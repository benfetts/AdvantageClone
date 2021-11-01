Namespace WinForm.MVC.Presentation.Controls

	Public Class SubItemMemoEdit
		Inherits DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum [Type]
			[Default]
		End Enum

#End Region

#Region " Variables "

		Protected _ControlType As SubItemComboBox.Type = SubItemComboBox.Type.Default
        Protected _OpenPopupOnKeyPress As Boolean = True
        Protected _CloseOnTab As Boolean = True
		Protected _ApplyKeyChar As String = Nothing

#End Region

#Region " Properties "

        Public Property ControlType() As SubItemComboBox.Type
            Get
                ControlType = _ControlType
            End Get
            Set(ByVal value As SubItemComboBox.Type)
                _ControlType = value
                SetControlType()
            End Set
        End Property
        Public Property OpenPopupOnKeyPress As Boolean
			Get
				OpenPopupOnKeyPress = _OpenPopupOnKeyPress
			End Get
			Set(ByVal value As Boolean)
				_OpenPopupOnKeyPress = value
			End Set
		End Property
		Public Property CloseOnTab As Boolean
			Get
				CloseOnTab = _CloseOnTab
			End Get
			Set(value As Boolean)
				_CloseOnTab = value
			End Set
		End Property

#End Region

#Region " Methods "

		Protected Sub SetControlType()

			Select Case _ControlType

				Case SubItemComboBox.Type.Default


			End Select

		End Sub

#Region "  Control Event Handlers "

		Public Sub New()

			Me.LookAndFeel.SkinName = "Office 2016 Colorful"
			Me.LookAndFeel.UseDefaultLookAndFeel = False

			Me.AcceptsTab = True
			Me.CloseUpKey = New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4)

		End Sub

#End Region

#Region "  Custom Control Event Handlers "

		Private Sub SubItemMemoEdit_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

			'objects
			Dim MemoExEdit As DevExpress.XtraEditors.MemoExEdit = Nothing

			If _OpenPopupOnKeyPress Then

				Try

					MemoExEdit = DirectCast(sender, DevExpress.XtraEditors.MemoExEdit)

				Catch ex As Exception
					MemoExEdit = Nothing
				End Try

				If MemoExEdit IsNot Nothing AndAlso Not MemoExEdit.ReadOnly Then

					If Char.IsControl(e.KeyChar) Then

						e.Handled = True

					Else

						If MemoExEdit.IsPopupOpen = False Then

							_ApplyKeyChar = e.KeyChar.ToString

							MemoExEdit.ShowPopup()

							e.Handled = True

						End If

					End If

				End If

			End If

		End Sub
		Private Sub SubItemMemoEdit_Popup(sender As Object, e As EventArgs) Handles Me.Popup

			Dim MemoEdit As DevExpress.XtraEditors.MemoEdit = Nothing
			Dim MemoExEdit As DevExpress.XtraEditors.MemoExEdit = Nothing
			Dim MemoExPopupForm As DevExpress.XtraEditors.Popup.MemoExPopupForm = Nothing

			Try

				MemoExEdit = DirectCast(sender, DevExpress.XtraEditors.MemoExEdit)

				MemoExPopupForm = DirectCast(MemoExEdit, DevExpress.Utils.Win.IPopupControl).PopupWindow

			Catch ex As Exception
				MemoExEdit = Nothing
			End Try

			If MemoExPopupForm IsNot Nothing Then

				Try

					MemoEdit = MemoExPopupForm.Controls.OfType(Of DevExpress.XtraEditors.MemoEdit).SingleOrDefault

					If _ApplyKeyChar IsNot Nothing Then

						MemoEdit.Text = MemoEdit.Text & _ApplyKeyChar

						_ApplyKeyChar = Nothing

					End If

					MemoEdit.Select(MemoEdit.Text.Length, 0)

					AddHandler MemoEdit.KeyDown, AddressOf MemoEdit_KeyDown

				Catch ex As Exception
					MemoEdit = Nothing
				End Try

			End If

		End Sub
		Private Sub MemoEdit_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs)

			'objects
			Dim MemoExEdit As DevExpress.XtraEditors.MemoExEdit = Nothing
			Dim MemoEdit As DevExpress.XtraEditors.MemoEdit = Nothing
			Dim MemoExPopupForm As DevExpress.XtraEditors.Popup.MemoExPopupForm = Nothing

			If e.KeyCode = Windows.Forms.Keys.Tab Then

				If _CloseOnTab Then

					Try

						MemoEdit = DirectCast(sender, DevExpress.XtraEditors.MemoEdit)
						MemoExPopupForm = DirectCast(MemoEdit.Parent, DevExpress.XtraEditors.Popup.MemoExPopupForm)
						MemoExEdit = DirectCast(MemoExPopupForm.OwnerEdit, DevExpress.XtraEditors.MemoExEdit)

					Catch ex As Exception

					End Try

					If MemoExEdit IsNot Nothing Then

						e.Handled = True
						MemoExEdit.ClosePopup()

					End If

				End If

			End If

		End Sub

#End Region

#End Region

	End Class

End Namespace