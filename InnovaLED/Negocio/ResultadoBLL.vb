Imports Entidades

Public Class ResultadoBLL


    Public Function ListarTodasLasFacturas()
        Dim facturaBLL As New GestorFacturaBLL
        Dim listFact As List(Of FacturaEntidad) = facturaBLL.TraerFacturasGestion()
        Dim lstResult As New List(Of ResultadoEntidad)
        Dim totalAnual As Integer = 0
        For Each f As FacturaEntidad In listFact
            totalAnual = totalAnual + f.MontoTotal
        Next

        If totalAnual > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = 2019
            oResultado.Monto = totalAnual
            lstResult.Add(oResultado)
        End If
        Return lstResult

    End Function


    Public Function listarFacturasTodosLosMeses(ByVal paramMEs As Integer)
        Dim facturaBLL As New GestorFacturaBLL
        Dim listFact As List(Of FacturaEntidad) = facturaBLL.TraerFacturasGestionxMes(paramMEs)
        Dim lstResult As New List(Of ResultadoEntidad)

        Dim totalMensual1 As Double = 0
        Dim totalMensual2 As Double = 0
        Dim totalMensual3 As Double = 0
        Dim TotalMensual4 As Double = 0
        Dim TotalMensual5 As Double = 0
        Dim TotalMensual6 As Double = 0
        Dim TotalMensual7 As Double = 0
        Dim TotalMensual8 As Double = 0
        Dim TotalMensual9 As Double = 0
        Dim TotalMensual10 As Double = 0
        Dim TotalMensual11 As Double = 0
        Dim TotalMensual12 As Double = 0

        For Each f As FacturaEntidad In listFact
            If f.Fecha.Month = 1 Then
                totalMensual1 = totalMensual1 + f.MontoTotal

            ElseIf f.Fecha.Month = 2 Then
                totalMensual2 = totalMensual2 + f.MontoTotal

            ElseIf f.Fecha.Month = 3 Then
                totalMensual3 = totalMensual3 + f.MontoTotal

            ElseIf f.Fecha.Month = 4 Then
                TotalMensual4 = TotalMensual4 + f.MontoTotal
            ElseIf f.fecha.Month = 5 Then
                TotalMensual5 = TotalMensual5 + f.MontoTotal

            ElseIf f.fecha.Month = 6 Then
                TotalMensual6 = TotalMensual6 + f.MontoTotal

            ElseIf f.fecha.Month = 7 Then
                TotalMensual7 = TotalMensual7 + f.MontoTotal

            ElseIf f.fecha.Month = 8 Then
                TotalMensual8 = TotalMensual8 + f.MontoTotal

            ElseIf f.fecha.Month = 9 Then
                TotalMensual9 = TotalMensual9 + f.MontoTotal

            ElseIf f.fecha.Month = 10 Then
                TotalMensual10 = TotalMensual10 + f.MontoTotal

            ElseIf f.fecha.Month = 11 Then
                TotalMensual11 = TotalMensual11 + f.MontoTotal

            ElseIf f.fecha.Month = 12 Then
                TotalMensual12 = TotalMensual12 + f.MontoTotal

            End If
        Next

        If totalMensual1 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "Enero"
            oResultado.Monto = totalMensual1
            lstResult.Add(oResultado)
        End If

        If totalMensual2 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "Febrero"
            oResultado.Monto = totalMensual2
            lstResult.Add(oResultado)
        End If

        If totalMensual3 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "Marzo"
            oResultado.Monto = totalMensual3
            lstResult.Add(oResultado)
        End If

        If TotalMensual4 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "Abril"
            oResultado.Monto = TotalMensual4
            lstResult.Add(oResultado)
        End If

        If TotalMensual5 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "Mayo"
            oResultado.Monto = TotalMensual5
            lstResult.Add(oResultado)
        End If

        If TotalMensual6 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "Junio"
            oResultado.Monto = TotalMensual6
            lstResult.Add(oResultado)
        End If

        If TotalMensual7 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "Julio"
            oResultado.Monto = TotalMensual7
            lstResult.Add(oResultado)
        End If

        If TotalMensual8 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "Agosto"
            oResultado.Monto = TotalMensual8
            lstResult.Add(oResultado)
        End If

        If TotalMensual9 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "Septiembre"
            oResultado.Monto = TotalMensual9
            lstResult.Add(oResultado)
        End If

        If TotalMensual10 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "Octubre"
            oResultado.Monto = TotalMensual10
            lstResult.Add(oResultado)
        End If

        If TotalMensual11 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = 11
            oResultado.Monto = TotalMensual11
            lstResult.Add(oResultado)
        End If

        If TotalMensual12 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "12"
            oResultado.Monto = TotalMensual12
            lstResult.Add(oResultado)
        End If
        Return lstResult
    End Function

    Public Function listarFacturaxMes(ByVal paramMes As Integer)
        Dim facturaBLL As New GestorFacturaBLL
        Dim listFact As List(Of FacturaEntidad) = facturaBLL.TraerFacturasGestionxMes(paramMes)
        Dim lstResult As New List(Of ResultadoEntidad)
        Dim totalMensual As Integer = 0

        For Each f As FacturaEntidad In listFact
            If f.Fecha.Month = paramMes Then
                totalMensual = totalMensual + f.MontoTotal
            End If
        Next
        If totalMensual > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = paramMes.ToString
            oResultado.Monto = totalMensual
            lstResult.Add(oResultado)
        End If
        Return lstResult

    End Function




    Public Function listarFacturasxSemana(ByVal paramMEs As Integer)
        Dim facturaBLL As New GestorFacturaBLL
        Dim listFact As List(Of FacturaEntidad) = facturaBLL.TraerFacturasGestionxMes(paramMEs)
        Dim lstResult As New List(Of ResultadoSemanalEntidad)

        Dim totalSemanal1 As Double = 0
        Dim totalSemanal2 As Double = 0
        Dim totalSemanal3 As Double = 0
        Dim totalSemanal4 As Double = 0

        For Each f As FacturaEntidad In listFact
            If f.Fecha.Day <= 7 Then
                totalSemanal1 = totalSemanal1 + f.MontoTotal
                Dim oResultado As New ResultadoSemanalEntidad
                'oResultado.Semana = "Semana 1"
                'oResultado.Monto = f.MontoTotal
                'lstResult.Add(oResultado)
            ElseIf f.Fecha.Day <= 14 Then
                totalSemanal2 = totalSemanal2 + f.MontoTotal
                'Dim oResultado As New ResultadoSemanalEntidad
                'oResultado.Semana = "Semana 2"
                'oResultado.Monto = f.MontoTotal
                'lstResult.Add(oResultado)
            ElseIf f.Fecha.Day <= 21 Then
                totalSemanal3 = totalSemanal3 + f.MontoTotal
                'Dim oResultado As New ResultadoSemanalEntidad
                'oResultado.Semana = "Semana 3"
                'oResultado.Monto = totalSemanal3
                'lstResult.Add(oResultado)
            Else
                totalSemanal4 = totalSemanal4 + f.MontoTotal
                'Dim oResultado As New ResultadoSemanalEntidad
                'oResultado.Semana = "Semana 4"
                'oResultado.Monto = f.MontoTotal
                'lstResult.Add(oResultado)
            End If
        Next
        If totalSemanal1 > 0 Then
            Dim oResultado As New ResultadoSemanalEntidad
            oResultado.Semana = "Semana 1"
            oResultado.Monto = totalSemanal1
            lstResult.Add(oResultado)
        End If

        If totalSemanal2 > 0 Then
            Dim oResultado As New ResultadoSemanalEntidad
            oResultado.Semana = "Semana 2"
            oResultado.Monto = totalSemanal2
            lstResult.Add(oResultado)
        End If

        If totalSemanal3 > 0 Then
            Dim oResultado As New ResultadoSemanalEntidad
            oResultado.Semana = "Semana 3"
            oResultado.Monto = totalSemanal3
            lstResult.Add(oResultado)
        End If

        If totalSemanal4 > 0 Then
            Dim oResultado As New ResultadoSemanalEntidad
            oResultado.Semana = "Semana 4"
            oResultado.Monto = totalSemanal4
            lstResult.Add(oResultado)
        End If

        Return lstResult
    End Function




    Public Function listarFacturasxDia(ByVal paramMes As Integer)
        Dim facturaBLL As New GestorFacturaBLL
        Dim listFact As List(Of FacturaEntidad) = facturaBLL.TraerFacturasGestionxMes(paramMes)
        Dim lstResult As New List(Of ResultadoEntidad)

        Dim totDiario1 As Integer = 0
        Dim totDiario2 As Integer = 0
        Dim totDiario3 As Integer = 0
        Dim totDiario4 As Integer = 0
        Dim totDiario5 As Integer = 0
        Dim totDiario6 As Integer = 0
        Dim totDiario7 As Integer = 0
        Dim totDiario8 As Integer = 0
        Dim totDiario9 As Integer = 0
        Dim totDiario10 As Integer = 0
        Dim totDiario11 As Integer = 0
        Dim totDiario12 As Integer = 0
        Dim totDiario13 As Integer = 0
        Dim totDiario14 As Integer = 0
        Dim totDiario15 As Integer = 0
        Dim totDiario16 As Integer = 0
        Dim totDiario17 As Integer = 0
        Dim totDiario18 As Integer = 0
        Dim totDiario19 As Integer = 0
        Dim totDiario20 As Integer = 0
        Dim totDiario21 As Integer = 0
        Dim totDiario22 As Integer = 0
        Dim totDiario23 As Integer = 0
        Dim totDiario24 As Integer = 0
        Dim totDiario25 As Integer = 0
        Dim totDiario26 As Integer = 0
        Dim totDiario27 As Integer = 0
        Dim totDiario28 As Integer = 0
        Dim totDiario29 As Integer = 0
        Dim totDiario30 As Integer = 0
        Dim totDiario31 As Integer = 0

        For Each f As FacturaEntidad In listFact

            If f.Fecha.Day = 1 Then
                totDiario1 = totDiario1 + f.MontoTotal
            ElseIf f.Fecha.Day = 2 Then
                totDiario2 = totDiario2 + f.MontoTotal
            ElseIf f.Fecha.Day = 3 Then
                totDiario3 = totDiario3 + f.MontoTotal
            ElseIf f.Fecha.Day = 4 Then
                totDiario4 = totDiario4 + f.MontoTotal
            ElseIf f.Fecha.Day = 5 Then
                totDiario5 = totDiario5 + f.MontoTotal
            ElseIf f.Fecha.Day = 6 Then
                totDiario6 = totDiario6 + f.MontoTotal
            ElseIf f.Fecha.Day = 7 Then
                totDiario7 = totDiario7 + f.MontoTotal
            ElseIf f.Fecha.Day = 8 Then
                totDiario8 = totDiario8 + f.MontoTotal
            ElseIf f.Fecha.Day = 9 Then
                totDiario9 = totDiario9 + f.MontoTotal
            ElseIf f.Fecha.Day = 10 Then
                totDiario10 = totDiario10 + f.MontoTotal
            ElseIf f.Fecha.Day = 11 Then
                totDiario11 = totDiario11 + f.MontoTotal
            ElseIf f.Fecha.Day = 12 Then
                totDiario12 = totDiario12 + f.MontoTotal
            ElseIf f.Fecha.Day = 13 Then
                totDiario13 = totDiario13 + f.MontoTotal
            ElseIf f.Fecha.Day = 14 Then
                totDiario14 = totDiario14 + f.MontoTotal
            ElseIf f.Fecha.Day = 15 Then
                totDiario15 = totDiario15 + f.MontoTotal
            ElseIf f.Fecha.Day = 16 Then
                totDiario16 = totDiario16 + f.MontoTotal
            ElseIf f.Fecha.Day = 17 Then
                totDiario17 = totDiario17 + f.MontoTotal
            ElseIf f.Fecha.Day = 18 Then
                totDiario18 = totDiario18 + f.MontoTotal
            ElseIf f.Fecha.Day = 19 Then
                totDiario19 = totDiario19 + f.MontoTotal
            ElseIf f.Fecha.Day = 20 Then
                totDiario20 = totDiario20 + f.MontoTotal
            ElseIf f.Fecha.Day = 21 Then
                totDiario21 = totDiario21 + f.MontoTotal
            ElseIf f.Fecha.Day = 22 Then
                totDiario22 = totDiario22 + f.MontoTotal
            ElseIf f.Fecha.Day = 23 Then
                totDiario23 = totDiario23 + f.MontoTotal
            ElseIf f.Fecha.Day = 24 Then
                totDiario24 = totDiario24 + f.MontoTotal
            ElseIf f.Fecha.Day = 25 Then
                totDiario25 = totDiario25 + f.MontoTotal
            ElseIf f.Fecha.Day = 26 Then
                totDiario26 = totDiario26 + f.MontoTotal
            ElseIf f.Fecha.Day = 27 Then
                totDiario27 = totDiario27 + f.MontoTotal
            ElseIf f.Fecha.Day = 28 Then
                totDiario28 = totDiario28 + f.MontoTotal
            ElseIf f.Fecha.Day = 29 Then
                totDiario29 = totDiario29 + f.MontoTotal
            ElseIf f.Fecha.Day = 30 Then
                totDiario30 = totDiario30 + f.MontoTotal
            Else
                totDiario31 = totDiario31 + f.MontoTotal
            End If
        Next

        If totDiario1 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "1"
            oResultado.Monto = totDiario1
            lstResult.Add(oResultado)
        End If


        If totDiario2 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "2"
            oResultado.Monto = totDiario2
            lstResult.Add(oResultado)
        End If


        If totDiario3 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "3"
            oResultado.Monto = totDiario3
            lstResult.Add(oResultado)
        End If


        If totDiario4 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "4"
            oResultado.Monto = totDiario4
            lstResult.Add(oResultado)
        End If


        If totDiario5 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "5"
            oResultado.Monto = totDiario5
            lstResult.Add(oResultado)
        End If


        If totDiario6 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "6"
            oResultado.Monto = totDiario6
            lstResult.Add(oResultado)
        End If


        If totDiario7 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "7"
            oResultado.Monto = totDiario7
            lstResult.Add(oResultado)
        End If

        If totDiario8 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "8"
            oResultado.Monto = totDiario8
            lstResult.Add(oResultado)
        End If


        If totDiario9 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "9"
            oResultado.Monto = totDiario9
            lstResult.Add(oResultado)
        End If


        If totDiario10 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "10"
            oResultado.Monto = totDiario10
            lstResult.Add(oResultado)
        End If

        If totDiario11 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "11"
            oResultado.Monto = totDiario11
            lstResult.Add(oResultado)
        End If


        If totDiario12 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "12"
            oResultado.Monto = totDiario12
            lstResult.Add(oResultado)
        End If


        If totDiario13 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "13"
            oResultado.Monto = totDiario13
            lstResult.Add(oResultado)
        End If

        If totDiario14 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "14"
            oResultado.Monto = totDiario14
            lstResult.Add(oResultado)
        End If


        If totDiario15 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "15"
            oResultado.Monto = totDiario15
            lstResult.Add(oResultado)
        End If

        If totDiario16 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "16"
            oResultado.Monto = totDiario16
            lstResult.Add(oResultado)
        End If


        If totDiario17 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "17"
            oResultado.Monto = totDiario17
            lstResult.Add(oResultado)
        End If

        If totDiario18 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "18"
            oResultado.Monto = totDiario18
            lstResult.Add(oResultado)
        End If


        If totDiario19 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "19"
            oResultado.Monto = totDiario19
            lstResult.Add(oResultado)
        End If


        If totDiario20 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "20"
            oResultado.Monto = totDiario20
            lstResult.Add(oResultado)
        End If


        If totDiario21 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "21"
            oResultado.Monto = totDiario21
            lstResult.Add(oResultado)
        End If


        If totDiario22 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "22"
            oResultado.Monto = totDiario22
            lstResult.Add(oResultado)
        End If


        If totDiario23 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "23"
            oResultado.Monto = totDiario23
            lstResult.Add(oResultado)
        End If


        If totDiario24 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "24"
            oResultado.Monto = totDiario24
            lstResult.Add(oResultado)
        End If


        If totDiario25 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "25"
            oResultado.Monto = totDiario25
            lstResult.Add(oResultado)
        End If


        If totDiario26 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "26"
            oResultado.Monto = totDiario26
            lstResult.Add(oResultado)
        End If


        If totDiario27 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "27"
            oResultado.Monto = totDiario27
            lstResult.Add(oResultado)
        End If


        If totDiario28 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "28"
            oResultado.Monto = totDiario28
            lstResult.Add(oResultado)
        End If


        If totDiario29 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "29"
            oResultado.Monto = totDiario29
            lstResult.Add(oResultado)
        End If


        If totDiario30 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "30"
            oResultado.Monto = totDiario30
            lstResult.Add(oResultado)
        End If


        If totDiario31 > 0 Then
            Dim oResultado As New ResultadoEntidad
            oResultado.Fecha = "31"
            oResultado.Monto = totDiario31
            lstResult.Add(oResultado)
        End If

        Return lstResult
    End Function





End Class
