<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="EncuestaGlobal.aspx.vb" Inherits="Vista.EncuestaGlobal" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- <script type="text/javascript" src="JS/ClienteValid.js"></script>-->
        <script src="JS/Chart.js"></script>
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


                            <div id="preguntasdinamicas" runat="server" class="col-md-6">
                            </div>
                           <div class="col-md-6">
                                   <div id="canvas-holder1">
                                        <canvas id="chart-area1" width="250" height="250" />
                                    </div>
                               <br />
                               <br />
                                  <div id="canvas-holder2">
                                        <canvas id="chart-area2" width="250" height="250" />
                                    </div>
                                <%--  <div id="canvas-holder3">
                                        <canvas id="chart-area3" width="300" height="300" />
                                    </div>
                                     <div id="canvas-holder4">
                                        <canvas id="chart-area4" width="300" height="300" />
                                    </div>
                                  <div id="canvas-holder5">
                                        <canvas id="chart-area5" width="300" height="300" />
                                    </div>--%>
                           </div>
                            <asp:Button ID="btn_enviar" class="btn btn-primary btn-lg" runat="server" Text="Enviar" />
                             </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
