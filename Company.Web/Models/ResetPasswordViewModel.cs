using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
	public class ResetPasswordViewModel
	{
		[RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).{8,}", ErrorMessage = "Passwrod Must Be At Least 8 Digits.")]
		[Required(ErrorMessage = "Password Is Required")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Confirm Password Is Required.")]
		[Compare(nameof(Password), ErrorMessage = "Confirm Password Does Not Match")]
		public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string  Token { get; set; }
    }
}
