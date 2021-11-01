Namespace Controller

    Public MustInherit Class BaseController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Property Session As AdvantageFramework.Security.Session

#End Region

#Region " Methods "



#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            _Session = Session

        End Sub
		Public Function GetAgency() As AdvantageFramework.Database.Entities.Agency

			Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

			If Me.Session IsNot Nothing Then

				Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

					Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

				End Using

			End If

			GetAgency = Agency

		End Function
		Public Overridable Function ValidateDTO(DbContext As AdvantageFramework.BaseClasses.DbContext, DataContext As AdvantageFramework.BaseClasses.DataContext,
												ByRef DTO As AdvantageFramework.DTO.BaseClass, ByRef IsValid As Boolean) As String

			'objects
			Dim PropertyIsValid As Boolean = True
			Dim PropertyErrorText As String = ""
			Dim ErrorText As String = ""
			Dim Value As Object = Nothing
			Dim OldValue As Object = Nothing

			For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(DTO.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)()

				If PropertyDescriptor.PropertyType IsNot GetType(Byte()) AndAlso (PropertyDescriptor.PropertyType.IsValueType OrElse PropertyDescriptor.PropertyType Is GetType(String)) Then

					OldValue = PropertyDescriptor.GetValue(DTO)
					Value = OldValue

					PropertyErrorText = ValidateDTOProperty(DbContext, DataContext, DTO, PropertyDescriptor, PropertyIsValid, Value)

					If Value <> OldValue OrElse (Value Is Nothing AndAlso OldValue IsNot Nothing) Then

						PropertyDescriptor.SetValue(DTO, Value)

					End If

					If PropertyIsValid = False Then

						If IsValid Then

							IsValid = False

						End If

						ErrorText = IIf(ErrorText = "", PropertyErrorText, ErrorText & Environment.NewLine & PropertyErrorText)

					ElseIf PropertyIsValid AndAlso PropertyErrorText IsNot Nothing AndAlso PropertyErrorText <> "" Then

						ErrorText = IIf(ErrorText = "", PropertyErrorText, ErrorText & Environment.NewLine & PropertyErrorText)

					End If

				End If

			Next

			DTO.SetEntityError(ErrorText)

			ValidateDTO = ErrorText

		End Function
		Public Overridable Function ValidateDTOProperty(DbContext As AdvantageFramework.BaseClasses.DbContext, DataContext As AdvantageFramework.BaseClasses.DataContext, ByRef DTO As AdvantageFramework.DTO.BaseClass,
														PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByRef IsValid As Boolean, ByRef Value As Object) As String

			'objects
			Dim ErrorText As String = ""
			Dim IsEntityKey As Boolean = False
			Dim IsNullable As Boolean = False
			Dim IsRequired As Boolean = False
			Dim MaxLength As Integer = 0
			Dim Precision As Long = 0
			Dim Scale As Long = 0
			Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = AdvantageFramework.BaseClasses.PropertyTypes.Default
			Dim ClientCode As String = Nothing
			Dim DivisionCode As String = Nothing
			Dim DisplayName As String = Nothing

			IsValid = True

			LoadPropertyAttributes(PropertyDescriptor, IsEntityKey, IsNullable, IsRequired, MaxLength, Precision,
								   Scale, PropertyType, DisplayName)

			If String.IsNullOrWhiteSpace(DisplayName) Then

				DisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(PropertyDescriptor.Name)

			End If

			Try

				ErrorText = AdvantageFramework.BaseClasses.ValidateData(Value, IsValid, DisplayName, IsEntityKey, IsRequired, IsNullable, MaxLength, Precision, Scale)

				If IsValid Then

					If PropertyType <> AdvantageFramework.BaseClasses.PropertyTypes.Default Then

						ErrorText = AdvantageFramework.BaseClasses.ValidatePropertyType(DbContext, DataContext, DTO, DTO.GetType, PropertyType, Value, IsValid)

					End If

				End If

				ErrorText &= ValidateCustomProperties(DbContext, DataContext, DTO, PropertyDescriptor.Name, IsValid, Value)

			Catch ex As Exception
				IsValid = True
			End Try

			FinalizeEntityPropertyValidation(DbContext, DataContext, DTO, PropertyDescriptor.Name, IsValid, Value, ErrorText, IsEntityKey, IsNullable, IsRequired, MaxLength, Precision, Scale, PropertyType)

			If IsValid = False AndAlso ErrorText = "" AndAlso PropertyType <> AdvantageFramework.BaseClasses.PropertyTypes.Default Then

				ErrorText = AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(PropertyType)

			End If

			If IsValid = False AndAlso IsRequired = False AndAlso
					(Value = Nothing OrElse Value Is Nothing OrElse (Value IsNot Nothing AndAlso Value.ToString = "")) Then

				IsValid = True
				ErrorText = ""

				ClearNonRequiredPropertiesWithInvalidBlankValues(DbContext, DataContext, DTO, PropertyDescriptor.Name, Value)

			End If

			DTO.SetPropertyError(PropertyDescriptor.Name, ErrorText)

			ValidateDTOProperty = ErrorText

		End Function
		Public Sub LoadPropertyAttributes(PropertyDescriptor As System.ComponentModel.PropertyDescriptor,
										  ByRef IsEntityKey As Boolean, ByRef IsNullable As Boolean, ByRef IsRequired As Boolean,
										  ByRef MaxLength As Integer, ByRef Precision As Integer, ByRef Scale As Integer,
										  ByRef PropertyType As AdvantageFramework.BaseClasses.PropertyTypes, ByRef DisplayName As String)

			'objects
			Dim DecimalPrecisionAttribute As AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute = Nothing
			Dim RequiredAttribute As System.ComponentModel.DataAnnotations.RequiredAttribute = Nothing
			Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

			If PropertyDescriptor IsNot Nothing Then

				RequiredAttribute = PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.DataAnnotations.RequiredAttribute).FirstOrDefault
				EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).FirstOrDefault

				If PropertyDescriptor.PropertyType Is GetType(System.Nullable) OrElse
						RequiredAttribute Is Nothing OrElse
						(RequiredAttribute IsNot Nothing AndAlso RequiredAttribute.AllowEmptyStrings) OrElse
						EntityAttribute Is Nothing OrElse
						(EntityAttribute IsNot Nothing AndAlso EntityAttribute.IsRequired = False) Then

					IsNullable = True

				End If

				IsEntityKey = PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.DataAnnotations.KeyAttribute).Any

				If PropertyDescriptor.PropertyType Is GetType(String) Then

					If PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.DataAnnotations.MaxLengthAttribute).Any Then

						MaxLength = PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.DataAnnotations.MaxLengthAttribute).FirstOrDefault.Length

					End If

				End If

				If PropertyDescriptor.PropertyType Is GetType(System.Nullable(Of Decimal)) OrElse
						PropertyDescriptor.PropertyType Is GetType(Decimal) OrElse
						PropertyDescriptor.PropertyType Is GetType(System.Nullable(Of Double)) OrElse
						PropertyDescriptor.PropertyType Is GetType(Double) Then

					If PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute).Any Then

						DecimalPrecisionAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute).FirstOrDefault

						If DecimalPrecisionAttribute IsNot Nothing Then

							Precision = DecimalPrecisionAttribute.Precision
							Scale = DecimalPrecisionAttribute.Scale

						End If

					End If

				End If

				If RequiredAttribute IsNot Nothing Then

					IsRequired = True

				End If

				If IsRequired = False AndAlso EntityAttribute IsNot Nothing Then

					IsRequired = EntityAttribute.IsRequired

				End If

				If EntityAttribute IsNot Nothing Then

					PropertyType = EntityAttribute.PropertyType
					DisplayName = EntityAttribute.CustomColumnCaption

				End If

			End If

		End Sub
		Public Overridable Sub ClearNonRequiredPropertiesWithInvalidBlankValues(DbContext As AdvantageFramework.BaseClasses.DbContext, DataContext As AdvantageFramework.BaseClasses.DataContext,
																				ByRef DTO As AdvantageFramework.DTO.BaseClass, PropertyName As String, ByRef Value As Object)



		End Sub
		Public Overridable Sub FinalizeEntityPropertyValidation(DbContext As AdvantageFramework.BaseClasses.DbContext, DataContext As AdvantageFramework.BaseClasses.DataContext,
																ByRef DTO As AdvantageFramework.DTO.BaseClass, PropertyName As String, ByRef IsValid As Boolean,
																ByRef Value As Object, ByRef ErrorText As String, IsEntityKey As Boolean, IsNullable As Boolean,
																IsRequired As Boolean, MaxLength As Integer, Precision As Long, Scale As Long, PropertyType As AdvantageFramework.BaseClasses.PropertyTypes)



		End Sub
		Public Overridable Function ValidateCustomProperties(DbContext As AdvantageFramework.BaseClasses.DbContext, DataContext As AdvantageFramework.BaseClasses.DataContext, ByRef DTO As AdvantageFramework.DTO.BaseClass,
															 PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

			ValidateCustomProperties = ""

		End Function
        Public Overridable Sub SetRequiredFields(ByRef DTO As AdvantageFramework.DTO.BaseClass)



        End Sub

#End Region

#End Region

    End Class

End Namespace
