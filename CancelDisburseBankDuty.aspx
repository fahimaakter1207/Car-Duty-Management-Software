<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="CancelDisburseBankDuty.aspx.cs" Inherits="CancelDisburseBankDuty" %>

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

    <script src ="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    
    <script type="text/javascript" src="js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="js/dataTables.responsive.min.js"></script>
    <script type="text/javascript" src="js/dataTables.bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css">
     

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
    
    <script type="text/javascript">
        //$(function () {
        //    $.fn.DataTable.ext.errMode = 'none';
        //    $('[id*=gvCompany]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
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
                    <h4>Cancel Disburse Bank Duty <small>Summary</small>
                    </h4>
                </div>
                <div class="panel-body">
                    <div class="form-horizontal">
                        <div class="form-group ">
                            <label for="username" class="control-label col-lg-3 no-padding-right">Bank Name : </label>
                            <div class="col-lg-6">
                                <asp:DropDownList ID="cmbBankName" class="form-control m-bot15" runat="server" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group" style="text-align:center" >
                            <label class="col-sm-3 control-label no-padding-right" runat="server"  for="form-field-1-1" style="font-weight:600">From Date : </label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtFromDate" class=" form-control" runat="server" textmode="Date" Autopostback="true" ></asp:TextBox>
                            </div>
                        </div>
                         <div class="form-group" style="text-align:center" >
                            <label class="col-sm-3 control-label no-padding-right" runat="server"  for="form-field-1-1" style="font-weight:600">To Date : </label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtToDate" class=" form-control" runat="server" textmode="Date"  Autopostback="true"  ></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-offset-3 col-lg-6">
                            <div style="text-align: left;">
                                <div class="messagealert" id="alert_container"></div>
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-info"  OnClick="btnSearch_Click" Text="Search" />
                            </div>
                        </div>
                    </div>
                </div>
                <br>
                <div class="table-responsive">
                    <div class="position-left ">
                        <div class="text-left">
                            <div class="col-sm-12">
                                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                                <asp:GridView ID="gvCompany" runat="server"  OnRowDataBound="OnRowDataBound" OnRowDeleting="OnRowDeleting" AutoGenerateColumns="False" class="table table-striped table-bordered table-responsive dataTable no-footer" Width="100%" border="1px solid #ddd" BorderWidth="1px" CellPadding="0" Font-Names="Calibri" Font-Size="Small" OnRowEditing="OnRowEditing" DataKeyNames="Id">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Id">
                                            <ItemTemplate  >
                                                <asp:Label ID="lblId"  runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="OrderDate" HeaderText="Order Date" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="ServiceDate" HeaderText="Duty Date" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="ReportingTime" HeaderText="Duty Time" />
                                        <asp:BoundField DataField="ServiceID" HeaderText="Service ID" />
                                        <asp:BoundField DataField="Username" HeaderText="Bank User Name" ItemStyle-Width="15%"><ItemStyle Width="20%"></ItemStyle></asp:BoundField>
                                        <asp:BoundField DataField="BName" HeaderText="Bank Name" />
                                        <asp:BoundField DataField="RegiNo" HeaderText="Vehicle No" />
                                        <asp:BoundField DataField="DName" HeaderText="Driver Name" />
                                       <asp:TemplateField>
                                           <ItemTemplate>
                                               <asp:Button ID="btnCancelDuty" class="btn btn-info" runat="server" Text="Cancel Duty" OnClick="btnCancel_Click" />
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <%-- </ContentTemplate>
                                </asp:UpdatePanel>--%>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">
        $(".chosen-search").chosen();
    </script>

</asp:Content>

