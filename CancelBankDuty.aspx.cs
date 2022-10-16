using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Net;
using System.Net.Mail;

public partial class CancelBankDuty : System.Web.UI.Page
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
                string strSql = "Select ' Select Bank' as BankName,'-1' as bid union Select bankName as BankName, id as bid from tbl_bankinfo";
                LoadCombo.fillcombo(this.cmbBankName, strSql, "BankName", "bid");

                refData();
            }
        }
    }
    void refData()
    {
        try
        {
            SqlConnection conn;
            conn = DBUtility.GetConnection();

            using (SqlCommand cmd = new SqlCommand("SELECT  dbo.tbl_BankDuty.Id, dbo.tbl_BankDuty.ServiceID,dbo.tbl_BankDuty.OrderDate, dbo.tbl_BankDuty.ServiceDate, dbo.tbl_BankDuty.Username, dbo.tbl_BankDuty.ContactNo, dbo.tbl_BankDuty.Email, dbo.tbl_BankDuty.ReportingPlace, dbo.tbl_BankDuty.FlightDetails, dbo.tbl_BankDuty.ReportingTime, dbo.tbl_BankDuty.DropAddress, dbo.tbl_BankDuty.VehicleNo, dbo.tbl_BankDuty.DriverName, dbo.tbl_BankDuty.BankName, dbo.tbl_BankDuty.BankDepartment, dbo.tbl_BankDuty.RM, dbo.tbl_bankInfo.bankName AS Bank, dbo.tbl_RMInfo.rmName, '-' as DName, '-' as RegiNo FROM dbo.tbl_BankDuty INNER JOIN dbo.tbl_bankInfo ON dbo.tbl_BankDuty.BankName = dbo.tbl_bankInfo.id INNER JOIN dbo.tbl_RMInfo ON dbo.tbl_BankDuty.RM = dbo.tbl_RMInfo.Id WHERE  dbo.tbl_BankDuty.Status = 2 AND dbo.tbl_BankDuty.VehicleNo=0 UNION SELECT dbo.tbl_BankDuty.Id, dbo.tbl_BankDuty.ServiceID, dbo.tbl_BankDuty.OrderDate, dbo.tbl_BankDuty.ServiceDate, dbo.tbl_BankDuty.Username, dbo.tbl_BankDuty.ContactNo, dbo.tbl_BankDuty.Email,  dbo.tbl_BankDuty.ReportingPlace, dbo.tbl_BankDuty.FlightDetails, dbo.tbl_BankDuty.ReportingTime, dbo.tbl_BankDuty.DropAddress, dbo.tbl_BankDuty.VehicleNo, dbo.tbl_BankDuty.DriverName, dbo.tbl_BankDuty.BankName, dbo.tbl_BankDuty.BankDepartment, dbo.tbl_BankDuty.RM, dbo.tbl_bankInfo.bankName AS Bank, dbo.tbl_RMInfo.rmName, dbo.tbl_employeecontactinfo.empname AS DName, dbo.VMS_VehicleInformation.RegiNo FROM dbo.tbl_BankDuty INNER JOIN dbo.tbl_bankInfo ON dbo.tbl_BankDuty.BankName = dbo.tbl_bankInfo.id INNER JOIN dbo.tbl_RMInfo ON dbo.tbl_BankDuty.RM = dbo.tbl_RMInfo.Id INNER JOIN dbo.tbl_employeecontactinfo ON dbo.tbl_BankDuty.DriverName = dbo.tbl_employeecontactinfo.id INNER JOIN dbo.VMS_VehicleInformation ON dbo.tbl_BankDuty.VehicleNo = dbo.VMS_VehicleInformation.Id WHERE(dbo.tbl_BankDuty.Status = 2) ORDER BY dbo.tbl_BankDuty.ServiceDate", conn))
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection conn;
            conn = DBUtility.GetConnection();
            using (SqlCommand cmd = new SqlCommand("SELECT  dbo.tbl_BankDuty.Id, dbo.tbl_BankDuty.ServiceID,dbo.tbl_BankDuty.OrderDate, dbo.tbl_BankDuty.ServiceDate, dbo.tbl_BankDuty.Username, dbo.tbl_BankDuty.ContactNo, dbo.tbl_BankDuty.Email, dbo.tbl_BankDuty.ReportingPlace, dbo.tbl_BankDuty.FlightDetails, dbo.tbl_BankDuty.ReportingTime, dbo.tbl_BankDuty.DropAddress, dbo.tbl_BankDuty.VehicleNo, dbo.tbl_BankDuty.DriverName, dbo.tbl_BankDuty.BankName, dbo.tbl_BankDuty.BankDepartment, dbo.tbl_BankDuty.RM, dbo.tbl_bankInfo.bankName AS Bank, dbo.tbl_RMInfo.rmName FROM dbo.tbl_BankDuty INNER JOIN dbo.tbl_bankInfo ON dbo.tbl_BankDuty.BankName = dbo.tbl_bankInfo.id INNER JOIN dbo.tbl_RMInfo ON dbo.tbl_BankDuty.RM = dbo.tbl_RMInfo.Id WHERE dbo.tbl_BankDuty.bankName = '" + cmbBankName.SelectedValue + "' AND dbo.tbl_BankDuty.ServiceDate Between '" + txtFromDate.Text.ToString() + "'AND'" + txtToDate.Text.ToString() + "' AND dbo.tbl_BankDuty.Status = 2 ORDER BY dbo.tbl_BankDuty.ServiceDate", conn))
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
    protected void txtDate_Changedtext(object sender, EventArgs e)
    {
        //try
        //{
        //    SqlConnection conn;
        //    conn = DBUtility.GetConnection();
        //    using (SqlCommand cmd = new SqlCommand("SELECT  dbo.tbl_BankDuty.Id, dbo.tbl_BankDuty.ServiceID,dbo.tbl_BankDuty.OrderDate, dbo.tbl_BankDuty.ServiceDate, dbo.tbl_BankDuty.Username, dbo.tbl_BankDuty.ContactNo, dbo.tbl_BankDuty.Email, dbo.tbl_BankDuty.ReportingPlace, dbo.tbl_BankDuty.FlightDetails, dbo.tbl_BankDuty.ReportingTime, dbo.tbl_BankDuty.DropAddress, dbo.tbl_BankDuty.VehicleNo, dbo.tbl_BankDuty.DriverName, dbo.tbl_BankDuty.BankName, dbo.tbl_BankDuty.BankDepartment, dbo.tbl_BankDuty.RM, dbo.tbl_bankInfo.bankName AS Bank, dbo.tbl_RMInfo.rmName FROM dbo.tbl_BankDuty INNER JOIN dbo.tbl_bankInfo ON dbo.tbl_BankDuty.BankName = dbo.tbl_bankInfo.id INNER JOIN dbo.tbl_RMInfo ON dbo.tbl_BankDuty.RM = dbo.tbl_RMInfo.Id WHERE dbo.tbl_BankDuty.ServiceDate = '" + txtDate.Text.ToString() + "' AND dbo.tbl_BankDuty.Status = 2 ORDER BY dbo.tbl_BankDuty.ServiceDate", conn))
        //    {
        //        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            DataTable dt = new DataTable();
        //            sda.Fill(dt);
        //            gvCompany.DataSource = dt;
        //            gvCompany.DataBind();
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Response.Write(ex.Message.ToString());
        //}
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {

        //int totalrows = this.gvCompany.Rows.Count;
        //for (int r = 0; r < totalrows; r++)
        //{
        //    GridViewRow thisGridViewRow = gvCompany.Rows[r];
        //    DropDownList cmbVehicleNo = (DropDownList)thisGridViewRow.FindControl("cmbVehicleNo");
        //    DropDownList cmbDriverName = (DropDownList)thisGridViewRow.FindControl("cmbDriverName");

        //    //load drivers information
        //    string strSql2 = "Select ' Select Driver' as EmployeeName,'-1' as EmployeeId union Select CONCAT(tbl_employeecontactinfo.empexistingid, ' - ' + tbl_employeecontactinfo.empname) as EmployeeName, tbl_employeecontactinfo.id as EmployeeId from tbl_employeecontactinfo WHERE tbl_employeecontactinfo.jobstatus='Active' and tbl_employeecontactinfo.desigid=1053";
        //    LoadCombo.fillcombo(cmbDriverName, strSql2, "EmployeeName", "EmployeeId");

        //    //load Vehicle Registration No information
        //    string strSql3 = "select ' Select Vehicle No ' as VehicleNo, '-1' as vid union Select RegiNo as VehicleNo, Id as vid from VMS_VehicleInformation";
        //    LoadCombo.fillcombo(cmbVehicleNo, strSql3, "VehicleNo", "vid");
        //}

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