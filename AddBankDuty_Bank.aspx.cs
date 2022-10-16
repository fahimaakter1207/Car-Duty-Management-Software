using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddBankDuty_Bank : System.Web.UI.Page
{
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    SqlConnection conn = DBUtility.GetConnection();
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


                //load drivers information
                //string strSql2 = "Select ' Select Driver' as EmployeeName,'-1' as EmployeeId union Select CONCAT(tbl_employeecontactinfo.empexistingid, ' - ' + tbl_employeecontactinfo.empname) as EmployeeName, tbl_employeecontactinfo.id as EmployeeId from tbl_employeecontactinfo WHERE tbl_employeecontactinfo.jobstatus='Active' and tbl_employeecontactinfo.desigid=1053";
                //LoadCombo.fillcombo(this.cmbDriverName, strSql2, "EmployeeName", "EmployeeId");

                //load Vehicle Registration No information
                //string strSql3 = "select ' Select Vehicle No ' as VehicleNo, '-1' as vid union Select RegiNo as VehicleNo, Id as vid from VMS_VehicleInformation";
                //LoadCombo.fillcombo(this.cmbVehicleNo, strSql3, "VehicleNo", "vid");

            }

        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtOrderDate.Text.ToString() == "")
        {
            ShowMessage("Please Enter Order Date!", MessageType.Warning);
            return;
        }
        if (txtServiceDate.Text.ToString() == "")
        {
            ShowMessage("Please Enter Service Date!", MessageType.Warning);
            return;
        }
        if (cmbUsername.SelectedItem.Text.ToString() == "")
        {
            ShowMessage("Please Select User Name!", MessageType.Warning);
            return;
        }
        if (txtReportingPlace.Text.ToString() == "")
        {
            ShowMessage("Please Enter Reporting Place Name!", MessageType.Warning);
            return;
        }
        if (txtReportingTime.Text.ToString() == "")
        {
            ShowMessage("Please Enter Reporting Time!", MessageType.Warning);
            return;
        }
        if (txtDropAddress.Text.ToString() == "")
        {
            ShowMessage("Please Enter Drop Address!", MessageType.Warning);
            return;
        }

        //if (cmbVehicleNo.SelectedValue == "")
        //{
        //    ShowMessage("Please Select Vehicle NO!", MessageType.Warning);
        //    return;
        //}
        //if (cmbDriverName.SelectedValue == "")
        //{
        //    ShowMessage("Please Select Driver Name!", MessageType.Warning);
        //    return;
        //}

        if (cmbBankName.SelectedValue == "")
        {
            ShowMessage("Please Select Bank Name!", MessageType.Warning);
            return;
        }
        if (cmbBankDept.SelectedValue == "")
        {
            ShowMessage("Please Select Bank Department Name!", MessageType.Warning);
            return;
        }
        if (cmbRM.SelectedValue == "")
        {
            ShowMessage("Please Select RM Name!", MessageType.Warning);
            return;
        }

        if (txtReportingPlace.Text.ToString() == "Airport")
        {
            if (txtFlight.Text.ToString() == "")
            {
                ShowMessage("When Reporting Place is Airport,Then You should fill up Flight Details.", MessageType.Warning);
                return;
            }
        }

        //Make a duty auto id
        string AAAutoId = "";
        SqlConnection conn = DBUtility.GetConnection();

        //find max number and generate auto id
        //"TAL/DBL/052022/1"
        string strSql = "SELECT  COUNT(Id) + 1 AS MaxId FROM tbl_BankDuty WHERE (ServiceID LIKE '%TAL/" + txtBankShortName.Text.ToString() + "/%')";
        SqlCommand cmd1 = new SqlCommand(strSql, conn);
        SqlDataReader dr;
        conn.Open();
        dr = cmd1.ExecuteReader();
        if (dr.Read())
        {
            AAAutoId = "TAL/" + txtBankShortName.Text.ToString() + "/" + DateTime.Today.ToString("MM") + DateTime.Today.ToString("yy") + "/" + dr["MaxId"].ToString();
        }
        conn.Close();


        SqlCommand cmd = new SqlCommand("sp_InsertBankDuty", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@ServiceID", SqlDbType.NVarChar, 50).Value = AAAutoId.ToString();
        cmd.Parameters.Add("@OrderDate", SqlDbType.Date).Value = this.txtOrderDate.Text.ToString();
        cmd.Parameters.Add("@ServiceDate", SqlDbType.Date).Value = this.txtServiceDate.Text.ToString();
        cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 100).Value = this.cmbUsername.SelectedItem.Text.ToString();
        cmd.Parameters.Add("@ContactNo", SqlDbType.NVarChar, 50).Value = this.txtContactNo.Text.ToString();
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = this.txtEmail.Text.ToString();
        cmd.Parameters.Add("@ReportingPlace", SqlDbType.NVarChar, 255).Value = this.txtReportingPlace.Text.ToString();
        cmd.Parameters.Add("@FlightDetails", SqlDbType.NVarChar, 500).Value = this.txtFlight.Text.ToString();
        cmd.Parameters.Add("@ReportingTime", SqlDbType.Time).Value = this.txtReportingTime.Text.ToString();
        cmd.Parameters.Add("@DropAddress", SqlDbType.NVarChar, 500).Value = this.txtDropAddress.Text.ToString();
        //cmd.Parameters.Add("@VehicleNo", SqlDbType.NVarChar, 100).Value = Convert.ToInt32(this.cmbVehicleNo.SelectedValue);
        //cmd.Parameters.Add("@DriverName", SqlDbType.NVarChar, 100).Value = Convert.ToInt32(this.cmbDriverName.SelectedValue);
        cmd.Parameters.Add("@BankName", SqlDbType.NVarChar, 100).Value = Convert.ToInt32(this.cmbBankName.SelectedValue);
        cmd.Parameters.Add("@BankDepartment", SqlDbType.NVarChar, 100).Value = this.cmbBankDept.SelectedItem.Text.ToString();
        cmd.Parameters.Add("@RM", SqlDbType.NVarChar, 100).Value = Convert.ToInt32(this.cmbRM.SelectedValue);

        try
        {
            conn.Open();

            int row = cmd.ExecuteNonQuery();
            if (row == 1)
            {
                ShowMessage("Record inserted successfully.", MessageType.Success);

                txtOrderDate.Text = "";
                txtServiceDate.Text = "";
                cmbUsername.SelectedItem.Text = " Select Service User Name";
                txtContactNo.Text = "";
                txtEmail.Text = "";
                txtReportingPlace.Text = "";
                txtFlight.Text = "";
                txtReportingTime.Text = "";
                txtDropAddress.Text = "";
                //cmbVehicleNo.SelectedValue = "-1";
                //cmbDriverName.SelectedValue = "-1";
                cmbBankName.SelectedValue = "-1";
                cmbBankDept.SelectedValue = "-1";
                cmbRM.SelectedValue = "-1";


                ScriptManager1.SetFocus(txtOrderDate);
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
    protected void btnSaveUser_Click(object sender, EventArgs e)
    {
        if (txtName.Text.ToString() == "")
        {
            return;
        }

        if (txtContact.Text.ToString() == "")
        {
            return;
        }

        SqlCommand cmd = new SqlCommand("sp_InsertBankUserInfo", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 255).Value = this.txtName.Text.ToString();
        cmd.Parameters.Add("@ContactNo", SqlDbType.NVarChar, 255).Value = this.txtContact.Text.ToString();
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 255).Value = this.txtUserEmail.Text.ToString();


        try
        {
            conn.Open();
            int row = cmd.ExecuteNonQuery();
            if (row == 1)
            {
                ShowMessage("Record inserted successfully.", MessageType.Success);
                //load new service user name information
                string strSql = "Select ' Select Service User Name' as Name union Select 'New Service User Name' as Name union Select Name from tbl_BankUserInfo";
                LoadCombo.fillcombo(this.cmbUsername, strSql, "Name", "Name");

                txtName.Text = "";
                txtContact.Text = "";
                txtUserEmail.Text = "";

                ScriptManager1.SetFocus(txtName);
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

    protected void cmbUsername_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbUsername.Text.ToString() == "New Service User Name")
        {
            newUser.Visible = true;
        }
        else
        {
            newUser.Visible = false;

        }
        refData();
    }

    protected void txtReportingPlace_SelectedTextChanged(object sender, EventArgs e)
    {
        if (txtReportingPlace.Text.ToString() == "Airport")
        {
            divFlightDetails.Visible = true;

            if (txtFlight.Text.ToString() == "")
            {
                ShowMessage("When Reporting Place is Airport, you should fill up Flight Details.", MessageType.Warning);
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

        //Load Bank Short Name
        SqlConnection conn;
        string strSql;
        conn = DBUtility.GetConnection();
        try
        {
            strSql = "SELECT * FROM tbl_Bankinfo  where  Id =" + Convert.ToInt32(cmbBankName.SelectedValue);

            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtBankShortName.Text = dr["shortBankName"].ToString();
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
        //End
    }

    void refData()
    {
        SqlConnection conn;
        string strSql;
        conn = DBUtility.GetConnection();
        try
        {
            // strSql = "Select ContactNo, Email from tbl_BankUserInfo where Id = " + cmbUsername.SelectedValue;

            strSql = "Select ContactNo, Email from tbl_BankUserInfo where Name = '" + cmbUsername.SelectedItem.Text.ToString() + "'";

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
        Response.Redirect("ManageVehicleService");
    }
}