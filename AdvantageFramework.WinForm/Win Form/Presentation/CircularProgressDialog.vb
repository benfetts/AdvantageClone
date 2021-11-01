Namespace WinForm.Presentation

    Public Class CircularProgressDialog

        Private Shared Event CloseDialogEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private WithEvents _Timer As System.Windows.Forms.Timer = Nothing
        Private Shared _CircularProgressDialog As AdvantageFramework.WinForm.Presentation.CircularProgressDialog = Nothing
        Private _Task As System.Threading.Tasks.Task = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal LabelText As String, ByVal Task As System.Threading.Tasks.Task)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            LabelForm_Text.Text = LabelText
            _Task = Task

            AddHandler CloseDialogEvent, AddressOf CloseDialog

        End Sub
        Private Sub CloseDialog()

            Me.Close()

        End Sub

#Region "  Show Form Methods "

        Private Shared Function ShowFormDialog(ByVal LabelText As String, ByVal Task As System.Threading.Tasks.Task) As Windows.Forms.DialogResult

            _CircularProgressDialog = New AdvantageFramework.WinForm.Presentation.CircularProgressDialog(LabelText, Task)

            System.Threading.Thread.Sleep(500)

            If Task Is Nothing OrElse (Task IsNot Nothing AndAlso Task.IsCompleted = False) Then

                ShowFormDialog = _CircularProgressDialog.ShowDialog()

            Else

                ShowFormDialog = Windows.Forms.DialogResult.OK

            End If

        End Function
        Private Shared Sub CloseFormDialog()

            RaiseEvent CloseDialogEvent()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub CircularProgressDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DevComponents.DotNetBar.StyleManager.Style = DevComponents.DotNetBar.eStyle.Office2013

            CircularProgress.IsRunning = True

            _Timer = New System.Windows.Forms.Timer

            _Timer.Interval = 100

            _Timer.Start()

            Me.BringToFront()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub _Timer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Timer.Tick

            If _Task IsNot Nothing AndAlso _Task.IsCompleted Then

                Me.Close()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace