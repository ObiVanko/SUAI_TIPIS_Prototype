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
    public partial class EditEventForm : Form
    {
        Form motherForm;
        bool closingByBackButton = false;

        public EditEventForm(Form motherForm)
        {
            InitializeComponent();
            this.motherForm = motherForm;
            
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            motherForm.Left = Left;
            motherForm.Top = Top;
            motherForm.Show();
            closingByBackButton = true;
            Hide();
        }

        private void EditEventForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closingByBackButton)
            {
                Application.Exit();
            }
        }
    }
}
