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
    public partial class EditBaseForm : BaseForm
    {
        public bool closingByBackButton = false;
        BaseForm motherForm;

        public EditBaseForm()
        {
        }

        public EditBaseForm(BaseForm motherForm)
        {   
            this.motherForm = motherForm;
        }

        public void backToMother()
        {
            motherForm.Left = Left;
            motherForm.Top = Top;
            motherForm.Show();
            closingByBackButton = true;
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Проверяем причину закрытия: крестик (UserClosing)
            if (e.CloseReason == CloseReason.UserClosing && closingByBackButton == false)
            {
                Application.Exit();
            }
        }
    }
}