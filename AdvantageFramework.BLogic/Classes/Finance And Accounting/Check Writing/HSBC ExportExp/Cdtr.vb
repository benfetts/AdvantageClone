Namespace Classes.FinanceAndAccounting.CheckWriting.HSBCExportExp

    <XmlRoot(ElementName:="Cdtr", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
    Public Class Cdtr

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <XmlElement(ElementName:="Nm", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property Nm As String
        <XmlElement(ElementName:="PstlAdr", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property PstlAdr As PstlAdr

#End Region

#Region " Methods "

        Public Sub New()

            Me.PstlAdr = New PstlAdr

        End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
