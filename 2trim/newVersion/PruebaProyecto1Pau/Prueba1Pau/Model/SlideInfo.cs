using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Prueba1Pau.Modl
{
    public class SlideInfo
    {
        public SlideType Type { get; set; }
        public System.Windows.Controls.UserControl UserControl { get; set; }
        public enum SlideType
        {
            Slide1, Slide2, Slide3, Slide4, Slide5, Slide6, Slide7,
            Slide8
        }
    }
}
