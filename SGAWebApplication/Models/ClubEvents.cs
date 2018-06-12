using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGAWebApplication.Models
{
    public class ClubEvents
    {

        public ClubEvents()
        {
            this.Attendees = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public string PointKey { get; set; }
        [Required]
        public int PointValue { get; set; }

        public int EventCount { get; set; }
        public int ClubId { get; set; }
        public string Date { get; set; }

        public virtual Clubs Club { get; set; }
        public virtual ICollection<ApplicationUser> Attendees { get; set; }
    }
}