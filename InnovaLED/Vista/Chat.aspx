<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Chat.aspx.vb" Inherits="Vista.Chat" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
        <ContentTemplate>
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
                                <asp:Label ID="lblPanelModUser" runat="server" Text="Chat" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />


                </div>

                <div class="row col-md-12">
                    <div class="thumbnail col-md-12">
                        <br />
                        <br />
                        <div id="chats" runat="server" class="col-md-3">
                        </div>
                        <div id="chat" runat="server" class="col-md-9">

                            <br />
                            <br />
                            <div id="mensajes" runat="server">
                            </div>
                            <br />
                            <br />

                            <div class="col-md-9">
                                <textarea class="form-control" rows="2" id="txt_mensaje" runat="server" enable="false" enableviewstate="True" visible="False"></textarea>
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btn_mensaje" runat="server" Text="Enviar" type="button" class="btn btn-info btn-lg " Visible="False"></asp:Button>
                                <br />
                                <br />                                                            
                            </div>

                        </div>                        
                    </div>                    
                </div>
                <h4>
                        <asp:Label ID="Lbl_TiempoRta" runat="server" Text="" Font-Size="20px" forecolor="SteelBlue" Font-Italic="true" Visible="false"></asp:Label></h4>
            </div>
            <asp:HiddenField ID="id_chat" runat="server" Value="-1" />
            <asp:Timer ID="Timer1" runat="server" EnableViewState="False" Interval="5000">
            </asp:Timer>
        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>
