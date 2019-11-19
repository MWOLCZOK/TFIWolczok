Imports Negocio
Imports Entidades
Imports System.Data
Imports System.IO
Imports System.Web.UI.DataVisualization.Charting



Public Class Reportes_Ventas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LLenarChartAnual()
    End Sub

    Public Function LLenarChartAnual()
        Try
            Dim oResultadoBLL As New ResultadoBLL
            Dim lstResult As New List(Of ResultadoEntidad)
            lstResult = oResultadoBLL.ListarTodasLasFacturas()
            If lstResult.Count > 0 Then
                chartGananciasAnuales.Series(0).IsValueShownAsLabel = True
                chartGananciasAnuales.DataSource = lstResult
                chartGananciasAnuales.Series("Series1").XValueMember = "Fecha"
                chartGananciasAnuales.Series("Series1").YValueMembers = "Monto"
                chartGananciasAnuales.ChartAreas(0).AxisY.LabelStyle.Format = "{0:c}"
                chartGananciasAnuales.Series(0).YValueType = ChartValueType.Single
                chartGananciasAnuales.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
                chartGananciasAnuales.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
                'Dim leg As New Legend
                'chartGananciaMensual.Legends.Add(leg)
                chartGananciaMensual.DataBind()
            Else
                Lbl_anual.Visible = True
                Lbl_anual.Text = "No se han encontrado registros para el periodo especificado."
            End If

        Catch ex As Exception

        End Try
    End Function

    Protected Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscarMensual.Click ' Reporte Mensual
        Try
            If ddl_Ano_Mes.SelectedValue = 0 Then
                Dim oResultadoBLL As New ResultadoBLL
                Dim lstResult As New List(Of ResultadoEntidad)
                If ddl_Mes.SelectedValue = 0 Then
                    lstResult = oResultadoBLL.listarFacturasTodosLosMeses(CInt(Me.ddl_Mes.SelectedValue))
                Else
                    lstResult = oResultadoBLL.listarFacturaxMes(CInt(Me.ddl_Mes.SelectedValue))
                End If
                If lstResult.Count > 0 Then
                    chartGananciaMensual.Series(0).IsValueShownAsLabel = True
                    chartGananciaMensual.DataSource = lstResult
                    chartGananciaMensual.Series("Series1").XValueMember = "Fecha"
                    chartGananciaMensual.Series("Series1").YValueMembers = "Monto"
                    chartGananciaMensual.ChartAreas(0).AxisY.LabelStyle.Format = "{0:c}"
                    chartGananciaMensual.Series(0).YValueType = ChartValueType.Single
                    chartGananciaMensual.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
                    chartGananciaMensual.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
                    'Dim leg As New Legend
                    'chartGananciaMensual.Legends.Add(leg)
                    chartGananciaMensual.DataBind()
                    lblmensual.Visible = False
                    Lbl_Semanal.Visible = False
                    Lbl_Diario.Visible = False
                Else
                    lblmensual.Visible = True
                    Lbl_Semanal.Visible = False
                    Lbl_Diario.Visible = False
                    lblmensual.Text = "No se han encontrado registros para el periodo especificado."
                End If
            Else
                lblmensual.Visible = True
                Lbl_Semanal.Visible = False
                Lbl_Diario.Visible = False
                lblmensual.Text = "No se han encontrado registros para el periodo especificado."
            End If
        Catch ex As Exception
        End Try
    End Sub


    Protected Sub Btn_Semanal_Click(sender As Object, e As EventArgs) Handles Btn_Semanal.Click ' Reporte Semanal
        Try
            If ddl_Ano_semanal.SelectedValue = 0 Then ' esto es para que si no es año 2019, se vaya por el else 
                Dim oResultadoBLL As New ResultadoBLL
                Dim lstResult As New List(Of ResultadoSemanalEntidad)
                lstResult = oResultadoBLL.listarFacturasxSemana(CInt(Me.ddl_Semanal.SelectedValue))
                If lstResult.Count > 0 Then
                    chartGananciaSemanal.Series(0).IsValueShownAsLabel = True
                    chartGananciaSemanal.DataSource = lstResult
                    chartGananciaSemanal.Series("Series1").XValueMember = "Semana"
                    chartGananciaSemanal.Series("Series1").YValueMembers = "Monto"
                    chartGananciaSemanal.ChartAreas(0).AxisY.LabelStyle.Format = "{0:c}"
                    chartGananciaSemanal.Series(0).YValueType = ChartValueType.Single
                    chartGananciaSemanal.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
                    chartGananciaSemanal.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
                    'Dim leg As New Legend
                    'chartGananciaSemanal.Legends.Add(leg)
                    chartGananciaSemanal.DataBind()
                    lblmensual.Visible = False
                    Lbl_Semanal.Visible = False
                    Lbl_Diario.Visible = False
                Else
                    lblmensual.Visible = False
                    Lbl_Semanal.Visible = True
                    Lbl_Diario.Visible = False
                    Lbl_Semanal.Text = "No se han encontrado registros para el periodo especificado."
                End If

            Else
                lblmensual.Visible = False
                Lbl_Semanal.Visible = True
                Lbl_Diario.Visible = False
                Lbl_Semanal.Text = "No se han encontrado registros para el periodo especificado."

            End If
        Catch ex As Exception
        End Try
    End Sub


    Protected Sub btn_buscarDiario_Click(sender As Object, e As EventArgs) Handles btn_buscarDiario.Click ' Reporte Diario
        Try

            If ddl_Ano_diario.SelectedValue = 0 Then ' esto es para que si no es año 2019, se vaya por el else 
                Dim oResultadoBLL As New ResultadoBLL
                Dim lstResult As New List(Of ResultadoEntidad)
                lstResult = oResultadoBLL.listarFacturasxDia(CInt(Me.ddl_Diario.SelectedValue))
                If lstResult.Count > 0 Then
                    chartGananciaDiario.Series(0).IsValueShownAsLabel = True
                    chartGananciaDiario.DataSource = lstResult
                    chartGananciaDiario.Series("Series1").XValueMember = "Fecha"
                    chartGananciaDiario.Series("Series1").YValueMembers = "Monto"
                    chartGananciaDiario.ChartAreas(0).AxisY.LabelStyle.Format = "{0:c}"
                    chartGananciaDiario.Series(0).YValueType = ChartValueType.Single
                    chartGananciaDiario.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
                    chartGananciaDiario.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
                    'Dim leg As New Legend
                    'chartGananciaDiario.Legends.Add(leg)
                    chartGananciaDiario.DataBind()
                    lblmensual.Visible = False
                    Lbl_Semanal.Visible = False
                    Lbl_Diario.Visible = False
                Else
                    lblmensual.Visible = False
                    Lbl_Semanal.Visible = False
                    Lbl_Diario.Visible = True
                    Lbl_Diario.Text = "No se han encontrado registros para el periodo especificado."
                End If
            Else
                lblmensual.Visible = False
                Lbl_Semanal.Visible = False
                Lbl_Diario.Visible = True
                Lbl_Diario.Text = "No se han encontrado registros para el periodo especificado."
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class