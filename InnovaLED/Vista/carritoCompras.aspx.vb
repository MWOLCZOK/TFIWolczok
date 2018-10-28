Imports Entidades
Imports Negocio
Imports System.Web.HttpContext



Public Class carritoCompras
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If IsNothing(Session("Carrito")) Then
                'carrito vacio
            Else
                GenerarDiseño(Session("carrito"))
            End If
            ddl_FormaPago.SelectedValue = 1
            ddl_FormaPago_SelectedIndexChanged(Nothing, Nothing)
            lsttipotarj.SelectedValue = 1
            lsttipotarj_SelectedIndexChanged(Nothing, Nothing)
        Else
            If IsNumeric(Request.QueryString("carrid")) Then
                Dim list As List(Of CompraEntidad) = Session("carrito")
                list.Remove(list.Find(Function(p) p.Producto.ID_Producto = Request.QueryString("carrid")))
            End If
            GenerarDiseño(Session("carrito"))

        End If

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
        Else
            Me.tarjetaCredito.Visible = False

        End If
    End Sub

    Protected Sub lsttipotarj_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsttipotarj.SelectedIndexChanged
        If Me.lsttipotarj.SelectedValue = 1 Then
            Me.divvisa.Visible = True
            Me.divmaster.Visible = False
            Me.divamex.Visible = False

        ElseIf Me.lsttipotarj.SelectedValue = 2 Then
            Me.divmaster.Visible = True
            Me.divvisa.Visible = False
            Me.divamex.Visible = False
        Else
            Me.lsttipotarj.SelectedValue = 3
            Me.divamex.Visible = True
            Me.divvisa.Visible = False
            Me.divmaster.Visible = False

        End If

    End Sub

    Private Sub ValidacionFecha()

    End Sub


    Protected Sub btn_aceptar_Click(sender As Object, e As EventArgs) Handles btn_aceptar.Click
        'Try
        '    Dim formaPago As Integer = CInt(Me.ddl_FormaPago.SelectedValue)
        '    'Dim _listaNota As New List(Of Entidades.Nota)
        '    If Me.ddl_FormaPago.SelectedValue = 1 Then
        '        formaPago = 1
        '    End If
        '    If Me.ddl_FormaPago.SelectedValue = 2 Then
        '        formaPago = 2
        '        'validaciones.validarSubmit(Me, Me.Error, Me.lbl_TituloError)
        '    End If
        '    If Me.ddl_FormaPago.SelectedValue = 3 Then
        '        If Me.ddl_FormaPago2.Visible = True Then
        '            formaPago = CInt(Me.ddl_FormaPago2.SelectedValue)
        '        Else
        '            formaPago = 3
        '        End If
        '        _listaNota = DirectCast(Session("listaCredito"), List(Of Entidades.Nota))
        '        'validaciones.validarSubmit(Me, Me.Error, Me.lbl_TituloError)
        '    End If
        '    Dim _nroFactura As Integer = _gestorCarrera.adquirirCarrera(validaciones.obtenerAlumno(), obtenerCarreraSeleccionada(), formaPago, _listaNota)
        '    Session("nroFactura") = _nroFactura
        '    Response.Redirect("compraRealizada.aspx")
        'Catch ex As Exception
        'End Try
    End Sub


    Private Sub gv_sponsors_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gv_sponsors.RowCommand
        Try
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If
            Dim nc As DocumentoFinanciero = TryCast(Session("notacredito"), List(Of DocumentoFinanciero))(e.CommandArgument + (gv_sponsors.PageIndex * gv_sponsors.PageSize))
            Select Case e.CommandName.ToString
                Case "S"
                    If TryCast(Session("ncseleccionada"), List(Of DocumentoFinanciero)).Any(Function(p) p.ID = nc.ID) Then
                        gv_sponsors.Rows.Item(e.CommandArgument).BackColor = Drawing.Color.FromName("#c3e6cb")
                        TryCast(Session("ncseleccionada"), List(Of DocumentoFinanciero)).Remove(nc)
                        Dim imagen3 As System.Web.UI.WebControls.ImageButton = DirectCast(gv_sponsors.Rows.Item(e.CommandArgument).FindControl("btn_seleccionar"), System.Web.UI.WebControls.ImageButton)
                        imagen3.ImageUrl = "~/Imagenes/check.png"
                    Else
                        gv_sponsors.Rows.Item(e.CommandArgument).BackColor = Drawing.Color.Cyan
                        TryCast(Session("ncseleccionada"), List(Of DocumentoFinanciero)).Add(nc)
                        Dim imagen3 As System.Web.UI.WebControls.ImageButton = DirectCast(gv_sponsors.Rows.Item(e.CommandArgument).FindControl("btn_seleccionar"), System.Web.UI.WebControls.ImageButton)
                        imagen3.ImageUrl = "~/Imagenes/clear.png"
                    End If


            End Select
        Catch ex As Exception
            'Dim clienteLogeado As Entidades.UsuarioEntidad = Current.Session("cliente")
            'Dim Bitac As New Entidades.BitacoraErrores(clienteLogeado, ex.Message, Entidades.Tipo_Bitacora.Errores, Now, Request.UserAgent, Request.UserHostAddress, ex.StackTrace, ex.GetType().ToString, Request.Url.ToString)
            'Negocio.BitacoraBLL.CrearBitacora(Bitac)
        End Try
    End Sub


    Private Sub gv_Sponsors_DataBound(sender As Object, e As EventArgs) Handles gv_sponsors.DataBound
        Try
            Try
                Dim ddl2 As DropDownList = CType(gv_sponsors.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            Catch ex As Exception
                Return
            End Try

            Dim ddl As DropDownList = CType(gv_sponsors.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            Dim ddlpage As DropDownList = CType(gv_sponsors.BottomPagerRow.Cells(0).FindControl("ddlPageSize"), DropDownList)
            Dim txttotal As Label = CType(gv_sponsors.BottomPagerRow.Cells(0).FindControl("lbltotalpages"), Label)

            ddlpage.ClearSelection()
            ddlpage.Items.FindByValue(gv_sponsors.PageSize).Selected = True

            txttotal.Text = gv_sponsors.PageCount

            For cnt As Integer = 0 To gv_sponsors.PageCount - 1
                Dim curr As Integer = cnt + 1
                Dim item As New ListItem(curr.ToString())
                If cnt = gv_sponsors.PageIndex Then
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
            For Each row As GridViewRow In gv_sponsors.Rows
                Dim imagen3 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_seleccionar"), System.Web.UI.WebControls.ImageButton)
                imagen3.CommandArgument = row.RowIndex
            Next

            'With gv_sponsors.HeaderRow
            '    .Cells(0).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderNombre").Traduccion
            '    .Cells(1).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderCUIL").Traduccion
            '    .Cells(2).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderCorreo").Traduccion
            '    .Cells(3).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderAcciones").Traduccion
            'End With

            gv_sponsors.BottomPagerRow.Visible = True
            gv_sponsors.BottomPagerRow.CssClass = "table-bottom-dark"
        Catch ex As Exception
            'Dim clienteLogeado As Entidades.UsuarioEntidad = Current.Session("cliente")
            'Dim Bitac As New Entidades.BitacoraErrores(clienteLogeado, ex.Message, Entidades.Tipo_Bitacora.Errores, Now, Request.UserAgent, Request.UserHostAddress, ex.StackTrace, ex.GetType().ToString, Request.Url.ToString)
            'Negocio.BitacoraBLL.CrearBitacora(Bitac)
        End Try

    End Sub

    Protected Sub gv_sponsors_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            'CargarSponsors()
            gv_sponsors.PageIndex = e.NewPageIndex
            gv_sponsors.DataBind()
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub ddlPaging_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim ddl As DropDownList = CType(gv_sponsors.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            gv_sponsors.SetPageIndex(ddl.SelectedIndex)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ddlPageSize_SelectedPageSizeChanged(sender As Object, e As EventArgs)
        Try
            Dim ddl As DropDownList = CType(gv_sponsors.BottomPagerRow.Cells(0).FindControl("ddlPageSize"), DropDownList)
            gv_sponsors.PageSize = ddl.SelectedValue
            'CargarSponsors()
        Catch ex As Exception

        End Try
    End Sub










End Class