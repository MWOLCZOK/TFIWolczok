<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="GestionarRespuestas.aspx.vb" Inherits="Vista.GestionarRespuestas" MaintainScrollPositionOnPostback="true" %>

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
            <label id="lblsuccessmodUser" class="text-success">La pregunta se respondió correctamente.</label>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-primary class">
                    <div class="panel-heading text-center">
                        <asp:Label ID="lblPanelModUser" runat="server" Text="Gestión de Respuestas" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                    </div>
                </div>
            </div>

            <br />
            <br />
            <div class="form-horizontal has-success col-md-12">
                <div class="form-group">

                    <%-- Sección Grid  --%>

                    <div class="col-md-12">
                        <asp:GridView CssClass="table table-hover table-bordered table-responsive table-success " ID="gv_comentarios" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="5" OnPageIndexChanging="gv_comentarios_PageIndexChanging" RowStyle-Height="40px">
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
                                <asp:BoundField DataField="Producto.Modelo" HeaderText="Producto" />
                                <asp:BoundField DataField="Usuario.NombreUsu" HeaderText="Usuario" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                <asp:BoundField DataField="Texto" HeaderText="Pregunta" />
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

                    <%-- Sección Tabla Usuarios  --%>

                    <div id="respuesta" runat="server" class="form-horizontal has-success col-md-12 ">
                        <div class="form-group">
                            <asp:Label ID="lblrespuesta" runat="server" Text="Respuesta:" CssClass="col-sm-3 control-label labelform"></asp:Label>
                            <div class="col-md-7">
                                <div class="input-group">
                                    <textarea class="form-control" rows="5" id="txt_respuesta" runat="server"></textarea>
                                    <span class="input-group-addon" id="basic-addon1"><span class="	glyphicon glyphicon-user" aria-hidden="true"></span></span>
                                </div>
                            </div>
                            <div class="col-md-1">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_respuesta" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4 col-md-offset-4">
                                <asp:Button ClientIDMode="Static" ID="btnrespuesta" name="btnrespuesta" runat="server" Text="Responder" CssClass="btn btn-lg btn-block btn-warning" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <br />
        </div>
    </div>



    <asp:HiddenField ID="id_usuario" runat="server" />

</asp:Content>
