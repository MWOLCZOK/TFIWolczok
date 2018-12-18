Imports Entidades
Imports Negocio


Public Class Novedades
    Inherits System.Web.UI.Page

    Dim BoletinBLL As New BoletinBLL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            GenerarDiseño()
        End If
    End Sub



    Private Sub GenerarDiseño()
        ID_Catalogo.Controls.Clear()

        Dim _listaboletin As List(Of BoletinEntidad)
        _listaboletin = BoletinBLL.ObtenerBoletinNovedad()


        For Each bol In _listaboletin
            Dim base64string As String = Convert.ToBase64String(bol.Imagen, 0, bol.Imagen.Length)
            Dim divmedia As HtmlGenericControl = New HtmlGenericControl("div")
            divmedia.Attributes.Add("class", "media")
            Dim divmedialeft As HtmlGenericControl = New HtmlGenericControl("div")
            divmedialeft.Attributes.Add("class", "media-left")
            Dim Img As New Image() ' Creamos una imagen que funciona como botón.

            Img.ImageUrl = Convert.ToString("data:image/jpg;base64,") & base64string ' Le asigno al control img botón, la imagen que traigo de la BD.
            Img.Width = 150
            'ImgBut.ID = "Nombre" & bol.Nombre
            Img.CssClass = "media-object"
            'ImgBut.PostBackUrl = "/DetalleProducto.aspx" & "?contid=" & prod.ID_Producto ' le pasamos por query string el ID de producto a la página del detalleProducto.
            divmedialeft.Controls.Add(Img)
            divmedia.Controls.Add(divmedialeft)

            Dim divmediabody As HtmlGenericControl = New HtmlGenericControl("div")
            divmediabody.Attributes.Add("class", "media-body")
            Dim h3 As HtmlGenericControl = New HtmlGenericControl("h3")
            h3.Attributes.Add("class", "media-heading")
            Dim A As HtmlGenericControl = New HtmlGenericControl("a")
            'A.Attributes.Add("href", "/DetalleProducto.aspx" & "?contid=" & prod.ID_Producto)
            A.InnerText = bol.Nombre
            h3.Controls.Add(A)
            Dim h2 As HtmlGenericControl = New HtmlGenericControl("h2")
            h2.InnerText = bol.Descripcion
            Dim h4 As HtmlGenericControl = New HtmlGenericControl("h4")
            h4.InnerText = bol.Cuerpo
            'Dim p As HtmlGenericControl = New HtmlGenericControl("p")
            'p.InnerText = prod.Watt & " Watt"
            'Dim peso As HtmlGenericControl = New HtmlGenericControl("p")
            'peso.InnerText = "Peso " & prod.Peso & "Kg"
            'Dim check As New CheckBox

            'check.Text = "  Comparar" 'Traducir
            'check.ID = "chk" & prod.ID_Producto
            'check.CssClass = "col-md-offset-2"

            'Dim btn As New Button

            'btn.Text = "Comprar" 'Traducir
            'btn.ID = "btn" & prod.ID_Producto
            'btn.CssClass = "btn btn-success col-md-2 col-lg"
            'btn.PostBackUrl = "/Catalogo.aspx" & "?contid=" & prod.ID_Producto

            divmediabody.Controls.Add(h3)
            divmediabody.Controls.Add(h2)
            divmediabody.Controls.Add(h4)
            'divmediabody.Controls.Add(p)
            'divmediabody.Controls.Add(peso)
            'divmediabody.Controls.Add(check)
            'divmediabody.Controls.Add(btn)
            divmedia.Controls.Add(divmediabody)
            ID_Catalogo.Controls.Add(divmedia)
            Dim hr As HtmlGenericControl = New HtmlGenericControl("hr")
            ID_Catalogo.Controls.Add(hr)


        Next

    End Sub




End Class