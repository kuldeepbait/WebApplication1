using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class LoginModel
    {
      
        [Display(Name = "User ID")]
        [Required(ErrorMessage = "Required")]
        public string UserId { get; set; }


        [Display(Name = "Passowrd")]
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        public string Passowrd { get; set; }
    }
}
