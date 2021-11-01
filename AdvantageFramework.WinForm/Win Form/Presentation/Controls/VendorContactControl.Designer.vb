Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class VendorContactControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VendorContactControl))
            Me.LabelControl_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonControl_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonItemRefresh_Vendor = New DevComponents.DotNetBar.ButtonItem()
            Me.CheckBoxControl_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxControl_Phone = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxPhone_FaxExt = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPhone_VoiceExt = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelPhone_FaxExt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPhone_VoiceExt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxPhone_Cell = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPhone_Fax = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPhone_Voice = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelPhone_Cell = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPhone_Fax = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPhone_Voice = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxControl_EmailAddress = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelControl_EmailAddress = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.AddressControlControl_Address = New AdvantageFramework.WinForm.Presentation.Controls.AddressControl()
            Me.TextBoxControl_LastName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxControl_MiddleInitial = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelControl_MiddleInitial = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxControl_FirstName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxControl_Title = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxControl_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelControl_Title = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_LastName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_FirstName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelControl_Control = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.SearchableComboBoxControl_ContactType = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxControl_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView4 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelControl_ContactType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.GroupBoxControl_Phone, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxControl_Phone.SuspendLayout()
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_Control.SuspendLayout()
            CType(Me.SearchableComboBoxControl_ContactType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxControl_Vendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'LabelControl_Vendor
            '
            Me.LabelControl_Vendor.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Vendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Vendor.Location = New System.Drawing.Point(0, 0)
            Me.LabelControl_Vendor.Name = "LabelControl_Vendor"
            Me.LabelControl_Vendor.Size = New System.Drawing.Size(82, 20)
            Me.LabelControl_Vendor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Vendor.TabIndex = 0
            Me.LabelControl_Vendor.Text = "Vendor:"
            '
            'ButtonControl_Refresh
            '
            Me.ButtonControl_Refresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonControl_Refresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonControl_Refresh.AutoExpandOnClick = True
            Me.ButtonControl_Refresh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonControl_Refresh.Location = New System.Drawing.Point(279, 183)
            Me.ButtonControl_Refresh.Name = "ButtonControl_Refresh"
            Me.ButtonControl_Refresh.SecurityEnabled = True
            Me.ButtonControl_Refresh.Size = New System.Drawing.Size(75, 20)
            Me.ButtonControl_Refresh.SplitButton = True
            Me.ButtonControl_Refresh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonControl_Refresh.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemRefresh_Vendor})
            Me.ButtonControl_Refresh.TabIndex = 17
            Me.ButtonControl_Refresh.Text = "Refresh"
            '
            'ButtonItemRefresh_Vendor
            '
            Me.ButtonItemRefresh_Vendor.Name = "ButtonItemRefresh_Vendor"
            Me.ButtonItemRefresh_Vendor.Text = "Vendor"
            '
            'CheckBoxControl_Inactive
            '
            Me.CheckBoxControl_Inactive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxControl_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_Inactive.CheckValue = 0
            Me.CheckBoxControl_Inactive.CheckValueChecked = 1
            Me.CheckBoxControl_Inactive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxControl_Inactive.ChildControls = CType(resources.GetObject("CheckBoxControl_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_Inactive.Location = New System.Drawing.Point(291, 24)
            Me.CheckBoxControl_Inactive.Name = "CheckBoxControl_Inactive"
            Me.CheckBoxControl_Inactive.OldestSibling = Nothing
            Me.CheckBoxControl_Inactive.SecurityEnabled = True
            Me.CheckBoxControl_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxControl_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_Inactive.Size = New System.Drawing.Size(63, 23)
            Me.CheckBoxControl_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_Inactive.TabIndex = 4
            Me.CheckBoxControl_Inactive.TabOnEnter = True
            Me.CheckBoxControl_Inactive.Text = "Inactive"
            '
            'GroupBoxControl_Phone
            '
            Me.GroupBoxControl_Phone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxControl_Phone.Controls.Add(Me.TextBoxPhone_FaxExt)
            Me.GroupBoxControl_Phone.Controls.Add(Me.TextBoxPhone_VoiceExt)
            Me.GroupBoxControl_Phone.Controls.Add(Me.LabelPhone_FaxExt)
            Me.GroupBoxControl_Phone.Controls.Add(Me.LabelPhone_VoiceExt)
            Me.GroupBoxControl_Phone.Controls.Add(Me.TextBoxPhone_Cell)
            Me.GroupBoxControl_Phone.Controls.Add(Me.TextBoxPhone_Fax)
            Me.GroupBoxControl_Phone.Controls.Add(Me.TextBoxPhone_Voice)
            Me.GroupBoxControl_Phone.Controls.Add(Me.LabelPhone_Cell)
            Me.GroupBoxControl_Phone.Controls.Add(Me.LabelPhone_Fax)
            Me.GroupBoxControl_Phone.Controls.Add(Me.LabelPhone_Voice)
            Me.GroupBoxControl_Phone.Location = New System.Drawing.Point(0, 398)
            Me.GroupBoxControl_Phone.Name = "GroupBoxControl_Phone"
            Me.GroupBoxControl_Phone.Size = New System.Drawing.Size(354, 104)
            Me.GroupBoxControl_Phone.TabIndex = 0
            Me.GroupBoxControl_Phone.Text = "Phone"
            '
            'TextBoxPhone_FaxExt
            '
            Me.TextBoxPhone_FaxExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPhone_FaxExt.Border.Class = "TextBoxBorder"
            Me.TextBoxPhone_FaxExt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPhone_FaxExt.CheckSpellingOnValidate = False
            Me.TextBoxPhone_FaxExt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPhone_FaxExt.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPhone_FaxExt.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPhone_FaxExt.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPhone_FaxExt.FocusHighlightEnabled = True
            Me.TextBoxPhone_FaxExt.Location = New System.Drawing.Point(290, 51)
            Me.TextBoxPhone_FaxExt.MaxFileSize = CType(0, Long)
            Me.TextBoxPhone_FaxExt.Name = "TextBoxPhone_FaxExt"
            Me.TextBoxPhone_FaxExt.SecurityEnabled = True
            Me.TextBoxPhone_FaxExt.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPhone_FaxExt.Size = New System.Drawing.Size(59, 21)
            Me.TextBoxPhone_FaxExt.StartingFolderName = Nothing
            Me.TextBoxPhone_FaxExt.TabIndex = 7
            Me.TextBoxPhone_FaxExt.TabOnEnter = True
            '
            'TextBoxPhone_VoiceExt
            '
            Me.TextBoxPhone_VoiceExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPhone_VoiceExt.Border.Class = "TextBoxBorder"
            Me.TextBoxPhone_VoiceExt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPhone_VoiceExt.CheckSpellingOnValidate = False
            Me.TextBoxPhone_VoiceExt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPhone_VoiceExt.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPhone_VoiceExt.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPhone_VoiceExt.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPhone_VoiceExt.FocusHighlightEnabled = True
            Me.TextBoxPhone_VoiceExt.Location = New System.Drawing.Point(290, 25)
            Me.TextBoxPhone_VoiceExt.MaxFileSize = CType(0, Long)
            Me.TextBoxPhone_VoiceExt.Name = "TextBoxPhone_VoiceExt"
            Me.TextBoxPhone_VoiceExt.SecurityEnabled = True
            Me.TextBoxPhone_VoiceExt.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPhone_VoiceExt.Size = New System.Drawing.Size(59, 21)
            Me.TextBoxPhone_VoiceExt.StartingFolderName = Nothing
            Me.TextBoxPhone_VoiceExt.TabIndex = 3
            Me.TextBoxPhone_VoiceExt.TabOnEnter = True
            '
            'LabelPhone_FaxExt
            '
            Me.LabelPhone_FaxExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelPhone_FaxExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPhone_FaxExt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPhone_FaxExt.Location = New System.Drawing.Point(257, 51)
            Me.LabelPhone_FaxExt.Name = "LabelPhone_FaxExt"
            Me.LabelPhone_FaxExt.Size = New System.Drawing.Size(27, 20)
            Me.LabelPhone_FaxExt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPhone_FaxExt.TabIndex = 6
            Me.LabelPhone_FaxExt.Text = "Ext:"
            '
            'LabelPhone_VoiceExt
            '
            Me.LabelPhone_VoiceExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelPhone_VoiceExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPhone_VoiceExt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPhone_VoiceExt.Location = New System.Drawing.Point(257, 25)
            Me.LabelPhone_VoiceExt.Name = "LabelPhone_VoiceExt"
            Me.LabelPhone_VoiceExt.Size = New System.Drawing.Size(27, 20)
            Me.LabelPhone_VoiceExt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPhone_VoiceExt.TabIndex = 2
            Me.LabelPhone_VoiceExt.Text = "Ext:"
            '
            'TextBoxPhone_Cell
            '
            Me.TextBoxPhone_Cell.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPhone_Cell.Border.Class = "TextBoxBorder"
            Me.TextBoxPhone_Cell.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPhone_Cell.CheckSpellingOnValidate = False
            Me.TextBoxPhone_Cell.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPhone_Cell.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPhone_Cell.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPhone_Cell.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPhone_Cell.FocusHighlightEnabled = True
            Me.TextBoxPhone_Cell.Location = New System.Drawing.Point(53, 77)
            Me.TextBoxPhone_Cell.MaxFileSize = CType(0, Long)
            Me.TextBoxPhone_Cell.Name = "TextBoxPhone_Cell"
            Me.TextBoxPhone_Cell.SecurityEnabled = True
            Me.TextBoxPhone_Cell.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPhone_Cell.Size = New System.Drawing.Size(198, 21)
            Me.TextBoxPhone_Cell.StartingFolderName = Nothing
            Me.TextBoxPhone_Cell.TabIndex = 9
            Me.TextBoxPhone_Cell.TabOnEnter = True
            '
            'TextBoxPhone_Fax
            '
            Me.TextBoxPhone_Fax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPhone_Fax.Border.Class = "TextBoxBorder"
            Me.TextBoxPhone_Fax.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPhone_Fax.CheckSpellingOnValidate = False
            Me.TextBoxPhone_Fax.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPhone_Fax.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPhone_Fax.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPhone_Fax.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPhone_Fax.FocusHighlightEnabled = True
            Me.TextBoxPhone_Fax.Location = New System.Drawing.Point(53, 51)
            Me.TextBoxPhone_Fax.MaxFileSize = CType(0, Long)
            Me.TextBoxPhone_Fax.Name = "TextBoxPhone_Fax"
            Me.TextBoxPhone_Fax.SecurityEnabled = True
            Me.TextBoxPhone_Fax.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPhone_Fax.Size = New System.Drawing.Size(198, 21)
            Me.TextBoxPhone_Fax.StartingFolderName = Nothing
            Me.TextBoxPhone_Fax.TabIndex = 5
            Me.TextBoxPhone_Fax.TabOnEnter = True
            '
            'TextBoxPhone_Voice
            '
            Me.TextBoxPhone_Voice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPhone_Voice.Border.Class = "TextBoxBorder"
            Me.TextBoxPhone_Voice.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPhone_Voice.CheckSpellingOnValidate = False
            Me.TextBoxPhone_Voice.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPhone_Voice.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPhone_Voice.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPhone_Voice.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPhone_Voice.FocusHighlightEnabled = True
            Me.TextBoxPhone_Voice.Location = New System.Drawing.Point(53, 25)
            Me.TextBoxPhone_Voice.MaxFileSize = CType(0, Long)
            Me.TextBoxPhone_Voice.Name = "TextBoxPhone_Voice"
            Me.TextBoxPhone_Voice.SecurityEnabled = True
            Me.TextBoxPhone_Voice.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPhone_Voice.Size = New System.Drawing.Size(198, 21)
            Me.TextBoxPhone_Voice.StartingFolderName = Nothing
            Me.TextBoxPhone_Voice.TabIndex = 1
            Me.TextBoxPhone_Voice.TabOnEnter = True
            '
            'LabelPhone_Cell
            '
            Me.LabelPhone_Cell.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPhone_Cell.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPhone_Cell.Location = New System.Drawing.Point(6, 77)
            Me.LabelPhone_Cell.Name = "LabelPhone_Cell"
            Me.LabelPhone_Cell.Size = New System.Drawing.Size(41, 20)
            Me.LabelPhone_Cell.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPhone_Cell.TabIndex = 8
            Me.LabelPhone_Cell.Text = "Cell:"
            '
            'LabelPhone_Fax
            '
            Me.LabelPhone_Fax.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPhone_Fax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPhone_Fax.Location = New System.Drawing.Point(6, 51)
            Me.LabelPhone_Fax.Name = "LabelPhone_Fax"
            Me.LabelPhone_Fax.Size = New System.Drawing.Size(41, 20)
            Me.LabelPhone_Fax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPhone_Fax.TabIndex = 4
            Me.LabelPhone_Fax.Text = "Fax:"
            '
            'LabelPhone_Voice
            '
            Me.LabelPhone_Voice.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPhone_Voice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPhone_Voice.Location = New System.Drawing.Point(6, 25)
            Me.LabelPhone_Voice.Name = "LabelPhone_Voice"
            Me.LabelPhone_Voice.Size = New System.Drawing.Size(41, 20)
            Me.LabelPhone_Voice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPhone_Voice.TabIndex = 0
            Me.LabelPhone_Voice.Text = "Voice:"
            '
            'TextBoxControl_EmailAddress
            '
            Me.TextBoxControl_EmailAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxControl_EmailAddress.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_EmailAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_EmailAddress.CheckSpellingOnValidate = False
            Me.TextBoxControl_EmailAddress.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Email
            Me.TextBoxControl_EmailAddress.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_EmailAddress.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_EmailAddress.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_EmailAddress.FocusHighlightEnabled = True
            Me.TextBoxControl_EmailAddress.Location = New System.Drawing.Point(88, 156)
            Me.TextBoxControl_EmailAddress.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_EmailAddress.Name = "TextBoxControl_EmailAddress"
            Me.TextBoxControl_EmailAddress.SecurityEnabled = True
            Me.TextBoxControl_EmailAddress.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_EmailAddress.Size = New System.Drawing.Size(266, 21)
            Me.TextBoxControl_EmailAddress.StartingFolderName = Nothing
            Me.TextBoxControl_EmailAddress.TabIndex = 16
            Me.TextBoxControl_EmailAddress.TabOnEnter = True
            '
            'LabelControl_EmailAddress
            '
            Me.LabelControl_EmailAddress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_EmailAddress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_EmailAddress.Location = New System.Drawing.Point(0, 156)
            Me.LabelControl_EmailAddress.Name = "LabelControl_EmailAddress"
            Me.LabelControl_EmailAddress.Size = New System.Drawing.Size(82, 20)
            Me.LabelControl_EmailAddress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_EmailAddress.TabIndex = 15
            Me.LabelControl_EmailAddress.Text = "Email Address:"
            '
            'AddressControlControl_Address
            '
            Me.AddressControlControl_Address.Address = Nothing
            Me.AddressControlControl_Address.Address2 = Nothing
            Me.AddressControlControl_Address.Address3 = Nothing
            Me.AddressControlControl_Address.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AddressControlControl_Address.City = Nothing
            Me.AddressControlControl_Address.Country = Nothing
            Me.AddressControlControl_Address.County = Nothing
            Me.AddressControlControl_Address.DisableCountry = False
            Me.AddressControlControl_Address.DisableCounty = False
            Me.AddressControlControl_Address.Location = New System.Drawing.Point(0, 210)
            Me.AddressControlControl_Address.Margin = New System.Windows.Forms.Padding(4)
            Me.AddressControlControl_Address.Name = "AddressControlControl_Address"
            Me.AddressControlControl_Address.ReadOnly = False
            Me.AddressControlControl_Address.ShowCountry = True
            Me.AddressControlControl_Address.ShowCounty = True
            Me.AddressControlControl_Address.Size = New System.Drawing.Size(354, 181)
            Me.AddressControlControl_Address.State = Nothing
            Me.AddressControlControl_Address.TabIndex = 18
            Me.AddressControlControl_Address.Title = "Address"
            Me.AddressControlControl_Address.Zip = Nothing
            '
            'TextBoxControl_LastName
            '
            Me.TextBoxControl_LastName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxControl_LastName.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_LastName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_LastName.CheckSpellingOnValidate = False
            Me.TextBoxControl_LastName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_LastName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_LastName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_LastName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_LastName.FocusHighlightEnabled = True
            Me.TextBoxControl_LastName.Location = New System.Drawing.Point(88, 129)
            Me.TextBoxControl_LastName.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_LastName.Name = "TextBoxControl_LastName"
            Me.TextBoxControl_LastName.SecurityEnabled = True
            Me.TextBoxControl_LastName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_LastName.Size = New System.Drawing.Size(266, 21)
            Me.TextBoxControl_LastName.StartingFolderName = Nothing
            Me.TextBoxControl_LastName.TabIndex = 14
            Me.TextBoxControl_LastName.TabOnEnter = True
            '
            'TextBoxControl_MiddleInitial
            '
            Me.TextBoxControl_MiddleInitial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxControl_MiddleInitial.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_MiddleInitial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_MiddleInitial.CheckSpellingOnValidate = False
            Me.TextBoxControl_MiddleInitial.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_MiddleInitial.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_MiddleInitial.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_MiddleInitial.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_MiddleInitial.FocusHighlightEnabled = True
            Me.TextBoxControl_MiddleInitial.Location = New System.Drawing.Point(323, 103)
            Me.TextBoxControl_MiddleInitial.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_MiddleInitial.Name = "TextBoxControl_MiddleInitial"
            Me.TextBoxControl_MiddleInitial.SecurityEnabled = True
            Me.TextBoxControl_MiddleInitial.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_MiddleInitial.Size = New System.Drawing.Size(31, 21)
            Me.TextBoxControl_MiddleInitial.StartingFolderName = Nothing
            Me.TextBoxControl_MiddleInitial.TabIndex = 12
            Me.TextBoxControl_MiddleInitial.TabOnEnter = True
            '
            'LabelControl_MiddleInitial
            '
            Me.LabelControl_MiddleInitial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelControl_MiddleInitial.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_MiddleInitial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_MiddleInitial.Location = New System.Drawing.Point(290, 103)
            Me.LabelControl_MiddleInitial.Name = "LabelControl_MiddleInitial"
            Me.LabelControl_MiddleInitial.Size = New System.Drawing.Size(27, 20)
            Me.LabelControl_MiddleInitial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_MiddleInitial.TabIndex = 11
            Me.LabelControl_MiddleInitial.Text = "M.I:"
            '
            'TextBoxControl_FirstName
            '
            Me.TextBoxControl_FirstName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxControl_FirstName.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_FirstName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_FirstName.CheckSpellingOnValidate = False
            Me.TextBoxControl_FirstName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_FirstName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_FirstName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_FirstName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_FirstName.FocusHighlightEnabled = True
            Me.TextBoxControl_FirstName.Location = New System.Drawing.Point(88, 103)
            Me.TextBoxControl_FirstName.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_FirstName.Name = "TextBoxControl_FirstName"
            Me.TextBoxControl_FirstName.SecurityEnabled = True
            Me.TextBoxControl_FirstName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_FirstName.Size = New System.Drawing.Size(196, 21)
            Me.TextBoxControl_FirstName.StartingFolderName = Nothing
            Me.TextBoxControl_FirstName.TabIndex = 10
            Me.TextBoxControl_FirstName.TabOnEnter = True
            '
            'TextBoxControl_Title
            '
            Me.TextBoxControl_Title.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxControl_Title.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_Title.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Title.CheckSpellingOnValidate = False
            Me.TextBoxControl_Title.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Title.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_Title.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Title.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Title.FocusHighlightEnabled = True
            Me.TextBoxControl_Title.Location = New System.Drawing.Point(88, 77)
            Me.TextBoxControl_Title.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Title.Name = "TextBoxControl_Title"
            Me.TextBoxControl_Title.SecurityEnabled = True
            Me.TextBoxControl_Title.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Title.Size = New System.Drawing.Size(266, 21)
            Me.TextBoxControl_Title.StartingFolderName = Nothing
            Me.TextBoxControl_Title.TabIndex = 8
            Me.TextBoxControl_Title.TabOnEnter = True
            '
            'TextBoxControl_Code
            '
            '
            '
            '
            Me.TextBoxControl_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Code.CheckSpellingOnValidate = False
            Me.TextBoxControl_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Code.FocusHighlightEnabled = True
            Me.TextBoxControl_Code.Location = New System.Drawing.Point(88, 26)
            Me.TextBoxControl_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Code.Name = "TextBoxControl_Code"
            Me.TextBoxControl_Code.SecurityEnabled = True
            Me.TextBoxControl_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Code.Size = New System.Drawing.Size(64, 21)
            Me.TextBoxControl_Code.StartingFolderName = Nothing
            Me.TextBoxControl_Code.TabIndex = 3
            Me.TextBoxControl_Code.TabOnEnter = True
            '
            'LabelControl_Title
            '
            Me.LabelControl_Title.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Title.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Title.Location = New System.Drawing.Point(0, 78)
            Me.LabelControl_Title.Name = "LabelControl_Title"
            Me.LabelControl_Title.Size = New System.Drawing.Size(82, 20)
            Me.LabelControl_Title.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Title.TabIndex = 7
            Me.LabelControl_Title.Text = "Title:"
            '
            'LabelControl_LastName
            '
            Me.LabelControl_LastName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_LastName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_LastName.Location = New System.Drawing.Point(0, 130)
            Me.LabelControl_LastName.Name = "LabelControl_LastName"
            Me.LabelControl_LastName.Size = New System.Drawing.Size(82, 20)
            Me.LabelControl_LastName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_LastName.TabIndex = 13
            Me.LabelControl_LastName.Text = "Last Name:"
            '
            'LabelControl_FirstName
            '
            Me.LabelControl_FirstName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_FirstName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_FirstName.Location = New System.Drawing.Point(0, 104)
            Me.LabelControl_FirstName.Name = "LabelControl_FirstName"
            Me.LabelControl_FirstName.Size = New System.Drawing.Size(82, 20)
            Me.LabelControl_FirstName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_FirstName.TabIndex = 9
            Me.LabelControl_FirstName.Text = "First Name:"
            '
            'LabelControl_Code
            '
            Me.LabelControl_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Code.Location = New System.Drawing.Point(0, 26)
            Me.LabelControl_Code.Name = "LabelControl_Code"
            Me.LabelControl_Code.Size = New System.Drawing.Size(82, 20)
            Me.LabelControl_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Code.TabIndex = 2
            Me.LabelControl_Code.Text = "Code:"
            '
            'PanelControl_Control
            '
            Me.PanelControl_Control.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_Control.Controls.Add(Me.SearchableComboBoxControl_ContactType)
            Me.PanelControl_Control.Controls.Add(Me.SearchableComboBoxControl_Vendor)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_ContactType)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_Vendor)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_Code)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_FirstName)
            Me.PanelControl_Control.Controls.Add(Me.ButtonControl_Refresh)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_LastName)
            Me.PanelControl_Control.Controls.Add(Me.CheckBoxControl_Inactive)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_Title)
            Me.PanelControl_Control.Controls.Add(Me.GroupBoxControl_Phone)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxControl_Code)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxControl_EmailAddress)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxControl_Title)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_EmailAddress)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxControl_FirstName)
            Me.PanelControl_Control.Controls.Add(Me.AddressControlControl_Address)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_MiddleInitial)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxControl_LastName)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxControl_MiddleInitial)
            Me.PanelControl_Control.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_Control.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_Control.Margin = New System.Windows.Forms.Padding(2)
            Me.PanelControl_Control.Name = "PanelControl_Control"
            Me.PanelControl_Control.Size = New System.Drawing.Size(354, 503)
            Me.PanelControl_Control.TabIndex = 0
            '
            'SearchableComboBoxControl_ContactType
            '
            Me.SearchableComboBoxControl_ContactType.ActiveFilterString = ""
            Me.SearchableComboBoxControl_ContactType.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxControl_ContactType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxControl_ContactType.AutoFillMode = False
            Me.SearchableComboBoxControl_ContactType.BookmarkingEnabled = False
            Me.SearchableComboBoxControl_ContactType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.ContactType
            Me.SearchableComboBoxControl_ContactType.DataSource = Nothing
            Me.SearchableComboBoxControl_ContactType.DisableMouseWheel = False
            Me.SearchableComboBoxControl_ContactType.DisplayName = ""
            Me.SearchableComboBoxControl_ContactType.EnterMoveNextControl = True
            Me.SearchableComboBoxControl_ContactType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxControl_ContactType.Location = New System.Drawing.Point(88, 52)
            Me.SearchableComboBoxControl_ContactType.Name = "SearchableComboBoxControl_ContactType"
            Me.SearchableComboBoxControl_ContactType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxControl_ContactType.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxControl_ContactType.Properties.NullText = "Select Contact Type"
            Me.SearchableComboBoxControl_ContactType.Properties.ValueMember = "ID"
            Me.SearchableComboBoxControl_ContactType.Properties.View = Me.GridView1
            Me.SearchableComboBoxControl_ContactType.SecurityEnabled = True
            Me.SearchableComboBoxControl_ContactType.SelectedValue = Nothing
            Me.SearchableComboBoxControl_ContactType.Size = New System.Drawing.Size(266, 20)
            Me.SearchableComboBoxControl_ContactType.TabIndex = 6
            '
            'GridView1
            '
            Me.GridView1.AFActiveFilterString = ""
            Me.GridView1.AllowExtraItemsInGridLookupEdits = True
            Me.GridView1.AutoFilterLookupColumns = False
            Me.GridView1.AutoloadRepositoryDatasource = True
            Me.GridView1.DataSourceClearing = False
            Me.GridView1.EnableDisabledRows = False
            Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView1.Name = "GridView1"
            Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView1.OptionsView.ShowGroupPanel = False
            Me.GridView1.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView1.RunStandardValidation = True
            '
            'SearchableComboBoxControl_Vendor
            '
            Me.SearchableComboBoxControl_Vendor.ActiveFilterString = ""
            Me.SearchableComboBoxControl_Vendor.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxControl_Vendor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxControl_Vendor.AutoFillMode = False
            Me.SearchableComboBoxControl_Vendor.BookmarkingEnabled = False
            Me.SearchableComboBoxControl_Vendor.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Vendor
            Me.SearchableComboBoxControl_Vendor.DataSource = Nothing
            Me.SearchableComboBoxControl_Vendor.DisableMouseWheel = False
            Me.SearchableComboBoxControl_Vendor.DisplayName = ""
            Me.SearchableComboBoxControl_Vendor.EnterMoveNextControl = True
            Me.SearchableComboBoxControl_Vendor.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxControl_Vendor.Location = New System.Drawing.Point(88, 0)
            Me.SearchableComboBoxControl_Vendor.Name = "SearchableComboBoxControl_Vendor"
            Me.SearchableComboBoxControl_Vendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxControl_Vendor.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxControl_Vendor.Properties.NullText = "Select Vendor"
            Me.SearchableComboBoxControl_Vendor.Properties.ValueMember = "Code"
            Me.SearchableComboBoxControl_Vendor.Properties.View = Me.GridView4
            Me.SearchableComboBoxControl_Vendor.SecurityEnabled = True
            Me.SearchableComboBoxControl_Vendor.SelectedValue = Nothing
            Me.SearchableComboBoxControl_Vendor.Size = New System.Drawing.Size(266, 20)
            Me.SearchableComboBoxControl_Vendor.TabIndex = 1
            '
            'GridView4
            '
            Me.GridView4.AFActiveFilterString = ""
            Me.GridView4.AllowExtraItemsInGridLookupEdits = True
            Me.GridView4.AutoFilterLookupColumns = False
            Me.GridView4.AutoloadRepositoryDatasource = True
            Me.GridView4.DataSourceClearing = False
            Me.GridView4.EnableDisabledRows = False
            Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView4.Name = "GridView4"
            Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView4.OptionsView.ShowGroupPanel = False
            Me.GridView4.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView4.RunStandardValidation = True
            '
            'LabelControl_ContactType
            '
            Me.LabelControl_ContactType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_ContactType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_ContactType.Location = New System.Drawing.Point(0, 52)
            Me.LabelControl_ContactType.Name = "LabelControl_ContactType"
            Me.LabelControl_ContactType.Size = New System.Drawing.Size(82, 20)
            Me.LabelControl_ContactType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_ContactType.TabIndex = 5
            Me.LabelControl_ContactType.Text = "Contact Type:"
            '
            'VendorContactControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelControl_Control)
            Me.Name = "VendorContactControl"
            Me.Size = New System.Drawing.Size(354, 503)
            CType(Me.GroupBoxControl_Phone, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxControl_Phone.ResumeLayout(False)
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_Control.ResumeLayout(False)
            CType(Me.SearchableComboBoxControl_ContactType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxControl_Vendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelControl_Vendor As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonControl_Refresh As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonItemRefresh_Vendor As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents CheckBoxControl_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxControl_Phone As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxPhone_FaxExt As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxPhone_VoiceExt As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelPhone_FaxExt As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPhone_VoiceExt As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxPhone_Cell As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxPhone_Fax As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxPhone_Voice As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelPhone_Cell As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPhone_Fax As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPhone_Voice As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxControl_EmailAddress As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_EmailAddress As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents AddressControlControl_Address As AdvantageFramework.WinForm.Presentation.Controls.AddressControl
        Friend WithEvents TextBoxControl_LastName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxControl_MiddleInitial As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_MiddleInitial As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxControl_FirstName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxControl_Title As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxControl_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_Title As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_LastName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_FirstName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelControl_Control As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents LabelControl_ContactType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxControl_Vendor As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView4 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxControl_ContactType As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.Presentation.Controls.GridView

    End Class

End Namespace
