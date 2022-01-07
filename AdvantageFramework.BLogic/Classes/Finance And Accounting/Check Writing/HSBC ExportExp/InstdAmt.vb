Namespace Classes.FinanceAndAccounting.CheckWriting.HSBCExportExp

    <XmlRoot(ElementName:="InstdAmt", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
    Public Class InstdAmt

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <XmlAttribute(AttributeName:="Ccy")>
        Public Property Ccy As String
        <XmlText>
        Public Property Text As String

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
