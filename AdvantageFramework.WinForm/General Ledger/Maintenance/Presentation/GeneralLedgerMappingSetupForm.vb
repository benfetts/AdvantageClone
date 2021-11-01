Namespace GeneralLedger.Maintenance.Presentation

    Public Class GeneralLedgerMappingSetupForm

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

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            If ComboBoxRecordSource_RecordSource.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewForm_GLMapping.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerCrossReference.LoadByRecordSourceID(DbContext, CInt(ComboBoxRecordSource_RecordSource.GetSelectedValue)).ToList

                End Using

            Else

                DataGridViewForm_GLMapping.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerCrossReference)

            End If

            DataGridViewForm_GLMapping.CurrentView.BestFitColumns()

        End Sub
        Private Sub CheckForUnsavedChanges()

            If Me.CheckUserEntryChangedSetting Then

                DataGridViewForm_GLMapping.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    If Me.Validator Then

                        Me.ShowWaitForm("Saving...")
                        Me.FormAction = WinForm.Presentation.FormActions.Saving
                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                        Try

                            Save()

                        Catch ex As Exception

                        End Try

                        Me.CloseWaitForm()
                        Me.FormAction = WinForm.Presentation.FormActions.None
                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                        Me.ClearChanged()
                        Me.ClearValidations()

                    End If

                End If

            End If

        End Sub
        Private Sub Save()

            'objects
            Dim GeneralLedgerCrossReferences As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerCrossReference) = Nothing

            If DataGridViewForm_GLMapping.HasRows Then

                DataGridViewForm_GLMapping.CurrentView.CloseEditorForUpdating()

                GeneralLedgerCrossReferences = DataGridViewForm_GLMapping.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.GeneralLedgerCrossReference)().ToList

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each GeneralLedgerCrossReference In GeneralLedgerCrossReferences

                        AdvantageFramework.Database.Procedures.GeneralLedgerCrossReference.Update(DbContext, GeneralLedgerCrossReference)

                    Next

                End Using

            End If

        End Sub
        Private Sub LoadRecordSources(ByVal DbContext As AdvantageFramework.Database.DbContext)

            ComboBoxRecordSource_RecordSource.DataSource = AdvantageFramework.Database.Procedures.RecordSource.Load(DbContext).ToList

        End Sub
        Private Sub LoadRecordSources()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                LoadRecordSources(DbContext)

            End Using

        End Sub
        Private Sub EnableOrDisableActions()

            If ComboBoxRecordSource_RecordSource.HasASelectedValue Then

                DataGridViewForm_GLMapping.Enabled = True
                ButtonItemActions_Export.Enabled = True

                If DataGridViewForm_GLMapping.IsNewItemRow Then

                    ButtonItemActions_Cancel.Enabled = True
                    ButtonItemActions_Save.Enabled = False
                    ButtonItemActions_Delete.Enabled = False

                Else

                    ButtonItemActions_Cancel.Enabled = False
                    ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                    ButtonItemActions_Delete.Enabled = DataGridViewForm_GLMapping.HasASelectedRow

                End If

            Else

                DataGridViewForm_GLMapping.Enabled = False
                ButtonItemActions_Export.Enabled = False
                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim GeneralLedgerMappingSetupForm As Presentation.GeneralLedgerMappingSetupForm = Nothing

            GeneralLedgerMappingSetupForm = New Presentation.GeneralLedgerMappingSetupForm()

            GeneralLedgerMappingSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub GeneralLedgerMappingSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemRecordSource_Manage.Image = AdvantageFramework.My.Resources.RecordSourceImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ComboBoxRecordSource_RecordSource.ByPassUserEntryChanged = True

            DataGridViewForm_GLMapping.AutoFilterLookupColumns = True

            LoadRecordSources()

            LoadGrid()

            EnableOrDisableActions()

        End Sub
        Private Sub GeneralLedgerMappingSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = False

        End Sub
        Private Sub GeneralLedgerMappingSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemRecordSource_Manage_Click(sender As Object, e As EventArgs) Handles ButtonItemRecordSource_Manage.Click

            'objects
            Dim RecordSourceID As Integer = 0
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting AndAlso ButtonItemActions_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = False

                    Me.ShowWaitForm("Saving...")
                    Me.FormAction = WinForm.Presentation.FormActions.Saving
                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Save()

                        IsOkay = True

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                        IsOkay = False
                    End Try

                    Me.CloseWaitForm()
                    Me.FormAction = WinForm.Presentation.FormActions.None
                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                    If IsOkay Then

                        Me.ClearChanged()

                    End If

                    If IsOkay = False Then

                        If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                            IsOkay = True

                        End If

                    End If

                End If

            End If

            If IsOkay Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.RecordSource, False, False, Title:="Manage Record Sources") = Windows.Forms.DialogResult.OK Then

                    If ComboBoxRecordSource_RecordSource.HasASelectedValue Then

                        RecordSourceID = ComboBoxRecordSource_RecordSource.GetSelectedValue

                    End If

                    Me.ShowWaitForm("Loading...")
                    Me.FormAction = WinForm.Presentation.FormActions.Loading

                    Try

                        LoadRecordSources()

                        If RecordSourceID <> 0 Then

                            ComboBoxRecordSource_RecordSource.SelectedValue = RecordSourceID

                        End If

                    Catch ex As Exception

                    End Try

                    If ComboBoxRecordSource_RecordSource.HasASelectedValue Then

                        Try

                            LoadGrid()

                        Catch ex As Exception

                        End Try

                    End If

                    Me.CloseWaitForm()
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_GLMapping.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim IsOkay As Boolean = False

            Me.ShowWaitForm("Saving...")
            Me.FormAction = WinForm.Presentation.FormActions.Saving
            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

            Try

                Save()

                IsOkay = True

            Catch ex As Exception
                AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                IsOkay = False
            End Try

            Me.CloseWaitForm()
            Me.FormAction = WinForm.Presentation.FormActions.None
            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            If IsOkay Then

                Me.ClearChanged()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim GeneralLedgerCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerCrossReference = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_GLMapping.HasASelectedRow Then

                DataGridViewForm_GLMapping.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Deleting...")
                    Me.FormAction = WinForm.Presentation.FormActions.Deleting

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_GLMapping.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    GeneralLedgerCrossReference = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    GeneralLedgerCrossReference = Nothing
                                End Try

                                If GeneralLedgerCrossReference IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.GeneralLedgerCrossReference.Delete(DbContext, GeneralLedgerCrossReference) Then

                                        DataGridViewForm_GLMapping.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()
                    Me.FormAction = WinForm.Presentation.FormActions.None

                    If DataGridViewForm_GLMapping.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_GLMapping.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_GLMapping_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_GLMapping.InitNewRowEvent

            If TypeOf DataGridViewForm_GLMapping.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Entities.GeneralLedgerCrossReference Then

                DirectCast(DataGridViewForm_GLMapping.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.GeneralLedgerCrossReference).RecordSourceID = ComboBoxRecordSource_RecordSource.GetSelectedValue

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_GLMapping_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_GLMapping.AddNewRowEvent

            'objects
            Dim GeneralLedgerCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerCrossReference = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.GeneralLedgerCrossReference Then

                Me.ShowWaitForm("Adding...")
                Me.FormAction = WinForm.Presentation.FormActions.Adding

                Try

                    GeneralLedgerCrossReference = RowObject

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If GeneralLedgerCrossReference.IsEntityBeingAdded() Then

                            GeneralLedgerCrossReference.DbContext = DbContext

                            AdvantageFramework.Database.Procedures.GeneralLedgerCrossReference.Insert(DbContext, GeneralLedgerCrossReference)

                        End If

                    End Using

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()
                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub DataGridViewForm_GLMapping_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_GLMapping.CellValueChangedEvent

            'objects
            Dim GeneralLedgerCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerCrossReference = Nothing

            If TypeOf DataGridViewForm_GLMapping.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Entities.GeneralLedgerCrossReference Then

                GeneralLedgerCrossReference = DataGridViewForm_GLMapping.CurrentView.GetRow(e.RowHandle)

                If e.Column.FieldName = AdvantageFramework.Database.Entities.GeneralLedgerCrossReference.Properties.ClientCode.ToString Then

                    If e.Value Is Nothing Then

                        GeneralLedgerCrossReference.DivisionCode = Nothing
                        GeneralLedgerCrossReference.ProductCode = Nothing

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Database.Entities.GeneralLedgerCrossReference.Properties.DivisionCode.ToString Then

                    If e.Value Is Nothing Then

                        GeneralLedgerCrossReference.ProductCode = Nothing

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_GLMapping_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_GLMapping.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_GLMapping_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_GLMapping.ShownEditorEvent

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim BindingSource As Windows.Forms.BindingSource = Nothing
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing

            If TypeOf DataGridViewForm_GLMapping.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                GridLookUpEdit = DataGridViewForm_GLMapping.CurrentView.ActiveEditor

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    If DataGridViewForm_GLMapping.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.GeneralLedgerCrossReference.Properties.DivisionCode.ToString Then

                        ClientCode = DataGridViewForm_GLMapping.CurrentView.GetRowCellValue(DataGridViewForm_GLMapping.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.GeneralLedgerCrossReference.Properties.ClientCode.ToString)

                        If ClientCode IsNot Nothing AndAlso ClientCode <> "" Then

                            BindingSource = New System.Windows.Forms.BindingSource
                            BindingSource.DataSource = AdvantageFramework.Database.Procedures.Division.LoadByClientCode(DbContext, ClientCode).ToList

                            GridLookUpEdit.Properties.DataSource = BindingSource

                        Else

                            DataGridViewForm_GLMapping.CurrentView.CloseEditor()

                        End If

                    ElseIf DataGridViewForm_GLMapping.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.GeneralLedgerCrossReference.Properties.ProductCode.ToString Then

                        ClientCode = DataGridViewForm_GLMapping.CurrentView.GetRowCellValue(DataGridViewForm_GLMapping.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.GeneralLedgerCrossReference.Properties.ClientCode.ToString)
                        DivisionCode = DataGridViewForm_GLMapping.CurrentView.GetRowCellValue(DataGridViewForm_GLMapping.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.GeneralLedgerCrossReference.Properties.DivisionCode.ToString)

                        If DivisionCode IsNot Nothing AndAlso DivisionCode <> "" Then

                            BindingSource = New System.Windows.Forms.BindingSource
                            BindingSource.DataSource = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionCode).ToList

                            GridLookUpEdit.Properties.DataSource = BindingSource

                        Else

                            DataGridViewForm_GLMapping.CurrentView.CloseEditor()

                        End If

                    End If

                End Using

            End If

        End Sub
        Private Sub ComboBoxRecordSource_RecordSource_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxRecordSource_RecordSource.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                CheckForUnsavedChanges()

                Me.ShowWaitForm("Loading...")
                Me.FormAction = WinForm.Presentation.FormActions.Loading

                Try

                    LoadGrid()

                    EnableOrDisableActions()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()
                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace