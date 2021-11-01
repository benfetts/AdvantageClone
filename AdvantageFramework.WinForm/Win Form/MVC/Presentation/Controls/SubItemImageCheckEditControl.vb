Namespace WinForm.MVC.Presentation.Controls

	Public Class SubItemImageCheckEditControl
		Inherits DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum [Type]
			[Default]
			YesNoSkip
			ImageWhenChecked
			ImageWhenUnChecked
		End Enum

#End Region

#Region " Variables "

		Protected _DbContext As AdvantageFramework.Database.DbContext = Nothing
		Protected _ControlType As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemImageCheckEditControl.Type = Type.Default

#End Region

#Region " Properties "

		Public Property DbContext() As AdvantageFramework.Database.DbContext
			Get
				DbContext = _DbContext
			End Get
			Set(ByVal value As AdvantageFramework.Database.DbContext)
				_DbContext = value
			End Set
		End Property
		Public Property ControlType() As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemImageCheckEditControl.Type
			Get
				ControlType = _ControlType
			End Get
			Set(ByVal value As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemImageCheckEditControl.Type)
				_ControlType = value
				SetControlType()
			End Set
		End Property

#End Region

#Region " Methods "

		Public Sub New()

			Me.LookAndFeel.SkinName = "Office 2016 Colorful"
			Me.LookAndFeel.UseDefaultLookAndFeel = False

			Me.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText

			Me.DisplayValueChecked = "Yes"
			Me.DisplayValueUnchecked = "No"
			Me.DisplayValueGrayed = "No"
			Me.ValueGrayed = Nothing
			Me.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined

		End Sub
		Private Sub SetControlType()

			Select Case _ControlType

				Case Type.Default



				Case Type.YesNoSkip

					Me.ValueChecked = Convert.ToInt16(1)
					Me.ValueUnchecked = Convert.ToInt16(0)
					Me.DisplayValueGrayed = "Skip"
					Me.PictureChecked = AdvantageFramework.My.Resources.SmallGreenCircleImage
					Me.PictureGrayed = AdvantageFramework.My.Resources.SmallBlueCircleArrowDownImage
					Me.PictureUnchecked = AdvantageFramework.My.Resources.SmallRedCircleImage

				Case Type.ImageWhenChecked

					Me.ValueChecked = True
					Me.ValueUnchecked = False
					Me.DisplayValueGrayed = "No"
					Me.PictureChecked = AdvantageFramework.My.Resources.SmallCheckMarkImage
					Me.PictureGrayed = Nothing
					Me.PictureUnchecked = Nothing

				Case Type.ImageWhenUnChecked

					Me.ValueChecked = Convert.ToInt16(0)
					Me.ValueUnchecked = Convert.ToInt16(1)
					Me.DisplayValueGrayed = "1"
					Me.PictureChecked = AdvantageFramework.My.Resources.SmallCheckMarkImage
					Me.PictureGrayed = Nothing
					Me.PictureUnchecked = Nothing

			End Select

		End Sub

#Region "  Control Event Handlers "

		Private Sub SubItemImageCheckEditControl_QueryCheckStateByValue(sender As Object, e As DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventArgs) Handles Me.QueryCheckStateByValue

			Try

				If _ControlType = Type.ImageWhenChecked Then

					If IsNumeric(e.Value) Then

						If Convert.ToInt64(e.Value) > 0 Then

							e.CheckState = Windows.Forms.CheckState.Checked

						Else

							e.CheckState = Windows.Forms.CheckState.Unchecked

						End If

						e.Handled = True

					End If

				End If

			Catch ex As Exception

			End Try

		End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

	End Class

End Namespace