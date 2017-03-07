using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMPMVC5.Models
{
    public class FooBarModel
    {
        public IEnumerable<SelectListItem> Locations { get; set; }
    }
}