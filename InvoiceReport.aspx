<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InvoiceReport.aspx.cs" Inherits="InvoiceReport" %>

<form runat="server" >
    <!DOCTYPE html>
    <html lang="en" xmlns="http://www.w3.org/1999/xhtml" >

    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
        <!-- Meta, title, CSS, favicons, etc. -->
        <meta charset="utf-8"/>
        <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>

        <title>Invoice Report :: Trivia Aviation Ltd</title>

        <!-- Bootstrap core CSS -->

       <%-- <link href="css/bootstrap.min.css" rel="stylesheet"/>
        <link href="css/style.css" rel="stylesheet" media="print" />
        <link href="fonts/css/font-awesome.min.css" rel="stylesheet"/>
        <link href="css/animate.min.css" rel="stylesheet"/>

        <!-- Custom styling plus plugins -->
        <link href="css/custom.css" rel="stylesheet"/>
        <link href="css/icheck/flat/green.css" rel="stylesheet"/> 

        <script src="js/jquery.min.js"></script>--%> 

       <style media="all">
           @font-face {
               font-family:Calibri;
               /*src: url(SourceSansPro-Regular.ttf);*/
           }

           .clearfix:after {
               content: "";
               display: table;
               clear: both;
           }

           a {
               color: #0087C3;
               text-decoration: none;
           }

           body {
               position: relative;
               width: 100%;
               height: 29.7cm;
               margin: 0 auto;
               color: #555555;
               background: #FFFFFF; 
               font-size: 14px;
               font-family: Calibri;
           }

           header {
               padding: 10px 0;
               margin-bottom: 20px;
               border-bottom: 1px solid #AAAAAA;
           }

           #logo {
               float: left;
               margin-top: 8px;
           }

               #logo img {
                   height: 70px;
               }

           #company {
               float: right;
               text-align: right;
           }


           #details {
               margin-bottom: 50px;
           }

           #client {
               padding-left: 6px;
               /*border-left: 6px solid #0087C3;*/
               float: left;
               text-align: center;
           }
            
            #client .to {
                color: #777777;
            }

           h2.name {
               font-size: 1.4em;
               font-weight: normal;
               margin: 0;
           }

           #invoice {
               float: right;
               text-align: center;
           }

               #invoice h1 {
                   color: #0087C3;
                   font-size: 2.4em;
                   line-height: 1em;
                   font-weight: normal;
                   margin: 0 0 10px 0;
               }

               #invoice .date {
                   font-size: 1.1em;
                   color: #777777;
               }

           table {
               /*width: 100%;
               border-collapse: collapse;
               border-spacing: 0;
               margin-bottom: 20px;*/
           }

               table th,
               table td {
                   padding: 5px; 
                   text-align: center;
                   /*border-bottom: 1px solid #FFFFFF;*/
               }

               table th {
                  /* white-space: nowrap;*/
                   font-weight: normal;
               }

               table td {
                   text-align: right;
               }

                table td h3 {
                    color: #57B223;
                    font-size: 1.2em;
                    font-weight: normal;
                    margin: 0 0 0.2em 0;
                }

               table .no {
                   color: #FFFFFF;
                   font-size: 1.6em;
                   background: #57B223;
               }

               table .desc {
                   text-align: left;
               }

               table .unit {
                   background: #DDDDDD;
               }

               table .qty {
               }

               table .total {
                   background: #57B223;
                   color: #FFFFFF;
               }

               table td.unit,
               table td.qty,
               table td.total {
                   font-size: 1.2em;
               }

               table tbody tr:last-child td {
                   border: none;
               }

               table tfoot td {
                   padding: 10px 20px;
                   background: #FFFFFF;
                   border-bottom: none;
                   font-size: 1.2em;
                   white-space: nowrap;
                   border-top: 1px solid #AAAAAA;
               }

               table tfoot tr:first-child td {
                   border-top: none;
               }

               table tfoot tr:last-child td {
                   color: #57B223;
                   font-size: 1.4em;
                   border-top: 1px solid #57B223;
               }

               table tfoot tr td:first-child {
                   border: none;
               }

           
           #notices {
               padding-left: 6px;
               border-left: 6px solid #0087C3;
           }

               #notices .notice {
                   font-size: 1.2em;
               }

           footer {
               color: #777777;
               width: 100%;
               height: 30px;
               position: absolute;
               bottom: 0;
               border-top: 1px solid #AAAAAA;
               padding: 8px 0;
               text-align: center;
           }

        </style>   
    </head>  
    <body>
        <header class="clearfix">
            <div id="logo">
                <img src="images/TriviaLogo.png" />
            </div>
            <div id="company">
                <h2 class="name" style="font-size:30px;font-weight:bolder">
                    Trivia Aviation Ltd <br />
                    <small style="font-size:11px;font-weight:normal;font-family:Consolas">(A concern of Dana Group)</small>
                </h2>
                <div>House# 59, Block – D, Road# 13 & 15, Banani, Dhaka – 1213, Bangladesh</div>
                <div>Office: + 88 02 883 7694 - 6 | Mobile: + 88 0192 991 8222</div>
                <div><a href="http://www.danagrpbd.com/">www.danagrpbd.com</a></div>
            </div>
        </header>

        <main>
            <div id="details" class="clearfix">
                <div id="client">
                    <asp:Label ID="lblVatText" Visible="false" runat="server" Text=""></asp:Label> 
                    <div style="font-size: 20px; font-weight: bold; text-align: left">
                        <asp:Label ID="lblBankName" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div style="text-align: left">
                        <asp:Label ID="lblBankAddress" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div style="font-size: 15px; font-weight: bold; text-align: left">
                        <asp:Label ID="lblManagerName" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div style="text-align: left">
                        <asp:Label ID="lblMngrDesignation" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div style="text-align: left">
                        <asp:Label ID="lblMngrMobileNo" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div style="text-align: left">
                        <asp:Label ID="lblMngrEmail" runat="server" Text="Label"></asp:Label>
                    </div>
                    
                </div>
                <div id="invoice">
                    <div style="font-size: 20px; font-weight: bold; text-align: left">
                        <strong>Invoice No: </strong>
                        <asp:Label ID="lblInvoiceNo" runat="server" Text=" "></asp:Label>
                    </div> 
                    <div style="font-size: 15px; font-weight: bold; text-align: left">
                        <asp:Label ID="lblBankDept" runat="server" Text="Bank Department Name"></asp:Label>
                    </div> 
                    <div style="font-size: 15px; font-weight: bold; text-align: left">
                        <strong>CD A/C # 1401470871001 </strong>
                    </div> 
                    <div style="font-size: 15px; font-weight: bold; text-align: left">
                        <strong>BIN: 000321414-0101 </strong>
                    </div> 
                    <div style="font-size: 15px; font-weight: 400; text-align: left">
                        <strong>Billing Period : </strong>
                        <asp:Label ID="lblfrmDate" runat="server" Text=""></asp:Label>
                        <strong>To </strong>
                        <asp:Label ID="lbltoDate" runat="server" Text=""></asp:Label>
                    </div>
                    <br />
                    <div style="text-align: left">
                         Billing Date :  
                        <asp:Label ID="lblBillingDate" runat="server" Text=" "></asp:Label>
                    </div>
                </div>
            </div>

            <asp:GridView ID="gvInvoiceReport" runat="server" ItemStyle-CssClass="Center" AutoGenerateColumns="False" class="table table-responsive"  OnRowDataBound="OnRowDataBound" CellPadding="4"  Font-Size="12px" Font-Names="calibri" BorderColor="#CCCCCC" ShowFooter="True" Width="100%" ForeColor="#333333" DataKeyNames="ID">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="SL" HeaderStyle-Font-Bold="true" />
                    <asp:BoundField DataField="DutyDate" HeaderText="Duty Date" HeaderStyle-Font-Bold="true" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="NameOfUser" HeaderText="User Name" HeaderStyle-Font-Bold="true"  />
                    <asp:BoundField DataField="UserContactNo" HeaderText="User Contact No" HeaderStyle-Font-Bold="true"  />
                    <asp:BoundField DataField="VehicleNo" HeaderText="Vehicle No" HeaderStyle-Font-Bold="true"  />
                    <asp:BoundField DataField="VehicleType" HeaderText="Vehicle Type" HeaderStyle-Font-Bold="true"  />
                    <asp:BoundField DataField="PickLocation" HeaderText="Pick" HeaderStyle-Font-Bold="true"  />
                    <asp:BoundField DataField="DropLocation" HeaderText="Drop" HeaderStyle-Font-Bold="true"  />
                    <asp:BoundField DataField="BasicRent" HeaderText="Basic Rent" HeaderStyle-Font-Bold="true"  />
                    <%--<asp:BoundField DataField="OddTimeCharge" HeaderText="Odd Time Charge" HeaderStyle-Font-Bold="true"  />
                    <asp:BoundField DataField="WaitingTimeCharge" HeaderText="Waiting Time Charge" HeaderStyle-Font-Bold="true"  /> --%>
                    <asp:TemplateField HeaderText="Odd Time Charge" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" >
                        <ItemTemplate>
                            <asp:Label ID="lblTotalOddTimeCharge" runat="server" Text='<%# Bind("OddTimeCharge", "{0:N2}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Waiting Time Charge" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" >
                        <ItemTemplate>
                            <asp:Label ID="lblWaitingTimeCharge" runat="server" Text='<%# Bind("WaitingTimeCharge", "{0:N2}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Grand Total" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" >
                        <ItemTemplate>
                            <asp:Label ID="lblgrandTotal" runat="server" Text='<%# Bind("total", "{0:N2}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div align="center">No records found.</div>
                </EmptyDataTemplate>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#eaeaea" Font-Bold="True" BorderColor="#CCCCCC" BorderWidth="1px" ForeColor="Black" HorizontalAlign="Right" />
                <HeaderStyle Font-Bold="True" ForeColor="Black" BackColor="#eaeaea" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>

            <table class="table" border="1" cellspacing="0" cellpadding="0" ui-jq="footable" style="font-size: 12px; border-collapse: collapse; border-spacing: 0;margin-bottom: 30px; font-family:Calibri">
               <%-- <thead>
                    <tr style="font-size: 14px; font-weight:bold">
                        <th style="font-weight:bold">SL</th> 
                        <th style="font-weight:bold">Duty Date</th>
                        <th style="font-weight:bold">User Name</th>
                        <th style="font-weight:bold; width:10%">User Contact No</th>
                        <th style="width:10%; font-weight:bold">Vehicle No</th>
                        <th style="font-weight:bold">Vehicle Type</th>
                        <th style="font-weight:bold">Pick</th>
                        <th style="font-weight:bold">Drop</th>
                        <th style="font-weight:bold">Basic Rent</th>
                        <th style="width:6%;font-weight:bold">Odd Time Charge</th>
                        <th style="width:6%;font-weight:bold">Waiting Time Charge</th>
                        <th style="width:5% ;font-weight:bold">Total</th>
                    </tr>
                    <%
                        Response.Write(getData());
                    %>
                </thead>--%>
                <tbody>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="9"></td>
                        <td colspan="2">
                            <strong>Total Invoiced Amount
								<asp:Label ID="lblWithVat" runat="server" Visible="false" Text="With VAT"></asp:Label>
                            </strong>
                        </td>
                        <td>
                            <strong>
                                <asp:Label ID="lblInvoiceAmnt" runat="server" Text="Label"></asp:Label>
                            </strong>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="9"></td>
                        <td colspan="2">
                            <strong>
                                <asp:Label ID="lblVatPercent" runat="server" Text=""></asp:Label>% VAT as per Govt. rules
                            </strong>
                        </td>
                        <td>
                            <strong>
                                <strong>
                                    <asp:Label ID="lblExcludeVat" runat="server" Text=""></asp:Label>
                                </strong>
                                <strong>
                                    <asp:Label ID="lblIncludeVat" runat="server" Text=""></asp:Label>
                                </strong>
                            </strong>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="9"></td>
                        <td colspan="2">
                            <strong>Amount Payable</strong>
                        </td>
                        <td>
                            <strong>
                                <asp:Label ID="lblAmntPay" runat="server" Text="Label"></asp:Label>
                            </strong>
                        </td>
                    </tr>
                    
                </tfoot>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
            </table>



            <div style="margin-bottom: 50px; font-family:Calibri;font-size:17px">
                <strong><u>TAKA IN WORD</u> :
                    <asp:Label ID="lblInWords" runat="server" Text=""></asp:Label>
                </strong>
            </div>

            <div id="notices">
                <div style="font-weight:bolder;font-size: initial;"><u>NOTE:</u></div>
                <div class="notice">
                    <b>As per agreement, Clause No. 7.3</b> -The <b>
                    <asp:Label ID="lblbank" runat="server" Text="Label"></asp:Label>
                    </b>shall pay the claim of Trivia within <b>10(Ten) working days</b> by crediting to the designated account of Trivia Aviation Ltd.
                </div>
            </div>

            <div id="details" class="clearfix" style="margin-top: 80px">
                <div id="client">
                    <p style="padding-bottom: 24px;"><u>Prepared By</u></p>
                    <b style="font-size: 12px;">Pronay Serao</b>
                    <p style="padding: 0; margin: 0;font-size: 12px;">
                        Executive 
                    </p>
                </div>
                <div id="client" style="margin-left: 250px;">
                    <p style="padding-bottom: 24px;"><u>Chceked By</u></p>
                    <b style="font-size: 12px;">MD. Mahabub Hossain</b>
                    <p style="padding: 0; margin: 0;font-size: 12px;">
                        Deputy Manager
                    </p>
                </div>
                <div id="invoice">
                    <p style="padding-bottom: 24px;"><u>Signed By</u></p>
                    <b style="font-size: 12px;">MD. Kamrul Hasan</b>
                    <p style="padding: 0; margin: 0;font-size: 12px;">
                        General Manager
                    </p> 
                </div> 
            </div>
             
        </main>
        <footer>
            <div style="font-style: italic; margin-top: 20px; font-size: x-small; color: darkgray; text-align: Center;">[This is automatically genered report by software]</div>
        </footer>
    </body>

    </html>
 </form>
