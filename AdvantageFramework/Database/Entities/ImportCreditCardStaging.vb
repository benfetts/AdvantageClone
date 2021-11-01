Namespace Database.Entities

	<Table("IMP_CC_STAGING")>
	Public Class ImportCreditCardStaging
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
            ID
            JobComponentID
            BatchName
            AccountNumber
			EmployeeCode
			EmployeeFirstName
			EmployeeLastName
			ExpenseReportDate
			ExpenseReportDescription
			ExpenseReportDetail
            ItemDate
            ItemDescription
            ClientCode
			DivisionCode
			ProductCode
			JobNumber
			JobComponentNumber
			FunctionCode
			Quantity
			Rate
			Amount
            CreditCardFlag

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ROW_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(50)>
		<Column("BATCH_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property BatchName() As String
		<MaxLength(30)>
		<Column("ACCOUNT_NUMBER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property AccountNumber() As String
		<MaxLength(6)>
		<Column("EMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ExpenseEmployee, IsImportDefaultProperty:=True)>
		Public Property EmployeeCode() As String
		<MaxLength(30)>
		<Column("EMP_FNAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property EmployeeFirstName() As String
		<MaxLength(30)>
		<Column("EMP_LNAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property EmployeeLastName() As String
		<Column("EXP_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsImportDefaultProperty:=True)>
		Public Property ExpenseReportDate() As Nullable(Of Date)
		<MaxLength(30)>
		<Column("EXP_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsImportDefaultProperty:=True)>
		Public Property ExpenseReportDescription() As String
		<Column("EXP_DTL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ExpenseReportDetail() As String
		<Column("ITEM_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsImportDefaultProperty:=True)>
		Public Property ItemDate() As Nullable(Of Date)
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode, IsImportDefaultProperty:=True)>
		Public Property ClientCode() As String
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode, IsImportDefaultProperty:=True)>
		Public Property DivisionCode() As String
		<MaxLength(6)>
		<Column("PRD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ProductCode, IsImportDefaultProperty:=True)>
		Public Property ProductCode() As String
		<Column("JOB_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.JobNumber, IsImportDefaultProperty:=True)>
		Public Property JobNumber() As Nullable(Of Integer)
		<Column("JOB_COMPONENT_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentNumber() As Nullable(Of Short)
        <Column("JOB_COMP_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Job Comp", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.JobComponentID, IsImportDefaultProperty:=True)>
        Public Property JobComponentID() As Nullable(Of Integer)
        <MaxLength(6)>
		<Column("FNC_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.FunctionCode, IsImportDefaultProperty:=True)>
		Public Property FunctionCode() As String
		<Column("QTY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Quantity() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 3)>
        <Column("RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=False)>
        Public Property Rate() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("AMOUNT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="F2")>
		Public Property Amount() As Nullable(Of Decimal)
		<Column("CC_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
		Public Property CreditCardFlag() As Nullable(Of Boolean)
		<MaxLength(200)>
		<Column("ITEM_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ItemDescription() As String


#End Region

#Region " Methods "

        Public Sub New()


        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.ClientCode.ToString, _
                     AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.DivisionCode.ToString, _
                     AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.ProductCode.ToString, _
                     AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.JobNumber.ToString, _
                     AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.JobComponentID.ToString

                    SetRequired(PropertyName, IsCDPJobAndCompRequired())

            End Select

            ValidateEntityProperty = MyBase.ValidateEntityProperty(PropertyName, IsValid, Value)

        End Function
        Public Overrides Function ValidateCustomProperties(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ExcludedJobProcessControlNumbers() As Integer = Nothing
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim EmployeeVendorCode As String = ""

            PropertyValue = Value

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.JobNumber.ToString

                    If IsValid Then

                        ExcludedJobProcessControlNumbers = New Integer() {2, 5, 7, 10, 11, 6, 12}

                        If (From JobComp In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).JobComponents _
                            Where JobComp.JobNumber = DirectCast(PropertyValue, Integer) AndAlso _
                                  ExcludedJobProcessControlNumbers.Contains(JobComp.JobProcessNumber) = False _
                            Select JobComp).Any = False Then

                            IsValid = False

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.JobComponentID.ToString

                    If IsValid Then

                        ExcludedJobProcessControlNumbers = New Integer() {2, 5, 7, 10, 11, 6, 12}

                        If (From JobComp In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).JobComponents _
                            Where JobComp.ID = DirectCast(PropertyValue, Integer) AndAlso _
                                  ExcludedJobProcessControlNumbers.Contains(JobComp.JobProcessNumber) = True _
                            Select JobComp).Any Then

                            IsValid = False

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.EmployeeCode.ToString

                    If IsValid Then

                        If (From Employee In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Employees
                            Where Employee.Code = DirectCast(PropertyValue, String) AndAlso
                                  Employee.TerminationDate Is Nothing
                            Select Employee).Any = False Then

                            IsValid = False

                        Else

                            EmployeeVendorCode = (From Employee In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Employees
                                                  Where Employee.Code = DirectCast(PropertyValue, String)
                                                  Select Employee).SingleOrDefault.EmployeeVendorCode

                            If (From Vendor In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Vendors
                                Where Vendor.Code = EmployeeVendorCode AndAlso
                                      Vendor.ActiveFlag = 1
                                Select Vendor).Any = False Then

                                IsValid = False

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.FunctionCode.ToString

                    If IsValid Then

                        If (From Item In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Functions
                            Where Item.Code = DirectCast(PropertyValue, String) AndAlso
                                  Item.Type = "V" AndAlso
                                  Item.EmployeeExpenseFlag = 1
                            Select Item).Any = False Then

                            IsValid = False

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Protected Overrides Sub FinalizeEntityPropertyValidation(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object, ByRef ErrorText As String, IsEntityKey As Boolean, IsNullable As Boolean, IsRequired As Boolean, MaxLength As Integer, Precision As Long, Scale As Long, PropertyType As BaseClasses.Methods.PropertyTypes)

            If Me.IsEntityBeingAdded() Then

                If IsValid = False Then

                    IsValid = True
                    ErrorText = ""

                End If

            End If

        End Sub
        Protected Function IsCDPJobAndCompRequired() As Boolean

            'objects
            Dim IsRequired As Boolean = False

            Try

                If String.IsNullOrEmpty(Me.ClientCode) = False OrElse _
                   String.IsNullOrEmpty(Me.DivisionCode) = False OrElse _
                   String.IsNullOrEmpty(Me.ProductCode) = False OrElse _
                   Me.JobNumber.HasValue OrElse _
                   Me.JobComponentID.HasValue Then

                    IsRequired = True

                End If

            Catch ex As Exception
                IsRequired = False
            Finally
                IsCDPJobAndCompRequired = IsRequired
            End Try

        End Function

#End Region

	End Class

End Namespace
