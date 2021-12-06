using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Web;

namespace AdvantageFramework.Core.Web
{
    [Serializable()]
    public class QueryString
    {
        #region Constants

        private const int _APIExperationMinutes = 30;

        #endregion

        #region Enum

        public enum Source_App
        {
            Alert = 0,
            JobJacket = 1,
            JobJacketAlerts = 2,
            ProjectSchedule = 3,
            ProjectScheduleTask = 4,
            Campaign = 5,
            Estimate = 6 // multiple components (ALERT TYPE: ES)
    ,
            Desktop = 7,
            PurchaseOrder = 8,
            RequestForQuote = 9,
            JobVersion = 10,
            CreativeBrief = 11,
            ProjectSchedule_Alerts = 12,
            Campaign_Print = 13,
            VendorQuote = 14,
            EstimateComponent = 15 // One component (ALERT TYPE: EST)
    ,
            JobSpecs = 16,
            CalendarActivity = 17
        }

        public enum ContentAreaName
        {
            None = 0,
            Alerts = 1,
            CreativeBrief = 2,
            Documents = 3,
            Estimates = 4,
            Events = 5,
            Gantt = 6,
            JobSpecifications = 7,
            JobStatus = 8,
            JobStatus_Team = 9,
            JobTemplate = 10,
            JobVersion = 11,
            PurchaseOrder = 12,
            FinancialStatus = 13,
            Risk = 14,
            Schedule = 15,
            Workload = 16,
            Billing = 17,
            Reports = 18,
            Calendar = 19,
            JobForecasts = 20,
            MediaOrderList = 21,
            AccountSetupForm = 22,
            Chat = 23,
            DigitalAssetReviews = 24,
            ProjectBoard = 25
        }
        public enum MediaOrderType
        {
            None,
            Internet,
            Magazine,
            Newspaper,
            Outdoor,
            Radio,
            TV
        }

        #endregion

        #region Variables

        private NameValueCollection _Collection { get; set; }

        private string _RequestURL = string.Empty;
        private string _ServerName = string.Empty;
        private string _DatabaseName = string.Empty;
        private string _UserName = string.Empty;
        private string _Password = string.Empty;
        private DateTime? _ApiDate = null;
        // Public ApiIsValid As Boolean = False 'To verify within data
        // Public ConnectionInfoIsValid As Boolean = False
        private bool _HasConnectionString = false;
        private string _AdminConnectionString = string.Empty;
        private string _AdminUserCode = string.Empty;
        private string _AdminPassword = string.Empty;
        public string ErrorMessage = string.Empty;
        private string _ConnectionString = string.Empty;
        private string _AamGroupBy = string.Empty;
        private string _AamInboxType = string.Empty;
        private bool _AamIncludeBacklog = false;
        private bool _AamIncludeBoardLevel = false;
        private bool _AamIncludeCompletedAssignments = false;
        private bool _AamIncludeReviews = false;
        private bool _AamIsCount = false;
        private bool _AamIsJobAlertsPage = false;
        private int _AamRecordsToReturn = 0;
        private string _AamShowAssignmentType = string.Empty;
        private string _AccountExecutiveCode = string.Empty;
        private int _AlertId = 0;
        private int _AlertNotifyHdrId = 0;
        private int _AlertStateId = 0;
        private string _APInvoice = string.Empty;
        private int _APID = 0;
        private Source_App _App = default(Source_App);
        private int _BillingApprovalBatchId = 0;
        private int _BillingApprovalId = 0;
        private int _BoardID = 0;
        private int _BoardColumnID = 0;
        private int _BoardHeaderID = 0;
        private int _BoardDetailID = 0;
        private int _BoardStateID = 0;
        private string _CampaignCode = string.Empty;
        private int _ChatRoomId = 0;
        private string _ClCode = string.Empty;
        private int _CmpIdentifier = 0;
        private int _ConceptShareAssetID = 0;
        //private AdvantageFramework.Database.Entities.ConceptShareBaseReviewType _ConceptShareBaseReviewType = null/* TODO Change to default(_) if this is not a reference type */;
        private int _ConceptShareCommentID = 0;
        private int _ConceptShareProjectID = 0;
        private int _ConceptShareReviewID = 0;
        private ContentAreaName _ContentArea = ContentAreaName.None;
        private int _ContractId = 0;
        private int _ContractReportId = 0;
        private string _CutOffDate = string.Empty;
        private string _DeepLink = string.Empty;
        private string _DepartmentTeamCode = string.Empty;
        private string _DivCode = string.Empty;
        private int _DocumentId = 0;
        private int _DocumentLabelId = 0;
        //private AdvantageFramework.Database.Entities.DocumentLevel _DocumentLevel = null/* TODO Change to default(_) if this is not a reference type */;
        private string _DueDate = string.Empty;
        private string _EmailGroup = string.Empty;
        private string _EmpCode = string.Empty;
        private string _EmployeeName = string.Empty;
        private int _EmployeeTimeId = 0;
        private int _EmployeeTimeDetailId = 0;
        private int _EmployeeTimeForecastOfficeDetailId = 0;
        private string _EndDate = string.Empty;
        private int _EstComponentNbr = 0;
        private int _EstimateNumber = 0;
        private int _EstQuoteNbr = 0;
        private int _EstRevNbr = 0;
        private int _EventId = 0;
        private int _EventTaskId = 0;
        private bool _ExcludeProjectedTasks = false;
        private int _ExpenseId = 0;
        private string _FunctionCode = string.Empty;
        private bool _IncludeCompletedSchedules = false;
        private bool _IncludeCompletedTasks = false;
        private bool _IncludeOnlyPendingTasks = false;
        private int _InvoiceNumber = 0;
        private int _InvoiceSeqNbr = -1;
        private bool _IsBookmark = false;
        private bool _IsJobDashboard = false;
        private bool _IsSession = false;
        private int _JobComponentNbr = 0;
        private int _JobNumber = 0;
        private int _JobVersionHdrId = 0;
        private int _JobVersionSeqNbr = 0;
        private string _LocationID = string.Empty;
        private string _ManagerCode = string.Empty;
        private int _MediaATBRevisionID = 0;
        private int _MediaATBNumber = 0;
        private int _MediaATBRevisionNumber = 0;
        private int _MediaOrderNumber = 0;
        private int _MediaOrderLineNumber = 0;
        private int _MediaOrderRevisionNumber = 0;
        private int _MediaOrderSequenceNumber = 0;
        private MediaOrderType _MediaType = MediaOrderType.None;
        private bool _MilestonesOnly = false;
        private int _Month = 0;
        private string _OfficeCode = string.Empty;
        private string _Page = string.Empty;
        private string _PhaseFilter = string.Empty;
        private int _PoNumber = 0;
        private string _PostPeriod = string.Empty;
        private string _PrdCode = string.Empty;
        private int _ProofingStatusExternalReviewerID = 0;
        private int _Quantity = 0;
        private int _RevisionId = 0;
        private string _RoleCode = string.Empty;
        private string _RoomId = string.Empty;
        private string _RoomName = string.Empty;
        private bool _Rush = false;
        private string _ScCode = string.Empty;
        private string _SearchText = string.Empty;
        private int _Skip = 0;
        private int _SpecId = 0;
        private int _SprintHeaderID = 0;
        private int _SprintDetailID = 0;
        private string _StartDate = string.Empty;
        private int _Take = 0;
        private string _TaskCode = string.Empty;
        private int _TaskSeqNbr = -1;
        private string _TimeType = string.Empty;
        private string _TrafficStatusCode = string.Empty;
        private int _TrafficScheduleVersionId = -1;
        private string _UserCode = string.Empty;
        private string _VendorCode = string.Empty;
        private int _VersionId = 0;
        private int _WorkspaceId = 0;
        private int _Year = 0;

        #endregion

        #region Properties

        // ''' <summary>
        // ''' QueryString key: con
        // ''' </summary>
        // ''' <returns>String</returns>
        // Public Property ConnectionString As String
        // Get
        // Return _ConnString
        // End Get
        // Set(ByVal Value As String)
        // _ConnString = Value
        // End Set
        // End Property

        public string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
        }

        /// <summary>
        /// QueryString key: N/A
        /// </summary>
        /// <returns>String</returns>
        public string Page
        {
            get
            {
                return _Page;
            }
            set
            {
                _Page = value;
            }
        }
        /// <summary>
        /// QueryString key: f
        /// </summary>
        /// <returns>String</returns>
        public Source_App App
        {
            get
            {
                return _App;
            }
            set
            {
                _App = value;
            }
        }
        /// <summary>
        /// QueryString key: SSSN
        /// </summary>
        /// <returns>String</returns>
        public bool IsSession
        {
            get
            {
                return _IsSession;
            }
            set
            {
                _IsSession = value;
            }
        }
        /// <summary>
        /// QueryString key: aamgb
        /// </summary>
        /// <returns>String</returns>
        public string AamGroupBy
        {
            get
            {
                return _AamGroupBy;
            }
            set
            {
                _AamGroupBy = value;
            }
        }
        /// <summary>
        /// QueryString key: aamit
        /// </summary>
        /// <returns>String</returns>
        public string AamInboxType
        {
            get
            {
                return _AamInboxType;
            }
            set
            {
                _AamInboxType = value;
            }
        }
        /// <summary>
        /// QueryString key: aamib
        /// </summary>
        /// <returns>String</returns>
        public bool AamIncludeBacklog
        {
            get
            {
                return _AamIncludeBacklog;
            }
            set
            {
                _AamIncludeBacklog = value;
            }
        }
        /// <summary>
        /// QueryString key: aamibl
        /// </summary>
        /// <returns>String</returns>
        public bool AamIncludeBoardLevel
        {
            get
            {
                return _AamIncludeBoardLevel;
            }
            set
            {
                _AamIncludeBoardLevel = value;
            }
        }
        /// <summary>
        /// QueryString key: aamica
        /// </summary>
        /// <returns>String</returns>
        public bool AamIncludeCompletedAssignments
        {
            get
            {
                return _AamIncludeCompletedAssignments;
            }
            set
            {
                _AamIncludeCompletedAssignments = value;
            }
        }
        /// <summary>
        /// QueryString key: aamir
        /// </summary>
        /// <returns>String</returns>
        public bool AamIncludeReviews
        {
            get
            {
                return _AamIncludeReviews;
            }
            set
            {
                _AamIncludeReviews = value;
            }
        }
        /// <summary>
        /// QueryString key: aamic
        /// </summary>
        /// <returns>String</returns>
        public bool AamIsCount
        {
            get
            {
                return _AamIsCount;
            }
            set
            {
                _AamIsCount = value;
            }
        }
        /// <summary>
        /// QueryString key: aamijap
        /// </summary>
        /// <returns>String</returns>
        public bool AamIsJobAlertsPage
        {
            get
            {
                return _AamIsJobAlertsPage;
            }
            set
            {
                _AamIsJobAlertsPage = value;
            }
        }
        /// <summary>
        /// QueryString key: aamrtr
        /// </summary>
        /// <returns>String</returns>
        public int AamRecordsToReturn
        {
            get
            {
                return _AamRecordsToReturn;
            }
            set
            {
                _AamRecordsToReturn = value;
            }
        }
        /// <summary>
        /// QueryString key: aamsat
        /// </summary>
        /// <returns>String</returns>
        public string AamShowAssignmentType
        {
            get
            {
                return _AamShowAssignmentType;
            }
            set
            {
                _AamShowAssignmentType = value;
            }
        }
        /// <summary>
        /// QueryString key: a
        /// </summary>
        /// <returns>String</returns>
        public int AlertID
        {
            get
            {
                return _AlertId;
            }
            set
            {
                _AlertId = value;
            }
        }
        /// <summary>
        /// QueryString key: ani
        /// </summary>
        /// <returns>String</returns>
        public int AlertTemplateID
        {
            get
            {
                return _AlertNotifyHdrId;
            }
            set
            {
                _AlertNotifyHdrId = value;
            }
        }
        /// <summary>
        /// QueryString key: asi
        /// </summary>
        /// <returns>String</returns>
        public int AlertStateID
        {
            get
            {
                return _AlertStateId;
            }
            set
            {
                _AlertStateId = value;
            }
        }
        /// <summary>
        /// QueryString key: ae
        /// </summary>
        /// <returns>String</returns>
        public string AccountExecutiveCode
        {
            get
            {
                return _AccountExecutiveCode;
            }
            set
            {
                _AccountExecutiveCode = value;
            }
        }
        /// <summary>
        /// QueryString key: api
        /// </summary>
        /// <returns>String</returns>
        public string APInvoice
        {
            get
            {
                return _APInvoice;
            }
            set
            {
                _APInvoice = value;
            }
        }
        /// <summary>
        /// QueryString key: apid
        /// </summary>
        /// <returns>String</returns>
        public int APID
        {
            get
            {
                return _APID;
            }
            set
            {
                _APID = value;
            }
        }
        /// <summary>
        /// QueryString key: bid
        /// </summary>
        /// <returns>String</returns>
        public int BillingApprovalBatchID
        {
            get
            {
                return _BillingApprovalBatchId;
            }
            set
            {
                _BillingApprovalBatchId = value;
            }
        }
        /// <summary>
        /// QueryString key: aid
        /// </summary>
        /// <returns>String</returns>
        public int BillingApprovalId
        {
            get
            {
                return _BillingApprovalId;
            }
            set
            {
                _BillingApprovalId = value;
            }
        }
        /// <summary>
        /// QueryString key: brdid
        /// </summary>
        /// <returns>String</returns>
        public int BoardID
        {
            get
            {
                return _BoardID;
            }
            set
            {
                _BoardID = value;
            }
        }
        /// <summary>
        /// QueryString key: brdhid
        /// </summary>
        /// <returns>String</returns>
        public int BoardHeaderID
        {
            get
            {
                return _BoardHeaderID;
            }
            set
            {
                _BoardHeaderID = value;
            }
        }
        /// <summary>
        /// QueryString key: brdcid
        /// </summary>
        /// <returns>String</returns>
        public int BoardColumnID
        {
            get
            {
                return _BoardColumnID;
            }
            set
            {
                _BoardColumnID = value;
            }
        }
        /// <summary>
        /// QueryString key: brdcid
        /// </summary>
        /// <returns>String</returns>
        public int BoardDetailID
        {
            get
            {
                return _BoardDetailID;
            }
            set
            {
                _BoardDetailID = value;
            }
        }
        /// <summary>
        /// QueryString key: brdstid
        /// </summary>
        /// <returns>String</returns>
        public int BoardStateID
        {
            get
            {
                return _BoardStateID;
            }
            set
            {
                _BoardStateID = value;
            }
        }
        /// <summary>
        /// QueryString key: cmp
        /// </summary>
        /// <returns>String</returns>
        public string CampaignCode
        {
            get
            {
                return _CampaignCode;
            }
            set
            {
                _CampaignCode = value;
            }
        }
        /// <summary>
        /// QueryString key: crid
        /// </summary>
        /// <returns>String</returns>
        public int ChatRoomId
        {
            get
            {
                return _ChatRoomId;
            }
            set
            {
                _ChatRoomId = value;
            }
        }
        /// <summary>
        /// QueryString key: c
        /// </summary>
        /// <returns>String</returns>
        public string ClientCode
        {
            get
            {
                return _ClCode;
            }
            set
            {
                _ClCode = value;
            }
        }
        /// <summary>
        /// QueryString key: cid
        /// </summary>
        /// <returns>String</returns>
        public int CampaignIdentifier
        {
            get
            {
                return _CmpIdentifier;
            }
            set
            {
                _CmpIdentifier = value;
            }
        }
        /// <summary>
        /// QueryString key: conrptid
        /// </summary>
        /// <returns>String</returns>
        public int ContractReportID
        {
            get
            {
                return _ContractReportId;
            }
            set
            {
                _ContractReportId = value;
            }
        }
        /// <summary>
        /// QueryString key: csbcsrt
        /// </summary>
        /// <returns>String</returns>
        //public AdvantageFramework.Database.Entities.ConceptShareBaseReviewType ConceptShareBaseReviewType
        //{
        //    get
        //    {
        //        return _ConceptShareBaseReviewType;
        //    }
        //    set
        //    {
        //        _ConceptShareBaseReviewType = value;
        //    }
        //}
        /// <summary>
        /// QueryString key: cspid
        /// </summary>
        /// <returns>String</returns>
        public int ConceptShareProjectID
        {
            get
            {
                return _ConceptShareProjectID;
            }
            set
            {
                _ConceptShareProjectID = value;
            }
        }
        /// <summary>
        /// QueryString key: csrid
        /// </summary>
        /// <returns>String</returns>
        public int ConceptShareReviewID
        {
            get
            {
                return _ConceptShareReviewID;
            }
            set
            {
                _ConceptShareReviewID = value;
            }
        }
        /// <summary>
        /// QueryString key: csaid
        /// </summary>
        /// <returns>String</returns>
        public int ConceptShareAssetID
        {
            get
            {
                return _ConceptShareAssetID;
            }
            set
            {
                _ConceptShareAssetID = value;
            }
        }
        /// <summary>
        /// QueryString key: cscid
        /// </summary>
        /// <returns>String</returns>
        public int ConceptShareCommentID
        {
            get
            {
                return _ConceptShareCommentID;
            }
            set
            {
                _ConceptShareCommentID = value;
            }
        }
        /// <summary>
        /// QueryString key: contaid
        /// </summary>
        /// <returns>String</returns>
        public ContentAreaName ContentArea
        {
            get
            {
                return _ContentArea;
            }
            set
            {
                _ContentArea = value;
            }
        }
        /// <summary>
        /// QueryString key: conid
        /// </summary>
        /// <returns>String</returns>
        public int ContractID
        {
            get
            {
                return _ContractId;
            }
            set
            {
                _ContractId = value;
            }
        }
        /// <summary>
        /// QueryString key: cod
        /// </summary>
        /// <returns>String</returns>
        public string CutOffDate
        {
            get
            {
                return _CutOffDate;
            }
            set
            {
                _CutOffDate = value;
            }
        }
        /// <summary>
        /// QueryString key: dl
        /// </summary>
        /// <returns>String</returns>
        public string DeepLink
        {
            get
            {
                return _DeepLink;
            }
            set
            {
                _DeepLink = value;
            }
        }
        /// <summary>
        /// QueryString key: dtc
        /// </summary>
        /// <returns>String</returns>
        public string DepartmentTeamCode
        {
            get
            {
                return _DepartmentTeamCode;
            }
            set
            {
                _DepartmentTeamCode = value;
            }
        }
        /// <summary>
        /// QueryString key: d
        /// </summary>
        /// <returns>String</returns>
        public string DivisionCode
        {
            get
            {
                return _DivCode;
            }
            set
            {
                _DivCode = value;
            }
        }
        /// <summary>
        /// QueryString key: doclvl
        /// </summary>
        /// <returns>String</returns>
        //public AdvantageFramework.Database.Entities.DocumentLevel DocumentLevel
        //{
        //    get
        //    {
        //        return _DocumentLevel;
        //    }
        //    set
        //    {
        //        _DocumentLevel = value;
        //    }
        //}
        /// <summary>
        /// QueryString key: doc
        /// </summary>
        /// <returns>String</returns>
        public int DocumentID
        {
            get
            {
                return _DocumentId;
            }
            set
            {
                _DocumentId = value;
            }
        }
        /// <summary>
        /// QueryString key: doclblid
        /// </summary>
        /// <returns>String</returns>
        public int DocumentLabelID
        {
            get
            {
                return _DocumentLabelId;
            }
            set
            {
                _DocumentLabelId = value;
            }
        }
        /// <summary>
        /// QueryString key: dd
        /// </summary>
        /// <returns>String</returns>
        public string DueDate
        {
            get
            {
                return _DueDate;
            }
            set
            {
                _DueDate = value;
            }
        }
        /// <summary>
        /// QueryString key: eg
        /// </summary>
        /// <returns>String</returns>
        public string EmailGroup
        {
            get
            {
                return _EmailGroup;
            }
            set
            {
                _EmailGroup = value;
            }
        }
        /// <summary>
        /// QueryString key: emp
        /// </summary>
        /// <returns>String</returns>
        public string EmployeeCode
        {
            get
            {
                return _EmpCode;
            }
            set
            {
                _EmpCode = value;
            }
        }
        /// <summary>
        /// QueryString key: en
        /// </summary>
        /// <returns>String</returns>
        public string EmployeeName
        {
            get
            {
                return _EmployeeName;
            }
            set
            {
                _EmployeeName = value;
            }
        }
        /// <summary>
        /// QueryString key: etid
        /// </summary>
        /// <returns>String</returns>
        public int EmployeeTimeID
        {
            get
            {
                return _EmployeeTimeId;
            }
            set
            {
                _EmployeeTimeId = value;
            }
        }
        /// <summary>
        /// QueryString key: etdid
        /// </summary>
        /// <returns>String</returns>
        public int EmployeeTimeDetailID
        {
            get
            {
                return _EmployeeTimeDetailId;
            }
            set
            {
                _EmployeeTimeDetailId = value;
            }
        }
        /// <summary>
        /// QueryString key: etfod
        /// </summary>
        /// <returns>String</returns>
        public int EmployeeTimeForecastOfficeDetailID
        {
            get
            {
                return _EmployeeTimeForecastOfficeDetailId;
            }
            set
            {
                _EmployeeTimeForecastOfficeDetailId = value;
            }
        }
        /// <summary>
        /// QueryString key: ed
        /// </summary>
        /// <returns>String</returns>
        public string EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                _EndDate = value;
            }
        }
        /// <summary>
        /// QueryString key: ec
        /// </summary>
        /// <returns>String</returns>
        public int EstimateComponentNumber
        {
            get
            {
                return _EstComponentNbr;
            }
            set
            {
                _EstComponentNbr = value;
            }
        }
        /// <summary>
        /// QueryString key: e
        /// </summary>
        /// <returns>String</returns>
        public int EstimateNumber
        {
            get
            {
                return _EstimateNumber;
            }
            set
            {
                _EstimateNumber = value;
            }
        }
        /// <summary>
        /// QueryString key: eq
        /// </summary>
        /// <returns>String</returns>
        public int EstimateQuoteNumber
        {
            get
            {
                return _EstQuoteNbr;
            }
            set
            {
                _EstQuoteNbr = value;
            }
        }
        /// <summary>
        /// QueryString key: er
        /// </summary>
        /// <returns>String</returns>
        public int EstimateRevisionNumber
        {
            get
            {
                return _EstRevNbr;
            }
            set
            {
                _EstRevNbr = value;
            }
        }
        /// <summary>
        /// QueryString key: evt
        /// </summary>
        /// <returns>String</returns>
        public int EventID
        {
            get
            {
                return _EventId;
            }
            set
            {
                _EventId = value;
            }
        }
        /// <summary>
        /// QueryString key: evtt
        /// </summary>
        /// <returns>String</returns>
        public int EventTaskID
        {
            get
            {
                return _EventTaskId;
            }
            set
            {
                _EventTaskId = value;
            }
        }
        /// <summary>
        /// QueryString key: ept
        /// </summary>
        /// <returns>String</returns>
        public bool ExcludeProjectedTasks
        {
            get
            {
                return _ExcludeProjectedTasks;
            }
            set
            {
                _ExcludeProjectedTasks = value;
            }
        }
        /// <summary>
        /// QueryString key: xid
        /// </summary>
        /// <returns>String</returns>
        public int ExpenseID
        {
            get
            {
                return _ExpenseId;
            }
            set
            {
                _ExpenseId = value;
            }
        }
        /// <summary>
        /// QueryString key: fn
        /// </summary>
        /// <returns>String</returns>
        public string FunctionCode
        {
            get
            {
                return _FunctionCode;
            }
            set
            {
                _FunctionCode = value;
            }
        }
        /// <summary>
        /// QueryString key: ics
        /// </summary>
        /// <returns>String</returns>
        public bool IncludeCompletedSchedules
        {
            get
            {
                return _IncludeCompletedSchedules;
            }
            set
            {
                _IncludeCompletedSchedules = value;
            }
        }
        /// <summary>
        /// QueryString key: ict
        /// </summary>
        /// <returns>String</returns>
        public bool IncludeCompletedTasks
        {
            get
            {
                return _IncludeCompletedTasks;
            }
            set
            {
                _IncludeCompletedTasks = value;
            }
        }
        /// <summary>
        /// QueryString key: ipt
        /// </summary>
        /// <returns>String</returns>
        public bool IncludeOnlyPendingTasks
        {
            get
            {
                return _IncludeOnlyPendingTasks;
            }
            set
            {
                _IncludeOnlyPendingTasks = value;
            }
        }
        /// <summary>
        /// QueryString key: inv
        /// </summary>
        /// <returns>String</returns>
        public int InvoiceNumber
        {
            get
            {
                return _InvoiceNumber;
            }
            set
            {
                _InvoiceNumber = value;
            }
        }
        /// <summary>
        /// QueryString key: invseq
        /// </summary>
        /// <returns>String</returns>
        public int InvoiceSequenceNumber
        {
            get
            {
                return _InvoiceSeqNbr;
            }
            set
            {
                _InvoiceSeqNbr = value;
            }
        }
        /// <summary>
        /// QueryString key: bm
        /// </summary>
        /// <returns>String</returns>
        public bool IsBookmark
        {
            get
            {
                return _IsBookmark;
            }
            set
            {
                _IsBookmark = value;
            }
        }
        /// <summary>
        /// QueryString key: jd
        /// </summary>
        /// <returns>String</returns>
        public bool IsJobDashboard
        {
            get
            {
                return _IsJobDashboard;
            }
            set
            {
                _IsJobDashboard = value;
            }
        }
        /// <summary>
        /// QueryString key: jc
        /// </summary>
        /// <returns>String</returns>
        public int JobComponentNumber
        {
            get
            {
                return _JobComponentNbr;
            }
            set
            {
                _JobComponentNbr = value;
            }
        }
        /// <summary>
        /// QueryString key: j
        /// </summary>
        /// <returns>String</returns>
        public int JobNumber
        {
            get
            {
                return _JobNumber;
            }
            set
            {
                _JobNumber = value;
            }
        }
        /// <summary>
        /// QueryString key: jvid
        /// </summary>
        /// <returns>String</returns>
        public int JobVersionHeaderID
        {
            get
            {
                return _JobVersionHdrId;
            }
            set
            {
                _JobVersionHdrId = value;
            }
        }
        /// <summary>
        /// QueryString key: jvs
        /// </summary>
        /// <returns>String</returns>
        public int JobVersionSequenceNumber
        {
            get
            {
                return _JobVersionSeqNbr;
            }
            set
            {
                _JobVersionSeqNbr = value;
            }
        }
        /// <summary>
        /// QueryString key: locid
        /// </summary>
        /// <returns>String</returns>
        public string LocationID
        {
            get
            {
                return _LocationID;
            }
            set
            {
                _LocationID = value;
            }
        }
        /// <summary>
        /// QueryString key: m
        /// </summary>
        /// <returns>String</returns>
        public string ManagerCode
        {
            get
            {
                return _ManagerCode;
            }
            set
            {
                _ManagerCode = value;
            }
        }
        /// <summary>
        /// QueryString key: matbrevid
        /// </summary>
        /// <returns>String</returns>
        public int MediaATBRevisionID
        {
            get
            {
                return _MediaATBRevisionID;
            }
            set
            {
                _MediaATBRevisionID = value;
            }
        }
        /// <summary>
        /// QueryString key: matbnum
        /// </summary>
        /// <returns>String</returns>
        public int MediaATBNumber
        {
            get
            {
                return _MediaATBNumber;
            }
            set
            {
                _MediaATBNumber = value;
            }
        }
        /// <summary>
        /// QueryString key: mon
        /// </summary>
        /// <returns>String</returns>
        public int MediaOrderNumber
        {
            get
            {
                return _MediaOrderNumber;
            }
            set
            {
                _MediaOrderNumber = value;
            }
        }
        /// <summary>
        /// QueryString key: moln
        /// </summary>
        /// <returns>String</returns>
        public int MediaOrderLineNumber
        {
            get
            {
                return _MediaOrderLineNumber;
            }
            set
            {
                _MediaOrderLineNumber = value;
            }
        }
        /// <summary>
        /// QueryString key: morn
        /// </summary>
        /// <returns>String</returns>
        public int MediaOrderRevisionNumber
        {
            get
            {
                return _MediaOrderRevisionNumber;
            }
            set
            {
                _MediaOrderRevisionNumber = value;
            }
        }
        /// <summary>
        /// QueryString key: morsn
        /// </summary>
        /// <returns>String</returns>
        public int MediaOrderSequenceNumber
        {
            get
            {
                return _MediaOrderSequenceNumber;
            }
            set
            {
                _MediaOrderSequenceNumber = value;
            }
        }
        /// <summary>
        /// QueryString key: matbrevid
        /// </summary>
        /// <returns>String</returns>
        public int MediaATBRevisionNumber
        {
            get
            {
                return _MediaATBRevisionNumber;
            }
            set
            {
                _MediaATBRevisionNumber = value;
            }
        }
        /// <summary>
        /// QueryString key: mt
        /// </summary>
        /// <returns>String</returns>
        public MediaOrderType MediaType
        {
            get
            {
                return _MediaType;
            }
            set
            {
                _MediaType = value;
            }
        }
        /// <summary>
        /// QueryString key: mso
        /// </summary>
        /// <returns>String</returns>
        public bool MilestonesOnly
        {
            get
            {
                return _MilestonesOnly;
            }
            set
            {
                _MilestonesOnly = value;
            }
        }
        /// <summary>
        /// QueryString key: mm
        /// </summary>
        /// <returns>String</returns>
        public int Month
        {
            get
            {
                return _Month;
            }
            set
            {
                _Month = value;
            }
        }
        /// <summary>
        /// QueryString key: o
        /// </summary>
        /// <returns>String</returns>
        public string OfficeCode
        {
            get
            {
                return _OfficeCode;
            }
            set
            {
                _OfficeCode = value;
            }
        }
        /// <summary>
        /// QueryString key: pf
        /// </summary>
        /// <returns>String</returns>
        public string PhaseFilter
        {
            get
            {
                return _PhaseFilter;
            }
            set
            {
                _PhaseFilter = value;
            }
        }
        /// <summary>
        /// QueryString key: po
        /// </summary>
        /// <returns>String</returns>
        public int PurchaseOrderNumber
        {
            get
            {
                return _PoNumber;
            }
            set
            {
                _PoNumber = value;
            }
        }
        /// <summary>
        /// QueryString key: pp
        /// </summary>
        /// <returns>String</returns>
        public string PostPeriod
        {
            get
            {
                return _PostPeriod;
            }
            set
            {
                _PostPeriod = value;
            }
        }
        /// <summary>
        /// QueryString key: p
        /// </summary>
        /// <returns>String</returns>
        public string ProductCode
        {
            get
            {
                return _PrdCode;
            }
            set
            {
                _PrdCode = value;
            }
        }
        /// <summary>
        /// QueryString key: pxrid
        /// </summary>
        /// <returns>String</returns>
        public int ProofingStatusExternalReviewerID
        {
            get
            {
                return _ProofingStatusExternalReviewerID;
            }
            set
            {
                _ProofingStatusExternalReviewerID = value;
            }
        }
        /// <summary>
        /// QueryString key: qty
        /// </summary>
        /// <returns>String</returns>
        public int Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                _Quantity = value;
            }
        }
        /// <summary>
        /// QueryString key: rv
        /// </summary>
        /// <returns>String</returns>
        public int RevisionID
        {
            get
            {
                return _RevisionId;
            }
            set
            {
                _RevisionId = value;
            }
        }
        /// <summary>
        /// QueryString key: rc
        /// </summary>
        /// <returns>String</returns>
        public string RoleCode
        {
            get
            {
                return _RoleCode;
            }
            set
            {
                _RoleCode = value;
            }
        }

        /// <summary>
        /// QueryString key: ri
        /// </summary>
        /// <returns>String</returns>
        public string RoomID
        {
            get
            {
                return _RoomId;
            }
            set
            {
                _RoomId = value;
            }
        }
        /// <summary>
        /// QueryString key: rn
        /// </summary>
        /// <returns>String</returns>
        public string RoomName
        {
            get
            {
                return _RoomName;
            }
            set
            {
                _RoomName = value;
            }
        }
        /// <summary>
        /// QueryString key: rsh
        /// </summary>
        /// <returns>String</returns>
        public bool Rush
        {
            get
            {
                return _Rush;
            }
            set
            {
                _Rush = value;
            }
        }
        /// <summary>
        /// QueryString key: sc
        /// </summary>
        /// <returns>String</returns>
        public string SalesClassCode
        {
            get
            {
                return _ScCode;
            }
            set
            {
                _ScCode = value;
            }
        }
        /// <summary>
        /// QueryString key: st
        /// </summary>
        /// <returns>String</returns>
        public string SearchText
        {
            get
            {
                return _SearchText;
            }
            set
            {
                _SearchText = value;
            }
        }
        /// <summary>
        /// QueryString key: skip
        /// </summary>
        /// <returns>Integer</returns>
        public int Skip
        {
            get
            {
                return _Skip;
            }
            set
            {
                _Skip = value;
            }
        }
        /// <summary>
        /// QueryString key: spid
        /// </summary>
        /// <returns>String</returns>
        public int SpecificationID
        {
            get
            {
                return _SpecId;
            }
            set
            {
                _SpecId = value;
            }
        }
        /// <summary>
        /// QueryString key: sprhid
        /// </summary>
        /// <returns>String</returns>
        public int SprintHeaderID
        {
            get
            {
                return _SprintHeaderID;
            }
            set
            {
                _SprintHeaderID = value;
            }
        }
        /// <summary>
        /// QueryString key: sprdid
        /// </summary>
        /// <returns>String</returns>
        public int SprintDetailID
        {
            get
            {
                return _SprintDetailID;
            }
            set
            {
                _SprintDetailID = value;
            }
        }
        /// <summary>
        /// QueryString key: sd
        /// </summary>
        /// <returns>String</returns>
        public string StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                _StartDate = value;
            }
        }
        /// <summary>
        /// QueryString key: take
        /// </summary>
        /// <returns>Integer</returns>
        public int Take
        {
            get
            {
                return _Take;
            }
            set
            {
                _Take = value;
            }
        }
        /// <summary>
        /// QueryString key: tc
        /// </summary>
        /// <returns>String</returns>
        public string TaskCode
        {
            get
            {
                return _TaskCode;
            }
            set
            {
                _TaskCode = value;
            }
        }
        /// <summary>
        /// QueryString key: s
        /// </summary>
        /// <returns>String</returns>
        public int TaskSequenceNumber
        {
            get
            {
                return _TaskSeqNbr;
            }
            set
            {
                _TaskSeqNbr = value;
            }
        }
        /// <summary>
        /// QueryString key: tt
        /// </summary>
        /// <returns>String</returns>
        public string TimeType
        {
            get
            {
                return _TimeType;
            }
            set
            {
                _TimeType = value;
            }
        }
        /// <summary>
        /// QueryString key: tsc
        /// </summary>
        /// <returns>String</returns>
        public string TrafficStatusCode
        {
            get
            {
                return _TrafficStatusCode;
            }
            set
            {
                _TrafficStatusCode = value;
            }
        }
        /// <summary>
        /// QueryString key: tsv
        /// </summary>
        /// <returns>String</returns>
        public int TrafficScheduleVersionID
        {
            get
            {
                return _TrafficScheduleVersionId;
            }
            set
            {
                _TrafficScheduleVersionId = value;
            }
        }
        /// <summary>
        /// QueryString key: usr
        /// </summary>
        /// <returns>String</returns>
        public string UserCode
        {
            get
            {
                return _UserCode;
            }
            set
            {
                _UserCode = value;
            }
        }
        /// <summary>
        /// QueryString key: vc
        /// </summary>
        /// <returns>String</returns>
        public string VendorCode
        {
            get
            {
                return _VendorCode;
            }
            set
            {
                _VendorCode = value;
            }
        }
        /// <summary>
        /// QueryString key: vid
        /// </summary>
        /// <returns>String</returns>
        public int VersionID
        {
            get
            {
                return _VersionId;
            }
            set
            {
                _VersionId = value;
            }
        }
        /// <summary>
        /// QueryString key: w
        /// </summary>
        /// <returns>String</returns>
        public int WorkspaceID
        {
            get
            {
                return _WorkspaceId;
            }
            set
            {
                _WorkspaceId = value;
            }
        }
        /// <summary>
        /// QueryString key: yyyy
        /// </summary>
        /// <returns>String</returns>
        public int Year
        {
            get
            {
                return _Year;
            }
            set
            {
                _Year = value;
            }
        }

        #endregion

        #region Methods

        //public QueryString FromString(string Value)
        //{
        //    QueryString qs = new QueryString();

        //    try
        //    {
        //        qs = FromUrl(Value);
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    return qs;
        //}
        //public QueryString FromCurrent(bool GetFromSession = false)
        //{
        //    string s = string.Empty;

        //    try
        //    {
        //        s = Request.GetEncodedUrl();
        //    }
        //    catch (Exception ex)
        //    {
        //        s = string.Empty;
        //    }

        //    if (string.IsNullOrWhiteSpace(s) == false)
        //        return this.FromString(s);
        //    else
        //        return null;
        //}

        static public QueryString FromEncrypted(string Encrypted)
        {
            QueryString rv = new QueryString();
            string r = rv.Decrypt(Encrypted);

            rv.Add("dl", r);

            NameValueCollection Values = HttpUtility.ParseQueryString(r);

            if (Values != null && Values.AllKeys.Count() > 0)
            {
                foreach (string Value in Values.AllKeys)
                {
                    string ThisKey = Value;

                    string ThisValue = Values[Value];

                    ThisValue = HttpUtility.UrlDecode(ThisValue);

                    rv._Collection.Add(ThisKey, ThisValue);
                    rv.ProcessKeyToValue(ThisKey, ThisValue);
                }
            }

            return rv;
        }


        public void FromString(string RequestURL)
        {

            this._RequestURL = RequestURL;

            if (this._RequestURL.Contains("?") == true)
            {
                System.Collections.Specialized.NameValueCollection Values = null; // System.Web.HttpUtility.ParseQueryString(parts(1))
                string[] parts;

                parts = this._RequestURL.Split("?");

                this.Page = parts[0];

                if (this._RequestURL.Contains("?dl=") == true)
                {
                    string[] s;
                    string Encrypted = string.Empty;
                    string r = string.Empty;

                    s = this._RequestURL.Split("?dl=");

                    Encrypted = s[1];

                    if (Encrypted.StartsWith("dl="))
                        Encrypted = Encrypted.Replace("dl=", "");

                    r = Decrypt(Encrypted);

                    this.Add("dl", r);

                    Values = System.Web.HttpUtility.ParseQueryString(r);
                }
                else
                    Values = System.Web.HttpUtility.ParseQueryString(parts[1]);
                if (Values != null && Values.AllKeys.Count() > 0)
                {
                    string ThisKey = string.Empty;
                    string ThisValue = string.Empty;

                    foreach (string Value in Values.AllKeys)
                    {
                        ThisKey = string.Empty;
                        ThisValue = string.Empty;

                        ThisKey = Value;
                        ThisValue = Values[Value];

                        ThisValue = HttpUtility.UrlDecode(ThisValue);

                        this._Collection.Add(ThisKey, ThisValue);
                        this.ProcessKeyToValue(ThisKey, ThisValue);

                    }
                }
            }
            else
                this.Page = this._RequestURL;

        }

        public string Encrypt(string s)
        {
            return AdvantageFramework.Core.StringUtilities.Methods.RijndaelSimpleEncrypt(s) + "A";
        }
        public string Decrypt(string s)
        {
            return AdvantageFramework.Core.StringUtilities.Methods.RijndaelSimpleDecrypt(s.Substring(0, s.Length - 1));
        }

        public void Add(string name, string value)
        {
            //what happens with duplicate key?
            this._Collection.Add(name, value);

        }
        public string GetValue(string keyValue)
        {
            try
            {
                string returnValue = string.Empty;

                string[] values = null;
                //foreach (string key in this._Collection)
                //{
                values = this._Collection.GetValues(keyValue);
                foreach (string value in values)
                {
                    returnValue = value;
                    break;
                }
                //}
                return returnValue;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        private void ProcessKeyToValue(string ThisKey, string ThisValue)
        {
            {
                switch (ThisKey?.ToLower()) // Keep the key alphabetical please
                {
                    case "a":
                    case "alertid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._AlertId = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "aamib":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._AamIncludeBacklog = this.FromInt(System.Convert.ToInt32(ThisValue));
                            break;
                        }

                    case "aamibl":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._AamIncludeBoardLevel = this.FromInt(System.Convert.ToInt32(ThisValue));
                            break;
                        }

                    case "aamgb":
                        {
                            this._AamGroupBy = ThisValue.ToString();
                            break;
                        }

                    case "aamic":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._AamIsCount = this.FromInt(System.Convert.ToInt32(ThisValue));
                            break;
                        }

                    case "aamica":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._AamIncludeCompletedAssignments = this.FromInt(System.Convert.ToInt32(ThisValue));
                            break;
                        }

                    case "aamijap":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._AamIsJobAlertsPage = this.FromInt(System.Convert.ToInt32(ThisValue));
                            break;
                        }

                    case "aamir":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._AamIncludeReviews = this.FromInt(System.Convert.ToInt32(ThisValue));
                            break;
                        }

                    case "aamit":
                        {
                            this._AamInboxType = ThisValue.ToString();
                            break;
                        }

                    case "aamrtr":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._AamRecordsToReturn = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "aamsat":
                        {
                            this._AamShowAssignmentType = ThisValue.ToString();
                            break;
                        }

                    case "ae":
                        {
                            this._AccountExecutiveCode = ThisValue.ToString();
                            break;
                        }

                    case "aid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._BillingApprovalId = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "ani":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._AlertNotifyHdrId = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "api":
                        {
                            this._APInvoice = ThisValue.ToString();
                            break;
                        }

                    case "apid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._APID = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "asi":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._AlertStateId = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "bid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._BillingApprovalBatchId = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "bm":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._IsBookmark = this.FromInt(System.Convert.ToInt32(ThisValue));
                            break;
                        }

                    case "brdid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._BoardID = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "brdhid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._BoardHeaderID = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "brdcid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._BoardColumnID = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "brddid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._BoardDetailID = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "brdstid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._BoardStateID = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "c" // , "cl", "cli", "client"
             :
                        {
                            this._ClCode = ThisValue.ToString();
                            break;
                        }

                    case "cid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._CmpIdentifier = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "cmp":
                    case "cmpcode":
                        {
                            this._CampaignCode = ThisValue.ToString();
                            break;
                        }

                    case "cod":
                        {
                            if (Information.IsDate(ThisValue) == true)
                                this._CutOffDate = Convert.ToDateTime(ThisValue).ToString();
                            break;
                        }

                    case "conid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._ContractId = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "conrptid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._ContractReportId = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "contaid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._ContentArea = (ContentAreaName)System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "crid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._ChatRoomId = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    //case "csbcsrt":
                    //    {
                    //        if (Information.IsNumeric(ThisValue))
                    //            this._ConceptShareBaseReviewType = (AdvantageFramework.Database.Entities.ConceptShareBaseReviewType)System.Convert.ToInt32(ThisValue);
                    //        break;
                    //    }

                    case "csaid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._ConceptShareAssetID = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "cscid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._ConceptShareCommentID = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "cspid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._ConceptShareProjectID = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "csrid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._ConceptShareReviewID = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "d" // , "div", "division "
             :
                        {
                            this._DivCode = ThisValue.ToString();
                            break;
                        }

                    case "dd":
                        {
                            if (Information.IsDate(ThisValue) == true)
                                this._DueDate = Convert.ToDateTime(ThisValue).ToString();
                            break;
                        }

                    case "dl":
                        {
                            this._DeepLink = ThisValue.ToString();
                            break;
                        }

                    case "doc":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._DocumentId = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "doclblid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._DocumentLabelId = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    //case "doclvl":
                    //    {
                    //        if (Information.IsNumeric(ThisValue))
                    //            this._DocumentLevel = (AdvantageFramework.Database.Entities.DocumentLevel)System.Convert.ToInt32(ThisValue);
                    //        break;
                    //    }

                    case "dtc":
                        {
                            this._DepartmentTeamCode = ThisValue.ToString();
                            break;
                        }

                    case "e":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._EstimateNumber = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "ec":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._EstComponentNbr = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "ed":
                        {
                            if (Information.IsDate(ThisValue) == true)
                                this._EndDate = Convert.ToDateTime(ThisValue).ToShortDateString();
                            break;
                        }

                    case "eg":
                        {
                            this._EmailGroup = ThisValue.ToString();
                            break;
                        }

                    case "emp":
                        {
                            this._EmpCode = ThisValue.ToString();
                            break;
                        }

                    case "en":
                        {
                            this._EmployeeName = ThisValue.ToString();
                            break;
                        }

                    case "ept":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._ExcludeProjectedTasks = this.FromInt(System.Convert.ToInt32(ThisValue));
                            break;
                        }

                    case "eq":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._EstQuoteNbr = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "er":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._EstRevNbr = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "etid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._EmployeeTimeId = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "etdid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._EmployeeTimeDetailId = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "etfod":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._EmployeeTimeForecastOfficeDetailId = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "evt":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._EventId = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "evtt":
                        {
                            this._EventTaskId = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "f":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._App = (Source_App)System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "fn":
                        {
                            this._FunctionCode = ThisValue;
                            break;
                        }

                    case "ics":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._IncludeCompletedSchedules = this.FromInt(System.Convert.ToInt32(ThisValue));
                            break;
                        }

                    case "ict":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._IncludeCompletedTasks = this.FromInt(System.Convert.ToInt32(ThisValue));
                            break;
                        }

                    case "ipt":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._IncludeOnlyPendingTasks = this.FromInt(System.Convert.ToInt32(ThisValue));
                            break;
                        }

                    case "inv":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._InvoiceNumber = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "invseq":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._InvoiceSeqNbr = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "j":
                    case "job":
                    case "jobnum":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._JobNumber = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "jc":
                    case "comp":
                    case "jobcomp":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._JobComponentNbr = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "jd":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._IsJobDashboard = this.FromInt(System.Convert.ToInt32(ThisValue));
                            break;
                        }

                    case "jvid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._JobVersionHdrId = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "jvs":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._JobVersionSeqNbr = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "locid":
                        {
                            if (string.IsNullOrWhiteSpace(ThisValue) == false)
                                this._LocationID = ThisValue;
                            break;
                        }

                    case "m":
                        {
                            this._ManagerCode = ThisValue.ToString();
                            break;
                        }

                    case "matbrevid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._MediaATBRevisionID = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "matbnum":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._MediaATBNumber = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "matbrevnum":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._MediaATBRevisionNumber = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "mm":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._Month = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "mon":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._MediaOrderNumber = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "moln":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._MediaOrderLineNumber = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "morn":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._MediaOrderRevisionNumber = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "morsn":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._MediaOrderSequenceNumber = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "mso":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._MilestonesOnly = this.FromInt(System.Convert.ToInt32(ThisValue));
                            break;
                        }

                    case "mt":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._MediaType = (MediaOrderType)System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "o" // , "office"
             :
                        {
                            this._OfficeCode = ThisValue.ToString();
                            break;
                        }

                    case "p" // , "prod", "product"
             :
                        {
                            this._PrdCode = ThisValue.ToString();
                            break;
                        }

                    case "pf":
                        {
                            this._PhaseFilter = ThisValue.ToString();
                            break;
                        }

                    case "po":
                        {
                            this._PoNumber = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "pp":
                        {
                            this._PostPeriod = ThisValue;
                            break;
                        }

                    case "pxrid":
                        {
                            this._ProofingStatusExternalReviewerID = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "qty":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._Quantity = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "rc":
                        {
                            this._RoleCode = ThisValue.ToString();
                            break;
                        }

                    case "ri":
                        {
                            this._RoomId = ThisValue.ToString();
                            break;
                        }

                    case "rn":
                        {
                            this._RoomName = ThisValue.ToString();
                            break;
                        }

                    case "rsh":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._Rush = this.FromInt(System.Convert.ToInt32(ThisValue));
                            break;
                        }

                    case "rv":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._RevisionId = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "s":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._TaskSeqNbr = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "sc":
                        {
                            this._ScCode = ThisValue;
                            break;
                        }

                    case "sd":
                        {
                            if (Information.IsDate(ThisValue) == true)
                                this._StartDate = Convert.ToDateTime(ThisValue).ToString();
                            break;
                        }

                    case "skip":
                        {
                            this._Skip = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "spid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._SpecId = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "sprhid":
                    case "sprintid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._SprintHeaderID = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "sprdid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._SprintDetailID = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "st":
                        {
                            this._SearchText = ThisValue.ToString();
                            break;
                        }

                    case "take":
                        {
                            this._Take = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "tc":
                        {
                            this._TaskCode = ThisValue.ToString();
                            break;
                        }

                    case "tsc":
                        {
                            this._TrafficStatusCode = ThisValue.ToString();
                            break;
                        }

                    case "tsv":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._TrafficScheduleVersionId = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "tt":
                        {
                            this._TimeType = ThisValue.ToString();
                            break;
                        }

                    case "usr":
                        {
                            this._UserCode = ThisValue.ToString();
                            break;
                        }

                    case "vc":
                        {
                            this._VendorCode = ThisValue.ToString();
                            break;
                        }

                    case "vid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._VersionId = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "w":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._WorkspaceId = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "xid":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._ExpenseId = System.Convert.ToInt32(ThisValue);
                            break;
                        }

                    case "xx3":
                        {
                            if (string.IsNullOrWhiteSpace(ThisValue) == false)
                                this._UserCode = ThisValue;
                            break;
                        }

                    case "xx5":
                        {
                            if (Information.IsDate(ThisValue) == true)
                                this._ApiDate = System.Convert.ToDateTime(ThisValue);
                            break;
                        }

                    case "xx6":
                        {
                            if (string.IsNullOrWhiteSpace(ThisValue) == false)
                                this._ConnectionString = ThisValue;
                            break;
                        }

                    case "yyyy":
                        {
                            if (Information.IsNumeric(ThisValue))
                                this._Year = System.Convert.ToInt32(ThisValue);
                            break;
                        }
                }
            }
        }
        public void RemoveAllKeys()
        {
            String[] AllQuerystringKeys;
            int i = 0;
            AllQuerystringKeys = this._Collection.AllKeys;
            while (i < AllQuerystringKeys.Length)
            {
                this._Collection.Remove(AllQuerystringKeys[i]);
                i += 1;
            }
        }
        private void AddProperties()
        {
            // keep the key alphabetical please and as short as possible
            // Starts with  "xx" is for encrypted conn info
            if (this._AlertId > 0)
                this._Collection.Add("a", this._AlertId.ToString());
            if (string.IsNullOrWhiteSpace(this._AamInboxType.Trim()) == false)
                this._Collection.Add("aamit", this._AamInboxType.Trim());
            if (this._AamIncludeCompletedAssignments == true)
                this._Collection.Add("aamica", this.ToInt(this._AamIncludeCompletedAssignments).ToString());
            if (string.IsNullOrWhiteSpace(this._AamGroupBy.Trim()) == false)
                this._Collection.Add("aamgb", this._AamGroupBy.ToString());
            if (this._AamIncludeBacklog == true)
                this._Collection.Add("aamib", this.ToInt(this._AamIncludeBacklog).ToString());
            if (this._AamIncludeBoardLevel == true)
                this._Collection.Add("aamibl", this.ToInt(this._AamIncludeBoardLevel).ToString());
            if (this._AamIsCount == true)
                this._Collection.Add("aamic", this.ToInt(this._AamIsCount).ToString());
            if (this._AamIsJobAlertsPage == true)
                this._Collection.Add("aamijap", this.ToInt(this._AamIsJobAlertsPage).ToString());
            if (this._AamIncludeReviews == true)
                this._Collection.Add("aamir", this.ToInt(this._AamIncludeReviews).ToString());
            if (this._AamRecordsToReturn > 0)
                this._Collection.Add("aamrtr", this._AamRecordsToReturn.ToString());
            if (string.IsNullOrWhiteSpace(this._AamShowAssignmentType.Trim()) == false)
                this._Collection.Add("aamsat", this._AamShowAssignmentType.ToString());
            if (string.IsNullOrWhiteSpace(this._AccountExecutiveCode.Trim()) == false)
                this._Collection.Add("ae", this._AccountExecutiveCode.Trim());
            if (this._BillingApprovalId > 0)
                this._Collection.Add("aid", this._BillingApprovalId.ToString());
            if (this._AlertNotifyHdrId > 0)
                this._Collection.Add("ani", this._AlertNotifyHdrId.ToString());
            if (string.IsNullOrWhiteSpace(this._APInvoice.Trim()) == false)
                this._Collection.Add("api", this._APInvoice.ToString());
            if (this._APID > 0)
                this._Collection.Add("apid", this._APID.ToString());
            if (this._AlertStateId > 0)
                this._Collection.Add("asi", this._AlertStateId.ToString());
            if (this._BillingApprovalBatchId > 0)
                this._Collection.Add("bid", this._BillingApprovalBatchId.ToString());
            if (this._IsBookmark == true)
                this._Collection.Add("bm", this.ToInt(this._IsBookmark).ToString());
            if (this._BoardID > 0)
                this._Collection.Add("brdid", this._BoardID.ToString());
            if (this._BoardHeaderID > 0)
                this._Collection.Add("brdhid", this._BoardHeaderID.ToString());
            if (this._BoardColumnID > 0)
                this._Collection.Add("brdcid", this._BoardColumnID.ToString());
            if (this._BoardDetailID > 0)
                this._Collection.Add("brddid", this._BoardDetailID.ToString());
            if (this._BoardDetailID > 0)
                this._Collection.Add("brdstid", this._BoardStateID.ToString());
            if (string.IsNullOrWhiteSpace(this._ClCode.Trim()) == false)
                this._Collection.Add("c", this._ClCode.Trim());
            if (this._CmpIdentifier > 0)
                this._Collection.Add("cid", this._CmpIdentifier.ToString());
            if (string.IsNullOrWhiteSpace(this._CampaignCode.Trim()) == false)
                this._Collection.Add("cmp", this._CampaignCode.Trim());
            if (string.IsNullOrWhiteSpace(this._CutOffDate.Trim()) == false)
            {
                if (Information.IsDate(this._CutOffDate) == true)
                    this._Collection.Add("cod", Convert.ToDateTime(this._CutOffDate).ToShortDateString());
            }
            // If String.IsNullOrWhiteSpace(Me._ConnString.Trim()) = False Then

            // Me.Add("con", Me._ConnString.Trim())

            // End If
            if (this._ContractId > 0)
                this._Collection.Add("conid", this._ContractId.ToString());
            if (this._ContractReportId > 0)
                this._Collection.Add("conrptid", this._ContractReportId.ToString());
            if (this._ContentArea > 0)
                this._Collection.Add("contaid", System.Convert.ToInt32(this._ContentArea).ToString());
            if (this._ChatRoomId > 0)
                this._Collection.Add("crid", this._ChatRoomId.ToString());
            //if (!this._ConceptShareBaseReviewType == null/* TODO Change to default(_) if this is not a reference type */ )
            //    this._Collection.Add("csbcsrt", System.Convert.ToInt32(this._ConceptShareBaseReviewType).ToString());
            if (this._ConceptShareAssetID > 0)
                this._Collection.Add("csaid", this._ConceptShareAssetID.ToString());
            if (this._ConceptShareCommentID > 0)
                this._Collection.Add("cscid", this._ConceptShareCommentID.ToString());
            if (this._ConceptShareProjectID > 0)
                this._Collection.Add("cspid", this._ConceptShareProjectID.ToString());
            if (this._ConceptShareReviewID > 0)
                this._Collection.Add("csrid", this._ConceptShareReviewID.ToString());
            if (string.IsNullOrWhiteSpace(this._DivCode.Trim()) == false)
                this._Collection.Add("d", this._DivCode.Trim());
            if (string.IsNullOrWhiteSpace(this._DueDate.Trim()) == false)
            {
                if (Information.IsDate(this._DueDate) == true)
                    this._Collection.Add("dd", Convert.ToDateTime(this._DueDate).ToShortDateString());
            }
            if (string.IsNullOrWhiteSpace(this._DeepLink.Trim()) == false)
                this._Collection.Add("dl", this._DeepLink.Trim());
            if (this._DocumentId > 0)
                this._Collection.Add("doc", this._DocumentId.ToString());
            if (this._DocumentLabelId > 0)
                this._Collection.Add("doclblid", this._DocumentLabelId.ToString());
            //if (!this._DocumentLevel == null/* TODO Change to default(_) if this is not a reference type */ )
            //    this._Collection.Add("doclvl", System.Convert.ToInt32(this._DocumentLevel).ToString());
            if (string.IsNullOrWhiteSpace(this._DepartmentTeamCode.Trim()) == false)
                this._Collection.Add("dtc", this._DepartmentTeamCode.Trim());
            if (this._EstimateNumber > 0)
                this._Collection.Add("e", this._EstimateNumber.ToString());
            if (this._EstComponentNbr > 0)
                this._Collection.Add("ec", this._EstComponentNbr.ToString());
            if (string.IsNullOrWhiteSpace(this._EndDate.Trim()) == false)
            {
                if (Information.IsDate(this._EndDate) == true)
                    this._Collection.Add("ed", Convert.ToDateTime(this._EndDate).ToShortDateString());
            }
            if (string.IsNullOrWhiteSpace(this._EmailGroup.Trim()) == false)
                this._Collection.Add("eg", this._EmailGroup.Trim());
            if (string.IsNullOrWhiteSpace(this._EmpCode.Trim()) == false)
                this._Collection.Add("emp", this._EmpCode.Trim());
            if (string.IsNullOrWhiteSpace(this._EmployeeName.Trim()) == false)
                this._Collection.Add("en", this._EmployeeName.Trim());
            if (this._ExcludeProjectedTasks == true)
                this._Collection.Add("ept", this.ToInt(this._ExcludeProjectedTasks).ToString());
            if (this._EstQuoteNbr > 0)
                this._Collection.Add("eq", this._EstQuoteNbr.ToString());
            if (this._EstRevNbr > 0)
                this._Collection.Add("er", this._EstRevNbr.ToString());
            if (this._EmployeeTimeId > 0)
                this._Collection.Add("etid", this._EmployeeTimeId.ToString());
            if (this._EmployeeTimeDetailId > 0)
                this._Collection.Add("etdid", this._EmployeeTimeDetailId.ToString());
            if (this._EmployeeTimeForecastOfficeDetailId > 0)
                this._Collection.Add("etfod", this._EmployeeTimeForecastOfficeDetailId.ToString());
            if (this._EventId > 0)
                this._Collection.Add("evt", this._EventId.ToString());
            if (this._EventTaskId > 0)
                this._Collection.Add("evtt", this._EventTaskId.ToString());
            //if (!_App == default(Integer))
            //    this._Collection.Add("f", System.Convert.ToInt32(this._App).ToString());
            if (string.IsNullOrWhiteSpace(this._FunctionCode.Trim()) == false)
                this._Collection.Add("fn", this._FunctionCode.Trim());
            if (this._IncludeCompletedSchedules == true)
                this._Collection.Add("ics", this.ToInt(this._IncludeCompletedSchedules).ToString());
            if (this._IncludeCompletedTasks == true)
                this._Collection.Add("ict", this.ToInt(this._IncludeCompletedTasks).ToString());
            if (this._IncludeOnlyPendingTasks == true)
                this._Collection.Add("ipt", this.ToInt(this._IncludeOnlyPendingTasks).ToString());
            if (this._InvoiceNumber > 0)
                this._Collection.Add("inv", this._InvoiceNumber.ToString());
            if (this._InvoiceSeqNbr > -1)
                this._Collection.Add("invseq", this._InvoiceSeqNbr.ToString());
            if (this._JobNumber > 0)
                this._Collection.Add("j", this._JobNumber.ToString());
            if (this._JobComponentNbr > 0)
                this._Collection.Add("jc", this._JobComponentNbr.ToString());
            if (this._IsJobDashboard == true)
                this._Collection.Add("jd", this.ToInt(this._IsJobDashboard).ToString());
            if (this._JobVersionHdrId > 0)
                this._Collection.Add("jvid", this._JobVersionHdrId.ToString());
            if (this._JobVersionSeqNbr > 0)
                this._Collection.Add("jvs", this._JobVersionSeqNbr.ToString());
            if (string.IsNullOrWhiteSpace(this._LocationID) == false)
                this._Collection.Add("locid", this._LocationID.Trim());
            if (string.IsNullOrWhiteSpace(this._ManagerCode.Trim()) == false)
                this._Collection.Add("m", this._ManagerCode.Trim());
            if (this._MediaATBRevisionID > 0)
                this._Collection.Add("matbrevid", this._MediaATBRevisionID.ToString());
            if (this._MediaATBNumber > 0)
                this._Collection.Add("matbnum", this._MediaATBNumber.ToString());
            if (this._MediaATBRevisionNumber > 0)
                this._Collection.Add("matbrevnum", this._MediaATBRevisionNumber.ToString());
            if (this._Month > 0)
                this._Collection.Add("mm", this._Month.ToString());
            if (this._MediaOrderNumber > 0)
                this._Collection.Add("mon", this._MediaOrderNumber.ToString());
            if (this._MediaOrderLineNumber > 0)
                this._Collection.Add("moln", this._MediaOrderLineNumber.ToString());
            if (this._MediaOrderRevisionNumber > 0)
                this._Collection.Add("morn", this._MediaOrderRevisionNumber.ToString());
            if (this._MediaOrderSequenceNumber > 0)
                this._Collection.Add("morsn", this._MediaOrderSequenceNumber.ToString());
            if (this._MilestonesOnly == true)
                this._Collection.Add("mso", this.ToInt(this._MilestonesOnly).ToString());
            //if (_MediaType.ToString != "")
            //    this._Collection.Add("mt", System.Convert.ToInt32(this._MediaType).ToString());
            if (string.IsNullOrWhiteSpace(this._OfficeCode.Trim()) == false)
                this._Collection.Add("o", this._OfficeCode.Trim());
            if (string.IsNullOrWhiteSpace(this._PrdCode.Trim()) == false)
                this._Collection.Add("p", this._PrdCode.Trim());
            if (string.IsNullOrWhiteSpace(this._PhaseFilter.Trim()) == false)
                this._Collection.Add("pf", this._PhaseFilter.Trim());
            if (this._PoNumber > 0)
                this._Collection.Add("po", this._PoNumber.ToString());
            if (string.IsNullOrWhiteSpace(this._PostPeriod.Trim()) == false)
                this._Collection.Add("pp", this._PostPeriod.Trim());
            if (this._ProofingStatusExternalReviewerID > 0)
                this._Collection.Add("pxrid", this._ProofingStatusExternalReviewerID.ToString());
            if (this._Quantity > 0)
                this._Collection.Add("qty", this._Quantity.ToString());
            if (string.IsNullOrWhiteSpace(this._RoleCode.Trim()) == false)
                this._Collection.Add("rc", this._RoleCode.Trim());
            if (string.IsNullOrWhiteSpace(this._RoomId.Trim()) == false)
                this._Collection.Add("ri", this._RoomId.Trim());
            if (string.IsNullOrWhiteSpace(this._RoomName.Trim()) == false)
                this._Collection.Add("rn", this._RoomName.Trim());
            if (this._Rush == true)
                this._Collection.Add("rsh", this.ToInt(this._Rush).ToString());
            if (this._RevisionId > 0)
                this._Collection.Add("rv", this._RevisionId.ToString());
            if (this._TaskSeqNbr > -1)
                this._Collection.Add("s", this._TaskSeqNbr.ToString());
            if (string.IsNullOrWhiteSpace(this._ScCode.Trim()) == false)
                this._Collection.Add("sc", this._ScCode.Trim());
            if (string.IsNullOrWhiteSpace(this._StartDate.Trim()) == false)
            {
                if (Information.IsDate(this._StartDate) == true)
                    this._Collection.Add("sd", Convert.ToDateTime(this._StartDate).ToShortDateString());
            }
            if (this._Skip > 0)
                this._Collection.Add("skip", this._Skip.ToString());
            if (this._SpecId > 0)
                this._Collection.Add("spid", this._SpecId.ToString());
            if (this._SprintHeaderID > 0)
                this._Collection.Add("sprhid", this._SprintHeaderID.ToString());
            if (this._SprintDetailID > 0)
                this._Collection.Add("sprdid", this._SprintDetailID.ToString());
            if (this._IsSession == true)
                this._Collection.Add("SSSN", this.ToInt(this._IsSession).ToString());
            if (string.IsNullOrWhiteSpace(this._SearchText.Trim()) == false)
                this._Collection.Add("st", this._SearchText.Trim());
            if (this._Take > 0)
                this._Collection.Add("take", this._Take.ToString());
            if (string.IsNullOrWhiteSpace(this._TaskCode.Trim()) == false)
                this._Collection.Add("tc", this._TaskCode.Trim());
            if (string.IsNullOrWhiteSpace(this._TrafficStatusCode.Trim()) == false)
                this._Collection.Add("tsc", this._TrafficStatusCode.Trim());
            if (this._TrafficScheduleVersionId > -1)
                this._Collection.Add("tsv", this._TrafficScheduleVersionId.ToString());
            if (string.IsNullOrWhiteSpace(this._TimeType.Trim()) == false)
                this._Collection.Add("tt", this._TimeType.Trim());
            if (string.IsNullOrWhiteSpace(this._UserCode.Trim()) == false)
                this._Collection.Add("usr", this._UserCode.Trim());
            if (string.IsNullOrWhiteSpace(this._VendorCode.Trim()) == false)
                this._Collection.Add("vc", this._VendorCode.ToString());
            if (this._VersionId > 0)
                this._Collection.Add("vid", this._VersionId.ToString());
            if (this._WorkspaceId > 0)
                this._Collection.Add("w", this._WorkspaceId.ToString());
            if (this._ExpenseId > 0)
                this._Collection.Add("xid", this._ExpenseId.ToString());
            if (this._Year > 0)
                this._Collection.Add("yyyy", this._Year.ToString());
        }

        public override string ToString()
        {
            return ToString(true);
        }

        public string ToString(bool IncludePage)
        {

            this.AddProperties();

            string url = string.Empty;
            string[] values = null;

            foreach (string key in this._Collection.Keys)
            {
                values = this._Collection.GetValues(key);
                foreach (string value in values)
                {
                    url += key + "=" + HttpUtility.UrlEncode(value) + "&";
                }
            }
            if (url.EndsWith("&") == true)
            {
                url = url.Substring(0, url.Length - 1);
            }

            //optionally encrypt, always use key "dl" (?)

            if (this._HasConnectionString == false)
            {
                if (string.IsNullOrWhiteSpace(url) == false && url.StartsWith("?") == false)
                    url = "?" + url;
                if (IncludePage)
                    url = this._Page + url;
            }  else
            {
                url = this._Page + "?dl=" + AdvantageFramework.Core.Web.Methods.EncryptDeepLinkQueryString(url);
            }
            //TODO:  else
            //using (var SecurityDbContext = new AdvantageFramework.Security.Database.DbContext(this._AdminConnectionString, this._AdminUserCode))
            //{
            //    string ApiURL = string.Empty;

            //    try
            //    {
            //        ApiURL = SecurityDbContext.Database.SqlQuery<string>("SELECT LICENSE_KEY FROM AGENCY WITH(NOLOCK);").SingleOrDefault;
            //    }
            //    catch (Exception ex)
            //    {
            //        ApiURL = string.Empty;
            //    }

            //    if (string.IsNullOrWhiteSpace(ApiURL) == false)
            //    {

            //        // Make sure only one slash between domain and action
            //        if (ApiURL.EndsWith("/") == false)
            //            ApiURL += "/";
            //        if (this._Page.StartsWith("/") == true)
            //            this._Page = this._Page.Substring(1, this._Page.Length - 1);

            //        url = ApiURL + this._Page + "?dl=" + AdvantageFramework.Web.EncryptDeepLinkQueryString(url);
            //    }
            //}

            return url;
        }
        private int ToInt(bool @bool)
        {
            if (@bool == true)
                return 1;
            else
                return 0;
        }
        private bool FromInt(int @int)
        {
            if (@int == 1)
                return true;
            else
                return false;
        }

        #endregion

        public QueryString()
        {
            this._Collection = new NameValueCollection();
        }

        /// <summary>
        ///     Instantiate with SecuritySession to include the connectionstring and force encryption
        /// </summary>
        public QueryString(string ConnectionString, string UserCode, string Password)
        {
            this._Collection = new NameValueCollection();

            this._AdminConnectionString = ConnectionString;
            this._AdminUserCode = UserCode;
            this._AdminPassword = Password;

            // 'Add connection string info
            // Me.Add("xx1", Me._ServerName)
            // Me.Add("xx2", Me._DatabaseName)
            this.Add("xx3", this._UserCode);
            // Me.Add("xx4", Me._Password)

            //// Add expiry info
            //this.Add("xx5", DateTime.Now.ToString());

            // Add admin conn
            this.Add("xx6", this._AdminConnectionString);

            this._HasConnectionString = true;

        }
    }
}
