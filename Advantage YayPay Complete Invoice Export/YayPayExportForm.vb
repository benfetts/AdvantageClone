Public Class YayPayExportForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If My.Application.CommandLineArgs.Count = 0 Then

            _UseSecurityLogin = True

        Else

            _UseSecurityLogin = False

        End If

        _Application = AdvantageFramework.Security.Application.Advantage

    End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

    Private Sub YayPayExportForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        TabStripForm_MDIChildren.Visible = False
        TabStripForm_MDIChildren.MdiTabbedDocuments = False

        Me.MinimizeBox = False
        Me.MaximizeBox = False

        Me.ButtonItemMainRibbon_Help.Visible = False
        Me.ButtonItemMainRibbon_ShowAndHide.Visible = False

        Me.StartPosition = FormStartPosition.CenterScreen

        If _UseSecurityLogin = False Then

            LoadStartUpInformation(My.Application.CommandLineArgs)

        End If

        AdvantageFramework.Exporting.Presentation.ExportYayPayInvoicesForm.ShowForm()

    End Sub
    Private Sub YayPayExportForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        If Me.ActiveMdiChild IsNot Nothing Then

            Me.ActiveMdiChild.WindowState = FormWindowState.Minimized

            Me.Update()

            Me.ActiveMdiChild.WindowState = FormWindowState.Maximized

            Me.Update()

        End If

    End Sub
    Private Sub YayPayExportForm_MdiChildActivate(sender As Object, e As EventArgs) Handles Me.MdiChildActivate

        If Me.ActiveMdiChild IsNot Nothing Then

            If Me.ActiveMdiChild.WindowState <> Windows.Forms.FormWindowState.Maximized Then

                Me.ActiveMdiChild.WindowState = System.Windows.Forms.FormWindowState.Maximized

            End If

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

End Class
