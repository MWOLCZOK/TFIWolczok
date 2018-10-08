Public Class CategoriaProducto

    Private _id_categoria As Integer
    Public Property ID_Categoria() As Integer
        Get
            Return _id_categoria
        End Get
        Set(ByVal value As Integer)
            _id_categoria = value
        End Set
    End Property

    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property



End Class
