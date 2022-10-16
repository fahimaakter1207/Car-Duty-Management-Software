<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="AddVehicleType.aspx.cs" Inherits="AddVehicleType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form role="form">
    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">

         <div class="page-content">


             <div class="page-header">
                 <h1>Vehicle Type
					<small>
                        <i class="ace-icon fa fa-angle-double-right"></i>

                    </small>
                 </h1>
             </div>
             <!-- /.page-header -->

             <div class="row">
                 <div class="col-xs-12">
                     <!-- PAGE CONTENT BEGINS -->
                     <div class="form-horizontal">
                          

                         <div class="form-group">
                             <asp:Label ID="Label9" class="control-label col-sm-3" runat="server" Text="Name :"></asp:Label>
                             <div class="col-sm-6">
                                 <asp:TextBox ID="txtName" class=" form-control" runat="server" required="required" placeholder=""></asp:TextBox>
                             </div>
                         </div>

                         <div class="form-group">
                             <asp:Label ID="Label10" class="control-label col-sm-3" runat="server" Text="Remarks :"></asp:Label>
                             <div class="col-sm-6">
                                 <asp:TextBox ID="txtRemarks" class=" form-control" runat="server" TextMode="MultiLine" required=" " placeholder=""></asp:TextBox>
                             </div>
                         </div>


                         <asp:Button ID="btnSave" runat="server" CssClass="btn btn-info" OnClick="btnSave_Click" Text="Save "  />

<%--                         <div class="clearfix form-actions">
                             <div class="col-md-offset-3 col-md-9">
                                 <div class="messagealert" id="alert_container"></div>
                                 <asp:Button ID="btnSave" runat="server" CssClass="btn btn-info" OnClick="btnSave_Click" Text="Save " />
                                 

                             </div>
                         </div>--%>

                     </div>
                 </div>
                 <!-- /.col -->
             </div>
             <!-- /.row -->
         </div>
          


     </div>
                </form>
</asp:Content>

