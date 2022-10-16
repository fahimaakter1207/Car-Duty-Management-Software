using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddBankDutyUser : System.Web.UI.Page
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtUsername.Text.ToString() == "")
        {
            ShowMessage("Please Enter User Name!", MessageType.Warning);
            return;
        }
        if (txtEmail.Text.ToString() == "")
        {
            ShowMessage("Please Enter Email Address!", MessageType.Warning);
            return;
        }
        if (txtContactNo.Text.ToString() == "")
        {
            ShowMessage("Please Enter User Contact No!", MessageType.Warning);
            return;
        }
        if (txtAddress.Text.ToString() == "")
        {
            ShowMessage("Please Enter User Address!", MessageType.Warning);
            return;
        }

        SqlConnection conn = DBUtility.GetConnection();

        SqlCommand cmd = new SqlCommand("sp_BankDutyUser", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = this.txtUsername.Text.ToString();
        cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = this.txtEmail.Text.ToString();
        cmd.Parameters.Add("@contactNo", SqlDbType.NVarChar, 100).Value = this.txtContactNo.Text.ToString();
        cmd.Parameters.Add("@address", SqlDbType.NVarChar, 255).Value = this.txtAddress.Text.ToString();

        try
        {
            conn.Open();
            int row = cmd.ExecuteNonQuery();
            if (row == 1)
            {
                ShowMessage("Record inserted successfully.", MessageType.Success);
                txtUsername.Text = "";
                txtEmail.Text = "";
                txtContactNo.Text = "";
                txtAddress.Text = "";


                ScriptManager1.SetFocus(txtUsername);
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
        Response.Redirect("ManageBankDutyUser");
    }
}