﻿Namespace Classes.FinanceAndAccounting.CheckWriting.WellsFargoExport

    <XmlRoot(ElementName:="RejectedB2P")>
    Public Class RejectedB2P

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <XmlElement(ElementName:="TranACK")>
        Public Property TranACK As TranACK
        <XmlElement(ElementName:="PmtTypeCount")>
        Public Property PmtTypeCount As String
        <XmlElement(ElementName:="PmtTypeAmt")>
        Public Property PmtTypeAmt As String
        <XmlAttribute(AttributeName:="PmtStatus")>
        Public Property PmtStatus As String
        <XmlAttribute(AttributeName:="PmtType")>
        Public Property PmtType As String
        <XmlAttribute(AttributeName:="PrcDate")>
        Public Property PrcDate As String


#End Region

#Region " Methods "

        Public Sub New()

            Me.TranACK = New TranACK

        End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
