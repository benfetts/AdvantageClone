Namespace WinForm.Presentation.Controls

    Public Class ExpandableSplitterControl
        Inherits DevComponents.DotNetBar.ExpandableSplitter
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _SaveChangesToRegistry As Boolean = False
        Protected _RegistrySection As String = ""
        Protected _FormSettingsLoaded As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New()

            Me.DoubleBuffered = True
            
            Me.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.Expandable = True
            Me.Size = New System.Drawing.Size(Me.Width, 5)

        End Sub
        Protected Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form) Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl.LoadFormSettings

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

            Try

                If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso Form IsNot Nothing AndAlso _
                        Form.Controls.Find(Me.Name, True).Any Then

                    _FormSettingsLoaded = True

                    _RegistrySection = Form.GetType.Namespace.Replace(".", "\") & "\" & Form.Name & "\" & Me.Name & "\"

                    If _RegistrySection <> "" Then

                        RegistryKey = AdvantageFramework.Registry.CreateAndOpenRegistryKeyByWin32(AdvantageFramework.Registry.OpenUserDefaultRegistryKey, _RegistrySection)

                        If RegistryKey IsNot Nothing Then

                            Me.SplitPosition = RegistryKey.GetValue("SplitPosition", Me.SplitPosition)

                        End If

                        _SaveChangesToRegistry = True

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub SaveRegistrySetting()

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

            Try

                If _RegistrySection <> "" AndAlso _SaveChangesToRegistry Then

                    RegistryKey = AdvantageFramework.Registry.CreateAndOpenRegistryKeyByWin32(AdvantageFramework.Registry.OpenUserDefaultRegistryKey, _RegistrySection)

                    If RegistryKey IsNot Nothing Then

                        RegistryKey.SetValue("SplitPosition", Me.SplitPosition)

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub

#Region "  Control Event Handlers "

        Private Sub ExpandableSplitterControl_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated

            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Private Sub ExpandableSplitterControl_HandleDestroyed(sender As Object, e As EventArgs) Handles Me.HandleDestroyed

            'RemoveHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Private Sub ExpandableSplitterControl_SplitterMoved(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles Me.SplitterMoved

            Me.SaveRegistrySetting()

        End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace

