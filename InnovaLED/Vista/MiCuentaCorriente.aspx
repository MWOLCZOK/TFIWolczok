<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="MiCuentaCorriente.aspx.vb" Inherits="Vista.MiCuentaCorriente" %>



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
                        <asp:Label ID="lblPanelModUser" runat="server" Text="Mi Cuenta Corriente" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                    </div>
                </div>
            </div>
            <br />
            <br />


            <div class="panel-group col-md-12">
                <div class="panel-default">
                    <hr />
                    <div class="panel-heading text-center">Cuenta Corriente</div>
                    <hr />
                    <div class="panel-body">

                        <div class="col-md-12  justify-content-center">
                            <asp:GridView CssClass="table table-hover table-bordered table-responsive table-active text-center" ID="gv_facturas" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="10" OnPageIndexChanging="gv_facturas_PageIndexChanging" RowStyle-Height="40px">
                                <HeaderStyle CssClass="thead-dark " />
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
                                    <asp:BoundField DataField="NroDoc" HeaderText="Numero Documento" />
                                    <asp:BoundField DataField="FechaEmision" HeaderText="Fecha de Emisión" />
                                    <asp:BoundField DataField="Documento" HeaderText="Tipo de Documento" />
                                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion"/> 
                                    <asp:BoundField DataField="Debe" HeaderText="Debe"  DataFormatString="{0:C1}" />
                                    <asp:BoundField DataField="Haber" HeaderText="Haber"  DataFormatString="{0:C1}"/>
                                    <asp:TemplateField HeaderText="Descarga" HeaderStyle-Width="100px">
                                        
                                        <ItemTemplate>
                                            <div>
                                                <asp:ImageButton ID="btn_descargar" runat="server" CommandName="D" ImageUrl="~/Imagenes/Download.png" Height="18px" Visible="true" />
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


          <asp:HiddenField ID="ID_MiCC" runat="server" />

    </div>



</asp:Content>



