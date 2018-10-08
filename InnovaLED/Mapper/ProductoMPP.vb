Imports System.Data.SqlClient
Imports DAL
Imports Entidades


Public Class ProductoMPP


    Public Function ActualizaImagen(imagen() As Byte, id_Producto As Integer) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("update ProductoEntidad set Imagen=@Imagen where ID_Producto=@ID_Producto")
            With Command.Parameters
                .Add(New SqlParameter("@ID_Producto", id_Producto))
                .Add(New SqlParameter("@Imagen", imagen))
            End With
            Acceso.Escritura(Command)
            Command.Dispose()
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TraerProductosCatalogo(ByVal paginacion As Integer) As List(Of Producto)

        Try
            Dim consulta As String = "select * from ProductoEntidad order by id_producto offset (@count) rows FETCH NEXT (@cant) ROWS ONLY"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@count", (paginacion - 1) * 5))
                .Add(New SqlParameter("@cant", 5))
            End With

            Dim dt As DataTable = Acceso.Lectura(Command)
            Dim Listaproducto As List(Of Producto) = New List(Of Producto)
            For Each row As DataRow In dt.Rows
                Dim Producto As Producto = New Producto
                FormatearProducto(Producto, row)
                Listaproducto.Add(Producto)
            Next
            Return Listaproducto
        Catch ex As Exception
            Throw ex
        End Try

    End Function






    Public Sub FormatearProducto(ByVal Producto As Entidades.Producto, ByVal row As DataRow)
        Try

            Producto.ID_Producto = row("ID_Producto")
            Producto.Modelo = row("Modelo")
            Producto.Peso = row("Peso")
            Producto.Watt = row("Watt")
            Producto.Imagen = row("Imagen")
            Producto.Precio = row("Precio")
            'producto.LineaProducto = ""
            'producto.CategoriaProducto = ""

        Catch ex As Exception
            Throw ex
        End Try
    End Sub






End Class
