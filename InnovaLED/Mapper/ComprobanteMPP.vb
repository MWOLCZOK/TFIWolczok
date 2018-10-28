Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Entidades
Imports DAL


Public Class ComprobanteMPP

    'Public Function altaComprobante(ByVal paramComprobante As Entidades.Comprobante) As Integer
    '    Try
    '        Dim Command As SqlCommand = Acceso.MiComando("insert into Comprobante values (@ID_Comprobante, @Nro_Factura, @Sucursal, @Tipo, @ID_Persona, @Fecha_Emision, @Fecha_Vencimiento, @IVA, @Subtotal, @Estado)")

    '        Dim _idComprobante As Integer = DAL.Conexion.ObtenerID("Comprobante", "ID_Comprobante")
    '        Dim _nroFactura As Integer = DAL.Conexion.ObtenerID("Comprobante", "Nro_Factura")

    '        With Command.Parameters
    '            .Add(New SqlParameter("@ID_Comprobante", _idComprobante))
    '            .Add(New SqlParameter("@Nro_Factura", _nroFactura))
    '            .Add(New SqlParameter("@Sucursal", paramComprobante.Sucursal))
    '            .Add(New SqlParameter("@Tipo", paramComprobante.TipoFactura))
    '            .Add(New SqlParameter("@ID_Persona", paramComprobante.Persona.ID))
    '            .Add(New SqlParameter("@Fecha_Emision", paramComprobante.FechaEmision))
    '            .Add(New SqlParameter("@Fecha_Vencimiento", paramComprobante.FechaVencimiento))
    '            .Add(New SqlParameter("@IVA", paramComprobante.IVA))
    '            .Add(New SqlParameter("@Subtotal", paramComprobante.Subtotal))
    '            .Add(New SqlParameter("@Estado", paramComprobante.Estado))


    '        End With
    '        Acceso.Escritura(Command)

    '        For Each _renglon As Entidades.Comprobante_Detalle In paramComprobante.Renglon
    '            Dim _idComprobanteDetalle As Integer = DAL.Conexion.ObtenerID("Comprobante_Detalle", "ID_Comprobante_Detalle")
    '            MiComando = DAL.Conexion.retornaComando("insert into Comprobante_Detalle values (@ID_Comprobante_Detalle, @ID_Comprobante, @Cod_Carrera, @Cantidad, @Subtotal)")
    '            With MiComando.Parameters
    '                .Add(New SqlParameter("@ID_Comprobante_Detalle", _idComprobanteDetalle))
    '                .Add(New SqlParameter("@ID_Comprobante", _idComprobante))
    '                .Add(New SqlParameter("@Cod_Carrera", _renglon.Carrera.ID))
    '                .Add(New SqlParameter("@Cantidad", _renglon.Cantidad))
    '                .Add(New SqlParameter("@Subtotal", _renglon.Subtotal))
    '            End With
    '            DAL.Conexion.ExecuteNonQuery(MiComando)
    '        Next
    '        'SI USO NOTA GUARDO, SINO NO
    '        For Each _Nota As Entidades.Nota In paramComprobante.Notas
    '            MiComando = DAL.Conexion.retornaComando("insert into Factura_Nota values (@ID_Comprobante, @ID_Nota, @Monto, @Fecha)")
    '            With MiComando.Parameters
    '                .Add(New SqlParameter("@ID_Comprobante", _idComprobante))
    '                .Add(New SqlParameter("@ID_Nota", _Nota.ID))
    '                .Add(New SqlParameter("@Monto", _Nota.MontoaDescontar))
    '                .Add(New SqlParameter("@Fecha", Today))
    '            End With
    '            DAL.Conexion.ExecuteNonQuery(MiComando)
    '        Next
    '        Return _idComprobante
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    'Public Function obtenerComprobante(ByVal paramComprobante As Entidades.Comprobante) As Entidades.Comprobante
    '    Try
    '        Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("select * from Comprobante where ID_Comprobante=@ID_Comprobante")
    '        With MiComando.Parameters
    '            .Add(New SqlParameter("@ID_Comprobante", paramComprobante.ID))
    '        End With
    '        Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
    '        If _dt.Rows.Count = 1 Then
    '            Dim _comprobante As New Entidades.Comprobante
    '            Me.FormatearComprobante(_dt.Rows(0), _comprobante)
    '            Return _comprobante
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    'Public Function obtenerComprobanteNFactura(ByVal paramComprobante As Entidades.Comprobante) As Entidades.Comprobante
    '    Try
    '        Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("select * from Comprobante where Nro_Factura=@Nro_Factura")
    '        With MiComando.Parameters
    '            .Add(New SqlParameter("@Nro_Factura", paramComprobante.NroFactura))
    '        End With
    '        Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
    '        If _dt.Rows.Count = 1 Then
    '            Dim _comprobante As New Entidades.Comprobante
    '            Me.FormatearComprobante(_dt.Rows(0), _comprobante)
    '            Return _comprobante
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    'Public Function obtenerComprobante(ByVal paramPersona As Entidades.Persona) As List(Of Entidades.Comprobante)
    '    Try
    '        Dim _listaComprobante As New List(Of Entidades.Comprobante)
    '        Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("select * from Comprobante where ID_Persona=@ID_Persona order by Fecha_Emision")
    '        With MiComando.Parameters
    '            .Add(New SqlParameter("@ID_Persona", paramPersona.ID))
    '        End With
    '        Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
    '        For Each _row As DataRow In _dt.Rows
    '            Dim _comprobante As New Entidades.Comprobante
    '            Me.FormatearComprobante(_row, _comprobante)
    '            _listaComprobante.Add(_comprobante)
    '        Next
    '        Return _listaComprobante
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    'Public Function obtenerComprobantesinPago(ByVal paramPersona As Entidades.Persona) As List(Of Entidades.Comprobante)
    '    Try
    '        Dim _listaComprobante As New List(Of Entidades.Comprobante)
    '        Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("select * from Comprobante where ID_Persona=@ID_Persona and Estado=@Estado order by Fecha_Emision")
    '        With MiComando.Parameters
    '            .Add(New SqlParameter("@ID_Persona", paramPersona.ID))
    '            .Add(New SqlParameter("@Estado", 1))
    '        End With
    '        Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
    '        For Each _row As DataRow In _dt.Rows
    '            Dim _comprobante As New Entidades.Comprobante
    '            Me.FormatearComprobante(_row, _comprobante)
    '            _listaComprobante.Add(_comprobante)
    '        Next
    '        Return _listaComprobante
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    'Public Function obtenerComprobante() As List(Of Entidades.Comprobante)
    '    Try
    '        Dim _listaComprobante As New List(Of Entidades.Comprobante)
    '        Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("select * from Comprobante")
    '        Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
    '        For Each _row As DataRow In _dt.Rows
    '            Dim _comprobante As New Entidades.Comprobante
    '            Me.FormatearComprobante(_row, _comprobante)
    '            _listaComprobante.Add(_comprobante)
    '        Next
    '        Return _listaComprobante
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    'Public Function obtenerDetalleComprobante(ByVal paramComprobante As Entidades.Comprobante) As List(Of Entidades.Comprobante_Detalle)
    '    Try
    '        Dim _listaComprobanteDetalle As New List(Of Entidades.Comprobante_Detalle)
    '        Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("select * from Comprobante_Detalle where ID_Comprobante=@ID_Comprobante")
    '        With MiComando.Parameters
    '            .Add(New SqlParameter("@ID_Comprobante", paramComprobante.ID))
    '        End With
    '        Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
    '        For Each _row As DataRow In _dt.Rows
    '            Dim _comprobanteDetalle As New Entidades.Comprobante_Detalle
    '            Me.FormatearDetalleComprobante(_row, _comprobanteDetalle)
    '            _listaComprobanteDetalle.Add(_comprobanteDetalle)
    '        Next
    '        Return _listaComprobanteDetalle
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    'Private Sub FormatearComprobante(ByVal _datarow As DataRow, ByVal paramComprobante As Entidades.Comprobante)
    '    Try
    '        paramComprobante.ID = _datarow.Item("ID_Comprobante")
    '        paramComprobante.NroFactura = _datarow.Item("Nro_Factura")
    '        paramComprobante.Sucursal = _datarow.Item("Sucursal")
    '        paramComprobante.TipoFactura = _datarow.Item("Tipo")
    '        paramComprobante.Persona = (New PersonaMPP).obtenerPersona(New Entidades.Persona With {.ID = _datarow.Item("ID_Persona")})
    '        paramComprobante.FechaEmision = _datarow.Item("Fecha_Emision")
    '        paramComprobante.FechaVencimiento = _datarow.Item("Fecha_Vencimiento")
    '        paramComprobante.IVA = _datarow.Item("IVA")
    '        paramComprobante.Subtotal = _datarow.Item("Subtotal")
    '        paramComprobante.Estado = _datarow.Item("Estado")
    '        paramComprobante.Renglon = Me.obtenerDetalleComprobante(paramComprobante)
    '        paramComprobante.Notas = (New NotaMPP).obtenerNota(New Entidades.Comprobante With {.ID = _datarow.Item("ID_Comprobante")})
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub FormatearDetalleComprobante(ByVal _datarow As DataRow, ByVal paramDetalleComprobante As Entidades.Comprobante_Detalle)
    '    Try
    '        paramDetalleComprobante.ID = _datarow.Item("ID_Comprobante_Detalle")
    '        paramDetalleComprobante.Carrera = (New CarreraMPP).obtenerCarrera(New Entidades.Carrera With {.ID = _datarow.Item("Cod_Carrera")})
    '        paramDetalleComprobante.Cantidad = _datarow.Item("Cantidad")
    '        paramDetalleComprobante.Subtotal = _datarow.Item("Subtotal")
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub


End Class
