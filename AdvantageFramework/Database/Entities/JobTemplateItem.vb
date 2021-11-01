Namespace Database.Entities

	<Table("JOB_TMPLT_ITEMS")>
	Public Class JobTemplateItem
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Code
			Description
			Type
			AdvantageRequired
			Comments
			DisplayOrder
			AgencyRequired
			ClientRequired
			UDVTableName
			AllowMultiple
            ControlType
            DatabaseTypeID
            Precision
            Scale
            JobTemplateDetails

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(32)>
		<Column("ITEM_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Database Field / Item Type")>
		Public Property Code() As String
		<Required>
		<MaxLength(50)>
		<Column("ITEM_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Original Label")>
		Public Property Description() As String
		<Required>
		<MaxLength(1)>
		<Column("ITEM_TYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property Type() As String
		<Required>
		<Column("ADVAN_REQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property AdvantageRequired() As Byte
		<MaxLength(254)>
		<Column("ITEM_COMMENTS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property Comments() As String
		<Column("DISPLAY_ORDER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property DisplayOrder() As Nullable(Of Short)
		<MaxLength(32)>
		<Column("AGENCY_REQ_COL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property AgencyRequired() As String
		<MaxLength(32)>
		<Column("CLIENT_REQ_COL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ClientRequired() As String
		<MaxLength(19)>
		<Column("UDV_TABLE_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property UDVTableName() As String
		<Required>
		<Column("ALLOW_MULTI")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property AllowMultiple() As Byte
		<Required>
		<Column("CONTROL_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ControlType() As Short
        <Required>
        <Column("ADVAN_DTYPE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property DatabaseTypeID() As Nullable(Of Short)
        <Required>
        <Column("JT_DTYPE_PREC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Precision() As Nullable(Of Short)
        <Required>
        <Column("JT_DTYPE_SCALE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Scale() As Nullable(Of Short)

        Public Overridable Property JobTemplateDetails As ICollection(Of Database.Entities.JobTemplateDetail)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code.ToString

        End Function

#End Region

	End Class

End Namespace
