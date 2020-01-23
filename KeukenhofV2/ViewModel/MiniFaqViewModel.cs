using KeukenhofV2.Models;
using System.Collections.Generic;

namespace KeukenhofV2.ViewModel
{
    public class MiniFaqViewModel
    {
        public string Image { get; set; }
        public string ButtonText { get; set; }
        public IEnumerable<FAQ> FAQ { get; set; }
        public string Theme { get; set; }
    }
}
