Imports DAL
Imports Entidades
Imports System.Data.SqlClient




Public Class FacturaMPP


    Public Function Alta(ByVal Fact As FacturaEntidad) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("insert into Factura (ID_Cliente,MontoTotal,Fecha,EstadoCompra,EstadoEnvio,BL) OUTPUT INSERTED.ID_Fact values (@ID_Cliente, @MontoTotal,@Fecha,@EstadoCompra,@EstadoEnvio, @BL)")
            With Command.Parameters
                .Add(New SqlParameter("@ID_Cliente", Fact.Cliente.ID_Usuario))
                .Add(New SqlParameter("@MontoTotal", Fact.MontoTotal))
                .Add(New SqlParameter("@Fecha", Now))
                .Add(New SqlParameter("@EstadoCompra", Fact.EstadoCompra))
                .Add(New SqlParameter("@EstadoEnvio", 1))
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

            Next
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ModificarFactura(facturaEntidad As FacturaEntidad) As Boolean
        Try


            Dim Command As SqlCommand = Acceso.MiComando("Update Factura set EstadoCompra=@estadocompra , EstadoEnvio=@estadoenvio where ID_Fact=@ID_Fact")
            With Command.Parameters
                .Add(New SqlParameter("@ID_Fact", facturaEntidad.ID))
                .Add(New SqlParameter("@estadocompra", facturaEntidad.EstadoCompra))
                .Add(New SqlParameter("@estadoenvio", facturaEntidad.EstadoEnvio))
            End With

            Acceso.Escritura(Command)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function TraerFacturasGestion() As List(Of FacturaEntidad)
        Try
            Dim consulta As String = "Select * from Factura where  estadoenvio not in( 3,4)"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            Dim dt As DataTable = Acceso.Lectura(Command)
            Dim lista As New List(Of FacturaEntidad)
            For Each _dr As DataRow In dt.Rows
                Dim _factura As New FacturaEntidad
                FormatearFactura(_factura, _dr)
                lista.Add(_factura)
            Next
            Return lista
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

    Public Function BuscarFacturaRenglonesID(ByVal Factura As FacturaEntidad) As FacturaEntidad
        Try
            Dim consulta As String = "Select * from Factura_Renglones where ID_Fact=@ID_Factura"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_Factura", Factura.ID))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            For Each _dr As DataRow In dt.Rows
                Dim _facturadet As New CompraEntidad
                FormatearCompraEntidad(_facturadet, _dr)
                Factura.DetalleFactura.Add(_facturadet)
            Next
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function TraerFacturasGestionPorUsuario(ByVal usu As UsuarioEntidad) As List(Of FacturaEntidad)
        Try
            Dim consulta As String = "Select * from Factura where  ID_Cliente=@ID_Cliente and BL=0"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_Cliente", usu.ID_Usuario))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            Dim lista As New List(Of FacturaEntidad)
            For Each _dr As DataRow In dt.Rows
                Dim _factura As New FacturaEntidad
                FormatearFactura(_factura, _dr)
                lista.Add(_factura)
            Next
            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Private Sub FormatearCompraEntidad(facturadet As CompraEntidad, Row As DataRow)
        Try
            facturadet.ID = Row("ID_Fact_renglones")
            facturadet.Producto = (New ProductoMPP).TraerProducto(New ProductoEntidad With {.ID_Producto = Row("ID_Prod")})
            facturadet.Cantidad = Row("Cantidad")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub FormatearFactura(ByVal Fact As FacturaEntidad, ByVal row As DataRow)
        Try
            Fact.ID = row("ID_Fact")
            Fact.Cliente = (New UsuarioMPP).BuscarUsuarioID(New UsuarioEntidad With {.ID_Usuario = row("ID_Cliente")})
            Me.BuscarFacturaRenglonesID(Fact) ' Carga los detalles
            Fact.MontoTotal = row("MontoTotal")
            Fact.Fecha = row("Fecha")
            Fact.EstadoCompra = row("EstadoCompra")
            Fact.EstadoEnvio = row("EstadoEnvio")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub








End Class
