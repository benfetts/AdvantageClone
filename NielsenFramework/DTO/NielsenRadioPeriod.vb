Namespace DTO

    Public Class NielsenRadioPeriod
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenRadioReportTypeCode
            NielsenPeriodID
            NielsenRadioMarketNumber
            MarketName
            ShortName
            Name

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Report Type")>
        Public Property NielsenRadioReportTypeCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property NielsenPeriodID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Market Number")>
        Public Property NielsenRadioMarketNumber() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MarketName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ShortName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Name() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Validated() As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Source() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenRadioPeriod As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriod,
                       NielsenRadioMarketList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioMarket))

            'objects
            Dim NielsenRadioMarket As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioMarket = Nothing

            NielsenRadioMarket = NielsenRadioMarketList.Where(Function(Market) Market.Number = NielsenRadioPeriod.NielsenRadioMarketNumber AndAlso Market.Source = NielsenRadioPeriod.Source).FirstOrDefault

            If NielsenRadioMarket IsNot Nothing Then

                Me.MarketName = NielsenRadioMarket.Name

            End If

            Me.ID = NielsenRadioPeriod.ID
            Me.NielsenRadioReportTypeCode = NielsenRadioPeriod.NielsenRadioReportTypeCode
            Me.NielsenPeriodID = NielsenRadioPeriod.NielsenPeriodID
            Me.NielsenRadioMarketNumber = NielsenRadioPeriod.NielsenRadioMarketNumber
            Me.ShortName = NielsenRadioPeriod.ShortName
            Me.Name = NielsenRadioPeriod.Name
            Me.Validated = NielsenRadioPeriod.Validated

            If NielsenRadioPeriod.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan Then

                Me.Source = "Eastlan"

            ElseIf NielsenRadioPeriod.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen Then

                Me.Source = "Nielsen"

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
