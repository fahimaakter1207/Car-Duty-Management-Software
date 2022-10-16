<%@ Page Title="" Language="C#" MasterPageFile="~/Bank.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

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

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <div class="row">
        <div class="col-lg-12">
            <section class="panel">
                <header class="panel-heading">
                    Change Password
                        <span class="tools pull-right">
                            <a class="fa fa-chevron-down" href="javascript:;"></a>
                            <a class="fa fa-cog" href="javascript:;"></a>
                            <a class="fa fa-times" href="javascript:;"></a>
                        </span>
                </header>
                <br>
                <div class="panel-body">
                    <div class="cmxform form-horizontal">

                        <div class="form-group ">
                            <label for="firstname" class="control-label col-lg-3">Old Password :</label>
                            <div class="col-lg-4">
                                <asp:TextBox ID="txtOldPass" class=" form-control" runat="server" TextMode="Password"  >
                                </asp:TextBox> 
                            </div>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="txtOldPass" ErrorMessage="Please Enter Old Password!" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                           
                        </div>
                        <div class="form-group ">
                            <label for="lastname" class="control-label col-lg-3">New Password :</label>
                            <div class="col-lg-4">
                                <asp:TextBox ID="txtNewPass" class=" form-control" TextMode="Password" runat="server" ></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="txtNewPass" ErrorMessage="Please Enter New Password!" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group ">
                            <label for="lastname" class="control-label col-lg-3">Confirm New Password :</label>
                            <div class="col-lg-4">
                                <asp:TextBox ID="txtConfirmpass" class=" form-control" TextMode="Password" runat="server" ></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                ControlToValidate="txtConfirmpass" ErrorMessage="Please Enter Confirm  Password!" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-offset-3 col-lg-6">
                            <asp:CompareValidator ID="CompareValidator1" runat="server"
                                ControlToCompare="txtNewPass" ControlToValidate="txtConfirmpass" ErrorMessage="New Password and Confirm Password Not Matched" ForeColor="Red" >
                            </asp:CompareValidator>
                        </div> 


                        <div class="form-group">
                            <div class="col-lg-offset-3 col-lg-6">
                                <div style="text-align: left;">
                                    <div class="messagealert" id="alert_container"></div>
                                    <asp:Button ID="btnChangePass" runat="server" CssClass="btn btn-success" OnClick="btnChangePass_Click" Text="Change Password" />
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-offset-3 col-lg-6">
                        <asp:Label ID="lblmsg" Font-Bold="True"  ForeColor="Green" runat="server" Text=""></asp:Label><br />  
                        </div>
                     </div>
                </div>

            </section>
        </div>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">
        $(function () {
            $("#toggle_pwd").click(function () {
                $(this).toggleClass("fa-eye fa-eye-slash");
                var type = $(this).hasClass("fa-eye-slash") ? "text" : "password";
                $("#txtPassword").attr("type", type);
            });
        });
    </script>

</asp:Content>

