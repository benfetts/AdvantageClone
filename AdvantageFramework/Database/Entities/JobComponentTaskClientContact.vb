Namespace Database.Entities

	<Table("JOB_TRAFFIC_DET_CNTS")>
	Public Class JobComponentTaskClientContact
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			JobNumber
			JobComponentNumber
			SequenceNumber
			ClientContactID
			ClientContact
			JobComponentTask

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("JOB_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property JobNumber() As Integer
		<Required>
		<Column("JOB_COMPONENT_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property JobComponentNumber() As Short
		<Required>
		<Column("SEQ_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property SequenceNumber() As Short
		<Required>
		<Column("CDP_CONTACT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ClientContactID() As Integer

        <ForeignKey("ClientContactID")>
        Public Overridable Property ClientContact As Database.Entities.ClientContact
        Public Overridable Property JobComponentTask As Database.Entities.JobComponentTask

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
