using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class AddAssetsInformation : System.Web.UI.Page
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
                this.txtLType.Visible = false;
                this.lblLiType.Visible = false;
                this.lblLKey.Visible = false;
                this.txtLKey.Visible = false;
                this.lblType.Visible = false;
                this.txtType.Visible = false;
                this.lblTonerModel.Visible = false;
                this.txtTonerModel.Visible = false;


                //load product information
                string strSql = "Select ' Select Product' as ProductName,'-1' as pid union Select Name as ProductName, Id as pid from IT_ProductCategory";
                LoadCombo.fillcombo(this.cmbProduct, strSql, "ProductName", "pid");

                //load vendor information
                string strSql1 = "Select ' Select Vendor' as VendorName,'-1' as vid union Select name as VendorName, id as vid from IT_VendorInformation";
                LoadCombo.fillcombo(this.cmbVendor, strSql1, "VendorName", "vid");
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        string constr = ConfigurationManager.ConnectionStrings["danaerpConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(constr);

        SqlCommand cmd = new SqlCommand("spInsertAssetsInformation", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@ProdId", SqlDbType.Int, 4).Value = Convert.ToInt32(this.cmbProduct.SelectedValue);
        cmd.Parameters.Add("@AssetsCode", SqlDbType.NVarChar, 200).Value = this.txtAssetsCode.Text.ToString();
        cmd.Parameters.Add("@AssetsName", SqlDbType.NVarChar, 200).Value = this.txtAssetsName.Text.ToString();
        cmd.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar, 200).Value = this.txtInvoiceNo.Text.ToString();
        cmd.Parameters.Add("@InvoiceDate", SqlDbType.DateTime).Value = this.txtInvoiceDate.Text.ToString();
        cmd.Parameters.Add("@PurchaseDate", SqlDbType.DateTime).Value = this.txtPurchaseDate.Text.ToString();
        cmd.Parameters.Add("@PurchasePrice", SqlDbType.Float).Value = this.txtPurchasePrice.Text.ToString();
        cmd.Parameters.Add("@SerialNo", SqlDbType.NVarChar, 100).Value = this.txtSerialNummber.Text.ToString();
        cmd.Parameters.Add("@BrandName", SqlDbType.VarChar, 200).Value = this.txtBrandName.Text.ToString();
        cmd.Parameters.Add("@Description", SqlDbType.VarChar, 1000).Value = this.txtDescription.Text.ToString();
        cmd.Parameters.Add("@Warranty", SqlDbType.VarChar, 100).Value = this.txtWarranty.Text.ToString();
        cmd.Parameters.Add("@LicenseType", SqlDbType.VarChar, 100).Value = this.txtLType.Text.ToString();
        cmd.Parameters.Add("@LicenseKey", SqlDbType.VarChar, 100).Value = this.txtLKey.Text.ToString();
        cmd.Parameters.Add("@Type", SqlDbType.VarChar, 100).Value = this.txtType.Text.ToString();
        cmd.Parameters.Add("@TonerModel", SqlDbType.VarChar, 100).Value = this.txtTonerModel.Text.ToString();
        cmd.Parameters.Add("@VendorId", SqlDbType.VarChar, 100).Value = Convert.ToInt32(this.cmbVendor.SelectedValue);
        cmd.Parameters.Add("@OpBy", SqlDbType.VarChar, 100).Value = Session["Username"].ToString();

        try
        {
            conn.Open();
            int row = cmd.ExecuteNonQuery();
            if (row == 1)
            {
                ShowMessage("Record inserted successfully.", MessageType.Success);
                cmbProduct.SelectedValue = "-1";
                txtAssetsCode.Text = "";
                txtAssetsName.Text = "";
                txtInvoiceNo.Text = "";
                txtInvoiceDate.Text = DateTime.Today.ToString("MMMM dd, yyyy");
                txtPurchaseDate.Text = DateTime.Today.ToString("MMMM dd, yyyy");
                txtPurchasePrice.Text = "";
                txtSerialNummber.Text = "";
                txtBrandName.Text = "";
                txtDescription.Text = "";
                txtWarranty.Text = "";
                txtLType.Text = "";
                txtLKey.Text = "";
                txtType.Text = "";
                txtTonerModel.Text = "";
                cmbVendor.SelectedValue = "-1";
                

                ScriptManager1.SetFocus(cmbProduct);
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
        Response.Redirect("/ManageAssetsInformation");
    }

    protected void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbProduct.SelectedItem.Text.ToString() == "Mouse USB")
        {
            
            this.txtLType.Visible = false;
            this.lblLiType.Visible = false;
            this.lblLKey.Visible = false;
            this.txtLKey.Visible = false;
            this.lblType.Visible = false;
            this.txtType.Visible = false;
            this.lblTonerModel.Visible = false;
            this.txtTonerModel.Visible = false;
        }

        if (cmbProduct.SelectedItem.Text.ToString() == "Dektop Computer")
        {

            this.txtLType.Visible = false;
            this.lblLiType.Visible = false;
            this.lblLKey.Visible = false;
            this.txtLKey.Visible = false;
            this.lblType.Visible = false;
            this.txtType.Visible = false;
            this.lblTonerModel.Visible = false;
            this.txtTonerModel.Visible = false;
        }


        
        
        if (cmbProduct.SelectedItem.Text.ToString() == "Printer")
        {

            this.txtLType.Visible = false;
            this.lblLiType.Visible = false;
            this.lblLKey.Visible = false;
            this.txtLKey.Visible = false;
            this.lblType.Visible = true;
            this.txtType.Visible = true;
            this.lblTonerModel.Visible = true;
            this.txtTonerModel.Visible = true;
        }

        if (cmbProduct.SelectedItem.Text.ToString() == "Antivirus")
        {

            this.txtLType.Visible = true;
            this.lblLiType.Visible = true;
            this.lblLKey.Visible = true;
            this.txtLKey.Visible = true;
            this.lblType.Visible = false;
            this.txtType.Visible = false;
            this.lblTonerModel.Visible = false;
            this.txtTonerModel.Visible = false;
        }
        if (cmbProduct.SelectedItem.Text.ToString() == "Laptop")
        {

            this.txtLType.Visible = false;
            this.lblLiType.Visible = false;
            this.lblLKey.Visible = false;
            this.txtLKey.Visible = false;
            this.lblType.Visible = false;
            this.txtType.Visible = false;
            this.lblTonerModel.Visible = false;
            this.txtTonerModel.Visible = false;
        }
        if (cmbProduct.SelectedItem.Text.ToString() == "Pen Drive")
        {

            this.txtLType.Visible = false;
            this.lblLiType.Visible = false;
            this.lblLKey.Visible = false;
            this.txtLKey.Visible = false;
            this.lblType.Visible = false;
            this.txtType.Visible = false;
            this.lblTonerModel.Visible = false;
            this.txtTonerModel.Visible = false;
        }
        if (cmbProduct.SelectedItem.Text.ToString() == "UPS")
        {

            this.txtLType.Visible = false;
            this.lblLiType.Visible = false;
            this.lblLKey.Visible = false;
            this.txtLKey.Visible = false;
            this.lblType.Visible = false;
            this.txtType.Visible = false;
            this.lblTonerModel.Visible = false;
            this.txtTonerModel.Visible = false;
        }
        if (cmbProduct.SelectedItem.Text.ToString() == "Mouse")
        {

            this.txtLType.Visible = false;
            this.lblLiType.Visible = false;
            this.lblLKey.Visible = false;
            this.txtLKey.Visible = false;
            this.lblType.Visible = false;
            this.txtType.Visible = false;
            this.lblTonerModel.Visible = false;
            this.txtTonerModel.Visible = false;
        }
        if (cmbProduct.SelectedItem.Text.ToString() == "RAM")
        {

            this.txtLType.Visible = false;
            this.lblLiType.Visible = false;
            this.lblLKey.Visible = false;
            this.txtLKey.Visible = false;
            this.lblType.Visible = false;
            this.txtType.Visible = false;
            this.lblTonerModel.Visible = false;
            this.txtTonerModel.Visible = false;
        }
        if (cmbProduct.SelectedItem.Text.ToString() == "LCD Monitor")
        {

            this.txtLType.Visible = false;
            this.lblLiType.Visible = false;
            this.lblLKey.Visible = false;
            this.txtLKey.Visible = false;
            this.lblType.Visible = false;
            this.txtType.Visible = false;
            this.lblTonerModel.Visible = false;
            this.txtTonerModel.Visible = false;
        }
        if (cmbProduct.SelectedItem.Text.ToString() == "Monitor")
        {

            this.txtLType.Visible = false;
            this.lblLiType.Visible = false;
            this.lblLKey.Visible = false;
            this.txtLKey.Visible = false;
            this.lblType.Visible = false;
            this.txtType.Visible = false;
            this.lblTonerModel.Visible = false;
            this.txtTonerModel.Visible = false;
        }
        if (cmbProduct.SelectedItem.Text.ToString() == "Scaner")
        {

            this.txtLType.Visible = false;
            this.lblLiType.Visible = false;
            this.lblLKey.Visible = false;
            this.txtLKey.Visible = false;
            this.lblType.Visible = false;
            this.txtType.Visible = false;
            this.lblTonerModel.Visible = false;
            this.txtTonerModel.Visible = false;
        }
        if (cmbProduct.SelectedItem.Text.ToString() == "Key Board")
        {

            this.txtLType.Visible = false;
            this.lblLiType.Visible = false;
            this.lblLKey.Visible = false;
            this.txtLKey.Visible = false;
            this.lblType.Visible = false;
            this.txtType.Visible = false;
            this.lblTonerModel.Visible = false;
            this.txtTonerModel.Visible = false;
        }
    }
}