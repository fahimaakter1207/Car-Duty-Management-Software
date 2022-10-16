using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class AddEmployee : System.Web.UI.Page
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
                //load company information
                string strSql = "Select ' Select Company' as CompanyName,'-1' as cid union Select name as CompanyName, id as cid from tbl_Company";
                LoadCombo.fillcombo(this.cmbcompany, strSql, "CompanyName", "cid");

                //load designation information
                string strSql1 = "Select ' Select Designation' as DesignationName,'-1' as desigid union Select name as DesignationName, id as desigid from tbl_designation";
                LoadCombo.fillcombo(this.cmbDesignation, strSql1, "DesignationName", "desigid");
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        try
        {
            int i;
            string strsql;
            strsql = "Insert into tbl_employeecontactinfo (empname, deptid, desigid, mobileno, pabx, location, email, additionalemail, cid, fname, mname, emptype, jobstatus, empid, empexistingid, opby) Values('" + txtEmployeeName.Text.ToString() + "'," + Convert.ToInt32(cmbDepartment.SelectedValue) + "," + Convert.ToInt32(cmbDesignation.SelectedValue) + ",'" + txtMobileNo.Text.ToString() + "','" + txtPabx.Text.ToString() + "','" + txtLocation.Text.ToString() + "','" + txtEmail.Text.ToString() + "','" + txtadditionalemail.Text.ToString() + "'," + Convert.ToInt32(cmbcompany.SelectedValue) + ",'" + txtFatherName.Text.ToString() + "','" + txtMotherName.Text.ToString() + "','Permanent','Active','" + txtEmployeeId.Text.ToString() + "','" + txtEmployeeId.Text.ToString() + "','" + Session["Username"].ToString() + "')";
            i = DBTask.InsertData(strsql);

            //insert data into user table
            int j;
            string strsql1;
            strsql1 = "Insert into tbl_users (username, password, cid, opby) Values('" + txtEmail.Text.ToString() + "','123456'," + Convert.ToInt32(cmbcompany.SelectedValue) + ",'" + Session["Username"].ToString() + "')";
            j = DBTask.InsertData(strsql1);


            //find last userid

            SqlConnection conn;
            string strSqlun;
            string userid = "";
            conn = DBUtility.GetConnection();
            try
            {

                strSqlun = "SELECT * FROM tbl_users WHERE username='" + txtEmail.Text.ToString() + "'";

                SqlCommand cmd = new SqlCommand(strSqlun, conn);
                SqlDataReader dr;
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    userid = dr["id"].ToString();
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


            //user trace in mapping table
            int k;
            string strsql2;
            strsql2 = "Insert into tbl_user_mapping (userid, accid, opby) Values(" + Convert.ToInt32(userid.ToString()) + ",11,'" + Session["Username"].ToString() + "')";
            k = DBTask.InsertData(strsql2);

            ShowMessage("Record inserted successfully.", MessageType.Success);
            txtEmployeeName.Text = "";
            txtEmployeeId.Text = "";
            txtFatherName.Text = "";
            txtMotherName.Text = "";
            cmbcompany.SelectedValue = "-1";
            cmbDesignation.SelectedValue = "-1";
            cmbDepartment.SelectedValue = "-1";
            

            txtEmail.Text = "";
            txtadditionalemail.Text = "";
            txtMobileNo.Text = "";
            txtPabx.Text = "";
            txtLocation.Text = "";
            
            ScriptManager1.SetFocus(txtEmployeeName);

        }
        catch
        {
            ShowMessage("Something went worng, most likely Duplicate Recroed is Detected/ Inputed value is greater than actual field size/ Inappropriate value.", MessageType.Error);
        }
        

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/ManageEmployee");
    }

    protected void cmbcompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        //load department information
        string strSql = "Select ' Select Department' as DepartmentName,'-1' as did union Select name as DepartmentName, id as did from tbl_department where cid=" + Convert.ToInt32(cmbcompany.SelectedValue);
        LoadCombo.fillcombo(this.cmbDepartment, strSql, "DepartmentName", "did");
    }
}