Namespace WinForm.MessageBox

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub Show(Message As String, MessageBoxButtons As AdvantageFramework.WinForm.MessageBox.MessageBoxButtons, Title As String, ByRef DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults)

            DialogResult = Show(Message, MessageBoxButtons, Title)

        End Sub
        Public Function Show(Message As String, Optional MessageBoxButtons As AdvantageFramework.WinForm.MessageBox.MessageBoxButtons = AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.OK, Optional Title As String = "", Optional MessageBoxIcon As Windows.Forms.MessageBoxIcon = Windows.Forms.MessageBoxIcon.None, Optional MessageBoxDefaultButton As Windows.Forms.MessageBoxDefaultButton = Windows.Forms.MessageBoxDefaultButton.Button1) As AdvantageFramework.WinForm.MessageBox.DialogResults

            'objects
            Dim Form As System.Windows.Forms.Form = Nothing
            Dim ActiveFormIntPtr As IntPtr = Nothing

            If SuppressMessageBox = False Then

                DevComponents.DotNetBar.MessageBoxEx.ButtonsDividerVisible = False

                Form = System.Windows.Forms.Form.ActiveForm

                If Form Is Nothing Then

                    ActiveFormIntPtr = AdvantageFramework.WinForm.Presentation.BaseForms.GetForegroundWindow

                    For Each Form In System.Windows.Forms.Application.OpenForms

                        Try

                            If Form.Handle = ActiveFormIntPtr Then

                                Exit For

                            End If

                        Catch ex As Exception

                        End Try

                        Form = Nothing

                    Next

                End If

                If Form Is Nothing Then

                    For Each Form In System.Windows.Forms.Application.OpenForms

                        If Form.IsMdiContainer Then

                            Exit For

                        End If

                    Next

                End If

                If Form Is Nothing Then

                    Show = DevComponents.DotNetBar.MessageBoxEx.Show(Message, Title, DirectCast(MessageBoxButtons, System.Windows.Forms.MessageBoxButtons), MessageBoxIcon, MessageBoxDefaultButton)

                Else

                    Show = DevComponents.DotNetBar.MessageBoxEx.Show(Form, Message, Title, DirectCast(MessageBoxButtons, System.Windows.Forms.MessageBoxButtons), MessageBoxIcon, MessageBoxDefaultButton, True)

                End If

            Else

                Show = DialogResults.Cancel

            End If

        End Function
        Public Function Show(Owner As Windows.Forms.IWin32Window,
                             Message As String,
                             Optional MessageBoxButtons As AdvantageFramework.WinForm.MessageBox.MessageBoxButtons = AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.OK,
                             Optional Title As String = "",
                             Optional MessageBoxIcon As Windows.Forms.MessageBoxIcon = Windows.Forms.MessageBoxIcon.None,
                             Optional MessageBoxDefaultButton As Windows.Forms.MessageBoxDefaultButton = Windows.Forms.MessageBoxDefaultButton.Button1) As AdvantageFramework.WinForm.MessageBox.DialogResults

            If SuppressMessageBox = False Then

                DevComponents.DotNetBar.MessageBoxEx.ButtonsDividerVisible = False

                Show = DevComponents.DotNetBar.MessageBoxEx.Show(Owner, Message, Title, DirectCast(MessageBoxButtons, System.Windows.Forms.MessageBoxButtons), MessageBoxIcon, MessageBoxDefaultButton, True)

            Else

                Show = DialogResults.Cancel

            End If

        End Function

#End Region

    End Module

End Namespace
