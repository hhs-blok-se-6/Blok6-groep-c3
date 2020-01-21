using KeukenhofV2.Models;
using System.Collections.Generic;

namespace KeukenhofV2.ViewModel
{
    public class PraktischViewModel
    {
        public string Image { get; set; }
        public string ButtonText { get; set; }
        public IEnumerable<VeelgesteldeVragen> FAQ { get; set; }
        public string Theme { get; set; }
    }
}
