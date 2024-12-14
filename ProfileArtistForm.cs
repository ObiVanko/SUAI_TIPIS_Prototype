﻿using System;
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
    public partial class ProfileArtistForm : Form
    {
        public event Action<int, int> SwitchToFeed;
        public ProfileArtistForm()
        {
            InitializeComponent();
        }

        private void feedButton_Click(object sender, EventArgs e)
        {
            SwitchToFeed?.Invoke(Left, Top);
            Hide();
        }

        private void ProfileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void editProfileButton_Click(object sender, EventArgs e)
        {
            EditProfileArtistForm editProfileArtistForm = new EditProfileArtistForm(this);
            editProfileArtistForm.Left = Left;
            editProfileArtistForm.Top = Top;    
            editProfileArtistForm.Show();

            Hide();
        }
    }
}