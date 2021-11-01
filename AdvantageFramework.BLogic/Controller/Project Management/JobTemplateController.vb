Imports AdvantageFramework.StringUtilities

Namespace Controller.ProjectManagement

    Public Class JobTemplateController
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
        Private Function UpdateAccountExecutive(DbContext As AdvantageFramework.Database.DbContext, AccountExecutive As String, IsDefault As Boolean, Components As String, ByRef RowCount As Integer) As Boolean

            'objects
            Dim Parameters As System.Data.SqlClient.SqlParameter() = Nothing
            Dim Updated As Boolean = False
            Dim AE As AdvantageFramework.Database.Entities.AccountExecutive = Nothing
            Dim AcctExecutive As AdvantageFramework.Database.Entities.AccountExecutive = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim ProductAccountExecutivesList As Generic.List(Of AdvantageFramework.Database.Entities.AccountExecutive) = Nothing
            Dim DefaultAE As AdvantageFramework.Database.Entities.AccountExecutive = Nothing

            Try

                For Each ComponentBatch In SplitFindAndReplaceComponentsToBatches(Components)

                    Dim job() As String = ComponentBatch.Split(",")
                    JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, job(0), job(1))

                    If JobComponent IsNot Nothing Then

                        AE = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductAndEmployeeCode(DbContext, JobComponent.Job.ClientCode, JobComponent.Job.DivisionCode, JobComponent.Job.ProductCode, AccountExecutive)

                        If AE Is Nothing Then

                            If IsDefault = True Then

                                ProductAccountExecutivesList = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductCode(DbContext, JobComponent.Job.ClientCode, JobComponent.Job.DivisionCode, JobComponent.Job.ProductCode).ToList
                                For Each AccountExecutiveClass In ProductAccountExecutivesList
                                    If AccountExecutiveClass.IsDefaultAccountExecutive = 1 Then
                                        DefaultAE = AccountExecutiveClass
                                    End If
                                Next

                                If DefaultAE IsNot Nothing Then
                                    DefaultAE.IsDefaultAccountExecutive = 0
                                    AdvantageFramework.Database.Procedures.AccountExecutive.Update(DbContext, DefaultAE)
                                End If

                                AcctExecutive = New AdvantageFramework.Database.Entities.AccountExecutive

                                AcctExecutive.DbContext = DbContext

                                AcctExecutive.ClientCode = JobComponent.Job.ClientCode
                                AcctExecutive.DivisionCode = JobComponent.Job.DivisionCode
                                AcctExecutive.ProductCode = JobComponent.Job.ProductCode
                                AcctExecutive.EmployeeCode = AccountExecutive
                                AcctExecutive.IsDefaultAccountExecutive = 1
                                AcctExecutive.ManagementLevelID = 1

                            Else

                                AcctExecutive = New AdvantageFramework.Database.Entities.AccountExecutive

                                AcctExecutive.DbContext = DbContext

                                AcctExecutive.ClientCode = JobComponent.Job.ClientCode
                                AcctExecutive.DivisionCode = JobComponent.Job.DivisionCode
                                AcctExecutive.ProductCode = JobComponent.Job.ProductCode
                                AcctExecutive.EmployeeCode = AccountExecutive
                                AcctExecutive.IsDefaultAccountExecutive = 0
                                AcctExecutive.ManagementLevelID = 1

                            End If

                        Else

                            If IsDefault = True And AE.IsDefaultAccountExecutive = 0 Then

                                ProductAccountExecutivesList = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductCode(DbContext, JobComponent.Job.ClientCode, JobComponent.Job.DivisionCode, JobComponent.Job.ProductCode).ToList
                                For Each AccountExecutiveClass In ProductAccountExecutivesList
                                    If AccountExecutiveClass.IsDefaultAccountExecutive = 1 Then
                                        DefaultAE = AccountExecutiveClass
                                    End If
                                Next

                                If DefaultAE IsNot Nothing Then
                                    DefaultAE.IsDefaultAccountExecutive = 0
                                    AdvantageFramework.Database.Procedures.AccountExecutive.Update(DbContext, DefaultAE)
                                End If


                                AE.IsDefaultAccountExecutive = 1
                                AdvantageFramework.Database.Procedures.AccountExecutive.Update(DbContext, AE)
                            End If

                        End If


                        JobComponent.AccountExecutiveEmployeeCode = AccountExecutive
                        AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, JobComponent)

                        RowCount += 1

                    End If

                    'Parameters = {New SqlClient.SqlParameter("@NEW_EMP_CODE", SqlDbType.VarChar) With {.Value = AccountExecutive.ToDbNullIfNullOrWhiteSpace},
                    '              New SqlClient.SqlParameter("@COMPONENTS", SqlDbType.VarChar) With {.Value = ComponentBatch}}

                    'RowCount += DbContext.Database.SqlQuery(Of Integer)("EXEC [dbo].[advsp_traffic_schedule_FindAndReplace_Manager] @NEW_EMP_CODE, @COMPONENTS", Parameters).SingleOrDefault

                Next

                Updated = True

            Catch ex As Exception
                Updated = False
                RowCount = 0
            End Try

            UpdateAccountExecutive = Updated

        End Function

        Private Function UpdateAlertGroup(DbContext As AdvantageFramework.Database.DbContext, AlertGroup As String, Components As String, ByRef RowCount As Integer) As Boolean

            'objects
            Dim Parameters As System.Data.SqlClient.SqlParameter() = Nothing
            Dim Updated As Boolean = False
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim AlertGroupClass As AdvantageFramework.Database.Entities.AlertGroup = Nothing

            Try

                For Each ComponentBatch In SplitFindAndReplaceComponentsToBatches(Components)

                    Dim job() As String = ComponentBatch.Split(",")
                    JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, job(0), job(1))

                    If JobComponent IsNot Nothing Then
                        JobComponent.AlertGroupCode = AlertGroup
                        AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, JobComponent)
                    End If

                    RowCount += 1

                    'Parameters = {New SqlClient.SqlParameter("@NEW_EMP_CODE", SqlDbType.VarChar) With {.Value = AlertGroup.ToDbNullIfNullOrWhiteSpace},
                    '              New SqlClient.SqlParameter("@COMPONENTS", SqlDbType.VarChar) With {.Value = ComponentBatch}}

                    'RowCount += DbContext.Database.SqlQuery(Of Integer)("EXEC [dbo].[advsp_traffic_schedule_FindAndReplace_Manager] @NEW_EMP_CODE, @COMPONENTS", Parameters).SingleOrDefault

                Next

                Updated = True

            Catch ex As Exception
                Updated = False
                RowCount = 0
            End Try

            UpdateAlertGroup = Updated

        End Function

#Region " Public "

        Public Sub New(ByVal Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function UpdateJob(ByVal ViewModel As AdvantageFramework.ViewModels.JobTemplate.UpdateJobViewModel) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim RecordCount As Integer = Nothing
            Dim LogString As String = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Select Case ViewModel.SelectedCriteria

                        Case "AccountExecutive"

                            LogString = "Account Executive updated to " & If(String.IsNullOrWhiteSpace(ViewModel.EmployeeCodeAE), "[Empty]", "" & ViewModel.EmployeeCodeAE & "") & " for {0} job(s)."
                            Updated = UpdateAccountExecutive(DbContext, ViewModel.EmployeeCodeAE, ViewModel.IsDefaultAE, ViewModel.SelectedJobComponents, RecordCount)

                        Case "AlertGroup"

                            LogString = "Alert group updated to " & If(String.IsNullOrWhiteSpace(ViewModel.AlertGroupJob), "[Empty]", "" & ViewModel.AlertGroupJob & "") & " for {0} job(s)."
                            Updated = UpdateAlertGroup(DbContext, ViewModel.AlertGroupJob, ViewModel.SelectedJobComponents, RecordCount)

                    End Select

                    If Updated = True Then

                        ViewModel.Log.Add(String.Format(LogString, RecordCount))

                    End If

                End Using

            Catch ex As Exception
                Updated = False
            End Try

            UpdateJob = Updated

        End Function

#End Region

#End Region

    End Class

End Namespace
