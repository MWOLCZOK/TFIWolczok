Imports Entidades
Imports Negocio
Imports System.Web.HttpContext




Public Class DetalleProducto
    Inherits System.Web.UI.Page

    Dim GestorProd As New GestorProductoBLL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim prod As New ProductoEntidad
            ID_Producto.Value = Request.QueryString("contid") ' aca le paso al ID producto hiden que generé en el aspx el id que viene de la página anterior.
            prod.ID_Producto = ID_Producto.Value ' aca le asigno al obj prod el id_prod.value
            GestorProd.TraerProducto(prod)
            Session("producto") = prod
            Dim base64string As String = Convert.ToBase64String(prod.Imagen, 0, prod.Imagen.Length)
            ImgBut.ImageUrl = Convert.ToString("data:image/jpg;base64,") & base64string
            LlenarCampos(prod)
            llenardrop()
            Dim Listacomentarios As New List(Of ComentarioEntidad)
            Dim gestorcomentarios As New GestorComentarioBLL

            Listacomentarios = gestorcomentarios.BuscarComentariosProd(prod)
            GenerarDiseño(Listacomentarios)
        End If
    End Sub


    Private Sub GenerarDiseño()
        Dim prod As New ProductoEntidad
        Dim base64string As String = Convert.ToBase64String(prod.Imagen, 0, prod.Imagen.Length)
        ImgBut.ImageUrl = Convert.ToString("data:image/jpg;base64,") & base64string


    End Sub

    Private Sub LlenarCampos(ByVal prod As ProductoEntidad)

        Lblmarca_descr.Text = prod.Marca
        Lblmodelo_descr.Text = prod.Modelo
        Lbldescrip_descrip.Text = prod.Descripcion
        Lblpeso_descrip.Text = prod.Peso
        Lblwatt_descr.Text = prod.Watt
        Lbllinea_descr.Text = prod.LineaProducto.Descripcion
        Lblcat_descr.Text = prod.CategoriaProducto.Descripcion
        Lblprecio_descr.Text = "AR$ " & prod.Precio

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
                listcompra.Add(compra)

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
        Else
            'Cartelito enojado
        End If
    End Sub
    Private Sub GenerarDiseño(ByVal listacomentarios As List(Of ComentarioEntidad))
        Comentarios.Controls.Clear()
        Comentarios.Controls.Add(New LiteralControl("<table id=""cart"" class=""table table-hover table-condensed"">"))
        Comentarios.Controls.Add(New LiteralControl("<tbody>"))

        For Each com In listacomentarios
            Comentarios.Controls.Add(New LiteralControl("<tr>"))
            Comentarios.Controls.Add(New LiteralControl("<td data-th=""Product"">"))
            Comentarios.Controls.Add(New LiteralControl("<div class=""row"">"))
            Comentarios.Controls.Add(New LiteralControl("<div Class=""col-md-12"">"))
            Comentarios.Controls.Add(New LiteralControl("<p>" & com.Texto & "</p>"))

            Comentarios.Controls.Add(New LiteralControl("</div>"))
            Comentarios.Controls.Add(New LiteralControl("</td>"))
            Comentarios.Controls.Add(New LiteralControl("</tr>"))

        Next

        Comentarios.Controls.Add(New LiteralControl("</tbody>"))
        Comentarios.Controls.Add(New LiteralControl("</table>"))

    End Sub
End Class