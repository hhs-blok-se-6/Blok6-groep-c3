using KeukenhofV2.Models;
using System.Collections.Generic;

namespace KeukenhofV2.ViewModel
{
    public class EvenementenViewModel
    {
        public IEnumerable<CardContent> evenementen { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
    }
}
