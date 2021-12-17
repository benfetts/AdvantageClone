Namespace Classes.FinanceAndAccounting.CheckWriting.HSBCExport

    <XmlRoot(ElementName:="GrpHdr", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
    Public Class GrpHdr

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <XmlElement(ElementName:="MsgId", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property MsgId As String
        <XmlElement(ElementName:="CreDtTm", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property CreDtTm As String
        <XmlElement(ElementName:="Authstn", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property Authstn As Authstn
        <XmlElement(ElementName:="NbOfTxs", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property NbOfTxs As String
        <XmlElement(ElementName:="CtrlSum", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property CtrlSum As String
        <XmlElement(ElementName:="InitgPty", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property InitgPty As InitgPty

#End Region

#Region " Methods "

        Public Sub New()

            Me.Authstn = New Authstn
            Me.InitgPty = New InitgPty

        End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
