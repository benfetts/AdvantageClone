Namespace Database.Entities

	<Table("JOB_TRAFFIC_VER")>
	Public Class JobTrafficVersion
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			JobNumber
			JobComponentNumber
			TrafficCode
			TrafficPresetCode
			TrafficComments
			Assign1EmployeeCode
			Assign2EmployeeCode
			Assign3EmployeeCode
			Assign4EmployeeCode
			Assign5EmployeeCode
			CompletedDate
			DateDelivered
			DateShipped
			ReceivedBy
			Reference
			ManagerEmployeeCode
			LockUserCode
			LockedUserCode
			PercentComplete
			ScheduleCalculation
			AutoUpdateStatus
			VersionSequenceNumber
			VersionName
			VersionComment
			VersionIsActive
			VersionIsCurrentVersion
			VersionCreatedByUserCode
			VersionCreatedDate
			VersionCreatedComment
			INACTIVE_FLAG
			Status
			JobTrafficTemplate

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
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobNumber() As Integer
		<Required>
		<Column("JOB_COMPONENT_NBR")>
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
		Public Property Assign1EmployeeCode() As String
		<MaxLength(6)>
		<Column("ASSIGN_2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Assign2EmployeeCode() As String
		<MaxLength(6)>
		<Column("ASSIGN_3", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Assign3EmployeeCode() As String
		<MaxLength(6)>
		<Column("ASSIGN_4", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Assign4EmployeeCode() As String
		<MaxLength(6)>
		<Column("ASSIGN_5", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Assign5EmployeeCode() As String
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
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)>
		<MaxLength(6)>
		<Column("MGR_EMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ManagerEmployeeCode() As String
		<MaxLength(100)>
		<Column("LOCK_USER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LockUserCode() As String
		<MaxLength(100)>
		<Column("LOCKED_USER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LockedUserCode() As String
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
		<Column("PERCENT_COMPLETE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PercentComplete() As Nullable(Of Decimal)
		<Column("SCHEDULE_CALC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ScheduleCalculation() As Nullable(Of Integer)
		<Column("AUTO_UPDATE_STATUS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AutoUpdateStatus() As Nullable(Of Boolean)
		<Column("VER_SEQ_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VersionSequenceNumber() As Byte
		<MaxLength(256)>
		<Column("VER_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VersionName() As String
		<Column("VER_COMMENT", TypeName:="varchar(MAX)")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VersionComment() As String
		<Column("VER_ACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VersionIsActive() As Nullable(Of Boolean)
		<Column("VER_IS_CURRENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VersionIsCurrentVersion() As Nullable(Of Boolean)
		<MaxLength(100)>
		<Column("VER_CREATED_BY_USER_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VersionCreatedByUserCode() As String
		<Column("VER_CREATED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VersionCreatedDate() As Nullable(Of Date)
		<Column("VER_CREATED_COMMENT", TypeName:="varchar(MAX)")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VersionCreatedComment() As String
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property INACTIVE_FLAG() As Nullable(Of Boolean)

        <ForeignKey("TrafficCode")>
        Public Overridable Property Status As Database.Entities.Status
        Public Overridable Property JobTrafficTemplate As ICollection(Of Database.Entities.JobTrafficTemplate)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
