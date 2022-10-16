<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="AddBankDutyUser.aspx.cs" Inherits="AddBankDutyUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	<style type="text/css">
        .messagealert {
            width: 40%;
            position: fixed;
            top:10px;
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
                            Add Bank Duty User Information
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
										 
										<label for="username form-field-1-1" class="col-sm-3 control-label no-padding-right">User Name :</label>

										<div class="col-sm-6">
											<asp:TextBox  ID="txtUsername" class=" form-control"   runat="server"   placeholder=" "></asp:TextBox>
                                         
										</div>
									</div>
                                    <div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-1-1"> Email : </label>

										<div class="col-sm-6">
											<asp:TextBox  ID="txtEmail" class=" form-control" TextMode="Email"  runat="server" ></asp:TextBox> 
										</div>
									</div>
                                    <div class="form-group">
										 
										<label for="username form-field-1-1" class="col-sm-3 control-label no-padding-right">Contact No :</label>

										<div class="col-sm-6">
											<asp:TextBox  ID="txtContactNo" class=" form-control"   runat="server"  placeholder=" "></asp:TextBox>
                                         
										</div>
									</div>
                                    <div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-1-1"> Address : </label>

										<div class="col-sm-6">
											<asp:TextBox  ID="txtAddress" class=" form-control"   runat="server"  ></asp:TextBox> 
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

