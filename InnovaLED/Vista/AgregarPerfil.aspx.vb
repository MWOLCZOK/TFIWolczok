Public Class AgregarPerfil1
    Inherits System.Web.UI.Page

    Protected mensajeConfirmacion As String

    Dim _gestorpermiso As New Negocio.GestorPermisosBLL
    Private _listapermisos As List(Of Entidades.PermisoBaseEntidad)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cargar()
        If Not IsPostBack Then
            Me.CargarGridView()
        End If


    End Sub



    Public Sub Cargar()
        Try
            _listapermisos = _gestorpermiso.ListarPermisos()
        Catch ex As Negocio.ExceptionPermisoNoExiste
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Message
        Catch ex As Exception
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Message
        End Try
    End Sub

    Private Sub CargarGridView()
        Me.gv_Perfiles.DataSource = _listapermisos
        Me.gv_Perfiles.DataBind()
        Me.gv_Perfiles.Columns(0).Visible = False
    End Sub





End Class