Namespace Database.Entities

	<Table("JOB_SPEC_TYPE")>
	Public Class JobSpecificationType
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Code
			Description
			UseQuantitiesTab
			IsInactive
			UseVendorTab
			JobSpecificationVendorTab
			JobSpecificationCategories
			JobSpecificationFields

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(6)>
		<Column("SPEC_TYPE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<Required>
		<MaxLength(32)>
		<Column("SPEC_TYPE_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<Column("USE_QTY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UseQuantitiesTab() As Short
		<Required>
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Short
		<Column("USE_VENDOR_TAB")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UseVendorTab() As Nullable(Of Short)

        <ForeignKey("UseVendorTab")>
        Public Overridable Property JobSpecificationVendorTab As Database.Entities.JobSpecificationVendorTab
        Public Overridable Property JobSpecificationCategories As ICollection(Of Database.Entities.JobSpecificationCategory)
        Public Overridable Property JobSpecificationFields As ICollection(Of Database.Entities.JobSpecificationField)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code.ToString

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.JobSpecificationType.Properties.Code.ToString

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).JobSpecificationTypes
                            Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique Job Specification Type code."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
