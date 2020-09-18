using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorWithIdentity.Shared
{
    public class RegisterParameters
    {
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane!")]
        [MinLength(5, ErrorMessage = "Hasło jest za krótkie, minumum 5 znaków")]
        public string Password { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane!")]
        [Compare(nameof(Password), ErrorMessage = "Hasła nie są identyczne!")]
        [MinLength(5, ErrorMessage = "Hasło jest za krótkie, minumum 5 znaków")]
        public string PasswordConfirm { get; set; }
    }
}
