using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDocument.Core.Models
{
    public class UserRegisterModel
    {
        [Required]
        public string NameAndFamily { get; set; } = string.Empty;

        [Required]
        public string Username { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
