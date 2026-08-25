namespace OutlookAddIn1
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.AIAssistGrp = this.Factory.CreateRibbonGroup();
            this.genEmailBtn = this.Factory.CreateRibbonButton();
            this.emailSplchkBtn = this.Factory.CreateRibbonButton();
            this.langConBtn = this.Factory.CreateRibbonButton();
            this.repAssistBtn = this.Factory.CreateRibbonButton();
            this.chatbotBtn = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.AIAssistGrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.AIAssistGrp);
            this.tab1.Label = "AI Add-ins";
            this.tab1.Name = "tab1";
            // 
            // AIAssistGrp
            // 
            this.AIAssistGrp.Items.Add(this.genEmailBtn);
            this.AIAssistGrp.Items.Add(this.emailSplchkBtn);
            this.AIAssistGrp.Items.Add(this.langConBtn);
            this.AIAssistGrp.Items.Add(this.repAssistBtn);
            this.AIAssistGrp.Items.Add(this.chatbotBtn);
            this.AIAssistGrp.Label = "AI Assist";
            this.AIAssistGrp.Name = "AIAssistGrp";
            // 
            // genEmailBtn
            // 
            this.genEmailBtn.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.genEmailBtn.Image = global::OutlookAddIn1.Properties.Resources.generate_email_image1;
            this.genEmailBtn.Label = "Generate Email";
            this.genEmailBtn.Name = "genEmailBtn";
            this.genEmailBtn.ScreenTip = "Generate a complete email using AI based on your instructions.";
            this.genEmailBtn.ShowImage = true;
            this.genEmailBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.genEmailBtn_Click);
            // 
            // emailSplchkBtn
            // 
            this.emailSplchkBtn.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.emailSplchkBtn.Image = global::OutlookAddIn1.Properties.Resources.spellcheck;
            this.emailSplchkBtn.Label = "Email Spell Check";
            this.emailSplchkBtn.Name = "emailSplchkBtn";
            this.emailSplchkBtn.ScreenTip = "Check your email for spelling and grammar mistakes and suggest corrections.";
            this.emailSplchkBtn.ShowImage = true;
            this.emailSplchkBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.emailSplchkBtn_Click);
            // 
            // langConBtn
            // 
            this.langConBtn.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.langConBtn.Image = global::OutlookAddIn1.Properties.Resources.translation;
            this.langConBtn.Label = "Language Conversion";
            this.langConBtn.Name = "langConBtn";
            this.langConBtn.ScreenTip = "Translate your email content into another language using AI.";
            this.langConBtn.ShowImage = true;
            this.langConBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.langConBtn_Click);
            // 
            // repAssistBtn
            // 
            this.repAssistBtn.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.repAssistBtn.Image = global::OutlookAddIn1.Properties.Resources.reply;
            this.repAssistBtn.Label = "Reply Assist";
            this.repAssistBtn.Name = "repAssistBtn";
            this.repAssistBtn.ScreenTip = "Generate an AI-assisted reply to the current email.";
            this.repAssistBtn.ShowImage = true;
            this.repAssistBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.repAssistBtn_Click);
            // 
            // chatbotBtn
            // 
            this.chatbotBtn.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.chatbotBtn.Image = global::OutlookAddIn1.Properties.Resources.chatbot;
            this.chatbotBtn.Label = "Talk to Chatbot";
            this.chatbotBtn.Name = "chatbotBtn";
            this.chatbotBtn.ScreenTip = "Open the AI assistant to ask questions and get help while working in Outlook.";
            this.chatbotBtn.ShowImage = true;
            this.chatbotBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.chatbotBtn_Click);
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.Outlook.Explorer, Microsoft.Outlook.Mail.Compose";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.AIAssistGrp.ResumeLayout(false);
            this.AIAssistGrp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup AIAssistGrp;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton genEmailBtn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton emailSplchkBtn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton langConBtn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton repAssistBtn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton chatbotBtn;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
