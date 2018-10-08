Public Class Producto

    Private _id_producto As Integer
    Public Property ID_Producto() As Integer
        Get
            Return _id_producto
        End Get
        Set(ByVal value As Integer)
            _id_producto = value
        End Set
    End Property

    Private _modelo As String
    Public Property Modelo() As String
        Get
            Return _modelo
        End Get
        Set(ByVal value As String)
            _modelo = value
        End Set
    End Property

    Private _peso As Integer
    Public Property Peso() As Integer
        Get
            Return _peso
        End Get
        Set(ByVal value As Integer)
            _peso = value
        End Set
    End Property

    Private _precio As Integer
    Public Property Precio() As Integer
        Get
            Return _precio
        End Get
        Set(ByVal value As Integer)
            _precio = value
        End Set
    End Property

    Private _categoria As CategoriaProducto
    Public Property CategoriaProducto() As CategoriaProducto
        Get
            Return _categoria
        End Get
        Set(ByVal value As CategoriaProducto)
            _categoria = value
        End Set
    End Property


    Private _watt As Integer
    Public Property Watt() As Integer
        Get
            Return _watt
        End Get
        Set(ByVal value As Integer)
            _watt = value
        End Set
    End Property

    Private _lineaproducto As LineaProducto
    Public Property LineaProducto() As LineaProducto
        Get
            Return _lineaproducto
        End Get
        Set(ByVal value As LineaProducto)
            _lineaproducto = value
        End Set
    End Property

    Private _Imagen As Byte()
    Public Property Imagen() As Byte()
        Get
            Return _Imagen
        End Get
        Set(ByVal value As Byte())
            _Imagen = value
        End Set
    End Property




End Class
