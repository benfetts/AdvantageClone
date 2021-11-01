Namespace DTO.Media.SpotTV

    Public Class ComScoreCDMA
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenMarketNumber
            Description
            Year
            Month
            Stream
            FullStreamName
            StreamSort
            StartDateTime
            EndDateTime
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StationCode() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AIUE() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CarraigeUE() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property UEFactor() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property RatingsAIUE() As Integer

#End Region

#Region " Methods "

        Public Sub New()

            Me.StationCode = 0
            Me.AIUE = 0
            Me.CarraigeUE = 0
            Me.UEFactor = 0
            Me.RatingsAIUE = 0

        End Sub

#End Region

    End Class

End Namespace
