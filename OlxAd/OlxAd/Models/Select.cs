using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OlxAd.Models
{
    public class Select
    {
        [Required(ErrorMessage = "Please select ItemType")]

        public string Category { get; set; }
       
    }
}