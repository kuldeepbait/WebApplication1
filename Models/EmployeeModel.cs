using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DLL;

namespace WebApplication1.Models
{
    public class EmployeeModel
    {
        public EmployeeModel()
        {
            this.listCity = new List<City>();
            this.objstate = new state();
            this.listAttachment = new List<EmployeeAttachment>();
        }

        public int id { get; set; }

        [Display(Name = "Emp Name")]
        [StringLength(15, ErrorMessage = "The Emp Name must contains 7 characters", MinimumLength = 7)]
        [Required(ErrorMessage = "Required")]
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
        public string  cityId { get; set; }

        [Display(Name = "Attachment")]
        [Required(ErrorMessage = "Required")]
        public HttpPostedFileBase File { get; set; }

        public List<City> listCity { get; set; }
        public IEnumerable<SelectList> City { get; set; }
        public state objstate { get; set; }

        public List<EmployeeAttachment> listAttachment { get; set; }
    }

    public class state
    {
        public int Id { get; set; }
        public string city { get; set; }
    }
}