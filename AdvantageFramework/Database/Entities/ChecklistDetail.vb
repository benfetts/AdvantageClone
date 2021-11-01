Namespace Database.Entities

    <Table("CHECKLIST_DTL")>
    Public Class ChecklistDetail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ChecklistID
            Description
            IsChecked
            SortOrder
            CreatedBy
            CreatedDate
            ModifiedBy
            ModifiedDate

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer

        <Required>
        <Column("CHECKLIST_HDR_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ChecklistID() As Integer

        <Required>
        <MaxLength(100)>
        <Column("DESCRIPTION", TypeName:="varchar")>
        Public Property Description As String

        <Column("IS_CHECKED")>
        Public Property IsChecked As Boolean?

        <Column("SORT_ORDER")>
        Public Property SortOrder As Short?

        <MaxLength(6)>
        <Column("CREATED_BY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CreatedBy As String

        <Column("CREATED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CreatedDate As DateTime?

        <MaxLength(6)>
        <Column("MODIFIED_BY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedBy As String

        <Column("MODIFIED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedDate As DateTime?

#End Region

#Region " Methods "


#End Region

    End Class

End Namespace
