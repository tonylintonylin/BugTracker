using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Models
{
    public class Project
    {
        public int ProjectID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public string CreationDate { get; set; }

        [Display(Name = "Created By")]
        public string Creator { get; set; }
        public string CreatorID { get; set; }
        public int UnresolvedTickets { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}