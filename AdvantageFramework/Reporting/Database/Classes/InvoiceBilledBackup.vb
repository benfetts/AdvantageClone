Namespace Reporting.Database.Classes

    <Serializable>
    Public Class InvoiceBilledBackup

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            TypeCode
            ARInvoiceNumber
            LineNumber
            InvoiceDate
            DueDate
            VendorCode
            VendorName
            FunctionCode
            FunctionDescription
            InvoiceNumber
            Amount
            InvoiceDateShort
            JobNumber
            JobComponentNbr
            ARInvoicePaid
            DateARPaid
        End Enum

#End Region

#Region " Variables "


#End Region

#Region " Properties "

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
        Public Property TypeCode As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property ARInvoiceNumber As Nullable(Of Integer)
        Public Property LineNumber As Nullable(Of Long)
        Public Property InvoiceDate As Nullable(Of Date)
        Public Property DueDate As Nullable(Of Date)
        <MaxLength(6)>
        Public Property VendorCode As String
        <MaxLength(40)>
        Public Property VendorName As String
        <MaxLength(6)>
        Public Property FunctionCode As String
        <MaxLength(40)>
        Public Property FunctionDescription As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property InvoiceNumber As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Amount As Nullable(Of Decimal)
        Public Property InvoiceDateShort As String
        Public Property JobNumber As Nullable(Of Integer)
        Public Property JobComponentNbr As Nullable(Of Short)
        Public Property ARInvoicePaid As String
        Public Property DateARPaid As Nullable(Of Date)



#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCode.ToString

        End Function

#End Region

    End Class

End Namespace
