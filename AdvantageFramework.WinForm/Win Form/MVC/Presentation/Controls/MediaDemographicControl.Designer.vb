Namespace WinForm.MVC.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaDemographicControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaDemographicControl))
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.CheckBoxControl_System = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.ComboBoxControl_AgeTo = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.ComboBoxControl_AgeFrom = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.GroupBoxControl_Gender = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxGender_WorkingWomen = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxGender_Children = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxGender_Women = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxGender_Boys = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxGender_Men = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxGender_Girls = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.LabelControl_AgeTo = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelControl_AgeFrom = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxControl_Code = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.TextBoxControl_Description = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelControl_Description = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DataGridViewControl_DemoDetails = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelControl_Code = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.CheckBoxControl_Inactive = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.GroupBoxControl_UseFor = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxUseFor_County = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxUseFor_Market = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.GroupBoxControl_Gender, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxControl_Gender.SuspendLayout()
            CType(Me.GroupBoxControl_UseFor, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxControl_UseFor.SuspendLayout()
            Me.SuspendLayout()
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_RightSection.Controls.Add(Me.GroupBoxControl_UseFor)
            Me.PanelForm_RightSection.Controls.Add(Me.CheckBoxControl_System)
            Me.PanelForm_RightSection.Controls.Add(Me.ComboBoxControl_AgeTo)
            Me.PanelForm_RightSection.Controls.Add(Me.ComboBoxControl_AgeFrom)
            Me.PanelForm_RightSection.Controls.Add(Me.GroupBoxControl_Gender)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_AgeTo)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_AgeFrom)
            Me.PanelForm_RightSection.Controls.Add(Me.TextBoxControl_Code)
            Me.PanelForm_RightSection.Controls.Add(Me.TextBoxControl_Description)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_Description)
            Me.PanelForm_RightSection.Controls.Add(Me.DataGridViewControl_DemoDetails)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_Code)
            Me.PanelForm_RightSection.Controls.Add(Me.CheckBoxControl_Inactive)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(525, 506)
            Me.PanelForm_RightSection.TabIndex = 0
            '
            'CheckBoxControl_System
            '
            Me.CheckBoxControl_System.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxControl_System.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_System.CheckValue = 0
            Me.CheckBoxControl_System.CheckValueChecked = 1
            Me.CheckBoxControl_System.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_System.CheckValueUnchecked = 0
            Me.CheckBoxControl_System.ChildControls = CType(resources.GetObject("CheckBoxControl_System.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_System.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_System.Location = New System.Drawing.Point(388, 1)
            Me.CheckBoxControl_System.Name = "CheckBoxControl_System"
            Me.CheckBoxControl_System.OldestSibling = Nothing
            Me.CheckBoxControl_System.SecurityEnabled = True
            Me.CheckBoxControl_System.SiblingControls = CType(resources.GetObject("CheckBoxControl_System.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_System.Size = New System.Drawing.Size(63, 20)
            Me.CheckBoxControl_System.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_System.TabIndex = 2
            Me.CheckBoxControl_System.TabOnEnter = True
            Me.CheckBoxControl_System.Text = "System"
            Me.CheckBoxControl_System.Visible = False
            '
            'ComboBoxControl_AgeTo
            '
            Me.ComboBoxControl_AgeTo.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxControl_AgeTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxControl_AgeTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxControl_AgeTo.AutoFindItemInDataSource = False
            Me.ComboBoxControl_AgeTo.AutoSelectSingleItemDatasource = False
            Me.ComboBoxControl_AgeTo.BookmarkingEnabled = False
            Me.ComboBoxControl_AgeTo.DisableMouseWheel = True
            Me.ComboBoxControl_AgeTo.DisplayMember = "Display"
            Me.ComboBoxControl_AgeTo.DisplayName = ""
            Me.ComboBoxControl_AgeTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxControl_AgeTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxControl_AgeTo.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxControl_AgeTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxControl_AgeTo.FocusHighlightEnabled = True
            Me.ComboBoxControl_AgeTo.FormattingEnabled = True
            Me.ComboBoxControl_AgeTo.ItemHeight = 16
            Me.ComboBoxControl_AgeTo.Location = New System.Drawing.Point(293, 139)
            Me.ComboBoxControl_AgeTo.Name = "ComboBoxControl_AgeTo"
            Me.ComboBoxControl_AgeTo.ReadOnly = False
            Me.ComboBoxControl_AgeTo.SecurityEnabled = True
            Me.ComboBoxControl_AgeTo.Size = New System.Drawing.Size(112, 22)
            Me.ComboBoxControl_AgeTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxControl_AgeTo.TabIndex = 11
            Me.ComboBoxControl_AgeTo.TabOnEnter = True
            Me.ComboBoxControl_AgeTo.ValueMember = "Value"
            Me.ComboBoxControl_AgeTo.WatermarkText = "Select"
            '
            'ComboBoxControl_AgeFrom
            '
            Me.ComboBoxControl_AgeFrom.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxControl_AgeFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxControl_AgeFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxControl_AgeFrom.AutoFindItemInDataSource = False
            Me.ComboBoxControl_AgeFrom.AutoSelectSingleItemDatasource = False
            Me.ComboBoxControl_AgeFrom.BookmarkingEnabled = False
            Me.ComboBoxControl_AgeFrom.DisableMouseWheel = True
            Me.ComboBoxControl_AgeFrom.DisplayMember = "Display"
            Me.ComboBoxControl_AgeFrom.DisplayName = ""
            Me.ComboBoxControl_AgeFrom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxControl_AgeFrom.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxControl_AgeFrom.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxControl_AgeFrom.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxControl_AgeFrom.FocusHighlightEnabled = True
            Me.ComboBoxControl_AgeFrom.FormattingEnabled = True
            Me.ComboBoxControl_AgeFrom.ItemHeight = 16
            Me.ComboBoxControl_AgeFrom.Location = New System.Drawing.Point(88, 139)
            Me.ComboBoxControl_AgeFrom.Name = "ComboBoxControl_AgeFrom"
            Me.ComboBoxControl_AgeFrom.ReadOnly = False
            Me.ComboBoxControl_AgeFrom.SecurityEnabled = True
            Me.ComboBoxControl_AgeFrom.Size = New System.Drawing.Size(112, 22)
            Me.ComboBoxControl_AgeFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxControl_AgeFrom.TabIndex = 9
            Me.ComboBoxControl_AgeFrom.TabOnEnter = True
            Me.ComboBoxControl_AgeFrom.ValueMember = "Value"
            Me.ComboBoxControl_AgeFrom.WatermarkText = "Select"
            '
            'GroupBoxControl_Gender
            '
            Me.GroupBoxControl_Gender.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxControl_Gender.Controls.Add(Me.CheckBoxGender_WorkingWomen)
            Me.GroupBoxControl_Gender.Controls.Add(Me.CheckBoxGender_Children)
            Me.GroupBoxControl_Gender.Controls.Add(Me.CheckBoxGender_Women)
            Me.GroupBoxControl_Gender.Controls.Add(Me.CheckBoxGender_Boys)
            Me.GroupBoxControl_Gender.Controls.Add(Me.CheckBoxGender_Men)
            Me.GroupBoxControl_Gender.Controls.Add(Me.CheckBoxGender_Girls)
            Me.GroupBoxControl_Gender.Location = New System.Drawing.Point(0, 53)
            Me.GroupBoxControl_Gender.Name = "GroupBoxControl_Gender"
            Me.GroupBoxControl_Gender.Size = New System.Drawing.Size(525, 80)
            Me.GroupBoxControl_Gender.TabIndex = 6
            Me.GroupBoxControl_Gender.Text = "Gender"
            '
            'CheckBoxGender_WorkingWomen
            '
            Me.CheckBoxGender_WorkingWomen.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGender_WorkingWomen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGender_WorkingWomen.CheckValue = 0
            Me.CheckBoxGender_WorkingWomen.CheckValueChecked = 1
            Me.CheckBoxGender_WorkingWomen.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGender_WorkingWomen.CheckValueUnchecked = 0
            Me.CheckBoxGender_WorkingWomen.ChildControls = Nothing
            Me.CheckBoxGender_WorkingWomen.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGender_WorkingWomen.Location = New System.Drawing.Point(5, 50)
            Me.CheckBoxGender_WorkingWomen.Name = "CheckBoxGender_WorkingWomen"
            Me.CheckBoxGender_WorkingWomen.OldestSibling = Nothing
            Me.CheckBoxGender_WorkingWomen.SecurityEnabled = True
            Me.CheckBoxGender_WorkingWomen.SiblingControls = Nothing
            Me.CheckBoxGender_WorkingWomen.Size = New System.Drawing.Size(125, 20)
            Me.CheckBoxGender_WorkingWomen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGender_WorkingWomen.TabIndex = 3
            Me.CheckBoxGender_WorkingWomen.TabOnEnter = True
            Me.CheckBoxGender_WorkingWomen.Text = "Working Women"
            '
            'CheckBoxGender_Children
            '
            Me.CheckBoxGender_Children.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGender_Children.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGender_Children.CheckValue = 0
            Me.CheckBoxGender_Children.CheckValueChecked = 1
            Me.CheckBoxGender_Children.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGender_Children.CheckValueUnchecked = 0
            Me.CheckBoxGender_Children.ChildControls = Nothing
            Me.CheckBoxGender_Children.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGender_Children.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxGender_Children.Name = "CheckBoxGender_Children"
            Me.CheckBoxGender_Children.OldestSibling = Nothing
            Me.CheckBoxGender_Children.SecurityEnabled = True
            Me.CheckBoxGender_Children.SiblingControls = Nothing
            Me.CheckBoxGender_Children.Size = New System.Drawing.Size(125, 20)
            Me.CheckBoxGender_Children.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGender_Children.TabIndex = 0
            Me.CheckBoxGender_Children.TabOnEnter = True
            Me.CheckBoxGender_Children.Text = "Children"
            '
            'CheckBoxGender_Women
            '
            Me.CheckBoxGender_Women.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGender_Women.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGender_Women.CheckValue = 0
            Me.CheckBoxGender_Women.CheckValueChecked = 1
            Me.CheckBoxGender_Women.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGender_Women.CheckValueUnchecked = 0
            Me.CheckBoxGender_Women.ChildControls = Nothing
            Me.CheckBoxGender_Women.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGender_Women.Location = New System.Drawing.Point(267, 50)
            Me.CheckBoxGender_Women.Name = "CheckBoxGender_Women"
            Me.CheckBoxGender_Women.OldestSibling = Nothing
            Me.CheckBoxGender_Women.SecurityEnabled = True
            Me.CheckBoxGender_Women.SiblingControls = Nothing
            Me.CheckBoxGender_Women.Size = New System.Drawing.Size(125, 20)
            Me.CheckBoxGender_Women.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGender_Women.TabIndex = 5
            Me.CheckBoxGender_Women.TabOnEnter = True
            Me.CheckBoxGender_Women.Text = "Women"
            '
            'CheckBoxGender_Boys
            '
            Me.CheckBoxGender_Boys.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGender_Boys.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGender_Boys.CheckValue = 0
            Me.CheckBoxGender_Boys.CheckValueChecked = 1
            Me.CheckBoxGender_Boys.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGender_Boys.CheckValueUnchecked = 0
            Me.CheckBoxGender_Boys.ChildControls = Nothing
            Me.CheckBoxGender_Boys.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGender_Boys.Location = New System.Drawing.Point(136, 24)
            Me.CheckBoxGender_Boys.Name = "CheckBoxGender_Boys"
            Me.CheckBoxGender_Boys.OldestSibling = Nothing
            Me.CheckBoxGender_Boys.SecurityEnabled = True
            Me.CheckBoxGender_Boys.SiblingControls = Nothing
            Me.CheckBoxGender_Boys.Size = New System.Drawing.Size(125, 20)
            Me.CheckBoxGender_Boys.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGender_Boys.TabIndex = 1
            Me.CheckBoxGender_Boys.TabOnEnter = True
            Me.CheckBoxGender_Boys.Text = "Boys"
            '
            'CheckBoxGender_Men
            '
            Me.CheckBoxGender_Men.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGender_Men.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGender_Men.CheckValue = 0
            Me.CheckBoxGender_Men.CheckValueChecked = 1
            Me.CheckBoxGender_Men.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGender_Men.CheckValueUnchecked = 0
            Me.CheckBoxGender_Men.ChildControls = Nothing
            Me.CheckBoxGender_Men.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGender_Men.Location = New System.Drawing.Point(267, 24)
            Me.CheckBoxGender_Men.Name = "CheckBoxGender_Men"
            Me.CheckBoxGender_Men.OldestSibling = Nothing
            Me.CheckBoxGender_Men.SecurityEnabled = True
            Me.CheckBoxGender_Men.SiblingControls = Nothing
            Me.CheckBoxGender_Men.Size = New System.Drawing.Size(125, 20)
            Me.CheckBoxGender_Men.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGender_Men.TabIndex = 2
            Me.CheckBoxGender_Men.TabOnEnter = True
            Me.CheckBoxGender_Men.Text = "Men"
            '
            'CheckBoxGender_Girls
            '
            Me.CheckBoxGender_Girls.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGender_Girls.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGender_Girls.CheckValue = 0
            Me.CheckBoxGender_Girls.CheckValueChecked = 1
            Me.CheckBoxGender_Girls.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGender_Girls.CheckValueUnchecked = 0
            Me.CheckBoxGender_Girls.ChildControls = Nothing
            Me.CheckBoxGender_Girls.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGender_Girls.Location = New System.Drawing.Point(136, 50)
            Me.CheckBoxGender_Girls.Name = "CheckBoxGender_Girls"
            Me.CheckBoxGender_Girls.OldestSibling = Nothing
            Me.CheckBoxGender_Girls.SecurityEnabled = True
            Me.CheckBoxGender_Girls.SiblingControls = Nothing
            Me.CheckBoxGender_Girls.Size = New System.Drawing.Size(125, 20)
            Me.CheckBoxGender_Girls.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGender_Girls.TabIndex = 4
            Me.CheckBoxGender_Girls.TabOnEnter = True
            Me.CheckBoxGender_Girls.Text = "Girls"
            '
            'LabelControl_AgeTo
            '
            Me.LabelControl_AgeTo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_AgeTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_AgeTo.Location = New System.Drawing.Point(206, 139)
            Me.LabelControl_AgeTo.Name = "LabelControl_AgeTo"
            Me.LabelControl_AgeTo.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_AgeTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_AgeTo.TabIndex = 10
            Me.LabelControl_AgeTo.Text = "Age To:"
            '
            'LabelControl_AgeFrom
            '
            Me.LabelControl_AgeFrom.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_AgeFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_AgeFrom.Location = New System.Drawing.Point(1, 139)
            Me.LabelControl_AgeFrom.Name = "LabelControl_AgeFrom"
            Me.LabelControl_AgeFrom.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_AgeFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_AgeFrom.TabIndex = 8
            Me.LabelControl_AgeFrom.Text = "Age From:"
            '
            'TextBoxControl_Code
            '
            Me.TextBoxControl_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Code.CheckSpellingOnValidate = False
            Me.TextBoxControl_Code.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Code.FocusHighlightEnabled = True
            Me.TextBoxControl_Code.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_Code.Location = New System.Drawing.Point(87, 1)
            Me.TextBoxControl_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Code.Name = "TextBoxControl_Code"
            Me.TextBoxControl_Code.SecurityEnabled = True
            Me.TextBoxControl_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Code.Size = New System.Drawing.Size(77, 21)
            Me.TextBoxControl_Code.StartingFolderName = Nothing
            Me.TextBoxControl_Code.TabIndex = 1
            Me.TextBoxControl_Code.TabOnEnter = True
            '
            'TextBoxControl_Description
            '
            Me.TextBoxControl_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxControl_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Description.CheckSpellingOnValidate = False
            Me.TextBoxControl_Description.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Description.FocusHighlightEnabled = True
            Me.TextBoxControl_Description.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_Description.Location = New System.Drawing.Point(87, 26)
            Me.TextBoxControl_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Description.Name = "TextBoxControl_Description"
            Me.TextBoxControl_Description.SecurityEnabled = True
            Me.TextBoxControl_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Description.Size = New System.Drawing.Size(438, 21)
            Me.TextBoxControl_Description.StartingFolderName = Nothing
            Me.TextBoxControl_Description.TabIndex = 5
            Me.TextBoxControl_Description.TabOnEnter = True
            '
            'LabelControl_Description
            '
            Me.LabelControl_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Description.Location = New System.Drawing.Point(1, 26)
            Me.LabelControl_Description.Name = "LabelControl_Description"
            Me.LabelControl_Description.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Description.TabIndex = 4
            Me.LabelControl_Description.Text = "Description:"
            '
            'DataGridViewControl_DemoDetails
            '
            Me.DataGridViewControl_DemoDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_DemoDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewControl_DemoDetails.AutoUpdateViewCaption = True
            Me.DataGridViewControl_DemoDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_DemoDetails.ItemDescription = "Nielsen Demographic(s)"
            Me.DataGridViewControl_DemoDetails.Location = New System.Drawing.Point(0, 168)
            Me.DataGridViewControl_DemoDetails.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewControl_DemoDetails.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewControl_DemoDetails.ModifyGridRowHeight = False
            Me.DataGridViewControl_DemoDetails.MultiSelect = True
            Me.DataGridViewControl_DemoDetails.Name = "DataGridViewControl_DemoDetails"
            Me.DataGridViewControl_DemoDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewControl_DemoDetails.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewControl_DemoDetails.ShowRowSelectionIfHidden = True
            Me.DataGridViewControl_DemoDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewControl_DemoDetails.Size = New System.Drawing.Size(525, 338)
            Me.DataGridViewControl_DemoDetails.TabIndex = 12
            Me.DataGridViewControl_DemoDetails.UseEmbeddedNavigator = False
            Me.DataGridViewControl_DemoDetails.ViewCaptionHeight = -1
            '
            'LabelControl_Code
            '
            Me.LabelControl_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Code.Location = New System.Drawing.Point(1, 1)
            Me.LabelControl_Code.Name = "LabelControl_Code"
            Me.LabelControl_Code.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Code.TabIndex = 0
            Me.LabelControl_Code.Text = "Code:"
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
            Me.CheckBoxControl_Inactive.Location = New System.Drawing.Point(457, 1)
            Me.CheckBoxControl_Inactive.Name = "CheckBoxControl_Inactive"
            Me.CheckBoxControl_Inactive.OldestSibling = Nothing
            Me.CheckBoxControl_Inactive.SecurityEnabled = True
            Me.CheckBoxControl_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxControl_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_Inactive.Size = New System.Drawing.Size(63, 20)
            Me.CheckBoxControl_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_Inactive.TabIndex = 3
            Me.CheckBoxControl_Inactive.TabOnEnter = True
            Me.CheckBoxControl_Inactive.Text = "Inactive"
            '
            'GroupBoxControl_UseFor
            '
            Me.GroupBoxControl_UseFor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxControl_UseFor.Controls.Add(Me.CheckBoxUseFor_County)
            Me.GroupBoxControl_UseFor.Controls.Add(Me.CheckBoxUseFor_Market)
            Me.GroupBoxControl_UseFor.Location = New System.Drawing.Point(402, 53)
            Me.GroupBoxControl_UseFor.Name = "GroupBoxControl_UseFor"
            Me.GroupBoxControl_UseFor.Size = New System.Drawing.Size(123, 80)
            Me.GroupBoxControl_UseFor.TabIndex = 7
            Me.GroupBoxControl_UseFor.Text = "Use For"
            '
            'CheckBoxUseFor_County
            '
            Me.CheckBoxUseFor_County.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxUseFor_County.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxUseFor_County.CheckValue = 0
            Me.CheckBoxUseFor_County.CheckValueChecked = 1
            Me.CheckBoxUseFor_County.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxUseFor_County.CheckValueUnchecked = 0
            Me.CheckBoxUseFor_County.ChildControls = Nothing
            Me.CheckBoxUseFor_County.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxUseFor_County.Location = New System.Drawing.Point(5, 50)
            Me.CheckBoxUseFor_County.Name = "CheckBoxUseFor_County"
            Me.CheckBoxUseFor_County.OldestSibling = Nothing
            Me.CheckBoxUseFor_County.SecurityEnabled = True
            Me.CheckBoxUseFor_County.SiblingControls = Nothing
            Me.CheckBoxUseFor_County.Size = New System.Drawing.Size(71, 20)
            Me.CheckBoxUseFor_County.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxUseFor_County.TabIndex = 1
            Me.CheckBoxUseFor_County.TabOnEnter = True
            Me.CheckBoxUseFor_County.Text = "County"
            '
            'CheckBoxUseFor_Market
            '
            Me.CheckBoxUseFor_Market.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxUseFor_Market.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxUseFor_Market.CheckValue = 0
            Me.CheckBoxUseFor_Market.CheckValueChecked = 1
            Me.CheckBoxUseFor_Market.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxUseFor_Market.CheckValueUnchecked = 0
            Me.CheckBoxUseFor_Market.ChildControls = Nothing
            Me.CheckBoxUseFor_Market.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxUseFor_Market.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxUseFor_Market.Name = "CheckBoxUseFor_Market"
            Me.CheckBoxUseFor_Market.OldestSibling = Nothing
            Me.CheckBoxUseFor_Market.SecurityEnabled = True
            Me.CheckBoxUseFor_Market.SiblingControls = Nothing
            Me.CheckBoxUseFor_Market.Size = New System.Drawing.Size(71, 20)
            Me.CheckBoxUseFor_Market.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxUseFor_Market.TabIndex = 0
            Me.CheckBoxUseFor_Market.TabOnEnter = True
            Me.CheckBoxUseFor_Market.Text = "Market"
            '
            'MediaDemographicControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Name = "MediaDemographicControl"
            Me.Size = New System.Drawing.Size(525, 506)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.GroupBoxControl_Gender, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxControl_Gender.ResumeLayout(False)
            CType(Me.GroupBoxControl_UseFor, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxControl_UseFor.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelForm_RightSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents GroupBoxControl_Gender As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxGender_Children As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxGender_Women As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxGender_Boys As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxGender_Men As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxGender_Girls As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents LabelControl_AgeTo As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelControl_AgeFrom As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxControl_Code As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents TextBoxControl_Description As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_Description As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DataGridViewControl_DemoDetails As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents LabelControl_Code As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents CheckBoxControl_Inactive As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents ComboBoxControl_AgeFrom As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxControl_AgeTo As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxControl_System As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxGender_WorkingWomen As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxControl_UseFor As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxUseFor_County As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxUseFor_Market As WinForm.MVC.Presentation.Controls.CheckBox
    End Class

End Namespace
