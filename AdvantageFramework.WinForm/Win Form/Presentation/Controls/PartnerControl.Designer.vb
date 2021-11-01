Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PartnerControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PartnerControl))
            Me.TableLayoutPanelForm_Table = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelTable_RightColumn = New System.Windows.Forms.Panel()
            Me.GroupBoxRightColumn_Area = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelArea_Region = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelArea_Market = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxRightColumn_Contact = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxContact_Email = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelContact_Email = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxContact_FaxExt = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelContact_FaxExt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxContact_Fax = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxContact_PhoneExt = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelContact_PhoneExt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxContact_Phone = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelContact_Fax = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelContact_Phone = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelTable_LeftColumn = New System.Windows.Forms.Panel()
            Me.AddressControlLeftColumn_Address = New AdvantageFramework.WinForm.Presentation.Controls.AddressControl()
            Me.NumericInputForm_PercentPartner = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.GroupBoxForm_Comment = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxComment_Comment = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.CheckBoxForm_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_Percent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelControl_Control = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.SearchableComboBoxArea_Market = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxArea_Region = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.TableLayoutPanelForm_Table.SuspendLayout()
            Me.PanelTable_RightColumn.SuspendLayout()
            CType(Me.GroupBoxRightColumn_Area, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxRightColumn_Area.SuspendLayout()
            CType(Me.GroupBoxRightColumn_Contact, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxRightColumn_Contact.SuspendLayout()
            Me.PanelTable_LeftColumn.SuspendLayout()
            CType(Me.NumericInputForm_PercentPartner.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxForm_Comment, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_Comment.SuspendLayout()
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_Control.SuspendLayout()
            CType(Me.SearchableComboBoxArea_Market.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxArea_Region.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TableLayoutPanelForm_Table
            '
            Me.TableLayoutPanelForm_Table.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelForm_Table.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanelForm_Table.ColumnCount = 2
            Me.TableLayoutPanelForm_Table.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelForm_Table.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelForm_Table.Controls.Add(Me.PanelTable_RightColumn, 1, 0)
            Me.TableLayoutPanelForm_Table.Controls.Add(Me.PanelTable_LeftColumn, 0, 0)
            Me.TableLayoutPanelForm_Table.Location = New System.Drawing.Point(0, 53)
            Me.TableLayoutPanelForm_Table.Name = "TableLayoutPanelForm_Table"
            Me.TableLayoutPanelForm_Table.RowCount = 1
            Me.TableLayoutPanelForm_Table.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelForm_Table.Size = New System.Drawing.Size(718, 181)
            Me.TableLayoutPanelForm_Table.TabIndex = 7
            '
            'PanelTable_RightColumn
            '
            Me.PanelTable_RightColumn.Controls.Add(Me.GroupBoxRightColumn_Area)
            Me.PanelTable_RightColumn.Controls.Add(Me.GroupBoxRightColumn_Contact)
            Me.PanelTable_RightColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelTable_RightColumn.Location = New System.Drawing.Point(359, 0)
            Me.PanelTable_RightColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelTable_RightColumn.Name = "PanelTable_RightColumn"
            Me.PanelTable_RightColumn.Size = New System.Drawing.Size(359, 181)
            Me.PanelTable_RightColumn.TabIndex = 1
            '
            'GroupBoxRightColumn_Area
            '
            Me.GroupBoxRightColumn_Area.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxRightColumn_Area.Controls.Add(Me.SearchableComboBoxArea_Region)
            Me.GroupBoxRightColumn_Area.Controls.Add(Me.SearchableComboBoxArea_Market)
            Me.GroupBoxRightColumn_Area.Controls.Add(Me.LabelArea_Region)
            Me.GroupBoxRightColumn_Area.Controls.Add(Me.LabelArea_Market)
            Me.GroupBoxRightColumn_Area.Location = New System.Drawing.Point(3, 106)
            Me.GroupBoxRightColumn_Area.Name = "GroupBoxRightColumn_Area"
            Me.GroupBoxRightColumn_Area.Size = New System.Drawing.Size(356, 75)
            Me.GroupBoxRightColumn_Area.TabIndex = 1
            Me.GroupBoxRightColumn_Area.Text = "Area"
            '
            'LabelArea_Region
            '
            Me.LabelArea_Region.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelArea_Region.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelArea_Region.Location = New System.Drawing.Point(6, 50)
            Me.LabelArea_Region.Name = "LabelArea_Region"
            Me.LabelArea_Region.Size = New System.Drawing.Size(50, 20)
            Me.LabelArea_Region.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelArea_Region.TabIndex = 2
            Me.LabelArea_Region.Text = "Region:"
            '
            'LabelArea_Market
            '
            Me.LabelArea_Market.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelArea_Market.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelArea_Market.Location = New System.Drawing.Point(6, 25)
            Me.LabelArea_Market.Name = "LabelArea_Market"
            Me.LabelArea_Market.Size = New System.Drawing.Size(50, 20)
            Me.LabelArea_Market.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelArea_Market.TabIndex = 0
            Me.LabelArea_Market.Text = "Market:"
            '
            'GroupBoxRightColumn_Contact
            '
            Me.GroupBoxRightColumn_Contact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxRightColumn_Contact.Controls.Add(Me.TextBoxContact_Email)
            Me.GroupBoxRightColumn_Contact.Controls.Add(Me.LabelContact_Email)
            Me.GroupBoxRightColumn_Contact.Controls.Add(Me.TextBoxContact_FaxExt)
            Me.GroupBoxRightColumn_Contact.Controls.Add(Me.LabelContact_FaxExt)
            Me.GroupBoxRightColumn_Contact.Controls.Add(Me.TextBoxContact_Fax)
            Me.GroupBoxRightColumn_Contact.Controls.Add(Me.TextBoxContact_PhoneExt)
            Me.GroupBoxRightColumn_Contact.Controls.Add(Me.LabelContact_PhoneExt)
            Me.GroupBoxRightColumn_Contact.Controls.Add(Me.TextBoxContact_Phone)
            Me.GroupBoxRightColumn_Contact.Controls.Add(Me.LabelContact_Fax)
            Me.GroupBoxRightColumn_Contact.Controls.Add(Me.LabelContact_Phone)
            Me.GroupBoxRightColumn_Contact.Location = New System.Drawing.Point(3, 0)
            Me.GroupBoxRightColumn_Contact.Name = "GroupBoxRightColumn_Contact"
            Me.GroupBoxRightColumn_Contact.Size = New System.Drawing.Size(356, 100)
            Me.GroupBoxRightColumn_Contact.TabIndex = 0
            Me.GroupBoxRightColumn_Contact.Text = "Contact Information"
            '
            'TextBoxContact_Email
            '
            Me.TextBoxContact_Email.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxContact_Email.Border.Class = "TextBoxBorder"
            Me.TextBoxContact_Email.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxContact_Email.CheckSpellingOnValidate = False
            Me.TextBoxContact_Email.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Email
            Me.TextBoxContact_Email.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxContact_Email.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxContact_Email.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxContact_Email.FocusHighlightEnabled = True
            Me.TextBoxContact_Email.Location = New System.Drawing.Point(62, 75)
            Me.TextBoxContact_Email.MaxFileSize = CType(0, Long)
            Me.TextBoxContact_Email.Name = "TextBoxContact_Email"
            Me.TextBoxContact_Email.SecurityEnabled = True
            Me.TextBoxContact_Email.ShowSpellCheckCompleteMessage = True
            Me.TextBoxContact_Email.Size = New System.Drawing.Size(289, 21)
            Me.TextBoxContact_Email.StartingFolderName = Nothing
            Me.TextBoxContact_Email.TabIndex = 9
            Me.TextBoxContact_Email.TabOnEnter = True
            '
            'LabelContact_Email
            '
            Me.LabelContact_Email.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContact_Email.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContact_Email.Location = New System.Drawing.Point(6, 75)
            Me.LabelContact_Email.Name = "LabelContact_Email"
            Me.LabelContact_Email.Size = New System.Drawing.Size(50, 20)
            Me.LabelContact_Email.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContact_Email.TabIndex = 8
            Me.LabelContact_Email.Text = "Email:"
            '
            'TextBoxContact_FaxExt
            '
            Me.TextBoxContact_FaxExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxContact_FaxExt.Border.Class = "TextBoxBorder"
            Me.TextBoxContact_FaxExt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxContact_FaxExt.CheckSpellingOnValidate = False
            Me.TextBoxContact_FaxExt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxContact_FaxExt.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxContact_FaxExt.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxContact_FaxExt.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxContact_FaxExt.FocusHighlightEnabled = True
            Me.TextBoxContact_FaxExt.Location = New System.Drawing.Point(289, 50)
            Me.TextBoxContact_FaxExt.MaxFileSize = CType(0, Long)
            Me.TextBoxContact_FaxExt.Name = "TextBoxContact_FaxExt"
            Me.TextBoxContact_FaxExt.SecurityEnabled = True
            Me.TextBoxContact_FaxExt.ShowSpellCheckCompleteMessage = True
            Me.TextBoxContact_FaxExt.Size = New System.Drawing.Size(62, 21)
            Me.TextBoxContact_FaxExt.StartingFolderName = Nothing
            Me.TextBoxContact_FaxExt.TabIndex = 7
            Me.TextBoxContact_FaxExt.TabOnEnter = True
            '
            'LabelContact_FaxExt
            '
            Me.LabelContact_FaxExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelContact_FaxExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContact_FaxExt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContact_FaxExt.Location = New System.Drawing.Point(253, 50)
            Me.LabelContact_FaxExt.Name = "LabelContact_FaxExt"
            Me.LabelContact_FaxExt.Size = New System.Drawing.Size(30, 20)
            Me.LabelContact_FaxExt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContact_FaxExt.TabIndex = 6
            Me.LabelContact_FaxExt.Text = "Ext:"
            '
            'TextBoxContact_Fax
            '
            Me.TextBoxContact_Fax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxContact_Fax.Border.Class = "TextBoxBorder"
            Me.TextBoxContact_Fax.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxContact_Fax.CheckSpellingOnValidate = False
            Me.TextBoxContact_Fax.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxContact_Fax.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxContact_Fax.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxContact_Fax.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxContact_Fax.FocusHighlightEnabled = True
            Me.TextBoxContact_Fax.Location = New System.Drawing.Point(62, 50)
            Me.TextBoxContact_Fax.MaxFileSize = CType(0, Long)
            Me.TextBoxContact_Fax.Name = "TextBoxContact_Fax"
            Me.TextBoxContact_Fax.SecurityEnabled = True
            Me.TextBoxContact_Fax.ShowSpellCheckCompleteMessage = True
            Me.TextBoxContact_Fax.Size = New System.Drawing.Size(185, 21)
            Me.TextBoxContact_Fax.StartingFolderName = Nothing
            Me.TextBoxContact_Fax.TabIndex = 5
            Me.TextBoxContact_Fax.TabOnEnter = True
            '
            'TextBoxContact_PhoneExt
            '
            Me.TextBoxContact_PhoneExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxContact_PhoneExt.Border.Class = "TextBoxBorder"
            Me.TextBoxContact_PhoneExt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxContact_PhoneExt.CheckSpellingOnValidate = False
            Me.TextBoxContact_PhoneExt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxContact_PhoneExt.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxContact_PhoneExt.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxContact_PhoneExt.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxContact_PhoneExt.FocusHighlightEnabled = True
            Me.TextBoxContact_PhoneExt.Location = New System.Drawing.Point(289, 25)
            Me.TextBoxContact_PhoneExt.MaxFileSize = CType(0, Long)
            Me.TextBoxContact_PhoneExt.Name = "TextBoxContact_PhoneExt"
            Me.TextBoxContact_PhoneExt.SecurityEnabled = True
            Me.TextBoxContact_PhoneExt.ShowSpellCheckCompleteMessage = True
            Me.TextBoxContact_PhoneExt.Size = New System.Drawing.Size(62, 21)
            Me.TextBoxContact_PhoneExt.StartingFolderName = Nothing
            Me.TextBoxContact_PhoneExt.TabIndex = 3
            Me.TextBoxContact_PhoneExt.TabOnEnter = True
            '
            'LabelContact_PhoneExt
            '
            Me.LabelContact_PhoneExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelContact_PhoneExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContact_PhoneExt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContact_PhoneExt.Location = New System.Drawing.Point(253, 25)
            Me.LabelContact_PhoneExt.Name = "LabelContact_PhoneExt"
            Me.LabelContact_PhoneExt.Size = New System.Drawing.Size(30, 20)
            Me.LabelContact_PhoneExt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContact_PhoneExt.TabIndex = 2
            Me.LabelContact_PhoneExt.Text = "Ext:"
            '
            'TextBoxContact_Phone
            '
            Me.TextBoxContact_Phone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxContact_Phone.Border.Class = "TextBoxBorder"
            Me.TextBoxContact_Phone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxContact_Phone.CheckSpellingOnValidate = False
            Me.TextBoxContact_Phone.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxContact_Phone.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxContact_Phone.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxContact_Phone.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxContact_Phone.FocusHighlightEnabled = True
            Me.TextBoxContact_Phone.Location = New System.Drawing.Point(62, 25)
            Me.TextBoxContact_Phone.MaxFileSize = CType(0, Long)
            Me.TextBoxContact_Phone.Name = "TextBoxContact_Phone"
            Me.TextBoxContact_Phone.SecurityEnabled = True
            Me.TextBoxContact_Phone.ShowSpellCheckCompleteMessage = True
            Me.TextBoxContact_Phone.Size = New System.Drawing.Size(185, 21)
            Me.TextBoxContact_Phone.StartingFolderName = Nothing
            Me.TextBoxContact_Phone.TabIndex = 1
            Me.TextBoxContact_Phone.TabOnEnter = True
            '
            'LabelContact_Fax
            '
            Me.LabelContact_Fax.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContact_Fax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContact_Fax.Location = New System.Drawing.Point(6, 50)
            Me.LabelContact_Fax.Name = "LabelContact_Fax"
            Me.LabelContact_Fax.Size = New System.Drawing.Size(50, 20)
            Me.LabelContact_Fax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContact_Fax.TabIndex = 4
            Me.LabelContact_Fax.Text = "Fax:"
            '
            'LabelContact_Phone
            '
            Me.LabelContact_Phone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContact_Phone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContact_Phone.Location = New System.Drawing.Point(6, 25)
            Me.LabelContact_Phone.Name = "LabelContact_Phone"
            Me.LabelContact_Phone.Size = New System.Drawing.Size(50, 20)
            Me.LabelContact_Phone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContact_Phone.TabIndex = 0
            Me.LabelContact_Phone.Text = "Phone:"
            '
            'PanelTable_LeftColumn
            '
            Me.PanelTable_LeftColumn.Controls.Add(Me.AddressControlLeftColumn_Address)
            Me.PanelTable_LeftColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelTable_LeftColumn.Location = New System.Drawing.Point(0, 0)
            Me.PanelTable_LeftColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelTable_LeftColumn.Name = "PanelTable_LeftColumn"
            Me.PanelTable_LeftColumn.Size = New System.Drawing.Size(359, 181)
            Me.PanelTable_LeftColumn.TabIndex = 0
            '
            'AddressControlLeftColumn_Address
            '
            Me.AddressControlLeftColumn_Address.Address = Nothing
            Me.AddressControlLeftColumn_Address.Address2 = Nothing
            Me.AddressControlLeftColumn_Address.Address3 = Nothing
            Me.AddressControlLeftColumn_Address.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AddressControlLeftColumn_Address.City = Nothing
            Me.AddressControlLeftColumn_Address.Country = Nothing
            Me.AddressControlLeftColumn_Address.County = Nothing
            Me.AddressControlLeftColumn_Address.DisableCountry = False
            Me.AddressControlLeftColumn_Address.DisableCounty = False
            Me.AddressControlLeftColumn_Address.Location = New System.Drawing.Point(0, 0)
            Me.AddressControlLeftColumn_Address.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.AddressControlLeftColumn_Address.Name = "AddressControlLeftColumn_Address"
            Me.AddressControlLeftColumn_Address.ReadOnly = False
            Me.AddressControlLeftColumn_Address.ShowCountry = True
            Me.AddressControlLeftColumn_Address.ShowCounty = True
            Me.AddressControlLeftColumn_Address.Size = New System.Drawing.Size(357, 181)
            Me.AddressControlLeftColumn_Address.State = Nothing
            Me.AddressControlLeftColumn_Address.TabIndex = 0
            Me.AddressControlLeftColumn_Address.Title = "Address"
            Me.AddressControlLeftColumn_Address.Zip = Nothing
            '
            'NumericInputForm_PercentPartner
            '
            Me.NumericInputForm_PercentPartner.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_PercentPartner.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputForm_PercentPartner.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_PercentPartner.EnterMoveNextControl = True
            Me.NumericInputForm_PercentPartner.Location = New System.Drawing.Point(56, 26)
            Me.NumericInputForm_PercentPartner.Name = "NumericInputForm_PercentPartner"
            Me.NumericInputForm_PercentPartner.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputForm_PercentPartner.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_PercentPartner.Properties.EditFormat.FormatString = "f"
            Me.NumericInputForm_PercentPartner.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_PercentPartner.Properties.Mask.EditMask = "f"
            Me.NumericInputForm_PercentPartner.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_PercentPartner.SecurityEnabled = True
            Me.NumericInputForm_PercentPartner.Size = New System.Drawing.Size(67, 20)
            Me.NumericInputForm_PercentPartner.TabIndex = 5
            '
            'GroupBoxForm_Comment
            '
            Me.GroupBoxForm_Comment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxForm_Comment.Controls.Add(Me.TextBoxComment_Comment)
            Me.GroupBoxForm_Comment.Location = New System.Drawing.Point(0, 239)
            Me.GroupBoxForm_Comment.Name = "GroupBoxForm_Comment"
            Me.GroupBoxForm_Comment.Size = New System.Drawing.Size(718, 150)
            Me.GroupBoxForm_Comment.TabIndex = 8
            Me.GroupBoxForm_Comment.Text = "Comment"
            '
            'TextBoxComment_Comment
            '
            Me.TextBoxComment_Comment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxComment_Comment.Border.Class = "TextBoxBorder"
            Me.TextBoxComment_Comment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxComment_Comment.CheckSpellingOnValidate = False
            Me.TextBoxComment_Comment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxComment_Comment.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxComment_Comment.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxComment_Comment.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxComment_Comment.FocusHighlightEnabled = True
            Me.TextBoxComment_Comment.Location = New System.Drawing.Point(5, 25)
            Me.TextBoxComment_Comment.MaxFileSize = CType(0, Long)
            Me.TextBoxComment_Comment.Multiline = True
            Me.TextBoxComment_Comment.Name = "TextBoxComment_Comment"
            Me.TextBoxComment_Comment.SecurityEnabled = True
            Me.TextBoxComment_Comment.ShowSpellCheckCompleteMessage = True
            Me.TextBoxComment_Comment.Size = New System.Drawing.Size(708, 120)
            Me.TextBoxComment_Comment.StartingFolderName = Nothing
            Me.TextBoxComment_Comment.TabIndex = 0
            Me.TextBoxComment_Comment.TabOnEnter = True
            '
            'CheckBoxForm_Inactive
            '
            Me.CheckBoxForm_Inactive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Inactive.CheckValue = 0
            Me.CheckBoxForm_Inactive.CheckValueChecked = 1
            Me.CheckBoxForm_Inactive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxForm_Inactive.ChildControls = CType(resources.GetObject("CheckBoxForm_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Inactive.Location = New System.Drawing.Point(129, 26)
            Me.CheckBoxForm_Inactive.Name = "CheckBoxForm_Inactive"
            Me.CheckBoxForm_Inactive.OldestSibling = Nothing
            Me.CheckBoxForm_Inactive.SecurityEnabled = True
            Me.CheckBoxForm_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxForm_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Inactive.Size = New System.Drawing.Size(589, 20)
            Me.CheckBoxForm_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Inactive.TabIndex = 6
            Me.CheckBoxForm_Inactive.TabOnEnter = True
            Me.CheckBoxForm_Inactive.Text = "Inactive"
            '
            'LabelForm_Percent
            '
            Me.LabelForm_Percent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Percent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Percent.Location = New System.Drawing.Point(0, 26)
            Me.LabelForm_Percent.Name = "LabelForm_Percent"
            Me.LabelForm_Percent.Size = New System.Drawing.Size(50, 20)
            Me.LabelForm_Percent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Percent.TabIndex = 4
            Me.LabelForm_Percent.Text = "Percent:"
            '
            'TextBoxForm_Name
            '
            Me.TextBoxForm_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_Name.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Name.CheckSpellingOnValidate = False
            Me.TextBoxForm_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Name.FocusHighlightEnabled = True
            Me.TextBoxForm_Name.Location = New System.Drawing.Point(177, 0)
            Me.TextBoxForm_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Name.Name = "TextBoxForm_Name"
            Me.TextBoxForm_Name.SecurityEnabled = True
            Me.TextBoxForm_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Name.Size = New System.Drawing.Size(541, 21)
            Me.TextBoxForm_Name.StartingFolderName = Nothing
            Me.TextBoxForm_Name.TabIndex = 3
            Me.TextBoxForm_Name.TabOnEnter = True
            '
            'TextBoxForm_Code
            '
            '
            '
            '
            Me.TextBoxForm_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Code.CheckSpellingOnValidate = False
            Me.TextBoxForm_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Code.FocusHighlightEnabled = True
            Me.TextBoxForm_Code.Location = New System.Drawing.Point(56, 0)
            Me.TextBoxForm_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Code.Name = "TextBoxForm_Code"
            Me.TextBoxForm_Code.SecurityEnabled = True
            Me.TextBoxForm_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Code.Size = New System.Drawing.Size(67, 21)
            Me.TextBoxForm_Code.StartingFolderName = Nothing
            Me.TextBoxForm_Code.TabIndex = 1
            Me.TextBoxForm_Code.TabOnEnter = True
            '
            'LabelForm_Name
            '
            Me.LabelForm_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Name.Location = New System.Drawing.Point(129, 0)
            Me.LabelForm_Name.Name = "LabelForm_Name"
            Me.LabelForm_Name.Size = New System.Drawing.Size(42, 20)
            Me.LabelForm_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Name.TabIndex = 2
            Me.LabelForm_Name.Text = "Name:"
            '
            'LabelForm_Code
            '
            Me.LabelForm_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Code.Location = New System.Drawing.Point(0, 0)
            Me.LabelForm_Code.Name = "LabelForm_Code"
            Me.LabelForm_Code.Size = New System.Drawing.Size(50, 20)
            Me.LabelForm_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Code.TabIndex = 0
            Me.LabelForm_Code.Text = "Code:"
            '
            'PanelControl_Control
            '
            Me.PanelControl_Control.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_Control.Controls.Add(Me.TableLayoutPanelForm_Table)
            Me.PanelControl_Control.Controls.Add(Me.NumericInputForm_PercentPartner)
            Me.PanelControl_Control.Controls.Add(Me.LabelForm_Code)
            Me.PanelControl_Control.Controls.Add(Me.GroupBoxForm_Comment)
            Me.PanelControl_Control.Controls.Add(Me.LabelForm_Name)
            Me.PanelControl_Control.Controls.Add(Me.CheckBoxForm_Inactive)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxForm_Code)
            Me.PanelControl_Control.Controls.Add(Me.LabelForm_Percent)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxForm_Name)
            Me.PanelControl_Control.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_Control.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_Control.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me.PanelControl_Control.Name = "PanelControl_Control"
            Me.PanelControl_Control.Size = New System.Drawing.Size(718, 389)
            Me.PanelControl_Control.TabIndex = 45
            '
            'SearchableComboBoxArea_Market
            '
            Me.SearchableComboBoxArea_Market.ActiveFilterString = ""
            Me.SearchableComboBoxArea_Market.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxArea_Market.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxArea_Market.AutoFillMode = False
            Me.SearchableComboBoxArea_Market.BookmarkingEnabled = False
            Me.SearchableComboBoxArea_Market.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Market
            Me.SearchableComboBoxArea_Market.DataSource = Nothing
            Me.SearchableComboBoxArea_Market.DisableMouseWheel = False
            Me.SearchableComboBoxArea_Market.DisplayName = ""
            Me.SearchableComboBoxArea_Market.EnterMoveNextControl = True
            Me.SearchableComboBoxArea_Market.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxArea_Market.Location = New System.Drawing.Point(62, 25)
            Me.SearchableComboBoxArea_Market.Name = "SearchableComboBoxArea_Market"
            Me.SearchableComboBoxArea_Market.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxArea_Market.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxArea_Market.Properties.NullText = "Select Market"
            Me.SearchableComboBoxArea_Market.Properties.ValueMember = "Code"
            Me.SearchableComboBoxArea_Market.Properties.View = Me.GridView1
            Me.SearchableComboBoxArea_Market.SecurityEnabled = True
            Me.SearchableComboBoxArea_Market.SelectedValue = Nothing
            Me.SearchableComboBoxArea_Market.Size = New System.Drawing.Size(289, 20)
            Me.SearchableComboBoxArea_Market.TabIndex = 1
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
            'SearchableComboBoxArea_Region
            '
            Me.SearchableComboBoxArea_Region.ActiveFilterString = ""
            Me.SearchableComboBoxArea_Region.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxArea_Region.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxArea_Region.AutoFillMode = False
            Me.SearchableComboBoxArea_Region.BookmarkingEnabled = False
            Me.SearchableComboBoxArea_Region.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.PrintSpecRegion
            Me.SearchableComboBoxArea_Region.DataSource = Nothing
            Me.SearchableComboBoxArea_Region.DisableMouseWheel = False
            Me.SearchableComboBoxArea_Region.DisplayName = ""
            Me.SearchableComboBoxArea_Region.EnterMoveNextControl = True
            Me.SearchableComboBoxArea_Region.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxArea_Region.Location = New System.Drawing.Point(62, 50)
            Me.SearchableComboBoxArea_Region.Name = "SearchableComboBoxArea_Region"
            Me.SearchableComboBoxArea_Region.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxArea_Region.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxArea_Region.Properties.NullText = "Select Region"
            Me.SearchableComboBoxArea_Region.Properties.ValueMember = "Code"
            Me.SearchableComboBoxArea_Region.Properties.View = Me.GridView2
            Me.SearchableComboBoxArea_Region.SecurityEnabled = True
            Me.SearchableComboBoxArea_Region.SelectedValue = Nothing
            Me.SearchableComboBoxArea_Region.Size = New System.Drawing.Size(289, 20)
            Me.SearchableComboBoxArea_Region.TabIndex = 3
            '
            'GridView2
            '
            Me.GridView2.AFActiveFilterString = ""
            Me.GridView2.AllowExtraItemsInGridLookupEdits = True
            Me.GridView2.AutoFilterLookupColumns = False
            Me.GridView2.AutoloadRepositoryDatasource = True
            Me.GridView2.DataSourceClearing = False
            Me.GridView2.EnableDisabledRows = False
            Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView2.Name = "GridView2"
            Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView2.OptionsView.ShowGroupPanel = False
            Me.GridView2.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView2.RunStandardValidation = True
            '
            'PartnerControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelControl_Control)
            Me.Name = "PartnerControl"
            Me.Size = New System.Drawing.Size(718, 389)
            Me.TableLayoutPanelForm_Table.ResumeLayout(False)
            Me.PanelTable_RightColumn.ResumeLayout(False)
            CType(Me.GroupBoxRightColumn_Area, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxRightColumn_Area.ResumeLayout(False)
            CType(Me.GroupBoxRightColumn_Contact, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxRightColumn_Contact.ResumeLayout(False)
            Me.PanelTable_LeftColumn.ResumeLayout(False)
            CType(Me.NumericInputForm_PercentPartner.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxForm_Comment, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_Comment.ResumeLayout(False)
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_Control.ResumeLayout(False)
            CType(Me.SearchableComboBoxArea_Market.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxArea_Region.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TableLayoutPanelForm_Table As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelTable_RightColumn As System.Windows.Forms.Panel
        Friend WithEvents PanelTable_LeftColumn As System.Windows.Forms.Panel
        Friend WithEvents AddressControlLeftColumn_Address As AdvantageFramework.WinForm.Presentation.Controls.AddressControl
        Friend WithEvents GroupBoxRightColumn_Area As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelArea_Region As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelArea_Market As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxRightColumn_Contact As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxContact_Email As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelContact_Email As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxContact_FaxExt As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelContact_FaxExt As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxContact_Fax As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxContact_PhoneExt As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelContact_PhoneExt As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxContact_Phone As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelContact_Fax As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelContact_Phone As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Percent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TextBoxForm_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxForm_Comment As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxComment_Comment As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents NumericInputForm_PercentPartner As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents PanelControl_Control As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents SearchableComboBoxArea_Market As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxArea_Region As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As AdvantageFramework.WinForm.Presentation.Controls.GridView

    End Class

End Namespace
