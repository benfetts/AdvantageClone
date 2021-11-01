Namespace WinForm.Presentation.MVCControls

    Public Class SpellChecker
        Inherits DevExpress.XtraSpellChecker.SpellChecker

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ShowSpellCheckCompleteMessage As Boolean = True

#End Region

#Region " Properties "

        Public Property ShowSpellCheckCompleteMessage As Boolean
            Get
                ShowSpellCheckCompleteMessage = _ShowSpellCheckCompleteMessage
            End Get
            Set(value As Boolean)
                _ShowSpellCheckCompleteMessage = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            MyBase.New()

            Me.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.LookAndFeel.UseDefaultLookAndFeel = False

        End Sub

#Region "  Control Event Handlers "

        Public Overrides Sub Check(controller As DevExpress.XtraSpellChecker.Native.ISpellCheckTextControlController)

            If DirectCast(Me.ParentContainer, AdvantageFramework.WinForm.Presentation.MVCBaseForms.Interfaces.IMVCBaseForm).FormShown Then

                MyBase.Check(controller)

            End If

        End Sub
        Public Overrides Function Check(text As String) As String

            If DirectCast(Me.ParentContainer, AdvantageFramework.WinForm.Presentation.MVCBaseForms.Interfaces.IMVCBaseForm).FormShown Then

                Try

                    Check = MyBase.Check(text)

                Catch ex As Exception
                    Check = text
                End Try

            Else
                Check = text
            End If

        End Function
        Public Overrides Function Check(controller As DevExpress.XtraSpellChecker.Parser.ISpellCheckTextController) As String

            If DirectCast(Me.ParentContainer, AdvantageFramework.WinForm.Presentation.MVCBaseForms.Interfaces.IMVCBaseForm).FormShown Then

                Check = (MyBase.Check(controller))

            Else

                Check = controller.Text

            End If

        End Function
        Public Overrides Function Check(text As String, start As DevExpress.XtraSpellChecker.Parser.Position, finish As DevExpress.XtraSpellChecker.Parser.Position) As String

            If DirectCast(Me.ParentContainer, AdvantageFramework.WinForm.Presentation.MVCBaseForms.Interfaces.IMVCBaseForm).FormShown Then

                Try

                    Check = MyBase.Check(text, start, finish)

                Catch ex As Exception
                    Check = text
                End Try

            Else
                Check = text
            End If

        End Function
        Public Overrides Sub Check(editControl As System.Windows.Forms.Control)

            If DirectCast(Me.ParentContainer, AdvantageFramework.WinForm.Presentation.MVCBaseForms.Interfaces.IMVCBaseForm).FormShown Then

                MyBase.Check(editControl)

            End If

        End Sub
        Private Sub SpellChecker_CheckCompleteFormShowing(sender As Object, e As DevExpress.XtraSpellChecker.FormShowingEventArgs) Handles Me.CheckCompleteFormShowing

            e.Handled = Not _ShowSpellCheckCompleteMessage

        End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
