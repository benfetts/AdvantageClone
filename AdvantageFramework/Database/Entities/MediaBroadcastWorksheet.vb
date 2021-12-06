Namespace Database.Entities

    <Table("MEDIA_BROADCAST_WORKSHEET")>
    Public Class MediaBroadcastWorksheet
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaType
            Name
            ClientCode
            DivisionCode
            ProductCode
            SalesClassCode
            CampaignID
            StartDate
            EndDate
            MediaBroadcastWorksheetDateTypeID
            MediaCalendarTypeID
            MediaPlanID
            IsInactive
            DefaultToLatestSharebook
            ArePiggybacksOK
            ProrateSecondaryDemosToPrimary
            PrimaryMediaDemographicID
            CreatedByUserCode
            CreatedDate
            ModifiedByUserCode
            ModifiedDate
            Length
            RatingsServiceID
            Comment
            IsGross
            UseOldCalendarDateCreation
            CountryID
            NPRPrepopulateDates
            Client
            Division
            Product
            SalesClass
            Campaign
            MediaBroadcastWorksheetDateType
            MediaPlan
            MediaBroadcastWorksheetMarkets
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_BROADCAST_WORKSHEET_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <MaxLength(1)>
        <Column("MEDIA_TYPE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaTypeCode() As String
        <Required>
        <MaxLength(100)>
        <Column("NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Name() As String
        <Required>
        <MaxLength(6)>
        <Column("CL_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
        <Required>
        <MaxLength(6)>
        <Column("DIV_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.DivisionCode)>
        Public Property DivisionCode() As String
        <Required>
        <MaxLength(6)>
        <Column("PRD_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.ProductCode)>
        Public Property ProductCode() As String
        <Required>
        <MaxLength(6)>
        <Column("SC_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.SalesClassCode)>
        Public Property SalesClassCode() As String
        <Column("CMP_IDENTIFIER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.CampaignID)>
        Public Property CampaignID() As Nullable(Of Integer)
        <Required>
        <Column("START_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StartDate() As Date
        <Required>
        <Column("END_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property EndDate() As Date
        <Required>
        <Column("MEDIA_BROADCAST_WORKSHEET_DATE_TYPE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaBroadcastWorksheetDateTypeID() As Integer
        <Required>
        <Column("MEDIA_CALENDAR_TYPE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaCalendarTypeID() As Integer
        <Column("MEDIA_PLAN_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.MediaPlanID)>
        Public Property MediaPlanID() As Nullable(Of Integer)
        <Required>
        <Column("IS_INACTIVE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsInactive() As Boolean
        <Required>
        <Column("DEFAULT_TO_LATEST_SHAREBOOK")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property DefaultToLatestSharebook() As Boolean
        <Required>
        <Column("ARE_PIGGYBACKS_OK")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ArePiggybacksOK() As Boolean
        <Required>
        <Column("PRORATE_SECONDARY_DEMOS_TO_PRIMARY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ProrateSecondaryDemosToPrimary() As Boolean
        <Column("PRIMARY_MEDIA_DEMO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PrimaryMediaDemographicID() As Nullable(Of Integer)
        <Required>
        <MaxLength(100)>
        <Column("USER_CREATED", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CreatedByUserCode() As String
        <Required>
        <Column("CREATED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CreatedDate() As Date
        <MaxLength(100)>
        <Column("USER_MODIFIED", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedByUserCode() As String
        <Column("MODIFIED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedDate() As Nullable(Of Date)
        <Required>
        <Column("LENGTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Length() As Short
        <Required>
        <Column("RATINGS_SERVICE_ID")>
        Public Property RatingsServiceID() As AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID
        <Column("COMMENT", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Comment() As String
        <Required>
        <Column("IS_GROSS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsGross() As Boolean
        <Required>
        <Column("USE_OLD_CALENDAR_DATE_CREATION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property UseOldCalendarDateCreation() As Boolean
        <Required>
        <Column("COUNTRY_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CountryID() As Integer
        <Required>
        <Column("NPR_PREPOPULATE_DATES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property NPRPrepopulateDates() As Boolean

        Public Overridable Property Client As Database.Entities.Client
        <ForeignKey("ClientCode, DivisionCode")>
        Public Overridable Property Division As Database.Entities.Division
        <ForeignKey("ClientCode, DivisionCode, ProductCode")>
        Public Overridable Property Product As Database.Entities.Product
        Public Overridable Property SalesClass As Database.Entities.SalesClass
        Public Overridable Property Campaign As Database.Entities.Campaign
        Public Overridable Property MediaBroadcastWorksheetDateType As Database.Entities.MediaBroadcastWorksheetDateType
        Public Overridable Property MediaPlan As Database.Entities.MediaPlan
        <ForeignKey("PrimaryMediaDemographicID")>
        Public Overridable Property PrimaryMediaDemographic As Database.Entities.MediaDemographic
        Public Overridable Property MediaBroadcastWorksheetMarkets As ICollection(Of Database.Entities.MediaBroadcastWorksheetMarket)
        Public Overridable Property Country As Database.Entities.Country

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.Name.ToString

        End Function

#End Region

    End Class

End Namespace
