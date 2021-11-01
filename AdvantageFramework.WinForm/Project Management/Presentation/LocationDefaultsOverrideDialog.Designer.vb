Namespace ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class LocationDefaultsOverrideDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LocationDefaultsOverrideDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.GroupBoxForm_Header = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxHeader_PrintHeader = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxHeader_Name = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxHeader_Addr1 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxHeader_Addr2 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxHeader_Zip = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxHeader_State = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxHeader_City = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxHeader_Email = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxHeader_Fax = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxHeader_Phone = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxForm_Footer = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxFooter_Email = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxFooter_Fax = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxFooter_Phone = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxFooter_Zip = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxFooter_State = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxFooter_City = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxFooter_Addr2 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxFooter_Addr1 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxFooter_Name = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxFooter_PrintFooter = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_Location = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Logo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonControlForm_Show = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlForm_Hide = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelForm_LocationDetails = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.GroupBoxForm_Header, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_Header.SuspendLayout()
            CType(Me.GroupBoxForm_Footer, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_Footer.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(360, 210)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 8
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(279, 210)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 7
            Me.ButtonForm_OK.Text = "OK"
            '
            'GroupBoxForm_Header
            '
            Me.GroupBoxForm_Header.Controls.Add(Me.CheckBoxHeader_Email)
            Me.GroupBoxForm_Header.Controls.Add(Me.CheckBoxHeader_Fax)
            Me.GroupBoxForm_Header.Controls.Add(Me.CheckBoxHeader_Phone)
            Me.GroupBoxForm_Header.Controls.Add(Me.CheckBoxHeader_Zip)
            Me.GroupBoxForm_Header.Controls.Add(Me.CheckBoxHeader_State)
            Me.GroupBoxForm_Header.Controls.Add(Me.CheckBoxHeader_City)
            Me.GroupBoxForm_Header.Controls.Add(Me.CheckBoxHeader_Addr2)
            Me.GroupBoxForm_Header.Controls.Add(Me.CheckBoxHeader_Addr1)
            Me.GroupBoxForm_Header.Controls.Add(Me.CheckBoxHeader_Name)
            Me.GroupBoxForm_Header.Controls.Add(Me.CheckBoxHeader_PrintHeader)
            Me.GroupBoxForm_Header.Location = New System.Drawing.Point(12, 64)
            Me.GroupBoxForm_Header.Name = "GroupBoxForm_Header"
            Me.GroupBoxForm_Header.Size = New System.Drawing.Size(208, 140)
            Me.GroupBoxForm_Header.TabIndex = 5
            Me.GroupBoxForm_Header.Text = "Header"
            '
            'CheckBoxHeader_PrintHeader
            '
            '
            '
            '
            Me.CheckBoxHeader_PrintHeader.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxHeader_PrintHeader.ChildControls = CType(resources.GetObject("CheckBoxHeader_PrintHeader.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeader_PrintHeader.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxHeader_PrintHeader.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxHeader_PrintHeader.Name = "CheckBoxHeader_PrintHeader"
            Me.CheckBoxHeader_PrintHeader.OldestSibling = Nothing
            Me.CheckBoxHeader_PrintHeader.SecurityEnabled = True
            Me.CheckBoxHeader_PrintHeader.SiblingControls = CType(resources.GetObject("CheckBoxHeader_PrintHeader.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeader_PrintHeader.Size = New System.Drawing.Size(198, 23)
            Me.CheckBoxHeader_PrintHeader.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxHeader_PrintHeader.TabIndex = 0
            Me.CheckBoxHeader_PrintHeader.Text = "Print Header"
            '
            'CheckBoxHeader_Name
            '
            '
            '
            '
            Me.CheckBoxHeader_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxHeader_Name.ChildControls = CType(resources.GetObject("CheckBoxHeader_Name.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeader_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxHeader_Name.Location = New System.Drawing.Point(11, 53)
            Me.CheckBoxHeader_Name.Name = "CheckBoxHeader_Name"
            Me.CheckBoxHeader_Name.OldestSibling = Nothing
            Me.CheckBoxHeader_Name.SecurityEnabled = True
            Me.CheckBoxHeader_Name.SiblingControls = CType(resources.GetObject("CheckBoxHeader_Name.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeader_Name.Size = New System.Drawing.Size(60, 23)
            Me.CheckBoxHeader_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxHeader_Name.TabIndex = 1
            Me.CheckBoxHeader_Name.Text = "Name"
            '
            'CheckBoxHeader_Addr1
            '
            '
            '
            '
            Me.CheckBoxHeader_Addr1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxHeader_Addr1.ChildControls = CType(resources.GetObject("CheckBoxHeader_Addr1.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeader_Addr1.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxHeader_Addr1.Location = New System.Drawing.Point(11, 82)
            Me.CheckBoxHeader_Addr1.Name = "CheckBoxHeader_Addr1"
            Me.CheckBoxHeader_Addr1.OldestSibling = Nothing
            Me.CheckBoxHeader_Addr1.SecurityEnabled = True
            Me.CheckBoxHeader_Addr1.SiblingControls = CType(resources.GetObject("CheckBoxHeader_Addr1.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeader_Addr1.Size = New System.Drawing.Size(60, 23)
            Me.CheckBoxHeader_Addr1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxHeader_Addr1.TabIndex = 2
            Me.CheckBoxHeader_Addr1.Text = "Addr 1"
            '
            'CheckBoxHeader_Addr2
            '
            '
            '
            '
            Me.CheckBoxHeader_Addr2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxHeader_Addr2.ChildControls = CType(resources.GetObject("CheckBoxHeader_Addr2.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeader_Addr2.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxHeader_Addr2.Location = New System.Drawing.Point(11, 111)
            Me.CheckBoxHeader_Addr2.Name = "CheckBoxHeader_Addr2"
            Me.CheckBoxHeader_Addr2.OldestSibling = Nothing
            Me.CheckBoxHeader_Addr2.SecurityEnabled = True
            Me.CheckBoxHeader_Addr2.SiblingControls = CType(resources.GetObject("CheckBoxHeader_Addr2.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeader_Addr2.Size = New System.Drawing.Size(60, 23)
            Me.CheckBoxHeader_Addr2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxHeader_Addr2.TabIndex = 3
            Me.CheckBoxHeader_Addr2.Text = "Addr 2"
            '
            'CheckBoxHeader_Zip
            '
            '
            '
            '
            Me.CheckBoxHeader_Zip.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxHeader_Zip.ChildControls = CType(resources.GetObject("CheckBoxHeader_Zip.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeader_Zip.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxHeader_Zip.Location = New System.Drawing.Point(77, 111)
            Me.CheckBoxHeader_Zip.Name = "CheckBoxHeader_Zip"
            Me.CheckBoxHeader_Zip.OldestSibling = Nothing
            Me.CheckBoxHeader_Zip.SecurityEnabled = True
            Me.CheckBoxHeader_Zip.SiblingControls = CType(resources.GetObject("CheckBoxHeader_Zip.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeader_Zip.Size = New System.Drawing.Size(60, 23)
            Me.CheckBoxHeader_Zip.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxHeader_Zip.TabIndex = 6
            Me.CheckBoxHeader_Zip.Text = "Zip"
            '
            'CheckBoxHeader_State
            '
            '
            '
            '
            Me.CheckBoxHeader_State.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxHeader_State.ChildControls = CType(resources.GetObject("CheckBoxHeader_State.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeader_State.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxHeader_State.Location = New System.Drawing.Point(77, 82)
            Me.CheckBoxHeader_State.Name = "CheckBoxHeader_State"
            Me.CheckBoxHeader_State.OldestSibling = Nothing
            Me.CheckBoxHeader_State.SecurityEnabled = True
            Me.CheckBoxHeader_State.SiblingControls = CType(resources.GetObject("CheckBoxHeader_State.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeader_State.Size = New System.Drawing.Size(60, 23)
            Me.CheckBoxHeader_State.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxHeader_State.TabIndex = 5
            Me.CheckBoxHeader_State.Text = "State"
            '
            'CheckBoxHeader_City
            '
            '
            '
            '
            Me.CheckBoxHeader_City.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxHeader_City.ChildControls = CType(resources.GetObject("CheckBoxHeader_City.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeader_City.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxHeader_City.Location = New System.Drawing.Point(77, 53)
            Me.CheckBoxHeader_City.Name = "CheckBoxHeader_City"
            Me.CheckBoxHeader_City.OldestSibling = Nothing
            Me.CheckBoxHeader_City.SecurityEnabled = True
            Me.CheckBoxHeader_City.SiblingControls = CType(resources.GetObject("CheckBoxHeader_City.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeader_City.Size = New System.Drawing.Size(60, 23)
            Me.CheckBoxHeader_City.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxHeader_City.TabIndex = 4
            Me.CheckBoxHeader_City.Text = "City"
            '
            'CheckBoxHeader_Email
            '
            '
            '
            '
            Me.CheckBoxHeader_Email.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxHeader_Email.ChildControls = CType(resources.GetObject("CheckBoxHeader_Email.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeader_Email.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxHeader_Email.Location = New System.Drawing.Point(143, 111)
            Me.CheckBoxHeader_Email.Name = "CheckBoxHeader_Email"
            Me.CheckBoxHeader_Email.OldestSibling = Nothing
            Me.CheckBoxHeader_Email.SecurityEnabled = True
            Me.CheckBoxHeader_Email.SiblingControls = CType(resources.GetObject("CheckBoxHeader_Email.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeader_Email.Size = New System.Drawing.Size(60, 23)
            Me.CheckBoxHeader_Email.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxHeader_Email.TabIndex = 9
            Me.CheckBoxHeader_Email.Text = "Email"
            '
            'CheckBoxHeader_Fax
            '
            '
            '
            '
            Me.CheckBoxHeader_Fax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxHeader_Fax.ChildControls = CType(resources.GetObject("CheckBoxHeader_Fax.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeader_Fax.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxHeader_Fax.Location = New System.Drawing.Point(143, 82)
            Me.CheckBoxHeader_Fax.Name = "CheckBoxHeader_Fax"
            Me.CheckBoxHeader_Fax.OldestSibling = Nothing
            Me.CheckBoxHeader_Fax.SecurityEnabled = True
            Me.CheckBoxHeader_Fax.SiblingControls = CType(resources.GetObject("CheckBoxHeader_Fax.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeader_Fax.Size = New System.Drawing.Size(60, 23)
            Me.CheckBoxHeader_Fax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxHeader_Fax.TabIndex = 8
            Me.CheckBoxHeader_Fax.Text = "Fax"
            '
            'CheckBoxHeader_Phone
            '
            '
            '
            '
            Me.CheckBoxHeader_Phone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxHeader_Phone.ChildControls = CType(resources.GetObject("CheckBoxHeader_Phone.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeader_Phone.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxHeader_Phone.Location = New System.Drawing.Point(143, 53)
            Me.CheckBoxHeader_Phone.Name = "CheckBoxHeader_Phone"
            Me.CheckBoxHeader_Phone.OldestSibling = Nothing
            Me.CheckBoxHeader_Phone.SecurityEnabled = True
            Me.CheckBoxHeader_Phone.SiblingControls = CType(resources.GetObject("CheckBoxHeader_Phone.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeader_Phone.Size = New System.Drawing.Size(60, 23)
            Me.CheckBoxHeader_Phone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxHeader_Phone.TabIndex = 7
            Me.CheckBoxHeader_Phone.Text = "Phone"
            '
            'GroupBoxForm_Footer
            '
            Me.GroupBoxForm_Footer.Controls.Add(Me.CheckBoxFooter_Email)
            Me.GroupBoxForm_Footer.Controls.Add(Me.CheckBoxFooter_Fax)
            Me.GroupBoxForm_Footer.Controls.Add(Me.CheckBoxFooter_Phone)
            Me.GroupBoxForm_Footer.Controls.Add(Me.CheckBoxFooter_Zip)
            Me.GroupBoxForm_Footer.Controls.Add(Me.CheckBoxFooter_State)
            Me.GroupBoxForm_Footer.Controls.Add(Me.CheckBoxFooter_City)
            Me.GroupBoxForm_Footer.Controls.Add(Me.CheckBoxFooter_Addr2)
            Me.GroupBoxForm_Footer.Controls.Add(Me.CheckBoxFooter_Addr1)
            Me.GroupBoxForm_Footer.Controls.Add(Me.CheckBoxFooter_Name)
            Me.GroupBoxForm_Footer.Controls.Add(Me.CheckBoxFooter_PrintFooter)
            Me.GroupBoxForm_Footer.Location = New System.Drawing.Point(226, 64)
            Me.GroupBoxForm_Footer.Name = "GroupBoxForm_Footer"
            Me.GroupBoxForm_Footer.Size = New System.Drawing.Size(208, 140)
            Me.GroupBoxForm_Footer.TabIndex = 6
            Me.GroupBoxForm_Footer.Text = "Footer"
            '
            'CheckBoxFooter_Email
            '
            '
            '
            '
            Me.CheckBoxFooter_Email.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFooter_Email.ChildControls = CType(resources.GetObject("CheckBoxFooter_Email.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFooter_Email.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFooter_Email.Location = New System.Drawing.Point(143, 111)
            Me.CheckBoxFooter_Email.Name = "CheckBoxFooter_Email"
            Me.CheckBoxFooter_Email.OldestSibling = Nothing
            Me.CheckBoxFooter_Email.SecurityEnabled = True
            Me.CheckBoxFooter_Email.SiblingControls = CType(resources.GetObject("CheckBoxFooter_Email.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFooter_Email.Size = New System.Drawing.Size(60, 23)
            Me.CheckBoxFooter_Email.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFooter_Email.TabIndex = 9
            Me.CheckBoxFooter_Email.Text = "Email"
            '
            'CheckBoxFooter_Fax
            '
            '
            '
            '
            Me.CheckBoxFooter_Fax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFooter_Fax.ChildControls = CType(resources.GetObject("CheckBoxFooter_Fax.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFooter_Fax.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFooter_Fax.Location = New System.Drawing.Point(143, 82)
            Me.CheckBoxFooter_Fax.Name = "CheckBoxFooter_Fax"
            Me.CheckBoxFooter_Fax.OldestSibling = Nothing
            Me.CheckBoxFooter_Fax.SecurityEnabled = True
            Me.CheckBoxFooter_Fax.SiblingControls = CType(resources.GetObject("CheckBoxFooter_Fax.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFooter_Fax.Size = New System.Drawing.Size(60, 23)
            Me.CheckBoxFooter_Fax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFooter_Fax.TabIndex = 8
            Me.CheckBoxFooter_Fax.Text = "Fax"
            '
            'CheckBoxFooter_Phone
            '
            '
            '
            '
            Me.CheckBoxFooter_Phone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFooter_Phone.ChildControls = CType(resources.GetObject("CheckBoxFooter_Phone.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFooter_Phone.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFooter_Phone.Location = New System.Drawing.Point(143, 53)
            Me.CheckBoxFooter_Phone.Name = "CheckBoxFooter_Phone"
            Me.CheckBoxFooter_Phone.OldestSibling = Nothing
            Me.CheckBoxFooter_Phone.SecurityEnabled = True
            Me.CheckBoxFooter_Phone.SiblingControls = CType(resources.GetObject("CheckBoxFooter_Phone.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFooter_Phone.Size = New System.Drawing.Size(60, 23)
            Me.CheckBoxFooter_Phone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFooter_Phone.TabIndex = 7
            Me.CheckBoxFooter_Phone.Text = "Phone"
            '
            'CheckBoxFooter_Zip
            '
            '
            '
            '
            Me.CheckBoxFooter_Zip.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFooter_Zip.ChildControls = CType(resources.GetObject("CheckBoxFooter_Zip.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFooter_Zip.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFooter_Zip.Location = New System.Drawing.Point(77, 111)
            Me.CheckBoxFooter_Zip.Name = "CheckBoxFooter_Zip"
            Me.CheckBoxFooter_Zip.OldestSibling = Nothing
            Me.CheckBoxFooter_Zip.SecurityEnabled = True
            Me.CheckBoxFooter_Zip.SiblingControls = CType(resources.GetObject("CheckBoxFooter_Zip.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFooter_Zip.Size = New System.Drawing.Size(60, 23)
            Me.CheckBoxFooter_Zip.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFooter_Zip.TabIndex = 6
            Me.CheckBoxFooter_Zip.Text = "Zip"
            '
            'CheckBoxFooter_State
            '
            '
            '
            '
            Me.CheckBoxFooter_State.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFooter_State.ChildControls = CType(resources.GetObject("CheckBoxFooter_State.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFooter_State.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFooter_State.Location = New System.Drawing.Point(77, 82)
            Me.CheckBoxFooter_State.Name = "CheckBoxFooter_State"
            Me.CheckBoxFooter_State.OldestSibling = Nothing
            Me.CheckBoxFooter_State.SecurityEnabled = True
            Me.CheckBoxFooter_State.SiblingControls = CType(resources.GetObject("CheckBoxFooter_State.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFooter_State.Size = New System.Drawing.Size(60, 23)
            Me.CheckBoxFooter_State.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFooter_State.TabIndex = 5
            Me.CheckBoxFooter_State.Text = "State"
            '
            'CheckBoxFooter_City
            '
            '
            '
            '
            Me.CheckBoxFooter_City.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFooter_City.ChildControls = CType(resources.GetObject("CheckBoxFooter_City.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFooter_City.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFooter_City.Location = New System.Drawing.Point(77, 53)
            Me.CheckBoxFooter_City.Name = "CheckBoxFooter_City"
            Me.CheckBoxFooter_City.OldestSibling = Nothing
            Me.CheckBoxFooter_City.SecurityEnabled = True
            Me.CheckBoxFooter_City.SiblingControls = CType(resources.GetObject("CheckBoxFooter_City.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFooter_City.Size = New System.Drawing.Size(60, 23)
            Me.CheckBoxFooter_City.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFooter_City.TabIndex = 4
            Me.CheckBoxFooter_City.Text = "City"
            '
            'CheckBoxFooter_Addr2
            '
            '
            '
            '
            Me.CheckBoxFooter_Addr2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFooter_Addr2.ChildControls = CType(resources.GetObject("CheckBoxFooter_Addr2.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFooter_Addr2.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFooter_Addr2.Location = New System.Drawing.Point(11, 111)
            Me.CheckBoxFooter_Addr2.Name = "CheckBoxFooter_Addr2"
            Me.CheckBoxFooter_Addr2.OldestSibling = Nothing
            Me.CheckBoxFooter_Addr2.SecurityEnabled = True
            Me.CheckBoxFooter_Addr2.SiblingControls = CType(resources.GetObject("CheckBoxFooter_Addr2.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFooter_Addr2.Size = New System.Drawing.Size(60, 23)
            Me.CheckBoxFooter_Addr2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFooter_Addr2.TabIndex = 3
            Me.CheckBoxFooter_Addr2.Text = "Addr 2"
            '
            'CheckBoxFooter_Addr1
            '
            '
            '
            '
            Me.CheckBoxFooter_Addr1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFooter_Addr1.ChildControls = CType(resources.GetObject("CheckBoxFooter_Addr1.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFooter_Addr1.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFooter_Addr1.Location = New System.Drawing.Point(11, 82)
            Me.CheckBoxFooter_Addr1.Name = "CheckBoxFooter_Addr1"
            Me.CheckBoxFooter_Addr1.OldestSibling = Nothing
            Me.CheckBoxFooter_Addr1.SecurityEnabled = True
            Me.CheckBoxFooter_Addr1.SiblingControls = CType(resources.GetObject("CheckBoxFooter_Addr1.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFooter_Addr1.Size = New System.Drawing.Size(60, 23)
            Me.CheckBoxFooter_Addr1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFooter_Addr1.TabIndex = 2
            Me.CheckBoxFooter_Addr1.Text = "Addr 1"
            '
            'CheckBoxFooter_Name
            '
            '
            '
            '
            Me.CheckBoxFooter_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFooter_Name.ChildControls = CType(resources.GetObject("CheckBoxFooter_Name.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFooter_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFooter_Name.Location = New System.Drawing.Point(11, 53)
            Me.CheckBoxFooter_Name.Name = "CheckBoxFooter_Name"
            Me.CheckBoxFooter_Name.OldestSibling = Nothing
            Me.CheckBoxFooter_Name.SecurityEnabled = True
            Me.CheckBoxFooter_Name.SiblingControls = CType(resources.GetObject("CheckBoxFooter_Name.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFooter_Name.Size = New System.Drawing.Size(60, 23)
            Me.CheckBoxFooter_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFooter_Name.TabIndex = 1
            Me.CheckBoxFooter_Name.Text = "Name"
            '
            'CheckBoxFooter_PrintFooter
            '
            '
            '
            '
            Me.CheckBoxFooter_PrintFooter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFooter_PrintFooter.ChildControls = CType(resources.GetObject("CheckBoxFooter_PrintFooter.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFooter_PrintFooter.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFooter_PrintFooter.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxFooter_PrintFooter.Name = "CheckBoxFooter_PrintFooter"
            Me.CheckBoxFooter_PrintFooter.OldestSibling = Nothing
            Me.CheckBoxFooter_PrintFooter.SecurityEnabled = True
            Me.CheckBoxFooter_PrintFooter.SiblingControls = CType(resources.GetObject("CheckBoxFooter_PrintFooter.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFooter_PrintFooter.Size = New System.Drawing.Size(198, 23)
            Me.CheckBoxFooter_PrintFooter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFooter_PrintFooter.TabIndex = 0
            Me.CheckBoxFooter_PrintFooter.Text = "Print Footer"
            '
            'LabelForm_Location
            '
            Me.LabelForm_Location.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Location.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Location.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Location.Name = "LabelForm_Location"
            Me.LabelForm_Location.Size = New System.Drawing.Size(53, 20)
            Me.LabelForm_Location.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Location.TabIndex = 0
            Me.LabelForm_Location.Text = "Location:"
            '
            'LabelForm_Logo
            '
            Me.LabelForm_Logo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Logo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Logo.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Logo.Name = "LabelForm_Logo"
            Me.LabelForm_Logo.Size = New System.Drawing.Size(53, 20)
            Me.LabelForm_Logo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Logo.TabIndex = 2
            Me.LabelForm_Logo.Text = "Logo:"
            '
            'RadioButtonControlForm_Show
            '
            '
            '
            '
            Me.RadioButtonControlForm_Show.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_Show.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_Show.Location = New System.Drawing.Point(71, 38)
            Me.RadioButtonControlForm_Show.Name = "RadioButtonControlForm_Show"
            Me.RadioButtonControlForm_Show.Size = New System.Drawing.Size(67, 20)
            Me.RadioButtonControlForm_Show.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_Show.TabIndex = 3
            Me.RadioButtonControlForm_Show.TabStop = False
            Me.RadioButtonControlForm_Show.Text = "Show"
            '
            'RadioButtonControlForm_Hide
            '
            '
            '
            '
            Me.RadioButtonControlForm_Hide.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_Hide.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_Hide.Location = New System.Drawing.Point(144, 38)
            Me.RadioButtonControlForm_Hide.Name = "RadioButtonControlForm_Hide"
            Me.RadioButtonControlForm_Hide.Size = New System.Drawing.Size(67, 20)
            Me.RadioButtonControlForm_Hide.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_Hide.TabIndex = 4
            Me.RadioButtonControlForm_Hide.TabStop = False
            Me.RadioButtonControlForm_Hide.Text = "Hide"
            '
            'LabelForm_LocationDetails
            '
            Me.LabelForm_LocationDetails.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_LocationDetails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_LocationDetails.Location = New System.Drawing.Point(71, 12)
            Me.LabelForm_LocationDetails.Name = "LabelForm_LocationDetails"
            Me.LabelForm_LocationDetails.Size = New System.Drawing.Size(363, 20)
            Me.LabelForm_LocationDetails.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_LocationDetails.TabIndex = 1
            Me.LabelForm_LocationDetails.Text = "{0}"
            '
            'LocationDefaultsOverrideDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(447, 242)
            Me.Controls.Add(Me.LabelForm_LocationDetails)
            Me.Controls.Add(Me.RadioButtonControlForm_Hide)
            Me.Controls.Add(Me.RadioButtonControlForm_Show)
            Me.Controls.Add(Me.LabelForm_Logo)
            Me.Controls.Add(Me.LabelForm_Location)
            Me.Controls.Add(Me.GroupBoxForm_Footer)
            Me.Controls.Add(Me.GroupBoxForm_Header)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.DoubleBuffered = True
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "LocationDefaultsOverrideDialog"
            Me.Text = "Location Defaults - Location Override"
            CType(Me.GroupBoxForm_Header, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_Header.ResumeLayout(False)
            CType(Me.GroupBoxForm_Footer, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_Footer.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents GroupBoxForm_Header As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxHeader_Email As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxHeader_Fax As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxHeader_Phone As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxHeader_Zip As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxHeader_State As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxHeader_City As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxHeader_Addr2 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxHeader_Addr1 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxHeader_Name As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxHeader_PrintHeader As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxForm_Footer As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxFooter_Email As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxFooter_Fax As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxFooter_Phone As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxFooter_Zip As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxFooter_State As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxFooter_City As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxFooter_Addr2 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxFooter_Addr1 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxFooter_Name As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxFooter_PrintFooter As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_Location As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Logo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonControlForm_Show As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlForm_Hide As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelForm_LocationDetails As AdvantageFramework.WinForm.Presentation.Controls.Label

    End Class

End Namespace