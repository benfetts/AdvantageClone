Namespace WinForm.Presentation

    Public Class TextBoxMessageDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal Message As String, ByVal Title As String)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            TextBoxForm_Message.Text = Message
            Me.Text = Title

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal Message As String, ByVal Title As String) As System.Windows.Forms.DialogResult

            'objects
            Dim TextBoxMessageDialog As TextBoxMessageDialog = Nothing

            TextBoxMessageDialog = New TextBoxMessageDialog(Message, Title)

            ShowFormDialog = TextBoxMessageDialog.ShowDialog

        End Function

#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace