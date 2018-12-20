'------------------------------------------------------------------------------
' <generado automáticamente>
'     Este código fue generado por una herramienta.
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código. 
' </generado automáticamente>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class GestionarEncuestas

    '''<summary>
    '''Control alertvalid.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents alertvalid As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control textovalid.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents textovalid As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control success.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents success As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control lblPanelModUser.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblPanelModUser As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control lbl_Nombrepregunta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Nombrepregunta As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control txt_Nombrepregunta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_Nombrepregunta As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control RequiredFieldValidator1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents RequiredFieldValidator1 As Global.System.Web.UI.WebControls.RequiredFieldValidator

    '''<summary>
    '''Control Lbl_tipopreg.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_tipopreg As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control ddl_tipopregunta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_tipopregunta As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control lbl_FechaFinVigencia2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_FechaFinVigencia2 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control datepicker.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents datepicker As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control Lbl_rtas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_rtas As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control Div_Encuesta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Div_Encuesta As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control Lbl_muybueno.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_muybueno As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control Lbl_bueno.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_bueno As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control Lbl_regular.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_regular As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control Lbl_malo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_malo As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control Lbl_muymalo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_muymalo As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control Div_Opinion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Div_Opinion As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control Lbl_SI.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_SI As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control Lbl_NO.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_NO As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control Lbl_Quizas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Quizas As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control btn_nuevo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_nuevo As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control btn_agregar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_agregar As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control btn_modificar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_modificar As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control btn_eliminar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_eliminar As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control gv_Encuestas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents gv_Encuestas As Global.System.Web.UI.WebControls.GridView

    '''<summary>
    '''Control cab_EstadisticasSatisfaccion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cab_EstadisticasSatisfaccion As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control Lbl_mesdetalle.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_mesdetalle As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control ddl_Mes.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_Mes As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control Lbl_añodetalle.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_añodetalle As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control ddl_Ano.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_Ano As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control btn_buscar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_buscar As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control lbl_Valores.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Valores As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control lbl_Satisfecho.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Satisfecho As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control valor_satisfecho.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents valor_satisfecho As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control lbl_insatisfecho.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_insatisfecho As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control valor_insatisfecho.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents valor_insatisfecho As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control cab_EstadisticasEncuestas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cab_EstadisticasEncuestas As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control ddl_PreguntaEncuesta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_PreguntaEncuesta As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control Lbl_Valores_FO.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Valores_FO As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control lbl_Si2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Si2 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control valor_Si.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents valor_Si As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control Lbl_No2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_No2 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control valor_No.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents valor_No As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control Lbl_Quizas2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Quizas2 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control valor_Quizas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents valor_Quizas As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control ID_encuesta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ID_encuesta As Global.System.Web.UI.WebControls.HiddenField
End Class
