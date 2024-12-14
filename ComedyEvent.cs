using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    internal class ComedyEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Image Image { get; set; }

        // Переопределите метод ToString, чтобы отображать нужное значение в ListBox
        public override string ToString()
        {
            return Name; 
        }
    }
}
