Imports DAL
Imports Entidades
Imports System.Data.SqlClient


Public Class PagoMPP


    Public Function Alta(ByVal pago As PagoEntidad) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("insert into Pago (ID_Fact,TipoPago,Fecha,Monto,BL) values (@ID_Fact,@TipoPago,@Fecha,@Monto,@BL)")
            With Command.Parameters
                .Add(New SqlParameter("@ID_Fact", pago.Factura.ID))
                .Add(New SqlParameter("TipoPago", pago.TipoPago))
                .Add(New SqlParameter("TipoPago", pago.Fecha))
                .Add(New SqlParameter("Monto", pago.Monto))
                .Add(New SqlParameter("BL", False))
            End With
            Acceso.Escritura(Command)
            Return True
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub FormatearPago(ByVal Pago As PagoEntidad, ByVal row As DataRow)
        Try
            Pago.ID_Pago = row("ID_Pago")
            Pago.Factura = (New FacturaMPP).BuscarFacturaID(New FacturaEntidad With {.ID = row("ID_Fact")})
            Pago.TipoPago = row("TipoPago")
            Pago.Fecha = row("Fecha")
            Pago.Monto = row("Monto")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub






End Class
