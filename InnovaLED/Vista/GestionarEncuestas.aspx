<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="GestionarEncuestas.aspx.vb" Inherits="Vista.GestionarEncuestas" %>


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
                        <asp:Label ID="lblPanelModUser" runat="server" Text="Gestión de Encuestas" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                    </div>
                </div>
            </div>
            <br />
            <br />


        </div>


        <div class="panel-group col-md-5">
            <div class="panel-default">
                <div class="panel-heading ">Encuesta</div>
                <div class="panel-body">
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <div class="row">
                                <asp:Label ID="lbl_Nombrepregunta" runat="server" Font-Bold="true" Text="Pregunta"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-7 ">
                            <asp:TextBox ID="txt_Nombrepregunta" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>
                        <div class="col-md-1 col-md-offset-1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="txt_Nombrepregunta" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-2">
                            <div class="row">
                                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-1 col-md-offset-1">
                                <asp:RequiredFieldValidator ID="requerido_txt_asunto" runat="server"
                                    ControlToValidate="RadioButtonList1" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-4">
                                <div class="row">
                                    <asp:Label ID="lbl_FechaFinVigencia2" runat="server" Text="Fecha Fin Vigencia" Font-Bold="true"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="datepicker" runat="server" placeholder="DD/MM/AAAA" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-1 col-md-offset-1">
                                <asp:RequiredFieldValidator ID="requerido_txt_texto" runat="server"
                                    ControlToValidate="datepicker" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <br />
                    </div>
                    <br />
                    <br />
                    <div class="col-md-offset-1">
                        <div class="row">
                            <asp:Button ID="btn_agregar" runat="server" Text="Agregar" CssClass="btn btn-success btn-md col-md-2" />
                            <asp:Button ID="btn_eliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-md col-md-2 col-md-offset-1" />
                        </div>
                    </div>
                    <br />
                </div>
            </div>
        </div>
    </div>



</asp:Content>




