Namespace Classes.FinanceAndAccounting.CheckWriting.HSBCExport

    <XmlRoot(ElementName:="DbtrAgt", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
    Public Class DbtrAgt

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <XmlElement(ElementName:="FinInstnId", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property FinInstnId As FinInstnId

#End Region

#Region " Methods "

        Public Sub New()

            Me.FinInstnId = New FinInstnId

        End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
