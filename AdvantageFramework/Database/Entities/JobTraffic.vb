Namespace Database.Entities

	<Table("JOB_TRAFFIC")>
	Public Class JobTraffic
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobNumber
            JobComponentNumber
            TrafficCode
            TrafficPresetCode
            TrafficComments
            Assign1
            Assign2
            Assign3
            Assign4
            Assign5
            CompletedDate
            DateDelivered
            DateShipped
            ReceivedBy
            Reference
            RowID
            ManagerEmployeeCode
            LockUser
            LockedUser
            PercentComplete
            ScheduleCalculation
            AutoUpdateStatus
            VersionID
            VersionLastApplied
            JobComponent
            JobTrafficPredecessors
            Traffic
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("JOB_NUMBER", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobNumber() As Integer
		<Key>
		<Required>
        <Column("JOB_COMPONENT_NBR", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentNumber() As Short
		<MaxLength(10)>
		<Column("TRF_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TrafficCode() As String
		<MaxLength(6)>
		<Column("TRF_PRESET_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TrafficPresetCode() As String
		<Column("TRF_COMMENTS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TrafficComments() As String
		<MaxLength(6)>
		<Column("ASSIGN_1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Assign1() As String
		<MaxLength(6)>
		<Column("ASSIGN_2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Assign2() As String
		<MaxLength(6)>
		<Column("ASSIGN_3", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Assign3() As String
		<MaxLength(6)>
		<Column("ASSIGN_4", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Assign4() As String
		<MaxLength(6)>
		<Column("ASSIGN_5", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Assign5() As String
		<Column("COMPLETED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CompletedDate() As Nullable(Of Date)
		<Column("DATE_DELIVERED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DateDelivered() As Nullable(Of Date)
		<Column("DATE_SHIPPED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DateShipped() As Nullable(Of Date)
		<MaxLength(40)>
		<Column("RECEIVED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ReceivedBy() As String
		<MaxLength(150)>
		<Column("REFERENCE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Reference() As String
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ROWID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RowID() As Integer
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)>
		<MaxLength(6)>
		<Column("MGR_EMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ManagerEmployeeCode() As String
		<MaxLength(100)>
		<Column("LOCK_USER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LockUser() As String
		<MaxLength(100)>
		<Column("LOCKED_USER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LockedUser() As String
        <Column("AUTO_UPDATE_STATUS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AutoUpdateStatus() As Nullable(Of Boolean)
        <Column("JOB_TRAFFIC_VER_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VersionID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <Column("VERSION_LAST_APPLIED")>
        Public Property VersionLastApplied() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("PERCENT_COMPLETE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PercentComplete() As Nullable(Of Decimal)
		<Column("SCHEDULE_CALC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ScheduleCalculation() As Nullable(Of Integer)
		<Column("IS_TEMPLATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsTemplate() As Boolean

		<ForeignKey("JobNumber, JobComponentNumber")>
        Public Overridable Property JobComponent As Database.Entities.JobComponent
        Public Overridable Property JobTrafficPredecessors As ICollection(Of Database.Entities.JobTrafficPredecessors)
        Public Overridable Property Traffic As Database.Entities.Status

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.JobNumber

        End Function

#End Region

	End Class

End Namespace
