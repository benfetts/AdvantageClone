Namespace Database.Views

    <Table("V_ESTIMATE_FUNCTION_COMMENT")>
    Public Class EstimateFunctionComment
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EstimateNumber
            EstimateDesc
            EstimateComponentNumber
            EstimateCompDesc
            QuoteNumber
            QuoteDesc
            FunctionCode
            FunctionDescription
            Comment
            SuppliedByNotes
            RevisionNumber

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("EstimateNumber", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateNumber() As Integer
        <MaxLength(60)>
        <Column("EstimateDesc", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateDesc() As String
        <Key>
        <Required>
        <Column("EstimateComponentNumber", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateComponentNumber() As Short
        <MaxLength(60)>
        <Column("EstimateCompDesc", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateCompDesc() As String
        <Required>
        <Column("QuoteNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property QuoteNumber() As Short
        <MaxLength(60)>
        <Column("QuoteDesc", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property QuoteDesc() As String
        <MaxLength(6)>
        <Column("FunctionCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionCode() As String
        <MaxLength(30)>
        <Column("FunctionDescription", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FunctionDescription() As String
		<Column("Comment")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Comment() As String
		<Column("SuppliedByNotes")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SuppliedByNotes() As String
        <Required>
        <Column("RevisionNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RevisionNumber() As Short


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EstimateNumber.ToString

        End Function

#End Region

    End Class

End Namespace
