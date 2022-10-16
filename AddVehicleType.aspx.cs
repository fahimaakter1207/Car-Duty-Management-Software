using System;
using System.Collections.Generic; 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class AddVehicleType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    
    {

    }
    void clear()
    {
        txtName.Text = "";
        txtRemarks.Text = "";
        
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string constr = WebConfigurationManager.ConnectionStrings["danaerpConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(constr);


        SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[tbl_VehicleType]
           ([Name]
           ,[Remarks])
            VALUES ('" + txtName.Text + "' , '" + txtRemarks.Text + "')", conn);

        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataSet ds = new DataSet();
        //sda.Fill(ds);

        conn.Open();
        cmd.ExecuteNonQuery();
        Response.Write(" ");
        clear();
        conn.Close();

    }
}