using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MVC3TIER.Models
{
    public class gconnect
    {
        public static string gcon = null;
        static gconnect()
        {
            gcon = ConfigurationManager.ConnectionStrings["con"].ToString();
        }
    }
}