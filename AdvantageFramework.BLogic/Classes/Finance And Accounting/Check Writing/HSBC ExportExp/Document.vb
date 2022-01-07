Namespace Classes.FinanceAndAccounting.CheckWriting.HSBCExportExp

    <XmlRoot(ElementName:="Document", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
    Public Class Document

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <XmlElement(ElementName:="CstmrCdtTrfInitn", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property CstmrCdtTrfInitn As CstmrCdtTrfInitn
        '<XmlAttribute(AttributeName:="xmlns")>
        'Public Property Xmlns As String
        '<XmlAttribute(AttributeName:="xsi", [Namespace]:="http://www.w3.org/2000/xmlns/")>
        'Public Property Xsi As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.CstmrCdtTrfInitn = New CstmrCdtTrfInitn

        End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
