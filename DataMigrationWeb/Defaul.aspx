<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Defaul.aspx.cs" Inherits="DataMigrationWeb.Defaul" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="Js/bootstrap.min.js"></script>
    <title></title>
</head>
<body>
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-sm-10">
                <!-- Header -->
                <div class="row border-bottom white-bg">
                    <div class="col-sm-4">
                        <h2>Data Migration Tool</h2>
                        <ol class="breadcrumb">
                            <strong>Data Migration Tool</strong>
                        </ol>
                    </div>
                </div>
                <br />
                <!-- Content -->
                <div class="row" style="border: solid 1px;border-radius: 10px; border-color:gainsboro">
                    <div class="col-lg-12">
                        <form id="form1" runat="server" class="row g-3">
                            <div class="row">
                                <div class="col-lg-12">
                                    <asp:Label 
                                        runat="server" 
                                        CssClass="control-label" 
                                        Text="Destination Table">
                                    </asp:Label>
                                    <br />
                                    <asp:TextBox 
                                        ID="txtTabla"
                                        runat="server"
                                        CssClass="form-control form-control-lg">
                                    </asp:TextBox>
                                    <br /><br />
                                </div>
                                <div class="col-lg-12">
                                    <asp:Label 
                                        runat="server" 
                                        CssClass="control-label" 
                                        Text="Origin query">
                                    </asp:Label>
                                    <br />
                                    <asp:TextBox 
                                        ID="txtOriginQuery"
                                        runat="server"
                                        TextMode="MultiLine"
                                        CssClass="form-control form-control-lg"
                                        Rows="5">
                                    </asp:TextBox>

                                    <br /><br />
                                </div>
                                <div class="d-grid gap-2 col-5 mx-auto">
                                    <asp:Button 
                                        ID="btnMigrate"
                                        runat="server"
                                        Text="Start Migration"
                                        CssClass="btn btn-success"
                                        OnClick="btnMigrate_Click" />
                                </div>
                            </div>
                            <br /><br />
                            <asp:Label 
                                ID="lblStatus"
                                runat="server">
                            </asp:Label>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
