using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMPMVC5.Models
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }
        [Required(ErrorMessage ="Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Latitude")]
        public string Latitude { get; set; }

        [Required(ErrorMessage = "Enter Latitude")]
        public string Longitude { get; set; }

        public string Description { get; set; }
        public List<Location> ShowallLocation { get; set; }

    }
}