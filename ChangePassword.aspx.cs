using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class ChangePassword : System.Web.UI.Page
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
        }
    }

    byte up;
    protected void btnChangePass_Click(object sender, EventArgs e)
    {
        SqlConnection conn = DBUtility.GetConnection();
        string strsql = "Select username , password from tbl_users";
        SqlCommand cmd = new SqlCommand(strsql, conn);
        
        conn.Open();
        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
            if (txtOldPass.Text == sdr["password"].ToString())
            {
                up = 1;
            }
        }
        sdr.Close();
        conn.Close();

        if (up == 1)
        {
            conn.Open();
            strsql = "update tbl_users set Password = @password where UserName ='" + Session["username"].ToString() + "'";
            cmd = new SqlCommand(strsql, conn);
            cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 50));
            cmd.Parameters["@password"].Value = txtNewPass.Text;

            cmd.ExecuteNonQuery();
            conn.Close();
            ShowMessage("Password changed Successfully", MessageType.Success);
            lblmsg.Text = "Password changed Successfully";
        }
        else
        {
            ShowMessage("Please enter correct old password!!!", MessageType.Error);
        }
    }

}