Public Class AdvantageSplashScreenForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private WithEvents _Timer As System.Windows.Forms.Timer = Nothing
    Private _StartTime As DateTime = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub New(ByVal ShowLoadingLabel As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LabelLoading.Visible = ShowLoadingLabel

    End Sub

#Region "  Show Form Methods "

    Public Shared Function ShowFormDialog(ByVal ShowLoadingLabel As Boolean) As System.Windows.Forms.DialogResult

        'objects
        Dim AdvantageSplashScreenForm As AdvantageSplashScreenForm = Nothing

        AdvantageSplashScreenForm = New AdvantageSplashScreenForm(ShowLoadingLabel)

        ShowFormDialog = AdvantageSplashScreenForm.ShowDialog()

    End Function

#End Region

#Region "  Form Event Handlers "

    Private Sub AdvantageSplashScreenForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        '_Timer = New System.Windows.Forms.Timer

        '_Timer.Interval = 500

        '_Timer.Start()

        '_StartTime = Now

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub _Timer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Timer.Tick

        'If LabelLoading.Visible = False Then

        '    If DateDiff(DateInterval.Second, _StartTime, Now) > 1 Then

        '        Me.Close()

        '    End If

        'ElseIf _Task IsNot Nothing Then

        '    If _Task.Status = Threading.Tasks.TaskStatus.RanToCompletion Then

        '        Me.Close()

        '    Else

        '        If LabelLoading.Text = "Loading...." Then

        '            LabelLoading.Text = "Loading"

        '        End If

        '        LabelLoading.Text &= "."

        '        LabelLoading.Refresh()

        '    End If

        'End If

    End Sub

#End Region

#End Region

End Class
