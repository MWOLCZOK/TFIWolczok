Public Class BoletinEntidad


    Private _id As String
    Public Property ID() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
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

    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Private _cuerpo As String
    Public Property Cuerpo() As String
        Get
            Return _cuerpo
        End Get
        Set(ByVal value As String)
            _cuerpo = value
        End Set
    End Property


    Private _imagen As String
    Public Property Imagen() As String
        Get
            Return _imagen
        End Get
        Set(ByVal value As String)
            _imagen = value
        End Set
    End Property



    Private _tipoBoletin As TipoBoletin
    Public Property TipoBoletin() As TipoBoletin
        Get
            Return _tipoBoletin
        End Get
        Set(ByVal value As TipoBoletin)
            _tipoBoletin = value
        End Set
    End Property

    Private _fechaAlta As Date
    Public Property FechaAlta() As Date
        Get
            Return _fechaAlta
        End Get
        Set(ByVal value As Date)
            _fechaAlta = value
        End Set
    End Property

    Private _listadosuscriptores As List(Of String)
    Public Property Suscriptores() As List(Of String)
        Get
            Return _listadosuscriptores
        End Get
        Set(ByVal value As List(Of String))
            _listadosuscriptores = value
        End Set
    End Property

    Private _fechaFinVigencia As Date
    Public Property FechaFinVigencia() As Date
        Get
            Return _fechaFinVigencia
        End Get
        Set(ByVal value As Date)
            _fechaFinVigencia = value
        End Set
    End Property

    Private _BL As Boolean
    Public Property BL() As Boolean
        Get
            Return _BL
        End Get
        Set(ByVal value As Boolean)
            _BL = value
        End Set
    End Property

End Class
Public Enum TipoBoletin
    Noticias = 1
    Ofertas = 2
    Eventos = 3
    Novedad = 4
End Enum


