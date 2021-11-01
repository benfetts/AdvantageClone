Namespace WinForm.Presentation.Controls

    Public Class GridControl
        Inherits DevExpress.XtraGrid.GridControl

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

            Me.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.LookAndFeel.UseDefaultLookAndFeel = False

        End Sub
        Protected Overrides Sub OnMouseDown(ev As Windows.Forms.MouseEventArgs)

            Try

                MyBase.OnMouseDown(ev)

            Catch ex As Exception

            End Try

        End Sub

#Region "  Control Event Handlers "

        Private Sub GridControl_ProcessGridKey(sender As Object, e As Windows.Forms.KeyEventArgs) Handles Me.ProcessGridKey

            Dim GridControl As AdvantageFramework.WinForm.Presentation.Controls.GridControl = Nothing
            Dim GridView As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing

            GridControl = DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.GridControl)

            If TypeOf GridControl.FocusedView Is AdvantageFramework.WinForm.Presentation.Controls.GridView Then

                GridView = GridControl.FocusedView

                If Not GridView.IsEditing AndAlso e.KeyCode = Windows.Forms.Keys.Enter Then

                    'forces next column/row focus on enter when focused on read-only cell
                    'System.Windows.Forms.SendKeys.SendWait("{TAB}")
                    'GridView.ShowEditor()
                    'e.Handled = True

                    If GridView.FocusedColumn IsNot Nothing Then

                        If GridView.FocusedColumn.VisibleIndex < GridView.VisibleColumns.Count - 1 Then

                            GridView.FocusedColumn = GridView.VisibleColumns(GridView.FocusedColumn.VisibleIndex + 1)

                        Else

                            System.Windows.Forms.SendKeys.Send("{TAB}")
                            
                        End If

                        e.Handled = True

                    End If
                    
                End If

            End If

        End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace

