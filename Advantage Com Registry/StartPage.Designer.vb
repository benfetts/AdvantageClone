Imports Microsoft.VisualBasic
Imports System
Partial Public Class StartPage
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
        Me.components = New System.ComponentModel.Container()
        Me.layoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SimpleButtonRegisterComLibrary = New DevExpress.XtraEditors.SimpleButton()
        Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.emptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.emptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me._DefaultLookAndFeel = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.layoutControl1.SuspendLayout()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.emptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.emptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'layoutControl1
        '
        Me.layoutControl1.AllowCustomization = False
        Me.layoutControl1.Controls.Add(Me.SimpleButtonRegisterComLibrary)
        Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.layoutControl1.Name = "layoutControl1"
        Me.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1594, 189, 650, 400)
        Me.layoutControl1.Root = Me.layoutControlGroup1
        Me.layoutControl1.Size = New System.Drawing.Size(406, 153)
        Me.layoutControl1.TabIndex = 0
        Me.layoutControl1.Text = "layoutControl1"
        '
        'SimpleButtonRegisterComLibrary
        '
        Me.SimpleButtonRegisterComLibrary.Location = New System.Drawing.Point(12, 69)
        Me.SimpleButtonRegisterComLibrary.Name = "SimpleButtonRegisterComLibrary"
        Me.SimpleButtonRegisterComLibrary.Size = New System.Drawing.Size(382, 22)
        Me.SimpleButtonRegisterComLibrary.StyleController = Me.layoutControl1
        Me.SimpleButtonRegisterComLibrary.TabIndex = 4
        Me.SimpleButtonRegisterComLibrary.Text = "Register Com Library"
        '
        'layoutControlGroup1
        '
        Me.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1"
        Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.layoutControlGroup1.GroupBordersVisible = False
        Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.emptySpaceItem2, Me.LayoutControlItem1, Me.EmptySpaceItem1})
        Me.layoutControlGroup1.Name = "Root"
        Me.layoutControlGroup1.Size = New System.Drawing.Size(406, 153)
        Me.layoutControlGroup1.TextVisible = False
        '
        'emptySpaceItem2
        '
        Me.emptySpaceItem2.AllowHotTrack = False
        Me.emptySpaceItem2.Location = New System.Drawing.Point(0, 83)
        Me.emptySpaceItem2.Name = "emptySpaceItem2"
        Me.emptySpaceItem2.Size = New System.Drawing.Size(386, 50)
        Me.emptySpaceItem2.StartNewLine = True
        Me.emptySpaceItem2.Text = "Advantage Administrator Login"
        Me.emptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SimpleButtonRegisterComLibrary
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 57)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(386, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(386, 57)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
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
        '_DefaultLookAndFeel
        '
        Me._DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2019 Colorful"
        '
        'StartPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 153)
        Me.Controls.Add(Me.layoutControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StartPage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Advantage Com Registry"
        CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.layoutControl1.ResumeLayout(False)
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.emptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.emptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
    Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Private emptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Private emptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleButtonRegisterComLibrary As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Private WithEvents _DefaultLookAndFeel As DevExpress.LookAndFeel.DefaultLookAndFeel
End Class
