Imports DAL
Imports Entidades
Imports System.Data.SqlClient




Public Class FacturaMPP


    Public Function Alta(ByVal cliente As UsuarioEntidad, ByVal DetalleCompra As CompraEntidad) As FacturaEntidad
        Try
            Dim Command As SqlCommand = Acceso.MiComando("insert into Factura (Detalle,MontoTotal,Fecha,EstadoCompra,BL) values (@Detalle, @MontoTotal,@Fecha,@EstadoCompra, @BL)")
            With Command.Parameters
                .Add(New SqlParameter("@Detalle", DetalleCompra.Producto.Descripcion))
                .Add(New SqlParameter("@MontoTotal", DetalleCompra.Subtotal))
                .Add(New SqlParameter("@Fecha", Now))
                .Add(New SqlParameter("@EstadoCompra", DetalleCompra.))
                .Add(New SqlParameter("@Peso", Producto.Peso))
                .Add(New SqlParameter("@Watt", Producto.Watt))
                .Add(New SqlParameter("@Imagen", Producto.Imagen))
                .Add(New SqlParameter("@ID_Linea", Producto.LineaProducto.ID_Linea))
                .Add(New SqlParameter("@ID_CategoriaProducto", Producto.CategoriaProducto.ID_Categoria))
                .Add(New SqlParameter("@BL", False))
            End With
            Acceso.Escritura(Command)
            Return True
        Catch ex As Exception
            Throw ex
        End Try
        Try
            'Dim Command As Sql



        Catch ex As Exception

        End Try







    End Function




End Class
