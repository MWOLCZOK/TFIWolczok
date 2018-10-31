Imports DAL
Imports Entidades
Imports System.Data.SqlClient


Public Class PagoMPP


    Public Function Alta(ByVal DetalleCompra As CompraEntidad, ByVal Fact As FacturaEntidad) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("insert into Pago (ID_Fact,ID_Prod,Cantidad,PrecioUnitario,Subtotal) values (@ID_Fact,@ID_Prod,@Cantidad,@PrecioUnitario,@Subtotal)")
            With Command.Parameters
                .Add(New SqlParameter("@ID_Fact", Fact.ID))
                .Add(New SqlParameter("@ID_Prod", DetalleCompra.Producto.ID_Producto))
                .Add(New SqlParameter("@Cantidad", DetalleCompra.Cantidad))
                .Add(New SqlParameter("@PrecioUnitario", DetalleCompra.Producto.Precio))
                .Add(New SqlParameter("@Subtotal", DetalleCompra.Subtotal))
            End With
            Acceso.Escritura(Command)
            Return True
        Catch ex As Exception
            Throw ex
        End Try

    End Function




End Class
