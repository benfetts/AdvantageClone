Public Class EmployeeTimeForecast_Scheduler
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

    Private Sub EmployeeTimeForecast_Scheduler_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim JobsList As Generic.List(Of AdvantageFramework.Database.Entities.Job) = Nothing
        Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
        Dim JobComponentTasksList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTask) = Nothing



        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            'AdvantageFramework.Web.Presentation.Controls.SetHtmlTableCellToDarkGrayCSSClass(Me.TdRadToolbarScheduler)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                JobsList = AdvantageFramework.Database.Procedures.Job.Load(DbContext).OrderBy(Function(Entity) Entity.Number).ThenBy(Function(Entity) Entity.Description).ToList

                DropDownListJob.DataSource = (From Entity In JobsList
                                              Select [Number] = Entity.Number,
                                                     [Description] = Entity.ToString(True)).ToList
                DropDownListJob.DataBind()
                DropDownListJob.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))
                DropDownListJob.SelectedValue = 143

                DayPilotMonth1.StartDate = CDate("12/01/2010")

                Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, 143)

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

                    DayPilotMonth1.DataSource = JobComponentTasksList
                    DayPilotMonth1.DataBind()

                End If

            End Using

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolbarScheduler_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarScheduler.ButtonClick

        'objects
        Dim StringWriter As System.IO.StringWriter = Nothing
        Dim HtmlTextWriter As System.Web.UI.HtmlTextWriter = Nothing
        Dim HTML As String = ""
        Dim StringBuilder As System.Text.StringBuilder = Nothing
        Dim Bitmap As System.Drawing.Bitmap = Nothing
        Dim MemoryStream As System.IO.MemoryStream = Nothing
        Dim URL As String = ""


        Select Case e.Item.Value

            Case "Create"

                'URL = Me.Request.Url.AbsoluteUri.Replace("EmployeeTimeForecast_Scheduler.aspx", "EmployeeTimeForecast_SchedulerPrint.aspx")

                'URL &= "?Server=NET-PROGRAMMER\SQL2005&Database=ADVAN620"

                'string address = "http://" + txtWebsiteAddress.Text;
                '        int width = Int32.Parse(txtWidth.Text);
                '        int height = Int32.Parse(txtHeight.Text);
                '        Bitmap bmp = WebsiteThumbnailImageGenerator.GetWebSiteThumbnail(address, 800, 600, width, height);
                '        bmp.Save(Server.MapPath("~") + "/thumbnail.bmp");
                '        imgWebsiteThumbnailImage.ImageUrl = "~/thumbnail.bmp";
                '        imgWebsiteThumbnailImage.Visible = true;

                'Bitmap = TestWebControl.WebsiteThumbnail.WebsiteThumbnailImageGenerator.GetWebSiteThumbnail(URL, 800, 800, 800, 800)
                Try

                    MemoryStream = DayPilotMonth1.Export(System.Drawing.Imaging.ImageFormat.Bmp)

                    ' RadBinaryImageScreenShot.DataValue = MemoryStream.ToArray

                    Session("SchedulerBitmapMemoryStream") = MemoryStream

                    Me.OpenWindow("", "EmployeeTimeForecast_SchedulerPrint.aspx", 650, 850, False, True)

                Catch ex As Exception
                    MemoryStream = Nothing
                End Try

        End Select

    End Sub
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

                    DayPilotMonth1.DataSource = JobComponentTasksList
                    DayPilotMonth1.DataBind()

                End If

            End Using

        End If

    End Sub

#End Region

#End Region

End Class