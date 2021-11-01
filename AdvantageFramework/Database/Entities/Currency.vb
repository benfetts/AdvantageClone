Namespace Database.Entities

	<Table("CURRENCY_HEADER")>
	Public Class Currency
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			CurrencyCode
			GLACode
			ForeignCurrencyGLACode
			IsInactive
			AccountPayables
			CurrencyDetails
			GeneralLedgerAccounts
			Products
			Vendors
			VendorHistorys
			Clients

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(5)>
		<Column("CURRENCY_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property CurrencyCode() As String
		<MaxLength(30)>
		<Column("GLACODE_AP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACode() As String
		<MaxLength(30)>
		<Column("GLACODE_AP_FRN", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ForeignCurrencyGLACode() As String
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)

        Public Overridable Property AccountPayables As ICollection(Of Database.Entities.AccountPayable)
        Public Overridable Property CurrencyDetails As ICollection(Of Database.Entities.CurrencyDetail)
        Public Overridable Property Products As ICollection(Of Database.Entities.Product)
        Public Overridable Property Vendors As ICollection(Of Database.Entities.Vendor)
        Public Overridable Property VendorHistorys As ICollection(Of Database.Entities.VendorHistory)
        Public Overridable Property Clients As ICollection(Of Database.Entities.Client)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.CurrencyCode

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            'objects 
            Dim ErrorText As String = ""

            ErrorText = MyBase.ValidateEntity(IsValid)

            If IsValid Then

                If Me.IsEntityBeingAdded() Then

                    If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Currencies.ToList
                        Where Entity.CurrencyCode.ToUpper = Me.CurrencyCode.ToUpper
                        Select Entity).Any Then

                        IsValid = False
                        ErrorText = "A currency code already exist for this currency."

                    End If

                End If

            End If

            ValidateEntity = ErrorText

        End Function

#End Region

	End Class

End Namespace
