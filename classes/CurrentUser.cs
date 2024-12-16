using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.classes
{
    public static class CurrentUser
    {
        public static int UserID { get; set; }
        public static int TypeID { get; set; }

        public static void Clear()
        {
            UserID = 0;
            TypeID = 0;
        }
    }
}
