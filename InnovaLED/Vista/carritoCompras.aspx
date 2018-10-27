<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="carritoCompras.aspx.vb" Inherits="Vista.carritoCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-primary class">
                    <div class="panel-heading text-center">
                        <asp:Label ID="lblPanelModUser" runat="server" Text="Carrito de Compras" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div id="ID_Catalogo" runat="server" class="col-md-12">
            </div>

        </div>
        <br />
        <div class="row">
            <div class="col-md-5">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:Label ID="lblidiomaname" runat="server" Text="FORMA DE PAGO:" CssClass="control-label labelform"></asp:Label>
                                <div class="input-group col-md-12">
                                    <asp:DropDownList ID="lstFormaPAgo" runat="server" CssClass="form-control" AutoPostBack="true">
                                        <asp:ListItem Text="Efectivo" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Tarjeta de Crédito" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Nota de Crédito" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="tarjetaCredito" runat="server" visible="false">
                        <div class="row">
                            <div class="col-md-6 col-md-offset-3">
                                <asp:Image ID="credit" runat="server" ImageUrl="~/IMAGENES/tarjetas.png" CssClass="img-responsive" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="NUMERO TARJETA:" CssClass="control-label labelform"></asp:Label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtnrotarjeta" runat="server" placeholder="N° de Tarjeta" CssClass="form-control"></asp:TextBox>
                                        <span class="input-group-addon"><i class="fa fa-credit-card"></i></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server" Text="NOMBRE Y APELLIDO:" CssClass="control-label labelform"></asp:Label>
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox2" runat="server" placeholder="Apellido y Nombre" CssClass="form-control"></asp:TextBox>
                                        <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" Text="FECHA EXPIRACIÓN:" CssClass="control-label labelform"></asp:Label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtexpiracion" runat="server" placeholder="MM/AAAA" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group  pull-right">
                                    <asp:Label ID="Label3" runat="server" Text="CÓDIGO DE SEGURIDAD:" CssClass="control-label labelform"></asp:Label>
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox1" runat="server" placeholder="CVC" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
