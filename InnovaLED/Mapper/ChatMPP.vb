Imports DAL
Imports Entidades
Imports System.Data.SqlClient




Public Class ChatMPP


    Public Function GenerarMensaje(chat As ChatEntidad) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("insert into Chat (ID_Usuario,Finalizado)  Output Inserted.ID_Chat values (@ID_Usuario, @Finalizado)")
            With Command.Parameters
                .Add(New SqlParameter("@ID_Usuario", chat.Usuario.ID_Usuario))
                .Add(New SqlParameter("@Finalizado", False))
            End With

            chat.ID = Acceso.Scalar(Command)

            Dim Command2 As SqlCommand = Acceso.MiComando("insert into Mensaje_Chat (ID_Chat,ID_Usuario,Fecha,Texto) values (@ID_Chat,@ID_Usuario, @Fecha,@Texto)")
            With Command2.Parameters
                .Add(New SqlParameter("@ID_Chat", chat.ID))
                .Add(New SqlParameter("@ID_Usuario", chat.Usuario.ID_Usuario))
                .Add(New SqlParameter("@Fecha", chat.MensajesChat.First.Fecha))
                .Add(New SqlParameter("@Texto", chat.MensajesChat.First.Texto))
            End With
            Acceso.Escritura(Command2)

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function




    Public Sub AsignarEmpleado(chat As ChatEntidad)
        Try

            Dim Command2 As SqlCommand = Acceso.MiComando("update Chat set ID_Empleado=@ID_Empleado where ID_Chat=@ID_Chat")
            With Command2.Parameters
                .Add(New SqlParameter("@ID_Chat", chat.ID))
                .Add(New SqlParameter("@ID_Empleado", chat.Empleado.ID_Usuario))
            End With
            Acceso.Escritura(Command2)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function AgregarMensaje(chat As ChatEntidad) As Boolean
        Try

            Dim Command2 As SqlCommand = Acceso.MiComando("insert into Mensaje_Chat (ID_Chat,ID_Usuario,Fecha,Texto) values (@ID_Chat,@ID_Usuario, @Fecha,@Texto)")
            With Command2.Parameters
                .Add(New SqlParameter("@ID_Chat", chat.ID))
                .Add(New SqlParameter("@ID_Usuario", chat.MensajesChat.Last.Usuario.ID_Usuario))
                .Add(New SqlParameter("@Fecha", chat.MensajesChat.Last.Fecha))
                .Add(New SqlParameter("@Texto", chat.MensajesChat.Last.Texto))
            End With
            Acceso.Escritura(Command2)

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TraerChats() As List(Of ChatEntidad)
        Try
            Dim consulta As String = "Select * from Chat"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            Dim dt As DataTable = Acceso.Lectura(Command)
            Dim listachat As New List(Of ChatEntidad)
            For Each _dr As DataRow In dt.Rows
                Dim _chat As New ChatEntidad
                FormatearChat(_chat, _dr)
                listachat.Add(_chat)
            Next
            Return listachat
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TraerMensajesChat(iD As Integer) As List(Of MensajeChatEntidad) ' Ojo que acá antes decía Private no Public, VER
        Try
            Dim consulta As String = "Select * from Mensaje_Chat where ID_Chat = @ID_Chat"

            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_Chat", iD))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            Dim listamensajeschat As New List(Of MensajeChatEntidad)
            For Each _dr As DataRow In dt.Rows
                Dim _mensajeentidad As New MensajeChatEntidad

                FormatearMensajeChat(_mensajeentidad, _dr)
                listamensajeschat.Add(_mensajeentidad)
            Next
            Return listamensajeschat
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function TraerMensajesChatParaReporte() As List(Of MensajeChatEntidad)
        Try
            Dim consulta As String = "Select * from Mensaje_Chat"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            Dim dt As DataTable = Acceso.Lectura(Command)
            Dim listamensajeschat As New List(Of MensajeChatEntidad)
            For Each _dr As DataRow In dt.Rows
                Dim _mensajeentidad As New MensajeChatEntidad
                FormatearMensajeChat(_mensajeentidad, _dr)
                listamensajeschat.Add(_mensajeentidad)
            Next
            Return listamensajeschat
        Catch ex As Exception
            Throw ex
        End Try
    End Function




    Public Sub FormatearChat(ByVal chat As ChatEntidad, ByVal row As DataRow)
        Try
            chat.ID = row("ID_Chat")
            chat.Usuario = (New UsuarioMPP).BuscarUsuarioID(New UsuarioEntidad With {.ID_Usuario = row("ID_Usuario")})
            If Not IsDBNull(row("ID_Empleado")) Then
                chat.Empleado = (New UsuarioMPP).BuscarUsuarioID(New UsuarioEntidad With {.ID_Usuario = row("ID_Empleado")})
            Else
                chat.Empleado = New Entidades.UsuarioEntidad With {.ID_Usuario = -2}
            End If
            chat.MensajesChat = TraerMensajesChat(chat.ID)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FormatearMensajeChat(mensajeentidad As MensajeChatEntidad, Row As DataRow)
        mensajeentidad.ID = Row("ID_Mensaje_Chat")
        mensajeentidad.Usuario = (New UsuarioMPP).BuscarUsuarioID(New UsuarioEntidad With {.ID_Usuario = Row("ID_Usuario")})
        mensajeentidad.Texto = Row("Texto")
        mensajeentidad.Fecha = Row("Fecha")
    End Sub
End Class
