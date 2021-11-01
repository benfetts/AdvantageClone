Namespace Security.Database.Entities

	<Table("SERVICE_FEE_DEF")>
	Public Class ServiceFeeReconciliationSetting
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			UserCode
			IncludeIncomeOnly
			IncludeProductionCommission
			IncludeMediaCommission
			IncomeOnlyJobCompMarkedAsFee
			IncomeOnlyPostedBasedOnSalesClass
			IncomeOnlyPostedBasedOnFunction
			ProductionCommissionPostedBasedOnSalesClass
			ProductionCommissionPostedBasedOnFunction
			BroadcastCommission
			MagazineCommission
			NewspaperCommission
			InternetCommission
			OutOfHomeCommission
			ClientDivisionProductIncludeOption
			IncludeUnreconciledOnly
			IncludeIncomeOnlyFeeTime
			IncludeProductionCommissionFeeTime
			IncludeMediaCommissionFeeTime
			PrimaryDisplayOption
			DisplayCampaign
			DisplayJobNumber
			DisplayJobName
			DisplayJobComponentNumber
			DisplayJobComponentName
			DisplayFunction
			ServiceFeeTypeSelection
			GroupByOption
			SummaryStyle
			IncludeServiceFeeTypeLevel
			AddFeeDescriptionToGroupBy

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(100)>
		<Column("USER_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String
		<Column("INCOME_ONLY_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IncludeIncomeOnly() As Nullable(Of Short)
		<Column("PRODUCT_COMM_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IncludeProductionCommission() As Nullable(Of Short)
		<Column("MEDIA_COMM_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IncludeMediaCommission() As Nullable(Of Short)
		<Column("STD_FEE_JOB_COMP")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IncomeOnlyJobCompMarkedAsFee() As Nullable(Of Short)
		<Column("STD_FEE_SC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IncomeOnlyPostedBasedOnSalesClass() As Nullable(Of Short)
		<Column("STD_FEE_FUNC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IncomeOnlyPostedBasedOnFunction() As Nullable(Of Short)
		<Column("PROD_COMM_SC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductionCommissionPostedBasedOnSalesClass() As Nullable(Of Short)
		<Column("PROD_COMM_FUNC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductionCommissionPostedBasedOnFunction() As Nullable(Of Short)
		<Column("BROAD_COMM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BroadcastCommission() As Nullable(Of Short)
		<Column("MAG_COMM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineCommission() As Nullable(Of Short)
		<Column("NEWS_COMM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperCommission() As Nullable(Of Short)
		<Column("INT_COMM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetCommission() As Nullable(Of Short)
		<Column("OOH_COMM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutOfHomeCommission() As Nullable(Of Short)
		<Column("CDP_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientDivisionProductIncludeOption() As Nullable(Of Short)
		<Column("UN_REC_ONLY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IncludeUnreconciledOnly() As Nullable(Of Short)
		<Column("FEETIME_TYPE_INCL_STD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IncludeIncomeOnlyFeeTime() As Nullable(Of Short)
		<Column("FEETIME_TYPE_INCL_PROD_COMM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IncludeProductionCommissionFeeTime() As Nullable(Of Short)
		<Column("FEETIME_TYPE_INCL_MEDIA_COMM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IncludeMediaCommissionFeeTime() As Nullable(Of Short)
		<Column("PRIMARY_DISPL_OPT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PrimaryDisplayOption() As Nullable(Of Short)
		<Column("GRD_DISPL_OPT_CMPN")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DisplayCampaign() As Nullable(Of Short)
		<Column("GRD_DISPL_OPT_JOB_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DisplayJobNumber() As Nullable(Of Short)
		<Column("GRD_DISPL_OPT_JOB_NAME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DisplayJobName() As Nullable(Of Short)
		<Column("GRD_DISPL_OPT_COMP_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DisplayJobComponentNumber() As Nullable(Of Short)
		<Column("GRD_DISPL_OPT_COMP_NAME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DisplayJobComponentName() As Nullable(Of Short)
		<Column("GRD_DISPL_OPT_FUNC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DisplayFunction() As Nullable(Of Short)
		<Column("SERVICE_FEE_SEL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ServiceFeeTypeSelection() As Nullable(Of Integer)
		<Column("SERVICE_GROUP_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GroupByOption() As Nullable(Of Integer)
		<Column("SERVICE_SUMMARY_STYLE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SummaryStyle() As Nullable(Of Integer)
		<Required>
		<Column("INCLD_SERV_FEE_TYPE_LEVEL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IncludeServiceFeeTypeLevel() As Boolean
		<Required>
		<Column("ADD_FEE_DESC_TO_GRP_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AddFeeDescriptionToGroupBy() As Boolean


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.UserCode

        End Function

#End Region

	End Class

End Namespace
