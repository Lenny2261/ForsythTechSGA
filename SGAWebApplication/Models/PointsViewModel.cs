using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGAWebApplication.Models
{
    public class PointsViewModel
    {
        public ICollection<Events> events { get; set; }
        public ICollection<ClubEvents> clubEvents { get; set; }
    }
}