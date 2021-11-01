Namespace Database.Entities

	<Table("AP_PROD_COMMENTS")>
	Public Class AccountPayableProductionComment
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			AccountPayableID
			LineNumber
			JobNumber
			JobComponentNumber
			FunctionCode
			Comment

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("AP_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccountPayableID() As Integer
		<Key>
		<Required>
        <Column("LINE_NUMBER", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LineNumber() As Short
		<Column("JOB_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobNumber() As Nullable(Of Integer)
		<Column("JOB_COMPONENT_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentNumber() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("FNC_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FunctionCode() As String
		<Column("AP_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Comment() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AccountPayableID.ToString

        End Function
        Public Function Copy() As AdvantageFramework.Database.Entities.AccountPayableProductionComment

            Dim EntityCopy As AdvantageFramework.Database.Entities.AccountPayableProductionComment = Nothing

            EntityCopy = New AdvantageFramework.Database.Entities.AccountPayableProductionComment

            With EntityCopy
                .AccountPayableID = Me.AccountPayableID
                .LineNumber = Me.LineNumber
                .JobNumber = Me.JobNumber
                .JobComponentNumber = Me.JobComponentNumber
                .FunctionCode = Me.FunctionCode
                .Comment = Me.Comment
            End With

            Copy = EntityCopy

        End Function

#End Region

	End Class

End Namespace
