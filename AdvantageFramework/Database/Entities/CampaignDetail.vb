Namespace Database.Entities

	<Table("CAMPAIGN_DETAIL")>
	Public Class CampaignDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			CampaignID
			ID
			SalesClassCode
			PostPeriodCode
			CampaignDetailType
			DepartmentTeamCode
			BillingBudgetAmount
			IncomeBudgetAmount
			RevisedDate
			UserCode
			FunctionCode
			Campaign

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("CMP_IDENTIFIER", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property CampaignID() As Integer
		<Key>
		<Required>
        <Column("LINE_NBR", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Short
		<MaxLength(6)>
		<Column("SC_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Sales Class", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SalesClassCode)>
		Public Property SalesClassCode() As String
		<MaxLength(6)>
		<Column("POST_PERIOD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Post Period", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.PostPeriodCode)>
		Public Property PostPeriodCode() As String
		<MaxLength(10)>
		<Column("DTL_CMP_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.CampaignDetailType)>
		Public Property CampaignDetailType() As String
		<MaxLength(4)>
		<Column("DP_TM_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Department/Team", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DepartmentTeamCode)>
        Public Property DepartmentTeamCode() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("CMP_BILL_BUDGET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="c2")>
        Public Property BillingBudgetAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("CMP_INC_BUDGET")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="c2")>
		Public Property IncomeBudgetAmount() As Nullable(Of Decimal)
		<Column("LAST_REV_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property RevisedDate() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("USER_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property UserCode() As String
		<MaxLength(6)>
		<Column("FNC_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Function", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.FunctionCode)>
		Public Property FunctionCode() As String

        Public Overridable Property Campaign As Database.Entities.Campaign

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.CampaignID

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                'Case AdvantageFramework.Database.Entities.CampaignDetail.Properties.SalesClassCode.ToString

                '    If Value <> Nothing AndAlso Value <> "" Then

                '        If AdvantageFramework.Database.Procedures.SalesClass.LoadBySalesClassCode(Me.DbContext, Value) Is Nothing Then

                '            IsValid = False
                '            ErrorText = "Please enter a valid sales class code."

                '        End If

                '    End If

                'Case AdvantageFramework.Database.Entities.CampaignDetail.Properties.PostPeriodCode.ToString

                '    If Value <> Nothing AndAlso Value <> "" Then

                '        If AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(Me.DbContext, Value) Is Nothing Then

                '            IsValid = False
                '            ErrorText = "Please enter a valid post period code."

                '        End If

                '    End If

                'Case AdvantageFramework.Database.Entities.CampaignDetail.Properties.CampaignDetailType.ToString

                '    If Value <> Nothing AndAlso Value IsNot Nothing Then

                '        If AdvantageFramework.EnumUtilities.IsMemberOfEnum(GetType(AdvantageFramework.Database.Entities.CampaignDetailTypes), Value) = False Then

                '            IsValid = False
                '            ErrorText = "Please enter a valid campaign detail type."

                '        End If

                '    End If

                'Case AdvantageFramework.Database.Entities.CampaignDetail.Properties.DepartmentTeamCode.ToString

                '    If Value <> Nothing AndAlso Value <> "" Then

                '        If AdvantageFramework.Database.Procedures.DepartmentTeam.LoadByDepartmentTeamCode(Me.DbContext, Value) Is Nothing Then

                '            IsValid = False
                '            ErrorText = "Please enter a valid department/team code."

                '        End If

                '    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
