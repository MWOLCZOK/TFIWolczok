Imports Entidades
Imports Negocio
Public Class ComparacionProducto
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim ListaProd As List(Of ProductoEntidad) = Session("ProductosComparar")
            Dim gestor As New GestorProductoBLL
            If Not IsNothing(ListaProd) Then
                For Each prod In ListaProd
                    prod = gestor.TraerProducto(prod)
                Next
                GenerarDiseño(ListaProd)
            End If

        Else
        End If
    End Sub

    Private Sub GenerarDiseño(ByVal listaproductos As List(Of ProductoEntidad))
        ID_Comparacion.Controls.Clear()

        Dim ListaOrden As New List(Of ProductoEntidad)
        ListaOrden.AddRange(listaproductos.ToArray)

        For Each prod In listaproductos

            Dim base64string As String = Convert.ToBase64String(prod.Imagen, 0, prod.Imagen.Length)
            Dim div As HtmlGenericControl = New HtmlGenericControl("div")
            Dim ImgBut As New ImageButton() ' Creamos una imagen que funciona como botón.
            Select Case listaproductos.Count
                Case 2
                    div.Attributes.Add("class", "col-md-6")
                    ImgBut.CssClass = "col-md-offset-3"
                Case 3
                    div.Attributes.Add("class", "col-md-4")
                    ImgBut.CssClass = "col-md-offset-2"
                Case 4
                    div.Attributes.Add("class", "col-md-3")
                    ImgBut.CssClass = "col-md-offset-1"
            End Select

            Dim divthumbnail As HtmlGenericControl = New HtmlGenericControl("div")
            divthumbnail.Attributes.Add("class", "thumbnail")



            ImgBut.ImageUrl = Convert.ToString("data:image/jpg;base64,") & base64string ' Le asigno al control img botón, la imagen que traigo de la BD.
            ImgBut.Height = 300
            ImgBut.Width = 300
            ImgBut.ID = "prd" & prod.ID_Producto


            ImgBut.PostBackUrl = "/DetalleProducto.aspx" & "?contid=" & prod.ID_Producto ' le pasamos por query string el ID de producto a la página del detalleProducto.
            divthumbnail.Controls.Add(ImgBut)

            Dim divcaption As HtmlGenericControl = New HtmlGenericControl("div")
            divcaption.Attributes.Add("class", "caption")
            Dim h3 As HtmlGenericControl = New HtmlGenericControl("h3")
            Dim A As HtmlGenericControl = New HtmlGenericControl("a")
            A.Attributes.Add("href", "/DetalleProducto.aspx" & "?contid=" & prod.ID_Producto)
            A.InnerText = prod.Modelo
            h3.Controls.Add(A)

            Dim p As HtmlGenericControl = New HtmlGenericControl("p")
            p.InnerText = "Precio: " & prod.Precio
            Dim ImgPrecio As New Image
            ImgPrecio.Height = 50
            ImgPrecio.Width = 50

            ListaOrden = ListaOrden.OrderByDescending(Function(x) x.Precio).ToList
            Select Case ListaOrden.IndexOf(prod)
                Case 0
                    ImgPrecio.ImageUrl = "IMAGENES\first.png"
                Case 1
                    ImgPrecio.ImageUrl = "IMAGENES\second-prize.png"
                Case 2
                    ImgPrecio.ImageUrl = "IMAGENES\third.png"
                Case 3
                    ImgPrecio.ImageUrl = "IMAGENES\cuarto.png"
            End Select

            Dim p2 As HtmlGenericControl = New HtmlGenericControl("p")
            p2.InnerText = "Descripcion: " & prod.Descripcion
            Dim p3 As HtmlGenericControl = New HtmlGenericControl("p")
            p3.InnerText = "Peso: " & prod.Peso
            ListaOrden = ListaOrden.OrderByDescending(Function(x) x.Peso).ToList
            Dim ImgPeso As New Image
            ImgPeso.Height = 50
            ImgPeso.Width = 50

            Select Case ListaOrden.IndexOf(prod)
                Case 0
                    ImgPeso.ImageUrl = "IMAGENES\first.png"
                Case 1
                    ImgPeso.ImageUrl = "IMAGENES\second-prize.png"
                Case 2
                    ImgPeso.ImageUrl = "IMAGENES\third.png"
                Case 3
                    ImgPeso.ImageUrl = "IMAGENES\cuarto.png"
            End Select
            Dim p4 As HtmlGenericControl = New HtmlGenericControl("p")
            p4.InnerText = "Watt: " & prod.Watt
            ListaOrden = ListaOrden.OrderByDescending(Function(x) x.Watt).ToList
            Dim ImgWatt As New Image
            ImgWatt.Height = 50
            ImgWatt.Width = 50
            Select Case ListaOrden.IndexOf(prod)
                Case 0
                    ImgWatt.ImageUrl = "IMAGENES\first.png"
                Case 1
                    ImgWatt.ImageUrl = "IMAGENES\second-prize.png"
                Case 2
                    ImgWatt.ImageUrl = "IMAGENES\third.png"
                Case 3
                    ImgWatt.ImageUrl = "IMAGENES\cuarto.png"
            End Select


            divcaption.Controls.Add(h3)
            Dim hr As HtmlGenericControl = New HtmlGenericControl("hr")
            divcaption.Controls.Add(hr)
            divcaption.Controls.Add(p)
            divcaption.Controls.Add(ImgPrecio)
            divcaption.Controls.Add(p2)
            divcaption.Controls.Add(p3)
            divcaption.Controls.Add(ImgPeso)
            divcaption.Controls.Add(p4)
            divcaption.Controls.Add(ImgWatt)

            divthumbnail.Controls.Add(divcaption)
            div.Controls.Add(divthumbnail)
            ID_Comparacion.Controls.Add(div)
        Next
    End Sub


End Class