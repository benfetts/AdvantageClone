Namespace WinForm.MVC.Presentation.Controls

	Public Class TimeEdit
		Inherits DevExpress.XtraEditors.TimeEdit
		Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl
		Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum [Type]
			[Default]
		End Enum

#End Region

#Region " Variables "

		Protected _ControlType As TimeEdit.Type = TimeEdit.Type.Default
		Protected _IsRequired As Boolean = False
		Protected _DisplayName As String = ""
		Protected _FormSettingsLoaded As Boolean = False
		Protected _ErrorIconAlignment As System.Windows.Forms.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
		Protected _UserEntryChanged As Boolean = False
		Protected _ByPassUserEntryChanged As Boolean = False
		Protected _ReadOnly As Boolean = False
		Protected _SuspendedForLoading As Boolean = False
		Protected _ShowingButtons As Boolean = False
		Protected _TabOnEnter As Boolean = True

#End Region

#Region " Properties "

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
		Public Property DisplayName As String
			Get
				DisplayName = _DisplayName
			End Get
			Set(value As String)
				_DisplayName = value
			End Set
		End Property
		Public Property TabOnEnter() As Boolean
			Get
				TabOnEnter = _TabOnEnter
			End Get
			Set(value As Boolean)
				_TabOnEnter = value
			End Set
		End Property
		Public Property ControlType() As AdvantageFramework.WinForm.MVC.Presentation.Controls.TimeEdit.Type
			Get
				ControlType = _ControlType
			End Get
			Set(value As AdvantageFramework.WinForm.MVC.Presentation.Controls.TimeEdit.Type)
				_ControlType = value
				SetControlType()
			End Set
		End Property

#End Region

#Region " Methods "

		Public Sub New()

			Me.Size = New System.Drawing.Size(75, 20)

			Me.LookAndFeel.SkinName = "Office 2016 Colorful"
			Me.LookAndFeel.UseDefaultLookAndFeel = False
			Me.DoubleBuffered = True

		End Sub
		Public Sub ClearChanged() Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.ClearChanged

			_UserEntryChanged = False

		End Sub
		Protected Sub LoadFormSettings(Form As System.Windows.Forms.Form) Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl.LoadFormSettings

			If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
					Form.Controls.Find(Me.Name, True).Any Then

				If TypeOf Form Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm Then

					If DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

						DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.MVC.Presentation.Controls.Validation.CustomValidatorControl)

						DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.ErrorProvider.SetIconAlignment(Me, _ErrorIconAlignment)

					End If

				End If

				_FormSettingsLoaded = True

			End If

		End Sub
		Public Sub SetPropertySettings(PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor), EnumProperty As [Enum], Optional CustomDisplayName As String = "")

			'objects
			Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

			Try

				PropertyDescriptor = PropertyDescriptorsList.SingleOrDefault(Function(PropDesc) PropDesc.Name.ToUpper = EnumProperty.ToString.ToUpper)

			Catch ex As Exception
				PropertyDescriptor = Nothing
			End Try

			SetPropertySettings(PropertyDescriptor, CustomDisplayName)

		End Sub
		Public Sub SetPropertySettings(PropertyDescriptor As System.ComponentModel.PropertyDescriptor, Optional CustomDisplayName As String = "")

			'objects
			Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

			If PropertyDescriptor IsNot Nothing Then

				_DisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(PropertyDescriptor.Name)

				Try

					EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

				Catch ex As Exception
					EntityAttribute = Nothing
				Finally

					If EntityAttribute IsNot Nothing Then

						SetRequired(EntityAttribute.IsRequired)

					End If

				End Try

			End If

			If CustomDisplayName <> "" Then

				_DisplayName = CustomDisplayName

			End If

		End Sub
		Public Sub SetPropertySettings(EnumProperty As [Enum], Optional CustomDisplayName As String = "")

			'objects
			Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

			Try

				PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(System.ComponentModel.TypeDescriptor.GetReflectionType(EnumProperty.GetType).DeclaringType).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(PropDesc) PropDesc.Name.ToUpper = EnumProperty.ToString.ToUpper).SingleOrDefault

			Catch ex As Exception
				PropertyDescriptor = Nothing
			End Try

			SetPropertySettings(PropertyDescriptor, CustomDisplayName)

		End Sub
		Public Sub SetRequired(IsRequired As Boolean)

			_IsRequired = IsRequired

			If _IsRequired Then

				Me.BackColor = Drawing.Color.Cyan

			Else

				Me.BackColor = Drawing.Color.White

			End If

		End Sub
		Protected Sub SetControlType()

			Select Case _ControlType

				Case TimeEdit.Type.Default

					Me.Properties.DisplayFormat.FormatString = "t"
					Me.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

					Me.Properties.EditFormat.FormatString = "t"
					Me.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime

					Me.Properties.Mask.EditMask = "t"

					Me.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret

					Me.Properties.Mask.SaveLiteral = False
					Me.Properties.Mask.ShowPlaceHolders = False

			End Select

		End Sub
		Protected Friend Function Validate(ByRef ErrorMessage As String) As Boolean

			'objects
			Dim IsValid As Boolean = True
			Dim Name As String = ""

			Try

				If _IsRequired Then

					If Me.Text.Trim = "" OrElse Me.EditValue Is Nothing Then

						If _DisplayName <> "" Then

							ErrorMessage = _DisplayName & " is required."

						Else

							Try

								Name = AdvantageFramework.StringUtilities.GetNameAsWords(Me.Name.Substring(Me.Name.IndexOf("_") + 1))

							Catch ex As Exception
								Name = ""
							End Try

							ErrorMessage = Name & " is required."

						End If

						IsValid = False

					End If

				End If

			Catch ex As Exception
				IsValid = False
			Finally
				Validate = IsValid
			End Try

		End Function
		Public Function GetValue() As Object

			Dim Value As Object = Nothing

			If Me.EditValue <> Nothing Then

				Try

					Value = Convert.ToDateTime(Me.EditValue)

				Catch ex As Exception
					Value = Nothing
				End Try

			End If

			GetValue = Value

		End Function
		Public Shadows Sub Show()

			Me.Visible = True

		End Sub
		Public Shadows Sub Hide()

			Me.Visible = False

		End Sub

#Region "  Control Event Handlers "

		Private Sub TimeEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles Me.EditValueChanging

			If _ByPassUserEntryChanged = False AndAlso _SuspendedForLoading = False Then

				_UserEntryChanged = True

				AdvantageFramework.WinForm.MVC.Presentation.Controls.UserEntryChanged(Me)

			End If

		End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

	End Class

End Namespace
