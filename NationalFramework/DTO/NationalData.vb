Namespace DTO

    Public Class NationalData
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            DataType
            Stream
            TimeType
            IsPreliminary
            StartDate
            EndDate
            Year
            IsHispanic
            MarketBreakID
            IsCorrection
            IsPBSNSS
            FileName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ID() As Integer

        Public Property DataType() As String

        Public Property Stream() As String

        Public Property IsPreliminary() As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="g")>
        Public Property StartDate() As Date

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="g")>
        Public Property EndDate() As Date

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property Year() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property IsHispanic() As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property MarketBreakID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property IsCorrection() As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property IsPBSNSS() As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property FileName() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NationalData As AdvantageFramework.National.Database.Entities.NationalData)

            Me.ID = NationalData.ID
            Me.DataType = NationalData.DataType
            Me.Stream = NationalData.Stream
            Me.IsPreliminary = NationalData.IsPreliminary
            Me.StartDate = NationalData.StartDate
            Me.EndDate = NationalData.EndDate
            Me.Year = NationalData.Year
            Me.IsHispanic = NationalData.IsHispanic
            Me.MarketBreakID = NationalData.MarketBreakID
            Me.IsCorrection = NationalData.IsCorrection
            Me.IsPBSNSS = NationalData.IsPBSNSS
            Me.FileName = NationalData.FileName

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
