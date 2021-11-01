Namespace Database.Entities

	<Table("EMP_TIME_DTL_CMTS")>
	Public Class EmployeeTimeComment
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			EmployeeTimeID
			EmployeeTimeDetailID
			SequenceNumber
			EmployeeTimeSource
			EmployeeComments
			AdjusterComments
			StartTime
			EndTime

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("ET_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeTimeID() As Integer
		<Key>
		<Required>
        <Column("ET_DTL_ID", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeTimeDetailID() As Short
		<Key>
		<Required>
        <Column("SEQ_NBR", Order:=2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SequenceNumber() As Short
		<Key>
		<Required>
		<MaxLength(1)>
        <Column("ET_SOURCE", Order:=3, TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeTimeSource() As String
		<Column("EMP_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeComments() As String
		<Column("ADJ_COMMENTS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AdjusterComments() As String
		<MaxLength(4)>
		<Column("START_TIME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StartTime() As String
		<MaxLength(4)>
		<Column("END_TIME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EndTime() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EmployeeTimeID.ToString

        End Function

#End Region

	End Class

End Namespace
