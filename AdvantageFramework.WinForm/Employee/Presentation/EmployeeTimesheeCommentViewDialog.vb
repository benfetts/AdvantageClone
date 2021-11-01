Namespace Employee.Presentation

    Public Class EmployeeTimesheeCommentViewDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _StartDate As Date = Nothing
        Private _EndDate As Date = Nothing
        Private _EmployeeCode As String = Nothing
        Private _UseProductCategory As Boolean = False

#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New(ByVal EmployeeCode As String, ByVal StartDate As String, ByVal EndDate As String)

            ' This call is required by the designer.
            InitializeComponent()

            _EmployeeCode = EmployeeCode
            _StartDate = StartDate
            _EndDate = EndDate

        End Sub
        Private Sub LoadTimesheetSettings()

            'objects
            Dim UserDaysToDisplay As Short = Nothing
            Dim UserStartWeekOn As String = Nothing
            Dim UserShowCommentsUsing As String = Nothing
            Dim UserMainTimesheetNoPaging As Boolean = Nothing
            Dim UserDivision As String = Nothing
            Dim UserProduct As String = Nothing
            Dim UserProductCategory As String = Nothing
            Dim UserJob As String = Nothing
            Dim UserJobComp As String = Nothing
            Dim UserFunctionCategory As String = Nothing
            Dim CommentsRequired As Boolean = False

            AdvantageFramework.EmployeeTimesheet.LoadTimesheetSettings(Me.Session, Me.Session.UserCode, UserDaysToDisplay, UserStartWeekOn,
                                                                       UserShowCommentsUsing, UserMainTimesheetNoPaging, UserDivision, UserProduct,
                                                                       UserProductCategory, UserJob, UserJobComp, UserFunctionCategory, CommentsRequired)

            If PropertyGridControlLeftSection_HeaderData.GetRowByFieldName(AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.DivisionCode.ToString) IsNot Nothing Then

                PropertyGridControlLeftSection_HeaderData.GetRowByFieldName(AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.DivisionCode.ToString).Properties.Caption = UserDivision

            End If

            If PropertyGridControlLeftSection_HeaderData.GetRowByFieldName(AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.ProductCode.ToString) IsNot Nothing Then

                PropertyGridControlLeftSection_HeaderData.GetRowByFieldName(AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.ProductCode.ToString).Properties.Caption = UserProduct

            End If

            If PropertyGridControlLeftSection_HeaderData.GetRowByFieldName(AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.ProductCategoryCode.ToString) IsNot Nothing Then

                PropertyGridControlLeftSection_HeaderData.GetRowByFieldName(AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.ProductCategoryCode.ToString).Properties.Caption = UserProductCategory

            End If

            If PropertyGridControlLeftSection_HeaderData.GetRowByFieldName(AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.JobNumber.ToString) IsNot Nothing Then

                PropertyGridControlLeftSection_HeaderData.GetRowByFieldName(AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.JobNumber.ToString).Properties.Caption = UserJob

            End If

            If PropertyGridControlLeftSection_HeaderData.GetRowByFieldName(AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.JobComponentNumber.ToString) IsNot Nothing Then

                PropertyGridControlLeftSection_HeaderData.GetRowByFieldName(AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.JobComponentNumber.ToString).Properties.Caption = UserJobComp

            End If

            If PropertyGridControlLeftSection_HeaderData.GetRowByFieldName(AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.FunctionCode.ToString) IsNot Nothing Then

                PropertyGridControlLeftSection_HeaderData.GetRowByFieldName(AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.FunctionCode.ToString).Properties.Caption = UserFunctionCategory

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal EmployeeCode As String, ByVal StartDate As Date, ByVal EndDate As Date) As System.Windows.Forms.DialogResult

            'objects
            Dim EmployeeTimesheeCommentViewDialog As AdvantageFramework.Employee.Presentation.EmployeeTimesheeCommentViewDialog = Nothing

            EmployeeTimesheeCommentViewDialog = New AdvantageFramework.Employee.Presentation.EmployeeTimesheeCommentViewDialog(EmployeeCode, StartDate, EndDate)

            ShowFormDialog = EmployeeTimesheeCommentViewDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub RowPreviewHandler(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CalcPreviewTextEventArgs)

            'objects
            Dim CommentView As AdvantageFramework.EmployeeTimesheet.Classes.CommentView = Nothing

            Try

                CommentView = DataGridViewForm_Comments.CurrentView.GetRow(e.RowHandle)

            Catch ex As Exception
                CommentView = Nothing
            End Try

            If CommentView IsNot Nothing Then

                If CommentView.DayStatus <> EmployeeTimesheet.DayStatus.Open AndAlso CommentView.DayStatus <> EmployeeTimesheet.DayStatus.Denied Then

                    e.PreviewText = "Time for " & CommentView.CommentDate.ToShortDateString & " is " & AdvantageFramework.StringUtilities.GetNameAsWords(CommentView.DayStatus.ToString) & " and cannot be changed."

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Comments_CurrentView_MeasurePreviewHeight(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowHeightEventArgs)

            'objects
            Dim CommentView As AdvantageFramework.EmployeeTimesheet.Classes.CommentView = Nothing

            Try

                CommentView = DataGridViewForm_Comments.CurrentView.GetRow(e.RowHandle)

            Catch ex As Exception
                CommentView = Nothing
            End Try

            If CommentView IsNot Nothing Then

                If CommentView.DayStatus = EmployeeTimesheet.DayStatus.Open OrElse CommentView.DayStatus = EmployeeTimesheet.DayStatus.Denied Then

                    e.RowHeight = 0

                End If

            End If

        End Sub
        Private Sub EmployeeTimesheeCommentViewDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim CommentViews As Generic.List(Of AdvantageFramework.EmployeeTimesheet.Classes.CommentView) = Nothing
            Dim CommentViewHeaders As Generic.List(Of AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader) = Nothing
            Dim EmployeeTimeComplexList As Generic.List(Of AdvantageFramework.Database.Classes.EmployeeTimeComplex) = Nothing
            Dim EmployeeTimeComplex As AdvantageFramework.Database.Classes.EmployeeTimeComplex = Nothing
            Dim DayStatus As AdvantageFramework.EmployeeTimesheet.DayStatus = Nothing
            Dim CurrentDate As Date = Nothing
            Dim Loaded As Boolean = True

            AddHandler DataGridViewForm_Comments.CurrentView.CalcPreviewText, AddressOf RowPreviewHandler
            AddHandler DataGridViewForm_Comments.CurrentView.MeasurePreviewHeight, AddressOf DataGridViewForm_Comments_CurrentView_MeasurePreviewHeight

            DataGridViewForm_Comments.OptionsView.ShowPreview = True
            DataGridViewForm_Comments.OptionsView.AutoCalcPreviewLineCount = True

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Session.UserCode)

                    If _StartDate > _EndDate Then

                        _EndDate = _StartDate

                    End If

                    CommentViews = New Generic.List(Of AdvantageFramework.EmployeeTimesheet.Classes.CommentView)

                    CurrentDate = _StartDate

                    EmployeeTimeComplexList = AdvantageFramework.Database.Procedures.EmployeeTimeComplex.Load(DbContext, _EmployeeCode, _StartDate, _EndDate, "", Me.Session.UserCode).ToList

                    Do Until CurrentDate > _EndDate

                        DayStatus = EmployeeTimesheet.DayStatus.Open

                        If EmployeeTimeComplexList IsNot Nothing AndAlso EmployeeTimeComplexList.Count > 0 Then

                            Try

                                EmployeeTimeComplex = (From Entity In EmployeeTimeComplexList
                                                       Where Entity.EmployeeDate = CurrentDate
                                                       Select Entity).FirstOrDefault

                            Catch ex As Exception
                                EmployeeTimeComplex = Nothing
                            End Try

                            If EmployeeTimeComplex IsNot Nothing Then

                                If EmployeeTimeComplex.DayPostPeriodClosed.GetValueOrDefault(False) = True Then

                                    DayStatus = AdvantageFramework.EmployeeTimesheet.DayStatus.PostPeriodClosed

                                ElseIf EmployeeTimeComplex.DayIsPendingApproval.GetValueOrDefault(False) = True Then

                                    DayStatus = AdvantageFramework.EmployeeTimesheet.DayStatus.Pending

                                ElseIf EmployeeTimeComplex.DayIsApproved.GetValueOrDefault(False) = True Then

                                    DayStatus = AdvantageFramework.EmployeeTimesheet.DayStatus.Approved

                                ElseIf EmployeeTimeComplex.DayIsDenied.GetValueOrDefault(False) = True Then

                                    DayStatus = AdvantageFramework.EmployeeTimesheet.DayStatus.Denied

                                Else

                                    DayStatus = AdvantageFramework.EmployeeTimesheet.DayStatus.Open

                                End If

                            End If

                        End If

                        CommentViews.Add(New AdvantageFramework.EmployeeTimesheet.Classes.CommentView With {.CommentDate = CurrentDate, .DayStatus = DayStatus})

                        CurrentDate = CurrentDate.AddDays(1)

                    Loop

                    _UseProductCategory = CBool(AdvantageFramework.Database.Procedures.Agency.Load(DbContext).EnableProductCategory.GetValueOrDefault(0))

                    DataGridViewForm_Comments.DataSource = CommentViews
                    DataGridViewForm_Comments.CurrentView.BestFitColumns()

                    CommentViewHeaders = New Generic.List(Of AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader)
                    CommentViewHeaders.Add(New AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader)

                    PropertyGridControlLeftSection_HeaderData.AllowExtraItemsInGridLookupEdits = False
                    PropertyGridControlLeftSection_HeaderData.SelectedObject = New AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader

                    If PropertyGridControlLeftSection_HeaderData.GetRowByFieldName(AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.ProductCategoryCode.ToString) IsNot Nothing Then

                        If _UseProductCategory = False Then

                            PropertyGridControlLeftSection_HeaderData.GetRowByFieldName(AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.ProductCategoryCode.ToString).Visible = False

                        End If

                    End If

                    PropertyGridControlLeftSection_HeaderData.Appearance.ModifiedRecordValue.Font = New System.Drawing.Font(PropertyGridControlLeftSection_HeaderData.Font, Drawing.FontStyle.Regular)
                    PropertyGridControlLeftSection_HeaderData.Appearance.FocusedRow.Font = New System.Drawing.Font(PropertyGridControlLeftSection_HeaderData.Font, Drawing.FontStyle.Bold)

                    PropertyGridControlLeftSection_HeaderData.Appearance.ModifiedRecordValue.Options.UseFont = True
                    PropertyGridControlLeftSection_HeaderData.Appearance.FocusedRow.Options.UseFont = True

                    DataGridViewForm_Comments.OptionsView.ShowViewCaption = False
                    DataGridViewForm_Comments.OptionsView.ShowFooter = True

                    LoadTimesheetSettings()

                    DataGridViewForm_Comments.CurrentView.BestFitColumns()

                End Using

            Catch ex As Exception
                Loaded = False
            End Try

            If Loaded = False Then

                AdvantageFramework.Navigation.ShowMessageBox("Error loading comment view.")

                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim CommentViewHeader As AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader = Nothing
            Dim HeaderValid As Boolean = True
            Dim ReturnMessage As String = Nothing
            Dim ErrorMessage As String = Nothing
            Dim EmployeeTimeID As Integer = Nothing
            Dim EmployeeTimeDetailID As Integer = Nothing
            Dim Passed As Boolean = True

            DataGridViewForm_Comments.CurrentView.CloseEditorForUpdating()
            PropertyGridControlLeftSection_HeaderData.CloseEditor()

            CommentViewHeader = PropertyGridControlLeftSection_HeaderData.SelectedObject

            ErrorMessage = CommentViewHeader.ValidateEntity(HeaderValid)

            If HeaderValid Then

                If DataGridViewForm_Comments.HasAnyInvalidRows Then

                    ErrorMessage = "Please fix invalid time entries. "

                Else

                    If (From Entity In DataGridViewForm_Comments.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.EmployeeTimesheet.Classes.CommentView)()
                        Where Entity.CommentHours.HasValue = True
                        Select Entity).Any = False Then

                        ErrorMessage = "Please enter hours for at least one day."

                    End If

                End If

            End If

            If ErrorMessage = "" AndAlso Me.Validator Then

                Try

                    CommentViewHeader = PropertyGridControlLeftSection_HeaderData.SelectedObject

                Catch ex As Exception
                    CommentViewHeader = Nothing
                End Try

                If CommentViewHeader IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each CommentView In DataGridViewForm_Comments.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.EmployeeTimesheet.Classes.CommentView)()

                            If CommentView.CommentHours.HasValue Then

                                If AdvantageFramework.EmployeeTimesheet.SaveTimesheetDay(Me.Session, DbContext, 0, 0, _EmployeeCode, CommentView.CommentDate, CommentViewHeader.FunctionCode,
                                                                                         CommentView.CommentHours.Value, CommentViewHeader.JobNumber.GetValueOrDefault(0), CommentViewHeader.JobComponentNumber.GetValueOrDefault(0),
                                                                                         CommentViewHeader.DepartmentTeamCode, Nothing, Me.Session.UserCode, CommentView.CommentDate, 0, ReturnMessage) = True Then

                                    AdvantageFramework.EmployeeTimesheet.ParseDetailRecordInformation(ReturnMessage, EmployeeTimeID, EmployeeTimeDetailID)

                                    If (EmployeeTimeID = Nothing OrElse EmployeeTimeID <= 0) AndAlso (EmployeeTimeDetailID = Nothing OrElse EmployeeTimeDetailID <= 0) Then

                                        Passed = False

                                    End If

                                End If

                            End If

                        Next

                    End Using

                End If

                If Passed = False Then

                    AdvantageFramework.Navigation.ShowMessageBox("One or more records failed to save.")

                End If

                Me.ClearChanged()

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub GridLookUpEdit_JobComponent_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobCompNumber As Short = Nothing
            Dim CommentViewHeader As AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader = Nothing

            Try

                GridLookUpEdit = sender

            Catch ex As Exception
                GridLookUpEdit = Nothing
            End Try

            If GridLookUpEdit IsNot Nothing AndAlso GridLookUpEdit.EditValue IsNot Nothing Then

                Try

                    JobNumber = CInt(GridLookUpEdit.Properties.View.GetFocusedRowCellValue("JobNumber"))

                Catch ex As Exception
                    JobNumber = Nothing
                End Try

                If JobNumber <> 0 Then

                    JobCompNumber = GridLookUpEdit.EditValue

                    CommentViewHeader = DirectCast(GridLookUpEdit.Parent, AdvantageFramework.WinForm.Presentation.Controls.PropertyGridControl).SelectedObject

                    CommentViewHeader.JobNumber = JobNumber

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Comments_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Comments.CellValueChangedEvent

            'objects
            Dim CommentView As AdvantageFramework.EmployeeTimesheet.Classes.CommentView = Nothing

            If e.Column.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.CommentView.Properties.CommentHours.ToString Then

                If e.Value Is Nothing Then

                    DataGridViewForm_Comments.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.EmployeeTimesheet.Classes.CommentView.Properties.Comment.ToString, Nothing)

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Comments_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Comments.DataSourceChangedEvent

            If DataGridViewForm_Comments.Columns.Count > 0 Then

                If DataGridViewForm_Comments.Columns(AdvantageFramework.EmployeeTimesheet.Classes.CommentView.Properties.CommentHours.ToString) IsNot Nothing Then

                    DataGridViewForm_Comments.Columns(AdvantageFramework.EmployeeTimesheet.Classes.CommentView.Properties.CommentHours.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    DataGridViewForm_Comments.Columns(AdvantageFramework.EmployeeTimesheet.Classes.CommentView.Properties.CommentHours.ToString).SummaryItem.DisplayFormat = "{0:N2}"
                    DataGridViewForm_Comments.Columns(AdvantageFramework.EmployeeTimesheet.Classes.CommentView.Properties.CommentHours.ToString).AllowSummaryMenu = False

                End If

                If DataGridViewForm_Comments.Columns(AdvantageFramework.EmployeeTimesheet.Classes.CommentView.Properties.CommentDate.ToString) IsNot Nothing Then

                    DataGridViewForm_Comments.Columns(AdvantageFramework.EmployeeTimesheet.Classes.CommentView.Properties.CommentDate.ToString).OptionsColumn.AllowFocus = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Comments_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_Comments.ShowingEditorEvent

            'objects
            Dim CommentView As AdvantageFramework.EmployeeTimesheet.Classes.CommentView = Nothing

            Try

                CommentView = DataGridViewForm_Comments.CurrentView.GetFocusedRow

            Catch ex As Exception
                CommentView = Nothing
            End Try

            If CommentView IsNot Nothing Then

                If CommentView.DayStatus <> EmployeeTimesheet.DayStatus.Open AndAlso CommentView.DayStatus <> EmployeeTimesheet.DayStatus.Denied Then

                    e.Cancel = True

                ElseIf CommentView.CommentHours.HasValue = False AndAlso DataGridViewForm_Comments.CurrentView.FocusedColumn.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.CommentView.Properties.Comment.ToString Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub PropertyGridControlForm_Properties_QueryPopupNeedDatasource(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles PropertyGridControlLeftSection_HeaderData.QueryPopupNeedDatasource

            'objects
            Dim CommentViewHeader As AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobNumbers As Integer() = Nothing
            Dim FunctionCodes As String() = Nothing
            Dim EmployeeDepartments As String() = Nothing
            Dim IsIndirectTime As Boolean = True
            Dim LoadFunctionsByEmployee As Boolean = False
            Dim EmployeeUserIDs As Integer() = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        CommentViewHeader = PropertyGridControlLeftSection_HeaderData.SelectedObject

                    Catch ex As Exception
                        CommentViewHeader = Nothing
                    End Try

                    If CommentViewHeader IsNot Nothing Then

                        If FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.FunctionCode.ToString Then

                            OverrideDefaultDatasource = True

                            If String.IsNullOrEmpty(CommentViewHeader.ClientCode) = False OrElse
                               CommentViewHeader.JobNumber.HasValue Then

                                IsIndirectTime = False

                            Else

                                IsIndirectTime = True

                            End If

                            Datasource = AdvantageFramework.EmployeeTimesheet.LoadTimeCategorOrFunctionListByEmployee(Me.Session, _EmployeeCode, IsIndirectTime)

                        ElseIf FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DepartmentTeamCode.ToString Then

                            OverrideDefaultDatasource = True

                            EmployeeDepartments = (From Entity In AdvantageFramework.Database.Procedures.EmployeeDepartment.Load(DbContext)
                                                   Where Entity.EmployeeCode = _EmployeeCode
                                                   Select Entity.DepartmentTeamCode).ToArray

                            Datasource = From Entity In AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext)
                                         Where EmployeeDepartments.Contains(Entity.Code)
                                         Select Entity

                        ElseIf FieldName = AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.JobNumber.ToString Then

                            OverrideDefaultDatasource = True

                            ClientCode = CommentViewHeader.ClientCode
                            DivisionCode = CommentViewHeader.DivisionCode
                            ProductCode = CommentViewHeader.ProductCode

                            If String.IsNullOrEmpty(ClientCode) = False AndAlso String.IsNullOrEmpty(DivisionCode) = False AndAlso String.IsNullOrEmpty(ProductCode) = False Then

                                Datasource = From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, Me.Session.UserCode, _EmployeeCode, True)
                                             Where Entity.ClientCode = ClientCode AndAlso
                                                   Entity.DivisionCode = DivisionCode AndAlso
                                                   Entity.ProductCode = ProductCode
                                             Select Entity

                            ElseIf String.IsNullOrEmpty(ClientCode) = False AndAlso String.IsNullOrEmpty(DivisionCode) = False Then

                                Datasource = From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, Me.Session.UserCode, _EmployeeCode, True)
                                             Where Entity.ClientCode = ClientCode AndAlso
                                                   Entity.DivisionCode = DivisionCode
                                             Select Entity

                            ElseIf String.IsNullOrEmpty(ClientCode) = False Then

                                Datasource = From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, Me.Session.UserCode, _EmployeeCode, True)
                                             Where Entity.ClientCode = ClientCode
                                             Select Entity

                            Else

                                Datasource = AdvantageFramework.Database.Procedures.Job.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, Me.Session.UserCode, _EmployeeCode, True)

                            End If

                        ElseIf FieldName = AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.JobComponentNumber.ToString Then

                            OverrideDefaultDatasource = True

                            ClientCode = CommentViewHeader.ClientCode
                            DivisionCode = CommentViewHeader.DivisionCode
                            ProductCode = CommentViewHeader.ProductCode
                            JobNumber = CommentViewHeader.JobNumber.GetValueOrDefault(0)

                            If JobNumber > 0 Then

                                Datasource = From Entity In AdvantageFramework.Database.Procedures.JobComponent.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, Me.Session.UserCode, _EmployeeCode, True)
                                             Where Entity.JobNumber = JobNumber
                                             Select Entity

                            Else

                                If String.IsNullOrEmpty(ClientCode) = False AndAlso String.IsNullOrEmpty(DivisionCode) = False AndAlso String.IsNullOrEmpty(ProductCode) = False Then

                                    JobNumbers = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, Me.Session.UserCode, _EmployeeCode, True)
                                                  Where Entity.ClientCode = ClientCode AndAlso
                                                        Entity.DivisionCode = DivisionCode AndAlso
                                                        Entity.ProductCode = ProductCode
                                                  Select Entity.Number).ToArray

                                ElseIf String.IsNullOrEmpty(ClientCode) = False AndAlso String.IsNullOrEmpty(DivisionCode) = False Then

                                    JobNumbers = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, Me.Session.UserCode, _EmployeeCode, True)
                                                  Where Entity.ClientCode = ClientCode AndAlso
                                                        Entity.DivisionCode = DivisionCode
                                                  Select Entity.Number).ToArray

                                ElseIf String.IsNullOrEmpty(ClientCode) = False Then

                                    JobNumbers = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, Me.Session.UserCode, _EmployeeCode, True)
                                                  Where Entity.ClientCode = ClientCode
                                                  Select Entity.Number).ToArray

                                Else

                                    JobNumbers = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, Me.Session.UserCode, _EmployeeCode, True)
                                                  Select Entity.Number).ToArray

                                End If

                                Datasource = From Entity In AdvantageFramework.Database.Procedures.JobComponent.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, Me.Session.UserCode, _EmployeeCode, True)
                                             Where JobNumbers.Contains(Entity.JobNumber)
                                             Select Entity

                            End If

                        ElseIf FieldName = AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.ClientCode.ToString Then

                            OverrideDefaultDatasource = True

                            Datasource = AdvantageFramework.Database.Procedures.Client.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, Me.Session.UserCode, _EmployeeCode, True)

                        ElseIf FieldName = AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.DivisionCode.ToString Then

                            OverrideDefaultDatasource = True

                            ClientCode = CommentViewHeader.ClientCode

                            If String.IsNullOrEmpty(ClientCode) = False Then

                                Datasource = From Entity In AdvantageFramework.Database.Procedures.Division.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, Me.Session.UserCode, _EmployeeCode, True)
                                             Where Entity.ClientCode = ClientCode
                                             Select Entity

                            End If

                        ElseIf FieldName = AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.ProductCode.ToString Then

                            OverrideDefaultDatasource = True

                            ClientCode = CommentViewHeader.ClientCode
                            DivisionCode = CommentViewHeader.DivisionCode

                            If String.IsNullOrEmpty(ClientCode) = False AndAlso String.IsNullOrEmpty(DivisionCode) = False Then

                                Datasource = From Entity In AdvantageFramework.Database.Procedures.Product.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, Me.Session.UserCode, _EmployeeCode, True)
                                             Where Entity.ClientCode = ClientCode AndAlso
                                                   Entity.DivisionCode = DivisionCode
                                             Select Entity

                            End If

                        End If

                        If OverrideDefaultDatasource = True AndAlso Datasource IsNot Nothing Then

                            Datasource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(Datasource)

                        End If

                    End If

                End Using

            End Using

        End Sub
        Private Sub PropertyGridControlLeftSection_HeaderData_ShownEditor(sender As Object, e As EventArgs) Handles PropertyGridControlLeftSection_HeaderData.ShownEditor

            If PropertyGridControlLeftSection_HeaderData.FocusedRow.Properties.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.JobComponentNumber.ToString Then

                If TypeOf PropertyGridControlLeftSection_HeaderData.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                    AddHandler PropertyGridControlLeftSection_HeaderData.ActiveEditor.EditValueChanged, AddressOf GridLookUpEdit_JobComponent_EditValueChanged

                End If

            End If

        End Sub
        Private Sub PropertyGridControlLeftSection_HeaderData_CellValueChangedEvent(ByVal sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles PropertyGridControlLeftSection_HeaderData.CellValueChanged

            'objects
            Dim ClearFunction As Boolean = False
            Dim CommentViewHeader As AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Try

                CommentViewHeader = PropertyGridControlLeftSection_HeaderData.SelectedObject

            Catch ex As Exception
                CommentViewHeader = Nothing
            End Try

            If CommentViewHeader IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If e.Row.Properties.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.ClientCode.ToString OrElse
                       e.Row.Properties.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.DivisionCode.ToString OrElse
                       e.Row.Properties.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.ProductCode.ToString OrElse
                       e.Row.Properties.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.JobNumber.ToString OrElse
                       e.Row.Properties.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.JobComponentNumber.ToString Then

                        If CommentViewHeader IsNot Nothing Then

                            If String.IsNullOrEmpty(CommentViewHeader.FunctionCode) = False Then

                                If String.IsNullOrEmpty(CommentViewHeader.ClientCode) = False OrElse CommentViewHeader.JobNumber.HasValue Then

                                    ClearFunction = Not (From Entity In AdvantageFramework.Database.Procedures.Function.Load(DbContext)
                                                         Where Entity.Code = CommentViewHeader.FunctionCode
                                                         Select Entity).Any

                                Else

                                    ClearFunction = Not (From Entity In AdvantageFramework.Database.Procedures.IndirectCategory.Load(DbContext)
                                                         Where Entity.Code = CommentViewHeader.FunctionCode
                                                         Select Entity).Any

                                End If

                                If ClearFunction Then

                                    CommentViewHeader.FunctionCode = Nothing

                                End If

                            End If

                        End If

                    End If

                    If e.Row.Properties.FieldName <> AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.FunctionCode.ToString Then

                        If String.IsNullOrEmpty(CommentViewHeader.FunctionCode) = True Then

                            If String.IsNullOrEmpty(CommentViewHeader.ClientCode) = False OrElse CommentViewHeader.JobNumber.HasValue Then

                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                                If Employee IsNot Nothing Then

                                    CommentViewHeader.FunctionCode = Employee.FunctionCode

                                End If

                            End If

                        End If

                    End If

                    If e.Row.Properties.FieldName <> AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.DepartmentTeamCode.ToString Then

                        If String.IsNullOrEmpty(CommentViewHeader.DepartmentTeamCode) Then

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                            If Employee IsNot Nothing Then

                                CommentViewHeader.DepartmentTeamCode = Employee.DepartmentTeamCode

                            End If

                        End If

                    End If

                End Using

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace