Namespace Database.Entities

	<Table("MEDIA_SPECS_HDR")>
	Public Class MediaSpecsHeader
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			VendorCode
			AdSize
			DateCreated
			CreatedBy
			DateModified
			ModifiedBy
			Vendor
			MediaSpecsDetails

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<DatabaseGenerated(DatabaseGeneratedOption.None)>
		<Required>
		<Column("SPEC_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<MaxLength(6)>
		<Column("VN_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorCode() As String
		<Required>
		<MaxLength(6)>
		<Column("AD_SIZE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AdSize() As String
		<Required>
		<Column("CREATE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DateCreated() As Date
		<Required>
		<MaxLength(100)>
		<Column("CREATE_USER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedBy() As String
		<Column("MODIFIED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DateModified() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("MODIFIED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedBy() As String

        Public Overridable Property Vendor As Database.Entities.Vendor
        Public Overridable Property MediaSpecsDetails As ICollection(Of Database.Entities.MediaSpecsDetail)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.MediaSpecsHeader.Properties.AdSize.ToString

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).MediaSpecsHeaders
                            Where Entity.AdSize.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso
                                      Entity.VendorCode.ToUpper = Me.VendorCode.ToUpper
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "There is already a Media Specification for " & PropertyValue & "."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
