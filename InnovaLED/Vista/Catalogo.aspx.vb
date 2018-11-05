Imports System.Web.HttpContext
Imports Entidades
Imports Negocio



Public Class Catalogo

    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If IsNumeric(Request.QueryString("pagid")) Then
                TraerProductosBusqueda(Session("Modelo"), Session("Marca"), Session("PesoDesde"), Session("PesoHasta"), Session("WattDesde"), Session("WattHasta"), Session("PrecioDesde"), Session("PrecioHasta"), Session("LineaProducto"), Session("CategoriaProducto"))
                'Completar con Método que pase txt=sesion("Marca"), etc
            Else
                TraerProductosBusqueda(,,,,,,,, New LineaProducto With {.ID_Linea = 0}, New CategoriaProducto With {.ID_Categoria = 0})
            End If

            CargarCategoria()
            CargarLinea()
        Else
            If IsNumeric(Request.QueryString("contid")) Then
                If IsNothing(Session("Carrito")) Then
                    Dim listaprod As List(Of ProductoEntidad) = Session("Listaproductos")
                    Dim carrito As New List(Of CompraEntidad)
                    carrito.Add(New CompraEntidad With {.Cantidad = 1, .Producto = listaprod.Find(Function(p) p.ID_Producto = CInt(Request.QueryString("contid")))})
                    Session("Carrito") = carrito

                Else
                    Dim listaprod As List(Of ProductoEntidad) = Session("Listaproductos")
                    Dim carrito As List(Of CompraEntidad) = Session("Carrito")
                    carrito.Add(New CompraEntidad With {.Cantidad = 1, .Producto = listaprod.Find(Function(p) p.ID_Producto = CInt(Request.QueryString("contid")))})
                End If
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
            Dim h2 As HtmlGenericControl = New HtmlGenericControl("h2")
            h2.InnerText = prod.Marca
            Dim h4 As HtmlGenericControl = New HtmlGenericControl("h4")
            h4.InnerText = "AR$ " & prod.Precio
            Dim p As HtmlGenericControl = New HtmlGenericControl("p")
            p.InnerText = prod.Watt & " Watt"
            Dim peso As HtmlGenericControl = New HtmlGenericControl("p")
            peso.InnerText = "Peso " & prod.Peso & "Kg"
            Dim check As New CheckBox

            check.Text = "  Comparar" 'Traducir
            check.ID = "chk" & prod.ID_Producto
            check.CssClass = "col-md-offset-2"

            Dim btn As New Button

            btn.Text = "Comprar" 'Traducir
            btn.ID = "btn" & prod.ID_Producto
            btn.CssClass = "btn btn-success col-md-2 col-lg"
            btn.PostBackUrl = "/Catalogo.aspx" & "?contid=" & prod.ID_Producto

            divmediabody.Controls.Add(h3)
            divmediabody.Controls.Add(h2)
            divmediabody.Controls.Add(h4)
            divmediabody.Controls.Add(p)
            divmediabody.Controls.Add(peso)
            divmediabody.Controls.Add(check)
            divmediabody.Controls.Add(btn)
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

        'Paginacion
        For index = 1 To cant
            index += 5
            If cant >= index Then


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


    Private Sub CargarLinea()
        Dim lista As List(Of LineaProducto)
        Dim Gestor As New GestorLineaProdBLL
        lista = Gestor.TraerTodasLineasProd
        lista.Add(New LineaProducto With {.ID_Linea = 0, .Descripcion = "Todos"})
        DropDownLinea.DataSource = lista
        DropDownLinea.DataTextField = "Descripcion"
        DropDownLinea.DataValueField = "ID_Linea"
        DropDownLinea.DataBind()
    End Sub

    Private Sub CargarCategoria()
        Dim lista As List(Of CategoriaProducto)
        Dim Gestor As New GestorCategoriaProdBLL
        lista = Gestor.TraerTodasCatProd
        lista.Add(New CategoriaProducto With {.ID_Categoria = 0, .Descripcion = "Todos"})
        DropDowncat.DataSource = lista
        DropDowncat.DataTextField = "Descripcion"
        DropDowncat.DataValueField = "ID_Categoria"
        DropDowncat.DataBind()
    End Sub

    Private Sub Filtrar()


        Dim Marca As String
        Dim Modelo As String
        Dim PesoDesde As Integer
        Dim PesoHasta As Integer
        Dim WattDesde As Integer
        Dim WattHasta As Integer
        Dim PrecioDesde As Integer
        Dim PrecioHasta As Integer
        Dim LineaProducto As LineaProducto
        Dim CategoriaProducto As CategoriaProducto


        If txtmarca.Text = "" Then
            Marca = Nothing
        Else
            Marca = txtmarca.Text
        End If

        If txtmodelo.Text = "" Then
            Modelo = Nothing
        Else
            Modelo = txtmodelo.Text
        End If

        If txtpesodesde.Text = "" Then
            PesoDesde = Nothing
        Else
            PesoDesde = CInt(txtpesodesde.Text)
        End If

        If txtpesohasta.Text = "" Then
            PesoHasta = Nothing
        Else

            PesoHasta = CInt(txtpesohasta.Text) + 1
        End If

        If txtwattdesde.Text = "" Then
            WattDesde = Nothing
        Else

            WattDesde = CInt(txtwattdesde.Text)
        End If

        If txtwatthasta.Text = "" Then
            WattHasta = Nothing
        Else

            WattHasta = CInt(txtwatthasta.Text)
        End If

        If txtpreciodesde.Text = "" Then
            PrecioDesde = Nothing
        Else

            PrecioDesde = CInt(txtpreciodesde.Text)
        End If

        If txtpreciohasta.Text = "" Then
            PrecioHasta = Nothing
        Else

            PrecioHasta = CInt(txtpreciohasta.Text)
        End If


        LineaProducto = New LineaProducto With {.ID_Linea = DropDownLinea.SelectedValue}
        CategoriaProducto = New CategoriaProducto With {.ID_Categoria = DropDowncat.SelectedValue}

        Session("Marca") = Marca
        Session("Modelo") = Modelo
        Session("PesoDesde") = PesoDesde
        Session("PesoHasta") = PesoHasta
        Session("WattDesde") = WattDesde
        Session("WattHasta") = WattHasta
        Session("PrecioDesde") = PrecioDesde
        Session("PrecioHasta") = PrecioHasta
        Session("LineaProducto") = New LineaProducto With {.ID_Linea = DropDownLinea.SelectedValue}
        Session("CategoriaProducto") = New CategoriaProducto With {.ID_Categoria = DropDowncat.SelectedValue}

        Session("Paginacion") = 1

        TraerProductosBusqueda(Modelo, Marca, PrecioHasta, PrecioDesde, PesoHasta, PesoDesde, WattHasta, WattDesde, LineaProducto, CategoriaProducto)

    End Sub

    Private Sub Ocultamiento()
        txtmarca.Enabled = False
        txtmodelo.Enabled = False
        txtpesodesde.Enabled = False
        txtpesohasta.Enabled = False
        txtwattdesde.Enabled = False
        txtwatthasta.Enabled = False
        txtpreciodesde.Enabled = False
        txtpreciohasta.Enabled = False
        DropDownLinea.Enabled = False
        DropDowncat.Enabled = False
    End Sub


    Protected Sub btn_filtrar_Click(sender As Object, e As EventArgs) Handles btn_filtrar.Click
        Filtrar()
    End Sub

    Protected Sub btn_comparar_Click(sender As Object, e As EventArgs) Handles btn_comparar.Click
        Session("ProductosComparar") = New List(Of ProductoEntidad)
        For Each control In Me.ID_Catalogo.Controls
            If TypeOf control Is HtmlGenericControl Then
                For Each controles In control.Controls
                    For Each controles2 In controles.Controls
                        If TypeOf controles2 Is CheckBox Then
                            If DirectCast(controles2, CheckBox).Checked = True Then
                                Dim var As String = DirectCast(controles2, CheckBox).ID
                                Dim ProdComparar As New ProductoEntidad
                                ProdComparar.ID_Producto = Integer.Parse(var.Replace("chk", ""))
                                Dim ListaProd As List(Of ProductoEntidad) = Session("ProductosComparar")
                                ListaProd.Add(ProdComparar)
                            End If
                        End If
                    Next
                Next
            End If
        Next
        If DirectCast(Session("ProductosComparar"), List(Of ProductoEntidad)).Count > 1 And DirectCast(Session("ProductosComparar"), List(Of ProductoEntidad)).Count < 5 Then
            Response.Redirect("ComparacionProducto.aspx", False)
        Else
            alertvalid.InnerText = "Debe Seleccionar entre 2 y 4 productos para comparar."
            alertvalid.Visible = True
            success.Visible = False
        End If

    End Sub
End Class