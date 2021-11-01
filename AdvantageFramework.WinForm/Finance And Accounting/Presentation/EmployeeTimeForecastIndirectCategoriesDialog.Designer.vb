Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeTimeForecastIndirectCategoriesDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeTimeForecastIndirectCategoriesDialog))
            Me.ButtonForm_AddIndirectCategories = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_RemoveIndirectCategories = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_AddAllIndirectCategories = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_RemoveAllIndirectCategories = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_AvailableIndirectCategories = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewForm_CurrentIndirectCategories = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'ButtonForm_AddIndirectCategories
            '
            Me.ButtonForm_AddIndirectCategories.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_AddIndirectCategories.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_AddIndirectCategories.Location = New System.Drawing.Point(218, 12)
            Me.ButtonForm_AddIndirectCategories.Name = "ButtonForm_AddIndirectCategories"
            Me.ButtonForm_AddIndirectCategories.SecurityEnabled = True
            Me.ButtonForm_AddIndirectCategories.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_AddIndirectCategories.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_AddIndirectCategories.TabIndex = 1
            Me.ButtonForm_AddIndirectCategories.Text = ">"
            '
            'ButtonForm_RemoveIndirectCategories
            '
            Me.ButtonForm_RemoveIndirectCategories.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_RemoveIndirectCategories.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_RemoveIndirectCategories.Location = New System.Drawing.Point(218, 64)
            Me.ButtonForm_RemoveIndirectCategories.Name = "ButtonForm_RemoveIndirectCategories"
            Me.ButtonForm_RemoveIndirectCategories.SecurityEnabled = True
            Me.ButtonForm_RemoveIndirectCategories.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_RemoveIndirectCategories.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_RemoveIndirectCategories.TabIndex = 3
            Me.ButtonForm_RemoveIndirectCategories.Text = "<"
            '
            'ButtonForm_AddAllIndirectCategories
            '
            Me.ButtonForm_AddAllIndirectCategories.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_AddAllIndirectCategories.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_AddAllIndirectCategories.Location = New System.Drawing.Point(218, 38)
            Me.ButtonForm_AddAllIndirectCategories.Name = "ButtonForm_AddAllIndirectCategories"
            Me.ButtonForm_AddAllIndirectCategories.SecurityEnabled = True
            Me.ButtonForm_AddAllIndirectCategories.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_AddAllIndirectCategories.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_AddAllIndirectCategories.TabIndex = 2
            Me.ButtonForm_AddAllIndirectCategories.Text = ">>"
            '
            'ButtonForm_RemoveAllIndirectCategories
            '
            Me.ButtonForm_RemoveAllIndirectCategories.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_RemoveAllIndirectCategories.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_RemoveAllIndirectCategories.Location = New System.Drawing.Point(218, 90)
            Me.ButtonForm_RemoveAllIndirectCategories.Name = "ButtonForm_RemoveAllIndirectCategories"
            Me.ButtonForm_RemoveAllIndirectCategories.SecurityEnabled = True
            Me.ButtonForm_RemoveAllIndirectCategories.Size = New System.Drawing.Size(75, 22)
            Me.ButtonForm_RemoveAllIndirectCategories.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_RemoveAllIndirectCategories.TabIndex = 4
            Me.ButtonForm_RemoveAllIndirectCategories.Text = "<<"
            '
            'DataGridViewForm_AvailableIndirectCategories
            '
            Me.DataGridViewForm_AvailableIndirectCategories.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_AvailableIndirectCategories.ItemDescription = "Available Indirect Category(ies)"
            Me.DataGridViewForm_AvailableIndirectCategories.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_AvailableIndirectCategories.MultiSelect = True
            Me.DataGridViewForm_AvailableIndirectCategories.Name = "DataGridViewForm_AvailableIndirectCategories"
            Me.DataGridViewForm_AvailableIndirectCategories.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_AvailableIndirectCategories.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_AvailableIndirectCategories.Size = New System.Drawing.Size(200, 344)
            Me.DataGridViewForm_AvailableIndirectCategories.TabIndex = 0
            Me.DataGridViewForm_AvailableIndirectCategories.UseEmbeddedNavigator = False
            Me.DataGridViewForm_AvailableIndirectCategories.ViewCaptionHeight = -1
            '
            'DataGridViewForm_CurrentIndirectCategories
            '
            Me.DataGridViewForm_CurrentIndirectCategories.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_CurrentIndirectCategories.DataSource = Nothing
            Me.DataGridViewForm_CurrentIndirectCategories.ItemDescription = "Current Indirect Category(ies)"
            Me.DataGridViewForm_CurrentIndirectCategories.Location = New System.Drawing.Point(299, 12)
            Me.DataGridViewForm_CurrentIndirectCategories.MultiSelect = True
            Me.DataGridViewForm_CurrentIndirectCategories.Name = "DataGridViewForm_CurrentIndirectCategories"
            Me.DataGridViewForm_CurrentIndirectCategories.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_CurrentIndirectCategories.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_CurrentIndirectCategories.Size = New System.Drawing.Size(200, 344)
            Me.DataGridViewForm_CurrentIndirectCategories.TabIndex = 5
            Me.DataGridViewForm_CurrentIndirectCategories.UseEmbeddedNavigator = False
            Me.DataGridViewForm_CurrentIndirectCategories.ViewCaptionHeight = -1
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(424, 362)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 6
            Me.ButtonForm_OK.Text = "OK"
            '
            'EmployeeTimeForecastIndirectCategoriesDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(511, 394)
            Me.Controls.Add(Me.DataGridViewForm_AvailableIndirectCategories)
            Me.Controls.Add(Me.DataGridViewForm_CurrentIndirectCategories)
            Me.Controls.Add(Me.ButtonForm_AddIndirectCategories)
            Me.Controls.Add(Me.ButtonForm_RemoveIndirectCategories)
            Me.Controls.Add(Me.ButtonForm_AddAllIndirectCategories)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_RemoveAllIndirectCategories)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmployeeTimeForecastIndirectCategoriesDialog"
            Me.Text = "Add Employee Time Forecast Indirect Categories"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_AddIndirectCategories As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_RemoveIndirectCategories As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_AddAllIndirectCategories As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_RemoveAllIndirectCategories As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_AvailableIndirectCategories As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewForm_CurrentIndirectCategories As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
    End Class

End Namespace