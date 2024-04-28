using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using Newtonsoft.Json;

namespace CRJquery
{
    public partial class Employee : System.Web.UI.Page
    {
        static SqlConnection con = new SqlConnection("data source=Desktop-231TL\\SQLEXPRESS01;initial catalog=DB25012024;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }
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
    }
}