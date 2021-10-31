using System;
using System.Collections.Generic;

#nullable disable

namespace CoreHomePageAPI.Models
{
    public partial class NewList
    {
        public int NewId { get; set; }
        public string NewName { get; set; }
        public string NewDetail { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ActiveDate { get; set; }
    }
}
