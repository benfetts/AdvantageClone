Namespace Database.Classes

    <Serializable()>
    Public Class ImportAccountPayableOrder
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            OrderID
            LineNumber
            RevNbr
            MediaType
            SalesClassCode
            ClientCode
            DivisionCode
            ProductCode
            VendorCode
            StartDate
            EndDate
            NetGross
            CommPct
            NetRate
            GrossRate
            TotalSpots
            RateType
            CostType
            Cost
            Columns
            Inches
            LinesCirculation
        End Enum

#End Region

#Region " Variables "

        Private _OrderID As Nullable(Of Integer) = Nothing
        Private _LineNumber As Nullable(Of Short) = Nothing
        Private _MediaType As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _VendorCode As String = Nothing
        Private _StartDate As Nullable(Of Date) = Nothing
        Private _EndDate As Nullable(Of Date) = Nothing
        Private _NetGross As Nullable(Of Integer) = Nothing
        Private _CommPct As Nullable(Of Decimal) = Nothing
        Private _NetRate As Nullable(Of Decimal) = Nothing
        Private _GrossRate As Nullable(Of Decimal) = Nothing
        Private _TotalSpots As Nullable(Of Integer) = Nothing
        Private _ImportAccountPayableMediaID As Integer = Nothing
        Private _RateType As String = Nothing
        Private _CostType As String = Nothing
        Private _Cost As Nullable(Of Decimal) = Nothing
        Private _ImportAccountPayableMediaNetAmount As Nullable(Of Decimal) = Nothing
        Private _Columns As Nullable(Of Decimal) = Nothing
        Private _Inches As Nullable(Of Decimal) = Nothing
        Private _LinesCirculation As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OrderID() As Nullable(Of Integer)
            Get
                OrderID = _OrderID
            End Get
            Set(value As Nullable(Of Integer))
                _OrderID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property LineNumber() As Nullable(Of Short)
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Nullable(Of Short))
                _LineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public ReadOnly Property RevNbr() As Integer
            Get
                RevNbr = 0
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property MediaType() As String
            Get
                MediaType = _MediaType
            End Get
            Set(value As String)
                _MediaType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.SalesClassCode, ShowColumnInGrid:=False)>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(value As String)
                _SalesClassCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ClientCode, IsReadOnlyColumn:=True)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.DivisionCode, IsReadOnlyColumn:=True)>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ProductCode, IsReadOnlyColumn:=True)>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.VendorCode, CustomColumnCaption:="Vendor")>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StartDate() As Nullable(Of Date)
            Get
                StartDate = _StartDate
            End Get
            Set(value As Nullable(Of Date))
                _StartDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property EndDate() As Nullable(Of Date)
            Get
                EndDate = _EndDate
            End Get
            Set(value As Nullable(Of Date))
                _EndDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property NetGross() As Nullable(Of Integer)
            Get
                NetGross = _NetGross
            End Get
            Set(value As Nullable(Of Integer))
                _NetGross = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2", CustomColumnCaption:="Markup %")>
        Public Property CommPct() As Nullable(Of Decimal)
            Get
                CommPct = _CommPct
            End Get
            Set(value As Nullable(Of Decimal))
                _CommPct = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n4")>
        Public Property NetRate() As Nullable(Of Decimal)
            Get
                NetRate = _NetRate
            End Get
            Set(value As Nullable(Of Decimal))
                _NetRate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n4")>
        Public Property GrossRate() As Nullable(Of Decimal)
            Get
                GrossRate = _GrossRate
            End Get
            Set(value As Nullable(Of Decimal))
                _GrossRate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True, CustomColumnCaption:="Quantity")>
        Public Property TotalSpots() As Nullable(Of Integer)
            Get
                TotalSpots = _TotalSpots
            End Get
            Set(value As Nullable(Of Integer))
                _TotalSpots = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property RateType() As String
            Get
                If Me.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString Then
                    _RateType = "CPM"
                Else
                    _RateType = "STD"
                End If
                RateType = _RateType
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CostType() As String
            Get
                CostType = _CostType
            End Get
            Set(value As String)
                _CostType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public ReadOnly Property Cost() As Nullable(Of Decimal)
            Get
                If Me.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString Then
                    _Cost = Me.TotalSpots * Me.NetRate / 1000
                Else
                    _Cost = _ImportAccountPayableMediaNetAmount
                End If
                Cost = _Cost
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ImportAccountPayableMediaID() As Integer
            Get
                ImportAccountPayableMediaID = _ImportAccountPayableMediaID
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal MediaPlanningData As AdvantageFramework.Exporting.DataClasses.MediaPlanningData)

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
            Dim BroadcastImportCrossReference As AdvantageFramework.Database.Entities.BroadcastImportCrossReference = Nothing

            Me.ObjectContext = ObjectContext

            _MediaType = MediaPlanningData.MediaType

            _SalesClassCode = MediaPlanningData.SalesClassCode
            _ClientCode = MediaPlanningData.ClientCode
            _DivisionCode = MediaPlanningData.DivisionCode
            _ProductCode = MediaPlanningData.ProductCode
            _VendorCode = MediaPlanningData.VendorCode
            _StartDate = MediaPlanningData.Date
            _EndDate = MediaPlanningData.Date

            Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(ObjectContext, _ClientCode, _DivisionCode, _ProductCode)
            MediaPlanDetail = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanDetailID(ObjectContext, MediaPlanningData.EstimateID, False)

            If Product IsNot Nothing AndAlso MediaPlanDetail IsNot Nothing Then

                _CommPct = 0

                If MediaPlanningData.MediaTypeCode = "R" Then

                    If Product.RadioBillNet = 1 Then

                        If MediaPlanDetail.IsEstimateGrossAmount Then

                            _CommPct = 0.85

                        End If

                    Else

                        If MediaPlanDetail.IsEstimateGrossAmount Then

                            _CommPct = Product.RadioRebate.GetValueOrDefault(0)

                        Else

                            _CommPct = Product.RadioMarkup.GetValueOrDefault(0)

                        End If

                    End If

                ElseIf MediaPlanningData.MediaTypeCode = "T" Then

                    If Product.TelevisionBillNet = 1 Then

                        If MediaPlanDetail.IsEstimateGrossAmount Then

                            _CommPct = 0.85

                        End If

                    Else

                        If MediaPlanDetail.IsEstimateGrossAmount Then

                            _CommPct = Product.TelevisionRebate.GetValueOrDefault(0)

                        Else

                            _CommPct = Product.TelevisionMarkup.GetValueOrDefault(0)

                        End If

                    End If

                ElseIf MediaPlanningData.MediaTypeCode = "M" Then

                    If Product.MagazineBillNet = 1 Then

                        If MediaPlanDetail.IsEstimateGrossAmount Then

                            _CommPct = 0.85

                        End If

                    Else

                        If MediaPlanDetail.IsEstimateGrossAmount Then

                            _CommPct = Product.MagazineRebate.GetValueOrDefault(0)

                        Else

                            _CommPct = Product.MagazineMarkup.GetValueOrDefault(0)

                        End If

                    End If

                ElseIf MediaPlanningData.MediaTypeCode = "O" Then

                    If Product.OutOfHomeBillNet = 1 Then

                        If MediaPlanDetail.IsEstimateGrossAmount Then

                            _CommPct = 0.85

                        End If

                    Else

                        If MediaPlanDetail.IsEstimateGrossAmount Then

                            _CommPct = Product.OutOfHomeRebate.GetValueOrDefault(0)

                        Else

                            _CommPct = Product.OutOfHomeMarkup.GetValueOrDefault(0)

                        End If

                    End If

                ElseIf MediaPlanningData.MediaTypeCode = "I" Then

                    If Product.InternetBillNet = 1 Then

                        If MediaPlanDetail.IsEstimateGrossAmount Then

                            _CommPct = 0.85

                        End If

                    Else

                        If MediaPlanDetail.IsEstimateGrossAmount Then

                            _CommPct = Product.InternetRebate.GetValueOrDefault(0)

                        Else

                            _CommPct = Product.InternetMarkup.GetValueOrDefault(0)

                        End If

                    End If

                ElseIf MediaPlanningData.MediaTypeCode = "N" Then

                    If Product.NewspaperBillNet = 1 Then

                        If MediaPlanDetail.IsEstimateGrossAmount Then

                            _CommPct = 0.85

                        End If

                    Else

                        If MediaPlanDetail.IsEstimateGrossAmount Then

                            _CommPct = Product.NewspaperRebate.GetValueOrDefault(0)

                        Else

                            _CommPct = Product.NewspaperMarkup.GetValueOrDefault(0)

                        End If

                    End If

                End If

            End If

            _NetGross = 0

            CalculateGross(ObjectContext, MediaPlanningData)

        End Sub
        Private Sub CalculateGross(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal MediaPlanningData As AdvantageFramework.Exporting.DataClasses.MediaPlanningData)

            'objects
            Dim FirstVisibleQuantityColumn As AdvantageFramework.MediaPlanning.DataColumns = MediaPlanning.DataColumns.ID
            Dim SecondVisibleQuantityColumn As AdvantageFramework.MediaPlanning.DataColumns = MediaPlanning.DataColumns.ID
            Dim ThirdVisibleQuantityColumn As AdvantageFramework.MediaPlanning.DataColumns = MediaPlanning.DataColumns.ID
            Dim MediaQuantity As Decimal = 0
            Dim CommissionAmount As Decimal = 0
            Dim GrossAmount As Decimal = 0

            Try

                For Each Entity In AdvantageFramework.Database.Procedures.MediaPlanDetailField.LoadByMediaPlanDetailID(ObjectContext, MediaPlanningData.EstimateID).Where(Function(MPDF) MPDF.Area = 3 AndAlso MPDF.IsVisible = True).OrderBy(Function(MPDF) MPDF.AreaIndex).ToList

                    If Entity.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString Then

                        If Entity.IsVisible Then

                            If FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Units

                            ElseIf SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Units

                            ElseIf ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Units

                            End If

                        End If

                    ElseIf Entity.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString Then

                        If Entity.IsVisible Then

                            If FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Impressions

                            ElseIf SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Impressions

                            ElseIf ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Impressions

                            End If

                        End If

                    ElseIf Entity.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString Then

                        If Entity.IsVisible Then

                            If FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Clicks

                            ElseIf SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Clicks

                            ElseIf ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Clicks

                            End If

                        End If

                    End If

                Next

            Catch ex As Exception

            End Try

            If FirstVisibleQuantityColumn = MediaPlanning.DataColumns.Units Then

                MediaQuantity = MediaPlanningData.Units.GetValueOrDefault(0)

            ElseIf FirstVisibleQuantityColumn = MediaPlanning.DataColumns.Impressions Then

                MediaQuantity = MediaPlanningData.Impressions.GetValueOrDefault(0)

            ElseIf FirstVisibleQuantityColumn = MediaPlanning.DataColumns.Clicks Then

                MediaQuantity = MediaPlanningData.Clicks.GetValueOrDefault(0)

            End If

            If MediaQuantity = 0 Then

                _TotalSpots = 1

                _NetRate = MediaPlanningData.BillAmount

            Else

                _TotalSpots = MediaQuantity

                _NetRate = MediaPlanningData.BillAmount.GetValueOrDefault(0) / MediaQuantity

            End If

            GrossAmount = FormatNumber(MediaPlanningData.BillAmount.GetValueOrDefault(0), 2)

            If _TotalSpots = 1 Then

                _GrossRate = GrossAmount

            Else

                _GrossRate = GrossAmount / MediaQuantity

            End If

        End Sub
        Public Sub New(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal ImportAccountPayable As AdvantageFramework.Database.Classes.ImportAccountPayable)

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Me.ObjectContext = ObjectContext

            _MediaType = ImportAccountPayable.MediaType

            _SalesClassCode = ImportAccountPayable.SalesClassCode
            _ClientCode = ImportAccountPayable.MediaClientCode
            _DivisionCode = ImportAccountPayable.MediaDivisionCode
            _ProductCode = ImportAccountPayable.MediaProductCode
            _VendorCode = ImportAccountPayable.VendorCode
            _StartDate = ImportAccountPayable.LineDate
            _EndDate = ImportAccountPayable.LineDate

            _ImportAccountPayableMediaNetAmount = ImportAccountPayable.MediaNetAmount

            If _MediaType = "R" OrElse _MediaType = "T" Then

                If ImportAccountPayable.MediaQuantity.GetValueOrDefault(0) = 0 Then

                    _TotalSpots = 1

                Else

                    _TotalSpots = ImportAccountPayable.MediaQuantity

                End If

            ElseIf _MediaType = "I" Then

                _TotalSpots = ImportAccountPayable.MediaQuantity

                If ImportAccountPayable.MediaQuantity Is Nothing Then

                    _CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                Else

                    _CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString 'default to NA

                End If

            ElseIf _MediaType = "N" Then

                _TotalSpots = ImportAccountPayable.MediaQuantity

                If ImportAccountPayable.MediaQuantity Is Nothing Then

                    _CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                Else

                    _CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString 'default to NA

                End If

            ElseIf _MediaType = "M" Then

                _TotalSpots = ImportAccountPayable.MediaQuantity

            ElseIf _MediaType = "O" Then

                _TotalSpots = ImportAccountPayable.MediaQuantity

            End If

            If ImportAccountPayable.MediaMarkupPercent Is Nothing Then

                Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(ObjectContext, _ClientCode, _DivisionCode, _ProductCode)

                If Product IsNot Nothing Then

                    _CommPct = Product.ProductionMarkup.GetValueOrDefault(0)

                End If

            Else

                _CommPct = ImportAccountPayable.MediaMarkupPercent

            End If

            _NetGross = 0

            _ImportAccountPayableMediaID = ImportAccountPayable.ImportAccountPayableMediaID

            CalculateGross(ImportAccountPayable)

        End Sub
        Private Sub CalculateGross(ByVal ImportAccountPayable As AdvantageFramework.Database.Classes.ImportAccountPayable)

            Dim CommissionAmount As Decimal = 0
            Dim GrossAmount As Decimal = 0

            If ImportAccountPayable.MediaQuantity.GetValueOrDefault(0) = 0 Then

                _NetRate = ImportAccountPayable.MediaNetAmount

            Else

                _NetRate = ImportAccountPayable.MediaNetAmount.GetValueOrDefault(0) / ImportAccountPayable.MediaQuantity

            End If

            CommissionAmount = FormatNumber(ImportAccountPayable.MediaNetAmount.GetValueOrDefault(0) * _CommPct.GetValueOrDefault(0) / 100, 2)

            GrossAmount = FormatNumber(ImportAccountPayable.MediaNetAmount.GetValueOrDefault(0) + CommissionAmount, 2)

            If ImportAccountPayable.MediaQuantity.GetValueOrDefault(0) = 0 Then

                _GrossRate = GrossAmount

            Else

                _GrossRate = GrossAmount / ImportAccountPayable.MediaQuantity

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = _OrderID.ToString

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Sub SetRequiredFields()

            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            For Each PropertyDescriptor In PropertyDescriptors

                Select Case PropertyDescriptor.Name

                    Case AdvantageFramework.Database.Classes.ImportAccountPayableOrder.Properties.CostType.ToString

                        If Me.MediaType = "I" OrElse Me.MediaType = "N" Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                    Case AdvantageFramework.Database.Classes.ImportAccountPayableOrder.Properties.NetRate.ToString

                        If Me.MediaType = "I" AndAlso Me.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString Then

                            SetRequired(PropertyDescriptor, False)

                        Else

                            SetRequired(PropertyDescriptor, True)

                        End If

                    Case AdvantageFramework.Database.Classes.ImportAccountPayableOrder.Properties.GrossRate.ToString

                        If Me.MediaType = "I" AndAlso Me.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString Then

                            SetRequired(PropertyDescriptor, False)

                        Else

                            SetRequired(PropertyDescriptor, True)

                        End If

                    Case AdvantageFramework.Database.Classes.ImportAccountPayableOrder.Properties.TotalSpots.ToString

                        If Me.MediaType = "I" AndAlso Me.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString Then

                            SetRequired(PropertyDescriptor, False)

                        Else

                            SetRequired(PropertyDescriptor, True)

                        End If

                    Case AdvantageFramework.Database.Classes.ImportAccountPayableOrder.Properties.Cost.ToString

                        If Me.MediaType = "I" OrElse Me.MediaType = "N" Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                    Case AdvantageFramework.Database.Classes.ImportAccountPayableOrder.Properties.EndDate.ToString

                        If Me.MediaType = "N" OrElse Me.MediaType = "M" Then

                            SetRequired(PropertyDescriptor, False)

                        Else

                            SetRequired(PropertyDescriptor, True)

                        End If

                End Select

            Next

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Classes.ImportAccountPayableOrder.Properties.OrderID.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Order ID is required and cannot be zero."

                    End If

                Case AdvantageFramework.Database.Classes.ImportAccountPayableOrder.Properties.LineNumber.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Line Number is required and cannot be zero."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace

