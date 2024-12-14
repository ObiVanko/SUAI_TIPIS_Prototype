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
    public partial class EditProfilePlatformForm : Form
    {
        ProfilePlatformForm ProfilePlatformForm;
        public EditProfilePlatformForm(ProfilePlatformForm profilePlatformForm)
        {
            InitializeComponent();
            ProfilePlatformForm = profilePlatformForm;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            profilePlatformForm.Left = Left;
            profilePlatformForm.Top = Top;
            profilePlatformForm.Show();
            closingByBackButton = true;
            Hide();
        }

        private void EditProfilePlatformForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closingByBackButton)
            {
                Application.Exit();
            }
        }
    }
}
