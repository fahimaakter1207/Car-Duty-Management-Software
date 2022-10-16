<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="AddAssetsInformation.aspx.cs" Inherits="AddAssetsInformation" %>

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

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-lg-6">
                    <section class="panel">
                            <header class="panel-heading">
                                Add Assets Information
                                <span class="tools pull-right">
                                    <%--<a class="fa fa-chevron-down" href="javascript:;"></a>
                                    <a class="fa fa-cog" href="javascript:;"></a>
                                    <a class="fa fa-times" href="javascript:;"></a>--%>
                                 </span>
                            </header>
                                    <div class="panel-body">
                                        <div class="cmxform form-horizontal">
                                            <div class="form-group ">
                                                <%--<label for="username" class="control-label col-lg-3">Product Category :</label>--%>
                                                <asp:Label ID="lblProductCat" class="control-label col-lg-4" runat="server" Text="Product Category :"></asp:Label>
                                                <div class="col-lg-7">
                                                    <asp:DropDownList ID="cmbProduct" class="form-control m-bot15" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbProduct_SelectedIndexChanged"></asp:DropDownList></td>
                                                </div>
                                            </div>
                                            <div class="form-group ">
                                                <%--<label for="firstname" class="control-label col-lg-3">Assets Code :</label>--%>
                                                <asp:Label ID="lblAssetsCode" class="control-label col-lg-4" runat="server" Text="Assets Code :"></asp:Label>
                                                <div class="col-lg-7">
                                                    <asp:TextBox  ID="txtAssetsCode" class=" form-control"   runat="server" required="required" placeholder="Enter company name......."></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group ">
                                                <%--<label for="firstname" class="control-label col-lg-3">Assets Name :</label>--%>
                                                <asp:Label ID="lblAssetsName" class="control-label col-lg-4" runat="server" Text="Assets Name :"></asp:Label>
                                                <div class="col-lg-7">
                                                    <asp:TextBox  ID="txtAssetsName" class=" form-control"   runat="server" required="required" placeholder="Enter company name......."></asp:TextBox>
                                                </div>
                                            </div>
                                            
                                            <div class="form-group ">
                                                <%--<label for="firstname" class="control-label col-lg-3">Serial Number :</label>--%>
                                                <asp:Label ID="lblSerialNumber" class="control-label col-lg-4" runat="server" Text="Serial Number :"></asp:Label>
                                                <div class="col-lg-7">
                                                    <asp:TextBox  ID="txtSerialNummber" class=" form-control"   runat="server" required="required" placeholder="Enter company name......."></asp:TextBox>
                                                </div>
                                            </div>
                                        
                                            <div class="form-group ">
                                                <%--<label for="firstname" class="control-label col-lg-3">Brand Name :</label>--%>
                                                <asp:Label ID="lblBrandName" class="control-label col-lg-4" runat="server" Text="Brand Name :"></asp:Label>
                                                <div class="col-lg-7">
                                                    <asp:TextBox  ID="txtBrandName" class=" form-control" required="required"  runat="server" ></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group ">
                                                <%--<label for="firstname" class="control-label col-lg-3">Description :</label>--%>
                                                <asp:Label ID="lblDescription" class="control-label col-lg-4" runat="server" Text="Description :"></asp:Label>
                                                <div class="col-lg-7">
                                                    <asp:TextBox  ID="txtDescription" class=" form-control" TextMode="MultiLine"  runat="server" ></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group ">
                                                <%--<label for="firstname" class="control-label col-lg-3">Warranty :</label>--%>
                                                <asp:Label ID="lblWarranty" class="control-label col-lg-4" runat="server" Text="Warranty :"></asp:Label>
                                                <div class="col-lg-7">
                                                    <asp:TextBox  ID="txtWarranty" class=" form-control"   runat="server" required="required" ></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group ">
                                                <%--<label for="firstname" class="control-label col-lg-3" id="lblType">Type :</label>--%>
                                                <asp:Label ID="lblType" class="control-label col-lg-4" runat="server" Text="Printer Type :"></asp:Label>
                                                <div class="col-lg-7">
                                                    <asp:TextBox  ID="txtType" class=" form-control"   runat="server"  ></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group ">
                                                <%--<label for="firstname" class="control-label col-lg-3" id="lblTonerModel">Toner Model :</label>--%>
                                                <asp:Label ID="lblTonerModel" class="control-label col-lg-4" runat="server" Text="Toner Model :"></asp:Label>
                                                <div class="col-lg-7">
                                                    <asp:TextBox  ID="txtTonerModel" class=" form-control"   runat="server"  ></asp:TextBox>
                                                </div>
                                            </div>
                                            
                                        
                                        
                                        
                                        

                                        </div>
                                    </div>
                                   
                    </section>
                </div>
                <div class="col-lg-6">
                    <section class="panel">
                            <header class="panel-heading">
                                Add Purchase Information
                                <%--<span class="tools pull-right">
                                    <a class="fa fa-chevron-down" href="javascript:;"></a>
                                    <a class="fa fa-cog" href="javascript:;"></a>
                                    <a class="fa fa-times" href="javascript:;"></a>
                                 </span>--%>
                            </header>
                                    <div class="panel-body">
                                        <div class="cmxform form-horizontal">
                                            <div class="form-group ">
                                                <%--<label for="firstname" class="control-label col-lg-3">Invoice No :</label>--%>
                                                <asp:Label ID="lblInvoiceNo" class="control-label col-lg-4" runat="server" Text="Invoice No :"></asp:Label>
                                                <div class="col-lg-7">
                                                    <asp:TextBox  ID="txtInvoiceNo" class=" form-control"   runat="server" required="required" placeholder="Enter company name......."></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group ">
                                                <%--<label for="firstname" class="control-label col-lg-3">Invoice Date :</label>--%>
                                                <asp:Label ID="lblInvoiceDate" class="control-label col-lg-4" runat="server" Text="Invoice Date :"></asp:Label>
                                                <div class="col-lg-7">
                                                    <asp:TextBox  ID="txtInvoiceDate" class=" form-control"  type="date"  runat="server" required="required" placeholder="Enter company name......."></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group ">
                                                <%--<label for="firstname" class="control-label col-lg-3">Purchase Date :</label>--%>
                                                <asp:Label ID="lblPurchaseDate" class="control-label col-lg-4" runat="server" Text="Purchase Date :"></asp:Label>
                                                <div class="col-lg-7">
                                                    <asp:TextBox  ID="txtPurchaseDate" class=" form-control" type="date"  runat="server" required="required" placeholder="Enter company name......."></asp:TextBox>
                                                </div>
                                            </div>
                                        
                                            <div class="form-group ">
                                                <%--<label for="firstname" class="control-label col-lg-3">Purchase Price :</label>--%>
                                                <asp:Label ID="lblPurchasePrice" class="control-label col-lg-4" runat="server" Text="Purchase Price :"></asp:Label>
                                                <div class="col-lg-7">
                                                    <asp:TextBox  ID="txtPurchasePrice" class=" form-control" required="required" type="number"  runat="server" ></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group ">
                                                <label for="username" class="control-label col-lg-4">Vendor Name :</label>
                                                <div class="col-lg-7">
                                                    <asp:DropDownList ID="cmbVendor" class="form-control m-bot15" runat="server" required="required"></asp:DropDownList></td>
                                                </div>
                                            </div>
                                        
                                        
                                        
                                            
                                        </div>
                                    </div>
                                   
                    </section>
                </div>
                <div class="col-lg-6">
                    <section class="panel">
                            <header class="panel-heading">
                                Add License Information
                                <%--<span class="tools pull-right">
                                    <a class="fa fa-chevron-down" href="javascript:;"></a>
                                    <a class="fa fa-cog" href="javascript:;"></a>
                                    <a class="fa fa-times" href="javascript:;"></a>
                                 </span>--%>
                            </header>
                            <div class="panel-body">
                                    <div class="cmxform form-horizontal">
                                            <div class="form-group ">
                                                <%--<label for="firstname" class="control-label col-lg-3" id="lblLiType">License Type :</label>--%>
                                                <asp:Label ID="lblLiType" class="control-label col-lg-4" runat="server" Text="License Type :"></asp:Label>
                                                <div class="col-lg-7">
                                                    <asp:TextBox  ID="txtLType" class=" form-control" runat="server"  ></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group ">
                                                <%--<label for="firstname" class="control-label col-lg-3" id="lblLKey">License Key :</label>--%>
                                                <asp:Label ID="lblLKey" class="control-label col-lg-4" runat="server" Text="License Key :"></asp:Label>
                                                <div class="col-lg-7">
                                                    <asp:TextBox  ID="txtLKey" class=" form-control"  runat="server" ></asp:TextBox>
                                                </div>
                                            </div>
                                    </div>
                            </div>
                    </section>
                </div>

                <div class="col-lg-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div class="cmxform form-horizontal">
                                            <div class="form-group">
                                                <div class="col-lg-offset-5 col-lg-6">
                                                
                                                    <div style=" text-align:left;">
                                                        <div class="messagealert" id="alert_container"></div>
                                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" OnClick="btnSave_Click" Text="Save Information" />
                                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" OnClick="btnCancel_Click" Text="Cancel" />
                                                    
                                                    </div>
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

