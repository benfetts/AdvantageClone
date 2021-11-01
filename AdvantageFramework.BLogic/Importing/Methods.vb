Namespace Importing

    <HideModuleName()>
    Public Module Methods

        Public Event ImportingProgressUpdateEvent(ByVal ProgressValue As Integer)
        Public Event SetupImportingProgressEvent(ByVal MinValue As Integer, ByVal MaxValue As Integer, ByVal Value As Integer)
        Public Event OverallImportingProgressUpdateEvent(ByVal ProgressValue As Integer)
        Public Event SetupOverallImportingProgressEvent(ByVal MinValue As Integer, ByVal MaxValue As Integer, ByVal Value As Integer)

#Region " Constants "

        Private Const NullHashKeyString As String = "*NullHashKeyString**"

#End Region

#Region " Enum "

        Public Enum CSIReconciliationTemplates
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Com Data AC29 File")>
            ComDataAC29File = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Fixed File Format")>
            FixedFileFormat = 2
        End Enum

        Public Enum FileTypes
            CSV = 1
            Fixed = 2
        End Enum

        Public Enum ImportType
            Employee = 1
            Vendor = 2
            ExpenseReport = 3
            ClearedChecks = 4
            AccountsPayable = 5
            Client = 6
            Division = 7
            Product = 8
            [Function] = 9
            ChartOfAccounts = 10
            AccountsReceivable = 11
            DigitalResults = 12
            AvalaraTaxCode = 13
            CashReceipt = 14
            ClientContact = 15
            PTO = 16
            JournalEntry = 17
            MediaRFP = 18
        End Enum

        Public Enum ImportTemplateTypes As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("ExpenseReport_CreditCard", "Credit Card")>
            ExpenseReport_CreditCard = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("ExpenseReport_NonCreditCard", "Non Credit Card")>
            ExpenseReport_NonCreditCard = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("ClearedChecks_Default", "Default")>
            ClearedChecks_Default = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("AccountsPayable_Generic", "Generic")>
            AccountsPayable_Generic = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("AccountsPayable_StrataFixedInternet", "Strata Fixed Internet")>
            AccountsPayable_StrataFixedInternet = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Client_Default", "Default")>
            Client_Default = 6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Division_Default", "Default")>
            Division_Default = 7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Product_Default", "Default")>
            Product_Default = 8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("AccountsPayable_StrataFixedBroadcast", "Strata Fixed Broadcast")>
            AccountsPayable_StrataFixedBroadcast = 9
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("AccountsPayable_StrataFixedPrint", "Strata Fixed Print")>
            AccountsPayable_StrataFixedPrint = 10
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Function_Default", "Default")>
            Function_Default = 11
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("ChartOfAccounts_Default", "Default")>
            ChartOfAccounts_Default = 12
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("AccountsReceivable_Default", "Default")>
            AccountsReceivable_Default = 13
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("DigitalResults_Default", "Default")>
            DigitalResults_Default = 14
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("AvalaraTaxCode_Default", "Default")>
            AvalaraTaxCode_Default = 15
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CashReceipt_Generic", "Generic")>
            CashReceipt_Generic = 16
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CashReceipt_Custom", "Custom")>
            CashReceipt_Custom = 17
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("AccountsReceivable_Custom", "Custom")>
            AccountsReceivable_Custom = 18
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("AccountsPayable_Custom", "Custom")>
            AccountsPayable_Custom = 19
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("ClearedChecks_MediaVCC", "Media VCC")>
            ClearedChecks_MediaVCC = 20
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("ClientContact_Default", "Default")>
            ClientContact_Default = 21
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("PTO_Default", "Default")>
            PTO_Default = 22
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("JournalEntry_Default", "Default")>
            JournalEntry_Default = 23
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("JournalEntry_MOGLIFACE", "MO GLIFACE")>
            JournalEntry_MOGLIFACE = 24
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("AccountsPayable_4AsBroadcast", "4A's Broadcast")>
            AccountsPayable_4AsBroadcast = 25
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Employee_Hours", "Hours")>
            Employee_Hours = 26
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("MediaRFP_4As", "4A's")>
            MediaRFP_4As = 27
        End Enum

        Public Enum VendorImportColumns
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
            VendorTerms
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
        End Enum

        Public Enum EmployeeImportColumns
            EmployeeCode
            FirstName
            MiddleInitial
            LastName
            DepartmentCode
            AccountNumber
            Email
            Address
            Address2
            City
            State
            Zip
            County
            OtherInfo
            PhoneNumber
            WorkPhoneNumber
            WorkPhoneNumberExtension
            CellPhoneNumber
            AlternatePhoneNumber
            Title
            SupervisorEmployeeCode
            OfficeCode
            FunctionCode
            StartDate
            TerminationDate
            BillingRate
            CostRate
            BirthDate
            LastIncrease
            NextReview
            AnnualSalary
            MonthlySalary
            AnnualHours
            MonthHoursGoal
            PurchaseOrderLimit
            PurchaseOrderApprovalRuleCode
            DirectHours
            RoleCode
        End Enum

        Public Enum AccountPayableImportColumns
            ID
            BatchName
            VendorCode
            VendorName
            InvoiceNumber
            InvoiceDescription
            InvoiceDate
            InvoiceTotalNet
            InvoiceTotalTax
            OfficeCode
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            MediaType
            OrderID
            OrderNumber
            Month
            Year
            SalesClassCode
            OrderLineID
            OrderLineNumber
            LineDate
            MediaQuantity
            MediaNetAmount
            MediaVendorTax
            MediaNetCharge
            MediaMarkupPercent
            MediaAddAmount
            PONumber
            POLine
            JobNumber
            JobComponentNumber
            FunctionCode
            JobQuantity
            JobNetAmount
            JobVendorTax
            JobComment
            GLACode
            GLNetAmount
            GLComment
            SourceCode
            ProductionNBGLAccount
        End Enum

        Public Enum APImportDefaultInvoiceDescription
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("None", "None")>
            None
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CDP_Codes", "CDP Codes")>
            CDP_Codes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Client_Name", "Client Name")>
            Client_Name
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Product_Name", "Product Name")>
            Product_Name
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Client_Name_and_Client_PO", "Client Name and Client PO")>
            Client_Name_and_Client_PO
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Product_Name_and_Client_PO", "Product Name and Client PO")>
            Product_Name_and_Client_PO
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Campaign_Code_and_Name", "Campaign Code and Name")>
            Campaign_Code_and_Name
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CDP_Campaign_Codes", "CDP/Campaign Codes")>
            CDP_Campaign_Codes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CDP_Codes_and_Client_PO", "CDP Codes and Client PO")>
            CDP_Codes_and_Client_PO
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Client_PO", "Client PO")>
            Client_PO
        End Enum

        Public Enum CashReceiptImportColumns
            ID
            BatchName
            CheckNumber
            CheckDate
            CheckAmount
            DepositDate
            IsCleared
            ARInvoiceNumber
            PaymentAmount
            PaymentTypeDescription
            AltInvoiceNumber
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Function ScrubString(ByVal FileData As String, ByVal AutoTrimOverflowData As Boolean,
                                     ByVal MaxLength As Long) As String

            'objects
            Dim ScrubedFileData As String = ""

            If FileData IsNot Nothing Then

                ScrubedFileData = FileData.Trim

            End If

            If AutoTrimOverflowData Then

                If MaxLength > 0 Then

                    If ScrubedFileData.Length > MaxLength Then

                        ScrubedFileData = ScrubedFileData.Substring(0, MaxLength)

                    End If

                End If

            End If

            ScrubString = ScrubedFileData

        End Function
        Private Function ScrubString(ByVal FileData As String, ByVal AutoTrimOverflowData As Boolean,
                                     ByVal DbContext As AdvantageFramework.Database.DbContext,
                                     ByVal EnumProperty As [Enum], ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor) As String

            'objects
            Dim ScrubedFileData As String = ""
            Dim MaxLength As Long = 0

            If FileData IsNot Nothing Then

                ScrubedFileData = FileData.Trim

            End If

            If AutoTrimOverflowData Then

                If PropertyDescriptor IsNot Nothing Then

                    MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(PropertyDescriptor)

                Else

                    MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(EnumProperty.GetType.DeclaringType, EnumProperty.ToString)

                End If

                ScrubedFileData = ScrubString(FileData, AutoTrimOverflowData, MaxLength)

            End If

            ScrubString = ScrubedFileData

        End Function
        Private Function ScrubDecimal(ByVal FileData As String, ByVal AutoTrimOverflowData As Boolean,
                                      ByVal Precision As Long, ByVal Scale As Long, FileType As AdvantageFramework.Importing.FileTypes) As Object

            'objects
            Dim ScrubedFileData As Object = Nothing

            If FileType = FileTypes.Fixed Then

                If String.IsNullOrWhiteSpace(FileData) = False Then

                    If FileData.Contains(".") = False Then

                        FileData = FileData.Substring(0, FileData.Length - Scale) & "." & FileData.Substring(FileData.Length - Scale)

                    End If

                    If Decimal.TryParse(FileData, ScrubedFileData) = False Then

                        ScrubedFileData = Nothing

                    Else

                        If AutoTrimOverflowData Then

                            ScrubedFileData = CDec(AdvantageFramework.StringUtilities.FormatNumberString(CDec(ScrubedFileData).ToString, Precision, Scale))

                        End If

                    End If

                End If

            Else

                If Decimal.TryParse(FileData, ScrubedFileData) = False Then

                    ScrubedFileData = Nothing

                Else

                    If AutoTrimOverflowData Then

                        ScrubedFileData = CDec(AdvantageFramework.StringUtilities.FormatNumberString(CDec(ScrubedFileData).ToString, Precision, Scale))

                    End If

                End If

            End If

            ScrubDecimal = ScrubedFileData

        End Function
        Private Function ScrubDecimal(ByVal FileData As String, ByVal AutoTrimOverflowData As Boolean,
                                      ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal EnumProperty As [Enum], ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor) As Object

            'objects
            Dim ScrubedFileData As Object = Nothing
            Dim Precision As Long = 0
            Dim Scale As Long = 0

            If Decimal.TryParse(FileData, ScrubedFileData) = False Then

                ScrubedFileData = Nothing

            Else

                If AutoTrimOverflowData Then

                    If PropertyDescriptor IsNot Nothing Then

                        Precision = AdvantageFramework.BaseClasses.Entity.LoadPropertyPrecision(PropertyDescriptor)
                        Scale = AdvantageFramework.BaseClasses.Entity.LoadPropertyScale(PropertyDescriptor)

                    Else

                        Precision = AdvantageFramework.BaseClasses.Entity.LoadPropertyPrecision(EnumProperty.GetType.DeclaringType, EnumProperty.ToString)
                        Scale = AdvantageFramework.BaseClasses.Entity.LoadPropertyScale(EnumProperty.GetType.DeclaringType, EnumProperty.ToString)

                    End If

                    ScrubedFileData = CDec(AdvantageFramework.StringUtilities.FormatNumberString(CDec(ScrubedFileData).ToString, Precision, Scale))

                End If

            End If

            ScrubDecimal = ScrubedFileData

        End Function
        Private Function ScrubDate(ByVal FileData As String) As Object

            'objects
            Dim ScrubedFileData As Object = Nothing

            If Date.TryParse(AdvantageFramework.DateUtilities.ConvertStringToShortDateString(FileData), ScrubedFileData) = False Then

                ScrubedFileData = Nothing

            End If

            ScrubDate = ScrubedFileData

        End Function
        Private Function ScrubDate(ByVal FileData As String, ByVal DateFormat As String) As Object

            'objects
            Dim ScrubedFileData As Object = Nothing

            If Date.TryParse(AdvantageFramework.DateUtilities.ConvertStringToShortDateString(FileData, DateFormat), ScrubedFileData) = False Then

                ScrubedFileData = Nothing

            End If

            ScrubDate = If(IsDate(ScrubedFileData), CDate(ScrubedFileData), Nothing)

            If ScrubDate = Nothing Then

                ScrubDate = Nothing

            End If

        End Function
        Private Function ScrubShort(ByVal FileData As String) As Object

            'objects
            Dim ScrubedFileData As Object = Nothing

            If Short.TryParse(FileData, ScrubedFileData) = False Then

                ScrubedFileData = Nothing

            End If

            ScrubShort = ScrubedFileData

        End Function
        Private Function ScrubInteger(ByVal FileData As String) As Object

            'objects
            Dim ScrubedFileData As Object = Nothing

            If Integer.TryParse(FileData, ScrubedFileData) = False Then

                ScrubedFileData = Nothing

            End If

            ScrubInteger = ScrubedFileData

        End Function
        Private Function ScrubLong(ByVal FileData As String) As Object

            'objects
            Dim ScrubedFileData As Object = Nothing

            If Long.TryParse(FileData, ScrubedFileData) = False Then

                ScrubedFileData = Nothing

            End If

            ScrubLong = ScrubedFileData

        End Function
        Private Function ScrubBoolean(ByVal FileData As String) As Object

            'objects
            Dim ScrubedFileData As Object = Nothing

            If FileData = Boolean.TrueString OrElse FileData = "1" Then

                ScrubedFileData = True

            Else

                ScrubedFileData = False

            End If

            ScrubBoolean = ScrubedFileData

        End Function
        Public Function ScrubFileData(ByVal FileData As String, ByVal SystemType As System.Type, ByVal AutoTrimOverflowData As Boolean, MaxLength As Long, Precision As Long, Scale As Long, ByVal DateFormat As String, FileType As AdvantageFramework.Importing.FileTypes) As Object

            'objects
            Dim ScrubedFileData As Object = Nothing

            Try

                If SystemType Is GetType(String) Then

                    ScrubedFileData = ScrubString(FileData, AutoTrimOverflowData, MaxLength)

                ElseIf SystemType Is GetType(Decimal) Then

                    ScrubedFileData = ScrubDecimal(FileData, AutoTrimOverflowData, Precision, Scale, FileType)

                ElseIf SystemType Is GetType(Short) Then

                    ScrubedFileData = ScrubShort(FileData)

                ElseIf SystemType Is GetType(Integer) Then

                    ScrubedFileData = ScrubInteger(FileData)

                ElseIf SystemType Is GetType(Long) Then

                    ScrubedFileData = ScrubLong(FileData)

                ElseIf SystemType Is GetType(Date) Then

                    If String.IsNullOrEmpty(DateFormat) Then

                        ScrubedFileData = ScrubDate(FileData)

                    Else

                        ScrubedFileData = ScrubDate(FileData, DateFormat)

                    End If

                ElseIf SystemType Is GetType(Boolean) Then

                    ScrubedFileData = ScrubBoolean(FileData)

                Else

                    ScrubedFileData = FileData

                End If

            Catch ex As Exception
                ScrubedFileData = Nothing
            Finally
                ScrubFileData = ScrubedFileData
            End Try

        End Function
        Public Function ScrubFileData(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor,
                                      ByVal FileData As String, ByVal SystemType As System.Type, ByVal AutoTrimOverflowData As Boolean) As Object

            'objects
            Dim ScrubedFileData As Object = Nothing

            Try

                If SystemType Is GetType(String) Then

                    ScrubedFileData = ScrubString(FileData, AutoTrimOverflowData, DbContext, Nothing, PropertyDescriptor)

                ElseIf SystemType Is GetType(Decimal) Then

                    ScrubedFileData = ScrubDecimal(FileData, AutoTrimOverflowData, DbContext, Nothing, PropertyDescriptor)

                ElseIf SystemType Is GetType(Short) Then

                    ScrubedFileData = ScrubShort(FileData)

                ElseIf SystemType Is GetType(Integer) Then

                    ScrubedFileData = ScrubInteger(FileData)

                ElseIf SystemType Is GetType(Long) Then

                    ScrubedFileData = ScrubLong(FileData)

                ElseIf SystemType Is GetType(Date) Then

                    ScrubedFileData = ScrubDate(FileData)

                Else

                    ScrubedFileData = FileData

                End If

            Catch ex As Exception
                ScrubedFileData = Nothing
            Finally
                ScrubFileData = ScrubedFileData
            End Try

        End Function
        Public Function ScrubFileData(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportType As AdvantageFramework.Importing.ImportType,
                                      ByVal FileData As String, ByVal EnumProperty As [Enum], ByVal AutoTrimOverflowData As Boolean) As Object

            'objects
            Dim ScrubedFileData As Object = Nothing

            Try

                If ImportType = Methods.ImportType.Employee Then

                    Select Case AdvantageFramework.EnumUtilities.GetValue(EnumProperty)

                        Case AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.EmployeeCode, AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.DepartmentTeamCode,
                                AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.LastName, AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.FirstName,
                                AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.MiddleInitial, AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.Address,
                                AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.Address2, AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.City,
                                AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.County, AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.PhoneNumber,
                                AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.State, AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.OtherInfo,
                                AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.Zip, AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.Title,
                                AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.Email, AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.OfficeCode,
                                AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.SupervisorEmployeeCode, AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.FunctionCode,
                                AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.WorkPhoneNumber, AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.CellPhoneNumber,
                                AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.AlternatePhoneNumber, AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.WorkPhoneNumberExtension,
                                AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.RoleCode, AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.PurchaseOrderApprovalRuleCode,
                                AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.AccountNumber

                            ScrubedFileData = ScrubString(FileData, AutoTrimOverflowData, DbContext, EnumProperty, Nothing)

                        Case AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.CostRate, AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.AnnualSalary,
                                AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.MonthlySalary, AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.MonthHoursGoal,
                                AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.PurchaseOrderLimit, AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.AnnualHours,
                                AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.DirectHours, AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.BillRate

                            ScrubedFileData = ScrubDecimal(FileData, AutoTrimOverflowData, DbContext, EnumProperty, Nothing)

                        Case AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.StartDate, AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.TerminationDate,
                                AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.BirthDate, AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.LastIncrease,
                                AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.NextReview

                            ScrubedFileData = ScrubDate(FileData)

                    End Select

                ElseIf ImportType = Methods.ImportType.Vendor Then

                    Select Case AdvantageFramework.EnumUtilities.GetValue(EnumProperty)

                        Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.FieldName, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorCode,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorName, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorStreetAddressLine1,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorStreetAddressLine2, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorStreetAddressLine3,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorCity, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorCounty, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorState,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorCountry, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorZipCode,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPhoneNumber, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPhoneNumberExtension,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorFaxPhoneNumber, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorFaxPhoneNumberExtension,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToCode, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToName,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToAddressLine1, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToAddressLine2,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToStreetAddressLine3, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToCity,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToCounty, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToState,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToCountry, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToZipCode,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToPhoneNumber, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToPhoneNumberExtension,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToFaxPhoneNumber, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToFaxPhoneNumberExtension,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorTermCode, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorTaxID,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorCategory, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.DefaultAPAccount,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorNotes, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.DefaultExpenseAccount,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.OfficeCode, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.Vendor1099StreetAddressLine1,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.Vendor1099StreetAddressLine2, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.Vendor1099StreetAddressLine3,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.Vendor1099City, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.Vendor1099State,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.Vendor1099ZipCode, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.Vendor1099County,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.Vendor1099Country, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorAccountNumber,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.DefaultFunction, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorEmailAddress,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.PaymentManagerEmailAddress

                            ScrubedFileData = ScrubString(FileData, AutoTrimOverflowData, DbContext, EnumProperty, Nothing)

                        Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.ActiveFlag, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.OneCheckPerInvoice,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.UseAlternativeAddressFor1099, AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.AssociateWithOffice,
                                AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.Vendor1099Flag

                            ScrubedFileData = ScrubShort(FileData)

                        Case AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.EmployeeVendor

                            ScrubedFileData = ScrubInteger(FileData)

                    End Select

                End If

            Catch ex As Exception
                ScrubedFileData = Nothing
            Finally
                ScrubFileData = ScrubedFileData
            End Try

        End Function
        Public Function ScrubFileData(ByVal Session As AdvantageFramework.Security.Session, ByVal ImportType As AdvantageFramework.Importing.ImportType,
                                      ByVal FileData As String, ByVal EnumProperty As [Enum], ByVal AutoTrimOverflowData As Boolean) As Object

            'objects
            Dim ScrubedFileData As Object = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    ScrubedFileData = ScrubedFileData(DbContext, ImportType, FileData, EnumProperty, AutoTrimOverflowData)

                End Using

            Catch ex As Exception
                ScrubedFileData = Nothing
            Finally
                ScrubFileData = ScrubedFileData
            End Try

        End Function
        Public Function GetValueFromFileLine(ByVal FileLine As String(), ByVal Position As Integer) As String

            If FileLine.Count > Position Then

                Return FileLine(Position)

            Else

                Return Nothing

            End If

        End Function
        Public Function LoadFirstCSVLine(ByVal File As String) As String()

            'objects
            Dim Fields() As String = Nothing

            Try

                Using TextFieldParser = New Microsoft.VisualBasic.FileIO.TextFieldParser(File)

                    TextFieldParser.SetDelimiters(New String() {","})
                    TextFieldParser.HasFieldsEnclosedInQuotes = True

                    If Not TextFieldParser.EndOfData Then

                        Fields = TextFieldParser.ReadFields

                    End If

                End Using

            Catch ex As Exception
                Fields = Nothing
            Finally
                LoadFirstCSVLine = Fields
            End Try

        End Function
        Public Function LoadFirstCSVLine(ByVal Session As AdvantageFramework.Security.Session, ByVal File As String) As String()

            Dim CSVLine() As String = Nothing
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim FileLines() As String = Nothing
            Dim StringList As Generic.List(Of String) = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Try

                        StreamReader = New System.IO.StreamReader(File)

                    Catch ex As Exception
                        StreamReader = Nothing
                    Finally

                        If StreamReader IsNot Nothing Then

                            StringList = New Generic.List(Of String)

                            Do While StreamReader.Peek <> -1

                                StringList.Add(StreamReader.ReadLine())

                            Loop

                            FileLines = StringList.ToArray

                            Try

                                StreamReader.Close()
                                StreamReader.Dispose()

                            Catch ex As Exception

                            End Try

                        End If

                    End Try

                    If FileLines IsNot Nothing AndAlso FileLines.Count > 0 Then

                        CSVLine = FileLines.FirstOrDefault.Split(",")

                    End If

                End Using

            Catch ex As Exception
                CSVLine = Nothing
            Finally
                LoadFirstCSVLine = CSVLine
            End Try

        End Function
        'Private Sub CreateEntityFromTemplate(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate, _
        '                                     ByVal FileLineData As Object, _
        '                                     ByVal ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail), _
        '                                     ByRef Entity As AdvantageFramework.BaseClasses.Entity, ByVal AutoTrimOverflowData As Boolean, _
        '                                     ByVal ScrubValuesByPropertyType As Boolean, _
        '                                     ByVal PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor))

        '    Select Case ImportTemplate.FileType

        '        Case AdvantageFramework.Importing.FileTypes.CSV

        '            CreateEntityFromCSVTemplate(Session, DbContext, FileLineData, ImportTemplateDetails, Entity, AutoTrimOverflowData, ScrubValuesByPropertyType, PropertyDescriptorsList)

        '        Case AdvantageFramework.Importing.FileTypes.Fixed

        '            CreateEntityFromFixedTemplate(Session, DbContext, FileLineData, ImportTemplateDetails, Entity, AutoTrimOverflowData, ScrubValuesByPropertyType, PropertyDescriptorsList)

        '    End Select

        'End Sub
        'Private Sub CreateEntityFromCSVTemplate(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, _
        '                                        ByVal FileLineData() As String, _
        '                                        ByVal ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail), _
        '                                        ByRef Entity As AdvantageFramework.BaseClasses.Entity, ByVal AutoTrimOverflowData As Boolean, _
        '                                        ByVal ScrubValuesByPropertyType As Boolean, _
        '                                        ByVal PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor))

        '    'objects
        '    Dim ImportTemplateDetail As AdvantageFramework.Database.Entities.ImportTemplateDetail = Nothing
        '    Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
        '    Dim SystemType As System.Type = Nothing
        '    Dim PropertyValue As Object = Nothing

        '    For Each ImportTemplateDetail In ImportTemplateDetails

        '        Try

        '            PropertyDescriptor = PropertyDescriptorsList.SingleOrDefault(Function(PropDesc) PropDesc.Name = ImportTemplateDetail.FieldName)

        '        Catch ex As Exception
        '            PropertyDescriptor = Nothing
        '        End Try

        '        If PropertyDescriptor IsNot Nothing Then

        '            Try

        '                If FileLineData(ImportTemplateDetail.CSVPosition) IsNot Nothing Then

        '                    If Nullable.GetUnderlyingType(PropertyDescriptor.PropertyType) IsNot Nothing Then

        '                        SystemType = Nullable.GetUnderlyingType(PropertyDescriptor.PropertyType)

        '                    Else

        '                        SystemType = PropertyDescriptor.PropertyType

        '                    End If

        '                    PropertyValue = ScrubFileData(Session, DbContext, PropertyDescriptor, FileLineData(ImportTemplateDetail.CSVPosition), SystemType, AutoTrimOverflowData)

        '                    If ScrubValuesByPropertyType Then

        '                        ScrubDataByPropertyType(Session, DbContext, Entity, PropertyDescriptor, PropertyValue)

        '                    End If

        '                    PropertyDescriptor.SetValue(Entity, Convert.ChangeType(PropertyValue, SystemType))

        '                End If

        '            Catch ex As Exception

        '            End Try

        '        End If

        '    Next

        'End Sub
        'Private Sub CreateEntityFromFixedTemplate(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, _
        '                                          ByVal FileLine As String, _
        '                                          ByVal ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail), _
        '                                          ByRef Entity As AdvantageFramework.BaseClasses.Entity, ByVal AutoTrimOverflowData As Boolean, _
        '                                          ByVal ScrubValuesByPropertyType As Boolean, _
        '                                          ByVal PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor))

        '    'objects
        '    Dim ImportTemplateDetail As AdvantageFramework.Database.Entities.ImportTemplateDetail = Nothing
        '    Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
        '    Dim SystemType As System.Type = Nothing
        '    Dim PropertyValue As Object = Nothing
        '    Dim FileData As String = ""

        '    For Each ImportTemplateDetail In ImportTemplateDetails

        '        Try

        '            PropertyDescriptor = PropertyDescriptorsList.SingleOrDefault(Function(PropDesc) PropDesc.Name = ImportTemplateDetail.FieldName)

        '        Catch ex As Exception
        '            PropertyDescriptor = Nothing
        '        End Try

        '        If PropertyDescriptor IsNot Nothing Then

        '            Try

        '                FileData = FileLine.Substring(ImportTemplateDetail.Start.GetValueOrDefault(0), ImportTemplateDetail.Length.GetValueOrDefault(0))

        '            Catch ex As Exception
        '                FileData = ""
        '            End Try

        '            Try

        '                If FileData <> "" Then

        '                    If Nullable.GetUnderlyingType(PropertyDescriptor.PropertyType) IsNot Nothing Then

        '                        SystemType = Nullable.GetUnderlyingType(PropertyDescriptor.PropertyType)

        '                    Else

        '                        SystemType = PropertyDescriptor.PropertyType

        '                    End If

        '                    PropertyValue = ScrubFileData(Session, DbContext, PropertyDescriptor, FileData, SystemType, AutoTrimOverflowData)

        '                    If ScrubValuesByPropertyType Then

        '                        ScrubDataByPropertyType(Session, DbContext, Entity, PropertyDescriptor, PropertyValue)

        '                    End If

        '                    PropertyDescriptor.SetValue(Entity, Convert.ChangeType(PropertyValue, SystemType))

        '                End If

        '            Catch ex As Exception

        '            End Try

        '        End If

        '    Next

        'End Sub
        Private Sub CreateEntityFromTemplateDataTable(ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                      ByVal DataTable As System.Data.DataTable, ByVal FileLineData As Object,
                                                      ByVal EntityBase As AdvantageFramework.BaseClasses.EntityBase, ByVal AutoTrimOverFlowData As Boolean)

            'objects
            Dim PropertyValue As Object = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim FileData As String = ""

            Select Case ImportTemplate.FileType

                Case AdvantageFramework.Importing.FileTypes.CSV

                    For Each DataColumn In DataTable.Columns

                        If DataColumn.ExtendedProperties("CSVPosition") <= UBound(FileLineData) AndAlso FileLineData(DataColumn.ExtendedProperties("CSVPosition")) IsNot Nothing Then

                            Try

                                PropertyDescriptor = DataColumn.ExtendedProperties("PropertyDescriptor")

                            Catch ex As Exception
                                PropertyDescriptor = Nothing
                            End Try

                            If PropertyDescriptor IsNot Nothing Then

                                PropertyValue = ScrubFileData(FileLineData(DataColumn.ExtendedProperties("CSVPosition")), DataColumn.DataType, AutoTrimOverFlowData,
                                                              DataColumn.MaxLength, DataColumn.ExtendedProperties("Precision"), DataColumn.ExtendedProperties("Scale"), DataColumn.ExtendedProperties("DateFormat"), ImportTemplate.FileType)

                                PropertyDescriptor.SetValue(EntityBase, PropertyValue)

                            End If

                        End If

                    Next

                Case AdvantageFramework.Importing.FileTypes.Fixed

                    For Each DataColumn In DataTable.Columns

                        Try

                            FileData = FileLineData.Substring(DataColumn.ExtendedProperties("Start"), DataColumn.ExtendedProperties("Length"))

                        Catch ex As Exception
                            FileData = ""
                        End Try

                        If FileData <> "" Then

                            Try

                                PropertyDescriptor = DataColumn.ExtendedProperties("PropertyDescriptor")

                            Catch ex As Exception
                                PropertyDescriptor = Nothing
                            End Try

                            If PropertyDescriptor IsNot Nothing Then

                                PropertyValue = ScrubFileData(FileData, DataColumn.DataType, AutoTrimOverFlowData,
                                                              DataColumn.MaxLength, DataColumn.ExtendedProperties("Precision"), DataColumn.ExtendedProperties("Scale"), DataColumn.ExtendedProperties("DateFormat"), ImportTemplate.FileType)

                                PropertyDescriptor.SetValue(EntityBase, PropertyValue)

                            End If

                        End If

                    Next

            End Select

        End Sub
        Private Sub CreateEntityFromTemplateDataTable(ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                      ByVal DataTable As System.Data.DataTable, ByVal FileLineData As Object,
                                                      ByVal Entity As AdvantageFramework.BaseClasses.Entity, ByVal AutoTrimOverFlowData As Boolean)

            'objects
            Dim PropertyValue As Object = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim FileData As String = ""

            Select Case ImportTemplate.FileType

                Case AdvantageFramework.Importing.FileTypes.CSV

                    For Each DataColumn In DataTable.Columns

                        If DataColumn.ExtendedProperties("CSVPosition") <= UBound(FileLineData) AndAlso FileLineData(DataColumn.ExtendedProperties("CSVPosition")) IsNot Nothing Then

                            Try

                                PropertyDescriptor = DataColumn.ExtendedProperties("PropertyDescriptor")

                            Catch ex As Exception
                                PropertyDescriptor = Nothing
                            End Try

                            If PropertyDescriptor IsNot Nothing Then

                                PropertyValue = ScrubFileData(FileLineData(DataColumn.ExtendedProperties("CSVPosition")), DataColumn.DataType, AutoTrimOverFlowData,
                                                              DataColumn.MaxLength, DataColumn.ExtendedProperties("Precision"), DataColumn.ExtendedProperties("Scale"), DataColumn.ExtendedProperties("DateFormat"), ImportTemplate.FileType)

                                PropertyDescriptor.SetValue(Entity, PropertyValue)

                            End If

                        End If

                    Next

                Case AdvantageFramework.Importing.FileTypes.Fixed

                    For Each DataColumn In DataTable.Columns

                        Try

                            FileData = FileLineData.Substring(DataColumn.ExtendedProperties("Start"), DataColumn.ExtendedProperties("Length"))

                        Catch ex As Exception
                            FileData = ""
                        End Try

                        If FileData <> "" Then

                            Try

                                PropertyDescriptor = DataColumn.ExtendedProperties("PropertyDescriptor")

                            Catch ex As Exception
                                PropertyDescriptor = Nothing
                            End Try

                            If PropertyDescriptor IsNot Nothing Then

                                PropertyValue = ScrubFileData(FileData, DataColumn.DataType, AutoTrimOverFlowData,
                                                              DataColumn.MaxLength, DataColumn.ExtendedProperties("Precision"), DataColumn.ExtendedProperties("Scale"), DataColumn.ExtendedProperties("DateFormat"), ImportTemplate.FileType)

                                PropertyDescriptor.SetValue(Entity, PropertyValue)

                            End If

                        End If

                    Next

            End Select

        End Sub
        Private Function CreateDataTableFromTemplate(ByVal ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail),
                                                     ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                     ByVal ClassType As System.Type, ImportTemplateType As ImportTemplateTypes) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim MaxLength As Long = 0
            Dim Precision As Long = 0
            Dim Scale As Long = 0
            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim ImportTemplateDetail As AdvantageFramework.Database.Entities.ImportTemplateDetail = Nothing

            Try

                Try

                    PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(ClassType).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                Catch ex As Exception

                End Try

                If PropertyDescriptorsList IsNot Nothing Then

                    DataTable = New System.Data.DataTable

                    For Each ImportTemplateDetail In ImportTemplateDetails

                        Try

                            PropertyDescriptor = PropertyDescriptorsList.SingleOrDefault(Function(PropDesc) PropDesc.Name = ImportTemplateDetail.FieldName)

                        Catch ex As Exception
                            PropertyDescriptor = Nothing
                        End Try

                        If PropertyDescriptor IsNot Nothing Then

                            DataColumn = DataTable.Columns.Add(PropertyDescriptor.Name)

                            If Nullable.GetUnderlyingType(PropertyDescriptor.PropertyType) IsNot Nothing Then

                                DataColumn.AllowDBNull = True
                                DataColumn.DataType = Nullable.GetUnderlyingType(PropertyDescriptor.PropertyType)

                            Else

                                DataColumn.DataType = PropertyDescriptor.PropertyType

                            End If

                            DataColumn.ExtendedProperties.Add("Precision", -1)
                            DataColumn.ExtendedProperties.Add("Scale", -1)
                            DataColumn.ExtendedProperties.Add("DateFormat", "")

                            If DataColumn.DataType Is GetType(String) Then

                                DataColumn.MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(PropertyDescriptor)

                            ElseIf DataColumn.DataType Is GetType(Decimal) Then

                                Precision = AdvantageFramework.BaseClasses.Entity.LoadPropertyPrecision(PropertyDescriptor)
                                Scale = AdvantageFramework.BaseClasses.Entity.LoadPropertyScale(PropertyDescriptor)

                                DataColumn.ExtendedProperties("Precision") = Precision
                                DataColumn.ExtendedProperties("Scale") = Scale

                            ElseIf DataColumn.DataType Is GetType(Date) Then

                                DataColumn.ExtendedProperties("DateFormat") = ImportTemplateDetail.DateFormat

                            End If

                            DataColumn.ExtendedProperties.Add("Start", ImportTemplateDetail.Start.GetValueOrDefault(0))
                            DataColumn.ExtendedProperties.Add("Length", ImportTemplateDetail.Length.GetValueOrDefault(0))
                            DataColumn.ExtendedProperties.Add("CSVPosition", ImportTemplateDetail.CSVPosition.GetValueOrDefault(0))
                            DataColumn.ExtendedProperties.Add("PropertyDescriptor", PropertyDescriptor)

                            If ClassType.UnderlyingSystemType Is GetType(AdvantageFramework.Database.Entities.AccountReceivableImportStaging) AndAlso
                                    PropertyDescriptor.Name = AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.InvoiceDate.ToString Then

                                DataColumn.ExtendedProperties("DateFormat") = ImportTemplateDetail.DateFormat

                            ElseIf ClassType.UnderlyingSystemType Is GetType(AdvantageFramework.Database.Entities.ImportAccountPayable) AndAlso
                                    PropertyDescriptor.Name = AdvantageFramework.Database.Entities.ImportAccountPayable.Properties.VendorCode.ToString AndAlso
                                    (ImportTemplateType = ImportTemplateTypes.AccountsPayable_Custom OrElse ImportTemplateType = ImportTemplateTypes.AccountsPayable_Generic) Then

                                DataColumn.MaxLength = -1

                            End If

                        End If

                    Next

                End If

            Catch ex As Exception
                DataTable = Nothing
            End Try

            CreateDataTableFromTemplate = DataTable

        End Function
        Private Sub LoadPropertyAttributes(ByVal Type As System.Type, ByVal PropertyName As String,
                                          ByRef IsEntityKey As Boolean, ByRef IsNullable As Boolean, ByRef IsRequired As Boolean,
                                          ByRef MaxLength As Integer, ByRef Precision As Integer, ByRef Scale As Integer,
                                          ByRef PropertyType As AdvantageFramework.BaseClasses.PropertyTypes, ByRef DisplayName As String)

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim ColumnAttribute As System.Data.Linq.Mapping.ColumnAttribute = Nothing
            Dim MaxLengthAttribute As System.ComponentModel.DataAnnotations.MaxLengthAttribute = Nothing

            Try

                PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(Type).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(PropDesc) PropDesc.Name = PropertyName).SingleOrDefault

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            If PropertyDescriptor IsNot Nothing Then

                If PropertyDescriptor.PropertyType IsNot GetType(System.Nullable) Then

                    Try

                        ColumnAttribute = PropertyDescriptor.Attributes.OfType(Of System.Data.Linq.Mapping.ColumnAttribute).SingleOrDefault

                    Catch ex As Exception
                        ColumnAttribute = Nothing
                    Finally

                        If ColumnAttribute IsNot Nothing Then

                            IsNullable = ColumnAttribute.CanBeNull

                            IsEntityKey = ColumnAttribute.IsPrimaryKey

                        End If

                    End Try

                End If

                If PropertyDescriptor.PropertyType Is GetType(String) Then

                    Try

                        MaxLengthAttribute = PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.DataAnnotations.MaxLengthAttribute).SingleOrDefault

                    Catch ex As Exception
                        MaxLengthAttribute = Nothing
                    Finally

                        If MaxLengthAttribute IsNot Nothing Then

                            MaxLength = MaxLengthAttribute.Length

                        End If

                    End Try

                End If

            End If

        End Sub
        Private Function CreateDataTableFromTemplate(ByVal ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail),
                                                     ByVal ClassType As System.Type, ImportTemplateType As ImportTemplateTypes) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim MaxLength As Long = 0
            Dim Precision As Long = 0
            Dim Scale As Long = 0
            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim ImportTemplateDetail As AdvantageFramework.Database.Entities.ImportTemplateDetail = Nothing
            Dim IsEntityKey As Boolean = False
            Dim IsNullable As Boolean = False
            Dim IsRequired As Boolean = False
            Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = Nothing
            Dim DisplayName As String = Nothing

            Try

                Try

                    PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(ClassType).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                Catch ex As Exception

                End Try

                If PropertyDescriptorsList IsNot Nothing Then

                    DataTable = New System.Data.DataTable

                    For Each ImportTemplateDetail In ImportTemplateDetails

                        Try

                            PropertyDescriptor = PropertyDescriptorsList.SingleOrDefault(Function(PropDesc) PropDesc.Name = ImportTemplateDetail.FieldName)

                        Catch ex As Exception
                            PropertyDescriptor = Nothing
                        End Try

                        If PropertyDescriptor IsNot Nothing Then

                            LoadPropertyAttributes(ClassType, PropertyDescriptor.Name, IsEntityKey, IsNullable, IsRequired, MaxLength, Precision, Scale, PropertyType, DisplayName)

                            DataColumn = DataTable.Columns.Add(PropertyDescriptor.Name)

                            If Nullable.GetUnderlyingType(PropertyDescriptor.PropertyType) IsNot Nothing Then

                                DataColumn.AllowDBNull = True
                                DataColumn.DataType = Nullable.GetUnderlyingType(PropertyDescriptor.PropertyType)

                            Else

                                DataColumn.DataType = PropertyDescriptor.PropertyType

                            End If

                            DataColumn.ExtendedProperties.Add("Precision", -1)
                            DataColumn.ExtendedProperties.Add("Scale", -1)
                            DataColumn.ExtendedProperties.Add("DateFormat", "")

                            If DataColumn.DataType Is GetType(String) Then

                                DataColumn.MaxLength = MaxLength

                            ElseIf DataColumn.DataType Is GetType(Decimal) Then

                                DataColumn.ExtendedProperties("Precision") = Precision
                                DataColumn.ExtendedProperties("Scale") = Scale

                            ElseIf DataColumn.DataType Is GetType(Date) Then

                                DataColumn.ExtendedProperties("DateFormat") = ImportTemplateDetail.DateFormat

                            End If

                            DataColumn.ExtendedProperties.Add("Start", ImportTemplateDetail.Start.GetValueOrDefault(0))
                            DataColumn.ExtendedProperties.Add("Length", ImportTemplateDetail.Length.GetValueOrDefault(0))
                            DataColumn.ExtendedProperties.Add("CSVPosition", ImportTemplateDetail.CSVPosition.GetValueOrDefault(0))
                            DataColumn.ExtendedProperties.Add("PropertyDescriptor", PropertyDescriptor)

                            If ClassType.UnderlyingSystemType Is GetType(AdvantageFramework.Database.Entities.AccountReceivableImportStaging) AndAlso
                                    PropertyDescriptor.Name = AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.InvoiceDate.ToString Then

                                DataColumn.ExtendedProperties("DateFormat") = ImportTemplateDetail.DateFormat

                            ElseIf ClassType.UnderlyingSystemType Is GetType(AdvantageFramework.Database.Entities.ImportAccountPayable) AndAlso
                                    PropertyDescriptor.Name = AdvantageFramework.Database.Entities.ImportAccountPayable.Properties.VendorCode.ToString AndAlso
                                    (ImportTemplateType = ImportTemplateTypes.AccountsPayable_Custom OrElse ImportTemplateType = ImportTemplateTypes.AccountsPayable_Generic) Then

                                DataColumn.MaxLength = -1

                            End If

                        End If

                    Next

                End If

            Catch ex As Exception
                DataTable = Nothing
            End Try

            CreateDataTableFromTemplate = DataTable

        End Function
        Public Function CreateBatchName(ImportTemplateName As String) As String

            'objects
            Dim BatchName As String = Nothing
            Dim BatchDateAndTime As String = Nothing

            BatchDateAndTime = Format(CInt(Now.Month), "0#") & Format(CInt(Now.Day), "0#") & Format(CInt(Now.Year), "000#") & Format(CInt(Now.Hour), "0#") & Format(CInt(Now.Minute), "0#") & Format(CInt(Now.Second), "0#")

            If BatchDateAndTime.Length + ImportTemplateName.Length + 1 > 50 Then

                ImportTemplateName = ImportTemplateName.Substring(0, 50 - BatchDateAndTime.Length - 1)

            End If

            BatchName = ImportTemplateName & "_" & BatchDateAndTime

            CreateBatchName = BatchName

        End Function
        Public Function ImportFileByImportTemplate(ByVal Session As AdvantageFramework.Security.Session, ByVal ImportTemplateID As Short,
                                                   ByVal Files() As String, ByVal AutoTrimOverflowData As Boolean, ByVal IsFirstRowColumnHeaders As Boolean,
                                                   ByVal BankCode As String, ByRef BatchName As String,
                                                   ByRef FailedLines As Generic.Dictionary(Of Integer, String),
                                                   Optional ByVal EventLog As System.Diagnostics.EventLog = Nothing) As Boolean

            'objects
            Dim FileImported As Boolean = True
            Dim ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail) = Nothing
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing
            Dim BatchDateAndTime As String = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, ImportTemplateID)

                        If ImportTemplate IsNot Nothing Then

                            ImportTemplateDetails = ImportTemplate.ImportTemplateDetails.ToList

                            If BatchName Is Nothing Then

                                BatchName = CreateBatchName(ImportTemplate.Name)

                            End If

                            Select Case ImportTemplate.FileType

                                Case AdvantageFramework.Importing.FileTypes.CSV

                                    ImportCSVFileFromTemplate(Session, DbContext, DataContext, ImportTemplate, ImportTemplateDetails, Files, IsFirstRowColumnHeaders,
                                                              BatchName, AutoTrimOverflowData, BankCode, FailedLines, EventLog)

                                Case AdvantageFramework.Importing.FileTypes.Fixed

                                    ImportFixedFileFromTemplate(Session, DbContext, DataContext, ImportTemplate, ImportTemplateDetails, Files,
                                                                IsFirstRowColumnHeaders, BatchName, AutoTrimOverflowData, BankCode, FailedLines)

                            End Select

                            If ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic OrElse
                                    ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast OrElse
                                    ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedInternet OrElse
                                    ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedPrint OrElse
                                    ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Custom OrElse
                                    ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_4AsBroadcast Then

                                ValidateAccountsPayableBatch(Session, BatchName)

                                UpdateAccountsPayableBatchInvoiceDescription(Session, BatchName, AdvantageFramework.Agency.GetOptionAPImportDefaultInvoiceDescription(DbContext))

                            End If

                        End If

                    End Using

                End Using

            Catch ex As Exception
                FileImported = False
            Finally
                ImportFileByImportTemplate = FileImported
            End Try

        End Function
        Private Function GetFileLines(ByVal File As String) As String()

            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim FileLines() As String = Nothing

            Try

                StreamReader = New System.IO.StreamReader(File)

            Catch ex As Exception
                StreamReader = Nothing
            Finally

                If StreamReader IsNot Nothing Then

                    FileLines = GetFileLines(StreamReader)

                End If

            End Try

            GetFileLines = FileLines

        End Function
        Public Function GetFileLines(ByVal StreamReader As System.IO.StreamReader) As String()

            Dim StringList As Generic.List(Of String) = Nothing
            Dim FileLines() As String = Nothing

            If StreamReader IsNot Nothing Then

                StringList = New Generic.List(Of String)

                Do While StreamReader.Peek <> -1

                    StringList.Add(StreamReader.ReadLine())

                Loop

                FileLines = StringList.ToArray

                Try

                    StreamReader.Close()
                    StreamReader.Dispose()

                Catch ex As Exception

                End Try

            End If

            GetFileLines = FileLines

        End Function
        Private Sub ImportCSVFileFromTemplate(ByVal Session As AdvantageFramework.Security.Session,
                                              ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal DataContext As AdvantageFramework.Database.DataContext,
                                              ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                              ByVal ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail),
                                              ByVal Files() As String, ByVal IsFirstRowColumnHeaders As Boolean,
                                              ByVal BatchName As String, ByVal AutoTrimOverFlowData As Boolean,
                                              ByVal BankCode As String, ByRef FailedLines As Generic.Dictionary(Of Integer, String),
                                              Optional ByVal EventLog As System.Diagnostics.EventLog = Nothing)

            'objects
            Dim TextFieldParser As FileIO.TextFieldParser = Nothing
            Dim FileLineData() As String = Nothing
            Dim FileLineCounter As Integer = 0
            Dim Imported As Boolean = True
            Dim ImportAccountPayables As Hashtable = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataTableGL As System.Data.DataTable = Nothing
            Dim DataTableJob As System.Data.DataTable = Nothing
            Dim DataTableMedia As System.Data.DataTable = Nothing
            Dim DataTableCRDetail As System.Data.DataTable = Nothing
            Dim DataTableJEDetail As System.Data.DataTable = Nothing
            Dim Remainder As Integer = 0
            Dim NumberOfLines As Integer = 0
            Dim FileLineStarter As Integer = 0
            Dim FileLines() As String = Nothing
            Dim FileCounter As Integer = 0
            Dim ExistingImportAccountPayableList As Generic.List(Of AdvantageFramework.Database.Entities.ImportAccountPayable) = Nothing
            Dim ImportCashReceipts As Hashtable = Nothing
            Dim ImportTemplateExcludeList As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateExclude) = Nothing
            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim ImportJournalEntries As Hashtable = Nothing
            Dim ClientCrossReferences As Generic.List(Of AdvantageFramework.Database.Entities.ClientCrossReference) = Nothing
            Dim GeneralLedgerCrossReferences As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerCrossReference) = Nothing
            Dim DocumentFiles As String() = Nothing
            Dim ImportDocument As String = Nothing

            ImportTemplateExcludeList = AdvantageFramework.Database.Procedures.ImportTemplateExclude.LoadByImportTemplateID(DataContext, ImportTemplate.ID).ToList

            Select Case ImportTemplate.Type

                Case AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_CreditCard,
                     AdvantageFramework.Importing.Methods.ImportTemplateTypes.ExpenseReport_NonCreditCard

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportCreditCardStaging), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_Default

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportClearedChecksStaging), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic,
                     AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Custom

                    ImportAccountPayables = New Hashtable

                    ExistingImportAccountPayableList = AdvantageFramework.Database.Procedures.ImportAccountPayable.LoadByBatchName(DbContext, BatchName).Include("ImportAccountPayableGLs").Include("ImportAccountPayableJobs").Include("ImportAccountPayableMedias").ToList

                    For Each IAP In ExistingImportAccountPayableList

                        ImportAccountPayables.Add(IAP.VendorCode & "|" & IAP.InvoiceNumber, IAP)

                    Next

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportAccountPayable), ImportTemplate.Type)
                    DataTableGL = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportAccountPayableGL), ImportTemplate.Type)
                    DataTableJob = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportAccountPayableJob), ImportTemplate.Type)
                    DataTableMedia = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportAccountPayableMedia), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.Client_Default

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportClientStaging), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.ClientContact_Default

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportClientContactStaging), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.Division_Default

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportDivisionStaging), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.Product_Default

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportProductStaging), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Default,
                     AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Custom

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.AccountReceivableImportStaging), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.Function_Default

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportFunctionStaging), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.ChartOfAccounts_Default

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.DigitalResults_Default

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportDigitalResultsStaging), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.AvalaraTaxCode_Default

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.CashReceipt_Generic

                    ImportCashReceipts = New Hashtable

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportCashReceipt), ImportTemplate.Type)
                    DataTableCRDetail = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportCashReceiptDetail), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.PTO_Default

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, GetType(AdvantageFramework.Database.Entities.ImportPTOStaging), ImportTemplate.Type)

                    PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.ImportPTOStaging)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                Case AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_Default

                    ImportJournalEntries = New Hashtable

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, GetType(AdvantageFramework.Database.Entities.ImportJournalEntry), ImportTemplate.Type)
                    DataTableJEDetail = CreateDataTableFromTemplate(ImportTemplateDetails, GetType(AdvantageFramework.Database.Entities.ImportJournalEntryDetail), ImportTemplate.Type)

                    If ImportTemplate.RecordSourceID.HasValue Then

                        ClientCrossReferences = AdvantageFramework.Database.Procedures.ClientCrossReference.LoadByRecordSourceID(DbContext, ImportTemplate.RecordSourceID.Value).ToList
                        GeneralLedgerCrossReferences = AdvantageFramework.Database.Procedures.GeneralLedgerCrossReference.LoadByRecordSourceID(DbContext, ImportTemplate.RecordSourceID.Value).ToList

                    End If

                Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_4AsBroadcast

                    DocumentFiles = Files.Where(Function(f) f.ToUpper.EndsWith(".PDF")).ToArray
                    Files = Files.Where(Function(f) f.ToUpper.EndsWith(".PDF") = False).ToArray

                Case AdvantageFramework.Importing.ImportTemplateTypes.Employee_Hours

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, GetType(AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging), ImportTemplate.Type)

                    PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

            End Select

            If IsFirstRowColumnHeaders Then

                FileLineStarter = 1

            End If

            RaiseEvent SetupOverallImportingProgressEvent(0, UBound(Files) + 1, 0)

            For Each File In Files

                Imported = True

                FileLineCounter = 0

                FileLines = GetFileLines(File.ToString)

                NumberOfLines = FileLines.Count

                If NumberOfLines > 0 Then

                    If ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_4AsBroadcast Then

                        ImportDocument = Nothing

                        If DocumentFiles IsNot Nothing Then

                            ImportDocument = DocumentFiles.Where(Function(f) f.StartsWith(File)).FirstOrDefault

                        End If

                        Imported = ImportBroadcast4AStaging(Session, DbContext, DataContext, ImportTemplate, File, BatchName, AutoTrimOverFlowData, ImportDocument, EventLog)

                    Else

                        TextFieldParser = New FileIO.TextFieldParser(File.ToString)

                        TextFieldParser.TextFieldType = FileIO.FieldType.Delimited
                        TextFieldParser.Delimiters = {","}
                        TextFieldParser.HasFieldsEnclosedInQuotes = True

                        RaiseEvent SetupImportingProgressEvent(0, If(NumberOfLines - FileLineStarter <= 0, 1, NumberOfLines - FileLineStarter), 0)

                        Do While Not TextFieldParser.EndOfData

                            Try

                                FileLineData = TextFieldParser.ReadFields

                                If FileLineCounter >= FileLineStarter AndAlso FileLineData.Count > 0 Then

                                    Select Case ImportTemplate.Type

                                        Case AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_CreditCard,
                                         AdvantageFramework.Importing.Methods.ImportTemplateTypes.ExpenseReport_NonCreditCard

                                            Imported = CreateImportCreditCardStaging(Session, DbContext, ImportTemplate, ImportTemplateDetails, FileLineData, BatchName, AutoTrimOverFlowData, DataTable)

                                        Case AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_Default

                                            Imported = CreateImportClearedChecksStaging(Session, DbContext, ImportTemplate, ImportTemplateDetails, FileLineData, File.ToString, BatchName, AutoTrimOverFlowData, BankCode, DataTable)

                                        Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic,
                                         AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Custom

                                            Imported = CreateImportAccountsPayableStaging(Session, DbContext, ImportTemplate, ImportTemplateDetails, FileLineData, BatchName, AutoTrimOverFlowData, ImportAccountPayables, DataTable, DataTableGL, DataTableJob, DataTableMedia, Nothing, ExistingImportAccountPayableList)

                                        'Math.DivRem(FileLineCounter, 1000, Remainder)

                                        'If FileLineCounter <> 0 AndAlso Remainder = 0 Then

                                        '	SaveAccountPayable(DbContext, FailedLines)

                                        'End If

                                        Case AdvantageFramework.Importing.ImportTemplateTypes.Client_Default

                                            Imported = CreateImportClientStaging(Session, DbContext, ImportTemplate, ImportTemplateDetails, FileLineData, BatchName, AutoTrimOverFlowData, DataTable)

                                        Case AdvantageFramework.Importing.ImportTemplateTypes.ClientContact_Default

                                            Imported = CreateImportClientContactStaging(Session, DbContext, ImportTemplate, ImportTemplateDetails, FileLineData, BatchName, AutoTrimOverFlowData, DataTable)

                                        Case AdvantageFramework.Importing.ImportTemplateTypes.Division_Default

                                            Imported = CreateImportDivisionStaging(Session, DbContext, ImportTemplate, ImportTemplateDetails, FileLineData, BatchName, AutoTrimOverFlowData, DataTable)

                                        Case AdvantageFramework.Importing.ImportTemplateTypes.Product_Default

                                            Imported = CreateImportProductStaging(Session, DbContext, ImportTemplate, ImportTemplateDetails, FileLineData, BatchName, AutoTrimOverFlowData, DataTable)

                                        Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Default,
                                             AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Custom

                                            Imported = CreateImportAccountsReceivableStaging(Session, DbContext, ImportTemplate, ImportTemplateDetails, FileLineData, BatchName, AutoTrimOverFlowData, DataTable)

                                        Case AdvantageFramework.Importing.ImportTemplateTypes.Function_Default

                                            Imported = CreateImportFunctionStaging(Session, DbContext, ImportTemplate, ImportTemplateDetails, FileLineData, BatchName, AutoTrimOverFlowData, DataTable)

                                        Case AdvantageFramework.Importing.ImportTemplateTypes.ChartOfAccounts_Default

                                            Imported = CreateImportGeneralLedgerStaging(Session, DbContext, ImportTemplate, ImportTemplateDetails, FileLineData, BatchName, AutoTrimOverFlowData, DataTable)

                                        Case AdvantageFramework.Importing.ImportTemplateTypes.DigitalResults_Default

                                            Imported = CreateImportDigitalResultsStaging(Session, DbContext, DataContext, ImportTemplate, ImportTemplateDetails, FileLineData, BatchName, AutoTrimOverFlowData, DataTable)

                                        Case AdvantageFramework.Importing.ImportTemplateTypes.AvalaraTaxCode_Default

                                            Imported = CreateImportAvalaraTaxStaging(Session, DataContext, ImportTemplate, ImportTemplateDetails, FileLineData, BatchName, AutoTrimOverFlowData, DataTable)

                                        Case AdvantageFramework.Importing.ImportTemplateTypes.CashReceipt_Generic

                                            Imported = CreateImportCashReceiptStaging(Session, DataContext, DbContext, ImportTemplate, ImportTemplateDetails, FileLineData, BatchName, AutoTrimOverFlowData, ImportCashReceipts, DataTable, DataTableCRDetail)

                                        Case AdvantageFramework.Importing.ImportTemplateTypes.PTO_Default

                                            Imported = CreateImportPTOStaging(Session, DbContext, DataContext, ImportTemplate, ImportTemplateDetails, FileLineData, BatchName, AutoTrimOverFlowData, DataTable, AdvantageFramework.Importing.FileTypes.CSV, ImportTemplateExcludeList, PropertyDescriptorsList)

                                        Case AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_Default

                                            Imported = CreateImportJournalEntryStaging(Session, DbContext, ImportTemplate, ImportTemplateDetails, FileLineData, BatchName, AutoTrimOverFlowData, ImportJournalEntries, DataTable, DataTableJEDetail, ClientCrossReferences, GeneralLedgerCrossReferences)

                                            Math.DivRem(FileLineCounter, 1000, Remainder)

                                            If FileLineCounter <> 0 AndAlso Remainder = 0 Then

                                                SaveJournalEntry(DbContext, FailedLines)

                                            End If

                                        Case AdvantageFramework.Importing.ImportTemplateTypes.Employee_Hours

                                            Imported = CreateImportEmployeeHoursStaging(Session, DbContext, DataContext, ImportTemplate, ImportTemplateDetails, FileLineData, BatchName, AutoTrimOverFlowData, DataTable, AdvantageFramework.Importing.FileTypes.CSV, ImportTemplateExcludeList, PropertyDescriptorsList)

                                    End Select

                                End If

                                If Imported = False Then

                                    If FailedLines Is Nothing Then

                                        FailedLines = New Generic.Dictionary(Of Integer, String)

                                    End If

                                    FailedLines.Add(FailedLines.Count + 1, String.Join(",", FileLineData))

                                End If

                                FileLineCounter += 1

                                Math.DivRem(FileLineCounter, 100, Remainder)

                                If Remainder = 0 Then

                                    RaiseEvent ImportingProgressUpdateEvent(FileLineCounter)

                                End If

                            Catch ex As Exception
                                TextFieldParser.Close()
                                TextFieldParser.Dispose()
                                Throw ex
                            End Try

                        Loop

                        RaiseEvent ImportingProgressUpdateEvent(FileLineCounter)

                        Select Case ImportTemplate.Type

                            Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic,
                             AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Custom

                                SaveAccountPayable(DbContext, FailedLines)

                            Case AdvantageFramework.Importing.ImportTemplateTypes.DigitalResults_Default

                                AutoResolveDigitalResultsData(DbContext, BatchName)

                            Case AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_Default

                                SaveJournalEntry(DbContext, FailedLines)

                        End Select

                        TextFieldParser.Close()
                        TextFieldParser.Dispose()

                    End If

                End If

                AdvantageFramework.Importing.RenameFileAfterImport(File, Session.UserCode, BatchName)

                If Not String.IsNullOrWhiteSpace(ImportDocument) Then

                    AdvantageFramework.Importing.RenameFileAfterImport(ImportDocument, Session.UserCode, BatchName)

                End If

                FileCounter += 1

                RaiseEvent OverallImportingProgressUpdateEvent(FileCounter)

            Next

        End Sub
        Private Sub ImportFixedFileFromTemplate(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                ByVal ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail),
                                                ByVal Files() As String, ByVal IsFirstRowColumnHeaders As Boolean, ByVal BatchName As String,
                                                ByVal AutoTrimOverflowData As Boolean,
                                                ByVal BankCode As String,
                                                ByRef FailedLines As Generic.Dictionary(Of Integer, String))

            'objects
            Dim FileLineCounter As Integer = 0
            Dim Imported As Boolean = True
            Dim ImportAccountPayables As Hashtable = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataTableGL As System.Data.DataTable = Nothing
            Dim DataTableJob As System.Data.DataTable = Nothing
            Dim DataTableMedia As System.Data.DataTable = Nothing
            Dim Remainder As Integer = 0
            Dim NumberOfLines As Integer = 0
            Dim FileLineStarter As Integer = 0
            Dim FileLines() As String = Nothing
            Dim FileCounter As Integer = 0
            Dim StrataBroadcastDetailFileLines() As String = Nothing
            Dim ExistingImportAccountPayableList As Generic.List(Of AdvantageFramework.Database.Entities.ImportAccountPayable) = Nothing
            Dim ImportTemplateExcludeList As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateExclude) = Nothing
            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            ImportTemplateExcludeList = AdvantageFramework.Database.Procedures.ImportTemplateExclude.LoadByImportTemplateID(DataContext, ImportTemplate.ID).ToList

            Select Case ImportTemplate.Type

                Case AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_CreditCard,
                     AdvantageFramework.Importing.Methods.ImportTemplateTypes.ExpenseReport_NonCreditCard

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportCreditCardStaging), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_Default

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportClearedChecksStaging), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic,
                     AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedInternet,
                     AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedPrint,
                     AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast

                    ImportAccountPayables = New Hashtable

                    ExistingImportAccountPayableList = AdvantageFramework.Database.Procedures.ImportAccountPayable.LoadByBatchName(DbContext, BatchName).ToList

                    For Each IAP In ExistingImportAccountPayableList

                        ImportAccountPayables.Add(IAP.VendorCode & "|" & IAP.InvoiceNumber, IAP)

                    Next

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportAccountPayable), ImportTemplate.Type)
                    DataTableGL = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportAccountPayableGL), ImportTemplate.Type)
                    DataTableJob = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportAccountPayableJob), ImportTemplate.Type)
                    DataTableMedia = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportAccountPayableMedia), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.Client_Default

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportClientStaging), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.ClientContact_Default

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportClientContactStaging), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.Division_Default

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportDivisionStaging), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.Product_Default

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportProductStaging), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Default

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.AccountReceivableImportStaging), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.Function_Default

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportFunctionStaging), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.ChartOfAccounts_Default

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging), ImportTemplate.Type)

                Case AdvantageFramework.Importing.ImportTemplateTypes.PTO_Default

                    DataTable = CreateDataTableFromTemplate(ImportTemplateDetails, DbContext, GetType(AdvantageFramework.Database.Entities.ImportPTOStaging), ImportTemplate.Type)

                    PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.ImportPTOStaging)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

            End Select

            If IsFirstRowColumnHeaders Then

                FileLineStarter = 1

            End If

            RaiseEvent SetupOverallImportingProgressEvent(0, UBound(Files) + 1, 0)

            For Each File In Files

                Imported = True

                FileLineCounter = 0

                FileLines = GetFileLines(File.ToString)

                NumberOfLines = FileLines.Count

                If ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.CashReceipt_Custom AndAlso ImportTemplate.IsSystemTemplate AndAlso ImportTemplate.Name = "Custom Fixed" AndAlso
                        NumberOfLines > 0 Then

                    Imported = CreateImportCashReceiptStagingFromLockboxFile(DbContext, DataContext, ImportTemplate, FileLines, BatchName)

                ElseIf NumberOfLines > 0 Then

                    RaiseEvent SetupImportingProgressEvent(0, If(FileLines.Count - FileLineStarter <= 0, 1, NumberOfLines - FileLineStarter), 0)

                    For Each FileLine In FileLines

                        If FileLineCounter >= FileLineStarter Then

                            If String.IsNullOrWhiteSpace(FileLine) = False Then

                                Select Case ImportTemplate.Type

                                    Case Methods.ImportTemplateTypes.ExpenseReport_CreditCard, Methods.ImportTemplateTypes.ExpenseReport_NonCreditCard

                                        Imported = CreateImportCreditCardStaging(Session, DbContext, ImportTemplate, ImportTemplateDetails, FileLine, BatchName, AutoTrimOverflowData, DataTable)

                                    Case AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_Default

                                        Imported = CreateImportClearedChecksStaging(Session, DbContext, ImportTemplate, ImportTemplateDetails, FileLine, File, BatchName, AutoTrimOverflowData, BankCode, DataTable)

                                    Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic,
                                         AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedInternet,
                                         AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedPrint,
                                         AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast

                                        If ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast Then

                                            StrataBroadcastDetailFileLines = GetFileLines(Replace(File.ToUpper, ".V51", ".C51"))

                                        End If

                                        Imported = CreateImportAccountsPayableStaging(Session, DbContext, ImportTemplate, ImportTemplateDetails, FileLine, BatchName, AutoTrimOverflowData, ImportAccountPayables, DataTable, DataTableGL, DataTableJob, DataTableMedia, StrataBroadcastDetailFileLines, ExistingImportAccountPayableList)

                                        'Math.DivRem(FileLineCounter, 1000, Remainder)

                                        'If FileLineCounter <> 0 AndAlso Remainder = 0 Then

                                        '	SaveAccountPayable(DbContext, FailedLines)

                                        'End If

                                    Case AdvantageFramework.Importing.ImportTemplateTypes.Client_Default

                                        Imported = CreateImportClientStaging(Session, DbContext, ImportTemplate, ImportTemplateDetails, FileLine, BatchName, AutoTrimOverflowData, DataTable)

                                    Case AdvantageFramework.Importing.ImportTemplateTypes.ClientContact_Default

                                        Imported = CreateImportClientContactStaging(Session, DbContext, ImportTemplate, ImportTemplateDetails, FileLine, BatchName, AutoTrimOverflowData, DataTable)

                                    Case AdvantageFramework.Importing.ImportTemplateTypes.Division_Default

                                        Imported = CreateImportDivisionStaging(Session, DbContext, ImportTemplate, ImportTemplateDetails, FileLine, BatchName, AutoTrimOverflowData, DataTable)

                                    Case AdvantageFramework.Importing.ImportTemplateTypes.Product_Default

                                        Imported = CreateImportProductStaging(Session, DbContext, ImportTemplate, ImportTemplateDetails, FileLine, BatchName, AutoTrimOverflowData, DataTable)

                                    Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Default

                                        Imported = CreateImportAccountsReceivableStaging(Session, DbContext, ImportTemplate, ImportTemplateDetails, FileLine, BatchName, AutoTrimOverflowData, DataTable)

                                    Case AdvantageFramework.Importing.ImportTemplateTypes.Function_Default

                                        Imported = CreateImportFunctionStaging(Session, DbContext, ImportTemplate, ImportTemplateDetails, FileLine, BatchName, AutoTrimOverflowData, DataTable)

                                    Case AdvantageFramework.Importing.ImportTemplateTypes.ChartOfAccounts_Default

                                        Imported = CreateImportGeneralLedgerStaging(Session, DbContext, ImportTemplate, ImportTemplateDetails, FileLine, BatchName, AutoTrimOverflowData, DataTable)

                                    Case AdvantageFramework.Importing.ImportTemplateTypes.PTO_Default

                                        Imported = CreateImportPTOStaging(Session, DbContext, DataContext, ImportTemplate, ImportTemplateDetails, FileLine, BatchName, AutoTrimOverflowData, DataTable, AdvantageFramework.Importing.FileTypes.Fixed, ImportTemplateExcludeList, PropertyDescriptorsList)

                                End Select

                                If Imported = False Then

                                    If FailedLines Is Nothing Then

                                        FailedLines = New Generic.Dictionary(Of Integer, String)

                                    End If

                                    FailedLines.Add(FailedLines.Count + 1, FileLine)

                                End If

                            End If

                        End If

                        FileLineCounter += 1

                        Math.DivRem(FileLineCounter, 100, Remainder)

                        If Remainder = 0 Then

                            RaiseEvent ImportingProgressUpdateEvent(FileLineCounter)

                        End If

                    Next

                    RaiseEvent ImportingProgressUpdateEvent(FileLineCounter)

                    Select Case ImportTemplate.Type

                        Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic,
                             AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedInternet,
                             AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedPrint,
                             AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast

                            SaveAccountPayable(DbContext, FailedLines)

                    End Select

                End If

                AdvantageFramework.Importing.RenameFileAfterImport(File, Session.UserCode, BatchName)

                If ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast Then

                    AdvantageFramework.Importing.RenameFileAfterImport(Replace(File.ToUpper, ".V51", ".C51"), Session.UserCode, BatchName)

                End If

                FileCounter += 1

                RaiseEvent OverallImportingProgressUpdateEvent(FileCounter)

            Next

        End Sub
        'Public Function ImportFileByImportTemplate(ByVal Session As AdvantageFramework.Security.Session, ByVal ImportTemplateID As Short, _
        '                                           ByVal File As String, ByVal AutoTrimOverflowData As Boolean, ByVal IsFirstRowColumnHeaders As Boolean,
        '                                           Optional ByVal BankCode As String = Nothing, Optional ByRef BatchName As String = Nothing) As Boolean

        '    ''objects
        '    'Dim FileImported As Boolean = True
        '    'Dim StreamReader As System.IO.StreamReader = Nothing
        '    'Dim FileLines() As String = Nothing
        '    'Dim FileLineData() As String = Nothing
        '    'Dim FileLineCounter As Integer = 0
        '    'Dim FileLineStarter As Integer = 0
        '    'Dim ImportCreditCardStaging As AdvantageFramework.Database.Entities.ImportCreditCardStaging = Nothing
        '    'Dim ImportClearedChecksStaging As AdvantageFramework.Database.Entities.ImportClearedChecksStaging = Nothing
        '    'Dim ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail) = Nothing
        '    'Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing
        '    'Dim TextFieldParser As FileIO.TextFieldParser = Nothing
        '    'Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
        '    'Dim FileInfo As System.IO.FileInfo = Nothing
        '    'Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
        '    'Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
        '    'Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
        '    'Dim FailedLines As Generic.List(Of String) = New Generic.List(Of String)

        '    'Try

        '    '    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

        '    '        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, ImportTemplateID)

        '    '        If ImportTemplate IsNot Nothing Then

        '    '            ImportTemplateDetails = ImportTemplate.ImportTemplateDetails.ToList

        '    '            Try

        '    '                StreamReader = New System.IO.StreamReader(File)

        '    '            Catch ex As Exception
        '    '                StreamReader = Nothing
        '    '            Finally

        '    '                If StreamReader IsNot Nothing Then

        '    '                    FileLines = StreamReader.ReadToEnd.Split(vbCrLf)

        '    '                    StreamReader.Close()
        '    '                    StreamReader.Dispose()

        '    '                End If

        '    '            End Try

        '    '            If FileLines.Count > 0 Then

        '    '                FileInfo = New System.IO.FileInfo(File)

        '    '                BatchName = FileInfo.Name.Replace(FileInfo.Extension, "") & "_" & Format(CInt(Now.Month), "0#") & Format(CInt(Now.Day), "0#") & Format(CInt(Now.Year), "000#") & Format(CInt(Now.Hour), "0#") & Format(CInt(Now.Minute), "0#") & Format(CInt(Now.Second), "0#")

        '    '                If ImportTemplate.FileType = AdvantageFramework.Importing.FileTypes.CSV Then

        '    '                    TextFieldParser = New FileIO.TextFieldParser(File)

        '    '                    TextFieldParser.TextFieldType = FileIO.FieldType.Delimited
        '    '                    TextFieldParser.Delimiters = New String() {","}
        '    '                    TextFieldParser.HasFieldsEnclosedInQuotes = True

        '    '                    If IsFirstRowColumnHeaders Then

        '    '                        FileLineStarter = 1

        '    '                    End If

        '    '                    RaiseEvent SetupImportingProgressEvent(0, FileLines.Count - 1 - FileLineStarter, 0)

        '    '                    If ImportTemplate.Type = Methods.ImportTemplateTypes.ExpenseReport_CreditCard OrElse _
        '    '                            ImportTemplate.Type = Methods.ImportTemplateTypes.ExpenseReport_NonCreditCard Then

        '    '                        Employees = AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).ToList

        '    '                    End If

        '    '                    Do While Not TextFieldParser.EndOfData

        '    '                        Try

        '    '                            FileLineData = TextFieldParser.ReadFields

        '    '                            If FileLineCounter >= FileLineStarter AndAlso FileLineData.Count > 0 Then

        '    '                                If ImportTemplate.Type = Methods.ImportTemplateTypes.ExpenseReport_CreditCard OrElse _
        '    '                                        ImportTemplate.Type = Methods.ImportTemplateTypes.ExpenseReport_NonCreditCard Then

        '    '                                    ImportCreditCardStaging = New AdvantageFramework.Database.Entities.ImportCreditCardStaging

        '    '                                    ImportCreditCardStaging.DbContext = DbContext
        '    '                                    ImportCreditCardStaging.BatchName = BatchName

        '    '                                    CreateEntityFromCSVTemplate(Session, FileLineData, ImportTemplateDetails, ImportCreditCardStaging, AutoTrimOverflowData)

        '    '                                    ScrubDataByPropertyType(DbContext, ImportCreditCardStaging)

        '    '                                    If String.IsNullOrEmpty(ImportCreditCardStaging.EmployeeCode) = True AndAlso _
        '    '                                       (String.IsNullOrEmpty(ImportCreditCardStaging.EmployeeFirstName) = False OrElse _
        '    '                                        String.IsNullOrEmpty(ImportCreditCardStaging.EmployeeLastName) = False) Then

        '    '                                        Try

        '    '                                            ImportCreditCardStaging.EmployeeCode = (From Employee In Employees _
        '    '                                                                                    Where Employee.LastName.ToUpper = If(String.IsNullOrEmpty(ImportCreditCardStaging.EmployeeLastName), Employee.LastName, ImportCreditCardStaging.EmployeeLastName).ToUpper AndAlso _
        '    '                                                                                          Employee.FirstName.ToUpper = If(String.IsNullOrEmpty(ImportCreditCardStaging.EmployeeFirstName), Employee.LastName, ImportCreditCardStaging.EmployeeFirstName).ToUpper _
        '    '                                                                                    Select Employee.Code).FirstOrDefault

        '    '                                        Catch ex As Exception
        '    '                                            ImportCreditCardStaging.EmployeeCode = Nothing
        '    '                                        End Try

        '    '                                    End If

        '    '                                    If String.IsNullOrEmpty(ImportCreditCardStaging.EmployeeCode) AndAlso String.IsNullOrEmpty(ImportCreditCardStaging.AccountNumber) = False Then

        '    '                                        Try

        '    '                                            ImportCreditCardStaging.EmployeeCode = (From Employee In Employees _
        '    '                                                                                    Where Employee.AccountNumber.ToUpper = ImportCreditCardStaging.AccountNumber.ToUpper _
        '    '                                                                                    Select Employee.Code).FirstOrDefault

        '    '                                        Catch ex As Exception
        '    '                                            ImportCreditCardStaging.EmployeeCode = Nothing
        '    '                                        End Try

        '    '                                    End If

        '    '                                    If ImportCreditCardStaging.JobNumber.HasValue Then

        '    '                                        Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, ImportCreditCardStaging.JobNumber)

        '    '                                        If Job IsNot Nothing Then

        '    '                                            ImportCreditCardStaging.ClientCode = Job.ClientCode
        '    '                                            ImportCreditCardStaging.DivisionCode = Job.DivisionCode
        '    '                                            ImportCreditCardStaging.ProductCode = Job.ProductCode

        '    '                                            If Job.JobComponents.Count = 1 Then

        '    '                                                ImportCreditCardStaging.JobComponentNumber = Job.JobComponents.SingleOrDefault.Number
        '    '                                                ImportCreditCardStaging.JobComponentID = Job.JobComponents.SingleOrDefault.ID

        '    '                                            ElseIf ImportCreditCardStaging.JobComponentNumber.HasValue Then

        '    '                                                Try
        '    '                                                    ' get the job component ID - it is used in the grid w/ auto filtering but not allowed as a field to import
        '    '                                                    ImportCreditCardStaging.JobComponentID = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Job.Number, ImportCreditCardStaging.JobComponentNumber).ID

        '    '                                                Catch ex As Exception
        '    '                                                    ImportCreditCardStaging.JobComponentID = Nothing
        '    '                                                    ImportCreditCardStaging.JobComponentNumber = Nothing
        '    '                                                End Try

        '    '                                            End If

        '    '                                        End If

        '    '                                    Else

        '    '                                        ImportCreditCardStaging.JobComponentNumber = Nothing ' can't have a job component w/o job
        '    '                                        ImportCreditCardStaging.JobComponentID = Nothing ' can't have a job component w/o job

        '    '                                        If String.IsNullOrEmpty(ImportCreditCardStaging.ClientCode) = False Then

        '    '                                            If String.IsNullOrEmpty(ImportCreditCardStaging.DivisionCode) Then ' fill in division only if empty & single active division

        '    '                                                Try

        '    '                                                    ImportCreditCardStaging.DivisionCode = (From Entity In AdvantageFramework.Database.Procedures.Division.Load(DbContext) _
        '    '                                                                                            Where Entity.IsActive = 1 AndAlso _
        '    '                                                                                                  Entity.ClientCode.ToUpper = ImportCreditCardStaging.ClientCode.ToUpper _
        '    '                                                                                            Select Entity.Code).SingleOrDefault

        '    '                                                Catch ex As Exception
        '    '                                                    ImportCreditCardStaging.DivisionCode = Nothing
        '    '                                                End Try

        '    '                                            End If

        '    '                                            If String.IsNullOrEmpty(ImportCreditCardStaging.DivisionCode) = False AndAlso _
        '    '                                               String.IsNullOrEmpty(ImportCreditCardStaging.ProductCode) Then ' fill in product only if empty & single active product

        '    '                                                Try

        '    '                                                    ImportCreditCardStaging.ProductCode = (From Entity In AdvantageFramework.Database.Procedures.Product.Load(DbContext) _
        '    '                                                                                           Where Entity.IsActive = 1 AndAlso _
        '    '                                                                                                 Entity.DivisionCode.ToUpper = ImportCreditCardStaging.DivisionCode.ToUpper AndAlso _
        '    '                                                                                                 Entity.ClientCode.ToUpper = ImportCreditCardStaging.ClientCode.ToUpper
        '    '                                                                                           Select Entity.Code).SingleOrDefault

        '    '                                                Catch ex As Exception
        '    '                                                    ImportCreditCardStaging.ProductCode = Nothing
        '    '                                                End Try

        '    '                                            End If

        '    '                                        End If

        '    '                                    End If

        '    '                                    If ImportTemplate.Type = Methods.ImportTemplateTypes.ExpenseReport_CreditCard Then

        '    '                                        ImportCreditCardStaging.CreditCardFlag = True

        '    '                                    Else

        '    '                                        ImportCreditCardStaging.CreditCardFlag = False

        '    '                                    End If

        '    '                                    If ImportCreditCardStaging.ExpenseReportDate.HasValue = False Then

        '    '                                        ImportCreditCardStaging.ExpenseReportDate = System.DateTime.Today

        '    '                                    End If

        '    '                                    If ImportCreditCardStaging.ItemDate.HasValue = False Then

        '    '                                        ImportCreditCardStaging.ItemDate = System.DateTime.Today

        '    '                                    End If

        '    '                                    ImportCreditCardStaging.DbContext = DbContext

        '    '                                    If AdvantageFramework.Database.Procedures.ImportCreditCardStaging.Insert(DbContext, ImportCreditCardStaging) = False Then

        '    '                                        Try

        '    '                                            FailedLines.Add("Line:" & FileLineCounter.ToString & vbTab & "Data: " & String.Join(",", FileLineData))

        '    '                                        Catch ex As Exception

        '    '                                        End Try

        '    '                                        Try

        '    '                                            DbContext.ImportCreditCardStagings.DeleteObject(ImportCreditCardStaging)

        '    '                                        Catch ex As Exception

        '    '                                        End Try

        '    '                                    End If

        '    '                                ElseIf ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_Default Then

        '    '                                    ImportClearedChecksStaging = New AdvantageFramework.Database.Entities.ImportClearedChecksStaging

        '    '                                    ImportClearedChecksStaging.DbContext = DbContext
        '    '                                    ImportClearedChecksStaging.BatchName = BatchName
        '    '                                    ImportClearedChecksStaging.BankCode = BankCode
        '    '                                    ImportClearedChecksStaging.FileName = FileInfo.Name

        '    '                                    CreateEntityFromCSVTemplate(Session, FileLineData, ImportTemplateDetails, ImportClearedChecksStaging, AutoTrimOverflowData)

        '    '                                    AdvantageFramework.Database.Procedures.ImportClearedChecksStaging.Insert(DbContext, ImportClearedChecksStaging)

        '    '                                End If

        '    '                            End If

        '    '                            FileLineCounter += 1

        '    '                            RaiseEvent ImportingProgressUpdateEvent(FileLineCounter)

        '    '                        Catch ex As Exception

        '    '                        End Try

        '    '                    Loop

        '    '                    TextFieldParser.Close()
        '    '                    TextFieldParser.Dispose()

        '    '                ElseIf ImportTemplate.FileType = AdvantageFramework.Importing.FileTypes.Fixed Then

        '    '                    If IsFirstRowColumnHeaders Then

        '    '                        FileLineStarter = 1

        '    '                    End If

        '    '                    RaiseEvent SetupImportingProgressEvent(0, FileLines.Count - 1 - FileLineStarter, 0)

        '    '                    If ImportTemplate.Type = Methods.ImportTemplateTypes.ExpenseReport_CreditCard OrElse _
        '    '                            ImportTemplate.Type = Methods.ImportTemplateTypes.ExpenseReport_CreditCard Then

        '    '                        Employees = AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).ToList

        '    '                    End If

        '    '                    For Each FileLine In FileLines

        '    '                        If FileLineCounter >= FileLineStarter Then

        '    '                            If ImportTemplate.Type = Methods.ImportTemplateTypes.ExpenseReport_CreditCard OrElse _
        '    '                                    ImportTemplate.Type = Methods.ImportTemplateTypes.ExpenseReport_CreditCard Then

        '    '                                ImportCreditCardStaging = New AdvantageFramework.Database.Entities.ImportCreditCardStaging

        '    '                                ImportCreditCardStaging.DbContext = DbContext
        '    '                                ImportCreditCardStaging.BatchName = BatchName

        '    '                                CreateEntityFromFixedTemplate(Session, FileLine, ImportTemplateDetails, ImportCreditCardStaging, AutoTrimOverflowData)

        '    '                                If ImportCreditCardStaging.EmployeeFirstName IsNot Nothing AndAlso ImportCreditCardStaging.EmployeeLastName IsNot Nothing Then

        '    '                                    Try

        '    '                                        ImportCreditCardStaging.EmployeeCode = (From Employee In Employees _
        '    '                                                                                Where Employee.LastName.ToUpper = ImportCreditCardStaging.EmployeeLastName.ToUpper AndAlso _
        '    '                                                                                      Employee.FirstName.ToUpper = ImportCreditCardStaging.EmployeeFirstName.ToUpper _
        '    '                                                                                Select Employee.Code).FirstOrDefault

        '    '                                    Catch ex As Exception
        '    '                                        ImportCreditCardStaging.EmployeeCode = Nothing
        '    '                                    End Try

        '    '                                End If

        '    '                                If ImportTemplate.Type = Methods.ImportTemplateTypes.ExpenseReport_CreditCard Then

        '    '                                    ImportCreditCardStaging.CreditCardFlag = True

        '    '                                Else

        '    '                                    ImportCreditCardStaging.CreditCardFlag = False

        '    '                                End If

        '    '                                AdvantageFramework.Database.Procedures.ImportCreditCardStaging.Insert(DbContext, ImportCreditCardStaging)

        '    '                            ElseIf ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_Default Then

        '    '                                ImportClearedChecksStaging = New AdvantageFramework.Database.Entities.ImportClearedChecksStaging

        '    '                                ImportClearedChecksStaging.DbContext = DbContext
        '    '                                ImportClearedChecksStaging.BatchName = BatchName
        '    '                                ImportClearedChecksStaging.BankCode = BankCode
        '    '                                ImportClearedChecksStaging.FileName = FileInfo.Name

        '    '                                CreateEntityFromFixedTemplate(Session, FileLine, ImportTemplateDetails, ImportClearedChecksStaging, AutoTrimOverflowData)

        '    '                                AdvantageFramework.Database.Procedures.ImportClearedChecksStaging.Insert(DbContext, ImportClearedChecksStaging)

        '    '                            End If

        '    '                        End If

        '    '                        FileLineCounter += 1

        '    '                        RaiseEvent ImportingProgressUpdateEvent(FileLineCounter)

        '    '                    Next

        '    '                End If

        '    '            End If

        '    '        End If

        '    '    End Using

        '    'Catch ex As Exception
        '    '    FileImported = False
        '    'Finally
        '    '    ImportFileByImportTemplate = FileImported
        '    'End Try

        'End Function
        Public Function ImportStandardDefinitionFile(ByVal Session As AdvantageFramework.Security.Session, ByVal ImportType As AdvantageFramework.Importing.ImportType,
                                                     ByVal File As String, ByVal AutoTrimOverflowData As Boolean) As Boolean

            'objects
            Dim FileImported As Boolean = True
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim FileLines() As String = Nothing
            Dim FileLineData() As String = Nothing
            Dim FileLineCounter As Integer = 0
            Dim ImportEmployeeStaging As AdvantageFramework.Database.Entities.ImportEmployeeStaging = Nothing
            Dim ImportVendorStaging As AdvantageFramework.Database.Entities.ImportVendorStaging = Nothing
            Dim VendorList As Generic.List(Of AdvantageFramework.Database.Entities.Vendor) = Nothing
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim StringList As Generic.List(Of String) = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Try

                        StreamReader = New System.IO.StreamReader(File)

                    Catch ex As Exception
                        StreamReader = Nothing
                    Finally

                        If StreamReader IsNot Nothing Then

                            StringList = New Generic.List(Of String)

                            Do While StreamReader.Peek <> -1

                                StringList.Add(StreamReader.ReadLine())

                            Loop

                            FileLines = StringList.ToArray

                            Try

                                StreamReader.Close()
                                StreamReader.Dispose()

                            Catch ex As Exception

                            End Try

                        End If

                    End Try

                    If FileLines IsNot Nothing AndAlso FileLines.Count > 0 Then

                        If ImportType = Methods.ImportType.Employee Then

                            Employees = AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).ToList

                        ElseIf ImportType = Methods.ImportType.Vendor Then

                            VendorList = AdvantageFramework.Database.Procedures.Vendor.Load(DbContext).ToList

                        End If

                        RaiseEvent SetupImportingProgressEvent(0, FileLines.Count, 0)

                        For Each FileLine In FileLines

                            FileLineData = FileLine.Split(",")

                            If FileLineCounter <> 0 AndAlso FileLineData.Count > 2 Then

                                If ImportType = Methods.ImportType.Employee Then

                                    Try

                                        ImportEmployeeStaging = New AdvantageFramework.Database.Entities.ImportEmployeeStaging

                                        ImportEmployeeStaging.DbContext = DbContext
                                        ImportEmployeeStaging.EmployeeCode = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.EmployeeCode), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.EmployeeCode, AutoTrimOverflowData)
                                        ImportEmployeeStaging.FirstName = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.FirstName), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.FirstName, AutoTrimOverflowData)
                                        ImportEmployeeStaging.MiddleInitial = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.MiddleInitial), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.MiddleInitial, AutoTrimOverflowData)
                                        ImportEmployeeStaging.LastName = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.LastName), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.LastName, AutoTrimOverflowData)
                                        ImportEmployeeStaging.DepartmentTeamCode = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.DepartmentCode), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.DepartmentTeamCode, AutoTrimOverflowData)
                                        ImportEmployeeStaging.AccountNumber = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.AccountNumber), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.AccountNumber, AutoTrimOverflowData)
                                        ImportEmployeeStaging.Email = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.Email), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.Email, AutoTrimOverflowData)
                                        ImportEmployeeStaging.Address = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.Address), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.Address, AutoTrimOverflowData)
                                        ImportEmployeeStaging.Address2 = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.Address2), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.Address2, AutoTrimOverflowData)
                                        ImportEmployeeStaging.City = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.City), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.City, AutoTrimOverflowData)
                                        ImportEmployeeStaging.State = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.State), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.State, AutoTrimOverflowData)
                                        ImportEmployeeStaging.Zip = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.Zip), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.Zip, AutoTrimOverflowData)
                                        ImportEmployeeStaging.County = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.County), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.County, AutoTrimOverflowData)
                                        ImportEmployeeStaging.OtherInfo = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.OtherInfo), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.OtherInfo, AutoTrimOverflowData)
                                        ImportEmployeeStaging.PhoneNumber = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.PhoneNumber), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.PhoneNumber, AutoTrimOverflowData)
                                        ImportEmployeeStaging.WorkPhoneNumber = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.WorkPhoneNumber), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.WorkPhoneNumber, AutoTrimOverflowData)
                                        ImportEmployeeStaging.WorkPhoneNumberExtension = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.WorkPhoneNumberExtension), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.WorkPhoneNumberExtension, AutoTrimOverflowData)
                                        ImportEmployeeStaging.CellPhoneNumber = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.CellPhoneNumber), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.CellPhoneNumber, AutoTrimOverflowData)
                                        ImportEmployeeStaging.AlternatePhoneNumber = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.AlternatePhoneNumber), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.AlternatePhoneNumber, AutoTrimOverflowData)
                                        ImportEmployeeStaging.Title = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.Title), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.Title, AutoTrimOverflowData)
                                        ImportEmployeeStaging.SupervisorEmployeeCode = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.SupervisorEmployeeCode), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.SupervisorEmployeeCode, AutoTrimOverflowData)
                                        ImportEmployeeStaging.OfficeCode = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.OfficeCode), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.OfficeCode, AutoTrimOverflowData)
                                        ImportEmployeeStaging.FunctionCode = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.FunctionCode), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.FunctionCode, AutoTrimOverflowData)

                                        ImportEmployeeStaging.StartDate = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.StartDate), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.StartDate, AutoTrimOverflowData)
                                        ImportEmployeeStaging.TerminationDate = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.TerminationDate), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.TerminationDate, AutoTrimOverflowData)
                                        ImportEmployeeStaging.BirthDate = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.BirthDate), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.BirthDate, AutoTrimOverflowData)
                                        ImportEmployeeStaging.LastIncrease = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.LastIncrease), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.LastIncrease, AutoTrimOverflowData)
                                        ImportEmployeeStaging.NextReview = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.NextReview), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.NextReview, AutoTrimOverflowData)
                                        ImportEmployeeStaging.BillRate = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.BillingRate), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.BillRate, AutoTrimOverflowData)
                                        ImportEmployeeStaging.CostRate = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.CostRate), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.CostRate, AutoTrimOverflowData)
                                        ImportEmployeeStaging.AnnualSalary = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.AnnualSalary), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.AnnualSalary, AutoTrimOverflowData)
                                        ImportEmployeeStaging.MonthlySalary = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.MonthlySalary), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.MonthlySalary, AutoTrimOverflowData)
                                        ImportEmployeeStaging.AnnualHours = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.AnnualHours), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.AnnualHours, AutoTrimOverflowData)
                                        ImportEmployeeStaging.MonthHoursGoal = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.MonthHoursGoal), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.MonthHoursGoal, AutoTrimOverflowData)
                                        ImportEmployeeStaging.PurchaseOrderLimit = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.PurchaseOrderLimit), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.PurchaseOrderLimit, AutoTrimOverflowData)

                                        ImportEmployeeStaging.PurchaseOrderApprovalRuleCode = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.PurchaseOrderApprovalRuleCode), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.PurchaseOrderApprovalRuleCode, AutoTrimOverflowData)
                                        ImportEmployeeStaging.DirectHours = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.DirectHours), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.DirectHours, AutoTrimOverflowData)
                                        ImportEmployeeStaging.RoleCode = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.RoleCode), AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.RoleCode, AutoTrimOverflowData)

                                        ImportEmployeeStaging.IsOnHold = False

                                        Try

                                            Employee = Employees.SingleOrDefault(Function(EmployeeView) EmployeeView.Code.ToUpper = ImportEmployeeStaging.EmployeeCode.ToUpper)

                                        Catch ex As Exception
                                            Employee = Nothing
                                        End Try

                                        If Employee IsNot Nothing Then

                                            ImportEmployeeStaging.EmployeeCode = Employee.Code

                                            ImportEmployeeStaging.IsNew = False

                                            If FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.StartDate) = "" Then

                                                ImportEmployeeStaging.StartDate = Employee.StartDate

                                            End If

                                            If FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.TerminationDate) = "" Then

                                                ImportEmployeeStaging.TerminationDate = Employee.TerminationDate

                                            End If

                                            If FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.BirthDate) = "" Then

                                                ImportEmployeeStaging.BirthDate = Employee.BirthDate

                                            End If

                                            If FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.LastIncrease) = "" Then

                                                ImportEmployeeStaging.LastIncrease = Employee.LastIncrease

                                            End If

                                            If FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.NextReview) = "" Then

                                                ImportEmployeeStaging.NextReview = Employee.NextReview

                                            End If

                                            If FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.BillingRate) = "" Then

                                                ImportEmployeeStaging.BillRate = Employee.BillRate

                                            End If

                                            If FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.CostRate) = "" Then

                                                ImportEmployeeStaging.CostRate = Employee.CostRate

                                            End If

                                            If FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.AnnualSalary) = "" Then

                                                ImportEmployeeStaging.AnnualSalary = Employee.AnnualSalary

                                            End If

                                            If FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.MonthlySalary) = "" Then

                                                ImportEmployeeStaging.MonthlySalary = Employee.MonthlySalary

                                            End If

                                            If FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.AnnualHours) = "" Then

                                                ImportEmployeeStaging.AnnualHours = Employee.AnnualHours

                                            End If

                                            If FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.MonthHoursGoal) = "" Then

                                                ImportEmployeeStaging.MonthHoursGoal = Employee.MonthHoursGoal

                                            End If

                                            If FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.PurchaseOrderLimit) = "" Then

                                                ImportEmployeeStaging.PurchaseOrderLimit = Employee.PurchaseOrderLimit

                                            End If

                                            If FileLineData(AdvantageFramework.Importing.EmployeeImportColumns.DirectHours) = "" Then

                                                ImportEmployeeStaging.DirectHours = Employee.DirectHours

                                            End If

                                        Else

                                            ImportEmployeeStaging.IsNew = True

                                        End If

                                        DbContext.ImportEmployeeStagings.Add(ImportEmployeeStaging)

                                    Catch ex As Exception
                                        FileImported = False
                                    End Try

                                ElseIf ImportType = Methods.ImportType.Vendor Then

                                    Try

                                        ImportVendorStaging = New AdvantageFramework.Database.Entities.ImportVendorStaging

                                        ImportVendorStaging.DbContext = DbContext
                                        ImportVendorStaging.VendorCode = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorCode), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorCode, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorName = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorName), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorName, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorStreetAddressLine1 = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorStreetAddressLine1), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorStreetAddressLine1, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorStreetAddressLine2 = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorStreetAddressLine2), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorStreetAddressLine2, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorStreetAddressLine3 = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorStreetAddressLine3), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorStreetAddressLine3, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorCity = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorCity), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorCity, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorCounty = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorCounty), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorCounty, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorState = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorState), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorState, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorCountry = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorCountry), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorCountry, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorZipCode = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorZipCode), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorZipCode, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorPhoneNumber = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorPhoneNumber), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPhoneNumber, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorPhoneNumberExtension = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorPhoneNumberExtension), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPhoneNumberExtension, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorFaxPhoneNumber = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorFaxPhoneNumber), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorFaxPhoneNumber, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorFaxPhoneNumberExtension = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorFaxPhoneNumberExtension), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorFaxPhoneNumberExtension, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorPayToCode = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorPayToCode), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToCode, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorPayToName = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorPayToName), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToName, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorPayToAddressLine1 = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorPayToAddressLine1), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToAddressLine1, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorPayToAddressLine2 = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorPayToAddressLine2), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToAddressLine2, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorPayToStreetAddressLine3 = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorPayToStreetAddressLine3), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToStreetAddressLine3, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorPayToCity = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorPayToCity), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToCity, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorPayToCounty = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorPayToCounty), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToCounty, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorPayToState = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorPayToState), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToState, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorPayToCountry = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorPayToCountry), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToCountry, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorPayToZipCode = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorPayToZipCode), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToZipCode, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorPayToPhoneNumber = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorPayToPhoneNumber), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToPhoneNumber, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorPayToPhoneNumberExtension = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorPayToPhoneNumberExtension), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToPhoneNumberExtension, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorPayToFaxPhoneNumber = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorPayToFaxPhoneNumber), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToFaxPhoneNumber, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorPayToFaxPhoneNumberExtension = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorPayToFaxPhoneNumberExtension), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorPayToFaxPhoneNumberExtension, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorTermCode = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorTerms), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorTermCode, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorTaxID = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorTaxID), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorTaxID, AutoTrimOverflowData)
                                        ImportVendorStaging.Vendor1099Flag = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.Vendor1099Flag), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.Vendor1099Flag, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorCategory = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorCategory), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorCategory, AutoTrimOverflowData)
                                        ImportVendorStaging.DefaultAPAccount = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.DefaultAPAccount), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.DefaultAPAccount, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorNotes = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorNotes), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorNotes, AutoTrimOverflowData)
                                        ImportVendorStaging.DefaultExpenseAccount = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.DefaultExpenseAccount), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.DefaultExpenseAccount, AutoTrimOverflowData)
                                        ImportVendorStaging.AssociateWithOffice = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.AssociateWithOffice), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.AssociateWithOffice, AutoTrimOverflowData)
                                        ImportVendorStaging.OfficeCode = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.OfficeCode), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.OfficeCode, AutoTrimOverflowData)
                                        ImportVendorStaging.Vendor1099StreetAddressLine1 = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.Vendor1099StreetAddressLine1), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.Vendor1099StreetAddressLine1, AutoTrimOverflowData)
                                        ImportVendorStaging.Vendor1099StreetAddressLine2 = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.Vendor1099StreetAddressLine2), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.Vendor1099StreetAddressLine2, AutoTrimOverflowData)
                                        ImportVendorStaging.Vendor1099StreetAddressLine3 = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.Vendor1099StreetAddressLine3), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.Vendor1099StreetAddressLine3, AutoTrimOverflowData)
                                        ImportVendorStaging.Vendor1099City = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.Vendor1099City), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.Vendor1099City, AutoTrimOverflowData)
                                        ImportVendorStaging.Vendor1099State = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.Vendor1099State), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.Vendor1099State, AutoTrimOverflowData)
                                        ImportVendorStaging.Vendor1099ZipCode = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.Vendor1099ZipCode), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.Vendor1099ZipCode, AutoTrimOverflowData)
                                        ImportVendorStaging.Vendor1099County = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.Vendor1099County), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.Vendor1099County, AutoTrimOverflowData)
                                        ImportVendorStaging.Vendor1099Country = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.Vendor1099Country), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.Vendor1099Country, AutoTrimOverflowData)
                                        ImportVendorStaging.UseAlternativeAddressFor1099 = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.UseAlternativeAddressFor1099), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.UseAlternativeAddressFor1099, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorAccountNumber = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorAccountNumber), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorAccountNumber, AutoTrimOverflowData)
                                        ImportVendorStaging.DefaultFunction = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.DefaultFunction), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.DefaultFunction, AutoTrimOverflowData)
                                        ImportVendorStaging.EmployeeVendor = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.EmployeeVendor), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.EmployeeVendor, AutoTrimOverflowData)
                                        ImportVendorStaging.OneCheckPerInvoice = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.OneCheckPerInvoice), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.OneCheckPerInvoice, AutoTrimOverflowData)
                                        ImportVendorStaging.VendorEmailAddress = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.VendorEmailAddress), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.VendorEmailAddress, AutoTrimOverflowData)
                                        ImportVendorStaging.PaymentManagerEmailAddress = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.PaymentManagerEmailAddress), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.PaymentManagerEmailAddress, AutoTrimOverflowData)
                                        ImportVendorStaging.ActiveFlag = AdvantageFramework.Importing.ScrubFileData(DbContext, ImportType, FileLineData(AdvantageFramework.Importing.VendorImportColumns.ActiveFlag), AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.ActiveFlag, AutoTrimOverflowData)

                                        ImportVendorStaging.OnHold = False

                                        If FileLineData(AdvantageFramework.Importing.VendorImportColumns.Vendor1099Flag) = "*" Then

                                            ImportVendorStaging.Vendor1099Flag = 0

                                        End If

                                        If FileLineData(AdvantageFramework.Importing.VendorImportColumns.AssociateWithOffice) = "*" Then

                                            ImportVendorStaging.AssociateWithOffice = 0

                                        End If

                                        If FileLineData(AdvantageFramework.Importing.VendorImportColumns.UseAlternativeAddressFor1099) = "*" Then

                                            ImportVendorStaging.UseAlternativeAddressFor1099 = 0

                                        End If

                                        If FileLineData(AdvantageFramework.Importing.VendorImportColumns.EmployeeVendor) = "*" Then

                                            ImportVendorStaging.EmployeeVendor = 0

                                        End If

                                        If FileLineData(AdvantageFramework.Importing.VendorImportColumns.OneCheckPerInvoice) = "*" Then

                                            ImportVendorStaging.OneCheckPerInvoice = 0

                                        End If

                                        Try

                                            Vendor = VendorList.SingleOrDefault(Function(Entity) Entity.Code.ToUpper = ImportVendorStaging.VendorCode.ToUpper)

                                        Catch ex As Exception
                                            Vendor = Nothing
                                        End Try

                                        If Vendor IsNot Nothing Then

                                            ImportVendorStaging.VendorCode = Vendor.Code

                                            ImportVendorStaging.IsNew = False

                                            If FileLineData(AdvantageFramework.Importing.VendorImportColumns.ActiveFlag) = "" Then

                                                ImportVendorStaging.ActiveFlag = Vendor.ActiveFlag.GetValueOrDefault(0)

                                            End If

                                            If FileLineData(AdvantageFramework.Importing.VendorImportColumns.Vendor1099Flag) = "" Then

                                                ImportVendorStaging.Vendor1099Flag = Vendor.Vendor1099Flag

                                            End If

                                            If FileLineData(AdvantageFramework.Importing.VendorImportColumns.AssociateWithOffice) = "" Then

                                                ImportVendorStaging.AssociateWithOffice = Vendor.AssociateWithOffice

                                            End If

                                            If FileLineData(AdvantageFramework.Importing.VendorImportColumns.UseAlternativeAddressFor1099) = "" Then

                                                ImportVendorStaging.UseAlternativeAddressFor1099 = Vendor.UseAlternativeAddressFor1099

                                            End If

                                            If FileLineData(AdvantageFramework.Importing.VendorImportColumns.EmployeeVendor) = "" Then

                                                ImportVendorStaging.EmployeeVendor = Vendor.EmployeeVendor

                                            End If

                                            If FileLineData(AdvantageFramework.Importing.VendorImportColumns.OneCheckPerInvoice) = "" Then

                                                ImportVendorStaging.OneCheckPerInvoice = Vendor.OneCheckPerInvoice

                                            End If

                                        Else

                                            ImportVendorStaging.IsNew = True

                                        End If

                                        DbContext.ImportVendorStagings.Add(ImportVendorStaging)

                                    Catch ex As Exception
                                        FileImported = False
                                    End Try

                                End If

                            End If

                            FileLineCounter += 1
                            RaiseEvent ImportingProgressUpdateEvent(FileLineCounter)

                        Next

                        DbContext.SaveChanges()

                    End If

                End Using

            Catch ex As Exception
                FileImported = False
            Finally
                ImportStandardDefinitionFile = FileImported
            End Try

        End Function
        Public Function CheckForStandardDefinitionFile(ByVal ImportType As AdvantageFramework.Importing.ImportType, ByVal File As String) As Boolean

            'objects
            Dim IsStandardDefinitionFile As Boolean = True
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim FileLines() As String = Nothing
            Dim FileLineData() As String = Nothing
            Dim ColumnName As String = ""
            Dim ColumnNameList As Generic.List(Of String) = Nothing
            Dim ImportColumnNames As Generic.List(Of String) = Nothing
            Dim StringList As Generic.List(Of String) = Nothing

            Try

                Try

                    StreamReader = New System.IO.StreamReader(File)

                Catch ex As Exception
                    StreamReader = Nothing
                Finally

                    If StreamReader IsNot Nothing Then

                        StringList = New Generic.List(Of String)

                        Do While StreamReader.Peek <> -1

                            StringList.Add(StreamReader.ReadLine())

                        Loop

                        FileLines = StringList.ToArray

                        If FileLines IsNot Nothing AndAlso FileLines.Count > 0 Then

                            FileLineData = FileLines(0).Split(",")

                        End If

                        Try

                            StreamReader.Close()
                            StreamReader.Dispose()

                        Catch ex As Exception

                        End Try

                    End If

                End Try

                If FileLineData IsNot Nothing Then

                    If FileLineData.Count > 2 Then

                        ColumnNameList = New Generic.List(Of String)

                        If ImportType = Methods.ImportType.Employee Then

                            ImportColumnNames = AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(AdvantageFramework.Importing.EmployeeImportColumns), False)

                        ElseIf ImportType = Methods.ImportType.Vendor Then

                            ImportColumnNames = AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(AdvantageFramework.Importing.VendorImportColumns), False)

                        End If

                        For Each ImportColumnName In ImportColumnNames

                            ColumnName = AdvantageFramework.StringUtilities.GetNameAsWords(ImportColumnName)

                            If FileLineData.Any(Function(FileData) FileData = ColumnName) = False Then

                                IsStandardDefinitionFile = False
                                Exit For

                            Else

                                If ColumnNameList.Contains(ImportColumnName) Then

                                    IsStandardDefinitionFile = False
                                    Exit For

                                Else

                                    ColumnNameList.Add(ImportColumnName)

                                End If

                            End If

                        Next

                    Else

                        IsStandardDefinitionFile = False

                    End If

                Else

                    IsStandardDefinitionFile = False

                End If

            Catch ex As Exception
                IsStandardDefinitionFile = False
            Finally
                CheckForStandardDefinitionFile = IsStandardDefinitionFile
            End Try

        End Function
        Public Function LoadImportedDataToUpdate(ByVal CurrentValue As Object, ByVal NewValue As Object) As Object

            'objects
            Dim NewImportedValue As Object = Nothing

            If TypeOf CurrentValue Is String AndAlso TypeOf NewValue Is String Then

                If DirectCast(NewValue, String) <> "" Then

                    If DirectCast(NewValue, String) = "*" Then

                        NewImportedValue = Nothing

                    Else

                        If DirectCast(CurrentValue, String) <> DirectCast(NewValue, String) Then

                            NewImportedValue = NewValue

                        Else

                            NewImportedValue = CurrentValue

                        End If

                    End If

                Else

                    NewImportedValue = CurrentValue

                End If

            Else

                If TypeOf NewValue Is String AndAlso CurrentValue = Nothing Then

                    If NewValue = "" Then

                        NewImportedValue = CurrentValue

                    Else

                        If NewValue <> "*" Then

                            NewImportedValue = NewValue

                        End If

                    End If

                Else

                    If (CurrentValue Is Nothing OrElse CurrentValue <> NewValue) AndAlso IsNothing(NewValue) = False Then

                        NewImportedValue = NewValue

                    Else

                        If IsNothing(CurrentValue) = False AndAlso IsNothing(NewValue) Then

                            NewImportedValue = NewValue

                        Else

                            NewImportedValue = CurrentValue

                        End If

                    End If

                End If

            End If

            LoadImportedDataToUpdate = NewImportedValue

        End Function
        ''' <summary>
        ''' DO NOT USE FOR VENDOR OR EMPLOYEE IMPORT!  Or risk death by Steve
        ''' </summary>
        Private Function LoadImportedMaintenanceDataToUpdate(ByVal CurrentValue As Object, ByVal NewValue As Object) As Object

            'objects
            Dim NewImportedValue As Object = Nothing

            If TypeOf CurrentValue Is String AndAlso TypeOf NewValue Is String Then

                If String.IsNullOrWhiteSpace(NewValue) Then

                    NewImportedValue = CurrentValue

                ElseIf NewValue = "*" Then

                    NewImportedValue = Nothing

                Else

                    NewImportedValue = CType(NewValue, String).Trim

                End If

            Else

                If TypeOf NewValue Is String AndAlso CurrentValue Is Nothing Then

                    If String.IsNullOrWhiteSpace(NewValue) Then

                        NewImportedValue = CurrentValue

                    ElseIf NewValue <> "*" Then

                        NewImportedValue = CType(NewValue, String).Trim

                    End If

                Else 'for non-strings take what is there always

                    NewImportedValue = NewValue

                End If

            End If

            LoadImportedMaintenanceDataToUpdate = NewImportedValue

        End Function
        Private Function ScrubAsteriskNonStringColumn(ByVal DataTable As System.Data.DataTable, ByVal ColumnName As String, ByVal FileLineData As Object, ByVal NonAsteriskValue As Object) As Object

            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim NewValue As Object = Nothing

            DataColumn = DataTable.Columns(ColumnName)

            If DataColumn IsNot Nothing AndAlso DataColumn.ExtendedProperties("CSVPosition") <= UBound(FileLineData) AndAlso
                    FileLineData(DataColumn.ExtendedProperties("CSVPosition")) IsNot Nothing Then

                If FileLineData(DataColumn.ExtendedProperties("CSVPosition")) = "*" Then

                    NewValue = Nothing

                ElseIf Trim(FileLineData(DataColumn.ExtendedProperties("CSVPosition"))) = "" Then

                    NewValue = NonAsteriskValue

                Else

                    NewValue = FileLineData(DataColumn.ExtendedProperties("CSVPosition"))

                End If

                If NewValue IsNot Nothing Then

                    If DataColumn.DataType Is GetType(String) Then

                        NewValue = CType(NewValue, String)

                    ElseIf DataColumn.DataType Is GetType(Decimal) Then

                        NewValue = CType(NewValue, Decimal)

                    ElseIf DataColumn.DataType Is GetType(Short) Then

                        NewValue = CType(NewValue, Short)

                    ElseIf DataColumn.DataType Is GetType(Integer) Then

                        NewValue = CType(NewValue, Integer)

                    ElseIf DataColumn.DataType Is GetType(Date) Then

                        NewValue = CType(NewValue, Date)

                    ElseIf DataColumn.DataType Is GetType(Boolean) Then

                        NewValue = CType(NewValue, Boolean)

                    End If

                End If

            Else

                NewValue = NonAsteriskValue

            End If

            ScrubAsteriskNonStringColumn = NewValue

        End Function
        Public Function ImportClearedChecks(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportedClearedChecksList As Generic.List(Of AdvantageFramework.Database.Classes.ImportedClearedCheck)) As Boolean

            'objects
            Dim Imported As Boolean = False
            Dim ImportClearedChecksStaging As AdvantageFramework.Database.Entities.ImportClearedChecksStaging = Nothing

            For Each ImportedClearedCheck In ImportedClearedChecksList

                ImportClearedChecksStaging = AdvantageFramework.Database.Procedures.ImportClearedChecksStaging.LoadByImportClearedChecksStagingID(DbContext, ImportedClearedCheck.ID)

                If ImportClearedChecksStaging IsNot Nothing Then

                    If AdvantageFramework.Database.Procedures.CheckRegister.SetCheckToCleared(DbContext, ImportClearedChecksStaging.BankCode, CInt(ImportClearedChecksStaging.CheckNumber), ImportClearedChecksStaging.CheckClearedDate) Then

                        Imported = AdvantageFramework.Database.Procedures.ImportClearedChecksStaging.Delete(DbContext, ImportClearedChecksStaging)

                    End If

                End If

            Next

            ImportClearedChecks = Imported

        End Function
        Public Function ImportClearedChecks(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportClearedCheckMediaVCCList As Generic.List(Of AdvantageFramework.MediaManager.Classes.ImportClearedCheckMediaVCC),
                                            ByRef AllImportClearedCheckMediaVCCList As Generic.List(Of AdvantageFramework.MediaManager.Classes.ImportClearedCheckMediaVCC)) As Boolean

            'objects
            Dim Imported As Boolean = False
            Dim ImportClearedCheckMediaVCCStaging As AdvantageFramework.Database.Entities.ImportClearedCheckMediaVCCStaging = Nothing

            For Each ImportClearedCheckMediaVCC In ImportClearedCheckMediaVCCList

                ImportClearedCheckMediaVCCStaging = AdvantageFramework.Database.Procedures.ImportClearedCheckMediaVCCStaging.LoadByImportClearedCheckMediaVCCStagingID(DbContext, ImportClearedCheckMediaVCC.ID)

                If ImportClearedCheckMediaVCCStaging IsNot Nothing Then

                    If AdvantageFramework.Database.Procedures.CheckRegister.SetCheckToCleared(DbContext, ImportClearedCheckMediaVCC.BankCode, ImportClearedCheckMediaVCC.CheckNumber, ImportClearedCheckMediaVCC.ClearedDate) Then

                        For Each AllImportClearedCheckMediaVCC In AllImportClearedCheckMediaVCCList.Where(Function(Entity) Entity.CheckNumber = ImportClearedCheckMediaVCC.CheckNumber)

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.IMP_CLR_CHK_MEDIA_VCC_STAGING WHERE ID = {0}", AllImportClearedCheckMediaVCC.ID))

                        Next

                        Imported = True

                    End If

                End If

            Next

            ImportClearedChecks = Imported

        End Function
        Public Function RenameFileAfterImport(ByVal FilePath As String, ByVal UserCode As String, Optional ByVal NewFileName As String = Nothing) As Boolean

            'objects
            Dim FileDirectory As String = Nothing
            Dim FileName As String = Nothing
            Dim FileExtension As String = Nothing
            Dim Renamed As Boolean = True

            Try

                FileName = My.Computer.FileSystem.GetFileInfo(FilePath).Name

                FileDirectory = FilePath.Replace(FileName, "")

                FileExtension = My.Computer.FileSystem.GetFileInfo(FilePath).Extension

                'If Debugger.IsAttached = False Then

                If String.IsNullOrWhiteSpace(NewFileName) Then

                    If String.IsNullOrWhiteSpace(FileExtension) Then

                        NewFileName = FileName & "_" & Now.ToFileTime & ".old"

                    Else

                        NewFileName = FileName.Replace(FileExtension, "_" & Now.ToFileTime & FileExtension & ".old")

                    End If

                Else

                    NewFileName &= "_" & FileName & ".old"

                End If

                My.Computer.FileSystem.RenameFile(FilePath, NewFileName)

                'End If

            Catch ex As Exception
                Renamed = False
            Finally
                RenameFileAfterImport = Renamed
            End Try

        End Function
        Private Sub ScrubDataByPropertyType(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal DataContext As AdvantageFramework.Database.DataContext,
                                            ByVal Entity As Object,
                                            ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByRef PropertyValue As Object)

            'objects
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim IsValid As Boolean = True

            If PropertyValue IsNot Nothing Then

                Try

                    EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                Catch ex As Exception

                End Try

                If EntityAttribute IsNot Nothing Then

                    If EntityAttribute.PropertyType <> BaseClasses.PropertyTypes.Default Then

                        Select Case EntityAttribute.PropertyType

                            Case BaseClasses.PropertyTypes.DivisionCode, BaseClasses.PropertyTypes.ProductCode

                                Try

                                    ClientCode = System.ComponentModel.TypeDescriptor.GetProperties(Entity).OfType(Of System.ComponentModel.PropertyDescriptor) _
                                                 .Where(Function(Prop) Prop.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault.PropertyType = BaseClasses.PropertyTypes.ClientCode) _
                                                 .FirstOrDefault.GetValue(Entity)

                                Catch ex As Exception
                                    ClientCode = Nothing
                                End Try

                                If EntityAttribute.PropertyType = BaseClasses.PropertyTypes.ProductCode Then

                                    Try

                                        DivisionCode = System.ComponentModel.TypeDescriptor.GetProperties(Entity).OfType(Of System.ComponentModel.PropertyDescriptor) _
                                                       .Where(Function(Prop) Prop.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault.PropertyType = BaseClasses.PropertyTypes.DivisionCode) _
                                                       .FirstOrDefault.GetValue(Entity)

                                    Catch ex As Exception
                                        DivisionCode = Nothing
                                    End Try

                                End If

                            Case Else

                        End Select

                        Try

                            AdvantageFramework.BaseClasses.ValidatePropertyType(DbContext, DataContext, EntityAttribute.PropertyType, PropertyValue, IsValid, ClientCode, DivisionCode)

                        Catch ex As Exception

                        End Try

                        If IsValid = False Then

                            ScrubValueByPropertyType(DbContext, DataContext, EntityAttribute.PropertyType, PropertyValue, ClientCode, DivisionCode)

                        End If

                    End If

                End If

            End If

        End Sub
        Public Sub ScrubValueByPropertyType(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal DataContext As AdvantageFramework.Database.DataContext,
                                            ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes,
                                            ByRef PropertyValue As Object, Optional ByVal ClientCode As String = Nothing, Optional ByVal DivisionCode As String = Nothing)

            If PropertyType <> BaseClasses.PropertyTypes.Default Then

                Select Case PropertyType

                    Case BaseClasses.PropertyTypes.ClientCode

                        ScrubClientCode(DbContext, PropertyValue)

                    Case BaseClasses.PropertyTypes.DivisionCode

                        ScrubDivisionCode(DbContext, ClientCode, PropertyValue)

                    Case BaseClasses.PropertyTypes.ProductCode

                        ScrubProductCode(DbContext, ClientCode, DivisionCode, PropertyValue)

                    Case BaseClasses.PropertyTypes.EmployeeCode, BaseClasses.PropertyTypes.ExpenseEmployee

                        ScrubEmployeeCode(DbContext, PropertyValue)

                    Case BaseClasses.PropertyTypes.FunctionCode

                        ScrubFunctionCode(DbContext, PropertyValue)

                End Select

            End If

        End Sub
        Public Sub ScrubClientCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef ClientCode As String)

            'objects
            Dim PropertyValue As Object = Nothing
            Dim Value As Object = Nothing

            If DbContext IsNot Nothing Then

                PropertyValue = ClientCode

                Try

                    Value = (From Client In DbContext.Clients
                             Where Client.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                             Select Client.Code).SingleOrDefault

                Catch ex As Exception
                    Value = ClientCode
                End Try

                ClientCode = Value

            End If

        End Sub
        Public Sub ScrubDivisionCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String, ByRef DivisionCode As String)

            'objects
            Dim PropertyValue As Object = Nothing
            Dim Value As Object = Nothing

            If DbContext IsNot Nothing Then

                PropertyValue = DivisionCode

                Try

                    Value = (From Division In DbContext.Divisions
                             Where Division.ClientCode.ToUpper = ClientCode.ToUpper AndAlso
                                   Division.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                             Select Division.Code).SingleOrDefault

                Catch ex As Exception
                    Value = DivisionCode
                End Try

                DivisionCode = Value

            End If

        End Sub
        Public Sub ScrubProductCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByRef ProductCode As String)

            'objects
            Dim PropertyValue As Object = Nothing
            Dim Value As Object = Nothing

            If DbContext IsNot Nothing Then

                PropertyValue = ProductCode

                Try

                    Value = (From Product In DbContext.Products
                             Where Product.ClientCode.ToUpper = ClientCode.ToUpper AndAlso
                                   Product.DivisionCode.ToUpper = DivisionCode.ToUpper AndAlso
                                   Product.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                             Select Product.Code).SingleOrDefault

                Catch ex As Exception
                    Value = ProductCode
                End Try

                ProductCode = Value

            End If

        End Sub
        Public Sub ScrubEmployeeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef EmployeeCode As String)

            'objects
            Dim PropertyValue As Object = Nothing
            Dim Value As Object = Nothing

            If DbContext IsNot Nothing Then

                PropertyValue = EmployeeCode

                Try

                    Value = (From Employee In DbContext.Employees
                             Where Employee.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                             Select Employee.Code).SingleOrDefault

                Catch ex As Exception
                    Value = EmployeeCode
                End Try

                EmployeeCode = Value

            End If

        End Sub
        Public Sub ScrubFunctionCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef FunctionCode As String)

            'objects
            Dim PropertyValue As Object = Nothing
            Dim Value As Object = Nothing

            If DbContext IsNot Nothing Then

                PropertyValue = FunctionCode

                Try

                    Value = (From [Function] In DbContext.Functions
                             Where [Function].Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                             Select [Function].Code).SingleOrDefault

                Catch ex As Exception
                    Value = FunctionCode
                End Try

                FunctionCode = Value

            End If

        End Sub
        Public Function GetHostedDirectory(ByVal ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes, ByVal AgencyImportPath As String) As String

            Dim HostedDirectory As String = Nothing

            Select Case ImportTemplateType

                Case ImportTemplateTypes.ClearedChecks_Default

                    HostedDirectory = AgencyImportPath + "CHKCLR\"

                Case ImportTemplateTypes.AccountsPayable_Generic

                    HostedDirectory = AgencyImportPath + "AP\"

                Case ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast

                    HostedDirectory = AgencyImportPath + "StrataConnect\BrdCast\"

                Case ImportTemplateTypes.AccountsPayable_StrataFixedInternet, ImportTemplateTypes.AccountsPayable_StrataFixedPrint

                    HostedDirectory = AgencyImportPath + "StrataConnect\Print\"

                Case ImportTemplateTypes.CashReceipt_Generic, ImportTemplateTypes.CashReceipt_Custom

                    HostedDirectory = AgencyImportPath + "CR\"

                Case ImportTemplateTypes.DigitalResults_Default

                    HostedDirectory = AgencyImportPath + "MediaResults\"

                Case ImportTemplateTypes.AccountsPayable_4AsBroadcast

                    HostedDirectory = AgencyImportPath + "BRDCAST\4AVOUCHER"

                Case ImportTemplateTypes.MediaRFP_4As

                    HostedDirectory = AgencyImportPath + "Avails"

                Case ImportTemplateTypes.JournalEntry_Default, ImportTemplateTypes.JournalEntry_MOGLIFACE

                    HostedDirectory = AgencyImportPath + "JE"

                Case Else

                    HostedDirectory = AgencyImportPath

            End Select

            GetHostedDirectory = HostedDirectory

        End Function
        Public Function SetFileFilterByImportTemplate(ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate) As FileSystem.FileFilters

            Dim FileFilter As FileSystem.FileFilters = Nothing

            If ImportTemplate.Type = ImportTemplateTypes.AccountsPayable_StrataFixedPrint OrElse ImportTemplate.Type = ImportTemplateTypes.AccountsPayable_StrataFixedInternet Then

                FileFilter = FileSystem.FileFilters.INV

            ElseIf ImportTemplate.Type = ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast Then

                FileFilter = FileSystem.FileFilters.V51

            ElseIf ImportTemplate.Type = ImportTemplateTypes.AccountsPayable_4AsBroadcast Then

                FileFilter = FileSystem.FileFilters.BUYandDATandTXT

            ElseIf ImportTemplate.FileType = AdvantageFramework.Importing.FileTypes.CSV Then

                FileFilter = FileSystem.FileFilters.CSV

            Else

                FileFilter = FileSystem.FileFilters.TXT

            End If

            SetFileFilterByImportTemplate = FileFilter

        End Function
        Public Function GetImportFileList(ByVal Directory As String, ByVal FileFilter As FileSystem.FileFilters, ByRef FilesInUse As String) As Generic.List(Of System.IO.FileInfo)

            Dim FileInfoList As Generic.List(Of System.IO.FileInfo) = Nothing
            Dim FileInfo As System.IO.FileInfo = Nothing
            Dim Files() As String = Nothing
            Dim InUse As Generic.List(Of String) = Nothing

            If My.Computer.FileSystem.DirectoryExists(Directory) Then

                FileInfoList = My.Computer.FileSystem.GetDirectoryInfo(Directory).GetFiles().ToList

                For Each FileInfo In FileInfoList.ToList

                    If FileFilter = FileSystem.FileFilters.CSV AndAlso FileInfo.Extension.ToUpper.EndsWith(FileFilter.ToString.ToUpper) = False Then

                        FileInfoList.Remove(FileInfo)

                    ElseIf FileFilter = FileSystem.FileFilters.INV AndAlso FileInfo.Extension.ToUpper.EndsWith(FileFilter.ToString.ToUpper) = False Then

                        FileInfoList.Remove(FileInfo)

                    ElseIf FileFilter = FileSystem.FileFilters.V51 AndAlso FileInfo.Extension.ToUpper.EndsWith(FileFilter.ToString.ToUpper) = False Then

                        FileInfoList.Remove(FileInfo)

                    ElseIf FileFilter = FileSystem.FileFilters.DAT AndAlso FileInfo.Extension.ToUpper.EndsWith(FileFilter.ToString.ToUpper) = False Then

                        FileInfoList.Remove(FileInfo)

                    ElseIf FileFilter = FileSystem.FileFilters.BUY AndAlso FileInfo.Extension.ToUpper.EndsWith(FileFilter.ToString.ToUpper) = False Then

                        FileInfoList.Remove(FileInfo)

                    ElseIf FileFilter = FileSystem.FileFilters.BUYandDATandTXT AndAlso FileInfo.Extension.ToUpper.EndsWith(FileSystem.FileFilters.BUY.ToString.ToUpper) = False AndAlso FileInfo.Extension.ToUpper.EndsWith(FileSystem.FileFilters.DAT.ToString.ToUpper) = False AndAlso FileInfo.Extension.ToUpper.EndsWith(FileSystem.FileFilters.TXT.ToString.ToUpper) = False Then

                        FileInfoList.Remove(FileInfo)

                    ElseIf FileFilter = FileSystem.FileFilters.TXT AndAlso FileInfo.Extension.ToUpper.EndsWith("TXT") = False AndAlso FileInfo.Extension.ToUpper.EndsWith("DAT") = False Then

                        FileInfoList.Remove(FileInfo)

                    ElseIf FileFilter = FileSystem.FileFilters.PDF AndAlso FileInfo.Extension.ToUpper.EndsWith(FileFilter.ToString.ToUpper) = False Then

                        FileInfoList.Remove(FileInfo)

                    End If

                Next

                Files = FileInfoList.Select(Function(F) F.FullName).ToArray

                If Files IsNot Nothing AndAlso Files.Length > 0 Then

                    FileInfoList = New Generic.List(Of System.IO.FileInfo)

                    For FileCounter As Integer = 0 To Files.Length - 1

                        If AdvantageFramework.FileSystem.IsFileInUse(Files(FileCounter)) Then

                            If InUse Is Nothing Then

                                InUse = New Generic.List(Of String)

                            End If

                            InUse.Add(Files(FileCounter))

                        Else

                            FileInfo = New System.IO.FileInfo(Files(FileCounter))

                            FileInfoList.Add(FileInfo)

                        End If

                    Next

                End If

            End If

            If InUse IsNot Nothing AndAlso InUse.Count > 0 Then

                FilesInUse = String.Join(vbCrLf, InUse.ToArray)

            End If

            GetImportFileList = FileInfoList

        End Function
        Public Function GetBatchNamesOrderedByDateDescending(ByVal BatchNameList As IEnumerable(Of String)) As Generic.List(Of Generic.KeyValuePair(Of Date, String))

            'objects
            Dim BatchDictionary As Generic.Dictionary(Of Date, String) = Nothing
            Dim BatchDateTime As String = Nothing
            Dim BatchDate As Date = Nothing

            BatchDictionary = New Generic.Dictionary(Of Date, String)

            For Each BatchName In BatchNameList

                If BatchName.ToUpper.StartsWith("MEDIA MANAGER ") Then

                    BatchDateTime = Mid(BatchName, 15)

                Else

                    BatchDateTime = Mid(BatchName, InStrRev(BatchName, "_") + 1)

                End If

                BatchDate = New Date(Mid(BatchDateTime, 5, 4), Mid(BatchDateTime, 1, 2), Mid(BatchDateTime, 3, 2), Mid(BatchDateTime, 9, 2), Mid(BatchDateTime, 11, 2), Mid(BatchDateTime, 13, 2))

                BatchDictionary.Add(BatchDate, BatchName)

            Next

            GetBatchNamesOrderedByDateDescending = BatchDictionary.OrderByDescending(Function(BD) BD.Key).ToList

        End Function
        Private Sub SetEmptyStringsToNull(ByVal PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor), ByVal Entity As BaseClasses.Entity)

            For Each PropertyDescriptor In PropertyDescriptorsList

                If PropertyDescriptor.PropertyType Is GetType(System.String) Then

                    If AdvantageFramework.BaseClasses.Entity.LoadPropertyIsNullable(PropertyDescriptor) AndAlso String.IsNullOrWhiteSpace(PropertyDescriptor.GetValue(Entity)) Then

                        PropertyDescriptor.SetValue(Entity, Nothing)

                    End If

                End If

            Next

        End Sub
        Private Function RowHasExcludeValues(ImportTemplateExcludeList As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateExclude),
                                             PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor),
                                             Entity As Object) As Boolean

            Dim HasExcludeValues As Boolean = False
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim PropertyValue As Object = Nothing

            If ImportTemplateExcludeList IsNot Nothing AndAlso ImportTemplateExcludeList.Count > 0 Then

                For Each PropertyDescriptor In PropertyDescriptorsList

                    If PropertyDescriptor.Attributes.OfType(Of System.Xml.Serialization.XmlIgnoreAttribute).Any = False AndAlso
                            Not PropertyDescriptor.PropertyType Is GetType(Byte()) Then

                        PropertyValue = PropertyDescriptor.GetValue(Entity)

                        If PropertyDescriptor.PropertyType Is GetType(System.String) Then

                            If ImportTemplateExcludeList.Where(Function(ITE) ITE.FieldName = PropertyDescriptor.Name AndAlso ITE.ExcludeValue.ToUpper = DirectCast(PropertyValue, String).ToUpper).Any Then

                                HasExcludeValues = True

                                Exit For

                            End If

                        End If

                    End If

                Next

            End If

            RowHasExcludeValues = HasExcludeValues

        End Function
        Public Function SaveOrders(Session As AdvantageFramework.Security.Session, ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder),
                                   NewAndRevised As Boolean, NewOnly As Boolean, ShowOrderDescription As Boolean, OrderDescription As String, ShowMessageBox As Boolean, IsMakegood As Boolean,
                                   ByRef CancelledImportOrders As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder), ByRef AllDirectPostMessages As String, ByRef DialogResultIsOK As Boolean, ByRef ErrorMessage As String,
                                   Optional ByVal MediaInterface As String = Nothing) As Boolean

            Dim DbTransaction As Entity.DbContextTransaction = Nothing
            Dim Saved As Boolean = False
            Dim DirectPostMessage As String = ""
            Dim BroadcastImports As Generic.List(Of AdvantageFramework.Database.Entities.BroadcastImport) = Nothing
            Dim BroadcastImportID As Long = 1
            Dim OrderNumbers As IEnumerable(Of Integer) = Nothing
            Dim StringIDs As Generic.List(Of String) = Nothing
            Dim IDs As Generic.List(Of Integer) = Nothing
            Dim MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim MediaBroadcastWorksheetMarketDetailDates As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate) = Nothing
            Dim OrderNumberLineNumbers As IEnumerable(Of String) = Nothing
            Dim [Continue] As Boolean = True

            BroadcastImports = New Generic.List(Of AdvantageFramework.Database.Entities.BroadcastImport)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    Try

                        DbContext.Database.Connection.Open()
                        DataContext.Connection.Open()

                        IDs = New Generic.List(Of Integer)

                        StringIDs = (From IOL In ImportOrderList
                                     Where String.IsNullOrWhiteSpace(IOL.MediaPlanDetailLevelLineDataIDs) = False
                                     Select IOL.MediaPlanDetailLevelLineDataIDs).ToList

                        For Each StringID In StringIDs

                            IDs.AddRange(Split(StringID, ",").ToList.Select(Function(ID) CInt(ID)).ToArray)

                        Next

                        If ImportOrderList.Where(Function(IOL) IOL.ImportSource = Media.Methods.ImportSource.MediaPlanning).Any Then

                            MediaPlanDetailLevelLineDatas = DbContext.MediaPlanDetailLevelLineDatas.Where(Function(LD) IDs.Contains(LD.ID)).ToList

                        End If

                        If ImportOrderList.Where(Function(IOL) IOL.ImportSource = Media.Methods.ImportSource.BroadcastWorksheet).Any Then

                            MediaBroadcastWorksheetMarketDetailDates = DbContext.MediaBroadcastWorksheetMarketDetailDates.Where(Function(DD) IDs.Contains(DD.ID)).ToList

                        End If

                        OrderNumbers = ImportOrderList.Where(Function(IOL) IOL.OrderNumber.HasValue).Select(Function(IOL) IOL.OrderNumber.Value).Distinct.ToArray

                        If OrderNumbers IsNot Nothing AndAlso OrderNumbers.Count > 0 Then

                            If ImportOrderList.Where(Function(IOL) IOL.MediaType = "T").Any Then

                                'CancelledImportOrders.AddRange(From Entity In ImportOrderList
                                '                               Join TV In AdvantageFramework.Database.Procedures.TVOrderDetail.Load(DbContext) On Entity.OrderNumber Equals TV.TVOrderNumber And Entity.OrderLineNumber Equals TV.LineNumber
                                '                               Where OrderNumbers.Contains(TV.TVOrderNumber) AndAlso
                                '                                     TV.IsActiveRevision = 1 AndAlso
                                '                                     TV.IsLineCancelled = 1
                                '                               Select Entity)

                                OrderNumberLineNumbers = (From Entity In AdvantageFramework.Database.Procedures.TVOrderDetail.Load(DbContext)
                                                          Where OrderNumbers.Contains(Entity.TVOrderNumber) AndAlso
                                                                Entity.IsActiveRevision = 1 AndAlso
                                                                Entity.IsLineCancelled = 1
                                                          Select Entity.TVOrderNumber.ToString & "|" & Entity.LineNumber.ToString).ToList

                                CancelledImportOrders.AddRange(From Entity In ImportOrderList
                                                               Where Entity.OrderNumber.HasValue AndAlso
                                                                     Entity.OrderLineNumber.HasValue AndAlso
                                                                     OrderNumberLineNumbers.Contains(Entity.OrderNumber.Value & "|" & Entity.OrderLineNumber.Value)
                                                               Select Entity)

                            End If

                            If ImportOrderList.Where(Function(IOL) IOL.MediaType = "R").Any Then

                                'CancelledImportOrders.AddRange(From Entity In ImportOrderList
                                '                               Join Radio In AdvantageFramework.Database.Procedures.RadioOrderDetail.Load(DbContext) On Entity.OrderNumber Equals Radio.RadioOrderNumber And Entity.OrderLineNumber Equals Radio.LineNumber
                                '                               Where OrderNumbers.Contains(Radio.RadioOrderNumber) AndAlso
                                '                                     Radio.IsActiveRevision = 1 AndAlso
                                '                                     Radio.IsLineCancelled = 1
                                '                               Select Entity)

                                OrderNumberLineNumbers = (From Entity In AdvantageFramework.Database.Procedures.RadioOrderDetail.Load(DbContext)
                                                          Where OrderNumbers.Contains(Entity.RadioOrderNumber) AndAlso
                                                                Entity.IsActiveRevision = 1 AndAlso
                                                                Entity.IsLineCancelled = 1
                                                          Select Entity.RadioOrderNumber.ToString & "|" & Entity.LineNumber.ToString).ToList

                                CancelledImportOrders.AddRange(From Entity In ImportOrderList
                                                               Where Entity.OrderNumber.HasValue AndAlso
                                                                     Entity.OrderLineNumber.HasValue AndAlso
                                                                     OrderNumberLineNumbers.Contains(Entity.OrderNumber.Value & "|" & Entity.OrderLineNumber.Value)
                                                               Select Entity)

                            End If

                            If ImportOrderList.Where(Function(IOL) IOL.MediaType = "I").Any Then

                                'CancelledImportOrders.AddRange(From Entity In ImportOrderList
                                '                               Join Internet In AdvantageFramework.Database.Procedures.InternetOrderDetail.Load(DbContext) On Entity.OrderNumber Equals Internet.InternetOrderOrderNumber And Entity.OrderLineNumber Equals Internet.LineNumber
                                '                               Where OrderNumbers.Contains(Internet.InternetOrderOrderNumber) AndAlso
                                '                                     Internet.IsActiveRevision = 1 AndAlso
                                '                                     Internet.IsLineCancelled = 1
                                '                               Select Entity)

                                OrderNumberLineNumbers = (From Entity In AdvantageFramework.Database.Procedures.InternetOrderDetail.Load(DbContext)
                                                          Where OrderNumbers.Contains(Entity.InternetOrderOrderNumber) AndAlso
                                                                Entity.IsActiveRevision = 1 AndAlso
                                                                Entity.IsLineCancelled = 1
                                                          Select Entity.InternetOrderOrderNumber.ToString & "|" & Entity.LineNumber.ToString).ToList

                                CancelledImportOrders.AddRange(From Entity In ImportOrderList
                                                               Where Entity.OrderNumber.HasValue AndAlso
                                                                     Entity.OrderLineNumber.HasValue AndAlso
                                                                     OrderNumberLineNumbers.Contains(Entity.OrderNumber.Value & "|" & Entity.OrderLineNumber.Value)
                                                               Select Entity)

                            End If

                            If ImportOrderList.Where(Function(IOL) IOL.MediaType = "M").Any Then

                                'CancelledImportOrders.AddRange(From Entity In ImportOrderList
                                '                               Join Magazine In AdvantageFramework.Database.Procedures.MagazineOrderDetail.Load(DbContext) On Entity.OrderNumber Equals Magazine.MagazineOrderNumber And Entity.OrderLineNumber Equals Magazine.LineNumber
                                '                               Where OrderNumbers.Contains(Magazine.MagazineOrderNumber) AndAlso
                                '                                     Magazine.IsActiveRevision = 1 AndAlso
                                '                                     Magazine.IsLineCancelled = 1
                                '                               Select Entity)

                                OrderNumberLineNumbers = (From Entity In AdvantageFramework.Database.Procedures.MagazineOrderDetail.Load(DbContext)
                                                          Where OrderNumbers.Contains(Entity.MagazineOrderNumber) AndAlso
                                                                Entity.IsActiveRevision = 1 AndAlso
                                                                Entity.IsLineCancelled = 1
                                                          Select Entity.MagazineOrderNumber.ToString & "|" & Entity.LineNumber.ToString).ToList

                                CancelledImportOrders.AddRange(From Entity In ImportOrderList
                                                               Where Entity.OrderNumber.HasValue AndAlso
                                                                     Entity.OrderLineNumber.HasValue AndAlso
                                                                     OrderNumberLineNumbers.Contains(Entity.OrderNumber.Value & "|" & Entity.OrderLineNumber.Value)
                                                               Select Entity)

                            End If

                            If ImportOrderList.Where(Function(IOL) IOL.MediaType = "N").Any Then

                                'CancelledImportOrders.AddRange(From Entity In ImportOrderList
                                '                               Join Newspaper In AdvantageFramework.Database.Procedures.NewspaperOrderDetail.Load(DbContext) On Entity.OrderNumber Equals Newspaper.NewspaperOrderOrderNumber And Entity.OrderLineNumber Equals Newspaper.LineNumber
                                '                               Where OrderNumbers.Contains(Newspaper.NewspaperOrderOrderNumber) AndAlso
                                '                                     Newspaper.IsActiveRevision = 1 AndAlso
                                '                                     Newspaper.IsLineCancelled = 1
                                '                               Select Entity)

                                OrderNumberLineNumbers = (From Entity In AdvantageFramework.Database.Procedures.NewspaperOrderDetail.Load(DbContext)
                                                          Where OrderNumbers.Contains(Entity.NewspaperOrderOrderNumber) AndAlso
                                                                Entity.IsActiveRevision = 1 AndAlso
                                                                Entity.IsLineCancelled = 1
                                                          Select Entity.NewspaperOrderOrderNumber.ToString & "|" & Entity.LineNumber.ToString).ToList

                                CancelledImportOrders.AddRange(From Entity In ImportOrderList
                                                               Where Entity.OrderNumber.HasValue AndAlso
                                                                     Entity.OrderLineNumber.HasValue AndAlso
                                                                     OrderNumberLineNumbers.Contains(Entity.OrderNumber.Value & "|" & Entity.OrderLineNumber.Value)
                                                               Select Entity)

                            End If

                            If ImportOrderList.Where(Function(IOL) IOL.MediaType = "O").Any Then

                                'CancelledImportOrders.AddRange(From Entity In ImportOrderList
                                '                               Join Outdoor In AdvantageFramework.Database.Procedures.OutOfHomeOrderDetail.Load(DbContext) On Entity.OrderNumber Equals Outdoor.OutofHomeOrderNumber And Entity.OrderLineNumber Equals Outdoor.LineNumber
                                '                               Where OrderNumbers.Contains(Outdoor.OutofHomeOrderNumber) AndAlso
                                '                                     Outdoor.IsActiveRevision = 1 AndAlso
                                '                                     Outdoor.IsLineCancelled = 1
                                '                               Select Entity)

                                OrderNumberLineNumbers = (From Entity In AdvantageFramework.Database.Procedures.OutOfHomeOrderDetail.Load(DbContext)
                                                          Where OrderNumbers.Contains(Entity.OutofHomeOrderNumber) AndAlso
                                                                Entity.IsActiveRevision = 1 AndAlso
                                                                Entity.IsLineCancelled = 1
                                                          Select Entity.OutofHomeOrderNumber.ToString & "|" & Entity.LineNumber.ToString).ToList

                                CancelledImportOrders.AddRange(From Entity In ImportOrderList
                                                               Where Entity.OrderNumber.HasValue AndAlso
                                                                     Entity.OrderLineNumber.HasValue AndAlso
                                                                     OrderNumberLineNumbers.Contains(Entity.OrderNumber.Value & "|" & Entity.OrderLineNumber.Value)
                                                               Select Entity)

                            End If

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        [Continue] = False
                    End Try

                    If [Continue] Then

                        Try

                            DbTransaction = DbContext.Database.BeginTransaction()

                            Try

                                BroadcastImportID = (From Entity In DataContext.BroadcastImports
                                                     Select Entity.ID).Max + 1

                            Catch ex As Exception
                                BroadcastImportID = 1
                            End Try

                            For Each ImportOrder In ImportOrderList

                                If (ImportOrder.ImportSource = Media.ImportSource.MediaPlanning AndAlso (NewAndRevised OrElse (ImportOrder.IsRevision = False AndAlso NewOnly))) OrElse
                                        ImportOrder.ImportSource <> Media.ImportSource.MediaPlanning Then

                                    'If AdvantageFramework.Media.CheckForCancelledOrderLine(DbContext, ImportOrder) = False Then
                                    If CancelledImportOrders.Contains(ImportOrder) = False Then

                                        If AdvantageFramework.Media.CheckForAlreadyOrderedNewOrder(ImportOrder, MediaPlanDetailLevelLineDatas, MediaBroadcastWorksheetMarketDetailDates) = False Then

                                            If ImportOrder.MediaType = "R" OrElse ImportOrder.MediaType = "T" Then

                                                If AdvantageFramework.Media.CreateBroadcastImportFromImportOrder(DbContext, DataContext, ImportOrder, ShowOrderDescription, OrderDescription, BroadcastImportID, BroadcastImports, MediaInterface:=MediaInterface) = False Then

                                                    Throw New Exception("Failed to create orders.")

                                                End If

                                                BroadcastImportID += 1

                                            Else

                                                If AdvantageFramework.Media.DirectPostImportOrder(DbContext, DataContext, ImportOrder, ShowOrderDescription, OrderDescription) = False Then

                                                    Throw New Exception("Failed to create orders.")

                                                End If

                                            End If

                                        End If

                                    Else

                                        ImportOrder.EntityError = "Can't modify a cancelled line."
                                        CancelledImportOrders.Add(ImportOrder)

                                    End If

                                End If

                            Next

                            BulkInsertBroadcastImports(DbContext, DbTransaction, BroadcastImports)

                            DbContext.SaveChanges()
                            DataContext.SubmitChanges()

                            DbTransaction.Commit()

                            Saved = True

                            If ImportOrderList.Any() Then

                                If ImportOrderList.Any(Function(Entity) Entity.MediaType = "N") Then

                                    If AdvantageFramework.Media.ImportOrdersFromDirectPost(DbContext, DbContext.UserCode, "", "N", DirectPostMessage) = False Then

                                        AdvantageFramework.Media.ImportOrdersFromDirectPostCleanup(DbContext, DbContext.UserCode, "", "N", DirectPostMessage)

                                        ImportOrderList.ForEach(Function(Entity) Entity.EntityError = DirectPostMessage)

                                        AllDirectPostMessages &= System.Environment.NewLine & DirectPostMessage

                                    End If

                                End If

                                If ImportOrderList.Any(Function(Entity) Entity.MediaType = "M") Then

                                    If AdvantageFramework.Media.ImportOrdersFromDirectPost(DbContext, DbContext.UserCode, "", "M", DirectPostMessage) = False Then

                                        AdvantageFramework.Media.ImportOrdersFromDirectPostCleanup(DbContext, DbContext.UserCode, "", "M", DirectPostMessage)

                                        ImportOrderList.ForEach(Function(Entity) Entity.EntityError = DirectPostMessage)

                                        AllDirectPostMessages &= System.Environment.NewLine & DirectPostMessage

                                    End If

                                End If

                                If ImportOrderList.Any(Function(Entity) Entity.MediaType = "O") Then

                                    If AdvantageFramework.Media.ImportOrdersFromDirectPost(DbContext, DbContext.UserCode, "", "O", DirectPostMessage) = False Then

                                        AdvantageFramework.Media.ImportOrdersFromDirectPostCleanup(DbContext, DbContext.UserCode, "", "O", DirectPostMessage)

                                        ImportOrderList.ForEach(Function(Entity) Entity.EntityError = DirectPostMessage)

                                        AllDirectPostMessages &= System.Environment.NewLine & DirectPostMessage

                                    End If

                                End If

                                If ImportOrderList.Any(Function(Entity) Entity.MediaType = "I") Then

                                    If AdvantageFramework.Media.ImportOrdersFromDirectPost(DbContext, DbContext.UserCode, "", "I", DirectPostMessage) = False Then

                                        AdvantageFramework.Media.ImportOrdersFromDirectPostCleanup(DbContext, DbContext.UserCode, "", "I", DirectPostMessage)

                                        ImportOrderList.ForEach(Function(Entity) Entity.EntityError = DirectPostMessage)

                                        AllDirectPostMessages &= System.Environment.NewLine & DirectPostMessage

                                    End If

                                End If

                                If ImportOrderList.Any(Function(Entity) Entity.MediaType = "R") Then

                                    If AdvantageFramework.Media.ImportOrdersFromDirectPost(DbContext, DbContext.UserCode, "", "R", DirectPostMessage) = False Then

                                        AdvantageFramework.Media.ImportOrdersFromDirectPostCleanup(DbContext, DbContext.UserCode, "", "R", DirectPostMessage)

                                        ImportOrderList.ForEach(Function(Entity) Entity.EntityError = DirectPostMessage)

                                        AllDirectPostMessages &= System.Environment.NewLine & DirectPostMessage

                                    End If

                                End If

                                If ImportOrderList.Any(Function(Entity) Entity.MediaType = "T") Then

                                    If AdvantageFramework.Media.ImportOrdersFromDirectPost(DbContext, DbContext.UserCode, "", "T", DirectPostMessage) = False Then

                                        AdvantageFramework.Media.ImportOrdersFromDirectPostCleanup(DbContext, DbContext.UserCode, "", "T", DirectPostMessage)

                                        ImportOrderList.ForEach(Function(Entity) Entity.EntityError = DirectPostMessage)

                                        AllDirectPostMessages &= System.Environment.NewLine & DirectPostMessage

                                    End If

                                End If

                                If String.IsNullOrWhiteSpace(AllDirectPostMessages) = False Then

                                    If CancelledImportOrders.Any Then

                                        AllDirectPostMessages &= System.Environment.NewLine & "Can't modify a cancelled line."

                                    End If

                                    'AllDirectPostMessages = "An error occured while creating orders. Please contact software support." & System.Environment.NewLine & AllDirectPostMessages

                                    If ShowMessageBox Then AdvantageFramework.Navigation.ShowMessageBox(AllDirectPostMessages.Trim)

                                Else

                                    If CancelledImportOrders.Any Then

                                        AllDirectPostMessages &= "Create orders is complete." & System.Environment.NewLine & "Some order(s) could not be processed because the order/line(s) have been cancelled. The cancelled order/line(s) are noted in the window."

                                        If ShowMessageBox Then AdvantageFramework.Navigation.ShowMessageBox(AllDirectPostMessages)

                                    Else

                                        If ShowMessageBox Then AdvantageFramework.Navigation.ShowMessageBox("Create orders is complete.")

                                        DialogResultIsOK = True

                                    End If

                                End If

                            Else

                                If ShowMessageBox Then AdvantageFramework.Navigation.ShowMessageBox("Order file(s) created, [Direct Post], use the Media Generic Import to finalize order creation.")

                            End If

                            'If CancelledImportOrders.Any OrElse String.IsNullOrWhiteSpace(AllDirectPostMessages) = False Then

                            '    Me.FormAction = WinForm.Presentation.FormActions.Refreshing
                            '    Me.ShowWaitForm("Refreshing...")

                            '    ValidateAllRows()

                            '    RibbonBarOptions_Actions.SecurityEnabled = False
                            '    RibbonBarOptions_OrderTypes.SecurityEnabled = False
                            '    RibbonBarOptions_Actions.Visible = False
                            '    RibbonBarOptions_OrderTypes.Visible = False

                            '    RibbonBarFilePanel_System.Visible = True

                            '    RibbonControlForm_MainRibbon.Refresh()

                            'End If

                            'Me.FormAction = WinForm.Presentation.FormActions.None
                            'Me.CloseWaitForm()

                        Catch ex As Exception
                            If Not Saved Then
                                DbTransaction.Rollback()
                                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                                ErrorMessage += vbCrLf & ex.Message
                                'ErrorMessage += vbCrLf & vbCrLf & ex.StackTrace
                            End If

                        Finally

                            '    Me.FormAction = WinForm.Presentation.FormActions.None
                            '    Me.CloseWaitForm()

                        End Try

                    End If

                End Using

            End Using

            SaveOrders = Saved

        End Function
        <System.Runtime.CompilerServices.Extension>
        Private Function ToDataTable(Of T)(EntityList As IList(Of T)) As System.Data.DataTable

            Dim PropertyDescriptorCollection As System.ComponentModel.PropertyDescriptorCollection = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataRow As System.Data.DataRow = Nothing

            DataTable = New System.Data.DataTable

            PropertyDescriptorCollection = System.ComponentModel.TypeDescriptor.GetProperties(GetType(T))

            For Each Prop As System.ComponentModel.PropertyDescriptor In PropertyDescriptorCollection

                DataTable.Columns.Add(Prop.Name, If(Nullable.GetUnderlyingType(Prop.PropertyType), Prop.PropertyType))

            Next

            For Each Entity As T In EntityList

                DataRow = DataTable.NewRow()

                For Each Prop As System.ComponentModel.PropertyDescriptor In PropertyDescriptorCollection

                    DataRow(Prop.Name) = If(Prop.GetValue(Entity), DBNull.Value)

                Next

                DataTable.Rows.Add(DataRow)

            Next

            Return DataTable

        End Function
        Private Sub BulkInsertBroadcastImports(DbContext As AdvantageFramework.Database.DbContext, DbContextTransaction As Entity.DbContextTransaction,
                                               BroadcastImports As List(Of AdvantageFramework.Database.Entities.BroadcastImport))

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = BroadcastImports.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(DirectCast(DbContext.Database.Connection, SqlClient.SqlConnection), SqlClient.SqlBulkCopyOptions.CheckConstraints, DirectCast(DbContextTransaction.UnderlyingTransaction, SqlClient.SqlTransaction))

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "RECSEQ")
                    .ColumnMappings.Add("LinkID", "LINK_ID")
                    .ColumnMappings.Add("LineNumber", "LINE_NBR")
                    .ColumnMappings.Add("RevisionNumber", "REV_NBR")
                    .ColumnMappings.Add("MediaType", "MEDIA_TYPE")
                    .ColumnMappings.Add("SalesClassCode", "SALES_CLASS_CODE")
                    .ColumnMappings.Add("ClientCode", "CL_CODE")
                    .ColumnMappings.Add("ProductCode", "PRD_CODE")
                    .ColumnMappings.Add("VendorCode", "VN_CODE")
                    .ColumnMappings.Add("LineFlightFrom", "LINE_FLIGHT_FROM")
                    .ColumnMappings.Add("LineFlightTo", "LINE_FLIGHT_TO")
                    .ColumnMappings.Add("HeaderFlightFrom", "HDR_FLIGHT_FROM")
                    .ColumnMappings.Add("HeaderFlightTo", "HDR_FLIGHT_TO")
                    .ColumnMappings.Add("FlightType", "FLIGHT_TYPE")
                    .ColumnMappings.Add("Rate", "RATE")
                    .ColumnMappings.Add("NetRate", "NET_RATE")
                    .ColumnMappings.Add("GrossRate", "GROSS_RATE")
                    .ColumnMappings.Add("WeeklyNumber", "P1_52")
                    .ColumnMappings.Add("DivisionCode", "DIV_CODE")
                    .ColumnMappings.Add("CampaignCode", "CMP_CODE")
                    .ColumnMappings.Add("OrderDescription", "ORDER_DESC")
                    .ColumnMappings.Add("MarketCode", "MARKET_CODE")
                    .ColumnMappings.Add("StartTime", "START_TIME")
                    .ColumnMappings.Add("EndTime", "END_TIME")
                    .ColumnMappings.Add("TotalSpots", "TOTAL_SPOTS")
                    .ColumnMappings.Add("CommissionPercent", "COMM_PCT")
                    .ColumnMappings.Add("DeleteFlag", "DELETE_FLAG")
                    .ColumnMappings.Add("Buyer", "BUYER")
                    .ColumnMappings.Add("ClientPO", "CLIENT_PO")
                    .ColumnMappings.Add("Length", "LENGTH")
                    .ColumnMappings.Add("Programming", "PROGRAMMING")
                    .ColumnMappings.Add("Monday", "MONDAY")
                    .ColumnMappings.Add("Tuesday", "TUESDAY")
                    .ColumnMappings.Add("Wednesday", "WEDNESDAY")
                    .ColumnMappings.Add("Thrursday", "THURSDAY")
                    .ColumnMappings.Add("Friday", "FRIDAY")
                    .ColumnMappings.Add("Saturday", "SATURDAY")
                    .ColumnMappings.Add("Sunday", "SUNDAY")
                    .ColumnMappings.Add("OrderComment", "ORDER_COMMENT")
                    .ColumnMappings.Add("LineComment", "LINE_COMMENT")
                    .ColumnMappings.Add("ClientName", "CL_NAME")
                    .ColumnMappings.Add("VendorName", "VN_NAME")
                    .ColumnMappings.Add("MarketDescription", "MARKET_DESC")
                    .ColumnMappings.Add("MediaInterface", "MEDIA_INTERFACE")
                    .ColumnMappings.Add("PostFlag", "POST_FLAG")
                    .ColumnMappings.Add("DeleteOrder", "DELETE_ORDER")
                    .ColumnMappings.Add("ConvertImportLine", "CNVT_IMPRT_LINE")
                    .ColumnMappings.Add("IsPossibleDupe", "POSSIBLE_DUPE")
                    .ColumnMappings.Add("JobNumber", "JOB_NUMBER")
                    .ColumnMappings.Add("JobComponentNumber", "JOB_COMPONENT_NBR")
                    .ColumnMappings.Add("VendorRepCode", "VR_CODE")
                    .ColumnMappings.Add("VendorRepCode2", "VR_CODE2")
                    .ColumnMappings.Add("WeeklyCost", "WEEKLY_COST")
                    .ColumnMappings.Add("NetGross", "NET_GROSS_FLAG")
                    .ColumnMappings.Add("VendorCrossReferenceCode", "VN_CODE_XREF")
                    .ColumnMappings.Add("AirDate", "AIR_DATE")
                    .ColumnMappings.Add("BroadcastWeeks", "BC_WEEKS")
                    .ColumnMappings.Add("NetworkID", "NETWORK_ID")
                    .ColumnMappings.Add("Netcharge", "NETCHARGE")
                    .ColumnMappings.Add("AdditionalCharge", "ADDL_CHARGE")
                    .ColumnMappings.Add("Date1", "DATE1")
                    .ColumnMappings.Add("Date2", "DATE2")
                    .ColumnMappings.Add("Date3", "DATE3")
                    .ColumnMappings.Add("Date4", "DATE4")
                    .ColumnMappings.Add("Date5", "DATE5")
                    .ColumnMappings.Add("Date6", "DATE6")
                    .ColumnMappings.Add("BuyMonth", "BUY_MONTH")
                    .ColumnMappings.Add("BuyYear", "BUY_YEAR")
                    .ColumnMappings.Add("RebatePercent", "REBATE_PCT")
                    .ColumnMappings.Add("RebateAmount", "REBATE_AMT")
                    .ColumnMappings.Add("MarkupPercent", "MARKUP_PCT")
                    .ColumnMappings.Add("PlanIDs", "PLAN_IDS")
                    .ColumnMappings.Add("CalendarType", "CAL_TYPE")
                    .ColumnMappings.Add("DaypartCode", "DAYPART_CODE")
                    .ColumnMappings.Add("EstimateNumber", "ESTIMATE_NBR")
                    .ColumnMappings.Add("PackageName", "PACKAGE_NAME")
                    .ColumnMappings.Add("Remarks", "REMARKS")
                    .ColumnMappings.Add("UserCode", "USER_ID")
                    .ColumnMappings.Add("IsQuote", "IS_QUOTE")
                    .ColumnMappings.Add("ProcessStatus", "PRC_STATUS")
                    .ColumnMappings.Add("OrderCopy", "ORDER_COPY")
                    .ColumnMappings.Add("MiscInfo", "MISC_INFO")
                    .ColumnMappings.Add("MaterialNotes", "MATL_NOTES")
                    .ColumnMappings.Add("PositionInfo", "POSITION_INFO")
                    .ColumnMappings.Add("CloseInfo", "CLOSE_INFO")
                    .ColumnMappings.Add("RateInfo", "RATE_INFO")
                    .ColumnMappings.Add("AdNumber", "AD_NBR")
                    .ColumnMappings.Add("BuyerEmployeeCode", "BUYER_EMP_CODE")
                    .ColumnMappings.Add("CableNetworkStationCode", "CABLE_NETWORK_STATION_CODE")
                    .ColumnMappings.Add("DaypartID", "DAY_PART_ID")
                    .ColumnMappings.Add("ValueAdded", "ADDED_VALUE")
                    .ColumnMappings.Add("Bookend", "BOOKEND")
                    .ColumnMappings.Add("VendorOrderLine", "VENDOR_ORDER_LINE")
                    .ColumnMappings.Add("BatchID", "BATCH_ID ")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "BRDCAST_IMPORT"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub

#Region "   Import Credit Card Staging "

        Private Sub FillImportCreditCardStagingValues(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportCreditCardStaging As AdvantageFramework.Database.Entities.ImportCreditCardStaging)

            'objects
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim NumberOfDecimals As Int16 = Nothing

            If ImportCreditCardStaging IsNot Nothing Then

                Try

                    If String.IsNullOrEmpty(ImportCreditCardStaging.EmployeeCode) = True AndAlso
                   (String.IsNullOrEmpty(ImportCreditCardStaging.EmployeeFirstName) = False OrElse
                    String.IsNullOrEmpty(ImportCreditCardStaging.EmployeeLastName) = False) Then

                        Try

                            ImportCreditCardStaging.EmployeeCode = (From Employee In AdvantageFramework.Database.Procedures.EmployeeView.LoadCore(DbContext).ToList
                                                                    Where Employee.LastName.ToUpper = If(String.IsNullOrEmpty(ImportCreditCardStaging.EmployeeLastName), Employee.LastName, ImportCreditCardStaging.EmployeeLastName).ToUpper AndAlso
                                                                          Employee.FirstName.ToUpper = If(String.IsNullOrEmpty(ImportCreditCardStaging.EmployeeFirstName), Employee.LastName, ImportCreditCardStaging.EmployeeFirstName).ToUpper
                                                                    Select Employee.Code).FirstOrDefault

                        Catch ex As Exception
                            ImportCreditCardStaging.EmployeeCode = Nothing
                        End Try

                    End If

                    If String.IsNullOrEmpty(ImportCreditCardStaging.EmployeeCode) AndAlso String.IsNullOrEmpty(ImportCreditCardStaging.AccountNumber) = False Then

                        Try

                            ImportCreditCardStaging.EmployeeCode = (From Employee In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                                                    Where Employee.AccountNumber.ToUpper = ImportCreditCardStaging.AccountNumber.ToUpper
                                                                    Select Employee.Code).FirstOrDefault

                        Catch ex As Exception
                            ImportCreditCardStaging.EmployeeCode = Nothing
                        End Try

                    End If

                    If ImportCreditCardStaging.JobNumber.HasValue Then

                        Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, ImportCreditCardStaging.JobNumber)

                        If Job IsNot Nothing Then

                            ImportCreditCardStaging.ClientCode = Job.ClientCode
                            ImportCreditCardStaging.DivisionCode = Job.DivisionCode
                            ImportCreditCardStaging.ProductCode = Job.ProductCode

                            If Job.JobComponents.Count = 1 Then

                                ImportCreditCardStaging.JobComponentNumber = Job.JobComponents.SingleOrDefault.Number
                                ImportCreditCardStaging.JobComponentID = Job.JobComponents.SingleOrDefault.ID

                            ElseIf ImportCreditCardStaging.JobComponentNumber.HasValue Then

                                Try
                                    ' get the job component ID - it is used in the grid w/ auto filtering but not allowed as a field to import
                                    ImportCreditCardStaging.JobComponentID = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Job.Number, ImportCreditCardStaging.JobComponentNumber).ID

                                Catch ex As Exception
                                    ImportCreditCardStaging.JobComponentID = Nothing
                                    ImportCreditCardStaging.JobComponentNumber = Nothing
                                End Try

                            End If

                        End If

                    Else

                        ImportCreditCardStaging.JobComponentNumber = Nothing ' can't have a job component w/o job
                        ImportCreditCardStaging.JobComponentID = Nothing ' can't have a job component w/o job

                        If String.IsNullOrEmpty(ImportCreditCardStaging.ClientCode) = False Then

                            If String.IsNullOrEmpty(ImportCreditCardStaging.DivisionCode) Then ' fill in division only if empty & single active division

                                Try

                                    ImportCreditCardStaging.DivisionCode = (From Entity In AdvantageFramework.Database.Procedures.Division.Load(DbContext)
                                                                            Where Entity.IsActive = 1 AndAlso
                                                                                  Entity.ClientCode.ToUpper = ImportCreditCardStaging.ClientCode.ToUpper
                                                                            Select Entity.Code).SingleOrDefault

                                Catch ex As Exception
                                    ImportCreditCardStaging.DivisionCode = Nothing
                                End Try

                            End If

                            If String.IsNullOrEmpty(ImportCreditCardStaging.DivisionCode) = False AndAlso
                               String.IsNullOrEmpty(ImportCreditCardStaging.ProductCode) Then ' fill in product only if empty & single active product

                                Try

                                    ImportCreditCardStaging.ProductCode = (From Entity In AdvantageFramework.Database.Procedures.Product.Load(DbContext)
                                                                           Where Entity.IsActive = 1 AndAlso
                                                                                 Entity.DivisionCode.ToUpper = ImportCreditCardStaging.DivisionCode.ToUpper AndAlso
                                                                                 Entity.ClientCode.ToUpper = ImportCreditCardStaging.ClientCode.ToUpper
                                                                           Select Entity.Code).SingleOrDefault

                                Catch ex As Exception
                                    ImportCreditCardStaging.ProductCode = Nothing
                                End Try

                            End If

                        End If

                    End If

                    If ImportCreditCardStaging.Quantity.HasValue AndAlso ImportCreditCardStaging.Rate.HasValue Then

                        PropertyDescriptor = AdvantageFramework.BaseClasses.Entity.LoadProperty(AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.Amount)

                        If PropertyDescriptor IsNot Nothing Then

                            NumberOfDecimals = AdvantageFramework.BaseClasses.Entity.LoadPropertyScale(PropertyDescriptor)

                        Else

                            NumberOfDecimals = 2

                        End If

                        ImportCreditCardStaging.Amount = AdvantageFramework.BillingSystem.CalculateAmount(ImportCreditCardStaging.Rate, ImportCreditCardStaging.Quantity, NumberOfDecimals)

                    ElseIf ImportCreditCardStaging.Quantity.HasValue AndAlso ImportCreditCardStaging.Amount.HasValue Then

                        PropertyDescriptor = AdvantageFramework.BaseClasses.Entity.LoadProperty(AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.Rate)

                        If PropertyDescriptor IsNot Nothing Then

                            NumberOfDecimals = AdvantageFramework.BaseClasses.Entity.LoadPropertyScale(PropertyDescriptor)

                        Else

                            NumberOfDecimals = 4

                        End If

                        ImportCreditCardStaging.Rate = AdvantageFramework.BillingSystem.CalculateRate(ImportCreditCardStaging.Quantity, ImportCreditCardStaging.Amount, NumberOfDecimals)

                    End If

                    If ImportCreditCardStaging.ExpenseReportDate.HasValue = False Then

                        ImportCreditCardStaging.ExpenseReportDate = System.DateTime.Today

                    End If

                    If ImportCreditCardStaging.ItemDate.HasValue = False Then

                        ImportCreditCardStaging.ItemDate = System.DateTime.Today

                    End If

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Function CreateImportCreditCardStaging(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                       ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                       ByVal ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail),
                                                       ByVal FileLineData As Object, ByVal BatchName As String, ByVal AutoTrimOverFlowData As Boolean,
                                                       ByVal DataTable As System.Data.DataTable)

            'objects
            Dim Created As Boolean = True
            Dim ImportCreditCardStaging As AdvantageFramework.Database.Entities.ImportCreditCardStaging = Nothing

            Try

                ImportCreditCardStaging = New AdvantageFramework.Database.Entities.ImportCreditCardStaging

                ImportCreditCardStaging.DbContext = DbContext
                ImportCreditCardStaging.BatchName = BatchName

                CreateEntityFromTemplateDataTable(ImportTemplate, DataTable, FileLineData, ImportCreditCardStaging, AutoTrimOverFlowData)

                FillImportCreditCardStagingValues(DbContext, ImportCreditCardStaging)

                If ImportTemplate.Type = Methods.ImportTemplateTypes.ExpenseReport_CreditCard Then

                    ImportCreditCardStaging.CreditCardFlag = True

                Else

                    ImportCreditCardStaging.CreditCardFlag = False

                End If

                If AdvantageFramework.Database.Procedures.ImportCreditCardStaging.Insert(DbContext, ImportCreditCardStaging) = False Then

                    Created = False

                    Try

                        DbContext.ImportCreditCardStagings.Remove(ImportCreditCardStaging)

                    Catch ex As Exception

                    End Try

                End If

            Catch ex As Exception
                Created = False
            Finally
                CreateImportCreditCardStaging = Created
            End Try

        End Function

#End Region

#Region "   Cleared Checks "

        Private Function CreateImportClearedChecksStaging(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                          ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                          ByVal ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail),
                                                          ByVal FileLineData As Object, ByVal FileName As String, ByVal BatchName As String,
                                                          ByVal AutoTrimOverFlowData As Boolean, ByVal BankCode As String,
                                                          ByVal DataTable As System.Data.DataTable)

            'objects
            Dim Created As Boolean = True
            Dim ImportClearedChecksStaging As AdvantageFramework.Database.Entities.ImportClearedChecksStaging = Nothing

            Try

                ImportClearedChecksStaging = New AdvantageFramework.Database.Entities.ImportClearedChecksStaging

                ImportClearedChecksStaging.DbContext = DbContext
                ImportClearedChecksStaging.BatchName = BatchName
                ImportClearedChecksStaging.BankCode = BankCode
                ImportClearedChecksStaging.FileName = FileName

                CreateEntityFromTemplateDataTable(ImportTemplate, DataTable, FileLineData, ImportClearedChecksStaging, AutoTrimOverFlowData)

                If AdvantageFramework.Database.Procedures.ImportClearedChecksStaging.Insert(DbContext, ImportClearedChecksStaging) = False Then

                    Created = False

                    Try

                        DbContext.ImportClearedChecksStagings.Remove(ImportClearedChecksStaging)

                    Catch ex As Exception

                    End Try

                End If

            Catch ex As Exception
                Created = False
            Finally
                CreateImportClearedChecksStaging = Created
            End Try

        End Function
        Public Function ImportCSIPreferredPartnerFiles(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                       ByVal Files As Generic.List(Of String), ByRef BatchName As String, ByVal BankCode As String,
                                                       ByVal CSIReconciliationTemplate As AdvantageFramework.Importing.CSIReconciliationTemplates,
                                                       ByRef FailedLines As Generic.Dictionary(Of Integer, String)) As Boolean

            'objects
            Dim FilesImported As Boolean = False

            If Files IsNot Nothing AndAlso Files.Count > 0 Then

                If CSIReconciliationTemplate = CSIReconciliationTemplates.ComDataAC29File Then

                    FilesImported = ImportCSIPreferredPartnerFilesComDataAC29File(DbContext, Files, BatchName, BankCode, FailedLines)

                ElseIf CSIReconciliationTemplate = CSIReconciliationTemplates.FixedFileFormat Then

                    FilesImported = ImportCSIPreferredPartnerFilesFixedFileFormat(DbContext, Files, BatchName, BankCode, FailedLines)

                End If

            End If

            ImportCSIPreferredPartnerFiles = FilesImported

        End Function
        Private Function ImportCSIPreferredPartnerFilesComDataAC29File(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                       ByVal Files As Generic.List(Of String), ByRef BatchName As String, ByVal BankCode As String,
                                                                       ByRef FailedLines As Generic.Dictionary(Of Integer, String)) As Boolean

            'objects
            Dim FilesImported As Boolean = False
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim FileLines() As String = Nothing
            Dim FileLineData() As String = Nothing
            Dim StringList As Generic.List(Of String) = Nothing
            Dim ComDataAC29Files As Generic.List(Of AdvantageFramework.Importing.Classes.ComDataAC29File) = Nothing
            Dim ImportClearedChecksStaging As AdvantageFramework.Database.Entities.ImportClearedChecksStaging = Nothing
            Dim ExistingImportClearedChecksStaging As AdvantageFramework.Database.Entities.ImportClearedChecksStaging = Nothing
            Dim ClearedChecks As Generic.List(Of AdvantageFramework.Database.Entities.ImportClearedChecksStaging) = Nothing
            Dim FilesLinesImported As Boolean = False

            BatchName = CreateBatchName("CSI_ComDataAC29File")
            ComDataAC29Files = New Generic.List(Of AdvantageFramework.Importing.Classes.ComDataAC29File)

            If Files IsNot Nothing AndAlso Files.Count > 0 Then

                FilesImported = True

                For Each File In Files

                    FileLines = Nothing
                    StringList = Nothing
                    StreamReader = Nothing

                    Try

                        StreamReader = New System.IO.StreamReader(File)

                    Catch ex As Exception
                        StreamReader = Nothing
                    Finally

                        If StreamReader IsNot Nothing Then

                            StringList = New Generic.List(Of String)

                            Do While StreamReader.Peek <> -1

                                StringList.Add(StreamReader.ReadLine())

                            Loop

                            FileLines = StringList.ToArray

                            Try

                                StreamReader.Close()
                                StreamReader.Dispose()

                            Catch ex As Exception

                            End Try

                        End If

                    End Try

                    If FileLines IsNot Nothing AndAlso FileLines.Count > 0 Then

                        ComDataAC29Files.Add(New AdvantageFramework.Importing.Classes.ComDataAC29File(File, FileLines.ToList))

                    End If

                Next

                For Each ComDataAC29File In ComDataAC29Files

                    ClearedChecks = New Generic.List(Of AdvantageFramework.Database.Entities.ImportClearedChecksStaging)
                    FilesLinesImported = True

                    For Each ComDataAC29FileDetail In ComDataAC29File.ComDataAC29FileDetails

                        If String.IsNullOrWhiteSpace(ComDataAC29FileDetail.Line1001) = False AndAlso String.IsNullOrWhiteSpace(ComDataAC29FileDetail.Line1002) = False AndAlso String.IsNullOrWhiteSpace(ComDataAC29FileDetail.Line1003) = False Then

                            ImportClearedChecksStaging = CreateImportClearedChecksStagingFromComDataAC29FileDetail(DbContext, ComDataAC29FileDetail, BatchName, BankCode)

                            If ImportClearedChecksStaging Is Nothing Then

                                FailedLines.Add(Files.IndexOf(ComDataAC29File.File), ComDataAC29File.File & " - Failed inserting into database.")
                                FilesImported = False
                                FilesLinesImported = False

                            Else

                                Try

                                    ExistingImportClearedChecksStaging = ClearedChecks.SingleOrDefault(Function(Entity) Entity.CheckNumber = ImportClearedChecksStaging.CheckNumber)

                                Catch ex As Exception
                                    ExistingImportClearedChecksStaging = Nothing
                                End Try

                                If ExistingImportClearedChecksStaging IsNot Nothing Then

                                    ExistingImportClearedChecksStaging.CheckAmount += ImportClearedChecksStaging.CheckAmount

                                Else

                                    ClearedChecks.Add(ImportClearedChecksStaging)

                                End If

                            End If

                        End If

                    Next

                    For Each ClearedCheck In ClearedChecks

                        DbContext.ImportClearedChecksStagings.Add(ClearedCheck)

                    Next

                    AdvantageFramework.Importing.RenameFileAfterImport(ComDataAC29File.File, DbContext.UserCode)

                Next

                DbContext.SaveChanges()

            End If

            ImportCSIPreferredPartnerFilesComDataAC29File = FilesImported

        End Function
        Private Function ImportCSIPreferredPartnerFilesFixedFileFormat(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                       ByVal Files As Generic.List(Of String), ByRef BatchName As String, ByVal BankCode As String,
                                                                       ByRef FailedLines As Generic.Dictionary(Of Integer, String)) As Boolean

            'objects
            Dim FilesImported As Boolean = False
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim StringList As Generic.List(Of String) = Nothing
            Dim ImportClearedChecksStaging As AdvantageFramework.Database.Entities.ImportClearedChecksStaging = Nothing
            Dim ExistingImportClearedChecksStaging As AdvantageFramework.Database.Entities.ImportClearedChecksStaging = Nothing
            Dim ClearedChecks As Generic.List(Of AdvantageFramework.Database.Entities.ImportClearedChecksStaging) = Nothing

            BatchName = CreateBatchName("CSI_FixedFileFormat")

            If Files IsNot Nothing AndAlso Files.Count > 0 Then

                ClearedChecks = New Generic.List(Of AdvantageFramework.Database.Entities.ImportClearedChecksStaging)
                FilesImported = True

                For Each File In Files

                    StringList = Nothing
                    StreamReader = Nothing

                    Try

                        StreamReader = New System.IO.StreamReader(File)

                    Catch ex As Exception
                        StreamReader = Nothing
                    Finally

                        If StreamReader IsNot Nothing Then

                            StringList = New Generic.List(Of String)

                            Do While StreamReader.Peek <> -1

                                StringList.Add(StreamReader.ReadLine())

                            Loop

                            Try

                                StreamReader.Close()
                                StreamReader.Dispose()
                                StreamReader = Nothing

                            Catch ex As Exception

                            End Try

                        End If

                    End Try

                    If StringList IsNot Nothing AndAlso StringList.Count > 0 Then

                        For Each FileLine In StringList

                            If FileLine.Length >= 76 Then

                                ExistingImportClearedChecksStaging = Nothing

                                ImportClearedChecksStaging = New AdvantageFramework.Database.Entities.ImportClearedChecksStaging

                                ImportClearedChecksStaging.DbContext = DbContext
                                ImportClearedChecksStaging.BatchName = BatchName
                                ImportClearedChecksStaging.BankCode = BankCode
                                ImportClearedChecksStaging.FileName = File

                                ImportClearedChecksStaging.VendorName = ScrubFileData(FileLine.Substring(15, 25), GetType(String), True, 25, 0, 0, "", FileTypes.Fixed)
                                ImportClearedChecksStaging.CheckClearedDate = ScrubFileData(FileLine.Substring(40, 8), GetType(Date), True, 8, 0, 0, DateUtilities.DateFormat.YMD.ToString, FileTypes.Fixed)
                                ImportClearedChecksStaging.CheckNumber = ScrubFileData(FileLine.Substring(48, 15), GetType(String), True, 15, 0, 0, "", FileTypes.Fixed)
                                ImportClearedChecksStaging.CheckAmount = ScrubFileData(FileLine.Substring(63, 10) & "." & FileLine.Substring(73, 2), GetType(Decimal), True, 12, 10, 3, "", FileTypes.Fixed)

                                Try

                                    ExistingImportClearedChecksStaging = ClearedChecks.SingleOrDefault(Function(Entity) Entity.CheckNumber = ImportClearedChecksStaging.CheckNumber)

                                Catch ex As Exception
                                    ExistingImportClearedChecksStaging = Nothing
                                End Try

                                If ExistingImportClearedChecksStaging IsNot Nothing Then

                                    ExistingImportClearedChecksStaging.CheckAmount += ImportClearedChecksStaging.CheckAmount

                                Else

                                    ClearedChecks.Add(ImportClearedChecksStaging)

                                End If

                            End If

                        Next

                        AdvantageFramework.Importing.RenameFileAfterImport(File, DbContext.UserCode)

                    End If

                Next

                For Each ClearedCheck In ClearedChecks

                    DbContext.ImportClearedChecksStagings.Add(ClearedCheck)

                Next

                DbContext.SaveChanges()

            End If

            ImportCSIPreferredPartnerFilesFixedFileFormat = FilesImported

        End Function
        Private Function CreateImportClearedChecksStagingFromComDataAC29FileDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                                   ByVal ComDataAC29FileDetail As AdvantageFramework.Importing.Classes.ComDataAC29FileDetail,
                                                                                   ByVal BatchName As String, ByVal BankCode As String) As AdvantageFramework.Database.Entities.ImportClearedChecksStaging

            'objects
            Dim ImportClearedChecksStaging As AdvantageFramework.Database.Entities.ImportClearedChecksStaging = Nothing

            Try

                ImportClearedChecksStaging = New AdvantageFramework.Database.Entities.ImportClearedChecksStaging

                ImportClearedChecksStaging.DbContext = DbContext
                ImportClearedChecksStaging.BatchName = BatchName
                ImportClearedChecksStaging.BankCode = BankCode
                ImportClearedChecksStaging.FileName = ComDataAC29FileDetail.ComDataAC29File.File

                ImportClearedChecksStaging.CheckNumber = ComDataAC29FileDetail.GetCheckNumber
                ImportClearedChecksStaging.CheckAmount = ComDataAC29FileDetail.GetCheckAmount
                ImportClearedChecksStaging.VendorName = ComDataAC29FileDetail.GetVendorName
                ImportClearedChecksStaging.CheckClearedDate = ComDataAC29FileDetail.GetCheckClearedDate

            Catch ex As Exception
                ImportClearedChecksStaging = Nothing
            Finally
                CreateImportClearedChecksStagingFromComDataAC29FileDetail = ImportClearedChecksStaging
            End Try

        End Function

#End Region

#Region "   Accounts Payable "

        Private Function CreateImportAccountsPayableStaging(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                            ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                            ByVal ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail),
                                                            ByVal FileLineData As Object, ByVal BatchName As String, ByVal AutoTrimOverFlowData As Boolean,
                                                            ByVal ImportAccountPayables As Hashtable,
                                                            ByVal DataTable As System.Data.DataTable,
                                                            ByVal DataTableGL As System.Data.DataTable,
                                                            ByVal DataTableJob As System.Data.DataTable,
                                                            ByVal DataTableMedia As System.Data.DataTable,
                                                            ByVal StrataBroadcastDetailFileLines() As String,
                                                            ByVal ExistingImportAccountPayableList As Generic.List(Of AdvantageFramework.Database.Entities.ImportAccountPayable)) As Boolean

            'objects
            Dim Created As Boolean = True
            Dim ImportAccountPayable As AdvantageFramework.Database.Entities.ImportAccountPayable = Nothing
            Dim ImportAccountPayableGL As AdvantageFramework.Database.Entities.ImportAccountPayableGL = Nothing
            Dim ImportAccountPayableJob As AdvantageFramework.Database.Entities.ImportAccountPayableJob = Nothing
            Dim ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia = Nothing
            Dim ImportAccountPayableLookup As AdvantageFramework.Database.Entities.ImportAccountPayable = Nothing
            Dim StrataVoucher As String = Nothing
            Dim ImportAccountPayableMediaCopy As AdvantageFramework.Database.Entities.ImportAccountPayableMedia = Nothing
            Dim StrataBroadcastDetails As Generic.List(Of AdvantageFramework.Importing.Classes.StrataBroadcastDetail) = Nothing
            Dim ImportAccountPayableMediaList As Generic.List(Of AdvantageFramework.Database.Entities.ImportAccountPayableMedia) = Nothing
            Dim VendorCode As String = Nothing
            Dim VendorCrossReference As AdvantageFramework.Database.Entities.VendorCrossReference = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim ClientCrossReference As AdvantageFramework.Database.Entities.ClientCrossReference = Nothing

            Try

                DbContext.Configuration.AutoDetectChangesEnabled = False

                ImportAccountPayable = New AdvantageFramework.Database.Entities.ImportAccountPayable
                ImportAccountPayableGL = New AdvantageFramework.Database.Entities.ImportAccountPayableGL
                ImportAccountPayableJob = New AdvantageFramework.Database.Entities.ImportAccountPayableJob
                ImportAccountPayableMedia = New AdvantageFramework.Database.Entities.ImportAccountPayableMedia

                ImportAccountPayable.DbContext = DbContext
                ImportAccountPayable.BatchName = BatchName

                CreateEntityFromTemplateDataTable(ImportTemplate, DataTable, FileLineData, ImportAccountPayable, AutoTrimOverFlowData)
                CreateEntityFromTemplateDataTable(ImportTemplate, DataTableGL, FileLineData, ImportAccountPayableGL, AutoTrimOverFlowData)
                CreateEntityFromTemplateDataTable(ImportTemplate, DataTableJob, FileLineData, ImportAccountPayableJob, AutoTrimOverFlowData)
                CreateEntityFromTemplateDataTable(ImportTemplate, DataTableMedia, FileLineData, ImportAccountPayableMedia, AutoTrimOverFlowData)

                If ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedInternet AndAlso ImportAccountPayableMedia IsNot Nothing Then

                    Try

                        ImportAccountPayableMedia.MediaNetCharge = If(IsNumeric(FileLineData.Substring(140, 12)), CDec(FileLineData.Substring(140, 12)), 0) + If(IsNumeric(FileLineData.Substring(152, 12)), CDec(FileLineData.Substring(152, 12)), 0)

                    Catch ex As Exception
                        ImportAccountPayableMedia.MediaNetCharge = Nothing
                    End Try

                    If ImportAccountPayableMedia.MediaNetCharge.GetValueOrDefault(0) <> 0 AndAlso ImportAccountPayable.InvoiceTotalNet.GetValueOrDefault(0) = 0 Then

                        ImportAccountPayable.InvoiceTotalNet = ImportAccountPayableMedia.MediaNetCharge

                    End If

                End If

                If ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast AndAlso ImportAccountPayableMedia IsNot Nothing Then

                    StrataBroadcastDetails = New Generic.List(Of AdvantageFramework.Importing.Classes.StrataBroadcastDetail)

                    StrataVoucher = Mid(FileLineData, 1, 8).Trim

                    For Each Line In StrataBroadcastDetailFileLines

                        StrataBroadcastDetails.Add(New AdvantageFramework.Importing.Classes.StrataBroadcastDetail(Line))

                    Next

                    For Each OrderLineID In StrataBroadcastDetails.Where(Function(D) D.Voucher = StrataVoucher).Select(Function(D) D.OrderLineID).Distinct

                        ImportAccountPayableMediaCopy = ImportAccountPayableMedia.Copy

                        ImportAccountPayableMediaCopy.OrderID = StrataBroadcastDetails.FirstOrDefault.OrderID

                        If OrderLineID Is Nothing Then

                            ImportAccountPayableMediaCopy.LineDate = StrataBroadcastDetails.FirstOrDefault.Week
                            ImportAccountPayableMediaCopy.MediaQuantity = StrataBroadcastDetails.Where(Function(D) D.OrderLineID Is Nothing).Sum(Function(D) D.Spots)
                            ImportAccountPayableMediaCopy.MediaNetAmount = StrataBroadcastDetails.Where(Function(D) D.OrderLineID Is Nothing).Sum(Function(D) D.Cost)

                        Else

                            ImportAccountPayableMediaCopy.LineDate = StrataBroadcastDetails.Where(Function(D) D.OrderLineID = OrderLineID).FirstOrDefault.Week
                            ImportAccountPayableMediaCopy.MediaQuantity = StrataBroadcastDetails.Where(Function(D) D.OrderLineID = OrderLineID).Sum(Function(D) D.Spots)
                            ImportAccountPayableMediaCopy.MediaNetAmount = StrataBroadcastDetails.Where(Function(D) D.OrderLineID = OrderLineID).Sum(Function(D) D.Cost)

                        End If

                        ImportAccountPayableMediaCopy.OrderLineID = OrderLineID

                        If ImportAccountPayableMediaList Is Nothing Then

                            ImportAccountPayableMediaList = New Generic.List(Of AdvantageFramework.Database.Entities.ImportAccountPayableMedia)

                        End If

                        ImportAccountPayableMediaList.Add(ImportAccountPayableMediaCopy)

                        ImportAccountPayableMediaCopy = Nothing

                    Next

                    ImportAccountPayableMedia = Nothing

                End If

                If (ImportTemplate.Type = ImportTemplateTypes.AccountsPayable_Custom OrElse ImportTemplate.Type = ImportTemplateTypes.AccountsPayable_Generic) AndAlso
                        ImportTemplate.RecordSourceID.HasValue Then

                    Try

                        VendorCrossReference = (From VCR In AdvantageFramework.Database.Procedures.VendorCrossReference.LoadByRecordSourceID(DbContext, ImportTemplate.RecordSourceID.Value)
                                                Where VCR.SourceVendorCode = ImportAccountPayable.VendorCode
                                                Select VCR).SingleOrDefault

                    Catch ex As Exception
                        VendorCrossReference = Nothing
                    End Try

                End If

                If VendorCrossReference IsNot Nothing Then

                    ImportAccountPayable.VendorCode = VendorCrossReference.VendorCode

                Else

                    If String.IsNullOrWhiteSpace(ImportAccountPayable.VendorCode) = False Then

                        If ImportAccountPayable.VendorCode.Length > 6 Then

                            ImportAccountPayable.VendorCode = ImportAccountPayable.VendorCode.Substring(0, 6)

                        Else

                            ImportAccountPayable.VendorCode = ImportAccountPayable.VendorCode.Trim

                        End If

                    End If

                End If

                If ImportTemplate.Type = ImportTemplateTypes.AccountsPayable_Custom AndAlso ImportTemplate.RecordSourceID.HasValue Then

                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, ImportAccountPayable.VendorCode)

                    If Vendor IsNot Nothing Then

                        ImportAccountPayable.GLAccount = Vendor.DefaultAPAccount

                    End If

                    ClientCrossReference = (From CCR In AdvantageFramework.Database.Procedures.ClientCrossReference.LoadByRecordSourceID(DbContext, ImportTemplate.RecordSourceID.Value)
                                            Where CCR.SourceClientCode = ImportAccountPayableJob.ClientCode AndAlso
                                                  CCR.SourceProductCode = ImportAccountPayableJob.ProductCode
                                            Select CCR).SingleOrDefault

                    If ClientCrossReference IsNot Nothing Then

                        Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, ClientCrossReference.ClientCode, ClientCrossReference.DivisionCode, ClientCrossReference.ProductCode)

                        If Product IsNot Nothing AndAlso Product.Office IsNot Nothing Then

                            If ImportAccountPayableGL IsNot Nothing Then

                                ImportAccountPayableGL.GLACode = Product.Office.MediaAccruedAccountsPayableGLACode

                            End If

                            ImportAccountPayable.GLAccount = ReplaceOfficeSegment(DbContext, ImportAccountPayable.GLAccount, Product.Office.Code)

                        End If

                    End If

                End If

                Try

                    ImportAccountPayableLookup = ImportAccountPayables(ImportAccountPayable.VendorCode & "|" & ImportAccountPayable.InvoiceNumber)

                Catch ex As Exception
                    ImportAccountPayableLookup = Nothing
                End Try

                If ImportAccountPayableLookup Is Nothing Then

                    ImportAccountPayable.ImportTemplateID = ImportTemplate.ID

                    DbContext.ImportAccountPayables.Add(ImportAccountPayable)
                    ImportAccountPayables.Add(ImportAccountPayable.VendorCode & "|" & ImportAccountPayable.InvoiceNumber, ImportAccountPayable)

                Else

                    ImportAccountPayable = ImportAccountPayableLookup

                    If ImportAccountPayable.DbContext Is Nothing Then

                        DbContext.TryAttach(ImportAccountPayable)

                    End If

                End If

                If ImportAccountPayableGL IsNot Nothing Then

                    If String.IsNullOrEmpty(ImportAccountPayableGL.GLACode) = False OrElse
                            ImportAccountPayableGL.GLNetAmount IsNot Nothing Then

                        ImportAccountPayable.ImportAccountPayableGLs.Add(ImportAccountPayableGL)

                    End If

                End If

                If ImportAccountPayableJob IsNot Nothing Then

                    If ImportAccountPayableJob.PONumber IsNot Nothing OrElse
                            ImportAccountPayableJob.POLine IsNot Nothing OrElse
                            ImportAccountPayableJob.JobNumber IsNot Nothing OrElse
                            ImportAccountPayableJob.JobComponentNumber IsNot Nothing OrElse
                            String.IsNullOrEmpty(ImportAccountPayableJob.FunctionCode) = False OrElse
                            ImportAccountPayableJob.JobQuantity IsNot Nothing OrElse
                            ImportAccountPayableJob.JobNetAmount IsNot Nothing OrElse
                            ImportAccountPayableJob.JobVendorTax IsNot Nothing Then

                        ImportAccountPayable.ImportAccountPayableJobs.Add(ImportAccountPayableJob)

                    End If

                End If

                If ImportAccountPayableMedia IsNot Nothing Then

                    If String.IsNullOrEmpty(ImportAccountPayableMedia.MediaType) = False OrElse
                            ImportAccountPayableMedia.OrderID IsNot Nothing OrElse
                            ImportAccountPayableMedia.OrderNumber IsNot Nothing OrElse
                            String.IsNullOrEmpty(ImportAccountPayableMedia.Month) = False OrElse
                            ImportAccountPayableMedia.Year IsNot Nothing OrElse
                            String.IsNullOrEmpty(ImportAccountPayableMedia.SalesClassCode) = False OrElse
                            ImportAccountPayableMedia.OrderLineNumber IsNot Nothing OrElse
                            ImportAccountPayableMedia.LineDate IsNot Nothing OrElse
                            ImportAccountPayableMedia.MediaQuantity IsNot Nothing OrElse
                            ImportAccountPayableMedia.MediaNetAmount IsNot Nothing OrElse
                            ImportAccountPayableMedia.MediaVendorTax IsNot Nothing OrElse
                            ImportAccountPayableMedia.MediaNetCharge IsNot Nothing OrElse
                            ImportAccountPayableMedia.MediaMarkupPercent IsNot Nothing OrElse
                            ImportAccountPayableMedia.MediaAddAmount IsNot Nothing OrElse
                            ImportAccountPayableMedia.Length IsNot Nothing OrElse
                            String.IsNullOrEmpty(ImportAccountPayableMedia.DaypartCode) = False Then

                        ImportAccountPayable.ImportAccountPayableMedias.Add(ImportAccountPayableMedia)

                    End If

                ElseIf ImportAccountPayableMediaList IsNot Nothing Then

                    For Each ImportAccountPayableMedia In ImportAccountPayableMediaList

                        ImportAccountPayable.ImportAccountPayableMedias.Add(ImportAccountPayableMedia)

                    Next

                End If

                If ImportAccountPayable.ImportAccountPayableGLs.Count = 0 AndAlso ImportAccountPayable.ImportAccountPayableJobs.Count = 0 AndAlso ImportAccountPayable.ImportAccountPayableMedias.Count = 0 Then

                    If ExistingImportAccountPayableList.Where(Function(IAP) IAP.VendorCode = ImportAccountPayable.VendorCode AndAlso IAP.InvoiceNumber = ImportAccountPayable.InvoiceNumber).Any = False Then

                        ImportAccountPayables.Remove(ImportAccountPayable.VendorCode & "|" & ImportAccountPayable.InvoiceNumber)
                        DbContext.Detach(ImportAccountPayable)

                        Created = False

                    End If

                End If

            Catch ex As Exception
                Created = False
            Finally
                DbContext.Configuration.AutoDetectChangesEnabled = True
                CreateImportAccountsPayableStaging = Created
            End Try

        End Function
        Private Sub SaveAccountPayable(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                       ByRef FailedLines As Generic.Dictionary(Of Integer, String))

            Dim HasUpdateException As Boolean = False
            Dim UpdateException As System.Data.Entity.Core.UpdateException = Nothing
            Dim ImportAccountPayable As AdvantageFramework.Database.Entities.ImportAccountPayable = Nothing

            Try

                DbContext.SaveChanges()

            Catch ex As System.Data.Entity.Core.UpdateException

                UpdateException = ex
                HasUpdateException = True

                If FailedLines Is Nothing Then

                    FailedLines = New Generic.Dictionary(Of Integer, String)
                    FailedLines.Add(-1, "Bulk AP Save")

                End If

                While HasUpdateException

                    For Each ObjectStateEntry In UpdateException.StateEntries

                        ImportAccountPayable = DirectCast(ObjectStateEntry.Entity, AdvantageFramework.Database.Entities.ImportAccountPayable)

                        For Each ImportAccountPayableGL In ImportAccountPayable.ImportAccountPayableGLs.ToList

                            DbContext.Detach(ImportAccountPayableGL)

                        Next

                        For Each ImportAccountPayableJob In ImportAccountPayable.ImportAccountPayableJobs.ToList

                            DbContext.Detach(ImportAccountPayableJob)

                        Next

                        For Each ImportAccountPayableMedia In ImportAccountPayable.ImportAccountPayableMedias.ToList

                            DbContext.Detach(ImportAccountPayableMedia)

                        Next

                        DbContext.Detach(ImportAccountPayable)

                        Try

                            DbContext.SaveChanges()

                            HasUpdateException = False

                        Catch upex As System.Data.Entity.Core.UpdateException
                            UpdateException = upex
                            HasUpdateException = True
                        Catch ex2 As Exception

                        End Try

                    Next

                End While

            End Try

        End Sub
        Private Function ReplaceOfficeSegment(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerAccountCode As String,
                                              ByVal OfficeCode As String) As String

            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing
            Dim GeneralLedgerAccountNew As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim GLAccount As String = Nothing

            GLAccount = GeneralLedgerAccountCode

            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, GeneralLedgerAccountCode)

            If GeneralLedgerAccount IsNot Nothing Then

                GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByOfficeCode(DbContext, OfficeCode)

                If GeneralLedgerOfficeCrossReference IsNot Nothing Then

                    GeneralLedgerAccountNew = (From GL In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext)
                                               Where GL.GeneralLedgerOfficeCrossReferenceCode = GeneralLedgerOfficeCrossReference.Code AndAlso
                                                     GL.BaseCode = GeneralLedgerAccount.BaseCode AndAlso
                                                     (GeneralLedgerAccount.DepartmentCode Is Nothing OrElse GL.DepartmentCode = GeneralLedgerAccount.DepartmentCode) AndAlso
                                                     (GeneralLedgerAccount.OtherCode Is Nothing OrElse GL.OtherCode = GeneralLedgerAccount.OtherCode)
                                               Select GL).SingleOrDefault

                    If GeneralLedgerAccountNew IsNot Nothing Then

                        GLAccount = GeneralLedgerAccountNew.Code

                    End If

                End If

            End If

            ReplaceOfficeSegment = GLAccount

        End Function
        Public Sub ValidateAccountsPayableBatch(ByVal Session As AdvantageFramework.Security.Session, ByVal BatchName As String)

            Dim MinImportID As Integer = 0
            Dim MaxImportID As Integer = 0
            Dim ImportAccountPayables As Generic.List(Of AdvantageFramework.Database.Entities.ImportAccountPayable) = Nothing
            Dim SqlParameterBatchName As SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserCode As SqlClient.SqlParameter = Nothing
            Dim ImportIDsWithErrors As Integer() = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    ImportAccountPayables = AdvantageFramework.Database.Procedures.ImportAccountPayable.LoadByBatchName(DbContext, BatchName).ToList

                Catch ex As Exception
                    ImportAccountPayables = Nothing
                End Try

                If ImportAccountPayables IsNot Nothing AndAlso ImportAccountPayables.Count > 0 Then

                    MinImportID = ImportAccountPayables.Min(Function(AP) AP.ID)
                    MaxImportID = ImportAccountPayables.Max(Function(AP) AP.ID)

                End If

                ImportIDsWithErrors = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DISTINCT IMPORT_ID FROM dbo.IMP_AP_ERROR WHERE IMPORT_ID between {0} and {1}", MinImportID, MaxImportID)).ToArray
                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.IMP_AP_ERROR WHERE IMPORT_ID between {0} and {1}", MinImportID, MaxImportID))

                SqlParameterBatchName = New SqlClient.SqlParameter("@batch_name", SqlDbType.VarChar)
                SqlParameterUserCode = New SqlClient.SqlParameter("@user_code", SqlDbType.VarChar)

                SqlParameterBatchName.Value = BatchName
                SqlParameterUserCode.Value = Session.UserCode

                DbContext.Database.ExecuteSqlCommand("exec advsp_ap_import_validate_staging_tables @batch_name, @user_code", SqlParameterBatchName, SqlParameterUserCode)

                If ImportIDsWithErrors IsNot Nothing AndAlso ImportIDsWithErrors.Any Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.IMP_AP_HEADER SET ON_HOLD = 0 WHERE IMPORT_ID IN ({0}) AND IMPORT_ID NOT IN (SELECT DISTINCT IMPORT_ID FROM dbo.IMP_AP_ERROR)", String.Join(",", ImportIDsWithErrors)))

                End If

            End Using

        End Sub
        Public Sub UpdateAccountsPayableBatchInvoiceDescription(ByVal Session As AdvantageFramework.Security.Session, ByVal BatchName As String, ByVal DescriptionOption As String)

            Dim SqlParameterBatchName As SqlClient.SqlParameter = Nothing
            Dim SqlParameterDescriptionOption As SqlClient.SqlParameter = Nothing

            If DescriptionOption <> AdvantageFramework.Importing.APImportDefaultInvoiceDescription.None.ToString Then

                SqlParameterBatchName = New SqlClient.SqlParameter("@batch_name", SqlDbType.VarChar)
                SqlParameterBatchName.Value = BatchName

                SqlParameterDescriptionOption = New SqlClient.SqlParameter("@description_option", SqlDbType.VarChar)
                SqlParameterDescriptionOption.Value = DescriptionOption

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    DbContext.Database.ExecuteSqlCommand("exec advsp_ap_import_set_invoice_description @batch_name, @description_option", SqlParameterBatchName, SqlParameterDescriptionOption)

                End Using

            End If

        End Sub

#End Region

#Region "   Client "

        Private Function CreateImportClientStaging(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                   ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                   ByVal ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail),
                                                   ByVal FileLineData As Object, ByVal BatchName As String,
                                                   ByVal AutoTrimOverFlowData As Boolean, ByVal DataTable As System.Data.DataTable)

            'objects
            Dim Created As Boolean = True
            Dim ImportClientStaging As AdvantageFramework.Database.Entities.ImportClientStaging = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

            Try

                ImportClientStaging = New AdvantageFramework.Database.Entities.ImportClientStaging

                ImportClientStaging.DbContext = DbContext
                ImportClientStaging.BatchName = BatchName

                CreateEntityFromTemplateDataTable(ImportTemplate, DataTable, FileLineData, ImportClientStaging, AutoTrimOverFlowData)

                Try

                    Client = AdvantageFramework.Database.Procedures.Client.Load(DbContext).Where(Function(Entity) Entity.Code.ToUpper = ImportClientStaging.Code.ToUpper).SingleOrDefault

                Catch ex As Exception
                    Client = Nothing
                End Try

                If Client IsNot Nothing Then

                    ImportClientStaging.IsNew = False

                    ImportClientStaging.Code = Client.Code

                    If ImportClientStaging.Name = "*" OrElse String.IsNullOrWhiteSpace(ImportClientStaging.Name) Then

                        ImportClientStaging.Name = Client.Name

                    End If

                    ImportClientStaging.FiscalStart = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.FiscalStart.ToString, FileLineData, Client.FiscalStart)
                    ImportClientStaging.CreditLimit = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.CreditLimit.ToString, FileLineData, Client.CreditLimit)
                    ImportClientStaging.AssignProductionInvoicesBy = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.AssignProductionInvoicesBy.ToString, FileLineData, Client.AssignProductionInvoicesBy)
                    ImportClientStaging.AssignMediaInvoicesBy = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.AssignMediaInvoicesBy.ToString, FileLineData, Client.AssignMediaInvoicesBy)
                    ImportClientStaging.IsActive = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.IsActive.ToString, FileLineData, Client.IsActive)
                    ImportClientStaging.IsNewBusiness = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.IsNewBusiness.ToString, FileLineData, Client.IsNewBusiness)
                    ImportClientStaging.CampaignCodeRequired = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.CampaignCodeRequired.ToString, FileLineData, Client.CampaignCodeRequired)
                    ImportClientStaging.AccountNumberRequired = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.AccountNumberRequired.ToString, FileLineData, Client.AccountNumberRequired)
                    ImportClientStaging.JobTypeRequired = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.JobTypeRequired.ToString, FileLineData, Client.JobTypeRequired)
                    ImportClientStaging.PromotionRequired = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.PromotionRequired.ToString, FileLineData, Client.PromotionRequired)
                    ImportClientStaging.OverrideAgencySettings = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.OverrideAgencySettings.ToString, FileLineData, Client.OverrideAgencySettings)
                    ImportClientStaging.DueDateRequired = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.DueDateRequired.ToString, FileLineData, Client.DueDateRequired)
                    ImportClientStaging.ComplexityCodeRequired = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.ComplexityCodeRequired.ToString, FileLineData, Client.ComplexityCodeRequired)
                    ImportClientStaging.SCFormatRequired = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.SCFormatRequired.ToString, FileLineData, Client.SCFormatRequired)
                    ImportClientStaging.DepartmentCodeRequired = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.DepartmentCodeRequired.ToString, FileLineData, Client.DepartmentCodeRequired)
                    ImportClientStaging.MarketCodeRequired = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.MarketCodeRequired.ToString, FileLineData, Client.MarketCodeRequired)
                    ImportClientStaging.AlertGroupRequired = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.AlertGroupRequired.ToString, FileLineData, Client.AlertGroupRequired)
                    ImportClientStaging.CoopBillingCodeRequired = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.CoopBillingCodeRequired.ToString, FileLineData, Client.CoopBillingCodeRequired)
                    ImportClientStaging.AdNumberRequired = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.AdNumberRequired.ToString, FileLineData, Client.AdNumberRequired)
                    ImportClientStaging.ClientReferenceRequired = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.ClientReferenceRequired.ToString, FileLineData, Client.ClientReferenceRequired)
                    ImportClientStaging.DateOpenedRequired = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.DateOpenedRequired.ToString, FileLineData, Client.DateOpenedRequired)
                    ImportClientStaging.FormatRequired = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.FormatRequired.ToString, FileLineData, Client.FormatRequired)
                    ImportClientStaging.ProductContactRequired = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.ProductContactRequired.ToString, FileLineData, Client.ProductContactRequired)
                    ImportClientStaging.ComponentBudgetRequired = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.ComponentBudgetRequired.ToString, FileLineData, Client.ComponentBudgetRequired)
                    ImportClientStaging.JobLogCustom1 = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.JobLogCustom1.ToString, FileLineData, Client.JobLogCustom1)
                    ImportClientStaging.JobLogCustom2 = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.JobLogCustom2.ToString, FileLineData, Client.JobLogCustom2)
                    ImportClientStaging.JobLogCustom3 = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.JobLogCustom3.ToString, FileLineData, Client.JobLogCustom3)
                    ImportClientStaging.JobLogCustom4 = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.JobLogCustom4.ToString, FileLineData, Client.JobLogCustom4)
                    ImportClientStaging.JobLogCustom5 = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.JobLogCustom5.ToString, FileLineData, Client.JobLogCustom5)
                    ImportClientStaging.JobCustomComponent1Required = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.JobCustomComponent1Required.ToString, FileLineData, Client.JobCustomComponent1Required)
                    ImportClientStaging.JobCustomComponent2Required = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.JobCustomComponent2Required.ToString, FileLineData, Client.JobCustomComponent2Required)
                    ImportClientStaging.JobCustomComponent3Required = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.JobCustomComponent3Required.ToString, FileLineData, Client.JobCustomComponent3Required)
                    ImportClientStaging.JobCustomComponent4Required = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.JobCustomComponent4Required.ToString, FileLineData, Client.JobCustomComponent4Required)
                    ImportClientStaging.JobCustomComponent5Required = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.JobCustomComponent5Required.ToString, FileLineData, Client.JobCustomComponent5Required)
                    ImportClientStaging.ProductCategoryInTimesheetRequired = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.ProductCategoryInTimesheetRequired.ToString, FileLineData, Client.ProductCategoryInTimesheetRequired)
                    ImportClientStaging.FiscalPeriodRequired = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.FiscalPeriodRequired.ToString, FileLineData, Client.FiscalPeriodRequired)
                    ImportClientStaging.Blackplate1Required = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.Blackplate1Required.ToString, FileLineData, Client.Blackplate1Required)
                    ImportClientStaging.Blackplate2Required = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.Blackplate2Required.ToString, FileLineData, Client.Blackplate2Required)
                    ImportClientStaging.ProductionDaysToPay = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.ProductionDaysToPay.ToString, FileLineData, Client.ProductionDaysToPay)
                    ImportClientStaging.MediaDaysToPay = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.MediaDaysToPay.ToString, FileLineData, Client.MediaDaysToPay)
                    ImportClientStaging.ServiceFeeTypeRequired = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.ServiceFeeTypeRequired.ToString, FileLineData, Client.ServiceFeeTypeRequired)
                    ImportClientStaging.RequireTimeComment = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientStaging.Properties.RequireTimeComment.ToString, FileLineData, Client.RequireTimeComment)

                Else

                    ImportClientStaging.IsNew = True

                    If ImportClientStaging.IsActive Is Nothing Then

                        ImportClientStaging.IsActive = 1

                    End If

                    If ImportClientStaging.CreditLimit Is Nothing Then

                        ImportClientStaging.CreditLimit = 0

                    End If

                    If ImportClientStaging.AssignProductionInvoicesBy Is Nothing Then

                        ImportClientStaging.AssignProductionInvoicesBy = AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.Job

                    End If

                    If ImportClientStaging.AssignMediaInvoicesBy Is Nothing Then

                        ImportClientStaging.AssignMediaInvoicesBy = AdvantageFramework.Database.Entities.AssignMediaInvoicesBy.SalesClass

                    End If

                End If

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                If AdvantageFramework.Database.Procedures.ImportClientStaging.Insert(DbContext, ImportClientStaging) = False Then

                    Created = False

                    Try

                        DbContext.ImportClientStagings.Remove(ImportClientStaging)

                    Catch ex As Exception

                    End Try

                End If

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            Catch ex As Exception
                Created = False
            Finally
                CreateImportClientStaging = Created
            End Try

        End Function
        Public Function CreateClientsFromImport(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportClientStagings As Generic.List(Of AdvantageFramework.Database.Entities.ImportClientStaging),
                                                ByVal ValidateBeforeImporting As Boolean) As Boolean

            'objects
            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim Created As Boolean = True
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim IsValid As Boolean = True

            Try

                PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.Client)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                For Each ImportClientStaging In ImportClientStagings

                    IsValid = True

                    ImportClientStaging.DbContext = DbContext

                    If ImportClientStaging.IsOnHold = False Then

                        If ValidateBeforeImporting Then

                            ImportClientStaging.ValidateEntity(IsValid)

                        Else

                            IsValid = Not ImportClientStaging.HasError()

                        End If

                        If IsValid Then

                            If ImportClientStaging.IsNew Then

                                Client = New AdvantageFramework.Database.Entities.Client
                                Client.DbContext = DbContext

                                Client.Code = ImportClientStaging.Code

                                FillClientEntityFromImportClientStagingEntity(Client, ImportClientStaging)

                                SetEmptyStringsToNull(PropertyDescriptorsList, Client)

                                If AdvantageFramework.Database.Procedures.Client.Insert(DbContext, Client) Then

                                    AdvantageFramework.Database.Procedures.ImportClientStaging.Delete(DbContext, ImportClientStaging)

                                Else

                                    DbContext.Clients.Remove(Client)

                                    Created = False

                                End If

                            Else

                                Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, ImportClientStaging.Code)

                                If Client IsNot Nothing Then

                                    ImportClientStaging.Name = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.Name, ImportClientStaging.Name)
                                    ImportClientStaging.Address = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.Address, ImportClientStaging.Address)
                                    ImportClientStaging.Address2 = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.Address2, ImportClientStaging.Address2)
                                    ImportClientStaging.City = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.City, ImportClientStaging.City)
                                    ImportClientStaging.County = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.County, ImportClientStaging.County)
                                    ImportClientStaging.State = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.State, ImportClientStaging.State)
                                    ImportClientStaging.Country = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.Country, ImportClientStaging.Country)
                                    ImportClientStaging.Zip = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.Zip, ImportClientStaging.Zip)
                                    ImportClientStaging.ProductionAttentionLine = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.ProductionAttentionLine, ImportClientStaging.ProductionAttentionLine)
                                    ImportClientStaging.BillingAddress = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.BillingAddress, ImportClientStaging.BillingAddress)
                                    ImportClientStaging.BillingAddress2 = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.BillingAddress2, ImportClientStaging.BillingAddress2)
                                    ImportClientStaging.BillingCity = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.BillingCity, ImportClientStaging.BillingCity)
                                    ImportClientStaging.BillingCounty = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.BillingCounty, ImportClientStaging.BillingCounty)
                                    ImportClientStaging.BillingState = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.BillingState, ImportClientStaging.BillingState)
                                    ImportClientStaging.BillingCountry = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.BillingCountry, ImportClientStaging.BillingCountry)
                                    ImportClientStaging.BillingZip = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.BillingZip, ImportClientStaging.BillingZip)
                                    ImportClientStaging.StatementAddress = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.StatementAddress, ImportClientStaging.StatementAddress)
                                    ImportClientStaging.StatementAddress2 = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.StatementAddress2, ImportClientStaging.StatementAddress2)
                                    ImportClientStaging.StatementCity = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.StatementCity, ImportClientStaging.StatementCity)
                                    ImportClientStaging.StatementCounty = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.StatementCounty, ImportClientStaging.StatementCounty)
                                    ImportClientStaging.StatementState = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.StatementState, ImportClientStaging.StatementState)
                                    ImportClientStaging.StatementCountry = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.StatementCountry, ImportClientStaging.StatementCountry)
                                    ImportClientStaging.StatementZip = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.StatementZip, ImportClientStaging.StatementZip)
                                    ImportClientStaging.ProductionFooterComments = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.ProductionFooterComments, ImportClientStaging.ProductionFooterComments)
                                    ImportClientStaging.FiscalStart = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.FiscalStart, ImportClientStaging.FiscalStart)
                                    ImportClientStaging.CreditLimit = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.CreditLimit, ImportClientStaging.CreditLimit)
                                    ImportClientStaging.AssignProductionInvoicesBy = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.AssignProductionInvoicesBy, ImportClientStaging.AssignProductionInvoicesBy)
                                    ImportClientStaging.MediaAttentionLine = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.MediaAttentionLine, ImportClientStaging.MediaAttentionLine)
                                    ImportClientStaging.AssignMediaInvoicesBy = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.AssignMediaInvoicesBy, ImportClientStaging.AssignMediaInvoicesBy)
                                    ImportClientStaging.MediaFooterComments = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.MediaFooterComments, ImportClientStaging.MediaFooterComments)
                                    ImportClientStaging.IsActive = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.IsActive, ImportClientStaging.IsActive)
                                    ImportClientStaging.IsNewBusiness = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.IsNewBusiness, ImportClientStaging.IsNewBusiness)
                                    ImportClientStaging.CampaignCodeRequired = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.CampaignCodeRequired, ImportClientStaging.CampaignCodeRequired)
                                    ImportClientStaging.AccountNumberRequired = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.AccountNumberRequired, ImportClientStaging.AccountNumberRequired)
                                    ImportClientStaging.JobTypeRequired = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.JobTypeRequired, ImportClientStaging.JobTypeRequired)
                                    ImportClientStaging.PromotionRequired = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.PromotionRequired, ImportClientStaging.PromotionRequired)
                                    ImportClientStaging.OverrideAgencySettings = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.OverrideAgencySettings, ImportClientStaging.OverrideAgencySettings)
                                    ImportClientStaging.DueDateRequired = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.DueDateRequired, ImportClientStaging.DueDateRequired)
                                    ImportClientStaging.ComplexityCodeRequired = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.ComplexityCodeRequired, ImportClientStaging.ComplexityCodeRequired)
                                    ImportClientStaging.SCFormatRequired = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.SCFormatRequired, ImportClientStaging.SCFormatRequired)
                                    ImportClientStaging.DepartmentCodeRequired = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.DepartmentCodeRequired, ImportClientStaging.DepartmentCodeRequired)
                                    ImportClientStaging.MarketCodeRequired = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.MarketCodeRequired, ImportClientStaging.MarketCodeRequired)
                                    ImportClientStaging.AlertGroupRequired = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.AlertGroupRequired, ImportClientStaging.AlertGroupRequired)
                                    ImportClientStaging.CoopBillingCodeRequired = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.CoopBillingCodeRequired, ImportClientStaging.CoopBillingCodeRequired)
                                    ImportClientStaging.AdNumberRequired = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.AdNumberRequired, ImportClientStaging.AdNumberRequired)
                                    ImportClientStaging.ClientReferenceRequired = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.ClientReferenceRequired, ImportClientStaging.ClientReferenceRequired)
                                    ImportClientStaging.DateOpenedRequired = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.DateOpenedRequired, ImportClientStaging.DateOpenedRequired)
                                    ImportClientStaging.FormatRequired = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.FormatRequired, ImportClientStaging.FormatRequired)
                                    ImportClientStaging.ProductContactRequired = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.ProductContactRequired, ImportClientStaging.ProductContactRequired)
                                    ImportClientStaging.ComponentBudgetRequired = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.ComponentBudgetRequired, ImportClientStaging.ComponentBudgetRequired)
                                    ImportClientStaging.JobLogCustom1 = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.JobLogCustom1, ImportClientStaging.JobLogCustom1)
                                    ImportClientStaging.JobLogCustom2 = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.JobLogCustom2, ImportClientStaging.JobLogCustom2)
                                    ImportClientStaging.JobLogCustom3 = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.JobLogCustom3, ImportClientStaging.JobLogCustom3)
                                    ImportClientStaging.JobLogCustom4 = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.JobLogCustom4, ImportClientStaging.JobLogCustom4)
                                    ImportClientStaging.JobLogCustom5 = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.JobLogCustom5, ImportClientStaging.JobLogCustom5)
                                    ImportClientStaging.JobCustomComponent1Required = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.JobCustomComponent1Required, ImportClientStaging.JobCustomComponent1Required)
                                    ImportClientStaging.JobCustomComponent2Required = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.JobCustomComponent2Required, ImportClientStaging.JobCustomComponent2Required)
                                    ImportClientStaging.JobCustomComponent3Required = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.JobCustomComponent3Required, ImportClientStaging.JobCustomComponent3Required)
                                    ImportClientStaging.JobCustomComponent4Required = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.JobCustomComponent4Required, ImportClientStaging.JobCustomComponent4Required)
                                    ImportClientStaging.JobCustomComponent5Required = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.JobCustomComponent5Required, ImportClientStaging.JobCustomComponent5Required)
                                    ImportClientStaging.ARComment = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.ARComment, ImportClientStaging.ARComment)
                                    ImportClientStaging.ProductCategoryInTimesheetRequired = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.ProductCategoryInTimesheetRequired, ImportClientStaging.ProductCategoryInTimesheetRequired)
                                    ImportClientStaging.FiscalPeriodRequired = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.FiscalPeriodRequired, ImportClientStaging.FiscalPeriodRequired)
                                    ImportClientStaging.Blackplate1Required = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.Blackplate1Required, ImportClientStaging.Blackplate1Required)
                                    ImportClientStaging.Blackplate2Required = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.Blackplate2Required, ImportClientStaging.Blackplate2Required)
                                    ImportClientStaging.ProductionDaysToPay = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.ProductionDaysToPay, ImportClientStaging.ProductionDaysToPay)
                                    ImportClientStaging.MediaDaysToPay = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.MediaDaysToPay, ImportClientStaging.MediaDaysToPay)
                                    ImportClientStaging.ServiceFeeTypeRequired = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.ServiceFeeTypeRequired, ImportClientStaging.ServiceFeeTypeRequired)
                                    ImportClientStaging.RequireTimeComment = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Client.RequireTimeComment, ImportClientStaging.RequireTimeComment)

                                    FillClientEntityFromImportClientStagingEntity(Client, ImportClientStaging)

                                    If AdvantageFramework.Database.Procedures.Client.Update(DbContext, Client) Then

                                        AdvantageFramework.Database.Procedures.ImportClientStaging.Delete(DbContext, ImportClientStaging)

                                    Else

                                        Created = False

                                    End If

                                End If

                            End If

                        Else

                            Created = False

                        End If

                    End If

                Next

            Catch ex As Exception
                Created = False
            End Try

            CreateClientsFromImport = Created

        End Function
        Private Sub FillClientEntityFromImportClientStagingEntity(ByRef Client As AdvantageFramework.Database.Entities.Client, ByVal ImportClientStaging As AdvantageFramework.Database.Entities.ImportClientStaging)

            Client.Name = ImportClientStaging.Name
            Client.Address = ImportClientStaging.Address
            Client.Address2 = ImportClientStaging.Address2
            Client.City = ImportClientStaging.City
            Client.County = ImportClientStaging.County
            Client.State = ImportClientStaging.State
            Client.Country = ImportClientStaging.Country
            Client.Zip = ImportClientStaging.Zip
            Client.ProductionAttentionLine = ImportClientStaging.ProductionAttentionLine
            Client.BillingAddress = ImportClientStaging.BillingAddress
            Client.BillingAddress2 = ImportClientStaging.BillingAddress2
            Client.BillingCity = ImportClientStaging.BillingCity
            Client.BillingCounty = ImportClientStaging.BillingCounty
            Client.BillingState = ImportClientStaging.BillingState
            Client.BillingCountry = ImportClientStaging.BillingCountry
            Client.BillingZip = ImportClientStaging.BillingZip
            Client.StatementAddress = ImportClientStaging.StatementAddress
            Client.StatementAddress2 = ImportClientStaging.StatementAddress2
            Client.StatementCity = ImportClientStaging.StatementCity
            Client.StatementCounty = ImportClientStaging.StatementCounty
            Client.StatementState = ImportClientStaging.StatementState
            Client.StatementCountry = ImportClientStaging.StatementCountry
            Client.StatementZip = ImportClientStaging.StatementZip
            Client.ProductionFooterComments = ImportClientStaging.ProductionFooterComments
            Client.FiscalStart = ImportClientStaging.FiscalStart
            Client.CreditLimit = ImportClientStaging.CreditLimit
            Client.AssignProductionInvoicesBy = ImportClientStaging.AssignProductionInvoicesBy
            Client.MediaAttentionLine = ImportClientStaging.MediaAttentionLine
            Client.AssignMediaInvoicesBy = ImportClientStaging.AssignMediaInvoicesBy
            Client.MediaFooterComments = ImportClientStaging.MediaFooterComments
            Client.IsActive = ImportClientStaging.IsActive
            Client.IsNewBusiness = ImportClientStaging.IsNewBusiness
            Client.CampaignCodeRequired = ImportClientStaging.CampaignCodeRequired
            Client.AccountNumberRequired = ImportClientStaging.AccountNumberRequired
            Client.JobTypeRequired = ImportClientStaging.JobTypeRequired
            Client.PromotionRequired = ImportClientStaging.PromotionRequired
            Client.OverrideAgencySettings = ImportClientStaging.OverrideAgencySettings
            Client.DueDateRequired = ImportClientStaging.DueDateRequired
            Client.ComplexityCodeRequired = ImportClientStaging.ComplexityCodeRequired
            Client.SCFormatRequired = ImportClientStaging.SCFormatRequired
            Client.DepartmentCodeRequired = ImportClientStaging.DepartmentCodeRequired
            Client.MarketCodeRequired = ImportClientStaging.MarketCodeRequired
            Client.AlertGroupRequired = ImportClientStaging.AlertGroupRequired
            Client.CoopBillingCodeRequired = ImportClientStaging.CoopBillingCodeRequired
            Client.AdNumberRequired = ImportClientStaging.AdNumberRequired
            Client.ClientReferenceRequired = ImportClientStaging.ClientReferenceRequired
            Client.DateOpenedRequired = ImportClientStaging.DateOpenedRequired
            Client.FormatRequired = ImportClientStaging.FormatRequired
            Client.ProductContactRequired = ImportClientStaging.ProductContactRequired
            Client.ComponentBudgetRequired = ImportClientStaging.ComponentBudgetRequired
            Client.JobLogCustom1 = ImportClientStaging.JobLogCustom1
            Client.JobLogCustom2 = ImportClientStaging.JobLogCustom2
            Client.JobLogCustom3 = ImportClientStaging.JobLogCustom3
            Client.JobLogCustom4 = ImportClientStaging.JobLogCustom4
            Client.JobLogCustom5 = ImportClientStaging.JobLogCustom5
            Client.JobCustomComponent1Required = ImportClientStaging.JobCustomComponent1Required
            Client.JobCustomComponent2Required = ImportClientStaging.JobCustomComponent2Required
            Client.JobCustomComponent3Required = ImportClientStaging.JobCustomComponent3Required
            Client.JobCustomComponent4Required = ImportClientStaging.JobCustomComponent4Required
            Client.JobCustomComponent5Required = ImportClientStaging.JobCustomComponent5Required
            Client.ARComment = ImportClientStaging.ARComment
            Client.ProductCategoryInTimesheetRequired = ImportClientStaging.ProductCategoryInTimesheetRequired
            Client.FiscalPeriodRequired = ImportClientStaging.FiscalPeriodRequired
            Client.Blackplate1Required = ImportClientStaging.Blackplate1Required
            Client.Blackplate2Required = ImportClientStaging.Blackplate2Required
            Client.ProductionDaysToPay = ImportClientStaging.ProductionDaysToPay
            Client.MediaDaysToPay = ImportClientStaging.MediaDaysToPay
            Client.ServiceFeeTypeRequired = ImportClientStaging.ServiceFeeTypeRequired
            Client.RequireTimeComment = ImportClientStaging.RequireTimeComment
            Client.BatchName = ImportClientStaging.BatchName

        End Sub

#End Region

#Region "   Division "

        Public Function CreateDivisionsFromImport(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportDivisionStagings As Generic.List(Of AdvantageFramework.Database.Entities.ImportDivisionStaging),
                                                  ByVal ValidateBeforeImporting As Boolean) As Boolean

            'objects
            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim Created As Boolean = True
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim IsValid As Boolean = True

            Try

                PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.Division)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                For Each ImportDivisionStaging In ImportDivisionStagings

                    IsValid = True

                    ImportDivisionStaging.DbContext = DbContext

                    If ImportDivisionStaging.IsOnHold = False Then

                        If ValidateBeforeImporting Then

                            ImportDivisionStaging.ValidateEntity(IsValid)

                        Else

                            IsValid = Not ImportDivisionStaging.HasError()

                        End If

                        If IsValid Then

                            If ImportDivisionStaging.IsNew Then

                                Division = New AdvantageFramework.Database.Entities.Division
                                Division.DbContext = DbContext

                                Division.ClientCode = ImportDivisionStaging.ClientCode
                                Division.Code = ImportDivisionStaging.Code

                                FillDivisionEntityFromImportDivisionStagingEntity(Division, ImportDivisionStaging)

                                SetEmptyStringsToNull(PropertyDescriptorsList, Division)

                                If AdvantageFramework.Database.Procedures.Division.Insert(DbContext, Division) Then

                                    AdvantageFramework.Database.Procedures.ImportDivisionStaging.Delete(DbContext, ImportDivisionStaging)

                                Else

                                    DbContext.Divisions.Remove(Division)

                                    Created = False

                                End If

                            Else

                                Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, ImportDivisionStaging.ClientCode, ImportDivisionStaging.Code)

                                If Division IsNot Nothing Then

                                    ImportDivisionStaging.Name = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Division.Name, ImportDivisionStaging.Name)
                                    ImportDivisionStaging.AttentionLine = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Division.AttentionLine, ImportDivisionStaging.AttentionLine)
                                    ImportDivisionStaging.BillingAddress = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Division.BillingAddress, ImportDivisionStaging.BillingAddress)
                                    ImportDivisionStaging.BillingAddress2 = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Division.BillingAddress2, ImportDivisionStaging.BillingAddress2)
                                    ImportDivisionStaging.BillingCity = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Division.BillingCity, ImportDivisionStaging.BillingCity)
                                    ImportDivisionStaging.BillingCounty = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Division.BillingCounty, ImportDivisionStaging.BillingCounty)
                                    ImportDivisionStaging.BillingState = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Division.BillingState, ImportDivisionStaging.BillingState)
                                    ImportDivisionStaging.BillingCountry = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Division.BillingCountry, ImportDivisionStaging.BillingCountry)
                                    ImportDivisionStaging.BillingZip = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Division.BillingZip, ImportDivisionStaging.BillingZip)
                                    ImportDivisionStaging.Address = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Division.Address, ImportDivisionStaging.Address)
                                    ImportDivisionStaging.Address2 = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Division.Address2, ImportDivisionStaging.Address2)
                                    ImportDivisionStaging.City = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Division.City, ImportDivisionStaging.City)
                                    ImportDivisionStaging.County = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Division.County, ImportDivisionStaging.County)
                                    ImportDivisionStaging.State = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Division.State, ImportDivisionStaging.State)
                                    ImportDivisionStaging.Country = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Division.Country, ImportDivisionStaging.Country)
                                    ImportDivisionStaging.Zip = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Division.Zip, ImportDivisionStaging.Zip)
                                    ImportDivisionStaging.IsActive = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Division.IsActive, ImportDivisionStaging.IsActive)

                                    FillDivisionEntityFromImportDivisionStagingEntity(Division, ImportDivisionStaging)

                                    If AdvantageFramework.Database.Procedures.Division.Update(DbContext, Division) Then

                                        AdvantageFramework.Database.Procedures.ImportDivisionStaging.Delete(DbContext, ImportDivisionStaging)

                                    Else

                                        Created = False

                                    End If

                                End If

                            End If

                        Else

                            Created = False

                        End If

                    End If

                Next

            Catch ex As Exception
                Created = False
            End Try

            CreateDivisionsFromImport = Created

        End Function
        Private Function CreateImportDivisionStaging(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                     ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                     ByVal ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail),
                                                     ByVal FileLineData As Object, ByVal BatchName As String,
                                                     ByVal AutoTrimOverFlowData As Boolean, ByVal DataTable As System.Data.DataTable)

            'objects
            Dim Created As Boolean = True
            Dim ImportDivisionStaging As AdvantageFramework.Database.Entities.ImportDivisionStaging = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing

            Try

                ImportDivisionStaging = New AdvantageFramework.Database.Entities.ImportDivisionStaging

                ImportDivisionStaging.DbContext = DbContext
                ImportDivisionStaging.BatchName = BatchName

                CreateEntityFromTemplateDataTable(ImportTemplate, DataTable, FileLineData, ImportDivisionStaging, AutoTrimOverFlowData)

                Try

                    Division = AdvantageFramework.Database.Procedures.Division.Load(DbContext).Where(Function(Entity) Entity.Code.ToUpper = ImportDivisionStaging.Code.ToUpper AndAlso
                                                                                                                          Entity.ClientCode.ToUpper = ImportDivisionStaging.ClientCode.ToUpper).SingleOrDefault

                Catch ex As Exception
                    Division = Nothing
                End Try

                If Division IsNot Nothing Then

                    ImportDivisionStaging.IsNew = False

                    ImportDivisionStaging.ClientCode = Division.ClientCode
                    ImportDivisionStaging.Code = Division.Code

                    If ImportDivisionStaging.Name = "*" OrElse String.IsNullOrWhiteSpace(ImportDivisionStaging.Name) Then

                        ImportDivisionStaging.Name = Division.Name

                    End If

                    ImportDivisionStaging.IsActive = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportDivisionStaging.Properties.IsActive.ToString, FileLineData, Division.IsActive)

                Else

                    ImportDivisionStaging.IsNew = True

                    If ImportDivisionStaging.IsActive Is Nothing Then

                        ImportDivisionStaging.IsActive = 1

                    End If

                End If

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                If AdvantageFramework.Database.Procedures.ImportDivisionStaging.Insert(DbContext, ImportDivisionStaging) = False Then

                    Created = False

                    Try

                        DbContext.ImportDivisionStagings.Remove(ImportDivisionStaging)

                    Catch ex As Exception

                    End Try

                End If

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            Catch ex As Exception
                Created = False
            Finally
                CreateImportDivisionStaging = Created
            End Try

        End Function
        Private Sub FillDivisionEntityFromImportDivisionStagingEntity(ByRef Division As AdvantageFramework.Database.Entities.Division, ByVal ImportDivisionStaging As AdvantageFramework.Database.Entities.ImportDivisionStaging)

            Division.Name = ImportDivisionStaging.Name
            Division.AttentionLine = ImportDivisionStaging.AttentionLine
            Division.BillingAddress = ImportDivisionStaging.BillingAddress
            Division.BillingAddress2 = ImportDivisionStaging.BillingAddress2
            Division.BillingCity = ImportDivisionStaging.BillingCity
            Division.BillingCounty = ImportDivisionStaging.BillingCounty
            Division.BillingState = ImportDivisionStaging.BillingState
            Division.BillingCountry = ImportDivisionStaging.BillingCountry
            Division.BillingZip = ImportDivisionStaging.BillingZip
            Division.Address = ImportDivisionStaging.Address
            Division.Address2 = ImportDivisionStaging.Address2
            Division.City = ImportDivisionStaging.City
            Division.County = ImportDivisionStaging.County
            Division.State = ImportDivisionStaging.State
            Division.Country = ImportDivisionStaging.Country
            Division.Zip = ImportDivisionStaging.Zip
            Division.IsActive = ImportDivisionStaging.IsActive
            Division.BatchName = ImportDivisionStaging.BatchName

        End Sub

#End Region

#Region "   Product "

        Public Function CreateProductsFromImport(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportProductStagings As Generic.List(Of AdvantageFramework.Database.Entities.ImportProductStaging),
                                                 ByVal ValidateBeforeImporting As Boolean) As Boolean

            'objects
            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim Created As Boolean = True
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim IsValid As Boolean = True

            Try

                PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.Product)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                For Each ImportProductStaging In ImportProductStagings

                    IsValid = True

                    ImportProductStaging.DbContext = DbContext

                    If ImportProductStaging.IsOnHold = False Then

                        If ValidateBeforeImporting Then

                            ImportProductStaging.ValidateEntity(IsValid)

                        Else

                            IsValid = Not ImportProductStaging.HasError()

                        End If

                        If IsValid Then

                            If ImportProductStaging.IsNew Then

                                Product = New AdvantageFramework.Database.Entities.Product
                                Product.DbContext = DbContext

                                Product.ClientCode = ImportProductStaging.ClientCode
                                Product.DivisionCode = ImportProductStaging.DivisionCode
                                Product.Code = ImportProductStaging.Code

                                FillProductEntityFromImportProductStagingEntity(Product, ImportProductStaging)

                                SetEmptyStringsToNull(PropertyDescriptorsList, Product)

                                If AdvantageFramework.Database.Procedures.Product.Insert(DbContext, Product) Then

                                    AdvantageFramework.Database.Procedures.ImportProductStaging.Delete(DbContext, ImportProductStaging)

                                Else

                                    DbContext.Products.Remove(Product)

                                    Created = False

                                End If

                            Else

                                Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, ImportProductStaging.ClientCode, ImportProductStaging.DivisionCode, ImportProductStaging.Code)

                                If Product IsNot Nothing Then

                                    ImportProductStaging.Name = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.Name, ImportProductStaging.Name)
                                    ImportProductStaging.AttentionTo = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.AttentionTo, ImportProductStaging.AttentionTo)
                                    ImportProductStaging.BillingAddress = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.BillingAddress, ImportProductStaging.BillingAddress)
                                    ImportProductStaging.BillingAddress2 = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.BillingAddress2, ImportProductStaging.BillingAddress2)
                                    ImportProductStaging.BillingCity = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.BillingCity, ImportProductStaging.BillingCity)
                                    ImportProductStaging.BillingCounty = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.BillingCounty, ImportProductStaging.BillingCounty)
                                    ImportProductStaging.BillingState = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.BillingState, ImportProductStaging.BillingState)
                                    ImportProductStaging.BillingCountry = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.BillingCountry, ImportProductStaging.BillingCountry)
                                    ImportProductStaging.BillingZip = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.BillingZip, ImportProductStaging.BillingZip)
                                    ImportProductStaging.BillingPhone = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.BillingPhone, ImportProductStaging.BillingPhone)
                                    ImportProductStaging.BillingPhoneExtension = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.BillingPhoneExtension, ImportProductStaging.BillingPhoneExtension)
                                    ImportProductStaging.BillingFax = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.BillingFax, ImportProductStaging.BillingFax)
                                    ImportProductStaging.BillingFaxExtension = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.BillingFaxExtension, ImportProductStaging.BillingFaxExtension)
                                    ImportProductStaging.StatementAddress = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.StatementAddress, ImportProductStaging.StatementAddress)
                                    ImportProductStaging.StatementAddress2 = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.StatementAddress2, ImportProductStaging.StatementAddress2)
                                    ImportProductStaging.StatementCity = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.StatementCity, ImportProductStaging.StatementCity)
                                    ImportProductStaging.StatementCounty = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.StatementCounty, ImportProductStaging.StatementCounty)
                                    ImportProductStaging.StatementState = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.StatementState, ImportProductStaging.StatementState)
                                    ImportProductStaging.StatementCountry = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.StatementCountry, ImportProductStaging.StatementCountry)
                                    ImportProductStaging.StatementZip = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.StatementZip, ImportProductStaging.StatementZip)
                                    ImportProductStaging.StatementPhone = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.StatementPhone, ImportProductStaging.StatementPhone)
                                    ImportProductStaging.StatementPhoneExtension = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.StatementPhoneExtension, ImportProductStaging.StatementPhoneExtension)
                                    ImportProductStaging.StatementFax = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.StatementFax, ImportProductStaging.StatementFax)
                                    ImportProductStaging.StatementFaxExtension = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.StatementFaxExtension, ImportProductStaging.StatementFaxExtension)
                                    ImportProductStaging.OfficeCode = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.OfficeCode, ImportProductStaging.OfficeCode)
                                    ImportProductStaging.ProductionConsolidateFunctions = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.ProductionConsolidateFunctions, ImportProductStaging.ProductionConsolidateFunctions)
                                    ImportProductStaging.ProductionContingency = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.ProductionContingency, ImportProductStaging.ProductionContingency)
                                    ImportProductStaging.ProductionMarkup = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.ProductionMarkup, ImportProductStaging.ProductionMarkup)
                                    ImportProductStaging.ProductionBillNet = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.ProductionBillNet, ImportProductStaging.ProductionBillNet)
                                    ImportProductStaging.ProductionVendorDiscounts = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.ProductionVendorDiscounts, ImportProductStaging.ProductionVendorDiscounts)
                                    ImportProductStaging.ProductionApprovedEstimatedRequired = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.ProductionApprovedEstimatedRequired, ImportProductStaging.ProductionApprovedEstimatedRequired)
                                    ImportProductStaging.ProductionTaxCode = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.ProductionTaxCode, ImportProductStaging.ProductionTaxCode)
                                    ImportProductStaging.RadioRebate = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.RadioRebate, ImportProductStaging.RadioRebate)
                                    ImportProductStaging.RadioBillNet = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.RadioBillNet, ImportProductStaging.RadioBillNet)
                                    ImportProductStaging.RadioVendorDiscounts = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.RadioVendorDiscounts, ImportProductStaging.RadioVendorDiscounts)
                                    ImportProductStaging.RadioCommissionOnly = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.RadioCommissionOnly, ImportProductStaging.RadioCommissionOnly)
                                    ImportProductStaging.RadioTaxCode = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.RadioTaxCode, ImportProductStaging.RadioTaxCode)
                                    ImportProductStaging.RadioDaysToBill = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.RadioDaysToBill, ImportProductStaging.RadioDaysToBill)
                                    ImportProductStaging.RadioPrePostBill = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.RadioPrePostBill, ImportProductStaging.RadioPrePostBill)
                                    ImportProductStaging.RadioBillSetting = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.RadioBillSetting, ImportProductStaging.RadioBillSetting)
                                    ImportProductStaging.TelevisionRebate = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.TelevisionRebate, ImportProductStaging.TelevisionRebate)
                                    ImportProductStaging.TelevisionBillNet = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.TelevisionBillNet, ImportProductStaging.TelevisionBillNet)
                                    ImportProductStaging.TelevisionVendorDiscounts = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.TelevisionVendorDiscounts, ImportProductStaging.TelevisionVendorDiscounts)
                                    ImportProductStaging.TelevisionCommissionOnly = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.TelevisionCommissionOnly, ImportProductStaging.TelevisionCommissionOnly)
                                    ImportProductStaging.TelevisionTaxCode = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.TelevisionTaxCode, ImportProductStaging.TelevisionTaxCode)
                                    ImportProductStaging.TelevisionDaysToBill = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.TelevisionDaysToBill, ImportProductStaging.TelevisionDaysToBill)
                                    ImportProductStaging.TelevisionPrePostBill = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.TelevisionPrePostBill, ImportProductStaging.TelevisionPrePostBill)
                                    ImportProductStaging.TelevisionBillSetting = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.TelevisionBillSetting, ImportProductStaging.TelevisionBillSetting)
                                    ImportProductStaging.MagazineRebate = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.MagazineRebate, ImportProductStaging.MagazineRebate)
                                    ImportProductStaging.MagazineBillNet = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.MagazineBillNet, ImportProductStaging.MagazineBillNet)
                                    ImportProductStaging.MagazineVendorDiscounts = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.MagazineVendorDiscounts, ImportProductStaging.MagazineVendorDiscounts)
                                    ImportProductStaging.MagazineCommissionOnly = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.MagazineCommissionOnly, ImportProductStaging.MagazineCommissionOnly)
                                    ImportProductStaging.MagazineTaxCode = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.MagazineTaxCode, ImportProductStaging.MagazineTaxCode)
                                    ImportProductStaging.MagazineDaysToBill = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.MagazineDaysToBill, ImportProductStaging.MagazineDaysToBill)
                                    ImportProductStaging.MagazinePrePostBill = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.MagazinePrePostBill, ImportProductStaging.MagazinePrePostBill)
                                    ImportProductStaging.MagazineBillSetting = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.MagazineBillSetting, ImportProductStaging.MagazineBillSetting)
                                    ImportProductStaging.NewspaperMarkup = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.NewspaperMarkup, ImportProductStaging.NewspaperMarkup)
                                    ImportProductStaging.NewspaperBillNet = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.NewspaperBillNet, ImportProductStaging.NewspaperBillNet)
                                    ImportProductStaging.NewspaperVendorDiscounts = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.NewspaperVendorDiscounts, ImportProductStaging.NewspaperVendorDiscounts)
                                    ImportProductStaging.NewspaperCommissionOnly = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.NewspaperCommissionOnly, ImportProductStaging.NewspaperCommissionOnly)
                                    ImportProductStaging.NewspaperTaxCode = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.NewspaperTaxCode, ImportProductStaging.NewspaperTaxCode)
                                    ImportProductStaging.NewspaperDaysToBill = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.NewspaperDaysToBill, ImportProductStaging.NewspaperDaysToBill)
                                    ImportProductStaging.NewspaperPrePostBill = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.NewspaperPrePostBill, ImportProductStaging.NewspaperPrePostBill)
                                    ImportProductStaging.NewspaperBillSetting = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.NewspaperBillSetting, ImportProductStaging.NewspaperBillSetting)
                                    ImportProductStaging.NewspaperRebate = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.NewspaperRebate, ImportProductStaging.NewspaperRebate)
                                    ImportProductStaging.OutOfHomeRebate = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.OutOfHomeRebate, ImportProductStaging.OutOfHomeRebate)
                                    ImportProductStaging.InternetRebate = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.InternetRebate, ImportProductStaging.InternetRebate)
                                    ImportProductStaging.RadioMarkup = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.RadioMarkup, ImportProductStaging.RadioMarkup)
                                    ImportProductStaging.TelevisionMarkup = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.TelevisionMarkup, ImportProductStaging.TelevisionMarkup)
                                    ImportProductStaging.MagazineMarkup = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.MagazineMarkup, ImportProductStaging.MagazineMarkup)
                                    ImportProductStaging.OutOfHomeMarkup = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.OutOfHomeMarkup, ImportProductStaging.OutOfHomeMarkup)
                                    ImportProductStaging.InternetMarkup = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.InternetMarkup, ImportProductStaging.InternetMarkup)
                                    ImportProductStaging.OutOfHomeBillSetting = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.OutOfHomeBillSetting, ImportProductStaging.OutOfHomeBillSetting)
                                    ImportProductStaging.OutOfHomeBillNet = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.OutOfHomeBillNet, ImportProductStaging.OutOfHomeBillNet)
                                    ImportProductStaging.OutOfHomeCommissionOnly = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.OutOfHomeCommissionOnly, ImportProductStaging.OutOfHomeCommissionOnly)
                                    ImportProductStaging.OutOfHomeDaysToBill = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.OutOfHomeDaysToBill, ImportProductStaging.OutOfHomeDaysToBill)
                                    ImportProductStaging.OutOfHomePrePostBill = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.OutOfHomePrePostBill, ImportProductStaging.OutOfHomePrePostBill)
                                    ImportProductStaging.OutOfHomeTaxCode = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.OutOfHomeTaxCode, ImportProductStaging.OutOfHomeTaxCode)
                                    ImportProductStaging.OutOfHomeVendorDiscounts = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.OutOfHomeVendorDiscounts, ImportProductStaging.OutOfHomeVendorDiscounts)
                                    ImportProductStaging.InternetBillSetting = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.InternetBillSetting, ImportProductStaging.InternetBillSetting)
                                    ImportProductStaging.InternetBillNet = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.InternetBillNet, ImportProductStaging.InternetBillNet)
                                    ImportProductStaging.InternetCommissionOnly = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.InternetCommissionOnly, ImportProductStaging.InternetCommissionOnly)
                                    ImportProductStaging.InternetDaysToBill = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.InternetDaysToBill, ImportProductStaging.InternetDaysToBill)
                                    ImportProductStaging.InternetPrePostBill = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.InternetPrePostBill, ImportProductStaging.InternetPrePostBill)
                                    ImportProductStaging.InternetTaxCode = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.InternetTaxCode, ImportProductStaging.InternetTaxCode)
                                    ImportProductStaging.InternetVendorDiscounts = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.InternetVendorDiscounts, ImportProductStaging.InternetVendorDiscounts)
                                    ImportProductStaging.ProductionAlertGroup = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.ProductionAlertGroup, ImportProductStaging.ProductionAlertGroup)
                                    ImportProductStaging.IsActive = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.IsActive, ImportProductStaging.IsActive)
                                    ImportProductStaging.UserDefinedField1 = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.UserDefinedField1, ImportProductStaging.UserDefinedField1)
                                    ImportProductStaging.UserDefinedField2 = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.UserDefinedField2, ImportProductStaging.UserDefinedField2)
                                    ImportProductStaging.UserDefinedField3 = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.UserDefinedField3, ImportProductStaging.UserDefinedField3)
                                    ImportProductStaging.UserDefinedField4 = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.UserDefinedField4, ImportProductStaging.UserDefinedField4)
                                    ImportProductStaging.RadioApplyTaxUseFlags = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.RadioApplyTaxUseFlags, ImportProductStaging.RadioApplyTaxUseFlags)
                                    ImportProductStaging.RadioApplyTaxLineNet = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.RadioApplyTaxLineNet, ImportProductStaging.RadioApplyTaxLineNet)
                                    ImportProductStaging.RadioApplyTaxNetDiscount = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.RadioApplyTaxNetDiscount, ImportProductStaging.RadioApplyTaxNetDiscount)
                                    ImportProductStaging.RadioApplyTaxNetCharge = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.RadioApplyTaxNetCharge, ImportProductStaging.RadioApplyTaxNetCharge)
                                    ImportProductStaging.RadioApplyTaxAddlCharge = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.RadioApplyTaxAddlCharge, ImportProductStaging.RadioApplyTaxAddlCharge)
                                    ImportProductStaging.RadioApplyTaxCommission = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.RadioApplyTaxCommission, ImportProductStaging.RadioApplyTaxCommission)
                                    ImportProductStaging.RadioApplyTaxRebate = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.RadioApplyTaxRebate, ImportProductStaging.RadioApplyTaxRebate)
                                    ImportProductStaging.TelevisionApplyTaxUseFlags = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.TelevisionApplyTaxUseFlags, ImportProductStaging.TelevisionApplyTaxUseFlags)
                                    ImportProductStaging.TelevisionApplyTaxLineNet = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.TelevisionApplyTaxLineNet, ImportProductStaging.TelevisionApplyTaxLineNet)
                                    ImportProductStaging.TelevisionApplyTaxNetDiscount = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.TelevisionApplyTaxNetDiscount, ImportProductStaging.TelevisionApplyTaxNetDiscount)
                                    ImportProductStaging.TelevisionApplyTaxNetCharge = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.TelevisionApplyTaxNetCharge, ImportProductStaging.TelevisionApplyTaxNetCharge)
                                    ImportProductStaging.TelevisionApplyTaxAddlCharge = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.TelevisionApplyTaxAddlCharge, ImportProductStaging.TelevisionApplyTaxAddlCharge)
                                    ImportProductStaging.TelevisionApplyTaxCommission = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.TelevisionApplyTaxCommission, ImportProductStaging.TelevisionApplyTaxCommission)
                                    ImportProductStaging.TelevisionApplyTaxRebate = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.TelevisionApplyTaxRebate, ImportProductStaging.TelevisionApplyTaxRebate)
                                    ImportProductStaging.MagazineApplyTaxUseFlags = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.MagazineApplyTaxUseFlags, ImportProductStaging.MagazineApplyTaxUseFlags)
                                    ImportProductStaging.MagazineApplyTaxLineNet = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.MagazineApplyTaxLineNet, ImportProductStaging.MagazineApplyTaxLineNet)
                                    ImportProductStaging.MagazineApplyTaxNetDiscount = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.MagazineApplyTaxNetDiscount, ImportProductStaging.MagazineApplyTaxNetDiscount)
                                    ImportProductStaging.MagazineApplyTaxNetCharge = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.MagazineApplyTaxNetCharge, ImportProductStaging.MagazineApplyTaxNetCharge)
                                    ImportProductStaging.MagazineApplyTaxAddlCharge = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.MagazineApplyTaxAddlCharge, ImportProductStaging.MagazineApplyTaxAddlCharge)
                                    ImportProductStaging.MagazineApplyTaxCommission = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.MagazineApplyTaxCommission, ImportProductStaging.MagazineApplyTaxCommission)
                                    ImportProductStaging.MagazineApplyTaxRebate = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.MagazineApplyTaxRebate, ImportProductStaging.MagazineApplyTaxRebate)
                                    ImportProductStaging.NewspaperApplyTaxUseFlags = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.NewspaperApplyTaxUseFlags, ImportProductStaging.NewspaperApplyTaxUseFlags)
                                    ImportProductStaging.NewspaperApplyTaxLineNet = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.NewspaperApplyTaxLineNet, ImportProductStaging.NewspaperApplyTaxLineNet)
                                    ImportProductStaging.NewspaperApplyTaxNetDiscount = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.NewspaperApplyTaxNetDiscount, ImportProductStaging.NewspaperApplyTaxNetDiscount)
                                    ImportProductStaging.NewspaperApplyTaxNetCharge = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.NewspaperApplyTaxNetCharge, ImportProductStaging.NewspaperApplyTaxNetCharge)
                                    ImportProductStaging.NewspaperApplyTaxAddlCharge = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.NewspaperApplyTaxAddlCharge, ImportProductStaging.NewspaperApplyTaxAddlCharge)
                                    ImportProductStaging.NewspaperApplyTaxCommission = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.NewspaperApplyTaxCommission, ImportProductStaging.NewspaperApplyTaxCommission)
                                    ImportProductStaging.NewspaperApplyTaxRebate = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.NewspaperApplyTaxRebate, ImportProductStaging.NewspaperApplyTaxRebate)
                                    ImportProductStaging.OutOfHomeApplyTaxUseFlags = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.OutOfHomeApplyTaxUseFlags, ImportProductStaging.OutOfHomeApplyTaxUseFlags)
                                    ImportProductStaging.OutOfHomeApplyTaxLineNet = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.OutOfHomeApplyTaxLineNet, ImportProductStaging.OutOfHomeApplyTaxLineNet)
                                    ImportProductStaging.OutOfHomeApplyTaxNetDiscount = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.OutOfHomeApplyTaxNetDiscount, ImportProductStaging.OutOfHomeApplyTaxNetDiscount)
                                    ImportProductStaging.OutOfHomeApplyTaxNetCharge = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.OutOfHomeApplyTaxNetCharge, ImportProductStaging.OutOfHomeApplyTaxNetCharge)
                                    ImportProductStaging.OutOfHomeApplyTaxAddlCharge = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.OutOfHomeApplyTaxAddlCharge, ImportProductStaging.OutOfHomeApplyTaxAddlCharge)
                                    ImportProductStaging.OutOfHomeApplyTaxCommission = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.OutOfHomeApplyTaxCommission, ImportProductStaging.OutOfHomeApplyTaxCommission)
                                    ImportProductStaging.OutOfHomeApplyTaxRebate = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.OutOfHomeApplyTaxRebate, ImportProductStaging.OutOfHomeApplyTaxRebate)
                                    ImportProductStaging.InternetApplyTaxUseFlags = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.InternetApplyTaxUseFlags, ImportProductStaging.InternetApplyTaxUseFlags)
                                    ImportProductStaging.InternetApplyTaxLineNet = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.InternetApplyTaxLineNet, ImportProductStaging.InternetApplyTaxLineNet)
                                    ImportProductStaging.InternetApplyTaxNetDiscount = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.InternetApplyTaxNetDiscount, ImportProductStaging.InternetApplyTaxNetDiscount)
                                    ImportProductStaging.InternetApplyTaxNetCharge = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.InternetApplyTaxNetCharge, ImportProductStaging.InternetApplyTaxNetCharge)
                                    ImportProductStaging.InternetApplyTaxAddlCharge = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.InternetApplyTaxAddlCharge, ImportProductStaging.InternetApplyTaxAddlCharge)
                                    ImportProductStaging.InternetApplyTaxCommission = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.InternetApplyTaxCommission, ImportProductStaging.InternetApplyTaxCommission)
                                    ImportProductStaging.InternetApplyTaxRebate = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.InternetApplyTaxRebate, ImportProductStaging.InternetApplyTaxRebate)
                                    ImportProductStaging.ProductionBillingSetupComplete = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.ProductionBillingSetupComplete, ImportProductStaging.ProductionBillingSetupComplete)
                                    ImportProductStaging.RadioBillingSetupComplete = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.RadioBillingSetupComplete, ImportProductStaging.RadioBillingSetupComplete)
                                    ImportProductStaging.TelevisionBillingSetupComplete = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.TelevisionBillingSetupComplete, ImportProductStaging.TelevisionBillingSetupComplete)
                                    ImportProductStaging.MagazineBillingSetupComplete = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.MagazineBillingSetupComplete, ImportProductStaging.MagazineBillingSetupComplete)
                                    ImportProductStaging.NewspaperBillingSetupComplete = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.NewspaperBillingSetupComplete, ImportProductStaging.NewspaperBillingSetupComplete)
                                    ImportProductStaging.OutOfHomeBillingSetupComplete = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.OutOfHomeBillingSetupComplete, ImportProductStaging.OutOfHomeBillingSetupComplete)
                                    ImportProductStaging.InternetBillingSetupComplete = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.InternetBillingSetupComplete, ImportProductStaging.InternetBillingSetupComplete)
                                    ImportProductStaging.ProductionUseEstimateBillingRate = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.ProductionUseEstimateBillingRate, ImportProductStaging.ProductionUseEstimateBillingRate)
                                    'ImportProductStaging.CurrencyCode = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(Product.CurrencyCode, ImportProductStaging.CurrencyCode)

                                    FillProductEntityFromImportProductStagingEntity(Product, ImportProductStaging)

                                    If AdvantageFramework.Database.Procedures.Product.Update(DbContext, Product) Then

                                        AdvantageFramework.Database.Procedures.ImportProductStaging.Delete(DbContext, ImportProductStaging)

                                    Else

                                        Created = False

                                    End If

                                End If

                            End If

                        Else

                            Created = False

                        End If

                    End If

                Next

            Catch ex As Exception
                Created = False
            End Try

            CreateProductsFromImport = Created

        End Function
        Private Function CreateImportProductStaging(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                    ByVal ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail),
                                                    ByVal FileLineData As Object, ByVal BatchName As String,
                                                    ByVal AutoTrimOverFlowData As Boolean, ByVal DataTable As System.Data.DataTable)

            'objects
            Dim Created As Boolean = True
            Dim ImportProductStaging As AdvantageFramework.Database.Entities.ImportProductStaging = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Try

                ImportProductStaging = New AdvantageFramework.Database.Entities.ImportProductStaging

                ImportProductStaging.DbContext = DbContext
                ImportProductStaging.BatchName = BatchName

                CreateEntityFromTemplateDataTable(ImportTemplate, DataTable, FileLineData, ImportProductStaging, AutoTrimOverFlowData)

                Try

                    Product = AdvantageFramework.Database.Procedures.Product.Load(DbContext).Where(Function(Entity) Entity.Code.ToUpper = ImportProductStaging.Code.ToUpper AndAlso
                                                                                                                        Entity.ClientCode.ToUpper = ImportProductStaging.ClientCode.ToUpper AndAlso
                                                                                                                        Entity.DivisionCode.ToUpper = ImportProductStaging.DivisionCode.ToUpper).SingleOrDefault

                Catch ex As Exception
                    Product = Nothing
                End Try

                If Product IsNot Nothing Then

                    ImportProductStaging.IsNew = False

                    ImportProductStaging.ClientCode = Product.ClientCode
                    ImportProductStaging.DivisionCode = Product.DivisionCode
                    ImportProductStaging.Code = Product.Code

                    If ImportProductStaging.Name = "*" OrElse String.IsNullOrWhiteSpace(ImportProductStaging.Name) Then

                        ImportProductStaging.Name = Product.Name

                    End If

                    If ImportProductStaging.OfficeCode = "*" OrElse String.IsNullOrWhiteSpace(ImportProductStaging.OfficeCode) Then

                        ImportProductStaging.OfficeCode = Product.OfficeCode

                    End If

                    If ImportProductStaging.ProductionTaxCode = "*" Then

                        ImportProductStaging.ProductionTaxCode = Nothing

                    End If

                    If ImportProductStaging.RadioTaxCode = "*" Then

                        ImportProductStaging.RadioTaxCode = Nothing

                    End If

                    If ImportProductStaging.TelevisionTaxCode = "*" Then

                        ImportProductStaging.TelevisionTaxCode = Nothing

                    End If

                    If ImportProductStaging.MagazineTaxCode = "*" Then

                        ImportProductStaging.MagazineTaxCode = Nothing

                    End If

                    If ImportProductStaging.NewspaperTaxCode = "*" Then

                        ImportProductStaging.NewspaperTaxCode = Nothing

                    End If

                    If ImportProductStaging.OutOfHomeTaxCode = "*" Then

                        ImportProductStaging.OutOfHomeTaxCode = Nothing

                    End If

                    If ImportProductStaging.InternetTaxCode = "*" Then

                        ImportProductStaging.InternetTaxCode = Nothing

                    End If

                    ImportProductStaging.ProductionConsolidateFunctions = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.ProductionConsolidateFunctions.ToString, FileLineData, Product.ProductionConsolidateFunctions)
                    ImportProductStaging.ProductionContingency = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.ProductionContingency.ToString, FileLineData, Product.ProductionContingency)
                    ImportProductStaging.ProductionMarkup = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.ProductionMarkup.ToString, FileLineData, Product.ProductionMarkup)
                    ImportProductStaging.ProductionBillNet = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.ProductionBillNet.ToString, FileLineData, Product.ProductionBillNet)
                    ImportProductStaging.ProductionVendorDiscounts = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.ProductionVendorDiscounts.ToString, FileLineData, Product.ProductionVendorDiscounts)
                    ImportProductStaging.ProductionApprovedEstimatedRequired = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.ProductionApprovedEstimatedRequired.ToString, FileLineData, Product.ProductionApprovedEstimatedRequired)
                    ImportProductStaging.RadioRebate = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.RadioRebate.ToString, FileLineData, Product.RadioRebate)
                    ImportProductStaging.RadioBillNet = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.RadioBillNet.ToString, FileLineData, Product.RadioBillNet)
                    ImportProductStaging.RadioVendorDiscounts = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.RadioVendorDiscounts.ToString, FileLineData, Product.RadioVendorDiscounts)
                    ImportProductStaging.RadioCommissionOnly = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.RadioCommissionOnly.ToString, FileLineData, Product.RadioCommissionOnly)
                    ImportProductStaging.RadioDaysToBill = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.RadioDaysToBill.ToString, FileLineData, Product.RadioDaysToBill)
                    ImportProductStaging.RadioPrePostBill = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.RadioPrePostBill.ToString, FileLineData, Product.RadioPrePostBill)
                    ImportProductStaging.RadioBillSetting = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.RadioBillSetting.ToString, FileLineData, Product.RadioBillSetting)
                    ImportProductStaging.TelevisionRebate = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.TelevisionRebate.ToString, FileLineData, Product.TelevisionRebate)
                    ImportProductStaging.TelevisionBillNet = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.TelevisionBillNet.ToString, FileLineData, Product.TelevisionBillNet)
                    ImportProductStaging.TelevisionVendorDiscounts = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.TelevisionVendorDiscounts.ToString, FileLineData, Product.TelevisionVendorDiscounts)
                    ImportProductStaging.TelevisionCommissionOnly = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.TelevisionCommissionOnly.ToString, FileLineData, Product.TelevisionCommissionOnly)
                    ImportProductStaging.TelevisionDaysToBill = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.TelevisionDaysToBill.ToString, FileLineData, Product.TelevisionDaysToBill)
                    ImportProductStaging.TelevisionPrePostBill = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.TelevisionPrePostBill.ToString, FileLineData, Product.TelevisionPrePostBill)
                    ImportProductStaging.TelevisionBillSetting = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.TelevisionBillSetting.ToString, FileLineData, Product.TelevisionBillSetting)
                    ImportProductStaging.MagazineRebate = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.MagazineRebate.ToString, FileLineData, Product.MagazineRebate)
                    ImportProductStaging.MagazineBillNet = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.MagazineBillNet.ToString, FileLineData, Product.MagazineBillNet)
                    ImportProductStaging.MagazineVendorDiscounts = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.MagazineVendorDiscounts.ToString, FileLineData, Product.MagazineVendorDiscounts)
                    ImportProductStaging.MagazineCommissionOnly = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.MagazineCommissionOnly.ToString, FileLineData, Product.MagazineCommissionOnly)
                    ImportProductStaging.MagazineDaysToBill = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.MagazineDaysToBill.ToString, FileLineData, Product.MagazineDaysToBill)
                    ImportProductStaging.MagazinePrePostBill = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.MagazinePrePostBill.ToString, FileLineData, Product.MagazinePrePostBill)
                    ImportProductStaging.MagazineBillSetting = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.MagazineBillSetting.ToString, FileLineData, Product.MagazineBillSetting)
                    ImportProductStaging.NewspaperMarkup = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.NewspaperMarkup.ToString, FileLineData, Product.NewspaperMarkup)
                    ImportProductStaging.NewspaperBillNet = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.NewspaperBillNet.ToString, FileLineData, Product.NewspaperBillNet)
                    ImportProductStaging.NewspaperVendorDiscounts = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.NewspaperVendorDiscounts.ToString, FileLineData, Product.NewspaperVendorDiscounts)
                    ImportProductStaging.NewspaperCommissionOnly = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.NewspaperCommissionOnly.ToString, FileLineData, Product.NewspaperCommissionOnly)
                    ImportProductStaging.NewspaperDaysToBill = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.NewspaperDaysToBill.ToString, FileLineData, Product.NewspaperDaysToBill)
                    ImportProductStaging.NewspaperPrePostBill = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.NewspaperPrePostBill.ToString, FileLineData, Product.NewspaperPrePostBill)
                    ImportProductStaging.NewspaperBillSetting = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.NewspaperBillSetting.ToString, FileLineData, Product.NewspaperBillSetting)
                    ImportProductStaging.NewspaperRebate = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.NewspaperRebate.ToString, FileLineData, Product.NewspaperRebate)
                    ImportProductStaging.OutOfHomeRebate = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.OutOfHomeRebate.ToString, FileLineData, Product.OutOfHomeRebate)
                    ImportProductStaging.InternetRebate = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.InternetRebate.ToString, FileLineData, Product.InternetRebate)
                    ImportProductStaging.RadioMarkup = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.RadioMarkup.ToString, FileLineData, Product.RadioMarkup)
                    ImportProductStaging.TelevisionMarkup = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.TelevisionMarkup.ToString, FileLineData, Product.TelevisionMarkup)
                    ImportProductStaging.MagazineMarkup = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.MagazineMarkup.ToString, FileLineData, Product.MagazineMarkup)
                    ImportProductStaging.OutOfHomeMarkup = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.OutOfHomeMarkup.ToString, FileLineData, Product.OutOfHomeMarkup)
                    ImportProductStaging.InternetMarkup = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.InternetMarkup.ToString, FileLineData, Product.InternetMarkup)
                    ImportProductStaging.OutOfHomeBillSetting = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.OutOfHomeBillSetting.ToString, FileLineData, Product.OutOfHomeBillSetting)
                    ImportProductStaging.OutOfHomeBillNet = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.OutOfHomeBillNet.ToString, FileLineData, Product.OutOfHomeBillNet)
                    ImportProductStaging.OutOfHomeCommissionOnly = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.OutOfHomeCommissionOnly.ToString, FileLineData, Product.OutOfHomeCommissionOnly)
                    ImportProductStaging.OutOfHomeDaysToBill = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.OutOfHomeDaysToBill.ToString, FileLineData, Product.OutOfHomeDaysToBill)
                    ImportProductStaging.OutOfHomePrePostBill = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.OutOfHomePrePostBill.ToString, FileLineData, Product.OutOfHomePrePostBill)
                    ImportProductStaging.OutOfHomeVendorDiscounts = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.OutOfHomeVendorDiscounts.ToString, FileLineData, Product.OutOfHomeVendorDiscounts)
                    ImportProductStaging.InternetBillSetting = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.InternetBillSetting.ToString, FileLineData, Product.InternetBillSetting)
                    ImportProductStaging.InternetBillNet = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.InternetBillNet.ToString, FileLineData, Product.InternetBillNet)
                    ImportProductStaging.InternetCommissionOnly = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.InternetCommissionOnly.ToString, FileLineData, Product.InternetCommissionOnly)
                    ImportProductStaging.InternetDaysToBill = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.InternetDaysToBill.ToString, FileLineData, Product.InternetDaysToBill)
                    ImportProductStaging.InternetPrePostBill = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.InternetPrePostBill.ToString, FileLineData, Product.InternetPrePostBill)
                    ImportProductStaging.InternetVendorDiscounts = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.InternetVendorDiscounts.ToString, FileLineData, Product.InternetVendorDiscounts)
                    ImportProductStaging.IsActive = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.IsActive.ToString, FileLineData, Product.IsActive)
                    ImportProductStaging.RadioApplyTaxUseFlags = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.RadioApplyTaxUseFlags.ToString, FileLineData, Product.RadioApplyTaxUseFlags)
                    ImportProductStaging.RadioApplyTaxLineNet = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.RadioApplyTaxLineNet.ToString, FileLineData, Product.RadioApplyTaxLineNet)
                    ImportProductStaging.RadioApplyTaxNetDiscount = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.RadioApplyTaxNetDiscount.ToString, FileLineData, Product.RadioApplyTaxNetDiscount)
                    ImportProductStaging.RadioApplyTaxNetCharge = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.RadioApplyTaxNetCharge.ToString, FileLineData, Product.RadioApplyTaxNetCharge)
                    ImportProductStaging.RadioApplyTaxAddlCharge = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.RadioApplyTaxAddlCharge.ToString, FileLineData, Product.RadioApplyTaxAddlCharge)
                    ImportProductStaging.RadioApplyTaxCommission = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.RadioApplyTaxCommission.ToString, FileLineData, Product.RadioApplyTaxCommission)
                    ImportProductStaging.RadioApplyTaxRebate = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.RadioApplyTaxRebate.ToString, FileLineData, Product.RadioApplyTaxRebate)
                    ImportProductStaging.TelevisionApplyTaxUseFlags = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.TelevisionApplyTaxUseFlags.ToString, FileLineData, Product.TelevisionApplyTaxUseFlags)
                    ImportProductStaging.TelevisionApplyTaxLineNet = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.TelevisionApplyTaxLineNet.ToString, FileLineData, Product.TelevisionApplyTaxLineNet)
                    ImportProductStaging.TelevisionApplyTaxNetDiscount = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.TelevisionApplyTaxNetDiscount.ToString, FileLineData, Product.TelevisionApplyTaxNetDiscount)
                    ImportProductStaging.TelevisionApplyTaxNetCharge = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.TelevisionApplyTaxNetCharge.ToString, FileLineData, Product.TelevisionApplyTaxNetCharge)
                    ImportProductStaging.TelevisionApplyTaxAddlCharge = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.TelevisionApplyTaxAddlCharge.ToString, FileLineData, Product.TelevisionApplyTaxAddlCharge)
                    ImportProductStaging.TelevisionApplyTaxCommission = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.TelevisionApplyTaxCommission.ToString, FileLineData, Product.TelevisionApplyTaxCommission)
                    ImportProductStaging.TelevisionApplyTaxRebate = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.TelevisionApplyTaxRebate.ToString, FileLineData, Product.TelevisionApplyTaxRebate)
                    ImportProductStaging.MagazineApplyTaxUseFlags = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.MagazineApplyTaxUseFlags.ToString, FileLineData, Product.MagazineApplyTaxUseFlags)
                    ImportProductStaging.MagazineApplyTaxLineNet = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.MagazineApplyTaxLineNet.ToString, FileLineData, Product.MagazineApplyTaxLineNet)
                    ImportProductStaging.MagazineApplyTaxNetDiscount = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.MagazineApplyTaxNetDiscount.ToString, FileLineData, Product.MagazineApplyTaxNetDiscount)
                    ImportProductStaging.MagazineApplyTaxNetCharge = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.MagazineApplyTaxNetCharge.ToString, FileLineData, Product.MagazineApplyTaxNetCharge)
                    ImportProductStaging.MagazineApplyTaxAddlCharge = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.MagazineApplyTaxAddlCharge.ToString, FileLineData, Product.MagazineApplyTaxAddlCharge)
                    ImportProductStaging.MagazineApplyTaxCommission = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.MagazineApplyTaxCommission.ToString, FileLineData, Product.MagazineApplyTaxCommission)
                    ImportProductStaging.MagazineApplyTaxRebate = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.MagazineApplyTaxRebate.ToString, FileLineData, Product.MagazineApplyTaxRebate)
                    ImportProductStaging.NewspaperApplyTaxUseFlags = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.NewspaperApplyTaxUseFlags.ToString, FileLineData, Product.NewspaperApplyTaxUseFlags)
                    ImportProductStaging.NewspaperApplyTaxLineNet = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.NewspaperApplyTaxLineNet.ToString, FileLineData, Product.NewspaperApplyTaxLineNet)
                    ImportProductStaging.NewspaperApplyTaxNetDiscount = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.NewspaperApplyTaxNetDiscount.ToString, FileLineData, Product.NewspaperApplyTaxNetDiscount)
                    ImportProductStaging.NewspaperApplyTaxNetCharge = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.NewspaperApplyTaxNetCharge.ToString, FileLineData, Product.NewspaperApplyTaxNetCharge)
                    ImportProductStaging.NewspaperApplyTaxAddlCharge = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.NewspaperApplyTaxAddlCharge.ToString, FileLineData, Product.NewspaperApplyTaxAddlCharge)
                    ImportProductStaging.NewspaperApplyTaxCommission = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.NewspaperApplyTaxCommission.ToString, FileLineData, Product.NewspaperApplyTaxCommission)
                    ImportProductStaging.NewspaperApplyTaxRebate = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.NewspaperApplyTaxRebate.ToString, FileLineData, Product.NewspaperApplyTaxRebate)
                    ImportProductStaging.OutOfHomeApplyTaxUseFlags = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.OutOfHomeApplyTaxUseFlags.ToString, FileLineData, Product.OutOfHomeApplyTaxUseFlags)
                    ImportProductStaging.OutOfHomeApplyTaxLineNet = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.OutOfHomeApplyTaxLineNet.ToString, FileLineData, Product.OutOfHomeApplyTaxLineNet)
                    ImportProductStaging.OutOfHomeApplyTaxNetDiscount = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.OutOfHomeApplyTaxNetDiscount.ToString, FileLineData, Product.OutOfHomeApplyTaxNetDiscount)
                    ImportProductStaging.OutOfHomeApplyTaxNetCharge = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.OutOfHomeApplyTaxNetCharge.ToString, FileLineData, Product.OutOfHomeApplyTaxNetCharge)
                    ImportProductStaging.OutOfHomeApplyTaxAddlCharge = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.OutOfHomeApplyTaxAddlCharge.ToString, FileLineData, Product.OutOfHomeApplyTaxAddlCharge)
                    ImportProductStaging.OutOfHomeApplyTaxCommission = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.OutOfHomeApplyTaxCommission.ToString, FileLineData, Product.OutOfHomeApplyTaxCommission)
                    ImportProductStaging.OutOfHomeApplyTaxRebate = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.OutOfHomeApplyTaxRebate.ToString, FileLineData, Product.OutOfHomeApplyTaxRebate)
                    ImportProductStaging.InternetApplyTaxUseFlags = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.InternetApplyTaxUseFlags.ToString, FileLineData, Product.InternetApplyTaxUseFlags)
                    ImportProductStaging.InternetApplyTaxLineNet = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.InternetApplyTaxLineNet.ToString, FileLineData, Product.InternetApplyTaxLineNet)
                    ImportProductStaging.InternetApplyTaxNetDiscount = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.InternetApplyTaxNetDiscount.ToString, FileLineData, Product.InternetApplyTaxNetDiscount)
                    ImportProductStaging.InternetApplyTaxNetCharge = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.InternetApplyTaxNetCharge.ToString, FileLineData, Product.InternetApplyTaxNetCharge)
                    ImportProductStaging.InternetApplyTaxAddlCharge = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.InternetApplyTaxAddlCharge.ToString, FileLineData, Product.InternetApplyTaxAddlCharge)
                    ImportProductStaging.InternetApplyTaxCommission = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.InternetApplyTaxCommission.ToString, FileLineData, Product.InternetApplyTaxCommission)
                    ImportProductStaging.InternetApplyTaxRebate = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.InternetApplyTaxRebate.ToString, FileLineData, Product.InternetApplyTaxRebate)
                    ImportProductStaging.ProductionBillingSetupComplete = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.ProductionBillingSetupComplete.ToString, FileLineData, Product.ProductionBillingSetupComplete)
                    ImportProductStaging.RadioBillingSetupComplete = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.RadioBillingSetupComplete.ToString, FileLineData, Product.RadioBillingSetupComplete)
                    ImportProductStaging.TelevisionBillingSetupComplete = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.TelevisionBillingSetupComplete.ToString, FileLineData, Product.TelevisionBillingSetupComplete)
                    ImportProductStaging.MagazineBillingSetupComplete = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.MagazineBillingSetupComplete.ToString, FileLineData, Product.MagazineBillingSetupComplete)
                    ImportProductStaging.NewspaperBillingSetupComplete = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.NewspaperBillingSetupComplete.ToString, FileLineData, Product.NewspaperBillingSetupComplete)
                    ImportProductStaging.OutOfHomeBillingSetupComplete = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.OutOfHomeBillingSetupComplete.ToString, FileLineData, Product.OutOfHomeBillingSetupComplete)
                    ImportProductStaging.InternetBillingSetupComplete = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.InternetBillingSetupComplete.ToString, FileLineData, Product.InternetBillingSetupComplete)
                    ImportProductStaging.ProductionUseEstimateBillingRate = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportProductStaging.Properties.ProductionUseEstimateBillingRate.ToString, FileLineData, Product.ProductionUseEstimateBillingRate)

                Else

                    ImportProductStaging.IsNew = True

                    If ImportProductStaging.IsActive Is Nothing Then

                        ImportProductStaging.IsActive = 1

                    End If

                End If

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                If AdvantageFramework.Database.Procedures.ImportProductStaging.Insert(DbContext, ImportProductStaging) = False Then

                    Created = False

                    Try

                        DbContext.ImportProductStagings.Remove(ImportProductStaging)

                    Catch ex As Exception

                    End Try

                End If

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            Catch ex As Exception
                Created = False
            Finally
                CreateImportProductStaging = Created
            End Try

        End Function
        Private Sub FillProductEntityFromImportProductStagingEntity(ByRef Product As AdvantageFramework.Database.Entities.Product, ByVal ImportProductStaging As AdvantageFramework.Database.Entities.ImportProductStaging)

            Product.Name = ImportProductStaging.Name
            Product.AttentionTo = ImportProductStaging.AttentionTo
            Product.BillingAddress = ImportProductStaging.BillingAddress
            Product.BillingAddress2 = ImportProductStaging.BillingAddress2
            Product.BillingCity = ImportProductStaging.BillingCity
            Product.BillingCounty = ImportProductStaging.BillingCounty
            Product.BillingState = ImportProductStaging.BillingState
            Product.BillingCountry = ImportProductStaging.BillingCountry
            Product.BillingZip = ImportProductStaging.BillingZip
            Product.BillingPhone = ImportProductStaging.BillingPhone
            Product.BillingPhoneExtension = ImportProductStaging.BillingPhoneExtension
            Product.BillingFax = ImportProductStaging.BillingFax
            Product.BillingFaxExtension = ImportProductStaging.BillingFaxExtension
            Product.StatementAddress = ImportProductStaging.StatementAddress
            Product.StatementAddress2 = ImportProductStaging.StatementAddress2
            Product.StatementCity = ImportProductStaging.StatementCity
            Product.StatementCounty = ImportProductStaging.StatementCounty
            Product.StatementState = ImportProductStaging.StatementState
            Product.StatementCountry = ImportProductStaging.StatementCountry
            Product.StatementZip = ImportProductStaging.StatementZip
            Product.StatementPhone = ImportProductStaging.StatementPhone
            Product.StatementPhoneExtension = ImportProductStaging.StatementPhoneExtension
            Product.StatementFax = ImportProductStaging.StatementFax
            Product.StatementFaxExtension = ImportProductStaging.StatementFaxExtension
            Product.OfficeCode = ImportProductStaging.OfficeCode
            Product.ProductionConsolidateFunctions = ImportProductStaging.ProductionConsolidateFunctions
            Product.ProductionContingency = ImportProductStaging.ProductionContingency
            Product.ProductionMarkup = ImportProductStaging.ProductionMarkup
            Product.ProductionBillNet = ImportProductStaging.ProductionBillNet
            Product.ProductionVendorDiscounts = ImportProductStaging.ProductionVendorDiscounts
            Product.ProductionApprovedEstimatedRequired = ImportProductStaging.ProductionApprovedEstimatedRequired
            Product.ProductionTaxCode = ImportProductStaging.ProductionTaxCode
            Product.RadioRebate = ImportProductStaging.RadioRebate
            Product.RadioBillNet = ImportProductStaging.RadioBillNet
            Product.RadioVendorDiscounts = ImportProductStaging.RadioVendorDiscounts
            Product.RadioCommissionOnly = ImportProductStaging.RadioCommissionOnly
            Product.RadioTaxCode = ImportProductStaging.RadioTaxCode
            Product.RadioDaysToBill = ImportProductStaging.RadioDaysToBill
            Product.RadioPrePostBill = ImportProductStaging.RadioPrePostBill
            Product.RadioBillSetting = ImportProductStaging.RadioBillSetting
            Product.TelevisionRebate = ImportProductStaging.TelevisionRebate
            Product.TelevisionBillNet = ImportProductStaging.TelevisionBillNet
            Product.TelevisionVendorDiscounts = ImportProductStaging.TelevisionVendorDiscounts
            Product.TelevisionCommissionOnly = ImportProductStaging.TelevisionCommissionOnly
            Product.TelevisionTaxCode = ImportProductStaging.TelevisionTaxCode
            Product.TelevisionDaysToBill = ImportProductStaging.TelevisionDaysToBill
            Product.TelevisionPrePostBill = ImportProductStaging.TelevisionPrePostBill
            Product.TelevisionBillSetting = ImportProductStaging.TelevisionBillSetting
            Product.MagazineRebate = ImportProductStaging.MagazineRebate
            Product.MagazineBillNet = ImportProductStaging.MagazineBillNet
            Product.MagazineVendorDiscounts = ImportProductStaging.MagazineVendorDiscounts
            Product.MagazineCommissionOnly = ImportProductStaging.MagazineCommissionOnly
            Product.MagazineTaxCode = ImportProductStaging.MagazineTaxCode
            Product.MagazineDaysToBill = ImportProductStaging.MagazineDaysToBill
            Product.MagazinePrePostBill = ImportProductStaging.MagazinePrePostBill
            Product.MagazineBillSetting = ImportProductStaging.MagazineBillSetting
            Product.NewspaperMarkup = ImportProductStaging.NewspaperMarkup
            Product.NewspaperBillNet = ImportProductStaging.NewspaperBillNet
            Product.NewspaperVendorDiscounts = ImportProductStaging.NewspaperVendorDiscounts
            Product.NewspaperCommissionOnly = ImportProductStaging.NewspaperCommissionOnly
            Product.NewspaperTaxCode = ImportProductStaging.NewspaperTaxCode
            Product.NewspaperDaysToBill = ImportProductStaging.NewspaperDaysToBill
            Product.NewspaperPrePostBill = ImportProductStaging.NewspaperPrePostBill
            Product.NewspaperBillSetting = ImportProductStaging.NewspaperBillSetting
            Product.NewspaperRebate = ImportProductStaging.NewspaperRebate
            Product.OutOfHomeRebate = ImportProductStaging.OutOfHomeRebate
            Product.InternetRebate = ImportProductStaging.InternetRebate
            Product.RadioMarkup = ImportProductStaging.RadioMarkup
            Product.TelevisionMarkup = ImportProductStaging.TelevisionMarkup
            Product.MagazineMarkup = ImportProductStaging.MagazineMarkup
            Product.OutOfHomeMarkup = ImportProductStaging.OutOfHomeMarkup
            Product.InternetMarkup = ImportProductStaging.InternetMarkup
            Product.OutOfHomeBillSetting = ImportProductStaging.OutOfHomeBillSetting
            Product.OutOfHomeBillNet = ImportProductStaging.OutOfHomeBillNet
            Product.OutOfHomeCommissionOnly = ImportProductStaging.OutOfHomeCommissionOnly
            Product.OutOfHomeDaysToBill = ImportProductStaging.OutOfHomeDaysToBill
            Product.OutOfHomePrePostBill = ImportProductStaging.OutOfHomePrePostBill
            Product.OutOfHomeTaxCode = ImportProductStaging.OutOfHomeTaxCode
            Product.OutOfHomeVendorDiscounts = ImportProductStaging.OutOfHomeVendorDiscounts
            Product.InternetBillSetting = ImportProductStaging.InternetBillSetting
            Product.InternetBillNet = ImportProductStaging.InternetBillNet
            Product.InternetCommissionOnly = ImportProductStaging.InternetCommissionOnly
            Product.InternetDaysToBill = ImportProductStaging.InternetDaysToBill
            Product.InternetPrePostBill = ImportProductStaging.InternetPrePostBill
            Product.InternetTaxCode = ImportProductStaging.InternetTaxCode
            Product.InternetVendorDiscounts = ImportProductStaging.InternetVendorDiscounts
            Product.ProductionAlertGroup = ImportProductStaging.ProductionAlertGroup
            Product.IsActive = ImportProductStaging.IsActive
            Product.UserDefinedField1 = ImportProductStaging.UserDefinedField1
            Product.UserDefinedField2 = ImportProductStaging.UserDefinedField2
            Product.UserDefinedField3 = ImportProductStaging.UserDefinedField3
            Product.UserDefinedField4 = ImportProductStaging.UserDefinedField4
            Product.RadioApplyTaxUseFlags = ImportProductStaging.RadioApplyTaxUseFlags
            Product.RadioApplyTaxLineNet = ImportProductStaging.RadioApplyTaxLineNet
            Product.RadioApplyTaxNetDiscount = ImportProductStaging.RadioApplyTaxNetDiscount
            Product.RadioApplyTaxNetCharge = ImportProductStaging.RadioApplyTaxNetCharge
            Product.RadioApplyTaxAddlCharge = ImportProductStaging.RadioApplyTaxAddlCharge
            Product.RadioApplyTaxCommission = ImportProductStaging.RadioApplyTaxCommission
            Product.RadioApplyTaxRebate = ImportProductStaging.RadioApplyTaxRebate
            Product.TelevisionApplyTaxUseFlags = ImportProductStaging.TelevisionApplyTaxUseFlags
            Product.TelevisionApplyTaxLineNet = ImportProductStaging.TelevisionApplyTaxLineNet
            Product.TelevisionApplyTaxNetDiscount = ImportProductStaging.TelevisionApplyTaxNetDiscount
            Product.TelevisionApplyTaxNetCharge = ImportProductStaging.TelevisionApplyTaxNetCharge
            Product.TelevisionApplyTaxAddlCharge = ImportProductStaging.TelevisionApplyTaxAddlCharge
            Product.TelevisionApplyTaxCommission = ImportProductStaging.TelevisionApplyTaxCommission
            Product.TelevisionApplyTaxRebate = ImportProductStaging.TelevisionApplyTaxRebate
            Product.MagazineApplyTaxUseFlags = ImportProductStaging.MagazineApplyTaxUseFlags
            Product.MagazineApplyTaxLineNet = ImportProductStaging.MagazineApplyTaxLineNet
            Product.MagazineApplyTaxNetDiscount = ImportProductStaging.MagazineApplyTaxNetDiscount
            Product.MagazineApplyTaxNetCharge = ImportProductStaging.MagazineApplyTaxNetCharge
            Product.MagazineApplyTaxAddlCharge = ImportProductStaging.MagazineApplyTaxAddlCharge
            Product.MagazineApplyTaxCommission = ImportProductStaging.MagazineApplyTaxCommission
            Product.MagazineApplyTaxRebate = ImportProductStaging.MagazineApplyTaxRebate
            Product.NewspaperApplyTaxUseFlags = ImportProductStaging.NewspaperApplyTaxUseFlags
            Product.NewspaperApplyTaxLineNet = ImportProductStaging.NewspaperApplyTaxLineNet
            Product.NewspaperApplyTaxNetDiscount = ImportProductStaging.NewspaperApplyTaxNetDiscount
            Product.NewspaperApplyTaxNetCharge = ImportProductStaging.NewspaperApplyTaxNetCharge
            Product.NewspaperApplyTaxAddlCharge = ImportProductStaging.NewspaperApplyTaxAddlCharge
            Product.NewspaperApplyTaxCommission = ImportProductStaging.NewspaperApplyTaxCommission
            Product.NewspaperApplyTaxRebate = ImportProductStaging.NewspaperApplyTaxRebate
            Product.OutOfHomeApplyTaxUseFlags = ImportProductStaging.OutOfHomeApplyTaxUseFlags
            Product.OutOfHomeApplyTaxLineNet = ImportProductStaging.OutOfHomeApplyTaxLineNet
            Product.OutOfHomeApplyTaxNetDiscount = ImportProductStaging.OutOfHomeApplyTaxNetDiscount
            Product.OutOfHomeApplyTaxNetCharge = ImportProductStaging.OutOfHomeApplyTaxNetCharge
            Product.OutOfHomeApplyTaxAddlCharge = ImportProductStaging.OutOfHomeApplyTaxAddlCharge
            Product.OutOfHomeApplyTaxCommission = ImportProductStaging.OutOfHomeApplyTaxCommission
            Product.OutOfHomeApplyTaxRebate = ImportProductStaging.OutOfHomeApplyTaxRebate
            Product.InternetApplyTaxUseFlags = ImportProductStaging.InternetApplyTaxUseFlags
            Product.InternetApplyTaxLineNet = ImportProductStaging.InternetApplyTaxLineNet
            Product.InternetApplyTaxNetDiscount = ImportProductStaging.InternetApplyTaxNetDiscount
            Product.InternetApplyTaxNetCharge = ImportProductStaging.InternetApplyTaxNetCharge
            Product.InternetApplyTaxAddlCharge = ImportProductStaging.InternetApplyTaxAddlCharge
            Product.InternetApplyTaxCommission = ImportProductStaging.InternetApplyTaxCommission
            Product.InternetApplyTaxRebate = ImportProductStaging.InternetApplyTaxRebate
            Product.ProductionBillingSetupComplete = ImportProductStaging.ProductionBillingSetupComplete
            Product.RadioBillingSetupComplete = ImportProductStaging.RadioBillingSetupComplete
            Product.TelevisionBillingSetupComplete = ImportProductStaging.TelevisionBillingSetupComplete
            Product.MagazineBillingSetupComplete = ImportProductStaging.MagazineBillingSetupComplete
            Product.NewspaperBillingSetupComplete = ImportProductStaging.NewspaperBillingSetupComplete
            Product.OutOfHomeBillingSetupComplete = ImportProductStaging.OutOfHomeBillingSetupComplete
            Product.InternetBillingSetupComplete = ImportProductStaging.InternetBillingSetupComplete
            Product.ProductionUseEstimateBillingRate = ImportProductStaging.ProductionUseEstimateBillingRate
            Product.BatchName = ImportProductStaging.BatchName

        End Sub

#End Region

#Region "   Function "

        Public Function CreateFunctionsFromImport(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportFunctionStagings As Generic.List(Of AdvantageFramework.Database.Entities.ImportFunctionStaging),
                                                  ByVal ValidateBeforeImporting As Boolean) As Boolean

            'objects
            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim Created As Boolean = True
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
            Dim IsValid As Boolean = True

            Try

                PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.Function)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                For Each ImportFunctionStaging In ImportFunctionStagings

                    IsValid = True

                    ImportFunctionStaging.DbContext = DbContext

                    If ImportFunctionStaging.IsOnHold = False Then

                        If ValidateBeforeImporting Then

                            ImportFunctionStaging.ValidateEntity(IsValid)

                        Else

                            IsValid = Not ImportFunctionStaging.HasError()

                        End If

                        If IsValid Then

                            If ImportFunctionStaging.IsNew Then

                                [Function] = New AdvantageFramework.Database.Entities.Function
                                [Function].DbContext = DbContext

                                [Function].Code = ImportFunctionStaging.Code

                                FillFunctionEntityFromImportFunctionStagingEntity([Function], ImportFunctionStaging)

                                SetEmptyStringsToNull(PropertyDescriptorsList, [Function])

                                If AdvantageFramework.Database.Procedures.Function.Insert(DbContext, [Function]) Then

                                    AdvantageFramework.Database.Procedures.ImportFunctionStaging.Delete(DbContext, ImportFunctionStaging)

                                Else

                                    DbContext.Functions.Remove([Function])

                                    Created = False

                                End If

                            Else

                                [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, ImportFunctionStaging.Code)

                                If [Function] IsNot Nothing Then

                                    ImportFunctionStaging.Description = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate([Function].Description, ImportFunctionStaging.Description)

                                    FillFunctionEntityFromImportFunctionStagingEntity([Function], ImportFunctionStaging)

                                    If AdvantageFramework.Database.Procedures.Function.Update(DbContext, [Function]) Then

                                        AdvantageFramework.Database.Procedures.ImportFunctionStaging.Delete(DbContext, ImportFunctionStaging)

                                    Else

                                        Created = False

                                    End If

                                End If

                            End If

                        Else

                            Created = False

                        End If

                    End If

                Next

            Catch ex As Exception
                Created = False
            End Try

            CreateFunctionsFromImport = Created

        End Function
        Private Function CreateImportFunctionStaging(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                     ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                     ByVal ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail),
                                                     ByVal FileLineData As Object, ByVal BatchName As String,
                                                     ByVal AutoTrimOverFlowData As Boolean, ByVal DataTable As System.Data.DataTable)

            'objects
            'objects
            Dim Created As Boolean = True
            Dim ImportFunctionStaging As AdvantageFramework.Database.Entities.ImportFunctionStaging = Nothing
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing

            Try

                ImportFunctionStaging = New AdvantageFramework.Database.Entities.ImportFunctionStaging

                ImportFunctionStaging.DbContext = DbContext
                ImportFunctionStaging.BatchName = BatchName

                CreateEntityFromTemplateDataTable(ImportTemplate, DataTable, FileLineData, ImportFunctionStaging, AutoTrimOverFlowData)

                Try

                    [Function] = AdvantageFramework.Database.Procedures.Function.Load(DbContext).Where(Function(Entity) Entity.Code.ToUpper = ImportFunctionStaging.Code.ToUpper).SingleOrDefault

                Catch ex As Exception
                    [Function] = Nothing
                End Try

                If [Function] IsNot Nothing Then

                    ImportFunctionStaging.IsNew = False

                    ImportFunctionStaging.Code = [Function].Code

                    If ImportFunctionStaging.Description = "*" OrElse String.IsNullOrWhiteSpace(ImportFunctionStaging.Description) Then

                        ImportFunctionStaging.Description = [Function].Description

                    End If

                    If ImportFunctionStaging.Type = "*" OrElse String.IsNullOrWhiteSpace(ImportFunctionStaging.Type) Then

                        ImportFunctionStaging.Type = [Function].Type

                    End If

                    ImportFunctionStaging.FunctionHeadingID = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportFunctionStaging.Properties.FunctionHeadingID.ToString, FileLineData, [Function].FunctionHeadingID)
                    ImportFunctionStaging.FunctionOrder = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportFunctionStaging.Properties.FunctionOrder.ToString, FileLineData, [Function].FunctionOrder)
                    ImportFunctionStaging.CPMFlag = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportFunctionStaging.Properties.CPMFlag.ToString, FileLineData, [Function].CPMFlag)
                    ImportFunctionStaging.EmployeeExpenseFlag = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportFunctionStaging.Properties.EmployeeExpenseFlag.ToString, FileLineData, [Function].EmployeeExpenseFlag)
                    ImportFunctionStaging.IsInactive = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportFunctionStaging.Properties.IsInactive.ToString, FileLineData, [Function].IsInactive)

                Else

                    ImportFunctionStaging.IsNew = True

                End If

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                If AdvantageFramework.Database.Procedures.ImportFunctionStaging.Insert(DbContext, ImportFunctionStaging) = False Then

                    Created = False

                    Try

                        DbContext.DeleteEntityObject(ImportFunctionStaging)

                    Catch ex As Exception

                    End Try

                End If

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            Catch ex As Exception
                Created = False
            Finally
                CreateImportFunctionStaging = Created
            End Try

        End Function
        Private Sub FillFunctionEntityFromImportFunctionStagingEntity(ByRef [Function] As AdvantageFramework.Database.Entities.Function, ByVal ImportFunctionStaging As AdvantageFramework.Database.Entities.ImportFunctionStaging)

            [Function].Description = ImportFunctionStaging.Description
            [Function].Type = ImportFunctionStaging.Type
            [Function].IsInactive = ImportFunctionStaging.IsInactive
            [Function].DepartmentTeamCode = ImportFunctionStaging.DepartmentTeamCode
            [Function].NonBillableClientGLACode = ImportFunctionStaging.NonBillableClientGLACode
            [Function].OverheadGLACode = ImportFunctionStaging.OverheadGLACode
            [Function].FunctionHeadingID = ImportFunctionStaging.FunctionHeadingID
            [Function].LineConsolidation = ImportFunctionStaging.LineConsolidation
            [Function].CPMFlag = ImportFunctionStaging.CPMFlag
            [Function].FunctionOrder = ImportFunctionStaging.FunctionOrder
            [Function].EmployeeExpenseFlag = ImportFunctionStaging.EmployeeExpenseFlag

        End Sub

#End Region

#Region "   Charts of Account "

        Public Function CreateChartsOfAccountFromImport(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportGeneralLedgerAccountStagings As Generic.List(Of AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging),
                                                        ByVal ValidateBeforeImporting As Boolean) As Boolean

            'objects
            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim Created As Boolean = True
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim IsValid As Boolean = True

            Try

                PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.GeneralLedgerAccount)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                For Each ImportGeneralLedgerAccountStaging In ImportGeneralLedgerAccountStagings

                    IsValid = True

                    ImportGeneralLedgerAccountStaging.DbContext = DbContext

                    If ImportGeneralLedgerAccountStaging.IsOnHold = False Then

                        If ValidateBeforeImporting Then

                            ImportGeneralLedgerAccountStaging.ValidateEntity(IsValid)

                        Else

                            IsValid = Not ImportGeneralLedgerAccountStaging.HasError()

                        End If

                        If IsValid Then

                            If ImportGeneralLedgerAccountStaging.IsNew Then

                                GeneralLedgerAccount = New AdvantageFramework.Database.Entities.GeneralLedgerAccount
                                GeneralLedgerAccount.DbContext = DbContext

                                GeneralLedgerAccount.Code = ImportGeneralLedgerAccountStaging.Code

                                FillGeneralLedgerAccountEntityFromImportGeneralLedgerAccountStagingEntity(GeneralLedgerAccount, ImportGeneralLedgerAccountStaging)

                                SetEmptyStringsToNull(PropertyDescriptorsList, GeneralLedgerAccount)

                                If AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Insert(DbContext, GeneralLedgerAccount) Then

                                    AdvantageFramework.Database.Procedures.ImportGeneralLedgerAccountStaging.Delete(DbContext, ImportGeneralLedgerAccountStaging)

                                Else

                                    DbContext.DeleteEntityObject(GeneralLedgerAccount)

                                    Created = False

                                End If

                            Else

                                GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, ImportGeneralLedgerAccountStaging.Code)

                                If GeneralLedgerAccount IsNot Nothing Then

                                    ImportGeneralLedgerAccountStaging.Description = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(GeneralLedgerAccount.Description, ImportGeneralLedgerAccountStaging.Description)

                                    FillGeneralLedgerAccountEntityFromImportGeneralLedgerAccountStagingEntity(GeneralLedgerAccount, ImportGeneralLedgerAccountStaging)

                                    If AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Update(DbContext, GeneralLedgerAccount) Then

                                        AdvantageFramework.Database.Procedures.ImportGeneralLedgerAccountStaging.Delete(DbContext, ImportGeneralLedgerAccountStaging)

                                    Else

                                        Created = False

                                    End If

                                End If

                            End If

                        Else

                            Created = False

                        End If

                    End If

                Next

            Catch ex As Exception
                Created = False
            End Try

            CreateChartsOfAccountFromImport = Created

        End Function
        Private Function CreateImportGeneralLedgerStaging(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                          ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                          ByVal ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail),
                                                          ByVal FileLineData As Object, ByVal BatchName As String,
                                                          ByVal AutoTrimOverFlowData As Boolean, ByVal DataTable As System.Data.DataTable)

            'objects
            Dim Created As Boolean = True
            Dim ImportGeneralLedgerAccountStaging As AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing

            Try

                ImportGeneralLedgerAccountStaging = New AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging

                ImportGeneralLedgerAccountStaging.DbContext = DbContext
                ImportGeneralLedgerAccountStaging.BatchName = BatchName

                CreateEntityFromTemplateDataTable(ImportTemplate, DataTable, FileLineData, ImportGeneralLedgerAccountStaging, AutoTrimOverFlowData)

                Try

                    GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(DbContext).Where(Function(Entity) Entity.Code.ToUpper = ImportGeneralLedgerAccountStaging.Code.ToUpper).SingleOrDefault

                Catch ex As Exception
                    GeneralLedgerAccount = Nothing
                End Try

                If GeneralLedgerAccount IsNot Nothing Then

                    ImportGeneralLedgerAccountStaging.IsNew = False

                    ImportGeneralLedgerAccountStaging.Code = GeneralLedgerAccount.Code

                    If ImportGeneralLedgerAccountStaging.Description = "*" OrElse String.IsNullOrWhiteSpace(ImportGeneralLedgerAccountStaging.Description) Then

                        ImportGeneralLedgerAccountStaging.Description = GeneralLedgerAccount.Description

                    End If

                    If ImportGeneralLedgerAccountStaging.Type = "*" OrElse String.IsNullOrWhiteSpace(ImportGeneralLedgerAccountStaging.Type) Then

                        ImportGeneralLedgerAccountStaging.Type = GeneralLedgerAccount.Type

                    End If

                    ImportGeneralLedgerAccountStaging.BalanceType = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging.Properties.BalanceType.ToString, FileLineData, GeneralLedgerAccount.BalanceType)
                    ImportGeneralLedgerAccountStaging.CDPRequired = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging.Properties.CDPRequired.ToString, FileLineData, GeneralLedgerAccount.CDPRequired)
                    ImportGeneralLedgerAccountStaging.Payroll = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging.Properties.Payroll.ToString, FileLineData, GeneralLedgerAccount.Payroll)
                    ImportGeneralLedgerAccountStaging.PurchaseOrder = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging.Properties.PurchaseOrder.ToString, FileLineData, GeneralLedgerAccount.PurchaseOrder)

                Else

                    ImportGeneralLedgerAccountStaging.IsNew = True

                End If

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                If AdvantageFramework.Database.Procedures.ImportGeneralLedgerAccountStaging.Insert(DbContext, ImportGeneralLedgerAccountStaging) = False Then

                    Created = False

                    Try

                        DbContext.DeleteEntityObject(ImportGeneralLedgerAccountStaging)

                    Catch ex As Exception

                    End Try

                End If

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            Catch ex As Exception
                Created = False
            Finally
                CreateImportGeneralLedgerStaging = Created
            End Try

        End Function
        Private Sub FillGeneralLedgerAccountEntityFromImportGeneralLedgerAccountStagingEntity(ByRef GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount, ByVal ImportGeneralLedgerAccountStaging As AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging)

            GeneralLedgerAccount.Description = ImportGeneralLedgerAccountStaging.Description
            GeneralLedgerAccount.Type = ImportGeneralLedgerAccountStaging.Type
            GeneralLedgerAccount.CDPRequired = ImportGeneralLedgerAccountStaging.CDPRequired
            GeneralLedgerAccount.Active = ImportGeneralLedgerAccountStaging.Active
            GeneralLedgerAccount.DepartmentCode = ImportGeneralLedgerAccountStaging.DepartmentCode
            GeneralLedgerAccount.BalanceType = ImportGeneralLedgerAccountStaging.BalanceType
            GeneralLedgerAccount.BaseCode = ImportGeneralLedgerAccountStaging.BaseCode
            GeneralLedgerAccount.GeneralLedgerOfficeCrossReferenceCode = ImportGeneralLedgerAccountStaging.GeneralLedgerOfficeCrossReferenceCode
            GeneralLedgerAccount.Payroll = ImportGeneralLedgerAccountStaging.Payroll
            GeneralLedgerAccount.PurchaseOrder = ImportGeneralLedgerAccountStaging.PurchaseOrder

        End Sub

#End Region

#Region "   Accounts Receivable "

        Private Function CreateImportAccountsReceivableStaging(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                               ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                               ByVal ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail),
                                                               ByVal FileLineData As Object, ByVal BatchName As String,
                                                               ByVal AutoTrimOverFlowData As Boolean, ByVal DataTable As System.Data.DataTable)

            'objects
            Dim Created As Boolean = True
            Dim AccountReceivableImportStaging As AdvantageFramework.Database.Entities.AccountReceivableImportStaging = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim InvoiceDate As Nullable(Of Date) = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim SourceClientCode As String = Nothing
            Dim SourceDivisionCode As String = Nothing
            Dim SourceProductCode As String = Nothing
            Dim ClientCrossReference As AdvantageFramework.Database.Entities.ClientCrossReference = Nothing
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim OfficeSalesClassAccount As AdvantageFramework.Database.Entities.OfficeSalesClassAccount = Nothing
            Dim SalesClassTypeCode As String = Nothing

            Try

                AccountReceivableImportStaging = New AdvantageFramework.Database.Entities.AccountReceivableImportStaging

                AccountReceivableImportStaging.DbContext = DbContext
                AccountReceivableImportStaging.BatchName = BatchName
                AccountReceivableImportStaging.AdvanARType = "IN"

                AccountReceivableImportStaging.ImportTemplateID = ImportTemplate.ID

                CreateEntityFromTemplateDataTable(ImportTemplate, DataTable, FileLineData, AccountReceivableImportStaging, AutoTrimOverFlowData)

                DataColumn = DataTable.Columns(AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.InvoiceDate.ToString)

                If DataColumn IsNot Nothing Then

                    If String.IsNullOrEmpty(DataColumn.ExtendedProperties("DateFormat")) Then

                        InvoiceDate = ScrubDate(FileLineData(DataColumn.ExtendedProperties("CSVPosition")))

                        If InvoiceDate Is Nothing Then

                            AccountReceivableImportStaging.InvoiceDate = " "

                        Else

                            AccountReceivableImportStaging.InvoiceDate = Format(CInt(InvoiceDate.Value.Month), "0#") & "/" & Format(CInt(InvoiceDate.Value.Day), "0#") & "/" & CInt(Mid(InvoiceDate.Value.Year, 3, 2))

                        End If

                    Else

                        InvoiceDate = ScrubDate(FileLineData(DataColumn.ExtendedProperties("CSVPosition")), DataColumn.ExtendedProperties("DateFormat"))

                        If InvoiceDate Is Nothing Then

                            AccountReceivableImportStaging.InvoiceDate = " "

                        Else

                            AccountReceivableImportStaging.InvoiceDate = Format(CInt(InvoiceDate.Value.Month), "0#") & "/" & Format(CInt(InvoiceDate.Value.Day), "0#") & "/" & CInt(Mid(InvoiceDate.Value.Year, 3, 2))

                        End If

                    End If

                    If AccountReceivableImportStaging.InvoiceDate = "12:00:00 AM" Then

                        AccountReceivableImportStaging.InvoiceDate = " "

                    End If

                End If

                If ImportTemplate.Type = Importing.ImportTemplateTypes.AccountsReceivable_Custom AndAlso ImportTemplate.RecordSourceID.HasValue Then

                    DataColumn = DataTable.Columns(AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.ClientCode.ToString)

                    If DataColumn IsNot Nothing Then

                        SourceClientCode = FileLineData(DataColumn.Ordinal)

                    End If

                    DataColumn = DataTable.Columns(AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.ProductCode.ToString)

                    If DataColumn IsNot Nothing Then

                        SourceProductCode = FileLineData(DataColumn.Ordinal)

                    End If

                    Try

                        ClientCrossReference = (From CCR In AdvantageFramework.Database.Procedures.ClientCrossReference.LoadByRecordSourceID(DbContext, ImportTemplate.RecordSourceID.Value).ToList
                                                Where CCR.SourceClientCode = String.Concat(SourceClientCode) AndAlso
                                                      CCR.SourceProductCode = String.Concat(SourceProductCode)
                                                Select CCR).SingleOrDefault

                    Catch ex As Exception
                        ClientCrossReference = Nothing
                    End Try

                    If ClientCrossReference IsNot Nothing Then

                        AccountReceivableImportStaging.ClientCode = ClientCrossReference.ClientCode
                        AccountReceivableImportStaging.DivisionCode = ClientCrossReference.DivisionCode
                        AccountReceivableImportStaging.ProductCode = ClientCrossReference.ProductCode

                    End If

                    SalesClassTypeCode = AccountReceivableImportStaging.RecordType

                    Select Case AccountReceivableImportStaging.RecordType

                        Case "P"

                            AccountReceivableImportStaging.RecordType = "P"

                        Case "I", "M", "N", "O", "R", "T"

                            AccountReceivableImportStaging.RecordType = "M"

                    End Select

                ElseIf ImportTemplate.Type = Importing.ImportTemplateTypes.AccountsReceivable_Default AndAlso ImportTemplate.RecordSourceID.HasValue Then

                    DataColumn = DataTable.Columns(AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.ClientCode.ToString)

                    If DataColumn IsNot Nothing Then

                        SourceClientCode = FileLineData(DataColumn.Ordinal)

                    End If

                    DataColumn = DataTable.Columns(AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.DivisionCode.ToString)

                    If DataColumn IsNot Nothing Then

                        SourceDivisionCode = FileLineData(DataColumn.Ordinal)

                    End If

                    DataColumn = DataTable.Columns(AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.ProductCode.ToString)

                    If DataColumn IsNot Nothing Then

                        SourceProductCode = FileLineData(DataColumn.Ordinal)

                    End If

                    Try

                        ClientCrossReference = (From CCR In AdvantageFramework.Database.Procedures.ClientCrossReference.LoadByRecordSourceID(DbContext, ImportTemplate.RecordSourceID.Value).ToList
                                                Where String.Concat(CCR.SourceClientCode) = String.Concat(SourceClientCode) AndAlso
                                                      String.Concat(CCR.SourceDivisionCode) = String.Concat(SourceDivisionCode) AndAlso
                                                      String.Concat(CCR.SourceProductCode) = String.Concat(SourceProductCode)
                                                Select CCR).SingleOrDefault

                    Catch ex As Exception
                        ClientCrossReference = Nothing
                    End Try

                    If ClientCrossReference IsNot Nothing Then

                        AccountReceivableImportStaging.ClientCode = ClientCrossReference.ClientCode
                        AccountReceivableImportStaging.DivisionCode = ClientCrossReference.DivisionCode
                        AccountReceivableImportStaging.ProductCode = ClientCrossReference.ProductCode

                    End If

                End If

                If AccountReceivableImportStaging.ClientCode Is Nothing Then

                    AccountReceivableImportStaging.ClientCode = ""

                End If

                If (String.IsNullOrWhiteSpace(AccountReceivableImportStaging.OfficeCode) AndAlso Not String.IsNullOrWhiteSpace(AccountReceivableImportStaging.ClientCode) AndAlso
                        Not String.IsNullOrWhiteSpace(AccountReceivableImportStaging.DivisionCode) AndAlso Not String.IsNullOrWhiteSpace(AccountReceivableImportStaging.ProductCode)) OrElse
                        ImportTemplate.Type = Importing.ImportTemplateTypes.AccountsReceivable_Custom Then

                    Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, AccountReceivableImportStaging.ClientCode, AccountReceivableImportStaging.DivisionCode, AccountReceivableImportStaging.ProductCode)

                    If Product IsNot Nothing Then

                        If ImportTemplate.Type = Importing.ImportTemplateTypes.AccountsReceivable_Custom Then 'AccountsReceivable_Custom should always take the office from the source file!

                            Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, AccountReceivableImportStaging.OfficeCode)

                            If Office IsNot Nothing Then

                                AccountReceivableImportStaging.GLACodeAR = Office.AccountsReceivableGLACode

                            End If

                        Else

                            AccountReceivableImportStaging.OfficeCode = Product.OfficeCode

                        End If

                        If ImportTemplate.Type = Importing.ImportTemplateTypes.AccountsReceivable_Custom Then

                            If AccountReceivableImportStaging.RecordType <> "P" Then

                                OfficeSalesClassAccount = (From OSCA In AdvantageFramework.Database.Procedures.OfficeSalesClassAccount.Load(DbContext)
                                                           Where OSCA.OfficeCode = AccountReceivableImportStaging.OfficeCode AndAlso
                                                                 OSCA.SalesClass.SalesClassTypeCode = SalesClassTypeCode
                                                           Select OSCA).OrderBy(Function(OSCA) OSCA.SalesClassCode).FirstOrDefault

                            End If

                            If OfficeSalesClassAccount IsNot Nothing Then

                                AccountReceivableImportStaging.GLACodeSales = OfficeSalesClassAccount.MediaSalesGLACode
                                AccountReceivableImportStaging.GLACodeCOS = OfficeSalesClassAccount.MediaCostOfSalesGLACode

                                AccountReceivableImportStaging.SalesClassCode = OfficeSalesClassAccount.SalesClassCode

                            Else

                                If String.IsNullOrWhiteSpace(AccountReceivableImportStaging.GLACodeSales) Then

                                    AccountReceivableImportStaging.GLACodeSales = Product.Office.MediaSalesGLACode

                                End If

                                If String.IsNullOrWhiteSpace(AccountReceivableImportStaging.GLACodeCOS) Then

                                    AccountReceivableImportStaging.GLACodeCOS = Product.Office.MediaCostOfSalesGLACode

                                End If

                            End If

                            If String.IsNullOrWhiteSpace(AccountReceivableImportStaging.GLACodeOffset) Then

                                AccountReceivableImportStaging.GLACodeOffset = Product.Office.MediaAccruedAccountsPayableGLACode

                            End If

                        End If

                    End If

                End If

                If AccountReceivableImportStaging.ImportARInvoiceNumber Is Nothing Then

                    Created = False

                ElseIf Not AdvantageFramework.Database.Procedures.AccountReceivableImportStaging.Load(DbContext).
                        Where(Function(Entity) Entity.ImportARInvoiceNumber.ToUpper = AccountReceivableImportStaging.ImportARInvoiceNumber.ToUpper AndAlso
                                               Entity.AdvanARType = AccountReceivableImportStaging.AdvanARType).Any Then

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    If AdvantageFramework.Database.Procedures.AccountReceivableImportStaging.Insert(DbContext, AccountReceivableImportStaging) = False Then

                        Created = False

                        Try

                            DbContext.DeleteEntityObject(AccountReceivableImportStaging)

                        Catch ex As Exception

                        End Try

                    End If

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Else

                    Created = False

                End If

            Catch ex As Exception
                Created = False
            Finally
                CreateImportAccountsReceivableStaging = Created
            End Try

        End Function

#End Region

#Region "   Digital Results "

        Public Function LoadDigitalResultsTemplateFieldNames() As Generic.Dictionary(Of Long, String)

            'objects
            Dim FieldNameDictionary As Generic.Dictionary(Of Long, String) = Nothing
            Dim InvalidFieldNames As String() = Nothing

            Try

                InvalidFieldNames = {AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.ID.ToString,
                                     AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.BatchName.ToString,
                                     AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.TemplateID.ToString,
                                     AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.MediaPlanDetailLevelLineID.ToString}

                FieldNameDictionary = New Generic.Dictionary(Of Long, String)

                For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties), False)

                    If InvalidFieldNames.Contains(KeyValuePair.Value) = False Then

                        FieldNameDictionary.Add(KeyValuePair.Key, AdvantageFramework.StringUtilities.GetNameAsWords(KeyValuePair.Value))

                    End If

                Next

            Catch ex As Exception
                FieldNameDictionary = Nothing
            Finally
                LoadDigitalResultsTemplateFieldNames = FieldNameDictionary
            End Try

        End Function
        Private Function CreateImportDigitalResultsStaging(ByVal Session As AdvantageFramework.Security.Session,
                                                           ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                           ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                           ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                           ByVal ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail),
                                                           ByVal FileLineData As Object, ByVal BatchName As String,
                                                           ByVal AutoTrimOverFlowData As Boolean, ByVal DataTable As System.Data.DataTable)

            'objects
            Dim Created As Boolean = True
            Dim ImportDigitalResultsStaging As AdvantageFramework.Database.Entities.ImportDigitalResultsStaging = Nothing
            Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing
            Dim MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim DateColumnNames As String() = Nothing
            Dim DateValue As Nullable(Of Date) = Nothing
            Dim TheDate As Date? = Nothing
            Dim InternetOrderDetail As AdvantageFramework.Database.Entities.InternetOrderDetail = Nothing
            Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing

            Try

                ImportDigitalResultsStaging = New AdvantageFramework.Database.Entities.ImportDigitalResultsStaging

                ImportDigitalResultsStaging.DbContext = DbContext
                ImportDigitalResultsStaging.BatchName = BatchName

                CreateEntityFromTemplateDataTable(ImportTemplate, DataTable, FileLineData, ImportDigitalResultsStaging, AutoTrimOverFlowData)

                DateColumnNames = {AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.ResultDate.ToString}

                For Each DateColumnName In DateColumnNames

                    DataColumn = DataTable.Columns(DateColumnName)

                    If DataColumn IsNot Nothing Then

                        Try

                            PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(ImportDigitalResultsStaging).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(PropDesc) PropDesc.Name = DateColumnName).SingleOrDefault

                        Catch ex As Exception
                            PropertyDescriptor = Nothing
                        End Try

                        If PropertyDescriptor IsNot Nothing Then

                            Try

                                If String.IsNullOrEmpty(DataColumn.ExtendedProperties("DateFormat")) Then

                                    DateValue = ScrubDate(FileLineData(DataColumn.ExtendedProperties("CSVPosition")))

                                    If DateValue Is Nothing Then

                                        PropertyDescriptor.SetValue(ImportDigitalResultsStaging, Nothing)

                                    Else

                                        Try

                                            TheDate = CDate(Format(CInt(DateValue.Value.Month), "0#") & "/" & Format(CInt(DateValue.Value.Day), "0#") & "/" & CInt(Mid(DateValue.Value.Year, 3, 2)))

                                        Catch ex As Exception

                                        End Try

                                        PropertyDescriptor.SetValue(ImportDigitalResultsStaging, TheDate)

                                    End If

                                Else

                                    DateValue = ScrubDate(FileLineData(DataColumn.ExtendedProperties("CSVPosition")), DataColumn.ExtendedProperties("DateFormat"))

                                    If DateValue Is Nothing Then

                                        PropertyDescriptor.SetValue(ImportDigitalResultsStaging, Nothing)

                                    Else

                                        PropertyDescriptor.SetValue(ImportDigitalResultsStaging, Convert.ChangeType(PropertyDescriptor.PropertyType, Format(CInt(DateValue.Value.Month), "0#") & "/" & Format(CInt(DateValue.Value.Day), "0#") & "/" & CInt(Mid(DateValue.Value.Year, 3, 2))))

                                    End If

                                End If

                            Catch ex As Exception

                            End Try

                        End If

                    End If

                Next

                'If ImportDigitalResultsStaging.MediaPlanID.HasValue Then

                '    MediaPlan = AdvantageFramework.Database.Procedures.MediaPlan.LoadByMediaPlanID(DbContext, ImportDigitalResultsStaging.MediaPlanID)

                '    If MediaPlan IsNot Nothing Then

                '        ImportDigitalResultsStaging.ClientCode = MediaPlan.ClientCode
                '        ImportDigitalResultsStaging.DivisionCode = MediaPlan.DivisionCode
                '        ImportDigitalResultsStaging.ProductCode = MediaPlan.ProductCode

                '    End If

                '    If ImportDigitalResultsStaging.MediaPlanDetailID.HasValue Then

                '        MediaPlanDetail = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanDetailID(DbContext, ImportDigitalResultsStaging.MediaPlanDetailID, False)

                '        If MediaPlanDetail IsNot Nothing Then

                '            ImportDigitalResultsStaging.MediaType = MediaPlanDetail.SalesClassType
                '            ImportDigitalResultsStaging.SalesClassCode = MediaPlanDetail.SalesClassCode
                '            ImportDigitalResultsStaging.CampaignID = MediaPlanDetail.CampaignID

                '        End If

                '    End If

                'End If

                'If String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.ClientCode) = False AndAlso String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.ClientName) Then

                '    Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, ImportDigitalResultsStaging.ClientCode)

                'ElseIf String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.ClientCode) AndAlso String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.ClientName) = False Then

                '    Try

                '        Client = (From Entity In AdvantageFramework.Database.Procedures.Client.Load(DbContext) _
                '                  Where Entity.Name = ImportDigitalResultsStaging.ClientName _
                '                  Select Entity).SingleOrDefault

                '    Catch ex As Exception
                '        Client = Nothing
                '    End Try

                'End If

                'If Client IsNot Nothing Then

                '    ImportDigitalResultsStaging.ClientCode = Client.Code
                '    ImportDigitalResultsStaging.ClientName = Client.Name

                'End If

                'If ImportDigitalResultsStaging.CampaignID.HasValue Then

                '    Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, ImportDigitalResultsStaging.CampaignID)

                'ElseIf String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.CampaignName) = False AndAlso (ImportDigitalResultsStaging.CampaignID.HasValue = False OrElse String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.CampaignCode)) Then

                '    Try

                '        Campaign = (From Entity In AdvantageFramework.Database.Procedures.Campaign.Load(DbContext) _
                '                    Where Entity.Name = ImportDigitalResultsStaging.CampaignName _
                '                    Select Entity).SingleOrDefault

                '    Catch ex As Exception

                '    End Try

                'End If

                'If Campaign IsNot Nothing Then

                '    ImportDigitalResultsStaging.CampaignCode = Campaign.Code
                '    ImportDigitalResultsStaging.CampaignID = Campaign.ID
                '    ImportDigitalResultsStaging.CampaignName = Campaign.Name

                'End If

                'If Not String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.VendorCode) AndAlso String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.VendorName) Then

                '    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, ImportDigitalResultsStaging.VendorCode)

                'ElseIf Not String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.VendorName) AndAlso String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.VendorCode) Then

                '    Try

                '        Vendor = (From Entity In AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext) _
                '                  Where Entity.Name = ImportDigitalResultsStaging.VendorName _
                '                  Select Entity).FirstOrDefault

                '    Catch ex As Exception

                '    End Try

                'End If

                'If Vendor IsNot Nothing Then

                '    ImportDigitalResultsStaging.VendorCode = Vendor.Code
                '    ImportDigitalResultsStaging.VendorName = Vendor.Name

                'End If

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                If ImportDigitalResultsStaging.MediaType IsNot Nothing AndAlso ImportDigitalResultsStaging.MediaType.Length >= 1 Then

                    ImportDigitalResultsStaging.MediaType = Mid(ImportDigitalResultsStaging.MediaType, 1, 1).ToUpper

                End If

                ImportDigitalResultsStaging.TemplateID = ImportTemplate.ID

                If ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.DigitalResults_Default AndAlso ImportTemplate.IsSystemTemplate AndAlso ImportTemplate.Name = "Advantage DoubleClick Results" AndAlso
                        ImportDigitalResultsStaging.PlacementID.HasValue Then

                    InternetOrderDetail = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.InternetOrderDetail).Include("InternetOrder")
                                           Where Entity.AdServerPlacementID = ImportDigitalResultsStaging.PlacementID.Value AndAlso
                                                 Entity.IsActiveRevision = 1
                                           Select Entity).FirstOrDefault

                    If InternetOrderDetail IsNot Nothing Then

                        ImportDigitalResultsStaging.MediaType = "I"
                        ImportDigitalResultsStaging.AdServerSource = "DoubleClick"

                        ImportDigitalResultsStaging.ClientCode = InternetOrderDetail.InternetOrder.ClientCode
                        ImportDigitalResultsStaging.DivisionCode = InternetOrderDetail.InternetOrder.DivisionCode
                        ImportDigitalResultsStaging.ProductCode = InternetOrderDetail.InternetOrder.ProductCode
                        ImportDigitalResultsStaging.SalesClassCode = InternetOrderDetail.InternetOrder.SalesClass.Code
                        ImportDigitalResultsStaging.CampaignID = InternetOrderDetail.InternetOrder.CampaignID
                        ImportDigitalResultsStaging.CampaignCode = InternetOrderDetail.InternetOrder.CampaignCode
                        ImportDigitalResultsStaging.VendorCode = InternetOrderDetail.InternetOrder.VendorCode
                        ImportDigitalResultsStaging.MarketCode = InternetOrderDetail.InternetOrder.MarketCode
                        ImportDigitalResultsStaging.AdSizeCode = InternetOrderDetail.Size
                        ImportDigitalResultsStaging.AdNumber = InternetOrderDetail.AdNumber
                        ImportDigitalResultsStaging.InternetTypeCode = InternetOrderDetail.InternetTypeCode
                        ImportDigitalResultsStaging.TargetAudience = InternetOrderDetail.TargetAudience
                        ImportDigitalResultsStaging.Placement = InternetOrderDetail.Placement1
                        ImportDigitalResultsStaging.NetGrossRate = InternetOrderDetail.InternetOrder.NetGross

                        Campaign = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Campaign)
                                    Where Entity.ID = InternetOrderDetail.InternetOrder.CampaignID
                                    Select Entity).SingleOrDefault

                        If Campaign IsNot Nothing AndAlso Campaign.ClientWebsiteID.HasValue Then

                            ImportDigitalResultsStaging.PlacementURL = AdvantageFramework.Database.Procedures.ClientWebsite.LoadByID(DbContext, Campaign.ClientWebsiteID).WebsiteAddress

                        End If

                        MediaPlanDetailLevelLineData = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)
                                                        Where Entity.OrderNumber = InternetOrderDetail.InternetOrderOrderNumber AndAlso
                                                              Entity.OrderLineNumber = InternetOrderDetail.LineNumber
                                                        Select Entity).FirstOrDefault

                        If MediaPlan IsNot Nothing Then

                            ImportDigitalResultsStaging.MediaPlanID = MediaPlanDetailLevelLineData.MediaPlanID
                            ImportDigitalResultsStaging.MediaPlanDetailLevelLineID = MediaPlanDetailLevelLineData.ID

                        End If

                    End If

                End If

                If AdvantageFramework.Database.Procedures.ImportDigitalResultsStaging.Insert(DbContext, ImportDigitalResultsStaging) = False Then

                    Created = False

                    Try

                        DbContext.DeleteEntityObject(ImportDigitalResultsStaging)

                    Catch ex As Exception

                    End Try

                End If

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            Catch ex As Exception
                Created = False
            Finally
                CreateImportDigitalResultsStaging = Created
            End Try

        End Function
        Public Function CreateDigitalResultsFromImport(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportDigitalResultsStagings As Generic.List(Of AdvantageFramework.Database.Entities.ImportDigitalResultsStaging),
                                                       ByVal ValidateBeforeImporting As Boolean) As Boolean

            'objects
            Dim Created As Boolean = True
            Dim DigitalResult As AdvantageFramework.Database.Entities.DigitalResult = Nothing
            Dim IsValid As Boolean = True

            Try

                If ImportDigitalResultsStagings IsNot Nothing AndAlso ImportDigitalResultsStagings.Count > 0 Then

                    For Each ImportDigitalResultsStaging In ImportDigitalResultsStagings

                        IsValid = True

                        If ValidateBeforeImporting Then

                            ImportDigitalResultsStaging.ValidateEntity(IsValid)

                        Else

                            IsValid = Not ImportDigitalResultsStaging.HasError()

                        End If

                        If IsValid Then

                            DigitalResult = New AdvantageFramework.Database.Entities.DigitalResult

                            DigitalResult.DbContext = DbContext

                            DigitalResult.MediaPlanID = ImportDigitalResultsStaging.MediaPlanID

                            If String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.ClientCode) = False Then

                                DigitalResult.ClientCode = ImportDigitalResultsStaging.ClientCode

                            End If

                            If String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.ClientName) = False Then

                                DigitalResult.ClientName = ImportDigitalResultsStaging.ClientName

                            End If

                            If String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.DivisionCode) = False Then

                                DigitalResult.DivisionCode = ImportDigitalResultsStaging.DivisionCode

                            End If

                            If String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.ProductCode) = False Then

                                DigitalResult.ProductCode = ImportDigitalResultsStaging.ProductCode

                            End If

                            If ImportDigitalResultsStaging.JobNumber.HasValue Then

                                DigitalResult.JobNumber = ImportDigitalResultsStaging.JobNumber

                            End If

                            If ImportDigitalResultsStaging.JobComponentNumber.HasValue Then

                                DigitalResult.JobComponentNumber = ImportDigitalResultsStaging.JobComponentNumber

                            End If

                            DigitalResult.MediaPlanDetailID = ImportDigitalResultsStaging.MediaPlanDetailID

                            If String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.MediaType) = False Then

                                DigitalResult.MediaType = ImportDigitalResultsStaging.MediaType

                            End If

                            If String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.SalesClassCode) = False Then

                                DigitalResult.SalesClassCode = ImportDigitalResultsStaging.SalesClassCode

                            End If

                            DigitalResult.CampaignID = ImportDigitalResultsStaging.CampaignID

                            If String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.CampaignCode) = False Then

                                DigitalResult.CampaignCode = ImportDigitalResultsStaging.CampaignCode

                            End If

                            If String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.CampaignName) = False Then

                                DigitalResult.CampaignName = ImportDigitalResultsStaging.CampaignName

                            End If

                            If String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.VendorCode) = False Then

                                DigitalResult.VendorCode = ImportDigitalResultsStaging.VendorCode

                            End If

                            If String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.VendorName) = False Then

                                DigitalResult.VendorName = ImportDigitalResultsStaging.VendorName

                            End If

                            If String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.MarketCode) = False Then

                                DigitalResult.MarketCode = ImportDigitalResultsStaging.MarketCode

                            End If

                            If String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.AdSizeCode) = False Then

                                DigitalResult.AdSizeCode = ImportDigitalResultsStaging.AdSizeCode

                            End If

                            If String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.AdNumber) = False Then

                                DigitalResult.AdNumber = ImportDigitalResultsStaging.AdNumber

                            End If

                            DigitalResult.AdNumberDescription = ImportDigitalResultsStaging.AdNumberDescription

                            If String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.InternetTypeCode) = False Then

                                DigitalResult.InternetTypeCode = ImportDigitalResultsStaging.InternetTypeCode

                            End If

                            DigitalResult.Placement = ImportDigitalResultsStaging.Placement
                            DigitalResult.PlacementURL = ImportDigitalResultsStaging.PlacementURL
                            DigitalResult.PlacementPixelSize = ImportDigitalResultsStaging.PlacementPixelSize
                            DigitalResult.Creative = ImportDigitalResultsStaging.Creative
                            DigitalResult.Tactic = ImportDigitalResultsStaging.Tactic
                            DigitalResult.PagePositioning = ImportDigitalResultsStaging.PagePositioning
                            DigitalResult.ResultDate = ImportDigitalResultsStaging.ResultDate
                            DigitalResult.EndDate = ImportDigitalResultsStaging.EndDate
                            DigitalResult.NetGrossRate = ImportDigitalResultsStaging.NetGrossRate
                            DigitalResult.Units = ImportDigitalResultsStaging.Units
                            DigitalResult.Impressions = ImportDigitalResultsStaging.Impressions
                            DigitalResult.ImpressionsMeasurable = ImportDigitalResultsStaging.ImpressionsMeasurable
                            DigitalResult.ImpressionsViewable = ImportDigitalResultsStaging.ImpressionsViewable
                            DigitalResult.Clicks = ImportDigitalResultsStaging.Clicks
                            DigitalResult.ClickRate = ImportDigitalResultsStaging.ClickRate
                            DigitalResult.TotalConversions = ImportDigitalResultsStaging.TotalConversions
                            DigitalResult.TotalConversionsB = ImportDigitalResultsStaging.TotalConversionsB
                            DigitalResult.TotalConversionsC = ImportDigitalResultsStaging.TotalConversionsC
                            DigitalResult.Rate = ImportDigitalResultsStaging.Rate
                            DigitalResult.NetDollars = ImportDigitalResultsStaging.NetDollars
                            DigitalResult.GrossDollars = ImportDigitalResultsStaging.GrossDollars
                            DigitalResult.TargetAudience = ImportDigitalResultsStaging.TargetAudience
                            DigitalResult.Leads1 = ImportDigitalResultsStaging.Leads1
                            DigitalResult.Leads2 = ImportDigitalResultsStaging.Leads2
                            DigitalResult.Calls = ImportDigitalResultsStaging.Calls
                            DigitalResult.LikesOrganic = ImportDigitalResultsStaging.LikesOrganic
                            DigitalResult.LikesPaid = ImportDigitalResultsStaging.LikesPaid
                            DigitalResult.Visits = ImportDigitalResultsStaging.Visits
                            DigitalResult.UniqueVisitors = ImportDigitalResultsStaging.UniqueVisitors
                            DigitalResult.ReachOrganic = ImportDigitalResultsStaging.ReachOrganic
                            DigitalResult.ReachPaid = ImportDigitalResultsStaging.ReachPaid
                            DigitalResult.PageViews = ImportDigitalResultsStaging.PageViews
                            DigitalResult.PageEngagement = ImportDigitalResultsStaging.PageEngagement

                            If String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.Note) = False Then

                                DigitalResult.Note = ImportDigitalResultsStaging.Note

                            End If

                            DigitalResult.ClientSales = ImportDigitalResultsStaging.ClientSales
                            DigitalResult.PlacementID = ImportDigitalResultsStaging.PlacementID
                            DigitalResult.AdServerSource = ImportDigitalResultsStaging.AdServerSource
                            DigitalResult.DaypartCode = ImportDigitalResultsStaging.DaypartCode

                            If AdvantageFramework.Database.Procedures.DigitalResult.Insert(DbContext, DigitalResult) Then

                                AdvantageFramework.Database.Procedures.ImportDigitalResultsStaging.Delete(DbContext, ImportDigitalResultsStaging.ID)

                            End If

                        Else

                            Created = False

                        End If

                    Next

                Else

                    Created = False

                End If

            Catch ex As Exception
                Created = False
            Finally
                CreateDigitalResultsFromImport = Created
            End Try

        End Function
        Private Sub AutoResolveDigitalResultsData(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BatchName As String)

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_imp_digital_results_auto_resolve_data] '{0}'", BatchName))

            Catch ex As Exception

            End Try

        End Sub

#End Region

#Region "   Avalara Tax "

        Public Function CreateAvalaraTaxFromImport(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ImportAvalaraTaxStagings As Generic.List(Of AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging)) As Boolean

            'objects
            Dim Created As Boolean = True
            Dim AvalaraTax As AdvantageFramework.Database.Entities.AvalaraTax = Nothing
            Dim IsValid As Boolean = True

            Try

                Using DbContext As New AdvantageFramework.Database.DbContext(DataContext.Connection.ConnectionString, DataContext.UserCode)

                    For Each ImportAvalaraTaxStaging In ImportAvalaraTaxStagings

                        IsValid = True

                        ImportAvalaraTaxStaging.DataContext = DataContext

                        If ImportAvalaraTaxStaging.IsOnHold = False Then

                            ImportAvalaraTaxStaging.ValidateEntity(IsValid)

                            If IsValid Then

                                If ImportAvalaraTaxStaging.IsNew Then

                                    AvalaraTax = New AdvantageFramework.Database.Entities.AvalaraTax
                                    AvalaraTax.DataContext = DataContext

                                    AvalaraTax.Code = ImportAvalaraTaxStaging.Code
                                    AvalaraTax.Description = ImportAvalaraTaxStaging.Description
                                    AvalaraTax.LongDescription = ImportAvalaraTaxStaging.LongDescription
                                    AvalaraTax.IsInactive = ImportAvalaraTaxStaging.IsInactive

                                    FillAvalaraTaxEntityFromImportAvalaraTaxStagingEntity(AvalaraTax, ImportAvalaraTaxStaging)

                                    If AdvantageFramework.Database.Procedures.AvalaraTax.Insert(DataContext, AvalaraTax) Then

                                        DbContext.Database.ExecuteSqlCommand(String.Format("delete dbo.IMP_AVALARA_TAX_STAGING WHERE IMPORT_ID={0}", ImportAvalaraTaxStaging.ImportID))

                                    Else

                                        Created = False

                                    End If

                                Else

                                    AvalaraTax = AdvantageFramework.Database.Procedures.AvalaraTax.LoadByCode(DataContext, ImportAvalaraTaxStaging.Code)

                                    If AvalaraTax IsNot Nothing Then

                                        ImportAvalaraTaxStaging.Code = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(AvalaraTax.Code, ImportAvalaraTaxStaging.Code)
                                        ImportAvalaraTaxStaging.Description = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(AvalaraTax.Description, ImportAvalaraTaxStaging.Description)
                                        ImportAvalaraTaxStaging.LongDescription = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(AvalaraTax.LongDescription, ImportAvalaraTaxStaging.LongDescription)
                                        ImportAvalaraTaxStaging.IsInactive = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(AvalaraTax.IsInactive, ImportAvalaraTaxStaging.IsInactive)

                                        FillAvalaraTaxEntityFromImportAvalaraTaxStagingEntity(AvalaraTax, ImportAvalaraTaxStaging)

                                        If AdvantageFramework.Database.Procedures.AvalaraTax.Update(DataContext, AvalaraTax) Then

                                            DbContext.Database.ExecuteSqlCommand(String.Format("delete dbo.IMP_AVALARA_TAX_STAGING WHERE IMPORT_ID={0}", ImportAvalaraTaxStaging.ImportID))

                                        Else

                                            Created = False

                                        End If

                                    End If

                                End If

                            Else

                                Created = False

                            End If

                        End If

                    Next

                End Using

            Catch ex As Exception
                Created = False
            End Try

            CreateAvalaraTaxFromImport = Created

        End Function
        Private Function CreateImportAvalaraTaxStaging(ByVal Session As AdvantageFramework.Security.Session, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                       ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                       ByVal ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail),
                                                       ByVal FileLineData As Object, ByVal BatchName As String,
                                                       ByVal AutoTrimOverFlowData As Boolean, ByVal DataTable As System.Data.DataTable)

            'objects
            Dim Created As Boolean = True
            Dim ImportAvalaraTaxStaging As AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging = Nothing
            Dim AvalaraTax As AdvantageFramework.Database.Entities.AvalaraTax = Nothing

            Try

                ImportAvalaraTaxStaging = New AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging

                ImportAvalaraTaxStaging.DataContext = DataContext
                ImportAvalaraTaxStaging.BatchName = BatchName

                CreateEntityFromTemplateDataTable(ImportTemplate, DataTable, FileLineData, ImportAvalaraTaxStaging, AutoTrimOverFlowData)

                Try

                    AvalaraTax = AdvantageFramework.Database.Procedures.AvalaraTax.Load(DataContext).Where(Function(Entity) Entity.Code.ToUpper = ImportAvalaraTaxStaging.Code.ToUpper).SingleOrDefault

                Catch ex As Exception
                    AvalaraTax = Nothing
                End Try

                If AvalaraTax IsNot Nothing Then

                    ImportAvalaraTaxStaging.IsNew = False

                    ImportAvalaraTaxStaging.Code = AvalaraTax.Code

                    ImportAvalaraTaxStaging.IsInactive = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging.Properties.IsInactive.ToString, FileLineData, AvalaraTax.IsInactive)

                Else

                    ImportAvalaraTaxStaging.IsNew = True
                    ImportAvalaraTaxStaging.IsInactive = False

                End If

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                If AdvantageFramework.Database.Procedures.ImportAvalaraTaxStaging.Insert(DataContext, ImportAvalaraTaxStaging) = False Then

                    Created = False

                    Try

                        DataContext.ImportAvalaraTaxStagings.DeleteOnSubmit(ImportAvalaraTaxStaging)

                    Catch ex As Exception

                    End Try

                End If

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            Catch ex As Exception
                Created = False
            Finally
                CreateImportAvalaraTaxStaging = Created
            End Try

        End Function
        Private Sub FillAvalaraTaxEntityFromImportAvalaraTaxStagingEntity(ByRef AvalaraTax As AdvantageFramework.Database.Entities.AvalaraTax, ByVal ImportAvalaraTaxStaging As AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging)

            AvalaraTax.Code = ImportAvalaraTaxStaging.Code
            AvalaraTax.Description = ImportAvalaraTaxStaging.Description
            AvalaraTax.LongDescription = ImportAvalaraTaxStaging.LongDescription
            AvalaraTax.IsInactive = ImportAvalaraTaxStaging.IsInactive

        End Sub

#End Region

#Region "   Cash Receipt "

#Region "     Custom Fixed "

        Private Sub InsertImportCashReceiptDetails(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ImportCashReceiptDetailList As Generic.List(Of AdvantageFramework.Database.Entities.ImportCashReceiptDetail))

            If ImportCashReceiptDetailList IsNot Nothing Then

                For Each ImportCashReceiptDetail In ImportCashReceiptDetailList

                    If AdvantageFramework.Database.Procedures.ImportCashReceiptDetail.Insert(DataContext, ImportCashReceiptDetail) = False Then

                        Throw New Exception("Failed to insert into import cash receipt detail table.")

                    End If

                Next

            End If

        End Sub
        Private Function RemoveAllNonNumericExceptDash(ByVal SourceText As String, Optional ByVal DefaultReturn As String = "") As String

            Try

                If String.IsNullOrEmpty(SourceText) = False Then

                    RemoveAllNonNumericExceptDash = System.Text.RegularExpressions.Regex.Replace(SourceText, "[^0-9/-]", "")

                Else

                    RemoveAllNonNumericExceptDash = DefaultReturn

                End If

            Catch ex As Exception
                RemoveAllNonNumericExceptDash = DefaultReturn
            End Try

        End Function
        Private Function CreateImportCashReceiptDetail(ByVal FileLine As String) As AdvantageFramework.Database.Entities.ImportCashReceiptDetail

            Dim ImportCashReceiptDetail As AdvantageFramework.Database.Entities.ImportCashReceiptDetail = Nothing
            Dim InvoiceNumber As String = Nothing
            Dim InvSeq() As String = Nothing

            ImportCashReceiptDetail = New AdvantageFramework.Database.Entities.ImportCashReceiptDetail

            InvoiceNumber = RemoveAllNonNumericExceptDash(FileLine.Substring(11, 15))

            If IsNumeric(InvoiceNumber) Then

                ImportCashReceiptDetail.ARInvoiceNumber = Math.Abs(CLng(InvoiceNumber))
                ImportCashReceiptDetail.ARInvoiceSequence = 0

            Else

                InvSeq = InvoiceNumber.Split("-")

                If InvSeq.Length = 2 Then

                    If IsNumeric(InvSeq(0)) Then

                        ImportCashReceiptDetail.ARInvoiceNumber = InvSeq(0)

                    End If

                    If IsNumeric(InvSeq(1)) Then

                        ImportCashReceiptDetail.ARInvoiceSequence = InvSeq(1)

                    End If

                End If

            End If

            'ImportCashReceiptDetail.ARInvoiceNumber = CLng(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(FileLine.Substring(11, 15)))
            ImportCashReceiptDetail.PaymentAmount = CDec(FileLine.Substring(26, 10)) / 100

            CreateImportCashReceiptDetail = ImportCashReceiptDetail

        End Function
        Private Function CreateImportCashReceiptStagingFromLockboxFile(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                                       ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                                       ByVal FileLines() As String,
                                                                       ByVal BatchName As String) As Boolean

            'objects
            Dim FileLineCounter As Integer = 0
            Dim Created As Boolean = True
            Dim ImportCashReceipt As AdvantageFramework.Database.Entities.ImportCashReceipt = Nothing
            Dim ImportCashReceiptDetail As AdvantageFramework.Database.Entities.ImportCashReceiptDetail = Nothing
            Dim ImportCashReceiptDetailList As Generic.List(Of AdvantageFramework.Database.Entities.ImportCashReceiptDetail) = Nothing
            Dim SqlParameterDepositDate As SqlClient.SqlParameter = Nothing
            Dim SqlParameterBatchName As SqlClient.SqlParameter = Nothing

            Try

                RaiseEvent SetupImportingProgressEvent(0, FileLines.Count, 0)

                For Each FileLine In FileLines

                    If FileLine.StartsWith("6") Then

                        InsertImportCashReceiptDetails(DataContext, ImportCashReceiptDetailList)
                        ImportCashReceiptDetailList = Nothing

                        ImportCashReceipt = New AdvantageFramework.Database.Entities.ImportCashReceipt
                        ImportCashReceipt.CheckAmount = CDec(FileLine.Substring(7, 10)) / 100
                        ImportCashReceipt.CheckNumber = FileLine.Substring(17, 10).Trim
                        ImportCashReceipt.CheckDate = DateSerial(CInt(FileLine.Substring(31, 2)), CInt(FileLine.Substring(27, 2)), CInt(FileLine.Substring(29, 2)))

                        ImportCashReceipt.DataContext = DataContext
                        ImportCashReceipt.BatchName = BatchName
                        ImportCashReceipt.IsOnHold = 0
                        ImportCashReceipt.ImportTemplateID = ImportTemplate.ID

                        If AdvantageFramework.Database.Procedures.ImportCashReceipt.Insert(DataContext, ImportCashReceipt) = False Then

                            Throw New Exception("Failed to insert into import cash receipt table.")

                        End If

                    ElseIf FileLine.StartsWith("4") Then

                        If ImportCashReceiptDetailList Is Nothing Then

                            ImportCashReceiptDetailList = New Generic.List(Of AdvantageFramework.Database.Entities.ImportCashReceiptDetail)

                        End If

                        ImportCashReceiptDetail = CreateImportCashReceiptDetail(FileLine)
                        ImportCashReceiptDetail.ImportCashReceiptID = ImportCashReceipt.ID
                        ImportCashReceiptDetail.DataContext = DataContext

                        ImportCashReceiptDetailList.Add(ImportCashReceiptDetail)

                    ElseIf FileLine.StartsWith("8") Then

                        InsertImportCashReceiptDetails(DataContext, ImportCashReceiptDetailList)
                        ImportCashReceiptDetailList = Nothing

                        SqlParameterDepositDate = New SqlClient.SqlParameter("@depositdate", DateSerial(CInt(FileLine.Substring(14, 2)), CInt(FileLine.Substring(16, 2)), CInt(FileLine.Substring(18, 2))))
                        SqlParameterBatchName = New SqlClient.SqlParameter("@batchname", BatchName)

                        DbContext.Database.ExecuteSqlCommand("UPDATE dbo.IMP_CR_HEADER SET DEPOSIT_DATE = @depositdate WHERE BATCH_NAME = @batchname", SqlParameterDepositDate, SqlParameterBatchName)

                    End If

                    FileLineCounter += 1

                    'Math.DivRem(FileLineCounter, 100, Remainder)

                    'If Remainder = 0 Then

                    RaiseEvent ImportingProgressUpdateEvent(FileLineCounter)

                    'End If

                Next

            Catch ex As Exception
                Created = False
            Finally
                CreateImportCashReceiptStagingFromLockboxFile = Created
            End Try

        End Function

#End Region

#Region "     Generic "

        Private Function CreateImportCashReceiptStaging(ByVal Session As AdvantageFramework.Security.Session, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                        ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                        ByVal ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail),
                                                        ByVal FileLineData As Object, ByVal BatchName As String, ByVal AutoTrimOverFlowData As Boolean,
                                                        ByVal ImportCashReceipts As Hashtable,
                                                        ByVal DataTable As System.Data.DataTable,
                                                        ByVal DataTableCRDetail As System.Data.DataTable) As Boolean

            'objects
            Dim Created As Boolean = True
            Dim ImportCashReceipt As AdvantageFramework.Database.Entities.ImportCashReceipt = Nothing
            Dim ImportCashReceiptDetail As AdvantageFramework.Database.Entities.ImportCashReceiptDetail = Nothing
            Dim ImportCashReceiptLookup As AdvantageFramework.Database.Entities.ImportCashReceipt = Nothing
            Dim InvoiceNumber As String = Nothing
            Dim InvSeq() As String = Nothing
            Dim AccountReceivable As AdvantageFramework.Database.Entities.AccountReceivable = Nothing

            Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                ImportCashReceipt = New AdvantageFramework.Database.Entities.ImportCashReceipt
                ImportCashReceiptDetail = New AdvantageFramework.Database.Entities.ImportCashReceiptDetail

                ImportCashReceipt.DataContext = DataContext
                ImportCashReceipt.BatchName = BatchName

                ImportCashReceiptDetail.DataContext = DataContext

                CreateEntityFromTemplateDataTable(ImportTemplate, DataTable, FileLineData, ImportCashReceipt, AutoTrimOverFlowData)
                CreateEntityFromTemplateDataTable(ImportTemplate, DataTableCRDetail, FileLineData, ImportCashReceiptDetail, AutoTrimOverFlowData)

                If DataTableCRDetail.Columns("ARInvoiceNumber") IsNot Nothing AndAlso DataTableCRDetail.Columns("ARInvoiceNumber").ExtendedProperties("CSVPosition") IsNot Nothing AndAlso
                        FileLineData(DataTableCRDetail.Columns("ARInvoiceNumber").ExtendedProperties("CSVPosition")) <> "" Then

                    Try

                        InvoiceNumber = RemoveAllNonNumericExceptDash(FileLineData(DataTableCRDetail.Columns("ARInvoiceNumber").ExtendedProperties("CSVPosition")))

                    Catch ex As Exception
                        InvoiceNumber = Nothing
                    End Try

                    If IsNumeric(InvoiceNumber) Then

                        ImportCashReceiptDetail.ARInvoiceNumber = Math.Abs(CLng(InvoiceNumber))
                        ImportCashReceiptDetail.ARInvoiceSequence = 0

                    Else

                        InvSeq = InvoiceNumber.Split("-")

                        If InvSeq.Length = 2 Then

                            If IsNumeric(InvSeq(0)) Then

                                ImportCashReceiptDetail.ARInvoiceNumber = InvSeq(0)

                            End If

                            If IsNumeric(InvSeq(1)) Then

                                ImportCashReceiptDetail.ARInvoiceSequence = InvSeq(1)

                            End If

                        End If

                    End If

                ElseIf Not String.IsNullOrWhiteSpace(ImportCashReceiptDetail.AltInvoiceNumber) Then

                    Try

                        AccountReceivable = DbContext.AccountReceivables.Where(Function(AR) (AR.IsVoided Is Nothing OrElse AR.IsVoided = 0) AndAlso AR.Description = ImportCashReceiptDetail.AltInvoiceNumber).SingleOrDefault

                    Catch ex As Exception
                        AccountReceivable = Nothing
                    End Try

                    If AccountReceivable IsNot Nothing Then

                        ImportCashReceiptDetail.ARInvoiceNumber = AccountReceivable.InvoiceNumber
                        ImportCashReceiptDetail.ARInvoiceSequence = AccountReceivable.SequenceNumber

                    End If

                End If

                Try

                    ImportCashReceiptLookup = ImportCashReceipts(ImportCashReceipt.CheckNumber & "|" & ImportCashReceipt.CheckAmount)

                Catch ex As Exception
                    ImportCashReceiptLookup = Nothing
                End Try

                If ImportCashReceiptLookup Is Nothing Then

                    ImportCashReceipt.ImportTemplateID = ImportTemplate.ID

                    If AdvantageFramework.Database.Procedures.ImportCashReceipt.Insert(DataContext, ImportCashReceipt) = False Then

                        Created = False

                        Try

                            DataContext.ImportCashReceipts.DeleteOnSubmit(ImportCashReceipt)

                        Catch ex As Exception

                        End Try

                    Else

                        ImportCashReceipts.Add(ImportCashReceipt.CheckNumber & "|" & ImportCashReceipt.CheckAmount, ImportCashReceipt)

                    End If

                Else

                    ImportCashReceipt = ImportCashReceiptLookup

                End If

                If Created Then

                    ImportCashReceiptDetail.ImportCashReceiptID = ImportCashReceipt.ID

                    If AdvantageFramework.Database.Procedures.ImportCashReceiptDetail.Insert(DataContext, ImportCashReceiptDetail) = False Then

                        Created = False

                        Try

                            DataContext.ImportCashReceiptDetails.DeleteOnSubmit(ImportCashReceiptDetail)

                        Catch ex As Exception

                        End Try

                    End If

                End If

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            Catch ex As Exception
                Created = False
            Finally
                CreateImportCashReceiptStaging = Created
            End Try

        End Function

#End Region

#End Region

#Region "   Client Contact "

        Private Function CreateImportClientContactStaging(ByVal Session As AdvantageFramework.Security.Session,
                                                          ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                          ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                          ByVal ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail),
                                                          ByVal FileLineData As Object, ByVal BatchName As String,
                                                          ByVal AutoTrimOverFlowData As Boolean, ByVal DataTable As System.Data.DataTable)

            'objects
            Dim Created As Boolean = True
            Dim ImportClientContactStaging As AdvantageFramework.Database.Entities.ImportClientContactStaging = Nothing
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing

            Try

                ImportClientContactStaging = New AdvantageFramework.Database.Entities.ImportClientContactStaging

                ImportClientContactStaging.DbContext = DbContext
                ImportClientContactStaging.BatchName = BatchName

                CreateEntityFromTemplateDataTable(ImportTemplate, DataTable, FileLineData, ImportClientContactStaging, AutoTrimOverFlowData)

                Try

                    ClientContact = AdvantageFramework.Database.Procedures.ClientContact.Load(DbContext).Where(Function(Entity) Entity.ContactCode.ToUpper = ImportClientContactStaging.ContactCode.ToUpper AndAlso Entity.ClientCode.ToUpper = ImportClientContactStaging.ClientCode.ToUpper).SingleOrDefault

                Catch ex As Exception
                    ClientContact = Nothing
                End Try

                If ClientContact IsNot Nothing Then

                    ImportClientContactStaging.IsNew = False

                    ImportClientContactStaging.ContactCode = ClientContact.ContactCode
                    ImportClientContactStaging.ClientCode = ClientContact.ClientCode

                    'ImportClientContactStaging.FiscalStart = ScrubAsteriskNonStringColumn(DataTable, AdvantageFramework.Database.Entities.ImportClientContactStaging.Properties.FiscalStart.ToString, FileLineData, Client.FiscalStart)

                Else

                    ImportClientContactStaging.IsNew = True

                End If

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                If AdvantageFramework.Database.Procedures.ImportClientContactStaging.Insert(DbContext, ImportClientContactStaging, "") = False Then

                    Created = False

                    Try

                        DbContext.ImportClientContactStagings.Remove(ImportClientContactStaging)

                    Catch ex As Exception

                    End Try

                End If

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            Catch ex As Exception
                Created = False
            Finally
                CreateImportClientContactStaging = Created
            End Try

        End Function
        Public Function CreateClientContactsFromImport(DbContext As AdvantageFramework.Database.DbContext,
                                                       ImportClientContactStagings As Generic.List(Of AdvantageFramework.Database.Entities.ImportClientContactStaging),
                                                       ValidateBeforeImporting As Boolean) As Boolean

            'objects
            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim Created As Boolean = True
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
            Dim IsValid As Boolean = True

            Try

                PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.ClientContact)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                For Each ImportClientContactStaging In ImportClientContactStagings

                    IsValid = True

                    ImportClientContactStaging.DbContext = DbContext

                    If ImportClientContactStaging.IsOnHold = False Then

                        If ValidateBeforeImporting Then

                            ImportClientContactStaging.ValidateEntity(IsValid)

                        Else

                            IsValid = Not ImportClientContactStaging.HasError()

                        End If

                        If IsValid Then

                            If ImportClientContactStaging.IsNew Then

                                ClientContact = New AdvantageFramework.Database.Entities.ClientContact
                                ClientContact.DbContext = DbContext

                                ClientContact.ClientCode = ImportClientContactStaging.ClientCode
                                ClientContact.ContactCode = ImportClientContactStaging.ContactCode

                                FillClientContactEntityFromImportClientContactStagingEntity(ClientContact, ImportClientContactStaging)

                                SetEmptyStringsToNull(PropertyDescriptorsList, ClientContact)

                                If AdvantageFramework.Database.Procedures.ClientContact.Insert(DbContext, ClientContact) Then

                                    AdvantageFramework.Database.Procedures.ImportClientContactStaging.Delete(DbContext, ImportClientContactStaging, "")

                                Else

                                    DbContext.DeleteEntityObject(ClientContact)

                                    Created = False

                                End If

                            Else

                                ClientContact = AdvantageFramework.Database.Procedures.ClientContact.LoadByClientAndContactCode(DbContext, ImportClientContactStaging.ClientCode, ImportClientContactStaging.ContactCode)

                                If ClientContact IsNot Nothing Then

                                    ImportClientContactStaging.EmailAddress = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.EmailAddress, ImportClientContactStaging.EmailAddress)
                                    ImportClientContactStaging.FirstName = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.FirstName, ImportClientContactStaging.FirstName)
                                    ImportClientContactStaging.LastName = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.LastName, ImportClientContactStaging.LastName)
                                    ImportClientContactStaging.MiddleInitial = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.MiddleInitial, ImportClientContactStaging.MiddleInitial)
                                    ImportClientContactStaging.Title = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.Title, ImportClientContactStaging.Title)
                                    ImportClientContactStaging.ContactTypeID = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.ContactTypeID, ImportClientContactStaging.ContactTypeID)
                                    ImportClientContactStaging.Address = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.Address, ImportClientContactStaging.Address)
                                    ImportClientContactStaging.Address2 = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.Address2, ImportClientContactStaging.Address2)
                                    ImportClientContactStaging.City = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.City, ImportClientContactStaging.City)
                                    ImportClientContactStaging.County = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.County, ImportClientContactStaging.County)
                                    ImportClientContactStaging.State = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.State, ImportClientContactStaging.State)
                                    ImportClientContactStaging.Country = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.Country, ImportClientContactStaging.Country)
                                    ImportClientContactStaging.Zip = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.Zip, ImportClientContactStaging.Zip)
                                    ImportClientContactStaging.Telephone = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.Telephone, ImportClientContactStaging.Telephone)
                                    ImportClientContactStaging.TelephoneExtension = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.TelephoneExtension, ImportClientContactStaging.TelephoneExtension)
                                    ImportClientContactStaging.Fax = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.Fax, ImportClientContactStaging.Fax)
                                    ImportClientContactStaging.FaxExtension = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.FaxExtension, ImportClientContactStaging.FaxExtension)
                                    ImportClientContactStaging.ScheduleUser = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.ScheduleUser, ImportClientContactStaging.ScheduleUser)
                                    ImportClientContactStaging.ClientPortalUser = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.IsClientPortalUser, ImportClientContactStaging.ClientPortalUser)
                                    ImportClientContactStaging.GetAlerts = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.GetAlerts, ImportClientContactStaging.GetAlerts)
                                    ImportClientContactStaging.GetEmails = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.GetEmails, ImportClientContactStaging.GetEmails)
                                    ImportClientContactStaging.IsInactive = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.IsInactive, ImportClientContactStaging.IsInactive)
                                    ImportClientContactStaging.CellPhone = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.CellPhone, ImportClientContactStaging.CellPhone)
                                    ImportClientContactStaging.Comments = AdvantageFramework.Importing.LoadImportedMaintenanceDataToUpdate(ClientContact.Comments, ImportClientContactStaging.Comments)

                                    FillClientContactEntityFromImportClientContactStagingEntity(ClientContact, ImportClientContactStaging)

                                    If AdvantageFramework.Database.Procedures.ClientContact.Update(DbContext, ClientContact) Then

                                        AdvantageFramework.Database.Procedures.ImportClientContactStaging.Delete(DbContext, ImportClientContactStaging, "")

                                    Else

                                        Created = False

                                    End If

                                End If

                            End If

                        Else

                            Created = False

                        End If

                    End If

                Next

            Catch ex As Exception
                Created = False
            End Try

            CreateClientContactsFromImport = Created

        End Function
        Private Sub FillClientContactEntityFromImportClientContactStagingEntity(ByRef ClientContact As AdvantageFramework.Database.Entities.ClientContact, ByVal ImportClientContactStaging As AdvantageFramework.Database.Entities.ImportClientContactStaging)

            ClientContact.EmailAddress = ImportClientContactStaging.EmailAddress
            ClientContact.FirstName = ImportClientContactStaging.FirstName
            ClientContact.LastName = ImportClientContactStaging.LastName
            ClientContact.MiddleInitial = ImportClientContactStaging.MiddleInitial
            ClientContact.Title = ImportClientContactStaging.Title
            ClientContact.ContactTypeID = ImportClientContactStaging.ContactTypeID
            ClientContact.Address = ImportClientContactStaging.Address
            ClientContact.Address2 = ImportClientContactStaging.Address2
            ClientContact.City = ImportClientContactStaging.City
            ClientContact.County = ImportClientContactStaging.County
            ClientContact.State = ImportClientContactStaging.State
            ClientContact.Country = ImportClientContactStaging.Country
            ClientContact.Zip = ImportClientContactStaging.Zip
            ClientContact.Telephone = ImportClientContactStaging.Telephone
            ClientContact.TelephoneExtension = ImportClientContactStaging.TelephoneExtension
            ClientContact.Fax = ImportClientContactStaging.Fax
            ClientContact.FaxExtension = ImportClientContactStaging.FaxExtension
            ClientContact.ScheduleUser = ImportClientContactStaging.ScheduleUser
            ClientContact.IsClientPortalUser = ImportClientContactStaging.ClientPortalUser
            ClientContact.GetAlerts = ImportClientContactStaging.GetAlerts
            ClientContact.GetEmails = ImportClientContactStaging.GetEmails
            ClientContact.IsInactive = ImportClientContactStaging.IsInactive
            ClientContact.CellPhone = ImportClientContactStaging.CellPhone
            ClientContact.Comments = ImportClientContactStaging.Comments

        End Sub

#End Region

#Region "   PTO "

        Private Function CreateImportPTOStaging(Session As AdvantageFramework.Security.Session,
                                                DbContext As AdvantageFramework.Database.DbContext,
                                                DataContext As AdvantageFramework.Database.DataContext,
                                                ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail),
                                                FileLineData As Object, BatchName As String,
                                                AutoTrimOverFlowData As Boolean, DataTable As System.Data.DataTable,
                                                FileType As AdvantageFramework.Importing.FileTypes,
                                                ImportTemplateExcludeList As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateExclude),
                                                PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor))

            'objects
            Dim Created As Boolean = True
            Dim ImportPTOStaging As AdvantageFramework.Database.Entities.ImportPTOStaging = Nothing
            Dim Duration As String = Nothing
            Dim FirstSpace As Integer = 0

            Try

                ImportPTOStaging = New AdvantageFramework.Database.Entities.ImportPTOStaging

                ImportPTOStaging.DbContext = DbContext
                ImportPTOStaging.BatchName = BatchName

                CreateEntityFromTemplateDataTable(ImportTemplate, DataTable, FileLineData, ImportPTOStaging, AutoTrimOverFlowData)

                If DataTable.Columns.Item(AdvantageFramework.Database.Entities.ImportPTOStaging.Properties.Duration.ToString).ExtendedProperties("CSVPosition") <= UBound(FileLineData) AndAlso
                        FileLineData(DataTable.Columns.Item(AdvantageFramework.Database.Entities.ImportPTOStaging.Properties.Duration.ToString).ExtendedProperties("CSVPosition")) IsNot Nothing Then

                    Duration = FileLineData(DataTable.Columns.Item(AdvantageFramework.Database.Entities.ImportPTOStaging.Properties.Duration.ToString).ExtendedProperties("CSVPosition"))

                    FirstSpace = InStr(Duration, " ")

                    If FirstSpace <> 0 Then

                        ImportPTOStaging.Duration = ScrubDecimal(Left(Duration, FirstSpace), True, 5, 2, FileType)

                    End If

                End If

                If ImportPTOStaging.ActivityDate.HasValue AndAlso
                        DataTable.Columns.Item(AdvantageFramework.Database.Entities.ImportPTOStaging.Properties.ActivityStart.ToString).ExtendedProperties("CSVPosition") <= UBound(FileLineData) AndAlso
                        FileLineData(DataTable.Columns.Item(AdvantageFramework.Database.Entities.ImportPTOStaging.Properties.ActivityStart.ToString).ExtendedProperties("CSVPosition")) IsNot Nothing Then

                    Try

                        ImportPTOStaging.ActivityStart = ImportPTOStaging.ActivityDate.Value.ToShortDateString & " " & Mid(FileLineData(DataTable.Columns.Item(AdvantageFramework.Database.Entities.ImportPTOStaging.Properties.ActivityStart.ToString).ExtendedProperties("CSVPosition")), 1, 8)

                    Catch ex As Exception

                    End Try

                Else

                    ImportPTOStaging.ActivityStart = Nothing

                End If

                If Not RowHasExcludeValues(ImportTemplateExcludeList, PropertyDescriptorsList, ImportPTOStaging) Then

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    If AdvantageFramework.Database.Procedures.ImportPTOStaging.Insert(DataContext, ImportPTOStaging, True) = False Then

                        Created = False

                        Try

                            DataContext.ImportPTOStagings.DeleteOnSubmit(ImportPTOStaging)

                        Catch ex As Exception

                        End Try

                    End If

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            Catch ex As Exception
                Created = False
            Finally
                CreateImportPTOStaging = Created
            End Try

        End Function
        Public Function CreatePTORecordsFromImport(DataContext As AdvantageFramework.Database.DataContext,
                                                   DbContext As AdvantageFramework.Database.DbContext,
                                                   ImportPTOItems As Generic.List(Of AdvantageFramework.Importing.Classes.ImportPTOItem)) As Boolean

            'objects
            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim Created As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorMessage As String = Nothing
            Dim SaveEmployeeTimeReponse As AdvantageFramework.EmployeeTimesheet.Classes.SaveEmployeeTimeReponse = Nothing
            Dim EmployeeTime As AdvantageFramework.Database.Entities.EmployeeTime = Nothing
            Dim EmployeeTimeIndirect As AdvantageFramework.Database.Entities.EmployeeTimeIndirect = Nothing
            Dim EmployeeTimeID As Integer = 0
            Dim EmployeeTimeDetailID As Integer = 0
            Dim ShortDate As Date = Nothing
            Dim EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing
            Dim Minutes As Integer = Nothing
            Dim EmployeeCodes As IEnumerable(Of String) = Nothing
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim IndirectCategory As AdvantageFramework.Database.Entities.IndirectCategory = Nothing

            Try

                PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.ClientContact)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                EmployeeCodes = (From Entity In ImportPTOItems
                                 Select Entity.EmployeeCode).Distinct.ToArray

                Employees = AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).Where(Function(Entity) EmployeeCodes.Contains(Entity.Code)).ToList

                For Each ImportPTOItem In ImportPTOItems

                    IsValid = True

                    ImportPTOItem.DataContext = DataContext
                    ImportPTOItem.DbContext = DbContext

                    If ImportPTOItem.IsOnHold = False Then

                        ImportPTOItem.ValidateEntity(IsValid)

                        If IsValid Then

                            EmployeeTimeID = 0
                            EmployeeTimeDetailID = 0

                            ShortDate = ImportPTOItem.ActivityStart.Value.ToShortDateString

                            EmployeeTime = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTime.Load(DbContext)
                                            Where Entity.EmployeeCode = ImportPTOItem.EmployeeCode AndAlso
                                                  Entity.Date = ShortDate
                                            Select Entity).SingleOrDefault

                            If EmployeeTime IsNot Nothing Then

                                EmployeeTimeIndirect = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeIndirect.LoadByID(DbContext, EmployeeTime.ID)
                                                        Where Entity.Category = ImportPTOItem.Category
                                                        Select Entity).SingleOrDefault

                            End If

                            If ImportPTOItem.Status = 1 Then

                                If EmployeeTime IsNot Nothing Then

                                    EmployeeTimeID = EmployeeTime.ID

                                    If EmployeeTimeIndirect IsNot Nothing Then

                                        EmployeeTimeDetailID = EmployeeTimeIndirect.EmployeeTimeDetailID

                                    End If

                                End If

                                'If EmployeeTimeDetailID = 0 Then 'The Webvantage save function needs both of these or neither

                                '    EmployeeTimeID = 0

                                'End If

                                SaveEmployeeTimeReponse = AdvantageFramework.EmployeeTimesheet.SaveEmployeeNonProductionTime(DbContext.ConnectionString, DbContext.UserCode, EmployeeTimeID, EmployeeTimeDetailID, ImportPTOItem.EmployeeCode, ImportPTOItem.ActivityStart.Value.ToShortDateString, ImportPTOItem.Category, ImportPTOItem.Duration, Nothing, ImportPTOItem.Description, ErrorMessage)

                                If SaveEmployeeTimeReponse.SaveSuccessful = 1 Then

                                    EmployeeNonTask = New AdvantageFramework.Database.Entities.EmployeeNonTask
                                    EmployeeNonTask.DbContext = DbContext

                                    Minutes = CInt(Math.Floor(ImportPTOItem.Duration.Value)) * 60 + (ImportPTOItem.Duration.Value - CInt(Math.Floor(ImportPTOItem.Duration.Value))) * 60

                                    Employee = Employees.Where(Function(Entity) Entity.Code = ImportPTOItem.EmployeeCode).FirstOrDefault

                                    If Employee IsNot Nothing AndAlso ImportPTOItem.ActivityStart.HasValue Then

                                        If ImportPTOItem.ActivityStart.Value.DayOfWeek = DayOfWeek.Monday AndAlso Employee.MondayHours.HasValue AndAlso Employee.MondayStartTime.HasValue AndAlso ImportPTOItem.Duration.Value = Employee.MondayHours.Value Then

                                            EmployeeNonTask.StartDateAndTime = Employee.MondayStartTime.Value
                                            EmployeeNonTask.EndDateAndTime = DateAdd(DateInterval.Minute, Minutes + 60, ImportPTOItem.ActivityStart.Value)

                                        ElseIf ImportPTOItem.ActivityStart.Value.DayOfWeek = DayOfWeek.Tuesday AndAlso Employee.TuesdayHours.HasValue AndAlso Employee.TuesdayStartTime.HasValue AndAlso ImportPTOItem.Duration.Value = Employee.TuesdayHours.Value Then

                                            EmployeeNonTask.StartDateAndTime = Employee.TuesdayStartTime.Value
                                            EmployeeNonTask.EndDateAndTime = DateAdd(DateInterval.Minute, Minutes + 60, ImportPTOItem.ActivityStart.Value)

                                        ElseIf ImportPTOItem.ActivityStart.Value.DayOfWeek = DayOfWeek.Wednesday AndAlso Employee.WednesdayHours.HasValue AndAlso Employee.WednesdayStartTime.HasValue AndAlso ImportPTOItem.Duration.Value = Employee.WednesdayHours.Value Then

                                            EmployeeNonTask.StartDateAndTime = Employee.WednesdayStartTime.Value
                                            EmployeeNonTask.EndDateAndTime = DateAdd(DateInterval.Minute, Minutes + 60, ImportPTOItem.ActivityStart.Value)

                                        ElseIf ImportPTOItem.ActivityStart.Value.DayOfWeek = DayOfWeek.Thursday AndAlso Employee.ThursdayHours.HasValue AndAlso Employee.ThursdayStartTime.HasValue AndAlso ImportPTOItem.Duration.Value = Employee.ThursdayHours.Value Then

                                            EmployeeNonTask.StartDateAndTime = Employee.ThursdayStartTime.Value
                                            EmployeeNonTask.EndDateAndTime = DateAdd(DateInterval.Minute, Minutes + 60, ImportPTOItem.ActivityStart.Value)

                                        ElseIf ImportPTOItem.ActivityStart.Value.DayOfWeek = DayOfWeek.Friday AndAlso Employee.FridayHours.HasValue AndAlso Employee.FridayStartTime.HasValue AndAlso ImportPTOItem.Duration.Value = Employee.FridayHours.Value Then

                                            EmployeeNonTask.StartDateAndTime = Employee.FridayStartTime.Value
                                            EmployeeNonTask.EndDateAndTime = DateAdd(DateInterval.Minute, Minutes + 60, ImportPTOItem.ActivityStart.Value)

                                        ElseIf ImportPTOItem.ActivityStart.Value.DayOfWeek = DayOfWeek.Saturday AndAlso Employee.SaturdayHours.HasValue AndAlso Employee.SaturdayStartTime.HasValue AndAlso ImportPTOItem.Duration.Value = Employee.SaturdayHours.Value Then

                                            EmployeeNonTask.StartDateAndTime = Employee.SaturdayStartTime.Value
                                            EmployeeNonTask.EndDateAndTime = DateAdd(DateInterval.Minute, Minutes + 60, ImportPTOItem.ActivityStart.Value)

                                        ElseIf ImportPTOItem.ActivityStart.Value.DayOfWeek = DayOfWeek.Sunday AndAlso Employee.SundayHours.HasValue AndAlso Employee.SundayStartTime.HasValue AndAlso ImportPTOItem.Duration.Value = Employee.SundayHours.Value Then

                                            EmployeeNonTask.StartDateAndTime = Employee.SundayStartTime.Value
                                            EmployeeNonTask.EndDateAndTime = DateAdd(DateInterval.Minute, Minutes + 60, ImportPTOItem.ActivityStart.Value)

                                        Else

                                            EmployeeNonTask.StartDateAndTime = ImportPTOItem.ActivityStart

                                            If ImportPTOItem.Duration = 8 Then

                                                EmployeeNonTask.EndDateAndTime = DateAdd(DateInterval.Minute, Minutes + 60, ImportPTOItem.ActivityStart.Value)

                                            Else

                                                EmployeeNonTask.EndDateAndTime = DateAdd(DateInterval.Minute, Minutes, ImportPTOItem.ActivityStart.Value)

                                            End If

                                        End If

                                    End If

                                    IndirectCategory = AdvantageFramework.Database.Procedures.IndirectCategory.LoadByIndirectCategoryCode(DbContext, ImportPTOItem.Category)

                                    EmployeeNonTask.Type = "A"
                                    EmployeeNonTask.StartDate = ShortDate
                                    EmployeeNonTask.EndDate = EmployeeNonTask.EndDateAndTime.Value.ToShortDateString
                                    EmployeeNonTask.IsAllDay = 0
                                    EmployeeNonTask.Description = If(IndirectCategory IsNot Nothing, IndirectCategory.Description, Nothing)
                                    EmployeeNonTask.Hours = ImportPTOItem.Duration
                                    EmployeeNonTask.EmployeeCode = ImportPTOItem.EmployeeCode
                                    EmployeeNonTask.Category = ImportPTOItem.Category
                                    EmployeeNonTask.Priority = 3

                                    If AdvantageFramework.Database.Procedures.EmployeeNonTask.Insert(DbContext, EmployeeNonTask) Then

                                        DbContext.Database.ExecuteSqlCommand(String.Format("insert dbo.EMP_NON_TASKS_EMPS (NON_TASK_ID, EMP_CODE, EMAIL_ADDRESS) values ({0}, '{1}', {2})", EmployeeNonTask.ID, ImportPTOItem.EmployeeCode, If(String.IsNullOrWhiteSpace(ImportPTOItem.EmployeeEmail), "NULL", "'" & ImportPTOItem.EmployeeEmail & "'")))

                                        DbContext.Database.ExecuteSqlCommand(String.Format("delete dbo.IMP_PTO_STAGING WHERE IMPORT_ID={0}", ImportPTOItem.ImportID))

                                    End If

                                Else

                                    Created = False

                                End If

                            ElseIf ImportPTOItem.Status = 2 Then

                                If EmployeeTime IsNot Nothing AndAlso EmployeeTimeIndirect IsNot Nothing Then

                                    EmployeeNonTask = (From Entity In AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeCode(DbContext, ImportPTOItem.EmployeeCode)
                                                       Where Entity.Type = "A" AndAlso
                                                             Entity.Category = ImportPTOItem.Category AndAlso
                                                             Entity.StartDateAndTime = ImportPTOItem.ActivityStart.Value
                                                       Select Entity).SingleOrDefault

                                    If EmployeeNonTask IsNot Nothing Then

                                        DbContext.Database.ExecuteSqlCommand(String.Format("delete dbo.EMP_NON_TASKS_EMPS where NON_TASK_ID = {0}", EmployeeNonTask.ID))

                                        If AdvantageFramework.Database.Procedures.EmployeeNonTask.Delete(DbContext, EmployeeNonTask) Then

                                        End If

                                    End If

                                    DbContext.Database.ExecuteSqlCommand(String.Format("delete dbo.EMP_TIME_DTL_CMTS where ET_ID = {0} AND ET_DTL_ID = {1} AND SEQ_NBR = {2} AND ET_SOURCE = 'N'", EmployeeTimeIndirect.ID, EmployeeTimeIndirect.EmployeeTimeDetailID, EmployeeTimeIndirect.SequenceNumber))

                                    If AdvantageFramework.Database.Procedures.EmployeeTimeIndirect.Delete(DbContext, EmployeeTimeIndirect.ID, EmployeeTimeIndirect.EmployeeTimeDetailID) Then

                                        DbContext.Database.ExecuteSqlCommand(String.Format("delete dbo.IMP_PTO_STAGING WHERE IMPORT_ID={0}", ImportPTOItem.ImportID))

                                    Else

                                        Created = False

                                    End If

                                End If

                            End If

                        Else

                            Created = False

                        End If

                    End If

                Next

            Catch ex As Exception
                Created = False
            End Try

            CreatePTORecordsFromImport = Created

        End Function

#End Region

#Region "   Journal Entry "

        Private Function CreateImportJournalEntryStaging(Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext,
                                                         ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                         ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail),
                                                         FileLineData As Object, BatchName As String, AutoTrimOverFlowData As Boolean,
                                                         ImportJournalEntries As Hashtable,
                                                         DataTable As System.Data.DataTable,
                                                         DataTableJEDetail As System.Data.DataTable,
                                                         ClientCrossReferences As Generic.List(Of AdvantageFramework.Database.Entities.ClientCrossReference),
                                                         GeneralLedgerCrossReferences As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerCrossReference))

            'objects
            Dim Created As Boolean = True
            Dim ImportJournalEntry As AdvantageFramework.Database.Entities.ImportJournalEntry = Nothing
            Dim ImportJournalEntryDetail As AdvantageFramework.Database.Entities.ImportJournalEntryDetail = Nothing
            Dim ExistingImportJournalEntry As AdvantageFramework.Database.Entities.ImportJournalEntry = Nothing
            Dim ClientCrossReference As AdvantageFramework.Database.Entities.ClientCrossReference = Nothing
            Dim GeneralLedgerCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerCrossReference = Nothing
            Dim HashKey As String = Nothing

            Try

                ImportJournalEntry = New AdvantageFramework.Database.Entities.ImportJournalEntry
                ImportJournalEntryDetail = New AdvantageFramework.Database.Entities.ImportJournalEntryDetail

                ImportJournalEntry.DbContext = DbContext
                ImportJournalEntry.BatchName = BatchName

                CreateEntityFromTemplateDataTable(ImportTemplate, DataTable, FileLineData, ImportJournalEntry, AutoTrimOverFlowData)
                CreateEntityFromTemplateDataTable(ImportTemplate, DataTableJEDetail, FileLineData, ImportJournalEntryDetail, AutoTrimOverFlowData)

                ImportJournalEntry.ImportTemplateID = ImportTemplate.ID

                If String.IsNullOrWhiteSpace(ImportJournalEntry.GLSource) Then

                    ImportJournalEntry.GLSource = "IJ"

                End If

                Try

                    If String.IsNullOrWhiteSpace(ImportJournalEntry.TransactionID) Then

                        HashKey = NullHashKeyString

                    Else

                        HashKey = ImportJournalEntry.TransactionID

                    End If

                    ExistingImportJournalEntry = ImportJournalEntries(HashKey)

                Catch ex As Exception
                    ExistingImportJournalEntry = Nothing
                End Try

                If ExistingImportJournalEntry Is Nothing Then

                    DbContext.ImportJournalEntrys.Add(ImportJournalEntry)
                    ImportJournalEntries.Add(HashKey, ImportJournalEntry)

                Else

                    ImportJournalEntry = ExistingImportJournalEntry

                    If ImportJournalEntry.DbContext Is Nothing Then

                        DbContext.TryAttach(ImportJournalEntry)

                    End If

                End If

                If ImportTemplate.RecordSourceID.HasValue Then

                    ImportJournalEntryDetail.ClearBlankValues()

                    Try

                        ClientCrossReference = (From CCR In ClientCrossReferences
                                                Where (CCR.SourceClientCode = ImportJournalEntryDetail.ClientCode OrElse
                                                       (CCR.SourceClientCode Is Nothing AndAlso ImportJournalEntryDetail.ClientCode Is Nothing)) AndAlso
                                                      (CCR.SourceDivisionCode = ImportJournalEntryDetail.DivisionCode OrElse
                                                       (CCR.SourceDivisionCode Is Nothing AndAlso ImportJournalEntryDetail.DivisionCode Is Nothing)) AndAlso
                                                      (CCR.SourceProductCode = ImportJournalEntryDetail.ProductCode OrElse
                                                       (CCR.SourceProductCode Is Nothing AndAlso ImportJournalEntryDetail.ProductCode Is Nothing))
                                                Select CCR).SingleOrDefault

                    Catch ex As Exception
                        ClientCrossReference = Nothing
                    End Try

                    If ClientCrossReference IsNot Nothing Then

                        ImportJournalEntryDetail.ClientCode = ClientCrossReference.ClientCode
                        ImportJournalEntryDetail.DivisionCode = ClientCrossReference.DivisionCode
                        ImportJournalEntryDetail.ProductCode = ClientCrossReference.ProductCode

                    End If

                    Try

                        GeneralLedgerCrossReference = (From Entity In GeneralLedgerCrossReferences
                                                       Where Entity.SourceGLACode = ImportJournalEntryDetail.GLAccount
                                                       Select Entity).SingleOrDefault

                    Catch ex As Exception
                        GeneralLedgerCrossReference = Nothing
                    End Try

                    If GeneralLedgerCrossReference IsNot Nothing Then

                        ImportJournalEntryDetail.GLAccount = GeneralLedgerCrossReference.GLACode

                    End If

                End If

                ImportJournalEntry.ImportJournalEntryDetails.Add(ImportJournalEntryDetail)

            Catch ex As Exception
                Created = False
            Finally
                CreateImportJournalEntryStaging = Created
            End Try

        End Function
        Public Function CreateJERecordsFromImport(DbContext As AdvantageFramework.Database.DbContext,
                                                  ImportJournalEntrys As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry),
                                                  LogExternalIDs As Boolean) As Boolean

            'objects
            Dim Created As Boolean = True
            Dim ImportIDs As IEnumerable(Of Integer) = Nothing
            Dim ErrorMessage As String = Nothing
            Dim ImportJournalEntry As AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry = Nothing
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim BatchDate As Date = Nothing
            Dim SequenceNumber As Short = Nothing
            Dim GeneralLedgerDetailList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerDetail) = Nothing
            Dim GeneralLedgerExternalGLIFaceCrossReferenceList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerExternalGLIFaceCrossReference) = Nothing
            Dim GeneralLedgerExternalGLIFaceCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerExternalGLIFaceCrossReference = Nothing
            Dim TransactionSum As Decimal = -1
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            Try

                ImportIDs = (From Entity In ImportJournalEntrys
                             Where Entity.IsOnHold = False
                             Select Entity.ID).Distinct.ToList

                BatchDate = Now

                DbContext.Database.Connection.Open()

                DbContext.Configuration.AutoDetectChangesEnabled = False

                If LogExternalIDs Then

                    GeneralLedgerExternalGLIFaceCrossReferenceList = New Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerExternalGLIFaceCrossReference)

                End If

                For Each ImportID In ImportIDs

                    ImportJournalEntry = ImportJournalEntrys.Where(Function(Entity) Entity.ID = ImportID).FirstOrDefault

                    If ImportJournalEntry IsNot Nothing Then

                        DbTransaction = DbContext.Database.BeginTransaction

                        Try

                            ImportJournalEntry.DbContext = DbContext

                            If AdvantageFramework.GeneralLedger.InsertGeneralLedger(GeneralLedger, DbContext, ImportJournalEntry.PostPeriodCode, DbContext.UserCode, ImportJournalEntry.Description, ImportJournalEntry.GLSource, BatchDate, ImportJournalEntry.TransactionDate) Then

                                SequenceNumber = 0

                                GeneralLedgerDetailList = New Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerDetail)

                                If LogExternalIDs Then

                                    GeneralLedgerExternalGLIFaceCrossReferenceList.Clear()

                                End If

                                For Each Dtl In ImportJournalEntrys.Where(Function(Det) Det.ID = ImportJournalEntry.ID)

                                    SequenceNumber += 1

                                    If String.IsNullOrWhiteSpace(Dtl.Remark) Then

                                        Dtl.Remark = GeneralLedger.Description

                                    End If

                                    GeneralLedgerDetail = New AdvantageFramework.Database.Entities.GeneralLedgerDetail
                                    GeneralLedgerDetail.DbContext = DbContext
                                    GeneralLedgerDetail.GLTransaction = GeneralLedger.Transaction
                                    GeneralLedgerDetail.GLACode = Dtl.GLAccount
                                    GeneralLedgerDetail.CreditAmount = Dtl.Amount
                                    GeneralLedgerDetail.DebitAmount = Dtl.Amount
                                    GeneralLedgerDetail.Remark = Mid(Dtl.Remark, 1, 150)
                                    GeneralLedgerDetail.GLSourceCode = GeneralLedger.GLSourceCode
                                    GeneralLedgerDetail.ClientCode = If(Not String.IsNullOrWhiteSpace(Dtl.ClientCode), Dtl.ClientCode, Nothing)
                                    GeneralLedgerDetail.DivisionCode = If(Not String.IsNullOrWhiteSpace(Dtl.DivisionCode), Dtl.DivisionCode, Nothing)
                                    GeneralLedgerDetail.ProductCode = If(Not String.IsNullOrWhiteSpace(Dtl.ProductCode), Dtl.ProductCode, Nothing)
                                    GeneralLedgerDetail.SequenceNumber = SequenceNumber

                                    GeneralLedgerDetailList.Add(GeneralLedgerDetail)

                                    If LogExternalIDs Then

                                        GeneralLedgerExternalGLIFaceCrossReference = New AdvantageFramework.Database.Entities.GeneralLedgerExternalGLIFaceCrossReference
                                        GeneralLedgerExternalGLIFaceCrossReference.DbContext = DbContext

                                        GeneralLedgerExternalGLIFaceCrossReference.ExternalGLIFaceID = Dtl.ExternalID.Value
                                        GeneralLedgerExternalGLIFaceCrossReference.GLTransaction = GeneralLedger.Transaction

                                        GeneralLedgerExternalGLIFaceCrossReferenceList.Add(GeneralLedgerExternalGLIFaceCrossReference)

                                    End If

                                Next

                                DbContext.GeneralLedgerDetails.AddRange(GeneralLedgerDetailList)

                                If LogExternalIDs Then

                                    DbContext.GeneralLedgerExternalGLIFaceCrossReferences.AddRange(GeneralLedgerExternalGLIFaceCrossReferenceList)

                                End If

                                DbContext.SaveChanges()

                                TransactionSum = DbContext.Database.SqlQuery(Of Decimal)(String.Format("SELECT CAST(SUM(GLETAMT) AS DECIMAL(16,2)) FROM dbo.GLENTTRL (NOLOCK) WHERE GLETXACT={0}", GeneralLedger.Transaction)).FirstOrDefault

                                If TransactionSum = 0 Then

                                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.IMP_JE_DETAIL WHERE IMPORT_ID={0}", ImportJournalEntry.ID))

                                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.IMP_JE_HEADER WHERE IMPORT_ID={0}", ImportJournalEntry.ID))

                                    DbTransaction.Commit()

                                Else

                                    DbTransaction.Rollback()

                                    Created = False

                                End If

                            Else

                                Throw New Exception("Failed to insert GL header record.")

                            End If

                        Catch ex As Exception
                            Throw ex
                        End Try

                    End If

                Next

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                ErrorMessage += vbCrLf & ex.Message
                Created = False
            Finally

                If DbContext.Database.Connection.State = ConnectionState.Open Then

                    DbContext.Database.Connection.Close()

                End If

                DbContext.Configuration.AutoDetectChangesEnabled = True

            End Try

            CreateJERecordsFromImport = Created

        End Function
        Private Sub SaveJournalEntry(DbContext As AdvantageFramework.Database.DbContext,
                                     ByRef FailedLines As Generic.Dictionary(Of Integer, String))

            Dim HasUpdateException As Boolean = False
            Dim UpdateException As System.Data.Entity.Core.UpdateException = Nothing
            Dim ImportJournalEntry As AdvantageFramework.Database.Entities.ImportJournalEntry = Nothing

            Try

                DbContext.SaveChanges()

            Catch ex As System.Data.Entity.Core.UpdateException

                UpdateException = ex
                HasUpdateException = True

                If FailedLines Is Nothing Then

                    FailedLines = New Generic.Dictionary(Of Integer, String)
                    FailedLines.Add(-1, "Bulk JE Save")

                End If

                While HasUpdateException

                    For Each ObjectStateEntry In UpdateException.StateEntries

                        ImportJournalEntry = DirectCast(ObjectStateEntry.Entity, AdvantageFramework.Database.Entities.ImportJournalEntry)

                        For Each ImportJournalEntryDetail In ImportJournalEntry.ImportJournalEntryDetails.ToList

                            DbContext.Detach(ImportJournalEntryDetail)

                        Next

                        DbContext.Detach(ImportJournalEntry)

                        Try

                            DbContext.SaveChanges()

                            HasUpdateException = False

                        Catch upex As System.Data.Entity.Core.UpdateException
                            UpdateException = upex
                            HasUpdateException = True
                        Catch ex2 As Exception

                        End Try

                    Next

                End While

            End Try

        End Sub

#End Region

#Region "   Broadcast 4a "

        Public Function ImportBroadcast4AStaging(ByVal Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext, DataContext As AdvantageFramework.Database.DataContext,
                                                 ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                 ByVal File As String, ByVal BatchName As String, ByVal AutoTrimOverflowData As Boolean,
                                                 ByVal InvoicePDF As String, Optional ByVal EventLog As System.Diagnostics.EventLog = Nothing) As Boolean

            'objects
            Dim FileImported As Boolean = True
            Dim FileLines As Generic.List(Of String) = Nothing

            Try

                FileLines = GetFileLines(File).ToList

                FileImported = ImportBroadcast4AStaging(Session, DbContext, DataContext, ImportTemplate, FileLines, BatchName, AutoTrimOverflowData, InvoicePDF, EventLog)

            Catch ex As Exception
                FileImported = False
            Finally
                ImportBroadcast4AStaging = FileImported
            End Try

        End Function
        Public Function ImportBroadcast4AStaging(ByVal Session As AdvantageFramework.Security.Session,
                                                 ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                 ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                 ByVal FileLines As Generic.List(Of String), ByVal BatchName As String,
                                                 ByVal AutoTrimOverflowData As Boolean, ByVal InvoicePDF As String,
                                                 Optional ByVal EventLog As System.Diagnostics.EventLog = Nothing) As Boolean

            'objects
            Dim FileImported As Boolean = True
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim FileLineData() As String = Nothing
            Dim FileLineCounter As Integer = 0
            Dim StringList As Generic.List(Of String) = Nothing
            Dim Products As Generic.List(Of AdvantageFramework.Database.Views.ProductView) = Nothing
            Dim Divisions As Generic.List(Of AdvantageFramework.Database.Views.DivisionView) = Nothing
            Dim Clients As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Product As AdvantageFramework.Database.Views.ProductView = Nothing
            Dim Division As AdvantageFramework.Database.Views.DivisionView = Nothing
            Dim InvoiceHeaderRecord As Importing.Classes.Broadcast4A.InvoiceHeaderRecord = Nothing
            Dim ScheduleLineRecord As Importing.Classes.Broadcast4A.ScheduleLineRecord = Nothing
            Dim BroadcastDetailRecord As Importing.Classes.Broadcast4A.BroadcastDetailRecord = Nothing
            Dim ScheduleCommentRecord As Importing.Classes.Broadcast4A.ScheduleCommentRecord = Nothing
            Dim StationRecord As Importing.Classes.Broadcast4A.StationRecord = Nothing
            Dim InvoiceTotalRecord As AdvantageFramework.Importing.Classes.Broadcast4A.InvoiceTotalRecord = Nothing
            Dim ImportAccountPayable As AdvantageFramework.Database.Entities.ImportAccountPayable = Nothing
            Dim ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia = Nothing
            Dim FileRecord As Object = Nothing
            Dim RateCounter As Integer = 0
            Dim ImportAccountPayableBroadcastDetail As AdvantageFramework.Database.Entities.ImportAccountPayableBroadcastDetail = Nothing
            Dim MaxCount As Integer = 100
            Dim ProductIsValid As Boolean = False
            Dim FilteredProducts As Generic.List(Of AdvantageFramework.Database.Views.ProductView) = Nothing
            Dim VendorCode As String = Nothing
            Dim VendorName As String = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim FileInfo As IO.FileInfo = Nothing
            Dim ImportDocument As AdvantageFramework.Database.Entities.ImportDocument = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim RemoveImportAccountPayableMedias As Generic.List(Of AdvantageFramework.Database.Entities.ImportAccountPayableMedia) = Nothing
            Dim ImportAccountPayableList As Generic.List(Of AdvantageFramework.Database.Entities.ImportAccountPayable) = Nothing

            Try

                If FileLines IsNot Nothing AndAlso FileLines.Count > 0 Then

                    Clients = AdvantageFramework.Database.Procedures.Client.Load(DbContext).ToList
                    Divisions = AdvantageFramework.Database.Procedures.DivisionView.Load(DbContext).ToList
                    Products = AdvantageFramework.Database.Procedures.ProductView.Load(DbContext).ToList

                    ImportAccountPayableList = New Generic.List(Of AdvantageFramework.Database.Entities.ImportAccountPayable)

                    RaiseEvent SetupImportingProgressEvent(0, FileLines.Count, 0)

                    For Each FileLine In FileLines

                        FileLineData = FileLine.Split(";")

                        If FileLineCounter <> 0 AndAlso FileLineData.Count > 0 Then

                            FileRecord = GetBroadcast4aRecordFromFileLine(DbContext, FileLineData, AutoTrimOverflowData)

                            If FileRecord IsNot Nothing Then

                                If TypeOf FileRecord Is AdvantageFramework.Importing.Classes.Broadcast4A.StationRecord Then

                                    StationRecord = DirectCast(FileRecord, AdvantageFramework.Importing.Classes.Broadcast4A.StationRecord)

                                    Vendor = Nothing

                                    VendorCode = String.Concat(StationRecord.CallLetters, StationRecord.Band)
                                    VendorName = StationRecord.Name

                                    Vendor = GetVendorByCallLetterHierarchy(Session, DbContext, ImportTemplate, StationRecord.CallLetters & "", StationRecord.Band & "", StationRecord.Name)

                                    'Vendor = Nothing

                                    'VendorCode = String.Concat(StationRecord.CallLetters, StationRecord.Band)
                                    'VendorName = StationRecord.Name

                                    'If IsNumeric(StationRecord.CallLetters) Then

                                    '    If Session.IsNielsenSetup Then

                                    '        Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                                    '            If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                                    '                NCCTVSyscode = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NCCTVSyscode.GetSyscodesByMarketHosted(NielsenDbContext, Session.NielsenClientCodeForHosted, Nothing)
                                    '                                Where Entity.Syscode = StationRecord.CallLetters
                                    '                                Select Entity).SingleOrDefault

                                    '            Else

                                    '                NCCTVSyscode = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NCCTVSyscode.GetSyscodesByMarket(NielsenDbContext, Nothing)
                                    '                                Where Entity.Syscode = StationRecord.CallLetters
                                    '                                Select Entity).SingleOrDefault

                                    '            End If

                                    '            If NCCTVSyscode IsNot Nothing Then

                                    '                If (From Entity In AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext)
                                    '                    Where Entity.NCCTVSyscodeID = NCCTVSyscode.ID
                                    '                    Select Entity).Count = 1 Then

                                    '                    Vendor = (From Entity In AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext)
                                    '                              Where Entity.NCCTVSyscodeID = NCCTVSyscode.ID
                                    '                              Select Entity).Single

                                    '                    If Vendor IsNot Nothing Then

                                    '                        VendorCode = Vendor.Code
                                    '                        VendorName = Vendor.Name

                                    '                    Else

                                    '                        NCCTVSyscode = Nothing

                                    '                    End If

                                    '                Else

                                    '                    NCCTVSyscode = Nothing

                                    '                End If

                                    '            End If

                                    '        End Using

                                    '    End If

                                    '    If NCCTVSyscode Is Nothing Then

                                    '        VendorCodeLookup = StationRecord.CallLetters.PadLeft(4, "0")

                                    '        Vendor = (From Entity In AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext)
                                    '                  Where Entity.Code = VendorCodeLookup
                                    '                  Select Entity).SingleOrDefault

                                    '        If Vendor IsNot Nothing Then

                                    '            VendorCode = Vendor.Code
                                    '            VendorName = Vendor.Name

                                    '        End If

                                    '    End If

                                    'End If

                                    'If Vendor Is Nothing AndAlso ImportTemplate.RecordSourceID.HasValue Then

                                    '    Try

                                    '        VendorCrossReference = (From VCR In AdvantageFramework.Database.Procedures.VendorCrossReference.LoadByRecordSourceID(DbContext, ImportTemplate.RecordSourceID.Value)
                                    '                                Where VCR.SourceVendorCode.ToUpper = VendorCode.ToUpper
                                    '                                Select VCR).SingleOrDefault

                                    '    Catch ex As Exception
                                    '        VendorCrossReference = Nothing
                                    '    End Try

                                    '    If VendorCrossReference IsNot Nothing Then

                                    '        VendorCode = VendorCrossReference.VendorCode

                                    '        Vendor = Vendors.Where(Function(v) v.Code.ToUpper = VendorCode.ToUpper).SingleOrDefault

                                    '        VendorCode = Vendor.Code
                                    '        VendorName = Vendor.Name

                                    '    End If

                                    'End If

                                    'If Vendor Is Nothing Then

                                    '    If Vendors.Where(Function(v) Not String.IsNullOrWhiteSpace(v.VendorCodeCrossReference) AndAlso v.VendorCodeCrossReference.ToUpper = VendorCode.Trim.ToUpper).Count = 1 Then

                                    '        Vendor = Vendors.Where(Function(v) Not String.IsNullOrWhiteSpace(v.VendorCodeCrossReference) AndAlso v.VendorCodeCrossReference.ToUpper = VendorCode.Trim.ToUpper).SingleOrDefault
                                    '        VendorCode = Vendor.Code

                                    '    End If

                                    'End If

                                    'If Not String.IsNullOrWhiteSpace(VendorCode) Then

                                    '    If Vendors.Where(Function(v) v.Code.ToUpper = VendorCode.Trim.ToUpper).Any Then

                                    '        Vendor = Vendors.Where(Function(v) v.Code.ToUpper = VendorCode.Trim.ToUpper).SingleOrDefault

                                    '    ElseIf Vendors.Where(Function(v) v.Code.ToUpper = StationRecord.CallLetters.Trim.ToUpper).Count = 1 Then

                                    '        Vendor = Vendors.Where(Function(v) v.Code.ToUpper = StationRecord.CallLetters.Trim.ToUpper).SingleOrDefault

                                    '    End If

                                    'End If

                                    'If Not String.IsNullOrWhiteSpace(VendorName) AndAlso Vendor Is Nothing Then

                                    '    If Vendors.Where(Function(v) v.Name.ToUpper = VendorName.Trim.ToUpper).Count = 1 Then

                                    '        Vendor = Vendors.Where(Function(v) v.Name.ToUpper = VendorName.Trim.ToUpper).SingleOrDefault

                                    '    ElseIf Vendors.Where(Function(v) v.Name.ToUpper.StartsWith(VendorName.Trim.ToUpper)).Count = 1 Then

                                    '        Vendor = Vendors.Where(Function(v) v.Name.ToUpper.StartsWith(VendorName.Trim.ToUpper)).SingleOrDefault

                                    '    End If

                                    'End If

                                    If Vendor IsNot Nothing Then

                                        VendorCode = Vendor.Code
                                        VendorName = Vendor.Name

                                    End If

                                ElseIf TypeOf FileRecord Is AdvantageFramework.Importing.Classes.Broadcast4A.InvoiceHeaderRecord Then

                                    InvoiceHeaderRecord = DirectCast(FileRecord, AdvantageFramework.Importing.Classes.Broadcast4A.InvoiceHeaderRecord)

                                    ImportAccountPayable = New AdvantageFramework.Database.Entities.ImportAccountPayable
                                    ImportAccountPayable.ImportTemplateID = ImportTemplate.ID

                                    ImportAccountPayable.BatchName = BatchName
                                    ImportAccountPayable.VendorCode = VendorCode
                                    ImportAccountPayable.VendorName = VendorName
                                    ImportAccountPayable.InvoiceNumber = InvoiceHeaderRecord.Number
                                    ImportAccountPayable.InvoiceDate = InvoiceHeaderRecord.InvoiceDate

                                    If InvoiceHeaderRecord.OrderType.ToUpper.Trim = "TRADE" Then

                                        ImportAccountPayable.Is4AsCommissionOnly = True

                                    End If

                                    ImportAccountPayableList.Add(ImportAccountPayable)

                                    DbContext.ImportAccountPayables.Add(ImportAccountPayable)

                                ElseIf TypeOf FileRecord Is AdvantageFramework.Importing.Classes.Broadcast4A.ScheduleLineRecord Then

                                    ScheduleLineRecord = DirectCast(FileRecord, AdvantageFramework.Importing.Classes.Broadcast4A.ScheduleLineRecord)

                                    Division = Nothing
                                    Product = Nothing
                                    ProductIsValid = False

                                    ImportAccountPayableMedia = New Database.Entities.ImportAccountPayableMedia

                                    ImportAccountPayableMedia.ClientName = InvoiceHeaderRecord.AdvertiserName
                                    ImportAccountPayableMedia.ProductName = InvoiceHeaderRecord.ProductName
                                    ImportAccountPayableMedia.ClientCode = If(InvoiceHeaderRecord.AgencyAdvertiserCode = "NULL", Nothing, InvoiceHeaderRecord.AgencyAdvertiserCode)
                                    ImportAccountPayableMedia.ProductCode = InvoiceHeaderRecord.AgencyProductCode

                                    If Not String.IsNullOrWhiteSpace(InvoiceHeaderRecord.AgencyEstimateCode) AndAlso IsNumeric(InvoiceHeaderRecord.AgencyEstimateCode) Then

                                        Try

                                            ImportAccountPayableMedia.OrderNumber = CInt(InvoiceHeaderRecord.AgencyEstimateCode)

                                        Catch ex As Exception
                                            Try
                                                ImportAccountPayableMedia.OrderNumber = AdvantageFramework.StringUtilities.ParseDigits(InvoiceHeaderRecord.RepOrderNumber)
                                            Catch ex2 As Exception

                                            End Try
                                        End Try
                                    End If

                                    ImportAccountPayableMedia.OrderID = Nothing 'InvoiceHeaderRecord.StationOrderNumber
                                    ImportAccountPayableMedia.OrderLineID = AdvantageFramework.StringUtilities.RemoveAllNonNumeric(ScheduleLineRecord.Number, "1")

                                    ImportAccountPayableMedia.OrderLineNumber = Nothing 'ScheduleLineRecord.Number
                                    ImportAccountPayableMedia.MediaType = StationRecord.AdvantageMediaType
                                    ImportAccountPayableMedia.DaysOfWeek = ScheduleLineRecord.DaysOfWeek
                                    ImportAccountPayableMedia.StartTime = ScheduleLineRecord.StartTime
                                    ImportAccountPayableMedia.EndTime = ScheduleLineRecord.EndTime
                                    ImportAccountPayableMedia.RateDetail = ScheduleLineRecord.RateDetail
                                    ImportAccountPayableMedia.PlanCode = ScheduleLineRecord.PlanCode
                                    ImportAccountPayableMedia.PackageCode = ScheduleLineRecord.PackageCode

                                    Try

                                        ImportAccountPayableMedia.Month = [Enum].GetName(GetType(AdvantageFramework.DateUtilities.AbbreviatedMonths), CInt(InvoiceHeaderRecord.BroadcastMonth.Substring(2, 2))).ToString

                                    Catch ex As Exception

                                    End Try

                                    Try

                                        ImportAccountPayableMedia.Year = CShort(System.Globalization.CultureInfo.CurrentCulture.Calendar.ToFourDigitYear(CInt(InvoiceHeaderRecord.BroadcastMonth.Substring(0, 2))))

                                    Catch ex As Exception

                                    End Try

                                    If Not String.IsNullOrWhiteSpace(ImportAccountPayableMedia.ClientCode) Then

                                        If Clients.Where(Function(c) c.Code.ToUpper = ImportAccountPayableMedia.ClientCode.Trim.ToUpper).Any Then

                                            With Clients.Where(Function(c) c.Code.ToUpper = ImportAccountPayableMedia.ClientCode.Trim.ToUpper).SingleOrDefault

                                                ImportAccountPayableMedia.ClientCode = .Code
                                                ImportAccountPayableMedia.ClientName = .Name

                                            End With

                                        End If

                                    ElseIf Not String.IsNullOrWhiteSpace(ImportAccountPayableMedia.ClientName) Then

                                        If Clients.Where(Function(c) c.Name.ToUpper = ImportAccountPayableMedia.ClientName.Trim.ToUpper).Count() = 1 Then

                                            With Clients.Where(Function(c) c.Name.ToUpper = ImportAccountPayableMedia.ClientName.Trim.ToUpper).SingleOrDefault

                                                ImportAccountPayableMedia.ClientCode = .Code
                                                ImportAccountPayableMedia.ClientName = .Name

                                            End With

                                        ElseIf Clients.Where(Function(c) c.Name.ToUpper.StartsWith(ImportAccountPayableMedia.ClientName.Trim.ToUpper)).Count = 1 Then

                                            With Clients.Where(Function(c) c.Name.ToUpper.StartsWith(ImportAccountPayableMedia.ClientName.Trim.ToUpper)).SingleOrDefault

                                                ImportAccountPayableMedia.ClientCode = .Code
                                                ImportAccountPayableMedia.ClientName = .Name

                                            End With

                                        End If

                                    End If

                                    If Not String.IsNullOrWhiteSpace(ImportAccountPayableMedia.ClientCode) Then

                                        FilteredProducts = Products.Where(Function(p) p.ClientCode = ImportAccountPayableMedia.ClientCode).ToList

                                        If Not String.IsNullOrWhiteSpace(ImportAccountPayableMedia.ProductCode) Then

                                            If FilteredProducts.Where(Function(p) p.ProductCode.ToUpper = ImportAccountPayableMedia.ProductCode.ToUpper).Any Then

                                                ProductIsValid = True

                                                FilteredProducts = FilteredProducts.Where(Function(p) p.ProductCode.ToUpper = ImportAccountPayableMedia.ProductCode.ToUpper).ToList

                                                If FilteredProducts.Count = 1 Then

                                                    Product = FilteredProducts.SingleOrDefault

                                                ElseIf FilteredProducts.Where(Function(p) p.IsActive.GetValueOrDefault(0) = 1).Count = 1 Then

                                                    Product = FilteredProducts.Where(Function(p) p.IsActive.GetValueOrDefault(0) = 1).SingleOrDefault

                                                ElseIf Not String.IsNullOrWhiteSpace(ImportAccountPayableMedia.ProductName) AndAlso FilteredProducts.Where(Function(p) p.ProductDescription.ToUpper = ImportAccountPayableMedia.ProductName.ToUpper).Count = 1 Then

                                                    Product = FilteredProducts.Where(Function(p) p.ProductDescription.ToUpper = ImportAccountPayableMedia.ProductName.ToUpper).SingleOrDefault

                                                ElseIf Not String.IsNullOrWhiteSpace(ImportAccountPayableMedia.ProductName) AndAlso FilteredProducts.Where(Function(p) p.ProductDescription.ToUpper = ImportAccountPayableMedia.ProductName.ToUpper AndAlso p.IsActive.GetValueOrDefault(0) = 1).Count = 1 Then

                                                    Product = FilteredProducts.Where(Function(p) p.ProductDescription.ToUpper = ImportAccountPayableMedia.ProductName.ToUpper AndAlso p.IsActive.GetValueOrDefault(0) = 1).SingleOrDefault

                                                End If

                                            End If

                                        End If

                                        If Not ProductIsValid Then

                                            If Not String.IsNullOrWhiteSpace(ImportAccountPayableMedia.ProductName) Then

                                                If FilteredProducts.Where(Function(p) p.ProductDescription.ToUpper = ImportAccountPayableMedia.ProductName.ToUpper).Any Then

                                                    ProductIsValid = True

                                                    FilteredProducts = FilteredProducts.Where(Function(p) p.ProductDescription.ToUpper = ImportAccountPayableMedia.ProductName.ToUpper).ToList

                                                    If FilteredProducts.Count = 1 Then

                                                        Product = FilteredProducts.SingleOrDefault

                                                    ElseIf FilteredProducts.Where(Function(p) p.IsActive.GetValueOrDefault(0) = 1).Count = 1 Then

                                                        Product = FilteredProducts.Where(Function(p) p.IsActive.GetValueOrDefault(0) = 1).SingleOrDefault

                                                    End If

                                                ElseIf FilteredProducts.Where(Function(p) p.ProductDescription.ToUpper.StartsWith(ImportAccountPayableMedia.ProductName.Trim.ToUpper)).Count = 1 Then

                                                    Product = FilteredProducts.Where(Function(p) p.ProductDescription.ToUpper.StartsWith(ImportAccountPayableMedia.ProductName.Trim.ToUpper)).SingleOrDefault

                                                End If

                                            End If

                                        End If

                                        If Product IsNot Nothing Then

                                            ImportAccountPayableMedia.ClientCode = Product.ClientCode
                                            ImportAccountPayableMedia.ClientName = Product.ClientName
                                            ImportAccountPayableMedia.DivisionCode = Product.DivisionCode
                                            ImportAccountPayableMedia.DivisionName = Product.DivisionName
                                            ImportAccountPayableMedia.ProductCode = Product.ProductCode
                                            ImportAccountPayableMedia.ProductName = Product.ProductDescription

                                        ElseIf Not ProductIsValid Then

                                            'if ProductName is empty, pass in ProductCode 
                                            If String.IsNullOrWhiteSpace(ImportAccountPayableMedia.ProductName) Then

                                                ImportAccountPayableMedia.ProductName = ImportAccountPayableMedia.ProductCode

                                            End If

                                            ImportAccountPayableMedia.ProductCode = Nothing

                                        End If

                                    End If

                                    ImportAccountPayable.ImportAccountPayableMedias.Add(ImportAccountPayableMedia)

                                ElseIf TypeOf FileRecord Is AdvantageFramework.Importing.Classes.Broadcast4A.BroadcastDetailRecord Then

                                    BroadcastDetailRecord = DirectCast(FileRecord, AdvantageFramework.Importing.Classes.Broadcast4A.BroadcastDetailRecord)

                                    If BroadcastDetailRecord.RunCode.ToUpper = "Y" Then

                                        ImportAccountPayableBroadcastDetail = New Database.Entities.ImportAccountPayableBroadcastDetail

                                        ImportAccountPayableBroadcastDetail.RunDate = BroadcastDetailRecord.RunDate
                                        ImportAccountPayableBroadcastDetail.DayOfWeek = BroadcastDetailRecord.DayOfWeek
                                        ImportAccountPayableBroadcastDetail.TimeOfDay = BroadcastDetailRecord.TimeOfDay
                                        ImportAccountPayableBroadcastDetail.Length = BroadcastDetailRecord.Type
                                        ImportAccountPayableBroadcastDetail.AdNumber = BroadcastDetailRecord.CopyID

                                        If Vendor IsNot Nothing AndAlso Vendor.Commission.GetValueOrDefault(0) <> 0 Then

                                            ImportAccountPayableBroadcastDetail.NetRate = Math.Round(BroadcastDetailRecord.Rate * (1 - (Vendor.Commission.Value / 100)), 4, MidpointRounding.AwayFromZero)

                                        Else

                                            ImportAccountPayableBroadcastDetail.NetRate = Math.Round(BroadcastDetailRecord.Rate * 0.85, 4, MidpointRounding.AwayFromZero)

                                        End If

                                        ImportAccountPayableBroadcastDetail.GrossRate = BroadcastDetailRecord.Rate
                                        ImportAccountPayableBroadcastDetail.Piggyback = BroadcastDetailRecord.Piggyback
                                        ImportAccountPayableBroadcastDetail.ProgramName = BroadcastDetailRecord.ProgramDescription
                                        ImportAccountPayableBroadcastDetail.NetworkID = BroadcastDetailRecord.NetworkForLocalCable
                                        ImportAccountPayableBroadcastDetail.PackageCode = BroadcastDetailRecord.PackageForNetworkOnly

                                        ImportAccountPayableMedia.ImportAccountPayableBroadcastDetails.Add(ImportAccountPayableBroadcastDetail)

                                        ImportAccountPayableMedia.LineDate = ImportAccountPayableMedia.ImportAccountPayableBroadcastDetails.Select(Function(dtl) dtl.RunDate).Min
                                        ImportAccountPayableMedia.LineStartDate = ImportAccountPayableMedia.LineDate
                                        ImportAccountPayableMedia.LineEndDate = ImportAccountPayableMedia.ImportAccountPayableBroadcastDetails.Select(Function(dtl) dtl.RunDate).Max

                                        If ImportAccountPayableMedia.MediaGrossRate.HasValue = False Then

                                            ImportAccountPayableMedia.MediaGrossRate = BroadcastDetailRecord.Rate
                                            ImportAccountPayableMedia.MediaNetRate = ImportAccountPayableBroadcastDetail.NetRate

                                        End If

                                        If ImportAccountPayableMedia.Year.HasValue AndAlso Not String.IsNullOrWhiteSpace(ImportAccountPayableMedia.Month) AndAlso
                                                ImportAccountPayableMedia.OrderNumber.HasValue AndAlso ImportAccountPayableMedia.OrderLineNumber.HasValue = False Then

                                            If ImportAccountPayableMedia.MediaType = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.SalesClassMediaType.Radio).Code Then

                                                With (From OrderDtl In AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadNonCancelledByOrderNumber(DbContext, ImportAccountPayableMedia.OrderNumber.Value, ImportAccountPayableMedia.Month, ImportAccountPayableMedia.Year.Value)
                                                      Where OrderDtl.GrossRate = ImportAccountPayableMedia.MediaGrossRate.Value
                                                      Select OrderDtl)

                                                    If .Count = 1 Then

                                                        ImportAccountPayableMedia.OrderLineNumber = .FirstOrDefault.LineNumber

                                                    End If

                                                End With

                                            ElseIf ImportAccountPayableMedia.MediaType = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.SalesClassMediaType.Television).Code Then

                                                With (From OrderDtl In AdvantageFramework.Database.Procedures.TVOrderDetail.LoadNonCancelledByOrderNumber(DbContext, ImportAccountPayableMedia.OrderNumber.Value, ImportAccountPayableMedia.Month, ImportAccountPayableMedia.Year.Value)
                                                      Where OrderDtl.GrossRate = ImportAccountPayableMedia.MediaGrossRate.Value
                                                      Select OrderDtl)

                                                    If .Count = 1 Then

                                                        ImportAccountPayableMedia.OrderLineNumber = .FirstOrDefault.LineNumber

                                                    End If

                                                End With

                                            End If

                                        End If

                                        If ImportAccountPayableMedia.Length.HasValue = False Then

                                            ImportAccountPayableMedia.Length = CInt(BroadcastDetailRecord.Type)

                                        End If

                                        ImportAccountPayableMedia.MediaNetAmount = FormatNumber(ImportAccountPayableMedia.ImportAccountPayableBroadcastDetails.Sum(Function(d) d.NetRate), 2)

                                    End If

                                ElseIf TypeOf FileRecord Is AdvantageFramework.Importing.Classes.Broadcast4A.ScheduleCommentRecord Then

                                    ScheduleCommentRecord = DirectCast(FileRecord, AdvantageFramework.Importing.Classes.Broadcast4A.ScheduleCommentRecord)

                                    ImportAccountPayableMedia.Comment = ScheduleCommentRecord.Comment

                                ElseIf TypeOf FileRecord Is AdvantageFramework.Importing.Classes.Broadcast4A.InvoiceTotalRecord Then

                                    InvoiceTotalRecord = DirectCast(FileRecord, AdvantageFramework.Importing.Classes.Broadcast4A.InvoiceTotalRecord)

                                    If ImportAccountPayable.Is4AsCommissionOnly Then

                                        For Each ImportAccountPayableMedia In ImportAccountPayable.ImportAccountPayableMedias

                                            ImportAccountPayableMedia.MediaNetAmount = 0

                                        Next

                                        ImportAccountPayable.InvoiceTotalTax = 0
                                        ImportAccountPayable.InvoiceTotalNet = 0

                                    Else

                                        ImportAccountPayable.InvoiceTotalTax = InvoiceTotalRecord.LocalTax.GetValueOrDefault(0) + InvoiceTotalRecord.StateTax.GetValueOrDefault(0)

                                        If InvoiceTotalRecord.AgencyCommission.GetValueOrDefault(0) = 0 Then 'reset net to be gross in this case

                                            For Each ImportAccountPayableMedia In ImportAccountPayable.ImportAccountPayableMedias

                                                ImportAccountPayableMedia.MediaNetRate = ImportAccountPayableMedia.MediaGrossRate

                                                For Each ImportAccountPayableBroadcastDetail In ImportAccountPayableMedia.ImportAccountPayableBroadcastDetails

                                                    ImportAccountPayableBroadcastDetail.NetRate = ImportAccountPayableBroadcastDetail.GrossRate

                                                Next

                                                ImportAccountPayableMedia.MediaNetAmount = FormatNumber(ImportAccountPayableMedia.ImportAccountPayableBroadcastDetails.Sum(Function(d) d.NetRate), 2)

                                            Next

                                            ImportAccountPayable.InvoiceTotalNet = FormatNumber(ImportAccountPayable.ImportAccountPayableMedias.Sum(Function(E) E.MediaNetAmount), 2)

                                        Else

                                            ImportAccountPayable.InvoiceTotalNet = FormatNumber(ImportAccountPayable.ImportAccountPayableMedias.Sum(Function(E) E.MediaNetAmount), 2) 'InvoiceTotalRecord.NetDue.GetValueOrDefault(0)

                                        End If

                                        ImportAccountPayable.StateTaxAmount = InvoiceTotalRecord.StateTax
                                        ImportAccountPayable.CityTaxAmount = InvoiceTotalRecord.LocalTax

                                        'If Not String.IsNullOrWhiteSpace(ImportAccountPayable.VendorCode) Then

                                        '    If Vendors.Where(Function(V) V.Code = ImportAccountPayable.VendorCode AndAlso V.OfficeCode IsNot Nothing).Count = 1 Then

                                        '        OfficeCode = Vendors.Where(Function(V) V.Code = ImportAccountPayable.VendorCode).First.OfficeCode

                                        '        Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, OfficeCode)

                                        '        If Office IsNot Nothing Then

                                        '            ImportAccountPayable.StateTaxGLAccount = Office.StateTaxGLACode
                                        '            ImportAccountPayable.CityTaxGLAccount = Office.CityTaxGLACode

                                        '        End If

                                        '    End If

                                        'End If

                                    End If

                                End If

                            End If

                        End If

                        FileLineCounter += 1
                        RaiseEvent ImportingProgressUpdateEvent(FileLineCounter)

                    Next

                    For Each IAP In ImportAccountPayableList

                        RemoveImportAccountPayableMedias = New Generic.List(Of AdvantageFramework.Database.Entities.ImportAccountPayableMedia)

                        For Each IAPM In IAP.ImportAccountPayableMedias

                            If IAPM.ImportAccountPayableBroadcastDetails Is Nothing OrElse IAPM.ImportAccountPayableBroadcastDetails.Count = 0 Then

                                RemoveImportAccountPayableMedias.Add(IAPM)

                            Else

                                IAPM.MediaQuantity = IAPM.ImportAccountPayableBroadcastDetails.Count

                            End If

                        Next

                        For Each IAPM In RemoveImportAccountPayableMedias

                            If IAP.ImportAccountPayableMedias.Contains(IAPM) Then

                                IAP.ImportAccountPayableMedias.Remove(IAPM)

                            End If

                            Try

                                DbContext.ImportAccountPayableMedias.Remove(IAPM)

                            Catch ex As Exception

                            End Try

                            IAPM.Daypart = Nothing
                            IAPM.ImportAccountPayable = Nothing

                        Next

                        RemoveImportAccountPayableMedias = Nothing

                    Next

                    DbContext.SaveChanges()

                    If Not String.IsNullOrWhiteSpace(InvoicePDF) Then

                        Try

                            FileInfo = New IO.FileInfo(InvoicePDF)

                        Catch ex As Exception

                        End Try

                        If EventLog IsNot Nothing Then

                            EventLog.WriteEntry("Adding Invoice PDF to Document Repository --> " & FileInfo.Name)

                        End If

                        Document = New Database.Entities.Document

                        Document.Description = String.Format("{0} - {1} - Inv #: {2} - {3:d}", ImportAccountPayable.VendorCode, ImportAccountPayable.VendorName, ImportAccountPayable.InvoiceNumber, ImportAccountPayable.InvoiceDate)
                        Document.Keywords = "Invoice"

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        If AdvantageFramework.FileSystem.Add(Agency, InvoicePDF, Document.Description, Document.Keywords, DbContext.UserCode, "", "", FileSystem.Methods.DocumentSource.DocumentUpload, "", Nothing, Document.FileSystemFileName, EventLog) Then

                            If FileInfo IsNot Nothing Then

                                Document.DbContext = DbContext
                                Document.FileName = FileInfo.Name
                                Document.MIMEType = AdvantageFramework.FileSystem.GetMIMEType(FileInfo)
                                'Document.FileSystemFileName = AdvantageFramework.FileSystem.GetFileName(Document.FileSystemFileName)
                                Document.FileSize = FileInfo.Length
                                Document.DocumentTypeID = 3
                                Document.IsPrivate = 0
                                Document.UploadedDate = Now
                                Document.UserCode = DbContext.UserCode

                                If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document) Then

                                    ImportDocument = New Database.Entities.ImportDocument

                                    ImportDocument.DataContext = DataContext
                                    ImportDocument.ImportID = ImportAccountPayable.ID
                                    ImportDocument.ImportTemplateID = ImportAccountPayable.ImportTemplateID
                                    ImportDocument.DocumentID = Document.ID

                                    AdvantageFramework.Database.Procedures.ImportDocument.Insert(DataContext, ImportDocument)

                                End If

                            End If

                        Else

                            If EventLog IsNot Nothing Then

                                EventLog.WriteEntry("Failed adding Invoice PDF to document repository --> " & FileInfo.Name)

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                FileImported = False
            Finally
                ImportBroadcast4AStaging = FileImported
            End Try

        End Function
        Public Function GetBroadcast4aRecordFromFileLine(ByVal DbContet As AdvantageFramework.Database.DbContext, ByVal FileLine As String(), AutoTrimOverflowData As Boolean) As Object

            'objects
            Dim Entity As Object = Nothing
            Dim PropertyDescriptors As System.ComponentModel.PropertyDescriptorCollection = Nothing

            Try

                Select Case FileLine(0).ToString 'Record Code

                    Case "22"

                        Entity = New AdvantageFramework.Importing.Classes.Broadcast4A.StationRecord

                    Case "23"

                        Entity = New AdvantageFramework.Importing.Classes.Broadcast4A.PayeeRecord

                    Case "31"

                        Entity = New AdvantageFramework.Importing.Classes.Broadcast4A.InvoiceHeaderRecord

                    Case "32"

                        Entity = New AdvantageFramework.Importing.Classes.Broadcast4A.InvoiceCommentTopRecord

                    Case "24"

                        Entity = New AdvantageFramework.Importing.Classes.Broadcast4A.StandardCommentTopRecord

                    Case "25"

                        Entity = New AdvantageFramework.Importing.Classes.Broadcast4A.StandardCommentBottomRecord

                    Case "41"

                        Entity = New AdvantageFramework.Importing.Classes.Broadcast4A.ScheduleLineRecord

                    Case "42"

                        Entity = New AdvantageFramework.Importing.Classes.Broadcast4A.ScheduleCommentRecord

                    Case "51"

                        Entity = New AdvantageFramework.Importing.Classes.Broadcast4A.BroadcastDetailRecord

                    Case "52"

                        Entity = New AdvantageFramework.Importing.Classes.Broadcast4A.ReconciliationRemarksRecord

                    Case "33"

                        Entity = New AdvantageFramework.Importing.Classes.Broadcast4A.InvoiceCommentBottomRecord

                    Case "34"

                        Entity = New AdvantageFramework.Importing.Classes.Broadcast4A.InvoiceTotalRecord

                    Case "12"

                        Entity = New AdvantageFramework.Importing.Classes.Broadcast4A.TransmissionTotalRecord

                End Select

                If Entity IsNot Nothing Then

                    PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Entity)

                    If TypeOf Entity Is AdvantageFramework.Importing.Classes.Broadcast4A.StationRecord Then

                        With DirectCast(Entity, AdvantageFramework.Importing.Classes.Broadcast4A.StationRecord)

                            .CallLetters = ScrubString(GetValueFromFileLine(FileLine, 1), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.StationRecord.Properties.CallLetters, PropertyDescriptors("CallLetters"))
                            .MediaType = ScrubString(GetValueFromFileLine(FileLine, 2), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.StationRecord.Properties.MediaType, PropertyDescriptors("MediaType"))
                            .Band = ScrubString(GetValueFromFileLine(FileLine, 3), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.StationRecord.Properties.Band, PropertyDescriptors("Band"))
                            .Name = ScrubString(GetValueFromFileLine(FileLine, 4), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.StationRecord.Properties.Name, PropertyDescriptors("Name"))
                            .AddressLine1 = ScrubString(GetValueFromFileLine(FileLine, 5), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.StationRecord.Properties.AddressLine1, PropertyDescriptors("AddressLine1"))
                            .AddressLine2 = ScrubString(GetValueFromFileLine(FileLine, 6), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.StationRecord.Properties.AddressLine2, PropertyDescriptors("AddressLine2"))
                            .AddressLine3 = ScrubString(GetValueFromFileLine(FileLine, 7), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.StationRecord.Properties.AddressLine3, PropertyDescriptors("AddressLine3"))
                            .AddressLine4 = ScrubString(GetValueFromFileLine(FileLine, 8), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.StationRecord.Properties.AddressLine4, PropertyDescriptors("AddressLine4"))
                            .ComputerSystem = ScrubString(GetValueFromFileLine(FileLine, 9), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.StationRecord.Properties.ComputerSystem, PropertyDescriptors("ComputerSystem"))
                            .GSTRegistrationNumber = ScrubString(GetValueFromFileLine(FileLine, 10), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.StationRecord.Properties.GSTRegistrationNumber, PropertyDescriptors("GSTRegistrationNumber"))
                            .QSTRegistrationNumber = ScrubString(GetValueFromFileLine(FileLine, 11), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.StationRecord.Properties.QSTRegistrationNumber, PropertyDescriptors("QSTRegistrationNumber"))

                        End With

                    ElseIf TypeOf Entity Is AdvantageFramework.Importing.Classes.Broadcast4A.PayeeRecord Then

                        With DirectCast(Entity, AdvantageFramework.Importing.Classes.Broadcast4A.PayeeRecord)

                            .Name = ScrubString(GetValueFromFileLine(FileLine, 1), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.PayeeRecord.Properties.Name, PropertyDescriptors("Name"))
                            .AddressLine1 = ScrubString(GetValueFromFileLine(FileLine, 2), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.PayeeRecord.Properties.AddressLine1, PropertyDescriptors("QSTRegistrationNumber"))
                            .AddressLine2 = ScrubString(GetValueFromFileLine(FileLine, 3), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.PayeeRecord.Properties.AddressLine2, PropertyDescriptors("AddressLine2"))
                            .AddressLine3 = ScrubString(GetValueFromFileLine(FileLine, 4), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.PayeeRecord.Properties.AddressLine3, PropertyDescriptors("AddressLine3"))
                            .AddressLine4 = ScrubString(GetValueFromFileLine(FileLine, 5), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.PayeeRecord.Properties.AddressLine4, PropertyDescriptors("AddressLine4"))

                        End With

                    ElseIf TypeOf Entity Is AdvantageFramework.Importing.Classes.Broadcast4A.InvoiceHeaderRecord Then

                        With DirectCast(Entity, AdvantageFramework.Importing.Classes.Broadcast4A.InvoiceHeaderRecord)

                            .Representative = ScrubString(GetValueFromFileLine(FileLine, 1), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.Representative, PropertyDescriptors("Representative"))
                            .Salesperson = ScrubString(GetValueFromFileLine(FileLine, 2), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.Salesperson, PropertyDescriptors("Salesperson"))
                            .AdvertiserName = ScrubString(GetValueFromFileLine(FileLine, 3), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.AdvertiserName, PropertyDescriptors("AdvertiserName"))
                            .ProductName = ScrubString(GetValueFromFileLine(FileLine, 4), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.ProductName, PropertyDescriptors("ProductName"))
                            .InvoiceDate = ParseBroadcast4aDate(GetValueFromFileLine(FileLine, 5))
                            .OrderType = ScrubString(GetValueFromFileLine(FileLine, 6), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.OrderType, PropertyDescriptors("OrderType"))
                            .AgencyEstimateCode = ScrubString(GetValueFromFileLine(FileLine, 7), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.AgencyEstimateCode, PropertyDescriptors("AgencyEstimateCode"))
                            .Number = ScrubString(GetValueFromFileLine(FileLine, 8), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.Number, PropertyDescriptors("Number"))
                            .BroadcastMonth = ScrubString(GetValueFromFileLine(FileLine, 9), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.BroadcastMonth, PropertyDescriptors("BroadcastMonth"))
                            .PeriodStartDate = ParseBroadcast4aDate(GetValueFromFileLine(FileLine, 10))
                            .PeriodEndDate = ParseBroadcast4aDate(GetValueFromFileLine(FileLine, 11))
                            .ScheduleStartDate = ParseBroadcast4aDate(GetValueFromFileLine(FileLine, 12))
                            .ScheduleEndDate = ParseBroadcast4aDate(GetValueFromFileLine(FileLine, 13))
                            .ContractStartDate = ParseBroadcast4aDate(GetValueFromFileLine(FileLine, 14))
                            .ContractEndDate = ParseBroadcast4aDate(GetValueFromFileLine(FileLine, 15))
                            .BillingInstructions = ScrubString(GetValueFromFileLine(FileLine, 16), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.BillingInstructions, PropertyDescriptors("BillingInstructions"))
                            .RateCardNumber = ScrubString(GetValueFromFileLine(FileLine, 17), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.RateCardNumber, PropertyDescriptors("RateCardNumber"))
                            .AgencyCommissionFlag = ScrubString(GetValueFromFileLine(FileLine, 18), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.AgencyCommissionFlag, PropertyDescriptors("AgencyCommissionFlag"))
                            .SalesTaxPercent = ScrubDecimal(GetValueFromFileLine(FileLine, 19), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.SalesTaxPercent, PropertyDescriptors("SalesTaxPercent"))
                            .AudiencePercent = ScrubDecimal(GetValueFromFileLine(FileLine, 20), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.AudiencePercent, PropertyDescriptors("AudiencePercent"))
                            .RepOrderNumber = ScrubString(GetValueFromFileLine(FileLine, 21), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.RepOrderNumber, PropertyDescriptors("RepOrderNumber"))
                            .StationOrderNumber = ScrubString(GetValueFromFileLine(FileLine, 22), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.StationOrderNumber, PropertyDescriptors("StationOrderNumber"))
                            .StationAdvertiserCode = ScrubString(GetValueFromFileLine(FileLine, 23), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.StationAdvertiserCode, PropertyDescriptors("StationAdvertiserCode"))
                            .AgencyAdvertiserCode = ScrubString(GetValueFromFileLine(FileLine, 24), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.AgencyAdvertiserCode, PropertyDescriptors("AgencyAdvertiserCode"))
                            .StationProductCode = ScrubString(GetValueFromFileLine(FileLine, 25), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.StationProductCode, PropertyDescriptors("StationProductCode"))
                            .AgencyProductCode = ScrubString(GetValueFromFileLine(FileLine, 26), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.AgencyProductCode, PropertyDescriptors("AgencyProductCode"))
                            .StationContact = ScrubString(GetValueFromFileLine(FileLine, 27), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.StationContact, PropertyDescriptors("StationContact"))
                            .AgencyContact = ScrubString(GetValueFromFileLine(FileLine, 28), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.AgencyContact, PropertyDescriptors("AgencyContact"))
                            .DueDate = ParseBroadcast4aDate(GetValueFromFileLine(FileLine, 29))
                            .NetworkForLocalCable = ScrubString(GetValueFromFileLine(FileLine, 30), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.NetworkForLocalCable, PropertyDescriptors("NetworkForLocalCable"))
                            .TradingPartnerCode = ScrubString(GetValueFromFileLine(FileLine, 31), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.TradingPartnerCode, PropertyDescriptors("TradingPartnerCode"))
                            .DealNumber = ScrubString(GetValueFromFileLine(FileLine, 32), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.DealNumber, PropertyDescriptors("DealNumber"))
                            .RepID = ScrubString(GetValueFromFileLine(FileLine, 33), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.RepID, PropertyDescriptors("RepID"))
                            .PackageCode = ScrubString(GetValueFromFileLine(FileLine, 34), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.PackageCode, PropertyDescriptors("PackageCode"))
                            .ReferenceInvoiceNumber = ScrubString(GetValueFromFileLine(FileLine, 35), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.ReferenceInvoiceNumber, PropertyDescriptors("ReferenceInvoiceNumber"))
                            .ReferenceInvoiceCode = ScrubString(GetValueFromFileLine(FileLine, 36), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.ReferenceInvoiceCode, PropertyDescriptors("ReferenceInvoiceCode"))
                            .VersionCode = ScrubString(GetValueFromFileLine(FileLine, 37), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.VersionCode, PropertyDescriptors("VersionCode"))
                            .NationalLocalCode = ScrubString(GetValueFromFileLine(FileLine, 38), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.NationalLocalCode, PropertyDescriptors("NationalLocalCode"))
                            .SpecialPayingRepCode = ScrubString(GetValueFromFileLine(FileLine, 39), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceHeaderRecord.Properties.SpecialPayingRepCode, PropertyDescriptors("SpecialPayingRepCode"))

                        End With

                    ElseIf TypeOf Entity Is AdvantageFramework.Importing.Classes.Broadcast4A.InvoiceCommentTopRecord Then

                        With DirectCast(Entity, AdvantageFramework.Importing.Classes.Broadcast4A.InvoiceCommentTopRecord)

                            .Comment = ScrubString(GetValueFromFileLine(FileLine, 1), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceCommentTopRecord.Properties.Comment, PropertyDescriptors("Comment"))

                        End With

                    ElseIf TypeOf Entity Is AdvantageFramework.Importing.Classes.Broadcast4A.StandardCommentTopRecord Then

                        With DirectCast(Entity, AdvantageFramework.Importing.Classes.Broadcast4A.StandardCommentTopRecord)

                            .Comment = ScrubString(GetValueFromFileLine(FileLine, 1), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.StandardCommentTopRecord.Properties.Comment, PropertyDescriptors("Comment"))

                        End With

                    ElseIf TypeOf Entity Is AdvantageFramework.Importing.Classes.Broadcast4A.StandardCommentBottomRecord Then

                        With DirectCast(Entity, AdvantageFramework.Importing.Classes.Broadcast4A.StandardCommentBottomRecord)

                            .Comment = ScrubString(GetValueFromFileLine(FileLine, 1), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.StandardCommentBottomRecord.Properties.Comment, PropertyDescriptors("Comment"))

                        End With

                    ElseIf TypeOf Entity Is AdvantageFramework.Importing.Classes.Broadcast4A.ScheduleLineRecord Then

                        With DirectCast(Entity, AdvantageFramework.Importing.Classes.Broadcast4A.ScheduleLineRecord)

                            .Number = ScrubString(GetValueFromFileLine(FileLine, 1), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.ScheduleLineRecord.Properties.Number, PropertyDescriptors("Number"))
                            .DaysOfWeek = GetValueFromFileLine(FileLine, 2) ', AutoTrimOverflowData, DbContet, Classes.Broadcast4A.ScheduleLineRecord.Properties.DaysOfWeek, PropertyDescriptors("DaysOfWeek")
                            .StartTime = ParseBroadcast4aTime(GetValueFromFileLine(FileLine, 3))
                            .EndTime = ParseBroadcast4aTime(GetValueFromFileLine(FileLine, 4))
                            .RateDetail = ScrubString(GetValueFromFileLine(FileLine, 5), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.ScheduleLineRecord.Properties.RateDetail, PropertyDescriptors("RateDetail"))
                            .RatePerSpot = ScrubDecimal(GetValueFromFileLine(FileLine, 6), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.ScheduleLineRecord.Properties.RatePerSpot, PropertyDescriptors("RatePerSpot"))
                            .NumberOfSpotsScheduleForLine = ScrubInteger(GetValueFromFileLine(FileLine, 7))
                            .StartDate = ParseBroadcast4aDate(GetValueFromFileLine(FileLine, 8))
                            .EndDate = ParseBroadcast4aDate(GetValueFromFileLine(FileLine, 9))
                            .PlanCode = ScrubString(GetValueFromFileLine(FileLine, 10), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.ScheduleLineRecord.Properties.PlanCode, PropertyDescriptors("PlanCode"))
                            .PackageCode = ScrubString(GetValueFromFileLine(FileLine, 11), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.ScheduleLineRecord.Properties.PackageCode, PropertyDescriptors("PackageCode"))

                            If .RatePerSpot.HasValue Then

                                .RatePerSpot = .RatePerSpot / 100

                            End If

                        End With

                    ElseIf TypeOf Entity Is AdvantageFramework.Importing.Classes.Broadcast4A.ScheduleCommentRecord Then

                        With DirectCast(Entity, AdvantageFramework.Importing.Classes.Broadcast4A.ScheduleCommentRecord)

                            .Comment = ScrubString(GetValueFromFileLine(FileLine, 1), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.ScheduleCommentRecord.Properties.Comment, PropertyDescriptors("Comment"))

                        End With

                    ElseIf TypeOf Entity Is AdvantageFramework.Importing.Classes.Broadcast4A.BroadcastDetailRecord Then

                        With DirectCast(Entity, AdvantageFramework.Importing.Classes.Broadcast4A.BroadcastDetailRecord)

                            .RunCode = ScrubString(GetValueFromFileLine(FileLine, 1), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.BroadcastDetailRecord.Properties.RunCode, PropertyDescriptors("RunCode"))
                            .RunDate = ParseBroadcast4aDate(GetValueFromFileLine(FileLine, 2))
                            .DayOfWeek = ScrubShort(GetValueFromFileLine(FileLine, 3))
                            .TimeOfDay = ParseBroadcast4aTime(GetValueFromFileLine(FileLine, 4))
                            .Type = ScrubShort(GetValueFromFileLine(FileLine, 5))
                            .CopyID = ScrubString(GetValueFromFileLine(FileLine, 6), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.BroadcastDetailRecord.Properties.CopyID, PropertyDescriptors("CopyID"))
                            .Rate = ScrubDecimal(GetValueFromFileLine(FileLine, 7), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.BroadcastDetailRecord.Properties.Rate, PropertyDescriptors("Rate")) / 100
                            .[Class] = ScrubString(GetValueFromFileLine(FileLine, 8), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.BroadcastDetailRecord.Properties.[Class], PropertyDescriptors("Class"))
                            .Piggyback = ScrubInteger(GetValueFromFileLine(FileLine, 9))
                            .MakegoodDate1 = ParseBroadcast4aDate(GetValueFromFileLine(FileLine, 10))
                            .MakegoodDate2 = ParseBroadcast4aDate(GetValueFromFileLine(FileLine, 11))
                            .MakegoodTime1 = ScrubString(GetValueFromFileLine(FileLine, 12), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.BroadcastDetailRecord.Properties.MakegoodTime1, PropertyDescriptors("MakegoodTime1"))
                            .MakegoodTime2 = ScrubString(GetValueFromFileLine(FileLine, 13), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.BroadcastDetailRecord.Properties.MakegoodTime2, PropertyDescriptors("MakegoodTime2"))
                            .MakegoodLineNumber = ScrubString(GetValueFromFileLine(FileLine, 14), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.BroadcastDetailRecord.Properties.MakegoodLineNumber, PropertyDescriptors("MakegoodLineNumber"))
                            .AdjustmentDr = ScrubString(GetValueFromFileLine(FileLine, 15), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.BroadcastDetailRecord.Properties.AdjustmentDr, PropertyDescriptors("AdjustmentDr"))
                            .AdjustmentCr = ScrubString(GetValueFromFileLine(FileLine, 16), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.BroadcastDetailRecord.Properties.AdjustmentCr, PropertyDescriptors("AdjustmentCr"))
                            .ProgramDescription = ScrubString(GetValueFromFileLine(FileLine, 17), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.BroadcastDetailRecord.Properties.ProgramDescription, PropertyDescriptors("ProgramDescription"))
                            .BillboardIndicator = ScrubString(GetValueFromFileLine(FileLine, 18), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.BroadcastDetailRecord.Properties.BillboardIndicator, PropertyDescriptors("BillboardIndicator"))
                            .Length = ScrubInteger(GetValueFromFileLine(FileLine, 19))
                            .VideoCopyID = ScrubString(GetValueFromFileLine(FileLine, 20), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.BroadcastDetailRecord.Properties.VideoCopyID, PropertyDescriptors("VideoCopyID"))
                            .AudioCopyID = ScrubString(GetValueFromFileLine(FileLine, 21), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.BroadcastDetailRecord.Properties.AudioCopyID, PropertyDescriptors("AudioCopyID"))
                            .SerialNumber = ScrubString(GetValueFromFileLine(FileLine, 22), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.BroadcastDetailRecord.Properties.SerialNumber, PropertyDescriptors("SerialNumber"))
                            .NetworkForLocalCable = ScrubString(GetValueFromFileLine(FileLine, 23), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.BroadcastDetailRecord.Properties.NetworkForLocalCable, PropertyDescriptors("NetworkForLocalCable"))
                            .NetworkIntegrationCost = ScrubString(GetValueFromFileLine(FileLine, 24), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.BroadcastDetailRecord.Properties.NetworkIntegrationCost, PropertyDescriptors("NetworkIntegrationCost"))
                            .PackageForNetworkOnly = ScrubInteger(GetValueFromFileLine(FileLine, 25))

                        End With

                    ElseIf TypeOf Entity Is AdvantageFramework.Importing.Classes.Broadcast4A.ReconciliationRemarksRecord Then

                        With DirectCast(Entity, AdvantageFramework.Importing.Classes.Broadcast4A.ReconciliationRemarksRecord)

                            .Remarks = ScrubString(GetValueFromFileLine(FileLine, 1), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.ReconciliationRemarksRecord.Properties.Remarks, PropertyDescriptors("Remarks"))

                        End With

                    ElseIf TypeOf Entity Is AdvantageFramework.Importing.Classes.Broadcast4A.InvoiceCommentBottomRecord Then

                        With DirectCast(Entity, AdvantageFramework.Importing.Classes.Broadcast4A.InvoiceCommentBottomRecord)

                            .Comment = ScrubString(GetValueFromFileLine(FileLine, 1), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceCommentBottomRecord.Properties.Comment, PropertyDescriptors("Comment"))

                        End With

                    ElseIf TypeOf Entity Is AdvantageFramework.Importing.Classes.Broadcast4A.InvoiceTotalRecord Then

                        With DirectCast(Entity, AdvantageFramework.Importing.Classes.Broadcast4A.InvoiceTotalRecord)

                            .ConfirmedCost = ScrubString(GetValueFromFileLine(FileLine, 1), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceTotalRecord.Properties.ConfirmedCost, PropertyDescriptors("ConfirmedCost"))
                            .ActualGrossBilling = ScrubDecimal(GetValueFromFileLine(FileLine, 2), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceTotalRecord.Properties.ActualGrossBilling, PropertyDescriptors("ActualGrossBilling"))
                            .AgencyCommission = ScrubDecimal(GetValueFromFileLine(FileLine, 3), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceTotalRecord.Properties.AgencyCommission, PropertyDescriptors("AgencyCommission"))
                            .NetDue = ScrubDecimal(GetValueFromFileLine(FileLine, 4), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceTotalRecord.Properties.NetDue, PropertyDescriptors("NetDue"))
                            .ReconciliationDr = ScrubString(GetValueFromFileLine(FileLine, 5), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceTotalRecord.Properties.ReconciliationDr, PropertyDescriptors("ReconciliationDr"))
                            .ReconciliationCr = ScrubString(GetValueFromFileLine(FileLine, 6), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceTotalRecord.Properties.ReconciliationCr, PropertyDescriptors("ReconciliationCr"))
                            .ReconciliationTotal = ScrubString(GetValueFromFileLine(FileLine, 7), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceTotalRecord.Properties.ReconciliationTotal, PropertyDescriptors("ReconciliationTotal"))
                            .StateTax = ScrubDecimal(GetValueFromFileLine(FileLine, 8), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceTotalRecord.Properties.StateTax, PropertyDescriptors("StateTax"))
                            .LocalTax = ScrubDecimal(GetValueFromFileLine(FileLine, 9), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceTotalRecord.Properties.LocalTax, PropertyDescriptors("LocalTax"))
                            .PriorGrossBalance = ScrubString(GetValueFromFileLine(FileLine, 10), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceTotalRecord.Properties.PriorGrossBalance, PropertyDescriptors("PriorGrossBalance"))
                            .PriorNetBalance = ScrubString(GetValueFromFileLine(FileLine, 11), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceTotalRecord.Properties.PriorNetBalance, PropertyDescriptors("PriorNetBalance"))
                            .NumberOfSpots = ScrubString(GetValueFromFileLine(FileLine, 12), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceTotalRecord.Properties.NumberOfSpots, PropertyDescriptors("NumberOfSpots"))
                            .GST = ScrubString(GetValueFromFileLine(FileLine, 13), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceTotalRecord.Properties.GST, PropertyDescriptors("GST"))
                            .PST = ScrubString(GetValueFromFileLine(FileLine, 14), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.InvoiceTotalRecord.Properties.PST, PropertyDescriptors("PST"))

                            If .ActualGrossBilling.HasValue Then

                                .ActualGrossBilling = .ActualGrossBilling / 100

                            End If

                            If .AgencyCommission.HasValue Then

                                .AgencyCommission = .AgencyCommission / 100

                            End If

                            'If .NetDue.HasValue Then

                            '    .NetDue = .NetDue / 100

                            'End If

                            If .StateTax.HasValue Then

                                .StateTax = .StateTax / 100

                            End If

                            If .LocalTax.HasValue Then

                                .LocalTax = .LocalTax / 100

                            End If

                        End With

                    ElseIf TypeOf Entity Is AdvantageFramework.Importing.Classes.Broadcast4A.TransmissionTotalRecord Then

                        With DirectCast(Entity, AdvantageFramework.Importing.Classes.Broadcast4A.TransmissionTotalRecord)

                            .TransmissionTotalNumberOfInvoices = ScrubString(GetValueFromFileLine(FileLine, 1), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.TransmissionTotalRecord.Properties.TransmissionTotalNumberOfInvoices, PropertyDescriptors("TransmissionTotalNumberOfInvoices"))
                            .TransmissionTotalGrossTotal = ScrubString(GetValueFromFileLine(FileLine, 2), AutoTrimOverflowData, DbContet, Classes.Broadcast4A.TransmissionTotalRecord.Properties.TransmissionTotalGrossTotal, PropertyDescriptors("TransmissionTotalGrossTotal"))

                        End With

                    End If

                End If

            Catch ex As Exception
                Entity = Nothing
            Finally
                GetBroadcast4aRecordFromFileLine = Entity
            End Try

        End Function
        Private Function ParseBroadcast4aDate(ByVal Value As String) As Date?

            If Not String.IsNullOrWhiteSpace(Value) Then

                Return DateTime.ParseExact(Value, "yyMMdd", Globalization.CultureInfo.InvariantCulture)

            Else

                Return Nothing

            End If

        End Function
        Private Function ParseBroadcast4aTime(ByVal Value As String) As TimeSpan?

            If Not String.IsNullOrWhiteSpace(Value) Then

                If IsNumeric(Value) AndAlso CInt(Value) >= 2400 Then

                    Return TimeSpan.ParseExact((CInt(Value) - 2400).ToString.PadLeft(4, "0"), "hhmm", Globalization.CultureInfo.InvariantCulture)

                Else

                    Return TimeSpan.ParseExact(Value, "hhmm", Globalization.CultureInfo.InvariantCulture)

                End If

            Else

                Return Nothing

            End If

        End Function
        Private Function GetVendorByCallLetterHierarchy(Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext, ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                        CallLetters As String, Band As String, Name As String) As AdvantageFramework.Database.Entities.Vendor

            'objects
            Dim Vendors As Generic.List(Of AdvantageFramework.Database.Entities.Vendor) = Nothing
            Dim VendorCode As String = Nothing
            Dim VendorName As String = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim NCCTVSyscode As AdvantageFramework.Nielsen.Database.Classes.NCCTVSyscode = Nothing
            Dim VendorCodeLookup As String = Nothing
            Dim VendorCrossReference As AdvantageFramework.Database.Entities.VendorCrossReference = Nothing

            Vendors = AdvantageFramework.Database.Procedures.Vendor.Load(DbContext).ToList

            VendorCode = String.Concat(CallLetters, Band)
            VendorName = Name

            '1 vendor mapping
            If Vendor Is Nothing AndAlso ImportTemplate.RecordSourceID.HasValue Then

                Try

                    VendorCrossReference = (From VCR In AdvantageFramework.Database.Procedures.VendorCrossReference.LoadByRecordSourceID(DbContext, ImportTemplate.RecordSourceID.Value)
                                            Where VCR.SourceVendorCode.ToUpper = VendorCode.ToUpper
                                            Select VCR).SingleOrDefault

                Catch ex As Exception
                    VendorCrossReference = Nothing
                End Try

                If VendorCrossReference Is Nothing Then

                    Try

                        VendorCrossReference = (From VCR In AdvantageFramework.Database.Procedures.VendorCrossReference.LoadByRecordSourceID(DbContext, ImportTemplate.RecordSourceID.Value)
                                                Where VCR.SourceVendorCode.ToUpper = CallLetters.ToUpper
                                                Select VCR).SingleOrDefault

                    Catch ex As Exception
                        VendorCrossReference = Nothing
                    End Try

                End If

                If VendorCrossReference IsNot Nothing Then

                    Vendor = Vendors.Where(Function(v) v.Code.ToUpper = VendorCrossReference.VendorCode.ToUpper).SingleOrDefault

                End If

            End If

            '2 vendor cross reference
            If Vendor Is Nothing Then

                If Vendors.Where(Function(v) Not String.IsNullOrWhiteSpace(v.VendorCodeCrossReference) AndAlso v.VendorCodeCrossReference.ToUpper = VendorCode.Trim.ToUpper).Count = 1 Then

                    Vendor = Vendors.Where(Function(v) Not String.IsNullOrWhiteSpace(v.VendorCodeCrossReference) AndAlso v.VendorCodeCrossReference.ToUpper = VendorCode.Trim.ToUpper).SingleOrDefault

                ElseIf Vendors.Where(Function(v) Not String.IsNullOrWhiteSpace(v.VendorCodeCrossReference) AndAlso v.VendorCodeCrossReference.ToUpper = CallLetters.ToUpper).Count = 1 Then

                    Vendor = Vendors.Where(Function(v) Not String.IsNullOrWhiteSpace(v.VendorCodeCrossReference) AndAlso v.VendorCodeCrossReference.ToUpper = CallLetters.ToUpper).SingleOrDefault

                End If

            End If

            '3 call letters and band
            If Vendor Is Nothing Then

                If String.IsNullOrWhiteSpace(Band) Then

                    If (From Entity In Vendors
                        Where Entity.CallLetters IsNot Nothing AndAlso
                              Entity.CallLetters.ToUpper = CallLetters.ToUpper
                        Select Entity).Count = 1 Then

                        Vendor = (From Entity In Vendors
                                  Where Entity.CallLetters IsNot Nothing AndAlso
                                        Entity.CallLetters.ToUpper = CallLetters.ToUpper
                                  Select Entity).SingleOrDefault

                    End If

                Else

                    If (From Entity In Vendors
                        Where Entity.CallLetters IsNot Nothing AndAlso
                              Entity.CallLetters.ToUpper = CallLetters.ToUpper AndAlso
                              Entity.Band.ToUpper = Band.ToUpper
                        Select Entity).Count = 1 Then

                        Vendor = (From Entity In Vendors
                                  Where Entity.CallLetters IsNot Nothing AndAlso
                                        Entity.CallLetters.ToUpper = CallLetters.ToUpper AndAlso
                                        Entity.Band.ToUpper = Band.ToUpper
                                  Select Entity).SingleOrDefault

                    End If

                End If

            End If

            '4 SYSCODE
            If Vendor Is Nothing AndAlso IsNumeric(CallLetters) Then

                If Session.IsNielsenSetup Then

                    Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                        If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                            NCCTVSyscode = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NCCTVSyscode.GetSyscodesByMarketHosted(NielsenDbContext, Session.NielsenClientCodeForHosted, Nothing)
                                            Where Entity.Syscode = CallLetters
                                            Select Entity).SingleOrDefault

                        Else

                            NCCTVSyscode = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NCCTVSyscode.GetSyscodesByMarket(NielsenDbContext, Nothing)
                                            Where Entity.Syscode = CallLetters
                                            Select Entity).SingleOrDefault

                        End If

                        If NCCTVSyscode IsNot Nothing Then

                            If (From Entity In Vendors
                                Where Entity.NCCTVSyscodeID = NCCTVSyscode.ID
                                Select Entity).Count = 1 Then

                                Vendor = (From Entity In Vendors
                                          Where Entity.NCCTVSyscodeID = NCCTVSyscode.ID
                                          Select Entity).Single

                                If Vendor IsNot Nothing Then

                                    'VendorCode = Vendor.Code
                                    'VendorName = Vendor.Name

                                Else

                                    NCCTVSyscode = Nothing

                                End If

                            Else

                                NCCTVSyscode = Nothing

                            End If

                        End If

                    End Using

                End If

                If NCCTVSyscode Is Nothing Then

                    VendorCodeLookup = CallLetters.PadLeft(4, "0")

                    Vendor = (From Entity In Vendors
                              Where Entity.Code = VendorCodeLookup
                              Select Entity).SingleOrDefault

                End If

            End If

            '5 vendor code
            If Vendor Is Nothing AndAlso String.IsNullOrWhiteSpace(VendorCode) = False Then

                If Vendors.Where(Function(v) v.Code.ToUpper = VendorCode.Trim.ToUpper).Any Then

                    Vendor = Vendors.Where(Function(v) v.Code.ToUpper = VendorCode.Trim.ToUpper).SingleOrDefault

                ElseIf Vendors.Where(Function(v) v.Code.ToUpper = CallLetters.Trim.ToUpper).Count = 1 Then

                    Vendor = Vendors.Where(Function(v) v.Code.ToUpper = CallLetters.Trim.ToUpper).SingleOrDefault

                End If

            End If

            '6 vendor name
            If Vendor Is Nothing AndAlso String.IsNullOrWhiteSpace(VendorName) = False Then

                If Vendors.Where(Function(v) v.Name.ToUpper = VendorName.Trim.ToUpper).Count = 1 Then

                    Vendor = Vendors.Where(Function(v) v.Name.ToUpper = VendorName.Trim.ToUpper).SingleOrDefault

                ElseIf Vendors.Where(Function(v) v.Name.ToUpper.StartsWith(VendorName.Trim.ToUpper)).Count = 1 Then

                    Vendor = Vendors.Where(Function(v) v.Name.ToUpper.StartsWith(VendorName.Trim.ToUpper)).SingleOrDefault

                End If

            End If

            GetVendorByCallLetterHierarchy = Vendor

        End Function

#End Region

#Region "   Employee Hours "

        Private Function CreateImportEmployeeHoursStaging(Session As AdvantageFramework.Security.Session,
                                                          DbContext As AdvantageFramework.Database.DbContext,
                                                          DataContext As AdvantageFramework.Database.DataContext,
                                                          ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                          ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail),
                                                          FileLineData As Object, BatchName As String,
                                                          AutoTrimOverFlowData As Boolean, DataTable As System.Data.DataTable,
                                                          FileType As AdvantageFramework.Importing.FileTypes,
                                                          ImportTemplateExcludeList As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateExclude),
                                                          PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor))

            'objects
            Dim Created As Boolean = True
            Dim ImportEmployeeHoursStaging As AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging = Nothing
            Dim Duration As String = Nothing
            Dim FirstSpace As Integer = 0

            Try

                ImportEmployeeHoursStaging = New AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging

                ImportEmployeeHoursStaging.DbContext = DbContext
                ImportEmployeeHoursStaging.BatchName = BatchName

                CreateEntityFromTemplateDataTable(ImportTemplate, DataTable, FileLineData, ImportEmployeeHoursStaging, AutoTrimOverFlowData)

                If Not RowHasExcludeValues(ImportTemplateExcludeList, PropertyDescriptorsList, ImportEmployeeHoursStaging) Then

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    If AdvantageFramework.Database.Procedures.ImportEmployeeHoursStaging.Insert(DbContext, ImportEmployeeHoursStaging) = False Then

                        Created = False

                        Try

                            DbContext.Entry(ImportEmployeeHoursStaging).State = Entity.EntityState.Deleted

                            DbContext.SaveChanges()

                        Catch ex As Exception

                        End Try

                    End If

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            Catch ex As Exception
                Created = False
            Finally
                CreateImportEmployeeHoursStaging = Created
            End Try

        End Function
        Public Function UpdateEmployeeRecordsFromImport(DataContext As AdvantageFramework.Database.DataContext,
                                                        DbContext As AdvantageFramework.Database.DbContext,
                                                        ImportEmployeeHoursStagings As Generic.List(Of AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging)) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Updated As Boolean = True

            Try

                For Each ImportEmployeeHoursStaging In ImportEmployeeHoursStagings

                    IsValid = True

                    ImportEmployeeHoursStaging.DbContext = DbContext

                    If ImportEmployeeHoursStaging.IsOnHold = False Then

                        ImportEmployeeHoursStaging.ValidateEntity(IsValid)

                        If IsValid Then

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ImportEmployeeHoursStaging.EmployeeCode)

                            If Employee IsNot Nothing Then

                                Employee.VacationHours = ImportEmployeeHoursStaging.VacationHours
                                Employee.VacationDateFrom = ImportEmployeeHoursStaging.VacationDateFrom
                                Employee.VacationDateTo = ImportEmployeeHoursStaging.VacationDateTo

                                Employee.SickHours = ImportEmployeeHoursStaging.SickHours
                                Employee.SickDateFrom = ImportEmployeeHoursStaging.SickDateFrom
                                Employee.SickDateTo = ImportEmployeeHoursStaging.SickDateTo

                                Employee.PersonalHours = ImportEmployeeHoursStaging.PersonalHours
                                Employee.PersonalHoursDateFrom = ImportEmployeeHoursStaging.PersonalHoursDateFrom
                                Employee.PersonalHoursDateTo = ImportEmployeeHoursStaging.PersonalHoursDateTo

                                If AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee) Then

                                    DbContext.Entry(ImportEmployeeHoursStaging).State = Entity.EntityState.Deleted

                                    DbContext.SaveChanges()

                                End If

                            End If

                        Else

                            Updated = False

                        End If

                    End If

                Next

            Catch ex As Exception
                Updated = False
            End Try

            UpdateEmployeeRecordsFromImport = Updated

        End Function

#End Region

#Region "   MediaRFP 4As "

        Private Sub SetDaypartID(DbContext As AdvantageFramework.Database.DbContext, MediaRFPAvailLine As AdvantageFramework.Database.Entities.MediaRFPAvailLine,
                                 DaypartList As Generic.List(Of AdvantageFramework.Database.Entities.Daypart), VendorCode As String)

            'objects
            Dim Daypart As AdvantageFramework.Database.Entities.Daypart = Nothing
            Dim MediaRFPVendorDaypartCrossReference As AdvantageFramework.Database.Entities.MediaRFPVendorDaypartCrossReference = Nothing

            MediaRFPVendorDaypartCrossReference = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPVendorDaypartCrossReference.LoadByVendorCode(DbContext, VendorCode)
                                                   Where Entity.VendorDaypartCode.ToUpper = MediaRFPAvailLine.DaypartName.ToUpper
                                                   Select Entity).FirstOrDefault

            If MediaRFPVendorDaypartCrossReference IsNot Nothing Then

                MediaRFPAvailLine.DaypartID = MediaRFPVendorDaypartCrossReference.DaypartID

            Else

                If MediaRFPAvailLine.DaypartName.ToUpper = "PRIME" Then

                    Daypart = (From DP In DaypartList
                               Where DP.Code = "P"
                               Select DP).SingleOrDefault

                Else

                    Daypart = (From DP In DaypartList
                               Where DP.Code = MediaRFPAvailLine.DaypartName
                               Select DP).SingleOrDefault

                End If

                If Daypart IsNot Nothing Then

                    MediaRFPAvailLine.DaypartID = Daypart.ID

                End If

            End If

        End Sub
        Private Sub SetMarketCode(DbContext As AdvantageFramework.Database.DbContext, MediaRFPDemo As AdvantageFramework.Database.Entities.MediaRFPDemo)

            'objects
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing
            Dim MediaRFPMarketCrossReference As AdvantageFramework.Database.Entities.MediaRFPMarketCrossReference = Nothing

            MediaRFPMarketCrossReference = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPMarketCrossReference.Load(DbContext)
                                            Where Entity.SourceMarketCode.ToUpper = MediaRFPDemo.SourceMarketName.ToUpper
                                            Select Entity).SingleOrDefault

            If MediaRFPMarketCrossReference IsNot Nothing Then

                MediaRFPDemo.MarketCode = MediaRFPMarketCrossReference.MarketCode

            Else

                Market = (From Entity In AdvantageFramework.Database.Procedures.Market.LoadByCountryID(DbContext, AdvantageFramework.DTO.Countries.Canada)
                          Where Entity.Description.ToUpper = MediaRFPDemo.SourceMarketName.ToUpper
                          Select Entity).FirstOrDefault

                If Market IsNot Nothing Then

                    MediaRFPDemo.MarketCode = Market.Code

                End If

            End If

        End Sub

#Region "   NCC "

        Private Function CreateNCCMediaRFPDemos(DbContext As AdvantageFramework.Database.DbContext, XmlNodeList As System.Xml.XmlNodeList, MediaBroadcastWorksheet As AdvantageFramework.Database.Entities.MediaBroadcastWorksheet) As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo)

            'objects
            Dim MediaRFPDemoList As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo) = Nothing
            Dim MediaRFPDemo As AdvantageFramework.DTO.Media.RFP.MediaRFPDemo = Nothing

            MediaRFPDemoList = New Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo)

            For Each XmlElement In XmlNodeList.OfType(Of System.Xml.XmlElement)

                MediaRFPDemo = New AdvantageFramework.DTO.Media.RFP.MediaRFPDemo

                MediaRFPDemo.IDRank = XmlElement.Attributes("demoRank").Value

                MediaRFPDemo.Group = XmlElement.GetElementsByTagName("group").Item(0).InnerText

                If IsNumeric(XmlElement.GetElementsByTagName("ageFrom").Item(0).InnerText) Then

                    MediaRFPDemo.AgeFrom = CShort(XmlElement.GetElementsByTagName("ageFrom").Item(0).InnerText)

                End If

                If IsNumeric(XmlElement.GetElementsByTagName("ageTo").Item(0).InnerText) Then

                    MediaRFPDemo.AgeTo = CShort(XmlElement.GetElementsByTagName("ageTo").Item(0).InnerText)

                End If

                MediaRFPDemo.MediaDemoID = GetMediaDemoID(DbContext, MediaRFPDemo.AgeFrom, MediaRFPDemo.AgeTo, MediaRFPDemo.Group, MediaBroadcastWorksheet.MediaTypeCode, MediaBroadcastWorksheet.RatingsServiceID)

                MediaRFPDemoList.Add(MediaRFPDemo)

            Next

            CreateNCCMediaRFPDemos = MediaRFPDemoList

        End Function
        Private Sub CreateNCCMediaRFPDetailLines(Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext, XmlElementSyscode As System.Xml.XmlElement,
                                                 MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader,
                                                 MediaRFPDemoList As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo), XmlNodeListWeeks As System.Xml.XmlNodeList,
                                                 DaypartList As Generic.List(Of AdvantageFramework.Database.Entities.Daypart), IsComscore As Boolean)

            'objects
            Dim XmlNodeList As System.Xml.XmlNodeList = Nothing
            Dim NextBatchNumber As Short = 0
            'Dim CableNetworkStations As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation) = Nothing
            Dim MediaRFPAvailLine As AdvantageFramework.Database.Entities.MediaRFPAvailLine = Nothing
            Dim DemoValuesXmlNodeList As System.Xml.XmlNodeList = Nothing
            Dim IDRank As String = Nothing
            Dim MediaRFPDemo As AdvantageFramework.Database.Entities.MediaRFPDemo = Nothing
            Dim MediaRFPDemoDTO As AdvantageFramework.DTO.Media.RFP.MediaRFPDemo = Nothing
            Dim WeekNumber As Short = 0
            Dim MediaRFPAvailLineSpot As AdvantageFramework.Database.Entities.MediaRFPAvailLineSpot = Nothing
            Dim XmlNodeListSpots As System.Xml.XmlNodeList = Nothing
            Dim XmlNodeListCodes As System.Xml.XmlNodeList = Nothing
            Dim Rate As Decimal = 0
            Dim UpdateToType As String = Nothing
            Dim ComscoreTVStation As AdvantageFramework.Database.Entities.ComscoreTVStation = Nothing

            XmlNodeList = XmlElementSyscode.GetElementsByTagName("detailLine")

            If (From Entity In AdvantageFramework.Database.Procedures.MediaRFPAvailLine.Load(DbContext)
                Where Entity.MediaRFPHeaderID = MediaRFPHeader.ID
                Select Entity.BatchNumber).Any Then

                NextBatchNumber = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPAvailLine.Load(DbContext)
                                   Where Entity.MediaRFPHeaderID = MediaRFPHeader.ID
                                   Select Entity.BatchNumber).Max + 1

            Else

                NextBatchNumber = 1

            End If

            'If Session.IsNielsenSetup Then

            '    Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

            '        CableNetworkStations = AdvantageFramework.Nielsen.Database.Procedures.NCCTVCablenet.Load(NielsenDbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation(Entity)).ToList

            '    End Using

            '    If CableNetworkStations.Count = 0 Then

            '        CableNetworkStations = AdvantageFramework.Database.Procedures.CableNetworkStation.Load(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation(Entity)).ToList

            '    End If

            'Else

            '    CableNetworkStations = AdvantageFramework.Database.Procedures.CableNetworkStation.Load(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation(Entity)).ToList

            'End If

            For Each XmlElement In XmlNodeList.OfType(Of System.Xml.XmlElement)

                MediaRFPAvailLine = New AdvantageFramework.Database.Entities.MediaRFPAvailLine

                MediaRFPAvailLine.MediaRFPHeaderID = MediaRFPHeader.ID

                If XmlElement.GetElementsByTagName("name").Count > 0 Then

                    MediaRFPAvailLine.NetworkName = XmlElement.GetElementsByTagName("name").Item(0).InnerText

                End If

                If XmlElement.GetElementsByTagName("program").Count = 1 Then

                    MediaRFPAvailLine.Program = System.Web.HttpUtility.HtmlDecode(XmlElement.GetElementsByTagName("program").Item(0).InnerText)

                    If MediaRFPAvailLine.Program.Length > 100 Then

                        MediaRFPAvailLine.Program = Mid(MediaRFPAvailLine.Program, 1, 100)

                    End If

                End If

                If XmlElement.GetElementsByTagName("comment").Count = 1 Then

                    'MediaRFPAvailLine.Comments = System.Web.HttpUtility.HtmlDecode(XmlElement.GetElementsByTagName("comment").Item(0).InnerText)

                    If System.Web.HttpUtility.HtmlDecode(XmlElement.GetElementsByTagName("comment").Item(0).InnerText).StartsWith("TP" & Chr(127)) Then

                        MediaRFPAvailLine.Comments = System.Web.HttpUtility.HtmlDecode(XmlElement.GetElementsByTagName("comment").Item(0).InnerText).Substring(3)

                    Else

                        MediaRFPAvailLine.Comments = System.Web.HttpUtility.HtmlDecode(XmlElement.GetElementsByTagName("comment").Item(0).InnerText)

                    End If

                End If

                MediaRFPAvailLine.DaypartName = XmlElement.GetElementsByTagName("daypartCode").Item(0).InnerText

                SetDaypartID(DbContext, MediaRFPAvailLine, DaypartList, MediaRFPHeader.VendorCode)

                MediaRFPAvailLine.StartTime = XmlElement.GetElementsByTagName("startTime").Item(0).InnerText
                MediaRFPAvailLine.EndTime = XmlElement.GetElementsByTagName("endTime").Item(0).InnerText

                If Not String.IsNullOrWhiteSpace(MediaRFPAvailLine.StartTime) AndAlso MediaRFPAvailLine.StartTime.Length > 1 AndAlso CInt(MediaRFPAvailLine.StartTime.Substring(0, 2)) >= 24 Then

                    MediaRFPAvailLine.StartTime = CInt(MediaRFPAvailLine.StartTime.Substring(0, 2)) - 24 & MediaRFPAvailLine.StartTime.Substring(2)

                End If

                If Not String.IsNullOrWhiteSpace(MediaRFPAvailLine.EndTime) AndAlso MediaRFPAvailLine.EndTime.Length > 1 AndAlso CInt(MediaRFPAvailLine.EndTime.Substring(0, 2)) >= 24 Then

                    MediaRFPAvailLine.EndTime = CInt(MediaRFPAvailLine.EndTime.Substring(0, 2)) - 24 & MediaRFPAvailLine.EndTime.Substring(2)

                End If

                If IsDate(MediaRFPAvailLine.StartTime) Then

                    MediaRFPAvailLine.StartTime = CDate(MediaRFPAvailLine.StartTime).ToString("hh:mm tt")
                    MediaRFPAvailLine.StartHour = CShort(CDate(MediaRFPAvailLine.StartTime).ToString("HHmm"))

                End If

                If IsDate(MediaRFPAvailLine.EndTime) Then

                    MediaRFPAvailLine.EndTime = CDate(MediaRFPAvailLine.EndTime).ToString("hh:mm tt")
                    MediaRFPAvailLine.EndHour = CShort(CDate(MediaRFPAvailLine.EndTime).ToString("HHmm"))

                End If

                MediaRFPAvailLine.Sunday = If(XmlElement.GetElementsByTagName("Sunday").Item(0).InnerText = "Y", True, False)
                MediaRFPAvailLine.Monday = If(XmlElement.GetElementsByTagName("Monday").Item(0).InnerText = "Y", True, False)
                MediaRFPAvailLine.Tuesday = If(XmlElement.GetElementsByTagName("Tuesday").Item(0).InnerText = "Y", True, False)
                MediaRFPAvailLine.Wednesday = If(XmlElement.GetElementsByTagName("Wednesday").Item(0).InnerText = "Y", True, False)
                MediaRFPAvailLine.Thursday = If(XmlElement.GetElementsByTagName("Thursday").Item(0).InnerText = "Y", True, False)
                MediaRFPAvailLine.Friday = If(XmlElement.GetElementsByTagName("Friday").Item(0).InnerText = "Y", True, False)
                MediaRFPAvailLine.Saturday = If(XmlElement.GetElementsByTagName("Saturday").Item(0).InnerText = "Y", True, False)

                MediaRFPAvailLine.SpotLength = AdvantageFramework.StringUtilities.RemoveAllNonNumeric(XmlElement.GetElementsByTagName("length").Item(0).InnerText)
                Rate = XmlElement.GetElementsByTagName("spotCost").Item(0).InnerText

                XmlNodeListSpots = XmlElement.GetElementsByTagName("spot")

                For Each XmlNodeListSpot In XmlNodeListSpots.OfType(Of System.Xml.XmlElement)

                    WeekNumber = XmlNodeListSpot.Item("weekNumber").InnerText

                    For Each XmlElementWeek In XmlNodeListWeeks.OfType(Of System.Xml.XmlElement)

                        If XmlElementWeek.Attributes("number").Value = WeekNumber Then

                            MediaRFPAvailLineSpot = New AdvantageFramework.Database.Entities.MediaRFPAvailLineSpot
                            MediaRFPAvailLineSpot.DbContext = DbContext

                            MediaRFPAvailLineSpot.WeekDate = XmlElementWeek.Attributes("startDate").Value
                            MediaRFPAvailLineSpot.Quantity = XmlNodeListSpot.Item("quantity").InnerText
                            MediaRFPAvailLineSpot.Rate = Rate

                            If MediaRFPAvailLine.StartDate.HasValue = False Then

                                MediaRFPAvailLine.StartDate = XmlElementWeek.Attributes("startDate").Value

                            End If

                            'If WeekNumber = 1 Then

                            '    MediaRFPAvailLine.StartDate = XmlElementWeek.Attributes("startDate").Value

                            'End If

                            MediaRFPAvailLine.EndDate = DateAdd(DateInterval.Day, 6, MediaRFPAvailLineSpot.WeekDate)

                            MediaRFPAvailLine.MediaRFPAvailLineSpots.Add(MediaRFPAvailLineSpot)

                            Exit For

                        End If

                    Next

                Next

                MediaRFPAvailLine.BatchNumber = NextBatchNumber
                MediaRFPAvailLine.Status = AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus.H.ToString

                DemoValuesXmlNodeList = XmlElement.GetElementsByTagName("demoValue")

                If DemoValuesXmlNodeList.Count = 0 AndAlso MediaRFPDemoList.Count > 0 Then

                    MediaRFPDemo = New AdvantageFramework.Database.Entities.MediaRFPDemo
                    MediaRFPDemo.DbContext = DbContext

                    MediaRFPDemo.IDRank = MediaRFPDemoList.FirstOrDefault.IDRank
                    MediaRFPDemo.Type = ""
                    MediaRFPDemo.Group = MediaRFPDemoList.FirstOrDefault.Group
                    MediaRFPDemo.AgeFrom = MediaRFPDemoList.FirstOrDefault.AgeFrom
                    MediaRFPDemo.AgeTo = MediaRFPDemoList.FirstOrDefault.AgeTo
                    MediaRFPDemo.Value = 0

                    MediaRFPAvailLine.MediaRFPDemos.Add(MediaRFPDemo)

                Else

                    For Each DemoXmlElement In DemoValuesXmlNodeList.OfType(Of System.Xml.XmlElement)

                        IDRank = DemoXmlElement.Attributes("demoRank").Value

                        For Each ChildXmlElement In DemoXmlElement.OfType(Of System.Xml.XmlElement)

                            If ChildXmlElement.Attributes IsNot Nothing AndAlso ChildXmlElement.Attributes.Count > 0 Then

                                MediaRFPDemo = New AdvantageFramework.Database.Entities.MediaRFPDemo
                                MediaRFPDemo.DbContext = DbContext

                                MediaRFPDemoDTO = (From Entity In MediaRFPDemoList
                                                   Where Entity.IDRank = IDRank
                                                   Select Entity).FirstOrDefault

                                MediaRFPDemoDTO.Type = ChildXmlElement.Attributes("type").Value

                                If UpdateToType Is Nothing AndAlso Not String.IsNullOrWhiteSpace(MediaRFPDemoDTO.Type) Then

                                    UpdateToType = MediaRFPDemoDTO.Type

                                End If

                                MediaRFPDemoDTO.SaveToEntity(MediaRFPDemo)

                                If MediaRFPDemo.Type.ToUpper.StartsWith("IMPRESSION") Then

                                    If MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "T" Then

                                        MediaRFPDemo.Value = ChildXmlElement.InnerText

                                    ElseIf MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "R" Then

                                        MediaRFPDemo.Value = ChildXmlElement.InnerText

                                    End If

                                Else

                                    MediaRFPDemo.Value = ChildXmlElement.InnerText

                                End If

                                MediaRFPAvailLine.MediaRFPDemos.Add(MediaRFPDemo)

                            End If

                        Next

                    Next

                End If

                XmlNodeListCodes = XmlElement.GetElementsByTagName("code")

                For Each XmlNodeListCode In XmlNodeListCodes.OfType(Of System.Xml.XmlElement)

                    If XmlNodeListCode.HasAttribute("codeOwner") AndAlso XmlNodeListCode.Attributes("codeOwner").Value = "Spotcable" AndAlso XmlNodeListCode.HasAttribute("codeDescription") OrElse
                            XmlNodeListCode.HasAttribute("codeOwner") AndAlso XmlNodeListCode.Attributes("codeOwner").Value = "NCC" AndAlso XmlNodeListCode.HasAttribute("codeDescription") Then

                        If IsNumeric(XmlNodeListCode.Attributes("codeDescription").Value) AndAlso XmlNodeListCode.Attributes("codeDescription").Value > 0 Then

                            If IsComscore Then

                                ComscoreTVStation = AdvantageFramework.Database.Procedures.ComscoreTVStation.LoadByCallLetters(DbContext, XmlNodeListCode.InnerXml)

                                If ComscoreTVStation IsNot Nothing Then

                                    MediaRFPAvailLine.ComscoreTVStationCallLetters = ComscoreTVStation.CallLetters

                                End If

                                MediaRFPAvailLine.CallLetters = XmlNodeListCode.InnerXml

                                If Not String.IsNullOrWhiteSpace(MediaRFPAvailLine.CallLetters) AndAlso MediaRFPAvailLine.CallLetters.Length > 20 Then

                                    MediaRFPAvailLine.CallLetters = Mid(MediaRFPAvailLine.CallLetters, 1, 20)

                                End If

                            Else

                                MediaRFPAvailLine.CableNetworkStationCode = XmlNodeListCode.InnerText
                                MediaRFPAvailLine.CableNetworkNielsenTVStationCode = XmlNodeListCode.Attributes("codeDescription").Value

                            End If

                        End If

                        DbContext.MediaRFPAvailLines.Add(MediaRFPAvailLine)

                        MediaRFPAvailLine = DuplicateMediaRFPAvailLine(MediaRFPAvailLine)

                    End If

                Next

            Next

            DbContext.SaveChanges()

            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE a SET [TYPE]= '{0}' FROM dbo.MEDIA_RFP_DEMO a INNER JOIN dbo.MEDIA_RFP_AVAILABLE_LINE b ON a.MEDIA_RFP_AVAILABLE_LINE_ID = b.MEDIA_RFP_AVAILABLE_LINE_ID AND b.MEDIA_RFP_HEADER_ID = {1} WHERE a.[TYPE] = ''", UpdateToType, MediaRFPHeader.ID))

        End Sub
        Private Function DuplicateMediaRFPAvailLine(MediaRFPAvailLine As AdvantageFramework.Database.Entities.MediaRFPAvailLine) As AdvantageFramework.Database.Entities.MediaRFPAvailLine

            'objects
            Dim MediaRFPAvailLineNew As AdvantageFramework.Database.Entities.MediaRFPAvailLine = Nothing

            MediaRFPAvailLineNew = MediaRFPAvailLine.DuplicateEntity

            For Each MediaRFPDemo In MediaRFPAvailLine.MediaRFPDemos

                MediaRFPAvailLineNew.MediaRFPDemos.Add(MediaRFPDemo.DuplicateEntity)

            Next

            For Each MediaRFPAvailLineSpot In MediaRFPAvailLine.MediaRFPAvailLineSpots

                MediaRFPAvailLineNew.MediaRFPAvailLineSpots.Add(MediaRFPAvailLineSpot.DuplicateEntity)

            Next

            DuplicateMediaRFPAvailLine = MediaRFPAvailLineNew

        End Function

#End Region

        Private Function GetMediaDemoID(DbContext As AdvantageFramework.Database.DbContext, AgeFrom As Short, AgeTo As Short, Description As String, MediaType As String, RatingsServiceID As Nielsen.Database.Entities.Methods.RatingsServiceID) As Nullable(Of Integer)

            'objects 
            Dim MediaDemographic As AdvantageFramework.Database.Entities.MediaDemographic = Nothing
            Dim MediaDemoID As Integer? = Nothing
            Dim ComscoreDescription As String = Nothing

            If RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen Then

                MediaDemographic = (From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.LoadAllActiveByType(DbContext, MediaType).ToList
                                    Where Entity.MediaDemoSourceID = AdvantageFramework.Database.Entities.MediaDemoSourceID.Nielsen AndAlso
                                          Entity.AgeFrom.GetValueOrDefault(0) = AgeFrom AndAlso
                                          Entity.AgeTo.GetValueOrDefault(99) = AgeTo AndAlso
                                          Entity.Description.ToUpper.StartsWith(Description.ToUpper)).SingleOrDefault

            ElseIf RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore Then

                ComscoreDescription = Mid(Description, 1, 1) & AgeFrom.ToString & If(AgeTo = 99, "+", "-" & AgeTo.ToString)

                MediaDemographic = (From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.LoadAllActiveByType(DbContext, MediaType)
                                    Where Entity.MediaDemoSourceID = AdvantageFramework.Database.Entities.MediaDemoSourceID.Comscore AndAlso
                                          Entity.Description = ComscoreDescription).SingleOrDefault

            ElseIf RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Numeris Then

                MediaDemographic = (From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.LoadAllActiveByType(DbContext, MediaType).ToList
                                    Where Entity.MediaDemoSourceID = AdvantageFramework.Database.Entities.MediaDemoSourceID.Numeris AndAlso
                                          Entity.AgeFrom.GetValueOrDefault(0) = AgeFrom AndAlso
                                          Entity.AgeTo.GetValueOrDefault(99) = AgeTo AndAlso
                                          Entity.Description.ToUpper.StartsWith(Description.ToUpper)).SingleOrDefault

            End If

            If MediaDemographic IsNot Nothing Then

                MediaDemoID = MediaDemographic.ID

            End If

            GetMediaDemoID = MediaDemoID

        End Function
        Private Function CreateMediaRFPDemos(DbContext As AdvantageFramework.Database.DbContext, XmlNodeList As System.Xml.XmlNodeList, MediaBroadcastWorksheet As AdvantageFramework.Database.Entities.MediaBroadcastWorksheet) As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo)

            'objects
            Dim MediaRFPDemoList As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo) = Nothing
            Dim MediaRFPDemo As AdvantageFramework.DTO.Media.RFP.MediaRFPDemo = Nothing

            MediaRFPDemoList = New Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo)

            For Each XmlElement In XmlNodeList.OfType(Of System.Xml.XmlElement)

                MediaRFPDemo = New AdvantageFramework.DTO.Media.RFP.MediaRFPDemo

                MediaRFPDemo.IDRank = XmlElement.Attributes("DemoId").Value

                If XmlElement.Name = "NonStandardDemoCategory" Then

                    If XmlElement.GetElementsByTagName("DemoType").Count = 1 Then

                        MediaRFPDemo.Type = XmlElement.GetElementsByTagName("DemoType").Item(0).InnerText

                    End If

                    If XmlElement.GetElementsByTagName("Description").Count = 1 Then

                        MediaRFPDemo.Group = XmlElement.GetElementsByTagName("Description").Item(0).InnerText

                    End If

                    If XmlElement.GetElementsByTagName("AgeFrom").Count = 1 AndAlso IsNumeric(XmlElement.GetElementsByTagName("AgeFrom").Item(0).InnerText) Then

                        MediaRFPDemo.AgeFrom = CShort(XmlElement.GetElementsByTagName("AgeFrom").Item(0).InnerText)

                    End If

                    If XmlElement.GetElementsByTagName("AgeTo").Count = 1 AndAlso IsNumeric(XmlElement.GetElementsByTagName("AgeTo").Item(0).InnerText) Then

                        MediaRFPDemo.AgeTo = CShort(XmlElement.GetElementsByTagName("AgeTo").Item(0).InnerText)

                    End If

                Else

                    MediaRFPDemo.Type = XmlElement.GetElementsByTagName("tvb:DemoType").Item(0).InnerText
                    MediaRFPDemo.Group = XmlElement.GetElementsByTagName("tvb:Group").Item(0).InnerText

                    If IsNumeric(XmlElement.GetElementsByTagName("tvb:AgeFrom").Item(0).InnerText) Then

                        MediaRFPDemo.AgeFrom = CShort(XmlElement.GetElementsByTagName("tvb:AgeFrom").Item(0).InnerText)

                    End If

                    If IsNumeric(XmlElement.GetElementsByTagName("tvb:AgeTo").Item(0).InnerText) Then

                        MediaRFPDemo.AgeTo = CShort(XmlElement.GetElementsByTagName("tvb:AgeTo").Item(0).InnerText)

                    End If

                End If

                MediaRFPDemo.MediaDemoID = GetMediaDemoID(DbContext, MediaRFPDemo.AgeFrom, MediaRFPDemo.AgeTo, MediaRFPDemo.Group, MediaBroadcastWorksheet.MediaTypeCode, MediaBroadcastWorksheet.RatingsServiceID)

                MediaRFPDemoList.Add(MediaRFPDemo)

            Next

            CreateMediaRFPDemos = MediaRFPDemoList

        End Function
        Private Function CreateMediaRFPCanadianRadioDemos(DbContext As AdvantageFramework.Database.DbContext, XmlNodeList As System.Xml.XmlNodeList, MediaBroadcastWorksheet As AdvantageFramework.Database.Entities.MediaBroadcastWorksheet) As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo)

            'objects
            Dim MediaRFPDemoList As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo) = Nothing
            Dim MediaRFPDemo As AdvantageFramework.DTO.Media.RFP.MediaRFPDemo = Nothing

            MediaRFPDemoList = New Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo)

            For Each XmlElement In XmlNodeList.OfType(Of System.Xml.XmlElement)

                MediaRFPDemo = New AdvantageFramework.DTO.Media.RFP.MediaRFPDemo

                MediaRFPDemo.IDRank = XmlElement.Attributes("indexKey").Value

                'MediaRFPDemo.Type = XmlElement.GetElementsByTagName("tvb:DemoType").Item(0).InnerText
                MediaRFPDemo.Group = XmlElement.GetElementsByTagName("hdr:Group").Item(0).InnerText

                If IsNumeric(XmlElement.GetElementsByTagName("hdr:AgeFrom").Item(0).InnerText) Then

                    MediaRFPDemo.AgeFrom = CShort(XmlElement.GetElementsByTagName("hdr:AgeFrom").Item(0).InnerText)

                End If

                If IsNumeric(XmlElement.GetElementsByTagName("hdr:AgeTo").Item(0).InnerText) Then

                    MediaRFPDemo.AgeTo = CShort(XmlElement.GetElementsByTagName("hdr:AgeTo").Item(0).InnerText)

                End If

                MediaRFPDemo.MediaDemoID = GetMediaDemoID(DbContext, MediaRFPDemo.AgeFrom, MediaRFPDemo.AgeTo, MediaRFPDemo.Group, "R", MediaBroadcastWorksheet.RatingsServiceID)

                MediaRFPDemoList.Add(MediaRFPDemo)

            Next

            CreateMediaRFPCanadianRadioDemos = MediaRFPDemoList

        End Function
        Private Sub CreateMediaRFPDetailLines(DbContext As AdvantageFramework.Database.DbContext, XmlElement As System.Xml.XmlElement, MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader,
                                              MediaRFPDemoList As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo),
                                              DaypartList As Generic.List(Of AdvantageFramework.Database.Entities.Daypart), MediaRFPOutlet As AdvantageFramework.Importing.Classes.MediaRFPOutlet,
                                              Optional MarketDictionary As Dictionary(Of String, String) = Nothing)

            'objects
            Dim MediaRFPAvailLine As AdvantageFramework.Database.Entities.MediaRFPAvailLine = Nothing
            Dim SpotLength() As String = Nothing
            Dim DemoValuesXmlNodeList As System.Xml.XmlNodeList = Nothing
            Dim IDRank As String = Nothing
            Dim MediaRFPDemo As AdvantageFramework.Database.Entities.MediaRFPDemo = Nothing
            Dim MediaRFPDemoDTO As AdvantageFramework.DTO.Media.RFP.MediaRFPDemo = Nothing
            Dim SpotDate As Date = Nothing
            Dim Rate As Nullable(Of Decimal) = Nothing
            Dim MediaRFPAvailLineSpot As AdvantageFramework.Database.Entities.MediaRFPAvailLineSpot = Nothing
            Dim DetailPeriodXmlNodeList As System.Xml.XmlNodeList = Nothing
            Dim Spots As Integer = 0

            MediaRFPAvailLine = New AdvantageFramework.Database.Entities.MediaRFPAvailLine

            MediaRFPAvailLine.MediaRFPHeaderID = MediaRFPHeader.ID

            If XmlElement.GetElementsByTagName("ProgramName").Count = 1 Then

                MediaRFPAvailLine.Program = System.Web.HttpUtility.HtmlDecode(XmlElement.GetElementsByTagName("ProgramName").Item(0).InnerText)

            ElseIf XmlElement.GetElementsByTagName("ProgramDescription").Count = 1 Then 'Canadian tv

                MediaRFPAvailLine.Program = System.Web.HttpUtility.HtmlDecode(XmlElement.GetElementsByTagName("ProgramDescription").Item(0).InnerText)

            End If

            If Not String.IsNullOrWhiteSpace(MediaRFPAvailLine.Program) AndAlso MediaRFPAvailLine.Program.Length > 100 Then

                MediaRFPAvailLine.Program = Mid(MediaRFPAvailLine.Program, 1, 100)

            End If

            If MediaRFPOutlet.IsCable Then

                MediaRFPAvailLine.CableNetworkStationCode = MediaRFPOutlet.CallLetters
                MediaRFPAvailLine.NetworkName = MediaRFPOutlet.CallLetters

            Else

                MediaRFPAvailLine.CallLetters = MediaRFPOutlet.CallLetters

            End If

            If Not String.IsNullOrWhiteSpace(MediaRFPAvailLine.CallLetters) AndAlso MediaRFPAvailLine.CallLetters.Length > 20 Then

                MediaRFPAvailLine.CallLetters = Mid(MediaRFPAvailLine.CallLetters, 1, 20)

            End If

            'If MarketDictionary IsNot Nothing Then

            '    SetStationID(DbContext, MediaRFPAvailLine, MediaRFPHeader.VendorCode)

            'End If

            If XmlElement.GetElementsByTagName("DaypartName").Count > 0 Then

                MediaRFPAvailLine.DaypartName = XmlElement.GetElementsByTagName("DaypartName").Item(0).InnerText

            Else

                MediaRFPAvailLine.DaypartName = ""

            End If

            SetDaypartID(DbContext, MediaRFPAvailLine, DaypartList, MediaRFPHeader.VendorCode)

            If XmlElement.GetElementsByTagName("AvailName").Count > 0 Then

                MediaRFPAvailLine.AvailName = System.Web.HttpUtility.HtmlDecode(XmlElement.GetElementsByTagName("AvailName").Item(0).InnerText)

            Else

                MediaRFPAvailLine.AvailName = ""

            End If

            If Not String.IsNullOrWhiteSpace(MediaRFPAvailLine.AvailName) AndAlso MediaRFPAvailLine.AvailName.Length > 100 Then

                MediaRFPAvailLine.AvailName = Mid(MediaRFPAvailLine.AvailName, 1, 100)

            End If

            If XmlElement.GetElementsByTagName("StartTime").Count > 0 Then

                MediaRFPAvailLine.StartTime = XmlElement.GetElementsByTagName("StartTime").Item(0).InnerText

            End If

            If XmlElement.GetElementsByTagName("EndTime").Count > 0 Then

                MediaRFPAvailLine.EndTime = XmlElement.GetElementsByTagName("EndTime").Item(0).InnerText

            End If

            If Not String.IsNullOrWhiteSpace(MediaRFPAvailLine.StartTime) AndAlso MediaRFPAvailLine.StartTime.Length > 1 AndAlso CInt(MediaRFPAvailLine.StartTime.Substring(0, 2)) >= 24 Then

                MediaRFPAvailLine.StartTime = CInt(MediaRFPAvailLine.StartTime.Substring(0, 2)) - 24 & MediaRFPAvailLine.StartTime.Substring(2)

            End If

            If Not String.IsNullOrWhiteSpace(MediaRFPAvailLine.EndTime) AndAlso MediaRFPAvailLine.EndTime.Length > 1 AndAlso CInt(MediaRFPAvailLine.EndTime.Substring(0, 2)) >= 24 Then

                MediaRFPAvailLine.EndTime = CInt(MediaRFPAvailLine.EndTime.Substring(0, 2)) - 24 & MediaRFPAvailLine.EndTime.Substring(2)

            End If

            If IsDate(MediaRFPAvailLine.StartTime) Then

                MediaRFPAvailLine.StartTime = CDate(MediaRFPAvailLine.StartTime).ToString("hh:mm tt")
                MediaRFPAvailLine.StartHour = CShort(CDate(MediaRFPAvailLine.StartTime).ToString("HHmm"))

            End If

            If IsDate(MediaRFPAvailLine.EndTime) Then

                MediaRFPAvailLine.EndTime = CDate(MediaRFPAvailLine.EndTime).ToString("hh:mm tt")
                MediaRFPAvailLine.EndHour = CShort(CDate(MediaRFPAvailLine.EndTime).ToString("HHmm"))

            End If

            MediaRFPAvailLine.Sunday = If(XmlElement.GetElementsByTagName("tvb-tp:Sunday").Item(0).InnerText = "Y", True, False)
            MediaRFPAvailLine.Monday = If(XmlElement.GetElementsByTagName("tvb-tp:Monday").Item(0).InnerText = "Y", True, False)
            MediaRFPAvailLine.Tuesday = If(XmlElement.GetElementsByTagName("tvb-tp:Tuesday").Item(0).InnerText = "Y", True, False)
            MediaRFPAvailLine.Wednesday = If(XmlElement.GetElementsByTagName("tvb-tp:Wednesday").Item(0).InnerText = "Y", True, False)
            MediaRFPAvailLine.Thursday = If(XmlElement.GetElementsByTagName("tvb-tp:Thursday").Item(0).InnerText = "Y", True, False)
            MediaRFPAvailLine.Friday = If(XmlElement.GetElementsByTagName("tvb-tp:Friday").Item(0).InnerText = "Y", True, False)
            MediaRFPAvailLine.Saturday = If(XmlElement.GetElementsByTagName("tvb-tp:Saturday").Item(0).InnerText = "Y", True, False)

            If XmlElement.GetElementsByTagName("tvb-tp:CommentLine").Count = 1 Then

                'MediaRFPAvailLine.Comments = System.Web.HttpUtility.HtmlDecode(XmlElement.GetElementsByTagName("tvb-tp:CommentLine").Item(0).InnerText)

                If System.Web.HttpUtility.HtmlDecode(XmlElement.GetElementsByTagName("tvb-tp:CommentLine").Item(0).InnerText).StartsWith("TP" & Chr(127)) Then

                    MediaRFPAvailLine.Comments = System.Web.HttpUtility.HtmlDecode(XmlElement.GetElementsByTagName("tvb-tp:CommentLine").Item(0).InnerText).Substring(3)

                Else

                    MediaRFPAvailLine.Comments = System.Web.HttpUtility.HtmlDecode(XmlElement.GetElementsByTagName("tvb-tp:CommentLine").Item(0).InnerText)

                End If

            End If

            If XmlElement.GetElementsByTagName("SpotLength").Count > 0 Then

                SpotLength = XmlElement.GetElementsByTagName("SpotLength").Item(0).InnerText.Split(":")

            End If

            If SpotLength.Length = 3 Then

                MediaRFPAvailLine.SpotLength = (SpotLength(0) * 3600) + (SpotLength(1) * 60) + SpotLength(2)

            End If

            DetailPeriodXmlNodeList = XmlElement.GetElementsByTagName("DetailedPeriod")

            If DetailPeriodXmlNodeList.Count = 0 Then

                DetailPeriodXmlNodeList = XmlElement.GetElementsByTagName("Period")

                If XmlElement.GetElementsByTagName("Rate").Count > 0 Then

                    Rate = XmlElement.GetElementsByTagName("Rate").Item(0).InnerText

                End If

            End If

            If DetailPeriodXmlNodeList.Count = 0 Then

                Throw New Exception("There are no DetailedPeriod or Period data present in the file.")

            End If

            For Each DetailPeriodXmlElement In DetailPeriodXmlNodeList.OfType(Of System.Xml.XmlElement)

                MediaRFPAvailLine.StartDate = DetailPeriodXmlElement.Attributes("startDate").Value
                MediaRFPAvailLine.EndDate = DetailPeriodXmlElement.Attributes("endDate").Value

                If DetailPeriodXmlElement.GetElementsByTagName("Rate").Count > 0 Then

                    Rate = DetailPeriodXmlElement.GetElementsByTagName("Rate").Item(0).InnerText

                ElseIf Not Rate.HasValue Then

                    Rate = 0

                End If

                If DetailPeriodXmlElement.GetElementsByTagName("SpotsPerWeek").Count > 0 Then

                    Spots = DetailPeriodXmlElement.GetElementsByTagName("SpotsPerWeek").Item(0).InnerText

                Else

                    Spots = 0

                End If

                SpotDate = MediaRFPAvailLine.StartDate

                While SpotDate <= MediaRFPAvailLine.EndDate

                    MediaRFPAvailLineSpot = New AdvantageFramework.Database.Entities.MediaRFPAvailLineSpot
                    MediaRFPAvailLineSpot.DbContext = DbContext

                    MediaRFPAvailLineSpot.WeekDate = SpotDate
                    MediaRFPAvailLineSpot.Quantity = Spots
                    MediaRFPAvailLineSpot.Rate = Rate
                    MediaRFPAvailLine.MediaRFPAvailLineSpots.Add(MediaRFPAvailLineSpot)

                    SpotDate = DateAdd(DateInterval.Day, 7, SpotDate)

                End While

            Next

            If MediaRFPAvailLine.MediaRFPAvailLineSpots.Count > 0 Then

                MediaRFPAvailLine.StartDate = MediaRFPAvailLine.MediaRFPAvailLineSpots.Min(Function(S) S.WeekDate)
                MediaRFPAvailLine.EndDate = DateAdd(DateInterval.Day, 6, MediaRFPAvailLine.MediaRFPAvailLineSpots.Max(Function(S) S.WeekDate))

            End If

            MediaRFPAvailLine.BatchNumber = MediaRFPOutlet.BatchNumber.Value

            MediaRFPAvailLine.Status = AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus.H.ToString

            DemoValuesXmlNodeList = XmlElement.GetElementsByTagName("DemoValue")

            If DemoValuesXmlNodeList.Count = 0 AndAlso MediaRFPDemoList IsNot Nothing AndAlso MediaRFPDemoList.Count > 0 Then

                MediaRFPDemo = New AdvantageFramework.Database.Entities.MediaRFPDemo
                MediaRFPDemo.DbContext = DbContext

                MediaRFPDemoDTO = MediaRFPDemoList.FirstOrDefault

                MediaRFPDemoDTO.SaveToEntity(MediaRFPDemo)

                MediaRFPDemo.Value = 0

                MediaRFPAvailLine.MediaRFPDemos.Add(MediaRFPDemo)

            ElseIf MediaRFPDemoList IsNot Nothing AndAlso MediaRFPDemoList.Count > 0 Then

                For Each DemoXmlElement In DemoValuesXmlNodeList.OfType(Of System.Xml.XmlElement)

                    IDRank = DemoXmlElement.Attributes("demoRef").Value

                    MediaRFPDemo = New AdvantageFramework.Database.Entities.MediaRFPDemo
                    MediaRFPDemo.DbContext = DbContext

                    MediaRFPDemoDTO = (From Entity In MediaRFPDemoList
                                       Where Entity.IDRank = IDRank
                                       Select Entity).FirstOrDefault

                    MediaRFPDemoDTO.SaveToEntity(MediaRFPDemo)

                    If MediaRFPDemo.Type.ToUpper.StartsWith("IMPRESSION") Then

                        If MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "T" Then

                            MediaRFPDemo.Value = DemoXmlElement.InnerText * 1000

                        ElseIf MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "R" Then

                            MediaRFPDemo.Value = DemoXmlElement.InnerText * 10

                        End If

                    Else

                        If IsNumeric(DemoXmlElement.InnerText) Then

                            MediaRFPDemo.Value = DemoXmlElement.InnerText

                        Else

                            MediaRFPDemo.Value = 0

                        End If

                    End If

                    If MarketDictionary IsNot Nothing AndAlso DemoXmlElement.HasAttribute("marketRef") AndAlso MarketDictionary.Keys.Contains(DemoXmlElement.Attributes("marketRef").Value) Then

                        MediaRFPDemo.SourceMarketName = MarketDictionary.Item(DemoXmlElement.Attributes("marketRef").Value)

                        If String.IsNullOrWhiteSpace(MediaRFPDemo.SourceMarketName) = False AndAlso MediaRFPDemo.SourceMarketName.Length > 20 Then

                            MediaRFPDemo.SourceMarketName = Mid(MediaRFPDemo.SourceMarketName, 1, 20)

                        End If

                        SetMarketCode(DbContext, MediaRFPDemo)

                    End If

                    MediaRFPAvailLine.MediaRFPDemos.Add(MediaRFPDemo)

                Next

            End If

            DbContext.MediaRFPAvailLines.Add(MediaRFPAvailLine)

            DbContext.SaveChanges()

        End Sub
        Private Sub AddMediaRFPHeaderStatus(DbContext As AdvantageFramework.Database.DbContext, MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader,
                                            Optional ByVal CreatedDate As Nullable(Of Date) = Nothing)

            'objects
            Dim MediaRFPHeaderStatus As AdvantageFramework.Database.Entities.MediaRFPHeaderStatus = Nothing
            Dim Added As Boolean = False

            If CreatedDate.HasValue Then

                MediaRFPHeaderStatus = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeaderStatus.Load(DbContext)
                                        Where Entity.MediaRFPHeaderID = MediaRFPHeader.ID AndAlso
                                              Entity.MediaRFPStatusID = AdvantageFramework.Database.Entities.MediaRFPStatusID.Imported AndAlso
                                              Entity.CreatedDate = CreatedDate.Value
                                        Select Entity).SingleOrDefault

                If MediaRFPHeaderStatus IsNot Nothing Then

                    Added = True

                End If

            End If

            If Added = False Then

                MediaRFPHeaderStatus = New AdvantageFramework.Database.Entities.MediaRFPHeaderStatus

                MediaRFPHeaderStatus.MediaRFPHeaderID = MediaRFPHeader.ID
                MediaRFPHeaderStatus.MediaRFPStatusID = AdvantageFramework.Database.Entities.MediaRFPStatusID.Imported

                If CreatedDate.HasValue Then

                    MediaRFPHeaderStatus.CreatedDate = CreatedDate.Value

                Else

                    MediaRFPHeaderStatus.CreatedDate = Now

                End If

                MediaRFPHeaderStatus.CreatedByUserCode = DbContext.UserCode

                DbContext.MediaRFPHeaderStatuses.Add(MediaRFPHeaderStatus)

            End If

            DbContext.SaveChanges()

        End Sub
        Private Function CreateMediaRFPAvailLineFromAvailLineWithDetailedPeriodsType(Item As AdvantageFramework.Media.Classes.SpotTVCableProposal.availLineWithDetailedPeriodsType,
                                                                                     MediaRFPOutlet As Classes.MediaRFPOutlet) As AdvantageFramework.Database.Entities.MediaRFPAvailLine

            'objects
            Dim MediaRFPAvailLine As AdvantageFramework.Database.Entities.MediaRFPAvailLine = Nothing
            Dim SpotLength() As String = Nothing
            Dim CommentString As String = Nothing
            Dim detailedPeriodType As AdvantageFramework.Media.Classes.SpotTVCableProposal.detailedPeriodType = Nothing
            Dim SpotDate As Date = Nothing
            Dim MediaRFPAvailLineSpot As AdvantageFramework.Database.Entities.MediaRFPAvailLineSpot = Nothing
            Dim Quantity As Integer = 0
            Dim Rate As Decimal = 0

            MediaRFPAvailLine = New AdvantageFramework.Database.Entities.MediaRFPAvailLine

            If MediaRFPOutlet.IsCable Then

                MediaRFPAvailLine.CableNetworkStationCode = MediaRFPOutlet.CallLetters
                MediaRFPAvailLine.NetworkName = MediaRFPOutlet.CallLetters

            Else

                MediaRFPAvailLine.CallLetters = MediaRFPOutlet.CallLetters

            End If

            If String.IsNullOrWhiteSpace(MediaRFPAvailLine.CallLetters) = False AndAlso MediaRFPAvailLine.CallLetters.Length > 20 Then

                MediaRFPAvailLine.CallLetters = Mid(MediaRFPAvailLine.CallLetters, 1, 20)

            End If

            MediaRFPAvailLine.DaypartName = Item.DaypartName
            'MediaRFPAvailLine.DaypartID = Set in calling procedure
            If String.IsNullOrWhiteSpace(Item.AvailName) = False Then

                MediaRFPAvailLine.AvailName = Mid(Item.AvailName, 1, 100)

            End If

            If String.IsNullOrWhiteSpace(Item.SpotLength) = False Then

                SpotLength = Item.SpotLength.Split(":")

            End If

            MediaRFPAvailLine.SpotLength = (SpotLength(0) * 3600) + (SpotLength(1) * 60) + SpotLength(2)

            MediaRFPAvailLine.StartTime = Item.DayTimes(0).StartTime
            MediaRFPAvailLine.EndTime = Item.DayTimes(0).EndTime

            If String.IsNullOrWhiteSpace(MediaRFPAvailLine.StartTime) = False AndAlso MediaRFPAvailLine.StartTime.Length > 1 AndAlso CInt(MediaRFPAvailLine.StartTime.Substring(0, 2)) >= 24 Then

                MediaRFPAvailLine.StartTime = CInt(MediaRFPAvailLine.StartTime.Substring(0, 2)) - 24 & MediaRFPAvailLine.StartTime.Substring(2)

            End If

            If String.IsNullOrWhiteSpace(MediaRFPAvailLine.EndTime) = False AndAlso MediaRFPAvailLine.EndTime.Length > 1 AndAlso CInt(MediaRFPAvailLine.EndTime.Substring(0, 2)) >= 24 Then

                MediaRFPAvailLine.EndTime = CInt(MediaRFPAvailLine.EndTime.Substring(0, 2)) - 24 & MediaRFPAvailLine.EndTime.Substring(2)

            End If

            MediaRFPAvailLine.Monday = (Item.DayTimes(0).Days.Monday = Media.Classes.SpotTVCableProposal.yesNoType.Y)
            MediaRFPAvailLine.Tuesday = (Item.DayTimes(0).Days.Tuesday = Media.Classes.SpotTVCableProposal.yesNoType.Y)
            MediaRFPAvailLine.Wednesday = (Item.DayTimes(0).Days.Wednesday = Media.Classes.SpotTVCableProposal.yesNoType.Y)
            MediaRFPAvailLine.Thursday = (Item.DayTimes(0).Days.Thursday = Media.Classes.SpotTVCableProposal.yesNoType.Y)
            MediaRFPAvailLine.Friday = (Item.DayTimes(0).Days.Friday = Media.Classes.SpotTVCableProposal.yesNoType.Y)
            MediaRFPAvailLine.Saturday = (Item.DayTimes(0).Days.Saturday = Media.Classes.SpotTVCableProposal.yesNoType.Y)
            MediaRFPAvailLine.Sunday = (Item.DayTimes(0).Days.Sunday = Media.Classes.SpotTVCableProposal.yesNoType.Y)

            If IsDate(MediaRFPAvailLine.StartTime) Then

                MediaRFPAvailLine.StartTime = CDate(MediaRFPAvailLine.StartTime).ToString("hh:mm tt")
                MediaRFPAvailLine.StartHour = CShort(CDate(MediaRFPAvailLine.StartTime).ToString("HHmm"))

            End If

            If IsDate(MediaRFPAvailLine.EndTime) Then

                MediaRFPAvailLine.EndTime = CDate(MediaRFPAvailLine.EndTime).ToString("hh:mm tt")
                MediaRFPAvailLine.EndHour = CShort(CDate(MediaRFPAvailLine.EndTime).ToString("HHmm"))

            End If

            MediaRFPAvailLine.Program = Item.DayTimes(0).ProgramName

            If Item.Comment IsNot Nothing Then

                CommentString = String.Join(" ", Item.Comment)

                If System.Web.HttpUtility.HtmlDecode(CommentString.StartsWith("TP" & Chr(127))) Then

                    MediaRFPAvailLine.Comments = CommentString.Substring(3)

                Else

                    MediaRFPAvailLine.Comments = CommentString

                End If

            End If

            MediaRFPAvailLine.BatchNumber = MediaRFPOutlet.BatchNumber.Value

            MediaRFPAvailLine.Status = AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus.H.ToString

            For Each PeriodType In Item.Periods.Items

                If PeriodType.GetType.Equals(GetType(AdvantageFramework.Media.Classes.SpotTVCableProposal.detailedPeriodType)) Then

                    detailedPeriodType = PeriodType

                    MediaRFPAvailLine.StartDate = detailedPeriodType.startDate
                    MediaRFPAvailLine.EndDate = detailedPeriodType.endDate

                    If IsNumeric(detailedPeriodType.SpotsPerWeek) Then

                        Quantity = detailedPeriodType.SpotsPerWeek

                    Else

                        Quantity = 0

                    End If

                    SpotDate = MediaRFPAvailLine.StartDate

                    While SpotDate <= MediaRFPAvailLine.EndDate

                        MediaRFPAvailLineSpot = New AdvantageFramework.Database.Entities.MediaRFPAvailLineSpot

                        MediaRFPAvailLineSpot.WeekDate = SpotDate
                        MediaRFPAvailLineSpot.Quantity = Quantity
                        MediaRFPAvailLineSpot.Rate = detailedPeriodType.Rate
                        MediaRFPAvailLine.MediaRFPAvailLineSpots.Add(MediaRFPAvailLineSpot)

                        SpotDate = DateAdd(DateInterval.Day, 7, SpotDate)

                    End While

                End If

            Next

            'MediaRFPAvailLine.MediaRFPDemos 
            CreateMediaRFPAvailLineFromAvailLineWithDetailedPeriodsType = MediaRFPAvailLine

        End Function
        Private Function ImportProposal(DbContext As AdvantageFramework.Database.DbContext, File As String, MediaBroadcastWorksheetMarketID As Integer,
                                        MediaBroadcastWorksheet As AdvantageFramework.Database.Entities.MediaBroadcastWorksheet, DaypartList As Generic.List(Of AdvantageFramework.Database.Entities.Daypart),
                                        ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate, ByRef MissingSyscodesCallLetters As Generic.List(Of String)) As Boolean

            Dim aaaaMessageType As AdvantageFramework.Media.Classes.SpotTVCableProposal.aaaaMessageType = Nothing
            Dim Serializer As Xml.Serialization.XmlSerializer = Nothing
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim Imported As Boolean = False
            Dim MediaRFPOutlet As AdvantageFramework.Importing.Classes.MediaRFPOutlet = Nothing
            Dim MediaRFPOutletList As Generic.List(Of AdvantageFramework.Importing.Classes.MediaRFPOutlet) = Nothing
            Dim MediaRFPAvailLine As AdvantageFramework.Database.Entities.MediaRFPAvailLine = Nothing
            Dim MediaRFPDemoList As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo) = Nothing
            Dim MediaRFPDemo As AdvantageFramework.DTO.Media.RFP.MediaRFPDemo = Nothing
            Dim MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader = Nothing

            MediaRFPDemoList = New Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo)

            Try

                Serializer = New Xml.Serialization.XmlSerializer(GetType(AdvantageFramework.Media.Classes.SpotTVCableProposal.aaaaMessageType))
                StreamReader = New IO.StreamReader(File)
                aaaaMessageType = Serializer.Deserialize(StreamReader)

                MediaRFPOutletList = New Generic.List(Of AdvantageFramework.Importing.Classes.MediaRFPOutlet)

                For Each OutletItem In aaaaMessageType.Proposal.Outlets.Items

                    MediaRFPOutlet = New AdvantageFramework.Importing.Classes.MediaRFPOutlet()

                    If OutletItem.GetType = GetType(AdvantageFramework.Media.Classes.SpotTVCableProposal.televisionStationType) Then

                        MediaRFPOutlet.CallLetters = DirectCast(OutletItem, AdvantageFramework.Media.Classes.SpotTVCableProposal.televisionStationType).callLetters
                        MediaRFPOutlet.OutletId = DirectCast(OutletItem, AdvantageFramework.Media.Classes.SpotTVCableProposal.televisionStationType).outletId

                    ElseIf OutletItem.GetType = GetType(AdvantageFramework.Media.Classes.SpotTVCableProposal.cableStationType) Then

                        MediaRFPOutlet.Syscode = DirectCast(OutletItem, AdvantageFramework.Media.Classes.SpotTVCableProposal.cableStationType).syscode
                        MediaRFPOutlet.OutletId = DirectCast(OutletItem, AdvantageFramework.Media.Classes.SpotTVCableProposal.cableStationType).outletId
                        MediaRFPOutlet.IsCable = True

                    ElseIf OutletItem.GetType = GetType(AdvantageFramework.Media.Classes.SpotTVCableProposal.radioStationType) Then

                        MediaRFPOutlet.CallLetters = DirectCast(OutletItem, AdvantageFramework.Media.Classes.SpotTVCableProposal.radioStationType).callLetters
                        MediaRFPOutlet.OutletId = DirectCast(OutletItem, AdvantageFramework.Media.Classes.SpotTVCableProposal.radioStationType).outletId
                        MediaRFPOutlet.Band = DirectCast(OutletItem, AdvantageFramework.Media.Classes.SpotTVCableProposal.radioStationType).band

                    End If

                    MediaRFPOutletList.Add(MediaRFPOutlet)

                Next

                For Each AvailList In aaaaMessageType.Proposal.AvailList

                    For Each OutletReference In AvailList.OutletReferences

                        MediaRFPOutlet = MediaRFPOutletList.Where(Function(OL) OL.OutletId = OutletReference.outletFromProposalRef).SingleOrDefault
                        MediaRFPOutlet.OutletForListId = OutletReference.outletForListId

                    Next

                    MediaRFPDemoList.Clear()

                    For Each DemoCategory In AvailList.DemoCategories

                        MediaRFPDemo = New AdvantageFramework.DTO.Media.RFP.MediaRFPDemo
                        MediaRFPDemo.Type = DemoCategory.DemoType.ToString
                        MediaRFPDemo.Group = DemoCategory.Group.ToString

                        MediaRFPDemo.AgeFrom = (CType(GetType(Media.Classes.SpotTVCableProposal.demoBaseTypeAgeFrom).GetMember(DemoCategory.AgeFrom.ToString())(0).GetCustomAttributes(GetType(System.Xml.Serialization.XmlEnumAttribute), False)(0), System.Xml.Serialization.XmlEnumAttribute)).Name
                        MediaRFPDemo.AgeTo = (CType(GetType(Media.Classes.SpotTVCableProposal.demoBaseTypeAgeTo).GetMember(DemoCategory.AgeTo.ToString())(0).GetCustomAttributes(GetType(System.Xml.Serialization.XmlEnumAttribute), False)(0), System.Xml.Serialization.XmlEnumAttribute)).Name

                        MediaRFPDemo.IDRank = DemoCategory.DemoId
                        MediaRFPDemo.MediaDemoID = GetMediaDemoID(DbContext, MediaRFPDemo.AgeFrom, MediaRFPDemo.AgeTo, MediaRFPDemo.Group, MediaBroadcastWorksheet.MediaTypeCode, MediaBroadcastWorksheet.RatingsServiceID)

                        MediaRFPDemoList.Add(MediaRFPDemo)

                    Next

                    For Each Item In AvailList.Items

                        MediaRFPOutlet = MediaRFPOutletList.Where(Function(OL) OL.OutletForListId = Item.OutletReference.outletFromListRef).SingleOrDefault

                        If MediaRFPOutlet IsNot Nothing Then

                            MediaRFPHeader = GetMediaRFPHeader(DbContext, MediaRFPOutlet, ImportTemplate, MediaBroadcastWorksheetMarketID)

                            If MediaRFPHeader IsNot Nothing Then

                                For Each MediaRFPDemo In MediaRFPDemoList

                                    MediaRFPDemo.MediaRFPHeaderID = MediaRFPHeader.ID

                                Next

                                If MediaRFPOutletList.Where(Function(OL) OL.MediaRFPHeaderID.HasValue AndAlso OL.MediaRFPHeaderID = MediaRFPHeader.ID AndAlso OL.BatchNumber.HasValue).Any Then

                                    MediaRFPOutlet.BatchNumber = MediaRFPOutletList.Where(Function(OL) OL.MediaRFPHeaderID.HasValue AndAlso OL.MediaRFPHeaderID = MediaRFPHeader.ID AndAlso OL.BatchNumber.HasValue).First.BatchNumber

                                ElseIf (From Entity In AdvantageFramework.Database.Procedures.MediaRFPAvailLine.Load(DbContext)
                                        Where Entity.MediaRFPHeaderID = MediaRFPHeader.ID
                                        Select Entity.BatchNumber).Any Then

                                    MediaRFPOutlet.BatchNumber = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPAvailLine.Load(DbContext)
                                                                  Where Entity.MediaRFPHeaderID = MediaRFPHeader.ID
                                                                  Select Entity.BatchNumber).Max + 1

                                Else

                                    MediaRFPOutlet.BatchNumber = 1

                                End If

                                If Item.GetType.Equals(GetType(AdvantageFramework.Media.Classes.SpotTVCableProposal.availLineWithDetailedPeriodsType)) Then

                                    MediaRFPAvailLine = CreateMediaRFPAvailLineFromAvailLineWithDetailedPeriodsType(Item, MediaRFPOutlet)

                                    MediaRFPAvailLine.MediaRFPHeaderID = MediaRFPHeader.ID

                                    SetDaypartID(DbContext, MediaRFPAvailLine, DaypartList, MediaRFPHeader.VendorCode)

                                    DbContext.MediaRFPAvailLines.Add(MediaRFPAvailLine)

                                End If

                            ElseIf Not MissingSyscodesCallLetters.Contains(MediaRFPOutlet.CallLetters) Then

                                MissingSyscodesCallLetters.Add(MediaRFPOutlet.CallLetters)

                            End If

                        End If

                    Next

                Next

                DbContext.SaveChanges()

                Imported = True

            Catch ex As Exception
                Imported = False
            End Try

            ImportProposal = Imported

        End Function
        Private Function GetMediaRFPHeader(DbContext As AdvantageFramework.Database.DbContext, MediaRFPOutlet As AdvantageFramework.Importing.Classes.MediaRFPOutlet,
                                           ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate, MediaBroadcastWorksheetMarketID As Integer) As AdvantageFramework.Database.Entities.MediaRFPHeader

            'objects
            Dim MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader = Nothing
            Dim VendorCrossReference As AdvantageFramework.Database.Entities.VendorCrossReference = Nothing
            Dim SourceVendorCode As String = Nothing

            If MediaRFPOutlet.IsCable Then

                If String.IsNullOrWhiteSpace(MediaRFPOutlet.Syscode) = False AndAlso IsNumeric(MediaRFPOutlet.Syscode) Then

                    MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                      Where Entity.Syscode = CInt(MediaRFPOutlet.Syscode)
                                      Select Entity).SingleOrDefault

                End If

                If MediaRFPHeader Is Nothing Then

                    If ImportTemplate IsNot Nothing AndAlso ImportTemplate.RecordSourceID.HasValue AndAlso String.IsNullOrWhiteSpace(MediaRFPOutlet.Syscode) = False Then

                        VendorCrossReference = (From VCR In AdvantageFramework.Database.Procedures.VendorCrossReference.LoadByRecordSourceID(DbContext, ImportTemplate.RecordSourceID.Value)
                                                Where VCR.SourceVendorCode.ToUpper = MediaRFPOutlet.Syscode.ToUpper
                                                Select VCR).SingleOrDefault

                        If VendorCrossReference IsNot Nothing Then

                            MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                              Where Entity.VendorCode.ToUpper = VendorCrossReference.VendorCode.ToUpper
                                              Select Entity).SingleOrDefault

                        End If

                    End If

                    If MediaRFPHeader Is Nothing AndAlso String.IsNullOrWhiteSpace(MediaRFPOutlet.Syscode) = False Then

                        If (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                            Where Entity.Vendor.VendorCodeCrossReference.ToUpper = MediaRFPOutlet.Syscode.ToUpper
                            Select Entity).Count = 1 Then

                            MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                              Where Entity.Vendor.VendorCodeCrossReference.ToUpper = MediaRFPOutlet.Syscode.ToUpper
                                              Select Entity).SingleOrDefault

                        End If

                    End If

                    If MediaRFPHeader Is Nothing AndAlso String.IsNullOrWhiteSpace(MediaRFPOutlet.Syscode) = False Then

                        MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                          Where Entity.VendorCode = MediaRFPOutlet.Syscode
                                          Select Entity).SingleOrDefault

                    End If

                End If

            Else

                SourceVendorCode = MediaRFPOutlet.CallLetters.ToUpper & If(String.IsNullOrWhiteSpace(MediaRFPOutlet.Band), "", MediaRFPOutlet.Band).ToUpper

                If ImportTemplate IsNot Nothing AndAlso ImportTemplate.RecordSourceID.HasValue Then

                    If (From VCR In AdvantageFramework.Database.Procedures.VendorCrossReference.LoadByRecordSourceID(DbContext, ImportTemplate.RecordSourceID.Value)
                        Where VCR.SourceVendorCode.ToUpper = SourceVendorCode
                        Select VCR).Count = 1 Then

                        VendorCrossReference = (From VCR In AdvantageFramework.Database.Procedures.VendorCrossReference.LoadByRecordSourceID(DbContext, ImportTemplate.RecordSourceID.Value)
                                                Where VCR.SourceVendorCode.ToUpper = SourceVendorCode
                                                Select VCR).SingleOrDefault

                        If VendorCrossReference IsNot Nothing Then

                            MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                              Where Entity.VendorCode.ToUpper = VendorCrossReference.VendorCode.ToUpper
                                              Select Entity).SingleOrDefault

                        End If

                    End If

                End If

                If MediaRFPHeader Is Nothing Then

                    If (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                        Where Entity.Vendor.VendorCodeCrossReference.ToUpper = SourceVendorCode
                        Select Entity).Count = 1 Then

                        MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                          Where Entity.Vendor.VendorCodeCrossReference.ToUpper = SourceVendorCode
                                          Select Entity).SingleOrDefault

                    End If

                End If

                If MediaRFPHeader Is Nothing Then

                    If MediaRFPOutlet.CallLetters.Length = 3 Then

                        If (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                            Where Entity.VendorCode.Substring(0, 3).ToUpper = MediaRFPOutlet.CallLetters.ToUpper
                            Select Entity).Count = 1 Then

                            MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                              Where Entity.VendorCode.Substring(0, 3).ToUpper = MediaRFPOutlet.CallLetters.ToUpper
                                              Select Entity).SingleOrDefault

                        ElseIf Not String.IsNullOrWhiteSpace(MediaRFPOutlet.Band) Then

                            MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                              Where Entity.VendorCode.Substring(0, 4).ToUpper = MediaRFPOutlet.CallLetters.ToUpper & Mid(MediaRFPOutlet.Band.ToUpper, 1, 1)
                                              Select Entity).SingleOrDefault

                        End If

                    ElseIf MediaRFPOutlet.CallLetters.Length = 4 Then

                        If (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                            Where Entity.VendorCode.Substring(0, 4).ToUpper = MediaRFPOutlet.CallLetters.ToUpper
                            Select Entity).Count = 1 Then

                            MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                              Where Entity.VendorCode.Substring(0, 4).ToUpper = MediaRFPOutlet.CallLetters.ToUpper
                                              Select Entity).SingleOrDefault

                        ElseIf Not String.IsNullOrWhiteSpace(MediaRFPOutlet.Band) Then

                            If (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                Where Entity.VendorCode.Substring(0, 5).ToUpper = MediaRFPOutlet.CallLetters.ToUpper & Mid(MediaRFPOutlet.Band.ToUpper, 1, 1)
                                Select Entity).Count = 1 Then

                                MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                                  Where Entity.VendorCode.Substring(0, 5).ToUpper = MediaRFPOutlet.CallLetters.ToUpper & Mid(MediaRFPOutlet.Band.ToUpper, 1, 1)
                                                  Select Entity).SingleOrDefault

                            ElseIf (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                    Where Entity.VendorCode.ToUpper = MediaRFPOutlet.CallLetters.ToUpper & Mid(MediaRFPOutlet.Band.ToUpper, 1, 2)
                                    Select Entity).Count = 1 Then

                                MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                                  Where Entity.VendorCode.ToUpper = MediaRFPOutlet.CallLetters.ToUpper & Mid(MediaRFPOutlet.Band.ToUpper, 1, 2)
                                                  Select Entity).SingleOrDefault

                            End If

                        End If

                    End If

                End If

            End If

            GetMediaRFPHeader = MediaRFPHeader

        End Function
        Public Function ImportMediaRFPFile(Session As AdvantageFramework.Security.Session, Files() As String, MediaBroadcastWorksheetMarketID As Integer,
                                           ByRef InfoMessage As String, Optional ByVal MediaRFPHeaderID As Nullable(Of Integer) = Nothing) As Boolean

            'objects
            Dim StringBuilderInfo As Text.StringBuilder = Nothing
            Dim MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing
            Dim DaypartList As Generic.List(Of AdvantageFramework.Database.Entities.Daypart) = Nothing
            Dim FileCounter As Integer = 0
            Dim FileImported As Boolean = False
            Dim XmlDocument As System.Xml.XmlDocument = Nothing
            Dim XmlNodeList As System.Xml.XmlNodeList = Nothing
            Dim MediaRFPDemoList As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo) = Nothing
            Dim Syscode As String = Nothing
            Dim MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader = Nothing
            Dim NodeCounter As Integer = 0
            Dim XmlNodeListWeeks As System.Xml.XmlNodeList = Nothing
            Dim MissingSyscodesCallLetters As Generic.List(Of String) = Nothing
            Dim CanImport As Boolean = True
            Dim StationsXmlNodeList As System.Xml.XmlNodeList = Nothing
            'Dim OutletReferencesXmlNodeList As System.Xml.XmlNodeList = Nothing
            Dim MediaRFPOutlet As AdvantageFramework.Importing.Classes.MediaRFPOutlet = Nothing
            'Dim MediaRFPOutletList As Generic.List(Of AdvantageFramework.Importing.Classes.MediaRFPOutlet) = Nothing
            Dim HeaderComment As String = String.Empty
            Dim OrderXmlNodeList As System.Xml.XmlNodeList = Nothing
            Dim OrderXmlElement As System.Xml.XmlElement = Nothing
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing
            Dim VendorCrossReference As AdvantageFramework.Database.Entities.VendorCrossReference = Nothing
            'Dim SourceVendorCode As String = Nothing
            Dim IsCanadianRadio As Boolean = False ' a Canadian radio file with one station for many markets 
            Dim OutletId As String = Nothing
            Dim IsComscore As Boolean = False
            Dim SchemaName As String = String.Empty
            Dim Imported As Boolean = False
            Dim AvailNodeList As System.Xml.XmlNodeList = Nothing

            Try

                StringBuilderInfo = New System.Text.StringBuilder()

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    RaiseEvent SetupOverallImportingProgressEvent(0, UBound(Files) + 1, 0)

                    If (From Entity In AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportType(DbContext, AdvantageFramework.Importing.ImportTemplateTypes.MediaRFP_4As)
                        Where Entity.IsSystemTemplate = True
                        Select Entity).Count = 1 Then

                        ImportTemplate = (From Entity In AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportType(DbContext, AdvantageFramework.Importing.ImportTemplateTypes.MediaRFP_4As)
                                          Where Entity.IsSystemTemplate = True
                                          Select Entity).SingleOrDefault

                    End If

                    MediaBroadcastWorksheetMarket = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)

                    If MediaBroadcastWorksheetMarket IsNot Nothing AndAlso MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet IsNot Nothing Then

                        If MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore Then

                            IsComscore = True

                        End If

                        If MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "T" Then

                            DaypartList = AdvantageFramework.Database.Procedures.Daypart.LoadActiveByDaypartTypeID(DbContext, AdvantageFramework.Database.Entities.DayPartTypeID.Local_TV).ToList

                        ElseIf MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "R" Then

                            DaypartList = AdvantageFramework.Database.Procedures.Daypart.LoadActiveByDaypartTypeID(DbContext, AdvantageFramework.Database.Entities.DayPartTypeID.Local_Radio).ToList

                        End If

                        MissingSyscodesCallLetters = New Generic.List(Of String)

                        For Each File In Files

                            FileCounter += 1

                            'Imported = ImportProposal(DbContext, File, MediaBroadcastWorksheetMarketID, MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet, DaypartList, ImportTemplate, MissingSyscodesCallLetters)

                            If File.ToUpper.EndsWith(".PRP") Then

                                Imported = ImportAustralianPRP(DbContext, ImportTemplate, MediaBroadcastWorksheetMarketID, File, MissingSyscodesCallLetters)

                            ElseIf Imported = False Then

                                IsCanadianRadio = False

                                CanImport = True

                                XmlDocument = New System.Xml.XmlDocument
                                XmlDocument.Load(File)

                                SchemaName = String.Empty

                                If XmlDocument.DocumentElement.GetElementsByTagName("SchemaName").Count = 1 Then

                                    SchemaName = XmlDocument.DocumentElement.GetElementsByTagName("SchemaName").Item(0).InnerText

                                End If

                                If SchemaName.ToUpper = "CanadianTVContract".ToUpper Then

                                    XmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("tv:StandardDemoCategory")

                                    MediaRFPDemoList = CreateMediaRFPDemos(DbContext, XmlNodeList, MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet)

                                    CanImport = ImportCanadianTVContract(XmlDocument, DbContext, ImportTemplate, MediaBroadcastWorksheetMarketID, MediaRFPDemoList, MissingSyscodesCallLetters)

                                ElseIf MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.CountryID = AdvantageFramework.DTO.Countries.Canada AndAlso SchemaName.ToUpper = "CanadianTVGAP".ToUpper Then

                                    XmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("StandardDemoCategory")

                                    MediaRFPDemoList = CreateMediaRFPDemos(DbContext, XmlNodeList, MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet)

                                    CanImport = ImportCanadianTVGAP(XmlDocument, Session, DbContext, ImportTemplate, MediaBroadcastWorksheetMarketID, MediaRFPDemoList, DaypartList, MissingSyscodesCallLetters)

                                ElseIf XmlDocument.DocumentElement IsNot Nothing AndAlso (XmlDocument.DocumentElement.Name = "AAAA-Message" OrElse
                                        XmlDocument.DocumentElement.Name = "Transmission") Then

                                    If MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "T" Then

                                        StationsXmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("TelevisionStation")

                                        If StationsXmlNodeList.Count = 0 Then

                                            StationsXmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("CableStation")

                                            If StationsXmlNodeList.Count = 0 Then

                                                StationsXmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("Station") 'Canadian tv

                                                If StationsXmlNodeList.Count = 0 Then

                                                    StringBuilderInfo.AppendLine("Cannot import file: " & File & " for a Spot TV worksheet.")
                                                    CanImport = False

                                                End If

                                            End If

                                        End If

                                    ElseIf MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "R" Then

                                        StationsXmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("RadioStation")

                                        If StationsXmlNodeList.Count = 0 Then

                                            StationsXmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("Station")

                                            If StationsXmlNodeList.Count = 0 Then

                                                StationsXmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("rdo:StationName") 'Canadian radio

                                                IsCanadianRadio = (StationsXmlNodeList.Count > 0)

                                            End If

                                            If StationsXmlNodeList.Count = 0 Then

                                                StringBuilderInfo.AppendLine("Cannot import file: " & File & " for a Spot Radio worksheet.")
                                                CanImport = False

                                            End If

                                        End If

                                    End If

                                    If CanImport Then

                                        'OutletReferencesXmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("OutletReferences")

                                        'If OutletReferencesXmlNodeList.Count = 0 Then

                                        '    OutletReferencesXmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("OutletReference") 'Canadian tv

                                        'Else

                                        '    OutletReferencesXmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("OutletReferences").Item(0).ChildNodes

                                        'End If

                                        'MediaRFPOutletList = New Generic.List(Of AdvantageFramework.Importing.Classes.MediaRFPOutlet)

                                        'If IsCanadianRadio Then

                                        '    MediaRFPOutlet = New AdvantageFramework.Importing.Classes.MediaRFPOutlet()

                                        '    For Each StationElement In StationsXmlNodeList.OfType(Of System.Xml.XmlElement)

                                        '        If StationElement.InnerText.Contains("-") Then

                                        '            MediaRFPOutlet.CallLetters = StationElement.InnerText.Substring(0, InStr(StationElement.InnerText, "-") - 1)
                                        '            MediaRFPOutlet.Band = StationElement.InnerText.Substring(InStr(StationElement.InnerText, "-"))

                                        '        Else

                                        '            MediaRFPOutlet.CallLetters = StationElement.InnerText

                                        '        End If

                                        '        MediaRFPOutlet.IsCable = False

                                        '    Next

                                        '    MediaRFPOutletList.Add(MediaRFPOutlet)

                                        'ElseIf OutletReferencesXmlNodeList Is Nothing OrElse OutletReferencesXmlNodeList.Count = 0 Then

                                        '    Throw New Exception("Cannot find OutletReferences or OutletReference in file!")

                                        'Else

                                        '    For Each OutletReferenceElement In OutletReferencesXmlNodeList.OfType(Of System.Xml.XmlElement)

                                        '        If OutletReferenceElement.HasAttribute("outletFromProposalRef") AndAlso OutletReferenceElement.HasAttribute("outletForListId") Then

                                        '            MediaRFPOutlet = New AdvantageFramework.Importing.Classes.MediaRFPOutlet(OutletReferenceElement.Attributes("outletFromProposalRef").Value, OutletReferenceElement.Attributes("outletForListId").Value)

                                        '        ElseIf OutletReferenceElement.HasAttribute("outletRef") Then 'Canadian tv

                                        '            MediaRFPOutlet = New AdvantageFramework.Importing.Classes.MediaRFPOutlet(OutletReferenceElement.Attributes("outletRef").Value, Nothing)

                                        '        End If

                                        '        If OutletReferenceElement.GetElementsByTagName("tvb-tp:CommentLine").Count = 1 Then

                                        '            MediaRFPOutlet.HeaderComment = System.Web.HttpUtility.HtmlDecode(OutletReferenceElement.GetElementsByTagName("tvb-tp:CommentLine").Item(0).InnerText)

                                        '        Else

                                        '            MediaRFPOutlet.HeaderComment = String.Empty

                                        '        End If

                                        '        For Each StationElement In StationsXmlNodeList.OfType(Of System.Xml.XmlElement)

                                        '            If StationElement.Attributes("outletId").Value = MediaRFPOutlet.OutletId Then

                                        '                If StationElement.HasAttribute("callLetters") Then

                                        '                    MediaRFPOutlet.CallLetters = Trim(Replace(StationElement.Attributes("callLetters").Value, "+", ""))
                                        '                    MediaRFPOutlet.IsCable = False

                                        '                    If StationElement.HasAttribute("band") Then

                                        '                        MediaRFPOutlet.Band = StationElement.Attributes("band").Value

                                        '                    End If

                                        '                ElseIf StationElement.HasAttribute("network") Then

                                        '                    MediaRFPOutlet.CallLetters = Trim(StationElement.Attributes("network").Value)
                                        '                    MediaRFPOutlet.IsCable = True
                                        '                    MediaRFPOutlet.Syscode = StationElement.Attributes("syscode").Value

                                        '                End If

                                        '                If MediaRFPOutlet.CallLetters.Length > 4 AndAlso SchemaName.ToUpper <> "CanadianTVGAP".ToUpper Then

                                        '                    MediaRFPOutlet.CallLetters = MediaRFPOutlet.CallLetters.Substring(0, 4)

                                        '                End If

                                        '                Exit For

                                        '            End If

                                        '        Next

                                        '        MediaRFPOutletList.Add(MediaRFPOutlet)

                                        '    Next

                                        'End If

                                        XmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("DemoCategory")

                                        If XmlNodeList.Count = 0 Then

                                            XmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("StandardDemoCategory") 'Canadian tv

                                            If XmlNodeList.Count = 0 Then

                                                XmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("NonStandardDemoCategory") 'found in Canadian radio

                                            End If

                                        End If

                                        If IsCanadianRadio Then

                                            XmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("hdr:Demo") 'Canadian radio
                                            MediaRFPDemoList = CreateMediaRFPCanadianRadioDemos(DbContext, XmlNodeList, MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet)

                                        Else

                                            MediaRFPDemoList = CreateMediaRFPDemos(DbContext, XmlNodeList, MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet)

                                        End If

                                        AvailNodeList = XmlDocument.DocumentElement.GetElementsByTagName("AvailList")

                                        If AvailNodeList IsNot Nothing AndAlso AvailNodeList.Count > 0 Then

                                            For Each AvailNode As System.Xml.XmlElement In AvailNodeList

                                                ImportAvailLines(DbContext, XmlDocument, StationsXmlNodeList, SchemaName, DaypartList, ImportTemplate, IsCanadianRadio, MediaBroadcastWorksheetMarketID, MediaRFPDemoList, AvailNode, MissingSyscodesCallLetters)

                                            Next

                                        Else

                                            ImportAvailLines(DbContext, XmlDocument, StationsXmlNodeList, SchemaName, DaypartList, ImportTemplate, IsCanadianRadio, MediaBroadcastWorksheetMarketID, MediaRFPDemoList, XmlDocument.DocumentElement, MissingSyscodesCallLetters)

                                        End If

                                    End If

                                ElseIf XmlDocument.DocumentElement IsNot Nothing AndAlso XmlDocument.DocumentElement.Name = "adx" Then

                                    XmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("demo")
                                    MediaRFPDemoList = CreateNCCMediaRFPDemos(DbContext, XmlNodeList, MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet)

                                    OrderXmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("order")

                                    For Each OrderXmlElement In OrderXmlNodeList.OfType(Of System.Xml.XmlElement)

                                        MediaRFPHeader = Nothing

                                        If OrderXmlElement.GetElementsByTagName("survey").Count = 1 AndAlso OrderXmlElement.GetElementsByTagName("survey").Item(0).SelectSingleNode("comment") IsNot Nothing Then

                                            HeaderComment = System.Web.HttpUtility.HtmlDecode(OrderXmlElement.GetElementsByTagName("survey").Item(0).SelectSingleNode("comment").InnerText)

                                        End If

                                        XmlNodeList = OrderXmlElement.GetElementsByTagName("systemOrder")

                                        RaiseEvent SetupImportingProgressEvent(0, If(XmlNodeList.Count = 1, 1, XmlNodeList.Count), 0)

                                        For Each XmlElement In XmlNodeList.OfType(Of System.Xml.XmlElement)

                                            Syscode = XmlElement.GetElementsByTagName("syscode").Item(0).InnerText

                                            XmlNodeListWeeks = XmlElement.GetElementsByTagName("week")

                                            MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                                              Where Entity.Syscode = CInt(Syscode)
                                                              Select Entity).SingleOrDefault

                                            If ImportTemplate IsNot Nothing AndAlso ImportTemplate.RecordSourceID.HasValue Then

                                                VendorCrossReference = (From VCR In AdvantageFramework.Database.Procedures.VendorCrossReference.LoadByRecordSourceID(DbContext, ImportTemplate.RecordSourceID.Value)
                                                                        Where VCR.SourceVendorCode.ToUpper = Syscode.ToUpper
                                                                        Select VCR).SingleOrDefault

                                                If VendorCrossReference IsNot Nothing Then

                                                    MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                                                      Where Entity.VendorCode.ToUpper = VendorCrossReference.VendorCode.ToUpper
                                                                      Select Entity).SingleOrDefault

                                                End If

                                            End If

                                            If MediaRFPHeader Is Nothing Then

                                                If (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                                    Where Entity.Vendor.VendorCodeCrossReference.ToUpper = Syscode.ToUpper
                                                    Select Entity).Count = 1 Then

                                                    MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                                                      Where Entity.Vendor.VendorCodeCrossReference.ToUpper = Syscode.ToUpper
                                                                      Select Entity).SingleOrDefault

                                                End If

                                            End If

                                            If MediaRFPHeader Is Nothing Then

                                                MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                                                  Where Entity.VendorCode = Syscode
                                                                  Select Entity).SingleOrDefault

                                            End If

                                            If MediaRFPHeader IsNot Nothing Then

                                                MediaRFPHeader.Comments = HeaderComment

                                                If MediaRFPHeader.DbContext Is Nothing Then

                                                    DbContext.TryAttach(MediaRFPHeader)

                                                End If

                                                DbContext.Entry(MediaRFPHeader).State = Entity.EntityState.Modified
                                                DbContext.SaveChanges()

                                                AddMediaRFPHeaderStatus(DbContext, MediaRFPHeader)

                                                CreateNCCMediaRFPDetailLines(Session, DbContext, XmlElement, MediaRFPHeader, MediaRFPDemoList, XmlNodeListWeeks, DaypartList, IsComscore)

                                            Else

                                                MissingSyscodesCallLetters.Add(Syscode)

                                            End If

                                            NodeCounter += 1

                                            RaiseEvent ImportingProgressUpdateEvent(NodeCounter)

                                        Next

                                    Next

                                End If

                            End If

                            If CanImport OrElse Imported Then

                                AdvantageFramework.Importing.RenameFileAfterImport(File, Session.UserCode)

                                FileImported = True

                            End If

                            RaiseEvent OverallImportingProgressUpdateEvent(FileCounter)

                        Next

                    End If

                End Using

                If MissingSyscodesCallLetters IsNot Nothing AndAlso MissingSyscodesCallLetters.Count > 0 Then

                    If MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.CountryID = AdvantageFramework.DTO.Countries.Canada Then

                        StringBuilderInfo.AppendLine("The following station(s) were not imported to any vendor:" & vbCrLf & String.Join(", ", MissingSyscodesCallLetters.ToArray))

                    Else

                        StringBuilderInfo.AppendLine("The following syscodes/call letters were not imported to any vendor:" & vbCrLf & String.Join(", ", MissingSyscodesCallLetters.ToArray))

                    End If

                End If

            Catch ex As Exception

                While ex.InnerException IsNot Nothing

                    ex = ex.InnerException

                End While

                StringBuilderInfo.AppendLine("Error: " & ex.Message)

                FileImported = False

            Finally

                If StringBuilderInfo.Length > 0 Then

                    InfoMessage = StringBuilderInfo.ToString

                End If

                ImportMediaRFPFile = FileImported

            End Try

        End Function
        Private Sub ImportAvailLines(DbContext As AdvantageFramework.Database.DbContext, XmlDocument As System.Xml.XmlDocument, StationsXmlNodeList As System.Xml.XmlNodeList, SchemaName As String,
                                     DaypartList As Generic.List(Of AdvantageFramework.Database.Entities.Daypart), ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate, IsCanadianRadio As Boolean,
                                     MediaBroadcastWorksheetMarketID As Integer, MediaRFPDemoList As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo), AvailLineXmlElement As System.Xml.XmlElement,
                                     ByRef MissingSyscodesCallLetters As Generic.List(Of String))

            'objects
            Dim XmlNodeList As System.Xml.XmlNodeList = Nothing
            Dim MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader = Nothing
            Dim MediaRFPOutlet As AdvantageFramework.Importing.Classes.MediaRFPOutlet = Nothing
            Dim OutletId As String = Nothing
            Dim NodeCounter As Integer = 0
            Dim OutletReferencesXmlNodeList As System.Xml.XmlNodeList = Nothing
            Dim MediaRFPOutletList As Generic.List(Of AdvantageFramework.Importing.Classes.MediaRFPOutlet) = Nothing

            ''
            OutletReferencesXmlNodeList = AvailLineXmlElement.GetElementsByTagName("OutletReferences")

            If OutletReferencesXmlNodeList.Count = 0 Then

                OutletReferencesXmlNodeList = AvailLineXmlElement.GetElementsByTagName("OutletReference") 'Canadian tv

            Else

                OutletReferencesXmlNodeList = AvailLineXmlElement.GetElementsByTagName("OutletReferences").Item(0).ChildNodes

            End If

            MediaRFPOutletList = New Generic.List(Of AdvantageFramework.Importing.Classes.MediaRFPOutlet)

            If IsCanadianRadio Then

                For Each StationElement In StationsXmlNodeList.OfType(Of System.Xml.XmlElement)

                    MediaRFPOutlet = New AdvantageFramework.Importing.Classes.MediaRFPOutlet()

                    MediaRFPOutlet.StationElementInnerText = StationElement.InnerText

                    If StationElement.InnerText.Contains("-") Then

                        MediaRFPOutlet.CallLetters = StationElement.InnerText.Substring(0, InStr(StationElement.InnerText, "-") - 1)
                        MediaRFPOutlet.Band = StationElement.InnerText.Substring(InStr(StationElement.InnerText, "-"))

                    Else

                        MediaRFPOutlet.CallLetters = StationElement.InnerText

                    End If

                    MediaRFPOutlet.IsCable = False

                    MediaRFPOutletList.Add(MediaRFPOutlet)

                Next

            ElseIf OutletReferencesXmlNodeList Is Nothing OrElse OutletReferencesXmlNodeList.Count = 0 Then

                Throw New Exception("Cannot find OutletReferences or OutletReference in file!")

            Else

                For Each OutletReferenceElement In OutletReferencesXmlNodeList.OfType(Of System.Xml.XmlElement)

                    If OutletReferenceElement.HasAttribute("outletFromProposalRef") AndAlso OutletReferenceElement.HasAttribute("outletForListId") Then

                        MediaRFPOutlet = New AdvantageFramework.Importing.Classes.MediaRFPOutlet(OutletReferenceElement.Attributes("outletFromProposalRef").Value, OutletReferenceElement.Attributes("outletForListId").Value)

                    ElseIf OutletReferenceElement.HasAttribute("outletRef") Then 'Canadian tv

                        MediaRFPOutlet = New AdvantageFramework.Importing.Classes.MediaRFPOutlet(OutletReferenceElement.Attributes("outletRef").Value, Nothing)

                    End If

                    If OutletReferenceElement.GetElementsByTagName("tvb-tp:CommentLine").Count = 1 Then

                        MediaRFPOutlet.HeaderComment = System.Web.HttpUtility.HtmlDecode(OutletReferenceElement.GetElementsByTagName("tvb-tp:CommentLine").Item(0).InnerText)

                    Else

                        MediaRFPOutlet.HeaderComment = String.Empty

                    End If

                    For Each StationElement In StationsXmlNodeList.OfType(Of System.Xml.XmlElement)

                        If StationElement.Attributes("outletId").Value = MediaRFPOutlet.OutletId Then

                            If StationElement.HasAttribute("callLetters") Then

                                MediaRFPOutlet.CallLetters = Trim(Replace(StationElement.Attributes("callLetters").Value, "+", ""))
                                MediaRFPOutlet.IsCable = False

                                If StationElement.HasAttribute("band") Then

                                    MediaRFPOutlet.Band = StationElement.Attributes("band").Value

                                End If

                            ElseIf StationElement.HasAttribute("network") Then

                                MediaRFPOutlet.CallLetters = Trim(StationElement.Attributes("network").Value)
                                MediaRFPOutlet.IsCable = True
                                MediaRFPOutlet.Syscode = StationElement.Attributes("syscode").Value

                            End If

                            If MediaRFPOutlet.CallLetters.Length > 4 AndAlso SchemaName.ToUpper <> "CanadianTVGAP".ToUpper Then

                                MediaRFPOutlet.CallLetters = MediaRFPOutlet.CallLetters.Substring(0, 4)

                            End If

                            Exit For

                        End If

                    Next

                    MediaRFPOutletList.Add(MediaRFPOutlet)

                Next

            End If

            ''
            XmlNodeList = AvailLineXmlElement.GetElementsByTagName("AvailLineWithDetailedPeriods")

            If XmlNodeList.Count = 0 Then

                XmlNodeList = AvailLineXmlElement.GetElementsByTagName("AvailLineWithPeriods")

            End If

            If XmlNodeList.Count = 0 Then

                XmlNodeList = AvailLineXmlElement.GetElementsByTagName("OfferLineWithDetailedPeriods") 'Canadian tv

            End If

            If XmlNodeList.Count = 0 Then

                XmlNodeList = AvailLineXmlElement.GetElementsByTagName("BuyLine") 'Canadian radio

            End If

            If XmlNodeList.Count = 0 Then

                Throw New Exception("There are no AvailLineWithDetailedPeriods or AvailLineWithPeriods or OfferLineWithDetailedPeriods or BuyLine present in the file.")

            End If

            RaiseEvent SetupImportingProgressEvent(0, If(XmlNodeList.Count = 1, 1, XmlNodeList.Count), 0)

            For Each XmlElement In XmlNodeList.OfType(Of System.Xml.XmlElement)

                MediaRFPHeader = Nothing

                If XmlElement.GetElementsByTagName("OutletReference").Count > 0 AndAlso XmlElement.GetElementsByTagName("OutletReference").Item(0).Attributes("outletFromListRef") IsNot Nothing Then

                    MediaRFPOutlet = MediaRFPOutletList.Where(Function(OL) OL.OutletForListId = XmlElement.GetElementsByTagName("OutletReference").Item(0).Attributes("outletFromListRef").Value).FirstOrDefault

                ElseIf MediaRFPOutletList.Count > 1 Then

                    If XmlElement.ParentNode IsNot Nothing AndAlso XmlElement.ParentNode.Name = "StationOffer" Then

                        For Each ChildNode As Xml.XmlElement In XmlElement.ParentNode.ChildNodes

                            If ChildNode.Name = "OutletReference" AndAlso ChildNode.HasAttribute("outletRef") Then

                                OutletId = ChildNode.Attributes("outletRef").Value
                                MediaRFPOutlet = MediaRFPOutletList.Where(Function(att) att.OutletId = OutletId).FirstOrDefault
                                Exit For

                            End If

                        Next

                    ElseIf XmlElement.ParentNode IsNot Nothing AndAlso XmlElement.ParentNode.Name = "StationOrder" Then

                        For Each ChildNode As Xml.XmlElement In XmlElement.ParentNode.ChildNodes

                            If ChildNode.Name = "rdo:Station" Then

                                MediaRFPOutlet = MediaRFPOutletList.Where(Function(T) T.StationElementInnerText = ChildNode.FirstChild.InnerText).FirstOrDefault
                                Exit For

                            End If

                        Next

                    End If

                ElseIf MediaRFPOutletList.Count = 1 Then 'Canadian tv/radio only has one

                    MediaRFPOutlet = MediaRFPOutletList.First

                End If

                If MediaRFPOutlet IsNot Nothing Then

                    MediaRFPHeader = GetMediaRFPHeader(DbContext, MediaRFPOutlet, ImportTemplate, MediaBroadcastWorksheetMarketID)

                    If MediaRFPHeader IsNot Nothing Then

                        If MediaRFPOutletList.Where(Function(OL) OL.MediaRFPHeaderID.HasValue AndAlso OL.MediaRFPHeaderID = MediaRFPHeader.ID AndAlso OL.BatchNumber.HasValue).Any Then

                            MediaRFPOutlet.BatchNumber = MediaRFPOutletList.Where(Function(OL) OL.MediaRFPHeaderID.HasValue AndAlso OL.MediaRFPHeaderID = MediaRFPHeader.ID AndAlso OL.BatchNumber.HasValue).First.BatchNumber

                        ElseIf (From Entity In AdvantageFramework.Database.Procedures.MediaRFPAvailLine.Load(DbContext)
                                Where Entity.MediaRFPHeaderID = MediaRFPHeader.ID
                                Select Entity.BatchNumber).Any Then

                            MediaRFPOutlet.BatchNumber = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPAvailLine.Load(DbContext)
                                                          Where Entity.MediaRFPHeaderID = MediaRFPHeader.ID
                                                          Select Entity.BatchNumber).Max + 1

                        Else

                            MediaRFPOutlet.BatchNumber = 1

                        End If

                        If Not MediaRFPOutletList.Where(Function(OL) OL.MediaRFPHeaderID.HasValue AndAlso OL.MediaRFPHeaderID = MediaRFPHeader.ID AndAlso OL.HeaderAddedUpdated).Any Then

                            MediaRFPHeader.Comments = MediaRFPOutlet.HeaderComment

                            If MediaRFPHeader.DbContext Is Nothing Then

                                DbContext.TryAttach(MediaRFPHeader)

                            End If

                            DbContext.Entry(MediaRFPHeader).State = Entity.EntityState.Modified
                            DbContext.SaveChanges()

                            AddMediaRFPHeaderStatus(DbContext, MediaRFPHeader)

                            MediaRFPOutlet.MediaRFPHeaderID = MediaRFPHeader.ID
                            MediaRFPOutlet.HeaderAddedUpdated = True

                        End If

                        If IsCanadianRadio Then

                            CreateMediaRFPDetailLinesCanadianRadio(DbContext, XmlElement, MediaRFPHeader, MediaRFPDemoList, DaypartList, MediaRFPOutlet)

                        Else

                            CreateMediaRFPDetailLines(DbContext, XmlElement, MediaRFPHeader, MediaRFPDemoList, DaypartList, MediaRFPOutlet)

                        End If

                    ElseIf Not MissingSyscodesCallLetters.Contains(MediaRFPOutlet.CallLetters) Then

                        MissingSyscodesCallLetters.Add(MediaRFPOutlet.CallLetters)

                    End If

                End If

                NodeCounter += 1

                RaiseEvent ImportingProgressUpdateEvent(NodeCounter)

            Next

        End Sub
        Private Sub CreateMediaRFPDetailLinesCanadianRadio(DbContext As AdvantageFramework.Database.DbContext, XmlElement As System.Xml.XmlElement, MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader,
                                                           MediaRFPDemoList As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo),
                                                           DaypartList As Generic.List(Of AdvantageFramework.Database.Entities.Daypart), MediaRFPOutlet As AdvantageFramework.Importing.Classes.MediaRFPOutlet)

            'objects
            Dim MediaRFPAvailLine As AdvantageFramework.Database.Entities.MediaRFPAvailLine = Nothing
            Dim SpotLength() As String = Nothing
            Dim DemoValuesXmlNodeList As System.Xml.XmlNodeList = Nothing
            Dim IDRank As String = Nothing
            Dim MediaRFPDemo As AdvantageFramework.Database.Entities.MediaRFPDemo = Nothing
            Dim MediaRFPDemoDTO As AdvantageFramework.DTO.Media.RFP.MediaRFPDemo = Nothing
            Dim SpotDate As Date = Nothing
            Dim Rate As Nullable(Of Decimal) = Nothing
            Dim MediaRFPAvailLineSpot As AdvantageFramework.Database.Entities.MediaRFPAvailLineSpot = Nothing
            Dim DetailPeriodXmlNodeList As System.Xml.XmlNodeList = Nothing
            Dim Spots As Integer = 0
            Dim RatingsXmlNodeList As System.Xml.XmlNodeList = Nothing

            MediaRFPAvailLine = New AdvantageFramework.Database.Entities.MediaRFPAvailLine

            MediaRFPAvailLine.MediaRFPHeaderID = MediaRFPHeader.ID

            If XmlElement.GetElementsByTagName("Program").Count = 1 Then 'Canadian radio

                MediaRFPAvailLine.Program = System.Web.HttpUtility.HtmlDecode(XmlElement.GetElementsByTagName("Program").Item(0).InnerText)

            End If

            If Not String.IsNullOrWhiteSpace(MediaRFPAvailLine.Program) AndAlso MediaRFPAvailLine.Program.Length > 100 Then

                MediaRFPAvailLine.Program = Mid(MediaRFPAvailLine.Program, 1, 100)

            End If

            If MediaRFPOutlet.IsCable Then

                MediaRFPAvailLine.CableNetworkStationCode = MediaRFPOutlet.CallLetters
                MediaRFPAvailLine.NetworkName = MediaRFPOutlet.CallLetters

            Else

                MediaRFPAvailLine.CallLetters = MediaRFPOutlet.CallLetters

            End If

            If Not String.IsNullOrWhiteSpace(MediaRFPAvailLine.CallLetters) AndAlso MediaRFPAvailLine.CallLetters.Length > 20 Then

                MediaRFPAvailLine.CallLetters = Mid(MediaRFPAvailLine.CallLetters, 1, 20)

            End If

            If XmlElement.GetElementsByTagName("DaypartName").Count > 0 Then

                MediaRFPAvailLine.DaypartName = XmlElement.GetElementsByTagName("DaypartName").Item(0).InnerText

            ElseIf XmlElement.GetElementsByTagName("brd:Daypart").Count = 1 Then

                MediaRFPAvailLine.DaypartName = XmlElement.GetElementsByTagName("brd:Daypart").Item(0).InnerText

            Else

                MediaRFPAvailLine.DaypartName = ""

            End If

            SetDaypartID(DbContext, MediaRFPAvailLine, DaypartList, MediaRFPHeader.VendorCode)

            If XmlElement.GetElementsByTagName("AvailName").Count > 0 Then

                MediaRFPAvailLine.AvailName = System.Web.HttpUtility.HtmlDecode(XmlElement.GetElementsByTagName("AvailName").Item(0).InnerText)

            Else

                MediaRFPAvailLine.AvailName = ""

            End If

            If MediaRFPAvailLine.AvailName.Length > 100 Then

                MediaRFPAvailLine.AvailName = Mid(MediaRFPAvailLine.AvailName, 1, 100)

            End If

            If XmlElement.GetElementsByTagName("brd:StartTime").Count > 0 Then 'Canadian radio

                MediaRFPAvailLine.StartTime = XmlElement.GetElementsByTagName("brd:StartTime").Item(0).InnerText

            End If

            If XmlElement.GetElementsByTagName("brd:EndTime").Count > 0 Then 'Canadian radio

                MediaRFPAvailLine.EndTime = XmlElement.GetElementsByTagName("brd:EndTime").Item(0).InnerText

            End If

            If Not String.IsNullOrWhiteSpace(MediaRFPAvailLine.StartTime) AndAlso MediaRFPAvailLine.StartTime.Length > 1 AndAlso CInt(MediaRFPAvailLine.StartTime.Substring(0, 2)) >= 24 Then

                MediaRFPAvailLine.StartTime = CInt(MediaRFPAvailLine.StartTime.Substring(0, 2)) - 24 & MediaRFPAvailLine.StartTime.Substring(2)

            End If

            If Not String.IsNullOrWhiteSpace(MediaRFPAvailLine.EndTime) AndAlso MediaRFPAvailLine.EndTime.Length > 1 AndAlso CInt(MediaRFPAvailLine.EndTime.Substring(0, 2)) >= 24 Then

                MediaRFPAvailLine.EndTime = CInt(MediaRFPAvailLine.EndTime.Substring(0, 2)) - 24 & MediaRFPAvailLine.EndTime.Substring(2)

            End If

            If IsDate(MediaRFPAvailLine.StartTime) Then

                MediaRFPAvailLine.StartTime = CDate(MediaRFPAvailLine.StartTime).ToString("hh:mm tt")
                MediaRFPAvailLine.StartHour = CShort(CDate(MediaRFPAvailLine.StartTime).ToString("HHmm"))

            End If

            If IsDate(MediaRFPAvailLine.EndTime) Then

                MediaRFPAvailLine.EndTime = CDate(MediaRFPAvailLine.EndTime).ToString("hh:mm tt")
                MediaRFPAvailLine.EndHour = CShort(CDate(MediaRFPAvailLine.EndTime).ToString("HHmm"))

            End If

            MediaRFPAvailLine.Sunday = If(XmlElement.GetElementsByTagName("brd:Sunday").Item(0).InnerText = "Y", True, False)
            MediaRFPAvailLine.Monday = If(XmlElement.GetElementsByTagName("brd:Monday").Item(0).InnerText = "Y", True, False)
            MediaRFPAvailLine.Tuesday = If(XmlElement.GetElementsByTagName("brd:Tuesday").Item(0).InnerText = "Y", True, False)
            MediaRFPAvailLine.Wednesday = If(XmlElement.GetElementsByTagName("brd:Wednesday").Item(0).InnerText = "Y", True, False)
            MediaRFPAvailLine.Thursday = If(XmlElement.GetElementsByTagName("brd:Thursday").Item(0).InnerText = "Y", True, False)
            MediaRFPAvailLine.Friday = If(XmlElement.GetElementsByTagName("brd:Friday").Item(0).InnerText = "Y", True, False)
            MediaRFPAvailLine.Saturday = If(XmlElement.GetElementsByTagName("brd:Saturday").Item(0).InnerText = "Y", True, False)

            If XmlElement.GetElementsByTagName("SpotLength").Count > 0 Then

                SpotLength = XmlElement.GetElementsByTagName("SpotLength").Item(0).InnerText.Split(":")

            End If

            If SpotLength.Length = 3 Then

                MediaRFPAvailLine.SpotLength = (SpotLength(0) * 3600) + (SpotLength(1) * 60) + SpotLength(2)

            ElseIf SpotLength.Length = 1 Then

                MediaRFPAvailLine.SpotLength = SpotLength(0)

            End If

            DetailPeriodXmlNodeList = XmlElement.GetElementsByTagName("brd:AirPeriod")

            If DetailPeriodXmlNodeList.Count = 0 Then

                Throw New Exception("There are no brd:AirPeriod data present in the file.")

            End If

            For Each DetailPeriodXmlElement In DetailPeriodXmlNodeList.OfType(Of System.Xml.XmlElement)

                If DetailPeriodXmlElement.GetElementsByTagName("brd:StartDate").Count = 1 Then

                    MediaRFPAvailLine.StartDate = DetailPeriodXmlElement.GetElementsByTagName("brd:StartDate").Item(0).InnerText

                End If

                If DetailPeriodXmlElement.GetElementsByTagName("brd:EndDate").Count = 1 Then

                    MediaRFPAvailLine.EndDate = DetailPeriodXmlElement.GetElementsByTagName("brd:EndDate").Item(0).InnerText

                End If

                If DetailPeriodXmlElement.GetElementsByTagName("brd:UnitRate").Count = 1 Then

                    Rate = DetailPeriodXmlElement.GetElementsByTagName("brd:UnitRate").Item(0).InnerText

                ElseIf Not Rate.HasValue Then

                    Rate = 0

                End If

                If DetailPeriodXmlElement.GetElementsByTagName("brd:SpotQuantity").Count = 1 Then

                    Spots = DetailPeriodXmlElement.GetElementsByTagName("brd:SpotQuantity").Item(0).InnerText

                Else

                    Spots = 0

                End If

                SpotDate = MediaRFPAvailLine.StartDate

                While SpotDate <= MediaRFPAvailLine.EndDate

                    MediaRFPAvailLineSpot = New AdvantageFramework.Database.Entities.MediaRFPAvailLineSpot
                    MediaRFPAvailLineSpot.DbContext = DbContext

                    MediaRFPAvailLineSpot.WeekDate = SpotDate
                    MediaRFPAvailLineSpot.Quantity = Spots
                    MediaRFPAvailLineSpot.Rate = Rate
                    MediaRFPAvailLine.MediaRFPAvailLineSpots.Add(MediaRFPAvailLineSpot)

                    SpotDate = DateAdd(DateInterval.Day, 7, SpotDate)

                End While

            Next

            If MediaRFPAvailLine.MediaRFPAvailLineSpots.Count > 0 Then

                MediaRFPAvailLine.StartDate = MediaRFPAvailLine.MediaRFPAvailLineSpots.Min(Function(S) S.WeekDate)
                MediaRFPAvailLine.EndDate = DateAdd(DateInterval.Day, 6, MediaRFPAvailLine.MediaRFPAvailLineSpots.Max(Function(S) S.WeekDate))

            End If

            MediaRFPAvailLine.BatchNumber = MediaRFPOutlet.BatchNumber.Value

            MediaRFPAvailLine.Status = AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus.H.ToString

            DemoValuesXmlNodeList = XmlElement.GetElementsByTagName("DemoValues")

            If DemoValuesXmlNodeList.Count = 0 Then

                MediaRFPDemo = New AdvantageFramework.Database.Entities.MediaRFPDemo
                MediaRFPDemo.DbContext = DbContext

                MediaRFPDemoDTO = MediaRFPDemoList.FirstOrDefault

                MediaRFPDemoDTO.SaveToEntity(MediaRFPDemo)

                MediaRFPDemo.Value = 0

                MediaRFPAvailLine.MediaRFPDemos.Add(MediaRFPDemo)

            Else

                For Each DemoXmlElement In DemoValuesXmlNodeList.OfType(Of System.Xml.XmlElement)

                    IDRank = DemoXmlElement.Attributes("demoIndex").Value

                    MediaRFPDemo = New AdvantageFramework.Database.Entities.MediaRFPDemo
                    MediaRFPDemo.DbContext = DbContext

                    MediaRFPDemoDTO = (From Entity In MediaRFPDemoList
                                       Where Entity.IDRank = IDRank
                                       Select Entity).FirstOrDefault

                    MediaRFPDemoDTO.SaveToEntity(MediaRFPDemo)

                    If DemoXmlElement.GetElementsByTagName("brd:Rating").Count > 0 Then

                        RatingsXmlNodeList = DemoXmlElement.GetElementsByTagName("brd:Rating")

                        If MediaRFPDemo.Type Is Nothing Then

                            MediaRFPDemo.Type = "RATING"

                            MediaRFPDemo.Value = RatingsXmlNodeList.Item(0).InnerText

                        End If

                    End If

                    MediaRFPAvailLine.MediaRFPDemos.Add(MediaRFPDemo)

                Next

            End If

            DbContext.MediaRFPAvailLines.Add(MediaRFPAvailLine)

            DbContext.SaveChanges()

        End Sub
        Private Function ImportCanadianTVContract(XmlDocument As System.Xml.XmlDocument, DbContext As AdvantageFramework.Database.DbContext, ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                  MediaBroadcastWorksheetMarketID As Integer, MediaRFPDemoList As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo), ByRef MissingSyscodesCallLetters As Generic.List(Of String)) As Boolean

            'objects
            Dim StationsXmlNodeList As System.Xml.XmlNodeList = Nothing
            Dim XmlNodeList As System.Xml.XmlNodeList = Nothing
            Dim MediaRFPOutlet As AdvantageFramework.Importing.Classes.MediaRFPOutlet = Nothing
            Dim MediaRFPOutletList As Generic.List(Of AdvantageFramework.Importing.Classes.MediaRFPOutlet) = Nothing
            Dim MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader = Nothing
            Dim SourceVendorCode As String = Nothing
            Dim VendorCrossReference As AdvantageFramework.Database.Entities.VendorCrossReference = Nothing
            Dim NodeCounter As Integer = 0

            MediaRFPOutlet = New AdvantageFramework.Importing.Classes.MediaRFPOutlet()

            MediaRFPOutletList = New Generic.List(Of AdvantageFramework.Importing.Classes.MediaRFPOutlet)

            StationsXmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("Station") 'should only be 1 by design

            For Each StationElement In StationsXmlNodeList.OfType(Of System.Xml.XmlElement)

                If StationElement.HasAttributes AndAlso StationElement.Attributes(0).Name = "name" Then

                    MediaRFPOutlet.CallLetters = StationElement.Attributes(0).Value

                End If

                MediaRFPOutlet.IsCable = False

            Next

            MediaRFPOutletList.Add(MediaRFPOutlet)

            XmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("ContractLine")

            RaiseEvent SetupImportingProgressEvent(0, If(XmlNodeList.Count = 1, 1, XmlNodeList.Count), 0)

            For Each XmlElement In XmlNodeList.OfType(Of System.Xml.XmlElement)

                MediaRFPHeader = Nothing

                SourceVendorCode = MediaRFPOutlet.CallLetters.ToUpper '& If(String.IsNullOrWhiteSpace(MediaRFPOutlet.Band), "", MediaRFPOutlet.Band).ToUpper

                If ImportTemplate IsNot Nothing AndAlso ImportTemplate.RecordSourceID.HasValue Then

                    If (From VCR In AdvantageFramework.Database.Procedures.VendorCrossReference.LoadByRecordSourceID(DbContext, ImportTemplate.RecordSourceID.Value)
                        Where VCR.SourceVendorCode.ToUpper = SourceVendorCode
                        Select VCR).Count = 1 Then

                        VendorCrossReference = (From VCR In AdvantageFramework.Database.Procedures.VendorCrossReference.LoadByRecordSourceID(DbContext, ImportTemplate.RecordSourceID.Value)
                                                Where VCR.SourceVendorCode.ToUpper = SourceVendorCode
                                                Select VCR).SingleOrDefault

                        If VendorCrossReference IsNot Nothing Then

                            MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                              Where Entity.VendorCode.ToUpper = VendorCrossReference.VendorCode.ToUpper
                                              Select Entity).SingleOrDefault

                        End If

                    End If

                End If

                If MediaRFPHeader Is Nothing Then

                    If (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                        Where Entity.Vendor.VendorCodeCrossReference.ToUpper = SourceVendorCode
                        Select Entity).Count = 1 Then

                        MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                          Where Entity.Vendor.VendorCodeCrossReference.ToUpper = SourceVendorCode
                                          Select Entity).SingleOrDefault

                    End If

                End If

                If MediaRFPHeader Is Nothing Then

                    If MediaRFPOutlet.CallLetters.Length = 3 Then

                        If (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                            Where Entity.VendorCode.Substring(0, 3).ToUpper = MediaRFPOutlet.CallLetters.ToUpper
                            Select Entity).Count = 1 Then

                            MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                              Where Entity.VendorCode.Substring(0, 3).ToUpper = MediaRFPOutlet.CallLetters.ToUpper
                                              Select Entity).SingleOrDefault

                        ElseIf Not String.IsNullOrWhiteSpace(MediaRFPOutlet.Band) Then

                            MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                              Where Entity.VendorCode.Substring(0, 4).ToUpper = MediaRFPOutlet.CallLetters.ToUpper & Mid(MediaRFPOutlet.Band.ToUpper, 1, 1)
                                              Select Entity).SingleOrDefault

                        End If

                    ElseIf MediaRFPOutlet.CallLetters.Length = 4 Then

                        If (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                            Where Entity.VendorCode.Substring(0, 4).ToUpper = MediaRFPOutlet.CallLetters.ToUpper
                            Select Entity).Count = 1 Then

                            MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                              Where Entity.VendorCode.Substring(0, 4).ToUpper = MediaRFPOutlet.CallLetters.ToUpper
                                              Select Entity).SingleOrDefault

                        ElseIf Not String.IsNullOrWhiteSpace(MediaRFPOutlet.Band) Then

                            MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                              Where Entity.VendorCode.Substring(0, 5).ToUpper = MediaRFPOutlet.CallLetters.ToUpper & Mid(MediaRFPOutlet.Band.ToUpper, 1, 1)
                                              Select Entity).SingleOrDefault

                        End If

                    End If

                End If

                If MediaRFPHeader IsNot Nothing Then

                    If MediaRFPOutletList.Where(Function(OL) OL.MediaRFPHeaderID.HasValue AndAlso OL.MediaRFPHeaderID = MediaRFPHeader.ID AndAlso OL.BatchNumber.HasValue).Any Then

                        MediaRFPOutlet.BatchNumber = MediaRFPOutletList.Where(Function(OL) OL.MediaRFPHeaderID.HasValue AndAlso OL.MediaRFPHeaderID = MediaRFPHeader.ID AndAlso OL.BatchNumber.HasValue).First.BatchNumber

                    ElseIf (From Entity In AdvantageFramework.Database.Procedures.MediaRFPAvailLine.Load(DbContext)
                            Where Entity.MediaRFPHeaderID = MediaRFPHeader.ID
                            Select Entity.BatchNumber).Any Then

                        MediaRFPOutlet.BatchNumber = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPAvailLine.Load(DbContext)
                                                      Where Entity.MediaRFPHeaderID = MediaRFPHeader.ID
                                                      Select Entity.BatchNumber).Max + 1

                    Else

                        MediaRFPOutlet.BatchNumber = 1

                    End If

                    If Not MediaRFPOutletList.Where(Function(OL) OL.MediaRFPHeaderID.HasValue AndAlso OL.MediaRFPHeaderID = MediaRFPHeader.ID AndAlso OL.HeaderAddedUpdated).Any Then

                        MediaRFPHeader.Comments = MediaRFPOutlet.HeaderComment

                        If MediaRFPHeader.DbContext Is Nothing Then

                            DbContext.TryAttach(MediaRFPHeader)

                        End If

                        DbContext.Entry(MediaRFPHeader).State = Entity.EntityState.Modified
                        DbContext.SaveChanges()

                        AddMediaRFPHeaderStatus(DbContext, MediaRFPHeader)

                        MediaRFPOutlet.MediaRFPHeaderID = MediaRFPHeader.ID
                        MediaRFPOutlet.HeaderAddedUpdated = True

                    End If

                    CanadianTVContractCreateMediaRFPDetailLines(DbContext, XmlElement, MediaRFPHeader, MediaRFPOutlet, MediaRFPDemoList)

                ElseIf Not MissingSyscodesCallLetters.Contains(MediaRFPOutlet.CallLetters) Then

                    MissingSyscodesCallLetters.Add(MediaRFPOutlet.CallLetters)

                End If

                NodeCounter += 1

                RaiseEvent ImportingProgressUpdateEvent(NodeCounter)

            Next

            ImportCanadianTVContract = True

        End Function
        Private Sub CanadianTVContractCreateMediaRFPDetailLines(DbContext As AdvantageFramework.Database.DbContext, XmlElement As System.Xml.XmlElement, MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader,
                                                                MediaRFPOutlet As AdvantageFramework.Importing.Classes.MediaRFPOutlet, MediaRFPDemoList As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo))

            'objects
            Dim MediaRFPAvailLine As AdvantageFramework.Database.Entities.MediaRFPAvailLine = Nothing
            Dim SpotLength() As String = Nothing
            Dim DemoValuesXmlNodeList As System.Xml.XmlNodeList = Nothing
            Dim IDRank As String = Nothing
            Dim MediaRFPDemo As AdvantageFramework.Database.Entities.MediaRFPDemo = Nothing
            Dim MediaRFPDemoDTO As AdvantageFramework.DTO.Media.RFP.MediaRFPDemo = Nothing
            Dim SpotDate As Date = Nothing
            Dim Rate As Nullable(Of Decimal) = Nothing
            Dim MediaRFPAvailLineSpot As AdvantageFramework.Database.Entities.MediaRFPAvailLineSpot = Nothing
            Dim DetailPeriodXmlNodeList As System.Xml.XmlNodeList = Nothing
            Dim Spots As Integer = 0
            Dim DayTimeXmlNode As System.Xml.XmlNode = Nothing
            Dim IDRankUsed As Generic.List(Of String) = Nothing

            IDRankUsed = New Generic.List(Of String)

            MediaRFPAvailLine = New AdvantageFramework.Database.Entities.MediaRFPAvailLine

            MediaRFPAvailLine.MediaRFPHeaderID = MediaRFPHeader.ID

            If XmlElement.GetElementsByTagName("ProgramDescription").Count = 1 Then

                MediaRFPAvailLine.Program = System.Web.HttpUtility.HtmlDecode(XmlElement.GetElementsByTagName("ProgramDescription").Item(0).InnerText)

            End If

            If Not String.IsNullOrWhiteSpace(MediaRFPAvailLine.Program) AndAlso MediaRFPAvailLine.Program.Length > 100 Then

                MediaRFPAvailLine.Program = Mid(MediaRFPAvailLine.Program, 1, 100)

            End If

            If MediaRFPOutlet.IsCable Then

                MediaRFPAvailLine.CableNetworkStationCode = MediaRFPOutlet.CallLetters
                MediaRFPAvailLine.NetworkName = MediaRFPOutlet.CallLetters

            Else

                MediaRFPAvailLine.CallLetters = MediaRFPOutlet.CallLetters

            End If

            If Not String.IsNullOrWhiteSpace(MediaRFPAvailLine.CallLetters) AndAlso MediaRFPAvailLine.CallLetters.Length > 20 Then

                MediaRFPAvailLine.CallLetters = Mid(MediaRFPAvailLine.CallLetters, 1, 20)

            End If

            If XmlElement.GetElementsByTagName("DaypartName").Count > 0 Then

                MediaRFPAvailLine.DaypartName = XmlElement.GetElementsByTagName("DaypartName").Item(0).InnerText

            Else

                MediaRFPAvailLine.DaypartName = ""

            End If

            'SetDaypartID(DbContext, MediaRFPAvailLine, DaypartList, MediaRFPHeader.VendorCode)

            If XmlElement.GetElementsByTagName("AvailName").Count > 0 Then

                MediaRFPAvailLine.AvailName = System.Web.HttpUtility.HtmlDecode(XmlElement.GetElementsByTagName("AvailName").Item(0).InnerText)

            Else

                MediaRFPAvailLine.AvailName = ""

            End If

            If Not String.IsNullOrWhiteSpace(MediaRFPAvailLine.AvailName) AndAlso MediaRFPAvailLine.AvailName.Length > 100 Then

                MediaRFPAvailLine.AvailName = Mid(MediaRFPAvailLine.AvailName, 1, 100)

            End If

            If XmlElement.GetElementsByTagName("DayTime").Count = 1 Then

                DayTimeXmlNode = XmlElement.GetElementsByTagName("DayTime").Item(0)

                For i As Integer = 0 To DayTimeXmlNode.ChildNodes.Count - 1

                    If DayTimeXmlNode.ChildNodes.Item(i).Name = "tv:StartTime" Then

                        MediaRFPAvailLine.StartTime = DayTimeXmlNode.ChildNodes(i).InnerText

                    End If

                    If DayTimeXmlNode.ChildNodes.Item(i).Name = "tv:EndTime" Then

                        MediaRFPAvailLine.EndTime = DayTimeXmlNode.ChildNodes(i).InnerText

                    End If

                Next

            End If

            If Not String.IsNullOrWhiteSpace(MediaRFPAvailLine.StartTime) AndAlso MediaRFPAvailLine.StartTime.Length > 1 AndAlso CInt(MediaRFPAvailLine.StartTime.Substring(0, 2)) >= 24 Then

                MediaRFPAvailLine.StartTime = CInt(MediaRFPAvailLine.StartTime.Substring(0, 2)) - 24 & MediaRFPAvailLine.StartTime.Substring(2)

            End If

            If Not String.IsNullOrWhiteSpace(MediaRFPAvailLine.EndTime) AndAlso MediaRFPAvailLine.EndTime.Length > 1 AndAlso CInt(MediaRFPAvailLine.EndTime.Substring(0, 2)) >= 24 Then

                MediaRFPAvailLine.EndTime = CInt(MediaRFPAvailLine.EndTime.Substring(0, 2)) - 24 & MediaRFPAvailLine.EndTime.Substring(2)

            End If

            If IsDate(MediaRFPAvailLine.StartTime) Then

                MediaRFPAvailLine.StartTime = CDate(MediaRFPAvailLine.StartTime).ToString("hh:mm tt")
                MediaRFPAvailLine.StartHour = CShort(CDate(MediaRFPAvailLine.StartTime).ToString("HHmm"))

            End If

            If IsDate(MediaRFPAvailLine.EndTime) Then

                MediaRFPAvailLine.EndTime = CDate(MediaRFPAvailLine.EndTime).ToString("hh:mm tt")
                MediaRFPAvailLine.EndHour = CShort(CDate(MediaRFPAvailLine.EndTime).ToString("HHmm"))

            End If

            MediaRFPAvailLine.Sunday = If(XmlElement.GetElementsByTagName("tvb-tp:Sunday").Item(0).InnerText = "Y", True, False)
            MediaRFPAvailLine.Monday = If(XmlElement.GetElementsByTagName("tvb-tp:Monday").Item(0).InnerText = "Y", True, False)
            MediaRFPAvailLine.Tuesday = If(XmlElement.GetElementsByTagName("tvb-tp:Tuesday").Item(0).InnerText = "Y", True, False)
            MediaRFPAvailLine.Wednesday = If(XmlElement.GetElementsByTagName("tvb-tp:Wednesday").Item(0).InnerText = "Y", True, False)
            MediaRFPAvailLine.Thursday = If(XmlElement.GetElementsByTagName("tvb-tp:Thursday").Item(0).InnerText = "Y", True, False)
            MediaRFPAvailLine.Friday = If(XmlElement.GetElementsByTagName("tvb-tp:Friday").Item(0).InnerText = "Y", True, False)
            MediaRFPAvailLine.Saturday = If(XmlElement.GetElementsByTagName("tvb-tp:Saturday").Item(0).InnerText = "Y", True, False)

            If XmlElement.GetElementsByTagName("tvb-tp:CommentLine").Count = 1 Then

                If System.Web.HttpUtility.HtmlDecode(XmlElement.GetElementsByTagName("tvb-tp:CommentLine").Item(0).InnerText).StartsWith("TP" & Chr(127)) Then

                    MediaRFPAvailLine.Comments = System.Web.HttpUtility.HtmlDecode(XmlElement.GetElementsByTagName("tvb-tp:CommentLine").Item(0).InnerText).Substring(3)

                Else

                    MediaRFPAvailLine.Comments = System.Web.HttpUtility.HtmlDecode(XmlElement.GetElementsByTagName("tvb-tp:CommentLine").Item(0).InnerText)

                End If

            End If

            If XmlElement.GetElementsByTagName("SpotLength").Count > 0 Then

                SpotLength = XmlElement.GetElementsByTagName("SpotLength").Item(0).InnerText.Split(":")

            End If

            If SpotLength.Length = 3 Then

                MediaRFPAvailLine.SpotLength = (SpotLength(0) * 3600) + (SpotLength(1) * 60) + SpotLength(2)

            End If

            If XmlElement.GetElementsByTagName("Rate").Count > 0 Then

                Rate = XmlElement.GetElementsByTagName("Rate").Item(0).InnerText

            End If

            DetailPeriodXmlNodeList = XmlElement.GetElementsByTagName("Period")

            If DetailPeriodXmlNodeList.Count = 0 Then

                Throw New Exception("There are no Period data present in the file.")

            End If

            For Each DetailPeriodXmlElement In DetailPeriodXmlNodeList.OfType(Of System.Xml.XmlElement)

                MediaRFPAvailLine.StartDate = DetailPeriodXmlElement.Attributes("startDate").Value
                MediaRFPAvailLine.EndDate = DetailPeriodXmlElement.Attributes("endDate").Value

                SpotDate = MediaRFPAvailLine.StartDate

                While SpotDate <= MediaRFPAvailLine.EndDate

                    MediaRFPAvailLineSpot = New AdvantageFramework.Database.Entities.MediaRFPAvailLineSpot
                    MediaRFPAvailLineSpot.DbContext = DbContext

                    MediaRFPAvailLineSpot.WeekDate = SpotDate
                    MediaRFPAvailLineSpot.Quantity = DetailPeriodXmlElement.ChildNodes.Count
                    MediaRFPAvailLineSpot.Rate = Rate
                    MediaRFPAvailLine.MediaRFPAvailLineSpots.Add(MediaRFPAvailLineSpot)

                    SpotDate = DateAdd(DateInterval.Day, 7, SpotDate)

                End While

            Next

            If MediaRFPAvailLine.MediaRFPAvailLineSpots.Count > 0 Then

                MediaRFPAvailLine.StartDate = MediaRFPAvailLine.MediaRFPAvailLineSpots.Min(Function(S) S.WeekDate)
                MediaRFPAvailLine.EndDate = DateAdd(DateInterval.Day, 6, MediaRFPAvailLine.MediaRFPAvailLineSpots.Max(Function(S) S.WeekDate))

            End If

            MediaRFPAvailLine.BatchNumber = MediaRFPOutlet.BatchNumber.Value

            MediaRFPAvailLine.Status = AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus.H.ToString

            DemoValuesXmlNodeList = XmlElement.GetElementsByTagName("DemoValue")

            If DemoValuesXmlNodeList.Count = 0 Then

                MediaRFPDemo = New AdvantageFramework.Database.Entities.MediaRFPDemo
                MediaRFPDemo.DbContext = DbContext

                MediaRFPDemoDTO = MediaRFPDemoList.FirstOrDefault

                MediaRFPDemoDTO.SaveToEntity(MediaRFPDemo)

                MediaRFPDemo.Value = 0

                MediaRFPAvailLine.MediaRFPDemos.Add(MediaRFPDemo)

            Else

                For Each DemoXmlElement In DemoValuesXmlNodeList.OfType(Of System.Xml.XmlElement)

                    IDRank = DemoXmlElement.Attributes("demoRef").Value

                    If IDRankUsed.Contains(IDRank) = False Then 'only use the first one of eachy

                        MediaRFPDemo = New AdvantageFramework.Database.Entities.MediaRFPDemo
                        MediaRFPDemo.DbContext = DbContext

                        MediaRFPDemoDTO = (From Entity In MediaRFPDemoList
                                           Where Entity.IDRank = IDRank
                                           Select Entity).FirstOrDefault

                        MediaRFPDemoDTO.SaveToEntity(MediaRFPDemo)

                        If MediaRFPDemo.Type.ToUpper.StartsWith("IMPRESSION") Then

                            If MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "T" Then

                                MediaRFPDemo.Value = DemoXmlElement.InnerText * 1000

                            ElseIf MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "R" Then

                                MediaRFPDemo.Value = DemoXmlElement.InnerText * 10

                            End If

                        Else

                            If IsNumeric(DemoXmlElement.InnerText) Then

                                MediaRFPDemo.Value = DemoXmlElement.InnerText

                            Else

                                MediaRFPDemo.Value = 0

                            End If

                        End If

                        MediaRFPAvailLine.MediaRFPDemos.Add(MediaRFPDemo)

                        IDRankUsed.Add(IDRank)

                    End If

                Next

            End If

            DbContext.MediaRFPAvailLines.Add(MediaRFPAvailLine)

            DbContext.SaveChanges()

        End Sub
        'Private Function ImportCanadianTVGAP(XmlDocument As System.Xml.XmlDocument, DbContext As AdvantageFramework.Database.DbContext, ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
        '                                     MediaBroadcastWorksheetMarketID As Integer, MediaRFPDemoList As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo), DaypartList As Generic.List(Of AdvantageFramework.Database.Entities.Daypart),
        '                                     MediaRFPHeaderID As Integer) As Boolean

        '    'objects
        '    Dim MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader = Nothing
        '    Dim MediaRFPOutletList As Generic.List(Of AdvantageFramework.Importing.Classes.MediaRFPOutlet) = Nothing
        '    Dim MarketsXmlNodeList As System.Xml.XmlNodeList = Nothing
        '    Dim MarketDictionary As Dictionary(Of String, String) = Nothing
        '    Dim StationsXmlNodeList As System.Xml.XmlNodeList = Nothing
        '    Dim MediaRFPOutlet As AdvantageFramework.Importing.Classes.MediaRFPOutlet = Nothing
        '    Dim OutletReferencesXmlNodeList As System.Xml.XmlNodeList = Nothing
        '    Dim XmlNodeList As System.Xml.XmlNodeList = Nothing
        '    Dim NodeCounter As Integer = 0
        '    Dim OutletId As String = Nothing

        '    MediaRFPHeader = AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByID(DbContext, MediaRFPHeaderID)

        '    MediaRFPOutletList = New Generic.List(Of AdvantageFramework.Importing.Classes.MediaRFPOutlet)

        '    MarketsXmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("Market")

        '    MarketDictionary = New Dictionary(Of String, String)

        '    For Each MarketElement In MarketsXmlNodeList.OfType(Of System.Xml.XmlElement)

        '        If MarketElement.HasAttribute("name") AndAlso MarketElement.HasAttribute("marketId") Then

        '            MarketDictionary.Add(MarketElement.Attributes("marketId").Value, MarketElement.Attributes("name").Value)

        '        End If

        '    Next

        '    StationsXmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("Station")

        '    For Each StationElement In StationsXmlNodeList.OfType(Of System.Xml.XmlElement)

        '        If StationElement.HasAttributes AndAlso StationElement.Attributes(0).Name = "callLetters" Then

        '            MediaRFPOutlet = New AdvantageFramework.Importing.Classes.MediaRFPOutlet()

        '            MediaRFPOutlet.CallLetters = StationElement.Attributes(0).Value

        '            MediaRFPOutlet.IsCable = False

        '            MediaRFPOutletList.Add(MediaRFPOutlet)

        '        End If

        '    Next

        '    OutletReferencesXmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("OutletReference")

        '    For Each OutletReferenceElement In OutletReferencesXmlNodeList.OfType(Of System.Xml.XmlElement)

        '        If OutletReferenceElement.HasAttribute("outletRef") Then

        '            MediaRFPOutlet = New AdvantageFramework.Importing.Classes.MediaRFPOutlet(OutletReferenceElement.Attributes("outletRef").Value, Nothing)

        '        End If

        '        For Each StationElement In StationsXmlNodeList.OfType(Of System.Xml.XmlElement)

        '            If StationElement.Attributes("outletId").Value = MediaRFPOutlet.OutletId Then

        '                If StationElement.HasAttribute("callLetters") Then

        '                    MediaRFPOutlet.CallLetters = Trim(Replace(StationElement.Attributes("callLetters").Value, "+", ""))
        '                    MediaRFPOutlet.IsCable = False

        '                    If StationElement.HasAttribute("band") Then

        '                        MediaRFPOutlet.Band = StationElement.Attributes("band").Value

        '                    End If

        '                ElseIf StationElement.HasAttribute("network") Then

        '                    MediaRFPOutlet.CallLetters = Trim(StationElement.Attributes("network").Value)
        '                    MediaRFPOutlet.IsCable = True
        '                    MediaRFPOutlet.Syscode = StationElement.Attributes("syscode").Value

        '                End If

        '                Exit For

        '            End If

        '        Next

        '        MediaRFPOutletList.Add(MediaRFPOutlet)

        '    Next

        '    XmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("OfferLineWithDetailedPeriods")

        '    RaiseEvent SetupImportingProgressEvent(0, If(XmlNodeList.Count = 1, 1, XmlNodeList.Count), 0)

        '    For Each XmlElement In XmlNodeList.OfType(Of System.Xml.XmlElement)

        '        If XmlElement.GetElementsByTagName("OutletReference").Count > 0 AndAlso XmlElement.GetElementsByTagName("OutletReference").Item(0).Attributes("outletFromListRef") IsNot Nothing Then

        '            MediaRFPOutlet = MediaRFPOutletList.Where(Function(OL) OL.OutletForListId = XmlElement.GetElementsByTagName("OutletReference").Item(0).Attributes("outletFromListRef").Value).FirstOrDefault

        '        ElseIf MediaRFPOutletList.Count > 1 Then

        '            If XmlElement.ParentNode IsNot Nothing AndAlso XmlElement.ParentNode.Name = "StationOffer" Then

        '                For Each ChildNode As Xml.XmlElement In XmlElement.ParentNode.ChildNodes

        '                    If ChildNode.Name = "OutletReference" AndAlso ChildNode.HasAttribute("outletRef") Then

        '                        OutletId = ChildNode.Attributes("outletRef").Value
        '                        MediaRFPOutlet = MediaRFPOutletList.Where(Function(att) att.OutletId = OutletId).FirstOrDefault
        '                        Exit For

        '                    End If

        '                Next

        '            End If

        '        ElseIf MediaRFPOutletList.Count = 1 Then

        '            MediaRFPOutlet = MediaRFPOutletList.First

        '        End If

        '        If MediaRFPOutlet IsNot Nothing Then

        '            If MediaRFPHeader IsNot Nothing Then

        '                If MediaRFPOutletList.Where(Function(OL) OL.MediaRFPHeaderID.HasValue AndAlso OL.MediaRFPHeaderID = MediaRFPHeader.ID AndAlso OL.BatchNumber.HasValue).Any Then

        '                    MediaRFPOutlet.BatchNumber = MediaRFPOutletList.Where(Function(OL) OL.MediaRFPHeaderID.HasValue AndAlso OL.MediaRFPHeaderID = MediaRFPHeader.ID AndAlso OL.BatchNumber.HasValue).First.BatchNumber

        '                ElseIf (From Entity In AdvantageFramework.Database.Procedures.MediaRFPAvailLine.Load(DbContext)
        '                        Where Entity.MediaRFPHeaderID = MediaRFPHeader.ID
        '                        Select Entity.BatchNumber).Any Then

        '                    MediaRFPOutlet.BatchNumber = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPAvailLine.Load(DbContext)
        '                                                  Where Entity.MediaRFPHeaderID = MediaRFPHeader.ID
        '                                                  Select Entity.BatchNumber).Max + 1

        '                Else

        '                    MediaRFPOutlet.BatchNumber = 1

        '                End If

        '                If Not MediaRFPOutletList.Where(Function(OL) OL.MediaRFPHeaderID.HasValue AndAlso OL.MediaRFPHeaderID = MediaRFPHeader.ID AndAlso OL.HeaderAddedUpdated).Any Then

        '                    MediaRFPHeader.Comments = MediaRFPOutlet.HeaderComment

        '                    If MediaRFPHeader.DbContext Is Nothing Then

        '                        DbContext.TryAttach(MediaRFPHeader)

        '                    End If

        '                    DbContext.Entry(MediaRFPHeader).State = Entity.EntityState.Modified
        '                    DbContext.SaveChanges()

        '                    AddMediaRFPHeaderStatus(DbContext, MediaRFPHeader)

        '                    MediaRFPOutlet.MediaRFPHeaderID = MediaRFPHeader.ID
        '                    MediaRFPOutlet.HeaderAddedUpdated = True

        '                End If

        '                'If IsCanadianRadio Then

        '                '    CreateMediaRFPDetailLinesCanadianRadio(DbContext, XmlElement, MediaRFPHeader, MediaRFPDemoList, DaypartList, MediaRFPOutlet)

        '                'Else

        '                CreateMediaRFPDetailLines(DbContext, XmlElement, MediaRFPHeader, MediaRFPDemoList, DaypartList, MediaRFPOutlet, MarketDictionary)

        '                'End If

        '            End If

        '        End If

        '        NodeCounter += 1

        '        RaiseEvent ImportingProgressUpdateEvent(NodeCounter)

        '    Next

        '    ImportCanadianTVGAP = True

        'End Function
        Private Function ImportCanadianTVGAP(XmlDocument As System.Xml.XmlDocument, Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext, ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                             MediaBroadcastWorksheetMarketID As Integer, MediaRFPDemoList As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo), DaypartList As Generic.List(Of AdvantageFramework.Database.Entities.Daypart),
                                             ByRef MissingSyscodesCallLetters As Generic.List(Of String)) As Boolean

            'objects
            Dim MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim MediaRFPOutletList As Generic.List(Of AdvantageFramework.Importing.Classes.MediaRFPOutlet) = Nothing
            Dim MarketsXmlNodeList As System.Xml.XmlNodeList = Nothing
            Dim MarketDictionary As Dictionary(Of String, String) = Nothing
            Dim StationsXmlNodeList As System.Xml.XmlNodeList = Nothing
            Dim MediaRFPOutlet As AdvantageFramework.Importing.Classes.MediaRFPOutlet = Nothing
            Dim OutletReferencesXmlNodeList As System.Xml.XmlNodeList = Nothing
            Dim XmlNodeList As System.Xml.XmlNodeList = Nothing
            Dim NodeCounter As Integer = 0
            Dim OutletId As String = Nothing
            Dim StationOfferXmlNodeList As System.Xml.XmlNodeList = Nothing

            MediaRFPOutletList = New Generic.List(Of AdvantageFramework.Importing.Classes.MediaRFPOutlet)

            MarketsXmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("Market")

            MarketDictionary = New Dictionary(Of String, String)

            For Each MarketElement In MarketsXmlNodeList.OfType(Of System.Xml.XmlElement)

                If MarketElement.HasAttribute("name") AndAlso MarketElement.HasAttribute("marketId") Then

                    MarketDictionary.Add(MarketElement.Attributes("marketId").Value, MarketElement.Attributes("name").Value)

                End If

            Next

            StationsXmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("Station")

            For Each StationElement In StationsXmlNodeList.OfType(Of System.Xml.XmlElement)

                If StationElement.HasAttribute("callLetters") AndAlso StationElement.HasAttribute("outletId") Then

                    Vendor = GetVendorByCallLetterHierarchy(Session, DbContext, ImportTemplate, StationElement.Attributes(0).Value, "", StationElement.Attributes(0).Value)

                    If Vendor IsNot Nothing Then

                        MediaRFPOutlet = New AdvantageFramework.Importing.Classes.MediaRFPOutlet()

                        MediaRFPOutlet.CallLetters = StationElement.Attributes("callLetters").Value

                        MediaRFPOutlet.OutletId = StationElement.Attributes("outletId").Value

                        MediaRFPOutlet.CanadianVendorCode = Vendor.Code

                        MediaRFPOutlet.IsCable = False

                        MediaRFPOutletList.Add(MediaRFPOutlet)

                    Else

                        MissingSyscodesCallLetters.Add(StationElement.Attributes(0).Value)

                    End If

                End If

            Next

            StationOfferXmlNodeList = XmlDocument.DocumentElement.GetElementsByTagName("StationOffer")

            RaiseEvent SetupImportingProgressEvent(0, If(StationOfferXmlNodeList.Count = 1, 1, StationOfferXmlNodeList.Count), 0)

            For Each StationOfferElement In StationOfferXmlNodeList.OfType(Of System.Xml.XmlElement)

                OutletReferencesXmlNodeList = StationOfferElement.GetElementsByTagName("OutletReference")

                For Each OutletReferenceElement In OutletReferencesXmlNodeList.OfType(Of System.Xml.XmlElement)

                    If OutletReferenceElement.HasAttribute("outletRef") Then

                        MediaRFPOutlet = MediaRFPOutletList.Where(Function(Entity) Entity.OutletId = OutletReferenceElement.Attributes("outletRef").Value).SingleOrDefault

                        If MediaRFPOutlet IsNot Nothing Then

                            MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                              Where Entity.VendorCode = MediaRFPOutlet.CanadianVendorCode
                                              Select Entity).SingleOrDefault

                            If MediaRFPHeader IsNot Nothing Then

                                XmlNodeList = StationOfferElement.GetElementsByTagName("OfferLineWithDetailedPeriods")

                                For Each XmlElement In XmlNodeList.OfType(Of System.Xml.XmlElement)

                                    If MediaRFPOutletList.Where(Function(OL) OL.MediaRFPHeaderID.HasValue AndAlso OL.MediaRFPHeaderID = MediaRFPHeader.ID AndAlso OL.BatchNumber.HasValue).Any Then

                                        MediaRFPOutlet.BatchNumber = MediaRFPOutletList.Where(Function(OL) OL.MediaRFPHeaderID.HasValue AndAlso OL.MediaRFPHeaderID = MediaRFPHeader.ID AndAlso OL.BatchNumber.HasValue).First.BatchNumber

                                    ElseIf (From Entity In AdvantageFramework.Database.Procedures.MediaRFPAvailLine.Load(DbContext)
                                            Where Entity.MediaRFPHeaderID = MediaRFPHeader.ID
                                            Select Entity.BatchNumber).Any Then

                                        MediaRFPOutlet.BatchNumber = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPAvailLine.Load(DbContext)
                                                                      Where Entity.MediaRFPHeaderID = MediaRFPHeader.ID
                                                                      Select Entity.BatchNumber).Max + 1

                                    Else

                                        MediaRFPOutlet.BatchNumber = 1

                                    End If

                                    If Not MediaRFPOutletList.Where(Function(OL) OL.MediaRFPHeaderID.HasValue AndAlso OL.MediaRFPHeaderID = MediaRFPHeader.ID AndAlso OL.HeaderAddedUpdated).Any Then

                                        MediaRFPHeader.Comments = MediaRFPOutlet.HeaderComment

                                        If MediaRFPHeader.DbContext Is Nothing Then

                                            DbContext.TryAttach(MediaRFPHeader)

                                        End If

                                        DbContext.Entry(MediaRFPHeader).State = Entity.EntityState.Modified
                                        DbContext.SaveChanges()

                                        AddMediaRFPHeaderStatus(DbContext, MediaRFPHeader)

                                        MediaRFPOutlet.MediaRFPHeaderID = MediaRFPHeader.ID
                                        MediaRFPOutlet.HeaderAddedUpdated = True

                                    End If

                                    CreateMediaRFPDetailLines(DbContext, XmlElement, MediaRFPHeader, MediaRFPDemoList, DaypartList, MediaRFPOutlet, MarketDictionary)

                                Next

                            ElseIf Not MissingSyscodesCallLetters.Contains(MediaRFPOutlet.CanadianVendorCode) Then

                                MissingSyscodesCallLetters.Add(MediaRFPOutlet.CallLetters)

                            End If

                        End If

                    End If

                Next

                NodeCounter += 1

                RaiseEvent ImportingProgressUpdateEvent(NodeCounter)

            Next

            ImportCanadianTVGAP = True

        End Function
        Private Function ImportAustralianPRP(DbContext As AdvantageFramework.Database.DbContext, ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                             MediaBroadcastWorksheetMarketID As Integer, File As String, ByRef MissingSyscodesCallLetters As Generic.List(Of String)) As Boolean

            'objects
            Dim FileLines As Generic.List(Of String) = Nothing
            Dim Imported As Boolean = False
            Dim FileLineCounter As Integer = 0
            Dim MediaRFPOutletList As Generic.List(Of AdvantageFramework.Importing.Classes.MediaRFPOutlet) = Nothing
            Dim MediaRFPOutlet As AdvantageFramework.Importing.Classes.MediaRFPOutlet = Nothing
            Dim MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader = Nothing
            Dim MediaRFPAvailLine As AdvantageFramework.Database.Entities.MediaRFPAvailLine = Nothing
            Dim MediaRFPAvailLineSpot As AdvantageFramework.Database.Entities.MediaRFPAvailLineSpot = Nothing
            Dim MediaRFPDemo As AdvantageFramework.Database.Entities.MediaRFPDemo = Nothing
            Dim CallLetters As String = Nothing
            Dim NetworkName As String = Nothing
            Dim NextBatchNumber As Short = 0
            Dim LastSpotInfo As String = Nothing
            Dim LastSpotLength As Short = 0
            Dim MediaRFPHeaderIDBatchDictionary As Dictionary(Of Integer, Integer) = Nothing
            Dim MediaDemographic As AdvantageFramework.Database.Entities.MediaDemographic = Nothing
            Dim CreatedDate As Date = Now.ToString("MM/dd/yyyy HH:mm")
            Dim GrossRate As Decimal = 0
            Dim NetRate As Decimal = 0

            FileLines = GetFileLines(File).ToList

            If FileLines IsNot Nothing AndAlso FileLines.Count > 0 Then

                RaiseEvent SetupImportingProgressEvent(0, FileLines.Count, 0)

                MediaRFPHeaderIDBatchDictionary = New Dictionary(Of Integer, Integer)

                MediaRFPOutletList = New Generic.List(Of AdvantageFramework.Importing.Classes.MediaRFPOutlet)

                For Each FileLine In FileLines

                    If FileLine.Length > 600 Then

                        CallLetters = FileLine.Substring(92, 6).Trim
                        NetworkName = FileLine.Substring(98, 40).Trim

                        MediaRFPOutlet = MediaRFPOutletList.Where(Function(Entity) Entity.CallLetters = CallLetters).SingleOrDefault

                        If MediaRFPOutlet Is Nothing Then

                            MediaRFPOutlet = New AdvantageFramework.Importing.Classes.MediaRFPOutlet()
                            MediaRFPOutlet.IsCable = False
                            MediaRFPOutlet.CallLetters = CallLetters

                            MediaRFPOutletList.Add(MediaRFPOutlet)

                        End If

                        MediaRFPHeader = GetMediaRFPHeader(DbContext, MediaRFPOutlet, ImportTemplate, MediaBroadcastWorksheetMarketID)

                        If MediaRFPHeader IsNot Nothing Then

                            If MediaRFPHeaderIDBatchDictionary.ContainsKey(MediaRFPHeader.ID) Then

                                NextBatchNumber = MediaRFPHeaderIDBatchDictionary.Item(MediaRFPHeader.ID)

                            Else

                                If (From Entity In AdvantageFramework.Database.Procedures.MediaRFPAvailLine.Load(DbContext)
                                    Where Entity.MediaRFPHeaderID = MediaRFPHeader.ID
                                    Select Entity.BatchNumber).Any Then

                                    NextBatchNumber = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPAvailLine.Load(DbContext)
                                                       Where Entity.MediaRFPHeaderID = MediaRFPHeader.ID
                                                       Select Entity.BatchNumber).Max + 1

                                Else

                                    NextBatchNumber = 1

                                End If

                                MediaRFPHeaderIDBatchDictionary.Add(MediaRFPHeader.ID, NextBatchNumber)

                            End If

                            If MediaRFPAvailLine IsNot Nothing AndAlso LastSpotInfo = FileLine.Substring(258, 23) & MediaRFPAvailLine.Program AndAlso LastSpotLength = FileLine.Substring(296, 8) Then

                                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_RFP_AVAILABLE_LINE_SPOT SET QUANTITY = QUANTITY + 1 WHERE MEDIA_RFP_AVAILABLE_LINE_ID = {0} AND WEEK_DATE = '{1}'", MediaRFPAvailLine.ID, MediaRFPAvailLine.StartDate))

                            Else

                                MediaRFPAvailLine = New AdvantageFramework.Database.Entities.MediaRFPAvailLine
                                MediaRFPAvailLine.BatchNumber = NextBatchNumber
                                MediaRFPAvailLine.Status = AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus.H.ToString

                                MediaRFPAvailLine.MediaRFPHeaderID = MediaRFPHeader.ID

                                MediaRFPAvailLine.CallLetters = CallLetters
                                MediaRFPAvailLine.NetworkName = NetworkName

                                MediaRFPAvailLine.StartDate = New Date(FileLine.Substring(258, 4), FileLine.Substring(262, 2), FileLine.Substring(264, 2))
                                MediaRFPAvailLine.EndDate = MediaRFPAvailLine.StartDate.Value.AddDays(6)
                                MediaRFPAvailLine.SpotLength = FileLine.Substring(296, 8)

                                LastSpotLength = MediaRFPAvailLine.SpotLength

                                MediaRFPAvailLine.StartHour = FileLine.Substring(273, 4)
                                MediaRFPAvailLine.EndHour = FileLine.Substring(277, 4)

                                MediaRFPAvailLine.StartTime = FormatTime(FileLine.Substring(273, 4))
                                MediaRFPAvailLine.EndTime = FormatTime(FileLine.Substring(277, 4))

                                MediaRFPAvailLine.Sunday = IsProposedDay(FileLine.Substring(266, 1))
                                MediaRFPAvailLine.Monday = IsProposedDay(FileLine.Substring(267, 1))
                                MediaRFPAvailLine.Tuesday = IsProposedDay(FileLine.Substring(268, 1))
                                MediaRFPAvailLine.Wednesday = IsProposedDay(FileLine.Substring(269, 1))
                                MediaRFPAvailLine.Thursday = IsProposedDay(FileLine.Substring(270, 1))
                                MediaRFPAvailLine.Friday = IsProposedDay(FileLine.Substring(271, 1))
                                MediaRFPAvailLine.Saturday = IsProposedDay(FileLine.Substring(272, 1))

                                If MediaRFPAvailLine.Sunday = False AndAlso MediaRFPAvailLine.StartDate.HasValue Then

                                    MediaRFPAvailLine.StartDate = MediaRFPAvailLine.StartDate.Value.AddDays(1)

                                End If

                                MediaRFPAvailLine.Program = FileLine.Substring(352, 40).Trim
                                MediaRFPAvailLine.FileSource = Database.Entities.Methods.MediaRFPAvailLineFileSource.PRP

                                LastSpotInfo = FileLine.Substring(258, 23) & MediaRFPAvailLine.Program

                                MediaRFPAvailLineSpot = New AdvantageFramework.Database.Entities.MediaRFPAvailLineSpot
                                MediaRFPAvailLineSpot.WeekDate = MediaRFPAvailLine.StartDate

                                If IsNumeric(FileLine.Substring(304, 10)) Then

                                    GrossRate = CDec(FileLine.Substring(304, 10) / 100)

                                End If

                                If IsNumeric(FileLine.Substring(314, 10)) Then

                                    NetRate = CDec(FileLine.Substring(314, 10) / 100)

                                End If

                                If GrossRate <> 0 Then

                                    MediaRFPAvailLineSpot.Rate = GrossRate

                                ElseIf NetRate <> 0 Then

                                    MediaRFPAvailLineSpot.Rate = NetRate

                                End If

                                MediaRFPAvailLineSpot.Quantity = 1

                                MediaRFPAvailLine.MediaRFPAvailLineSpots.Add(MediaRFPAvailLineSpot)

                                'Impressions
                                If IsNumeric(FileLine.Substring(512, 7)) Then

                                    MediaRFPDemo = New AdvantageFramework.Database.Entities.MediaRFPDemo
                                    MediaRFPDemo.IDRank = "DM1"

                                    MediaDemographic = AdvantageFramework.Database.Procedures.MediaDemographic.LoadByCode(DbContext, FileLine.Substring(546, 15))

                                    If MediaDemographic IsNot Nothing Then

                                        MediaRFPDemo.MediaDemoID = MediaDemographic.ID
                                        MediaRFPDemo.AgeFrom = MediaDemographic.AgeFrom.GetValueOrDefault(0)
                                        MediaRFPDemo.AgeTo = MediaDemographic.AgeTo.GetValueOrDefault(99)

                                    Else

                                        MediaRFPDemo.MediaDemoID = Nothing
                                        MediaRFPDemo.AgeFrom = 0
                                        MediaRFPDemo.AgeTo = 99

                                    End If

                                    MediaRFPDemo.Group = FileLine.Substring(546, 15)
                                    MediaRFPDemo.Type = "Impressions"
                                    MediaRFPDemo.Value = FileLine.Substring(512, 7) * 100 'raw value is in tenths

                                    MediaRFPAvailLine.MediaRFPDemos.Add(MediaRFPDemo)

                                End If

                                'Rating
                                If IsNumeric(FileLine.Substring(561, 3)) Then

                                    MediaRFPDemo = New AdvantageFramework.Database.Entities.MediaRFPDemo
                                    MediaRFPDemo.IDRank = "DM2"

                                    MediaDemographic = AdvantageFramework.Database.Procedures.MediaDemographic.LoadByCode(DbContext, FileLine.Substring(546, 15))

                                    If MediaDemographic IsNot Nothing Then

                                        MediaRFPDemo.MediaDemoID = MediaDemographic.ID
                                        MediaRFPDemo.AgeFrom = MediaDemographic.AgeFrom.GetValueOrDefault(0)
                                        MediaRFPDemo.AgeTo = MediaDemographic.AgeTo.GetValueOrDefault(99)

                                    Else

                                        MediaRFPDemo.MediaDemoID = Nothing
                                        MediaRFPDemo.AgeFrom = 0
                                        MediaRFPDemo.AgeTo = 99

                                    End If

                                    MediaRFPDemo.Group = FileLine.Substring(546, 15)
                                    MediaRFPDemo.Type = "Rating"
                                    MediaRFPDemo.Value = FileLine.Substring(561, 3) / 10

                                    MediaRFPAvailLine.MediaRFPDemos.Add(MediaRFPDemo)

                                End If

                                DbContext.MediaRFPAvailLines.Add(MediaRFPAvailLine)

                            End If

                            DbContext.SaveChanges()

                            AddMediaRFPHeaderStatus(DbContext, MediaRFPHeader, CreatedDate)

                        Else

                            MissingSyscodesCallLetters.Add(CallLetters)

                        End If

                    End If

                    FileLineCounter += 1
                    RaiseEvent ImportingProgressUpdateEvent(FileLineCounter)

                Next

            End If

            ImportAustralianPRP = Imported

        End Function
        Private Function FormatTime(Hour As String) As String

            Dim FormattedTime As String = Nothing

            If CInt(Hour.Substring(0, 2)) <= 12 Then

                FormattedTime = Hour.Substring(0, 2) & ":" & Hour.Substring(2) & " AM"

            ElseIf CInt(Hour.Substring(0, 2)) = 24 Then

                FormattedTime = CStr(CInt(Hour.Substring(0, 2)) - 12) & ":" & Hour.Substring(2) & " AM"

            Else

                FormattedTime = CStr(CInt(Hour.Substring(0, 2)) - 12) & ":" & Hour.Substring(2) & " PM"

            End If

            FormatTime = FormattedTime

        End Function
        Private Function IsProposedDay(Day As String) As Boolean

            Dim IsDay As Boolean = False

            If Day = "Y" OrElse Day = "Y" Then

                IsDay = True

            End If

            IsProposedDay = IsDay

        End Function

#End Region

#End Region

    End Module

End Namespace
