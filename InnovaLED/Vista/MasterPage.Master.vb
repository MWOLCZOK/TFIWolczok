﻿Imports System.IO
Imports System.Web.HttpContext
Imports System.Environment
Imports System.Net
Imports System.Globalization
Imports Entidades
Imports Negocio
Imports Newtonsoft.Json.Linq


Public Class MasterPage
    Inherits System.Web.UI.MasterPage

    Private GestorUsu As New UsuarioBLL
    Dim Usuario As New Entidades.UsuarioEntidad

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Not IsPostBack Then

                If IsNothing(Current.Session("cliente")) Or IsDBNull(Current.Session("Cliente")) Then
                    Dim UsuarioInvitado As New Entidades.UsuarioEntidad
                    CargarSinPerfilIdioma(UsuarioInvitado)
                    VisibilidadAcceso(False)
                    TraducirPagina(UsuarioInvitado)
                    miMenuVertical.Attributes.Remove("class")
                    miContenidoPagina.Attributes.Add("class", "col-md-12")
                    CargarIdiomas()
                Else
                    Try
                        Dim Usuario As Entidades.UsuarioEntidad = TryCast(Current.Session("cliente"), Entidades.UsuarioEntidad)
                        CargarPerfil(Usuario)
                        VisibilidadAcceso(True)
                        TraducirPagina(Usuario)
                        miContenidoPagina.Attributes.Add("class", "col-md-10")
                        miMenuVertical.Attributes.Add("class", "col-md-2")
                        CargarIdiomas()
                    Catch ex As Exception

                    End Try
                End If
            Else

                If IsNothing(Current.Session("cliente")) Or IsDBNull(Current.Session("Cliente")) Then
                    Dim UsuarioInvitado As New Entidades.UsuarioEntidad
                    CargarSinPerfilIdioma(UsuarioInvitado)
                    VisibilidadAcceso(False)
                    TraducirPagina(UsuarioInvitado)
                    miMenuVertical.Attributes.Remove("class")
                    miContenidoPagina.Attributes.Add("class", "col-md-12")

                Else
                    Try
                        Dim Usuario As Entidades.UsuarioEntidad = TryCast(Current.Session("cliente"), Entidades.UsuarioEntidad)
                        CargarPerfil(Usuario)
                        VisibilidadAcceso(True)
                        TraducirPagina(Usuario)
                        miContenidoPagina.Attributes.Add("class", "col-md-10")
                        miMenuVertical.Attributes.Add("class", "col-md-2")
                    Catch ex As Exception

                    End Try



                End If
            End If
            'If Request.Path <> Session("PaginaActual") Then
            '    Session("PaginaActual") = Request.Path
            '    If IsNothing(Session("Verificador")) Then
            '        Session("Verificador") = -1
            '    End If


            '    Session("Verificador") += 1
            '    If Session("Verificador") Mod 2 = 0 Then
            '        Session("PaginaAnterior") = Request.Path
            '    End If
            'End If

            'código para botón aceptar >>>>

            If IsNothing(Session("Paginas")) Then
                Session("Paginas") = New List(Of String)
            End If
            If Session("Paginas").count = 0 Then
                Session("Paginas").Add(Request.RawUrl)
            Else
                Dim Paginas As List(Of String) = Session("Paginas")
                If Paginas.Last <> (Request.RawUrl) Then
                    Paginas.Add(Request.RawUrl)
                End If
            End If


        Catch ex As Exception

        End Try

    End Sub


    Private Sub VisibilidadAcceso(B As Boolean)

        Me.lbl_NombredeUsuarioLogueado.Visible = B
        If B = True Then

            Me.lbl_NombredeUsuarioLogueado.Text = DirectCast(Session("cliente"), UsuarioEntidad).Apellido & ", " & DirectCast(Session("cliente"), UsuarioEntidad).Nombre
            YaLogueo.Visible = True
            NoLogueo.Visible = False
            If DirectCast(Session("cliente"), UsuarioEntidad).Empleado = 0 Then
                btn_carrito.Visible = True
            End If
        Else
            YaLogueo.Visible = False
            NoLogueo.Visible = True
            btn_carrito.Visible = False
        End If

    End Sub

    Private Sub ArmarMenuCompleto()

        Me.Menu.Items.Clear()
        Me.Menu.Items.Add(New MenuItem("Home", "Home", Nothing, "/Default.aspx"))

        Me.Menu.Items.Add(New MenuItem("Empresa", "Empresa"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("¿Quienes Somos?", "Institucional", Nothing, "/Institucional.aspx"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("Faqs", "Faqs", Nothing, "/Faqs.aspx"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("Politicas y Seguridad", "PoliticasySeguridad", Nothing, "/PoliticasySeguridad.aspx"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("Terminos y Condiciones", "TerminosyCondiciones", Nothing, "/TerminosyCondiciones.aspx"))
        Me.Menu.Items.Add(New MenuItem("Catalogo", "Catalogo"))
        Me.Menu.Items.Item(2).ChildItems.Add(New MenuItem("Nuestros Productos", "Catalogo", Nothing, "/Catalogo.aspx"))
        Me.Menu.Items.Item(2).ChildItems.Add(New MenuItem("Novedades", "Novedades", Nothing, "/Novedades.aspx"))
        Me.Menu.Items.Add(New MenuItem("¡Nos interesa tu Opinion!", "NosInteresaTuOpinion", Nothing, "/EncuestaGlobal.aspx"))

        Me.menuVertical.Items.Clear()
        Me.menuVertical.Items.Add(New MenuItem("Facturacion", "Facturacion"))
        Me.menuVertical.Items.Item(0).ChildItems.Add(New MenuItem("Generar Documento", "GenerarDocumento", Nothing, "/GenerarDocumento.aspx"))
        Me.menuVertical.Items.Item(0).ChildItems.Add(New MenuItem("Gestionar Facturas", "GestionarFacturas", Nothing, "/GestionarFacturas.aspx"))

        Me.menuVertical.Items.Add(New MenuItem("Marketing", "Marketing"))
        Me.menuVertical.Items.Item(1).ChildItems.Add(New MenuItem("Gestionar Productos", "GestionarProductos", Nothing, "/GestionarProductos.aspx"))
        Me.menuVertical.Items.Item(1).ChildItems.Add(New MenuItem("Newslatter", "RegistrarBoletin", Nothing, "/RegistrarBoletin.aspx"))
        Me.menuVertical.Items.Item(1).ChildItems.Add(New MenuItem("Gestionar Publicidad", "GestionarPublicidad", Nothing, "/GestionarPublicidad.aspx"))
        Me.menuVertical.Items.Item(1).ChildItems.Add(New MenuItem("Preguntas S/ Productos", "PreguntasProductos", Nothing, "/GestionarRespuestas.aspx"))
        Me.menuVertical.Items.Item(1).ChildItems.Add(New MenuItem("Gestionar Encuestas", "GestionarEncuestas", Nothing, "/GestionarEncuestas.aspx"))


        Me.menuVertical.Items.Add(New MenuItem("Seguridad", "Seguridad"))
        Me.menuVertical.Items.Item(2).ChildItems.Add(New MenuItem("Gestionar Usuarios", "GestionarUsuarios", Nothing, "/GestionarUsuarios.aspx"))
        Me.menuVertical.Items.Item(2).ChildItems.Add(New MenuItem("Gestion Idioma", "CrearIdioma", Nothing, "/AgregarIdioma.aspx"))
        Me.menuVertical.Items.Item(2).ChildItems.Add(New MenuItem("Modificar Idioma", "ModificarIdioma", Nothing, "/ModificarIdioma.aspx"))
        Me.menuVertical.Items.Item(2).ChildItems.Add(New MenuItem("Eliminar Idioma", "EliminarIdioma", Nothing, "/EliminarIdioma.aspx"))
        Me.menuVertical.Items.Item(2).ChildItems.Add(New MenuItem("Gestión de Bitácora", "GestiondeBitacora", Nothing, "/BitacoraAuditoria.aspx"))
        Me.menuVertical.Items.Item(2).ChildItems.Add(New MenuItem("Gestionar Roles", "AgregarPerfil", Nothing, "/AgregarPerfil.aspx"))
        Me.menuVertical.Items.Item(2).ChildItems.Add(New MenuItem("Backup & Restore", "Backup&Restore", Nothing, "/Restore.aspx"))

        Me.menuVertical.Items.Add(New MenuItem("Mi Cuenta Corriente ", "MiCuentaCorriente"))
        Me.menuVertical.Items.Item(3).ChildItems.Add(New MenuItem("Tracking", "MiTracking", Nothing, "/GestionarMisCompras.aspx"))
        Me.menuVertical.Items.Item(3).ChildItems.Add(New MenuItem("Cuenta Corriente", "MiCuentaCorriente", Nothing, "/MiCuentaCorriente.aspx"))

        Me.menuVertical.Items.Add(New MenuItem("Reportes", "Reportes"))
        Me.menuVertical.Items.Item(4).ChildItems.Add(New MenuItem("Mis Reportes Ventas", "ReportesVentas", Nothing, "/ReportesVentas.aspx"))
        Me.menuVertical.Items.Item(4).ChildItems.Add(New MenuItem("Mis Tiempos de Rta", "ReportesTRChat", Nothing, "/ReportesTRChat.aspx"))
        Me.menuVertical.Items.Item(4).ChildItems.Add(New MenuItem("Mis Reportes Encuestas", "ReporteEncuestas", Nothing, "/ReporteEncuestas.aspx"))


        Me.menuVertical.Items.Add(New MenuItem("Mis Chats", "MisChats"))
        Me.menuVertical.Items.Item(5).ChildItems.Add(New MenuItem("Ingresar al Chat", "IngresaralChat", Nothing, "/Chat.aspx"))


    End Sub

    Private Sub CargarSinPerfilIdioma(ByRef UsuarioInvitado As Entidades.UsuarioEntidad)
        Me.Menu.Items.Clear()
        Me.Menu.Items.Add(New MenuItem("Home", "Home", Nothing, "/Default.aspx"))

        Me.Menu.Items.Add(New MenuItem("Empresa", "Empresa"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("¿Quienes Somos?", "Institucional", Nothing, "/Institucional.aspx"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("Faqs", "Faqs", Nothing, "/Faqs.aspx"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("Politicas y Seguridad", "PoliticasySeguridad", Nothing, "/PoliticasySeguridad.aspx"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("Terminos y Condiciones", "TerminosyCondiciones", Nothing, "/TerminosyCondiciones.aspx"))



        Me.Menu.Items.Add(New MenuItem("Catalogo", "Catalogo"))
        Me.Menu.Items.Item(2).ChildItems.Add(New MenuItem("Nuestros Productos", "Catalogo", Nothing, "/Catalogo.aspx"))
        Me.Menu.Items.Item(2).ChildItems.Add(New MenuItem("Novedades", "Novedades", Nothing, "/Novedades.aspx"))

        'Me.Menu.Items.Add(New MenuItem("Seleccionar Idioma", "SeleccionarIdioma", Nothing, "/SeleccionarIdioma.aspx"))

        Me.Menu.Items.Add(New MenuItem("¡Nos interesa tu Opinion!", "NosInteresaTuOpinion", Nothing, "/EncuestaGlobal.aspx"))

        Dim Rol As New Entidades.RolEntidad
        Rol.Hijos.Add(New Entidades.PermisoBaseEntidad With {.URL = "/Empresa.aspx"})
        Rol.Hijos.Add(New Entidades.PermisoBaseEntidad With {.URL = "/Institucional.aspx"})
        Rol.Hijos.Add(New Entidades.PermisoBaseEntidad With {.URL = "/Faqs.aspx"})
        Rol.Hijos.Add(New Entidades.PermisoBaseEntidad With {.URL = "/PoliticasySeguridad.aspx"})
        Rol.Hijos.Add(New Entidades.PermisoBaseEntidad With {.URL = "/Catalogo.aspx"})
        Rol.Hijos.Add(New Entidades.PermisoBaseEntidad With {.URL = "/Novedades.aspx"})
        Rol.Hijos.Add(New Entidades.PermisoBaseEntidad With {.URL = "/AccesoRestringido.aspx"})
        Rol.Hijos.Add(New Entidades.PermisoBaseEntidad With {.URL = "/ConfirmarRecupero.aspx"})
        Rol.Hijos.Add(New Entidades.PermisoBaseEntidad With {.URL = "/ConfirmarRegistracion.aspx"})
        Rol.Hijos.Add(New Entidades.PermisoBaseEntidad With {.URL = "/RecuperarPassword.aspx"})
        Rol.Hijos.Add(New Entidades.PermisoBaseEntidad With {.URL = "/Newsletter.aspx"})
        Rol.Hijos.Add(New Entidades.PermisoBaseEntidad With {.URL = "/Default.aspx"})
        'Rol.Hijos.Add(New Entidades.PermisoBaseEntidad With {.URL = "/SeleccionarIdioma.aspx"})
        Rol.Hijos.Add(New Entidades.PermisoBaseEntidad With {.URL = "/TerminosyCondiciones.aspx"})
        Rol.Hijos.Add(New Entidades.PermisoBaseEntidad With {.URL = "/DetalleProducto.aspx"})
        Rol.Hijos.Add(New Entidades.PermisoBaseEntidad With {.URL = "/ComparacionProducto.aspx"})
        Rol.Hijos.Add(New Entidades.PermisoBaseEntidad With {.URL = "/EncuestaGlobal.aspx"})
        Rol.Hijos.Add(New Entidades.PermisoBaseEntidad With {.URL = "/BusquedaGlobal.aspx"})
        Rol.Hijos.Add(New Entidades.PermisoBaseEntidad With {.URL = "/SuscripcionBoletin.aspx"})

        UsuarioInvitado.Rol.Add(Rol)


        Dim GestorIdioma As New Negocio.IdiomaBLL
        If IsNothing(Current.Session("Idioma")) Then
            UsuarioInvitado.Idioma = GestorIdioma.ConsultarPorCultura(Request.UserLanguages(0))
            If IsNothing(Application(UsuarioInvitado.Idioma.Nombre)) Then
                Application(UsuarioInvitado.Idioma.Nombre) = UsuarioInvitado.Idioma
            End If
        Else
            If IsNothing(Application(TryCast(Current.Session("Idioma"), Entidades.IdiomaEntidad).Nombre)) Then
                Application(TryCast(Current.Session("Idioma"), Entidades.IdiomaEntidad).Nombre) = GestorIdioma.ConsultarPorID(TryCast(Current.Session("Idioma"), Entidades.IdiomaEntidad).ID_Idioma)
            End If
            UsuarioInvitado.Idioma = Application(TryCast(Current.Session("Idioma"), Entidades.IdiomaEntidad).Nombre)
        End If

        If UsuarioInvitado.ValidarURL(Me.Page.Request.FilePath) = False Then
            'El usuario valida que la URL exista, por medio del Rol.
            Response.Redirect("AccesoRestringido.aspx", False)
        End If





    End Sub


    Private Sub CargarPerfil(ByRef Usuario As Entidades.UsuarioEntidad)
        Dim usu As New UsuarioEntidad

        Dim GestorUsuario As New Negocio.UsuarioBLL

        GestorUsuario.RefrescarUsuario(Usuario)
        ' Permite cambiar permisos en caliente, si el usuario 1 cambia el permiso do usuario 2, cuando el usuario 2 quiera entrar a otra página ya no podrá.
        If Usuario.Bloqueo = True Then
            Current.Session("cliente") = Nothing
            Response.Redirect("/Default.aspx", False)
        End If


        Me.Menu.Items.Clear()
        ArmarMenuCompleto()

        'Funcion para recorrer las paginas y paginas hijas del menu vertical y si no están dentro del Rol, las saca, ya que carga todas por default.

        Dim listaAremover As New List(Of MenuItem)
        For Each pagina As MenuItem In menuVertical.Items
            If pagina.ChildItems.Count > 0 Then
                RecursividadMenu(pagina, Usuario, listaAremover)
            Else

                If Usuario.ValidarURL(pagina.NavigateUrl) = False Then
                    listaAremover.Add(pagina)
                End If
            End If
            If pagina.Value = "MisChats" Then
                usu = Usuario
                Dim mischats As List(Of Entidades.ChatEntidad) = TryCast(Application("ChatGlobal"), List(Of Entidades.ChatEntidad)).FindAll(Function(p) p.Usuario.ID_Usuario = usu.ID_Usuario And p.Finalizado = False)

                For Each chat In mischats
                    For Each mensaje In chat.MensajesChat.Where(Function(t) t.Fecha = chat.MensajesChat.Max(Function(p) p.Fecha))
                        If Not mensaje.Usuario.ID_Usuario = usu.ID_Usuario Then
                            pagina.Text = "Mis Chats (**)"
                        End If
                    Next
                Next

            End If
        Next
        For Each item As MenuItem In listaAremover
            Me.menuVertical.Items.Remove(item)
            'Menu.Items.Remove(item)
            For Each subnivel As MenuItem In menuVertical.Items
                subnivel.ChildItems.Remove(item)
            Next
        Next
        If Usuario.ValidarURL(Me.Page.Request.FilePath) = False Then
            Response.Redirect("AccesoRestringido.aspx", False)
        End If
    End Sub


    Private Sub RecursividadMenu(ByRef pagina As MenuItem, ByRef Usuario As Entidades.UsuarioEntidad, ByRef ListaAremover As List(Of MenuItem))
        Dim flag As Integer = 0
        For Each paginadentro As MenuItem In pagina.ChildItems
            If paginadentro.ChildItems.Count > 0 Then
                RecursividadMenu(paginadentro, Usuario, ListaAremover)
            Else
                If Not Usuario.ValidarURL(paginadentro.NavigateUrl) Then
                    ListaAremover.Add(paginadentro)
                    flag += 1
                End If
            End If
        Next
        If flag = pagina.ChildItems.Count Then
            ListaAremover.Add(pagina)
        End If
    End Sub

    Protected Sub TraducirPagina(ByRef Usuario As Entidades.UsuarioEntidad)
        Try

            Dim MiPagina As String = Right(Request.Path, Len(Request.Path) - 1)

            Dim GestorIdioma As New Negocio.IdiomaBLL
            If IsNothing(Application(Usuario.Idioma.Nombre)) Then
                Application(Usuario.Idioma.Nombre) = GestorIdioma.ConsultarPorID(Usuario.Idioma.ID_Idioma)
            End If

            Me.traducirMenu(Usuario.Idioma.Nombre)
            traducirControl(Me.Master.Controls, Usuario.Idioma.Nombre)

            Dim mpContentPlaceHolder As New ContentPlaceHolder
            mpContentPlaceHolder = Me.FindControl("ContentPlaceHolder1")

            traducirControl(mpContentPlaceHolder.Controls, Usuario.Idioma.Nombre)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub traducirMenu(ByVal Idioma As String)
        Try
            Dim MasterMenu As Menu
            MasterMenu = Me.FindControl("Menu")
            If MasterMenu.Items.Count > 0 Then
                traducirMenuRecursivo(MasterMenu.Items, Idioma)
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub traducir(ByVal _menuitem As MenuItem, ByVal Idioma As String)
        Try
            Dim LStPalabras As List(Of Entidades.Palabras) = CType(Application(Idioma), Entidades.IdiomaEntidad).Palabras
            Dim PalabraAEncontrar As Entidades.Palabras = LStPalabras.Find(Function(p) p.Codigo = _menuitem.Value)
            If Not IsNothing(PalabraAEncontrar) Then
                _menuitem.Text = PalabraAEncontrar.Traduccion
            End If

        Catch ex As Exception
        End Try
    End Sub


    Private Sub traducir(ByVal _button As Button, ByVal Idioma As String)
        Try
            Dim LStPalabras As List(Of Entidades.Palabras) = CType(Application(Idioma), Entidades.IdiomaEntidad).Palabras
            Dim PalabraAEncontrar As Entidades.Palabras = LStPalabras.Find(Function(p) p.Codigo = _button.ID)
            If Not IsNothing(PalabraAEncontrar) Then
                _button.Text = PalabraAEncontrar.Traduccion
            End If


        Catch ex As System.Data.SqlClient.SqlException
        Catch ex As Exception
        End Try
    End Sub

    Private Sub traducir(ByVal _label As Label, ByVal Idioma As String)
        Try
            Dim LStPalabras As List(Of Entidades.Palabras) = CType(Application(Idioma), Entidades.IdiomaEntidad).Palabras
            Dim PalabraAEncontrar As Entidades.Palabras = LStPalabras.Find(Function(p) p.Codigo = _label.ID)
            If Not IsNothing(PalabraAEncontrar) Then
                _label.Text = PalabraAEncontrar.Traduccion
            End If
        Catch ex As System.Data.SqlClient.SqlException
        Catch ex As Exception
        End Try
    End Sub

    Private Sub traducirMenuRecursivo(ByVal _items As MenuItemCollection, ByVal Idioma As String)
        Try
            For Each MiMenuItem As MenuItem In _items
                Me.traducir(MiMenuItem, Idioma)
                If MiMenuItem.ChildItems.Count > 0 Then
                    traducirMenuRecursivo(MiMenuItem.ChildItems, Idioma)
                End If
            Next
        Catch ex As Exception
        End Try

    End Sub

    Private Sub traducirControl(ByVal paramListaControl As ControlCollection, ByVal Idioma As String)
        Try
            For Each miControl As Control In paramListaControl
                If TypeOf miControl Is Button Then
                    traducir(DirectCast(miControl, Button), Idioma)
                ElseIf TypeOf miControl Is Label Then
                    traducir(DirectCast(miControl, Label), Idioma)
                ElseIf TypeOf miControl Is GridView Then
                    Dim ControlGrview As GridView = DirectCast(miControl, GridView)
                    For Each GrvLabel In ControlGrview.BottomPagerRow.Cells(0).Controls
                        If TypeOf GrvLabel Is Label Then
                            traducir(DirectCast(GrvLabel, Label), Idioma)
                        End If
                    Next
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Public Function IsReCaptchaValid() As Boolean
        Dim result = False
        Dim mensaje As String
        Dim captchaResponse = Me.Request("g-recaptcha-response")
        Dim secretKey = ConfigurationManager.AppSettings("reCAPTCHA")
        Dim apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}"
        Dim requestUri = String.Format(apiUrl, secretKey, captchaResponse)
        Dim request = CType(WebRequest.Create(requestUri), HttpWebRequest)
        Using response As WebResponse = request.GetResponse()

            Using stream As StreamReader = New StreamReader(response.GetResponseStream())
                Dim jResponse As JObject = JObject.Parse(stream.ReadToEnd())
                Dim isSuccess = jResponse.Value(Of Boolean)("success")
                result = If((isSuccess), True, False)
            End Using
        End Using
        If result Then
            Return True
        Else
            Return False
        End If
    End Function



    Public Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try

            If IsReCaptchaValid() = True Then
                Dim Cliente As New Entidades.UsuarioEntidad
                Dim IdiomaActual As Entidades.IdiomaEntidad
                Dim clienteLogeado As New Entidades.UsuarioEntidad
                If IsNothing(Current.Session("Cliente")) Then
                    IdiomaActual = Application("Español")
                Else
                    IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
                End If
                If Page.IsValid = True Then
                    Cliente.NombreUsu = txtUser.Value
                    Cliente.Password = txtPassword.Value
                    clienteLogeado = GestorUsu.ExisteUsuario(Cliente)
                    Dim Bitac As New Bitacora(clienteLogeado, "El usuario " & clienteLogeado.NombreUsu & " Se logueo correctamente", Tipo_Bitacora.Login, Now, Request.UserAgent, Request.UserHostAddress, "", "", Request.Url.ToString)
                    BitacoraBLL.CrearBitacora(Bitac)
                    Session("cliente") = clienteLogeado
                    Usuario = DirectCast(Session("cliente"), Entidades.UsuarioEntidad)
                    Me.success.Visible = True
                    Me.lbl_success.InnerText = "Se ha logueado correctamente"
                    Me.alertvalid.Visible = False
                    VisibilidadAcceso(True)
                    'Response.Redirect(Default., False)
                    Response.Redirect(Request.Url.ToString, False)
                End If

                'descomentar lo q esta debajo para que funcione el captcha y la funcion que esta arriba de todo del IF

            Else
                Me.label_alert_login.InnerText = "Debe completar el captcha"
                Me.success.Visible = False
                Me.alert_login.Visible = True
            End If

        Catch ex As Exception
            VisibilidadAcceso(False)
            Me.label_alert_login.InnerText = "Usuario o Contraseña invalidos"
            Me.success.Visible = False
            Me.alert_login.Visible = True
            '        Response.Redirect("~/default.aspx", False)
            '    Else
            '        Me.aert
            '        Me.textovalid.InnerText = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "FieldValidator1").Traduccion
            '        Me.success.Visible = False
            '    End If
            'Catch UsuarioBloqueado As Negocio.ExceptionUsuarioBloqueado
            '    Me.alertvalid.Visible = True
            '    Me.textovalid.InnerText = UsuarioBloqueado.Mensaje(IdiomaActual)
            '    Me.success.Visible = False
            'Catch UsuarioNoExiste As Negocio.ExceptionUsuarioNoExiste
            '    Me.alertvalid.Visible = True
            '    Me.textovalid.InnerText = UsuarioNoExiste.Mensaje(IdiomaActual)
            '    Me.success.Visible = False
            'Catch Password As Negocio.ExceptionPasswordIncorrecta
            '    Me.alertvalid.Visible = True
            '    Me.textovalid.InnerText = Password.Mensaje(IdiomaActual)
            '    Me.success.Visible = False



        End Try
    End Sub

    'Public Sub img_opciones_Click(sender As Object, e As ImageClickEventArgs)
    '    Response.Redirect("cambiarIdioma.aspx")
    'End Sub

    Public Sub btnregistracion_Click(sender As Object, e As EventArgs) Handles btnregistracion.Click
        If chk_terminos.Checked = True Then
            Dim GestorCliente As New Negocio.UsuarioBLL
            Dim usu As New Entidades.UsuarioEntidad
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If
            Try

                If Page.IsValid = True Then

                    If Not ValidarCamposRegistracion() Then
                        Me.success.Visible = False
                        Me.alertvalid.Visible = True
                        Return
                    End If

                    If IsValidEmail(txtmail.Value) Then
                        usu.Mail = txtmail.Value
                    Else
                        Me.success.Visible = False
                        Me.alertvalid.Visible = True
                        Return
                    End If

                    If chk_terminos.Checked = False Then
                        Me.success.Visible = False
                        Me.alertvalid.Visible = True
                        Return
                    End If


                    Dim PassSalt As List(Of String) = Negocio.EncriptarBLL.EncriptarPassword(txtPasswordreg.Value)
                    usu.Apellido = txtapereg.Value
                    usu.Nombre = txtnombrereg.Value
                    usu.NombreUsu = txtUserreg.Value
                    usu.DNI = txtdni.Value
                    usu.Salt = PassSalt.Item(0)
                    usu.Password = PassSalt.Item(1)
                    usu.Idioma = New Entidades.IdiomaEntidad With {.ID_Idioma = 1}
                    usu.Rol.Add(New RolEntidad With {.ID_Rol = 2})
                    usu.FechaAlta = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    usu.Empleado = False
                    usu.Bloqueo = True
                    If GestorCliente.Alta(usu) Then
                        Dim Bitac As New Bitacora(usu, usu.NombreUsu, Tipo_Bitacora.Login, Now, Request.UserAgent, Request.UserHostAddress, "", "", Request.Url.ToString)
                        BitacoraBLL.CrearBitacora(Bitac)
                        Me.success.Visible = True
                        Me.alertvalid.Visible = False
                        'Me.txtusuario.Text = ""
                        EnviarMailRegistro(GestorCliente.GEtToken(usu.ID_Usuario), usu)
                        LimpiarCamposRegistracion()
                    End If
                Else
                    'Me.alertvalid.Visible = True
                    'Me.textovalid.InnerText = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "FieldValidator1").Traduccion
                    'Me.success.Visible = False
                End If
            Catch nombreuso As Negocio.ExceptionNombreEnUso
                'Me.alertvalid.Visible = True
                'Me.textovalid.InnerText = nombreuso.Mensaje(IdiomaActual)
                'Me.success.Visible = False
            Catch ex As Exception


            End Try
        Else
            Me.alertvalid.Visible = True
            Me.success.Visible = False
            Me.alertvalid.InnerText = "Debe completar todos los campos y aceptar los terminos y condiciones."

        End If

    End Sub

    Public Function ValidarCamposRegistracion() As Boolean
        If txtapereg.Value = "" Or txtnombrereg.Value = "" Or txtUserreg.Value = "" Or txtdni.Value = "" Or txtmail.Value = "" Then
            Return False
        Else
            Return True

        End If
    End Function

    Public Sub LimpiarCamposRegistracion()
        txtapereg.Value = ""
        txtnombrereg.Value = ""
        txtUserreg.Value = ""
        txtmail.Value = ""
        txtdni.Value = ""
    End Sub



    Public Sub btnolvidepass_Click(sender As Object, e As EventArgs) Handles btnolvidepass.Click
        Response.Redirect("~/RecuperarPassword.aspx", False)

    End Sub



    Private Sub EnviarMailRegistro(ByVal token As String, ByVal usu As UsuarioEntidad)
        Dim body As String = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("EmailTemplates/registracion.html"))
        Dim ruta As String = HttpContext.Current.Server.MapPath("Imagenes")
        Dim ur As Uri = Request.Url
        Negocio.MailingBLL.enviarMailRegistroUsuario(token, body, ruta, Replace(ur.AbsoluteUri, ur.AbsolutePath, ""), usu)
    End Sub







    Dim invalid As Boolean = False

    Public Function IsValidEmail(strIn As String) As Boolean
        ' funcion para validar correo 
        invalid = False
        If String.IsNullOrEmpty(strIn) Then Return False

        Try
            strIn = Regex.Replace(strIn, "(@)(.+)$", AddressOf Me.DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200))
        Catch e As RegexMatchTimeoutException
            Return False
        End Try

        If invalid Then Return False


        Try
            Return Regex.IsMatch(strIn,
                   "^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                   "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                   RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))
        Catch e As RegexMatchTimeoutException
            Return False
        End Try


    End Function

    Private Function DomainMapper(match As Match) As String
        Try
            ' IdnMapping class with default property values.
            Dim idn As New IdnMapping()

            Dim domainName As String = match.Groups(2).Value
            Try
                domainName = idn.GetAscii(domainName)
            Catch e As ArgumentException
                invalid = True
            End Try
            Return match.Groups(1).Value + domainName
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Protected Sub btnlogout_Click(sender As Object, e As EventArgs) Handles btnlogout.Click

        Session("cliente") = Nothing
        'Dim clienteLogeado As Entidades.UsuarioEntidad = Current.Session("cliente")
        'Dim Bitac As New Bitacora(clienteLogeado, "El usuario " & clienteLogeado.NombreUsu & "se ha deslogueado de la plataforma WEB.", Tipo_Bitacora.Login, Now, Request.UserAgent, Request.UserHostAddress, "", "", Request.Url.ToString)
        'BitacoraBLL.CrearBitacora(Bitac)
        VisibilidadAcceso(False)
        Response.Redirect("Default.aspx", False)

    End Sub

    Private Sub btnsettings_Click(sender As Object, e As EventArgs) Handles btnsettings.Click
        Response.Redirect("cambiarpassword.aspx", False)
    End Sub

    Private Sub btn_carrito_Click(sender As Object, e As ImageClickEventArgs) Handles btn_carrito.Click
        Response.Redirect("carritoCompras.aspx", False)
    End Sub

    Protected Sub btn_busqueda_Click(sender As Object, e As EventArgs) Handles btn_busqueda.Click

        Dim pal As String
        pal = txt_busqueda.Text
        Session("PalabraBusqueda") = pal
        Response.Redirect("BusquedaGlobal.aspx")


    End Sub


    'Región Idioma

    Private Sub CargarIdiomas()
        Dim lista As List(Of Entidades.IdiomaEntidad)
        Dim Gestor As New Negocio.IdiomaBLL
        lista = Gestor.ConsultarIdiomas()
        Me.lstidioma.DataSource = lista
        Me.lstidioma.DataBind()
    End Sub

    Protected Sub Btn_Idioma_Click(sender As Object, e As EventArgs) Handles Btn_Idioma.Click
        Dim GestorCliente As New Negocio.UsuarioBLL
        Try
            Dim clienteLogeado As Entidades.UsuarioEntidad = Current.Session("cliente")
            Dim GestorIdioma As New Negocio.IdiomaBLL
            If Not IsNothing(clienteLogeado) Then
                clienteLogeado.Idioma = GestorIdioma.SeleccionarIdioma(clienteLogeado, CInt(lstidioma.SelectedValue))
            Else
                Current.Session("Idioma") = GestorIdioma.ConsultarPorID(CInt(lstidioma.SelectedValue))
            End If
            Me.success.Visible = True
            Me.success.InnerText = "Se ha cambiado el idioma satisfactoriamente."
            Me.alertvalid.Visible = False
            Page_Load(Nothing,Nothing)
            'Response.Redirect("/SeleccionarIdioma.aspx", False)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_newsletter_Click(sender As Object, e As EventArgs) Handles btn_newsletter.Click
        Response.Redirect("/SuscripcionBoletin.aspx", False)
    End Sub

    Protected Sub btn_Volver_Click(sender As Object, e As EventArgs) Handles btn_Volver.Click
        Dim Paginas As List(Of String) = Session("Paginas")
        If Paginas.Count > 1 Then
            Paginas.RemoveAt(Paginas.Count - 1)
            Response.Redirect(Paginas.ElementAt(Paginas.Count - 1), False)
        End If

    End Sub

End Class