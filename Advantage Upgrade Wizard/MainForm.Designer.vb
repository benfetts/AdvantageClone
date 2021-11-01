Imports Microsoft.VisualBasic
Imports System
Partial Public Class MainForm
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

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.DocumentManagerForm_DocumentManager = New DevExpress.XtraBars.Docking2010.DocumentManager(Me.components)
        Me.WindowsUIViewForm_View = New DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView(Me.components)
        Me.PageGroupForm_PageGroup = New DevExpress.XtraBars.Docking2010.Views.WindowsUI.PageGroup(Me.components)
        Me.CloseFlyout = New DevExpress.XtraBars.Docking2010.Views.WindowsUI.Flyout(Me.components)
        Me.ImageListForm_Image = New DevExpress.Utils.ImageCollection(Me.components)
        CType(Me.DocumentManagerForm_DocumentManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WindowsUIViewForm_View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PageGroupForm_PageGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CloseFlyout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageListForm_Image, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DocumentManagerForm_DocumentManager
        '
        Me.DocumentManagerForm_DocumentManager.ContainerControl = Me
        Me.DocumentManagerForm_DocumentManager.View = Me.WindowsUIViewForm_View
        Me.DocumentManagerForm_DocumentManager.ViewCollection.AddRange(New DevExpress.XtraBars.Docking2010.Views.BaseView() {Me.WindowsUIViewForm_View})
        '
        'WindowsUIViewForm_View
        '
        Me.WindowsUIViewForm_View.AddTileWhenCreatingDocument = DevExpress.Utils.DefaultBoolean.[False]
        Me.WindowsUIViewForm_View.AllowCaptionDragMove = DevExpress.Utils.DefaultBoolean.[True]
        Me.WindowsUIViewForm_View.Caption = "Advantage Upgrade Wizard"
        Me.WindowsUIViewForm_View.ContentContainers.AddRange(New DevExpress.XtraBars.Docking2010.Views.WindowsUI.IContentContainer() {Me.PageGroupForm_PageGroup, Me.CloseFlyout})
        Me.WindowsUIViewForm_View.Style = DevExpress.XtraBars.Docking2010.Views.DockingViewStyle.Classic
        Me.WindowsUIViewForm_View.UseSplashScreen = DevExpress.Utils.DefaultBoolean.[False]
        '
        'PageGroupForm_PageGroup
        '
        Me.PageGroupForm_PageGroup.ButtonInterval = 30
        Me.PageGroupForm_PageGroup.Name = "pageGroup"
        Me.PageGroupForm_PageGroup.Properties.ShowPageHeaders = DevExpress.Utils.DefaultBoolean.[False]
        '
        'CloseFlyout
        '
        Me.CloseFlyout.FlyoutButtons = System.Windows.Forms.MessageBoxButtons.YesNo
        Me.CloseFlyout.Name = "closeFlyout"
        '
        'ImageListForm_Image
        '
        Me.ImageListForm_Image.ImageSize = New System.Drawing.Size(32, 32)
        Me.ImageListForm_Image.ImageStream = CType(resources.GetObject("ImageListForm_Image.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageListForm_Image.InsertGalleryImage("backward_32x32.png", "grayscaleimages/navigation/backward_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("grayscaleimages/navigation/backward_32x32.png"), 0)
        Me.ImageListForm_Image.Images.SetKeyName(0, "backward_32x32.png")
        Me.ImageListForm_Image.InsertGalleryImage("forward_32x32.png", "grayscaleimages/navigation/forward_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("grayscaleimages/navigation/forward_32x32.png"), 1)
        Me.ImageListForm_Image.Images.SetKeyName(1, "forward_32x32.png")
        Me.ImageListForm_Image.InsertGalleryImage("cancel_32x32.png", "grayscaleimages/actions/cancel_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("grayscaleimages/actions/cancel_32x32.png"), 2)
        Me.ImageListForm_Image.Images.SetKeyName(2, "cancel_32x32.png")
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(840, 500)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.IconOptions.Icon = CType(resources.GetObject("MainForm.IconOptions.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Wizard"
        CType(Me.DocumentManagerForm_DocumentManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WindowsUIViewForm_View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PageGroupForm_PageGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CloseFlyout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageListForm_Image, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private WithEvents DocumentManagerForm_DocumentManager As DevExpress.XtraBars.Docking2010.DocumentManager
    Private WithEvents WindowsUIViewForm_View As DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView
    Private PageGroupForm_PageGroup As DevExpress.XtraBars.Docking2010.Views.WindowsUI.PageGroup
    Private CloseFlyout As DevExpress.XtraBars.Docking2010.Views.WindowsUI.Flyout
    Private ImageListForm_Image As DevExpress.Utils.ImageCollection
End Class
