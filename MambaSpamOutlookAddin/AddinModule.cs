using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;
using AddinExpress.MSO;
using MambaInteractive.Spam.Common;
using MambaSpamOutlookAddin.Properties;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace MambaSpamOutlookAddin
{
    /// <summary>
    ///   Add-in Express Add-in Module
    /// </summary>
    [GuidAttribute("5BBB2F42-59CF-4EBB-8578-ECD1D9C43F48"), ProgId("MambaSpamOutlookAddin.AddinModule")]
    public partial class AddinModule : AddinExpress.MSO.ADXAddinModule
    {
        public AddinModule()
        {
            Application.EnableVisualStyles();
            InitializeComponent();
            // Please add any initialization code to the AddinInitialize event handler
            btnReportSpam.Caption = Resources.Button_Label;
            btnReportSpam2.Caption = Resources.Button_Label;
                btnReportSpam3.Caption = Resources.Button_Label;
            adxGroupSecurity.Caption = Resources.Group_Label;
            adxGroupSecurity2.Caption = Resources.Group_Label;

        }
 
        #region Add-in Express automatic code
 
        // Required by Add-in Express - do not modify
        // the methods within this region
 
        public override System.ComponentModel.IContainer GetContainer()
        {
            if (components == null)
                components = new System.ComponentModel.Container();
            return components;
        }
 
        [ComRegisterFunctionAttribute]
        public static void AddinRegister(Type t)
        {
            AddinExpress.MSO.ADXAddinModule.ADXRegister(t);
        }
 
        [ComUnregisterFunctionAttribute]
        public static void AddinUnregister(Type t)
        {
            AddinExpress.MSO.ADXAddinModule.ADXUnregister(t);
        }
 
        public override void UninstallControls()
        {
            base.UninstallControls();
        }

        #endregion

        public static new AddinModule CurrentInstance 
        {
            get
            {
                return AddinExpress.MSO.ADXAddinModule.CurrentInstance as AddinModule;
            }
        }

        public Outlook._Application OutlookApp
        {
            get
            {
                return (HostApplication as Outlook._Application);
            }
        }

       

        private void btnReportSpam_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            if(Reporting.Application == null)
                Reporting.Application = this.OutlookApp.Application;

            Reporting.SendReports();
        }
    }
}

