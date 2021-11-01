Namespace DTO.Media

    Public Class ComscoreLocalTimeView
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property MarketNumber As Integer

        Public Property MarketName As String

        Public Property NetworkName As String

        Public Property StationCallSign As String

        Public Property StationNumber As Integer

        Public Property StationName As String

        Public Property ProgramName As String

        Public Property Quarterhour As String

        Public Property Week As String

        Public Property AdjustedHour As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_01 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_01 As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_01 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Rating_01 As Decimal
            Get
                Rating_01 = If(Me.Universe_01 <> 0, Me.AvgAud_01 * 100 / Me.Universe_01, 0)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Share_01 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_02 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_02 As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_02 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Rating_02 As Decimal
            Get
                Rating_02 = If(Me.Universe_02 <> 0, Me.AvgAud_02 * 100 / Me.Universe_02, 0)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Share_02 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_03 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_03 As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_03 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Rating_03 As Decimal
            Get
                Rating_03 = If(Me.Universe_03 <> 0, Me.AvgAud_03 * 100 / Me.Universe_03, 0)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Share_03 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_04 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_04 As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_04 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Rating_04 As Decimal
            Get
                Rating_04 = If(Me.Universe_04 <> 0, Me.AvgAud_04 * 100 / Me.Universe_04, 0)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Share_04 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_05 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_05 As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_05 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Rating_05 As Decimal
            Get
                Rating_05 = If(Me.Universe_05 <> 0, Me.AvgAud_05 * 100 / Me.Universe_05, 0)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Share_05 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_06 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_06 As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_06 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Rating_06 As Decimal
            Get
                Rating_06 = If(Me.Universe_06 <> 0, Me.AvgAud_06 * 100 / Me.Universe_06, 0)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Share_06 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_07 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_07 As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_07 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Rating_07 As Decimal
            Get
                Rating_07 = If(Me.Universe_07 <> 0, Me.AvgAud_07 * 100 / Me.Universe_07, 0)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Share_07 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_08 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_08 As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_08 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Rating_08 As Decimal
            Get
                Rating_08 = If(Me.Universe_08 <> 0, Me.AvgAud_08 * 100 / Me.Universe_08, 0)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Share_08 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_09 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_09 As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_09 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Rating_09 As Decimal
            Get
                Rating_09 = If(Me.Universe_09 <> 0, Me.AvgAud_09 * 100 / Me.Universe_09, 0)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Share_09 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_10 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_10 As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_10 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Rating_10 As Decimal
            Get
                Rating_10 = If(Me.Universe_10 <> 0, Me.AvgAud_10 * 100 / Me.Universe_10, 0)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Share_10 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_11 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_11 As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_11 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Rating_11 As Decimal
            Get
                Rating_11 = If(Me.Universe_11 <> 0, Me.AvgAud_11 * 100 / Me.Universe_11, 0)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Share_11 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_12 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_12 As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_12 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Rating_12 As Decimal
            Get
                Rating_12 = If(Me.Universe_12 <> 0, Me.AvgAud_12 * 100 / Me.Universe_12, 0)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Share_12 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_13 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_13 As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_13 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Rating_13 As Decimal
            Get
                Rating_13 = If(Me.Universe_13 <> 0, Me.AvgAud_13 * 100 / Me.Universe_13, 0)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Share_13 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_14 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_14 As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_14 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Rating_14 As Decimal
            Get
                Rating_14 = If(Me.Universe_14 <> 0, Me.AvgAud_14 * 100 / Me.Universe_14, 0)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Share_14 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_15 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_15 As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_15 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Rating_15 As Decimal
            Get
                Rating_15 = If(Me.Universe_15 <> 0, Me.AvgAud_15 * 100 / Me.Universe_15, 0)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Share_15 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_16 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_16 As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_16 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Rating_16 As Decimal
            Get
                Rating_16 = If(Me.Universe_16 <> 0, Me.AvgAud_16 * 100 / Me.Universe_16, 0)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Share_16 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_17 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_17 As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_17 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Rating_17 As Decimal
            Get
                Rating_17 = If(Me.Universe_17 <> 0, Me.AvgAud_17 * 100 / Me.Universe_17, 0)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Share_17 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_18 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_18 As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_18 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Rating_18 As Decimal
            Get
                Rating_18 = If(Me.Universe_18 <> 0, Me.AvgAud_18 * 100 / Me.Universe_18, 0)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Share_18 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_19 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_19 As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_19 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Rating_19 As Decimal
            Get
                Rating_19 = If(Me.Universe_19 <> 0, Me.AvgAud_19 * 100 / Me.Universe_19, 0)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Share_19 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_20 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_20 As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_20 As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Rating_20 As Decimal
            Get
                Rating_20 = If(Me.Universe_20 <> 0, Me.AvgAud_20 * 100 / Me.Universe_20, 0)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Share_20 As Decimal

        Public Property MeetsDemoThreshold_01 As Boolean
        Public Property MeetsDemoThreshold_02 As Boolean
        Public Property MeetsDemoThreshold_03 As Boolean
        Public Property MeetsDemoThreshold_04 As Boolean
        Public Property MeetsDemoThreshold_05 As Boolean
        Public Property MeetsDemoThreshold_06 As Boolean
        Public Property MeetsDemoThreshold_07 As Boolean
        Public Property MeetsDemoThreshold_08 As Boolean
        Public Property MeetsDemoThreshold_09 As Boolean
        Public Property MeetsDemoThreshold_10 As Boolean
        Public Property MeetsDemoThreshold_11 As Boolean
        Public Property MeetsDemoThreshold_12 As Boolean
        Public Property MeetsDemoThreshold_13 As Boolean
        Public Property MeetsDemoThreshold_14 As Boolean
        Public Property MeetsDemoThreshold_15 As Boolean
        Public Property MeetsDemoThreshold_16 As Boolean
        Public Property MeetsDemoThreshold_17 As Boolean
        Public Property MeetsDemoThreshold_18 As Boolean
        Public Property MeetsDemoThreshold_19 As Boolean
        Public Property MeetsDemoThreshold_20 As Boolean

        Public Property MeetsHighQualityDemoThreshold_01 As Boolean
        Public Property MeetsHighQualityDemoThreshold_02 As Boolean
        Public Property MeetsHighQualityDemoThreshold_03 As Boolean
        Public Property MeetsHighQualityDemoThreshold_04 As Boolean
        Public Property MeetsHighQualityDemoThreshold_05 As Boolean
        Public Property MeetsHighQualityDemoThreshold_06 As Boolean
        Public Property MeetsHighQualityDemoThreshold_07 As Boolean
        Public Property MeetsHighQualityDemoThreshold_08 As Boolean
        Public Property MeetsHighQualityDemoThreshold_09 As Boolean
        Public Property MeetsHighQualityDemoThreshold_10 As Boolean
        Public Property MeetsHighQualityDemoThreshold_11 As Boolean
        Public Property MeetsHighQualityDemoThreshold_12 As Boolean
        Public Property MeetsHighQualityDemoThreshold_13 As Boolean
        Public Property MeetsHighQualityDemoThreshold_14 As Boolean
        Public Property MeetsHighQualityDemoThreshold_15 As Boolean
        Public Property MeetsHighQualityDemoThreshold_16 As Boolean
        Public Property MeetsHighQualityDemoThreshold_17 As Boolean
        Public Property MeetsHighQualityDemoThreshold_18 As Boolean
        Public Property MeetsHighQualityDemoThreshold_19 As Boolean
        Public Property MeetsHighQualityDemoThreshold_20 As Boolean

        Public Property RequestProcessingTime As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
