using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddVehicle : System.Web.UI.Page
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
        if (txtVehicleName.Text.ToString() == "")
        {
            ShowMessage("Please Enter Vehicle Name!", MessageType.Warning);
            return;
        }

        SqlConnection conn = DBUtility.GetConnection();

        SqlCommand cmd = new SqlCommand("sp_InsertVehicle", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 255).Value = this.txtVehicleName.Text.ToString();
        cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar, 255).Value = this.txtRemarks.Text.ToString();
        cmd.Parameters.Add("@opBy", SqlDbType.NVarChar, 255).Value = Session["Username"].ToString();

        try
        {
            conn.Open();
            int row = cmd.ExecuteNonQuery();
            if (row == 1)
            {
                ShowMessage("Record inserted successfully.", MessageType.Success);
                txtVehicleName.Text = "";
                txtRemarks.Text = "";
                
                ScriptManager1.SetFocus(txtVehicleName);
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
        Response.Redirect("ManageVehicle");
    }

}