using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;




namespace OlxAd.Models
{
    
    
    // For Registration
    public class Registration
    {

        [Required(ErrorMessage = "Please Enter Name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please ReEnter Password")]
        [Display(Name = "ReEnter Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }

    //For Login
    public class Users
    {
        public int UserNo { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }


    }

   
}