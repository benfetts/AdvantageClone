Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class GeneralLedgerTransactionDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GeneralLedgerTransactionDialog))
            Me.PanelForm_MainSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.NumericInputPanel_ControlAmount = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelPanel_ControlAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxPanel_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPanel_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPanel_TransactionDate = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPanel_CreatedBy = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPanel_Source = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPanel_Transaction = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelPanel_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxPanel_Posted = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelPanel_TransactionDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPanel_CreatedBy = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPanel_Source = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPanel_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPanel_Transaction = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewPanel_TransactionDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonForm_Close = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            CType(Me.PanelForm_MainSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_MainSection.SuspendLayout()
            CType(Me.NumericInputPanel_ControlAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'PanelForm_MainSection
            '
            Me.PanelForm_MainSection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelForm_MainSection.Controls.Add(Me.NumericInputPanel_ControlAmount)
            Me.PanelForm_MainSection.Controls.Add(Me.LabelPanel_ControlAmount)
            Me.PanelForm_MainSection.Controls.Add(Me.TextBoxPanel_PostPeriod)
            Me.PanelForm_MainSection.Controls.Add(Me.TextBoxPanel_Description)
            Me.PanelForm_MainSection.Controls.Add(Me.TextBoxPanel_TransactionDate)
            Me.PanelForm_MainSection.Controls.Add(Me.TextBoxPanel_CreatedBy)
            Me.PanelForm_MainSection.Controls.Add(Me.TextBoxPanel_Source)
            Me.PanelForm_MainSection.Controls.Add(Me.TextBoxPanel_Transaction)
            Me.PanelForm_MainSection.Controls.Add(Me.LabelPanel_Description)
            Me.PanelForm_MainSection.Controls.Add(Me.CheckBoxPanel_Posted)
            Me.PanelForm_MainSection.Controls.Add(Me.LabelPanel_TransactionDate)
            Me.PanelForm_MainSection.Controls.Add(Me.LabelPanel_CreatedBy)
            Me.PanelForm_MainSection.Controls.Add(Me.LabelPanel_Source)
            Me.PanelForm_MainSection.Controls.Add(Me.LabelPanel_PostPeriod)
            Me.PanelForm_MainSection.Controls.Add(Me.LabelPanel_Transaction)
            Me.PanelForm_MainSection.Controls.Add(Me.DataGridViewPanel_TransactionDetails)
            Me.PanelForm_MainSection.Location = New System.Drawing.Point(12, 12)
            Me.PanelForm_MainSection.Name = "PanelForm_MainSection"
            Me.PanelForm_MainSection.Size = New System.Drawing.Size(968, 626)
            Me.PanelForm_MainSection.TabIndex = 0
            '
            'NumericInputPanel_ControlAmount
            '
            Me.NumericInputPanel_ControlAmount.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputPanel_ControlAmount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputPanel_ControlAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputPanel_ControlAmount.Location = New System.Drawing.Point(799, 5)
            Me.NumericInputPanel_ControlAmount.Name = "NumericInputPanel_ControlAmount"
            Me.NumericInputPanel_ControlAmount.Properties.DisplayFormat.FormatString = "c2"
            Me.NumericInputPanel_ControlAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputPanel_ControlAmount.Properties.EditFormat.FormatString = "c2"
            Me.NumericInputPanel_ControlAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputPanel_ControlAmount.Properties.Mask.EditMask = "f"
            Me.NumericInputPanel_ControlAmount.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputPanel_ControlAmount.Size = New System.Drawing.Size(164, 20)
            Me.NumericInputPanel_ControlAmount.TabIndex = 28
            '
            'LabelPanel_ControlAmount
            '
            Me.LabelPanel_ControlAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_ControlAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_ControlAmount.Location = New System.Drawing.Point(707, 5)
            Me.LabelPanel_ControlAmount.Name = "LabelPanel_ControlAmount"
            Me.LabelPanel_ControlAmount.Size = New System.Drawing.Size(86, 20)
            Me.LabelPanel_ControlAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_ControlAmount.TabIndex = 12
            Me.LabelPanel_ControlAmount.Text = "Control Amount:"
            '
            'TextBoxPanel_PostPeriod
            '
            '
            '
            '
            Me.TextBoxPanel_PostPeriod.Border.Class = "TextBoxBorder"
            Me.TextBoxPanel_PostPeriod.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPanel_PostPeriod.CheckSpellingOnValidate = False
            Me.TextBoxPanel_PostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPanel_PostPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPanel_PostPeriod.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPanel_PostPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPanel_PostPeriod.FocusHighlightEnabled = True
            Me.TextBoxPanel_PostPeriod.Location = New System.Drawing.Point(368, 5)
            Me.TextBoxPanel_PostPeriod.MaxFileSize = CType(0, Long)
            Me.TextBoxPanel_PostPeriod.Name = "TextBoxPanel_PostPeriod"
            Me.TextBoxPanel_PostPeriod.ReadOnly = True
            Me.TextBoxPanel_PostPeriod.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPanel_PostPeriod.Size = New System.Drawing.Size(110, 20)
            Me.TextBoxPanel_PostPeriod.TabIndex = 7
            Me.TextBoxPanel_PostPeriod.TabOnEnter = True
            Me.TextBoxPanel_PostPeriod.TabStop = False
            '
            'TextBoxPanel_Description
            '
            '
            '
            '
            Me.TextBoxPanel_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxPanel_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPanel_Description.CheckSpellingOnValidate = False
            Me.TextBoxPanel_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPanel_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPanel_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPanel_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPanel_Description.FocusHighlightEnabled = True
            Me.TextBoxPanel_Description.Location = New System.Drawing.Point(368, 58)
            Me.TextBoxPanel_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxPanel_Description.Name = "TextBoxPanel_Description"
            Me.TextBoxPanel_Description.ReadOnly = True
            Me.TextBoxPanel_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPanel_Description.Size = New System.Drawing.Size(595, 20)
            Me.TextBoxPanel_Description.TabIndex = 11
            Me.TextBoxPanel_Description.TabOnEnter = True
            Me.TextBoxPanel_Description.TabStop = False
            '
            'TextBoxPanel_TransactionDate
            '
            '
            '
            '
            Me.TextBoxPanel_TransactionDate.Border.Class = "TextBoxBorder"
            Me.TextBoxPanel_TransactionDate.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPanel_TransactionDate.CheckSpellingOnValidate = False
            Me.TextBoxPanel_TransactionDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPanel_TransactionDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPanel_TransactionDate.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPanel_TransactionDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPanel_TransactionDate.FocusHighlightEnabled = True
            Me.TextBoxPanel_TransactionDate.Location = New System.Drawing.Point(368, 31)
            Me.TextBoxPanel_TransactionDate.MaxFileSize = CType(0, Long)
            Me.TextBoxPanel_TransactionDate.Name = "TextBoxPanel_TransactionDate"
            Me.TextBoxPanel_TransactionDate.ReadOnly = True
            Me.TextBoxPanel_TransactionDate.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPanel_TransactionDate.Size = New System.Drawing.Size(110, 20)
            Me.TextBoxPanel_TransactionDate.TabIndex = 9
            Me.TextBoxPanel_TransactionDate.TabOnEnter = True
            Me.TextBoxPanel_TransactionDate.TabStop = False
            '
            'TextBoxPanel_CreatedBy
            '
            '
            '
            '
            Me.TextBoxPanel_CreatedBy.Border.Class = "TextBoxBorder"
            Me.TextBoxPanel_CreatedBy.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPanel_CreatedBy.CheckSpellingOnValidate = False
            Me.TextBoxPanel_CreatedBy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPanel_CreatedBy.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPanel_CreatedBy.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPanel_CreatedBy.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPanel_CreatedBy.FocusHighlightEnabled = True
            Me.TextBoxPanel_CreatedBy.Location = New System.Drawing.Point(92, 57)
            Me.TextBoxPanel_CreatedBy.MaxFileSize = CType(0, Long)
            Me.TextBoxPanel_CreatedBy.Name = "TextBoxPanel_CreatedBy"
            Me.TextBoxPanel_CreatedBy.ReadOnly = True
            Me.TextBoxPanel_CreatedBy.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPanel_CreatedBy.Size = New System.Drawing.Size(163, 20)
            Me.TextBoxPanel_CreatedBy.TabIndex = 5
            Me.TextBoxPanel_CreatedBy.TabOnEnter = True
            Me.TextBoxPanel_CreatedBy.TabStop = False
            '
            'TextBoxPanel_Source
            '
            '
            '
            '
            Me.TextBoxPanel_Source.Border.Class = "TextBoxBorder"
            Me.TextBoxPanel_Source.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPanel_Source.CheckSpellingOnValidate = False
            Me.TextBoxPanel_Source.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPanel_Source.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPanel_Source.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPanel_Source.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPanel_Source.FocusHighlightEnabled = True
            Me.TextBoxPanel_Source.Location = New System.Drawing.Point(92, 31)
            Me.TextBoxPanel_Source.MaxFileSize = CType(0, Long)
            Me.TextBoxPanel_Source.Name = "TextBoxPanel_Source"
            Me.TextBoxPanel_Source.ReadOnly = True
            Me.TextBoxPanel_Source.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPanel_Source.Size = New System.Drawing.Size(163, 20)
            Me.TextBoxPanel_Source.TabIndex = 3
            Me.TextBoxPanel_Source.TabOnEnter = True
            Me.TextBoxPanel_Source.TabStop = False
            '
            'TextBoxPanel_Transaction
            '
            '
            '
            '
            Me.TextBoxPanel_Transaction.Border.Class = "TextBoxBorder"
            Me.TextBoxPanel_Transaction.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPanel_Transaction.CheckSpellingOnValidate = False
            Me.TextBoxPanel_Transaction.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPanel_Transaction.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPanel_Transaction.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPanel_Transaction.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPanel_Transaction.FocusHighlightEnabled = True
            Me.TextBoxPanel_Transaction.Location = New System.Drawing.Point(92, 5)
            Me.TextBoxPanel_Transaction.MaxFileSize = CType(0, Long)
            Me.TextBoxPanel_Transaction.Name = "TextBoxPanel_Transaction"
            Me.TextBoxPanel_Transaction.ReadOnly = True
            Me.TextBoxPanel_Transaction.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPanel_Transaction.Size = New System.Drawing.Size(163, 20)
            Me.TextBoxPanel_Transaction.TabIndex = 1
            Me.TextBoxPanel_Transaction.TabOnEnter = True
            Me.TextBoxPanel_Transaction.TabStop = False
            '
            'LabelPanel_Description
            '
            Me.LabelPanel_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_Description.Location = New System.Drawing.Point(261, 57)
            Me.LabelPanel_Description.Name = "LabelPanel_Description"
            Me.LabelPanel_Description.Size = New System.Drawing.Size(101, 20)
            Me.LabelPanel_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_Description.TabIndex = 10
            Me.LabelPanel_Description.Text = "Description:"
            '
            'CheckBoxPanel_Posted
            '
            Me.CheckBoxPanel_Posted.AutoCheck = False
            '
            '
            '
            Me.CheckBoxPanel_Posted.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxPanel_Posted.CheckValue = 0
            Me.CheckBoxPanel_Posted.CheckValueChecked = 1
            Me.CheckBoxPanel_Posted.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxPanel_Posted.CheckValueUnchecked = 0
            Me.CheckBoxPanel_Posted.ChildControls = Nothing
            Me.CheckBoxPanel_Posted.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxPanel_Posted.Location = New System.Drawing.Point(799, 31)
            Me.CheckBoxPanel_Posted.Name = "CheckBoxPanel_Posted"
            Me.CheckBoxPanel_Posted.OldestSibling = Nothing
            Me.CheckBoxPanel_Posted.SecurityEnabled = True
            Me.CheckBoxPanel_Posted.SiblingControls = Nothing
            Me.CheckBoxPanel_Posted.Size = New System.Drawing.Size(60, 20)
            Me.CheckBoxPanel_Posted.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxPanel_Posted.TabIndex = 14
            Me.CheckBoxPanel_Posted.Text = "Posted"
            '
            'LabelPanel_TransactionDate
            '
            Me.LabelPanel_TransactionDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_TransactionDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_TransactionDate.Location = New System.Drawing.Point(261, 31)
            Me.LabelPanel_TransactionDate.Name = "LabelPanel_TransactionDate"
            Me.LabelPanel_TransactionDate.Size = New System.Drawing.Size(91, 20)
            Me.LabelPanel_TransactionDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_TransactionDate.TabIndex = 8
            Me.LabelPanel_TransactionDate.Text = "Transaction Date:"
            '
            'LabelPanel_CreatedBy
            '
            Me.LabelPanel_CreatedBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_CreatedBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_CreatedBy.Location = New System.Drawing.Point(5, 57)
            Me.LabelPanel_CreatedBy.Name = "LabelPanel_CreatedBy"
            Me.LabelPanel_CreatedBy.Size = New System.Drawing.Size(81, 20)
            Me.LabelPanel_CreatedBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_CreatedBy.TabIndex = 4
            Me.LabelPanel_CreatedBy.Text = "Created By:"
            '
            'LabelPanel_Source
            '
            Me.LabelPanel_Source.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_Source.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_Source.Location = New System.Drawing.Point(5, 31)
            Me.LabelPanel_Source.Name = "LabelPanel_Source"
            Me.LabelPanel_Source.Size = New System.Drawing.Size(81, 20)
            Me.LabelPanel_Source.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_Source.TabIndex = 2
            Me.LabelPanel_Source.Text = "Source:"
            '
            'LabelPanel_PostPeriod
            '
            Me.LabelPanel_PostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_PostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_PostPeriod.Location = New System.Drawing.Point(261, 5)
            Me.LabelPanel_PostPeriod.Name = "LabelPanel_PostPeriod"
            Me.LabelPanel_PostPeriod.Size = New System.Drawing.Size(101, 20)
            Me.LabelPanel_PostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_PostPeriod.TabIndex = 6
            Me.LabelPanel_PostPeriod.Text = "Post Period:"
            '
            'LabelPanel_Transaction
            '
            Me.LabelPanel_Transaction.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_Transaction.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_Transaction.Location = New System.Drawing.Point(5, 5)
            Me.LabelPanel_Transaction.Name = "LabelPanel_Transaction"
            Me.LabelPanel_Transaction.Size = New System.Drawing.Size(81, 20)
            Me.LabelPanel_Transaction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_Transaction.TabIndex = 0
            Me.LabelPanel_Transaction.Text = "Transaction:"
            '
            'DataGridViewPanel_TransactionDetails
            '
            Me.DataGridViewPanel_TransactionDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewPanel_TransactionDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewPanel_TransactionDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewPanel_TransactionDetails.AutoFilterLookupColumns = False
            Me.DataGridViewPanel_TransactionDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewPanel_TransactionDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewPanel_TransactionDetails.DataSource = Nothing
            Me.DataGridViewPanel_TransactionDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewPanel_TransactionDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewPanel_TransactionDetails.ItemDescription = "Transaction Detail"
            Me.DataGridViewPanel_TransactionDetails.Location = New System.Drawing.Point(5, 90)
            Me.DataGridViewPanel_TransactionDetails.MultiSelect = False
            Me.DataGridViewPanel_TransactionDetails.Name = "DataGridViewPanel_TransactionDetails"
            Me.DataGridViewPanel_TransactionDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewPanel_TransactionDetails.RunStandardValidation = True
            Me.DataGridViewPanel_TransactionDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewPanel_TransactionDetails.Size = New System.Drawing.Size(958, 531)
            Me.DataGridViewPanel_TransactionDetails.TabIndex = 15
            Me.DataGridViewPanel_TransactionDetails.UseEmbeddedNavigator = False
            Me.DataGridViewPanel_TransactionDetails.ViewCaptionHeight = -1
            '
            'ButtonForm_Close
            '
            Me.ButtonForm_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Close.Location = New System.Drawing.Point(905, 644)
            Me.ButtonForm_Close.Name = "ButtonForm_Close"
            Me.ButtonForm_Close.SecurityEnabled = True
            Me.ButtonForm_Close.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Close.TabIndex = 0
            Me.ButtonForm_Close.Text = "Close"
            '
            'GeneralLedgerTransactionDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(992, 676)
            Me.Controls.Add(Me.ButtonForm_Close)
            Me.Controls.Add(Me.PanelForm_MainSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "GeneralLedgerTransactionDialog"
            Me.Text = "Query Transaction Detail"
            CType(Me.PanelForm_MainSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_MainSection.ResumeLayout(False)
            CType(Me.NumericInputPanel_ControlAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelForm_MainSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewPanel_TransactionDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelPanel_TransactionDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPanel_CreatedBy As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPanel_Source As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPanel_PostPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPanel_Transaction As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxPanel_Posted As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelPanel_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPanel_ControlAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxPanel_PostPeriod As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxPanel_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxPanel_TransactionDate As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxPanel_CreatedBy As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxPanel_Source As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxPanel_Transaction As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ButtonForm_Close As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents NumericInputPanel_ControlAmount As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
    End Class

End Namespace

