Namespace Database.Entities

	<Table("DESTINATION")>
	Public Class Destination
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Code
			Name
			VendorID
			Address1
			Address2
			City
			State
			Zip
			Phone
			PhoneExt
			Fax
			FaxExt
			IsInactive
			DestinationContacts

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(10)>
		<Column("DESTINATION_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<MaxLength(60)>
		<Column("DESTINATION_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Name() As String
		<MaxLength(10)>
		<Column("VENDOR_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorID() As String
		<MaxLength(40)>
		<Column("DEST_ADDR1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Address1() As String
		<MaxLength(40)>
		<Column("DEST_ADDR2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Address2() As String
		<MaxLength(25)>
		<Column("DEST_CITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property City() As String
		<MaxLength(10)>
		<Column("DEST_STATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property State() As String
		<MaxLength(10)>
		<Column("DEST_ZIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Zip() As String
		<MaxLength(13)>
		<Column("DEST_PHONE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Phone() As String
		<MaxLength(4)>
		<Column("DEST_PHONE_EXT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PhoneExt() As String
		<MaxLength(13)>
		<Column("DEST_FAX", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Fax() As String
		<MaxLength(4)>
		<Column("DEST_FAX_EXT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FaxExt() As String
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)

        Public Overridable Property DestinationContacts As ICollection(Of Database.Entities.DestinationContact)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Name

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
            Dim PropertyValue As Object = Nothing

            PropertyValue = Value

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.Destination.Properties.Code.ToString

                    If IsValid Then

                        If Me.IsEntityBeingAdded() Then

                            If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Destinations
                                Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                                Select Entity).Any Then

                                IsValid = False

                                ErrorText = "Please enter a unique code."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
