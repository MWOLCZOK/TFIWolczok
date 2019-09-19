Imports System.Web.HttpContext
Imports Entidades
Imports Negocio


Public Class GestionarProductos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then
            Try
                Ocultamiento()
                CargarProductos()
                CargarCategoria()
                CargarLinea()


            Catch ex As Exception

            End Try
        Else
            Ocultamiento3()

        End If
    End Sub




    Private Sub CargarProductos()
        Dim lista As List(Of ProductoEntidad)
        Dim Gestor As New GestorProductoBLL
        'If Not IsNothing(Current.Session("producto")) Then
        lista = Gestor.TraerTodosProductos()
        'Else Return
        'End If
        If lista.Count > 0 Then
            Session("producto") = lista
            Me.gv_Productos.DataSource = lista
            Me.gv_Productos.DataBind()
        Else

        End If
    End Sub

    Private Sub CargarLinea()
        Dim lista As List(Of LineaProducto)
        Dim Gestor As New GestorLineaProdBLL
        lista = Gestor.TraerTodasLineasProd
        DropDownLinea.DataSource = lista
        DropDownLinea.DataTextField = "Descripcion"
        DropDownLinea.DataValueField = "ID_Linea"
        DropDownLinea.DataBind()
    End Sub

    Private Sub CargarCategoria()
        Dim lista As List(Of CategoriaProducto)
        Dim Gestor As New GestorCategoriaProdBLL
        lista = Gestor.TraerTodasCatProd
        DropDowncat.DataSource = lista
        DropDowncat.DataTextField = "Descripcion"
        DropDowncat.DataValueField = "ID_Categoria"
        DropDowncat.DataBind()
    End Sub

    Private Sub Ocultamiento()
        Me.btn_nuevo.Visible = True
        Me.btn_modificar.Visible = False
        Me.btn_confirmar.Visible = False
        Me.btn_agregar.Visible = True
        'txtmarca.Enabled = False
        'txtmodelo.Enabled = False
        'txtdesc.Enabled = False
        'txtpeso.Enabled = False
        'txtwatt.Enabled = False
        'txtprecio.Enabled = False
        'DropDownLinea.Enabled = False
        'DropDowncat.Enabled = False
        'FileUpload1.Enabled = False
    End Sub

    Private Sub Ocultamiento2()
        Me.btn_nuevo.Visible = True
        Me.btn_modificar.Visible = True
        Me.btn_confirmar.Visible = True
        Me.btn_agregar.Visible = False
    End Sub

    Private Sub Ocultamiento3()
        Me.btn_agregar.Visible = True
        Me.btn_modificar.Visible = False
        Me.btn_confirmar.Visible = False
        Me.btn_nuevo.Visible = True
        txtmarca.Enabled = True
        txtmodelo.Enabled = True
        txtdesc.Enabled = True
        txtpeso.Enabled = True
        txtwatt.Enabled = True
        txtprecio.Enabled = True
        DropDownLinea.Enabled = True
        DropDowncat.Enabled = True
        FileUpload1.Enabled = True

    End Sub





    Private Sub gv_Productos_DataBound(sender As Object, e As EventArgs) Handles gv_Productos.DataBound
        Try

            Try
                Dim ddl2 As DropDownList = CType(gv_Productos.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            Catch ex As Exception
                Return
            End Try

            Dim ddl As DropDownList = CType(gv_Productos.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            Dim ddlpage As DropDownList = CType(gv_Productos.BottomPagerRow.Cells(0).FindControl("ddlPageSize"), DropDownList)
            Dim txttotal As Label = CType(gv_Productos.BottomPagerRow.Cells(0).FindControl("lbltotalpages"), Label)

            ddlpage.ClearSelection()
            ddlpage.Items.FindByValue(gv_Productos.PageSize).Selected = True

            txttotal.Text = gv_Productos.PageCount

            For cnt As Integer = 0 To gv_Productos.PageCount - 1
                Dim curr As Integer = cnt + 1
                Dim item As New ListItem(curr.ToString())
                If cnt = gv_Productos.PageIndex Then
                    item.Selected = True
                End If

                ddl.Items.Add(item)

            Next cnt
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If
            For Each row As GridViewRow In gv_Productos.Rows
                Dim imagen3 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_editar"), System.Web.UI.WebControls.ImageButton)
                imagen3.CommandArgument = row.RowIndex


                If row.Cells(4).Text = "False" Then
                    'row.Cells(4).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "MsjNoBloqueado").Traduccion
                Else
                    'row.Cells(4).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "MsjBloqueado").Traduccion
                End If
                If row.Cells(5).Text = "False" Then
                    'row.Cells(5).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "MsjNo").Traduccion
                    imagen3.Visible = False
                Else
                    'row.Cells(5).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "MsjSi").Traduccion
                End If
            Next

            With gv_Productos.HeaderRow
                '.Cells(0).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderID").Traduccion
                '.Cells(1).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderNombreUsuario").Traduccion
                '.Cells(2).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderIdioma").Traduccion
                '.Cells(3).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderBloqueo").Traduccion
                '.Cells(4).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderEmpleado").Traduccion
                '.Cells(5).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderFechaAlta").Traduccion
                '.Cells(6).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderAcciones").Traduccion
            End With

            gv_Productos.BottomPagerRow.Visible = True
            gv_Productos.BottomPagerRow.CssClass = "table-bottom-dark"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ModificarProducto_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        Try
            If Not IsNothing(gv_Productos.HeaderRow) Then
                gv_Productos.HeaderRow.TableSection = TableRowSection.TableHeader
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gv_Productos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gv_Productos.RowCommand
        'Funcion para que luego de clickear en el Grid lo pase a los textbox
        Try
            Ocultamiento2()
            Dim Gestor As New GestorProductoBLL
            Dim producto As ProductoEntidad = TryCast(Session("producto"), List(Of ProductoEntidad))(e.CommandArgument + (gv_Productos.PageIndex * gv_Productos.PageSize))
            Me.id_producto.Value = e.CommandArgument
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If
            Select Case e.CommandName.ToString


                Case "E"

                    txtmarca.Text = producto.Marca
                    txtmodelo.Text = producto.Modelo
                    txtdesc.Text = producto.Descripcion
                    txtpeso.Text = producto.Peso
                    txtprecio.Text = producto.Precio
                    txtwatt.Text = producto.Watt

                    DropDownLinea.ClearSelection()
                    DropDowncat.ClearSelection()
                    DropDownLinea.Items.FindByText(producto.LineaProducto.Descripcion).Selected = True
                    DropDowncat.Items.FindByText(producto.CategoriaProducto.Descripcion).Selected = True


                    'DropDownLinea.ClearSelection()

                    'Ocultamiento(True)
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_Modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        Dim GestorProducto As New GestorProductoBLL
        Try
            ' Dim Producto As ProductoEntidad = TryCast(Session("producto"), List(Of ProductoEntidad))(Me.id_producto.Value)
            Dim producto As ProductoEntidad = TryCast(Session("producto"), List(Of ProductoEntidad))(Me.id_producto.Value + (gv_Productos.PageIndex * gv_Productos.PageSize))
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If
            If Page.IsValid = True Then
                Producto.Marca = txtmarca.Text
                producto.Modelo = txtmodelo.Text
                producto.Descripcion = txtdesc.Text
                producto.Precio = txtprecio.Text
                Producto.Watt = txtwatt.Text
                Producto.Imagen = Producto.Imagen
                Producto.LineaProducto = Nothing
                Producto.LineaProducto = New LineaProducto With {.ID_Linea = DropDownLinea.SelectedValue}
                Producto.CategoriaProducto = Nothing
                Producto.CategoriaProducto = New CategoriaProducto With {.ID_Categoria = DropDowncat.SelectedValue}

                If GestorProducto.Modificar(Producto) Then
                    'Dim clienteLogeado As Entidades.UsuarioEntidad = Current.Session("cliente")
                    'Dim Bitac As New Bitacora(Usuario, "El usuario " & Usuario.NombreUsu & " Se modificó correctamente", Tipo_Bitacora.Modificacion, Now, Request.UserAgent, Request.UserHostAddress, "", "", Request.Url.ToString)
                    'BitacoraBLL.CrearBitacora(Bitac)
                    Me.success.Visible = True
                    Me.alertvalid.Visible = False
                    Me.success.InnerText = "Se ha modificado el producto correctamente."
                    CargarProductos()
                    Ocultamiento2()
                End If
            Else
                Me.alertvalid.Visible = True
                Me.textovalid.InnerText = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "FieldValidator1").Traduccion
                Me.success.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_Nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click


        txtmarca.Text = ""
        txtmodelo.Text = ""
        txtdesc.Text = ""
        txtpeso.Text = ""
        txtprecio.Text = ""
        txtprecio.Text = ""
        txtwatt.Text = ""
        DropDownLinea.ClearSelection()
            DropDowncat.ClearSelection()
            Ocultamiento3()



    End Sub

    Protected Sub gv_Productos_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            CargarProductos()
            gv_Productos.PageIndex = e.NewPageIndex
            gv_Productos.DataBind()
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub ddlPaging_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim ddl As DropDownList = CType(gv_Productos.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            gv_Productos.SetPageIndex(ddl.SelectedIndex)
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub ddlPageSize_SelectedPageSizeChanged(sender As Object, e As EventArgs)
        Try
            Dim ddl As DropDownList = CType(gv_Productos.BottomPagerRow.Cells(0).FindControl("ddlPageSize"), DropDownList)
            gv_Productos.PageSize = ddl.SelectedValue
            CargarProductos()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub btneliminar_Click(sender As Object, e As EventArgs)

        Dim GestorProducto As New GestorProductoBLL
        Try
            Dim producto As ProductoEntidad = TryCast(Session("producto"), List(Of ProductoEntidad))(Me.id_producto.Value + (gv_Productos.PageIndex * gv_Productos.PageSize))
            '(Me.id_producto.Value + (gv_Productos.PageIndex * gv_Productos.PageSize)) esto es igual a la posición elegida +(el numero de pagina * la paginación que le puse) eso me devuelve el ID a eliminar, porque el que selecciono desde la grilla no es el ID sino la posicion.
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If

            GestorProducto.Eliminar(producto)
            Me.success.InnerText = "Se eliminó el producto correctamente."
            Me.alertvalid.Visible = False
            CargarProductos()
            'Ocultamiento(False)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click

        Dim GestorProducto As New GestorProductoBLL

        Dim prod As New ProductoEntidad
        Try
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If
            If Page.IsValid = True Then

                prod.Marca = txtmarca.Text
                prod.Modelo = txtmodelo.Text
                prod.Descripcion = txtdesc.Text
                prod.Precio = txtprecio.Text
                prod.Watt = txtwatt.Text
                prod.Imagen = FileUpload1.FileBytes


                prod.LineaProducto = New LineaProducto With {.ID_Linea = DropDownLinea.SelectedValue}
                prod.CategoriaProducto = New CategoriaProducto With {.ID_Categoria = DropDowncat.SelectedValue}




                If GestorProducto.Alta(prod) Then
                    Me.success.Visible = True
                    Me.textovalid.InnerText = "Se agregó el producto correctamente"
                    Me.alertvalid.Visible = False
                End If
            Else
                Me.alertvalid.Visible = True
                'Me.textovalid.InnerText = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "FieldValidator1").Traduccion
                Me.textovalid.InnerText = "Completar los campos correctamente"
                Me.success.Visible = False
            End If
        Catch nombreuso As Negocio.ExceptionNombreEnUso
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If
            Me.alertvalid.Visible = True
            Me.textovalid.InnerText = "MensajeaCompletar"
            Me.success.Visible = False
        Catch ex As Exception

        End Try
    End Sub












End Class