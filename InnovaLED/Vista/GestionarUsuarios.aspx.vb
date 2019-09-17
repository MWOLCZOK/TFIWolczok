Imports System.Web.HttpContext
Imports Entidades
Imports Negocio



Public Class GestionarUsuarios
    Inherits System.Web.UI.Page

    Private Sub Gestionar_Usuario_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Ocultamiento(False)
                CargarUsuarios()
                CargarPerfiles()
                CargarIdiomas()
                Session("RolesSeleccionados") = New List(Of RolEntidad)
            Catch ex As Exception

            End Try

        End If
    End Sub


    Private Sub CargarUsuarios()
        Dim lista As List(Of Entidades.UsuarioEntidad)
        Dim Gestor As New Negocio.UsuarioBLL
        If Not IsNothing(Current.Session("cliente")) Then
            lista = Gestor.TraerUsuariosParaBloqueo(Current.Session("cliente"))
        Else Return
        End If
        If lista.Count > 0 Then
            Session("Usuarios") = lista
            Me.gv_Usuarios.DataSource = lista
            Me.gv_Usuarios.DataBind()
        Else
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If
            Me.alertvalid.Visible = True
            Me.alertvalid.InnerText = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "ModUserError3").Traduccion
            Me.success.Visible = False
        End If
    End Sub


    Private Sub CargarPerfiles()
        Dim lista As List(Of Entidades.RolEntidad)
        Dim Gestor As New Negocio.GestorPermisosBLL
        lista = Gestor.ListarFamiliasGestion()
        If lista.Count > 0 Then
            Session("Roles") = lista
            Me.gv_Roles.DataSource = lista
            Me.gv_Roles.DataBind()
        Else
            'Dim IdiomaActual As Entidades.IdiomaEntidad
            'If IsNothing(Current.Session("Cliente")) Then
            '    IdiomaActual = Application("Español")
            'Else
            '    IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            'End If
            'Me.alertvalid.Visible = True
            'Me.alertvalid.InnerText = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "ModUserError3").Traduccion
            'Me.success.Visible = False
        End If

    End Sub

    Private Sub CargarIdiomas()
        Dim lista As List(Of Entidades.IdiomaEntidad)
        Dim Gestor As New Negocio.IdiomaBLL
        lista = Gestor.ConsultarIdiomas()
        If lista.Count > 0 Then
            Session("Idiomas") = lista
            Me.DropDownListIdioma.DataSource = lista
            Me.DropDownListIdioma.DataBind()
            Me.DropDownListIdioma.DataSource = lista
            Me.DropDownListIdioma.DataBind()
        End If

    End Sub

    Private Sub gv_Usuarios_DataBound(sender As Object, e As EventArgs) Handles gv_Usuarios.DataBound
        Try

            Try
                Dim ddl2 As DropDownList = CType(gv_Usuarios.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            Catch ex As Exception
                Return
            End Try

            Dim ddl As DropDownList = CType(gv_Usuarios.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            Dim ddlpage As DropDownList = CType(gv_Usuarios.BottomPagerRow.Cells(0).FindControl("ddlPageSize"), DropDownList)
            Dim txttotal As Label = CType(gv_Usuarios.BottomPagerRow.Cells(0).FindControl("lbltotalpages"), Label)

            ddlpage.ClearSelection()
            ddlpage.Items.FindByValue(gv_Usuarios.PageSize).Selected = True

            txttotal.Text = gv_Usuarios.PageCount

            For cnt As Integer = 0 To gv_Usuarios.PageCount - 1
                Dim curr As Integer = cnt + 1
                Dim item As New ListItem(curr.ToString())
                If cnt = gv_Usuarios.PageIndex Then
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
            For Each row As GridViewRow In gv_Usuarios.Rows
                Dim imagen1 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Bloquear"), System.Web.UI.WebControls.ImageButton)
                Dim imagen2 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_desbloqueo"), System.Web.UI.WebControls.ImageButton)
                Dim imagen3 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_editar"), System.Web.UI.WebControls.ImageButton)

                imagen1.CommandArgument = row.RowIndex
                imagen2.CommandArgument = row.RowIndex
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

            With gv_Usuarios.HeaderRow
                '.Cells(0).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderID").Traduccion
                '.Cells(1).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderNombreUsuario").Traduccion
                '.Cells(2).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderIdioma").Traduccion
                '.Cells(3).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderBloqueo").Traduccion
                '.Cells(4).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderEmpleado").Traduccion
                '.Cells(5).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderFechaAlta").Traduccion
                '.Cells(6).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderAcciones").Traduccion
            End With

            gv_Usuarios.BottomPagerRow.Visible = True
            gv_Usuarios.BottomPagerRow.CssClass = "table-bottom-dark"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gv_Roles_DataBound(sender As Object, e As EventArgs) Handles gv_Roles.DataBound
        Try


            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If
            For Each row As GridViewRow In gv_Roles.Rows
                Dim imagen1 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Seleccionar"), System.Web.UI.WebControls.ImageButton)

                imagen1.CommandArgument = row.RowIndex
            Next

            With gv_Roles.HeaderRow
                '.Cells(0).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderID").Traduccion
                '.Cells(1).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderNombreUsuario").Traduccion
                '.Cells(2).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderIdioma").Traduccion
                '.Cells(3).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderBloqueo").Traduccion
                '.Cells(4).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderEmpleado").Traduccion
                '.Cells(5).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderFechaAlta").Traduccion
                '.Cells(6).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderAcciones").Traduccion
            End With

            gv_Roles.BottomPagerRow.Visible = True
            gv_Roles.BottomPagerRow.CssClass = "table-bottom-dark"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gv_Roles_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gv_Roles.RowCommand

        Try
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If

            Dim Rolsele As RolEntidad = TryCast(Session("Roles"), List(Of RolEntidad))(e.CommandArgument)

            Select Case e.CommandName.ToString
                Case "S"

                    If TryCast(Session("RolesSeleccionados"), List(Of Entidades.RolEntidad)).Any(Function(p) p.ID_Rol = Rolsele.ID_Rol) Then
                        gv_Roles.Rows.Item(e.CommandArgument).BackColor = Drawing.Color.FromName("#c3e6cb")
                        TryCast(Session("RolesSeleccionados"), List(Of Entidades.RolEntidad)).Remove(Rolsele)
                        Dim imagen3 As System.Web.UI.WebControls.ImageButton = DirectCast(gv_Roles.Rows.Item(e.CommandArgument).FindControl("btn_seleccionar"), System.Web.UI.WebControls.ImageButton)
                        imagen3.ImageUrl = "~/Imagenes/check.png"
                    Else
                        gv_Roles.Rows.Item(e.CommandArgument).BackColor = Drawing.Color.Cyan
                        TryCast(Session("RolesSeleccionados"), List(Of Entidades.RolEntidad)).Add(Rolsele)
                        Dim imagen3 As System.Web.UI.WebControls.ImageButton = DirectCast(gv_Roles.Rows.Item(e.CommandArgument).FindControl("btn_seleccionar"), System.Web.UI.WebControls.ImageButton)
                        imagen3.ImageUrl = "~/Imagenes/clear.png"
                    End If




            End Select
        Catch ex As Exception

        End Try
    End Sub


    Private Sub ModificarUsuario_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        Try
            If Not IsNothing(gv_Usuarios.HeaderRow) Then
                gv_Usuarios.HeaderRow.TableSection = TableRowSection.TableHeader
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Ocultamiento(ByVal bi As Boolean)

        Me.btnModificar.Visible = bi
        Me.btneliminar.Visible = bi
    End Sub

    Private Sub gv_Usuarios_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gv_Usuarios.RowCommand
        'Funcion para que luego de clickear en el Grid lo pase a los textbox
        Try
            Ocultamiento(False)
            Dim gestor As New Negocio.UsuarioBLL
            Dim Usuario As Entidades.UsuarioEntidad = TryCast(Session("Usuarios"), List(Of Entidades.UsuarioEntidad))(e.CommandArgument + (gv_Usuarios.PageIndex * gv_Usuarios.PageSize))
            Me.id_usuario.Value = e.CommandArgument
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If
            Select Case e.CommandName.ToString
                Case "B"
                    If Usuario.Bloqueo = True Then
                        Me.alertvalid.Visible = True
                        Me.alertvalid.InnerText = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "ModUserError1").Traduccion
                        Me.success.Visible = False
                    Else
                        gestor.Bloquear(Usuario)

                        Dim clienteLogeado As Entidades.UsuarioEntidad = Current.Session("cliente")
                        Dim Bitac As New Bitacora(Usuario, "El usuario " & Usuario.NombreUsu & " Se bloqueó correctamente", Tipo_Bitacora.Modificacion, Now, Request.UserAgent, Request.UserHostAddress, "", "", Request.Url.ToString)
                        BitacoraBLL.CrearBitacora(Bitac)

                        CargarUsuarios()
                        'Me.success.InnerText = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "ModUserSuccess1").Traduccion
                        Me.success.InnerText = "El usuario se bloqueó correctamente."
                        Me.success.Visible = True
                        Me.alertvalid.Visible = False
                    End If
                Case "U"
                    If Usuario.Bloqueo = False Then
                        Me.alertvalid.Visible = True
                        Me.alertvalid.InnerText = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "ModUserError2").Traduccion
                        Me.success.Visible = False
                    Else
                        gestor.Bloquear(Usuario)
                        Dim clienteLogeado As Entidades.UsuarioEntidad = Current.Session("cliente")
                        Dim Bitac As New Bitacora(Usuario, "El usuario " & Usuario.NombreUsu & " Se desbloqueó correctamente", Tipo_Bitacora.Modificacion, Now, Request.UserAgent, Request.UserHostAddress, "", "", Request.Url.ToString)
                        BitacoraBLL.CrearBitacora(Bitac)
                        CargarUsuarios()
                        'Me.success.InnerText = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "ModUserSuccess2").Traduccion
                        Me.success.InnerText = "El usuario se debloqueó correctamente."
                        Me.success.Visible = True
                        Me.alertvalid.Visible = False
                    End If

                Case "E"

                    txtapellido.Text = Usuario.Apellido
                    txtnombre.Text = Usuario.Nombre
                    txtnomusuario.Text = Usuario.NombreUsu
                    TxtDNI.Text = Usuario.DNI
                    txtmail.Text = Usuario.Mail

                    DropDownListIdioma.ClearSelection()
                    'DropDownListRol.ClearSelection()

                    DropDownListIdioma.Items.FindByValue(Usuario.Idioma.ID_Idioma).Selected = True
                    TryCast(Session("RolesSeleccionados"), List(Of Entidades.RolEntidad)).Clear()

                    Dim rolIndice As Integer = 0
                    For Each rol As RolEntidad In TryCast(Session("Roles"), List(Of Entidades.RolEntidad))

                        If Usuario.Rol.Any(Function(m) m.ID_Rol = rol.ID_Rol) Then
                            TryCast(Session("RolesSeleccionados"), List(Of Entidades.RolEntidad)).Add(rol)
                            gv_Roles.Rows.Item(rolIndice).BackColor = Drawing.Color.Cyan
                            Dim imagen3 As System.Web.UI.WebControls.ImageButton = DirectCast(gv_Roles.Rows.Item(rolIndice).FindControl("btn_seleccionar"), System.Web.UI.WebControls.ImageButton)
                            imagen3.ImageUrl = "~/Imagenes/clear.png"
                        Else
                            gv_Roles.Rows.Item(rolIndice).BackColor = Drawing.Color.FromName("#c3e6cb")
                            Dim imagen3 As System.Web.UI.WebControls.ImageButton = DirectCast(gv_Roles.Rows.Item(rolIndice).FindControl("btn_seleccionar"), System.Web.UI.WebControls.ImageButton)
                            imagen3.ImageUrl = "~/Imagenes/check.png"
                        End If
                        rolIndice += 1
                    Next
                    Ocultamiento(True)
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim GestorCliente As New Negocio.UsuarioBLL
        Try
            Dim Usuario As Entidades.UsuarioEntidad = TryCast(Session("Usuarios"), List(Of Entidades.UsuarioEntidad))(Me.id_usuario.Value)

            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If
            If Page.IsValid = True Then
                Usuario.NombreUsu = txtnomusuario.Text
                Usuario.Idioma = New Entidades.IdiomaEntidad With {.ID_Idioma = DropDownListIdioma.SelectedValue}
                Usuario.Rol = Session("RolesSeleccionados")
                If Usuario.Rol.Count > 0 Then
                    If GestorCliente.Modificar(Usuario) Then
                        Dim clienteLogeado As Entidades.UsuarioEntidad = Current.Session("cliente")
                        Dim Bitac As New Bitacora(Usuario, "El usuario " & Usuario.NombreUsu & " Se modificó correctamente", Tipo_Bitacora.Modificacion, Now, Request.UserAgent, Request.UserHostAddress, "", "", Request.Url.ToString)
                        BitacoraBLL.CrearBitacora(Bitac)
                        Me.success.Visible = True
                        Me.alertvalid.Visible = False
                        CargarUsuarios()
                        Ocultamiento(False)
                    End If
                Else
                    Me.alertvalid.Visible = True
                    'Me.textovalid.InnerText = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "FieldValidator2").Traduccion
                    Me.success.Visible = False
                End If

            Else
                Me.alertvalid.Visible = True
                Me.textovalid.InnerText = IdiomaActual.Palabras.FirstOrDefault(Function(p) p.Codigo = "FieldValidator1").Traduccion
                Me.success.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub gv_Usuarios_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            CargarUsuarios()
            gv_Usuarios.PageIndex = e.NewPageIndex
            gv_Usuarios.DataBind()
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub ddlPaging_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim ddl As DropDownList = CType(gv_Usuarios.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            gv_Usuarios.SetPageIndex(ddl.SelectedIndex)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ddlPageSize_SelectedPageSizeChanged(sender As Object, e As EventArgs)
        Try
            Dim ddl As DropDownList = CType(gv_Usuarios.BottomPagerRow.Cells(0).FindControl("ddlPageSize"), DropDownList)
            gv_Usuarios.PageSize = ddl.SelectedValue
            CargarUsuarios()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btneliminar_Click(sender As Object, e As EventArgs)

        Dim GestorCliente As New Negocio.UsuarioBLL
        Try
            Dim Usuario As Entidades.UsuarioEntidad = TryCast(Session("Usuarios"), List(Of Entidades.UsuarioEntidad))(Me.id_usuario.Value)
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If

            Dim usulog As New UsuarioEntidad

            If usulog = Current.Session("Usuarios") Then

                If GestorCliente.Eliminar(Usuario) Then
                    Dim clienteLogeado As Entidades.UsuarioEntidad = Current.Session("cliente")
                    Dim Bitac As New Bitacora(Usuario, "El usuario " & Usuario.NombreUsu & " Se eliminó correctamente", Tipo_Bitacora.Modificacion, Now, Request.UserAgent, Request.UserHostAddress, "", "", Request.Url.ToString)
                    BitacoraBLL.CrearBitacora(Bitac)
                    Me.success.Visible = True
                    'Me.success.InnerText = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "DelUserSuccess").Traduccion
                    Me.success.InnerText = "Se eliminó el usuario correctamente."
                    Me.alertvalid.Visible = False
                    CargarUsuarios()
                    Ocultamiento(False)
                End If
            Else
                Me.success.InnerText = "No se puede eliminar el usuario que esta logueado"
            End If
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Dim GestorCliente As New Negocio.UsuarioBLL
        Dim usu As New Entidades.UsuarioEntidad
        Try
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If
            If Page.IsValid = True Then
                usu.NombreUsu = txtnomusuario.Text
                usu.Nombre = txtnombre.Text
                usu.Apellido = txtapellido.Text
                usu.DNI = TxtDNI.Text
                usu.Mail = txtmail.Text
                Dim PassSalt As List(Of String) = Negocio.EncriptarBLL.EncriptarPassword(txtpass.Value)
                usu.Salt = PassSalt.Item(0)
                usu.Password = PassSalt.Item(1)
                usu.Idioma = New Entidades.IdiomaEntidad With {.ID_Idioma = DropDownListIdioma.SelectedValue}
                usu.Rol = Session("Roles")
                usu.FechaAlta = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                usu.Empleado = True
                If GestorCliente.Alta(usu) Then
                    Dim clienteLogeado As Entidades.UsuarioEntidad = Current.Session("cliente")
                    Dim Bitac As New Bitacora(usu, "El usuario " & usu.NombreUsu & " Se dió de alta correctamente", Tipo_Bitacora.Alta, Now, Request.UserAgent, Request.UserHostAddress, "", "", Request.Url.ToString)
                    BitacoraBLL.CrearBitacora(Bitac)
                    Me.success.Visible = True
                    Me.alertvalid.Visible = False
                End If
            Else
                Me.alertvalid.Visible = True
                Me.textovalid.InnerText = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "FieldValidator1").Traduccion
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
            Me.textovalid.InnerText = nombreuso.Mensaje(IdiomaActual)
            Me.success.Visible = False
        Catch ex As Exception

        End Try
    End Sub

End Class