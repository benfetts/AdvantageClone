Namespace Maintenance.Media.Presentation

    Public Class MediaTemplateDataEntryDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanEstimateTemplateDataEntryViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Maintenance.Media.MediaPlanEstimateTemplateController = Nothing
        Protected _MediaPlanEstimateTemplateID As Integer = 0
        'Protected _PivotLayoutChanged As Boolean = False ' in case we want to save the layout later
        Protected _RowPivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing
        Protected _ColumnPivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing
        Protected _ShowInternetRates As Boolean = False
        Protected _ShowPercents As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaPlanEstimateTemplateID As Integer, ShowInternetRates As Boolean, ShowPercents As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaPlanEstimateTemplateID = MediaPlanEstimateTemplateID
            _ShowInternetRates = ShowInternetRates
            _ShowPercents = ShowPercents

        End Sub
        Private Sub EnableDisableActions()

            Me.ButtonItemActions_Save.Enabled = Me.UserEntryChanged 'OrElse _PivotLayoutChanged
            Me.ButtonItemActions_Cancel.Enabled = Me.UserEntryChanged 'OrElse _PivotLayoutChanged

            Me.RibbonBarOptions_PivotColumn.Visible = (Me.FieldAreaCount(DevExpress.XtraPivotGrid.PivotArea.ColumnArea) = 1 AndAlso Me.FieldAreaCount(DevExpress.XtraPivotGrid.PivotArea.RowArea) = 1) 'AndAlso (_ViewModel.IsSystemTemplate = False)
            Me.RibbonBarOptions_Market.Visible = ({"R", "T"}.Contains(_ViewModel.PlanEstimateTemplate.Type) AndAlso _ShowPercents AndAlso _ViewModel.PlanEstimateTemplate.HasMarkets)

        End Sub
        Private Sub SetupInternetPivotGrid()

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing
            Dim HasRow As Boolean = False

            If _ViewModel.PlanEstimateTemplate.HasVendors Then

                PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
                PivotGridField.MinWidth = 85
                PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
                PivotGridField.AreaIndex = 0
                PivotGridField.Caption = "Vendor"
                PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.VendorName.ToString
                PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea Or DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                PivotGridForm_DataEnty.Fields.Add(PivotGridField)

                HasRow = True

            End If

            If _ViewModel.PlanEstimateTemplate.HasTactics Then

                PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
                PivotGridField.MinWidth = 85
                PivotGridField.Area = If(HasRow, DevExpress.XtraPivotGrid.PivotArea.ColumnArea, DevExpress.XtraPivotGrid.PivotArea.RowArea)
                PivotGridField.AreaIndex = 0
                PivotGridField.Caption = "Tactic"
                PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.TacticDescription.ToString
                PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea Or DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                PivotGridForm_DataEnty.Fields.Add(PivotGridField)

            End If

            If _ViewModel.PlanEstimateTemplate.HasVendors = False OrElse _ViewModel.PlanEstimateTemplate.HasTactics = False Then

                PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
                PivotGridField.MinWidth = 85
                PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
                PivotGridField.AreaIndex = 0
                PivotGridField.Caption = " "
                PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.Quarter.ToString
                PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea Or DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                PivotGridForm_DataEnty.Fields.Add(PivotGridField)

            End If

        End Sub
        Private Sub SetupInternetRatePivotGrid()

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
            PivotGridField.MinWidth = 85
            PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
            PivotGridField.AreaIndex = 0
            PivotGridField.Caption = "Vendor"
            PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.VendorName.ToString
            PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea Or DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
            PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
            PivotGridForm_DataEnty.Fields.Add(PivotGridField)

            PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
            PivotGridField.MinWidth = 85
            PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
            PivotGridField.AreaIndex = 0
            PivotGridField.Caption = "Internet Type"
            PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.InternetTypeName.ToString
            PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea Or DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
            PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
            PivotGridForm_DataEnty.Fields.Add(PivotGridField)

        End Sub
        Private Sub SetupOutdoorPivotGrid()

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            If _ViewModel.PlanEstimateTemplate.HasOutdoorTypes Then

                PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
                PivotGridField.MinWidth = 85
                PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
                PivotGridField.AreaIndex = 0
                PivotGridField.Caption = "Out Of Home Type"
                PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.OutOfHomeType.ToString
                PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea Or DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                PivotGridForm_DataEnty.Fields.Add(PivotGridField)

            End If

            If _ViewModel.PlanEstimateTemplate.HasVendors Then

                PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
                PivotGridField.MinWidth = 85
                PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
                PivotGridField.AreaIndex = 0
                PivotGridField.Caption = "Vendor"
                PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.VendorName.ToString
                PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea Or DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                PivotGridForm_DataEnty.Fields.Add(PivotGridField)

            End If

            If _ViewModel.PlanEstimateTemplate.HasQuarters Then

                PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
                PivotGridField.MinWidth = 85
                PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
                PivotGridField.AreaIndex = 0
                PivotGridField.Caption = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.Quarter.ToString
                PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.Quarter.ToString
                PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea Or DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                PivotGridForm_DataEnty.Fields.Add(PivotGridField)

            Else

                PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
                PivotGridField.MinWidth = 85
                PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
                PivotGridField.AreaIndex = 0
                PivotGridField.Caption = "All Quarters"
                PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.Quarter.ToString
                PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea Or DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                PivotGridForm_DataEnty.Fields.Add(PivotGridField)

            End If

        End Sub
        Private Sub SetupPrintPivotGrid()

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            If _ViewModel.PlanEstimateTemplate.HasRateTypes Then

                PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
                PivotGridField.MinWidth = 85
                PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
                PivotGridField.AreaIndex = 0
                PivotGridField.Caption = "Rate Type"
                PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.RateTypeDescription.ToString
                PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea Or DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                PivotGridForm_DataEnty.Fields.Add(PivotGridField)

            End If

            If _ViewModel.PlanEstimateTemplate.HasAdSizes Then

                PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
                PivotGridField.MinWidth = 85
                PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
                PivotGridField.AreaIndex = 0
                PivotGridField.Caption = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.AdSize.ToString
                PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.AdSize.ToString
                PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea Or DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                PivotGridForm_DataEnty.Fields.Add(PivotGridField)

            End If

            If _ViewModel.PlanEstimateTemplate.HasVendors Then

                PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
                PivotGridField.MinWidth = 85
                PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
                PivotGridField.AreaIndex = 0
                PivotGridField.Caption = "Vendor"
                PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.VendorName.ToString
                PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea Or DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                PivotGridForm_DataEnty.Fields.Add(PivotGridField)

            End If

            If _ViewModel.PlanEstimateTemplate.HasQuarters Then

                PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
                PivotGridField.MinWidth = 85
                PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
                PivotGridField.AreaIndex = 0
                PivotGridField.Caption = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.Quarter.ToString
                PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.Quarter.ToString
                PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea Or DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                PivotGridForm_DataEnty.Fields.Add(PivotGridField)

            Else

                PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
                PivotGridField.MinWidth = 85
                PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
                PivotGridField.AreaIndex = 0
                PivotGridField.Caption = "All Quarters"
                PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.Quarter.ToString
                PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea Or DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                PivotGridForm_DataEnty.Fields.Add(PivotGridField)

            End If

        End Sub
        Private Sub SetupBroadcastRatePivotGrid()

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            If _ViewModel.PlanEstimateTemplate.HasQuarters Then

                PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
                PivotGridField.MinWidth = 85
                PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
                PivotGridField.AreaIndex = 0
                PivotGridField.Caption = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.Quarter.ToString
                PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.Quarter.ToString
                PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                PivotGridForm_DataEnty.Fields.Add(PivotGridField)

            End If

            If _ViewModel.PlanEstimateTemplate.HasSpotLengths Then

                PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
                PivotGridField.MinWidth = 85
                PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
                PivotGridField.AreaIndex = 0
                PivotGridField.Caption = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.SpotLength.ToString
                PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.SpotLength.ToString
                PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                PivotGridForm_DataEnty.Fields.Add(PivotGridField)

            End If

            If _ViewModel.PlanEstimateTemplate.HasDemographics Then

                PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
                PivotGridField.MinWidth = 85
                PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
                PivotGridField.AreaIndex = 0
                PivotGridField.Caption = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.Demographic.ToString
                PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.Demographic.ToString
                PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                PivotGridForm_DataEnty.Fields.Add(PivotGridField)

            End If

            If _ViewModel.PlanEstimateTemplate.HasMarkets Then

                PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
                PivotGridField.MinWidth = 85
                PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
                PivotGridField.AreaIndex = 0
                PivotGridField.Caption = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.Market.ToString
                PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.Market.ToString
                PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                PivotGridForm_DataEnty.Fields.Add(PivotGridField)

            End If

            If _ViewModel.PlanEstimateTemplate.HasDayparts Then

                PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
                PivotGridField.MinWidth = 85
                PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
                PivotGridField.AreaIndex = 0
                PivotGridField.Caption = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.Daypart.ToString
                PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.Daypart.ToString
                PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea
                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                PivotGridForm_DataEnty.Fields.Add(PivotGridField)

                PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
                PivotGridField.MinWidth = 85
                PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
                PivotGridField.AreaIndex = 1
                PivotGridField.Caption = "Daypart %"
                PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.DaypartPercent.ToString
                PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea
                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                PivotGridField.Visible = True
                PivotGridField.Options.ReadOnly = True
                PivotGridField.Options.ShowGrandTotal = False
                PivotGridForm_DataEnty.Fields.Add(PivotGridField)

            End If

        End Sub
        Private Sub SetupBroadcastPercentPivotGrid()

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            If _ViewModel.PlanEstimateTemplate.HasMarkets AndAlso ButtonItemMarket_Include.Checked Then

                PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
                PivotGridField.MinWidth = 85
                PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
                PivotGridField.AreaIndex = 0
                PivotGridField.Caption = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.Market.ToString
                PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.Market.ToString
                PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea Or DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea
                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                PivotGridForm_DataEnty.Fields.Add(PivotGridField)

            Else

                PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
                PivotGridField.MinWidth = 85
                PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
                PivotGridField.AreaIndex = 0
                PivotGridField.Caption = "All Markets"
                PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.MediaPlanEstimateTemplateID.ToString
                PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea Or DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea
                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                PivotGridField.Options.ShowValues = False
                PivotGridForm_DataEnty.Fields.Add(PivotGridField)

            End If

            If _ViewModel.PlanEstimateTemplate.HasDayparts Then

                PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
                PivotGridField.MinWidth = 85
                PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
                PivotGridField.AreaIndex = 0
                PivotGridField.Caption = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.Daypart.ToString
                PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.Daypart.ToString
                PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea Or DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea
                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                PivotGridForm_DataEnty.Fields.Add(PivotGridField)

            End If

        End Sub
        Private Sub AddDataAreaPercentageField()

            'objects
            Dim SubItemNumericInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput = Nothing
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing
            Dim DisplayFormat As String = "n2"

            If _ViewModel.PlanEstimateTemplate.Type <> "I" Then

                DisplayFormat = "n0"

            End If

            PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
            PivotGridField.MinWidth = 80
            PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
            PivotGridField.AreaIndex = 0
            PivotGridField.Caption = "Percentage"
            PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.PercentageOrRate.ToString
            PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False

            AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Session, PivotGridForm_DataEnty, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal, GetType(AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateData), False, Nothing)

            SubItemNumericInput = PivotGridField.FieldEdit

            SubItemNumericInput.AllowMouseWheel = False
            SubItemNumericInput.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
            SubItemNumericInput.EditMask = DisplayFormat
            SubItemNumericInput.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            SubItemNumericInput.DisplayFormat.FormatString = DisplayFormat
            SubItemNumericInput.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            SubItemNumericInput.EditFormat.FormatString = DisplayFormat
            SubItemNumericInput.Mask.UseMaskAsDisplayFormat = True
            SubItemNumericInput.Mask.EditMask = DisplayFormat
            SubItemNumericInput.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            SubItemNumericInput.IsFloatValue = True
            SubItemNumericInput.MinValue = 0
            SubItemNumericInput.MaxValue = 100.0

            If _ViewModel.PlanEstimateTemplate.Type = "I" Then

                SubItemNumericInput.MaxLength = 6

            Else

                SubItemNumericInput.MaxLength = 3

            End If

            SubItemNumericInput.AllowKeyUpAndDownToIncrementValue = False
            SubItemNumericInput.AllowMouseWheel = False
            SubItemNumericInput.Increment = 0

            AddHandler SubItemNumericInput.Spin, AddressOf SubItemNumericInput_Spin

            PivotGridForm_DataEnty.Fields.Add(PivotGridField)

        End Sub
        Private Sub AddDataAreaRateField()

            'objects
            Dim SubItemNumericInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput = Nothing
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
            PivotGridField.MinWidth = 90
            PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
            PivotGridField.AreaIndex = 0
            PivotGridField.Caption = "Rate"
            PivotGridField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.PercentageOrRate.ToString
            PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.ShowGrandTotal = False

            AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Session, PivotGridForm_DataEnty, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal, GetType(AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateData), False, Nothing)

            SubItemNumericInput = PivotGridField.FieldEdit

            SubItemNumericInput.AllowMouseWheel = False
            SubItemNumericInput.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
            SubItemNumericInput.EditMask = "n4"
            SubItemNumericInput.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            SubItemNumericInput.DisplayFormat.FormatString = "n4"
            SubItemNumericInput.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            SubItemNumericInput.EditFormat.FormatString = "n4"
            SubItemNumericInput.Mask.UseMaskAsDisplayFormat = True
            SubItemNumericInput.Mask.EditMask = "n4"
            SubItemNumericInput.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            SubItemNumericInput.IsFloatValue = True
            SubItemNumericInput.MinValue = 0
            SubItemNumericInput.MaxValue = 999999.9999
            SubItemNumericInput.MaxLength = 11
            SubItemNumericInput.AllowKeyUpAndDownToIncrementValue = False
            SubItemNumericInput.AllowMouseWheel = False
            SubItemNumericInput.Increment = 0

            AddHandler SubItemNumericInput.Spin, AddressOf SubItemNumericInput_Spin

            PivotGridForm_DataEnty.Fields.Add(PivotGridField)

            If {"R", "T"}.Contains(_ViewModel.PlanEstimateTemplate.Type) Then

                AddHandler PivotGridForm_DataEnty.CustomSummary, AddressOf PivotGridControl1_CustomSummary

                PivotGridField = New DevExpress.XtraPivotGrid.PivotGridField
                PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
                PivotGridField.AreaIndex = 1
                PivotGridField.Caption = "Weight"
                PivotGridField.FieldName = "Weight"
                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False
                PivotGridField.Options.ShowValues = False
                PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom

                AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Session, PivotGridForm_DataEnty, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Integer, GetType(AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateData), False, Nothing)

                SubItemNumericInput = PivotGridField.FieldEdit

                SubItemNumericInput.AllowMouseWheel = False
                SubItemNumericInput.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                SubItemNumericInput.EditMask = "n0"
                SubItemNumericInput.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                SubItemNumericInput.DisplayFormat.FormatString = "n0"
                SubItemNumericInput.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                SubItemNumericInput.EditFormat.FormatString = "n0"
                SubItemNumericInput.Mask.UseMaskAsDisplayFormat = True
                SubItemNumericInput.Mask.EditMask = "n0"
                SubItemNumericInput.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                SubItemNumericInput.IsFloatValue = True
                SubItemNumericInput.MinValue = 0
                SubItemNumericInput.MaxValue = 100
                SubItemNumericInput.MaxLength = 3
                SubItemNumericInput.AllowKeyUpAndDownToIncrementValue = False
                SubItemNumericInput.AllowMouseWheel = False
                SubItemNumericInput.Increment = 0

                AddHandler SubItemNumericInput.Spin, AddressOf SubItemNumericInput_Spin

                PivotGridForm_DataEnty.Fields.Add(PivotGridField)

            End If

        End Sub
        Private Sub PivotGridControl1_CustomSummary(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotGridCustomSummaryEventArgs)

            'objects
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing
            Dim AvgCPP As Decimal = 0

            Try

                PivotDrillDownDataSource = e.CreateDrillDownDataSource

            Catch ex As Exception
                PivotDrillDownDataSource = Nothing
            End Try

            If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                AvgCPP = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Sum(Function(PDDDR) CDec(PDDDR.Item("PercentageOrRate")) * CDec(PDDDR.Item("DaypartPercent"))) / 100

                e.CustomValue = AvgCPP

            Else

                e.CustomValue = 0

            End If

        End Sub
        Private Sub SaveViewModel()

            'objects
            Dim PivotField As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PivotField = Nothing

            For Each PivotGridField As DevExpress.XtraPivotGrid.PivotGridField In PivotGridForm_DataEnty.Fields

                If PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea OrElse PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea Then

                    PivotField = _ViewModel.PivotFields.Where(Function(PF) PF.FieldName = PivotGridField.FieldName).FirstOrDefault

                    If PivotField Is Nothing Then

                        PivotField = New AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PivotField
                        PivotField.MediaPlanEstimateTemplateID = _ViewModel.PlanEstimateTemplate.ID
                        PivotField.FieldName = PivotGridField.FieldName

                        _ViewModel.PivotFields.Add(PivotField)

                    End If

                    PivotField.Area = PivotGridField.Area
                    PivotField.AreaIndex = PivotGridField.AreaIndex
                    PivotField.Width = PivotGridField.Width

                End If

            Next

        End Sub
        Private Sub RefreshViewModel()

            'objects
            Dim SavedFieldsDiffer As Boolean = False
            Dim PivotField As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PivotField = Nothing

            _Controller.DataEntry_GetPivotData(_ShowInternetRates, _ShowPercents, (Me.RibbonBarOptions_Market.Visible AndAlso Me.ButtonItemMarket_Include.Checked), _ViewModel)

            'PivotGridForm_DataEnty.OptionsView.ShowDataHeaders = False 'hides DataAreaFields
            If _ShowPercents = False Then

                PivotGridForm_DataEnty.OptionsView.ShowColumnGrandTotals = False
                PivotGridForm_DataEnty.OptionsView.ShowRowGrandTotals = False

            Else

                PivotGridForm_DataEnty.OptionsView.ShowColumnGrandTotals = True
                PivotGridForm_DataEnty.OptionsView.ShowRowGrandTotals = True

            End If

            PivotGridForm_DataEnty.DataSource = _ViewModel.Datas

            If _ViewModel.PlanEstimateTemplate.Type = "I" Then

                If _ShowPercents Then

                    SetupInternetPivotGrid()

                ElseIf _ShowInternetRates Then

                    SetupInternetRatePivotGrid()

                End If

            ElseIf _ViewModel.PlanEstimateTemplate.Type = "O" Then

                SetupOutdoorPivotGrid()

            ElseIf {"M", "N"}.Contains(_ViewModel.PlanEstimateTemplate.Type) Then

                SetupPrintPivotGrid()

            ElseIf {"R", "T"}.Contains(_ViewModel.PlanEstimateTemplate.Type) Then

                If _ShowPercents Then

                    SetupBroadcastPercentPivotGrid()

                    'PivotGridForm_DataEnty.OptionsView.ShowRowGrandTotals = False

                Else

                    SetupBroadcastRatePivotGrid()

                    PivotGridForm_DataEnty.OptionsView.ShowColumnGrandTotals = True

                End If

            End If

            If {"I", "R", "T"}.Contains(_ViewModel.PlanEstimateTemplate.Type) AndAlso _ShowPercents = True Then

                AddDataAreaPercentageField()

            Else

                AddDataAreaRateField()

            End If

            For Each PivotGridField As DevExpress.XtraPivotGrid.PivotGridField In PivotGridForm_DataEnty.Fields

                If (PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea OrElse PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea) AndAlso
                            _ViewModel.PivotFields.Where(Function(PF) PF.FieldName = PivotGridField.FieldName).Any = False Then

                    SavedFieldsDiffer = True
                    Exit For

                End If

            Next

            If SavedFieldsDiffer = False Then

                For Each PivotGridField As DevExpress.XtraPivotGrid.PivotGridField In PivotGridForm_DataEnty.Fields

                    If PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea OrElse PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea Then

                        PivotField = _ViewModel.PivotFields.Where(Function(PF) PF.FieldName = PivotGridField.FieldName).FirstOrDefault

                        If PivotField IsNot Nothing Then

                            PivotGridField.Area = PivotField.Area
                            PivotGridField.AreaIndex = PivotField.AreaIndex
                            PivotGridField.Width = PivotField.Width

                        End If

                    End If

                Next

            End If

            PivotGridForm_DataEnty.RefreshData()

            PivotGridForm_DataEnty.BestFitColumnArea()
            PivotGridForm_DataEnty.BestFitRowArea()

            EnableDisableActions()

        End Sub
        Private Function FieldAreaCount(PivotArea As DevExpress.XtraPivotGrid.PivotArea) As Integer

            Dim Count As Integer = 0

            For Each PivotGridField As DevExpress.XtraPivotGrid.PivotGridField In PivotGridForm_DataEnty.Fields

                If PivotGridField.Area = PivotArea Then

                    Count += 1

                    If PivotArea = DevExpress.XtraPivotGrid.PivotArea.RowArea Then

                        _RowPivotGridField = PivotGridField

                    ElseIf PivotArea = DevExpress.XtraPivotGrid.PivotArea.ColumnArea Then

                        _ColumnPivotGridField = PivotGridField

                    End If

                End If

            Next

            FieldAreaCount = Count

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaPlanEstimateTemplateID As Integer, ShowInternetRates As Boolean, ShowPercents As Boolean) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaTemplateDataEntryDialog As Maintenance.Media.Presentation.MediaTemplateDataEntryDialog = Nothing

            MediaTemplateDataEntryDialog = New Maintenance.Media.Presentation.MediaTemplateDataEntryDialog(MediaPlanEstimateTemplateID, ShowInternetRates, ShowPercents)

            ShowFormDialog = MediaTemplateDataEntryDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaTemplateDataEntryDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            Me.ButtonItemActions_Save.Enabled = False
            Me.ButtonItemActions_Cancel.Enabled = False

        End Sub
        Private Sub MediaTemplateDataEntryDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Me.RibbonBarOptions_PivotColumn.Visible = False

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemPivotColumn_Swap.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemMarket_Include.Image = AdvantageFramework.My.Resources.CheckImage

            PivotGridForm_DataEnty.OptionsSelection.MultiSelect = False
            PivotGridForm_DataEnty.OptionsSelection.CellSelection = False

            _Controller = New Controller.Maintenance.Media.MediaPlanEstimateTemplateController(Me.Session)

        End Sub
        Private Sub MediaTemplateDataEntryDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.ShowWaitForm("Loading...")

            _ViewModel = _Controller.DataEntry_Load(_MediaPlanEstimateTemplateID)

            Me.Text = _ViewModel.TemplateTypeName & " Data Entry"

            '_PivotLayoutChanged = False

            Me.ClearChanged()

            Me.ButtonItemMarket_Include.Checked = _ViewModel.IncludeMarket

            RefreshViewModel()

            Me.CloseWaitForm()

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            RefreshViewModel()

            '_PivotLayoutChanged = False

            Me.ClearChanged()

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Dim ErrorMessage As String = Nothing
            Dim DataList As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data) = Nothing
            Dim Markets As Generic.List(Of String) = Nothing
            Dim [Continue] As Boolean = True

            PivotGridForm_DataEnty.CloseEditor()

            DataList = DirectCast(PivotGridForm_DataEnty.DataSource, Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data))

            If _ViewModel.PlanEstimateTemplate.Type = "I" AndAlso _ShowPercents = True AndAlso DataList.Sum(Function(DL) DL.PercentageOrRate) <> 100.0 Then

                AdvantageFramework.WinForm.MessageBox.Show("Total must equal 100%.")
                [Continue] = False

            ElseIf {"R", "T"}.Contains(_ViewModel.PlanEstimateTemplate.Type) AndAlso _ShowPercents = True Then

                If DataList.Where(Function(DL) String.IsNullOrWhiteSpace(DL.Market) = False).Any Then

                    Markets = (From DL In DataList
                               Select DL.Market).Distinct.ToList

                    For Each Market In Markets

                        If DataList.Where(Function(DL) DL.Market = Market).Sum(Function(DL) DL.PercentageOrRate) <> 0 Then

                            If DataList.Where(Function(DL) DL.Market = Market).Sum(Function(DL) DL.PercentageOrRate) <> 100.0 Then

                                AdvantageFramework.WinForm.MessageBox.Show("Total must equal 100% for market: " & Market)
                                [Continue] = False
                                Exit For

                            End If

                        End If

                    Next

                ElseIf DataList.Sum(Function(DL) DL.PercentageOrRate) <> 100.0 Then

                    AdvantageFramework.WinForm.MessageBox.Show("Total must equal 100%.")
                    [Continue] = False

                End If

                If [Continue] AndAlso _ViewModel.DaypartsSetup AndAlso ButtonItemMarket_Include.Checked = True Then

                    If AdvantageFramework.WinForm.MessageBox.Show("Daypart level data exists for this template.  Daypart percentages saved by Market will remove Daypart level data.  Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo, "Confirm") = WinForm.MessageBox.DialogResults.No Then

                        [Continue] = False

                    End If

                ElseIf [Continue] AndAlso _ViewModel.DaypartsSetupByMarket AndAlso ButtonItemMarket_Include.Checked = False Then

                    If AdvantageFramework.WinForm.MessageBox.Show("Daypart level data by Market exists for this template.  Daypart percentages saved will remove Daypart level data by Market.  Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo, "Confirm") = WinForm.MessageBox.DialogResults.No Then

                        [Continue] = False

                    End If

                End If

            End If

            If [Continue] Then

                SaveViewModel()

                If _Controller.DataEntry_Save(_ViewModel, ErrorMessage) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    '_PivotLayoutChanged = False

                    RefreshViewModel()

                    Me.ClearChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemPivotColumn_Swap_Click(sender As Object, e As EventArgs) Handles ButtonItemPivotColumn_Swap.Click

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Refreshing

            PivotGridForm_DataEnty.CloseEditor()

            If _ColumnPivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea Then

                _ColumnPivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea

            ElseIf _ColumnPivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea Then

                _ColumnPivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea

            End If

            If _RowPivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea Then

                _RowPivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea

            ElseIf _RowPivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea Then

                _RowPivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea

            End If

            PivotGridForm_DataEnty.RefreshData()

            '_PivotLayoutChanged = True
            EnableDisableActions()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

        End Sub
        Private Sub PivotGridForm_DataEnty_EditValueChanged(sender As Object, e As DevExpress.XtraPivotGrid.EditValueChangedEventArgs) Handles PivotGridForm_DataEnty.EditValueChanged

            Me.BaseFormUserEntryChanged(Me.PivotGridForm_DataEnty)

            EnableDisableActions()

        End Sub
        Private Sub PivotGridForm_DataEnty_FieldAreaChanged(sender As Object, e As DevExpress.XtraPivotGrid.PivotFieldEventArgs) Handles PivotGridForm_DataEnty.FieldAreaChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                '_PivotLayoutChanged = True
                EnableDisableActions()

            End If

        End Sub
        Private Sub PivotGridForm_DataEnty_FieldAreaChanging(sender As Object, e As DevExpress.XtraPivotGrid.PivotAreaChangingEventArgs) Handles PivotGridForm_DataEnty.FieldAreaChanging

            Dim OppositeAreaCount As Integer = 0

            If e.NewArea = DevExpress.XtraPivotGrid.PivotArea.ColumnArea Then

                For Each PivotGridField As DevExpress.XtraPivotGrid.PivotGridField In PivotGridForm_DataEnty.Fields

                    If PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea AndAlso e.Field.Equals(PivotGridField) = False Then

                        OppositeAreaCount += 1
                        Exit For

                    End If

                Next

            ElseIf e.NewArea = DevExpress.XtraPivotGrid.PivotArea.RowArea Then

                For Each PivotGridField As DevExpress.XtraPivotGrid.PivotGridField In PivotGridForm_DataEnty.Fields

                    If PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea AndAlso e.Field.Equals(PivotGridField) = False Then

                        OppositeAreaCount += 1
                        Exit For

                    End If

                Next

            End If

            If OppositeAreaCount = 0 Then

                e.Allow = False

            End If

        End Sub
        Private Sub PivotGridForm_DataEnty_FieldAreaIndexChanged(sender As Object, e As DevExpress.XtraPivotGrid.PivotFieldEventArgs) Handles PivotGridForm_DataEnty.FieldAreaIndexChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                '_PivotLayoutChanged = True
                EnableDisableActions()

            End If

        End Sub
        Private Sub PivotGridForm_DataEnty_FieldValueDisplayText(sender As Object, e As DevExpress.XtraPivotGrid.PivotFieldDisplayTextEventArgs) Handles PivotGridForm_DataEnty.FieldValueDisplayText

            If Me.FormShown AndAlso {"R", "T"}.Contains(_ViewModel.PlanEstimateTemplate.Type) AndAlso _ShowPercents = False AndAlso e.DisplayText = "Grand Total" AndAlso e.IsColumn = True Then

                e.DisplayText = "Quarterly CPP"

            ElseIf Me.FormShown AndAlso {"R", "T"}.Contains(_ViewModel.PlanEstimateTemplate.Type) AndAlso _ShowPercents = True AndAlso e.Field IsNot Nothing AndAlso e.Field.Caption = "All Markets" Then

                e.DisplayText = String.Empty

            End If

        End Sub
        Private Sub PivotGridForm_DataEnty_FieldWidthChanged(sender As Object, e As DevExpress.XtraPivotGrid.PivotFieldEventArgs) Handles PivotGridForm_DataEnty.FieldWidthChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                '_PivotLayoutChanged = True
                EnableDisableActions()

            End If

        End Sub
        Private Sub PivotGridForm_DataEnty_PopupMenuShowing(sender As Object, e As DevExpress.XtraPivotGrid.PopupMenuShowingEventArgs) Handles PivotGridForm_DataEnty.PopupMenuShowing

            e.Allow = False

        End Sub
        Private Sub PivotGridForm_DataEnty_ShowingEditor(sender As Object, e As DevExpress.XtraPivotGrid.CancelPivotCellEditEventArgs) Handles PivotGridForm_DataEnty.ShowingEditor

            If _ViewModel.IsSystemTemplate AndAlso _ViewModel.Datas IsNot Nothing AndAlso _ViewModel.ShowPercents Then

                e.Cancel = True

            ElseIf e.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal OrElse e.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal Then

                e.Cancel = True

            End If

        End Sub
        Private Sub PivotGridForm_DataEnty_ShownEditor(sender As Object, e As DevExpress.XtraPivotGrid.PivotCellEditEventArgs) Handles PivotGridForm_DataEnty.ShownEditor

            If e.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value AndAlso
                    e.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

                If e.Edit IsNot Nothing Then

                    e.Edit.SelectAll()

                End If

            End If

        End Sub
        Private Sub PivotGridForm_DataEnty_CustomAppearance(sender As Object, e As DevExpress.XtraPivotGrid.PivotCustomAppearanceEventArgs) Handles PivotGridForm_DataEnty.CustomAppearance

            If Me.FormShown AndAlso e.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal AndAlso e.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal AndAlso
                    _ViewModel IsNot Nothing AndAlso _ViewModel.PlanEstimateTemplate IsNot Nothing AndAlso _ViewModel.PlanEstimateTemplate.Type = "I" Then

                Font = e.Appearance.Font
                e.Appearance.FontStyleDelta = Drawing.FontStyle.Bold

            End If

        End Sub
        Private Sub SubItemNumericInput_Spin(sender As Object, e As DevExpress.XtraEditors.Controls.SpinEventArgs)

            PivotGridForm_DataEnty.CloseEditor()

            If e.IsSpinUp Then

                If PivotGridForm_DataEnty.Cells.FocusedCell.Y - 1 < 0 Then

                    PivotGridForm_DataEnty.Cells.FocusedCell = New Drawing.Point(PivotGridForm_DataEnty.Cells.FocusedCell.X, PivotGridForm_DataEnty.Cells.FocusedCell.Y - 1)

                End If

            Else

                If PivotGridForm_DataEnty.Cells.RowCount > PivotGridForm_DataEnty.Cells.FocusedCell.Y + 1 Then

                    PivotGridForm_DataEnty.Cells.FocusedCell = New Drawing.Point(PivotGridForm_DataEnty.Cells.FocusedCell.X, PivotGridForm_DataEnty.Cells.FocusedCell.Y + 1)

                    'Else

                    '    PivotGridForm_DataEnty.Cells.FocusedCell = New Drawing.Point(PivotGridForm_DataEnty.Cells.FocusedCell.X, 0)

                End If

            End If

            e.Handled = True

        End Sub
        Private Sub PivotGridForm_DataEnty_FocusedCellChanged(sender As Object, e As EventArgs) Handles PivotGridForm_DataEnty.FocusedCellChanged

            If PivotGridForm_DataEnty.Cells.GetFocusedCellInfo.DataField.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data.Properties.DaypartPercent.ToString Then

                If PivotGridForm_DataEnty.Cells.ColumnCount > PivotGridForm_DataEnty.Cells.FocusedCell.X + 1 Then

                    PivotGridForm_DataEnty.Cells.FocusedCell = New Drawing.Point(PivotGridForm_DataEnty.Cells.FocusedCell.X + 1, PivotGridForm_DataEnty.Cells.FocusedCell.Y)

                End If

            ElseIf PivotGridForm_DataEnty.Cells.GetFocusedCellInfo.DataField.FieldName = "Weight" Then

                If PivotGridForm_DataEnty.Cells.RowCount > PivotGridForm_DataEnty.Cells.FocusedCell.Y + 1 Then

                    PivotGridForm_DataEnty.Cells.FocusedCell = New Drawing.Point(0, PivotGridForm_DataEnty.Cells.FocusedCell.Y + 1)

                Else

                    PivotGridForm_DataEnty.Cells.FocusedCell = New Drawing.Point(0, 0)

                End If

            ElseIf PivotGridForm_DataEnty.Cells.GetFocusedCellInfo.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal Then

                If PivotGridForm_DataEnty.Cells.ColumnCount = PivotGridForm_DataEnty.Cells.FocusedCell.X + 1 Then

                    If PivotGridForm_DataEnty.Cells.RowCount = PivotGridForm_DataEnty.Cells.FocusedCell.Y + 1 Then

                        PivotGridForm_DataEnty.Cells.FocusedCell = New Drawing.Point(0, 0)

                    Else

                        PivotGridForm_DataEnty.Cells.FocusedCell = New Drawing.Point(0, PivotGridForm_DataEnty.Cells.FocusedCell.Y + 1)

                    End If

                End If

            ElseIf PivotGridForm_DataEnty.Cells.GetFocusedCellInfo.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal Then

                PivotGridForm_DataEnty.Cells.FocusedCell = New Drawing.Point(0, 0)

                'ElseIf PivotGridForm_DataEnty.Cells.ColumnCount = 1 Then

                '    If PivotGridForm_DataEnty.Cells.RowCount = PivotGridForm_DataEnty.Cells.FocusedCell.Y + 1 AndAlso PivotGridForm_DataEnty.Cells.GetFocusedCellInfo.RowValueType <> DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

                '        PivotGridForm_DataEnty.Cells.FocusedCell = New Drawing.Point(0, 0)

                '    End If

                'ElseIf PivotGridForm_DataEnty.Cells.RowCount = 1 Then

                '    If PivotGridForm_DataEnty.Cells.ColumnCount = PivotGridForm_DataEnty.Cells.FocusedCell.X + 1 AndAlso PivotGridForm_DataEnty.Cells.GetFocusedCellInfo.ColumnValueType <> DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

                '        PivotGridForm_DataEnty.Cells.FocusedCell = New Drawing.Point(0, 0)

                '    End If

            End If

            PivotGridForm_DataEnty.Refresh()

        End Sub
        Private Sub ButtonItemMarket_Include_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemMarket_Include.CheckedChanged

            PivotGridForm_DataEnty.CloseEditor()

            RefreshViewModel()

        End Sub
        'Private Sub PivotGridForm_DataEnty_EditorKeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles PivotGridForm_DataEnty.EditorKeyDown

        '    If e.KeyCode = System.Windows.Forms.Keys.Tab Then

        '        If PivotGridForm_DataEnty.Cells.ColumnCount = 1 Then

        '            If PivotGridForm_DataEnty.Cells.RowCount = PivotGridForm_DataEnty.Cells.FocusedCell.Y + 1 AndAlso PivotGridForm_DataEnty.Cells.GetFocusedCellInfo.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

        '                PivotGridForm_DataEnty.Cells.FocusedCell = New Drawing.Point(0, 0)

        '            End If

        '        ElseIf PivotGridForm_DataEnty.Cells.RowCount = 1 Then

        '            If PivotGridForm_DataEnty.Cells.ColumnCount = PivotGridForm_DataEnty.Cells.FocusedCell.X + 1 AndAlso PivotGridForm_DataEnty.Cells.GetFocusedCellInfo.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

        '                PivotGridForm_DataEnty.Cells.FocusedCell = New Drawing.Point(0, 0)

        '            End If

        '        End If

        '    End If

        'End Sub

#End Region

#End Region

    End Class

End Namespace
