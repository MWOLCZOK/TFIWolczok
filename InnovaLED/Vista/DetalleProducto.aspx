﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="DetalleProducto.aspx.vb" Inherits="Vista.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid fondoGris">
        <br />
        <div id="alertvalid" runat="server" name="alertvalid" class="alert alert-danger  text-center" visible="false">
            <label runat="server" id="txtvalidprod" class="text-danger"></label>
        </div>
        <div id="success" runat="server" name="success" class="alert alert-success  text-center" visible="false">
            <label id="lblsuccessprod" class="text-success"></label>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-primary class">
                    <div class="panel-heading text-center">
                        <asp:Label ID="lblPanelModUser" runat="server" Text="Detalle de Producto" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                    </div>
                </div>
            </div>
            <br />
            <br />


        </div>



        <div class="row col-md-12">
            <div class="thumbnail col-md-12">
                <div class="row col-md-6">
                    <asp:ImageButton ID="ImgBut" runat="server" Height="500px" Width="500px" />
                </div>

                <div class="col-md-6">


                    <%-- Aca van las especificaciones tecnicas --%>

                    <div class="panel-group col-md-6">
                        <div class="panel-default">
                            <div class="panel-heading ">Especificaciones Técnicas</div>
                            <div class="panel-body">

                                <div class="row">
                                    <asp:Label ID="Lblmarca" runat="server" Text="Marca:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                                    <div class="col-md-6">
                                        <div class="input-group">
                                            <asp:Label ID="Lblmarca_descr" runat="server"></asp:Label>

                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <asp:Label ID="Lbl_modelo" runat="server" Text="Modelo:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                                    <div class="col-md-6">
                                        <div class="input-group">
                                            <asp:Label ID="Lblmodelo_descr" runat="server"></asp:Label>

                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <asp:Label ID="Lbl_peso" runat="server" Text="Peso:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                                    <div class="col-md-6">
                                        <div class="input-group">
                                            <asp:Label ID="Lblpeso_descrip" runat="server"></asp:Label>

                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <asp:Label ID="Lbl_watt" runat="server" Text="Watt:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                                    <div class="col-md-6">
                                        <div class="input-group">
                                            <asp:Label ID="Lblwatt_descr" runat="server"></asp:Label>

                                        </div>
                                    </div>

                                </div>
                                <br />

                                <div class="row">
                                    <asp:Label ID="Lbl_linea" runat="server" Text="Línea del Producto:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                                    <div class="col-md-6">
                                        <div class="input-group">
                                            <asp:Label ID="Lbllinea_descr" runat="server"></asp:Label>

                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <asp:Label ID="Lbl_cat" runat="server" Text="Categoria Producto:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                                    <div class="col-md-6">
                                        <div class="input-group">
                                            <asp:Label ID="Lblcat_descr" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <asp:Label ID="Lbl_Descripcion" runat="server" Text="Descripcion:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                                    <div class="col-md-6">
                                        <div class="input-group">
                                            <asp:Label ID="Lbldescrip_descrip" runat="server"></asp:Label>

                                        </div>
                                    </div>
                                </div>
                                <br />


                                <div class="row">
                                    <asp:Label ID="Label3" Text="Cantidad" runat="server" CssClass="col-sm-4 control-label labelform"></asp:Label>
                                    <div class="col-md-6">
                                        <div class="input-group">
                                            <asp:DropDownList ID="Dropnumeric" runat="server" class="btn btn-lg btn-default dropdown-toggle" data-toggle="dropdown"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <asp:Label ID="Lbl_DescripcionPromedioValoracion" runat="server" Text="Valoracion:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                                    <div class="col-md-6">
                                        <div class="input-group">
                                            <h3>
                                            <asp:Label ID="Lbl_PromValoracion" runat="server"></asp:Label></h3>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <br />

                                <div class="row">
                                    <h1>
                                        <asp:Label ID="Lblprecio_descr" runat="server"></asp:Label></h1>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="row col-md-4 col-md-offset-1">
                                        <asp:Button ID="btn_comprar" runat="server" Text="Comprar" type="button" class="btn btn-success btn-lg "></asp:Button>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <%-- Aca cierran especificaciones tecnicas --%>
                    </div>

                    <%-- <div class="caption">
        <asp:Label ID="Lbl_marca" runat="server" Text="Gestionar Productos" font-size="24px" CssClass="TituloPanel"></asp:Label>
        <p>...</p>
        <p><a href="#" class="btn btn-lg btn-primary" role="button">Button</a> <a href="#" class="btn btn-default" role="button">Button</a></p>
      </div>--%>
                </div>

                <div id="pregunta" runat="server" class="col-md-6">
                    <br />
                    <br />
                    <div class="col-md-9">
                        <textarea class="form-control" rows="8" id="txt_consulta" runat="server"></textarea>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btn_consultar" runat="server" Text="Preguntar" type="button" class="btn btn-info btn-lg "></asp:Button>
                    </div>


                    <div class="row col-md-12">
                        <br />
                        <br />
                        <br />
                    </div>
                    <div id="Comentarios" runat="server">
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                </div>
                <div id="valoracion" runat="server" class=" col-md-6">
                    <br />
                    <h3>Valoración</h3>
                    <div id="valorarocultado" runat="server">
                        <asp:ImageButton runat="server" ID="star1" ImageUrl="IMAGENES/1starblack.png" Height="55" />
                        <asp:ImageButton runat="server" ID="star2" ImageUrl="IMAGENES/2starblack.png" Height="55" />
                        <asp:ImageButton runat="server" ID="star3" ImageUrl="IMAGENES/3starblack.png" Height="55" />
                        <asp:ImageButton runat="server" ID="star4" ImageUrl="IMAGENES/4starblack.png" Height="55" />
                        <asp:ImageButton runat="server" ID="star5" ImageUrl="IMAGENES/5starblack.png" Height="55" />
                        <div class="col-md-12 row">
                            <textarea class="form-control" rows="5" id="txt_valoracion" runat="server"></textarea>
                        </div>

                        <div class="col-md-2 row">
                            <br />
                            <asp:Button ID="btn_valoracion" runat="server" Text="Valorar" type="button" class="btn btn-info btn-lg "></asp:Button>
                        </div>

                        <div class="row col-md-12">
                            <br />
                            <br />
                            <br />
                        </div>
                    </div>
                    <div id="valoraciones" runat="server">
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>


    <asp:HiddenField ID="ID_Producto" runat="server" />
</asp:Content>
