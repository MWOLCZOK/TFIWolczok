Imports Entidades

Public Class ResultadoBLL


    Public Function listarFacturasxSemana(ByVal paramMEs As Integer)
        Dim facturaBLL As New GestorFacturaBLL
        Dim listFact As List(Of FacturaEntidad) = facturaBLL.TraerFacturasGestionxMes(paramMEs)
        Dim lstResult As New List(Of ResultadoSemanalEntidad)

        Dim lstResultado2 As New List(Of Integer)

        Dim totalSemanal1 As Double = 0
        Dim totalSemanal2 As Double = 0
        Dim totalSemanal3 As Double = 0
        Dim totalSemanal4 As Double = 0

        For Each f As FacturaEntidad In listFact
            If f.Fecha.Day <= 7 Then
                totalSemanal1 = totalSemanal1 + f.MontoTotal
                Dim oResultado As New ResultadoSemanalEntidad
                oResultado.Semana = "Semana 1"
                oResultado.Monto = f.MontoTotal
                lstResult.Add(oResultado)
            ElseIf f.Fecha.Day <= 14 Then
                totalSemanal2 = totalSemanal2 + f.MontoTotal
                Dim oResultado As New ResultadoSemanalEntidad
                oResultado.Semana = "Semana 2"
                oResultado.Monto = f.MontoTotal
                lstResult.Add(oResultado)
            ElseIf f.Fecha.Day <= 21 Then
                totalSemanal3 = totalSemanal3 + f.MontoTotal
                'Dim oResultado As New ResultadoSemanalEntidad
                'oResultado.Semana = "Semana 3"
                'oResultado.Monto = totalSemanal3
                'lstResult.Add(oResultado)
            Else
                totalSemanal4 = totalSemanal4 + f.MontoTotal
                Dim oResultado As New ResultadoSemanalEntidad
                oResultado.Semana = "Semana 4"
                oResultado.Monto = f.MontoTotal
                lstResult.Add(oResultado)
            End If
        Next
        If totalSemanal1 > 0 Then
            Dim oResultado As New ResultadoSemanalEntidad
            oResultado.Semana = "Semana 1"
            oResultado.Monto = totalSemanal1
            lstResult.Add(oResultado)
        ElseIf totalSemanal2 > 0 Then
            Dim oResultado As New ResultadoSemanalEntidad
            oResultado.Semana = "Semana 2"
            oResultado.Monto = totalSemanal2
            lstResult.Add(oResultado)
        ElseIf totalSemanal3 > 0 Then
            Dim oResultado As New ResultadoSemanalEntidad
            oResultado.Semana = "Semana 3"
            oResultado.Monto = totalSemanal3
            lstResult.Add(oResultado)
        Else
            Dim oResultado As New ResultadoSemanalEntidad
            oResultado.Semana = "Semana 4"
            oResultado.Monto = totalSemanal4
            lstResult.Add(oResultado)
        End If

        Return lstResult
    End Function
End Class
