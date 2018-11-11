Public Class PreguntaOpinionEntidad

    Enum TipoPreguntaOpinion
            Opinion = 1
            Encuesta = 2
        End Enum


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

        Private _TipoPregunta As TipoPreguntaOpinion
        Public Property TipoPregunta() As TipoPreguntaOpinion
            Get
                Return _TipoPregunta
            End Get
            Set(ByVal value As TipoPreguntaOpinion)
                _TipoPregunta = value
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
