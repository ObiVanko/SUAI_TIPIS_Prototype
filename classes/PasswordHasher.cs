using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    internal class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // Преобразуем пароль в массив байтов и хешируем
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashBytes); // Возвращаем хеш как строку
            }
        }

        // Проверка совпадения хешированного пароля
        public static bool VerifyPassword(string storedHash, string password)
        {
            var hashedPassword = HashPassword(password); // Хешируем введённый пароль
            return storedHash == hashedPassword; // Сравниваем хеши
        }
    }
}
