using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;



public partial class EditAssetsInformation : System.Web.UI.Page
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
                //load product information
                string strSql = "Select ' Select Product' as ProductName,'-1' as pid union Select Name as ProductName, Id as pid from IT_ProductCategory";
                LoadCombo.fillcombo(this.cmbProduct, strSql, "ProductName", "pid");

                //load vendor information
                string strSql1 = "Select ' Select Vendor' as VendorName,'-1' as vid union Select name as VendorName, id as vid from IT_VendorInformation";
                LoadCombo.fillcombo(this.cmbVendor, strSql1, "VendorName", "vid");
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

            strSql = "SELECT ai.*, v.id as Vid, v.name as VendorName, p.id as Pid, p.name as ProductName FROM IT_AssetsInformation ai INNER JOIN IT_VendorInformation v on ai.VendorId=v.id INNER JOIN IT_ProductCategory p on ai.ProdId=p.id WHERE ai.id=" + Application["assetsId"].ToString();

            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                cmbProduct.SelectedValue = dr["Pid"].ToString();
                txtAssetsCode.Text = dr["AssetsCode"].ToString();
                txtAssetsName.Text = dr["AssetsName"].ToString();
                txtInvoiceNo.Text = dr["InvoiceNo"].ToString();
                txtInvoiceDate.Text = Convert.ToDateTime(dr["InvoiceDate"]).ToString("MM/dd/yyyy");
                txtPurchaseDate.Text = Convert.ToDateTime(dr["PurchaseDate"]).ToString("MM/dd/yyyy");
                txtPurchasePrice.Text = dr["PurchasePrice"].ToString();
                txtSerialNummber.Text = dr["SerialNumber"].ToString();
                txtBrandName.Text = dr["BrandName"].ToString();
                txtDescription.Text = dr["Description"].ToString();
                txtWarranty.Text = dr["Warranty"].ToString();
                txtLType.Text = dr["LicenseType"].ToString();
                txtLKey.Text = dr["LicenseKey"].ToString();
                txtType.Text = dr["Type"].ToString();
                txtTonerModel.Text = dr["TonerModel"].ToString();
                cmbVendor.SelectedValue = dr["Vid"].ToString();
                cmbStatus.SelectedValue = dr["Status"].ToString();

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
            strsql = "Update IT_AssetsInformation set ProdId=" + Convert.ToInt32(this.cmbProduct.SelectedValue) + ", AssetsCode='" + this.txtAssetsCode.Text.ToString() + "', AssetsName='" + this.txtAssetsName.Text.ToString() + ", InvoiceNo='" + this.txtInvoiceNo.Text.ToString() + "', InvoiceDate='" + this.txtInvoiceDate.Text.ToString() + "', PurchaseDate ='" + txtPurchaseDate.Text.ToString() + "', PurchasePrice='" + txtPurchasePrice.Text.ToString() + "', SerialNumber ='" + txtSerialNummber.Text.ToString() + "', BrandName='" + txtBrandName.Text.ToString() + "', Description='" + txtDescription.Text.ToString() + "', Warranty='" + txtWarranty.Text.ToString() + "', LicenseType='" + txtLType.Text.ToString() + "', LicenseKey='" + txtLKey.Text.ToString() + "', Type='" + txtType.Text.ToString() + "', TonerModel='" + txtTonerModel.Text.ToString() + "', VendorId=" + Convert.ToInt32(cmbVendor.SelectedValue) + ", Status='" + cmbStatus.SelectedItem.Text.ToString() + "' Where id='" + Application["assetsId"].ToString() + "'";
            i = DBTask.InsertData(strsql);

            //For log details
            int j;
            string strsql1;
            strsql1 = "Insert into tbl_applog (appname, tblname, optype, cid, opby) Values('IT Assets Management Software','IT_AssetsInformation','Update','','" + Session["Username"].ToString() + "')";
            j = DBTask.InsertData(strsql1);

        }
        Response.Redirect("/ManageAssets");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/ManageAssets");
    }

    
}