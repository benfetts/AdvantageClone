Namespace DTO.Media.RFP

    Public Class RFPReport
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            DateRequested
            DateAvailsDue
            MarketDescription
            RatingsSource
            TargetAudience
            Daypart
            FlightDates
            CPPGoal
            GRPGoal
            AddedValue
            AdditionalGuidelines
            SecondaryTargetAudiences
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property DateRequested As Nullable(Of Date)
        Public Property DateAvailsDue As String
        Public Property MarketDescription As String
        Public Property RatingsSource As String
        Public Property TargetAudience As String
        Public Property Daypart As String
        Public Property FlightDates As String
        Public Property CPPGoal As String
        Public Property GRPGoal As String
        Public Property AddedValue As String
        Public Property AdditionalGuidelines As String
        Public Property SecondaryTargetAudiences As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.DateRequested = Nothing
            Me.DateAvailsDue = Nothing
            Me.MarketDescription = Nothing
            Me.RatingsSource = Nothing
            Me.TargetAudience = Nothing
            Me.Daypart = Nothing
            Me.FlightDates = Nothing
            Me.CPPGoal = Nothing
            Me.GRPGoal = Nothing
            Me.AddedValue = Nothing
            Me.AdditionalGuidelines = Nothing
            Me.SecondaryTargetAudiences = Nothing

        End Sub

#End Region

    End Class

End Namespace
