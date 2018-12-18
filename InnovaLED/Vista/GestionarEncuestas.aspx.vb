Imports Negocio
Imports Entidades



Public Class GestionarEncuestas
    Inherits System.Web.UI.Page

    Dim preguntaBLL As GestorPreguntaOpinionBLL
    Dim preguntaEntidad As New PreguntaOpinionEntidad

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        Try

            preguntaEntidad.Enunciado = txt_Nombrepregunta.Text


            preguntaBLL.Alta(preguntaEntidad)
        Catch ex As Exception

        End Try
    End Sub


    Public Sub traerRespuestas()
        Dim list As New 
    End Sub


End Class

