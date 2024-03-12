using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LoginPage.Models
{
    public class user
    {
        [Required(ErrorMessage ="Please Enter your username")]
        [Display(Name ="Enter username:")]
        public string user_name{ get; set; }

        [Required(ErrorMessage = "Please Enter your Password")]
        [Display(Name = "Enter Password:")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        //public string password { get; set; }
        //public string email { get; set; }
        //public DateTime reg_date { get; set; }
        //public bool active { get; set; }


    }
}