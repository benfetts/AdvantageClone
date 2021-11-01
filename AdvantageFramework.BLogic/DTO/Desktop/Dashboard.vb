Namespace DTO.Desktop

    Public Class Dashboard

        Public Property GroupByOptions As Generic.List(Of GroupByOption)
        Public Property GroupBy As String
        Public Property Type As Short
        Public ReadOnly Property DashboardType As AdvantageFramework.Controller.Dashboard.DashboardController.DashboardType
            Get
                If Type = 0 Then

                    Return Controller.Dashboard.DashboardController.DashboardType.Alerts

                ElseIf Type = 1 Then

                    Return Controller.Dashboard.DashboardController.DashboardType.Assignments

                ElseIf Type = 2 Then

                    Return Controller.Dashboard.DashboardController.DashboardType.Tasks

                ElseIf Type = 3 Then

                    Return Controller.Dashboard.DashboardController.DashboardType.Reviews

                Else

                    Return Controller.Dashboard.DashboardController.DashboardType.Alerts

                End If

            End Get
        End Property
        Public Property Settings As CardSettings

        Public Sub New()


        End Sub
        Public Sub New(DashboardType As AdvantageFramework.Controller.Dashboard.DashboardController.DashboardType)

            Me.Type = CShort(DashboardType)

        End Sub

        Public Class GroupByOption

            Public Property Value As String
            Public Property Text As String

            Public Sub New()


            End Sub
            Public Sub New(Value As String, Text As String)

                Me.Value = Value
                Me.Text = Text

            End Sub

        End Class

        Public Class CardSettings

            Public Property ShowClientName As Boolean = False
            Public Property ShowJobNumber As Boolean = False
            Public Property ShowJobComponentNumber As Boolean = False
            Public Property ShowJobDescription As Boolean = False
            Public Property ShowJobComponentDescription As Boolean = False
            Public Property ShowTaskComment As Boolean = False
            Public Property ShowState As Boolean = False
            Public Property DefaultSort As String = String.Empty

        End Class

        Public Class TaskCardSettings
            Inherits CardSettings

            Public Property TaskType As String
            Public Property ShowTasks As String
            Public Property TodayOnlyStartDue As Boolean

        End Class

        Public Class ReviewCardSettings
            Inherits CardSettings

            Public Property ShowReviewInstructions As Boolean = False

        End Class

        Public Class CardGroup

            Public Property Key As String
            Public Property Cards As Generic.List(Of Card)

            Public Sub New()

                Me.Cards = New List(Of Card)

            End Sub

        End Class

        Public Class Card
            Public Property AlertID As Integer
            Public Property SprintID As Integer
            Public Property Title As String
            Public Property Priority As Short
            Public Property Data As Generic.List(Of String)
            Public Property JobNumber As Integer?
            Public Property StartDate() As Nullable(Of Date)
            Public Property DueDate() As Nullable(Of Date)
            Public Property TimeDue() As String
            Public Property JobDescription() As String
            Public Property JobComponentNumber() As Nullable(Of Short)
            Public Property JobComponentDescription() As String
            Public Property TaskFunctionDescription() As String
            Public ReadOnly Property StartDateString As String
                Get
                    If StartDate IsNot Nothing Then
                        Return CType(StartDate, Date).ToShortDateString
                    Else
                        Return String.Empty
                    End If
                End Get
            End Property
            Public ReadOnly Property DueDateString As String
                Get
                    If DueDate IsNot Nothing Then
                        Return CType(DueDate, Date).ToShortDateString
                    Else
                        Return String.Empty
                    End If
                End Get
            End Property

            Public Property AlertTypeID() As Integer
            Public Property AlertTypeDescription() As String
            Public ReadOnly Property AlertType As String
                Get
                    If String.IsNullOrWhiteSpace(AlertTypeDescription) = False Then
                        Return AlertTypeDescription.Substring(0, 1).ToUpper
                    Else
                        Return String.Empty
                    End If
                End Get
            End Property

            Public Property AlertCategoryID As Integer
            Public Property AlertCategoryDescription As String
            Public ReadOnly Property Indicator As String
                Get
                    If String.IsNullOrWhiteSpace(AlertCategoryDescription) = False Then
                        Return AlertCategoryDescription.Substring(0, 1).ToUpper
                    Else
                        Return String.Empty
                    End If
                End Get
            End Property


            Public Property ClientName As String
            Public Property IsAlertAssignment As String
            Public Property TaskSequenceNumber As Nullable(Of Short)
            Public Property IsWorkItem As String
            Public Property TaskComment As String
            Public Property CheckListCompleted As Integer
            Public Property CheckListTotal As Integer
            Public Property CSProjectID As Integer
            Public Property CSReviewID As Integer
            Public Property ShowChecklistsOnCards As String
            Public Property IsMyTaskTempComplete As Boolean
            Public Property TempCompleteString As String
            Public Property EstimateNumber As Integer?
            Public Property EstimateComponentNumber As Nullable(Of Short)

            Public ReadOnly Property IsRead As Boolean
                Get
                    Try
                        If ReadAlert Is Nothing Then
                            Return False
                        Else
                            If ReadAlert = 1 Then
                                Return True
                            Else
                                Return False
                            End If
                        End If
                    Catch ex As Exception
                        Return True
                    End Try
                End Get
            End Property
            Public Property ReadAlert As Short?
            Public Property ReadAlertText As String
            Public Property IsAlertCC As Boolean
            Public Property AlertStateName As String
            Public Property ShowState As String
            Public Property TaskStatus As String
            Public Property TaskStatusDescription As String
            Public Property IsAutoRoute As Boolean? = False

            Public Sub New()

                Me.Data = New List(Of String)

            End Sub

        End Class

    End Class

End Namespace


