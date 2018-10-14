Imports System.Web.HttpContext
Imports Entidades
Imports Negocio



Public Class Catalogo

    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Gestorproducto As New ProductoBLL
        Dim listaproductos As List(Of ProductoEntidad)


        If IsNumeric(Request.QueryString("pagid")) Then
            listaproductos = Gestorproducto.TraerProductosCatalogo(Request.QueryString("pagid"))
            Session("Paginacion") = Request.QueryString("pagid")
        Else
            listaproductos = Gestorproducto.TraerProductosCatalogo(1)
            Session("Paginacion") = 1
        End If

        ID_Catalogo.Controls.Clear()


        For Each prod In listaproductos
            Dim base64string As String = Convert.ToBase64String(prod.Imagen, 0, prod.Imagen.Length)
            Dim divmedia As HtmlGenericControl = New HtmlGenericControl("div")
            divmedia.Attributes.Add("class", "media")
            Dim divmedialeft As HtmlGenericControl = New HtmlGenericControl("div")
            divmedialeft.Attributes.Add("class", "media-left")
            Dim ImgBut As New ImageButton() ' Creamos una imagen que funciona como botón.

            ImgBut.ImageUrl = Convert.ToString("data:image/jpg;base64,") & base64string ' Le asigno al control img botón, la imagen que traigo de la BD.
            ImgBut.Width = 150
            ImgBut.ID = "prd" & prod.ID_Producto
            ImgBut.CssClass = "media-object"
            ImgBut.PostBackUrl = "/DetalleProducto.aspx" & "?contid=" & prod.ID_Producto ' le pasamos por query string el ID de producto a la página del detalleProducto.
            divmedialeft.Controls.Add(ImgBut)
            divmedia.Controls.Add(divmedialeft)

            Dim divmediabody As HtmlGenericControl = New HtmlGenericControl("div")
            divmediabody.Attributes.Add("class", "media-body")
            Dim h3 As HtmlGenericControl = New HtmlGenericControl("h3")
            h3.Attributes.Add("class", "media-heading")
            Dim A As HtmlGenericControl = New HtmlGenericControl("a")
            A.Attributes.Add("href", "/DetalleProducto.aspx" & "?contid=" & prod.ID_Producto)
            A.InnerText = prod.Modelo
            h3.Controls.Add(A)
            Dim h4 As HtmlGenericControl = New HtmlGenericControl("h4")
            h4.InnerText = "AR$ " & prod.Precio
            Dim p As HtmlGenericControl = New HtmlGenericControl("p")
            p.InnerText = prod.Watt ' aca tiene que ir prod.detalle, agregar a la clase y a la BD
            divmediabody.Controls.Add(h3)
            divmediabody.Controls.Add(h4)
            divmediabody.Controls.Add(p)
            divmedia.Controls.Add(divmediabody)
            ID_Catalogo.Controls.Add(divmedia)
            Dim hr As HtmlGenericControl = New HtmlGenericControl("hr")
            ID_Catalogo.Controls.Add(hr)


        Next

        Dim nav As HtmlGenericControl = New HtmlGenericControl("nav")
        nav.Attributes.Add("aria-label", "Page navigation example")
        Dim ul As HtmlGenericControl = New HtmlGenericControl("ul")
        ul.Attributes.Add("class", "pagination justify-content-center pagination-lg")
        Dim li1 As HtmlGenericControl = New HtmlGenericControl("li")
        li1.Attributes.Add("class", "page-item")
        If Session("Paginacion") = 1 Then
            li1.Attributes.Add("class", "disabled")

        End If

        Dim a1 As HtmlGenericControl = New HtmlGenericControl("a")
        a1.Attributes.Add("class", "page-link")
        a1.Attributes.Add("href", "/Catalogo.aspx" & "?pagid=" & (Session("Paginacion") - 1))
        a1.Attributes.Add("tabindex", "-1")
        a1.InnerText = "Anterior"
        li1.Controls.Add(a1)
        ul.Controls.Add(li1)

        Dim li2 As HtmlGenericControl = New HtmlGenericControl("li")
        li2.Attributes.Add("class", "page-item ")
        If Session("Paginacion") = 1 Then
            li2.Attributes.Add("class", "active")

        End If

        Dim a2 As HtmlGenericControl = New HtmlGenericControl("a")
        a2.Attributes.Add("class", "page-link")
        a2.Attributes.Add("href", "/Catalogo.aspx" & "?pagid=" & 1)
        a2.InnerText = 1
        li2.Controls.Add(a2)
        ul.Controls.Add(li2)

        Dim var As Integer = 2

        For index = 1 To listaproductos.Count
            index += 5
            If index > listaproductos.Count Then


                Dim li3 As HtmlGenericControl = New HtmlGenericControl("li")
                li3.Attributes.Add("class", "page-item ")
                If Session("Paginacion") = var Then
                    li3.Attributes.Add("class", "active page-item")
                End If
                li3.Attributes.Add("id", "pr")
                Dim a3 As HtmlGenericControl = New HtmlGenericControl("a")
                a3.Attributes.Add("class", "page-link")
                a3.Attributes.Add("href", "/Catalogo.aspx" & "?pagid=" & var)
                a3.InnerText = var
                var += 1
                li3.Controls.Add(a3)
                ul.Controls.Add(li3)

            End If

        Next

        Dim li4 As HtmlGenericControl = New HtmlGenericControl("li")
        li4.Attributes.Add("class", "page-item")
        If Session("Paginacion") = (var - 1) Then
            li4.Attributes.Add("class", "disabled")

        End If
        Dim a4 As HtmlGenericControl = New HtmlGenericControl("a")
        a4.Attributes.Add("class", "page-link")
        a4.Attributes.Add("href", "/Catalogo.aspx" & "?pagid=" & (Session("Paginacion") + 1))
        a4.InnerText = "Siguiente"
        li4.Controls.Add(a4)
        ul.Controls.Add(li4)
        nav.Controls.Add(ul)
        ID_Catalogo.Controls.Add(nav)






    End Sub



    'esto nos va a servir para el ABM de productos (Uploads)

    'Dim producto As New Producto
    'Dim productoBLL As New ProductoBLL
    '    producto.ID_Producto = 11
    '    producto.Imagen = FileUpload1.FileBytes
    '    productoBLL.ActualizaImagen(producto.Imagen, producto.ID_Producto)




End Class