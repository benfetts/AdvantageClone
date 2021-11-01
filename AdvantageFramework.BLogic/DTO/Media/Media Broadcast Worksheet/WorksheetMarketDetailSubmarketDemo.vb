Namespace DTO.Media.MediaBroadcastWorksheet

    Public Class WorksheetMarketDetailSubmarketDemo
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaBroadcastWorksheetMarketSubmarketID
            MediaBroadcastWorksheetMarketDetailID
            MediaDemographicID
            MarketCode
            RowID
            VendorCode
            LineNumber
            MakegoodNumber
            TotalSpots
            TotalDollars
            BookRating
            Rating
            BookImpressions
            Impressions
            Universe
        End Enum

#End Region

#Region " Variables "

        Private _GIMPTotal As Decimal = 0
        Private _AllocationTotal As Decimal = 0

#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaBroadcastWorksheetMarketSubmarketID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaBroadcastWorksheetMarketDetailID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaDemographicID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MarketCode() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property RowID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property VendorCode() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property LineNumber() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MakegoodNumber() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property TotalSpots() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property TotalDollars() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property BookRating() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property Rating() As Decimal
        '<Required>
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        'Private Property BookImpressions() As Long
        '<Required>
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        'Private Property Impressions() As Long
        Public ReadOnly Property GRP() As Decimal
            Get
                GRP = Math.Round(Me.Rating * Me.TotalSpots, 2)
            End Get
        End Property
        Public ReadOnly Property Impressions() As Decimal
            Get
                Impressions = Math.Round((Me.Rating * (Me.Universe / 100)), 2)
            End Get
        End Property
        Public ReadOnly Property GIMP() As Decimal
            Get
                GIMP = Math.Round((Me.TotalSpots * Me.Rating * (Me.Universe / 100)), 2)
            End Get
        End Property
        Public ReadOnly Property Allocation() As Decimal
            Get

                If _GIMPTotal <> 0 Then

                    Allocation = Math.Round((Me.TotalDollars * Me.GIMP) / _GIMPTotal, 2)

                Else

                    Allocation = 0

                End If

            End Get
        End Property
        Public ReadOnly Property Percentage() As Decimal
            Get

                If _AllocationTotal <> 0 Then

                    Percentage = Math.Round(Me.Allocation / _AllocationTotal, 2)

                Else

                    Percentage = 0

                End If

            End Get
        End Property
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Universe As Integer
        Public WriteOnly Property GIMPTotal As Decimal
            Set(value As Decimal)
                _GIMPTotal = value
            End Set
        End Property
        Public WriteOnly Property AllocationTotal As Decimal
            Set(value As Decimal)
                _AllocationTotal = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.MediaBroadcastWorksheetMarketSubmarketID = 0
            Me.MediaBroadcastWorksheetMarketDetailID = 0
            Me.MediaDemographicID = 0
            Me.MarketCode = String.Empty
            Me.RowID = 0
            Me.VendorCode = String.Empty
            Me.LineNumber = 0
            Me.MakegoodNumber = 0
            Me.TotalSpots = 0
            Me.TotalDollars = 0
            Me.BookRating = 0
            Me.Rating = 0
            'Me.BookImpressions = 0
            'Me.Impressions = 0
            Me.Universe = 0

        End Sub
        Public Sub New(MediaBroadcastWorksheetMarketDetailSubmarketDemo As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailSubmarketDemo,
                       RowID As Integer, TotalSpots As Integer, TotalDollars As Decimal, Universe As Integer)

            Me.ID = MediaBroadcastWorksheetMarketDetailSubmarketDemo.ID
            Me.MediaBroadcastWorksheetMarketSubmarketID = MediaBroadcastWorksheetMarketDetailSubmarketDemo.MediaBroadcastWorksheetMarketSubmarketID
            Me.MediaBroadcastWorksheetMarketDetailID = MediaBroadcastWorksheetMarketDetailSubmarketDemo.MediaBroadcastWorksheetMarketDetailID
            Me.MediaDemographicID = MediaBroadcastWorksheetMarketDetailSubmarketDemo.MediaDemographicID
            Me.MarketCode = MediaBroadcastWorksheetMarketDetailSubmarketDemo.MediaBroadcastWorksheetMarketSubmarket.MarketCode
            Me.RowID = RowID
            Me.VendorCode = MediaBroadcastWorksheetMarketDetailSubmarketDemo.MediaBroadcastWorksheetMarketDetail.VendorCode
            Me.LineNumber = MediaBroadcastWorksheetMarketDetailSubmarketDemo.MediaBroadcastWorksheetMarketDetail.LineNumber
            Me.MakegoodNumber = MediaBroadcastWorksheetMarketDetailSubmarketDemo.MediaBroadcastWorksheetMarketDetail.MakegoodNumber
            Me.TotalSpots = TotalSpots
            Me.TotalDollars = TotalDollars
            Me.BookRating = MediaBroadcastWorksheetMarketDetailSubmarketDemo.BookRating
            Me.Rating = MediaBroadcastWorksheetMarketDetailSubmarketDemo.Rating
            'Me.BookImpressions = MediaBroadcastWorksheetMarketDetailSubmarketDemo.BookImpressions
            'Me.Impressions = MediaBroadcastWorksheetMarketDetailSubmarketDemo.Impressions
            Me.Universe = Universe

        End Sub
        Public Sub SaveToEntity(ByRef MediaBroadcastWorksheetMarketDetailSubmarketDemo As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailSubmarketDemo)

            MediaBroadcastWorksheetMarketDetailSubmarketDemo.ID = Me.ID
            MediaBroadcastWorksheetMarketDetailSubmarketDemo.MediaBroadcastWorksheetMarketSubmarketID = Me.MediaBroadcastWorksheetMarketSubmarketID
            MediaBroadcastWorksheetMarketDetailSubmarketDemo.MediaBroadcastWorksheetMarketDetailID = Me.MediaBroadcastWorksheetMarketDetailID
            MediaBroadcastWorksheetMarketDetailSubmarketDemo.MediaDemographicID = Me.MediaDemographicID
            MediaBroadcastWorksheetMarketDetailSubmarketDemo.BookRating = Me.BookRating
            MediaBroadcastWorksheetMarketDetailSubmarketDemo.Rating = Me.Rating
            'MediaBroadcastWorksheetMarketDetailSubmarketDemo.BookImpressions = Me.BookImpressions
            'MediaBroadcastWorksheetMarketDetailSubmarketDemo.Impressions = Me.Impressions
            MediaBroadcastWorksheetMarketDetailSubmarketDemo.BookImpressions = 0
            MediaBroadcastWorksheetMarketDetailSubmarketDemo.Impressions = 0

        End Sub
        Public Function CopyWithNewRowID(RowID As Integer) As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailSubmarketDemo

            Dim WorksheetMarketDetailSubmarketDemo As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailSubmarketDemo = Nothing

            WorksheetMarketDetailSubmarketDemo = New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailSubmarketDemo

            WorksheetMarketDetailSubmarketDemo.ID = 0
            WorksheetMarketDetailSubmarketDemo.MediaBroadcastWorksheetMarketSubmarketID = Me.MediaBroadcastWorksheetMarketSubmarketID
            WorksheetMarketDetailSubmarketDemo.MediaBroadcastWorksheetMarketDetailID = 0
            WorksheetMarketDetailSubmarketDemo.MediaDemographicID = Me.MediaDemographicID
            WorksheetMarketDetailSubmarketDemo.MarketCode = Me.MarketCode
            WorksheetMarketDetailSubmarketDemo.RowID = RowID
            WorksheetMarketDetailSubmarketDemo.VendorCode = Me.VendorCode
            WorksheetMarketDetailSubmarketDemo.LineNumber = Me.LineNumber
            WorksheetMarketDetailSubmarketDemo.MakegoodNumber = Me.MakegoodNumber
            WorksheetMarketDetailSubmarketDemo.TotalSpots = Me.TotalSpots
            WorksheetMarketDetailSubmarketDemo.TotalDollars = Me.TotalDollars
            WorksheetMarketDetailSubmarketDemo.BookRating = Me.BookRating
            WorksheetMarketDetailSubmarketDemo.Rating = Me.Rating
            'WorksheetMarketDetailSubmarketDemo.BookImpressions = Me.ID
            'WorksheetMarketDetailSubmarketDemo.Impressions = Me.ID
            WorksheetMarketDetailSubmarketDemo.Universe = Me.Universe
            WorksheetMarketDetailSubmarketDemo.GIMPTotal = _GIMPTotal
            WorksheetMarketDetailSubmarketDemo.AllocationTotal = _AllocationTotal

            CopyWithNewRowID = WorksheetMarketDetailSubmarketDemo

        End Function
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.MediaBroadcastWorksheetMarketSubmarketID.ToString & " - " & Me.MediaBroadcastWorksheetMarketDetailID.ToString & " - " & Me.MediaDemographicID.ToString

        End Function

#End Region

    End Class

End Namespace
