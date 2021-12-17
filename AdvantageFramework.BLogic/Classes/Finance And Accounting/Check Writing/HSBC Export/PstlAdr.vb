Namespace Classes.FinanceAndAccounting.CheckWriting.HSBCExport

    <XmlRoot(ElementName:="PstlAdr", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
    Public Class PstlAdr

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <XmlElement(ElementName:="StrtNm", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property StrtNm As String
        <XmlElement(ElementName:="PstCd", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property PstCd As String
        <XmlElement(ElementName:="TwnNm", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property TwnNm As String
        <XmlElement(ElementName:="CtrySubDvsn", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property CtrySubDvsn As String
        <XmlElement(ElementName:="Ctry", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property Ctry As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
