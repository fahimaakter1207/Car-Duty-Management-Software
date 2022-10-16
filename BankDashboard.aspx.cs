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


public partial class BankDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Username"].ToString() != "")
            {
                this.lblUserName.Text = Session["BankName"].ToString();
            }

            if (Session["Username"] == null)
            {
                Response.Redirect("login");
            }
            else
            {
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
            //using (SqlCommand cmd = new SqlCommand("SELECT dbo.tbl_BankDuty.*, dbo.tbl_bankInfo.id, dbo.tbl_bankInfo.bankName, dbo.tbl_RMInfo.rmName, dbo.tbl_bankInfo.serviceReletedEmail, dbo.tbl_RMInfo.email AS RMEmail, dbo.tbl_BankUserInfo.Email AS UserEmail, dbo.tbl_bankInfo.bankName as BName, tbl_employeecontactinfo.empname as DName, VMS_VehicleInformation.RegiNo FROM dbo.tbl_BankDuty INNER JOIN dbo.tbl_bankInfo ON dbo.tbl_BankDuty.BankName = dbo.tbl_bankInfo.id INNER JOIN dbo.tbl_RMInfo ON dbo.tbl_BankDuty.RM = dbo.tbl_RMInfo.Id INNER JOIN dbo.tbl_BankUserInfo ON dbo.tbl_BankDuty.Username = dbo.tbl_BankUserInfo.Name INNER JOIN tbl_employeecontactinfo ON tbl_BankDuty.DriverName = tbl_employeecontactinfo.id INNER JOIN VMS_VehicleInformation ON tbl_BankDuty.VehicleNo = VMS_VehicleInformation.Id Where tbl_bankInfo.id ='" + Convert.ToInt32(Session["BankId"].ToString()) + "'    ORDER BY dbo.tbl_BankDuty.ServiceDate", conn))
            using (SqlCommand cmd = new SqlCommand("SELECT dbo.tbl_BankDuty.*, dbo.tbl_bankInfo.id, dbo.tbl_bankInfo.bankName, dbo.tbl_RMInfo.rmName, dbo.tbl_bankInfo.serviceReletedEmail, dbo.tbl_RMInfo.email AS RMEmail, dbo.tbl_BankUserInfo.Email AS UserEmail, dbo.tbl_bankInfo.bankName as BName FROM dbo.tbl_BankDuty INNER JOIN dbo.tbl_bankInfo ON dbo.tbl_BankDuty.BankName = dbo.tbl_bankInfo.id INNER JOIN dbo.tbl_RMInfo ON dbo.tbl_BankDuty.RM = dbo.tbl_RMInfo.Id INNER JOIN dbo.tbl_BankUserInfo ON dbo.tbl_BankDuty.Username = dbo.tbl_BankUserInfo.Name  Where tbl_bankInfo.id = " + Convert.ToInt32(Session["BankId"].ToString()) + " ORDER BY dbo.tbl_BankDuty.ServiceDate", conn))
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
            using (SqlCommand cmd = new SqlCommand("SELECT dbo.tbl_BankDuty.*, dbo.tbl_bankInfo.bankName, dbo.tbl_RMInfo.rmName, dbo.tbl_bankInfo.serviceReletedEmail, dbo.tbl_RMInfo.email AS RMEmail, dbo.tbl_BankUserInfo.Email AS UserEmail, dbo.tbl_bankInfo.bankName as BName, tbl_employeecontactinfo.empname as DName, VMS_VehicleInformation.RegiNo FROM dbo.tbl_BankDuty INNER JOIN dbo.tbl_bankInfo ON dbo.tbl_BankDuty.BankName = dbo.tbl_bankInfo.id INNER JOIN dbo.tbl_RMInfo ON dbo.tbl_BankDuty.RM = dbo.tbl_RMInfo.Id INNER JOIN dbo.tbl_BankUserInfo ON dbo.tbl_BankDuty.Username = dbo.tbl_BankUserInfo.Name INNER JOIN tbl_employeecontactinfo ON tbl_BankDuty.DriverName = tbl_employeecontactinfo.id INNER JOIN VMS_VehicleInformation ON tbl_BankDuty.VehicleNo = VMS_VehicleInformation.Id WHERE dbo.tbl_BankDuty.ServiceDate Between '" + txtFromDate.Text.ToString() + "'AND'" + txtToDate.Text.ToString() + "'  ORDER BY dbo.tbl_BankDuty.ServiceDate", conn))
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
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Status = e.Row.Cells[7].Text.ToString();
            

            foreach (TableCell cell in e.Row.Cells)
            {
                

                if ((Status.ToString() == "0"))
                {
                    //cell.ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[7].BackColor = System.Drawing.Color.Blue;
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[7].Text = "Pending";
                }
                else if ((Status.ToString() == "1"))
                {
                    //cell.ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[7].BackColor = System.Drawing.Color.Green;
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[7].Text = "Complete";
                    //e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
                }
                else if (Status.ToString() == "2")
                {
                    //e.Row.Cells[6].CssClass = "label label-success";
                    e.Row.Cells[7].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[7].Text = "Cancel";
                }
                


            }

        }

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

    //protected void MyButtonClick(object sender, EventArgs e)
    //{
    //    //int totalrows = this.gvCompany.Rows.Count;
    //    //for (int r = 0; r < totalrows; r++)
    //    //{
    //    //int r = 0;
    //    //GridViewRow thisGridViewRow = gvCompany.Rows[r];


    //    Button btn = (Button)sender;
    //    GridViewRow gvr = (GridViewRow)btn.NamingContainer;

    //    Label lblId = (Label)gvr.FindControl("lblId");
    //    Label lblBankName = (Label)gvr.FindControl("lblBankName");
    //    Label lblBankDept = (Label)gvr.FindControl("lblBankDepartment");
    //    Label lblUserEmail = (Label)gvr.FindControl("lblUserEmail");
    //    Label lblRMEmail = (Label)gvr.FindControl("lblRMEmail");
    //    Label lblServiceReleted = (Label)gvr.FindControl("lblServiceReleted");
    //    Label lblServiceDate = (Label)gvr.FindControl("lblServiceDate");
    //    //Label lblVehicleNo = (Label)thisGridViewRow.FindControl("lblVehicleNo");
    //    //Label lblVehicleBrand = (Label)thisGridViewRow.FindControl("lblVehicleBrand");
    //    //Label lblDriverName = (Label)thisGridViewRow.FindControl("lblDriverName");
    //    //Label lblDriverCellNo = (Label)thisGridViewRow.FindControl("lblDriverCellNo");
    //    Label lblUserName = (Label)gvr.FindControl("lblUsername");
    //    Label lblUserContact = (Label)gvr.FindControl("lblContactNo");
    //    Label lblReportingPlace = (Label)gvr.FindControl("lblReportingPlace");
    //    Label lblReportingTime = (Label)gvr.FindControl("lblReportingTime");
    //    Label lblDropAddress = (Label)gvr.FindControl("lblDropAddress");

    //    DropDownList cmbVehicleNo = (DropDownList)gvr.FindControl("cmbVehicleNo");
    //    DropDownList cmbDriverName = (DropDownList)gvr.FindControl("cmbDriverName");

    //    int i;
    //    string strsql;

    //    strsql = "Update tbl_BankDuty Set VehicleNo =" + Convert.ToInt32(cmbVehicleNo.SelectedValue) + ", DriverName=" + Convert.ToInt32(cmbDriverName.SelectedValue) + ", Status = 1  Where Id=" + Convert.ToInt32(lblId.Text.ToString());
    //    i = DBTask.InsertData(strsql);

    //    try
    //    {
    //        if (i == 1)
    //        {

    //            string lblVehicleNo = "";
    //            string lblVehicleBrand = "";
    //            string lblDriverName = "";
    //            string lblDriverCellNo = "";

    //            //Load Duty Related Vehicle & Driver Info
    //            SqlConnection conn;
    //            string strSql;
    //            conn = DBUtility.GetConnection();
    //            strSql = "SELECT dbo.VMS_VehicleInformation.RegiNo, dbo.VMS_VehicleInformation.Brand, dbo.tbl_employeecontactinfo.empname as DriverName, dbo.tbl_employeecontactinfo.mobileno as DriverMobileNo FROM dbo.tbl_BankDuty INNER JOIN dbo.VMS_VehicleInformation ON dbo.tbl_BankDuty.VehicleNo = dbo.VMS_VehicleInformation.Id INNER JOIN dbo.tbl_employeecontactinfo ON dbo.tbl_BankDuty.DriverName = dbo.tbl_employeecontactinfo.id where dbo.tbl_BankDuty.Id =" + Convert.ToInt32(lblId.Text.ToString());

    //            SqlCommand cmd = new SqlCommand(strSql, conn);
    //            SqlDataReader dr;
    //            conn.Open();
    //            dr = cmd.ExecuteReader();
    //            if (dr.Read())
    //            {

    //                lblVehicleNo = dr["RegiNo"].ToString();
    //                lblVehicleBrand = dr["Brand"].ToString();
    //                lblDriverName = dr["DriverName"].ToString();
    //                lblDriverCellNo = dr["DriverMobileNo"].ToString();

    //            }
    //            dr.Close();
    //            //return;

    //            //End


    //            //Send mail to Department Head
    //            MailMessage mail = new MailMessage();
    //            //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
    //            SmtpClient SmtpServer = new SmtpClient("mail.danagrpbd.com");
    //            mail.From = new MailAddress("trivia@danagrpbd.com");
    //            mail.To.Add(lblUserEmail.Text.ToString());
    //            //mail.To.Add("rezwanul@danagrpbd.com");
    //            mail.CC.Add(lblServiceReleted.Text.ToString());
    //            mail.CC.Add(lblRMEmail.Text.ToString());

    //            //mail.CC.Add("fahima@danagrpbd.com");
    //            //mail.CC.Add("kamrul@danagrpbd.com");
    //            //mail.CC.Add("mostafijur@danagrpbd.com");

    //            mail.Subject = "Airport Pick & Drop Service";
    //            mail.Body += "<html>";
    //            mail.Body += "<body>";
    //            mail.Body += "<table>";
    //            mail.Body += "<tr>";
    //            mail.Body += "<td>Dear Sir, </td><td> </br> </td>";
    //            mail.Body += "</tr>";

    //            mail.Body += "<tr>";
    //            mail.Body += "<td>Please have the vehicle and chauffeur details from Trivia Aviation Ltd under " + lblBankDept.Text.ToString() + " Member Program of  " + lblBankName.Text.ToString() + ": <br><br><b style='color:#00B050;'><u>Service Date: " + Convert.ToDateTime(lblServiceDate.Text.ToString()).ToString("dd MMM yyyy") + "</u></b><br> <b>Vehicle Regi. No:</b> " + lblVehicleNo.ToString() + " (" + lblVehicleBrand.ToString() + ")<br> <b>Chauffeur Name :</b>" + lblDriverName.ToString() + "<br><b>Cell Phone No:</b>" + lblDriverCellNo.ToString() + "<br><br><b style='color:#00B050;'><u>Service Details:</u></b><br><b>User Name:</b>" + lblUserName.Text.ToString() + "<br><b>Email:</b>" + lblUserEmail.Text.ToString() + "<br><b>Reporting Place :</b>" + lblReportingPlace.Text.ToString() + "<br><b>Reporting Time :</b>" + lblReportingTime.Text.ToString() + " <br><b>Drop Address :</b>" + lblDropAddress.Text.ToString() + " <br><br> For further assistance, feel free to contact with me. <br><br>Best Regards, <br><b>Md. Mahabub Hossain</b> <br><b>Trivia Aviation Ltd |Sr. Executive Operation</b> <br>Office: + 88 02 883 7694 - 6 | Mobile: + 88 0192 991 8222 <br>House# 59, Block – D, Road# 13 & 15, Banani, Dhaka – 1213, Bangladesh.</td>";
    //            mail.Body += "</tr>";
    //            mail.Body += "</table>";
    //            mail.Body += "</body>";
    //            mail.Body += "</html>";
    //            mail.IsBodyHtml = true;
    //            //SmtpServer.Port = 587; //gmail
    //            SmtpServer.Port = 25;
    //            SmtpServer.Credentials = new System.Net.NetworkCredential("trivia@danagrpbd.com", "TA9090#@");
    //            //SmtpServer.EnableSsl = true; //original for gmail
    //            SmtpServer.EnableSsl = false;
    //            SmtpServer.Send(mail);
    //            //end send mail


    //            lblMsg.Text = "Selected Duty Disburse Successfully.";
    //            lblMsg.ForeColor = System.Drawing.Color.Green;
    //        }

    //        else
    //        {
    //            lblMsg.Text = "Something went wrong! Please try agian.";
    //            lblMsg.ForeColor = System.Drawing.Color.Red;

    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        lblMsg.Text = ex.Message.ToString();
    //        lblMsg.ForeColor = System.Drawing.Color.Red;
    //    }
    //    finally
    //    {

    //    }
    //    refData();
    //}

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