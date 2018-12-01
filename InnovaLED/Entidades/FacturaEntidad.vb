
Public Class FacturaEntidad

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _cliente As UsuarioEntidad
    Public Property Cliente() As UsuarioEntidad
        Get
            Return _cliente
        End Get
        Set(ByVal value As UsuarioEntidad)
            _cliente = value
        End Set
    End Property

    Private _detalleFactura As New List(Of CompraEntidad)
    Public Property DetalleFactura() As List(Of CompraEntidad)
        Get
            Return _detalleFactura
        End Get
        Set(ByVal value As List(Of CompraEntidad))
            _detalleFactura = value
        End Set
    End Property

    'Private _montototal As Single
    'Public ReadOnly Property MontoTotal() As Single
    '    Get
    '        Dim sum As Single
    '        For Each _subt In Me.DetalleFactura
    '            sum += _subt.Subtotal
    '        Next
    '        Return sum
    '    End Get

    'End Property

    Private Function Total() As Double
        Dim retorno As Double
        For Each deta As CompraEntidad In Me.DetalleFactura
            retorno = retorno + deta.Producto.Precio
        Next
        Return retorno
    End Function


    Private _monto_total As Double
    Public Property MontoTotal() As Double
        Get
            Return _monto_total
        End Get
        Set(ByVal value As Double)
            _monto_total = value
        End Set
    End Property




    Private _fecha As DateTime
    Public Property Fecha() As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property

    Private _estadocompra As EstadoCompraEntidad
    Public Property EstadoCompra() As EstadoCompraEntidad
        Get
            Return _estadocompra
        End Get
        Set(ByVal value As EstadoCompraEntidad)
            _estadocompra = value
        End Set
    End Property

    Private _estadoenvio As EstadoEnvio
    Public Property EstadoEnvio() As EstadoEnvio
        Get
            Return _estadoenvio
        End Get
        Set(ByVal value As EstadoEnvio)
            _estadoenvio = value
        End Set
    End Property

    Private _notas As New List(Of DocumentoFinancieroEntidad)
    Public Property Notas() As List(Of DocumentoFinancieroEntidad)
        Get
            Return _notas
        End Get
        Set(ByVal value As List(Of DocumentoFinancieroEntidad))
            _notas = value
        End Set
    End Property


    Sub New(ByRef clie As UsuarioEntidad, ByRef Detalle As List(Of CompraEntidad), ByRef notas As List(Of DocumentoFinancieroEntidad), ByRef fec As DateTime, ByRef EstadoCompra As EstadoCompraEntidad)
        Me.Cliente = clie
        Me.DetalleFactura = Detalle
        Me.Notas = notas
        Me.MontoTotal = Total()
        Me.Fecha = Now
        Me.EstadoCompra = EstadoCompra
        Me.EstadoEnvio = 0
    End Sub

    Sub New()

    End Sub

    Private _pdf As Byte()
    Public Property PDF() As Byte()
        Get
            Return _pdf
        End Get
        Set(ByVal value As Byte())
            _pdf = value
        End Set
    End Property





End Class
