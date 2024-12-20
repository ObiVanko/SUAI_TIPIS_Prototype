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
    public partial class ListItemControl : UserControl
    {
        public string ItemText
        {
            get => textLabel.Text;
            set => textLabel.Text = value;
        }

        public string ItemLinkText
        {
            get => eventLinkLabel.Text;
            set => eventLinkLabel.Text = value;
        }

        public int NotificationID { get; set; } // ID уведомления
        public int EventID { get; set; } // ID события (если есть)

        public event EventHandler ButtonClick;
        public event EventHandler LinkClicked;

        public ListItemControl()
        {
            InitializeComponent();
            readedButton.Click += (s, e) => ButtonClick?.Invoke(this, e);
            eventLinkLabel.Click += (s, e) => LinkClicked?.Invoke(this, e);
        }

        public void ButtinOff()
        {
            readedButton.Hide();
        }
    }
}
