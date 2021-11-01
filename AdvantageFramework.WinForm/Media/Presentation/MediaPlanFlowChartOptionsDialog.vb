Namespace Media.Presentation

    Public Class MediaPlanFlowChartOptionsDialog

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

        Private _FlowChartMediaPlanOptions As AdvantageFramework.MediaPlanning.FlowChart.FlowChartMediaPlanOptions = Nothing
        Private _MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing
        Private _MediaPlanID As Integer = 0

#End Region

#Region " Properties "

        Private ReadOnly Property FlowChartMediaPlanOptions As AdvantageFramework.MediaPlanning.FlowChart.FlowChartMediaPlanOptions
            Get
                FlowChartMediaPlanOptions = _FlowChartMediaPlanOptions
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, FlowChartMediaPlanOptions As AdvantageFramework.MediaPlanning.FlowChart.FlowChartMediaPlanOptions)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _MediaPlan = MediaPlan
            _FlowChartMediaPlanOptions = FlowChartMediaPlanOptions

        End Sub
        Private Sub New(MediaPlanID As Integer, FlowChartMediaPlanOptions As AdvantageFramework.MediaPlanning.FlowChart.FlowChartMediaPlanOptions)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _MediaPlanID = MediaPlanID
            _FlowChartMediaPlanOptions = FlowChartMediaPlanOptions

        End Sub
        Private Sub LoadFormControls()

            DateTimePickerForm_StartDate.Value = _FlowChartMediaPlanOptions.StartDate
            DateTimePickerForm_EndDate.Value = _FlowChartMediaPlanOptions.EndDate

            SearchableComboBoxForm_Location.SelectedValue = _FlowChartMediaPlanOptions.LocationID

            ComboBoxForm_DateHeaderOption.SelectedValue = CInt(_FlowChartMediaPlanOptions.FlowChartDateHeaderOption).ToString
            ColorPickerForm_DateHeaderColor.SelectedColor = _FlowChartMediaPlanOptions.DateHeaderColor
            ComboBoxForm_DateOverrideOption.SelectedValue = CInt(_FlowChartMediaPlanOptions.FlowChartDateOverrideOption).ToString

            CheckBoxLevels_PrintYear.Checked = _FlowChartMediaPlanOptions.PrintYear
            CheckBoxLevels_PrintQuarter.Checked = _FlowChartMediaPlanOptions.PrintQuarter
            CheckBoxLevels_PrintMonth.Checked = _FlowChartMediaPlanOptions.PrintMonth
            CheckBoxLevels_PrintMonthName.Checked = _FlowChartMediaPlanOptions.PrintMonthName
            CheckBoxLevels_PrintWeek.Checked = _FlowChartMediaPlanOptions.PrintWeek
            ComboBoxLevels_WeekDisplayType.SelectedValue = CInt(_FlowChartMediaPlanOptions.FlowChartWeekDisplayType).ToString
            CheckBoxLevels_PrintDate.Checked = _FlowChartMediaPlanOptions.PrintDate
            CheckBoxLevels_PrintDay.Checked = _FlowChartMediaPlanOptions.PrintDay

            ColorPickerForm_FieldAreaColor.SelectedColor = _FlowChartMediaPlanOptions.FieldAreaColor

            CheckBoxEstimateColumnTotals_Show.Checked = _FlowChartMediaPlanOptions.PrintEstimateColumnTotals

            If _FlowChartMediaPlanOptions.EstimateColumnTotalsType = AdvantageFramework.MediaPlanning.FlowChart.EstimateColumnTotalsTypes.Default Then

                RadioButtonEstimateColumnTotals_Default.Checked = True
                RadioButtonEstimateColumnTotals_ByMonth.Checked = False
                RadioButtonEstimateColumnTotals_Both.Checked = False

            ElseIf _FlowChartMediaPlanOptions.EstimateColumnTotalsType = AdvantageFramework.MediaPlanning.FlowChart.EstimateColumnTotalsTypes.ByMonth Then

                RadioButtonEstimateColumnTotals_Default.Checked = False
                RadioButtonEstimateColumnTotals_ByMonth.Checked = True
                RadioButtonEstimateColumnTotals_Both.Checked = False

            ElseIf _FlowChartMediaPlanOptions.EstimateColumnTotalsType = AdvantageFramework.MediaPlanning.FlowChart.EstimateColumnTotalsTypes.Both Then

                RadioButtonEstimateColumnTotals_Default.Checked = False
                RadioButtonEstimateColumnTotals_ByMonth.Checked = False
                RadioButtonEstimateColumnTotals_Both.Checked = True

            End If

            ColorPickerEstimateColumnTotals_AreaColor.SelectedColor = _FlowChartMediaPlanOptions.EstimateColumnTotalsAreaColor

            CheckBoxGrandTotals_Show.Checked = _FlowChartMediaPlanOptions.PrintGrandTotals

            If _FlowChartMediaPlanOptions.GrandTotalsType = AdvantageFramework.MediaPlanning.FlowChart.GrandTotalsTypes.Default Then

                RadioButtonGrandTotals_Default.Checked = True
                RadioButtonGrandTotals_ByMonth.Checked = False
                RadioButtonGrandTotals_Both.Checked = False

            ElseIf _FlowChartMediaPlanOptions.GrandTotalsType = AdvantageFramework.MediaPlanning.FlowChart.GrandTotalsTypes.ByMonth Then

                RadioButtonGrandTotals_Default.Checked = False
                RadioButtonGrandTotals_ByMonth.Checked = True
                RadioButtonGrandTotals_Both.Checked = False

            ElseIf _FlowChartMediaPlanOptions.GrandTotalsType = AdvantageFramework.MediaPlanning.FlowChart.GrandTotalsTypes.Both Then

                RadioButtonGrandTotals_Default.Checked = False
                RadioButtonGrandTotals_ByMonth.Checked = False
                RadioButtonGrandTotals_Both.Checked = True

            End If

            ColorPickerGrandTotals_AreaColor.SelectedColor = _FlowChartMediaPlanOptions.GrandTotalsAreaColor

            ComboBoxForm_GrandTotalDisplayValue.SelectedValue = CInt(_FlowChartMediaPlanOptions.GrandTotalsDisplayValue).ToString

            ComboBoxForm_SummaryOption.SelectedValue = CInt(_FlowChartMediaPlanOptions.FlowChartSummaryOption).ToString

            ComboBoxForm_FooterImages.SelectedValue = CInt(_FlowChartMediaPlanOptions.ImageID.GetValueOrDefault(0))

            CheckBoxForm_RoundToNearestDollar.Checked = _FlowChartMediaPlanOptions.RoundToNearestDollar

        End Sub
        Private Sub SaveFormControls()

            _FlowChartMediaPlanOptions.StartDate = DateTimePickerForm_StartDate.Value
            _FlowChartMediaPlanOptions.EndDate = DateTimePickerForm_EndDate.Value

            _FlowChartMediaPlanOptions.LocationID = SearchableComboBoxForm_Location.GetSelectedValue

            _FlowChartMediaPlanOptions.FlowChartDateHeaderOption = ComboBoxForm_DateHeaderOption.GetSelectedValue
            _FlowChartMediaPlanOptions.DateHeaderColor = ColorPickerForm_DateHeaderColor.SelectedColor
            _FlowChartMediaPlanOptions.FlowChartDateOverrideOption = ComboBoxForm_DateOverrideOption.GetSelectedValue

            _FlowChartMediaPlanOptions.PrintYear = CheckBoxLevels_PrintYear.Checked
            _FlowChartMediaPlanOptions.PrintQuarter = CheckBoxLevels_PrintQuarter.Checked
            _FlowChartMediaPlanOptions.PrintMonth = CheckBoxLevels_PrintMonth.Checked
            _FlowChartMediaPlanOptions.PrintMonthName = CheckBoxLevels_PrintMonthName.Checked
            _FlowChartMediaPlanOptions.PrintWeek = CheckBoxLevels_PrintWeek.Checked
            _FlowChartMediaPlanOptions.FlowChartWeekDisplayType = ComboBoxLevels_WeekDisplayType.GetSelectedValue
            _FlowChartMediaPlanOptions.PrintDate = CheckBoxLevels_PrintDate.Checked
            _FlowChartMediaPlanOptions.PrintDay = CheckBoxLevels_PrintDay.Checked

            _FlowChartMediaPlanOptions.FieldAreaColor = ColorPickerForm_FieldAreaColor.SelectedColor


            _FlowChartMediaPlanOptions.PrintEstimateColumnTotals = CheckBoxEstimateColumnTotals_Show.Checked

            If RadioButtonEstimateColumnTotals_Default.Checked Then

                _FlowChartMediaPlanOptions.EstimateColumnTotalsType = AdvantageFramework.MediaPlanning.FlowChart.EstimateColumnTotalsTypes.Default

            ElseIf RadioButtonEstimateColumnTotals_ByMonth.Checked Then

                _FlowChartMediaPlanOptions.EstimateColumnTotalsType = AdvantageFramework.MediaPlanning.FlowChart.EstimateColumnTotalsTypes.ByMonth

            ElseIf RadioButtonEstimateColumnTotals_Both.Checked Then

                _FlowChartMediaPlanOptions.EstimateColumnTotalsType = AdvantageFramework.MediaPlanning.FlowChart.EstimateColumnTotalsTypes.Both

            End If

            _FlowChartMediaPlanOptions.EstimateColumnTotalsAreaColor = ColorPickerEstimateColumnTotals_AreaColor.SelectedColor

            _FlowChartMediaPlanOptions.PrintGrandTotals = CheckBoxGrandTotals_Show.Checked

            If RadioButtonGrandTotals_Default.Checked Then

                _FlowChartMediaPlanOptions.GrandTotalsType = AdvantageFramework.MediaPlanning.FlowChart.GrandTotalsTypes.Default

            ElseIf RadioButtonGrandTotals_ByMonth.Checked Then

                _FlowChartMediaPlanOptions.GrandTotalsType = AdvantageFramework.MediaPlanning.FlowChart.GrandTotalsTypes.ByMonth

            ElseIf RadioButtonGrandTotals_Both.Checked Then

                _FlowChartMediaPlanOptions.GrandTotalsType = AdvantageFramework.MediaPlanning.FlowChart.GrandTotalsTypes.Both

            End If

            _FlowChartMediaPlanOptions.GrandTotalsAreaColor = ColorPickerGrandTotals_AreaColor.SelectedColor

            _FlowChartMediaPlanOptions.GrandTotalsDisplayValue = ComboBoxForm_GrandTotalDisplayValue.GetSelectedValue

            _FlowChartMediaPlanOptions.FlowChartSummaryOption = ComboBoxForm_SummaryOption.GetSelectedValue

            _FlowChartMediaPlanOptions.ImageID = ComboBoxForm_FooterImages.GetSelectedValue

            _FlowChartMediaPlanOptions.RoundToNearestDollar = CheckBoxForm_RoundToNearestDollar.Checked

        End Sub
        Private Sub EnableOrDisableActions()

            GroupBoxForm_Levels.Enabled = (ComboBoxForm_DateHeaderOption.GetSelectedValue = AdvantageFramework.MediaPlanning.FlowChart.FlowChartDateHeaderOptions.ChooseLevels)
            ComboBoxLevels_WeekDisplayType.Enabled = ((ComboBoxForm_DateHeaderOption.GetSelectedValue = AdvantageFramework.MediaPlanning.FlowChart.FlowChartDateHeaderOptions.ChooseLevels) AndAlso CheckBoxLevels_PrintWeek.Checked)

        End Sub
        Private Sub LoadImages()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_FooterImages.DataSource = AdvantageFramework.Database.Procedures.Image.Load(DbContext).ToList

            End Using

        End Sub
        Private Function ValidateForm() As Boolean

            'objects
            Dim IsValid As Boolean = False
            Dim ErrorMessage As String = String.Empty

            If Me.Validator Then

                If DateTimePickerForm_StartDate.Value > DateTimePickerForm_EndDate.Value Then

                    ErrorMessage = "Please select a start date on or before the end date."

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    IsValid = True

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            ValidateForm = IsValid

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaPlanID As Integer, ByRef FlowChartMediaPlanOptions As AdvantageFramework.MediaPlanning.FlowChart.FlowChartMediaPlanOptions) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanFlowChartOptionsDialog As AdvantageFramework.Media.Presentation.MediaPlanFlowChartOptionsDialog = Nothing

            MediaPlanFlowChartOptionsDialog = New AdvantageFramework.Media.Presentation.MediaPlanFlowChartOptionsDialog(MediaPlanID, FlowChartMediaPlanOptions)

            ShowFormDialog = MediaPlanFlowChartOptionsDialog.ShowDialog()

            If ShowFormDialog = System.Windows.Forms.DialogResult.OK Then

                FlowChartMediaPlanOptions = MediaPlanFlowChartOptionsDialog.FlowChartMediaPlanOptions

            End If

        End Function
        Public Shared Function ShowFormDialog(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, ByRef FlowChartMediaPlanOptions As AdvantageFramework.MediaPlanning.FlowChart.FlowChartMediaPlanOptions) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanFlowChartOptionsDialog As AdvantageFramework.Media.Presentation.MediaPlanFlowChartOptionsDialog = Nothing

            MediaPlanFlowChartOptionsDialog = New AdvantageFramework.Media.Presentation.MediaPlanFlowChartOptionsDialog(MediaPlan, FlowChartMediaPlanOptions)

            ShowFormDialog = MediaPlanFlowChartOptionsDialog.ShowDialog()

            If ShowFormDialog = System.Windows.Forms.DialogResult.OK Then

                FlowChartMediaPlanOptions = MediaPlanFlowChartOptionsDialog.FlowChartMediaPlanOptions

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanFlowChartOptionsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim DataTable As System.Data.DataTable = Nothing

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            If _MediaPlan Is Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    _MediaPlan = New MediaPlanning.Classes.MediaPlan(Me.Session.ConnectionString, Me.Session.UserCode, _MediaPlanID)

                End Using

            End If

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_DateHeaderOption.SetPropertySettings("Date Header Option", GetType(Integer), True)
                ComboBoxLevels_WeekDisplayType.SetPropertySettings("_Week Display Type", GetType(Integer), True)
                ComboBoxForm_DateOverrideOption.SetPropertySettings("Date Override Option", GetType(Integer), True)
                ComboBoxForm_GrandTotalDisplayValue.SetPropertySettings("Grand Total Display Value", GetType(Integer), True)
                ComboBoxForm_SummaryOption.SetPropertySettings("Summary Option", GetType(String), True)

                DataTable = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.MediaPlanning.FlowChart.DataColumns), GetType(Integer))
                AdvantageFramework.Data.RemoveRowsByValue(DataTable, "Code", CInt(AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Rate))

                SearchableComboBoxForm_Location.DataSource = AdvantageFramework.Database.Procedures.Location.Load(DataContext).ToList
                ComboBoxForm_DateHeaderOption.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.MediaPlanning.FlowChart.FlowChartDateHeaderOptions), False)
                ComboBoxLevels_WeekDisplayType.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.MediaPlanning.FlowChart.FlowChartWeekDisplayTypes), False)
                ComboBoxForm_DateOverrideOption.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.MediaPlanning.FlowChart.FlowChartDateOverrideOptions), False)
                ComboBoxForm_GrandTotalDisplayValue.DataSource = DataTable
                ComboBoxForm_GrandTotalDisplayValue.DisplayMember = "Description"
                ComboBoxForm_GrandTotalDisplayValue.ValueMember = "Code"
                ComboBoxForm_SummaryOption.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.MediaPlanning.FlowChart.FlowChartSummaryOptions))

                DateTimePickerForm_StartDate.MinDate = _MediaPlan.StartDate
                DateTimePickerForm_StartDate.MaxDate = _MediaPlan.EndDate

                DateTimePickerForm_EndDate.MinDate = _MediaPlan.StartDate
                DateTimePickerForm_EndDate.MaxDate = _MediaPlan.EndDate

                DataGridViewForm_EstimateOptions.DataSource = _FlowChartMediaPlanOptions.FlowChartMediaPlanEstimateOptions
                '===============
                '
                '===============

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.Nothing
                SubItemGridLookUpEditControl.EnumType = GetType(AdvantageFramework.MediaPlanning.FlowChart.DataColumns)
                SubItemGridLookUpEditControl.ValueType = GetType(Integer)
                SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable
                SubItemGridLookUpEditControl.Session = Me.Session

                SubItemGridLookUpEditControl.DataSource = DataTable

                DataGridViewForm_EstimateOptions.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                DataGridViewForm_EstimateOptions.Columns(AdvantageFramework.MediaPlanning.FlowChart.FlowChartMediaPlanEstimateOptions.Properties.DisplayValue.ToString).ColumnEdit = SubItemGridLookUpEditControl
                '===============
                '
                '===============

                DataTable = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.MediaPlanning.FlowChart.GroupByLevels), GetType(Integer))

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.Nothing
                SubItemGridLookUpEditControl.EnumType = GetType(AdvantageFramework.MediaPlanning.FlowChart.GroupByLevels)
                SubItemGridLookUpEditControl.ValueType = GetType(Integer)
                SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable
                SubItemGridLookUpEditControl.Session = Me.Session

                SubItemGridLookUpEditControl.DataSource = DataTable

                DataGridViewForm_EstimateOptions.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                DataGridViewForm_EstimateOptions.Columns(AdvantageFramework.MediaPlanning.FlowChart.FlowChartMediaPlanEstimateOptions.Properties.GroupByLevel.ToString).ColumnEdit = SubItemGridLookUpEditControl

                LoadImages()

            End Using

            DataGridViewForm_EstimateOptions.MakeColumnNotVisible(AdvantageFramework.MediaPlanning.FlowChart.FlowChartMediaPlanEstimateOptions.Properties.MediaPlanDetailID.ToString)
            DataGridViewForm_EstimateOptions.MakeColumnNotVisible(AdvantageFramework.MediaPlanning.FlowChart.FlowChartMediaPlanEstimateOptions.Properties.FlowChartMediaPlanOptions.ToString)

            DataGridViewForm_EstimateOptions.CurrentView.BestFitColumns()

            LoadFormControls()

            CheckBoxEstimateColumnTotals_Show.Checked = Not CheckBoxEstimateColumnTotals_Show.Checked
            CheckBoxEstimateColumnTotals_Show.Checked = Not CheckBoxEstimateColumnTotals_Show.Checked

            CheckBoxGrandTotals_Show.Checked = Not CheckBoxGrandTotals_Show.Checked
            CheckBoxGrandTotals_Show.Checked = Not CheckBoxGrandTotals_Show.Checked

            EnableOrDisableActions()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Print_Click(sender As Object, e As EventArgs) Handles ButtonForm_Print.Click

            'objects
            Dim ErrorMessage As String = String.Empty
            Dim FlowChart As AdvantageFramework.MediaPlanning.FlowChart.FlowChart = Nothing
            Dim FlowChartBuilder As AdvantageFramework.MediaPlanning.FlowChart.FlowChartBuilder = Nothing
            Dim FileName As String = String.Empty
            Dim FileNameCounter As Integer = 0
            Dim FileNameTemplate As String = String.Empty
            Dim Folder As String = String.Empty
            Dim MediaPlanFlowChartOptions As AdvantageFramework.Database.Entities.MediaPlanFlowChartOptions = Nothing
            Dim IsASP As Boolean = False
            Dim SaveFlowChartToDisk As Boolean = False

            If ValidateForm() Then

                SaveFormControls()

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    MediaPlanFlowChartOptions = AdvantageFramework.Database.Procedures.MediaPlanFlowChartOptions.LoadByUserCode(DbContext, Me.Session.UserCode)

                    If MediaPlanFlowChartOptions Is Nothing Then

                        MediaPlanFlowChartOptions = New AdvantageFramework.Database.Entities.MediaPlanFlowChartOptions

                        MediaPlanFlowChartOptions.DbContext = DbContext
                        MediaPlanFlowChartOptions.UserCode = Me.Session.UserCode

                        _FlowChartMediaPlanOptions.Save(MediaPlanFlowChartOptions)

                        AdvantageFramework.Database.Procedures.MediaPlanFlowChartOptions.Insert(DbContext, MediaPlanFlowChartOptions)

                    Else

                        _FlowChartMediaPlanOptions.Save(MediaPlanFlowChartOptions)

                        AdvantageFramework.Database.Procedures.MediaPlanFlowChartOptions.Update(DbContext, MediaPlanFlowChartOptions)

                    End If

                    IsASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                    If IsASP Then

                        Folder = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                    End If

                End Using

                If IsASP Then

                    Folder = Folder.Trim

                    If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder.Trim, "\")) Then

                        Folder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder.Trim, "\") & "Reports\"

                        If My.Computer.FileSystem.DirectoryExists(Folder) = False Then

                            My.Computer.FileSystem.CreateDirectory(Folder)

                        End If

                        SaveFlowChartToDisk = My.Computer.FileSystem.DirectoryExists(Folder)

                    End If

                Else

                    SaveFlowChartToDisk = AdvantageFramework.WinForm.Presentation.BrowseForFolder(Folder)

                End If

                If SaveFlowChartToDisk Then

                    FlowChart = New AdvantageFramework.MediaPlanning.FlowChart.FlowChart(Me.Session, _FlowChartMediaPlanOptions, _MediaPlan)

                    If FlowChart.FlowChartMediaPlanOptions.FlowChartMediaPlanEstimateOptions IsNot Nothing AndAlso
                            FlowChart.FlowChartMediaPlanOptions.FlowChartMediaPlanEstimateOptions.Any(Function(Entity) Entity.Print = True) Then

                        FlowChartBuilder = New AdvantageFramework.MediaPlanning.FlowChart.FlowChartBuilder()
                        FlowChartBuilder.Construct(FlowChart)

                        Folder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder, "\")

                        FileName = Folder & AdvantageFramework.FileSystem.CreateValidFileName(_MediaPlan.Description) & ".xlsx"
                        FileNameTemplate = Folder & AdvantageFramework.FileSystem.CreateValidFileName(_MediaPlan.Description) & " {0}.xlsx"

                        If My.Computer.FileSystem.FileExists(FileName) Then

                            FileNameCounter = 0

                            Do

                                FileName = String.Format(FileNameTemplate, FileNameCounter)

                                FileNameCounter += 1

                            Loop Until My.Computer.FileSystem.FileExists(FileName) = False

                        End If

                        FlowChartBuilder.SaveAsAndOpen(Me.Session, IsASP, FileName)

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("There are no estimates to print.")

                    End If

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If ValidateForm() Then

                SaveFormControls()

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ComboBoxForm_DateHeaderOption_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxForm_DateHeaderOption.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub CheckBoxLevels_PrintWeek_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxLevels_PrintWeek.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonForm_ManageImages_Click(sender As Object, e As EventArgs) Handles ButtonForm_ManageImages.Click

            AdvantageFramework.Maintenance.General.Presentation.ImageSetupForm.ShowFormDialog()

            LoadImages()

        End Sub
        Private Sub ComboBoxForm_GrandTotalDisplayValue_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxForm_GrandTotalDisplayValue.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso ComboBoxForm_GrandTotalDisplayValue.HasASelectedValue Then

                For Each FCMPEO In _FlowChartMediaPlanOptions.FlowChartMediaPlanEstimateOptions

                    FCMPEO.DisplayValue = ComboBoxForm_GrandTotalDisplayValue.GetSelectedValue

                Next

                DataGridViewForm_EstimateOptions.CurrentView.RefreshData()

            End If

        End Sub
        Private Sub CheckBoxEstimateColumnTotals_Show_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxEstimateColumnTotals_Show.CheckedChanged

            RadioButtonEstimateColumnTotals_Default.Enabled = CheckBoxEstimateColumnTotals_Show.Checked
            RadioButtonEstimateColumnTotals_ByMonth.Enabled = CheckBoxEstimateColumnTotals_Show.Checked
            RadioButtonEstimateColumnTotals_Both.Enabled = CheckBoxEstimateColumnTotals_Show.Checked
            LabelEstimateColumnTotals_AreaColor.Enabled = CheckBoxEstimateColumnTotals_Show.Checked
            ColorPickerEstimateColumnTotals_AreaColor.Enabled = CheckBoxEstimateColumnTotals_Show.Checked

        End Sub
        Private Sub CheckBoxGrandTotals_Show_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxGrandTotals_Show.CheckedChanged

            RadioButtonGrandTotals_Default.Enabled = CheckBoxGrandTotals_Show.Checked
            RadioButtonGrandTotals_ByMonth.Enabled = CheckBoxGrandTotals_Show.Checked
            RadioButtonGrandTotals_Both.Enabled = CheckBoxGrandTotals_Show.Checked
            LabelGrandTotals_AreaColor.Enabled = CheckBoxGrandTotals_Show.Checked
            ColorPickerGrandTotals_AreaColor.Enabled = CheckBoxGrandTotals_Show.Checked

        End Sub

#End Region

#End Region

    End Class

End Namespace
