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

    'Private _TipoPreguntaOpinion As TipoPreguntaOpinion
    'Public Property TipoPreguntaOpinion() As TipoPreguntaOpinion
    '    Get
    '        Return _TipoPreguntaOpinion
    '    End Get
    '    Set(ByVal value As TipoPreguntaOpinion)
    '        _TipoPreguntaOpinion = value
    '    End Set
    'End Property

    Private _TipoPreguntaEncuesta As TipoRespuestasCalidad
    Public Property TipoPreguntaEncuesta() As TipoRespuestasCalidad
        Get
            Return _TipoPreguntaEncuesta
        End Get
        Set(ByVal value As TipoRespuestasCalidad)
            _TipoPreguntaEncuesta = value
        End Set
    End Property



    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function


    Enum TipoRespuestasFichaOpinion ' Opinion
        Si = 0
        No = 1
        Quizas = 2
    End Enum

    Enum TipoRespuestasCalidad ' Encuesta
        Excelente = 0
        Bueno = 1
        Regular = 2
        Malo = 3
        Pesimo = 4
    End Enum


End Class

Public Enum TipoPregunta
    Opinion = 1
    Encuesta = 2
End Enum







