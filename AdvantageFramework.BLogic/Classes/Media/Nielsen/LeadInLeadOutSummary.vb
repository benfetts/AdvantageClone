Namespace Classes.Media.Nielsen

    Public Class LeadInLeadOutSummary

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            TimeSlot
            Program
            Rating
            Share
            HPUT
            Impressions
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property TimeSlot As String
        Public Property Program As String
        Public Property Rating As Decimal
        Public Property Share As Decimal
        Public Property HPUT As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Imps (000)")>
        Public Property Impressions As Long

#End Region

#Region " Methods "

        Public Sub New()

            Me.TimeSlot = String.Empty
            Me.Program = String.Empty
            Me.Rating = 0
            Me.Share = 0
            Me.HPUT = 0
            Me.Impressions = 0

        End Sub

#End Region

    End Class

End Namespace