<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="GestionarRoles.aspx.vb" Inherits="Vista.GestionarRoles" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function confirmDel() {
            var myValue = "<%=mensajeConfirmacion%>";
                var agree = confirm(myValue);
                if (agree) return true;
                else return false;
            }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor">
        <div class="fila">
            <div class="col-md-10 col-md-offset-1">
                <div id="error" class="msj-error col-md-12" runat="server" visible="false">
                    <asp:Label ID="lbl_TituloError" runat="server" CssClass="label"></asp:Label>
                </div>
            </div>
        </div>
        <br />
        <div class="fila">
            <div class="col-md-10 col-md-offset-1">
                <div class="panel panel-verde">
                    <div class="panel-cabecera">
                        <asp:Label ID="cab_adminPerfil" runat="server">Administración de Perfiles</asp:Label>
                    </div>
                    <div class="panel-cuerpo">
                        <div class="fila">
                            <asp:GridView ID="gv_Perfiles" runat="server" CssClass="Grid-verde" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="10" OnPageIndexChanging="gv_Perfiles_PageIndexChanging" RowStyle-Height="40px">
                                <PagerTemplate>
                                    <div class="label right">
                                        <asp:Label ID="lbl_pagina" runat="server" Text="Pagina" CssClass="margenPaginacion"></asp:Label>
                                        <asp:DropDownList ID="ddlPaging" runat="server" AutoPostBack="true" CssClass="margenPaginacion" OnSelectedIndexChanged="ddlPaging_SelectedIndexChanged" />
                                    </div>
                                </PagerTemplate>
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre del Perfil" />
                                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <div class="col-md-3 col-md-offset-2 margenIconoMensaje">
                                                <asp:ImageButton ID="btn_Editar" runat="server" OnCommand="Editar_Command" ImageUrl="~/Imagenes/edit-32.png" Height="20px" CommandArgument='<%#Eval("ID")%>' />

                                            </div>
                                            <div class="col-md-3 col-md-offset-2 margenIconoMensaje">
                                                <asp:ImageButton ID="btn_Eliminar" runat="server" onclick="btn_Eliminar_Click" OnClientClick="return confirmDel();" ImageUrl="~/Imagenes/delete-32.png" Height="20px" CommandArgument='<%#Eval("ID")%>' />

                                            </div>
                                        </ItemTemplate>

                                        <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />
    <br />
</asp:Content>



