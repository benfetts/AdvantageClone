Public Class TrafficScheduleTemplate_New
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "

    Public Enum TemplateType

        ProjectSchedule = 0
        Task = 1

    End Enum

#End Region

#Region " Properties "

    Private Property _CurrentTemplateType As TemplateType = 0

#End Region

#Region " Variables "

    Private _JobNumber As Integer = 0
    Private _JobComponentNbr As Integer = 0

#End Region

#Region " Page "

    Private Sub TrafficScheduleTemplate_New_Init(sender As Object, e As EventArgs) Handles Me.Init

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        Me._JobNumber = qs.JobNumber
        Me._JobComponentNbr = qs.JobComponentNumber

        If IsNumeric(qs.GetValue("tmplt_type")) = True Then Me._CurrentTemplateType = CType(CType(qs.GetValue("tmplt_type"), Integer), TemplateType)


    End Sub
    Private Sub TrafficScheduleTemplate_New_Load(sender As Object, e As EventArgs) Handles Me.Load

        Select Case Me._CurrentTemplateType

            Case TemplateType.ProjectSchedule

                Me.RadTextBoxCode.Visible = False
                Me.RadTextBoxNameDescription.Width = New WebControls.Unit(100, UnitType.Percentage)
                Me.LabelTextBoxDescriptors.Text = "Template Name:"

                Me.RadTextBoxNameDescription.Focus()

            Case TemplateType.Task

                Me.Page.Title = "New Task Template"

                Me.RadTextBoxCode.Visible = True
                Me.RadTextBoxCode.Width = New WebControls.Unit(75, UnitType.Pixel)
                Me.RadTextBoxNameDescription.Width = New WebControls.Unit(300, UnitType.Pixel)
                Me.LabelTextBoxDescriptors.Text = "Template Code and Description:"

                Me.RadTextBoxCode.Focus()

        End Select

    End Sub

#End Region

#Region " Controls "

    Private Sub RadToolBarTrafficScheduleTemplateNew_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarTrafficScheduleTemplateNew.ButtonClick

        Select Case e.Item.Value

            Case "save"

                If Me._JobNumber > 0 And Me._JobComponentNbr > 0 Then

                    Select Case Me._CurrentTemplateType

                        Case TemplateType.ProjectSchedule
                            If Me.RadTextBoxNameDescription.Text.Trim() = "" Then

                                Me.ShowMessage("Template name is required")
                                Exit Sub

                            End If
                        Case TemplateType.Task
                            If Me.RadTextBoxCode.Text.Trim() = "" Then

                                Me.ShowMessage("Template code is required")
                                Exit Sub

                            Else

                                Me.RadTextBoxCode.Text = AdvantageFramework.StringUtilities.RemoveAllNonAlphaNumeric(Me.RadTextBoxCode.Text.Trim())

                            End If
                            If Me.RadTextBoxNameDescription.Text.Trim() = "" Then

                                Me.ShowMessage("Template description is required")
                                Exit Sub

                            End If
                    End Select



                    Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                        Select Case Me._CurrentTemplateType

                            Case TemplateType.ProjectSchedule

                                Dim NewVersion As AdvantageFramework.Database.Entities.JobTrafficVersion = Nothing
                                NewVersion = New AdvantageFramework.Database.Entities.JobTrafficVersion

                                NewVersion.DbContext = DbContext
                                NewVersion.VersionCreatedByUserCode = Me._Session.UserCode
                                NewVersion.VersionSequenceNumber = 0
                                NewVersion.VersionName = Me.RadTextBoxNameDescription.Text.Trim()
                                NewVersion.VersionComment = "Created for template:  " & Me.RadTextBoxNameDescription.Text.Trim()
                                NewVersion.VersionCreatedComment = "Created for template:  " & Me.RadTextBoxNameDescription.Text.Trim()
                                NewVersion.JobNumber = Me._JobNumber
                                NewVersion.JobComponentNumber = Me._JobComponentNbr
                                NewVersion.VersionIsActive = True

                                If AdvantageFramework.Database.Procedures.JobTrafficVersion.Insert(DbContext, NewVersion) = True Then

                                    If NewVersion.ID > 0 Then

                                        Dim jtt As New AdvantageFramework.Database.Entities.JobTrafficTemplate
                                        With jtt

                                            .CreateDate = Now.Date
                                            .CreatedBy = Me._Session.UserCode
                                            .Name = Me.RadTextBoxNameDescription.Text.Trim()
                                            .VersionID = NewVersion.ID

                                        End With

                                        If AdvantageFramework.Database.Procedures.JobTrafficTemplate.Insert(DbContext, jtt) = True Then

                                            Me.CloseThisWindow()

                                        Else

                                            Me.ShowMessage("Error saving template.")

                                        End If

                                    Else

                                        Me.ShowMessage("Error getting version ID for template.")

                                    End If

                                End If

                            Case TemplateType.Task

                                Dim TaskHeader As New AdvantageFramework.Database.Entities.TaskTemplate
                                Dim TotalExistingTasks As Integer = 0
                                Dim SuccessfulTemplateSaves As Integer = 0

                                With TaskHeader

                                    .Code = Me.RadTextBoxCode.Text.Trim()
                                    .Description = Me.RadTextBoxNameDescription.Text.Trim()

                                End With

                                If AdvantageFramework.Database.Procedures.TaskTemplate.Insert(DbContext, TaskHeader) = True Then

                                    Dim CurrentScheduleTasks As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTask)

                                    CurrentScheduleTasks = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumber(DbContext, Me._JobNumber, Me._JobComponentNbr).ToList()

                                    If Not CurrentScheduleTasks Is Nothing Then

                                        Using dc As New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                            For Each ScheduleTask As AdvantageFramework.Database.Entities.JobComponentTask In CurrentScheduleTasks

                                                TotalExistingTasks += 1

                                                Dim TemplateDetail As New AdvantageFramework.Database.Entities.TaskTemplateDetail

                                                TemplateDetail.TaskTemplateCode = TaskHeader.Code

                                                If Not ScheduleTask.Days Is Nothing Then TemplateDetail.DaysToComplete = ScheduleTask.Days
                                                If Not ScheduleTask.FuctionCode Is Nothing Then TemplateDetail.FunctionCode = ScheduleTask.FuctionCode
                                                If Not ScheduleTask.Hours Is Nothing Then TemplateDetail.HoursAllowed = ScheduleTask.Hours
                                                If Not ScheduleTask.IsMilestone Is Nothing Then TemplateDetail.IsMilestone = ScheduleTask.IsMilestone
                                                If Not ScheduleTask.PhaseID Is Nothing Then

                                                    TemplateDetail.PhaseID = ScheduleTask.PhaseID

                                                Else

                                                    TemplateDetail.PhaseID = Nothing

                                                End If
                                                If TemplateDetail.PhaseID = 0 Then TemplateDetail.PhaseID = Nothing
                                                If Not ScheduleTask.OrderNumber Is Nothing Then TemplateDetail.ProcessOrderNumber = ScheduleTask.OrderNumber
                                                If Not ScheduleTask.RoleCode Is Nothing Then TemplateDetail.RoleCode = ScheduleTask.RoleCode
                                                If Not ScheduleTask.TaskCode Is Nothing Then TemplateDetail.TaskCode = ScheduleTask.TaskCode

                                                If AdvantageFramework.Database.Procedures.TaskTemplateDetail.Insert(DbContext, dc, TemplateDetail) = True Then

                                                    SuccessfulTemplateSaves += 1

                                                End If

                                                TemplateDetail = Nothing

                                            Next

                                            If TotalExistingTasks <> SuccessfulTemplateSaves Then

                                                If SuccessfulTemplateSaves = 0 Then

                                                    AdvantageFramework.Database.Procedures.TaskTemplate.Delete(DbContext, dc, TaskHeader)
                                                    Me.ShowMessage("Error saving tasks.")

                                                ElseIf SuccessfulTemplateSaves > 0 Then

                                                    Me.ShowMessage(TotalExistingTasks.ToString() & " tasks found. " & SuccessfulTemplateSaves.ToString() & " tasks saved as template tasks.")

                                                End If

                                            Else

                                                Me.CloseThisWindowAndRefreshCaller("TrafficSchedule_QuickAdd.aspx")

                                            End If

                                        End Using

                                    End If

                                End If

                        End Select

                    End Using

                Else

                    Me.ShowMessage("Missing Job or Component")

                End If

        End Select

    End Sub

#End Region

#Region " Methods "



#End Region

End Class