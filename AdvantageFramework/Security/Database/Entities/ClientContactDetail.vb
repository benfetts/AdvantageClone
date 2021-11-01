Namespace Security.Database.Entities

    <Table("CDP_CONTACT_DTL")>
    Public Class ClientContactDetail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ContactID
            SequenceNumber
            DivisionCode
            ProductCode
            ClientContact
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("CDP_CONTACT_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ContactID() As Integer
        <Key>
        <Required>
        <Column("SEQ_NBR", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SequenceNumber() As Integer
        <Required>
        <MaxLength(6)>
        <Column("DIV_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property DivisionCode() As String
        <MaxLength(6)>
        <Column("PRD_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode() As String

        <ForeignKey("ContactID")>
        Public Overridable Property ClientContact As Database.Entities.ClientContact

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ContactID

        End Function

#End Region

    End Class

End Namespace
