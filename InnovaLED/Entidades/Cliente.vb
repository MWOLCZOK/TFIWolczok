Public Class ClienteEntidad

    Private _id As Integer
    Public Property ID_Cliente() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _domicilio As String
    Public Property DomicilioFacturacion() As String
        Get
            Return _domicilio
        End Get
        Set(ByVal value As String)
            _domicilio = value
        End Set
    End Property


    Private _telefono As String
    Public Property Telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
        End Set
    End Property

    Private _usuario As UsuarioEntidad
    Public Property UsuarioEntidad() As UsuarioEntidad
        Get
            Return _usuario
        End Get
        Set(ByVal value As UsuarioEntidad)
            _usuario = value
        End Set
    End Property






End Class
