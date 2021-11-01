Namespace Database.Views

    <Table("V_INVOICE_JOB_COMMENT")>
    Public Class InvoiceJobComment
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            InvoiceNumber
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            Comment
            CommentSource

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("InvoiceNumber", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceNumber() As Integer
        <Key>
        <Required>
        <Column("JobNumber", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobNumber() As Integer
        <MaxLength(60)>
        <Column("JobDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDescription() As String
        <Key>
        <Required>
        <Column("JobComponentNumber", Order:=2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentNumber() As Short
        <Required>
        <MaxLength(60)>
        <Column("JobComponentDescription", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentDescription() As String
		<Column("Comment")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Comment() As String
        <Column("CommentSource")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CommentSource() As Nullable(Of Short)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.InvoiceNumber.ToString

        End Function

#End Region

    End Class

End Namespace
