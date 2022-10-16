<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="EditAssetsInformation.aspx.cs" Inherits="EditAssetsInformation" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

    <div class="row">
            <div class="col-lg-12">
                <section class="panel">
                        <header class="panel-heading">
                            Edit Assets Information
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
                                            <label for="username" class="control-label col-lg-3">Product Category :</label>
                                            <div class="col-lg-6">
                                                <asp:DropDownList ID="cmbProduct" class="form-control m-bot15" runat="server" ></asp:DropDownList></td>
                                            </div>
                                        </div>
                                        <div class="form-group ">
                                            <label for="firstname" class="control-label col-lg-3">Assets Code :</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox  ID="txtAssetsCode" class=" form-control"   runat="server" required="required" placeholder="Enter company name......."></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group ">
                                            <label for="firstname" class="control-label col-lg-3">Assets Name :</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox  ID="txtAssetsName" class=" form-control"   runat="server" required="required" placeholder="Enter company name......."></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group ">
                                            <label for="firstname" class="control-label col-lg-3">Invoice No :</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox  ID="txtInvoiceNo" class=" form-control"   runat="server" required="required" placeholder="Enter company name......."></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group ">
                                            <label for="firstname" class="control-label col-lg-3">Invoice Date :</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox  ID="txtInvoiceDate" class=" form-control" runat="server" required="required" ></asp:TextBox><span style="font-size:small; font-weight:bold;">(mm/dd/yyyy)</span>
                                            </div>
                                        </div>
                                        <div class="form-group ">
                                            <label for="firstname" class="control-label col-lg-3">Purchase Date :</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox  ID="txtPurchaseDate" class=" form-control"  runat="server" required="required" ></asp:TextBox><span style="font-size:small; font-weight:bold;">(mm/dd/yyyy)</span>
                                            </div>
                                        </div>
                                        
                                        <div class="form-group ">
                                            <label for="firstname" class="control-label col-lg-3">Purchase Price :</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox  ID="txtPurchasePrice" class=" form-control" required="required" type="number"  runat="server" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group ">
                                            <label for="firstname" class="control-label col-lg-3">Serial Number :</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox  ID="txtSerialNummber" class=" form-control"   runat="server" required="required" placeholder="Enter company name......."></asp:TextBox>
                                            </div>
                                        </div>
                                        
                                        <div class="form-group ">
                                            <label for="firstname" class="control-label col-lg-3">Brand Name :</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox  ID="txtBrandName" class=" form-control" required="required"  runat="server" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group ">
                                            <label for="firstname" class="control-label col-lg-3">Description :</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox  ID="txtDescription" class=" form-control" TextMode="MultiLine"  runat="server" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group ">
                                            <label for="firstname" class="control-label col-lg-3">Warranty :</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox  ID="txtWarranty" class=" form-control"   runat="server" required="required" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group ">
                                            <label for="firstname" class="control-label col-lg-3">License Type :</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox  ID="txtLType" class=" form-control" runat="server"  ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group ">
                                            <label for="firstname" class="control-label col-lg-3">License Key :</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox  ID="txtLKey" class=" form-control"  runat="server" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group ">
                                            <label for="firstname" class="control-label col-lg-3">Type :</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox  ID="txtType" class=" form-control"   runat="server"  ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group ">
                                            <label for="firstname" class="control-label col-lg-3">Toner Model :</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox  ID="txtTonerModel" class=" form-control"   runat="server"  ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group ">
                                            <label for="username" class="control-label col-lg-3">Vendor Name :</label>
                                            <div class="col-lg-6">
                                                <asp:DropDownList ID="cmbVendor" class="form-control m-bot15" runat="server" required="required"></asp:DropDownList></td>
                                            </div>
                                        </div>
                                        <div class="form-group ">
                                            <label for="username" class="control-label col-lg-3">Status :</label>
                                            <div class="col-lg-6">
                                                <asp:DropDownList ID="cmbStatus" class="form-control m-bot15" runat="server" >
                                                    <asp:ListItem>Active</asp:ListItem>
                                                    <asp:ListItem>Inactive</asp:ListItem>
                                                    <asp:ListItem>In Stock</asp:ListItem>
                                                    <asp:ListItem>Out of Use</asp:ListItem>
                                                    <asp:ListItem>Scrapped</asp:ListItem>
                                                </asp:DropDownList></td>
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

