using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddUser : System.Web.UI.Page
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
                Response.Redirect("login");
            }
        }

        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text.ToString() == "")
        {
            return;
        }
        if (txtPassword.Text.ToString() == "")
        {
            return;
        }
        //string constr = ConfigurationManager.ConnectionStrings["danaerpConnectionString"].ConnectionString;
        SqlConnection conn = DBUtility.GetConnection();

        SqlCommand cmd = new SqlCommand("sp_InsertUser", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@username", SqlDbType.NVarChar, 255).Value = this.txtUserName.Text.ToString();
        cmd.Parameters.Add("@password", SqlDbType.NVarChar, 255).Value = this.txtPassword.Text.ToString();
        cmd.Parameters.Add("@cid", SqlDbType.Int, 4).Value = 229;
        cmd.Parameters.Add("@opBy", SqlDbType.NVarChar, 255).Value = Session["Username"].ToString();
        cmd.Parameters.Add("@accid", SqlDbType.Int, 4).Value = Convert.ToInt32(this.cmbAccess.SelectedValue);

        try
        {
            conn.Open();
            int row = cmd.ExecuteNonQuery();
            if (row == 1)
            {
                ShowMessage("Record inserted successfully.", MessageType.Success);
                txtUserName.Text = "";
                txtPassword.Text = "";
                cmbAccess.SelectedValue = "0";

                ScriptManager1.SetFocus(txtUserName);
            }
            else
            {
                ShowMessage("Something went wrong!!!", MessageType.Error);
            }
        }
        catch (Exception ex)
        {
            ShowMessage("Something went worng, most likely Duplicate Recroed is Detected/ Inputed value is greater than actual field size/ Inappropriate value.", MessageType.Error);
        }
        finally
        {
            conn.Close();
        }
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageUsers");
    }

}