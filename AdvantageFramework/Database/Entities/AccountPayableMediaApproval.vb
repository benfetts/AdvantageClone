Namespace Database.Entities

	<Table("AP_MEDIA_APPROVAL")>
	Public Class AccountPayableMediaApproval
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			AccountPayableID
			OrderNumber
			LineNumber
			Revision
			Source
			Status
			IsActiveRevision
			UserCode
			RevisionDate
			Comments
			ApplicationSource

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
        <Column("ORDER_NBR", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderNumber() As Integer
		<Key>
		<Required>
        <Column("LINE_NBR", Order:=2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LineNumber() As Short
		<Key>
		<Required>
        <Column("REVISION", Order:=3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Revision() As Short
		<Key>
		<Required>
		<MaxLength(1)>
        <Column("SOURCE", Order:=4, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Source() As String
		<Column("STATUS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Status() As Nullable(Of Short)
		<Column("ACTIVE_REV")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsActiveRevision() As Nullable(Of Short)
		<MaxLength(100)>
		<Column("USER_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String
		<Column("DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RevisionDate() As Nullable(Of Date)
		<MaxLength(254)>
		<Column("COMMENTS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Comments() As String
		<MaxLength(6)>
		<Column("APP_SOURCE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ApplicationSource() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AccountPayableID.ToString

        End Function

#End Region

	End Class

End Namespace
