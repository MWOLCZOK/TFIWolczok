Imports Entidades
Imports Negocio
Imports System.Web.HttpContext




Public Class Chat
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsNothing(Session("cliente")) Then

            txt_mensaje.Focus()

            If Not Request.QueryString("contid") = "" Then
                id_chat.Value = Request.QueryString("contid")

            End If

            If id_chat.Value >= 0 Then
                Me.btn_mensaje.Visible = True
                Me.txt_mensaje.Visible = True
                If id_chat.Value > 0 Then
                    CargarMensajes(id_chat.Value)
                End If
            Else
                Me.btn_mensaje.Visible = False
                Me.txt_mensaje.Visible = False

            End If

            CargarChats()
        End If
    End Sub

    Private Sub CargarMensajes(id_chat As Integer)
        Dim usu As UsuarioEntidad = Session("cliente")
        Dim mismensajes As List(Of MensajeChatEntidad) = TryCast(Application("ChatGlobal"), List(Of Entidades.ChatEntidad)).Find(Function(p) p.ID = id_chat).MensajesChat

        mensajes.Controls.Clear()
        mensajes.Controls.Add(New LiteralControl("<table id=""cart"" class=""table table-hover table-condensed"">"))
        mensajes.Controls.Add(New LiteralControl("<tbody>"))

        For Each mensaje In mismensajes
            If mensaje.Usuario.ID_Usuario = usu.ID_Usuario Then
                mensajes.Controls.Add(New LiteralControl("<tr  bgcolor=""#e0ffff""> "))
            Else
                mensajes.Controls.Add(New LiteralControl("<tr  bgcolor=""#ffffe0""> "))
            End If


            mensajes.Controls.Add(New LiteralControl("<td data-th=""Product"">"))
            mensajes.Controls.Add(New LiteralControl("<div class=""row"">"))
            mensajes.Controls.Add(New LiteralControl("<div Class=""col-md-12 text-left"">"))
            mensajes.Controls.Add(New LiteralControl("<p>" & mensaje.Usuario.NombreUsu & " - " & mensaje.Fecha & "</p>"))
            mensajes.Controls.Add(New LiteralControl("</div>"))
            mensajes.Controls.Add(New LiteralControl("</div>"))
            mensajes.Controls.Add(New LiteralControl("<div class=""row"">"))
            mensajes.Controls.Add(New LiteralControl("<div Class=""col-md-12 text-left"">"))
            mensajes.Controls.Add(New LiteralControl("<p><h4>" & mensaje.Texto & "<h4/></p>"))
            mensajes.Controls.Add(New LiteralControl("</div>"))
            mensajes.Controls.Add(New LiteralControl("</div>"))
            mensajes.Controls.Add(New LiteralControl("</td>"))
            mensajes.Controls.Add(New LiteralControl("</tr>"))

        Next

        mensajes.Controls.Add(New LiteralControl("</tbody>"))
        mensajes.Controls.Add(New LiteralControl("</table>"))
    End Sub

    Private Sub CargarChats()
        Dim usu As UsuarioEntidad = Session("cliente")
        Dim mischats As List(Of Entidades.ChatEntidad)
        If usu.Empleado Then
            mischats = (TryCast(Application("ChatGlobal"), List(Of Entidades.ChatEntidad)).FindAll(Function(p) p.Empleado.ID_Usuario = usu.ID_Usuario))
            mischats.AddRange(TryCast(Application("ChatGlobal"), List(Of Entidades.ChatEntidad)).FindAll(Function(p) p.Empleado.ID_Usuario = -2))
        Else
            mischats = TryCast(Application("ChatGlobal"), List(Of Entidades.ChatEntidad)).FindAll(Function(p) p.Usuario.ID_Usuario = usu.ID_Usuario)
        End If

        GenerarDiseño(mischats)

    End Sub

    Private Sub GenerarDiseño(mischats As List(Of ChatEntidad))
        chats.Controls.Clear()

        Dim usu As UsuarioEntidad = Session("cliente")
        For Each chat As ChatEntidad In mischats
            Dim divmedia As HtmlGenericControl = New HtmlGenericControl("div")
            divmedia.Attributes.Add("class", "media")
            Dim divmedialeft As HtmlGenericControl = New HtmlGenericControl("div")
            divmedialeft.Attributes.Add("class", "media-left")
            divmedia.Controls.Add(divmedialeft)

            Dim divmediabody As HtmlGenericControl = New HtmlGenericControl("div")
            divmediabody.Attributes.Add("class", "media-body")
            Dim h3 As HtmlGenericControl = New HtmlGenericControl("h3")
            h3.Attributes.Add("class", "media-heading")
            Dim A As HtmlGenericControl = New HtmlGenericControl("a")
            A.Attributes.Add("href", "/Chat.aspx" & "?contid=" & chat.ID)
            If usu.Empleado Then
                If chat.Empleado.ID_Usuario = -2 Then
                    A.InnerText = "Iniciar Chat con: " & chat.Usuario.Apellido & ", " & chat.Usuario.Nombre
                Else
                    A.InnerText = "Chat con: " & chat.Usuario.Apellido & ", " & chat.Usuario.Nombre
                End If
            Else
                If chat.Empleado.ID_Usuario = -2 Then
                    A.InnerText = "Chat sin Empleado Asignado"
                Else
                    A.InnerText = "Chat con: " & chat.Empleado.Apellido & ", " & chat.Empleado.Nombre
                End If

            End If

            h3.Controls.Add(A)
            divmediabody.Controls.Add(h3)
            divmedia.Controls.Add(divmediabody)
            chats.Controls.Add(divmedia)
            Dim hr As HtmlGenericControl = New HtmlGenericControl("hr")
            chats.Controls.Add(hr)
        Next
        If Not usu.Empleado Then
            Dim divmedia2 As HtmlGenericControl = New HtmlGenericControl("div")
            divmedia2.Attributes.Add("class", "media")
            Dim divmedialeft2 As HtmlGenericControl = New HtmlGenericControl("div")
            divmedialeft2.Attributes.Add("class", "media-left")
            divmedia2.Controls.Add(divmedialeft2)

            Dim divmediabody2 As HtmlGenericControl = New HtmlGenericControl("div")
            divmediabody2.Attributes.Add("class", "media-body")
            Dim h32 As HtmlGenericControl = New HtmlGenericControl("h3")
            h32.Attributes.Add("class", "media-heading")
            Dim A2 As HtmlGenericControl = New HtmlGenericControl("a")
            A2.Attributes.Add("href", "/Chat.aspx" & "?contid=0")

            A2.InnerText = "Iniciar Nuevo Chat"
            h32.Controls.Add(A2)
            divmediabody2.Controls.Add(h32)
            divmedia2.Controls.Add(divmediabody2)
            chats.Controls.Add(divmedia2)
            Dim hr As HtmlGenericControl = New HtmlGenericControl("hr")
            chats.Controls.Add(hr)
        End If



    End Sub

    Protected Sub btn_mensaje_Click(sender As Object, e As EventArgs) Handles btn_mensaje.Click
        Try
            Dim gestor As New GestorChatBLL
            Dim usu As UsuarioEntidad = Session("cliente")
            Dim Chat As ChatEntidad
            If id_chat.Value = 0 Then
                Chat = New ChatEntidad
                Chat.Usuario = usu
                Chat.Empleado = New UsuarioEntidad With {.ID_Usuario = -2}
                Dim Mensajechat As New MensajeChatEntidad
                Mensajechat.Usuario = usu
                Mensajechat.Texto = txt_mensaje.InnerText
                Mensajechat.Fecha = Now
                Chat.MensajesChat.Add(Mensajechat)

                If gestor.GenerarMensaje(Chat) Then
                    TryCast(Application("ChatGlobal"), List(Of Entidades.ChatEntidad)).Add(Chat)
                    CargarChats()
                End If

            ElseIf id_chat.Value > 0 Then
                Chat = TryCast(Application("ChatGlobal"), List(Of Entidades.ChatEntidad)).Find(Function(p) p.ID = id_chat.Value)
                Dim Mensajechat As New MensajeChatEntidad
                Mensajechat.Usuario = Session("cliente")
                Mensajechat.Texto = txt_mensaje.InnerText
                Mensajechat.Fecha = Now
                If usu.Empleado Then
                    If Chat.Empleado.ID_Usuario = -2 Then
                        Chat.Empleado = usu
                        gestor.AsignarEmpleado(Chat)
                    End If
                End If
                Chat.MensajesChat.Add(Mensajechat)
                If gestor.AgregarMensaje(Chat) Then

                End If

            Else
                Return
            End If
            CargarMensajes(Chat.ID)
            txt_mensaje.InnerText = ""

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'If id_chat.Value > 0 Then
        '    CargarMensajes(id_chat.Value)
        'End If

    End Sub
End Class