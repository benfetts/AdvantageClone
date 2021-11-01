Namespace AlertSystem.Classes

    <Serializable()>
    Public Class AlertsAndAssignmentsManagerJobDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            JobNumber
            JobComponentNumber
            TaskSequenceNumber

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property JobNumber As Integer
        Public Property JobComponentNumber As Integer
        Public Property TaskSequenceNumber As Integer

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace

