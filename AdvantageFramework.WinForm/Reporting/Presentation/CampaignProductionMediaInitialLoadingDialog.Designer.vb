Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CampaignProductionMediaInitialLoadingDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CampaignProductionMediaInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.CheckBoxForm_Closed = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_StartingPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_CampaignFrom = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.Label1 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBox_Clients = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_CampaignTo = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.Label2 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBox_CampaignMasterJob = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(258, 154)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 3
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(339, 154)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 4
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'CheckBoxForm_Closed
            '
            Me.CheckBoxForm_Closed.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_Closed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Closed.CheckValue = 0
            Me.CheckBoxForm_Closed.CheckValueChecked = 1
            Me.CheckBoxForm_Closed.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Closed.CheckValueUnchecked = 0
            Me.CheckBoxForm_Closed.ChildControls = CType(resources.GetObject("CheckBoxForm_Closed.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Closed.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Closed.Location = New System.Drawing.Point(6, 91)
            Me.CheckBoxForm_Closed.Name = "CheckBoxForm_Closed"
            Me.CheckBoxForm_Closed.OldestSibling = Nothing
            Me.CheckBoxForm_Closed.SecurityEnabled = True
            Me.CheckBoxForm_Closed.SiblingControls = CType(resources.GetObject("CheckBoxForm_Closed.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Closed.Size = New System.Drawing.Size(408, 20)
            Me.CheckBoxForm_Closed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Closed.TabIndex = 2
            Me.CheckBoxForm_Closed.TabOnEnter = True
            Me.CheckBoxForm_Closed.Text = "Include Closed Campaigns"
            '
            'LabelForm_StartingPostPeriod
            '
            Me.LabelForm_StartingPostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StartingPostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StartingPostPeriod.Location = New System.Drawing.Point(6, 39)
            Me.LabelForm_StartingPostPeriod.Name = "LabelForm_StartingPostPeriod"
            Me.LabelForm_StartingPostPeriod.Size = New System.Drawing.Size(90, 20)
            Me.LabelForm_StartingPostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StartingPostPeriod.TabIndex = 0
            Me.LabelForm_StartingPostPeriod.Text = "From Campaign:"
            '
            'ComboBoxForm_CampaignFrom
            '
            Me.ComboBoxForm_CampaignFrom.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_CampaignFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_CampaignFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_CampaignFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_CampaignFrom.AutoFindItemInDataSource = False
            Me.ComboBoxForm_CampaignFrom.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_CampaignFrom.BookmarkingEnabled = False
            Me.ComboBoxForm_CampaignFrom.ClientCode = ""
            Me.ComboBoxForm_CampaignFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Campaign
            Me.ComboBoxForm_CampaignFrom.DisableMouseWheel = False
            Me.ComboBoxForm_CampaignFrom.DisplayMember = "Name"
            Me.ComboBoxForm_CampaignFrom.DisplayName = ""
            Me.ComboBoxForm_CampaignFrom.DivisionCode = ""
            Me.ComboBoxForm_CampaignFrom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_CampaignFrom.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_CampaignFrom.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_CampaignFrom.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_CampaignFrom.FocusHighlightEnabled = True
            Me.ComboBoxForm_CampaignFrom.FormattingEnabled = True
            Me.ComboBoxForm_CampaignFrom.ItemHeight = 14
            Me.ComboBoxForm_CampaignFrom.Location = New System.Drawing.Point(102, 39)
            Me.ComboBoxForm_CampaignFrom.Name = "ComboBoxForm_CampaignFrom"
            Me.ComboBoxForm_CampaignFrom.ReadOnly = False
            Me.ComboBoxForm_CampaignFrom.SecurityEnabled = True
            Me.ComboBoxForm_CampaignFrom.Size = New System.Drawing.Size(312, 20)
            Me.ComboBoxForm_CampaignFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_CampaignFrom.TabIndex = 1
            Me.ComboBoxForm_CampaignFrom.TabOnEnter = True
            Me.ComboBoxForm_CampaignFrom.ValueMember = "Code"
            Me.ComboBoxForm_CampaignFrom.WatermarkText = "Select Campaign"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label1.Location = New System.Drawing.Point(6, 12)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(90, 20)
            Me.Label1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label1.TabIndex = 5
            Me.Label1.Text = "Client:"
            '
            'ComboBox_Clients
            '
            Me.ComboBox_Clients.AddInactiveItemsOnSelectedValue = False
            Me.ComboBox_Clients.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBox_Clients.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBox_Clients.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBox_Clients.AutoFindItemInDataSource = False
            Me.ComboBox_Clients.AutoSelectSingleItemDatasource = False
            Me.ComboBox_Clients.BookmarkingEnabled = False
            Me.ComboBox_Clients.ClientCode = ""
            Me.ComboBox_Clients.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBox_Clients.DisableMouseWheel = False
            Me.ComboBox_Clients.DisplayMember = "Name"
            Me.ComboBox_Clients.DisplayName = ""
            Me.ComboBox_Clients.DivisionCode = ""
            Me.ComboBox_Clients.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBox_Clients.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBox_Clients.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBox_Clients.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBox_Clients.FocusHighlightEnabled = True
            Me.ComboBox_Clients.FormattingEnabled = True
            Me.ComboBox_Clients.ItemHeight = 14
            Me.ComboBox_Clients.Location = New System.Drawing.Point(102, 12)
            Me.ComboBox_Clients.Name = "ComboBox_Clients"
            Me.ComboBox_Clients.ReadOnly = False
            Me.ComboBox_Clients.SecurityEnabled = True
            Me.ComboBox_Clients.Size = New System.Drawing.Size(312, 20)
            Me.ComboBox_Clients.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBox_Clients.TabIndex = 6
            Me.ComboBox_Clients.TabOnEnter = True
            Me.ComboBox_Clients.ValueMember = "ID"
            Me.ComboBox_Clients.WatermarkText = "Select Post Period"
            '
            'ComboBoxForm_CampaignTo
            '
            Me.ComboBoxForm_CampaignTo.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_CampaignTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_CampaignTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_CampaignTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_CampaignTo.AutoFindItemInDataSource = False
            Me.ComboBoxForm_CampaignTo.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_CampaignTo.BookmarkingEnabled = False
            Me.ComboBoxForm_CampaignTo.ClientCode = ""
            Me.ComboBoxForm_CampaignTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Campaign
            Me.ComboBoxForm_CampaignTo.DisableMouseWheel = False
            Me.ComboBoxForm_CampaignTo.DisplayMember = "Name"
            Me.ComboBoxForm_CampaignTo.DisplayName = ""
            Me.ComboBoxForm_CampaignTo.DivisionCode = ""
            Me.ComboBoxForm_CampaignTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_CampaignTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_CampaignTo.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_CampaignTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_CampaignTo.FocusHighlightEnabled = True
            Me.ComboBoxForm_CampaignTo.FormattingEnabled = True
            Me.ComboBoxForm_CampaignTo.ItemHeight = 14
            Me.ComboBoxForm_CampaignTo.Location = New System.Drawing.Point(102, 65)
            Me.ComboBoxForm_CampaignTo.Name = "ComboBoxForm_CampaignTo"
            Me.ComboBoxForm_CampaignTo.ReadOnly = False
            Me.ComboBoxForm_CampaignTo.SecurityEnabled = True
            Me.ComboBoxForm_CampaignTo.Size = New System.Drawing.Size(312, 20)
            Me.ComboBoxForm_CampaignTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_CampaignTo.TabIndex = 7
            Me.ComboBoxForm_CampaignTo.TabOnEnter = True
            Me.ComboBoxForm_CampaignTo.ValueMember = "Code"
            Me.ComboBoxForm_CampaignTo.WatermarkText = "Select Campaign"
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label2.Location = New System.Drawing.Point(6, 65)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(90, 20)
            Me.Label2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label2.TabIndex = 8
            Me.Label2.Text = "To Campaign:"
            '
            'CheckBox_CampaignMasterJob
            '
            Me.CheckBox_CampaignMasterJob.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBox_CampaignMasterJob.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBox_CampaignMasterJob.CheckValue = 0
            Me.CheckBox_CampaignMasterJob.CheckValueChecked = 1
            Me.CheckBox_CampaignMasterJob.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBox_CampaignMasterJob.CheckValueUnchecked = 0
            Me.CheckBox_CampaignMasterJob.ChildControls = CType(resources.GetObject("CheckBox_CampaignMasterJob.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBox_CampaignMasterJob.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBox_CampaignMasterJob.Location = New System.Drawing.Point(6, 117)
            Me.CheckBox_CampaignMasterJob.Name = "CheckBox_CampaignMasterJob"
            Me.CheckBox_CampaignMasterJob.OldestSibling = Nothing
            Me.CheckBox_CampaignMasterJob.SecurityEnabled = True
            Me.CheckBox_CampaignMasterJob.SiblingControls = CType(resources.GetObject("CheckBox_CampaignMasterJob.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBox_CampaignMasterJob.Size = New System.Drawing.Size(408, 20)
            Me.CheckBox_CampaignMasterJob.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBox_CampaignMasterJob.TabIndex = 9
            Me.CheckBox_CampaignMasterJob.TabOnEnter = True
            Me.CheckBox_CampaignMasterJob.Text = "Use Campaign Master Job Estimate"
            '
            'CampaignProductionMediaInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(426, 186)
            Me.Controls.Add(Me.CheckBox_CampaignMasterJob)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.ComboBoxForm_CampaignTo)
            Me.Controls.Add(Me.ComboBox_Clients)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.LabelForm_StartingPostPeriod)
            Me.Controls.Add(Me.ComboBoxForm_CampaignFrom)
            Me.Controls.Add(Me.CheckBoxForm_Closed)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "CampaignProductionMediaInitialLoadingDialog"
            Me.Text = "Campaign Initial Criteria"
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Private WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Private WithEvents CheckBoxForm_Closed As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_StartingPostPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_CampaignFrom As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents Label1 As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBox_Clients As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_CampaignTo As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents Label2 As WinForm.Presentation.Controls.Label
        Private WithEvents CheckBox_CampaignMasterJob As WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace