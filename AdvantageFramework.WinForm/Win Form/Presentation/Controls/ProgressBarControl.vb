Namespace WinForm.Presentation.Controls

    Public Class ProgressBar
        Inherits DevComponents.DotNetBar.Controls.ProgressBarX

        Private Delegate Sub SetMinimumDelegate(ByVal Minimum As Integer)
        Private Delegate Sub SetMaximumDelegate(ByVal Maximum As Integer)
        Private Delegate Sub SetValueDelegate(ByVal Value As Integer)

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

            Me.Size = New System.Drawing.Size(Me.Size.Width, 20)
            Me.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DoubleBuffered = True

        End Sub
        Public Sub SetMinimum(ByVal Minimum As Integer)

            If Me.InvokeRequired Then

                Me.Invoke(New SetMinimumDelegate(AddressOf SetMinimum), New Object() {Minimum})

            Else

                Me.Minimum = Minimum

            End If

        End Sub
        Public Sub SetMaximum(ByVal Maximum As Integer)

            If Me.InvokeRequired Then

                Me.Invoke(New SetMaximumDelegate(AddressOf SetMaximum), New Object() {Maximum})

            Else

                Me.Maximum = Maximum

            End If

        End Sub
        Public Sub SetValue(ByVal Value As Integer)

            If Me.InvokeRequired Then

                Me.Invoke(New SetValueDelegate(AddressOf SetValue), New Object() {Value})

            Else

                Me.Value = Value

            End If

        End Sub

#Region "  Control Event Handlers "



#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
