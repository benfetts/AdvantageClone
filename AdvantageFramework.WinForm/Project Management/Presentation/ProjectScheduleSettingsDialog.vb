Namespace ProjectManagement.Presentation

    Public Class ProjectScheduleSettingsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "


#End Region

#Region " Properties "

#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

        End Sub
        Private Sub LoadGrid()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewForm_Settings.DataSource = AdvantageFramework.Database.Procedures.TrafficScheduleUserColumnComplexType.Load(DbContext, Me.Session.User.EmployeeCode, True, True, False).ToList

            End Using

            DataGridViewForm_Settings.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog() As System.Windows.Forms.DialogResult

            'objects
            Dim ProjectScheduleSettingsDialog As AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleSettingsDialog = Nothing

            ProjectScheduleSettingsDialog = New AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleSettingsDialog()

            ShowFormDialog = ProjectScheduleSettingsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ProjectScheduleSettingsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Loaded As Boolean = True

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Me.ShowUnsavedChangesOnFormClosing = False

            Try

                LoadGrid()

            Catch ex As Exception
                Loaded = False
            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

            If Loaded = False Then

                AdvantageFramework.Navigation.ShowMessageBox("There was a problem loading project schedule settings. Please contact software support.")

                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Close_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_Settings_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Settings.CellValueChangingEvent

            'objects
            Dim TrafficScheduleUserColumn As AdvantageFramework.Database.Classes.TrafficScheduleUserColumn = Nothing
            Dim ShowOnGrid As Boolean = False
            Dim ShowOnAddNew As Boolean = False

            If e.Column.FieldName = AdvantageFramework.Database.Classes.TrafficScheduleUserColumn.Properties.ShowOnGrid.ToString OrElse
                e.Column.FieldName = AdvantageFramework.Database.Classes.TrafficScheduleUserColumn.Properties.ShowOnAddNew.ToString Then

                Try

                    TrafficScheduleUserColumn = DataGridViewForm_Settings.CurrentView.GetRow(e.RowHandle)

                Catch ex As Exception
                    TrafficScheduleUserColumn = Nothing
                End Try

                If TrafficScheduleUserColumn IsNot Nothing Then

                    If e.Column.FieldName = AdvantageFramework.Database.Classes.TrafficScheduleUserColumn.Properties.ShowOnGrid.ToString Then

                        ShowOnGrid = CBool(e.Value)
                        ShowOnAddNew = CBool(TrafficScheduleUserColumn.ShowOnAddNew)

                    ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.TrafficScheduleUserColumn.Properties.ShowOnAddNew.ToString Then

                        ShowOnGrid = CBool(TrafficScheduleUserColumn.ShowOnGrid)
                        ShowOnAddNew = CBool(e.Value)

                    End If

                    Saved = AdvantageFramework.ProjectSchedule.SaveUserColumn(Session, TrafficScheduleUserColumn.ID, ShowOnGrid, ShowOnAddNew)

                    If Saved Then

                        If ShowOnGrid Then

                            If TrafficScheduleUserColumn.ID = 6 Then

                                For Each TrfScheduleUserColumn In (From Entity In DataGridViewForm_Settings.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.TrafficScheduleUserColumn)()
                                                                   Where Entity.ID = 8
                                                                   Select Entity).ToList

                                    TrfScheduleUserColumn.ShowOnGrid = "False"

                                Next

                                DataGridViewForm_Settings.CurrentView.RefreshData()

                            ElseIf TrafficScheduleUserColumn.ID = 8 Then

                                For Each TrfScheduleUserColumn In (From Entity In DataGridViewForm_Settings.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.TrafficScheduleUserColumn)()
                                                                   Where Entity.ID = 6 OrElse
                                                                         Entity.ID = 7
                                                                   Select Entity).ToList

                                    TrfScheduleUserColumn.ShowOnGrid = If(TrfScheduleUserColumn.ID = 6, "False", "True")

                                Next

                                DataGridViewForm_Settings.CurrentView.RefreshData()

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Settings_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_Settings.CustomRowCellEditEvent



        End Sub
        Private Sub DataGridViewForm_Settings_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Settings.DataSourceChangedEvent

            If DataGridViewForm_Settings.Columns.Count > 0 Then

                For Each GridColumn In DataGridViewForm_Settings.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                    If GridColumn.FieldName = AdvantageFramework.Database.Classes.TrafficScheduleUserColumn.Properties.ShowOnGrid.ToString Then

                        If TypeOf GridColumn.ColumnEdit Is DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit Then

                            CType(GridColumn.ColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).ValueChecked = "True"
                            CType(GridColumn.ColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).ValueUnchecked = "False"

                        End If

                    Else

                        GridColumn.OptionsColumn.AllowEdit = False

                    End If

                Next

                For Each TrafficScheduleUserColumn In DataGridViewForm_Settings.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.TrafficScheduleUserColumn)()

                    If TrafficScheduleUserColumn.Active = 3 Then

                        TrafficScheduleUserColumn.ShowOnAddNew = Convert.ToString(False)

                    End If

                Next

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace