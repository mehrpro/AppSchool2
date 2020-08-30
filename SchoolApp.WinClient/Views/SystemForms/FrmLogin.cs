using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolApp.WinClient.Views.SystemForms
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
