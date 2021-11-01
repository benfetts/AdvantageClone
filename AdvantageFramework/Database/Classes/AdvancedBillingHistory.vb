Namespace Database.Classes

    <Serializable()>
    Public Class AdvancedBillingHistory

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobNumber
            JobComponentNumber
            ARInvoiceNumber
            ARType
            TotalAmount
            TotalBilledAmount
            InterimRec
            InterimFlag
            AdvancedType
            BillTypeCode
            BillTypeDescription
            BillTypeSort
            DatePaid
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property JobNumber() As Nullable(Of Integer)

        Public Property JobComponentNumber() As Nullable(Of Short)

        Public Property ARInvoiceNumber() As Nullable(Of Integer)

        Public Property ARType() As String

        Public Property TotalAmount() As Nullable(Of Decimal)

        Public Property TotalBilledAmount() As Nullable(Of Decimal)

        Public Property InterimRec() As Nullable(Of Byte)

        Public Property InterimFlag() As String

        Public Property AdvancedType() As Nullable(Of Byte)

        Public Property BillTypeCode() As String

        Public Property BillTypeDescription() As String

        Public Property BillTypeSort() As Nullable(Of Byte)

        Public Property DatePaid() As Nullable(Of Date)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.JobNumber

        End Function

#End Region

    End Class

End Namespace
