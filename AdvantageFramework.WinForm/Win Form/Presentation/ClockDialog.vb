Namespace WinForm.Presentation

    Public Class ClockDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _LockTimerCounter As Boolean = False
        Private Shared _SharedClockDialogOpen As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal Location As System.Drawing.Point)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Timer.Start()
            OnTimerTick(Nothing, Nothing)
            Me.Location = New System.Drawing.Point(Location.X - 308, Location.Y - 128)

        End Sub
        Private Sub OnTimerTick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer.Tick

            If _LockTimerCounter = False Then

                _LockTimerCounter = True

                UpdateTime()

                _LockTimerCounter = False

            End If

        End Sub
        Private Sub UpdateTime()

            'objects
            Dim Time As String = ""

            Time = DateTime.Now.ToLongTimeString()

            If GetTimeStringLength(Time) > DigitalGauge.DigitCount Then

                DigitalGauge.DigitCount = GetTimeStringLength(Time)

            End If

            DigitalGauge.Text = Time

        End Sub
        Private Function GetTimeStringLength(ByVal Time As String) As Integer

            'objects
            Dim NumberOfDigits As Integer = 0
            Dim StringIndex As Integer = 0

            Do While StringIndex < Time.Length

                If Time.Chars(StringIndex) <> ":"c Then

                    NumberOfDigits += 1

                End If

                StringIndex += 1

            Loop

            GetTimeStringLength = NumberOfDigits

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm(ByVal Location As System.Drawing.Point)

            If _SharedClockDialogOpen = False Then

                Dim ClockDialog As AdvantageFramework.WinForm.Presentation.ClockDialog = Nothing

                ClockDialog = New AdvantageFramework.WinForm.Presentation.ClockDialog(Location)

                ClockDialog.Show()

            End If

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ClockDialog_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

            _SharedClockDialogOpen = False

        End Sub
        Private Sub ClockDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.Location = New System.Drawing.Point(Me.Location.X - Me.Width, Me.Location.Y - Me.Height)

            _SharedClockDialogOpen = True

        End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace