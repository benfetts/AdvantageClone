Imports Microsoft.VisualBasic
Imports System
Partial Public Class InstallPage
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
        Me.bgWorker = New System.ComponentModel.BackgroundWorker()
        Me.layoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.startButton = New DevExpress.XtraEditors.SimpleButton()
        Me.progressEdit = New DevExpress.XtraEditors.ProgressBarControl()
        Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.simpleLabelItem1 = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.emptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.simpleLabelItem2 = New DevExpress.XtraLayout.SimpleLabelItem()
        CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.layoutControl1.SuspendLayout()
        CType(Me.progressEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.simpleLabelItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.simpleLabelItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        ' bgWorker
        '
        Me.bgWorker.WorkerReportsProgress = True
        '			Me.bgWorker.DoWork += New System.ComponentModel.DoWorkEventHandler(Me.backgroundWorker_DoWork);
        '			Me.bgWorker.ProgressChanged += New System.ComponentModel.ProgressChangedEventHandler(Me.bgWorker_ProgressChanged);
        '			Me.bgWorker.RunWorkerCompleted += New System.ComponentModel.RunWorkerCompletedEventHandler(Me.backgroundWorker1_RunWorkerCompleted);
        '
        ' layoutControl1
        '
        Me.layoutControl1.AllowCustomization = False
        Me.layoutControl1.Controls.Add(Me.startButton)
        Me.layoutControl1.Controls.Add(Me.progressEdit)
        Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.layoutControl1.Name = "layoutControl1"
        Me.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(-1469, 300, 450, 350)
        Me.layoutControl1.Root = Me.layoutControlGroup1
        Me.layoutControl1.Size = New System.Drawing.Size(759, 354)
        Me.layoutControl1.TabIndex = 1
        Me.layoutControl1.Text = "layoutControl1"
        '
        ' startButton
        '
        Me.startButton.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0F)
        Me.startButton.Appearance.Options.UseFont = True
        Me.startButton.AutoWidthInLayoutControl = True
        Me.startButton.Location = New System.Drawing.Point(527, 160)
        Me.startButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.startButton.MinimumSize = New System.Drawing.Size(112, 0)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(112, 28)
        Me.startButton.StyleController = Me.layoutControl1
        Me.startButton.TabIndex = 9
        Me.startButton.Text = "Install"
        '			Me.startButton.Click += New System.EventHandler(Me.startButton_Click);
        '
        ' progressEdit
        '
        Me.progressEdit.EditValue = Nothing
        Me.progressEdit.Location = New System.Drawing.Point(120, 114)
        Me.progressEdit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.progressEdit.MinimumSize = New System.Drawing.Size(0, 26)
        Me.progressEdit.Name = "progressEdit"
        Me.progressEdit.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
        Me.progressEdit.Size = New System.Drawing.Size(519, 26)
        Me.progressEdit.StyleController = Me.layoutControl1
        Me.progressEdit.TabIndex = 8
        '
        ' layoutControlGroup1
        '
        Me.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1"
        Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        Me.layoutControlGroup1.GroupBordersVisible = False
        Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutControlItem2, Me.simpleLabelItem1, Me.layoutControlItem1, Me.emptySpaceItem1, Me.simpleLabelItem2})
        Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.layoutControlGroup1.Name = "Root"
        Me.layoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(40, 40, 0, 40)
        Me.layoutControlGroup1.Size = New System.Drawing.Size(759, 354)
        Me.layoutControlGroup1.Text = "Root"
        Me.layoutControlGroup1.TextVisible = False
        '
        ' layoutControlItem2
        '
        Me.layoutControlItem2.AppearanceItemCaption.Font = New System.Drawing.Font("Segoe UI", 14.0F)
        Me.layoutControlItem2.AppearanceItemCaption.Options.UseFont = True
        Me.layoutControlItem2.Control = Me.progressEdit
        Me.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.layoutControlItem2.CustomizationFormText = "Installation Folder:"
        Me.layoutControlItem2.Location = New System.Drawing.Point(0, 34)
        Me.layoutControlItem2.Name = "layoutControlItem2"
        Me.layoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(80, 80, 80, 20)
        Me.layoutControlItem2.Size = New System.Drawing.Size(679, 126)
        Me.layoutControlItem2.Text = "Installation Folder:"
        Me.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.layoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem2.TextToControlDistance = 0
        Me.layoutControlItem2.TextVisible = False
        Me.layoutControlItem2.TrimClientAreaToControl = False
        '
        ' simpleLabelItem1
        '
        Me.simpleLabelItem1.AllowHotTrack = False
        Me.simpleLabelItem1.AppearanceItemCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold)
        Me.simpleLabelItem1.AppearanceItemCaption.Options.UseFont = True
        Me.simpleLabelItem1.CustomizationFormText = "Installation progress:"
        Me.simpleLabelItem1.Location = New System.Drawing.Point(0, 0)
        Me.simpleLabelItem1.Name = "simpleLabelItem1"
        Me.simpleLabelItem1.Size = New System.Drawing.Size(679, 34)
        Me.simpleLabelItem1.Text = "Installation progress:"
        Me.simpleLabelItem1.TextSize = New System.Drawing.Size(200, 30)
        '
        ' layoutControlItem1
        '
        Me.layoutControlItem1.Control = Me.startButton
        Me.layoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.layoutControlItem1.CustomizationFormText = "layoutControlItem1"
        Me.layoutControlItem1.FillControlToClientArea = False
        Me.layoutControlItem1.Location = New System.Drawing.Point(0, 160)
        Me.layoutControlItem1.Name = "layoutControlItem1"
        Me.layoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(80, 80, 0, 0)
        Me.layoutControlItem1.Size = New System.Drawing.Size(679, 28)
        Me.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment
        Me.layoutControlItem1.Text = "layoutControlItem1"
        Me.layoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem1.TextToControlDistance = 0
        Me.layoutControlItem1.TextVisible = False
        '
        ' emptySpaceItem1
        '
        Me.emptySpaceItem1.AllowHotTrack = False
        Me.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1"
        Me.emptySpaceItem1.Location = New System.Drawing.Point(0, 188)
        Me.emptySpaceItem1.Name = "emptySpaceItem1"
        Me.emptySpaceItem1.Size = New System.Drawing.Size(679, 113)
        Me.emptySpaceItem1.Text = "emptySpaceItem1"
        Me.emptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        ' simpleLabelItem2
        '
        Me.simpleLabelItem2.AllowHotTrack = False
        Me.simpleLabelItem2.CustomizationFormText = "Click Install to begin installation"
        Me.simpleLabelItem2.Location = New System.Drawing.Point(0, 301)
        Me.simpleLabelItem2.Name = "simpleLabelItem2"
        Me.simpleLabelItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(80, 0, 0, 0)
        Me.simpleLabelItem2.Size = New System.Drawing.Size(679, 13)
        Me.simpleLabelItem2.Text = "Click Install to begin installation"
        Me.simpleLabelItem2.TextSize = New System.Drawing.Size(200, 13)
        '
        ' ucInstallPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.layoutControl1)
        Me.Name = "ucInstallPage"
        Me.Size = New System.Drawing.Size(759, 354)
        CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.layoutControl1.ResumeLayout(False)
        CType(Me.progressEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.simpleLabelItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.simpleLabelItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private WithEvents bgWorker As System.ComponentModel.BackgroundWorker
    Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
    Private progressEdit As DevExpress.XtraEditors.ProgressBarControl
    Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Private layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Private simpleLabelItem1 As DevExpress.XtraLayout.SimpleLabelItem
    Private WithEvents startButton As DevExpress.XtraEditors.SimpleButton
    Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Private emptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Private simpleLabelItem2 As DevExpress.XtraLayout.SimpleLabelItem
End Class
