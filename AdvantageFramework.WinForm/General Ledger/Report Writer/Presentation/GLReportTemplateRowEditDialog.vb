Namespace GeneralLedger.ReportWriter.Presentation

    Public Class GLReportTemplateRowEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _RowsDataTable As System.Data.DataTable = Nothing
        Private _RelatedRowsDataTable As System.Data.DataTable = Nothing
        Private _RowDataRow As System.Data.DataRow = Nothing
        Private _GLReportTemplateRowDescriptionMaxLength As Integer = -1
		Private _ReportType As ReportTypes = ReportTypes.IncomeStatement

#End Region

#Region " Properties "



#End Region

#Region " Methods "

		Private Sub New(ByVal RowsDataTable As System.Data.DataTable, ByVal RelatedRowsDataTable As System.Data.DataTable, ByVal RowDataRow As System.Data.DataRow, ByVal ReportType As ReportTypes)

            ' This call is required by the designer.
            InitializeComponent()

            _RowsDataTable = RowsDataTable
            _RelatedRowsDataTable = RelatedRowsDataTable
            _RowDataRow = RowDataRow
            _ReportType = ReportType

        End Sub
        Private Sub LoadRelatedRows()

            'objects
            Dim AvailableRowsDataTable As System.Data.DataTable = Nothing
            Dim RelatedRowsDataTable As System.Data.DataTable = Nothing
            Dim AvailableDataRow As System.Data.DataRow = Nothing
            Dim RelatedDataRow As System.Data.DataRow = Nothing

            AvailableRowsDataTable = New System.Data.DataTable

            AvailableRowsDataTable.Columns.Add(RowFields.ID.ToString, GetType(Integer))
            AvailableRowsDataTable.Columns.Add(RowFields.RowIndex.ToString, GetType(Integer))
            AvailableRowsDataTable.Columns.Add(RowFields.Description.ToString, GetType(String))
            AvailableRowsDataTable.Columns.Add(RelatedRowFields.RelatedRowOrder.ToString, GetType(Integer))

            RelatedRowsDataTable = AvailableRowsDataTable.Clone

            If _RowDataRow IsNot Nothing Then

                For Each DataRow In _RelatedRowsDataTable.Select(RelatedRowFields.RowID.ToString & " = " & _RowDataRow(RowFields.ID.ToString))

                    RelatedDataRow = RelatedRowsDataTable.NewRow

                    RelatedDataRow(RowFields.ID.ToString) = DataRow(RelatedRowFields.RelatedRowID.ToString)
                    RelatedDataRow(RowFields.RowIndex.ToString) = DataRow(RelatedRowFields.RelatedRowIndex.ToString)
                    RelatedDataRow(RowFields.Description.ToString) = DataRow(RelatedRowFields.RelatedRowDescription.ToString)
                    RelatedDataRow(RelatedRowFields.RelatedRowOrder.ToString) = DataRow(RelatedRowFields.RelatedRowOrder.ToString)

                    RelatedRowsDataTable.Rows.Add(RelatedDataRow)

                Next

                For Each DataRow In _RowsDataTable.Select(RowFields.ID.ToString & " <> " & _RowDataRow(RowFields.ID.ToString) & " AND " & RowFields.Type.ToString & " <> " & RowTypes.Other)

                    If RelatedRowsDataTable.Select(RowFields.ID.ToString & " = " & DataRow(RowFields.ID.ToString)).Any = False Then

                        AvailableDataRow = AvailableRowsDataTable.NewRow

                        AvailableDataRow(RowFields.ID.ToString) = DataRow(RowFields.ID.ToString)
                        AvailableDataRow(RowFields.RowIndex.ToString) = DataRow(RowFields.RowIndex.ToString)
                        AvailableDataRow(RowFields.Description.ToString) = DataRow(RowFields.Description.ToString)
                        AvailableDataRow(RelatedRowFields.RelatedRowOrder.ToString) = 0

                        AvailableRowsDataTable.Rows.Add(AvailableDataRow)

                    End If

                Next

            Else

                For Each DataRow In _RowsDataTable.Select(RowFields.Type.ToString & " <> " & RowTypes.Other)

                    AvailableDataRow = AvailableRowsDataTable.NewRow

                    AvailableDataRow(RowFields.ID.ToString) = DataRow(RowFields.ID.ToString)
                    AvailableDataRow(RowFields.RowIndex.ToString) = DataRow(RowFields.RowIndex.ToString)
                    AvailableDataRow(RowFields.Description.ToString) = DataRow(RowFields.Description.ToString)
                    AvailableDataRow(RelatedRowFields.RelatedRowOrder.ToString) = 0

                    AvailableRowsDataTable.Rows.Add(AvailableDataRow)

                Next

            End If

            AvailableRowsDataTable.DefaultView.Sort = RelatedRowFields.RelatedRowOrder.ToString
            RelatedRowsDataTable.DefaultView.Sort = RelatedRowFields.RelatedRowOrder.ToString

            DataGridViewLeftSection_Rows.DataSource = AvailableRowsDataTable
            DataGridViewRightSection_RelatedRows.DataSource = RelatedRowsDataTable

            DataGridViewLeftSection_Rows.MakeColumnNotVisible(RowFields.ID.ToString)
            DataGridViewRightSection_RelatedRows.MakeColumnNotVisible(RowFields.ID.ToString)

            DataGridViewLeftSection_Rows.MakeColumnNotVisible(RelatedRowFields.RelatedRowOrder.ToString)
            DataGridViewRightSection_RelatedRows.MakeColumnNotVisible(RelatedRowFields.RelatedRowOrder.ToString)

            DataGridViewLeftSection_Rows.CurrentView.BestFitColumns()
            DataGridViewRightSection_RelatedRows.CurrentView.BestFitColumns()

        End Sub
        Private Sub SaveRow(ByVal DataRow As System.Data.DataRow)

            'objects
            Dim NewRelatedRowDataRow As System.Data.DataRow = Nothing

            If DataRow IsNot Nothing Then

				DataRow(RowFields.Description.ToString) = TextBoxForm_Description.Text
				DataRow(RowFields.IsVisible.ToString) = CheckBoxForm_IsVisible.Checked

				DataRow(RowFields.Type.ToString) = If(ComboBoxForm_Type.GetSelectedValue IsNot Nothing, ComboBoxForm_Type.GetSelectedValue, DataRow(RowFields.Type.ToString))
                DataRow(RowFields.IndentSpaces.ToString) = NumericInputForm_IndentSpaces.EditValue
                DataRow(RowFields.RollUp.ToString) = CheckBoxForm_Rollup.Checked
                DataRow(RowFields.IsBold.ToString) = CheckBoxForm_Bold.Checked
				DataRow(RowFields.UseCurrencyFormat.ToString) = False 'CheckBoxForm_Currency.Checked
				DataRow(RowFields.NumberOfDecimalPlaces.ToString) = 0 'NumericInputForm_NumberOfDecimalPlaces.EditValue
				DataRow(RowFields.UnderlineAmount.ToString) = CheckBoxForm_UnderlineAmount.Checked
				DataRow(RowFields.DoubleUnderlineAmount.ToString) = CheckBoxForm_DoubleUnderlineAmount.Checked
				DataRow(RowFields.SuppressIfAllZeros.ToString) = CheckBoxForm_SuppressIfAllZeros.Checked

                DataRow(RowFields.BalanceType.ToString) = If(ComboBoxForm_Balance.GetSelectedValue IsNot Nothing, ComboBoxForm_Balance.GetSelectedValue, DataRow(RowFields.BalanceType.ToString))
                DataRow(RowFields.DisplayType.ToString) = If(ComboBoxForm_DisplayType.GetSelectedValue IsNot Nothing, ComboBoxForm_DisplayType.GetSelectedValue, DataRow(RowFields.DisplayType.ToString))
                DataRow(RowFields.UseBaseAccountCodes.ToString) = CheckBoxAccountRowDetails_UseBaseCodes.Checked

                If RadioButtonAccountRowDetails_AccountType.Checked Then

                    DataRow(RowFields.LinkType.ToString) = CInt(LinkTypes.AccountType)
                    DataRow(RowFields.AccountType.ToString) = If(ComboBoxAccountRowDetails_AccountType.GetSelectedValue Is Nothing, System.DBNull.Value, ComboBoxAccountRowDetails_AccountType.GetSelectedValue)

                    DataRow(RowFields.AccountGroupCode.ToString) = System.DBNull.Value
                    DataRow(RowFields.GLACode.ToString) = System.DBNull.Value
                    DataRow(RowFields.GLACodeRangeStart.ToString) = System.DBNull.Value
                    DataRow(RowFields.GLACodeRangeTo.ToString) = System.DBNull.Value
                    DataRow(RowFields.Wildcard.ToString) = System.DBNull.Value

                ElseIf RadioButtonAccountRowDetails_AccountGroup.Checked Then

                    DataRow(RowFields.LinkType.ToString) = CInt(LinkTypes.AccountGroup)
                    DataRow(RowFields.AccountGroupCode.ToString) = If(ComboBoxAccountRowDetails_AccountGroup.GetSelectedValue Is Nothing, System.DBNull.Value, ComboBoxAccountRowDetails_AccountGroup.GetSelectedValue)

                    DataRow(RowFields.AccountType.ToString) = System.DBNull.Value
                    DataRow(RowFields.GLACode.ToString) = System.DBNull.Value
                    DataRow(RowFields.GLACodeRangeStart.ToString) = System.DBNull.Value
                    DataRow(RowFields.GLACodeRangeTo.ToString) = System.DBNull.Value
                    DataRow(RowFields.Wildcard.ToString) = System.DBNull.Value

                ElseIf RadioButtonAccountRowDetails_Account.Checked Then

                    DataRow(RowFields.LinkType.ToString) = CInt(LinkTypes.Account)
                    DataRow(RowFields.GLACode.ToString) = If(ComboBoxAccountRowDetails_Account.GetSelectedValue Is Nothing, System.DBNull.Value, ComboBoxAccountRowDetails_Account.GetSelectedValue)

                    DataRow(RowFields.AccountType.ToString) = System.DBNull.Value
                    DataRow(RowFields.AccountGroupCode.ToString) = System.DBNull.Value
                    DataRow(RowFields.GLACodeRangeStart.ToString) = System.DBNull.Value
                    DataRow(RowFields.GLACodeRangeTo.ToString) = System.DBNull.Value
                    DataRow(RowFields.Wildcard.ToString) = System.DBNull.Value

                ElseIf RadioButtonAccountRowDetails_AccountRange.Checked Then

                    DataRow(RowFields.LinkType.ToString) = CInt(LinkTypes.AccountRange)
                    DataRow(RowFields.GLACodeRangeStart.ToString) = If(ComboBoxAccountRowDetails_AccountRangeStart.GetSelectedValue Is Nothing, System.DBNull.Value, ComboBoxAccountRowDetails_AccountRangeStart.GetSelectedValue)
                    DataRow(RowFields.GLACodeRangeTo.ToString) = If(ComboBoxAccountRowDetails_AccountRangeTo.GetSelectedValue Is Nothing, System.DBNull.Value, ComboBoxAccountRowDetails_AccountRangeTo.GetSelectedValue)

                    DataRow(RowFields.AccountType.ToString) = System.DBNull.Value
                    DataRow(RowFields.AccountGroupCode.ToString) = System.DBNull.Value
                    DataRow(RowFields.GLACode.ToString) = System.DBNull.Value
                    DataRow(RowFields.Wildcard.ToString) = System.DBNull.Value

                ElseIf RadioButtonAccountRowDetails_Wildcard.Checked Then

                    DataRow(RowFields.LinkType.ToString) = CInt(LinkTypes.Wildcard)
                    DataRow(RowFields.Wildcard.ToString) = TextBoxAccountRowDetails_Wildcard.Text

                    DataRow(RowFields.AccountType.ToString) = System.DBNull.Value
                    DataRow(RowFields.AccountGroupCode.ToString) = System.DBNull.Value
                    DataRow(RowFields.GLACode.ToString) = System.DBNull.Value
                    DataRow(RowFields.GLACodeRangeStart.ToString) = System.DBNull.Value
                    DataRow(RowFields.GLACodeRangeTo.ToString) = System.DBNull.Value

                End If

                DataRow(RowFields.TotalType.ToString) = If(ComboBoxTableRowDetails_TotalBy.GetSelectedValue Is Nothing, System.DBNull.Value, ComboBoxTableRowDetails_TotalBy.GetSelectedValue)

                If RadioButtonDataCalculations_YearToDate.Checked Then

                    DataRow(RowFields.DataCalculation.ToString) = CInt(DataCalculations.YearToDate)

                ElseIf RadioButtonDataCalculations_SelectedPeriod.Checked Then

                    DataRow(RowFields.DataCalculation.ToString) = CInt(DataCalculations.SelectedPeriod)

                ElseIf RadioButtonDataCalculations_All.Checked Then

                    DataRow(RowFields.DataCalculation.ToString) = CInt(DataCalculations.All)

                End If

                If RadioButtonDataOptions_EndingBalance.Checked Then

                    DataRow(RowFields.DataOption.ToString) = CInt(DataOptions.EndingBalance)

                ElseIf RadioButtonDataOptions_BeginningBalance.Checked Then

                    DataRow(RowFields.DataOption.ToString) = CInt(DataOptions.BeginningBalance)

                ElseIf RadioButtonDataOptions_PeriodChange.Checked Then

                    DataRow(RowFields.DataOption.ToString) = CInt(DataOptions.PeriodChange)

                End If

                For Each RelatedRowDataRow In _RelatedRowsDataTable.Select(RelatedRowFields.RowID.ToString & " = " & _RowDataRow(RowFields.ID.ToString))

                    _RelatedRowsDataTable.Rows.Remove(RelatedRowDataRow)

                Next

                For Each RelatedRowDataRow In DirectCast(DirectCast(DataGridViewRightSection_RelatedRows.DataSource, System.Windows.Forms.BindingSource).DataSource, System.Data.DataTable).Select

                    NewRelatedRowDataRow = _RelatedRowsDataTable.NewRow()

                    NewRelatedRowDataRow(RelatedRowFields.RowID.ToString) = DataRow(RowFields.ID.ToString)
                    NewRelatedRowDataRow(RelatedRowFields.RelatedRowID.ToString) = RelatedRowDataRow(RowFields.ID.ToString)
                    NewRelatedRowDataRow(RelatedRowFields.RelatedRowIndex.ToString) = RelatedRowDataRow(RowFields.RowIndex.ToString)
                    NewRelatedRowDataRow(RelatedRowFields.RelatedRowDescription.ToString) = RelatedRowDataRow(RowFields.Description.ToString)
                    NewRelatedRowDataRow(RelatedRowFields.RelatedRowOrder.ToString) = RelatedRowDataRow(RelatedRowFields.RelatedRowOrder.ToString)

                    _RelatedRowsDataTable.Rows.Add(NewRelatedRowDataRow)

                Next

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            If ComboBoxForm_Type.GetSelectedValue = RowTypes.Account Then

                TabControlForm_RowDetails.Visible = True

                TabItemRowDetails_AccountRowDetailsTab.Visible = True
                TabItemRowDetails_TotalRowDetailsTab.Visible = False

                'CheckBoxForm_Currency.Enabled = True
                CheckBoxForm_UnderlineAmount.Enabled = True
                CheckBoxForm_DoubleUnderlineAmount.Enabled = True
                CheckBoxForm_SuppressIfAllZeros.Enabled = True
                'NumericInputForm_NumberOfDecimalPlaces.Enabled = True

                ComboBoxForm_Balance.Enabled = True
                ComboBoxForm_DisplayType.Enabled = True

                RadioButtonAccountRowDetails_Account.Enabled = True
                ComboBoxAccountRowDetails_Account.Enabled = RadioButtonAccountRowDetails_Account.Checked

                RadioButtonAccountRowDetails_AccountGroup.Enabled = True
                ComboBoxAccountRowDetails_AccountGroup.Enabled = RadioButtonAccountRowDetails_AccountGroup.Checked

                RadioButtonAccountRowDetails_AccountRange.Enabled = True
                CheckBoxAccountRowDetails_UseBaseCodes.Enabled = RadioButtonAccountRowDetails_AccountRange.Checked
                ComboBoxAccountRowDetails_AccountRangeStart.Enabled = RadioButtonAccountRowDetails_AccountRange.Checked
                ComboBoxAccountRowDetails_AccountRangeTo.Enabled = RadioButtonAccountRowDetails_AccountRange.Checked

                RadioButtonAccountRowDetails_AccountType.Enabled = True
                ComboBoxAccountRowDetails_AccountType.Enabled = RadioButtonAccountRowDetails_AccountType.Checked

                RadioButtonAccountRowDetails_Wildcard.Enabled = True
                TextBoxAccountRowDetails_Wildcard.Enabled = RadioButtonAccountRowDetails_Wildcard.Checked

            ElseIf ComboBoxForm_Type.GetSelectedValue = RowTypes.Total Then

                TabControlForm_RowDetails.Visible = True

                TabItemRowDetails_AccountRowDetailsTab.Visible = False
                TabItemRowDetails_TotalRowDetailsTab.Visible = True

                'CheckBoxForm_Currency.Enabled = True
                CheckBoxForm_UnderlineAmount.Enabled = True
                CheckBoxForm_DoubleUnderlineAmount.Enabled = True
                CheckBoxForm_SuppressIfAllZeros.Enabled = False
                'NumericInputForm_NumberOfDecimalPlaces.Enabled = True

                ComboBoxForm_Balance.Enabled = True
                ComboBoxForm_DisplayType.Enabled = False
                ComboBoxForm_DisplayType.SelectedValue = CInt(DisplayTypes.Description)

            Else

                TabControlForm_RowDetails.Visible = False

                'CheckBoxForm_Currency.Enabled = False
                CheckBoxForm_UnderlineAmount.Enabled = False
                CheckBoxForm_DoubleUnderlineAmount.Enabled = False
                CheckBoxForm_SuppressIfAllZeros.Enabled = False
                'NumericInputForm_NumberOfDecimalPlaces.Enabled = False

                ComboBoxForm_Balance.Enabled = False
                ComboBoxForm_DisplayType.Enabled = False

            End If

            If ComboBoxForm_DisplayType.Enabled AndAlso ComboBoxForm_DisplayType.SelectedValue = DisplayTypes.AccountDescription Then

                CheckBoxForm_Rollup.Enabled = True

            Else

                CheckBoxForm_Rollup.Enabled = False
                CheckBoxForm_Rollup.Checked = False

            End If

            EnalbeOrDisableRelatedRows()

        End Sub
        Private Sub EnableOrDisablePeriodChange()

            PanelAccountRowDetails_DataCalculations.Enabled = Not RadioButtonDataOptions_PeriodChange.Checked

            If RadioButtonDataOptions_PeriodChange.Checked Then

                RadioButtonDataCalculations_SelectedPeriod.Checked = True

            End If

        End Sub
        Private Sub EnalbeOrDisableRelatedRows()

            ButtonRightSection_Add.Enabled = DataGridViewLeftSection_Rows.HasASelectedRow
            ButtonRightSection_AddAll.Enabled = DataGridViewLeftSection_Rows.HasASelectedRow
            ButtonRightSection_Remove.Enabled = DataGridViewRightSection_RelatedRows.HasASelectedRow
            ButtonRightSection_RemoveAll.Enabled = DataGridViewRightSection_RelatedRows.HasASelectedRow

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal RowsDataTable As System.Data.DataTable, ByVal RelatedRowsDataTable As System.Data.DataTable, ByVal RowDataRow As System.Data.DataRow, ByVal ReportType As ReportTypes) As System.Windows.Forms.DialogResult

            'objects
            Dim GLReportTemplateRowEditDialog As AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateRowEditDialog = Nothing

            GLReportTemplateRowEditDialog = New AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateRowEditDialog(RowsDataTable, RelatedRowsDataTable, RowDataRow, ReportType)

            ShowFormDialog = GLReportTemplateRowEditDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub GLReportTemplateRowEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

			'objects
			Dim GeneralLedgerAccountsList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing
			Dim EnumObjectsList As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing
			Dim EnumObjectAttribute As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing

            EnumObjectsList = New Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)

            EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(AccountTypes.CurrentAsset))
            EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(AccountTypes.FixedAsset))
            EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(AccountTypes.NonCurrentAsset))
            EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(AccountTypes.CurrentLiability))
            EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(AccountTypes.NonCurrentLiability))
            EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(AccountTypes.Equity))
            EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(AccountTypes.Income))
            EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(AccountTypes.ExpenseCOS))
            EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(AccountTypes.ExpenseOperating))
            EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(AccountTypes.IncomeOther))
            EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(AccountTypes.ExpenseOther))
            EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(AccountTypes.ExpenseTaxes))

            DataGridViewLeftSection_Rows.ItemDescription = "Row(s)"
            DataGridViewLeftSection_Rows.MultiSelect = True
            DataGridViewLeftSection_Rows.OptionsView.ColumnAutoWidth = True
            DataGridViewLeftSection_Rows.OptionsView.ShowFooter = False

            DataGridViewRightSection_RelatedRows.ItemDescription = "Related Row(s)"
            DataGridViewRightSection_RelatedRows.MultiSelect = True
            DataGridViewRightSection_RelatedRows.OptionsView.ColumnAutoWidth = True
            DataGridViewRightSection_RelatedRows.OptionsView.ShowFooter = False

            ComboBoxForm_Type.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(RowTypes), False)
            ComboBoxForm_Balance.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(BalanceTypes), False)
            ComboBoxForm_DisplayType.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(DisplayTypes), False)
            ComboBoxAccountRowDetails_AccountType.DataSource = EnumObjectsList
            ComboBoxTableRowDetails_TotalBy.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(TotalTypes), False)
            NumericInputForm_IndentSpaces.Properties.MinValue = 0
			'NumericInputForm_NumberOfDecimalPlaces.Properties.MinValue = 0

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				NumericInputForm_IndentSpaces.SetPropertySettings(AdvantageFramework.Database.Entities.GLReportTemplateRow.Properties.IndentSpaces)
				'NumericInputForm_NumberOfDecimalPlaces.SetPropertySettings( AdvantageFramework.Database.Entities.GLReportTemplateRow.Properties.NumberOfDecimalPlaces)

				If AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode).Any Then

					GeneralLedgerAccountsList = New Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)

					For Each EmployeeOffice In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode).ToList

						GeneralLedgerAccountsList.AddRange(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByOfficeCode(DbContext, EmployeeOffice.OfficeCode).ToList)

					Next

					GeneralLedgerAccountsList = GeneralLedgerAccountsList.OrderBy(Function(Entity) Entity.Code).ToList

				Else

					GeneralLedgerAccountsList = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(DbContext).ToList

				End If

				ComboBoxAccountRowDetails_Account.DataSource = GeneralLedgerAccountsList

				ComboBoxAccountRowDetails_AccountGroup.DataSource = AdvantageFramework.Database.Procedures.AccountGroup.Load(DbContext)

			End Using

			'NumericInputForm_NumberOfDecimalPlaces.Properties.MaxValue = 6

			Me.FormAction = WinForm.Presentation.FormActions.Loading

            'If _ReportType = ReportTypes.BalanceSheet Then

            '    RadioButtonDataCalculations_YearToDate.SecurityEnabled = False
            '    RadioButtonDataCalculations_All.SecurityEnabled = True

            'ElseIf _ReportType = ReportTypes.BalanceSheet Then

            '    RadioButtonDataCalculations_YearToDate.SecurityEnabled = True
            '    RadioButtonDataCalculations_All.SecurityEnabled = False

            'End If

            'RadioButtonDataCalculations_SelectedPeriod.SecurityEnabled = True

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Try

                        _GLReportTemplateRowDescriptionMaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(GetType(AdvantageFramework.Database.Entities.GLReportTemplateRow), RowFields.Description.ToString))

                    Catch ex As Exception
                        _GLReportTemplateRowDescriptionMaxLength = -1
                    End Try

                End Using

            Catch ex As Exception
                _GLReportTemplateRowDescriptionMaxLength = -1
            End Try

            Try

                If _RowDataRow Is Nothing Then

                    Me.Text = "Add Row"
                    ButtonForm_Add.Visible = True
                    ButtonForm_Update.Visible = False

					CheckBoxForm_IsVisible.Checked = True

					ComboBoxAccountRowDetails_AccountRangeStart.DataSource = GeneralLedgerAccountsList
					ComboBoxAccountRowDetails_AccountRangeTo.DataSource = GeneralLedgerAccountsList

					If _ReportType = ReportTypes.IncomeStatement Then

                        RadioButtonDataCalculations_YearToDate.Checked = True

                    Else

                        RadioButtonDataCalculations_All.Checked = True

                    End If

                Else

                    Me.Text = "Edit Row"
                    ButtonForm_Add.Visible = False
                    ButtonForm_Update.Visible = True

                    TextBoxForm_Description.Text = _RowDataRow(RowFields.Description.ToString)

					If _RowDataRow(RowFields.IsVisible.ToString) Is System.DBNull.Value Then

						CheckBoxForm_IsVisible.Checked = True

					Else

						CheckBoxForm_IsVisible.Checked = _RowDataRow(RowFields.IsVisible.ToString)

					End If

					If _RowDataRow(RowFields.Type.ToString) Is System.DBNull.Value Then

                        ComboBoxForm_Type.SelectedValue = CInt(RowTypes.Account)

                    Else

                        ComboBoxForm_Type.SelectedValue = _RowDataRow(RowFields.Type.ToString)

                    End If

                    If _RowDataRow(RowFields.BalanceType.ToString) Is System.DBNull.Value Then

                        ComboBoxForm_Balance.SelectedValue = CInt(BalanceTypes.Credit)

                    Else

                        ComboBoxForm_Balance.SelectedValue = _RowDataRow(RowFields.BalanceType.ToString)

                    End If

                    If _RowDataRow(RowFields.DisplayType.ToString) Is System.DBNull.Value Then

                        ComboBoxForm_DisplayType.SelectedValue = CInt(DisplayTypes.Description)

                    Else

                        ComboBoxForm_DisplayType.SelectedValue = _RowDataRow(RowFields.DisplayType.ToString)

                    End If

                    If _RowDataRow(RowFields.IndentSpaces.ToString) Is System.DBNull.Value Then

                        NumericInputForm_IndentSpaces.EditValue = 0

                    Else

                        NumericInputForm_IndentSpaces.EditValue = _RowDataRow(RowFields.IndentSpaces.ToString)

                    End If

                    If _RowDataRow(RowFields.RollUp.ToString) Is System.DBNull.Value Then

                        CheckBoxForm_Rollup.Checked = False

                    Else

                        CheckBoxForm_Rollup.Checked = _RowDataRow(RowFields.RollUp.ToString)

                    End If

                    If _RowDataRow(RowFields.IsBold.ToString) Is System.DBNull.Value Then

                        CheckBoxForm_Bold.Checked = False

                    Else

                        CheckBoxForm_Bold.Checked = _RowDataRow(RowFields.IsBold.ToString)

                    End If

                    If _RowDataRow(RowFields.UnderlineAmount.ToString) Is System.DBNull.Value Then

                        CheckBoxForm_UnderlineAmount.Checked = False

                    Else

                        CheckBoxForm_UnderlineAmount.Checked = _RowDataRow(RowFields.UnderlineAmount.ToString)

                    End If

                    If _RowDataRow(RowFields.DoubleUnderlineAmount.ToString) Is System.DBNull.Value Then

                        CheckBoxForm_DoubleUnderlineAmount.Checked = False

                    Else

                        CheckBoxForm_DoubleUnderlineAmount.Checked = _RowDataRow(RowFields.DoubleUnderlineAmount.ToString)

                    End If

                    If _RowDataRow(RowFields.SuppressIfAllZeros.ToString) Is System.DBNull.Value Then

                        CheckBoxForm_SuppressIfAllZeros.Checked = False

                    Else

                        CheckBoxForm_SuppressIfAllZeros.Checked = _RowDataRow(RowFields.SuppressIfAllZeros.ToString)

                    End If

                    'If _RowDataRow(RowFields.UseCurrencyFormat.ToString) Is System.DBNull.Value Then

                    '    CheckBoxForm_Currency.Checked = False

                    'Else

                    '    CheckBoxForm_Currency.Checked = _RowDataRow(RowFields.UseCurrencyFormat.ToString)

                    'End If

                    'If _RowDataRow(RowFields.NumberOfDecimalPlaces.ToString) Is System.DBNull.Value Then

                    '    NumericInputForm_NumberOfDecimalPlaces.EditValue = 0

                    'Else

                    '    NumericInputForm_NumberOfDecimalPlaces.EditValue = _RowDataRow(RowFields.NumberOfDecimalPlaces.ToString)

                    'End If

                    If _RowDataRow(RowFields.UseBaseAccountCodes.ToString) Is System.DBNull.Value Then

                        CheckBoxAccountRowDetails_UseBaseCodes.Checked = False

                    Else

                        CheckBoxAccountRowDetails_UseBaseCodes.Checked = _RowDataRow(RowFields.UseBaseAccountCodes.ToString)

                    End If

					If CheckBoxAccountRowDetails_UseBaseCodes.Checked Then

						ComboBoxAccountRowDetails_AccountRangeStart.DataSource = (From GLA In GeneralLedgerAccountsList
																				  Select [Code] = GLA.BaseCode,
																						 [Description] = GLA.BaseCode & " - " & GLA.Description
																				  Order By Code, Description
																				  Distinct).ToList
						ComboBoxAccountRowDetails_AccountRangeTo.DataSource = (From GLA In GeneralLedgerAccountsList
																			   Select [Code] = GLA.BaseCode,
																					  [Description] = GLA.BaseCode & " - " & GLA.Description
																			   Order By Code, Description
																			   Distinct).ToList

					Else

						ComboBoxAccountRowDetails_AccountRangeStart.DataSource = GeneralLedgerAccountsList
						ComboBoxAccountRowDetails_AccountRangeTo.DataSource = GeneralLedgerAccountsList

					End If

					If _RowDataRow(RowFields.LinkType.ToString) Is System.DBNull.Value Then

                        RadioButtonAccountRowDetails_AccountType.Checked = True
                        ComboBoxAccountRowDetails_AccountType.SelectedValue = CStr(CInt(AccountTypes.NonCurrentAsset))

                    ElseIf _RowDataRow(RowFields.LinkType.ToString) = LinkTypes.AccountType Then

                        RadioButtonAccountRowDetails_AccountType.Checked = True
                        ComboBoxAccountRowDetails_AccountType.SelectedValue = CStr(_RowDataRow(RowFields.AccountType.ToString))

                    ElseIf _RowDataRow(RowFields.LinkType.ToString) = LinkTypes.AccountGroup Then

                        RadioButtonAccountRowDetails_AccountGroup.Checked = True
                        ComboBoxAccountRowDetails_AccountGroup.SelectedValue = _RowDataRow(RowFields.AccountGroupCode.ToString)

                    ElseIf _RowDataRow(RowFields.LinkType.ToString) = LinkTypes.Account Then

                        RadioButtonAccountRowDetails_Account.Checked = True
                        ComboBoxAccountRowDetails_Account.SelectedValue = _RowDataRow(RowFields.GLACode.ToString)

                    ElseIf _RowDataRow(RowFields.LinkType.ToString) = LinkTypes.AccountRange Then

                        RadioButtonAccountRowDetails_AccountRange.Checked = True

                        ComboBoxAccountRowDetails_AccountRangeStart.SelectedValue = _RowDataRow(RowFields.GLACodeRangeStart.ToString)
                        ComboBoxAccountRowDetails_AccountRangeTo.SelectedValue = _RowDataRow(RowFields.GLACodeRangeTo.ToString)

                    ElseIf _RowDataRow(RowFields.LinkType.ToString) = LinkTypes.Wildcard Then

                        RadioButtonAccountRowDetails_Wildcard.Checked = True
                        TextBoxAccountRowDetails_Wildcard.Text = _RowDataRow(RowFields.Wildcard.ToString)

                    End If

                    If _RowDataRow(RowFields.TotalType.ToString) Is System.DBNull.Value Then

                        ComboBoxTableRowDetails_TotalBy.SelectedValue = CInt(TotalTypes.Adding)

                    Else

                        ComboBoxTableRowDetails_TotalBy.SelectedValue = _RowDataRow(RowFields.TotalType.ToString)

                    End If

                    If _RowDataRow(RowFields.DataCalculation.ToString) Is System.DBNull.Value Then

                        If _ReportType = ReportTypes.IncomeStatement Then

                            RadioButtonDataCalculations_YearToDate.Checked = True

                        Else

                            RadioButtonDataCalculations_All.Checked = True

                        End If

                    Else

                        If _RowDataRow(RowFields.DataCalculation.ToString) = DataCalculations.YearToDate Then

                            'If _ReportType <> ReportTypes.BalanceSheet Then

                            RadioButtonDataCalculations_YearToDate.Checked = True

                            'Else

                            '    RadioButtonDataCalculations_YearToDate.Checked = False
                            '    RadioButtonDataCalculations_All.Checked = True

                            'End If

                        ElseIf _RowDataRow(RowFields.DataCalculation.ToString) = DataCalculations.SelectedPeriod Then

                            RadioButtonDataCalculations_SelectedPeriod.Checked = True

                        ElseIf _RowDataRow(RowFields.DataCalculation.ToString) = DataCalculations.All Then

                            'If _ReportType <> ReportTypes.IncomeStatement Then

                            RadioButtonDataCalculations_All.Checked = True

                            'Else

                            '    RadioButtonDataCalculations_All.Checked = False
                            '    RadioButtonDataCalculations_YearToDate.Checked = True

                            'End If

                        End If

                    End If

                    If _RowDataRow(RowFields.DataOption.ToString) Is System.DBNull.Value Then

                        RadioButtonDataOptions_EndingBalance.Checked = True

                    Else

                        If _RowDataRow(RowFields.DataOption.ToString) = DataOptions.EndingBalance Then

                            RadioButtonDataOptions_EndingBalance.Checked = True

                        ElseIf _RowDataRow(RowFields.DataOption.ToString) = DataOptions.BeginningBalance Then

                            RadioButtonDataOptions_BeginningBalance.Checked = True

                        ElseIf _RowDataRow(RowFields.DataOption.ToString) = DataOptions.PeriodChange Then

                            RadioButtonDataOptions_PeriodChange.Checked = True

                        End If

                    End If

                End If

                LoadRelatedRows()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub GLReportTemplateRowEditDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Try

                    _RowDataRow = _RowsDataTable.NewRow

                    _RowDataRow(RowFields.RowIndex.ToString) = _RowsDataTable.Rows.Count

                    SaveRow(_RowDataRow)

                    _RowsDataTable.Rows.Add(_RowDataRow)

                Catch ex As Exception
                    ErrorMessage = ex.Message
                End Try

                If ErrorMessage = "" Then

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Update_Click(sender As Object, e As EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Try

                    SaveRow(_RowDataRow)

                Catch ex As Exception
                    ErrorMessage = ex.Message
                End Try

                If ErrorMessage = "" Then

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ComboBoxForm_Type_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxForm_Type.SelectedValueChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If Me.FormShown Then

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub ComboBoxForm_DisplayType_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxForm_DisplayType.SelectedValueChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If Me.FormShown Then

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub RadioButtonAccountRowDetails_AccountType_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonAccountRowDetails_AccountType.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If Me.FormShown Then

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub RadioButtonAccountRowDetails_AccountGroup_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonAccountRowDetails_AccountGroup.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If Me.FormShown Then

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub RadioButtonAccountRowDetails_Account_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonAccountRowDetails_Account.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If Me.FormShown Then

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub RadioButtonAccountRowDetails_AccountRange_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonAccountRowDetails_AccountRange.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If Me.FormShown Then

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub RadioButtonAccountRowDetails_Wildcard_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonAccountRowDetails_Wildcard.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If Me.FormShown Then

                    EnableOrDisableActions()

                End If

            End If

        End Sub
		Private Sub CheckBoxAccountRowDetails_UseBaseCodes_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxAccountRowDetails_UseBaseCodes.CheckedChanged

			'objects
			Dim GeneralLedgerAccountsList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing

			If Me.FormAction = WinForm.Presentation.FormActions.None Then

				If Me.FormShown Then

					Me.FormAction = WinForm.Presentation.FormActions.Loading

					Try

						Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

							GeneralLedgerAccountsList = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext).ToList

							If CheckBoxAccountRowDetails_UseBaseCodes.Checked Then

								ComboBoxAccountRowDetails_AccountRangeStart.DataSource = (From GLA In GeneralLedgerAccountsList
																						  Select [Code] = GLA.BaseCode,
																								 [Description] = GLA.BaseCode & " - " & GLA.Description
																						  Order By Code, Description
																						  Distinct).ToList
								ComboBoxAccountRowDetails_AccountRangeTo.DataSource = (From GLA In GeneralLedgerAccountsList
																					   Select [Code] = GLA.BaseCode,
																							  [Description] = GLA.BaseCode & " - " & GLA.Description
																					   Order By Code, Description
																					   Distinct).ToList

							Else

								ComboBoxAccountRowDetails_AccountRangeStart.DataSource = GeneralLedgerAccountsList
								ComboBoxAccountRowDetails_AccountRangeTo.DataSource = GeneralLedgerAccountsList

							End If

						End Using

					Catch ex As Exception

					End Try

					Me.FormAction = WinForm.Presentation.FormActions.None

					EnableOrDisableActions()

				End If

			End If

		End Sub
		Private Sub ComboBoxAccountRowDetails_AccountRangeStart_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxAccountRowDetails_AccountRangeStart.SelectedValueChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If Me.FormShown Then

                    If RadioButtonAccountRowDetails_AccountRange.Checked Then

                        If ComboBoxAccountRowDetails_AccountRangeStart.HasASelectedValue AndAlso ComboBoxAccountRowDetails_AccountRangeTo.HasASelectedValue Then

                            If ComboBoxAccountRowDetails_AccountRangeStart.SelectedValue > ComboBoxAccountRowDetails_AccountRangeTo.SelectedValue Then

                                Me.ErrorProvider.SetError(ComboBoxAccountRowDetails_AccountRangeStart, "Start account must be less than 'To' account.")

                            Else

                                SetDefaultBalanceType(ComboBoxAccountRowDetails_AccountRangeStart.SelectedValue)

                            End If

                        Else

                            If ComboBoxAccountRowDetails_AccountRangeStart.HasASelectedValue = False Then

                                Me.ErrorProvider.SetError(ComboBoxAccountRowDetails_AccountRangeStart, "Please select a valid account code.")

                            End If

                            If ComboBoxAccountRowDetails_AccountRangeTo.HasASelectedValue = False Then

                                Me.ErrorProvider.SetError(ComboBoxAccountRowDetails_AccountRangeTo, "Please select a valid account code.")

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ComboBoxAccountRowDetails_AccountRangeTo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxAccountRowDetails_AccountRangeTo.SelectedValueChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If Me.FormShown Then

                    If RadioButtonAccountRowDetails_AccountRange.Checked Then

                        If ComboBoxAccountRowDetails_AccountRangeStart.HasASelectedValue AndAlso ComboBoxAccountRowDetails_AccountRangeTo.HasASelectedValue Then

                            If ComboBoxAccountRowDetails_AccountRangeStart.SelectedValue > ComboBoxAccountRowDetails_AccountRangeTo.SelectedValue Then

                                Me.ErrorProvider.SetError(ComboBoxAccountRowDetails_AccountRangeStart, "To account must be greater than 'Start' account.")

                            End If

                        Else

                            If ComboBoxAccountRowDetails_AccountRangeStart.HasASelectedValue = False Then

                                Me.ErrorProvider.SetError(ComboBoxAccountRowDetails_AccountRangeStart, "Please select a valid account code.")

                            End If

                            If ComboBoxAccountRowDetails_AccountRangeTo.HasASelectedValue = False Then

                                Me.ErrorProvider.SetError(ComboBoxAccountRowDetails_AccountRangeTo, "Please select a valid account code.")

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub TextBoxAccountRowDetails_Wildcard_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBoxAccountRowDetails_Wildcard.Validating

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If Me.FormShown Then

                    If RadioButtonAccountRowDetails_Wildcard.Checked Then

                        If TextBoxAccountRowDetails_Wildcard.Text = "" Then

                            Me.ErrorProvider.SetError(TextBoxAccountRowDetails_Wildcard, "Please enter a wildcard value.")

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonRightSection_Add_Click(sender As Object, e As EventArgs) Handles ButtonRightSection_Add.Click

            'objects
            Dim RowDataRow As System.Data.DataRow = Nothing
            Dim AvailableRowDataRow As System.Data.DataRow = Nothing
            Dim RelatedRowDataRow As System.Data.DataRow = Nothing

            For Each AvailableRowDataRow In DataGridViewLeftSection_Rows.GetAllSelectedRowsDataBoundItems.OfType(Of System.Data.DataRowView).Select(Function(DRV) DRV.Row).ToList

                RelatedRowDataRow = DirectCast(DirectCast(DataGridViewRightSection_RelatedRows.DataSource, System.Windows.Forms.BindingSource).DataSource, System.Data.DataTable).NewRow()

                RelatedRowDataRow.ItemArray = AvailableRowDataRow.ItemArray

                RelatedRowDataRow(RelatedRowFields.RelatedRowOrder.ToString) = DirectCast(DirectCast(DataGridViewRightSection_RelatedRows.DataSource, System.Windows.Forms.BindingSource).DataSource, System.Data.DataTable).Rows.Count + 1

                DirectCast(DirectCast(DataGridViewRightSection_RelatedRows.DataSource, System.Windows.Forms.BindingSource).DataSource, System.Data.DataTable).Rows.Add(RelatedRowDataRow)
                DirectCast(DirectCast(DataGridViewLeftSection_Rows.DataSource, System.Windows.Forms.BindingSource).DataSource, System.Data.DataTable).Rows.Remove(AvailableRowDataRow)

            Next

        End Sub
        Private Sub ButtonRightSection_AddAll_Click(sender As Object, e As EventArgs) Handles ButtonRightSection_AddAll.Click

            'objects
            Dim RowDataRow As System.Data.DataRow = Nothing
            Dim AvailableRowDataRow As System.Data.DataRow = Nothing
            Dim RelatedRowDataRow As System.Data.DataRow = Nothing

            For Each AvailableRowDataRow In DataGridViewLeftSection_Rows.GetAllRowsDataBoundItems.OfType(Of System.Data.DataRowView).Select(Function(DRV) DRV.Row).ToList

                RelatedRowDataRow = DirectCast(DirectCast(DataGridViewRightSection_RelatedRows.DataSource, System.Windows.Forms.BindingSource).DataSource, System.Data.DataTable).NewRow()

                RelatedRowDataRow.ItemArray = AvailableRowDataRow.ItemArray

                RelatedRowDataRow(RelatedRowFields.RelatedRowOrder.ToString) = DirectCast(DirectCast(DataGridViewRightSection_RelatedRows.DataSource, System.Windows.Forms.BindingSource).DataSource, System.Data.DataTable).Rows.Count + 1

                DirectCast(DirectCast(DataGridViewRightSection_RelatedRows.DataSource, System.Windows.Forms.BindingSource).DataSource, System.Data.DataTable).Rows.Add(RelatedRowDataRow)
                DirectCast(DirectCast(DataGridViewLeftSection_Rows.DataSource, System.Windows.Forms.BindingSource).DataSource, System.Data.DataTable).Rows.Remove(AvailableRowDataRow)

            Next

        End Sub
        Private Sub ButtonRightSection_Remove_Click(sender As Object, e As EventArgs) Handles ButtonRightSection_Remove.Click

            'objects
            Dim RowDataRow As System.Data.DataRow = Nothing
            Dim AvailableRowDataRow As System.Data.DataRow = Nothing
            Dim RelatedRowDataRow As System.Data.DataRow = Nothing

            For Each RelatedRowDataRow In DataGridViewRightSection_RelatedRows.GetAllSelectedRowsDataBoundItems.OfType(Of System.Data.DataRowView).Select(Function(DRV) DRV.Row).ToList

                AvailableRowDataRow = DirectCast(DirectCast(DataGridViewLeftSection_Rows.DataSource, System.Windows.Forms.BindingSource).DataSource, System.Data.DataTable).NewRow()

                AvailableRowDataRow.ItemArray = RelatedRowDataRow.ItemArray

                AvailableRowDataRow(RelatedRowFields.RelatedRowOrder.ToString) = 0

                DirectCast(DirectCast(DataGridViewLeftSection_Rows.DataSource, System.Windows.Forms.BindingSource).DataSource, System.Data.DataTable).Rows.Add(AvailableRowDataRow)
                DirectCast(DirectCast(DataGridViewRightSection_RelatedRows.DataSource, System.Windows.Forms.BindingSource).DataSource, System.Data.DataTable).Rows.Remove(RelatedRowDataRow)

            Next

        End Sub
        Private Sub ButtonRightSection_RemoveAll_Click(sender As Object, e As EventArgs) Handles ButtonRightSection_RemoveAll.Click

            'objects
            Dim RowDataRow As System.Data.DataRow = Nothing
            Dim AvailableRowDataRow As System.Data.DataRow = Nothing
            Dim RelatedRowDataRow As System.Data.DataRow = Nothing

            For Each RelatedRowDataRow In DataGridViewRightSection_RelatedRows.GetAllRowsDataBoundItems.OfType(Of System.Data.DataRowView).Select(Function(DRV) DRV.Row).ToList

                AvailableRowDataRow = DirectCast(DirectCast(DataGridViewLeftSection_Rows.DataSource, System.Windows.Forms.BindingSource).DataSource, System.Data.DataTable).NewRow()

                AvailableRowDataRow.ItemArray = RelatedRowDataRow.ItemArray

                AvailableRowDataRow(RelatedRowFields.RelatedRowOrder.ToString) = 0

                DirectCast(DirectCast(DataGridViewLeftSection_Rows.DataSource, System.Windows.Forms.BindingSource).DataSource, System.Data.DataTable).Rows.Add(AvailableRowDataRow)
                DirectCast(DirectCast(DataGridViewRightSection_RelatedRows.DataSource, System.Windows.Forms.BindingSource).DataSource, System.Data.DataTable).Rows.Remove(RelatedRowDataRow)

            Next

        End Sub
        Private Sub DataGridViewLeftSection_Rows_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_Rows.SelectionChangedEvent

            EnalbeOrDisableRelatedRows()

        End Sub
        Private Sub DataGridViewRightSection_RelatedRows_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewRightSection_RelatedRows.SelectionChangedEvent

            EnalbeOrDisableRelatedRows()

        End Sub
        Private Sub SetDefaultBalanceType(ByVal GLACode As String)

            'objects
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, GLACode)

                If GeneralLedgerAccount IsNot Nothing Then

                    If GeneralLedgerAccount.BalanceType = 0 Then

                        ComboBoxForm_Balance.SelectedValue = CInt(BalanceTypes.Credit)

                    Else

                        ComboBoxForm_Balance.SelectedValue = CInt(BalanceTypes.Debit)

                    End If

                End If

            End Using

        End Sub
        Private Sub ComboBoxAccountRowDetails_Account_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxAccountRowDetails_Account.SelectedValueChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If Me.FormShown Then

                    If RadioButtonAccountRowDetails_Account.Checked Then

                        SetDefaultBalanceType(ComboBoxAccountRowDetails_Account.SelectedValue)

                    End If

                End If

            End If

        End Sub
        Private Sub ComboBoxAccountRowDetails_AccountGroup_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxAccountRowDetails_AccountGroup.SelectedValueChanged

            'objects
            Dim GLACore As AdvantageFramework.Database.Core.GeneralLedgerAccount = Nothing
            Dim AccountGroupDetail As AdvantageFramework.Database.Entities.AccountGroupDetail = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If Me.FormShown Then

                    If RadioButtonAccountRowDetails_AccountGroup.Checked Then

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                For Each AccountGroupDetail In AdvantageFramework.Database.Procedures.AccountGroupDetail.LoadByAccountGroupCode(DbContext, ComboBoxAccountRowDetails_AccountGroup.SelectedValue).ToList

                                    If AccountGroupDetail.GLACode <> "" Then

                                        Try

                                            GLACore = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext).SingleOrDefault(Function(Entity) Entity.Code = AccountGroupDetail.GLACode)

                                        Catch ex As Exception
                                            GLACore = Nothing
                                        End Try

                                    Else

                                        Try

                                            GLACore = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext).Where(Function(Entity) Entity.Code >= AccountGroupDetail.GLACodeFrom AndAlso Entity.Code <= AccountGroupDetail.GLACodeTo).FirstOrDefault

                                        Catch ex As Exception

                                        End Try

                                    End If

                                    If GLACore IsNot Nothing Then

                                        Exit For

                                    End If

                                Next

                            End Using

                        Catch ex As Exception
                            GLACore = Nothing
                        End Try

                        If GLACore IsNot Nothing Then

                            SetDefaultBalanceType(GLACore.Code)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ComboBoxAccountRowDetails_AccountType_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxAccountRowDetails_AccountType.SelectedValueChanged

            'objects
            Dim GLACore As AdvantageFramework.Database.Core.GeneralLedgerAccount = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If Me.FormShown Then

                    If RadioButtonAccountRowDetails_AccountType.Checked Then

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                GLACore = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext).Where(Function(Entity) Entity.Type = ComboBoxAccountRowDetails_AccountType.SelectedValue).FirstOrDefault

                            End Using

                        Catch ex As Exception
                            GLACore = Nothing
                        End Try

                        If GLACore IsNot Nothing Then

                            SetDefaultBalanceType(GLACore.Code)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub RadioButtonDataOptions_PeriodChange_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonDataOptions_PeriodChange.CheckedChanged

            EnableOrDisablePeriodChange()

        End Sub
        Private Sub CheckBoxForm_UnderlineAmount_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_UnderlineAmount.CheckedChanged

            If CheckBoxForm_UnderlineAmount.Checked Then

                CheckBoxForm_DoubleUnderlineAmount.Checked = False

            End If

        End Sub
        Private Sub CheckBoxForm_DoubleUnderlineAmount_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_DoubleUnderlineAmount.CheckedChanged

            If CheckBoxForm_DoubleUnderlineAmount.Checked Then

                CheckBoxForm_UnderlineAmount.Checked = False

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
