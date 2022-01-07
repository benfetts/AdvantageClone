Namespace Classes.FinanceAndAccounting.CheckWriting.HSBCExportExp

    <XmlRoot(ElementName:="Amt", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
    Public Class Amt

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <XmlElement(ElementName:="InstdAmt", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property InstdAmt As InstdAmt

#End Region

#Region " Methods "

        Public Sub New()

            Me.InstdAmt = New InstdAmt

        End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
