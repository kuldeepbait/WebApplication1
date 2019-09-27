using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class FinanceModel
    {
        public int id { get; set; }
        [Display(Name = "Emp Name")]
        [Required(ErrorMessage = "Enter Name")]
        [StringLength(10,ErrorMessage ="Name should be less than 10 chars")]
        public string name { get; set; }

        [Display(Name = "Salary")]
        [Required(ErrorMessage = "Required")]
        public decimal Salary { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
        ErrorMessage = "Please Enter Correct Email Address")]
        public string Email { get; set; }

        [Display(Name = "Date Of Joining")]
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        public string DateOfJoining { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Required")]
        public string Gender { get; set; }


        [Display(Name = "City")]
        [Required(ErrorMessage = "Required")]
        public string cityId { get; set; }


        public IEnumerable<SelectList> City { get; set; }

    }
}