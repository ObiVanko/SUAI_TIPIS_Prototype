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
    public partial class ArtistForm : BaseForm
    {
        public ArtistForm()
        {
            InitializeComponent();
            SetupListView();
            PopulateListView();
        }

        // Мероприятия
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
        private void PopulateListView()
        {
            // Моковые данные
            var items = new List<Event>
            {
                //new Event { Id = 1, Name = "Item 1", Description = "Description 1", Image = Properties.Resources.Image1 },
                //new Event { Id = 2, Name = "Item 2", Description = "Description 2", Image = Properties.Resources.Image2 }
            };

            // Добавление изображений в ImageList
            foreach (var item in items)
            {
                //feedListView.LargeImageList.Images.Add(item.Name, item.Image);
            }

            // Заполнение ListView
            foreach (var item in items)
            {
                var listViewItem = new ListViewItem
                {
                    Text = item.Name, // Основной текст
                    ImageKey = item.Name, // Привязка изображения по ключу
                };
                listViewItem.SubItems.Add(item.Description); // Добавление дополнительного текста
                feedListView.Items.Add(listViewItem);
            }
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

                //EventPlatformForm eventPlatformForm = new EventPlatformForm(this);
                //eventPlatformForm.Left = Left;
                //eventPlatformForm.Top = Top;
                //eventPlatformForm.Show();
                //Hide();
            }
        }


        // Профиль
        private void editProfileButton_Click(object sender, EventArgs e)
        {
            //EditProfileArtistForm editProfileArtistForm = new EditProfileArtistForm(this);
            //editProfileArtistForm.Left = Left;
            //editProfileArtistForm.Top = Top;
            //editProfileArtistForm.Show();

            Hide();
        }
    }
}
