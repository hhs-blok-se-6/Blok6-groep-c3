using KeukenhofV2.Models;
using System.Collections.Generic;

namespace KeukenhofV2.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<HomeContent> HomeContent { get; set; }
        public IEnumerable<FeaturedContent> FeaturedContent { get; set; }
        public int FeatureRows { get; set; }
        public int FeatureColumns { get; set; }
        public IEnumerable<CardContent> CardContent { get; set; }
        public int CardRows { get; set; }
        public int CardColumns { get; set; }
        public string Theme { get; set; }
    }
}