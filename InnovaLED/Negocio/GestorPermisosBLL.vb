Imports Entidades
Imports Mapper



Public Class GestorPermisosBLL

    Private PermisosMPP As GestorPermisosMPP

    Public Function Alta(ByVal perm As PermisoBaseEntidad) As Boolean
        'Try
        '    If ValidarNombre(perm.Nombre) Then
        '        PermisosMPP = New GestorPermisosMPP
        '        PermisosMPP.Alta(perm)
        '        Return True
        '    Else
        '        Return False
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Function

    Public Function Baja(ByVal Perfil As RolEntidad)
        Try
            PermisosMPP = New GestorPermisosMPP
            Return PermisosMPP.Baja(Perfil.ID_Rol)
        Catch ExcepcionUsuario As ExceptionIntegridadUsuario
            Throw ExcepcionUsuario
        Catch ExcepcionBitacora As ExceptionIntegridadBitacora
            Throw ExcepcionBitacora
        Catch ExcepcionEvento As ExceptionIntegridadEvento
            Throw ExcepcionEvento
        Catch FalloConexion As InvalidOperationException
            'Dim Bitacora As New BitacoraEntidad("No se pudo eliminar el Perfil: " & Perfil.Nombre & " en el sistema. Error de Conexion", TipoBitacora.Baja, SessionBLL.SesionActual.ObtenerUsuarioActual)
            'BitacoraBLL.ArchivarBitacora(Bitacora)
            Throw FalloConexion
        Catch ex As Exception
            'BitacoraBLL.CrearBitacora("El Metodo " & ex.TargetSite.ToString & " generó un error. Su mensaje es: " & ex.Message, TipoBitacora.Errores, (New UsuarioEntidad With {.ID_Usuario = 0, .Nombre = "Sistema"}))
            Throw ex
        End Try
    End Function


    Public Sub Modificar(ByVal perm As PermisoBaseEntidad)
        'Try
        '    PermisosMPP = New GestorPermisosMPP
        '    PermisosMPP.Modificar(perm)
        '    '    BitacoraBLL.CrearBitacora("Se modificó el Perfil: " & perm.Nombre & " en el sistema.", TipoBitacora.Modificación, SessionBLL.SesionActual.ObtenerUsuarioActual)
        'Catch FalloConexion As InvalidOperationException
        '    'Dim Bitacora As New BitacoraEntidad("No se pudo modificar el Perfil: " & perm.Nombre & " en el sistema. Error de Conexion", TipoBitacora.Modificación, SessionBLL.SesionActual.ObtenerUsuarioActual)
        '    'BitacoraBLL.ArchivarBitacora(Bitacora)
        '    'Throw FalloConexion
        'Catch ex As Exception
        '    'BitacoraBLL.CrearBitacora("El Metodo " & ex.TargetSite.ToString & " generó un error. Su mensaje es: " & ex.Message, TipoBitacora.Errores, (New UsuarioEntidad With {.ID_Usuario = 0, .Nombre = "Sistema"}))
        '    Throw ex
        'End Try
    End Sub

    Public Function ListarFamilias(ByVal filtro As Boolean) As List(Of PermisoBaseEntidad)
        Try
            Dim Permisos As List(Of PermisoBaseEntidad) = New List(Of PermisoBaseEntidad)
            Permisos = (New GestorPermisosMPP).ListarFamilias(filtro)
            If Permisos.Count > 0 Then
                Return Permisos
            Else
                Throw New ExceptionNoHayPerfiles
            End If
        Catch NoHayPerfiles As ExceptionNoHayPerfiles
            Throw NoHayPerfiles
        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            'BitacoraBLL.CrearBitacora("El Metodo " & ex.TargetSite.ToString & " generó un error. Su mensaje es: " & ex.Message, TipoBitacora.Errores, (New UsuarioEntidad With {.ID_Usuario = 0, .Nombre = "Sistema"}))
            Throw ex
        End Try
    End Function

    Public Function ConsultarporID(ByVal ID As Integer) As RolEntidad
        Try
            Dim Permisos As RolEntidad = New RolEntidad
            Permisos = (New GestorPermisosMPP).ConsultarporID(ID)
            If Not IsNothing(Permisos) Then
                If Permisos.ID_Rol = 0 Then
                    Throw New ExceptionPermisoNoExiste
                End If
                Return Permisos
            Else
                Throw New ExceptionPermisoNoExiste
            End If
        Catch PermisoNoExiste As ExceptionPermisoNoExiste
            Throw PermisoNoExiste
        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            'BitacoraBLL.CrearBitacora("El Metodo " & ex.TargetSite.ToString & " generó un error. Su mensaje es: " & ex.Message, TipoBitacora.Errores, (New UsuarioEntidad With {.ID_Usuario = 0, .Nombre = "Sistema"}))
            Throw ex
        End Try
    End Function


    Public Function ListarPermisos() As List(Of PermisoBaseEntidad)
        Try
            PermisosMPP = New GestorPermisosMPP
            Return PermisosMPP.ListarPermisos()
        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            'BitacoraBLL.CrearBitacora("El Metodo " & ex.TargetSite.ToString & " generó un error. Su mensaje es: " & ex.Message, TipoBitacora.Errores, (New UsuarioEntidad With {.ID_Usuario = 0, .Nombre = "Sistema"}))
            Throw ex
        End Try
    End Function

    Public Function ValidarNombre(ByVal nombrepermiso As String) As Boolean
        Try
            PermisosMPP = New GestorPermisosMPP
            Return PermisosMPP.ValidarNombre(nombrepermiso)
        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            'BitacoraBLL.CrearBitacora("El Metodo " & ex.TargetSite.ToString & " generó un error. Su mensaje es: " & ex.Message, TipoBitacora.Errores, (New UsuarioEntidad With {.ID_Usuario = 0, .Nombre = "Sistema"}))
            Throw ex
        End Try
    End Function










End Class
