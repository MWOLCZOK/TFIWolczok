Imports DAL
Imports Entidades
Imports System.Data.SqlClient




Public Class FacturaMPP


    Public Function Alta(ByVal Fact As FacturaEntidad) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("insert into Factura (ID_Cliente,MontoTotal,Fecha,EstadoCompra,BL) OUTPUT INSERTED.ID_Fact values (@ID_Cliente, @MontoTotal,@Fecha,@EstadoCompra, @BL)")
            With Command.Parameters
                .Add(New SqlParameter("@ID_Cliente", Fact.Cliente.ID_Usuario))
                .Add(New SqlParameter("@MontoTotal", Fact.MontoTotal))
                .Add(New SqlParameter("@Fecha", Now))
                .Add(New SqlParameter("@EstadoCompra", Fact.Estado))
                .Add(New SqlParameter("@BL", False))
            End With

            Fact.ID = Acceso.Scalar(Command)

            ' Región Detalle de Factura // Sumo los detalles de la factura a la factura.

            For Each _renglon As CompraEntidad In Fact.DetalleFactura
                Dim Command2 As SqlCommand = Acceso.MiComando("insert into Factura_Renglones (ID_Fact,ID_Prod,Cantidad,PrecioUnitario,Subtotal) values (@ID_Fact,@ID_Prod,@Cantidad,@PrecioUnitario,@Subtotal)")

                With Command2.Parameters
                    .Add(New SqlParameter("@ID_Fact", Fact.ID))
                    .Add(New SqlParameter("@ID_Prod", _renglon.Producto.ID_Producto))
                    .Add(New SqlParameter("@Cantidad", _renglon.Cantidad))
                    .Add(New SqlParameter("@PrecioUnitario", _renglon.Producto.Precio))
                    .Add(New SqlParameter("@Subtotal", _renglon.Subtotal))
                End With
                Acceso.Escritura(Command2)

                'Región Notas de crédito dentro de Factura // Si utilizo Nota de crédito la inserto en la tabla Factura_DocFinanciero.

                For Each _nota As DocumentoFinancieroEntidad In Fact.Notas
                    Dim Command3 As SqlCommand = Acceso.MiComando("insert into Factura_DocFinanciero (ID_Fact,ID_DocFinanciero,Monto,Fecha) values (@ID_Fact,@ID_DocFinanciero,@Monto,@Fecha)")
                    With Command3.Parameters
                        .Add(New SqlParameter("@ID_Fact", Fact.ID))
                        .Add(New SqlParameter("@ID_DocFinanciero", _nota.ID))
                        .Add(New SqlParameter("@Monto", _nota.Monto))
                        .Add(New SqlParameter("@Fecha", Now))
                    End With
                    Acceso.Escritura(Command3)
                Next
            Next
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function BuscarFacturaID(ByVal Factura As FacturaEntidad) As FacturaEntidad
        Try
            Dim consulta As String = "Select * from Factura where ID_Factura=@ID_Factura"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_Factura", Factura.ID))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            If dt.Rows.Count > 0 Then
                FormatearFactura(Factura, dt.Rows(0))
                Return Factura
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Sub FormatearFactura(ByVal Fact As FacturaEntidad, ByVal row As DataRow)
        Try
            Fact.ID = row("ID_Fact")
            Fact.Cliente = (New UsuarioMPP).BuscarUsuarioID(New UsuarioEntidad With {.ID_Usuario = row("ID_Cliente")})
            Fact.DetalleFactura = row("Detalle")
            Fact.MontoTotal = row("MontoTotal")
            Fact.Fecha = row("Fecha")
            Fact.Estado = row("EstadoCompra")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub








End Class
