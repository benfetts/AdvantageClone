Namespace Reporting.Database.Classes

    <Serializable>
    Public Class MediaTrafficMissingInstructionDataset

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            WorksheetID
            WorksheetName
            WorksheetMarketID
            VendorCode
            VendorName
            SpotDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property ID() As Nullable(Of System.Guid)
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property WorksheetID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property WorksheetName As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientName As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionName As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductName As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property WorksheetMarketID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MarketCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MarketDescription As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorName As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SpotDate As Date

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
