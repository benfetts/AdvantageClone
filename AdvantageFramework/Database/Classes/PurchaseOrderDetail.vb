Namespace Database.Classes

    <Serializable()>
    Public Class PurchaseOrderDetail
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            PONumber
            LineNumber
            LineDescription
            DetailDescription
            Instructions
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentID
            JobComponentDescription
            FunctionCode
            FunctionDescription
            GeneralLedgerCode
            Quantity
            Rate
            ExtendedAmount
            CommissionPercent
            TaxPercent
            ExtendedMarkupAmount
            LineTotal
            BillingApprovalID
            UseCPM
            CanDelete
            IsAttachedToAP
            IsComplete
            BalanceNet
            POUsed
            EstimateBudgetNet
            LockedByJobComp
        End Enum

#End Region

#Region " Variables "

        Private _PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing
        Private _PONumber As Integer = Nothing
        Private _LineNumber As Integer = Nothing
        Private _LineDescription As String = Nothing
        Private _DetailDescription As String = Nothing
        Private _Instructions As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentID As Nullable(Of Integer) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _GeneralLedgerCode As String = Nothing
        Private _Quantity As Nullable(Of Integer) = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _ExtendedAmount As Nullable(Of Decimal) = Nothing
        Private _CommissionPercent As Nullable(Of Decimal) = Nothing
        Private _TaxPercent As Nullable(Of Decimal) = Nothing
        Private _ExtendedMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _LineTotal As Nullable(Of Decimal) = Nothing
        Private _BillingApprovalID As Nullable(Of Integer) = Nothing
        Private _UseCPM As Nullable(Of Boolean) = Nothing
        Private _IsAttachedToAP As Nullable(Of Boolean) = Nothing
        Private _CanDelete As Nullable(Of Boolean) = Nothing
        Private _IsComplete As Nullable(Of Short) = Nothing
        Private _BalanceNet As Nullable(Of Decimal) = Nothing
        Private _POUsed As Nullable(Of Decimal) = Nothing
        Private _EstimateBudgetNet As Nullable(Of Decimal) = Nothing
        Private _LockedByJobComp As Nullable(Of Boolean) = Nothing

#End Region

#Region " Properties "

        Public Overrides ReadOnly Property AttachedEntityType As Type
            Get
                AttachedEntityType = GetType(AdvantageFramework.Database.Entities.PurchaseOrderDetail)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property PONumber() As Integer
            Get
                PONumber = _PONumber
            End Get
            Set(ByVal value As Integer)
                _PONumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property LineNumber() As Integer
            Get
                LineNumber = _LineNumber
            End Get
            Set(ByVal value As Integer)
                _LineNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Description")>
        Public Property LineDescription() As String
            Get
                LineDescription = _LineDescription
            End Get
            Set(ByVal value As String)
                _LineDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property DetailDescription() As String
            Get
                DetailDescription = _DetailDescription
            End Get
            Set(ByVal value As String)
                _DetailDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property Instructions() As String
            Get
                Instructions = _Instructions
            End Get
            Set(ByVal value As String)
                _Instructions = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Client Name", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ClientName)>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(ByVal value As String)
                _ClientName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.DivisionCode)>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Division Name", DefaultColumnType:=BaseClasses.DefaultColumnTypes.DivisionName)>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(ByVal value As String)
                _DivisionName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ProductCode)>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Product Description", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ProductName)>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(ByVal value As String)
                _ProductDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Job", PropertyType:=BaseClasses.PropertyTypes.JobNumber)>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobNumber = value
                CalculateItem()
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Job Description", DefaultColumnType:=BaseClasses.DefaultColumnTypes.JobDescription)>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(ByVal value As String)
                _JobDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, PropertyType:=BaseClasses.PropertyTypes.JobComponent)>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Component", PropertyType:=BaseClasses.PropertyTypes.JobComponentID)>
        Public Property JobComponentID() As Nullable(Of Integer)
            Get
                JobComponentID = _JobComponentID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobComponentID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Component Description", DefaultColumnType:=BaseClasses.DefaultColumnTypes.JobComponentDescription)>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(ByVal value As String)
                _JobComponentDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.VendorFunctionCode)>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.FunctionDescription)>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(ByVal value As String)
                _FunctionDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GeneralLedgerCode() As String
            Get
                GeneralLedgerCode = _GeneralLedgerCode
            End Get
            Set(ByVal value As String)
                _GeneralLedgerCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0")>
        Public Property Quantity() As Nullable(Of Integer)
            Get
                Quantity = _Quantity
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _Quantity = value
                CalculateItem()
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F4")>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Rate = value
                CalculateItem()
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ExtendedAmount() As Nullable(Of Decimal)
            Get
                ExtendedAmount = _ExtendedAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ExtendedAmount = value
                CalculateItem()
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property TaxPercent() As Nullable(Of Decimal)
            Get
                TaxPercent = _TaxPercent
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TaxPercent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F3", CustomColumnCaption:="Markup Percent")>
        Public Property CommissionPercent() As Nullable(Of Decimal)
            Get
                CommissionPercent = _CommissionPercent
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CommissionPercent = value
                CalculateItem()
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Markup Amount")>
        Public Property ExtendedMarkupAmount() As Nullable(Of Decimal)
            Get
                ExtendedMarkupAmount = _ExtendedMarkupAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ExtendedMarkupAmount = value
                CalculateItem()
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property LineTotal As Nullable(Of Decimal)
            Get
                LineTotal = _LineTotal
            End Get
            Set(value As Nullable(Of Decimal))
                _LineTotal = value
            End Set
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Estimate / Budget (Net)", IsReadOnlyColumn:=True)>
        Public Property EstimateBudgetNet As Nullable(Of Decimal)
            Get
                EstimateBudgetNet = _EstimateBudgetNet
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimateBudgetNet = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="PO Used (Net)", IsReadOnlyColumn:=True)>
        Public Property POUsed As Nullable(Of Decimal)
            Get
                POUsed = _POUsed
            End Get
            Set(value As Nullable(Of Decimal))
                _POUsed = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Balance (Net)", IsReadOnlyColumn:=True)>
        Public Property BalanceNet As Nullable(Of Decimal)
            Get
                BalanceNet = _BalanceNet
            End Get
            Set(value As Nullable(Of Decimal))
                _BalanceNet = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property BillingApprovalID() As Nullable(Of Integer)
            Get
                BillingApprovalID = _BillingApprovalID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _BillingApprovalID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox, CustomColumnCaption:="CPM")>
        Public Property UseCPM() As Nullable(Of Boolean)
            Get
                UseCPM = _UseCPM
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _UseCPM = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox, CustomColumnCaption:="Attached to A/P")>
        Public Property IsAttachedToAP() As Nullable(Of Boolean)
            Get
                IsAttachedToAP = _IsAttachedToAP
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _IsAttachedToAP = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property CanDelete() As Nullable(Of Boolean)
            Get
                CanDelete = _CanDelete
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _CanDelete = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsComplete() As Nullable(Of Short)
            Get
                IsComplete = _IsComplete
            End Get
            Set(ByVal value As Nullable(Of Short))
                _IsComplete = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property LockedByJobComp() As Nullable(Of Boolean)
            Get
                LockedByJobComp = _LockedByJobComp
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _LockedByJobComp = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _PurchaseOrderDetail = New AdvantageFramework.Database.Entities.PurchaseOrderDetail

        End Sub
        Public Function GetPurchaseOrderDetail() As AdvantageFramework.Database.Entities.PurchaseOrderDetail

            Try

                If _PurchaseOrderDetail Is Nothing Then

                    _PurchaseOrderDetail = New AdvantageFramework.Database.Entities.PurchaseOrderDetail

                End If

                _PurchaseOrderDetail.PurchaseOrderNumber = _PONumber
                _PurchaseOrderDetail.LineNumber = _LineNumber
                _PurchaseOrderDetail.LineDescription = _LineDescription
                _PurchaseOrderDetail.Description = _DetailDescription
                _PurchaseOrderDetail.Instructions = _Instructions
                _PurchaseOrderDetail.JobNumber = _JobNumber
                _PurchaseOrderDetail.JobComponentNumber = _JobComponentNumber
                _PurchaseOrderDetail.FunctionCode = _FunctionCode
                _PurchaseOrderDetail.GLACode = _GeneralLedgerCode
                _PurchaseOrderDetail.Quantity = _Quantity
                _PurchaseOrderDetail.Rate = _Rate
                _PurchaseOrderDetail.ExtendedAmount = _ExtendedAmount
                _PurchaseOrderDetail.CommissionPercent = _CommissionPercent
                _PurchaseOrderDetail.TaxPercent = _TaxPercent

                If _ExtendedMarkupAmount.HasValue Then

                    _PurchaseOrderDetail.ExtendedMarkupAmount = Math.Round(_ExtendedMarkupAmount.Value, 2, MidpointRounding.AwayFromZero)

                Else

                    _PurchaseOrderDetail.ExtendedMarkupAmount = Nothing

                End If

                _PurchaseOrderDetail.BillingApprovalID = _BillingApprovalID
                _PurchaseOrderDetail.IsComplete = _IsComplete

            Catch ex As Exception

            End Try

            GetPurchaseOrderDetail = _PurchaseOrderDetail
            
        End Function
        Public Sub CalculateItem()

            If Me.JobNumber.HasValue Then

                Try

                    _ExtendedMarkupAmount = Math.Round(_ExtendedAmount.GetValueOrDefault(0) * (_CommissionPercent.GetValueOrDefault(0) / 100), 2, MidpointRounding.AwayFromZero)

                Catch ex As Exception
                    _ExtendedMarkupAmount = 0
                End Try

                Try

                    _LineTotal = _ExtendedMarkupAmount.GetValueOrDefault(0) + _ExtendedAmount.GetValueOrDefault(0)

                Catch ex As Exception

                End Try

            Else

                _ExtendedMarkupAmount = 0
                _CommissionPercent = Nothing
                _LineTotal = _ExtendedAmount

            End If

        End Sub
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            _DbContext = _DbContext

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Function ValidateCustomProperties(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            ' Objects
            Dim ErrorText As String = ""

            If PropertyName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobComponentID.ToString OrElse _
               PropertyName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ClientCode.ToString OrElse _
               PropertyName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.DivisionCode.ToString OrElse _
               PropertyName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ProductCode.ToString OrElse _
               PropertyName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.LineTotal.ToString OrElse _
               PropertyName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.IsAttachedToAP.ToString Then

                ErrorText &= MyBase.ValidateCustomProperties(PropertyName, IsValid, Value)

            Else

                ErrorText &= _PurchaseOrderDetail.ValidateCustomProperties(PropertyName, IsValid, Value)

            End If

            ValidateCustomProperties = ErrorText

        End Function
        Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = Nothing
            Dim IsRequired As Boolean = False
            Dim AllowedProcessControls As Short() = {1, 3, 4, 8, 9}
            Dim PropertyValue As Object = Nothing

            _DbContext = _DbContext

            If PropertyName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobComponentID.ToString OrElse
               PropertyName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ClientCode.ToString OrElse _
               PropertyName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.DivisionCode.ToString OrElse _
               PropertyName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ProductCode.ToString OrElse _
               PropertyName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobNumber.ToString  Then

                SetRequired(PropertyName, IsCDPJobCompRequired())

                ErrorText = MyBase.ValidateEntityProperty(PropertyName, IsValid, Value)

                If IsValid Then

                    If PropertyName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobComponentID.ToString Then

                        If Value IsNot Nothing Then

                            PropertyValue = CInt(Value)

                            If (From Item In AdvantageFramework.Database.Procedures.JobComponent.Load(Me.DbContext) _
                                Where Item.ID = DirectCast(PropertyValue, Integer) AndAlso _
                                      AllowedProcessControls.Contains(Item.JobProcessNumber) _
                                Select Item).Any = False Then

                                IsValid = False
                                ErrorText = AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(BaseClasses.PropertyTypes.JobComponent)

                            End If

                        End If

                    End If

                End If

            ElseIf PropertyName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.FunctionCode.ToString Then

                SetRequired(PropertyName, IsFunctionRequired())

                ErrorText = MyBase.ValidateEntityProperty(PropertyName, IsValid, Value)

            ElseIf PropertyName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.GeneralLedgerCode.ToString Then

                SetRequired(PropertyName, IsGLACodeRequired())

                ErrorText = MyBase.ValidateEntityProperty(PropertyName, IsValid, Value)

            ElseIf PropertyName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.LineTotal.ToString OrElse _
                   PropertyName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.IsAttachedToAP.ToString Then

                ErrorText = MyBase.ValidateEntityProperty(PropertyName, IsValid, Value)

            ElseIf PropertyName <> AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobComponentNumber.ToString Then

                ErrorText = _PurchaseOrderDetail.ValidateEntityProperty(PropertyName, IsValid, Value)

            End If

            _ErrorHashtable(PropertyName) = ErrorText

            ValidateEntityProperty = ErrorText

        End Function
        Private Function IsCDPJobCompRequired() As Boolean

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
            End Try

            IsCDPJobCompRequired = IsRequired

        End Function
        Private Function IsFunctionRequired() As Boolean

            'objects
            Dim FunctionRequired As Boolean = False

            Try

                If IsCDPJobCompRequired() Then

                    FunctionRequired = True

                ElseIf String.IsNullOrEmpty(Me.GeneralLedgerCode) Then

                    FunctionRequired = True

                End If

            Catch ex As Exception
                FunctionRequired = False
            End Try

            IsFunctionRequired = FunctionRequired

        End Function
        Private Function IsGLACodeRequired() As Boolean

            'objects
            Dim GLACodeRequired As Boolean = False

            Try

                If String.IsNullOrEmpty(Me.FunctionCode) Then

                    If IsCDPJobCompRequired() = False Then

                        GLACodeRequired = True

                    End If

                End If

            Catch ex As Exception
                GLACodeRequired = False
            End Try

            IsGLACodeRequired = GLACodeRequired

        End Function
        Public Overrides Sub SetRequiredFields()

            'objects
            Dim IsRequired As Boolean = False

            IsRequired = IsCDPJobCompRequired()

            SetRequired(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ClientCode.ToString, IsRequired)
            SetRequired(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.DivisionCode.ToString, IsRequired)
            SetRequired(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ProductCode.ToString, IsRequired)
            SetRequired(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobNumber.ToString, IsRequired)
            SetRequired(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobComponentID.ToString, IsRequired)
            SetRequired(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.FunctionCode.ToString, IsFunctionRequired())
            SetRequired(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.GeneralLedgerCode.ToString, IsGLACodeRequired())

        End Sub

#End Region

    End Class

    <Serializable()>
    Public Class PurchaseOrderDetailWebSerializable

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            PONumber
            LineNumber
            LineDescription
            DetailDescription
            Instructions
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentID
            JobComponentDescription
            FunctionCode
            FunctionDescription
            GeneralLedgerCode
            Quantity
            Rate
            ExtendedAmount
            CommissionPercent
            TaxPercent
            ExtendedMarkupAmount
            LineTotal
            BillingApprovalID
            UseCPM
            CanDelete
            IsAttachedToAP
            IsComplete
            BalanceNet
            POUsed
            EstimateBudgetNet
            LockedByJobComp
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property PONumber As Integer = 0
        Public Property LineNumber As Integer = 0
        Public Property LineDescription As String = String.Empty
        Public Property DetailDescription As String = Nothing
        Public Property Instructions As String = Nothing
        Public Property ClientCode As String = Nothing
        Public Property ClientName As String = Nothing
        Public Property DivisionCode As String = Nothing
        Public Property DivisionName As String = Nothing
        Public Property ProductCode As String = Nothing
        Public Property ProductDescription As String = Nothing
        Public Property JobNumber As Nullable(Of Integer) = Nothing
        Public Property JobDescription As String = Nothing
        Public Property JobComponentNumber As Nullable(Of Short) = Nothing
        Public Property JobComponentID As Nullable(Of Integer) = Nothing
        Public Property JobComponentDescription As String = Nothing
        Public Property FunctionCode As String = Nothing
        Public Property FunctionDescription As String = Nothing
        Public Property GeneralLedgerCode As String = Nothing
        Public Property Quantity As Nullable(Of Integer) = Nothing
        Public Property Rate As Nullable(Of Decimal) = Nothing
        Public Property ExtendedAmount As Nullable(Of Decimal) = Nothing
        Public Property CommissionPercent As Nullable(Of Decimal) = Nothing
        Public Property TaxPercent As Nullable(Of Decimal) = Nothing
        Public Property ExtendedMarkupAmount As Nullable(Of Decimal) = Nothing
        Public Property LineTotal As Nullable(Of Decimal) = Nothing
        Public Property BillingApprovalID As Nullable(Of Integer) = Nothing
        Public Property UseCPM As Nullable(Of Boolean) = Nothing
        Public Property IsAttachedToAP As Nullable(Of Boolean) = Nothing
        Public Property CanDelete As Nullable(Of Boolean) = Nothing
        Public Property IsComplete As Nullable(Of Short) = Nothing
        Public Property BalanceNet As Nullable(Of Decimal) = Nothing
        Public Property POUsed As Nullable(Of Decimal) = Nothing
        Public Property EstimateBudgetNet As Nullable(Of Decimal) = Nothing
        Public Property LockedByJobComp As Nullable(Of Boolean) = Nothing

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace