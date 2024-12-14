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
    public partial class EventPlatformForm : Form
    {
        FeedForm feedForm;
        
        bool closingByBackButton = false;
        public EventPlatformForm(FeedForm feedForm)
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

        private void EventPlatformForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closingByBackButton)
            {
                Application.Exit();
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditEventForm editEventForm = new EditEventForm();
            editEventForm.Left = Left;
            editEventForm.Top = Top;
            editEventForm.Show();
            Hide();
        }
    }
}
