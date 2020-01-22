using KeukenhofV2.Models;
using System.Collections.Generic;

namespace KeukenhofV2.ViewModel
{
    public class ContactViewModel
    {
        public IEnumerable<ContactContent> ContactContent { get; set; }
        public IEnumerable<FeaturedContent> FeaturedContent { get; set; }
        public int FeatureRows { get; set; }
        public int FeatureColumns { get; set; }
        public MiniFaqViewModel MiniFAQ { get; set; }
    }
}
