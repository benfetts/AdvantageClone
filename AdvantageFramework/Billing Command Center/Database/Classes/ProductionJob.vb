Namespace BillingCommandCenter.Database.Classes

    <Serializable()>
    Public Class ProductionJob

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobNumber
            JobComponentNumber
            ClientCode
            DivisionCode
            ProductCode
            AdvanceBillingReconcileStatus
            ReconcilePendingAmount
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property JobNumber() As Nullable(Of Integer)

        Public Property JobComponentNumber() As Nullable(Of Short)

        Public Property ClientCode() As String

        Public Property DivisionCode() As String

        Public Property ProductCode() As String

        Public Property AdvanceBillingReconcileStatus() As Nullable(Of Short)

        Public Property ReconcilePendingAmount() As Nullable(Of Decimal)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.JobNumber.ToString

        End Function

#End Region

    End Class

End Namespace
