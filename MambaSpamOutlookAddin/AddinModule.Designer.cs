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
            this.adxRibbonButton2 = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxRibbonContextMenu = new AddinExpress.MSO.ADXRibbonContextMenu(this.components);
            this.btnReportSpam3 = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxRibbonRead = new AddinExpress.MSO.ADXRibbonTab(this.components);
            this.adxGroupSecurity2 = new AddinExpress.MSO.ADXRibbonGroup(this.components);
            this.btnReportSpam2 = new AddinExpress.MSO.ADXRibbonButton(this.components);
            // 
            // adxRibbonMain
            // 
            this.adxRibbonMain.Caption = "Home";
            this.adxRibbonMain.Controls.Add(this.adxGroupSecurity);
            this.adxRibbonMain.Id = "adxRibbonTab_9a74e47662844ed3b045503b1bfedd0b";
            this.adxRibbonMain.IdMso = "TabMail";
            this.adxRibbonMain.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            // 
            // adxGroupSecurity
            // 
            this.adxGroupSecurity.Caption = "Secure";
            this.adxGroupSecurity.Controls.Add(this.btnReportSpam);
            this.adxGroupSecurity.Id = "adxRibbonGroup_c4124fda4648475dbe2cbbf922588f02";
            this.adxGroupSecurity.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxGroupSecurity.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            // 
            // btnReportSpam
            // 
            this.btnReportSpam.Caption = "Mark Spam 2";
            this.btnReportSpam.Glyph = global::MambaSpamOutlookAddin.Properties.Resources.red_envelope;
            this.btnReportSpam.Id = "adxRibbonButton_3546e03727964bbc8c24490f19568560";
            this.btnReportSpam.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnReportSpam.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            this.btnReportSpam.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.btnReportSpam.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnReportSpam_OnClick);
            // 
            // adxRibbonButton2
            // 
            this.adxRibbonButton2.Id = "adxRibbonButton_b1dc03991053443f899a54d38c6089cd";
            this.adxRibbonButton2.ImageTransparentColor = System.Drawing.Color.Transparent;
            // 
            // adxRibbonContextMenu
            // 
            this.adxRibbonContextMenu.ContextMenuNames.AddRange(new string[] {
            "Outlook.Explorer.ContextMenuMailItem",
            "Outlook.Explorer.ContextMenuMultipleItems"});
            this.adxRibbonContextMenu.Controls.Add(this.btnReportSpam3);
            this.adxRibbonContextMenu.Ribbons = ((AddinExpress.MSO.ADXRibbons)(((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose) 
            | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            // 
            // btnReportSpam3
            // 
            this.btnReportSpam3.Glyph = global::MambaSpamOutlookAddin.Properties.Resources.red_envelope;
            this.btnReportSpam3.Id = "adxRibbonButton_73266200828f48b9b13665966ef366c2";
            this.btnReportSpam3.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnReportSpam3.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnReportSpam_OnClick);
            // 
            // adxRibbonRead
            // 
            this.adxRibbonRead.Caption = "Home";
            this.adxRibbonRead.Controls.Add(this.adxGroupSecurity2);
            this.adxRibbonRead.Id = "adxRibbonTab_1be865c35e2e48c7902154f3d58d6c45";
            this.adxRibbonRead.IdMso = "TabReadMessage";
            this.adxRibbonRead.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose)));
            // 
            // adxGroupSecurity2
            // 
            this.adxGroupSecurity2.Caption = "Security";
            this.adxGroupSecurity2.Controls.Add(this.btnReportSpam2);
            this.adxGroupSecurity2.Id = "adxRibbonGroup_eb91378c6d07472a883060f65ceb33be";
            this.adxGroupSecurity2.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxGroupSecurity2.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose)));
            // 
            // btnReportSpam2
            // 
            this.btnReportSpam2.Caption = "Mark Spam";
            this.btnReportSpam2.Glyph = global::MambaSpamOutlookAddin.Properties.Resources.red_envelope;
            this.btnReportSpam2.Id = "adxRibbonButton_5573484ee16e44f385bdc0679aae9614";
            this.btnReportSpam2.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnReportSpam2.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose)));
            this.btnReportSpam2.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.btnReportSpam2.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnReportSpam_OnClick);
            // 
            // AddinModule
            // 
            this.AddinName = "MambaSpamOutlookAddin";
            this.RegisterForAllUsers = true;
            this.SupportedApps = AddinExpress.MSO.ADXOfficeHostApp.ohaOutlook;

        }
        #endregion

        private AddinExpress.MSO.ADXRibbonTab adxRibbonMain;
        private AddinExpress.MSO.ADXRibbonGroup adxGroupSecurity;
        private AddinExpress.MSO.ADXRibbonButton btnReportSpam;
        private AddinExpress.MSO.ADXRibbonButton adxRibbonButton2;
        private AddinExpress.MSO.ADXRibbonContextMenu adxRibbonContextMenu;
        private AddinExpress.MSO.ADXRibbonButton btnReportSpam3;
        private AddinExpress.MSO.ADXRibbonTab adxRibbonRead;
        private AddinExpress.MSO.ADXRibbonGroup adxGroupSecurity2;
        private AddinExpress.MSO.ADXRibbonButton btnReportSpam2;
    }
}

