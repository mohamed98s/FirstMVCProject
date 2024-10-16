﻿using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage ="First Name Is Required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Is Required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Email Is Required.")]
        [EmailAddress(ErrorMessage ="Invalid Email Format.")]
        public string Email { get; set; }

        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).{8,}", ErrorMessage ="Passwrod Must Be At Least 8 Digits.")]
        [Required(ErrorMessage ="Password Is Required")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Confirm Password Is Required.")]
        [Compare(nameof(Password), ErrorMessage ="Confirm Password Does Not Match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="IsActive Is Required.")]
        public bool IsActive { get; set; }
    }
}
