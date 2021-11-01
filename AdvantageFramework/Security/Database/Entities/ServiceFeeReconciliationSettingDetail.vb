Namespace Security.Database.Entities

	<Table("SERVICE_FEE_DEF_DTL")>
	Public Class ServiceFeeReconciliationSettingDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			UserCode
			Type
			Code

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(100)>
        <Column("USER_ID", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String
		<Key>
		<Required>
		<MaxLength(20)>
        <Column("DTL_TYPE", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Type() As String
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("DTL_CODE", Order:=2, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Code() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.UserCode.ToString

        End Function

#End Region

	End Class

End Namespace
