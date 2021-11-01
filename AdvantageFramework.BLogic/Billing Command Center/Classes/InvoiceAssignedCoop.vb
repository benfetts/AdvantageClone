Namespace BillingCommandCenter.Classes

    Public Class InvoiceAssignedCoop

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            WorkARFunctionID
            CDP
            ClientName
            DivisionName
            ProductDescription
            FunctionDescription
            SalesTaxCode
            IncomeAmount
            CostAmount
            TotalAmount
            Status
            Variance
            Reconciled
            CoopPercent
            FunctionCode
            SummaryRowId
            FunctionType
            RowTotal
        End Enum

#End Region

#Region " Variables "

        Private _InvoiceAssignedCoop As AdvantageFramework.BillingCommandCenter.Database.Classes.InvoiceAssignedCoop = Nothing
        Private _Reconciled As Boolean = False
        Private _IncomeAmount As Decimal = Nothing
        Private _CostAmount As Decimal = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property WorkARFunctionID() As Integer
            Get
                WorkARFunctionID = _InvoiceAssignedCoop.WorkARFunctionID
            End Get
            Set(value As Integer)
                _InvoiceAssignedCoop.WorkARFunctionID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property CDP() As String
            Get
                CDP = _InvoiceAssignedCoop.ClientCode & ":" & _InvoiceAssignedCoop.DivisionCode & ":" & _InvoiceAssignedCoop.ProductCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ClientName() As String
            Get
                ClientName = _InvoiceAssignedCoop.ClientName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property DivisionName() As String
            Get
                DivisionName = _InvoiceAssignedCoop.DivisionName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ProductDescription() As String
            Get
                ProductDescription = _InvoiceAssignedCoop.ProductName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Function")>
        Public ReadOnly Property FunctionDescription() As String
            Get
                FunctionDescription = _InvoiceAssignedCoop.FunctionCode & " - " & _InvoiceAssignedCoop.FunctionDescription
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property SalesTaxCode() As String
            Get
                SalesTaxCode = _InvoiceAssignedCoop.SalesTaxCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property IncomeAmount() As Decimal
            Get
                IncomeAmount = _IncomeAmount
            End Get
            Set(value As Decimal)
                _IncomeAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property CostAmount() As Decimal
            Get
                CostAmount = _CostAmount
            End Get
            Set(value As Decimal)
                _CostAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property TotalAmount() As Decimal
            Get
                TotalAmount = _InvoiceAssignedCoop.TotalBill.GetValueOrDefault(0) - (_InvoiceAssignedCoop.CityTaxAmount.GetValueOrDefault(0) + _InvoiceAssignedCoop.CountyTaxAmount.GetValueOrDefault(0) + _InvoiceAssignedCoop.StateTaxAmount.GetValueOrDefault(0))
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Status() As Integer
            Get
                Status = If(Me.Reconciled OrElse (Me.Variance <> 0), 1, 0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Variance() As Decimal
            Get
                Variance = Me.TotalAmount - (Me.IncomeAmount + Me.CostAmount)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Reconciled() As Boolean
            Get
                Reconciled = _Reconciled
            End Get
            Set(value As Boolean)
                _Reconciled = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property CoopPercent() As Nullable(Of Decimal)
            Get
                CoopPercent = _InvoiceAssignedCoop.CoopPercent
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property FunctionCode() As String
            Get
                FunctionCode = _InvoiceAssignedCoop.FunctionCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property SummaryRowId() As Nullable(Of Integer)
            Get
                SummaryRowId = _InvoiceAssignedCoop.SummaryRowId
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", ShowColumnInGrid:=False, CustomColumnCaption:="Total Amount")>
        Public ReadOnly Property RowTotal() As Decimal
            Get
                RowTotal = (Me.CostAmount + Me.IncomeAmount) - (_InvoiceAssignedCoop.CityTaxAmount.GetValueOrDefault(0) + _InvoiceAssignedCoop.CountyTaxAmount.GetValueOrDefault(0) + _InvoiceAssignedCoop.StateTaxAmount.GetValueOrDefault(0))
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Sub New(ByVal InvoiceAssignedCoop As AdvantageFramework.BillingCommandCenter.Database.Classes.InvoiceAssignedCoop)

            _InvoiceAssignedCoop = InvoiceAssignedCoop

            _Reconciled = _InvoiceAssignedCoop.CCInterimReconcile.GetValueOrDefault(False)

            _IncomeAmount = InvoiceAssignedCoop.CCIncomeAmount.GetValueOrDefault(0)
            _CostAmount = _InvoiceAssignedCoop.CCCostAmount.GetValueOrDefault(0)

        End Sub

#End Region

    End Class

End Namespace