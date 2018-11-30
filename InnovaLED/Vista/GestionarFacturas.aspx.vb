Imports System.Web.HttpContext
Imports Entidades
Imports Negocio



Public Class GestionarFacturas
    Inherits System.Web.UI.Page

    Private Sub Gestionar_Usuario_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Session("Facturasseleccionadas") = New Entidades.FacturaEntidad
                Ocultamiento(False)
                CargarFacturas()
                CargarCombos

            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub CargarCombos()
        Dim tipo As New Entidades.EstadoCompraEntidad
        Dim itemValues As Array = System.Enum.GetValues(tipo.GetType)
        Dim itemNames As Array = System.Enum.GetNames(tipo.GetType)
        For i As Integer = 0 To itemNames.Length - 1
            Dim item As New ListItem(itemNames(i), itemValues(i))
            Me.lstestadocompra.Items.Add(item)
        Next

        Dim tipo2 As New Entidades.EstadoEnvio
        Dim itemValues2 As Array = System.Enum.GetValues(tipo2.GetType)
        Dim itemNames2 As Array = System.Enum.GetNames(tipo2.GetType)
        For i As Integer = 0 To itemNames2.Length - 2
            Dim item As New ListItem(itemNames2(i), itemValues2(i))
            Me.lstestadoenvio.Items.Add(item)
        Next
    End Sub

    Private Sub CargarFacturas()
        Dim lista As List(Of Entidades.FacturaEntidad)
        Dim Gestor As New Negocio.GestorFacturaBLL

        lista = Gestor.TraerFacturasGestion

        If lista.Count > 0 Then
            Session("Facturas") = lista
            Me.gv_facturas.DataSource = lista
            Me.gv_facturas.DataBind()
        Else
            'cartel de no hay preguntas para responder
            'Dim IdiomaActual As Entidades.IdiomaEntidad
            'If IsNothing(Current.Session("Cliente")) Then
            '    IdiomaActual = Application("Español")
            'Else
            '    IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            'End If
            'Me.alertvalid.Visible = True
            'Me.alertvalid.InnerText = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "ModUserError3").Traduccion
            'Me.success.Visible = False
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

    Private Sub Ocultamiento(ByVal bi As Boolean)
        Me.respuesta.Visible = bi
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
                    For Each r As GridViewRow In gv_facturas.Rows
                        r.BackColor = Drawing.Color.FromName("#c3e6cb")
                    Next
                    Dim facturasele As FacturaEntidad = TryCast(Session("Facturas"), List(Of FacturaEntidad))(e.CommandArgument + (gv_facturas.PageIndex * gv_facturas.PageSize))
                    Dim fact = TryCast(Session("Facturasseleccionadas"), FacturaEntidad)

                    If fact.ID = facturasele.ID Then
                        Dim imagen1 As System.Web.UI.WebControls.ImageButton = DirectCast(gv_facturas.Rows.Item(e.CommandArgument).FindControl("btn_seleccionar"), System.Web.UI.WebControls.ImageButton)
                        imagen1.ImageUrl = "~/Imagenes/check.png"
                        gv_facturas.Rows.Item(e.CommandArgument).BackColor = Drawing.Color.FromName("#c3e6cb")
                    Else

                        Session("Facturasseleccionadas") = facturasele
                        gv_facturas.Rows.Item(e.CommandArgument).BackColor = Drawing.Color.SkyBlue
                    End If
                    If Not IsNothing(facturasele) Then
                        Me.respuesta.Visible = True
                        Me.lstestadocompra.SelectedValue = facturasele.EstadoCompra
                        Me.lstestadoenvio.SelectedValue = facturasele.EstadoEnvio
                    Else
                        Me.respuesta.Visible = False

                    End If

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnmodificar_Click(sender As Object, e As EventArgs) Handles btnmodificar.Click
        Dim Gestor As New Negocio.GestorFacturaBLL
        Dim GestorNota As New GestorDocFinancieroBLL
        Try

            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If
            If Page.IsValid = True Then
                Dim fact As FacturaEntidad = Session("Facturasseleccionadas")
                 fact.EstadoCompra = Me.lstestadocompra.SelectedValue
                If Me.lstestadocompra.SelectedValue = 2 Then
                    fact.EstadoEnvio = 4
                    Dim usuNota As UsuarioEntidad = fact.Cliente

                    Dim nota As New DocumentoFinancieroEntidad("Nota de Credito generada por Cancelación de factura", fact.MontoTotal, TipoDocumento.Positivo, usuNota, Now)
                    GestorNota.Alta(nota)
                Else
                    fact.EstadoEnvio = Me.lstestadoenvio.SelectedValue
                End If

                If Gestor.ModificarFactura(fact) Then
                    '    Dim clienteLogeado As Entidades.UsuarioEntidad = Current.Session("cliente")
                    '    Dim Bitac As New Bitacora(Usuario, "El usuario " & Usuario.NombreUsu & " Se modificó correctamente", Tipo_Bitacora.Modificacion, Now, Request.UserAgent, Request.UserHostAddress, "", "", Request.Url.ToString)
                    '    BitacoraBLL.CrearBitacora(Bitac)
                    Me.success.Visible = True
                    Me.alertvalid.Visible = False
                    CargarFacturas()
                    Ocultamiento(False)
                End If
            Else
                Me.alertvalid.Visible = True
                Me.textovalid.InnerText = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "FieldValidator1").Traduccion
                Me.success.Visible = False
            End If
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

    Protected Sub lstestadocompra_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstestadocompra.SelectedIndexChanged
        If Me.lstestadocompra.SelectedValue = 2 Then
            envio.Visible = False
        Else
            envio.Visible = True
        End If


    End Sub
End Class