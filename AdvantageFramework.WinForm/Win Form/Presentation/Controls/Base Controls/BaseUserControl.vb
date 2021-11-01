Namespace WinForm.Presentation.Controls.BaseControls

    Public Class BaseUserControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl

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

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True

        End Sub
        Protected Overrides Sub OnSizeChanged(e As EventArgs)

			If Me.IsHandleCreated AndAlso Me.IsDisposed = False Then

				Me.BeginInvoke(Sub()

								   MyBase.OnSizeChanged(e)

							   End Sub)

			End If

		End Sub
        Protected Overridable Sub LoadFormSettings(Form As Windows.Forms.Form) Implements Interfaces.IUserControl.LoadFormSettings

        End Sub
        Protected Sub ShowWaitForm(Optional ByVal DisplayText As String = Nothing)

            If TypeOf Me.ParentForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm AndAlso
                    CType(Me.ParentForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).FormShown Then

                AdvantageFramework.WinForm.Presentation.ShowWaitForm(DisplayText)

            End If

        End Sub
        Protected Sub CloseWaitForm()

            AdvantageFramework.WinForm.Presentation.CloseWaitForm()

        End Sub

#Region "  Control Event Handlers "



#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
