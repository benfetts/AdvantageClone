Imports AdvantageFramework.BaseClasses

Namespace IncomeOnly.Classes

    <Serializable()>
    Public Class IncomeOnly
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            SequenceNumber
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentID
            JobComponentDescription
            MediaType
            OrderNumber
            OrderDescription
            OrderLineNumber
            FunctionCode
            FunctionDescription
            TaxCode
            InvoiceDate
            Quantity
            Rate
            Amount
            CommissionPercent
            MarkupAmount
            Taxes
            CityTaxAmount
            CountyTaxAmount
            StateTaxAmount
            TotalAmount
            Description
            ReferenceNumber
            Comment
            BillingUser
            TaxStatePercent
            TaxCityPercent
            TaxCountyPercent
            TaxCommission
            TaxCommissionOnly
            TaxResale
            IsServiceFee
            IsBilled
            NonBillable
            SalesClassCode
            DepartmentTeamCode
            IsRevised
            IsDeleted
            JobServiceFeeID
            EverBilled
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _SequenceNumber As Short = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentID As Nullable(Of Integer) = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _MediaType As String = Nothing
        Private _OrderNumber As Nullable(Of Integer) = Nothing
        Private _OrderDescription As String = Nothing
        Private _OrderLineNumber As Nullable(Of Short) = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _TaxCode As String = Nothing
        Private _InvoiceDate As Nullable(Of Date) = Nothing
        Private _Quantity As Nullable(Of Decimal) = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _Amount As Nullable(Of Decimal) = Nothing
        Private _CommissionPercent As Nullable(Of Decimal) = Nothing
        Private _MarkupAmount As Nullable(Of Decimal) = Nothing
        Private _TotalAmount As Decimal = Nothing
        Private _Description As String = Nothing
        Private _ReferenceNumber As String = Nothing
        Private _Comment As String = Nothing
        Private _BillingUser As String = Nothing
        Private _TaxStatePercent As Nullable(Of Decimal) = Nothing
        Private _TaxCityPercent As Nullable(Of Decimal) = Nothing
        Private _TaxCountyPercent As Nullable(Of Decimal) = Nothing
        Private _TaxCommission As Nullable(Of Short) = Nothing
        Private _TaxCommissionOnly As Nullable(Of Short) = Nothing
        Private _TaxResale As Nullable(Of Short) = Nothing
        Private _IsServiceFee As Boolean = Nothing
        Private _IsBilled As Boolean = Nothing
        Private _NonBillable As Boolean = Nothing
        Private _SalesClassCode As String = Nothing
        Private _DepartmentTeamCode As String = Nothing
        Private _IsRevised As Boolean = False
        Private _CityTaxAmount As Nullable(Of Decimal) = Nothing
        Private _CountyTaxAmount As Nullable(Of Decimal) = Nothing
        Private _StateTaxAmount As Nullable(Of Decimal) = Nothing
        Private _IsDeleted As Boolean = False
        Private _JobServiceFeeID As Nullable(Of Integer) = Nothing
        Private _EverBilled As Boolean = False

#End Region

#Region " Properties "

        Public Overrides ReadOnly Property AttachedEntityType As Type
            Get
                AttachedEntityType = GetType(AdvantageFramework.Database.Entities.IncomeOnly)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property SequenceNumber() As Short
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(value As Short)
                _SequenceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ClientName, IsReadOnlyColumn:=True)>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.DivisionCode)>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.DivisionName, IsReadOnlyColumn:=True)>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ProductCode)>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ProductName, IsReadOnlyColumn:=True)>
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set(value As String)
                _ProductName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n", PropertyType:=BaseClasses.PropertyTypes.JobNumber)>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.JobDescription, IsReadOnlyColumn:=True)>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Job Comp", PropertyType:=BaseClasses.PropertyTypes.JobComponentID)>
        Public Property JobComponentID() As Nullable(Of Integer)
            Get
                JobComponentID = _JobComponentID
            End Get
            Set(value As Nullable(Of Integer))
                _JobComponentID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Job Comp", ShowColumnInGrid:=False, PropertyType:=BaseClasses.PropertyTypes.JobComponent)>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Job Comp Description", DefaultColumnType:=BaseClasses.DefaultColumnTypes.JobComponentDescription, IsReadOnlyColumn:=True)>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(value As String)
                _JobComponentDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property MediaType() As String
            Get
                MediaType = _MediaType
            End Get
            Set(value As String)
                _MediaType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n")>
        Public Property OrderNumber() As Nullable(Of Integer)
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As Nullable(Of Integer))
                _OrderNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property OrderDescription() As String
            Get
                OrderDescription = _OrderDescription
            End Get
            Set(value As String)
                _OrderDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n")>
        Public Property OrderLineNumber() As Nullable(Of Short)
            Get
                OrderLineNumber = _OrderLineNumber
            End Get
            Set(value As Nullable(Of Short))
                _OrderLineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.FunctionCode)>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.FunctionDescription, IsReadOnlyColumn:=True)>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(value As Nullable(Of Date))
                _InvoiceDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quantity() As Nullable(Of Decimal)
            Get
                Quantity = _Quantity
            End Get
            Set(value As Nullable(Of Decimal))
                _Quantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n4")>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(value As Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.EntityAttribute(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Amount() As Nullable(Of Decimal)
            Get
                Amount = _Amount
            End Get
            Set(value As Nullable(Of Decimal))
                _Amount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3", CustomColumnCaption:="Markup %")>
        Public Property CommissionPercent() As Nullable(Of Decimal)
            Get
                CommissionPercent = _CommissionPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _CommissionPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property MarkupAmount() As Nullable(Of Decimal)
            Get
                MarkupAmount = _MarkupAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _MarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.SalesTaxCode)>
        Public Property TaxCode() As String
            Get
                TaxCode = _TaxCode
            End Get
            Set(value As String)
                _TaxCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, IsReadOnlyColumn:=True, DisplayFormat:="n2")>
        Public Property Taxes() As Decimal
            Get
                Taxes = _CityTaxAmount.GetValueOrDefault(0) + _CountyTaxAmount.GetValueOrDefault(0) + _StateTaxAmount.GetValueOrDefault(0)
            End Get
            Set(value As Decimal)

            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True, CustomColumnCaption:="Total")>
        Public Property TotalAmount() As Decimal
            Get
                TotalAmount = Math.Round(_Amount.GetValueOrDefault(0) + _MarkupAmount.GetValueOrDefault(0) + Me.Taxes, 2, MidpointRounding.AwayFromZero)
            End Get
            Set(value As Decimal)

            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(value As String)
                _Description = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ReferenceNumber() As String
            Get
                ReferenceNumber = _ReferenceNumber
            End Get
            Set(value As String)
                _ReferenceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property Comment() As String
            Get
                Comment = _Comment
            End Get
            Set(value As String)
                _Comment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property BillingUser() As String
            Get
                BillingUser = _BillingUser
            End Get
            Set(value As String)
                _BillingUser = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property IsServiceFee As Boolean
            Get
                IsServiceFee = _IsServiceFee
            End Get
            Set(value As Boolean)
                _IsServiceFee = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, IsReadOnlyColumn:=True, CustomColumnCaption:="Billed", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property IsBilled() As Boolean
            Get
                IsBilled = _IsBilled
            End Get
            Set(value As Boolean)
                _IsBilled = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property NonBillable() As Boolean
            Get
                NonBillable = _NonBillable
            End Get
            Set(value As Boolean)
                _NonBillable = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False, DisplayFormat:="n2")>
        Public Property CityTaxAmount As Nullable(Of Decimal)
            Get
                CityTaxAmount = _CityTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _CityTaxAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False, DisplayFormat:="n2")>
        Public Property CountyTaxAmount As Nullable(Of Decimal)
            Get
                CountyTaxAmount = _CountyTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _CountyTaxAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False, DisplayFormat:="n2")>
        Public Property StateTaxAmount As Nullable(Of Decimal)
            Get
                StateTaxAmount = _StateTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _StateTaxAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n4", ShowColumnInGrid:=False)>
        Public Property TaxStatePercent() As Nullable(Of Decimal)
            Get
                TaxStatePercent = _TaxStatePercent
            End Get
            Set(value As Nullable(Of Decimal))
                _TaxStatePercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property TaxCityPercent() As Nullable(Of Decimal)
            Get
                TaxCityPercent = _TaxCityPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _TaxCityPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n4", ShowColumnInGrid:=False)>
        Public Property TaxCountyPercent() As Nullable(Of Decimal)
            Get
                TaxCountyPercent = _TaxCountyPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _TaxCountyPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property TaxCommission() As Nullable(Of Short)
            Get
                TaxCommission = _TaxCommission
            End Get
            Set(value As Nullable(Of Short))
                _TaxCommission = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property TaxCommissionOnly() As Nullable(Of Short)
            Get
                TaxCommissionOnly = _TaxCommissionOnly
            End Get
            Set(value As Nullable(Of Short))
                _TaxCommissionOnly = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n4", ShowColumnInGrid:=False)>
        Public Property TaxResale() As Nullable(Of Short)
            Get
                TaxResale = _TaxResale
            End Get
            Set(value As Nullable(Of Short))
                _TaxResale = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(value As String)
                _SalesClassCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property DepartmentTeamCode() As String
            Get
                DepartmentTeamCode = _DepartmentTeamCode
            End Get
            Set(value As String)
                _DepartmentTeamCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsRevised() As Boolean
            Get
                IsRevised = _IsRevised
            End Get
            Set(value As Boolean)
                _IsRevised = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsDeleted As Boolean
            Get
                IsDeleted = _IsDeleted
            End Get
            Set(value As Boolean)
                _IsDeleted = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property JobServiceFeeID As Nullable(Of Integer)
            Get
                JobServiceFeeID = _JobServiceFeeID
            End Get
            Set(value As Nullable(Of Integer))
                _JobServiceFeeID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property EverBilled As Boolean
            Get
                EverBilled = _EverBilled
            End Get
            Set(value As Boolean)
                _EverBilled = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _InvoiceDate = System.DateTime.Today

        End Sub
        Public Sub FillIncomeOnlyEntity(ByRef IncomeOnlyEntity As AdvantageFramework.Database.Entities.IncomeOnly)

            'objects
            Dim TaxableAmount As Decimal = Nothing

            If IncomeOnlyEntity Is Nothing Then

                IncomeOnlyEntity = New AdvantageFramework.Database.Entities.IncomeOnly

            End If

            IncomeOnlyEntity.ID = Me.ID
            IncomeOnlyEntity.SequenceNumber = Me.SequenceNumber
            IncomeOnlyEntity.JobNumber = Me.JobNumber
            IncomeOnlyEntity.JobComponentNumber = Me.JobComponentNumber
            IncomeOnlyEntity.FunctionCode = Me.FunctionCode
            IncomeOnlyEntity.InvoiceDate = Me.InvoiceDate
            IncomeOnlyEntity.Quantity = Me.Quantity
            IncomeOnlyEntity.Rate = Me.Rate
            IncomeOnlyEntity.Amount = Me.Amount.GetValueOrDefault(0)
            IncomeOnlyEntity.Description = Me.Description
            IncomeOnlyEntity.ReferenceNumber = Me.ReferenceNumber
            IncomeOnlyEntity.Comment = Me.Comment
            IncomeOnlyEntity.BillingUser = Me.BillingUser
            IncomeOnlyEntity.TaxCode = Me.TaxCode
            IncomeOnlyEntity.TaxCommission = Me.TaxCommission.GetValueOrDefault(0)
            IncomeOnlyEntity.TaxCommissionOnly = Me.TaxCommissionOnly.GetValueOrDefault(0)
            IncomeOnlyEntity.TaxResale = Me.TaxResale
            IncomeOnlyEntity.NonBillable = If(Me.NonBillable, 1, 0)
            IncomeOnlyEntity.CommissionPercent = Me.CommissionPercent
            IncomeOnlyEntity.TaxStatePercent = Me.TaxStatePercent
            IncomeOnlyEntity.TaxCityPercent = Me.TaxCityPercent
            IncomeOnlyEntity.TaxCountyPercent = Me.TaxCountyPercent
            IncomeOnlyEntity.ExtendedMarkupAmount = Me.MarkupAmount
            IncomeOnlyEntity.ExtendedCityResale = Me.CityTaxAmount
            IncomeOnlyEntity.ExtendedCountyResale = Me.CountyTaxAmount
            IncomeOnlyEntity.ExtendedStateResale = Me.StateTaxAmount
            IncomeOnlyEntity.LineTotal = Me.TotalAmount
            IncomeOnlyEntity.DepartmentTeamCode = Me.DepartmentTeamCode
            IncomeOnlyEntity.JobServiceFeeID = _JobServiceFeeID
            IncomeOnlyEntity.OrderNumber = Me.OrderNumber
            IncomeOnlyEntity.LineNumber = Me.OrderLineNumber

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.FunctionCode.ToString

                    PropertyValue = Value

                    If AdvantageFramework.Database.Procedures.Function.LoadCore(Me.DbContext).Any(Function(Entity) Entity.Code = PropertyValue AndAlso Entity.Type = "I") = False Then

                        IsValid = False
                        ErrorText = "Function must be an income only function."

                    End If
                    
            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace

