'Imports System.ComponentModel
'Imports System.Configuration.Install

Imports System.Configuration.Install

Public Class AdvantageWindowsServiceProjectInstaller

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

        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add initialization code after the call to InitializeComponent


    End Sub
    Public Overrides Sub Install(ByVal stateSaver As System.Collections.IDictionary)

        'objects
        Dim ServiceInstaller As System.ServiceProcess.ServiceInstaller = Nothing
        Dim AutoStartEnabled As String = "1"

        Try

            AutoStartEnabled = Context.Parameters("autostart_enabled")

        Catch ex As Exception

            System.Windows.Forms.MessageBox.Show(ex.Message, "Install Error 1")

            AutoStartEnabled = "1"

        End Try

        Try

            If AutoStartEnabled <> "1" Then

                For Each Installer As Object In Me.Installers

                    If TypeOf Installer Is System.ServiceProcess.ServiceInstaller Then

                        ServiceInstaller = DirectCast(Installer, System.ServiceProcess.ServiceInstaller)

                        ServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Manual

                    End If

                Next

            End If

        Catch ex As Exception

            System.Windows.Forms.MessageBox.Show(ex.Message, "Install Error 2")

        End Try

        MyBase.Install(stateSaver)

    End Sub
    Private Sub AdvantageWindowsServiceProjectInstaller_AfterInstall(ByVal sender As Object, ByVal e As System.Configuration.Install.InstallEventArgs) Handles Me.AfterInstall

        'objects
        Dim ServiceController As System.ServiceProcess.ServiceController = Nothing
        Dim AutoStartEnabled As String = "1"

        Try

            AutoStartEnabled = Context.Parameters("autostart_enabled")

        Catch ex As Exception

            System.Windows.Forms.MessageBox.Show(ex.Message, "After Install Error 1")

            AutoStartEnabled = "1"

        End Try

        Try

            If AutoStartEnabled = "1" Then

                ServiceController = AdvantageFramework.Services.Load()

                ServiceController.Start()

            End If

        Catch ex As Exception

            System.Windows.Forms.MessageBox.Show(ex.Message, "After Install Error 2")

        End Try

    End Sub
    Private Sub AdvantageWindowsServiceProjectInstaller_AfterUninstall(sender As Object, e As InstallEventArgs) Handles Me.AfterUninstall

        Try

            If My.Computer.FileSystem.DirectoryExists(CType(e.SavedState("TARGETDIR"), String)) Then

                My.Computer.FileSystem.DeleteDirectory(CType(e.SavedState("TARGETDIR"), String), FileIO.DeleteDirectoryOption.DeleteAllContents)

            End If

        Catch ex As Exception

            System.Windows.Forms.MessageBox.Show(ex.Message, "Cannot delete installed files!")

        End Try

    End Sub

#End Region


End Class
