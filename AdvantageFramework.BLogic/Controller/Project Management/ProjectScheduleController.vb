Imports AdvantageFramework.StringUtilities

Namespace Controller.ProjectManagement

    Public Class ProjectScheduleController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Function SplitFindAndReplaceComponentsToBatches(ByVal Components As String) As String()

            'objects
            Dim Batches As Generic.List(Of String) = Nothing
            Dim BatchComponents As Generic.List(Of String) = Nothing
            Dim SqlMax As Short = 8000

            If Components.Length > SqlMax Then

                Batches = New List(Of String)
                BatchComponents = New List(Of String)

                For Each Component In Components.Split("|")

                    If (String.Join("|", BatchComponents).Length + Component.Length + 1) < SqlMax Then

                        BatchComponents.Add(Component)

                    Else

                        Batches.Add(String.Join("|", BatchComponents))
                        BatchComponents.Clear()
                        BatchComponents.Add(Component)

                    End If

                Next

                Batches.Add(String.Join("|", BatchComponents))

                Return Batches.ToArray

        Else

        Return {Components}

        End If

        End Function
        Private Function FindAndReplace(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Type As Short, ByVal SearchForValue As String, ByVal ReplaceWithValue As String, ByVal Components As String, ByRef RowCount As Integer) As Boolean

            'objects
            Dim Parameters As System.Data.SqlClient.SqlParameter() = Nothing
            Dim FoundAndReplaced As Boolean = False

            Try

                For Each ComponentBatch In SplitFindAndReplaceComponentsToBatches(Components)

                    Parameters = {New SqlClient.SqlParameter("@TYPE", SqlDbType.SmallInt) With {.Value = Type},
                                  New SqlClient.SqlParameter("@OLD_VALUE", SqlDbType.VarChar) With {.Value = SearchForValue.ToDbNullIfNullOrWhiteSpace},
                                  New SqlClient.SqlParameter("@NEW_DATE", SqlDbType.VarChar) With {.Value = ReplaceWithValue.ToDbNullIfNullOrWhiteSpace},
                                  New SqlClient.SqlParameter("@COMPONENTS", SqlDbType.VarChar) With {.Value = ComponentBatch}}

                    RowCount += DbContext.Database.SqlQuery(Of Integer)("EXEC [dbo].[advsp_traffic_schedule_FindAndReplace] @TYPE, @OLD_VALUE, @NEW_DATE, @COMPONENTS", Parameters).SingleOrDefault

                Next

                FoundAndReplaced = True

            Catch ex As Exception
                FoundAndReplaced = False
                RowCount = 0
            End Try

            FindAndReplace = FoundAndReplaced

        End Function
        Private Function FindAndReplaceDates(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Type As Short, ByVal SearchFromDate As Date?, ByVal SearchToDate As Date?, ByVal ReplaceWithDate As Date?, ByVal Components As String, ByRef RowCount As Integer) As Boolean

            'objects
            Dim Parameters As System.Data.SqlClient.SqlParameter() = Nothing
            Dim FoundAndReplaced As Boolean = False

            Try

                For Each ComponentBatch In SplitFindAndReplaceComponentsToBatches(Components)

                    Parameters = {New SqlClient.SqlParameter("@TYPE", SqlDbType.SmallInt) With {.Value = Type},
                                  New SqlClient.SqlParameter("@DATE_FROM", SqlDbType.SmallDateTime) With {.Value = IIf(SearchFromDate Is Nothing, DBNull.Value, SearchFromDate)},
                                  New SqlClient.SqlParameter("@DATE_TO", SqlDbType.SmallDateTime) With {.Value = IIf(SearchToDate Is Nothing, DBNull.Value, SearchToDate)},
                                  New SqlClient.SqlParameter("@NEW_DATE", SqlDbType.SmallDateTime) With {.Value = IIf(ReplaceWithDate Is Nothing, DBNull.Value, ReplaceWithDate)},
                                  New SqlClient.SqlParameter("@COMPONENTS", SqlDbType.VarChar) With {.Value = ComponentBatch}}

                    RowCount += DbContext.Database.SqlQuery(Of Integer)("EXEC [dbo].[advsp_traffic_schedule_FindAndReplace_Dates] @TYPE, @DATE_FROM, @DATE_TO, @NEW_DATE, @COMPONENTS", Parameters).SingleOrDefault

                Next

                FoundAndReplaced = True

            Catch ex As Exception
                FoundAndReplaced = False
                RowCount = 0
            End Try

            FindAndReplaceDates = FoundAndReplaced

        End Function
        Private Function FindAndReplaceHeaderDates(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Type As Short, ByVal SearchFromDate As Date, ByVal SearchToDate As Date, ReplaceWithDate As Date, ByVal Components As String, ByRef RowCount As Integer) As Boolean

            'objects
            Dim Parameters As System.Data.SqlClient.SqlParameter() = Nothing
            Dim FoundAndReplaced As Boolean = False

            Try

                For Each ComponentBatch In SplitFindAndReplaceComponentsToBatches(Components)

                    Parameters = {New SqlClient.SqlParameter("@TYPE", SqlDbType.SmallInt) With {.Value = Type},
                                  New SqlClient.SqlParameter("@DATE_FROM", SqlDbType.SmallDateTime) With {.Value = If(SearchFromDate.Year = 1, DBNull.Value, SearchFromDate)},
                                  New SqlClient.SqlParameter("@DATE_TO", SqlDbType.SmallDateTime) With {.Value = If(SearchToDate.Year = 1, DBNull.Value, SearchToDate)},
                                  New SqlClient.SqlParameter("@NEW_DATE", SqlDbType.SmallDateTime) With {.Value = ReplaceWithDate},
                                  New SqlClient.SqlParameter("@COMPONENTS", SqlDbType.VarChar) With {.Value = ComponentBatch}}

                    RowCount += DbContext.Database.SqlQuery(Of Integer)("EXEC [dbo].[advsp_traffic_schedule_FindAndReplace_Dates] @TYPE, @DATE_FROM, @DATE_TO, @NEW_DATE, @COMPONENTS", Parameters).SingleOrDefault

                Next

                FoundAndReplaced = True

            Catch ex As Exception
                FoundAndReplaced = False
                RowCount = 0
            End Try

            FindAndReplaceHeaderDates = FoundAndReplaced

        End Function
        Private Function FindAndReplaceEmployeeAssignment(DbContext As AdvantageFramework.Database.DbContext, EmployeeCodeSearchFor As String, EmployeeCodeReplaceWith As String, TaskCode As String, Components As String, ByRef RowCount As Integer) As Boolean

            'objects
            Dim Parameters As System.Data.SqlClient.SqlParameter() = Nothing
            Dim FoundAndReplaced As Boolean = False

            Try

                For Each ComponentBatch In SplitFindAndReplaceComponentsToBatches(Components)

                    Parameters = {New SqlClient.SqlParameter("@OLD_EMP_CODE", SqlDbType.VarChar) With {.Value = EmployeeCodeSearchFor.ToDbNullIfNullOrWhiteSpace},
                              New SqlClient.SqlParameter("@NEW_EMP_CODE", SqlDbType.VarChar) With {.Value = EmployeeCodeReplaceWith.ToDbNullIfNullOrWhiteSpace},
                              New SqlClient.SqlParameter("@FNC_CODE", SqlDbType.VarChar) With {.Value = TaskCode.ToDbNullIfNullOrWhiteSpace},
                              New SqlClient.SqlParameter("@COMPONENTS", SqlDbType.VarChar) With {.Value = ComponentBatch}}

                    RowCount += DbContext.Database.SqlQuery(Of Integer)("EXEC [dbo].[advsp_traffic_schedule_FindAndReplace_EmployeeAssignment] @OLD_EMP_CODE, @NEW_EMP_CODE, @FNC_CODE, @COMPONENTS", Parameters).SingleOrDefault

                Next

                FoundAndReplaced = True

            Catch ex As Exception
                FoundAndReplaced = False
                RowCount = 0
            End Try

            FindAndReplaceEmployeeAssignment = FoundAndReplaced

        End Function
        Private Function FindAndReplaceManager(DbContext As AdvantageFramework.Database.DbContext, EmployeeCodeSearchFor As String, EmployeeCodeReplaceWith As String, Components As String, ByRef RowCount As Integer) As Boolean

            'objects
            Dim Parameters As System.Data.SqlClient.SqlParameter() = Nothing
            Dim FoundAndReplaced As Boolean = False

            Try

                For Each ComponentBatch In SplitFindAndReplaceComponentsToBatches(Components)

                    Parameters = {New SqlClient.SqlParameter("@OLD_EMP_CODE", SqlDbType.VarChar) With {.Value = EmployeeCodeSearchFor.ToDbNullIfNullOrWhiteSpace},
                                  New SqlClient.SqlParameter("@NEW_EMP_CODE", SqlDbType.VarChar) With {.Value = EmployeeCodeReplaceWith.ToDbNullIfNullOrWhiteSpace},
                                  New SqlClient.SqlParameter("@COMPONENTS", SqlDbType.VarChar) With {.Value = ComponentBatch}}

                    RowCount += DbContext.Database.SqlQuery(Of Integer)("EXEC [dbo].[advsp_traffic_schedule_FindAndReplace_Manager] @OLD_EMP_CODE, @NEW_EMP_CODE, @COMPONENTS", Parameters).SingleOrDefault

                Next

                FoundAndReplaced = True

            Catch ex As Exception
                FoundAndReplaced = False
                RowCount = 0
            End Try

            FindAndReplaceManager = FoundAndReplaced

        End Function
        Private Function FindAndReplaceClientContactAssignment(DbContext As AdvantageFramework.Database.DbContext, ClientCode As String, ClientContactCodeSearchFor As String, ClientContactCodeReplaceWith As String, Components As String, ByRef RowCount As Integer) As Boolean

            'objects
            Dim Parameters As System.Data.SqlClient.SqlParameter() = Nothing
            Dim FoundAndReplaced As Boolean = False

            Try

                For Each ComponentBatch In SplitFindAndReplaceComponentsToBatches(Components)

                    Parameters = {New SqlClient.SqlParameter("@CL_CODE", SqlDbType.VarChar) With {.Value = ClientCode},
                                  New SqlClient.SqlParameter("@OLD_CONT_CODE", SqlDbType.VarChar) With {.Value = ClientContactCodeSearchFor},
                                  New SqlClient.SqlParameter("@NEW_CONT_CODE", SqlDbType.VarChar) With {.Value = ClientContactCodeReplaceWith.ToDbNullIfNullOrWhiteSpace},
                                  New SqlClient.SqlParameter("@COMPONENTS", SqlDbType.VarChar) With {.Value = ComponentBatch}}

                    RowCount += DbContext.Database.SqlQuery(Of Integer)("EXEC [dbo].[advsp_traffic_schedule_FindAndReplace_ClientContactAssignment] @CL_CODE, @OLD_CONT_CODE, @NEW_CONT_CODE, @COMPONENTS", Parameters).SingleOrDefault

                Next

                FoundAndReplaced = True

            Catch ex As Exception
                FoundAndReplaced = False
                RowCount = 0
            End Try

            FindAndReplaceClientContactAssignment = FoundAndReplaced

        End Function
        Private Function FindAndReplaceTaskComment(DbContext As AdvantageFramework.Database.DbContext, TaskCommentReplaceWith As String, TaskCode As String, Components As String, ByRef RowCount As Integer) As Boolean

            'objects
            Dim Parameters As System.Data.SqlClient.SqlParameter() = Nothing
            Dim FoundAndReplaced As Boolean = False

            Try

                For Each ComponentBatch In SplitFindAndReplaceComponentsToBatches(Components)

                    Parameters = {New SqlClient.SqlParameter("@NEW_COMMENT", SqlDbType.VarChar) With {.Value = TaskCommentReplaceWith.ToDbNullIfNullOrWhiteSpace},
                              New SqlClient.SqlParameter("@FNC_CODE", SqlDbType.VarChar) With {.Value = TaskCode.ToDbNullIfNullOrWhiteSpace},
                              New SqlClient.SqlParameter("@COMPONENTS", SqlDbType.VarChar) With {.Value = ComponentBatch}}

                    RowCount += DbContext.Database.SqlQuery(Of Integer)("EXEC [dbo].[advsp_traffic_schedule_FindAndReplace_TaskComment] @NEW_COMMENT, @FNC_CODE, @COMPONENTS", Parameters).SingleOrDefault

                Next

                FoundAndReplaced = True

            Catch ex As Exception
                FoundAndReplaced = False
                RowCount = 0
            End Try

            FindAndReplaceTaskComment = FoundAndReplaced

        End Function

#Region " Public "

        Public Sub New(ByVal Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function FindAndReplace(ByVal ViewModel As AdvantageFramework.ViewModels.ProjectSchedule.ProjectScheduleFindAndReplaceViewModel) As Boolean

            'objects
            Dim FoundAndReplaced As Boolean = False
            Dim RecordCount As Integer = Nothing
            Dim LogString As String = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Select Case ViewModel.SelectedCriteria

                        Case "StartDate"

                            LogString = "Start date changed to """ & ViewModel.DateReplaceWith?.ToShortDateString & """ for {0} task(s)."
                            FoundAndReplaced = FindAndReplaceDates(DbContext, 0, ViewModel.FromDateSearchFor, ViewModel.ToDateSearchFor, ViewModel.DateReplaceWith, ViewModel.SelectedJobComponents, RecordCount)

                        Case "DueDate"

                            LogString = "Due date changed to """ & ViewModel.DateReplaceWith?.ToShortDateString & """ for {0} task(s)."
                            FoundAndReplaced = FindAndReplaceDates(DbContext, 1, ViewModel.FromDateSearchFor, ViewModel.ToDateSearchFor, ViewModel.DateReplaceWith, ViewModel.SelectedJobComponents, RecordCount)

                        Case "TimeDue"

                            LogString = "Time due changed to """ & ViewModel.TimeDueReplaceWith & """ for {0} task(s)."
                            FoundAndReplaced = FindAndReplace(DbContext, 0, ViewModel.TimeDueSearchFor, ViewModel.TimeDueReplaceWith, ViewModel.SelectedJobComponents, RecordCount)

                        Case "CompletedDate"

                            LogString = "Completed date changed to """ & ViewModel.DateReplaceWith?.ToShortDateString & """ for {0} task(s)."
                            FoundAndReplaced = FindAndReplaceDates(DbContext, 2, ViewModel.FromDateSearchFor, ViewModel.ToDateSearchFor, ViewModel.DateReplaceWith, ViewModel.SelectedJobComponents, RecordCount)

                        Case "EmployeeAssignment"

                            If String.IsNullOrWhiteSpace(ViewModel.EmployeeCodeSearchFor) Then

                                LogString = "Employee assignments for """ & ViewModel.EmployeeCodeReplaceWith & """ added to {0} open task(s)."

                            ElseIf String.IsNullOrWhiteSpace(ViewModel.EmployeeCodeReplaceWith) Then

                                LogString = "Employee assignments for """ & ViewModel.EmployeeCodeSearchFor & """ deleted from {0} open task(s)."

                            Else

                                LogString = "Employee assignment changed from """ & ViewModel.EmployeeCodeSearchFor & """ to """ & ViewModel.EmployeeCodeReplaceWith & """ for {0} open task(s)."

                            End If

                            FoundAndReplaced = FindAndReplaceEmployeeAssignment(DbContext, ViewModel.EmployeeCodeSearchFor, ViewModel.EmployeeCodeReplaceWith, ViewModel.TaskCodeSearchFor, ViewModel.SelectedJobComponents, RecordCount)

                        Case "ClientContactAssignment"

                            If String.IsNullOrWhiteSpace(ViewModel.ClientContactCodeReplaceWith) Then

                                LogString = "Client contact assignments for """ & ViewModel.ClientContactCodeSearchFor & """ deleted from {0} task(s)."

                            Else

                                LogString = "Client contact assignment changed from """ & ViewModel.ClientContactCodeSearchFor & """ to """ & ViewModel.ClientContactCodeReplaceWith & """ for {0} task(s)."

                            End If

                            FoundAndReplaced = FindAndReplaceClientContactAssignment(DbContext, ViewModel.ClientCode, ViewModel.ClientContactCodeSearchFor, ViewModel.ClientContactCodeReplaceWith, ViewModel.SelectedJobComponents, RecordCount)

                        Case "TaskStatus"

                            LogString = "Task status changed from """ & ViewModel.TaskStatuses(ViewModel.TaskStatusSearchFor) & """ to """ & ViewModel.TaskStatuses(ViewModel.TaskStatusReplaceWith) & """ for {0} task(s)."
                            FoundAndReplaced = FindAndReplace(DbContext, 1, ViewModel.TaskStatusSearchFor, ViewModel.TaskStatusReplaceWith, ViewModel.SelectedJobComponents, RecordCount)

                        Case "Manager"

                            LogString = "Manager assignment changed from " & If(String.IsNullOrWhiteSpace(ViewModel.ManagerCodeSearchFor), "[Empty]", "" & ViewModel.ManagerCodeSearchFor & "") & " to " & If(String.IsNullOrWhiteSpace(ViewModel.ManagerCodeReplaceWith), "[Empty]", "" & ViewModel.ManagerCodeReplaceWith & "") & " for {0} project schedule(s)."
                            FoundAndReplaced = FindAndReplaceManager(DbContext, ViewModel.ManagerCodeSearchFor, ViewModel.ManagerCodeReplaceWith, ViewModel.SelectedJobComponents, RecordCount)

                        Case "TaskComment"

                            LogString = "Task Comment updated for task code '" & ViewModel.TaskCodeSearchFor & "' for {0} task(s)."
                            FoundAndReplaced = FindAndReplaceTaskComment(DbContext, ViewModel.TaskCommentReplaceWith, ViewModel.TaskCodeSearchFor, ViewModel.SelectedJobComponents, RecordCount)

                        Case "HeaderStartDate"

                            LogString = "Header Start date changed to """ & ViewModel.DateReplaceWith.Value.ToShortDateString & """ for {0} schedule(s)."
                            FoundAndReplaced = FindAndReplaceHeaderDates(DbContext, 3, If(ViewModel.FromDateSearchFor.HasValue = False, Nothing, ViewModel.FromDateSearchFor.Value), If(ViewModel.ToDateSearchFor.HasValue = False, Nothing, ViewModel.ToDateSearchFor.Value), ViewModel.DateReplaceWith, ViewModel.SelectedJobComponents, RecordCount)

                        Case "HeaderDueDate"

                            LogString = "Header Due date changed to """ & ViewModel.DateReplaceWith.Value.ToShortDateString & """ for {0} schedule(s)."
                            FoundAndReplaced = FindAndReplaceHeaderDates(DbContext, 4, If(ViewModel.FromDateSearchFor.HasValue = False, Nothing, ViewModel.FromDateSearchFor.Value), If(ViewModel.ToDateSearchFor.HasValue = False, Nothing, ViewModel.ToDateSearchFor.Value), ViewModel.DateReplaceWith, ViewModel.SelectedJobComponents, RecordCount)

                        Case "HeaderCompletedDate"

                            LogString = "Header Completed date changed to """ & ViewModel.DateReplaceWith.Value.ToShortDateString & """ for {0} schedule(s)."
                            FoundAndReplaced = FindAndReplaceHeaderDates(DbContext, 5, If(ViewModel.FromDateSearchFor.HasValue = False, Nothing, ViewModel.FromDateSearchFor.Value), If(ViewModel.ToDateSearchFor.HasValue = False, Nothing, ViewModel.ToDateSearchFor.Value), ViewModel.DateReplaceWith, ViewModel.SelectedJobComponents, RecordCount)


                    End Select

                    If FoundAndReplaced = True Then

                        ViewModel.Log.Add(String.Format(LogString, RecordCount))

                    End If

                End Using

            Catch ex As Exception
                FoundAndReplaced = False
            End Try

            FindAndReplace = FoundAndReplaced

        End Function
        Public Function MarkTaskTempComplete(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal TaskSequenceNumber As Short,
                                             ByVal EmployeeCode As String, ByRef MarkCompleted As Boolean) As Boolean

            Dim Updated As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Dim TaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee = Nothing

                    TaskEmployee = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeqEmp(DbContext, JobNumber, JobComponentNumber, TaskSequenceNumber, EmployeeCode)

                    If TaskEmployee IsNot Nothing Then

                        If TaskEmployee.TempCompletionDate Is Nothing Then

                            Updated = AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, SecurityContext, JobNumber, JobComponentNumber, TaskSequenceNumber, EmployeeCode, CType(Now, DateTime), MarkCompleted)

                        Else

                            Updated = AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, SecurityContext, JobNumber, JobComponentNumber, TaskSequenceNumber, EmployeeCode, Nothing, MarkCompleted)

                        End If

                    End If

                End Using

            End Using

            Return MarkCompleted

        End Function

#End Region

#End Region

    End Class

End Namespace
