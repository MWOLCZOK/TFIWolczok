Imports Entidades
Imports Mapper


Public Class NovedadBLL
    Private Shared gestor_novedad As New Mapper.novedadMPP

    Public Sub altaNovedad(ByVal paramNovedad As Entidades.Novedad)
        Try
            paramNovedad.Fecha_Alta = Now
            paramNovedad.BL = False
            gestor_novedad.altaNovedad(paramNovedad)
            enviarNewsletter(paramNovedad)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub bajaNovedad(ByVal paramNovedad As Entidades.Novedad)
        Try
            paramNovedad.BL = False
            gestor_novedad.bajaNovedad(paramNovedad)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub modificarNovedad(ByVal paramNovedad As Entidades.Novedad)
        Try
            gestor_novedad.modificarNovedad(paramNovedad)
        Catch ex As Exception

        End Try
    End Sub


    Public Function enviarNewsletter(ByVal paramNovedad As Entidades.Novedad) As Boolean
        Try
            Dim listaSuscriptores As List(Of String) = gestor_novedad.obtenerSuscriptores(paramNovedad)
            For Each mail As String In listaSuscriptores
                MaillingBLL.enviarMailNewsletter()
            Next
        Catch ex As Exception

        End Try
    End Function

    Public Function obtenerNovedades() As List(Of Entidades.Novedad)
        Try
            Return gestor_novedad.obtenerNovedades
        Catch ex As Exception

        End Try
    End Function

    Public Function obtenerNovedadesVigentes() As List(Of Entidades.Novedad)
        Try
            Return gestor_novedad.obtenerNovedadesVigentes
        Catch ex As Exception

        End Try
    End Function

    Public Function obtenerNovedad(ByVal paramNovedad As Entidades.Novedad) As Entidades.Novedad
        Try
            Return gestor_novedad.obtenerNovedad(paramNovedad)
        Catch ex As Exception

        End Try
    End Function

End Class
