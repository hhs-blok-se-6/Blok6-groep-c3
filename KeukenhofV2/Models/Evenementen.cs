using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeukenhofV2.Models
{
    public class Evenementen
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string description { get; set; }
        public string type { get; set; }
    }
}
