using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddDutyRate : System.Web.UI.Page
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
                string strSql = "Select ' Select Bank Name' as BankName,'-1' as bid union Select bankName as BankName, id as bid from tbl_bankinfo";
                LoadCombo.fillcombo(this.cmbBankName, strSql, "BankName", "bid");

                //load Route information
                string strSq2 = "Select ' Select Route' as Route,'-1' as rid union SELECT CONCAT(PickLocation, ' - ' + DropLocation) AS Route , Id as rid from tbl_Route";
                LoadCombo.fillcombo(this.cmbRoute, strSq2, "Route", "rid");
            }      
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (cmbBankName.SelectedValue == "-1")
        {
            ShowMessage("Please Select Bank Name From Dropdown Menu!", MessageType.Warning);
            return;
        }
        if (cmbVehicleType.SelectedValue == "0")
        {
            ShowMessage("Please Select Vehicle Type From Dropdown Menu!", MessageType.Warning);
            return;
        }
        if (cmbRoute.SelectedValue == "-1")
        {
            ShowMessage("Please Select Route From Dropdown Menu!", MessageType.Warning);
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
        if (txtOddTimeStart.Text.ToString() == "")
        {
            ShowMessage("Please Enter Odd Time Start!", MessageType.Warning);
            return;
        }
        if (txtOddTimeEnd.Text.ToString() == "")
        {
            ShowMessage("Please Enter Odd Time End!", MessageType.Warning);
            return;
        }
        if (txtOddTimeRate.Text.ToString() == "")
        {
            ShowMessage("Please Enter Odd Time Rate!", MessageType.Warning);
            return;
        } 

        SqlConnection conn = DBUtility.GetConnection();
        SqlCommand cmd = new SqlCommand("sp_InsertDutyRate", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@BankId", SqlDbType.Int, 4).Value = Convert.ToInt32(this.cmbBankName.SelectedValue);
        cmd.Parameters.Add("@VehicleType", SqlDbType.NVarChar, 150).Value = this.cmbVehicleType.SelectedItem.Text.ToString();
        cmd.Parameters.Add("@RouteId", SqlDbType.Int, 4).Value = Convert.ToInt32(this.cmbRoute.SelectedValue);
        cmd.Parameters.Add("@Rate", SqlDbType.Float, 5).Value = Convert.ToDouble(this.txtRate.Text.ToString());
        cmd.Parameters.Add("@WChargePerMin", SqlDbType.Float, 5).Value = Convert.ToDouble(this.txtWChargePerMin.Text.ToString());
        cmd.Parameters.Add("@GovtHolydayCharge", SqlDbType.Float, 5).Value = Convert.ToDouble(this.txtGHCharge.Text.ToString());
        cmd.Parameters.Add("@OddTimeStart", SqlDbType.Time).Value = this.txtOddTimeStart.Text.ToString();
        cmd.Parameters.Add("@OddTimeEnd", SqlDbType.Time).Value = this.txtOddTimeEnd.Text.ToString();
        cmd.Parameters.Add("@OddTimeRate", SqlDbType.Float, 5).Value = Convert.ToDouble(this.txtOddTimeRate.Text.ToString());
        cmd.Parameters.Add("@OpBy", SqlDbType.VarChar, 50).Value = Session["Username"].ToString();

        try
        {
            conn.Open();
            int row = cmd.ExecuteNonQuery();
            if(row == 1)
            {
                ShowMessage("Record inserted successfully!", MessageType.Success);
                cmbBankName.SelectedValue = "-1";
                cmbVehicleType.SelectedValue = "0";
                cmbRoute.SelectedValue = "-1";
                txtRate.Text = "";
                txtWChargePerMin.Text = "";
                txtGHCharge.Text = "";
                txtOddTimeStart.Text = "";
                txtOddTimeEnd.Text = "";
                txtOddTimeRate.Text = "";
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
        Response.Redirect("ManageDutyRate");
    }
}

