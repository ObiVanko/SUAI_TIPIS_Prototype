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
    public partial class EditProfileArtistForm : Form
    {
        ProfileArtistForm profileArtistForm;
        bool closingByBackButton = false;
        public EditProfileArtistForm(ProfileArtistForm profileArtistForm)
        {
            InitializeComponent();
            this.profileArtistForm = profileArtistForm;
        }

        private void backButton_Click(object sender, EventArgs e)
        {            
            profileArtistForm.Left = Left;
            profileArtistForm.Top = Top;
            profileArtistForm.Show();
            closingByBackButton = true;
            Hide();
        }

        private void EditProfileArtistForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closingByBackButton)
            {
                Application.Exit();
            }
        }
    }
}
