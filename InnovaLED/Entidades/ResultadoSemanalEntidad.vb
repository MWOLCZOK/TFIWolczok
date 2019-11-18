Public Class ResultadoSemanalEntidad

    Private _semana As String
    Public Property Semana() As String
        Get
            Return _semana
        End Get
        Set(ByVal value As String)
            _semana = value
        End Set
    End Property

    Private _monton As Integer
    Public Property Monto() As Integer
        Get
            Return _monton
        End Get
        Set(ByVal value As Integer)
            _monton = value
        End Set
    End Property

    Public Overrides Function Equals(obj As Object) As Boolean
        Return Monto & " " & Semana
    End Function




End Class
