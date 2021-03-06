﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGAWebApplication.Models
{
    public class Clubs
    {

        public Clubs()
        {
            this.Members = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public string Picture { get; set; }
        public string AdvisorId { get; set; }

        public virtual ApplicationUser Advisor { get; set; }

        [InverseProperty("Clubs")]
        public virtual ICollection<ApplicationUser> Members { get; set; }
    }
}