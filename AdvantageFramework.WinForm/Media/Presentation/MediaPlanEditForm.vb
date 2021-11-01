Namespace Media.Presentation

    Public Class MediaPlanEditForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _MediaPlanID As Integer = 0
        Private _MediaPlanDetailIDToShowOnLoad As Integer = 0
        Private WithEvents _MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing
        Private _PlanChangedInDialog As Boolean = False
        Private _ImageCollection As DevExpress.Utils.ImageCollection = Nothing
        Private _AllowCalendarChange As Boolean = False
        Private _FlowChartMediaPlanOptions As AdvantageFramework.MediaPlanning.FlowChart.FlowChartMediaPlanOptions = Nothing
        Private _CanUserEditTemplate As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property MediaPlanID As Integer
            Get
                MediaPlanID = _MediaPlanID
            End Get
        End Property
        Public ReadOnly Property MediaPlanEstimateID As Integer
            Get
                If _MediaPlan.MediaPlanEstimate IsNot Nothing Then
                    MediaPlanEstimateID = _MediaPlan.MediaPlanEstimate.ID
                Else
                    MediaPlanEstimateID = 0
                End If
            End Get
        End Property
        Public ReadOnly Property TabText As String
            Get
                If _MediaPlan IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate IsNot Nothing Then
                    TabText = "Plan " & _MediaPlan.ID & " - Est " & _MediaPlan.MediaPlanEstimate.ID & " (" & _MediaPlan.MediaPlanEstimate.Name & ")"
                Else
                    TabText = ""
                End If
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal MediaPlanID As Integer, Optional ByVal MediaPlanDetailID As Integer = 0)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _MediaPlanID = MediaPlanID
            _MediaPlanDetailIDToShowOnLoad = MediaPlanDetailID

        End Sub
        Private Sub LoadMediaPlan()

            _MediaPlan = New AdvantageFramework.MediaPlanning.Classes.MediaPlan(Me.Session.ConnectionString, Me.Session.UserCode, _MediaPlanID)

            _CanUserEditTemplate = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, Security.Methods.Modules.Media_MediaPlanning_Actions_EditTemplate, Me.Session.User)

            If _MediaPlan IsNot Nothing Then

                Me.Text = "Media Plan - " & _MediaPlan.Description

                LoadMediaPlanStatus()

            End If

        End Sub
        Private Sub LoadMediaPlanStatus()

            If _MediaPlan IsNot Nothing Then

                If _MediaPlan.MediaPlanEstimates.Count <> 0 Then

                    ButtonItemActions_Unapprove.Visible = Not _MediaPlan.HasUnapprovedEstimates
                    ButtonItemActions_Approve.Visible = _MediaPlan.HasUnapprovedEstimates

                Else

                    ButtonItemActions_Unapprove.Visible = False
                    ButtonItemActions_Approve.Visible = False

                End If

                If ButtonItemActions_Unapprove.Visible Then

                    ButtonItemActions_Unapprove.Tooltip = _MediaPlan.LastApprovalDateUser

                Else

                    ButtonItemActions_Unapprove.Tooltip = Nothing

                End If

                If Me.FormShown Then

                    RibbonBarOptions_Actions.ResetCachedContentSize()

                    RibbonBarOptions_Actions.Refresh()

                    RibbonBarOptions_Actions.Width = RibbonBarOptions_Actions.GetAutoSizeWidth

                    RibbonBarOptions_Actions.Refresh()

                End If

            End If

        End Sub
        Private Sub LoadMediaPlanEsitmatesForComboBox()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            BindingSource = New System.Windows.Forms.BindingSource

            BindingSource.DataSource = (From MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).OrderBy(Function(MPE) MPE.OrderNumber).ToList
                                        Select [MediaPlanDetailIDSalesClassType] = MediaPlanEstimate.Name,
                                               [ID] = MediaPlanEstimate.OrderNumber).ToList

            ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.DataSource = BindingSource

            'AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, "MediaPlanDetailIDSalesClassType", "ID", "[Please select]", 0, True, False, Nothing)

        End Sub
        Private Sub LoadMediaPlanEstimateSettings(ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            If MediaPlanEstimate IsNot Nothing Then

                Me.Text = "Media Plan - " & _MediaPlan.Description & " (" & MediaPlanEstimate.Name & ") - " & _MediaPlan.GetCDPDescription

                LabelForm_EstimateIDData.Text = If(MediaPlanEstimate.ID = 0, "", MediaPlanEstimate.ID)

                ButtonItemGridOptions_FreezeLevels.Checked = MediaPlanEstimate.FreezeLevels

                ButtonItemDateSettings_CalendarMonth.Checked = MediaPlanEstimate.IsCalendarMonth
                ButtonItemDateSettings_BroadcastMonth.Checked = Not MediaPlanEstimate.IsCalendarMonth
                ButtonItemDateSettings_SplitWeeks.Checked = MediaPlanEstimate.SplitWeeks

                ButtonItemMediaRates_Gross.Checked = MediaPlanEstimate.IsEstimateGrossAmount
                ButtonItemMediaRates_Net.Checked = Not MediaPlanEstimate.IsEstimateGrossAmount

                ButtonItemShowHideColumnTotals_GrandTotals.Checked = MediaPlanEstimate.ShowColumnGrandTotals
                ButtonItemShowHideRowTotals_GrandTotals.Checked = MediaPlanEstimate.ShowRowGrandTotals
                ButtonItemShowHideRowTotals_GrandTotalsValues.Checked = MediaPlanEstimate.ShowRowGrandTotalsValues

                ButtonItemShowHideColumnTotals_Totals.Checked = MediaPlanEstimate.ShowColumnTotals
                ButtonItemShowHideRowTotals_Totals.Checked = MediaPlanEstimate.ShowRowTotals
                ButtonItemShowHideRowTotals_TotalsValues.Checked = MediaPlanEstimate.ShowRowTotalsValues

                SetTotalsOptionsOnPivotGridControl(PivotGridForm_MediaPlanDetail, MediaPlanEstimate)

                ButtonItemDataOptions_ShowPackageLevel.Checked = MediaPlanEstimate.ShowPackageName
                ButtonItemDataOptions_ShowDateRange.Checked = MediaPlanEstimate.ShowDateRange
                ButtonItemDataOptions_ShowAdSizes.Checked = MediaPlanEstimate.ShowAdSizes

                If MediaPlanEstimate.DaysOfWeekType <> AdvantageFramework.MediaPlanning.DaysOfWeeksType.None Then

                    If MediaPlanEstimate.DaysOfWeekType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.AsLevel Then

                        ButtonItemShowDaysOfWeek_AsLevel.Checked = True
                        ButtonItemShowDaysOfWeek_OverrideDataWithMerge.Checked = False
                        ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge.Checked = False

                    ElseIf MediaPlanEstimate.DaysOfWeekType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.OverrideDataWithMerge Then

                        ButtonItemShowDaysOfWeek_OverrideDataWithMerge.Checked = True
                        ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge.Checked = False
                        ButtonItemShowDaysOfWeek_AsLevel.Checked = False

                    ElseIf MediaPlanEstimate.DaysOfWeekType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.OverrideDataWithoutMerge Then

                        ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge.Checked = True
                        ButtonItemShowDaysOfWeek_OverrideDataWithMerge.Checked = False
                        ButtonItemShowDaysOfWeek_AsLevel.Checked = False

                    End If

                Else

                    ButtonItemShowDaysOfWeek_AsLevel.Checked = False
                    ButtonItemShowDaysOfWeek_OverrideDataWithMerge.Checked = False
                    ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge.Checked = False

                End If

                ButtonItemTotalFields_GrossPercentageInTotals.Checked = MediaPlanEstimate.GrossPercentageInTotals

                If String.IsNullOrEmpty(MediaPlanEstimate.GrossPercentageInTotalField) = False Then

                    For Each ButtonItem In ButtonItemTotalFields_GrossPercentageInTotals.SubItems.OfType(Of DevComponents.DotNetBar.ButtonItem).ToList

                        If ButtonItem.Name = MediaPlanEstimate.GrossPercentageInTotalField Then

                            ButtonItem.Checked = True
                            Exit For

                        End If

                    Next

                Else

                    For Each ButtonItem In ButtonItemTotalFields_GrossPercentageInTotals.SubItems.OfType(Of DevComponents.DotNetBar.ButtonItem).ToList

                        ButtonItem.Checked = False

                    Next

                End If

                ButtonItemTotalFields_NetDollars.Checked = MediaPlanEstimate.NetDollars
                ButtonItemTotalFields_CPP1.Checked = MediaPlanEstimate.CPP1
                ButtonItemTotalFields_CPP2.Checked = MediaPlanEstimate.CPP2
                ButtonItemTotalFields_CPI.Checked = MediaPlanEstimate.CPI
                ButtonItemTotalFields_CTR.Checked = MediaPlanEstimate.CTR
                ButtonItemTotalFields_ConversionRate.Checked = MediaPlanEstimate.ConversionRate
                ButtonItemTotalFields_TotalDemo1.Checked = MediaPlanEstimate.TotalDemo1
                ButtonItemTotalFields_TotalDemo2.Checked = MediaPlanEstimate.TotalDemo2
                ButtonItemTotalFields_TotalNet.Checked = MediaPlanEstimate.TotalNet
                ButtonItemTotalFields_Commission.Checked = MediaPlanEstimate.Commission

                For Each ButtonItem In ButtonItemDataOptions_RateCPM.SubItems.OfType(Of DevComponents.DotNetBar.ButtonItem).ToList

                    If ButtonItem.Tag = AdvantageFramework.MediaPlanning.DataAreaQuantityColumns.Clicks Then

                        ButtonItem.Checked = MediaPlanEstimate.IsClicksCPM

                    ElseIf ButtonItem.Tag = AdvantageFramework.MediaPlanning.DataAreaQuantityColumns.Units Then

                        ButtonItem.Checked = MediaPlanEstimate.IsUnitsCPM

                    ElseIf ButtonItem.Tag = AdvantageFramework.MediaPlanning.DataAreaQuantityColumns.Impressions Then

                        ButtonItem.Checked = MediaPlanEstimate.IsImpressionsCPM

                    End If

                Next

            Else

                Me.Text = "Media Plan - " & _MediaPlan.Description
                LabelForm_EstimateIDData.Text = ""

            End If

        End Sub
        Private Sub SetTotalsOptionsOnPivotGridControl(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'PivotGridControl.BeginUpdate()

            Try

                PivotGridControl.OptionsView.ShowColumnGrandTotalHeader = MediaPlanEstimate.ShowColumnGrandTotals
                PivotGridControl.OptionsView.ShowColumnGrandTotals = MediaPlanEstimate.ShowColumnGrandTotals

                PivotGridControl.OptionsView.ShowColumnTotals = MediaPlanEstimate.ShowColumnTotals

                PivotGridControl.OptionsView.ShowRowGrandTotalHeader = MediaPlanEstimate.ShowRowGrandTotals
                PivotGridControl.OptionsView.ShowRowGrandTotals = MediaPlanEstimate.ShowRowGrandTotals

                PivotGridControl.OptionsView.ShowRowTotals = MediaPlanEstimate.ShowRowTotals

            Catch ex As Exception

            End Try

            'PivotGridControl.EndUpdate()

        End Sub
        'Private Sub LoadPivotGrid(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

        '    'objects
        '    Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing
        '    Dim DataColumn As System.Data.DataColumn = Nothing
        '    Dim PivotGridAreaDictionary As Generic.Dictionary(Of Long, String) = Nothing
        '    Dim PivotGridAllowedAreaName As String = Nothing
        '    Dim SubItemNumericInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput = Nothing

        '    If MediaPlanEstimate IsNot Nothing Then

        '        'PivotGridControl.BeginUpdate()

        '        Try

        '            PivotGridControl.Fields.Clear()
        '            PivotGridControl.DataSource = Nothing

        '        Catch ex As Exception

        '        End Try

        '        'PivotGridControl.EndUpdate()

        '        'PivotGridControl.BeginUpdate()

        '        PivotGridControl.DataSource = MediaPlanEstimate.EstimateDataTable

        '        PivotGridAreaDictionary = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(DevExpress.XtraPivotGrid.PivotArea))

        '        For Each PivotGridField In PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField)().ToList

        '            Try

        '                DataColumn = MediaPlanEstimate.EstimateDataTable.Columns(PivotGridField.FieldName)

        '            Catch ex As Exception
        '                DataColumn = Nothing
        '            End Try

        '            If DataColumn IsNot Nothing Then

        '                If DataColumn.ExtendedProperties.Contains(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine.Properties.MediaPlanDetailLevelID.ToString) = False Then

        '                    Try

        '                        PivotGridAllowedAreaName = PivotGridAreaDictionary.SingleOrDefault(Function(KVP) KVP.Key = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Area.ToString)).Value

        '                    Catch ex As Exception

        '                    End Try

        '                    PivotGridField.Caption = DataColumn.Caption
        '                    PivotGridField.Area = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Area.ToString)
        '                    PivotGridField.AreaIndex = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.AreaIndex.ToString)

        '                    Try

        '                        PivotGridField.AllowedAreas = AdvantageFramework.EnumUtilities.GetValue(GetType(DevExpress.XtraPivotGrid.PivotGridAllowedAreas), PivotGridAllowedAreaName)

        '                    Catch ex As Exception

        '                    End Try

        '                    PivotGridField.Visible = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.IsVisible.ToString)
        '                    PivotGridField.Index = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Index.ToString)
        '                    PivotGridField.SortOrder = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.SortOrder.ToString)
        '                    PivotGridField.Width = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Width.ToString)

        '                    If PivotGridField.Visible = False AndAlso PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea Then

        '                        PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
        '                        PivotGridField.Options.ShowInCustomizationForm = False
        '                        PivotGridField.Options.ShowInPrefilter = False

        '                    End If

        '                    If PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea Then

        '                        PivotGridField.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.True
        '                        PivotGridField.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.Custom

        '                    End If

        '                    If PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea Then

        '                        PivotGridField.Options.ShowGrandTotal = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.ShowInGrandTotals.ToString)
        '                        PivotGridField.Options.ShowTotals = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.ShowInTotals.ToString)
        '                        PivotGridField.Options.ShowValues = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.ShowInValues.ToString)

        '                    End If

        '                    If PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.[Date].ToString Then

        '                        PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        '                        PivotGridField.CellFormat.FormatString = "d"
        '                        PivotGridField.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        '                        PivotGridField.ValueFormat.FormatString = "d"

        '                    ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString OrElse _
        '                            PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse _
        '                            PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

        '                        PivotGridField.FilterValues.FilterType = DevExpress.XtraPivotGrid.PivotFilterType.Excluded

        '                    ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString Then

        '                        PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '                        PivotGridField.CellFormat.FormatString = "n1"

        '                        AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Me.Session, PivotGridControl, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal, GetType(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData), True, DbContext)

        '                    ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString Then

        '                        PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '                        PivotGridField.CellFormat.FormatString = "n1"

        '                        AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Me.Session, PivotGridControl, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal, GetType(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData), True, DbContext)

        '                    ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.BillAmount.ToString Then

        '                        PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '                        PivotGridField.CellFormat.FormatString = "c2"
        '                        PivotGridField.Options.AllowEdit = False

        '                        AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Me.Session, PivotGridControl, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Currency, GetType(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData), True, DbContext)

        '                    ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.AgencyFee.ToString Then

        '                        PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '                        PivotGridField.CellFormat.FormatString = "c2"

        '                        AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Me.Session, PivotGridControl, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Currency, GetType(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData), True, DbContext)

        '                    ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString Then

        '                        PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '                        PivotGridField.CellFormat.FormatString = "c2"
        '                        PivotGridField.Options.AllowEdit = Not MediaPlanEstimate.CalculateDollars

        '                        AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Me.Session, PivotGridControl, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Currency, GetType(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData), True, DbContext)

        '                    ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString Then

        '                        PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '                        PivotGridField.CellFormat.FormatString = "n1"

        '                        AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Me.Session, PivotGridControl, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal, GetType(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData), True, DbContext)

        '                    ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString Then

        '                        PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '                        PivotGridField.CellFormat.FormatString = "c2"
        '                        PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average

        '                        AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Me.Session, PivotGridControl, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Currency, GetType(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData), True, DbContext)

        '                    ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString Then

        '                        PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '                        PivotGridField.CellFormat.FormatString = "n0"

        '                        AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Me.Session, PivotGridControl, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal, GetType(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData), True, DbContext)

        '                    ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString Then

        '                        PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '                        PivotGridField.CellFormat.FormatString = "n0"

        '                        AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Me.Session, PivotGridControl, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal, GetType(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData), True, DbContext)

        '                    ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Note.ToString Then

        '                        PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max
        '                        PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
        '                        PivotGridField.Options.ShowInCustomizationForm = False
        '                        PivotGridField.Options.ShowInPrefilter = False
        '                        PivotGridField.Visible = False

        '                    ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Color.ToString Then

        '                        PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
        '                        PivotGridField.Options.ShowInCustomizationForm = False
        '                        PivotGridField.Options.ShowInPrefilter = False
        '                        PivotGridField.Visible = False

        '                    ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString Then

        '                        PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
        '                        PivotGridField.Options.ShowInCustomizationForm = False
        '                        PivotGridField.Options.ShowInPrefilter = False

        '                    End If

        '                Else

        '                    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
        '                    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        '                    PivotGridField.Visible = True
        '                    PivotGridField.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False
        '                    PivotGridField.Options.AllowSortBySummary = DevExpress.Utils.DefaultBoolean.False
        '                    PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.True
        '                    PivotGridField.Options.ShowInCustomizationForm = True
        '                    PivotGridField.Options.ShowInPrefilter = True
        '                    PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.True
        '                    PivotGridField.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.Custom
        '                    PivotGridField.Width = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.Width.ToString)

        '                End If

        '            End If

        '        Next

        '        For Each PivotGridField In PivotGridControl.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.RowArea)

        '            Try

        '                DataColumn = MediaPlanEstimate.LevelsAndLinesDataTable.Columns(PivotGridField.FieldName)

        '            Catch ex As Exception
        '                DataColumn = Nothing
        '            End Try

        '            If DataColumn IsNot Nothing Then

        '                PivotGridField.AreaIndex = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString)
        '                PivotGridField.Visible = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.IsVisible.ToString)

        '            End If

        '        Next

        '        'If _MediaPlan.IsApproved Then

        '        '    PivotGridControl.OptionsCustomization.AllowHideFields = DevExpress.XtraPivotGrid.AllowHideFieldsType.Never

        '        '    If PivotGridControl.CustomizationForm IsNot Nothing Then

        '        '        PivotGridControl.DestroyCustomization()
        '        '        ButtonItemGridOptions_ShowHideFieldList.Checked = False

        '        '    End If

        '        'Else

        '        PivotGridControl.OptionsCustomization.AllowHideFields = DevExpress.XtraPivotGrid.AllowHideFieldsType.Always

        '        'End If

        '        PivotGridControl.OptionsCustomization.AllowEdit = True 'Not _MediaPlan.IsApproved

        '        PivotGridControl.OptionsCustomization.AllowPrefilter = False
        '        PivotGridControl.OptionsCustomization.AllowSortInCustomizationForm = False

        '        'PivotGridControl.EndUpdate()

        '    End If

        'End Sub
        'Private Sub SetExpandedValuesForPivotGrid(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

        '    'objects
        '    Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
        '    Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
        '    Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing
        '    Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

        '    'PivotGridControl.BeginUpdate()

        '    For Each PivotGridField In PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField)().Where(Function(PGF) PGF.Visible AndAlso PGF.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea).ToList

        '        Try

        '            MediaPlanDetailLevel = MediaPlanEstimate.MediaPlanDetailLevels.SingleOrDefault(Function(Entity) PivotGridField.FieldName = Entity.Description)

        '        Catch ex As Exception
        '            MediaPlanDetailLevel = Nothing
        '        End Try

        '        If MediaPlanDetailLevel IsNot Nothing Then

        '            For Each MediaPlanDetailLevelLine In MediaPlanDetailLevel.MediaPlanDetailLevelLines.ToList

        '                Try

        '                    If MediaPlanDetailLevelLine.Expanded Then

        '                        PivotGridField.ExpandValue(MediaPlanDetailLevelLine.Description)

        '                    Else

        '                        PivotGridField.CollapseValue(MediaPlanDetailLevelLine.Description)

        '                    End If

        '                Catch ex As Exception

        '                End Try

        '            Next

        '        End If

        '    Next

        '    'PivotGridControl.EndUpdate()

        'End Sub
        'Private Sub LoadCalculatedFieldsToPivotGrid(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

        '    'PivotGridControl.BeginUpdate()

        '    AddGrossPercentageInTotalsField(PivotGridControl, MediaPlanEstimate)
        '    AddNetDollarsField(PivotGridControl, MediaPlanEstimate)
        '    AddCPP1Field(PivotGridControl, MediaPlanEstimate)
        '    AddCPP2Field(PivotGridControl, MediaPlanEstimate)
        '    AddCPIField(PivotGridControl, MediaPlanEstimate)

        '    'PivotGridControl.EndUpdate()

        'End Sub
        'Private Sub AddGrossPercentageInTotalsField(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

        '    'objects
        '    Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

        '    Try

        '        PivotGridField = PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotals.ToString)

        '    Catch ex As Exception
        '        PivotGridField = Nothing
        '    End Try

        '    If PivotGridField Is Nothing Then

        '        PivotGridField = PivotGridControl.Fields.Add()

        '    End If

        '    PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotals.ToString
        '    PivotGridField.UnboundType = DevExpress.Data.UnboundColumnType.Decimal

        '    If _MediaPlan.GrossBudgetAmount.GetValueOrDefault(0) > 0 Then

        '        If String.IsNullOrEmpty(MediaPlanEstimate.GrossPercentageInTotalField) = False Then

        '            PivotGridField.UnboundExpression = "([" & MediaPlanEstimate.GrossPercentageInTotalField & "]/" & _MediaPlan.GrossBudgetAmount.GetValueOrDefault(0) & ")"

        '        End If

        '        If PivotGridField.UnboundExpression = "" Then

        '            PivotGridField.UnboundExpression = "0"

        '        End If

        '    Else

        '        PivotGridField.UnboundExpression = "0"

        '    End If

        '    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        '    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea
        '    PivotGridField.Caption = "Gross %"
        '    PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '    PivotGridField.CellFormat.FormatString = "P"

        '    PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False
        '    PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
        '    PivotGridField.Options.ShowValues = False
        '    PivotGridField.Options.ShowTotals = False
        '    PivotGridField.Options.ShowInCustomizationForm = False
        '    PivotGridField.Options.ShowInPrefilter = False
        '    PivotGridField.Options.ShowGrandTotal = True
        '    PivotGridField.Options.AllowEdit = False
        '    PivotGridField.Visible = MediaPlanEstimate.GrossPercentageInTotals

        'End Sub
        'Private Sub AddNetDollarsField(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

        '    'objects
        '    Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

        '    Try

        '        PivotGridField = PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString)

        '    Catch ex As Exception
        '        PivotGridField = Nothing
        '    End Try

        '    If PivotGridField Is Nothing Then

        '        PivotGridField = PivotGridControl.Fields.Add()

        '    End If

        '    PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString
        '    PivotGridField.UnboundType = DevExpress.Data.UnboundColumnType.Decimal

        '    If MediaPlanEstimate.IsEstimateGrossAmount Then

        '        PivotGridField.UnboundExpression = "[" & AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString & "] * 0.85"

        '    Else

        '        PivotGridField.UnboundExpression = "[" & AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString & "]"

        '    End If

        '    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        '    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea
        '    PivotGridField.Caption = "Net Dollars"
        '    PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '    PivotGridField.CellFormat.FormatString = "c2"

        '    PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False
        '    PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
        '    PivotGridField.Options.ShowValues = False
        '    PivotGridField.Options.ShowTotals = False
        '    PivotGridField.Options.ShowInCustomizationForm = False
        '    PivotGridField.Options.ShowInPrefilter = False
        '    PivotGridField.Options.ShowGrandTotal = True
        '    PivotGridField.Options.AllowEdit = False
        '    PivotGridField.Visible = MediaPlanEstimate.NetDollars

        'End Sub
        'Private Sub AddCPP1Field(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

        '    'objects
        '    Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

        '    Try

        '        PivotGridField = PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP1.ToString)

        '    Catch ex As Exception
        '        PivotGridField = Nothing
        '    End Try

        '    If PivotGridField Is Nothing Then

        '        PivotGridField = PivotGridControl.Fields.Add()

        '    End If

        '    PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP1.ToString
        '    PivotGridField.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
        '    PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average

        '    PivotGridField.UnboundExpression = "[" & AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString & "] / [" & AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString & "]"

        '    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        '    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea
        '    PivotGridField.Caption = "CPP 1"
        '    PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '    PivotGridField.CellFormat.FormatString = "c2"

        '    PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False
        '    PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
        '    PivotGridField.Options.ShowValues = False
        '    PivotGridField.Options.ShowTotals = False
        '    PivotGridField.Options.ShowInCustomizationForm = False
        '    PivotGridField.Options.ShowInPrefilter = False
        '    PivotGridField.Options.ShowGrandTotal = True
        '    PivotGridField.Options.AllowEdit = False
        '    PivotGridField.Visible = MediaPlanEstimate.CPP1

        'End Sub
        'Private Sub AddCPP2Field(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

        '    'objects
        '    Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

        '    Try

        '        PivotGridField = PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP2.ToString)

        '    Catch ex As Exception
        '        PivotGridField = Nothing
        '    End Try

        '    If PivotGridField Is Nothing Then

        '        PivotGridField = PivotGridControl.Fields.Add()

        '    End If

        '    PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP2.ToString
        '    PivotGridField.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
        '    PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average

        '    PivotGridField.UnboundExpression = "[" & AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString & "] / [" & AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString & "]"

        '    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        '    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea
        '    PivotGridField.Caption = "CPP 2"
        '    PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '    PivotGridField.CellFormat.FormatString = "c2"

        '    PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False
        '    PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
        '    PivotGridField.Options.ShowValues = False
        '    PivotGridField.Options.ShowTotals = False
        '    PivotGridField.Options.ShowInCustomizationForm = False
        '    PivotGridField.Options.ShowInPrefilter = False
        '    PivotGridField.Options.ShowGrandTotal = True
        '    PivotGridField.Options.AllowEdit = False
        '    PivotGridField.Visible = MediaPlanEstimate.CPP2

        'End Sub
        'Private Sub AddCPIField(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

        '    'objects
        '    Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

        '    Try

        '        PivotGridField = PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPI.ToString)

        '    Catch ex As Exception
        '        PivotGridField = Nothing
        '    End Try

        '    If PivotGridField Is Nothing Then

        '        PivotGridField = PivotGridControl.Fields.Add()

        '    End If

        '    PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPI.ToString
        '    PivotGridField.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
        '    PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average

        '    If MediaPlanEstimate.IsImpressionsCPM Then

        '        PivotGridField.UnboundExpression = "[" & AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString & "] / ([" & AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString & "] / 1000)"

        '    Else

        '        PivotGridField.UnboundExpression = "[" & AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString & "] / [" & AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString & "]"

        '    End If

        '    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        '    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea
        '    PivotGridField.Caption = "CPI"
        '    PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '    PivotGridField.CellFormat.FormatString = "c2"

        '    PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False
        '    PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
        '    PivotGridField.Options.ShowValues = False
        '    PivotGridField.Options.ShowTotals = False
        '    PivotGridField.Options.ShowInCustomizationForm = False
        '    PivotGridField.Options.ShowInPrefilter = False
        '    PivotGridField.Options.ShowGrandTotal = True
        '    PivotGridField.Options.AllowEdit = False
        '    PivotGridField.Visible = MediaPlanEstimate.CPI

        'End Sub
        'Private Sub AddDaysOfWeekField(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

        '    'objects
        '    Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

        '    Try

        '        PivotGridField = PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.DaysOfWeek.ToString)

        '    Catch ex As Exception
        '        PivotGridField = Nothing
        '    End Try

        '    If PivotGridField Is Nothing Then

        '        PivotGridField = PivotGridControl.Fields.Add()

        '    End If

        '    PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.DaysOfWeek.ToString
        '    PivotGridField.UnboundType = DevExpress.Data.UnboundColumnType.String
        '    'PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom

        '    PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
        '    PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        '    PivotGridField.Caption = MediaPlanEstimate.DaysOfWeekCaption
        '    PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.None

        '    PivotGridField.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False
        '    PivotGridField.Options.AllowSortBySummary = DevExpress.Utils.DefaultBoolean.False
        '    PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
        '    PivotGridField.Options.ShowInCustomizationForm = False
        '    PivotGridField.Options.ShowInPrefilter = False
        '    PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False
        '    PivotGridField.Options.AllowEdit = False
        '    PivotGridField.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.Custom

        '    If MediaPlanEstimate.DaysOfWeekType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.AsLevel Then

        '        PivotGridField.Visible = True

        '    Else

        '        PivotGridField.Visible = False

        '    End If

        'End Sub
        Private Sub FieldAreaIndexChanged(ByVal ChangedPivotGridField As DevExpress.XtraPivotGrid.PivotGridField, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate, ByRef RefreshData As Boolean)

            'objects
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim LastVisibleIndex As Integer = -1
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing
            Dim MediaPlanDetailFieldsList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailField) = Nothing
            Dim MediaPlanDetailLevelsList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevel) = Nothing

            If ChangedPivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea Then

                MediaPlanDetailLevelsList = MediaPlanEstimate.MediaPlanDetailLevels.ToList

                For Each PivotGridField In PivotGridForm_MediaPlanDetail.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).Where(Function(PGF) PGF.Area = ChangedPivotGridField.Area).ToList

                    Try

                        MediaPlanDetailLevel = MediaPlanDetailLevelsList.SingleOrDefault(Function(Entity) Entity.Description = PivotGridField.FieldName)

                    Catch ex As Exception
                        MediaPlanDetailLevel = Nothing
                    End Try

                    If MediaPlanDetailLevel IsNot Nothing Then

                        If PivotGridField.Visible Then

                            MediaPlanDetailLevel.OrderNumber = PivotGridField.AreaIndex

                            If MediaPlanEstimate.IsDataLoaded Then

                                MediaPlanEstimate.LevelsAndLinesDataTable.Columns(PivotGridField.FieldName).ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString) = PivotGridField.AreaIndex
                                MediaPlanEstimate.LevelsAndLinesDataTable.Columns(PivotGridField.FieldName).SetOrdinal(PivotGridField.AreaIndex)
                                MediaPlanEstimate.EstimateDataTable.Columns(PivotGridField.FieldName).ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString) = PivotGridField.AreaIndex

                            End If

                            If PivotGridField.AreaIndex > LastVisibleIndex Then

                                LastVisibleIndex = PivotGridField.AreaIndex

                            End If

                            MediaPlanDetailLevelsList.Remove(MediaPlanDetailLevel)

                        End If


                    Else

                        If PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowPackageLevels.ToString Then

                            MediaPlanEstimate.PackageLevelIndex = PivotGridField.AreaIndex

                            If PivotGridField.AreaIndex > LastVisibleIndex Then

                                LastVisibleIndex = PivotGridField.AreaIndex

                            End If

                        ElseIf PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowAdSizes.ToString Then

                            MediaPlanEstimate.AdSizesIndex = PivotGridField.AreaIndex

                            If PivotGridField.AreaIndex > LastVisibleIndex Then

                                LastVisibleIndex = PivotGridField.AreaIndex

                            End If

                        ElseIf PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowDateRange.ToString Then

                            MediaPlanEstimate.DateRangeIndex = PivotGridField.AreaIndex

                            If PivotGridField.AreaIndex > LastVisibleIndex Then

                                LastVisibleIndex = PivotGridField.AreaIndex

                            End If

                        End If

                    End If

                Next

                For Each MediaPlanDetailLevel In MediaPlanDetailLevelsList.OrderBy(Function(Entity) Entity.OrderNumber).ToList

                    LastVisibleIndex += 1

                    MediaPlanDetailLevel.OrderNumber = LastVisibleIndex

                    If MediaPlanEstimate.IsDataLoaded Then

                        MediaPlanEstimate.LevelsAndLinesDataTable.Columns(MediaPlanDetailLevel.Description).ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString) = LastVisibleIndex

                        If MediaPlanEstimate.LevelsAndLinesDataTable.Columns(PivotGridField.FieldName) IsNot Nothing Then

                            MediaPlanEstimate.LevelsAndLinesDataTable.Columns(PivotGridField.FieldName).SetOrdinal(LastVisibleIndex)

                        End If

                        MediaPlanEstimate.EstimateDataTable.Columns(MediaPlanDetailLevel.Description).ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString) = LastVisibleIndex

                    End If

                Next

            Else

                MediaPlanDetailFieldsList = MediaPlanEstimate.MediaPlanDetailFields.ToList

                For Each PivotGridField In PivotGridForm_MediaPlanDetail.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).Where(Function(PGF) PGF.Area = ChangedPivotGridField.Area).ToList

                    Try

                        MediaPlanDetailField = MediaPlanDetailFieldsList.SingleOrDefault(Function(Entity) Entity.FieldID = PivotGridField.FieldName)

                    Catch ex As Exception
                        MediaPlanDetailField = Nothing
                    End Try

                    If MediaPlanDetailField IsNot Nothing Then

                        If PivotGridField.Visible Then

                            MediaPlanDetailField.AreaIndex = PivotGridField.AreaIndex

                            If MediaPlanEstimate.IsDataLoaded Then

                                MediaPlanEstimate.EstimateDataTable.Columns(PivotGridField.FieldName).ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.AreaIndex.ToString) = PivotGridField.AreaIndex

                            End If

                            If PivotGridField.AreaIndex > LastVisibleIndex Then

                                LastVisibleIndex = PivotGridField.AreaIndex

                            End If

                            MediaPlanDetailFieldsList.Remove(MediaPlanDetailField)

                        End If

                    Else

                        If PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CTR.ToString Then

                            MediaPlanEstimate.CTRIndex = PivotGridField.AreaIndex

                            If PivotGridField.AreaIndex > LastVisibleIndex Then

                                LastVisibleIndex = PivotGridField.AreaIndex

                            End If

                        ElseIf PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ConversionRate.ToString Then

                            MediaPlanEstimate.ConversionRateIndex = PivotGridField.AreaIndex

                            If PivotGridField.AreaIndex > LastVisibleIndex Then

                                LastVisibleIndex = PivotGridField.AreaIndex

                            End If

                        ElseIf PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString Then

                            MediaPlanEstimate.NetDollarsIndex = PivotGridField.AreaIndex

                            If PivotGridField.AreaIndex > LastVisibleIndex Then

                                LastVisibleIndex = PivotGridField.AreaIndex

                            End If

                        ElseIf PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPI.ToString Then

                            MediaPlanEstimate.CPIIndex = PivotGridField.AreaIndex

                            If PivotGridField.AreaIndex > LastVisibleIndex Then

                                LastVisibleIndex = PivotGridField.AreaIndex

                            End If

                        ElseIf PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP1.ToString Then

                            MediaPlanEstimate.CPP1Index = PivotGridField.AreaIndex

                            If PivotGridField.AreaIndex > LastVisibleIndex Then

                                LastVisibleIndex = PivotGridField.AreaIndex

                            End If

                        ElseIf PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP2.ToString Then

                            MediaPlanEstimate.CPP2Index = PivotGridField.AreaIndex

                            If PivotGridField.AreaIndex > LastVisibleIndex Then

                                LastVisibleIndex = PivotGridField.AreaIndex

                            End If

                        ElseIf PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo1.ToString Then

                            MediaPlanEstimate.TotalDemo1Index = PivotGridField.AreaIndex

                            If PivotGridField.AreaIndex > LastVisibleIndex Then

                                LastVisibleIndex = PivotGridField.AreaIndex

                            End If

                        ElseIf PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo2.ToString Then

                            MediaPlanEstimate.TotalDemo2Index = PivotGridField.AreaIndex

                            If PivotGridField.AreaIndex > LastVisibleIndex Then

                                LastVisibleIndex = PivotGridField.AreaIndex

                            End If

                        ElseIf PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalNet.ToString Then

                            MediaPlanEstimate.TotalNetIndex = PivotGridField.AreaIndex

                            If PivotGridField.AreaIndex > LastVisibleIndex Then

                                LastVisibleIndex = PivotGridField.AreaIndex

                            End If

                        ElseIf PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.Commission.ToString Then

                            MediaPlanEstimate.CommissionIndex = PivotGridField.AreaIndex

                            If PivotGridField.AreaIndex > LastVisibleIndex Then

                                LastVisibleIndex = PivotGridField.AreaIndex

                            End If

                        ElseIf PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotals.ToString Then

                            MediaPlanEstimate.GrossPercentageInTotalsIndex = PivotGridField.AreaIndex

                            If PivotGridField.AreaIndex > LastVisibleIndex Then

                                LastVisibleIndex = PivotGridField.AreaIndex

                            End If

                        End If

                    End If

                Next

                For Each MediaPlanDetailField In MediaPlanDetailFieldsList.OrderBy(Function(Entity) Entity.Index).ToList

                    LastVisibleIndex += 1

                    MediaPlanDetailField.AreaIndex = LastVisibleIndex

                Next

                If ChangedPivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString OrElse
                        ChangedPivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString OrElse
                        ChangedPivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString OrElse
                        ChangedPivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString OrElse
                        ChangedPivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString Then

                    MediaPlanEstimate.LoadQuantityColumn(False, RefreshData)

                ElseIf ChangedPivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString OrElse
                        ChangedPivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString Then

                    'MediaPlanEstimate.LoadFirstVisibleQuantityColumnForCalculationOnly(False, RefreshData)
                    RefreshData = True

                End If

            End If

        End Sub
        Private Sub SaveFieldSortOrder(ByVal e As DevExpress.XtraPivotGrid.PivotFieldPropertyChangedEventArgs, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing

            Try

                MediaPlanDetailField = MediaPlanEstimate.MediaPlanDetailFields.SingleOrDefault(Function(Entity) Entity.FieldID = e.Field.FieldName)

            Catch ex As Exception
                MediaPlanDetailField = Nothing
            End Try

            If MediaPlanDetailField IsNot Nothing Then

                MediaPlanDetailField.SortOrder = e.Field.SortOrder

                If MediaPlanEstimate.IsDataLoaded Then

                    MediaPlanEstimate.EstimateDataTable.Columns(e.Field.FieldName).ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.SortOrder.ToString) = e.Field.SortOrder

                End If

            End If

        End Sub
        Private Sub SaveFieldVisible(ByVal ChangedPivotGridField As DevExpress.XtraPivotGrid.PivotGridField, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate, ByRef RefreshData As Boolean)

            'objects
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            If ChangedPivotGridField IsNot Nothing AndAlso ChangedPivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea Then

                Try

                    MediaPlanDetailLevel = MediaPlanEstimate.MediaPlanDetailLevels.SingleOrDefault(Function(Entity) Entity.Description = ChangedPivotGridField.FieldName)

                Catch ex As Exception
                    MediaPlanDetailLevel = Nothing
                End Try

                If MediaPlanDetailLevel IsNot Nothing Then

                    MediaPlanDetailLevel.IsVisible = ChangedPivotGridField.Visible

                    If MediaPlanEstimate.IsDataLoaded Then

                        MediaPlanEstimate.LevelsAndLinesDataTable.Columns(ChangedPivotGridField.FieldName).ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.IsVisible.ToString) = ChangedPivotGridField.Visible
                        MediaPlanEstimate.EstimateDataTable.Columns(ChangedPivotGridField.FieldName).ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.IsVisible.ToString) = ChangedPivotGridField.Visible

                    End If

                    Try

                        PivotGridField = PivotGridForm_MediaPlanDetail.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.RowArea).ToList.SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.DaysOfWeek.ToString)

                    Catch ex As Exception
                        PivotGridField = Nothing
                    End Try

                    If PivotGridField IsNot Nothing Then

                        PivotGridField.SetAreaPosition(DevExpress.XtraPivotGrid.PivotArea.RowArea, PivotGridForm_MediaPlanDetail.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.RowArea).Count() - 1)

                    End If

                    FieldAreaIndexChanged(ChangedPivotGridField, MediaPlanEstimate, RefreshData)

                Else

                    If ChangedPivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowPackageLevels.ToString Then

                        ButtonItemDataOptions_ShowPackageLevel.Checked = ChangedPivotGridField.Visible

                    ElseIf ChangedPivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowAdSizes.ToString Then

                        ButtonItemDataOptions_ShowAdSizes.Checked = ChangedPivotGridField.Visible

                    ElseIf ChangedPivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowDateRange.ToString Then

                        ButtonItemDataOptions_ShowDateRange.Checked = ChangedPivotGridField.Visible

                    End If

                End If

            Else

                Try

                    MediaPlanDetailField = MediaPlanEstimate.MediaPlanDetailFields.SingleOrDefault(Function(Entity) Entity.FieldID = ChangedPivotGridField.FieldName)

                Catch ex As Exception
                    MediaPlanDetailField = Nothing
                End Try

                If MediaPlanDetailField IsNot Nothing Then

                    MediaPlanDetailField.IsVisible = ChangedPivotGridField.Visible

                    If MediaPlanEstimate.IsDataLoaded Then

                        MediaPlanEstimate.EstimateDataTable.Columns(ChangedPivotGridField.FieldName).ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.IsVisible.ToString) = ChangedPivotGridField.Visible

                    End If

                    FieldAreaIndexChanged(ChangedPivotGridField, MediaPlanEstimate, RefreshData)

                End If

            End If

        End Sub
        Private Sub SaveExpandedValueSetting(ByVal e As DevExpress.XtraPivotGrid.PivotFieldValueEventArgs, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim Expanded As Boolean = False
            Dim RowIndex As Integer = -1
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Expanded = Not e.IsCollapsed

                Try

                    MediaPlanDetailLevel = MediaPlanEstimate.MediaPlanDetailLevels.SingleOrDefault(Function(Entity) e.Field.FieldName = Entity.Description)

                Catch ex As Exception
                    MediaPlanDetailLevel = Nothing
                End Try

                If MediaPlanDetailLevel IsNot Nothing Then

                    Try

                        PivotDrillDownDataSource = e.CreateDrillDownDataSource

                    Catch ex As Exception
                        PivotDrillDownDataSource = Nothing
                    End Try

                    If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                        Try

                            RowIndex = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Select(Function(PDDDR) CInt(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).Distinct.ToList.Min

                        Catch ex As Exception
                            RowIndex = -1
                        End Try

                        For Each RowIndex In PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Select(Function(PDDDR) CInt(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).Distinct.ToList

                            Try

                                MediaPlanDetailLevelLine = MediaPlanDetailLevel.MediaPlanDetailLevelLines.SingleOrDefault(Function(Entity) Entity.RowIndex = RowIndex)

                            Catch ex As Exception
                                MediaPlanDetailLevelLine = Nothing
                            End Try

                            If MediaPlanDetailLevelLine IsNot Nothing Then

                                MediaPlanDetailLevelLine.Expanded = Expanded

                            End If

                        Next

                    End If

                End If

            End If

        End Sub
        Private Sub SaveFieldCaptionSetting(ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate, ByVal FieldName As String, ByVal Caption As String)

            'objects
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If MediaPlanEstimate.IsDataLoaded Then

                    MediaPlanEstimate.EstimateDataTable.Columns(FieldName).Caption = Caption

                End If

                Try

                    MediaPlanDetailField = MediaPlanEstimate.MediaPlanDetailFields.SingleOrDefault(Function(Entity) Entity.FieldID = FieldName)

                Catch ex As Exception
                    MediaPlanDetailField = Nothing
                End Try

                If MediaPlanDetailField IsNot Nothing Then

                    MediaPlanDetailField.Caption = Caption

                End If

            End If

        End Sub
        Private Sub SaveFieldShowInValuesSetting(ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate, ByVal FieldName As String, ByVal ShowInValues As Boolean)

            'objects
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If MediaPlanEstimate.IsDataLoaded Then

                    MediaPlanEstimate.EstimateDataTable.Columns(FieldName).ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.ShowInValues.ToString) = ShowInValues

                End If

                Try

                    MediaPlanDetailField = MediaPlanEstimate.MediaPlanDetailFields.SingleOrDefault(Function(Entity) Entity.FieldID = FieldName)

                Catch ex As Exception
                    MediaPlanDetailField = Nothing
                End Try

                If MediaPlanDetailField IsNot Nothing Then

                    MediaPlanDetailField.ShowInValues = ShowInValues

                End If

            End If

        End Sub
        Private Sub SaveFieldShowInTotalsSetting(ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate, ByVal FieldName As String, ByVal ShowInTotals As Boolean)

            'objects
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If MediaPlanEstimate.IsDataLoaded Then

                    MediaPlanEstimate.EstimateDataTable.Columns(FieldName).ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.ShowInTotals.ToString) = ShowInTotals

                End If

                Try

                    MediaPlanDetailField = MediaPlanEstimate.MediaPlanDetailFields.SingleOrDefault(Function(Entity) Entity.FieldID = FieldName)

                Catch ex As Exception
                    MediaPlanDetailField = Nothing
                End Try

                If MediaPlanDetailField IsNot Nothing Then

                    MediaPlanDetailField.ShowInTotals = ShowInTotals

                End If

            End If

        End Sub
        Private Sub SaveFieldShowInGrandTotalsSetting(ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate, ByVal FieldName As String, ByVal ShowInGrandTotals As Boolean)

            'objects
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If MediaPlanEstimate.IsDataLoaded Then

                    MediaPlanEstimate.EstimateDataTable.Columns(FieldName).ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.ShowInGrandTotals.ToString) = ShowInGrandTotals

                End If

                Try

                    MediaPlanDetailField = MediaPlanEstimate.MediaPlanDetailFields.SingleOrDefault(Function(Entity) Entity.FieldID = FieldName)

                Catch ex As Exception
                    MediaPlanDetailField = Nothing
                End Try

                If MediaPlanDetailField IsNot Nothing Then

                    MediaPlanDetailField.ShowInGrandTotals = ShowInGrandTotals

                End If

            End If

        End Sub
        'Private Function CreateTextBrick(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal BrickGraphics As DevExpress.XtraPrinting.BrickGraphics, _
        '                                 ByVal OutputString As String) As DevExpress.XtraPrinting.TextBrick

        '    'objects
        '    Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing
        '    Dim SizeF As System.Drawing.SizeF = Nothing

        '    SizeF = BrickGraphics.MeasureString(OutputString, Width)

        '    TextBrick = New DevExpress.XtraPrinting.TextBrick

        '    TextBrick.Rect = New System.Drawing.Rectangle(X, Y, Width, CInt(SizeF.Height))
        '    TextBrick.BackColor = System.Drawing.Color.White
        '    TextBrick.BorderWidth = 0
        '    TextBrick.BorderStyle = DevExpress.XtraPrinting.BrickBorderStyle.Inset
        '    TextBrick.Font = New System.Drawing.Font("Tahoma", TextBrick.Font.Size)

        '    TextBrick.Text = OutputString

        '    CreateTextBrick = TextBrick

        'End Function
        'Private Function CreateTextBrick(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer) As DevExpress.XtraPrinting.TextBrick

        '    'objects
        '    Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing

        '    TextBrick = New DevExpress.XtraPrinting.TextBrick

        '    TextBrick.Rect = New System.Drawing.Rectangle(X, Y, Width, Height)
        '    TextBrick.BackColor = System.Drawing.Color.White
        '    TextBrick.BorderWidth = 0
        '    TextBrick.BorderStyle = DevExpress.XtraPrinting.BrickBorderStyle.Inset
        '    TextBrick.Font = New System.Drawing.Font("Tahoma", TextBrick.Font.Size)

        '    CreateTextBrick = TextBrick

        'End Function
        Private Function SaveChanges(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Saved As Boolean = True

            Saved = _MediaPlan.Save(ErrorMessage)

            If Saved Then

                If _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                    _MediaPlan.Refresh(_MediaPlan.MediaPlanEstimate.ID, False)

                Else

                    _MediaPlan.Refresh(0, False)

                End If

                RefreshMediaPlanForm()

                Me.ClearChanged()

            End If

            SaveChanges = Saved

        End Function
        Private Sub RefreshMediaPlanForm()

            Try

                For Each MdiChild In Me.ParentForm.MdiChildren

                    If TypeOf MdiChild Is AdvantageFramework.Media.Presentation.MediaPlanningForm Then

                        DirectCast(MdiChild, AdvantageFramework.Media.Presentation.MediaPlanningForm).RefreshForm()
                        Exit For

                    End If

                Next

            Catch ex As Exception

            End Try

        End Sub
        'Private Sub PlanHeaderLink_CreateDetailArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs)

        '    'objects
        '    Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing
        '    Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
        '    Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
        '    Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
        '    Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
        '    Dim BillingTotal As Decimal = 0
        '    Dim VeritcalLocation As Integer = 0

        '    Try

        '        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '            ClientContact = AdvantageFramework.Database.Procedures.ClientContact.LoadByContactID(DbContext, _MediaPlan.ClientContactID.GetValueOrDefault(0))

        '            Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, _MediaPlan.ClientCode)

        '            Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, _MediaPlan.ClientCode, _MediaPlan.DivisionCode)

        '            Product = _MediaPlan.Product

        '        End Using

        '    Catch ex As Exception

        '    End Try

        '    Try

        '        TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

        '        TextBrick.Text = _MediaPlan.Description

        '        e.Graph.DrawBrick(TextBrick)

        '        VeritcalLocation += 15

        '    Catch ex As Exception

        '    End Try

        '    Try

        '        TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

        '        TextBrick.Text = "Client: " & Client.Name

        '        e.Graph.DrawBrick(TextBrick)

        '        VeritcalLocation += 15

        '    Catch ex As Exception

        '    End Try

        '    Try

        '        TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

        '        TextBrick.Text = "Division: " & If(Division IsNot Nothing, Division.Name, "")

        '        e.Graph.DrawBrick(TextBrick)

        '        VeritcalLocation += 15

        '    Catch ex As Exception

        '    End Try

        '    Try

        '        TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

        '        TextBrick.Text = "Product: " & If(Product IsNot Nothing, Product.Name, "")

        '        e.Graph.DrawBrick(TextBrick)

        '        VeritcalLocation += 15

        '    Catch ex As Exception

        '    End Try

        '    Try

        '        If ClientContact IsNot Nothing Then

        '            TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

        '            TextBrick.Text = "Client Contact: " & ClientContact.ToString

        '            e.Graph.DrawBrick(TextBrick)

        '            VeritcalLocation += 15

        '        End If

        '    Catch ex As Exception

        '    End Try

        '    Try

        '        TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

        '        TextBrick.Text = "Start Date: " & _MediaPlan.StartDate.ToShortDateString

        '        e.Graph.DrawBrick(TextBrick)

        '        VeritcalLocation += 15

        '    Catch ex As Exception

        '    End Try

        '    Try

        '        TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

        '        TextBrick.Text = "End Date: " & _MediaPlan.EndDate.ToShortDateString

        '        e.Graph.DrawBrick(TextBrick)

        '        VeritcalLocation += 15

        '    Catch ex As Exception

        '    End Try

        '    Try

        '        TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

        '        TextBrick.Text = "Gross Budget: " & FormatCurrency(_MediaPlan.GrossBudgetAmount.GetValueOrDefault(0))

        '        e.Graph.DrawBrick(TextBrick)

        '        VeritcalLocation += 15

        '    Catch ex As Exception

        '    End Try

        '    Try

        '        TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

        '        For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)()

        '            BillingTotal += MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.BillAmount.GetValueOrDefault(0)).Sum

        '        Next

        '        TextBrick.Text = "Billing Total: " & FormatCurrency(BillingTotal)

        '        e.Graph.DrawBrick(TextBrick)

        '        VeritcalLocation += 15

        '    Catch ex As Exception

        '    End Try

        '    Try

        '        TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

        '        TextBrick.Text = "Variance: " & FormatCurrency(_MediaPlan.GrossBudgetAmount.GetValueOrDefault(0) - BillingTotal)

        '        e.Graph.DrawBrick(TextBrick)

        '        VeritcalLocation += 15

        '    Catch ex As Exception

        '    End Try

        '    Try

        '        If String.IsNullOrWhiteSpace(_MediaPlan.Comment) = False Then

        '            TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, e.Graph, "Comment: " & _MediaPlan.Comment)

        '        Else

        '            TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, e.Graph, "")

        '        End If

        '        e.Graph.DrawBrick(TextBrick)

        '    Catch ex As Exception

        '    End Try

        'End Sub
        'Private Sub HeaderLink_CreateDetailArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs)

        '    'objects
        '    Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing

        '    Try

        '        TextBrick = CreateTextBrick(0, 0, e.Graph.ClientPageSize.Width, 15)

        '        TextBrick.Text = CType(CType(sender, AdvantageFramework.Reporting.Reports.CustomLink).Tag, AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).Name

        '        e.Graph.DrawBrick(TextBrick)

        '    Catch ex As Exception

        '    End Try

        '    Try

        '        If String.IsNullOrWhiteSpace(CType(CType(sender, AdvantageFramework.Reporting.Reports.CustomLink).Tag, AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).Notes) = False Then

        '            TextBrick = CreateTextBrick(0, 15, e.Graph.ClientPageSize.Width, e.Graph, "Comment: " & CType(CType(sender, AdvantageFramework.Reporting.Reports.CustomLink).Tag, AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).Notes)

        '        Else

        '            TextBrick = CreateTextBrick(0, 15, e.Graph.ClientPageSize.Width, e.Graph, "")

        '        End If

        '        e.Graph.DrawBrick(TextBrick)

        '    Catch ex As Exception

        '    End Try

        'End Sub
        'Private Sub FooterLink_CreateDetailArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs)

        '    'objects
        '    Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing

        '    TextBrick = New DevExpress.XtraPrinting.TextBrick

        '    TextBrick.Rect = New System.Drawing.Rectangle(0, 0, e.Graph.ClientPageSize.Width, 15)
        '    TextBrick.BackColor = System.Drawing.Color.White
        '    TextBrick.BorderWidth = 0
        '    TextBrick.BorderStyle = DevExpress.XtraPrinting.BrickBorderStyle.Inset
        '    TextBrick.Font = New System.Drawing.Font("Tahoma", TextBrick.Font.Size)

        '    TextBrick.Text = ""

        '    e.Graph.DrawBrick(TextBrick)

        'End Sub
        'Private Sub PivotGridControl_FirstPivotGridCustomExportCell(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.CustomExportCellEventArgs)

        '    'objects
        '    Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing
        '    Dim Color As Integer = 0
        '    Dim HasData As Boolean = False
        '    Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing
        '    Dim HasNote As Boolean = False

        '    Try

        '        If e.ColumnField IsNot Nothing AndAlso e.RowField IsNot Nothing AndAlso _
        '                DirectCast(sender, DevExpress.XtraPivotGrid.PivotGridControl).GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.ColumnArea).Last Is e.ColumnField AndAlso _
        '                DirectCast(sender, DevExpress.XtraPivotGrid.PivotGridControl).GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.RowArea).Last Is e.RowField Then

        '            Try

        '                PivotDrillDownDataSource = DirectCast(sender, DevExpress.XtraPivotGrid.PivotGridControl).CreateDrillDownDataSource(e.ColumnIndex, e.RowIndex)

        '            Catch ex As Exception
        '                PivotDrillDownDataSource = Nothing
        '            End Try

        '            If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

        '                Try

        '                    If PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Any(Function(PivotDrillDownDataRow) (PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString) <> 0 OrElse _
        '                                                                                                                                               PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString) <> 0 OrElse _
        '                                                                                                                                               PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString) <> 0 OrElse _
        '                                                                                                                                               PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Units.ToString) <> 0 OrElse _
        '                                                                                                                                               PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) <> 0 OrElse _
        '                                                                                                                                               PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) <> "" OrElse _
        '                                                                                                                                               PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString) <> 0 OrElse _
        '                                                                                                                                               PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString) <> 0)) Then

        '                        HasData = True

        '                        Color = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Where(Function(PivotDrillDownDataRow) (PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString) <> 0 OrElse _
        '                                                                                                                                                          PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString) <> 0 OrElse _
        '                                                                                                                                                          PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString) <> 0 OrElse _
        '                                                                                                                                                          PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Units.ToString) <> 0 OrElse _
        '                                                                                                                                                          PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) <> 0 OrElse _
        '                                                                                                                                                          PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) <> "" OrElse _
        '                                                                                                                                                          PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString) <> 0 OrElse _
        '                                                                                                                                                          PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString) <> 0) AndAlso PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString) <> 0).Select(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString)).Max()

        '                    End If

        '                Catch ex As Exception
        '                    Color = 0
        '                End Try

        '                Try

        '                    If PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Any(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) IsNot Nothing AndAlso PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) <> "") Then

        '                        HasNote = True

        '                    End If

        '                Catch ex As Exception
        '                    HasNote = False
        '                End Try

        '                If Color <> 0 Then

        '                    e.Appearance.BackColor = System.Drawing.Color.FromArgb(Color)

        '                Else

        '                    Try

        '                        MediaPlanEstimate = sender.Tag

        '                    Catch ex As Exception
        '                        MediaPlanEstimate = Nothing
        '                    End Try

        '                    If HasData AndAlso MediaPlanEstimate IsNot Nothing AndAlso MediaPlanEstimate.Color <> 0 Then

        '                        e.Appearance.BackColor = System.Drawing.Color.FromArgb(MediaPlanEstimate.Color)

        '                    Else

        '                        e.Appearance.BackColor = System.Drawing.Color.White

        '                    End If

        '                End If

        '            End If

        '        End If

        '    Catch ex As Exception

        '    End Try

        '    Try

        '        If e.DataField IsNot Nothing Then

        '            If (e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString OrElse _
        '                    e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString OrElse _
        '                    e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString) AndAlso HasNote = False Then

        '                DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).XlsExportNativeFormat = DevExpress.Utils.DefaultBoolean.True
        '                DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).XlsxFormatString = "0.0"

        '            End If

        '        End If

        '    Catch ex As Exception

        '    End Try

        '    If e.DataField IsNot Nothing AndAlso e.DataField.ActualDataType Is GetType(System.Decimal) OrElse _
        '            e.DataField.ActualDataType Is GetType(Nullable(Of System.Decimal)) Then

        '        If DirectCast(e.Value, Nullable(Of Decimal)).GetValueOrDefault(0) = 0 Then

        '            e.Brick.TextValue = Nothing

        '        End If

        '    End If

        '    If e.RowValue IsNot Nothing AndAlso e.RowValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal Then

        '        e.Appearance.BackColor = System.Drawing.Color.FromArgb(155, 200, 230)

        '    ElseIf e.ColumnValue IsNot Nothing AndAlso e.ColumnValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal Then

        '        e.Appearance.BackColor = System.Drawing.Color.FromArgb(155, 200, 230)

        '    End If

        'End Sub
        'Private Sub PivotGridControl_CustomExportCell(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.CustomExportCellEventArgs)

        '    'objects
        '    Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing
        '    Dim Color As Integer = 0
        '    Dim HasData As Boolean = False
        '    Dim ColumnHeadingCount As Integer = 0
        '    Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing
        '    Dim HasNote As Boolean = False

        '    Try

        '        If e.ColumnField IsNot Nothing AndAlso e.RowField IsNot Nothing AndAlso _
        '                DirectCast(sender, DevExpress.XtraPivotGrid.PivotGridControl).GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.ColumnArea).Last Is e.ColumnField AndAlso _
        '                DirectCast(sender, DevExpress.XtraPivotGrid.PivotGridControl).GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.RowArea).Last Is e.RowField Then

        '            Try

        '                PivotDrillDownDataSource = DirectCast(sender, DevExpress.XtraPivotGrid.PivotGridControl).CreateDrillDownDataSource(e.ColumnIndex, e.RowIndex)

        '            Catch ex As Exception
        '                PivotDrillDownDataSource = Nothing
        '            End Try

        '            If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

        '                Try

        '                    If PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Any(Function(PivotDrillDownDataRow) (PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString) <> 0 OrElse _
        '                                                                                                                                               PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString) <> 0 OrElse _
        '                                                                                                                                               PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString) <> 0 OrElse _
        '                                                                                                                                               PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Units.ToString) <> 0 OrElse _
        '                                                                                                                                               PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) <> 0 OrElse _
        '                                                                                                                                               PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) <> "" OrElse _
        '                                                                                                                                               PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString) <> 0 OrElse _
        '                                                                                                                                               PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString) <> 0)) Then

        '                        HasData = True

        '                        Color = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Where(Function(PivotDrillDownDataRow) (PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString) <> 0 OrElse _
        '                                                                                                                                                          PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString) <> 0 OrElse _
        '                                                                                                                                                          PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString) <> 0 OrElse _
        '                                                                                                                                                          PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Units.ToString) <> 0 OrElse _
        '                                                                                                                                                          PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) <> 0 OrElse _
        '                                                                                                                                                          PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) <> "" OrElse _
        '                                                                                                                                                          PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString) <> 0 OrElse _
        '                                                                                                                                                          PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString) <> 0) AndAlso PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString) <> 0).Select(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString)).Max()

        '                    End If

        '                Catch ex As Exception
        '                    Color = 0
        '                End Try

        '                Try

        '                    If PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Any(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) IsNot Nothing AndAlso PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) <> "") Then

        '                        HasNote = True

        '                    End If

        '                Catch ex As Exception
        '                    HasNote = False
        '                End Try

        '                If Color <> 0 Then

        '                    e.Appearance.BackColor = System.Drawing.Color.FromArgb(Color)

        '                Else

        '                    Try

        '                        MediaPlanEstimate = sender.Tag

        '                    Catch ex As Exception
        '                        MediaPlanEstimate = Nothing
        '                    End Try

        '                    If HasData AndAlso MediaPlanEstimate IsNot Nothing AndAlso MediaPlanEstimate.Color <> 0 Then

        '                        e.Appearance.BackColor = System.Drawing.Color.FromArgb(MediaPlanEstimate.Color)

        '                    Else

        '                        e.Appearance.BackColor = System.Drawing.Color.White

        '                    End If

        '                End If

        '            End If

        '        End If

        '    Catch ex As Exception

        '    End Try

        '    Try

        '        If e.DataField IsNot Nothing Then

        '            Try

        '                If _MediaPlan.SyncDetailSettings AndAlso ButtonItemOptions_AddColumnsHeadersToAllEstimates.Checked = False Then

        '                    ColumnHeadingCount = DirectCast(sender, DevExpress.XtraPivotGrid.PivotGridControl).GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.ColumnArea).Where(Function(PGF) PGF.Visible = True).Count - 1

        '                    DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).Location = New System.Drawing.Point(DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).Rect.X, DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).Rect.Y - (62.5 * ColumnHeadingCount))

        '                End If

        '            Catch ex As Exception

        '            End Try

        '            If (e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString OrElse _
        '                    e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString OrElse _
        '                    e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString) AndAlso HasNote = False Then

        '                DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).XlsExportNativeFormat = DevExpress.Utils.DefaultBoolean.True
        '                DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).XlsxFormatString = "0.0"

        '            End If

        '        End If

        '    Catch ex As Exception

        '    End Try

        '    If e.DataField IsNot Nothing AndAlso e.DataField.ActualDataType Is GetType(System.Decimal) OrElse _
        '            e.DataField.ActualDataType Is GetType(Nullable(Of System.Decimal)) Then

        '        If DirectCast(e.Value, Nullable(Of Decimal)).GetValueOrDefault(0) = 0 Then

        '            e.Brick.TextValue = Nothing

        '        End If

        '    End If

        '    If e.RowValue IsNot Nothing AndAlso e.RowValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal Then

        '        e.Appearance.BackColor = System.Drawing.Color.FromArgb(155, 200, 230)

        '    ElseIf e.ColumnValue IsNot Nothing AndAlso e.ColumnValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal Then

        '        e.Appearance.BackColor = System.Drawing.Color.FromArgb(155, 200, 230)

        '    End If

        'End Sub
        'Private Sub PivotGridControl_CustomExportFieldValue(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.CustomExportFieldValueEventArgs)

        '    'objects
        '    Dim ColumnHeadingCount As Integer = 0
        '    Dim NewY As Integer = 0
        '    Dim HasOnlyOneColumnField As Boolean = False

        '    If e.Field IsNot Nothing Then

        '        If e.Field.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea OrElse e.Field.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea Then

        '            If TypeOf e.Brick Is DevExpress.XtraPrinting.PanelBrick Then

        '                DirectCast(e.Brick, DevExpress.XtraPrinting.PanelBrick).IsVisible = False
        '                DirectCast(e.Brick, DevExpress.XtraPrinting.PanelBrick).Printed = False
        '                DirectCast(e.Brick, DevExpress.XtraPrinting.PanelBrick).Size = New System.Drawing.Size(0, 0)

        '            Else

        '                DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).IsVisible = False
        '                DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).Printed = False
        '                DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).Size = New System.Drawing.Size(0, 0)

        '            End If

        '        Else

        '            'Try

        '            '    If _MediaPlan.SyncDetailSettings AndAlso ButtonItemOptions_AddColumnsHeadersToAllEstimates.Checked = False Then

        '            '        ColumnHeadingCount = DirectCast(sender, DevExpress.XtraPivotGrid.PivotGridControl).GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.ColumnArea).Where(Function(PGF) PGF.Visible = True).Count - 1

        '            '    End If

        '            'Catch ex As Exception

        '            'End Try

        '            'If TypeOf e.Brick Is DevExpress.XtraPrinting.PanelBrick Then

        '            '    DirectCast(e.Brick, DevExpress.XtraPrinting.PanelBrick).Location = New System.Drawing.Point(DirectCast(e.Brick, DevExpress.XtraPrinting.PanelBrick).Rect.X, DirectCast(e.Brick, DevExpress.XtraPrinting.PanelBrick).Rect.Y - (62.5 * ColumnHeadingCount))

        '            'Else

        '            '    DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).Location = New System.Drawing.Point(DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).Rect.X, DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).Rect.Y - (62.5 * ColumnHeadingCount))

        '            'End If

        '        End If

        '    Else

        '        If e.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal Then

        '            If TypeOf e.Brick Is DevExpress.XtraPrinting.PanelBrick Then

        '                DirectCast(e.Brick, DevExpress.XtraPrinting.PanelBrick).IsVisible = Not e.IsTopMost
        '                DirectCast(e.Brick, DevExpress.XtraPrinting.PanelBrick).Printed = Not e.IsTopMost

        '                If DirectCast(e.Brick, DevExpress.XtraPrinting.PanelBrick).IsVisible = False Then

        '                    DirectCast(e.Brick, DevExpress.XtraPrinting.PanelBrick).Size = New System.Drawing.Size(0, 0)

        '                Else

        '                    'NewY = DirectCast(e.Brick, DevExpress.XtraPrinting.PanelBrick).Location.Y + (2 * DirectCast(e.Brick, DevExpress.XtraPrinting.PanelBrick).Rect.Height)

        '                    'DirectCast(e.Brick, DevExpress.XtraPrinting.PanelBrick).Location = New System.Drawing.Point(DirectCast(e.Brick, DevExpress.XtraPrinting.PanelBrick).Location.X, NewY)

        '                    '    If DoesPivotGridHaveOnlyOneVisibleDataField(sender) Then

        '                    '        HasOnlyOneColumnField = (CType(sender, DevExpress.XtraPivotGrid.PivotGridControl).GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.ColumnArea).Count = 1)

        '                    '        For Each PGF In CType(sender, DevExpress.XtraPivotGrid.PivotGridControl).GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.DataArea)

        '                    '            If PGF.Visible AndAlso PGF.Options.ShowGrandTotal AndAlso e.DataField.Caption = PGF.Caption Then

        '                    '                'If HasOnlyOneColumnField Then

        '                    '                e.Brick.Text = "Grand Total" & System.Environment.NewLine & PGF.Caption

        '                    '                'Else

        '                    '                '    e.Brick.Text = "Grand Total" & System.Environment.NewLine & System.Environment.NewLine & PGF.Caption

        '                    '                'End If

        '                    '                Exit For

        '                    '            End If

        '                    '        Next

        '                    '    End If

        '                End If

        '            Else

        '                DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).IsVisible = Not e.IsTopMost
        '                DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).Printed = Not e.IsTopMost

        '                If DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).IsVisible = False Then

        '                    DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).Size = New System.Drawing.Size(0, 0)

        '                Else

        '                    'NewY = DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).Location.Y + (2 * DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).Rect.Height)

        '                    'DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).Location = New System.Drawing.Point(DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).Location.X, NewY)

        '                    '    If DoesPivotGridHaveOnlyOneVisibleDataField(sender) Then

        '                    '        HasOnlyOneColumnField = (CType(sender, DevExpress.XtraPivotGrid.PivotGridControl).GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.ColumnArea).Count = 1)

        '                    '        For Each PGF In CType(sender, DevExpress.XtraPivotGrid.PivotGridControl).GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.DataArea)

        '                    '            If PGF.Visible AndAlso PGF.Options.ShowGrandTotal AndAlso e.DataField.Caption = PGF.Caption Then

        '                    '                'If HasOnlyOneColumnField Then

        '                    '                e.Brick.Text = "Grand Total" & System.Environment.NewLine & PGF.Caption

        '                    '                'Else

        '                    '                '    e.Brick.Text = "Grand Total" & System.Environment.NewLine & System.Environment.NewLine & PGF.Caption

        '                    '                'End If

        '                    '                Exit For

        '                    '            End If

        '                    '        Next

        '                    '    End If

        '                End If

        '            End If

        '        End If

        '    End If

        'End Sub
        'Private Sub PivotGridControl_CustomCellDisplayText(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotCellDisplayTextEventArgs)

        '    'objects
        '    Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing
        '    Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing
        '    Dim DisplayText As String = ""
        '    Dim RowIndexes() As Integer = Nothing
        '    Dim EntryDates() As Date = Nothing

        '    Try

        '        If e.ColumnField IsNot Nothing AndAlso e.RowField IsNot Nothing AndAlso e.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value AndAlso e.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value AndAlso _
        '                e.GetColumnFields.Last Is e.ColumnField AndAlso e.GetRowFields.Last Is e.RowField Then

        '            Try

        '                PivotDrillDownDataSource = e.CreateDrillDownDataSource

        '            Catch ex As Exception
        '                PivotDrillDownDataSource = Nothing
        '            End Try

        '            If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

        '                Try

        '                    If PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Any(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) IsNot Nothing AndAlso PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) <> "") Then

        '                        DisplayText = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Where(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) IsNot Nothing AndAlso PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) <> "").Select(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString)).Max()

        '                    End If

        '                Catch ex As Exception
        '                    DisplayText = ""
        '                End Try
        '                'DO NOT CHANGE THIS IF STATEMENT IN ANYWAY
        '                If String.IsNullOrEmpty(DisplayText) = False Then

        '                    e.DisplayText = DisplayText

        '                Else

        '                    Try

        '                        MediaPlanEstimate = sender.Tag

        '                    Catch ex As Exception
        '                        MediaPlanEstimate = Nothing
        '                    End Try

        '                    If MediaPlanEstimate IsNot Nothing AndAlso MediaPlanEstimate.DaysOfWeekType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.OverrideData Then

        '                        Try

        '                            RowIndexes = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Select(Function(PivotDrillDownDataRow) CInt(PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).ToArray

        '                        Catch ex As Exception
        '                            RowIndexes = Nothing
        '                        End Try

        '                        Try

        '                            EntryDates = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Select(Function(PivotDrillDownDataRow) CDate(PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.EntryDate.ToString))).ToArray

        '                        Catch ex As Exception
        '                            EntryDates = Nothing
        '                        End Try

        '                        If RowIndexes IsNot Nothing AndAlso RowIndexes.Count > 0 AndAlso EntryDates IsNot Nothing AndAlso EntryDates.Count > 0 Then

        '                            DisplayText = CreateDayOfWeeks(_MediaPlan.MediaPlanEstimate, RowIndexes, EntryDates)

        '                            If String.IsNullOrWhiteSpace(DisplayText) = False Then

        '                                e.DisplayText = DisplayText

        '                            End If

        '                        End If

        '                    End If

        '                End If

        '            End If

        '        End If

        '        If e.DataField IsNot Nothing AndAlso e.DataField.ActualDataType Is GetType(System.Decimal) OrElse _
        '                e.DataField.ActualDataType Is GetType(Nullable(Of System.Decimal)) Then

        '            If DirectCast(e.Value, Nullable(Of Decimal)).GetValueOrDefault(0) = 0 AndAlso String.IsNullOrWhiteSpace(DisplayText) Then

        '                e.DisplayText = ""

        '            End If

        '        End If

        '    Catch ex As Exception

        '    End Try

        'End Sub
        'Private Sub PivotGridControl_CustomFieldSort(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotGridCustomFieldSortEventArgs)

        '    CustomFieldSort(sender, e)

        'End Sub
        'Private Sub PivotGridControl_CustomGroupInterval(sender As Object, e As DevExpress.XtraPivotGrid.PivotCustomGroupIntervalEventArgs)

        '    'objects
        '    Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing

        '    Try

        '        MediaPlanEstimate = sender.Tag

        '    Catch ex As Exception
        '        MediaPlanEstimate = Nothing
        '    End Try

        '    If MediaPlanEstimate IsNot Nothing Then

        '        CustomGroupInterval(sender, e, MediaPlanEstimate)

        '    End If

        'End Sub
        'Private Sub PivotGridControl_FieldValueDisplayText(sender As Object, e As DevExpress.XtraPivotGrid.PivotFieldDisplayTextEventArgs)

        '    'objects
        '    Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing

        '    Try

        '        MediaPlanEstimate = sender.Tag

        '    Catch ex As Exception
        '        MediaPlanEstimate = Nothing
        '    End Try

        '    If MediaPlanEstimate IsNot Nothing Then

        '        FieldValueDisplayText(sender, e, MediaPlanEstimate)

        '    End If

        'End Sub
        'Private Sub PivotGridControl_CustomUnboundFieldData(sender As Object, e As DevExpress.XtraPivotGrid.CustomFieldDataEventArgs)

        '    'objects
        '    Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing

        '    Try

        '        MediaPlanEstimate = sender.Tag

        '    Catch ex As Exception
        '        MediaPlanEstimate = Nothing
        '    End Try

        '    If MediaPlanEstimate IsNot Nothing Then

        '        CustomUnboundFieldData(sender, e, MediaPlanEstimate)

        '    End If

        'End Sub
        'Private Sub PivotGridControl_CustomDrawFieldValue(sender As Object, e As DevExpress.XtraPivotGrid.PivotCustomDrawFieldValueEventArgs)

        '    'objects
        '    Dim HasOnlyOneColumnField As Boolean = False

        '    If e.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal AndAlso TypeOf sender Is DevExpress.XtraPivotGrid.PivotGridControl Then

        '        If e.Field Is Nothing Then

        '            If DoesPivotGridHaveOnlyOneVisibleDataField(sender) Then

        '                HasOnlyOneColumnField = (CType(sender, DevExpress.XtraPivotGrid.PivotGridControl).GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.ColumnArea).Count = 1)

        '                For Each PGF In CType(sender, DevExpress.XtraPivotGrid.PivotGridControl).GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.DataArea)

        '                    If PGF.Visible AndAlso PGF.Options.ShowGrandTotal Then

        '                        'If HasOnlyOneColumnField Then

        '                        e.Info.Caption = "Grand Total" & System.Environment.NewLine & PGF.Caption

        '                        'Else

        '                        '    e.Info.Caption = "Grand Total" & System.Environment.NewLine & System.Environment.NewLine & PGF.Caption

        '                        'End If

        '                        Exit For

        '                    End If

        '                Next

        '            End If

        '        End If

        '    End If

        'End Sub
        'Private Sub PivotGridControl_CustomExportFieldValueCaptionFix(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.CustomExportFieldValueEventArgs)

        '    'objects
        '    Dim ColumnHeadingCount As Integer = 0
        '    Dim NewY As Integer = 0

        '    If e.Field Is Nothing Then

        '        If e.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal AndAlso e.IsColumn Then

        '            If DoesPivotGridHaveOnlyOneVisibleDataField(sender) Then

        '                For Each PGF In CType(sender, DevExpress.XtraPivotGrid.PivotGridControl).GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.DataArea)

        '                    If PGF.Visible AndAlso PGF.Options.ShowGrandTotal AndAlso e.DataField.Caption = PGF.Caption Then

        '                        e.Brick.Text = " Grand Total" & System.Environment.NewLine & System.Environment.NewLine & " " & PGF.Caption
        '                        Exit For

        '                    End If

        '                Next

        '            End If

        '        End If

        '    End If

        'End Sub
        'Private Sub CreateOutput(ByVal CompositeLink As DevExpress.XtraPrintingLinks.CompositeLink, ByVal PrintingSystem As DevExpress.XtraPrinting.PrintingSystem, _
        '                         ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate, ByRef FirstPivotGrid As Boolean, ByVal ShowHiatusDates As Boolean, ByVal AddRowHeadersToAllEstimates As Boolean)

        '    'objects
        '    Dim PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl = Nothing
        '    Dim PrintableComponentLink As DevExpress.XtraPrinting.PrintableComponentLink = Nothing
        '    Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

        '    PivotGridControl = New AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl

        '    PivotGridControl.Tag = MediaPlanEstimate

        '    AddHandler PivotGridControl.CustomCellDisplayText, AddressOf PivotGridControl_CustomCellDisplayText
        '    AddHandler PivotGridControl.CustomFieldSort, AddressOf PivotGridControl_CustomFieldSort
        '    AddHandler PivotGridControl.CustomGroupInterval, AddressOf PivotGridControl_CustomGroupInterval
        '    AddHandler PivotGridControl.FieldValueDisplayText, AddressOf PivotGridControl_FieldValueDisplayText
        '    AddHandler PivotGridControl.CustomUnboundFieldData, AddressOf PivotGridControl_CustomUnboundFieldData
        '    AddHandler PivotGridControl.CustomExportFieldValue, AddressOf PivotGridControl_CustomExportFieldValueCaptionFix

        '    If FirstPivotGrid Then

        '        AddHandler PivotGridControl.CustomExportCell, AddressOf PivotGridControl_FirstPivotGridCustomExportCell

        '    Else

        '        AddHandler PivotGridControl.CustomExportCell, AddressOf PivotGridControl_CustomExportCell

        '        If _MediaPlan.SyncDetailSettings AndAlso AddRowHeadersToAllEstimates = False Then

        '            AddHandler PivotGridControl.CustomExportFieldValue, AddressOf PivotGridControl_CustomExportFieldValue

        '        End If

        '    End If

        '    PivotGridControl.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        '    PivotGridControl.OptionsCustomization.AllowHideFields = DevExpress.XtraPivotGrid.AllowHideFieldsType.Always
        '    PivotGridControl.OptionsCustomization.AllowPrefilter = False
        '    PivotGridControl.OptionsView.ShowColumnTotals = False
        '    PivotGridControl.OptionsView.ShowFilterHeaders = False
        '    PivotGridControl.OptionsView.ShowFilterSeparatorBar = False
        '    PivotGridControl.OptionsView.ShowGrandTotalsForSingleValues = True
        '    PivotGridControl.OptionsView.ShowRowGrandTotalHeader = False
        '    PivotGridControl.OptionsView.ShowRowGrandTotals = False
        '    PivotGridControl.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False
        '    PivotGridControl.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False
        '    PivotGridControl.OptionsPrint.PrintHeadersOnEveryPage = True
        '    PivotGridControl.OptionsPrint.MergeColumnFieldValues = True

        '    If FirstPivotGrid Then

        '        FirstPivotGrid = False

        '        PivotGridControl.OptionsPrint.PrintRowHeaders = DevExpress.Utils.DefaultBoolean.True

        '    Else

        '        If _MediaPlan.SyncDetailSettings Then

        '            If AddRowHeadersToAllEstimates Then

        '                PivotGridControl.OptionsPrint.PrintRowHeaders = DevExpress.Utils.DefaultBoolean.True

        '            Else

        '                PivotGridControl.OptionsPrint.PrintRowHeaders = DevExpress.Utils.DefaultBoolean.False

        '            End If

        '        Else

        '            PivotGridControl.OptionsPrint.PrintRowHeaders = DevExpress.Utils.DefaultBoolean.True

        '        End If

        '    End If

        '    PivotGridControl.BeginUpdate()

        '    SetTotalsOptionsOnPivotGridControl(PivotGridControl, MediaPlanEstimate)

        '    LoadPivotGrid(PivotGridControl, _MediaPlan.DbContext, MediaPlanEstimate)

        '    SetExpandedValuesForPivotGrid(PivotGridControl, MediaPlanEstimate)
        '    LoadCalculatedFieldsToPivotGrid(PivotGridControl, MediaPlanEstimate)
        '    AddDaysOfWeekField(PivotGridControl, MediaPlanEstimate)

        '    If ShowHiatusDates = False Then

        '        Try

        '            PivotGridField = PivotGridControl.Fields(AdvantageFramework.MediaPlanning.DataColumns.Week.ToString)

        '        Catch ex As Exception
        '            PivotGridField = Nothing
        '        End Try

        '        If PivotGridField IsNot Nothing Then

        '            For Each HiatusDate In MediaPlanEstimate.HiatusWeeks.ToList

        '                PivotGridField.FilterValues.Add(HiatusDate)

        '            Next

        '        End If

        '        Try

        '            PivotGridField = PivotGridControl.Fields(AdvantageFramework.MediaPlanning.DataColumns.Month.ToString)

        '        Catch ex As Exception
        '            PivotGridField = Nothing
        '        End Try

        '        If PivotGridField IsNot Nothing Then

        '            For Each HiatusDate In MediaPlanEstimate.HiatusMonths.ToList

        '                PivotGridField.FilterValues.Add(HiatusDate)

        '            Next

        '        End If

        '        Try

        '            PivotGridField = PivotGridControl.Fields(AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString)

        '        Catch ex As Exception
        '            PivotGridField = Nothing
        '        End Try

        '        If PivotGridField IsNot Nothing Then

        '            For Each HiatusDate In MediaPlanEstimate.HiatusMonths.ToList

        '                PivotGridField.FilterValues.Add(HiatusDate)

        '            Next

        '        End If

        '    End If

        '    PivotGridControl.EndUpdate()

        '    PrintableComponentLink = New DevExpress.XtraPrinting.PrintableComponentLink(PrintingSystem)

        '    PrintableComponentLink.Component = PivotGridControl

        '    CompositeLink.Links.Add(PrintableComponentLink)

        'End Sub
        'Private Sub CustomFieldSort(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotGridCustomFieldSortEventArgs)

        '    If e.Field IsNot Nothing Then

        '        If e.Field.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea Then

        '            e.Handled = True

        '            If e.Value1 <> e.Value2 Then

        '                If e.GetListSourceColumnValue(e.ListSourceRowIndex1, AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) > e.GetListSourceColumnValue(e.ListSourceRowIndex2, AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) Then

        '                    e.Result = 1

        '                ElseIf e.GetListSourceColumnValue(e.ListSourceRowIndex1, AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) < e.GetListSourceColumnValue(e.ListSourceRowIndex2, AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) Then

        '                    e.Result = -1

        '                Else

        '                    e.Result = 0

        '                End If

        '            Else

        '                e.Result = 0

        '            End If

        '        End If

        '    End If

        'End Sub
        'Private Sub CustomGroupInterval(sender As Object, e As DevExpress.XtraPivotGrid.PivotCustomGroupIntervalEventArgs, MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

        '    'objects
        '    Dim EntryDate As Date = Nothing
        '    Dim Year As Integer = 0
        '    Dim Quarter As Integer = 0
        '    Dim Month As Integer = 0

        '    If e.Field.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea Then

        '        Try

        '            EntryDate = e.Value

        '        Catch ex As Exception
        '            EntryDate = Nothing
        '        End Try

        '        If EntryDate <> Nothing Then

        '            If e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString Then

        '                e.GroupValue = New Date(AdvantageFramework.MediaPlanning.GetYearForEstimate(EntryDate, MediaPlanEstimate.IsCalendarMonth, _MediaPlan.BroadcastCalendarWeeks), 1, 1)

        '            ElseIf e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString Then

        '                Quarter = AdvantageFramework.MediaPlanning.GetQuarterForEstimate(EntryDate, MediaPlanEstimate.IsCalendarMonth, _MediaPlan.BroadcastCalendarWeeks, Year)

        '                If Quarter = 1 Then

        '                    e.GroupValue = New Date(Year, 1, 1)

        '                ElseIf Quarter = 2 Then

        '                    e.GroupValue = New Date(Year, 4, 1)

        '                ElseIf Quarter = 3 Then

        '                    e.GroupValue = New Date(Year, 7, 1)

        '                ElseIf Quarter = 4 Then

        '                    e.GroupValue = New Date(Year, 10, 1)

        '                End If

        '            ElseIf e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

        '                Month = AdvantageFramework.MediaPlanning.GetMonthForEstimate(EntryDate, MediaPlanEstimate.IsCalendarMonth, _MediaPlan.BroadcastCalendarWeeks, Year)

        '                e.GroupValue = New Date(Year, Month, 1)

        '            ElseIf e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

        '                e.GroupValue = AdvantageFramework.MediaPlanning.GetWeekDateForEstimate(EntryDate, MediaPlanEstimate.IsCalendarMonth, _MediaPlan.BroadcastCalendarWeeks, MediaPlanEstimate.SplitWeeks)

        '            ElseIf e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Day.ToString Then

        '                e.GroupValue = EntryDate

        '            ElseIf e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Date.ToString Then

        '                e.GroupValue = EntryDate

        '            End If

        '        End If

        '    End If

        'End Sub
        'Private Sub FieldValueDisplayText(sender As Object, e As DevExpress.XtraPivotGrid.PivotFieldDisplayTextEventArgs, MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

        '    'objects
        '    Dim Prefix As String = ""
        '    Dim FirstDate As Date = Nothing
        '    Dim EntryDate As Date = Nothing
        '    Dim MonthValue As Integer = 0
        '    Dim Month As AdvantageFramework.DateUtilities.Months = DateUtilities.Months.January

        '    If e.Field IsNot Nothing AndAlso e.Field.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea Then

        '        Try

        '            EntryDate = e.Value

        '        Catch ex As Exception
        '            EntryDate = Nothing
        '        End Try

        '        If EntryDate <> Nothing AndAlso MediaPlanEstimate IsNot Nothing Then

        '            If e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString Then

        '                e.DisplayText = AdvantageFramework.MediaPlanning.GetYearForEstimate(EntryDate, MediaPlanEstimate.IsCalendarMonth, _MediaPlan.BroadcastCalendarWeeks)

        '            ElseIf e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString Then

        '                If e.Field.Tag Is Nothing Then

        '                    e.Field.Tag = MediaPlanEstimate.QuarterPrefix

        '                End If

        '                e.DisplayText = e.Field.Tag & AdvantageFramework.MediaPlanning.GetQuarterForEstimate(EntryDate, MediaPlanEstimate.IsCalendarMonth, _MediaPlan.BroadcastCalendarWeeks)

        '            ElseIf e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString Then

        '                e.DisplayText = AdvantageFramework.MediaPlanning.GetMonthForEstimate(EntryDate, MediaPlanEstimate.IsCalendarMonth, _MediaPlan.BroadcastCalendarWeeks)

        '            ElseIf e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

        '                MonthValue = AdvantageFramework.MediaPlanning.GetMonthForEstimate(EntryDate, MediaPlanEstimate.IsCalendarMonth, _MediaPlan.BroadcastCalendarWeeks)

        '                If MonthValue > 0 AndAlso MonthValue < 13 Then

        '                    Month = MonthValue

        '                    e.DisplayText = Month.ToString

        '                Else

        '                    e.DisplayText = ""

        '                End If

        '            ElseIf e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

        '                If e.Field.Tag Is Nothing Then

        '                    e.Field.Tag = MediaPlanEstimate.WeekDisplayType

        '                End If

        '                Try

        '                    If e.Field.Tag = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekNumber Then

        '                        e.DisplayText = AdvantageFramework.MediaPlanning.GetWeekForEstimate(EntryDate, MediaPlanEstimate.IsCalendarMonth, _MediaPlan.BroadcastCalendarWeeks)

        '                    Else

        '                        Try

        '                            FirstDate = EntryDate

        '                            If MediaPlanEstimate.IsCalendarMonth Then

        '                                If MediaPlanEstimate.SplitWeeks = False Then

        '                                    Do Until FirstDate.DayOfWeek = DayOfWeek.Sunday

        '                                        FirstDate = FirstDate.AddDays(-1)

        '                                    Loop

        '                                End If

        '                            Else

        '                                Do Until FirstDate.DayOfWeek = DayOfWeek.Monday

        '                                    FirstDate = FirstDate.AddDays(-1)

        '                                Loop

        '                            End If

        '                        Catch ex As Exception
        '                            FirstDate = Nothing
        '                        End Try

        '                        If FirstDate <> Nothing Then

        '                            If e.Field.Tag = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekStartDate Then

        '                                e.DisplayText = Format(FirstDate.Month, "0#") & "/" & Format(FirstDate.Day, "0#")

        '                            ElseIf e.Field.Tag = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekStartDay Then

        '                                e.DisplayText = FirstDate.Day

        '                            Else

        '                                e.DisplayText = e.Value

        '                            End If

        '                        Else

        '                            e.DisplayText = e.Value

        '                        End If

        '                    End If

        '                Catch ex As Exception

        '                End Try

        '            ElseIf e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Day.ToString Then

        '                e.DisplayText = EntryDate.Day

        '            End If

        '        End If

        '    End If

        'End Sub
        Private Function FindRightMostEqualCell(ByVal e As DevExpress.XtraPivotGrid.PivotCustomDrawCellEventArgs, ByVal ColumnCount As Integer, ByVal Note As String) As Integer

            Dim RightMostEqualCellIndex As Integer = 0
            Dim PivotCellEventArgs As DevExpress.XtraPivotGrid.PivotCellEventArgs = Nothing
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing

            RightMostEqualCellIndex = e.ColumnIndex

            For CellIndex As Integer = e.ColumnIndex + 1 To ColumnCount - 1

                PivotCellEventArgs = PivotGridForm_MediaPlanDetail.Cells.GetCellInfo(CellIndex, e.RowIndex)

                Try

                    PivotDrillDownDataSource = PivotCellEventArgs.CreateDrillDownDataSource()

                Catch ex As Exception
                    PivotDrillDownDataSource = Nothing
                End Try

                If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                    If PivotCellEventArgs.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value AndAlso
                                PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Any(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) = Note) = True Then

                        RightMostEqualCellIndex = CellIndex

                    Else

                        Exit For

                    End If

                End If

            Next CellIndex

            FindRightMostEqualCell = RightMostEqualCellIndex

        End Function
        Private Function FindLeftMostEqualCell(ByVal e As DevExpress.XtraPivotGrid.PivotCustomDrawCellEventArgs, ByVal Note As String) As Integer

            Dim LeftMostEqualCellIndex As Integer = 0
            Dim PivotCellEventArgs As DevExpress.XtraPivotGrid.PivotCellEventArgs = Nothing
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing

            LeftMostEqualCellIndex = e.ColumnIndex

            If e.ColumnIndex > PivotGridForm_MediaPlanDetail.Cells.LeftTopCell.X Then

                For CellIndex As Integer = e.ColumnIndex - 1 To PivotGridForm_MediaPlanDetail.Cells.LeftTopCell.X Step -1

                    PivotCellEventArgs = PivotGridForm_MediaPlanDetail.Cells.GetCellInfo(CellIndex, e.RowIndex)

                    Try

                        PivotDrillDownDataSource = PivotCellEventArgs.CreateDrillDownDataSource()

                    Catch ex As Exception
                        PivotDrillDownDataSource = Nothing
                    End Try

                    If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                        If PivotCellEventArgs.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value AndAlso
                                PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Any(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) = Note) = True Then

                            LeftMostEqualCellIndex = CellIndex

                        Else

                            Exit For

                        End If

                    End If

                Next CellIndex

            End If

            FindLeftMostEqualCell = LeftMostEqualCellIndex

        End Function
        Private Function FindRightMostEqualCellForDaysOfWeek(ByVal e As DevExpress.XtraPivotGrid.PivotCustomDrawCellEventArgs, ByVal ColumnCount As Integer, ByVal DaysOfWeek As String) As Integer

            Dim RightMostEqualCellIndex As Integer = 0
            Dim PivotCellEventArgs As DevExpress.XtraPivotGrid.PivotCellEventArgs = Nothing
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing

            RightMostEqualCellIndex = e.ColumnIndex

            For CellIndex As Integer = e.ColumnIndex + 1 To ColumnCount - 1

                PivotCellEventArgs = PivotGridForm_MediaPlanDetail.Cells.GetCellInfo(CellIndex, e.RowIndex)

                If PivotCellEventArgs IsNot Nothing AndAlso PivotCellEventArgs.DisplayText = DaysOfWeek Then

                    RightMostEqualCellIndex = CellIndex

                Else

                    Exit For

                End If

            Next CellIndex

            FindRightMostEqualCellForDaysOfWeek = RightMostEqualCellIndex

        End Function
        Private Function FindLeftMostEqualCellForDaysOfWeek(ByVal e As DevExpress.XtraPivotGrid.PivotCustomDrawCellEventArgs, ByVal DaysOfWeek As String) As Integer

            Dim LeftMostEqualCellIndex As Integer = 0
            Dim PivotCellEventArgs As DevExpress.XtraPivotGrid.PivotCellEventArgs = Nothing

            LeftMostEqualCellIndex = e.ColumnIndex

            If e.ColumnIndex > PivotGridForm_MediaPlanDetail.Cells.LeftTopCell.X Then

                For CellIndex As Integer = e.ColumnIndex - 1 To PivotGridForm_MediaPlanDetail.Cells.LeftTopCell.X Step -1

                    PivotCellEventArgs = PivotGridForm_MediaPlanDetail.Cells.GetCellInfo(CellIndex, e.RowIndex)

                    If PivotCellEventArgs IsNot Nothing AndAlso PivotCellEventArgs.DisplayText = DaysOfWeek Then

                        LeftMostEqualCellIndex = CellIndex

                    Else

                        Exit For

                    End If

                Next CellIndex

            End If

            FindLeftMostEqualCellForDaysOfWeek = LeftMostEqualCellIndex

        End Function
        'Private Sub CustomUnboundFieldData(sender As Object, e As DevExpress.XtraPivotGrid.CustomFieldDataEventArgs, MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

        '    'objects
        '    Dim RowIndex As Integer = -1
        '    Dim DaysOfWeeks As String = ""
        '    Dim EntryDates() As Date = Nothing

        '    If e.Field IsNot Nothing AndAlso e.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.DaysOfWeek.ToString AndAlso MediaPlanEstimate IsNot Nothing Then

        '        Try

        '            RowIndex = CInt(e.GetListSourceColumnValue(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))

        '        Catch ex As Exception
        '            RowIndex = -1
        '        End Try

        '        Try

        '            EntryDates = MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Select(Function(DR) CDate(DR(AdvantageFramework.MediaPlanning.DataColumns.EntryDate.ToString))).Distinct.ToArray

        '        Catch ex As Exception
        '            EntryDates = Nothing
        '        End Try

        '        If RowIndex > -1 AndAlso EntryDates IsNot Nothing Then

        '            e.Value = CreateDayOfWeeks(MediaPlanEstimate, New Integer() {RowIndex}, EntryDates)

        '        End If

        '    End If

        'End Sub
        'Private Function CreateDayOfWeeks(MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate, RowIndexes() As Integer, ByVal Dates() As Date) As String

        '    'objects
        '    Dim DaysOfWeeks As String = ""

        '    If MediaPlanEstimate.IsCalendarMonth Then

        '        If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso Dates.Contains(MPDLLD.EntryDate) = True AndAlso MPDLLD.Sunday = True) Then

        '            DaysOfWeeks &= If(DaysOfWeeks = "", "SU", ",SU")

        '        End If

        '        If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso Dates.Contains(MPDLLD.EntryDate) = True AndAlso MPDLLD.Monday = True) Then

        '            DaysOfWeeks &= If(DaysOfWeeks = "", "M", ",M")

        '        End If

        '        If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso Dates.Contains(MPDLLD.EntryDate) = True AndAlso MPDLLD.Tuesday = True) Then

        '            DaysOfWeeks &= If(DaysOfWeeks = "", "TU", ",TU")

        '        End If

        '        If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso Dates.Contains(MPDLLD.EntryDate) = True AndAlso MPDLLD.Wednesday = True) Then

        '            DaysOfWeeks &= If(DaysOfWeeks = "", "W", ",W")

        '        End If

        '        If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso Dates.Contains(MPDLLD.EntryDate) = True AndAlso MPDLLD.Thursday = True) Then

        '            DaysOfWeeks &= If(DaysOfWeeks = "", "TH", ",TH")

        '        End If

        '        If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso Dates.Contains(MPDLLD.EntryDate) = True AndAlso MPDLLD.Friday = True) Then

        '            DaysOfWeeks &= If(DaysOfWeeks = "", "F", ",F")

        '        End If

        '        If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso Dates.Contains(MPDLLD.EntryDate) = True AndAlso MPDLLD.Saturday = True) Then

        '            DaysOfWeeks &= If(DaysOfWeeks = "", "SA", ",SA")

        '        End If

        '    Else

        '        If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso Dates.Contains(MPDLLD.EntryDate) = True AndAlso MPDLLD.Monday = True) Then

        '            DaysOfWeeks &= If(DaysOfWeeks = "", "M", ",M")

        '        End If

        '        If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso Dates.Contains(MPDLLD.EntryDate) = True AndAlso MPDLLD.Tuesday = True) Then

        '            DaysOfWeeks &= If(DaysOfWeeks = "", "TU", ",TU")

        '        End If

        '        If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso Dates.Contains(MPDLLD.EntryDate) = True AndAlso MPDLLD.Wednesday = True) Then

        '            DaysOfWeeks &= If(DaysOfWeeks = "", "W", ",W")

        '        End If

        '        If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso Dates.Contains(MPDLLD.EntryDate) = True AndAlso MPDLLD.Thursday = True) Then

        '            DaysOfWeeks &= If(DaysOfWeeks = "", "TH", ",TH")

        '        End If

        '        If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso Dates.Contains(MPDLLD.EntryDate) = True AndAlso MPDLLD.Friday = True) Then

        '            DaysOfWeeks &= If(DaysOfWeeks = "", "F", ",F")

        '        End If

        '        If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso Dates.Contains(MPDLLD.EntryDate) = True AndAlso MPDLLD.Saturday = True) Then

        '            DaysOfWeeks &= If(DaysOfWeeks = "", "SA", ",SA")

        '        End If

        '        If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso Dates.Contains(MPDLLD.EntryDate) = True AndAlso MPDLLD.Sunday = True) Then

        '            DaysOfWeeks &= If(DaysOfWeeks = "", "SU", ",SU")

        '        End If

        '    End If

        '    CreateDayOfWeeks = DaysOfWeeks

        'End Function
        Private Function SelectedMediaPlanEstimateHasMediaOrder() As Boolean

            Dim HasMediaOrder As Boolean = True
            Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing

            MediaPlanEstimate = _MediaPlan.MediaPlanEstimates(CInt(ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedIndex + 1))

            If MediaPlanEstimate IsNot Nothing Then

                HasMediaOrder = MediaPlanEstimate.HasMediaOrder

            End If

            SelectedMediaPlanEstimateHasMediaOrder = HasMediaOrder

        End Function
        Private Sub ShowMediaPlanLevelAndLines()

            'objects
            Dim Message As String = Nothing

            If ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1 Then

                If _MediaPlan.SyncDetailSettings AndAlso AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlanOtherThanSelectedEstimateID(Session, _MediaPlan.ID, _MediaPlan.MediaPlanEstimate.ID, Message) Then

                    AdvantageFramework.WinForm.MessageBox.Show(Message)

                Else

                    If _MediaPlan.SyncDetailSettings Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_DTL SET LEVEL_LINE_EDIT_LOCKED_BY = '{0}' WHERE MEDIA_PLAN_DTL_ID = {1}", DbContext.UserCode, _MediaPlan.MediaPlanEstimate.ID))

                        End Using

                        _MediaPlan.MediaPlanEstimate.MediaLevelLinesLocked = True

                    End If

                    _PlanChangedInDialog = False

                    PivotGridForm_MediaPlanDetail.RetrieveFieldsOnLoadDataSource = False

                    PivotGridForm_MediaPlanDetail.DataSource = _MediaPlan.MediaPlanEstimate.EstimateDataTable.Copy

                    AdvantageFramework.Media.Presentation.MediaPlanDetailLevelsAndLinesDialog.ShowFormDialog(_MediaPlan)

                    PivotGridForm_MediaPlanDetail.RetrieveFieldsOnLoadDataSource = True

                    If _PlanChangedInDialog Then

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading
                        Me.ShowWaitForm()

                        PivotGridForm_MediaPlanDetail.BeginUpdate()

                        Try

                            LoadPivotGrid(Me.Session, PivotGridForm_MediaPlanDetail, _MediaPlan.DbContext, _MediaPlan.MediaPlanEstimate)

                        Catch ex As Exception

                        End Try

                        PivotGridForm_MediaPlanDetail.EndUpdate()

                        'AddDaysOfWeekField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                        'ButtonItemDataOptions_ShowPackageLevel.Checked = _MediaPlan.MediaPlanEstimate.ShowPackageName

                        'ShowPackageLevelsField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                        'ButtonItemDataOptions_ShowAdSizes.Checked = _MediaPlan.MediaPlanEstimate.ShowAdSizes

                        'ShowAdSizesField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                        'ButtonItemDataOptions_ShowDateRange.Checked = _MediaPlan.MediaPlanEstimate.ShowDateRange

                        'ShowDateRangeField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                        SetExpandedValuesForPivotGrid(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                        EnableOrDisableEstimateActions()

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                        Me.CloseWaitForm()

                        If _MediaPlan.HasChanged = False Then

                            ButtonItemActions_Save.Enabled = False

                        End If

                    Else

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading
                        Me.ShowWaitForm()

                        PivotGridForm_MediaPlanDetail.BeginUpdate()

                        Try

                            LoadPivotGrid(Me.Session, PivotGridForm_MediaPlanDetail, _MediaPlan.DbContext, _MediaPlan.MediaPlanEstimate)

                        Catch ex As Exception

                        End Try

                        PivotGridForm_MediaPlanDetail.EndUpdate()

                        SetExpandedValuesForPivotGrid(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                        EnableOrDisableEstimateActions()

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                        Me.CloseWaitForm()

                    End If

                End If

            End If

        End Sub
        Private Sub RefreshMediaPlanGrandTotalAmounts()

            'objects
            Dim BillingAmount As Decimal = 0

            LabelForm_GrossBudgetAmount.Text = FormatCurrency(_MediaPlan.GrossBudgetAmount.GetValueOrDefault(0))

            For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)()

                If MediaPlanEstimate.MediaPlanDetailLevelLineDatas IsNot Nothing AndAlso MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Count > 0 Then

                    BillingAmount += MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.BillAmount.GetValueOrDefault(0)).Sum

                End If

            Next

            LabelForm_BillingAmount.Text = FormatCurrency(BillingAmount)
            LabelForm_VarianceAmount.Text = FormatCurrency(_MediaPlan.GrossBudgetAmount.GetValueOrDefault(0) - BillingAmount)

            RefreshEstimateGrandTotalAmounts()

        End Sub
        Private Sub RefreshEstimateGrandTotalAmounts()

            'objects
            Dim BillingAmount As Decimal = 0

            If _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                LabelForm_EstimateGrossBudgetAmount.Text = FormatCurrency(_MediaPlan.MediaPlanEstimate.GrossBudgetAmount)

                BillingAmount = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.BillAmount.GetValueOrDefault(0)).Sum

                LabelForm_EstimateBillingAmount.Text = FormatCurrency(BillingAmount)
                LabelForm_EstimateVarianceAmount.Text = FormatCurrency(_MediaPlan.MediaPlanEstimate.GrossBudgetAmount - BillingAmount)

            End If

        End Sub
        Private Sub EnableOrDisableEstimateActions()

            If _MediaPlan IsNot Nothing Then

                If _MediaPlan.MediaPlanEstimates.Count = 0 Then

                    ButtonItemMediaPlanDetails_Update.Enabled = False
                    ButtonItemMediaPlanDetails_Delete.Enabled = False
                    ButtonItemMediaPlanDetails_Copy.Enabled = False
                    ButtonItemMediaPlanDetails_ViewOrderDetails.Enabled = False
                    ButtonItemMediaPlanDetails_Approve.Visible = False
                    ButtonItemMediaPlanDetails_Unapprove.Visible = False
                    ButtonItemMediaPlanDetails_ChangeLogs.Enabled = False
                    ButtonForm_CalculateQty.Enabled = False
                    ButtonItemDetailLevelsLines_CopyFrom.Enabled = False
                    ButtonItemData_GenerateOrders.Enabled = False
                    ButtonItemData_OrderStatus.Enabled = False

                Else

                    If _MediaPlan.MediaPlanEstimate Is Nothing Then

                        ButtonForm_CalculateQty.Enabled = False
                        ButtonItemDetailLevelsLines_CopyFrom.Enabled = False
                        ButtonItemData_GenerateOrders.Enabled = False
                        ButtonItemData_OrderStatus.Enabled = False

                    Else

                        ButtonForm_CalculateQty.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
                        ButtonItemDataOptions_ShowPackageLevel.Enabled = If(_MediaPlan.MediaPlanEstimate.SalesClassType = "I", True, False) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
                        ButtonItemDataOptions_ShowAdSizes.Enabled = If(_MediaPlan.MediaPlanEstimate.SalesClassType = "I", True, False) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
                        ButtonItemData_OrderStatus.Enabled = True

                        If _MediaPlan.SyncDetailSettings Then

                            ButtonItemDetailLevelsLines_CopyFrom.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

                        Else

                            If _MediaPlan.MediaPlanEstimate.IsLevelAndLinesLoaded = False Then

                                ButtonItemDetailLevelsLines_CopyFrom.Enabled = False

                            Else

                                ButtonItemDetailLevelsLines_CopyFrom.Enabled = Not _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns.OfType(Of System.Data.DataColumn).Where(Function(DC) DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString AndAlso
                                                                                                                                                                                                     DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString AndAlso
                                                                                                                                                                                                     DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString AndAlso
                                                                                                                                                                                                     DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString AndAlso
                                                                                                                                                                                                     DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString AndAlso
                                                                                                                                                                                                     DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString).Any AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

                            End If

                        End If

                        EnableGenerateOrdersButton()

                    End If

                    ButtonItemMediaPlanDetails_Update.Enabled = ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1 AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
                    'ButtonItemMediaPlanDetails_Delete.Enabled = (ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1 AndAlso Not _MediaPlan.IsApproved) AndAlso SelectedMediaPlanEstimateHasMediaOrder() = False
                    'ButtonItemMediaPlanDetails_Copy.Enabled = (ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1 AndAlso Not _MediaPlan.IsApproved)
                    ButtonItemMediaPlanDetails_Delete.Enabled = (ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1) AndAlso SelectedMediaPlanEstimateHasMediaOrder() = False AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
                    ButtonItemMediaPlanDetails_Copy.Enabled = (ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
                    ButtonItemMediaPlanDetails_ViewOrderDetails.Enabled = ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1
                    ButtonItemMediaPlanDetails_Approve.Visible = ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1 AndAlso Not _MediaPlan.GetMediaPlanEstimate(ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue).IsApproved AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
                    ButtonItemMediaPlanDetails_Unapprove.Visible = ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1 AndAlso _MediaPlan.GetMediaPlanEstimate(ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue).IsApproved AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
                    ButtonItemMediaPlanDetails_ChangeLogs.Enabled = ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1 AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

                    _AllowCalendarChange = ((ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1) AndAlso _MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate.HasMediaOrder = False)

                    If ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1 Then

                        ButtonItemMediaPlanDetails_Unapprove.Tooltip = _MediaPlan.GetMediaPlanEstimate(ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue).ApprovalDateUser

                    End If

                End If

            Else

                ButtonItemMediaPlanDetails_Update.Enabled = False
                ButtonItemMediaPlanDetails_Delete.Enabled = False
                ButtonItemMediaPlanDetails_Copy.Enabled = False
                ButtonItemMediaPlanDetails_ViewOrderDetails.Enabled = False
                ButtonItemMediaPlanDetails_Approve.Visible = False
                ButtonItemMediaPlanDetails_Unapprove.Visible = False
                ButtonItemMediaPlanDetails_ChangeLogs.Enabled = False
                ButtonForm_CalculateQty.Enabled = False
                ButtonItemDetailLevelsLines_CopyFrom.Enabled = False
                ButtonItemData_GenerateOrders.Enabled = False
                ButtonItemData_OrderStatus.Enabled = False

            End If

            If Not ButtonItemMediaPlanDetails_Unapprove.Visible Then

                ButtonItemMediaPlanDetails_Unapprove.Tooltip = Nothing

            End If

            If Me.FormShown Then

                RibbonBarOptions_Estimates.ResetCachedContentSize()

                RibbonBarOptions_Estimates.Refresh()

                RibbonBarOptions_Estimates.Width = RibbonBarOptions_Estimates.GetAutoSizeWidth

                RibbonBarOptions_Estimates.Refresh()

            End If

        End Sub
        Private Sub EnableOrDisableMediaMixOptions()

            If _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                ButtonItemMediaMixUpdate_BudgetAddMissing.Visible = _MediaPlan.MediaPlanEstimate.MediaPlanEstimateTemplateID.HasValue AndAlso ({"I"}.Contains(_MediaPlan.MediaPlanEstimate.SalesClassType))
                ButtonItemMediaMixUpdate_LevelsLines.Visible = _MediaPlan.MediaPlanEstimate.MediaPlanEstimateTemplateID.HasValue AndAlso ({"I", "R", "T"}.Contains(_MediaPlan.MediaPlanEstimate.SalesClassType))
                ButtonItemMediaMixUpdate_Budget.Visible = _MediaPlan.MediaPlanEstimate.MediaPlanEstimateTemplateID.HasValue AndAlso ({"I", "R", "T"}.Contains(_MediaPlan.MediaPlanEstimate.SalesClassType))

            Else

                ButtonItemMediaMixUpdate_BudgetAddMissing.Visible = False
                ButtonItemMediaMixUpdate_LevelsLines.Visible = False
                ButtonItemMediaMixUpdate_Budget.Visible = False

            End If

        End Sub
        Private Sub EnableOrDisableActions(ByVal Enable As Boolean)

            'If Enable Then

            '    If _MediaPlan.IsApproved Then

            '        Enable = False

            '    End If

            'End If

            LoadMediaPlanStatus()

            PivotGridForm_MediaPlanDetail.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

            PivotGridForm_MediaPlanDetail.OptionsCustomization.AllowEdit = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

            ButtonItemMediaPlanDetails_Add.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

            ButtonItemDetailLevelsLines_ManageLevelLines.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)


            _AllowCalendarChange = ((ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1) AndAlso _MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate.HasMediaOrder = False AndAlso Enable)

            ButtonItemDateSettings_SplitWeeks.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso Enable AndAlso ButtonItemDateSettings_CalendarMonth.Checked) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
            ButtonItemDateSettings_CopyHiatusSettingsFrom.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

            ButtonItemMediaRates_Gross.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso Enable) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
            ButtonItemMediaRates_Net.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso Enable) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

            ButtonItemTotals_ShowHideColumnTotals.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
            ButtonItemTotals_ShowHideRowTotals.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
            ButtonItemTotals_TotalFields.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
            ButtonItemTotalFields_GrossPercentageInTotals.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
            ButtonItemTotalFields_NetDollars.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
            ButtonItemTotalFields_CPP1.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
            ButtonItemTotalFields_CPP2.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
            ButtonItemTotalFields_CPI.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
            ButtonItemTotalFields_CTR.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
            ButtonItemTotalFields_ConversionRate.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
            ButtonItemTotalFields_TotalDemo1.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
            ButtonItemTotalFields_TotalDemo2.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
            ButtonItemTotalFields_TotalNet.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
            ButtonItemTotalFields_Commission.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

            ButtonItemGridOptions_ShowHideFieldList.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

            'ButtonItemDataOptions_CalculateDollars.Enabled = Enable
            ButtonItemDataOptions_RateCPM.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso Enable) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
            ButtonItemDataArea_RateCPM.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso Enable) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

            If Enable AndAlso _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                EnableDisableShowDaysOfWeek(False)

            Else

                ButtonItemDataOptions_ShowDaysOfWeeks.Enabled = False

            End If

            ButtonItemExport_Estimate.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso Enable) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

            ButtonItemData_Import.Enabled = Enable AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
            ButtonItemData_Export.Enabled = Enable AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
            ButtonItemData_CreateOrders.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

            If _MediaPlan.SyncDetailSettings Then

                ButtonItemOptions_AddColumnsHeadersToAllEstimates.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

            Else

                ButtonItemOptions_AddColumnsHeadersToAllEstimates.Enabled = False
                ButtonItemOptions_AddColumnsHeadersToAllEstimates.Checked = False

            End If

            ButtonForm_CalculateQty.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing) AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

            ButtonItemActions_Update.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
            ButtonItemActions_Approve.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
            ButtonItemActions_Unapprove.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
            ButtonItemActions_Refresh.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

            ButtonItemGridOptions_FreezeLevels.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

            ButtonItemDateSettings_CalendarMonth.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
            ButtonItemDateSettings_BroadcastMonth.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

            ButtonItemDataOptions_ShowDateRange.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

            ButtonItemMediaMix_Update.Enabled = (_MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate.MediaPlanEstimateTemplateID.HasValue)

        End Sub
        'Private Function IsMediaPlanDetailCalendarMonth(ByVal DbContext As AdvantageFramework.Database.DbContext, MediaPlanDetailID As Integer) As Boolean

        '    Dim MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
        '    Dim IsCalendarMonth As Boolean = False

        '    MediaPlanDetail = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanDetailID(DbContext, MediaPlanDetailID)

        '    If MediaPlanDetail IsNot Nothing Then

        '        IsCalendarMonth = MediaPlanDetail.IsCalendarMonth

        '    End If

        '    IsMediaPlanDetailCalendarMonth = IsCalendarMonth

        'End Function
        'Private Sub SetBroadcastMonthYearForDate(ByVal BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek), ByVal MediaPlanningData As AdvantageFramework.Exporting.DataClasses.MediaPlanningData)

        '    Dim MaxWeekDate As Nullable(Of Date) = Nothing
        '    Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

        '    MaxWeekDate = (From Dates In BroadcastCalendarWeeks
        '                   Where Dates.WeekDate <= MediaPlanningData.StartDate
        '                   Select Dates.WeekDate).Max

        '    If MaxWeekDate IsNot Nothing Then

        '        BroadcastCalendarWeek = (From Dates In BroadcastCalendarWeeks
        '                                 Where Dates.WeekDate = MaxWeekDate).SingleOrDefault

        '        If BroadcastCalendarWeek IsNot Nothing Then

        '            MediaPlanningData.Month = BroadcastCalendarWeek.Month
        '            MediaPlanningData.Year = BroadcastCalendarWeek.Year

        '        End If

        '    End If

        'End Sub
        'Private Sub SetBroadcastQuarterYearForDate(ByVal BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek), ByVal MediaPlanningData As AdvantageFramework.Exporting.DataClasses.MediaPlanningData)

        '    Dim MaxWeekDate As Nullable(Of Date) = Nothing
        '    Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

        '    MaxWeekDate = (From Dates In BroadcastCalendarWeeks
        '                   Where Dates.WeekDate <= MediaPlanningData.StartDate
        '                   Select Dates.WeekDate).Max

        '    If MaxWeekDate IsNot Nothing Then

        '        BroadcastCalendarWeek = (From Dates In BroadcastCalendarWeeks
        '                                 Where Dates.WeekDate = MaxWeekDate).SingleOrDefault

        '        If BroadcastCalendarWeek IsNot Nothing Then

        '            Select Case BroadcastCalendarWeek.Month

        '                Case 1, 2, 3

        '                    MediaPlanningData.Quarter = 1

        '                Case 4, 5, 6

        '                    MediaPlanningData.Quarter = 2

        '                Case 7, 8, 9

        '                    MediaPlanningData.Quarter = 3

        '                Case 10, 11, 12

        '                    MediaPlanningData.Quarter = 4

        '            End Select

        '            MediaPlanningData.Year = BroadcastCalendarWeek.Year

        '        End If

        '    End If

        'End Sub
        'Private Sub SetBroadcastWeekYearForDate(ByVal BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek), ByVal MediaPlanningData As AdvantageFramework.Exporting.DataClasses.MediaPlanningData)

        '    Dim MaxWeekDate As Nullable(Of Date) = Nothing
        '    Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

        '    MaxWeekDate = (From Dates In BroadcastCalendarWeeks
        '                   Where Dates.WeekDate <= MediaPlanningData.StartDate
        '                   Select Dates.WeekDate).Max

        '    If MaxWeekDate IsNot Nothing Then

        '        BroadcastCalendarWeek = (From Dates In BroadcastCalendarWeeks
        '                                 Where Dates.WeekDate = MaxWeekDate).SingleOrDefault

        '        If BroadcastCalendarWeek IsNot Nothing Then

        '            MediaPlanningData.Year = BroadcastCalendarWeek.Year

        '        End If

        '    End If

        'End Sub
        'Private Function DoesPivotGridHaveOnlyOneVisibleDataField(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl) As Boolean

        '    'objects
        '    Dim HasOnlyOneVisibleDataField As Boolean = False
        '    Dim Count As Integer = 0

        '    For Each PGF In PivotGridControl.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.DataArea)

        '        If PGF.Visible AndAlso PGF.Options.ShowGrandTotal Then

        '            Count += 1

        '        End If

        '    Next

        '    If Count = 1 Then

        '        HasOnlyOneVisibleDataField = True

        '    End If

        '    DoesPivotGridHaveOnlyOneVisibleDataField = HasOnlyOneVisibleDataField

        'End Function
        Public Sub OpenEstimate(MediaPlanDetailID As Integer)

            ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue = _MediaPlan.GetMediaPlanEstimateByMediaPlanDetailID(MediaPlanDetailID).OrderNumber

        End Sub
        Private Sub SetNote(ByVal Note As String, EntryDatesList As Generic.List(Of Date), RowIndexes As Generic.List(Of Integer))

            'objects
            Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim Color As Integer = 0

            If RowIndexes IsNot Nothing AndAlso EntryDatesList IsNot Nothing Then

                _MediaPlan.MediaPlanEstimate.IsEstimateDataTableSaving = True

                For Each EntryDate In EntryDatesList

                    For Each RowIndex In RowIndexes

                        Try

                            MediaPlanDetailLevelLineData = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.SingleOrDefault(Function(Entity) Entity.RowIndex = RowIndex AndAlso
                                                                                                                                                       Entity.StartDate = EntryDate)

                        Catch ex As Exception
                            MediaPlanDetailLevelLineData = Nothing
                        End Try

                        Try

                            DataRow = _MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) RowIndex = DR(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) AndAlso EntryDate = DR(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString))

                        Catch ex As Exception
                            DataRow = Nothing
                        End Try

                        If DataRow IsNot Nothing AndAlso MediaPlanDetailLevelLineData IsNot Nothing Then

                            Try

                                Color = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) RowIndex = DR(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString)).Select(Function(DR) DR(AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString)).Max

                            Catch ex As Exception
                                Color = 0
                            End Try

                            Try

                                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) = Note

                            Catch ex As Exception
                                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) = Nothing
                            End Try

                            DataRow(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString) = Color

                            MediaPlanDetailLevelLineData.SetPropertyValue(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString, If(Note Is System.DBNull.Value, Nothing, Note))

                            AdvantageFramework.MediaPlanning.FillMediaPlanDetailDataRowData(DataRow, MediaPlanDetailLevelLineData)

                        End If

                    Next

                Next

                _MediaPlan.MediaPlanEstimate.IsEstimateDataTableSaving = False

            End If

        End Sub
        Private Function GetEndDateForRow(RowIndex As Integer) As Date

            'objects
            Dim EndDate As Date = Date.MinValue

            For Each MediaPlanDetailLevel In _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.EndDate)

                For Each MediaPlanDetailLevelLine In MediaPlanDetailLevel.MediaPlanDetailLevelLines.Where(Function(Entity) Entity.RowIndex = RowIndex).ToList

                    Try

                        If MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.SingleOrDefault IsNot Nothing Then

                            EndDate = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.SingleOrDefault.EndDate.GetValueOrDefault(Date.MinValue)

                        End If

                    Catch ex As Exception
                        EndDate = Date.MinValue
                    End Try

                    If EndDate <> Date.MinValue Then

                        Exit For

                    End If

                Next

                If EndDate <> Date.MinValue Then

                    Exit For

                End If

            Next

            GetEndDateForRow = EndDate

        End Function
        Private Function GetStartDateForRow(RowIndex As Integer) As Date

            'objects
            Dim StartDate As Date = Date.MinValue

            For Each MediaPlanDetailLevel In _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.StartDate)

                For Each MediaPlanDetailLevelLine In MediaPlanDetailLevel.MediaPlanDetailLevelLines.Where(Function(Entity) Entity.RowIndex = RowIndex).ToList

                    Try

                        If MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.SingleOrDefault IsNot Nothing Then

                            StartDate = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.SingleOrDefault.StartDate.GetValueOrDefault(Date.MinValue)

                        End If

                    Catch ex As Exception
                        StartDate = Date.MinValue
                    End Try

                    If StartDate <> Date.MinValue Then

                        Exit For

                    End If

                Next

                If StartDate <> Date.MinValue Then

                    Exit For

                End If

            Next

            GetStartDateForRow = StartDate

        End Function
        Private Sub EnableDisableShowDaysOfWeek(IsUpdating As Boolean)

            'objects
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing
            Dim IsEnabled As Boolean = False

            If _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                Try

                    MediaPlanDetailField = _MediaPlan.MediaPlanEstimate.MediaPlanDetailFields.Where(Function(Entity) Entity.Area = 1 AndAlso Entity.IsVisible = True).OrderBy(Function(Entity) Entity.AreaIndex).LastOrDefault

                Catch ex As Exception
                    MediaPlanDetailField = Nothing
                End Try

                If MediaPlanDetailField IsNot Nothing AndAlso MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                    IsEnabled = True

                Else

                    IsEnabled = False

                End If

            Else

                IsEnabled = False

            End If

            If IsUpdating Then

                If _MediaPlan.SyncDetailSettings Then

                    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                        If IsEnabled = False Then

                            MediaPlanEstimate.DaysOfWeekType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.None

                        End If

                        If MediaPlanEstimate Is _MediaPlan.MediaPlanEstimate Then

                            If IsEnabled Then

                                ButtonItemDataOptions_ShowDaysOfWeeks.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

                            Else

                                ButtonItemDataOptions_ShowDaysOfWeeks.Enabled = False

                                ButtonItemShowDaysOfWeek_AsLevel.Checked = False
                                ButtonItemShowDaysOfWeek_OverrideDataWithMerge.Checked = False
                                ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge.Checked = False

                            End If

                        End If

                    Next

                Else

                    If IsEnabled Then

                        ButtonItemDataOptions_ShowDaysOfWeeks.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

                    Else

                        _MediaPlan.MediaPlanEstimate.DaysOfWeekType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.None
                        ButtonItemDataOptions_ShowDaysOfWeeks.Enabled = False

                        ButtonItemShowDaysOfWeek_AsLevel.Checked = False
                        ButtonItemShowDaysOfWeek_OverrideDataWithMerge.Checked = False
                        ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge.Checked = False

                    End If

                End If

            Else

                If IsEnabled Then

                    ButtonItemDataOptions_ShowDaysOfWeeks.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

                Else

                    ButtonItemDataOptions_ShowDaysOfWeeks.Enabled = False

                End If

            End If

            'PivotGridForm_MediaPlanDetail.BeginUpdate()

            'AddDaysOfWeekField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

            'PivotGridForm_MediaPlanDetail.EndUpdate()

        End Sub
        Private Sub EnableGenerateOrdersButton()

            If _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ButtonItemData_GenerateOrders.Enabled = (From Entity In AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineData.LoadByMediaPlanID(DbContext, _MediaPlan.ID)
                                                             Where Entity.MediaPlanDetailID = _MediaPlan.MediaPlanEstimate.ID AndAlso
                                                                   Entity.OrderNumber.HasValue AndAlso
                                                                   Entity.OrderLineNumber.HasValue).Any AndAlso Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

                End Using

            Else

                ButtonItemData_GenerateOrders.Enabled = False

            End If

        End Sub
        Private Sub RefreshEstimate()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading
            Me.ShowWaitForm()

            PivotGridForm_MediaPlanDetail.BeginUpdate()

            Try

                LoadPivotGrid(Me.Session, PivotGridForm_MediaPlanDetail, _MediaPlan.DbContext, _MediaPlan.MediaPlanEstimate)

            Catch ex As Exception

            End Try

            PivotGridForm_MediaPlanDetail.EndUpdate()

            SetExpandedValuesForPivotGrid(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

            EnableOrDisableEstimateActions()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

        End Sub
        Private Sub UpdateInternetEstimateLevelsLinesBudget(MediaPlanEstimateTemplateID As Integer, AddLevelsLines As Boolean, UpdateBudget As Boolean, AddMissingDatesForBudget As Boolean)

            'objects
            Dim Message As String = Nothing
            Dim Datas As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data) = Nothing
            Dim MediaPlanEstimateTemplate As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate = Nothing
            Dim Dollars As Decimal = 0
            Dim BillAmount As Decimal = 0
            Dim FoundTagType As AdvantageFramework.MediaPlanning.TagTypes = Nothing
            Dim FoundMappingType As AdvantageFramework.MediaPlanning.MappingTypes = Nothing
            Dim VendorTagTypeFound As Boolean = False
            Dim VendorColumnName As String = Nothing
            Dim TacticTagTypeFound As Boolean = False
            Dim TacticColumnName As String = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim DataColumn As AdvantageFramework.MediaPlanning.DataColumns = Nothing
            Dim TotalDollars As Decimal = 0
            Dim TotalBillAmount As Decimal = 0
            Dim BudgetedIndexes As Generic.List(Of Integer) = Nothing
            Dim RowIndex As Integer = 0
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim RowIndexFound As Boolean = False
            Dim DataRowList As Generic.List(Of System.Data.DataRow) = Nothing
            Dim BalanceToBudget As Decimal = 0
            Dim SuggestedVendorColumnName As String = Nothing
            Dim SuggestedTacticColumnName As String = Nothing
            Dim InternetTypeTagTypeFound As Boolean = False
            Dim RateDatas As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data) = Nothing

            If _MediaPlan.SyncDetailSettings AndAlso AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlanOtherThanSelectedEstimateID(Session, _MediaPlan.ID, _MediaPlan.MediaPlanEstimate.ID, Message) Then

                AdvantageFramework.WinForm.MessageBox.Show(Message)

            Else

                If CheckMappings(Me.Session, MediaPlanEstimateTemplateID, "I") Then

                    If UpdateBudget Then

                        BudgetedIndexes = New Generic.List(Of Integer)

                    End If

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DbContext.Database.Connection.Open()

                        If _MediaPlan.MediaPlanEstimate.IsLevelAndLinesLoaded = False Then

                            _MediaPlan.MediaPlanEstimate.CreateLevelsAndLinesDataTable()

                        End If

                        If _MediaPlan.MediaPlanEstimate.IsDataLoaded = False Then

                            _MediaPlan.MediaPlanEstimate.CreateEstimateDataTable()

                        End If

                        For Each DC As System.Data.DataColumn In _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns

                            If DC.ExtendedProperties.Contains(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString) Then

                                FoundTagType = DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString)

                                If VendorTagTypeFound = False AndAlso FoundTagType.Equals(AdvantageFramework.MediaPlanning.TagTypes.Vendor) Then

                                    VendorTagTypeFound = True
                                    VendorColumnName = DC.ColumnName

                                ElseIf TacticTagTypeFound = False AndAlso FoundTagType.Equals(AdvantageFramework.MediaPlanning.TagTypes.MediaTactic) Then

                                    TacticTagTypeFound = True
                                    TacticColumnName = DC.ColumnName

                                ElseIf InternetTypeTagTypeFound = False AndAlso FoundTagType.Equals(AdvantageFramework.MediaPlanning.TagTypes.InternetType) Then

                                    InternetTypeTagTypeFound = True

                                ElseIf SuggestedVendorColumnName Is Nothing AndAlso FoundTagType.Equals(AdvantageFramework.MediaPlanning.TagTypes.Default) AndAlso DC.ColumnName = "Suggested Vendor" Then

                                    SuggestedVendorColumnName = DC.ColumnName

                                ElseIf SuggestedTacticColumnName Is Nothing AndAlso FoundTagType.Equals(AdvantageFramework.MediaPlanning.TagTypes.Default) AndAlso DC.ColumnName = "Suggested Tactic" Then

                                    SuggestedTacticColumnName = DC.ColumnName

                                End If

                            End If

                        Next

                        RateDatas = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data)(String.Format("exec advsp_media_type_template_data {0}, 1", MediaPlanEstimateTemplateID)).ToList

                        Datas = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data)(String.Format("exec advsp_media_type_template_data {0}", MediaPlanEstimateTemplateID)).ToList

                        MediaPlanEstimateTemplate = DbContext.MediaPlanEstimateTemplates.Find(MediaPlanEstimateTemplateID)

                        If AddLevelsLines AndAlso (Datas IsNot Nothing AndAlso Datas.Any(Function(D) D.MediaPlanEstimateTemplateVendorID.HasValue) OrElse
                                (MediaPlanEstimateTemplate IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateVendors IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateVendors.Count > 0)) Then

                            If VendorTagTypeFound = False Then

                                VendorColumnName = "Vendor"

                                _MediaPlan.AddLevelLineColumn(VendorColumnName, AdvantageFramework.MediaPlanning.TagTypes.Vendor, AdvantageFramework.MediaPlanning.MappingTypes.None)

                            End If

                        End If

                        If AddLevelsLines AndAlso (Datas IsNot Nothing AndAlso Datas.Any(Function(D) D.MediaPlanEstimateTemplateMediaTacticID.HasValue) OrElse
                                (MediaPlanEstimateTemplate IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateTactics IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateTactics.Count > 0)) Then

                            If TacticTagTypeFound = False Then

                                TacticColumnName = "Tactic"

                                _MediaPlan.AddLevelLineColumn(TacticColumnName, AdvantageFramework.MediaPlanning.TagTypes.MediaTactic, AdvantageFramework.MediaPlanning.MappingTypes.MediaTactic)

                            End If

                        End If

                        If AddLevelsLines AndAlso InternetTypeTagTypeFound = False AndAlso RateDatas IsNot Nothing AndAlso RateDatas.Any(Function(RD) RD.ID.HasValue) Then

                            _MediaPlan.AddLevelLineColumn("Internet Type", AdvantageFramework.MediaPlanning.TagTypes.InternetType, AdvantageFramework.MediaPlanning.MappingTypes.InternetType)

                        End If

                        For Each DataDTO In Datas.Where(Function(D) D.PercentageOrRate <> 0).OrderBy(Function(D) D.VendorName)

                            RowIndexFound = False

                            If VendorTagTypeFound AndAlso TacticTagTypeFound AndAlso String.IsNullOrWhiteSpace(VendorColumnName) = False AndAlso String.IsNullOrWhiteSpace(TacticColumnName) = False AndAlso
                                    String.IsNullOrWhiteSpace(DataDTO.VendorCode) = False AndAlso DataDTO.MediaTacticID.HasValue Then

                                For RowIndex = 0 To _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Count - 1

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags IsNot Nothing AndAlso
                                            _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.MediaTactic).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags IsNot Nothing Then

                                        If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) String.IsNullOrWhiteSpace(Entity.VendorCode) = False AndAlso Entity.VendorCode = DataDTO.VendorCode) AndAlso
                                                _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.MediaTactic).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.MediaTacticID.HasValue AndAlso Entity.MediaTacticID = DataDTO.MediaTacticID) Then

                                            RowIndexFound = True
                                            Exit For

                                        End If

                                    End If

                                Next

                            ElseIf VendorTagTypeFound AndAlso String.IsNullOrWhiteSpace(VendorColumnName) = False AndAlso String.IsNullOrWhiteSpace(DataDTO.VendorCode) = False Then

                                For RowIndex = 0 To _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Count - 1

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags IsNot Nothing Then

                                        If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) String.IsNullOrWhiteSpace(Entity.VendorCode) = False AndAlso Entity.VendorCode = DataDTO.VendorCode) Then

                                            RowIndexFound = True
                                            Exit For

                                        End If

                                    End If

                                Next

                            ElseIf TacticTagTypeFound AndAlso String.IsNullOrWhiteSpace(TacticColumnName) = False AndAlso DataDTO.MediaTacticID.HasValue Then

                                For RowIndex = 0 To _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Count - 1

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.MediaTactic).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags IsNot Nothing Then

                                        If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.MediaTactic).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.MediaTacticID.HasValue AndAlso Entity.MediaTacticID = DataDTO.MediaTacticID) Then

                                            RowIndexFound = True
                                            Exit For

                                        End If

                                    End If

                                Next

                            End If

                            If RowIndexFound = False AndAlso SuggestedVendorColumnName IsNot Nothing AndAlso VendorColumnName IsNot Nothing AndAlso
                                    SuggestedTacticColumnName IsNot Nothing AndAlso TacticColumnName IsNot Nothing Then

                                For RowIndex = 0 To _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Count - 1

                                    If _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows(RowIndex).Item(SuggestedVendorColumnName) = DataDTO.SuggestedVendorName AndAlso
                                            _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows(RowIndex).Item(SuggestedTacticColumnName) = DataDTO.SuggestedTacticDescription Then

                                        _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows(RowIndex).Item(VendorColumnName) = DataDTO.VendorName
                                        _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows(RowIndex).Item(TacticColumnName) = DataDTO.TacticDescription
                                        RowIndexFound = True

                                        MediaPlanDetailLevelLine = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Where(Function(Entity) Entity.RowIndex = RowIndex).FirstOrDefault

                                        If MediaPlanDetailLevelLine IsNot Nothing Then

                                            MediaPlanDetailLevelLineTag = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag
                                            MediaPlanDetailLevelLineTag.DbContext = _MediaPlan.DbContext
                                            MediaPlanDetailLevelLineTag.VendorCode = DataDTO.VendorCode

                                            _MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineTag(MediaPlanDetailLevelLine, MediaPlanDetailLevelLineTag)

                                        End If

                                        MediaPlanDetailLevelLine = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.MediaTactic).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Where(Function(Entity) Entity.RowIndex = RowIndex).FirstOrDefault

                                        If MediaPlanDetailLevelLine IsNot Nothing Then

                                            MediaPlanDetailLevelLineTag = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag
                                            MediaPlanDetailLevelLineTag.DbContext = _MediaPlan.DbContext
                                            MediaPlanDetailLevelLineTag.MediaTacticID = DataDTO.MediaTacticID

                                            _MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineTag(MediaPlanDetailLevelLine, MediaPlanDetailLevelLineTag)

                                        End If

                                    End If

                                Next

                            ElseIf RowIndexFound = False AndAlso SuggestedVendorColumnName IsNot Nothing AndAlso VendorColumnName IsNot Nothing Then

                                For RowIndex = 0 To _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Count - 1

                                    If _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows(RowIndex).Item(SuggestedVendorColumnName) = DataDTO.SuggestedVendorName Then

                                        _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows(RowIndex).Item(VendorColumnName) = DataDTO.VendorName
                                        RowIndexFound = True

                                        MediaPlanDetailLevelLine = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Where(Function(Entity) Entity.RowIndex = RowIndex).FirstOrDefault

                                        If MediaPlanDetailLevelLine IsNot Nothing Then

                                            MediaPlanDetailLevelLineTag = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag
                                            MediaPlanDetailLevelLineTag.DbContext = _MediaPlan.DbContext
                                            MediaPlanDetailLevelLineTag.VendorCode = DataDTO.VendorCode

                                            _MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineTag(MediaPlanDetailLevelLine, MediaPlanDetailLevelLineTag)

                                        End If

                                    End If

                                Next

                            ElseIf RowIndexFound = False AndAlso SuggestedTacticColumnName IsNot Nothing AndAlso TacticColumnName IsNot Nothing Then

                                For RowIndex = 0 To _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Count - 1

                                    If _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows(RowIndex).Item(SuggestedTacticColumnName) = DataDTO.SuggestedTacticDescription Then

                                        _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows(RowIndex).Item(TacticColumnName) = DataDTO.TacticDescription
                                        RowIndexFound = True

                                        MediaPlanDetailLevelLine = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.MediaTactic).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Where(Function(Entity) Entity.RowIndex = RowIndex).FirstOrDefault

                                        If MediaPlanDetailLevelLine IsNot Nothing Then

                                            MediaPlanDetailLevelLineTag = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag
                                            MediaPlanDetailLevelLineTag.DbContext = _MediaPlan.DbContext
                                            MediaPlanDetailLevelLineTag.MediaTacticID = DataDTO.MediaTacticID

                                            _MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineTag(MediaPlanDetailLevelLine, MediaPlanDetailLevelLineTag)

                                        End If

                                    End If

                                Next

                            End If

                            If AddLevelsLines AndAlso RowIndexFound = False Then

                                DataRow = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.NewRow

                                If String.IsNullOrWhiteSpace(VendorColumnName) = False AndAlso _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns(VendorColumnName) IsNot Nothing Then

                                    DataRow(VendorColumnName) = DataDTO.VendorName

                                End If

                                If String.IsNullOrWhiteSpace(TacticColumnName) = False AndAlso _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns(TacticColumnName) IsNot Nothing Then

                                    DataRow(TacticColumnName) = DataDTO.TacticDescription

                                End If

                                _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Add(DataRow)
                                RowIndex = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow)

                                If String.IsNullOrWhiteSpace(VendorColumnName) = False AndAlso _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns(VendorColumnName) IsNot Nothing Then

                                    MediaPlanDetailLevelLine = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Where(Function(Entity) Entity.RowIndex = RowIndex).FirstOrDefault

                                    If MediaPlanDetailLevelLine IsNot Nothing Then

                                        MediaPlanDetailLevelLineTag = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag
                                        MediaPlanDetailLevelLineTag.DbContext = _MediaPlan.DbContext
                                        MediaPlanDetailLevelLineTag.VendorCode = DataDTO.VendorCode

                                        _MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineTag(MediaPlanDetailLevelLine, MediaPlanDetailLevelLineTag)

                                    End If

                                End If

                                If String.IsNullOrWhiteSpace(TacticColumnName) = False AndAlso _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns(TacticColumnName) IsNot Nothing Then

                                    MediaPlanDetailLevelLine = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.MediaTactic).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Where(Function(Entity) Entity.RowIndex = RowIndex).FirstOrDefault

                                    If MediaPlanDetailLevelLine IsNot Nothing Then

                                        MediaPlanDetailLevelLineTag = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag
                                        MediaPlanDetailLevelLineTag.DbContext = _MediaPlan.DbContext
                                        MediaPlanDetailLevelLineTag.MediaTacticID = DataDTO.MediaTacticID

                                        _MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineTag(MediaPlanDetailLevelLine, MediaPlanDetailLevelLineTag)

                                    End If

                                End If

                            End If

                            If RowIndexFound AndAlso UpdateBudget Then

                                DataRowList = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Select(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString & "=" & RowIndex).ToList

                                For Each DataRow In DataRowList

                                    If _MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount = False Then

                                        Dollars = Math.Round(_MediaPlan.MediaPlanEstimate.GrossBudgetAmount * DataDTO.PercentageOrRate / 100.0 * 0.85, 2, MidpointRounding.AwayFromZero)
                                        BillAmount = Math.Round(_MediaPlan.MediaPlanEstimate.GrossBudgetAmount * DataDTO.PercentageOrRate / 100.0, 2, MidpointRounding.AwayFromZero)

                                    Else

                                        Dollars = Math.Round(_MediaPlan.MediaPlanEstimate.GrossBudgetAmount * DataDTO.PercentageOrRate / 100.0, 2, MidpointRounding.AwayFromZero)
                                        BillAmount = Dollars

                                    End If

                                    TotalDollars += Dollars
                                    TotalBillAmount += BillAmount

                                    DataColumn = AdvantageFramework.Media.Presentation.GetDataColumnFromPeriodType(_MediaPlan)

                                    BudgetedIndexes.Add(_MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow))

                                    AdvantageFramework.Media.Presentation.AllocateBudget(_MediaPlan, _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow), Dollars, _MediaPlan.StartDate, _MediaPlan.EndDate, DataColumn, False, AddMissingDatesForBudget)

                                    If Datas.Last.Equals(DataDTO) Then

                                        If _MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount = False Then

                                            BalanceToBudget = FormatNumber(Dollars - (TotalDollars - (Math.Round(_MediaPlan.MediaPlanEstimate.GrossBudgetAmount * 0.85, 2, MidpointRounding.AwayFromZero))), 2)

                                            If BalanceToBudget <> 0 Then

                                                AdvantageFramework.Media.Presentation.BalanceBudgetDollars(_MediaPlan, _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow), BalanceToBudget)

                                            End If

                                            'If BillAmount - (TotalBillAmount - _MediaPlan.MediaPlanEstimate.GrossBudgetAmount) <> 0 Then

                                            '    AdvantageFramework.Media.Presentation.BalanceBudgetBillAmount(_MediaPlan, _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow), BillAmount - (TotalBillAmount - _MediaPlan.MediaPlanEstimate.GrossBudgetAmount))

                                            'End If

                                        Else

                                            BalanceToBudget = FormatNumber(Dollars - (TotalDollars - _MediaPlan.MediaPlanEstimate.GrossBudgetAmount), 2)

                                            If BalanceToBudget <> 0 Then

                                                AdvantageFramework.Media.Presentation.BalanceBudgetDollars(_MediaPlan, _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow), BalanceToBudget)

                                                'AdvantageFramework.Media.Presentation.BalanceBudgetBillAmount(_MediaPlan, _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow), BalanceToBudget)

                                            End If

                                        End If

                                    Else

                                        AdvantageFramework.Media.Presentation.BalanceBudgetDollars(_MediaPlan, _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow), Dollars)

                                        'AdvantageFramework.Media.Presentation.BalanceBudgetBillAmount(_MediaPlan, _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow), BillAmount)

                                    End If

                                Next

                            End If

                        Next

                    End Using

                    If UpdateBudget Then

                        For Each DR In _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow)

                            If BudgetedIndexes.Contains(_MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DR)) = False Then

                                For Each DRow In _MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow)

                                    If DR(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) = DRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) Then

                                        DRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString) = 0
                                        DRow(AdvantageFramework.MediaPlanning.DataColumns.BillAmount.ToString) = 0

                                    End If

                                Next

                            End If

                        Next

                    End If

                    RefreshEstimate()

                End If

            End If

        End Sub
        Private Sub UpdateInternetEstimateRate(MediaPlanEstimateTemplateID As Integer)

            'objects
            Dim Message As String = Nothing
            Dim MediaPlanEstimateTemplateDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateData) = Nothing
            Dim FoundTagType As AdvantageFramework.MediaPlanning.TagTypes = Nothing
            Dim InternetTypeTagTypeFound As Boolean = False
            Dim InternetTypeColumnName As String = Nothing
            Dim VendorTagTypeFound As Boolean = False
            Dim VendorColumnName As String = Nothing
            Dim RowIndex As Integer = 0
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim LevelsLinesRowIndex As Integer = 0
            Dim UpdateAllRates As Boolean = False
            Dim DataRow As System.Data.DataRow = Nothing

            If _MediaPlan.SyncDetailSettings AndAlso AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlanOtherThanSelectedEstimateID(Session, _MediaPlan.ID, _MediaPlan.MediaPlanEstimate.ID, Message) Then

                AdvantageFramework.WinForm.MessageBox.Show(Message)

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    If _MediaPlan.MediaPlanEstimate.IsLevelAndLinesLoaded = False Then

                        _MediaPlan.MediaPlanEstimate.CreateLevelsAndLinesDataTable()

                    End If

                    If _MediaPlan.MediaPlanEstimate.IsDataLoaded = False Then

                        _MediaPlan.MediaPlanEstimate.CreateEstimateDataTable()

                    End If

                    For Each DC As System.Data.DataColumn In _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns

                        If DC.ExtendedProperties.Contains(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString) Then

                            FoundTagType = DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString)

                            If InternetTypeTagTypeFound = False AndAlso FoundTagType.Equals(AdvantageFramework.MediaPlanning.TagTypes.InternetType) Then

                                InternetTypeTagTypeFound = True
                                InternetTypeColumnName = DC.ColumnName

                            ElseIf VendorTagTypeFound = False AndAlso FoundTagType.Equals(AdvantageFramework.MediaPlanning.TagTypes.Vendor) Then

                                VendorTagTypeFound = True
                                VendorColumnName = DC.ColumnName

                            End If

                        End If

                    Next

                    If InternetTypeTagTypeFound AndAlso VendorTagTypeFound Then

                        If AdvantageFramework.WinForm.MessageBox.Show("Update all rates or just missing rates?  Click Yes for all rates or No for missing rates only.", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                            UpdateAllRates = True

                        End If

                        Try

                            _MediaPlan.MediaPlanEstimate.PreventAutoCalcOfMediaPlanDetailLevelLineData = True

                            MediaPlanEstimateTemplateDatas = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateData).Include("MediaPlanEstimateTemplateVendor").Include("InternetType")
                                                              Where Entity.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplateID AndAlso
                                                                    Entity.InternetTypeCode IsNot Nothing AndAlso
                                                                    Entity.MediaPlanEstimateTemplateVendor IsNot Nothing
                                                              Select Entity).ToList

                            For Each MediaPlanEstimateTemplateData In MediaPlanEstimateTemplateDatas

                                RowIndexes = New Generic.List(Of Integer)

                                For RowIndex = 0 To _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Count - 1

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.VendorCode = MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateVendor.VendorCode) AndAlso
                                            _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.InternetType).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.InternetTypeCode = MediaPlanEstimateTemplateData.InternetTypeCode) Then

                                        RowIndexes.Add(RowIndex)

                                    End If

                                Next

                                For Each RowIndex In RowIndexes

                                    For Each EntryDate In _MediaPlan.MediaPlanEstimate.GetDatesByPeriodType()

                                        Try

                                            DataRow = _MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) DR(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) = RowIndex AndAlso
                                                                                                                                                                      DR(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString) = EntryDate AndAlso
                                                                                                                                                                      DR(AdvantageFramework.MediaPlanning.DataColumns.MediaPlanDetailLevelLineDataID.ToString) <> 0)

                                        Catch ex As Exception
                                            DataRow = Nothing
                                        End Try

                                        If DataRow IsNot Nothing AndAlso (UpdateAllRates OrElse (IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString)) OrElse
                                                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = 0)) Then

                                            DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = MediaPlanEstimateTemplateData.Rate

                                            If MediaPlanEstimateTemplateData.Rate <> 0 AndAlso IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString)) = False Then

                                                If _MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(DataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString)) OrElse _MediaPlan.MediaPlanEstimate.IsImpressionsCPM Then

                                                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString) = DataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString) * 1000 / MediaPlanEstimateTemplateData.Rate

                                                Else

                                                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString) = DataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString) / MediaPlanEstimateTemplateData.Rate

                                                End If

                                            End If

                                        End If

                                    Next

                                Next

                            Next

                        Catch ex As Exception

                        Finally

                            _MediaPlan.MediaPlanEstimate.PreventAutoCalcOfMediaPlanDetailLevelLineData = False

                        End Try

                        RefreshEstimate()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Rate could not be updated.  Please be sure both Vendor and Internet Type levels are defined.")

                    End If

                End Using

            End If

        End Sub
        Private Sub UpdateMagazineEstimateRate(MediaPlanEstimateTemplateID As Integer)

            'objects
            Dim Message As String = Nothing
            Dim FoundTagType As AdvantageFramework.MediaPlanning.TagTypes = Nothing
            Dim AdSizeTagTypeFound As Boolean = False
            Dim VendorTagTypeFound As Boolean = False
            Dim RowIndexFound As Boolean = False
            Dim RowIndex As Integer = 0
            Dim Datas As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data) = Nothing
            Dim TemplateHasAdSize As Boolean = False
            Dim TemplateHasVendor As Boolean = False
            Dim UpdateAllRates As Boolean = False
            Dim DataRow As System.Data.DataRow = Nothing

            If _MediaPlan.SyncDetailSettings AndAlso AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlanOtherThanSelectedEstimateID(Session, _MediaPlan.ID, _MediaPlan.MediaPlanEstimate.ID, Message) Then

                AdvantageFramework.WinForm.MessageBox.Show(Message)

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    If _MediaPlan.MediaPlanEstimate.IsLevelAndLinesLoaded = False Then

                        _MediaPlan.MediaPlanEstimate.CreateLevelsAndLinesDataTable()

                    End If

                    If _MediaPlan.MediaPlanEstimate.IsDataLoaded = False Then

                        _MediaPlan.MediaPlanEstimate.CreateEstimateDataTable()

                    End If

                    For Each DC As System.Data.DataColumn In _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns

                        If DC.ExtendedProperties.Contains(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString) Then

                            FoundTagType = DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString)

                            If AdSizeTagTypeFound = False AndAlso FoundTagType.Equals(AdvantageFramework.MediaPlanning.TagTypes.AdSize) Then

                                AdSizeTagTypeFound = True

                            ElseIf VendorTagTypeFound = False AndAlso FoundTagType.Equals(AdvantageFramework.MediaPlanning.TagTypes.Vendor) Then

                                VendorTagTypeFound = True

                            End If

                        End If

                    Next

                    Datas = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data)(String.Format("exec advsp_media_type_template_data {0}", MediaPlanEstimateTemplateID)).ToList

                    If Datas.Any(Function(D) D.AdSizeCode IsNot Nothing) Then

                        TemplateHasAdSize = True

                    End If

                    If Datas.Any(Function(D) D.VendorCode IsNot Nothing) Then

                        TemplateHasVendor = True

                    End If

                    If TemplateHasAdSize AndAlso TemplateHasVendor AndAlso (AdSizeTagTypeFound = False OrElse VendorTagTypeFound = False) Then

                        AdvantageFramework.WinForm.MessageBox.Show("Rate could not be updated.  Rates are defined for both vendor and ad size but estimate is missing one or both.")

                    ElseIf TemplateHasAdSize AndAlso AdSizeTagTypeFound = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Rate could not be updated.  Rates are defined for ad size but estimate is missing ad size.")

                    ElseIf TemplateHasVendor AndAlso VendorTagTypeFound = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Rate could not be updated.  Rates are defined for vendor but estimate is missing vendor.")

                    ElseIf TemplateHasAdSize = False AndAlso TemplateHasVendor = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Rates not found for template.")

                    Else

                        If AdvantageFramework.WinForm.MessageBox.Show("Update all rates or just missing rates?  Click Yes for all rates or No for missing rates only.", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                            UpdateAllRates = True

                        End If

                        For Each DataDTO In Datas

                            For RowIndex = 0 To _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Count - 1

                                RowIndexFound = False

                                If AdSizeTagTypeFound AndAlso VendorTagTypeFound Then

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.VendorCode = DataDTO.VendorCode) AndAlso
                                                _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.AdSize).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.SizeCode = DataDTO.AdSizeCode) Then

                                        RowIndexFound = True

                                    End If

                                ElseIf AdSizeTagTypeFound Then

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.AdSize).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.SizeCode = DataDTO.AdSizeCode) Then

                                        RowIndexFound = True

                                    End If

                                ElseIf VendorTagTypeFound Then

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.VendorCode = DataDTO.VendorCode) Then

                                        RowIndexFound = True

                                    End If

                                End If

                                If RowIndexFound Then

                                    For Each EntryDate In _MediaPlan.MediaPlanEstimate.GetDatesByPeriodType()

                                        Try

                                            DataRow = _MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) DR(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) = RowIndex AndAlso
                                                                                                                                                                      DR(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString) = EntryDate AndAlso
                                                                                                                                                                      DR(AdvantageFramework.MediaPlanning.DataColumns.MediaPlanDetailLevelLineDataID.ToString) <> 0)

                                        Catch ex As Exception
                                            DataRow = Nothing
                                        End Try

                                        If DataRow IsNot Nothing AndAlso (UpdateAllRates OrElse IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString))) Then

                                            If String.IsNullOrWhiteSpace(DataDTO.Quarter) = False Then

                                                If DataDTO.Quarter = "Q1" AndAlso {1, 2, 3}.Contains(CDate(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString)).Month) Then

                                                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = DataDTO.PercentageOrRate

                                                ElseIf DataDTO.Quarter = "Q2" AndAlso {4, 5, 6}.Contains(CDate(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString)).Month) Then

                                                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = DataDTO.PercentageOrRate

                                                ElseIf DataDTO.Quarter = "Q3" AndAlso {7, 8, 9}.Contains(CDate(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString)).Month) Then

                                                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = DataDTO.PercentageOrRate

                                                ElseIf DataDTO.Quarter = "Q4" AndAlso {10, 11, 12}.Contains(CDate(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString)).Month) Then

                                                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = DataDTO.PercentageOrRate

                                                End If

                                            Else

                                                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = DataDTO.PercentageOrRate

                                            End If

                                        End If

                                    Next

                                End If

                            Next

                        Next

                        RefreshEstimate()

                    End If

                End Using

            End If

        End Sub
        Private Sub UpdateNewspaperEstimateRate(MediaPlanEstimateTemplateID As Integer)

            'objects
            Dim Message As String = Nothing
            Dim FoundTagType As AdvantageFramework.MediaPlanning.TagTypes = Nothing
            Dim AdSizeTagTypeFound As Boolean = False
            Dim VendorTagTypeFound As Boolean = False
            Dim RowIndexFound As Boolean = False
            Dim RowIndex As Integer = 0
            Dim Datas As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data) = Nothing
            Dim TemplateHasAdSize As Boolean = False
            Dim TemplateHasVendor As Boolean = False
            Dim UpdateAllRates As Boolean = False
            Dim ColumnsVisible As Boolean = False
            Dim InchesLinesVisible As Boolean = False
            Dim UseRateTypeID As Nullable(Of Integer) = Nothing
            Dim Columns As String = AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString
            Dim InchesLines As String = AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString
            Dim DataRow As System.Data.DataRow = Nothing

            If _MediaPlan.SyncDetailSettings AndAlso AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlanOtherThanSelectedEstimateID(Session, _MediaPlan.ID, _MediaPlan.MediaPlanEstimate.ID, Message) Then

                AdvantageFramework.WinForm.MessageBox.Show(Message)

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    If _MediaPlan.MediaPlanEstimate.IsLevelAndLinesLoaded = False Then

                        _MediaPlan.MediaPlanEstimate.CreateLevelsAndLinesDataTable()

                    End If

                    If _MediaPlan.MediaPlanEstimate.IsDataLoaded = False Then

                        _MediaPlan.MediaPlanEstimate.CreateEstimateDataTable()

                    End If

                    For Each DC As System.Data.DataColumn In _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns

                        If DC.ExtendedProperties.Contains(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString) Then

                            FoundTagType = DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString)

                            If AdSizeTagTypeFound = False AndAlso FoundTagType.Equals(AdvantageFramework.MediaPlanning.TagTypes.AdSize) Then

                                AdSizeTagTypeFound = True

                            ElseIf VendorTagTypeFound = False AndAlso FoundTagType.Equals(AdvantageFramework.MediaPlanning.TagTypes.Vendor) Then

                                VendorTagTypeFound = True

                            End If

                        End If

                    Next

                    Datas = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data)(String.Format("exec advsp_media_type_template_data {0}", MediaPlanEstimateTemplateID)).ToList

                    If Datas.Any(Function(D) D.MediaPlanEstimateTemplateRateTypeID.HasValue) Then

                        ColumnsVisible = (From Entity In AdvantageFramework.Database.Procedures.MediaPlanDetailField.LoadByMediaPlanDetailID(DbContext, _MediaPlan.MediaPlanEstimate.ID)
                                          Where Entity.FieldID = Columns AndAlso Entity.IsVisible = True).Any

                        InchesLinesVisible = (From Entity In AdvantageFramework.Database.Procedures.MediaPlanDetailField.LoadByMediaPlanDetailID(DbContext, _MediaPlan.MediaPlanEstimate.ID)
                                              Where Entity.FieldID = InchesLines AndAlso Entity.IsVisible = True).Any

                        If ColumnsVisible AndAlso InchesLinesVisible Then

                            UseRateTypeID = 1

                        ElseIf InchesLinesVisible Then

                            UseRateTypeID = 2

                        Else

                            UseRateTypeID = 3

                        End If

                    End If

                    If Datas.Any(Function(D) D.AdSizeCode IsNot Nothing) Then

                        TemplateHasAdSize = True

                    End If

                    If Datas.Any(Function(D) D.VendorCode IsNot Nothing) Then

                        TemplateHasVendor = True

                    End If

                    If TemplateHasAdSize AndAlso TemplateHasVendor AndAlso (AdSizeTagTypeFound = False OrElse VendorTagTypeFound = False) Then

                        AdvantageFramework.WinForm.MessageBox.Show("Rate could not be updated.  Rates are defined for both vendor and ad size but estimate is missing one or both.")

                    ElseIf TemplateHasAdSize AndAlso AdSizeTagTypeFound = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Rate could not be updated.  Rates are defined for ad size but estimate is missing ad size.")

                    ElseIf TemplateHasVendor AndAlso VendorTagTypeFound = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Rate could not be updated.  Rates are defined for vendor but estimate is missing vendor.")

                    ElseIf TemplateHasAdSize = False AndAlso TemplateHasVendor = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Rates not found for template.")

                    Else

                        If AdvantageFramework.WinForm.MessageBox.Show("Update all rates or just missing rates?  Click Yes for all rates or No for missing rates only.", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                            UpdateAllRates = True

                        End If

                        For Each DataDTO In Datas.Where(Function(D) D.RateTypeID.GetValueOrDefault(0) = UseRateTypeID.GetValueOrDefault(0))

                            For RowIndex = 0 To _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Count - 1

                                RowIndexFound = False

                                If AdSizeTagTypeFound AndAlso VendorTagTypeFound Then

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.VendorCode = DataDTO.VendorCode) AndAlso
                                                _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.AdSize).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.SizeCode = DataDTO.AdSizeCode) Then

                                        RowIndexFound = True

                                    End If

                                ElseIf AdSizeTagTypeFound Then

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.AdSize).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.SizeCode = DataDTO.AdSizeCode) Then

                                        RowIndexFound = True

                                    End If

                                ElseIf VendorTagTypeFound Then

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.VendorCode = DataDTO.VendorCode) Then

                                        RowIndexFound = True

                                    End If

                                End If

                                If RowIndexFound Then

                                    For Each EntryDate In _MediaPlan.MediaPlanEstimate.GetDatesByPeriodType

                                        Try

                                            DataRow = _MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) DR(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) = RowIndex AndAlso
                                                                                                                                                                      DR(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString) = EntryDate AndAlso
                                                                                                                                                                      DR(AdvantageFramework.MediaPlanning.DataColumns.MediaPlanDetailLevelLineDataID.ToString) <> 0)

                                        Catch ex As Exception
                                            DataRow = Nothing
                                        End Try

                                        If DataRow IsNot Nothing AndAlso (UpdateAllRates OrElse IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString))) Then

                                            If String.IsNullOrWhiteSpace(DataDTO.Quarter) = False Then

                                                If DataDTO.Quarter = "Q1" AndAlso {1, 2, 3}.Contains(CDate(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString)).Month) Then

                                                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = DataDTO.PercentageOrRate

                                                ElseIf DataDTO.Quarter = "Q2" AndAlso {4, 5, 6}.Contains(CDate(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString)).Month) Then

                                                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = DataDTO.PercentageOrRate

                                                ElseIf DataDTO.Quarter = "Q3" AndAlso {7, 8, 9}.Contains(CDate(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString)).Month) Then

                                                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = DataDTO.PercentageOrRate

                                                ElseIf DataDTO.Quarter = "Q4" AndAlso {10, 11, 12}.Contains(CDate(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString)).Month) Then

                                                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = DataDTO.PercentageOrRate

                                                End If

                                            Else

                                                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = DataDTO.PercentageOrRate

                                            End If

                                        End If

                                    Next

                                End If

                            Next

                        Next

                        RefreshEstimate()

                    End If

                End Using

            End If

        End Sub
        Private Sub UpdateOutOfHomeEstimateRate(MediaPlanEstimateTemplateID As Integer)

            'objects
            Dim Message As String = Nothing
            Dim FoundTagType As AdvantageFramework.MediaPlanning.TagTypes = Nothing
            Dim OutOfHomeTagTypeFound As Boolean = False
            Dim VendorTagTypeFound As Boolean = False
            Dim RowIndexFound As Boolean = False
            Dim RowIndex As Integer = 0
            Dim Datas As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data) = Nothing
            Dim TemplateHasOutOfHome As Boolean = False
            Dim TemplateHasVendor As Boolean = False
            Dim UpdateAllRates As Boolean = False
            Dim DataRow As System.Data.DataRow = Nothing

            If _MediaPlan.SyncDetailSettings AndAlso AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlanOtherThanSelectedEstimateID(Session, _MediaPlan.ID, _MediaPlan.MediaPlanEstimate.ID, Message) Then

                AdvantageFramework.WinForm.MessageBox.Show(Message)

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    If _MediaPlan.MediaPlanEstimate.IsLevelAndLinesLoaded = False Then

                        _MediaPlan.MediaPlanEstimate.CreateLevelsAndLinesDataTable()

                    End If

                    If _MediaPlan.MediaPlanEstimate.IsDataLoaded = False Then

                        _MediaPlan.MediaPlanEstimate.CreateEstimateDataTable()

                    End If

                    For Each DC As System.Data.DataColumn In _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns

                        If DC.ExtendedProperties.Contains(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString) Then

                            FoundTagType = DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString)

                            If OutOfHomeTagTypeFound = False AndAlso FoundTagType.Equals(AdvantageFramework.MediaPlanning.TagTypes.OutOfHomeType) Then

                                OutOfHomeTagTypeFound = True

                            ElseIf VendorTagTypeFound = False AndAlso FoundTagType.Equals(AdvantageFramework.MediaPlanning.TagTypes.Vendor) Then

                                VendorTagTypeFound = True

                            End If

                        End If

                    Next

                    Datas = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data)(String.Format("exec advsp_media_type_template_data {0}", MediaPlanEstimateTemplateID)).ToList

                    If Datas.Any(Function(D) D.OutOfHomeType IsNot Nothing) Then

                        TemplateHasOutOfHome = True

                    End If

                    If Datas.Any(Function(D) D.VendorCode IsNot Nothing) Then

                        TemplateHasVendor = True

                    End If

                    If TemplateHasOutOfHome AndAlso TemplateHasVendor AndAlso (OutOfHomeTagTypeFound = False OrElse VendorTagTypeFound = False) Then

                        AdvantageFramework.WinForm.MessageBox.Show("Rate could not be updated.  Rates are defined for both vendor and out of home type but estimate is missing one or both.")

                    ElseIf TemplateHasOutOfHome AndAlso OutOfHomeTagTypeFound = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Rate could not be updated.  Rates are defined for out of home type but estimate is missing out of home type.")

                    ElseIf TemplateHasVendor AndAlso VendorTagTypeFound = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Rate could not be updated.  Rates are defined for vendor but estimate is missing vendor.")

                    ElseIf TemplateHasOutOfHome = False AndAlso TemplateHasVendor = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Rates not found for template.")

                    Else

                        If AdvantageFramework.WinForm.MessageBox.Show("Update all rates or just missing rates?  Click Yes for all rates or No for missing rates only.", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                            UpdateAllRates = True

                        End If

                        For Each DataDTO In Datas

                            For RowIndex = 0 To _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Count - 1

                                RowIndexFound = False

                                If OutOfHomeTagTypeFound AndAlso VendorTagTypeFound Then

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.VendorCode = DataDTO.VendorCode) AndAlso
                                            _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.OutOfHomeType).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.OutOfHomeTypeCode = DataDTO.OutOfHomeTypeCode) Then

                                        RowIndexFound = True

                                    End If

                                ElseIf OutOfHomeTagTypeFound Then

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.OutOfHomeType).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.OutOfHomeTypeCode = DataDTO.OutOfHomeTypeCode) Then

                                        RowIndexFound = True

                                    End If

                                ElseIf VendorTagTypeFound Then

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.VendorCode = DataDTO.VendorCode) Then

                                        RowIndexFound = True

                                    End If

                                End If

                                If RowIndexFound Then

                                    'For Each EntryDate In _MediaPlan.MediaPlanEstimate.GetDatesByPeriodType
                                    For Each DataRow In _MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) DR(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) = RowIndex AndAlso
                                                                                                                                                              DR(AdvantageFramework.MediaPlanning.DataColumns.MediaPlanDetailLevelLineDataID) <> 0)

                                        'Try

                                        '    DataRow = _MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) DR(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) = RowIndex AndAlso
                                        '                                                                                                                              DR(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString) = EntryDate AndAlso
                                        '                                                                                                                              DR(AdvantageFramework.MediaPlanning.DataColumns.MediaPlanDetailLevelLineDataID.ToString) <> 0)

                                        'Catch ex As Exception
                                        '    DataRow = Nothing
                                        'End Try

                                        If (UpdateAllRates OrElse IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString))) Then

                                            If String.IsNullOrWhiteSpace(DataDTO.Quarter) = False Then

                                                If DataDTO.Quarter = "Q1" AndAlso {1, 2, 3}.Contains(CDate(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString)).Month) Then

                                                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = DataDTO.PercentageOrRate

                                                ElseIf DataDTO.Quarter = "Q2" AndAlso {4, 5, 6}.Contains(CDate(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString)).Month) Then

                                                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = DataDTO.PercentageOrRate

                                                ElseIf DataDTO.Quarter = "Q3" AndAlso {7, 8, 9}.Contains(CDate(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString)).Month) Then

                                                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = DataDTO.PercentageOrRate

                                                ElseIf DataDTO.Quarter = "Q4" AndAlso {10, 11, 12}.Contains(CDate(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString)).Month) Then

                                                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = DataDTO.PercentageOrRate

                                                End If

                                            Else

                                                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = DataDTO.PercentageOrRate

                                            End If

                                        End If

                                    Next

                                End If

                            Next

                        Next

                        RefreshEstimate()

                    End If

                End Using

            End If

        End Sub
        Private Sub UpdateBroadcastGRPs()

            'objects
            Dim HasMarketLevel As Boolean = False
            Dim HasLengthLevel As Boolean = False
            Dim Datas As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data) = Nothing
            Dim MediaPlanDetailGRPBudgetList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailGRPBudget) = Nothing
            Dim RowIndexFound As Boolean = False
            Dim RowIndex As Integer = 0
            Dim MediaPlanDetailGRPBudget As AdvantageFramework.Database.Entities.MediaPlanDetailGRPBudget = Nothing
            Dim Amount As Decimal = 0
            Dim TotalAmount As Decimal = 0

            'we know we have daypart here
            HasMarketLevel = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(L) L.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Market).Any
            HasLengthLevel = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(L) L.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Length).Any

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Datas = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data)(String.Format("exec advsp_media_type_template_data {0}", _MediaPlan.MediaPlanEstimate.MediaPlanEstimateTemplateID.Value)).ToList

                MediaPlanDetailGRPBudgetList = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanDetailGRPBudget)
                                                Where Entity.MediaPlanDetailID = _MediaPlan.MediaPlanEstimate.ID
                                                Select Entity).ToList

            End Using

            For Each DataDTO In Datas

                RowIndexFound = False

                For RowIndex = 0 To _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Count - 1

                    If HasLengthLevel = False OrElse (HasLengthLevel AndAlso _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows(RowIndex).Item("Length") = DataDTO.SpotLength) Then

                        If HasMarketLevel Then

                            If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Market).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags IsNot Nothing AndAlso
                                    _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Daypart).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags IsNot Nothing Then

                                If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Market).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) String.IsNullOrWhiteSpace(Entity.MarketCode) = False AndAlso Entity.MarketCode = DataDTO.MarketCode) AndAlso
                                        _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Daypart).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.DaypartID.HasValue AndAlso Entity.DaypartID.Value = DataDTO.DaypartID.Value) Then

                                    RowIndexFound = True
                                    Exit For

                                End If

                            End If

                        Else

                            If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Daypart).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags IsNot Nothing Then

                                If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Daypart).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.DaypartID.HasValue AndAlso Entity.DaypartID.Value = DataDTO.DaypartID.Value) Then

                                    RowIndexFound = True
                                    Exit For

                                End If

                            End If

                        End If

                    End If

                Next

                If RowIndexFound Then

                    TotalAmount = 0

                    For Each DataRow In _MediaPlan.MediaPlanEstimate.EstimateDataTable.Select("RowIndex=" & RowIndex)

                        MediaPlanDetailGRPBudget = (From Entity In MediaPlanDetailGRPBudgetList
                                                    Where ((HasMarketLevel AndAlso Entity.MarketCode = DataDTO.MarketCode) OrElse (HasMarketLevel = False)) AndAlso
                                                          ((HasLengthLevel AndAlso Entity.SpotLength = DataDTO.SpotLength) OrElse (HasLengthLevel = False)) AndAlso
                                                          Entity.EntryDate = DataRow("Date")
                                                    Select Entity).SingleOrDefault

                        If MediaPlanDetailGRPBudget IsNot Nothing Then

                            If DataDTO.DaypartPercent.HasValue = False OrElse DataDTO.DaypartPercent.Value = 0 Then

                                Amount = 0

                            Else

                                Amount = Math.Round(MediaPlanDetailGRPBudget.GRPBudget * (DataDTO.DaypartPercent.Value / 100), 2, MidpointRounding.AwayFromZero)

                            End If

                            TotalAmount += Amount

                            'If _MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.IndexOf(DataRow) = _MediaPlan.MediaPlanEstimate.EstimateDataTable.Select("RowIndex=" & RowIndex).Count - 1 Then

                            '    DataRow("Demo1") = MediaPlanDetailGRPBudget.GRPBudget - TotalAmount

                            'Else

                            If Amount <> 0 Then

                                DataRow("Demo1") = Amount

                            End If

                            'End If

                        End If

                    Next

                End If

            Next

            RefreshEstimate()

        End Sub
        Private Sub UpdateBroadcastEstimateRate(MediaPlanEstimateTemplateID As Integer)

            'objects
            Dim Message As String = Nothing
            Dim FoundMappingType As AdvantageFramework.MediaPlanning.MappingTypes = Nothing
            Dim MarketMappingTypeFound As Boolean = False
            Dim DaypartMappingTypeFound As Boolean = False
            Dim LengthMappingTypeFound As Boolean = False
            Dim RowIndexFound As Boolean = False
            Dim RowIndex As Integer = 0
            Dim Datas As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data) = Nothing
            Dim TemplateHasMarket As Boolean = False
            Dim TemplateHasDaypart As Boolean = False
            Dim TemplateHasLength As Boolean = False
            Dim UpdateAllRates As Boolean = False
            Dim DataRow As System.Data.DataRow = Nothing
            Dim DemographicFound As Boolean = False
            Dim TemplateHasDemo As Boolean = False
            Dim BroadcastCalendars As Generic.List(Of AdvantageFramework.DTO.BroadcastCalendar) = Nothing
            Dim BroadcastCalendar As AdvantageFramework.DTO.BroadcastCalendar = Nothing

            If _MediaPlan.SyncDetailSettings AndAlso AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlanOtherThanSelectedEstimateID(Session, _MediaPlan.ID, _MediaPlan.MediaPlanEstimate.ID, Message) Then

                AdvantageFramework.WinForm.MessageBox.Show(Message)

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    BroadcastCalendars = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.BroadcastCalendar)(String.Format("SELECT * FROM dbo.fn_BroadcastCal2('01/01/1996')")).ToList

                    If _MediaPlan.MediaPlanEstimate.IsLevelAndLinesLoaded = False Then

                        _MediaPlan.MediaPlanEstimate.CreateLevelsAndLinesDataTable()

                    End If

                    If _MediaPlan.MediaPlanEstimate.IsDataLoaded = False Then

                        _MediaPlan.MediaPlanEstimate.CreateEstimateDataTable()

                    End If

                    For Each DC As System.Data.DataColumn In _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns

                        If DC.ExtendedProperties.Contains(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.MappingType.ToString) Then

                            FoundMappingType = DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.MappingType.ToString)

                            If MarketMappingTypeFound = False AndAlso FoundMappingType.Equals(AdvantageFramework.MediaPlanning.MappingTypes.Market) Then

                                MarketMappingTypeFound = True

                            ElseIf DaypartMappingTypeFound = False AndAlso FoundMappingType.Equals(AdvantageFramework.MediaPlanning.MappingTypes.Daypart) Then

                                DaypartMappingTypeFound = True

                            ElseIf LengthMappingTypeFound = False AndAlso FoundMappingType.Equals(AdvantageFramework.MediaPlanning.MappingTypes.Length) Then

                                LengthMappingTypeFound = True

                            End If

                        End If

                    Next

                    If _MediaPlan.MediaPlanEstimate.MediaDemographicID.HasValue Then

                        DemographicFound = True

                    End If

                    Datas = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data)(String.Format("exec advsp_media_type_template_data {0}", MediaPlanEstimateTemplateID)).ToList

                    If Datas.Any(Function(D) D.MarketCode IsNot Nothing) Then

                        TemplateHasMarket = True

                    End If

                    If Datas.Any(Function(D) D.Daypart IsNot Nothing) Then

                        TemplateHasDaypart = True

                    End If

                    If Datas.Any(Function(D) D.MediaPlanEstimateTemplateSpotLengthID IsNot Nothing) Then

                        TemplateHasLength = True

                    End If

                    If Datas.Any(Function(D) D.MediaPlanEstimateTemplateDemographicID IsNot Nothing) Then

                        TemplateHasDemo = True

                    End If

                    If TemplateHasMarket AndAlso TemplateHasDaypart AndAlso TemplateHasLength AndAlso TemplateHasDemo AndAlso
                            (MarketMappingTypeFound = False OrElse DaypartMappingTypeFound = False OrElse LengthMappingTypeFound = False OrElse DemographicFound = False) Then

                        AdvantageFramework.WinForm.MessageBox.Show("Rate could not be updated.  Rates are defined for market/daypart/length/demographic but estimate is missing one or more.")

                    ElseIf TemplateHasMarket AndAlso MarketMappingTypeFound = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Rate could not be updated.  Rates are defined for market but estimate is missing market.")

                    ElseIf TemplateHasDaypart AndAlso DaypartMappingTypeFound = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Rate could not be updated.  Rates are defined for daypart but estimate is missing daypart.")

                    ElseIf TemplateHasLength AndAlso LengthMappingTypeFound = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Rate could not be updated.  Rates are defined for length but estimate is missing length.")

                    ElseIf TemplateHasDemo AndAlso DemographicFound = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Rate could not be updated.  Rates are defined for demographic but estimate is missing demographic.")

                    ElseIf TemplateHasDemo = False AndAlso DemographicFound Then

                        AdvantageFramework.WinForm.MessageBox.Show("Rate could not be updated.  Rates are not defined for demographic.")

                    ElseIf TemplateHasMarket = False AndAlso TemplateHasDaypart = False AndAlso TemplateHasLength = False AndAlso TemplateHasDemo = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Rates not found for template.")

                    Else

                        If AdvantageFramework.WinForm.MessageBox.Show("Update all rates or just missing rates?  Click Yes for all rates or No for missing rates only.", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                            UpdateAllRates = True

                        End If

                        Me.ShowWaitForm("Refreshing...")

                        If TemplateHasDemo AndAlso DemographicFound Then

                            Datas = Datas.Where(Function(D) D.MediaDemographicID = _MediaPlan.MediaPlanEstimate.MediaDemographicID).ToList

                            If Datas.Count = 0 Then

                                AdvantageFramework.WinForm.MessageBox.Show("Demographic on estimate does not match template.")

                            End If

                        End If

                        For Each DataDTO In Datas

                            For RowIndex = 0 To _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Count - 1

                                RowIndexFound = False

                                If MarketMappingTypeFound AndAlso DaypartMappingTypeFound AndAlso LengthMappingTypeFound Then

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Market).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.MarketCode = DataDTO.MarketCode) AndAlso
                                            _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Daypart).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.DaypartID.GetValueOrDefault(0) = DataDTO.DaypartID.GetValueOrDefault(0)) AndAlso
                                            _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Length).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.SingleOrDefault(Function(Entity) Entity.RowIndex = RowIndex AndAlso Entity.Description = DataDTO.SpotLength) IsNot Nothing Then

                                        RowIndexFound = True

                                    End If

                                ElseIf MarketMappingTypeFound AndAlso DaypartMappingTypeFound Then

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Market).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.MarketCode = DataDTO.MarketCode) AndAlso
                                            _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Daypart).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.DaypartID.GetValueOrDefault(0) = DataDTO.DaypartID.GetValueOrDefault(0)) Then

                                        RowIndexFound = True

                                    End If

                                ElseIf MarketMappingTypeFound AndAlso LengthMappingTypeFound Then

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Market).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.MarketCode = DataDTO.MarketCode) AndAlso
                                            _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Length).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.SingleOrDefault(Function(Entity) Entity.RowIndex = RowIndex AndAlso Entity.Description = DataDTO.SpotLength) IsNot Nothing Then

                                        RowIndexFound = True

                                    End If

                                ElseIf DaypartMappingTypeFound AndAlso LengthMappingTypeFound Then

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Daypart).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.DaypartID.GetValueOrDefault(0) = DataDTO.DaypartID.GetValueOrDefault(0)) AndAlso
                                            _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Length).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.SingleOrDefault(Function(Entity) Entity.RowIndex = RowIndex AndAlso Entity.Description = DataDTO.SpotLength) IsNot Nothing Then

                                        RowIndexFound = True

                                    End If

                                ElseIf MarketMappingTypeFound Then

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Market).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.MarketCode = DataDTO.MarketCode) Then

                                        RowIndexFound = True

                                    End If

                                ElseIf DaypartMappingTypeFound Then

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Daypart).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.DaypartID.GetValueOrDefault(0) = DataDTO.DaypartID.GetValueOrDefault(0)) Then

                                        RowIndexFound = True

                                    End If

                                ElseIf LengthMappingTypeFound Then

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Length).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.SingleOrDefault(Function(Entity) Entity.RowIndex = RowIndex AndAlso Entity.Description = DataDTO.SpotLength) IsNot Nothing Then

                                        RowIndexFound = True

                                    End If

                                End If

                                If RowIndexFound Then

                                    For Each EntryDate In _MediaPlan.MediaPlanEstimate.GetDatesByPeriodType()

                                        Try

                                            DataRow = _MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) DR(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) = RowIndex AndAlso
                                                                                                                                                                      DR(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString) = EntryDate AndAlso
                                                                                                                                                                      DR(AdvantageFramework.MediaPlanning.DataColumns.MediaPlanDetailLevelLineDataID.ToString) <> 0)

                                        Catch ex As Exception
                                            DataRow = Nothing
                                        End Try

                                        If DataRow IsNot Nothing AndAlso (UpdateAllRates OrElse IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString))) Then

                                            If String.IsNullOrWhiteSpace(DataDTO.Quarter) = False Then

                                                BroadcastCalendar = (From Entity In BroadcastCalendars
                                                                     Where CDate(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString)) >= Entity.BRD_WEEK_START AndAlso
                                                                           CDate(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString)) <= Entity.BRD_WEEK_END
                                                                     Select Entity).SingleOrDefault

                                                If BroadcastCalendar IsNot Nothing Then

                                                    If DataDTO.Quarter = "Q1" AndAlso {1, 2, 3}.Contains(BroadcastCalendar.BRD_MONTH) Then

                                                        DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = DataDTO.PercentageOrRate

                                                    ElseIf DataDTO.Quarter = "Q2" AndAlso {4, 5, 6}.Contains(BroadcastCalendar.BRD_MONTH) Then

                                                        DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = DataDTO.PercentageOrRate

                                                    ElseIf DataDTO.Quarter = "Q3" AndAlso {7, 8, 9}.Contains(BroadcastCalendar.BRD_MONTH) Then

                                                        DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = DataDTO.PercentageOrRate

                                                    ElseIf DataDTO.Quarter = "Q4" AndAlso {10, 11, 12}.Contains(BroadcastCalendar.BRD_MONTH) Then

                                                        DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = DataDTO.PercentageOrRate

                                                    End If

                                                End If

                                            Else

                                                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = DataDTO.PercentageOrRate

                                            End If

                                        End If

                                    Next

                                End If

                            Next

                        Next

                        RefreshEstimate()

                        Me.CloseWaitForm()

                    End If

                End Using

            End If

        End Sub
        Private Function EstimateIsSaved() As Boolean

            Dim ErrorMessage As String = Nothing
            Dim Saved As Boolean = True

            If ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1 Then

                If ButtonItemActions_Save.Enabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes to continue.  Do you want to save your changes now?", WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = WinForm.MessageBox.DialogResults.Yes Then

                        Me.FormAction = WinForm.Presentation.FormActions.Saving
                        Me.ShowWaitForm()
                        Me.ShowWaitForm("Saving...")

                        Saved = SaveChanges(ErrorMessage)

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                        Me.CloseWaitForm()

                        If Saved = False Then

                            AdvantageFramework.WinForm.MessageBox.Show("Failed saving this media plan.  Please contact Software Support." & System.Environment.NewLine & ErrorMessage)

                        End If

                    Else

                        Saved = False

                    End If

                End If

            End If

            EstimateIsSaved = Saved

        End Function
        Private Sub UpdateBroadcastEstimateLevelsLinesBudget(MediaPlanEstimateTemplateID As Integer, AddLevelsLines As Boolean, UpdateBudget As Boolean, AddMissingDatesForBudget As Boolean)

            'objects
            Dim Message As String = Nothing
            Dim Datas As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data) = Nothing
            Dim MediaPlanEstimateTemplate As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate = Nothing
            Dim Dollars As Decimal = 0
            Dim BillAmount As Decimal = 0
            Dim FoundMappingType As AdvantageFramework.MediaPlanning.MappingTypes = Nothing
            Dim MarketMappingTypeFound As Boolean = False
            Dim DaypartMappingTypeFound As Boolean = False
            Dim LengthMappingTypeFound As Boolean = False
            Dim MarketColumnName As String = Nothing
            Dim DaypartColumnName As String = Nothing
            Dim LengthColumnName As String = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim DataColumn As AdvantageFramework.MediaPlanning.DataColumns = Nothing
            Dim TotalDollars As Decimal = 0
            Dim TotalBillAmount As Decimal = 0
            Dim BudgetedIndexes As Generic.List(Of Integer) = Nothing
            Dim RowIndex As Integer = 0
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim RowIndexFound As Boolean = False
            Dim DataRowList As Generic.List(Of System.Data.DataRow) = Nothing
            Dim BalanceToBudget As Decimal = 0
            Dim RateDatas As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data) = Nothing

            If _MediaPlan.SyncDetailSettings AndAlso AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlanOtherThanSelectedEstimateID(Session, _MediaPlan.ID, _MediaPlan.MediaPlanEstimate.ID, Message) Then

                AdvantageFramework.WinForm.MessageBox.Show(Message)

            Else

                If UpdateBudget Then

                    BudgetedIndexes = New Generic.List(Of Integer)

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    If _MediaPlan.MediaPlanEstimate.IsLevelAndLinesLoaded = False Then

                        _MediaPlan.MediaPlanEstimate.CreateLevelsAndLinesDataTable()

                    End If

                    If _MediaPlan.MediaPlanEstimate.IsDataLoaded = False Then

                        _MediaPlan.MediaPlanEstimate.CreateEstimateDataTable()

                    End If

                    For Each DC As System.Data.DataColumn In _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns

                        If DC.ExtendedProperties.Contains(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.MappingType.ToString) Then

                            FoundMappingType = DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.MappingType.ToString)

                            If MarketMappingTypeFound = False AndAlso FoundMappingType.Equals(AdvantageFramework.MediaPlanning.MappingTypes.Market) Then

                                MarketMappingTypeFound = True
                                MarketColumnName = DC.ColumnName

                            ElseIf DaypartMappingTypeFound = False AndAlso FoundMappingType.Equals(AdvantageFramework.MediaPlanning.MappingTypes.Daypart) Then

                                DaypartMappingTypeFound = True
                                DaypartColumnName = DC.ColumnName

                            ElseIf LengthMappingTypeFound = False AndAlso FoundMappingType.Equals(AdvantageFramework.MediaPlanning.MappingTypes.Length) Then

                                LengthMappingTypeFound = True
                                LengthColumnName = DC.ColumnName

                            End If

                        End If

                    Next

                    RateDatas = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data)(String.Format("exec advsp_media_type_template_data {0}, 1", MediaPlanEstimateTemplateID)).ToList

                    Datas = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data)(String.Format("exec advsp_media_type_template_data {0}", MediaPlanEstimateTemplateID)).ToList

                    MediaPlanEstimateTemplate = DbContext.MediaPlanEstimateTemplates.Find(MediaPlanEstimateTemplateID)

                    If AddLevelsLines AndAlso (Datas IsNot Nothing AndAlso Datas.Any(Function(D) D.MediaPlanEstimateTemplateMarketID.HasValue) OrElse
                            (MediaPlanEstimateTemplate IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateMarkets IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateMarkets.Count > 0)) Then

                        If MarketMappingTypeFound = False Then

                            MarketColumnName = "Market"

                            _MediaPlan.AddLevelLineColumn(MarketColumnName, AdvantageFramework.MediaPlanning.TagTypes.Market, AdvantageFramework.MediaPlanning.MappingTypes.Market)

                        End If

                    End If

                    If AddLevelsLines AndAlso (Datas IsNot Nothing AndAlso Datas.Any(Function(D) D.MediaPlanEstimateTemplateSpotLengthID.HasValue) OrElse
                            (MediaPlanEstimateTemplate IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateSpotLengths IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateSpotLengths.Count > 0)) Then

                        If LengthMappingTypeFound = False Then

                            LengthColumnName = "Length"

                            _MediaPlan.AddLevelLineColumn(DaypartColumnName, AdvantageFramework.MediaPlanning.TagTypes.Default, AdvantageFramework.MediaPlanning.MappingTypes.Length)

                        End If

                    End If

                    If AddLevelsLines AndAlso (Datas IsNot Nothing AndAlso Datas.Any(Function(D) D.MediaPlanEstimateTemplateDaypartID.HasValue) OrElse
                            (MediaPlanEstimateTemplate IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateDayparts IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateDayparts.Count > 0)) Then

                        If DaypartMappingTypeFound = False Then

                            DaypartColumnName = "Daypart"

                            _MediaPlan.AddLevelLineColumn(DaypartColumnName, AdvantageFramework.MediaPlanning.TagTypes.Daypart, AdvantageFramework.MediaPlanning.MappingTypes.Daypart)

                        End If

                    End If

                    For Each DataDTO In Datas.Where(Function(D) D.PercentageOrRate <> 0).OrderBy(Function(D) D.Market).ThenBy(Function(D) D.SpotLength).ThenBy(Function(D) D.DaypartDescription)

                        RowIndexFound = False

                        If MarketMappingTypeFound AndAlso DaypartMappingTypeFound AndAlso LengthMappingTypeFound AndAlso String.IsNullOrWhiteSpace(MarketColumnName) = False AndAlso
                                String.IsNullOrWhiteSpace(DaypartColumnName) = False AndAlso String.IsNullOrWhiteSpace(LengthColumnName) = False AndAlso DataDTO.MediaPlanEstimateTemplateMarketID.HasValue AndAlso
                                DataDTO.MediaPlanEstimateTemplateDaypartID.HasValue AndAlso DataDTO.MediaPlanEstimateTemplateSpotLengthID.HasValue Then

                            For RowIndex = 0 To _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Count - 1

                                If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Market).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags IsNot Nothing AndAlso
                                        _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Daypart).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags IsNot Nothing Then

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Market).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.MarketCode = DataDTO.MarketCode) AndAlso
                                            _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Daypart).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.DaypartID.GetValueOrDefault(0) = DataDTO.DaypartID.GetValueOrDefault(0)) AndAlso
                                            _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Length).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.SingleOrDefault(Function(Entity) Entity.RowIndex = RowIndex AndAlso Entity.Description = DataDTO.SpotLength) IsNot Nothing Then

                                        RowIndexFound = True
                                        Exit For

                                    End If

                                End If

                            Next

                        ElseIf MarketMappingTypeFound AndAlso DaypartMappingTypeFound AndAlso String.IsNullOrWhiteSpace(MarketColumnName) = False AndAlso
                                String.IsNullOrWhiteSpace(DaypartColumnName) = False AndAlso DataDTO.MediaPlanEstimateTemplateMarketID.HasValue AndAlso
                                DataDTO.MediaPlanEstimateTemplateDaypartID.HasValue Then

                            For RowIndex = 0 To _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Count - 1

                                If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Market).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags IsNot Nothing AndAlso
                                        _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Daypart).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags IsNot Nothing Then

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Market).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.MarketCode = DataDTO.MarketCode) AndAlso
                                            _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Daypart).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.DaypartID.GetValueOrDefault(0) = DataDTO.DaypartID.GetValueOrDefault(0)) Then

                                        RowIndexFound = True
                                        Exit For

                                    End If

                                End If

                            Next

                        ElseIf MarketMappingTypeFound AndAlso LengthMappingTypeFound AndAlso String.IsNullOrWhiteSpace(MarketColumnName) = False AndAlso
                                String.IsNullOrWhiteSpace(LengthColumnName) = False AndAlso DataDTO.MediaPlanEstimateTemplateMarketID.HasValue AndAlso
                                DataDTO.MediaPlanEstimateTemplateSpotLengthID.HasValue Then

                            For RowIndex = 0 To _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Count - 1

                                If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Market).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags IsNot Nothing Then

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Market).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.MarketCode = DataDTO.MarketCode) AndAlso
                                            _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Length).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.SingleOrDefault(Function(Entity) Entity.RowIndex = RowIndex AndAlso Entity.Description = DataDTO.SpotLength) IsNot Nothing Then

                                        RowIndexFound = True
                                        Exit For

                                    End If

                                End If

                            Next

                        ElseIf DaypartMappingTypeFound AndAlso LengthMappingTypeFound AndAlso
                                String.IsNullOrWhiteSpace(DaypartColumnName) = False AndAlso String.IsNullOrWhiteSpace(LengthColumnName) = False AndAlso
                                DataDTO.MediaPlanEstimateTemplateDaypartID.HasValue AndAlso DataDTO.MediaPlanEstimateTemplateSpotLengthID.HasValue Then

                            For RowIndex = 0 To _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Count - 1

                                If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Daypart).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags IsNot Nothing Then

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Daypart).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.DaypartID.GetValueOrDefault(0) = DataDTO.DaypartID.GetValueOrDefault(0)) AndAlso
                                            _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Length).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.SingleOrDefault(Function(Entity) Entity.RowIndex = RowIndex AndAlso Entity.Description = DataDTO.SpotLength) IsNot Nothing Then

                                        RowIndexFound = True
                                        Exit For

                                    End If

                                End If

                            Next

                        ElseIf MarketMappingTypeFound AndAlso String.IsNullOrWhiteSpace(MarketColumnName) = False AndAlso DataDTO.MediaPlanEstimateTemplateMarketID.HasValue Then

                            For RowIndex = 0 To _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Count - 1

                                If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Market).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags IsNot Nothing Then

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Market).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.MarketCode = DataDTO.MarketCode) Then

                                        RowIndexFound = True
                                        Exit For

                                    End If

                                End If

                            Next

                        ElseIf DaypartMappingTypeFound AndAlso String.IsNullOrWhiteSpace(DaypartColumnName) = False AndAlso DataDTO.MediaPlanEstimateTemplateDaypartID.HasValue Then

                            For RowIndex = 0 To _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Count - 1

                                If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Daypart).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags IsNot Nothing Then

                                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Daypart).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.Single(Function(Entity) Entity.RowIndex = RowIndex).MediaPlanDetailLevelLineTags.Any(Function(Entity) Entity.DaypartID.GetValueOrDefault(0) = DataDTO.DaypartID.GetValueOrDefault(0)) Then

                                        RowIndexFound = True
                                        Exit For

                                    End If

                                End If

                            Next

                        ElseIf LengthMappingTypeFound AndAlso String.IsNullOrWhiteSpace(LengthColumnName) = False AndAlso DataDTO.MediaPlanEstimateTemplateSpotLengthID.HasValue Then

                            For RowIndex = 0 To _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Count - 1

                                If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Length).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).ToList.SingleOrDefault(Function(Entity) Entity.RowIndex = RowIndex AndAlso Entity.Description = DataDTO.SpotLength) IsNot Nothing Then

                                    RowIndexFound = True
                                    Exit For

                                End If

                            Next

                        End If

                        If AddLevelsLines AndAlso RowIndexFound = False Then

                            DataRow = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.NewRow

                            If String.IsNullOrWhiteSpace(MarketColumnName) = False AndAlso _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns(MarketColumnName) IsNot Nothing Then

                                DataRow(MarketColumnName) = DataDTO.Market

                            End If

                            If String.IsNullOrWhiteSpace(DaypartColumnName) = False AndAlso _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns(DaypartColumnName) IsNot Nothing Then

                                DataRow(DaypartColumnName) = DataDTO.DaypartDescription

                            End If

                            If String.IsNullOrWhiteSpace(LengthColumnName) = False AndAlso _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns(LengthColumnName) IsNot Nothing Then

                                DataRow(LengthColumnName) = DataDTO.SpotLength

                            End If

                            _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Add(DataRow)
                            RowIndex = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow)

                            If String.IsNullOrWhiteSpace(MarketColumnName) = False AndAlso _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns(MarketColumnName) IsNot Nothing Then

                                MediaPlanDetailLevelLine = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Market).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Where(Function(Entity) Entity.RowIndex = RowIndex).FirstOrDefault

                                If MediaPlanDetailLevelLine IsNot Nothing Then

                                    MediaPlanDetailLevelLineTag = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag
                                    MediaPlanDetailLevelLineTag.DbContext = _MediaPlan.DbContext
                                    MediaPlanDetailLevelLineTag.MarketCode = DataDTO.MarketCode

                                    _MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineTag(MediaPlanDetailLevelLine, MediaPlanDetailLevelLineTag)

                                End If

                            End If

                            If String.IsNullOrWhiteSpace(DaypartColumnName) = False AndAlso _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns(DaypartColumnName) IsNot Nothing Then

                                MediaPlanDetailLevelLine = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Daypart).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Where(Function(Entity) Entity.RowIndex = RowIndex).FirstOrDefault

                                If MediaPlanDetailLevelLine IsNot Nothing Then

                                    MediaPlanDetailLevelLineTag = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag
                                    MediaPlanDetailLevelLineTag.DbContext = _MediaPlan.DbContext
                                    MediaPlanDetailLevelLineTag.DaypartID = DataDTO.DaypartID

                                    _MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineTag(MediaPlanDetailLevelLine, MediaPlanDetailLevelLineTag)

                                End If

                            End If

                        End If

                        If RowIndexFound AndAlso UpdateBudget Then

                            DataRowList = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Select(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString & "=" & RowIndex).ToList

                            For Each DataRow In DataRowList

                                If _MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount = False Then

                                    Dollars = Math.Round(_MediaPlan.MediaPlanEstimate.GrossBudgetAmount * DataDTO.PercentageOrRate / 100.0 * 0.85, 2, MidpointRounding.AwayFromZero)
                                    BillAmount = Math.Round(_MediaPlan.MediaPlanEstimate.GrossBudgetAmount * DataDTO.PercentageOrRate / 100.0, 2, MidpointRounding.AwayFromZero)

                                Else

                                    Dollars = Math.Round(_MediaPlan.MediaPlanEstimate.GrossBudgetAmount * DataDTO.PercentageOrRate / 100.0, 2, MidpointRounding.AwayFromZero)
                                    BillAmount = Dollars

                                End If

                                TotalDollars += Dollars
                                TotalBillAmount += BillAmount

                                DataColumn = AdvantageFramework.Media.Presentation.GetDataColumnFromPeriodType(_MediaPlan)

                                BudgetedIndexes.Add(_MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow))

                                AdvantageFramework.Media.Presentation.AllocateBudget(_MediaPlan, _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow), Dollars, _MediaPlan.StartDate, _MediaPlan.EndDate, DataColumn, False, AddMissingDatesForBudget)

                                If Datas.Last.Equals(DataDTO) Then

                                    If _MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount = False Then

                                        BalanceToBudget = FormatNumber(Dollars - (TotalDollars - (Math.Round(_MediaPlan.MediaPlanEstimate.GrossBudgetAmount * 0.85, 2, MidpointRounding.AwayFromZero))), 2)

                                        If BalanceToBudget <> 0 Then

                                            AdvantageFramework.Media.Presentation.BalanceBudgetDollars(_MediaPlan, _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow), BalanceToBudget)

                                        End If

                                        'If BillAmount - (TotalBillAmount - _MediaPlan.MediaPlanEstimate.GrossBudgetAmount) <> 0 Then

                                        '    AdvantageFramework.Media.Presentation.BalanceBudgetBillAmount(_MediaPlan, _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow), BillAmount - (TotalBillAmount - _MediaPlan.MediaPlanEstimate.GrossBudgetAmount))

                                        'End If

                                    Else

                                        BalanceToBudget = FormatNumber(Dollars - (TotalDollars - _MediaPlan.MediaPlanEstimate.GrossBudgetAmount), 2)

                                        If BalanceToBudget <> 0 Then

                                            AdvantageFramework.Media.Presentation.BalanceBudgetDollars(_MediaPlan, _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow), BalanceToBudget)

                                            'AdvantageFramework.Media.Presentation.BalanceBudgetBillAmount(_MediaPlan, _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow), BalanceToBudget)

                                        End If

                                    End If

                                Else

                                    AdvantageFramework.Media.Presentation.BalanceBudgetDollars(_MediaPlan, _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow), Dollars)

                                    'AdvantageFramework.Media.Presentation.BalanceBudgetBillAmount(_MediaPlan, _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow), BillAmount)

                                End If

                            Next

                        End If

                    Next

                End Using

                If UpdateBudget Then

                    For Each DR In _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow)

                        If BudgetedIndexes.Contains(_MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DR)) = False Then

                            For Each DRow In _MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow)

                                If DR(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) = DRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) Then

                                    DRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString) = 0
                                    DRow(AdvantageFramework.MediaPlanning.DataColumns.BillAmount.ToString) = 0

                                End If

                            Next

                        End If

                    Next

                End If

                RefreshEstimate()

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm(ByVal MediaPlanID As Integer, Optional ByVal MediaPlanDetailID As Integer = 0)

            'objects
            Dim MediaPlanEditForm As AdvantageFramework.Media.Presentation.MediaPlanEditForm = Nothing

            MediaPlanEditForm = New AdvantageFramework.Media.Presentation.MediaPlanEditForm(MediaPlanID, MediaPlanDetailID)

            MediaPlanEditForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanEditForm_FormClosed(sender As Object, e As Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

            Try

                If _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                    AdvantageFramework.MediaPlanning.ClearEstimateLock(Me.Session, _MediaPlan.MediaPlanEstimate.ID)

                End If

                If _MediaPlan IsNot Nothing Then

                    _MediaPlan.CloseDbContext()

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub MediaPlanEditForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim ButtonItem As DevComponents.DotNetBar.ButtonItem = Nothing
            Dim SwitchButtonItem As DevComponents.DotNetBar.SwitchButtonItem = Nothing

            ButtonItemActions_Save.Image = My.Resources.SaveImage
            ButtonItemActions_Update.Image = My.Resources.UpdateImage
            ButtonItemActions_Approve.Image = My.Resources.ApproveImage
            ButtonItemActions_Unapprove.Image = My.Resources.UnapproveImage
            ButtonItemActions_Refresh.Image = My.Resources.RefreshImage

            ButtonItemMediaPlanDetails_Add.Image = My.Resources.AddImage
            ButtonItemMediaPlanDetails_Update.Image = My.Resources.UpdateImage
            ButtonItemMediaPlanDetails_Delete.Image = My.Resources.DeleteImage
            ButtonItemMediaPlanDetails_Copy.Image = My.Resources.CopyImage
            ButtonItemMediaPlanDetails_ViewOrderDetails.Image = My.Resources.ViewImage
            ButtonItemMediaPlanDetails_Approve.Image = My.Resources.ApproveImage
            ButtonItemMediaPlanDetails_Unapprove.Image = My.Resources.UnapproveImage
            ButtonItemMediaPlanDetails_ChangeLogs.Image = My.Resources.ChangeCodeImage

            ButtonItemMediaMix_Update.Image = AdvantageFramework.My.Resources.UpdateImage

            ButtonItemDetailLevelsLines_CopyFrom.Image = My.Resources.CopyImage
            ButtonItemDetailLevelsLines_ManageLevelLines.Image = My.Resources.EditImage

            ButtonItemDateSettings_BroadcastMonth.Icon = My.Resources.BroadcastCalendarMonthIcon
            ButtonItemDateSettings_CalendarMonth.Icon = My.Resources.CalendarMonthIcon
            ButtonItemDateSettings_SplitWeeks.Image = My.Resources.SplitWeeksImage
            ButtonItemDateSettings_CopyHiatusSettingsFrom.Image = My.Resources.SetHiatusImage

            ButtonItemMediaRates_Gross.Icon = My.Resources.BuyGrossIcon
            ButtonItemMediaRates_Net.Icon = My.Resources.BuyNetIcon

            ButtonItemTotals_ShowHideColumnTotals.Icon = My.Resources.EstimatingIcon
            ButtonItemTotals_ShowHideRowTotals.Icon = My.Resources.EstimatingIcon
            ButtonItemTotals_TotalFields.Icon = My.Resources.TotalFieldsIcon
            ButtonItemTotalFields_GrossPercentageInTotals.Icon = My.Resources.AddTotalColumnIcon

            ButtonItemGridOptions_ShowHideFieldList.Icon = My.Resources.ShowFieldListIcon
            ButtonItemGridOptions_FreezeLevels.Icon = My.Resources.ShowOnlyColumnDescriptionsIcon

            ButtonItemDataArea_AddDataByAllocating.Icon = My.Resources.DateTimeIcon
            ButtonItemDataArea_ChangeDisplayType.Icon = My.Resources.ChangeDisplayTypeIcon
            ButtonItemDataArea_Hide.Icon = My.Resources.HideFieldIcon
            ButtonItemDataArea_SetCaption.Icon = My.Resources.SetCaptionIcon
            ButtonItemDataArea_SetNote.Icon = My.Resources.EditIcon
            ButtonItemDataArea_SetPrefix.Icon = My.Resources.SetPrefixIcon
            ButtonItemDataArea_ShowFieldList.Icon = My.Resources.ShowFieldListIcon
            ButtonItemDataArea_ViewData.Icon = My.Resources.DataViewIcon
            ButtonItemDataArea_SetClearHiatus.Icon = My.Resources.SetHiatusIcon

            'ButtonItemDataOptions_CalculateDollars.Icon = My.Resources.CalculatorIcon
            ButtonItemDataOptions_RateCPM.Image = My.Resources.RateCPMImage
            ButtonItemDataArea_RateCPM.Image = My.Resources.RateCPMImage
            ButtonItemDataOptions_ShowDaysOfWeeks.Image = My.Resources.DaysOfWeekImage
            ButtonItemDataOptions_ShowPackageLevel.Image = My.Resources.RFPPackageImage
            ButtonItemDataOptions_ShowDateRange.Image = My.Resources.DateTimeImage
            ButtonItemDataOptions_ShowAdSizes.Image = My.Resources.AdServerImage

            ButtonItemExport_AllEstimates.Image = AdvantageFramework.My.Resources.PrintFullReportImage
            ButtonItemExport_Estimate.Image = AdvantageFramework.My.Resources.PrintSelectedReportImage

            ButtonItemOptions_ShowHiatusDates.Image = My.Resources.SetHiatusImage
            ButtonItemOptions_AddColumnsHeadersToAllEstimates.Image = My.Resources.ShowAllColumnsImage
            ButtonItemPrintOrder_Change.Image = My.Resources.QuickManageImage

            ButtonItemHeaderFooterImages_Manage.Image = My.Resources.ImagesImage

            ButtonItemExport_FlowChart.Image = AdvantageFramework.My.Resources.PrintFullReportImage

            ButtonItemData_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemData_Import.Image = AdvantageFramework.My.Resources.DatabaseImportImage
            ButtonItemData_CreateOrders.Image = AdvantageFramework.My.Resources.CreateForAllRowsImage
            ButtonItemData_GenerateOrders.Image = AdvantageFramework.My.Resources.MediaAddImage
            ButtonItemData_OrderStatus.Image = AdvantageFramework.My.Resources.IndirectCategoryImage

            ButtonItemActions_Update.Visible = False

            ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.DisplayMember = "MediaPlanDetailIDSalesClassType"
            ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.ValueMember = "ID"

            PivotGridForm_MediaPlanDetail.OptionsData.DataProcessingEngine = DevExpress.XtraPivotGrid.PivotDataProcessingEngine.Legacy
            PivotGridForm_MediaPlanDetail.OptionsData.DirectDataAccessInClientMode = False
            PivotGridForm_MediaPlanDetail.OptionsCustomization.AllowExpandOnDoubleClick = False
            PivotGridForm_MediaPlanDetail.OptionsHint.ShowValueHints = False
            PivotGridForm_MediaPlanDetail.ToolTipController = Me.ToolTipController

            _ImageCollection = New DevExpress.Utils.ImageCollection

            _ImageCollection.AddImage(AdvantageFramework.My.Resources.SmallRedCircleImage)
            _ImageCollection.AddImage(AdvantageFramework.My.Resources.SmallBlueSemiCircleImage)
            _ImageCollection.AddImage(AdvantageFramework.My.Resources.SmallBlueCircleImage)
            _ImageCollection.AddImage(AdvantageFramework.My.Resources.SmallRFPPackageImage)
            _ImageCollection.AddImage(AdvantageFramework.My.Resources.SmallTransparentImage)

            PivotGridForm_MediaPlanDetail.ValueImages = _ImageCollection

            For Each DataColumnName In AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(AdvantageFramework.MediaPlanning.GrossPercentInTotals), False)

                ButtonItem = New DevComponents.DotNetBar.ButtonItem(DataColumnName, AdvantageFramework.StringUtilities.GetNameAsWords(DataColumnName))

                ButtonItem.AutoCheckOnClick = True
                ButtonItem.OptionGroup = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotals.ToString

                AddHandler ButtonItem.CheckedChanged, AddressOf ButtonItemTotals_SubItem_CheckedChanged

                ButtonItemTotalFields_GrossPercentageInTotals.SubItems.Add(ButtonItem)

            Next

            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.MediaPlanning.DataAreaQuantityColumns), False)

                If KeyValuePair.Key <> AdvantageFramework.MediaPlanning.DataAreaQuantityColumns.Columns AndAlso
                        KeyValuePair.Key <> AdvantageFramework.MediaPlanning.DataAreaQuantityColumns.InchesLines Then

                    ButtonItem = New DevComponents.DotNetBar.ButtonItem("QC" & KeyValuePair.Value, AdvantageFramework.StringUtilities.GetNameAsWords(KeyValuePair.Value))

                    ButtonItem.AutoCheckOnClick = True
                    ButtonItem.Tag = KeyValuePair.Key

                    AddHandler ButtonItem.CheckedChanged, AddressOf ButtonItemRateCPM_SubItem_CheckedChanged

                    ButtonItemDataOptions_RateCPM.SubItems.Add(ButtonItem)

                End If

            Next

            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.MediaPlanning.DataAreaQuantityColumns), False)

                ButtonItem = New DevComponents.DotNetBar.ButtonItem("QCD" & KeyValuePair.Value, AdvantageFramework.StringUtilities.GetNameAsWords(KeyValuePair.Value))

                If KeyValuePair.Key = AdvantageFramework.MediaPlanning.DataAreaQuantityColumns.InchesLines Then

                    ButtonItem.Text = "Inches/Lines"

                End If

                ButtonItem.AutoCheckOnClick = True
                ButtonItem.Tag = KeyValuePair.Key

                AddHandler ButtonItem.CheckedChanged, AddressOf ButtonItemRateCPMLevelLine_SubItem_CheckedChanged

                If KeyValuePair.Key <> AdvantageFramework.MediaPlanning.DataAreaQuantityColumns.Columns AndAlso
                        KeyValuePair.Key <> AdvantageFramework.MediaPlanning.DataAreaQuantityColumns.InchesLines Then

                    SwitchButtonItem = New DevComponents.DotNetBar.SwitchButtonItem("QCDCPM" & KeyValuePair.Value, "CPM")

                    AddHandler SwitchButtonItem.ValueChanged, AddressOf ButtonItemRateCPMLevelLineQuantity_SubItem_ValueChanged

                    ButtonItem.SubItems.Add(SwitchButtonItem)

                End If

                ButtonItemDataArea_RateCPM.SubItems.Add(ButtonItem)

            Next

            ButtonItemChangeDisplayType_WeekNumber.Tag = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekNumber
            ButtonItemChangeDisplayType_WeekStartDate.Tag = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekStartDate
            ButtonItemChangeDisplayType_WeekStartDay.Tag = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekStartDay

            AddHandler ButtonItemChangeDisplayType_WeekNumber.Click, AddressOf ButtonItemChangeDisplayType_Click
            AddHandler ButtonItemChangeDisplayType_WeekStartDate.Click, AddressOf ButtonItemChangeDisplayType_Click
            AddHandler ButtonItemChangeDisplayType_WeekStartDay.Click, AddressOf ButtonItemChangeDisplayType_Click

            ButtonItemActions_Approve.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, Security.Methods.Modules.Media_MediaPlanning_Actions_Approval, Me.Session.User)
            ButtonItemActions_Unapprove.SecurityEnabled = ButtonItemActions_Approve.SecurityEnabled
            ButtonItemMediaPlanDetails_Approve.SecurityEnabled = ButtonItemActions_Approve.SecurityEnabled
            ButtonItemMediaPlanDetails_Unapprove.SecurityEnabled = ButtonItemActions_Approve.SecurityEnabled
            ButtonItemData_GenerateOrders.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Media_MediaManager_Actions_GenerateOrders)

        End Sub
        Private Sub MediaPlanEditForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            'objects
            Dim RibbonControl As DevComponents.DotNetBar.RibbonControl = Nothing

            LoadMediaPlan()

            If _MediaPlan IsNot Nothing Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

                LoadMediaPlanEsitmatesForComboBox()

                RefreshMediaPlanGrandTotalAmounts()

                EnableOrDisableEstimateActions()

                EnableOrDisableActions(False)

                If RibbonBarMergeContainerForm_Options.RibbonTabItem IsNot Nothing Then

                    Try

                        RibbonControl = Me.MdiParent.Controls("RibbonControlForm_MainRibbon")

                    Catch ex As Exception
                        RibbonControl = Nothing
                    End Try

                    If RibbonControl IsNot Nothing Then

                        RibbonControl.SelectedRibbonTabItem = RibbonBarMergeContainerForm_Options.RibbonTabItem

                    End If

                End If

                RibbonBarOptions_Actions.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
                RibbonBarOptions_EstimateLevelsLines.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
                RibbonBarOptions_GridOptions.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
                RibbonBarOptions_DateSettings.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
                RibbonBarOptions_MediaRates.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
                RibbonBarOptions_Totals.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
                RibbonBarOptions_DataOptions.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)
                RibbonBarProcess_Data.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

                ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedIndex = -1

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                If _MediaPlanDetailIDToShowOnLoad > 0 Then

                    _MediaPlan.SelectMediaPlanEstimateByMediaPlanDetailID(_MediaPlanDetailIDToShowOnLoad)

                    If _MediaPlan.MediaPlanEstimate Is Nothing Then

                        AdvantageFramework.WinForm.MessageBox.Show("The media plan you are trying to view does not exist anymore.")
                        Me.Close()

                    Else

                        ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedIndex = _MediaPlan.MediaPlanEstimate.OrderNumber - 1

                        RefreshEstimateGrandTotalAmounts()

                    End If

                ElseIf _MediaPlanDetailIDToShowOnLoad = 0 AndAlso _MediaPlan.MediaPlanEstimates.Count = 0 Then

                    ButtonItemMediaPlanDetails_Add.RaiseClick()

                End If

                EnableOrDisableMediaMixOptions()

            Else

                AdvantageFramework.WinForm.MessageBox.Show("The media plan you are trying to view does not exist anymore.")
                Me.Close()

            End If

        End Sub
        Private Sub MediaPlanEditForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = False

        End Sub
        Private Sub MediaPlanEditForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub _MediaPlan_MediaPlanChangedEvent() Handles _MediaPlan.MediaPlanChangedEvent

            PivotGridForm_MediaPlanDetail.SetUserEntryChanged()

            RefreshMediaPlanGrandTotalAmounts()

            _PlanChangedInDialog = True

        End Sub
        Private Sub _MediaPlan_SavedMediaPlanEvent() Handles _MediaPlan.SavedMediaPlanEvent

            If Me.UserEntryChanged Then

                Me.ClearChanged()

            End If

            _PlanChangedInDialog = False

        End Sub
        Private Sub ButtonForm_CalculateQty_Click(sender As Object, e As EventArgs) Handles ButtonForm_CalculateQty.Click

            If _MediaPlan IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                Me.ShowWaitForm("Refreshing...")

                _MediaPlan.MediaPlanEstimate.CalculateQtyEstimateDataTableData()

                _MediaPlan.MediaPlanEstimate.FieldsChanged()

                RefreshMediaPlanGrandTotalAmounts()

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                PivotGridForm_MediaPlanDetail.RefreshData()

                PivotGridForm_MediaPlanDetail.EndUpdate()

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            Me.FormAction = WinForm.Presentation.FormActions.Saving
            Me.ShowWaitForm()
            Me.ShowWaitForm("Saving...")

            Try

                Saved = SaveChanges(ErrorMessage)

            Catch ex As Exception
                Saved = False
            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

            If Saved = False Then

                AdvantageFramework.WinForm.MessageBox.Show("Failed saving this media plan.  Please contact Software Support." & System.Environment.NewLine & ErrorMessage)

            Else

                If _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                    Me.FormAction = WinForm.Presentation.FormActions.Saving

                    ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedIndex = -1

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue = _MediaPlan.MediaPlanEstimate.OrderNumber

                    RefreshEstimateGrandTotalAmounts()

                    EnableOrDisableMediaMixOptions()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Update.Click

            'objects
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim LockMessage As String = Nothing

            StartDate = _MediaPlan.StartDate
            EndDate = _MediaPlan.EndDate

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlan(DbContext, _MediaPlan.ID, LockMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show(LockMessage)

                ElseIf AdvantageFramework.Media.Presentation.MediaPlanUpdateDialog.ShowFormDialog(_MediaPlan) = Windows.Forms.DialogResult.OK Then

                    'If Not _MediaPlan.IsApproved AndAlso StartDate <> _MediaPlan.StartDate OrElse EndDate <> _MediaPlan.EndDate AndAlso _MediaPlan.MediaPlanEstimates.Count > 0 Then
                    If StartDate <> _MediaPlan.StartDate OrElse EndDate <> _MediaPlan.EndDate AndAlso _MediaPlan.MediaPlanEstimates.Count > 0 Then

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading
                        Me.ShowWaitForm()

                        PivotGridForm_MediaPlanDetail.BeginUpdate()

                        Try

                            For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                For Each MediaPlanDetailLevel In MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.StartDate OrElse Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.EndDate).ToList

                                    For Each MediaPlanDetailLevelLine In MediaPlanDetailLevel.MediaPlanDetailLevelLines.ToList

                                        For Each MediaPlanDetailLevelLineTag In MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.ToList

                                            If MediaPlanDetailLevel.TagType = AdvantageFramework.MediaPlanning.TagTypes.StartDate Then

                                                If MediaPlanDetailLevelLineTag.StartDate < _MediaPlan.StartDate OrElse MediaPlanDetailLevelLineTag.StartDate > _MediaPlan.EndDate Then

                                                    MediaPlanDetailLevelLine.Description = ""

                                                    If MediaPlanEstimate.IsLevelAndLinesLoaded AndAlso MediaPlanEstimate.LevelsAndLinesDataTable.Columns.Contains(MediaPlanDetailLevel.Description) Then

                                                        Try

                                                            MediaPlanEstimate.LevelsAndLinesDataTable.Rows(MediaPlanDetailLevelLine.RowIndex)(MediaPlanDetailLevel.Description) = ""

                                                        Catch ex As Exception

                                                        End Try

                                                    End If

                                                    MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Remove(MediaPlanDetailLevelLineTag)

                                                    Try

                                                        _MediaPlan.DbContext.DeleteEntityObject(MediaPlanDetailLevelLineTag)

                                                    Catch ex As Exception
                                                        MediaPlanDetailLevelLineTag = Nothing
                                                    End Try

                                                End If

                                            ElseIf MediaPlanDetailLevel.TagType = AdvantageFramework.MediaPlanning.TagTypes.EndDate Then

                                                If MediaPlanDetailLevelLineTag.EndDate < _MediaPlan.StartDate OrElse MediaPlanDetailLevelLineTag.EndDate > _MediaPlan.EndDate Then

                                                    MediaPlanDetailLevelLine.Description = ""

                                                    If MediaPlanEstimate.IsLevelAndLinesLoaded AndAlso MediaPlanEstimate.LevelsAndLinesDataTable.Columns.Contains(MediaPlanDetailLevel.Description) Then

                                                        Try

                                                            MediaPlanEstimate.LevelsAndLinesDataTable.Rows(MediaPlanDetailLevelLine.RowIndex)(MediaPlanDetailLevel.Description) = ""

                                                        Catch ex As Exception

                                                        End Try

                                                    End If

                                                    MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Remove(MediaPlanDetailLevelLineTag)

                                                    Try

                                                        _MediaPlan.DbContext.DeleteEntityObject(MediaPlanDetailLevelLineTag)

                                                    Catch ex As Exception
                                                        MediaPlanDetailLevelLineTag = Nothing
                                                    End Try

                                                End If

                                            End If

                                        Next

                                    Next

                                Next

                                MediaPlanEstimate.RefreshWidths()

                                MediaPlanEstimate.CreateEstimateDataTable()

                                If MediaPlanEstimate.EstimateDataTable IsNot Nothing Then

                                    For Each DataRow In MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) DR(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString) < _MediaPlan.StartDate OrElse DR(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString) > _MediaPlan.EndDate).ToList

                                        MediaPlanEstimate.EstimateDataTable.Rows.Remove(DataRow)

                                    Next

                                End If

                                MediaPlanEstimate.RefreshEntryDates()

                                For Each MediaPlanDetailLevelLineData In MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.StartDate < _MediaPlan.StartDate OrElse Entity.StartDate > _MediaPlan.EndDate).ToList

                                    MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Remove(MediaPlanDetailLevelLineData)

                                    Try

                                        _MediaPlan.DbContext.DeleteEntityObject(MediaPlanDetailLevelLineData)

                                    Catch ex As Exception
                                        MediaPlanDetailLevelLineData = Nothing
                                    End Try

                                Next

                            Next

                            LoadPivotGrid(Me.Session, PivotGridForm_MediaPlanDetail, _MediaPlan.DbContext, _MediaPlan.MediaPlanEstimate)

                        Catch ex As Exception

                        End Try

                        PivotGridForm_MediaPlanDetail.EndUpdate()

                        SetExpandedValuesForPivotGrid(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                        If _MediaPlan.SyncDetailSettings Then

                            ButtonItemOptions_AddColumnsHeadersToAllEstimates.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

                        Else

                            ButtonItemOptions_AddColumnsHeadersToAllEstimates.Enabled = False
                            ButtonItemOptions_AddColumnsHeadersToAllEstimates.Checked = False

                        End If

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                        Me.CloseWaitForm()

                    End If

                    RefreshMediaPlanGrandTotalAmounts()

                End If

            End Using

        End Sub
        Private Sub ButtonItemActions_Approve_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Approve.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim Message As String = Nothing

            If _MediaPlan IsNot Nothing Then

                If AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlanOtherThanSelectedEstimateID(Session, _MediaPlan.ID, _MediaPlan.MediaPlanEstimate.ID, Message, False) Then

                    AdvantageFramework.WinForm.MessageBox.Show(Message)

                ElseIf AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to approve ALL estimates for this media plan?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    _MediaPlan.ApproveAllEstimates(Me.Session.User.EmployeeCode)

                    If _MediaPlan.Save(ErrorMessage, True) Then

                        If _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                            _MediaPlan.Refresh(_MediaPlan.MediaPlanEstimate.ID, False)

                        Else

                            _MediaPlan.Refresh(0, False)

                        End If

                        RefreshMediaPlanForm()

                        If ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1 Then

                            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading
                            Me.ShowWaitForm()

                            PivotGridForm_MediaPlanDetail.BeginUpdate()

                            Try

                                LoadPivotGrid(Me.Session, PivotGridForm_MediaPlanDetail, _MediaPlan.DbContext, _MediaPlan.MediaPlanEstimate)

                                EnableOrDisableEstimateActions()

                                EnableOrDisableActions(False)

                            Catch ex As Exception

                            End Try

                            PivotGridForm_MediaPlanDetail.EndUpdate()

                            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                            Me.CloseWaitForm()

                        Else

                            EnableOrDisableEstimateActions()

                            EnableOrDisableActions(False)

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Failed saving this media plan.  Please contact Software Support." & System.Environment.NewLine & ErrorMessage)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Unapprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Unapprove.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim Message As String = Nothing

            If _MediaPlan IsNot Nothing Then

                If AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlanOtherThanSelectedEstimateID(Session, _MediaPlan.ID, _MediaPlan.MediaPlanEstimate.ID, Message, False) Then

                    AdvantageFramework.WinForm.MessageBox.Show(Message)

                ElseIf AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to unapprove ALL estimates for this media plan?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    _MediaPlan.UnapproveAllEstimates()

                    If _MediaPlan.Save(ErrorMessage, True) Then

                        If _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                            _MediaPlan.Refresh(_MediaPlan.MediaPlanEstimate.ID, False)

                        Else

                            _MediaPlan.Refresh(0, False)

                        End If

                        RefreshMediaPlanForm()

                        If ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1 Then

                            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading
                            Me.ShowWaitForm()

                            PivotGridForm_MediaPlanDetail.BeginUpdate()

                            Try

                                LoadPivotGrid(Me.Session, PivotGridForm_MediaPlanDetail, _MediaPlan.DbContext, _MediaPlan.MediaPlanEstimate)

                                EnableOrDisableEstimateActions()

                                EnableOrDisableActions(True)

                            Catch ex As Exception

                            End Try

                            PivotGridForm_MediaPlanDetail.EndUpdate()

                            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                            Me.CloseWaitForm()

                        Else

                            EnableOrDisableEstimateActions()

                            EnableOrDisableActions(False)

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Failed saving this media plan.  Please contact Software Support." & System.Environment.NewLine & ErrorMessage)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            'objects
            Dim ContinueRefreshing As Boolean = False
            Dim OrderNumber As Integer = Nothing
            Dim NewOrderNumber As Integer = Nothing
            Dim ErrorMessage As String = ""

            If ButtonItemActions_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before refreshing plan.  Do you want to save your changes now?", WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        ContinueRefreshing = SaveChanges(ErrorMessage)

                    Catch ex As Exception
                        ContinueRefreshing = False
                    End Try

                    Me.SetFormActionAndShowWaitForm(WinForm.Presentation.Methods.FormActions.None)

                    If ContinueRefreshing = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Failed saving this media plan.  Please contact Software Support." & System.Environment.NewLine & ErrorMessage)

                    End If

                End If

            Else

                ContinueRefreshing = True

            End If

            If ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1 AndAlso ContinueRefreshing Then

                OrderNumber = ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.Methods.FormActions.Refreshing, "Refreshing...")

                _MediaPlan.Refresh(DirectCast(_MediaPlan.MediaPlanEstimates(OrderNumber), AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ID, False)

                LoadMediaPlanEsitmatesForComboBox()

                ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex = -1
                ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue = OrderNumber

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.Methods.FormActions.None)

            End If

        End Sub
        Private Sub ComboBoxItemMediaPlanDetails_MediaPlanDetails_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndexChanged

            'objects
            Dim MediaPlanDetailID As Integer = 0
            Dim Message As String = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1 Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading
                    Me.ShowWaitForm()

                    Try

                        MediaPlanDetailID = DirectCast(_MediaPlan.MediaPlanEstimates(CInt(ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue)), AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ID

                        _MediaPlan.SelectMediaPlanEstimateByMediaPlanDetailID(_MediaPlan.MediaPlanEstimate.ID)

                        ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue = _MediaPlan.MediaPlanEstimate.OrderNumber

                        If AdvantageFramework.MediaPlanning.IsEstimateLocked(Session, MediaPlanDetailID, Message) Then

                            AdvantageFramework.WinForm.MessageBox.Show(Message)

                        Else

                            If Not CheckForOpenMediaPlan(Me.MdiParent, _MediaPlan.ID, MediaPlanDetailID) Then

                                'If _MediaPlan IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                                '    AdvantageFramework.MediaPlanning.ClearEstimateLock(Me.Session, _MediaPlan.MediaPlanEstimate.ID)

                                'End If

                                AdvantageFramework.Media.Presentation.MediaPlanEditForm.ShowForm(MediaPlanID, MediaPlanDetailID)

                            End If

                            If _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                                _MediaPlan.MediaPlanEstimate.RefreshWidths()

                                ComboBoxItemMediaPlanDetails_MediaPlanDetails.Tooltip = "Estimate ID: " & If(_MediaPlan.MediaPlanEstimate.ID = 0, "", _MediaPlan.MediaPlanEstimate.ID)

                                PivotGridForm_MediaPlanDetail.BeginUpdate()

                                LoadMediaPlanEstimateSettings(_MediaPlan.MediaPlanEstimate)

                                LoadPivotGrid(Me.Session, PivotGridForm_MediaPlanDetail, _MediaPlan.DbContext, _MediaPlan.MediaPlanEstimate)

                                PivotGridForm_MediaPlanDetail.Tag = _MediaPlan.MediaPlanEstimate

                                PivotGridForm_MediaPlanDetail.EndUpdate()

                                'AddDaysOfWeekField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)
                                'ShowPackageLevelsField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)
                                'ShowDateRangeField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)
                                'ShowAdSizesField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                                SetExpandedValuesForPivotGrid(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                                RefreshEstimateGrandTotalAmounts()

                                EnableOrDisableEstimateActions()

                                EnableOrDisableActions(True)

                            End If

                        End If

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                Else

                    If _MediaPlan IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                        AdvantageFramework.MediaPlanning.ClearEstimateLock(Me.Session, _MediaPlan.MediaPlanEstimate.ID)

                    End If

                    ComboBoxItemMediaPlanDetails_MediaPlanDetails.Tooltip = ""
                    _MediaPlan.SelectMediaPlanEstimate(-1)

                End If

                EnableOrDisableEstimateActions()

            End If

        End Sub
        Private Sub ButtonItemMediaPlanDetails_ViewOrderDetails_Click(sender As Object, e As EventArgs) Handles ButtonItemMediaPlanDetails_ViewOrderDetails.Click

            Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing

            If ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1 Then

                MediaPlanEstimate = _MediaPlan.MediaPlanEstimates(CInt(ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedIndex + 1))

                If MediaPlanEstimate IsNot Nothing Then

                    AdvantageFramework.Media.Presentation.MediaPlanEstimateLevelLineDataDialog.ShowFormDialog(_MediaPlan.ID, MediaPlanEstimate.ID)

                End If

            End If

        End Sub
        Private Sub ButtonItemMediaPlanDetails_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemMediaPlanDetails_Add.Click

            'objects
            Dim OrderNumber As Nullable(Of Integer) = Nothing

            If _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                OrderNumber = _MediaPlan.MediaPlanEstimate.OrderNumber

            End If

            If AdvantageFramework.Media.Presentation.MediaPlanDetailEditDialog.ShowFormDialog(_MediaPlan, Nothing) = System.Windows.Forms.DialogResult.OK Then

                If OrderNumber.HasValue Then

                    AdvantageFramework.Media.Presentation.MediaPlanEditForm.ShowForm(MediaPlanID, _MediaPlan.MediaPlanEstimate.ID)

                Else

                    OrderNumber = _MediaPlan.MediaPlanEstimate.OrderNumber

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading, "Loading...")

                LoadMediaPlanEsitmatesForComboBox()

                RefreshMediaPlanGrandTotalAmounts()

                _MediaPlan.SelectMediaPlanEstimate(OrderNumber)

                ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex = -1

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue = OrderNumber

            Else

                Me.Close()

            End If

        End Sub
        Private Sub ButtonItemMediaPlanDetails_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemMediaPlanDetails_Update.Click

            Dim OrderNumber As Integer = 0
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing

            If _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                If AdvantageFramework.Media.Presentation.MediaPlanDetailEditDialog.ShowFormDialog(_MediaPlan, _MediaPlan.MediaPlanEstimate) = Windows.Forms.DialogResult.OK Then

                    Me.FormAction = WinForm.Presentation.Methods.FormActions.Refreshing

                    OrderNumber = _MediaPlan.MediaPlanEstimate.OrderNumber

                    _MediaPlan.RefreshOrderNumbers()

                    Try

                        LoadMediaPlanEsitmatesForComboBox()
                        ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue = OrderNumber

                    Catch ex As Exception

                    End Try

                    RefreshEstimateGrandTotalAmounts()

                    Try

                        MediaPlanDetailField = _MediaPlan.MediaPlanEstimate.MediaPlanDetailFields.SingleOrDefault(Function(Entity) Entity.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString)

                    Catch ex As Exception
                        MediaPlanDetailField = Nothing
                    End Try

                    If MediaPlanDetailField IsNot Nothing Then

                        PivotGridForm_MediaPlanDetail.Fields(AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString).Caption = MediaPlanDetailField.Caption

                    End If

                    Me.FormAction = WinForm.Presentation.Methods.FormActions.None

                End If

            End If

        End Sub
        Private Sub ButtonItemMediaPlanDetails_Approve_Click(sender As Object, e As EventArgs) Handles ButtonItemMediaPlanDetails_Approve.Click

            Dim Approved As Boolean = False
            Dim OrderNumber As Integer = 0
            Dim ErrorMessage As String = ""

            If ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1 Then

                If ButtonItemActions_Save.Enabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes to approve this estimate.  Do you want to save your changes now?", WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = WinForm.MessageBox.DialogResults.Yes Then

                        Me.FormAction = WinForm.Presentation.FormActions.Saving
                        Me.ShowWaitForm()
                        Me.ShowWaitForm("Saving...")

                        Try

                            _MediaPlan.ApproveMediaPlanEstimate(ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue, Session.User.EmployeeCode)

                            Approved = SaveChanges(ErrorMessage)

                        Catch ex As Exception
                            Approved = False
                        End Try

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                        Me.CloseWaitForm()

                        If Approved = False Then

                            AdvantageFramework.WinForm.MessageBox.Show("Failed saving this media plan.  Please contact Software Support." & System.Environment.NewLine & ErrorMessage)

                        End If

                    End If

                Else

                    _MediaPlan.ApproveMediaPlanEstimate(ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue, Session.User.EmployeeCode)

                    SaveChanges(ErrorMessage)

                End If

                If _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                    Me.FormAction = WinForm.Presentation.FormActions.Refreshing

                    ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedIndex = -1

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue = _MediaPlan.MediaPlanEstimate.OrderNumber

                End If

            End If

        End Sub
        Private Sub ButtonItemMediaPlanDetails_Unapprove_Click(sender As Object, e As EventArgs) Handles ButtonItemMediaPlanDetails_Unapprove.Click

            Dim Unapproved As Boolean = False
            Dim OrderNumber As Integer = 0
            Dim ErrorMessage As String = ""

            If ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1 Then

                If ButtonItemActions_Save.Enabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes to unapprove this estimate.  Do you want to save your changes now?", WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = WinForm.MessageBox.DialogResults.Yes Then

                        Me.FormAction = WinForm.Presentation.FormActions.Saving
                        Me.ShowWaitForm()
                        Me.ShowWaitForm("Saving...")

                        Try

                            _MediaPlan.UnapproveMediaPlanEstimate(ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue)

                            Unapproved = SaveChanges(ErrorMessage)

                        Catch ex As Exception
                            Unapproved = False
                        End Try

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                        Me.CloseWaitForm()

                        If Unapproved = False Then

                            AdvantageFramework.WinForm.MessageBox.Show("Failed saving this media plan.  Please contact Software Support." & System.Environment.NewLine & ErrorMessage)

                        End If

                    End If

                Else

                    _MediaPlan.UnapproveMediaPlanEstimate(ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue)

                    SaveChanges(ErrorMessage)

                End If

                If _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                    Me.FormAction = WinForm.Presentation.FormActions.Refreshing

                    ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedIndex = -1

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue = _MediaPlan.MediaPlanEstimate.OrderNumber

                End If

            End If

        End Sub
        Private Sub ButtonItemMediaPlanDetails_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemMediaPlanDetails_Delete.Click

            'objects
            Dim Deleted As Boolean = False

            If ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1 Then

                If SelectedMediaPlanEstimateHasMediaOrder() = False Then

                    If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete this estimate?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Deleting
                        Me.ShowWaitForm()
                        Me.ShowWaitForm("Deleting...")

                        Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            Deleted = _MediaPlan.MediaPlanEstimate.Delete(DbContext)

                            DbContext.SaveChanges()

                        End Using

                        'Try

                        '    Deleted = _MediaPlan.DeleteMediaPlanEstimate(ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue)

                        'Catch ex As Exception

                        'End Try

                        Me.FormAction = WinForm.Presentation.FormActions.None
                        Me.CloseWaitForm()

                        If Deleted Then

                            Me.Close()

                            'For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                            '    MediaPlanEstimate.OrderNumberChanged()

                            'Next

                            '_MediaPlan.EstimateChangedEvent()

                            'Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Clearing
                            'Me.ShowWaitForm()

                            'PivotGridForm_MediaPlanDetail.Fields.Clear()

                            'LoadMediaPlanEsitmatesForComboBox()

                            'ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex = -1

                            'EnableOrDisableEstimateActions()

                            'EnableOrDisableActions(False)

                            'Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                            'Me.CloseWaitForm()

                            'ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedIndex = -1

                            'If ComboBoxItemMediaPlanDetails_MediaPlanDetails.Items.Count > 0 Then

                            '    ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedIndex = 0

                            'End If

                            '_MediaPlan.SelectMediaPlanEstimate(-1)

                            'EnableOrDisableEstimateActions()

                            'EnableOrDisableActions(False)

                            'If _MediaPlan.MediaPlanEstimate Is Nothing Then

                            '    LoadMediaPlanEstimateSettings(Nothing)

                            'End If

                            'RefreshMediaPlanGrandTotalAmounts()

                        End If

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("You cannot delete this estimate because orders are processing or processed.")

                End If

            End If

        End Sub
        Private Sub ButtonItemMediaPlanDetails_Copy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemMediaPlanDetails_Copy.Click

            'objects
            Dim ContinueCopying As Boolean = False
            Dim OrderNumber As Integer = Nothing
            Dim NewOrderNumber As Integer = Nothing
            Dim ErrorMessage As String = ""
            Dim MediaPlanDetailIDs As IEnumerable(Of Integer) = Nothing
            Dim DictionaryMediaPlanDetailIDs As Dictionary(Of Integer, String) = Nothing
            Dim NewSalesClassCode As String = Nothing

            If ButtonItemActions_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before copying estimate.  Do you want to save your changes now?", WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = WinForm.MessageBox.DialogResults.Yes Then

                    Me.FormAction = WinForm.Presentation.FormActions.Saving
                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Saving...")

                    Try

                        ContinueCopying = SaveChanges(ErrorMessage)

                    Catch ex As Exception
                        ContinueCopying = False
                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                    If ContinueCopying = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Failed saving this media plan.  Please contact Software Support." & System.Environment.NewLine & ErrorMessage)

                    End If

                End If

            Else

                ContinueCopying = True

            End If

            If ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex > -1 AndAlso ContinueCopying Then

                OrderNumber = ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue

                If AdvantageFramework.MediaPlanning.GetMediaPlanEstimatesWithInactiveSalesClassByMediaPlanID(Session, _MediaPlan.ID,
                                                                                                             DirectCast(_MediaPlan.MediaPlanEstimates(OrderNumber), AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ID, MediaPlanDetailIDs) Then

                    If AdvantageFramework.Media.Presentation.MediaPlanCopyDialog.ShowFormDialog(MediaPlanDetailIDs, DictionaryMediaPlanDetailIDs) = Windows.Forms.DialogResult.OK Then

                        NewSalesClassCode = DictionaryMediaPlanDetailIDs.Item(DirectCast(_MediaPlan.MediaPlanEstimates(OrderNumber), AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ID)

                    Else

                        ContinueCopying = False

                    End If

                End If

                If ContinueCopying Then

                    Me.FormAction = WinForm.Presentation.FormActions.Copying
                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Copying...")

                    If _MediaPlan.Copy(ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue, NewOrderNumber, NewSalesClassCode) Then

                        LoadMediaPlanEsitmatesForComboBox()

                        Me.FormAction = WinForm.Presentation.FormActions.None
                        Me.CloseWaitForm()

                        If AdvantageFramework.WinForm.MessageBox.Show("Estimate successfully copied. Do you want to view this estimate now?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                            Me.ShowWaitForm()

                            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_DTL SET LOCKED_BY = NULL WHERE MEDIA_PLAN_DTL_ID = {0}", DirectCast(_MediaPlan.MediaPlanEstimates(OrderNumber), AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ID))

                            End Using

                            Try

                                ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue = NewOrderNumber

                            Catch ex As Exception

                            End Try

                            Me.CloseWaitForm()

                        Else

                            Me.ShowWaitForm()

                            Try

                                ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue = OrderNumber

                            Catch ex As Exception

                            End Try

                            Me.CloseWaitForm()

                        End If

                        RefreshMediaPlanGrandTotalAmounts()

                    Else

                        Me.FormAction = WinForm.Presentation.FormActions.None
                        Me.CloseWaitForm()

                        AdvantageFramework.WinForm.MessageBox.Show("Failed copying media plan detail.  Please contact Software Support.")

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemMediaPlanDetails_ChangeLogs_Click(sender As Object, e As EventArgs) Handles ButtonItemMediaPlanDetails_ChangeLogs.Click

            AdvantageFramework.Media.Presentation.MediaPlanDetailChangeLogDialog.ShowFormDialog(_MediaPlan, _MediaPlan.MediaPlanEstimate)

        End Sub
        Private Sub ButtonItemDetailLevelsLines_CopyFrom_Click(sender As Object, e As EventArgs) Handles ButtonItemDetailLevelsLines_CopyFrom.Click

            'objects
            Dim ContinueCopying As Boolean = False
            Dim OrderNumber As Integer = 0
            Dim ErrorMessage As String = ""

            If ButtonItemActions_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before copying levels\lines.  Do you want to save your changes now?", WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = WinForm.MessageBox.DialogResults.Yes Then

                    Me.FormAction = WinForm.Presentation.FormActions.Saving
                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Saving...")

                    Try

                        ContinueCopying = SaveChanges(ErrorMessage)

                    Catch ex As Exception
                        ContinueCopying = False
                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                    If ContinueCopying = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Failed saving this media plan.  Please contact Software Support." & System.Environment.NewLine & ErrorMessage)

                    End If

                End If

            Else

                ContinueCopying = True

            End If

            If ContinueCopying Then

                OrderNumber = ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue

                If AdvantageFramework.Media.Presentation.MediaPlanDetailLevelsAndLinesCopyDialog.ShowFormDialog(_MediaPlan.ID, _MediaPlan.MediaPlanEstimate.ID) = Windows.Forms.DialogResult.OK Then

                    Me.FormAction = WinForm.Presentation.FormActions.Loading
                    Me.ShowWaitForm()

                    Try

                        _MediaPlan.Refresh(_MediaPlan.MediaPlanEstimate.ID, False)

                    Catch ex As Exception

                    End Try

                    ComboBoxItemMediaPlanDetails_MediaPlanDetails.SelectedIndex = -1

                    Me.FormAction = WinForm.Presentation.FormActions.None

                    ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue = OrderNumber

                    RefreshMediaPlanGrandTotalAmounts()

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemDetailLevelsLines_ManageLevelLines_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDetailLevelsLines_ManageLevelLines.Click

            ShowMediaPlanLevelAndLines()

        End Sub
        Private Sub ButtonItemDataArea_ShowFieldList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDataArea_ShowFieldList.Click

            'objects
            Dim PivotGridHitInfo As DevExpress.XtraPivotGrid.PivotGridHitInfo = Nothing

            If TypeOf ButtonItemCMB_DataArea.Tag Is DevExpress.XtraPivotGrid.PivotGridHitInfo Then

                Try

                    PivotGridHitInfo = ButtonItemCMB_DataArea.Tag

                Catch ex As Exception
                    PivotGridHitInfo = Nothing
                End Try

                If PivotGridHitInfo IsNot Nothing Then

                    If PivotGridForm_MediaPlanDetail.CustomizationForm IsNot Nothing Then

                        PivotGridForm_MediaPlanDetail.DestroyCustomization()
                        ButtonItemGridOptions_ShowHideFieldList.Checked = False

                    Else

                        PivotGridForm_MediaPlanDetail.FieldsCustomization()
                        ButtonItemGridOptions_ShowHideFieldList.Checked = True

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemDateSettings_CalendarMonth_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDateSettings_CalendarMonth.CheckedChanged

            'objects
            Dim ShowWarning As Boolean = False
            Dim ContinueChanging As Boolean = True

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If ButtonItemDateSettings_CalendarMonth.Checked Then

                    If _MediaPlan.MediaPlanEstimate.HiatusWeeks.Any OrElse _MediaPlan.MediaPlanEstimate.HiatusMonths.Any Then

                        ShowWarning = True

                    End If

                    If ShowWarning Then

                        If AdvantageFramework.WinForm.MessageBox.Show("By changing this calendar setting, all hiatus settings will be deleted.  Do you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.No Then

                            ContinueChanging = False

                        End If

                    End If

                    If ContinueChanging Then

                        _MediaPlan.MediaPlanEstimate.IsCalendarMonth = True
                        _MediaPlan.MediaPlanEstimate.HiatusWeeks.Clear()
                        _MediaPlan.MediaPlanEstimate.HiatusMonths.Clear()

                        _MediaPlan.MediaPlanEstimate.SaveHiatusWeeks()
                        _MediaPlan.MediaPlanEstimate.SaveHiatusMonths()

                        ButtonItemDateSettings_SplitWeeks.Enabled = Not (_MediaPlan.IsTemplate AndAlso Not _CanUserEditTemplate)

                        _MediaPlan.MediaPlanEstimate.RefreshEstimateDataTableDates()

                        PivotGridForm_MediaPlanDetail.RefreshData()

                    Else

                        Me.FormAction = WinForm.Presentation.FormActions.Modifying

                        Try

                            ButtonItemDateSettings_CalendarMonth.Checked = False
                            ButtonItemDateSettings_BroadcastMonth.Checked = True

                        Catch ex As Exception

                        End Try

                        Me.FormAction = WinForm.Presentation.FormActions.None

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemDateSettings_Month_OptionGroupChanging(sender As Object, e As DevComponents.DotNetBar.OptionGroupChangingEventArgs) Handles ButtonItemDateSettings_BroadcastMonth.OptionGroupChanging,
                                                                                                                                                          ButtonItemDateSettings_CalendarMonth.OptionGroupChanging

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _AllowCalendarChange = False Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub ButtonItemDateSettings_BroadcastMonth_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDateSettings_BroadcastMonth.CheckedChanged

            'objects
            Dim ShowWarning As Boolean = False
            Dim ContinueChanging As Boolean = True

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If ButtonItemDateSettings_BroadcastMonth.Checked Then

                    If _MediaPlan.MediaPlanEstimate.HiatusWeeks.Any OrElse _MediaPlan.MediaPlanEstimate.HiatusMonths.Any Then

                        ShowWarning = True

                    End If

                    If ShowWarning Then

                        If AdvantageFramework.WinForm.MessageBox.Show("By changing this calendar setting, all hiatus settings will be deleted.  Do you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.No Then

                            ContinueChanging = False

                        End If

                    End If

                    If ContinueChanging Then

                        _MediaPlan.MediaPlanEstimate.IsCalendarMonth = False
                        _MediaPlan.MediaPlanEstimate.HiatusWeeks.Clear()
                        _MediaPlan.MediaPlanEstimate.HiatusMonths.Clear()

                        _MediaPlan.MediaPlanEstimate.SaveHiatusWeeks()
                        _MediaPlan.MediaPlanEstimate.SaveHiatusMonths()

                        Me.FormAction = WinForm.Presentation.FormActions.Modifying

                        Try

                            ButtonItemDateSettings_SplitWeeks.Checked = False
                            ButtonItemDateSettings_SplitWeeks.Enabled = False
                            _MediaPlan.MediaPlanEstimate.SplitWeeks = False

                        Catch ex As Exception

                        End Try

                        Me.FormAction = WinForm.Presentation.FormActions.None

                        _MediaPlan.MediaPlanEstimate.RefreshEstimateDataTableDates()

                        PivotGridForm_MediaPlanDetail.RefreshData()

                    Else

                        Me.FormAction = WinForm.Presentation.FormActions.Modifying

                        Try

                            ButtonItemDateSettings_CalendarMonth.Checked = True
                            ButtonItemDateSettings_BroadcastMonth.Checked = False

                        Catch ex As Exception

                        End Try

                        Me.FormAction = WinForm.Presentation.FormActions.None

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemDateSettings_SplitWeeks_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemDateSettings_SplitWeeks.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                _MediaPlan.MediaPlanEstimate.SplitWeeks = ButtonItemDateSettings_SplitWeeks.Checked

                _MediaPlan.MediaPlanEstimate.RefreshEstimateDataTableDates()

                PivotGridForm_MediaPlanDetail.RefreshData()

            End If

        End Sub
        Private Sub ButtonItemMediaRates_Gross_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemMediaRates_Gross.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If ButtonItemMediaRates_Gross.Checked Then

                    _MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount = True

                    _MediaPlan.MediaPlanEstimate.RefreshEstimateDataTableData()

                    AddNetDollarsField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)
                    AddCommissionField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                    PivotGridForm_MediaPlanDetail.RefreshData()

                End If

            End If

        End Sub
        Private Sub ButtonItemMediaRates_Net_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemMediaRates_Net.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If ButtonItemMediaRates_Net.Checked Then

                    _MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount = False

                    _MediaPlan.MediaPlanEstimate.RefreshEstimateDataTableData()

                    AddNetDollarsField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)
                    AddCommissionField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                    PivotGridForm_MediaPlanDetail.RefreshData()

                End If

            End If

        End Sub
        Private Sub ButtonItemShowHideColumnTotals_GrandTotals_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemShowHideColumnTotals_GrandTotals.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                _MediaPlan.MediaPlanEstimate.ShowColumnGrandTotals = ButtonItemShowHideColumnTotals_GrandTotals.Checked

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                SetTotalsOptionsOnPivotGridControl(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                PivotGridForm_MediaPlanDetail.EndUpdate()

            End If

        End Sub
        Private Sub ButtonItemShowHideColumnTotals_Totals_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemShowHideColumnTotals_Totals.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                _MediaPlan.MediaPlanEstimate.ShowColumnTotals = ButtonItemShowHideColumnTotals_Totals.Checked

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                SetTotalsOptionsOnPivotGridControl(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                PivotGridForm_MediaPlanDetail.EndUpdate()

            End If

        End Sub
        Private Sub ButtonItemShowHideRowTotals_GrandTotals_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemShowHideRowTotals_GrandTotals.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                _MediaPlan.MediaPlanEstimate.ShowRowGrandTotals = ButtonItemShowHideRowTotals_GrandTotals.Checked

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                SetTotalsOptionsOnPivotGridControl(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                PivotGridForm_MediaPlanDetail.EndUpdate()

            End If

        End Sub
        Private Sub ButtonItemShowHideRowTotals_GrandTotalsValues_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemShowHideRowTotals_GrandTotalsValues.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                _MediaPlan.MediaPlanEstimate.ShowRowGrandTotalsValues = ButtonItemShowHideRowTotals_GrandTotalsValues.Checked

                PivotGridForm_MediaPlanDetail.RefreshData()

            End If

        End Sub
        Private Sub ButtonItemShowHideRowTotals_Totals_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemShowHideRowTotals_Totals.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                _MediaPlan.MediaPlanEstimate.ShowRowTotals = ButtonItemShowHideRowTotals_Totals.Checked

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                SetTotalsOptionsOnPivotGridControl(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                PivotGridForm_MediaPlanDetail.EndUpdate()

            End If

        End Sub
        Private Sub ButtonItemShowHideRowTotals_TotalsValues_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemShowHideRowTotals_TotalsValues.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                _MediaPlan.MediaPlanEstimate.ShowRowTotalsValues = ButtonItemShowHideRowTotals_TotalsValues.Checked

                PivotGridForm_MediaPlanDetail.RefreshData()

            End If

        End Sub
        Private Sub ButtonItemTotals_SubItem_CheckedChanged(sender As Object, e As EventArgs)

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing
            Dim ButtonItem As DevComponents.DotNetBar.ButtonItem = Nothing

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemTotalFields_GrossPercentageInTotals.Checked = True

                If TypeOf sender Is DevComponents.DotNetBar.ButtonItem Then

                    ButtonItem = sender

                    If ButtonItem.Checked Then

                        _MediaPlan.MediaPlanEstimate.GrossPercentageInTotalField = DirectCast(sender, DevComponents.DotNetBar.ButtonItem).Name

                    Else

                        _MediaPlan.MediaPlanEstimate.GrossPercentageInTotalField = ""

                    End If

                End If

                _MediaPlan.MediaPlanEstimate.GrossPercentageInTotals = ButtonItemTotalFields_GrossPercentageInTotals.Checked

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                AddGrossPercentageInTotalsField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                PivotGridForm_MediaPlanDetail.EndUpdate()

                PivotGridForm_MediaPlanDetail.RefreshData()

                Try

                    PivotGridField = PivotGridForm_MediaPlanDetail.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotals.ToString)

                Catch ex As Exception
                    PivotGridField = Nothing
                End Try

                If PivotGridField IsNot Nothing Then

                    FieldAreaIndexChanged(PivotGridField, _MediaPlan.MediaPlanEstimate, False)

                End If

            End If

        End Sub
        Private Sub ButtonItemTotalFields_GrossPercentageInTotals_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemTotalFields_GrossPercentageInTotals.CheckedChanged

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing
            Dim ButtonItem As DevComponents.DotNetBar.ButtonItem = Nothing

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                _MediaPlan.MediaPlanEstimate.GrossPercentageInTotals = ButtonItemTotalFields_GrossPercentageInTotals.Checked

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                AddGrossPercentageInTotalsField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                If ButtonItemTotalFields_GrossPercentageInTotals.Checked Then

                    If ButtonItemTotalFields_GrossPercentageInTotals.SubItems.OfType(Of DevComponents.DotNetBar.ButtonItem).Any(Function(BI) BI.Checked = True) Then

                        _MediaPlan.MediaPlanEstimate.GrossPercentageInTotalField = ButtonItemTotalFields_GrossPercentageInTotals.SubItems.OfType(Of DevComponents.DotNetBar.ButtonItem).Where(Function(BI) BI.Checked = True).First.Name

                    Else

                        ButtonItem = ButtonItemTotalFields_GrossPercentageInTotals.SubItems.OfType(Of DevComponents.DotNetBar.ButtonItem).First

                        ButtonItem.Checked = True

                        _MediaPlan.MediaPlanEstimate.GrossPercentageInTotalField = ButtonItem.Name

                    End If

                End If

                Me.FormAction = WinForm.Presentation.FormActions.None

                PivotGridForm_MediaPlanDetail.EndUpdate()

                PivotGridForm_MediaPlanDetail.RefreshData()

                Try

                    PivotGridField = PivotGridForm_MediaPlanDetail.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotals.ToString)

                Catch ex As Exception
                    PivotGridField = Nothing
                End Try

                If PivotGridField IsNot Nothing Then

                    FieldAreaIndexChanged(PivotGridField, _MediaPlan.MediaPlanEstimate, False)

                End If

            End If

        End Sub
        Private Sub ButtonItemTotalFields_NetDollars_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemTotalFields_NetDollars.CheckedChanged

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                _MediaPlan.MediaPlanEstimate.NetDollars = ButtonItemTotalFields_NetDollars.Checked

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                AddNetDollarsField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                PivotGridForm_MediaPlanDetail.EndUpdate()

                Try

                    PivotGridField = PivotGridForm_MediaPlanDetail.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString)

                Catch ex As Exception
                    PivotGridField = Nothing
                End Try

                If PivotGridField IsNot Nothing Then

                    FieldAreaIndexChanged(PivotGridField, _MediaPlan.MediaPlanEstimate, False)

                End If

            End If

        End Sub
        Private Sub ButtonItemTotalFields_CPP1_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemTotalFields_CPP1.CheckedChanged

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                _MediaPlan.MediaPlanEstimate.CPP1 = ButtonItemTotalFields_CPP1.Checked

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                AddCPP1Field(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                PivotGridForm_MediaPlanDetail.EndUpdate()

                Try

                    PivotGridField = PivotGridForm_MediaPlanDetail.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP1.ToString)

                Catch ex As Exception
                    PivotGridField = Nothing
                End Try

                If PivotGridField IsNot Nothing Then

                    FieldAreaIndexChanged(PivotGridField, _MediaPlan.MediaPlanEstimate, False)

                End If

            End If

        End Sub
        Private Sub ButtonItemTotalFields_CPP2_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemTotalFields_CPP2.CheckedChanged

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                _MediaPlan.MediaPlanEstimate.CPP2 = ButtonItemTotalFields_CPP2.Checked

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                AddCPP2Field(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                PivotGridForm_MediaPlanDetail.EndUpdate()

                Try

                    PivotGridField = PivotGridForm_MediaPlanDetail.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP2.ToString)

                Catch ex As Exception
                    PivotGridField = Nothing
                End Try

                If PivotGridField IsNot Nothing Then

                    FieldAreaIndexChanged(PivotGridField, _MediaPlan.MediaPlanEstimate, False)

                End If

            End If

        End Sub
        Private Sub ButtonItemTotalFields_CPI_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemTotalFields_CPI.CheckedChanged

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                _MediaPlan.MediaPlanEstimate.CPI = ButtonItemTotalFields_CPI.Checked

                If ButtonItemTotalFields_CPI.Checked Then

                    If PivotGridForm_MediaPlanDetail.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).Any(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString) = False Then

                        PivotGridForm_MediaPlanDetail.BeginUpdate()

                        AddNetDollarsField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                        PivotGridForm_MediaPlanDetail.EndUpdate()

                    End If

                End If

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                AddCPIField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                PivotGridForm_MediaPlanDetail.EndUpdate()

                Try

                    PivotGridField = PivotGridForm_MediaPlanDetail.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPI.ToString)

                Catch ex As Exception
                    PivotGridField = Nothing
                End Try

                If PivotGridField IsNot Nothing Then

                    FieldAreaIndexChanged(PivotGridField, _MediaPlan.MediaPlanEstimate, False)

                End If

            End If

        End Sub
        Private Sub ButtonItemTotalFields_CTR_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemTotalFields_CTR.CheckedChanged

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                _MediaPlan.MediaPlanEstimate.CTR = ButtonItemTotalFields_CTR.Checked

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                AddCTRField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                PivotGridForm_MediaPlanDetail.EndUpdate()

                Try

                    PivotGridField = PivotGridForm_MediaPlanDetail.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CTR.ToString)

                Catch ex As Exception
                    PivotGridField = Nothing
                End Try

                If PivotGridField IsNot Nothing Then

                    FieldAreaIndexChanged(PivotGridField, _MediaPlan.MediaPlanEstimate, False)

                End If

            End If

        End Sub
        Private Sub ButtonItemTotalFields_ConversionRate_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemTotalFields_ConversionRate.CheckedChanged

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                _MediaPlan.MediaPlanEstimate.ConversionRate = ButtonItemTotalFields_ConversionRate.Checked

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                AddConversionRateField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                PivotGridForm_MediaPlanDetail.EndUpdate()

                Try

                    PivotGridField = PivotGridForm_MediaPlanDetail.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ConversionRate.ToString)

                Catch ex As Exception
                    PivotGridField = Nothing
                End Try

                If PivotGridField IsNot Nothing Then

                    FieldAreaIndexChanged(PivotGridField, _MediaPlan.MediaPlanEstimate, False)

                End If

            End If

        End Sub
        Private Sub ButtonItemTotalFields_TotalDemo1_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemTotalFields_TotalDemo1.CheckedChanged

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                _MediaPlan.MediaPlanEstimate.TotalDemo1 = ButtonItemTotalFields_TotalDemo1.Checked

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                AddTotalDemo1Field(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                PivotGridForm_MediaPlanDetail.EndUpdate()

                Try

                    PivotGridField = PivotGridForm_MediaPlanDetail.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo1.ToString)

                Catch ex As Exception
                    PivotGridField = Nothing
                End Try

                If PivotGridField IsNot Nothing Then

                    FieldAreaIndexChanged(PivotGridField, _MediaPlan.MediaPlanEstimate, False)

                End If

            End If

        End Sub
        Private Sub ButtonItemTotalFields_TotalDemo2_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemTotalFields_TotalDemo2.CheckedChanged

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                _MediaPlan.MediaPlanEstimate.TotalDemo2 = ButtonItemTotalFields_TotalDemo2.Checked

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                AddTotalDemo2Field(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                PivotGridForm_MediaPlanDetail.EndUpdate()

                Try

                    PivotGridField = PivotGridForm_MediaPlanDetail.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo2.ToString)

                Catch ex As Exception
                    PivotGridField = Nothing
                End Try

                If PivotGridField IsNot Nothing Then

                    FieldAreaIndexChanged(PivotGridField, _MediaPlan.MediaPlanEstimate, False)

                End If

            End If

        End Sub
        Private Sub ButtonItemTotalFields_TotalNet_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemTotalFields_TotalNet.CheckedChanged

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                _MediaPlan.MediaPlanEstimate.TotalNet = ButtonItemTotalFields_TotalNet.Checked

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                AddTotalNetField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                PivotGridForm_MediaPlanDetail.EndUpdate()

                Try

                    PivotGridField = PivotGridForm_MediaPlanDetail.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalNet.ToString)

                Catch ex As Exception
                    PivotGridField = Nothing
                End Try

                If PivotGridField IsNot Nothing Then

                    FieldAreaIndexChanged(PivotGridField, _MediaPlan.MediaPlanEstimate, False)

                End If

            End If

        End Sub
        Private Sub ButtonItemTotalFields_Commission_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemTotalFields_Commission.CheckedChanged

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                _MediaPlan.MediaPlanEstimate.Commission = ButtonItemTotalFields_Commission.Checked

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                AddCommissionField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                PivotGridForm_MediaPlanDetail.EndUpdate()

                Try

                    PivotGridField = PivotGridForm_MediaPlanDetail.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.Commission.ToString)

                Catch ex As Exception
                    PivotGridField = Nothing
                End Try

                If PivotGridField IsNot Nothing Then

                    FieldAreaIndexChanged(PivotGridField, _MediaPlan.MediaPlanEstimate, False)

                End If

            End If

        End Sub
        Private Sub ButtonItemRateCPM_SubItem_CheckedChanged(sender As Object, e As EventArgs)

            'objects
            Dim DataAreaQuantityColumn As AdvantageFramework.MediaPlanning.DataAreaQuantityColumns = MediaPlanning.DataAreaQuantityColumns.Clicks

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.ShowWaitForm("Loading...")

                Try

                    DataAreaQuantityColumn = CType(sender, DevComponents.DotNetBar.ButtonItem).Tag

                    If DataAreaQuantityColumn = MediaPlanning.DataAreaQuantityColumns.Clicks Then

                        _MediaPlan.MediaPlanEstimate.IsClicksCPM = CType(sender, DevComponents.DotNetBar.ButtonItem).Checked

                    ElseIf DataAreaQuantityColumn = MediaPlanning.DataAreaQuantityColumns.Units Then

                        _MediaPlan.MediaPlanEstimate.IsUnitsCPM = CType(sender, DevComponents.DotNetBar.ButtonItem).Checked

                    ElseIf DataAreaQuantityColumn = MediaPlanning.DataAreaQuantityColumns.Impressions Then

                        _MediaPlan.MediaPlanEstimate.IsImpressionsCPM = CType(sender, DevComponents.DotNetBar.ButtonItem).Checked

                    End If

                Catch ex As Exception

                End Try

                _MediaPlan.MediaPlanEstimate.RefreshEstimateDataTableData()

                RefreshMediaPlanGrandTotalAmounts()

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                PivotGridForm_MediaPlanDetail.RefreshData()

                PivotGridForm_MediaPlanDetail.EndUpdate()

                _MediaPlan.EstimateChangedEvent()

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemRateCPMLevelLine_SubItem_CheckedChanged(sender As Object, e As EventArgs)

            'objects
            Dim DataAreaQuantityColumn As AdvantageFramework.MediaPlanning.DataAreaQuantityColumns = AdvantageFramework.MediaPlanning.DataAreaQuantityColumns.Clicks
            Dim PivotGridHitInfo As DevExpress.XtraPivotGrid.PivotGridHitInfo = Nothing
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing

            If TypeOf ButtonItemDataArea_RateCPM.Tag Is DevExpress.XtraPivotGrid.PivotGridHitInfo Then

                Me.ShowWaitForm("Loading...")

                Try

                    PivotGridHitInfo = ButtonItemDataArea_RateCPM.Tag

                Catch ex As Exception
                    PivotGridHitInfo = Nothing
                End Try

                If PivotGridHitInfo IsNot Nothing Then

                    If PivotGridHitInfo.ValueInfo IsNot Nothing Then

                        Try

                            PivotDrillDownDataSource = PivotGridHitInfo.ValueInfo.CreateDrillDownDataSource

                        Catch ex As Exception
                            PivotDrillDownDataSource = Nothing
                        End Try

                        If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                            RowIndexes = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Select(Function(PDDDR) CInt(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).Distinct.ToList

                            If CType(sender, DevComponents.DotNetBar.ButtonItem).Checked Then

                                DataAreaQuantityColumn = CType(sender, DevComponents.DotNetBar.ButtonItem).Tag

                                For Each MediaPlanDetailLevelLine In _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Where(Function(Entity) RowIndexes.Contains(Entity.RowIndex) = True).ToList

                                    MediaPlanDetailLevelLine.QuantityColumn = DataAreaQuantityColumn
                                    MediaPlanDetailLevelLine.IsCPM = False

                                Next

                            Else

                                For Each MediaPlanDetailLevelLine In _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Where(Function(Entity) RowIndexes.Contains(Entity.RowIndex) = True).ToList

                                    MediaPlanDetailLevelLine.QuantityColumn = 0
                                    MediaPlanDetailLevelLine.IsCPM = False

                                Next

                            End If

                            ButtonItemCMB_DataArea.ClosePopup()

                            _MediaPlan.MediaPlanEstimate.LevelAndLinesDataTableColumnDefinitionChanged()

                            _MediaPlan.MediaPlanEstimate.RefreshEstimateDataTableData(RowIndexes)

                            RefreshMediaPlanGrandTotalAmounts()

                            PivotGridForm_MediaPlanDetail.BeginUpdate()

                            PivotGridForm_MediaPlanDetail.RefreshData()

                            PivotGridForm_MediaPlanDetail.EndUpdate()

                            _MediaPlan.EstimateChangedEvent()

                        End If

                    End If

                End If

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemRateCPMLevelLineQuantity_SubItem_ValueChanged(sender As Object, e As EventArgs)

            'objects
            Dim PivotGridHitInfo As DevExpress.XtraPivotGrid.PivotGridHitInfo = Nothing
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing
            Dim DataAreaQuantityColumn As AdvantageFramework.MediaPlanning.DataAreaQuantityColumns = AdvantageFramework.MediaPlanning.Methods.DataAreaQuantityColumns.Clicks
            Dim IsCPM As Boolean = False

            If TypeOf ButtonItemDataArea_RateCPM.Tag Is DevExpress.XtraPivotGrid.PivotGridHitInfo Then

                Me.ShowWaitForm("Loading...")

                Try

                    PivotGridHitInfo = ButtonItemDataArea_RateCPM.Tag

                Catch ex As Exception
                    PivotGridHitInfo = Nothing
                End Try

                If PivotGridHitInfo IsNot Nothing Then

                    If PivotGridHitInfo.ValueInfo IsNot Nothing Then

                        Try

                            PivotDrillDownDataSource = PivotGridHitInfo.ValueInfo.CreateDrillDownDataSource

                        Catch ex As Exception
                            PivotDrillDownDataSource = Nothing
                        End Try

                        If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                            RowIndexes = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Select(Function(PDDDR) CInt(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).Distinct.ToList

                            DataAreaQuantityColumn = CType(sender, DevComponents.DotNetBar.SwitchButtonItem).Parent.Tag
                            IsCPM = CType(sender, DevComponents.DotNetBar.SwitchButtonItem).Value

                            For Each MediaPlanDetailLevelLine In _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Where(Function(Entity) RowIndexes.Contains(Entity.RowIndex) = True).ToList

                                MediaPlanDetailLevelLine.QuantityColumn = DataAreaQuantityColumn
                                MediaPlanDetailLevelLine.IsCPM = IsCPM

                            Next

                            _MediaPlan.MediaPlanEstimate.RefreshEstimateDataTableData(RowIndexes)

                            RefreshMediaPlanGrandTotalAmounts()

                            PivotGridForm_MediaPlanDetail.BeginUpdate()

                            PivotGridForm_MediaPlanDetail.RefreshData()

                            PivotGridForm_MediaPlanDetail.EndUpdate()

                            _MediaPlan.MediaPlanEstimate.FieldsChanged()

                            _MediaPlan.EstimateChangedEvent()

                        End If

                    End If

                End If

                Me.CloseWaitForm()

            End If

        End Sub
        'Private Sub ButtonItemDataOptions_CalculateDollars_CheckedChanged(sender As Object, e As EventArgs)

        '	'objects
        '	Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

        '	If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

        '		Try

        '			PivotGridField = PivotGridForm_MediaPlanDetail.Fields(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString)

        '		Catch ex As Exception
        '			PivotGridField = Nothing
        '		End Try

        '		If PivotGridField IsNot Nothing Then

        '			PivotGridField.Options.AllowEdit = Not ButtonItemDataOptions_CalculateDollars.Checked

        '		End If

        '		_MediaPlan.MediaPlanEstimate.CalculateDollars = ButtonItemDataOptions_CalculateDollars.Checked

        '		_MediaPlan.MediaPlanEstimate.RefreshEstimateDataTableData()

        '		PivotGridForm_MediaPlanDetail.RefreshData()

        '		RefreshMediaPlanGrandTotalAmounts()

        '	End If

        'End Sub
        Private Sub ButtonItemShowDaysOfWeek_AsLevel_Click(sender As Object, e As EventArgs) Handles ButtonItemShowDaysOfWeek_AsLevel.Click

            'objects
            Dim DaysOfWeekType As AdvantageFramework.MediaPlanning.DaysOfWeeksType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.None

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                If ButtonItemShowDaysOfWeek_AsLevel.Checked = False Then

                    DaysOfWeekType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.AsLevel
                    ButtonItemShowDaysOfWeek_AsLevel.Checked = True
                    ButtonItemShowDaysOfWeek_OverrideDataWithMerge.Checked = False
                    ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge.Checked = False

                Else

                    DaysOfWeekType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.None
                    ButtonItemShowDaysOfWeek_AsLevel.Checked = False

                End If

                If _MediaPlan.SyncDetailSettings Then

                    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                        MediaPlanEstimate.DaysOfWeekType = DaysOfWeekType

                    Next

                Else

                    _MediaPlan.MediaPlanEstimate.DaysOfWeekType = DaysOfWeekType

                End If

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                AddDaysOfWeekField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                PivotGridForm_MediaPlanDetail.EndUpdate()

            End If

        End Sub
        Private Sub ButtonItemShowDaysOfWeek_OverrideDataWithMerge_Click(sender As Object, e As EventArgs) Handles ButtonItemShowDaysOfWeek_OverrideDataWithMerge.Click

            'objects
            Dim DaysOfWeekType As AdvantageFramework.MediaPlanning.DaysOfWeeksType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.None

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                If ButtonItemShowDaysOfWeek_OverrideDataWithMerge.Checked = False Then

                    DaysOfWeekType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.OverrideDataWithMerge
                    ButtonItemShowDaysOfWeek_OverrideDataWithMerge.Checked = True
                    ButtonItemShowDaysOfWeek_AsLevel.Checked = False
                    ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge.Checked = False

                Else

                    DaysOfWeekType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.None
                    ButtonItemShowDaysOfWeek_OverrideDataWithMerge.Checked = False

                End If

                If _MediaPlan.SyncDetailSettings Then

                    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                        MediaPlanEstimate.DaysOfWeekType = DaysOfWeekType

                    Next

                Else

                    _MediaPlan.MediaPlanEstimate.DaysOfWeekType = DaysOfWeekType

                End If

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                AddDaysOfWeekField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                PivotGridForm_MediaPlanDetail.EndUpdate()

            End If

        End Sub
        Private Sub ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge_Click(sender As Object, e As EventArgs) Handles ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge.Click

            'objects
            Dim DaysOfWeekType As AdvantageFramework.MediaPlanning.DaysOfWeeksType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.None

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                If ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge.Checked = False Then

                    DaysOfWeekType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.OverrideDataWithoutMerge
                    ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge.Checked = True
                    ButtonItemShowDaysOfWeek_OverrideDataWithMerge.Checked = False
                    ButtonItemShowDaysOfWeek_AsLevel.Checked = False

                Else

                    DaysOfWeekType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.None
                    ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge.Checked = False

                End If

                If _MediaPlan.SyncDetailSettings Then

                    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                        MediaPlanEstimate.DaysOfWeekType = DaysOfWeekType

                    Next

                Else

                    _MediaPlan.MediaPlanEstimate.DaysOfWeekType = DaysOfWeekType

                End If

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                AddDaysOfWeekField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                PivotGridForm_MediaPlanDetail.EndUpdate()

            End If

        End Sub
        Private Sub ButtonItemDataOptions_ShowPackageLevel_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemDataOptions_ShowPackageLevel.CheckedChanged

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                _MediaPlan.MediaPlanEstimate.ShowPackageName = ButtonItemDataOptions_ShowPackageLevel.Checked

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                ShowPackageLevelsField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                PivotGridForm_MediaPlanDetail.EndUpdate()

                Try

                    PivotGridField = PivotGridForm_MediaPlanDetail.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowPackageLevels.ToString)

                Catch ex As Exception
                    PivotGridField = Nothing
                End Try

                If PivotGridField IsNot Nothing Then

                    PivotGridForm_MediaPlanDetail.RaiseFieldAreaIndexChangedEvent(PivotGridField)

                End If

            End If

        End Sub
        Private Sub ButtonItemDataOptions_ShowAdSizes_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemDataOptions_ShowAdSizes.CheckedChanged

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                _MediaPlan.MediaPlanEstimate.ShowAdSizes = ButtonItemDataOptions_ShowAdSizes.Checked

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                ShowAdSizesField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                PivotGridForm_MediaPlanDetail.EndUpdate()

                Try

                    PivotGridField = PivotGridForm_MediaPlanDetail.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowAdSizes.ToString)

                Catch ex As Exception
                    PivotGridField = Nothing
                End Try

                If PivotGridField IsNot Nothing Then

                    PivotGridForm_MediaPlanDetail.RaiseFieldAreaIndexChangedEvent(PivotGridField)

                End If

            End If

        End Sub
        Private Sub ButtonItemDataOptions_ShowDateRange_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemDataOptions_ShowDateRange.CheckedChanged

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                _MediaPlan.MediaPlanEstimate.ShowDateRange = ButtonItemDataOptions_ShowDateRange.Checked

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                ShowDateRangeField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                PivotGridForm_MediaPlanDetail.EndUpdate()

                Try

                    PivotGridField = PivotGridForm_MediaPlanDetail.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowDateRange.ToString)

                Catch ex As Exception
                    PivotGridField = Nothing
                End Try

                If PivotGridField IsNot Nothing Then

                    PivotGridForm_MediaPlanDetail.RaiseFieldAreaIndexChangedEvent(PivotGridField)

                End If

            End If

        End Sub
        Private Sub ButtonItemExport_Estimate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_Estimate.Click

            If _MediaPlan IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                Print(Me.DefaultLookAndFeel.LookAndFeel, Me.Session, _MediaPlan, New Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)({_MediaPlan.MediaPlanEstimate}), ButtonItemOptions_ShowHiatusDates.Checked, ButtonItemOptions_AddColumnsHeadersToAllEstimates.Checked)

            End If

        End Sub
        Private Sub ButtonItemExport_AllEstimates_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_AllEstimates.Click

            If _MediaPlan IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimates IsNot Nothing Then

                Print(Me.DefaultLookAndFeel.LookAndFeel, Me.Session, _MediaPlan, _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).OrderBy(Function(MPE) MPE.OrderNumber).ToList, ButtonItemOptions_ShowHiatusDates.Checked, ButtonItemOptions_AddColumnsHeadersToAllEstimates.Checked)

            End If

        End Sub
        Private Sub ButtonItemHeaderFooterImages_Manage_Click(sender As Object, e As EventArgs) Handles ButtonItemHeaderFooterImages_Manage.Click

            AdvantageFramework.Maintenance.General.Presentation.ImageSetupForm.ShowFormDialog()

        End Sub
        Private Sub ButtonItemExport_FlowChart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_FlowChart.Click

            'objects
            Dim FlowChart As AdvantageFramework.MediaPlanning.FlowChart.FlowChart = Nothing
            Dim FlowChartBuilder As AdvantageFramework.MediaPlanning.FlowChart.FlowChartBuilder = Nothing
            Dim FileName As String = String.Empty
            Dim FileNameCounter As Integer = 0
            Dim FileNameTemplate As String = String.Empty
            Dim Folder As String = String.Empty
            Dim MediaPlanFlowChartOptions As AdvantageFramework.Database.Entities.MediaPlanFlowChartOptions = Nothing
            Dim IsASP As Boolean = False
            Dim SaveFlowChartToDisk As Boolean = False

            If _MediaPlan IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimates.Count > 0 Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    MediaPlanFlowChartOptions = AdvantageFramework.Database.Procedures.MediaPlanFlowChartOptions.LoadByUserCode(DbContext, Me.Session.UserCode)

                End Using

                If _FlowChartMediaPlanOptions Is Nothing Then

                    If MediaPlanFlowChartOptions IsNot Nothing Then

                        _FlowChartMediaPlanOptions = New AdvantageFramework.MediaPlanning.FlowChart.FlowChartMediaPlanOptions(_MediaPlan, MediaPlanFlowChartOptions)

                    Else

                        _FlowChartMediaPlanOptions = New AdvantageFramework.MediaPlanning.FlowChart.FlowChartMediaPlanOptions(_MediaPlan)

                    End If

                    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).OrderBy(Function(Entity) Entity.OrderNumber).ToList

                        _FlowChartMediaPlanOptions.FlowChartMediaPlanEstimateOptions.Add(New AdvantageFramework.MediaPlanning.FlowChart.FlowChartMediaPlanEstimateOptions(_FlowChartMediaPlanOptions) With {.MediaPlanDetailID = MediaPlanEstimate.ID,
                                                                                                                                                                                                            .Estimate = MediaPlanEstimate.Name,
                                                                                                                                                                                                            .DisplayValue = _FlowChartMediaPlanOptions.GrandTotalsDisplayValue,
                                                                                                                                                                                                            .PrintDateHeader = True,
                                                                                                                                                                                                            .ShowEstimateRowTotals = True})

                    Next

                End If

                If MediaPlanFlowChartOptionsDialog.ShowFormDialog(_MediaPlan, _FlowChartMediaPlanOptions) = System.Windows.Forms.DialogResult.OK Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

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

                End If

            End If

        End Sub
        Private Sub ButtonItemData_CreateOrders_Click(sender As Object, e As EventArgs) Handles ButtonItemData_CreateOrders.Click

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataFilter As AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData = Nothing
            Dim EstimateMediaPlanOrderGrouping As AdvantageFramework.Exporting.MediaPlanOrderGroupings = Nothing
            Dim MediaPlanningDataList As Generic.List(Of AdvantageFramework.Exporting.DataClasses.MediaPlanningData) = Nothing
            Dim CreateOrderBroadcastCalendarType As AdvantageFramework.MediaPlanning.CreateOrderBroadcastCalendarType = Nothing
            Dim ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim ErrorMessage As String = Nothing
            Dim ContinueToCreateOrders As Boolean = True
            Dim CreateOrderOption As AdvantageFramework.MediaPlanning.CreateOrderOptions = AdvantageFramework.MediaPlanning.Methods.CreateOrderOptions.Default
            Dim OrderGroupingLevelLinesDataTable As System.Data.DataTable = Nothing
            Dim DoesHaveCustomDates As Boolean = False

            Me.FormAction = WinForm.Presentation.FormActions.Loading
            Me.ShowWaitForm("Loading...")

            If _MediaPlan.IsAttachedToBroadcastWorksheet = False Then

                If _MediaPlan.HasPendingOrders = False Then

                    If ButtonItemActions_Save.Enabled Then

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                        Me.CloseWaitForm()

                        If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes to export the latest media plan data.  Do you want to save your changes now?", WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = WinForm.MessageBox.DialogResults.Yes Then

                            Me.FormAction = WinForm.Presentation.FormActions.Saving
                            Me.ShowWaitForm("Saving...")

                            Try

                                ContinueToCreateOrders = SaveChanges(ErrorMessage)

                            Catch ex As Exception
                                ContinueToCreateOrders = False
                            End Try

                            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                            Me.CloseWaitForm()

                            If ContinueToCreateOrders = False Then

                                AdvantageFramework.WinForm.MessageBox.Show("Failed saving this media plan.  Please contact Software Support." & System.Environment.NewLine & ErrorMessage)

                            End If

                        Else

                            ContinueToCreateOrders = False

                        End If

                    End If

                    If ContinueToCreateOrders AndAlso _MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate.ID > 0 Then

                        DataFilter = New AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData(_MediaPlanID, _MediaPlan.MediaPlanEstimate.ID)

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                        Me.CloseWaitForm()

                        CreateOrderOption = _MediaPlan.MediaPlanEstimate.CreateOrderOption

                        If AdvantageFramework.Media.Presentation.MediaPlanOrderBillDialog.ShowFormDialog(_MediaPlanID, _MediaPlan.MediaPlanEstimate.ID, DataFilter, DataTable,
                                                                                                         OrderGroupingLevelLinesDataTable, EstimateMediaPlanOrderGrouping,
                                                                                                         CreateOrderBroadcastCalendarType, CreateOrderOption, DoesHaveCustomDates) = Windows.Forms.DialogResult.OK Then

                            Me.FormAction = WinForm.Presentation.FormActions.Loading
                            Me.ShowWaitForm("Loading...")

                            If AdvantageFramework.Media.Presentation.OkayToCreateMediaPlanOrders(DataTable, OrderGroupingLevelLinesDataTable, EstimateMediaPlanOrderGrouping, MediaPlanningDataList, ErrorMessage) Then

                                ImportOrderList = GetImportOrderList(Me.Session, _MediaPlan, DataFilter, OrderGroupingLevelLinesDataTable, MediaPlanningDataList, EstimateMediaPlanOrderGrouping, CreateOrderBroadcastCalendarType)

                                If AdvantageFramework.Media.Presentation.MediaPlanCreateOrders(ImportOrderList, CreateOrderOption, _MediaPlan, EstimateMediaPlanOrderGrouping, MediaPlanningDataList, OrderGroupingLevelLinesDataTable) Then

                                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading
                                    Me.ShowWaitForm()

                                    PivotGridForm_MediaPlanDetail.BeginUpdate()

                                    Try

                                        LoadPivotGrid(Me.Session, PivotGridForm_MediaPlanDetail, _MediaPlan.DbContext, _MediaPlan.MediaPlanEstimate)

                                    Catch ex As Exception

                                    End Try

                                    PivotGridForm_MediaPlanDetail.EndUpdate()

                                    'AddDaysOfWeekField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)
                                    'ShowPackageLevelsField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)
                                    'ShowDateRangeField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)
                                    'ShowAdSizesField(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                                    SetExpandedValuesForPivotGrid(PivotGridForm_MediaPlanDetail, _MediaPlan.MediaPlanEstimate)

                                    RefreshMediaPlanGrandTotalAmounts()

                                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                                    Me.CloseWaitForm()

                                    EnableOrDisableEstimateActions()

                                End If

                            ElseIf String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                            End If

                        End If

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("There are pending orders needing to be processed before this plan can create\revise any orders.")

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Orders cannot be created from this plan estimate because it is attached to a broadcast worksheet.")

            End If

            EnableGenerateOrdersButton()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemData_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemData_Export.Click

            Dim ContinueExporting As Boolean = True
            Dim ErrorMessage As String = ""

            If ButtonItemActions_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes to export the latest media plan data.  Do you want to save your changes now?", WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = WinForm.MessageBox.DialogResults.Yes Then

                    Me.FormAction = WinForm.Presentation.FormActions.Saving
                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Saving...")

                    Try

                        ContinueExporting = SaveChanges(ErrorMessage)

                    Catch ex As Exception
                        ContinueExporting = False
                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                    If ContinueExporting = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Failed saving this media plan.  Please contact Software Support." & System.Environment.NewLine & ErrorMessage)

                    End If

                Else

                    ContinueExporting = False

                End If

            End If

            If ContinueExporting AndAlso _MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate.ID > 0 Then

                AdvantageFramework.Exporting.Presentation.ExportForm.ShowForm(Exporting.ExportTypes.MediaPlanData, False, False, New AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData(_MediaPlanID, _MediaPlan.MediaPlanEstimate.ID))

            End If

        End Sub
        Private Sub ButtonItemData_GenerateOrders_Click(sender As Object, e As EventArgs) Handles ButtonItemData_GenerateOrders.Click

            'objects
            Dim OrderNumbers As Generic.List(Of Integer) = Nothing
            Dim OrderNumberLineNumbers As Generic.List(Of String) = Nothing
            Dim MediaPlanDetailLevelLineDataList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            'Dim MediaManagerSearchSetting As AdvantageFramework.Database.Entities.MediaManagerSearchSetting = Nothing
            Dim MediaManagerReviewDetails As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing

            OrderNumbers = New Generic.List(Of Integer)
            OrderNumberLineNumbers = New Generic.List(Of String)

            If _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    MediaPlanDetailLevelLineDataList = (From Entity In AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineData.LoadByMediaPlanID(DbContext, _MediaPlan.ID)
                                                        Where Entity.MediaPlanDetailID = _MediaPlan.MediaPlanEstimate.ID AndAlso
                                                              Entity.OrderNumber.HasValue AndAlso
                                                              Entity.OrderLineNumber.HasValue).ToList

                    If MediaPlanDetailLevelLineDataList IsNot Nothing AndAlso MediaPlanDetailLevelLineDataList.Count > 0 Then

                        OrderNumberLineNumbers = (From Entity In MediaPlanDetailLevelLineDataList
                                                  Select Entity.OrderNumber.Value.ToString & "|" & Entity.OrderLineNumber.Value.ToString).ToList

                        OrderNumbers = (From Entity In MediaPlanDetailLevelLineDataList
                                        Select Entity.OrderNumber.Value).Distinct.ToList

                    End If

                End Using

                If OrderNumbers IsNot Nothing AndAlso OrderNumbers.Count > 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        'DbContext.Database.Connection.Open()
                        'DbContext.Configuration.AutoDetectChangesEnabled = False

                        'MediaManagerSearchSetting = DbContext.MediaManagerSearchSettings.Find(Me.Session.UserCode)

                        'If MediaManagerSearchSetting Is Nothing Then

                        '    MediaManagerSearchSetting = New AdvantageFramework.Database.Entities.MediaManagerSearchSetting

                        '    DbContext.MediaManagerSearchSettings.Add(MediaManagerSearchSetting)

                        'End If

                        'MediaManagerSearchSetting.UserCode = Me.Session.UserCode

                        'If _MediaPlan.MediaPlanEstimate.SalesClassType = "I" Then

                        '    MediaManagerSearchSetting.SelectInternet = True

                        'ElseIf _MediaPlan.MediaPlanEstimate.SalesClassType = "M" Then

                        '    MediaManagerSearchSetting.SelectMagazine = True

                        'ElseIf _MediaPlan.MediaPlanEstimate.SalesClassType = "N" Then

                        '    MediaManagerSearchSetting.SelectNewspaper = True

                        'ElseIf _MediaPlan.MediaPlanEstimate.SalesClassType = "O" Then

                        '    MediaManagerSearchSetting.SelectOutOfHome = True

                        'ElseIf _MediaPlan.MediaPlanEstimate.SalesClassType = "R" Then

                        '    MediaManagerSearchSetting.SelectRadio = True

                        'ElseIf _MediaPlan.MediaPlanEstimate.SalesClassType = "T" Then

                        '    MediaManagerSearchSetting.SelectTV = True

                        'End If

                        'MediaManagerSearchSetting.SelectPO = False
                        'MediaManagerSearchSetting.IncludeOrderQuoteBoth = 1
                        'MediaManagerSearchSetting.FilterBy = 0
                        'MediaManagerSearchSetting.IncludeOrderLineDates = False
                        'MediaManagerSearchSetting.IncludeJobMediaDateToBill = False
                        'MediaManagerSearchSetting.IncludeClosedOrders = False
                        'MediaManagerSearchSetting.MediaMonthStart = Nothing
                        'MediaManagerSearchSetting.MediaMonthEnd = Nothing
                        'MediaManagerSearchSetting.OrderLineStartDate = Nothing
                        'MediaManagerSearchSetting.OrderLineEndDate = Nothing
                        'MediaManagerSearchSetting.JobMediaStartDate = Nothing
                        'MediaManagerSearchSetting.JobMediaEndDate = Nothing

                        'DbContext.Configuration.AutoDetectChangesEnabled = True

                        'DbContext.SaveChanges()

                        'AdvantageFramework.MediaManager.DeleteOrderSelection(DbContext)

                        'AdvantageFramework.MediaManager.SaveOrderSelection(DbContext, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, OrderNumbers, Nothing, Nothing, Nothing, Nothing, Nothing)

                        MediaManagerReviewDetails = AdvantageFramework.MediaManager.LoadMediaManagerReviewDetails(DbContext, Nothing, Nothing, Nothing, Nothing,
                                                                                                                  Nothing, Nothing, OrderNumbers, Nothing, Nothing,
                                                                                                                  Nothing, Nothing, False, Nothing, False, Nothing, True, True)

                    End Using

                End If

            End If

            If MediaManagerReviewDetails IsNot Nothing AndAlso MediaManagerReviewDetails.Count > 0 Then

                AdvantageFramework.Media.Presentation.MediaManagerGenerateOrdersDialog.ShowFormDialog(MediaManagerReviewDetails, False)

            End If

        End Sub
        Private Sub ButtonItemData_OrderStatus_Click(sender As Object, e As EventArgs) Handles ButtonItemData_OrderStatus.Click

            If _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                AdvantageFramework.Media.Presentation.MediaPlanEstimateOrderStatusDialog.ShowFormDialog(_MediaPlan.ID, _MediaPlan.MediaPlanEstimate.ID)

            End If

        End Sub
        Private Sub ButtonItemDataArea_Hide_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDataArea_Hide.Click

            'objects
            Dim PivotGridHitInfo As DevExpress.XtraPivotGrid.PivotGridHitInfo = Nothing

            If TypeOf ButtonItemCMB_DataArea.Tag Is DevExpress.XtraPivotGrid.PivotGridHitInfo Then

                Try

                    PivotGridHitInfo = ButtonItemCMB_DataArea.Tag

                Catch ex As Exception
                    PivotGridHitInfo = Nothing
                End Try

                If PivotGridHitInfo IsNot Nothing AndAlso PivotGridHitInfo.HeadersAreaInfo IsNot Nothing Then

                    If PivotGridHitInfo.HeadersAreaInfo.Field IsNot Nothing Then

                        PivotGridHitInfo.HeadersAreaInfo.Field.Visible = False

                        _MediaPlan.EstimateChangedEvent()

                    End If

                End If

            End If

        End Sub
        Private Sub ColorPickerDropDownDataArea_RowColor_SelectedColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ColorPickerDropDownDataArea_RowColor.SelectedColorChanged

            'objects
            Dim PivotFieldValueHitInfo As DevExpress.XtraPivotGrid.PivotFieldValueHitInfo = Nothing
            Dim PivotCellEventArgs As DevExpress.XtraPivotGrid.PivotCellEventArgs = Nothing
            Dim LevelLineColor As Integer = 0
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim Color As Integer = 0
            Dim EntryDate As Date = Nothing
            Dim EntryDatesList As Generic.List(Of Date) = Nothing
            Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
            Dim DataRow As System.Data.DataRow = Nothing

            If TypeOf ColorPickerDropDownDataArea_RowColor.Tag Is DevExpress.XtraPivotGrid.PivotFieldValueHitInfo Then

                Try

                    PivotFieldValueHitInfo = ColorPickerDropDownDataArea_RowColor.Tag

                Catch ex As Exception
                    PivotFieldValueHitInfo = Nothing
                End Try

                If PivotFieldValueHitInfo IsNot Nothing Then

                    Try

                        PivotDrillDownDataSource = PivotFieldValueHitInfo.CreateDrillDownDataSource

                    Catch ex As Exception
                        PivotDrillDownDataSource = Nothing
                    End Try

                    If PivotDrillDownDataSource IsNot Nothing Then

                        If PivotDrillDownDataSource.RowCount > 0 Then

                            RowIndexes = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Select(Function(PDDDR) CInt(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).Distinct.ToList

                        End If

                        If RowIndexes IsNot Nothing Then

                            LevelLineColor = If(ColorPickerDropDownDataArea_RowColor.SelectedColor.ToArgb = -1, 0, ColorPickerDropDownDataArea_RowColor.SelectedColor.ToArgb)

                            For Each RowIndex In RowIndexes

                                For Each DataRow In _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) DR(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString) = RowIndex).ToList

                                    DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString) = LevelLineColor

                                Next

                            Next

                            '_MediaPlan.EstimateChangedEvent()

                            PivotGridForm_MediaPlanDetail.BeginUpdate()

                            PivotGridForm_MediaPlanDetail.RefreshData()

                            PivotGridForm_MediaPlanDetail.EndUpdate()

                        End If

                    End If

                End If

            ElseIf TypeOf ColorPickerDropDownDataArea_RowColor.Tag Is DevExpress.XtraPivotGrid.PivotCellEventArgs Then

                Try

                    PivotCellEventArgs = ColorPickerDropDownDataArea_RowColor.Tag

                Catch ex As Exception
                    PivotCellEventArgs = Nothing
                End Try

                If PivotCellEventArgs IsNot Nothing Then

                    Try

                        PivotDrillDownDataSource = PivotCellEventArgs.CreateDrillDownDataSource

                    Catch ex As Exception
                        PivotDrillDownDataSource = Nothing
                    End Try

                    If PivotDrillDownDataSource IsNot Nothing Then

                        If PivotDrillDownDataSource.RowCount > 0 Then

                            RowIndexes = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Select(Function(PDDDR) CInt(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).Distinct.ToList

                            EntryDatesList = New Generic.List(Of Date)

                            For Each PDDDR In PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).ToList

                                EntryDate = Date.MinValue

                                Try

                                    EntryDate = PDDDR(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString)

                                Catch ex As Exception
                                    EntryDate = Date.MinValue
                                End Try

                                If EntryDate <> Date.MinValue Then

                                    EntryDatesList.Add(EntryDate)

                                End If

                            Next

                        End If

                        If RowIndexes IsNot Nothing Then

                            Color = If(ColorPickerDropDownDataArea_RowColor.SelectedColor.ToArgb = -1, 0, ColorPickerDropDownDataArea_RowColor.SelectedColor.ToArgb)

                            For Each EntryDate In EntryDatesList

                                For Each RowIndex In RowIndexes

                                    Try

                                        MediaPlanDetailLevelLineData = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.SingleOrDefault(Function(Entity) Entity.RowIndex = RowIndex AndAlso
                                                                                                                                                                   Entity.StartDate = EntryDate)

                                    Catch ex As Exception
                                        MediaPlanDetailLevelLineData = Nothing
                                    End Try

                                    Try

                                        DataRow = _MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) RowIndex = DR(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) AndAlso
                                                                                                                                                                  EntryDate = DR(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString))

                                    Catch ex As Exception
                                        DataRow = Nothing
                                    End Try

                                    If DataRow IsNot Nothing AndAlso MediaPlanDetailLevelLineData IsNot Nothing Then

                                        DataRow(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString) = Color
                                        MediaPlanDetailLevelLineData.Color = Color

                                    End If

                                Next

                            Next

                            '_MediaPlan.EstimateChangedEvent()

                            PivotGridForm_MediaPlanDetail.BeginUpdate()

                            PivotGridForm_MediaPlanDetail.RefreshData()

                            PivotGridForm_MediaPlanDetail.EndUpdate()

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemDataArea_SetNote_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDataArea_SetNote.Click

            'objects
            Dim PivotGridHitInfo As DevExpress.XtraPivotGrid.PivotGridHitInfo = Nothing
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing
            Dim Note As String = ""
            Dim RowIndex As Integer = -1
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim EntryDate As Date = Nothing
            Dim EntryDatesList As Generic.List(Of Date) = Nothing
            Dim FromDate As Date = Nothing
            Dim ToDate As Date = Nothing
            Dim DataColumn As AdvantageFramework.MediaPlanning.DataColumns = AdvantageFramework.MediaPlanning.DataColumns.Date

            If TypeOf ButtonItemDataArea_SetNote.Tag Is DevExpress.XtraPivotGrid.PivotGridHitInfo Then

                Try

                    PivotGridHitInfo = ButtonItemDataArea_SetNote.Tag

                Catch ex As Exception
                    PivotGridHitInfo = Nothing
                End Try

                If PivotGridHitInfo IsNot Nothing Then

                    If PivotGridHitInfo.CellInfo IsNot Nothing Then

                        Try

                            PivotDrillDownDataSource = PivotGridHitInfo.CellInfo.CreateDrillDownDataSource

                        Catch ex As Exception
                            PivotDrillDownDataSource = Nothing
                        End Try

                    ElseIf PivotGridHitInfo.ValueInfo IsNot Nothing Then

                        Try

                            PivotDrillDownDataSource = PivotGridHitInfo.ValueInfo.CreateDrillDownDataSource

                        Catch ex As Exception
                            PivotDrillDownDataSource = Nothing
                        End Try

                    End If

                    If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                        EntryDatesList = New Generic.List(Of Date)

                        For Each PDDDR In PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).ToList

                            EntryDate = Date.MinValue

                            Try

                                EntryDate = PDDDR(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString)

                            Catch ex As Exception
                                EntryDate = Date.MinValue
                            End Try

                            If EntryDate <> Date.MinValue Then

                                If _MediaPlan.MediaPlanEstimate.IsOnHiatusDate(EntryDate) = False Then

                                    EntryDatesList.Add(EntryDate)

                                End If

                            End If

                        Next

                    End If

                    If EntryDatesList IsNot Nothing AndAlso EntryDatesList.Count > 0 AndAlso PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                        Try

                            Note = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Where(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) IsNot System.DBNull.Value AndAlso PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) <> "").Select(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString)).Max

                        Catch ex As Exception
                            Note = ""
                        End Try

                        If AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("Set Note", "Enter a note:", Note, Note, AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.Note) = Windows.Forms.DialogResult.OK Then

                            RowIndexes = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Select(Function(PDDDR) CInt(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).Distinct.ToList

                            If RowIndexes.Count > 0 Then

                                SetNote(Note, EntryDatesList, RowIndexes)

                                _MediaPlan.MediaPlanEstimate.FieldsChanged()

                                _MediaPlan.EstimateChangedEvent()

                                PivotGridForm_MediaPlanDetail.RefreshData()

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemGridOptions_ShowHideFieldList_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemGridOptions_ShowHideFieldList.CheckedChanged

            Try

                If ButtonItemGridOptions_ShowHideFieldList.Checked Then

                    If PivotGridForm_MediaPlanDetail.CustomizationForm Is Nothing Then

                        PivotGridForm_MediaPlanDetail.FieldsCustomization()

                    End If

                Else

                    If PivotGridForm_MediaPlanDetail.CustomizationForm IsNot Nothing Then

                        PivotGridForm_MediaPlanDetail.DestroyCustomization()

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemGridOptions_FreezeLevels_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemGridOptions_FreezeLevels.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None AndAlso
                    _MediaPlan IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                _MediaPlan.MediaPlanEstimate.FreezeLevels = ButtonItemGridOptions_FreezeLevels.Checked

                PivotGridForm_MediaPlanDetail.BeginUpdate()

                If _MediaPlan.MediaPlanEstimate.FreezeLevels Then

                    PivotGridForm_MediaPlanDetail.OptionsBehavior.HorizontalScrolling = DevExpress.XtraPivotGrid.PivotGridScrolling.CellsArea

                Else

                    PivotGridForm_MediaPlanDetail.OptionsBehavior.HorizontalScrolling = DevExpress.XtraPivotGrid.PivotGridScrolling.Control

                End If

                PivotGridForm_MediaPlanDetail.EndUpdate()

            End If

        End Sub
        Private Sub ButtonItemDataArea_SetPrefix_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDataArea_SetPrefix.Click

            'objects
            Dim PivotGridHitInfo As DevExpress.XtraPivotGrid.PivotGridHitInfo = Nothing
            Dim Prefix As String = ""
            Dim DefaultPrefix As String = ""

            If TypeOf ButtonItemCMB_DataArea.Tag Is DevExpress.XtraPivotGrid.PivotGridHitInfo Then

                Try

                    PivotGridHitInfo = ButtonItemCMB_DataArea.Tag

                Catch ex As Exception
                    PivotGridHitInfo = Nothing
                End Try

                If PivotGridHitInfo IsNot Nothing AndAlso PivotGridHitInfo.HeadersAreaInfo IsNot Nothing Then

                    If PivotGridHitInfo.HeadersAreaInfo.Field IsNot Nothing AndAlso PivotGridHitInfo.HeadersAreaInfo.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString Then

                        DefaultPrefix = _MediaPlan.MediaPlanEstimate.QuarterPrefix

                        If String.IsNullOrEmpty(DefaultPrefix) Then

                            DefaultPrefix = ""

                        End If

                        If AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("Set Prefix", "Enter a prefix   (ie Q, Quarter, QTR, etc)", DefaultPrefix, Prefix, AdvantageFramework.Database.Entities.MediaPlanDetailSetting.Properties.StringValue) = Windows.Forms.DialogResult.OK Then

                            PivotGridHitInfo.HeadersAreaInfo.Field.Tag = Prefix

                            If _MediaPlan.SyncDetailSettings Then

                                For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                    MediaPlanEstimate.QuarterPrefix = Prefix

                                Next

                            Else

                                _MediaPlan.MediaPlanEstimate.QuarterPrefix = Prefix

                            End If

                            PivotGridForm_MediaPlanDetail.RefreshData()

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemDataArea_SetCaption_Click(sender As Object, e As EventArgs) Handles ButtonItemDataArea_SetCaption.Click

            'objects
            Dim PivotGridHitInfo As DevExpress.XtraPivotGrid.PivotGridHitInfo = Nothing
            Dim Caption As String = ""
            Dim DefaultCaption As String = ""
            Dim FieldName As String = ""

            If TypeOf ButtonItemCMB_DataArea.Tag Is DevExpress.XtraPivotGrid.PivotGridHitInfo Then

                Try

                    PivotGridHitInfo = ButtonItemCMB_DataArea.Tag

                Catch ex As Exception
                    PivotGridHitInfo = Nothing
                End Try

                If PivotGridHitInfo IsNot Nothing AndAlso PivotGridHitInfo.HeadersAreaInfo IsNot Nothing Then

                    If PivotGridHitInfo.HeadersAreaInfo.Field IsNot Nothing Then

                        DefaultCaption = PivotGridHitInfo.HeadersAreaInfo.Field.Caption

                        If String.IsNullOrWhiteSpace(PivotGridHitInfo.HeadersAreaInfo.Field.FieldName) = False Then

                            FieldName = AdvantageFramework.StringUtilities.GetNameAsWords(PivotGridHitInfo.HeadersAreaInfo.Field.FieldName)

                        Else

                            If PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.DaysOfWeek.ToString Then

                                FieldName = "Days of Week"

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowDateRange.ToString Then

                                FieldName = "Date Range"

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CTR.ToString Then

                                FieldName = AdvantageFramework.MediaPlanning.CTRCaption

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ConversionRate.ToString Then

                                FieldName = AdvantageFramework.MediaPlanning.ConversionRateCaption

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP1.ToString Then

                                FieldName = AdvantageFramework.MediaPlanning.CPP1Caption

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP2.ToString Then

                                FieldName = AdvantageFramework.MediaPlanning.CPP2Caption

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo1.ToString Then

                                FieldName = AdvantageFramework.MediaPlanning.TotalDemo1Caption

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo2.ToString Then

                                FieldName = AdvantageFramework.MediaPlanning.TotalDemo2Caption

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalNet.ToString Then

                                FieldName = AdvantageFramework.MediaPlanning.TotalNetCaption

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.Commission.ToString Then

                                FieldName = AdvantageFramework.MediaPlanning.CommissionCaption

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString Then

                                FieldName = AdvantageFramework.MediaPlanning.NetDollarsCaption

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPI.ToString Then

                                FieldName = AdvantageFramework.MediaPlanning.CPICaption

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotals.ToString Then

                                FieldName = AdvantageFramework.MediaPlanning.GrossPercentageInTotalsCaption

                            End If

                        End If

                        If AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("Set Caption for " & FieldName, "Enter a caption:", DefaultCaption, Caption, AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Caption) = Windows.Forms.DialogResult.OK Then

                            If String.IsNullOrEmpty(Caption) OrElse Caption.Trim = "" Then

                                If String.IsNullOrWhiteSpace(PivotGridHitInfo.HeadersAreaInfo.Field.FieldName) = False Then

                                    Caption = AdvantageFramework.StringUtilities.GetNameAsWords(PivotGridHitInfo.HeadersAreaInfo.Field.FieldName)

                                Else

                                    If PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.DaysOfWeek.ToString Then

                                        Caption = "Days of Week"

                                    ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowPackageLevels.ToString Then

                                        Caption = "Package"

                                    ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowDateRange.ToString Then

                                        Caption = "Date Range"

                                    ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CTR.ToString Then

                                        Caption = AdvantageFramework.MediaPlanning.CTRCaption

                                    ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ConversionRate.ToString Then

                                        Caption = AdvantageFramework.MediaPlanning.ConversionRateCaption

                                    ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP1.ToString Then

                                        Caption = AdvantageFramework.MediaPlanning.CPP1Caption

                                    ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP2.ToString Then

                                        Caption = AdvantageFramework.MediaPlanning.CPP2Caption

                                    ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo1.ToString Then

                                        Caption = AdvantageFramework.MediaPlanning.TotalDemo1Caption

                                    ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo2.ToString Then

                                        Caption = AdvantageFramework.MediaPlanning.TotalDemo2Caption

                                    ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalNet.ToString Then

                                        Caption = AdvantageFramework.MediaPlanning.TotalNetCaption

                                    ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.Commission.ToString Then

                                        Caption = AdvantageFramework.MediaPlanning.CommissionCaption

                                    ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString Then

                                        Caption = AdvantageFramework.MediaPlanning.NetDollarsCaption

                                    ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPI.ToString Then

                                        Caption = AdvantageFramework.MediaPlanning.CPICaption

                                    ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotals.ToString Then

                                        Caption = AdvantageFramework.MediaPlanning.GrossPercentageInTotalsCaption

                                    End If

                                End If

                            End If

                            PivotGridHitInfo.HeadersAreaInfo.Field.Caption = Caption

                            If PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.DaysOfWeek.ToString Then

                                If _MediaPlan.SyncDetailSettings Then

                                    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                        MediaPlanEstimate.DaysOfWeekCaption = Caption

                                    Next

                                Else

                                    _MediaPlan.MediaPlanEstimate.DaysOfWeekCaption = Caption

                                End If

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowAdSizes.ToString Then

                                If _MediaPlan.SyncDetailSettings Then

                                    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                        MediaPlanEstimate.AdSizesCaption = Caption

                                    Next

                                Else

                                    _MediaPlan.MediaPlanEstimate.AdSizesCaption = Caption

                                End If

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowPackageLevels.ToString Then

                                If _MediaPlan.SyncDetailSettings Then

                                    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                        MediaPlanEstimate.PackageNameCaption = Caption

                                    Next

                                Else

                                    _MediaPlan.MediaPlanEstimate.PackageNameCaption = Caption

                                End If

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowDateRange.ToString Then

                                If _MediaPlan.SyncDetailSettings Then

                                    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                        MediaPlanEstimate.DateRangeCaption = Caption

                                    Next

                                Else

                                    _MediaPlan.MediaPlanEstimate.DateRangeCaption = Caption

                                End If

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CTR.ToString Then

                                If _MediaPlan.SyncDetailSettings Then

                                    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                        MediaPlanEstimate.CTRCaption = Caption

                                    Next

                                Else

                                    _MediaPlan.MediaPlanEstimate.CTRCaption = Caption

                                End If

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ConversionRate.ToString Then

                                If _MediaPlan.SyncDetailSettings Then

                                    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                        MediaPlanEstimate.ConversionRateCaption = Caption

                                    Next

                                Else

                                    _MediaPlan.MediaPlanEstimate.ConversionRateCaption = Caption

                                End If

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP1.ToString Then

                                If _MediaPlan.SyncDetailSettings Then

                                    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                        MediaPlanEstimate.CPP1Caption = Caption

                                    Next

                                Else

                                    _MediaPlan.MediaPlanEstimate.CPP1Caption = Caption

                                End If

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP2.ToString Then

                                If _MediaPlan.SyncDetailSettings Then

                                    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                        MediaPlanEstimate.CPP2Caption = Caption

                                    Next

                                Else

                                    _MediaPlan.MediaPlanEstimate.CPP2Caption = Caption

                                End If

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo1.ToString Then

                                If _MediaPlan.SyncDetailSettings Then

                                    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                        MediaPlanEstimate.TotalDemo1Caption = Caption

                                    Next

                                Else

                                    _MediaPlan.MediaPlanEstimate.TotalDemo1Caption = Caption

                                End If

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo2.ToString Then

                                If _MediaPlan.SyncDetailSettings Then

                                    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                        MediaPlanEstimate.TotalDemo2Caption = Caption

                                    Next

                                Else

                                    _MediaPlan.MediaPlanEstimate.TotalDemo2Caption = Caption

                                End If

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalNet.ToString Then

                                If _MediaPlan.SyncDetailSettings Then

                                    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                        MediaPlanEstimate.TotalNetCaption = Caption

                                    Next

                                Else

                                    _MediaPlan.MediaPlanEstimate.TotalNetCaption = Caption

                                End If

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.Commission.ToString Then

                                If _MediaPlan.SyncDetailSettings Then

                                    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                        MediaPlanEstimate.CommissionCaption = Caption

                                    Next

                                Else

                                    _MediaPlan.MediaPlanEstimate.CommissionCaption = Caption

                                End If

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString Then

                                If _MediaPlan.SyncDetailSettings Then

                                    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                        MediaPlanEstimate.NetDollarsCaption = Caption

                                    Next

                                Else

                                    _MediaPlan.MediaPlanEstimate.NetDollarsCaption = Caption

                                End If

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPI.ToString Then

                                If _MediaPlan.SyncDetailSettings Then

                                    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                        MediaPlanEstimate.CPICaption = Caption

                                    Next

                                Else

                                    _MediaPlan.MediaPlanEstimate.CPICaption = Caption

                                End If

                            ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotals.ToString Then

                                If _MediaPlan.SyncDetailSettings Then

                                    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                        MediaPlanEstimate.GrossPercentageInTotalsCaption = Caption

                                    Next

                                Else

                                    _MediaPlan.MediaPlanEstimate.GrossPercentageInTotalsCaption = Caption

                                End If

                            Else

                                If _MediaPlan.SyncDetailSettings Then

                                    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                        SaveFieldCaptionSetting(MediaPlanEstimate, PivotGridHitInfo.HeadersAreaInfo.Field.FieldName, Caption)

                                        MediaPlanEstimate.FieldsChanged()

                                    Next

                                Else

                                    SaveFieldCaptionSetting(_MediaPlan.MediaPlanEstimate, PivotGridHitInfo.HeadersAreaInfo.Field.FieldName, Caption)

                                    _MediaPlan.MediaPlanEstimate.FieldsChanged()

                                End If

                                _MediaPlan.EstimateChangedEvent()

                            End If

                            PivotGridForm_MediaPlanDetail.RefreshData()

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemChangeDisplayType_Click(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim PivotGridHitInfo As DevExpress.XtraPivotGrid.PivotGridHitInfo = Nothing
            Dim WeekDisplayType As AdvantageFramework.MediaPlanning.WeekDisplayTypes = MediaPlanning.WeekDisplayTypes.WeekStartDay

            If TypeOf ButtonItemCMB_DataArea.Tag Is DevExpress.XtraPivotGrid.PivotGridHitInfo Then

                Try

                    PivotGridHitInfo = ButtonItemCMB_DataArea.Tag

                Catch ex As Exception
                    PivotGridHitInfo = Nothing
                End Try

                Try

                    WeekDisplayType = DirectCast(sender, DevComponents.DotNetBar.ButtonItem).Tag

                Catch ex As Exception
                    WeekDisplayType = MediaPlanning.WeekDisplayTypes.WeekStartDay
                End Try

                If PivotGridHitInfo IsNot Nothing AndAlso PivotGridHitInfo.HeadersAreaInfo IsNot Nothing Then

                    If PivotGridHitInfo.HeadersAreaInfo.Field IsNot Nothing AndAlso PivotGridHitInfo.HeadersAreaInfo.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                        PivotGridHitInfo.HeadersAreaInfo.Field.Tag = WeekDisplayType

                        If _MediaPlan.SyncDetailSettings Then

                            For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                If MediaPlanEstimate.WeekDisplayType <> WeekDisplayType Then

                                    MediaPlanEstimate.WeekDisplayType = WeekDisplayType

                                End If

                            Next

                        Else

                            _MediaPlan.MediaPlanEstimate.WeekDisplayType = WeekDisplayType

                        End If

                        PivotGridForm_MediaPlanDetail.RefreshData()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemDataArea_ShowHideValues_Click(sender As Object, e As EventArgs) Handles ButtonItemDataArea_ShowHideValues.Click

            'objects
            Dim PivotGridHitInfo As DevExpress.XtraPivotGrid.PivotGridHitInfo = Nothing
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing

            If TypeOf ButtonItemCMB_DataArea.Tag Is DevExpress.XtraPivotGrid.PivotGridHitInfo Then

                Try

                    PivotGridHitInfo = ButtonItemCMB_DataArea.Tag

                Catch ex As Exception
                    PivotGridHitInfo = Nothing
                End Try

                If PivotGridHitInfo IsNot Nothing AndAlso PivotGridHitInfo.HeadersAreaInfo IsNot Nothing Then

                    If PivotGridHitInfo.HeadersAreaInfo.Field IsNot Nothing Then

                        PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowValues = Not PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowValues

                        If _MediaPlan.SyncDetailSettings Then

                            For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                SaveFieldShowInValuesSetting(MediaPlanEstimate, PivotGridHitInfo.HeadersAreaInfo.Field.FieldName, PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowValues)

                            Next

                        Else

                            SaveFieldShowInValuesSetting(_MediaPlan.MediaPlanEstimate, PivotGridHitInfo.HeadersAreaInfo.Field.FieldName, PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowValues)

                        End If

                        _MediaPlan.MediaPlanEstimate.FieldsChanged()

                        _MediaPlan.EstimateChangedEvent()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemDataArea_ShowHideTotals_Click(sender As Object, e As EventArgs) Handles ButtonItemDataArea_ShowHideTotals.Click

            'objects
            Dim PivotGridHitInfo As DevExpress.XtraPivotGrid.PivotGridHitInfo = Nothing
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing

            If TypeOf ButtonItemCMB_DataArea.Tag Is DevExpress.XtraPivotGrid.PivotGridHitInfo Then

                Try

                    PivotGridHitInfo = ButtonItemCMB_DataArea.Tag

                Catch ex As Exception
                    PivotGridHitInfo = Nothing
                End Try

                If PivotGridHitInfo IsNot Nothing AndAlso PivotGridHitInfo.HeadersAreaInfo IsNot Nothing Then

                    If PivotGridHitInfo.HeadersAreaInfo.Field IsNot Nothing Then

                        PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals = Not PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                        If PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotals.ToString Then

                            If _MediaPlan.SyncDetailSettings Then

                                For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                    MediaPlanEstimate.GrossPercentageInTotalsShowTotals = PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                                Next

                            Else

                                _MediaPlan.MediaPlanEstimate.GrossPercentageInTotalsShowTotals = PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                            End If

                        ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString Then

                            If _MediaPlan.SyncDetailSettings Then

                                For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                    MediaPlanEstimate.NetDollarsShowTotals = PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                                Next

                            Else

                                _MediaPlan.MediaPlanEstimate.NetDollarsShowTotals = PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                            End If

                        ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP1.ToString Then

                            If _MediaPlan.SyncDetailSettings Then

                                For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                    MediaPlanEstimate.CPP1ShowTotals = PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                                Next

                            Else

                                _MediaPlan.MediaPlanEstimate.CPP1ShowTotals = PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                            End If

                        ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP2.ToString Then

                            If _MediaPlan.SyncDetailSettings Then

                                For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                    MediaPlanEstimate.CPP2ShowTotals = PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                                Next

                            Else

                                _MediaPlan.MediaPlanEstimate.CPP2ShowTotals = PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                            End If

                        ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPI.ToString Then

                            If _MediaPlan.SyncDetailSettings Then

                                For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                    MediaPlanEstimate.CPIShowTotals = PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                                Next

                            Else

                                _MediaPlan.MediaPlanEstimate.CPIShowTotals = PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                            End If

                        ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CTR.ToString Then

                            If _MediaPlan.SyncDetailSettings Then

                                For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                    MediaPlanEstimate.CTRShowTotals = PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                                Next

                            Else

                                _MediaPlan.MediaPlanEstimate.CTRShowTotals = PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                            End If

                        ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ConversionRate.ToString Then

                            If _MediaPlan.SyncDetailSettings Then

                                For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                    MediaPlanEstimate.ConversionRateShowTotals = PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                                Next

                            Else

                                _MediaPlan.MediaPlanEstimate.ConversionRateShowTotals = PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                            End If

                        ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo1.ToString Then

                            If _MediaPlan.SyncDetailSettings Then

                                For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                    MediaPlanEstimate.TotalDemo1ShowTotals = PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                                Next

                            Else

                                _MediaPlan.MediaPlanEstimate.TotalDemo1ShowTotals = PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                            End If

                        ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo2.ToString Then

                            If _MediaPlan.SyncDetailSettings Then

                                For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                    MediaPlanEstimate.TotalDemo2ShowTotals = PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                                Next

                            Else

                                _MediaPlan.MediaPlanEstimate.TotalDemo2ShowTotals = PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                            End If

                        ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalNet.ToString Then

                            If _MediaPlan.SyncDetailSettings Then

                                For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                    MediaPlanEstimate.TotalNetShowTotals = PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                                Next

                            Else

                                _MediaPlan.MediaPlanEstimate.TotalNetShowTotals = PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                            End If

                        ElseIf PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.Commission.ToString Then

                            If _MediaPlan.SyncDetailSettings Then

                                For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                    MediaPlanEstimate.CommissionShowTotals = PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                                Next

                            Else

                                _MediaPlan.MediaPlanEstimate.CommissionShowTotals = PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals

                            End If

                        Else

                            If _MediaPlan.SyncDetailSettings Then

                                For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                    SaveFieldShowInTotalsSetting(MediaPlanEstimate, PivotGridHitInfo.HeadersAreaInfo.Field.FieldName, PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals)

                                Next

                            Else

                                SaveFieldShowInTotalsSetting(_MediaPlan.MediaPlanEstimate, PivotGridHitInfo.HeadersAreaInfo.Field.FieldName, PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals)

                            End If

                            _MediaPlan.MediaPlanEstimate.FieldsChanged()

                            _MediaPlan.EstimateChangedEvent()

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemDataArea_ShowHideGrandTotal_Click(sender As Object, e As EventArgs) Handles ButtonItemDataArea_ShowHideGrandTotal.Click

            'objects
            Dim PivotGridHitInfo As DevExpress.XtraPivotGrid.PivotGridHitInfo = Nothing
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing

            If TypeOf ButtonItemCMB_DataArea.Tag Is DevExpress.XtraPivotGrid.PivotGridHitInfo Then

                Try

                    PivotGridHitInfo = ButtonItemCMB_DataArea.Tag

                Catch ex As Exception
                    PivotGridHitInfo = Nothing
                End Try

                If PivotGridHitInfo IsNot Nothing AndAlso PivotGridHitInfo.HeadersAreaInfo IsNot Nothing Then

                    If PivotGridHitInfo.HeadersAreaInfo.Field IsNot Nothing Then

                        PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowGrandTotal = Not PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowGrandTotal

                        If _MediaPlan.SyncDetailSettings Then

                            For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                SaveFieldShowInGrandTotalsSetting(MediaPlanEstimate, PivotGridHitInfo.HeadersAreaInfo.Field.FieldName, PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowGrandTotal)

                            Next

                        Else

                            SaveFieldShowInGrandTotalsSetting(_MediaPlan.MediaPlanEstimate, PivotGridHitInfo.HeadersAreaInfo.Field.FieldName, PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowGrandTotal)

                        End If

                        _MediaPlan.MediaPlanEstimate.FieldsChanged()

                        _MediaPlan.EstimateChangedEvent()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemDataArea_ViewData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDataArea_ViewData.Click

            'objects
            Dim PivotGridHitInfo As DevExpress.XtraPivotGrid.PivotGridHitInfo = Nothing
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing
            Dim DataColumn As AdvantageFramework.MediaPlanning.DataColumns = AdvantageFramework.MediaPlanning.DataColumns.Date

            If TypeOf ButtonItemDataArea_ViewData.Tag Is DevExpress.XtraPivotGrid.PivotGridHitInfo Then

                Try

                    PivotGridHitInfo = ButtonItemDataArea_ViewData.Tag

                Catch ex As Exception
                    PivotGridHitInfo = Nothing
                End Try

                If PivotGridHitInfo IsNot Nothing Then

                    _PlanChangedInDialog = False

                    If PivotGridHitInfo.CellInfo IsNot Nothing Then

                        DataColumn = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.MediaPlanning.DataColumns), PivotGridHitInfo.CellInfo.GetColumnFields.Last.FieldName)

                        Try

                            PivotDrillDownDataSource = PivotGridHitInfo.CellInfo.CreateDrillDownDataSource

                        Catch ex As Exception
                            PivotDrillDownDataSource = Nothing
                        End Try

                        If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                            RowIndexes = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Select(Function(PDDDR) CInt(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).Distinct.ToList

                            Try

                                If PivotGridHitInfo.CellInfo.ColumnField IsNot Nothing AndAlso PivotGridHitInfo.CellInfo.RowField IsNot Nothing AndAlso
                                        PivotGridHitInfo.CellInfo.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value AndAlso
                                        PivotGridHitInfo.CellInfo.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

                                    StartDate = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Select(Function(PDDDR) CDate(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString))).Min
                                    EndDate = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Select(Function(PDDDR) CDate(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString))).Max

                                End If

                            Catch ex As Exception
                                StartDate = Nothing
                                EndDate = Nothing
                            End Try

                        End If

                        If StartDate = Nothing OrElse IsNothing(StartDate) OrElse StartDate < _MediaPlan.StartDate Then

                            StartDate = _MediaPlan.StartDate

                        End If

                        If DataColumn = MediaPlanning.Methods.DataColumns.Date OrElse
                                DataColumn = MediaPlanning.Methods.DataColumns.Day Then

                            EndDate = StartDate

                        ElseIf DataColumn = MediaPlanning.Methods.DataColumns.Week Then

                            If _MediaPlan.MediaPlanEstimate.IsCalendarMonth Then

                                Do Until EndDate.DayOfWeek = DayOfWeek.Saturday OrElse EndDate.Day = DateTime.DaysInMonth(EndDate.Year, EndDate.Month)

                                    EndDate = EndDate.AddDays(1)

                                Loop

                            Else

                                Do Until EndDate.DayOfWeek = DayOfWeek.Sunday

                                    EndDate = EndDate.AddDays(1)

                                Loop

                            End If

                        ElseIf DataColumn = MediaPlanning.Methods.DataColumns.Month OrElse
                                DataColumn = MediaPlanning.Methods.DataColumns.MonthName OrElse
                                DataColumn = MediaPlanning.Methods.DataColumns.Quarter OrElse
                                DataColumn = MediaPlanning.Methods.DataColumns.Year Then

                            If _MediaPlan.MediaPlanEstimate.IsCalendarMonth Then

                                Do Until EndDate.Day = DateTime.DaysInMonth(EndDate.Year, EndDate.Month)

                                    EndDate = EndDate.AddDays(1)

                                Loop

                            Else

                                Do Until EndDate.DayOfWeek = DayOfWeek.Sunday

                                    EndDate = EndDate.AddDays(1)

                                Loop

                            End If

                        End If

                        If EndDate = Nothing OrElse IsNothing(EndDate) OrElse EndDate > _MediaPlan.EndDate Then

                            EndDate = _MediaPlan.EndDate

                        End If

                        If RowIndexes Is Nothing Then

                            RowIndexes = New Generic.List(Of Integer)({PivotGridHitInfo.CellInfo.RowIndex})

                        End If

                        AdvantageFramework.Media.Presentation.MediaPlanDetailLevelLineDataDialog.ShowFormDialog(_MediaPlan, RowIndexes, StartDate, EndDate, DataColumn)

                    ElseIf PivotGridHitInfo.ValueInfo IsNot Nothing Then

                        StartDate = _MediaPlan.StartDate
                        EndDate = _MediaPlan.EndDate

                        DataColumn = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.MediaPlanning.DataColumns), PivotGridForm_MediaPlanDetail.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.ColumnArea).Last.FieldName)

                        Try

                            PivotDrillDownDataSource = PivotGridHitInfo.ValueInfo.CreateDrillDownDataSource

                        Catch ex As Exception
                            PivotDrillDownDataSource = Nothing
                        End Try

                        If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                            RowIndexes = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Select(Function(PDDDR) CInt(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).Distinct.ToList

                        End If

                        AdvantageFramework.Media.Presentation.MediaPlanDetailLevelLineDataDialog.ShowFormDialog(_MediaPlan, RowIndexes, StartDate, EndDate, DataColumn)

                    End If

                    If _PlanChangedInDialog Then

                        Me.ShowWaitForm("Loading...")

                        PivotGridForm_MediaPlanDetail.RetrieveFieldsOnLoadDataSource = False

                        PivotGridForm_MediaPlanDetail.DataSource = _MediaPlan.MediaPlanEstimate.EstimateDataTable

                        PivotGridForm_MediaPlanDetail.RetrieveFieldsOnLoadDataSource = True

                        'PivotGridForm_MediaPlanDetail.BeginUpdate()

                        PivotGridForm_MediaPlanDetail.RefreshData()

                        'PivotGridForm_MediaPlanDetail.EndUpdate()

                        Me.CloseWaitForm()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemDataArea_AddDataByAllocating_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDataArea_AddDataByAllocating.Click

            'objects
            Dim PivotGridHitInfo As DevExpress.XtraPivotGrid.PivotGridHitInfo = Nothing
            Dim StartDate As Date = Date.MinValue
            Dim EndDate As Date = Date.MinValue
            Dim RowStartDate As Date = Nothing
            Dim RowEndDate As Date = Nothing
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing
            Dim DataColumn As AdvantageFramework.MediaPlanning.DataColumns = AdvantageFramework.MediaPlanning.DataColumns.Date
            Dim RowIndex As Integer = -1

            If TypeOf ButtonItemDataArea_AddDataByAllocating.Tag Is DevExpress.XtraPivotGrid.PivotGridHitInfo Then

                Try

                    PivotGridHitInfo = ButtonItemDataArea_AddDataByAllocating.Tag

                Catch ex As Exception
                    PivotGridHitInfo = Nothing
                End Try

                If PivotGridHitInfo IsNot Nothing Then

                    _PlanChangedInDialog = False

                    If PivotGridHitInfo.CellInfo IsNot Nothing Then

                        DataColumn = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.MediaPlanning.DataColumns), PivotGridHitInfo.CellInfo.GetColumnFields.Last.FieldName)

                        Try

                            If PivotGridHitInfo.CellInfo.ColumnField IsNot Nothing AndAlso PivotGridHitInfo.CellInfo.RowField IsNot Nothing AndAlso
                                    PivotGridHitInfo.CellInfo.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value AndAlso
                                    PivotGridHitInfo.CellInfo.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

                                Try

                                    PivotDrillDownDataSource = PivotGridHitInfo.CellInfo.CreateDrillDownDataSource

                                Catch ex As Exception
                                    PivotDrillDownDataSource = Nothing
                                End Try

                                If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                                    RowIndex = PivotDrillDownDataSource.GetValue(0, AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString)

                                    StartDate = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Select(Function(PDDDR) CDate(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString))).Min
                                    EndDate = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Select(Function(PDDDR) CDate(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString))).Max

                                End If

                            End If

                        Catch ex As Exception
                            StartDate = Date.MinValue
                            EndDate = Date.MinValue
                        End Try

                        If StartDate <> Date.MinValue AndAlso EndDate <> Date.MinValue Then

                            If DataColumn = MediaPlanning.Methods.DataColumns.Date OrElse
                                    DataColumn = MediaPlanning.Methods.DataColumns.Day Then

                                EndDate = StartDate

                            ElseIf DataColumn = MediaPlanning.Methods.DataColumns.Week Then

                                If _MediaPlan.MediaPlanEstimate.IsCalendarMonth Then

                                    Do Until EndDate.DayOfWeek = DayOfWeek.Saturday OrElse EndDate.Day = DateTime.DaysInMonth(EndDate.Year, EndDate.Month)

                                        EndDate = EndDate.AddDays(1)

                                    Loop

                                Else

                                    Do Until EndDate.DayOfWeek = DayOfWeek.Sunday

                                        EndDate = EndDate.AddDays(1)

                                    Loop

                                End If

                            ElseIf DataColumn = MediaPlanning.Methods.DataColumns.Month OrElse
                                    DataColumn = MediaPlanning.Methods.DataColumns.MonthName OrElse
                                    DataColumn = MediaPlanning.Methods.DataColumns.Quarter OrElse
                                    DataColumn = MediaPlanning.Methods.DataColumns.Year Then

                                If _MediaPlan.MediaPlanEstimate.IsCalendarMonth Then

                                    Do Until EndDate.Day = DateTime.DaysInMonth(EndDate.Year, EndDate.Month)

                                        EndDate = EndDate.AddDays(1)

                                    Loop

                                Else

                                    Do Until EndDate.DayOfWeek = DayOfWeek.Sunday

                                        EndDate = EndDate.AddDays(1)

                                    Loop

                                End If

                            End If

                        End If

                        If StartDate <> Date.MinValue AndAlso EndDate <> Date.MinValue Then

                            RowStartDate = GetStartDateForRow(RowIndex)
                            RowEndDate = GetEndDateForRow(RowIndex)

                            If RowStartDate <> Date.MinValue AndAlso RowEndDate <> Date.MinValue Then

                                If (RowStartDate >= StartDate AndAlso RowStartDate <= EndDate) = True AndAlso
                                        (RowEndDate >= StartDate AndAlso RowEndDate <= EndDate) = True Then

                                    StartDate = RowStartDate
                                    EndDate = RowEndDate

                                ElseIf (RowStartDate >= StartDate AndAlso RowStartDate <= EndDate) = True AndAlso
                                        (RowEndDate >= StartDate AndAlso RowEndDate <= EndDate) = False Then

                                    StartDate = RowStartDate

                                ElseIf (RowStartDate >= StartDate AndAlso RowStartDate <= EndDate) = False AndAlso
                                        (RowEndDate >= StartDate AndAlso RowEndDate <= EndDate) = True Then

                                    EndDate = RowEndDate

                                End If

                            End If

                        End If

                        If StartDate = Date.MinValue OrElse StartDate < _MediaPlan.StartDate Then

                            StartDate = _MediaPlan.StartDate

                        End If

                        If EndDate = Date.MinValue OrElse EndDate > _MediaPlan.EndDate Then

                            EndDate = _MediaPlan.EndDate

                        End If

                        If RowIndex > -1 Then

                            AdvantageFramework.Media.Presentation.MediaPlanDetailAllocateDataDialog.ShowFormDialog(_MediaPlan, RowIndex, StartDate, EndDate, StartDate, EndDate, DataColumn)

                        End If

                    ElseIf PivotGridHitInfo.ValueInfo IsNot Nothing Then

                        Try

                            PivotDrillDownDataSource = PivotGridHitInfo.ValueInfo.CreateDrillDownDataSource

                        Catch ex As Exception
                            PivotDrillDownDataSource = Nothing
                        End Try

                        If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                            RowIndex = PivotDrillDownDataSource.GetValue(0, AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString)

                            If RowIndex > -1 Then

                                DataColumn = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.MediaPlanning.DataColumns), PivotGridForm_MediaPlanDetail.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.ColumnArea).Last.FieldName)

                                RowStartDate = GetStartDateForRow(RowIndex)

                                If RowStartDate = Date.MinValue Then

                                    StartDate = _MediaPlan.StartDate

                                Else

                                    StartDate = RowStartDate

                                End If

                                RowEndDate = GetEndDateForRow(RowIndex)

                                If RowEndDate = Date.MinValue Then

                                    EndDate = _MediaPlan.EndDate

                                Else

                                    EndDate = RowEndDate

                                End If

                                AdvantageFramework.Media.Presentation.MediaPlanDetailAllocateDataDialog.ShowFormDialog(_MediaPlan, RowIndex, StartDate, EndDate, _MediaPlan.StartDate, _MediaPlan.EndDate, DataColumn)

                            End If

                        End If

                    End If

                    If _PlanChangedInDialog Then

                        Me.ShowWaitForm("Loading...")

                        PivotGridForm_MediaPlanDetail.RetrieveFieldsOnLoadDataSource = False

                        PivotGridForm_MediaPlanDetail.DataSource = _MediaPlan.MediaPlanEstimate.EstimateDataTable

                        PivotGridForm_MediaPlanDetail.RetrieveFieldsOnLoadDataSource = True

                        'PivotGridForm_MediaPlanDetail.BeginUpdate()

                        PivotGridForm_MediaPlanDetail.RefreshData()

                        'PivotGridForm_MediaPlanDetail.EndUpdate()

                        Me.CloseWaitForm()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemDataArea_SetClearHiatus_Click(sender As Object, e As EventArgs) Handles ButtonItemDataArea_SetClearHiatus.Click

            'objects
            Dim PivotGridHitInfo As DevExpress.XtraPivotGrid.PivotGridHitInfo = Nothing
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim CellDates As Generic.List(Of Date) = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim Adding As Boolean = False
            Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
            Dim CancelAdd As Boolean = False
            Dim ShowWarning As Boolean = False

            If TypeOf ButtonItemDataArea_SetClearHiatus.Tag Is DevExpress.XtraPivotGrid.PivotGridHitInfo Then

                Try

                    PivotGridHitInfo = ButtonItemDataArea_SetClearHiatus.Tag

                Catch ex As Exception
                    PivotGridHitInfo = Nothing
                End Try

                If PivotGridHitInfo IsNot Nothing Then

                    Try

                        PivotDrillDownDataSource = PivotGridHitInfo.ValueInfo.CreateDrillDownDataSource

                    Catch ex As Exception
                        PivotDrillDownDataSource = Nothing
                    End Try

                    If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                        RowIndexes = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Select(Function(PDDDR) CInt(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).Distinct.ToList
                        CellDates = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Select(Function(PDDDR) CDate(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString))).Distinct.ToList

                        Try

                            ShowWarning = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) CellDates.Contains(CDate(MPDLLD.StartDate.ToShortDateString)) = True)

                        Catch ex As Exception
                            ShowWarning = False
                        End Try

                    End If

                    If PivotGridHitInfo.ValueInfo.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                        If _MediaPlan.MediaPlanEstimate.HiatusWeeks.Contains(PivotGridHitInfo.ValueInfo.Value) = False Then

                            If ShowWarning Then

                                If AdvantageFramework.WinForm.MessageBox.Show("WARNING: Setting Hiatus will delete all data in this range." & vbNewLine & vbNewLine & "Do you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                    _MediaPlan.MediaPlanEstimate.HiatusWeeks.Add(PivotGridHitInfo.ValueInfo.Value)
                                    Adding = True

                                Else

                                    CancelAdd = True

                                End If

                            Else

                                _MediaPlan.MediaPlanEstimate.HiatusWeeks.Add(PivotGridHitInfo.ValueInfo.Value)
                                Adding = True

                            End If

                        Else

                            _MediaPlan.MediaPlanEstimate.HiatusWeeks.Remove(PivotGridHitInfo.ValueInfo.Value)

                        End If

                        If CancelAdd = False Then

                            _MediaPlan.MediaPlanEstimate.SaveHiatusWeeks()

                        End If

                    ElseIf PivotGridHitInfo.ValueInfo.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                            PivotGridHitInfo.ValueInfo.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

                        If _MediaPlan.MediaPlanEstimate.HiatusMonths.Contains(PivotGridHitInfo.ValueInfo.Value) = False Then

                            If ShowWarning Then

                                If AdvantageFramework.WinForm.MessageBox.Show("WARNING: Setting Hiatus will delete all data in this range." & vbNewLine & vbNewLine & "Do you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                    _MediaPlan.MediaPlanEstimate.HiatusMonths.Add(PivotGridHitInfo.ValueInfo.Value)
                                    Adding = True

                                Else

                                    CancelAdd = True

                                End If

                            Else

                                _MediaPlan.MediaPlanEstimate.HiatusMonths.Add(PivotGridHitInfo.ValueInfo.Value)
                                Adding = True

                            End If

                        Else

                            _MediaPlan.MediaPlanEstimate.HiatusMonths.Remove(PivotGridHitInfo.ValueInfo.Value)

                        End If

                        If CancelAdd = False Then

                            _MediaPlan.MediaPlanEstimate.SaveHiatusMonths()

                        End If

                    End If

                    If CancelAdd = False Then

                        If Adding Then

                            If RowIndexes IsNot Nothing AndAlso CellDates IsNot Nothing Then

                                For Each RowIndex In RowIndexes

                                    For Each CellDate In CellDates

                                        Try

                                            MediaPlanDetailLevelLineData = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.SingleOrDefault(Function(MPDLLD) MPDLLD.RowIndex = RowIndex AndAlso
                                                                                                                                                                       CDate(MPDLLD.StartDate.ToShortDateString) = CDate(CellDate.ToShortDateString))

                                        Catch ex As Exception
                                            MediaPlanDetailLevelLineData = Nothing
                                        End Try

                                        If MediaPlanDetailLevelLineData IsNot Nothing Then

                                            If MediaPlanDetailLevelLineData.OrderNumber IsNot Nothing OrElse MediaPlanDetailLevelLineData.HasPendingOrders = True Then

                                                _MediaPlan.MediaPlanEstimate.ClearMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData)

                                            Else

                                                _MediaPlan.MediaPlanEstimate.RemoveMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData)

                                            End If

                                        End If

                                    Next

                                Next

                            End If

                        End If

                        _MediaPlan.MediaPlanEstimate.FieldsChanged()

                        PivotGridForm_MediaPlanDetail.RefreshData()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemDataArea_SetClearBlankCell_Click(sender As Object, e As EventArgs) Handles ButtonItemDataArea_SetClearBlankCell.Click

            'objects
            Dim PivotGridHitInfo As DevExpress.XtraPivotGrid.PivotGridHitInfo = Nothing
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing
            Dim Note As String = ""
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim EntryDate As Date = Date.MinValue
            Dim EntryDatesList As Generic.List(Of Date) = Nothing
            Dim DataColumn As AdvantageFramework.MediaPlanning.DataColumns = AdvantageFramework.MediaPlanning.DataColumns.Date

            If TypeOf ButtonItemDataArea_SetClearBlankCell.Tag Is DevExpress.XtraPivotGrid.PivotGridHitInfo Then

                Try

                    PivotGridHitInfo = ButtonItemDataArea_SetClearBlankCell.Tag

                Catch ex As Exception
                    PivotGridHitInfo = Nothing
                End Try

                If PivotGridHitInfo IsNot Nothing Then

                    If PivotGridHitInfo.CellInfo IsNot Nothing Then

                        Try

                            PivotDrillDownDataSource = PivotGridHitInfo.CellInfo.CreateDrillDownDataSource

                        Catch ex As Exception
                            PivotDrillDownDataSource = Nothing
                        End Try

                    ElseIf PivotGridHitInfo.ValueInfo IsNot Nothing Then

                        Try

                            PivotDrillDownDataSource = PivotGridHitInfo.ValueInfo.CreateDrillDownDataSource

                        Catch ex As Exception
                            PivotDrillDownDataSource = Nothing
                        End Try

                    End If

                    If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                        EntryDatesList = New Generic.List(Of Date)

                        For Each PDDDR In PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).ToList

                            EntryDate = Date.MinValue

                            Try

                                EntryDate = PDDDR(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString)

                            Catch ex As Exception
                                EntryDate = Date.MinValue
                            End Try

                            If EntryDate <> Date.MinValue Then

                                If _MediaPlan.MediaPlanEstimate.IsOnHiatusDate(EntryDate) = False Then

                                    EntryDatesList.Add(EntryDate)

                                End If

                            End If

                        Next

                    End If

                    If EntryDatesList IsNot Nothing AndAlso EntryDatesList.Count > 0 AndAlso PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                        RowIndexes = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Select(Function(PDDDR) CInt(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).Distinct.ToList

                        Try

                            Note = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Where(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) IsNot Nothing AndAlso PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) <> "").Select(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString)).Max()

                        Catch ex As Exception
                            Note = ""
                        End Try

                        If String.IsNullOrEmpty(Note) = False AndAlso Note.Trim = "" Then

                            SetNote("", EntryDatesList, RowIndexes)

                        Else

                            SetNote(" ", EntryDatesList, RowIndexes)

                        End If

                        _MediaPlan.MediaPlanEstimate.FieldsChanged()

                        _MediaPlan.EstimateChangedEvent()

                        PivotGridForm_MediaPlanDetail.RefreshData()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemPrintOrder_Change_Click(sender As Object, e As EventArgs) Handles ButtonItemPrintOrder_Change.Click

            Dim OrderNumber As Integer = 0

            If AdvantageFramework.Media.Presentation.MediaPlanDetailOrderDialog.ShowFormDialog(_MediaPlan) = Windows.Forms.DialogResult.OK Then

                OrderNumber = _MediaPlan.MediaPlanEstimate.OrderNumber

                Me.FormAction = WinForm.Presentation.FormActions.Refreshing
                Me.ShowWaitForm("Refreshing...")

                _MediaPlan.RefreshOrderNumbers()

                Try

                    LoadMediaPlanEsitmatesForComboBox()

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None

                Try

                    ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboBoxEx.SelectedValue = OrderNumber

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemDateSettings_CopyHiatusSettingsFrom_Click(sender As Object, e As EventArgs) Handles ButtonItemDateSettings_CopyHiatusSettingsFrom.Click

            If AdvantageFramework.Media.Presentation.MediaPlanDetailCopyHiatusSettingsFromDialog.ShowFormDialog(_MediaPlan, _MediaPlan.MediaPlanEstimate) = Windows.Forms.DialogResult.OK Then

                _MediaPlan.EstimateChangedEvent()

                PivotGridForm_MediaPlanDetail.RefreshData()

            End If

        End Sub
        Private Sub ButtonItemDataArea_ChangeDemo_Click(sender As Object, e As EventArgs) Handles ButtonItemDataArea_ChangeDemo.Click

            Dim MediaDemographic As AdvantageFramework.Database.Entities.MediaDemographic = Nothing

            If AdvantageFramework.Media.Presentation.MediaPlanDetailSelectDemoDialog.ShowFormDialog(_MediaPlan, _MediaPlan.MediaPlanEstimate) = Windows.Forms.DialogResult.OK Then

                If _MediaPlan.MediaPlanEstimate.MediaDemographicID.GetValueOrDefault(0) > 0 Then

                    Try

                        MediaDemographic = AdvantageFramework.Database.Procedures.MediaDemographic.LoadByID(_MediaPlan.DbContext, _MediaPlan.MediaPlanEstimate.MediaDemographicID.GetValueOrDefault(0))

                    Catch ex As Exception
                        MediaDemographic = Nothing
                    End Try

                    If MediaDemographic IsNot Nothing Then

                        PivotGridForm_MediaPlanDetail.Fields(AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString).Caption = MediaDemographic.Description

                        SaveFieldCaptionSetting(_MediaPlan.MediaPlanEstimate, AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString, MediaDemographic.Description)

                    Else

                        PivotGridForm_MediaPlanDetail.Fields(AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString).Caption = "Demo 1"

                        SaveFieldCaptionSetting(_MediaPlan.MediaPlanEstimate, AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString, "Demo 1")

                    End If

                Else

                    PivotGridForm_MediaPlanDetail.Fields(AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString).Caption = "Demo 1"

                    SaveFieldCaptionSetting(_MediaPlan.MediaPlanEstimate, AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString, "Demo 1")

                End If

                _MediaPlan.MediaPlanEstimate.FieldsChanged()

                PivotGridForm_MediaPlanDetail.RefreshData()

                _MediaPlan.EstimateChangedEvent()

            End If

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_CustomCellDisplayText(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotCellDisplayTextEventArgs) Handles PivotGridForm_MediaPlanDetail.CustomCellDisplayText

            'objects
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing
            Dim DisplayText As String = ""
            Dim RowIndexes() As Integer = Nothing
            Dim EntryDates() As Date = Nothing

            Try

                If e.ColumnField IsNot Nothing AndAlso e.RowField IsNot Nothing AndAlso e.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value AndAlso
                        e.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

                    Try

                        PivotDrillDownDataSource = e.CreateDrillDownDataSource

                    Catch ex As Exception
                        PivotDrillDownDataSource = Nothing
                    End Try

                    If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                        Try

                            If PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Any(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) IsNot Nothing AndAlso PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) <> "") Then

                                DisplayText = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Where(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) IsNot Nothing AndAlso PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) <> "").Select(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString)).Max()

                            End If

                        Catch ex As Exception
                            DisplayText = ""
                        End Try
                        'DO NOT CHANGE THIS IF STATEMENT IN ANYWAY
                        If String.IsNullOrEmpty(DisplayText) Then

                            If _MediaPlan.MediaPlanEstimate.DaysOfWeekType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.OverrideDataWithMerge OrElse
                                    _MediaPlan.MediaPlanEstimate.DaysOfWeekType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.OverrideDataWithoutMerge Then

                                Try

                                    RowIndexes = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Select(Function(PivotDrillDownDataRow) CInt(PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).ToArray

                                Catch ex As Exception
                                    RowIndexes = Nothing
                                End Try

                                Try

                                    EntryDates = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Select(Function(PivotDrillDownDataRow) CDate(PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString))).ToArray

                                Catch ex As Exception
                                    EntryDates = Nothing
                                End Try

                                If RowIndexes IsNot Nothing AndAlso RowIndexes.Count > 0 AndAlso EntryDates IsNot Nothing AndAlso EntryDates.Count > 0 Then

                                    DisplayText = AdvantageFramework.MediaPlanning.CreateDayOfWeeks(_MediaPlan.MediaPlanEstimate, RowIndexes, EntryDates)

                                End If

                            End If

                        End If
                        'DO NOT CHANGE THIS IF STATEMENT IN ANYWAY
                        If String.IsNullOrEmpty(DisplayText) = False Then

                            e.DisplayText = DisplayText

                        Else

                            If e.ColumnField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                                If _MediaPlan.MediaPlanEstimate.HiatusWeeks.Contains(e.GetFieldValue(e.ColumnField)) Then

                                    e.DisplayText = ""

                                End If

                            ElseIf e.ColumnField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                                    e.ColumnField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

                                If _MediaPlan.MediaPlanEstimate.HiatusMonths.Contains(e.GetFieldValue(e.ColumnField)) Then

                                    e.DisplayText = ""

                                End If

                            End If

                            If IsNumeric(e.DisplayText) AndAlso CDec(e.DisplayText) = 0 Then

                                e.DisplayText = ""

                            End If

                        End If

                    End If

                ElseIf e.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Total AndAlso e.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

                    If _MediaPlan.MediaPlanEstimate.ShowRowTotalsValues = False Then

                        e.DisplayText = String.Empty

                    End If

                ElseIf e.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal AndAlso e.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

                    If _MediaPlan.MediaPlanEstimate.ShowRowGrandTotalsValues = False Then

                        e.DisplayText = String.Empty

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_CustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotCustomDrawCellEventArgs) Handles PivotGridForm_MediaPlanDetail.CustomDrawCell

            'objects
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing
            Dim Color As Integer = 0
            Dim PivotCustomDrawCellEventArgs As DevExpress.XtraPivotGrid.PivotCustomDrawCellThreadSafeEventArgs = Nothing
            Dim LeftMostEqualCellIndex As Integer = 0
            Dim RightMostEqualCellIndex As Integer = 0
            Dim Width As Integer = 0
            Dim Left As Integer = 0
            Dim Right As Integer = 0
            Dim Rectangle As System.Drawing.Rectangle = Nothing
            Dim StringFormat As System.Drawing.StringFormat = Nothing
            Dim Note As String = ""
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim EntryDates As Generic.List(Of Date) = Nothing
            Dim MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim FilteredMediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim PivotGridHitInfo As DevExpress.XtraPivotGrid.PivotGridHitInfo = Nothing
            Dim IsActualized As Boolean = False

            If CType(sender, DevExpress.XtraPivotGrid.PivotGridControl).IsAsyncInProgress = False Then

                Try

                    If e.ColumnField IsNot Nothing AndAlso e.RowField IsNot Nothing AndAlso
                            e.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value AndAlso
                            e.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

                        Try

                            PivotDrillDownDataSource = e.CreateDrillDownDataSource

                        Catch ex As Exception
                            PivotDrillDownDataSource = Nothing
                        End Try

                        If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                            Try

                                RowIndexes = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Select(Function(PivotDrillDownDataRow) CInt(PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).Distinct.ToList

                            Catch ex As Exception
                                RowIndexes = Nothing
                            End Try

                            Try

                                EntryDates = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Select(Function(PivotDrillDownDataRow) CDate(PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString))).Distinct.ToList

                            Catch ex As Exception
                                EntryDates = Nothing
                            End Try

                        Else

                            EntryDates = New List(Of Date)({e.GetFieldValue(e.ColumnField)})

                            If e.IsFieldValueExpanded(e.RowField) = False Then

                                RowIndexes = _MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) DR(e.RowField.FieldName) = e.GetFieldValue(e.RowField)).Select(Function(DR) CInt(DR(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).Distinct.ToList

                            Else

                                RowIndexes = New List(Of Integer)({e.RowIndex})

                            End If

                        End If

                        Try

                            MediaPlanDetailLevelLineDatas = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) RowIndexes.Contains(Entity.RowIndex)).ToList

                        Catch ex As Exception
                            MediaPlanDetailLevelLineDatas = Nothing
                        End Try

                        FilteredMediaPlanDetailLevelLineDatas = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)

                        If MediaPlanDetailLevelLineDatas IsNot Nothing AndAlso MediaPlanDetailLevelLineDatas.Count > 0 Then

                            Try

                                For Each EntryDate In EntryDates

                                    For Each MediaPlanDetailLevelLineData In MediaPlanDetailLevelLineDatas

                                        If EntryDate >= MediaPlanDetailLevelLineData.StartDate AndAlso EntryDate <= MediaPlanDetailLevelLineData.EndDate Then

                                            FilteredMediaPlanDetailLevelLineDatas.Add(MediaPlanDetailLevelLineData)

                                        End If

                                    Next

                                Next

                            Catch ex As Exception

                            End Try

                        End If

                        If FilteredMediaPlanDetailLevelLineDatas IsNot Nothing AndAlso FilteredMediaPlanDetailLevelLineDatas.Count > 0 Then

                            Try

                                If FilteredMediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.Color <> 0) Then

                                    Color = FilteredMediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.Color <> 0).Max(Function(Entity) Entity.Color)

                                End If

                            Catch ex As Exception
                                Color = 0
                            End Try

                            Try

                                IsActualized = FilteredMediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.IsActualized = True)

                            Catch ex As Exception
                                IsActualized = False
                            End Try

                        End If

                        If Color <> 0 Then

                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(Color)

                        Else

                            e.Appearance.BackColor = System.Drawing.Color.White

                        End If

                        If IsActualized Then

                            e.Appearance.FontStyleDelta = Drawing.FontStyle.Italic

                        Else

                            e.Appearance.FontStyleDelta = Drawing.FontStyle.Regular

                        End If

                    End If

                Catch ex As Exception

                End Try

                Try

                    If e.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value AndAlso e.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

                        If PivotDrillDownDataSource Is Nothing Then

                            Try

                                PivotDrillDownDataSource = e.CreateDrillDownDataSource

                            Catch ex As Exception
                                PivotDrillDownDataSource = Nothing
                            End Try

                        End If

                        If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                            Try

                                Note = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Where(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) IsNot Nothing AndAlso PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) <> "").Select(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString)).Max()

                            Catch ex As Exception
                                Note = ""
                            End Try
                            'DO NOT CHANGE THIS IF STATEMENT IN ANYWAY
                            If String.IsNullOrEmpty(Note) = False Then

                                LeftMostEqualCellIndex = FindLeftMostEqualCell(e, Note)
                                RightMostEqualCellIndex = FindRightMostEqualCell(e, CType(sender, DevExpress.XtraPivotGrid.PivotGridControl).Cells.ColumnCount, Note) - LeftMostEqualCellIndex

                                If LeftMostEqualCellIndex = e.ColumnIndex AndAlso (LeftMostEqualCellIndex + RightMostEqualCellIndex) > e.ColumnIndex Then

                                    Width = e.Bounds.Width
                                    Left = e.Bounds.Left - Width * (e.ColumnIndex - LeftMostEqualCellIndex)
                                    Right = e.Bounds.Right + Width * (RightMostEqualCellIndex) - 1
                                    Rectangle = New System.Drawing.Rectangle(Left, e.Bounds.Top, (Right - Left) + 1, e.Bounds.Height - 1)

                                    e.Graphics.FillRectangle(e.Appearance.GetBackBrush(e.GraphicsCache), Rectangle)
                                    StringFormat = New System.Drawing.StringFormat()
                                    StringFormat.Alignment = System.Drawing.StringAlignment.Center
                                    StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

                                    e.Graphics.DrawString(e.DisplayText, e.Appearance.Font, e.Appearance.GetForeBrush(e.GraphicsCache), Rectangle, StringFormat)

                                    e.Handled = True

                                End If

                                If LeftMostEqualCellIndex < e.ColumnIndex Then

                                    e.Handled = True

                                End If

                                'If LeftMostEqualCellIndex < e.ColumnIndex AndAlso RightMostEqualCellIndex > e.ColumnIndex Then

                                '    Width = e.Bounds.Width
                                '    Left = e.Bounds.Left
                                '    'Right = e.Bounds.Right + Width * (RightMostEqualCellIndex - e.ColumnIndex) - 1
                                '    Right = e.Bounds.Right + Width * (RightMostEqualCellIndex - e.ColumnIndex) - 1
                                '    Rectangle = New System.Drawing.Rectangle(Left, e.Bounds.Top, (Right - Left) + 1, e.Bounds.Height - 1)

                                '    e.Graphics.FillRectangle(e.Appearance.GetBackBrush(e.GraphicsCache), Rectangle)
                                '    StringFormat = New System.Drawing.StringFormat()
                                '    StringFormat.Alignment = System.Drawing.StringAlignment.Center
                                '    StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

                                '    e.Graphics.DrawString(e.DisplayText, e.Appearance.Font, e.Appearance.GetForeBrush(e.GraphicsCache), Rectangle, StringFormat)

                                '    e.Handled = True

                                'End If

                            Else
                                'DO NOT CHANGE THIS IF STATEMENT IN ANYWAY
                                If _MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate.DaysOfWeekType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.OverrideDataWithMerge AndAlso String.IsNullOrEmpty(e.DisplayText) = False AndAlso IsNumeric(e.DisplayText) = False Then

                                    LeftMostEqualCellIndex = FindLeftMostEqualCellForDaysOfWeek(e, e.DisplayText)
                                    RightMostEqualCellIndex = FindRightMostEqualCellForDaysOfWeek(e, CType(sender, DevExpress.XtraPivotGrid.PivotGridControl).Cells.ColumnCount, e.DisplayText) - LeftMostEqualCellIndex

                                    If LeftMostEqualCellIndex = e.ColumnIndex AndAlso (LeftMostEqualCellIndex + RightMostEqualCellIndex) > e.ColumnIndex Then

                                        Width = e.Bounds.Width
                                        Left = e.Bounds.Left - Width * (e.ColumnIndex - LeftMostEqualCellIndex)
                                        Right = e.Bounds.Right + Width * (RightMostEqualCellIndex) - 1
                                        Rectangle = New System.Drawing.Rectangle(Left, e.Bounds.Top, (Right - Left) + 1, e.Bounds.Height - 1)

                                        e.Graphics.FillRectangle(e.Appearance.GetBackBrush(e.GraphicsCache), Rectangle)
                                        StringFormat = New System.Drawing.StringFormat()
                                        StringFormat.Alignment = System.Drawing.StringAlignment.Center
                                        StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

                                        e.Graphics.DrawString(e.DisplayText, e.Appearance.Font, e.Appearance.GetForeBrush(e.GraphicsCache), Rectangle, StringFormat)

                                        e.Handled = True

                                    End If

                                    If LeftMostEqualCellIndex < e.ColumnIndex Then

                                        e.Handled = True

                                    End If

                                End If

                            End If

                        End If

                    End If

                Catch ex As Exception

                End Try

                If e.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Total AndAlso
                    (e.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value OrElse e.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Total) Then

                    e.Appearance.BackColor = System.Drawing.Color.LightCyan
                    e.Appearance.BackColor2 = System.Drawing.Color.LightCyan

                ElseIf e.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Total AndAlso
                    (e.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value OrElse e.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Total) Then

                    e.Appearance.BackColor = System.Drawing.Color.LightCyan
                    e.Appearance.BackColor2 = System.Drawing.Color.LightCyan

                End If

                If e.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal Then

                    e.Appearance.BackColor = System.Drawing.Color.FromArgb(155, 200, 230)

                ElseIf e.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal Then

                    e.Appearance.BackColor = System.Drawing.Color.FromArgb(155, 200, 230)

                End If

            End If

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_CustomDrawFieldHeader(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotCustomDrawFieldHeaderEventArgs) Handles PivotGridForm_MediaPlanDetail.CustomDrawFieldHeader

            If CType(sender, DevExpress.XtraPivotGrid.PivotGridControl).IsAsyncInProgress = False Then

                If e.Field.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea Then

                    For Each DrawElementInfo In e.Info.InnerElements.OfType(Of DevExpress.Utils.Drawing.DrawElementInfo)()

                        If TypeOf DrawElementInfo.ElementInfo Is DevExpress.Utils.Drawing.SortedShapeObjectInfoArgs Then

                            e.Info.CaptionRect = New System.Drawing.Rectangle(e.Info.CaptionRect.Left, e.Info.CaptionRect.Top, e.Info.CaptionRect.Width + e.Info.InnerElements(0).ElementInfo.Bounds.Width, e.Info.CaptionRect.Height)
                            e.Info.InnerElements(0).ElementInfo.Bounds = System.Drawing.Rectangle.Empty

                        End If

                    Next

                End If

            End If

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_CustomDrawFieldValue(sender As Object, e As DevExpress.XtraPivotGrid.PivotCustomDrawFieldValueEventArgs) Handles PivotGridForm_MediaPlanDetail.CustomDrawFieldValue

            If _MediaPlan IsNot Nothing AndAlso CType(sender, DevExpress.XtraPivotGrid.PivotGridControl).IsAsyncInProgress = False Then

                AdvantageFramework.Media.Presentation.CustomDrawFieldValue(sender, e, _MediaPlan.MediaPlanEstimate)

            End If

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_CustomExportCell(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.CustomExportCellEventArgs) Handles PivotGridForm_MediaPlanDetail.CustomExportCell

            'objects
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing
            Dim Color As Integer = 0
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim EntryDates As Generic.List(Of Date) = Nothing
            Dim MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim FilteredMediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim IsActualized As Boolean = False

            Try

                If e.ColumnField IsNot Nothing AndAlso e.RowField IsNot Nothing AndAlso
                        e.RowValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value AndAlso
                        e.ColumnValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

                    Try

                        PivotDrillDownDataSource = DirectCast(sender, DevExpress.XtraPivotGrid.PivotGridControl).CreateDrillDownDataSource(e.ColumnIndex, e.RowIndex)

                    Catch ex As Exception
                        PivotDrillDownDataSource = Nothing
                    End Try

                    If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                        Try

                            Color = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Where(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString) <> 0).Max(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString))

                        Catch ex As Exception
                            Color = 0
                        End Try

                        Try

                            RowIndexes = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Select(Function(PivotDrillDownDataRow) CInt(PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).Distinct.ToList

                        Catch ex As Exception
                            RowIndexes = Nothing
                        End Try

                        Try

                            EntryDates = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Select(Function(PivotDrillDownDataRow) CDate(PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString))).Distinct.ToList

                        Catch ex As Exception
                            EntryDates = Nothing
                        End Try

                        Try

                            MediaPlanDetailLevelLineDatas = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) RowIndexes.Contains(Entity.RowIndex)).ToList

                        Catch ex As Exception
                            MediaPlanDetailLevelLineDatas = Nothing
                        End Try

                        FilteredMediaPlanDetailLevelLineDatas = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)

                        If MediaPlanDetailLevelLineDatas IsNot Nothing AndAlso MediaPlanDetailLevelLineDatas.Count > 0 Then

                            Try

                                For Each EntryDate In EntryDates

                                    For Each MediaPlanDetailLevelLineData In MediaPlanDetailLevelLineDatas

                                        If EntryDate >= MediaPlanDetailLevelLineData.StartDate AndAlso EntryDate <= MediaPlanDetailLevelLineData.EndDate Then

                                            FilteredMediaPlanDetailLevelLineDatas.Add(MediaPlanDetailLevelLineData)

                                        End If

                                    Next

                                Next

                            Catch ex As Exception

                            End Try

                        End If

                        If FilteredMediaPlanDetailLevelLineDatas IsNot Nothing AndAlso FilteredMediaPlanDetailLevelLineDatas.Count > 0 Then

                            Try

                                IsActualized = FilteredMediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.IsActualized = True)

                            Catch ex As Exception
                                IsActualized = False
                            End Try

                        End If

                        If Color <> 0 Then

                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(Color)

                        Else

                            e.Appearance.BackColor = System.Drawing.Color.White

                        End If

                        If IsActualized Then

                            e.Appearance.FontStyleDelta = Drawing.FontStyle.Italic

                        Else

                            e.Appearance.FontStyleDelta = Drawing.FontStyle.Regular

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_CustomFieldSort(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotGridCustomFieldSortEventArgs) Handles PivotGridForm_MediaPlanDetail.CustomFieldSort

            CustomFieldSort(sender, e)

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_CustomFieldValueCells(sender As Object, e As DevExpress.XtraPivotGrid.PivotCustomFieldValueCellsEventArgs) Handles PivotGridForm_MediaPlanDetail.CustomFieldValueCells

            If _MediaPlan IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                CustomFieldValueCells(sender, e, _MediaPlan.MediaPlanEstimate)

            End If

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_CustomGroupInterval(sender As Object, e As DevExpress.XtraPivotGrid.PivotCustomGroupIntervalEventArgs) Handles PivotGridForm_MediaPlanDetail.CustomGroupInterval

            'If _MediaPlan IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate IsNot Nothing Then

            '	CustomGroupInterval(sender, e, _MediaPlan, _MediaPlan.MediaPlanEstimate)

            'End If

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_CustomSummary(sender As Object, e As DevExpress.XtraPivotGrid.PivotGridCustomSummaryEventArgs) Handles PivotGridForm_MediaPlanDetail.CustomSummary

            CustomSummary(sender, e, _MediaPlan.MediaPlanEstimate)

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_CustomUnboundFieldData(sender As Object, e As DevExpress.XtraPivotGrid.CustomFieldDataEventArgs) Handles PivotGridForm_MediaPlanDetail.CustomUnboundFieldData

            CustomUnboundFieldData(sender, e, _MediaPlan.MediaPlanEstimate)

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_EditValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.EditValueChangedEventArgs) Handles PivotGridForm_MediaPlanDetail.EditValueChanged

            'objects
            'Dim EntryDate As Date = Nothing
            Dim Value As Object = Nothing
            Dim DecimalValue As Decimal = 0
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing
            Dim Color As Integer = 0
            Dim FocusedCell As System.Drawing.Point = Nothing
            Dim CellColumnCount As Integer = 0
            Dim CellRowCount As Integer = 0
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = -1
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim StartDate As Date = Date.MinValue
            Dim EndDate As Date = Date.MinValue
            Dim RowStartDate As Date = Nothing
            Dim RowEndDate As Date = Nothing
            Dim GroupStartDate As Date = Date.MinValue
            Dim GroupEndDate As Date = Date.MinValue

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If e.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value AndAlso
                        e.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

                    If e.DataField IsNot Nothing Then

                        Try

                            PivotDrillDownDataSource = e.CreateDrillDownDataSource()

                        Catch ex As Exception
                            PivotDrillDownDataSource = Nothing
                        End Try

                        If PivotDrillDownDataSource IsNot Nothing Then

                            If PivotDrillDownDataSource.RowCount > 0 Then

                                RowIndexes = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Select(Function(PDDDR) CInt(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).Distinct.ToList

                            End If

                            If RowIndexes Is Nothing OrElse RowIndexes.Count = 0 Then

                                RowIndexes = New Generic.List(Of Integer)({e.RowIndex})

                            End If

                            If RowIndexes.Count > 0 Then

                                If PivotDrillDownDataSource.RowCount > 0 Then

                                    Try

                                        GroupStartDate = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Select(Function(PDDDR) CDate(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString))).Min
                                        GroupEndDate = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Select(Function(PDDDR) CDate(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString))).Max

                                    Catch ex As Exception
                                        GroupStartDate = Date.MinValue
                                        GroupEndDate = Date.MinValue
                                    End Try

                                End If

                                If GroupStartDate <> Date.MinValue AndAlso GroupEndDate <> Date.MinValue Then

                                    If _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.None Then

                                        RowStartDate = GetStartDateForRow(RowIndexes(0))

                                        If RowStartDate <> Date.MinValue Then

                                            If (RowStartDate >= GroupStartDate AndAlso RowStartDate <= GroupEndDate) = True Then

                                                StartDate = RowStartDate

                                            End If

                                        End If

                                    End If

                                End If

                                If StartDate = Date.MinValue Then

                                    Try

                                        If PivotDrillDownDataSource.RowCount > 0 Then

                                            StartDate = PivotDrillDownDataSource.GetValue(0, AdvantageFramework.MediaPlanning.DataColumns.Date.ToString)

                                        End If

                                    Catch ex As Exception
                                        StartDate = Date.MinValue
                                    End Try

                                    If StartDate = Date.MinValue Then

                                        Try

                                            StartDate = e.GetFieldValue(e.ColumnField)

                                        Catch ex As Exception
                                            StartDate = Date.MinValue
                                        End Try

                                    End If

                                End If

                                If StartDate <> Date.MinValue Then

                                    Try

                                        Value = sender.EditValue

                                    Catch ex As Exception
                                        Value = Nothing
                                    End Try

                                    If IsNothing(Value) = False AndAlso CDec(Value) <> 0 Then

                                        Try

                                            DecimalValue = CDec(Value / RowIndexes.Count)

                                        Catch ex As Exception
                                            DecimalValue = 0
                                        End Try

                                        For Each RowIndex In RowIndexes

                                            Try

                                                DataRow = _MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) RowIndex = DR(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) AndAlso
                                                                                                                                                                          StartDate = DR(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString))

                                            Catch ex As Exception
                                                DataRow = Nothing
                                            End Try

                                            If DataRow Is Nothing Then

                                                DataRow = _MediaPlan.MediaPlanEstimate.AddDataRowToEstimateDataTable(Nothing, RowIndex, StartDate)

                                                _MediaPlan.MediaPlanEstimate.RefreshEntryDates()

                                            End If

                                            If DataRow IsNot Nothing Then

                                                Color = 0

                                                Try

                                                    Color = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) RowIndex = DR(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString)).Select(Function(DR) DR(AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString)).Max

                                                Catch ex As Exception
                                                    Color = 0
                                                End Try

                                                If Color = 0 Then

                                                    If _MediaPlan.MediaPlanEstimate.Color <> 0 Then

                                                        Color = _MediaPlan.MediaPlanEstimate.Color

                                                    End If

                                                End If

                                                If e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString Then

                                                    Try

                                                        If DecimalValue = 99999999.99 Then

                                                            DecimalValue = 99999999.89

                                                        End If

                                                        DataRow(e.DataField.FieldName) = CDec(FormatNumber(DecimalValue, 1))

                                                    Catch ex As Exception
                                                        DataRow(e.DataField.FieldName) = Nothing
                                                    End Try

                                                ElseIf e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString Then

                                                    Try

                                                        If DecimalValue = 99999999.99 Then

                                                            DecimalValue = 99999999.89

                                                        End If

                                                        DataRow(e.DataField.FieldName) = CDec(FormatNumber(DecimalValue, 1))

                                                    Catch ex As Exception
                                                        DataRow(e.DataField.FieldName) = Nothing
                                                    End Try

                                                ElseIf e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString Then

                                                    Try

                                                        If DecimalValue = 99999999.99 Then

                                                            DecimalValue = Math.Truncate(DecimalValue)

                                                        End If

                                                        DataRow(e.DataField.FieldName) = CDec(FormatNumber(DecimalValue, 0))

                                                    Catch ex As Exception
                                                        DataRow(e.DataField.FieldName) = Nothing
                                                    End Try

                                                ElseIf e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString Then

                                                    Try

                                                        DataRow(e.DataField.FieldName) = Value

                                                    Catch ex As Exception
                                                        DataRow(e.DataField.FieldName) = Nothing
                                                    End Try

                                                ElseIf e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString Then

                                                    Try

                                                        If DecimalValue = 99999999.99 Then

                                                            DecimalValue = Math.Truncate(DecimalValue)

                                                        End If

                                                        DataRow(e.DataField.FieldName) = CDec(FormatNumber(DecimalValue, 0))

                                                    Catch ex As Exception
                                                        DataRow(e.DataField.FieldName) = Nothing
                                                    End Try

                                                ElseIf e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString Then

                                                    Try

                                                        If DecimalValue = 99999999.99 Then

                                                            DecimalValue = Math.Truncate(DecimalValue)

                                                        End If

                                                        DataRow(e.DataField.FieldName) = CDec(FormatNumber(DecimalValue, 0))

                                                    Catch ex As Exception
                                                        DataRow(e.DataField.FieldName) = Nothing
                                                    End Try

                                                ElseIf e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString Then

                                                    Try

                                                        DataRow(e.DataField.FieldName) = CDec(FormatNumber(DecimalValue, 2))

                                                    Catch ex As Exception
                                                        DataRow(e.DataField.FieldName) = Nothing
                                                    End Try

                                                ElseIf e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString Then

                                                    Try

                                                        DataRow(e.DataField.FieldName) = CDec(FormatNumber(DecimalValue, 2))

                                                    Catch ex As Exception
                                                        DataRow(e.DataField.FieldName) = Nothing
                                                    End Try

                                                ElseIf e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString Then

                                                    Try

                                                        DataRow(e.DataField.FieldName) = CDec(FormatNumber(DecimalValue, 2))

                                                    Catch ex As Exception
                                                        DataRow(e.DataField.FieldName) = Nothing
                                                    End Try

                                                ElseIf e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.NetCharge.ToString Then

                                                    Try

                                                        DataRow(e.DataField.FieldName) = CDec(FormatNumber(DecimalValue, 2))

                                                    Catch ex As Exception
                                                        DataRow(e.DataField.FieldName) = Nothing
                                                    End Try

                                                ElseIf e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.AgencyFee.ToString Then

                                                    Try

                                                        DataRow(e.DataField.FieldName) = CDec(FormatNumber(DecimalValue, 2))

                                                    Catch ex As Exception
                                                        DataRow(e.DataField.FieldName) = Nothing
                                                    End Try

                                                End If

                                                If _MediaPlan.MediaPlanEstimate.DoesMediaPlanDetailLevelLineDataHaveData(DataRow) Then

                                                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString) = Color

                                                Else

                                                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString) = 0

                                                End If

                                            End If

                                        Next

                                    Else

                                        For Each RowIndex In RowIndexes

                                            Color = 0

                                            Try

                                                Color = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) RowIndex = DR(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString)).Select(Function(DR) DR(AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString)).Max

                                            Catch ex As Exception
                                                Color = 0
                                            End Try

                                            If Color = 0 Then

                                                If _MediaPlan.MediaPlanEstimate.Color <> 0 Then

                                                    Color = _MediaPlan.MediaPlanEstimate.Color

                                                End If

                                            End If

                                            Try

                                                DataRow = _MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) RowIndex = DR(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) AndAlso
                                                                                                                                                                          StartDate = DR(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString))

                                            Catch ex As Exception
                                                DataRow = Nothing
                                            End Try

                                            If DataRow IsNot Nothing Then

                                                Try

                                                    DataRow(e.DataField.FieldName) = System.DBNull.Value

                                                Catch ex As Exception

                                                End Try

                                                If _MediaPlan.MediaPlanEstimate.DoesMediaPlanDetailLevelLineDataHaveData(DataRow) Then

                                                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString) = Color

                                                Else

                                                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString) = 0

                                                End If

                                            End If

                                        Next

                                    End If

                                    'PivotGridForm_MediaPlanDetail.BeginUpdate()

                                    PivotGridForm_MediaPlanDetail.RefreshData()

                                    'PivotGridForm_MediaPlanDetail.EndUpdate()

                                End If

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_FieldAreaIndexChanged(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotFieldEventArgs) Handles PivotGridForm_MediaPlanDetail.FieldAreaIndexChanged

            'objects
            Dim RefreshData As Boolean = False
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If e.Field IsNot Nothing AndAlso e.Field.UnboundFieldName <> AdvantageFramework.MediaPlanning.Settings.DaysOfWeek.ToString Then

                    If e.Field.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea Then

                        Try

                            PivotGridField = PivotGridForm_MediaPlanDetail.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.RowArea).ToList.SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.DaysOfWeek.ToString)

                        Catch ex As Exception
                            PivotGridField = Nothing
                        End Try

                        If PivotGridField IsNot Nothing Then

                            PivotGridField.SetAreaPosition(DevExpress.XtraPivotGrid.PivotArea.RowArea, PivotGridForm_MediaPlanDetail.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.RowArea).Count() - 1)

                        End If

                    End If

                    If _MediaPlan.SyncDetailSettings Then

                        For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                            FieldAreaIndexChanged(e.Field, MediaPlanEstimate, RefreshData)

                            MediaPlanEstimate.FieldsChanged()

                            If RefreshData AndAlso MediaPlanEstimate Is _MediaPlan.MediaPlanEstimate Then

                                PivotGridForm_MediaPlanDetail.RefreshData()

                            End If

                        Next

                    Else

                        FieldAreaIndexChanged(e.Field, _MediaPlan.MediaPlanEstimate, RefreshData)

                        _MediaPlan.MediaPlanEstimate.FieldsChanged()

                        If RefreshData Then

                            PivotGridForm_MediaPlanDetail.RefreshData()

                        End If

                    End If

                    _MediaPlan.EstimateChangedEvent()

                    If e.Field.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea Then

                        EnableDisableShowDaysOfWeek(True)

                    End If

                End If

            End If

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_FieldPropertyChanged(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotFieldPropertyChangedEventArgs) Handles PivotGridForm_MediaPlanDetail.FieldPropertyChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If e.Field IsNot Nothing AndAlso e.PropertyName = DevExpress.XtraPivotGrid.PivotFieldPropertyName.SortOrder Then

                    If _MediaPlan.SyncDetailSettings Then

                        For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                            SaveFieldSortOrder(e, MediaPlanEstimate)

                            MediaPlanEstimate.FieldsChanged()

                        Next

                    Else

                        SaveFieldSortOrder(e, _MediaPlan.MediaPlanEstimate)

                        _MediaPlan.MediaPlanEstimate.FieldsChanged()

                    End If

                    _MediaPlan.EstimateChangedEvent()

                End If

            End If

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_FieldValueDisplayText(sender As Object, e As DevExpress.XtraPivotGrid.PivotFieldDisplayTextEventArgs) Handles PivotGridForm_MediaPlanDetail.FieldValueDisplayText

            If _MediaPlan IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                FieldValueDisplayText(sender, e, _MediaPlan.MediaPlanEstimate)

            End If

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_FieldValueCollapsed(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotFieldValueEventArgs) Handles PivotGridForm_MediaPlanDetail.FieldValueCollapsed

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If e.Field IsNot Nothing Then

                    If _MediaPlan.SyncDetailSettings Then

                        For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                            SaveExpandedValueSetting(e, MediaPlanEstimate)

                            MediaPlanEstimate.FieldsChanged()

                        Next

                    Else

                        SaveExpandedValueSetting(e, _MediaPlan.MediaPlanEstimate)

                        _MediaPlan.MediaPlanEstimate.FieldsChanged()

                    End If

                    _MediaPlan.EstimateChangedEvent()

                End If

            End If

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_FieldValueExpanded(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotFieldValueEventArgs) Handles PivotGridForm_MediaPlanDetail.FieldValueExpanded

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If e.Field IsNot Nothing Then

                    If _MediaPlan.SyncDetailSettings Then

                        For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                            SaveExpandedValueSetting(e, MediaPlanEstimate)

                            MediaPlanEstimate.FieldsChanged()

                        Next

                    Else

                        SaveExpandedValueSetting(e, _MediaPlan.MediaPlanEstimate)

                        _MediaPlan.MediaPlanEstimate.FieldsChanged()

                    End If

                    _MediaPlan.EstimateChangedEvent()

                End If

            End If

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_FieldVisibleChanged(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotFieldEventArgs) Handles PivotGridForm_MediaPlanDetail.FieldVisibleChanged

            'objects
            Dim RefreshData As Boolean = False

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If e.Field IsNot Nothing Then

                    If _MediaPlan.SyncDetailSettings Then

                        For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                            SaveFieldVisible(e.Field, MediaPlanEstimate, RefreshData)

                            MediaPlanEstimate.FieldsChanged()

                            If e.Field IsNot Nothing AndAlso e.Field.Visible = False AndAlso e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                                MediaPlanEstimate.DaysOfWeekType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.None

                            End If

                            If MediaPlanEstimate Is _MediaPlan.MediaPlanEstimate Then

                                If e.Field IsNot Nothing AndAlso e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                                    If e.Field.Visible Then

                                        ButtonItemDataOptions_ShowDaysOfWeeks.Enabled = True

                                    Else

                                        ButtonItemDataOptions_ShowDaysOfWeeks.Enabled = False

                                        ButtonItemShowDaysOfWeek_AsLevel.Checked = False
                                        ButtonItemShowDaysOfWeek_OverrideDataWithMerge.Checked = False
                                        ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge.Checked = False

                                    End If

                                End If

                                If RefreshData Then

                                    PivotGridForm_MediaPlanDetail.RefreshData()

                                End If

                            End If

                        Next

                    Else

                        SaveFieldVisible(e.Field, _MediaPlan.MediaPlanEstimate, RefreshData)

                        _MediaPlan.MediaPlanEstimate.FieldsChanged()

                        If e.Field IsNot Nothing AndAlso e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                            If e.Field.Visible Then

                                ButtonItemDataOptions_ShowDaysOfWeeks.Enabled = True

                            Else

                                _MediaPlan.MediaPlanEstimate.DaysOfWeekType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.None
                                ButtonItemDataOptions_ShowDaysOfWeeks.Enabled = False

                                ButtonItemShowDaysOfWeek_AsLevel.Checked = False
                                ButtonItemShowDaysOfWeek_OverrideDataWithMerge.Checked = False
                                ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge.Checked = False

                            End If

                        End If

                        If RefreshData Then

                            PivotGridForm_MediaPlanDetail.RefreshData()

                        End If

                    End If

                    _MediaPlan.EstimateChangedEvent()

                    If e.Field.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea Then

                        EnableDisableShowDaysOfWeek(True)

                    End If

                End If

            End If

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_FieldWidthChanged(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotFieldEventArgs) Handles PivotGridForm_MediaPlanDetail.FieldWidthChanged

            'objects
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If e.Field IsNot Nothing Then

                    If _MediaPlan.SyncDetailSettings Then

                        For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                            If String.IsNullOrWhiteSpace(e.Field.FieldName) = False Then

                                MediaPlanEstimate.SaveFieldWidth(e.Field.FieldName, If(e.Field.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea, True, False), e.Field.Width)

                            Else

                                MediaPlanEstimate.SaveFieldWidth(e.Field.UnboundFieldName, If(e.Field.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea, True, False), e.Field.Width)

                            End If

                            MediaPlanEstimate.FieldsChanged()

                        Next

                    ElseIf _MediaPlan.SyncDetailSettings = False AndAlso _MediaPlan.SyncFieldWidths = True Then

                        For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                            If String.IsNullOrWhiteSpace(e.Field.FieldName) = False AndAlso e.Field.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea Then

                                MediaPlanDetailLevel = MediaPlanEstimate.MediaPlanDetailLevels.FirstOrDefault(Function(Entity) Entity.OrderNumber = e.Field.AreaIndex)

                                MediaPlanEstimate.SaveFieldWidth(MediaPlanDetailLevel, e.Field.Width)

                            Else

                                If String.IsNullOrWhiteSpace(e.Field.FieldName) = False Then

                                    MediaPlanEstimate.SaveFieldWidth(e.Field.FieldName, If(e.Field.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea, True, False), e.Field.Width)

                                Else

                                    MediaPlanEstimate.SaveFieldWidth(e.Field.UnboundFieldName, If(e.Field.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea, True, False), e.Field.Width)

                                End If

                            End If

                            MediaPlanEstimate.FieldsChanged()

                        Next

                    Else

                        If _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                            If String.IsNullOrWhiteSpace(e.Field.FieldName) = False Then

                                _MediaPlan.MediaPlanEstimate.SaveFieldWidth(e.Field.FieldName, If(e.Field.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea, True, False), e.Field.Width)

                            Else

                                _MediaPlan.MediaPlanEstimate.SaveFieldWidth(e.Field.UnboundFieldName, If(e.Field.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea, True, False), e.Field.Width)

                            End If

                            _MediaPlan.MediaPlanEstimate.FieldsChanged()

                        End If

                    End If

                    _MediaPlan.EstimateChangedEvent()

                End If

            End If

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_HideCustomizationForm(ByVal sender As Object, ByVal e As System.EventArgs) Handles PivotGridForm_MediaPlanDetail.HideCustomizationForm

            If ButtonItemGridOptions_ShowHideFieldList.Checked Then

                ButtonItemGridOptions_ShowHideFieldList.Checked = False

            End If

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PivotGridForm_MediaPlanDetail.MouseDown

            'objects
            Dim PivotGridHitInfo As DevExpress.XtraPivotGrid.PivotGridHitInfo = Nothing
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing
            Dim Note As String = ""
            Dim DataAreaQuantityColumn As AdvantageFramework.MediaPlanning.DataAreaQuantityColumns = MediaPlanning.DataAreaQuantityColumns.Clicks
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim Color As Integer = 0

            If e.Button = Windows.Forms.MouseButtons.Right Then

                Try

                    PivotGridHitInfo = PivotGridForm_MediaPlanDetail.CalcHitInfo(e.Location)

                Catch ex As Exception
                    PivotGridHitInfo = Nothing
                End Try

                If PivotGridHitInfo IsNot Nothing Then

                    ButtonItemCMB_DataArea.Tag = PivotGridHitInfo
                    ColorPickerDropDownDataArea_RowColor.Tag = Nothing
                    ButtonItemDataArea_SetNote.Tag = Nothing
                    ButtonItemDataArea_ViewData.Tag = Nothing
                    ButtonItemDataArea_AddDataByAllocating.Tag = Nothing
                    ButtonItemDataArea_SetPrefix.Tag = Nothing
                    ButtonItemDataArea_SetCaption.Tag = Nothing
                    ButtonItemDataArea_ChangeDisplayType.Tag = Nothing
                    ButtonItemDataArea_ShowHideGrandTotal.Tag = Nothing
                    ButtonItemDataArea_ShowHideTotals.Tag = Nothing
                    ButtonItemDataArea_ShowHideValues.Tag = Nothing
                    ButtonItemDataArea_SetClearHiatus.Tag = Nothing
                    ButtonItemDataArea_SetClearBlankCell.Tag = Nothing
                    ButtonItemDataArea_RateCPM.Tag = Nothing

                    If PivotGridForm_MediaPlanDetail.CustomizationForm IsNot Nothing Then

                        ButtonItemDataArea_ShowFieldList.Icon = AdvantageFramework.My.Resources.HideFieldListIcon
                        ButtonItemDataArea_ShowFieldList.Text = "Hide Field List"

                    Else

                        ButtonItemDataArea_ShowFieldList.Icon = AdvantageFramework.My.Resources.ShowFieldListIcon
                        ButtonItemDataArea_ShowFieldList.Text = "Show Field List"

                    End If

                    ColorPickerDropDownDataArea_RowColor.Visible = False
                    ButtonItemDataArea_SetNote.Visible = False
                    ButtonItemDataArea_Hide.Visible = False
                    ButtonItemDataArea_ViewData.Visible = False
                    ButtonItemDataArea_AddDataByAllocating.Visible = False
                    ButtonItemDataArea_SetPrefix.Visible = False
                    ButtonItemDataArea_SetCaption.Visible = False
                    ButtonItemDataArea_ChangeDisplayType.Visible = False
                    ButtonItemDataArea_ShowHideGrandTotal.Visible = False
                    ButtonItemDataArea_ShowHideTotals.Visible = False
                    ButtonItemDataArea_ShowHideValues.Visible = False
                    ButtonItemDataArea_ShowFieldList.Visible = True
                    ButtonItemDataArea_SetClearHiatus.Visible = False
                    ButtonItemDataArea_SetClearBlankCell.Visible = False
                    ButtonItemDataArea_RateCPM.Visible = False
                    ButtonItemDataArea_ChangeDemo.Visible = False

                    If PivotGridHitInfo.HitTest = DevExpress.XtraPivotGrid.PivotGridHitTest.HeadersArea Then

                        ColorPickerDropDownDataArea_RowColor.Visible = False
                        ButtonItemDataArea_ViewData.Visible = False
                        ButtonItemDataArea_AddDataByAllocating.Visible = False
                        ButtonItemDataArea_SetNote.Visible = False
                        ButtonItemDataArea_SetClearHiatus.Visible = False
                        ButtonItemDataArea_SetClearBlankCell.Visible = False
                        ButtonItemDataArea_RateCPM.Visible = False
                        ButtonItemDataArea_ChangeDemo.Visible = False

                        If PivotGridHitInfo.HeadersAreaInfo IsNot Nothing Then

                            If PivotGridHitInfo.HeadersAreaInfo.Field IsNot Nothing Then

                                If PivotGridHitInfo.HeadersAreaInfo.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea Then

                                    If PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.DaysOfWeek.ToString OrElse
                                            PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowDateRange.ToString OrElse
                                            PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowPackageLevels.ToString OrElse
                                            PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowAdSizes.ToString Then

                                        ButtonItemDataArea_Hide.Visible = False
                                        ButtonItemDataArea_SetCaption.Visible = True

                                    Else

                                        ButtonItemDataArea_Hide.Visible = True
                                        ButtonItemDataArea_SetCaption.Visible = False

                                    End If

                                    ButtonItemDataArea_SetPrefix.Visible = False
                                    ButtonItemDataArea_ChangeDisplayType.Visible = False
                                    ButtonItemDataArea_ShowHideGrandTotal.Visible = False
                                    ButtonItemDataArea_ShowHideTotals.Visible = False
                                    ButtonItemDataArea_ShowHideValues.Visible = False

                                Else

                                    If PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotals.ToString OrElse
                                            PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString OrElse
                                            PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP1.ToString OrElse
                                            PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP2.ToString OrElse
                                            PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPI.ToString OrElse
                                            PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CTR.ToString OrElse
                                            PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ConversionRate.ToString OrElse
                                            PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo1.ToString OrElse
                                            PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo2.ToString OrElse
                                            PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalNet.ToString OrElse
                                            PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.Commission.ToString Then

                                        ButtonItemDataArea_Hide.Visible = False

                                    Else

                                        ButtonItemDataArea_Hide.Visible = True

                                    End If

                                    If PivotGridHitInfo.HeadersAreaInfo.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString Then

                                        ButtonItemDataArea_SetPrefix.Visible = True

                                    Else

                                        ButtonItemDataArea_SetPrefix.Visible = False

                                    End If

                                    If PivotGridHitInfo.HeadersAreaInfo.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea Then

                                        ButtonItemDataArea_SetCaption.Visible = True

                                        If PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotals.ToString OrElse
                                                PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString OrElse
                                                PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP1.ToString OrElse
                                                PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP2.ToString OrElse
                                                PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPI.ToString OrElse
                                                PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CTR.ToString OrElse
                                                PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ConversionRate.ToString OrElse
                                                PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo1.ToString OrElse
                                                PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo2.ToString OrElse
                                                PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalNet.ToString OrElse
                                                PivotGridHitInfo.HeadersAreaInfo.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.Commission.ToString Then

                                            ButtonItemDataArea_ShowHideGrandTotal.Visible = False
                                            ButtonItemDataArea_ShowHideTotals.Visible = True
                                            ButtonItemDataArea_ShowHideValues.Visible = False

                                            If PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals Then

                                                ButtonItemDataArea_ShowHideTotals.Text = "Hide Totals"

                                            Else

                                                ButtonItemDataArea_ShowHideTotals.Text = "Show Totals"

                                            End If

                                        Else

                                            ButtonItemDataArea_ShowHideGrandTotal.Visible = True
                                            ButtonItemDataArea_ShowHideTotals.Visible = True
                                            ButtonItemDataArea_ShowHideValues.Visible = True

                                            If PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowValues Then

                                                ButtonItemDataArea_ShowHideValues.Text = "Hide Values"

                                            Else

                                                ButtonItemDataArea_ShowHideValues.Text = "Show Values"

                                            End If

                                            If PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowTotals Then

                                                ButtonItemDataArea_ShowHideTotals.Text = "Hide Totals"

                                            Else

                                                ButtonItemDataArea_ShowHideTotals.Text = "Show Totals"

                                            End If

                                            If PivotGridHitInfo.HeadersAreaInfo.Field.Options.ShowGrandTotal Then

                                                ButtonItemDataArea_ShowHideGrandTotal.Text = "Hide In Grand Total"

                                            Else

                                                ButtonItemDataArea_ShowHideGrandTotal.Text = "Show In Grand Total"

                                            End If

                                        End If

                                    Else

                                        ButtonItemDataArea_SetCaption.Visible = False
                                        ButtonItemDataArea_ShowHideGrandTotal.Visible = False
                                        ButtonItemDataArea_ShowHideTotals.Visible = False
                                        ButtonItemDataArea_ShowHideValues.Visible = False

                                    End If

                                    If PivotGridHitInfo.HeadersAreaInfo.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                                        ButtonItemDataArea_ChangeDisplayType.Visible = True

                                    Else

                                        ButtonItemDataArea_ChangeDisplayType.Visible = False

                                    End If

                                End If

                                If PivotGridHitInfo.HeadersAreaInfo.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea Then

                                    If PivotGridHitInfo.HeadersAreaInfo.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString Then

                                        ButtonItemDataArea_ChangeDemo.Visible = True

                                    End If

                                End If

                            Else

                                ButtonItemDataArea_Hide.Visible = False
                                ButtonItemDataArea_SetPrefix.Visible = False
                                ButtonItemDataArea_SetCaption.Visible = False
                                ButtonItemDataArea_ChangeDisplayType.Visible = False
                                ButtonItemDataArea_ShowHideGrandTotal.Visible = False
                                ButtonItemDataArea_ShowHideTotals.Visible = False
                                ButtonItemDataArea_ShowHideValues.Visible = False

                            End If

                        Else

                            ButtonItemDataArea_Hide.Visible = False
                            ButtonItemDataArea_SetPrefix.Visible = False
                            ButtonItemDataArea_SetCaption.Visible = False
                            ButtonItemDataArea_ChangeDisplayType.Visible = False
                            ButtonItemDataArea_ShowHideGrandTotal.Visible = False
                            ButtonItemDataArea_ShowHideTotals.Visible = False
                            ButtonItemDataArea_ShowHideValues.Visible = False

                        End If

                        ButtonItemCMB_DataArea.Popup(System.Windows.Forms.Form.MousePosition)

                    ElseIf PivotGridHitInfo.HitTest = DevExpress.XtraPivotGrid.PivotGridHitTest.Value Then

                        ButtonItemDataArea_Hide.Visible = False
                        ButtonItemDataArea_SetPrefix.Visible = False
                        ButtonItemDataArea_SetCaption.Visible = False
                        ButtonItemDataArea_ChangeDisplayType.Visible = False
                        ButtonItemDataArea_ShowHideGrandTotal.Visible = False
                        ButtonItemDataArea_ShowHideTotals.Visible = False
                        ButtonItemDataArea_ShowHideValues.Visible = False
                        ButtonItemDataArea_SetClearBlankCell.Visible = False

                        If PivotGridHitInfo.ValueInfo IsNot Nothing AndAlso PivotGridHitInfo.ValueInfo.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

                            If PivotGridHitInfo.ValueInfo.Field IsNot Nothing Then

                                If PivotGridHitInfo.ValueInfo.Field.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea Then

                                    ColorPickerDropDownDataArea_RowColor.Visible = True

                                    ButtonItemDataArea_ViewData.Tag = PivotGridHitInfo
                                    ButtonItemDataArea_ViewData.Visible = PivotGridForm_MediaPlanDetail.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.ColumnArea).Any

                                    ButtonItemDataArea_AddDataByAllocating.Tag = PivotGridHitInfo
                                    ButtonItemDataArea_AddDataByAllocating.Visible = PivotGridForm_MediaPlanDetail.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.ColumnArea).Any ' Not _MediaPlan.IsApproved

                                    ButtonItemDataArea_SetNote.Tag = PivotGridHitInfo
                                    ButtonItemDataArea_SetNote.Visible = True ' Not _MediaPlan.IsApproved

                                    ColorPickerDropDownDataArea_RowColor.Text = "Row Color"

                                    If _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow).Any(Function(DR) DR(AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString) IsNot System.DBNull.Value AndAlso DR(AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString) <> 0) Then

                                        ColorPickerDropDownDataArea_RowColor.SelectedColor = System.Drawing.Color.FromArgb(_MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow).Select(Function(DR) CInt(DR(AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString))).Max)

                                    Else

                                        ColorPickerDropDownDataArea_RowColor.SelectedColor = Drawing.Color.Empty

                                    End If

                                    ColorPickerDropDownDataArea_RowColor.Tag = PivotGridHitInfo.ValueInfo

                                    Try

                                        PivotDrillDownDataSource = PivotGridHitInfo.ValueInfo.CreateDrillDownDataSource

                                    Catch ex As Exception
                                        PivotDrillDownDataSource = Nothing
                                    End Try

                                    If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                                        Try

                                            Note = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Where(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) IsNot Nothing AndAlso PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) <> "").Select(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString)).Max()

                                        Catch ex As Exception
                                            Note = ""
                                        End Try

                                        If String.IsNullOrEmpty(Note) = False AndAlso Note.Trim = "" Then

                                            ButtonItemDataArea_SetClearBlankCell.Text = "Clear Blank Cells"

                                        Else

                                            ButtonItemDataArea_SetClearBlankCell.Text = "Set Blank Cells"

                                        End If

                                        ButtonItemDataArea_SetClearBlankCell.Tag = PivotGridHitInfo
                                        ButtonItemDataArea_SetClearBlankCell.Visible = True

                                    Else

                                        ButtonItemDataArea_SetClearBlankCell.Visible = False

                                    End If

                                    For Each ButtonItem In ButtonItemDataArea_RateCPM.SubItems.OfType(Of DevComponents.DotNetBar.ButtonItem).ToList

                                        ButtonItem.Checked = False

                                    Next

                                    If PivotDrillDownDataSource Is Nothing Then

                                        Try

                                            PivotDrillDownDataSource = PivotGridHitInfo.ValueInfo.CreateDrillDownDataSource

                                        Catch ex As Exception
                                            PivotDrillDownDataSource = Nothing
                                        End Try

                                    End If

                                    If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                                        RowIndexes = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Select(Function(PDDDR) CInt(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).Distinct.ToList

                                        For Each ButtonItem In ButtonItemDataArea_RateCPM.SubItems.OfType(Of DevComponents.DotNetBar.ButtonItem).ToList

                                            DataAreaQuantityColumn = ButtonItem.Tag

                                            For Each RowIndex In RowIndexes

                                                If ButtonItem.Checked = False Then

                                                    If DataAreaQuantityColumn = MediaPlanning.DataAreaQuantityColumns.Clicks Then

                                                        ButtonItem.Checked = _MediaPlan.MediaPlanEstimate.CheckForClicksQuantity(RowIndex)
                                                        ButtonItem.SubItems.OfType(Of DevComponents.DotNetBar.SwitchButtonItem).FirstOrDefault.Value = _MediaPlan.MediaPlanEstimate.CheckForClicksCPM(RowIndex)

                                                    ElseIf DataAreaQuantityColumn = MediaPlanning.DataAreaQuantityColumns.Units Then

                                                        ButtonItem.Checked = _MediaPlan.MediaPlanEstimate.CheckForUnitsQuantity(RowIndex)
                                                        ButtonItem.SubItems.OfType(Of DevComponents.DotNetBar.SwitchButtonItem).FirstOrDefault.Value = _MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(RowIndex)

                                                    ElseIf DataAreaQuantityColumn = MediaPlanning.DataAreaQuantityColumns.Impressions Then

                                                        ButtonItem.Checked = _MediaPlan.MediaPlanEstimate.CheckForImpressionsQuantity(RowIndex)
                                                        ButtonItem.SubItems.OfType(Of DevComponents.DotNetBar.SwitchButtonItem).FirstOrDefault.Value = _MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(RowIndex)

                                                    ElseIf DataAreaQuantityColumn = MediaPlanning.DataAreaQuantityColumns.Columns Then

                                                        ButtonItem.Checked = _MediaPlan.MediaPlanEstimate.CheckForColumnsQuantity(RowIndex)

                                                    ElseIf DataAreaQuantityColumn = MediaPlanning.DataAreaQuantityColumns.InchesLines Then

                                                        ButtonItem.Checked = _MediaPlan.MediaPlanEstimate.CheckForInchesLinesQuantity(RowIndex)

                                                    End If

                                                End If

                                            Next

                                        Next

                                    End If

                                    ButtonItemDataArea_RateCPM.Tag = PivotGridHitInfo
                                    ButtonItemDataArea_RateCPM.Visible = True

                                ElseIf PivotGridHitInfo.ValueInfo.Field.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea Then

                                    If PivotGridForm_MediaPlanDetail.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.ColumnArea).Last IsNot Nothing AndAlso
                                            PivotGridForm_MediaPlanDetail.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.ColumnArea).Last Is PivotGridHitInfo.ValueInfo.Field Then

                                        If PivotGridHitInfo.ValueInfo.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                                            If _MediaPlan.MediaPlanEstimate.HiatusWeeks.Contains(PivotGridHitInfo.ValueInfo.Value) Then

                                                ButtonItemDataArea_SetClearHiatus.Icon = AdvantageFramework.My.Resources.ClearHiatusIcon
                                                ButtonItemDataArea_SetClearHiatus.Text = "Clear Hiatus"

                                            Else

                                                ButtonItemDataArea_SetClearHiatus.Icon = AdvantageFramework.My.Resources.SetHiatusIcon
                                                ButtonItemDataArea_SetClearHiatus.Text = "Set Hiatus"

                                            End If

                                            ButtonItemDataArea_SetClearHiatus.Tag = PivotGridHitInfo
                                            ButtonItemDataArea_SetClearHiatus.Visible = True

                                        ElseIf PivotGridHitInfo.ValueInfo.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                                                PivotGridHitInfo.ValueInfo.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

                                            If _MediaPlan.MediaPlanEstimate.HiatusMonths.Contains(PivotGridHitInfo.ValueInfo.Value) Then

                                                ButtonItemDataArea_SetClearHiatus.Icon = AdvantageFramework.My.Resources.ClearHiatusIcon
                                                ButtonItemDataArea_SetClearHiatus.Text = "Clear Hiatus"

                                            Else

                                                ButtonItemDataArea_SetClearHiatus.Icon = AdvantageFramework.My.Resources.SetHiatusIcon
                                                ButtonItemDataArea_SetClearHiatus.Text = "Set Hiatus"

                                            End If

                                            ButtonItemDataArea_SetClearHiatus.Tag = PivotGridHitInfo
                                            ButtonItemDataArea_SetClearHiatus.Visible = True

                                        Else

                                            ButtonItemDataArea_SetClearHiatus.Visible = False

                                        End If

                                    Else

                                        ButtonItemDataArea_SetClearHiatus.Visible = False

                                    End If

                                Else

                                    ColorPickerDropDownDataArea_RowColor.Visible = False
                                    ButtonItemDataArea_ViewData.Visible = False
                                    ButtonItemDataArea_AddDataByAllocating.Visible = False
                                    ButtonItemDataArea_SetNote.Visible = False
                                    ButtonItemDataArea_SetClearBlankCell.Visible = False
                                    ButtonItemDataArea_RateCPM.Visible = False

                                End If

                            Else

                                ColorPickerDropDownDataArea_RowColor.Visible = False
                                ButtonItemDataArea_ViewData.Visible = False
                                ButtonItemDataArea_AddDataByAllocating.Visible = False
                                ButtonItemDataArea_SetNote.Visible = False
                                ButtonItemDataArea_SetClearBlankCell.Visible = False
                                ButtonItemDataArea_RateCPM.Visible = False

                            End If

                        Else

                            ColorPickerDropDownDataArea_RowColor.Visible = False
                            ButtonItemDataArea_ViewData.Visible = False
                            ButtonItemDataArea_AddDataByAllocating.Visible = False
                            ButtonItemDataArea_SetNote.Visible = False
                            ButtonItemDataArea_SetClearBlankCell.Visible = False
                            ButtonItemDataArea_RateCPM.Visible = False

                        End If

                        ButtonItemCMB_DataArea.Popup(System.Windows.Forms.Form.MousePosition)

                    ElseIf PivotGridHitInfo.HitTest = DevExpress.XtraPivotGrid.PivotGridHitTest.Cell Then

                        'ColorPickerDropDownDataArea_RowColor.Visible = False
                        ButtonItemDataArea_Hide.Visible = False
                        ButtonItemDataArea_SetPrefix.Visible = False
                        ButtonItemDataArea_SetCaption.Visible = False
                        ButtonItemDataArea_ChangeDisplayType.Visible = False
                        ButtonItemDataArea_ShowHideGrandTotal.Visible = False
                        ButtonItemDataArea_ShowHideTotals.Visible = False
                        ButtonItemDataArea_ShowHideValues.Visible = False
                        ButtonItemDataArea_RateCPM.Visible = False

                        If PivotGridHitInfo.CellInfo IsNot Nothing AndAlso
                                PivotGridHitInfo.CellInfo.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value AndAlso
                                PivotGridHitInfo.CellInfo.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

                            ButtonItemDataArea_ViewData.Tag = PivotGridHitInfo
                            ButtonItemDataArea_ViewData.Visible = PivotGridForm_MediaPlanDetail.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.ColumnArea).Any

                            If PivotGridHitInfo.CellInfo.ColumnField IsNot Nothing Then

                                If _MediaPlan.MediaPlanEstimate.IsOnHiatusDate(PivotGridHitInfo.CellInfo.GetFieldValue(PivotGridHitInfo.CellInfo.ColumnField)) = False Then

                                    ButtonItemDataArea_AddDataByAllocating.Tag = PivotGridHitInfo
                                    ButtonItemDataArea_AddDataByAllocating.Visible = False ' PivotGridForm_MediaPlanDetail.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.ColumnArea).Any ' Not _MediaPlan.IsApproved

                                    ButtonItemDataArea_SetNote.Tag = PivotGridHitInfo
                                    ButtonItemDataArea_SetNote.Visible = True 'Not _MediaPlan.IsApproved

                                    ButtonItemDataArea_SetClearBlankCell.Visible = True

                                End If

                            End If

                            ColorPickerDropDownDataArea_RowColor.Visible = True
                            ColorPickerDropDownDataArea_RowColor.Text = "Cell Color"

                            Try

                                PivotDrillDownDataSource = PivotGridHitInfo.CellInfo.CreateDrillDownDataSource

                            Catch ex As Exception
                                PivotDrillDownDataSource = Nothing
                            End Try

                            If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                                Try

                                    Color = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Where(Function(PivotDrillDownDataRow) CInt(PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString)) <> 0).Select(Function(PivotDrillDownDataRow) CInt(PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString))).Max()

                                Catch ex As Exception
                                    Color = 0
                                End Try

                                If Color <> 0 Then

                                    ColorPickerDropDownDataArea_RowColor.SelectedColor = System.Drawing.Color.FromArgb(Color)

                                Else

                                    ColorPickerDropDownDataArea_RowColor.SelectedColor = Drawing.Color.Empty

                                End If

                            Else

                                ColorPickerDropDownDataArea_RowColor.SelectedColor = Drawing.Color.Empty

                            End If

                            ColorPickerDropDownDataArea_RowColor.Tag = PivotGridHitInfo.CellInfo

                            If ButtonItemDataArea_SetClearBlankCell.Visible Then

                                Try

                                    PivotDrillDownDataSource = PivotGridHitInfo.CellInfo.CreateDrillDownDataSource

                                Catch ex As Exception
                                    PivotDrillDownDataSource = Nothing
                                End Try

                                If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                                    Try

                                        Note = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Where(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) IsNot Nothing AndAlso PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) <> "").Select(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString)).Max()

                                    Catch ex As Exception
                                        Note = ""
                                    End Try

                                    If String.IsNullOrEmpty(Note) = False AndAlso Note.Trim = "" Then

                                        ButtonItemDataArea_SetClearBlankCell.Text = "Clear Blank Cell"

                                    Else

                                        ButtonItemDataArea_SetClearBlankCell.Text = "Set Blank Cell"

                                    End If

                                    ButtonItemDataArea_SetClearBlankCell.Tag = PivotGridHitInfo
                                    ButtonItemDataArea_SetClearBlankCell.Visible = True

                                Else

                                    ButtonItemDataArea_SetClearBlankCell.Visible = False

                                End If

                            End If

                        Else

                            ButtonItemDataArea_SetNote.Visible = False
                            ButtonItemDataArea_ViewData.Visible = False
                            ButtonItemDataArea_AddDataByAllocating.Visible = False
                            ButtonItemDataArea_SetClearBlankCell.Visible = False

                        End If

                        ButtonItemCMB_DataArea.Popup(System.Windows.Forms.Form.MousePosition)

                    Else

                        ButtonItemCMB_DataArea.Popup(System.Windows.Forms.Form.MousePosition)

                    End If

                End If

            End If

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_MouseDoubleClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles PivotGridForm_MediaPlanDetail.MouseDoubleClick

            'objects
            Dim PivotGridHitInfo As DevExpress.XtraPivotGrid.PivotGridHitInfo = Nothing

            Try

                PivotGridHitInfo = PivotGridForm_MediaPlanDetail.CalcHitInfo(e.Location)

            Catch ex As Exception
                PivotGridHitInfo = Nothing
            End Try

            If PivotGridHitInfo IsNot Nothing Then

                If PivotGridHitInfo.HitTest = DevExpress.XtraPivotGrid.PivotGridHitTest.Value Then

                    If PivotGridHitInfo.ValueInfo IsNot Nothing AndAlso PivotGridHitInfo.ValueInfo.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

                        If PivotGridHitInfo.ValueInfo.Field IsNot Nothing Then

                            If PivotGridHitInfo.ValueInfo.Field.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea Then

                                ShowMediaPlanLevelAndLines()

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_PopupMenuShowing(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PopupMenuShowingEventArgs) Handles PivotGridForm_MediaPlanDetail.PopupMenuShowing

            e.Allow = False

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_ShowingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.CancelPivotCellEditEventArgs) Handles PivotGridForm_MediaPlanDetail.ShowingEditor

            'objects
            Dim ContainsHiatusDate As Boolean = False
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim StartDates As Generic.List(Of Date) = Nothing

            If e.ColumnValueType <> DevExpress.XtraPivotGrid.PivotGridValueType.Value OrElse
                    e.RowValueType <> DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

                e.Cancel = True

            Else

                If _MediaPlan.MediaPlanEstimate.IsOnHiatusDate(e.GetFieldValue(e.ColumnField)) Then

                    ContainsHiatusDate = True

                End If

                If ContainsHiatusDate Then

                    e.Cancel = True

                Else

                    If TypeOf e.RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput Then

                        CType(e.RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).AllowKeyUpAndDownToIncrementValue = False
                        CType(e.RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).AllowMouseWheel = False
                        CType(e.RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).Increment = 0

                        If _MediaPlan IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso e.DataField IsNot Nothing AndAlso
                            (e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString OrElse e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString OrElse
                             e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString OrElse e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString OrElse
                             e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString) Then

                            If (_MediaPlan.MediaPlanEstimate.SalesClassType = "R" OrElse _MediaPlan.MediaPlanEstimate.SalesClassType = "T") Then

                                CType(e.RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = 999999
                                CType(e.RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 6

                            Else

                                CType(e.RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = 99999999.99
                                CType(e.RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 10

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_ShowCustomizationForm(ByVal sender As Object, ByVal e As System.EventArgs) Handles PivotGridForm_MediaPlanDetail.ShowCustomizationForm

            If ButtonItemGridOptions_ShowHideFieldList.Checked = False Then

                ButtonItemGridOptions_ShowHideFieldList.Checked = True

            End If

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_ShownEditor(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotCellEditEventArgs) Handles PivotGridForm_MediaPlanDetail.ShownEditor

            If e.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value AndAlso
                    e.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

                If e.Edit IsNot Nothing Then

                    e.Edit.SelectAll()

                End If

            End If

        End Sub
        Private Sub PivotGridForm_MediaPlanDetail_FieldValueImageIndex(sender As Object, e As DevExpress.XtraPivotGrid.PivotFieldImageIndexEventArgs) Handles PivotGridForm_MediaPlanDetail.FieldValueImageIndex

            'objects
            Dim DataRows As Generic.List(Of System.Data.DataRow) = Nothing
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing

            If Me.IsFormClosing = False AndAlso CType(sender, DevExpress.XtraPivotGrid.PivotGridControl).IsAsyncInProgress = False AndAlso
                    e.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value AndAlso
                    e.Field IsNot Nothing AndAlso e.Field.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea AndAlso
                    _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                If e.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowPackageLevels.ToString Then

                    PivotDrillDownDataSource = e.CreateDrillDownDataSource

                    RowIndexes = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Select(Function(PivotDrillDownDataRow) CInt(PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).ToList

                    DataRows = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) RowIndexes.Contains(CInt(DR(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString)))).ToList

                    'If DataRows.Count > 0 AndAlso DataRows.Any(Function(DR) DR(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageParent.ToString) = True) Then

                    '    e.ImageIndex = 3

                    'Else

                    '    e.ImageIndex = 4

                    'End If

                ElseIf e.Field.AreaIndex = 0 Then

                    PivotDrillDownDataSource = e.CreateDrillDownDataSource

                    RowIndexes = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Select(Function(PivotDrillDownDataRow) CInt(PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).ToList

                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) RowIndexes.Contains(Entity.RowIndex)).
                                                                                  All(Function(Entity) Entity.OrderNumber Is Nothing) Then

                        e.ImageIndex = 0

                    ElseIf _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) RowIndexes.Contains(Entity.RowIndex)).
                                                                                      All(Function(Entity) Entity.OrderNumber IsNot Nothing) Then

                        e.ImageIndex = 2

                    ElseIf _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) RowIndexes.Contains(Entity.RowIndex)).
                                                                                      Any(Function(Entity) Entity.OrderNumber IsNot Nothing) Then

                        e.ImageIndex = 1

                    End If

                End If

            End If

        End Sub
        Private Sub ToolTipController_GetActiveObjectInfo(sender As Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController.GetActiveObjectInfo

            'objects
            Dim ToolTipControlInfo As DevExpress.Utils.ToolTipControlInfo = Nothing
            Dim PivotGridHitInfo As DevExpress.XtraPivotGrid.PivotGridHitInfo = Nothing
            Dim CellText As String = String.Empty
            Dim Ordered As Integer = 0

            If e.Info Is Nothing AndAlso e.SelectedControl Is PivotGridForm_MediaPlanDetail AndAlso
                    _MediaPlan IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                PivotGridHitInfo = PivotGridForm_MediaPlanDetail.CalcHitInfo(e.ControlMousePosition)

                If PivotGridHitInfo IsNot Nothing AndAlso PivotGridHitInfo.HitTest = DevExpress.XtraPivotGrid.PivotGridHitTest.Value AndAlso
                        PivotGridHitInfo.ValueInfo IsNot Nothing AndAlso PivotGridHitInfo.ValueInfo.Field IsNot Nothing AndAlso
                        PivotGridHitInfo.ValueInfo.Field.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea AndAlso
                        PivotGridHitInfo.ValueInfo.Field.AreaIndex = 0 Then

                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.RowIndex >= PivotGridHitInfo.ValueInfo.MinIndex AndAlso Entity.RowIndex <= PivotGridHitInfo.ValueInfo.MaxIndex).
                                                                                  All(Function(Entity) Entity.OrderNumber Is Nothing) Then

                        ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(PivotGridHitInfo.ValueInfo.Value, "Unordered")

                    ElseIf _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.RowIndex >= PivotGridHitInfo.ValueInfo.MinIndex AndAlso Entity.RowIndex <= PivotGridHitInfo.ValueInfo.MaxIndex).
                                                                                      All(Function(Entity) Entity.OrderNumber IsNot Nothing) Then

                        ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(PivotGridHitInfo.ValueInfo.Value, "Ordered")

                    ElseIf _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.RowIndex >= PivotGridHitInfo.ValueInfo.MinIndex AndAlso Entity.RowIndex <= PivotGridHitInfo.ValueInfo.MaxIndex).
                                                                                      Any(Function(Entity) Entity.OrderNumber IsNot Nothing) Then

                        ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(PivotGridHitInfo.ValueInfo.Value, "Partially Ordered")

                    End If

                    e.Info = ToolTipControlInfo

                End If

            End If

        End Sub
        Private Sub ButtonItemMediaMixUpdate_LevelsLines_Click(sender As Object, e As EventArgs) Handles ButtonItemMediaMixUpdate_LevelsLines.Click

            Me.PivotGridForm_MediaPlanDetail.CloseEditor()

            If _MediaPlan IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate.MediaPlanEstimateTemplateID.HasValue AndAlso EstimateIsSaved() Then

                If _MediaPlan.MediaPlanEstimate.SalesClassType = "I" Then

                    UpdateInternetEstimateLevelsLinesBudget(_MediaPlan.MediaPlanEstimate.MediaPlanEstimateTemplateID.Value, True, False, False)

                ElseIf {"R", "T"}.Contains(_MediaPlan.MediaPlanEstimate.SalesClassType) Then

                    UpdateBroadcastEstimateLevelsLinesBudget(_MediaPlan.MediaPlanEstimate.MediaPlanEstimateTemplateID.Value, True, False, False)

                End If

            End If

        End Sub
        Private Sub ButtonItemMediaMixUpdate_Budget_Click(sender As Object, e As EventArgs) Handles ButtonItemMediaMixUpdate_Budget.Click

            Me.PivotGridForm_MediaPlanDetail.CloseEditor()

            If _MediaPlan IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate.MediaPlanEstimateTemplateID.HasValue AndAlso EstimateIsSaved() Then

                If _MediaPlan.MediaPlanEstimate.SalesClassType = "I" Then

                    UpdateInternetEstimateLevelsLinesBudget(_MediaPlan.MediaPlanEstimate.MediaPlanEstimateTemplateID.Value, False, True, False)

                ElseIf {"R", "T"}.Contains(_MediaPlan.MediaPlanEstimate.SalesClassType) Then

                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(L) L.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Market).Any = False AndAlso
                            _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(L) L.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Daypart).Any = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Estimate does not have market and daypart mappings defined.", Title:="Cannot Allocate Budget")

                    Else

                        If AdvantageFramework.Media.Presentation.MediaPlanEstimateGRPBudgetDialog.ShowFormDialog(_MediaPlan) = Windows.Forms.DialogResult.OK Then

                            UpdateBroadcastGRPs()

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemMediaMixUpdate_BudgetAddMissing_Click(sender As Object, e As EventArgs) Handles ButtonItemMediaMixUpdate_BudgetAddMissing.Click

            Me.PivotGridForm_MediaPlanDetail.CloseEditor()

            If _MediaPlan IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate.MediaPlanEstimateTemplateID.HasValue AndAlso EstimateIsSaved() Then

                If _MediaPlan.MediaPlanEstimate.SalesClassType = "I" Then

                    UpdateInternetEstimateLevelsLinesBudget(_MediaPlan.MediaPlanEstimate.MediaPlanEstimateTemplateID.Value, False, True, True)

                End If

            End If

        End Sub
        Private Sub ButtonItemMediaMixUpdate_Rate_Click(sender As Object, e As EventArgs) Handles ButtonItemMediaMixUpdate_Rate.Click

            Me.PivotGridForm_MediaPlanDetail.CloseEditor()

            If _MediaPlan IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate.MediaPlanEstimateTemplateID.HasValue AndAlso EstimateIsSaved() Then

                If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Count > 0 Then

                    If _MediaPlan.MediaPlanEstimate.SalesClassType = "I" Then

                        UpdateInternetEstimateRate(_MediaPlan.MediaPlanEstimate.MediaPlanEstimateTemplateID.Value)

                    ElseIf {"R", "T"}.Contains(_MediaPlan.MediaPlanEstimate.SalesClassType) Then

                        UpdateBroadcastEstimateRate(_MediaPlan.MediaPlanEstimate.MediaPlanEstimateTemplateID.Value)

                    ElseIf _MediaPlan.MediaPlanEstimate.SalesClassType = "M" Then

                        UpdateMagazineEstimateRate(_MediaPlan.MediaPlanEstimate.MediaPlanEstimateTemplateID.Value)

                    ElseIf _MediaPlan.MediaPlanEstimate.SalesClassType = "N" Then

                        UpdateNewspaperEstimateRate(_MediaPlan.MediaPlanEstimate.MediaPlanEstimateTemplateID.Value)

                    ElseIf _MediaPlan.MediaPlanEstimate.SalesClassType = "O" Then

                        UpdateOutOfHomeEstimateRate(_MediaPlan.MediaPlanEstimate.MediaPlanEstimateTemplateID.Value)

                    End If

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
