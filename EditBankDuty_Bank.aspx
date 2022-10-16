<%@ Page Title="" Language="C#" MasterPageFile="~/Bank.master" AutoEventWireup="true" CodeFile="EditBankDuty_Bank.aspx.cs" Inherits="EditBankDuty_Bank" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/themes/smoothness/jquery-ui.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>
    <script src ="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css">

    <div class="row">
        <div class="col-lg-12">
            <section class="panel">
                <header class="panel-heading">
                    Edit Bank Duty Information
                        <span class="tools pull-right">
                            <a class="fa fa-chevron-down" href="javascript:;"></a>
                            <a class="fa fa-cog" href="javascript:;"></a>
                            <a class="fa fa-times" href="javascript:;"></a>
                        </span>
                </header>
                <br>

                <div class="panel-body">
                    <div class="form-horizontal">

                        <div class="form-group" runat="server">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1-1">Service ID : </label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtServiceId" class=" form-control"  runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1-1">Order Date : </label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtOrderDate" class=" form-control" runat="server"></asp:TextBox>(mm/dd/yyyy)
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1-1">Service Date : </label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtServiceDate" class=" form-control" runat="server" ></asp:TextBox>  (mm/dd/yyyy)
                            </div>
                        </div>
                        <div class="form-group ">
                            <label for="username" class="control-label col-lg-3 no-padding-right">Bank User Name : </label>
                            <div class="col-lg-6">
                                <asp:DropDownList ID="cmbUsername" class="form-control m-bot15 chosen-search " runat="server" OnSelectedIndexChanged="cmbUsername_SelectedIndexChanged" EnableFilterSearch="true" FilterType="StartsWith" EnableServerFiltering="true" AutoPostBack="true">
                                </asp:DropDownList>

                            </div>
                        </div>

                        <%--========================================================================--%>
                       <%-- <div id="newUser" visible="false" runat="server" style="background-color: aliceblue; padding: 11px 11px 11px 11px; width: 50%; margin-left: 260px;">
                            <div class="form-group">
                                <label for="username form-field-1-1" class="col-sm-3 control-label no-padding-right">Name :</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtName" class=" form-control" runat="server" required="required" placeholder=" "></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="username form-field-1-1" class="col-sm-3 control-label no-padding-right">Contact No :</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtContact" class=" form-control" runat="server" required="required" placeholder=" "></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="username form-field-1-1" class="col-sm-3 control-label no-padding-right">Email :</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtUserEmail" class=" form-control" runat="server" TextMode="Email" required="required" placeholder=" "></asp:TextBox>
                                </div>
                            </div>
                            <div class="clearfix form-actions">
                                <div class="col-md-offset-3 col-md-9">
                                    <div class="messagealert" id="alert_container1"></div>
                                    <asp:Button ID="txtAddUser" runat="server" CssClass="btn btn-success" OnClick="btnSaveUser_Click" Text="Add New User" />
                                </div>
                            </div>
                        </div>--%>

                        <%--=========================================================================--%>


                        <div class="form-group">
                            <label for="username form-field-1-1" class="col-sm-3 control-label no-padding-right">Contact No :</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtContactNo" class=" form-control" runat="server" placeholder=" "></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="username form-field-1-1" class="col-sm-3 control-label no-padding-right">Email :</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtEmail" class=" form-control" runat="server" TextMode="Email" placeholder=" "></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="username form-field-1-1" class="col-sm-3 control-label no-padding-right">Reporting Place :</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtReportingPlace" class=" form-control" runat="server" placeholder="" OnTextChanged="txtReportingPlace_SelectedTextChanged" AutoPostBack="true"></asp:TextBox>
                            </div>
                        </div>

                        <%--=======================================================--%>

                        <div id="divFlightDetails" style="/*background-color: #c8def1; */ padding: 11px 11px 11px 11px; width: 100%; margin-left: 260px;" runat="server" visible="false">
                            <h4 style="color: seagreen">Flight Details</h4>
                            <div class="form-group">
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtFlight" class=" form-control" runat="server" TextMode="MultiLine" BackColor="#339966" ForeColor="White" placeholder=" "></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <%--=======================================================--%>

                        <div class="form-group">
                            <label for="username form-field-1-1" class="col-sm-3 control-label no-padding-right">Reporting Time :</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtReportingTime" class=" form-control" runat="server" TextMode="Time" placeholder=" "></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="username form-field-1-1" class="col-sm-3 control-label no-padding-right">Drop Address :</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtDropAddress" class=" form-control" runat="server" TextMode="Multiline" placeholder=" "></asp:TextBox>
                            </div>
                        </div>
                       <%-- <div class="form-group ">
                            <label for="username" class="control-label col-lg-3 no-padding-right">Vehicle No : </label>
                            <div class="col-lg-6">
                                <asp:DropDownList ID="cmbVehicleNo" class="form-control m-bot15 chosen-search " runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group ">
                            <label for="username" class="control-label col-lg-3 no-padding-right">Driver Name : </label>
                            <div class="col-lg-6">
                                <asp:DropDownList ID="cmbDriverName" class="form-control m-bot15 chosen-search " runat="server" >
                                </asp:DropDownList>
                            </div>
                        </div>--%>
                        <div class="form-group ">
                            <label for="username" class="control-label col-lg-3 no-padding-right">Bank Name : </label>
                            <div class="col-lg-6">
                                <asp:DropDownList ID="cmbBankName" class="form-control m-bot15 chosen-search " runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbBankName_SelectedIndexChanged" AppendDataBoundItems="true" EnableFilterSearch="true" FilterType="StartsWith" EnableServerFiltering="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group ">
                            <label for=" " class="control-label col-lg-3 no-padding-right">Bank Department Name : </label>
                            <div class="col-lg-6">
                                <asp:DropDownList ID="cmbBankDept" class="chosen-select form-control chosen-search" runat="server">
                                    <asp:ListItem Selected="True" Value="0" Text="Select Bank Department Name"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="General"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Priorty Clients"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Valued Card Holder"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="Privilege Banking Customer"></asp:ListItem>
                                    <asp:ListItem Value="5" Text="Women Banking Department"></asp:ListItem>
                                    <asp:ListItem Value="6" Text="Priorty Banking"></asp:ListItem>
                                    <asp:ListItem Value="7" Text="Card Holder Customer"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group ">
                            <label for="username" class="control-label col-lg-3 no-padding-right">RM : </label>
                            <div class="col-lg-6">
                                <asp:DropDownList ID="cmbRM" class="form-control m-bot15 chosen-search " runat="server" >
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-lg-offset-3 col-lg-6">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-success" OnClick="btnUpdate_Click" Text="Update" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" OnClick="btnCancel_Click" Text="Cancel" />
                            </div>
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


