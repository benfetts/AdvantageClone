Namespace Database.Entities

	<Table("IMP_VENDOR_STAGING")>
	Public Class ImportVendorStaging
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			IsNew
			FieldName
			VendorCode
			VendorName
			VendorStreetAddressLine1
			VendorStreetAddressLine2
			VendorStreetAddressLine3
			VendorCity
			VendorCounty
			VendorState
			VendorCountry
			VendorZipCode
			VendorPhoneNumber
			VendorPhoneNumberExtension
			VendorFaxPhoneNumber
			VendorFaxPhoneNumberExtension
			VendorPayToCode
			VendorPayToName
			VendorPayToAddressLine1
			VendorPayToAddressLine2
			VendorPayToStreetAddressLine3
			VendorPayToCity
			VendorPayToCounty
			VendorPayToState
			VendorPayToCountry
			VendorPayToZipCode
			VendorPayToPhoneNumber
			VendorPayToPhoneNumberExtension
			VendorPayToFaxPhoneNumber
			VendorPayToFaxPhoneNumberExtension
			VendorTermCode
			VendorTaxID
			Vendor1099Flag
			VendorCategory
			DefaultAPAccount
			VendorNotes
			DefaultExpenseAccount
			AssociateWithOffice
			OfficeCode
			Vendor1099StreetAddressLine1
			Vendor1099StreetAddressLine2
			Vendor1099StreetAddressLine3
			Vendor1099City
			Vendor1099State
			Vendor1099ZipCode
			Vendor1099County
			Vendor1099Country
			UseAlternativeAddressFor1099
			VendorAccountNumber
			DefaultFunction
			EmployeeVendor
			OneCheckPerInvoice
			VendorEmailAddress
			PaymentManagerEmailAddress
			ActiveFlag
			OnHold

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("IMPORT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<Column("IS_NEW")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property IsNew() As Boolean
		<Column("FIELD_NAME", TypeName:="varchar(MAX)")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property FieldName() As String
		<MaxLength(6)>
		<Column("VN_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property VendorCode() As String
		<MaxLength(40)>
		<Column("VN_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property VendorName() As String
		<MaxLength(40)>
		<Column("VN_ADDRESS1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Vendor Address 1")>
		Public Property VendorStreetAddressLine1() As String
		<MaxLength(40)>
		<Column("VN_ADDRESS2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Vendor Address 2")>
		Public Property VendorStreetAddressLine2() As String
		<MaxLength(30)>
		<Column("VN_ADDRESS3", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Vendor Address 3")>
		Public Property VendorStreetAddressLine3() As String
		<MaxLength(25)>
		<Column("VN_CITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorCity() As String
		<MaxLength(20)>
		<Column("VN_COUNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorCounty() As String
		<MaxLength(10)>
		<Column("VN_STATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorState() As String
		<MaxLength(20)>
		<Column("VN_COUNTRY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorCountry() As String
		<MaxLength(10)>
		<Column("VN_ZIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorZipCode() As String
		<MaxLength(13)>
		<Column("VN_PHONE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorPhoneNumber() As String
		<MaxLength(4)>
		<Column("VN_PHONE_EXT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorPhoneNumberExtension() As String
		<MaxLength(13)>
		<Column("VN_FAX_NUMBER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorFaxPhoneNumber() As String
		<MaxLength(4)>
		<Column("VN_FAX_EXTENTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorFaxPhoneNumberExtension() As String
		<MaxLength(6)>
		<Column("VN_PAY_TO_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property VendorPayToCode() As String
		<MaxLength(40)>
		<Column("VN_PAY_TO_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property VendorPayToName() As String
		<MaxLength(40)>
		<Column("VN_PAY_TO_ADDRESS1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Vendor Pay To Address 1")>
		Public Property VendorPayToAddressLine1() As String
		<MaxLength(40)>
		<Column("VN_PAY_TO_ADDRESS2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Vendor Pay To Address 2")>
		Public Property VendorPayToAddressLine2() As String
		<MaxLength(30)>
		<Column("VN_PAY_TO_ADDRESS3", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Vendor Pay To Address 3")>
		Public Property VendorPayToStreetAddressLine3() As String
		<MaxLength(25)>
		<Column("VN_PAY_TO_CITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorPayToCity() As String
		<MaxLength(20)>
		<Column("VN_PAY_TO_COUNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorPayToCounty() As String
		<MaxLength(10)>
		<Column("VN_PAY_TO_STATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorPayToState() As String
		<MaxLength(20)>
		<Column("VN_PAY_TO_COUNTRY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorPayToCountry() As String
		<MaxLength(10)>
		<Column("VN_PAY_TO_ZIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorPayToZipCode() As String
		<MaxLength(13)>
		<Column("VN_PAY_TO_PHONE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorPayToPhoneNumber() As String
		<MaxLength(4)>
		<Column("VN_PAY_TO_EXT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorPayToPhoneNumberExtension() As String
		<MaxLength(13)>
		<Column("VN_PAY_TO_FAX_NBR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorPayToFaxPhoneNumber() As String
		<MaxLength(4)>
		<Column("VN_PAY_TO_FAX_EXT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorPayToFaxPhoneNumberExtension() As String
		<MaxLength(3)>
		<Column("VT_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.VendorTermCode)>
		Public Property VendorTermCode() As String
		<MaxLength(20)>
		<Column("VN_TAX_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorTaxID() As String
		<Column("VN_1099_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Vendor 1099 Flag", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property Vendor1099Flag() As Nullable(Of Short)
		<MaxLength(1)>
		<Column("VN_CATEGORY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ImportVendorCategoryCode)>
		Public Property VendorCategory() As String
		<MaxLength(30)>
		<Column("GLACODE_AP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
		Public Property DefaultAPAccount() As String
		<Column("VN_NOTES")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorNotes() As String
		<MaxLength(30)>
		<Column("GLACODE_EXP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
		Public Property DefaultExpenseAccount() As String
		<Column("ASSOC_OFFICE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property AssociateWithOffice() As Nullable(Of Short)
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Office", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.OfficeCode)>
		Public Property OfficeCode() As String
		<MaxLength(40)>
		<Column("VN_1099_ADDRESS1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Vendor 1099 Address 1")>
		Public Property Vendor1099StreetAddressLine1() As String
		<MaxLength(40)>
		<Column("VN_1099_ADDRESS2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Vendor 1099 Address 2")>
		Public Property Vendor1099StreetAddressLine2() As String
		<MaxLength(30)>
		<Column("VN_1099_ADDRESS3", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Vendor 1099 Address 3")>
		Public Property Vendor1099StreetAddressLine3() As String
		<MaxLength(25)>
		<Column("VN_1099_CITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Vendor 1099 City")>
		Public Property Vendor1099City() As String
		<MaxLength(10)>
		<Column("VN_1099_STATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Vendor 1099 State")>
		Public Property Vendor1099State() As String
		<MaxLength(10)>
		<Column("VN_1099_ZIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Vendor 1099 Zip Code")>
		Public Property Vendor1099ZipCode() As String
		<MaxLength(20)>
		<Column("VN_1099_COUNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Vendor 1099 County")>
		Public Property Vendor1099County() As String
		<MaxLength(20)>
		<Column("VN_1099_COUNTRY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Vendor 1099 Country")>
		Public Property Vendor1099Country() As String
		<Column("VN_USE_1099")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Use Alternative Address For 1099", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property UseAlternativeAddressFor1099() As Nullable(Of Short)
		<MaxLength(30)>
		<Column("VN_ACCT_NBR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorAccountNumber() As String
		<MaxLength(6)>
		<Column("DEF_FNC_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.VendorFunctionCode)>
		Public Property DefaultFunction() As String
		<Column("EMP_VENDOR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property EmployeeVendor() As Nullable(Of Integer)
		<Column("ONE_CHECK_PER_INV")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property OneCheckPerInvoice() As Nullable(Of Short)
		<MaxLength(50)>
		<Column("VN_EMAIL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Email)>
		Public Property VendorEmailAddress() As String
		<MaxLength(50)>
		<Column("PYMT_MGR_EMAIL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Email)>
		Public Property PaymentManagerEmailAddress() As String
		<Column("VN_ACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property ActiveFlag() As Nullable(Of Short)
		<Required>
		<Column("ON_HOLD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OnHold() As Boolean


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Protected Overrides Sub FinalizeEntityPropertyValidation(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object, ByRef ErrorText As String,
                                                                 ByVal IsEntityKey As Boolean, ByVal IsNullable As Boolean, ByVal IsRequired As Boolean, ByVal MaxLength As Integer,
                                                                 ByVal Precision As Long, ByVal Scale As Long, ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes)

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorZipCode.ToString,
                        AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPhoneNumber.ToString,
                        AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPhoneNumber.ToString,
                        AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorFaxPhoneNumber.ToString,
                        AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToZipCode.ToString,
                        AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToPhoneNumber.ToString,
                        AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToFaxPhoneNumber.ToString,
                        AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.OfficeCode.ToString,
                        AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.DefaultFunction.ToString,
                        AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorEmailAddress.ToString,
                        AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.PaymentManagerEmailAddress.ToString,
                        AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.DefaultExpenseAccount.ToString,
                        AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.Vendor1099ZipCode.ToString

                    If Me.IsNew = False AndAlso Value = "*" Then

                        IsValid = True
                        ErrorText = ""

                    End If

            End Select

        End Sub
        Protected Overrides Sub ClearNonRequiredPropertiesWithInvalidBlankValues(ByVal PropertyName As String, ByRef Value As Object)

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.OfficeCode.ToString, _
                        AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.DefaultFunction.ToString, _
                        AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.DefaultExpenseAccount.ToString

                    Try

                        If Me.IsNew Then

                            Value = Nothing

                        Else

                            Value = ""

                        End If

                    Catch ex As Exception

                    End Try

            End Select

        End Sub
        Public Shadows Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim GLOfficeXREFCode As String = Nothing
            Dim PropertyValue As String = Nothing
            Dim AllowCostOfSaleEntry As Boolean = False

            PropertyValue = Value

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorCode.ToString

                    If Me.IsNew Then

                        If AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(_DbContext, Value) IsNot Nothing Then

                            IsValid = False
                            ErrorText = "Vendor code already exist in the system."

                        End If

                    Else

                        If AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(_DbContext, Value) Is Nothing Then

                            IsValid = False
                            ErrorText = "Vendor code does not exist in the system."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorName.ToString

                    If Value <> Nothing Then

                        If Me.IsNew = False Then

                            If Value = "*" Then

                                IsValid = False
                                ErrorText = "You cannot clear a vendor's name."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToCode.ToString

                    If Value <> Nothing Then

                        If Value <> "*" Then

                            If Value <> Me.VendorCode AndAlso AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(_DbContext, Value) Is Nothing Then

                                IsValid = False
                                ErrorText = "Please enter a valid vendor pay to code or use this item vendor code."

                            End If

                        Else

                            If Me.IsNew = False AndAlso Value = "*" Then

                                IsValid = False
                                ErrorText = "You cannot clear a vendor pay to code."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToName.ToString

                    If Value <> Nothing Then

                        If Me.IsNew = False Then

                            If Value = "*" Then

                                IsValid = False
                                ErrorText = "You cannot clear a vendor's pay to name."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.DefaultAPAccount.ToString

                    If Value <> Nothing AndAlso IsValid Then

                        If Me.IsNew OrElse (Me.IsNew = False AndAlso Value <> "*") Then

                            If (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(_DbContext, True, True, "5")) _
                                    Where Entity.Code = PropertyValue
                                    Select Entity).Any = False Then

                                IsValid = False
                                ErrorText = "Please enter a valid AP account."

                            End If

                        Else

                            If Me.IsNew = False AndAlso Value = "*" Then

                                IsValid = False
                                ErrorText = "You cannot clear a vendor AP account."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.DefaultExpenseAccount.ToString

                    If Value <> Nothing AndAlso IsValid Then

                        If Me.IsNew OrElse (Me.IsNew = False AndAlso Value <> "*") Then

                            Try

                                AllowCostOfSaleEntry = AdvantageFramework.Database.Procedures.Agency.AllowCostOfSaleEntry(_DbContext)

                            Catch ex As Exception
                                AllowCostOfSaleEntry = False
                            End Try

                            If AllowCostOfSaleEntry Then

                                If (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(_DbContext, True, False)) _
                                        Where Entity.Code = PropertyValue
                                        Select Entity).Any = False Then

                                    IsValid = False
                                    ErrorText = "Please enter a valid expense account."

                                End If

                            Else

                                If (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(_DbContext, True, False)) _
                                        Where Entity.Type <> "8" AndAlso _
                                              Entity.Type <> "13"
                                        Select Entity).Any = False Then

                                    IsValid = False
                                    ErrorText = "Please enter a valid expense account."

                                End If

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.OfficeCode.ToString

                    If Value <> Nothing AndAlso IsValid Then

                        If Me.IsNew Then

                            If AdvantageFramework.Database.Procedures.Office.LoadAllActive(_DbContext).Any(Function(Entity) Entity.Code = PropertyValue) = False Then

                                IsValid = False
                                ErrorText = "Please enter a valid active office code."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorTermCode.ToString

                    If Value <> Nothing AndAlso IsValid Then

                        If Me.IsNew Then

                            If AdvantageFramework.Database.Procedures.VendorTerm.LoadAllActive(_DbContext).Any(Function(Entity) Entity.Code = PropertyValue) = False Then

                                IsValid = False
                                ErrorText = "Please enter a valid active vendor term code."

                            End If

                        Else

                            If Me.IsNew = False AndAlso Value = "*" Then

                                IsValid = False
                                ErrorText = "You cannot clear a vendor term code."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorCategory.ToString

                    If Value <> Nothing AndAlso IsValid Then

                        If Me.IsNew = False Then

                            If Value = "*" Then

                                IsValid = False
                                ErrorText = "You cannot clear a vendor category code."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Shadows Function ValidateCustomProperties(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object,
                                                         Vendors As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Vendor),
                                                         GeneralLedgerAccounts As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount),
                                                         Offices As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Office),
                                                         VendorTerms As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.VendorTerm),
                                                         VendorCategories As System.Collections.Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute),
                                                         Functions As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Function),
                                                         GeneralLedgerOfficeCrossReferences As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference),
                                                         AllowCostOfSaleEntry As Boolean) As String

            'objects
            Dim ErrorText As String = ""
            Dim GLOfficeXREFCode As String = Nothing
            Dim PropertyValue As String = Nothing

            PropertyValue = Value

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorCode.ToString

                    If Me.IsNew Then

                        If Vendors.Any(Function(Entity) Entity.Code = PropertyValue) Then

                            IsValid = False
                            ErrorText = "Vendor code already exist in the system."

                        Else

                            Try

                                If _DataContext IsNot Nothing Then

                                    _DataContext = New AdvantageFramework.Database.DataContext(_DbContext.ConnectionString, _DbContext.UserCode)

                                End If

                            Catch ex As Exception
                                _DataContext = Nothing
                            End Try

                            ErrorText = AdvantageFramework.BaseClasses.ValidatePropertyType(DbContext, DataContext, BaseClasses.PropertyTypes.Code, Value, IsValid)

                        End If

                    Else

                        If Vendors.Any(Function(Entity) Entity.Code = PropertyValue) = False Then

                            IsValid = False
                            ErrorText = "Vendor code does not exist in the system."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorName.ToString

                    If Value <> Nothing Then

                        If Me.IsNew = False Then

                            If Value = "*" Then

                                IsValid = False
                                ErrorText = "You cannot clear a vendor's name."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToCode.ToString

                    If Value <> Nothing Then

                        If Value <> "*" Then

                            If Value <> Me.VendorCode AndAlso Vendors.Any(Function(Entity) Entity.Code = PropertyValue) = False Then

                                IsValid = False
                                ErrorText = "Please enter a valid vendor pay to code or use this item vendor code."

                            End If

                        Else

                            If Me.IsNew = False AndAlso Value = "*" Then

                                IsValid = False
                                ErrorText = "You cannot clear a vendor pay to code."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToName.ToString

                    If Value <> Nothing Then

                        If Me.IsNew = False Then

                            If Value = "*" Then

                                IsValid = False
                                ErrorText = "You cannot clear a vendor's pay to name."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.DefaultAPAccount.ToString

                    If Value <> Nothing AndAlso IsValid Then

                        If Me.IsNew OrElse (Me.IsNew = False AndAlso Value <> "*") Then

                            If (From Entity In LoadGeneralAccounts(GeneralLedgerAccounts, Offices, True, True, "5")
                                Where Entity.Code = PropertyValue
                                Select Entity).Any = False Then

                                IsValid = False
                                ErrorText = "Please enter a valid AP account."

                            End If

                        Else

                            If Me.IsNew = False AndAlso Value = "*" Then

                                IsValid = False
                                ErrorText = "You cannot clear a vendor AP account."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.DefaultExpenseAccount.ToString

                    If Value <> Nothing AndAlso IsValid Then

                        If Me.IsNew OrElse (Me.IsNew = False AndAlso Value <> "*") Then

                            If AllowCostOfSaleEntry Then

                                If (From Entity In LoadGeneralAccounts(GeneralLedgerAccounts, Offices, True, False)
                                    Where Entity.Code = PropertyValue
                                    Select Entity).Any = False Then

                                    IsValid = False
                                    ErrorText = "Please enter a valid expense account."

                                End If

                            Else

                                If (From Entity In LoadGeneralAccounts(GeneralLedgerAccounts, Offices, True, False)
                                    Where Entity.Type <> "8" AndAlso
                                          Entity.Type <> "13"
                                    Select Entity).Any = False Then

                                    IsValid = False
                                    ErrorText = "Please enter a valid expense account."

                                End If

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.OfficeCode.ToString

                    If Value <> Nothing AndAlso IsValid Then

                        If Me.IsNew Then

                            If Offices.Where(Function(Entity) Entity.IsInactive.GetValueOrDefault(0) = 0).Any(Function(Entity) Entity.Code = PropertyValue) = False Then

                                IsValid = False
                                ErrorText = "Please enter a valid active office code."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorTermCode.ToString

                    If Value <> Nothing AndAlso IsValid Then

                        If Me.IsNew Then

                            If VendorTerms.Where(Function(Entity) Entity.IsInactive.GetValueOrDefault(0) = 0).Any(Function(Entity) Entity.Code = PropertyValue) = False Then

                                IsValid = False
                                ErrorText = "Please enter a valid active vendor term code."

                            End If

                        Else

                            If Me.IsNew = False AndAlso Value = "*" Then

                                IsValid = False
                                ErrorText = "You cannot clear a vendor term code."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorCategory.ToString

                    If Value <> Nothing AndAlso IsValid Then

                        If Me.IsNew = False Then

                            If Value = "*" Then

                                IsValid = False
                                ErrorText = "You cannot clear a vendor category code."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Private Function LoadGeneralAccounts(GeneralLedgerAccounts As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount),
                                             Offices As Generic.List(Of AdvantageFramework.Database.Entities.Office),
                                             ExcludeOfficeAccounts As Boolean, ExcludeWorkInProgressAccountsOnly As Boolean,
                                             Optional ByVal Type As String = "") As Generic.List(Of Database.Core.GeneralLedgerAccount)

            Dim OfficeGLAccounts() As String = Nothing
            Dim ActiveGeneralLedgerAccounts As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount) = Nothing

            ActiveGeneralLedgerAccounts = GeneralLedgerAccounts.Where(Function(Entity) Entity.Active = "A").ToList

            If ExcludeOfficeAccounts Then

                Try

                    If ExcludeWorkInProgressAccountsOnly Then

                        OfficeGLAccounts = ((From Entity In Offices
                                             Select Entity.ProductionWorkInProgressGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In Offices
                                             Select Entity.MediaWorkInProgressGLACode
                                             Distinct).ToArray).ToArray

                    Else

                        OfficeGLAccounts = ((From Entity In Offices
                                             Select Entity.ProductionWorkInProgressGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In Offices
                                             Select Entity.MediaWorkInProgressGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In Offices
                                             Select Entity.AccountsReceivableGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In Offices
                                             Select Entity.AccountsPayableGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In Offices
                                             Select Entity.AccountsPayableDiscountGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In Offices
                                             Select Entity.ProductionDeferredSalesGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In Offices
                                             Select Entity.ProductionAccruedCostOfSalesGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In Offices
                                             Select Entity.ProductionAccruedAccountsPayableGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In Offices
                                             Select Entity.ProductionDeferredCostOfSalesGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In Offices
                                             Select Entity.MediaAccruedAccountsPayableGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In Offices
                                             Select Entity.MediaAccruedCostOfSalesGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In Offices
                                             Select Entity.MediaDeferredCostOfSalesGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In Offices
                                             Select Entity.MediaDeferredSalesGLACode
                                             Distinct).ToArray).ToArray

                    End If

                Catch ex As Exception
                    OfficeGLAccounts = Nothing
                End Try

                LoadGeneralAccounts = (From GeneralLedgerAccount In ActiveGeneralLedgerAccounts.AsQueryable.Where(BaseClasses.BuildDoesNotContainsExpression(Of Core.GeneralLedgerAccount, String)(Function(Entity) Entity.Code, OfficeGLAccounts))
                                       Where GeneralLedgerAccount.Type = If(String.IsNullOrEmpty(Type), GeneralLedgerAccount.Type, Type)
                                       Select GeneralLedgerAccount).ToList

            Else

                LoadGeneralAccounts = (From GeneralLedgerAccount In ActiveGeneralLedgerAccounts
                                       Where GeneralLedgerAccount.Type = If(String.IsNullOrEmpty(Type), GeneralLedgerAccount.Type, Type)
                                       Select GeneralLedgerAccount).ToList

            End If

        End Function
        Public Shadows Function ValidateEntity(ByRef IsValid As Boolean, Properties As Generic.List(Of System.ComponentModel.PropertyDescriptor),
                                               Vendors As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Vendor),
                                               GeneralLedgerAccounts As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount),
                                               Offices As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Office),
                                               VendorTerms As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.VendorTerm),
                                               VendorCategories As System.Collections.Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute),
                                               Functions As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Function),
                                               GeneralLedgerOfficeCrossReferences As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference),
                                               AllowCostOfSaleEntry As Boolean) As String

            'objects
            Dim PropertyIsValid As Boolean = True
            Dim PropertyErrorText As String = ""
            Dim ErrorText As String = ""
            Dim Value As Object = Nothing
            Dim OldValue As Object = Nothing

            For Each PropertyDescriptor In Properties

				If PropertyDescriptor.PropertyType IsNot GetType(Byte()) AndAlso (PropertyDescriptor.PropertyType.IsValueType OrElse PropertyDescriptor.PropertyType Is GetType(String)) Then

					OldValue = PropertyDescriptor.GetValue(Me)
					Value = OldValue

					PropertyErrorText = ValidateEntityProperty(PropertyDescriptor, PropertyIsValid, Value, Vendors, GeneralLedgerAccounts, Offices, VendorTerms, VendorCategories, Functions, GeneralLedgerOfficeCrossReferences, AllowCostOfSaleEntry)

					If Value <> OldValue OrElse (Value Is Nothing AndAlso OldValue IsNot Nothing) Then

						PropertyDescriptor.SetValue(Me, Value)

					End If

					If PropertyIsValid = False Then

						If IsValid Then

							IsValid = False

						End If

						ErrorText = IIf(ErrorText = "", PropertyErrorText, ErrorText & Environment.NewLine & PropertyErrorText)

					ElseIf PropertyIsValid AndAlso PropertyErrorText IsNot Nothing AndAlso PropertyErrorText <> "" Then

						ErrorText = IIf(ErrorText = "", PropertyErrorText, ErrorText & Environment.NewLine & PropertyErrorText)

					End If

				End If

			Next

            _EntityError = ErrorText

            ValidateEntity = ErrorText

        End Function
        Public Shadows Function ValidateEntityProperty(PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByRef IsValid As Boolean, ByRef Value As Object,
                                                       Vendors As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Vendor),
                                                       GeneralLedgerAccounts As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount),
                                                       Offices As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Office),
                                                       VendorTerms As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.VendorTerm),
                                                       VendorCategories As System.Collections.Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute),
                                                       Functions As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Function),
                                                       GeneralLedgerOfficeCrossReferences As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference),
                                                       AllowCostOfSaleEntry As Boolean) As String

            'objects
            Dim ErrorText As String = ""
            Dim IsEntityKey As Boolean = False
            Dim IsNullable As Boolean = False
            Dim IsRequired As Boolean = False
            Dim MaxLength As Integer = 0
            Dim Precision As Long = 0
            Dim Scale As Long = 0
            Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = AdvantageFramework.BaseClasses.PropertyTypes.Default
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim DisplayName As String = Nothing
            Dim PropertyValue As String = Nothing

            IsValid = True

            LoadPropertyAttributes(Me.GetType, PropertyDescriptor.Name, IsEntityKey, IsNullable, IsRequired, MaxLength, Precision, Scale, PropertyType, DisplayName)

            If DisplayName Is Nothing OrElse DisplayName = "" Then

                DisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(PropertyDescriptor.Name)

            End If

            Try

                ErrorText = AdvantageFramework.BaseClasses.ValidateData(Value, IsValid, DisplayName, IsEntityKey, IsRequired, IsNullable, MaxLength, Precision, Scale)

                If IsValid Then

                    Try

                        If _DataContext Is Nothing AndAlso _DbContext IsNot Nothing Then

                            _DataContext = New AdvantageFramework.Database.DataContext(_DbContext.ConnectionString, _DbContext.UserCode)

                        End If

                    Catch ex As Exception
                        _DataContext = Nothing
                    End Try

                    If PropertyType <> BaseClasses.PropertyTypes.Default Then

                        PropertyValue = Value

                        Select Case PropertyType

                            Case BaseClasses.PropertyTypes.Code

                                If Value <> AdvantageFramework.StringUtilities.RemoveAllNonAlphaNumeric(Value) Then

                                    IsValid = False

                                End If

                            Case BaseClasses.PropertyTypes.Email

                                If AdvantageFramework.StringUtilities.IsValidEmailAddress(Value) = False Then

                                    IsValid = False

                                End If

                            Case BaseClasses.PropertyTypes.GeneralLedgerAccountCode

                                If (From GeneralLedgerAccount In GeneralLedgerAccounts
                                    Where GeneralLedgerAccount.Code = PropertyValue
                                    Select GeneralLedgerAccount).Any = False Then

                                    IsValid = False

                                End If

                            Case BaseClasses.PropertyTypes.OfficeCode

                                If (From Office In Offices
                                    Where Office.Code = PropertyValue
                                    Select Office).Any = False Then

                                    IsValid = False

                                End If

                            Case BaseClasses.PropertyTypes.VendorTermCode

                                If (From VendorTerm In VendorTerms
                                    Where VendorTerm.Code = PropertyValue
                                    Select VendorTerm).Any = False Then

                                    IsValid = False

                                End If

                            Case BaseClasses.PropertyTypes.ImportVendorCategoryCode

                                If VendorCategories.Any(Function(VenCat) VenCat.Code = PropertyValue) = False Then

                                    IsValid = False

                                End If

                            Case BaseClasses.PropertyTypes.VendorFunctionCode

                                If (From [Function] In Functions
                                    Where [Function].Code = PropertyValue AndAlso
                                          [Function].Type = "V"
                                    Select [Function]).Any = False Then

                                    IsValid = False

                                End If

                        End Select

                        If IsValid = False Then

                            ErrorText = AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(PropertyType)

                        End If

                        If PropertyType = BaseClasses.PropertyTypes.Code Then

                            If Me.IsEntityBeingAdded() = False AndAlso IsValid = False AndAlso Value <> AdvantageFramework.StringUtilities.RemoveAllNonAlphaNumeric(Value) Then

                                ErrorText = ""
                                IsValid = True

                            End If

                        End If

                    End If

                End If

                ErrorText &= ValidateCustomProperties(PropertyDescriptor.Name, IsValid, Value, Vendors, GeneralLedgerAccounts, Offices, VendorTerms, VendorCategories, Functions, GeneralLedgerOfficeCrossReferences, AllowCostOfSaleEntry)

            Catch ex As Exception
                IsValid = True
            End Try

            FinalizeEntityPropertyValidation(PropertyDescriptor.Name, IsValid, Value, ErrorText, IsEntityKey, IsNullable, IsRequired, MaxLength, Precision, Scale, PropertyType)

            If IsValid = False AndAlso ErrorText = "" AndAlso PropertyType <> AdvantageFramework.BaseClasses.PropertyTypes.Default Then

                ErrorText = AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(PropertyType)

            End If

            If IsValid = False AndAlso IsRequired = False AndAlso
                    (Value = Nothing OrElse Value Is Nothing OrElse (Value IsNot Nothing AndAlso Value.ToString = "")) Then

                IsValid = True
                ErrorText = ""

                ClearNonRequiredPropertiesWithInvalidBlankValues(PropertyDescriptor.Name, Value)

            End If

            _ErrorHashtable(PropertyDescriptor.Name) = ErrorText

            ValidateEntityProperty = ErrorText

        End Function
        Public Shadows Function ValidateEntity(ByRef IsValid As Boolean, ByVal Properties As Generic.List(Of System.ComponentModel.PropertyDescriptor)) As String

            'objects
            Dim PropertyIsValid As Boolean = True
            Dim PropertyErrorText As String = ""
            Dim ErrorText As String = ""
            Dim Value As Object = Nothing
            Dim OldValue As Object = Nothing

            For Each PropertyDescriptor In Properties

				If PropertyDescriptor.PropertyType IsNot GetType(Byte()) AndAlso (PropertyDescriptor.PropertyType.IsValueType OrElse PropertyDescriptor.PropertyType Is GetType(String)) Then

					OldValue = PropertyDescriptor.GetValue(Me)
					Value = OldValue

					PropertyErrorText = ValidateEntityProperty(PropertyDescriptor, PropertyIsValid, Value)

					If Value <> OldValue OrElse (Value Is Nothing AndAlso OldValue IsNot Nothing) Then

						PropertyDescriptor.SetValue(Me, Value)

					End If

					If PropertyIsValid = False Then

						If IsValid Then

							IsValid = False

						End If

						ErrorText = IIf(ErrorText = "", PropertyErrorText, ErrorText & Environment.NewLine & PropertyErrorText)

					ElseIf PropertyIsValid AndAlso PropertyErrorText IsNot Nothing AndAlso PropertyErrorText <> "" Then

						ErrorText = IIf(ErrorText = "", PropertyErrorText, ErrorText & Environment.NewLine & PropertyErrorText)

					End If

				End If

			Next

            _EntityError = ErrorText

            ValidateEntity = ErrorText

        End Function
        Public Shadows Function ValidateEntityProperty(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim IsEntityKey As Boolean = False
            Dim IsNullable As Boolean = False
            Dim IsRequired As Boolean = False
            Dim MaxLength As Integer = 0
            Dim Precision As Long = 0
            Dim Scale As Long = 0
            Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = AdvantageFramework.BaseClasses.PropertyTypes.Default
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim DisplayName As String = Nothing

            IsValid = True

            LoadPropertyAttributes(Me.GetType, PropertyDescriptor.Name, IsEntityKey, IsNullable, IsRequired, MaxLength, Precision, Scale, PropertyType, DisplayName)

            If DisplayName Is Nothing OrElse DisplayName = "" Then

                DisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(PropertyDescriptor.Name)

            End If

            Try

                ErrorText = AdvantageFramework.BaseClasses.ValidateData(Value, IsValid, DisplayName, IsEntityKey, IsRequired, IsNullable, MaxLength, Precision, Scale)

                If IsValid Then

                    Try

                        If _DataContext Is Nothing AndAlso _DbContext IsNot Nothing Then

                            _DataContext = New AdvantageFramework.Database.DataContext(_DbContext.ConnectionString, _DbContext.UserCode)

                        End If

                    Catch ex As Exception
                        _DataContext = Nothing
                    End Try

                    ErrorText = AdvantageFramework.BaseClasses.ValidatePropertyType(_DbContext, _DataContext, Me, Me.GetType, PropertyType, Value, IsValid)

                End If

                ErrorText &= ValidateCustomProperties(PropertyDescriptor.Name, IsValid, Value)

            Catch ex As Exception
                IsValid = True
            End Try

            FinalizeEntityPropertyValidation(PropertyDescriptor.Name, IsValid, Value, ErrorText, IsEntityKey, IsNullable, IsRequired, MaxLength, Precision, Scale, PropertyType)

            If IsValid = False AndAlso ErrorText = "" AndAlso PropertyType <> AdvantageFramework.BaseClasses.PropertyTypes.Default Then

                ErrorText = AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(PropertyType)

            End If

            If IsValid = False AndAlso IsRequired = False AndAlso
                    (Value = Nothing OrElse Value Is Nothing OrElse (Value IsNot Nothing AndAlso Value.ToString = "")) Then

                IsValid = True
                ErrorText = ""

                ClearNonRequiredPropertiesWithInvalidBlankValues(PropertyDescriptor.Name, Value)

            End If

            _ErrorHashtable(PropertyDescriptor.Name) = ErrorText

            ValidateEntityProperty = ErrorText

        End Function

#End Region

    End Class

End Namespace
