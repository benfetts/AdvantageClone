Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class CoverSheet

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            InvoiceNumber
            InvoiceSequenceNumber
            InvoiceDate
            InvoiceType
            FullInvoiceNumber
            InvoiceAmount
            InvoiceDescription
            InvoiceClassification
            RecordType
            RecordTypeDescription
            ClientCode
            DivisionCode
            ProductCode
            Address
            LocationCode
            PageHeaderComment
            PageFooterComment
            PageHeaderLogoPath
            PageHeaderLogoPathLandscape
            PageFooterLogoPath
            PageFooterLogoPathLandscape
            SortOrder
            JobNumber
            JobDescription
            ClientPO
            FooterComment
            ShowPageHeaderLogo
            ShowPageFooterLogo
        End Enum

#End Region

#Region " Variables "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceNumber As Integer = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceSequenceNumber As Short = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceDate As Nullable(Of Date) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceType As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FullInvoiceNumber As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceAmount As Decimal = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceDescription As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceClassification As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RecordType As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RecordTypeDescription As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionCode As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductCode As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Address As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LocationCode() As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageHeaderComment() As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageFooterComment() As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageHeaderLogoPath() As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageHeaderLogoPathLandscape() As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageFooterLogoPath() As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageFooterLogoPathLandscape() As String = Nothing
        Public Property SortOrder As Integer
        Public Property JobNumber() As String
        Public Property JobDescription() As String
        Public Property ClientPO() As String
        Public Property FooterComment() As String
        Public Property ShowPageHeaderLogo() As Boolean
        Public Property ShowPageFooterLogo() As Boolean

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.InvoiceNumber

        End Function

#End Region

    End Class

End Namespace
