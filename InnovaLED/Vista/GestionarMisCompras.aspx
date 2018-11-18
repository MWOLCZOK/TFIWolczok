<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="GestionarMisCompras.aspx.vb" Inherits="Vista.GestionMisCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid fondoGris" >
        <br />
        <div id="alertvalid" runat="server" name="alertvalid" class="alert alert-danger  text-center" visible="false">
            <label runat="server" id="textovalid" class="text-danger"></label>
        </div>
        <div id="success" runat="server" name="success" class="alert alert-success  text-center" visible="false">
            <label id="lblsuccessmodUser" class="text-success"></label>
        </div>

<div class="row">
  <div class="col-md-12">
     <div class="panel panel-primary class">
       <div class="panel-heading text-center">
         <asp:Label ID="lblGestionMisCompras" runat="server" Text="Mi Cuenta Corriente" font-size="24px" CssClass="TituloPanel"></asp:Label>
       </div>
     </div>
 </div>
<br />
<br />    
      
                                   
</div>
  <br />   
    <br />  
       <%-- Sección GRID FACTURAS--%>

         <div class="panel-group col-md-12">
                        <div class="panel-default">
                            <hr />
                            <div class="panel-heading text-center">Resumen Facturas</div>
                            <hr />
                          <div class="panel-body">

                      <div class="col-md-12">
                        <asp:GridView CssClass="table table-hover table-bordered table-responsive table-active text-center" ID="gv_facturas" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="5" OnPageIndexChanging="gv_facturas_PageIndexChanging" RowStyle-Height="40px">
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
                                <asp:BoundField DataField="ID" HeaderText="Numero Factura" />
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
                    </div>


               </div>
             </div>
          </div>



         <%-- Sección GRID NOTAS CREDITO--%>

         <div class="panel-group col-md-12">
                        <div class="panel-default">
                             <hr />
                            <div class="panel-heading text-center">Resumen Notas de Crédito</div>
                             <hr />
                            <div class="panel-body">

            <div class="col-md-12">
                        <asp:GridView CssClass="table table-hover table-bordered table-responsive table-active text-center" ID="gv_notas" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="5" OnPageIndexChanging="gv_notas_PageIndexChanging" RowStyle-Height="40px">
                            <HeaderStyle CssClass="thead-dark" />
                            <PagerTemplate>
                                <div class="col-md-4 text-left">
                                    <asp:Label ID="lblmostrarpag" runat="server" Text="Mostrar Pagina"></asp:Label>
                                    <asp:DropDownList ID="ddlPagingnotas" runat="server" AutoPostBack="true" CssClass="margenPaginacion" OnSelectedIndexChanged="ddlPagingnotas_SelectedIndexChanged" />
                                    <asp:Label ID="lblde" runat="server" Text="de"></asp:Label>
                                    <asp:Label ID="lbltotalpages" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-md-4 col-md-offset-4">
                                    <asp:Label ID="lblMostrar" runat="server" Text="Mostrar"></asp:Label>
                                    <asp:DropDownList ID="ddlPageSizenotas" runat="server" AutoPostBack="true" CssClass="margenPaginacion" OnSelectedIndexChanged="ddlPageSizenotas_SelectedPageSizeChanged">
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
                                <asp:BoundField DataField="ID" HeaderText="Numero Nota Credito" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                <asp:BoundField DataField="Fecha_Emision" HeaderText="Fecha" />
                                <asp:BoundField DataField="Monto" HeaderText="Monto" />
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


          <div class="panel-group col-md-4">
                        <div class="panel-default">
                             <hr />
                            <div class="panel-heading text-center">Saldo en Innova LED</div>
                             <hr />
                            <div class="panel-body">
                            </div>
                            </div>
     
              <div class="row col-md-12">
                <div class="row col-md-4">
                   <h4><asp:Label ID="lbltotalnotasCTitulo" runat="server" Text="En cuenta:  " CssClass="control-label labelform"></asp:Label></h4>
              </div>
            <div class="row col-md-4 col-md-offset-1">
                <h4><asp:Label ID="lbltotalnotasC" runat="server" Text="AR$ 0" CssClass="control-label labelform"></asp:Label></h4>
             </div>
             </div>
         <hr />
       </div>
   

      

 </div>  
  
   
</asp:Content>


