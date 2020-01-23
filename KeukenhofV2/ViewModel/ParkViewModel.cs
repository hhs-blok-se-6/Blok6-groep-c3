using KeukenhofV2.Models;
using System.Collections.Generic;

namespace KeukenhofV2.ViewModel
{
    public class ParkViewModel
    {
        public IEnumerable<ParkContent> ParkContent { get; set; }
        public IEnumerable<CardContent> Bezigheden { get; set; }
        public int BezighedenRows { get; set; }
        public int BezighedenColumns { get; set; }
        public IEnumerable<CTAButton> Plattegrond { get; set; }
        public IEnumerable<CardContent> Evenementen { get; set; }
        public int EvenementenRows { get; set; }
        public int EvenementenColumns { get; set; }
        public IEnumerable<CTAButton> Tulpomania { get; set; }
        public IEnumerable<CardContent> Bloemenshows { get; set; }
        public int BloemenshowsRows { get; set; }
        public int BloemenshowsColumns { get; set; }
    }
}
