
Public Class LineaProducto

    Private _id_linea As Integer
    Public Property ID_Linea() As Integer
        Get
            Return _id_linea
        End Get
        Set(ByVal value As Integer)
            _id_linea = value
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
