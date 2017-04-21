using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Outlook;
using System.IO;
using System.Security.Policy;
using System.Windows.Forms;

namespace MambaInteractive.Spam.Common
{
    public class Reporting
    {
        private static Microsoft.Office.Interop.Outlook.Application _app;

        /// <summary>
        /// The application object to work with
        /// </summary>
        public static Microsoft.Office.Interop.Outlook.Application Application
        {
            get
            {
                return _app;
            }
            set
            {
                _app = value;
            }
        }

        private static Profile _profile;
        public static Profile Profile => _profile ?? (_profile = new MambaInteractive.Spam.Common.Profile(Profile.STR_PROFILE_ID));

        /// <summary>
        /// Sends the selected emails using the specified Profile
        /// </summary>
        /// <param name="ProfileID"></param>
        public static void SendReports()
        {
            if (Profile.AskVerify)
            {
                if (MessageBox.Show("Are you sure you want to report the selected item(s)?", "Report messages", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            Explorer exp = _app.Application.ActiveExplorer();

            // Create a collection to hold references to the attachments
            List<string> attachmentFiles = new List<string>();

            // Make sure at least one item is sent
            bool bItemsSelected = false;


            // First make sure the selected emails have been downloaded
            bool bNeedsSendReceive = false;
            for (int i = 1; i <= exp.Selection.Count; i++)
            {
                if (exp.Selection[i] is MailItem)
                {
                    MailItem mail = (MailItem)exp.Selection[i];
                    bItemsSelected = true;
                    // If the item has not been downloaded, mark for download
                    if (mail.DownloadState == OlDownloadState.olHeaderOnly)
                    {
                        bNeedsSendReceive = true;
                        mail.MarkForDownload = OlRemoteStatus.olMarkedForDownload;
                        mail.Save();
                    }
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(mail);
                }
            }
            if (bNeedsSendReceive)
            {
                // Download the marked emails
                // TODO: Trying to carry on at this point returns blank email bodies. Try and find a way of downloading them properly.
                _app.Session.SendAndReceive(false);
                MessageBox.Show("One of more emails were not downloaded from the server. Please ensure they are now downloaded and click report again",
                    "SpamGrabber", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (bItemsSelected)
            {
                // Now get references to all the items
                for (int i = 1; i <= exp.Selection.Count; i++)
                {
                    if (exp.Selection[i] is MailItem)
                    {
                        MailItem mail = (MailItem)exp.Selection[i];
                        if (Profile.UseRFC)
                        {
                            // Direct attaching seems to be buggy. Save the mailitem first
                            string fileName = Path.Combine(Path.GetTempPath(), Path.GetTempFileName() + ".msg");
                            mail.SaveAs(fileName);
                            attachmentFiles.Add(fileName);
                        }
                        else
                        {
                            // Create temp text file
                            string fileName = Path.Combine(Path.GetTempPath(), Path.GetTempFileName() + ".txt");
                            TextWriter tw = new StreamWriter(fileName);
                            tw.Write(GetMessageSource(mail, Profile.CleanHeaders));
                            tw.Close();
                            attachmentFiles.Add(fileName);
                        }
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(mail);
                    }
                }

                // Are we using a single email or one per report?
                if (Profile.SendMultiple)
                {
                    // Create the report email
                    MailItem reportEmail = CreateReportEmail();

                    // Attach the files
                    foreach (string attachment in attachmentFiles)
                    {
                        reportEmail.Attachments.Add(attachment);
                    }

                    // Do we need to keep a copy?
                    if (!Profile.KeepCopy)
                    {
                        reportEmail.DeleteAfterSubmit = true;
                    }

                    var storeId = _app.ActiveExplorer().CurrentFolder.StoreID;
                    foreach (Account acc in _app.ActiveExplorer().Session.Accounts)
                    {
                        if (acc.DeliveryStore.StoreID == storeId)
                        {
                           // reportEmail.SendUsingAccount = acc;
                            break;
                        }
                    }
                    // Send the report
                    reportEmail.Send();

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(reportEmail);
                }
                else
                {
                    // Send one email per report
                    foreach (string attachment in attachmentFiles)
                    {
                        MailItem reportEmail = CreateReportEmail();
                        reportEmail.Attachments.Add(attachment);
                        // Do we need to keep a copy?
                        if (!Profile.KeepCopy)
                        {
                            reportEmail.DeleteAfterSubmit = true;
                        }
                        reportEmail.Send();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(reportEmail);
                    }
                }

                // Sort out actions on the source emails
                for (int i = 1; i <= exp.Selection.Count; i++)
                {
                    if (exp.Selection[i] is MailItem)
                    {
                        MailItem mail = (MailItem)exp.Selection[i];
                        if (Profile.MarkAsReadAfterReport)
                        {
                            mail.UnRead = false;
                        }
                        if (Profile.MoveToFolderAfterReport)
                        {
                            mail.Move(_app.GetNamespace("MAPI").GetFolderFromID(
                                Profile.MoveFolderName, Profile.MoveFolderStoreId));
                        }
                        if (Profile.DeleteAfterReport)
                        {
                            mail.UnRead = false;
                            mail.Delete();
                        }
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(mail);
                    }
                }
            }
        }

        public static void SendReport(MailItem item)
        {
            
        }

        /// <summary>
        /// Returns the plain text source of the specified email
        /// </summary>
        /// <param name="message">The email message to view source of</param>
        /// <param name="cleanHeaders">Whether to clean out Exchange headers</param>
        /// <returns></returns>
        public static string GetMessageSource(MailItem message, bool cleanHeaders)
        {
            string headers = message.PropertyAccessor.GetProperty("http://schemas.microsoft.com/mapi/proptag/0x007D001E");
            return string.Format("{1}{0}{2}", Environment.NewLine,
                cleanHeaders ? MambaInteractive.Spam.Common.SGGlobals.RepairHeaders(headers, message.BodyFormat.Equals(OlBodyFormat.olFormatHTML)) : headers,
                message.BodyFormat == OlBodyFormat.olFormatHTML ? message.HTMLBody : message.Body);
        }

        /// <summary>
        /// Creates a report email using the settings in the specified
        /// reporting Profile
        /// </summary>
        /// <param name="Profile">The SpamGrabber Profile being used to report to</param>
        /// <returns></returns>
        private static MailItem CreateReportEmail()
        {

            Explorer exp = _app.Application.ActiveExplorer();
            string subject = Profile.ReportSubject.Replace("{{name}}", exp.Session.CurrentUser.Name);
            subject = subject.Replace("{{email}}", Application.Session.CurrentUser.AddressEntry.GetExchangeUser().PrimarySmtpAddress);
            // Create the report email
            MailItem reportEmail = (MailItem)_app.CreateItem(OlItemType.olMailItem);
            reportEmail.Subject = subject;
            string strTo = "";
            foreach (string toAddress in Profile.ToAddresses)
            {
                strTo += toAddress + ";";
            }
            reportEmail.To = strTo;

            string strBcc = "";
            foreach (string bccAddress in Profile.BccAddresses)
            {
                strBcc += bccAddress + ";";
            }
            reportEmail.BCC = strBcc;

            reportEmail.BodyFormat = OlBodyFormat.olFormatPlain;
            reportEmail.Body = Profile.MessageBody;
            return reportEmail;
        }
    }
}
