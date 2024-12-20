
using System;

namespace Prototype
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public int UserID { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ArtistID { get; set; }
        public int? EventID { get; set; }
        public string EventName { get; set; }
    }
}