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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.VisualStyles;

namespace Prototype
{
    public partial class ArtistForm : BaseForm
    {
        private DatabaseHelper dbHelper;
        private ImageConverter converter;
        public ArtistForm()
        {
            dbHelper = new DatabaseHelper();
            converter = new ImageConverter();

            InitializeComponent();
            SetupListView();
        }

        private void ArtistForm_Activated(object sender, EventArgs e)
        {
            PopulateListView();
            LoadArtistInfo();
            NotificationInit();
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
            var items = dbHelper.GetAllEvents();

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
                EventArtistForm eventArtistForm = new EventArtistForm(this, (int)feedListView.SelectedItems[0].Tag);
                eventArtistForm.Left = Left;
                eventArtistForm.Top = Top;
                eventArtistForm.Show();
                Hide();
            }
        }

        //
        //
        //
        // Профиль

        private void LoadArtistInfo()
        {
            Artist artist = dbHelper.GetArtistById(CurrentUser.TypeID);

            // Заполнение элементов формы
            nameLabel.Text = artist.FullName;
            cityLabel.Text = artist.Hometown;
            var nowDate = DateTime.Now;
            int age = nowDate.Year - artist.BirthDate.Year;
            if (nowDate < artist.BirthDate.AddYears(age))
            {
                age--;
            }
            ageLabel.Text = "Возраст: " + age.ToString();
            descriptionLabel.Text = artist.Description;

            // Установка аватара, если он есть, или замена на изображение по умолчанию
            if (artist.Image != null && artist.Image.Length > 0)
            {
                avatarPictureBox.Image = (Image)converter.ConvertFrom(artist.Image);
            }
            else
            {
                avatarPictureBox.Image = Properties.Resources.NoImage;
            }

            List<string> existingGenreNames = dbHelper.GetGenresByArtistId(CurrentUser.TypeID).Names;
            if (existingGenreNames.Count > 0)
            {
                string genresString = "Жанры: ";
                for (int i = 0; i < existingGenreNames.Count - 1; i++)
                {
                    genresString += existingGenreNames[i] + "; ";
                }
                genresString += existingGenreNames.Last() + ".";
                genresLabel.Text = genresString;
            }
        }
        private void editProfileButton_Click(object sender, EventArgs e)
        {
            EditProfileArtistForm editProfileArtistForm = new EditProfileArtistForm(this);
            editProfileArtistForm.Left = Left;
            editProfileArtistForm.Top = Top;
            editProfileArtistForm.Show();

            Hide();
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
                var item = new ListItemControl
                {
                    ItemText = notification.Message,
                    ItemLinkText = dbHelper.GetEventById((int)notification.EventID).Name,
                    NotificationID = notification.NotificationID,
                    EventID = (int)notification.EventID
                };

                // Подписываемся на события
                item.ButtonClick += OnNotificationReaded;
                item.LinkClicked += OnEventLinkClicked;

                unreadFlowLayoutPanel.Controls.Add(item);
            }

            readFlowLayoutPanel.Controls.Clear();
            var readNotifications = dbHelper.GetReadedNotifications(); // Метод для загрузки уведомлений
            foreach (var notification in readNotifications)
            {
                var item = new ListItemControl
                {
                    ItemText = notification.Message,
                    ItemLinkText = dbHelper.GetEventById((int)notification.EventID).Name,
                    NotificationID = notification.NotificationID,
                    EventID = (int)notification.EventID
                };

                item.ButtinOff();
                item.LinkClicked += OnEventLinkClicked;

                readFlowLayoutPanel.Controls.Add(item);
            }
        }

        private void OnNotificationReaded(object sender, EventArgs e)
        {
            var item = sender as ListItemControl;
            if (item != null)
            {
                dbHelper.MarkNotificationAsRead(item.NotificationID); // Обновляем статус в базе
            }
            NotificationInit();
        }

        private void OnEventLinkClicked(object sender, EventArgs e)
        {
            var item = sender as ListItemControl;
            if (item != null)
            {
                OpenEventDetails(item.EventID); // Метод для открытия формы с подробностями события
            }
        }

        private void OpenEventDetails(int eventID)
        {
            // Откройте форму с подробностями события
            var eventForm = new EventArtistForm(this, eventID);
            eventForm.Left = Left;
            eventForm.Top = Top;
            eventForm.Show();
            Hide();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            dbHelper.DeleteReadNotifications(CurrentUser.UserID);
            NotificationInit();
        }
    }
}
