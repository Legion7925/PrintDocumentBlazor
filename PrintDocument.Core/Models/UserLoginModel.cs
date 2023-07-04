using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDocument.Core.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "نام کاربری یا شماره موبایل نمیتواند خالی باشد")]
        public  string UsernameOrPhoneNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "کلمه عبور نمیتواند خالی باشد")]
        public string Password { get; set; } = string.Empty;
    }
}
