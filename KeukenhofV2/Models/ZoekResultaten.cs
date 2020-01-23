using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KeukenhofV2.Models
{

    [Table("SearchView")]
    public class ZoekResultaten
    {
        [Key]
        public string Sid { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public string Location { get; set; }


    }

   
}
