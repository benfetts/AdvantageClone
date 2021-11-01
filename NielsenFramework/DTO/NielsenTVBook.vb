Namespace DTO

    Public Class NielsenTVBook
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenMarketNumber
            MarketName
            Year
            Month
            Stream
            CreateDate
            Validated
            CollectionMethod
            ReportingService
            Exclusion
            Ethnicity
            DownloadFileID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Market Number")>
        Public Property NielsenMarketNumber() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MarketName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Year() As Short

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Month() As Short

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Stream() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="g")>
        Public Property CreateDate() As Date

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Validated() As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CollectionMethod() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ReportingService() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Exclusion() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Ethnicity() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DownloadFileID As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenTVBook As AdvantageFramework.Nielsen.Database.Entities.NielsenTVBook,
                       NielsenMarketList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenMarket))

            'objects
            Dim NielsenMarket As AdvantageFramework.Nielsen.Database.Entities.NielsenMarket = Nothing

            NielsenMarket = NielsenMarketList.Where(Function(Market) Market.NielsenTVCode = NielsenTVBook.NielsenMarketNumber).FirstOrDefault

            If NielsenMarket IsNot Nothing Then

                Me.MarketName = NielsenMarket.Description

            End If

            Me.ID = NielsenTVBook.ID
            Me.NielsenMarketNumber = NielsenTVBook.NielsenMarketNumber
            Me.Year = NielsenTVBook.Year
            Me.Month = NielsenTVBook.Month
            Me.Stream = NielsenTVBook.Stream
            Me.CreateDate = NielsenTVBook.CreateDate
            Me.Validated = NielsenTVBook.Validated
            Me.CollectionMethod = NielsenTVBook.CollectionMethod
            Me.ReportingService = NielsenTVBook.ReportingService
            Me.Exclusion = NielsenTVBook.Exclusion
            Me.Ethnicity = NielsenTVBook.Ethnicity
            Me.DownloadFileID = NielsenTVBook.DownloadFileID

        End Sub
        Public Sub New(NielsenTVCumeBook As AdvantageFramework.Nielsen.Database.Entities.NielsenTVCumeBook,
                       NielsenMarketList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenMarket))

            'objects
            Dim NielsenMarket As AdvantageFramework.Nielsen.Database.Entities.NielsenMarket = Nothing

            NielsenMarket = NielsenMarketList.Where(Function(Market) Market.NielsenTVCode = NielsenTVCumeBook.NielsenMarketNumber).FirstOrDefault

            If NielsenMarket IsNot Nothing Then

                Me.MarketName = NielsenMarket.Description

            End If

            Me.ID = NielsenTVCumeBook.ID
            Me.NielsenMarketNumber = NielsenTVCumeBook.NielsenMarketNumber
            Me.Year = NielsenTVCumeBook.Year
            Me.Month = NielsenTVCumeBook.Month
            Me.Stream = NielsenTVCumeBook.Stream
            Me.CreateDate = NielsenTVCumeBook.CreateDate
            Me.Validated = NielsenTVCumeBook.Validated

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
