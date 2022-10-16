<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="AddInvoice.aspx.cs" Inherits="AddInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <%--<link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.9/css/dataTables.bootstrap.min.css" />--%>
    <link type="text/css" rel="stylesheet" href="css/dataTables.bootstrap.min.css" />
    <%--<link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />--%>
    <link type="text/css" rel="stylesheet" href="css/bootstrap.min.css" />
    <%--<link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/responsive/1.0.7/css/responsive.bootstrap.min.css" />--%>
    <link type="text/css" rel="stylesheet" href="css/responsive.bootstrap.min.css" />

    <%--<script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/responsive/1.0.7/js/dataTables.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/dataTables.bootstrap.min.js"></script>--%>


    <script type="text/javascript" src="js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="js/dataTables.responsive.min.js"></script>
    <script type="text/javascript" src="js/dataTables.bootstrap.min.js"></script>


    <!-- testing  -->
    <link type="text/css" rel="stylesheet" href="css/buttons.dataTables.min.css" />
    <script type="text/javascript" src="js/dataTables.buttons.min.js"></script>
    <script type="text/javascript" src="js/buttons.flash.min.js"></script>
    <script type="text/javascript" src="js/jszip.min.js"></script>
    <script type="text/javascript" src="js/pdfmake.min.js"></script>
    <script type="text/javascript" src="js/vfs_fonts.js"></script>
    <script type="text/javascript" src="js/buttons.html5.min.js"></script>
    <script type="text/javascript" src="js/buttons.print.min.js"></script>
    <!-- end test -->

     <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7/jquery.min.js" type="text/javascript"></script>
          
    <script type="text/javascript">
        //$(function () {
        //    $.fn.DataTable.ext.errMode = 'none';
        //    $('[id*=gvInvoice]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
        //        "responsive": true,
        //        "sPaginationType": "full_numbers",
        //        "dom": "Bfrtip",
        //        "buttons": [
        //            'copy', 'csv', 'excel', 'pdf', 'print'
        //        ]
        //    });
        //});

          
    </script>


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <div class="row">
             <div class="col-lg-12">
            <section class="panel">
                <div style="border-bottom: 2px solid #E6E9ED; padding: 5px 5px 6px; margin-bottom: 10px; margin-left: 10px;">
                    <h4>Add Invoice Information  <small>Summary</small> </h4>
                </div>
                <br>
                <div class="panel-body">
                    <div class="form-horizontal">
                        <div class="form-group ">
                            <label for="username" class="control-label col-lg-3 no-padding-right">Bank Name : </label>
                            <div class="col-lg-6">
                                <asp:DropDownList ID="cmbBankName" class="form-control m-bot15" runat="server" AutoPostBack="true"></asp:DropDownList>
                                </div>
                        </div>
                        <div class="form-group" style="text-align: center">
                            <label class="col-sm-3 control-label no-padding-right" runat="server" for="form-field-1-1" style="font-weight: 600">From Date : </label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtFromDate" class=" form-control" runat="server" TextMode="Date" AutoPostBack="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group" style="text-align: center">
                            <label class="col-sm-3 control-label no-padding-right" runat="server" for="form-field-1-1" style="font-weight: 600">To Date : </label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtToDate" class=" form-control" runat="server" TextMode="Date" AutoPostBack="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-offset-3 col-lg-6">
                            <div style="text-align: left;">
                                <div class="messagealert" id="alert_container"></div>
                                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-info" OnClick="btnSearch_Click" Text="Search" />
                            </div>
                        </div>  
                    </div>
                </div> 
                <br />
                <div class="col-lg-12" >
                    <section class="panel" id="inputSection"  <%--visibility: hidden--%>>
                        <header class="panel" > 
                             <asp:Label ID="lblHeader" class="control-label col-lg-12" style="padding:5px 0 ;text-transform:uppercase; font-size:15px ; text-align:center; font-weight:bold; background-color:lightgray" visible="false" runat="server" Text="Add payment manager details"></asp:Label>
                        </header>
                            <div class="col-lg-5"> 
                                <div class="panel-body">
                                    <div class="form-horizontal">
                                        <div class="form-group ">
                                            <asp:Label ID="lblManagerName" class="control-label col-lg-4" visible="false" runat="server" Text="Manager Name :"></asp:Label>
                                            <div class="col-lg-7">
                                                <asp:TextBox ID="txtManagerName" class=" form-control" visible="false" runat="server"  ></asp:TextBox>
                                            </div>
                                        </div> 
                                        <div class="form-group ">
                                            <asp:Label ID="lblMngDesignation" class="control-label col-lg-4" visible="false" runat="server" Text="Designation :"></asp:Label>
                                            <div class="col-lg-7">
                                                <asp:TextBox ID="txtMngDesignation" class=" form-control" visible="false"  runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-4"> 
                                <div class="panel-body">
                                    <div class="form-horizontal">
                                        <div class="form-group ">
                                            <asp:Label ID="lblMobileNo" class="control-label col-lg-5" visible="false" runat="server" Text="Mobile No :"></asp:Label>
                                            <div class="col-lg-7">
                                                <asp:TextBox ID="txtMngMobileNo" class=" form-control" visible="false" runat="server"  ></asp:TextBox>
                                            </div>
                                        </div> 
                                        <div class="form-group ">
                                            <asp:Label ID="lblEmail" class="control-label col-lg-5" visible="false" runat="server" Text="Email :"></asp:Label>
                                            <div class="col-lg-7">
                                                <asp:TextBox ID="txtMngEmail" class=" form-control" visible="false" textmode="Email"  runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="panel-body">
                                    <div class="form-horizontal">
                                        <asp:Label ID="lblVat"  style="text-align:left; font-weight:bold "  visible="false" runat="server" Text="*Select Vat Type--"></asp:Label>
                                        <br />
                                        <div>
                                            <asp:CheckBoxList ID="checkVat" runat="server" Visible="false" AutoPostBack="True" TextAlign="Right"  Width="432px">
                                                <asp:ListItem style="font-weight:normal">Include VAT</asp:ListItem>  
                                                <asp:ListItem style="font-weight:normal">Exclude VAT</asp:ListItem>  
                                            </asp:CheckBoxList>  
                                        </div>
                                         <div class="form-group ">
                                            <asp:Label ID="lblVatPercent" class="control-label col-lg-5"  visible="false" runat="server" Text="VAT% :" style="text-align:left; font-weight:bold "></asp:Label>
                                            <div class="col-lg-5">
                                                <asp:TextBox ID="txtVat" class=" form-control" visible="false"  runat="server" style="margin-left: -40px;" ></asp:TextBox>
                                            </div>
                                        </div>
                                     </div>
                                </div>
                            </div>
                    </section>
                </div>
                <br />
                 
                <asp:Label ID="lblNote" runat="server" Visible="false" Text="As per agreement, Clause No. 7.3-The Bank shall pay the claim of Trivia within 10(Ten) working days by crediting to the designated account of Trivia Aviation Ltd" ></asp:Label>
                <%--<asp:Label ID="lblVatPercent" runat="server" Visible="false" Text="15%" ></asp:Label>--%>

                <div class="table-responsive">
                    <div class="position-left ">
                        <div class="text-left">
                            <div class="col-sm-12">
                                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                                <asp:GridView ID="gvInvoice" runat="server" OnRowDeleting="OnRowDeleting" AutoGenerateColumns="False" class="table table-striped table-bordered table-responsive dataTable no-footer" Width="100%" border="1px solid #ddd" BorderWidth="1px" CellPadding="0" Font-Names="Calibri" Font-Size="Small" OnRowEditing="OnRowEditing" DataKeyNames="ID">
                                   <Columns>
                                        <asp:TemplateField >
                                            <HeaderTemplate>
                                                <ContentTemplate>
                                                    <asp:CheckBox ID="chkAll" runat="server" class="form-control" OnCheckedChanged="chkAll_CheckedChanged" AutoPostBack="True" />
                                                </ContentTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox id="chkLTA" runat="server" class=" form-control" ></asp:CheckBox> 
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Id">
                                            <ItemTemplate> 
                                                <asp:Label ID="lblBankDutyId" runat="server" Text='<%# Bind("Id") %>'></asp:Label> 
                                                <asp:Label ID="lblServiceDate" Visible="false" runat="server" Text='<%# Bind("ServiceDate") %>'></asp:Label>
                                                <asp:Label ID="lblUsername" Visible="false" runat="server" Text='<%# Bind("Username") %>'></asp:Label>
                                                <asp:Label ID="lblUserContactNo" Visible="false" runat="server" Text='<%# Bind("ContactNo") %>'></asp:Label>
                                                <asp:Label ID="lblRegiNo" Visible="false" runat="server" Text='<%# Bind("RegiNo") %>'></asp:Label>
                                                <asp:Label ID="lblVType" Visible="false" runat="server" Text='<%# Bind("VType") %>'></asp:Label>
                                                <asp:Label ID="lblRate" Visible="false" runat="server" Text='<%# Bind("Rate") %>'></asp:Label>
                                                <asp:Label ID="lblRoute" Visible="false" runat="server" Text='<%# Bind("RouteId") %>'></asp:Label>
                                                <%--<asp:Label ID="lblBankName" runat="server" Text='<%# Bind("Bank") %>'></asp:Label>--%>
                                                <asp:Label ID="lblOddTimeRate" Visible="false" runat="server" Text='<%# Bind("OddTimeRate") %>'></asp:Label>
                                                <asp:Label ID="lblWChargePerMin" Visible="false" runat="server" Text='<%# Bind("WChargePerMin") %>'></asp:Label>
                                                <asp:Label ID="lblReportingTime" Visible="false" runat="server" Text='<%# Bind("ReportingTime") %>'></asp:Label>
                                                <asp:Label ID="lblPickTime" Visible="false" runat="server" Text='<%# Bind("PickTime") %>'></asp:Label>
                                                <asp:Label ID="lblWaitingTimeCharge" Visible="false" runat="server" Text='<%# Bind("WaitingTimeCharge") %>'></asp:Label>
                                                <asp:Label ID="lblPickLocation" Visible="false" runat="server" Text='<%# Bind("PickLocation") %>'></asp:Label> 
                                                <asp:Label ID="lblDropLocation" Visible="false" runat="server" Text='<%# Bind("DropLocation") %>'></asp:Label>
                                                <asp:Label ID="lblBankShortName" runat="server" Visible="false" Text='<%# Bind("shortBankName") %>' ></asp:Label> 
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <%--<asp:BoundField DataField="Id" HeaderText="Order ID" ><ItemStyle Width="5%"></ItemStyle></asp:BoundField>--%>
                                       <asp:BoundField DataField="ServiceDate" HeaderText="Duty Date" ><ItemStyle Width="8%"></ItemStyle></asp:BoundField>
                                       <asp:BoundField DataField="Bank" HeaderText="Bank Name" ><ItemStyle Width="10%"></ItemStyle></asp:BoundField>
                                       <asp:BoundField DataField="Username" HeaderText="User Name" ><ItemStyle Width="13%"></ItemStyle></asp:BoundField>
                                       <asp:BoundField DataField="ContactNo" HeaderText="User Contact No" />
                                       <asp:BoundField DataField="RegiNo" HeaderText="Vehicle No" />
                                       <asp:BoundField DataField="VType" HeaderText="Vehicle Type" />
                                       <asp:BoundField DataField="Rate" HeaderText="Basic Rent" />
                                       <asp:BoundField DataField="Route" HeaderText="Duty Route" ><ItemStyle Width="12%"></ItemStyle></asp:BoundField>
                                       <asp:BoundField DataField="OddTimeRate" HeaderText="Odd Time Charge" ><ItemStyle Width="5%"></ItemStyle></asp:BoundField>
                                       <asp:BoundField DataField="WChargePerMin" HeaderText="Waiting Time Charge Per Min" ><ItemStyle Width="8%"></ItemStyle></asp:BoundField>
                                       <asp:BoundField DataField="ReportingTime" HeaderText="Reporting Time" ><ItemStyle Width="8%"></ItemStyle></asp:BoundField>
                                       <asp:BoundField DataField="PickTime" HeaderText="Pick Time" ><ItemStyle Width="8%"></ItemStyle></asp:BoundField>
                                       <asp:BoundField DataField="WaitingTimeCharge" HeaderText="Waiting Time Charge" /> 
                                    </Columns>
                                </asp:GridView>
                            </div> 
                        </div>
                    </div>
                </div>
                <div class="form-group" >
                    <div class="col-sm-12">
                        <div style="text-align: right;">
                            <div class="messagealert" id="alert_container"></div>
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Visible="false" OnClick="btnSave_Click" Text="Save Invoice" />
                        </div>
                    </div>
                </div>
            </section>
        </div>
      </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%--<link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css"/>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>--%>

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("[id*=checkVat]").click(function () {
                if ($(this).is(":checked")) {
                    $(this).closest("tr").find("input[type=checkbox]").not(this).removeAttr("checked");
                } else {
                    $(this).closest("tr").find("input[type=checkbox]").not(this).attr('checked', 'checked');
                }
            });
        });
    </script>

</asp:Content>

