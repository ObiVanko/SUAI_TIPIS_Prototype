using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype
{
    public partial class RegistrationForm : Form
    {
        LoginForm loginForm;
        bool closingByBackButton = false;
        public RegistrationForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            loginForm.Left = Left;
            loginForm.Top = Top;
            loginForm.Show();
            closingByBackButton = true;
            this.Close();
        }

        private void RegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closingByBackButton)
            {
                Application.Exit();
            }
        }
    }
}
