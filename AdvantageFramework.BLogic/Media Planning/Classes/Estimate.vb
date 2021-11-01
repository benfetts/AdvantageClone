Namespace MediaPlanning.Classes

    Public Class Estimate

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            PlanID
            ID
            Estimate
            LockedBy
            CreatedBy
            CreatedDate
            ModifiedBy
            ModifiedDate
            FullOrdered
            PartialOrdered
            Ordered
            BudgetAmount
            DollarsAmount
            Commission
            AgencyFee
            BillableAmount
            BudgetVariance
            LastChangedByUser
            LastChangedDate
            SalesClassType
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property PlanID As Integer
        Public Property ID As Integer
        Public Property Estimate As String
        Public Property LockedBy As String
        Public Property CreatedBy As String
        Public Property CreatedDate As Date
        Public Property ModifiedBy As String
        Public Property ModifiedDate As Nullable(Of Date)
        Public Property FullOrdered As Boolean
        Public Property PartialOrdered As Boolean
        Public Property Ordered As Integer
        Public Property BudgetAmount As Decimal
        Public Property DollarsAmount As Decimal
        Public Property NetCharge As Decimal
        Public Property Commission As Decimal
        Public Property AgencyFee As Decimal
        Public Property BillableAmount As Decimal
        Public Property BudgetVariance As Decimal
        Public Property LastChangedByUser As String
        Public Property LastChangedDate As String
        Public Property SalesClassType As String

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
