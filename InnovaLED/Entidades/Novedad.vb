Public Class Novedad

    Public Enum etipoNovedad
        Noticias = 1
        Ofertas = 2
        Tecnologia = 3
    End Enum

    Private _id_novedad As Integer
    Public Property ID_Novedad() As Integer
        Get
            Return _id_novedad
        End Get
        Set(ByVal value As Integer)
            _id_novedad = value
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

    Private _tipo_novedad As etipoNovedad
    Public Property Tipo_Novedad() As etipoNovedad
        Get
            Return _tipo_novedad
        End Get
        Set(ByVal value As etipoNovedad)
            _tipo_novedad = value
        End Set
    End Property

    Private _fecha_Alta As DateTime
    Public Property Fecha_Alta() As DateTime
        Get
            Return _fecha_Alta
        End Get
        Set(ByVal value As DateTime)
            _fecha_Alta = value
        End Set
    End Property

    Private _fecha_fin_vigencia As Date
    Public Property Fecha_Fin_Vigencia() As Date
        Get
            Return _fecha_fin_vigencia
        End Get
        Set(ByVal value As Date)
            _fecha_fin_vigencia = value
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

    Private _lista_suscriptores As List(Of Entidades.Cliente)
    Public Property lista_subscriptores() As List(Of Entidades.Cliente)
        Get
            Return _lista_suscriptores
        End Get
        Set(ByVal value As List(Of Entidades.Cliente))
            _lista_suscriptores = value
        End Set
    End Property

End Class
