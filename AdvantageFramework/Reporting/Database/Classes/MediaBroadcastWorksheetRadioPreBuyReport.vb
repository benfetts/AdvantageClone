Namespace Reporting.Database.Classes

    <Serializable>
    Public Class MediaBroadcastWorksheetRadioPreBuyReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientName
            DivisionName
            ProductDescription
            MediaBroadcastWorksheetName
            MarketName
            VendorCode
            VendorName
            FlightDates
            WorksheetBooks
            UpdatedBooks
            LineNumber
            MakeGoodNumber
            LineMinDate
            LineMaxDate
            LineDate
            Days
            Time
            Daypart
            DaypartDescription
            Len
            OrdSpots
            Cost
            SpotEstimate
            SpotUpdatedEstimate
            TotalEstimate
            TotalUpdatedEstimate
            NielsenRadioStationComboID
            StationName
            NielsenMarketNumber
            DemographicDescription
            Index
            GeographyEthnicity
            MediaBroadcastWorksheetMarketDetailID
            MediaBroadcastWorksheetMarketID
            ReportedDates
            Bookend
            AddedValue
            RatingSource
            Quarter
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property ID() As Nullable(Of System.Guid)

        Public Property ClientName() As String

        Public Property DivisionName() As String

        Public Property ProductDescription() As String

        Public Property MediaBroadcastWorksheetName() As String

        Public Property MarketName() As String

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property VendorCode() As String
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property VendorName() As String

        Public Property FlightDates() As String

        Public Property WorksheetBooks() As String

        Public Property UpdatedBooks() As String

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property LineNumber As Integer

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property MakeGoodNumber As Integer

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(CustomColumnCaption:="Line Number")>
        Public ReadOnly Property FormattedLineNumber As String
            Get
                FormattedLineNumber = Me.LineNumber.ToString & IIf(Me.MakeGoodNumber <> 0, "-" & Me.MakeGoodNumber.ToString, "")
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property LineMinDate As Date
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property LineMaxDate As Date

        Public ReadOnly Property LineDate As String
            Get
                If Me.LineMinDate.Year = Me.LineMaxDate.Year Then
                    LineDate = Me.LineMinDate.Month & "/" & Me.LineMinDate.Day & "-" & Me.LineMaxDate.ToString("M/d/yy")
                Else
                    LineDate = Me.LineMinDate.ToString("M/d/yy") & "-" & Me.LineMaxDate.ToString("M/d/yy")
                End If
            End Get
        End Property

        Public Property Days As String

        Public Property Time As String

        Public Property Daypart As String

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property DaypartDescription As String

        Public Property Len As Short

        Public Property OrdSpots As Integer

        Public Property Cost As Decimal

        Public Property SpotEstimate As Decimal

        Public Property SpotUpdatedEstimate As Decimal

        Public ReadOnly Property TotalEstimate As Decimal
            Get
                TotalEstimate = FormatNumber(Me.OrdSpots * Me.SpotEstimate, 2)
            End Get
        End Property

        Public ReadOnly Property TotalUpdatedEstimate As Decimal
            Get
                TotalUpdatedEstimate = FormatNumber(Me.OrdSpots * Me.SpotUpdatedEstimate, 2)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property NielsenRadioStationComboID As Nullable(Of Integer)

        Public Property StationName As String

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property NielsenMarketNumber As Integer

        Public Property DemographicDescription As String

        Public ReadOnly Property Index As Integer
            Get
                If Me.TotalEstimate = 0 Then

                    Index = 0

                Else

                    Index = FormatNumber(Me.TotalUpdatedEstimate / Me.TotalEstimate * 100, 0)

                End If
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property GeographyEthnicity As String

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property MediaBroadcastWorksheetMarketDetailID As Integer

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property MediaBroadcastWorksheetMarketID As Integer

        Public Property ReportedDates() As String

        Public Property Bookend() As Boolean

        Public Property AddedValue() As Boolean

        Public Property RatingSource() As String

        Public Property Quarter() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
