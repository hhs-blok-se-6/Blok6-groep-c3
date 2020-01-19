using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeukenhofV2.Models
{
    public class EditPagesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
