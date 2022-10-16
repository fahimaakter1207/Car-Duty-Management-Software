using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class CancelDisburseBankDuty : System.Web.UI.Page
{
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

                refData();
            }
        }
    }
    void refData()
    {
        SqlConnection conn;

        conn = DBUtility.GetConnection();

        try
        {
            //using (SqlCommand cmd = new SqlCommand("SELECT dbo.tbl_BankDuty.*, dbo.tbl_bankInfo.bankName as BName, dbo.tbl_bankInfo.bankDept, dbo.tbl_RMInfo.rmName, dbo.tbl_bankInfo.serviceReletedEmail, dbo.tbl_RMInfo.email AS RMEmail, dbo.tbl_BankUserInfo.Email AS UserEmail, dbo.VMS_VehicleInformation.RegiNo, dbo.VMS_VehicleInformation.Brand, dbo.tbl_employeecontactinfo.empname, dbo.tbl_employeecontactinfo.mobileno FROM dbo.tbl_BankDuty INNER JOIN dbo.tbl_bankInfo ON dbo.tbl_BankDuty.BankName = dbo.tbl_bankInfo.id INNER JOIN dbo.tbl_RMInfo ON dbo.tbl_BankDuty.RM = dbo.tbl_RMInfo.Id INNER JOIN dbo.tbl_BankUserInfo ON dbo.tbl_BankDuty.Username = dbo.tbl_BankUserInfo.Name INNER JOIN dbo.VMS_VehicleInformation ON dbo.tbl_BankDuty.VehicleNo = dbo.VMS_VehicleInformation.Id INNER JOIN dbo.tbl_employeecontactinfo ON dbo.tbl_BankDuty.DriverName = dbo.tbl_employeecontactinfo.id WHERE (dbo.tbl_BankDuty.Status = 0) AND dbo.tbl_BankDuty.ServiceDate ='" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "' ORDER BY dbo.tbl_BankDuty.ServiceDate", conn))
            using (SqlCommand cmd = new SqlCommand("SELECT dbo.tbl_BankDuty.*, dbo.tbl_bankInfo.bankName, dbo.tbl_RMInfo.rmName, dbo.tbl_bankInfo.serviceReletedEmail, dbo.tbl_RMInfo.email AS RMEmail, dbo.tbl_BankUserInfo.Email AS UserEmail, dbo.tbl_bankInfo.bankName as BName, tbl_employeecontactinfo.empname as DName, VMS_VehicleInformation.RegiNo FROM dbo.tbl_BankDuty INNER JOIN dbo.tbl_bankInfo ON dbo.tbl_BankDuty.BankName = dbo.tbl_bankInfo.id INNER JOIN dbo.tbl_RMInfo ON dbo.tbl_BankDuty.RM = dbo.tbl_RMInfo.Id INNER JOIN dbo.tbl_BankUserInfo ON dbo.tbl_BankDuty.Username = dbo.tbl_BankUserInfo.Name INNER JOIN tbl_employeecontactinfo ON tbl_BankDuty.DriverName = tbl_employeecontactinfo.id INNER JOIN VMS_VehicleInformation ON tbl_BankDuty.VehicleNo = VMS_VehicleInformation.Id WHERE dbo.tbl_BankDuty.Status = 1 ORDER BY dbo.tbl_BankDuty.ServiceDate DESC ", conn))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    gvCompany.DataSource = dt;
                    gvCompany.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
        finally
        {
            conn.Close();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection conn;
            conn = DBUtility.GetConnection();
            using (SqlCommand cmd = new SqlCommand("SELECT dbo.tbl_BankDuty.*, dbo.tbl_bankInfo.bankName, dbo.tbl_RMInfo.rmName, dbo.tbl_bankInfo.serviceReletedEmail, dbo.tbl_RMInfo.email AS RMEmail, dbo.tbl_BankUserInfo.Email AS UserEmail, dbo.tbl_bankInfo.bankName as BName, tbl_employeecontactinfo.empname as DName, VMS_VehicleInformation.RegiNo FROM dbo.tbl_BankDuty INNER JOIN dbo.tbl_bankInfo ON dbo.tbl_BankDuty.BankName = dbo.tbl_bankInfo.id INNER JOIN dbo.tbl_RMInfo ON dbo.tbl_BankDuty.RM = dbo.tbl_RMInfo.Id INNER JOIN dbo.tbl_BankUserInfo ON dbo.tbl_BankDuty.Username = dbo.tbl_BankUserInfo.Name INNER JOIN tbl_employeecontactinfo ON tbl_BankDuty.DriverName = tbl_employeecontactinfo.id INNER JOIN VMS_VehicleInformation ON tbl_BankDuty.VehicleNo = VMS_VehicleInformation.Id WHERE dbo.tbl_BankDuty.bankName = '" + cmbBankName.SelectedValue + "' AND dbo.tbl_BankDuty.ServiceDate Between '" + txtFromDate.Text.ToString() + "'AND'" + txtToDate.Text.ToString() + "' AND dbo.tbl_BankDuty.Status = 1 ORDER BY dbo.tbl_BankDuty.ServiceDate", conn))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    gvCompany.DataSource = dt;
                    gvCompany.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        int totalrows = this.gvCompany.Rows.Count;
        //for (int r = 0; r < totalrows; r++)
        //{
        int r = 0;
        GridViewRow thisGridViewRow = gvCompany.Rows[r];

        Label lblId = (Label)thisGridViewRow.FindControl("lblId");
        DropDownList cmbVehicleNo = (DropDownList)thisGridViewRow.FindControl("cmbVehicleNo");
        DropDownList cmbDriverName = (DropDownList)thisGridViewRow.FindControl("cmbDriverName");

        int i;
        string strsql;

        strsql = "Update tbl_BankDuty Set Status = 2  Where Id=" + Convert.ToInt32(lblId.Text.ToString());
        i = DBTask.InsertData(strsql);

        try
        {
            if (i == 1)
            {
                lblMsg.Text = "Duty Canceled.";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }

            else
            {
                lblMsg.Text = "Something went wrong! Please try agian.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
        finally
        {

        }

        refData();
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void MyButtonClick(object sender, EventArgs e)
    {

    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {


    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
}