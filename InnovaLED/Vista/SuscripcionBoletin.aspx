<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="SuscripcionBoletin.aspx.vb" Inherits="Vista.SuscripcionBoletin" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- <script type="text/javascript" src="JS/ClienteValid.js"></script>-->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid fondoGris">
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
                        <asp:Label ID="lblPanelModUser" runat="server" Text="Newsletter" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                    </div>
                </div>
            </div>
            <br />
            <br />

            <div class="row" runat="server" id="Suscrip">
                <div class="panel-group col-md-5 col-md-offset-3">
                    <div class="panel-default">
                        <div class="panel-heading text-center">Suscribirse a Boletin</div>
                        <div class="panel-body">
                            <br />
                            <br />
                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="label">
                                        <asp:Label ID="lbl_correo" Text="Correo Electronico" font="Bahnschrift" Font-Bold="True" Font-Size="18px" ForeColor="Black" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-md-offset-1">
                                    <asp:TextBox ID="txt_correo" runat="server" CssClass="caja-texto" MaxLength="100"></asp:TextBox>
                                </div>
                                <div class="col-md-1 col-md-offset-1">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="txt_correo" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                        ControlToValidate="txt_correo" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="label">
                                        <asp:Label ID="lbl_intereses" Text="Intereses" font="Bahnschrift" Font-Bold="True" Font-Size="18px" ForeColor="Black" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-md-offset-1">
                                    <asp:TreeView ID="tv_TipoBoletin" runat="server" ExpandDepth="0" ForeColor="Black" CssClass="label" ShowCheckBoxes="All" ShowExpandCollapse="False">
                                        <NodeStyle VerticalPadding="7px" />
                                    </asp:TreeView>
                                </div>
                                <div class="col-md-1 col-md-offset-1">
                                </div>
                            </div>

                            <br />
                            <br />
                            <div class="fila">
                                <div class="col-md-2 col-md-offset-3">
                                    <asp:Button ID="btn_agregar" runat="server" Text="Agregar" CssClass="btn btn-aceptar btn-block" />
                                </div>
                                <div class="col-md-2 col-md-offset-2">
                                    <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" CssClass="btn btn-cancelar btn-block" />
                                </div>

                            </div>
                            <br />
                        </div>
                    </div>
                </div>
            </div>


            <br />
            <div class="row" runat="server" id="Row_BajaSuscripcion_labelyboton">
                <div class="col-md-offset-9">
                    <asp:Label ID="Lbl_bajasuscrip1" runat="server" Text="¿Deseas dejar de recir nuestro Boletín?"></asp:Label>
                </div>
            </div>

            <div class="row" runat="server" id="Row_BajaSuscripcion_labelyboton2">
                <div class="row col-md-offset-9">
                    <asp:Button ID="btn_bajasuscrip1" runat="server" Text="Baja Suscripción" CssClass="btn btn-danger btn-md col-md-4 col-md-offset-2 " />
                </div>
            </div>
            <br />


            <%--  Baja de Boletin--%>
            <div class="row" runat="server" id="Baja_Suscrip">
                <div class="panel-group col-md-5 col-md-offset-3">
                    <div class="panel-default">
                        <div class="panel-heading text-center">Baja suscripción a Boletin</div>
                        <div class="panel-body">
                            <br />
                            <br />
                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="label">
                                        <asp:Label ID="lbl_correobajasus" Text="Correo Electronico" font="Bahnschrift" Font-Bold="True" Font-Size="18px" ForeColor="Black" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-md-offset-1">
                                    <asp:TextBox ID="TxtCorreoBaja" runat="server" CssClass="caja-texto" MaxLength="100"></asp:TextBox>
                                </div>
                                <div class="col-md-1 col-md-offset-1">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                        ControlToValidate="txt_correo" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                        ControlToValidate="txt_correo" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />
                            <br />
                            <div class="row">
                                <div class="col-md-3 col-md-offset-4">
                                    <asp:Button ID="btn_bajasus" runat="server" Text="Baja Suscripción" CssClass="btn btn-aceptar btn-block" />
                                </div>
                            </div>
                            <br />
                            <br />
                        </div>
                    </div>
                </div>
            </div>



        </div>







    </div>
</asp:Content>



