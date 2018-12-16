Imports Mapper
Imports Entidades
Imports System.Web

Public Class BoletinBLL

    Dim boletinMPP As New BoletinMPP
    Dim usu As UsuarioEntidad

    Public Sub Alta(ByVal boletin As BoletinEntidad)
        Try
            boletinMPP.Alta(boletin)
            '   If Not _paramBoletin.TipoBoletin = Entidades.TipoBoletin.Novedad Then
            EnviarMail(boletin)
            '    End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function obtenerSuscriptores(ByVal boletin As TipoBoletin) As List(Of String)
        Try
            Return boletinMPP.obtenerSubscriptores(boletin)
        Catch ex As Exception

        End Try
    End Function

    Public Sub EnviarMail(ByVal boletin As BoletinEntidad)
        Try
            boletin.Suscriptores = obtenerSuscriptores(boletin.TipoBoletin)
            Dim ruta As String = HttpContext.Current.Server.MapPath("Imagenes")
            Dim body As String = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("EmailTemplates/Newsletter.html"))
            Mapper.BoletinMPP.enviarMailNewsletter(body, boletin, ruta) ' terminar de armar la funcion enviarMailNewsletter
        Catch ex As Exception

        End Try
    End Sub

    Public Sub inscripbirseBoletin(ByVal paramCorreo As String, ByVal paramTipo As List(Of TipoBoletin))
        Try
            boletinMPP.inscribirseBoletin(paramCorreo, paramTipo)
        Catch ex As Exception

        End Try
    End Sub

    Public Function validarCorreo(ByVal paramCorreo As String) As Boolean
        Try
            Return boletinMPP.validarCorreo(paramCorreo)
        Catch ex As Exception

        End Try
    End Function

    Public Function ObtenerBoletinNovedad() As List(Of BoletinEntidad)
        Try
            Return boletinMPP.obtenerBoletinNovedad()
        Catch ex As Exception

        End Try
    End Function

    Public Function ObtenerBoletinNovedad(ByVal paramBoletin As BoletinEntidad) As BoletinEntidad
        Try
            Return boletinMPP.obtenerBoletinNovedad(paramBoletin)
        Catch ex As Exception

        End Try
    End Function

    Public Function bajaNovedad(ByVal paramBoletin As BoletinEntidad)
        Try
            boletinMPP.bajaNovedad(paramBoletin)
        Catch ex As Exception

        End Try
    End Function

    Public Function modificarNovedad(ByVal paramBoletin As BoletinEntidad) As Boolean
        Try
            boletinMPP.Modificar(paramBoletin)
        Catch ex As Exception
            Return True
        End Try
    End Function




















End Class
