<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="GestionarProductos.aspx.vb" Inherits="Vista.GestionarProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div id="alertvalid" runat="server" name="alertvalid" class="alert alert-danger  text-center" visible="false">
        <label runat="server" id="textovalid" class="text-danger"></label>
    </div>
    <div id="success" runat="server" name="success" class="alert alert-success  text-center" visible="false">
        <label id="lblsuccessmodprod" class="text-success">El producto se creó correctamente.</label>
    </div>
    <div class="container-fluid fondoGris">
        <br />


        <div class="col-md-12">
            <div class="panel panel-primary class">
                <div class="panel-heading text-center">
                    <asp:Label ID="Lbl_GestionarProd" runat="server" Text="Gestionar Productos" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                </div>
            </div>
        </div>
        <br />
        <br />
        <br />


        <div class="panel col-md-5">
            <div class="panel-default">
                <div class="panel-heading ">Producto</div>
                <div class="panel-body">
                        <br />
                    <div class="form-group">
                        <asp:Label ID="Lbl_marca" runat="server" Text="Marca:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                        <div class="col-md-6">
                            <div class="input-group">
                                <asp:TextBox ID="txtmarca" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtmarca" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                        </div>
                    </div>    <br />
                           <br />
                    <div class="form-group">
                        <asp:Label ID="Lbl_modelo" runat="server" Text="Modelo:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                        <div class="col-md-6">
                            <div class="input-group">
                                <asp:TextBox ID="txtmodelo" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtmodelo" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                        </div>
                    </div>    <br />
                           <br />

                    <div class="form-group">
                        <asp:Label ID="Lbl_Descripcion" runat="server" Text="Descripcion:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                        <div class="col-md-6">
                            <div class="input-group">
                                <asp:TextBox ID="txtdesc" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtdesc" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                        </div>
                    </div>    <br />
                           <br />
                    <div class="form-group">
                        <asp:Label ID="Lbl_peso" runat="server" Text="Peso:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                        <div class="col-md-6">
                            <div class="input-group">
                                <asp:TextBox ID="txtpeso" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpeso" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="Numeros3" runat="server" ControlToValidate="txtpeso"
                                ValidationExpression="^\d+$" ErrorMessage="Solo numeros"  ForeColor="Red" Font-Bold="true"></asp:RegularExpressionValidator>   
                        </div>
                    </div>    <br />
                           <br />
                    <div class="form-group">
                        <asp:Label ID="Lbl_precio" runat="server" Text="Precio:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                        <div class="col-md-6">
                            <div class="input-group">
                                <asp:TextBox ID="txtprecio" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-1">
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtprecio" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                           <asp:RegularExpressionValidator ID="Numeros" runat="server" ControlToValidate="txtprecio"
                                ValidationExpression="^\d+$" ErrorMessage="Solo numeros"  ForeColor="Red" Font-Bold="true"></asp:RegularExpressionValidator>                         
                        </div>
                    </div>    <br />
                           <br />
                    <div class="form-group">
                        <asp:Label ID="Lbl_watt" runat="server" Text="Watt:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                        <div class="col-md-6">
                            <div class="input-group">
                                <asp:TextBox ID="txtwatt" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtwatt" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="Numeros2" runat="server" ControlToValidate="txtwatt"
                                ValidationExpression="^\d+$" ErrorMessage="Solo numeros"  ForeColor="Red" Font-Bold="true"></asp:RegularExpressionValidator> 
                        </div>
                    </div>    <br />
                           <br />
                    <div class="form-group">
                        <asp:Label ID="Lbl_linea" runat="server" Text="Línea del Producto:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                        <div class="col-md-6">
                            <div class="input-group">
                                <asp:DropDownList ID="DropDownLinea" runat="server" CssClass="form-control" AutoPostBack="true" DataValueField="ID_Linea" DataTextField="Nombre"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-1">
                        </div>
                    </div>    <br />
                           <br />
                    <div class="form-group">
                        <asp:Label ID="Lbl_cat" runat="server" Text="Categoria Producto:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                        <div class="col-md-6">
                            <div class="input-group">
                                <asp:DropDownList ID="DropDowncat" runat="server" CssClass="form-control" AutoPostBack="true" DataValueField="ID_CategoriaProducto" DataTextField="Nombre"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-1">
                        </div>
                    </div>    <br />
                           <br />
                    <div class="form-group">
                        <asp:Label ID="Lbl_imagen" runat="server" Text="Imagen:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                        <div class="col-md-6">
                            <div class="input-group">
                                <asp:FileUpload ID="FileUpload1" class="btn btn-default btn-file" runat="server" />
                            </div>
                        </div>
                        <div class="col-md-1">
                        </div>
                    </div>
                           <br />
                        <br />
              
                    <div class="form-group">
                        <asp:Button ID="btn_agregar" runat="server" Text="Agregar" type="button" class="btn btn-success btn-md col-md-2"></asp:Button>
                        <asp:Button ID="btn_modificar" runat="server" Text="Modificar" type="button" class="btn btn-info btn-md col-md-2 col-md-offset-1"></asp:Button>
                        <button id="btn_confirmar" runat="server" type="button" class="btn btn-danger btn-md col-md-2 col-md-offset-1" data-toggle="modal" data-target="#ConfirmacionModalTitle">Eliminar</button>
                        <asp:Button ID="btn_nuevo"  CausesValidation="false" runat="server" Text="Cancelar" type="button" class="btn btn-warning btn-md col-md-2 col-md-offset-1"></asp:Button>

                    </div>
                </div>
            </div>
        </div>

        <%-- Sección GRID --%>
        <div class="col-md-6">
            <asp:GridView CssClass="table table-hover table-bordered table-responsive table-active " ID="gv_Productos" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="10" OnPageIndexChanging="gv_Productos_PageIndexChanging" RowStyle-Height="40px">
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
                    <asp:BoundField DataField="ID_Producto" HeaderText="ID" />
                    <asp:BoundField DataField="Marca" HeaderText="Marca" />
                    <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                    <asp:BoundField DataField="Peso" HeaderText="Peso" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:BoundField DataField="Watt" HeaderText="Watt" />
                    <asp:BoundField DataField="LineaProducto" HeaderText="Linea" />
                    <asp:BoundField DataField="CategoriaProducto" HeaderText="Categoria Producto" />

                    <asp:TemplateField HeaderText="Acción" HeaderStyle-Width="100px">
                        <ItemTemplate>
                            <div>
                                <%--   <asp:ImageButton ID="btn_Bloquear" runat="server" CommandName="B" ImageUrl="~/Imagenes/padlock-close.png" Height="18px" />
                                                            <asp:ImageButton ID="btn_desbloqueo" runat="server" CommandName="U" ImageUrl="~/Imagenes/padlock-open.png" Height="18px" />--%>
                                <asp:ImageButton ID="btn_editar" runat="server" CommandName="E" ImageUrl="~/Imagenes/edit.png" Height="18px" />
                            </div>
                        </ItemTemplate>
                        <HeaderStyle Width="100px"></HeaderStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <br />
    <br />

    <%-- Modal de Confirmacion de Eliminación --%>
    <div class="modal-normal " id="ConfirmacionModalTitle" role="dialog">
        <div class="modal-dialog" role="document">

            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title Blanco" id="ModalTitle">Confirmar Eliminación</h5>
                </div>


                <div class="modal-body Blanco">
                    <label>¿Está seguro que desea realizar la operación de Eliminación?</label>

                </div>
                <div class="modal-footer">
                    <asp:Button ID="btneliminar" runat="server" CssClass="btn btn-primary" OnClick="btneliminar_Click" Text="Aceptar" />
                    <button id="btncerrar" type="button" class="btn btn-primary" data-dismiss="modal">Cancelar</button>
                </div>

            </div>
        </div>
    </div>

    <asp:HiddenField ID="id_producto" runat="server" />

    <%-- </ContentTemplate>

<%--<Triggers>
     <asp:PostBackTrigger ControlID="btn_agregar"  />         
</Triggers>--%>
    <%--</asp:UpdatePanel>--%>
</asp:Content>
