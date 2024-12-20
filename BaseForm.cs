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
    public partial class BaseForm : Form
    {
        public bool closingByBackButton = false;
        public BaseForm()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Size = new Size(268, 489);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
             
            if (e.CloseReason == CloseReason.UserClosing && closingByBackButton == false)
            {
                Application.Exit();
            }
        }
    }
}
