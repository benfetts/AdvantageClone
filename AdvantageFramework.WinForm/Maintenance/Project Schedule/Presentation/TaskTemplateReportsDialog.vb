Namespace Maintenance.ProjectSchedule.Presentation

    Public Class TaskTemplateReportsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _TaskTemplates As Generic.List(Of AdvantageFramework.Database.Entities.TaskTemplate) = Nothing
        Private _SelectedTaskTemplates As Generic.List(Of AdvantageFramework.Database.Entities.TaskTemplate) = Nothing
        Private _TaskTemplateCode As String = Nothing

#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New(ByVal TaskTemplateCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _TaskTemplateCode = TaskTemplateCode

        End Sub
        Private Sub LoadObjects()

            DataGridViewForm_SelectedTaskTemplates.DataSource = _SelectedTaskTemplates
            DataGridViewForm_SelectedTaskTemplates.CurrentView.BestFitColumns()

            DataGridViewForm_TaskTemplates.DataSource = (From TaskTemplate In _TaskTemplates
                                                         Where _SelectedTaskTemplates.Any(Function(TaskTemp) TaskTemp.Code = TaskTemplate.Code) = False _
                                                         Select TaskTemplate).ToList
            DataGridViewForm_TaskTemplates.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadReports()

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ListBoxForm_Reports.DataSource = AdvantageFramework.Security.Database.Procedures.Report.LoadByReportType(SecurityDbContext, 114).ToList

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByVal TaskTemplateCode As String = "") As System.Windows.Forms.DialogResult

            'objects
            Dim TaskTemplateReportsDialog As AdvantageFramework.Maintenance.ProjectSchedule.Presentation.TaskTemplateReportsDialog = Nothing

            TaskTemplateReportsDialog = New AdvantageFramework.Maintenance.ProjectSchedule.Presentation.TaskTemplateReportsDialog(TaskTemplateCode)

            ShowFormDialog = TaskTemplateReportsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub TaskTemplateReportsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ' Objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            _SelectedTaskTemplates = New Generic.List(Of AdvantageFramework.Database.Entities.TaskTemplate)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                _TaskTemplates = AdvantageFramework.Database.Procedures.TaskTemplate.Load(DbContext).ToList

            End Using

            If _TaskTemplateCode <> "" Then

                Try

                    _SelectedTaskTemplates.Add(_TaskTemplates.Where(Function(TaskTemplate) TaskTemplate.Code = _TaskTemplateCode).SingleOrDefault)

                Catch ex As Exception

                End Try

            End If

            ListBoxForm_Reports.SelectionMode = Windows.Forms.SelectionMode.One
            DataGridViewForm_TaskTemplates.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never

            LoadReports()
            LoadObjects()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Ok_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Ok.Click

            'objects
            Dim ParameterList As Generic.Dictionary(Of String, Object) = Nothing
            Dim ReportType As AdvantageFramework.Reporting.ReportTypes = Nothing

            If Me.Validator Then

                If _SelectedTaskTemplates IsNot Nothing AndAlso _SelectedTaskTemplates.Count > 0 Then

                    ParameterList = New Generic.Dictionary(Of String, Object)

                    Select Case ListBoxForm_Reports.SelectedValue

                        Case "d_traffic_preset_roles_rpt"

                            ReportType = Reporting.ReportTypes.TaskTemplatesWithRoles

                        Case "d_traffic_preset_rpt"

                            ReportType = Reporting.ReportTypes.TaskTemplates

                    End Select

                    ParameterList.Add("DataSource", _SelectedTaskTemplates)

                    If AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, ReportType, ParameterList, Nothing, Nothing, Nothing, Nothing) = Windows.Forms.DialogResult.OK Then

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Please select at least one task template.")

                End If

            End If

        End Sub
        Private Sub ButtonForm_Close_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_Add_Click(sender As System.Object, e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim TaskTemplate As AdvantageFramework.Database.Entities.TaskTemplate = Nothing
            Dim TaskTemplateCode As String = Nothing

            If DataGridViewForm_TaskTemplates.HasOnlyOneSelectedRow Then

                TaskTemplateCode = DataGridViewForm_TaskTemplates.GetFirstSelectedRowBookmarkValue

                Try

                    TaskTemplate = _TaskTemplates.Where(Function(TaskTemp) TaskTemp.Code = TaskTemplateCode).FirstOrDefault

                    If TaskTemplate IsNot Nothing Then

                        _SelectedTaskTemplates.Add(TaskTemplate)

                    End If

                Catch ex As Exception

                End Try

                LoadObjects()

            End If

        End Sub
        Private Sub ButtonForm_Remove_Click(sender As System.Object, e As System.EventArgs) Handles ButtonForm_Remove.Click

            Dim TaskTemplateCode As String = Nothing
            Dim TaskTemplate As AdvantageFramework.Database.Entities.TaskTemplate = Nothing

            If DataGridViewForm_SelectedTaskTemplates.HasOnlyOneSelectedRow Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    TaskTemplateCode = DataGridViewForm_SelectedTaskTemplates.GetFirstSelectedRowBookmarkValue

                    Try

                        TaskTemplate = (From TaskTemp In _SelectedTaskTemplates
                                        Where TaskTemp.Code = TaskTemplateCode
                                        Select TaskTemp).SingleOrDefault

                    Catch ex As Exception
                        TaskTemplate = Nothing
                    End Try

                    If TaskTemplate IsNot Nothing Then

                        _SelectedTaskTemplates.Remove(TaskTemplate)

                    End If

                    LoadObjects()

                End Using

            End If

        End Sub
        Private Sub ButtonForm_AddAll_Click(sender As System.Object, e As System.EventArgs) Handles ButtonForm_AddAll.Click

            _SelectedTaskTemplates.Clear()

            For Each TaskTemplate In _TaskTemplates

                Try

                    _SelectedTaskTemplates.Add(TaskTemplate)

                Catch ex As Exception

                End Try

            Next

            LoadObjects()

        End Sub
        Private Sub ButtonForm_RemoveAll_Click(sender As System.Object, e As System.EventArgs) Handles ButtonForm_RemoveAll.Click

            _SelectedTaskTemplates.Clear()

            LoadObjects()

        End Sub

#End Region

#End Region

    End Class

End Namespace