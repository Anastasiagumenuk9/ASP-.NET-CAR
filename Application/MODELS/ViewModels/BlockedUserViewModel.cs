using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MODELS.ViewModels
{
    public class BlockedUserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
