Namespace WinForm.MVC.Presentation.Controls.Validation

	Public Class CustomValidatorControl
		Inherits DevComponents.DotNetBar.Validator.ValidatorBase

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

			MyBase.New()

			Me.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red

		End Sub
		Public Overloads Overrides Function Validate(ByVal Control As System.Windows.Forms.Control) As Boolean

			'objects
			Dim IsValid As Boolean = True

			Me.ErrorMessage = ""

            If Control.IsDisposed = False AndAlso Control.Enabled Then

                If TypeOf Control Is AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox Then

                    IsValid = DirectCast(Control, AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox).Validate(Me.ErrorMessage)

                ElseIf TypeOf Control Is AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox Then

                    IsValid = DirectCast(Control, AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox).Validate(Me.ErrorMessage)

                ElseIf TypeOf Control Is AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox Then

                    IsValid = DirectCast(Control, AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox).Validate(Me.ErrorMessage)

                ElseIf TypeOf Control Is AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView Then

                    IsValid = DirectCast(Control, AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView).CustomValidate(Me.ErrorMessage)

                ElseIf TypeOf Control Is AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput Then

                    IsValid = DirectCast(Control, AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput).Validate(Me.ErrorMessage)

                ElseIf TypeOf Control Is AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit Then

                    IsValid = DirectCast(Control, AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit).Validate(Me.ErrorMessage)

                End If

            End If

			Me.DisplayError = Not IsValid

			Validate = IsValid

		End Function

#End Region

	End Class

End Namespace

