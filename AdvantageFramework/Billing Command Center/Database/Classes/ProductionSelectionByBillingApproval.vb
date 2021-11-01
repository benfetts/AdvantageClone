Namespace BillingCommandCenter.Database.Classes

    <Serializable()>
    Public Class ProductionSelectionByBillingApproval

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            BillingApprovalID
            BillingApprovalClientName
            BillingApprovalBatchID
            JobNumber
            JobDescription
            JobComponentNumber
            ComponentDescription
            IsSelected
            BillingApprovalHeaderID
            BatchDescription
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsSelected() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BillingApprovalID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Description")>
        Public Property BillingApprovalClientName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobNumber() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Component")>
        Public Property JobComponentNumber() As Short

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ComponentDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Batch ID")>
        Public Property BillingApprovalBatchID() As Nullable(Of Integer)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BillingApprovalHeaderID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BatchDescription() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.BillingApprovalID.ToString

        End Function

#End Region

    End Class

End Namespace
