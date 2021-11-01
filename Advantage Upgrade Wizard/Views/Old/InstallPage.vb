Partial Public Class InstallPage
    Inherits BaseWizardPage

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

        InitializeComponent()

    End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

    Private Sub backgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgWorker.DoWork

        For i As Integer = 0 To 10
            System.Threading.Thread.Sleep(100)
            CType(sender, System.ComponentModel.BackgroundWorker).ReportProgress(i)
        Next i

    End Sub
    Private Sub bgWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgWorker.ProgressChanged

        progressEdit.PerformStep()

    End Sub
    Private Sub startButton_Click(sender As Object, e As System.EventArgs) Handles startButton.Click

        If (Not bgWorker.IsBusy) Then

            startButton.Enabled = False
            bgWorker.RunWorkerAsync()

        End If

    End Sub
    Private Sub backgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWorker.RunWorkerCompleted

        If (Not e.Cancelled) Then

            CType(PageViewModel, InstallPageViewModel).SetComplete(True)

        End If

        WizardViewModel.PageCompleted()

    End Sub

#End Region

#End Region

End Class
