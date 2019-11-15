Imports System.Web.HttpContext
Imports Entidades
Imports Negocio
Imports System.Data
Imports System.IO
Imports System.Web.UI.DataVisualization.Charting



Public Class MiCuentaCorriente

    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            CargarHistorial()
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
                'If row.Cells(4).Text = "Rechazado" Then
                '    Dim cell6 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Seleccionar"), System.Web.UI.WebControls.ImageButton)
                '    cell6.Visible = False
                'ElseIf row.Cells(5).Text = "PendienteCancelacion" Then
                '    Dim cell6 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Seleccionar"), System.Web.UI.WebControls.ImageButton)
                '    cell6.Visible = False
                'End If

                'Dim imagen1 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Seleccionar"), System.Web.UI.WebControls.ImageButton)

                'imagen1.CommandArgument = row.RowIndex

                Dim imagen2 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_descargar"), System.Web.UI.WebControls.ImageButton)

                imagen2.CommandArgument = row.RowIndex
            Next

            'With gv_facturas.HeaderRow
            '    '.Cells(0).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderID").Traduccion
            '    '.Cells(1).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderNombreUsuario").Traduccion
            '    '.Cells(2).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderIdioma").Traduccion
            '    '.Cells(3).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderBloqueo").Traduccion
            '    '.Cells(4).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderEmpleado").Traduccion
            '    '.Cells(5).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderFechaAlta").Traduccion
            '    '.Cells(6).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderAcciones").Traduccion
            'End With


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
                'Case "S"
                '    Dim fact As FacturaEntidad = TryCast(Session("FacturasUsuario"), List(Of FacturaEntidad))(e.CommandArgument + (gv_facturas.PageIndex * gv_facturas.PageSize))
                '    If TryCast(Session("FactCanceladaSeleccionada"), List(Of FacturaEntidad)).Any(Function(p) p.ID = fact.ID) Then
                '        TryCast(Session("FactCanceladaSeleccionada"), List(Of FacturaEntidad)).Remove(fact)
                '        Dim imagen1 As System.Web.UI.WebControls.ImageButton = DirectCast(gv_facturas.Rows.Item(e.CommandArgument).FindControl("btn_seleccionar"), System.Web.UI.WebControls.ImageButton) ' aca hace referencia al boton de la grilla.
                '        imagen1.ImageUrl = "~/Imagenes/check.png"
                '        gv_facturas.Rows.Item(e.CommandArgument).BackColor = Drawing.Color.FromName("#c3e6cb")
                '    Else
                '        TryCast(Session("FactCanceladaSeleccionada"), List(Of FacturaEntidad)).Add(fact)
                '        gv_facturas.Rows.Item(e.CommandArgument).BackColor = Drawing.Color.SkyBlue
                '        Dim imagen1 As System.Web.UI.WebControls.ImageButton = DirectCast(gv_facturas.Rows.Item(e.CommandArgument).FindControl("btn_seleccionar"), System.Web.UI.WebControls.ImageButton)
                '        imagen1.ImageUrl = "~/Imagenes/clear.png"
                '    End If
                '    If TryCast(Session("FactCanceladaSeleccionada"), List(Of FacturaEntidad)).Count > 0 Then
                '        btn_cancelacion.Visible = True
                '    Else
                '        btn_cancelacion.Visible = False
                '    End If

                Case "D"


                    Dim documento As HistorialEntidad = TryCast(Session("oHistorial"), List(Of HistorialEntidad))(e.CommandArgument + (gv_facturas.PageIndex * gv_facturas.PageSize))


                    Response.ContentType = "application/octet-stream"
                    Response.AppendHeader("Content-Disposition", "attachment; filename=Factura_" & Right("0000" & documento.NroDoc, 4) + ".pdf")
                    Response.BinaryWrite(documento.PDF)
                    Response.Flush()





            End Select
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gv_facturas_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            CargarHistorial()
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
            CargarHistorial()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub CargarHistorial()
        Dim lstHistorial As New List(Of HistorialEntidad)
        Dim GestorHistorialBLL As New HistorialBLL
        Dim usu As New UsuarioEntidad
        usu = Session("cliente")
        lstHistorial = GestorHistorialBLL.ListarPorCliente(usu)
        If lstHistorial.Count > 0 Then
            Session("oHistorial") = lstHistorial
            gv_facturas.DataSource = lstHistorial
            gv_facturas.DataBind()
        End If
    End Sub








End Class