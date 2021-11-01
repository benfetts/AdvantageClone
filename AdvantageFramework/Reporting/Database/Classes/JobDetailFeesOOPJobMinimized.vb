Namespace Reporting.Database.Classes

    <Serializable>
    Public Class JobDetailFeesOOPJobMinimized

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            JobNumber
            OfficeCode
            OfficeDescription
            ClientCode
            ClientDescription
            DivisionCode
            DivisionDescription
            ProductCode
            ProductDescription
            SalesClassCode
            SalesClassDescription
            JobDescription
            FeeEstimate
            OOPEstimate
            BillableFeeTotal
            BillableOOPTotal
            BillableTotal
        End Enum

#End Region

#Region " Variables "


#End Region

#Region " Properties "

        <Required>
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
        Public Property JobNumber() As Nullable(Of Integer)
        <MaxLength(4)>
        Public Property OfficeCode() As String
        <MaxLength(30)>
        Public Property OfficeDescription() As String
        <MaxLength(6)>
        Public Property ClientCode() As String
        <MaxLength(40)>
        Public Property ClientDescription() As String
        <MaxLength(6)>
        Public Property DivisionCode() As String
        <MaxLength(40)>
        Public Property DivisionDescription() As String
        <MaxLength(6)>
        Public Property ProductCode As String
        <MaxLength(40)>
        Public Property ProductDescription As String
        <MaxLength(6)>
        Public Property SalesClassCode As String
        <MaxLength(30)>
        Public Property SalesClassDescription As String
        <MaxLength(60)>
        Public Property JobDescription As String
        Public Property FeeEstimate As Nullable(Of Decimal)
        Public Property OOPEstimate As Nullable(Of Decimal)
        Public Property BillableFeeTotal As Nullable(Of Decimal)
        Public Property BillableOOPTotal As Nullable(Of Decimal)
        Public Property BillableTotal As Nullable(Of Decimal)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
