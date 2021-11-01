Namespace Database.Entities

	<Table("PRODUCT_MEDIA_OVERRIDES")>
	Public Class ProductMediaOverrides
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
			ID
			ClientCode
			DivisionCode
			ProductCode
			MediaType
			SalesClassCode
			RebatePercent
			MarkupPercent
			CreatedByUserCode
			CreatedDate
			ModifiedByUserCode
			ModifiedDate

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("PRODUCT_MEDIA_OVERRIDES_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
		<Required>
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ClientCode() As String
		<Required>
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property DivisionCode() As String
		<Required>
		<MaxLength(6)>
		<Column("PRD_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ProductCode() As String
		<Required>
		<MaxLength(1)>
		<Column("MEDIA_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.MediaType)>
		Public Property MediaType() As String
		<Required>
		<MaxLength(6)>
		<Column("SC_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Sales Class", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SalesClassCode)>
        Public Property SalesClassCode() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        <Column("REBATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f3", CustomColumnCaption:="Rebate Pct", UseMaxValue:=True, MaxValue:=9999.999, UseMinValue:=True, MinValue:=-9999.999)>
        Public Property RebatePercent() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        <Column("MARKUP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f3", CustomColumnCaption:="Markup Pct", UseMaxValue:=True, MaxValue:=9999.999, UseMinValue:=True, MinValue:=-9999.999)>
        Public Property MarkupPercent() As Nullable(Of Decimal)
		<Required>
		<MaxLength(100)>
		<Column("USER_CREATED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property CreatedByUserCode() As String
		<Required>
		<Column("CREATED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property CreatedDate() As Date
		<MaxLength(100)>
		<Column("USER_MODIFIED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ModifiedByUserCode() As String
		<Column("MODIFIED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ModifiedDate() As Nullable(Of Date)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Overrides Function ValidateCustomProperties(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            PropertyValue = Value

            If PropertyName = Properties.SalesClassCode.ToString Then

                If Me.IsEntityBeingAdded() Then

                    If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).ProductMediaOverrides
                        Where Entity.ClientCode = Me.ClientCode AndAlso
                                    Entity.DivisionCode = Me.DivisionCode AndAlso
                                    Entity.ProductCode = Me.ProductCode AndAlso
                                    Entity.SalesClassCode = CType(PropertyValue, String) AndAlso
                                    Entity.MediaType = Me.MediaType
                        Select Entity).Any Then

                        IsValid = False

                        ErrorText = "Sales Class\Media Type override combo already exists."

                    End If

                End If

            End If

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
