Namespace Database.Entities

	<Table("GLOXREF")>
	Public Class GeneralLedgerOfficeCrossReference
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Code
			OfficeCode
			UserCode
			EnteredDate
			ModifiedDate
			Office
			GeneralLedgerAccounts

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(20)>
		<Column("GLOXGLOFFICE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<MaxLength(4)>
		<Column("GLOXOFFICE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.OfficeCode)>
		Public Property OfficeCode() As String
		<MaxLength(100)>
		<Column("GLOXUSER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property UserCode() As String
		<Column("GLOXENTDATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property EnteredDate() As Nullable(Of Date)
		<Column("GLOXMODDATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ModifiedDate() As Nullable(Of Date)

        Public Overridable Property Office As Database.Entities.Office
        Public Overridable Property GeneralLedgerAccounts As ICollection(Of Database.Entities.GeneralLedgerAccount)

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

                Case AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference.Properties.OfficeCode.ToString

                    If IsValid Then

                        PropertyValue = Value

                        If Me.IsEntityBeingAdded() Then

                            If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).GeneralLedgerOfficeCrossReferences
                                Where Entity.OfficeCode.ToUpper = DirectCast(PropertyValue, String).ToUpper
                                Select Entity).Any Then

                                IsValid = False
                                ErrorText = "The office code you have selected is already associated with another GL Office Code. Please select again."

                            End If

                        Else

                            If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).GeneralLedgerOfficeCrossReferences _
                                   Where Entity.OfficeCode.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso _
                                         Entity.Code <> Me.Code _
                                   Select Entity).Any Then

                                IsValid = False
                                ErrorText = "The office code you have selected is already associated with another GL Office Code. Please select again."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
