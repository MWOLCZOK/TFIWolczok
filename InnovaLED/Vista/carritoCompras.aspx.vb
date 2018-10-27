Imports Entidades
Imports Negocio


Public Class carritoCompras
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If IsNumeric(Request.QueryString("pagid")) Then

                TraerProductosBusqueda(Session("Modelo"), Session("Marca"), Session("PesoDesde"), Session("PesoHasta"), Session("WattDesde"), Session("WattHasta"), Session("PrecioDesde"), Session("PrecioHasta"), Session("LineaProducto"), Session("CategoriaProducto"))
                'Completar con Método que pase txt=sesion("Marca"), etc
            Else
                TraerProductosBusqueda(,,,,,,,, New LineaProducto With {.ID_Linea = 0}, New CategoriaProducto With {.ID_Categoria = 0})
            End If

        Else

            If IsNumeric(Request.QueryString("carrid")) Then
                Dim list As List(Of ProductoEntidad) = Session("Listaproductos")
                list.Remove(list.Find(Function(p) p.ID_Producto = Request.QueryString("carrid")))
            End If
            GenerarDiseño(Session("Listaproductos"), Session("CantListaproductos"))
        End If

    End Sub

    Private Sub TraerProductosBusqueda(Optional ByVal Modelo As String = Nothing, Optional ByVal Marca As String = Nothing, Optional ByVal PrecioHasta As Integer = Nothing, Optional ByVal PrecioDesde As Integer = Nothing, Optional ByVal PesoHasta As Integer = Nothing, Optional ByVal PesoDesde As Integer = Nothing, Optional ByVal WattHasta As Integer = Nothing, Optional ByVal WattDesde As Integer = Nothing, Optional ByVal LineaProducto As LineaProducto = Nothing, Optional ByVal CategoriaProducto As CategoriaProducto = Nothing)
        Dim Listaproductos As New List(Of ProductoEntidad)
        Dim GestorProducto As New GestorProductoBLL
        Dim CantProd As Integer

        If IsNumeric(Request.QueryString("pagid")) Then
            Listaproductos = GestorProducto.TraerProductosCatalogo(Request.QueryString("pagid"), Modelo, Marca, PrecioHasta, PrecioDesde, PesoHasta, PesoDesde, WattHasta, WattDesde, LineaProducto, CategoriaProducto)
            Session("Paginacion") = Request.QueryString("pagid")
            Session("Listaproductos") = Listaproductos
            CantProd = GestorProducto.TraerCantProductosCatalogo(Request.QueryString("pagid"), Modelo, Marca, PrecioHasta, PrecioDesde, PesoHasta, PesoDesde, WattHasta, WattDesde, LineaProducto, CategoriaProducto)
            Session("CantListaproductos") = CantProd

        Else
            Listaproductos = GestorProducto.TraerProductosCatalogo(1, Modelo, Marca, PrecioHasta, PrecioDesde, PesoHasta, PesoDesde, WattHasta, WattDesde, LineaProducto, CategoriaProducto)
            Session("Paginacion") = 1
            Session("Listaproductos") = Listaproductos
            CantProd = GestorProducto.TraerCantProductosCatalogo(1, Modelo, Marca, PrecioHasta, PrecioDesde, PesoHasta, PesoDesde, WattHasta, WattDesde, LineaProducto, CategoriaProducto)
            Session("CantListaproductos") = CantProd
        End If

        GenerarDiseño(Listaproductos, CantProd)

    End Sub


    Private Sub GenerarDiseño(ByVal listaproductos As List(Of ProductoEntidad), ByVal cant As Integer)
        ID_Catalogo.Controls.Clear()
        ID_Catalogo.Controls.Add(New LiteralControl("<table id=""cart"" class=""table table-hover table-condensed"">"))
        ID_Catalogo.Controls.Add(New LiteralControl("<tbody>"))


        For Each prod In listaproductos
            ID_Catalogo.Controls.Add(New LiteralControl("<tr>"))
            ID_Catalogo.Controls.Add(New LiteralControl("<td data-th=""Product"">"))
            ID_Catalogo.Controls.Add(New LiteralControl("<div class=""row"">"))
            ID_Catalogo.Controls.Add(New LiteralControl("<div Class=""col-md-1"">"))

            Dim base64string As String = Convert.ToBase64String(prod.Imagen, 0, prod.Imagen.Length)
            ID_Catalogo.Controls.Add(New LiteralControl("<img src=" & Convert.ToString("data:image/jpg;base64,") & base64string & " alt=""..."" class=""img-responsive""/>"))
            ID_Catalogo.Controls.Add(New LiteralControl("</div>"))
            ID_Catalogo.Controls.Add(New LiteralControl("<div class=""col-md-5 left"">"))
            ID_Catalogo.Controls.Add(New LiteralControl("<h3>" & prod.Modelo & "</h3>"))
            ID_Catalogo.Controls.Add(New LiteralControl("<h4>" & prod.Descripcion & "</h4>"))
            ID_Catalogo.Controls.Add(New LiteralControl("</div>"))
            ID_Catalogo.Controls.Add(New LiteralControl("<div class=""col-md-2"">"))
            ID_Catalogo.Controls.Add(New LiteralControl("<h3>" & 2 & "</h3>"))
            ID_Catalogo.Controls.Add(New LiteralControl("</div>"))
            ID_Catalogo.Controls.Add(New LiteralControl("<div class=""col-md-2"">"))
            ID_Catalogo.Controls.Add(New LiteralControl("<h3>" & "AR$ " & prod.Precio & "</h3>"))
            ID_Catalogo.Controls.Add(New LiteralControl("</div>"))

            Dim div As HtmlGenericControl = New HtmlGenericControl("div")
            div.Attributes.Add("class", "col-md-2")
            Dim ImgBut As New ImageButton() ' Creamos una imagen que funciona como botón.

            ImgBut.ImageUrl = "IMAGENES\cart.png"
            ImgBut.Width = 50
            ImgBut.CssClass = "media-object"
            ImgBut.PostBackUrl = "/carritoCompras.aspx" & "?carrid=" & prod.ID_Producto ' le pasamos por query string el ID de producto a la página del detalleProducto.
            div.Controls.Add(ImgBut)
            ID_Catalogo.Controls.Add(div)
            ID_Catalogo.Controls.Add(New LiteralControl("</td>"))
            ID_Catalogo.Controls.Add(New LiteralControl("</tr>"))
            '    h3.Controls.Add(A)
            '    Dim h4 As HtmlGenericControl = New HtmlGenericControl("h4")
            '    h4.InnerText = 
            '    Dim p As HtmlGenericControl = New HtmlGenericControl("p")
            '    p.InnerText = prod.Watt ' aca tiene que ir prod.detalle, agregar a la clase y a la BD
            '    divmediabody.Controls.Add(h3)
            '    divmediabody.Controls.Add(h4)
            '    divmediabody.Controls.Add(p)
            '    divmedia.Controls.Add(divmediabody)
            '    ID_Catalogo.Controls.Add(divmedia)
            '    Dim hr As HtmlGenericControl = New HtmlGenericControl("hr")
            '    ID_Catalogo.Controls.Add(hr)


        Next

        ID_Catalogo.Controls.Add(New LiteralControl("</tbody>"))
        ID_Catalogo.Controls.Add(New LiteralControl("</table>"))

    End Sub




End Class