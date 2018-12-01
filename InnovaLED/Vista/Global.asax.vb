Imports System.Web.SessionState
Imports System.Timers

Public Class Global_asax
    Inherits System.Web.HttpApplication
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim GestorIdioma As New Negocio.IdiomaBLL
            Dim IdiomaDefault As Entidades.IdiomaEntidad = GestorIdioma.ConsultarPorID(1)
            Application(IdiomaDefault.Nombre) = IdiomaDefault
            Dim GestorChat As New Negocio.GestorChatBLL
            Application("ChatGlobal") = GestorChat.TraerChats()
        Catch ex As Exception
        End Try
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al iniciar la sesión
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al comienzo de cada solicitud
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al intentar autenticar el uso
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando se produce un error
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando finaliza la sesión
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando finaliza la aplicación
    End Sub

End Class