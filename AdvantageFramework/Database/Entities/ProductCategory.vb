Namespace Database.Entities

	<Table("PRODUCT_CATEGORY")>
	Public Class ProductCategory
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ClientCode
			DivisionCode
			ProductCode
			Code
			Description
			IsInactive
			Product

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(6)>
        <Column("CL_CODE", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
		Public Property ClientCode() As String
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("DIV_CODE", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode)>
		Public Property DivisionCode() As String
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("PRD_CODE", Order:=2, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ProductCode)>
		Public Property ProductCode() As String
		<Key>
		<Required>
		<MaxLength(10)>
        <Column("PROD_CAT_CODE", Order:=3, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<Required>
		<MaxLength(60)>
		<Column("PROD_CAT_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)

        <ForeignKey("ClientCode, DivisionCode, ProductCode")>
        Public Overridable Property Product As Database.Entities.Product

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ProductCategory.Properties.Code.ToString

                    If Value Is Nothing OrElse Value.Trim = "" Then

                        IsValid = False
                        ErrorText = "Please enter a product category code."

                    End If

                    If IsValid Then

                        If Value <> AdvantageFramework.StringUtilities.RemoveAllNonAlphaNumeric(Value) Then

                            IsValid = False
                            ErrorText = "Please enter a valid product category code."

                        End If

                    End If

                    If IsValid Then

                        PropertyValue = Value

                        If Me.IsEntityBeingAdded() Then

                            If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).ProductCategories
                                Where Entity.ProductCode = Me.ProductCode AndAlso
                                          Entity.DivisionCode = Me.DivisionCode AndAlso
                                          Entity.ClientCode = Me.ClientCode AndAlso
                                          Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                                Select Entity).Any Then

                                IsValid = False
                                ErrorText = "Please enter a unique product category code."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
