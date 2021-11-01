Namespace MediaPlanning.Classes

    Public Class OrderNumberSearchResult

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            PlanID
            EstimateID
            OrderNumber
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property PlanID As Integer
        Public Property EstimateID As Integer
        Public Property OrderNumber As Integer

#End Region

#Region " Methods "

        Public Sub New()

            Me.PlanID = 0
            Me.EstimateID = 0
            Me.OrderNumber = 0

        End Sub

#End Region

    End Class

End Namespace
