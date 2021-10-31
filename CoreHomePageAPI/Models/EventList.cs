using System;
using System.Collections.Generic;

#nullable disable

namespace CoreHomePageAPI.Models
{
    public partial class EventList
    {
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public string EventDetail { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
