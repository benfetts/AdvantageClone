Namespace WinForm.MVC.Presentation.Controls

	Public Class SubItemNumericInput
		Inherits DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum [Type]
			[Default]
			[Decimal]
			[Short]
			[Integer]
			[Long]
			[Currency]
			[Percent]
			[Double]
		End Enum

#End Region

#Region " Variables "

		Protected _ControlType As SubItemNumericInput.Type = SubItemNumericInput.Type.Default
		'Protected _DbContext As AdvantageFramework.Database.DbContext = Nothing
		Protected _ShowSpinButton As Boolean = False
		Protected _AllowKeyUpAndDownToInBooleancrementValue As Boolean = False

#End Region

#Region " Properties "

		Public Property AllowKeyUpAndDownToIncrementValue() As Boolean
			Get
				AllowKeyUpAndDownToIncrementValue = _AllowKeyUpAndDownToInBooleancrementValue
			End Get
			Set(ByVal value As Boolean)
				_AllowKeyUpAndDownToInBooleancrementValue = value
			End Set
		End Property
		Public Property ShowSpinButton As Boolean
			Get
				ShowSpinButton = _ShowSpinButton
			End Get
			Set(ByVal value As Boolean)

				_ShowSpinButton = value

				If _ShowSpinButton Then

					ShowButtons()

				Else

					HideButtons()

				End If

			End Set
		End Property
		Public Property ControlType() As SubItemNumericInput.Type
			Get
				ControlType = _ControlType
			End Get
			Set(ByVal value As SubItemNumericInput.Type)
				_ControlType = value
				SetControlType()
			End Set
		End Property
		'Public Property DbContext() As AdvantageFramework.Database.DbContext
		'    Get
		'        DbContext = _DbContext
		'    End Get
		'    Set(ByVal value As AdvantageFramework.Database.DbContext)
		'        _DbContext = value
		'    End Set
		'End Property

#End Region

#Region " Methods "

		Public Sub New()

			Me.LookAndFeel.SkinName = "Office 2016 Colorful"
			Me.LookAndFeel.UseDefaultLookAndFeel = False

		End Sub
		Public Sub SetFormatString(ByVal FormatString As String)

			Me.EditMask = FormatString
			Me.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
			Me.DisplayFormat.FormatString = FormatString
			Me.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
			Me.EditFormat.FormatString = FormatString
			Me.Mask.EditMask = FormatString
			Me.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric

		End Sub
		Protected Sub SetControlType()

			Select Case _ControlType

				Case SubItemNumericInput.Type.Default

					Me.EditMask = ""
					Me.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.DisplayFormat.FormatString = ""
					Me.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.EditFormat.FormatString = ""
					Me.Mask.UseMaskAsDisplayFormat = False
					Me.Mask.EditMask = ""
					Me.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
					Me.IsFloatValue = False

				Case SubItemNumericInput.Type.Short

					Me.EditMask = "f0"
					Me.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.DisplayFormat.FormatString = "f0"
					Me.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.EditFormat.FormatString = "f0"
					Me.Mask.UseMaskAsDisplayFormat = True
					Me.Mask.EditMask = "f0"
					Me.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
					Me.IsFloatValue = False

					Me.MaxLength = 6
					Me.MaxValue = 32767
					Me.MinValue = -32768

				Case SubItemNumericInput.Type.[Integer]

					Me.EditMask = "f0"
					Me.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.DisplayFormat.FormatString = "f0"
					Me.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.EditFormat.FormatString = "f0"
					Me.Mask.UseMaskAsDisplayFormat = True
					Me.Mask.EditMask = "f0"
					Me.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
					Me.IsFloatValue = False

					Me.MaxLength = 11
					Me.MaxValue = 2147483647
					Me.MinValue = -2147483648

				Case SubItemNumericInput.Type.Long

					Me.EditMask = "f0"
					Me.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.DisplayFormat.FormatString = "f0"
					Me.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.EditFormat.FormatString = "f0"
					Me.Mask.UseMaskAsDisplayFormat = True
					Me.Mask.EditMask = "f0"
					Me.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
					Me.IsFloatValue = False

					Me.MaxLength = 20
					Me.MaxValue = 9223372036854775807
					Me.MinValue = -9223372036854775807

				Case SubItemNumericInput.Type.[Decimal]

					Me.EditMask = "f2"
					Me.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.DisplayFormat.FormatString = "f2"
					Me.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.EditFormat.FormatString = "f2"
					Me.Mask.UseMaskAsDisplayFormat = True
					Me.Mask.EditMask = "f2"
					Me.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
					Me.IsFloatValue = True

				Case SubItemNumericInput.Type.[Currency]

					Me.EditMask = "c2"
					Me.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.DisplayFormat.FormatString = "c2"
					Me.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.EditFormat.FormatString = "c2"
					Me.Mask.UseMaskAsDisplayFormat = True
					Me.Mask.EditMask = "c2"
					Me.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
					Me.IsFloatValue = True

				Case SubItemNumericInput.Type.[Double]

					Me.EditMask = "f2"
					Me.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.DisplayFormat.FormatString = "f2"
					Me.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.EditFormat.FormatString = "f2"
					Me.Mask.UseMaskAsDisplayFormat = True
					Me.Mask.EditMask = "f2"
					Me.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
					Me.IsFloatValue = True


			End Select

			If Me.ShowSpinButton Then

				ShowButtons()

			Else

				HideButtons()

			End If

		End Sub
		Protected Sub HideButtons()

			For Each EditorButton In Me.Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton)()

				EditorButton.Enabled = False
				EditorButton.Visible = False

			Next

		End Sub
		Protected Sub ShowButtons()

			For Each EditorButton In Me.Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton)()

				EditorButton.Enabled = True
				EditorButton.Visible = True

			Next

		End Sub
		Private Sub AddEllipsisButton()

			If CheckForExistingButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) = False Then

				Me.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis))

			End If

		End Sub
		Private Function CheckForExistingButton(ByVal ButtonPredefines As DevExpress.XtraEditors.Controls.ButtonPredefines) As Boolean

			'objects
			Dim ButtonExists As Boolean = False

			For Each EditorButton In Me.Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton)()

				If EditorButton.Kind = ButtonPredefines Then

					ButtonExists = True
					Exit For

				End If

			Next

			CheckForExistingButton = ButtonExists

		End Function
		Protected Sub SetValue(ByVal Value As Object)

			'objects
			Dim DictionaryEntry As System.Collections.DictionaryEntry = Nothing

			Try

				For Each DictionaryEntry In Me.Links

					If DictionaryEntry.Key IsNot Nothing Then

						If TypeOf DictionaryEntry.Key Is DevExpress.XtraGrid.Columns.GridColumn Then

							DirectCast(DictionaryEntry.Key, DevExpress.XtraGrid.Columns.GridColumn).View.ActiveEditor.EditValue = Value

						End If

					End If

				Next

			Catch ex As Exception

			End Try

		End Sub

#Region "  Control Event Handlers "

		Private Sub SubItemNumericInput_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles Me.ButtonClick

			Select Case _ControlType

				Case SubItemNumericInput.Type.Default



			End Select

		End Sub
		Private Sub SubItemNumericInput_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles Me.EditValueChanging



		End Sub
		Private Sub SubItemNumericInput_Spin(sender As Object, e As DevExpress.XtraEditors.Controls.SpinEventArgs) Handles Me.Spin

			If e.IsSpinUp Then

				If TypeOf sender Is DevExpress.XtraEditors.SpinEdit Then

					If (CType(sender, DevExpress.XtraEditors.SpinEdit).EditValue + Me.Increment).ToString.Length > Me.MaxLength Then

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