Public Class RespuestaEntidad

    Enum TipoRespuestasCalidad
        Excelente = 0
        Bueno = 1
        Regular = 2
        Malo = 3
        Pesimo = 4
    End Enum

    Enum TipoRespuestasFichaOpinion
        Si = 0
        No = 1
        Quizas = 2
    End Enum


    Private _respuestaCal As TipoRespuestasCalidad
    Public Property Tipo_Respuesta_Calidad() As TipoRespuestasCalidad
        Get
            Return _respuestaCal
        End Get
        Set(ByVal value As TipoRespuestasCalidad)
            _respuestaCal = value
        End Set
    End Property


    Private _respuestaFichaOpinion As TipoRespuestasFichaOpinion
    Public Property Tipo_Respuesta_FichaOpinion() As TipoRespuestasFichaOpinion
        Get
            Return _respuestaFichaOpinion
        End Get
        Set(ByVal value As TipoRespuestasFichaOpinion)
            _respuestaFichaOpinion = value
        End Set
    End Property


    Private _id As Integer
    Public Property ID_Respuesta() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _pregunta As PreguntaOpinionEntidad
    Public Property Pregunta() As PreguntaOpinionEntidad
        Get
            Return _pregunta
        End Get
        Set(ByVal value As PreguntaOpinionEntidad)
            _pregunta = value
        End Set
    End Property

    Private _id_usuario As UsuarioEntidad
    Public Property Usuario() As UsuarioEntidad
        Get
            Return _id_usuario
        End Get
        Set(ByVal value As UsuarioEntidad)
            _id_usuario = value
        End Set
    End Property

    Private _Valor_Respuesta As Integer
    Public Property Valor_Respuesta() As Integer
        Get
            Return _Valor_Respuesta
        End Get
        Set(ByVal value As Integer)
            _Valor_Respuesta = value
        End Set
    End Property




End Class
