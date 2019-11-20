Imports Entidades
Imports Negocio
Imports System.Web.HttpContext




Public Class DetalleProducto
    Inherits System.Web.UI.Page

    Dim GestorProd As New GestorProductoBLL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        star1.Attributes.Add("onmouseover", "this.src = 'IMAGENES/1stargold.png'")
        star1.Attributes.Add("onmouseout", "this.src = 'IMAGENES/1starblack.png'")
        star2.Attributes.Add("onmouseover", "this.src = 'IMAGENES/2stargold.png'")
        star2.Attributes.Add("onmouseout", "this.src = 'IMAGENES/2starblack.png'")
        star3.Attributes.Add("onmouseover", "this.src = 'IMAGENES/3stargold.png'")
        star3.Attributes.Add("onmouseout", "this.src = 'IMAGENES/3starblack.png'")
        star4.Attributes.Add("onmouseover", "this.src = 'IMAGENES/4stargold.png'")
        star4.Attributes.Add("onmouseout", "this.src = 'IMAGENES/4starblack.png'")
        star5.Attributes.Add("onmouseover", "this.src = 'IMAGENES/5stargold.png'")
        star5.Attributes.Add("onmouseout", "this.src = 'IMAGENES/5starblack.png'")
        Dim prod As New ProductoEntidad
        ID_Producto.Value = Request.QueryString("contid") ' aca le paso al ID producto hiden que generé en el aspx el id que viene de la página anterior.
        prod.ID_Producto = ID_Producto.Value ' aca le asigno al obj prod el id_prod.value
        GestorProd.TraerProducto(prod)
        Session("producto") = prod
        Dim base64string As String = Convert.ToBase64String(prod.Imagen, 0, prod.Imagen.Length)
        ImgBut.ImageUrl = Convert.ToString("data:image/jpg;base64,") & base64string
        LlenarCampos(prod)
        llenardrop()
        If IsNothing(Session("cliente")) Then
            pregunta.Visible = False
        Else
            pregunta.Visible = True

        End If
        CargarPreguntas(prod)
        CargarValoraciones(prod)
    End Sub
    Private Sub CargarPreguntas(ByRef prod As ProductoEntidad)
        Dim Listacomentarios As New List(Of ComentarioEntidad)
        Dim gestorcomentarios As New GestorComentarioBLL

        Listacomentarios = gestorcomentarios.BuscarComentariosProd(prod)
        GenerarDiseño(Listacomentarios)
    End Sub
    Private Sub CargarValoraciones(ByRef prod As ProductoEntidad)

        Dim ListaValoraciones As New List(Of ValoracionEntidad)
        Dim gestorvaloraciones As New GestorvaloracionBLL

        If gestorvaloraciones.PuedeValorar(prod, IIf(IsNothing(Session("cliente")), New UsuarioEntidad With {.ID_Usuario = 0}, Session("cliente"))) Then
            valorarocultado.Visible = True
        Else
            valorarocultado.Visible = False
        End If

        ListaValoraciones = gestorvaloraciones.BuscarvaloracionsProd(prod)
        GenerarDiseño(ListaValoraciones)
    End Sub

    Private Sub GenerarDiseño()
        Dim prod As New ProductoEntidad
        Dim base64string As String = Convert.ToBase64String(prod.Imagen, 0, prod.Imagen.Length)
        ImgBut.ImageUrl = Convert.ToString("data:image/jpg;base64,") & base64string


    End Sub

    Private Sub LlenarCampos(ByVal prod As ProductoEntidad)

        Dim ListaValoraciones As New List(Of ValoracionEntidad)
        Dim gestorvaloraciones As New GestorvaloracionBLL
        ListaValoraciones = gestorvaloraciones.BuscarvaloracionsProd(prod)
        Dim TotValoraciones As Integer = 0
        Dim PromValoracion As Single = 0
       

        For Each Valoracion As ValoracionEntidad In ListaValoraciones
            TotValoraciones = TotValoraciones + Valoracion.Valor
            PromValoracion = TotValoraciones / ListaValoraciones.Count

        Next


        Lblmarca_descr.Text = prod.Marca
        Lblmodelo_descr.Text = prod.Modelo
        Lbldescrip_descrip.Text = prod.Descripcion
        Lblpeso_descrip.Text = prod.Peso
        Lblwatt_descr.Text = prod.Watt
        Lbllinea_descr.Text = prod.LineaProducto.Descripcion
        Lblcat_descr.Text = prod.CategoriaProducto.Descripcion
        Lblprecio_descr.Text = "$ " & prod.Precio
        Lbl_PromValoracion.Text = Math.Round(Convert.ToDouble(PromValoracion), 1)

    End Sub

    Private Sub llenardrop()
        Dropnumeric.DataSource = Enumerable.Range(1, 50)
        Dropnumeric.DataBind()
    End Sub


    Protected Sub btn_comprar_Click(sender As Object, e As EventArgs) Handles btn_comprar.Click

        If IsNothing(Current.Session("cliente")) Or IsDBNull(Current.Session("Cliente")) Then
            Me.alertvalid.Visible = True
            Me.alertvalid.InnerText = "Debe loguearse para continuar con la compra"
        Else

            Dim compra As New CompraEntidad
            compra.Producto = Session("producto")
            compra.Cantidad = Dropnumeric.SelectedValue

            If IsNothing(Session("carrito")) Then
                Dim listcompra As New List(Of CompraEntidad)
                listcompra.Add(compra)
                Session("carrito") = listcompra


            Else
                Dim listcompra As List(Of CompraEntidad) = Session("carrito")
                If Not listcompra.Any(Function(p) p.Producto.ID_Producto = compra.Producto.ID_Producto) Then
                    listcompra.Add(compra)
                End If


            End If

            Response.Redirect("carritoCompras.aspx")
        End If
    End Sub

    Protected Sub btn_consultar_Click(sender As Object, e As EventArgs) Handles btn_consultar.Click
        Dim Comentario As New ComentarioEntidad
        Comentario.Usuario = Session("cliente")
        Comentario.Texto = txt_consulta.InnerText
        Comentario.Producto = Session("producto")
        Dim gestorComentario As New GestorComentarioBLL
        If gestorComentario.GenerarComentario(Comentario) Then
            'cartelito feliz
            CargarPreguntas(Comentario.Producto)
        Else
            'Cartelito enojado
        End If
    End Sub
    Private Sub GenerarDiseño(ByVal listacomentarios As List(Of ComentarioEntidad))
        Comentarios.Controls.Clear()
        Comentarios.Controls.Add(New LiteralControl("<table id=""cart"" class=""table table-hover table-condensed"">"))
        Comentarios.Controls.Add(New LiteralControl("<tbody>"))

        For Each com In listacomentarios
            If IsNothing(com.Pregunta) Then
                Comentarios.Controls.Add(New LiteralControl("<tr  bgcolor=""#e0ffff""> "))
            Else
                Comentarios.Controls.Add(New LiteralControl("<tr  bgcolor=""#ffffe0""> "))
            End If


            Comentarios.Controls.Add(New LiteralControl("<td data-th=""Product"">"))
            Comentarios.Controls.Add(New LiteralControl("<div class=""row"">"))
            Comentarios.Controls.Add(New LiteralControl("<div Class=""col-md-12 text-left"">"))
            Comentarios.Controls.Add(New LiteralControl("<p>" & com.Usuario.NombreUsu & " - " & com.Fecha & "</p>"))
            Comentarios.Controls.Add(New LiteralControl("</div>"))
            Comentarios.Controls.Add(New LiteralControl("</div>"))
            Comentarios.Controls.Add(New LiteralControl("<div class=""row"">"))
            Comentarios.Controls.Add(New LiteralControl("<div Class=""col-md-12 text-left"">"))
            Comentarios.Controls.Add(New LiteralControl("<p><h4>" & com.Texto & "<h4/></p>"))
            Comentarios.Controls.Add(New LiteralControl("</div>"))
            Comentarios.Controls.Add(New LiteralControl("</div>"))
            Comentarios.Controls.Add(New LiteralControl("</td>"))
            Comentarios.Controls.Add(New LiteralControl("</tr>"))

        Next

        Comentarios.Controls.Add(New LiteralControl("</tbody>"))
        Comentarios.Controls.Add(New LiteralControl("</table>"))

    End Sub

    Private Sub GenerarDiseño(ByVal listavaloraciones As List(Of ValoracionEntidad))
        valoraciones.Controls.Clear()
        valoraciones.Controls.Add(New LiteralControl("<table id=""cart"" class=""table table-hover table-condensed"">"))
        valoraciones.Controls.Add(New LiteralControl("<tbody>"))

        For Each com In listavaloraciones
            valoraciones.Controls.Add(New LiteralControl("<tr  bgcolor=""#ffffe0""> "))
            valoraciones.Controls.Add(New LiteralControl("<td data-th=""Product"">"))
            valoraciones.Controls.Add(New LiteralControl("<div class=""row"">"))
            valoraciones.Controls.Add(New LiteralControl("<div Class=""col-md-12 text-left"">"))
            valoraciones.Controls.Add(New LiteralControl("<p>" & com.Usuario.NombreUsu & " - " & com.Fecha & "</p>"))
            valoraciones.Controls.Add(New LiteralControl("</div>"))
            valoraciones.Controls.Add(New LiteralControl("</div>"))
            valoraciones.Controls.Add(New LiteralControl("<div class=""row"">"))
            valoraciones.Controls.Add(New LiteralControl("<div Class=""col-md-12 text-left"">"))
            Select Case com.Valor
                Case 1
                    valoraciones.Controls.Add(New LiteralControl("<img src=""IMAGENES/1starblack.png"" height=""35px"" />"))
                Case 2
                    valoraciones.Controls.Add(New LiteralControl("<img src=""IMAGENES/2starblack.png"" height=""35px"" />"))
                Case 3
                    valoraciones.Controls.Add(New LiteralControl("<img src=""IMAGENES/3starblack.png"" height=""35px"" />"))
                Case 4
                    valoraciones.Controls.Add(New LiteralControl("<img src=""IMAGENES/4starblack.png"" height=""35px"" />"))
                Case 5
                    valoraciones.Controls.Add(New LiteralControl("<img src=""IMAGENES/5starblack.png"" height=""35px"" />"))
            End Select

            valoraciones.Controls.Add(New LiteralControl("<p><h4>" & com.Texto & "<h4/></p>"))
            valoraciones.Controls.Add(New LiteralControl("</div>"))
            valoraciones.Controls.Add(New LiteralControl("</div>"))
            valoraciones.Controls.Add(New LiteralControl("</td>"))
            valoraciones.Controls.Add(New LiteralControl("</tr>"))

        Next

        valoraciones.Controls.Add(New LiteralControl("</tbody>"))
        valoraciones.Controls.Add(New LiteralControl("</table>"))

    End Sub

    Private Sub star1_Click(sender As Object, e As ImageClickEventArgs) Handles star1.Click
        star1.Attributes.Remove("onmouseover")
        star1.Attributes.Remove("onmouseout")
        star1.ImageUrl = "IMAGENES/1stargold.png"
        star2.ImageUrl = "IMAGENES/2starblack.png"
        star3.ImageUrl = "IMAGENES/3starblack.png"
        star4.ImageUrl = "IMAGENES/4starblack.png"
        star5.ImageUrl = "IMAGENES/5starblack.png"
        Session("Valoracion") = 1
    End Sub

    Private Sub star2_Click(sender As Object, e As ImageClickEventArgs) Handles star2.Click
        star1.Attributes.Remove("onmouseover")
        star1.Attributes.Remove("onmouseout")
        star2.Attributes.Remove("onmouseover")
        star2.Attributes.Remove("onmouseout")
        star1.ImageUrl = "IMAGENES/1stargold.png"
        star2.ImageUrl = "IMAGENES/2stargold.png"
        star3.ImageUrl = "IMAGENES/3starblack.png"
        star4.ImageUrl = "IMAGENES/4starblack.png"
        star5.ImageUrl = "IMAGENES/5starblack.png"
        Session("Valoracion") = 2
    End Sub

    Private Sub star3_Click(sender As Object, e As ImageClickEventArgs) Handles star3.Click
        star1.Attributes.Remove("onmouseover")
        star1.Attributes.Remove("onmouseout")
        star2.Attributes.Remove("onmouseover")
        star2.Attributes.Remove("onmouseout")
        star3.Attributes.Remove("onmouseover")
        star3.Attributes.Remove("onmouseout")
        star1.ImageUrl = "IMAGENES/1stargold.png"
        star2.ImageUrl = "IMAGENES/2stargold.png"
        star3.ImageUrl = "IMAGENES/3stargold.png"
        star4.ImageUrl = "IMAGENES/4starblack.png"
        star5.ImageUrl = "IMAGENES/5starblack.png"
        Session("Valoracion") = 3
    End Sub

    Private Sub star4_Click(sender As Object, e As ImageClickEventArgs) Handles star4.Click
        star1.Attributes.Remove("onmouseover")
        star1.Attributes.Remove("onmouseout")
        star2.Attributes.Remove("onmouseover")
        star2.Attributes.Remove("onmouseout")
        star3.Attributes.Remove("onmouseover")
        star3.Attributes.Remove("onmouseout")
        star4.Attributes.Remove("onmouseover")
        star4.Attributes.Remove("onmouseout")
        star1.ImageUrl = "IMAGENES/1stargold.png"
        star2.ImageUrl = "IMAGENES/2stargold.png"
        star3.ImageUrl = "IMAGENES/3stargold.png"
        star4.ImageUrl = "IMAGENES/4stargold.png"
        star5.ImageUrl = "IMAGENES/5starblack.png"
        Session("Valoracion") = 4
    End Sub

    Private Sub star5_Click(sender As Object, e As ImageClickEventArgs) Handles star5.Click
        star1.Attributes.Remove("onmouseover")
        star1.Attributes.Remove("onmouseout")
        star2.Attributes.Remove("onmouseover")
        star2.Attributes.Remove("onmouseout")
        star3.Attributes.Remove("onmouseover")
        star3.Attributes.Remove("onmouseout")
        star4.Attributes.Remove("onmouseover")
        star4.Attributes.Remove("onmouseout")
        star5.Attributes.Remove("onmouseover")
        star5.Attributes.Remove("onmouseout")
        star1.ImageUrl = "IMAGENES/1stargold.png"
        star2.ImageUrl = "IMAGENES/2stargold.png"
        star3.ImageUrl = "IMAGENES/3stargold.png"
        star4.ImageUrl = "IMAGENES/4stargold.png"
        star5.ImageUrl = "IMAGENES/5stargold.png"
        Session("Valoracion") = 5
    End Sub

    Private Sub btn_valoracion_Click(sender As Object, e As EventArgs) Handles btn_valoracion.Click
        Dim Valoracion As New ValoracionEntidad
        Valoracion.Usuario = Session("cliente")
        Valoracion.Texto = txt_valoracion.InnerText
        Valoracion.Producto = Session("producto")
        Valoracion.Valor = Session("Valoracion")
        Valoracion.FacturaID = 2
        Dim gestorvaloracion As New GestorvaloracionBLL
        If gestorvaloracion.GenerarValoracion(Valoracion) Then
            'cartelito feliz
            CargarValoraciones(Valoracion.Producto)
        Else
            'Cartelito enojado
        End If
    End Sub
End Class