Imports Entidades
Imports Negocio


Public Class GestionarPerfiles
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                'lo carga solamente la primera vez
                CargarPerfiles()
                CargarPermisos()
                CargarPerfilesParaEliminar()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub ActualizarCampos()
        CargarPerfiles()
        CargarPerfilesParaEliminar()
    End Sub


    Private Sub CargarPerfiles()
        Dim lista As List(Of Entidades.RolEntidad)
        Dim Gestor As New Negocio.GestorPermisosBLL
        lista = Gestor.ListarFamilias
        Session("Roles") = lista

        Me.DropdwnrolesListar.DataSource = lista
        Me.DropdwnrolesListar.DataBind()
        Me.DropdwnrolesListar.SelectedIndex = 0
        Me.DropdwnrolesListar_SelectedIndexChanged(Nothing, Nothing)

    End Sub

    Private Sub CargarPerfilesParaEliminar()
        Dim lista As List(Of Entidades.RolEntidad)
        Dim Gestor As New Negocio.GestorPermisosBLL
        lista = Gestor.ListarFamilias
        Session("Roles") = lista

        Me.DropdwnrolesElim.DataSource = lista
        Me.DropdwnrolesElim.DataBind()
        Me.DropdwnrolesElim.SelectedIndex = 0
        Me.DropdwnrolesElim_SelectedIndexChanged(Nothing, Nothing)

    End Sub


    Private Sub CargarPermisos()
        Dim lista As List(Of Entidades.PermisoBaseEntidad)
        Dim Gestor As New Negocio.GestorPermisosBLL
        lista = Gestor.ListarPermisos
        Session("Permisos") = lista

        Me.Lsttodoslosperfiles.DataSource = lista
        Me.Lsttodoslosperfiles.DataBind()

    End Sub


    Protected Sub Btncrearrol_Click(sender As Object, e As EventArgs) Handles Btncrearrol.Click
        Try
            Dim Rol As New RolEntidad
            Dim GestorRol As New GestorPermisosBLL

            Rol.Nombre = Txtcrearrol.Text
            If GestorRol.Alta(Rol) Then
                'falta bitacora
                Me.alertvalid.Visible = False
                Me.lbl_success.InnerText = "Se ha creado el Rol satisfactoriamente."
                'poner traducción
                Me.success.Visible = True
            Else
                Me.alertvalid.Visible = True
                Me.lbl_textovalid.InnerText = "Ya existe un Rol con ese nombre."
                'poner traducción
                Me.success.Visible = False
            End If
            ActualizarCampos()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub DropdwnrolesListar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropdwnrolesListar.SelectedIndexChanged
        Dim LstRoles As List(Of RolEntidad) = Session("Roles")
        'Me.Lstperfilesactuales.Items.Clear()

        Lstperfilesactuales.DataSource = LstRoles(DropdwnrolesListar.SelectedIndex).Hijos
        Lstperfilesactuales.DataBind()

    End Sub

    Protected Sub Btnagregarrol_Click(sender As Object, e As EventArgs) Handles Btnagregarrol.Click
        Dim Lstpermisos As List(Of PermisoBaseEntidad) = Session("Permisos")
        Dim itempermiso As New ListItem
        itempermiso.Text = Lstpermisos(Me.Lsttodoslosperfiles.SelectedIndex).Nombre
        itempermiso.Value = Me.Lsttodoslosperfiles.SelectedValue

        If IsNothing(Lstperfilesactuales.Items.FindByValue(Me.Lsttodoslosperfiles.SelectedValue)) Then
            Lstperfilesactuales.Items.Add(itempermiso)
        End If

    End Sub

    Protected Sub Btnquitarrol_Click(sender As Object, e As EventArgs) Handles Btnquitarrol.Click
        Dim Lstpermisos As List(Of PermisoBaseEntidad) = Session("Permisos")
        Lstperfilesactuales.Items.Remove(Me.Lstperfilesactuales.SelectedItem)
    End Sub

    Protected Sub btneliminar_Click(sender As Object, e As EventArgs)
        Try
            Dim GestorRol As New GestorPermisosBLL
            Dim Rol As New RolEntidad
            Dim LstRoles As List(Of RolEntidad) = Session("Roles")
            If GestorRol.Baja(LstRoles(DropdwnrolesElim.SelectedIndex)) Then
                'falta bitacora
                Me.alertvalid.Visible = False
                Me.lbl_success.InnerText = "Se ha eliminado el Rol satisfactoriamente."
                'poner traducción
                Me.success.Visible = True
            Else
                Me.alertvalid.Visible = True
                Me.lbl_textovalid.InnerText = "El Rol no se logró eliminar porque tiene un usuario asignado."
                'poner traducción
                Me.success.Visible = False
            End If
            ActualizarCampos()
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub DropdwnrolesElim_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropdwnrolesElim.SelectedIndexChanged
        Dim LstRoles As List(Of RolEntidad) = Session("Roles")
        Me.Lstperfilesactuales.Items.Clear()

    End Sub

    Protected Sub Btnaceptar_Click(sender As Object, e As EventArgs) Handles Btnaceptar.Click
        Dim LstRoles As List(Of RolEntidad) = Session("Roles")
        Dim Rol As RolEntidad = LstRoles(DropdwnrolesListar.SelectedIndex)
        Rol.Hijos.Clear()
        For Each item As ListItem In Lstperfilesactuales.Items
            Dim permiso As New PermisoBaseEntidad
            permiso.ID_Permiso = item.Value
            Rol.Hijos.Add(permiso)
        Next
        Dim GestorPermiso As New GestorPermisosBLL
        GestorPermiso.Modificar(Rol)
        'falta bitacora
        Me.alertvalid.Visible = False
        Me.lbl_success.InnerText = "Se ha modificador el Rol satisfactoriamente."
        'poner traducción
        Me.success.Visible = True
        ActualizarCampos()

    End Sub

    Protected Sub Btncancelar_Click(sender As Object, e As EventArgs) Handles Btncancelar.Click
        Me.Lstperfilesactuales.Items.Clear()
    End Sub
End Class