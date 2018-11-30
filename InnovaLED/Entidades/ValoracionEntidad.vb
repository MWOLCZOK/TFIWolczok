Public Class ValoracionEntidad
    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _producto As ProductoEntidad
    Public Property Producto() As ProductoEntidad
        Get
            Return _producto
        End Get
        Set(ByVal value As ProductoEntidad)
            _producto = value
        End Set
    End Property

    Private _usuario As UsuarioEntidad
    Public Property Usuario() As UsuarioEntidad
        Get
            Return _usuario
        End Get
        Set(ByVal value As UsuarioEntidad)
            _usuario = value
        End Set
    End Property

    Private _valor As Integer
    Public Property Valor() As Integer
        Get
            Return _valor
        End Get
        Set(ByVal value As Integer)
            _valor = value
        End Set
    End Property
    Private _fecha As DateTime
    Public Property Fecha() As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property
    Private _texto As String
    Public Property Texto() As String
        Get
            Return _texto
        End Get
        Set(ByVal value As String)
            _texto = value
        End Set
    End Property
    Private _facturaid As Integer
    Public Property FacturaID() As Integer
        Get
            Return _facturaid
        End Get
        Set(ByVal value As Integer)
            _facturaid = value
        End Set
    End Property
End Class
