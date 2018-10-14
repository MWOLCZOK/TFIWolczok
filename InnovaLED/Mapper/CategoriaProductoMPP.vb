Imports System.Data.SqlClient
Imports DAL
Imports Entidades



Public Class CategoriaProductoMPP



    Public Function obtenerCategoriaProducto(ByVal categoria_producto As Entidades.CategoriaProducto) As Entidades.CategoriaProducto
        Try
            Dim consulta As String = "Select * from CategoriaProducto where ID_Categoria=@ID_Categoria"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_Categoria", categoria_producto.ID_Categoria))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            If dt.Rows.Count = 1 Then
                FormatearCategoriaProducto(categoria_producto, dt.Rows(0))
                Return categoria_producto
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function




    Public Sub FormatearCategoriaProducto(ByVal categoria_producto As Entidades.CategoriaProducto, ByVal row As DataRow)
        Try
            categoria_producto.ID_Categoria = row("ID_Categoria")
            categoria_producto.Descripcion = row("Descripcion")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



End Class
