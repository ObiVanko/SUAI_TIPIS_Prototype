using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace Prototype
{
    public partial class FeedForm : BaseForm
    {
        public FeedForm()
        {
            InitializeComponent();
            SetupListView();
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            //SwitchToArtistProfile?.Invoke(Left, Top);
            //Hide();

            
            Hide();
        }

        private void SetupListView()
        {
            // Установка режимов отображения
            feedListView.View = View.Tile; // Режим плиток для изображения и текста
            feedListView.TileSize = new Size(222, 60); // Размер плиток
            feedListView.FullRowSelect = true; // Выделение всей строки
            feedListView.HideSelection = false; // Оставить выделение, даже если ListView не в фокусе

            // Подключение ImageList
            feedListView.LargeImageList = new ImageList { ImageSize = new Size(48, 48) }; // Настройка размеров иконок
        }

        private void feedListView_ItemActivate(object sender, EventArgs e)
        {
            if (feedListView.SelectedItems.Count > 0)
            {
                //var selectedItem = feedListView.SelectedItems[0];
                //EventArtistForm eventArtistForm = new EventArtistForm(this);
                //eventArtistForm.Left = Left;
                //eventArtistForm.Top = Top;
                //eventArtistForm.Show();
                //Hide();

                EventPlatformForm eventPlatformForm = new EventPlatformForm(this);
                eventPlatformForm.Left = Left;
                eventPlatformForm.Top = Top;
                eventPlatformForm.Show();
                Hide();
            }
        }
    }
}
