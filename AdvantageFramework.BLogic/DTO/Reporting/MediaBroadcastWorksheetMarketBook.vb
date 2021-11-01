Namespace DTO.Reporting

    Public Class MediaBroadcastWorksheetMarketBook
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaBroadcastWorksheetID
            MediaBroadcastWorksheetMarketID
            NielsenMarketNumber
            WorksheetName
            Division
            DivisionName
            Product
            ProductName
            MarketCode
            MarketDescription
            IsCable
            ShareBookID
            HPUTBookID
            NielsenRadioPeriodID1
            NielsenRadioPeriodID2
            NielsenRadioPeriodID3
            NielsenRadioPeriodID4
            NielsenRadioPeriodID5
            StartDate
            EndDate
            BroadcastStartYearMonth
            BroadcastEndYearMonth
            UsePrimaryDemo
            UseImpressions
            PrimaryMediaDemographicID
            SecondaryMediaDemographicID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaBroadcastWorksheetID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaBroadcastWorksheetMarketID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property NielsenMarketNumber() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property WorksheetName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Division() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property DivisionName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Product() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property ProductName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property MarketCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property MarketDescription() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property IsCable() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False, CustomColumnCaption:="Geography")>
        Public Property MediaBroadcastWorksheetMarketTVGeographyID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Override Post Book", PropertyType:=BaseClasses.Methods.PropertyTypes.NielsenTVBook)>
        Public Property ShareBookID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Pre Buy H/PUT Book", PropertyType:=BaseClasses.Methods.PropertyTypes.NielsenTVBook)>
        Public Property HPUTBookID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False, CustomColumnCaption:="Source")>
        Public Property ExternalRadioSource() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False, CustomColumnCaption:="Geography")>
        Public Property MediaBroadcastWorksheetMarketRadioGeographyID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False, CustomColumnCaption:="Ethnicity")>
        Public Property MediaBroadcastWorksheetMarketRadioEthnicityID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Book 1", PropertyType:=BaseClasses.Methods.PropertyTypes.NielsenRadioPeriod)>
        Public Property NielsenRadioPeriodID1() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Book 2", PropertyType:=BaseClasses.Methods.PropertyTypes.NielsenRadioPeriod)>
        Public Property NielsenRadioPeriodID2() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Book 3", PropertyType:=BaseClasses.Methods.PropertyTypes.NielsenRadioPeriod)>
        Public Property NielsenRadioPeriodID3() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Book 4", PropertyType:=BaseClasses.Methods.PropertyTypes.NielsenRadioPeriod)>
        Public Property NielsenRadioPeriodID4() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Book 5", PropertyType:=BaseClasses.Methods.PropertyTypes.NielsenRadioPeriod)>
        Public Property NielsenRadioPeriodID5() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Broadcast Start Month", PropertyType:=BaseClasses.Methods.PropertyTypes.YearMonth, ShowColumnInGrid:=False)>
        Public Property BroadcastStartYearMonth() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Broadcast End Month", PropertyType:=BaseClasses.Methods.PropertyTypes.YearMonth, ShowColumnInGrid:=False)>
        Public Property BroadcastEndYearMonth() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StartDate() As Date
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EndDate() As Date
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property UsePrimaryDemo() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property UseImpressions() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Primary Demo", PropertyType:=BaseClasses.Methods.PropertyTypes.MediaDemographic)>
        Public Property PrimaryMediaDemographicID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Secondary Demo", PropertyType:=BaseClasses.Methods.PropertyTypes.MediaDemographic)>
        Public Property SecondaryMediaDemographicID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property WorksheetStartDate() As Date
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property WorksheetEndDate() As Date
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaType() As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaMediaType
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BuyType() As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaBuyType
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsFromMediaManager() As Boolean

#End Region

#Region " Methods "

        Public Sub New(MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket,
                       BuyType As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaBuyType)

            Me.New(MediaBroadcastWorksheetMarket)

            Me.BuyType = BuyType

        End Sub
        Public Sub New(MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket)

            Me.MediaBroadcastWorksheetID = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.ID
            Me.WorksheetName = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.Name
            Me.Division = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.DivisionCode
            Me.DivisionName = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.Division.Name
            Me.Product = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.ProductCode
            Me.ProductName = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.Product.Name

            Me.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarket.ID

            If MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "R" Then

                If MediaBroadcastWorksheetMarket.ExternalRadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen Then

                    If MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketRadioEthnicityID = AdvantageFramework.Database.Entities.MediaBroadcastWorksheetRadioEthnicity.All Then

                        If Not String.IsNullOrWhiteSpace(MediaBroadcastWorksheetMarket.Market.NielsenRadioCode) Then

                            Me.NielsenMarketNumber = CInt(MediaBroadcastWorksheetMarket.Market.NielsenRadioCode.Trim)

                        End If

                    ElseIf MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketRadioEthnicityID = AdvantageFramework.Database.Entities.MediaBroadcastWorksheetRadioEthnicity.Black Then

                        If Not String.IsNullOrWhiteSpace(MediaBroadcastWorksheetMarket.Market.NielsenBlackRadioCode) Then

                            Me.NielsenMarketNumber = CInt(MediaBroadcastWorksheetMarket.Market.NielsenBlackRadioCode.Trim)

                        End If

                    ElseIf MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketRadioEthnicityID = AdvantageFramework.Database.Entities.MediaBroadcastWorksheetRadioEthnicity.Hispanic Then

                        If Not String.IsNullOrWhiteSpace(MediaBroadcastWorksheetMarket.Market.NielsenHispanicRadioCode) Then

                            Me.NielsenMarketNumber = CInt(MediaBroadcastWorksheetMarket.Market.NielsenHispanicRadioCode.Trim)

                        End If

                    End If

                ElseIf MediaBroadcastWorksheetMarket.ExternalRadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan Then

                    If MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketRadioEthnicityID = AdvantageFramework.Database.Entities.MediaBroadcastWorksheetRadioEthnicity.All Then

                        If MediaBroadcastWorksheetMarket.Market.EastlanRadioCode.HasValue Then

                            Me.NielsenMarketNumber = MediaBroadcastWorksheetMarket.Market.EastlanRadioCode.Value

                        End If

                    ElseIf MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketRadioEthnicityID = AdvantageFramework.Database.Entities.MediaBroadcastWorksheetRadioEthnicity.Black Then

                        If MediaBroadcastWorksheetMarket.Market.EastlanBlackRadioCode.HasValue Then

                            Me.NielsenMarketNumber = MediaBroadcastWorksheetMarket.Market.EastlanBlackRadioCode.Value

                        End If

                    ElseIf MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketRadioEthnicityID = AdvantageFramework.Database.Entities.MediaBroadcastWorksheetRadioEthnicity.Hispanic Then

                        If MediaBroadcastWorksheetMarket.Market.EastlanHispanicRadioCode.HasValue Then

                            Me.NielsenMarketNumber = MediaBroadcastWorksheetMarket.Market.EastlanHispanicRadioCode.Value

                        End If

                    End If

                End If

                Me.ExternalRadioSource = MediaBroadcastWorksheetMarket.ExternalRadioSource
                Me.MediaBroadcastWorksheetMarketRadioGeographyID = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketRadioGeographyID
                Me.MediaBroadcastWorksheetMarketRadioEthnicityID = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketRadioEthnicityID

            ElseIf MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen Then

                If (MediaBroadcastWorksheetMarket.Market.NielsenTVCode IsNot Nothing) Then

                    If (String.IsNullOrWhiteSpace(MediaBroadcastWorksheetMarket.Market.NielsenTVCode)) Then

                        Me.NielsenMarketNumber = 0

                    Else

                        Me.NielsenMarketNumber = CInt(MediaBroadcastWorksheetMarket.Market.NielsenTVCode.Trim)

                    End If

                End If

            ElseIf MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore Then

                Me.NielsenMarketNumber = MediaBroadcastWorksheetMarket.Market.ComscoreMarketNumber.Value

            End If

            Me.MarketCode = MediaBroadcastWorksheetMarket.Market.Code
            Me.MarketDescription = MediaBroadcastWorksheetMarket.Market.Description
            Me.IsCable = MediaBroadcastWorksheetMarket.IsCable
            Me.MediaBroadcastWorksheetMarketTVGeographyID = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketTVGeographyID
            Me.ShareBookID = Nothing
            Me.HPUTBookID = Nothing
            Me.StartDate = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.StartDate
            Me.EndDate = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.EndDate
            Me.WorksheetStartDate = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.StartDate
            Me.WorksheetEndDate = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.EndDate
            Me.UsePrimaryDemo = True
            Me.UseImpressions = False
            Me.PrimaryMediaDemographicID = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographicID

            If MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "T" Then

                Me.MediaType = Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.TV

            ElseIf MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "R" Then

                Me.MediaType = Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.Radio

            End If

            If BuyType <> -1 Then

                Me.BuyType = BuyType

            End If

        End Sub
        Public Sub SaveToEntity(ByRef MediaBroadcastWorksheetPrePostReportCriteria As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteria)

            MediaBroadcastWorksheetPrePostReportCriteria.MediaBroadcastWorksheetMarketID = Me.MediaBroadcastWorksheetMarketID
            MediaBroadcastWorksheetPrePostReportCriteria.SharebookNielsenTVBookID = Me.ShareBookID
            MediaBroadcastWorksheetPrePostReportCriteria.HUTPUTNielsenTVBookID = Me.HPUTBookID
            MediaBroadcastWorksheetPrePostReportCriteria.UsePrimaryDemo = Me.UsePrimaryDemo
            MediaBroadcastWorksheetPrePostReportCriteria.UseImpressions = Me.UseImpressions
            MediaBroadcastWorksheetPrePostReportCriteria.PrimaryMediaDemographicID = Me.PrimaryMediaDemographicID
            MediaBroadcastWorksheetPrePostReportCriteria.SecondaryMediaDemographicID = Me.SecondaryMediaDemographicID
            MediaBroadcastWorksheetPrePostReportCriteria.BroadcastStartYearMonth = Me.BroadcastStartYearMonth
            MediaBroadcastWorksheetPrePostReportCriteria.BroadcastEndYearMonth = Me.BroadcastEndYearMonth
            MediaBroadcastWorksheetPrePostReportCriteria.StartDate = Me.StartDate
            MediaBroadcastWorksheetPrePostReportCriteria.EndDate = Me.EndDate
            MediaBroadcastWorksheetPrePostReportCriteria.NeilsenRadioPeriodID1 = Me.NielsenRadioPeriodID1
            MediaBroadcastWorksheetPrePostReportCriteria.NeilsenRadioPeriodID2 = Me.NielsenRadioPeriodID2
            MediaBroadcastWorksheetPrePostReportCriteria.NeilsenRadioPeriodID3 = Me.NielsenRadioPeriodID3
            MediaBroadcastWorksheetPrePostReportCriteria.NeilsenRadioPeriodID4 = Me.NielsenRadioPeriodID4
            MediaBroadcastWorksheetPrePostReportCriteria.NeilsenRadioPeriodID5 = Me.NielsenRadioPeriodID5

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.MarketCode & " - " & Me.MarketDescription

        End Function
        Public Function GetRadioBookIDs() As Generic.List(Of String)

            Dim BookIDs As Generic.List(Of String) = Nothing

            BookIDs = New Generic.List(Of String)

            If Me.NielsenRadioPeriodID1.HasValue Then

                BookIDs.Add(Me.NielsenRadioPeriodID1.Value)

            End If

            If Me.NielsenRadioPeriodID2.HasValue Then

                BookIDs.Add(Me.NielsenRadioPeriodID2.Value)

            End If

            If Me.NielsenRadioPeriodID3.HasValue Then

                BookIDs.Add(Me.NielsenRadioPeriodID3.Value)

            End If

            If Me.NielsenRadioPeriodID4.HasValue Then

                BookIDs.Add(Me.NielsenRadioPeriodID4.Value)

            End If

            If Me.NielsenRadioPeriodID5.HasValue Then

                BookIDs.Add(Me.NielsenRadioPeriodID5.Value)

            End If

            GetRadioBookIDs = BookIDs

        End Function

#End Region

    End Class

End Namespace
