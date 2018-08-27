Imports System.Data.SqlClient
Imports Entidades
Imports DAL



Public Class GestorPermisosMPP

    Public Sub Alta(ByVal perm As Rol)

    End Sub

    Public Function Baja(ByVal ID As Integer) As Boolean

    End Function

    Public Sub Modificar(ByVal perm As Rol)

    End Sub

    Public Function ListarFamilias(ByVal filtro As Boolean) As List(Of PermisoBaseEntidad)

    End Function

    Public Function ConsultarporID(ByVal ID As Integer) As Entidades.Rol
        Try
            Dim Command As SqlCommand = Acceso.MiComando("Select * from Permiso where ID_ROL=@ID_ROL")
            Command.Parameters.Add(New SqlParameter("@ID_ROL", ID))
            Dim _dt As DataTable = Acceso.Lectura(Command)
            If _dt.Rows.Count = 1 Then
                Return ConvertirDataRowEnPermiso(_dt.Rows(0))
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ListarPermisos() As List(Of PermisoBaseEntidad)
        Try
            Dim _listaPermisos As New List(Of PermisoBaseEntidad)
            Dim Command As SqlCommand
            Command = Acceso.MiComando("Select * from Permiso where esCliente=0 and ID_Rol > 0 order by esAccion asc, ID_Rol asc")
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
            Dim Command As SqlCommand = Acceso.MiComando("select Nombre from Permiso where Nombre=@Nombre")
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

    'Ver Con Marki
    Private Function ConvertirDataRowEnPermiso(_dr As DataRow) As PermisoBaseEntidad
        Try
            Dim _permiso As PermisoBaseEntidad
            If Not _dr.Item("esAccion") Is DBNull.Value AndAlso Convert.ToBoolean(_dr.Item("esAccion")) Then
                _permiso = New PermisoBaseEntidad
            Else
                _permiso = New Rol
            End If
            _permiso.ID_Permiso = CInt(_dr.Item("ID_Rol"))
            _permiso.Nombre = Convert.ToString(_dr.Item("Nombre"))
            _permiso.URL = Convert.ToString(_dr.Item("URL"))
            If _permiso.tieneHijos Then
                Dim ListaHijos As List(Of PermisoBaseEntidad) = Me.ListarHijos(_permiso.ID_Permiso)
                For Each hijo As PermisoBaseEntidad In ListaHijos
                    _permiso.agregarHijo(hijo)
                Next
            End If
            Return _permiso
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Function ListarHijos(ByVal _id As Integer) As List(Of PermisoBaseEntidad)
        Try
            Dim lista As List(Of PermisoBaseEntidad) = New List(Of PermisoBaseEntidad)
            Dim Command As SqlClient.SqlCommand = Acceso.MiComando("SELECT P.ID_ROL,Nombre,esAccion,URL FROM Permiso as P LEFT JOIN Permiso_Permiso as PP ON (PP.ID_Permiso=P.ID_ROL) WHERE PP.ID_ROL = @IDPadre  ORDER BY P.ID_Rol ASC")
            Command.Parameters.Add(New SqlParameter("@IDPadre", _id))
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











End Class
