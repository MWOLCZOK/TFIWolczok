<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="EncuestaGlobal.aspx.vb" Inherits="Vista.EncuestaGlobal" %>




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

            <div class="row text-center">
                <hr />
                <h3>Nos interesa tu opinión, es por ello que te invitamos a responder estas breves preguntas acerca de nuestro sitio .. </h3>
                <hr />
            </div>

            <br />
            <br />


            <%--<div class="col-md-10 col-md-offset-1">
<br />
<asp:Panel ID="panelPreguntas" runat="server">--%>



            <div class="panel-group col-md-8 col-md-offset-2">
                <div class="panel-default">
                    <div class="panel-body">
                        <asp:Panel ID="panelPreguntas" runat="server">


                            <h3>
                                <asp:Label ID="lbl_pregunta1" runat="server"></asp:Label></h3>

                            <asp:Label ID="id_1" runat="server" Visible="false"></asp:Label>
                            <br />
                            <br />
                            <asp:RadioButtonList class="text-left" ID="rb_pregunta1" runat="server"></asp:RadioButtonList>
                            <br />
                            <br />
                            <h3>
                                <asp:Label ID="lbl_pregunta2" runat="server"></asp:Label></h3>
                            <asp:Label ID="id_2" runat="server" Visible="false"></asp:Label>
                            <br />
                            <br />
                            <asp:RadioButtonList class="text-left" ID="rb_pregunta2" runat="server"></asp:RadioButtonList>
                            <br />
                            <br />
                            <h3>
                                <asp:Label ID="lbl_pregunta3" runat="server"></asp:Label></h3>
                            <asp:Label ID="id_3" runat="server" Visible="false"></asp:Label>
                            <br />
                            <br />
                            <asp:RadioButtonList class="text-left" ID="rb_pregunta3" runat="server"></asp:RadioButtonList>
                            <br />
                            <br />

                            <asp:Button ID="btn_enviar" class="btn btn-primary btn-lg" runat="server" Text="Enviar" />
                        </asp:Panel>
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="panel-group col-md-6">
                    <div class="panel-default">
                        <hr />
                        <div class="panel-heading text-center">Distribución Total de Chats Ingresados</div>
                        <hr />
                        <div class="panel-body">

                            <div id="div1" class="row col-md-offset-2" runat="server">
                                <div id="div2" runat="server" style="width: 100%; font-size: 4vh; font-weight: bold" />
                                <div id="div3" runat="server" style="width: 408px; height: 308px">
                                    <asp:Chart EnableViewState="True" ID="CharEncuesta1" runat="server" Style="max-width: 100%" Height="334px" Width="384px">
                                        <Legends>
                                            <asp:Legend Name="Distribución de Chat">
                                            </asp:Legend>
                                        </Legends>
                                        <Titles>
                                            <asp:Title Text="Distribución de Chats"></asp:Title>
                                        </Titles>
                                        <Series>
                                            <asp:Series Name="Series1" ChartType="Pie" IsValueShownAsLabel="true" Legend="Distribución de Chat"></asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1" AlignmentOrientation="Horizontal" Area3DStyle-Enable3D="true"
                                                Area3DStyle-WallWidth="2" Area3DStyle-Rotation="20"
                                                Area3DStyle-LightStyle="Simplistic" Area3DStyle-Inclination="40"
                                                BorderColor="White" ShadowColor="#CCCCCC">

                                                <Area3DStyle Enable3D="True" Inclination="40" Rotation="20" WallWidth="2"></Area3DStyle>

                                            </asp:ChartArea>

                                        </ChartAreas>
                                    </asp:Chart>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>




        </div>




    </div>



</asp:Content>
