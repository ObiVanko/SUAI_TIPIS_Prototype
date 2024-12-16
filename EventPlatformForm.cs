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
    public partial class EventPlatformForm : EditBaseForm
    {     
        public EventPlatformForm(BaseForm motherForm) : base(motherForm)
        {
            InitializeComponent();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditEventForm editEventForm = new EditEventForm(this);
            editEventForm.Left = Left;
            editEventForm.Top = Top;
            editEventForm.Show();
            Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            backToMother();
        }
    }
}
