using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class EditUser_Admin : System.Web.UI.Page
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
            strSql = "SELECT  dbo.tbl_access.id as accid, dbo.tbl_access.accessname, dbo.tbl_users.id, dbo.tbl_users.username, dbo.tbl_users.password FROM  dbo.tbl_users INNER JOIN dbo.tbl_access ON dbo.tbl_users.id = dbo.tbl_access.id where  dbo.tbl_users.id =" + Application["userId"].ToString();

            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtUserName.Text = dr["username"].ToString();
                txtpassword.Text = dr["password"].ToString();
                cmbAccess.SelectedValue = dr["accid"].ToString();

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
            strsql = "Update tbl_users set username='" + this.txtUserName.Text.ToString() + "', password = '" + this.txtpassword.Text.ToString() + "', accid =" + Convert.ToInt32(this.cmbAccess.SelectedValue) + " Where id='" + Application["userId"].ToString() + "'";
            i = DBTask.InsertData(strsql);

            //For log details
            int j;
            string strsql1;
            strsql1 = "Insert into tbl_applog (appname, tblname, optype, cid, opby) Values('IT Assets Management Software','tbl_users','Update','','" + Session["Username"].ToString() + "')";
            j = DBTask.InsertData(strsql1);

        }
        Response.Redirect("/ManageUsers_Admin");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/ManageUsers_Admin");
    }
}