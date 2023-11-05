using MVC3TIER.Models.TIER.DAL;
using MVC3TIER.Models.TIER.entity_class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MVC3TIER.Models.TIER.Reposit
{
    public class reposit_master:ireposit_read,ireposit_write
    {
        public string newdept(string pro_name, dept_cls entity)
        {
            DAL_ ob = new DAL_();
            int x = ob.newdept(pro_name, entity);
            return x.ToString();
        }
        public string editdept(string pro_name, dept_cls entity)
        {
            DAL_ ob = new DAL_();
            int x = ob.updatedept(pro_name, entity);
            return x.ToString();
        }
        public string deletedept(string pro_name, int did)
        {
            DAL_ ob = new DAL_();
            int x = ob.deletedept(pro_name, did);
            return x.ToString();
        }
        public dept_cls search(string pro_name, int did)
        {
            DAL_ ob = new DAL_();
            DataTable x = ob.search(pro_name, did);
            dept_cls ent = null;
            if (x.Rows.Count >= 0)
            {
                ent = new dept_cls
                {
                    did = int.Parse(x.Rows[0]["d_id"].ToString()),
                    dname = x.Rows[0]["dname"].ToString(),
                    dloc = x.Rows[0]["dloc"].ToString(),
                    no_of_emp = int.Parse(x.Rows[0]["no_of_emp"].ToString())
                };
            }
            else
            {
                ent = new dept_cls { did = 0, dname = null, dloc = null, no_of_emp = 0 };
            }
            return ent;
        }
        public List<dept_cls> dispall(string pro_name)
        {
            DAL_ ob = new DAL_();
            DataTable x = ob.display_all(pro_name);
            dept_cls ent = null;
            List<dept_cls> ds = new List<dept_cls>();
            foreach (DataRow rr in x.Rows)
            {
                ent = new dept_cls
                {
                    did = int.Parse(rr["d_id"].ToString()),
                    dname = rr["dname"].ToString(),
                    dloc = rr["dloc"].ToString(),
                    no_of_emp = int.Parse(rr["no_of_emp"].ToString())
                };
                ds.Add(ent);
            }
            return ds;
        }

    }
}