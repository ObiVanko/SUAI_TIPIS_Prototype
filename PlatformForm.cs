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
    public partial class PlatformForm : BaseForm
    {
        public PlatformForm()
        {
            InitializeComponent();
        }

        private void editProfileButton_Click(object sender, EventArgs e)
        {
            EditProfilePlatformForm editProfilePlatformForm = new EditProfilePlatformForm(this);
            editProfilePlatformForm.Left = Left;
            editProfilePlatformForm.Top = Top;
            editProfilePlatformForm.Show();

            Hide();
        }

        private void addEventButton_Click(object sender, EventArgs e)
        {
            EditEventForm editEventForm = new EditEventForm(this);
            editEventForm.Left = Left;
            editEventForm.Top = Top;
            editEventForm.Show();

            Hide();
        }
    }
}
