Namespace WinForm.MVC.Presentation.Controls

	Public Class BandedGridControl
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

            Dim BandedGridControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedGridControl = Nothing
            Dim BandedGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedGridView = Nothing

            BandedGridControl = DirectCast(sender, AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedGridControl)

            If TypeOf BandedGridControl.FocusedView Is AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView Then

                BandedGridView = BandedGridControl.FocusedView

                If Not BandedGridView.IsEditing AndAlso e.KeyCode = Windows.Forms.Keys.Enter Then

                    If BandedGridView.FocusedColumn IsNot Nothing Then

                        If BandedGridView.FocusedColumn.VisibleIndex < BandedGridView.VisibleColumns.Count - 1 Then

                            BandedGridView.FocusedColumn = BandedGridView.VisibleColumns(BandedGridView.FocusedColumn.VisibleIndex + 1)

                        Else

                            System.Windows.Forms.SendKeys.Send("{TAB}")

                        End If

                        e.Handled = True

                    End If

                End If

            End If

        End Sub
        'Protected Overrides Function CreateDefaultView() As DevExpress.XtraGrid.Views.Base.BaseView

        '    CreateDefaultView = CreateView("BandedGridViewControl")

        'End Function
        Protected Overrides Sub RegisterAvailableViewsCore(collection As DevExpress.XtraGrid.Registrator.InfoCollection)

			MyBase.RegisterAvailableViewsCore(collection)

            collection.Add(New AdvantageFramework.WinForm.MVC.Presentation.Controls.Classes.CustomAdvBandedGridViewInfoRegistrator())

        End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

	End Class

End Namespace

