Namespace WinForm.MVC.Presentation.Controls

	Public Class FindPanel
		Inherits DevExpress.XtraGrid.Controls.FindControl

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New(ByVal ColumnView As DevExpress.XtraGrid.Views.Base.ColumnView, ByVal Properties As Object)

			MyBase.New(ColumnView, Properties)

            Me.FindEdit.Properties.Buttons(0).Visible = False
            Me.DoubleBuffered = True

            AddHandler Me.FindEdit.EditValueChanging, AddressOf EditValueChanging

        End Sub
		Public Sub EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

			Try

				If String.IsNullOrEmpty(e.NewValue) = False Then

					If TypeOf Me.View Is AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView Then

						CType(Me.View, AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView).RaiseBeforeLeaveRowEvent()

					End If

				End If

			Catch ex As Exception

			End Try

		End Sub

#Region "  Control Event Handlers "



#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

	End Class

End Namespace
