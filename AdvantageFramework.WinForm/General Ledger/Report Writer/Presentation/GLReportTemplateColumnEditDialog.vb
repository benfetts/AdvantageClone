Namespace GeneralLedger.ReportWriter.Presentation

    Public Class GLReportTemplateColumnEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ColumnsDataTable As System.Data.DataTable = Nothing
        Private _RowsDataTable As System.Data.DataTable = Nothing
        Private _PercentOfRowColumnDataTable As System.Data.DataTable = Nothing
        Private _ColumnRow As System.Data.DataRow = Nothing
        Private _ReportType As ReportTypes = ReportTypes.IncomeStatement

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal ColumnsDataTable As System.Data.DataTable, ByVal RowsDataTable As System.Data.DataTable, ByVal PercentOfRowColumnDataTable As System.Data.DataTable, ByVal ColumnRow As System.Data.DataRow, ByVal ReportType As ReportTypes)

            ' This call is required by the designer.
            InitializeComponent()

            _ColumnsDataTable = ColumnsDataTable
            _RowsDataTable = RowsDataTable
            _PercentOfRowColumnDataTable = PercentOfRowColumnDataTable
            _ColumnRow = ColumnRow
            _ReportType = ReportType

        End Sub
        Private Sub LoadPercentOfRowColumnRows()

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim GridLookupDataTable As System.Data.DataTable = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim LoadNewDataTable As Boolean = True
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            DataTable = New System.Data.DataTable

            DataColumn = DataTable.Columns.Add(PercentOfRowColumnFields.RowID.ToString, GetType(Integer))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = 0

            DataColumn = DataTable.Columns.Add(PercentOfRowColumnFields.RowIndex.ToString, GetType(Integer))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = 0

            DataColumn = DataTable.Columns.Add(PercentOfRowColumnFields.RowDescription.ToString, GetType(String))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = ""

            DataColumn = DataTable.Columns.Add(PercentOfRowColumnFields.PercentOfRowID.ToString, GetType(Integer))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = System.DBNull.Value
            DataColumn.Caption = "PercentOfRow"

            If _ColumnRow IsNot Nothing Then

                If _PercentOfRowColumnDataTable.Select(PercentOfRowColumnFields.ColumnID.ToString & " = " & _ColumnRow(ColumnFields.ID.ToString)).Any Then

                    LoadNewDataTable = False

                    For Each PercentOfRowColumnDataRow In _PercentOfRowColumnDataTable.Select(PercentOfRowColumnFields.ColumnID.ToString & " = " & _ColumnRow(ColumnFields.ID.ToString))

                        DataRow = DataTable.NewRow()

                        DataRow(PercentOfRowColumnFields.RowID.ToString) = PercentOfRowColumnDataRow(PercentOfRowColumnFields.RowID.ToString)
                        DataRow(PercentOfRowColumnFields.RowIndex.ToString) = PercentOfRowColumnDataRow(PercentOfRowColumnFields.RowIndex.ToString)
                        DataRow(PercentOfRowColumnFields.RowDescription.ToString) = PercentOfRowColumnDataRow(PercentOfRowColumnFields.RowDescription.ToString)
                        DataRow(PercentOfRowColumnFields.PercentOfRowID.ToString) = PercentOfRowColumnDataRow(PercentOfRowColumnFields.PercentOfRowID.ToString)

                        DataTable.Rows.Add(DataRow)

                    Next

                    For Each RowDataRow In _RowsDataTable.Select(RowFields.Type.ToString & " <> " & RowTypes.Other)

                        If _PercentOfRowColumnDataTable.Select(PercentOfRowColumnFields.ColumnID.ToString & " = " & _ColumnRow(ColumnFields.ID.ToString) & " AND " & PercentOfRowColumnFields.RowID.ToString & " = " & RowDataRow(RowFields.ID.ToString)).Any = False Then

                            DataRow = DataTable.NewRow()

                            DataRow(PercentOfRowColumnFields.RowID.ToString) = RowDataRow(RowFields.ID.ToString)
                            DataRow(PercentOfRowColumnFields.RowIndex.ToString) = RowDataRow(RowFields.RowIndex.ToString)
                            DataRow(PercentOfRowColumnFields.RowDescription.ToString) = RowDataRow(RowFields.Description.ToString)
                            DataRow(PercentOfRowColumnFields.PercentOfRowID.ToString) = System.DBNull.Value

                            DataTable.Rows.Add(DataRow)

                        End If

                    Next

                End If

            End If

            If LoadNewDataTable Then

                For Each RowDataRow In _RowsDataTable.Select(RowFields.Type.ToString & " <> " & RowTypes.Other)

                    DataRow = DataTable.NewRow()

                    DataRow(PercentOfRowColumnFields.RowID.ToString) = RowDataRow(RowFields.ID.ToString)
                    DataRow(PercentOfRowColumnFields.RowIndex.ToString) = RowDataRow(RowFields.RowIndex.ToString)
                    DataRow(PercentOfRowColumnFields.RowDescription.ToString) = RowDataRow(RowFields.Description.ToString)
                    DataRow(PercentOfRowColumnFields.PercentOfRowID.ToString) = System.DBNull.Value

                    DataTable.Rows.Add(DataRow)

                Next

            End If

            DataGridViewPercentOfRowColumnDetails_Rows.DataSource = DataTable

            For Each GridColumn In DataGridViewPercentOfRowColumnDetails_Rows.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.FieldName = PercentOfRowColumnFields.RowID.ToString Then

                    GridColumn.Visible = False

                ElseIf GridColumn.FieldName = PercentOfRowColumnFields.PercentOfRowID.ToString Then

                    GridColumn.Visible = True

                    SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl

                    SubItemGridLookUpEditControl.Session = Session
                    SubItemGridLookUpEditControl.ControlType = WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default

                    SubItemGridLookUpEditControl.ValueType = GetType(Integer)
                    SubItemGridLookUpEditControl.NullText = ""
                    SubItemGridLookUpEditControl.DisplayMember = "Description"
                    SubItemGridLookUpEditControl.ValueMember = "ID"
                    SubItemGridLookUpEditControl.View.Columns.Add(WinForm.Presentation.Controls.GetNewColumn(RowFields.ID.ToString, False))
                    SubItemGridLookUpEditControl.View.Columns.Add(WinForm.Presentation.Controls.GetNewColumn(RowFields.RowIndex.ToString))
                    SubItemGridLookUpEditControl.View.Columns.Add(WinForm.Presentation.Controls.GetNewColumn(RowFields.Description.ToString))
                    SubItemGridLookUpEditControl.ExtraComboBoxItem = WinForm.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.PleaseSelect
                    SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                    SubItemGridLookUpEditControl.DataSource = If(_RowsDataTable.Select(RowFields.Type.ToString & " <> " & CInt(RowTypes.Other).ToString).Any, _RowsDataTable.Select(RowFields.Type.ToString & " <> " & CInt(RowTypes.Other).ToString).CopyToDataTable, _RowsDataTable.Clone)

                    If _RowsDataTable.Select(RowFields.Type.ToString & " <> " & CInt(RowTypes.Other).ToString).Any Then

                        GridLookupDataTable = _RowsDataTable.Select(RowFields.Type.ToString & " <> " & CInt(RowTypes.Other).ToString).CopyToDataTable

                    Else

                        GridLookupDataTable = _RowsDataTable.Clone

                    End If

                    GridLookupDataTable.DefaultView.Sort = RowFields.RowIndex.ToString

                    SubItemGridLookUpEditControl.DataSource = GridLookupDataTable

                    GridColumn.ColumnEdit = SubItemGridLookUpEditControl

                Else

                    GridColumn.Visible = True

                End If

            Next

            DataGridViewPercentOfRowColumnDetails_Rows.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If ComboBoxForm_Type.GetSelectedValue = ColumnTypes.Blank Then

                ComboBoxForm_Type.Enabled = True
                CheckBoxForm_Visible.Enabled = True
                CheckBoxForm_Currency.Enabled = False
                CheckBoxForm_UnderlineColumnHeader.Enabled = True
                NumericInputForm_NumberOfDecimalPlaces.Enabled = False

                TabControlForm_ColumnDetails.Visible = False

                TabItemColumnDetails_DataColumnDetailsTab.Visible = False
                TabItemColumnDetails_ExpressionColumnDetailsTab.Visible = False
                TabItemColumnDetails_PercentOfRowColumnDetailsTab.Visible = False
                TabItemColumnDetails_VariancePercentVarianceColumnDetailsTab.Visible = False

                ComboBoxPercentOfRowColumnDetails_Column.SetRequired(False)

                ComboBoxVariancePercentVarianceColumnDetails_Column1.SetRequired(False)
                ComboBoxVariancePercentVarianceColumnDetails_Column2.SetRequired(False)

            ElseIf ComboBoxForm_Type.GetSelectedValue = ColumnTypes.Expression Then

                ComboBoxForm_Type.Enabled = True
                CheckBoxForm_Visible.Enabled = True
                CheckBoxForm_Currency.Enabled = True
                CheckBoxForm_UnderlineColumnHeader.Enabled = True
                NumericInputForm_NumberOfDecimalPlaces.Enabled = True

                TabControlForm_ColumnDetails.Visible = True

                TabItemColumnDetails_DataColumnDetailsTab.Visible = False
                TabItemColumnDetails_ExpressionColumnDetailsTab.Visible = True
                TabItemColumnDetails_PercentOfRowColumnDetailsTab.Visible = False
                TabItemColumnDetails_VariancePercentVarianceColumnDetailsTab.Visible = False

                ComboBoxPercentOfRowColumnDetails_Column.SetRequired(False)

                ComboBoxVariancePercentVarianceColumnDetails_Column1.SetRequired(False)
                ComboBoxVariancePercentVarianceColumnDetails_Column2.SetRequired(False)

            ElseIf ComboBoxForm_Type.GetSelectedValue = ColumnTypes.Variance Then

                ComboBoxForm_Type.Enabled = True
                CheckBoxForm_Visible.Enabled = True
                CheckBoxForm_Currency.Enabled = True
                CheckBoxForm_UnderlineColumnHeader.Enabled = True
                NumericInputForm_NumberOfDecimalPlaces.Enabled = True

                TabControlForm_ColumnDetails.Visible = True

                TabItemColumnDetails_DataColumnDetailsTab.Visible = False
                TabItemColumnDetails_ExpressionColumnDetailsTab.Visible = False
                TabItemColumnDetails_PercentOfRowColumnDetailsTab.Visible = False
                TabItemColumnDetails_VariancePercentVarianceColumnDetailsTab.Visible = True

                ComboBoxPercentOfRowColumnDetails_Column.SetRequired(False)

                ComboBoxVariancePercentVarianceColumnDetails_Column1.SetRequired(True)
                ComboBoxVariancePercentVarianceColumnDetails_Column2.SetRequired(True)

            ElseIf ComboBoxForm_Type.GetSelectedValue = ColumnTypes.PercentVariance Then

                ComboBoxForm_Type.Enabled = True
                CheckBoxForm_Visible.Enabled = True
                CheckBoxForm_Currency.Enabled = False
                CheckBoxForm_UnderlineColumnHeader.Enabled = True
                NumericInputForm_NumberOfDecimalPlaces.Enabled = True

                TabControlForm_ColumnDetails.Visible = True

                TabItemColumnDetails_DataColumnDetailsTab.Visible = False
                TabItemColumnDetails_ExpressionColumnDetailsTab.Visible = False
                TabItemColumnDetails_PercentOfRowColumnDetailsTab.Visible = False
                TabItemColumnDetails_VariancePercentVarianceColumnDetailsTab.Visible = True

                ComboBoxPercentOfRowColumnDetails_Column.SetRequired(False)

                ComboBoxVariancePercentVarianceColumnDetails_Column1.SetRequired(True)
                ComboBoxVariancePercentVarianceColumnDetails_Column2.SetRequired(True)

            ElseIf ComboBoxForm_Type.GetSelectedValue = ColumnTypes.PercentOfRow Then

                ComboBoxForm_Type.Enabled = True
                CheckBoxForm_Visible.Enabled = True
                CheckBoxForm_Currency.Enabled = False
                CheckBoxForm_UnderlineColumnHeader.Enabled = True
                NumericInputForm_NumberOfDecimalPlaces.Enabled = True

                TabControlForm_ColumnDetails.Visible = True

                TabItemColumnDetails_DataColumnDetailsTab.Visible = False
                TabItemColumnDetails_ExpressionColumnDetailsTab.Visible = False
                TabItemColumnDetails_PercentOfRowColumnDetailsTab.Visible = True
                TabItemColumnDetails_VariancePercentVarianceColumnDetailsTab.Visible = False

                ComboBoxPercentOfRowColumnDetails_Column.SetRequired(True)

                ComboBoxVariancePercentVarianceColumnDetails_Column1.SetRequired(False)
                ComboBoxVariancePercentVarianceColumnDetails_Column2.SetRequired(False)

            Else

                ComboBoxForm_Type.Enabled = True
                CheckBoxForm_Visible.Enabled = True
                CheckBoxForm_Currency.Enabled = True
                CheckBoxForm_UnderlineColumnHeader.Enabled = True
                NumericInputForm_NumberOfDecimalPlaces.Enabled = True

                TabControlForm_ColumnDetails.Visible = True

                TabItemColumnDetails_DataColumnDetailsTab.Visible = True
                TabItemColumnDetails_ExpressionColumnDetailsTab.Visible = False
                TabItemColumnDetails_PercentOfRowColumnDetailsTab.Visible = False
                TabItemColumnDetails_VariancePercentVarianceColumnDetailsTab.Visible = False

                ComboBoxPercentOfRowColumnDetails_Column.SetRequired(False)

                ComboBoxVariancePercentVarianceColumnDetails_Column1.SetRequired(False)
                ComboBoxVariancePercentVarianceColumnDetails_Column2.SetRequired(False)

                PanelDataColumnDetails_DataCalculations.Enabled = CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.Checked
                PanelDataColumnDetails_DataOptions.Enabled = CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.Checked

            End If

            EnableOrDisablePeriodChange()

        End Sub
        Private Sub EnableOrDisablePeriodChange()

            If CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.Checked Then

                PanelDataColumnDetails_DataOptions.Enabled = True
                PanelDataColumnDetails_DataCalculations.Enabled = Not RadioButtonDataOptions_PeriodChange.Checked

                If RadioButtonDataOptions_PeriodChange.Checked Then

                    RadioButtonDataCalculations_SelectedPeriod.Checked = True

                End If

            Else

                PanelDataColumnDetails_DataOptions.Enabled = False
                PanelDataColumnDetails_DataCalculations.Enabled = False

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ColumnsDataTable As System.Data.DataTable, ByVal RowsDataTable As System.Data.DataTable, ByVal PercentOfRowColumnDataTable As System.Data.DataTable, ByVal ColumnRow As System.Data.DataRow, ByVal ReportType As ReportTypes) As System.Windows.Forms.DialogResult

            'objects
            Dim GLReportTemplateColumnEditDialog As AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateColumnEditDialog = Nothing

            GLReportTemplateColumnEditDialog = New AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateColumnEditDialog(ColumnsDataTable, RowsDataTable, PercentOfRowColumnDataTable, ColumnRow, ReportType)

            ShowFormDialog = GLReportTemplateColumnEditDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub GLReportTemplateColumnEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim EnumObjects As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing

            DataGridViewPercentOfRowColumnDetails_Rows.OptionsView.ShowFooter = False
            DataGridViewPercentOfRowColumnDetails_Rows.MultiSelect = False
            DataGridViewPercentOfRowColumnDetails_Rows.OptionsView.ShowViewCaption = False

            TextBoxForm_Name.SetDefaultPropertySettings(30, "Column Name", BaseClasses.PropertyTypes.Code, True)
            TextBoxForm_Name.SetDefaultPropertySettings(30, "Column Description", BaseClasses.PropertyTypes.Default, False)
            ComboBoxForm_Type.SetRequired(True)
            ComboBoxDataColumnDetails_DataType.SetRequired(True)
            NumericInputDataColumnDetails_PreviousYears.SetPropertySettings("Previous Years", True)
            NumericInputDataColumnDetails_PreviousYears.Properties.MinValue = 0
            NumericInputForm_NumberOfDecimalPlaces.Properties.MinValue = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                NumericInputForm_NumberOfDecimalPlaces.SetPropertySettings(AdvantageFramework.Database.Entities.GLReportTemplateColumn.Properties.NumberOfDecimalPlaces)

                ComboBoxDataColumnDetails_OfficeFilter.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadWithOfficeLimitsOrderByOffice(Me.Session, DbContext).Include("Office").ToList.Where(Function(Entity) Entity.Office IsNot Nothing).Select(Function(Entity) Entity.Office).ToList

            End Using

            NumericInputForm_NumberOfDecimalPlaces.Properties.MaxValue = 6

            ComboBoxForm_Type.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(ColumnTypes), False)
            ComboBoxDataColumnDetails_DataType.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(ColumnDataTypes), False)
            ComboBoxDataColumnDetails_PeriodOption.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(PeriodOptions), False)

            LoadPercentOfRowColumnRows()

            CheckBoxForm_Visible.Checked = True

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

                EnumObjects = New Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)

                For Each DataRow In _ColumnsDataTable.Select()

                    If DataRow(ColumnFields.Type.ToString) = ColumnTypes.Data AndAlso (_ColumnRow Is Nothing OrElse _ColumnRow(ColumnFields.Name.ToString) <> DataRow(ColumnFields.Name.ToString)) Then

                        EnumObjects.Add(New AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute(DataRow(ColumnFields.Name.ToString), DataRow(ColumnFields.Name.ToString)))

                    End If

                Next

                ComboBoxVariancePercentVarianceColumnDetails_Column1.DataSource = EnumObjects.ToList
                ComboBoxVariancePercentVarianceColumnDetails_Column2.DataSource = EnumObjects.ToList
                ComboBoxPercentOfRowColumnDetails_Column.DataSource = EnumObjects.ToList

            Catch ex As Exception
                ComboBoxVariancePercentVarianceColumnDetails_Column1.DataSource = New Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)
                ComboBoxVariancePercentVarianceColumnDetails_Column2.DataSource = New Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)
                ComboBoxPercentOfRowColumnDetails_Column.DataSource = New Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)
            End Try

            Try

                If _ColumnRow Is Nothing Then

                    Me.Text = "Add Column"
                    ButtonForm_Add.Visible = True
                    ButtonForm_Update.Visible = False

                    If _ReportType = ReportTypes.IncomeStatement Then

                        RadioButtonDataCalculations_YearToDate.Checked = True

                    Else

                        RadioButtonDataCalculations_All.Checked = True

                    End If

                Else

                    Me.Text = "Edit Column"
                    ButtonForm_Add.Visible = False
                    ButtonForm_Update.Visible = True

                    TextBoxForm_Name.Text = _ColumnRow(ColumnFields.Name.ToString)
                    TextBoxForm_Description.Text = _ColumnRow(ColumnFields.Description.ToString)
                    ComboBoxForm_Type.SelectedValue = CStr(_ColumnRow(ColumnFields.Type.ToString))
                    ComboBoxDataColumnDetails_DataType.SelectedValue = CStr(_ColumnRow(ColumnFields.DataType.ToString))
                    NumericInputDataColumnDetails_PreviousYears.EditValue = CStr(_ColumnRow(ColumnFields.PreviousYears.ToString))
                    ComboBoxDataColumnDetails_PeriodOption.SelectedValue = _ColumnRow(ColumnFields.PeriodOption.ToString)
                    CheckBoxForm_Visible.Checked = _ColumnRow(ColumnFields.IsVisible.ToString)
                    CheckBoxForm_UnderlineColumnHeader.Checked = _ColumnRow(ColumnFields.UnderlineColumnHeader.ToString)
                    TextBoxExpressionColumnDetails_Expression.Text = _ColumnRow(ColumnFields.Expression.ToString)
                    CheckBoxForm_Currency.Checked = _ColumnRow(ColumnFields.UseCurrencyFormat.ToString)
                    NumericInputForm_NumberOfDecimalPlaces.EditValue = _ColumnRow(ColumnFields.NumberOfDecimalPlaces.ToString)
                    ComboBoxVariancePercentVarianceColumnDetails_Column1.SelectedValue = If(_ColumnRow(ColumnFields.Column1Name.ToString) Is System.DBNull.Value, Nothing, _ColumnRow(ColumnFields.Column1Name.ToString))
                    ComboBoxVariancePercentVarianceColumnDetails_Column2.SelectedValue = If(_ColumnRow(ColumnFields.Column2Name.ToString) Is System.DBNull.Value, Nothing, _ColumnRow(ColumnFields.Column2Name.ToString))
                    ComboBoxPercentOfRowColumnDetails_Column.SelectedValue = If(_ColumnRow(ColumnFields.PctOfRowColumnName.ToString) Is System.DBNull.Value, Nothing, _ColumnRow(ColumnFields.PctOfRowColumnName.ToString))
                    ComboBoxDataColumnDetails_OfficeFilter.SelectedValue = If(_ColumnRow(ColumnFields.OfficeCode.ToString) Is System.DBNull.Value, Nothing, _ColumnRow(ColumnFields.OfficeCode.ToString))
                    CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.Checked = _ColumnRow(ColumnFields.OverrideRowDataOptionsAndCalculations.ToString)

                    If _ColumnRow(ColumnFields.DataCalculation.ToString) Is System.DBNull.Value Then

                        If _ReportType = ReportTypes.IncomeStatement Then

                            RadioButtonDataCalculations_YearToDate.Checked = True

                        Else

                            RadioButtonDataCalculations_All.Checked = True

                        End If

                    Else

                        If _ColumnRow(ColumnFields.DataCalculation.ToString) = DataCalculations.YearToDate Then

                            'If _ReportType <> ReportTypes.BalanceSheet Then

                            RadioButtonDataCalculations_YearToDate.Checked = True

                            'Else

                            '    RadioButtonDataCalculations_YearToDate.Checked = False
                            '    RadioButtonDataCalculations_All.Checked = True

                            'End If

                        ElseIf _ColumnRow(ColumnFields.DataCalculation.ToString) = DataCalculations.SelectedPeriod Then

                            RadioButtonDataCalculations_SelectedPeriod.Checked = True

                        ElseIf _ColumnRow(ColumnFields.DataCalculation.ToString) = DataCalculations.All Then

                            'If _ReportType <> ReportTypes.IncomeStatement Then

                            RadioButtonDataCalculations_All.Checked = True

                            'Else

                            '    RadioButtonDataCalculations_All.Checked = False
                            '    RadioButtonDataCalculations_YearToDate.Checked = True

                            'End If

                        End If

                    End If

                    If _ColumnRow(ColumnFields.DataOption.ToString) Is System.DBNull.Value Then

                        RadioButtonDataOptions_EndingBalance.Checked = True

                    Else

                        If _ColumnRow(ColumnFields.DataOption.ToString) = DataOptions.EndingBalance Then

                            RadioButtonDataOptions_EndingBalance.Checked = True

                        ElseIf _ColumnRow(ColumnFields.DataOption.ToString) = DataOptions.BeginningBalance Then

                            RadioButtonDataOptions_BeginningBalance.Checked = True

                        ElseIf _ColumnRow(ColumnFields.DataOption.ToString) = DataOptions.PeriodChange Then

                            RadioButtonDataOptions_PeriodChange.Checked = True

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub GLReportTemplateColumnEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim PercentOfRowColumnDataRow As System.Data.DataRow = Nothing
            Dim RowDataRow As System.Data.DataRow = Nothing

            If Me.Validator Then

                If _ColumnsDataTable.Rows.OfType(Of System.Data.DataRow).Any(Function(DR) DR(ColumnFields.Name.ToString).ToString.ToUpper = TextBoxForm_Name.Text.ToUpper) = False Then

                    If AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(StatementFields), False).Any(Function(FieldName) FieldName.ToUpper = TextBoxForm_Name.Text.ToUpper) = False Then

                        Try

                            _ColumnRow = _ColumnsDataTable.NewRow

                            _ColumnRow(ColumnFields.Name.ToString) = TextBoxForm_Name.Text
                            _ColumnRow(ColumnFields.Description.ToString) = TextBoxForm_Description.Text
                            _ColumnRow(ColumnFields.Type.ToString) = ComboBoxForm_Type.SelectedValue
                            _ColumnRow(ColumnFields.ColumnIndex.ToString) = _ColumnsDataTable.Rows.Count
                            _ColumnRow(ColumnFields.DataType.ToString) = ComboBoxDataColumnDetails_DataType.SelectedValue
                            _ColumnRow(ColumnFields.PreviousYears.ToString) = NumericInputDataColumnDetails_PreviousYears.EditValue
                            _ColumnRow(ColumnFields.PeriodOption.ToString) = ComboBoxDataColumnDetails_PeriodOption.SelectedValue
                            _ColumnRow(ColumnFields.IsVisible.ToString) = CheckBoxForm_Visible.Checked
                            _ColumnRow(ColumnFields.UnderlineColumnHeader.ToString) = CheckBoxForm_UnderlineColumnHeader.Checked
                            _ColumnRow(ColumnFields.Expression.ToString) = TextBoxExpressionColumnDetails_Expression.Text
                            _ColumnRow(ColumnFields.UseCurrencyFormat.ToString) = CheckBoxForm_Currency.Checked
                            _ColumnRow(ColumnFields.NumberOfDecimalPlaces.ToString) = NumericInputForm_NumberOfDecimalPlaces.EditValue
                            _ColumnRow(ColumnFields.Column1Name.ToString) = ComboBoxVariancePercentVarianceColumnDetails_Column1.GetSelectedValue
                            _ColumnRow(ColumnFields.Column2Name.ToString) = ComboBoxVariancePercentVarianceColumnDetails_Column2.GetSelectedValue
                            _ColumnRow(ColumnFields.PctOfRowColumnName.ToString) = ComboBoxPercentOfRowColumnDetails_Column.GetSelectedValue
                            _ColumnRow(ColumnFields.OfficeCode.ToString) = If(ComboBoxDataColumnDetails_OfficeFilter.GetSelectedValue Is Nothing, System.DBNull.Value, ComboBoxDataColumnDetails_OfficeFilter.GetSelectedValue)
                            _ColumnRow(ColumnFields.OverrideRowDataOptionsAndCalculations.ToString) = CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.Checked

                            If RadioButtonDataCalculations_YearToDate.Checked Then

                                _ColumnRow(ColumnFields.DataCalculation.ToString) = CInt(DataCalculations.YearToDate)

                            ElseIf RadioButtonDataCalculations_SelectedPeriod.Checked Then

                                _ColumnRow(ColumnFields.DataCalculation.ToString) = CInt(DataCalculations.SelectedPeriod)

                            ElseIf RadioButtonDataCalculations_All.Checked Then

                                _ColumnRow(ColumnFields.DataCalculation.ToString) = CInt(DataCalculations.All)

                            End If

                            If RadioButtonDataOptions_EndingBalance.Checked Then

                                _ColumnRow(ColumnFields.DataOption.ToString) = CInt(DataOptions.EndingBalance)

                            ElseIf RadioButtonDataOptions_BeginningBalance.Checked Then

                                _ColumnRow(ColumnFields.DataOption.ToString) = CInt(DataOptions.BeginningBalance)

                            ElseIf RadioButtonDataOptions_PeriodChange.Checked Then

                                _ColumnRow(ColumnFields.DataOption.ToString) = CInt(DataOptions.PeriodChange)

                            End If

                            _ColumnsDataTable.Rows.Add(_ColumnRow)

                            If _ColumnRow(ColumnFields.Type.ToString) = ColumnTypes.PercentOfRow Then

                                For Each DataRow In DataGridViewPercentOfRowColumnDetails_Rows.GetAllRowsDataBoundItems.OfType(Of System.Data.DataRowView).Select(Function(DRV) DRV.Row).ToList

                                    PercentOfRowColumnDataRow = _PercentOfRowColumnDataTable.NewRow()

                                    PercentOfRowColumnDataRow(PercentOfRowColumnFields.ColumnID.ToString) = _ColumnRow(ColumnFields.ID.ToString)
                                    PercentOfRowColumnDataRow(PercentOfRowColumnFields.ColumnName.ToString) = _ColumnRow(ColumnFields.Name.ToString)
                                    PercentOfRowColumnDataRow(PercentOfRowColumnFields.RowID.ToString) = DataRow(PercentOfRowColumnFields.RowID.ToString)
                                    PercentOfRowColumnDataRow(PercentOfRowColumnFields.RowIndex.ToString) = DataRow(PercentOfRowColumnFields.RowIndex.ToString)
                                    PercentOfRowColumnDataRow(PercentOfRowColumnFields.RowDescription.ToString) = DataRow(PercentOfRowColumnFields.RowDescription.ToString)

                                    Try

                                        RowDataRow = _RowsDataTable.Select(RowFields.ID.ToString & " = " & DataRow(PercentOfRowColumnFields.PercentOfRowID.ToString)).SingleOrDefault

                                    Catch ex As Exception
                                        RowDataRow = Nothing
                                    End Try

                                    If RowDataRow IsNot Nothing Then

                                        PercentOfRowColumnDataRow(PercentOfRowColumnFields.PercentOfRowID.ToString) = RowDataRow(RowFields.ID.ToString)
                                        PercentOfRowColumnDataRow(PercentOfRowColumnFields.PercentOfRowIndex.ToString) = RowDataRow(RowFields.RowIndex.ToString)
                                        PercentOfRowColumnDataRow(PercentOfRowColumnFields.PercentOfRowDescription.ToString) = RowDataRow(RowFields.Description.ToString)

                                    End If

                                    _PercentOfRowColumnDataTable.Rows.Add(PercentOfRowColumnDataRow)

                                Next

                            End If

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

                        AdvantageFramework.WinForm.MessageBox.Show("Please enter a different column name. This column name is reserved for internal use.")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please enter a unqiue column name.")

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
            Dim PercentOfRowColumnDataRow As System.Data.DataRow = Nothing
            Dim RowDataRow As System.Data.DataRow = Nothing

            If Me.Validator Then

                If _ColumnsDataTable.Rows.OfType(Of System.Data.DataRow).Any(Function(DR) DR(ColumnFields.ID.ToString) <> _ColumnRow(ColumnFields.ID.ToString) AndAlso DR(ColumnFields.Name.ToString).ToString.ToUpper = TextBoxForm_Name.Text.ToUpper) = False Then

                    If AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(StatementFields), False).Any(Function(FieldName) FieldName.ToUpper = TextBoxForm_Name.Text.ToUpper) = False Then

                        Try

                            _ColumnRow(ColumnFields.Name.ToString) = TextBoxForm_Name.Text
                            _ColumnRow(ColumnFields.Description.ToString) = TextBoxForm_Description.Text
                            _ColumnRow(ColumnFields.Type.ToString) = ComboBoxForm_Type.SelectedValue
                            _ColumnRow(ColumnFields.ColumnIndex.ToString) = _ColumnsDataTable.Rows.IndexOf(_ColumnRow)
                            _ColumnRow(ColumnFields.DataType.ToString) = ComboBoxDataColumnDetails_DataType.SelectedValue
                            _ColumnRow(ColumnFields.PreviousYears.ToString) = NumericInputDataColumnDetails_PreviousYears.EditValue
                            _ColumnRow(ColumnFields.PeriodOption.ToString) = ComboBoxDataColumnDetails_PeriodOption.SelectedValue
                            _ColumnRow(ColumnFields.IsVisible.ToString) = CheckBoxForm_Visible.Checked
                            _ColumnRow(ColumnFields.UnderlineColumnHeader.ToString) = CheckBoxForm_UnderlineColumnHeader.Checked
                            _ColumnRow(ColumnFields.Expression.ToString) = TextBoxExpressionColumnDetails_Expression.Text
                            _ColumnRow(ColumnFields.UseCurrencyFormat.ToString) = CheckBoxForm_Currency.Checked
                            _ColumnRow(ColumnFields.NumberOfDecimalPlaces.ToString) = NumericInputForm_NumberOfDecimalPlaces.EditValue
                            _ColumnRow(ColumnFields.Column1Name.ToString) = ComboBoxVariancePercentVarianceColumnDetails_Column1.GetSelectedValue
                            _ColumnRow(ColumnFields.Column2Name.ToString) = ComboBoxVariancePercentVarianceColumnDetails_Column2.GetSelectedValue
                            _ColumnRow(ColumnFields.PctOfRowColumnName.ToString) = ComboBoxPercentOfRowColumnDetails_Column.GetSelectedValue
                            _ColumnRow(ColumnFields.OfficeCode.ToString) = If(ComboBoxDataColumnDetails_OfficeFilter.GetSelectedValue Is Nothing, System.DBNull.Value, ComboBoxDataColumnDetails_OfficeFilter.GetSelectedValue)
                            _ColumnRow(ColumnFields.OverrideRowDataOptionsAndCalculations.ToString) = CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.Checked

                            If RadioButtonDataCalculations_YearToDate.Checked Then

                                _ColumnRow(ColumnFields.DataCalculation.ToString) = CInt(DataCalculations.YearToDate)

                            ElseIf RadioButtonDataCalculations_SelectedPeriod.Checked Then

                                _ColumnRow(ColumnFields.DataCalculation.ToString) = CInt(DataCalculations.SelectedPeriod)

                            ElseIf RadioButtonDataCalculations_All.Checked Then

                                _ColumnRow(ColumnFields.DataCalculation.ToString) = CInt(DataCalculations.All)

                            End If

                            If RadioButtonDataOptions_EndingBalance.Checked Then

                                _ColumnRow(ColumnFields.DataOption.ToString) = CInt(DataOptions.EndingBalance)

                            ElseIf RadioButtonDataOptions_BeginningBalance.Checked Then

                                _ColumnRow(ColumnFields.DataOption.ToString) = CInt(DataOptions.BeginningBalance)

                            ElseIf RadioButtonDataOptions_PeriodChange.Checked Then

                                _ColumnRow(ColumnFields.DataOption.ToString) = CInt(DataOptions.PeriodChange)

                            End If

                            For Each PercentOfRowColumnDataRow In _PercentOfRowColumnDataTable.Select(PercentOfRowColumnFields.ColumnID.ToString & " = " & _ColumnRow(ColumnFields.ID.ToString))

                                _PercentOfRowColumnDataTable.Rows.Remove(PercentOfRowColumnDataRow)

                            Next

                            If _ColumnRow(ColumnFields.Type.ToString) = ColumnTypes.PercentOfRow Then

                                For Each DataRow In DataGridViewPercentOfRowColumnDetails_Rows.GetAllRowsDataBoundItems.OfType(Of System.Data.DataRowView).Select(Function(DRV) DRV.Row).ToList

                                    PercentOfRowColumnDataRow = _PercentOfRowColumnDataTable.NewRow()

                                    PercentOfRowColumnDataRow(PercentOfRowColumnFields.ColumnID.ToString) = _ColumnRow(ColumnFields.ID.ToString)
                                    PercentOfRowColumnDataRow(PercentOfRowColumnFields.ColumnName.ToString) = _ColumnRow(ColumnFields.Name.ToString)
                                    PercentOfRowColumnDataRow(PercentOfRowColumnFields.RowID.ToString) = DataRow(PercentOfRowColumnFields.RowID.ToString)
                                    PercentOfRowColumnDataRow(PercentOfRowColumnFields.RowIndex.ToString) = DataRow(PercentOfRowColumnFields.RowIndex.ToString)
                                    PercentOfRowColumnDataRow(PercentOfRowColumnFields.RowDescription.ToString) = DataRow(PercentOfRowColumnFields.RowDescription.ToString)

                                    Try

                                        RowDataRow = _RowsDataTable.Select(RowFields.ID.ToString & " = " & DataRow(PercentOfRowColumnFields.PercentOfRowID.ToString)).SingleOrDefault

                                    Catch ex As Exception
                                        RowDataRow = Nothing
                                    End Try

                                    If RowDataRow IsNot Nothing Then

                                        PercentOfRowColumnDataRow(PercentOfRowColumnFields.PercentOfRowID.ToString) = RowDataRow(RowFields.ID.ToString)
                                        PercentOfRowColumnDataRow(PercentOfRowColumnFields.PercentOfRowIndex.ToString) = RowDataRow(RowFields.RowIndex.ToString)
                                        PercentOfRowColumnDataRow(PercentOfRowColumnFields.PercentOfRowDescription.ToString) = RowDataRow(RowFields.Description.ToString)

                                    End If

                                    _PercentOfRowColumnDataTable.Rows.Add(PercentOfRowColumnDataRow)

                                Next

                            End If

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

                        AdvantageFramework.WinForm.MessageBox.Show("Please enter a different column name. This column name is reserved for internal use.")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please enter a unqiue column name.")

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

            If Me.FormShown Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonExpressionColumnDetails_Expression_Click(sender As Object, e As EventArgs) Handles ButtonExpressionColumnDetails_Expression.Click

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = BuildExpresionEditorDataTable(_ColumnsDataTable)

            If AdvantageFramework.WinForm.Presentation.ExpressionEditorDialog.ShowFormDialog(DataTable, TextBoxForm_Name.Text, TextBoxExpressionColumnDetails_Expression.Text) = Windows.Forms.DialogResult.OK Then

                If _ColumnRow IsNot Nothing Then

                    _ColumnRow.RowError = ""

                End If

            End If

        End Sub
        Private Sub CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.CheckedChanged

            EnableOrDisablePeriodChange()

        End Sub
        Private Sub RadioButtonDataOptions_PeriodChange_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonDataOptions_PeriodChange.CheckedChanged

            EnableOrDisablePeriodChange()

        End Sub
        Private Sub TextBoxForm_Name_FinalizeValidationEvent(ByRef IsValid As Boolean, ByRef ErrorText As String) Handles TextBoxForm_Name.FinalizeValidationEvent

            If IsValid = False Then

                ErrorText = "Please enter a valid name. Use only alpha numeric text."

            End If

        End Sub
        Private Sub ComboBoxDataColumnDetails_PeriodOption_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxDataColumnDetails_PeriodOption.SelectedValueChanged

            If ComboBoxDataColumnDetails_PeriodOption.HasASelectedValue AndAlso ComboBoxDataColumnDetails_PeriodOption.SelectedValue <> PeriodOptions.Month Then

                RadioButtonDataOptions_EndingBalance.Checked = True
                RadioButtonDataCalculations_SelectedPeriod.Checked = True

                CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.Checked = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
