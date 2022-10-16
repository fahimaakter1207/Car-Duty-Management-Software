using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddBankInfo_Admin : System.Web.UI.Page
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
        if (txtBankName.Text.ToString() == "")
        {
            ShowMessage("Please Enter Bank Name!", MessageType.Warning);
            return;
        }
        if (txtShortBankName.Text.ToString() == "")
        {
            ShowMessage("Please Enter Bank Short Name!", MessageType.Warning);
            return;
        }
        if (cmbBankDept.SelectedItem.Text.ToString() == "")
        {
            ShowMessage("Please Select Bank Department Name!", MessageType.Warning);
            return;
        }
        if (txtBranch.Text.ToString() == "")
        {
            ShowMessage("Please Enter Branch Name!", MessageType.Warning);
            return;
        }
        if (txtContact.Text.ToString() == "")
        {
            ShowMessage("Please Enter Contact No!", MessageType.Warning);
            return;
        }
        if (txtEmail.Text.ToString() == "")
        {
            ShowMessage("Please Enter Valid Email Address!", MessageType.Warning);
            return;
        }
        if (txtAddress.Text.ToString() == "")
        {
            ShowMessage("Please Enter Address!", MessageType.Warning);
            return;
        }
        if (txtCPName.Text.ToString() == "")
        {
            ShowMessage("Please Enter Contact Person Name!", MessageType.Warning);
            return;
        }
        if (txtCPPhone.Text.ToString() == "")
        {
            ShowMessage("Please Enter Contact Person Phone No!", MessageType.Warning);
            return;
        }


        SqlConnection conn = DBUtility.GetConnection();

        SqlCommand cmd = new SqlCommand("insert into tbl_bankInfo (bankName,shortBankName, bankDept, branchName, contactNo, email, address ,contactPersonName, contactPersonEmail,contactPersonPhone, serviceReletedEmail ) values (@bankName,@shortBankName, @bankDept , @branchName, @contactNo, @email , @address , @contactPersonName, @contactPersonEmail, @contactPersonPhone , @serviceReletedEmail)", conn);
        cmd.Parameters.AddWithValue("bankName", txtBankName.Text);
        cmd.Parameters.AddWithValue("shortBankName", txtShortBankName.Text);
        cmd.Parameters.AddWithValue("bankDept", cmbBankDept.SelectedItem.Text);
        cmd.Parameters.AddWithValue("branchName", txtBranch.Text);
        cmd.Parameters.AddWithValue("contactNo", txtContact.Text);
        cmd.Parameters.AddWithValue("email", txtEmail.Text);
        cmd.Parameters.AddWithValue("address", txtAddress.Text);
        cmd.Parameters.AddWithValue("contactPersonName", txtCPName.Text);
        cmd.Parameters.AddWithValue("contactPersonEmail", txtCPEmail.Text);
        cmd.Parameters.AddWithValue("contactPersonPhone", txtCPPhone.Text);
        cmd.Parameters.AddWithValue("serviceReletedEmail", txtSREmil.Text);

        try
        {
            conn.Open();
            int row = cmd.ExecuteNonQuery();
            if (row == 1)
            {
                string strSql = "INSERT into tbl_users (username, password, cid, opby, accid, remoteaccess, status) VALUES('" + txtShortBankName.Text.ToString() + "','123456', 229,'" + Session["Username"].ToString() + "', 32, 0, 1)";
                int j = DBTask.InsertData(strSql);

                ShowMessage("Record inserted successfully.", MessageType.Success);
                txtBankName.Text = "";
                txtShortBankName.Text = "";
                cmbBankDept.SelectedValue = "0";
                txtBranch.Text = "";
                txtContact.Text = "";
                txtEmail.Text = "";
                txtAddress.Text = "";
                txtCPName.Text = "";
                txtCPEmail.Text = "";
                txtCPPhone.Text = "";
                txtSREmil.Text = "";


                ScriptManager1.SetFocus(txtBankName);
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
        Response.Redirect("ManageBankInfo_Admin");
    }
}