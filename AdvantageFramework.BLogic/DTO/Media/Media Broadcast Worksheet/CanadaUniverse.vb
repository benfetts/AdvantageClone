Namespace DTO.Media.MediaBroadcastWorksheet

    Public Class CanadaUniverse
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Year
            MarketCode
            Market
            Males2Plus
            Males12Plus
            Males18Plus
            Males25Plus
            Males35Plus
            Males50Plus
            Males55Plus
            Males60Plus
            Males65Plus
            Females2Plus
            Females12Plus
            Females18Plus
            Females25Plus
            Females35Plus
            Females50Plus
            Females55Plus
            Females60Plus
            Females65Plus
            CanadaUniverseDetails
        End Enum

#End Region

#Region " Variables "

        Private _CanadaUniverseDetails As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverseDetail) = Nothing

#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, MaxValue:=9999, MinValue:=1900, UseMaxValue:=True, UseMinValue:=True)>
        Public Property Year() As Integer
        <Required>
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property MarketCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Market() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property Males2Plus() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property Males12Plus() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property Males18Plus() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property Males25Plus() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property Males35Plus() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property Males50Plus() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property Males55Plus() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property Males60Plus() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property Males65Plus() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property Females2Plus() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property Females12Plus() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property Females18Plus() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property Females25Plus() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property Females35Plus() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property Females50Plus() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property Females55Plus() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property Females60Plus() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property Females65Plus() As Integer
        Public ReadOnly Property CanadaUniverseDetails As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverseDetail)
            Get
                CanadaUniverseDetails = _CanadaUniverseDetails
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.Year = Now.Year
            Me.MarketCode = Nothing
            Me.Market = String.Empty
            Me.Males2Plus = 0
            Me.Males12Plus = 0
            Me.Males18Plus = 0
            Me.Males25Plus = 0
            Me.Males35Plus = 0
            Me.Males50Plus = 0
            Me.Males55Plus = 0
            Me.Males60Plus = 0
            Me.Males65Plus = 0
            Me.Females2Plus = 0
            Me.Females12Plus = 0
            Me.Females18Plus = 0
            Me.Females25Plus = 0
            Me.Females35Plus = 0
            Me.Females50Plus = 0
            Me.Females55Plus = 0
            Me.Females60Plus = 0
            Me.Females65Plus = 0

            _CanadaUniverseDetails = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverseDetail)

        End Sub
        Public Sub New(CanadaUniverse As AdvantageFramework.Database.Entities.CanadaUniverse)

            Me.ID = CanadaUniverse.ID
            Me.Year = CanadaUniverse.Year
            Me.MarketCode = CanadaUniverse.MarketCode
            Me.Market = If(CanadaUniverse.Market IsNot Nothing, CanadaUniverse.Market.Description, String.Empty)
            Me.Males2Plus = CanadaUniverse.Males2Plus
            Me.Males12Plus = CanadaUniverse.Males12Plus
            Me.Males18Plus = CanadaUniverse.Males18Plus
            Me.Males25Plus = CanadaUniverse.Males25Plus
            Me.Males35Plus = CanadaUniverse.Males35Plus
            Me.Males50Plus = CanadaUniverse.Males50Plus
            Me.Males55Plus = CanadaUniverse.Males55Plus
            Me.Males60Plus = CanadaUniverse.Males60Plus
            Me.Males65Plus = CanadaUniverse.Males65Plus
            Me.Females2Plus = CanadaUniverse.Females2Plus
            Me.Females12Plus = CanadaUniverse.Females12Plus
            Me.Females18Plus = CanadaUniverse.Females18Plus
            Me.Females25Plus = CanadaUniverse.Females25Plus
            Me.Females35Plus = CanadaUniverse.Females35Plus
            Me.Females50Plus = CanadaUniverse.Females50Plus
            Me.Females55Plus = CanadaUniverse.Females55Plus
            Me.Females60Plus = CanadaUniverse.Females60Plus
            Me.Females65Plus = CanadaUniverse.Females65Plus

            _CanadaUniverseDetails = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverseDetail)

            _CanadaUniverseDetails.Add(New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverseDetail(CanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males2Plus, CanadaUniverse.Males2Plus))
            _CanadaUniverseDetails.Add(New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverseDetail(CanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males12Plus, CanadaUniverse.Males12Plus))
            _CanadaUniverseDetails.Add(New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverseDetail(CanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males18Plus, CanadaUniverse.Males18Plus))
            _CanadaUniverseDetails.Add(New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverseDetail(CanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males25Plus, CanadaUniverse.Males25Plus))
            _CanadaUniverseDetails.Add(New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverseDetail(CanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males35Plus, CanadaUniverse.Males35Plus))
            _CanadaUniverseDetails.Add(New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverseDetail(CanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males50Plus, CanadaUniverse.Males50Plus))
            _CanadaUniverseDetails.Add(New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverseDetail(CanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males55Plus, CanadaUniverse.Males55Plus))
            _CanadaUniverseDetails.Add(New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverseDetail(CanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males60Plus, CanadaUniverse.Males60Plus))
            _CanadaUniverseDetails.Add(New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverseDetail(CanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males65Plus, CanadaUniverse.Males65Plus))
            _CanadaUniverseDetails.Add(New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverseDetail(CanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females2Plus, CanadaUniverse.Females2Plus))
            _CanadaUniverseDetails.Add(New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverseDetail(CanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females12Plus, CanadaUniverse.Females12Plus))
            _CanadaUniverseDetails.Add(New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverseDetail(CanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females18Plus, CanadaUniverse.Females18Plus))
            _CanadaUniverseDetails.Add(New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverseDetail(CanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females25Plus, CanadaUniverse.Females25Plus))
            _CanadaUniverseDetails.Add(New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverseDetail(CanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females35Plus, CanadaUniverse.Females35Plus))
            _CanadaUniverseDetails.Add(New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverseDetail(CanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females50Plus, CanadaUniverse.Females50Plus))
            _CanadaUniverseDetails.Add(New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverseDetail(CanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females55Plus, CanadaUniverse.Females55Plus))
            _CanadaUniverseDetails.Add(New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverseDetail(CanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females60Plus, CanadaUniverse.Females60Plus))
            _CanadaUniverseDetails.Add(New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverseDetail(CanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females65Plus, CanadaUniverse.Females65Plus))

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.Year.ToString & " - " & Me.MarketCode

        End Function

#End Region

    End Class

End Namespace
