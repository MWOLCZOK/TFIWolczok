Imports Entidades
Imports Mapper

Public Class GestorLineaProdBLL

    Dim gestorlineaMPP As New LineaProductoMPP

    Public Function TraerTodasLineasProd() As List(Of LineaProducto)
        Return gestorlineaMPP.obtenerLineaProducto()

    End Function



End Class
