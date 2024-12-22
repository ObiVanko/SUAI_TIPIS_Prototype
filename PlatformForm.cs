using Prototype.classes;
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
    public partial class PlatformForm : BaseForm
    {
        private DatabaseHelper dbHelper;
        private ImageConverter converter;
        public PlatformForm()
        {
            dbHelper = new DatabaseHelper();
            converter = new ImageConverter();
            InitializeComponent();
            SetupListView();         
        }

        private void editProfileButton_Click(object sender, EventArgs e)
        {
            EditProfilePlatformForm editProfilePlatformForm = new EditProfilePlatformForm(this);
            editProfilePlatformForm.Left = Left;
            editProfilePlatformForm.Top = Top;
            editProfilePlatformForm.Show();

            Hide();
        }

        private void addEventButton_Click(object sender, EventArgs e)
        {
            EditEventForm editEventForm = new EditEventForm(this);
            editEventForm.Left = Left;
            editEventForm.Top = Top;
            editEventForm.Show();

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
        private void PopulateListView()
        {
            var items = dbHelper.GetEventsByPlatform(dbHelper.GetPlatformByUserId(CurrentUser.UserID).PlatformID);

            feedListView.Items.Clear();

            foreach (var item in items)
            {
                feedListView.LargeImageList.Images.Add(item.Name, (Image)converter.ConvertFrom(item.Image));
            }

            foreach (var item in items)
            {
                var listViewItem = new ListViewItem
                {
                    Text = item.Name, // Основной текст
                    ImageKey = item.Name, // Привязка изображения по ключу
                    Tag = item.EventID
                };
                listViewItem.SubItems.Add(item.Description); // Добавление дополнительного текста
                feedListView.Items.Add(listViewItem);
            }
        }

        private void feedListView_ItemActivate(object sender, EventArgs e)
        {
            if (feedListView.SelectedItems.Count > 0)
            {
                var selectedItem = feedListView.SelectedItems[0];
                EventPlatformForm eventPlatformForm = new EventPlatformForm(this, (int)feedListView.SelectedItems[0].Tag);
                eventPlatformForm.Left = Left;
                eventPlatformForm.Top = Top;
                eventPlatformForm.Show();
                Hide();
            }
        }

        private void PlatformForm_Activated(object sender, EventArgs e)
        {
            PopulateListView();
            LoadPlatformInfo();
            NotificationInit();
        }

        //
        //
        //
        // Профиль

        private void LoadPlatformInfo()
        {
            var platform = dbHelper.GetPlatformById(CurrentUser.TypeID);

            // Заполнение элементов формы
            nameLabel.Text = platform.Name;
            addressLabel.Text = platform.Address;
            descriptionLabel.Text = platform.Description;

            // Установка аватара, если он есть, или замена на изображение по умолчанию
            if (platform.Image != null && platform.Image.Length > 0)
            {
                avatarPictureBox.Image = (Image)converter.ConvertFrom(platform.Image);
            }
            else
            {
                avatarPictureBox.Image = Properties.Resources.NoImage; 
            }
        }

        //
        //
        //
        // Уведомления

        private void NotificationInit()
        {
            unreadFlowLayoutPanel.Controls.Clear();

            var notifications = dbHelper.GetNotifications(); // Метод для загрузки уведомлений
            foreach (var notification in notifications)
            {
                var item = new ListItemControl2
                {
                    ItemText = notification.Message,
                    ItemEventLinkText = dbHelper.GetEventById((int)notification.EventID).Name,
                    ItemArtistLinkText = notification.ArtistID == null ? "" : dbHelper.GetArtistById((int)notification.ArtistID).FullName,
                    NotificationID = notification.NotificationID,
                    EventID = (int)notification.EventID,
                    ArtistID = notification.ArtistID == null ? -1 : (int)notification.ArtistID,
                };

                // Подписываемся на события
                item.ButtonClick += OnNotificationReaded;
                item.EventLinkClicked += OnEventLinkClicked;
                item.ArtistLinkClicked += OnArtistLinkClicked;

                unreadFlowLayoutPanel.Controls.Add(item);
            }

            readFlowLayoutPanel.Controls.Clear();
            var readNotifications = dbHelper.GetReadedNotifications(); // Метод для загрузки уведомлений
            foreach (var notification in readNotifications)
            {
                var item = new ListItemControl2
                {
                    ItemText = notification.Message,
                    ItemEventLinkText = dbHelper.GetEventById((int)notification.EventID).Name,
                    ItemArtistLinkText = notification.ArtistID == null ? "" : dbHelper.GetArtistById((int)notification.ArtistID).FullName,
                    NotificationID = notification.NotificationID,
                    EventID = (int)notification.EventID,
                    ArtistID = notification.ArtistID == null ? -1 : (int)notification.ArtistID,
                };

                item.ButtinOff();
                item.EventLinkClicked += OnEventLinkClicked;
                item.ArtistLinkClicked += OnArtistLinkClicked;

                readFlowLayoutPanel.Controls.Add(item);
            }
        }

        private void OnNotificationReaded(object sender, EventArgs e)
        {
            var item = sender as ListItemControl2;
            if (item != null)
            {
                dbHelper.MarkNotificationAsRead(item.NotificationID); 
            }
            NotificationInit();
        }

        private void OnEventLinkClicked(object sender, EventArgs e)
        {
            var item = sender as ListItemControl2;
            if (item != null)
            {
                var eventForm = new EventPlatformForm(this, item.EventID);
                eventForm.Left = Left;
                eventForm.Top = Top;
                eventForm.Show();
                Hide(); 
            }
        }

        private void OnArtistLinkClicked(object sender, EventArgs e)
        {
            var item = sender as ListItemControl2;
            if (item != null)
            {
                var artistForm = new ArtistProfileForPlatforms(this, item.ArtistID);
                artistForm.Left = Left;
                artistForm.Top = Top;
                artistForm.Show();
                Hide(); 
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            dbHelper.DeleteReadNotifications(CurrentUser.UserID);
            NotificationInit();
        }
    }
}
