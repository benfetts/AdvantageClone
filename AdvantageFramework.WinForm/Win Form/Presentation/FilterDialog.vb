Namespace WinForm.Presentation

    Public Class FilterDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FilterString As String = ""

#End Region

#Region " Properties "

        Private ReadOnly Property FilterString As String
            Get
                FilterString = _FilterString
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal SourceControl As Object, ByRef FilterString As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            FilterEditorControlForm_Filter.SourceControl = SourceControl
            FilterEditorControlForm_Filter.FilterString = FilterString

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal SourceControl As Object, ByRef FilterString As String) As Windows.Forms.DialogResult

            Dim FilterDialog As AdvantageFramework.WinForm.Presentation.FilterDialog = Nothing

            FilterDialog = New AdvantageFramework.WinForm.Presentation.FilterDialog(SourceControl, FilterString)

            ShowFormDialog = FilterDialog.ShowDialog()

            FilterString = FilterDialog.FilterString

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub FilterDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            FilterEditorControlForm_Filter.ApplyFilter()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_OK.Click

            _FilterString = FilterEditorControlForm_Filter.FilterString

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace