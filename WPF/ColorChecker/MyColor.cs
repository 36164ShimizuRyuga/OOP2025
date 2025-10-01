using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorChecker {
    internal class MyColor {
    public string Name { get;set; }
        public Color Color { get; set; }

        public override string ToString() {
            return Name ?? $"R:{Color.R}G:{Color.G}B:{Color.B}";
        }
    }

}

