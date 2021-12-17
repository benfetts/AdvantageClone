Namespace Classes.FinanceAndAccounting.CheckWriting.HSBCExport

    <XmlRoot(ElementName:="FinInstnId", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
    Public Class FinInstnId

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <XmlElement(ElementName:="BIC", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property BIC As String
        <XmlElement(ElementName:="ClrSysMmbId", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property ClrSysMmbId As ClrSysMmbId
        <XmlElement(ElementName:="Nm", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property Nm As String
        <XmlElement(ElementName:="PstlAdr", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property PstlAdr As PstlAdr

#End Region

#Region " Methods "

        Public Sub New()

            Me.ClrSysMmbId = New ClrSysMmbId
            Me.PstlAdr = New PstlAdr

        End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
