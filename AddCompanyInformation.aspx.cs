using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



public partial class AddCompanyInformation : System.Web.UI.Page
{
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("/login");
            }
           
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
    
    

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/ManageCompany");
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {


        
        string constr = ConfigurationManager.ConnectionStrings["danaerpConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(constr);

        SqlCommand cmd = new SqlCommand("spInsertCompany", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 200).Value = this.txtCompanyName.Text.ToString();
        cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 450).Value = this.txtAddress.Text.ToString();
        cmd.Parameters.Add("@ContactNo", SqlDbType.NVarChar, 100).Value = this.txtContactNo.Text.ToString();
        cmd.Parameters.Add("@EmailId", SqlDbType.VarChar, 100).Value = this.txtEmail.Text.ToString();
        cmd.Parameters.Add("@WebsiteAdd", SqlDbType.VarChar, 100).Value = this.txtWebsite.Text.ToString();
        cmd.Parameters.Add("@ContactPerson", SqlDbType.VarChar, 100).Value = this.txtContactPerson.Text.ToString();
        cmd.Parameters.Add("@OpBy", SqlDbType.VarChar, 100).Value = Session["Username"].ToString();

        try
        {
            conn.Open();
            int row = cmd.ExecuteNonQuery();
            if (row == 1)
            {
                ShowMessage("Record inserted successfully.", MessageType.Success);
                txtCompanyName.Text = "";
                txtAddress.Text = "";
                txtContactNo.Text = "";
                txtEmail.Text = "";
                txtWebsite.Text = "";
                txtContactPerson.Text = "";
                ScriptManager1.SetFocus(txtCompanyName);
            }

            else
            {
                ShowMessage("Something went wrong!!!", MessageType.Error);
            }
        }
        catch(Exception ex)
        {
            ShowMessage("Something went worng, most likely Duplicate Recroed is Detected/ Inputed value is greater than actual field size/ Inappropriate value.", MessageType.Error);
        }
        finally
        {
            conn.Close();
        }
    }
}