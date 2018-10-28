Imports Mapper
Imports Entidades



Public Class GestorCategoriaProdBLL

    Dim gestorcategoria As New CategoriaProductoMPP

    Public Function TraerTodasCatProd() As List(Of CategoriaProducto)
        Return gestorcategoria.obtenerCategoriaProducto()

    End Function

End Class
