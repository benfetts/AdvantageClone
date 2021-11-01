Namespace BillingCommandCenter.Database.Classes

    <Serializable()>
    Public Class ProductionSelectionByJobComponent

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobNumber
            JobDescription
            JobComponentNumber
            ComponentDescription
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            CampaignCode
            CampaignName
            IsSelected
            ID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsSelected() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobNumber() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Component")>
        Public Property JobComponentNumber() As Short

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ComponentDescription() As String

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

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CampaignCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CampaignName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.JobNumber.ToString

        End Function

#End Region

    End Class

End Namespace
