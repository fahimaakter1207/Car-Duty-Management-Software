<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="EditBankDutyUser.aspx.cs" Inherits="EditBankDutyUser" %>

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
                Edit Bank Duty User Information
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
                        <label for="username form-field-1-1" class="col-sm-3 control-label no-padding-right">Name :</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtName" class=" form-control" runat="server" required="required" placeholder=" "></asp:TextBox>
                            <asp:TextBox ID="txtUN" class=" form-control" runat="server" required="required" placeholder="" Visible="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="username form-field-1-1" class="col-sm-3 control-label no-padding-right">Contact No :</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtContact" class=" form-control" runat="server" required="required" placeholder=" "></asp:TextBox>
                            <asp:TextBox ID="txtPN" class=" form-control" runat="server" required="required" placeholder="" Visible="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="username form-field-1-1" class="col-sm-3 control-label no-padding-right">Email :</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtUserEmail" class=" form-control" runat="server" TextMode="Email" required="required" placeholder=" "></asp:TextBox>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

