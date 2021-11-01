Namespace Security.Presentation

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Class LicenseKeyEditDialog
		Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

		'Form overrides dispose to clean up the component list.
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LicenseKeyEditDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Create = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.CheckBoxForm_CreateFileAfterKeyCreated = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_DaysUntilFileExpires = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_DaysUntilKeyExpires = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputForm_DaysUntilFileExpires = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputForm_DaysUntilKeyExpires = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputForm_WVOnlyUsersQuantity = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputForm_PowerUsersQuantity = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelForm_WVOnlyUsersQuantity = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_PowerUsersQuantity = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputForm_ClientPortalUsersQuantity = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelForm_ClientPortalUsersQuantity = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_QuantityMessage = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_AgencyName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_AgencyName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Comment = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Comment = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_MediaToolsUsersQuantity = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputForm_MediaToolsUsersQuantity = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelForm_APIUsersQuantity = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputForm_APIUsersQuantity = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelForm_EnableProofingTool = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_EnableProofingTool = New System.Windows.Forms.CheckBox()
            CType(Me.NumericInputForm_DaysUntilFileExpires.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_DaysUntilKeyExpires.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_WVOnlyUsersQuantity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_PowerUsersQuantity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_ClientPortalUsersQuantity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_MediaToolsUsersQuantity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_APIUsersQuantity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(385, 413)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 21
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Create
            '
            Me.ButtonForm_Create.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Create.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Create.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Create.Location = New System.Drawing.Point(304, 413)
            Me.ButtonForm_Create.Name = "ButtonForm_Create"
            Me.ButtonForm_Create.SecurityEnabled = True
            Me.ButtonForm_Create.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Create.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Create.TabIndex = 20
            Me.ButtonForm_Create.Text = "Create"
            '
            'CheckBoxForm_CreateFileAfterKeyCreated
            '
            Me.CheckBoxForm_CreateFileAfterKeyCreated.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_CreateFileAfterKeyCreated.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_CreateFileAfterKeyCreated.CheckValue = 0
            Me.CheckBoxForm_CreateFileAfterKeyCreated.CheckValueChecked = 1
            Me.CheckBoxForm_CreateFileAfterKeyCreated.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_CreateFileAfterKeyCreated.CheckValueUnchecked = 0
            Me.CheckBoxForm_CreateFileAfterKeyCreated.ChildControls = CType(resources.GetObject("CheckBoxForm_CreateFileAfterKeyCreated.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_CreateFileAfterKeyCreated.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_CreateFileAfterKeyCreated.Location = New System.Drawing.Point(12, 413)
            Me.CheckBoxForm_CreateFileAfterKeyCreated.Name = "CheckBoxForm_CreateFileAfterKeyCreated"
            Me.CheckBoxForm_CreateFileAfterKeyCreated.OldestSibling = Nothing
            Me.CheckBoxForm_CreateFileAfterKeyCreated.SecurityEnabled = True
            Me.CheckBoxForm_CreateFileAfterKeyCreated.SiblingControls = CType(resources.GetObject("CheckBoxForm_CreateFileAfterKeyCreated.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_CreateFileAfterKeyCreated.Size = New System.Drawing.Size(286, 20)
            Me.CheckBoxForm_CreateFileAfterKeyCreated.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_CreateFileAfterKeyCreated.TabIndex = 19
            Me.CheckBoxForm_CreateFileAfterKeyCreated.TabOnEnter = True
            Me.CheckBoxForm_CreateFileAfterKeyCreated.Text = "Create File After Key Created"
            '
            'LabelForm_DaysUntilFileExpires
            '
            Me.LabelForm_DaysUntilFileExpires.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_DaysUntilFileExpires.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DaysUntilFileExpires.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DaysUntilFileExpires.Location = New System.Drawing.Point(259, 38)
            Me.LabelForm_DaysUntilFileExpires.Name = "LabelForm_DaysUntilFileExpires"
            Me.LabelForm_DaysUntilFileExpires.Size = New System.Drawing.Size(120, 20)
            Me.LabelForm_DaysUntilFileExpires.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DaysUntilFileExpires.TabIndex = 12
            Me.LabelForm_DaysUntilFileExpires.Text = "Days Until File Expires:"
            '
            'LabelForm_DaysUntilKeyExpires
            '
            Me.LabelForm_DaysUntilKeyExpires.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_DaysUntilKeyExpires.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DaysUntilKeyExpires.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DaysUntilKeyExpires.Location = New System.Drawing.Point(259, 64)
            Me.LabelForm_DaysUntilKeyExpires.Name = "LabelForm_DaysUntilKeyExpires"
            Me.LabelForm_DaysUntilKeyExpires.Size = New System.Drawing.Size(120, 20)
            Me.LabelForm_DaysUntilKeyExpires.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DaysUntilKeyExpires.TabIndex = 14
            Me.LabelForm_DaysUntilKeyExpires.Text = "Days Until Key Expires:"
            '
            'NumericInputForm_DaysUntilFileExpires
            '
            Me.NumericInputForm_DaysUntilFileExpires.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_DaysUntilFileExpires.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputForm_DaysUntilFileExpires.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputForm_DaysUntilFileExpires.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputForm_DaysUntilFileExpires.EnterMoveNextControl = True
            Me.NumericInputForm_DaysUntilFileExpires.Location = New System.Drawing.Point(385, 38)
            Me.NumericInputForm_DaysUntilFileExpires.Name = "NumericInputForm_DaysUntilFileExpires"
            Me.NumericInputForm_DaysUntilFileExpires.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputForm_DaysUntilFileExpires.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_DaysUntilFileExpires.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputForm_DaysUntilFileExpires.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_DaysUntilFileExpires.Properties.IsFloatValue = False
            Me.NumericInputForm_DaysUntilFileExpires.Properties.Mask.EditMask = "f0"
            Me.NumericInputForm_DaysUntilFileExpires.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_DaysUntilFileExpires.Properties.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
            Me.NumericInputForm_DaysUntilFileExpires.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputForm_DaysUntilFileExpires.SecurityEnabled = True
            Me.NumericInputForm_DaysUntilFileExpires.Size = New System.Drawing.Size(75, 20)
            Me.NumericInputForm_DaysUntilFileExpires.TabIndex = 13
            '
            'NumericInputForm_DaysUntilKeyExpires
            '
            Me.NumericInputForm_DaysUntilKeyExpires.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_DaysUntilKeyExpires.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputForm_DaysUntilKeyExpires.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputForm_DaysUntilKeyExpires.EnterMoveNextControl = True
            Me.NumericInputForm_DaysUntilKeyExpires.Location = New System.Drawing.Point(385, 64)
            Me.NumericInputForm_DaysUntilKeyExpires.Name = "NumericInputForm_DaysUntilKeyExpires"
            Me.NumericInputForm_DaysUntilKeyExpires.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputForm_DaysUntilKeyExpires.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_DaysUntilKeyExpires.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputForm_DaysUntilKeyExpires.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_DaysUntilKeyExpires.Properties.IsFloatValue = False
            Me.NumericInputForm_DaysUntilKeyExpires.Properties.Mask.EditMask = "f0"
            Me.NumericInputForm_DaysUntilKeyExpires.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_DaysUntilKeyExpires.Properties.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
            Me.NumericInputForm_DaysUntilKeyExpires.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputForm_DaysUntilKeyExpires.SecurityEnabled = True
            Me.NumericInputForm_DaysUntilKeyExpires.Size = New System.Drawing.Size(75, 20)
            Me.NumericInputForm_DaysUntilKeyExpires.TabIndex = 15
            '
            'NumericInputForm_WVOnlyUsersQuantity
            '
            Me.NumericInputForm_WVOnlyUsersQuantity.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_WVOnlyUsersQuantity.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputForm_WVOnlyUsersQuantity.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_WVOnlyUsersQuantity.EnterMoveNextControl = True
            Me.NumericInputForm_WVOnlyUsersQuantity.Location = New System.Drawing.Point(163, 64)
            Me.NumericInputForm_WVOnlyUsersQuantity.Name = "NumericInputForm_WVOnlyUsersQuantity"
            Me.NumericInputForm_WVOnlyUsersQuantity.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputForm_WVOnlyUsersQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_WVOnlyUsersQuantity.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputForm_WVOnlyUsersQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_WVOnlyUsersQuantity.Properties.IsFloatValue = False
            Me.NumericInputForm_WVOnlyUsersQuantity.Properties.Mask.EditMask = "f0"
            Me.NumericInputForm_WVOnlyUsersQuantity.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_WVOnlyUsersQuantity.Properties.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
            Me.NumericInputForm_WVOnlyUsersQuantity.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputForm_WVOnlyUsersQuantity.SecurityEnabled = True
            Me.NumericInputForm_WVOnlyUsersQuantity.Size = New System.Drawing.Size(90, 20)
            Me.NumericInputForm_WVOnlyUsersQuantity.TabIndex = 5
            '
            'NumericInputForm_PowerUsersQuantity
            '
            Me.NumericInputForm_PowerUsersQuantity.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_PowerUsersQuantity.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputForm_PowerUsersQuantity.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_PowerUsersQuantity.EnterMoveNextControl = True
            Me.NumericInputForm_PowerUsersQuantity.Location = New System.Drawing.Point(163, 38)
            Me.NumericInputForm_PowerUsersQuantity.Name = "NumericInputForm_PowerUsersQuantity"
            Me.NumericInputForm_PowerUsersQuantity.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputForm_PowerUsersQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_PowerUsersQuantity.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputForm_PowerUsersQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_PowerUsersQuantity.Properties.IsFloatValue = False
            Me.NumericInputForm_PowerUsersQuantity.Properties.Mask.EditMask = "f0"
            Me.NumericInputForm_PowerUsersQuantity.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_PowerUsersQuantity.Properties.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
            Me.NumericInputForm_PowerUsersQuantity.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputForm_PowerUsersQuantity.SecurityEnabled = True
            Me.NumericInputForm_PowerUsersQuantity.Size = New System.Drawing.Size(90, 20)
            Me.NumericInputForm_PowerUsersQuantity.TabIndex = 3
            '
            'LabelForm_WVOnlyUsersQuantity
            '
            Me.LabelForm_WVOnlyUsersQuantity.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_WVOnlyUsersQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_WVOnlyUsersQuantity.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_WVOnlyUsersQuantity.Name = "LabelForm_WVOnlyUsersQuantity"
            Me.LabelForm_WVOnlyUsersQuantity.Size = New System.Drawing.Size(145, 20)
            Me.LabelForm_WVOnlyUsersQuantity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_WVOnlyUsersQuantity.TabIndex = 4
            Me.LabelForm_WVOnlyUsersQuantity.Text = "*WV Only Users Quantity:"
            '
            'LabelForm_PowerUsersQuantity
            '
            Me.LabelForm_PowerUsersQuantity.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PowerUsersQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PowerUsersQuantity.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_PowerUsersQuantity.Name = "LabelForm_PowerUsersQuantity"
            Me.LabelForm_PowerUsersQuantity.Size = New System.Drawing.Size(145, 20)
            Me.LabelForm_PowerUsersQuantity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PowerUsersQuantity.TabIndex = 2
            Me.LabelForm_PowerUsersQuantity.Text = "*Power Users Quantity:"
            '
            'NumericInputForm_ClientPortalUsersQuantity
            '
            Me.NumericInputForm_ClientPortalUsersQuantity.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_ClientPortalUsersQuantity.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputForm_ClientPortalUsersQuantity.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_ClientPortalUsersQuantity.EnterMoveNextControl = True
            Me.NumericInputForm_ClientPortalUsersQuantity.Location = New System.Drawing.Point(163, 90)
            Me.NumericInputForm_ClientPortalUsersQuantity.Name = "NumericInputForm_ClientPortalUsersQuantity"
            Me.NumericInputForm_ClientPortalUsersQuantity.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputForm_ClientPortalUsersQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_ClientPortalUsersQuantity.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputForm_ClientPortalUsersQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_ClientPortalUsersQuantity.Properties.IsFloatValue = False
            Me.NumericInputForm_ClientPortalUsersQuantity.Properties.Mask.EditMask = "f0"
            Me.NumericInputForm_ClientPortalUsersQuantity.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_ClientPortalUsersQuantity.Properties.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
            Me.NumericInputForm_ClientPortalUsersQuantity.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputForm_ClientPortalUsersQuantity.SecurityEnabled = True
            Me.NumericInputForm_ClientPortalUsersQuantity.Size = New System.Drawing.Size(90, 20)
            Me.NumericInputForm_ClientPortalUsersQuantity.TabIndex = 7
            '
            'LabelForm_ClientPortalUsersQuantity
            '
            Me.LabelForm_ClientPortalUsersQuantity.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ClientPortalUsersQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ClientPortalUsersQuantity.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_ClientPortalUsersQuantity.Name = "LabelForm_ClientPortalUsersQuantity"
            Me.LabelForm_ClientPortalUsersQuantity.Size = New System.Drawing.Size(145, 20)
            Me.LabelForm_ClientPortalUsersQuantity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ClientPortalUsersQuantity.TabIndex = 6
            Me.LabelForm_ClientPortalUsersQuantity.Text = "*Client Portal Users Quantity:"
            '
            'LabelForm_QuantityMessage
            '
            Me.LabelForm_QuantityMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_QuantityMessage.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_QuantityMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_QuantityMessage.Location = New System.Drawing.Point(12, 194)
            Me.LabelForm_QuantityMessage.Name = "LabelForm_QuantityMessage"
            Me.LabelForm_QuantityMessage.Size = New System.Drawing.Size(448, 20)
            Me.LabelForm_QuantityMessage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_QuantityMessage.TabIndex = 16
            Me.LabelForm_QuantityMessage.Text = "*Leaving the check box unchecked denotes unlimited"
            '
            'LabelForm_AgencyName
            '
            Me.LabelForm_AgencyName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_AgencyName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AgencyName.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_AgencyName.Name = "LabelForm_AgencyName"
            Me.LabelForm_AgencyName.Size = New System.Drawing.Size(145, 20)
            Me.LabelForm_AgencyName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AgencyName.TabIndex = 0
            Me.LabelForm_AgencyName.Text = "Agency Name:"
            '
            'TextBoxForm_AgencyName
            '
            Me.TextBoxForm_AgencyName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_AgencyName.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_AgencyName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_AgencyName.CheckSpellingOnValidate = False
            Me.TextBoxForm_AgencyName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_AgencyName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_AgencyName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_AgencyName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_AgencyName.FocusHighlightEnabled = True
            Me.TextBoxForm_AgencyName.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_AgencyName.Location = New System.Drawing.Point(163, 12)
            Me.TextBoxForm_AgencyName.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_AgencyName.MaxLength = 40
            Me.TextBoxForm_AgencyName.Name = "TextBoxForm_AgencyName"
            Me.TextBoxForm_AgencyName.SecurityEnabled = True
            Me.TextBoxForm_AgencyName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_AgencyName.Size = New System.Drawing.Size(297, 20)
            Me.TextBoxForm_AgencyName.StartingFolderName = Nothing
            Me.TextBoxForm_AgencyName.TabIndex = 1
            Me.TextBoxForm_AgencyName.TabOnEnter = True
            '
            'LabelForm_Comment
            '
            Me.LabelForm_Comment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Comment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Comment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Comment.Location = New System.Drawing.Point(12, 220)
            Me.LabelForm_Comment.Name = "LabelForm_Comment"
            Me.LabelForm_Comment.Size = New System.Drawing.Size(448, 20)
            Me.LabelForm_Comment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Comment.TabIndex = 17
            Me.LabelForm_Comment.Text = "Comment:"
            '
            'TextBoxForm_Comment
            '
            Me.TextBoxForm_Comment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_Comment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_Comment.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Comment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Comment.CheckSpellingOnValidate = False
            Me.TextBoxForm_Comment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Comment.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Comment.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Comment.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Comment.FocusHighlightEnabled = True
            Me.TextBoxForm_Comment.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Comment.Location = New System.Drawing.Point(12, 246)
            Me.TextBoxForm_Comment.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Comment.Multiline = True
            Me.TextBoxForm_Comment.Name = "TextBoxForm_Comment"
            Me.TextBoxForm_Comment.SecurityEnabled = True
            Me.TextBoxForm_Comment.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Comment.Size = New System.Drawing.Size(448, 161)
            Me.TextBoxForm_Comment.StartingFolderName = Nothing
            Me.TextBoxForm_Comment.TabIndex = 18
            Me.TextBoxForm_Comment.TabOnEnter = True
            '
            'LabelForm_MediaToolsUsersQuantity
            '
            Me.LabelForm_MediaToolsUsersQuantity.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_MediaToolsUsersQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_MediaToolsUsersQuantity.Location = New System.Drawing.Point(12, 116)
            Me.LabelForm_MediaToolsUsersQuantity.Name = "LabelForm_MediaToolsUsersQuantity"
            Me.LabelForm_MediaToolsUsersQuantity.Size = New System.Drawing.Size(145, 20)
            Me.LabelForm_MediaToolsUsersQuantity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_MediaToolsUsersQuantity.TabIndex = 8
            Me.LabelForm_MediaToolsUsersQuantity.Text = "*Media Tools Users Quantity:"
            '
            'NumericInputForm_MediaToolsUsersQuantity
            '
            Me.NumericInputForm_MediaToolsUsersQuantity.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_MediaToolsUsersQuantity.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputForm_MediaToolsUsersQuantity.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_MediaToolsUsersQuantity.EnterMoveNextControl = True
            Me.NumericInputForm_MediaToolsUsersQuantity.Location = New System.Drawing.Point(163, 116)
            Me.NumericInputForm_MediaToolsUsersQuantity.Name = "NumericInputForm_MediaToolsUsersQuantity"
            Me.NumericInputForm_MediaToolsUsersQuantity.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputForm_MediaToolsUsersQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_MediaToolsUsersQuantity.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputForm_MediaToolsUsersQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_MediaToolsUsersQuantity.Properties.IsFloatValue = False
            Me.NumericInputForm_MediaToolsUsersQuantity.Properties.Mask.EditMask = "f0"
            Me.NumericInputForm_MediaToolsUsersQuantity.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_MediaToolsUsersQuantity.Properties.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
            Me.NumericInputForm_MediaToolsUsersQuantity.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputForm_MediaToolsUsersQuantity.SecurityEnabled = True
            Me.NumericInputForm_MediaToolsUsersQuantity.Size = New System.Drawing.Size(90, 20)
            Me.NumericInputForm_MediaToolsUsersQuantity.TabIndex = 9
            '
            'LabelForm_APIUsersQuantity
            '
            Me.LabelForm_APIUsersQuantity.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_APIUsersQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_APIUsersQuantity.Location = New System.Drawing.Point(12, 142)
            Me.LabelForm_APIUsersQuantity.Name = "LabelForm_APIUsersQuantity"
            Me.LabelForm_APIUsersQuantity.Size = New System.Drawing.Size(145, 20)
            Me.LabelForm_APIUsersQuantity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_APIUsersQuantity.TabIndex = 10
            Me.LabelForm_APIUsersQuantity.Text = "*API Users Quantity:"
            '
            'NumericInputForm_APIUsersQuantity
            '
            Me.NumericInputForm_APIUsersQuantity.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_APIUsersQuantity.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputForm_APIUsersQuantity.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_APIUsersQuantity.EnterMoveNextControl = True
            Me.NumericInputForm_APIUsersQuantity.Location = New System.Drawing.Point(163, 142)
            Me.NumericInputForm_APIUsersQuantity.Name = "NumericInputForm_APIUsersQuantity"
            Me.NumericInputForm_APIUsersQuantity.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputForm_APIUsersQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_APIUsersQuantity.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputForm_APIUsersQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_APIUsersQuantity.Properties.IsFloatValue = False
            Me.NumericInputForm_APIUsersQuantity.Properties.Mask.EditMask = "f0"
            Me.NumericInputForm_APIUsersQuantity.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_APIUsersQuantity.Properties.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
            Me.NumericInputForm_APIUsersQuantity.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputForm_APIUsersQuantity.SecurityEnabled = True
            Me.NumericInputForm_APIUsersQuantity.Size = New System.Drawing.Size(90, 20)
            Me.NumericInputForm_APIUsersQuantity.TabIndex = 11
            '
            'LabelForm_EnableProofingTool
            '
            Me.LabelForm_EnableProofingTool.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EnableProofingTool.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EnableProofingTool.Location = New System.Drawing.Point(12, 168)
            Me.LabelForm_EnableProofingTool.Name = "LabelForm_EnableProofingTool"
            Me.LabelForm_EnableProofingTool.Size = New System.Drawing.Size(145, 20)
            Me.LabelForm_EnableProofingTool.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EnableProofingTool.TabIndex = 22
            Me.LabelForm_EnableProofingTool.Text = "Enable Proofing Tool:"
            '
            'CheckBoxForm_EnableProofingTool
            '
            Me.CheckBoxForm_EnableProofingTool.AutoSize = True
            Me.CheckBoxForm_EnableProofingTool.Location = New System.Drawing.Point(238, 171)
            Me.CheckBoxForm_EnableProofingTool.Name = "CheckBoxForm_EnableProofingTool"
            Me.CheckBoxForm_EnableProofingTool.Size = New System.Drawing.Size(15, 14)
            Me.CheckBoxForm_EnableProofingTool.TabIndex = 23
            Me.CheckBoxForm_EnableProofingTool.UseVisualStyleBackColor = True
            '
            'LicenseKeyEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(472, 445)
            Me.Controls.Add(Me.CheckBoxForm_EnableProofingTool)
            Me.Controls.Add(Me.LabelForm_EnableProofingTool)
            Me.Controls.Add(Me.LabelForm_APIUsersQuantity)
            Me.Controls.Add(Me.NumericInputForm_APIUsersQuantity)
            Me.Controls.Add(Me.LabelForm_MediaToolsUsersQuantity)
            Me.Controls.Add(Me.NumericInputForm_MediaToolsUsersQuantity)
            Me.Controls.Add(Me.TextBoxForm_Comment)
            Me.Controls.Add(Me.LabelForm_Comment)
            Me.Controls.Add(Me.TextBoxForm_AgencyName)
            Me.Controls.Add(Me.LabelForm_AgencyName)
            Me.Controls.Add(Me.LabelForm_PowerUsersQuantity)
            Me.Controls.Add(Me.LabelForm_QuantityMessage)
            Me.Controls.Add(Me.LabelForm_ClientPortalUsersQuantity)
            Me.Controls.Add(Me.NumericInputForm_ClientPortalUsersQuantity)
            Me.Controls.Add(Me.LabelForm_WVOnlyUsersQuantity)
            Me.Controls.Add(Me.NumericInputForm_WVOnlyUsersQuantity)
            Me.Controls.Add(Me.NumericInputForm_PowerUsersQuantity)
            Me.Controls.Add(Me.ButtonForm_Create)
            Me.Controls.Add(Me.NumericInputForm_DaysUntilKeyExpires)
            Me.Controls.Add(Me.NumericInputForm_DaysUntilFileExpires)
            Me.Controls.Add(Me.LabelForm_DaysUntilKeyExpires)
            Me.Controls.Add(Me.LabelForm_DaysUntilFileExpires)
            Me.Controls.Add(Me.CheckBoxForm_CreateFileAfterKeyCreated)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "LicenseKeyEditDialog"
            Me.Text = "Create License Key"
            CType(Me.NumericInputForm_DaysUntilFileExpires.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_DaysUntilKeyExpires.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_WVOnlyUsersQuantity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_PowerUsersQuantity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_ClientPortalUsersQuantity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_MediaToolsUsersQuantity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_APIUsersQuantity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Private WithEvents ButtonForm_Cancel As WinForm.Presentation.Controls.Button
		Private WithEvents ButtonForm_Create As WinForm.Presentation.Controls.Button
		Private WithEvents CheckBoxForm_CreateFileAfterKeyCreated As WinForm.Presentation.Controls.CheckBox
		Private WithEvents LabelForm_DaysUntilFileExpires As WinForm.Presentation.Controls.Label
		Private WithEvents LabelForm_DaysUntilKeyExpires As WinForm.Presentation.Controls.Label
		Private WithEvents LabelForm_WVOnlyUsersQuantity As WinForm.Presentation.Controls.Label
		Private WithEvents NumericInputForm_DaysUntilFileExpires As WinForm.Presentation.Controls.NumericInput
		Private WithEvents NumericInputForm_DaysUntilKeyExpires As WinForm.Presentation.Controls.NumericInput
		Private WithEvents NumericInputForm_WVOnlyUsersQuantity As WinForm.Presentation.Controls.NumericInput
		Private WithEvents NumericInputForm_PowerUsersQuantity As WinForm.Presentation.Controls.NumericInput
		Private WithEvents LabelForm_PowerUsersQuantity As WinForm.Presentation.Controls.Label
		Private WithEvents NumericInputForm_ClientPortalUsersQuantity As WinForm.Presentation.Controls.NumericInput
		Private WithEvents LabelForm_ClientPortalUsersQuantity As WinForm.Presentation.Controls.Label
		Private WithEvents LabelForm_QuantityMessage As WinForm.Presentation.Controls.Label
		Private WithEvents LabelForm_AgencyName As WinForm.Presentation.Controls.Label
		Private WithEvents TextBoxForm_AgencyName As WinForm.Presentation.Controls.TextBox
		Private WithEvents LabelForm_Comment As WinForm.Presentation.Controls.Label
		Private WithEvents TextBoxForm_Comment As WinForm.Presentation.Controls.TextBox
		Private WithEvents LabelForm_MediaToolsUsersQuantity As WinForm.Presentation.Controls.Label
		Private WithEvents NumericInputForm_MediaToolsUsersQuantity As WinForm.Presentation.Controls.NumericInput
		Private WithEvents LabelForm_APIUsersQuantity As WinForm.Presentation.Controls.Label
		Private WithEvents NumericInputForm_APIUsersQuantity As WinForm.Presentation.Controls.NumericInput
        Private WithEvents LabelForm_EnableProofingTool As WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_EnableProofingTool As Windows.Forms.CheckBox
    End Class

End Namespace
