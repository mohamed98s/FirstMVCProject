﻿using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
	public class SignInViewModel
	{
		[Required(ErrorMessage = "Email Is Required.")]
		[EmailAddress(ErrorMessage = "Invalid Email Format.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password Is Required")]
		public string Password { get; set; }

		public bool RememberMe { get; set; }
	}
}
