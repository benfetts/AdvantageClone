Namespace Reporting.Database.Classes

    <Serializable>
    Public Class AlertCommentsReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            AlertID
            SequenceNumber
            AlertType
            Description
            Subject
            Body
            GeneratedDate
            Priority
            ClientCode
            ClientDescription
            DivisionCode
            DivisionDescription
            ProductCode
            ProductDescription
            CampaignCode
            JobNumber
            JobDescription
            ComponentNumber
            ComponentDescription
            EstimateNumber
            EstimateComponentNumber
            EstimateQuoteNumber
            EstimateRevisionNumber
            VendorCode
            EmployeeCode
            PurchaseOrderNumber
            PurchaseOrderRevisionNumber
            OrderNumber
            RevisionNumber
            UserCode
            PDFDirectory
            AlertLevel
            CampaignIdentifier
            OfficeCode
            GetsAlerts
            BillingApprovalBatchID
            TaskSequence
            TaskDueDate
            AlertAssignmentID
            AlertAssignmentTemplate
            AlertStateID
            AlertState
            CurrentState
            TimeDue
            Version
            VersionDescription
            Build
            BuildDescription
            CommentUserCode
            CommentDate
            State
            Comment
            AssignedEmployeeCode
            AssignedEmployee
            LastModifiedDate
            LastModifiedByEmployee
            AssignmentCompleted
            WorkItem
            IsRouted
            CSReview
            HoursAllowed
            BoardState
            BacklogOrder
            CustodyStartDate
            CustodyEndDate
            DaysInCustody
            HoursInCustody
            MinutesInCustody
            IsSystemGenerated
            ClientContactCode
            ClientContactName
        End Enum

#End Region

#Region " Variables "

        Private _ID As Nullable(Of System.Guid) = Nothing
        Private _AlertID As Integer = Nothing
        Private _SequenceNumber As Nullable(Of Integer) = Nothing
        Private _AlertType As String = Nothing
        Private _Description As String = Nothing
        Private _Subject As String = Nothing
        Private _Body As String = Nothing
        Private _GeneratedDate As Nullable(Of Date) = Nothing
        Private _Priority As Nullable(Of Short) = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _CampaignCode As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _ComponentNumber As Nullable(Of Short) = Nothing
        Private _ComponentDescription As String = Nothing
        Private _EstimateNumber As Nullable(Of Integer) = Nothing
        Private _EstimateComponentNumber As Nullable(Of Short) = Nothing
        Private _EstimateQuoteNumber As Nullable(Of Short) = Nothing
        Private _EstimateRevisionNumber As Nullable(Of Short) = Nothing
        Private _VendorCode As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _PurchaseOrderNumber As Nullable(Of Integer) = Nothing
        Private _PurchaseOrderRevisionNumber As Nullable(Of Short) = Nothing
        Private _OrderNumber As Nullable(Of Integer) = Nothing
        Private _RevisionNumber As Nullable(Of Short) = Nothing
        Private _UserCode As String = Nothing
        Private _PDFDirectory As String = Nothing
        Private _AlertLevel As String = Nothing
        Private _CampaignIdentifier As Nullable(Of Integer) = Nothing
        Private _OfficeCode As String = Nothing
        Private _GetsAlerts As String = Nothing
        Private _BillingApprovalBatchID As Nullable(Of Integer) = Nothing
        Private _TaskSequence As Nullable(Of Short) = Nothing
        Private _TaskDueDate As Nullable(Of Date) = Nothing
        Private _AlertAssignmentID As Nullable(Of Integer) = Nothing
        Private _AlertAssignmentTemplate As String = Nothing
        Private _AlertStateID As Nullable(Of Integer) = Nothing
        Private _AlertState As String = Nothing
        Private _CurrentState As String = Nothing
        Private _TimeDue As String = Nothing
        Private _Version As String = Nothing
        Private _VersionDescription As String = Nothing
        Private _Build As String = Nothing
        Private _BuildDescription As String = Nothing
        Private _CommentUserCode As String = Nothing
        Private _CommentDate As Nullable(Of Date) = Nothing
        Private _State As String = Nothing
        Private _Comment As String = Nothing
        Private _AssignedEmployeeCode As String = Nothing
        Private _AssignedEmployee As String = Nothing
        Private _LastModifiedDate As Nullable(Of Date) = Nothing
        Private _LastModifiedByEmployee As String = Nothing
        Private _AssignmentCompleted As String = Nothing
        Private _WorkItem As String = Nothing
        Private _IsRouted As String = Nothing
        Private _CSReview As String = Nothing
        Private _HoursAllowed As Nullable(Of Decimal) = Nothing
        Private _BoardState As String = Nothing
        Private _BacklogOrder As Nullable(Of Integer) = Nothing
        Private _CustodyStartDate As Nullable(Of Date) = Nothing
        Private _CustodyEndDate As Nullable(Of Date) = Nothing
        Private _DaysInCustody As Nullable(Of Integer) = Nothing
        Private _HoursInCustody As Nullable(Of Decimal) = Nothing
        Private _MinutesInCustody As Nullable(Of Integer) = Nothing
        Private _IsSystemGenerated As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Nullable(Of System.Guid)
            Get
                ID = _ID
            End Get
            Set(value As Nullable(Of System.Guid))
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="ID")>
        Public Property AlertID() As Nullable(Of Integer)
            Get
                AlertID = _AlertID
            End Get
            Set(value As Nullable(Of Integer))
                _AlertID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="Alert or Assignment ID")>
        Public Property SequenceNumber() As Nullable(Of Integer)
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(value As Nullable(Of Integer))
                _SequenceNumber = value
            End Set
        End Property
        Public Property AlertType() As String
            Get
                AlertType = _AlertType
            End Get
            Set(value As String)
                _AlertType = value
            End Set
        End Property
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(value As String)
                _Description = value
            End Set
        End Property
        Public Property Subject() As String
            Get
                Subject = _Subject
            End Get
            Set(value As String)
                _Subject = value
            End Set
        End Property
        Public Property Body() As String
            Get
                Body = _Body
            End Get
            Set(value As String)
                _Body = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="G")>
        Public Property GeneratedDate() As Nullable(Of Date)
            Get
                GeneratedDate = _GeneratedDate
            End Get
            Set(value As Nullable(Of Date))
                _GeneratedDate = value
            End Set
        End Property
        Public Property Priority() As Nullable(Of Short)
            Get
                Priority = _Priority
            End Get
            Set(value As Nullable(Of Short))
                _Priority = value
            End Set
        End Property
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        Public Property ClientDescription() As String
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        Public Property DivisionDescription() As String
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        Public Property ProductDescription() As String
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(value As String)
                _CampaignCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        Public Property ComponentNumber() As Nullable(Of Short)
            Get
                ComponentNumber = _ComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _ComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property ComponentDescription() As String
            Get
                ComponentDescription = _ComponentDescription
            End Get
            Set(value As String)
                _ComponentDescription = value
            End Set
        End Property
        Public Property EstimateNumber() As Nullable(Of Integer)
            Get
                EstimateNumber = _EstimateNumber
            End Get
            Set(value As Nullable(Of Integer))
                _EstimateNumber = value
            End Set
        End Property
        Public Property EstimateComponentNumber() As Nullable(Of Short)
            Get
                EstimateComponentNumber = _EstimateComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _EstimateComponentNumber = value
            End Set
        End Property
        Public Property EstimateQuoteNumber() As Nullable(Of Short)
            Get
                EstimateQuoteNumber = _EstimateQuoteNumber
            End Get
            Set(value As Nullable(Of Short))
                _EstimateQuoteNumber = value
            End Set
        End Property
        Public Property EstimateRevisionNumber() As Nullable(Of Short)
            Get
                EstimateRevisionNumber = _EstimateRevisionNumber
            End Get
            Set(value As Nullable(Of Short))
                _EstimateRevisionNumber = value
            End Set
        End Property
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = value
            End Set
        End Property
        Public Property PurchaseOrderNumber() As Nullable(Of Integer)
            Get
                PurchaseOrderNumber = _PurchaseOrderNumber
            End Get
            Set(value As Nullable(Of Integer))
                _PurchaseOrderNumber = value
            End Set
        End Property
        Public Property PurchaseOrderRevisionNumber() As Nullable(Of Short)
            Get
                PurchaseOrderRevisionNumber = _PurchaseOrderRevisionNumber
            End Get
            Set(value As Nullable(Of Short))
                _PurchaseOrderRevisionNumber = value
            End Set
        End Property
        Public Property OrderNumber() As Nullable(Of Integer)
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As Nullable(Of Integer))
                _OrderNumber = value
            End Set
        End Property
        Public Property RevisionNumber() As Nullable(Of Short)
            Get
                RevisionNumber = _RevisionNumber
            End Get
            Set(value As Nullable(Of Short))
                _RevisionNumber = value
            End Set
        End Property
        Public Property UserCode() As String
            Get
                UserCode = _UserCode
            End Get
            Set(value As String)
                _UserCode = value
            End Set
        End Property
        Public Property PDFDirectory() As String
            Get
                PDFDirectory = _PDFDirectory
            End Get
            Set(value As String)
                _PDFDirectory = value
            End Set
        End Property
        Public Property AlertLevel() As String
            Get
                AlertLevel = _AlertLevel
            End Get
            Set(value As String)
                _AlertLevel = value
            End Set
        End Property
        Public Property CampaignIdentifier() As Nullable(Of Integer)
            Get
                CampaignIdentifier = _CampaignIdentifier
            End Get
            Set(value As Nullable(Of Integer))
                _CampaignIdentifier = value
            End Set
        End Property
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        Public Property GetsAlerts() As String
            Get
                GetsAlerts = _GetsAlerts
            End Get
            Set(value As String)
                _GetsAlerts = value
            End Set
        End Property
        Public Property BillingApprovalBatchID() As Nullable(Of Integer)
            Get
                BillingApprovalBatchID = _BillingApprovalBatchID
            End Get
            Set(value As Nullable(Of Integer))
                _BillingApprovalBatchID = value
            End Set
        End Property
        Public Property TaskSequence() As Nullable(Of Short)
            Get
                TaskSequence = _TaskSequence
            End Get
            Set(value As Nullable(Of Short))
                _TaskSequence = value
            End Set
        End Property
        Public Property TaskDueDate() As Nullable(Of Date)
            Get
                TaskDueDate = _TaskDueDate
            End Get
            Set(value As Nullable(Of Date))
                _TaskDueDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Alert Assignment Template ID")>
        Public Property AlertAssignmentID() As Nullable(Of Integer)
            Get
                AlertAssignmentID = _AlertAssignmentID
            End Get
            Set(value As Nullable(Of Integer))
                _AlertAssignmentID = value
            End Set
        End Property
        Public Property AlertAssignmentTemplate() As String
            Get
                AlertAssignmentTemplate = _AlertAssignmentTemplate
            End Get
            Set(value As String)
                _AlertAssignmentTemplate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public Property AlertStateID() As Nullable(Of Integer)
            Get
                AlertStateID = _AlertStateID
            End Get
            Set(value As Nullable(Of Integer))
                _AlertStateID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public Property AlertState() As String
            Get
                AlertState = _AlertState
            End Get
            Set(value As String)
                _AlertState = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property CurrentState() As String
            Get
                CurrentState = _CurrentState
            End Get
            Set(value As String)
                _CurrentState = value
            End Set
        End Property
        Public Property TimeDue() As String
            Get
                TimeDue = _TimeDue
            End Get
            Set(value As String)
                _TimeDue = value
            End Set
        End Property
        Public Property Version() As String
            Get
                Version = _Version
            End Get
            Set(value As String)
                _Version = value
            End Set
        End Property
        Public Property VersionDescription() As String
            Get
                VersionDescription = _VersionDescription
            End Get
            Set(value As String)
                _VersionDescription = value
            End Set
        End Property
        Public Property Build() As String
            Get
                Build = _Build
            End Get
            Set(value As String)
                _Build = value
            End Set
        End Property
        Public Property BuildDescription() As String
            Get
                BuildDescription = _BuildDescription
            End Get
            Set(value As String)
                _BuildDescription = value
            End Set
        End Property
        Public Property CommentUserCode() As String
            Get
                CommentUserCode = _CommentUserCode
            End Get
            Set(value As String)
                _CommentUserCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="G")>
        Public Property CommentDate() As Nullable(Of Date)
            Get
                CommentDate = _CommentDate
            End Get
            Set(value As Nullable(Of Date))
                _CommentDate = value
            End Set
        End Property
        Public Property State() As String
            Get
                State = _State
            End Get
            Set(value As String)
                _State = value
            End Set
        End Property
        Public Property Comment() As String
            Get
                If _Comment IsNot Nothing Then
                    Comment = _Comment.Replace("&nbsp;", "")
                Else
                    Comment = _Comment
                End If
            End Get
            Set(value As String)
                _Comment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Employee Code")>
        Public Property AssignedEmployeeCode() As String
            Get
                AssignedEmployeeCode = _AssignedEmployeeCode
            End Get
            Set(value As String)
                _AssignedEmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Employee")>
        Public Property AssignedEmployee() As String
            Get
                AssignedEmployee = _AssignedEmployee
            End Get
            Set(value As String)
                _AssignedEmployee = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="G")>
        Public Property LastModifiedDate() As Nullable(Of Date)
            Get
                LastModifiedDate = _LastModifiedDate
            End Get
            Set(value As Nullable(Of Date))
                _LastModifiedDate = value
            End Set
        End Property
        Public Property LastModifiedByEmployee() As String
            Get
                LastModifiedByEmployee = _LastModifiedByEmployee
            End Get
            Set(value As String)
                _LastModifiedByEmployee = value
            End Set
        End Property
        Public Property AssignmentCompleted() As String
            Get
                AssignmentCompleted = _AssignmentCompleted
            End Get
            Set(value As String)
                _AssignmentCompleted = value
            End Set
        End Property
        Public Property WorkItem() As String
            Get
                WorkItem = _WorkItem
            End Get
            Set(value As String)
                _WorkItem = value
            End Set
        End Property
        Public Property IsRouted() As String
            Get
                IsRouted = _IsRouted
            End Get
            Set(value As String)
                _IsRouted = value
            End Set
        End Property
        Public Property CSReview() As String
            Get
                CSReview = _CSReview
            End Get
            Set(value As String)
                _CSReview = value
            End Set
        End Property
        Public Property HoursAllowed() As Nullable(Of Decimal)
            Get
                HoursAllowed = _HoursAllowed
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAllowed = value
            End Set
        End Property
        Public Property BoardState() As String
            Get
                BoardState = _BoardState
            End Get
            Set(value As String)
                _BoardState = value
            End Set
        End Property
        Public Property BacklogOrder() As Nullable(Of Integer)
            Get
                BacklogOrder = _BacklogOrder
            End Get
            Set(value As Nullable(Of Integer))
                _BacklogOrder = value
            End Set
        End Property
        Public Property CustodyStartDate() As Nullable(Of Date)
            Get
                CustodyStartDate = _CustodyStartDate
            End Get
            Set(value As Nullable(Of Date))
                _CustodyStartDate = value
            End Set
        End Property
        Public Property CustodyEndDate() As Nullable(Of Date)
            Get
                CustodyEndDate = _CustodyEndDate
            End Get
            Set(value As Nullable(Of Date))
                _CustodyEndDate = value
            End Set
        End Property
        Public Property DaysInCustody() As Nullable(Of Integer)
            Get
                DaysInCustody = _DaysInCustody
            End Get
            Set(value As Nullable(Of Integer))
                _DaysInCustody = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property HoursInCustody() As Nullable(Of Decimal)
            Get
                HoursInCustody = _HoursInCustody
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursInCustody = value
            End Set
        End Property
        Public Property MinutesInCustody() As Nullable(Of Integer)
            Get
                MinutesInCustody = _MinutesInCustody
            End Get
            Set(value As Nullable(Of Integer))
                _MinutesInCustody = value
            End Set
        End Property
        Public Property IsSystemGenerated() As String
            Get
                IsSystemGenerated = _IsSystemGenerated
            End Get
            Set(value As String)
                _IsSystemGenerated = value
            End Set
        End Property
        Public Property ClientContactCode() As String
        Public Property ClientContactName() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
