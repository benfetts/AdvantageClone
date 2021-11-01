Namespace AlertSystem.Classes

    <Serializable()>
    Public Class AlertsAndAssignmentsManagerGridColumnUpdates

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ColumnName
            ColumnID
            ColumnWidth

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ColumnName As String = String.Empty
        Public Property ColumnID As Integer?
        Public Property ColumnWidth As Integer?

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace

