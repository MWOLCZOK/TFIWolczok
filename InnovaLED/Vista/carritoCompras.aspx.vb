Imports Entidades
Imports Negocio
Imports System.Web.HttpContext



Public Class carritoCompras
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Session("notaSeleccionadas") = New List(Of Entidades.DocumentoFinancieroEntidad)
                If IsNothing(Session("Carrito")) Then
                    'carrito vacio
                Else
                    GenerarDiseño(Session("carrito"))
                End If
                ddl_FormaPago.SelectedValue = 1
                ddl_FormaPago_SelectedIndexChanged(Nothing, Nothing)
                lsttipotarj.SelectedValue = 1
                lsttipotarj_SelectedIndexChanged(Nothing, Nothing)
                CargarNC()
                SumarTotalaPagar()

            Else
                If IsNumeric(Request.QueryString("carrid")) Then
                    Dim list As List(Of CompraEntidad) = Session("carrito")
                    list.Remove(list.Find(Function(p) p.Producto.ID_Producto = Request.QueryString("carrid")))
                End If
                GenerarDiseño(Session("carrito"))

            End If
        Catch ex As Exception
        End Try

    End Sub


    Private Sub GenerarDiseño(ByVal listaproductos As List(Of CompraEntidad))
        ID_Catalogo.Controls.Clear()
        ID_Catalogo.Controls.Add(New LiteralControl("<table id=""cart"" class=""table table-hover table-condensed"">"))
        ID_Catalogo.Controls.Add(New LiteralControl("<tbody>"))


        For Each prod In listaproductos
            ID_Catalogo.Controls.Add(New LiteralControl("<tr>"))
            ID_Catalogo.Controls.Add(New LiteralControl("<td data-th=""Product"">"))
            ID_Catalogo.Controls.Add(New LiteralControl("<div class=""row"">"))
            ID_Catalogo.Controls.Add(New LiteralControl("<div Class=""col-md-1"">"))

            Dim base64string As String = Convert.ToBase64String(prod.Producto.Imagen, 0, prod.Producto.Imagen.Length)
            ID_Catalogo.Controls.Add(New LiteralControl("<img src=" & Convert.ToString("data:image/jpg;base64,") & base64string & " alt=""..."" class=""img-responsive""/>"))
            ID_Catalogo.Controls.Add(New LiteralControl("</div>"))
            ID_Catalogo.Controls.Add(New LiteralControl("<div class=""col-md-5 left"">"))
            ID_Catalogo.Controls.Add(New LiteralControl("<h3>" & prod.Producto.Modelo & "</h3>"))
            ID_Catalogo.Controls.Add(New LiteralControl("<h4>" & prod.Producto.Descripcion & "</h4>"))
            ID_Catalogo.Controls.Add(New LiteralControl("</div>"))
            ID_Catalogo.Controls.Add(New LiteralControl("<div class=""col-md-2"">"))
            ID_Catalogo.Controls.Add(New LiteralControl("<h3>" & prod.Cantidad & "</h3>"))
            ID_Catalogo.Controls.Add(New LiteralControl("</div>"))
            ID_Catalogo.Controls.Add(New LiteralControl("<div class=""col-md-2"">"))
            ID_Catalogo.Controls.Add(New LiteralControl("<h3>" & "AR$ " & prod.Producto.Precio & "</h3>"))
            ID_Catalogo.Controls.Add(New LiteralControl("</div>"))


            Dim div As HtmlGenericControl = New HtmlGenericControl("div")
            div.Attributes.Add("class", "col-md-2")
            Dim ImgBut As New ImageButton() ' Creamos una imagen que funciona como botón.

            ImgBut.ImageUrl = "IMAGENES\cart.png"
            ImgBut.Width = 50
            ImgBut.CssClass = "media-object"
            ImgBut.PostBackUrl = "/carritoCompras.aspx" & "?carrid=" & prod.Producto.ID_Producto ' le pasamos por query string el ID de producto a la página del detalleProducto.
            div.Controls.Add(ImgBut)
            ID_Catalogo.Controls.Add(div)
            ID_Catalogo.Controls.Add(New LiteralControl("</td>"))
            ID_Catalogo.Controls.Add(New LiteralControl("</tr>"))

        Next

        ID_Catalogo.Controls.Add(New LiteralControl("</tbody>"))
        ID_Catalogo.Controls.Add(New LiteralControl("</table>"))

    End Sub


    Protected Sub ddl_FormaPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_FormaPago.SelectedIndexChanged
        If Me.ddl_FormaPago.SelectedValue = 1 Then
            Me.tarjetaCredito.Visible = True
            Me.btn_aceptar.Visible = True
            Me.btn_cancelar.Visible = True
            Me.gv_div.Visible = False

        Else
            Me.tarjetaCredito.Visible = False
            Me.gv_div.Visible = True
            SumarNotasC()

        End If
    End Sub

    Protected Sub lsttipotarj_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsttipotarj.SelectedIndexChanged
        If Me.lsttipotarj.SelectedValue = 1 Then
            Me.divvisa.Visible = True
            Me.divmaster.Visible = False
            Me.divamex.Visible = False
            Me.div_tjVisa.Visible = True
            Me.div_tjMaster1.Visible = False
            Me.div_tjAmex.Visible = False


        ElseIf Me.lsttipotarj.SelectedValue = 2 Then
            Me.divmaster.Visible = True
            Me.divvisa.Visible = False
            Me.divamex.Visible = False

            Me.div_tjVisa.Visible = False
            Me.div_tjMaster1.Visible = True
            Me.div_tjAmex.Visible = False
        Else
            Me.lsttipotarj.SelectedValue = 3
            Me.divamex.Visible = True
            Me.divvisa.Visible = False
            Me.divmaster.Visible = False

            Me.div_tjVisa.Visible = False
            Me.div_tjMaster1.Visible = False
            Me.div_tjAmex.Visible = True

        End If

    End Sub

    Private Sub ValidacionFecha()

    End Sub


    Protected Sub btn_aceptar_Click(sender As Object, e As EventArgs) Handles btn_aceptar.Click
        Try
            Dim listnota As List(Of DocumentoFinancieroEntidad) = TryCast(Session("notaSeleccionadas"), List(Of DocumentoFinancieroEntidad))
            Dim cli As UsuarioEntidad = TryCast(Session("cliente"), UsuarioEntidad)
            Dim compra As CompraEntidad = TryCast(Session("carrito"), CompraEntidad)
            Dim EstadoCompra As EstadoCompraEntidad = EstadoCompraEntidad.Aprobado


            Dim listcompra As List(Of CompraEntidad) = TryCast(Session("carrito"), List(Of CompraEntidad))

            Dim factura As New FacturaEntidad(cli, listcompra, listnota, Now, 1)
            Dim GestorFacturaBLL As New GestorFacturaBLL
            If ValidarCampos() = True And validarFecha() = True then
                GestorFacturaBLL.GenerarFactura(factura)
            End If

            'If ValidarCampos() = True And listnota.Count > 0 Then
            '    'la parte del tipo de pago

            'End If



            'Dim pago As New PagoEntidad
            'Dim GestorPagoBLL As New GestorPagoBLL
            'GestorPagoBLL.Alta(pago)


        Catch ex As Exception

        End Try

    End Sub


    Private Sub gv_notacredito_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gv_notacredito.RowCommand
        Try
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If
            Dim nc As DocumentoFinancieroEntidad = TryCast(Session("nota"), List(Of DocumentoFinancieroEntidad))(e.CommandArgument + (gv_notacredito.PageIndex * gv_notacredito.PageSize))
            Select Case e.CommandName.ToString
                Case "S"
                    If TryCast(Session("notaSeleccionadas"), List(Of DocumentoFinancieroEntidad)).Any(Function(p) p.ID = nc.ID) Then
                        gv_notacredito.Rows.Item(e.CommandArgument).BackColor = Drawing.Color.FromName("#ffffff")
                        TryCast(Session("notaSeleccionadas"), List(Of DocumentoFinancieroEntidad)).Remove(nc)
                        Dim imagen3 As System.Web.UI.WebControls.ImageButton = DirectCast(gv_notacredito.Rows.Item(e.CommandArgument).FindControl("btn_seleccionar"), System.Web.UI.WebControls.ImageButton)
                        imagen3.ImageUrl = "~/Imagenes/check.png"
                    Else
                        gv_notacredito.Rows.Item(e.CommandArgument).BackColor = Drawing.Color.SkyBlue
                        TryCast(Session("notaSeleccionadas"), List(Of DocumentoFinancieroEntidad)).Add(nc)
                        Dim imagen3 As System.Web.UI.WebControls.ImageButton = DirectCast(gv_notacredito.Rows.Item(e.CommandArgument).FindControl("btn_seleccionar"), System.Web.UI.WebControls.ImageButton)
                        imagen3.ImageUrl = "~/Imagenes/clear.png"
                    End If
                    SumarNotasCseleccionadas()
                    GenerarPago()
                    ValidarDiferenciaNotaC()
            End Select
        Catch ex As Exception
            'Dim clienteLogeado As Entidades.UsuarioEntidad = Current.Session("cliente")
            'Dim Bitac As New Entidades.BitacoraErrores(clienteLogeado, ex.Message, Entidades.Tipo_Bitacora.Errores, Now, Request.UserAgent, Request.UserHostAddress, ex.StackTrace, ex.GetType().ToString, Request.Url.ToString)
            'Negocio.BitacoraBLL.CrearBitacora(Bitac)
        End Try
    End Sub


    Private Sub gv_notacredito_DataBound(sender As Object, e As EventArgs) Handles gv_notacredito.DataBound
        Try
            Try
                Dim ddl2 As DropDownList = CType(gv_notacredito.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            Catch ex As Exception
                Return
            End Try

            Dim ddl As DropDownList = CType(gv_notacredito.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            Dim ddlpage As DropDownList = CType(gv_notacredito.BottomPagerRow.Cells(0).FindControl("ddlPageSize"), DropDownList)
            Dim txttotal As Label = CType(gv_notacredito.BottomPagerRow.Cells(0).FindControl("lbltotalpages"), Label)

            ddlpage.ClearSelection()
            ddlpage.Items.FindByValue(gv_notacredito.PageSize).Selected = True

            txttotal.Text = gv_notacredito.PageCount

            For cnt As Integer = 0 To gv_notacredito.PageCount - 1
                Dim curr As Integer = cnt + 1
                Dim item As New ListItem(curr.ToString())
                If cnt = gv_notacredito.PageIndex Then
                    item.Selected = True
                End If

                ddl.Items.Add(item)

            Next cnt

            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If
            For Each row As GridViewRow In gv_notacredito.Rows
                Dim imagen3 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_seleccionar"), System.Web.UI.WebControls.ImageButton)
                imagen3.CommandArgument = row.RowIndex
            Next

            'With gv_notacredito.HeaderRow
            '    .Cells(0).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderNombre").Traduccion
            '    .Cells(1).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderCUIL").Traduccion
            '    .Cells(2).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderCorreo").Traduccion
            '    .Cells(3).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderAcciones").Traduccion
            'End With

            gv_notacredito.BottomPagerRow.Visible = True
            gv_notacredito.BottomPagerRow.CssClass = "table-bottom-dark"
        Catch ex As Exception
            'Dim clienteLogeado As Entidades.UsuarioEntidad = Current.Session("cliente")
            'Dim Bitac As New Entidades.BitacoraErrores(clienteLogeado, ex.Message, Entidades.Tipo_Bitacora.Errores, Now, Request.UserAgent, Request.UserHostAddress, ex.StackTrace, ex.GetType().ToString, Request.Url.ToString)
            'Negocio.BitacoraBLL.CrearBitacora(Bitac)
        End Try

    End Sub

    Protected Sub gv_notacredito_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            CargarNC()
            gv_notacredito.PageIndex = e.NewPageIndex
            gv_notacredito.DataBind()
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub ddlPaging_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim ddl As DropDownList = CType(gv_notacredito.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            gv_notacredito.SetPageIndex(ddl.SelectedIndex)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ddlPageSize_SelectedPageSizeChanged(sender As Object, e As EventArgs)
        Try
            Dim ddl As DropDownList = CType(gv_notacredito.BottomPagerRow.Cells(0).FindControl("ddlPageSize"), DropDownList)
            gv_notacredito.PageSize = ddl.SelectedValue
            CargarNC()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarNC()

        Dim usu As New UsuarioEntidad
        'Session("cliente") = usu
        usu = Session("cliente")
        Dim listaNC As List(Of DocumentoFinancieroEntidad)

        Dim GestorNC As New GestorDocFinancieroBLL
        listaNC = GestorNC.TraerDocumentoF(usu)
        If listaNC.Count > 0 Then
            Session("nota") = listaNC
            Me.gv_notacredito.DataSource = listaNC
            Me.gv_notacredito.DataBind()
            ' para llenar la grilla, el ID de la grilla tiene que ser el mismo que la Clase!!!!!

        End If


    End Sub

    Public Function SumarNotasC()
        Dim sum As Single
        Dim lstnc As List(Of DocumentoFinancieroEntidad)
        lstnc = Session("nota")
        For Each nc In lstnc
            sum = sum + nc.Monto
            lbltotalnotasC.Text = "AR$ " & sum
            Session("notaTotal") = sum
        Next
        Return sum

    End Function

    Public Function SumarNotasCseleccionadas()
        Dim sum As Single
        Dim lstnc As List(Of DocumentoFinancieroEntidad)
        lstnc = Session("notaSeleccionadas")
        For Each nc In lstnc
            sum = sum + nc.Monto
            lbltotalnotaselec.Text = "AR$ " & sum
            Session("notasSeleccionadasTotal") = sum

            Dim varActualizacionNota As Single
            Dim notaTotal As Single
            notaTotal = Session("notaTotal")
            varActualizacionNota = notaTotal - sum
            lbltotalnotasC.Text = "AR$ " & varActualizacionNota



        Next
        Return sum

    End Function


    Public Function SumarTotalaPagar()
        Dim sum As Single
        Dim lstsum As List(Of CompraEntidad)
        lstsum = Session("carrito")
        For Each compra In lstsum
            sum = sum + compra.Producto.Precio
            LbltotalApagar.Text = "AR$ " & sum
            lblTotalPendientePago.Text = "AR$ " & sum
            Session("totalApagar") = sum
        Next
        Return sum
    End Function


    Public Function GenerarPago()
        Dim tot As Single
        Dim varTotal As Single
        Dim varTotalnotas As Single
        varTotal = Session("totalApagar")
        Dim varNotaSeleccionadas As Single
        varNotaSeleccionadas = Session("notasSeleccionadasTotal")
        tot = varTotal - varNotaSeleccionadas
        lblTotalPendientePago.Text = "AR$ " & tot

        Return tot

    End Function


    Protected Sub btn_seguircontj_Click(sender As Object, e As EventArgs) Handles btn_seguircontj.Click
        Me.tarjetaCredito.Visible = True
        Me.gv_div.Visible = True
        Me.ddl_FormaPago.SelectedValue = 1
    End Sub



    Public Function ValidarCampos() As Boolean
        If Me.lsttipotarj.SelectedValue = 1 Then
            ValidarCamposVisa()
            Return True
        ElseIf lsttipotarj.SelectedValue = 2 Then
            ValidarCamposMaster()
            Return True
        Else
            ValidarCamposAmex()
            Return True
        End If
        Return False

    End Function


    Public Function ValidarCamposVisa() As Boolean
        If txtnrotarjetaVisa.Text <> "" And txtexpiracion.Text <> "" And txtCodSeg.Text <> "" Then
            Return True
        Else
            Me.alertvalid.Visible = True
            Me.success.Visible = False
            Me.alertvalid.InnerText = "Debe completar todos los campos de la tarjeta para finalizar la compra."
        End If
        Return False
    End Function

    Public Function ValidarCamposMaster() As Boolean
        If txtnrotarjetaMaster.Text <> "" And txtexpiracion.Text <> "" And txtCodSeg.Text <> "" Then
            Return True
        Else
            Me.alertvalid.Visible = True
            Me.success.Visible = False
            Me.alertvalid.InnerText = "Debe completar todos los campos de la tarjeta para finalizar la compra."
        End If
        Return False
    End Function

    Public Function ValidarCamposAmex() As Boolean
        If txtnrotarjetaAmex.Text <> "" And txtexpiracion.Text <> "" And txtCodSeg.Text <> "" Then
            Return True
        Else
            Me.alertvalid.Visible = True
            Me.success.Visible = False
            Me.alertvalid.InnerText = "Debe completar todos los campos de la tarjeta para finalizar la compra."
        End If
        Return False
    End Function

    Private Function validarFecha() As Boolean
        Dim mes As Integer = CInt(Left(Me.txtexpiracion.Text, 2))
        Dim ano As Integer = CInt(Right(Me.txtexpiracion.Text, 4))
        If mes > 12 Then
            Return False
        End If
        If ano > Today.Year Then
            Return True
        End If
        Return True
    End Function


    Public Function ValidarDiferenciaNotaC()
        Dim varTotal As Single
        varTotal = Session("totalApagar")
        Dim varNotasSeleccionadas As Single
        varNotasSeleccionadas = Session("notasSeleccionadasTotal")
        If varTotal < varNotasSeleccionadas Then
            txtdescripnota.Visible = True
        Else
            txtdescripnota.Visible = False
        End If

        Return True

    End Function








End Class