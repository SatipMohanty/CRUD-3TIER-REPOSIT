using MVC3TIER.Models.TIER.entity_class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC3TIER.Models.TIER.Reposit
{
    internal interface ireposit_read
    {
        dept_cls search(string pro_name, int did);
        List<dept_cls> dispall(string pro_name);
    }
    internal interface  ireposit_write
    {
        string newdept(string pro_name, dept_cls entity);
        string editdept(string pro_name, dept_cls entity);
        string deletedept(string pro_name, int did);
    }
}