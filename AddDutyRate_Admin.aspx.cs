using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class AddDutyRate_Admin : System.Web.UI.Page
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
            else
            {
                //load Bank name information
                string strSql = "Select ' Select Bank' as BankName,'-1' as bid union Select bankName as BankName, id as bid from tbl_bankinfo";
                LoadCombo.fillcombo(this.cmbBankName, strSql, "BankName", "bid");
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (cmbBankName.SelectedValue == "")
        {
            ShowMessage("Please Select Bank Name From Dropdown!", MessageType.Warning);
            return;
        }
        if (txtPkLocation.Text.ToString() == "")
        {
            ShowMessage("Please Enter Pickup Address!", MessageType.Warning);
            return;
        }
        if (txtDropLocation.Text.ToString() == "")
        {
            ShowMessage("Please Enter Drop Address!", MessageType.Warning);
            return;
        }

        if (txtRate.Text.ToString() == "")
        {
            ShowMessage("Please Enter Duty Rate!", MessageType.Warning);
            return;
        }
        if (txtWChargePerMin.Text.ToString() == "")
        {
            ShowMessage("Please Enter Wait Charge Per Minute!", MessageType.Warning);
            return;
        }
        if (txtGHCharge.Text.ToString() == "")
        {
            ShowMessage("Please Enter Govt. Holiday Charge!", MessageType.Warning);
            return;
        }
        if (txtWCTime.Text.ToString() == "")
        {
            ShowMessage("Please Enter Waiting Count Time!", MessageType.Warning);
            return;
        }


        SqlConnection conn = DBUtility.GetConnection();
        SqlCommand cmd = new SqlCommand("sp_InsertDutyRate", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@BankId", SqlDbType.Int, 4).Value = Convert.ToInt32(this.cmbBankName.SelectedValue);
        cmd.Parameters.Add("@PickUpLocation", SqlDbType.NVarChar, 255).Value = this.txtPkLocation.Text.ToString();
        cmd.Parameters.Add("@DropLocation", SqlDbType.NVarChar, 255).Value = this.txtDropLocation.Text.ToString();
        cmd.Parameters.Add("@Rate", SqlDbType.Int, 4).Value = Convert.ToInt32(this.txtRate.Text.ToString());
        cmd.Parameters.Add("@WChargePerMin", SqlDbType.Int, 4).Value = Convert.ToInt32(this.txtWChargePerMin.Text.ToString());
        cmd.Parameters.Add("@GovtHolydayCharge", SqlDbType.Int, 4).Value = Convert.ToInt32(this.txtGHCharge.Text.ToString());
        cmd.Parameters.Add("@WatingCountTime", SqlDbType.Int, 4).Value = Convert.ToInt32(this.txtWCTime.Text.ToString());

        try
        {
            conn.Open();
            int row = cmd.ExecuteNonQuery();
            if (row == 1)
            {
                ShowMessage("Record inserted successfully!", MessageType.Success);
                cmbBankName.SelectedValue = "-1";
                txtPkLocation.Text = "";
                txtDropLocation.Text = "";
                txtRate.Text = "";
                txtWChargePerMin.Text = "";
                txtGHCharge.Text = "";
                txtWCTime.Text = "";
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
        Response.Redirect("ManageDutyRate_Admin");
    }
}