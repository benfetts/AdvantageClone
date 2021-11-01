Namespace WinForm.Presentation

    Public Class DataStoreForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _SqlConnection As SqlClient.SqlConnection = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Function LoadStartUpInformation(ByRef CommandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String)) As Boolean

            'objects
            Dim ServerName As String = ""
            Dim DatabaseName As String = ""

            For Each CommandLine In CommandLineArgs

                If CommandLine.StartsWith("-s") Then

                    ServerName = CommandLine.Replace("-s", "")

                ElseIf CommandLine.StartsWith("-d") Then

                    DatabaseName = CommandLine.Replace("-d", "")

                End If

            Next

            If WinForm.Presentation.LoginDialog.ShowFormDialog(ServerName, DatabaseName, _SqlConnection) = DialogResult.OK Then

                LoadStartUpInformation = True

            Else

                LoadStartUpInformation = False

            End If

        End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub DataStoreForm_Load(sender As Object, e As EventArgs) Handles Me.Load

            ButtonItemMaintain_Clients.Image = AdvantageFramework.My.Resources.ClientImage
            ButtonItemService_Log.Image = AdvantageFramework.My.Resources.LogAndSettingsImage
            ButtonItemService_ProcessNow.Image = AdvantageFramework.My.Resources.ProcessImage

            ButtonItemService_ProcessNow.Visible = Debugger.IsAttached

            Try

                If LoadStartUpInformation(My.Application.CommandLineArgs) Then

                    Me.Text = "Advantage Nielsen Data Store - [" & _SqlConnection.DataSource & " | " & _SqlConnection.Database & "]"

                Else

                    Me.Close()

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Me.Close()
            End Try

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemMaintain_Clients_Click(sender As Object, e As EventArgs) Handles ButtonItemMaintain_Clients.Click

            WinForm.Presentation.Maintenance.ClientSetupDialog.ShowFormDialog(_SqlConnection.ConnectionString)

        End Sub
        Private Sub ButtonItemService_Log_Click(sender As Object, e As EventArgs) Handles ButtonItemService_Log.Click

            WinForm.Presentation.ServiceEventLog.ShowFormDialog(_SqlConnection.ConnectionString)

        End Sub
        Private Sub ButtonItemService_ProcessNow_Click(sender As Object, e As EventArgs) Handles ButtonItemService_ProcessNow.Click

            NationalFramework.Service.SyncFilesFromNielsen("C:\NielsenData\DownloadData\MITLIB", _SqlConnection.ConnectionString)

        End Sub

#End Region

#End Region

    End Class

End Namespace