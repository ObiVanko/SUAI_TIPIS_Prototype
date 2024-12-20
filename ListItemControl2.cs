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
    public partial class ListItemControl2 : UserControl
    {
        public ListItemControl2()
        {
            InitializeComponent();
            readedButton.Click += (s, e) => ButtonClick?.Invoke(this, e);
            eventLinkLabel.Click += (s, e) => EventLinkClicked?.Invoke(this, e);
            artistLinkLabel.Click += (s, e) => ArtistLinkClicked?.Invoke(this, e);
        }
        public string ItemText
        {
            get => textLabel.Text;
            set => textLabel.Text = value;
        }

        public string ItemEventLinkText
        {
            get => eventLinkLabel.Text;
            set => eventLinkLabel.Text = value;
        }

        public string ItemArtistLinkText
        {
            get => artistLinkLabel.Text;
            set => artistLinkLabel.Text = value;
        }

        public int NotificationID { get; set; } 
        public int EventID { get; set; } 

        public int ArtistID { get; set; }

        public event EventHandler ButtonClick;
        public event EventHandler EventLinkClicked;
        public event EventHandler ArtistLinkClicked;

        public void ButtinOff()
        {
            readedButton.Hide();
        }
    }
}
