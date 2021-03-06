﻿Public Class DocumentoFinancieroEntidad

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property


    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Private _monto As Single
    Public Property Monto() As Single
        Get
            Return _monto
        End Get
        Set(ByVal value As Single)
            _monto = value
        End Set
    End Property

    Private _tipodocumento As TipoDocumento
    Public Property Tipo_Documento() As TipoDocumento
        Get
            Return _tipodocumento
        End Get
        Set(ByVal value As TipoDocumento)
            _tipodocumento = value
        End Set
    End Property


    Private _cliente As UsuarioEntidad
    Public Property Usuario() As UsuarioEntidad
        Get
            Return _cliente
        End Get
        Set(ByVal value As UsuarioEntidad)
            _cliente = value
        End Set
    End Property

    Private _fecha As DateTime
    Public Property Fecha_Emision() As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property

    Private _bl As Boolean
    Public Property BL() As Boolean
        Get
            Return _bl
        End Get
        Set(ByVal value As Boolean)
            _bl = value
        End Set
    End Property

    Private _factura As FacturaEntidad
    Public Property Factura() As FacturaEntidad
        Get
            Return _factura
        End Get
        Set(ByVal value As FacturaEntidad)
            _factura = value
        End Set
    End Property


    Sub New(ByRef descr As String, ByRef monto As Single, ByRef tipo As TipoDocumento, ByRef clie As UsuarioEntidad, ByRef fec As DateTime, ByVal ID_Fact As FacturaEntidad)
        Me.Descripcion = descr
        Me.Monto = monto
        Me.Tipo_Documento = tipo
        Me.Usuario = clie
        Me.Fecha_Emision = Now
        Me.Factura = ID_Fact

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
