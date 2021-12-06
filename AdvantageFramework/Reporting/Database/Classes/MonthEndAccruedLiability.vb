Namespace Reporting.Database.Classes

    <Serializable>
    Public Class MonthEndAccruedLiability

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OfficeCode
            OfficeName
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            SalesClassCode
            SalesClassDescription
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            FunctionCode
            FunctionDesc
            GLAccoountCode
            GLAccountDescription
            RecordType
            ARPostingPeriod
            ARInvoiceDate
            ARInvoiceNumber
            ARType
            AccruedLiabilityAmount
            APInvoiceAmount
            APLimitedJobFlag
            AccruedLiabilityAmountFunction
        End Enum

#End Region

#Region " Variables "


#End Region

#Region " Properties "

        <Required>
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
        <MaxLength(4)>
        Public Property OfficeCode() As String
        <MaxLength(30)>
        Public Property OfficeName() As String
        '<System.Runtime.Serialization.DataMemberAttribute(),
        'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        'Public Property CDPSortCode() As String
        <MaxLength(6)>
        Public Property ClientCode() As String
        <MaxLength(40)>
        Public Property ClientName() As String
        <MaxLength(6)>
        Public Property DivisionCode() As String
        <MaxLength(40)>
        Public Property DivisionName() As String
        <MaxLength(6)>
        Public Property ProductCode As String
        <MaxLength(40)>
        Public Property ProductDescription As String
        <MaxLength(6)>
        Public Property SalesClassCode As String
        <MaxLength(30)>
        Public Property SalesClassDescription As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property JobNumber As Nullable(Of Integer)
        Public Property JobDescription As String

        Public Property JobComponentNumber As Nullable(Of Short)
        Public Property JobComponentDescription As String

        <MaxLength(6)>
        Public Property FunctionCode As String
        <MaxLength(30)>
        Public Property FunctionDescription As String

        Public Property GLAccoountCode As String
        Public Property GLAccountDesc As String
        Public Property RecordType As String

        Public Property ARPostingPeriod As String
        Public Property ARInvoiceDate As Nullable(Of Date)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property ARInvoiceNumber As Nullable(Of Integer)

        <MaxLength(6)>
        Public Property ARType As String
        Public Property AccruedLiabilityAmount As Nullable(Of Decimal)
        Public Property APInvoiceAmount As Nullable(Of Decimal)
        Public Property APLimitedJobFlag As Nullable(Of Byte)

        Public Property AccruedLiabilityAmountFunction As Nullable(Of Decimal)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
