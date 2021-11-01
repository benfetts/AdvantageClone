Imports System.Collections
Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web
Imports System.Web.HttpContext
Imports System.Web.HttpUtility
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Xml

'  "x" is for encrypted API querystrings

Namespace Web

    <Serializable()> Public Class QueryString
        Inherits NameValueCollection

#Region " Constants "

        Private Const _APIExperationMinutes As Integer = 30

#End Region

#Region " Enum "
        Public Enum Source_App

            Alert = 0
            JobJacket = 1
            JobJacketAlerts = 2
            ProjectSchedule = 3
            ProjectScheduleTask = 4
            Campaign = 5
            Estimate = 6 'multiple components (ALERT TYPE: ES)
            Desktop = 7
            PurchaseOrder = 8
            RequestForQuote = 9
            JobVersion = 10
            CreativeBrief = 11
            ProjectSchedule_Alerts = 12
            Campaign_Print = 13
            VendorQuote = 14
            EstimateComponent = 15 'One component (ALERT TYPE: EST)
            JobSpecs = 16
            CalendarActivity = 17

        End Enum
        Public Enum ContentAreaName

            None = 0
            Alerts = 1
            CreativeBrief = 2
            Documents = 3
            Estimates = 4
            Events = 5
            Gantt = 6
            JobSpecifications = 7
            JobStatus = 8
            JobStatus_Team = 9
            JobTemplate = 10
            JobVersion = 11
            PurchaseOrder = 12
            FinancialStatus = 13
            Risk = 14
            Schedule = 15
            Workload = 16
            Billing = 17
            Reports = 18
            Calendar = 19
            JobForecasts = 20
            MediaOrderList = 21
            AccountSetupForm = 22
            Chat = 23
            DigitalAssetReviews = 24
            ProjectBoard = 25
            Proofs = 26

        End Enum
        Public Enum MediaOrderType

            None
            Internet
            Magazine
            Newspaper
            Outdoor
            Radio
            TV

        End Enum

#End Region

#Region " Variables "

        Private _ServerName As String = String.Empty
        Private _DatabaseName As String = String.Empty
        Private _UserName As String = String.Empty
        Private _Password As String = String.Empty
        Private _ApiDate As DateTime? = Nothing

        'Public ApiIsValid As Boolean = False 'To verify within data
        'Public ConnectionInfoIsValid As Boolean = False

        Private _HasConnectionString As Boolean = False
        Private _AdminConnectionString As String = String.Empty
        Private _AdminUserCode As String = String.Empty
        Private _AdminPassword As String = String.Empty

        Public ErrorMessage As String = String.Empty

#End Region

#Region " Properties "

#Region " Private "

        Private _ConnectionString As String = String.Empty

        Private _AamGroupBy As String = String.Empty
        Private _AamInboxType As String = String.Empty
        Private _AamIncludeBacklog As Boolean = False
        Private _AamIncludeBoardLevel As Boolean = False
        Private _AamIncludeCompletedAssignments As Boolean = False
        Private _AamIncludeReviews As Boolean = False
        Private _AamIsCount As Boolean = False
        Private _AamIsJobAlertsPage As Boolean = False
        Private _AamRecordsToReturn As Integer = 0
        Private _AamShowAssignmentType As String = String.Empty
        Private _AamGridSize As Integer = 0
        Private _AamShowOnlyTempCompletedTasks As Boolean = False
        Private _AccountExecutiveCode As String = String.Empty
        Private _AlertId As Integer = 0
        Private _AlertNotifyHdrId As Integer = 0
        Private _AlertStateId As Integer = 0
        Private _APInvoice As String = String.Empty
        Private _APID As Integer = 0
        Private _App As Source_App = Nothing
        Private _BillingApprovalBatchId As Integer = 0
        Private _BillingApprovalId As Integer = 0
        Private _BoardID As Integer = 0
        Private _BoardColumnID As Integer = 0
        Private _BoardHeaderID As Integer = 0
        Private _BoardDetailID As Integer = 0
        Private _BoardStateID As Integer = 0
        Private _CampaignCode As String = String.Empty
        Private _ChatRoomId As Integer = 0
        Private _ClCode As String = String.Empty
        Private _CmpIdentifier As Integer = 0
        Private _ConceptShareAssetID As Integer = 0
        Private _ConceptShareBaseReviewType As AdvantageFramework.Database.Entities.ConceptShareBaseReviewType = Nothing
        Private _ConceptShareCommentID As Integer = 0
        Private _ConceptShareProjectID As Integer = 0
        Private _ConceptShareReviewID As Integer = 0
        Private _ContentArea As ContentAreaName = ContentAreaName.None
        Private _ContractId As Integer = 0
        Private _ContractReportId As Integer = 0
        Private _CutOffDate As String = String.Empty
        Private _DeepLink As String = String.Empty
        Private _DepartmentTeamCode As String = String.Empty
        Private _DivCode As String = String.Empty
        Private _DocumentId As Integer = 0
        Private _DocumentLabelId As Integer = 0
        Private _DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel = Nothing
        Private _DueDate As String = String.Empty
        Private _EmailGroup As String = String.Empty
        Private _EmpCode As String = String.Empty
        Private _EmployeeName As String = String.Empty
        Private _EmployeeTimeId As Integer = 0
        Private _EmployeeTimeDetailId As Integer = 0
        Private _EmployeeTimeForecastOfficeDetailId As Integer = 0
        Private _EndDate As String = String.Empty
        Private _EstComponentNbr As Integer = 0
        Private _EstimateNumber As Integer = 0
        Private _EstQuoteNbr As Integer = 0
        Private _EstRevNbr As Integer = 0
        Private _EventId As Integer = 0
        Private _EventTaskId As Integer = 0
        Private _ExcludeProjectedTasks As Boolean = False
        Private _ExpenseId As Integer = 0
        Private _FunctionCode As String = String.Empty
        Private _IncludeCompletedSchedules As Boolean = False
        Private _IncludeCompletedTasks As Boolean = False
        Private _IncludeOnlyPendingTasks As Boolean = False
        Private _InvoiceNumber As Integer = 0
        Private _InvoiceSeqNbr As Integer = -1
        Private _IsBookmark As Boolean = False
        Private _IsJobDashboard As Boolean = False
        Private _IsSession As Boolean = False
        Private _JobComponentNbr As Integer = 0
        Private _JobNumber As Integer = 0
        Private _JobVersionHdrId As Integer = 0
        Private _JobVersionSeqNbr As Integer = 0
        Private _LocationID As String = String.Empty
        Private _ManagerCode As String = String.Empty
        Private _MediaATBRevisionID As Integer = 0
        Private _MediaATBNumber As Integer = 0
        Private _MediaATBRevisionNumber As Integer = 0
        Private _MediaOrderNumber As Integer = 0
        Private _MediaOrderLineNumber As Integer = 0
        Private _MediaOrderRevisionNumber As Integer = 0
        Private _MediaOrderSequenceNumber As Integer = 0
        Private _MediaType As MediaOrderType = MediaOrderType.None
        Private _MilestonesOnly As Boolean = False
        Private _Month As Integer = 0
        Private _OfficeCode As String = String.Empty
        Private _Page As String = String.Empty
        Private _PhaseFilter As String = String.Empty
        Private _PoNumber As Integer = 0
        Private _PostPeriod As String = String.Empty
        Private _PrdCode As String = String.Empty
        Private _ProofingStatusExternalReviewerID As Integer = 0
        Private _Quantity As Decimal = 0.0
        Private _RevisionId As Integer = 0
        Private _RoleCode As String = String.Empty
        Private _RoomId As String = String.Empty
        Private _RoomName As String = String.Empty
        Private _Rush As Boolean = False
        Private _ScCode As String = String.Empty
        Private _SearchText As String = String.Empty
        Private _Skip As Integer = 0
        Private _SpecId As Integer = 0
        Private _SprintHeaderID As Integer = 0
        Private _SprintDetailID As Integer = 0
        Private _StartDate As String = String.Empty
        Private _Take As Integer = 0
        Private _TaskCode As String = String.Empty
        Private _TaskSeqNbr As Integer = -1
        Private _TimeType As String = String.Empty
        Private _TrafficStatusCode As String = String.Empty
        Private _TrafficScheduleVersionId As Integer = -1
        Private _UserCode As String = String.Empty
        Private _VendorCode As String = String.Empty
        Private _VersionId As Integer = 0
        Private _WorkspaceId As Integer = 0
        Private _Year As Integer = 0

#End Region
#Region " Public "

        '''' <summary>
        '''' QueryString key: con
        '''' </summary>
        '''' <returns>String</returns>
        'Public Property ConnectionString As String
        '    Get
        '        Return _ConnString
        '    End Get
        '    Set(ByVal Value As String)
        '        _ConnString = Value
        '    End Set
        'End Property

        Public ReadOnly Property ConnectionString As String
            Get
                Return _ConnectionString
            End Get
        End Property

        ''' <summary>
        ''' QueryString key: N/A
        ''' </summary>
        ''' <returns>String</returns>
        Public Property Page As String
            Get
                Return _Page
            End Get
            Set(ByVal value As String)
                _Page = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: f
        ''' </summary>
        ''' <returns>String</returns>
        Public Property App As Source_App
            Get
                Return _App
            End Get
            Set(ByVal Value As Source_App)
                _App = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: SSSN
        ''' </summary>
        ''' <returns>String</returns>
        Public Property IsSession As Boolean
            Get
                Return _IsSession
            End Get
            Set(ByVal Value As Boolean)
                _IsSession = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: aamgb
        ''' </summary>
        ''' <returns>String</returns>
        Public Property AamGroupBy As String
            Get
                Return _AamGroupBy
            End Get
            Set(ByVal Value As String)
                _AamGroupBy = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: aamit
        ''' </summary>
        ''' <returns>String</returns>
        Public Property AamInboxType As String
            Get
                Return _AamInboxType
            End Get
            Set(ByVal Value As String)
                _AamInboxType = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: aamib
        ''' </summary>
        ''' <returns>String</returns>
        Public Property AamIncludeBacklog As Boolean
            Get
                Return _AamIncludeBacklog
            End Get
            Set(ByVal Value As Boolean)
                _AamIncludeBacklog = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: aamibl
        ''' </summary>
        ''' <returns>String</returns>
        Public Property AamIncludeBoardLevel As Boolean
            Get
                Return _AamIncludeBoardLevel
            End Get
            Set(ByVal Value As Boolean)
                _AamIncludeBoardLevel = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: aamica
        ''' </summary>
        ''' <returns>String</returns>
        Public Property AamIncludeCompletedAssignments As Boolean
            Get
                Return _AamIncludeCompletedAssignments
            End Get
            Set(ByVal Value As Boolean)
                _AamIncludeCompletedAssignments = Value
            End Set
        End Property
        '_AamShowOnlyTempCompletedTasks
        ''' <summary>
        ''' QueryString key: aamstct
        ''' </summary>
        ''' <returns>String</returns>
        Public Property AamShowOnlyTempCompletedTasks As Boolean
            Get
                Return _AamShowOnlyTempCompletedTasks
            End Get
            Set(ByVal Value As Boolean)
                _AamShowOnlyTempCompletedTasks = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: aamir
        ''' </summary>
        ''' <returns>String</returns>
        Public Property AamIncludeReviews As Boolean
            Get
                Return _AamIncludeReviews
            End Get
            Set(ByVal Value As Boolean)
                _AamIncludeReviews = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: aamic
        ''' </summary>
        ''' <returns>String</returns>
        Public Property AamIsCount As Boolean
            Get
                Return _AamIsCount
            End Get
            Set(ByVal Value As Boolean)
                _AamIsCount = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: aamijap
        ''' </summary>
        ''' <returns>String</returns>
        Public Property AamIsJobAlertsPage As Boolean
            Get
                Return _AamIsJobAlertsPage
            End Get
            Set(ByVal Value As Boolean)
                _AamIsJobAlertsPage = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: aamrtr
        ''' </summary>
        ''' <returns>String</returns>
        Public Property AamRecordsToReturn As Integer
            Get
                Return _AamRecordsToReturn
            End Get
            Set(ByVal Value As Integer)
                _AamRecordsToReturn = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: aamsat
        ''' </summary>
        ''' <returns>String</returns>
        Public Property AamShowAssignmentType As String
            Get
                Return _AamShowAssignmentType
            End Get
            Set(ByVal Value As String)
                _AamShowAssignmentType = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: aamgs
        ''' </summary>
        ''' <returns>String</returns>
        Public Property AamGridSize As Integer
            Get
                Return _AamGridSize
            End Get
            Set(ByVal Value As Integer)
                _AamGridSize = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: a
        ''' </summary>
        ''' <returns>String</returns>
        Public Property AlertID As Integer
            Get
                Return _AlertId
            End Get
            Set(ByVal Value As Integer)
                _AlertId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: ani
        ''' </summary>
        ''' <returns>String</returns>
        Public Property AlertTemplateID As Integer
            Get
                Return _AlertNotifyHdrId
            End Get
            Set(ByVal Value As Integer)
                _AlertNotifyHdrId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: asi
        ''' </summary>
        ''' <returns>String</returns>
        Public Property AlertStateID As Integer
            Get
                Return _AlertStateId
            End Get
            Set(ByVal Value As Integer)
                _AlertStateId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: ae
        ''' </summary>
        ''' <returns>String</returns>
        Public Property AccountExecutiveCode As String
            Get
                Return _AccountExecutiveCode
            End Get
            Set(ByVal Value As String)
                _AccountExecutiveCode = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: api
        ''' </summary>
        ''' <returns>String</returns>
        Public Property APInvoice As String
            Get
                Return _APInvoice
            End Get
            Set(value As String)
                _APInvoice = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: apid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property APID As Integer
            Get
                Return _APID
            End Get
            Set(value As Integer)
                _APID = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: bid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property BillingApprovalBatchID As Integer
            Get
                Return _BillingApprovalBatchId
            End Get
            Set(ByVal Value As Integer)
                _BillingApprovalBatchId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: aid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property BillingApprovalId As Integer
            Get
                Return _BillingApprovalId
            End Get
            Set(ByVal Value As Integer)
                _BillingApprovalId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: brdid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property BoardID As Integer
            Get
                Return _BoardID
            End Get
            Set(ByVal Value As Integer)
                _BoardID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: brdhid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property BoardHeaderID As Integer
            Get
                Return _BoardHeaderID
            End Get
            Set(ByVal Value As Integer)
                _BoardHeaderID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: brdcid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property BoardColumnID As Integer
            Get
                Return _BoardColumnID
            End Get
            Set(ByVal Value As Integer)
                _BoardColumnID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: brdcid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property BoardDetailID As Integer
            Get
                Return _BoardDetailID
            End Get
            Set(ByVal Value As Integer)
                _BoardDetailID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: brdstid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property BoardStateID As Integer
            Get
                Return _BoardStateID
            End Get
            Set(ByVal Value As Integer)
                _BoardStateID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: cmp
        ''' </summary>
        ''' <returns>String</returns>
        Public Property CampaignCode As String
            Get
                Return _CampaignCode
            End Get
            Set(ByVal Value As String)
                _CampaignCode = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: crid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ChatRoomId As Integer
            Get
                Return _ChatRoomId
            End Get
            Set(ByVal Value As Integer)
                _ChatRoomId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: c
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ClientCode As String
            Get
                Return _ClCode
            End Get
            Set(ByVal value As String)
                _ClCode = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: cid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property CampaignIdentifier As Integer
            Get
                Return _CmpIdentifier
            End Get
            Set(ByVal Value As Integer)
                _CmpIdentifier = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: conrptid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ContractReportID As Integer
            Get
                Return _ContractReportId
            End Get
            Set(ByVal Value As Integer)
                _ContractReportId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: csbcsrt
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ConceptShareBaseReviewType As AdvantageFramework.Database.Entities.ConceptShareBaseReviewType
            Get
                Return _ConceptShareBaseReviewType
            End Get
            Set(value As AdvantageFramework.Database.Entities.ConceptShareBaseReviewType)
                _ConceptShareBaseReviewType = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: cspid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ConceptShareProjectID As Integer
            Get
                Return _ConceptShareProjectID
            End Get
            Set(ByVal Value As Integer)
                _ConceptShareProjectID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: csrid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ConceptShareReviewID As Integer
            Get
                Return _ConceptShareReviewID
            End Get
            Set(ByVal Value As Integer)
                _ConceptShareReviewID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: csaid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ConceptShareAssetID As Integer
            Get
                Return _ConceptShareAssetID
            End Get
            Set(ByVal Value As Integer)
                _ConceptShareAssetID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: cscid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ConceptShareCommentID As Integer
            Get
                Return _ConceptShareCommentID
            End Get
            Set(ByVal Value As Integer)
                _ConceptShareCommentID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: contaid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ContentArea As ContentAreaName
            Get
                Return _ContentArea
            End Get
            Set(ByVal Value As ContentAreaName)
                _ContentArea = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: conid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ContractID As Integer
            Get
                Return _ContractId
            End Get
            Set(ByVal Value As Integer)
                _ContractId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: cod
        ''' </summary>
        ''' <returns>String</returns>
        Public Property CutOffDate As String
            Get
                Return _CutOffDate
            End Get
            Set(ByVal Value As String)
                _CutOffDate = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: dl
        ''' </summary>
        ''' <returns>String</returns>
        Public Property DeepLink As String
            Get
                Return _DeepLink
            End Get
            Set(ByVal value As String)
                _DeepLink = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: dtc
        ''' </summary>
        ''' <returns>String</returns>
        Public Property DepartmentTeamCode As String
            Get
                Return _DepartmentTeamCode
            End Get
            Set(ByVal value As String)
                _DepartmentTeamCode = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: d
        ''' </summary>
        ''' <returns>String</returns>
        Public Property DivisionCode As String
            Get
                Return _DivCode
            End Get
            Set(ByVal value As String)
                _DivCode = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: doclvl
        ''' </summary>
        ''' <returns>String</returns>
        Public Property DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel
            Get
                Return _DocumentLevel
            End Get
            Set(ByVal value As AdvantageFramework.Database.Entities.DocumentLevel)
                _DocumentLevel = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: doc
        ''' </summary>
        ''' <returns>String</returns>
        Public Property DocumentID As Integer
            Get
                Return _DocumentId
            End Get
            Set(ByVal Value As Integer)
                _DocumentId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: doclblid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property DocumentLabelID As Integer
            Get
                Return _DocumentLabelId
            End Get
            Set(ByVal Value As Integer)
                _DocumentLabelId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: dd
        ''' </summary>
        ''' <returns>String</returns>
        Public Property DueDate As String
            Get
                Return _DueDate
            End Get
            Set(ByVal Value As String)
                _DueDate = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: eg
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EmailGroup As String
            Get
                Return _EmailGroup
            End Get
            Set(ByVal Value As String)
                _EmailGroup = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: emp
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EmployeeCode As String
            Get
                Return _EmpCode
            End Get
            Set(ByVal Value As String)
                _EmpCode = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: en
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EmployeeName As String
            Get
                Return _EmployeeName
            End Get
            Set(ByVal Value As String)
                _EmployeeName = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: etid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EmployeeTimeID As Integer
            Get
                Return _EmployeeTimeId
            End Get
            Set(ByVal Value As Integer)
                _EmployeeTimeId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: etdid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EmployeeTimeDetailID As Integer
            Get
                Return _EmployeeTimeDetailId
            End Get
            Set(ByVal Value As Integer)
                _EmployeeTimeDetailId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: etfod
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EmployeeTimeForecastOfficeDetailID As Integer
            Get
                Return _EmployeeTimeForecastOfficeDetailId
            End Get
            Set(ByVal Value As Integer)
                _EmployeeTimeForecastOfficeDetailId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: ed
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EndDate As String
            Get
                Return _EndDate
            End Get
            Set(ByVal Value As String)
                _EndDate = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: ec
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EstimateComponentNumber As Integer
            Get
                Return _EstComponentNbr
            End Get
            Set(ByVal Value As Integer)
                _EstComponentNbr = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: e
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EstimateNumber As Integer
            Get
                Return _EstimateNumber
            End Get
            Set(ByVal Value As Integer)
                _EstimateNumber = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: eq
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EstimateQuoteNumber As Integer
            Get
                Return _EstQuoteNbr
            End Get
            Set(ByVal Value As Integer)
                _EstQuoteNbr = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: er
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EstimateRevisionNumber As Integer
            Get
                Return _EstRevNbr
            End Get
            Set(ByVal Value As Integer)
                _EstRevNbr = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: evt
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EventID As Integer
            Get
                Return _EventId
            End Get
            Set(ByVal value As Integer)
                _EventId = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: evtt
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EventTaskID As Integer
            Get
                Return _EventTaskId
            End Get
            Set(ByVal value As Integer)
                _EventTaskId = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: ept
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ExcludeProjectedTasks As Boolean
            Get
                Return _ExcludeProjectedTasks
            End Get
            Set(ByVal Value As Boolean)
                _ExcludeProjectedTasks = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: xid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ExpenseID As Integer
            Get
                Return _ExpenseId
            End Get
            Set(ByVal Value As Integer)
                _ExpenseId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: fn
        ''' </summary>
        ''' <returns>String</returns>
        Public Property FunctionCode As String
            Get
                Return _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: ics
        ''' </summary>
        ''' <returns>String</returns>
        Public Property IncludeCompletedSchedules As Boolean
            Get
                Return _IncludeCompletedSchedules
            End Get
            Set(ByVal Value As Boolean)
                _IncludeCompletedSchedules = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: ict
        ''' </summary>
        ''' <returns>String</returns>
        Public Property IncludeCompletedTasks As Boolean
            Get
                Return _IncludeCompletedTasks
            End Get
            Set(ByVal Value As Boolean)
                _IncludeCompletedTasks = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: ipt
        ''' </summary>
        ''' <returns>String</returns>
        Public Property IncludeOnlyPendingTasks As Boolean
            Get
                Return _IncludeOnlyPendingTasks
            End Get
            Set(ByVal Value As Boolean)
                _IncludeOnlyPendingTasks = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: inv
        ''' </summary>
        ''' <returns>String</returns>
        Public Property InvoiceNumber As Integer
            Get
                Return _InvoiceNumber
            End Get
            Set(ByVal value As Integer)
                _InvoiceNumber = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: invseq
        ''' </summary>
        ''' <returns>String</returns>
        Public Property InvoiceSequenceNumber As Integer
            Get
                Return _InvoiceSeqNbr
            End Get
            Set(ByVal value As Integer)
                _InvoiceSeqNbr = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: bm
        ''' </summary>
        ''' <returns>String</returns>
        Public Property IsBookmark As Boolean
            Get
                Return _IsBookmark
            End Get
            Set(ByVal Value As Boolean)
                _IsBookmark = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: jd
        ''' </summary>
        ''' <returns>String</returns>
        Public Property IsJobDashboard As Boolean
            Get
                Return _IsJobDashboard
            End Get
            Set(ByVal Value As Boolean)
                _IsJobDashboard = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: jc
        ''' </summary>
        ''' <returns>String</returns>
        Public Property JobComponentNumber As Integer
            Get
                Return _JobComponentNbr
            End Get
            Set(ByVal value As Integer)
                _JobComponentNbr = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: j
        ''' </summary>
        ''' <returns>String</returns>
        Public Property JobNumber As Integer
            Get
                Return _JobNumber
            End Get
            Set(ByVal value As Integer)
                _JobNumber = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: jvid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property JobVersionHeaderID As Integer
            Get
                Return _JobVersionHdrId
            End Get
            Set(ByVal value As Integer)
                _JobVersionHdrId = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: jvs
        ''' </summary>
        ''' <returns>String</returns>
        Public Property JobVersionSequenceNumber As Integer
            Get
                Return _JobVersionSeqNbr
            End Get
            Set(ByVal value As Integer)
                _JobVersionSeqNbr = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: locid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property LocationID As String
            Get
                Return _LocationID
            End Get
            Set(ByVal value As String)
                _LocationID = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: m
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ManagerCode As String
            Get
                Return _ManagerCode
            End Get
            Set(ByVal Value As String)
                _ManagerCode = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: matbrevid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property MediaATBRevisionID As Integer
            Get
                Return _MediaATBRevisionID
            End Get
            Set(ByVal Value As Integer)
                _MediaATBRevisionID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: matbnum
        ''' </summary>
        ''' <returns>String</returns>
        Public Property MediaATBNumber As Integer
            Get
                Return _MediaATBNumber
            End Get
            Set(ByVal Value As Integer)
                _MediaATBNumber = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: mon
        ''' </summary>
        ''' <returns>String</returns>
        Public Property MediaOrderNumber As Integer
            Get
                Return _MediaOrderNumber
            End Get
            Set(ByVal Value As Integer)
                _MediaOrderNumber = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: moln
        ''' </summary>
        ''' <returns>String</returns>
        Public Property MediaOrderLineNumber As Integer
            Get
                Return _MediaOrderLineNumber
            End Get
            Set(ByVal Value As Integer)
                _MediaOrderLineNumber = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: morn
        ''' </summary>
        ''' <returns>String</returns>
        Public Property MediaOrderRevisionNumber As Integer
            Get
                Return _MediaOrderRevisionNumber
            End Get
            Set(ByVal Value As Integer)
                _MediaOrderRevisionNumber = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: morsn
        ''' </summary>
        ''' <returns>String</returns>
        Public Property MediaOrderSequenceNumber As Integer
            Get
                Return _MediaOrderSequenceNumber
            End Get
            Set(ByVal Value As Integer)
                _MediaOrderSequenceNumber = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: matbrevid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property MediaATBRevisionNumber As Integer
            Get
                Return _MediaATBRevisionNumber
            End Get
            Set(ByVal Value As Integer)
                _MediaATBRevisionNumber = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: mt
        ''' </summary>
        ''' <returns>String</returns>
        Public Property MediaType As MediaOrderType
            Get
                Return _MediaType
            End Get
            Set(value As MediaOrderType)
                _MediaType = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: mso
        ''' </summary>
        ''' <returns>String</returns>
        Public Property MilestonesOnly As Boolean
            Get
                Return _MilestonesOnly
            End Get
            Set(ByVal Value As Boolean)
                _MilestonesOnly = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: mm
        ''' </summary>
        ''' <returns>String</returns>
        Public Property Month As Integer
            Get
                Return _Month
            End Get
            Set(ByVal Value As Integer)
                _Month = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: o
        ''' </summary>
        ''' <returns>String</returns>
        Public Property OfficeCode As String
            Get
                Return _OfficeCode
            End Get
            Set(ByVal value As String)
                _OfficeCode = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: pf
        ''' </summary>
        ''' <returns>String</returns>
        Public Property PhaseFilter As String
            Get
                Return _PhaseFilter
            End Get
            Set(ByVal Value As String)
                _PhaseFilter = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: po
        ''' </summary>
        ''' <returns>String</returns>
        Public Property PurchaseOrderNumber As Integer
            Get
                Return _PoNumber
            End Get
            Set(ByVal Value As Integer)
                _PoNumber = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: pp
        ''' </summary>
        ''' <returns>String</returns>
        Public Property PostPeriod As String
            Get
                Return _PostPeriod
            End Get
            Set(ByVal Value As String)
                _PostPeriod = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: p
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ProductCode As String
            Get
                Return _PrdCode
            End Get
            Set(ByVal value As String)
                _PrdCode = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: pxrid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ProofingStatusExternalReviewerID As String
            Get
                Return _ProofingStatusExternalReviewerID
            End Get
            Set(ByVal value As String)
                _ProofingStatusExternalReviewerID = value
            End Set
        End Property

        ''' <summary>
        ''' QueryString key: qty
        ''' </summary>
        ''' <returns>String</returns>
        Public Property Quantity As Integer
            Get
                Return _Quantity
            End Get
            Set(ByVal Value As Integer)
                _Quantity = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: rv
        ''' </summary>
        ''' <returns>String</returns>
        Public Property RevisionID As Integer
            Get
                Return _RevisionId
            End Get
            Set(ByVal Value As Integer)
                _RevisionId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: rc
        ''' </summary>
        ''' <returns>String</returns>
        Public Property RoleCode As String
            Get
                Return _RoleCode
            End Get
            Set(ByVal Value As String)
                _RoleCode = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: ri
        ''' </summary>
        ''' <returns>String</returns>
        Public Property RoomID As String
            Get
                Return _RoomId
            End Get
            Set(ByVal Value As String)
                _RoomId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: rn
        ''' </summary>
        ''' <returns>String</returns>
        Public Property RoomName As String
            Get
                Return _RoomName
            End Get
            Set(ByVal Value As String)
                _RoomName = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: rsh
        ''' </summary>
        ''' <returns>String</returns>
        Public Property Rush As Boolean
            Get
                Return _Rush
            End Get
            Set(ByVal Value As Boolean)
                _Rush = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: sc
        ''' </summary>
        ''' <returns>String</returns>
        Public Property SalesClassCode As String
            Get
                Return _ScCode
            End Get
            Set(ByVal Value As String)
                _ScCode = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: st
        ''' </summary>
        ''' <returns>String</returns>
        Public Property SearchText As String
            Get
                Return _SearchText
            End Get
            Set(ByVal Value As String)
                _SearchText = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: skip
        ''' </summary>
        ''' <returns>Integer</returns>
        Public Property Skip As Integer
            Get
                Return _Skip
            End Get
            Set(ByVal Value As Integer)
                _Skip = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: spid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property SpecificationID As Integer
            Get
                Return _SpecId
            End Get
            Set(ByVal Value As Integer)
                _SpecId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: sprhid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property SprintHeaderID As Integer
            Get
                Return _SprintHeaderID
            End Get
            Set(ByVal Value As Integer)
                _SprintHeaderID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: sprdid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property SprintDetailID As Integer
            Get
                Return _SprintDetailID
            End Get
            Set(ByVal Value As Integer)
                _SprintDetailID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: sd
        ''' </summary>
        ''' <returns>String</returns>
        Public Property StartDate As String
            Get
                Return _StartDate
            End Get
            Set(ByVal Value As String)
                _StartDate = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: take
        ''' </summary>
        ''' <returns>Integer</returns>
        Public Property Take As Integer
            Get
                Return _Take
            End Get
            Set(ByVal Value As Integer)
                _Take = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: tc
        ''' </summary>
        ''' <returns>String</returns>
        Public Property TaskCode As String
            Get
                Return _TaskCode
            End Get
            Set(ByVal Value As String)
                _TaskCode = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: s
        ''' </summary>
        ''' <returns>String</returns>
        Public Property TaskSequenceNumber As Integer
            Get
                Return _TaskSeqNbr
            End Get
            Set(ByVal value As Integer)
                _TaskSeqNbr = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: tt
        ''' </summary>
        ''' <returns>String</returns>
        Public Property TimeType As String
            Get
                Return _TimeType
            End Get
            Set(ByVal Value As String)
                _TimeType = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: tsc
        ''' </summary>
        ''' <returns>String</returns>
        Public Property TrafficStatusCode As Boolean
            Get
                Return _TrafficStatusCode
            End Get
            Set(ByVal Value As Boolean)
                _TrafficStatusCode = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: tsv
        ''' </summary>
        ''' <returns>String</returns>
        Public Property TrafficScheduleVersionID As Integer
            Get
                Return _TrafficScheduleVersionId
            End Get
            Set(ByVal value As Integer)
                _TrafficScheduleVersionId = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: usr
        ''' </summary>
        ''' <returns>String</returns>
        Public Property UserCode As String
            Get
                Return _UserCode
            End Get
            Set(ByVal Value As String)
                _UserCode = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: vc
        ''' </summary>
        ''' <returns>String</returns>
        Public Property VendorCode As String
            Get
                Return _VendorCode
            End Get
            Set(ByVal Value As String)
                _VendorCode = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: vid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property VersionID As Integer
            Get
                Return _VersionId
            End Get
            Set(ByVal Value As Integer)
                _VersionId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: w
        ''' </summary>
        ''' <returns>String</returns>
        Public Property WorkspaceID As Integer
            Get
                Return _WorkspaceId
            End Get
            Set(ByVal value As Integer)
                _WorkspaceId = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: yyyy
        ''' </summary>
        ''' <returns>String</returns>
        Public Property Year As Integer
            Get
                Return _Year
            End Get
            Set(ByVal Value As Integer)
                _Year = Value
            End Set
        End Property

#End Region

#End Region

#Region " Methods "
        Public Sub Build()

            Me.AddProperties()

        End Sub
        Public Sub Go(Optional ByVal PutIntoSession As Boolean = False, Optional ByVal EndResponse As Boolean = False)

            Me.Build()

            If PutIntoSession = False Then

                HttpContext.Current.Response.Redirect(Me.Page & Me.ToString(), EndResponse)

            Else

                HttpContext.Current.Response.Redirect(Me.Page, EndResponse)

            End If
        End Sub
        Public Sub PassThroughTo(ByVal PageName As String, Optional ByVal EndResponse As Boolean = False)

            Dim s As String = HttpContext.Current.Request.Url.AbsoluteUri.ToString()

            If s.IndexOf("?") > -1 Then

                Dim parts As String() = s.Split("?")

                If parts.Length > 1 Then

                    s = PageName & "?" & parts(1).ToString()

                Else

                    s = PageName

                End If

            Else

                s = PageName

            End If

            HttpContext.Current.Response.Redirect(s, EndResponse)

        End Sub
        Public Function FromString(ByVal Value As String) As QueryString

            Dim qs As New QueryString()

            Try

                qs = FromUrl(Value)

            Catch ex As Exception
            End Try

            Return qs

        End Function
        Public Function FromCurrent(Optional ByVal GetFromSession As Boolean = False) As QueryString

            Dim s As String = String.Empty

            Try

                s = HttpContext.Current.Request.Url.AbsoluteUri

            Catch ex As Exception
                s = String.Empty
            End Try

            If String.IsNullOrWhiteSpace(s) = False Then

                Me.CheckForEncoding(s)

                Return Me.FromString(s)

            Else

                Return Nothing

            End If

        End Function
        Private Sub CheckForEncoding(ByRef s As String)
            Try

                If s.Contains("&amp;") = True Then

                    s = HtmlDecode(s)

                End If
                If s.Contains("%") = True Then

                    s = UrlDecode(s)

                End If

            Catch ex As Exception
            End Try
        End Sub
        Public Overrides Sub Add(ByVal name As String, ByVal value As String)

            'Dim Sanitizer As New Ganss.XSS.HtmlSanitizer
            'value = Sanitizer.Sanitize(value)

            If Me(name) IsNot Nothing Then

                Me(name) = value

            Else

                MyBase.Add(name, value)

            End If

        End Sub
        Public Function GetValue(ByVal key As String) As String
            Try

                Dim s As String = Me.FromCurrent().ToString()

                If s.StartsWith("?") = True Then

                    s = s.Remove(0, 1)

                End If

                CheckForEncoding(s)

                Dim ar As String() = s.Split("&")

                For i As Integer = 0 To ar.Length - 1

                    Dim val As String() = ar(i).ToString().Split("=")

                    If val(0).ToString() = key Then

                        Return UrlDecode(val(1).ToString())

                    End If

                Next

                Return String.Empty

            Catch ex As Exception
                Return String.Empty
            End Try
        End Function
        Private Function FromUrl(ByVal URL As String) As QueryString

            Dim qs As New QueryString()

            If String.IsNullOrWhiteSpace(URL) Then

                URL = HttpContext.Current.Request.QueryString.ToString()

            End If

            CheckForEncoding(URL)

            If URL.Contains("?") = True Then

                Dim Values As System.Collections.Specialized.NameValueCollection = Nothing 'System.Web.HttpUtility.ParseQueryString(parts(1))
                Dim parts As String()

                parts = URL.Split("?")

                qs.Page = parts(0)

                If URL.Contains("?dl=") = True Then

                    Dim s As String()
                    Dim Encrypted As String = String.Empty
                    Dim r As String = String.Empty

                    s = URL.Split("?dl=")

                    Encrypted = s(1)

                    If Encrypted.StartsWith("dl=") Then

                        Encrypted = Encrypted.Replace("dl=", "")

                    End If

                    r = AdvantageFramework.Web.DecryptDeepLinkString(Encrypted)

                    qs.Add("dl", r)

                    Values = System.Web.HttpUtility.ParseQueryString(r)

                Else

                    Values = System.Web.HttpUtility.ParseQueryString(parts(1))

                End If
                If Values IsNot Nothing AndAlso Values.AllKeys.Count > 0 Then

                    Dim ThisKey As String = String.Empty
                    Dim ThisValue As String = String.Empty

                    For Each Value As String In Values.AllKeys

                        ThisKey = String.Empty
                        ThisValue = String.Empty

                        ThisKey = Value
                        ThisValue = Values(Value)

                        ThisValue = HttpUtility.UrlDecode(ThisValue)

                        qs.Add(ThisKey, ThisValue)

                        qs.ProcessKeyToValue(qs, ThisKey, ThisValue)

                    Next


                End If

            Else

                qs.Page = URL

            End If

            Return qs

            'If parts.Length = 1 Then

            '    Return qs

            'Else

            '    If URL.Contains("?dl=") = True Then

            '        Dim s As String()
            '        Dim Encrypted As String = String.Empty
            '        Dim r As String = String.Empty

            '        s = URL.Split("?dl=")

            '        Encrypted = s(1)

            '        If Encrypted.StartsWith("dl=") Then

            '            Encrypted = Encrypted.Replace("dl=", "")

            '        End If

            '        r = AdvantageFramework.Web.DecryptDeepLinkString(Encrypted)

            '        keys = r.Split("&")

            '    Else

            '        keys = parts(1).ToString().Split("&")

            '    End If
            '    For Each key As String In keys

            '        Dim part As String() = key.Split("=")
            '        Dim ThisKey As String = String.Empty
            '        Dim ThisValue As String = String.Empty

            '        ThisKey = part(0).ToString().Trim()

            '        If part.Length = 1 Then

            '            ThisValue = ""

            '        Else

            '            ThisValue = part(1).Trim()

            '        End If

            '        Try

            '            ThisValue = HttpUtility.UrlDecode(ThisValue)

            '        Catch ex As Exception
            '            ThisValue = ThisValue
            '        End Try

            '        qs.Add(ThisKey, ThisValue)

            '        With qs

            '            ProcessKeyToValue(qs, ThisKey, ThisValue)

            '        End With

            '    Next

            '    Return qs

            'End If

        End Function
        Private Sub ProcessKeyToValue(ByRef qs As QueryString, ByVal ThisKey As String, ByVal ThisValue As String)

            With qs

                Select Case ThisKey.ToLower 'Keep the key alphabetical please
                    Case "a", "alertid"

                        Try

                            If ThisValue.Contains(",") = True Then

                                Dim s As String()
                                s = ThisValue.Split(",")
                                ThisValue = s(0)

                            End If


                        Catch ex As Exception
                        End Try
                        Try

                            If IsNumeric(ThisValue) Then ._AlertId = CType(ThisValue, Integer)

                        Catch ex As Exception
                        End Try

                    Case "aamib"

                        If IsNumeric(ThisValue) Then ._AamIncludeBacklog = Me.FromInt(CType(ThisValue, Integer))

                    Case "aamibl"

                        If IsNumeric(ThisValue) Then ._AamIncludeBoardLevel = Me.FromInt(CType(ThisValue, Integer))

                    Case "aamgb"

                        ._AamGroupBy = ThisValue.ToString()

                    Case "aamic"

                        If IsNumeric(ThisValue) Then ._AamIsCount = Me.FromInt(CType(ThisValue, Integer))

                    Case "aamica"

                        If IsNumeric(ThisValue) Then ._AamIncludeCompletedAssignments = Me.FromInt(CType(ThisValue, Integer))

                    Case "aamstct"

                        If IsNumeric(ThisValue) Then ._AamShowOnlyTempCompletedTasks = Me.FromInt(CType(ThisValue, Integer))

                    Case "aamijap"

                        If IsNumeric(ThisValue) Then ._AamIsJobAlertsPage = Me.FromInt(CType(ThisValue, Integer))

                    Case "aamir"

                        If IsNumeric(ThisValue) Then ._AamIncludeReviews = Me.FromInt(CType(ThisValue, Integer))

                    Case "aamit"

                        ._AamInboxType = ThisValue.ToString()

                    Case "aamrtr"

                        If IsNumeric(ThisValue) Then ._AamRecordsToReturn = CType(ThisValue, Integer)

                    Case "aamsat"

                        ._AamShowAssignmentType = ThisValue.ToString()

                    Case "aamgs"

                        If IsNumeric(ThisValue) Then ._AamGridSize = CType(ThisValue, Integer)

                    Case "ae"

                        ._AccountExecutiveCode = ThisValue.ToString()

                    Case "aid"

                        If IsNumeric(ThisValue) Then ._BillingApprovalId = CType(ThisValue, Integer)

                    Case "ani"

                        If IsNumeric(ThisValue) Then ._AlertNotifyHdrId = CType(ThisValue, Integer)

                    Case "api"

                        ._APInvoice = ThisValue.ToString()

                    Case "apid"

                        If IsNumeric(ThisValue) Then ._APID = CType(ThisValue, Integer)

                    Case "asi"

                        If IsNumeric(ThisValue) Then ._AlertStateId = CType(ThisValue, Integer)

                    Case "bid"

                        If IsNumeric(ThisValue) Then ._BillingApprovalBatchId = CType(ThisValue, Integer)

                    Case "bm"

                        If IsNumeric(ThisValue) Then ._IsBookmark = Me.FromInt(CType(ThisValue, Integer))

                    Case "brdid"

                        If IsNumeric(ThisValue) Then ._BoardID = Me.FromInt(CType(ThisValue, Integer))

                    Case "brdhid"

                        If IsNumeric(ThisValue) Then ._BoardHeaderID = Me.FromInt(CType(ThisValue, Integer))

                    Case "brdcid"

                        If IsNumeric(ThisValue) Then ._BoardColumnID = Me.FromInt(CType(ThisValue, Integer))

                    Case "brddid"

                        If IsNumeric(ThisValue) Then ._BoardDetailID = Me.FromInt(CType(ThisValue, Integer))

                    Case "brdstid"

                        If IsNumeric(ThisValue) Then ._BoardStateID = Me.FromInt(CType(ThisValue, Integer))

                    Case "c", "cl", "cli", "client", "clcode"

                        ._ClCode = ThisValue.ToString()

                    Case "cid"

                        If IsNumeric(ThisValue) Then ._CmpIdentifier = CType(ThisValue, Integer)

                    Case "cmp", "cmpcode"

                        ._CampaignCode = ThisValue.ToString()

                    Case "cod"

                        If IsDate(ThisValue) = True Then ._CutOffDate = CDate(ThisValue).ToShortDateString()

                            'Case "con"

                            '    ._ConnString = ThisValue.ToString()

                    Case "conid"

                        If IsNumeric(ThisValue) Then ._ContractId = CType(ThisValue, Integer)

                    Case "conrptid"

                        If IsNumeric(ThisValue) Then ._ContractReportId = CType(ThisValue, Integer)

                    Case "contaid"

                        If IsNumeric(ThisValue) Then ._ContentArea = CType(CType(ThisValue, Integer), ContentAreaName)

                    Case "crid"

                        If IsNumeric(ThisValue) Then ._ChatRoomId = CType(ThisValue, Integer)

                    Case "csbcsrt"

                        If IsNumeric(ThisValue) Then ._ConceptShareBaseReviewType = CType(CType(ThisValue, Integer), AdvantageFramework.Database.Entities.ConceptShareBaseReviewType)

                    Case "csaid"

                        If IsNumeric(ThisValue) Then ._ConceptShareAssetID = CType(ThisValue, Integer)

                    Case "cscid"

                        If IsNumeric(ThisValue) Then ._ConceptShareCommentID = CType(ThisValue, Integer)

                    Case "cspid"

                        If IsNumeric(ThisValue) Then ._ConceptShareProjectID = CType(ThisValue, Integer)

                    Case "csrid"

                        If IsNumeric(ThisValue) Then ._ConceptShareReviewID = CType(ThisValue, Integer)

                    Case "d", "di", "div", "division", "divcode", "dicode"

                        ._DivCode = ThisValue.ToString()

                    Case "dd"

                        If IsDate(ThisValue) = True Then ._DueDate = CDate(ThisValue).ToShortDateString()

                    Case "dl"

                        ._DeepLink = ThisValue.ToString()

                    Case "doc"

                        If IsNumeric(ThisValue) Then ._DocumentId = CType(ThisValue, Integer)

                    Case "doclblid"

                        If IsNumeric(ThisValue) Then ._DocumentLabelId = CType(ThisValue, Integer)

                    Case "doclvl"

                        If IsNumeric(ThisValue) Then ._DocumentLevel = CType(CType(ThisValue, Integer), AdvantageFramework.Database.Entities.DocumentLevel)

                    Case "dtc"

                        ._DepartmentTeamCode = ThisValue.ToString()

                    Case "e"

                        If IsNumeric(ThisValue) Then ._EstimateNumber = CType(ThisValue, Integer)

                    Case "ec"

                        If IsNumeric(ThisValue) Then ._EstComponentNbr = CType(ThisValue, Integer)

                    Case "ed"

                        If IsDate(ThisValue) = True Then ._EndDate = CDate(ThisValue).ToShortDateString()

                    Case "eg"

                        ._EmailGroup = ThisValue.ToString()

                    Case "emp"

                        ._EmpCode = ThisValue.ToString()

                    Case "en"

                        ._EmployeeName = ThisValue.ToString()

                    Case "ept"

                        If IsNumeric(ThisValue) Then ._ExcludeProjectedTasks = Me.FromInt(CType(ThisValue, Integer))

                    Case "eq"

                        If IsNumeric(ThisValue) Then ._EstQuoteNbr = CType(ThisValue, Integer)

                    Case "er"

                        If IsNumeric(ThisValue) Then ._EstRevNbr = CType(ThisValue, Integer)

                    Case "etid"

                        If IsNumeric(ThisValue) Then ._EmployeeTimeId = CType(ThisValue, Integer)

                    Case "etdid"

                        If IsNumeric(ThisValue) Then ._EmployeeTimeDetailId = CType(ThisValue, Integer)

                    Case "etfod"

                        If IsNumeric(ThisValue) Then ._EmployeeTimeForecastOfficeDetailId = CType(ThisValue, Integer)

                    Case "evt"

                        If IsNumeric(ThisValue) Then ._EventId = CType(ThisValue, Integer)

                    Case "evtt"

                        ._EventTaskId = CType(ThisValue, Integer)

                    Case "f"

                        If IsNumeric(ThisValue) Then ._App = CType(CType(ThisValue, Integer), Source_App)

                    Case "fn"

                        ._FunctionCode = ThisValue

                    Case "ics"

                        If IsNumeric(ThisValue) Then ._IncludeCompletedSchedules = Me.FromInt(CType(ThisValue, Integer))

                    Case "ict"

                        If IsNumeric(ThisValue) Then ._IncludeCompletedTasks = Me.FromInt(CType(ThisValue, Integer))

                    Case "ipt"

                        If IsNumeric(ThisValue) Then ._IncludeOnlyPendingTasks = Me.FromInt(CType(ThisValue, Integer))

                    Case "inv"

                        If IsNumeric(ThisValue) Then ._InvoiceNumber = CType(ThisValue, Integer)

                    Case "invseq"

                        If IsNumeric(ThisValue) Then ._InvoiceSeqNbr = CType(ThisValue, Integer)

                    Case "j", "job", "jobnum", "jobnumber", "jobnbr"

                        If IsNumeric(ThisValue) Then ._JobNumber = CType(ThisValue, Integer)

                    Case "jc", "comp", "jobcomp", "jobcompnum", "jobcompnumber", "jobcomponentnumber", "jobcompnbr"

                        If IsNumeric(ThisValue) Then ._JobComponentNbr = CType(ThisValue, Integer)

                    Case "jd"

                        If IsNumeric(ThisValue) Then ._IsJobDashboard = Me.FromInt(CType(ThisValue, Integer))

                    Case "jvid"

                        If IsNumeric(ThisValue) Then ._JobVersionHdrId = CType(ThisValue, Integer)

                    Case "jvs"

                        If IsNumeric(ThisValue) Then ._JobVersionSeqNbr = CType(ThisValue, Integer)

                    Case "locid"

                        If String.IsNullOrWhiteSpace(ThisValue) = False Then ._LocationID = ThisValue

                    Case "m"

                        ._ManagerCode = ThisValue.ToString()

                    Case "matbrevid"

                        If IsNumeric(ThisValue) Then ._MediaATBRevisionID = CType(ThisValue, Integer)

                    Case "matbnum"

                        If IsNumeric(ThisValue) Then ._MediaATBNumber = CType(ThisValue, Integer)

                    Case "matbrevid"

                        If IsNumeric(ThisValue) Then ._MediaATBRevisionNumber = CType(ThisValue, Integer)

                    Case "mm"

                        If IsNumeric(ThisValue) Then ._Month = CType(ThisValue, Integer)

                    Case "mon"

                        If IsNumeric(ThisValue) Then ._MediaOrderNumber = CType(ThisValue, Integer)

                    Case "moln"

                        If IsNumeric(ThisValue) Then ._MediaOrderLineNumber = CType(ThisValue, Integer)

                    Case "morn"

                        If IsNumeric(ThisValue) Then ._MediaOrderRevisionNumber = CType(ThisValue, Integer)

                    Case "morsn"

                        If IsNumeric(ThisValue) Then ._MediaOrderSequenceNumber = CType(ThisValue, Integer)

                    Case "mso"

                        If IsNumeric(ThisValue) Then ._MilestonesOnly = Me.FromInt(CType(ThisValue, Integer))

                    Case "mt"

                        If IsNumeric(ThisValue) Then ._MediaType = CType(CType(ThisValue, Integer), MediaOrderType)

                    Case "o" ', "office"

                        ._OfficeCode = ThisValue.ToString()

                    Case "p" ', "prod", "product"

                        ._PrdCode = ThisValue.ToString()

                    Case "pf"

                        ._PhaseFilter = ThisValue.ToString()

                    Case "po"

                        ._PoNumber = CType(ThisValue, Integer)

                    Case "pp"

                        ._PostPeriod = ThisValue

                    Case "pxrid"

                        ._ProofingStatusExternalReviewerID = CType(ThisValue, Integer)

                    Case "qty"

                        If IsNumeric(ThisValue) Then ._Quantity = CType(ThisValue, Integer)

                    Case "rc"

                        ._RoleCode = ThisValue.ToString()

                    Case "ri"

                        ._RoomId = ThisValue.ToString()

                    Case "rn"

                        ._RoomName = ThisValue.ToString()

                    Case "rsh"

                        If IsNumeric(ThisValue) Then ._Rush = Me.FromInt(CType(ThisValue, Integer))

                    Case "rv"

                        If IsNumeric(ThisValue) Then ._RevisionId = CType(ThisValue, Integer)

                    Case "s"

                        If IsNumeric(ThisValue) Then ._TaskSeqNbr = CType(ThisValue, Integer)

                    Case "sc"

                        ._ScCode = ThisValue

                    Case "sd"

                        If IsDate(ThisValue) = True Then ._StartDate = CDate(ThisValue).ToShortDateString()

                    Case "skip"

                        ._Skip = CType(ThisValue, Integer)

                    Case "spid"

                        If IsNumeric(ThisValue) Then ._SpecId = CType(ThisValue, Integer)

                    Case "sprhid", "sprintid"

                        If IsNumeric(ThisValue) Then ._SprintHeaderID = CType(ThisValue, Integer)

                    Case "sprdid"

                        If IsNumeric(ThisValue) Then ._SprintDetailID = CType(ThisValue, Integer)

                    'Case "SSSN"

                    '    If IsNumeric(ThisValue) Then ._IsSession = Me.FromInt(CType(ThisValue, Integer))

                    Case "st"

                        ._SearchText = ThisValue.ToString()

                    Case "take"

                        ._Take = CType(ThisValue, Integer)

                    Case "tc"

                        ._TaskCode = ThisValue.ToString()

                    Case "tsc"

                        ._TrafficStatusCode = ThisValue.ToString()

                    Case "tsv"

                        If IsNumeric(ThisValue) Then ._TrafficScheduleVersionId = CType(ThisValue, Integer)

                    Case "tt"

                        ._TimeType = ThisValue.ToString

                    Case "usr"

                        Try

                            If ThisValue.Contains(",") = True Then

                                Dim s As String()
                                s = ThisValue.Split(",")
                                ThisValue = s(0)

                            End If

                        Catch ex As Exception
                        End Try
                        Try

                            ._UserCode = ThisValue.ToString()

                        Catch ex As Exception
                        End Try

                    Case "vc"

                        ._VendorCode = ThisValue.ToString()

                    Case "vid"

                        If IsNumeric(ThisValue) Then ._VersionId = CType(ThisValue, Integer)

                    Case "w"

                        If IsNumeric(ThisValue) Then ._WorkspaceId = CType(ThisValue, Integer)

                    Case "xid"

                        If IsNumeric(ThisValue) Then ._ExpenseId = CType(ThisValue, Integer)

                        'Case "xx1"

                        '    If String.IsNullOrWhiteSpace(ThisValue) = False Then Me._ServerName = ThisValue

                        'Case "xx2"

                        '    If String.IsNullOrWhiteSpace(ThisValue) = False Then Me._DatabaseName = ThisValue

                    Case "xx3"

                        If String.IsNullOrWhiteSpace(ThisValue) = False Then Me._UserCode = ThisValue

                        'Case "xx4"

                        '    If String.IsNullOrWhiteSpace(ThisValue) = False Then Me._Password = ThisValue

                    Case "xx5"

                        If IsDate(ThisValue) = True Then Me._ApiDate = CType(ThisValue, DateTime)

                    Case "xx6"

                        If String.IsNullOrWhiteSpace(ThisValue) = False Then Me._ConnectionString = ThisValue

                    Case "yyyy"

                        If IsNumeric(ThisValue) Then ._Year = CType(ThisValue, Integer)

                End Select

            End With

        End Sub
        Public Sub RemoveAllKeys()

            Dim AllQuerystringKeys As [String]()
            Dim i As Integer = 0

            AllQuerystringKeys = Me.AllKeys

            While i < AllQuerystringKeys.Length

                Me.Remove(AllQuerystringKeys(i))
                i += 1

            End While

        End Sub
        Private Sub AddProperties()

            'keep the key alphabetical please and as short as possible
            'Starts with  "xx" is for encrypted conn info

            If Me._AlertId > 0 Then

                Me.Add("a", Me._AlertId.ToString())

            End If
            If String.IsNullOrWhiteSpace(Me._AamInboxType.Trim()) = False Then

                Me.Add("aamit", Me._AamInboxType.Trim())

            End If
            If Me._AamIncludeCompletedAssignments = True Then

                Me.Add("aamica", Me.ToInt(Me._AamIncludeCompletedAssignments))

            End If
            If Me._AamShowOnlyTempCompletedTasks = True Then

                Me.Add("aamstct", Me.ToInt(Me.AamShowOnlyTempCompletedTasks))

            End If
            If String.IsNullOrWhiteSpace(Me._AamGroupBy.Trim()) = False Then

                Me.Add("aamgb", Me._AamGroupBy.ToString())

            End If
            If Me._AamIncludeBacklog = True Then

                Me.Add("aamib", Me.ToInt(Me._AamIncludeBacklog))

            End If
            If Me._AamIncludeBoardLevel = True Then

                Me.Add("aamibl", Me.ToInt(Me._AamIncludeBoardLevel))

            End If
            If Me._AamIsCount = True Then

                Me.Add("aamic", Me.ToInt(Me._AamIsCount))

            End If
            If Me._AamIsJobAlertsPage = True Then

                Me.Add("aamijap", Me.ToInt(Me._AamIsJobAlertsPage))

            End If
            If Me._AamIncludeReviews = True Then

                Me.Add("aamir", Me.ToInt(Me._AamIncludeReviews))

            End If
            If Me._AamRecordsToReturn > 0 Then

                Me.Add("aamrtr", Me._AamRecordsToReturn.ToString())

            End If
            If String.IsNullOrWhiteSpace(Me._AamShowAssignmentType.Trim()) = False Then

                Me.Add("aamsat", Me._AamShowAssignmentType.ToString())

            End If
            If Me._AamGridSize > 0 Then

                Me.Add("aamgs", Me._AamGridSize.ToString())

            End If
            If String.IsNullOrWhiteSpace(Me._AccountExecutiveCode.Trim()) = False Then

                Me.Add("ae", Me._AccountExecutiveCode.Trim())

            End If
            If Me._BillingApprovalId > 0 Then

                Me.Add("aid", Me._BillingApprovalId.ToString())

            End If
            If Me._AlertNotifyHdrId > 0 Then

                Me.Add("ani", Me._AlertNotifyHdrId.ToString())

            End If
            If String.IsNullOrWhiteSpace(Me._APInvoice.Trim()) = False Then

                Me.Add("api", Me._APInvoice.ToString())

            End If
            If Me._APID > 0 Then

                Me.Add("apid", Me._APID.ToString())

            End If
            If Me._AlertStateId > 0 Then

                Me.Add("asi", Me._AlertStateId.ToString())

            End If
            If Me._BillingApprovalBatchId > 0 Then

                Me.Add("bid", Me._BillingApprovalBatchId.ToString())

            End If
            If Me._IsBookmark = True Then

                Me.Add("bm", Me.ToInt(Me._IsBookmark))

            End If
            If Me._BoardID > 0 Then

                Me.Add("brdid", Me._BoardID.ToString())

            End If
            If Me._BoardHeaderID > 0 Then

                Me.Add("brdhid", Me._BoardHeaderID.ToString())

            End If
            If Me._BoardColumnID > 0 Then

                Me.Add("brdcid", Me._BoardColumnID.ToString())

            End If
            If Me._BoardDetailID > 0 Then

                Me.Add("brddid", Me._BoardDetailID.ToString())

            End If
            If Me._BoardDetailID > 0 Then

                Me.Add("brdstid", Me._BoardStateID.ToString())

            End If
            If String.IsNullOrWhiteSpace(Me._ClCode.Trim()) = False Then

                Me.Add("c", Me._ClCode.Trim())

            End If
            If Me._CmpIdentifier > 0 Then

                Me.Add("cid", Me._CmpIdentifier.ToString())

            End If
            If String.IsNullOrWhiteSpace(Me._CampaignCode.Trim()) = False Then

                Me.Add("cmp", Me._CampaignCode.Trim())

            End If
            If String.IsNullOrWhiteSpace(Me._CutOffDate.Trim()) = False Then

                If IsDate(Me._CutOffDate) = True Then

                    Me.Add("cod", CDate(Me._CutOffDate.Trim()).ToShortDateString())

                End If

            End If
            'If String.IsNullOrWhiteSpace(Me._ConnString.Trim()) = False Then

            '    Me.Add("con", Me._ConnString.Trim())

            'End If
            If Me._ContractId > 0 Then

                Me.Add("conid", Me._ContractId.ToString())

            End If
            If Me._ContractReportId > 0 Then

                Me.Add("conrptid", Me._ContractReportId.ToString())

            End If
            If Me._ContentArea > 0 Then

                Me.Add("contaid", CType(Me._ContentArea, Integer).ToString())

            End If
            If Me._ChatRoomId > 0 Then

                Me.Add("crid", Me._ChatRoomId.ToString())

            End If
            If Not Me._ConceptShareBaseReviewType = Nothing Then

                Me.Add("csbcsrt", CType(Me._ConceptShareBaseReviewType, Integer).ToString())

            End If
            If Me._ConceptShareAssetID > 0 Then

                Me.Add("csaid", Me._ConceptShareAssetID.ToString())

            End If
            If Me._ConceptShareCommentID > 0 Then

                Me.Add("cscid", Me._ConceptShareCommentID.ToString())

            End If
            If Me._ConceptShareProjectID > 0 Then

                Me.Add("cspid", Me._ConceptShareProjectID.ToString())

            End If
            If Me._ConceptShareReviewID > 0 Then

                Me.Add("csrid", Me._ConceptShareReviewID.ToString())

            End If
            If String.IsNullOrWhiteSpace(Me._DivCode.Trim()) = False Then

                Me.Add("d", Me._DivCode.Trim())

            End If
            If String.IsNullOrWhiteSpace(Me._DueDate.Trim()) = False Then

                If IsDate(Me._DueDate) = True Then

                    Me.Add("dd", CDate(Me._DueDate.Trim()).ToShortDateString())

                End If

            End If
            If String.IsNullOrWhiteSpace(Me._DeepLink.Trim()) = False Then

                Me.Add("dl", Me._DeepLink.Trim())

            End If
            If Me._DocumentId > 0 Then

                Me.Add("doc", Me._DocumentId.ToString())

            End If
            If Me._DocumentLabelId > 0 Then

                Me.Add("doclblid", Me._DocumentLabelId.ToString())

            End If
            If Not Me._DocumentLevel = Nothing Then

                Me.Add("doclvl", CType(Me._DocumentLevel, Integer).ToString())

            End If
            If String.IsNullOrWhiteSpace(Me._DepartmentTeamCode.Trim()) = False Then

                Me.Add("dtc", Me._DepartmentTeamCode.Trim())

            End If
            If Me._EstimateNumber > 0 Then

                Me.Add("e", Me._EstimateNumber.ToString())

            End If
            If Me._EstComponentNbr > 0 Then

                Me.Add("ec", Me._EstComponentNbr.ToString())

            End If
            If String.IsNullOrWhiteSpace(Me._EndDate.Trim()) = False Then

                If IsDate(Me._EndDate) = True Then

                    Me.Add("ed", CDate(Me._EndDate.Trim()).ToShortDateString())

                End If

            End If
            If String.IsNullOrWhiteSpace(Me._EmailGroup.Trim()) = False Then

                Me.Add("eg", Me._EmailGroup.Trim())

            End If
            If String.IsNullOrWhiteSpace(Me._EmpCode.Trim()) = False Then

                Me.Add("emp", Me._EmpCode.Trim())

            End If
            If String.IsNullOrWhiteSpace(Me._EmployeeName.Trim()) = False Then

                Me.Add("en", Me._EmployeeName.Trim())

            End If
            If Me._ExcludeProjectedTasks = True Then

                Me.Add("ept", Me.ToInt(Me._ExcludeProjectedTasks))

            End If
            If Me._EstQuoteNbr > 0 Then

                Me.Add("eq", Me._EstQuoteNbr.ToString())

            End If
            If Me._EstRevNbr > 0 Then

                Me.Add("er", Me._EstRevNbr.ToString())

            End If
            If Me._EmployeeTimeId > 0 Then

                Me.Add("etid", Me._EmployeeTimeId.ToString())

            End If
            If Me._EmployeeTimeDetailId > 0 Then

                Me.Add("etdid", Me._EmployeeTimeDetailId.ToString())

            End If
            If Me._EmployeeTimeForecastOfficeDetailId > 0 Then

                Me.Add("etfod", Me._EmployeeTimeForecastOfficeDetailId.ToString())

            End If
            If Me._EventId > 0 Then

                Me.Add("evt", Me._EventId.ToString())

            End If
            If Me._EventTaskId > 0 Then

                Me.Add("evtt", Me._EventTaskId.ToString())

            End If
            If Not Me._App = Nothing Then

                Me.Add("f", CType(Me._App, Integer).ToString())

            End If
            If String.IsNullOrWhiteSpace(Me._FunctionCode.Trim()) = False Then

                Me.Add("fn", Me._FunctionCode.Trim())

            End If
            If Me._IncludeCompletedSchedules = True Then

                Me.Add("ics", Me.ToInt(Me._IncludeCompletedSchedules))

            End If
            If Me._IncludeCompletedTasks = True Then

                Me.Add("ict", Me.ToInt(Me._IncludeCompletedTasks))

            End If
            If Me._IncludeOnlyPendingTasks = True Then

                Me.Add("ipt", Me.ToInt(Me._IncludeOnlyPendingTasks))

            End If
            If Me._InvoiceNumber > 0 Then

                Me.Add("inv", Me._InvoiceNumber.ToString())

            End If
            If Me._InvoiceSeqNbr > -1 Then

                Me.Add("invseq", Me._InvoiceSeqNbr.ToString())

            End If
            If Me._JobNumber > 0 Then

                Me.Add("j", Me._JobNumber.ToString())

            End If
            If Me._JobComponentNbr > 0 Then

                Me.Add("jc", Me._JobComponentNbr.ToString())

            End If
            If Me._IsJobDashboard = True Then

                Me.Add("jd", Me.ToInt(Me._IsJobDashboard))

            End If
            If Me._JobVersionHdrId > 0 Then

                Me.Add("jvid", Me._JobVersionHdrId.ToString())

            End If
            If Me._JobVersionSeqNbr > 0 Then

                Me.Add("jvs", Me._JobVersionSeqNbr.ToString())

            End If
            If String.IsNullOrWhiteSpace(Me._LocationID) = False Then

                Me.Add("locid", Me._LocationID.Trim())

            End If
            If String.IsNullOrWhiteSpace(Me._ManagerCode.Trim()) = False Then

                Me.Add("m", Me._ManagerCode.Trim())

            End If
            If Me._MediaATBRevisionID > 0 Then

                Me.Add("matbrevid", Me._MediaATBRevisionID.ToString())

            End If
            If Me._MediaATBNumber > 0 Then

                Me.Add("matbnum", Me._MediaATBNumber.ToString())

            End If
            If Me._MediaATBRevisionNumber > 0 Then

                Me.Add("matbrevid", Me._MediaATBRevisionNumber.ToString())

            End If
            If Me._Month > 0 Then

                Me.Add("mm", Me._Month.ToString())

            End If
            If Me._MediaOrderNumber > 0 Then

                Me.Add("mon", Me._MediaOrderNumber.ToString())

            End If
            If Me._MediaOrderLineNumber > 0 Then

                Me.Add("moln", Me._MediaOrderLineNumber.ToString())

            End If
            If Me._MediaOrderRevisionNumber > 0 Then

                Me.Add("morn", Me._MediaOrderRevisionNumber.ToString())

            End If
            If Me._MediaOrderSequenceNumber > 0 Then

                Me.Add("morsn", Me._MediaOrderSequenceNumber.ToString())

            End If
            If Me._MilestonesOnly = True Then

                Me.Add("mso", Me.ToInt(Me._MilestonesOnly))

            End If
            If Not Me._MediaType = Nothing Then

                Me.Add("mt", CType(Me._MediaType, Integer).ToString())

            End If
            If String.IsNullOrWhiteSpace(Me._OfficeCode.Trim()) = False Then

                Me.Add("o", Me._OfficeCode.Trim())

            End If
            If String.IsNullOrWhiteSpace(Me._PrdCode.Trim()) = False Then

                Me.Add("p", Me._PrdCode.Trim())

            End If
            If Me._ProofingStatusExternalReviewerID > 0 Then

                Me.Add("pxrid", Me._ProofingStatusExternalReviewerID.ToString())

            End If
            If String.IsNullOrWhiteSpace(Me._PhaseFilter.Trim()) = False Then

                Me.Add("pf", Me._PhaseFilter.Trim())

            End If
            If Me._PoNumber > 0 Then

                Me.Add("po", Me._PoNumber.ToString())

            End If
            If String.IsNullOrWhiteSpace(Me._PostPeriod.Trim()) = False Then

                Me.Add("pp", Me._PostPeriod.Trim())

            End If
            If Me._Quantity > 0 Then

                Me.Add("qty", Me._Quantity.ToString())

            End If
            If String.IsNullOrWhiteSpace(Me._RoleCode.Trim()) = False Then

                Me.Add("rc", Me._RoleCode.Trim())

            End If
            If String.IsNullOrWhiteSpace(Me._RoomId.Trim()) = False Then

                Me.Add("ri", Me._RoomId.Trim())

            End If
            If String.IsNullOrWhiteSpace(Me._RoomName.Trim()) = False Then

                Me.Add("rn", Me._RoomName.Trim())

            End If
            If Me._Rush = True Then

                Me.Add("rsh", Me.ToInt(Me._Rush))

            End If
            If Me._RevisionId > 0 Then

                Me.Add("rv", Me._RevisionId.ToString())

            End If
            If Me._TaskSeqNbr > -1 Then

                Me.Add("s", Me._TaskSeqNbr.ToString())

            End If
            If String.IsNullOrWhiteSpace(Me._ScCode.Trim()) = False Then

                Me.Add("sc", Me._ScCode.Trim())

            End If
            If String.IsNullOrWhiteSpace(Me._StartDate.Trim()) = False Then

                If IsDate(Me._StartDate) = True Then

                    Me.Add("sd", CDate(Me._StartDate.Trim()).ToShortDateString())

                End If

            End If
            If Me._Skip > 0 Then

                Me.Add("skip", Me._Skip.ToString())

            End If
            If Me._SpecId > 0 Then

                Me.Add("spid", Me._SpecId.ToString())

            End If
            If Me._SprintHeaderID > 0 Then

                Me.Add("sprhid", Me._SprintHeaderID.ToString())

            End If
            If Me._SprintDetailID > 0 Then

                Me.Add("sprdid", Me._SprintDetailID.ToString())

            End If
            If Me._IsSession = True Then

                Me.Add("SSSN", Me.ToInt(Me._IsSession))

            End If
            If String.IsNullOrWhiteSpace(Me._SearchText.Trim()) = False Then

                Me.Add("st", Me._SearchText.Trim())

            End If
            If Me._Take > 0 Then

                Me.Add("take", Me._Take.ToString())

            End If
            If String.IsNullOrWhiteSpace(Me._TaskCode.Trim()) = False Then

                Me.Add("tc", Me._TaskCode.Trim())

            End If
            If String.IsNullOrWhiteSpace(Me._TrafficStatusCode.Trim()) = False Then

                Me.Add("tsc", Me._TrafficStatusCode.Trim())

            End If
            If Me._TrafficScheduleVersionId > -1 Then

                Me.Add("tsv", Me._TrafficScheduleVersionId.ToString())

            End If
            If String.IsNullOrWhiteSpace(Me._TimeType.Trim()) = False Then

                Me.Add("tt", Me._TimeType.Trim())

            End If
            If String.IsNullOrWhiteSpace(Me._UserCode.Trim()) = False Then

                Me.Add("usr", Me._UserCode.Trim())

            End If
            If String.IsNullOrWhiteSpace(Me._VendorCode.Trim()) = False Then

                Me.Add("vc", Me._VendorCode.ToString())

            End If
            If Me._VersionId > 0 Then

                Me.Add("vid", Me._VersionId.ToString())

            End If
            If Me._WorkspaceId > 0 Then

                Me.Add("w", Me._WorkspaceId.ToString())

            End If
            If Me._ExpenseId > 0 Then

                Me.Add("xid", Me._ExpenseId.ToString())

            End If
            If Me._Year > 0 Then

                Me.Add("yyyy", Me._Year.ToString())

            End If

        End Sub
        Public Sub FromString()


        End Sub

#Region " ToString "
        Public Overrides Function ToString() As String

            Return ToString(False)

        End Function
        Public Overloads Function ToString(ByVal IncludePage As Boolean) As String

            Me.Build()

            Dim url As String = String.Empty
            Dim parts As String() = New String(Me.Count - 1) {}
            Dim keys As String() = Me.AllKeys

            For i As Integer = 0 To keys.Length - 1

                parts(i) = keys(i) & "=" & HttpContext.Current.Server.UrlEncode(Me(keys(i)))

            Next

            url = [String].Join("&", parts)

            If Me._HasConnectionString = False Then

                If String.IsNullOrWhiteSpace(url) = False AndAlso url.StartsWith("?") = False Then

                    url = "?" & url

                End If
                If IncludePage Then

                    url = Me._Page & url

                End If

            Else

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me._AdminConnectionString, Me._AdminUserCode)

                    Dim ApiURL As String = String.Empty

                    ApiURL = AdvantageFramework.Web.GetProofingBaseURL(SecurityDbContext)

                    If String.IsNullOrWhiteSpace(ApiURL) = False Then

                        If Me._Page.StartsWith("/") = True Then

                            Me._Page = Me._Page.Substring(1, Me._Page.Length - 1)

                        End If

                        url = ApiURL & Me._Page & "?dl=" & AdvantageFramework.Web.EncryptDeepLinkQueryString(url)

                    End If

                End Using

            End If

            Return url

        End Function

#End Region

#Region " API Querystring"

        '''''''' <summary>
        ''''''''     Only need to use this if you did NOT instantiate QS object without SecuritySession
        '''''''' </summary>
        '''''''' <returns>Boolean</returns>
        '''''Public Function BuildForAPI(ByVal DbContext As AdvantageFramework.Database.DbContext,
        '''''                            ByVal UserCode As String,
        '''''                            ByVal Password As String,
        '''''                            ByVal AllowConnectionStringUser As Boolean)

        '''''    Dim Success As Boolean = False

        '''''    Try

        '''''        If DbContext IsNot Nothing AndAlso String.IsNullOrWhiteSpace(DbContext.ConnectionString) = False Then

        '''''            Dim Builder As New SqlConnectionStringBuilder(DbContext.ConnectionString)

        '''''            Me._ServerName = Builder.DataSource
        '''''            Me._DatabaseName = Builder.InitialCatalog

        '''''            If String.IsNullOrWhiteSpace(UserCode) = False AndAlso String.IsNullOrWhiteSpace(Password) = False Then

        '''''                Me._UserCode = UserCode
        '''''                Me._Password = Password

        '''''            Else

        '''''                If AllowConnectionStringUser = True Then

        '''''                    Me._UserCode = Builder.UserID
        '''''                    Me._Password = Builder.Password

        '''''                End If

        '''''            End If

        '''''            If String.IsNullOrWhiteSpace(Me._ServerName) = False AndAlso String.IsNullOrWhiteSpace(Me._DatabaseName) = False AndAlso
        '''''               String.IsNullOrWhiteSpace(Me._UserCode) = False AndAlso String.IsNullOrWhiteSpace(Me._Password) = False Then

        '''''                Success = BuildForAPI()

        '''''            End If

        '''''        End If

        '''''    Catch ex As Exception
        '''''        Success = False
        '''''    End Try

        '''''    Return Success

        '''''End Function
        '''''''' <summary>
        ''''''''     Only need to use this if you did NOT instantiate QS object without SecuritySession
        '''''''' </summary>
        '''''''' <returns>Boolean</returns>
        '''''Public Function BuildForAPI(ByVal SecuritySession As AdvantageFramework.Security.Session)

        '''''    Dim Success As Boolean = False

        '''''    Try

        '''''        If SecuritySession IsNot Nothing Then

        '''''            If String.IsNullOrWhiteSpace(SecuritySession.ServerName) = False Then Me._ServerName = SecuritySession.ServerName
        '''''            If String.IsNullOrWhiteSpace(SecuritySession.DatabaseName) = False Then Me._DatabaseName = SecuritySession.DatabaseName
        '''''            If String.IsNullOrWhiteSpace(SecuritySession.UserCode) = False Then Me._UserCode = SecuritySession.UserCode
        '''''            If String.IsNullOrWhiteSpace(SecuritySession.Password) = False Then Me._Password = SecuritySession.Password

        '''''            Success = BuildForAPI()

        '''''        End If

        '''''    Catch ex As Exception
        '''''        Success = False
        '''''    End Try

        '''''    Return Success

        '''''End Function

        ''' <summary>
        '''     If QS object was instantiated WITH SecuritySession, add the admin connstring and force encrypt!
        ''' </summary>
        ''' <returns>Boolean</returns>

#End Region

#Region " Helpers "
        Private Function ToInt(ByVal bool As Boolean) As Integer

            If bool = True Then

                Return 1

            Else

                Return 0

            End If

        End Function
        Private Function FromInt(ByVal int As Integer) As Boolean

            If int = 1 Then

                Return True

            Else

                Return False

            End If

        End Function

#End Region

#Region " Constructors "
        Public Sub New()

        End Sub
        ''' <summary>
        '''     Instantiate with SecuritySession to include the connectionstring and force encryption
        ''' </summary>
        Public Sub New(ByVal SecuritySession As AdvantageFramework.Security.Session)

            If SecuritySession IsNot Nothing Then

                If String.IsNullOrWhiteSpace(SecuritySession.ServerName) = False Then Me._ServerName = SecuritySession.ServerName
                If String.IsNullOrWhiteSpace(SecuritySession.DatabaseName) = False Then Me._DatabaseName = SecuritySession.DatabaseName
                If String.IsNullOrWhiteSpace(SecuritySession.UserCode) = False Then Me._UserCode = SecuritySession.UserCode
                If String.IsNullOrWhiteSpace(SecuritySession.Password) = False Then Me._Password = SecuritySession.Password

                If String.IsNullOrWhiteSpace(Me._ServerName) = False AndAlso String.IsNullOrWhiteSpace(Me._DatabaseName) = False Then

                    Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing

                    ConnectionDatabaseProfile = AdvantageFramework.Database.LoadConnectionDatabaseProfile(Me._DatabaseName)

                    If ConnectionDatabaseProfile IsNot Nothing Then

                        Me._AdminConnectionString = ConnectionDatabaseProfile.GetConnectionString(AdvantageFramework.Security.Application.ProofingAPI)
                        Me._AdminUserCode = ConnectionDatabaseProfile.UserName
                        Me._AdminPassword = ConnectionDatabaseProfile.GetDecryptPassword()

                        ''Add connection string info
                        'Me.Add("xx1", Me._ServerName)
                        'Me.Add("xx2", Me._DatabaseName)
                        Me.Add("xx3", Me._UserCode)
                        'Me.Add("xx4", Me._Password)

                        'Add expiry info
                        If String.IsNullOrWhiteSpace(Me.ProofingStatusExternalReviewerID) = False AndAlso
                           IsNumeric(Me.ProofingStatusExternalReviewerID) = True AndAlso
                           CType(Me.ProofingStatusExternalReviewerID, Integer) > 0 Then

                            Me.Add("xx5", DateTime.Now.ToString)

                        End If

                        'Add admin conn
                        Me.Add("xx6", Me._AdminConnectionString)

                        Me._HasConnectionString = True

                    End If

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
