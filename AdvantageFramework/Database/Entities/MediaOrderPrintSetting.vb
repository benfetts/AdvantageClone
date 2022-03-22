Namespace Database.Entities

    <System.ComponentModel.DataAnnotations.Schema.Table("MEDIA_PRINT_DEF")>
    Public Class MediaOrderPrintSetting
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            UserCode
            MediaType
            LocationID
            LogoPath
            ReportLevel
            DateOverride
            Rep1Label
            Rep2Label
            IncludeRep1
            IncludeRep2
            ReportFormat
            Headline
            Location
            Edition
            Material
            ProductionSize
            SpaceCloseDate
            AdNumber
            JobNumber
            MaterialNotes
            PositionInfo
            CloseInfo
            RateInfo
            MiscInfo
            Instructions
            OrderCopy
            MaterialDueDate
            Issue
            Type
            CopyArea
            Placement1
            Placement2
            URL
            TargetAudience
            Section
            DefaultLabelFromVendor1
            DefaultLabelFromVendor2
            Market
            Guaranteed
            Projected
            Actual
            CostPer
            MediaTitleOption
            Campaign
            ShippingAddress
            ExcludeEmployeeSignature
            Programming
            StartTime
            EndTime
            Length
            Remarks
            PrintRevision
            OrderHeaderCommentOption
            Days
            Daypart
            AddedValue
            Bookends
            PrimaryRatings
            PrimaryCPP
            SeparationPolicy
            AgencyCommission
            PutSignatureBelowAllComments
            PrintDayDate
            PrimaryCPM
            PrimaryImpressions
            PrimaryAQH
            RemoveSignatureLines
            ShowLineNumbers
            IncludeFlighting
            IncludeLineMarket
            InternetQtyOverrideText
            BroadcastShowEmptyWeeks
            ApplyExchangeRate
            ExchangeRate
            MediaTitleOverride
            IncludeClientAddress
            IncludeImpressions
            ShowTotalNetForGrossOrder
            NewspaperIncludeCirculationQTY
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.ComponentModel.DataAnnotations.Key>
        <System.ComponentModel.DataAnnotations.Schema.Column("USER_ID", Order:=0)>
        <System.ComponentModel.DataAnnotations.MaxLength(100)>
        Public Property UserCode As String

        <System.ComponentModel.DataAnnotations.Key>
        <System.ComponentModel.DataAnnotations.Schema.Column("MEDIA_TYPE", Order:=1)>
        <System.ComponentModel.DataAnnotations.MaxLength(2)>
        Public Property MediaType As String

        <System.ComponentModel.DataAnnotations.MaxLength(6)>
        <System.ComponentModel.DataAnnotations.Schema.Column("LOCATION_ID")>
        Public Property LocationID As String

        <System.ComponentModel.DataAnnotations.MaxLength(100)>
        <System.ComponentModel.DataAnnotations.Schema.Column("LOGO_PATH")>
        Public Property LogoPath As String

        <System.ComponentModel.DataAnnotations.MaxLength(1)>
        <System.ComponentModel.DataAnnotations.Schema.Column("RPT_LEVEL")>
        Public Property ReportLevel As String

        <System.ComponentModel.DataAnnotations.Schema.Column("DATE_OVERRIDE")>
        Public Property DateOverride As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.MaxLength(20)>
        <System.ComponentModel.DataAnnotations.Schema.Column("REP_LABEL1")>
        Public Property Rep1Label As String

        <System.ComponentModel.DataAnnotations.MaxLength(20)>
        <System.ComponentModel.DataAnnotations.Schema.Column("REP_LABEL2")>
        Public Property Rep2Label As String

        <System.ComponentModel.DataAnnotations.Schema.Column("INCLUDE_REP1")>
        Public Property IncludeRep1 As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("INCLUDE_REP2")>
        Public Property IncludeRep2 As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.MaxLength(50)>
        <System.ComponentModel.DataAnnotations.Schema.Column("RPT_FORMAT")>
        Public Property ReportFormat As String

        <System.ComponentModel.DataAnnotations.Schema.Column("HEADLINE_FLAG")>
        Public Property Headline As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("LOCATION_FLAG")>
        Public Property Location As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("EDITION_FLAG")>
        Public Property Edition As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("MATERIAL_FLAG")>
        Public Property Material As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("PROD_SPECS_FLAG")>
        Public Property ProductionSize As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("SPACE_CLOSE_FLAG")>
        Public Property SpaceCloseDate As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("AD_NUMBER_FLAG")>
        Public Property AdNumber As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("JOB_NUMBER_FLAG")>
        Public Property JobNumber As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("MATL_NOTES_FLAG")>
        Public Property MaterialNotes As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("POSITION_FLAG")>
        Public Property PositionInfo As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("CLOSE_INFO_FLAG")>
        Public Property CloseInfo As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("RATE_INFO_FLAG")>
        Public Property RateInfo As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("MISC_INFO_FLAG")>
        Public Property MiscInfo As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("INSTRUCTIONS_FLAG")>
        Public Property Instructions As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("ORDER_COPY_FLAG")>
        Public Property OrderCopy As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("MATL_DUE_FLAG")>
        Public Property MaterialDueDate As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("ISSUE_FLAG")>
        Public Property Issue As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("TYPE_FLAG")>
        Public Property Type As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("COPY_AREA_FLAG")>
        Public Property CopyArea As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("PLACE1_FLAG")>
        Public Property Placement1 As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("PLACE2_FLAG")>
        Public Property Placement2 As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("URL_FLAG")>
        Public Property URL As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("TARGET_FLAG")>
        Public Property TargetAudience As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("SECTION_FLAG")>
        Public Property Section As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("DEF_REP_LABEL1")>
        Public Property DefaultLabelFromVendor1 As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("DEF_REP_LABEL2")>
        Public Property DefaultLabelFromVendor2 As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("MARKET_FLAG")>
        Public Property Market As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("GUARANTEED_FLAG")>
        Public Property Guaranteed As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("PROJECTED_FLAG")>
        Public Property Projected As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("ACTUAL_FLAG")>
        Public Property Actual As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("COST_PER_FLAG")>
        Public Property CostPer As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.MaxLength(1)>
        <System.ComponentModel.DataAnnotations.Schema.Column("TITLE_OPTION")>
        Public Property MediaTitleOption As String

        <System.ComponentModel.DataAnnotations.Schema.Column("CAMPAIGN_FLAG")>
        Public Property Campaign As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("SHIP_ADDR_FLAG")>
        Public Property ShippingAddress As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("USE_EMP_SIG")>
        Public Property ExcludeEmployeeSignature As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("PROGRAMMING_FLAG")>
        Public Property Programming As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("START_TIME_FLAG")>
        Public Property StartTime As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("END_TIME_FLAG")>
        Public Property EndTime As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("LENGTH_FLAG")>
        Public Property Length As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("REMARKS_FLAG")>
        Public Property Remarks As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("PRINT_REVISION")>
        Public Property PrintRevision As Nullable(Of Boolean)

        <System.ComponentModel.DataAnnotations.Schema.Column("PRINT_CLIENT_NAME")>
        Public Property PrintClientName As Nullable(Of Boolean)

        <System.ComponentModel.DataAnnotations.Schema.Column("PRINT_DIVISION_NAME")>
        Public Property PrintDivisionName As Nullable(Of Boolean)

        <System.ComponentModel.DataAnnotations.Schema.Column("PRINT_PRODUCT_DESCRIPTION")>
        Public Property PrintProductDescription As Nullable(Of Boolean)

        <System.ComponentModel.DataAnnotations.Schema.Column("ORDER_HEADER_COMMENT_OPTION")>
        Public Property OrderHeaderCommentOption As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("DAYS")>
        Public Property Days As Nullable(Of Boolean)

        <System.ComponentModel.DataAnnotations.Schema.Column("DAYPART")>
        Public Property Daypart As Nullable(Of Boolean)

        <System.ComponentModel.DataAnnotations.Schema.Column("ADDED_VALUE")>
        Public Property AddedValue As Nullable(Of Boolean)

        <System.ComponentModel.DataAnnotations.Schema.Column("BOOKENDS")>
        Public Property Bookends As Nullable(Of Boolean)

        <System.ComponentModel.DataAnnotations.Schema.Column("PRIMARY_RATINGS")>
        Public Property PrimaryRatings As Nullable(Of Boolean)

        <System.ComponentModel.DataAnnotations.Schema.Column("PRIMARY_CPP")>
        Public Property PrimaryCPP As Nullable(Of Boolean)

        <System.ComponentModel.DataAnnotations.Schema.Column("SEPARATION_POLICY")>
        Public Property SeparationPolicy As Nullable(Of Boolean)

        <System.ComponentModel.DataAnnotations.Schema.Column("AGENCY_COMMISSION")>
        Public Property AgencyCommission As Boolean

        <System.ComponentModel.DataAnnotations.Schema.Column("PUT_SIGNATURE_BELOW_ALL_COMMENTS")>
        Public Property PutSignatureBelowAllComments As Boolean

        <System.ComponentModel.DataAnnotations.Schema.Column("PRINT_DAY_DATE")>
        Public Property PrintDayDate As Boolean

        <System.ComponentModel.DataAnnotations.Schema.Column("PRIMARY_CPM")>
        Public Property PrimaryCPM As Boolean

        <System.ComponentModel.DataAnnotations.Schema.Column("PRIMARY_IMPRESSIONS")>
        Public Property PrimaryImpressions As Boolean

        <System.ComponentModel.DataAnnotations.Schema.Column("PRIMARY_AQH")>
        Public Property PrimaryAQH As Boolean

        <System.ComponentModel.DataAnnotations.Schema.Column("REMOVE_SIGNATURE_LINES")>
        Public Property RemoveSignatureLines As Boolean

        <System.ComponentModel.DataAnnotations.Schema.Column("SHOW_LINE_NUMBERS")>
        Public Property ShowLineNumbers As Boolean

        <System.ComponentModel.DataAnnotations.Schema.Column("INCLUDE_FLIGHTING")>
        Public Property IncludeFlighting As Boolean

        <System.ComponentModel.DataAnnotations.Schema.Column("INCLUDE_LINE_MARKET")>
        Public Property IncludeLineMarket As Boolean

        <System.ComponentModel.DataAnnotations.MaxLength(15)>
        <System.ComponentModel.DataAnnotations.Schema.Column("INTERNET_QTY_OVERRIDE_TEXT")>
        Public Property InternetQtyOverrideText As String

        <System.ComponentModel.DataAnnotations.Schema.Column("BRDCAST_SHOW_EMPTY_WEEKS")>
        Public Property BroadcastShowEmptyWeeks As Boolean

        <System.ComponentModel.DataAnnotations.Schema.Column("APPLY_EXCHANGE_RATE")>
        Public Property ApplyExchangeRate As Boolean

        <System.ComponentModel.DataAnnotations.Schema.Column("EXCHANGE_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n4")>
        Public Property ExchangeRate() As Nullable(Of Decimal)

        <System.ComponentModel.DataAnnotations.Schema.Column("MEDIA_TITLE_OVERRIDE", TypeName:="varchar")>
        Public Property MediaTitleOverride As String

        <System.ComponentModel.DataAnnotations.Schema.Column("INCLUDE_CLIENT_ADDRESS")>
        Public Property IncludeClientAddress As Boolean

        <System.ComponentModel.DataAnnotations.Schema.Column("IMPRESS_FLAG")>
        Public Property IncludeImpressions As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("SHOW_TOTALNET_ON_GROSS_ORDER")>
        Public Property ShowTotalNetForGrossOrder As Boolean

        <System.ComponentModel.DataAnnotations.Schema.Column("NP_INCLUDE_CIRC_QTY")>
        Public Property NewspaperIncludeCirculationQTY As Boolean

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.UserCode.ToUpper & " " & Me.MediaType

        End Function

#End Region

    End Class

End Namespace
