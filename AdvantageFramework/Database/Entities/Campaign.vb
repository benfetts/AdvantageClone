Namespace Database.Entities

	<Table("CAMPAIGN")>
	Public Class Campaign
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ClientCode
			DivisionCode
			ProductCode
			Code
			StartDate
			EndDate
			Comment
			Name
			IsDirectResponse
			IsMagazine
			IsNewspaper
			IsOutOfHome
			IsPrint
			IsRadio
			IsTelevision
			IsOther
			OtherDescription
			ID
			IsClosed
			IsActive
			BillingBudgetAmount
			IncomeBudgetAmount
			CampaignType
			OfficeCode
			AlertGroupCode
			IsInternetAds
			AdNumber
			MarketCode
			JobNumber
            JobComponentNumber
            ClientWebsiteID
            AdServerID
            AdServerCampaignID
            AdServerCreatedBy
            Client
			Division
			Office
			Product
			CampaignDetails
			PartnerAllocations
			RadioOrderLegacies
			TVOrderLegacies
			MediaATBRevisions
            DigitalResults
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Required>
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
		Public Property ClientCode() As String
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode)>
		Public Property DivisionCode() As String
		<MaxLength(6)>
		<Column("PRD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ProductCode)>
		Public Property ProductCode() As String
		<Required>
		<MaxLength(6)>
		<Column("CMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<Column("CMP_BEG_DATE")>
		Public Property StartDate() As Nullable(Of Date)
		<Column("CMP_END_DATE")>
		Public Property EndDate() As Nullable(Of Date)
		<Column("CMP_COMMENTS")>
		Public Property Comment() As String
        <MaxLength(128)>
        <Column("CMP_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Name() As String
		<Column("CMP_DIRECT")>
		Public Property IsDirectResponse() As Nullable(Of Short)
		<Column("CMP_MAGAZINE")>
		Public Property IsMagazine() As Nullable(Of Short)
		<Column("CMP_NEWSPAPER")>
		Public Property IsNewspaper() As Nullable(Of Short)
		<Column("CMP_OUTDOOR")>
		Public Property IsOutOfHome() As Nullable(Of Short)
		<Column("CMP_PRINT_COLL")>
		Public Property IsPrint() As Nullable(Of Short)
		<Column("CMP_RADIO")>
		Public Property IsRadio() As Nullable(Of Short)
		<Column("CMP_TELEVISION")>
		Public Property IsTelevision() As Nullable(Of Short)
		<Column("CMP_OTHER")>
		Public Property IsOther() As Nullable(Of Short)
		<MaxLength(30)>
		<Column("CMP_OTHER_EXPLAIN", TypeName:="varchar")>
		Public Property OtherDescription() As String
        <Key>
        <DatabaseGenerated(DatabaseGeneratedOption.None)>
        <Required>
        <Column("CMP_IDENTIFIER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Column("CMP_CLOSED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsClosed() As Nullable(Of Short)
        <Column("ACTIVE_FLAG")>
        Public Property IsActive() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("CMP_BILL_BUDGET")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="c2")>
		Public Property BillingBudgetAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("CMP_INC_BUDGET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="c2")>
		Public Property IncomeBudgetAmount() As Nullable(Of Decimal)
		<Required>
		<Column("CMP_TYPE")>
		Public Property CampaignType() As Short
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property OfficeCode() As String
		<MaxLength(50)>
		<Column("ALERT_GROUP", TypeName:="varchar")>
		Public Property AlertGroupCode() As String
		<Column("CMP_INTERNET")>
		Public Property IsInternetAds() As Nullable(Of Short)
		<MaxLength(30)>
		<Column("AD_NBR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AdNumber() As String
		<MaxLength(10)>
		<Column("MARKET_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MarketCode() As String
		<Column("JOB_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobNumber() As Nullable(Of Integer)
		<Column("JOB_COMPONENT_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentNumber() As Nullable(Of Short)
        <Column("CL_WEBSITE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientWebsiteID() As Nullable(Of Integer)
        <Column("AD_SERVER_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdServerID() As Nullable(Of Integer)
        <Column("AD_SERVER_CAMPAIGN_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdServerCampaignID() As Nullable(Of Long)
        <Column("AD_SERVER_CREATED_BY", TypeName:="varchar")>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdServerCreatedBy() As String

        Public Overridable Property Client As Database.Entities.Client
        <ForeignKey("ClientCode, DivisionCode")>
        Public Overridable Property Division As Database.Entities.Division
        Public Overridable Property Office As Database.Entities.Office
        <ForeignKey("ClientCode, DivisionCode, ProductCode")>
        Public Overridable Property Product As Database.Entities.Product
        Public Overridable Property CampaignDetails As ICollection(Of Database.Entities.CampaignDetail)
        Public Overridable Property PartnerAllocations As ICollection(Of Database.Entities.PartnerAllocation)
        Public Overridable Property RadioOrderLegacies As ICollection(Of Database.Entities.RadioOrderLegacy)
        Public Overridable Property TVOrderLegacies As ICollection(Of Database.Entities.TVOrderLegacy)
        Public Overridable Property MediaATBRevisions As ICollection(Of Database.Entities.MediaATBRevision)
        Public Overridable Property DigitalResults As ICollection(Of Database.Entities.DigitalResult)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Name

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = ""

            ErrorText = MyBase.ValidateEntity(IsValid)

            If IsValid Then

                If Me.IsEntityBeingAdded() Then

                    If String.IsNullOrEmpty(Me.ClientCode) = False AndAlso String.IsNullOrEmpty(Me.DivisionCode) = False AndAlso String.IsNullOrEmpty(Me.ProductCode) = False Then

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Campaigns
                            Where Entity.Code.ToUpper = Me.Code.ToUpper AndAlso
                                      Entity.ClientCode = Me.ClientCode AndAlso
                                      Entity.DivisionCode = Me.DivisionCode AndAlso
                                      Entity.ProductCode = Me.ProductCode
                            Select Entity).Any Then

                            IsValid = False
                            ErrorText = "Please enter a unique campaign code."

                        End If

                    ElseIf String.IsNullOrEmpty(Me.ClientCode) = False AndAlso String.IsNullOrEmpty(Me.DivisionCode) = False AndAlso String.IsNullOrEmpty(Me.ProductCode) Then

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Campaigns
                            Where Entity.Code.ToUpper = Me.Code.ToUpper AndAlso
                                      Entity.ClientCode = Me.ClientCode AndAlso
                                      Entity.DivisionCode = Me.DivisionCode
                            Select Entity).Any Then

                            IsValid = False
                            ErrorText = "Please enter a unique campaign code."

                        End If

                    ElseIf String.IsNullOrEmpty(Me.ClientCode) = False AndAlso String.IsNullOrEmpty(Me.DivisionCode) AndAlso String.IsNullOrEmpty(Me.ProductCode) Then

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Campaigns
                            Where Entity.Code.ToUpper = Me.Code.ToUpper AndAlso
                                      Entity.ClientCode = Me.ClientCode
                            Select Entity).Any Then

                            IsValid = False
                            ErrorText = "Please enter a unique campaign code."

                        End If

                    End If

                End If

            End If

            ValidateEntity = ErrorText

        End Function
        Public Overrides Function ValidateCustomProperties(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim ClientWebsite As AdvantageFramework.Database.Entities.ClientWebsite = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.Campaign.Properties.ClientWebsiteID.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        ClientWebsite = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ClientWebsite).Where(Function(Entity) Entity.ID = DirectCast(PropertyValue, Integer)).SingleOrDefault

                        If ClientWebsite IsNot Nothing AndAlso ClientWebsite.WebsiteAddress.ToUpper.StartsWith("HTTP://") = False AndAlso ClientWebsite.WebsiteAddress.ToUpper.StartsWith("HTTPS://") = False Then

                            IsValid = False

                            ErrorText = "Landing page must start with http:// or https://."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
