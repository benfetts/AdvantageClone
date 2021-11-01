Namespace WinForm.Presentation

    Public Class ProgressDialog

        Private Delegate Sub CloseFormDelegate()
        Private Delegate Sub SetupDelegate(ByVal MaxProgressBarValue As Integer, ByVal MinProgressBarValue As Integer)
        Private Delegate Sub UpdateDelegate(ByVal ProgressValue As Integer, ByVal StatusMessage As String)
        Private Shared Event CloseProgressDialogEvent()
        Private Shared Event UpdateProgressAndStatusEvent(ByVal ProgressValue As Integer, ByVal StatusMessage As String)
        Private Shared Event SetupProgressBarEvent(ByVal MaxProgressBarValue As Integer, ByVal MinProgressBarValue As Integer)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Thread As System.Threading.Thread = Nothing
        Private _Parameters() As Object = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByRef Thread As System.Threading.Thread, ByRef Parameters() As Object)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _Thread = Thread
            _Parameters = Parameters

        End Sub
        Public Shared Sub CloseProgressDialog()

            RaiseEvent CloseProgressDialogEvent()

        End Sub
        Public Shared Sub UpdateProgressAndStatus(ByVal ProgressValue As Integer, ByVal StatusMessage As String)

            RaiseEvent UpdateProgressAndStatusEvent(ProgressValue, StatusMessage)

        End Sub
        Public Shared Sub SetupProgressBar(ByVal MaxProgressBarValue As Integer, ByVal MinProgressBarValue As Integer)

            RaiseEvent SetupProgressBarEvent(MaxProgressBarValue, MinProgressBarValue)

        End Sub
        Private Sub SetupMethod(ByVal MaxProgressBarValue As Integer, ByVal MinProgressBarValue As Integer)

            ProgressBarForm_Progress.Maximum = MaxProgressBarValue
            ProgressBarForm_Progress.Minimum = MinProgressBarValue

            System.Windows.Forms.Application.DoEvents()

        End Sub
        Private Sub UpdateMethod(ByVal ProgressValue As Integer, ByVal StatusMessage As String)

            ProgressBarForm_Progress.Value = ProgressValue
            LabelForm_Status.Text = StatusMessage

            System.Windows.Forms.Application.DoEvents()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef Thread As System.Threading.Thread, ByRef Parameters() As Object, ByVal FormText As String) As Windows.Forms.DialogResult

            Dim ProgressDialog As AdvantageFramework.WinForm.Presentation.ProgressDialog = Nothing

            ProgressDialog = New AdvantageFramework.WinForm.Presentation.ProgressDialog(Thread, Parameters)

            ProgressDialog.Text = FormText

            ShowFormDialog = ProgressDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ProgressDialog_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            Me.DialogResult = Windows.Forms.DialogResult.OK

        End Sub
        Private Sub ProgressDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

        End Sub
        Private Sub ProgressDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            If _Parameters IsNot Nothing Then

                _Thread.Start(_Parameters)

            Else

                _Thread.Start()

            End If

        End Sub
        Private Sub ProgressDialog_xCloseProgressDialogEvent() Handles Me.CloseProgressDialogEvent

            If Me.IsHandleCreated Then

                Me.Invoke(New CloseFormDelegate(AddressOf Me.Close))

            End If

        End Sub
        Private Sub ProgressDialog_xSetupProgressBarEvent(ByVal MaxProgressBarValue As Integer, ByVal MinProgressBarValue As Integer) Handles Me.SetupProgressBarEvent

            If Me.IsHandleCreated Then

                Me.Invoke(New SetupDelegate(AddressOf Me.SetupMethod), New Object() {MaxProgressBarValue, MinProgressBarValue})

            End If

        End Sub
        Private Sub ProgressDialog_xUpdateProgressAndStatusEvent(ByVal ProgressValue As Integer, ByVal StatusMessage As String) Handles Me.UpdateProgressAndStatusEvent

            If Me.IsHandleCreated Then

                Me.Invoke(New UpdateDelegate(AddressOf Me.UpdateMethod), New Object() {ProgressValue, StatusMessage})

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace