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
    '''Control txt_rtas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_rtas As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control btn_agregarrta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_agregarrta As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control gv_respuestas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents gv_respuestas As Global.System.Web.UI.WebControls.GridView
    
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
    '''Control btn_confirmar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_confirmar As Global.System.Web.UI.HtmlControls.HtmlButton
    
    '''<summary>
    '''Control btneliminar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btneliminar As Global.System.Web.UI.WebControls.Button
    
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
    '''Control Label1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Label1 As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control encuestas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents encuestas As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control btn_buscar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_buscar As Global.System.Web.UI.WebControls.Button
    
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
    '''Control ID_encuesta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ID_encuesta As Global.System.Web.UI.WebControls.HiddenField
End Class
