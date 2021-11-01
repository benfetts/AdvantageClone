Namespace BillingCommandCenter.Classes

    <Serializable()>
    Public Class AccountPayableWriteoff
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            FunctionDescription
            VendorName
            InvoiceDate
            InvoiceNumber
            OriginalQuantity
            OriginalExtendedAmount
            Quantity
            Rate
            NetAmount
            VendorTax
            TotalWriteOff
            GLACode
            GLAccountDescription
            PostPeriodCode
            AdjustmentComment
            WriteOffResaleTax
            WriteOffMarkup
        End Enum

#End Region

#Region " Variables "

        Private _AccountPayableProductionDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail = Nothing
        Private _VendorName As String = Nothing
        Private _InvoiceDate As Date = Nothing
        Private _InvoiceNumber As String = Nothing
        Private _OriginalQuantity As Nullable(Of Decimal) = Nothing
        Private _OriginalExtendedAmount As Decimal = Nothing
        Private _AccountPayableID As Integer = Nothing
        Private _LineNumber As Short = Nothing
        Private _AccountPayableProductionDistributionDetailOriginal As AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail = Nothing
        Private _FunctionDescription As String = Nothing
        Private _GLAccountDescription As String = Nothing
        Private _Session As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property AccountPayableProductionDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail
            Get
                AccountPayableProductionDistributionDetail = _AccountPayableProductionDistributionDetail
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property AccountPayableProductionDistributionDetailOriginal As AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail
            Get
                AccountPayableProductionDistributionDetailOriginal = _AccountPayableProductionDistributionDetailOriginal
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property InvoiceDate() As Date
            Get
                InvoiceDate = _InvoiceDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property InvoiceNumber() As String
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property OriginalQuantity() As Nullable(Of Decimal)
            Get
                OriginalQuantity = _OriginalQuantity
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property OriginalExtendedAmount() As Decimal
            Get
                OriginalExtendedAmount = _OriginalExtendedAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Quantity() As Nullable(Of Decimal)
            Get
                Quantity = _AccountPayableProductionDistributionDetail.Quantity
            End Get
            Set(value As Nullable(Of Decimal))
                _AccountPayableProductionDistributionDetail.Quantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _AccountPayableProductionDistributionDetail.Rate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public Property NetAmount() As Nullable(Of Decimal)
            Get
                NetAmount = _AccountPayableProductionDistributionDetail.ExtendedAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _AccountPayableProductionDistributionDetail.ExtendedAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property VendorTax() As Decimal
            Get
                VendorTax = _AccountPayableProductionDistributionDetail.ExtendedNonResaleTax.GetValueOrDefault(0)
            End Get
            Set(value As Decimal)
                _AccountPayableProductionDistributionDetail.ExtendedNonResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property TotalWriteOff() As Decimal
            Get
                TotalWriteOff = _AccountPayableProductionDistributionDetail.LineTotal.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode, CustomColumnCaption:="GL Account")>
        Public Property GLACode() As String
            Get
                GLACode = _AccountPayableProductionDistributionDetail.GLACode
            End Get
            Set(value As String)
                _AccountPayableProductionDistributionDetail.GLACode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.GeneralLedgerAccountDescription, CustomColumnCaption:="GL Account Description", IsReadOnlyColumn:=True)>
        Public Property GLAccountDescription() As String
            Get
                GLAccountDescription = _GLAccountDescription
            End Get
            Set(value As String)
                _GLAccountDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.PostPeriodCode, CustomColumnCaption:="Post Period")>
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _AccountPayableProductionDistributionDetail.AccountPayableProduction.PostPeriodCode
            End Get
            Set(value As String)
                _AccountPayableProductionDistributionDetail.AccountPayableProduction.PostPeriodCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property AdjustmentComment() As String
            Get
                AdjustmentComment = _AccountPayableProductionDistributionDetail.AccountPayableProduction.AdjustmentComments
            End Get
            Set(value As String)
                _AccountPayableProductionDistributionDetail.AccountPayableProduction.AdjustmentComments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property WriteOffResaleTax() As Decimal
            Get
                WriteOffResaleTax = _AccountPayableProductionDistributionDetail.ResaleTax
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", ShowColumnInGrid:=False)>
        Public ReadOnly Property WriteOffMarkup() As Decimal
            Get
                WriteOffMarkup = _AccountPayableProductionDistributionDetail.ExtendedMarkupAmount.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property AccountPayableID() As Integer
            Get
                AccountPayableID = _AccountPayableID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property LineNumber() As Short
            Get
                LineNumber = _LineNumber
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableProduction As AdvantageFramework.Database.Entities.AccountPayableProduction,
                       Session As AdvantageFramework.Security.Session)

            Dim AccountPayableProductionCopy As AdvantageFramework.Database.Entities.AccountPayableProduction = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing

            _Session = Session

            AccountPayable = (From AP In AdvantageFramework.Database.Procedures.AccountPayable.LoadAllByAccountPayableID(DbContext, AccountPayableProduction.AccountPayableID)
                              Select AP).OrderByDescending(Function(AP) AP.SequenceNumber).FirstOrDefault

            _VendorName = AccountPayable.Vendor.Name
            _InvoiceDate = AccountPayable.InvoiceDate
            _InvoiceNumber = AccountPayable.InvoiceNumber
            _AccountPayableID = AccountPayableProduction.AccountPayableID
            _LineNumber = AccountPayableProduction.LineNumber

            _AccountPayableProductionDistributionDetailOriginal = New AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail(DbContext, AccountPayableProduction, Session)

            _OriginalQuantity = AccountPayableProduction.Quantity
            _OriginalExtendedAmount = AccountPayableProduction.ExtendedAmount.GetValueOrDefault(0)

            AccountPayableProductionCopy = AccountPayableProduction.Copy

            _AccountPayableProductionDistributionDetail = New AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail(Session)
            _AccountPayableProductionDistributionDetail.SetValuesFromAccountPayableProduction(DbContext, AccountPayableProductionCopy)

            _AccountPayableProductionDistributionDetail.Quantity = AccountPayableProductionCopy.Quantity
            _AccountPayableProductionDistributionDetail.Rate = AccountPayableProductionCopy.Rate
            _AccountPayableProductionDistributionDetail.ExtendedAmount = AccountPayableProductionCopy.ExtendedAmount

            _AccountPayableProductionDistributionDetail.ExtendedMarkupAmount = FormatNumber(_AccountPayableProductionDistributionDetail.ExtendedAmount.GetValueOrDefault(0) *
                                                                                            _AccountPayableProductionDistributionDetail.CommissionPercent.GetValueOrDefault(0) / 100, 2)

            'AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.CalculateTax(DbContext, _AccountPayableProductionDistributionDetail.AccountPayableProduction)

            _AccountPayableProductionDistributionDetail.AccountPayableProduction.SetLineTotal()

            _AccountPayableProductionDistributionDetail.AccountPayableProduction.AdjustmentComments = Nothing

            _AccountPayableProductionDistributionDetail.AccountPayableProduction.IsNonBillable = 1
            _AccountPayableProductionDistributionDetail.AccountPayableProduction.IsWriteOff = 1

            PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentAPPostPeriod(DbContext)

            If PostPeriod IsNot Nothing Then

                _AccountPayableProductionDistributionDetail.AccountPayableProduction.PostPeriodCode = PostPeriod.Code

            Else

                _AccountPayableProductionDistributionDetail.AccountPayableProduction.PostPeriodCode = Nothing

            End If

            [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, _AccountPayableProductionDistributionDetail.AccountPayableProduction.FunctionCode)

            If [Function] IsNot Nothing Then

                _FunctionDescription = [Function].Description

            End If

            _AccountPayableProductionDistributionDetail.GLACode = Nothing
            _AccountPayableProductionDistributionDetail.GLADescription = Nothing

            If [Function] IsNot Nothing AndAlso [Function].NonBillableClientGLACode IsNot Nothing Then

                _AccountPayableProductionDistributionDetail.GLACode = [Function].NonBillableClientGLACode

                If [Function].NonBillableGeneralLedgerAccount IsNot Nothing Then

                    _GLAccountDescription = [Function].NonBillableGeneralLedgerAccount.Description

                End If

            End If

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff.Properties.Quantity.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso _OriginalQuantity IsNot Nothing Then

                        If PropertyValue < System.Math.Min(0.01, _OriginalQuantity.Value) OrElse PropertyValue > System.Math.Max(0.01, _OriginalQuantity.Value) Then

                            IsValid = False

                            ErrorText = "Write off quantity should be between " & CStr(System.Math.Min(0.01, _OriginalQuantity.Value)) & " and " & CStr(System.Math.Max(0.01, _OriginalQuantity.Value)) & "."

                        End If

                    End If

                Case AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff.Properties.NetAmount.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If PropertyValue < System.Math.Min(0.01, _OriginalExtendedAmount) OrElse PropertyValue > System.Math.Max(0.01, _OriginalExtendedAmount) Then

                            IsValid = False

                            ErrorText = "Write off amount should be between " & CStr(System.Math.Min(0.01, _OriginalExtendedAmount)) & " and " & CStr(System.Math.Max(0.01, _OriginalExtendedAmount)) & "."

                        End If

                    End If

                Case AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff.Properties.GLACode.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If (From Entity In AdvantageFramework.AccountPayable.GetProductionGLAccountList(DbContext, Me.AccountPayableProductionDistributionDetail.OfficeCode, _Session)
                            Where Entity.Code = DirectCast(PropertyValue, String)
                            Select Entity).Any = False Then

                            IsValid = False

                            ErrorText = "Invalid GL Account."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace