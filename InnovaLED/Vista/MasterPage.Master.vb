Public Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        Me.Menu.Items.Clear()
        ArmarMenuCompleto()



    End Sub



    Private Sub ArmarMenuCompleto()
        Me.Menu.Items.Add(New MenuItem("Home", "Home", Nothing, "/Default.aspx"))
        Me.Menu.Items.Add(New MenuItem("Seguridad", "Seg"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("Gestionar Roles", "GestionarRoles", Nothing, "/GestionarRoles.aspx"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("Opciones", "Opciones", Nothing, "/Opciones.aspx"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("Gestion de Usuario", "GestiondeUsuario", Nothing, "/GestiondeUsuario.aspx"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("Crear Idioma", "CrearIdioma", Nothing, "/CrearIdioma.aspx"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("Cambiar Contraseña", "CambiarContraseña", Nothing, "/CambiarContraseña.aspx"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("Gestión de Bitácora", "GestiondeBitacora", Nothing, "/GestiondeBitacora.aspx"))



        Me.Menu.Items.Add(New MenuItem("Ingeniería de Preventa", "IngPrev"))
        Me.Menu.Items.Item(2).ChildItems.Add(New MenuItem("Gestionar Soluciones LED", "GestionarSolucionesLED", Nothing, "/GestionarSolucionesLED.aspx"))
        Me.Menu.Items.Item(2).ChildItems.Add(New MenuItem("Generar Presupuesto", "GenerarPresupuesto", Nothing, "/GenerarPresupuesto.aspx"))


        Me.Menu.Items.Add(New MenuItem("Ventas2", "Ventas"))
        Me.Menu.Items.Item(3).ChildItems.Add(New MenuItem("Crear Nuevo Cliente", "CrearNuevoCliente", Nothing, "/CrearNuevoCliente.aspx"))
        Me.Menu.Items.Item(3).ChildItems.Add(New MenuItem("Cargar Venta", "CargarVenta", Nothing, "/CargarVenta.aspx"))
        Me.Menu.Items.Item(3).ChildItems.Add(New MenuItem("Cobro", "Cobro", Nothing, "/Cobro.aspx"))


        Me.Menu.Items.Add(New MenuItem("Facturacion", "Facturacion"))
        Me.Menu.Items.Item(4).ChildItems.Add(New MenuItem("Generar Documento", "GenerarDocumento", Nothing, "/GenerarDocumento.aspx"))
        Me.Menu.Items.Item(4).ChildItems.Add(New MenuItem("Pago a Proveedores", "PagoaProveedores", Nothing, "/PagoaProveedores.aspx"))


        Me.Menu.Items.Add(New MenuItem("Compras", "Compras"))
        Me.Menu.Items.Item(5).ChildItems.Add(New MenuItem("Proveedores", "Proveedores", Nothing, "/Proveedores.aspx"))
        Me.Menu.Items.Item(5).ChildItems.Add(New MenuItem("Solicitud Pedido", "SolicitudPedido", Nothing, "/SolicitudPedido.aspx"))
        Me.Menu.Items.Item(5).ChildItems.Add(New MenuItem("Reporte Stock", "ReporteStock", Nothing, "/ReporteStock.aspx"))



        Me.Menu.Items.Add(New MenuItem("Area de Cliente", "Cliente"))
        Me.Menu.Items.Item(6).ChildItems.Add(New MenuItem("Carrito", "Carrito", Nothing, "/Orders.aspx"))
        Me.Menu.Items.Item(6).ChildItems.Add(New MenuItem("Mis Compras", "Compras", Nothing, "/MyOrders.aspx"))
        Me.Menu.Items.Item(6).ChildItems.Add(New MenuItem("Lista de Productos", "Productos", Nothing, "/ProductList.aspx"))


        Me.Menu.Items.Add(New MenuItem("Almacenes y Logística", "AlmyLog"))
        Me.Menu.Items.Item(7).ChildItems.Add(New MenuItem("Actualizar Stock", "ActualizarStock", Nothing, "/ActualizarStock.aspx"))
        Me.Menu.Items.Item(7).ChildItems.Add(New MenuItem("Crear Producto", "CrearProducto", Nothing, "/CrearProducto.aspx"))
        Me.Menu.Items.Item(7).ChildItems.Add(New MenuItem("Generar Envío", "GenerarEnvio", Nothing, "/GenerarEnvio.aspx"))

        Me.Menu.Items.Add(New MenuItem("Institucional", "Inst"))
        Me.Menu.Items.Item(8).ChildItems.Add(New MenuItem("Institucional", "Institucional", Nothing, "/Institucional.aspx"))

        Me.Menu.Items.Add(New MenuItem("Login", "Log"))
        Me.Menu.Items.Item(9).ChildItems.Add(New MenuItem("Login", "Login", Nothing, "/Login.aspx"))


    End Sub

    Public Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

    End Sub


End Class