Namespace Database.Entities

    <Table("ALERT_NOTIFY_HDR")>
    Public Class AlertAssignmentTemplate
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Type

            None = 0
            MultiAssigneeRouted = 1
            ConceptShareReview = 2

        End Enum
        Public Enum Properties

            ID
            Name
            IsActive
            IsDigitalAsset
            AutoNextState
            Type

            AlertAssignmentTemplateEmployees
            AlertAssignmentTemplateStates
            JobComponents
            WorkflowAlertState
            WorkflowEndAlertState

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("ALRT_NOTIFY_HDR_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <MaxLength(100)>
        <Column("ALERT_NOTIFY_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Name() As String
        <Column("ACTIVE_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsActive() As Nullable(Of Boolean)
        <Column("IS_DIGITAL_ASSET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsDigitalAsset() As Nullable(Of Boolean)
        <Column("AUTO_NXT_STATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AutoNextState() As Nullable(Of Boolean)
        <Column("TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TemplateType() As Nullable(Of Short)

        Public Overridable Property AlertAssignmentTemplateEmployees As ICollection(Of Database.Entities.AlertAssignmentTemplateEmployee)
        Public Overridable Property AlertAssignmentTemplateStates As ICollection(Of Database.Entities.AlertAssignmentTemplateState)
        Public Overridable Property JobComponents As ICollection(Of Database.Entities.JobComponent)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
