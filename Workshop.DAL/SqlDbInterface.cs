using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Workshop.DAL;
using Workshop.Common;


namespace Workshop.DAL
{
   public class SqlDbInterface
    {
        SqlConnection con;
        public SqlDbInterface()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultconnection"].ToString());
        }

        public void WorkshopReg(wssregistration wssregistration)
        {
            
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "proc_workshop";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.AddWithValue("@name", wssregistration.name);
                cmd.Parameters.AddWithValue("@location", wssregistration.location);
                cmd.Parameters.AddWithValue("@technology", wssregistration.technology);
                cmd.Parameters.AddWithValue("@email", wssregistration.email );
                cmd.Parameters.AddWithValue("@contactNo", wssregistration.contactNo);
                cmd.Parameters.AddWithValue("@course",wssregistration.course);
                cmd.Parameters.AddWithValue("@branch", wssregistration.branch);
                cmd.Parameters.AddWithValue("@semester", wssregistration.semester);
                cmd.Parameters.AddWithValue("@college", wssregistration.college);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                
            }
            catch (Exception EX)
            {
                Console.WriteLine(EX);
            }

                        
        }
       
    }
}
