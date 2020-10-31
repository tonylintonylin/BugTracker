using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Models
{
    public enum Status
    {
        New,
        [Display(Name = "In Progress")]
        InProgress,
        Completed
    }
    public class Ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }

        [DataType(DataType.Date)]
        public string CreationDate { get; set; }

        // user who created ticket
        [Display(Name = "Created By")]
        public string Creator { get; set; }
        public string CreatorID { get; set; }

        // the developer working on ticket
        [Required]
        [Display(Name = "Assign To Developer")]
        public string DeveloperID { get; set; }
        public IdentityUser Developer { get; set; }

        // many tickets are assigned to project
        [Required]
        [Display(Name = "Assign to Project")]
        public int ProjectID { get; set; }
        public Project Project { get; set; }
    }
}