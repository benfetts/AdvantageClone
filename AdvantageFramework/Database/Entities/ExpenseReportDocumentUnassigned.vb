Namespace Database.Entities

    <Table("EXPENSE_DOCS_UNASSND")>
    Public Class ExpenseReportDocumentUnassigned
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            DocumentID
            EmployeeCode

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)>
        <Required>
        <Column("DOCUMENT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DocumentID() As Integer
        <MaxLength(6)>
        <Column("EMP_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeCode() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.DocumentID

        End Function

#End Region

    End Class

End Namespace
