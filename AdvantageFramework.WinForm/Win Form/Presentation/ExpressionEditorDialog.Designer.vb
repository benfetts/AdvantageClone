Namespace WinForm.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ExpressionEditorDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExpressionEditorDialog))
            Me.DataGridViewForm_Columns = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TextBoxForm_Expression = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ButtonForm_Plus = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Minus = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Multiply = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Divide = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_OpenParenthesis = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_CloseParenthesis = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_IFF = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_Statement = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.SuspendLayout()
            '
            'DataGridViewForm_Columns
            '
            Me.DataGridViewForm_Columns.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Columns.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Columns.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Columns.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Columns.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Columns.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_Columns.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Columns.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Columns.ItemDescription = "Column(s)"
            Me.DataGridViewForm_Columns.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_Columns.MultiSelect = True
            Me.DataGridViewForm_Columns.Name = "DataGridViewForm_Columns"
            Me.DataGridViewForm_Columns.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Columns.RunStandardValidation = True
            Me.DataGridViewForm_Columns.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Columns.Size = New System.Drawing.Size(147, 204)
            Me.DataGridViewForm_Columns.TabIndex = 0
            Me.DataGridViewForm_Columns.TabStop = False
            Me.DataGridViewForm_Columns.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Columns.ViewCaptionHeight = -1
            '
            'TextBoxForm_Expression
            '
            Me.TextBoxForm_Expression.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_Expression.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Expression.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Expression.CheckSpellingOnValidate = False
            Me.TextBoxForm_Expression.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Expression.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Expression.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Expression.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Expression.FocusHighlightEnabled = True
            Me.TextBoxForm_Expression.HideSelection = False
            Me.TextBoxForm_Expression.Location = New System.Drawing.Point(165, 38)
            Me.TextBoxForm_Expression.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Expression.Multiline = True
            Me.TextBoxForm_Expression.Name = "TextBoxForm_Expression"
            Me.TextBoxForm_Expression.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Expression.Size = New System.Drawing.Size(394, 178)
            Me.TextBoxForm_Expression.TabIndex = 9
            Me.TextBoxForm_Expression.TabOnEnter = True
            '
            'ButtonForm_Plus
            '
            Me.ButtonForm_Plus.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Plus.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Plus.FocusCuesEnabled = False
            Me.ButtonForm_Plus.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ButtonForm_Plus.Location = New System.Drawing.Point(165, 12)
            Me.ButtonForm_Plus.Name = "ButtonForm_Plus"
            Me.ButtonForm_Plus.SecurityEnabled = True
            Me.ButtonForm_Plus.Size = New System.Drawing.Size(25, 20)
            Me.ButtonForm_Plus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Plus.TabIndex = 1
            Me.ButtonForm_Plus.TabStop = False
            Me.ButtonForm_Plus.Text = "+"
            '
            'ButtonForm_Minus
            '
            Me.ButtonForm_Minus.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Minus.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Minus.FocusCuesEnabled = False
            Me.ButtonForm_Minus.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ButtonForm_Minus.Location = New System.Drawing.Point(196, 12)
            Me.ButtonForm_Minus.Name = "ButtonForm_Minus"
            Me.ButtonForm_Minus.SecurityEnabled = True
            Me.ButtonForm_Minus.Size = New System.Drawing.Size(25, 20)
            Me.ButtonForm_Minus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Minus.TabIndex = 2
            Me.ButtonForm_Minus.TabStop = False
            Me.ButtonForm_Minus.Text = "-"
            '
            'ButtonForm_Multiply
            '
            Me.ButtonForm_Multiply.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Multiply.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Multiply.FocusCuesEnabled = False
            Me.ButtonForm_Multiply.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ButtonForm_Multiply.Location = New System.Drawing.Point(227, 12)
            Me.ButtonForm_Multiply.Name = "ButtonForm_Multiply"
            Me.ButtonForm_Multiply.SecurityEnabled = True
            Me.ButtonForm_Multiply.Size = New System.Drawing.Size(25, 20)
            Me.ButtonForm_Multiply.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Multiply.TabIndex = 3
            Me.ButtonForm_Multiply.TabStop = False
            Me.ButtonForm_Multiply.Text = "X"
            '
            'ButtonForm_Divide
            '
            Me.ButtonForm_Divide.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Divide.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Divide.FocusCuesEnabled = False
            Me.ButtonForm_Divide.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ButtonForm_Divide.Location = New System.Drawing.Point(351, 12)
            Me.ButtonForm_Divide.Name = "ButtonForm_Divide"
            Me.ButtonForm_Divide.SecurityEnabled = True
            Me.ButtonForm_Divide.Size = New System.Drawing.Size(25, 20)
            Me.ButtonForm_Divide.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Divide.TabIndex = 7
            Me.ButtonForm_Divide.TabStop = False
            Me.ButtonForm_Divide.Text = "/"
            Me.ButtonForm_Divide.Visible = False
            '
            'ButtonForm_OpenParenthesis
            '
            Me.ButtonForm_OpenParenthesis.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OpenParenthesis.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OpenParenthesis.FocusCuesEnabled = False
            Me.ButtonForm_OpenParenthesis.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ButtonForm_OpenParenthesis.Location = New System.Drawing.Point(258, 12)
            Me.ButtonForm_OpenParenthesis.Name = "ButtonForm_OpenParenthesis"
            Me.ButtonForm_OpenParenthesis.SecurityEnabled = True
            Me.ButtonForm_OpenParenthesis.Size = New System.Drawing.Size(25, 20)
            Me.ButtonForm_OpenParenthesis.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OpenParenthesis.TabIndex = 4
            Me.ButtonForm_OpenParenthesis.TabStop = False
            Me.ButtonForm_OpenParenthesis.Text = "("
            '
            'ButtonForm_CloseParenthesis
            '
            Me.ButtonForm_CloseParenthesis.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_CloseParenthesis.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_CloseParenthesis.FocusCuesEnabled = False
            Me.ButtonForm_CloseParenthesis.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ButtonForm_CloseParenthesis.Location = New System.Drawing.Point(289, 12)
            Me.ButtonForm_CloseParenthesis.Name = "ButtonForm_CloseParenthesis"
            Me.ButtonForm_CloseParenthesis.SecurityEnabled = True
            Me.ButtonForm_CloseParenthesis.Size = New System.Drawing.Size(25, 20)
            Me.ButtonForm_CloseParenthesis.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_CloseParenthesis.TabIndex = 5
            Me.ButtonForm_CloseParenthesis.TabStop = False
            Me.ButtonForm_CloseParenthesis.Text = ")"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.FocusCuesEnabled = False
            Me.ButtonForm_OK.Location = New System.Drawing.Point(403, 222)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 10
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_IFF
            '
            Me.ButtonForm_IFF.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_IFF.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_IFF.FocusCuesEnabled = False
            Me.ButtonForm_IFF.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ButtonForm_IFF.Location = New System.Drawing.Point(320, 12)
            Me.ButtonForm_IFF.Name = "ButtonForm_IFF"
            Me.ButtonForm_IFF.SecurityEnabled = True
            Me.ButtonForm_IFF.Size = New System.Drawing.Size(25, 20)
            Me.ButtonForm_IFF.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_IFF.TabIndex = 6
            Me.ButtonForm_IFF.TabStop = False
            Me.ButtonForm_IFF.Text = "IIF"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.FocusCuesEnabled = False
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(484, 222)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 11
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'DataGridViewForm_Statement
            '
            Me.DataGridViewForm_Statement.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Statement.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Statement.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Statement.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Statement.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewForm_Statement.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Statement.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Statement.ItemDescription = "Item(s)"
            Me.DataGridViewForm_Statement.Location = New System.Drawing.Point(499, 12)
            Me.DataGridViewForm_Statement.MultiSelect = True
            Me.DataGridViewForm_Statement.Name = "DataGridViewForm_Statement"
            Me.DataGridViewForm_Statement.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Statement.RunStandardValidation = True
            Me.DataGridViewForm_Statement.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Statement.Size = New System.Drawing.Size(60, 20)
            Me.DataGridViewForm_Statement.TabIndex = 8
            Me.DataGridViewForm_Statement.TabStop = False
            Me.DataGridViewForm_Statement.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Statement.ViewCaptionHeight = -1
            Me.DataGridViewForm_Statement.Visible = False
            '
            'ExpressionEditorDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(571, 254)
            Me.Controls.Add(Me.DataGridViewForm_Statement)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_IFF)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_CloseParenthesis)
            Me.Controls.Add(Me.ButtonForm_OpenParenthesis)
            Me.Controls.Add(Me.ButtonForm_Divide)
            Me.Controls.Add(Me.ButtonForm_Multiply)
            Me.Controls.Add(Me.ButtonForm_Minus)
            Me.Controls.Add(Me.ButtonForm_Plus)
            Me.Controls.Add(Me.TextBoxForm_Expression)
            Me.Controls.Add(Me.DataGridViewForm_Columns)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ExpressionEditorDialog"
            Me.Text = "Expression Editor"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_Columns As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TextBoxForm_Expression As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ButtonForm_Plus As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Minus As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Multiply As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Divide As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_OpenParenthesis As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_CloseParenthesis As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_IFF As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_Statement As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    End Class

End Namespace