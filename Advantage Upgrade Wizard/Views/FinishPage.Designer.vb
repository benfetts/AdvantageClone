Imports Microsoft.VisualBasic
Imports System
Partial Public Class FinishPage
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Component Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.layoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.finishButton = New DevExpress.XtraEditors.SimpleButton()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.emptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.layoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.emptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.layoutControl1.SuspendLayout()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.emptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.emptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'labelControl1
        '
        Me.labelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelControl1.Appearance.Options.UseFont = True
        Me.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.labelControl1.Location = New System.Drawing.Point(269, 12)
        Me.labelControl1.Name = "labelControl1"
        Me.labelControl1.Padding = New System.Windows.Forms.Padding(30, 10, 10, 10)
        Me.labelControl1.Size = New System.Drawing.Size(840, 50)
        Me.labelControl1.StyleController = Me.layoutControl1
        Me.labelControl1.TabIndex = 5
        Me.labelControl1.Text = "Setup was completed successfully."
        '
        'layoutControl1
        '
        Me.layoutControl1.AllowCustomization = False
        Me.layoutControl1.Controls.Add(Me.finishButton)
        Me.layoutControl1.Controls.Add(Me.labelControl1)
        Me.layoutControl1.Controls.Add(Me.panel1)
        Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.layoutControl1.Name = "layoutControl1"
        Me.layoutControl1.Root = Me.layoutControlGroup1
        Me.layoutControl1.Size = New System.Drawing.Size(1121, 370)
        Me.layoutControl1.TabIndex = 6
        Me.layoutControl1.Text = "layoutControl1"
        '
        'finishButton
        '
        Me.finishButton.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.finishButton.Appearance.Options.UseFont = True
        Me.finishButton.AutoWidthInLayoutControl = True
        Me.finishButton.Location = New System.Drawing.Point(959, 294)
        Me.finishButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.finishButton.MinimumSize = New System.Drawing.Size(112, 0)
        Me.finishButton.Name = "finishButton"
        Me.finishButton.Size = New System.Drawing.Size(112, 26)
        Me.finishButton.StyleController = Me.layoutControl1
        Me.finishButton.TabIndex = 10
        Me.finishButton.Text = "Finish"
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.panel1.Location = New System.Drawing.Point(12, 12)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(253, 346)
        Me.panel1.TabIndex = 5
        '
        'layoutControlGroup1
        '
        Me.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1"
        Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.layoutControlGroup1.GroupBordersVisible = False
        Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutControlItem2, Me.emptySpaceItem2, Me.layoutControlItem3, Me.layoutControlItem1})
        Me.layoutControlGroup1.Name = "layoutControlGroup1"
        Me.layoutControlGroup1.Size = New System.Drawing.Size(1121, 370)
        Me.layoutControlGroup1.TextVisible = False
        '
        'layoutControlItem2
        '
        Me.layoutControlItem2.Control = Me.panel1
        Me.layoutControlItem2.CustomizationFormText = "layoutControlItem2"
        Me.layoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.layoutControlItem2.MaxSize = New System.Drawing.Size(257, 0)
        Me.layoutControlItem2.MinSize = New System.Drawing.Size(257, 24)
        Me.layoutControlItem2.Name = "layoutControlItem2"
        Me.layoutControlItem2.Size = New System.Drawing.Size(257, 350)
        Me.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.layoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem2.TextVisible = False
        '
        'emptySpaceItem2
        '
        Me.emptySpaceItem2.AllowHotTrack = False
        Me.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2"
        Me.emptySpaceItem2.Location = New System.Drawing.Point(257, 54)
        Me.emptySpaceItem2.Name = "emptySpaceItem2"
        Me.emptySpaceItem2.Size = New System.Drawing.Size(844, 230)
        Me.emptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'layoutControlItem3
        '
        Me.layoutControlItem3.Control = Me.labelControl1
        Me.layoutControlItem3.CustomizationFormText = "layoutControlItem3"
        Me.layoutControlItem3.Location = New System.Drawing.Point(257, 0)
        Me.layoutControlItem3.Name = "layoutControlItem3"
        Me.layoutControlItem3.Size = New System.Drawing.Size(844, 54)
        Me.layoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem3.TextVisible = False
        '
        'layoutControlItem1
        '
        Me.layoutControlItem1.Control = Me.finishButton
        Me.layoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.layoutControlItem1.CustomizationFormText = "layoutControlItem1"
        Me.layoutControlItem1.FillControlToClientArea = False
        Me.layoutControlItem1.Location = New System.Drawing.Point(257, 284)
        Me.layoutControlItem1.Name = "layoutControlItem1"
        Me.layoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 40, 0, 40)
        Me.layoutControlItem1.Size = New System.Drawing.Size(844, 66)
        Me.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment
        Me.layoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem1.TextVisible = False
        '
        'emptySpaceItem3
        '
        Me.emptySpaceItem3.AllowHotTrack = False
        Me.emptySpaceItem3.CustomizationFormText = "emptySpaceItem2"
        Me.emptySpaceItem3.Location = New System.Drawing.Point(206, 0)
        Me.emptySpaceItem3.Name = "emptySpaceItem2"
        Me.emptySpaceItem3.Size = New System.Drawing.Size(882, 406)
        Me.emptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'FinishPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.layoutControl1)
        Me.Name = "FinishPage"
        Me.Size = New System.Drawing.Size(1121, 370)
        CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.layoutControl1.ResumeLayout(False)
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.emptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.emptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private labelControl1 As DevExpress.XtraEditors.LabelControl
    Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
    Private panel1 As System.Windows.Forms.Panel
    Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Private layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Private emptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Private layoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Private emptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Private WithEvents finishButton As DevExpress.XtraEditors.SimpleButton
    Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
End Class
