Imports Entidades
Imports Mapper



Public Class GestorChatBLL

    Dim ChatMPP As New ChatMPP

    Public Function GenerarMensaje(ByVal chat As ChatEntidad) As Boolean
        Return ChatMPP.GenerarMensaje(chat)

    End Function

    Public Function AgregarMensaje(chat As ChatEntidad) As Boolean
        Return ChatMPP.AgregarMensaje(chat)
    End Function
    Public Function TraerChats() As List(Of ChatEntidad)
        Return ChatMPP.TraerChats()
    End Function

    Public Sub AsignarEmpleado(chat As ChatEntidad)
        ChatMPP.AsignarEmpleado(chat)
    End Sub
End Class
