
using Prueba1Pau.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static Prueba1Pau.Modl.SlideInfo;

namespace Prueba1Pau.Modl
{
    public class SlideManager
    {
        private Dictionary<SlideType, System.Windows.Controls.UserControl> slides;
        public SlideManager()
        {

            slides = new Dictionary<SlideType, System.Windows.Controls.UserControl>();
            InitializeSlides();
        }

        private void InitializeSlides()
        {
            slides.Add(SlideType.Slide1, new Slide1());
            slides.Add(SlideType.Slide2, new Slide2());
            slides.Add(SlideType.Slide3, new Slide3());
            slides.Add(SlideType.Slide4, new Slide4());
            slides.Add(SlideType.Slide5, new Slide5());
            slides.Add(SlideType.Slide6, new Slide6());
            slides.Add(SlideType.Slide7, new Slide7());

        }

        public System.Windows.Controls.UserControl? GetSlide(SlideType slide)
        {
            if (slides.ContainsKey(slide))
            {
                return slides[slide];
            }
            return null;
        }
    }
}
