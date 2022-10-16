using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class AddAssignAssets : System.Web.UI.Page
{
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("/login");
            }
            else
            {
                //load assets information
                string strSql = "Select ' Select Assets' as AssetsName,'-1' as aid union Select AssetsName as AssetsName, Id as aid from IT_AssetsInformation Where AStatus=0";
                LoadCombo.fillcombo(this.cmbAssets, strSql, "AssetsName", "aid");

                //load employee information
                string strSql1 = "Select ' Select Employee' as EmployeeName,'-1' as empid union Select empname as EmployeeName, id as empid from tbl_employeecontactinfo";
                LoadCombo.fillcombo(this.cmbEmployee, strSql1, "EmployeeName", "empid");

                
                txtDeliveryDate.Text = DateTime.Today.ToString("MMMM dd, yyyy");

            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        string constr = ConfigurationManager.ConnectionStrings["danaerpConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(constr);

        SqlCommand cmd = new SqlCommand("spInsertAssignAssets", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@AssetsId", SqlDbType.Int, 4).Value = Convert.ToInt32(this.cmbAssets.SelectedValue);
        cmd.Parameters.Add("@EmpId", SqlDbType.Int, 4).Value = Convert.ToInt32(this.cmbEmployee.SelectedValue);
        
        cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = this.txtDeliveryDate.Text.ToString();
        cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = this.txtRemarks.Text.ToString();
        cmd.Parameters.Add("@OpBy", SqlDbType.VarChar, 100).Value = Session["Username"].ToString();

        try
        {
            conn.Open();
            int row = cmd.ExecuteNonQuery();
            if (row == 1)
            {
                ShowMessage("Record inserted successfully.", MessageType.Success);
                
                //insert data into assetstracking table
                int i;
                string strsql;
                strsql = "Insert into IT_AssetsTracking (AssetsId, EmpID, EmployeeName, DeliveryDate, Type, OpBy) Values(" + Convert.ToInt32(cmbAssets.SelectedValue) + "," + Convert.ToInt32(cmbEmployee.SelectedValue) + ",'" + cmbEmployee.SelectedItem.Text.ToString() + "','" + txtDeliveryDate.Text.ToString() + "','Delivered', '" + Session["Username"].ToString() + "')";
                i = DBTask.InsertData(strsql);

                //insert data into assetstracking table
                int j;
                string strsql1;
                strsql1 = "Update IT_AssetsInformation set AStatus='1' Where id=" + Convert.ToInt32(cmbAssets.SelectedValue);
                j = DBTask.InsertData(strsql1);



                cmbAssets.SelectedValue = "-1";
                cmbEmployee.SelectedValue = "-1";
                
                txtDeliveryDate.Text = DateTime.Today.ToString("MMMM dd, yyyy");
                txtRemarks.Text = "";
                
                

                ScriptManager1.SetFocus(cmbAssets);
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
        Response.Redirect("/ManageAssignAssets");
    }

    //protected void cmbcompany_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //load department information
    //    string strSql = "Select ' Select Department' as DepartmentName,'-1' as did union Select name as DepartmentName, id as did from tbl_department where cid=" + Convert.ToInt32(cmbcompany.SelectedValue);
    //    LoadCombo.fillcombo(this.cmbDepartment, strSql, "DepartmentName", "did");
    //}
}