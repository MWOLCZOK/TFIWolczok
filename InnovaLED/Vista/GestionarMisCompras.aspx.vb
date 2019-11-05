Imports Entidades
Imports Negocio
Imports System.Web.HttpContext





Public Class GestionMisCompras
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Session("FactCanceladaSeleccionada") = New List(Of FacturaEntidad)
                CargarFacturas()
                CargarNotasCredito()
                SumarNotasC()
            Catch ex As Exception

            End Try

        End If
    End Sub

    Dim FacturaBLL As New GestorFacturaBLL


    Private Sub CargarFacturas()
        Dim listaFacturas As New List(Of FacturaEntidad)
        Dim GestorFacturas As New GestorFacturaBLL
        Dim usu As New UsuarioEntidad
        usu = Session("cliente")
        listaFacturas = GestorFacturas.TraerFacturasGestionPorUsuario(usu)
        If listaFacturas.Count > 0 Then
            Session("FacturasUsuario") = listaFacturas
            gv_facturas.DataSource = listaFacturas
            gv_facturas.DataBind()
        End If
    End Sub

    Private Sub gv_facturas_DataBound(sender As Object, e As EventArgs) Handles gv_facturas.DataBound
        Try

            Try
                Dim ddl2 As DropDownList = CType(gv_facturas.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            Catch ex As Exception
                Return
            End Try

            Dim ddl As DropDownList = CType(gv_facturas.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            Dim ddlpage As DropDownList = CType(gv_facturas.BottomPagerRow.Cells(0).FindControl("ddlPageSize"), DropDownList)
            Dim txttotal As Label = CType(gv_facturas.BottomPagerRow.Cells(0).FindControl("lbltotalpages"), Label)

            ddlpage.ClearSelection()
            ddlpage.Items.FindByValue(gv_facturas.PageSize).Selected = True

            txttotal.Text = gv_facturas.PageCount

            For cnt As Integer = 0 To gv_facturas.PageCount - 1
                Dim curr As Integer = cnt + 1
                Dim item As New ListItem(curr.ToString())
                If cnt = gv_facturas.PageIndex Then
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
            For Each row As GridViewRow In gv_facturas.Rows
                If row.Cells(4).Text = "Rechazado" Then
                    Dim cell6 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Seleccionar"), System.Web.UI.WebControls.ImageButton)
                    cell6.Visible = False
                ElseIf row.Cells(5).Text = "PendienteCancelacion" Then
                    Dim cell6 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Seleccionar"), System.Web.UI.WebControls.ImageButton)
                    cell6.Visible = False
                End If

                Dim imagen1 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Seleccionar"), System.Web.UI.WebControls.ImageButton)

                imagen1.CommandArgument = row.RowIndex

                Dim imagen2 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_descargar"), System.Web.UI.WebControls.ImageButton)

                imagen2.CommandArgument = row.RowIndex
            Next

            With gv_facturas.HeaderRow
                '.Cells(0).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderID").Traduccion
                '.Cells(1).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderNombreUsuario").Traduccion
                '.Cells(2).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderIdioma").Traduccion
                '.Cells(3).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderBloqueo").Traduccion
                '.Cells(4).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderEmpleado").Traduccion
                '.Cells(5).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderFechaAlta").Traduccion
                '.Cells(6).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderAcciones").Traduccion
            End With


            gv_facturas.BottomPagerRow.Visible = True
            gv_facturas.BottomPagerRow.CssClass = "table-bottom-dark"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gv_facturas_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gv_facturas.RowCommand

        Try
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If

            Select Case e.CommandName.ToString
                Case "S"
                    Dim fact As FacturaEntidad = TryCast(Session("FacturasUsuario"), List(Of FacturaEntidad))(e.CommandArgument + (gv_facturas.PageIndex * gv_facturas.PageSize))
                    If TryCast(Session("FactCanceladaSeleccionada"), List(Of FacturaEntidad)).Any(Function(p) p.ID = fact.ID) Then
                        TryCast(Session("FactCanceladaSeleccionada"), List(Of FacturaEntidad)).Remove(fact)
                        Dim imagen1 As System.Web.UI.WebControls.ImageButton = DirectCast(gv_facturas.Rows.Item(e.CommandArgument).FindControl("btn_seleccionar"), System.Web.UI.WebControls.ImageButton) ' aca hace referencia al boton de la grilla.
                        imagen1.ImageUrl = "~/Imagenes/check.png"
                        gv_facturas.Rows.Item(e.CommandArgument).BackColor = Drawing.Color.FromName("#c3e6cb")
                    Else
                        TryCast(Session("FactCanceladaSeleccionada"), List(Of FacturaEntidad)).Add(fact)
                        gv_facturas.Rows.Item(e.CommandArgument).BackColor = Drawing.Color.SkyBlue
                        Dim imagen1 As System.Web.UI.WebControls.ImageButton = DirectCast(gv_facturas.Rows.Item(e.CommandArgument).FindControl("btn_seleccionar"), System.Web.UI.WebControls.ImageButton)
                        imagen1.ImageUrl = "~/Imagenes/clear.png"
                    End If
                    If TryCast(Session("FactCanceladaSeleccionada"), List(Of FacturaEntidad)).Count > 0 Then
                        btn_cancelacion.Visible = True
                    Else
                        btn_cancelacion.Visible = False
                    End If

                Case "D"
                    Dim fact As FacturaEntidad = TryCast(Session("FacturasUsuario"), List(Of FacturaEntidad))(e.CommandArgument + (gv_facturas.PageIndex * gv_facturas.PageSize))

                    Response.ContentType = "application/octet-stream"
                    Response.AppendHeader("Content-Disposition", "attachment; filename=Factura_" & Right("0000" & fact.ID, 4) + ".pdf")
                    Response.BinaryWrite(fact.PDF)
                    Response.Flush()





            End Select
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gv_facturas_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            CargarFacturas()
            gv_facturas.PageIndex = e.NewPageIndex
            gv_facturas.DataBind()
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub ddlPaging_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim ddl As DropDownList = CType(gv_facturas.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            gv_facturas.SetPageIndex(ddl.SelectedIndex)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ddlPageSize_SelectedPageSizeChanged(sender As Object, e As EventArgs)
        Try
            Dim ddl As DropDownList = CType(gv_facturas.BottomPagerRow.Cells(0).FindControl("ddlPageSize"), DropDownList)
            gv_facturas.PageSize = ddl.SelectedValue
            CargarFacturas()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub CargarNotasCredito()
        Dim listaNotasCre As New List(Of DocumentoFinancieroEntidad)
        Dim GestorNotasCre As New GestorDocFinancieroBLL
        Dim Usu As New UsuarioEntidad
        Usu = Session("cliente")
        listaNotasCre = GestorNotasCre.TraerDocumentoF(Usu)
        If listaNotasCre.Count > 0 Then
            Session("NotasCreUsuario") = listaNotasCre
            gv_notas.DataSource = listaNotasCre
            gv_notas.DataBind()
        End If
    End Sub


    Private Sub gv_notas_DataBound(sender As Object, e As EventArgs) Handles gv_notas.DataBound
        Try

            Try
                Dim ddl2 As DropDownList = CType(gv_notas.BottomPagerRow.Cells(0).FindControl("ddlPagingnotas"), DropDownList)
            Catch ex As Exception
                Return
            End Try

            Dim ddl As DropDownList = CType(gv_notas.BottomPagerRow.Cells(0).FindControl("ddlPagingnotas"), DropDownList)
            Dim ddlpage As DropDownList = CType(gv_notas.BottomPagerRow.Cells(0).FindControl("ddlPageSizenotas"), DropDownList)
            Dim txttotal As Label = CType(gv_notas.BottomPagerRow.Cells(0).FindControl("lbltotalpages"), Label)

            ddlpage.ClearSelection()
            ddlpage.Items.FindByValue(gv_notas.PageSize).Selected = True

            txttotal.Text = gv_notas.PageCount

            For cnt As Integer = 0 To gv_notas.PageCount - 1
                Dim curr As Integer = cnt + 1
                Dim item As New ListItem(curr.ToString())
                If cnt = gv_notas.PageIndex Then
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


            With gv_notas.HeaderRow
                '.Cells(0).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderID").Traduccion
                '.Cells(1).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderNombreUsuario").Traduccion
                '.Cells(2).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderIdioma").Traduccion
                '.Cells(3).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderBloqueo").Traduccion
                '.Cells(4).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderEmpleado").Traduccion
                '.Cells(5).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderFechaAlta").Traduccion
                '.Cells(6).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderAcciones").Traduccion
            End With

            gv_notas.BottomPagerRow.Visible = True
            gv_notas.BottomPagerRow.CssClass = "table-bottom-dark"
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub gv_notas_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            CargarNotasCredito()
            gv_notas.PageIndex = e.NewPageIndex
            gv_notas.DataBind()
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub ddlPagingnotas_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim ddl As DropDownList = CType(gv_notas.BottomPagerRow.Cells(0).FindControl("ddlPagingnotas"), DropDownList)
            gv_notas.SetPageIndex(ddl.SelectedIndex)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ddlPageSizenotas_SelectedPageSizeChanged(sender As Object, e As EventArgs)
        Try
            Dim ddl As DropDownList = CType(gv_notas.BottomPagerRow.Cells(0).FindControl("ddlPageSizenotas"), DropDownList)
            gv_notas.PageSize = ddl.SelectedValue
            CargarNotasCredito()
        Catch ex As Exception

        End Try
    End Sub


    Public Function SumarNotasC()
        Dim sum As Single
        Dim lstnc As List(Of DocumentoFinancieroEntidad)
        lstnc = Session("NotasCreUsuario")
        If Not IsNothing(lstnc) Then
            For Each nc In lstnc
                sum = sum + nc.Monto
                lbltotalnotasC.Text = "AR$ " & sum
                Session("NotasCreUsuario") = sum
            Next
        End If

        Return sum

    End Function

    Protected Sub btn_cancelacion_Click(sender As Object, e As EventArgs) Handles btn_cancelacion.Click

        Dim factlist As List(Of FacturaEntidad)
        factlist = Session("FactCanceladaSeleccionada")

        For Each _fact As FacturaEntidad In factlist
            _fact.EstadoEnvio = 5
            FacturaBLL.ModificarFactura(_fact)

        Next
        Me.success.Visible = True
        Me.success.InnerText = "Su solicitud de cancelación se ha procesado exitosamente."
    End Sub
End Class