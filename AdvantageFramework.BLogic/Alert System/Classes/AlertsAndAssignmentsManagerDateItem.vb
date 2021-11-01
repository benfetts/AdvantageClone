Namespace AlertSystem.Classes

    <Serializable()>
    Public Class AlertsAndAssignmentsManagerDateItem

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            DateDifference
            IsWeekendDate

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property DateDifference As Integer? = 0
        Public Property IsWeekendDate As Integer? = 0

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace
