<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
                            Add User Information
                            <span class="tools pull-right">
                                <a class="fa fa-chevron-down" href="javascript:;"></a>
                                <a class="fa fa-cog" href="javascript:;"></a>
                                <a class="fa fa-times" href="javascript:;"></a>
                            </span>
                        </header>
                        <br>

                        <div class="panel-body">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label   class="col-sm-3 control-label no-padding-right">User Name :</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtUserName" class=" form-control" runat="server"  placeholder="Enter User Name"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1-1">Password : </label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtPassword" class=" form-control" TextMode="Password" runat="server"  ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group ">
                                    <label for="username" class="control-label col-lg-3 no-padding-right">Access Name : </label>
                                    <div class="col-lg-6">
                                        <asp:DropDownList ID="cmbAccess" class="chosen-select form-control" runat="server" required="required">
                                            <asp:ListItem Selected="True" Value="0" Text="Select Access Name"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Administrator"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Client Admin"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Users"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="Report User"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="Workshop"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="Clients Operator"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="Accounts Operator"></asp:ListItem>
                                            <asp:ListItem Value="8" Text="STCL"></asp:ListItem>
                                            <asp:ListItem Value="9" Text="Report User For DEIL"></asp:ListItem>
                                            <asp:ListItem Value="10" Text="Report User For SEL"></asp:ListItem>
                                            <asp:ListItem Value="11" Text="Report User For Germents"></asp:ListItem>
                                            <asp:ListItem Value="12" Text="Report User For DPCL"></asp:ListItem>
                                            <asp:ListItem Value="13" Text="Report User For STCL3D"></asp:ListItem>
                                            <asp:ListItem Value="14" Text="Low Level Admin"></asp:ListItem>
                                        </asp:DropDownList>

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
        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>


