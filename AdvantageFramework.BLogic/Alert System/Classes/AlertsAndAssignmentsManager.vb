Namespace AlertSystem.Classes

    <Serializable()>
    Public Class AlertsAndAssignmentsManager

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
            Alert
            Assignment
            Task

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Filter As AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerFilter = Nothing
        Public Property Items As Generic.List(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerItem) = Nothing
        Public Property ErrorMesage As String = String.Empty

#End Region

#Region " Methods "

        Public Function GetCount(ByVal CountType As Type) As Integer

            Dim Count As Integer = 0

            Try

                If Me.Items IsNot Nothing Then

                    Select Case CountType
                        Case Type.All

                            Count = Me.Items.Count

                        Case Type.Assignment

                            Count = (From Entity In Me.Items
                                     Where Entity.IsStandardAlert = False
                                     Select Entity).Count

                        Case Type.Alert

                            Count = (From Entity In Me.Items
                                     Where Entity.IsStandardAlert = True
                                     Select Entity).Count

                        Case Type.Task

                            Count = (From Entity In Me.Items
                                     Where Entity.IsTaskAssignment = True
                                     Select Entity).Count

                    End Select

                End If

            Catch ex As Exception
                Count = -1
            End Try

            Return Count

        End Function

        Sub New()

            Me.Filter = New AlertsAndAssignmentsManagerFilter
            Me.Items = New List(Of AlertsAndAssignmentsManagerItem)

        End Sub

#End Region

    End Class

End Namespace
