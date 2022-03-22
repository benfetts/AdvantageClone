Option Strict On

Namespace DTO.Media.ComscorePrecache

    Public Class Cache

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            IsCached
            Market
            Year
            Month
            Stream
            CallLetters
            StationName
            Demographic
            ComscoreCacheHeaderID
            Warning
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsCached() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Market() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property Year() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property Month() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Stream() As String
        Public Property CallLetters() As String
        Public Property StationName() As String
        Public Property Demographic() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ComscoreCacheHeaderID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Warning() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Warning")>
        Public ReadOnly Property WarningText() As String
            Get
                If String.IsNullOrWhiteSpace(Me.Warning) = False Then
                    WarningText = "No data found for market:" & Me.Market & ".  Please call customer support and verify your Comscore subscription includes this market and the books selected."
                Else
                    WarningText = ""
                End If
            End Get
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
