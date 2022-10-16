using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddRMInfo_Admin : System.Web.UI.Page
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
                //load Bank name information
                string strSql = "Select ' Select Bank' as BankName,'-1' as bid union Select bankName as BankName, id as bid from tbl_bankinfo";
                LoadCombo.fillcombo(this.cmbBankName, strSql, "BankName", "bid");

                //string strSql = "Select ' Select Bank' as BankName,'-1' as bName union Select bankName as BankName, bankName as bName from tbl_bankinfo";
                //LoadCombo.fillcombo(this.cmbBankName, strSql, "BankName", "bName");
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtRMName.Text.ToString() == "")
        {
            ShowMessage("Please Enter RM Name!", MessageType.Warning);
            return;
        }
        if (txtEmail.Text.ToString() == "")
        {
            ShowMessage("Please Enter RM Email Address!", MessageType.Warning);
            return;
        }
        if (txtContactNo.Text.ToString() == "")
        {
            ShowMessage("Please Enter RM Contact No!", MessageType.Warning);
            return;
        }
        if (txtDesignation.Text.ToString() == "")
        {
            ShowMessage("Please Enter RM Designation!", MessageType.Warning);
            return;
        }
        if (cmbBankName.SelectedValue.ToString() == "")
        {
            ShowMessage("Please Select Bank Name!", MessageType.Warning);
            return;
        }

        SqlConnection conn = DBUtility.GetConnection();

        SqlCommand cmd = new SqlCommand("sp_RMInfo", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@rmName", SqlDbType.NVarChar, 100).Value = this.txtRMName.Text.ToString();
        cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = this.txtEmail.Text.ToString();
        cmd.Parameters.Add("@contactNo", SqlDbType.NVarChar, 50).Value = this.txtContactNo.Text.ToString();
        cmd.Parameters.Add("@designation", SqlDbType.NVarChar, 255).Value = this.txtDesignation.Text.ToString();
        cmd.Parameters.Add("@BankId", SqlDbType.Int, 4).Value = Convert.ToInt32(this.cmbBankName.SelectedValue);
        try
        {
            conn.Open();
            int row = cmd.ExecuteNonQuery();
            if (row == 1)
            {
                ShowMessage("Record inserted successfully.", MessageType.Success);
                txtRMName.Text = "";
                txtEmail.Text = "";
                txtContactNo.Text = "";
                txtDesignation.Text = "";
                cmbBankName.SelectedValue = "-1";

                ScriptManager1.SetFocus(txtRMName);
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
        Response.Redirect("ManageRMInfo_Admin");
    }
}