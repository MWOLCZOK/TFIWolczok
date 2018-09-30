Imports System.Data.SqlClient
Imports Entidades
Imports DAL



Public Class GestorPermisosMPP



    Public Sub Alta(ByVal perm As RolEntidad)
        Try
            Dim Command As SqlCommand = Acceso.MiComando("insert into RolEntidad values(@Nombre)")
            With Command.Parameters
                    .Add(New SqlParameter("@Nombre", perm.Nombre))

            End With
                Dim ID As Integer = Acceso.Scalar(Command)
            perm.ID_Rol = ID

        Catch ex As Exception
            Throw ex
        End Try




    End Sub

    Public Function Baja(ByVal ID As Integer) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("Select ID_Usuario from UsuarioEntidad_RolEntidad where ID_Rol=@ID_Rol")
            With Command.Parameters
                .Add(New SqlParameter("@ID_Rol", ID))
            End With
            Dim dt_usu As DataTable = Acceso.Lectura(Command)
            Command.Dispose()
            If dt_usu.Rows.Count = 0 Then
                Command = Acceso.MiComando("delete from RolEntidad_PermisoBaseEntidad where ID_Rol=@ID_Rol")
                With Command.Parameters
                    .Add(New SqlParameter("@ID_Rol", ID))
                End With
                Acceso.Escritura(Command)
                Command.Dispose()
                Command = Acceso.MiComando("delete from RolEntidad where ID_Rol=@ID_Rol")
                With Command.Parameters
                    .Add(New SqlParameter("@ID_Rol", ID))
                End With
                Acceso.Escritura(Command)
                Command.Dispose()

                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try



    End Function

    Public Sub Modificar(ByVal perm As RolEntidad)

        Try
            Dim Command As SqlCommand = Acceso.MiComando("delete from RolEntidad_PermisoBaseEntidad where ID_Rol=@ID_Rol")
            With Command.Parameters
                .Add(New SqlParameter("@ID_Rol", perm.ID_Rol))
            End With
            Acceso.Escritura(Command)
            Command.Dispose()
            For Each MiPermiso As Entidades.PermisoBaseEntidad In perm.Hijos
                Command = Acceso.MiComando("insert into RolEntidad_PermisoBaseEntidad values (@ID_Rol, @ID_Permiso)")
                With Command.Parameters
                    .Add(New SqlParameter("@ID_Rol", perm.ID_Rol))
                    .Add(New SqlParameter("@ID_Permiso", MiPermiso.ID_Permiso))
                End With
                If Not perm.ID_Rol = MiPermiso.ID_Permiso Then
                    Acceso.Escritura(Command)
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try


    End Sub

    Public Function ListarFamilias() As List(Of RolEntidad)
        Try
            Dim _listaFamilias As New List(Of RolEntidad)
            Dim Command As SqlCommand
            Command = Acceso.MiComando("Select * from RolEntidad where ID_Rol > 2 order by ID_Rol asc")
            Dim _dt As DataTable = Acceso.Lectura(Command)
            For Each _dr As DataRow In _dt.Rows
                Dim _rol As RolEntidad = ConvertirDataRowEnRol(_dr)
                _listaFamilias.Add(_rol)
            Next
            Return _listaFamilias
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ListarFamiliasGestion() As List(Of RolEntidad)
        Try
            Dim _listaFamilias As New List(Of RolEntidad)
            Dim Command As SqlCommand
            Command = Acceso.MiComando("Select * from RolEntidad where ID_Rol > 0 order by ID_Rol asc")
            Dim _dt As DataTable = Acceso.Lectura(Command)
            For Each _dr As DataRow In _dt.Rows
                Dim _rol As RolEntidad = ConvertirDataRowEnRol(_dr)
                _listaFamilias.Add(_rol)
            Next
            Return _listaFamilias
        Catch ex As Exception
            Throw ex
        End Try

    End Function



    Public Function ConsultarporID(ByVal ID As Integer) As Entidades.RolEntidad
        'Try
        '    Dim Command As SqlCommand = Acceso.MiComando("Select * from Permiso where ID_ROL=@ID_ROL")
        '    Command.Parameters.Add(New SqlParameter("@ID_ROL", ID))
        '    Dim _dt As DataTable = Acceso.Lectura(Command)
        '    If _dt.Rows.Count = 1 Then
        '        Return ConvertirDataRowEnPermiso(_dt.Rows(0))
        '    Else
        '        Return Nothing
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try

    End Function

    'Public Function ListarRoles() As List(Of RolEntidad)
    '    Return ListarRoles
    'End Function

    Public Function ListarPermisos() As List(Of PermisoBaseEntidad)
        Try
            Dim _listaPermisos As New List(Of PermisoBaseEntidad)
            Dim Command As SqlCommand
            Command = Acceso.MiComando("Select * from PermisoBaseEntidad")
            Dim _dt As DataTable = Acceso.Lectura(Command)
            For Each _dr As DataRow In _dt.Rows
                Dim _permiso As PermisoBaseEntidad = ConvertirDataRowEnPermiso(_dr)
                _listaPermisos.Add(_permiso)
            Next
            Return _listaPermisos
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarNombre(ByVal Nombre As String) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("select Nombre from RolEntidad where Nombre=@Nombre")
            Command.Parameters.Add(New SqlParameter("@Nombre", Nombre))
            Dim DataTabla = Acceso.Lectura(Command)
            If DataTabla.Rows.Count > 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Function ConvertirDataRowEnPermiso(_dr As DataRow) As PermisoBaseEntidad
        Try
            Dim _permiso As New PermisoBaseEntidad
            _permiso.Nombre = Convert.ToString(_dr.Item("Nombre"))
            _permiso.ID_Permiso = CInt(_dr.Item("ID_Permiso"))
            _permiso.URL = Convert.ToString(_dr.Item("URL"))
            Return _permiso
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Function ConvertirDataRowEnRol(_dr As DataRow) As RolEntidad
        Try
            Dim _rol As New RolEntidad
            _rol.Nombre = Convert.ToString(_dr.Item("Nombre"))
            _rol.ID_Rol = CInt(_dr.Item("ID_Rol"))
            _rol.Hijos = Me.ListarHijos(_rol.ID_Rol)

            Return _rol
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Private Function ListarHijos(ByVal _id As Integer) As List(Of PermisoBaseEntidad)
        Try
            Dim lista As List(Of PermisoBaseEntidad) = New List(Of PermisoBaseEntidad)
            Dim Command As SqlClient.SqlCommand = Acceso.MiComando("Select * from RolEntidad_PermisoBaseEntidad as RP inner join PermisoBaseEntidad as PB on RP.ID_PermisoBase = PB.ID_Permiso where RP.ID_Rol=@ID_Rol")
            Command.Parameters.Add(New SqlParameter("@ID_Rol", _id))
            Dim dt As DataTable = Acceso.Lectura(Command)
            For Each row As DataRow In dt.Rows
                Dim MiPermiso As PermisoBaseEntidad = Me.ConvertirDataRowEnPermiso(row)
                lista.Add(MiPermiso)
            Next
            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Friend Function ConsultarporIDUsuario(iD_Usuario As Integer) As List(Of RolEntidad)

        Try
            Dim Command As SqlCommand = Acceso.MiComando("Select * from UsuarioEntidad_RolEntidad inner join RolEntidad on RolEntidad.ID_rol = UsuarioEntidad_RolEntidad.ID_Rol  where ID_Usuario=@ID_Usuario")
            Command.Parameters.Add(New SqlParameter("@ID_Usuario", iD_Usuario))
            Dim _dt As DataTable = Acceso.Lectura(Command)
            If _dt.Rows.Count > 0 Then
                Dim rolusuario As New List(Of RolEntidad)
                For Each _row In _dt.Rows
                    rolusuario.Add(ConvertirDataRowEnRol(_row))
                Next
                Return rolusuario

            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try



    End Function
End Class
