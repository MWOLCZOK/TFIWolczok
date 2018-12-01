Imports Negocio
Imports Entidades

Public Class BusquedaGlobal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Busqueda()
        End If
    End Sub


    Private Sub Busqueda()
        Dim busquedaGlobalBLL As New BusquedaBLL
        Dim palabra As String
        palabra = Session("PalabraBusqueda")
        GenerarResultados(busquedaGlobalBLL.BusquedaGlobal(palabra))

    End Sub


    Private Sub GenerarResultados(ByVal Resultado As List(Of String))

        ID_Resultados.Controls.Clear()


        If Resultado.Count = 0 Then
            Lbl_sinresul.Visible = True
        Else

            For Each _res In Resultado

                If _res = "/DetalleProducto.aspx" Or _res = "/ComparacionProducto.aspx" Then

                Else

                    Dim divmedia As HtmlGenericControl = New HtmlGenericControl("div")
                    divmedia.Attributes.Add("class", "media")
                    Dim divmedialeft As HtmlGenericControl = New HtmlGenericControl("div")
                    divmedialeft.Attributes.Add("class", "media-left")

                    divmedia.Controls.Add(divmedialeft)

                    Dim divmediabody As HtmlGenericControl = New HtmlGenericControl("div")
                    divmediabody.Attributes.Add("class", "media-body")
                    Dim h3 As HtmlGenericControl = New HtmlGenericControl("h3")
                    h3.Attributes.Add("class", "media-heading")
                    Dim A As HtmlGenericControl = New HtmlGenericControl("a")
                    A.Attributes.Add("href", _res)
                    _res = _res.Replace(".aspx", "")
                    _res = _res.Replace("/", "")
                    A.InnerText = _res

                    h3.Controls.Add(A)
                    divmediabody.Controls.Add(h3)
                    divmedia.Controls.Add(divmediabody)
                    ID_Resultados.Controls.Add(divmedia)
                    Dim hr As HtmlGenericControl = New HtmlGenericControl("hr")
                    ID_Resultados.Controls.Add(hr)
                End If

            Next
        End If
    End Sub





End Class