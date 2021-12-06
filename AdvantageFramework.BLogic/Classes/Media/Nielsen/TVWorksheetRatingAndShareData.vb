Namespace Classes.Media.Nielsen

    Public Class TVWorksheetRatingAndShareData

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaDemoID
            Share
            Rating
            Impressions
            HPUT
            Universe
            ProgramName
            StationCode
            MediaBroadcastWorksheetMarketDetailID
            BookID
            CumeImpressions
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property MediaDemoID As Nullable(Of Integer)
        Public Property Share As Decimal
        Public Property Rating As Decimal
        Public Property Impressions As Long
        Public Property HPUT As Decimal
        Public Property Universe As Long
        Public Property ProgramName As String
        Public Property StationCode As Integer
        Public Property MediaBroadcastWorksheetMarketDetailID As Integer
        Public Property BookID As Integer
        Public Property CumeImpressions As Nullable(Of Long)
        Public Property ComscoreMeetsDemoThreshold As Boolean
        Public Property ComscoreMeetsHighQualityDemoThreshold As Boolean
        Public Property ComscoreDemoNumber As Integer
        Public Property BookName As String
        'Comscore spot specific
        Public Property ElapsedTime As String
        Public Property Request As String
        Public Property Response As String

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
