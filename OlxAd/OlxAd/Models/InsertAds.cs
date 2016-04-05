using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OlxAd.Models
{
    public class InsertAds
    {

    [Required(ErrorMessage = "Please select ItemType")]
    public string ItemType { get; set; }

    public string Image { get; set; }


    [StringLength(10, ErrorMessage = "Enter Atleast 10 characters", MinimumLength = 10)]
    [Required(ErrorMessage = "Please Enter Phone Number")]
    [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Please Enter Address")]
    public string Address { get; set; }


    public int Id { get; set; }
    public int UserNo { get; set; }
    }
   
}