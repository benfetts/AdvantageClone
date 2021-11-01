Namespace BillingCommandCenter.Database.Classes

    <Serializable()>
    Public Class ProductionSelectionByCampaign

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            CampaignID
            CampaignCode
            CampaignName
            IsSelected
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsSelected() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CampaignID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CampaignCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CampaignName() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCode.ToString

        End Function

#End Region

    End Class

End Namespace
