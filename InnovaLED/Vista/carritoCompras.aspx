<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="carritoCompras.aspx.vb" Inherits="Vista.carritoCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid fondoGris">

        <div id="alertvalid" runat="server" name="alertvalid" class="alert alert-danger  text-center" visible="false">
            <label runat="server" id="textovalid" class="text-danger"></label>
        </div>
        <div id="success" runat="server" name="success" class="alert alert-success  text-center" visible="false">
            <label id="lblsuccessCompra" class="text-success"></label>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-primary class">
                    <div class="panel-heading text-center">
                        <asp:Label ID="Lblpanelcarrito" runat="server" Text="MARKET" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                    </div>
                </div>
            </div>
        </div>


        <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>


        <div class="row">
            <div id="ID_Catalogo" runat="server" class="col-md-12">
            </div>

        </div>
        <br />
        <div class="panel-group">
            <div class="panel panel-primary col-md-5 col-md-offset-7">
                <div class="panel-heading">
                    <h3>Resumen de Saldo</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="row col-md-4 text-justify">
                            <h3>
                                <asp:Label ID="LbltotalApagarTit" runat="server" Text="Total a pagar:" CssClass="control-label labelform"></asp:Label></h3>
                        </div>
                        <div class="row col-md-3 text-right">
                            <h3>
                                <asp:Label ID="LbltotalApagar" runat="server" CssClass="control-label labelform"></asp:Label></h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="row col-md-4 text-justify">
                            <h3>
                                <asp:Label ID="lblTotalPendientePagoTit" runat="server" Text="Total Pendiente de Pago: " CssClass="control-label labelform"></asp:Label></h3>
                        </div>
                        <div class="row col-md-3 text-right">
                            <h3>
                                <asp:Label ID="lblTotalPendientePago" runat="server" Text="AR$ 0" CssClass="control-label labelform"></asp:Label></h3>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>


    <div class="row">
        <div class=" col-md-5">

            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">

                        <br />
                        <br />

                        <h3>
                            <asp:Label ID="LblmediopagoTit" runat="server" Text="Medios de Pago Disponibles:" CssClass="control-label labelform"></asp:Label></h3>
                        <br />
                        <asp:Label ID="Lblformapago" runat="server" Text="FORMA DE PAGO:" CssClass="control-label labelform"></asp:Label>
                        <div class="input-group col-md-12">
                            <asp:DropDownList ID="ddl_FormaPago" runat="server" CssClass="form-control" AutoPostBack="true">
                                <asp:ListItem Text="Tarjeta de Crédito" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Nota de Crédito" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div id="tarjetaCredito" runat="server" visible="false">
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label ID="Lbltarjetacred" runat="server" Text="TIPO DE TARJETA:" CssClass="control-label labelform"></asp:Label>
                            <div class="input-group">
                                <asp:DropDownList ID="lsttipotarj" runat="server" CssClass="form-control" AutoPostBack="true">
                                    <asp:ListItem Text="Visa" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="MasterCard" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Amex" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row" id="divvisa" runat="server" visible="false">
                            <asp:Image ID="imgvisa" runat="server" ImageUrl="~/IMAGENES/visa.png" CssClass="img-responsive" />
                        </div>
                        <div class="row" id="divmaster" runat="server" visible="false">
                            <asp:Image ID="imgmastercard" runat="server" ImageUrl="~/IMAGENES/mastercard.png" CssClass="img-responsive" />
                        </div>
                        <div class="row" id="divamex" runat="server" visible="false">
                            <asp:Image ID="imgamex" runat="server" ImageUrl="~/IMAGENES/amex.png" CssClass="img-responsive" />
                        </div>
                    </div>
                </div>

                <div class="row" runat="server" id="div_tjVisa">
                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:Label ID="LblNumTarj" runat="server" Text="NUMERO TARJETA:" CssClass="control-label labelform"></asp:Label>
                            <div class="input-group">
                                <asp:TextBox ID="txtnrotarjetaVisa" runat="server" placeholder="N° de Tarjeta" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon"><i class="fa fa-credit-card"></i></span>
                                <asp:RegularExpressionValidator ID="RE_Visa" runat="server" ErrorMessage="Nro invalido para Visa" ControlToValidate="txtnrotarjetaVisa"
                                    ValidationExpression="^4\d{3}-?\d{4}-?\d{4}-?\d{4}$" ForeColor="Red" Font-Bold="true"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row" runat="server" id="div_tjMaster1" visible="false">
                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="NUMERO TARJETA:" CssClass="control-label labelform"></asp:Label>
                            <div class="input-group">
                                <asp:TextBox ID="txtnrotarjetaMaster" runat="server" placeholder="N° de Tarjeta" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon"><i class="fa fa-credit-card"></i></span>

                                <asp:RegularExpressionValidator ID="RE_Master" runat="server" ErrorMessage="Nro invalido para Master" ControlToValidate="txtnrotarjetaMaster"
                                    ValidationExpression="^5[1-5]\d{2}-?\d{4}-?\d{4}-?\d{4}$" ForeColor="Red" Font-Bold="true"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="row" runat="server" id="div_tjAmex" visible="false">
                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="NUMERO TARJETA:" CssClass="control-label labelform"></asp:Label>
                            <div class="input-group">
                                <asp:TextBox ID="txtnrotarjetaAmex" runat="server" placeholder="N° de Tarjeta" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon"><i class="fa fa-credit-card"></i></span>
                                <asp:RegularExpressionValidator ID="RE_American" runat="server" ErrorMessage="Nro invalido para American" ControlToValidate="txtnrotarjetaAmex"
                                    ValidationExpression="^3[47][0-9]{13}$" ForeColor="Red" Font-Bold="true"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:Label ID="LblNomyApe" runat="server" Text="NOMBRE Y APELLIDO:" CssClass="control-label labelform"></asp:Label>
                            <div class="input-group">
                                <asp:TextBox ID="txtnomyape" runat="server" placeholder="Apellido y Nombre" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon"><i class="fa fa-user"></i></span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label ID="LblFechaExpiracion" runat="server" Text="FECHA EXPIRACIÓN:" CssClass="control-label labelform"></asp:Label>
                            <div class="input-group">
                                <asp:TextBox ID="txtexpiracion" runat="server" placeholder="MM/AAAA" CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Fechas Incorrectas" ControlToValidate="txtexpiracion"
                                    ValidationExpression="^((0[1-9])|(1[0-2]))\/(\d{4})$" ForeColor="Red" Font-Bold="true"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group  pull-right">
                            <asp:Label ID="LblCodSeg" runat="server" Text="CÓDIGO DE SEGURIDAD:" CssClass="control-label labelform"></asp:Label>
                            <div class="input-group">
                                <asp:TextBox ID="txtCodSeg" runat="server" placeholder="CVC" CssClass="form-control"></asp:TextBox>
                                <%--    <asp:RegularExpressionValidator ID="RE_TJ_CVV" runat="server" ErrorMessage="Codigo Incorrecto" ControlToValidate="txtCodSeg"
                                                ValidationExpression="/^[0-9]{3,4}$/" ForeColor="Red" Font-Bold="true" ></asp:RegularExpressionValidator>    --%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" id="Div_Cargando" runat="server" visible="false">
                <div class="col-md-7">
                    <h3>
                        <asp:Label ID="lblcargando" runat="server" Text="Aguarde por favor..." CssClass="control-label labelform"></asp:Label>
                        <i class="fa fa-spinner fa-spin" style="font-size: 36px"></i>
                    </h3>
                    <%--<div class="row col-md-offset-5">
                    </div>--%>
                </div>
            </div>
            <br />
            <br />

            <div class="row">
                 <div class="row col-md-3">
                    <asp:Button ID="btn_aceptar" runat="server" Text="Confirmar Pago" class="btn btn-success btn-lg" Visible="false"></asp:Button>
                </div>

               <%-- <div class="row col-md-3">
                    <button class="btn btn-success btn-lg" text="Confirmar Pago" runat="server" id="btn_aceptar" visible="false">
                        <span class="spinner-border spinner-border-sm"></span>
                    </button>
                </div>--%>

                <div class="row col-md-3 col-md-offset-2">
                    <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar Pago" class="btn btn-warning btn-lg" Visible="false"></asp:Button>
                </div>

            </div>
            <br />
            <br />



        </div>



        <%-- ACA ARRANCA LA GRILLA DE NOTAS DE CREDITO--%>



        <div class=" col-md-5 col-md-offset-1" id="gv_div" runat="server" visible="false">
            <br />
            <br />
            <h3>
                <asp:Label ID="lblNotasDispTit" runat="server" Text="Notas de Crédito Disponible:" CssClass="control-label labelform "></asp:Label></h3>
            <br />

            <asp:GridView CssClass="table table-hover table-bordered table-responsive table-default " ID="gv_notacredito" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="10" OnPageIndexChanging="gv_notacredito_PageIndexChanging" RowStyle-Height="40px">
                <HeaderStyle CssClass="thead-dark" />
                <PagerTemplate>
                    <div class="col-md-4 text-left">
                        <asp:Label ID="lblmostrarpag" runat="server" Text="Mostrar Pagina"></asp:Label>
                        <asp:DropDownList ID="ddlPaging" runat="server" AutoPostBack="true" CssClass="margenPaginacion" OnSelectedIndexChanged="ddlPaging_SelectedIndexChanged" />
                        <asp:Label ID="lblde" runat="server" Text="de"></asp:Label>
                        <asp:Label ID="lbltotalpages" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-md-6 col-md-offset-2">
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
                    <asp:BoundField DataField="ID" HeaderText="Nro Nota" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                    <asp:BoundField DataField="Monto" HeaderText="Monto" />
                    <asp:TemplateField HeaderText="Seleccionar" HeaderStyle-Width="100px">
                        <ItemTemplate>
                            <div>
                                <asp:ImageButton ID="btn_Seleccionar" runat="server" CommandName="S" ImageUrl="~/Imagenes/check.png" Height="18px" />
                            </div>
                        </ItemTemplate>
                        <HeaderStyle Width="100px"></HeaderStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div class="row">
                <div class="row col-md-4">
                    <h3>
                        <asp:Label ID="lbltotalnotascTit" runat="server" Text="Total Notas Cred: " CssClass="control-label labelform"></asp:Label></h3>
                </div>
                <div class="row col-md-3 col-md-offset-1">
                    <h3>
                        <asp:Label ID="lbltotalnotasC" runat="server" CssClass="control-label labelform"></asp:Label></h3>
                </div>
            </div>
            <div class="row">
                <div class="row col-md-4">
                    <h3>
                        <asp:Label ID="lbltotalnotaselectTit" runat="server" Text="Total Notas Cred Seleccionadas: " CssClass="control-label labelform"></asp:Label></h3>
                </div>
                <div class="row col-md-3 col-md-offset-1">
                    <h3>
                        <asp:Label ID="lbltotalnotaselec" runat="server" Text="AR$ 0" CssClass="control-label labelform"></asp:Label></h3>
                </div>
            </div>


            <div class="row col-md-5">
                <asp:Button ID="btn_seguircontj" runat="server" Text="Continuar el Pago con Tarjeta" class="btn btn-warning btn-lg"></asp:Button>
            </div>
            <br />
            <br />
            <br />
        </div>



    </div>

    <%--</div>--%>



    <br />
    <asp:Label ID="Label3" runat="server"></asp:Label>
    <br />

    <%--  </ContentTemplate>
   </asp:UpdatePanel> --%>
</asp:Content>
