using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;



public partial class EditAssignAssets : System.Web.UI.Page
{
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
                //load assets information
                string strSql = "Select ' Select Assets' as AssetsName,'-1' as aid union Select AssetsName as AssetsName, Id as aid from IT_AssetsInformation";
                LoadCombo.fillcombo(this.cmbAssets, strSql, "AssetsName", "aid");

                //load employee information
                string strSql1 = "Select ' Select Employee' as EmployeeName,'-1' as empid union Select empname as EmployeeName, id as empid from tbl_employeecontactinfo";
                LoadCombo.fillcombo(this.cmbEmployee, strSql1, "EmployeeName", "empid");

                refData();
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
    void refData()
    {
        
        SqlConnection conn;
        string strSql;
        conn = DBUtility.GetConnection();
        try
        {

            strSql = "SELECT aa.*, ai.id as asid, ai.AssetsName as AssetsName, e.id as empid, e.empname as EmployeeName FROM IT_AssignAssets aa INNER JOIN IT_AssetsInformation ai ON aa.AssetsId=ai.Id INNER JOIN tbl_employeecontactinfo e on aa.EmpId=e.id WHERE aa.id=" + Application["assignassetsId"].ToString();

            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                cmbAssets.SelectedValue = dr["asid"].ToString();
                cmbEmployee.SelectedValue = dr["empid"].ToString();
                
                txtDeliveryDate.Text = Convert.ToDateTime(dr["DeliveryDate"]).ToString("MM/dd/yyyy");
                txtRemarks.Text = dr["Remarks"].ToString();
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
        if (!IsPostBack)
        {
            Response.Redirect("/login");
        }
        else
        {
            int i;
            string strsql;
            strsql = "Update IT_AssignAssets set AssetsId=" + Convert.ToInt32(this.cmbAssets.SelectedValue) + ", EmpId=" + Convert.ToInt32(this.cmbEmployee.SelectedValue)  + ", DeliveryDate='" + txtDeliveryDate.Text.ToString() + "', Remarks='" + txtRemarks.Text.ToString() + "' Where id='" + Application["assignassetsId"].ToString() + "'";
            i = DBTask.InsertData(strsql);


            //Insert data into trace table
            if (chkReassign.Checked == true)
            {
                int k;
                string strsql2;
                strsql2 = "Insert into IT_AssetsTracking (AssetsId, EmpID, EmployeeName, DeliveryDate, Type, OpBy) Values(" + Convert.ToInt32(cmbAssets.SelectedValue) + "," + Convert.ToInt32(cmbEmployee.SelectedValue) + ",'" + cmbEmployee.SelectedItem.Text.ToString() + "','" + txtDeliveryDate.Text.ToString() + "','Delivered', '" + Session["Username"].ToString() + "')";
                k = DBTask.InsertData(strsql2);
            }

            //For log details
            int j;
            string strsql1;
            strsql1 = "Insert into tbl_applog (appname, tblname, optype, cid, opby) Values('IT Assets Management Software','IT_AssignAssets','Update','','" + Session["Username"].ToString() + "')";
            j = DBTask.InsertData(strsql1);

        }
        Response.Redirect("/ManageAssignAssets");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/ManageAssignAssets");
    }

    
}