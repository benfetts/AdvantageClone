Namespace ProjectManagement.Reports.Presentation

    Public Class EstimatePrintingSetupForm

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

            'objects
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                EstimateQuotes = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)(String.Format("EXEC [dbo].[advsp_estimate_printing_load] '{0}', '{1}', '{2}'", Me.Session.UserCode, DateTimePickerDates_From.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), DateTimePickerDates_To.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))).ToList

                DataGridViewForm_Estimates.CurrentView.BeginUpdate()

                DataGridViewForm_Estimates.DataSource = EstimateQuotes

                DataGridViewForm_Estimates.CurrentView.BestFitColumns()

                DataGridViewForm_Estimates.CurrentView.BeginSort()
                Try
                    DataGridViewForm_Estimates.CurrentView.ClearGrouping()
                    If ComboBoxSearch_GroupBy.SelectedValue = 3 Then
                        DataGridViewForm_Estimates.Columns("Campaign").GroupIndex = 0
                        DataGridViewForm_Estimates.Columns("Campaign").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                    ElseIf ComboBoxSearch_GroupBy.SelectedValue = 1 Then
                        DataGridViewForm_Estimates.Columns("JobComponent").GroupIndex = 0
                        DataGridViewForm_Estimates.Columns("JobComponent").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                    ElseIf ComboBoxSearch_GroupBy.SelectedValue = 2 Then
                        DataGridViewForm_Estimates.Columns("EstimateNumber").GroupIndex = 0
                        DataGridViewForm_Estimates.Columns("EstimateNumber").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                    End If
                Finally
                    DataGridViewForm_Estimates.CurrentView.EndSort()
                End Try

                RefreshColumnOrderAndVisibility()

                DataGridViewForm_Estimates.CurrentView.ExpandAllGroups()

                DataGridViewForm_Estimates.CurrentView.EndUpdate()

            End Using

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting AndAlso ButtonItemActions_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    DataGridViewForm_Estimates.CurrentView.CloseEditorForUpdating()

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.ShowWaitForm("Saving...")
                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                        Try

                            IsOkay = Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.CloseWaitForm()
                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save() As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing

            If DataGridViewForm_Estimates.HasRows Then

                Saved = True

                DataGridViewForm_Estimates.CurrentView.CloseEditorForUpdating()

                EstimateQuotes = DataGridViewForm_Estimates.GetAllModifiedRows.OfType(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each EstimateQuote In EstimateQuotes

                            AdvantageFramework.Estimate.Printing.SaveEstimate(DbContext, EstimateQuote)

                        Next

                    End Using

                Catch ex As Exception
                    Saved = False
                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                If Saved Then

                    Try

                        DataGridViewForm_Estimates.ValidateAllRowsAndClearChanged(True)

                    Catch ex As Exception

                    End Try

                End If

                Me.CloseWaitForm()

            End If

            Save = Saved

        End Function
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Print.Enabled = DataGridViewForm_Estimates.HasASelectedRow
            ButtonItemActions_PrintPreview.Enabled = DataGridViewForm_Estimates.HasASelectedRow
            ButtonItemPrintOptions_Setup.Enabled = DataGridViewForm_Estimates.HasASelectedRow
            ButtonItemComments_Job.Enabled = (DataGridViewForm_Estimates.HasASelectedRow)
            ButtonItemComments_Function.Enabled = (DataGridViewForm_Estimates.HasASelectedRow)
            ButtonItemEstimateFormatSettings_Client.Enabled = DataGridViewForm_Estimates.HasOnlyOneSelectedRow
            ButtonItemEstimateFormatSettings_Product.Enabled = DataGridViewForm_Estimates.HasOnlyOneSelectedRow

        End Sub
        Private Sub RefreshColumnOrderAndVisibility()

            'objects
            Dim ColumnVisibleIndex As Integer = Nothing

            ColumnVisibleIndex = 1

            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.JobNumber.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.JobDesc.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.JobComponentNumber.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.JobCompDesc.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.JobComponent.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.CampaignName.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.CampaignCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.Estimate.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstimateNumber.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstDesc.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstimateComponentNumber.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstCompDesc.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.QuoteNumber.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.QuoteDesc.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstimateDate.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.ClientCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.ClientName.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.DivisionCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.DivisionName.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.ProductCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.ProductName.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.OfficeCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.OfficeName.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstimateComment.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstimateComponentComment.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstimateQuoteComment.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstimateContactName.ToString, ColumnVisibleIndex)

            DataGridViewForm_Estimates.CurrentView.BestFitColumns()

        End Sub
        Private Sub HideOrShowColumn(ByVal FieldName As String, ByRef VisibleIndex As Integer)

            'objects
            Dim Visible As Boolean = False
            Dim ShowMarkupTaxFlagsBreakDownColumns As Boolean = Nothing

            If DataGridViewForm_Estimates.CurrentView.Columns(FieldName) IsNot Nothing Then

                Select Case FieldName

                    Case AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.ClientName.ToString,
                        AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.DivisionName.ToString,
                        AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.ProductName.ToString,
                        AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.OfficeName.ToString()

                        Visible = ButtonItem_ShowDescriptions.Checked

                        DataGridViewForm_Estimates.CurrentView.Columns(FieldName).OptionsColumn.TabStop = False

                    Case Estimate.Printing.Classes.EstimateQuote.Properties.Estimate.ToString,
                         Estimate.Printing.Classes.EstimateQuote.Properties.EstimateComment.ToString,
                         Estimate.Printing.Classes.EstimateQuote.Properties.EstimateComponentComment.ToString,
                         Estimate.Printing.Classes.EstimateQuote.Properties.EstimateDate.ToString,
                         Estimate.Printing.Classes.EstimateQuote.Properties.EstimateQuoteComment.ToString,
                         Estimate.Printing.Classes.EstimateQuote.Properties.ClientCode.ToString,
                         Estimate.Printing.Classes.EstimateQuote.Properties.DivisionCode.ToString,
                         Estimate.Printing.Classes.EstimateQuote.Properties.ProductCode.ToString,
                         Estimate.Printing.Classes.EstimateQuote.Properties.OfficeCode.ToString

                        Visible = True

                        If FieldName = Estimate.Printing.Classes.EstimateQuote.Properties.EstimateComment.ToString Or
                           FieldName = Estimate.Printing.Classes.EstimateQuote.Properties.EstimateComponentComment.ToString Or
                           FieldName = Estimate.Printing.Classes.EstimateQuote.Properties.EstimateQuoteComment.ToString Or
                           FieldName = Estimate.Printing.Classes.EstimateQuote.Properties.EstimateDate.ToString Then
                            DataGridViewForm_Estimates.CurrentView.Columns(FieldName).OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True
                        Else
                            DataGridViewForm_Estimates.CurrentView.Columns(FieldName).OptionsColumn.TabStop = False
                        End If

                    Case Estimate.Printing.Classes.EstimateQuote.Properties.JobNumber.ToString

                        If ComboBoxActions_SelectBy.SelectedValue = 1 Then
                            Visible = True
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 2 Then
                            Visible = False
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 3 Then
                            Visible = False
                        Else
                            Visible = True
                        End If

                        DataGridViewForm_Estimates.CurrentView.Columns(FieldName).OptionsColumn.TabStop = False

                    Case Estimate.Printing.Classes.EstimateQuote.Properties.JobComponentNumber.ToString

                        If ComboBoxActions_SelectBy.SelectedValue = 1 Then
                            Visible = True
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 2 Then
                            Visible = False
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 3 Then
                            Visible = False
                        Else
                            Visible = True
                        End If

                        DataGridViewForm_Estimates.CurrentView.Columns(FieldName).OptionsColumn.TabStop = False

                    Case Estimate.Printing.Classes.EstimateQuote.Properties.JobComponent.ToString

                        If ComboBoxActions_SelectBy.SelectedValue = 1 Then
                            Visible = True
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 2 Then
                            Visible = False
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 3 Then
                            Visible = False
                        Else
                            Visible = True
                        End If

                        DataGridViewForm_Estimates.CurrentView.Columns(FieldName).OptionsColumn.TabStop = False
                    Case Estimate.Printing.Classes.EstimateQuote.Properties.Estimate.ToString

                        If ComboBoxActions_SelectBy.SelectedValue = 1 Then
                            Visible = False
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 2 Then
                            Visible = True
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 3 Then
                            Visible = False
                        Else
                            Visible = True
                        End If

                        DataGridViewForm_Estimates.CurrentView.Columns(FieldName).OptionsColumn.TabStop = False
                    Case Estimate.Printing.Classes.EstimateQuote.Properties.EstimateNumber.ToString

                        If ComboBoxActions_SelectBy.SelectedValue = 1 Then
                            Visible = False
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 2 Then
                            Visible = True
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 3 Then
                            Visible = False
                        Else
                            Visible = True
                        End If

                        DataGridViewForm_Estimates.CurrentView.Columns(FieldName).OptionsColumn.TabStop = False
                    Case Estimate.Printing.Classes.EstimateQuote.Properties.EstimateComponentNumber.ToString

                        If ComboBoxActions_SelectBy.SelectedValue = 1 Then
                            Visible = False
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 2 Then
                            Visible = True
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 3 Then
                            Visible = False
                        Else
                            Visible = True
                        End If

                        DataGridViewForm_Estimates.CurrentView.Columns(FieldName).OptionsColumn.TabStop = False
                    Case Estimate.Printing.Classes.EstimateQuote.Properties.QuoteNumber.ToString

                        If ComboBoxActions_SelectBy.SelectedValue = 1 Then
                            Visible = False
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 2 Then
                            Visible = True
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 3 Then
                            Visible = False
                        Else
                            Visible = True
                        End If

                        DataGridViewForm_Estimates.CurrentView.Columns(FieldName).OptionsColumn.TabStop = False
                    Case Estimate.Printing.Classes.EstimateQuote.Properties.CampaignCode.ToString

                        If ComboBoxActions_SelectBy.SelectedValue = 1 Then
                            Visible = False
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 2 Then
                            Visible = False
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 3 Then
                            Visible = True
                        Else
                            Visible = True
                        End If

                        DataGridViewForm_Estimates.CurrentView.Columns(FieldName).OptionsColumn.TabStop = False
                    Case Estimate.Printing.Classes.EstimateQuote.Properties.CampaignName.ToString

                        If ComboBoxActions_SelectBy.SelectedValue = 1 Then
                            Visible = False
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 2 Then
                            Visible = False
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 3 Then
                            Visible = ButtonItem_ShowDescriptions.Checked
                        Else
                            Visible = ButtonItem_ShowDescriptions.Checked
                        End If

                        DataGridViewForm_Estimates.CurrentView.Columns(FieldName).OptionsColumn.TabStop = False

                    Case AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.JobDesc.ToString

                        If ComboBoxActions_SelectBy.SelectedValue = 1 Then
                            Visible = ButtonItem_ShowDescriptions.Checked
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 2 Then
                            Visible = False
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 3 Then
                            Visible = False
                        Else
                            Visible = ButtonItem_ShowDescriptions.Checked
                        End If

                        DataGridViewForm_Estimates.CurrentView.Columns(FieldName).OptionsColumn.TabStop = False
                    Case AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.JobCompDesc.ToString

                        If ComboBoxActions_SelectBy.SelectedValue = 1 Then
                            Visible = ButtonItem_ShowDescriptions.Checked
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 2 Then
                            Visible = False
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 3 Then
                            Visible = False
                        Else
                            Visible = ButtonItem_ShowDescriptions.Checked
                        End If

                        DataGridViewForm_Estimates.CurrentView.Columns(FieldName).OptionsColumn.TabStop = False
                    Case AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstCompDesc.ToString

                        If ComboBoxActions_SelectBy.SelectedValue = 1 Then
                            Visible = False
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 2 Then
                            Visible = ButtonItem_ShowDescriptions.Checked
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 3 Then
                            Visible = False
                        Else
                            Visible = ButtonItem_ShowDescriptions.Checked
                        End If

                        DataGridViewForm_Estimates.CurrentView.Columns(FieldName).OptionsColumn.TabStop = False
                    Case AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstDesc.ToString

                        If ComboBoxActions_SelectBy.SelectedValue = 1 Then
                            Visible = False
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 2 Then
                            Visible = ButtonItem_ShowDescriptions.Checked
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 3 Then
                            Visible = False
                        Else
                            Visible = ButtonItem_ShowDescriptions.Checked
                        End If

                        DataGridViewForm_Estimates.CurrentView.Columns(FieldName).OptionsColumn.TabStop = False
                    Case AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.QuoteDesc.ToString

                        If ComboBoxActions_SelectBy.SelectedValue = 1 Then
                            Visible = False
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 2 Then
                            Visible = ButtonItem_ShowDescriptions.Checked
                        ElseIf ComboBoxActions_SelectBy.SelectedValue = 3 Then
                            Visible = False
                        Else
                            Visible = ButtonItem_ShowDescriptions.Checked
                        End If

                        DataGridViewForm_Estimates.CurrentView.Columns(FieldName).OptionsColumn.TabStop = False

                    Case AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstimateContactName.ToString

                        Visible = True

                        DataGridViewForm_Estimates.CurrentView.Columns(FieldName).OptionsColumn.TabStop = False

                    Case Else

                        Visible = False

                End Select

                DataGridViewForm_Estimates.CurrentView.Columns(FieldName).Visible = Visible

                If DataGridViewForm_Estimates.CurrentView.Columns(FieldName).Visible Then

                    DataGridViewForm_Estimates.CurrentView.Columns(FieldName).VisibleIndex = VisibleIndex

                    VisibleIndex = VisibleIndex + 1

                End If

            End If

        End Sub
        Private Sub LoadData()
            Try
                ComboBoxFormatType_FormatType.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Estimate.Printing.EstimateFormatTypes))

                ComboBoxActions_SelectBy.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Estimate.Printing.SelectByOptions))
                ComboBoxSearch_GroupBy.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Estimate.Printing.GroupByOptions))
                ComboBoxActions_SelectBy.SelectedIndex = 1

                Try

                    DataGridViewForm_Estimates.DataSource = New Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)

                Catch ex As Exception

                End Try

                'Try
                '    ComboBox_CustomFormats.Items.Clear()
                '    For Each KeyValuePair In AdvantageFramework.Reporting.LoadAvailableEstimateReports(Me.Session).ToList.Select(Function(Entity) New AdvantageFramework.Database.Classes.UDReport(Entity)).OrderBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.DatasetType).ToList
                '        ComboBox_CustomFormats.Items.Add(KeyValuePair)
                '    Next

                '    ComboBox_CustomFormats.Items.Insert(0, "[Please select]")
                '    ComboBox_CustomFormats.SelectedIndex = 0
                '    'ComboBox_CustomFormats.DataSource = AdvantageFramework.Reporting.LoadAvailableUserDefinedReports(Me.Session).ToList.Where(Function(Entity) Entity.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.OneQuotePerPage).Select(Function(Entity) New AdvantageFramework.Database.Classes.UDReport(Entity)).OrderBy(Function(Entity) Entity.ReportCategory).ThenBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.DatasetType).ToList

                'Catch ex As Exception

                'End Try

                DataGridViewForm_Estimates.CurrentView.BestFitColumns()

            Catch ex As Exception

            End Try
        End Sub
        Private Sub PrintToFile(ByVal ToSingleFile As Boolean, ByVal ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions)

            'objects
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing
            Dim EstimateFormatType As AdvantageFramework.Estimate.Printing.EstimateFormatTypes = Estimate.Printing.EstimateFormatTypes.Agency

            If CheckForUnsavedChanges() Then

                If ComboBoxFormatType_FormatType.HasASelectedValue Then

                    If DataGridViewForm_Estimates.HasASelectedRow Then

                        EstimateFormatType = ComboBoxFormatType_FormatType.GetSelectedValue

                        EstimateQuotes = DataGridViewForm_Estimates.GetAllSelectedRowsDataBoundItems.OfType(Of Estimate.Printing.Classes.EstimateQuote)().ToList

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Printing

                        Try

                            AdvantageFramework.ProjectManagement.Reports.Presentation.PrintToFile(Nothing, Me.Session, EstimateQuotes, EstimateFormatType, ToSingleFile, ToFileOption)

                        Catch ex As Exception

                        End Try

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please select an invoice.")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a format type.")

                End If

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim EstimatePrintingSetupForm As EstimatePrintingSetupForm = Nothing

            EstimatePrintingSetupForm = New EstimatePrintingSetupForm()

            EstimatePrintingSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub EstimatePrintingSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.InvoicePrintImage
            ButtonItemActions_PrintPreview.Image = AdvantageFramework.My.Resources.PrintPreviewImage
            ButtonItem_ShowDescriptions.Image = AdvantageFramework.My.Resources.ShowOnlyColumnDescriptionsImage

            'ButtonItemSearch_Production.Image = AdvantageFramework.My.Resources.ProductionImage
            ButtonItemSearch_Search.Image = AdvantageFramework.My.Resources.DashboardAndQueryImage
            ButtonItemAction_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemPrintOptions_Setup.Image = AdvantageFramework.My.Resources.InvoicePropertiesImage
            ButtonItemPrintOptions_Setup.Visible = False

            ButtonItemComments_Job.Icon = AdvantageFramework.My.Resources.InvoicePropertiesIcon
            ButtonItemComments_Function.Icon = AdvantageFramework.My.Resources.InvoicePropertiesIcon

            ButtonItemEstimateFormatSettings_Client.Image = AdvantageFramework.My.Resources.ClientImage
            ButtonItemEstimateFormatSettings_Product.Image = AdvantageFramework.My.Resources.ProductImage
            ButtonItemEstimateFormatSettings_User.Image = AdvantageFramework.My.Resources.UserImage
            ButtonItemEstimateFormatSettings_Agency.Image = AdvantageFramework.My.Resources.AgencyImage
            ButtonItemEstimateFormatSettings_OneTime.Image = AdvantageFramework.My.Resources.InvoicePropertiesImage

            ButtonItemEstimateFormatSettings_CustomizeTemplates.Image = AdvantageFramework.My.Resources.AdvantageReportsImage

            DateTimePickerDates_To.ByPassUserEntryChanged = True
            DateTimePickerDates_From.ByPassUserEntryChanged = True

            DateTimePickerDates_From.ValueObject = Nothing
            DateTimePickerDates_To.ValueObject = Nothing

            Me.DateTimePickerDates_From.Value = Now
            Me.DateTimePickerDates_To.Value = Now

            ComboBoxActions_SelectBy.ByPassUserEntryChanged = True
            ComboBoxSearch_GroupBy.ByPassUserEntryChanged = True

            DateTimePickerOverrides_EstimateDate.ByPassUserEntryChanged = True
            DateTimePickerOverrides_EstimateDate.ValueObject = Nothing

            Me.DateTimePickerOverrides_EstimateDate.Value = Now

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            LoadData()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub EstimatePrintingSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = False

        End Sub
        Private Sub EstimatePrintingSetupForm_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub EstimatePrintingSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            EnableOrDisableActions()

            If Debugger.IsAttached Then

                DateTimePickerDates_From.Value = Now
                DateTimePickerDates_To.Value = Now

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm("Loading...")

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

                'DataGridViewForm_Invoices.CurrentView.AFActiveFilterString = "[RecordType] = 'I'"

                DataGridViewForm_Estimates.SelectAll()

                'ButtonItemActions_Print.RaiseClick(DevComponents.DotNetBar.eEventSource.Code)

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            Else

                Me.DateTimePickerDates_From.Value = Now
                Me.DateTimePickerDates_To.Value = Now

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Save()
            LoadGrid()

        End Sub
        Private Sub ButtonItemActions_PrintPreview_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_PrintPreview.Click

            'objects
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing
            Dim EstimateFormat As AdvantageFramework.Estimate.Printing.ReportFormats = AdvantageFramework.Estimate.Printing.ReportFormats.OneQuotePerPage
            Dim EstimateFormatType As AdvantageFramework.Estimate.Printing.EstimateFormatTypes = Estimate.Printing.EstimateFormatTypes.Agency
            Dim UserDefinedReport As AdvantageFramework.Database.Classes.UDReport = Nothing
            Dim UserDefinedReportID As Integer = 0
            Dim EstimatePrintingSettings As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting) = Nothing
            Dim EstimateSettings As Generic.List(Of AdvantageFramework.Database.Entities.EstimatePrintSetting) = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim datetoprint As DateTime = Nothing

            If CheckForUnsavedChanges() Then

                If ComboBoxFormatType_FormatType.HasASelectedValue Then

                    If DataGridViewForm_Estimates.HasASelectedRow Then

                        EstimateFormatType = ComboBoxFormatType_FormatType.GetSelectedValue

                        EstimateQuotes = DataGridViewForm_Estimates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)().ToList

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)
                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, DataContext, EstimateFormatType).ToList

                            End Using
                        End Using

                        EstimateViewingForm2.ShowFormDialog(Me.Session, EstimateFormatType, EstimateQuotes, EstimatePrintingSettings, EstimatePrintingSetting, 0, EstimateFormat, datetoprint)

                        EstimateQuotes = DataGridViewForm_Estimates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)().ToList

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please select an estimate quote.")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a format type.")

                End If

            End If

        End Sub
        Private Sub ButtonItemPrint_SendEmails_Click(sender As Object, e As EventArgs) Handles ButtonItemPrint_SendEmails.Click

            'objects
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing
            Dim EstimateFormat As AdvantageFramework.Estimate.Printing.ReportFormats = AdvantageFramework.Estimate.Printing.ReportFormats.OneQuotePerPage
            Dim EstimateFormatType As AdvantageFramework.Estimate.Printing.EstimateFormatTypes = Estimate.Printing.EstimateFormatTypes.Agency
            Dim EstimatePrintingSettings As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting) = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim ToRecipients As Generic.List(Of AdvantageFramework.Email.Classes.RecipientEmailAddress) = Nothing
            Dim CcRecipients As Generic.List(Of AdvantageFramework.Email.Classes.RecipientEmailAddress) = Nothing
            Dim BccRecipients As Generic.List(Of AdvantageFramework.Email.Classes.RecipientEmailAddress) = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.EmailSent
            Dim EmailSettings As AdvantageFramework.Estimate.Printing.Classes.EmailSettings = Nothing
            Dim ErrorMessage As String = ""
            Dim [To] As String = Nothing
            Dim [Cc] As String = Nothing
            Dim [Bcc] As String = Nothing
            Dim Subject As String = ""
            Dim Body As String = ""
            Dim EmailSent As Boolean = False
            Dim AgencyImportPath As String = Nothing
            Dim ReportExportPath As String = Nothing
            Dim DefaultFileName As String = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim IsAgencyASP As Boolean = False
            Dim Files As Generic.List(Of String) = Nothing
            Dim ClCodeString As String = ""

            If CheckForUnsavedChanges() Then

                If ComboBoxFormatType_FormatType.HasASelectedValue Then

                    If DataGridViewForm_Estimates.HasASelectedRow Then

                        EstimateFormatType = ComboBoxFormatType_FormatType.GetSelectedValue

                        EstimateQuotes = DataGridViewForm_Estimates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)().ToList

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)
                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, DataContext, EstimateFormatType).ToList

                            End Using
                        End Using

                        If AdvantageFramework.ProjectManagement.Reports.Presentation.EstimatePrintingSendEmailsDialog.ShowFormDialog(EmailSettings) = Windows.Forms.DialogResult.OK Then

                            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Printing
                            Me.ShowWaitForm("Printing...")

                            If EmailSettings.ToRecipients IsNot Nothing AndAlso EmailSettings.ToRecipients.Count > 0 Then

                                [To] = Join(EmailSettings.ToRecipients.Select(Function(Entity) Entity.EmailAddress).ToArray, "; ")

                            End If

                            If EmailSettings.CCRecipients IsNot Nothing AndAlso EmailSettings.CCRecipients.Count > 0 Then

                                [Cc] = Join(EmailSettings.CCRecipients.Select(Function(Entity) Entity.EmailAddress).ToArray, "; ")

                            End If

                            If EmailSettings.BCCRecipients IsNot Nothing AndAlso EmailSettings.BCCRecipients.Count > 0 Then

                                [Bcc] = Join(EmailSettings.BCCRecipients.Select(Function(Entity) Entity.EmailAddress).ToArray, "; ")

                            End If

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                                    AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                                    AgencyImportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\")

                                    If My.Computer.FileSystem.DirectoryExists(AgencyImportPath & "Reports\") = False Then

                                        My.Computer.FileSystem.CreateDirectory(AgencyImportPath & "Reports\")
                                        AgencyImportPath = AgencyImportPath & "Reports\"

                                    End If

                                Else

                                    Try

                                        ReportExportPath = AdvantageFramework.Agency.LoadMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.AccessTmpPath)

                                    Catch ex As Exception
                                        ReportExportPath = ""
                                    End Try

                                    If String.IsNullOrWhiteSpace(ReportExportPath) Then

                                        ReportExportPath = AdvantageFramework.Database.Procedures.Agency.LoadReportTempPath(DbContext)

                                    End If

                                    If My.Computer.FileSystem.DirectoryExists(ReportExportPath) Then

                                        AgencyImportPath = ReportExportPath

                                    End If

                                End If

                                If My.Computer.FileSystem.DirectoryExists(AgencyImportPath) Then

                                    If My.Computer.FileSystem.DirectoryExists(AgencyImportPath & "Reports\") = False Then

                                        My.Computer.FileSystem.CreateDirectory(AgencyImportPath & "Reports\")

                                    End If

                                    AgencyImportPath = AgencyImportPath & "Reports\"

                                    Files = New Generic.List(Of String)

                                    Dim quotes As String = ""
                                    Dim qtedesc As String = ""
                                    Dim qtedescs As String = ""
                                    Dim comps As String = ""
                                    Dim qte As Integer = 0
                                    Dim comp As Integer = 0
                                    Dim count As Integer = 0
                                    Dim est As Integer = 0
                                    Dim estcomp As String = ""
                                    Dim datetoprint As DateTime = Nothing

                                    Dim estCount As Integer = 0

                                    For Each EstimateQuote In EstimateQuotes
                                        If ComboBoxFormatType_FormatType.GetSelectedValue = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuote.CDP AndAlso Entity.Type = 3)
                                            If EstimatePrintingSetting Is Nothing Then
                                                EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode AndAlso Entity.Type = 2)
                                            End If
                                            If EstimatePrintingSetting Is Nothing Then
                                                EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode)
                                            End If
                                        ElseIf ComboBoxFormatType_FormatType.GetSelectedValue = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                        Else
                                            EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                        End If

                                        If EstimatePrintingSetting IsNot Nothing Then
                                            If EstimatePrintingSetting.SummaryLevel = 2 Then
                                                If (est <> 0 And est <> EstimateQuote.EstimateNumber) Then
                                                    If ComboBoxFormatType_FormatType.GetSelectedValue = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuotes(estCount - 1).CDP AndAlso Entity.Type = 3)
                                                        If EstimatePrintingSetting Is Nothing Then
                                                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode AndAlso Entity.Type = 2)
                                                        End If
                                                        If EstimatePrintingSetting Is Nothing Then
                                                            EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode)
                                                        End If
                                                    ElseIf ComboBoxFormatType_FormatType.GetSelectedValue = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                                    Else
                                                        EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                                    End If

                                                    If count > 4 And EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                                        AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                                        Exit Sub
                                                    End If

                                                    Report = AdvantageFramework.Reporting.Reports.CreateEstimate(Me.Session, EstimateQuotes(estCount - 1), EstimatePrintingSetting, EstimatePrintingSetting.ReportFormat, comps, quotes, qtedescs, EstimatePrintingSetting.SummaryLevel, datetoprint)

                                                    If Report IsNot Nothing Then

                                                        If EstimateQuote.ClientCode <> "" Then
                                                            ClCodeString = "_" & EstimateQuote.ClientCode
                                                        End If

                                                        If EstimateQuote.JobNumber <> 0 Then
                                                            DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(est, "000000#")
                                                        Else
                                                            DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(est, "000000#")
                                                        End If

                                                        Report.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = DefaultFileName
                                                        Report.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = AgencyImportPath
                                                        Report.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                                                        Report.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                                                        Report.ExportToPdf(AgencyImportPath & DefaultFileName & ".pdf")
                                                        Files.Add(AgencyImportPath & DefaultFileName & ".pdf")

                                                    End If

                                                    comps = ""
                                                    quotes = ""
                                                    qtedescs = ""
                                                    count = 0
                                                End If
                                            Else
                                                If (estcomp <> "" And estcomp <> EstimateQuote.EstimateNumber & "-" & EstimateQuote.EstimateComponentNumber) Then
                                                    If ComboBoxFormatType_FormatType.GetSelectedValue = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuotes(estCount - 1).CDP AndAlso Entity.Type = 3)
                                                        If EstimatePrintingSetting Is Nothing Then
                                                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode AndAlso Entity.Type = 2)
                                                        End If
                                                        If EstimatePrintingSetting Is Nothing Then
                                                            EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode)
                                                        End If
                                                    ElseIf ComboBoxFormatType_FormatType.GetSelectedValue = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                                    Else
                                                        EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                                    End If

                                                    If count > 4 And EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                                        AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                                        Exit Sub
                                                    End If

                                                    Report = AdvantageFramework.Reporting.Reports.CreateEstimate(Me.Session, EstimateQuotes(estCount - 1), EstimatePrintingSetting, EstimatePrintingSetting.ReportFormat, comps, quotes, qtedescs, EstimatePrintingSetting.SummaryLevel, datetoprint)

                                                    If Report IsNot Nothing Then

                                                        If EstimateQuote.ClientCode <> "" Then
                                                            ClCodeString = "_" & EstimateQuote.ClientCode
                                                        End If

                                                        If EstimateQuote.JobNumber = 0 Then
                                                            DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                                        Else
                                                            DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                                        End If

                                                        Report.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = DefaultFileName
                                                        Report.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = AgencyImportPath
                                                        Report.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                                                        Report.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                                                        Report.ExportToPdf(AgencyImportPath & DefaultFileName & ".pdf")
                                                        Files.Add(AgencyImportPath & DefaultFileName & ".pdf")

                                                    End If

                                                    comps = ""
                                                    quotes = ""
                                                    qtedescs = ""
                                                    count = 0
                                                End If
                                            End If

                                            Try
                                                est = EstimateQuote.EstimateNumber
                                                comp = EstimateQuote.EstimateComponentNumber
                                                estcomp = EstimateQuote.EstimateNumber & "-" & EstimateQuote.EstimateComponentNumber
                                                qte = EstimateQuote.QuoteNumber
                                                If EstimateQuote.QuoteDesc IsNot Nothing Then
                                                    qtedesc = EstimateQuote.QuoteDesc.Replace("&nbsp;", "").Replace(",", "_")
                                                End If
                                            Catch ex As Exception
                                                qte = 0
                                                qtedesc = ""
                                            End Try
                                            quotes &= qte & ","
                                            qtedescs &= qtedesc & ","
                                            comps &= comp & ","
                                            count += 1
                                            estCount += 1

                                            If estCount = EstimateQuotes.Count Then

                                                If ComboBoxFormatType_FormatType.GetSelectedValue = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                                    EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuote.CDP AndAlso Entity.Type = 3)
                                                    If EstimatePrintingSetting Is Nothing Then
                                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode AndAlso Entity.Type = 2)
                                                    End If
                                                    If EstimatePrintingSetting Is Nothing Then
                                                        EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode)
                                                    End If
                                                ElseIf ComboBoxFormatType_FormatType.GetSelectedValue = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                                    EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                                Else
                                                    EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                                End If

                                                If count > 4 And EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                                    AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                                    Exit Sub
                                                End If

                                                Report = AdvantageFramework.Reporting.Reports.CreateEstimate(Me.Session, EstimateQuote, EstimatePrintingSetting, EstimatePrintingSetting.ReportFormat, comps, quotes, qtedescs, EstimatePrintingSetting.SummaryLevel, datetoprint)

                                                If Report IsNot Nothing Then

                                                    If EstimateQuote.ClientCode <> "" Then
                                                        ClCodeString = "_" & EstimateQuote.ClientCode
                                                    End If

                                                    If EstimateQuote.JobNumber <> 0 Then
                                                        'DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                                        If EstimatePrintingSetting.SummaryLevel = 2 Then
                                                            DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#")
                                                        Else
                                                            DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#")
                                                        End If
                                                    Else
                                                        'DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                                        If EstimatePrintingSetting.SummaryLevel = 2 Then
                                                            DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#")
                                                        Else
                                                            DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#")
                                                        End If
                                                    End If

                                                    Report.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = DefaultFileName
                                                    Report.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = AgencyImportPath
                                                    Report.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                                                    Report.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                                                    Report.ExportToPdf(AgencyImportPath & DefaultFileName & ".pdf")
                                                    Files.Add(AgencyImportPath & DefaultFileName & ".pdf")

                                                End If
                                            End If
                                        Else
                                            EstimatePrintingSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting()

                                            Report = AdvantageFramework.Reporting.Reports.CreateEstimate(Me.Session, EstimateQuote, EstimatePrintingSetting, EstimatePrintingSetting.ReportFormat)

                                            If Report IsNot Nothing Then

                                                If EstimateQuote.ClientCode <> "" Then
                                                    ClCodeString = "_" & EstimateQuote.ClientCode
                                                End If

                                                If EstimateQuote.JobNumber = 0 Then
                                                    DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#") & "_" & Format(EstimateQuote.QuoteNumber, "00#")
                                                Else
                                                    DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#") & "_" & Format(EstimateQuote.QuoteNumber, "00#")
                                                End If

                                                Report.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = DefaultFileName
                                                Report.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = AgencyImportPath
                                                Report.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                                                Report.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                                                Report.ExportToPdf(AgencyImportPath & DefaultFileName & ".pdf")
                                                Files.Add(AgencyImportPath & DefaultFileName & ".pdf")

                                            End If
                                        End If

                                    Next

                                    Me.ShowWaitForm("Sending...")

                                    EmailSent = AdvantageFramework.Email.Send(DbContext, [To], [Cc], [Bcc], EmailSettings.Subject, EmailSettings.Body, 3, Files.ToArray, SendingEmailStatus, ErrorMessage, False)

                                    For Each File In Files

                                        If My.Computer.FileSystem.FileExists(File) Then

                                            My.Computer.FileSystem.DeleteFile(File)

                                        End If

                                    Next

                                End If

                            End Using

                            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                            Me.CloseWaitForm()

                            If EmailSent Then

                                AdvantageFramework.WinForm.MessageBox.Show("Estimates have been printed and sent.")

                            Else

                                If SendingEmailStatus <> AdvantageFramework.Email.SendingEmailStatus.EmailSent Then

                                    AdvantageFramework.WinForm.MessageBox.Show(AdvantageFramework.Email.LoadEmailErrorMessage(SendingEmailStatus))

                                ElseIf String.IsNullOrEmpty(ErrorMessage) = False Then

                                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                                Else

                                    AdvantageFramework.WinForm.MessageBox.Show("Failed creating or sending Estimate Report.  Please contact software support.")

                                End If

                            End If

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please select an estimate.")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a format type.")

                End If

            End If

        End Sub
        Private Sub ButtonItemPrint_ToFiles_Click(sender As Object, e As EventArgs) Handles ButtonItemPrint_ToFiles.Click

            'objects
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing
            Dim EstimateFormat As AdvantageFramework.Estimate.Printing.ReportFormats = AdvantageFramework.Estimate.Printing.ReportFormats.OneQuotePerPage
            Dim EstimateFormatType As AdvantageFramework.Estimate.Printing.EstimateFormatTypes = Estimate.Printing.EstimateFormatTypes.Agency
            Dim EstimatePrintingSettings As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting) = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim AgencyImportPath As String = Nothing
            Dim DefaultFileName As String = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim IsAgencyASP As Boolean = False
            Dim ExportPath As String = Nothing

            If CheckForUnsavedChanges() Then

                If ComboBoxFormatType_FormatType.HasASelectedValue Then

                    If DataGridViewForm_Estimates.HasASelectedRow Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                            AgencyImportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\")

                            IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                        End Using

                        If IsAgencyASP Then

                            If My.Computer.FileSystem.DirectoryExists(AgencyImportPath) Then

                                If My.Computer.FileSystem.DirectoryExists(AgencyImportPath & "Reports\") = False Then

                                    My.Computer.FileSystem.CreateDirectory(AgencyImportPath & "Reports\")

                                End If

                                ExportPath = AgencyImportPath & "Reports\"

                            End If

                        Else

                            AdvantageFramework.WinForm.Presentation.BrowseForFolder(ExportPath)

                        End If

                        If My.Computer.FileSystem.DirectoryExists(ExportPath) Then

                            ExportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(ExportPath.Trim, "\")

                            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Printing
                            Me.ShowWaitForm("Printing...")

                            EstimateFormatType = ComboBoxFormatType_FormatType.GetSelectedValue

                            EstimateQuotes = DataGridViewForm_Estimates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)().ToList

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)
                                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                    EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, DataContext, EstimateFormatType).ToList

                                End Using
                            End Using

                            Dim quotes As String = ""
                            Dim qtedesc As String = ""
                            Dim qtedescs As String = ""
                            Dim comps As String = ""
                            Dim qte As Integer = 0
                            Dim comp As Integer = 0
                            Dim count As Integer = 0
                            Dim est As Integer = 0
                            Dim estcomp As String = ""
                            Dim datetoprint As DateTime = Nothing
                            Dim ClCodeString As String = ""

                            Dim estCount As Integer = 0

                            For Each EstimateQuote In EstimateQuotes

                                If ComboBoxFormatType_FormatType.GetSelectedValue = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                    EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuote.CDP AndAlso Entity.Type = 3)
                                    If EstimatePrintingSetting Is Nothing Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode AndAlso Entity.Type = 2)
                                    End If
                                    If EstimatePrintingSetting Is Nothing Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode)
                                    End If
                                ElseIf ComboBoxFormatType_FormatType.GetSelectedValue = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                    EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                Else
                                    EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                End If

                                If EstimatePrintingSetting IsNot Nothing Then
                                    If EstimatePrintingSetting.SummaryLevel = 2 Then
                                        If (est <> 0 And est <> EstimateQuote.EstimateNumber) Then
                                            If ComboBoxFormatType_FormatType.GetSelectedValue = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                                EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuotes(estCount - 1).CDP AndAlso Entity.Type = 3)
                                                If EstimatePrintingSetting Is Nothing Then
                                                    EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode AndAlso Entity.Type = 2)
                                                End If
                                                If EstimatePrintingSetting Is Nothing Then
                                                    EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode)
                                                End If
                                            ElseIf ComboBoxFormatType_FormatType.GetSelectedValue = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                                EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                            Else
                                                EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                            End If

                                            If count > 4 And EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                                AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                                Exit Sub
                                            End If

                                            Report = AdvantageFramework.Reporting.Reports.CreateEstimate(Me.Session, EstimateQuotes(estCount - 1), EstimatePrintingSetting, EstimatePrintingSetting.ReportFormat, comps, quotes, qtedescs, EstimatePrintingSetting.SummaryLevel, datetoprint)

                                            If Report IsNot Nothing Then

                                                If EstimateQuote.ClientCode <> "" Then
                                                    ClCodeString = "_" & EstimateQuote.ClientCode
                                                End If

                                                If EstimateQuote.JobNumber <> 0 Then
                                                    DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(est, "000000#")
                                                Else
                                                    DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(est, "000000#")
                                                End If

                                                Report.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = DefaultFileName
                                                Report.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = ExportPath
                                                Report.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                                                Report.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                                                Report.ExportToPdf(ExportPath & DefaultFileName & ".pdf")

                                            End If

                                            comps = ""
                                            quotes = ""
                                            qtedescs = ""
                                            count = 0
                                        End If
                                    Else
                                        If (estcomp <> "" And estcomp <> EstimateQuote.EstimateNumber & "-" & EstimateQuote.EstimateComponentNumber) Then
                                            If ComboBoxFormatType_FormatType.GetSelectedValue = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                                EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuotes(estCount - 1).CDP AndAlso Entity.Type = 3)
                                                If EstimatePrintingSetting Is Nothing Then
                                                    EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode AndAlso Entity.Type = 2)
                                                End If
                                                If EstimatePrintingSetting Is Nothing Then
                                                    EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode)
                                                End If
                                            ElseIf ComboBoxFormatType_FormatType.GetSelectedValue = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                                EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                            Else
                                                EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                            End If

                                            If count > 4 And EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                                AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                                Exit Sub
                                            End If

                                            Report = AdvantageFramework.Reporting.Reports.CreateEstimate(Me.Session, EstimateQuotes(estCount - 1), EstimatePrintingSetting, EstimatePrintingSetting.ReportFormat, comps, quotes, qtedescs, EstimatePrintingSetting.SummaryLevel, datetoprint)

                                            If Report IsNot Nothing Then

                                                If EstimateQuote.ClientCode <> "" Then
                                                    ClCodeString = "_" & EstimateQuote.ClientCode
                                                End If

                                                If EstimateQuote.JobNumber = 0 Then
                                                    DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                                Else
                                                    DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                                End If

                                                'DefaultFileName = "ESTIMATE" & Format(est, "000000#") & "_" & Format(comp, "00#")

                                                Report.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = DefaultFileName
                                                Report.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = ExportPath
                                                Report.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                                                Report.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                                                Report.ExportToPdf(ExportPath & DefaultFileName & ".pdf")

                                            End If

                                            comps = ""
                                            quotes = ""
                                            qtedescs = ""
                                            count = 0
                                        End If
                                    End If

                                    Try
                                        est = EstimateQuote.EstimateNumber
                                        comp = EstimateQuote.EstimateComponentNumber
                                        estcomp = EstimateQuote.EstimateNumber & "-" & EstimateQuote.EstimateComponentNumber
                                        qte = EstimateQuote.QuoteNumber
                                        If EstimateQuote.QuoteDesc IsNot Nothing Then
                                            qtedesc = EstimateQuote.QuoteDesc.Replace("&nbsp;", "").Replace(",", "_")
                                        End If
                                    Catch ex As Exception
                                        qte = 0
                                        qtedesc = ""
                                    End Try
                                    quotes &= qte & ","
                                    qtedescs &= qtedesc & ","
                                    comps &= comp & ","
                                    count += 1
                                    estCount += 1

                                    If estCount = EstimateQuotes.Count Then

                                        If ComboBoxFormatType_FormatType.GetSelectedValue = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuote.CDP AndAlso Entity.Type = 3)
                                            If EstimatePrintingSetting Is Nothing Then
                                                EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode AndAlso Entity.Type = 2)
                                            End If
                                            If EstimatePrintingSetting Is Nothing Then
                                                EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode)
                                            End If
                                        ElseIf ComboBoxFormatType_FormatType.GetSelectedValue = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                        Else
                                            EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                        End If

                                        If count > 4 And EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                            AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                            Exit Sub
                                        End If

                                        Report = AdvantageFramework.Reporting.Reports.CreateEstimate(Me.Session, EstimateQuote, EstimatePrintingSetting, EstimatePrintingSetting.ReportFormat, comps, quotes, qtedescs, EstimatePrintingSetting.SummaryLevel, datetoprint)

                                        If Report IsNot Nothing Then

                                            If EstimateQuote.ClientCode <> "" Then
                                                ClCodeString = "_" & EstimateQuote.ClientCode
                                            End If

                                            If EstimateQuote.JobNumber <> 0 Then
                                                'DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                                If EstimatePrintingSetting.SummaryLevel = 2 Then
                                                    DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#")
                                                Else
                                                    DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#")
                                                End If
                                            Else
                                                'DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                                If EstimatePrintingSetting.SummaryLevel = 2 Then
                                                    DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#")
                                                Else
                                                    DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#")
                                                End If
                                            End If

                                            Report.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = DefaultFileName
                                            Report.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = ExportPath
                                            Report.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                                            Report.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                                            Report.ExportToPdf(ExportPath & DefaultFileName & ".pdf")

                                        End If
                                    End If
                                Else

                                    EstimatePrintingSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting()

                                    Report = AdvantageFramework.Reporting.Reports.CreateEstimate(Me.Session, EstimateQuote, EstimatePrintingSetting, EstimatePrintingSetting.ReportFormat)

                                    If Report IsNot Nothing Then

                                        If EstimateQuote.ClientCode <> "" Then
                                            ClCodeString = "_" & EstimateQuote.ClientCode
                                        End If

                                        If EstimateQuote.JobNumber = 0 Then
                                            DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#") & "_" & Format(EstimateQuote.QuoteNumber, "00#")
                                        Else
                                            DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#") & "_" & Format(EstimateQuote.QuoteNumber, "00#")
                                        End If

                                        'DefaultFileName = Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#") & "_" & Format(EstimateQuote.QuoteNumber, "00#")

                                        Report.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = DefaultFileName
                                        Report.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = ExportPath
                                        Report.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                                        Report.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                                        Report.ExportToPdf(ExportPath & DefaultFileName & ".pdf")

                                    End If
                                End If

                            Next

                            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                            Me.CloseWaitForm()

                            AdvantageFramework.WinForm.MessageBox.Show("Estimates have been printed.")

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please select an estimate.")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a format type.")

                End If

            End If

        End Sub
        Private Sub ButtonItemDates_YTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDates_YTD.Click

			DateTimePickerDates_From.Value = New Date(Now.Year, 1, 1)
			DateTimePickerDates_To.Value = Now

        End Sub
        Private Sub ButtonItemDates_MTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDates_MTD.Click

			DateTimePickerDates_From.Value = New Date(Now.Year, Now.Month, 1)
			DateTimePickerDates_To.Value = Now

        End Sub
        Private Sub ButtonItemDates_1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDates_1Year.Click

            DateTimePickerDates_From.Value = Now.AddYears(-1)
            DateTimePickerDates_To.Value = Now

        End Sub
        Private Sub ButtonItemDates_2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDates_2Years.Click

            DateTimePickerDates_From.Value = Now.AddYears(-2)
            DateTimePickerDates_To.Value = Now

        End Sub
        Private Sub ButtonItemSearch_Search_Click(sender As Object, e As EventArgs) Handles ButtonItemSearch_Search.Click

            'objects
            Dim Search As Boolean = True

            If CheckForUnsavedChanges() Then

                If DateTimePickerDates_From.Value = Nothing Then

                    AdvantageFramework.WinForm.MessageBox.Show("Please select valid start date")
                    Search = False

                ElseIf DateTimePickerDates_To.Value = Nothing Then

                    AdvantageFramework.WinForm.MessageBox.Show("Please select valid end date")
                    Search = False

                ElseIf DateTimePickerDates_To.Value < DateTimePickerDates_From.Value Then

                    AdvantageFramework.WinForm.MessageBox.Show("End date is less than start date")
                    Search = False

                End If

                If Search Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading
                    Me.ShowWaitForm("Loading...")

                    Try

                        LoadGrid()

                        EnableOrDisableActions()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                End If

            End If

        End Sub

        Private Sub DataGridViewForm_Estimates_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Estimates.CellValueChangingEvent

            If e.Column.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstimateDate.ToString Then

                'Saved = True

            End If

        End Sub
        Private Sub DataGridViewForm_Estimates_GridViewMouseDownEvent(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridViewForm_Estimates.GridViewMouseDownEvent

            'objects
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing

            If e.Button = Windows.Forms.MouseButtons.Right AndAlso DataGridViewForm_Estimates.HasMultipleSelectedRows Then

                Try

                    GridHitInfo = DataGridViewForm_Estimates.CurrentView.CalcHitInfo(e.Location)

                Catch ex As Exception
                    GridHitInfo = Nothing
                End Try

                If GridHitInfo IsNot Nothing Then

                    If GridHitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then

                        'ButtonItemCM_Invoices.Popup(System.Windows.Forms.Form.MousePosition)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Estimates_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_Estimates.QueryPopupNeedDatasourceEvent

            'objects
            Dim EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote = Nothing

            If FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstimateContact.ToString Then

                Try

                    EstimateQuote = DataGridViewForm_Estimates.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    EstimateQuote = Nothing
                End Try

                If EstimateQuote IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Datasource = AdvantageFramework.Database.Procedures.ClientContact.LoadAllActiveByClientCode(DbContext, EstimateQuote.ClientCode).ToList

                    End Using

                End If

                OverrideDefaultDatasource = True

            End If

        End Sub
        Private Sub DataGridViewForm_Estimates_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Estimates.SelectionChangedEvent

            Dim rowhandle As Integer = DataGridViewForm_Estimates.CurrentView.FocusedRowHandle
            Dim rowid As Integer = 0
            If DataGridViewForm_Estimates.CurrentView.IsGroupRow(rowhandle) Then
                DataGridViewForm_Estimates.CurrentView.BeginSelection()
                rowid = DataGridViewForm_Estimates.CurrentView.GetChildRowCount(rowhandle) - 1
                DataGridViewForm_Estimates.CurrentView.SelectRows(DataGridViewForm_Estimates.CurrentView.GetChildRowHandle(rowhandle, 0), DataGridViewForm_Estimates.CurrentView.GetChildRowHandle(rowhandle, rowid))
                DataGridViewForm_Estimates.CurrentView.EndSelection()
            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ComboBoxFormatType_FormatType_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxFormatType_FormatType.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If ComboBoxFormatType_FormatType.HasASelectedValue Then



                End If

            End If

        End Sub
        'Private Sub ButtonItemPrintOptions_Setup_Click(sender As Object, e As EventArgs) Handles ButtonItemPrintOptions_Setup.Click

        '    'objects
        '    Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing
        '    Dim EstimateFormat As AdvantageFramework.Estimate.Printing.ReportFormats = AdvantageFramework.Estimate.Printing.ReportFormats.OneQuotePerPage
        '    Dim EstimateType As AdvantageFramework.Estimate.Printing.EstimateFormatTypes = Estimate.Printing.EstimateFormatTypes.ClientDefault
        '    Dim EstimatePrintingSettings As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
        '    Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
        '    Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
        '    Dim ShowEstimateOptions As Boolean = True
        '    Dim ClientCodes As Generic.List(Of String) = Nothing
        '    Dim DivisionCodes As Generic.List(Of String) = Nothing
        '    Dim ProductCodes As Generic.List(Of String) = Nothing


        '    If ComboBoxFormatType_FormatType.HasASelectedValue Then

        '        EstimateType = ComboBoxFormatType_FormatType.GetSelectedValue

        '        'If EstimateFormat = AdvantageFramework.Estimate.Printing.ReportFormats.OneQuotePerPage Then

        '        If DataGridViewForm_Estimates.HasASelectedRow Then

        '            Try

        '                EstimateQuotes = DataGridViewForm_Estimates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)().ToList

        '            Catch ex As Exception
        '                EstimateQuotes = Nothing
        '            End Try

        '            If EstimateQuotes IsNot Nothing AndAlso EstimateQuotes.Count > 0 Then

        '                Try

        '                    ClientCodes = DataGridViewForm_Estimates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)().ToList.Select(Function(ARI) ARI.ClientCode).Distinct.ToList
        '                    ProductCodes = DataGridViewForm_Estimates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)().ToList.Select(Function(ARI) ARI.CDP).Distinct.ToList

        '                Catch ex As Exception

        '                End Try

        '                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)
        '                        'EstimatePrintingSettings = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadByEstimatePrintSettingUserID(DataContext, Me.Session.UserCode)

        '                        If ClientCodes IsNot Nothing AndAlso ClientCodes.Count = 1 AndAlso EstimateType <> Estimate.Printing.EstimateFormatTypes.ProductDefault AndAlso EstimateType <> Estimate.Printing.EstimateFormatTypes.UserDefault Then

        '                            If EstimateType = AdvantageFramework.Estimate.Printing.EstimateFormatTypes.Standard Then

        '                                EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, True, EstimateType).FirstOrDefault(Function(Entity) Entity.ClientCode = ClientCodes(0))

        '                            ElseIf EstimateType = AdvantageFramework.Estimate.Printing.EstimateFormatTypes.ClientDefault Then

        '                                EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, False, EstimateType).FirstOrDefault(Function(Entity) Entity.ClientCode = ClientCodes(0))

        '                            End If

        '                            'ElseIf ProductCodes IsNot Nothing AndAlso ProductCodes.Count = 1 AndAlso EstimateType = Estimate.Printing.EstimateFormatTypes.ProductDefault Then

        '                            '    If EstimateType = AdvantageFramework.Estimate.Printing.EstimateFormatTypes.Standard Then

        '                            '        EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, True, EstimateType).FirstOrDefault(Function(Entity) Entity.CDP = ProductCodes(0))

        '                            '    ElseIf EstimateType = AdvantageFramework.Estimate.Printing.EstimateFormatTypes.ClientDefault Then

        '                            '        EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, False, EstimateType).FirstOrDefault(Function(Entity) Entity.CDP = ProductCodes(0))

        '                            '    ElseIf EstimateType = AdvantageFramework.Estimate.Printing.EstimateFormatTypes.ProductDefault Then

        '                            '        EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, False, EstimateType).FirstOrDefault(Function(Entity) Entity.CDP = ProductCodes(0))

        '                            '    End If

        '                        Else

        '                            If EstimateType = AdvantageFramework.Estimate.Printing.EstimateFormatTypes.Standard Then

        '                                EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, True, EstimateType).FirstOrDefault(Function(Entity) Entity.Type = 1)

        '                            ElseIf EstimateType = AdvantageFramework.Estimate.Printing.EstimateFormatTypes.ClientDefault Then

        '                                EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, False, EstimateType).FirstOrDefault(Function(Entity) Entity.Type = 1)

        '                            ElseIf EstimateType = AdvantageFramework.Estimate.Printing.EstimateFormatTypes.ProductDefault Then

        '                                EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, False, EstimateType).FirstOrDefault(Function(Entity) Entity.Type = 1)

        '                            ElseIf EstimateType = AdvantageFramework.Estimate.Printing.EstimateFormatTypes.UserDefault Then

        '                                EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, False, EstimateType).FirstOrDefault(Function(Entity) Entity.Type = 1)

        '                            End If

        '                        End If


        '                    End Using

        '                    'EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettingsWV(DbContext, False, Me.Session.UserCode).First

        '                End Using

        '                EstimatePrintingOptionsDialog.ShowFormDialog(EstimateType, EstimatePrintingSetting, ClientCodes, ProductCodes, ShowEstimateOptions)

        '            End If

        '        Else

        '            AdvantageFramework.WinForm.MessageBox.Show("Please select an estimate before modifying printing options.")

        '        End If

        '        'End If

        '    Else

        '        AdvantageFramework.WinForm.MessageBox.Show("Please select a format type.")

        '    End If

        'End Sub
        Private Sub ButtonItemComments_Job_Click(sender As Object, e As EventArgs) Handles ButtonItemComments_Job.Click

            'objects
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing

            If DataGridViewForm_Estimates.HasASelectedRow Then

                Try

                    EstimateQuotes = DataGridViewForm_Estimates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)().ToList

                Catch ex As Exception
                    EstimateQuotes = Nothing
                End Try

                If EstimateQuotes IsNot Nothing AndAlso EstimateQuotes.Count > 0 Then

                    EstimatePrintingCommentsDialog.ShowFormDialog(EstimatePrintingCommentsDialog.Type.EstimateComment, EstimateQuotes)

                End If

            End If

        End Sub
        Private Sub ButtonItemComments_Function_Click(sender As Object, e As EventArgs) Handles ButtonItemComments_Function.Click

            'objects
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing

            If DataGridViewForm_Estimates.HasASelectedRow Then

                Try

                    EstimateQuotes = DataGridViewForm_Estimates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)().ToList

                Catch ex As Exception
                    EstimateQuotes = Nothing
                End Try

                If EstimateQuotes IsNot Nothing AndAlso EstimateQuotes.Count > 0 Then

                    EstimatePrintingCommentsDialog.ShowFormDialog(EstimatePrintingCommentsDialog.Type.EstimateFunctionComment, EstimateQuotes)

                End If

            End If

        End Sub

        Private Sub ButtonItem_ShowDescriptions_Click(sender As Object, e As EventArgs) Handles ButtonItem_ShowDescriptions.Click
            Try

                RefreshColumnOrderAndVisibility()

            Catch
            End Try

        End Sub
        Private Sub ComboBoxSearch_GroupBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxSearch_GroupBy.SelectedIndexChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                Try
                    LoadGrid()

                    RefreshColumnOrderAndVisibility()
                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub ComboBoxActions_SelectBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxActions_SelectBy.SelectedIndexChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub ButtonItemAction_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemAction_Refresh.Click
            Try
                LoadData()
                LoadGrid()
            Catch ex As Exception

            End Try
        End Sub
        Private Sub ButtonItemOverrides_EstimateDate_Click(sender As Object, e As EventArgs) Handles ButtonItemOverrides_EstimateDate.Click

            If DataGridViewForm_Estimates.HasASelectedRow AndAlso DateTimePickerOverrides_EstimateDate.Value <> Nothing Then

                For Each KeyValuePair In DataGridViewForm_Estimates.GetAllSelectedRowsRowHandlesAndDataBoundItems

                    CType(KeyValuePair.Value, AdvantageFramework.Estimate.Printing.Classes.EstimateQuote).EstimateDate = DateTimePickerOverrides_EstimateDate.Value

                    DataGridViewForm_Estimates.AddToModifiedRows(KeyValuePair.Key)

                Next

                DataGridViewForm_Estimates.CurrentView.RefreshData()

                DataGridViewForm_Estimates.SetUserEntryChanged()

                Me.RaiseUserEntryChangedEvent(DataGridViewForm_Estimates)

            End If

        End Sub

        Private Sub ButtonItemEstimateFormatSettings_Client_Click(sender As Object, e As EventArgs) Handles ButtonItemEstimateFormatSettings_Client.Click

            'objects
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing
            Dim EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote = Nothing
            Dim EstimatePrintingSettings As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim ShowEstimateOptions As Boolean = True
            Dim ClientCodes As Generic.List(Of String) = Nothing
            Dim DivisionCodes As Generic.List(Of String) = Nothing
            Dim ProductCodes As Generic.List(Of String) = Nothing

            If DataGridViewForm_Estimates.HasOnlyOneSelectedRow Then

                Try

                    EstimateQuote = DataGridViewForm_Estimates.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    EstimateQuote = Nothing
                End Try

                If EstimateQuote IsNot Nothing Then

                    ClientCodes = New Generic.List(Of String)

                    ClientCodes.Add(EstimateQuote.ClientCode)

                    ProductCodes = New Generic.List(Of String)

                    ProductCodes.Add(EstimateQuote.CDP)

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, DataContext, Estimate.Printing.EstimateFormatTypes.ClientDefault, EstimateQuote.ClientCode).FirstOrDefault()

                        End Using

                    End Using

                    EstimatePrintingOptionsDialog.ShowFormDialog(Estimate.Printing.EstimateFormatTypes.ClientDefault, EstimatePrintingSetting, ClientCodes, ProductCodes, True, "Client")

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an estimate before modifying printing options.")

            End If

        End Sub
        Private Sub ButtonItemEstimateFormatSettings_Product_Click(sender As Object, e As EventArgs) Handles ButtonItemEstimateFormatSettings_Product.Click
            'objects
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing
            Dim EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote = Nothing
            Dim EstimatePrintingSettings As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim ShowEstimateOptions As Boolean = True
            Dim ClientCodes As Generic.List(Of String) = Nothing
            Dim DivisionCodes As Generic.List(Of String) = Nothing
            Dim ProductCodes As Generic.List(Of String) = Nothing

            If DataGridViewForm_Estimates.HasOnlyOneSelectedRow Then

                Try

                    EstimateQuote = DataGridViewForm_Estimates.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    EstimateQuote = Nothing
                End Try

                If EstimateQuote IsNot Nothing Then

                    ClientCodes = New Generic.List(Of String)

                    ClientCodes.Add(EstimateQuote.ClientCode)

                    ProductCodes = New Generic.List(Of String)

                    ProductCodes.Add(EstimateQuote.CDP)

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, DataContext, Estimate.Printing.EstimateFormatTypes.ClientDefault, EstimateQuote.ClientCode, EstimateQuote.CDP).FirstOrDefault()

                        End Using

                    End Using

                    EstimatePrintingOptionsDialog.ShowFormDialog(Estimate.Printing.EstimateFormatTypes.ClientDefault, EstimatePrintingSetting, ClientCodes, ProductCodes, True, "Product")

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an estimate before modifying printing options.")

            End If
        End Sub
        Private Sub ButtonItemEstimateFormatSettings_User_Click(sender As Object, e As EventArgs) Handles ButtonItemEstimateFormatSettings_User.Click
            'objects
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing
            Dim EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote = Nothing
            Dim EstimatePrintingSettings As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim ShowEstimateOptions As Boolean = True
            Dim ClientCodes As Generic.List(Of String) = Nothing
            Dim DivisionCodes As Generic.List(Of String) = Nothing
            Dim ProductCodes As Generic.List(Of String) = Nothing

            Try

                EstimateQuotes = DataGridViewForm_Estimates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)().ToList

            Catch ex As Exception
                EstimateQuote = Nothing
            End Try

            If EstimateQuotes IsNot Nothing AndAlso EstimateQuotes.Count > 0 Then

                Try

                    ClientCodes = EstimateQuotes.Select(Function(ARI) ARI.ClientCode).Distinct.ToList

                    ProductCodes = EstimateQuotes.Select(Function(ARI) ARI.CDP).Distinct.ToList

                Catch ex As Exception

                End Try

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, DataContext, Estimate.Printing.EstimateFormatTypes.UserDefault, Nothing, Nothing, Session.UserCode).FirstOrDefault()

                End Using

            End Using

            EstimatePrintingOptionsDialog.ShowFormDialog(Estimate.Printing.EstimateFormatTypes.UserDefault, EstimatePrintingSetting, ClientCodes, ProductCodes, True, "")

        End Sub
        Private Sub ButtonItemEstimateFormatSettings_Agency_Click(sender As Object, e As EventArgs) Handles ButtonItemEstimateFormatSettings_Agency.Click
            'objects
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing
            Dim EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote = Nothing
            Dim EstimatePrintingSettings As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim ShowEstimateOptions As Boolean = True
            Dim ClientCodes As Generic.List(Of String) = Nothing
            Dim DivisionCodes As Generic.List(Of String) = Nothing
            Dim ProductCodes As Generic.List(Of String) = Nothing

            Try

                EstimateQuotes = DataGridViewForm_Estimates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)().ToList

            Catch ex As Exception
                EstimateQuotes = Nothing
            End Try

            If EstimateQuotes IsNot Nothing AndAlso EstimateQuotes.Count > 0 Then

                Try

                    ClientCodes = EstimateQuotes.Select(Function(ARI) ARI.ClientCode).Distinct.ToList

                    ProductCodes = EstimateQuotes.Select(Function(ARI) ARI.CDP).Distinct.ToList

                Catch ex As Exception

                End Try

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, DataContext, Estimate.Printing.EstimateFormatTypes.Agency).FirstOrDefault()

                End Using

            End Using

            EstimatePrintingOptionsDialog.ShowFormDialog(Estimate.Printing.EstimateFormatTypes.Agency, EstimatePrintingSetting, ClientCodes, ProductCodes, True, "")

        End Sub
        Private Sub ButtonItemEstimateFormatSettings_OneTime_Click(sender As Object, e As EventArgs) Handles ButtonItemEstimateFormatSettings_OneTime.Click
            'objects
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing
            Dim EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote = Nothing
            Dim EstimatePrintingSettings As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim ShowEstimateOptions As Boolean = True
            Dim ClientCodes As Generic.List(Of String) = Nothing
            Dim DivisionCodes As Generic.List(Of String) = Nothing
            Dim ProductCodes As Generic.List(Of String) = Nothing

            Try

                EstimateQuotes = DataGridViewForm_Estimates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)().ToList

            Catch ex As Exception
                EstimateQuotes = Nothing
            End Try

            If EstimateQuotes IsNot Nothing AndAlso EstimateQuotes.Count > 0 Then

                Try

                    ClientCodes = EstimateQuotes.Select(Function(ARI) ARI.ClientCode).Distinct.ToList

                    ProductCodes = EstimateQuotes.Select(Function(ARI) ARI.CDP).Distinct.ToList

                Catch ex As Exception

                End Try

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, DataContext, Estimate.Printing.EstimateFormatTypes.OneTime).FirstOrDefault()

                End Using

            End Using

            EstimatePrintingOptionsDialog.ShowFormDialog(Estimate.Printing.EstimateFormatTypes.OneTime, EstimatePrintingSetting, ClientCodes, ProductCodes, True, "")

        End Sub
        Private Sub ButtonItemEstimateFormatSettings_CustomizeTemplates_Click(sender As Object, e As EventArgs) Handles ButtonItemEstimateFormatSettings_CustomizeTemplates.Click
            Try
                Try

                    If CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).CheckFormOpenForm(GetType(AdvantageFramework.ProjectManagement.Reports.Presentation.CustomEstimateReportsForm)) = False Then
                        AdvantageFramework.ProjectManagement.Reports.Presentation.CustomEstimateReportsForm.ShowForm()
                    End If

                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
        End Sub

#End Region

#End Region




        
        
        
        
        
    End Class

End Namespace
