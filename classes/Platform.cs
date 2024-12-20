using System.Collections.Generic;

namespace Prototype
{
    public class Platform
    {
        public int PlatformID { get; set; }

        public int UserID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

    }
}