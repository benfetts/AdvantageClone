Namespace Database.Entities

	<Table("JOB_LOG")>
	Public Class Job
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Number
			OfficeCode
			ClientCode
			DivisionCode
			ProductCode
			UserCode
			CreatedDate
			Description
			OpenedDate
			IsEstimateRequired
			Comment
			ID
			SalesClassCode
			CampaignCode
			IsOpen
			CampaignID
			ClientRef
			ComplexityCode
			PromotionCode
			JobUserDefinedValue1Code
			JobUserDefinedValue2Code
			JobUserDefinedValue3Code
			JobUserDefinedValue4Code
			JobUserDefinedValue5Code
			SalesClassFormatCode
			BillingCoopCode
			Office
			Product
			Client
			Division
			JobComponents
			SalesClass
			EmployeeTimeForecastOfficeDetailJobComponents
			Documents
			Complexity
			PromotionType
			JobUserDefinedValue1
			JobUserDefinedValue2
			JobUserDefinedValue3
			JobUserDefinedValue4
			JobUserDefinedValue5
			AccountPayableProductions
			PurchaseOrderDetails
			AccountReceivables
            MediaPlanDetailLevelLineTags
            ModifiedDate
            ModifiedBy

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<Column("JOB_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job Number")>
		Public Property Number() As Integer
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Office")>
		Public Property OfficeCode() As String
		<Required>
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
		Public Property ClientCode() As String
		<Required>
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Division", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode)>
		Public Property DivisionCode() As String
		<Required>
		<MaxLength(6)>
		<Column("PRD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ProductCode)>
		Public Property ProductCode() As String
		<MaxLength(100)>
		<Column("USER_ID", TypeName:="varchar")>
		Public Property UserCode() As String
		<Column("CREATE_DATE")>
		Public Property CreatedDate() As Nullable(Of Date)
		<MaxLength(60)>
		<Column("JOB_DESC", TypeName:="varchar")>
		Public Property Description() As String
		<Column("JOB_DATE_OPENED")>
		Public Property OpenedDate() As Nullable(Of Date)
		<Column("JOB_ESTIMATE_REQ")>
		Public Property IsEstimateRequired() As Nullable(Of Short)
		<Column("JOB_COMMENTS")>
		Public Property Comment() As String
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ROWID")>
		Public Property ID() As Integer
		<MaxLength(6)>
		<Column("SC_CODE", TypeName:="varchar")>
		Public Property SalesClassCode() As String
		<MaxLength(6)>
        <Column("CMP_CODE", TypeName:="varchar")>
        Public Property CampaignCode() As String
        <DatabaseGenerated(DatabaseGeneratedOption.Computed)>
        <Column("COMP_OPEN")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsOpen() As Nullable(Of Integer)
		<Column("CMP_IDENTIFIER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CampaignID() As Nullable(Of Integer)
		<MaxLength(30)>
		<Column("JOB_CLI_REF", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientRef() As String
		<MaxLength(8)>
		<Column("COMPLEX_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ComplexityCode() As String
		<MaxLength(8)>
		<Column("PROMO_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PromotionCode() As String
		<MaxLength(10)>
		<Column("UDV1_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobUserDefinedValue1Code() As String
		<MaxLength(10)>
		<Column("UDV2_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobUserDefinedValue2Code() As String
		<MaxLength(10)>
		<Column("UDV3_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobUserDefinedValue3Code() As String
		<MaxLength(10)>
		<Column("UDV4_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobUserDefinedValue4Code() As String
		<MaxLength(10)>
		<Column("UDV5_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobUserDefinedValue5Code() As String
		<MaxLength(8)>
		<Column("FORMAT_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SalesClassFormatCode() As String
		<MaxLength(6)>
		<Column("BILL_COOP_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingCoopCode() As String
        <Column("MODIFY_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedDate() As Nullable(Of Date)
        <Column("MODIFIED_BY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedBy() As String

        Public Overridable Property Office As Database.Entities.Office
        <ForeignKey("ClientCode, DivisionCode, ProductCode")>
        Public Overridable Property Product As Database.Entities.Product
        Public Overridable Property Client As Database.Entities.Client
        <ForeignKey("ClientCode, DivisionCode")>
        Public Overridable Property Division As Database.Entities.Division
        Public Overridable Property JobComponents As ICollection(Of Database.Entities.JobComponent)
        Public Overridable Property SalesClass As Database.Entities.SalesClass
        Public Overridable Property EmployeeTimeForecastOfficeDetailJobComponents As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent)
        Public Overridable Property Complexity As Database.Entities.Complexity
        <ForeignKey("PromotionCode")>
        Public Overridable Property PromotionType As Database.Entities.PromotionType
        Public Overridable Property JobUserDefinedValue1 As Database.Entities.JobUserDefinedValue1
        Public Overridable Property JobUserDefinedValue2 As Database.Entities.JobUserDefinedValue2
        Public Overridable Property JobUserDefinedValue3 As Database.Entities.JobUserDefinedValue3
        Public Overridable Property JobUserDefinedValue4 As Database.Entities.JobUserDefinedValue4
        Public Overridable Property JobUserDefinedValue5 As Database.Entities.JobUserDefinedValue5
        Public Overridable Property AccountPayableProductions As ICollection(Of Database.Entities.AccountPayableProduction)
        Public Overridable Property PurchaseOrderDetails As ICollection(Of Database.Entities.PurchaseOrderDetail)
        Public Overridable Property AccountReceivables As ICollection(Of Database.Entities.AccountReceivable)
        Public Overridable Property MediaPlanDetailLevelLineTags As ICollection(Of Database.Entities.MediaPlanDetailLevelLineTag)

#End Region

#Region " Methods "

        Public Shadows Function ToString(ByVal WithDescription As Boolean) As String

            If WithDescription Then

                ToString = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(Me.Number, 6, "0", True, True) & " - " & Me.Description).Trim

            Else

                ToString = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(Me.Number, 6, "0", True, True)).Trim

            End If

        End Function

#End Region

	End Class

End Namespace
