namespace MambaSpamOutlookAddin
{
    partial class AddinModule
    {
        /// <summary>
        /// Required by designer
        /// </summary>
        private System.ComponentModel.IContainer components;
 
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary>
        /// Required by designer support - do not modify
        /// the following method
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.adxRibbonMain = new AddinExpress.MSO.ADXRibbonTab(this.components);
            this.adxGroupSecurity = new AddinExpress.MSO.ADXRibbonGroup(this.components);
            this.btnReportSpam = new AddinExpress.MSO.ADXRibbonButton(this.components);
            // 
            // adxRibbonMain
            // 
            this.adxRibbonMain.Caption = "Home";
            this.adxRibbonMain.Controls.Add(this.adxGroupSecurity);
            this.adxRibbonMain.Id = "adxRibbonTab_9a74e47662844ed3b045503b1bfedd0b";
            this.adxRibbonMain.IdMso = "TabMail";
            this.adxRibbonMain.Ribbons = ((AddinExpress.MSO.ADXRibbons)(((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose) 
            | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            // 
            // adxGroupSecurity
            // 
            this.adxGroupSecurity.Caption = "Secure";
            this.adxGroupSecurity.Controls.Add(this.btnReportSpam);
            this.adxGroupSecurity.Id = "adxRibbonGroup_c4124fda4648475dbe2cbbf922588f02";
            this.adxGroupSecurity.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxGroupSecurity.Ribbons = ((AddinExpress.MSO.ADXRibbons)(((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose) 
            | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            // 
            // btnReportSpam
            // 
            this.btnReportSpam.Caption = "Mark Spam";
            this.btnReportSpam.Glyph = global::MambaSpamOutlookAddin.Properties.Resources.red_envelope;
            this.btnReportSpam.Id = "adxRibbonButton_3546e03727964bbc8c24490f19568560";
            this.btnReportSpam.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnReportSpam.Ribbons = ((AddinExpress.MSO.ADXRibbons)(((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose) 
            | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            this.btnReportSpam.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.btnReportSpam.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnReportSpam_OnClick);
            // 
            // AddinModule
            // 
            this.AddinName = "MambaSpamOutlookAddin";
            this.SupportedApps = AddinExpress.MSO.ADXOfficeHostApp.ohaOutlook;

        }
        #endregion

        private AddinExpress.MSO.ADXRibbonTab adxRibbonMain;
        private AddinExpress.MSO.ADXRibbonGroup adxGroupSecurity;
        private AddinExpress.MSO.ADXRibbonButton btnReportSpam;
    }
}

