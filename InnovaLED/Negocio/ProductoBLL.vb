Imports Mapper


Public Class ProductoBLL

    Dim productoMPP As New ProductoMPP


    Public Sub ActualizaImagen(imagen() As Byte, id_Producto As Integer)
        productoMPP.ActualizaImagen(imagen, id_Producto)
    End Sub


    Public Function TraerProductosCatalogo(ByVal paginacion As Integer) As List(Of Entidades.Producto)
        Return productoMPP.TraerProductosCatalogo(paginacion)

    End Function




End Class
