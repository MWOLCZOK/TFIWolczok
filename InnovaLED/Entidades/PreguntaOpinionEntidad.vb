Public Class PreguntaOpinionEntidad


    Private _IDPregunta As Integer
    Public Property ID() As Integer
        Get
            Return _IDPregunta
        End Get
        Set(ByVal value As Integer)
            _IDPregunta = value
        End Set
    End Property

    Private _Enunciado As String
    Public Property Enunciado() As String
        Get
            Return _Enunciado
        End Get
        Set(ByVal value As String)
            _Enunciado = value
        End Set
    End Property

    Private _FechaAlta As DateTime
    Public Property FechaAlta() As DateTime
        Get
            Return _FechaAlta
        End Get
        Set(ByVal value As DateTime)
            _FechaAlta = value
        End Set
    End Property


    Private _tipopregunta As TipoPregunta
    Public Property TipoPregunta() As TipoPregunta
        Get
            Return _tipopregunta
        End Get
        Set(ByVal value As TipoPregunta)
            _tipopregunta = value
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


    Private _posiblesRespuestas As List(Of RespuestaEncuestaEntidad)
    Public Property PosiblesRespuestas() As List(Of RespuestaEncuestaEntidad)
        Get
            Return _posiblesRespuestas
        End Get
        Set(ByVal value As List(Of RespuestaEncuestaEntidad))
            _posiblesRespuestas = value
        End Set
    End Property



    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function



End Class

Public Enum TipoPregunta
    Opinion = 1
    Encuesta = 2
End Enum







