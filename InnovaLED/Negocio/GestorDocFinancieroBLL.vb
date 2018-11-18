Imports Mapper
Imports Entidades



Public Class GestorDocFinancieroBLL

    Private documentoMPP As New DocumentoFinancieroMPP

    Public Function TraerDocumentoF(ByVal usu As UsuarioEntidad) As List(Of DocumentoFinancieroEntidad)
        Return documentoMPP.TraerDocumentoF(usu)

    End Function


    Public Function Alta(ByVal nota As DocumentoFinancieroEntidad) As Boolean
        Return documentoMPP.Alta(nota)
    End Function

    Public Function Eliminar(ByVal nota As List(Of DocumentoFinancieroEntidad)) As Boolean
        Return documentoMPP.Eliminar(nota)
    End Function








End Class
