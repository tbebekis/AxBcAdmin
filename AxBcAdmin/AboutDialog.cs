﻿namespace AxBcAdmin
{
    public partial class AboutDialog : Form
    {
 

        void FormInitialize()
        {
            lblGenerator.LinkClicked += AnyLinkLableClick; 
            lblGithub.LinkClicked += AnyLinkLableClick;
            lblAntyxSoft.LinkClicked += AnyLinkLableClick;
        }

        private void AnyLinkLableClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel lbl = sender as LinkLabel;
            string Url = lbl.Text;
 
            ProcessStartInfo PSI = new ProcessStartInfo();
            PSI.FileName = Url;
            PSI.UseShellExecute = true;
            Process.Start(PSI);

            lbl.LinkVisited = true;
        }

        protected override void OnShown(EventArgs e)
        {
            if (!DesignMode)
                FormInitialize();
            base.OnShown(e);
        }

        public AboutDialog()
        {
            InitializeComponent();
        }
    }
}
