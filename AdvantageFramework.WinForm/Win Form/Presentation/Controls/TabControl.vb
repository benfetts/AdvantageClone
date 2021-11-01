Namespace WinForm.Presentation.Controls

    Public Class TabControl
        Inherits DevComponents.DotNetBar.TabControl

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _IsSelectedTabChanging As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property IsSelectedTabChanging As Boolean
            Get
                IsSelectedTabChanging = _IsSelectedTabChanging
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.ColorScheme.TabBackground = Drawing.Color.White
            Me.ColorScheme.TabPanelBackground = Drawing.Color.White

            Me.DoubleBuffered = True

        End Sub

#Region "  Control Event Handlers "

        Private Sub TabControl_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles Me.SelectedTabChanged

            Try

                If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Highlighter.UpdateHighlights()

                End If

            Catch ex As Exception

            End Try

            _IsSelectedTabChanging = False

        End Sub
        Private Sub TabControl_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles Me.SelectedTabChanging

            _IsSelectedTabChanging = True

        End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
