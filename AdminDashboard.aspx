<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminDashboard.aspx.cs" Inherits="AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<%--row start--%>
		<div class="row">
			<div class="panel-body">
				<div class="col-md-12 w3ls-graph">
					<!--agileinfo-grap-->
						<div class="agileinfo-grap">
							<div class="agileits-box">
								<header class="agileits-box-header clearfix">
									<h3>Trivia Aviation Limited</h3>
										<div class="toolbar">
										</div>
								</header>
								<div class="agileits-box-body clearfix">
									<div id="hero-area"></div>
								</div>
							</div>
						</div>
	<!--//agileinfo-grap-->
				</div>
			</div>
		</div>
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


    <div class="row">
        <div class="col-lg-12">
            <section class="panel">
                <div style="border-bottom: 2px solid #E6E9ED; padding: 5px 5px 6px; margin-bottom: 10px; margin-left: 10px;">
                    <h4><small></small>
                    </h4>
                </div>
                <br>
                <div class="table-responsive">
                    <div class="position-left ">
                        <div class="text-left">
                              
                       <%-- <div class="col-sm-12">
                                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                                <asp:GridView ID="gvCompany" runat="server"  OnRowDataBound="OnRowDataBound" OnRowDeleting="OnRowDeleting" AutoGenerateColumns="False" class="table table-striped table-bordered table-responsive dataTable no-footer" Width="100%" border="1px solid #ddd" BorderWidth="1px" CellPadding="0" Font-Names="Calibri" Font-Size="Small" OnRowEditing="OnRowEditing" DataKeyNames="Id">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Id">
                                            <ItemTemplate  >
                                                <asp:Label ID="lblId"  runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                                <asp:Label ID="lblBankName" Visible="false" runat="server" Text='<%# Bind("BName") %>'></asp:Label>
                                                <asp:Label ID="lblBankDepartment" Visible="false"  runat="server" Text='<%# Bind("BankDepartment") %>'></asp:Label>
                                                <asp:Label ID="lblUserEmail" Visible="false" runat="server" Text='<%# Bind("UserEmail") %>'></asp:Label>
                                                <asp:Label ID="lblRMEmail" runat="server" Visible="false" Text='<%# Bind("RMEmail") %>'></asp:Label>
                                                <asp:Label ID="lblServiceReleted" runat="server" Visible="false" Text='<%# Bind("serviceReletedEmail") %>'></asp:Label>
                                                <asp:Label ID="lblServiceDate"  runat="server" Visible="false" Text='<%# Bind("ServiceDate") %>'></asp:Label>
                                                <%--<asp:Label ID="lblVehicleNo" Visible="false" runat="server" Text='<%# Bind("RegiNo") %>'></asp:Label>
                                                <asp:Label ID="lblVehicleBrand" Visible="false" runat="server" Text='<%# Bind("Brand") %>'></asp:Label>
                                                <asp:Label ID="lblDriverName" runat="server" Visible="false" Text='<%# Bind("empname") %>'></asp:Label>
                                                <asp:Label ID="lblDriverCellNo" runat="server" Visible="false" Text='<%# Bind("mobileno") %>'></asp:Label>
                                                <asp:Label ID="lblUserName" runat="server" Visible="false" Text='<%# Bind("Username") %>'></asp:Label>
                                                <asp:Label ID="lblUserContact"  runat="server" Visible="false" Text='<%# Bind("ContactNo") %>'></asp:Label>
                                                <asp:Label ID="lblReportingPlace" Visible="false" runat="server" Text='<%# Bind("ReportingPlace") %>'></asp:Label>
                                                <asp:Label ID="lblReportingTime" runat="server" Visible="false" Text='<%# Bind("ReportingTime") %>'></asp:Label>
                                                <asp:Label ID="lblDropAddress" runat="server" Visible="false" Text='<%# Bind("DropAddress") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="OrderDate" HeaderText="Order Date" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="ServiceDate" HeaderText="Duty Date" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="ReportingTime" HeaderText="Duty Time" />
                                        <asp:BoundField DataField="ServiceID" HeaderText="Service ID" />
                                        <asp:BoundField DataField="Username" HeaderText="Bank User Name" ItemStyle-Width="20%">
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Vehicle No">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="cmbVehicleNo" class="form-control m-bot15 chosen-search " runat="server"></asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Driver Name" >
                                            <ItemTemplate>
                                                <asp:DropDownList ID="cmbDriverName"   class="form-control m-bot15 chosen-search " runat="server"    ></asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnDutyDisburce" class="btn btn-success" runat="server" Text="Disburse Duty" OnClick="MyButtonClick" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         
                                    </Columns>
                                </asp:GridView>

                            </div>--%>
                            

                            <%-- </ContentTemplate>
                                </asp:UpdatePanel>--%>
                        </div>
                        
                    </div>
                </div>
            </section>
        </div>
    </div>


    <script type="text/javascript">
        $(".chosen-search").chosen();
    </script>

</asp:Content>

