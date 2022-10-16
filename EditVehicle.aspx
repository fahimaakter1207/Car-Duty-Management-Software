<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="EditVehicle.aspx.cs" Inherits="EditVehicle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="row">
        <div class="col-lg-12">
            <section class="panel">
                <header class="panel-heading">
                    Edit Vehicle Information
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
                            <label for="firstname" class="control-label col-lg-3">Vehicle Name :</label>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtVehicleName" class=" form-control" runat="server" required="required" placeholder="Enter Vehicle Name"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group ">
                            <label for="lastname" class="control-label col-lg-3">Remarks :</label>
                            <div class="col-lg-6">
                                <asp:TextBox class=" form-control" ID="txtRemarks" runat="server" TextMode="MultiLine" required="required"></asp:TextBox>
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

</asp:Content>


