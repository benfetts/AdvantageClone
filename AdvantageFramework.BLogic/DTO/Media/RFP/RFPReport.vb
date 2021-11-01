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
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property DateRequested As Date
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

            Me.DateAvailsDue = ""
            Me.MarketDescription = ""
            Me.RatingsSource = ""
            Me.TargetAudience = ""
            Me.Daypart = ""
            Me.FlightDates = ""
            Me.CPPGoal = ""
            Me.GRPGoal = ""
            Me.AddedValue = ""
            Me.AdditionalGuidelines = ""
            Me.SecondaryTargetAudiences = ""

        End Sub

#End Region

    End Class

End Namespace
