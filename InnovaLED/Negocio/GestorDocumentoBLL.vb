Imports Mapper
Imports Entidades



Public Class GestorDocumentoBLL

    Private documentoMPP As New GestorDocumentoMPP

    Public Function TraerDocumentoF(ByVal usu As UsuarioEntidad) As List(Of DocumentoFinancieroEntidad)
        Return documentoMPP.TraerDocumentoF(usu)

    End Function








End Class
