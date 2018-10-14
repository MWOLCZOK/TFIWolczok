Imports System.Data.SqlClient
Imports DAL
Imports Entidades



Public Class LineaProductoMPP



    Public Function obtenerLineaProducto(ByVal linea_producto As Entidades.LineaProducto) As Entidades.LineaProducto
        Try
            Dim consulta As String = "Select * from LineaProducto where ID_Linea=@ID_Linea"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_Linea", linea_producto.ID_Linea))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            If dt.Rows.Count = 1 Then
                FormatearLineaProducto(linea_producto, dt.Rows(0))
                Return linea_producto
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function



    Public Function obtenerLineaProducto() As List(Of Entidades.LineaProducto)
        Try
            Dim consulta As String = "Select * from LineaProducto where BL=0"
            Dim lista_lineas As New List(Of LineaProducto)
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            Dim dt As DataTable = Acceso.Lectura(Command)
            For Each row As DataRow In dt.Rows
                Dim obj_lin As New LineaProducto
                FormatearLineaProducto(obj_lin, row)
                lista_lineas.Add(obj_lin)
            Next
            Return lista_lineas
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Sub FormatearLineaProducto(ByVal linea_Producto As Entidades.LineaProducto, ByVal row As DataRow)
        Try
            linea_Producto.ID_Linea = row("ID_Linea")
            linea_Producto.Descripcion = row("Descripcion")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



End Class
