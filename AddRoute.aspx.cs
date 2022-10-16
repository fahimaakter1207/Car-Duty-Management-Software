using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddRoute : System.Web.UI.Page
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
        string constr = ConfigurationManager.ConnectionStrings["danaerpConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(constr);

        if (txtPickLocation.Text.ToString() == "")
        {
            ShowMessage("Please Enter Pick Location!", MessageType.Warning);
            return;
        }
        if (txtDropLocation.Text.ToString() == "")
        {
            ShowMessage("Please Enter Drop Location!", MessageType.Warning);
            return;
        }
        if (cmbRouteDirection.SelectedValue == "-1")
        {
            ShowMessage("Please Select Route Direction From Dropdown Menu!", MessageType.Warning);
            return;
        }

        SqlCommand cmd = new SqlCommand("sp_InsertRoute", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@PickLocation", SqlDbType.NVarChar, 50).Value = this.txtPickLocation.Text.ToString();
        cmd.Parameters.Add("@DropLocation", SqlDbType.NVarChar, 50).Value = this.txtDropLocation.Text.ToString();
        cmd.Parameters.Add("@RouteDirection", SqlDbType.NVarChar, 100).Value = this.cmbRouteDirection.SelectedItem.Text.ToString();
        cmd.Parameters.Add("@OpBy", SqlDbType.VarChar, 100).Value = Session["Username"].ToString();

        try
        {
            conn.Open();
            int row = cmd.ExecuteNonQuery();
            if (row == 1)
            {
                ShowMessage("Record inserted successfully.", MessageType.Success);
                txtPickLocation.Text = "";
                txtDropLocation.Text = "";
                cmbRouteDirection.SelectedValue = "-1";

                ScriptManager1.SetFocus(txtPickLocation);
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
        Response.Redirect("/ManageRoute");
    }
}