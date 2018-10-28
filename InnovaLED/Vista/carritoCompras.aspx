<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="carritoCompras.aspx.vb" Inherits="Vista.carritoCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-primary class">
                    <div class="panel-heading text-center">
                        <asp:Label ID="Lblpanelcarrito" runat="server" Text="MARKET" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                    </div>
                </div>
            </div>
        </div>


<%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>


        <div class="row">
            <div id="ID_Catalogo" runat="server" class="col-md-12">
            </div>

        </div>
        <br />
        <div class="row">
            <div class="col-md-5">
                
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:Label ID="Lblformapago" runat="server" Text="FORMA DE PAGO:" CssClass="control-label labelform"></asp:Label>
                                <div class="input-group col-md-12">
                                    <asp:DropDownList ID="ddl_FormaPago" runat="server" CssClass="form-control" AutoPostBack="true">
                                       <%-- <asp:ListItem Text="Efectivo" Value="1"></asp:ListItem>--%>
                                        <asp:ListItem Text="Tarjeta de Crédito" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Nota de Crédito" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="tarjetaCredito" runat="server" visible="false">
                         <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="Lbltarjetacred" runat="server" Text="TIPO DE TARJETA:" CssClass="control-label labelform"></asp:Label>
                                    <div class="input-group">
                                         <asp:DropDownList ID="lsttipotarj" runat="server" CssClass="form-control" AutoPostBack="true">
                                        <asp:ListItem Text="Visa" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="MasterCard" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Amex" Value="3"></asp:ListItem>  
                                        </asp:DropDownList>                                                                              
                                    </div>                                   
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="row" id="divvisa" runat="server" visible="false">
                              <asp:Image ID="imgvisa" runat="server" ImageUrl="~/IMAGENES/visa.png" CssClass="img-responsive" />
                                    </div>
                                <div class="row" id="divmaster" runat="server" visible="false">
                                <asp:Image ID="imgmastercard" runat="server" ImageUrl="~/IMAGENES/mastercard.png" CssClass="img-responsive"  />
                                    </div>
                                <div class="row" id="divamex" runat="server" visible="false">
                                <asp:Image ID="imgamex" runat="server" ImageUrl="~/IMAGENES/amex.png" CssClass="img-responsive"  />
                                </div>
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
                        <div class="row">
                             <div class="row col-md-3 col-md-offset-1">
                               <asp:button ID="btn_aceptar" runat="server" Text="Confirmar" class="btn btn-success btn-lg" visible="false"></asp:button>
                              </div>
                              <div class="row col-md-3 col-md-offset-3">
                               <asp:button ID="btn_cancelar" runat="server" Text="Cancelar" class="btn btn-warning btn-lg" visible="false"></asp:button>
                             </div>

                        </div>
           
            </div>
            <div class="col-md-5 col-md-offset-1">
         <div class="form-group">
                                <asp:Label ID="lblSponsors" runat="server" Text="Sponsors:" CssClass=" col-sm-4 control-label labelform"></asp:Label>
                                <br />
                                <br />
                                <div class="col-md-12">
                                    <asp:GridView CssClass="table table-hover table-bordered table-responsive table-success " ID="gv_sponsors" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="5" OnPageIndexChanging="gv_sponsors_PageIndexChanging" RowStyle-Height="40px">
                                        <HeaderStyle CssClass="thead-dark" />
                                        <PagerTemplate>
                                            <div class="col-md-4 text-left">
                                                <asp:Label ID="lblmostrarpag" runat="server" Text="Mostrar Pagina"></asp:Label>
                                                <asp:DropDownList ID="ddlPaging" runat="server" AutoPostBack="true" CssClass="margenPaginacion" OnSelectedIndexChanged="ddlPaging_SelectedIndexChanged" />
                                                <asp:Label ID="lblde" runat="server" Text="de"></asp:Label>
                                                <asp:Label ID="lbltotalpages" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-md-6 col-md-offset-2">
                                                <asp:Label ID="lblMostrar" runat="server" Text="Mostrar"></asp:Label>
                                                <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" CssClass="margenPaginacion" OnSelectedIndexChanged="ddlPageSize_SelectedPageSizeChanged">
                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                    <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                                    <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label ID="lblRegistrosPag" runat="server" Text="Registros por Pagina"></asp:Label>
                                            </div>
                                        </PagerTemplate>
                                        <Columns>
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                            <asp:BoundField DataField="CUIL" HeaderText="CUIL" />
                                            <asp:BoundField DataField="Correo" HeaderText="Correo" />
                                            <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:ImageButton ID="btn_Seleccionar" runat="server" CommandName="S" ImageUrl="~/Imagenes/check.png" Height="18px" />
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Width="100px"></HeaderStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
            
            </div>


        </div>
    <br />
    <br />


    </div>

  <%--  </ContentTemplate>
   </asp:UpdatePanel> --%>
</asp:Content>
