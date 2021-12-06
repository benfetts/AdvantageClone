Namespace DTO.Media.MediaBroadcastWorksheet

    Public Class Worksheet
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaTypeCode
            MediaTypeDescription
            MediaType
            Name
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            SalesClassCode
            SalesClassDescription
            CampaignID
            CampaignCode
            CampaignName
            StartDate
            EndDate
            MediaBroadcastWorksheetDateTypeID
            MediaBroadcastWorksheetDateType
            MediaCalendarTypeID
            MediaCalendarType
            MediaPlanID
            MediaPlanDescription
            IsInactive
            CountryID
            Country
            DefaultToLatestSharebook
            ArePiggybacksOK
            ProrateSecondaryDemosToPrimary
            PrimaryMediaDemographicID
            PrimaryMediaDemographicCode
            PrimaryMediaDemographicDescription
            PrimaryMediaDemographicIsMales
            PrimaryMediaDemographicIsFemales
            PrimaryMediaDemographicAgeFrom
            PrimaryMediaDemographicAgeTo
            CreatedByUserCode
            CreatedDate
            ModifiedByUserCode
            ModifiedDate
            Length
            RatingsServiceID
            Comment
            MediaPlanComments
            IsGross
            UseOldCalendarDateCreation
            PendingMakegood
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <System.ComponentModel.DisplayName("WS ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <MaxLength(1)>
        <System.ComponentModel.DisplayName("Media Type")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaTypeCode() As String
        <Required>
        <System.ComponentModel.DisplayName("Media Type")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=True)>
        Public Property MediaTypeDescription() As String
        <Required>
        <System.ComponentModel.DisplayName("Media Type")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaType() As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes
        <Required>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Name() As String
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
        Public Property ClientName() As String
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.DivisionCode)>
        Public Property DivisionCode() As String
        Public Property DivisionName() As String
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.ProductCode)>
        Public Property ProductCode() As String
        Public Property ProductName() As String
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.SalesClassCode, ShowColumnInGrid:=False)>
        Public Property SalesClassCode() As String
        <System.ComponentModel.DisplayName("Sales Class")>
        Public Property SalesClassDescription() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.CampaignID, ShowColumnInGrid:=False)>
        Public Property CampaignID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        <System.ComponentModel.DisplayName("Campaign")>
        Public Property CampaignCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        <System.ComponentModel.DisplayName("Campaign Name")>
        Public Property CampaignName() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StartDate() As Date
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property EndDate() As Date
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaBroadcastWorksheetDateTypeID() As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.DateTypes
        <System.ComponentModel.DisplayName("Date Type")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaBroadcastWorksheetDateType() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaCalendarTypeID() As AdvantageFramework.DTO.Media.CalendarTypes
        <System.ComponentModel.DisplayName("Calendar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaCalendarType() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.MediaPlanID, ShowColumnInGrid:=False)>
        Public Property MediaPlanID() As Nullable(Of Integer)
        <System.ComponentModel.DisplayName("Media Plan")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaPlanDescription() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsInactive() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        <System.ComponentModel.DisplayName("Country")>
        Public Property CountryID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Country() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property DefaultToLatestSharebook() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ArePiggybacksOK() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ProrateSecondaryDemosToPrimary() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, PropertyType:=BaseClasses.Methods.PropertyTypes.MediaDemographic)>
        Public Property PrimaryMediaDemographicID() As Nullable(Of Integer)
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property PrimaryMediaDemographicCode() As String
        <MaxLength(50)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property PrimaryMediaDemographicDescription() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property PrimaryMediaDemographicIsMales() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property PrimaryMediaDemographicIsFemales() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property PrimaryMediaDemographicAgeFrom() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property PrimaryMediaDemographicAgeTo() As Nullable(Of Short)
        <Required>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CreatedByUserCode() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CreatedDate() As Date
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedByUserCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedDate() As Nullable(Of Date)
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Length() As Short
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property RatingsServiceID() As AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Comment() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanComments() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsGross() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property UseOldCalendarDateCreation() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property PendingMakegood() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property IsUSWorksheet As Boolean
            Get
                IsUSWorksheet = (Me.CountryID = AdvantageFramework.DTO.Countries.UnitedStates)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property IsCanadianWorksheet As Boolean
            Get
                IsCanadianWorksheet = (Me.CountryID = AdvantageFramework.DTO.Countries.Canada)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property DoesWorksheetAllowSubmarkets As Boolean
            Get
                DoesWorksheetAllowSubmarkets = (Me.IsCanadianWorksheet AndAlso Me.MediaType = MediaTypes.SpotTV)
            End Get
        End Property
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property NPRPrepopulateDates() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.MediaTypeCode = "T"
            Me.MediaTypeDescription = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV.ToString)
            Me.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV
            Me.Name = String.Empty
            Me.ClientCode = String.Empty
            Me.ClientName = String.Empty
            Me.DivisionCode = String.Empty
            Me.DivisionName = String.Empty
            Me.ProductCode = String.Empty
            Me.ProductName = String.Empty
            Me.SalesClassCode = String.Empty
            Me.SalesClassDescription = String.Empty
            Me.CampaignID = Nothing
            Me.CampaignName = String.Empty
            Me.StartDate = CDate(Now.ToShortDateString)
            Me.EndDate = CDate(Now.ToShortDateString)
            Me.MediaBroadcastWorksheetDateTypeID = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.DateTypes.Weekly
            Me.MediaBroadcastWorksheetDateType = String.Empty
            Me.MediaCalendarTypeID = AdvantageFramework.DTO.Media.CalendarTypes.Broadcast
            Me.MediaCalendarType = String.Empty
            Me.MediaPlanID = Nothing
            Me.MediaPlanDescription = String.Empty
            Me.IsInactive = False
            Me.CountryID = AdvantageFramework.DTO.Countries.UnitedStates
            Me.Country = String.Empty
            Me.DefaultToLatestSharebook = True
            Me.ArePiggybacksOK = False
            Me.ProrateSecondaryDemosToPrimary = False
            Me.PrimaryMediaDemographicID = Nothing
            Me.PrimaryMediaDemographicCode = String.Empty
            Me.PrimaryMediaDemographicDescription = String.Empty
            Me.PrimaryMediaDemographicIsMales = False
            Me.PrimaryMediaDemographicIsFemales = False
            Me.PrimaryMediaDemographicAgeFrom = Nothing
            Me.PrimaryMediaDemographicAgeTo = Nothing
            Me.CreatedByUserCode = String.Empty
            Me.CreatedDate = Date.MinValue
            Me.ModifiedByUserCode = Nothing
            Me.ModifiedDate = Nothing
            Me.Length = 0
            Me.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen
            Me.Comment = Nothing
            Me.IsGross = True
            Me.UseOldCalendarDateCreation = False
            Me.NPRPrepopulateDates = False

        End Sub
        Public Sub New(MediaBroadcastWorksheet As AdvantageFramework.Database.Entities.MediaBroadcastWorksheet)

            Me.ID = MediaBroadcastWorksheet.ID
            Me.MediaTypeCode = MediaBroadcastWorksheet.MediaTypeCode

            Select Case Me.MediaTypeCode

                Case "R"

                    Me.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio
                    Me.MediaTypeDescription = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio.ToString)

                Case "T"

                    Me.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV
                    Me.MediaTypeDescription = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV.ToString)

                    'Case "N"

                    '	Me.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.NetworkTV
                    '	Me.MediaTypeDescription = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.NetworkTV.ToString)

            End Select

            Me.Name = MediaBroadcastWorksheet.Name
            Me.ClientCode = MediaBroadcastWorksheet.ClientCode
            Me.ClientName = MediaBroadcastWorksheet.Client.Name
            Me.DivisionCode = MediaBroadcastWorksheet.DivisionCode
            Me.DivisionName = MediaBroadcastWorksheet.Division.Name
            Me.ProductCode = MediaBroadcastWorksheet.ProductCode
            Me.ProductName = MediaBroadcastWorksheet.Product.Name
            Me.SalesClassCode = MediaBroadcastWorksheet.SalesClassCode
            Me.SalesClassDescription = MediaBroadcastWorksheet.SalesClass.Description
            Me.CampaignID = MediaBroadcastWorksheet.CampaignID
            Me.CampaignCode = If(MediaBroadcastWorksheet.Campaign IsNot Nothing, MediaBroadcastWorksheet.Campaign.Code, String.Empty)
            Me.CampaignName = If(MediaBroadcastWorksheet.Campaign IsNot Nothing, MediaBroadcastWorksheet.Campaign.Name, String.Empty)
            Me.StartDate = CDate(MediaBroadcastWorksheet.StartDate.ToShortDateString)
            Me.EndDate = CDate(MediaBroadcastWorksheet.EndDate.ToShortDateString)
            Me.MediaBroadcastWorksheetDateTypeID = [Enum].Parse(GetType(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.DateTypes), MediaBroadcastWorksheet.MediaBroadcastWorksheetDateTypeID)
            Me.MediaBroadcastWorksheetDateType = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.DateTypes), MediaBroadcastWorksheet.MediaBroadcastWorksheetDateTypeID)
            Me.MediaCalendarTypeID = [Enum].Parse(GetType(AdvantageFramework.DTO.Media.CalendarTypes), MediaBroadcastWorksheet.MediaCalendarTypeID)
            Me.MediaCalendarType = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.DTO.Media.CalendarTypes), MediaBroadcastWorksheet.MediaCalendarTypeID)
            Me.MediaPlanID = MediaBroadcastWorksheet.MediaPlanID
            Me.MediaPlanDescription = If(MediaBroadcastWorksheet.MediaPlan IsNot Nothing, MediaBroadcastWorksheet.MediaPlan.Description, String.Empty)
            Me.IsInactive = MediaBroadcastWorksheet.IsInactive
            Me.CountryID = MediaBroadcastWorksheet.CountryID
            Me.Country = If(MediaBroadcastWorksheet.Country IsNot Nothing, MediaBroadcastWorksheet.Country.Name, String.Empty)
            Me.DefaultToLatestSharebook = MediaBroadcastWorksheet.DefaultToLatestSharebook
            Me.ArePiggybacksOK = MediaBroadcastWorksheet.ArePiggybacksOK
            Me.ProrateSecondaryDemosToPrimary = MediaBroadcastWorksheet.ProrateSecondaryDemosToPrimary
            Me.PrimaryMediaDemographicID = MediaBroadcastWorksheet.PrimaryMediaDemographicID
            Me.PrimaryMediaDemographicCode = If(MediaBroadcastWorksheet.PrimaryMediaDemographic IsNot Nothing, MediaBroadcastWorksheet.PrimaryMediaDemographic.Code, String.Empty)
            Me.PrimaryMediaDemographicDescription = If(MediaBroadcastWorksheet.PrimaryMediaDemographic IsNot Nothing, MediaBroadcastWorksheet.PrimaryMediaDemographic.Description, String.Empty)
            Me.PrimaryMediaDemographicIsMales = If(MediaBroadcastWorksheet.PrimaryMediaDemographic IsNot Nothing, MediaBroadcastWorksheet.PrimaryMediaDemographic.IsMales, False)
            Me.PrimaryMediaDemographicIsFemales = If(MediaBroadcastWorksheet.PrimaryMediaDemographic IsNot Nothing, MediaBroadcastWorksheet.PrimaryMediaDemographic.IsFemales, False)
            Me.PrimaryMediaDemographicAgeFrom = If(MediaBroadcastWorksheet.PrimaryMediaDemographic IsNot Nothing, MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeFrom, Nothing)
            Me.PrimaryMediaDemographicAgeTo = If(MediaBroadcastWorksheet.PrimaryMediaDemographic IsNot Nothing, MediaBroadcastWorksheet.PrimaryMediaDemographic.AgeTo, Nothing)
            Me.CreatedByUserCode = MediaBroadcastWorksheet.CreatedByUserCode
            Me.CreatedDate = MediaBroadcastWorksheet.CreatedDate
            Me.ModifiedByUserCode = MediaBroadcastWorksheet.ModifiedByUserCode
            Me.ModifiedDate = MediaBroadcastWorksheet.ModifiedDate
            Me.Length = MediaBroadcastWorksheet.Length
            Me.RatingsServiceID = If(MediaBroadcastWorksheet.RatingsServiceID = 0, AdvantageFramework.Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen, MediaBroadcastWorksheet.RatingsServiceID)
            Me.Comment = MediaBroadcastWorksheet.Comment
            Me.IsGross = MediaBroadcastWorksheet.IsGross
            Me.UseOldCalendarDateCreation = MediaBroadcastWorksheet.UseOldCalendarDateCreation
            Me.NPRPrepopulateDates = MediaBroadcastWorksheet.NPRPrepopulateDates

        End Sub
        Public Sub SaveToEntity(ByRef MediaBroadcastWorksheet As AdvantageFramework.Database.Entities.MediaBroadcastWorksheet)

            MediaBroadcastWorksheet.MediaTypeCode = Me.MediaTypeCode
            MediaBroadcastWorksheet.Name = Me.Name
            MediaBroadcastWorksheet.ClientCode = Me.ClientCode
            MediaBroadcastWorksheet.DivisionCode = Me.DivisionCode
            MediaBroadcastWorksheet.ProductCode = Me.ProductCode
            MediaBroadcastWorksheet.SalesClassCode = Me.SalesClassCode
            MediaBroadcastWorksheet.CampaignID = Me.CampaignID
            MediaBroadcastWorksheet.StartDate = CDate(Me.StartDate.ToShortDateString)
            MediaBroadcastWorksheet.EndDate = CDate(Me.EndDate.ToShortDateString)
            MediaBroadcastWorksheet.MediaBroadcastWorksheetDateTypeID = Me.MediaBroadcastWorksheetDateTypeID
            MediaBroadcastWorksheet.MediaCalendarTypeID = Me.MediaCalendarTypeID
            MediaBroadcastWorksheet.MediaPlanID = Me.MediaPlanID
            MediaBroadcastWorksheet.IsInactive = Me.IsInactive
            MediaBroadcastWorksheet.CountryID = Me.CountryID
            MediaBroadcastWorksheet.DefaultToLatestSharebook = Me.DefaultToLatestSharebook
            MediaBroadcastWorksheet.ArePiggybacksOK = Me.ArePiggybacksOK
            MediaBroadcastWorksheet.ProrateSecondaryDemosToPrimary = Me.ProrateSecondaryDemosToPrimary
            MediaBroadcastWorksheet.PrimaryMediaDemographicID = Me.PrimaryMediaDemographicID
            MediaBroadcastWorksheet.CreatedByUserCode = Me.CreatedByUserCode
            MediaBroadcastWorksheet.CreatedDate = Me.CreatedDate
            MediaBroadcastWorksheet.ModifiedByUserCode = Me.ModifiedByUserCode
            MediaBroadcastWorksheet.ModifiedDate = Me.ModifiedDate
            MediaBroadcastWorksheet.Length = Me.Length
            MediaBroadcastWorksheet.RatingsServiceID = Me.RatingsServiceID
            MediaBroadcastWorksheet.Comment = Me.Comment
            MediaBroadcastWorksheet.IsGross = Me.IsGross
            MediaBroadcastWorksheet.UseOldCalendarDateCreation = Me.UseOldCalendarDateCreation
            MediaBroadcastWorksheet.NPRPrepopulateDates = Me.NPRPrepopulateDates

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.Name.ToString

        End Function

#End Region

    End Class

End Namespace
