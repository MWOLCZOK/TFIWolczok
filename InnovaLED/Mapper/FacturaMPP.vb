Imports DAL
Imports Entidades
Imports System.Data.SqlClient




Public Class FacturaMPP


    Public Function Alta(ByVal cliente As UsuarioEntidad, ByVal DetalleCompra As CompraEntidad, ByVal Fact As FacturaEntidad) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("insert into Factura (Detalle,MontoTotal,Fecha,EstadoCompra,BL) values (@Detalle, @MontoTotal,@Fecha,@EstadoCompra, @BL)")
            With Command.Parameters
                .Add(New SqlParameter("@Detalle", DetalleCompra.Producto.Descripcion))
                .Add(New SqlParameter("@MontoTotal", DetalleCompra.Subtotal))
                .Add(New SqlParameter("@Fecha", Now))
                .Add(New SqlParameter("@EstadoCompra", Fact.Estado))
                .Add(New SqlParameter("@BL", False))
            End With
            Acceso.Escritura(Command)
            Return True
        Catch ex As Exception
            Throw ex
        End Try

    End Function




End Class
