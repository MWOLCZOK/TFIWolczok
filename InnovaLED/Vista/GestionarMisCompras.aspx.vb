Imports Entidades
Imports Negocio
Imports System.Web.HttpContext





Public Class GestionMisCompras
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                CargarFacturas()

            Catch ex As Exception

            End Try

        End If
    End Sub


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
                Dim imagen1 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Seleccionar"), System.Web.UI.WebControls.ImageButton)

                imagen1.CommandArgument = row.RowIndex
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











End Class