using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AxBcAdmin
{
    public partial class DatabaseCredentialsDialog : Form
    {
        const int WINDOWS_AUTH = 0;
        const int SQL_AUTH = 1;

        void AnyClick(object sender, EventArgs e)
        {
            if (btnOK == sender)
            {
                PassbackResult();
            }
            else if (cboMode == sender)
            {
                AuthModeChanged();
            }
        }

        void FormInitialize()
        {
            CancelButton = btnCancel;
            AcceptButton = btnOK;

            btnOK.Click += AnyClick;
            cboMode.SelectedIndexChanged += AnyClick;

            string[] Modes = { "Windows Authentication", "SQL Server Authentication"};
            cboMode.Items.AddRange(Modes);
            cboMode.SelectedIndex = WINDOWS_AUTH;            
        }
        void PassbackResult()
        {
            if (cboMode.SelectedIndex == WINDOWS_AUTH)
                this.DialogResult = DialogResult.OK;
            else if ((cboMode.SelectedIndex == SQL_AUTH) && !string.IsNullOrWhiteSpace(edtUserName.Text) && !string.IsNullOrWhiteSpace(edtPassword.Text))
                this.DialogResult = DialogResult.OK;
        }
        void AuthModeChanged()
        {
            edtUserName.Enabled = cboMode.SelectedIndex == SQL_AUTH;
            edtPassword.Enabled = cboMode.SelectedIndex == SQL_AUTH;

            if (cboMode.SelectedIndex == WINDOWS_AUTH)
            {
                edtUserName.Clear();
                edtPassword.Clear();
            }
        }

        protected override void OnShown(EventArgs e)
        {
            if (!DesignMode)
                FormInitialize();
            base.OnShown(e);
        }

        public DatabaseCredentialsDialog()
        {
            InitializeComponent();
        }



        static public bool ShowModal(ref string UserName, ref string Password)
        {
            using (DatabaseCredentialsDialog F = new DatabaseCredentialsDialog())
            {
                if (F.ShowDialog() == DialogResult.OK)
                {
                    UserName = F.edtUserName.Text;
                    Password = F.edtPassword.Text;
                    return true;
                }
            }

            return false;
        }
    }
}
