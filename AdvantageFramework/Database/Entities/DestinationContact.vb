Namespace Database.Entities

	<Table("DESTINATION_CONTACT")>
	Public Class DestinationContact
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			DestinationCode
			Code
			ClientCode
			DivisionCode
			ProductCode
			LastName
			FirstName
			MiddleInitial
			Phone
			PhoneExt
			Fax
			FaxExt
			Email
			SpecialInstructions
			IsInactive
			Destination
			Product

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(10)>
        <Column("DESTINATION_CODE", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property DestinationCode() As String
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("DEST_CONT_CODE", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
		Public Property ClientCode() As String
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Division", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode)>
		Public Property DivisionCode() As String
		<MaxLength(6)>
		<Column("PRD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Product", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ProductCode)>
		Public Property ProductCode() As String
		<MaxLength(30)>
		<Column("DEST_CONT_LNAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LastName() As String
		<MaxLength(30)>
		<Column("DEST_CONT_FNAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FirstName() As String
		<MaxLength(30)>
		<Column("DEST_CONT_MI", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MiddleInitial() As String
		<MaxLength(13)>
		<Column("DEST_CONT_PHONE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Phone() As String
		<MaxLength(4)>
		<Column("DEST_CONT_PHONE_EXT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PhoneExt() As String
		<MaxLength(13)>
		<Column("DEST_CONT_FAX", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Fax() As String
		<MaxLength(4)>
		<Column("DEST_CONT_FAX_EXT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FaxExt() As String
		<MaxLength(50)>
		<Column("DEST_CONT_EMAIL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="E-Mail Address", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Email)>
		Public Property Email() As String
		<Column("DEF_SPECIAL_INSTR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.Memo)>
		Public Property SpecialInstructions() As String
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)

        Public Overridable Property Destination As Database.Entities.Destination

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.DestinationCode.ToString

        End Function
        Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim PropertyValue As Object = Nothing
            Dim DivisionAndProductRequired As Boolean = False

            If PropertyName = AdvantageFramework.Database.Entities.DestinationContact.Properties.ClientCode.ToString Then

                PropertyValue = Value

                DivisionAndProductRequired = Not String.IsNullOrEmpty(DirectCast(PropertyValue, String))

                SetRequired(AdvantageFramework.Database.Entities.DestinationContact.Properties.DivisionCode.ToString, DivisionAndProductRequired)
                SetRequired(AdvantageFramework.Database.Entities.DestinationContact.Properties.ProductCode.ToString, DivisionAndProductRequired)

            End If

            ValidateEntityProperty = MyBase.ValidateEntityProperty(PropertyName, IsValid, Value)

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.DestinationContact.Properties.Code.ToString

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).DestinationContacts
                            Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso
                                  Entity.DestinationCode = Me.DestinationCode
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique contact code."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
