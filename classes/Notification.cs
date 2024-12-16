﻿
namespace Prototype
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
    }
}