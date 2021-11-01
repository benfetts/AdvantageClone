Namespace Reporting.Database.Classes

    <Serializable>
    Public Class BillingApprovalReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            AccountExecutiveCode
            AEFirstName
            AELastName
            AEName
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            BillingApprovalID
            BillingBatchID
            ARInvoiceNumber
            ARInvoiceDate
            GroupOrder
            RecordType
            HeaderApprovalAmount
            HeaderApprovalComment
            HeaderClientComment
            FunctionCode
            FunctionDescription
            DetailApprovalID
            DetailApprovalAmount
            DetailApprovalComment
            DetailClientComment
        End Enum

#End Region

#Region " Variables "


#End Region

#Region " Properties "

        <Required>
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
        Public Property AccountExecutiveCode As String
        Public Property AEFirstName As String
        Public Property AELastName As String
        Public Property AEName As String

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

        Public Property JobNumber As Nullable(Of Integer)
        Public Property JobDescription As String

        Public Property JobComponentNumber As Nullable(Of Short)
        Public Property JobComponentDescription As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property BillingApprovalID As Nullable(Of Integer)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property BillingBatchID As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property ARInvoiceNumber As Nullable(Of Integer)
        Public Property ARInvoiceDate As Nullable(Of Date)
        Public Property GroupOrder As Nullable(Of Short)
        Public Property RecordType As String
        Public Property HeaderApprovalAmount As Nullable(Of Decimal)
        Public Property HeaderApprovalComment As String
        Public Property HeaderClientComment As String
        <MaxLength(6)>
        Public Property FunctionCode As String
        Public Property FunctionDescription As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property DetailApprovalID As Nullable(Of Integer)
        Public Property DetailApprovalAmount As Nullable(Of Decimal)
        Public Property DetailApprovalComment As String
        Public Property DetailClientComment As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
