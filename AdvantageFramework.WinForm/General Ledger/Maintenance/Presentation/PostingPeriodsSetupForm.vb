Namespace GeneralLedger.Maintenance.Presentation

    Public Class PostingPeriodsSetupForm

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

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                DataGridViewForm_PostingPeriods.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext).OrderByDescending(Function(PostPeriod) PostPeriod.Code).ToList.Select(Function(Entity) New AdvantageFramework.Database.Classes.PostPeriod(DbContext, Entity)).ToList

                DataGridViewForm_PostingPeriods.Columns(AdvantageFramework.Database.Classes.PostPeriod.Properties.Year.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                DataGridViewForm_PostingPeriods.Columns(AdvantageFramework.Database.Classes.PostPeriod.Properties.Year.ToString).SortIndex = 0
                DataGridViewForm_PostingPeriods.Columns(AdvantageFramework.Database.Classes.PostPeriod.Properties.Month.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                DataGridViewForm_PostingPeriods.Columns(AdvantageFramework.Database.Classes.PostPeriod.Properties.Month.ToString).SortIndex = 1

                DataGridViewForm_PostingPeriods.Columns(AdvantageFramework.Database.Classes.PostPeriod.Properties.EnteredDate.ToString).OptionsColumn.AllowFocus = False
                DataGridViewForm_PostingPeriods.Columns(AdvantageFramework.Database.Classes.PostPeriod.Properties.ModifiedDate.ToString).OptionsColumn.AllowFocus = False
                DataGridViewForm_PostingPeriods.Columns(AdvantageFramework.Database.Classes.PostPeriod.Properties.UserCode.ToString).OptionsColumn.AllowFocus = False

                DbContext.Database.Connection.Close()

            End Using

            DataGridViewForm_PostingPeriods.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_PostingPeriods.IsNewItemRow Then

                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False
                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Export.Enabled = False
                ButtonItemStatus_MarkOpen.Enabled = False
                ButtonItemStatuses_MarkClosed.Enabled = False
                ButtonItemStatuses_MarkCurrent.Enabled = False

            Else

                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_PostingPeriods.HasASelectedRow
                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Export.Enabled = DataGridViewForm_PostingPeriods.HasRows
                ButtonItemStatus_MarkOpen.Enabled = DataGridViewForm_PostingPeriods.HasASelectedRow
                ButtonItemStatuses_MarkClosed.Enabled = DataGridViewForm_PostingPeriods.HasASelectedRow
                ButtonItemStatuses_MarkCurrent.Enabled = DataGridViewForm_PostingPeriods.HasOnlyOneSelectedRow

            End If

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Public Function Save() As Boolean

            'objects
            Dim Saved As Boolean = True
            Dim PostPeriods As Generic.List(Of AdvantageFramework.Database.Classes.PostPeriod) = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Try

                If DataGridViewForm_PostingPeriods.HasRows Then

                    DataGridViewForm_PostingPeriods.CurrentView.CloseEditorForUpdating()

                    PostPeriods = DataGridViewForm_PostingPeriods.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.PostPeriod)().ToList

                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Saving...")
                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each PostPeriodClass In PostPeriods

                                PostPeriod = PostPeriodClass.GetEntity

                                If AdvantageFramework.Database.Procedures.PostPeriod.Update(DbContext, PostPeriod) = False Then

                                    Saved = False

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                    Try

                        DataGridViewForm_PostingPeriods.ValidateAllRowsAndClearChanged(True)

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            Catch ex As Exception
                Saved = False
            Finally
                Save = Saved
            End Try

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim PostingPeriodsSetupForm As Presentation.PostingPeriodsSetupForm = Nothing

            PostingPeriodsSetupForm = New Presentation.PostingPeriodsSetupForm()

            PostingPeriodsSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub PostingPeriodsSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig = Nothing
            Dim PostPeriodFormatDescription As String = Nothing
            Dim PostPeriodFiscalYearFormatDescription As String = Nothing

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            DataGridViewForm_Export.Visible = False
            DataGridViewForm_PostingPeriods.OptionsCustomization.AllowSort = False
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemStatus_MarkOpen.Image = AdvantageFramework.My.Resources.PostPeriodOpenImage
            ButtonItemStatuses_MarkCurrent.Image = AdvantageFramework.My.Resources.PostPeriodCurrentImage
            ButtonItemStatuses_MarkClosed.Image = AdvantageFramework.My.Resources.PostPeriodClosedImage

            ComboBoxForm_FiscalYearStartMonth.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                GeneralLedgerConfig = AdvantageFramework.Database.Procedures.GeneralLedgerConfig.Load(DbContext)

                ComboBoxForm_FiscalYearStartMonth.SelectedValue = CLng(GeneralLedgerConfig.FiscalYearStartMonth.GetValueOrDefault(0))

                Select Case GeneralLedgerConfig.PostingPeriodFormat

                    Case AdvantageFramework.Database.Entities.PostPeriodFormats.MMEqualToCalendarMonth

                        PostPeriodFormatDescription = "MM is equal to calendar month"

                    Case AdvantageFramework.Database.Entities.PostPeriodFormats.MMNotEqualToCalendarMonth

                        PostPeriodFormatDescription = "MM does not equal calendar month"

                    Case Else

                        PostPeriodFormatDescription = "MM is equal to calendar month"

                End Select

                Select Case GeneralLedgerConfig.PostingPeriodYear

                    Case AdvantageFramework.Database.Entities.PostPeriodFiscalYearFormats.FiscalYearBeginsInCurrentCalendarYear

                        PostPeriodFiscalYearFormatDescription = "Fiscal year starts in current calendar year"

                    Case AdvantageFramework.Database.Entities.PostPeriodFiscalYearFormats.FiscalYearBeginsInPreviousCalendarYear

                        PostPeriodFiscalYearFormatDescription = "Fiscal year starts in previous calendar year"

                    Case Else

                        PostPeriodFiscalYearFormatDescription = "Posting periods are based on a calendar year"

                End Select

                LabelForm_Format.Text = "YYYYMM:"
                LabelForm_FormatDescription.Text = PostPeriodFiscalYearFormatDescription & " - " & PostPeriodFormatDescription

            End Using

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub PostingPeriodsSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub PostingPeriodsSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            'objects
            Dim LoadFromDatabase As Boolean = False

            Try

                DataGridViewForm_Export.DataSource = CType(DataGridViewForm_PostingPeriods.CurrentView.DataSource, System.Windows.Forms.BindingSource).DataSource

            Catch ex As Exception
                LoadFromDatabase = True
            End Try

            If LoadFromDatabase Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    DataGridViewForm_Export.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext).OrderByDescending(Function(PostPeriod) PostPeriod.Code).ToList.Select(Function(Entity) New AdvantageFramework.Database.Classes.PostPeriod(DbContext, Entity)).ToList

                    DbContext.Database.Connection.Close()

                End Using

            End If

            DataGridViewForm_Export.Columns(AdvantageFramework.Database.Classes.PostPeriod.Properties.Year.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Descending
            DataGridViewForm_Export.Columns(AdvantageFramework.Database.Classes.PostPeriod.Properties.Year.ToString).SortIndex = 0
            DataGridViewForm_Export.Columns(AdvantageFramework.Database.Classes.PostPeriod.Properties.Month.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            DataGridViewForm_Export.Columns(AdvantageFramework.Database.Classes.PostPeriod.Properties.Month.ToString).SortIndex = 1

            DataGridViewForm_Export.HideOrShowColumn(AdvantageFramework.Database.Classes.PostPeriod.Properties.EmployeeTimeStatus.ToString, False)
            DataGridViewForm_Export.HideOrShowColumn(AdvantageFramework.Database.Classes.PostPeriod.Properties.Month.ToString, False)
            DataGridViewForm_Export.HideOrShowColumn(AdvantageFramework.Database.Classes.PostPeriod.Properties.Year.ToString, False)
            DataGridViewForm_Export.HideOrShowColumn(AdvantageFramework.Database.Classes.PostPeriod.Properties.EnteredDate.ToString, False)
            DataGridViewForm_Export.HideOrShowColumn(AdvantageFramework.Database.Classes.PostPeriod.Properties.ModifiedDate.ToString, False)
            DataGridViewForm_Export.HideOrShowColumn(AdvantageFramework.Database.Classes.PostPeriod.Properties.UserCode.ToString, False)
            DataGridViewForm_Export.HideOrShowColumn(AdvantageFramework.Database.Classes.PostPeriod.Properties.UnpostedJournalEntry.ToString, False)

            DataGridViewForm_Export.CurrentView.AFActiveFilterString = DataGridViewForm_PostingPeriods.CurrentView.AFActiveFilterString

            DataGridViewForm_Export.CurrentView.BestFitColumns()

            DataGridViewForm_Export.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim PostPeriodClass As AdvantageFramework.Database.Classes.PostPeriod = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing
            Dim ErrorMessage As String = Nothing

            If DataGridViewForm_PostingPeriods.HasASelectedRow Then

                DataGridViewForm_PostingPeriods.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_PostingPeriods.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    PostPeriodClass = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    PostPeriodClass = Nothing
                                End Try

                                If PostPeriodClass IsNot Nothing Then

                                    PostPeriod = PostPeriodClass.GetEntity

                                    If AdvantageFramework.Database.Procedures.PostPeriod.Delete(DbContext, PostPeriod) Then

                                        DataGridViewForm_PostingPeriods.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    Else

                                        If DataGridViewForm_PostingPeriods.HasOnlyOneSelectedRow Then

                                            ErrorMessage = "Post period is in use and cannot be deleted."

                                        Else

                                            ErrorMessage = "One or more of the selected post periods are in use and cannot be deleted."

                                        End If

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If String.IsNullOrEmpty(ErrorMessage) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                    If DataGridViewForm_PostingPeriods.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_PostingPeriods_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_PostingPeriods.CellValueChangedEvent

            'objects
            Dim PostPeriod As AdvantageFramework.Database.Classes.PostPeriod = Nothing
            Dim SelectedPostPeriod As AdvantageFramework.Database.Classes.PostPeriod = Nothing
            Dim Modified As Boolean = False

            If e.Column.FieldName = AdvantageFramework.Database.Classes.PostPeriod.Properties.GLStatus.ToString OrElse
               e.Column.FieldName = AdvantageFramework.Database.Classes.PostPeriod.Properties.ARStatus.ToString OrElse
               e.Column.FieldName = AdvantageFramework.Database.Classes.PostPeriod.Properties.APStatus.ToString OrElse
               e.Column.FieldName = AdvantageFramework.Database.Classes.PostPeriod.Properties.EmployeeTimeStatus.ToString Then

                If e.Value = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.PostPeriodStatus.Current).Code Then

                    Try

                        For Each PostPeriod In (From Entity In DataGridViewForm_PostingPeriods.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.PostPeriod).ToList
                                                Where Entity.Code <> DataGridViewForm_PostingPeriods.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PostPeriod.Properties.Code.ToString).ToString
                                                Select Entity).ToList

                            Modified = False

                            Select Case e.Column.FieldName

                                Case AdvantageFramework.Database.Classes.PostPeriod.Properties.GLStatus.ToString

                                    If PostPeriod.GLStatus = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.PostPeriodStatus.Current).Code Then

                                        PostPeriod.GLStatus = Nothing
                                        Modified = True

                                    End If

                                Case AdvantageFramework.Database.Classes.PostPeriod.Properties.ARStatus.ToString

                                    If PostPeriod.ARStatus = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.PostPeriodStatus.Current).Code Then

                                        PostPeriod.ARStatus = Nothing
                                        Modified = True

                                    End If

                                Case AdvantageFramework.Database.Classes.PostPeriod.Properties.APStatus.ToString

                                    If PostPeriod.APStatus = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.PostPeriodStatus.Current).Code Then

                                        PostPeriod.APStatus = Nothing
                                        Modified = True

                                    End If

                                Case AdvantageFramework.Database.Classes.PostPeriod.Properties.EmployeeTimeStatus.ToString

                                    If PostPeriod.EmployeeTimeStatus = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.PostPeriodStatus.Current).Code Then

                                        PostPeriod.EmployeeTimeStatus = Nothing
                                        Modified = True

                                    End If

                            End Select

                            If Modified = True Then

                                PostPeriod.ModifiedDate = System.DateTime.Today
                                DataGridViewForm_PostingPeriods.CurrentView.RefreshData()

                            End If

                        Next

                    Catch ex As Exception

                    End Try

                End If

            End If

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then

                Try

                    SelectedPostPeriod = DataGridViewForm_PostingPeriods.CurrentView.GetRow(e.RowHandle)

                Catch ex As Exception
                    SelectedPostPeriod = Nothing
                End Try

                If SelectedPostPeriod IsNot Nothing Then

                    Try

                        SelectedPostPeriod.ModifiedDate = System.DateTime.Today

                    Catch ex As Exception
                        SelectedPostPeriod.ModifiedDate = SelectedPostPeriod.ModifiedDate
                    End Try

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_PostingPeriods_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_PostingPeriods.AddNewRowEvent

            'objects
            Dim PostPeriodClass As AdvantageFramework.Database.Classes.PostPeriod = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.PostPeriod Then

                Me.ShowWaitForm("Processing...")

                PostPeriodClass = RowObject

                PostPeriod = PostPeriodClass.GetEntity

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If PostPeriod.IsEntityBeingAdded() Then

                        PostPeriod.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.PostPeriod.Insert(DbContext, PostPeriod)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_PostingPeriods_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewForm_PostingPeriods.ValidatingEditorEvent

            'objects
            Dim PostPeriod As AdvantageFramework.Database.Classes.PostPeriod = Nothing
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing

            If DataGridViewForm_PostingPeriods.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.PostPeriod.Properties.GLStatus.ToString Then

                If e.Value = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.PostPeriodStatus.Closed).Code Then

                    Try

                        PostPeriod = DataGridViewForm_PostingPeriods.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        PostPeriod = Nothing
                    End Try

                    Try

                        GridLookUpEdit = DirectCast(DataGridViewForm_PostingPeriods.CurrentView.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit)

                    Catch ex As Exception

                    End Try

                    If PostPeriod IsNot Nothing AndAlso PostPeriod.UnpostedJournalEntry Then

                        AdvantageFramework.Navigation.ShowMessageBox("There are journal entries that have not been posted to summary for this posting period. Unable to mark as closed.")
                        e.Value = GridLookUpEdit.OldEditValue

                        'Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        '    If (From Entity In AdvantageFramework.Database.Procedures.GeneralLedger.Load(DbContext) _
                        '        Where Entity.PostPeriodCode = PostPeriod.Code AndAlso _
                        '              (Entity.PostedDate Is Nothing OrElse _
                        '               Entity.IsVoided <> 1) _
                        '        Select Entity).Any Then

                        '    End If

                        'End Using

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_PostingPeriods_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewForm_PostingPeriods.CustomDrawCellEvent

            If e.Column.FieldName = AdvantageFramework.Database.Classes.PostPeriod.Properties.GLStatus.ToString OrElse
               e.Column.FieldName = AdvantageFramework.Database.Classes.PostPeriod.Properties.ARStatus.ToString OrElse
               e.Column.FieldName = AdvantageFramework.Database.Classes.PostPeriod.Properties.APStatus.ToString OrElse
               e.Column.FieldName = AdvantageFramework.Database.Classes.PostPeriod.Properties.EmployeeTimeStatus.ToString Then

                If e.CellValue Is Nothing OrElse e.CellValue.ToString = "" Then 'Open

                    e.Appearance.ForeColor = Drawing.Color.Black

                ElseIf e.CellValue.ToString.ToUpper = "X" Then 'Closed

                    e.Appearance.ForeColor = Drawing.Color.Red

                ElseIf e.CellValue.ToString.ToUpper = "C" Then ' Current

                    e.Appearance.ForeColor = Drawing.Color.Green

                Else

                    e.Appearance.ForeColor = Drawing.Color.Black

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_PostingPeriods_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_PostingPeriods.InitNewRowEvent

            DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PostPeriod.Properties.UserCode.ToString, Me.Session.UserCode)
            DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PostPeriod.Properties.EnteredDate.ToString, System.DateTime.Today)

        End Sub
        Private Sub DataGridViewForm_PostingPeriods_NewItemRowCellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_PostingPeriods.NewItemRowCellValueChangedEvent

            'objects
            Dim GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig = Nothing
            Dim CodeYear As Integer = Nothing
            Dim CodeMonth As String = Nothing
            Dim ActualMonth As Integer = Nothing
            Dim DateYear As Integer = Nothing
            Dim FiscalMonth As Integer = Nothing
            Dim FiscalYear As Integer = Nothing
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim Description As String = Nothing

            If e.Column.FieldName = AdvantageFramework.Database.Classes.PostPeriod.Properties.Code.ToString Then

                If e.Value IsNot Nothing Then

                    If e.Value.ToString.Length = 6 Then

                        CodeYear = CInt(e.Value.ToString.Substring(0, 4))
                        CodeMonth = e.Value.ToString.Substring(4, 2)
                        FiscalYear = CodeYear
                        DateYear = CodeYear

                        If CodeMonth = "YE" Then

                            DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PostPeriod.Properties.ARStatus.ToString, AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.PostPeriodStatus.Closed).Code)
                            DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PostPeriod.Properties.APStatus.ToString, AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.PostPeriodStatus.Closed).Code)
                            DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PostPeriod.Properties.EmployeeTimeStatus.ToString, AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.PostPeriodStatus.Closed).Code)
                            DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PostPeriod.Properties.Month.ToString, 99)
                            DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PostPeriod.Properties.Year.ToString, CodeYear)
                            DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PostPeriod.Properties.Description.ToString, "Year End")
                            DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PostPeriod.Properties.EndDate.ToString, Nothing)
                            DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PostPeriod.Properties.StartDate.ToString, Nothing)

                        ElseIf IsNumeric(CodeMonth) = True Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                GeneralLedgerConfig = AdvantageFramework.Database.Procedures.GeneralLedgerConfig.Load(DbContext)

                                If GeneralLedgerConfig.FiscalYearStartMonth <> CLng(AdvantageFramework.DateUtilities.Months.January) Then

                                    FiscalYear = CodeYear
                                    DateYear = CodeYear

                                    If GeneralLedgerConfig.PostingPeriodFormat = AdvantageFramework.Database.Entities.PostPeriodFormats.MMEqualToCalendarMonth Then

                                        ActualMonth = CInt(CodeMonth)

                                        If CLng(CodeMonth) >= GeneralLedgerConfig.FiscalYearStartMonth Then

                                            FiscalMonth = CInt(CodeMonth) - GeneralLedgerConfig.FiscalYearStartMonth + 1

                                        Else

                                            FiscalMonth = CInt(CodeMonth) - GeneralLedgerConfig.FiscalYearStartMonth + 13

                                        End If

                                        If GeneralLedgerConfig.PostingPeriodYear = AdvantageFramework.Database.Entities.PostPeriodFiscalYearFormats.FiscalYearBeginsInPreviousCalendarYear Then

                                            If CInt(CodeMonth) >= GeneralLedgerConfig.FiscalYearStartMonth Then

                                                FiscalYear = CodeYear + 1

                                            End If

                                        ElseIf GeneralLedgerConfig.PostingPeriodYear = AdvantageFramework.Database.Entities.PostPeriodFiscalYearFormats.FiscalYearBeginsInCurrentCalendarYear Then

                                            If CInt(CodeMonth) < GeneralLedgerConfig.FiscalYearStartMonth Then

                                                FiscalYear = CodeYear - 1

                                            End If

                                        End If

                                    ElseIf GeneralLedgerConfig.PostingPeriodFormat = AdvantageFramework.Database.Entities.PostPeriodFormats.MMNotEqualToCalendarMonth Then

                                        ActualMonth = GeneralLedgerConfig.FiscalYearStartMonth + CInt(CodeMonth) - 1

                                        If ActualMonth > 12 Then

                                            ActualMonth = ActualMonth - 12

                                        End If

                                        FiscalMonth = CInt(CodeMonth)

                                        If GeneralLedgerConfig.PostingPeriodYear = AdvantageFramework.Database.Entities.PostPeriodFiscalYearFormats.FiscalYearBeginsInPreviousCalendarYear Then

                                            If ActualMonth >= GeneralLedgerConfig.FiscalYearStartMonth Then

                                                DateYear = DateYear - 1

                                            End If

                                        ElseIf GeneralLedgerConfig.PostingPeriodYear = AdvantageFramework.Database.Entities.PostPeriodFiscalYearFormats.FiscalYearBeginsInCurrentCalendarYear Then

                                            If ActualMonth < GeneralLedgerConfig.FiscalYearStartMonth Then

                                                DateYear = DateYear + 1

                                            End If

                                        End If

                                    End If

                                Else

                                    ActualMonth = CInt(CodeMonth)
                                    DateYear = CodeYear
                                    FiscalYear = CodeYear
                                    FiscalMonth = CInt(CodeMonth)

                                End If

                                Try

                                    StartDate = New System.DateTime(DateYear, ActualMonth, 1)
                                    EndDate = New System.DateTime(DateYear, ActualMonth, 1).AddMonths(1).AddDays(-1)
                                    Description = [Enum].GetName(GetType(AdvantageFramework.DateUtilities.Months), CLng(ActualMonth))

                                Catch ex As Exception
                                    StartDate = Nothing
                                    EndDate = Nothing
                                    Description = ""
                                End Try

                                DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PostPeriod.Properties.StartDate.ToString, StartDate)
                                DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PostPeriod.Properties.EndDate.ToString, EndDate)
                                DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PostPeriod.Properties.Month.ToString, FiscalMonth)
                                DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PostPeriod.Properties.Year.ToString, FiscalYear)
                                DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PostPeriod.Properties.Description.ToString, Description)

                            End Using

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_PostingPeriods_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_PostingPeriods.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            If CheckForUnsavedChanges() Then

                If AdvantageFramework.GeneralLedger.Maintenance.Presentation.CreatePostPeriodDialog.ShowFormDialog() = Windows.Forms.DialogResult.OK Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading, "Loading...")

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewForm_PostingPeriods.ValidateAllRowsAndClearChanged(True)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_PostingPeriods.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_PostingPeriods_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_PostingPeriods.ShowingEditorEvent

            'objects
            Dim PostPeriodCode As String = Nothing
            Dim PostPeriodMonth As String = Nothing
            Dim FocusedColumnFieldName As String = Nothing

            FocusedColumnFieldName = DataGridViewForm_PostingPeriods.CurrentView.FocusedColumn.FieldName

            If FocusedColumnFieldName = AdvantageFramework.Database.Classes.PostPeriod.Properties.ARStatus.ToString OrElse
               FocusedColumnFieldName = AdvantageFramework.Database.Classes.PostPeriod.Properties.APStatus.ToString OrElse
               FocusedColumnFieldName = AdvantageFramework.Database.Classes.PostPeriod.Properties.EndDate.ToString OrElse
               FocusedColumnFieldName = AdvantageFramework.Database.Classes.PostPeriod.Properties.StartDate.ToString Then

                Try

                    PostPeriodCode = DataGridViewForm_PostingPeriods.CurrentView.GetRowCellValue(DataGridViewForm_PostingPeriods.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.PostPeriod.Properties.Code.ToString).ToString

                    If PostPeriodCode IsNot Nothing Then

                        PostPeriodMonth = PostPeriodCode.Substring(4, 2)

                        If PostPeriodMonth = "YE" Then

                            e.Cancel = True

                        End If

                    End If

                Catch ex As Exception
                    PostPeriodCode = Nothing
                End Try

            End If

        End Sub
        Private Sub ButtonItemStatus_MarkOpen_Click(sender As Object, e As EventArgs) Handles ButtonItemStatus_MarkOpen.Click

            'objects
            Dim PostPeriod As AdvantageFramework.Database.Classes.PostPeriod = Nothing
            Dim CanUpdateARandARStatus As Boolean = True
            Dim StatusCode As String = Nothing

            StatusCode = Nothing 'AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.PostPeriodStatus.Open).Code

            For Each RowsRowHandlesAndDataBoundItem In DataGridViewForm_PostingPeriods.GetAllSelectedRowsRowHandlesAndDataBoundItems

                Try

                    PostPeriod = DirectCast(RowsRowHandlesAndDataBoundItem.Value, AdvantageFramework.Database.Classes.PostPeriod)

                Catch ex As Exception
                    PostPeriod = Nothing
                End Try

                If PostPeriod IsNot Nothing Then

                    If PostPeriod.Code.Substring(4, 2) = "YE" Then

                        CanUpdateARandARStatus = False

                    End If

                    DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(RowsRowHandlesAndDataBoundItem.Key, AdvantageFramework.Database.Classes.PostPeriod.Properties.GLStatus.ToString, StatusCode)

                    If CanUpdateARandARStatus Then

                        DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(RowsRowHandlesAndDataBoundItem.Key, AdvantageFramework.Database.Classes.PostPeriod.Properties.ARStatus.ToString, StatusCode)
                        DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(RowsRowHandlesAndDataBoundItem.Key, AdvantageFramework.Database.Classes.PostPeriod.Properties.APStatus.ToString, StatusCode)

                    End If

                    DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(RowsRowHandlesAndDataBoundItem.Key, AdvantageFramework.Database.Classes.PostPeriod.Properties.EmployeeTimeStatus.ToString, StatusCode)

                End If

            Next

            DataGridViewForm_PostingPeriods.SetUserEntryChanged()

        End Sub
        Private Sub ButtonItemStatuses_MarkCurrent_Click(sender As Object, e As EventArgs) Handles ButtonItemStatuses_MarkCurrent.Click

            'objects
            Dim PostPeriod As AdvantageFramework.Database.Classes.PostPeriod = Nothing
            Dim CanUpdateARandARStatus As Boolean = True
            Dim StatusCode As String = Nothing

            Try

                PostPeriod = DataGridViewForm_PostingPeriods.GetFirstSelectedRowDataBoundItem

            Catch ex As Exception
                PostPeriod = Nothing
            End Try

            If PostPeriod IsNot Nothing Then

                StatusCode = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.PostPeriodStatus.Current).Code

                If PostPeriod.Code.Substring(4, 2) = "YE" Then

                    CanUpdateARandARStatus = False

                End If

                DataGridViewForm_PostingPeriods.CurrentView.SetFocusedRowCellValue(AdvantageFramework.Database.Classes.PostPeriod.Properties.GLStatus.ToString, StatusCode)

                If CanUpdateARandARStatus Then

                    DataGridViewForm_PostingPeriods.CurrentView.SetFocusedRowCellValue(AdvantageFramework.Database.Classes.PostPeriod.Properties.ARStatus.ToString, StatusCode)
                    DataGridViewForm_PostingPeriods.CurrentView.SetFocusedRowCellValue(AdvantageFramework.Database.Classes.PostPeriod.Properties.APStatus.ToString, StatusCode)

                End If

                DataGridViewForm_PostingPeriods.CurrentView.SetFocusedRowCellValue(AdvantageFramework.Database.Classes.PostPeriod.Properties.EmployeeTimeStatus.ToString, StatusCode)

            End If

            DataGridViewForm_PostingPeriods.SetUserEntryChanged()

        End Sub
        Private Sub ButtonItemStatuses_MarkClosed_Click(sender As Object, e As EventArgs) Handles ButtonItemStatuses_MarkClosed.Click

            'objects
            Dim PostPeriod As AdvantageFramework.Database.Classes.PostPeriod = Nothing
            Dim CanUpdateGLStatus As Boolean = True
            Dim StatusCode As String = Nothing

            StatusCode = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.PostPeriodStatus.Closed).Code

            For Each RowsRowHandlesAndDataBoundItem In DataGridViewForm_PostingPeriods.GetAllSelectedRowsRowHandlesAndDataBoundItems

                Try

                    PostPeriod = DirectCast(RowsRowHandlesAndDataBoundItem.Value, AdvantageFramework.Database.Classes.PostPeriod)

                Catch ex As Exception
                    PostPeriod = Nothing
                End Try

                If PostPeriod IsNot Nothing Then

                    If PostPeriod.UnpostedJournalEntry = False Then

                        DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(RowsRowHandlesAndDataBoundItem.Key, AdvantageFramework.Database.Classes.PostPeriod.Properties.GLStatus.ToString, StatusCode)

                    End If

                    DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(RowsRowHandlesAndDataBoundItem.Key, AdvantageFramework.Database.Classes.PostPeriod.Properties.ARStatus.ToString, StatusCode)
                    DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(RowsRowHandlesAndDataBoundItem.Key, AdvantageFramework.Database.Classes.PostPeriod.Properties.APStatus.ToString, StatusCode)
                    DataGridViewForm_PostingPeriods.CurrentView.SetRowCellValue(RowsRowHandlesAndDataBoundItem.Key, AdvantageFramework.Database.Classes.PostPeriod.Properties.EmployeeTimeStatus.ToString, StatusCode)

                End If

            Next

            DataGridViewForm_PostingPeriods.SetUserEntryChanged()

        End Sub

#End Region

#End Region

    End Class

End Namespace
