using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddInvoice : System.Web.UI.Page 
{
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    SqlConnection conn = DBUtility.GetConnection();

    //Make a Invoice auto id
    string AAAutoId = "";
     
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
    void refData()
    {
        SqlConnection conn;
        conn = DBUtility.GetConnection();

        try
        {
            //using (SqlCommand cmd = new SqlCommand("SELECT dbo.tbl_BankDuty.*, dbo.tbl_bankInfo.bankName as BName, dbo.tbl_bankInfo.bankDept, dbo.tbl_RMInfo.rmName, dbo.tbl_bankInfo.serviceReletedEmail, dbo.tbl_RMInfo.email AS RMEmail, dbo.tbl_BankUserInfo.Email AS UserEmail, dbo.VMS_VehicleInformation.RegiNo, dbo.VMS_VehicleInformation.Brand, dbo.tbl_employeecontactinfo.empname, dbo.tbl_employeecontactinfo.mobileno FROM dbo.tbl_BankDuty INNER JOIN dbo.tbl_bankInfo ON dbo.tbl_BankDuty.BankName = dbo.tbl_bankInfo.id INNER JOIN dbo.tbl_RMInfo ON dbo.tbl_BankDuty.RM = dbo.tbl_RMInfo.Id INNER JOIN dbo.tbl_BankUserInfo ON dbo.tbl_BankDuty.Username = dbo.tbl_BankUserInfo.Name INNER JOIN dbo.VMS_VehicleInformation ON dbo.tbl_BankDuty.VehicleNo = dbo.VMS_VehicleInformation.Id INNER JOIN dbo.tbl_employeecontactinfo ON dbo.tbl_BankDuty.DriverName = dbo.tbl_employeecontactinfo.id WHERE (dbo.tbl_BankDuty.Status = 0) AND dbo.tbl_BankDuty.ServiceDate ='" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "' ORDER BY dbo.tbl_BankDuty.ServiceDate", conn))
            //using (SqlCommand cmd = new SqlCommand("SELECT  dbo.tbl_BankDuty.Id, dbo.tbl_bankInfo.bankName, dbo.tbl_BankDuty.ServiceDate, dbo.tbl_BankDuty.Username, dbo.VMS_VehicleInformation.RegiNo, dbo.VMS_VehicleInformation.VType, dbo.tbl_DutyRate.Rate,   dbo.tbl_DutyRate.OddTimeRate, dbo.tbl_DutyRate.WChargePerMin, dbo.tbl_BankDuty.ReportingTime  FROM  dbo.tbl_DutyRate INNER JOIN  dbo.tbl_BankDuty INNER JOIN  dbo.VMS_VehicleInformation ON dbo.tbl_BankDuty.VehicleNo = dbo.VMS_VehicleInformation.Id ON dbo.tbl_DutyRate.VehicleType = dbo.VMS_VehicleInformation.VType INNER JOIN  dbo.tbl_bankInfo ON dbo.tbl_BankDuty.BankName = dbo.tbl_bankInfo.id", conn))
            using (SqlCommand cmd = new SqlCommand("SELECT dbo.tbl_BankDuty.* , dbo.tbl_Route.PickLocation, dbo.tbl_Route.DropLocation, dbo.tbl_bankInfo.shortBankName, dbo.tbl_bankInfo.bankName AS Bank, { fn CONCAT(dbo.tbl_Route.PickLocation, ' - ' + dbo.tbl_Route.DropLocation) } AS Route , dbo.VMS_VehicleInformation.RegiNo, dbo.VMS_VehicleInformation.VType,dbo.tbl_DutyRate.Rate, dbo.tbl_DutyRate.OddTimeRate, dbo.tbl_DutyRate.WChargePerMin, dbo.tbl_BankDuty.ReportingTime FROM dbo.tbl_BankDuty INNER JOIN dbo.tbl_Route ON dbo.tbl_BankDuty.RouteId = dbo.tbl_Route.Id INNER JOIN    dbo.VMS_VehicleInformation ON dbo.tbl_BankDuty.VehicleNo = dbo.VMS_VehicleInformation.Id INNER JOIN   dbo.tbl_DutyRate ON dbo.tbl_BankDuty.BankName = dbo.tbl_DutyRate.BankId AND dbo.tbl_Route.Id = dbo.tbl_DutyRate.RouteId INNER JOIN dbo.tbl_bankInfo ON dbo.tbl_BankDuty.BankName = dbo.tbl_bankInfo.id   ", conn))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    gvInvoice.DataSource = dt;
                    gvInvoice.DataBind();
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
        SqlConnection conn;
        conn = DBUtility.GetConnection();

        if (cmbBankName.SelectedValue == "-1")
        {
            ShowMessage("Please Select Bank Name!", MessageType.Warning);
            return;
        }
        if (txtFromDate.Text.ToString() == "")
        {
            ShowMessage("Please Select From Date!", MessageType.Warning);
            return;
        }
        if (txtToDate.Text.ToString() == "")
        {
            ShowMessage("Please Select To Date!", MessageType.Warning);
            return;
        }

        try
        { 
            conn = DBUtility.GetConnection();
            using (SqlCommand cmd = new SqlCommand("SELECT dbo.tbl_BankDuty.* ,  dbo.tbl_Route.PickLocation, dbo.tbl_Route.DropLocation,dbo.tbl_bankInfo.shortBankName, dbo.tbl_bankInfo.shortBankName,dbo.tbl_bankInfo.bankName AS Bank, { fn CONCAT(dbo.tbl_Route.PickLocation, ' - ' + dbo.tbl_Route.DropLocation) } AS Route , dbo.VMS_VehicleInformation.RegiNo, dbo.VMS_VehicleInformation.VType,dbo.tbl_DutyRate.Rate, dbo.tbl_DutyRate.OddTimeRate, dbo.tbl_DutyRate.WChargePerMin, dbo.tbl_BankDuty.ReportingTime FROM dbo.tbl_BankDuty INNER JOIN dbo.tbl_Route ON dbo.tbl_BankDuty.RouteId = dbo.tbl_Route.Id INNER JOIN    dbo.VMS_VehicleInformation ON dbo.tbl_BankDuty.VehicleNo = dbo.VMS_VehicleInformation.Id INNER JOIN   dbo.tbl_DutyRate ON dbo.tbl_BankDuty.BankName = dbo.tbl_DutyRate.BankId AND dbo.tbl_Route.Id = dbo.tbl_DutyRate.RouteId INNER JOIN dbo.tbl_bankInfo ON dbo.tbl_BankDuty.BankName = dbo.tbl_bankInfo.id WHERE dbo.tbl_BankDuty.bankName = '" + cmbBankName.SelectedValue + "' AND dbo.tbl_BankDuty.ServiceDate Between '" + txtFromDate.Text.ToString() + "'AND'" + txtToDate.Text.ToString() + "' AND dbo.tbl_BankDuty.Status = 3 AND InvoiceStatus = 0 ORDER BY dbo.tbl_BankDuty.ServiceDate ", conn))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    gvInvoice.DataSource = dt;
                    gvInvoice.DataBind();
                } 
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }

        this.lblVatPercent.Visible = true;
        this.txtVat.Visible = true; 
        this.lblVat.Visible = true;
        this.checkVat.Visible = true;
        this.lblHeader.Visible = true;
        this.lblManagerName.Visible = true;
        this.txtManagerName.Visible = true;
        this.lblMngDesignation.Visible = true;
        this.txtMngDesignation.Visible = true;
        this.lblMobileNo.Visible = true;
        this.txtMngMobileNo.Visible = true;
        this.lblEmail.Visible = true;
        this.txtMngEmail.Visible = true;
        this.btnSave.Visible = true;
    }

    void SearchGV()
    {
        conn = DBUtility.GetConnection();
        using (SqlCommand cmd = new SqlCommand("SELECT dbo.tbl_BankDuty.* ,  dbo.tbl_Route.PickLocation, dbo.tbl_Route.DropLocation,dbo.tbl_bankInfo.shortBankName, dbo.tbl_bankInfo.shortBankName,dbo.tbl_bankInfo.bankName AS Bank, { fn CONCAT(dbo.tbl_Route.PickLocation, ' - ' + dbo.tbl_Route.DropLocation) } AS Route , dbo.VMS_VehicleInformation.RegiNo, dbo.VMS_VehicleInformation.VType,dbo.tbl_DutyRate.Rate, dbo.tbl_DutyRate.OddTimeRate, dbo.tbl_DutyRate.WChargePerMin, dbo.tbl_BankDuty.ReportingTime FROM dbo.tbl_BankDuty INNER JOIN dbo.tbl_Route ON dbo.tbl_BankDuty.RouteId = dbo.tbl_Route.Id INNER JOIN    dbo.VMS_VehicleInformation ON dbo.tbl_BankDuty.VehicleNo = dbo.VMS_VehicleInformation.Id INNER JOIN   dbo.tbl_DutyRate ON dbo.tbl_BankDuty.BankName = dbo.tbl_DutyRate.BankId AND dbo.tbl_Route.Id = dbo.tbl_DutyRate.RouteId INNER JOIN dbo.tbl_bankInfo ON dbo.tbl_BankDuty.BankName = dbo.tbl_bankInfo.id WHERE dbo.tbl_BankDuty.bankName = '" + cmbBankName.SelectedValue + "' AND dbo.tbl_BankDuty.ServiceDate Between '" + txtFromDate.Text.ToString() + "'AND'" + txtToDate.Text.ToString() + "' AND dbo.tbl_BankDuty.Status = 3 AND InvoiceStatus = 0 ORDER BY dbo.tbl_BankDuty.ServiceDate ", conn))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                sda.Fill(dt);
                gvInvoice.DataSource = dt;
                gvInvoice.DataBind();
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlConnection conn = DBUtility.GetConnection();


        int totalrows = this.gvInvoice.Rows.Count;

        //Declare Row for Auto ID 
        int row = 0;
        GridViewRow gvr = gvInvoice.Rows[row];

        Label lblBankShortName = (Label)gvr.FindControl("lblBankShortName");
        string BankShortName = lblBankShortName.Text.ToString();

        //find max number and generate auto id
        //"TAL/DBL/0522/1"
        string strSql = "SELECT  COUNT(Id) + 1 AS MaxId FROM tbl_InvoiceMaster WHERE (InvoiceID LIKE '%TAL/" + BankShortName.ToString() + "/%')";
        SqlCommand cmd1 = new SqlCommand(strSql, conn);
        SqlDataReader dr;
        conn.Open();
        dr = cmd1.ExecuteReader();
        if (dr.Read())
        {
            AAAutoId = "TAL/" + BankShortName.ToString() + "/" + DateTime.Today.ToString("MM") + DateTime.Today.ToString("yy") + "/" + dr["MaxId"].ToString();
        }
        conn.Close();


        InsertMasterData();

        

        //int totalrows = this.gvInvoice.Rows.Count;
        bool atLeastOneRowChecked = false;

        for (int r = 0; r < totalrows; r++)
        {
            GridViewRow thisGridViewRow = gvInvoice.Rows[r];
              
            CheckBox chkbox = (CheckBox)thisGridViewRow.FindControl("chkLTA");
            if (chkbox != null && chkbox.Checked)
            {
                atLeastOneRowChecked = true;

                Label lblId = (Label)thisGridViewRow.FindControl("lblBankDutyId");
                int id = Convert.ToInt32(lblId.Text.ToString());

                Label lblServiceDate = (Label)thisGridViewRow.FindControl("lblServiceDate");
                string ServiceDate = lblServiceDate.Text.ToString();

                Label lblUsername = (Label)thisGridViewRow.FindControl("lblUsername");
                string Username = lblUsername.Text.ToString();

                Label lblUserContactNo = (Label)thisGridViewRow.FindControl("lblUserContactNo");
                string UserContactNo = lblUserContactNo.Text.ToString();

                Label lblRegiNo = (Label)thisGridViewRow.FindControl("lblRegiNo");
                string RegiNo = lblRegiNo.Text.ToString();

                Label lblVType = (Label)thisGridViewRow.FindControl("lblVType");
                string VType = lblVType.Text.ToString();

                Label lblRate = (Label)thisGridViewRow.FindControl("lblRate");
                double Rate = Convert.ToDouble(lblRate.Text.ToString());

                Label lblRoute = (Label)thisGridViewRow.FindControl("lblRoute");
                int Route = Convert.ToInt32(lblRoute.Text.ToString()); 

                Label lblOddTimeRate = (Label)thisGridViewRow.FindControl("lblOddTimeRate");
                double OddTimeRate = Convert.ToDouble(lblOddTimeRate.Text.ToString());

                Label lblWChargePerMin = (Label)thisGridViewRow.FindControl("lblWChargePerMin");
                double WChargePerMin = Convert.ToDouble(lblWChargePerMin.Text.ToString());

                Label lblReportingTime = (Label)thisGridViewRow.FindControl("lblReportingTime");
                string ReportingTime = lblReportingTime.Text.ToString();

                Label lblPickTime = (Label)thisGridViewRow.FindControl("lblPickTime");
                string PickTime = lblPickTime.Text.ToString();

                Label lblWaitingTimeCharge = (Label)thisGridViewRow.FindControl("lblWaitingTimeCharge");
                float WaitingTimeCharge = float.Parse(lblWaitingTimeCharge.Text.ToString());

                Label lblPickLocation = (Label)thisGridViewRow.FindControl("lblPickLocation");
                string PickLocation = lblPickLocation.Text.ToString();

                Label lblDropLocation = (Label)thisGridViewRow.FindControl("lblDropLocation");
                string DropLocation = lblDropLocation.Text.ToString();


                int i;
                string strsql;

                strsql = "INSERT INTO [dbo].[tbl_InvoiceDetails](InvoiceID, [BankDutyID] ,[DutyDate],[NameOfUser],UserContactNo ,[VehicleNo],[VehicleType] ,[BasicRent] ,[OddTimeCharge],[WaitingTimeChargePerMin],[ReportingTime] ,[PickTime] ,[WaitingTimeCharge],[PickLocation],[DropLocation], Route) VALUES('" + AAAutoId.ToString() + "'," + id + ",'" + ServiceDate.ToString() + "','" + Username + "', '" + UserContactNo + "' ,'" + RegiNo + "','" + VType + "'," + Rate + "," + OddTimeRate + "," + WChargePerMin + ",'" + ReportingTime + "','" + PickTime + "'," + WaitingTimeCharge + ",'" + PickLocation + "','" + DropLocation + "' , '" + Route + "' )   ";
                i = DBTask.InsertData(strsql);

                int j;
                string strsql1;
                strsql1 = "Update tbl_BankDuty Set  InvoiceStatus = 1  where Id = " + Convert.ToInt32(lblId.Text.ToString());
                j = DBTask.InsertData(strsql1);

                try
                {
                    conn.Open();

                    if (i == 1)
                    {
                        
                        lblMsg.Text = "Record inserted successfully";
                        lblMsg.ForeColor = System.Drawing.Color.Green;

                        chkbox.Checked = false;

                    }
                    else
                    {
                        lblMsg.Text = "Something went wrong! Please try agian.";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch
                {

                }
                finally
                {
                    conn.Close();
                }
            }
        }
        SearchGV();
        //chkbox.Checked = false;

    }

    void InsertMasterData()
    {
        SqlConnection conn = DBUtility.GetConnection();

        int totalrows = this.gvInvoice.Rows.Count;
        int r = 0;
        GridViewRow thisGridViewRow = gvInvoice.Rows[r];

        Label lblBankShortName = (Label)thisGridViewRow.FindControl("lblBankShortName");
        string BankShortName = lblBankShortName.Text.ToString(); 

        //find max number and generate auto id
        //"TAL/DBL/0522/1"
        string strSql = "SELECT  COUNT(Id) + 1 AS MaxId FROM tbl_InvoiceMaster WHERE (InvoiceID LIKE '%TAL/" + BankShortName.ToString() + "/%')";
        SqlCommand cmd1 = new SqlCommand(strSql, conn);
        SqlDataReader dr;
        conn.Open();
        dr = cmd1.ExecuteReader();
        if (dr.Read())
        {
            AAAutoId = "TAL/" + BankShortName.ToString() + "/" + DateTime.Today.ToString("MM") + DateTime.Today.ToString("yy") + "/" + dr["MaxId"].ToString();
        }
        conn.Close();

        //if (txtManagerName.Text.ToString() == "")
        //{
        //    ShowMessage("Please Enter Manager Name!", MessageType.Warning);
        //    return;
        //}
        //if (txtMngDesignation.Text.ToString() == "")
        //{
        //    ShowMessage("Please Enter Manager Designation!", MessageType.Warning);
        //    return;
        //}
        //if (txtFromDate.Text.ToString() == "")
        //{
        //    ShowMessage("Please Enter From Date!", MessageType.Warning);
        //    return;
        //}
        //if (txtToDate.Text.ToString() == "")
        //{
        //    ShowMessage("Please Enter To Date!", MessageType.Warning);
        //    return;
        //}

        SqlCommand cmd = new SqlCommand("sp_InsertInvoiceMasterData", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@InvoiceID", SqlDbType.NVarChar, 50).Value = AAAutoId.ToString();
        cmd.Parameters.Add("@InvoiceDate", SqlDbType.Date).Value = DateTime.Now.ToString("MM/dd/yyyy");
        cmd.Parameters.Add("@InvoiceMonth", SqlDbType.NVarChar, 50).Value = Convert.ToDateTime(txtFromDate.Text.ToString()).ToString("MMMM");
        cmd.Parameters.Add("@InvoiceFromDate", SqlDbType.Date).Value = txtFromDate.Text.ToString();
        cmd.Parameters.Add("@InvoiceToDate", SqlDbType.Date).Value = txtToDate.Text.ToString();
        cmd.Parameters.Add("@BankID", SqlDbType.NVarChar, 100).Value = Convert.ToInt32(this.cmbBankName.SelectedValue);
        cmd.Parameters.Add("@MngrName", SqlDbType.NVarChar, 100).Value = txtManagerName.Text.ToString();
        cmd.Parameters.Add("@MngrDesignation", SqlDbType.NVarChar, 50).Value = txtMngDesignation.Text.ToString();
        cmd.Parameters.Add("@MngrPhoneNo", SqlDbType.NVarChar, 50).Value = txtMngMobileNo.Text.ToString();
        cmd.Parameters.Add("@MngrEmail", SqlDbType.NVarChar, 100).Value = txtMngEmail.Text.ToString();
        cmd.Parameters.Add("@Note", SqlDbType.NVarChar,500).Value = lblNote.Text.ToString();
        cmd.Parameters.Add("@VatText", SqlDbType.NVarChar, 100).Value = checkVat.SelectedItem.Text.ToString();
        cmd.Parameters.Add("@VatPercent", SqlDbType.NChar, 10).Value = txtVat.Text.ToString();
        cmd.Parameters.Add("@OpBy", SqlDbType.NVarChar, 50).Value = Session["Username"].ToString();



        try 
        { 
            conn.Open();

            int row = cmd.ExecuteNonQuery();
            if (row == 1)
            {
                txtManagerName.Text = "";
                txtMngDesignation.Text = "";
                txtMngMobileNo.Text = "";
                txtMngEmail.Text = "";
                txtVat.Text = ""; 

                checkVat.Items[0].Selected = false;
                checkVat.Items[1].Selected = false; 

                lblMsg.Text = "Record inserted successfully";
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

        }
        finally
        {
            conn.Close();
        }

    }

    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        ToggleCheckState(true);
    }

    private void ToggleCheckState(bool checkState)
    {

        // Iterate through the Products.Rows property
        foreach (GridViewRow row in gvInvoice.Rows)
        {
            // Access the CheckBox
            CheckBox cb = (CheckBox)row.FindControl("chkLTA");
            if (cb != null)
                cb.Checked = checkState;
        }

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