Namespace Reporting.Database.Classes

    <Serializable>
    Public Class SecurityGroupSettings

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            GroupName
            GroupDescription
            AllowTaskEdit
            AllowMediaPageEdit
            AllowUserToAddHolidays
            AllowUserToViewOtherEmployees
            ShowAllAssignments
            ShowUnassignedAssignments
            CanUploadDocuments
            ViewPrivateDocuments
            CreateWorkspaceTemplate

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Column("GroupName")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupName() As String
        <Column("GroupDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupDescription() As String
        <Column("AllowTaskEdit", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AllowTaskEdit() As String
        <Column("AllowMediaPageEdit", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AllowMediaPageEdit() As String
        <Column("AllowUserToAddHolidays", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AllowUserToAddHolidays() As String
        <Column("AllowUserToViewOtherEmployees", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AllowUserToViewOtherEmployees() As String
        <Column("ShowAllAssignments", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowAllAssignments() As String
        <Column("ShowUnassignedAssignments", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowUnassignedAssignments() As String
        <Column("CanUploadDocuments", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CanUploadDocuments() As String
        <Column("ViewPrivateDocuments", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ViewPrivateDocuments() As String
        <Column("CreateWorkspaceTemplate", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreateWorkspaceTemplate() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.GroupName.ToString

        End Function

#End Region

    End Class

End Namespace
