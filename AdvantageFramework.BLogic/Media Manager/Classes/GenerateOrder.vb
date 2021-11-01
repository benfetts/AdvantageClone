Namespace MediaManager.Classes

    <Serializable()>
    Public Class GenerateOrder

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            DefaultCorrespondenceMethod
            Vendor
            JobNumber
            JobComponentNumber
            OrderNumber
            Quote
            WorksheetLineNumber
            LineNumber
            RevisionNumber
            Cancelled
            JobMediaBillDate
            StartDate
            EndDate
            OrderLineStatus
            VCCLimit
            VCCCardAmount
            PaymentMethod
            Status
            OrderMessage
            SalesClassCode
            VendorCode
            TotalCostPayableToVendor
            MediaFrom
            AmountPaidRedeemed
            'RecipientCount
        End Enum

#End Region

#Region " Variables "

        Private _DefaultCorrespondenceMethod As Nullable(Of Short) = Nothing
        Private _VCCLimit As Nullable(Of Decimal) = Nothing
        Private _PaymentMethod As String = Nothing
        Private _Status As Nullable(Of Boolean) = Nothing
        Private _OrderMessage As String = Nothing
        Private _CreatedDate As Nullable(Of Date) = Nothing
        Private _LastGeneratedDate As Nullable(Of Date) = Nothing

        Private _MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail = Nothing
        Private _VCCCard As AdvantageFramework.Database.Entities.VCCCard = Nothing
        Private _Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
        Private _GenerateOrderVendorReps As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Status() As Nullable(Of Boolean)
            Get
                Status = _Status
            End Get
            Set(value As Nullable(Of Boolean))
                _Status = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Print/Email")>
        Public Property DefaultCorrespondenceMethod() As Nullable(Of Short)
            Get
                DefaultCorrespondenceMethod = _DefaultCorrespondenceMethod
            End Get
            Set(value As Nullable(Of Short))
                _DefaultCorrespondenceMethod = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Vendor" & vbCrLf & "Name")>
        Public ReadOnly Property Vendor() As String
            Get
                Vendor = _MediaManagerReviewDetail.VendorName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job" & vbCrLf & "Number")>
        Public ReadOnly Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _MediaManagerReviewDetail.JobNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Component" & vbCrLf & "Number")>
        Public ReadOnly Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _MediaManagerReviewDetail.JobComponentNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Order" & vbCrLf & "Number")>
        Public ReadOnly Property OrderNumber() As Integer
            Get
                OrderNumber = _MediaManagerReviewDetail.OrderNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Quote() As Boolean
            Get
                Quote = _MediaManagerReviewDetail.Quote
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Worksheet" & vbCrLf & "Line #")>
        Public ReadOnly Property WorksheetLineNumber() As Nullable(Of Integer)
            Get
                WorksheetLineNumber = _MediaManagerReviewDetail.WorksheetLineNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Line" & vbCrLf & "Number")>
        Public ReadOnly Property LineNumber() As Integer
            Get
                LineNumber = _MediaManagerReviewDetail.LineNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Revision")>
        Public ReadOnly Property RevisionNumber() As Nullable(Of Integer)
            Get
                RevisionNumber = _MediaManagerReviewDetail.RevisionNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Cancelled() As Boolean
            Get
                Cancelled = _MediaManagerReviewDetail.Cancelled
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job Media" & vbCrLf & "Date to Bill")>
        Public ReadOnly Property JobMediaBillDate() As Nullable(Of Date)
            Get
                JobMediaBillDate = _MediaManagerReviewDetail.JobMediaBillDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property StartDate() As Nullable(Of Date)
            Get
                StartDate = _MediaManagerReviewDetail.StartDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property EndDate() As Nullable(Of Date)
            Get
                EndDate = _MediaManagerReviewDetail.EndDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Payment" & vbCrLf & "Method")>
        Public ReadOnly Property PaymentMethod() As String
            Get
                PaymentMethod = _PaymentMethod
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Total Cost" & vbCrLf & "Payable to Vendor", DisplayFormat:="n2")>
        Public ReadOnly Property TotalCostPayableToVendor() As Nullable(Of Decimal)
            Get
                TotalCostPayableToVendor = _MediaManagerReviewDetail.TotalCostPayableToVendor.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Vendor" & vbCrLf & "Collected")>
        Public ReadOnly Property AmountPaidRedeemed() As Nullable(Of Decimal)
            Get
                AmountPaidRedeemed = _MediaManagerReviewDetail.VendorCollected.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="VCC Limit", DisplayFormat:="n2")>
        Public ReadOnly Property VCCLimit() As Nullable(Of Decimal)
            Get
                VCCLimit = _VCCLimit
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="VCC" & vbCrLf & "Amount", DisplayFormat:="n2")>
        Public ReadOnly Property VCCCardAmount() As Nullable(Of Decimal)
            Get

                If _VCCCard IsNot Nothing Then

                    VCCCardAmount = _VCCCard.CardAmount

                Else

                    VCCCardAmount = Nothing

                End If

            End Get
        End Property
        '<System.Runtime.Serialization.DataMemberAttribute(),
        'AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Order Line" & vbCrLf & "Status")>
        'Public ReadOnly Property OrderLineStatus() As String
        '    Get
        '        OrderLineStatus = _MediaManagerReviewDetail.OrderLineStatus
        '    End Get
        'End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Order" & vbCrLf & "Message")>
        Public Property OrderMessage() As String
            Get
                OrderMessage = _OrderMessage
            End Get
            Set(value As String)
                _OrderMessage = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Created Date", DisplayFormat:="g")>
        Public ReadOnly Property CreatedDate() As Nullable(Of Date)
            Get
                CreatedDate = _CreatedDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Last Generated" & vbCrLf & "Date", DisplayFormat:="g")>
        Public ReadOnly Property LastGeneratedDate() As Nullable(Of Date)
            Get
                LastGeneratedDate = _LastGeneratedDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property SalesClassCode() As String
            Get
                SalesClassCode = _MediaManagerReviewDetail.SalesClassCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property VendorCode() As String
            Get
                VendorCode = _MediaManagerReviewDetail.VendorCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property MediaFrom() As String
            Get
                MediaFrom = _MediaManagerReviewDetail.MediaFrom
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ClientName() As String
            Get
                ClientName = _MediaManagerReviewDetail.ClientName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AlertRecipients() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AlertRecipientEmployeeCodes() As Generic.List(Of String)

#End Region

#Region " Methods "

        Public Sub New()

            _GenerateOrderVendorReps = New Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep)

        End Sub
        Public Sub New(DbContext As AdvantageFramework.Database.DbContext, MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail, Vendor As AdvantageFramework.Database.Entities.Vendor, VCCCard As AdvantageFramework.Database.Entities.VCCCard)

            Me.New()

            Dim OrderStatus As Object = Nothing

            _MediaManagerReviewDetail = MediaManagerReviewDetail
            _VCCCard = VCCCard
            _Vendor = Vendor

            If Vendor IsNot Nothing Then

                _DefaultCorrespondenceMethod = Vendor.DefaultCorrespondenceMethod.GetValueOrDefault(1)

                If Vendor.VCCStatus.HasValue AndAlso Vendor.VCCStatus = AdvantageFramework.Database.Entities.VCCStatuses.Accepted AndAlso Vendor.SendVCCWithMediaOrder Then

                    _PaymentMethod = "Virtual CC"
                    _VCCLimit = Vendor.VCCAmount

                Else

                    _PaymentMethod = "Check"
                    _VCCLimit = Nothing

                End If

            End If

            If DbContext IsNot Nothing AndAlso _MediaManagerReviewDetail IsNot Nothing Then

                _CreatedDate = AdvantageFramework.Database.Procedures.MediaManagerGeneratedReport.GetCreateDateByOrderNumber(DbContext, MediaManagerReviewDetail.OrderNumber)

                Select Case Mid(MediaManagerReviewDetail.MediaFrom, 1, 1)

                    Case "I"

                        OrderStatus = (From Entity In AdvantageFramework.Database.Procedures.InternetOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)
                                       Where Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.OrderGenerated
                                       Select Entity).OrderByDescending(Function(Entity) Entity.RevisedDate).FirstOrDefault

                    Case "M"

                        OrderStatus = (From Entity In AdvantageFramework.Database.Procedures.MagazineOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)
                                       Where Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.OrderGenerated
                                       Select Entity).OrderByDescending(Function(Entity) Entity.RevisedDate).FirstOrDefault

                    Case "N"

                        OrderStatus = (From Entity In AdvantageFramework.Database.Procedures.NewspaperOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)
                                       Where Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.OrderGenerated
                                       Select Entity).OrderByDescending(Function(Entity) Entity.RevisedDate).FirstOrDefault

                    Case "O"

                        OrderStatus = (From Entity In AdvantageFramework.Database.Procedures.OutOfHomeOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)
                                       Where Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.OrderGenerated
                                       Select Entity).OrderByDescending(Function(Entity) Entity.RevisedDate).FirstOrDefault

                    Case "R"

                        OrderStatus = (From Entity In AdvantageFramework.Database.Procedures.RadioOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)
                                       Where Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.OrderGenerated
                                       Select Entity).OrderByDescending(Function(Entity) Entity.RevisedDate).FirstOrDefault

                    Case "T"

                        OrderStatus = (From Entity In AdvantageFramework.Database.Procedures.TVOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)
                                       Where Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.OrderGenerated
                                       Select Entity).OrderByDescending(Function(Entity) Entity.RevisedDate).FirstOrDefault

                End Select

                If OrderStatus IsNot Nothing Then

                    _LastGeneratedDate = OrderStatus.RevisedDate

                End If

            End If

        End Sub
        Public Sub SetReportDates(CreatedDate As Date, LastGeneratedDate As Date)

            _CreatedDate = CreatedDate
            _LastGeneratedDate = LastGeneratedDate

        End Sub
        Public Sub SetVCCCard(VCCCard As AdvantageFramework.Database.Entities.VCCCard)

            If VCCCard IsNot Nothing Then

                _VCCCard = VCCCard

            End If

        End Sub
        Public Sub AddOrUpdateGenerateOrderVendorReps(VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative, Process As Boolean, SendToOrderReps As Boolean)

            'objects
            Dim GenerateOrderVendorRep As AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep = Nothing

            If VendorRepresentative IsNot Nothing AndAlso _GenerateOrderVendorReps IsNot Nothing Then

                If _GenerateOrderVendorReps.Any(Function(Entity) Entity.VendorCode = VendorRepresentative.VendorCode AndAlso Entity.VendorRepCode = VendorRepresentative.Code) Then

                    For Each GenerateOrderVendorRep In _GenerateOrderVendorReps.Where(Function(Entity) Entity.VendorCode = VendorRepresentative.VendorCode AndAlso Entity.VendorRepCode = VendorRepresentative.Code).ToList

                        GenerateOrderVendorRep.Process = Process

                    Next

                Else

                    GenerateOrderVendorRep = New AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep(Me, _Vendor, VendorRepresentative, Process, SendToOrderReps)

                    _GenerateOrderVendorReps.Add(GenerateOrderVendorRep)

                End If

            End If

        End Sub
        Public Function GetGenerateOrderVendorReps() As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep)

            GetGenerateOrderVendorReps = _GenerateOrderVendorReps

        End Function
        Public Function GetMediaManagerReviewDetail() As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail

            GetMediaManagerReviewDetail = _MediaManagerReviewDetail

        End Function

#End Region

    End Class

End Namespace