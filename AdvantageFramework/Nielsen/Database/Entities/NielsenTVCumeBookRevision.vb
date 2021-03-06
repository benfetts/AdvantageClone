Namespace Nielsen.Database.Entities

    <Table("NIELSEN_TV_CUME_BOOK_REVISION")>
    Public Class NielsenTVCumeBookRevision
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OldNielsenTVCumeBookID
            NewNielsenTVCumeBookID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("NIELSEN_TV_CUME_BOOK_REVISION_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("OLD_NIELSEN_TV_CUME_BOOK_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OldNielsenTVCumeBookID() As Integer
        <Required>
        <Column("NEW_NIELSEN_TV_CUME_BOOK_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewNielsenTVCumeBookID() As Integer

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
