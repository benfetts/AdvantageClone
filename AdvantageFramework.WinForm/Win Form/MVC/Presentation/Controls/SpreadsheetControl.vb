Namespace WinForm.MVC.Presentation.Controls

	Public Class SpreadsheetControl
		Inherits DevExpress.XtraSpreadsheet.SpreadsheetControl
		Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl
		Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Protected _UserEntryChanged As Boolean = False
		Protected _ByPassUserEntryChanged As Boolean = False
		Protected _SuspendedForLoading As Boolean = False
		Protected _FormSettingsLoaded As Boolean = False
		Private _SecurityEnabled As Boolean = True

#End Region

#Region " Properties "

		Public Shadows Property Enabled As Boolean
			Get
				Enabled = MyBase.Enabled
			End Get
			Set(ByVal value As Boolean)

				If _SecurityEnabled Then

					MyBase.Enabled = value

				Else

					MyBase.Enabled = False

				End If

			End Set
		End Property
		Public Property SecurityEnabled As Boolean
			Get
				SecurityEnabled = _SecurityEnabled
			End Get
			Set(ByVal value As Boolean)
				_SecurityEnabled = value
				Me.Enabled = value
			End Set
		End Property
		Public ReadOnly Property UserEntryChanged As Boolean Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.UserEntryChanged
			Get
				UserEntryChanged = _UserEntryChanged
			End Get
		End Property
		Public WriteOnly Property ByPassUserEntryChanged As Boolean Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.ByPassUserEntryChanged
			Set(value As Boolean)
				_ByPassUserEntryChanged = value
			End Set
		End Property
		Public WriteOnly Property SuspendedForLoading As Boolean Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.SuspendedForLoading
			Set(value As Boolean)
				_SuspendedForLoading = value
			End Set
		End Property

#End Region

#Region " Methods "

		Public Sub New()

			MyBase.New

		End Sub
		Protected Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form) Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl.LoadFormSettings

			If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
					Form.Controls.Find(Me.Name, True).Any Then

				_FormSettingsLoaded = True

			End If

		End Sub
		Public Sub ClearChanged() Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.ClearChanged

			_UserEntryChanged = False

		End Sub
		Public Sub SetUserEntryChanged()

			_UserEntryChanged = True

			AdvantageFramework.WinForm.MVC.Presentation.Controls.UserEntryChanged(Me)

		End Sub
		Protected Overrides Function ProcessDialogKey(keyData As System.Windows.Forms.Keys) As Boolean

			If keyData = Windows.Forms.Keys.Tab Then

				If Me.IsCellEditorActive Then

					Me.CloseCellEditor(DevExpress.XtraSpreadsheet.CellEditorEnterValueMode.Default)

					System.Windows.Forms.SendKeys.Send("{TAB}")

					ProcessDialogKey = False

				Else

					ProcessDialogKey = MyBase.ProcessDialogKey(keyData)

				End If

			ElseIf keyData = Windows.Forms.Keys.Down OrElse keyData = Windows.Forms.Keys.Up OrElse keyData = Windows.Forms.Keys.Left OrElse keyData = Windows.Forms.Keys.Right Then

				If Me.IsCellEditorActive Then

					Me.CloseCellEditor(DevExpress.XtraSpreadsheet.CellEditorEnterValueMode.Default)

					System.Windows.Forms.SendKeys.Flush()

					System.Windows.Forms.SendKeys.Send("{" & keyData.ToString.ToUpper & "}")

					'System.Windows.Forms.SendKeys.Flush()

					'System.Windows.Forms.SendKeys.Send("{" & keyData.ToString.ToUpper & "}")

					ProcessDialogKey = False

				Else

					ProcessDialogKey = MyBase.ProcessDialogKey(keyData)

				End If

			Else

				ProcessDialogKey = MyBase.ProcessDialogKey(keyData)

			End If

		End Function

#Region "  Control Event Handlers "



#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

	End Class

End Namespace
