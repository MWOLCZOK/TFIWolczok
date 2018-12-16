<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="RegistrarBoletin.aspx.vb" Inherits="Vista.RegistrarBoletin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="JS/jquery-1.9.1.min.js"></script>
    <script src="JS/jquery-ui.js"></script>
    <link href="CSS/DateTimePicker.css" rel="stylesheet" type="text/css" />
    <script>
        $(function () {
            $("#contenidoPagina_datepicker").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div id="alertvalid" runat="server" name="alertvalid" class="alert alert-danger  text-center" visible="false">
        <label runat="server" id="textovalid" class="text-danger"></label>
    </div>
    <div id="success" runat="server" name="success" class="alert alert-success  text-center" visible="false">
        <label id="lblsuccessmodprod" class="text-success"></label>
    </div>
    <div class="container-fluid fondoGris">


        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-primary class">
                    <div class="panel-heading text-center">
                        <asp:Label ID="Lbl_GestionarProd" runat="server" Text="Newsletter" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                    </div>
                </div>
            </div>
            <br />
            <br />
        </div>
        <br />


        <div class="panel-group col-md-5">
            <div class="panel-default">
                <div class="panel-heading ">Nuevo Boletin</div>
                <div class="panel-body">
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-md-2">
                            <div class="row">
                                <asp:Label ID="lbl_Nombre" runat="server" Font-Bold="true" Text="Nombre"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-7 col-md-offset-1">
                            <asp:TextBox ID="txt_Nombre" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>
                        <div class="col-md-1 col-md-offset-1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="txt_Nombre" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <br />
                    <div class="row">
                        <div class="col-md-2">
                            <div class="row">
                                <asp:Label ID="lbl_Descripcion" runat="server" Font-Bold="true" Text="Descripcion"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-7 col-md-offset-1">
                            <asp:TextBox ID="txt_Descripcion" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>
                        <div class="col-md-1 col-md-offset-1">
                            <asp:RequiredFieldValidator ID="requerido_txt_asunto" runat="server"
                                ControlToValidate="txt_Descripcion" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-md-2">
                            <div class="row">
                                <asp:Label ID="lbl_Cuerpo" runat="server" Text="Cuerpo" Font-Bold="true"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-7 col-md-offset-1">
                            <asp:TextBox ID="txt_Cuerpo" runat="server" CssClass="form-control" Height="250px" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                        </div>
                        <div class="col-md-1 col-md-offset-1">
                            <asp:RequiredFieldValidator ID="requerido_txt_texto" runat="server"
                                ControlToValidate="txt_Cuerpo" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-md-3">
                            <div class="row">
                                <asp:Label ID="lbl_TipoBoletin" runat="server" Font-Bold="true" Text="Tipo Boletin"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-3 col-md-offset-2">
                            <asp:DropDownList ID="ddl_TipoBoletin" runat="server" CssClass="btn-lg btn-default dropdown-toggle" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col-md-1 col-md-offset-1">
                        </div>
                    </div>

                    <div id="fechaFinVigencia" runat="server">
                        <br />

                        <div class="row">
                            <div class="col-md-4">
                                <div class="row">
                                    <asp:Label ID="lbl_FechaFinVigencia" runat="server" Text="Fecha Fin Vigencia" Font-Bold="true"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4 col-md-offset-1">
                                <asp:TextBox ID="datepicker" runat="server" placeholder="DD/MM/AAAA" CssClass="form-control"></asp:TextBox>

                            </div>
                            <div class="col-md-1 col-md-offset-1">
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <div class="row">
                                <asp:Label ID="lbl_SeleccionarImagenBoletin" runat="server" Text="Selección Imagen" Font-Bold="true"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-5 col-md-offset-1">
                            <asp:FileUpload ID="fu_imagenBoletin" runat="server" CssClass="btn btn-default btn-file" />
                        </div>
                    </div>

                    <div class="col-md-1 col-md-offset-1">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ControlToValidate="fu_imagenBoletin" ValidationExpression="(.*).(.jpg|.JPG|.gif|.GIF|.jpeg|.JPEG|.bmp|.BMP|.png|.PNG)$" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RegularExpressionValidator>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*" ControlToValidate="datepicker" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fu_imagenBoletin" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="validadorSize" runat="server" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador" ControlToValidate="fu_imagenBoletin" OnServerValidate="validadorSize_ServerValidate"></asp:CustomValidator>
                    </div>

                </div>
                <br />
                <br />
                <div class="row">
                    <div class="col-md-2 col-md-offset-3">
                        <asp:Button ID="btn_agregar" runat="server" Text="Agregar" CssClass="btn btn-lg btn-primary" />
                    </div>
                    <div class="col-md-2 col-md-offset-1">
                        <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" CssClass="btn btn-lg btn-warning" />
                    </div>
                </div>
                <br />
            </div>
        </div>



        <%--Sección GRID Newsletters--%>


        <div class="col-md-5 col-md-offset-1">
            <asp:GridView CssClass="table table-hover table-bordered table-responsive table-success " ID="gv_Newsletter" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="5" OnPageIndexChanging="gv_Newsletter_PageIndexChanging" RowStyle-Height="40px">
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
                    <asp:BoundField DataField="ID" HeaderText="Numero Boletin" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre Boletin" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                    <asp:BoundField DataField="Cuerpo" HeaderText="Cuerpo" />
                    <asp:BoundField DataField="TipoBoletin" HeaderText="Tipo Boletin" />
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


    </div>

    <br />

     <asp:HiddenField ID="id_newsletter" runat="server" />

</asp:Content>
