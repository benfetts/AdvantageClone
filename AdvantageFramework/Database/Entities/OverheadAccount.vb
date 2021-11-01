Namespace Database.Entities

	<Table("OH_ACCOUNTS")>
	Public Class OverheadAccount
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Code
			FromGLACode
			Description
			ToGLACode
			GeneralLedgerAccount
			GeneralLedgerAccount2

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(20)>
        <Column("OH_CODE", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=True)>
		Public Property Code() As String
		<Key>
		<Required>
		<MaxLength(30)>
        <Column("OH_FROM", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Account From")>
		Public Property FromGLACode() As String
		<MaxLength(30)>
		<Column("OH_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Description() As String
        <Required>
        <MaxLength(30)>
		<Column("OH_TO", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Account To")>
        Public Property ToGLACode() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.OverheadAccount.Properties.FromGLACode.ToString

                    If Value <> Nothing AndAlso Value <> "" Then

                        If AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(Me.DbContext, Value) Is Nothing Then

                            IsValid = False
                            ErrorText = "Please enter a valid from code."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.OverheadAccount.Properties.ToGLACode.ToString

                    If Value <> Nothing AndAlso Value <> "" Then

                        If AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(Me.DbContext, Value) Is Nothing Then

                            IsValid = False
                            ErrorText = "Please enter a valid to code."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
