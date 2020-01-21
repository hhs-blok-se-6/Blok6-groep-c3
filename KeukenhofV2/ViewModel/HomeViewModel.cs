using KeukenhofV2.Models;
using KeukenhofV2.ViewModel;
using System.Collections.Generic;

namespace KeukenhofV2.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<HomeContent> HomeContent { get; set; }
        public IEnumerable<FeaturedContent> FeaturedContent { get; set; }
        public int FeatureRows { get; set; }
        public int FeatureColumns { get; set; }
        public PraktischViewModel Praktisch { get; set; }
        public IEnumerable<CardContent> CardContent { get; set; }
        public int CardRows { get; set; }
        public int CardColumns { get; set; }
        public IEnumerable<CTAButton> CTAButtons { get; set; }
    }
}