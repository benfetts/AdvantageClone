Namespace Security.Database.Views

    <Table("EMPLOYEE")>
    Public Class Employee
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            LastName
            FirstName
            MiddleInital
            DepartmentCode
            WorkspaceTemplateID
			TerminationDate
			OfficeCode
            IgnoreCalendarSync
            FunctionCode
            Users
            AdassistUser
            UserEmployeeAccesses
            Department
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <MaxLength(6)>
        <Column("EMP_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
        Public Property Code() As String
        <MaxLength(30)>
        <Column("EMP_LNAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property LastName() As String
        <MaxLength(30)>
        <Column("EMP_FNAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property FirstName() As String
        <MaxLength(1)>
        <Column("EMP_MI", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MiddleInitial() As String
        <MaxLength(4)>
        <Column("DP_TM_CODE", TypeName:="varchar")>
        <ForeignKey("Department")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property DepartmentCode() As String
        <Column("WV_TMPLT_HDR_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property WorkspaceTemplateID() As Nullable(Of Integer)
        <Column("EMP_TERM_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TerminationDate() As Nullable(Of Date)
        <MaxLength(4)>
        <Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OfficeCode() As String
		<Required>
		<Column("IGNORE_CALENDAR_SYNC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IgnoreCalendarSync() As Boolean
        <MaxLength(6)>
        <Column("DEF_FNC_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionCode() As String

        Public Overridable Property Users() As ICollection(Of Database.Entities.User)
        Public Overridable Property UserEmployeeAccesses() As ICollection(Of Database.Entities.UserEmployeeAccess)
        Public Overridable Property Department() As Database.Entities.Department
        Public Overridable Property Office() As Database.Entities.Office

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            If Me.MiddleInitial IsNot Nothing AndAlso Me.MiddleInitial.Trim <> "" Then

                ToString = Me.FirstName & " " & Me.MiddleInitial & ". " & Me.LastName

            Else

                ToString = Me.FirstName & " " & Me.LastName

            End If

        End Function

#End Region

    End Class

End Namespace
