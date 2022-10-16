using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class EditVehicle : System.Web.UI.Page
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
            strSql = "SELECT * FROM tbl_VehicleType WHERE id=" + Application["vehId"].ToString();
            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataReader dr;

            conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtVehicleName.Text = dr["Name"].ToString();
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
            strsql = "Update tbl_VehicleType set Name ='" + this.txtVehicleName.Text.ToString() + "', Remarks ='" + this.txtRemarks.Text + "' Where id='" + Application["vehId"].ToString() + "'";
            i = DBTask.InsertData(strsql);

            //For log details
            int j;
            string strsql1;
            strsql1 = "Insert into tbl_applog (appname, tblname, optype, cid, opby) Values('IT Assets Management Software','tbl_VehicleType','Update','','" + Session["Username"].ToString() + "')";
            j = DBTask.InsertData(strsql1);

        }
        Response.Redirect("/ManageVehicle");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/ManageVehicle");
    }
}