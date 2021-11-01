Public Class ProjectSchedule_GanttView
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region "  Form Event Handlers "

    Private Sub ProjectSchedule_GanttView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim JobsList As Generic.List(Of AdvantageFramework.Database.Entities.Job) = Nothing
        Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
        Dim JobComponentTasksList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTask) = Nothing



        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                JobsList = AdvantageFramework.Database.Procedures.Job.Load(DbContext).OrderBy(Function(Entity) Entity.Number).ThenBy(Function(Entity) Entity.Description).ToList

                DropDownListJob.DataSource = (From Entity In JobsList
                                              Select [Number] = Entity.Number,
                                                     [Description] = Entity.ToString(True)).ToList
                DropDownListJob.DataBind()
                DropDownListJob.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))
                DropDownListJob.SelectedValue = 1

                RadSchedulerProjectSchedule.SelectedDate = CDate("07/13/2007")

                Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, 1)

                If Job IsNot Nothing Then

                    JobComponentTasksList = New Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTask)

                    For Each JobComponent In Job.JobComponents.ToList

                        For Each JobComponentTask In JobComponent.JobComponentTasks.ToList

                            If JobComponentTask.StartDate IsNot Nothing AndAlso JobComponentTask.StartDate.HasValue AndAlso
                                JobComponentTask.DueDate IsNot Nothing AndAlso JobComponentTask.DueDate.HasValue Then

                                JobComponentTasksList.Add(JobComponentTask)

                            End If

                        Next

                    Next

                    RadSchedulerProjectSchedule.DataSource = JobComponentTasksList
                    RadSchedulerProjectSchedule.DataBind()

                End If

            End Using

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub DropDownListJob_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListJob.SelectedIndexChanged

        'objects
        Dim CreateReport As Boolean = True
        Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
        Dim JobComponentTasksList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTask) = Nothing

        If DropDownListJob.SelectedValue IsNot Nothing OrElse DropDownListJob.SelectedValue <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, DropDownListJob.SelectedValue)

                If Job IsNot Nothing Then

                    JobComponentTasksList = New Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTask)

                    For Each JobComponent In Job.JobComponents.ToList

                        For Each JobComponentTask In JobComponent.JobComponentTasks.ToList

                            If JobComponentTask.StartDate IsNot Nothing AndAlso JobComponentTask.StartDate.HasValue AndAlso _
                                JobComponentTask.DueDate IsNot Nothing AndAlso JobComponentTask.DueDate.HasValue Then

                                JobComponentTasksList.Add(JobComponentTask)

                            End If

                        Next

                    Next

                    RadSchedulerProjectSchedule.DataSource = JobComponentTasksList
                    RadSchedulerProjectSchedule.DataBind()

                End If

            End Using

        End If

    End Sub

#End Region

#End Region

End Class