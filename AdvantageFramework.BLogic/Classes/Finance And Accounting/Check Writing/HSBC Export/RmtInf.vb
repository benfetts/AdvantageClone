Namespace Classes.FinanceAndAccounting.CheckWriting.HSBCExport

    <XmlRoot(ElementName:="RmtInf", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
    Public Class RmtInf

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <XmlElement(ElementName:="Strd", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property Strd As List(Of Strd)

#End Region

#Region " Methods "

        Public Sub New()

            Me.Strd = New List(Of Strd)

        End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
