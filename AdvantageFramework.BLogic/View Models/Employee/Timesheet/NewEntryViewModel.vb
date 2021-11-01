Imports AdvantageFramework.Timesheet.Methods

Namespace ViewModels.Employee.Timesheet

    <Serializable()>
    Public Class NewEntryViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Jobs As Generic.List(Of AdvantageFramework.ViewModels.Lookup.LookupViewModel) = Nothing
        Public Property FunctionCategories As Generic.List(Of FunctionCategory) = Nothing
        Public Property TimeType As String = String.Empty
        Public Property Entry As ViewModels.Employee.Timesheet.TimesheetEntryViewModel
        Public Property AssignmentIsRequired As Boolean = False
        Public Property CommentIsRequired As Boolean = False
        Public ReadOnly Property IsDirectTime As Boolean
            Get
                If Me.TimeType.Trim.ToUpper = "D" Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

#End Region

#Region " Methods "

        Sub New()

            Entry = New TimesheetEntryViewModel
            Jobs = New List(Of AdvantageFramework.ViewModels.Lookup.LookupViewModel)
            FunctionCategories = New List(Of FunctionCategory)
            TimeType = "D"

        End Sub

#End Region

#Region " Classes "

        '<Serializable()>
        'Public Class Job

        '    Public Property JobNumber As Integer = 0
        '    Public Property JobComponentNumber As Short = 0
        '    Public ReadOnly Property Key As String
        '        Get
        '            Return JobNumber.ToString & "|" & JobComponentNumber
        '        End Get
        '    End Property

        '    Sub New()

        '    End Sub

        'End Class
        <Serializable()>
        Public Class FunctionCategory

            Public Property Code As String = String.Empty
            Public Property Description As String = String.Empty
            Public Property IsFunction As Boolean = False

            Sub New()

            End Sub

        End Class
        <Serializable()>
        Public Class Assignment

            Public Property AlertID As Integer = 0
            Public Property JobNumber As Integer? = 0
            Public Property JobComponentNumber As Short? = 0
            Public Property Subject As String = String.Empty
            Public Property DueDate As Date? = Nothing

            Sub New()

            End Sub

        End Class


#End Region

    End Class

End Namespace
