Namespace Classes.FinanceAndAccounting.CheckWriting.HSBCExport

    <XmlRoot(ElementName:="CdtTrfTxInf", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
    Public Class CdtTrfTxInf

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <XmlElement(ElementName:="PmtId", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property PmtId As PmtId
        <XmlElement(ElementName:="Amt", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property Amt As Amt
        <XmlElement(ElementName:="ChqInstr", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property ChqInstr As ChqInstr
        <XmlElement(ElementName:="Cdtr", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property Cdtr As Cdtr
        <XmlElement(ElementName:="RmtInf", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property RmtInf As RmtInf

#End Region

#Region " Methods "

        Public Sub New()

            Me.PmtId = New PmtId
            Me.Amt = New Amt
            Me.ChqInstr = New ChqInstr
            Me.Cdtr = New Cdtr
            Me.RmtInf = New RmtInf

        End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
