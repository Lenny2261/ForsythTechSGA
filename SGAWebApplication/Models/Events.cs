using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGAWebApplication.Models
{
    public class Events
    {

        public Events()
        {
            this.Attendees = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public string RegularKey { get; set; }
        [Required]
        public int RegularValue { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public string VolunteerKey { get; set; }
        [Required]
        public int VolunteerValue { get; set; }

        public int EventCount { get; set; }
        public string Date { get; set; }
        public string Picture { get; set; }

        public virtual ICollection<ApplicationUser> Attendees { get; set; }

    }
}