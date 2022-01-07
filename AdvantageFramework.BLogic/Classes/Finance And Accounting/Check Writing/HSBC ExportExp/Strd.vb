Namespace Classes.FinanceAndAccounting.CheckWriting.HSBCExportExp

    <XmlRoot(ElementName:="Strd", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
    Public Class Strd

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <XmlElement(ElementName:="RfrdDocInf", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property RfrdDocInf As RfrdDocInf
        <XmlElement(ElementName:="RfrdDocAmt", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property RfrdDocAmt As RfrdDocAmt

#End Region

#Region " Methods "

        Public Sub New()

            Me.RfrdDocInf = New RfrdDocInf
            Me.RfrdDocAmt = New RfrdDocAmt

        End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
