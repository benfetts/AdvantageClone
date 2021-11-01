Namespace Database.Entities

    <Table("VCC_CARD_NOTE")>
    Public Class VCCCardNote
        Inherits BaseClasses.Entity
        Implements Interfaces.IVCCCardNote

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Note
            CreatedByUserCode
            CreatedDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Column("VCC_CARD_NOTE_ID")>
        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer Implements Interfaces.IVCCCardNote.ID

        <Column("VCC_CARD_ID")>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property VCCCardID() As Integer

        <Column("NOTE")>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property Note() As String Implements Interfaces.IVCCCardNote.Note

        <Column("USER_CREATED")>
        <Required>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True, CustomColumnCaption:="By")>
        Public Property CreatedByUserCode() As String Implements Interfaces.IVCCCardNote.CreatedByUserCode

        <Column("CREATED_DATE", TypeName:="smalldatetime")>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True, CustomColumnCaption:="Date", DisplayFormat:="G")>
        Public Property CreatedDate() As Date Implements Interfaces.IVCCCardNote.CreatedDate

        <ForeignKey("VCCCardID")>
        Public Property VCCCard As VCCCard

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Function NoteType() As Interfaces.IVCCCardNote.EnumNoteType Implements Interfaces.IVCCCardNote.NoteType

            NoteType = Interfaces.IVCCCardNote.EnumNoteType.MediaOrder

        End Function

#End Region

    End Class

End Namespace
