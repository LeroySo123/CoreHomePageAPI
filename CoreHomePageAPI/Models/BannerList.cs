using System;
using System.Collections.Generic;

#nullable disable

namespace CoreHomePageAPI.Models
{
    public partial class BannerList
    {
        public int BannerId { get; set; }
        public string BannerTitle { get; set; }
        public string BannerDescription { get; set; }
        public string ImgLink { get; set; }
        public string Url { get; set; }
        public int Ordering { get; set; }
        public bool Active { get; set; }
        public bool ShowTitle { get; set; }
    }
}
