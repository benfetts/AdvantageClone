Namespace WinForm.Presentation

    Public Class ImageDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal Name As String, ByVal Bytes As Byte())

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.Text = Name

            Dim MemoryStream As System.IO.MemoryStream = Nothing

            MemoryStream = New System.IO.MemoryStream(Bytes)

            PictureEditForm_Image.Image = System.Drawing.Image.FromStream(MemoryStream)

            Try

                MemoryStream.Close()
                MemoryStream.Dispose()

                MemoryStream = Nothing

            Catch ex As Exception
                MemoryStream = Nothing
            End Try

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal Name As String, ByVal Bytes As Byte()) As System.Windows.Forms.DialogResult

            'objects
            Dim ImageDialog As ImageDialog = Nothing

            ImageDialog = New ImageDialog(Name, Bytes)

            ShowFormDialog = ImageDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ConnectedUsersDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

        End Sub

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