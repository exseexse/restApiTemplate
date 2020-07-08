using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace restApiTemplateDBEntities
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
