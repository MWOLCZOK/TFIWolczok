Imports Entidades
Imports Mapper
Imports System.Web.HttpContext


Public Class HistorialBLL

    Public Function ListarPorCliente(ByVal cliente As UsuarioEntidad) As List(Of HistorialEntidad)

        Dim lstResult As New List(Of HistorialEntidad)


        Dim listaFacturas As New List(Of FacturaEntidad)
        Dim GestorFacturas As New GestorFacturaBLL
        listaFacturas = GestorFacturas.TraerFacturasGestionPorUsuario(cliente)

        Dim listaNotasCre As New List(Of DocumentoFinancieroEntidad)
        Dim GestorNotasCre As New GestorDocFinancieroBLL
        listaNotasCre = GestorNotasCre.TraerDocumentoF(cliente)

        For Each oFactu In listaFacturas
            Dim oHisto As New HistorialEntidad
            oHisto.NroDoc = oFactu.ID
            oHisto.FechaEmision = oFactu.Fecha
            oHisto.Documento = "Factura"
            oHisto.Estado = oFactu.EstadoCompra.ToString
            oHisto.Descripcion = oFactu.FormaDePago
            oHisto.Debe = oFactu.MontoTotal

            lstResult.Add(oHisto)
        Next

        For Each oNC In listaNotasCre
            Dim oHisto As New HistorialEntidad
            oHisto.NroDoc = oNC.ID
            oHisto.FechaEmision = oNC.Fecha_Emision
            oHisto.Documento = "Nota de Crédito"
            oHisto.Estado = "Aprobada"
            If oNC.Descripcion.StartsWith("Nota de Credito generada en") Then
                oHisto.Descripcion = oNC.Descripcion
            Else
                oHisto.Descripcion = oNC.Descripcion & "Nro Fact: " & oNC.Factura.ID
            End If

            oHisto.Haber = oNC.Monto

            lstResult.Add(oHisto)
        Next

        Return lstResult.OrderByDescending(Function(x) x.FechaEmision).ToList

    End Function



End Class
