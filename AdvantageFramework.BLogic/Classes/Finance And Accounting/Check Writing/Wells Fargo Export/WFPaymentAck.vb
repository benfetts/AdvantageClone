Namespace Classes.FinanceAndAccounting.CheckWriting.WellsFargoExport

    <XmlRoot(ElementName:="WFPaymentAck")>
    Public Class WFPaymentAck

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <XmlElement(ElementName:="AcceptedUSDWire")>
        Public Property AcceptedUSDWire As AcceptedUSDWire
        <XmlElement(ElementName:="AcceptedDomACH")>
        Public Property AcceptedDomACH As AcceptedDomACH
        <XmlElement(ElementName:="AcceptedChecksWithValidEPData")>
        Public Property AcceptedChecksWithValidEPData As AcceptedChecksWithValidEPData
        <XmlElement(ElementName:="AcceptedChecksWithInvalidEPData")>
        Public Property AcceptedChecksWithInvalidEPData As AcceptedChecksWithInvalidEPData
        <XmlElement(ElementName:="AcceptedB2P")>
        Public Property AcceptedB2P As AcceptedB2P
        <XmlElement(ElementName:="RejectedDomACH")>
        Public Property RejectedDomACH As RejectedDomACH
        <XmlElement(ElementName:="RejectedB2P")>
        Public Property RejectedB2P As RejectedB2P
        <XmlElement(ElementName:="PrcTime")>
        Public Property PrcTime As String
        <XmlElement(ElementName:="PrcDate")>
        Public Property PrcDate As String
        <XmlElement(ElementName:="FileDate")>
        Public Property FileDate As String
        <XmlElement(ElementName:="FileTime")>
        Public Property FileTime As String
        <XmlElement(ElementName:="FileControl")>
        Public Property FileControl As String
        <XmlElement(ElementName:="FileTranCount")>
        Public Property FileTranCount As String
        <XmlElement(ElementName:="FileTranTotal")>
        Public Property FileTranTotal As String
        <XmlElement(ElementName:="FileAcceptCount")>
        Public Property FileAcceptCount As String
        <XmlElement(ElementName:="FileAcceptTotal")>
        Public Property FileAcceptTotal As String
        <XmlElement(ElementName:="FileRejectCount")>
        Public Property FileRejectCount As String
        <XmlElement(ElementName:="FileRejectTotal")>
        Public Property FileRejectTotal As String
        <XmlAttribute(AttributeName:="PmtTypeACKCount")>
        Public Property PmtTypeACKCount As String
        <XmlAttribute(AttributeName:="DocumentType")>
        Public Property DocumentType As String
        <XmlAttribute(AttributeName:="CompanyID")>
        Public Property CompanyID As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.AcceptedUSDWire = New AcceptedUSDWire
            Me.AcceptedDomACH = New AcceptedDomACH
            Me.AcceptedChecksWithValidEPData = New AcceptedChecksWithValidEPData
            Me.AcceptedChecksWithInvalidEPData = New AcceptedChecksWithInvalidEPData
            Me.AcceptedB2P = New AcceptedB2P
            Me.RejectedDomACH = New RejectedDomACH
            Me.RejectedB2P = New RejectedB2P

        End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
