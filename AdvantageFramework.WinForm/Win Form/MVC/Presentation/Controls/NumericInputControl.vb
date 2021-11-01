Namespace WinForm.MVC.Presentation.Controls

	Public Class NumericInput
		Inherits DevExpress.XtraEditors.SpinEdit
		Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl
		Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Type
			[Default]
			[Decimal]
			[Byte]
			[Short]
			[Integer]
			[Long]
			[Currency]
			[Percent]
		End Enum

#End Region

#Region " Variables "

		Protected _ControlType As NumericInput.Type = NumericInput.Type.Default
		Protected _IsRequired As Boolean = False
		Protected _DisplayName As String = ""
		Protected _EntityDataType As System.Type = Nothing
		Protected _UserEntryChanged As Boolean = False
		Protected _ByPassUserEntryChanged As Boolean = False
		Protected _SuspendedForLoading As Boolean = False
        Protected _FormSettingsLoaded As Boolean = False
        Protected _AllowKeyUpAndDownToInBooleancrementValue As Boolean = False
		Private _SecurityEnabled As Boolean = True
		Protected _ErrorIconAlignment As System.Windows.Forms.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
		Protected _TabOnEnter As Boolean = True
		Protected _ReadOnly As Boolean = False

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
			Set(ByVal value As Boolean)
				_ByPassUserEntryChanged = value
			End Set
		End Property
		Public WriteOnly Property SuspendedForLoading As Boolean Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.SuspendedForLoading
			Set(value As Boolean)
				_SuspendedForLoading = value
			End Set
		End Property
		Public Property ControlType() As NumericInput.Type
			Get
				ControlType = _ControlType
			End Get
			Set(ByVal value As NumericInput.Type)
				_ControlType = value
				SetControlType()
			End Set
		End Property
		Public Property AllowKeyUpAndDownToIncrementValue() As Boolean
			Get
				AllowKeyUpAndDownToIncrementValue = _AllowKeyUpAndDownToInBooleancrementValue
			End Get
			Set(ByVal value As Boolean)
				_AllowKeyUpAndDownToInBooleancrementValue = value
			End Set
		End Property
		Public Overloads Property ErrorIconAlignment() As System.Windows.Forms.ErrorIconAlignment
			Get
				ErrorIconAlignment = _ErrorIconAlignment
			End Get
			Set(ByVal value As System.Windows.Forms.ErrorIconAlignment)
				_ErrorIconAlignment = value
			End Set
		End Property
		Public Overrides Property EnterMoveNextControl As Boolean
			Get
				Return _TabOnEnter
			End Get
			Set(value As Boolean)
				_TabOnEnter = True
			End Set
		End Property
		Public Overloads Property [ReadOnly] As Boolean
			Get
				[ReadOnly] = _ReadOnly
			End Get
			Set(ByVal value As Boolean)
				_ReadOnly = value
				Me.Properties.ReadOnly = _ReadOnly
				SetBackColor()
			End Set
		End Property

#End Region

#Region " Methods "

		Public Sub New()

			Me.LookAndFeel.SkinName = "Office 2016 Colorful"
			Me.LookAndFeel.UseDefaultLookAndFeel = False
			Me.Size = New System.Drawing.Size(75, 20)

			For Each EditorButton In Me.Properties.Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton).ToList

				EditorButton.Visible = False

			Next

			Me.DoubleBuffered = True

		End Sub
		Protected Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form) Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl.LoadFormSettings

			If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
			   Form.Controls.Find(Me.Name, True).Any Then

				If TypeOf Form Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm Then

					If DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

						DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.MVC.Presentation.Controls.Validation.CustomValidatorControl)

						DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.ErrorProvider.SetIconAlignment(Me, Me.ErrorIconAlignment)

					End If

                End If

				_FormSettingsLoaded = True

			End If

		End Sub
		Public Sub ClearChanged() Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.ClearChanged

			_UserEntryChanged = False

		End Sub
		Public Sub SetPropertySettings(Optional ByVal DisplayName As String = "",
									   Optional ByVal IsRequired As Boolean = False)

			If DisplayName <> "" Then

				_DisplayName = DisplayName

			End If

			SetRequired(IsRequired)

		End Sub
		Public Sub SetPropertySettings(ByVal EnumProperty As [Enum])

			'objects
			Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

			Try

				PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(System.ComponentModel.TypeDescriptor.GetReflectionType(EnumProperty.GetType).DeclaringType).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(PropDesc) PropDesc.Name.ToUpper = EnumProperty.ToString.ToUpper).SingleOrDefault

			Catch ex As Exception
				PropertyDescriptor = Nothing
			End Try

			SetPropertySettings(PropertyDescriptor)

		End Sub
		Public Sub SetPropertySettings(ByVal PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor), ByVal EnumProperty As [Enum])

			'objects
			Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

			Try

				PropertyDescriptor = PropertyDescriptorsList.SingleOrDefault(Function(PropDesc) PropDesc.Name.ToUpper = EnumProperty.ToString.ToUpper)

			Catch ex As Exception
				PropertyDescriptor = Nothing
			End Try

			SetPropertySettings(PropertyDescriptor)

		End Sub
		Public Sub SetRequired(ByVal IsRequired As Boolean)

			_IsRequired = IsRequired

			SetBackColor()

		End Sub
		Public Sub SetFormat(ByVal FormatString As String)

			Me.Properties.DisplayFormat.FormatString = FormatString
			Me.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
			Me.Properties.EditFormat.FormatString = FormatString
			Me.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
			Me.Properties.Mask.EditMask = FormatString

		End Sub
		Protected Overridable Sub SetControlType()

			Select Case _ControlType

				Case NumericInput.Type.Default

					Me.Properties.IsFloatValue = True
					Me.Properties.DisplayFormat.FormatString = "f"
					Me.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.Properties.EditFormat.FormatString = "f"
					Me.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.Properties.Mask.EditMask = "f"
					Me.Properties.Mask.UseMaskAsDisplayFormat = True

				Case NumericInput.Type.Decimal

					Me.Properties.IsFloatValue = True
					Me.Properties.DisplayFormat.FormatString = "f"
					Me.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.Properties.EditFormat.FormatString = "f"
					Me.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.Properties.Mask.EditMask = "f"
					Me.Properties.Mask.UseMaskAsDisplayFormat = True

				Case NumericInput.Type.Byte

					Me.Properties.IsFloatValue = False
					Me.Properties.DisplayFormat.FormatString = "f0"
					Me.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.Properties.EditFormat.FormatString = "f0"
					Me.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.Properties.Mask.EditMask = "f0"
					Me.Properties.Mask.UseMaskAsDisplayFormat = True
					Me.Properties.MaxValue = 255
					Me.Properties.MinValue = 0

				Case NumericInput.Type.Short

					Me.Properties.IsFloatValue = False
					Me.Properties.DisplayFormat.FormatString = "f0"
					Me.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.Properties.EditFormat.FormatString = "f0"
					Me.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.Properties.Mask.EditMask = "f0"
					Me.Properties.Mask.UseMaskAsDisplayFormat = True
					Me.Properties.MaxValue = 32767
					Me.Properties.MinValue = -32768

				Case NumericInput.Type.Integer

					Me.Properties.IsFloatValue = False
					Me.Properties.DisplayFormat.FormatString = "f0"
					Me.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.Properties.EditFormat.FormatString = "f0"
					Me.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.Properties.Mask.EditMask = "f0"
					Me.Properties.Mask.UseMaskAsDisplayFormat = True
					Me.Properties.MaxValue = 2147483647
					Me.Properties.MinValue = -2147483648

				Case NumericInput.Type.Long

					Me.Properties.IsFloatValue = False
					Me.Properties.DisplayFormat.FormatString = "f0"
					Me.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.Properties.EditFormat.FormatString = "f0"
					Me.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.Properties.Mask.EditMask = "f0"
					Me.Properties.Mask.UseMaskAsDisplayFormat = True
					Me.Properties.MaxValue = 9223372036854775807
					Me.Properties.MinValue = -9223372036854775807

				Case NumericInput.Type.Currency

					Me.Properties.IsFloatValue = True
					Me.Properties.DisplayFormat.FormatString = "c2"
					Me.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.Properties.EditFormat.FormatString = "c2"
					Me.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.Properties.Mask.EditMask = "c2"
					Me.Properties.Mask.UseMaskAsDisplayFormat = True

				Case NumericInput.Type.Percent

					Me.Properties.IsFloatValue = True
					Me.Properties.DisplayFormat.FormatString = "p2"
					Me.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.Properties.EditFormat.FormatString = "p2"
					Me.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
					Me.Properties.Mask.EditMask = "p2"
					Me.Properties.Mask.UseMaskAsDisplayFormat = True

			End Select

		End Sub
		Protected Friend Function Validate(ByRef ErrorMessage As String) As Boolean

			'objects
			Dim IsValid As Boolean = True

			Try

				If _IsRequired AndAlso Not _ReadOnly Then

					If Me.Text.Trim = "" Then

						ErrorMessage = _DisplayName & " is required"

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

			'objects
			Dim InputValue As Object = Nothing

			If Me.EditValue IsNot Nothing OrElse Me.EditValue <> Nothing Then

				If _ControlType = NumericInput.Type.Default OrElse _ControlType = NumericInput.Type.Decimal OrElse
						_ControlType = NumericInput.Type.Currency OrElse _ControlType = NumericInput.Type.Percent Then

					InputValue = Convert.ToDecimal(Me.EditValue)

				ElseIf _ControlType = NumericInput.Type.Byte Then

					InputValue = Convert.ToByte(Me.EditValue)

				ElseIf _ControlType = NumericInput.Type.Short Then

					InputValue = Convert.ToInt16(Me.EditValue)

				ElseIf _ControlType = NumericInput.Type.Integer Then

					InputValue = Convert.ToInt32(Me.EditValue)

				ElseIf _ControlType = NumericInput.Type.Long Then

					InputValue = Convert.ToInt64(Me.EditValue)

				End If

			End If

			GetValue = InputValue

		End Function
		Public Sub SetPropertySettings(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor)

			'objects
			Dim Scale As Long = 0
			Dim Precision As Long = 0
			Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
			Dim MaxValue As Decimal = 0
			Dim MinValue As Decimal = 0
			Dim DisplayFormat As String = ""

			Me.BeginUpdate()

			If PropertyDescriptor IsNot Nothing Then

				_EntityDataType = PropertyDescriptor.PropertyType

				If _ControlType <> Type.Currency AndAlso _ControlType <> Type.Percent Then

					If _EntityDataType = GetType(Nullable(Of Byte)) OrElse _EntityDataType = GetType(Byte) Then

						_ControlType = Type.Byte

					ElseIf _EntityDataType = GetType(Nullable(Of Short)) OrElse _EntityDataType = GetType(Short) Then

						_ControlType = Type.Short

					ElseIf _EntityDataType = GetType(Nullable(Of Integer)) OrElse _EntityDataType = GetType(Integer) Then

						_ControlType = Type.Integer

					ElseIf _EntityDataType = GetType(Nullable(Of Long)) OrElse _EntityDataType = GetType(Long) Then

						_ControlType = Type.Long

					End If

				End If

				SetControlType()

				If _EntityDataType.IsPrimitive Then

					Me.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

				Else

					Me.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True

				End If

				Try

					EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

				Catch ex As Exception
					EntityAttribute = Nothing
				Finally

					If EntityAttribute IsNot Nothing Then

						SetRequired(EntityAttribute.IsRequired)

						If EntityAttribute.UseMaxValue Then

							MaxValue = EntityAttribute.MaxValue

						End If

						If EntityAttribute.UseMinValue Then

							MinValue = EntityAttribute.MinValue

						End If

						DisplayFormat = EntityAttribute.DisplayFormat

					End If

				End Try

			End If

			If PropertyDescriptor IsNot Nothing Then

				_DisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(PropertyDescriptor.Name)

				If _ControlType <> Type.Byte AndAlso _ControlType <> Type.Short AndAlso
						_ControlType <> Type.Integer AndAlso _ControlType <> Type.Long Then

					Scale = AdvantageFramework.BaseClasses.Entity.LoadPropertyScale(PropertyDescriptor)
					Precision = AdvantageFramework.BaseClasses.Entity.LoadPropertyPrecision(PropertyDescriptor)

					If DisplayFormat = "" Then

						If Scale > 0 Then

							If _ControlType = NumericInput.Type.Default OrElse _ControlType = NumericInput.Type.Decimal Then

								DisplayFormat = "n" & Scale

							ElseIf _ControlType = NumericInput.Type.Currency Then

								DisplayFormat = "c" & Scale

							ElseIf _ControlType = NumericInput.Type.Percent Then

								DisplayFormat = "p" & Scale

							End If

						End If

					End If

					If Precision > 0 Then

						If MaxValue = 0 Then

							Try

								MaxValue = ((10 ^ (Precision - Scale)) - 1) + ((10 ^ Scale) - 1) / (10 ^ Scale)

							Catch ex As Exception

							End Try

						End If

					End If

				End If

			Else

				If PropertyDescriptor IsNot Nothing Then

					_DisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(PropertyDescriptor.Name)

				End If

			End If

			Me.Properties.MaxValue = MaxValue
			Me.Properties.MinValue = MinValue

			If DisplayFormat <> "" Then

				SetFormat(DisplayFormat)

			End If

			Me.EndUpdate()

		End Sub
		Protected Overrides Sub OnKeyDown(e As Windows.Forms.KeyEventArgs)

			If _TabOnEnter Then

				If e.KeyCode = System.Windows.Forms.Keys.Enter AndAlso e.Shift = True Then

					Me.FindForm.SelectNextControl(Me, False, True, True, True)

				End If

			End If

			MyBase.OnKeyDown(e)

		End Sub
		Protected Overloads Sub SetBackColor()

			If _ReadOnly Then

				Me.BackColor = System.Drawing.SystemColors.Control

			ElseIf _IsRequired Then

				Me.BackColor = Drawing.Color.Cyan

			Else

				Me.BackColor = Drawing.Color.White

			End If

		End Sub

#Region "  Control Event Handlers "

		Private Sub NumericInput_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.EditValueChanged

			If _ByPassUserEntryChanged = False AndAlso _SuspendedForLoading = False Then

				_UserEntryChanged = True

				AdvantageFramework.WinForm.MVC.Presentation.Controls.UserEntryChanged(Me)

			End If

		End Sub
		Private Sub NumericInput_Spin(sender As Object, e As DevExpress.XtraEditors.Controls.SpinEventArgs) Handles Me.Spin

			If e.IsSpinUp Then

				If Me.Properties.MaxValue > 0 Then

					If (Me.EditValue + Me.Properties.Increment) > Me.Properties.MaxValue Then

						e.Handled = True

					End If

				End If

			End If

		End Sub
		Private Sub NumericInput_PropertiesChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PropertiesChanged

			If TypeOf e Is System.ComponentModel.PropertyChangedEventArgs AndAlso DirectCast(e, System.ComponentModel.PropertyChangedEventArgs).PropertyName = "ReadOnly" Then

				Me.TabStop = Not Me.Properties.ReadOnly

			End If

			Me.Properties.MaxLength = 0 ' Do not remove! Use MaxValue & MinValue to control input!!

		End Sub
		Private Sub NumericInput_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles Me.KeyDown

			If e.KeyCode = Windows.Forms.Keys.Up OrElse e.KeyCode = Windows.Forms.Keys.Down Then

				If Me.AllowKeyUpAndDownToIncrementValue = False Then

					e.Handled = True
					e.SuppressKeyPress = True

				End If

			End If

		End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

	End Class

End Namespace