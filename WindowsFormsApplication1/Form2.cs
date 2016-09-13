using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WallhavenSyncNm.src;

namespace WallhavenSyncNm
{
   

    public partial class FormLogin : Form
    {

        private SessionManager manager;

        public FormLogin(SessionManager manager)
        {
            InitializeComponent();
            this.manager = manager;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Boolean logged = manager.login(this.textBoxLogin.Text, this.textBoxPassword.Text);
            if (!logged)
            {
                this.labelInfo.Text = "Failed to login";
            }
            else
            {
                this.Dispose();
            }
        }
    }
}
