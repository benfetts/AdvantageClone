﻿Namespace Classes.FinanceAndAccounting.CheckWriting.HSBCExportExp

    <XmlRoot(ElementName:="CstmrCdtTrfInitn", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
    Public Class CstmrCdtTrfInitn

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <XmlElement(ElementName:="GrpHdr", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property GrpHdr As GrpHdr
        <XmlElement(ElementName:="PmtInf", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property PmtInf As List(Of PmtInf)

#End Region

#Region " Methods "

        Public Sub New()

            Me.GrpHdr = New GrpHdr
            Me.PmtInf = New List(Of PmtInf)

        End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
