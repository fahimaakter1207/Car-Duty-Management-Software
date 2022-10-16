<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="EditAssignAssets.aspx.cs" Inherits="EditAssignAssets" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

    <div class="row">
            <div class="col-lg-12">
                <section class="panel">
                        <header class="panel-heading">
                            Edit Assign Assets Information
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
                                            <label for="username" class="control-label col-lg-3">Assets Name :</label>
                                            <div class="col-lg-6">
                                                <asp:DropDownList ID="cmbAssets" class="form-control m-bot15" runat="server" ></asp:DropDownList></td>
                                            </div>
                                        </div>
                                        <div class="form-group ">
                                            <label for="username" class="control-label col-lg-3">Employee Name :</label>
                                            <div class="col-lg-6">
                                                <asp:DropDownList ID="cmbEmployee" class="form-control m-bot15" runat="server" required="required"></asp:DropDownList></td>
                                            </div>
                                        </div>
                                        
                                        <div class="form-group ">
                                            <label for="firstname" class="control-label col-lg-3">Delivery Date :</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox  ID="txtDeliveryDate" class=" form-control"   runat="server" required="required"></asp:TextBox><span style="font-size:small; font-weight:bold;">(mm/dd/yyyy)</span>
                                            </div>
                                        </div>
                                        <div class="form-group ">
                                            <label for="firstname" class="control-label col-lg-3">Remarks :</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox  ID="txtRemarks" class=" form-control" TextMode="MultiLine"  runat="server" ></asp:TextBox>
                                            </div>
                                        </div>
                                        
                                        <div class="form-group ">
                                            <label for="agree" class="control-label col-lg-3 col-sm-3">Re-assign :</label>
                                            <div class="col-lg-6 col-sm-9">
                                                <asp:CheckBox ID="chkReassign" type="checkbox" style="width: 20px"  class="checkbox form-control"  runat="server" Text="" />
                                            </div>
                                        </div>
                                        
                                        <%-- <div class="form-group ">
                                            <label for="username" class="control-label col-lg-3">Status :</label>
                                            <div class="col-lg-6">
                                                <asp:DropDownList ID="cmbStatus" class="form-control m-bot15" runat="server" >
                                                    <asp:ListItem>Active</asp:ListItem>
                                                    <asp:ListItem>Inactive</asp:ListItem>
                                                    <asp:ListItem>In Stock</asp:ListItem>
                                                    <asp:ListItem>Out of Use</asp:ListItem>
                                                    <asp:ListItem>Scrapped</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div> --%>
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

