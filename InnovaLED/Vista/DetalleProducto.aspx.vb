Imports Entidades
Imports Negocio


Public Class DetalleProducto
    Inherits System.Web.UI.Page

    Dim GestorProd As New GestorProductoBLL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim prod As New ProductoEntidad
            ID_Producto.Value = Request.QueryString("contid") ' aca le paso al ID producto hiden que generé en el aspx el id que viene de la página anterior.
            prod.ID_Producto = ID_Producto.Value ' aca le asigno al obj prod el id_prod.value
            GestorProd.TraerProducto(prod)
            Dim base64string As String = Convert.ToBase64String(prod.Imagen, 0, prod.Imagen.Length)
            ImgBut.ImageUrl = Convert.ToString("data:image/jpg;base64,") & base64string


        End If
    End Sub


    Private Sub GenerarDiseño()
        Dim prod As New ProductoEntidad
        Dim base64string As String = Convert.ToBase64String(prod.Imagen, 0, prod.Imagen.Length)
        ImgBut.ImageUrl = Convert.ToString("data:image/jpg;base64,") & base64string


    End Sub






End Class