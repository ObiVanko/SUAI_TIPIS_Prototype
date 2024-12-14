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
    public partial class ProfilePlatformForm : Form
    {
        public event Action<int, int> SwitchToFeed;
        public ProfilePlatformForm()
        {
            InitializeComponent();
        }

        private void feedButton_Click(object sender, EventArgs e)
        {
            SwitchToFeed?.Invoke(Left, Top);
            Hide();
        }

        private void ProfilePlatformForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void editProfileButton_Click(object sender, EventArgs e)
        {
            EditProfilePlatformForm editProfilePlatformForm = new EditProfilePlatformForm(this);
            editProfilePlatformForm.Left = Left;
            editProfilePlatformForm.Top = Top;
            editProfilePlatformForm.Show();

            Hide();
        }
    }
}
