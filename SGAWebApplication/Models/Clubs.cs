using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGAWebApplication.Models
{
    public class Clubs
    {

        public Clubs()
        {
            this.Memebers = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Budget { get; set; }

        public virtual ICollection<ApplicationUser> Memebers { get; set; }
    }
}