using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;

namespace CRJquery
{
    /// <summary>
    /// Summary description for EmployeeForm
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class EmployeeForm : System.Web.Services.WebService
    {
        static SqlConnection con = new SqlConnection("data source=Desktop-231TL\\SQLEXPRESS01;initial catalog=DB25012024;integrated security=true");
        
        [WebMethod]
        public static void EmployeeInsert(string Name, string Address, string Age)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GETEmpDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@age", Age);
            cmd.ExecuteNonQuery();
            con.Close();
        }


       [WebMethod]
        public string EmployeeShow()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GETEmpShow", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            String Jdata = JsonConvert.SerializeObject(dt);
            return Jdata;
        }

        [WebMethod]
        public void EmployeeDelete(int DelEmp)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("USP_EmpDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Emp_id", DelEmp);
            cmd.ExecuteNonQuery();
            con.Close();           
        }

        [WebMethod]
        public string EmployeeEdit(int EmpEdt)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("USP_EmpEdit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Emp_id", EmpEdt);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            String Jdata = JsonConvert.SerializeObject(dt);
            return Jdata;
        }
    }
}
