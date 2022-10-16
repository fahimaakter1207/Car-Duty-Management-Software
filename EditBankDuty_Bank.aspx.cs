using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class EditBankDuty_Bank : System.Web.UI.Page
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
                //load new service user name information
                string strSql = "Select ' Select Service User Name' as Name union Select 'New Service User Name' as Name union Select Name from tbl_BankUserInfo";
                LoadCombo.fillcombo(this.cmbUsername, strSql, "Name", "Name");

                //load Bank name information
                string strSql1 = "Select ' Select Bank' as BankName,'-1' as bid union Select bankName as BankName, id as bid from tbl_bankinfo";
                LoadCombo.fillcombo(this.cmbBankName, strSql1, "BankName", "bid");


                ////load drivers information
                //string strSql2 = "Select ' Select Driver' as EmployeeName,'-1' as EmployeeId union Select CONCAT(tbl_employeecontactinfo.empexistingid, ' - ' + tbl_employeecontactinfo.empname) as EmployeeName, tbl_employeecontactinfo.id as EmployeeId from tbl_employeecontactinfo WHERE tbl_employeecontactinfo.jobstatus='Active' and tbl_employeecontactinfo.desigid=1053";
                //LoadCombo.fillcombo(this.cmbDriverName, strSql2, "EmployeeName", "EmployeeId");

                ////load Vehicle Registration No information
                //string strSql3 = "select ' Select Vehicle No ' as VehicleNo, '-1' as vid union Select RegiNo as VehicleNo, Id as vid from VMS_VehicleInformation";
                //LoadCombo.fillcombo(this.cmbVehicleNo, strSql3, "VehicleNo", "vid");

                //load RM
                string strSql4 = "Select ' Select RM' as RMName,'-1' as RMId UNION SELECT rmName as RMName, Id as RMId FROM tbl_RMInfo";
                LoadCombo.fillcombo(this.cmbRM, strSql4, "RMName", "RMId");

                refData();

                if (txtReportingPlace.Text.ToString() == "Airport")
                {
                    divFlightDetails.Visible = true;
                }
            }


        }
    }

    void refData()
    {

        SqlConnection conn;
        string strSql;
        conn = DBUtility.GetConnection();
        try
        {
            strSql = "SELECT * FROM tbl_BankDuty  where  Id =" + Application["Id"].ToString();

            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtServiceId.Text = dr["ServiceID"].ToString();
                txtOrderDate.Text = Convert.ToDateTime(dr["OrderDate"]).ToString("MM/dd/yyyy");
                txtServiceDate.Text = Convert.ToDateTime(dr["ServiceDate"]).ToString("MM/dd/yyyy");
                cmbUsername.SelectedItem.Text = dr["Username"].ToString();
                txtContactNo.Text = dr["ContactNo"].ToString();
                txtEmail.Text = dr["Email"].ToString();
                txtReportingPlace.Text = dr["ReportingPlace"].ToString();
                txtFlight.Text = dr["FlightDetails"].ToString();
                txtReportingTime.Text = dr["ReportingTime"].ToString();
                txtDropAddress.Text = dr["DropAddress"].ToString();
                //cmbVehicleNo.SelectedValue = dr["VehicleNo"].ToString();
                //cmbDriverName.SelectedValue = dr["DriverName"].ToString();
                cmbBankName.SelectedValue = dr["BankName"].ToString();
                cmbBankDept.SelectedItem.Text = dr["BankDepartment"].ToString();
                cmbRM.SelectedValue = dr["RM"].ToString();
            }
            dr.Close();

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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtReportingPlace.Text.ToString() == "Airport")
        {
            if (txtFlight.Text.ToString() == "")
            {

                return;
            }
        }

        if (!IsPostBack)
        {
            Response.Redirect("/login");
        }
        else
        {
            int i;
            string strsql;
            strsql = "Update tbl_BankDuty set OrderDate='" + this.txtOrderDate.Text.ToString() + "', ServiceDate='" + this.txtServiceDate.Text.ToString() + "', Username='" + this.cmbUsername.SelectedItem.Text.ToString() + "',ContactNo='" + this.txtContactNo.Text.ToString() + "',Email ='" + this.txtEmail.Text.ToString() + "',ReportingPlace  ='" + this.txtReportingPlace.Text.ToString() + "',FlightDetails ='" + this.txtFlight.Text.ToString() + "', ReportingTime ='" + this.txtReportingTime.Text.ToString() + "',DropAddress ='" + this.txtDropAddress.Text.ToString() + "',BankName ='" + this.cmbBankName.SelectedValue + "',BankDepartment ='" + this.cmbBankDept.SelectedItem.Text.ToString() + "',RM ='" + this.cmbRM.SelectedValue + "' Where id='" + Application["Id"].ToString() + "'";
            i = DBTask.InsertData(strsql);

            //For log details
            int j;
            string strsql1;
            strsql1 = "Insert into tbl_applog (appname, tblname, optype, cid, opby) Values('IT Assets Management Software','tbl_BankDuty','Update','','" + Session["Username"].ToString() + "')";
            j = DBTask.InsertData(strsql1);

        }
        Response.Redirect("ManageBankDuty");
    }


    protected void cmbUsername_SelectedIndexChanged(object sender, EventArgs e)
    {

        refData1();
    }

    protected void txtReportingPlace_SelectedTextChanged(object sender, EventArgs e)
    {
        if (txtReportingPlace.Text.ToString() == "Airport")
        {
            divFlightDetails.Visible = true;

            if (txtFlight.Text.ToString() == "")
            {

                return;
            }
        }
        else
        {
            divFlightDetails.Visible = false;

        }
    }

    protected void cmbBankName_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strSql1 = "Select ' Select RM' as RMName,'-1' as RMId UNION SELECT rmName as RMName, Id as RMId FROM tbl_RMInfo WHERE bankId=" + Convert.ToInt32(this.cmbBankName.SelectedValue);
        LoadCombo.fillcombo(this.cmbRM, strSql1, "RMName", "RMId");
    }

    void refData1()
    {
        SqlConnection conn;
        string strSql;
        conn = DBUtility.GetConnection();
        try
        {
            // strSql = "Select ContactNo, Email from tbl_BankUserInfo where Id = " + cmbUsername.SelectedValue;

            strSql = "Select ContactNo, Email from tbl_BankUserInfo where where Name = '" + cmbUsername.SelectedItem.Text.ToString() + "'";

            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtContactNo.Text = dr["ContactNo"].ToString();
                txtEmail.Text = dr["Email"].ToString();
            }
            dr.Close();

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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/ManageVehicleService");
    }
}