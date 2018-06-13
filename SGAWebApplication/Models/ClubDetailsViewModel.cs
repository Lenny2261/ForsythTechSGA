using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGAWebApplication.Models
{
    public class ClubDetailsViewModel
    {
        public ICollection<ClubEvents> clubEvents { get; set; }
        public Clubs clubs { get; set; }
        public ApplicationUser advisor { get; set; }
    }
}