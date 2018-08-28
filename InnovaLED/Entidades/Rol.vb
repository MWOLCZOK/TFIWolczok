Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class Rol

    Implements ICloneable


    Private _id_rol As Integer
    Public Property ID_Rol() As Integer
        Get
            Return _id_rol
        End Get
        Set(ByVal value As Integer)
            _id_rol = value
        End Set
    End Property

    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property
    Private _url As String
    Public Property URL() As String
        Get
            Return _url
        End Get
        Set(ByVal value As String)
            _url = value
        End Set
    End Property



    Private _hijos As New List(Of PermisoBaseEntidad)
    Public ReadOnly Property Hijos() As List(Of PermisoBaseEntidad)
        Get
            Return _hijos
        End Get
    End Property

    Public Function ValidarURL(paramURL As String) As Boolean

        Return _hijos.Any(Function(Permiso) Permiso.ValidarURL(paramURL))
    End Function


    Public Function agregarHijo(Perm As PermisoBaseEntidad) As Boolean
        If Not _hijos.Contains(Perm) Then
            Me._hijos.Add(Perm)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function tieneHijos() As Boolean
        Return True
    End Function

    Public Function esValido(nombrePermiso As String) As Boolean
        Dim tieneUnValido As Boolean = False
        If nombrePermiso = Me.Nombre Then
            Return True
        End If
        For Each p In Me._hijos
            If p.Nombre = nombrePermiso Then
                Return True
            Else
                tieneUnValido = p.esValido(nombrePermiso)
            End If
            If tieneUnValido = True Then
                Exit For
            Else

            End If

        Next
        Return tieneUnValido
    End Function
    Public Function Clone() As Object Implements ICloneable.Clone
        Dim m As New MemoryStream()
        Dim f As New BinaryFormatter()
        f.Serialize(m, Me)
        m.Seek(0, SeekOrigin.Begin)
        Return f.Deserialize(m)
    End Function










End Class
