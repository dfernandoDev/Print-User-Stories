using Microsoft.Office.Interop.PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintUserStories
{
    public static class PowerPointUtilities
    {


        public static Presentation CreateNewPptFromTemplate(string path)
        {
            Presentation ppt = Globals.ThisAddIn.Application.Presentations.Open(path, Microsoft.Office.Core.MsoTriState.msoTrue, Microsoft.Office.Core.MsoTriState.msoTrue, Microsoft.Office.Core.MsoTriState.msoTrue);

            return ppt;
        }

        public static void DeleteAllSlides(Presentation ppt)
        {
            foreach (Slide slide in ppt.Slides)
            {
                slide.Delete();
            }
        }

        public static Slide InsertNewSlide(Presentation ppt)
        {
            CustomLayout pptLayout;
            pptLayout = ppt.Designs[1].SlideMaster.CustomLayouts[1];
            Slide slide = ppt.Slides.AddSlide(ppt.Slides.Count + 1, pptLayout);

            return slide;
        }

    }
}
