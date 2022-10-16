using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class EditBankDutyUser : System.Web.UI.Page
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
                Response.Redirect("/login");
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
        string strSql;
        conn = DBUtility.GetConnection();
        try
        {
            strSql = "select * from tbl_BankUserInfo where Id = " + Application["Id"].ToString();
            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataReader dr;
            conn.Open();

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtName.Text = dr["Name"].ToString();
                txtContact.Text = dr["ContactNo"].ToString();
                txtUserEmail.Text = dr["Email"].ToString();

                txtUN.Text = dr["Name"].ToString();
                txtPN.Text = dr["ContactNo"].ToString();
            }
            dr.Close();
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
        finally
        {
            conn.Close();
        }
        //return;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Response.Redirect("/login");
        }
        else
        {
            int k;
            string strsql2;
            strsql2 = "Update tbl_BankDuty set Username='" + this.txtName.Text.ToString() + "', ContactNo = '" + this.txtContact.Text.ToString() + "',   Email = '" + this.txtUserEmail.Text.ToString() + "'  Where Username='" + txtUN.Text.ToString() + "' and ContactNo='" + txtPN.Text.ToString() + "'";
            k = DBTask.InsertData(strsql2);

            int i;
            string strsql;
            strsql = "Update tbl_BankUserInfo set Name='" + this.txtName.Text.ToString() + "', ContactNo = '" + this.txtContact.Text.ToString() + "',   Email = '" + this.txtUserEmail.Text.ToString() + "'  Where id='" + Application["Id"].ToString() + "'";
            i = DBTask.InsertData(strsql);
            
            

            ShowMessage("Record Updated successfully!", MessageType.Success);

            //For log details
            int j;
            string strsql1;
            strsql1 = "Insert into tbl_applog (appname, tblname, optype, cid, opby) Values('IT Assets Management Software','tbl_BankUserInfo','Update','','" + Session["Username"].ToString() + "')";
            j = DBTask.InsertData(strsql1);

        }
        Response.Redirect("/ManageBankDutyUser");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/ManageBankDutyUser");
    }

}