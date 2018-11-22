using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeApp
{
    public partial class Employee : System.Web.UI.Page
    {
        public DataTable table;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetEmployeeDetails();

        }

        private void GetEmployeeDetails()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                table = new DataTable("Employee");
                SqlCommand cmd = new SqlCommand("Select * from EmpDetails", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(table);
            }
        }

        protected void EmployeeSubmit(object sender, EventArgs e)
        {
            string empName = txtEmpName.Text;
            string empDesig = txtDesig.Text;
            string connectionString = ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert into EmpDetails(EmployeeName,EmployeeDesig) values(@Name,@Designation)", con);
                // define parameters and their values
                cmd.Parameters.AddWithValue("@Name",empName);
                cmd.Parameters.AddWithValue("@Designation",empDesig);


                // open connection, execute INSERT
                con.Open();
                cmd.ExecuteNonQuery();
                GetEmployeeDetails();
                txtEmpName.Text = string.Empty;
                txtDesig.Text= string.Empty;


            }
        }
    }
}