﻿
Imports Entidades
Imports Mapper

Imports System.Globalization

Public Class IdiomaBLL
    Private _idiomaMPP As IdiomaMPP
    Private _idiomaentidad As IdiomaEntidad

    Public Function AltaIdioma(ByRef Idioma As IdiomaEntidad) As Boolean
        Try
            Dim gestor As New IdiomaMPP
            If gestor.ConsultarNombre(Idioma.Nombre) Then
                Return (New IdiomaMPP).GuardarIdioma(Idioma)

            Else
                Return False
            End If

        Catch NombreUso As ExceptionNombreEnUso
            Throw NombreUso
        Catch ex As Exception
            'BitacoraBLL.CrearBitacora("El Metodo " & ex.TargetSite.ToString & " generó un error. Su mensaje es: " & ex.Message, TipoBitacora.Errores, (New UsuarioEntidad With {.ID_Usuario = 0, .Nombre = "Sistema"}))
            Throw ex
        End Try
    End Function
    Public Function ModificarIdioma(ByRef Idioma As IdiomaEntidad) As Boolean
        Try
            If (New IdiomaMPP).ModificarIdioma(Idioma) Then
                'BitacoraBLL.CrearBitacora("Se modificó el Idioma: " & NombreIdioma & " en el sistema.", TipoBitacora.Modificación, SessionBLL.SesionActual.ObtenerUsuarioActual)
                Return True
            Else
                Return False
            End If
        Catch FalloConexion As InvalidOperationException
            'Dim Bitacora As New BitacoraEntidad("No se pudo modificar el Idioma: " & Idioma.Nombre & " en el sistema. Error de Conexion", TipoBitacora.Modificación, SessionBLL.SesionActual.ObtenerUsuarioActual)
            'BitacoraBLL.ArchivarBitacora(Bitacora)
            Throw FalloConexion
        Catch ex As Exception
            'BitacoraBLL.CrearBitacora("El Metodo " & ex.TargetSite.ToString & " generó un error. Su mensaje es: " & ex.Message, TipoBitacora.Errores, (New UsuarioEntidad With {.ID_Usuario = 0, .Nombre = "Sistema"}))
            Throw ex
        End Try
    End Function

    Public Function EliminarIdioma(ByRef Idioma As IdiomaEntidad) As Boolean
        Try
            'If DigitoVerificadorBLL.Integridad Then
            If (New IdiomaMPP).EliminarIdioma(Idioma) Then
                'BitacoraBLL.CrearBitacora("Se eliminó el Idioma: " & Idioma.Nombre & " en el sistema.", TipoBitacora.Baja, SessionBLL.SesionActual.ObtenerUsuarioActual)
                Return True
            Else
                Return False
            End If
            'Else
            '    Throw New ExceptionIntegridadUsuario
            'End If
        Catch ExcepcionUsuario As ExceptionIntegridadUsuario
            Throw ExcepcionUsuario
        Catch ExcepcionBitacora As ExceptionIntegridadBitacora
            Throw ExcepcionBitacora
        Catch ExcepcionEvento As ExceptionIntegridadEvento
            Throw ExcepcionEvento
        Catch FalloConexion As InvalidOperationException
            'Dim Bitacora As New BitacoraEntidad("No se pudo eliminar el Idioma: " & Idioma.Nombre & " en el sistema. Error de Conexion", TipoBitacora.Baja, SessionBLL.SesionActual.ObtenerUsuarioActual)
            'BitacoraBLL.ArchivarBitacora(Bitacora)
            Throw FalloConexion
        Catch ex As Exception
            'BitacoraBLL.CrearBitacora("El Metodo " & ex.TargetSite.ToString & " generó un error. Su mensaje es: " & ex.Message, TipoBitacora.Errores, (New UsuarioEntidad With {.ID_Usuario = 0, .Nombre = "Sistema"}))
            Throw ex
        End Try
    End Function

    Public Function SeleccionarIdioma(ByRef Usuario As UsuarioEntidad, ByRef ID_Idioma As Integer) As IdiomaEntidad
        Try
            Dim IdiomaSeleccionado = (New IdiomaMPP).SeleccionarIdioma(Usuario, ID_Idioma)
            'BitacoraBLL.CrearBitacora("El Usuario: " & Usuario.Nombre & " cambió su idioma.", TipoBitacora.Modificación, SessionBLL.SesionActual.ObtenerUsuarioActual)
            Return IdiomaSeleccionado
        Catch FalloConexion As InvalidOperationException
            'Dim Bitacora As New BitacoraEntidad("No se pudo cambiar el Idioma del usuario: " & Usuario.Nombre & ". Error de Conexion", TipoBitacora.Modificación, SessionBLL.SesionActual.ObtenerUsuarioActual)
            'BitacoraBLL.ArchivarBitacora(Bitacora)
            Throw FalloConexion
        Catch ex As Exception
            'BitacoraBLL.CrearBitacora("El Metodo " & ex.TargetSite.ToString & " generó un error. Su mensaje es: " & ex.Message, TipoBitacora.Errores, (New UsuarioEntidad With {.ID_Usuario = 0, .Nombre = "Sistema"}))
            Throw ex
        End Try
    End Function

    Public Function ConsultarIdiomas() As List(Of IdiomaEntidad)
        Try
            Return (New IdiomaMPP).ConsultarIdiomas
        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            'BitacoraBLL.CrearBitacora("El Metodo " & ex.TargetSite.ToString & " generó un error. Su mensaje es: " & ex.Message, TipoBitacora.Errores, (New UsuarioEntidad With {.ID_Usuario = 0, .Nombre = "Sistema"}))
            Throw ex
        End Try
    End Function

    Public Function ConsultarIdiomasEditables() As List(Of IdiomaEntidad)
        Try
            Dim IdiomasEditables As List(Of IdiomaEntidad) = New List(Of IdiomaEntidad)
            IdiomasEditables = (New IdiomaMPP).ConsultarIdiomasEditables

            If (IdiomasEditables.Count > 0) Then
                Return IdiomasEditables
            Else
                Throw New ExceptionNoHayIdiomasEditables
            End If

        Catch NoHayIdiomasEditables As ExceptionNoHayIdiomasEditables
            Throw NoHayIdiomasEditables
        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            'BitacoraBLL.CrearBitacora("El Metodo " & ex.TargetSite.ToString & " generó un error. Su mensaje es: " & ex.Message, TipoBitacora.Errores, (New UsuarioEntidad With {.ID_Usuario = 0, .Nombre = "Sistema"}))
            Throw ex
        End Try
    End Function

    Public Function ConsultarNombre(ByRef Idioma As String) As Boolean
        Try
            Return (New IdiomaMPP).ConsultarNombre(Idioma)
        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            'BitacoraBLL.CrearBitacora("El Metodo " & ex.TargetSite.ToString & " generó un error. Su mensaje es: " & ex.Message, TipoBitacora.Errores, (New UsuarioEntidad With {.ID_Usuario = 0, .Nombre = "Sistema"}))
            Throw ex
        End Try
    End Function

    Public Function ConsultarPorID(ByRef ID_Idioma As Integer) As IdiomaEntidad
        Try
            Return (New IdiomaMPP).ConsultarPorID(ID_Idioma)
        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarPorCultura(ByRef Cultura As String) As IdiomaEntidad
        Try
            If IsNothing(CultureInfo.GetCultureInfo(Cultura)) Then
                Return (New IdiomaMPP).ConsultarPorID(1)
            Else
                Return (New IdiomaMPP).ConsultarPorCultura(CultureInfo.GetCultureInfo(Cultura))
            End If
        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            'BitacoraBLL.CrearBitacora("El Metodo " & ex.TargetSite.ToString & " generó un error. Su mensaje es: " & ex.Message, TipoBitacora.Errores, (New UsuarioEntidad With {.ID_Usuario = 0, .Nombre = "Sistema"}))
            Throw ex
        End Try
    End Function
End Class
