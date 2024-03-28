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

    /// <summary>
    /// The input control of a <see cref="ConfigItem"/> instance.
    /// <para>Represents a setting in the <c>CustomSettings.config</c> file </para>
    /// </summary>
    public partial class ConfigItemUserControl : UserControl
    {
 
        ConfigItem ConfigItem;

        /* event handlers */
        void cboValueList_SelectedValueChanged(object sender, EventArgs e)
        {
            ConfigItem.Value = cboValueList.SelectedItem.ToString();
        }
        void edtValue_TextChanged(object sender, EventArgs e)
        {
            ConfigItem.Value = edtValue.Text;
        }
        void AnyClick(object sender, EventArgs e)
        {
            App.Log("----------------------------------------------");
            App.Log(ConfigItem.Name);
            App.Log(ConfigItem.CommentText);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ConfigItemUserControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor
        /// </summary>
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

            lblKey.Click += AnyClick;
            edtValue.Click += AnyClick;
            cboValueList.Click += AnyClick;
        }




    }
}
