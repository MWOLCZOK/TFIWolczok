<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="GestionarFacturas.aspx.vb" Inherits="Vista.GestionarFacturas" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- <script type="text/javascript" src="JS/ClienteValid.js"></script>-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <br />
        <div id="alertvalid" runat="server" name="alertvalid" class="alert alert-danger  text-center" visible="false">
            <label runat="server" id="textovalid" class="text-danger"></label>
        </div>
        <div id="success" runat="server" name="success" class="alert alert-success  text-center" visible="false">
            <label id="lblsuccessmodUser" class="text-success">La Factura se actualizó correctamente.</label>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-primary class">
                    <div class="panel-heading text-center">
                        <asp:Label ID="lblGestionFacturas" runat="server" Text="Gestión de Facturas" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                    </div>
                </div>
            </div>

            <br />
            <br />
            <div class="form-horizontal has-success col-md-12">
                <div class="form-group">

                    <%-- Sección Grid  --%>

                    <div class="col-md-12">
                        <asp:GridView CssClass="table table-hover table-bordered table-responsive table-active text-center " ID="gv_facturas" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="10" OnPageIndexChanging="gv_facturas_PageIndexChanging" RowStyle-Height="40px">
                            <HeaderStyle CssClass="thead-dark" />
                            <PagerTemplate>
                                <div class="col-md-4 text-left">
                                    <asp:Label ID="lblmostrarpag" runat="server" Text="Mostrar Pagina"></asp:Label>
                                    <asp:DropDownList ID="ddlPaging" runat="server" AutoPostBack="true" CssClass="margenPaginacion" OnSelectedIndexChanged="ddlPaging_SelectedIndexChanged" />
                                    <asp:Label ID="lblde" runat="server" Text="de"></asp:Label>
                                    <asp:Label ID="lbltotalpages" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-md-4 col-md-offset-4">
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
                                <asp:BoundField DataField="ID" HeaderText="Numero" />
                                <asp:BoundField DataField="Cliente.NombreUsu" HeaderText="Cliente" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                <asp:BoundField DataField="MontoTotal" HeaderText="Monto " DataFormatString="{0:C1}"/>
                                <asp:BoundField DataField="EstadoCompra" HeaderText="Estado de Compra" />
                                <asp:BoundField DataField="EstadoEnvio" HeaderText="Estado de Envio" />
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

                    


                    <%-- Sección Tabla Estado Compra  --%>

                    <div id="respuesta" runat="server" class="form-horizontal has-success col-md-12 ">
                        <div class="form-group">
                            <asp:Label ID="lblestadocompra" runat="server" Text="Estado Compra:" CssClass="col-sm-3 control-label labelform"></asp:Label>
                            <div class="col-md-7">
                                <div class="input-group">
                                    <asp:DropDownList ID="lstestadocompra" runat="server" CssClass="form-control" AutoPostBack="true" DataValueField="EstadoCompraEntidad" DataTextField="EstadoCompraEntidad"></asp:DropDownList>
                                    <span class="input-group-addon" id="basic-addon10"><span class="glyphicon glyphicon-asterisk" aria-hidden="true"></span></span>
                                </div>

                            </div>
                        </div>
                            <div id="envio" runat="server" class="form-group">
                            <asp:Label ID="lblestadoenvio" runat="server" Text="Estado Envio:" CssClass="col-sm-3 control-label labelform"></asp:Label>
                            <div class="col-md-7">
                                <div class="input-group">
                                    <asp:DropDownList ID="lstestadoenvio" runat="server" CssClass="form-control" AutoPostBack="true" DataValueField="EstadoEnvio" DataTextField="EstadoEnvio"></asp:DropDownList>
                                    <span class="input-group-addon" id="basic-addon11"><span class="glyphicon glyphicon-asterisk" aria-hidden="true"></span></span>
                                </div>

                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4 col-md-offset-4">
                                <asp:Button ClientIDMode="Static" ID="btnmodificar" name="btnmodificar" runat="server" Text="Modificar" CssClass="btn btn-lg btn-block btn-warning" />
                            </div>
                        </div>
                    </div>


                    
                    <%-- Sección Facturas por Cancelar --%>

                    <%--     <div class="col-md-12">
                        <asp:GridView CssClass="table table-hover table-bordered table-responsive table-success " ID="GridView1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="10" OnPageIndexChanging="gv_facturas_PageIndexChanging" RowStyle-Height="40px">
                            <HeaderStyle CssClass="thead-dark" />
                            <PagerTemplate>
                                <div class="col-md-4 text-left">
                                    <asp:Label ID="lblmostrarpag" runat="server" Text="Mostrar Pagina"></asp:Label>
                                    <asp:DropDownList ID="ddlPaging" runat="server" AutoPostBack="true" CssClass="margenPaginacion" OnSelectedIndexChanged="ddlPaging_SelectedIndexChanged" />
                                    <asp:Label ID="lblde" runat="server" Text="de"></asp:Label>
                                    <asp:Label ID="lbltotalpages" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-md-4 col-md-offset-4">
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
                                <asp:BoundField DataField="ID" HeaderText="Numero" />
                                <asp:BoundField DataField="Cliente.NombreUsu" HeaderText="Cliente" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                <asp:BoundField DataField="MontoTotal" HeaderText="Monto" />
                                <asp:BoundField DataField="EstadoCompra" HeaderText="Estado Compra" />
                                <asp:BoundField DataField="EstadoEnvio" HeaderText="Estado Envio" />
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
                    </div>--%>




                </div>
            </div>
            <br />
        </div>
    </div>



    <asp:HiddenField ID="id_usuario" runat="server" />

</asp:Content>
