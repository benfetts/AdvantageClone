Namespace Database.Entities

	<Table("EXPENSE_DETAIL")>
	Public Class ExpenseReportDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			InvoiceNumber
			LineNumber
			ItemDate
			Description
			CreditCardFlag
			ClientCode
			DivisionCode
			ProductCode
			JobNumber
			JobComponentNumber
			FunctionCode
			Quantity
			Rate
			CreditCardAmount
			Amount
			APComment
			CreatedBy
			ModifiedBy
			ModifiedDate
			PaymentType
            IsImported
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("EXPDETAILID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<Column("INV_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property InvoiceNumber() As Integer
		<Required>
		<Column("LINE_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property LineNumber() As Integer
		<Column("ITEM_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Date")>
		Public Property ItemDate() As Nullable(Of Date)
		<MaxLength(600)>
		<Column("ITEM_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<Column("CC_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Credit Card")>
		Public Property CreditCardFlag() As Nullable(Of Boolean)
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
		Public Property ClientCode() As String
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Division", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode)>
		Public Property DivisionCode() As String
		<MaxLength(6)>
		<Column("PRD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Product", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ProductCode)>
		Public Property ProductCode() As String
		<Column("JOB_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Job", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.JobNumber)>
		Public Property JobNumber() As Nullable(Of Integer)
		<Column("JOB_COMP_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Job Comp")>
		Public Property JobComponentNumber() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("FNC_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Function", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.FunctionCode)>
		Public Property FunctionCode() As String
		<Column("QTY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Quantity() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(12, 4)>
        <Column("RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F4")>
        Public Property Rate() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("CC_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property CreditCardAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("AMOUNT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="F2")>
		Public Property Amount() As Nullable(Of Decimal)
		<MaxLength(100)>
		<Column("AP_COMMENT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property APComment() As String
		<MaxLength(100)>
		<Column("CREATE_USER_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property CreatedBy() As String
		<MaxLength(100)>
		<Column("MOD_USER_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ModifiedBy() As String
		<Column("MOD_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ModifiedDate() As Nullable(Of Date)
		<Column("PAYMENT_TYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property PaymentType() As Nullable(Of Short)
        <Column("IMPORTED")>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsImported() As Boolean

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Sub SetRequiredFields()

            'objects
            Dim IsRequired As Boolean = False

            IsRequired = IsCDPJobCompRequired()

            SetRequired(AdvantageFramework.Database.Entities.ExpenseReportDetail.Properties.ClientCode.ToString, IsRequired)
            SetRequired(AdvantageFramework.Database.Entities.ExpenseReportDetail.Properties.DivisionCode.ToString, IsRequired)
            SetRequired(AdvantageFramework.Database.Entities.ExpenseReportDetail.Properties.ProductCode.ToString, IsRequired)
            SetRequired(AdvantageFramework.Database.Entities.ExpenseReportDetail.Properties.JobNumber.ToString, IsRequired)
            SetRequired(AdvantageFramework.Database.Entities.ExpenseReportDetail.Properties.JobComponentNumber.ToString, IsRequired)

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ExpenseReportDetail.Properties.FunctionCode.ToString

                    PropertyValue = Value

                    If Me.IsEntityBeingAdded() Then

                        If Not String.IsNullOrWhiteSpace(Me.Description) AndAlso Me.Description.ToUpper = "SYSTEM GENERATED" AndAlso Me.LineNumber = 0 Then

                            ErrorText = ""
                            IsValid = True

                        ElseIf IsValid Then

                            If AdvantageFramework.Database.Procedures.Function.LoadAllEmployeeExpenseFunctions(Me.DbContext).Where(Function(Entity) Entity.Code = DirectCast(PropertyValue, String)).Any = False Then

                                ErrorText = "Invalid function."
                                IsValid = False

                            End If

                        End If

                    ElseIf IsValid Then

                        If AdvantageFramework.Database.Procedures.Function.LoadAllEmployeeExpenseFunctions(Me.DbContext).Where(Function(Entity) Entity.Code = DirectCast(PropertyValue, String)).Any = False Then

                            ErrorText = "Invalid function."
                            IsValid = False

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ExpenseReportDetail.Properties.JobComponentNumber.ToString

                    PropertyValue = Value

                    If IsValid Then

                        If Me.IsEntityBeingAdded() Then

                            If Me.JobComponentNumber.HasValue Then

                                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.DbContext.ConnectionString, Me.DbContext.UserCode)

                                    If (From Item In AdvantageFramework.ExpenseReports.LoadAvailableJobComponents(Me.DbContext, SecurityDbContext, Me.JobNumber, Me.ClientCode, Me.DivisionCode, Me.ProductCode)
                                        Where Item.JobComponentNumber = PropertyValue
                                        Select Item).Count <> 1 Then

                                        IsValid = False

                                    End If

                                End Using

                            End If

                        Else

                            Try

                                If (From Item In AdvantageFramework.Database.Procedures.JobComponentView.Load(Me.DbContext)
                                    Where Item.ClientCode = Me.ClientCode AndAlso
                                      Item.DivisionCode = Me.DivisionCode AndAlso
                                      Item.ProductCode = Me.ProductCode AndAlso
                                      Item.JobNumber = Me.JobNumber AndAlso
                                      Item.JobComponentNumber = CType(PropertyValue, Short)
                                    Select Item).Any = False Then

                                    IsValid = False

                                End If

                            Catch ex As Exception

                            End Try

                        End If

                        If IsValid = False Then

                            ErrorText = AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(BaseClasses.PropertyTypes.JobComponent)

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            If PropertyName = AdvantageFramework.Database.Entities.ExpenseReportDetail.Properties.DivisionCode.ToString OrElse _
                PropertyName = AdvantageFramework.Database.Entities.ExpenseReportDetail.Properties.ProductCode.ToString OrElse _
                PropertyName = AdvantageFramework.Database.Entities.ExpenseReportDetail.Properties.ClientCode.ToString OrElse _
                PropertyName = AdvantageFramework.Database.Entities.ExpenseReportDetail.Properties.JobNumber.ToString OrElse _
                PropertyName = AdvantageFramework.Database.Entities.ExpenseReportDetail.Properties.JobComponentNumber.ToString Then

                SetRequired(PropertyName, IsCDPJobCompRequired())

            End If

            ValidateEntityProperty = MyBase.ValidateEntityProperty(PropertyName, IsValid, Value)

        End Function
        Private Function IsCDPJobCompRequired() As Boolean

            'objects
            Dim IsRequired As Boolean = False

            Try

                If String.IsNullOrEmpty(Me.ClientCode) = False OrElse _
                   String.IsNullOrEmpty(Me.DivisionCode) = False OrElse _
                   String.IsNullOrEmpty(Me.ProductCode) = False OrElse _
                   Me.JobNumber.HasValue OrElse _
                   Me.JobComponentNumber.HasValue Then

                    IsRequired = True

                End If

            Catch ex As Exception
                IsRequired = False
            End Try

            IsCDPJobCompRequired = IsRequired

        End Function

#End Region

	End Class

End Namespace
