using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class AddOddTime_Admin : System.Web.UI.Page
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
            else
            {
                // load bankname info
                string strSql = " Select ' Select Bank' as bankName, '-1' as bid union Select bankName as BankName, id as bid from tbl_bankInfo  ";
                LoadCombo.fillcombo(this.cmbBankName, strSql, "BankName", "bid");
            }


        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtOddTime.Text.ToString() == "")
        {
            ShowMessage("Please Enter Odd Time!", MessageType.Warning);
            return;
        }
        if (txtStartTime.Text.ToString() == "")
        {
            ShowMessage("Please Enter Start Time!", MessageType.Warning);
            return;
        }
        if (cmbBankName.SelectedValue == "")
        {
            ShowMessage("Please Select Bank Name!", MessageType.Warning);
            return;
        }


        SqlConnection conn;
        conn = DBUtility.GetConnection();
        SqlCommand cmd = new SqlCommand("sp_InsertOddTime", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@OddTime", SqlDbType.NVarChar, 50).Value = this.txtOddTime.Text.ToString();
        cmd.Parameters.Add("@StartTime", SqlDbType.NVarChar, 50).Value = this.txtStartTime.Text.ToString();
        cmd.Parameters.Add("@BankId", SqlDbType.Int, 4).Value = Convert.ToInt32(this.cmbBankName.SelectedValue);
        cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar, 255).Value = this.txtRemarks.Text.ToString();

        try
        {
            conn.Open();
            int row = cmd.ExecuteNonQuery();
            if (row == 1)
            {
                ShowMessage("Record Inserted Successfully!", MessageType.Success);
                txtOddTime.Text = "";
                txtStartTime.Text = "";
                cmbBankName.SelectedValue = "";
                txtRemarks.Text = "";
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
        Response.Redirect("ManageOddTime_Admin");
    }
}