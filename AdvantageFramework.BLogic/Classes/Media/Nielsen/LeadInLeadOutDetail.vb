Namespace Classes.Media.Nielsen

    Public Class LeadInLeadOutDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Book
            Program
            Share
            Rating
            Impressions
            HPUT
            Week
            AdjustedDateTime
            AdjustedHour
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Book As String
        Public Property Program As String
        Public Property Share As Decimal
        Public Property Rating As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Imps (000)")>
        Public Property Impressions As Long
        Public Property HPUT As Decimal
        Public Property Week As Integer
        Public Property AdjustedDateTime As Date
        Public Property AdjustedHour As Integer
        Public Property MediaBroadcastWorksheetMarketDetailID As Integer

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
