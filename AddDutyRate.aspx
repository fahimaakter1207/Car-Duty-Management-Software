<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="AddDutyRate.aspx.cs" Inherits="AddDutyRate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/themes/smoothness/jquery-ui.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>
    <script src ="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css">

    <style type="text/css">
        .messagealert {
            width: 40%;
            position: fixed;
            top: 10px;
            z-index: 100000;
            padding: 0;
            font-size: 15px;
        }
    </style>
    <script type="text/javascript">
        function ShowMessage(message, messagetype) {
            var cssclass;
            switch (messagetype) {
                case 'Success':
                    cssclass = 'alert-success'
                    break;
                case 'Error':
                    cssclass = 'alert-danger'
                    break;
                case 'Warning':
                    cssclass = 'alert-warning'
                    break;
                default:
                    cssclass = 'alert-info'
            }
            $('#alert_container').append('<div id="alert_div" style="-webkit-box-shadow: 3px 4px 6px #999; " class="alert fade in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');
        }
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            Add Bank Duty Rate Information
                            <span class="tools pull-right">
                                <a class="fa fa-chevron-down" href="javascript:;"></a>
                                <a class="fa fa-cog" href="javascript:;"></a>
                                <a class="fa fa-times" href="javascript:;"></a>
                            </span>
                        </header>
                        <br>

                        <div class="panel-body">
                            <div class="form-horizontal">

                                <div class="form-group ">
                                    <label for="username" class="control-label col-lg-3 no-padding-right">Bank Name : </label>
                                    <div class="col-lg-6">
                                        <asp:DropDownList ID="cmbBankName" class="form-control m-bot15 chosen-search " runat="server"   ></asp:DropDownList>
                                    </div>
                                </div>
                                 <div class="form-group ">
                                    <label for=" " class="control-label col-lg-3 no-padding-right">Vehicle Type : </label>
                                    <div class="col-lg-6">
                                        <asp:DropDownList ID="cmbVehicleType" class="chosen-select form-control chosen-search " runat="server"  >
                                            <asp:ListItem Selected="True" Value="0" Text="Select Vehicle Type---"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Sedan"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Suv"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="MPV"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="username form-field-1-1" class="col-sm-3 control-label no-padding-right">Route :</label>
                                    <div class="col-lg-6">
                                        <asp:DropDownList ID="cmbRoute" class="form-control m-bot15 chosen-search " runat="server" ></asp:DropDownList>
                                    </div>
                                </div>
                                 
                                <div class="form-group">
                                    <label for="username form-field-1-1" class="col-sm-3 control-label no-padding-right">Rate :</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtRate" class=" form-control" runat="server"   ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1-1">Waiting Charge Per Min : </label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtWChargePerMin" class=" form-control" runat="server" ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1-1">Govt. Holiday Charge : </label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtGHCharge" class=" form-control" runat="server" ></asp:TextBox>
                                    </div>
                                </div>

                                <%--<div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1-1">Waiting Count Time : </label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtWCTime" class=" form-control" runat="server"   ></asp:TextBox>
                                    </div>
                                </div>--%>

                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1-1">Odd Time Start: </label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtOddTimeStart" class=" form-control" Textmode="Time" runat="server"  ></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="username form-field-1-1" class="col-sm-3 control-label no-padding-right">Odd Time End:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtOddTimeEnd" class=" form-control" Textmode="Time" runat="server" ></asp:TextBox>
                                    </div>
                                </div>

                                 <div class="form-group">
                                    <label for="username form-field-1-1" class="col-sm-3 control-label no-padding-right">Odd Time Rate:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtOddTimeRate" class=" form-control" runat="server" ></asp:TextBox>
                                    </div>
                                </div>

                                <div class="clearfix form-actions">
                                    <div class="col-md-offset-3 col-md-9">
                                        <div class="messagealert" id="alert_container"></div>
                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" OnClick="btnSave_Click" Text="Save" />
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-info" OnClick="btnCancel_Click" Text="Cancel" />  
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

        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>

