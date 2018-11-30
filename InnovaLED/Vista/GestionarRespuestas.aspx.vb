Imports System.Web.HttpContext
Imports Entidades
Imports Negocio



Public Class GestionarRespuestas
    Inherits System.Web.UI.Page

    Private Sub Gestionar_Usuario_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Session("comentariosseleccionados") = New List(Of Entidades.ComentarioEntidad)
                Ocultamiento(False)
                Cargarcomentarios()
            Catch ex As Exception

            End Try

        End If
    End Sub


    Private Sub Cargarcomentarios()
        Dim lista As List(Of Entidades.ComentarioEntidad)
        Dim Gestor As New Negocio.GestorComentarioBLL

        lista = Gestor.BuscarComentariosSinRespuesta()

        If lista.Count > 0 Then
            Session("Comentarios") = lista
            Me.gv_comentarios.DataSource = lista
            Me.gv_comentarios.DataBind()
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

    Private Sub gv_comentarios_DataBound(sender As Object, e As EventArgs) Handles gv_comentarios.DataBound
        Try

            Try
                Dim ddl2 As DropDownList = CType(gv_comentarios.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            Catch ex As Exception
                Return
            End Try

            Dim ddl As DropDownList = CType(gv_comentarios.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            Dim ddlpage As DropDownList = CType(gv_comentarios.BottomPagerRow.Cells(0).FindControl("ddlPageSize"), DropDownList)
            Dim txttotal As Label = CType(gv_comentarios.BottomPagerRow.Cells(0).FindControl("lbltotalpages"), Label)

            ddlpage.ClearSelection()
            ddlpage.Items.FindByValue(gv_comentarios.PageSize).Selected = True

            txttotal.Text = gv_comentarios.PageCount

            For cnt As Integer = 0 To gv_comentarios.PageCount - 1
                Dim curr As Integer = cnt + 1
                Dim item As New ListItem(curr.ToString())
                If cnt = gv_comentarios.PageIndex Then
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
            For Each row As GridViewRow In gv_comentarios.Rows
                Dim imagen1 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Seleccionar"), System.Web.UI.WebControls.ImageButton)

                imagen1.CommandArgument = row.RowIndex
            Next

            With gv_comentarios.HeaderRow
                '.Cells(0).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderID").Traduccion
                '.Cells(1).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderNombreUsuario").Traduccion
                '.Cells(2).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderIdioma").Traduccion
                '.Cells(3).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderBloqueo").Traduccion
                '.Cells(4).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderEmpleado").Traduccion
                '.Cells(5).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderFechaAlta").Traduccion
                '.Cells(6).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderAcciones").Traduccion
            End With

            gv_comentarios.BottomPagerRow.Visible = True
            gv_comentarios.BottomPagerRow.CssClass = "table-bottom-dark"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Ocultamiento(ByVal bi As Boolean)
        Me.respuesta.Visible = bi
    End Sub

    Private Sub gv_comentarios_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gv_comentarios.RowCommand

        Try
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If

            Select Case e.CommandName.ToString
                Case "S"
                    Dim comentario As ComentarioEntidad = TryCast(Session("Comentarios"), List(Of ComentarioEntidad))(e.CommandArgument + (gv_comentarios.PageIndex * gv_comentarios.PageSize))
                    If TryCast(Session("comentariosseleccionados"), List(Of ComentarioEntidad)).Any(Function(p) p.ID = comentario.ID) Then
                        TryCast(Session("comentariosseleccionados"), List(Of ComentarioEntidad)).Remove(comentario) ' para deseleccionar
                        Dim imagen1 As System.Web.UI.WebControls.ImageButton = DirectCast(gv_comentarios.Rows.Item(e.CommandArgument).FindControl("btn_seleccionar"), System.Web.UI.WebControls.ImageButton)
                        imagen1.ImageUrl = "~/Imagenes/check.png"
                        gv_comentarios.Rows.Item(e.CommandArgument).BackColor = Drawing.Color.FromName("#c3e6cb")
                    Else
                        TryCast(Session("comentariosseleccionados"), List(Of ComentarioEntidad)).Add(comentario)
                        gv_comentarios.Rows.Item(e.CommandArgument).BackColor = Drawing.Color.SkyBlue
                        Dim imagen1 As System.Web.UI.WebControls.ImageButton = DirectCast(gv_comentarios.Rows.Item(e.CommandArgument).FindControl("btn_seleccionar"), System.Web.UI.WebControls.ImageButton)
                        imagen1.ImageUrl = "~/Imagenes/clear.png"
                    End If
                    If TryCast(Session("comentariosseleccionados"), List(Of ComentarioEntidad)).Count > 0 Then
                        Me.respuesta.Visible = True
                    Else
                        Me.respuesta.Visible = False
                    End If

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnrespuesta_Click(sender As Object, e As EventArgs) Handles btnrespuesta.Click
        Dim Gestor As New Negocio.GestorComentarioBLL
        Try
         
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If
            If Page.IsValid = True Then
                Dim lista As List(Of ComentarioEntidad) = Session("comentariosseleccionados")
                Dim Comentario As New ComentarioEntidad
                Comentario.Texto = txt_respuesta.InnerText
                Comentario.Producto = lista(0).Producto
                Comentario.Pregunta = lista(0)
                Comentario.Usuario = Current.Session("Cliente")
                Comentario.Fecha = Now

                If Gestor.GenerarComentario(Comentario) Then
                    '    Dim clienteLogeado As Entidades.UsuarioEntidad = Current.Session("cliente")
                    '    Dim Bitac As New Bitacora(Usuario, "El usuario " & Usuario.NombreUsu & " Se modificó correctamente", Tipo_Bitacora.Modificacion, Now, Request.UserAgent, Request.UserHostAddress, "", "", Request.Url.ToString)
                    '    BitacoraBLL.CrearBitacora(Bitac)
                    Me.success.Visible = True
                    Me.alertvalid.Visible = False
                    Cargarcomentarios()
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
    Protected Sub gv_comentarios_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            Cargarcomentarios()
            gv_comentarios.PageIndex = e.NewPageIndex
            gv_comentarios.DataBind()
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub ddlPaging_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim ddl As DropDownList = CType(gv_comentarios.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            gv_comentarios.SetPageIndex(ddl.SelectedIndex)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ddlPageSize_SelectedPageSizeChanged(sender As Object, e As EventArgs)
        Try
            Dim ddl As DropDownList = CType(gv_comentarios.BottomPagerRow.Cells(0).FindControl("ddlPageSize"), DropDownList)
            gv_comentarios.PageSize = ddl.SelectedValue
            Cargarcomentarios()
        Catch ex As Exception

        End Try
    End Sub

End Class