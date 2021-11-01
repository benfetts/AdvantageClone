Namespace Database.Entities

	<Table("COMPANY_PROFILE_AFFILIATION")>
	Public Class CompanyProfileAffiliation
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			CompanyProfileID
			AffiliationID
			Affiliation
			CompanyProfile

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("COMPANY_PROFILE_AFFILIATION_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<Column("COMPANY_PROFILE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property CompanyProfileID() As Integer
		<Required>
		<Column("AFFILIATION_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Affiliation")>
		Public Property AffiliationID() As Integer

        Public Overridable Property Affiliation As Database.Entities.Affiliation
        Public Overridable Property CompanyProfile As Database.Entities.CompanyProfile

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            PropertyValue = Value

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.CompanyProfileAffiliation.Properties.AffiliationID.ToString

                    If Me.IsEntityBeingAdded() Then

                        If Me.AffiliationID = 0 Then

                            IsValid = False

                            ErrorText = "Please enter a valid affiliation."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
