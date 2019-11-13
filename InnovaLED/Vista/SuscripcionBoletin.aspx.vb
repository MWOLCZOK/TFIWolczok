Imports Negocio
Imports Entidades
Public Class SuscripcionBoletin
    Inherits System.Web.UI.Page

    Dim boletinBLL As New BoletinBLL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            obtenerTipodeBoletin()
            Ocultamiento()
        End If
    End Sub


    Private Sub obtenerTipodeBoletin()
        Try
            For Each miTipoBoletin As Entidades.TipoBoletin In [Enum].GetValues(GetType(Entidades.TipoBoletin))
                Dim _treeNode As New TreeNode
                _treeNode.Value = miTipoBoletin.ToString
                Me.tv_TipoBoletin.Nodes.Add(_treeNode)
            Next
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Response.Redirect("Default.aspx")
    End Sub


    Protected Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        Try
            If validarListaTipoBoletin() Then
                Dim _gestorBoletin As New Negocio.BoletinBLL
                Dim _mail As String = Me.txt_correo.Text

                Dim _listasuscripcion As New List(Of Entidades.TipoBoletin)
                    For Each _nodo As TreeNode In tv_TipoBoletin.CheckedNodes
                        Dim _tipoBoletin As Entidades.TipoBoletin = [Enum].Parse(GetType(Entidades.TipoBoletin), _nodo.Text, True)
                        _listasuscripcion.Add(_tipoBoletin)
                    Next
                _gestorBoletin.inscripbirseBoletin(_mail, _listasuscripcion)
                Me.success.Visible = True
                Me.success.InnerText = "Se ha suscripto satisfactoriamente, muchas gracias!! Será redireccionado al Home."
                Me.alertvalid.Visible = False
                Response.AddHeader("REFRESH", "5;URL=Default.aspx")
            Else
                Me.success.Visible = False
                Me.alertvalid.Visible = True
                Me.alertvalid.InnerText = "Debe ingresar al menos una opción para continuar"
            End If


        Catch ex As Exception

        End Try
    End Sub


    Private Function validarListaTipoBoletin() As Boolean
        Try
            Dim flagNodo As Boolean = False
            For Each _node As TreeNode In Me.tv_TipoBoletin.Nodes
                If _node.Checked = True Then
                    flagNodo = True
                End If
            Next
            If flagNodo = False Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
        End Try

    End Function

    Public Sub Ocultamiento()
        Baja_Suscrip.Visible = False

    End Sub

    Protected Sub btn_bajasuscrip1_Click(sender As Object, e As EventArgs) Handles btn_bajasuscrip1.Click
        Suscrip.Visible = False
        Baja_Suscrip.Visible = True
        Row_BajaSuscripcion_labelyboton.Visible = False
        Row_BajaSuscripcion_labelyboton2.Visible = False
    End Sub

    Protected Sub btn_bajasus_Click(sender As Object, e As EventArgs) Handles btn_bajasus.Click
        Try
            Dim mail As String
            mail = TxtCorreoBaja.Text

            If boletinBLL.DesincribirBoletin(mail) Then
                Me.success.Visible = True
                Me.success.InnerText = "Se ha dado de baja de la suscripción satisfactoriamente, será redireccionado al Home."
                Me.alertvalid.Visible = False
                Response.AddHeader("REFRESH", "5;URL=Default.aspx")
            Else
                Me.alertvalid.Visible = True
                Me.alertvalid.InnerText = "El correo ingresado no está suscripto. Verifique."
                Me.success.Visible = False
            End If


        Catch ex As Exception

        End Try

    End Sub


End Class