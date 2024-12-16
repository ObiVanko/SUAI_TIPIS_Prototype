using System;
using System.Collections.Generic;

namespace Prototype
{
    public class Event
    {
        public int EventID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public int TotalSeats { get; set; }
        public int OccupiedSeats { get; set; }
        public byte[] Image { get; set; } // Для хранения изображения в формате byte[]

        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
        public ICollection<EventParticipant> EventParticipants { get; set; }

        public override string ToString()
        {
            return Name;
        }
    };

}