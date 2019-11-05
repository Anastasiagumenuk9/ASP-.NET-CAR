using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MODELS.ViewModels.AccountViewModels
{
    public class LoginViewModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Message { get; set; }
    }
}
