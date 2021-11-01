Namespace Desktop.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ProofHQUploadDocumentDialog
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProofHQUploadDocumentDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Upload = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelGeneral_DocumentLabel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_Document = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_Folder = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxGeneral_Folder = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelGeneral_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxGeneral_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabControlForm_DocumentDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelGeneralTab_General = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBoxGeneral_SendAlertAssignment = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxGeneral_SendAlert = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabItemDocumentDetails_GeneralTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions = New DevComponents.DotNetBar.TabControlPanel()
            Me.ComboBoxAlertAssignmentOptions_AssignTo = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxAlertAssignmentOptions_State = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelAlertAssignmentOptions_AssignTo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelAlertAssignmentOptions_State = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelAlertAssignmentOptions_Template = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxAlertAssignmentOptions_Template = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.TabItemDocumentDetails_AlertAssignmentOptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelAlertOptionsTab_AlertOptions = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelAlertOptions_SelectRecipients = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelAlertOptions_Subject = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TreeListControlAlertOptions_Recepients = New AdvantageFramework.WinForm.Presentation.Controls.TreeListControl()
            Me.LabelAlertOptions_Priority = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxAlertOptions_Subject = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelAlertOptions_Category = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxAlertOptions_Priority = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxAlertOptions_Category = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.TabItemDocumentDetails_AlertOptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.TabControlForm_DocumentDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_DocumentDetails.SuspendLayout()
            Me.TabControlPanelGeneralTab_General.SuspendLayout()
            Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions.SuspendLayout()
            Me.TabControlPanelAlertOptionsTab_AlertOptions.SuspendLayout()
            CType(Me.TreeListControlAlertOptions_Recepients, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(361, 334)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 2
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Upload
            '
            Me.ButtonForm_Upload.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Upload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Upload.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Upload.Location = New System.Drawing.Point(280, 334)
            Me.ButtonForm_Upload.Name = "ButtonForm_Upload"
            Me.ButtonForm_Upload.SecurityEnabled = True
            Me.ButtonForm_Upload.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Upload.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Upload.TabIndex = 1
            Me.ButtonForm_Upload.Text = "Upload"
            '
            'LabelGeneral_DocumentLabel
            '
            Me.LabelGeneral_DocumentLabel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_DocumentLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_DocumentLabel.Location = New System.Drawing.Point(4, 4)
            Me.LabelGeneral_DocumentLabel.Name = "LabelGeneral_DocumentLabel"
            Me.LabelGeneral_DocumentLabel.Size = New System.Drawing.Size(75, 20)
            Me.LabelGeneral_DocumentLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_DocumentLabel.TabIndex = 0
            Me.LabelGeneral_DocumentLabel.Text = "Document:"
            '
            'LabelGeneral_Document
            '
            Me.LabelGeneral_Document.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGeneral_Document.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Document.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Document.Location = New System.Drawing.Point(85, 4)
            Me.LabelGeneral_Document.Name = "LabelGeneral_Document"
            Me.LabelGeneral_Document.Size = New System.Drawing.Size(335, 20)
            Me.LabelGeneral_Document.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Document.TabIndex = 1
            '
            'LabelGeneral_Folder
            '
            Me.LabelGeneral_Folder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Folder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Folder.Location = New System.Drawing.Point(4, 56)
            Me.LabelGeneral_Folder.Name = "LabelGeneral_Folder"
            Me.LabelGeneral_Folder.Size = New System.Drawing.Size(75, 20)
            Me.LabelGeneral_Folder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Folder.TabIndex = 4
            Me.LabelGeneral_Folder.Text = "Folder:"
            '
            'ComboBoxGeneral_Folder
            '
            Me.ComboBoxGeneral_Folder.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxGeneral_Folder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxGeneral_Folder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxGeneral_Folder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxGeneral_Folder.AutoFindItemInDataSource = False
            Me.ComboBoxGeneral_Folder.AutoSelectSingleItemDatasource = False
            Me.ComboBoxGeneral_Folder.BookmarkingEnabled = False
            Me.ComboBoxGeneral_Folder.ClientCode = ""
            Me.ComboBoxGeneral_Folder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxGeneral_Folder.DisableMouseWheel = False
            Me.ComboBoxGeneral_Folder.DisplayMember = "Description"
            Me.ComboBoxGeneral_Folder.DisplayName = ""
            Me.ComboBoxGeneral_Folder.DivisionCode = ""
            Me.ComboBoxGeneral_Folder.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxGeneral_Folder.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxGeneral_Folder.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxGeneral_Folder.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxGeneral_Folder.FocusHighlightEnabled = True
            Me.ComboBoxGeneral_Folder.FormattingEnabled = True
            Me.ComboBoxGeneral_Folder.ItemHeight = 14
            Me.ComboBoxGeneral_Folder.Location = New System.Drawing.Point(85, 56)
            Me.ComboBoxGeneral_Folder.Name = "ComboBoxGeneral_Folder"
            Me.ComboBoxGeneral_Folder.PreventEnterBeep = False
            Me.ComboBoxGeneral_Folder.ReadOnly = False
            Me.ComboBoxGeneral_Folder.SecurityEnabled = True
            Me.ComboBoxGeneral_Folder.Size = New System.Drawing.Size(335, 20)
            Me.ComboBoxGeneral_Folder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxGeneral_Folder.TabIndex = 5
            Me.ComboBoxGeneral_Folder.ValueMember = "Code"
            Me.ComboBoxGeneral_Folder.WatermarkText = "Select"
            '
            'LabelGeneral_Name
            '
            Me.LabelGeneral_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Name.Location = New System.Drawing.Point(4, 30)
            Me.LabelGeneral_Name.Name = "LabelGeneral_Name"
            Me.LabelGeneral_Name.Size = New System.Drawing.Size(75, 20)
            Me.LabelGeneral_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Name.TabIndex = 2
            Me.LabelGeneral_Name.Text = "Name:"
            '
            'TextBoxGeneral_Name
            '
            Me.TextBoxGeneral_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxGeneral_Name.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneral_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneral_Name.CheckSpellingOnValidate = False
            Me.TextBoxGeneral_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneral_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxGeneral_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_Name.FocusHighlightEnabled = True
            Me.TextBoxGeneral_Name.Location = New System.Drawing.Point(85, 30)
            Me.TextBoxGeneral_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_Name.Name = "TextBoxGeneral_Name"
            Me.TextBoxGeneral_Name.PreventEnterBeep = False
            Me.TextBoxGeneral_Name.SecurityEnabled = True
            Me.TextBoxGeneral_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_Name.Size = New System.Drawing.Size(335, 20)
            Me.TextBoxGeneral_Name.StartingFolderName = Nothing
            Me.TextBoxGeneral_Name.TabIndex = 3
            Me.TextBoxGeneral_Name.TabOnEnter = True
            '
            'TabControlForm_DocumentDetails
            '
            Me.TabControlForm_DocumentDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_DocumentDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlForm_DocumentDetails.CanReorderTabs = False
            Me.TabControlForm_DocumentDetails.Controls.Add(Me.TabControlPanelAlertOptionsTab_AlertOptions)
            Me.TabControlForm_DocumentDetails.Controls.Add(Me.TabControlPanelGeneralTab_General)
            Me.TabControlForm_DocumentDetails.Controls.Add(Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions)
            Me.TabControlForm_DocumentDetails.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_DocumentDetails.Name = "TabControlForm_DocumentDetails"
            Me.TabControlForm_DocumentDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_DocumentDetails.SelectedTabIndex = 0
            Me.TabControlForm_DocumentDetails.Size = New System.Drawing.Size(424, 316)
            Me.TabControlForm_DocumentDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_DocumentDetails.TabIndex = 0
            Me.TabControlForm_DocumentDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_DocumentDetails.Tabs.Add(Me.TabItemDocumentDetails_GeneralTab)
            Me.TabControlForm_DocumentDetails.Tabs.Add(Me.TabItemDocumentDetails_AlertOptionsTab)
            Me.TabControlForm_DocumentDetails.Tabs.Add(Me.TabItemDocumentDetails_AlertAssignmentOptionsTab)
            '
            'TabControlPanelGeneralTab_General
            '
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.CheckBoxGeneral_SendAlertAssignment)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.CheckBoxGeneral_SendAlert)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.TextBoxGeneral_Name)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.ComboBoxGeneral_Folder)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Name)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_DocumentLabel)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Document)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Folder)
            Me.TabControlPanelGeneralTab_General.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelGeneralTab_General.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelGeneralTab_General.Name = "TabControlPanelGeneralTab_General"
            Me.TabControlPanelGeneralTab_General.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelGeneralTab_General.Size = New System.Drawing.Size(424, 289)
            Me.TabControlPanelGeneralTab_General.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGeneralTab_General.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGeneralTab_General.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelGeneralTab_General.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelGeneralTab_General.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelGeneralTab_General.Style.GradientAngle = 90
            Me.TabControlPanelGeneralTab_General.TabIndex = 0
            Me.TabControlPanelGeneralTab_General.TabItem = Me.TabItemDocumentDetails_GeneralTab
            '
            'CheckBoxGeneral_SendAlertAssignment
            '
            Me.CheckBoxGeneral_SendAlertAssignment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGeneral_SendAlertAssignment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGeneral_SendAlertAssignment.CheckValue = 0
            Me.CheckBoxGeneral_SendAlertAssignment.CheckValueChecked = 1
            Me.CheckBoxGeneral_SendAlertAssignment.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGeneral_SendAlertAssignment.CheckValueUnchecked = 0
            Me.CheckBoxGeneral_SendAlertAssignment.ChildControls = CType(resources.GetObject("CheckBoxGeneral_SendAlertAssignment.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGeneral_SendAlertAssignment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGeneral_SendAlertAssignment.Location = New System.Drawing.Point(87, 110)
            Me.CheckBoxGeneral_SendAlertAssignment.Name = "CheckBoxGeneral_SendAlertAssignment"
            Me.CheckBoxGeneral_SendAlertAssignment.OldestSibling = Nothing
            Me.CheckBoxGeneral_SendAlertAssignment.SecurityEnabled = True
            Me.CheckBoxGeneral_SendAlertAssignment.SiblingControls = CType(resources.GetObject("CheckBoxGeneral_SendAlertAssignment.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGeneral_SendAlertAssignment.Size = New System.Drawing.Size(333, 20)
            Me.CheckBoxGeneral_SendAlertAssignment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGeneral_SendAlertAssignment.TabIndex = 7
            Me.CheckBoxGeneral_SendAlertAssignment.Text = "Send Alert Assignment"
            '
            'CheckBoxGeneral_SendAlert
            '
            Me.CheckBoxGeneral_SendAlert.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGeneral_SendAlert.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGeneral_SendAlert.CheckValue = 0
            Me.CheckBoxGeneral_SendAlert.CheckValueChecked = 1
            Me.CheckBoxGeneral_SendAlert.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGeneral_SendAlert.CheckValueUnchecked = 0
            Me.CheckBoxGeneral_SendAlert.ChildControls = CType(resources.GetObject("CheckBoxGeneral_SendAlert.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGeneral_SendAlert.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGeneral_SendAlert.Location = New System.Drawing.Point(87, 84)
            Me.CheckBoxGeneral_SendAlert.Name = "CheckBoxGeneral_SendAlert"
            Me.CheckBoxGeneral_SendAlert.OldestSibling = Nothing
            Me.CheckBoxGeneral_SendAlert.SecurityEnabled = True
            Me.CheckBoxGeneral_SendAlert.SiblingControls = CType(resources.GetObject("CheckBoxGeneral_SendAlert.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGeneral_SendAlert.Size = New System.Drawing.Size(333, 20)
            Me.CheckBoxGeneral_SendAlert.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGeneral_SendAlert.TabIndex = 6
            Me.CheckBoxGeneral_SendAlert.Text = "Send Alert"
            '
            'TabItemDocumentDetails_GeneralTab
            '
            Me.TabItemDocumentDetails_GeneralTab.AttachedControl = Me.TabControlPanelGeneralTab_General
            Me.TabItemDocumentDetails_GeneralTab.Name = "TabItemDocumentDetails_GeneralTab"
            Me.TabItemDocumentDetails_GeneralTab.Text = "General"
            '
            'TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions
            '
            Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions.Controls.Add(Me.ComboBoxAlertAssignmentOptions_AssignTo)
            Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions.Controls.Add(Me.ComboBoxAlertAssignmentOptions_State)
            Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions.Controls.Add(Me.LabelAlertAssignmentOptions_AssignTo)
            Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions.Controls.Add(Me.LabelAlertAssignmentOptions_State)
            Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions.Controls.Add(Me.LabelAlertAssignmentOptions_Template)
            Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions.Controls.Add(Me.ComboBoxAlertAssignmentOptions_Template)
            Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions.Name = "TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions"
            Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions.Size = New System.Drawing.Size(424, 289)
            Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions.Style.GradientAngle = 90
            Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions.TabIndex = 1
            Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions.TabItem = Me.TabItemDocumentDetails_AlertAssignmentOptionsTab
            '
            'ComboBoxAlertAssignmentOptions_AssignTo
            '
            Me.ComboBoxAlertAssignmentOptions_AssignTo.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxAlertAssignmentOptions_AssignTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxAlertAssignmentOptions_AssignTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxAlertAssignmentOptions_AssignTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxAlertAssignmentOptions_AssignTo.AutoFindItemInDataSource = False
            Me.ComboBoxAlertAssignmentOptions_AssignTo.AutoSelectSingleItemDatasource = False
            Me.ComboBoxAlertAssignmentOptions_AssignTo.BookmarkingEnabled = False
            Me.ComboBoxAlertAssignmentOptions_AssignTo.ClientCode = ""
            Me.ComboBoxAlertAssignmentOptions_AssignTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Employee
            Me.ComboBoxAlertAssignmentOptions_AssignTo.DisableMouseWheel = False
            Me.ComboBoxAlertAssignmentOptions_AssignTo.DisplayMember = "FullName"
            Me.ComboBoxAlertAssignmentOptions_AssignTo.DisplayName = ""
            Me.ComboBoxAlertAssignmentOptions_AssignTo.DivisionCode = ""
            Me.ComboBoxAlertAssignmentOptions_AssignTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxAlertAssignmentOptions_AssignTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxAlertAssignmentOptions_AssignTo.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxAlertAssignmentOptions_AssignTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxAlertAssignmentOptions_AssignTo.FocusHighlightEnabled = True
            Me.ComboBoxAlertAssignmentOptions_AssignTo.FormattingEnabled = True
            Me.ComboBoxAlertAssignmentOptions_AssignTo.ItemHeight = 14
            Me.ComboBoxAlertAssignmentOptions_AssignTo.Location = New System.Drawing.Point(67, 56)
            Me.ComboBoxAlertAssignmentOptions_AssignTo.Name = "ComboBoxAlertAssignmentOptions_AssignTo"
            Me.ComboBoxAlertAssignmentOptions_AssignTo.PreventEnterBeep = False
            Me.ComboBoxAlertAssignmentOptions_AssignTo.ReadOnly = False
            Me.ComboBoxAlertAssignmentOptions_AssignTo.SecurityEnabled = True
            Me.ComboBoxAlertAssignmentOptions_AssignTo.Size = New System.Drawing.Size(353, 20)
            Me.ComboBoxAlertAssignmentOptions_AssignTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxAlertAssignmentOptions_AssignTo.TabIndex = 13
            Me.ComboBoxAlertAssignmentOptions_AssignTo.ValueMember = "Code"
            Me.ComboBoxAlertAssignmentOptions_AssignTo.WatermarkText = "Select Employee"
            '
            'ComboBoxAlertAssignmentOptions_State
            '
            Me.ComboBoxAlertAssignmentOptions_State.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxAlertAssignmentOptions_State.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxAlertAssignmentOptions_State.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxAlertAssignmentOptions_State.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxAlertAssignmentOptions_State.AutoFindItemInDataSource = False
            Me.ComboBoxAlertAssignmentOptions_State.AutoSelectSingleItemDatasource = False
            Me.ComboBoxAlertAssignmentOptions_State.BookmarkingEnabled = False
            Me.ComboBoxAlertAssignmentOptions_State.ClientCode = ""
            Me.ComboBoxAlertAssignmentOptions_State.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.AlertState
            Me.ComboBoxAlertAssignmentOptions_State.DisableMouseWheel = False
            Me.ComboBoxAlertAssignmentOptions_State.DisplayMember = "Name"
            Me.ComboBoxAlertAssignmentOptions_State.DisplayName = ""
            Me.ComboBoxAlertAssignmentOptions_State.DivisionCode = ""
            Me.ComboBoxAlertAssignmentOptions_State.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxAlertAssignmentOptions_State.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxAlertAssignmentOptions_State.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxAlertAssignmentOptions_State.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxAlertAssignmentOptions_State.FocusHighlightEnabled = True
            Me.ComboBoxAlertAssignmentOptions_State.FormattingEnabled = True
            Me.ComboBoxAlertAssignmentOptions_State.ItemHeight = 14
            Me.ComboBoxAlertAssignmentOptions_State.Location = New System.Drawing.Point(67, 30)
            Me.ComboBoxAlertAssignmentOptions_State.Name = "ComboBoxAlertAssignmentOptions_State"
            Me.ComboBoxAlertAssignmentOptions_State.PreventEnterBeep = False
            Me.ComboBoxAlertAssignmentOptions_State.ReadOnly = False
            Me.ComboBoxAlertAssignmentOptions_State.SecurityEnabled = True
            Me.ComboBoxAlertAssignmentOptions_State.Size = New System.Drawing.Size(353, 20)
            Me.ComboBoxAlertAssignmentOptions_State.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxAlertAssignmentOptions_State.TabIndex = 12
            Me.ComboBoxAlertAssignmentOptions_State.ValueMember = "ID"
            Me.ComboBoxAlertAssignmentOptions_State.WatermarkText = "Select Alert State"
            '
            'LabelAlertAssignmentOptions_AssignTo
            '
            Me.LabelAlertAssignmentOptions_AssignTo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAlertAssignmentOptions_AssignTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAlertAssignmentOptions_AssignTo.Location = New System.Drawing.Point(4, 56)
            Me.LabelAlertAssignmentOptions_AssignTo.Name = "LabelAlertAssignmentOptions_AssignTo"
            Me.LabelAlertAssignmentOptions_AssignTo.Size = New System.Drawing.Size(57, 20)
            Me.LabelAlertAssignmentOptions_AssignTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAlertAssignmentOptions_AssignTo.TabIndex = 11
            Me.LabelAlertAssignmentOptions_AssignTo.Text = "Assign To:"
            '
            'LabelAlertAssignmentOptions_State
            '
            Me.LabelAlertAssignmentOptions_State.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAlertAssignmentOptions_State.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAlertAssignmentOptions_State.Location = New System.Drawing.Point(4, 30)
            Me.LabelAlertAssignmentOptions_State.Name = "LabelAlertAssignmentOptions_State"
            Me.LabelAlertAssignmentOptions_State.Size = New System.Drawing.Size(57, 20)
            Me.LabelAlertAssignmentOptions_State.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAlertAssignmentOptions_State.TabIndex = 10
            Me.LabelAlertAssignmentOptions_State.Text = "State:"
            '
            'LabelAlertAssignmentOptions_Template
            '
            Me.LabelAlertAssignmentOptions_Template.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAlertAssignmentOptions_Template.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAlertAssignmentOptions_Template.Location = New System.Drawing.Point(4, 4)
            Me.LabelAlertAssignmentOptions_Template.Name = "LabelAlertAssignmentOptions_Template"
            Me.LabelAlertAssignmentOptions_Template.Size = New System.Drawing.Size(57, 20)
            Me.LabelAlertAssignmentOptions_Template.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAlertAssignmentOptions_Template.TabIndex = 8
            Me.LabelAlertAssignmentOptions_Template.Text = "Template:"
            '
            'ComboBoxAlertAssignmentOptions_Template
            '
            Me.ComboBoxAlertAssignmentOptions_Template.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxAlertAssignmentOptions_Template.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxAlertAssignmentOptions_Template.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxAlertAssignmentOptions_Template.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxAlertAssignmentOptions_Template.AutoFindItemInDataSource = False
            Me.ComboBoxAlertAssignmentOptions_Template.AutoSelectSingleItemDatasource = False
            Me.ComboBoxAlertAssignmentOptions_Template.BookmarkingEnabled = False
            Me.ComboBoxAlertAssignmentOptions_Template.ClientCode = ""
            Me.ComboBoxAlertAssignmentOptions_Template.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.AlertAssignmentTemplate
            Me.ComboBoxAlertAssignmentOptions_Template.DisableMouseWheel = False
            Me.ComboBoxAlertAssignmentOptions_Template.DisplayMember = "Name"
            Me.ComboBoxAlertAssignmentOptions_Template.DisplayName = ""
            Me.ComboBoxAlertAssignmentOptions_Template.DivisionCode = ""
            Me.ComboBoxAlertAssignmentOptions_Template.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxAlertAssignmentOptions_Template.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxAlertAssignmentOptions_Template.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxAlertAssignmentOptions_Template.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxAlertAssignmentOptions_Template.FocusHighlightEnabled = True
            Me.ComboBoxAlertAssignmentOptions_Template.FormattingEnabled = True
            Me.ComboBoxAlertAssignmentOptions_Template.ItemHeight = 14
            Me.ComboBoxAlertAssignmentOptions_Template.Location = New System.Drawing.Point(67, 4)
            Me.ComboBoxAlertAssignmentOptions_Template.Name = "ComboBoxAlertAssignmentOptions_Template"
            Me.ComboBoxAlertAssignmentOptions_Template.PreventEnterBeep = False
            Me.ComboBoxAlertAssignmentOptions_Template.ReadOnly = False
            Me.ComboBoxAlertAssignmentOptions_Template.SecurityEnabled = True
            Me.ComboBoxAlertAssignmentOptions_Template.Size = New System.Drawing.Size(353, 20)
            Me.ComboBoxAlertAssignmentOptions_Template.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxAlertAssignmentOptions_Template.TabIndex = 9
            Me.ComboBoxAlertAssignmentOptions_Template.ValueMember = "ID"
            Me.ComboBoxAlertAssignmentOptions_Template.WatermarkText = "Please Alert Assignment Template"
            '
            'TabItemDocumentDetails_AlertAssignmentOptionsTab
            '
            Me.TabItemDocumentDetails_AlertAssignmentOptionsTab.AttachedControl = Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions
            Me.TabItemDocumentDetails_AlertAssignmentOptionsTab.Name = "TabItemDocumentDetails_AlertAssignmentOptionsTab"
            Me.TabItemDocumentDetails_AlertAssignmentOptionsTab.Text = "Alert Assignment Options"
            Me.TabItemDocumentDetails_AlertAssignmentOptionsTab.Visible = False
            '
            'TabControlPanelAlertOptionsTab_AlertOptions
            '
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Controls.Add(Me.LabelAlertOptions_SelectRecipients)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Controls.Add(Me.LabelAlertOptions_Subject)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Controls.Add(Me.TreeListControlAlertOptions_Recepients)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Controls.Add(Me.LabelAlertOptions_Priority)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Controls.Add(Me.TextBoxAlertOptions_Subject)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Controls.Add(Me.LabelAlertOptions_Category)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Controls.Add(Me.ComboBoxAlertOptions_Priority)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Controls.Add(Me.ComboBoxAlertOptions_Category)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Name = "TabControlPanelAlertOptionsTab_AlertOptions"
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Size = New System.Drawing.Size(424, 289)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.Style.GradientAngle = 90
            Me.TabControlPanelAlertOptionsTab_AlertOptions.TabIndex = 0
            Me.TabControlPanelAlertOptionsTab_AlertOptions.TabItem = Me.TabItemDocumentDetails_AlertOptionsTab
            '
            'LabelAlertOptions_SelectRecipients
            '
            Me.LabelAlertOptions_SelectRecipients.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelAlertOptions_SelectRecipients.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAlertOptions_SelectRecipients.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelAlertOptions_SelectRecipients.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelAlertOptions_SelectRecipients.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelAlertOptions_SelectRecipients.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelAlertOptions_SelectRecipients.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelAlertOptions_SelectRecipients.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelAlertOptions_SelectRecipients.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAlertOptions_SelectRecipients.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelAlertOptions_SelectRecipients.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelAlertOptions_SelectRecipients.Location = New System.Drawing.Point(4, 56)
            Me.LabelAlertOptions_SelectRecipients.Name = "LabelAlertOptions_SelectRecipients"
            Me.LabelAlertOptions_SelectRecipients.Size = New System.Drawing.Size(416, 20)
            Me.LabelAlertOptions_SelectRecipients.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAlertOptions_SelectRecipients.TabIndex = 6
            Me.LabelAlertOptions_SelectRecipients.Text = "Select Recipients"
            '
            'LabelAlertOptions_Subject
            '
            Me.LabelAlertOptions_Subject.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAlertOptions_Subject.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAlertOptions_Subject.Location = New System.Drawing.Point(4, 4)
            Me.LabelAlertOptions_Subject.Name = "LabelAlertOptions_Subject"
            Me.LabelAlertOptions_Subject.Size = New System.Drawing.Size(53, 20)
            Me.LabelAlertOptions_Subject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAlertOptions_Subject.TabIndex = 0
            Me.LabelAlertOptions_Subject.Text = "Subject:"
            '
            'TreeListControlAlertOptions_Recepients
            '
            Me.TreeListControlAlertOptions_Recepients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TreeListControlAlertOptions_Recepients.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TreeListControl.Type.[Default]
            Me.TreeListControlAlertOptions_Recepients.Location = New System.Drawing.Point(4, 82)
            Me.TreeListControlAlertOptions_Recepients.Name = "TreeListControlAlertOptions_Recepients"
            Me.TreeListControlAlertOptions_Recepients.OptionsNavigation.AutoMoveRowFocus = True
            Me.TreeListControlAlertOptions_Recepients.OptionsBehavior.Editable = False
            Me.TreeListControlAlertOptions_Recepients.OptionsNavigation.UseTabKey = True
            Me.TreeListControlAlertOptions_Recepients.Size = New System.Drawing.Size(416, 203)
            Me.TreeListControlAlertOptions_Recepients.TabIndex = 7
            '
            'LabelAlertOptions_Priority
            '
            Me.LabelAlertOptions_Priority.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAlertOptions_Priority.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAlertOptions_Priority.Location = New System.Drawing.Point(261, 30)
            Me.LabelAlertOptions_Priority.Name = "LabelAlertOptions_Priority"
            Me.LabelAlertOptions_Priority.Size = New System.Drawing.Size(44, 20)
            Me.LabelAlertOptions_Priority.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAlertOptions_Priority.TabIndex = 4
            Me.LabelAlertOptions_Priority.Text = "Priority:"
            '
            'TextBoxAlertOptions_Subject
            '
            Me.TextBoxAlertOptions_Subject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxAlertOptions_Subject.Border.Class = "TextBoxBorder"
            Me.TextBoxAlertOptions_Subject.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAlertOptions_Subject.CheckSpellingOnValidate = False
            Me.TextBoxAlertOptions_Subject.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAlertOptions_Subject.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAlertOptions_Subject.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAlertOptions_Subject.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAlertOptions_Subject.FocusHighlightEnabled = True
            Me.TextBoxAlertOptions_Subject.Location = New System.Drawing.Point(63, 4)
            Me.TextBoxAlertOptions_Subject.MaxFileSize = CType(0, Long)
            Me.TextBoxAlertOptions_Subject.Name = "TextBoxAlertOptions_Subject"
            Me.TextBoxAlertOptions_Subject.SecurityEnabled = True
            Me.TextBoxAlertOptions_Subject.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAlertOptions_Subject.Size = New System.Drawing.Size(357, 20)
            Me.TextBoxAlertOptions_Subject.StartingFolderName = Nothing
            Me.TextBoxAlertOptions_Subject.TabIndex = 1
            Me.TextBoxAlertOptions_Subject.TabOnEnter = True
            '
            'LabelAlertOptions_Category
            '
            Me.LabelAlertOptions_Category.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAlertOptions_Category.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAlertOptions_Category.Location = New System.Drawing.Point(4, 30)
            Me.LabelAlertOptions_Category.Name = "LabelAlertOptions_Category"
            Me.LabelAlertOptions_Category.Size = New System.Drawing.Size(53, 20)
            Me.LabelAlertOptions_Category.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAlertOptions_Category.TabIndex = 2
            Me.LabelAlertOptions_Category.Text = "Category:"
            '
            'ComboBoxAlertOptions_Priority
            '
            Me.ComboBoxAlertOptions_Priority.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxAlertOptions_Priority.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxAlertOptions_Priority.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxAlertOptions_Priority.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxAlertOptions_Priority.AutoFindItemInDataSource = False
            Me.ComboBoxAlertOptions_Priority.AutoSelectSingleItemDatasource = False
            Me.ComboBoxAlertOptions_Priority.BookmarkingEnabled = False
            Me.ComboBoxAlertOptions_Priority.ClientCode = ""
            Me.ComboBoxAlertOptions_Priority.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxAlertOptions_Priority.DisableMouseWheel = False
            Me.ComboBoxAlertOptions_Priority.DisplayMember = "Name"
            Me.ComboBoxAlertOptions_Priority.DisplayName = ""
            Me.ComboBoxAlertOptions_Priority.DivisionCode = ""
            Me.ComboBoxAlertOptions_Priority.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxAlertOptions_Priority.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxAlertOptions_Priority.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxAlertOptions_Priority.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxAlertOptions_Priority.FocusHighlightEnabled = True
            Me.ComboBoxAlertOptions_Priority.FormattingEnabled = True
            Me.ComboBoxAlertOptions_Priority.ItemHeight = 14
            Me.ComboBoxAlertOptions_Priority.Location = New System.Drawing.Point(311, 30)
            Me.ComboBoxAlertOptions_Priority.Name = "ComboBoxAlertOptions_Priority"
            Me.ComboBoxAlertOptions_Priority.PreventEnterBeep = False
            Me.ComboBoxAlertOptions_Priority.ReadOnly = False
            Me.ComboBoxAlertOptions_Priority.SecurityEnabled = True
            Me.ComboBoxAlertOptions_Priority.Size = New System.Drawing.Size(109, 20)
            Me.ComboBoxAlertOptions_Priority.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxAlertOptions_Priority.TabIndex = 5
            Me.ComboBoxAlertOptions_Priority.ValueMember = "Value"
            Me.ComboBoxAlertOptions_Priority.WatermarkText = "Select"
            '
            'ComboBoxAlertOptions_Category
            '
            Me.ComboBoxAlertOptions_Category.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxAlertOptions_Category.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxAlertOptions_Category.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxAlertOptions_Category.AutoFindItemInDataSource = False
            Me.ComboBoxAlertOptions_Category.AutoSelectSingleItemDatasource = False
            Me.ComboBoxAlertOptions_Category.BookmarkingEnabled = False
            Me.ComboBoxAlertOptions_Category.ClientCode = ""
            Me.ComboBoxAlertOptions_Category.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.AlertCategory
            Me.ComboBoxAlertOptions_Category.DisableMouseWheel = False
            Me.ComboBoxAlertOptions_Category.DisplayMember = "Description"
            Me.ComboBoxAlertOptions_Category.DisplayName = ""
            Me.ComboBoxAlertOptions_Category.DivisionCode = ""
            Me.ComboBoxAlertOptions_Category.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxAlertOptions_Category.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxAlertOptions_Category.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxAlertOptions_Category.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxAlertOptions_Category.FocusHighlightEnabled = True
            Me.ComboBoxAlertOptions_Category.FormattingEnabled = True
            Me.ComboBoxAlertOptions_Category.ItemHeight = 14
            Me.ComboBoxAlertOptions_Category.Location = New System.Drawing.Point(63, 30)
            Me.ComboBoxAlertOptions_Category.Name = "ComboBoxAlertOptions_Category"
            Me.ComboBoxAlertOptions_Category.PreventEnterBeep = False
            Me.ComboBoxAlertOptions_Category.ReadOnly = False
            Me.ComboBoxAlertOptions_Category.SecurityEnabled = True
            Me.ComboBoxAlertOptions_Category.Size = New System.Drawing.Size(192, 20)
            Me.ComboBoxAlertOptions_Category.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxAlertOptions_Category.TabIndex = 3
            Me.ComboBoxAlertOptions_Category.ValueMember = "ID"
            Me.ComboBoxAlertOptions_Category.WatermarkText = "Select"
            '
            'TabItemDocumentDetails_AlertOptionsTab
            '
            Me.TabItemDocumentDetails_AlertOptionsTab.AttachedControl = Me.TabControlPanelAlertOptionsTab_AlertOptions
            Me.TabItemDocumentDetails_AlertOptionsTab.Name = "TabItemDocumentDetails_AlertOptionsTab"
            Me.TabItemDocumentDetails_AlertOptionsTab.Text = "Alert Options"
            Me.TabItemDocumentDetails_AlertOptionsTab.Visible = False
            '
            'ProofHQUploadDocumentDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(448, 366)
            Me.Controls.Add(Me.TabControlForm_DocumentDetails)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Upload)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ProofHQUploadDocumentDialog"
            Me.Text = "Upload Document to Proof HQ"
            CType(Me.TabControlForm_DocumentDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_DocumentDetails.ResumeLayout(False)
            Me.TabControlPanelGeneralTab_General.ResumeLayout(False)
            Me.TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions.ResumeLayout(False)
            Me.TabControlPanelAlertOptionsTab_AlertOptions.ResumeLayout(False)
            CType(Me.TreeListControlAlertOptions_Recepients, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Upload As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelGeneral_DocumentLabel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_Document As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_Folder As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxGeneral_Folder As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelGeneral_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxGeneral_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabControlForm_DocumentDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelGeneralTab_General As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemDocumentDetails_GeneralTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelAlertOptionsTab_AlertOptions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelAlertOptions_SelectRecipients As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelAlertOptions_Subject As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TreeListControlAlertOptions_Recepients As AdvantageFramework.WinForm.Presentation.Controls.TreeListControl
        Friend WithEvents LabelAlertOptions_Priority As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxAlertOptions_Subject As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelAlertOptions_Category As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxAlertOptions_Priority As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxAlertOptions_Category As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents TabItemDocumentDetails_AlertOptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelAlertAssignmentOptionsTab_AlertAssignmentOptions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemDocumentDetails_AlertAssignmentOptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ComboBoxAlertAssignmentOptions_AssignTo As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxAlertAssignmentOptions_State As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelAlertAssignmentOptions_AssignTo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelAlertAssignmentOptions_State As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelAlertAssignmentOptions_Template As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxAlertAssignmentOptions_Template As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxGeneral_SendAlertAssignment As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxGeneral_SendAlert As AdvantageFramework.WinForm.Presentation.Controls.CheckBox

    End Class

End Namespace
