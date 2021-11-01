Namespace WinForm.Presentation

    Public Class WaitForm

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum WaitFormCommand
            Hide
            Show
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Sub New()

            InitializeComponent()
            Me.ProgressPanel.AutoHeight = True
            Me.AutoSize = False

        End Sub
        Public Overrides Sub SetCaption(ByVal Caption As String)

            MyBase.SetCaption(Caption)
            Me.ProgressPanel.Caption = Caption

        End Sub
        Public Overrides Sub SetDescription(ByVal Description As String)

            MyBase.SetDescription(Description)
            Me.ProgressPanel.Description = Description

        End Sub
        Public Overrides Sub ProcessCommand(ByVal WaitFormCommand As System.Enum, ByVal Args As Object)

            MyBase.ProcessCommand(WaitFormCommand, Args)

            If AdvantageFramework.EnumUtilities.GetValue(WaitFormCommand) = WaitForm.WaitFormCommand.Hide Then

                Me.Hide()

            ElseIf AdvantageFramework.EnumUtilities.GetValue(WaitFormCommand) = WaitForm.WaitFormCommand.Show Then

                Me.Show()

            End If

        End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
