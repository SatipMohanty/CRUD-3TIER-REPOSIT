using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC3TIER.Models.TIER.entity_class
{
    public class dept_cls:Object
    {
        [Key]
        public int did { get; set; } = 0;
        public string dname { get; set; } = "";
        public string dloc { get; set; } = "";
        public int no_of_emp { get; set; } = 0;

    }
}