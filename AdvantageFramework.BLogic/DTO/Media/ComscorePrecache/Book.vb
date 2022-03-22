Namespace DTO.Media.ComscorePrecache

    Public Class Book

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            IsSelected
            Year
            Month
            MonthName
            Stream
            ComscoreTVBookID
            MarketBookID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property IsSelected() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Year As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Month() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Month")>
        Public ReadOnly Property MonthName() As String
            Get
                MonthName = DateAndTime.MonthName(Me.Month, True)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property Stream() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ComscoreTVBookID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MarketBookID() As Nullable(Of Integer)

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
