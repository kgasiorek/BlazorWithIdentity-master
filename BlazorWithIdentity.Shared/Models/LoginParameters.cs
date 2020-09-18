using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorWithIdentity.Shared
{
    public class LoginParameters
    {
        [Required (ErrorMessage = "To pole jest wymagane!")]
        public string UserName { get; set; }

        [Required (ErrorMessage = "To pole jest wymagane!")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
