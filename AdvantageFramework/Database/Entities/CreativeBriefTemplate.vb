Namespace Database.Entities

	<Table("CRTV_BRF_DEF")>
	Public Class CreativeBriefTemplate
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Description
			Code
			Level1Style
			Level2Style
			Level3Style
			DetailLevelStyle
			ShowClient
			ShowClientRef
			ShowDivision
			ShowProduct
			ShowClientAddress
			ShowDivisionAddress
			ShowProductAddress
			ShowJobNumber
			ShowJobDescription
			ShowJobComponentNumber
			ShowJobComponentDescription
			ShowAccountExecutive
			ShowBudget
			ShowTeam
			ShowDateOpened
			ShowCampaign
			ShowApprovedEstimateRequired
			ShowRushChargesApproved
			ShowDueDate
			ShowOpenedBy
			IsInactive
			JobTypeCode
			JobType
			CreativeBriefTemplateLevel1s

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <DatabaseGenerated(DatabaseGeneratedOption.None)>
        <Required>
		<Column("CRTV_BRF_DEF_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(254)>
		<Column("CRTV_BRF_DEF_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<MaxLength(6)>
		<Column("CRTV_BRF_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<MaxLength(100)>
		<Column("LVL1_STYLE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Level1Style() As String
		<MaxLength(100)>
		<Column("LVL2_STYLE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Level2Style() As String
		<MaxLength(100)>
		<Column("LVL3_STYLE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Level3Style() As String
		<MaxLength(100)>
		<Column("DTL_STYLE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DetailLevelStyle() As String
		<Column("SHOW_CLIENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowClient() As Nullable(Of Short)
		<Column("SHOW_CLIENT_REF")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowClientRef() As Nullable(Of Short)
		<Column("SHOW_DIVISION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowDivision() As Nullable(Of Short)
		<Column("SHOW_PRODUCT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowProduct() As Nullable(Of Short)
		<Column("SHOW_CL_ADDRESS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowClientAddress() As Nullable(Of Short)
		<Column("SHOW_DIV_ADDRESS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowDivisionAddress() As Nullable(Of Short)
		<Column("SHOW_PRD_ADDRESS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowProductAddress() As Nullable(Of Short)
		<Column("SHOW_JOB_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowJobNumber() As Nullable(Of Short)
		<Column("SHOW_JOB_DESC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowJobDescription() As Nullable(Of Short)
		<Column("SHOW_JOB_COMP_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowJobComponentNumber() As Nullable(Of Short)
		<Column("SHOW_JOB_COMP_DESC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowJobComponentDescription() As Nullable(Of Short)
		<Column("SHOW_ACCT_EXEC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowAccountExecutive() As Nullable(Of Short)
		<Column("SHOW_BUDGET")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowBudget() As Nullable(Of Short)
		<Column("SHOW_TEAM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowTeam() As Nullable(Of Short)
		<Column("SHOW_DATE_OPENED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowDateOpened() As Nullable(Of Short)
		<Column("SHOW_CAMPAIGN")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowCampaign() As Nullable(Of Short)
		<Column("SHOW_APPRV_EST_REQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowApprovedEstimateRequired() As Nullable(Of Short)
		<Column("SHOW_RUSH_CHGS_OK")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowRushChargesApproved() As Nullable(Of Short)
		<Column("SHOW_DUE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowDueDate() As Nullable(Of Short)
		<Column("SHOW_OPENED_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowOpenedBy() As Nullable(Of Short)
		<Column("ACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)
		<MaxLength(10)>
		<Column("JT_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobTypeCode() As String

        Public Overridable Property JobType As Database.Entities.JobType
        Public Overridable Property CreativeBriefTemplateLevel1s As ICollection(Of Database.Entities.CreativeBriefTemplateLevel1)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.CreativeBriefTemplate.Properties.Code.ToString

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).CreativeBriefTemplates
                            Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique creative brief template code."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
