using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RegisterModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [Display(Name = "User ID")]
        [Required(ErrorMessage = "Required")]
        public string UserId { get; set; }


        [Display(Name = "Passowrd")]
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        public string Passowrd { get; set; }
    }
}