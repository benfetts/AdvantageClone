Namespace GeneralLedger.ReportWriter.Presentation

    Public Class GLReportTemplatePresetsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DepartmentTeamPresetsTable As System.Data.DataTable = Nothing
        Private _OfficePresetsTable As System.Data.DataTable = Nothing
        Private _ReportPostPeriodCode As String = ""
        Private _GLReportUserDefReportID As Integer = 0
        Private _GLReportUserDefReportDescriptionMaxLength As Integer = -1
        Private _PrintColumnHeadingsOnEveryPage As Boolean = False
        Private _SortRowsBy As AdvantageFramework.GeneralLedger.ReportWriter.SortRowsByOptions = AdvantageFramework.GeneralLedger.ReportWriter.SortRowsByOptions.AccountCode
        Private _CurrencyCode As String = Nothing
        Private _CurrencyExchangeRate As Nullable(Of Decimal) = Nothing
        Private _IsMultiCurrencyEnabled As Boolean = False
        Private _CurrencyCodeHome As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ReportPostPeriodCode As String
            Get
                ReportPostPeriodCode = _ReportPostPeriodCode
            End Get
        End Property
        Private ReadOnly Property GLReportUserDefReportID As Integer
            Get
                GLReportUserDefReportID = _GLReportUserDefReportID
            End Get
        End Property
        Private ReadOnly Property PrintColumnHeadingsOnEveryPage As Boolean
            Get
                PrintColumnHeadingsOnEveryPage = _PrintColumnHeadingsOnEveryPage
            End Get
        End Property
        Private ReadOnly Property SortRowsBy As AdvantageFramework.GeneralLedger.ReportWriter.SortRowsByOptions
            Get
                SortRowsBy = _SortRowsBy
            End Get
        End Property
        Private ReadOnly Property CurrencyCode As String
            Get
                CurrencyCode = _CurrencyCode
            End Get
        End Property
        Private ReadOnly Property CurrencyExchangeRate As Nullable(Of Decimal)
            Get
                CurrencyExchangeRate = _CurrencyExchangeRate
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal OfficePresetsTable As System.Data.DataTable, ByVal DepartmentTeamPresetsTable As System.Data.DataTable,
                        ByVal ReportPostPeriodCode As String, ByVal GLReportUserDefReportID As Integer, ByVal PrintColumnHeadingsOnEveryPage As Boolean,
                        ByVal SortRowsBy As AdvantageFramework.GeneralLedger.ReportWriter.SortRowsByOptions,
                        ByVal CurrencyCode As String, ByVal CurrencyExchangeRate As Decimal)

            ' This call is required by the designer.
            InitializeComponent()

            _DepartmentTeamPresetsTable = DepartmentTeamPresetsTable
            _OfficePresetsTable = OfficePresetsTable
            _ReportPostPeriodCode = ReportPostPeriodCode
            _GLReportUserDefReportID = GLReportUserDefReportID
            _PrintColumnHeadingsOnEveryPage = PrintColumnHeadingsOnEveryPage
            _SortRowsBy = SortRowsBy
            _CurrencyCode = CurrencyCode
            _CurrencyExchangeRate = CurrencyExchangeRate

        End Sub
        Private Sub LoadGLReportUserDefReports()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewOptions_GLReportUDRs.DataSource = AdvantageFramework.Database.Procedures.GLReportUserDefReport.Load(DbContext).ToList

            End Using

            For Each GridColumn In DataGridViewOptions_GLReportUDRs.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.FieldName = AdvantageFramework.Database.Entities.GLReportUserDefReport.Properties.Description.ToString Then

                    GridColumn.OptionsColumn.AllowEdit = True
                    GridColumn.OptionsColumn.ReadOnly = False

                    AddSubItemTextBox(Me.Session, DataGridViewOptions_GLReportUDRs, GridColumn, _GLReportUserDefReportDescriptionMaxLength)

                Else

                    GridColumn.OptionsColumn.AllowEdit = False
                    GridColumn.OptionsColumn.ReadOnly = True

                End If

            Next

            DataGridViewOptions_GLReportUDRs.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadOfficePresetsTab()

            'objects
            Dim OfficesList As Generic.List(Of AdvantageFramework.Database.Entities.Office) = Nothing
            Dim EmployeeOfficeList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing

            OfficesList = New Generic.List(Of AdvantageFramework.Database.Entities.Office)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                EmployeeOfficeList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode).ToList

                For Each Office In AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadOrderByOffice(DbContext).Include("Office").ToList.Where(Function(Entity) Entity.Office IsNot Nothing AndAlso Entity.Office.IsInactive.GetValueOrDefault(0) = 0).Select(Function(Entity) Entity.Office)

                    If EmployeeOfficeList.Count = 0 OrElse EmployeeOfficeList.Any(Function(Entity) Entity.OfficeCode = Office.Code) Then

                        If _OfficePresetsTable.Select(OfficePresetFields.Code.ToString & " = '" & Office.Code & "'").Any = False Then

                            OfficesList.Add(Office)

                        End If

                    End If

                Next

            End Using

            DataGridViewOfficeLeftSection_Offices.DataSource = OfficesList
            DataGridViewOfficeRightSection_Presets.DataSource = _OfficePresetsTable

            DataGridViewOfficeRightSection_Presets.MakeColumnNotVisible(OfficePresetFields.GLAReferenceCode.ToString)
            DataGridViewOfficeRightSection_Presets.MakeColumnNotVisible(OfficePresetFields.GLReportTemplatePresetOfficeID.ToString)
            DataGridViewOfficeRightSection_Presets.MakeColumnNotVisible(OfficePresetFields.ID.ToString)

            DataGridViewOfficeLeftSection_Offices.CurrentView.BestFitColumns()
            DataGridViewOfficeRightSection_Presets.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadDepartmentTeamPresetsTab()

            'objects
            Dim DepartmentTeamsList As Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam) = Nothing

            DepartmentTeamsList = New Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each DepartmentTeam In AdvantageFramework.Database.Procedures.GeneralLedgerDepartmentTeamCrossReference.Load(DbContext).Include("DepartmentTeam").ToList.Where(Function(Entity) Entity.DepartmentTeam IsNot Nothing AndAlso Entity.DepartmentTeam.IsInactive.GetValueOrDefault(0) = 0).Select(Function(Entity) Entity.DepartmentTeam)

                    If _DepartmentTeamPresetsTable.Select(DepartmentTeamPresetFields.Code.ToString & " = '" & DepartmentTeam.Code & "'").Any = False Then

                        DepartmentTeamsList.Add(DepartmentTeam)

                    End If

                Next

            End Using

            DataGridViewDTLeftSection_DepartmentTeams.DataSource = DepartmentTeamsList
            DataGridViewDTRightSection_Presets.DataSource = _DepartmentTeamPresetsTable

            DataGridViewDTRightSection_Presets.MakeColumnNotVisible(DepartmentTeamPresetFields.GLAReferenceCode.ToString)
            DataGridViewDTRightSection_Presets.MakeColumnNotVisible(DepartmentTeamPresetFields.GLReportTemplatePresetDepartmentTeamID.ToString)
            DataGridViewDTRightSection_Presets.MakeColumnNotVisible(DepartmentTeamPresetFields.ID.ToString)

            DataGridViewDTLeftSection_DepartmentTeams.CurrentView.BestFitColumns()
            DataGridViewDTRightSection_Presets.CurrentView.BestFitColumns()

        End Sub
        Public Sub AddSubItemTextBox(ByVal Session As AdvantageFramework.Security.Session, ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal MaxLength As Long)

            'objects
            Dim RepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = Nothing

            RepositoryItemButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

            RepositoryItemButtonEdit.ValidateOnEnterKey = True

            If MaxLength <> -1 Then

                RepositoryItemButtonEdit.MaxLength = MaxLength

            End If

            For Each EditorButton In RepositoryItemButtonEdit.Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton)()

                If EditorButton.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                    EditorButton.Visible = False
                    Exit For

                End If

            Next

            DataGridView.GridControl.RepositoryItems.Add(RepositoryItemButtonEdit)

            GridColumn.ColumnEdit = RepositoryItemButtonEdit

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonDTRightSection_Add.Enabled = DataGridViewDTLeftSection_DepartmentTeams.HasASelectedRow
            ButtonDTRightSection_AddAll.Enabled = DataGridViewDTLeftSection_DepartmentTeams.HasASelectedRow
            ButtonDTRightSection_Remove.Enabled = DataGridViewDTRightSection_Presets.HasASelectedRow
            ButtonDTRightSection_RemoveAll.Enabled = DataGridViewDTRightSection_Presets.HasASelectedRow

            ButtonOfficeRightSection_Add.Enabled = DataGridViewOfficeLeftSection_Offices.HasASelectedRow
            ButtonOfficeRightSection_AddAll.Enabled = DataGridViewOfficeLeftSection_Offices.HasASelectedRow
            ButtonOfficeRightSection_Remove.Enabled = DataGridViewOfficeRightSection_Presets.HasASelectedRow
            ButtonOfficeRightSection_RemoveAll.Enabled = DataGridViewOfficeRightSection_Presets.HasASelectedRow

            DataGridViewOptions_GLReportUDRs.Enabled = RadioButtonOptions_UserDefined.Checked

            ButtonOptions_Add.Enabled = RadioButtonOptions_UserDefined.Checked
            ButtonOptions_Edit.Enabled = RadioButtonOptions_UserDefined.Checked AndAlso DataGridViewOptions_GLReportUDRs.HasOnlyOneSelectedRow
            ButtonOptions_Delete.Enabled = RadioButtonOptions_UserDefined.Checked AndAlso DataGridViewOptions_GLReportUDRs.HasOnlyOneSelectedRow
            ButtonOptions_Copy.Enabled = RadioButtonOptions_UserDefined.Checked AndAlso DataGridViewOptions_GLReportUDRs.HasOnlyOneSelectedRow

            If SearchableComboBoxOptions_Currency.HasASelectedValue Then

                NumericInputOptions_CurrencyExchangeRate.SetRequired(True)
                NumericInputOptions_CurrencyExchangeRate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                NumericInputOptions_CurrencyExchangeRate.ReadOnly = False

            Else

                NumericInputOptions_CurrencyExchangeRate.EditValue = Nothing
                NumericInputOptions_CurrencyExchangeRate.SetRequired(False)
                NumericInputOptions_CurrencyExchangeRate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                NumericInputOptions_CurrencyExchangeRate.ReadOnly = True

            End If

        End Sub
        Private Sub RefreshCurrencyTooltip(DbContext As AdvantageFramework.Database.DbContext, UpdateRate As Boolean)

            Dim CurrencyDetail As AdvantageFramework.Database.Entities.CurrencyDetail = Nothing

            CurrencyDetail = AdvantageFramework.Database.Procedures.CurrencyDetail.LoadLatestByCurrencyCodeAndCurrencyCodeComparison(DbContext, SearchableComboBoxOptions_Currency.GetSelectedValue, _CurrencyCodeHome)

            If CurrencyDetail IsNot Nothing Then

                If UpdateRate Then

                    NumericInputOptions_CurrencyExchangeRate.EditValue = CurrencyDetail.ReciprocalExchangeRate

                End If

                NumericInputOptions_CurrencyExchangeRate.ToolTip = FormatNumber(CurrencyDetail.ReciprocalExchangeRate, 6).ToString & " @ " & CurrencyDetail.ExchangeDate

            Else

                NumericInputOptions_CurrencyExchangeRate.EditValue = NumericInputOptions_CurrencyExchangeRate.Properties.MinValue
                NumericInputOptions_CurrencyExchangeRate.ToolTip = Nothing

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal OfficePresetsTable As System.Data.DataTable, ByVal DepartmentTeamPresetsTable As System.Data.DataTable,
                                              ByRef ReportPostPeriodCode As String, ByRef GLReportUserDefReportID As Integer, ByRef PrintColumnHeadingsOnEveryPage As Boolean,
                                              ByRef SortRowsBy As AdvantageFramework.GeneralLedger.ReportWriter.SortRowsByOptions,
                                              ByRef CurrencyCode As String, ByRef CurrencyExchangeRate As Nullable(Of Decimal)) As System.Windows.Forms.DialogResult

            'objects
            Dim GLReportTemplatePresetsDialog As AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplatePresetsDialog = Nothing

            GLReportTemplatePresetsDialog = New AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplatePresetsDialog(OfficePresetsTable, DepartmentTeamPresetsTable, ReportPostPeriodCode, GLReportUserDefReportID, PrintColumnHeadingsOnEveryPage, SortRowsBy,
                                                                                                                                         CurrencyCode, CurrencyExchangeRate)

            ShowFormDialog = GLReportTemplatePresetsDialog.ShowDialog()

            ReportPostPeriodCode = GLReportTemplatePresetsDialog.ReportPostPeriodCode
            GLReportUserDefReportID = GLReportTemplatePresetsDialog.GLReportUserDefReportID
            PrintColumnHeadingsOnEveryPage = GLReportTemplatePresetsDialog.PrintColumnHeadingsOnEveryPage
            SortRowsBy = GLReportTemplatePresetsDialog.SortRowsBy
            CurrencyCode = GLReportTemplatePresetsDialog.CurrencyCode
            CurrencyExchangeRate = GLReportTemplatePresetsDialog.CurrencyExchangeRate

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub GLReportTemplatePresetsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DataGridViewOptions_GLReportUDRs.OptionsView.ShowFooter = False
            DataGridViewDTLeftSection_DepartmentTeams.OptionsView.ShowFooter = False
            DataGridViewDTRightSection_Presets.OptionsView.ShowFooter = False
            DataGridViewOfficeLeftSection_Offices.OptionsView.ShowFooter = False
            DataGridViewOfficeRightSection_Presets.OptionsView.ShowFooter = False

            ComboBoxOptions_PostPeriod.SetRequired(True)
            ComboBoxOptions_SortRowsBy.SetRequired(True)

            LoadGLReportUserDefReports()

            NumericInputOptions_CurrencyExchangeRate.SetPropertySettings(AdvantageFramework.Database.Entities.GLReportTemplate.Properties.CurrencyRate)
            NumericInputOptions_CurrencyExchangeRate.SetPropertySettings("Currency Exchange Rate")

            PictureOptions_UpdateCurrencyImage.Image = AdvantageFramework.My.Resources.SmallCurrencyDollarImage
            PictureOptions_UpdateCurrencyImage.ToolTip = "Click to update rate"

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxOptions_PostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                SearchableComboBoxOptions_Currency.DataSource = AdvantageFramework.Database.Procedures.CurrencyCode.LoadAllActiveMultiCurrency(DbContext).ToList

                _IsMultiCurrencyEnabled = AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext)

                _CurrencyCodeHome = AdvantageFramework.Database.Procedures.Agency.GetHomeCurrency(DbContext)

                If AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext) AndAlso Not String.IsNullOrWhiteSpace(AdvantageFramework.Agency.GetValue(DbContext, Agency.Methods.Settings.CURRENCY_API_KEY)) Then

                    PictureOptions_UpdateCurrencyImage.Visible = True

                End If

            End Using

            ComboBoxOptions_SortRowsBy.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTableOld(GetType(AdvantageFramework.GeneralLedger.ReportWriter.SortRowsByOptions), GetType(Integer))

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Try

                        _GLReportUserDefReportDescriptionMaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(GetType(AdvantageFramework.Database.Entities.GLReportUserDefReport), AdvantageFramework.Database.Entities.GLReportUserDefReport.Properties.Description.ToString))

                    Catch ex As Exception
                        _GLReportUserDefReportDescriptionMaxLength = -1
                    End Try

                End Using

            Catch ex As Exception
                _GLReportUserDefReportDescriptionMaxLength = -1
            End Try

            Try

                ComboBoxOptions_PostPeriod.SelectedValue = _ReportPostPeriodCode
                CheckBoxOptions_PrintColumnHeadingsOnEveryPage.Checked = _PrintColumnHeadingsOnEveryPage
                ComboBoxOptions_SortRowsBy.SelectedValue = CInt(_SortRowsBy)
                SearchableComboBoxOptions_Currency.SelectedValue = _CurrencyCode

                If SearchableComboBoxOptions_Currency.HasASelectedValue Then

                    NumericInputOptions_CurrencyExchangeRate.EditValue = _CurrencyExchangeRate

                End If

                If _GLReportUserDefReportID = 0 Then

                    RadioButtonOptions_Default.Checked = True
                    RadioButtonOptions_UserDefined.Checked = False

                    DataGridViewOptions_GLReportUDRs.DeselectAll()

                Else

                    RadioButtonOptions_Default.Checked = False
                    RadioButtonOptions_UserDefined.Checked = True

                    DataGridViewOptions_GLReportUDRs.SelectRow(_GLReportUserDefReportID)

                End If

                LoadOfficePresetsTab()

                LoadDepartmentTeamPresetsTab()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(sender As Object, e As EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                If RadioButtonOptions_Default.Checked OrElse (RadioButtonOptions_UserDefined.Checked AndAlso DataGridViewOptions_GLReportUDRs.HasOnlyOneSelectedRow) Then

                    _ReportPostPeriodCode = ComboBoxOptions_PostPeriod.SelectedValue
                    _PrintColumnHeadingsOnEveryPage = CheckBoxOptions_PrintColumnHeadingsOnEveryPage.Checked
                    _SortRowsBy = ComboBoxOptions_SortRowsBy.SelectedValue
                    _CurrencyCode = SearchableComboBoxOptions_Currency.GetSelectedValue

                    If SearchableComboBoxOptions_Currency.HasASelectedValue Then

                        _CurrencyExchangeRate = NumericInputOptions_CurrencyExchangeRate.EditValue

                    End If

                    If RadioButtonOptions_Default.Checked Then

                        _GLReportUserDefReportID = 0

                    Else

                        _GLReportUserDefReportID = DataGridViewOptions_GLReportUDRs.GetFirstSelectedRowBookmarkValue

                    End If

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a valid User Defined report.")

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonDTRightSection_Add_Click(sender As Object, e As EventArgs) Handles ButtonDTRightSection_Add.Click

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataRow = _DepartmentTeamPresetsTable.Rows.Add()

                    DataRow(DepartmentTeamPresetFields.Code.ToString) = DataGridViewDTLeftSection_DepartmentTeams.GetFirstSelectedRowBookmarkValue(0)
                    DataRow(DepartmentTeamPresetFields.Description.ToString) = DataGridViewDTLeftSection_DepartmentTeams.GetFirstSelectedRowBookmarkValue(1)

                    Try

                        DataRow(DepartmentTeamPresetFields.GLAReferenceCode.ToString) = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT GLDXGLDEPT FROM dbo.GLDXREF WHERE GLDXDEPT = '{0}'", DataRow(DepartmentTeamPresetFields.Code.ToString))).FirstOrDefault

                    Catch ex As Exception
                        DataRow(DepartmentTeamPresetFields.GLAReferenceCode.ToString) = ""
                    End Try

                End Using

                LoadDepartmentTeamPresetsTab()

            End If

        End Sub
        Private Sub ButtonDTRightSection_AddAll_Click(sender As Object, e As EventArgs) Handles ButtonDTRightSection_AddAll.Click

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    RowHandlesAndDataBoundItems = DataGridViewDTLeftSection_DepartmentTeams.GetAllRowsRowHandlesAndDataBoundItems

                    For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                        DataRow = _DepartmentTeamPresetsTable.NewRow

                        Try

                            DataRow(DepartmentTeamPresetFields.Code.ToString) = RowHandleAndDataBoundItem.Value.Code
                            DataRow(DepartmentTeamPresetFields.Description.ToString) = RowHandleAndDataBoundItem.Value.Description

                            Try

                                DataRow(DepartmentTeamPresetFields.GLAReferenceCode.ToString) = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT GLDXGLDEPT FROM dbo.GLDXREF WHERE GLDXDEPT = '{0}'", DataRow(DepartmentTeamPresetFields.Code.ToString))).FirstOrDefault

                            Catch ex As Exception
                                DataRow(DepartmentTeamPresetFields.GLAReferenceCode.ToString) = ""
                            End Try

                        Catch ex As Exception
                            DataRow = Nothing
                        End Try

                        If DataRow IsNot Nothing Then

                            _DepartmentTeamPresetsTable.Rows.Add(DataRow)

                        End If

                    Next

                End Using

                LoadDepartmentTeamPresetsTab()

            End If

        End Sub
        Private Sub ButtonDTRightSection_Remove_Click(sender As Object, e As EventArgs) Handles ButtonDTRightSection_Remove.Click

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Try

                    DataRow = DirectCast(DataGridViewDTRightSection_Presets.GetFirstSelectedRowDataBoundItem, System.Data.DataRowView).Row

                Catch ex As Exception
                    DataRow = Nothing
                End Try

                If DataRow IsNot Nothing Then

                    _DepartmentTeamPresetsTable.Rows.Remove(DataRow)

                End If

                LoadDepartmentTeamPresetsTab()

            End If

        End Sub
        Private Sub ButtonDTRightSection_RemoveAll_Click(sender As Object, e As EventArgs) Handles ButtonDTRightSection_RemoveAll.Click

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                For Each DataRow In DataGridViewDTRightSection_Presets.GetAllRowsDataBoundItems.OfType(Of System.Data.DataRowView).Select(Function(DRV) DRV.Row).ToList

                    _DepartmentTeamPresetsTable.Rows.Remove(DataRow)

                Next

                LoadDepartmentTeamPresetsTab()

            End If

        End Sub
        Private Sub ButtonOfficeRightSection_Add_Click(sender As Object, e As EventArgs) Handles ButtonOfficeRightSection_Add.Click

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataRow = _OfficePresetsTable.Rows.Add()

                    DataRow(OfficePresetFields.Code.ToString) = DataGridViewOfficeLeftSection_Offices.GetFirstSelectedRowBookmarkValue(0)
                    DataRow(OfficePresetFields.Name.ToString) = DataGridViewOfficeLeftSection_Offices.GetFirstSelectedRowBookmarkValue(1)

                    Try

                        DataRow(OfficePresetFields.GLAReferenceCode.ToString) = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT GLOXGLOFFICE FROM dbo.GLOXREF WHERE GLOXOFFICE = '{0}'", DataRow(OfficePresetFields.Code.ToString))).FirstOrDefault

                    Catch ex As Exception
                        DataRow(OfficePresetFields.GLAReferenceCode.ToString) = ""
                    End Try

                End Using

                LoadOfficePresetsTab()

            End If

        End Sub
        Private Sub ButtonOfficeRightSection_AddAll_Click(sender As Object, e As EventArgs) Handles ButtonOfficeRightSection_AddAll.Click

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    RowHandlesAndDataBoundItems = DataGridViewOfficeLeftSection_Offices.GetAllRowsRowHandlesAndDataBoundItems

                    For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                        DataRow = _OfficePresetsTable.NewRow

                        Try

                            DataRow(OfficePresetFields.Code.ToString) = RowHandleAndDataBoundItem.Value.Code
                            DataRow(OfficePresetFields.Name.ToString) = RowHandleAndDataBoundItem.Value.Name

                            Try

                                DataRow(OfficePresetFields.GLAReferenceCode.ToString) = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT GLOXGLOFFICE FROM dbo.GLOXREF WHERE GLOXOFFICE = '{0}'", DataRow(OfficePresetFields.Code.ToString))).FirstOrDefault

                            Catch ex As Exception
                                DataRow(OfficePresetFields.GLAReferenceCode.ToString) = ""
                            End Try

                        Catch ex As Exception
                            DataRow = Nothing
                        End Try

                        If DataRow IsNot Nothing Then

                            _OfficePresetsTable.Rows.Add(DataRow)

                        End If

                    Next

                End Using

                LoadOfficePresetsTab()

            End If

        End Sub
        Private Sub ButtonOfficeRightSection_Remove_Click(sender As Object, e As EventArgs) Handles ButtonOfficeRightSection_Remove.Click

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Try

                    DataRow = DirectCast(DataGridViewOfficeRightSection_Presets.GetFirstSelectedRowDataBoundItem, System.Data.DataRowView).Row

                Catch ex As Exception
                    DataRow = Nothing
                End Try

                If DataRow IsNot Nothing Then

                    _OfficePresetsTable.Rows.Remove(DataRow)

                End If

                LoadOfficePresetsTab()

            End If

        End Sub
        Private Sub ButtonOfficeRightSection_RemoveAll_Click(sender As Object, e As EventArgs) Handles ButtonOfficeRightSection_RemoveAll.Click

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                For Each DataRow In DataGridViewOfficeRightSection_Presets.GetAllRowsDataBoundItems.OfType(Of System.Data.DataRowView).Select(Function(DRV) DRV.Row).ToList

                    _OfficePresetsTable.Rows.Remove(DataRow)

                Next

                LoadOfficePresetsTab()

            End If

        End Sub
        Private Sub DataGridViewDTLeftSection_DepartmentTeams_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewDTLeftSection_DepartmentTeams.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewDTRightSection_Presets_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewDTRightSection_Presets.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewOfficeLeftSection_Offices_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewOfficeLeftSection_Offices.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewOfficeRightSection_Presets_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewOfficeRightSection_Presets.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewOptions_GLReportUDRs_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewOptions_GLReportUDRs.CellValueChangedEvent

            'objects
            Dim GLReportUserDefReport As AdvantageFramework.Database.Entities.GLReportUserDefReport = Nothing
            Dim GLReportUserDefReportID As Integer = 0

            Try

                GLReportUserDefReportID = DataGridViewOptions_GLReportUDRs.GetFirstSelectedRowBookmarkValue

            Catch ex As Exception
                GLReportUserDefReportID = 0
            End Try

            If e.Column IsNot Nothing AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.GLReportUserDefReport.Properties.Description.ToString AndAlso GLReportUserDefReportID > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    GLReportUserDefReport = AdvantageFramework.Database.Procedures.GLReportUserDefReport.LoadByGLReportUserDefReportID(DbContext, GLReportUserDefReportID)

                    If GLReportUserDefReport IsNot Nothing Then

                        GLReportUserDefReport.Description = e.Value

                        AdvantageFramework.Database.Procedures.GLReportUserDefReport.Update(DbContext, GLReportUserDefReport)

                    End If

                End Using

            End If

        End Sub
        Private Sub DataGridViewOptions_GLReportUDRs_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewOptions_GLReportUDRs.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonOptions_Add_Click(sender As Object, e As EventArgs) Handles ButtonOptions_Add.Click

            'objects
            Dim GLReportUserDefReportID As Integer = 0

            If AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateReportWriterForm.ShowFormDialog(Me.Session, GLReportUserDefReportID) = Windows.Forms.DialogResult.OK Then

                LoadGLReportUserDefReports()

                DataGridViewOptions_GLReportUDRs.DeselectAll()

                DataGridViewOptions_GLReportUDRs.SelectRow(GLReportUserDefReportID)

            End If

        End Sub
        Private Sub ButtonOptions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonOptions_Delete.Click

            'objects
            Dim GLReportUserDefReport As AdvantageFramework.Database.Entities.GLReportUserDefReport = Nothing
            Dim GLReportUserDefReportID As Integer = 0

            GLReportUserDefReportID = DataGridViewOptions_GLReportUDRs.GetFirstSelectedRowBookmarkValue

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                GLReportUserDefReport = AdvantageFramework.Database.Procedures.GLReportUserDefReport.LoadByGLReportUserDefReportID(DbContext, GLReportUserDefReportID)

                If GLReportUserDefReport IsNot Nothing Then

                    If AdvantageFramework.Database.Procedures.GLReportUserDefReport.Delete(DbContext, GLReportUserDefReport) Then

                        LoadGLReportUserDefReports()

                        DataGridViewOptions_GLReportUDRs.DeselectAll()

                    End If

                End If

            End Using

        End Sub
        Private Sub ButtonOptions_Edit_Click(sender As Object, e As EventArgs) Handles ButtonOptions_Edit.Click

            'objects
            Dim GLReportUserDefReportID As Integer = 0

            GLReportUserDefReportID = DataGridViewOptions_GLReportUDRs.GetFirstSelectedRowBookmarkValue

            If AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateReportWriterForm.ShowFormDialog(Me.Session, GLReportUserDefReportID) = Windows.Forms.DialogResult.OK Then

                LoadGLReportUserDefReports()

                DataGridViewOptions_GLReportUDRs.DeselectAll()

                DataGridViewOptions_GLReportUDRs.SelectRow(GLReportUserDefReportID)

            End If

        End Sub
        Private Sub ButtonOptions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonOptions_Copy.Click

            'objects
            Dim GLReportUserDefReport As AdvantageFramework.Database.Entities.GLReportUserDefReport = Nothing
            Dim NewGLReportUserDefReport As AdvantageFramework.Database.Entities.GLReportUserDefReport = Nothing
            Dim GLReportUserDefReportID As Integer = 0

            If DataGridViewOptions_GLReportUDRs.HasOnlyOneSelectedRow Then

                GLReportUserDefReportID = DataGridViewOptions_GLReportUDRs.GetFirstSelectedRowBookmarkValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    GLReportUserDefReport = AdvantageFramework.Database.Procedures.GLReportUserDefReport.LoadByGLReportUserDefReportID(DbContext, GLReportUserDefReportID)

                    If GLReportUserDefReport IsNot Nothing Then

                        NewGLReportUserDefReport = GLReportUserDefReport.DuplicateEntity()

                        GLReportUserDefReport.ModifiedByUserCode = Nothing
                        GLReportUserDefReport.ModifiedDate = Nothing

                        If AdvantageFramework.Database.Procedures.GLReportUserDefReport.Insert(DbContext, NewGLReportUserDefReport) Then

                            LoadGLReportUserDefReports()

                        End If

                    End If

                End Using

            End If

        End Sub
        Private Sub NumericInputOptions_CurrencyExchangeRate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles NumericInputOptions_CurrencyExchangeRate.Validating

            If SearchableComboBoxOptions_Currency.HasASelectedValue AndAlso (NumericInputOptions_CurrencyExchangeRate.EditValue Is Nothing OrElse NumericInputOptions_CurrencyExchangeRate.EditValue <= 0) Then

                AdvantageFramework.WinForm.MessageBox.Show("Currency exchange rate must be greater than zero.")
                e.Cancel = True

            End If

        End Sub
        Private Sub PictureOptions_UpdateCurrencyImage_Click(sender As Object, e As EventArgs) Handles PictureOptions_UpdateCurrencyImage.Click

            Dim CurrencyList As IEnumerable(Of String) = Nothing
            Dim ErrorMessage As String = ""

            Me.ShowWaitForm("Updating...")

            CurrencyList = {SearchableComboBoxOptions_Currency.GetSelectedValue}

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If AdvantageFramework.Currency.GetRealtimeRates(DbContext, CurrencyList, _CurrencyCodeHome, ErrorMessage) Then

                    RefreshCurrencyTooltip(DbContext, True)

                    AdvantageFramework.WinForm.MessageBox.Show("Exchanges rate updated successfully.")

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End Using

            Me.CloseWaitForm()

        End Sub
        Private Sub RadioButtonOptions_Default_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonOptions_Default.CheckedChanged

            EnableOrDisableActions()

        End Sub
        Private Sub RadioButtonOptions_UserDefined_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonOptions_UserDefined.CheckedChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonForm_CopyFrom_Click(sender As Object, e As EventArgs) Handles ButtonForm_CopyFrom.Click

            'objects
            Dim SelectedGLReportTemplates As IEnumerable = Nothing
            Dim GLReportTemplateID As Integer = 0
            Dim GLReportTemplate As AdvantageFramework.Database.Entities.GLReportTemplate = Nothing

            If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.GLReportTemplate, True, True, SelectedGLReportTemplates, False, "Select GL Report Template") = Windows.Forms.DialogResult.OK Then

                If SelectedGLReportTemplates IsNot Nothing Then

                    Try

                        GLReportTemplateID = (From Entity In SelectedGLReportTemplates
                                              Select Entity.ID).FirstOrDefault

                    Catch ex As Exception
                        GLReportTemplateID = 0
                    End Try

                    If GLReportTemplateID > 0 Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            GLReportTemplate = AdvantageFramework.Database.Procedures.GLReportTemplate.LoadByGLReportTemplateID(DbContext, GLReportTemplateID)

                            If GLReportTemplate IsNot Nothing Then

                                ComboBoxOptions_PostPeriod.SelectedValue = GLReportTemplate.PostPeriodCode
                                CheckBoxOptions_PrintColumnHeadingsOnEveryPage.Checked = GLReportTemplate.PrintColumnHeadingsOnEveryPage
                                ComboBoxOptions_SortRowsBy.SelectedValue = GLReportTemplate.SortRowsBy
                                SearchableComboBoxOptions_Currency.SelectedValue = GLReportTemplate.CurrencyCode

                                If SearchableComboBoxOptions_Currency.HasASelectedValue Then

                                    NumericInputOptions_CurrencyExchangeRate.EditValue = GLReportTemplate.CurrencyRate

                                End If

                                If GLReportTemplate.GLReportUserDefReportID.GetValueOrDefault(0) = 0 Then

                                    RadioButtonOptions_Default.Checked = True
                                    RadioButtonOptions_UserDefined.Checked = False

                                    DataGridViewOptions_GLReportUDRs.DeselectAll()

                                Else

                                    RadioButtonOptions_Default.Checked = False
                                    RadioButtonOptions_UserDefined.Checked = True

                                    DataGridViewOptions_GLReportUDRs.SelectRow(_GLReportUserDefReportID)

                                End If

                                _DepartmentTeamPresetsTable.Rows.Clear()
                                _OfficePresetsTable.Rows.Clear()

                                LoadDepartmentTeamPresetsDataTable(DbContext, GLReportTemplateID, _DepartmentTeamPresetsTable)
                                LoadOfficePresetsDataTable(DbContext, GLReportTemplateID, _OfficePresetsTable)

                            End If

                        End Using

                        LoadDepartmentTeamPresetsTab()
                        LoadOfficePresetsTab()

                        EnableOrDisableActions()

                    End If

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxOptions_Currency_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxOptions_Currency.EditValueChanged

            Dim CurrencyDetail As AdvantageFramework.Database.Entities.CurrencyDetail = Nothing
            Dim UpdateRate As Boolean = False

            If SearchableComboBoxOptions_Currency.HasASelectedValue Then

                If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                    UpdateRate = True

                End If

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    RefreshCurrencyTooltip(DbContext, UpdateRate)

                End Using

            End If

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
