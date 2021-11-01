Namespace Database.Classes

    <Serializable()>
    Public Class [Function]
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Description
            Type
            DepartmentTeamCode
            LineConsolidation
            CPMFlag
            FunctionOrder
            IsInactive
            FeeReconcile
            FunctionHeadingID
            EmployeeExpenseFlag
            NonBillableClientGLACode
            OverheadGLACode
            FeeFlag
            BillingRate
            TaxCommissionFlag
            TaxCommissionOnlyFlag
            NonBillableFlag
            TaxFlag
            CommissionFlag
        End Enum

#End Region

#Region " Variables "

        Private _FunctionView As AdvantageFramework.Database.Views.FunctionView = Nothing
        Private _Code As String = Nothing
        Private _Description As String = Nothing
        Private _Type As String = Nothing
        Private _DepartmentTeamCode As String = Nothing
        Private _LineConsolidation As String = Nothing
        Private _CPMFlag As Nullable(Of Short) = Nothing
        Private _FunctionOrder As Nullable(Of Short) = Nothing
        Private _IsInactive As Nullable(Of Short) = Nothing
        Private _FeeReconcile As Nullable(Of Short) = Nothing
        Private _FunctionHeadingID As Nullable(Of Integer) = Nothing
        Private _EmployeeExpenseFlag As Nullable(Of Short) = Nothing
        Private _NonBillableClientGLACode As String = Nothing
        Private _OverheadGLACode As String = Nothing
        Private _FeeFlag As Nullable(Of Short) = Nothing
        Private _BillingRate As Nullable(Of Decimal) = Nothing
        Private _TaxCommissionFlag As Nullable(Of Short) = Nothing
        Private _TaxCommissionOnlyFlag As Nullable(Of Short) = Nothing
        Private _NonBillableFlag As Nullable(Of Short) = Nothing
        Private _TaxFlag As Nullable(Of Short) = Nothing
        Private _CommissionFlag As Nullable(Of Short) = Nothing
        Private _FunctionExists As Boolean = False
        Private _VATTaxCode As String = Nothing

#End Region

#Region " Properties "

        <Required>
		<MaxLength(6)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
			Get
				Code = _Code
			End Get
			Set(value As String)
				_Code = value
			End Set
		End Property
		<Required>
		<MaxLength(30)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
			Get
				Description = _Description
			End Get
			Set(value As String)
				_Description = value
			End Set
		End Property
		<Required>
		<MaxLength(1)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Type() As String
			Get
				Type = _Type
			End Get
			Set(value As String)
				_Type = value
			End Set
		End Property
		<MaxLength(4)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Department / Team", PropertyType:=BaseClasses.PropertyTypes.DepartmentTeamCode)>
		Public Property DepartmentTeamCode() As String
			Get
				DepartmentTeamCode = _DepartmentTeamCode
			End Get
			Set(value As String)
				_DepartmentTeamCode = value
			End Set
		End Property
		<MaxLength(6)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.FunctionCode, CustomColumnCaption:="Consolidation Code")>
        Public Property LineConsolidation() As String
            Get
                LineConsolidation = _LineConsolidation
            End Get
            Set(value As String)
                _LineConsolidation = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="CPM", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property CPMFlag() As Nullable(Of Short)
            Get
                CPMFlag = _CPMFlag
            End Get
            Set(value As Nullable(Of Short))
                _CPMFlag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=999)>
        Public Property FunctionOrder() As Nullable(Of Short)
            Get
                FunctionOrder = _FunctionOrder
            End Get
            Set(value As Nullable(Of Short))
                _FunctionOrder = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsInactive() As Nullable(Of Short)
            Get
                IsInactive = _IsInactive
            End Get
            Set(value As Nullable(Of Short))
                _IsInactive = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property FeeReconcile() As Nullable(Of Short)
            Get
                FeeReconcile = _FeeReconcile
            End Get
            Set(value As Nullable(Of Short))
                _FeeReconcile = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Heading Description", PropertyType:=BaseClasses.PropertyTypes.FunctionHeadingID)>
        Public Property FunctionHeadingID() As Nullable(Of Integer)
            Get
                FunctionHeadingID = _FunctionHeadingID
            End Get
            Set(value As Nullable(Of Integer))
                _FunctionHeadingID = value
            End Set
        End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Employee Expense", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property EmployeeExpenseFlag() As Nullable(Of Short)
			Get
				EmployeeExpenseFlag = _EmployeeExpenseFlag
			End Get
			Set(value As Nullable(Of Short))
				_EmployeeExpenseFlag = value
			End Set
		End Property
		<MaxLength(30)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Non Billable Client Account", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
		Public Property NonBillableClientGLACode() As String
			Get
				NonBillableClientGLACode = _NonBillableClientGLACode
			End Get
			Set(value As String)
				_NonBillableClientGLACode = value
			End Set
		End Property
		<MaxLength(30)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Overhead Account", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property OverheadGLACode() As String
            Get
                OverheadGLACode = _OverheadGLACode
            End Get
            Set(value As String)
                _OverheadGLACode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property FeeFlag() As Nullable(Of Short)
            Get
                FeeFlag = _FeeFlag
            End Get
            Set(value As Nullable(Of Short))
                _FeeFlag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property BillingRate() As Nullable(Of Decimal)
            Get
                BillingRate = _BillingRate
            End Get
            Set(value As Nullable(Of Decimal))
                _BillingRate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Tax Commission")>
        Public Property TaxCommissionFlag() As Nullable(Of Short)
            Get
                TaxCommissionFlag = _TaxCommissionFlag
            End Get
            Set(value As Nullable(Of Short))
                _TaxCommissionFlag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Tax Commission Only")>
        Public Property TaxCommissionOnlyFlag() As Nullable(Of Short)
            Get
                TaxCommissionOnlyFlag = _TaxCommissionOnlyFlag
            End Get
            Set(value As Nullable(Of Short))
                _TaxCommissionOnlyFlag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Non Billable")>
        Public Property NonBillableFlag() As Nullable(Of Short)
            Get
                NonBillableFlag = _NonBillableFlag
            End Get
            Set(value As Nullable(Of Short))
                _NonBillableFlag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Taxable")>
        Public Property TaxFlag() As Nullable(Of Short)
            Get
                TaxFlag = _TaxFlag
            End Get
            Set(value As Nullable(Of Short))
                _TaxFlag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Commissionable")>
        Public Property CommissionFlag() As Nullable(Of Short)
            Get
                CommissionFlag = _CommissionFlag
            End Get
            Set(value As Nullable(Of Short))
                _CommissionFlag = value
            End Set
        End Property
        <MaxLength(20)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="VAT Tax Code")>
        Public Property VATTaxCode() As String
            Get
                VATTaxCode = _VATTaxCode
            End Get
            Set(value As String)
                _VATTaxCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _FunctionView = New AdvantageFramework.Database.Views.FunctionView
            _FunctionExists = False

        End Sub
        Public Sub New(ByVal FunctionView As AdvantageFramework.Database.Views.FunctionView)

            _FunctionView = FunctionView

            _Code = FunctionView.Code
            _Description = FunctionView.Description
            _Type = FunctionView.Type
            _DepartmentTeamCode = FunctionView.DepartmentTeamCode
            _LineConsolidation = FunctionView.LineConsolidation
            _CPMFlag = FunctionView.CPMFlag
            _FunctionOrder = FunctionView.FunctionOrder
            _IsInactive = FunctionView.IsInactive
            _FeeReconcile = FunctionView.FeeReconcile
            _FunctionHeadingID = FunctionView.FunctionHeadingID
            _EmployeeExpenseFlag = FunctionView.EmployeeExpenseFlag
            _NonBillableClientGLACode = FunctionView.NonBillableClientGLACode
            _OverheadGLACode = FunctionView.OverheadGLACode
            _FeeFlag = FunctionView.FeeFlag
            _BillingRate = FunctionView.BillingRate
            _TaxCommissionFlag = FunctionView.TaxCommissionFlag
            _TaxCommissionOnlyFlag = FunctionView.TaxCommissionOnlyFlag
            _NonBillableFlag = FunctionView.NonBillableFlag
            _TaxFlag = FunctionView.TaxFlag
            _CommissionFlag = FunctionView.CommissionFlag
            _VATTaxCode = FunctionView.VATTaxCode

            _FunctionExists = True

        End Sub
        Public Function GetEntity() As AdvantageFramework.Database.Views.FunctionView

            Try

                _FunctionView.Code = _Code
                _FunctionView.Description = _Description
                _FunctionView.Type = _Type
                _FunctionView.DepartmentTeamCode = _DepartmentTeamCode
                _FunctionView.LineConsolidation = _LineConsolidation
                _FunctionView.CPMFlag = _CPMFlag
                _FunctionView.FunctionOrder = _FunctionOrder
                _FunctionView.IsInactive = _IsInactive
                _FunctionView.FeeReconcile = _FeeReconcile
                _FunctionView.FunctionHeadingID = _FunctionHeadingID
                _FunctionView.EmployeeExpenseFlag = _EmployeeExpenseFlag
                _FunctionView.NonBillableClientGLACode = _NonBillableClientGLACode
                _FunctionView.OverheadGLACode = _OverheadGLACode
                _FunctionView.FeeFlag = _FeeFlag
                _FunctionView.BillingRate = _BillingRate
                _FunctionView.TaxCommissionFlag = _TaxCommissionFlag
                _FunctionView.TaxCommissionOnlyFlag = _TaxCommissionOnlyFlag
                _FunctionView.NonBillableFlag = _NonBillableFlag
                _FunctionView.TaxFlag = _TaxFlag
                _FunctionView.CommissionFlag = _CommissionFlag
                _FunctionView.VATTaxCode = _VATTaxCode

            Catch ex As Exception

            End Try

            GetEntity = _FunctionView

        End Function
        Public Sub SetExists()

            _FunctionExists = True

        End Sub
		Public Overrides Function IsEntityBeingAdded() As Boolean

			IsEntityBeingAdded = Not _FunctionExists

		End Function
		Protected Overrides Sub FinalizeEntityPropertyValidation(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object, ByRef ErrorText As String,
                                                                 ByVal IsEntityKey As Boolean, ByVal IsNullable As Boolean, ByVal IsRequired As Boolean, ByVal MaxLength As Integer,
                                                                 ByVal Precision As Long, ByVal Scale As Long, ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes)

            Select Case PropertyName

                Case AdvantageFramework.Database.Classes.Function.Properties.Code.ToString

                    If Me.IsEntityBeingAdded() = False AndAlso IsValid = False AndAlso Value <> AdvantageFramework.StringUtilities.RemoveAllNonAlphaNumeric(Value) Then

                        ErrorText = ""
                        IsValid = True

                    End If

            End Select

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Classes.Function.Properties.Code.ToString

                    If Me.IsEntityBeingAdded Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).FunctionViews
                            Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique function code."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
