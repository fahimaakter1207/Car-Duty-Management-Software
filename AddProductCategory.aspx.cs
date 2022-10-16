using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class AddProductCategory : System.Web.UI.Page
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
                
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["danaerpConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(constr);

        SqlCommand cmd = new SqlCommand("spInsertProductCategory", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 200).Value = this.txtCategoryName.Text.ToString();
        cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar, 200).Value = this.txtRemarks.Text.ToString();
        cmd.Parameters.Add("@OpeningQty", SqlDbType.Int, 4).Value = Convert.ToInt32(this.txtopqty.Text.ToString());
        cmd.Parameters.Add("@OpBy", SqlDbType.VarChar, 100).Value = Session["Username"].ToString();

        try
        {
            conn.Open();
            int row = cmd.ExecuteNonQuery();
            if (row == 1)
            {
                ShowMessage("Record inserted successfully.", MessageType.Success);
                txtCategoryName.Text = "";
                txtopqty.Text = "";
                txtRemarks.Text = "";



                ScriptManager1.SetFocus(txtCategoryName);
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
        Response.Redirect("/ManageProductCategory");
    }
}