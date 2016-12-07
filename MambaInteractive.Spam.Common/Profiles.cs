#region Imports

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;

#endregion

namespace MambaInteractive.Spam.Common
{

    #region Profile Class

    /// <summary>
    ///     Class symbolising a user profile for SpamGrabber
    /// </summary>
    public class Profile
    {
        #region Class Data

        private string _strProfileName;
        private bool? _blnCleanHeaders;
        private List<string> _arrToAddresses;
        private List<string> _arrBccAddresses;
        private bool? _blnDeleteAfterReport;
        private bool? _blnMarkAsReadAfterReport;
        private bool? _blnMoveToFolderAfterReport;
        private string _strMoveFolderName;
        private string _strMoveFolderStoreId;
        private string _strReportSubject;
        private string _strReportEndText;
        private string _strMessageBody;
        private bool? _blnAskVerify;
        private bool? _blnKeepCopy;
        private bool? _blnSendMultiple;
        private bool? _blnUseRFC;
        private bool? _blnSendReceiveAfterReport;
        public const string STR_PROFILE_ID = "4CEFF1D4-293F-4EEB-A516-5F1331BE1612";

        private static class Defaults
        {
            public const string StrProfileName = "Default";
            public const bool BlnDeleteAfterReport = false;
            public const bool BlnMarkAsReadAfterReport = false;
            public const bool BlnMoveToFolderAfterReport = false;
            public const string StrMoveFolderName = "";
            public const string StrMoveFolderStoreId = "";
            public const string StrReportSubject = "Spam Report";
            public const string StrMessageBody = "Uh Oh, Spam!";
            public const string StrReportEndText = "The End";
            public const bool BlnAskVerify = true;
            public const bool BlnKeepCopy = true;
            public const bool BlnSendMultiple = true;
            public const bool BlnUseRFC = true;
            public const bool BlnSendReceiveAfterReport = true;
            public const bool BlnCleanHeaders = false;
            public const string StrToAddresses = "daniel.raby@allendevaux.com";
            public const string StrBccAddresses = "";
        }
        static readonly char[] splitter = { ';' };


        #endregion

        #region Constructors

        /// <summary>
        ///     Contructor for creating a new profile
        /// </summary>
        public Profile()
        {
            // This is a new profile, so assign a GUID
            Id = STR_PROFILE_ID;
            _arrToAddresses = Defaults.StrToAddresses.Split(splitter).ToList();
            _arrBccAddresses = Defaults.StrBccAddresses.Split(splitter).ToList();
            // Load in all the default options and save
            Save();
        }

        /// <summary>
        ///     Constructor to load an existing profile from the registry
        /// </summary>
        /// <param name="pstrProfileId"></param>
        public Profile(string pstrProfileId)
        {
            // Set the Profile ID
            Id = pstrProfileId;
            // Load the data from the registry
            LoadProfile();
        }

        #endregion

        # region Properties

        /// <summary>
        ///     The Outlook folder ID to move messages to, if MoveToFolderAfterReport is true
        /// </summary>
        public string MoveFolderName
        {
            get
            {
                if (_strMoveFolderName == null)
                {
                    // Default
                    _strMoveFolderName = Defaults.StrMoveFolderName;
                }
                return _strMoveFolderName;
            }
            set { _strMoveFolderName = value; }
        }

        /// <summary>
        ///     The Outlook folder Store ID to move messages to, if MoveToFolderAfterReport is true
        /// </summary>
        public string MoveFolderStoreId
        {
            get
            {
                if (_strMoveFolderStoreId == null)
                {
                    // Default
                    _strMoveFolderStoreId = Defaults.StrMoveFolderStoreId;
                }
                return _strMoveFolderStoreId;
            }
            set { _strMoveFolderStoreId = value; }
        }

        /// <summary>
        ///     The email subject of the report
        /// </summary>
        public string ReportSubject
        {
            get
            {
                if (_strReportSubject == null)
                {
                    // Default
                    _strReportSubject = Defaults.StrReportSubject;
                }
                return _strReportSubject;
            }
            set { _strReportSubject = value; }
        }

        /// <summary>
        ///     Text to append to the end of each spam message in the report
        /// </summary>
        public string ReportEndText
        {
            get
            {
                if (_strReportEndText == null)
                {
                    // Default
                    _strReportEndText = Defaults.StrReportEndText;
                }
                return _strReportEndText;
            }
            set { _strReportEndText = value; }
        }

        /// <summary>
        ///     Text to display in the report body
        /// </summary>
        public string MessageBody
        {
            get
            {
                if (_strMessageBody == null)
                {
                    // Default
                    _strMessageBody = Defaults.StrMessageBody;
                }
                return _strMessageBody;
            }
            set { _strMessageBody = value; }
        }

        /// <summary>
        ///     An array of all the requested addresses to use in the To: field of the report
        /// </summary>
        public List<string> ToAddresses
        {
            get
            {
                if (_arrToAddresses == null)
                {
                    _arrToAddresses = new List<string>();
                }
                return _arrToAddresses;
            }
        }

        /// <summary>
        ///     An array of all the requested addresses to use in the BCC: field of the report
        /// </summary>
        public List<string> BccAddresses
        {
            get
            {
                if (_arrBccAddresses == null)
                {
                    _arrBccAddresses = new List<string>();
                }
                return _arrBccAddresses;
            }
        }

        /// <summary>
        ///     Whether or not to strip out headers that SpamCop cannot understand
        /// </summary>
        public bool CleanHeaders
        {
            get
            {
                if (_blnCleanHeaders == null)
                {
                    // Default
                    _blnCleanHeaders = Defaults.BlnCleanHeaders;
                }
                return (bool) _blnCleanHeaders;
            }
            set { _blnCleanHeaders = value; }
        }

        /// <summary>
        ///     Whether or not to delete the spam after reporting it
        /// </summary>
        public bool DeleteAfterReport
        {
            get
            {
                if (_blnDeleteAfterReport == null)
                {
                    // Default
                    _blnDeleteAfterReport = Defaults.BlnDeleteAfterReport;
                }
                return (bool) _blnDeleteAfterReport;
            }
            set { _blnDeleteAfterReport = value; }
        }

        /// <summary>
        ///     Whether or not to mark spam as read after reporting
        /// </summary>
        public bool MarkAsReadAfterReport
        {
            get
            {
                if (_blnMarkAsReadAfterReport == null)
                {
                    // Default
                    _blnMarkAsReadAfterReport = Defaults.BlnMarkAsReadAfterReport;
                }
                return (bool) _blnMarkAsReadAfterReport;
            }
            set { _blnMarkAsReadAfterReport = value; }
        }

        /// <summary>
        ///     Whether or not to move the spam to another folder
        /// </summary>
        public bool MoveToFolderAfterReport
        {
            get
            {
                if (_blnMoveToFolderAfterReport == null)
                {
                    // Default
                    _blnMoveToFolderAfterReport = Defaults.BlnMoveToFolderAfterReport;
                }
                return (bool) _blnMoveToFolderAfterReport;
            }
            set { _blnMoveToFolderAfterReport = value; }
        }

        /// <summary>
        ///     Whether or not to ask for confirmation before sending reports
        /// </summary>
        public bool AskVerify
        {
            get
            {
                if (_blnAskVerify == null)
                {
                    // Default
                    _blnAskVerify = Defaults.BlnAskVerify;
                }
                return (bool) _blnAskVerify;
            }
            set { _blnAskVerify = value; }
        }

        /// <summary>
        ///     Whether or not to keep a copy of the report in the sent items folder
        /// </summary>
        public bool KeepCopy
        {
            get
            {
                if (_blnKeepCopy == null)
                {
                    // Default
                    _blnKeepCopy = Defaults.BlnKeepCopy;
                }
                return (bool) _blnKeepCopy;
            }
            set { _blnKeepCopy = value; }
        }

        /// <summary>
        ///     Whether or not to send all spam messages as one report. If set to
        ///     false then one report email will be used per spam
        /// </summary>
        public bool SendMultiple
        {
            get
            {
                if (_blnSendMultiple == null)
                {
                    // Default
                    _blnSendMultiple = Defaults.BlnSendMultiple;
                }
                return (bool) _blnSendMultiple;
            }
            set { _blnSendMultiple = value; }
        }

        /// <summary>
        ///     Whether or not to use RFC822 to attach the emails. Does not work with Spamcop.
        /// </summary>
        public bool UseRFC
        {
            get
            {
                if (_blnUseRFC == null)
                {
                    // Default
                    _blnUseRFC = Defaults.BlnUseRFC;
                }
                return (bool) _blnUseRFC;
            }
            set { _blnUseRFC = value; }
        }

        /// <summary>
        ///     Attempt a send / receive after reporting
        /// </summary>
        public bool SendReceiveAfterReport
        {
            get
            {
                if (_blnSendReceiveAfterReport == null)
                {
                    // Default
                    _blnSendReceiveAfterReport = Defaults.BlnSendReceiveAfterReport;
                }
                return (bool) _blnSendReceiveAfterReport;
            }
            set { _blnSendReceiveAfterReport = value; }
        }

        /// <summary>
        ///     The user-defined friendly name of the profile
        /// </summary>
        public string Name
        {
            get
            {
                if (_strProfileName == null)
                {
                    // Default
                    _strProfileName = Defaults.StrProfileName;
                }
                return _strProfileName;
            }
            set { _strProfileName = value; }
        }

        /// <summary>
        ///     The GUID of the profile as stored in the registry
        /// </summary>
        public string Id { get; }

        #endregion

        #region Methods
        /// <summary>
        ///     Loads the specified profile from the registry
        /// </summary>
        private void LoadProfile()
        {
            var strKey = SGGlobals.BaseRegistryKey + "Profiles\\" + Id;

            // Make sure the key exists
            if (!SGGlobals.DoesKeyExist(strKey))
            {
                try
                {
                    Save();
                    LoadProfile();
                    return;
                }
                catch
                {
                    throw new ProfileNotFoundException(String.Format("The profile {0} Could not be found", Id));
                }
            }
                
            // Load the values into the class data
            _strProfileName = SGGlobals.LoadValue(strKey, "ProfileName", Defaults.StrProfileName);
            _blnDeleteAfterReport = SGGlobals.LoadValue(strKey, "DeleteAfterReport", Defaults.BlnDeleteAfterReport);
            _blnMarkAsReadAfterReport = SGGlobals.LoadValue(strKey, "MarkAsReadAfterReport", Defaults.BlnMarkAsReadAfterReport);
            _blnMoveToFolderAfterReport = SGGlobals.LoadValue(strKey, "MoveToFolderAfterReport", Defaults.BlnMoveToFolderAfterReport);
            _strMoveFolderName = SGGlobals.LoadValue(strKey, "MoveFolderName", Defaults.StrMoveFolderName);
            _strMoveFolderStoreId = SGGlobals.LoadValue(strKey, "MoveFolderStoreId", Defaults.StrMoveFolderStoreId);
            _strReportSubject = SGGlobals.LoadValue(strKey, "ReportSubject", Defaults.StrReportSubject);
            _strMessageBody = SGGlobals.LoadValue(strKey, "MessageBody", Defaults.StrMessageBody);
            _strReportEndText = SGGlobals.LoadValue(strKey, "ReportEndText", Defaults.StrReportEndText);
            _blnAskVerify = SGGlobals.LoadValue(strKey, "AskVerify", Defaults.BlnAskVerify);
            _blnKeepCopy = SGGlobals.LoadValue(strKey, "KeepCopy", Defaults.BlnKeepCopy);
            _blnSendMultiple = SGGlobals.LoadValue(strKey, "SendMultiple", Defaults.BlnSendMultiple);
            _blnUseRFC = SGGlobals.LoadValue(strKey, "UseRFC", Defaults.BlnUseRFC);
            _blnSendReceiveAfterReport = SGGlobals.LoadValue(strKey, "SendReceiveAfterReport", Defaults.BlnDeleteAfterReport);
            _blnCleanHeaders = SGGlobals.LoadValue(strKey, "CleanHeaders", Defaults.BlnCleanHeaders);

            // Load the addresses into the array lists
            var strToAddresses = SGGlobals.LoadValue(strKey, "ToAddress", Defaults.StrToAddresses).Split(splitter);
            _arrToAddresses = new List<string>();
            foreach (var strAddress in strToAddresses)
            {
                if (!string.IsNullOrEmpty(strAddress))
                {
                    _arrToAddresses.Add(strAddress);
                }
            }
            var strBccAddresses = SGGlobals.LoadValue(strKey, "BccAddress", Defaults.StrBccAddresses).Split(splitter);
            _arrBccAddresses = new List<string>();
            foreach (var strAddress in strBccAddresses)
            {
                if (!string.IsNullOrEmpty(strAddress))
                {
                    _arrBccAddresses.Add(strAddress);
                }
            }
        }

        /// <summary>
        ///     Saves the current profile to the registry
        /// </summary>
        public void Save()
        {
            // Declare registry key we will be working with
            //RegistryKey regProfileKey;
            var strKey = SGGlobals.BaseRegistryKey + "Profiles\\" + Id;

            // Determine if this is a new profile
            if (SGGlobals.DoesKeyExist(strKey) == false)
            {
                // Create the new registry key
                //regProfileKey = Registry.CurrentUser.CreateSubKey(SGGlobals.BaseRegistryKey +
                //    "Profiles\\" + this._strProfileId);
                SGGlobals.CreateKey(Id, SGGlobals.BaseRegistryKey + "Profiles");
            }

            SGGlobals.SaveSetting(strKey, "ProfileName", Name);
            SGGlobals.SaveSetting(strKey, "CleanHeaders", CleanHeaders);
            SGGlobals.SaveSetting(strKey, "DeleteAfterReport", DeleteAfterReport);
            SGGlobals.SaveSetting(strKey, "MarkAsReadAfterReport", MarkAsReadAfterReport);
            SGGlobals.SaveSetting(strKey, "MoveToFolderAfterReport", MoveToFolderAfterReport);
            SGGlobals.SaveSetting(strKey, "MoveFolderName", MoveFolderName);
            SGGlobals.SaveSetting(strKey, "MoveFolderStoreId", MoveFolderStoreId);
            SGGlobals.SaveSetting(strKey, "ReportSubject", ReportSubject);
            SGGlobals.SaveSetting(strKey, "ReportEndText", ReportEndText);
            SGGlobals.SaveSetting(strKey, "MessageBody", MessageBody);
            SGGlobals.SaveSetting(strKey, "AskVerify", AskVerify);
            SGGlobals.SaveSetting(strKey, "KeepCopy", KeepCopy);
            SGGlobals.SaveSetting(strKey, "SendMultiple", SendMultiple);
            SGGlobals.SaveSetting(strKey, "UseRFC", UseRFC);
            SGGlobals.SaveSetting(strKey, "SendReceiveAfterReport", SendReceiveAfterReport);
            
            // Save the array lists
            var strToAddress = "";
            var strBccAddress = "";
            foreach (var strAddress in ToAddresses)
            {
                // remove excess ;
                if (strAddress != string.Empty)
                    strToAddress += strAddress.Replace(";", "") + ";";
            }
            foreach (var strAddress in BccAddresses)
            {
                if (strAddress != string.Empty)
                    strBccAddress += strAddress.Replace(";", "") + ";";
            }
            SGGlobals.SaveSetting(strKey, "ToAddress", strToAddress);
            SGGlobals.SaveSetting(strKey, "BccAddress", strBccAddress);
        }

        #endregion
    }

    #endregion

    #region Exception Class

    /// <summary>
    ///     Exception thrown if calling code attempts to load
    ///     a profile that does not exist
    /// </summary>
    public class ProfileNotFoundException : Exception
    {
        public ProfileNotFoundException()
        {
        }

        public ProfileNotFoundException(string message) : base(message)
        {
        }
    }

    #endregion

    #region Profile list class

    /// <summary>
    ///     Static class to return a list of the current user's profile IDs
    /// </summary>
    public static class UserProfiles
    {
        private static ArrayList _arrProfiles;

        /// <summary>
        ///     Returns an array list of all the user's profile IDs
        /// </summary>
        public static ArrayList ProfileList
        {
            get
            {
                if (_arrProfiles == null)
                {
                    // Make sure the root key exists
                    SGGlobals.CreateBaseKey();

                    // Populate the list
                    _arrProfiles = new ArrayList();

                    // Get the root HKCU key
                    var regSettings = Registry.CurrentUser;

                    // Get all the subkeys
                    regSettings = regSettings.OpenSubKey(SGGlobals.BaseRegistryKey +
                                                         "Profiles\\");
                    var strProfiles = regSettings.GetSubKeyNames();
                    foreach (var strProfile in strProfiles)
                    {
                        _arrProfiles.Add(new Profile(strProfile));
                    }
                }
                // Return the value
                return _arrProfiles;
            }
        }

        /// <summary>
        ///     Clears the cache of user profiles to allow the calling
        ///     code to load in the latest settings
        /// </summary>
        public static void ClearProfileCache()
        {
            _arrProfiles = null;
        }

        /// <summary>
        ///     Get a profile from the collection by name
        /// </summary>
        /// <param name="pstrName"></param>
        /// <returns></returns>
        public static Profile GetProfileByName(string pstrName)
        {
            Profile objProfile = null;

            // Loop through all the profiles
            foreach (Profile objTempProfile in ProfileList)
            {
                if (objTempProfile.Name == pstrName)
                {
                    // Found the correct one, set it to be the return profile
                    objProfile = objTempProfile;
                }
            }
            if (objProfile == null)
            {
                throw new ProfileNotFoundException("The selected profile name does not exist");
            }

            return objProfile;
        }

        /// <summary>
        ///     Deletes a profile from the registry
        /// </summary>
        /// <param name="pstrProfileName"></param>
        public static void DeleteProfile(string pstrProfileName)
        {
            // Get the ID of the profile (throws exception if not found)
            var strProfileId = GetProfileByName(pstrProfileName).Id;

            // Get the root HKCU key
            var regSettings = Registry.CurrentUser.OpenSubKey(
                SGGlobals.BaseRegistryKey + "Profiles\\", true);

            // Delete the key
            regSettings.DeleteSubKeyTree(strProfileId);
        }
    }

    #endregion
}