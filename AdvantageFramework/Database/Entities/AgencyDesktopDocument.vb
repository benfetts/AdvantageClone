Namespace Database.Entities

    <Table("AGENCY_DESKTOP_DOCUMENTS")>
    Public Class AgencyDesktopDocument
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            DocumentID
            OfficeCode
            DepartmentTeamCode
            Office
            Document
            DepartmentTeam

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("DOCUMENT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DocumentID() As Integer
        <MaxLength(4)>
        <Column("OFFICE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
        <MaxLength(4)>
        <Column("DP_TM_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DepartmentTeamCode() As String

        Public Overridable Property Office As Database.Entities.Office
        <ForeignKey("DocumentID")>
        Public Overridable Property Document As Database.Entities.Document
        Public Overridable Property DepartmentTeam As Database.Entities.DepartmentTeam

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.DocumentID

        End Function

#End Region

    End Class

End Namespace
