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
    public partial class ConfigItemUserControl : UserControl
    {
 
        ConfigItem ConfigItem;
        public ConfigItemUserControl()
        {
            InitializeComponent();
        }
        internal ConfigItemUserControl(ConfigItem ConfigItem): this()
        {
            this.ConfigItem = ConfigItem;
            lblKey.Text = ConfigItem.Name;


            edtValue.Visible = false;       // !CI.HasOptions;
            cboValueList.Visible = false;   // CI.HasOptions;

            if (!ConfigItem.HasOptions)
            {
                edtValue.Dock = DockStyle.Top;
                edtValue.Visible = true;
                edtValue.Text = ConfigItem.Value;
                edtValue.TextChanged += edtValue_TextChanged;
            }
            else
            {
                cboValueList.Dock = DockStyle.Top;
                cboValueList.Visible = true;
                cboValueList.Items.AddRange(ConfigItem.Options.ToArray());
                cboValueList.SelectedItem = ConfigItem.Value;
                cboValueList.SelectedValueChanged += cboValueList_SelectedValueChanged;
            } 

            lblKey.Click += lblKey_Click;
        }

        void cboValueList_SelectedValueChanged(object sender, EventArgs e)
        {
            ConfigItem.Value = cboValueList.SelectedItem.ToString();
        }

        void edtValue_TextChanged(object sender, EventArgs e)
        {
            ConfigItem.Value = edtValue.Text;
        }

        void lblKey_Click(object sender, EventArgs e)
        {
            App.Log("----------------------------------------------"); 
            App.Log(ConfigItem.Name);
            App.Log(ConfigItem.CommentText);
        }

    }
}
