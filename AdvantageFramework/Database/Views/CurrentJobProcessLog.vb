Namespace Database.Views

    <Table("V_CURRENT_JOB_PROCESS_LOG")>
    Public Class CurrentJobProcessLog
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobNumber
            JobComponentNumber
            OriginalProcessControl
            NewProcessControl
            ProcessedDate
            ProcessedByUserCode
            Comments
            BCCFlag
            ID

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
        <Column("ORIG_PROCESS_CNTRL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OriginalProcessControl() As Nullable(Of Short)
        <Column("NEW_PROCESS_CNTRL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewProcessControl() As Nullable(Of Short)
        <Column("PROCESS_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProcessedDate() As Nullable(Of Date)
        <MaxLength(100)>
        <Column("PROCESS_USER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProcessedByUserCode() As String
		<Column("PROCESS_COMMENT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Comments() As String
        <Column("BCC_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BCCFlag() As Nullable(Of Short)
        <Required>
        <Column("JOB_PROCESS_LOG_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.JobNumber.ToString

        End Function

#End Region

    End Class

End Namespace
