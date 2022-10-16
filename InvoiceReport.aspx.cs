using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; 

public partial class InvoiceReport : System.Web.UI.Page
{
    SqlConnection conn = DBUtility.GetConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        string strsql = "SELECT  dbo.tbl_InvoiceMaster.*, dbo.tbl_bankInfo.bankName, dbo.tbl_bankInfo.bankDept, dbo.tbl_bankInfo.address  FROM   dbo.tbl_bankInfo INNER JOIN  dbo.tbl_InvoiceMaster ON dbo.tbl_bankInfo.id = dbo.tbl_InvoiceMaster.BankID WHERE tbl_InvoiceMaster.InvoiceID = '" + Application["InvoiceId"].ToString() + "' ";
        //string strsql = "SELECT   dbo.tbl_bankInfo.bankName, dbo.tbl_bankInfo.bankDept, dbo.tbl_InvoiceMaster.InvoiceID, dbo.tbl_InvoiceMaster.InvoiceFromDate, dbo.tbl_InvoiceMaster.InvoiceToDate  FROM  dbo.tbl_bankInfo INNER JOIN  dbo.tbl_InvoiceMaster ON dbo.tbl_bankInfo.id = dbo.tbl_InvoiceMaster.BankID ";
        conn.Open();
        SqlCommand cmd = new SqlCommand(strsql, conn);
        SqlDataReader sda = cmd.ExecuteReader();

        sda.Read();
        lblBankName.Text = sda["bankName"].ToString();
        lblBankAddress.Text = sda["address"].ToString();
        lblBankDept.Text = sda["bankDept"].ToString();
        lblInvoiceNo.Text = sda["InvoiceID"].ToString();
        lblfrmDate.Text = Convert.ToDateTime(sda["InvoiceFromDate"].ToString()).ToString("dd-MM-yy");
        lbltoDate.Text = Convert.ToDateTime(sda["InvoiceToDate"].ToString()).ToString("dd-MM-yy");
        lblBillingDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
        lblManagerName.Text = sda["MngrName"].ToString();
        lblMngrDesignation.Text = sda["MngrDesignation"].ToString();
        lblMngrMobileNo.Text = sda["MngrPhoneNo"].ToString();
        lblMngrEmail.Text = sda["MngrEmail"].ToString();
        lblbank.Text = sda["bankName"].ToString();
        lblVatText.Text = sda["VatText"].ToString();
        lblVatPercent.Text = sda["VatPercent"].ToString();

        sda.Close();
        conn.Close();

        getData();
        GrandTotalCount();
        refDataGeneralLedger();
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    void refDataGeneralLedger()
    {
        DataSet ds;
        try
        {
            using (SqlConnection con = DBUtility.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT  dbo.tbl_InvoiceDetails.ID, dbo.tbl_InvoiceDetails.InvoiceID, dbo.tbl_InvoiceDetails.BankDutyID, dbo.tbl_InvoiceDetails.DutyDate, dbo.tbl_InvoiceDetails.NameOfUser, dbo.tbl_InvoiceDetails.UserContactNo, dbo.tbl_InvoiceDetails.VehicleNo, dbo.tbl_InvoiceDetails.VehicleType, dbo.tbl_InvoiceDetails.PickLocation, dbo.tbl_InvoiceDetails.DropLocation, dbo.tbl_InvoiceDetails.BasicRent, dbo.tbl_InvoiceDetails.OddTimeCharge,   dbo.tbl_InvoiceDetails.WaitingTimeCharge, dbo.tbl_InvoiceDetails.BasicRent + dbo.tbl_InvoiceDetails.OddTimeCharge + dbo.tbl_InvoiceDetails.WaitingTimeCharge AS Total FROM dbo.tbl_InvoiceDetails INNER JOIN dbo.tbl_InvoiceMaster ON dbo.tbl_InvoiceDetails.InvoiceID = dbo.tbl_InvoiceMaster.InvoiceID WHERE tbl_InvoiceMaster.InvoiceID = '" + lblInvoiceNo.Text.ToString() + "' ", conn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        gvInvoiceReport.DataSource = dt;
                        gvInvoiceReport.DataBind();

                        //Calculate Sum and display in Footer Row
                        double totalOTC = dt.AsEnumerable().Sum(row => row.Field<double>("OddTimeCharge"));
                        double totalWTC = dt.AsEnumerable().Sum(row => row.Field<double>("WaitingTimeCharge"));
                        double grandToal = dt.AsEnumerable().Sum(row => row.Field<double>("total"));
                        gvInvoiceReport.FooterRow.Cells[8].Text = "Total";
                        gvInvoiceReport.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Right;
                        gvInvoiceReport.FooterRow.Cells[9].Text = totalOTC.ToString("N2");
                        gvInvoiceReport.FooterRow.Cells[10].Text = totalWTC.ToString("N2");
                        gvInvoiceReport.FooterRow.Cells[11].Text = grandToal.ToString("N2");
                    }
                }
            }
        }
        catch(Exception ex)
        {

        } 
    }
     

    public string getData()
    {
        string htmlstr = "";

        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT  dbo.tbl_InvoiceDetails.ID, dbo.tbl_InvoiceDetails.InvoiceID, dbo.tbl_InvoiceDetails.BankDutyID, dbo.tbl_InvoiceDetails.DutyDate, dbo.tbl_InvoiceDetails.NameOfUser, dbo.tbl_InvoiceDetails.UserContactNo, dbo.tbl_InvoiceDetails.VehicleNo, dbo.tbl_InvoiceDetails.VehicleType, dbo.tbl_InvoiceDetails.PickLocation, dbo.tbl_InvoiceDetails.DropLocation, dbo.tbl_InvoiceDetails.BasicRent, dbo.tbl_InvoiceDetails.OddTimeCharge,   dbo.tbl_InvoiceDetails.WaitingTimeCharge, dbo.tbl_InvoiceDetails.BasicRent + dbo.tbl_InvoiceDetails.OddTimeCharge + dbo.tbl_InvoiceDetails.WaitingTimeCharge AS Total FROM dbo.tbl_InvoiceDetails INNER JOIN dbo.tbl_InvoiceMaster ON dbo.tbl_InvoiceDetails.InvoiceID = dbo.tbl_InvoiceMaster.InvoiceID WHERE tbl_InvoiceMaster.InvoiceID = '" + lblInvoiceNo.Text.ToString() + "' ", conn);
        SqlDataReader sdr = cmd.ExecuteReader();

        while (sdr.Read())
        {
            int id = sdr.GetInt32(0);
            //string invoiceId = sdr.GetString(1);
            //int orderId = sdr.GetInt32(2);
            string dutyDate = Convert.ToDateTime(sdr.GetDateTime(3).ToString()).ToString("dd/MM/yy");
            string username = sdr.GetString(4);
            string userContactNo = sdr.GetString(5);
            string vehicleNo = sdr.GetString(6);
            string vehicleType = sdr.GetString(7);
            string pick = sdr.GetString(8);
            string drop = sdr.GetString(9);
            double basicRent = sdr.GetDouble(10);
            double oddTimeCharge = sdr.GetDouble(11);
            double waitingTimeCharge = sdr.GetDouble(12);
            double total = sdr.GetDouble(13);

           // htmlstr += "<tr> <th>" + id + "</th> <th>" + dutyDate + "</th><th>" + username + "</th><th>" + userContactNo + "</th>  <th>" + vehicleNo + "</th><th>" + vehicleType + "</th><th>" + pick + "</th><th>" + drop + "</th><th>" + basicRent + "</th><th>" + oddTimeCharge + "</th><th>" + waitingTimeCharge + "</th><th>" + total + "</th> </tr>";
        }

        conn.Close();
        return htmlstr;
    }

    void GrandTotalCount()
    {
        //string strsql1 = "SELECT   InvoiceID   , SUM(BasicRent + OddTimeCharge + WaitingTimeCharge) AS GTotal FROM  tbl_InvoiceDetails  WHERE  (InvoiceID = '" + Application["InvoiceId"].ToString() + "')  GROUP BY InvoiceID  ";
        //Prev
        //string strsql1 = "SELECT   InvoiceID   , SUM(BasicRent + OddTimeCharge + WaitingTimeCharge) AS GTotal, ((SUM(BasicRent + OddTimeCharge + WaitingTimeCharge)*15)/115) AS GovtVat ,SUM((BasicRent + OddTimeCharge + WaitingTimeCharge)+((BasicRent + OddTimeCharge + WaitingTimeCharge)*15)/115) As PayableAmnt  FROM  tbl_InvoiceDetails  WHERE  (InvoiceID = '" + Application["InvoiceId"].ToString() + "')  GROUP BY InvoiceID  ";

        string strsql1 = "SELECT  InvoiceID, SUM(BasicRent + OddTimeCharge + WaitingTimeCharge) AS GTotal, ((SUM(BasicRent + OddTimeCharge + WaitingTimeCharge)*15)/115) AS ExcludeVat, ((SUM(BasicRent + OddTimeCharge + WaitingTimeCharge)*15)/100) AS IncludeVat, SUM((BasicRent + OddTimeCharge + WaitingTimeCharge)+((BasicRent + OddTimeCharge + WaitingTimeCharge)*15)/115) As PayableAmnt   FROM  tbl_InvoiceDetails  WHERE  (InvoiceID = '" + lblInvoiceNo.Text.ToString() + "')  GROUP BY InvoiceID  ";

        conn.Open();
        SqlCommand cmd = new SqlCommand(strsql1, conn);
        SqlDataReader sdr = cmd.ExecuteReader();

        sdr.Read();
        //lblGTotal.Text = sdr["GTotal"].ToString();
        lblInvoiceAmnt.Text = sdr["GTotal"].ToString();
        lblExcludeVat.Text = Convert.ToDouble(sdr["ExcludeVat"].ToString()).ToString("0.00");
        lblIncludeVat.Text = Convert.ToDouble(sdr["IncludeVat"].ToString()).ToString("0.00");
        double TotalAmount = 0;
        if (lblVatText.Text.ToString() == "Exclude VAT")
        {
            lblWithVat.Visible = true;
            lblExcludeVat.Visible = true;
            lblIncludeVat.Visible = false;
            TotalAmount = Convert.ToDouble(lblInvoiceAmnt.Text) - Convert.ToDouble(lblExcludeVat.Text.ToString());
        }
        else if (lblVatText.Text.ToString() == "Include VAT")
        {
            lblExcludeVat.Visible = false;
            lblIncludeVat.Visible = true;
            TotalAmount = Convert.ToDouble(lblInvoiceAmnt.Text) + Convert.ToDouble(lblIncludeVat.Text.ToString());
        }

        lblAmntPay.Text = TotalAmount.ToString("N2");
        lblInWords.Text = NumberToWords(TotalAmount);
        sdr.Close();
        conn.Close();
    }

    public string NumberToWords(double doubleNumber)
    {
        int beforeFloatingPoint = (int)Math.Floor(doubleNumber);
        string beforeFloatingPointWord = string.Format("{0} Taka", NumberToWords(beforeFloatingPoint));
        string afterFloatingPointWord = string.Format("{0} Paisa Only.", SmallNumberToWord((int)((doubleNumber - beforeFloatingPoint) * 100), ""));
        if ((int)((doubleNumber - beforeFloatingPoint) * 100) > 0)
        {
            return string.Format("{0} and {1}", beforeFloatingPointWord, afterFloatingPointWord);
        }
        else
        {
            return string.Format("{0} Only", beforeFloatingPointWord);
        }
    }

    private string NumberToWords(int number)
    {
        if (number == 0)
            return "Zero";

        if (number < 0)
            return "minus " + NumberToWords(Math.Abs(number));

        var words = "";

        if (number / 1000000000 > 0)
        {
            words += NumberToWords(number / 1000000000) + " Billion ";
            number %= 1000000000;
        }

        if (number / 1000000 > 0)
        {
            words += NumberToWords(number / 1000000) + " Million ";
            number %= 1000000;
        }

        if (number / 1000 > 0)
        {
            words += NumberToWords(number / 1000) + " Thousand ";
            number %= 1000;
        }

        if (number / 100 > 0)
        {
            words += NumberToWords(number / 100) + " Hundred ";
            number %= 100;
        }

        words = SmallNumberToWord(number, words);

        return words;
    }

    private string SmallNumberToWord(int number, string words)
    {
        if (number <= 0) return words;
        if (words != "")
            words += " ";

        var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        if (number < 20)
            words += unitsMap[number];
        else
        {
            words += tensMap[number / 10];
            if ((number % 10) > 0)
                words += " " + unitsMap[number % 10];
        }
        return words;
    }
}