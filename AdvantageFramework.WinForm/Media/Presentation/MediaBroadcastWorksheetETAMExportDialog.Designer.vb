Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaBroadcastWorksheetETAMExportDialog
        Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetETAMExportDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.LabelForm_StartDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_Filename = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_EndDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DateEditForm_StartDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit()
            Me.DateEditForm_EndDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit()
            Me.DataGridViewForm_Stations = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TextBoxForm_OutputFolder = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelForm_OutputFolder = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxForm_Filename = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            CType(Me.DateEditForm_StartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditForm_StartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditForm_EndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditForm_EndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(227, 450)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 9
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(308, 450)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 10
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelForm_StartDate
            '
            Me.LabelForm_StartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StartDate.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_StartDate.Name = "LabelForm_StartDate"
            Me.LabelForm_StartDate.Size = New System.Drawing.Size(84, 20)
            Me.LabelForm_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StartDate.TabIndex = 0
            Me.LabelForm_StartDate.Text = "Start Date:"
            '
            'LabelForm_Filename
            '
            Me.LabelForm_Filename.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Filename.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Filename.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_Filename.Name = "LabelForm_Filename"
            Me.LabelForm_Filename.Size = New System.Drawing.Size(84, 20)
            Me.LabelForm_Filename.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Filename.TabIndex = 4
            Me.LabelForm_Filename.Text = "FileName:"
            '
            'LabelForm_EndDate
            '
            Me.LabelForm_EndDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EndDate.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_EndDate.Name = "LabelForm_EndDate"
            Me.LabelForm_EndDate.Size = New System.Drawing.Size(84, 20)
            Me.LabelForm_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EndDate.TabIndex = 2
            Me.LabelForm_EndDate.Text = "End Date:"
            '
            'DateEditForm_StartDate
            '
            Me.DateEditForm_StartDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.[Default]
            Me.DateEditForm_StartDate.DisplayName = ""
            Me.DateEditForm_StartDate.EditValue = Nothing
            Me.DateEditForm_StartDate.Location = New System.Drawing.Point(102, 12)
            Me.DateEditForm_StartDate.Name = "DateEditForm_StartDate"
            Me.DateEditForm_StartDate.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
            Me.DateEditForm_StartDate.Properties.AllowMouseWheel = False
            Me.DateEditForm_StartDate.Properties.Appearance.BackColor = System.Drawing.Color.White
            Me.DateEditForm_StartDate.Properties.Appearance.Options.UseBackColor = True
            Me.DateEditForm_StartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditForm_StartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditForm_StartDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
            Me.DateEditForm_StartDate.Properties.DisplayFormat.FormatString = "MM/dd/yyyy"
            Me.DateEditForm_StartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            Me.DateEditForm_StartDate.Properties.EditFormat.FormatString = "MM/dd/yyyy"
            Me.DateEditForm_StartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            Me.DateEditForm_StartDate.Properties.Mask.EditMask = ""
            Me.DateEditForm_StartDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
            Me.DateEditForm_StartDate.Properties.MaxValue = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateEditForm_StartDate.Properties.MinValue = New Date(1900, 1, 1, 0, 0, 0, 0)
            Me.DateEditForm_StartDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
            Me.DateEditForm_StartDate.SecurityEnabled = True
            Me.DateEditForm_StartDate.Size = New System.Drawing.Size(111, 20)
            Me.DateEditForm_StartDate.TabIndex = 1
            Me.DateEditForm_StartDate.TabOnEnter = True
            Me.DateEditForm_StartDate.Tag = "9/2/2015"
            '
            'DateEditForm_EndDate
            '
            Me.DateEditForm_EndDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.[Default]
            Me.DateEditForm_EndDate.DisplayName = ""
            Me.DateEditForm_EndDate.EditValue = Nothing
            Me.DateEditForm_EndDate.Location = New System.Drawing.Point(102, 38)
            Me.DateEditForm_EndDate.Name = "DateEditForm_EndDate"
            Me.DateEditForm_EndDate.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
            Me.DateEditForm_EndDate.Properties.AllowMouseWheel = False
            Me.DateEditForm_EndDate.Properties.Appearance.BackColor = System.Drawing.Color.White
            Me.DateEditForm_EndDate.Properties.Appearance.Options.UseBackColor = True
            Me.DateEditForm_EndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditForm_EndDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditForm_EndDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
            Me.DateEditForm_EndDate.Properties.DisplayFormat.FormatString = "MM/dd/yyyy"
            Me.DateEditForm_EndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            Me.DateEditForm_EndDate.Properties.EditFormat.FormatString = "MM/dd/yyyy"
            Me.DateEditForm_EndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            Me.DateEditForm_EndDate.Properties.Mask.EditMask = ""
            Me.DateEditForm_EndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
            Me.DateEditForm_EndDate.Properties.MaxValue = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateEditForm_EndDate.Properties.MinValue = New Date(1900, 1, 1, 0, 0, 0, 0)
            Me.DateEditForm_EndDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
            Me.DateEditForm_EndDate.SecurityEnabled = True
            Me.DateEditForm_EndDate.Size = New System.Drawing.Size(111, 20)
            Me.DateEditForm_EndDate.TabIndex = 3
            Me.DateEditForm_EndDate.TabOnEnter = True
            Me.DateEditForm_EndDate.Tag = "9/2/2015"
            '
            'DataGridViewForm_Stations
            '
            Me.DataGridViewForm_Stations.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Stations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Stations.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Stations.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Stations.ItemDescription = "Available Station(s)"
            Me.DataGridViewForm_Stations.Location = New System.Drawing.Point(12, 116)
            Me.DataGridViewForm_Stations.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_Stations.ModifyGridRowHeight = False
            Me.DataGridViewForm_Stations.MultiSelect = True
            Me.DataGridViewForm_Stations.Name = "DataGridViewForm_Stations"
            Me.DataGridViewForm_Stations.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Stations.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_Stations.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_Stations.ShowSelectDeselectAllButtons = True
            Me.DataGridViewForm_Stations.Size = New System.Drawing.Size(371, 328)
            Me.DataGridViewForm_Stations.TabIndex = 8
            Me.DataGridViewForm_Stations.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Stations.ViewCaptionHeight = -1
            '
            'TextBoxForm_OutputFolder
            '
            Me.TextBoxForm_OutputFolder.AgencyImportPath = Nothing
            Me.TextBoxForm_OutputFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_OutputFolder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_OutputFolder.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_OutputFolder.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_OutputFolder.ButtonCustom.Visible = True
            Me.TextBoxForm_OutputFolder.CheckSpellingOnValidate = False
            Me.TextBoxForm_OutputFolder.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.Folder
            Me.TextBoxForm_OutputFolder.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_OutputFolder.DisplayName = ""
            Me.TextBoxForm_OutputFolder.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_OutputFolder.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_OutputFolder.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_OutputFolder.FocusHighlightEnabled = True
            Me.TextBoxForm_OutputFolder.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_OutputFolder.Location = New System.Drawing.Point(102, 90)
            Me.TextBoxForm_OutputFolder.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_OutputFolder.Name = "TextBoxForm_OutputFolder"
            Me.TextBoxForm_OutputFolder.PreventEnterBeep = True
            Me.TextBoxForm_OutputFolder.SecurityEnabled = True
            Me.TextBoxForm_OutputFolder.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_OutputFolder.Size = New System.Drawing.Size(281, 20)
            Me.TextBoxForm_OutputFolder.StartingFolderName = Nothing
            Me.TextBoxForm_OutputFolder.TabIndex = 7
            Me.TextBoxForm_OutputFolder.TabOnEnter = True
            '
            'LabelForm_OutputFolder
            '
            Me.LabelForm_OutputFolder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_OutputFolder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_OutputFolder.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_OutputFolder.Name = "LabelForm_OutputFolder"
            Me.LabelForm_OutputFolder.Size = New System.Drawing.Size(84, 20)
            Me.LabelForm_OutputFolder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_OutputFolder.TabIndex = 6
            Me.LabelForm_OutputFolder.Text = "Output Folder:"
            '
            'TextBoxForm_Filename
            '
            Me.TextBoxForm_Filename.AgencyImportPath = Nothing
            Me.TextBoxForm_Filename.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_Filename.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Filename.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Filename.CheckSpellingOnValidate = False
            Me.TextBoxForm_Filename.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Filename.DisplayName = ""
            Me.TextBoxForm_Filename.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Filename.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Filename.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Filename.FocusHighlightEnabled = True
            Me.TextBoxForm_Filename.Location = New System.Drawing.Point(102, 64)
            Me.TextBoxForm_Filename.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Filename.Name = "TextBoxForm_Filename"
            Me.TextBoxForm_Filename.PreventEnterBeep = True
            Me.TextBoxForm_Filename.SecurityEnabled = True
            Me.TextBoxForm_Filename.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Filename.Size = New System.Drawing.Size(281, 20)
            Me.TextBoxForm_Filename.StartingFolderName = Nothing
            Me.TextBoxForm_Filename.TabIndex = 5
            Me.TextBoxForm_Filename.TabOnEnter = True
            '
            'MediaBroadcastWorksheetETAMExportDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(395, 482)
            Me.Controls.Add(Me.TextBoxForm_Filename)
            Me.Controls.Add(Me.TextBoxForm_OutputFolder)
            Me.Controls.Add(Me.LabelForm_OutputFolder)
            Me.Controls.Add(Me.DataGridViewForm_Stations)
            Me.Controls.Add(Me.DateEditForm_EndDate)
            Me.Controls.Add(Me.DateEditForm_StartDate)
            Me.Controls.Add(Me.LabelForm_EndDate)
            Me.Controls.Add(Me.LabelForm_Filename)
            Me.Controls.Add(Me.LabelForm_StartDate)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetETAMExportDialog"
            Me.Text = "eTAM Export Criteria"
            CType(Me.DateEditForm_StartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditForm_StartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditForm_EndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditForm_EndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents LabelForm_StartDate As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_Filename As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_EndDate As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DateEditForm_StartDate As WinForm.MVC.Presentation.Controls.DateEdit
        Friend WithEvents DateEditForm_EndDate As WinForm.MVC.Presentation.Controls.DateEdit
        Friend WithEvents DataGridViewForm_Stations As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TextBoxForm_OutputFolder As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_OutputFolder As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Filename As WinForm.MVC.Presentation.Controls.TextBox
    End Class

End Namespace
