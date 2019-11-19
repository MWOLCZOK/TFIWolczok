Public Class ResultadoEntidad

    Private _fecha As Integer
    Public Property Fecha() As Integer
        Get
            Return _fecha
        End Get
        Set(ByVal value As Integer)
            _fecha = value
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
        Return Monto & " " & Fecha
    End Function



End Class
