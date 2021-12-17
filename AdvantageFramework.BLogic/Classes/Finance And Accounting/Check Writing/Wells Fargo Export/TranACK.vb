Namespace Classes.FinanceAndAccounting.CheckWriting.WellsFargoExport

    <XmlRoot(ElementName:="TranACK")>
    Public Class TranACK

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <XmlElement(ElementName:="PmtID")>
        Public Property PmtID As String
        <XmlElement(ElementName:="Name1")>
        Public Property Name1 As String
        <XmlElement(ElementName:="ValueDate")>
        Public Property ValueDate As String
        <XmlElement(ElementName:="CurAmt")>
        Public Property CurAmt As String
        <XmlElement(ElementName:="CurCode")>
        Public Property CurCode As String
        <XmlAttribute(AttributeName:="PrcDate")>
        Public Property PrcDate As String
        <XmlAttribute(AttributeName:="TranNum")>
        Public Property TranNum As String
        <XmlElement(ElementName:="Error")>
        Public Property [Error] As List(Of String)


#End Region

#Region " Methods "

        Public Sub New()

            Me.Error = New List(Of String)

        End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
