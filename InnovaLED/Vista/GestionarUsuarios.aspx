<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="GestionarUsuarios.aspx.vb" Inherits="Vista.ModificarUsuario" MaintainScrollPositionOnPostback="true" %>

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
            <label id="lblsuccessmodUser" class="text-success">El Usuario se creó correctamente.</label>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-primary class">
                    <div class="panel-heading text-center">
                        <asp:Label ID="lblPanelModUser" runat="server" Text="Gestión de Usuarios" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                    </div>
                </div>
            </div>

            <br />
            <br />
            <div class="form-horizontal has-success col-md-12">
                <div class="form-group">

                    <%-- Sección Grid  --%>

                    <div class="col-md-5 col-md-offset-1">
                        <asp:GridView CssClass="table table-hover table-bordered table-responsive table-success " ID="gv_Usuarios" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="5" OnPageIndexChanging="gv_Usuarios_PageIndexChanging" RowStyle-Height="40px">
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
                                <asp:BoundField DataField="ID_Usuario" HeaderText="ID" />
                                <asp:BoundField DataField="NombreUsu" HeaderText="Nombre Usuario" />
                                <asp:BoundField DataField="Idioma.Nombre" HeaderText="Idioma" />
                                <asp:BoundField DataField="Bloqueo" HeaderText="Estado" />
                                <asp:BoundField DataField="Empleado" HeaderText="Empleado" />
                                <asp:BoundField DataField="FechaAlta" HeaderText="Fecha de Alta" DataFormatString="{0:dd-MM-yyyy HH:mm:ss}" />
                                <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <div>
                                            <asp:ImageButton ID="btn_Bloquear" runat="server" CommandName="B" ImageUrl="~/Imagenes/padlock-close.png" Height="18px" />
                                            <asp:ImageButton ID="btn_desbloqueo" runat="server" CommandName="U" ImageUrl="~/Imagenes/padlock-open.png" Height="18px" />
                                            <asp:ImageButton ID="btn_editar" runat="server" CommandName="E" ImageUrl="~/Imagenes/edit.png" Height="18px" />
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>

                    <%-- Sección Tabla Usuarios  --%>

                    <div class="form-horizontal has-success col-md-6 ">
                        <div class="form-group">
                            <asp:Label ID="lblapellido" runat="server" Text="Apellido:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                            <div class="col-md-4">
                                <div class="input-group">
                                    <asp:TextBox ID="txtapellido" runat="server" CssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon" id="basic-addon1"><span class="	glyphicon glyphicon-user" aria-hidden="true"></span></span>
                                </div>
                            </div>
                            <div class="col-md-1">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtapellido" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblnombre" runat="server" Text="Nombre:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                            <div class="col-md-4">
                                <div class="input-group">
                                    <asp:TextBox ID="txtnombre" runat="server" CssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon" id="basic-addon2"><span class="	glyphicon glyphicon-user" aria-hidden="true"></span></span>
                                </div>
                            </div>
                            <div class="col-md-1">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnombre" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="Nombre de Usuario:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                            <div class="col-md-4">
                                <div class="input-group">
                                    <asp:TextBox ID="txtnomusuario" runat="server" CssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon" id="basic-addon8"><span class="glyphicon glyphicon-user" aria-hidden="true"></span></span>
                                </div>
                            </div>
                            <div class="col-md-1">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtnomusuario" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblpass" runat="server" Text="Contraseña:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                            <div class="col-md-4">
                                <div class="input-group">
                                    <input type="password" id="txtpass" runat="server" class="form-control" />
                                    <span class="input-group-addon" id="basic-addon9"><span class="glyphicon glyphicon-lock" aria-hidden="true"></span></span>
                                </div>
                            </div>
                            <div class="col-md-1">
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="LblDNI" runat="server" Text="DNI:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                            <div class="col-md-4">
                                <div class="input-group">
                                    <asp:TextBox ID="TxtDNI" runat="server" CssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon" id="basic-addon9"><span class="glyphicon glyphicon-lock" aria-hidden="true"></span></span>
                                </div>
                            </div>
                            <div class="col-md-1">
                            </div>
                            <div class="col-md-1">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtDNI" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                            </div>
                        </div>


                        <div class="form-group">
                            <asp:Label ID="Lblmail" runat="server" Text="Mail:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                            <div class="col-md-4">
                                <div class="input-group">
                                    <asp:TextBox ID="txtmail" runat="server" CssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon" id="basic-addon8"><span class="glyphicon glyphicon-user" aria-hidden="true"></span></span>
                                </div>
                            </div>
                            <div class="col-md-1">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtmail" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                            </div>
                        </div>



                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="Rol:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                            <div class="col-md-4">
                                <div class="input-group">
                                    <asp:DropDownList ID="DropDownListRol" runat="server" CssClass="form-control" AutoPostBack="true" DataValueField="ID_Rol" DataTextField="Nombre"></asp:DropDownList>
                                    <span class="input-group-addon" id="basic-addon10"><span class="	glyphicon glyphicon-list-alt" aria-hidden="true"></span></span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label3" runat="server" Text="Idioma:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                            <div class="col-md-4">
                                <div class="input-group">
                                    <asp:DropDownList ID="DropDownListIdioma" runat="server" CssClass="form-control" AutoPostBack="true" DataValueField="ID_Idioma" DataTextField="Nombre"></asp:DropDownList>
                                    <span class="input-group-addon" id="basic-addon11"><span class="glyphicon glyphicon-flag" aria-hidden="true"></span></span>
                                </div>
                            </div>
                        </div>
                    </div>


                    <br />
                    <br />


                    <div class="row">
                        <div class="col-md-2 col-md-offset-1">
                            <asp:Button ClientIDMode="Static" ID="btnAceptar" name="btnAceptar" runat="server" Text="Crear Usuario" CssClass="btn btn-block btn-success" />
                        </div>

                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-2 col-md-offset-7 ">
                            <asp:Button ClientIDMode="Static" ID="btnModificar" name="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-block btn-warning" />
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-md-2 col-md-offset-7 ">
                            <asp:Button ClientIDMode="Static" ID="btneliminar" name="btneliminar" runat="server" Text="Eliminar" CssClass="btn btn-block btn-danger" />
                        </div>
                    </div>
                    <br />
                </div>
                <br />
                <br />
            </div>
        </div>
        <br />
        <br />
    </div>
    </div>
      
 
   
    <asp:HiddenField ID="id_usuario" runat="server" />

</asp:Content>
