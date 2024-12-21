using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prototype.classes;
using System.IO;
using System.Drawing;

namespace Prototype
{
    internal class DatabaseHelper
    {
        private readonly string _connectionString;
        public DatabaseHelper()
        {
            _connectionString = "Server = localhost; Database = PrototypeDataBase_; Trusted_Connection=True;";

        }

        public void TestConnection()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection successful!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Connection failed: {ex.Message}");
                }
            }
        }

        public List<string> GetGenres()
        {
            List<string> genres = new List<string>();
            string query = "SELECT Name FROM Genres";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            genres.Add(reader.GetString(0));
                        }
                        reader.Close();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching genres: {ex.Message}");
                }
            }

            return genres;
        }

        public int GetGenreIdByName(string genreName)
        {
            string query = "SELECT GenreID FROM Genres WHERE Name = @genreName";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@genreName", genreName);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public (List<int> IDs, List<string> Names) GetGenresByEventId(int eventId)
        {
            List<int> genreIds = new List<int>();
            List<string> genreNames = new List<string>();
            string query = @"
                SELECT g.GenreId, g.Name
                FROM EventGenres eg
                INNER JOIN Genres g ON eg.GenreID = g.GenreID
                WHERE eg.EventID = @EventID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@eventId", eventId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            genreIds.Add(reader.GetInt32(0));
                            genreNames.Add(reader.GetString(1));
                        }
                        reader.Close();
                    }
                }
            }

            return (genreIds, genreNames);
        }

        public (List<int> IDs, List<string> Names) GetGenresByArtistId(int artistId)
        {
            List<int> genreIds = new List<int>();
            List<string> genreNames = new List<string>();
            string query = @"
                SELECT g.GenreId, g.Name
                FROM ArtistGenres ag
                INNER JOIN Genres g ON ag.GenreID = g.GenreID
                WHERE ag.ArtistID = @artistID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@artistId", artistId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            genreIds.Add(reader.GetInt32(0));
                            genreNames.Add(reader.GetString(1));
                        }
                        reader.Close();
                    }
                }
            }

            return (genreIds, genreNames);
        }
        public void AddEventGenre(int eventId, int genreId)
        {
            string query = "INSERT INTO EventGenres (EventID, GenreID) VALUES (@eventId, @genreId)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@eventId", eventId);
                    command.Parameters.AddWithValue("@genreId", genreId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void RemoveEventGenre(int eventId, int genreId)
        {
            string query = "DELETE FROM EventGenres WHERE EventID = @eventId AND GenreID = @genreId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@eventId", eventId);
                    command.Parameters.AddWithValue("@genreId", genreId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddArtistGenre(int artistId, int genreId)
        {
            string query = "INSERT INTO ArtistGenres (ArtistID, GenreID) VALUES (@artistId, @genreId)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@artistId", artistId);
                    command.Parameters.AddWithValue("@genreId", genreId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void RemoveArtistGenre(int artistId, int genreId)
        {
            string query = "DELETE FROM ArtistGenres WHERE ArtistID = @artistId AND GenreID = @genreId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@artistId", artistId);
                    command.Parameters.AddWithValue("@genreId", genreId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // Проверка логина и пароля
        public (int userID, string userType) ValidateUser(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT UserId, Password, UserType FROM [Users] WHERE Username = @login";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@login", login);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userID = reader.GetInt32(0);
                                string storedHash = reader.GetString(1); // Хэш пароля из базы
                                string userType = reader.GetString(2); // Тип пользователя

                                // Проверяем пароль
                                if (PasswordHasher.VerifyPassword(storedHash, password))
                                {
                                    Console.WriteLine($"Всё круто");
                                    return (userID, userType);
                                }
                            }
                            reader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error1: {ex.Message}");
                }
            }
            Console.WriteLine($"Нет такого");
            return (-1, null);

        }

        // Проверка существования логина
        public bool IsLoginTaken(string login)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM [Users] WHERE Username = @login";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@login", login);
                        int count = (int)command.ExecuteScalar();
                        return count > 0; // Возвращаем true, если логин занят
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return false;
                }
            }
        }

        // Проверка существования почты
        public bool IsEmailTaken(string email)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM [Users] WHERE Email = @email";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@email", email);
                        int count = (int)command.ExecuteScalar();
                        return count > 0; // Возвращаем true, если email уже зарегистрирован
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return false;
                }
            }
        }

        // Метод для регистрации пользователя
        public (int user_id, string error) RegisterUser(string login, string password, string user_type, string email)
        {
            if (IsLoginTaken(login))
            {
                Console.WriteLine("Логин уже занят!");
                return (-1, "Логин уже занят!"); // Логин уже занят
            }

            if (IsEmailTaken(email))
            {
                Console.WriteLine("Этот email уже зарегистрирован!");
                return (-1, "Email уже занят!");
            }

            string hashedPassword = PasswordHasher.HashPassword(password);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                connection.Open();
                string query = "INSERT INTO [Users] (Username, Password, UserType, Email) OUTPUT INSERTED.UserID VALUES (@login, @password, @user_type, @email)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", hashedPassword);
                    command.Parameters.AddWithValue("@user_type", user_type);
                    command.Parameters.AddWithValue("@email", email);

                    try
                    {
                        return ((int)command.ExecuteScalar(), null);
                    }
                    catch (Exception)
                    {
                        return (-1, null);
                    }

                }

            }
        }

        // Пример получения данных о пользователе (по ID)
        public User GetUserById(int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    // Запрос для получения основной информации о пользователе
                    string query = "SELECT UserId, Username, Password, UserType, Email FROM [Users] WHERE UserId = @userId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Создаем объект User
                                User user = new User
                                {
                                    Id = reader.GetInt32(0),
                                    Login = reader.GetString(1),
                                    Password = reader.GetString(2),
                                    UserType = reader.GetString(3),
                                    Email = reader.GetString(4)
                                };

                                reader.Close();
                                // В зависимости от типа пользователя загружаем дополнительные данные
                                if (user.UserType == "Artist")
                                {
                                    user.Artist = GetArtistByUserId(userId, connection);
                                }
                                else if (user.UserType == "Platform")
                                {
                                    user.Platform = GetPlatformByUserId(userId, connection);
                                }
                                Console.WriteLine($"Юзер создан");
                                return user;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return null;
        }

        public Event GetEventById(int eventId)
        {
            Event eventDetails = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT EventID, PlatformID, Name, Description, EventDate, TotalSeats, Image " +
                               "FROM Events WHERE EventID = @EventID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EventID", eventId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    eventDetails = new Event
                    {
                        EventID = (int)reader["EventID"],
                        PlatformID = (int)reader["PlatformID"],
                        Name = (string)reader["Name"],
                        Description = (string)reader["Description"],
                        EventDate = (DateTime)reader["EventDate"],
                        TotalSeats = (int)reader["TotalSeats"],
                        // Для изображения, если оно есть
                        Image = reader["Image"] as byte[]
                    };
                }
                reader.Close();
            }

            return eventDetails;
        }

        public bool DeleteEventById(int eventId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL-запрос для удаления мероприятия
                    string query = "DELETE FROM Events WHERE EventID = @eventId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@eventId", eventId);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0; // Успешное удаление, если была затронута хотя бы одна строка
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting event: {ex.Message}");
                    return false;
                }
            }
        }

        public void CreateArtist(int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Artists (UserID, FullName, BirthDate, Hometown, Description) VALUES (@UserID, 'Не заполнено', '2000-01-01', 'Не указано', 'Не заполнено')";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userId);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateArtist(Artist artist)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"
                UPDATE Artists
                SET FullName = @FullName, Hometown = @Hometown, Description = @Description, Image = @Image, BirthDate = @BirthDate 
                WHERE ArtistID = @ArtistID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", artist.FullName);
                    command.Parameters.AddWithValue("@Hometown", artist.Hometown);
                    command.Parameters.AddWithValue("@Description", artist.Description);
                    command.Parameters.AddWithValue("@Image", artist.Image);
                    command.Parameters.AddWithValue("@BirthDate", artist.BirthDate);
                    command.Parameters.AddWithValue("@ArtistID", artist.ArtistID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("Обновление не выполнено. Платформа с указанным ID не найдена.");
                    }
                }
            }
        }

        public void CreatePlatform(int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Platforms (UserID, Name, Address, Description) VALUES (@UserID, 'Не заполнено', 'Не указано', 'Не заполнено')";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userId);

                command.ExecuteNonQuery();
            }
        }

        public int AddEvent(string name, string description, DateTime eventDate, int totalSeats, byte[] image)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Events (PlatformID, Name, Description, EventDate, TotalSeats, Image) " +
                               "OUTPUT INSERTED.EventID " +
                               "VALUES (@PlatformID, @Name, @Description, @EventDate, @TotalSeats, @Image)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PlatformID", CurrentUser.TypeID);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@EventDate", eventDate);
                command.Parameters.AddWithValue("@TotalSeats", totalSeats);
                command.Parameters.AddWithValue("@Image", image);

                return (int)command.ExecuteScalar();
            }
        }
        public void UpdateEvent(int eventId, string name, string description, DateTime eventDate, int totalSeats, byte[] image)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Events SET Name = @Name, Description = @Description, EventDate = @EventDate, " +
                               "TotalSeats = @TotalSeats, Image = @Image WHERE EventID = @EventID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EventID", eventId);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@EventDate", eventDate);
                command.Parameters.AddWithValue("@TotalSeats", totalSeats);
                command.Parameters.AddWithValue("@Image", image == null ? (object)DBNull.Value : image);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Artist GetArtistByUserId(int userId, SqlConnection connection = null)
        {
            if (connection == null)
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
            }
            string query = "SELECT ArtistID, FullName, BirthDate, Hometown, Description, Image FROM [Artists] WHERE UserID = @userId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@userId", userId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Artist
                        {
                            ArtistID = reader.GetInt32(0), // Читаем ArtistID
                            FullName = reader.GetString(1),
                            BirthDate = reader.GetDateTime(2),
                            Hometown = reader.GetString(3),
                            Description = reader.GetString(4),
                            Image = reader["Image"] as byte[]
                        };
                    }
                    reader.Close();
                }
            }

            return null;
        }

        public Platform GetPlatformByUserId(int userId, SqlConnection connection = null)
        {
            if (connection == null)
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
            }
            string query = "SELECT PlatformID, Name, Address, Description, Image FROM [Platforms] WHERE UserID = @userId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@userId", userId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Platform
                        {
                            PlatformID = reader.GetInt32(0), // Читаем PlatformID
                            Name = reader.GetString(1),
                            Address = reader.GetString(2),
                            Description = reader.GetString(3),
                            Image = reader["Image"] as byte[]
                        };
                    }
                    reader.Close();
                }
            }

            return null;
        }

        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();
            string query = "SELECT EventID, PlatformID, Name, Description, EventDate, TotalSeats, Image FROM Events";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                events.Add(new Event
                                {
                                    EventID = reader.GetInt32(0),
                                    PlatformID = reader.GetInt32(1),
                                    Name = reader.GetString(2),
                                    Description = reader.GetString(3),
                                    EventDate = reader.GetDateTime(4),
                                    TotalSeats = reader.GetInt32(5),
                                    Image = reader.IsDBNull(6) ? null : (byte[])reader["Image"]
                                });
                            }
                            reader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving events: {ex.Message}");
                }
            }
            return events;
        }

        public List<Event> GetEventsByPlatform(int platformId)
        {
            List<Event> events = new List<Event>();
            string query = "SELECT EventID, PlatformID, Name, Description, EventDate, TotalSeats, Image " +
                           "FROM Events WHERE PlatformID = @PlatformID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PlatformID", platformId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                events.Add(new Event
                                {
                                    EventID = reader.GetInt32(0),
                                    PlatformID = reader.GetInt32(1),
                                    Name = reader.GetString(2),
                                    Description = reader.GetString(3),
                                    EventDate = reader.GetDateTime(4),
                                    TotalSeats = reader.GetInt32(5),
                                    Image = reader.IsDBNull(6) ? null : (byte[])reader["Image"]
                                });
                            }
                            reader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving events for platform {platformId}: {ex.Message}");
                }
            }
            return events;
        }

        public Platform GetPlatformById(int platformId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT PlatformID, UserId, Name, Address, Description, Image
                FROM Platforms
                WHERE PlatformID = @PlatformID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PlatformID", platformId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Platform
                                {
                                    PlatformID = reader.GetInt32(0),
                                    UserID = reader.GetInt32(1),
                                    Name = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    Address = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    Description = reader.IsDBNull(4) ? null : reader.GetString(4),
                                    Image = reader.IsDBNull(5) ? null : (byte[])reader[5]
                                };

                            }
                            reader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return null;
        }

        public Artist GetArtistById(int artistId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT ArtistID, UserId, FullName, BirthDate, Hometown, Description, Image
                FROM Artists
                WHERE ArtistID = @ArtistID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ArtistID", artistId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Artist
                                {
                                    ArtistID = reader.GetInt32(0),
                                    UserID = reader.GetInt32(1),
                                    FullName = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    BirthDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3),
                                    Hometown = reader.IsDBNull(4) ? null : reader.GetString(4),
                                    Description = reader.IsDBNull(5) ? null : reader.GetString(5),
                                    Image = reader.IsDBNull(6) ? null : (byte[])reader[6]
                                };
                            }
                            reader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return null;
        }
        public void UpdatePlatform(Platform platform)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"
                UPDATE Platforms
                SET Name = @Name, Address = @Address, Description = @Description, Image = @Image
                WHERE PlatformID = @PlatformID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", platform.Name);
                    command.Parameters.AddWithValue("@Address", platform.Address);
                    command.Parameters.AddWithValue("@Description", platform.Description);
                    command.Parameters.AddWithValue("@Image", platform.Image);
                    command.Parameters.AddWithValue("@PlatformID", platform.PlatformID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("Обновление не выполнено. Платформа с указанным ID не найдена.");
                    }
                }
            }
        }

        public List<Notification> GetNotifications()
        {
            var notifications = new List<Notification>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(@"
            SELECT n.NotificationID, n.Message, n.IsRead, n.CreatedAt, n.EventID, e.Name AS EventName, n.ArtistID
            FROM Notifications n
            LEFT JOIN Events e ON n.EventID = e.EventID
            WHERE n.UserID = @userID AND n.IsRead = 0
            ORDER BY n.CreatedAt DESC", connection);
                command.Parameters.AddWithValue("@userID", CurrentUser.UserID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        notifications.Add(new Notification
                        {
                            NotificationID = reader.GetInt32(0),
                            Message = reader.GetString(1),
                            IsRead = reader.GetBoolean(2),
                            CreatedAt = reader.GetDateTime(3),
                            EventID = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4),
                            EventName = reader.IsDBNull(5) ? null : reader.GetString(5),
                            ArtistID = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6),
                        });
                    }
                    reader.Close();
                }
            }
            return notifications;
        }

        public List<Notification> GetReadedNotifications()
        {
            var notifications = new List<Notification>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(@"
            SELECT n.NotificationID, n.Message, n.IsRead, n.CreatedAt, n.EventID, e.Name AS EventName, n.ArtistID
            FROM Notifications n
            LEFT JOIN Events e ON n.EventID = e.EventID
            WHERE n.UserID = @userID AND n.IsRead = 1
            ORDER BY n.CreatedAt DESC", connection);
                command.Parameters.AddWithValue("@userID", CurrentUser.UserID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        notifications.Add(new Notification
                        {
                            NotificationID = reader.GetInt32(0),
                            Message = reader.GetString(1),
                            IsRead = reader.GetBoolean(2),
                            CreatedAt = reader.GetDateTime(3),
                            EventID = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4),
                            EventName = reader.IsDBNull(5) ? null : reader.GetString(5),
                            ArtistID = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6),
                        });
                    }
                    reader.Close();
                }
            }
            return notifications;
        }

        public List<Artist> GetArtists()
        {
            var artists = new List<Artist>();
            string query = "SELECT ArtistID, UserID, FullName, BirthDate, Hometown, Description, Image FROM Artists";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        artists.Add(new Artist
                        {
                            ArtistID = reader.GetInt32(0),
                            UserID = reader.GetInt32(1),
                            FullName = reader.GetString(2),
                            BirthDate = reader.GetDateTime(3),
                            Hometown = reader.IsDBNull(4) ? null : reader.GetString(4),
                            Description = reader.IsDBNull(5) ? null : reader.GetString(5),
                            Image = reader.IsDBNull(6) ? null : (byte[])reader[6]

                        });
                    }
                    reader.Close();
                }
            }

            return artists;
        }

        public void AddNotification(Notification notification)
        {
            string query = @"INSERT INTO Notifications (UserID, Message, EventID, ArtistID)
                      VALUES (@UserID, @Message, @EventID, @ArtistID)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", notification.UserID);
                command.Parameters.AddWithValue("@Message", notification.Message);
                command.Parameters.AddWithValue("@EventID", notification.EventID.HasValue ? (object)notification.EventID.Value : DBNull.Value);
                command.Parameters.AddWithValue("@ArtistID", notification.ArtistID.HasValue ? (object)notification.ArtistID.Value : DBNull.Value); 

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public User GetUserByArtistId(int artistId, SqlConnection connection = null)
        {
            if (connection == null)
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
            }
            string query = @"SELECT u.UserID, u.Username, u.Password, u.UserType, u.Email
                        FROM dbo.Users u
                        INNER JOIN dbo.Artists a ON u.UserID = a.UserID
                        WHERE a.ArtistID = @ArtistID;";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ArtistID", artistId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            Id = reader.GetInt32(0), 
                            Login = reader.GetString(1),
                            Password = reader.GetString(2),
                            UserType = reader.GetString(3),
                            Email = reader.GetString(4)

                        };
                    }
                    reader.Close();
                }
            }

            return null;
        }

        public void MarkNotificationAsRead(int notificationId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // SQL запрос для обновления статуса уведомления
                string query = "UPDATE dbo.Notifications SET IsRead = 1 WHERE NotificationID = @NotificationID";

                using (var command = new SqlCommand(query, connection))
                {
                    // Добавление параметра NotificationID
                    command.Parameters.AddWithValue("@NotificationID", notificationId);

                    // Выполнение запроса
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteReadNotifications(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // SQL запрос для удаления прочитанных уведомлений для конкретного пользователя
                string query = "DELETE FROM dbo.Notifications WHERE UserID = @UserID AND IsRead = 1";

                using (var command = new SqlCommand(query, connection))
                {
                    // Добавление параметра UserID
                    command.Parameters.AddWithValue("@UserID", userId);

                    // Выполнение запроса
                    command.ExecuteNonQuery();
                }
            }
        }


        public int GetSignedUpArtistsCountForEvent(int eventId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // SQL запрос для получения количества записанных артистов на мероприятие
                string query = "SELECT COUNT(*) FROM dbo.ArtistEvents WHERE EventID = @EventID";

                using (var command = new SqlCommand(query, connection))
                {
                    // Добавление параметра EventID
                    command.Parameters.AddWithValue("@EventID", eventId);

                    // Выполнение запроса и возврат количества записанных артистов
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void SignUpArtistForEvent(int artistId, int eventId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Транзакция для обеспечения целостности данных
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Записываем артиста на мероприятие в таблицу ArtistEvents
                        string signUpQuery = "INSERT INTO dbo.ArtistEvents (ArtistID, EventID) VALUES (@ArtistID, @EventID)";
                        using (var signUpCommand = new SqlCommand(signUpQuery, connection, transaction))
                        {
                            signUpCommand.Parameters.AddWithValue("@ArtistID", artistId);
                            signUpCommand.Parameters.AddWithValue("@EventID", eventId);
                            signUpCommand.ExecuteNonQuery();
                        }

                        // Получаем PlatformID для уведомления площадки
                        string getPlatformQuery = "SELECT PlatformID FROM dbo.Events WHERE EventID = @EventID";
                        int platformId;
                        using (var getPlatformCommand = new SqlCommand(getPlatformQuery, connection, transaction))
                        {
                            getPlatformCommand.Parameters.AddWithValue("@EventID", eventId);
                            platformId = (int)getPlatformCommand.ExecuteScalar();
                        }

                        // Создаем уведомление для площадки
                        string notificationQuery = "INSERT INTO dbo.Notifications (UserID, Message, EventID, ArtistID) VALUES (@UserID, @Message, @EventID, @ArtistID)";
                        using (var notificationCommand = new SqlCommand(notificationQuery, connection, transaction))
                        {
                            notificationCommand.Parameters.AddWithValue("@UserID", platformId); // Площадка
                            notificationCommand.Parameters.AddWithValue("@Message", "Новый артист записался на ваше мероприятие.");
                            notificationCommand.Parameters.AddWithValue("@EventID", eventId);
                            notificationCommand.Parameters.AddWithValue("@ArtistID", artistId); // ID артиста, который записался
                            notificationCommand.ExecuteNonQuery();
                        }

                        // Подтверждаем транзакцию
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // В случае ошибки откатываем транзакцию
                        transaction.Rollback();
                        throw new Exception("Ошибка при записи артиста на мероприятие: " + ex.Message);
                    }
                }
            }
        }

        public bool IsArtistSignedUpForEvent(int artistId, int eventId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM dbo.ArtistEvents WHERE ArtistID = @ArtistID AND EventID = @EventID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ArtistID", artistId);
                    command.Parameters.AddWithValue("@EventID", eventId);
                    int count = (int)command.ExecuteScalar();
                    return count > 0; // Возвращаем true, если артист уже записан на мероприятие
                }
            }
        }

        public void CancelArtistSignUp(int artistId, int eventId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Отменяем запись артиста на мероприятие
                string cancelSignUpQuery = "DELETE FROM dbo.ArtistEvents WHERE ArtistID = @ArtistID AND EventID = @EventID";
                using (var command = new SqlCommand(cancelSignUpQuery, connection))
                {
                    command.Parameters.AddWithValue("@ArtistID", artistId);
                    command.Parameters.AddWithValue("@EventID", eventId);
                    command.ExecuteNonQuery();
                }

                string platformQuery = "SELECT PlatformID FROM dbo.Events WHERE EventID = @EventID";
                int platformId = 0;
                using (var command = new SqlCommand(platformQuery, connection))
                {
                    command.Parameters.AddWithValue("@EventID", eventId);
                    var result = command.ExecuteScalar();
                    platformId = result != null ? (int)result : 0;
                }

                if (platformId > 0)
                {
                    string notificationMessage = "Артист отменил запись";
                    string notificationQuery = "INSERT INTO dbo.Notifications (UserID, Message, IsRead, CreatedAt, EventID, ArtistID) " +
                                               "SELECT UserID, @Message, 0, GETDATE(), @EventID, @ArtistID " +
                                               "FROM dbo.Platforms WHERE PlatformID = @PlatformID";

                    using (var command = new SqlCommand(notificationQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Message", notificationMessage);
                        command.Parameters.AddWithValue("@PlatformID", platformId);
                        command.Parameters.AddWithValue("@EventID", eventId);
                        command.Parameters.AddWithValue("@ArtistID", artistId);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public List<int> GetEventsSignedUpByArtist(int artistId)
        {
            List<int> signedUpEventIds = new List<int>();

            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT EventID FROM ArtistEvents WHERE ArtistID = @ArtistID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ArtistID", artistId);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        signedUpEventIds.Add(reader.GetInt32(0)); // Добавление EventID
                    }
                    reader.Close();
                }
            }

            return signedUpEventIds;
        }

    }
}

