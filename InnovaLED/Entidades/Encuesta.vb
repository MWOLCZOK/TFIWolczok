Public Class Encuesta
    Enum TipoEncuesta
        Opinion = 1
        Encuesta = 2
    End Enum

    Private _lista_preguntas As New List(Of PreguntaOpinionEntidad)
    Public Property listaPreguntas() As List(Of PreguntaOpinionEntidad)
        Get
            Return _lista_preguntas
        End Get
        Set(ByVal value As List(Of PreguntaOpinionEntidad))
            _lista_preguntas = value
        End Set
    End Property

    Private _id_encuesta As Integer
    Public Property ID_Encuesta() As Integer
        Get
            Return _id_encuesta
        End Get
        Set(ByVal value As Integer)
            _id_encuesta = value
        End Set
    End Property

    Private _titulo As String
    Public Property Titulo() As String
        Get
            Return _titulo
        End Get
        Set(ByVal value As String)
            _titulo = value
        End Set
    End Property

    Private _fecha_alta As DateTime
    Public Property Fecha_Alta() As DateTime
        Get
            Return _fecha_alta
        End Get
        Set(ByVal value As DateTime)
            _fecha_alta = value
        End Set
    End Property

    Private _Tipo_Encuesta As TipoEncuesta
    Public Property Tipo_Encuesta() As TipoEncuesta
        Get
            Return _Tipo_Encuesta
        End Get
        Set(ByVal value As TipoEncuesta)
            _Tipo_Encuesta = value
        End Set
    End Property

    Private _fecha_Fin_Vigencia As Date
    Public Property Fecha_Fin_Vigencia() As Date
        Get
            Return _fecha_Fin_Vigencia
        End Get
        Set(ByVal value As Date)
            _fecha_Fin_Vigencia = value
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
