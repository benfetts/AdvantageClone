Namespace Database.Entities

    <Table("GLRJETRL")>
    Public Class GeneralLedgerRecurringEntryDetail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ControlNumber
            SequenceNumber
            GLACode
            Amount
            Remarks
            ClientCode
            DivisionCode
            ProductCode
            GeneralLedgerRecurringEntry
            GeneralLedgerAccount
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("GLRTCNTRL", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ControlNumber() As Integer
        <Key>
        <Required>
        <Column("GLRTSEQ", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property SequenceNumber() As Short
        <Required>
        <MaxLength(30)>
        <Column("GLRTCODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property GLACode() As String
        <Required>
        <Column("GLRTAMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Amount() As Nullable(Of Double)
        <MaxLength(45)>
        <Column("GLRTREM", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Remarks() As String
        <MaxLength(6)>
        <Column("CL_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientCode() As String
        <MaxLength(6)>
        <Column("DIV_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionCode() As String
        <MaxLength(6)>
        <Column("PRD_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductCode() As String

        <ForeignKey("ControlNumber")>
        Public Overridable Property GeneralLedgerRecurringEntry As Database.Entities.GeneralLedgerRecurringEntry
        <ForeignKey("GLACode")>
        Public Overridable Property GeneralLedgerAccount As Database.Entities.GeneralLedgerAccount

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ControlNumber.ToString & " - " & Me.SequenceNumber.ToString

        End Function

#End Region

    End Class

End Namespace
