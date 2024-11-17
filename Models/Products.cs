using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VisitorManagement.Models
{
    public partial class Products
    {
        [Key]
        public int ProductId { get; set; }


        [RegularExpression("^[a-z,A-Z ,.'-]+$", ErrorMessage = "Please enter a valid name")]
        [Required]
        public string Name { get; set; }

        [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Please enter a valid email address")]
        [Required]
        public string Email { get; set; }

        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Please enter a valid Mobile Number")]
        [Required]
        public string Phone { get; set; }

        [Required]
        public DateTime VisitingDate { get; set; }

        public Status Status { get; set; }
    }

    public enum Status
    {
        Submitted,
        Approved,
        Rejected
    }
}
