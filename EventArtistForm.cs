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
    public partial class EventArtistForm : Form
    {
        FeedForm feedForm;
        bool closingByBackButton = false;
        public EventArtistForm(FeedForm feedForm)
        {
            InitializeComponent();
            this.feedForm = feedForm;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            feedForm.Left = Left;
            feedForm.Top = Top;
            feedForm.Show();
            closingByBackButton = true;
            Hide();
        }

        private void EventArtistForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closingByBackButton)
            {
                Application.Exit();
            }
        }
    }
}
