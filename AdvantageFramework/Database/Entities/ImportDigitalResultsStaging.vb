Namespace Database.Entities

    <Table("IMP_DIGITAL_RESULTS_STAGING")>
    Public Class ImportDigitalResultsStaging
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            BatchName
            MediaPlanID
            ClientCode
            ClientName
            DivisionCode
            ProductCode
            MediaPlanDetailID
            MediaPlanDetailLevelLineID
            MediaType
            SalesClassCode
            CampaignCode
            CampaignID
            CampaignName
            VendorCode
            VendorName
            MarketCode
            AdSizeCode
            AdNumber
            AdNumberDescription
            InternetTypeCode
            Placement
            PlacementPixelSize
            PlacementURL
            Creative
            Tactic
            PagePositioning
            ResultDate
            NetGrossRate
            Units
            Impressions
            Clicks
            ClickRate
            TotalConversions
            Rate
            NetDollars
            GrossDollars
            TemplateID
            EndDate
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            MarketDescription
            InternetTypeDescription
            AdSizeDescription
            TargetAudience
            ImpressionsViewable
            ImpressionsMeasurable
            TotalConversionsB
            TotalConversionsC
            Leads1
            Leads2
            Calls
            LikesOrganic
            LikesPaid
            Visits
            UniqueVisitors
            ReachOrganic
            ReachPaid
            PageViews
            PageEngagement
            Note
            ClientSales
            PlacementID
            AdServerSource
            DaypartCode
        End Enum

#End Region

#Region " Variables "

        Private _DigitalResultError As AdvantageFramework.Database.Classes.DigitalResultError = Nothing
        Private _ValidatingUsingErrorObject As Boolean = False

#End Region

#Region " Properties "

        <Column("IMPORT_ID")>
        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer

        <Column("BATCH_NAME", TypeName:="varchar")>
        <MaxLength(50)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property BatchName() As String

        <Column("MEDIA_PLAN_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Media Plan", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.MediaPlanID, IsImportDefaultProperty:=True)>
        Public Property MediaPlanID() As Nullable(Of Integer)

        <Column("CL_CODE", TypeName:="varchar")>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode, IsImportDefaultProperty:=True)>
        Public Property ClientCode() As String

        <Column("CL_NAME", TypeName:="varchar")>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.ClientName)>
        Public Property ClientName() As String

        <Column("DIV_CODE", TypeName:="varchar")>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode, IsImportDefaultProperty:=True)>
        Public Property DivisionCode() As String

        <Column("PRD_CODE", TypeName:="varchar")>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ProductCode, IsImportDefaultProperty:=True)>
        Public Property ProductCode() As String

        <Column("JOB_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property JobNumber() As Nullable(Of Integer)

        <Column("JOB_DESC", TypeName:="varchar")>
        <MaxLength(60)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property JobDescription() As String

        <Column("JOB_COMPONENT_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property JobComponentNumber() As Nullable(Of Short)

        <Column("JOB_COMP_DESC", TypeName:="varchar")>
        <MaxLength(60)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property JobComponentDescription() As String

        <Column("MEDIA_PLAN_DTL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Estimate ID", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.MediaPlanDetailID, IsImportDefaultProperty:=True)>
        Public Property MediaPlanDetailID() As Nullable(Of Integer)

        <Column("MEDIA_PLAN_DTL_LEVEL_LINE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanDetailLevelLineID() As Nullable(Of Integer)

        <Column("MEDIA_TYPE", TypeName:="varchar")>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.MediaType, IsImportDefaultProperty:=True)>
        Public Property MediaType() As String

        <Column("SC_CODE", TypeName:="varchar")>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SalesClassCode, IsImportDefaultProperty:=True)>
        Public Property SalesClassCode() As String

        <Column("CMP_IDENTIFIER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.CampaignID, IsImportDefaultProperty:=True)>
        Public Property CampaignID() As Nullable(Of Integer)

        <Column("CMP_CODE", TypeName:="varchar")>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.CampaignCode)>
        Public Property CampaignCode() As String

        <Column("CMP_NAME", TypeName:="varchar")>
        <MaxLength(128)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.CampaignName)>
        Public Property CampaignName() As String

        <Column("VN_CODE", TypeName:="varchar")>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.VendorCode, IsImportDefaultProperty:=True)>
        Public Property VendorCode() As String

        <Column("VN_NAME", TypeName:="varchar")>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.VendorName)>
        Public Property VendorName() As String

        <Column("MARKET_CODE", TypeName:="varchar")>
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.MarketCode, IsImportDefaultProperty:=True)>
        Public Property MarketCode() As String

        <MaxLength(40)>
        <Column("MARKET_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.MarketDescription)>
        Public Property MarketDescription() As String

        <Column("AD_SIZE_CODE", TypeName:="varchar")>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.AdSizeCode, IsImportDefaultProperty:=True)>
        Public Property AdSizeCode() As String

        <Column("AD_SIZE_DESC", TypeName:="varchar")>
        <MaxLength(30)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.AdSizeDescription)>
        Public Property AdSizeDescription() As String

        <Column("AD_NBR", TypeName:="varchar")>
        <MaxLength(30)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.AdNumber, IsImportDefaultProperty:=True)>
        Public Property AdNumber() As String

        <Column("AD_NBR_DESC", TypeName:="varchar")>
        <MaxLength(60)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.AdNumberDescription)>
        Public Property AdNumberDescription() As String

        <MaxLength(6)>
        <Column("INTERNET_TYPE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.InternetType, IsImportDefaultProperty:=True)>
        Public Property InternetTypeCode() As String

        <Column("OD_DESC", TypeName:="varchar")>
        <MaxLength(30)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.InternetTypeDescription)>
        Public Property InternetTypeDescription() As String

        <Column("TARGET_AUDIENCE", TypeName:="varchar")>
        <MaxLength(60)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsImportDefaultProperty:=True)>
        Public Property TargetAudience() As String

        <MaxLength(256)>
        <Column("PLACEMENT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsImportDefaultProperty:=True)>
        Public Property Placement() As String

        <MaxLength(60)>
        <Column("PLACEMENT_PX_SIZE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsImportDefaultProperty:=True)>
        Public Property PlacementPixelSize() As String

        <MaxLength(60)>
        <Column("PLACEMENT_URL", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsImportDefaultProperty:=True)>
        Public Property PlacementURL() As String

        <MaxLength(256)>
        <Column("CREATIVE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsImportDefaultProperty:=True)>
        Public Property Creative() As String
        <Column("TACTIC", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsImportDefaultProperty:=True)>
        Public Property Tactic() As String
        <Column("PAGE_POSITIONING", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsImportDefaultProperty:=True)>
        Public Property PagePositioning() As String

        <Column("RESULT_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Start Date", IsImportDefaultProperty:=True)>
        Public Property ResultDate() As Nullable(Of Date)

        <Column("END_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="", IsImportDefaultProperty:=True)>
        Public Property EndDate() As Nullable(Of Date)

        <Column("NET_GROSS_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Net / Gross Rate", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.RateType, IsImportDefaultProperty:=True)>
        Public Property NetGrossRate() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 2)>
        <Column("UNITS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n1")>
        Public Property Units() As Nullable(Of Decimal)

        <Column("IMPRESSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=2147483647)>
        Public Property Impressions() As Nullable(Of Integer)

        <Column("IMPRESSIONS_VIEWABLE")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(12, 2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=2147483647)>
        Public Property ImpressionsViewable() As Nullable(Of Decimal)

        <Column("IMPRESSIONS_MEASUREABLE")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(12, 2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=2147483647)>
        Public Property ImpressionsMeasurable() As Nullable(Of Decimal)

        <Column("CLICKS")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0")>
        Public Property Clicks() As Nullable(Of Decimal)

        <Column("CLICK_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ClickRate() As Nullable(Of Decimal)

        <Column("TOTAL_CONVERSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(12, 2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=2147483647)>
        Public Property TotalConversions() As Nullable(Of Decimal)

        <Column("TOTAL_CONVERSIONS_B")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(12, 2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=2147483647)>
        Public Property TotalConversionsB() As Nullable(Of Decimal)

        <Column("TOTAL_CONVERSIONS_C")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(12, 2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=2147483647)>
        Public Property TotalConversionsC() As Nullable(Of Decimal)

        <Column("RATE")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Rate() As Nullable(Of Decimal)

        <Column("NET_DOLLARS")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property NetDollars() As Nullable(Of Decimal)

        <Column("GROSS_DOLLARS")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property GrossDollars() As Nullable(Of Decimal)

        <Column("LEADS1")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999999999)>
        Public Property Leads1() As Nullable(Of Decimal)

        <Column("LEADS2")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999999999)>
        Public Property Leads2() As Nullable(Of Decimal)

        <Column("CALLS")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999999999)>
        Public Property Calls() As Nullable(Of Decimal)

        <Column("LIKES_ORGANIC")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999999999)>
        Public Property LikesOrganic() As Nullable(Of Decimal)

        <Column("LIKES_PAID")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999999999)>
        Public Property LikesPaid() As Nullable(Of Decimal)

        <Column("VISITS")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999999999)>
        Public Property Visits() As Nullable(Of Decimal)

        <Column("UNIQUE_VISITORS")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999999999)>
        Public Property UniqueVisitors() As Nullable(Of Decimal)

        <Column("REACH_ORGANIC")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999999999)>
        Public Property ReachOrganic() As Nullable(Of Decimal)

        <Column("REACH_PAID")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999999999)>
        Public Property ReachPaid() As Nullable(Of Decimal)

        <Column("PAGE_VIEWS")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999999999)>
        Public Property PageViews() As Nullable(Of Decimal)

        <Column("PAGE_ENGAGEMENT")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999999999)>
        Public Property PageEngagement() As Nullable(Of Decimal)

        <Required>
        <Column("TEMPLATE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property TemplateID() As Integer

        <Column("CLIENT_SALES")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ClientSales() As Nullable(Of Decimal)

        <Column("NOTE", TypeName:="varchar")>
        <MaxLength(200)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Note() As String

        <Column("PLACEMENT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property PlacementID() As Nullable(Of Int64)

        <Column("AD_SERVER_SOURCE", TypeName:="varchar")>
        <MaxLength(25)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdServerSource() As String

        <Column("DAY_PART_CODE", TypeName:="varchar")>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DaypartCode)>
        Public Property DaypartCode() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = Nothing

            IsValid = True

            If _ValidatingUsingErrorObject AndAlso
                    (PropertyName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.MediaPlanID.ToString OrElse
                     PropertyName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.ClientCode.ToString OrElse
                     PropertyName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.DivisionCode.ToString OrElse
                     PropertyName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.ProductCode.ToString OrElse
                     PropertyName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.MediaPlanDetailID.ToString OrElse
                     PropertyName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.SalesClassCode.ToString OrElse
                     PropertyName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.CampaignID.ToString OrElse
                     PropertyName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.CampaignCode.ToString OrElse
                     PropertyName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.VendorCode.ToString OrElse
                     PropertyName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.MarketCode.ToString OrElse
                     PropertyName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.AdSizeCode.ToString OrElse
                     PropertyName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.AdNumber.ToString OrElse
                     PropertyName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.InternetTypeCode.ToString OrElse
                     PropertyName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.DaypartCode.ToString) Then

                ErrorText = ValidatePropertyWithErrorObject(PropertyName, IsValid)

                _ErrorHashtable(PropertyName) = ErrorText

                ValidateEntityProperty = ErrorText

            Else

                ValidateEntityProperty = MyBase.ValidateEntityProperty(PropertyName, IsValid, Value)

            End If

        End Function
        Private Function ValidatePropertyWithErrorObject(ByVal PropertyName As String, ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorMessage As String = Nothing

            If _DigitalResultError IsNot Nothing Then

                Select Case PropertyName

                    Case AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.MediaPlanID.ToString

                        ErrorMessage = _DigitalResultError.MediaPlanErrorMessage

                    Case AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.ClientCode.ToString

                        ErrorMessage = _DigitalResultError.ClientErrorMessage

                    Case AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.DivisionCode.ToString

                        ErrorMessage = _DigitalResultError.DivisionErrorMessage

                    Case AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.ProductCode.ToString

                        ErrorMessage = _DigitalResultError.ProductErrorMessage

                    Case AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.MediaPlanDetailID.ToString

                        ErrorMessage = _DigitalResultError.MediaPlanDetailErrorMessage

                    Case AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.SalesClassCode.ToString

                        ErrorMessage = _DigitalResultError.SalesClassErrorMessage

                    Case AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.CampaignID.ToString

                        ErrorMessage = _DigitalResultError.CampaignErrorMessage

                    Case AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.CampaignCode.ToString

                        ErrorMessage = _DigitalResultError.CampaignErrorMessage

                    Case AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.VendorCode.ToString

                        ErrorMessage = _DigitalResultError.VendorErrorMessage

                    Case AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.MarketCode.ToString

                        ErrorMessage = _DigitalResultError.MarketErrorMessage

                    Case AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.AdSizeCode.ToString

                        ErrorMessage = _DigitalResultError.AdSizeErrorMessage

                    Case AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.AdNumber.ToString

                        ErrorMessage = _DigitalResultError.AdNumberErrorMessage

                    Case AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.InternetTypeCode.ToString

                        ErrorMessage = _DigitalResultError.InternetTypeErrorMessage

                    Case AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.DaypartCode.ToString

                        ErrorMessage = _DigitalResultError.DaypartCodeErrorMessage

                    Case Else

                        ErrorMessage = Nothing

                End Select

            Else

                ErrorMessage = Nothing
                IsValid = True

            End If

            If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                IsValid = False

            End If

            ValidatePropertyWithErrorObject = ErrorMessage

        End Function
        Public Sub SetDigitalResultErrorObject(ByVal DigitalResultError As AdvantageFramework.Database.Classes.DigitalResultError)

            _DigitalResultError = DigitalResultError

        End Sub
        Public Sub ValidateUsingErrorObject()

            'objects
            Dim IsValid As Boolean = True

            Try

                _ValidatingUsingErrorObject = True

                Me.ValidateEntity(IsValid)

            Catch ex As Exception

            Finally

                _ValidatingUsingErrorObject = False

            End Try

        End Sub

#End Region

    End Class

End Namespace
