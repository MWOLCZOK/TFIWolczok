Public Class PermisoBaseEntidad

    Private _id_Permiso As Integer
    Public Property ID_Permiso() As Integer
        Get
            Return _id_Permiso
        End Get
        Set(ByVal value As Integer)
            _id_Permiso = value
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

    Public Function ValidarURL(paramURL As String) As Boolean
        If UCase(Me.URL) = UCase(paramURL) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function agregarHijo(Perm As PermisoBaseEntidad) As Boolean
        Return False
    End Function

    Public Function tieneHijos() As Boolean
        Return False
    End Function

    Public Function esValido(nombrePermiso As String) As Boolean
        Return Me.Nombre.Equals(nombrePermiso)
    End Function






End Class
