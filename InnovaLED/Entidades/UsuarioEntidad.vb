﻿Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class UsuarioEntidad

    Implements ICloneable


    Private _id_usuario As Integer
    Public Property ID_Usuario() As Integer
        Get
            Return _id_usuario
        End Get
        Set(ByVal value As Integer)
            _id_usuario = value
        End Set
    End Property
    Private _nombreusu As String
    Public Property NombreUsu() As String
        Get
            Return _nombreusu
        End Get
        Set(ByVal value As String)
            _nombreusu = value
        End Set
    End Property
    Private _apellido As String
    Public Property Apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property
    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _dni As Integer
    Public Property DNI() As Integer
        Get
            Return _dni
        End Get
        Set(ByVal value As Integer)
            _dni = value
        End Set
    End Property

    Private _fecha_alta As DateTime
    Public Property FechaAlta() As DateTime
        Get
            Return _fecha_alta
        End Get
        Set(ByVal value As DateTime)
            _fecha_alta = value
        End Set
    End Property

    Private _salt As String
    Public Property Salt() As String
        Get
            Return _salt
        End Get
        Set(ByVal value As String)
            _salt = value
        End Set

    End Property

    Private _password As String
    Public Property Password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set

    End Property
    Private _intento As Integer
    Public Property Intento() As Integer
        Get
            Return _intento
        End Get
        Set(ByVal value As Integer)
            _intento = value
        End Set
    End Property

    Private _bloqueo As Boolean
    Public Property Bloqueo() As Boolean
        Get
            Return _bloqueo
        End Get
        Set(ByVal value As Boolean)
            _bloqueo = value
        End Set
    End Property

    Private _rol As New List(Of RolEntidad)
    Public Property Rol() As List(Of RolEntidad)
        Get
            Return _rol
        End Get
        Set(ByVal value As List(Of RolEntidad))
            _rol = value
        End Set
    End Property








    Private _idioma As IdiomaEntidad
    Public Property Idioma() As IdiomaEntidad
        Get
            Return _idioma
        End Get
        Set(ByVal value As IdiomaEntidad)
            _idioma = value
        End Set
    End Property

    Private _empleado As Boolean
    Public Property Empleado() As Boolean
        Get
            Return _empleado
        End Get
        Set(ByVal value As Boolean)
            _empleado = value
        End Set
    End Property

    Private _mail As String
    Public Property Mail() As String
        Get
            Return _mail
        End Get
        Set(ByVal value As String)
            _mail = value
        End Set
    End Property



    Public Overrides Function ToString() As String
        Return Me.Nombre
    End Function

    Public Function Clone() As Object Implements ICloneable.Clone
        Dim m As New MemoryStream()
        Dim f As New BinaryFormatter()
        f.Serialize(m, Me)
        m.Seek(0, SeekOrigin.Begin)
        Return f.Deserialize(m)
    End Function


    Public Function ValidarURL(paramURL As String) As Boolean
        Return _rol.Any(Function(Rol) Rol.ValidarURL(paramURL))
    End Function




End Class
