
Imports System.Xml.Serialization
Imports System.IO
Imports Entidades
Imports Mapper
'imports system.web.httpcontext

Public Class UsuarioBLL

    Private UsuarioMPP As New UsuarioMPP
    Private UsuarioEntidad As New UsuarioEntidad


    Public Function ValidarNombre(usu As UsuarioEntidad) As Boolean
        Try

            If IsNothing((New UsuarioMPP).ExisteUsuario(usu)) Then
                Return True
            Else
                Return False
            End If
        Catch ExcepcionUsuario As ExceptionIntegridadUsuario
            Throw ExcepcionUsuario
        Catch ExcepcionBitacora As ExceptionIntegridadBitacora
            Throw ExcepcionBitacora
        Catch ExcepcionEvento As ExceptionIntegridadEvento
            Throw ExcepcionEvento
        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function CreateToken(ByRef usu As Entidades.UsuarioEntidad) As String
        Try
            Return UsuarioMPP.CrearToken(usu, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub LimpiarTokens(ByVal Token As String)
        Try
            UsuarioMPP.LimpiarTokens(Token)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function ACtivarUsuario(ByVal token As String) As Boolean
        Try
            Dim usuario As New Entidades.UsuarioEntidad
            usuario.ID_Usuario = UsuarioMPP.GetTokenUser(token)
            If Not IsNothing(usuario.ID_Usuario) And usuario.ID_Usuario > 0 Then
                Return UsuarioMPP.Bloquear(UsuarioMPP.BuscarUsuarioID(usuario))
            Else
                Return True
            End If

        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ExisteUsuario(ByVal Usuario As UsuarioEntidad) As UsuarioEntidad
        Try
            Dim UsuarioRetorno As UsuarioEntidad = New UsuarioEntidad
            Dim Pass As String = Usuario.Password
            UsuarioRetorno = UsuarioMPP.ExisteUsuario(Usuario)
            If Not IsNothing(UsuarioRetorno) Then
                If EncriptarBLL.EncriptarPassword(Pass, UsuarioRetorno.Salt).Item(0) = UsuarioRetorno.Password Then
                    If UsuarioRetorno.Bloqueo = False Then
                        Usuario.Intento = 0
                        Me.ResetearIntentos(UsuarioRetorno)
                        Return UsuarioRetorno
                    Else
                        Throw New ExceptionUsuarioBloqueado
                    End If
                Else
                    Usuario.Intento += 1
                    UsuarioMPP.SumarIntentos(Usuario)
                    If Usuario.Intento > 2 Then
                        UsuarioMPP.Bloquear(Usuario)
                        Throw New ExceptionPasswordIncorrecta
                    End If
                    Throw New ExceptionPasswordIncorrecta
                End If

            Else
                Throw New ExceptionUsuarioNoExiste
            End If

        Catch ExcepcionUsuario As ExceptionIntegridadUsuario
            Throw ExcepcionUsuario
        Catch ExcepcionBitacora As ExceptionIntegridadBitacora
            Throw ExcepcionBitacora
        Catch ExcepcionEvento As ExceptionIntegridadEvento
            Throw ExcepcionEvento
        Catch UsuarioBloqueado As ExceptionUsuarioBloqueado
            Throw UsuarioBloqueado
        Catch ExcepcionUsuarioNoExiste As ExceptionUsuarioNoExiste
            Throw ExcepcionUsuarioNoExiste
        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            Throw ex
        End Try

    End Function



    Public Sub RefrescarUsuario(ByRef USuario As Entidades.UsuarioEntidad)
        Try
            UsuarioMPP.RefrescarUsuario(USuario)
        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Function TraerUsuariosIdioma(ByVal ID_Idioma As Integer) As List(Of UsuarioEntidad)
        Try

            Return UsuarioMPP.TraerUsuariosIdioma(ID_Idioma)

        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function Alta(ByVal Usuario As UsuarioEntidad) As Boolean
        Try
            If Me.ValidarNombre(Usuario) Then
                If UsuarioMPP.Alta(Usuario) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Throw New ExceptionNombreEnUso
            End If

        Catch NombreUso As ExceptionNombreEnUso
            Throw NombreUso
        Catch FalloConexion As InvalidOperationException

            Throw FalloConexion
        Catch ex As Exception

            Throw ex
        End Try
    End Function


    Public Function GEtToken(ByVal ID_Usuario As Integer) As String
        Try
            Return UsuarioMPP.GetToken(ID_Usuario)
        Catch FalloConexion As InvalidOperationException

            Throw FalloConexion
        Catch ex As Exception

            Throw ex
        End Try
    End Function

    Public Function Modificar(ByVal Usuario As UsuarioEntidad) As Boolean
        Try
            If UsuarioMPP.Modificar(Usuario) Then
                Return True
            Else
                Return False
            End If
        Catch FalloConexion As InvalidOperationException

            Throw FalloConexion
        Catch ex As Exception

        End Try

    End Function


    Public Function Eliminar(ByVal Usuario As UsuarioEntidad) As Boolean
        Try
            If UsuarioMPP.Eliminar(Usuario) Then
                Return True
            Else
                Return False
            End If
        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function TraerUsuarios() As List(Of UsuarioEntidad)
        Try

            Return UsuarioMPP.TraerUsuarios()

        Catch ExcepcionUsuario As ExceptionIntegridadUsuario
            Throw ExcepcionUsuario
        Catch ExcepcionBitacora As ExceptionIntegridadBitacora
            Throw ExcepcionBitacora
        Catch ExcepcionEvento As ExceptionIntegridadEvento
            Throw ExcepcionEvento
        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function TraerUsuariosParaBloqueo(ByRef Usuario As Entidades.UsuarioEntidad) As List(Of UsuarioEntidad)
        Try

            Return UsuarioMPP.TraerUsuariosParaBloqueo(Usuario)
        Catch ExcepcionUsuario As ExceptionIntegridadUsuario
            Throw ExcepcionUsuario
        Catch ExcepcionBitacora As ExceptionIntegridadBitacora
            Throw ExcepcionBitacora
        Catch ExcepcionEvento As ExceptionIntegridadEvento
            Throw ExcepcionEvento
        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function TraerUsuariosPerfil(ByRef ID_Perfil As Integer) As List(Of UsuarioEntidad)
        Try

            Return UsuarioMPP.TraerUsuariosPerfil(ID_Perfil)

        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function VerificarPassword(ByVal Usuario As UsuarioEntidad) As Boolean
        Try

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Sub ResetearIntentos(ByVal paramusuarioentidad As UsuarioEntidad)
        Try
            UsuarioMPP.ResetearIntentos(paramusuarioentidad)
        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub SumarIntentos(ByVal Usuario As UsuarioEntidad)
        Try
            Usuario.Intento += 1
            UsuarioMPP.SumarIntentos(Usuario)
            If Usuario.Intento > 2 Then
                UsuarioMPP.Bloquear(Usuario)
            End If

        Catch ExcepcionUsuario As ExceptionIntegridadUsuario
            Throw ExcepcionUsuario
        Catch ExcepcionBitacora As ExceptionIntegridadBitacora
            Throw ExcepcionBitacora
        Catch ExcepcionEvento As ExceptionIntegridadEvento
            Throw ExcepcionEvento
        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function CambiarPassword(ByRef Usuario As UsuarioEntidad, Optional ByVal token As String = Nothing) As Boolean
        Try
            If Not IsNothing(token) Then
                Dim usu As New Entidades.UsuarioEntidad
                usu.ID_Usuario = UsuarioMPP.GetTokenUser(token)
                UsuarioMPP.BuscarUsuarioID(usu)
                usu.Salt = Usuario.Salt
                usu.Password = Usuario.Password
                If usu.ID_Usuario > 0 Then
                    If UsuarioMPP.CambiarPassword(usu) Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If

            Else
                If UsuarioMPP.CambiarPassword(Usuario) Then
                    Return True
                Else
                    Return False
                End If
            End If

        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function Bloquear(ByRef Usuario As UsuarioEntidad) As Boolean
        Try
            If UsuarioMPP.Bloquear(Usuario) Then
                Return True
            Else
                Return False
            End If
        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function ProbarConectividad() As Boolean
        Return (New Mapper.UsuarioMPP).ProbarConectividad
    End Function


End Class
