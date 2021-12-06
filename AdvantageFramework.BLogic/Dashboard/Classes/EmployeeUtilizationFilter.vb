Namespace Dashboard.Classes

    <Serializable()>
    Public Class EmployeeUtilizationFilter

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            UserCode
            FromMonth
            FromYear
            ToMonth
            ToYear
            EmployeeCode
            DepartmentCode
            StartDate
            EndDate
            Page

        End Enum

        ''TEMP
        'Public Enum InboxTypes

        '    inbox = 1
        '    dismissed = 2
        '    all = 3
        '    drafts = 4

        'End Enum
        'Public Enum ShowAssignmentTypes

        '    myalertsandassignments ' (for job inbox, this shows ALL alerts & assignments)
        '    myalerts
        '    myalertassignments ' (for job inbox, this shows all alerts)
        '    myreviews
        '    allalertassignments
        '    unassigned

        'End Enum


#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property UserCode As String = String.Empty
        Public Property FromMonth As Integer?
        Public Property FromYear As Integer?
        Public Property ToMonth As Integer?
        Public Property ToYear As Integer?
        Public Property EmployeeCode As String = String.Empty
        Public Property DepartmentCode As String = String.Empty
        Public Property StartDate As Date
        Public Property EndDate As Date
        Public Property Page As String = String.Empty



#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace
