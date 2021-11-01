Namespace Database.Classes

    <Serializable()>
    Public Class TimesheetEstimate

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobNumber
            JobComponentNumber
            EstimateNumber
            EstimateLogDescription
            EstimateComponentNumber
            EstimateComponentDescription
            EstimateQuoteNumber
            EstimateRevisionNumber
            FunctionCode
            EstimateRevisionSuppliedByCode
            TotalEstimateQuantity
            EstimateAmount
            Contingency
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property JobNumber() As Integer

        Public Property JobComponentNumber() As Short

        Public Property EstimateNumber() As Integer

        Public Property EstimateLogDescription() As String

        Public Property EstimateComponentNumber() As Short

        Public Property EstimateComponentDescription() As String

        Public Property EstimateQuoteNumber() As Short

        Public Property EstimateRevisionNumber() As Short

        Public Property FunctionCode() As String

        Public Property EstimateRevisionSuppliedByCode() As String

        Public Property TotalEstimateQuantity() As Decimal

        Public Property EstimateAmount() As Nullable(Of Decimal)

        Public Property Contingency() As Nullable(Of Decimal)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.JobNumber.ToString

        End Function

#End Region

    End Class

End Namespace
