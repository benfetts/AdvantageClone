Namespace Database.Interfaces

    Public Interface IVCCCardNote

#Region " Constants "



#End Region

#Region " Enum "

        Enum EnumNoteType
            MediaOrder
            PurchaseOrder
        End Enum

        Enum Properties
            Note
            CreatedDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Property ID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Property Note() As String

        Property CreatedByUserCode() As String

        Property CreatedDate() As Date

#End Region

#Region " Methods "

        Function NoteType() As EnumNoteType

#End Region

    End Interface

End Namespace

