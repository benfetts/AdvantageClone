Namespace Maintenance.ProjectManagement.Presentation

    Public Class JobVersionDetailListEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _JobVersionTemplateDetailID As Long = Nothing

#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New(ByRef JobVersionTemplateDetailID As Long)

            ' This call is required by the designer.
            InitializeComponent()

            _JobVersionTemplateDetailID = JobVersionTemplateDetailID

        End Sub
        Private Sub LoadGrid()

            If ComboBoxForm_List.HasASelectedValue Then

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewForm_JobVersionTemplateListValues.DataSource = AdvantageFramework.Database.Procedures.JobVersionTemplateDetailListValue.LoadByJobVersionTemplateDetailID(DataContext, ComboBoxForm_List.GetSelectedValue).ToList()
                    DataGridViewForm_JobVersionTemplateListValues.CurrentView.BestFitColumns()

                End Using

            End If

        End Sub
        Private Sub SaveChanges()

            'objects
            Dim DBJobVersionTemplateDetailListValues As Generic.List(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue) = Nothing
            Dim DBJobVersionTemplateDetailListValue As AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue = Nothing
            Dim JobVersionTemplateDetailListValues As Generic.List(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue) = Nothing

            Try

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DBJobVersionTemplateDetailListValues = AdvantageFramework.Database.Procedures.JobVersionTemplateDetailListValue.LoadByJobVersionTemplateDetailID(DataContext, ComboBoxForm_List.GetSelectedValue).ToList()
                    JobVersionTemplateDetailListValues = DataGridViewForm_JobVersionTemplateListValues.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue).ToList

                    For Each JobVersionTemplateDetailListValue In JobVersionTemplateDetailListValues

                        DBJobVersionTemplateDetailListValue = DBJobVersionTemplateDetailListValues.SingleOrDefault(Function(Entity) Entity.ID = JobVersionTemplateDetailListValue.ID)

                        If DBJobVersionTemplateDetailListValue IsNot Nothing Then

                            DBJobVersionTemplateDetailListValue.Value = JobVersionTemplateDetailListValue.Value

                            AdvantageFramework.Database.Procedures.JobVersionTemplateDetailListValue.Update(DataContext, DBJobVersionTemplateDetailListValue)

                        End If

                    Next

                End Using

            Catch ex As Exception

            End Try

        End Sub
        Private Sub EnableOrDisableActions()

            DataGridViewForm_JobVersionTemplateListValues.Enabled = ComboBoxForm_List.HasASelectedValue
            ButtonForm_Delete.Enabled = DataGridViewForm_JobVersionTemplateListValues.HasOnlyOneSelectedRow AndAlso DataGridViewForm_JobVersionTemplateListValues.Enabled

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal JobVersionTemplateDetailID As Long) As System.Windows.Forms.DialogResult

            'objects
            Dim JobVersionDetailListEditDialog As AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobVersionDetailListEditDialog = Nothing

            JobVersionDetailListEditDialog = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobVersionDetailListEditDialog(JobVersionTemplateDetailID)

            ShowFormDialog = JobVersionDetailListEditDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub JobVersionDetailListEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim JobVersionTemplateDetail As AdvantageFramework.Database.Entities.JobVersionTemplateDetail = Nothing
            Dim JobVersionDatabaseTypeIDs As Integer() = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                JobVersionTemplateDetail = AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.LoadByJobVersionTemplateDetailID(DbContext, _JobVersionTemplateDetailID)

                If JobVersionTemplateDetail IsNot Nothing Then

                    Me.FormAction = WinForm.Presentation.FormActions.Loading

                    ComboBoxForm_List.SetPropertySettings(AdvantageFramework.Database.Entities.JobVersionTemplateDetail.Properties.ID)

                    ComboBoxForm_List.Enabled = False

                    JobVersionDatabaseTypeIDs = (From Entity In AdvantageFramework.Database.Procedures.JobVersionDatabaseType.Load(DbContext)
                                                 Where Entity.IsList = 1
                                                 Select Entity.ID).ToArray

                    ComboBoxForm_List.DataSource = (From Entity In AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.Load(DbContext)
                                                    Where JobVersionDatabaseTypeIDs.Contains(Entity.DatabaseTypeID)
                                                    Select Entity).ToList

                    Try

                        ComboBoxForm_List.SelectedValue = JobVersionTemplateDetail.ID

                    Catch ex As Exception

                    End Try

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.None

                    EnableOrDisableActions()

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Error loading job version template detail.")

                    Me.DialogResult = Windows.Forms.DialogResult.None
                    Me.Close()

                End If

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_OK.Click

            Dim JobVersionTemplateDetailListValues As Generic.List(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue) = Nothing
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                Me.ShowWaitForm("Processing...")

                Try

                    SaveChanges()

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_JobVersionTemplateListValues_AddNewRowEvent(RowObject As Object) Handles DataGridViewForm_JobVersionTemplateListValues.AddNewRowEvent

            'objects
            Dim JobVersionTemplateDetailListValue As AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue Then

                If ComboBoxForm_List.HasASelectedValue Then

                    Me.ShowWaitForm("Processing...")

                    SaveChanges()

                    JobVersionTemplateDetailListValue = RowObject

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        JobVersionTemplateDetailListValue.DataContext = DataContext

                        JobVersionTemplateDetailListValue.JobVersionTemplateDetailID = ComboBoxForm_List.GetSelectedValue

                        AdvantageFramework.Database.Procedures.JobVersionTemplateDetailListValue.Insert(DataContext, JobVersionTemplateDetailListValue)

                        LoadGrid()

                    End Using

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonForm_Delete_Click(sender As System.Object, e As System.EventArgs) Handles ButtonForm_Delete.Click

            Dim JobVersionTemplateDetailListValue As AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue = Nothing
            Dim JobVersionTemplateDetailListValueID As Integer = Nothing

            If DataGridViewForm_JobVersionTemplateListValues.HasOnlyOneSelectedRow Then

                DataGridViewForm_JobVersionTemplateListValues.CurrentView.CloseEditorForUpdating()

                'If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                Me.ShowWaitForm("Processing...")

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        JobVersionTemplateDetailListValueID = DataGridViewForm_JobVersionTemplateListValues.CurrentView.GetRowCellValue(DataGridViewForm_JobVersionTemplateListValues.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue.Properties.ID.ToString)

                        JobVersionTemplateDetailListValue = AdvantageFramework.Database.Procedures.JobVersionTemplateDetailListValue.LoadByJobVersionTemplateDetailListValueID(DataContext, JobVersionTemplateDetailListValueID)

                    Catch ex As Exception
                        JobVersionTemplateDetailListValue = Nothing
                    End Try

                    If JobVersionTemplateDetailListValue IsNot Nothing Then

                        SaveChanges()

                        If AdvantageFramework.Database.Procedures.JobVersionTemplateDetailListValue.Delete(DataContext, JobVersionTemplateDetailListValue) Then

                            LoadGrid()

                        End If

                    End If

                End Using

                Me.CloseWaitForm()

                'End If

            End If

        End Sub
        Private Sub DataGridViewForm_JobVersionTemplateListValues_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewForm_JobVersionTemplateListValues.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ComboBoxForm_List_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_List.SelectedValueChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadGrid()
                EnableOrDisableActions()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace