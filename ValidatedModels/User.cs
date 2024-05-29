using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Test.CustomAttributes;

namespace Test.Models
{
    [MetadataType(typeof(CustomUser))]

    partial class User
    {
        internal class CustomUser {
            [Display(Name = "Email")]
            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Invalid email address.")]
            public string Email { get; set; }

            [Display(Name = "Birth Date")]
            [Required(ErrorMessage = "Birth date is required.")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [MinimumAge(18, ErrorMessage = "You must be at least 18 years old.")]
            public Nullable<System.DateTime> BirthDate { get; set; }

            [Display(Name = "Contact Number")]
            [Required(ErrorMessage = "Contact Number is required.")]
            [MinLength(10, ErrorMessage = "Enter a valid contact number")]
            [MaxLength(10, ErrorMessage = "Enter a valid contact number")]
            [RegularExpression("^[0-9]+$", ErrorMessage = "Contact Number must be numeric")]

            public string ContactNo { get; set; }

            [Display(Name = "Full Name")]
            [Required(ErrorMessage = "Full name is required.")]
            [StringLength(100, ErrorMessage = "Full name cannot be longer than 100 characters.")]
            [MinLength(2, ErrorMessage = "Full name must be at least 2 characters long.")]
            public string Fullname { get; set; }

            [Display(Name = "Password")]
            [Required(ErrorMessage = "Password is required.")]
            [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
            [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,}$", ErrorMessage = "Password must contain at least one uppercase letter, lowercase letter, special character and digit.")]
            public string Password { get; set; }
            public string Type { get; set; }
            public Nullable<System.DateTime> CreatedOn { get; set; }
            public Nullable<System.DateTime> UpdatedOn { get; set; }
            public Nullable<int> CratedBy { get; set; }
            public Nullable<int> Isdeleted { get; set; }
        }
    }
}