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
            _connectionString = "Server = localhost; Database = PrototypeDataBase; Trusted_Connection=True;";
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

        public Image ByteArrayToImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
                return null;

            using (MemoryStream ms = new MemoryStream(imageData))
            {
                return Image.FromStream(ms);
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
                string query = "SELECT EventID, Name, Description, EventDate, TotalSeats, OccupiedSeats, Image " +
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
                        Name = (string)reader["Name"],
                        Description = (string)reader["Description"],
                        EventDate = (DateTime)reader["EventDate"],
                        TotalSeats = (int)reader["TotalSeats"],
                        OccupiedSeats = (int)reader["OccupiedSeats"],
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
                string query = "INSERT INTO Events (PlatformID, Name, Description, EventDate, TotalSeats, OccupiedSeats, Image) " + 
                               "OUTPUT INSERTED.EventID " +
                               "VALUES (@PlatformID, @Name, @Description, @EventDate, @TotalSeats, 0, @Image)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PlatformID", CurrentUser.TypeID); 
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@EventDate", eventDate);
                command.Parameters.AddWithValue("@TotalSeats", totalSeats);
                command.Parameters.AddWithValue("@Image", image == null ? (object)DBNull.Value : image);

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

        public Artist GetArtistByUserId(int userId, SqlConnection connection)
        {
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

        public Platform GetPlatformByUserId(int userId, SqlConnection connection)
        {
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


    }
}
