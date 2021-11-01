Namespace Database.Entities

    Public Class DigitalResultsView
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaPlanID
            MediaPlanDescription
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            EstimateID
            EstimateDescription
            MediaPlanDetailLevelLineID
            MediaType
            SalesClassCode
            SalesClassDescription
            CampaignID
            CampaignCode
            CampaignName
            VendorCode
            VendorName
            MarketCode
            MarketDescription
            AdSizeCode
            AdSizeDescription
            AdNumber
            AdNumberDescription
            InternetTypeCode
            InternetTypeDescription
            TargetAudience
            Placement
            PlacementPixelSize
            PlacementURL
            Creative
            Tactic
            PagePositioning
            StartDate
            EndDate
            NetGrossRate
            Units
            Impressions
            ImpressionsViewable
            ImpressionsMeasurable
            Clicks
            ClickRate
            TotalConversions
            TotalConversionsB
            TotalConversionsC
            Rate
            NetDollars
            GrossDollars
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

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID As Integer = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Media Plan", PropertyType:=AdvantageFramework.BaseClasses.Methods.PropertyTypes.MediaPlanID, IsImportDefaultProperty:=True)>
        Public Property MediaPlanID As Integer? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaPlanDescription As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode, IsImportDefaultProperty:=True)>
        Public Property ClientCode As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.ClientName)>
        Public Property ClientName As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode, IsImportDefaultProperty:=True)>
        Public Property DivisionCode As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.DivisionName, ShowColumnInGrid:=False)>
        Public Property DivisionName As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ProductCode, IsImportDefaultProperty:=True)>
        Public Property ProductCode As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.ProductName, ShowColumnInGrid:=False)>
        Public Property ProductName As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property JobNumber As Integer? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property JobDescription As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property JobComponentNumber As Short? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property JobComponentDescription As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.MediaPlanDetailID, IsImportDefaultProperty:=True)>
        Public Property EstimateID As Integer? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.MediaPlanDetailDescription, ShowColumnInGrid:=False)>
        Public Property EstimateDescription As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanDetailLevelLineID As Integer? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.MediaType, IsImportDefaultProperty:=True)>
        Public Property MediaType As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SalesClassCode, IsImportDefaultProperty:=True)>
        Public Property SalesClassCode As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.SalesClassDescription, ShowColumnInGrid:=False)>
        Public Property SalesClassDescription As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.CampaignID, IsImportDefaultProperty:=True)>
        Public Property CampaignID As Integer? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.CampaignCode)>
        Public Property CampaignCode As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.CampaignName)>
        Public Property CampaignName As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.VendorCode, IsImportDefaultProperty:=True)>
        Public Property VendorCode As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.VendorName)>
        Public Property VendorName As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.MarketCode, IsImportDefaultProperty:=True)>
        Public Property MarketCode As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.Methods.DefaultColumnTypes.MarketDescription)>
        Public Property MarketDescription As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.AdSizeCode, IsImportDefaultProperty:=True)>
        Public Property AdSizeCode As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.Methods.DefaultColumnTypes.AdSizeDescription)>
        Public Property AdSizeDescription As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.AdNumber, IsImportDefaultProperty:=True)>
        Public Property AdNumber As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.AdNumberDescription)>
        Public Property AdNumberDescription As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.InternetType, IsImportDefaultProperty:=True)>
        Public Property InternetTypeCode As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.InternetTypeDescription)>
        Public Property InternetTypeDescription As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsImportDefaultProperty:=True)>
        Public Property TargetAudience As String = Nothing
        Public Property Placement As String = Nothing
        Public Property PlacementPixelSize As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsImportDefaultProperty:=True)>
        Public Property PlacementURL As String = Nothing
        Public Property Creative As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsImportDefaultProperty:=True)>
        Public Property Tactic As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsImportDefaultProperty:=True)>
        Public Property PagePositioning As String = Nothing
        <System.ComponentModel.DataAnnotations.Required(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsImportDefaultProperty:=True)>
        Public Property StartDate As Date? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsImportDefaultProperty:=True)>
        Public Property EndDate As Date? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsImportDefaultProperty:=True, CustomColumnCaption:="Net / Gross Rate", PropertyType:=AdvantageFramework.BaseClasses.Methods.PropertyTypes.RateType)>
        Public Property NetGrossRate As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n1")>
        Public Property Units As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=2147483647)>
        Public Property Impressions As Integer? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=2147483647)>
        Public Property ImpressionsViewable As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=2147483647)>
        Public Property ImpressionsMeasurable As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0")>
        Public Property Clicks As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ClickRate As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=2147483647)>
        Public Property TotalConversions As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=2147483647)>
        Public Property TotalConversionsB As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=2147483647)>
        Public Property TotalConversionsC As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Rate As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property NetDollars As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property GrossDollars As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999999999)>
        Public Property Leads1 As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999999999)>
        Public Property Leads2 As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999999999)>
        Public Property Calls As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999999999)>
        Public Property LikesOrganic As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999999999)>
        Public Property LikesPaid As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999999999)>
        Public Property Visits As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999999999)>
        Public Property UniqueVisitors As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999999999)>
        Public Property ReachOrganic As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999999999)>
        Public Property ReachPaid As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999999999)>
        Public Property PageViews As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999999999)>
        Public Property PageEngagement As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ClientSales As Decimal? = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <MaxLength(200)>
        Public Property Note As String = Nothing
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property PlacementID() As Nullable(Of Int64)
        <MaxLength(25)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdServerSource() As String
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
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

                    Case AdvantageFramework.Database.Entities.DigitalResultsView.Properties.MediaPlanID.ToString

                        ErrorMessage = _DigitalResultError.MediaPlanErrorMessage

                    Case AdvantageFramework.Database.Entities.DigitalResultsView.Properties.ClientCode.ToString

                        ErrorMessage = _DigitalResultError.ClientErrorMessage

                    Case AdvantageFramework.Database.Entities.DigitalResultsView.Properties.DivisionCode.ToString

                        ErrorMessage = _DigitalResultError.DivisionErrorMessage

                    Case AdvantageFramework.Database.Entities.DigitalResultsView.Properties.ProductCode.ToString

                        ErrorMessage = _DigitalResultError.ProductErrorMessage

                    Case AdvantageFramework.Database.Entities.DigitalResultsView.Properties.EstimateID.ToString

                        ErrorMessage = _DigitalResultError.MediaPlanDetailErrorMessage

                    Case AdvantageFramework.Database.Entities.DigitalResultsView.Properties.SalesClassCode.ToString

                        ErrorMessage = _DigitalResultError.SalesClassErrorMessage

                    Case AdvantageFramework.Database.Entities.DigitalResultsView.Properties.CampaignID.ToString

                        ErrorMessage = _DigitalResultError.CampaignErrorMessage

                    Case AdvantageFramework.Database.Entities.DigitalResultsView.Properties.CampaignCode.ToString

                        ErrorMessage = _DigitalResultError.CampaignErrorMessage

                    Case AdvantageFramework.Database.Entities.DigitalResultsView.Properties.VendorCode.ToString

                        ErrorMessage = _DigitalResultError.VendorErrorMessage

                    Case AdvantageFramework.Database.Entities.DigitalResultsView.Properties.MarketCode.ToString

                        ErrorMessage = _DigitalResultError.MarketErrorMessage

                    Case AdvantageFramework.Database.Entities.DigitalResultsView.Properties.AdSizeCode.ToString

                        ErrorMessage = _DigitalResultError.AdSizeErrorMessage

                    Case AdvantageFramework.Database.Entities.DigitalResultsView.Properties.AdNumber.ToString

                        ErrorMessage = _DigitalResultError.AdNumberErrorMessage

                    Case AdvantageFramework.Database.Entities.DigitalResultsView.Properties.InternetTypeCode.ToString

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
        Public Function GetDigitalResultEntity(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.DigitalResult

            'objects
            Dim DigitalResult As AdvantageFramework.Database.Entities.DigitalResult = Nothing

            If DbContext IsNot Nothing Then

                DigitalResult = AdvantageFramework.Database.Procedures.DigitalResult.LoadByID(DbContext, Me.ID)

                If DigitalResult IsNot Nothing Then

                    With DigitalResult

                        .MediaPlanID = Me.MediaPlanID

                        If String.IsNullOrWhiteSpace(Me.ClientCode) Then

                            .ClientCode = Nothing
                            .ClientName = Me.ClientName

                        Else

                            .ClientCode = Me.ClientCode
                            .ClientName = Nothing

                        End If

                        .DivisionCode = Me.DivisionCode
                        .ProductCode = Me.ProductCode

                        If Me.JobNumber.GetValueOrDefault(0) = 0 Then

                            .JobNumber = Nothing
                            .JobDescription = Me.JobDescription

                        Else

                            .JobNumber = Me.JobNumber
                            .JobDescription = Nothing

                        End If

                        If Me.JobComponentNumber.GetValueOrDefault(0) = 0 Then

                            .JobComponentNumber = Nothing
                            .JobComponentDescription = Me.JobComponentDescription

                        Else

                            .JobComponentNumber = Me.JobComponentNumber
                            .JobComponentDescription = Nothing

                        End If

                        .MediaPlanDetailID = Me.EstimateID
                        .MediaPlanDetailLevelLineID = Me.MediaPlanDetailLevelLineID
                        .MediaType = Me.MediaType
                        .SalesClassCode = Me.SalesClassCode

                        If Me.CampaignID.GetValueOrDefault(0) = 0 Then

                            .CampaignID = Nothing
                            .CampaignCode = Me.CampaignCode
                            .CampaignName = Me.CampaignName

                        Else

                            .CampaignID = Me.CampaignID
                            .CampaignCode = Nothing
                            .CampaignName = Nothing

                        End If

                        If String.IsNullOrWhiteSpace(Me.VendorCode) Then

                            .VendorCode = Nothing
                            .VendorName = Me.VendorName

                        Else

                            .VendorCode = Me.VendorCode
                            .VendorName = Nothing

                        End If

                        If String.IsNullOrWhiteSpace(Me.MarketCode) Then

                            .MarketCode = Nothing
                            .MarketDescription = Me.MarketDescription

                        Else

                            .MarketCode = Me.MarketCode
                            .MarketDescription = Nothing

                        End If

                        If String.IsNullOrWhiteSpace(Me.AdSizeCode) Then

                            .AdSizeCode = Nothing
                            .AdSizeDescription = Me.AdSizeDescription

                        Else

                            .AdSizeCode = Me.AdSizeCode
                            .AdSizeDescription = Nothing

                        End If

                        If String.IsNullOrWhiteSpace(Me.AdSizeCode) Then

                            .AdSizeCode = Nothing
                            .AdSizeDescription = Me.AdSizeDescription

                        Else

                            .AdSizeCode = Me.AdSizeCode
                            .AdSizeDescription = Nothing

                        End If

                        If String.IsNullOrWhiteSpace(Me.AdNumber) Then

                            .AdNumber = Nothing
                            .AdNumberDescription = Me.AdNumberDescription

                        Else

                            .AdNumber = Me.AdNumber
                            .AdNumberDescription = Nothing

                        End If

                        If String.IsNullOrWhiteSpace(Me.InternetTypeCode) Then

                            .InternetTypeCode = Nothing
                            .InternetTypeDescription = Me.InternetTypeDescription

                        Else

                            .InternetTypeCode = Me.InternetTypeCode
                            .InternetTypeDescription = Nothing

                        End If

                        .Placement = Me.Placement
                        .PlacementPixelSize = Me.PlacementPixelSize
                        .PlacementURL = Me.PlacementURL
                        .Creative = Me.Creative
                        .Tactic = Me.Tactic
                        .PagePositioning = Me.PagePositioning
                        .ResultDate = Me.StartDate
                        .EndDate = Me.EndDate
                        .NetGrossRate = Me.NetGrossRate
                        .Units = Me.Units
                        .Impressions = Me.Impressions
                        .ImpressionsViewable = Me.ImpressionsViewable
                        .ImpressionsMeasurable = Me.ImpressionsMeasurable
                        .Clicks = Me.Clicks
                        .ClickRate = Me.ClickRate
                        .TotalConversions = Me.TotalConversions
                        .TotalConversionsB = Me.TotalConversionsB
                        .TotalConversionsC = Me.TotalConversionsC
                        .Rate = Me.Rate
                        .NetDollars = Me.NetDollars
                        .GrossDollars = Me.GrossDollars
                        .TargetAudience = Me.TargetAudience
                        .Leads1 = Me.Leads1
                        .Leads2 = Me.Leads2
                        .Calls = Me.Calls
                        .LikesOrganic = Me.LikesOrganic
                        .LikesPaid = Me.LikesPaid
                        .Visits = Me.Visits
                        .UniqueVisitors = Me.UniqueVisitors
                        .ReachOrganic = Me.ReachOrganic
                        .ReachPaid = Me.ReachPaid
                        .PageViews = Me.PageViews
                        .PageEngagement = Me.PageEngagement
                        .Note = Me.Note
                        .ClientSales = Me.ClientSales
                    End With

                End If

            End If

            Return DigitalResult

        End Function

#End Region

    End Class

End Namespace
