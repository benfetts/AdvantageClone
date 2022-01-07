Namespace Classes.FinanceAndAccounting.CheckWriting.HSBCExportExp

    <XmlRoot(ElementName:="PmtInf", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
    Public Class PmtInf

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <XmlElement(ElementName:="PmtInfId", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property PmtInfId As String
        <XmlElement(ElementName:="PmtMtd", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property PmtMtd As String
        <XmlElement(ElementName:="NbOfTxs", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property NbOfTxs As String
        <XmlElement(ElementName:="CtrlSum", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property CtrlSum As String
        <XmlElement(ElementName:="PmtTpInf", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property PmtTpInf As PmtTpInf
        <XmlElement(ElementName:="ReqdExctnDt", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property ReqdExctnDt As String
        <XmlElement(ElementName:="Dbtr", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property Dbtr As Dbtr
        <XmlElement(ElementName:="DbtrAcct", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property DbtrAcct As DbtrAcct
        <XmlElement(ElementName:="DbtrAgt", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property DbtrAgt As DbtrAgt
        <XmlElement(ElementName:="CdtTrfTxInf", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property CdtTrfTxInf As CdtTrfTxInf

#End Region

#Region " Methods "

        Public Sub New()

            Me.PmtTpInf = New PmtTpInf
            Me.Dbtr = New Dbtr
            Me.DbtrAcct = New DbtrAcct
            Me.DbtrAgt = New DbtrAgt
            Me.CdtTrfTxInf = New CdtTrfTxInf

        End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
