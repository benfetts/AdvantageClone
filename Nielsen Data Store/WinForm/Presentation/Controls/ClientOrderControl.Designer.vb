Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ClientOrderControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientOrderControl))
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.GroupBoxControl_EthnicityOptions = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxOption_IsOlympic = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.RadioButtonOption_Asian = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonOption_Black = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonOption_Hispanic = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonOption_Standard = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxControl_AllMarketsCume = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxControl_IsSuspended = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.DataGridViewControl_Markets = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TextBoxControl_OrderType = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelControl_OrderType = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxControl_Report = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.DateTimePickerControl_LastChangedDateTime = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.TextBoxControl_ClientAlias = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelControl_ClientAlias = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.NumericInputControl_EndYear = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.NumericInputControl_StartYear = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.LabelControl_EndYear = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelControl_StartYear = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.NumericInputControl_OrderNumber = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.LabelControl_LastChangedDateTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DateTimePickerControl_OrderDateTime = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelControl_Report = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelControl_OrderDuration = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxControl_OrderDuration = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelControl_OrderDateTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelControl_OrderNumber = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.CheckBoxControl_AllMarkets = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.DataGridViewControl_States = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.CheckBoxControl_AllStates = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.GroupBoxControl_RadioEthnicityOptions = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonOption_RadioBlack = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonOption_RadioHispanic = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonOption_RadioStandard = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.GroupBoxControl_EthnicityOptions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxControl_EthnicityOptions.SuspendLayout()
            CType(Me.DateTimePickerControl_LastChangedDateTime, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputControl_EndYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputControl_StartYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputControl_OrderNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerControl_OrderDateTime, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxControl_RadioEthnicityOptions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxControl_RadioEthnicityOptions.SuspendLayout()
            Me.SuspendLayout()
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_RightSection.Controls.Add(Me.GroupBoxControl_RadioEthnicityOptions)
            Me.PanelForm_RightSection.Controls.Add(Me.GroupBoxControl_EthnicityOptions)
            Me.PanelForm_RightSection.Controls.Add(Me.CheckBoxControl_AllMarketsCume)
            Me.PanelForm_RightSection.Controls.Add(Me.CheckBoxControl_IsSuspended)
            Me.PanelForm_RightSection.Controls.Add(Me.DataGridViewControl_Markets)
            Me.PanelForm_RightSection.Controls.Add(Me.TextBoxControl_OrderType)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_OrderType)
            Me.PanelForm_RightSection.Controls.Add(Me.TextBoxControl_Report)
            Me.PanelForm_RightSection.Controls.Add(Me.DateTimePickerControl_LastChangedDateTime)
            Me.PanelForm_RightSection.Controls.Add(Me.TextBoxControl_ClientAlias)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_ClientAlias)
            Me.PanelForm_RightSection.Controls.Add(Me.NumericInputControl_EndYear)
            Me.PanelForm_RightSection.Controls.Add(Me.NumericInputControl_StartYear)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_EndYear)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_StartYear)
            Me.PanelForm_RightSection.Controls.Add(Me.NumericInputControl_OrderNumber)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_LastChangedDateTime)
            Me.PanelForm_RightSection.Controls.Add(Me.DateTimePickerControl_OrderDateTime)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_Report)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_OrderDuration)
            Me.PanelForm_RightSection.Controls.Add(Me.TextBoxControl_OrderDuration)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_OrderDateTime)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_OrderNumber)
            Me.PanelForm_RightSection.Controls.Add(Me.CheckBoxControl_AllMarkets)
            Me.PanelForm_RightSection.Controls.Add(Me.DataGridViewControl_States)
            Me.PanelForm_RightSection.Controls.Add(Me.CheckBoxControl_AllStates)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(1158, 545)
            Me.PanelForm_RightSection.TabIndex = 0
            '
            'GroupBoxControl_EthnicityOptions
            '
            Me.GroupBoxControl_EthnicityOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxControl_EthnicityOptions.Controls.Add(Me.CheckBoxOption_IsOlympic)
            Me.GroupBoxControl_EthnicityOptions.Controls.Add(Me.RadioButtonOption_Asian)
            Me.GroupBoxControl_EthnicityOptions.Controls.Add(Me.RadioButtonOption_Black)
            Me.GroupBoxControl_EthnicityOptions.Controls.Add(Me.RadioButtonOption_Hispanic)
            Me.GroupBoxControl_EthnicityOptions.Controls.Add(Me.RadioButtonOption_Standard)
            Me.GroupBoxControl_EthnicityOptions.Location = New System.Drawing.Point(350, 27)
            Me.GroupBoxControl_EthnicityOptions.LookAndFeel.SkinName = "Office 2013"
            Me.GroupBoxControl_EthnicityOptions.LookAndFeel.UseDefaultLookAndFeel = False
            Me.GroupBoxControl_EthnicityOptions.Name = "GroupBoxControl_EthnicityOptions"
            Me.GroupBoxControl_EthnicityOptions.Size = New System.Drawing.Size(808, 71)
            Me.GroupBoxControl_EthnicityOptions.TabIndex = 22
            Me.GroupBoxControl_EthnicityOptions.Text = "Order Options"
            '
            'CheckBoxOption_IsOlympic
            '
            '
            '
            '
            Me.CheckBoxOption_IsOlympic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxOption_IsOlympic.CheckValue = 0
            Me.CheckBoxOption_IsOlympic.CheckValueChecked = 1
            Me.CheckBoxOption_IsOlympic.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxOption_IsOlympic.CheckValueUnchecked = 0
            Me.CheckBoxOption_IsOlympic.ChildControls = CType(resources.GetObject("CheckBoxOption_IsOlympic.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOption_IsOlympic.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxOption_IsOlympic.Location = New System.Drawing.Point(5, 46)
            Me.CheckBoxOption_IsOlympic.Name = "CheckBoxOption_IsOlympic"
            Me.CheckBoxOption_IsOlympic.OldestSibling = Nothing
            Me.CheckBoxOption_IsOlympic.SecurityEnabled = True
            Me.CheckBoxOption_IsOlympic.SiblingControls = CType(resources.GetObject("CheckBoxOption_IsOlympic.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOption_IsOlympic.Size = New System.Drawing.Size(148, 20)
            Me.CheckBoxOption_IsOlympic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxOption_IsOlympic.TabIndex = 26
            Me.CheckBoxOption_IsOlympic.TabOnEnter = True
            Me.CheckBoxOption_IsOlympic.Text = "Is Olympic Exclusion"
            '
            'RadioButtonOption_Asian
            '
            Me.RadioButtonOption_Asian.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonOption_Asian.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonOption_Asian.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonOption_Asian.Location = New System.Drawing.Point(239, 22)
            Me.RadioButtonOption_Asian.Name = "RadioButtonOption_Asian"
            Me.RadioButtonOption_Asian.SecurityEnabled = True
            Me.RadioButtonOption_Asian.Size = New System.Drawing.Size(72, 23)
            Me.RadioButtonOption_Asian.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonOption_Asian.TabIndex = 3
            Me.RadioButtonOption_Asian.TabOnEnter = True
            Me.RadioButtonOption_Asian.TabStop = False
            Me.RadioButtonOption_Asian.Tag = "3"
            Me.RadioButtonOption_Asian.Text = "Asian"
            '
            'RadioButtonOption_Black
            '
            Me.RadioButtonOption_Black.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonOption_Black.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonOption_Black.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonOption_Black.Location = New System.Drawing.Point(161, 22)
            Me.RadioButtonOption_Black.Name = "RadioButtonOption_Black"
            Me.RadioButtonOption_Black.SecurityEnabled = True
            Me.RadioButtonOption_Black.Size = New System.Drawing.Size(72, 23)
            Me.RadioButtonOption_Black.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonOption_Black.TabIndex = 2
            Me.RadioButtonOption_Black.TabOnEnter = True
            Me.RadioButtonOption_Black.TabStop = False
            Me.RadioButtonOption_Black.Tag = "2"
            Me.RadioButtonOption_Black.Text = "Black"
            '
            'RadioButtonOption_Hispanic
            '
            Me.RadioButtonOption_Hispanic.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonOption_Hispanic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonOption_Hispanic.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonOption_Hispanic.Location = New System.Drawing.Point(83, 22)
            Me.RadioButtonOption_Hispanic.Name = "RadioButtonOption_Hispanic"
            Me.RadioButtonOption_Hispanic.SecurityEnabled = True
            Me.RadioButtonOption_Hispanic.Size = New System.Drawing.Size(72, 23)
            Me.RadioButtonOption_Hispanic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonOption_Hispanic.TabIndex = 1
            Me.RadioButtonOption_Hispanic.TabOnEnter = True
            Me.RadioButtonOption_Hispanic.TabStop = False
            Me.RadioButtonOption_Hispanic.Tag = "1"
            Me.RadioButtonOption_Hispanic.Text = "Hispanic"
            '
            'RadioButtonOption_Standard
            '
            Me.RadioButtonOption_Standard.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonOption_Standard.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonOption_Standard.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonOption_Standard.Location = New System.Drawing.Point(5, 22)
            Me.RadioButtonOption_Standard.Name = "RadioButtonOption_Standard"
            Me.RadioButtonOption_Standard.SecurityEnabled = True
            Me.RadioButtonOption_Standard.Size = New System.Drawing.Size(72, 23)
            Me.RadioButtonOption_Standard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonOption_Standard.TabIndex = 0
            Me.RadioButtonOption_Standard.TabOnEnter = True
            Me.RadioButtonOption_Standard.TabStop = False
            Me.RadioButtonOption_Standard.Tag = "0"
            Me.RadioButtonOption_Standard.Text = "Regular"
            '
            'CheckBoxControl_AllMarketsCume
            '
            '
            '
            '
            Me.CheckBoxControl_AllMarketsCume.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_AllMarketsCume.CheckValue = 0
            Me.CheckBoxControl_AllMarketsCume.CheckValueChecked = 1
            Me.CheckBoxControl_AllMarketsCume.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_AllMarketsCume.CheckValueUnchecked = 0
            Me.CheckBoxControl_AllMarketsCume.ChildControls = CType(resources.GetObject("CheckBoxControl_AllMarketsCume.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_AllMarketsCume.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_AllMarketsCume.Location = New System.Drawing.Point(109, 182)
            Me.CheckBoxControl_AllMarketsCume.Name = "CheckBoxControl_AllMarketsCume"
            Me.CheckBoxControl_AllMarketsCume.OldestSibling = Nothing
            Me.CheckBoxControl_AllMarketsCume.SecurityEnabled = True
            Me.CheckBoxControl_AllMarketsCume.SiblingControls = CType(resources.GetObject("CheckBoxControl_AllMarketsCume.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_AllMarketsCume.Size = New System.Drawing.Size(103, 20)
            Me.CheckBoxControl_AllMarketsCume.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_AllMarketsCume.TabIndex = 17
            Me.CheckBoxControl_AllMarketsCume.TabOnEnter = True
            Me.CheckBoxControl_AllMarketsCume.Text = "Cume"
            '
            'CheckBoxControl_IsSuspended
            '
            '
            '
            '
            Me.CheckBoxControl_IsSuspended.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_IsSuspended.CheckValue = 0
            Me.CheckBoxControl_IsSuspended.CheckValueChecked = 1
            Me.CheckBoxControl_IsSuspended.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_IsSuspended.CheckValueUnchecked = 0
            Me.CheckBoxControl_IsSuspended.ChildControls = CType(resources.GetObject("CheckBoxControl_IsSuspended.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_IsSuspended.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_IsSuspended.Location = New System.Drawing.Point(509, 1)
            Me.CheckBoxControl_IsSuspended.Name = "CheckBoxControl_IsSuspended"
            Me.CheckBoxControl_IsSuspended.OldestSibling = Nothing
            Me.CheckBoxControl_IsSuspended.SecurityEnabled = True
            Me.CheckBoxControl_IsSuspended.SiblingControls = CType(resources.GetObject("CheckBoxControl_IsSuspended.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_IsSuspended.Size = New System.Drawing.Size(103, 20)
            Me.CheckBoxControl_IsSuspended.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_IsSuspended.TabIndex = 21
            Me.CheckBoxControl_IsSuspended.TabOnEnter = True
            Me.CheckBoxControl_IsSuspended.Text = "Is Suspended"
            '
            'DataGridViewControl_Markets
            '
            Me.DataGridViewControl_Markets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_Markets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewControl_Markets.AutoUpdateViewCaption = True
            Me.DataGridViewControl_Markets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_Markets.ItemDescription = "Market(s)"
            Me.DataGridViewControl_Markets.Location = New System.Drawing.Point(0, 208)
            Me.DataGridViewControl_Markets.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewControl_Markets.ModifyGridRowHeight = False
            Me.DataGridViewControl_Markets.MultiSelect = True
            Me.DataGridViewControl_Markets.Name = "DataGridViewControl_Markets"
            Me.DataGridViewControl_Markets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewControl_Markets.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewControl_Markets.ShowRowSelectionIfHidden = True
            Me.DataGridViewControl_Markets.ShowSelectDeselectAllButtons = False
            Me.DataGridViewControl_Markets.Size = New System.Drawing.Size(1158, 337)
            Me.DataGridViewControl_Markets.TabIndex = 18
            Me.DataGridViewControl_Markets.UseEmbeddedNavigator = False
            Me.DataGridViewControl_Markets.ViewCaptionHeight = -1
            '
            'TextBoxControl_OrderType
            '
            Me.TextBoxControl_OrderType.AgencyImportPath = Nothing
            Me.TextBoxControl_OrderType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_OrderType.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_OrderType.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_OrderType.CheckSpellingOnValidate = False
            Me.TextBoxControl_OrderType.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_OrderType.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxControl_OrderType.DisplayName = ""
            Me.TextBoxControl_OrderType.Enabled = False
            Me.TextBoxControl_OrderType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_OrderType.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_OrderType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_OrderType.FocusHighlightEnabled = True
            Me.TextBoxControl_OrderType.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_OrderType.Location = New System.Drawing.Point(350, 0)
            Me.TextBoxControl_OrderType.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_OrderType.Name = "TextBoxControl_OrderType"
            Me.TextBoxControl_OrderType.ReadOnly = True
            Me.TextBoxControl_OrderType.SecurityEnabled = True
            Me.TextBoxControl_OrderType.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_OrderType.Size = New System.Drawing.Size(153, 21)
            Me.TextBoxControl_OrderType.StartingFolderName = Nothing
            Me.TextBoxControl_OrderType.TabIndex = 20
            Me.TextBoxControl_OrderType.TabOnEnter = True
            Me.TextBoxControl_OrderType.TabStop = False
            '
            'LabelControl_OrderType
            '
            Me.LabelControl_OrderType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_OrderType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_OrderType.Location = New System.Drawing.Point(254, 0)
            Me.LabelControl_OrderType.Name = "LabelControl_OrderType"
            Me.LabelControl_OrderType.Size = New System.Drawing.Size(90, 20)
            Me.LabelControl_OrderType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_OrderType.TabIndex = 19
            Me.LabelControl_OrderType.Text = "Order Type:"
            '
            'TextBoxControl_Report
            '
            Me.TextBoxControl_Report.AgencyImportPath = Nothing
            Me.TextBoxControl_Report.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxControl_Report.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_Report.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_Report.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Report.CheckSpellingOnValidate = False
            Me.TextBoxControl_Report.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Report.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxControl_Report.DisplayName = ""
            Me.TextBoxControl_Report.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_Report.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Report.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Report.FocusHighlightEnabled = True
            Me.TextBoxControl_Report.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_Report.Location = New System.Drawing.Point(109, 130)
            Me.TextBoxControl_Report.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Report.Name = "TextBoxControl_Report"
            Me.TextBoxControl_Report.SecurityEnabled = True
            Me.TextBoxControl_Report.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Report.Size = New System.Drawing.Size(1048, 21)
            Me.TextBoxControl_Report.StartingFolderName = Nothing
            Me.TextBoxControl_Report.TabIndex = 13
            Me.TextBoxControl_Report.TabOnEnter = True
            '
            'DateTimePickerControl_LastChangedDateTime
            '
            Me.DateTimePickerControl_LastChangedDateTime.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerControl_LastChangedDateTime.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerControl_LastChangedDateTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_LastChangedDateTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerControl_LastChangedDateTime.ButtonDropDown.Visible = True
            Me.DateTimePickerControl_LastChangedDateTime.ButtonFreeText.Checked = True
            Me.DateTimePickerControl_LastChangedDateTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDateAndTime
            Me.DateTimePickerControl_LastChangedDateTime.CustomFormat = "M/d/yyyy h:mm tt"
            Me.DateTimePickerControl_LastChangedDateTime.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both
            Me.DateTimePickerControl_LastChangedDateTime.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerControl_LastChangedDateTime.DisplayName = "Last Changed"
            Me.DateTimePickerControl_LastChangedDateTime.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerControl_LastChangedDateTime.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerControl_LastChangedDateTime.FocusHighlightEnabled = True
            Me.DateTimePickerControl_LastChangedDateTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
            Me.DateTimePickerControl_LastChangedDateTime.FreeTextEntryMode = True
            Me.DateTimePickerControl_LastChangedDateTime.IsPopupCalendarOpen = False
            Me.DateTimePickerControl_LastChangedDateTime.Location = New System.Drawing.Point(109, 52)
            Me.DateTimePickerControl_LastChangedDateTime.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerControl_LastChangedDateTime.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.DayClickAutoClosePopup = False
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_LastChangedDateTime.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerControl_LastChangedDateTime.Name = "DateTimePickerControl_LastChangedDateTime"
            Me.DateTimePickerControl_LastChangedDateTime.ReadOnly = False
            Me.DateTimePickerControl_LastChangedDateTime.Size = New System.Drawing.Size(139, 21)
            Me.DateTimePickerControl_LastChangedDateTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerControl_LastChangedDateTime.TabIndex = 5
            Me.DateTimePickerControl_LastChangedDateTime.TabOnEnter = True
            Me.DateTimePickerControl_LastChangedDateTime.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time12H
            Me.DateTimePickerControl_LastChangedDateTime.Value = New Date(2017, 4, 21, 14, 23, 56, 150)
            '
            'TextBoxControl_ClientAlias
            '
            Me.TextBoxControl_ClientAlias.AgencyImportPath = Nothing
            Me.TextBoxControl_ClientAlias.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxControl_ClientAlias.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_ClientAlias.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_ClientAlias.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_ClientAlias.CheckSpellingOnValidate = False
            Me.TextBoxControl_ClientAlias.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_ClientAlias.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxControl_ClientAlias.DisplayName = ""
            Me.TextBoxControl_ClientAlias.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_ClientAlias.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_ClientAlias.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_ClientAlias.FocusHighlightEnabled = True
            Me.TextBoxControl_ClientAlias.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_ClientAlias.Location = New System.Drawing.Point(109, 156)
            Me.TextBoxControl_ClientAlias.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_ClientAlias.Name = "TextBoxControl_ClientAlias"
            Me.TextBoxControl_ClientAlias.SecurityEnabled = True
            Me.TextBoxControl_ClientAlias.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_ClientAlias.Size = New System.Drawing.Size(1048, 21)
            Me.TextBoxControl_ClientAlias.StartingFolderName = Nothing
            Me.TextBoxControl_ClientAlias.TabIndex = 15
            Me.TextBoxControl_ClientAlias.TabOnEnter = True
            '
            'LabelControl_ClientAlias
            '
            Me.LabelControl_ClientAlias.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_ClientAlias.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_ClientAlias.Location = New System.Drawing.Point(0, 156)
            Me.LabelControl_ClientAlias.Name = "LabelControl_ClientAlias"
            Me.LabelControl_ClientAlias.Size = New System.Drawing.Size(103, 20)
            Me.LabelControl_ClientAlias.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_ClientAlias.TabIndex = 14
            Me.LabelControl_ClientAlias.Text = "Client Alias:"
            '
            'NumericInputControl_EndYear
            '
            Me.NumericInputControl_EndYear.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_EndYear.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Short]
            Me.NumericInputControl_EndYear.EditValue = New Decimal(New Integer() {2017, 0, 0, 0})
            Me.NumericInputControl_EndYear.EnterMoveNextControl = True
            Me.NumericInputControl_EndYear.Location = New System.Drawing.Point(263, 78)
            Me.NumericInputControl_EndYear.Name = "NumericInputControl_EndYear"
            Me.NumericInputControl_EndYear.Properties.AllowMouseWheel = False
            Me.NumericInputControl_EndYear.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputControl_EndYear.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputControl_EndYear.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_EndYear.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputControl_EndYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_EndYear.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputControl_EndYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_EndYear.Properties.IsFloatValue = False
            Me.NumericInputControl_EndYear.Properties.Mask.EditMask = "f0"
            Me.NumericInputControl_EndYear.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_EndYear.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputControl_EndYear.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputControl_EndYear.SecurityEnabled = True
            Me.NumericInputControl_EndYear.Size = New System.Drawing.Size(81, 20)
            Me.NumericInputControl_EndYear.TabIndex = 9
            '
            'NumericInputControl_StartYear
            '
            Me.NumericInputControl_StartYear.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_StartYear.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Short]
            Me.NumericInputControl_StartYear.EditValue = New Decimal(New Integer() {2017, 0, 0, 0})
            Me.NumericInputControl_StartYear.EnterMoveNextControl = True
            Me.NumericInputControl_StartYear.Location = New System.Drawing.Point(109, 78)
            Me.NumericInputControl_StartYear.Name = "NumericInputControl_StartYear"
            Me.NumericInputControl_StartYear.Properties.AllowMouseWheel = False
            Me.NumericInputControl_StartYear.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputControl_StartYear.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputControl_StartYear.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_StartYear.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputControl_StartYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_StartYear.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputControl_StartYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_StartYear.Properties.IsFloatValue = False
            Me.NumericInputControl_StartYear.Properties.Mask.EditMask = "f0"
            Me.NumericInputControl_StartYear.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_StartYear.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputControl_StartYear.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputControl_StartYear.SecurityEnabled = True
            Me.NumericInputControl_StartYear.Size = New System.Drawing.Size(81, 20)
            Me.NumericInputControl_StartYear.TabIndex = 7
            '
            'LabelControl_EndYear
            '
            Me.LabelControl_EndYear.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_EndYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_EndYear.Location = New System.Drawing.Point(196, 78)
            Me.LabelControl_EndYear.Name = "LabelControl_EndYear"
            Me.LabelControl_EndYear.Size = New System.Drawing.Size(61, 20)
            Me.LabelControl_EndYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_EndYear.TabIndex = 8
            Me.LabelControl_EndYear.Text = "End Year:"
            '
            'LabelControl_StartYear
            '
            Me.LabelControl_StartYear.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_StartYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_StartYear.Location = New System.Drawing.Point(0, 78)
            Me.LabelControl_StartYear.Name = "LabelControl_StartYear"
            Me.LabelControl_StartYear.Size = New System.Drawing.Size(103, 20)
            Me.LabelControl_StartYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_StartYear.TabIndex = 6
            Me.LabelControl_StartYear.Text = "Start Year:"
            '
            'NumericInputControl_OrderNumber
            '
            Me.NumericInputControl_OrderNumber.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_OrderNumber.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputControl_OrderNumber.EditValue = New Decimal(New Integer() {2017, 0, 0, 0})
            Me.NumericInputControl_OrderNumber.EnterMoveNextControl = True
            Me.NumericInputControl_OrderNumber.Location = New System.Drawing.Point(109, 0)
            Me.NumericInputControl_OrderNumber.Name = "NumericInputControl_OrderNumber"
            Me.NumericInputControl_OrderNumber.Properties.AllowMouseWheel = False
            Me.NumericInputControl_OrderNumber.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputControl_OrderNumber.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputControl_OrderNumber.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_OrderNumber.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputControl_OrderNumber.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_OrderNumber.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputControl_OrderNumber.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_OrderNumber.Properties.IsFloatValue = False
            Me.NumericInputControl_OrderNumber.Properties.Mask.EditMask = "f0"
            Me.NumericInputControl_OrderNumber.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_OrderNumber.Properties.MaxValue = New Decimal(New Integer() {2079, 0, 0, 0})
            Me.NumericInputControl_OrderNumber.Properties.MinValue = New Decimal(New Integer() {1980, 0, 0, 0})
            Me.NumericInputControl_OrderNumber.SecurityEnabled = True
            Me.NumericInputControl_OrderNumber.Size = New System.Drawing.Size(139, 20)
            Me.NumericInputControl_OrderNumber.TabIndex = 1
            '
            'LabelControl_LastChangedDateTime
            '
            Me.LabelControl_LastChangedDateTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_LastChangedDateTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_LastChangedDateTime.Location = New System.Drawing.Point(0, 52)
            Me.LabelControl_LastChangedDateTime.Name = "LabelControl_LastChangedDateTime"
            Me.LabelControl_LastChangedDateTime.Size = New System.Drawing.Size(103, 20)
            Me.LabelControl_LastChangedDateTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_LastChangedDateTime.TabIndex = 4
            Me.LabelControl_LastChangedDateTime.Text = "Last Changed:"
            '
            'DateTimePickerControl_OrderDateTime
            '
            Me.DateTimePickerControl_OrderDateTime.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerControl_OrderDateTime.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerControl_OrderDateTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_OrderDateTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerControl_OrderDateTime.ButtonDropDown.Visible = True
            Me.DateTimePickerControl_OrderDateTime.ButtonFreeText.Checked = True
            Me.DateTimePickerControl_OrderDateTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDateAndTime
            Me.DateTimePickerControl_OrderDateTime.CustomFormat = "M/d/yyyy h:mm tt"
            Me.DateTimePickerControl_OrderDateTime.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both
            Me.DateTimePickerControl_OrderDateTime.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerControl_OrderDateTime.DisplayName = "Order Date Time"
            Me.DateTimePickerControl_OrderDateTime.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerControl_OrderDateTime.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerControl_OrderDateTime.FocusHighlightEnabled = True
            Me.DateTimePickerControl_OrderDateTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
            Me.DateTimePickerControl_OrderDateTime.FreeTextEntryMode = True
            Me.DateTimePickerControl_OrderDateTime.IsPopupCalendarOpen = False
            Me.DateTimePickerControl_OrderDateTime.Location = New System.Drawing.Point(109, 26)
            Me.DateTimePickerControl_OrderDateTime.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerControl_OrderDateTime.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.DayClickAutoClosePopup = False
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_OrderDateTime.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerControl_OrderDateTime.Name = "DateTimePickerControl_OrderDateTime"
            Me.DateTimePickerControl_OrderDateTime.ReadOnly = False
            Me.DateTimePickerControl_OrderDateTime.Size = New System.Drawing.Size(139, 21)
            Me.DateTimePickerControl_OrderDateTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerControl_OrderDateTime.TabIndex = 3
            Me.DateTimePickerControl_OrderDateTime.TabOnEnter = True
            Me.DateTimePickerControl_OrderDateTime.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time12H
            Me.DateTimePickerControl_OrderDateTime.Value = New Date(2017, 4, 21, 14, 23, 56, 150)
            '
            'LabelControl_Report
            '
            Me.LabelControl_Report.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Report.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Report.Location = New System.Drawing.Point(0, 130)
            Me.LabelControl_Report.Name = "LabelControl_Report"
            Me.LabelControl_Report.Size = New System.Drawing.Size(103, 20)
            Me.LabelControl_Report.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Report.TabIndex = 12
            Me.LabelControl_Report.Text = "Report:"
            '
            'LabelControl_OrderDuration
            '
            Me.LabelControl_OrderDuration.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_OrderDuration.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_OrderDuration.Location = New System.Drawing.Point(0, 104)
            Me.LabelControl_OrderDuration.Name = "LabelControl_OrderDuration"
            Me.LabelControl_OrderDuration.Size = New System.Drawing.Size(103, 20)
            Me.LabelControl_OrderDuration.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_OrderDuration.TabIndex = 10
            Me.LabelControl_OrderDuration.Text = "Order Duration:"
            '
            'TextBoxControl_OrderDuration
            '
            Me.TextBoxControl_OrderDuration.AgencyImportPath = Nothing
            Me.TextBoxControl_OrderDuration.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxControl_OrderDuration.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_OrderDuration.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_OrderDuration.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_OrderDuration.CheckSpellingOnValidate = False
            Me.TextBoxControl_OrderDuration.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_OrderDuration.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxControl_OrderDuration.DisplayName = ""
            Me.TextBoxControl_OrderDuration.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_OrderDuration.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_OrderDuration.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_OrderDuration.FocusHighlightEnabled = True
            Me.TextBoxControl_OrderDuration.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_OrderDuration.Location = New System.Drawing.Point(109, 104)
            Me.TextBoxControl_OrderDuration.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_OrderDuration.Name = "TextBoxControl_OrderDuration"
            Me.TextBoxControl_OrderDuration.SecurityEnabled = True
            Me.TextBoxControl_OrderDuration.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_OrderDuration.Size = New System.Drawing.Size(1048, 21)
            Me.TextBoxControl_OrderDuration.StartingFolderName = Nothing
            Me.TextBoxControl_OrderDuration.TabIndex = 11
            Me.TextBoxControl_OrderDuration.TabOnEnter = True
            '
            'LabelControl_OrderDateTime
            '
            Me.LabelControl_OrderDateTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_OrderDateTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_OrderDateTime.Location = New System.Drawing.Point(0, 26)
            Me.LabelControl_OrderDateTime.Name = "LabelControl_OrderDateTime"
            Me.LabelControl_OrderDateTime.Size = New System.Drawing.Size(103, 20)
            Me.LabelControl_OrderDateTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_OrderDateTime.TabIndex = 2
            Me.LabelControl_OrderDateTime.Text = "Order Date Time:"
            '
            'LabelControl_OrderNumber
            '
            Me.LabelControl_OrderNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_OrderNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_OrderNumber.Location = New System.Drawing.Point(0, 0)
            Me.LabelControl_OrderNumber.Name = "LabelControl_OrderNumber"
            Me.LabelControl_OrderNumber.Size = New System.Drawing.Size(103, 20)
            Me.LabelControl_OrderNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_OrderNumber.TabIndex = 0
            Me.LabelControl_OrderNumber.Text = "Order Number:"
            '
            'CheckBoxControl_AllMarkets
            '
            '
            '
            '
            Me.CheckBoxControl_AllMarkets.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_AllMarkets.CheckValue = 0
            Me.CheckBoxControl_AllMarkets.CheckValueChecked = 1
            Me.CheckBoxControl_AllMarkets.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_AllMarkets.CheckValueUnchecked = 0
            Me.CheckBoxControl_AllMarkets.ChildControls = CType(resources.GetObject("CheckBoxControl_AllMarkets.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_AllMarkets.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_AllMarkets.Location = New System.Drawing.Point(0, 182)
            Me.CheckBoxControl_AllMarkets.Name = "CheckBoxControl_AllMarkets"
            Me.CheckBoxControl_AllMarkets.OldestSibling = Nothing
            Me.CheckBoxControl_AllMarkets.SecurityEnabled = True
            Me.CheckBoxControl_AllMarkets.SiblingControls = CType(resources.GetObject("CheckBoxControl_AllMarkets.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_AllMarkets.Size = New System.Drawing.Size(103, 20)
            Me.CheckBoxControl_AllMarkets.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_AllMarkets.TabIndex = 16
            Me.CheckBoxControl_AllMarkets.TabOnEnter = True
            Me.CheckBoxControl_AllMarkets.Text = "All Markets"
            '
            'DataGridViewControl_States
            '
            Me.DataGridViewControl_States.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_States.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewControl_States.AutoUpdateViewCaption = True
            Me.DataGridViewControl_States.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_States.ItemDescription = "State(s)"
            Me.DataGridViewControl_States.Location = New System.Drawing.Point(0, 208)
            Me.DataGridViewControl_States.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewControl_States.ModifyGridRowHeight = False
            Me.DataGridViewControl_States.MultiSelect = True
            Me.DataGridViewControl_States.Name = "DataGridViewControl_States"
            Me.DataGridViewControl_States.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewControl_States.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewControl_States.ShowRowSelectionIfHidden = True
            Me.DataGridViewControl_States.ShowSelectDeselectAllButtons = False
            Me.DataGridViewControl_States.Size = New System.Drawing.Size(1158, 337)
            Me.DataGridViewControl_States.TabIndex = 23
            Me.DataGridViewControl_States.UseEmbeddedNavigator = False
            Me.DataGridViewControl_States.ViewCaptionHeight = -1
            '
            'CheckBoxControl_AllStates
            '
            '
            '
            '
            Me.CheckBoxControl_AllStates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_AllStates.CheckValue = 0
            Me.CheckBoxControl_AllStates.CheckValueChecked = 1
            Me.CheckBoxControl_AllStates.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_AllStates.CheckValueUnchecked = 0
            Me.CheckBoxControl_AllStates.ChildControls = CType(resources.GetObject("CheckBoxControl_AllStates.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_AllStates.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_AllStates.Location = New System.Drawing.Point(0, 182)
            Me.CheckBoxControl_AllStates.Name = "CheckBoxControl_AllStates"
            Me.CheckBoxControl_AllStates.OldestSibling = Nothing
            Me.CheckBoxControl_AllStates.SecurityEnabled = True
            Me.CheckBoxControl_AllStates.SiblingControls = CType(resources.GetObject("CheckBoxControl_AllStates.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_AllStates.Size = New System.Drawing.Size(103, 20)
            Me.CheckBoxControl_AllStates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_AllStates.TabIndex = 24
            Me.CheckBoxControl_AllStates.TabOnEnter = True
            Me.CheckBoxControl_AllStates.Text = "All States"
            '
            'GroupBoxControl_RadioEthnicityOptions
            '
            Me.GroupBoxControl_RadioEthnicityOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxControl_RadioEthnicityOptions.Controls.Add(Me.RadioButtonOption_RadioBlack)
            Me.GroupBoxControl_RadioEthnicityOptions.Controls.Add(Me.RadioButtonOption_RadioHispanic)
            Me.GroupBoxControl_RadioEthnicityOptions.Controls.Add(Me.RadioButtonOption_RadioStandard)
            Me.GroupBoxControl_RadioEthnicityOptions.Location = New System.Drawing.Point(350, 27)
            Me.GroupBoxControl_RadioEthnicityOptions.LookAndFeel.SkinName = "Office 2013"
            Me.GroupBoxControl_RadioEthnicityOptions.LookAndFeel.UseDefaultLookAndFeel = False
            Me.GroupBoxControl_RadioEthnicityOptions.Name = "GroupBoxControl_RadioEthnicityOptions"
            Me.GroupBoxControl_RadioEthnicityOptions.Size = New System.Drawing.Size(808, 71)
            Me.GroupBoxControl_RadioEthnicityOptions.TabIndex = 25
            Me.GroupBoxControl_RadioEthnicityOptions.Text = "Order Options"
            '
            'RadioButtonOption_RadioBlack
            '
            Me.RadioButtonOption_RadioBlack.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonOption_RadioBlack.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonOption_RadioBlack.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonOption_RadioBlack.Location = New System.Drawing.Point(161, 22)
            Me.RadioButtonOption_RadioBlack.Name = "RadioButtonOption_RadioBlack"
            Me.RadioButtonOption_RadioBlack.SecurityEnabled = True
            Me.RadioButtonOption_RadioBlack.Size = New System.Drawing.Size(72, 23)
            Me.RadioButtonOption_RadioBlack.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonOption_RadioBlack.TabIndex = 2
            Me.RadioButtonOption_RadioBlack.TabOnEnter = True
            Me.RadioButtonOption_RadioBlack.TabStop = False
            Me.RadioButtonOption_RadioBlack.Tag = "2"
            Me.RadioButtonOption_RadioBlack.Text = "Black"
            '
            'RadioButtonOption_RadioHispanic
            '
            Me.RadioButtonOption_RadioHispanic.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonOption_RadioHispanic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonOption_RadioHispanic.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonOption_RadioHispanic.Location = New System.Drawing.Point(83, 22)
            Me.RadioButtonOption_RadioHispanic.Name = "RadioButtonOption_RadioHispanic"
            Me.RadioButtonOption_RadioHispanic.SecurityEnabled = True
            Me.RadioButtonOption_RadioHispanic.Size = New System.Drawing.Size(72, 23)
            Me.RadioButtonOption_RadioHispanic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonOption_RadioHispanic.TabIndex = 1
            Me.RadioButtonOption_RadioHispanic.TabOnEnter = True
            Me.RadioButtonOption_RadioHispanic.TabStop = False
            Me.RadioButtonOption_RadioHispanic.Tag = "1"
            Me.RadioButtonOption_RadioHispanic.Text = "Hispanic"
            '
            'RadioButtonOption_RadioStandard
            '
            Me.RadioButtonOption_RadioStandard.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonOption_RadioStandard.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonOption_RadioStandard.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonOption_RadioStandard.Location = New System.Drawing.Point(5, 22)
            Me.RadioButtonOption_RadioStandard.Name = "RadioButtonOption_RadioStandard"
            Me.RadioButtonOption_RadioStandard.SecurityEnabled = True
            Me.RadioButtonOption_RadioStandard.Size = New System.Drawing.Size(72, 23)
            Me.RadioButtonOption_RadioStandard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonOption_RadioStandard.TabIndex = 0
            Me.RadioButtonOption_RadioStandard.TabOnEnter = True
            Me.RadioButtonOption_RadioStandard.TabStop = False
            Me.RadioButtonOption_RadioStandard.Tag = "0"
            Me.RadioButtonOption_RadioStandard.Text = "Regular"
            '
            'ClientOrderControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Name = "ClientOrderControl"
            Me.Size = New System.Drawing.Size(1158, 545)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.GroupBoxControl_EthnicityOptions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxControl_EthnicityOptions.ResumeLayout(False)
            CType(Me.DateTimePickerControl_LastChangedDateTime, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputControl_EndYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputControl_StartYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputControl_OrderNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerControl_OrderDateTime, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxControl_RadioEthnicityOptions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxControl_RadioEthnicityOptions.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents LabelControl_Report As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelControl_OrderDuration As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxControl_OrderDuration As AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_OrderDateTime As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelControl_OrderNumber As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents CheckBoxControl_AllMarkets As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents LabelControl_LastChangedDateTime As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DateTimePickerControl_OrderDateTime As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents NumericInputControl_OrderNumber As AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputControl_EndYear As AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputControl_StartYear As AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput
        Friend WithEvents LabelControl_EndYear As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelControl_StartYear As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxControl_ClientAlias As AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_ClientAlias As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DateTimePickerControl_LastChangedDateTime As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents TextBoxControl_Report As AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents TextBoxControl_OrderType As AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_OrderType As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DataGridViewControl_Markets As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents CheckBoxControl_IsSuspended As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxControl_AllMarketsCume As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents DataGridViewControl_States As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents CheckBoxControl_AllStates As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxControl_EthnicityOptions As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonOption_Standard As AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonOption_Asian As AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonOption_Black As AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonOption_Hispanic As AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxOption_IsOlympic As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxControl_RadioEthnicityOptions As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonOption_RadioBlack As AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonOption_RadioHispanic As AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonOption_RadioStandard As AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl
    End Class

End Namespace
