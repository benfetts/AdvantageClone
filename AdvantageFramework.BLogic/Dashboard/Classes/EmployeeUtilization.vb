Namespace Dashboard.Classes

    <Serializable()>
    Public Class EmployeeUtilization

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            Items
            'TotalCount
            'AssignmentCount
            'AlertCount

        End Enum
        Public Enum Type

            All
            'Alert
            'Assignment
            'Task

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Filter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter = Nothing
        Public Property Items As Generic.List(Of AdvantageFramework.Dashboard.Classes.EmployeeUtilizationItem) = Nothing
        Public Property ErrorMesage As String = String.Empty

#End Region

#Region " Methods "

        Public Function GetCount(ByVal CountType As Type) As Integer

            'Dim Count As Integer = 0

            'Try

            '    If Me.Items IsNot Nothing Then

            '        Select Case CountType
            '            Case Type.All

            '                Count = Me.Items.Count

            '            Case Type.Assignment

            '                Count = (From Entity In Me.Items
            '                         Where Entity.IsStandardAlert = False
            '                         Select Entity).Count

            '            Case Type.Alert

            '                Count = (From Entity In Me.Items
            '                         Where Entity.IsStandardAlert = True
            '                         Select Entity).Count

            '            Case Type.Task

            '                Count = (From Entity In Me.Items
            '                         Where Entity.IsTaskAssignment = True
            '                         Select Entity).Count

            '        End Select

            '    End If

            'Catch ex As Exception
            '    Count = -1
            'End Try

            Return 0

        End Function

        Sub New()

            Me.Filter = New EmployeeUtilizationFilter
            Me.Items = New List(Of EmployeeUtilizationItem)

        End Sub

#End Region

    End Class

End Namespace
