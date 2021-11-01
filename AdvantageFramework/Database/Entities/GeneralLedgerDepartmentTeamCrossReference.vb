Namespace Database.Entities

	<Table("GLDXREF")>
	Public Class GeneralLedgerDepartmentTeamCrossReference
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Code
			DepartmentTeamCode
			UserCode
			EnteredDate
			ModifiedDate
			DepartmentTeam

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(20)>
		<Column("GLDXGLDEPT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Code() As String
		<MaxLength(4)>
		<Column("GLDXDEPT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DepartmentTeamCode)>
		Public Property DepartmentTeamCode() As String
		<MaxLength(100)>
		<Column("GLDXUSER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property UserCode() As String
		<Column("GLDXENTDATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property EnteredDate() As Nullable(Of Date)
		<Column("GLDXMODDATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ModifiedDate() As Nullable(Of Date)

        Public Overridable Property DepartmentTeam As Database.Entities.DepartmentTeam

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code.ToString

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.GeneralLedgerDepartmentTeamCrossReference.Properties.DepartmentTeamCode.ToString

                    If IsValid Then

                        PropertyValue = Value

                        If Me.IsEntityBeingAdded() Then

                            If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).GeneralLedgerDepartmentTeamCrossReferences
                                Where Entity.DepartmentTeamCode.ToUpper = DirectCast(PropertyValue, String).ToUpper
                                Select Entity).Any Then

                                IsValid = False
                                ErrorText = "The department code you have selected is already associated with another GL Department Code. Please select again."

                            End If

                        Else

                            If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).GeneralLedgerDepartmentTeamCrossReferences _
                                   Where Entity.DepartmentTeamCode.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso _
                                         Entity.Code <> Me.Code _
                                   Select Entity).Any Then

                                IsValid = False
                                ErrorText = "The department code you have selected is already associated with another GL Department Code. Please select again."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
