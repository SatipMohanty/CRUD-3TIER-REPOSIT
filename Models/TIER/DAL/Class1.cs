using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using MVC3TIER.Models.TIER.entity_class;
namespace MVC3TIER.Models.TIER.DAL
{
    public class DAL_
    {
        SqlConnection con = null;
        SqlDataAdapter adp=null;
        SqlCommand cmd = null;
        SqlDataReader rr = null;
        DataTable dt = new DataTable();
        public DAL_()
        {
            con = new SqlConnection(gconnect.gcon);
        }
        public int newdept(string pro_name,dept_cls entity)
        {
            int status = 0;
            try
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd = con.CreateCommand();
                cmd.CommandText = pro_name;
                cmd.Parameters.AddWithValue("@did",entity.did);
                cmd.Parameters.AddWithValue("@dname",entity.dname);
                cmd.Parameters.AddWithValue("@dloc",entity.dloc);
                cmd.Parameters.AddWithValue("@no_of_emp",entity.no_of_emp);
                cmd.Parameters.AddWithValue("@action", "i");
                cmd.CommandType = CommandType.StoredProcedure;
                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                status = 1;
            }
            catch (SqlException ee)
            {
                status = 0;
                throw ee;
            }
            catch (Exception ee)
            {
                status = 0;
                throw ee;
            }
            finally
            {
                con.Close();
                adp.Dispose();
                cmd.Dispose();
                con.Dispose();
            }
            return status;
        }
        public int updatedept(string pro_name,dept_cls entity)
        {
            int status = 0;
            try
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd=con.CreateCommand();
                cmd.CommandText = pro_name;
                cmd.Parameters.AddWithValue("@did", entity.did);
                cmd.Parameters.AddWithValue("@dloc", entity.dloc);
                cmd.Parameters.AddWithValue("@no_of_emp", entity.no_of_emp);
                cmd.Parameters.AddWithValue("@action", "u");
                cmd.CommandType = CommandType.StoredProcedure;
                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                status = 1;
            }
            catch (SqlException ee)
            {
                status = 0; throw ee;
            }
            catch(Exception ee)
            {
                status = 0; throw ee;
            }
            finally
            {
                con.Close();
                adp.Dispose();
                cmd.Dispose();
                con.Dispose();
            }
            return status;
        }
        public int deletedept(string pro_name,int did)
        {
            int status = 0;
            try
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd=con.CreateCommand();
                cmd.CommandText = pro_name;
                cmd.Parameters.AddWithValue("@did", did);
                cmd.Parameters.AddWithValue("@action", "d");
                cmd.CommandType = CommandType.StoredProcedure;
                adp=new SqlDataAdapter(cmd);
                adp.Fill(dt);
                status= 1;
            }
            catch (SqlException ee)
            {
                status = 0; throw ee;
            }
            catch (Exception ee)
            {
                status = 0; throw ee;
            }
            finally
            {
                con.Close();
                adp.Dispose();
                cmd.Dispose();
                con.Dispose();
            }
            return status;
        }
        public DataTable display_all(string pro_name)
        {
            try
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd = con.CreateCommand();
                cmd.CommandText = pro_name;
                cmd.Parameters.AddWithValue("@action", "disp");
                cmd.CommandType=CommandType.StoredProcedure;
                adp=new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (SqlException ee)
            {
                throw ee;
            }
            catch (Exception ee)
            {
                throw ee;
            }
            finally
            {
                con.Close();
                adp.Dispose();
                cmd.Dispose();
                con.Dispose();
            }
            return dt;
        }
        public DataTable search(string pro_name,int did)
        {
            try
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd= con.CreateCommand();
                cmd.CommandText = pro_name;
                cmd.Parameters.AddWithValue("@did", did);
                cmd.Parameters.AddWithValue("@action", "search");
                cmd.CommandType= CommandType.StoredProcedure;
                adp=new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (SqlException ee)
            {
                throw ee;
            }
            catch (Exception ee)
            {
                throw ee;
            }
            finally
            {
                con.Close();
                adp.Dispose();
                cmd.Dispose();
                con.Dispose();
            }
            return dt;
        }
    }
}