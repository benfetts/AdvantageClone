Namespace Billing.Presentation

    Public Class AvaTaxProcessDialog

        Private Delegate Sub SetMinimumDelegate(ByVal ProgressBar As System.Windows.Forms.ProgressBar, ByVal Minimum As Integer)
        Private Delegate Sub SetMaximumDelegate(ByVal ProgressBar As System.Windows.Forms.ProgressBar, ByVal Maximum As Integer)
        Private Delegate Sub SetValueDelegate(ByVal ProgressBar As System.Windows.Forms.ProgressBar, ByVal Value As Integer)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum AvaTaxMode
            CalculateTax
            PostTax
        End Enum

#End Region

#Region " Variables "

        Private WithEvents _BackgroundWorker As System.ComponentModel.BackgroundWorker = Nothing
        Private _BillingUser As String = Nothing
        Private _Mode As AvaTaxMode = Nothing
        Private _ErrorMessage As String = Nothing
        Private _ReturnValue As Short = -200
        Private _ConnectionString As String = Nothing
        Private _UserCode As String = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property ErrorMessage As String
            Get
                ErrorMessage = _ErrorMessage
            End Get
        End Property
        Public ReadOnly Property ReturnValue As Short
            Get
                ReturnValue = _ReturnValue
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal ConnectionString As String, ByVal BillingUser As String, ByVal Mode As AvaTaxMode, ByVal UserCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ConnectionString = ConnectionString
            _BillingUser = BillingUser
            _Mode = Mode
            _UserCode = UserCode

        End Sub
        Private Sub SetupAvaTaxProgress(ByVal MinValue As Integer, ByVal MaxValue As Integer, ByVal Value As Integer)

            SetMinimum(ProgressBarForm_Progress, MinValue)
            SetMaximum(ProgressBarForm_Progress, MaxValue)
            SetValue(ProgressBarForm_Progress, Value)

        End Sub
        Private Sub AvaTaxProgressUpdate(ByVal ProgressValue As Integer)

            _BackgroundWorker.ReportProgress(ProgressValue)

        End Sub
        Public Sub SetMinimum(ByVal ProgressBar As System.Windows.Forms.ProgressBar, ByVal Minimum As Integer)

            If ProgressBar.InvokeRequired Then

                ProgressBar.Invoke(New SetMinimumDelegate(AddressOf SetMinimum), New Object() {ProgressBar, Minimum})

            Else

                ProgressBar.Minimum = Minimum

            End If

        End Sub
        Public Sub SetMaximum(ByVal ProgressBar As System.Windows.Forms.ProgressBar, ByVal Maximum As Integer)

            If ProgressBar.InvokeRequired Then

                ProgressBar.Invoke(New SetMaximumDelegate(AddressOf SetMaximum), New Object() {ProgressBar, Maximum})

            Else

                ProgressBar.Maximum = Maximum

            End If

        End Sub
        Public Sub SetValue(ByVal ProgressBar As System.Windows.Forms.ProgressBar, ByVal Value As Integer)

            If ProgressBar.InvokeRequired Then

                ProgressBar.Invoke(New SetValueDelegate(AddressOf SetValue), New Object() {ProgressBar, Value})

            Else

                ProgressBar.Value = Value

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ConectionString As String, ByVal BillingUser As String, ByVal Mode As AvaTaxMode, _
                                              ByVal UserCode As String, ByRef ErrorMessage As String, ByRef ReturnValue As Short) As System.Windows.Forms.DialogResult

            'objects
            Dim AvaTaxProcessDialog As AdvantageFramework.Billing.Presentation.AvaTaxProcessDialog = Nothing

            AvaTaxProcessDialog = New AdvantageFramework.Billing.Presentation.AvaTaxProcessDialog(ConectionString, BillingUser, Mode, UserCode)

            ShowFormDialog = AvaTaxProcessDialog.ShowDialog()

            ErrorMessage = AvaTaxProcessDialog.ErrorMessage
            ReturnValue = AvaTaxProcessDialog.ReturnValue

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AvaTaxProcessDialog_FormClosed(sender As Object, e As Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

            RemoveHandler AdvantageFramework.AvaTax.AvaTaxProgressUpdateEvent, AddressOf AvaTaxProgressUpdate
            RemoveHandler AdvantageFramework.AvaTax.SetupAvaTaxProgressEvent, AddressOf SetupAvaTaxProgress

        End Sub
        Private Sub AvaTaxProcessDialog_Load(sender As Object, e As EventArgs) Handles Me.Load

            AddHandler AdvantageFramework.AvaTax.AvaTaxProgressUpdateEvent, AddressOf AvaTaxProgressUpdate
            AddHandler AdvantageFramework.AvaTax.SetupAvaTaxProgressEvent, AddressOf SetupAvaTaxProgress

        End Sub
        Private Sub AvaTaxProcessDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Select Case _Mode

                Case AvaTaxMode.CalculateTax

                    Me.Text = "Calculating AvaTax"

                Case AvaTaxMode.PostTax

                    Me.Text = "Posting AvaTax"

            End Select

            _BackgroundWorker = New System.ComponentModel.BackgroundWorker

            _BackgroundWorker.WorkerReportsProgress = True

            _BackgroundWorker.RunWorkerAsync()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub _BackgroundWorker_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles _BackgroundWorker.DoWork

            Try

                Select Case _Mode

                    Case AvaTaxMode.CalculateTax

                        AdvantageFramework.AvaTax.CalculateAvaTax(_ConnectionString, _UserCode, _BillingUser)

                        _ReturnValue = 0

                    Case AvaTaxMode.PostTax

                        _ReturnValue = AdvantageFramework.AvaTax.PostAvaTax(_ConnectionString, _UserCode, _BillingUser, _ErrorMessage)

                End Select

                Me.DialogResult = Windows.Forms.DialogResult.OK

            Catch ex As Exception
                _ErrorMessage = ex.Message
                e.Cancel = True
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            End Try

        End Sub
        Private Sub _BackgroundWorker_ProgressChanged(sender As Object, e As ComponentModel.ProgressChangedEventArgs) Handles _BackgroundWorker.ProgressChanged

            ProgressBarForm_Progress.Value = e.ProgressPercentage

        End Sub

#End Region

#End Region

    End Class

End Namespace