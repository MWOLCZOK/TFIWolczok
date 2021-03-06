﻿Public Class CompraEntidad

    'este es mi detalle factura

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property


    Private _producto As ProductoEntidad
    Public Property Producto() As ProductoEntidad
        Get
            Return _producto
        End Get
        Set(ByVal value As ProductoEntidad)
            _producto = value
        End Set
    End Property

    Private _cantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property

    Private _Subtotal As Double
    Public ReadOnly Property Subtotal() As Double
        Get
            Return Me.Cantidad * Me.Producto.Precio
        End Get

    End Property


End Class
