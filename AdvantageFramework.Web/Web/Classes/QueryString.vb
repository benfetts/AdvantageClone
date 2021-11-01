Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.Configuration
Imports System.Web.UI
Imports System.IO
Imports System.Collections.Specialized
Imports System.Collections
Imports System.Xml
Imports System.Text
Imports System.Security.Cryptography
Imports System.Globalization
Imports System.Web.SessionState
Imports System.Web.HttpUtility
Imports System.Text.RegularExpressions

Namespace Web

    ''' <summary>
    '''Internet Explorer 5 -8 has url limit of 2,083 chars !!!!!!!!!!!
    '''Need to handle this....if over limit, send QS to session???
    '''  STEPS TO ADD
    '''  1.  Add Private Property
    '''  2.  Add Public Property
    '''  3.  Add to Build function
    '''  4.  Add to FromURL function    
    ''' 
    ''' </summary>
    ''' 
    <Serializable()> Public Class QueryStringOld
        Inherits NameValueCollection

#Region " Constants "



#End Region

#Region " Enum "

        'pass the int using "f" for the querysting variable
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
        Public Enum PageName

            Alert_Inbox
            TrafficSchedule_Search

        End Enum
        Public Enum LookupType

            Office
            Client
            Division
            Product
            JobNumber
            JobComponentNbr

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

        Public ObfuscateQS As Boolean = False
        Private mQuerystring As QueryStringOld

#End Region

#Region " Properties "

        Private mConnString As String = ""
        Private mPage As String = ""

        Private mApp As Source_App = Nothing
        Private mIsSession As Boolean = False

        Private mAlertId As Integer = 0
        Private mAlertNotifyHdrId As Integer = 0
        Private mAlertStateId As Integer = 0
        Private mAccountExecutiveCode As String = ""
        Private mAPInvoice As String = ""
        Private mAPID As Integer = 0
        Private mBillingApprovalBatchId As Integer = 0
        Private mBillingApprovalId As Integer = 0
        Private mBoardID As Integer = 0
        Private mBoardHeaderID As Integer = 0
        Private mBoardColumnID As Integer = 0
        Private mBoardDetailID As Integer = 0
        Private mBoardStateID As Integer = 0
        Private mCampaignCode As String = ""
        Private mChatRoomId As Integer = 0
        Private mClCode As String = ""
        Private mCmpIdentifier As Integer = 0
        Private mContentArea As ContentAreaName = ContentAreaName.None
        Private mContractId As Integer = 0
        Private mContractReportId As Integer = 0
        Private mCutOffDate As String = ""
        Private mDeepLink As String = ""
        Private mDepartmentTeamCode As String = ""
        Private mDivCode As String = ""
        Private mDocumentId As Integer = 0
        Private mDocumentLabelId As Integer = 0
        Private mDueDate As String = ""
        Private mEmailGroup As String = ""
        Private mEmpCode As String = ""
        Private mEmployeeName As String = ""
        Private mEmployeeTimeId As Integer = 0
        Private mEmployeeTimeDetailId As Integer = 0
        Private mEmployeeTimeForecastOfficeDetailId As Integer = 0
        Private mEndDate As String = ""
        Private mEstComponentNbr As Integer = 0
        Private mEstimateNumber As Integer = 0
        Private mEstQuoteNbr As Integer = 0
        Private mEstRevNbr As Integer = 0
        Private mEventId As Integer = 0
        Private mEventTaskId As Integer = 0
        Private mExcludeProjectedTasks As Boolean = False
        Private mExpenseId As Integer = 0
        Private mFunctionCode As String = ""
        Private mIncludeCompletedSchedules As Boolean = False
        Private mIncludeCompletedTasks As Boolean = False
        Private mIncludeOnlyPendingTasks As Boolean = False
        Private mInvoiceNumber As Integer = 0
        Private mInvoiceSeqNbr As Integer = -1
        Private mIsBookmark As Boolean = False
        Private mIsJobDashboard As Boolean = False
        Private mJobComponentNbr As Integer = 0
        Private mJobNumber As Integer = 0
        Private mJobVersionHdrId As Integer = 0
        Private mJobVersionSeqNbr As Integer = 0
        Private mManagerCode As String = ""
        Private mMediaATBRevisionID As Integer = 0
        Private mMediaATBNumber As Integer = 0
        Private mMediaATBRevisionNumber As Integer = 0
        Private mMediaOrderNumber As Integer = 0
        Private mMediaOrderLineNumber As Integer = 0
        Private mMediaOrderRevisionNumber As Integer = 0
        Private mMediaOrderSequenceNumber As Integer = 0
        Private mMediaType As MediaOrderType = MediaOrderType.None
        Private mMilestonesOnly As Boolean = False
        Private mMonth As Integer = 0
        Private mOfficeCode As String = ""
        Private mPhaseFilter As String = ""
        Private mPoNumber As Integer = 0
        Private mPostPeriod As String = ""
        Private mPrdCode As String = ""
        Private mQuantity As Decimal = 0.0
        Private mRevisionId As Integer = 0
        Private mRoleCode As String = ""
        Private mRoomId As String = ""
        Private mRoomName As String = ""
        Private mRush As Boolean = False
        Private mScCode As String = ""
        Private mSearchText As String = ""
        Private mSkip As Integer = 0
        Private mSpecId As Integer = 0
        Private mSprintHeaderID As Integer = 0
        Private mSprintDetailID As Integer = 0
        Private mStartDate As String = ""
        Private mTake As Integer = 0
        Private mTaskCode As String = ""
        Private mTaskSeqNbr As Integer = -1
        Private mTimeType As String = ""
        Private mTrafficStatusCode As String = ""
        Private mTrafficScheduleVersionId As Integer = -1
        Private mUserCode As String = ""
        Private mVendorCode As String = ""
        Private mVersionId As Integer = 0
        Private mWorkspaceId As Integer = 0
        Private mYear As Integer = 0
        Private mDocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel = Nothing
        Private mApiDate As DateTime? = Nothing
        Private mAamGroupBy As String = String.Empty
        Private mAamInboxType As String = String.Empty
        Private mAamIncludeBacklog As Boolean = False
        Private mAamIncludeBoardLevel As Boolean = False
        Private mAamIncludeCompletedAssignments As Boolean = False
        Private mAamIncludeReviews As Boolean = False
        Private mAamIsCount As Boolean = False
        Private mAamIsJobAlertsPage As Boolean = False
        Private mAamRecordsToReturn As Integer = 0
        Private mAamShowAssignmentType As String = String.Empty
        Private mLocationID As String = String.Empty

        Private mConnectionString As String = String.Empty

        Private mConceptShareBaseReviewType As AdvantageFramework.Database.Entities.ConceptShareBaseReviewType = Nothing
        Private mConceptShareProjectID As Integer = 0
        Private mConceptShareReviewID As Integer = 0
        Private mConceptShareAssetID As Integer = 0
        Private mConceptShareCommentID As Integer = 0

        ''' <summary>
        ''' QueryString key: con
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ConnString As String
            Get
                Return mConnString
            End Get
            Set(ByVal Value As String)
                mConnString = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: N/A
        ''' </summary>
        ''' <returns>String</returns>
        Public Property Page() As String
            Get
                Return mPage
            End Get
            Set(ByVal value As String)
                mPage = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: f
        ''' </summary>
        ''' <returns>String</returns>
        Public Property App As Source_App
            Get
                Return mApp
            End Get
            Set(ByVal Value As Source_App)
                mApp = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: SSSN
        ''' </summary>
        ''' <returns>String</returns>
        Public Property IsSession As Boolean
            Get
                Return mIsSession
            End Get
            Set(ByVal Value As Boolean)
                mIsSession = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: a
        ''' </summary>
        ''' <returns>String</returns>
        Public Property AlertId As Integer
            Get
                Return mAlertId
            End Get
            Set(ByVal Value As Integer)
                mAlertId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: ani
        ''' </summary>
        ''' <returns>String</returns>
        Public Property AlertTemplateID As Integer
            Get
                Return mAlertNotifyHdrId
            End Get
            Set(ByVal Value As Integer)
                mAlertNotifyHdrId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: asi
        ''' </summary>
        ''' <returns>String</returns>
        Public Property AlertStateId As Integer
            Get
                Return mAlertStateId
            End Get
            Set(ByVal Value As Integer)
                mAlertStateId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: ae
        ''' </summary>
        ''' <returns>String</returns>
        Public Property AccountExecutiveCode As String
            Get
                Return mAccountExecutiveCode
            End Get
            Set(ByVal Value As String)
                mAccountExecutiveCode = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: api
        ''' </summary>
        ''' <returns>String</returns>
        Public Property APInvoice As String
            Get
                Return mAPInvoice
            End Get
            Set(value As String)
                mAPInvoice = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: apid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property APID As Integer
            Get
                Return mAPID
            End Get
            Set(value As Integer)
                mAPID = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: bid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property BillingApprovalBatchId As Integer
            Get
                Return mBillingApprovalBatchId
            End Get
            Set(ByVal Value As Integer)
                mBillingApprovalBatchId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: aid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property BillingApprovalId As Integer
            Get
                Return mBillingApprovalId
            End Get
            Set(ByVal Value As Integer)
                mBillingApprovalId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: brdid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property BoardID As Integer
            Get
                Return mBoardID
            End Get
            Set(ByVal Value As Integer)
                mBoardID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: brdhid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property BoardHeaderID As Integer
            Get
                Return mBoardHeaderID
            End Get
            Set(ByVal Value As Integer)
                mBoardHeaderID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: brdcid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property BoardColumnID As Integer
            Get
                Return mBoardColumnID
            End Get
            Set(ByVal Value As Integer)
                mBoardColumnID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: brdcid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property BoardDetailID As Integer
            Get
                Return mBoardDetailID
            End Get
            Set(ByVal Value As Integer)
                mBoardDetailID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: brdstid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property BoardStateID As Integer
            Get
                Return mBoardStateID
            End Get
            Set(ByVal Value As Integer)
                mBoardStateID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: cmp
        ''' </summary>
        ''' <returns>String</returns>
        Public Property CampaignCode As String
            Get
                Return mCampaignCode
            End Get
            Set(ByVal Value As String)
                mCampaignCode = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: crid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ChatRoomId As Integer
            Get
                Return mChatRoomId
            End Get
            Set(ByVal Value As Integer)
                mChatRoomId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: c
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ClientCode() As String
            Get
                Return mClCode
            End Get
            Set(ByVal value As String)
                mClCode = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: cid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property CampaignIdentifier As Integer
            Get
                Return mCmpIdentifier
            End Get
            Set(ByVal Value As Integer)
                mCmpIdentifier = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: contaid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ContentArea As ContentAreaName
            Get
                Return mContentArea
            End Get
            Set(ByVal Value As ContentAreaName)
                mContentArea = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: conid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ContractId As Integer
            Get
                Return mContractId
            End Get
            Set(ByVal Value As Integer)
                mContractId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: cod
        ''' </summary>
        ''' <returns>String</returns>
        Public Property CutOffDate As String
            Get
                Return mCutOffDate
            End Get
            Set(ByVal Value As String)
                mCutOffDate = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: dl
        ''' </summary>
        ''' <returns>String</returns>
        Public Property DeepLink() As String
            Get
                Return mDeepLink
            End Get
            Set(ByVal value As String)
                mDeepLink = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: dtc
        ''' </summary>
        ''' <returns>String</returns>
        Public Property DepartmentTeamCode() As String
            Get
                Return mDepartmentTeamCode
            End Get
            Set(ByVal value As String)
                mDepartmentTeamCode = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: d
        ''' </summary>
        ''' <returns>String</returns>
        Public Property DivisionCode() As String
            Get
                Return mDivCode
            End Get
            Set(ByVal value As String)
                mDivCode = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: doc
        ''' </summary>
        ''' <returns>String</returns>
        Public Property DocumentId As Integer
            Get
                Return mDocumentId
            End Get
            Set(ByVal Value As Integer)
                mDocumentId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: doclblid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property DocumentLabelId As Integer
            Get
                Return mDocumentLabelId
            End Get
            Set(ByVal Value As Integer)
                mDocumentLabelId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: dd
        ''' </summary>
        ''' <returns>String</returns>
        Public Property DueDate As String
            Get
                Return mDueDate
            End Get
            Set(ByVal Value As String)
                mDueDate = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: eg
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EmailGroup As String
            Get
                Return mEmailGroup
            End Get
            Set(ByVal Value As String)
                mEmailGroup = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: emp
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EmployeeCode As String
            Get
                Return mEmpCode
            End Get
            Set(ByVal Value As String)
                mEmpCode = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: en
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EmployeeName As String
            Get
                Return mEmployeeName
            End Get
            Set(ByVal Value As String)
                mEmployeeName = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: etid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EmployeeTimeId As Integer
            Get
                Return mEmployeeTimeId
            End Get
            Set(ByVal Value As Integer)
                mEmployeeTimeId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: etdid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EmployeeTimeDetailId As Integer
            Get
                Return mEmployeeTimeDetailId
            End Get
            Set(ByVal Value As Integer)
                mEmployeeTimeDetailId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: etfod
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EmployeeTimeForecastOfficeDetailId As Integer
            Get
                Return mEmployeeTimeForecastOfficeDetailId
            End Get
            Set(ByVal Value As Integer)
                mEmployeeTimeForecastOfficeDetailId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: ed
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EndDate As String
            Get
                Return mEndDate
            End Get
            Set(ByVal Value As String)
                mEndDate = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: ec
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EstimateComponentNumber As Integer
            Get
                Return mEstComponentNbr
            End Get
            Set(ByVal Value As Integer)
                mEstComponentNbr = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: e
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EstimateNumber As Integer
            Get
                Return mEstimateNumber
            End Get
            Set(ByVal Value As Integer)
                mEstimateNumber = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: eq
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EstimateQuoteNumber As Integer
            Get
                Return mEstQuoteNbr
            End Get
            Set(ByVal Value As Integer)
                mEstQuoteNbr = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: er
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EstimateRevisionNumber As Integer
            Get
                Return mEstRevNbr
            End Get
            Set(ByVal Value As Integer)
                mEstRevNbr = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: evt
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EventId() As Integer
            Get
                Return mEventId
            End Get
            Set(ByVal value As Integer)
                mEventId = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: evtt
        ''' </summary>
        ''' <returns>String</returns>
        Public Property EventTaskId() As Integer
            Get
                Return mEventTaskId
            End Get
            Set(ByVal value As Integer)
                mEventTaskId = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: ept
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ExcludeProjectedTasks As Boolean
            Get
                Return mExcludeProjectedTasks
            End Get
            Set(ByVal Value As Boolean)
                mExcludeProjectedTasks = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: xid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ExpenseId As Integer
            Get
                Return mExpenseId
            End Get
            Set(ByVal Value As Integer)
                mExpenseId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: fn
        ''' </summary>
        ''' <returns>String</returns>
        Public Property FunctionCode As String
            Get
                Return mFunctionCode
            End Get
            Set(ByVal value As String)
                mFunctionCode = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: ics
        ''' </summary>
        ''' <returns>String</returns>
        Public Property IncludeCompletedSchedules As Boolean
            Get
                Return mIncludeCompletedSchedules
            End Get
            Set(ByVal Value As Boolean)
                mIncludeCompletedSchedules = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: ict
        ''' </summary>
        ''' <returns>String</returns>
        Public Property IncludeCompletedTasks As Boolean
            Get
                Return mIncludeCompletedTasks
            End Get
            Set(ByVal Value As Boolean)
                mIncludeCompletedTasks = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: ipt
        ''' </summary>
        ''' <returns>String</returns>
        Public Property IncludeOnlyPendingTasks As Boolean
            Get
                Return mIncludeOnlyPendingTasks
            End Get
            Set(ByVal Value As Boolean)
                mIncludeOnlyPendingTasks = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: inv
        ''' </summary>
        ''' <returns>String</returns>
        Public Property InvoiceNumber() As Integer
            Get
                Return mInvoiceNumber
            End Get
            Set(ByVal value As Integer)
                mInvoiceNumber = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: invseq
        ''' </summary>
        ''' <returns>String</returns>
        Public Property InvoiceSequenceNumber() As Integer
            Get
                Return mInvoiceSeqNbr
            End Get
            Set(ByVal value As Integer)
                mInvoiceSeqNbr = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: bm
        ''' </summary>
        ''' <returns>String</returns>
        Public Property IsBookmark As Boolean
            Get
                Return mIsBookmark
            End Get
            Set(ByVal Value As Boolean)
                mIsBookmark = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: jd
        ''' </summary>
        ''' <returns>String</returns>
        Public Property IsJobDashboard As Boolean
            Get
                Return mIsJobDashboard
            End Get
            Set(ByVal Value As Boolean)
                mIsJobDashboard = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: jc
        ''' </summary>
        ''' <returns>String</returns>
        Public Property JobComponentNumber() As Integer
            Get
                Return mJobComponentNbr
            End Get
            Set(ByVal value As Integer)
                mJobComponentNbr = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: j
        ''' </summary>
        ''' <returns>String</returns>
        Public Property JobNumber() As Integer
            Get
                Return mJobNumber
            End Get
            Set(ByVal value As Integer)
                mJobNumber = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: jvid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property JobVersionHeaderID() As Integer
            Get
                Return mJobVersionHdrId
            End Get
            Set(ByVal value As Integer)
                mJobVersionHdrId = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: jvs
        ''' </summary>
        ''' <returns>String</returns>
        Public Property JobVersionSequenceNumber() As Integer
            Get
                Return mJobVersionSeqNbr
            End Get
            Set(ByVal value As Integer)
                mJobVersionSeqNbr = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: m
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ManagerCode As String
            Get
                Return mManagerCode
            End Get
            Set(ByVal Value As String)
                mManagerCode = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: matbrevid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property MediaATBRevisionID As Integer
            Get
                Return mMediaATBRevisionID
            End Get
            Set(ByVal Value As Integer)
                mMediaATBRevisionID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: matbnum
        ''' </summary>
        ''' <returns>String</returns>
        Public Property MediaATBNumber As Integer
            Get
                Return mMediaATBNumber
            End Get
            Set(ByVal Value As Integer)
                mMediaATBNumber = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: mon
        ''' </summary>
        ''' <returns>String</returns>
        Public Property MediaOrderNumber As Integer
            Get
                Return mMediaOrderNumber
            End Get
            Set(ByVal Value As Integer)
                mMediaOrderNumber = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: moln
        ''' </summary>
        ''' <returns>String</returns>
        Public Property MediaOrderLineNumber As Integer
            Get
                Return mMediaOrderLineNumber
            End Get
            Set(ByVal Value As Integer)
                mMediaOrderLineNumber = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: morn
        ''' </summary>
        ''' <returns>String</returns>
        Public Property MediaOrderRevisionNumber As Integer
            Get
                Return mMediaOrderRevisionNumber
            End Get
            Set(ByVal Value As Integer)
                mMediaOrderRevisionNumber = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: morsn
        ''' </summary>
        ''' <returns>String</returns>
        Public Property MediaOrderSequenceNumber As Integer
            Get
                Return mMediaOrderSequenceNumber
            End Get
            Set(ByVal Value As Integer)
                mMediaOrderSequenceNumber = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: matbrevid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property MediaATBRevisionNumber As Integer
            Get
                Return mMediaATBRevisionNumber
            End Get
            Set(ByVal Value As Integer)
                mMediaATBRevisionNumber = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: mt
        ''' </summary>
        ''' <returns>String</returns>
        Public Property MediaType As MediaOrderType
            Get
                Return mMediaType
            End Get
            Set(value As MediaOrderType)
                mMediaType = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: mso
        ''' </summary>
        ''' <returns>String</returns>
        Public Property MilestonesOnly As Boolean
            Get
                Return mMilestonesOnly
            End Get
            Set(ByVal Value As Boolean)
                mMilestonesOnly = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: mm
        ''' </summary>
        ''' <returns>String</returns>
        Public Property Month As Integer
            Get
                Return mMonth
            End Get
            Set(ByVal Value As Integer)
                mMonth = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: o
        ''' </summary>
        ''' <returns>String</returns>
        Public Property OfficeCode() As String
            Get
                Return mOfficeCode
            End Get
            Set(ByVal value As String)
                mOfficeCode = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: pf
        ''' </summary>
        ''' <returns>String</returns>
        Public Property PhaseFilter As String
            Get
                Return mPhaseFilter
            End Get
            Set(ByVal Value As String)
                mPhaseFilter = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: po
        ''' </summary>
        ''' <returns>String</returns>
        Public Property PurchaseOrderNumber As Integer
            Get
                Return mPoNumber
            End Get
            Set(ByVal Value As Integer)
                mPoNumber = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: pp
        ''' </summary>
        ''' <returns>String</returns>
        Public Property PostPeriod As String
            Get
                Return mPostPeriod
            End Get
            Set(ByVal Value As String)
                mPostPeriod = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: p
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ProductCode() As String
            Get
                Return mPrdCode
            End Get
            Set(ByVal value As String)
                mPrdCode = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: qty
        ''' </summary>
        ''' <returns>String</returns>
        Public Property Quantity As Integer
            Get
                Return mQuantity
            End Get
            Set(ByVal Value As Integer)
                mQuantity = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: rv
        ''' </summary>
        ''' <returns>String</returns>
        Public Property RevisionId As Integer
            Get
                Return mRevisionId
            End Get
            Set(ByVal Value As Integer)
                mRevisionId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: rc
        ''' </summary>
        ''' <returns>String</returns>
        Public Property RoleCode As String
            Get
                Return mRoleCode
            End Get
            Set(ByVal Value As String)
                mRoleCode = Value
            End Set
        End Property

        ''' <summary>
        ''' QueryString key: ri
        ''' </summary>
        ''' <returns>String</returns>
        Public Property RoomID As String
            Get
                Return mRoomId
            End Get
            Set(ByVal Value As String)
                mRoomId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: rn
        ''' </summary>
        ''' <returns>String</returns>
        Public Property RoomName As String
            Get
                Return mRoomName
            End Get
            Set(ByVal Value As String)
                mRoomName = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: rsh
        ''' </summary>
        ''' <returns>String</returns>
        Public Property Rush As Boolean
            Get
                Return mRush
            End Get
            Set(ByVal Value As Boolean)
                mRush = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: sc
        ''' </summary>
        ''' <returns>String</returns>
        Public Property SalesClassCode As String
            Get
                Return mScCode
            End Get
            Set(ByVal Value As String)
                mScCode = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: st
        ''' </summary>
        ''' <returns>String</returns>
        Public Property SearchText As String
            Get
                Return mSearchText
            End Get
            Set(ByVal Value As String)
                mSearchText = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: skip
        ''' </summary>
        ''' <returns>Integer</returns>
        Public Property Skip As Integer
            Get
                Return mSkip
            End Get
            Set(ByVal Value As Integer)
                mSkip = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: spid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property SpecificationId As Integer
            Get
                Return mSpecId
            End Get
            Set(ByVal Value As Integer)
                mSpecId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: sprhid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property SprintHeaderID As Integer
            Get
                Return mSprintHeaderID
            End Get
            Set(ByVal Value As Integer)
                mSprintHeaderID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: sprdid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property SprintDetailID As Integer
            Get
                Return mSprintDetailID
            End Get
            Set(ByVal Value As Integer)
                mSprintDetailID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: sd
        ''' </summary>
        ''' <returns>String</returns>
        Public Property StartDate As String
            Get
                Return mStartDate
            End Get
            Set(ByVal Value As String)
                mStartDate = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: take
        ''' </summary>
        ''' <returns>Integer</returns>
        Public Property Take As Integer
            Get
                Return mTake
            End Get
            Set(ByVal Value As Integer)
                mTake = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: tc
        ''' </summary>
        ''' <returns>String</returns>
        Public Property TaskCode As String
            Get
                Return mTaskCode
            End Get
            Set(ByVal Value As String)
                mTaskCode = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: s
        ''' </summary>
        ''' <returns>String</returns>
        Public Property TaskSequenceNumber() As Integer
            Get
                Return mTaskSeqNbr
            End Get
            Set(ByVal value As Integer)
                mTaskSeqNbr = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: tt
        ''' </summary>
        ''' <returns>String</returns>
        Public Property TimeType As String
            Get
                Return mTimeType
            End Get
            Set(ByVal Value As String)
                mTimeType = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: tsc
        ''' </summary>
        ''' <returns>String</returns>
        Public Property TrafficStatusCode As Boolean
            Get
                Return mTrafficStatusCode
            End Get
            Set(ByVal Value As Boolean)
                mTrafficStatusCode = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: tsv
        ''' </summary>
        ''' <returns>String</returns>
        Public Property TrafficScheduleVersionId() As Integer
            Get
                Return mTrafficScheduleVersionId
            End Get
            Set(ByVal value As Integer)
                mTrafficScheduleVersionId = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: usr
        ''' </summary>
        ''' <returns>String</returns>
        Public Property UserCode As String
            Get
                Return mUserCode
            End Get
            Set(ByVal Value As String)
                mUserCode = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: vc
        ''' </summary>
        ''' <returns>String</returns>
        Public Property VendorCode As String
            Get
                Return mVendorCode
            End Get
            Set(ByVal Value As String)
                mVendorCode = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: vid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property VersionId As Integer
            Get
                Return mVersionId
            End Get
            Set(ByVal Value As Integer)
                mVersionId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: w
        ''' </summary>
        ''' <returns>String</returns>
        Public Property WorkspaceId() As Integer
            Get
                Return mWorkspaceId
            End Get
            Set(ByVal value As Integer)
                mWorkspaceId = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: yyyy
        ''' </summary>
        ''' <returns>String</returns>
        Public Property Year As Integer
            Get
                Return mYear
            End Get
            Set(ByVal Value As Integer)
                mYear = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: doclvl
        ''' </summary>
        ''' <returns>String</returns>
        Public Property DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel
            Get
                Return mDocumentLevel
            End Get
            Set(ByVal value As AdvantageFramework.Database.Entities.DocumentLevel)
                mDocumentLevel = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: conrptid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ContractReportId As Integer
            Get
                Return mContractReportId
            End Get
            Set(ByVal Value As Integer)
                mContractReportId = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: csbcsrt
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ConceptShareBaseReviewType As AdvantageFramework.Database.Entities.ConceptShareBaseReviewType
            Get
                Return mConceptShareBaseReviewType
            End Get
            Set(value As AdvantageFramework.Database.Entities.ConceptShareBaseReviewType)
                mConceptShareBaseReviewType = value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: cspid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ConceptShareProjectID As Integer
            Get
                Return mConceptShareProjectID
            End Get
            Set(ByVal Value As Integer)
                mConceptShareProjectID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: csrid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ConceptShareReviewID As Integer
            Get
                Return mConceptShareReviewID
            End Get
            Set(ByVal Value As Integer)
                mConceptShareReviewID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: csaid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ConceptShareAssetID As Integer
            Get
                Return mConceptShareAssetID
            End Get
            Set(ByVal Value As Integer)
                mConceptShareAssetID = Value
            End Set
        End Property
        ''' <summary>
        ''' QueryString key: cscid
        ''' </summary>
        ''' <returns>String</returns>
        Public Property ConceptShareCommentID As Integer
            Get
                Return mConceptShareCommentID
            End Get
            Set(ByVal Value As Integer)
                mConceptShareCommentID = Value
            End Set
        End Property

#End Region

#Region " Methods "

#Region " Use session to maintain querystring "

        Public Sub ToSession()

            Me.Build()

            If Me.ObfuscateQS = True Then

                HttpContext.Current.Session("CURRENT_QUERYSTRING") = Me.Page & Me.Obfuscate(Me).ToString(True)

            Else

                HttpContext.Current.Session("CURRENT_QUERYSTRING") = Me.Page & Me.ToString(True)

            End If

        End Sub

        Public Function FromSession() As QueryStringOld

            Dim qs As New QueryStringOld()

            qs = FromUrl(HttpContext.Current.Session("CURRENT_QUERYSTRING"))
            HttpContext.Current.Session("CURRENT_QUERYSTRING") = Nothing

            Return qs

        End Function

#End Region
#Region " Other Methods "

        'keep the key alphabetical please and as short as possible
        Public Sub Build()

            If Me.mAlertId > 0 Then
                Me.Add("a", Me.mAlertId.ToString())
            End If
            If String.IsNullOrWhiteSpace(Me.mAccountExecutiveCode.Trim()) = False Then
                Me.Add("ae", Me.mAccountExecutiveCode.Trim())
            End If
            If Me.mBillingApprovalId > 0 Then
                Me.Add("aid", Me.mBillingApprovalId.ToString())
            End If
            If Me.mAlertNotifyHdrId > 0 Then
                Me.Add("ani", Me.mAlertNotifyHdrId.ToString())
            End If
            If String.IsNullOrWhiteSpace(Me.mAPInvoice.Trim()) = False Then
                Me.Add("api", Me.mAPInvoice.ToString())
            End If
            If Me.mAPID > 0 Then
                Me.Add("apid", Me.mAPID.ToString())
            End If
            If Me.mAlertStateId > 0 Then
                Me.Add("asi", Me.mAlertStateId.ToString())
            End If
            If Me.mBillingApprovalBatchId > 0 Then
                Me.Add("bid", Me.mBillingApprovalBatchId.ToString())
            End If
            If Me.mIsBookmark = True Then
                Me.Add("bm", Me.ToInt(Me.mIsBookmark))
            End If
            If Me.mBoardID > 0 Then
                Me.Add("brdid", Me.mBoardID.ToString())
            End If
            If Me.mBoardHeaderID > 0 Then
                Me.Add("brdhid", Me.mBoardHeaderID.ToString())
            End If
            If Me.mBoardColumnID > 0 Then
                Me.Add("brdcid", Me.mBoardColumnID.ToString())
            End If
            If Me.mBoardDetailID > 0 Then
                Me.Add("brddid", Me.mBoardDetailID.ToString())
            End If
            If Me.mBoardDetailID > 0 Then
                Me.Add("brdstid", Me.mBoardStateID.ToString())
            End If
            If String.IsNullOrWhiteSpace(Me.mClCode.Trim()) = False Then
                Me.Add("c", Me.mClCode.Trim())
            End If
            If Me.mCmpIdentifier > 0 Then
                Me.Add("cid", Me.mCmpIdentifier.ToString())
            End If
            If String.IsNullOrWhiteSpace(Me.mCampaignCode.Trim()) = False Then
                Me.Add("cmp", Me.mCampaignCode.Trim())
            End If
            If String.IsNullOrWhiteSpace(Me.mCutOffDate.Trim()) = False Then
                If IsDate(Me.mCutOffDate) = True Then
                    Me.Add("cod", CDate(Me.mCutOffDate.Trim()).ToShortDateString())
                End If
            End If
            If String.IsNullOrWhiteSpace(Me.mConnString.Trim()) = False Then
                Me.Add("con", Me.mConnString.Trim())
            End If
            If Me.mContractId > 0 Then
                Me.Add("conid", Me.mContractId.ToString())
            End If
            If Me.mContractReportId > 0 Then
                Me.Add("conrptid", Me.mContractReportId.ToString())
            End If
            If Me.mContentArea > 0 Then
                Me.Add("contaid", CType(Me.mContentArea, Integer).ToString())
            End If
            If Me.mChatRoomId > 0 Then
                Me.Add("crid", Me.mChatRoomId.ToString())
            End If
            If Not Me.mConceptShareBaseReviewType = Nothing Then
                Me.Add("csbcsrt", CType(Me.mConceptShareBaseReviewType, Integer).ToString())
            End If
            If Me.mConceptShareAssetID > 0 Then
                Me.Add("csaid", Me.mConceptShareAssetID.ToString())
            End If
            If Me.mConceptShareCommentID > 0 Then
                Me.Add("cscid", Me.mConceptShareCommentID.ToString())
            End If
            If Me.mConceptShareProjectID > 0 Then
                Me.Add("cspid", Me.mConceptShareProjectID.ToString())
            End If
            If Me.mConceptShareReviewID > 0 Then
                Me.Add("csrid", Me.mConceptShareReviewID.ToString())
            End If
            If String.IsNullOrWhiteSpace(Me.mDivCode.Trim()) = False Then
                Me.Add("d", Me.mDivCode.Trim())
            End If
            If String.IsNullOrWhiteSpace(Me.mDueDate.Trim()) = False Then
                If IsDate(Me.mDueDate) = True Then
                    Me.Add("dd", CDate(Me.mDueDate.Trim()).ToShortDateString())
                End If
            End If
            If String.IsNullOrWhiteSpace(Me.mDeepLink.Trim()) = False Then
                Me.Add("dl", Me.mDeepLink.Trim())
            End If
            If Me.mDocumentId > 0 Then
                Me.Add("doc", Me.mDocumentId.ToString())
            End If
            If Me.mDocumentLabelId > 0 Then
                Me.Add("doclblid", Me.mDocumentLabelId.ToString())
            End If
            If Not Me.mDocumentLevel = Nothing Then
                Me.Add("doclvl", CType(Me.mDocumentLevel, Integer).ToString())
            End If
            If String.IsNullOrWhiteSpace(Me.mDepartmentTeamCode.Trim()) = False Then
                Me.Add("dtc", Me.mDepartmentTeamCode.Trim())
            End If
            If Me.mEstimateNumber > 0 Then
                Me.Add("e", Me.mEstimateNumber.ToString())
            End If
            If Me.mEstComponentNbr > 0 Then
                Me.Add("ec", Me.mEstComponentNbr.ToString())
            End If
            If String.IsNullOrWhiteSpace(Me.mEndDate.Trim()) = False Then
                If IsDate(Me.mEndDate) = True Then
                    Me.Add("ed", CDate(Me.mEndDate.Trim()).ToShortDateString())
                End If
            End If
            If String.IsNullOrWhiteSpace(Me.mEmailGroup.Trim()) = False Then
                Me.Add("eg", Me.mEmailGroup.Trim())
            End If
            If String.IsNullOrWhiteSpace(Me.mEmpCode.Trim()) = False Then
                Me.Add("emp", Me.mEmpCode.Trim())
            End If
            If String.IsNullOrWhiteSpace(Me.mEmployeeName.Trim()) = False Then
                Me.Add("en", Me.mEmployeeName.Trim())
            End If
            If Me.mExcludeProjectedTasks = True Then
                Me.Add("ept", Me.ToInt(Me.mExcludeProjectedTasks))
            End If
            If Me.mEstQuoteNbr > 0 Then
                Me.Add("eq", Me.mEstQuoteNbr.ToString())
            End If
            If Me.mEstRevNbr > 0 Then
                Me.Add("er", Me.mEstRevNbr.ToString())
            End If
            If Me.mEmployeeTimeId > 0 Then
                Me.Add("etid", Me.mEmployeeTimeId.ToString())
            End If
            If Me.mEmployeeTimeDetailId > 0 Then
                Me.Add("etdid", Me.mEmployeeTimeDetailId.ToString())
            End If
            If Me.mEmployeeTimeForecastOfficeDetailId > 0 Then
                Me.Add("etfod", Me.mEmployeeTimeForecastOfficeDetailId.ToString())
            End If
            If Me.mEventId > 0 Then
                Me.Add("evt", Me.mEventId.ToString())
            End If
            If Me.mEventTaskId > 0 Then
                Me.Add("evtt", Me.mEventTaskId.ToString())
            End If
            If Not Me.mApp = Nothing Then
                Me.Add("f", CType(Me.mApp, Integer).ToString())
            End If
            If String.IsNullOrWhiteSpace(Me.mFunctionCode.Trim()) = False Then
                Me.Add("fn", Me.mFunctionCode.Trim())
            End If
            If Me.mIncludeCompletedSchedules = True Then
                Me.Add("ics", Me.ToInt(Me.mIncludeCompletedSchedules))
            End If
            If Me.mIncludeCompletedTasks = True Then
                Me.Add("ict", Me.ToInt(Me.mIncludeCompletedTasks))
            End If
            If Me.mIncludeOnlyPendingTasks = True Then
                Me.Add("ipt", Me.ToInt(Me.mIncludeOnlyPendingTasks))
            End If
            If Me.mInvoiceNumber > 0 Then
                Me.Add("inv", Me.mInvoiceNumber.ToString())
            End If
            If Me.mInvoiceSeqNbr > -1 Then
                Me.Add("invseq", Me.mInvoiceSeqNbr.ToString())
            End If
            If Me.mJobNumber > 0 Then
                Me.Add("j", Me.mJobNumber.ToString())
            End If
            If Me.mJobComponentNbr > 0 Then
                Me.Add("jc", Me.mJobComponentNbr.ToString())
            End If
            If Me.mIsJobDashboard = True Then
                Me.Add("jd", Me.ToInt(Me.mIsJobDashboard))
            End If
            If Me.mJobVersionHdrId > 0 Then
                Me.Add("jvid", Me.mJobVersionHdrId.ToString())
            End If
            If Me.mJobVersionSeqNbr > 0 Then
                Me.Add("jvs", Me.mJobVersionSeqNbr.ToString())
            End If
            If String.IsNullOrWhiteSpace(Me.mManagerCode.Trim()) = False Then
                Me.Add("m", Me.mManagerCode.Trim())
            End If
            If Me.mMediaATBRevisionID > 0 Then
                Me.Add("matbrevid", Me.mMediaATBRevisionID.ToString())
            End If
            If Me.mMediaATBNumber > 0 Then
                Me.Add("matbnum", Me.mMediaATBNumber.ToString())
            End If
            If Me.mMediaATBRevisionNumber > 0 Then
                Me.Add("matbrevid", Me.mMediaATBRevisionNumber.ToString())
            End If
            If Me.mMonth > 0 Then
                Me.Add("mm", Me.mMonth.ToString())
            End If
            If Me.mMediaOrderNumber > 0 Then
                Me.Add("mon", Me.mMediaOrderNumber.ToString())
            End If
            If Me.mMediaOrderLineNumber > 0 Then
                Me.Add("moln", Me.mMediaOrderLineNumber.ToString())
            End If
            If Me.mMediaOrderRevisionNumber > 0 Then
                Me.Add("morn", Me.mMediaOrderRevisionNumber.ToString())
            End If
            If Me.mMediaOrderSequenceNumber > 0 Then
                Me.Add("morsn", Me.mMediaOrderSequenceNumber.ToString())
            End If
            If Me.mMilestonesOnly = True Then
                Me.Add("mso", Me.ToInt(Me.mMilestonesOnly))
            End If
            If Not Me.mMediaType = Nothing Then
                Me.Add("mt", CType(Me.mMediaType, Integer).ToString())
            End If
            If String.IsNullOrWhiteSpace(Me.mOfficeCode.Trim()) = False Then
                Me.Add("o", Me.mOfficeCode.Trim())
            End If
            If String.IsNullOrWhiteSpace(Me.mPrdCode.Trim()) = False Then
                Me.Add("p", Me.mPrdCode.Trim())
            End If
            If String.IsNullOrWhiteSpace(Me.mPhaseFilter.Trim()) = False Then
                Me.Add("pf", Me.mPhaseFilter.Trim())
            End If
            If Me.mPoNumber > 0 Then
                Me.Add("po", Me.mPoNumber.ToString())
            End If
            If String.IsNullOrWhiteSpace(Me.mPostPeriod.Trim()) = False Then
                Me.Add("pp", Me.mPostPeriod.Trim())
            End If
            If Me.mQuantity > 0 Then
                Me.Add("qty", Me.mQuantity.ToString())
            End If
            If String.IsNullOrWhiteSpace(Me.mRoleCode.Trim()) = False Then
                Me.Add("rc", Me.mRoleCode.Trim())
            End If
            If String.IsNullOrWhiteSpace(Me.mRoomId.Trim()) = False Then
                Me.Add("ri", Me.mRoomId.Trim())
            End If
            If String.IsNullOrWhiteSpace(Me.mRoomName.Trim()) = False Then
                Me.Add("rn", Me.mRoomName.Trim())
            End If
            If Me.mRush = True Then
                Me.Add("rsh", Me.ToInt(Me.mRush))
            End If
            If Me.mRevisionId > 0 Then
                Me.Add("rv", Me.mRevisionId.ToString())
            End If
            If Me.mTaskSeqNbr > -1 Then
                Me.Add("s", Me.mTaskSeqNbr.ToString())
            End If
            If String.IsNullOrWhiteSpace(Me.mScCode.Trim()) = False Then
                Me.Add("sc", Me.mScCode.Trim())
            End If
            If String.IsNullOrWhiteSpace(Me.mStartDate.Trim()) = False Then
                If IsDate(Me.mStartDate) = True Then
                    Me.Add("sd", CDate(Me.mStartDate.Trim()).ToShortDateString())
                End If
            End If
            If Me.mSkip > 0 Then
                Me.Add("skip", Me.mSkip.ToString())
            End If
            If Me.mSpecId > 0 Then
                Me.Add("spid", Me.mSpecId.ToString())
            End If
            If Me.mSprintHeaderID > 0 Then
                Me.Add("sprhid", Me.mSprintHeaderID.ToString())
            End If
            If Me.mSprintDetailID > 0 Then
                Me.Add("sprdid", Me.mSprintDetailID.ToString())
            End If
            If Me.mIsSession = True Then
                Me.Add("SSSN", Me.ToInt(Me.mIsSession))
            End If
            If String.IsNullOrWhiteSpace(Me.mSearchText.Trim()) = False Then
                Me.Add("st", Me.mSearchText.Trim())
            End If
            If Me.mTake > 0 Then
                Me.Add("take", Me.mTake.ToString())
            End If
            If String.IsNullOrWhiteSpace(Me.mTaskCode.Trim()) = False Then
                Me.Add("tc", Me.mTaskCode.Trim())
            End If
            If String.IsNullOrWhiteSpace(Me.mTrafficStatusCode.Trim()) = False Then
                Me.Add("tsc", Me.mTrafficStatusCode.Trim())
            End If
            If Me.mTrafficScheduleVersionId > -1 Then
                Me.Add("tsv", Me.mTrafficScheduleVersionId.ToString())
            End If
            If String.IsNullOrWhiteSpace(Me.mTimeType.Trim()) = False Then
                Me.Add("tt", Me.mTimeType.Trim())
            End If
            If String.IsNullOrWhiteSpace(Me.mUserCode.Trim()) = False Then
                Me.Add("usr", Me.mUserCode.Trim())
            End If
            If String.IsNullOrWhiteSpace(Me.mVendorCode.Trim()) = False Then
                Me.Add("vc", Me.mVendorCode.ToString())
            End If
            If Me.mVersionId > 0 Then
                Me.Add("vid", Me.mVersionId.ToString())
            End If
            If Me.mWorkspaceId > 0 Then
                Me.Add("w", Me.mWorkspaceId.ToString())
            End If
            If Me.mExpenseId > 0 Then
                Me.Add("xid", Me.mExpenseId.ToString())
            End If
            If Me.mYear > 0 Then
                Me.Add("yyyy", Me.mYear.ToString())
            End If

            If ObfuscateQS = True Then

                Me.Obfuscate(Me)

            End If

        End Sub

        Public Sub Go(Optional ByVal PutIntoSession As Boolean = False, Optional ByVal EndResponse As Boolean = False)
            Me.Build()
            If PutIntoSession = False Then
                If ObfuscateQS = True Then
                    HttpContext.Current.Response.Redirect(Me.Page & Me.Obfuscate(Me).ToString(), EndResponse)
                Else
                    HttpContext.Current.Response.Redirect(Me.Page & Me.ToString(), EndResponse)
                End If
            Else
                If Me.ObfuscateQS = True Then
                    HttpContext.Current.Session("CURRENT_QUERYSTRING") = Me.Page & Me.Obfuscate(Me).ToString()
                Else
                    HttpContext.Current.Session("CURRENT_QUERYSTRING") = Me.Page & Me.ToString()
                End If
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

        Public Function FromString(ByVal Value As String) As QueryStringOld

            Dim qs As New QueryStringOld()

            Try

                qs = FromUrl(Value)

            Catch ex As Exception
                qs = Nothing
            End Try

            Return qs

        End Function
        Public Function FromCurrent(Optional ByVal GetFromSession As Boolean = False) As QueryStringOld

            Dim s As String = String.Empty

            Try

                If GetFromSession = False Then

                    s = HttpContext.Current.Request.Url.AbsoluteUri

                Else

                    If Not HttpContext.Current.Session("CURRENT_QUERYSTRING") = Nothing Then

                        s = HttpContext.Current.Session("CURRENT_QUERYSTRING")

                    End If

                End If

            Catch ex As Exception
                s = String.Empty
            End Try

            If String.IsNullOrWhiteSpace(s) = False Then

                Return Me.FromString(s)

            Else

                Return Nothing

            End If

            'Dim qs As New QueryStringOld()
            'If GetFromSession = False Then
            '    qs = FromUrl(HttpContext.Current.Request.Url.AbsoluteUri)
            'Else
            '    If Not HttpContext.Current.Session("CURRENT_QUERYSTRING") = Nothing Then
            '        qs = FromUrl(HttpContext.Current.Session("CURRENT_QUERYSTRING"))
            '    End If
            'End If
            'Return qs

        End Function
        Public Overrides Sub Add(ByVal name As String, ByVal value As String)

            Dim Sanitizer As New Ganss.XSS.HtmlSanitizer
            value = Sanitizer.Sanitize(value)

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

        Public Overrides Function ToString() As String

            Return ToString(False)

        End Function
        Public Overloads Function ToString(ByVal IncludePage As Boolean) As String

            Me.Build()

            Dim parts As String() = New String(Me.Count - 1) {}
            Dim keys As String() = Me.AllKeys

            For i As Integer = 0 To keys.Length - 1

                parts(i) = keys(i) & "=" & HttpContext.Current.Server.UrlEncode(Me(keys(i)))

            Next

            Dim url As String = [String].Join("&", parts)

            If (url IsNot Nothing OrElse url <> [String].Empty) AndAlso Not url.StartsWith("?") Then

                url = "?" & url

            End If

            If IncludePage Then

                url = Me.mPage & url

            End If

            Return url

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
        Private Sub CheckForBrokenEncoding(ByRef s As String)

            If s.Contains("&amp;") = True Then

                s = s.Replace("&amp;", "&")

            ElseIf s.Contains("&amp") = True Then

                s = s.Replace("&amp", "&")

            ElseIf s.Contains("amp;") = True Then

                s = s.Replace("amp;", "")

            End If

        End Sub
        Private Function FromUrl(ByVal URL As String) As QueryStringOld

            Dim Values As System.Collections.Specialized.NameValueCollection = Nothing 'System.Web.HttpUtility.ParseQueryString(parts(1))
            Dim parts As String() = URL.Split("?")
            Dim qs As New QueryStringOld()


            If String.IsNullOrWhiteSpace(URL) Then

                URL = HttpContext.Current.Request.QueryString.ToString()

            End If

            CheckForEncoding(URL)

            If URL.Contains("?") = True Then

                CheckForBrokenEncoding(URL)

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

            'qs.Page = parts(0)

            'If parts.Length = 1 Then

            '    Return qs

            'End If

            'Dim keys As String()
            'keys = HttpContext.Current.Request.QueryString.ToString().Split("&")

            'For Each key As String In keys

            '    Dim part As String() = key.Split("=")
            '    Dim ThisKey As String = ""
            '    Dim ThisValue As String = ""

            '    ThisKey = part(0).ToString().Trim()

            '    If part.Length = 1 Then

            '        ThisValue = ""

            '    Else

            '        ThisValue = part(1).Trim()

            '    End If
            '    If Me.ObfuscateQS = True Then

            '        ThisKey = DeHex(part(0))
            '        ThisValue = DeHex(part(1))

            '    End If

            '    Try

            '        ThisValue = HttpUtility.UrlDecode(ThisValue)

            '    Catch ex As Exception

            '        ThisValue = ThisValue

            '    End Try

            '    qs.Add(ThisKey, ThisValue)

            '    With qs
            '        Select Case ThisKey 'Keep the key alphabetical please
            '            Case "a" ', "alert", "alertid"
            '                If IsNumeric(ThisValue) Then .mAlertId = CType(ThisValue, Integer)
            '            Case "ae"
            '                .mAccountExecutiveCode = ThisValue.ToString()
            '            Case "aid"
            '                If IsNumeric(ThisValue) Then .mBillingApprovalId = CType(ThisValue, Integer)
            '            Case "ani"
            '                If IsNumeric(ThisValue) Then .mAlertNotifyHdrId = CType(ThisValue, Integer)
            '            Case "api"
            '                .mAPInvoice = ThisValue.ToString()
            '            Case "apid"
            '                If IsNumeric(ThisValue) Then .mAPID = CType(ThisValue, Integer)
            '            Case "asi"
            '                If IsNumeric(ThisValue) Then .mAlertStateId = CType(ThisValue, Integer)
            '            Case "bid"
            '                If IsNumeric(ThisValue) Then .mBillingApprovalBatchId = CType(ThisValue, Integer)
            '            Case "bm"
            '                If IsNumeric(ThisValue) Then .mIsBookmark = Me.FromInt(CType(ThisValue, Integer))
            '            Case "brdid"
            '                If IsNumeric(ThisValue) Then .mBoardID = Me.FromInt(CType(ThisValue, Integer))
            '            Case "brdhid"
            '                If IsNumeric(ThisValue) Then .mBoardHeaderID = Me.FromInt(CType(ThisValue, Integer))
            '            Case "brdcid"
            '                If IsNumeric(ThisValue) Then .mBoardColumnID = Me.FromInt(CType(ThisValue, Integer))
            '            Case "brddid"
            '                If IsNumeric(ThisValue) Then .mBoardDetailID = Me.FromInt(CType(ThisValue, Integer))
            '            Case "brdstid"
            '                If IsNumeric(ThisValue) Then .mBoardStateID = Me.FromInt(CType(ThisValue, Integer))
            '            Case "c" ', "cl", "cli", "client"
            '                .mClCode = ThisValue.ToString()
            '            Case "cid"
            '                If IsNumeric(ThisValue) Then .mCmpIdentifier = CType(ThisValue, Integer)
            '            Case "cmp", "cmpcode"
            '                .mCampaignCode = ThisValue.ToString()
            '            Case "cod"
            '                If IsDate(ThisValue) = True Then
            '                    .mCutOffDate = CDate(ThisValue).ToShortDateString()
            '                End If
            '            Case "con"
            '                .mConnString = ThisValue.ToString()
            '            Case "conid"
            '                If IsNumeric(ThisValue) Then .mContractId = CType(ThisValue, Integer)
            '            Case "conrptid"
            '                If IsNumeric(ThisValue) Then .mContractReportId = CType(ThisValue, Integer)
            '            Case "contaid"
            '                If IsNumeric(ThisValue) Then .mContentArea = CType(CType(ThisValue, Integer), ContentAreaName)
            '            Case "crid"
            '                If IsNumeric(ThisValue) Then .mChatRoomId = CType(ThisValue, Integer)
            '            Case "csbcsrt"
            '                If IsNumeric(ThisValue) Then .mConceptShareBaseReviewType = CType(CType(ThisValue, Integer), AdvantageFramework.Database.Entities.ConceptShareBaseReviewType)
            '            Case "csaid"
            '                If IsNumeric(ThisValue) Then .mConceptShareAssetID = CType(ThisValue, Integer)
            '            Case "cscid"
            '                If IsNumeric(ThisValue) Then .mConceptShareCommentID = CType(ThisValue, Integer)
            '            Case "cspid"
            '                If IsNumeric(ThisValue) Then .mConceptShareProjectID = CType(ThisValue, Integer)
            '            Case "csrid"
            '                If IsNumeric(ThisValue) Then .mConceptShareReviewID = CType(ThisValue, Integer)
            '            Case "d" ', "div", "division "
            '                .mDivCode = ThisValue.ToString()
            '            Case "dd"
            '                If IsDate(ThisValue) = True Then .mDueDate = CDate(ThisValue).ToShortDateString()
            '            Case "dl"
            '                .mDeepLink = ThisValue.ToString()
            '            Case "doc"
            '                If IsNumeric(ThisValue) Then .mDocumentId = CType(ThisValue, Integer)
            '            Case "doclblid"
            '                If IsNumeric(ThisValue) Then .mDocumentLabelId = CType(ThisValue, Integer)
            '            Case "doclvl"
            '                If IsNumeric(ThisValue) Then .mDocumentLevel = CType(CType(ThisValue, Integer), AdvantageFramework.Database.Entities.DocumentLevel)
            '            Case "dtc"
            '                .mDepartmentTeamCode = ThisValue.ToString()
            '            Case "e"
            '                If IsNumeric(ThisValue) Then .mEstimateNumber = CType(ThisValue, Integer)
            '            Case "ec"
            '                If IsNumeric(ThisValue) Then .mEstComponentNbr = CType(ThisValue, Integer)
            '            Case "ed"
            '                If IsDate(ThisValue) = True Then
            '                    If IsDate(ThisValue) = True Then .mEndDate = CDate(ThisValue).ToShortDateString()
            '                End If
            '            Case "eg"
            '                .mEmailGroup = ThisValue.ToString()
            '            Case "emp"
            '                .mEmpCode = ThisValue.ToString()
            '            Case "en"
            '                .mEmployeeName = ThisValue.ToString()
            '            Case "ept"
            '                If IsNumeric(ThisValue) Then .mExcludeProjectedTasks = Me.FromInt(CType(ThisValue, Integer))
            '            Case "eq"
            '                If IsNumeric(ThisValue) Then .mEstQuoteNbr = CType(ThisValue, Integer)
            '            Case "er"
            '                If IsNumeric(ThisValue) Then .mEstRevNbr = CType(ThisValue, Integer)
            '            Case "etid"
            '                If IsNumeric(ThisValue) Then .mEmployeeTimeId = CType(ThisValue, Integer)
            '            Case "etdid"
            '                If IsNumeric(ThisValue) Then .mEmployeeTimeDetailId = CType(ThisValue, Integer)
            '            Case "etfod"
            '                If IsNumeric(ThisValue) Then .mEmployeeTimeForecastOfficeDetailId = CType(ThisValue, Integer)
            '            Case "evt"
            '                If IsNumeric(ThisValue) Then .mEventId = CType(ThisValue, Integer)
            '            Case "evtt"
            '                .mEventTaskId = CType(ThisValue, Integer)
            '            Case "f"
            '                If IsNumeric(ThisValue) Then .mApp = CType(CType(ThisValue, Integer), Source_App)
            '            Case "fn"
            '                .mFunctionCode = ThisValue
            '            Case "ics"
            '                If IsNumeric(ThisValue) Then .mIncludeCompletedSchedules = Me.FromInt(CType(ThisValue, Integer))
            '            Case "ict"
            '                If IsNumeric(ThisValue) Then .mIncludeCompletedTasks = Me.FromInt(CType(ThisValue, Integer))
            '            Case "ipt"
            '                If IsNumeric(ThisValue) Then .mIncludeOnlyPendingTasks = Me.FromInt(CType(ThisValue, Integer))
            '            Case "inv"
            '                If IsNumeric(ThisValue) Then .mInvoiceNumber = CType(ThisValue, Integer)
            '            Case "invseq"
            '                If IsNumeric(ThisValue) Then .mInvoiceSeqNbr = CType(ThisValue, Integer)
            '            Case "j" ', "job", "JobNum"
            '                If IsNumeric(ThisValue) Then .mJobNumber = CType(ThisValue, Integer)
            '            Case "jc" ', "comp", "JobComp"
            '                If IsNumeric(ThisValue) Then .mJobComponentNbr = CType(ThisValue, Integer)
            '            Case "jd"
            '                If IsNumeric(ThisValue) Then .mIsJobDashboard = Me.FromInt(CType(ThisValue, Integer))
            '            Case "jvid"
            '                If IsNumeric(ThisValue) Then .mJobVersionHdrId = CType(ThisValue, Integer)
            '            Case "jvs"
            '                If IsNumeric(ThisValue) Then .mJobVersionSeqNbr = CType(ThisValue, Integer)
            '            Case "m"
            '                .mManagerCode = ThisValue.ToString()
            '            Case "matbrevid"
            '                If IsNumeric(ThisValue) Then .mMediaATBRevisionID = CType(ThisValue, Integer)
            '            Case "matbnum"
            '                If IsNumeric(ThisValue) Then .mMediaATBNumber = CType(ThisValue, Integer)
            '            Case "matbrevid"
            '                If IsNumeric(ThisValue) Then .mMediaATBRevisionNumber = CType(ThisValue, Integer)
            '            Case "mm"
            '                If IsNumeric(ThisValue) Then .mMonth = CType(ThisValue, Integer)
            '            Case "mon"
            '                If IsNumeric(ThisValue) Then .mMediaOrderNumber = CType(ThisValue, Integer)
            '            Case "moln"
            '                If IsNumeric(ThisValue) Then .mMediaOrderLineNumber = CType(ThisValue, Integer)
            '            Case "morn"
            '                If IsNumeric(ThisValue) Then .mMediaOrderRevisionNumber = CType(ThisValue, Integer)
            '            Case "morsn"
            '                If IsNumeric(ThisValue) Then .mMediaOrderSequenceNumber = CType(ThisValue, Integer)
            '            Case "mso"
            '                If IsNumeric(ThisValue) Then .mMilestonesOnly = Me.FromInt(CType(ThisValue, Integer))
            '            Case "mt"
            '                If IsNumeric(ThisValue) Then .mMediaType = CType(CType(ThisValue, Integer), MediaOrderType)
            '            Case "o" ', "office"
            '                .mOfficeCode = ThisValue.ToString()
            '            Case "p" ', "prod", "product"
            '                .mPrdCode = ThisValue.ToString()
            '            Case "pf"
            '                .mPhaseFilter = ThisValue.ToString()
            '            Case "po"
            '                .mPoNumber = CType(ThisValue, Integer)
            '            Case "pp"
            '                .mPostPeriod = ThisValue
            '            Case "qty"
            '                If IsNumeric(ThisValue) Then .mQuantity = CType(ThisValue, Integer)
            '            Case "rc"
            '                .mRoleCode = ThisValue.ToString()
            '            Case "ri"
            '                .mRoomId = ThisValue.ToString()
            '            Case "rn"
            '                .mRoomName = ThisValue.ToString()
            '            Case "rsh"
            '                If IsNumeric(ThisValue) Then .mRush = Me.FromInt(CType(ThisValue, Integer))
            '            Case "rv"
            '                If IsNumeric(ThisValue) Then .mRevisionId = CType(ThisValue, Integer)
            '            Case "s"
            '                If IsNumeric(ThisValue) Then .mTaskSeqNbr = CType(ThisValue, Integer)
            '            Case "sc"
            '                .mScCode = ThisValue
            '            Case "sd"
            '                If IsDate(ThisValue) = True Then
            '                    If IsDate(ThisValue) = True Then .mStartDate = CDate(ThisValue).ToShortDateString()
            '                End If
            '            Case "skip"
            '                .mSkip = CType(ThisValue, Integer)
            '            Case "spid"
            '                If IsNumeric(ThisValue) Then .mSpecId = CType(ThisValue, Integer)
            '            Case "sprhid"
            '                If IsNumeric(ThisValue) Then .mSprintHeaderID = CType(ThisValue, Integer)
            '            Case "sprdid"
            '                If IsNumeric(ThisValue) Then .mSprintDetailID = CType(ThisValue, Integer)
            '            Case "SSSN"
            '                If IsNumeric(ThisValue) Then .mIsSession = Me.FromInt(CType(ThisValue, Integer))
            '            Case "st"
            '                .mSearchText = ThisValue.ToString()
            '            Case "take"
            '                .mTake = CType(ThisValue, Integer)
            '            Case "tc"
            '                .mTaskCode = ThisValue.ToString()
            '            Case "tsc"
            '                .mTrafficStatusCode = ThisValue.ToString()
            '            Case "tsv"
            '                If IsNumeric(ThisValue) Then .mTrafficScheduleVersionId = CType(ThisValue, Integer)
            '            Case "tt"
            '                .mTimeType = ThisValue.ToString
            '            Case "usr"
            '                .mUserCode = ThisValue.ToString()
            '            Case "vc"
            '                .mVendorCode = ThisValue.ToString()
            '            Case "vid"
            '                If IsNumeric(ThisValue) Then .mVersionId = CType(ThisValue, Integer)
            '            Case "w"
            '                If IsNumeric(ThisValue) Then .mWorkspaceId = CType(ThisValue, Integer)
            '            Case "xid"
            '                If IsNumeric(ThisValue) Then .mExpenseId = CType(ThisValue, Integer)
            '            Case "yyyy"
            '                If IsNumeric(ThisValue) Then .mYear = CType(ThisValue, Integer)
            '        End Select
            '    End With
            'Next

            Return qs

        End Function
        Private Sub ProcessKeyToValue(ByRef qs As QueryStringOld, ByVal ThisKey As String, ByVal ThisValue As String)

            With qs

                Select Case ThisKey.ToLower 'Keep the key alphabetical please
                    Case "a", "alertid"

                        If IsNumeric(ThisValue) Then .mAlertId = CType(ThisValue, Integer)

                    Case "aamib"

                        If IsNumeric(ThisValue) Then .mAamIncludeBacklog = Me.FromInt(CType(ThisValue, Integer))

                    Case "aamibl"

                        If IsNumeric(ThisValue) Then .mAamIncludeBoardLevel = Me.FromInt(CType(ThisValue, Integer))

                    Case "aamgb"

                        .mAamGroupBy = ThisValue.ToString()

                    Case "aamic"

                        If IsNumeric(ThisValue) Then .mAamIsCount = Me.FromInt(CType(ThisValue, Integer))

                    Case "aamica"

                        If IsNumeric(ThisValue) Then .mAamIncludeCompletedAssignments = Me.FromInt(CType(ThisValue, Integer))

                    Case "aamijap"

                        If IsNumeric(ThisValue) Then .mAamIsJobAlertsPage = Me.FromInt(CType(ThisValue, Integer))

                    Case "aamir"

                        If IsNumeric(ThisValue) Then .mAamIncludeReviews = Me.FromInt(CType(ThisValue, Integer))

                    Case "aamit"

                        .mAamInboxType = ThisValue.ToString()

                    Case "aamrtr"

                        If IsNumeric(ThisValue) Then .mAamRecordsToReturn = CType(ThisValue, Integer)

                    Case "aamsat"

                        .mAamShowAssignmentType = ThisValue.ToString()

                    Case "ae"

                        .mAccountExecutiveCode = ThisValue.ToString()

                    Case "aid"

                        If IsNumeric(ThisValue) Then .mBillingApprovalId = CType(ThisValue, Integer)

                    Case "ani"

                        If IsNumeric(ThisValue) Then .mAlertNotifyHdrId = CType(ThisValue, Integer)

                    Case "api"

                        .mAPInvoice = ThisValue.ToString()

                    Case "apid"

                        If IsNumeric(ThisValue) Then .mAPID = CType(ThisValue, Integer)

                    Case "asi"

                        If IsNumeric(ThisValue) Then .mAlertStateId = CType(ThisValue, Integer)

                    Case "bid"

                        If IsNumeric(ThisValue) Then .mBillingApprovalBatchId = CType(ThisValue, Integer)

                    Case "bm"

                        If IsNumeric(ThisValue) Then .mIsBookmark = Me.FromInt(CType(ThisValue, Integer))

                    Case "brdid"

                        If IsNumeric(ThisValue) Then .mBoardID = Me.FromInt(CType(ThisValue, Integer))

                    Case "brdhid"

                        If IsNumeric(ThisValue) Then .mBoardHeaderID = Me.FromInt(CType(ThisValue, Integer))

                    Case "brdcid"

                        If IsNumeric(ThisValue) Then .mBoardColumnID = Me.FromInt(CType(ThisValue, Integer))

                    Case "brddid"

                        If IsNumeric(ThisValue) Then .mBoardDetailID = Me.FromInt(CType(ThisValue, Integer))

                    Case "brdstid"

                        If IsNumeric(ThisValue) Then .mBoardStateID = Me.FromInt(CType(ThisValue, Integer))

                    Case "c", "cl", "cli", "client", "clcode"

                        .mClCode = ThisValue.ToString()

                    Case "cid"

                        If IsNumeric(ThisValue) Then .mCmpIdentifier = CType(ThisValue, Integer)

                    Case "cmp", "cmpcode"

                        .mCampaignCode = ThisValue.ToString()

                    Case "cod"

                        If IsDate(ThisValue) = True Then .mCutOffDate = CDate(ThisValue).ToShortDateString()

                            'Case "con"

                            '    .mConnString = ThisValue.ToString()

                    Case "conid"

                        If IsNumeric(ThisValue) Then .mContractId = CType(ThisValue, Integer)

                    Case "conrptid"

                        If IsNumeric(ThisValue) Then .mContractReportId = CType(ThisValue, Integer)

                    Case "contaid"

                        If IsNumeric(ThisValue) Then .mContentArea = CType(CType(ThisValue, Integer), ContentAreaName)

                    Case "crid"

                        If IsNumeric(ThisValue) Then .mChatRoomId = CType(ThisValue, Integer)

                    Case "csbcsrt"

                        If IsNumeric(ThisValue) Then .mConceptShareBaseReviewType = CType(CType(ThisValue, Integer), AdvantageFramework.Database.Entities.ConceptShareBaseReviewType)

                    Case "csaid"

                        If IsNumeric(ThisValue) Then .mConceptShareAssetID = CType(ThisValue, Integer)

                    Case "cscid"

                        If IsNumeric(ThisValue) Then .mConceptShareCommentID = CType(ThisValue, Integer)

                    Case "cspid"

                        If IsNumeric(ThisValue) Then .mConceptShareProjectID = CType(ThisValue, Integer)

                    Case "csrid"

                        If IsNumeric(ThisValue) Then .mConceptShareReviewID = CType(ThisValue, Integer)

                    Case "d", "di", "div", "division", "divcode", "dicode"

                        .mDivCode = ThisValue.ToString()

                    Case "dd"

                        If IsDate(ThisValue) = True Then .mDueDate = CDate(ThisValue).ToShortDateString()

                    Case "dl"

                        .mDeepLink = ThisValue.ToString()

                    Case "doc"

                        If IsNumeric(ThisValue) Then .mDocumentId = CType(ThisValue, Integer)

                    Case "doclblid"

                        If IsNumeric(ThisValue) Then .mDocumentLabelId = CType(ThisValue, Integer)

                    Case "doclvl"

                        If IsNumeric(ThisValue) Then .mDocumentLevel = CType(CType(ThisValue, Integer), AdvantageFramework.Database.Entities.DocumentLevel)

                    Case "dtc"

                        .mDepartmentTeamCode = ThisValue.ToString()

                    Case "e"

                        If IsNumeric(ThisValue) Then .mEstimateNumber = CType(ThisValue, Integer)

                    Case "ec"

                        If IsNumeric(ThisValue) Then .mEstComponentNbr = CType(ThisValue, Integer)

                    Case "ed"

                        If IsDate(ThisValue) = True Then .mEndDate = CDate(ThisValue).ToShortDateString()

                    Case "eg"

                        .mEmailGroup = ThisValue.ToString()

                    Case "emp"

                        .mEmpCode = ThisValue.ToString()

                    Case "en"

                        .mEmployeeName = ThisValue.ToString()

                    Case "ept"

                        If IsNumeric(ThisValue) Then .mExcludeProjectedTasks = Me.FromInt(CType(ThisValue, Integer))

                    Case "eq"

                        If IsNumeric(ThisValue) Then .mEstQuoteNbr = CType(ThisValue, Integer)

                    Case "er"

                        If IsNumeric(ThisValue) Then .mEstRevNbr = CType(ThisValue, Integer)

                    Case "etid"

                        If IsNumeric(ThisValue) Then .mEmployeeTimeId = CType(ThisValue, Integer)

                    Case "etdid"

                        If IsNumeric(ThisValue) Then .mEmployeeTimeDetailId = CType(ThisValue, Integer)

                    Case "etfod"

                        If IsNumeric(ThisValue) Then .mEmployeeTimeForecastOfficeDetailId = CType(ThisValue, Integer)

                    Case "evt"

                        If IsNumeric(ThisValue) Then .mEventId = CType(ThisValue, Integer)

                    Case "evtt"

                        .mEventTaskId = CType(ThisValue, Integer)

                    Case "f"

                        If IsNumeric(ThisValue) Then .mApp = CType(CType(ThisValue, Integer), Source_App)

                    Case "fn"

                        .mFunctionCode = ThisValue

                    Case "ics"

                        If IsNumeric(ThisValue) Then .mIncludeCompletedSchedules = Me.FromInt(CType(ThisValue, Integer))

                    Case "ict"

                        If IsNumeric(ThisValue) Then .mIncludeCompletedTasks = Me.FromInt(CType(ThisValue, Integer))

                    Case "ipt"

                        If IsNumeric(ThisValue) Then .mIncludeOnlyPendingTasks = Me.FromInt(CType(ThisValue, Integer))

                    Case "inv"

                        If IsNumeric(ThisValue) Then .mInvoiceNumber = CType(ThisValue, Integer)

                    Case "invseq"

                        If IsNumeric(ThisValue) Then .mInvoiceSeqNbr = CType(ThisValue, Integer)

                    Case "j", "job", "jobnum", "jobnumber", "jobnbr"

                        If IsNumeric(ThisValue) Then .mJobNumber = CType(ThisValue, Integer)

                    Case "jc", "comp", "jobcomp", "jobcompnum", "jobcompnumber", "jobcomponentnumber", "jobcompnbr"

                        If IsNumeric(ThisValue) Then .mJobComponentNbr = CType(ThisValue, Integer)

                    Case "jd"

                        If IsNumeric(ThisValue) Then .mIsJobDashboard = Me.FromInt(CType(ThisValue, Integer))

                    Case "jvid"

                        If IsNumeric(ThisValue) Then .mJobVersionHdrId = CType(ThisValue, Integer)

                    Case "jvs"

                        If IsNumeric(ThisValue) Then .mJobVersionSeqNbr = CType(ThisValue, Integer)

                    Case "locid"

                        If String.IsNullOrWhiteSpace(ThisValue) = False Then .mLocationID = ThisValue

                    Case "m"

                        .mManagerCode = ThisValue.ToString()

                    Case "matbrevid"

                        If IsNumeric(ThisValue) Then .mMediaATBRevisionID = CType(ThisValue, Integer)

                    Case "matbnum"

                        If IsNumeric(ThisValue) Then .mMediaATBNumber = CType(ThisValue, Integer)

                    Case "matbrevid"

                        If IsNumeric(ThisValue) Then .mMediaATBRevisionNumber = CType(ThisValue, Integer)

                    Case "mm"

                        If IsNumeric(ThisValue) Then .mMonth = CType(ThisValue, Integer)

                    Case "mon"

                        If IsNumeric(ThisValue) Then .mMediaOrderNumber = CType(ThisValue, Integer)

                    Case "moln"

                        If IsNumeric(ThisValue) Then .mMediaOrderLineNumber = CType(ThisValue, Integer)

                    Case "morn"

                        If IsNumeric(ThisValue) Then .mMediaOrderRevisionNumber = CType(ThisValue, Integer)

                    Case "morsn"

                        If IsNumeric(ThisValue) Then .mMediaOrderSequenceNumber = CType(ThisValue, Integer)

                    Case "mso"

                        If IsNumeric(ThisValue) Then .mMilestonesOnly = Me.FromInt(CType(ThisValue, Integer))

                    Case "mt"

                        If IsNumeric(ThisValue) Then .mMediaType = CType(CType(ThisValue, Integer), MediaOrderType)

                    Case "o", "office", "off"

                        .mOfficeCode = ThisValue.ToString()

                    Case "p", "prod", "product", "prd"

                        .mPrdCode = ThisValue.ToString()

                    Case "pf"

                        .mPhaseFilter = ThisValue.ToString()

                    Case "po"

                        .mPoNumber = CType(ThisValue, Integer)

                    Case "pp"

                        .mPostPeriod = ThisValue

                    Case "qty"

                        If IsNumeric(ThisValue) Then .mQuantity = CType(ThisValue, Integer)

                    Case "rc"

                        .mRoleCode = ThisValue.ToString()

                    Case "ri"

                        .mRoomId = ThisValue.ToString()

                    Case "rn"

                        .mRoomName = ThisValue.ToString()

                    Case "rsh"

                        If IsNumeric(ThisValue) Then .mRush = Me.FromInt(CType(ThisValue, Integer))

                    Case "rv"

                        If IsNumeric(ThisValue) Then .mRevisionId = CType(ThisValue, Integer)

                    Case "s"

                        If IsNumeric(ThisValue) Then .mTaskSeqNbr = CType(ThisValue, Integer)

                    Case "sc"

                        .mScCode = ThisValue

                    Case "sd"

                        If IsDate(ThisValue) = True Then .mStartDate = CDate(ThisValue).ToShortDateString()

                    Case "skip"

                        .mSkip = CType(ThisValue, Integer)

                    Case "spid"

                        If IsNumeric(ThisValue) Then .mSpecId = CType(ThisValue, Integer)

                    Case "sprhid", "sprintid"

                        If IsNumeric(ThisValue) Then .mSprintHeaderID = CType(ThisValue, Integer)

                    Case "sprdid"

                        If IsNumeric(ThisValue) Then .mSprintDetailID = CType(ThisValue, Integer)

                    'Case "SSSN"

                    '    If IsNumeric(ThisValue) Then .mIsSession = Me.FromInt(CType(ThisValue, Integer))

                    Case "st"

                        .mSearchText = ThisValue.ToString()

                    Case "take"

                        .mTake = CType(ThisValue, Integer)

                    Case "tc"

                        .mTaskCode = ThisValue.ToString()

                    Case "tsc"

                        .mTrafficStatusCode = ThisValue.ToString()

                    Case "tsv"

                        If IsNumeric(ThisValue) Then .mTrafficScheduleVersionId = CType(ThisValue, Integer)

                    Case "tt"

                        .mTimeType = ThisValue.ToString

                    Case "usr"

                        .mUserCode = ThisValue.ToString()

                    Case "vc"

                        .mVendorCode = ThisValue.ToString()

                    Case "vid"

                        If IsNumeric(ThisValue) Then .mVersionId = CType(ThisValue, Integer)

                    Case "w"

                        If IsNumeric(ThisValue) Then .mWorkspaceId = CType(ThisValue, Integer)

                    Case "xid"

                        If IsNumeric(ThisValue) Then .mExpenseId = CType(ThisValue, Integer)

                        'Case "xx1"

                        '    If String.IsNullOrWhiteSpace(ThisValue) = False Then Me.mServerName = ThisValue

                        'Case "xx2"

                        '    If String.IsNullOrWhiteSpace(ThisValue) = False Then Me.mDatabaseName = ThisValue

                    Case "xx3"

                        If String.IsNullOrWhiteSpace(ThisValue) = False Then Me.mUserCode = ThisValue

                        'Case "xx4"

                        '    If String.IsNullOrWhiteSpace(ThisValue) = False Then Me.mPassword = ThisValue

                    Case "xx5"

                        If IsDate(ThisValue) = True Then Me.mApiDate = CType(ThisValue, DateTime)

                    Case "xx6"

                        If String.IsNullOrWhiteSpace(ThisValue) = False Then Me.mConnectionString = ThisValue

                    Case "yyyy"

                        If IsNumeric(ThisValue) Then .mYear = CType(ThisValue, Integer)

                End Select

            End With

        End Sub

        Public Sub RemoveAllKeys()
            Dim AllQuerystringKeys As [String]()
            AllQuerystringKeys = Me.AllKeys
            Dim i As Integer = 0
            While i < AllQuerystringKeys.Length
                Me.Remove(AllQuerystringKeys(i))
                i += 1
            End While
        End Sub

#End Region
#Region " Obfuscate "

        Private Function Obfuscate(ByVal queryString As QueryStringOld) As QueryStringOld
            Dim newQueryString As New QueryStringOld()
            Dim nm As String = String.Empty
            Dim val As String = String.Empty

            For Each name As String In queryString
                nm = name
                val = queryString(name)
                newQueryString.Add(Hex(nm), Hex(val))
            Next

            Return newQueryString

        End Function
        Private Function De_Obfuscate(ByVal queryString As QueryStringOld) As QueryStringOld
            Dim newQueryString As New QueryStringOld()
            Dim nm As String = String.Empty
            Dim val As String = String.Empty
            For Each name As String In queryString
                nm = DeHex(name)
                val = DeHex(queryString(name))
                newQueryString.Add(nm, val)
            Next
            Return newQueryString
        End Function

        Private Function DeHex(ByVal hexstring As String) As String
            Dim ret As String = String.Empty
            Dim sb As New StringBuilder(hexstring.Length \ 2)
            Dim i As Integer = 0

            While i <= hexstring.Length - 1
                sb.Append(ChrW(Integer.Parse(hexstring.Substring(i, 2), NumberStyles.HexNumber)))
                i = i + 2
            End While

            Return sb.ToString()

        End Function
        Private Function Hex(ByVal sData As String) As String
            Dim temp As String = String.Empty
            Dim newdata As String = String.Empty
            Dim sb As New StringBuilder(sData.Length * 2)

            For i As Integer = 0 To sData.Length - 1
                If (sData.Length - (i + 1)) > 0 Then
                    temp = sData.Substring(i, 2)
                    Select Case temp
                        Case "\n"
                            newdata &= "0A"
                        Case "\b"
                            newdata &= "20"
                        Case "\r"
                            newdata &= "0D"
                        Case "\c"
                            newdata &= "2C"
                        Case "\\"
                            newdata &= "5C"
                        Case "\0"
                            newdata &= "00"
                        Case "\t"
                            newdata &= "07"
                        Case Else
                            sb.Append(String.Format("{0:X2}", AscW((sData)(i))))
                            i -= 1
                    End Select
                Else
                    sb.Append(String.Format("{0:X2}", AscW((sData)(i))))
                End If
                i += 1
            Next
            Return sb.ToString()
        End Function

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

        Public Sub New()

        End Sub
        Public Sub New(ByVal info As Runtime.Serialization.SerializationInfo, ByVal context As Runtime.Serialization.StreamingContext)

            MyBase.New(info, context)

        End Sub
        Public Sub New(ByVal clone As NameValueCollection)

            MyBase.New(clone)

        End Sub

#End Region

    End Class

    <Serializable()>
    Public Class DeepLinkOld

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum LinkType

            Internal = 1
            External = 2
            ClientPortalExternal = 3

        End Enum
        Public Enum LinkDisplay

            Rename
            ShowURL
            Blank

        End Enum

#End Region

#Region " Variables "

        Private _QueryString As AdvantageFramework.Web.QueryStringOld
        Private _WebvantageURL As String = String.Empty
        Private _ClientPortalURL As String = String.Empty
        Private _SecuritySession As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

        Public Property URL As String = String.Empty
        Public Property DeepLinkContentType As AdvantageFramework.Web.QueryStringOld.ContentAreaName
        Public Property QueryString As AdvantageFramework.Web.QueryStringOld
            Get
                Return Me._QueryString
            End Get
            Set(value As AdvantageFramework.Web.QueryStringOld)
                Me._QueryString = value
            End Set
        End Property
        Public ReadOnly Property ClientPortalVisible As Boolean
            Get
                Return Not String.IsNullOrWhiteSpace(Me._ClientPortalURL)
            End Get
        End Property

#End Region

#Region " Methods "

        Public Function UrlToInternalLink(ByRef TextString As String, ByRef PlaceHolder As System.Web.UI.WebControls.PlaceHolder, ByVal DisplayAs As LinkDisplay) As Boolean

            Dim HasInternalLink As Boolean = False

            If String.IsNullOrWhiteSpace(TextString) = True OrElse
                    TextString.Contains("<img") = True OrElse
                    TextString.Contains("data:image") = True OrElse
                    TextString.Contains("Click here to navigate") = True Then

                HasInternalLink = False

            Else

                Dim FixedBodyText As String = String.Empty
                Dim Splitter As String = "?dl="
                Dim URL As String = String.Empty
                Dim MatchCollection As System.Text.RegularExpressions.MatchCollection = Nothing
                Dim InternalPage As String = String.Empty
                Dim Counter As Integer = 0
                Dim ReferenceText As String = String.Empty

                Try

                    FixedBodyText = TextString
                    MatchCollection = AdvantageFramework.AlertSystem.GetUrlMatchCollection(FixedBodyText, Me._WebvantageURL, Me._ClientPortalURL)

                    If MatchCollection IsNot Nothing Then

                        Dim ListOpenLiteral As New System.Web.UI.WebControls.Literal
                        Dim ListCloseLiteral As New System.Web.UI.WebControls.Literal

                        ListOpenLiteral.Text = "<ul>"
                        ListCloseLiteral.Text = "</ul>"

                        If PlaceHolder.Visible = True Then PlaceHolder.Controls.Add(ListOpenLiteral)

                        For Each Match In MatchCollection.OfType(Of System.Text.RegularExpressions.Match).Where(Function(m) m.Success = True)

                            InternalPage = String.Empty
                            ReferenceText = String.Empty

                            Try

                                URL = Match.Value

                            Catch ex As Exception
                                URL = String.Empty
                            End Try

                            If String.IsNullOrWhiteSpace(URL) = False Then

                                Try

                                    InternalPage = URL.Substring(URL.IndexOf(Splitter) + Splitter.Length, URL.Length - URL.IndexOf(Splitter) - Splitter.Length)
                                    InternalPage = AdvantageFramework.Web.DecryptDeepLinkString(InternalPage)

                                Catch ex As Exception
                                    InternalPage = String.Empty
                                End Try

                                If String.IsNullOrWhiteSpace(InternalPage) = False Then

                                    Counter += 1

                                    Select Case DisplayAs
                                        Case LinkDisplay.Blank

                                            ReferenceText = String.Format("Link {0}", Counter.ToString)
                                            FixedBodyText = FixedBodyText.Replace(URL, String.Format("&nbsp;"))
                                            'FixedBodyText = FixedBodyText.Replace(URL, String.Format("<div>&nbsp;</div>"))
                                            If PlaceHolder.Visible = True Then AddInternalLinkToPlaceHolder(PlaceHolder, InternalPage, ReferenceText)

                                        Case LinkDisplay.Rename

                                            ReferenceText = String.Format("Link {0}", Counter.ToString)
                                            FixedBodyText = FixedBodyText.Replace(URL, String.Format("{0}", ReferenceText))
                                            'FixedBodyText = FixedBodyText.Replace(URL, String.Format("<div>{0}</div>", ReferenceText))
                                            If PlaceHolder.Visible = True Then AddInternalLinkToPlaceHolder(PlaceHolder, InternalPage, ReferenceText)

                                        Case LinkDisplay.ShowURL

                                            FixedBodyText = FixedBodyText.Replace(URL, String.Format("{0}", URL))
                                            'FixedBodyText = FixedBodyText.Replace(URL, String.Format("<div>{0}</div>", URL))
                                            If PlaceHolder.Visible = True Then AddInternalLinkToPlaceHolder(PlaceHolder, InternalPage, URL)

                                    End Select

                                    HasInternalLink = True

                                End If

                            End If

                        Next

                        If PlaceHolder.Visible = True Then PlaceHolder.Controls.Add(ListCloseLiteral)

                        TextString = FixedBodyText

                    End If

                Catch ex As Exception
                    HasInternalLink = False
                End Try

            End If

            Return HasInternalLink

        End Function
        Private Function AddInternalLinkToPlaceHolder(ByRef PlaceHolder As System.Web.UI.WebControls.PlaceHolder, ByVal InternalPage As String, ByVal ReferenceText As String) As Boolean
            Try

                InternalPage = InternalPage.Replace(String.Format("{0}/", _WebvantageURL), "").Replace(String.Format("{0}/", _ClientPortalURL), "")

                Dim InternalLinkButton As New System.Web.UI.WebControls.LinkButton
                Dim DivOpenLiteral As New System.Web.UI.WebControls.Literal
                Dim DivCloseLiteral As New System.Web.UI.WebControls.Literal

                DivOpenLiteral.Text = "<li style=""display: block !important;word-break:break-all !important;font-size: 14px !important;"">"
                DivCloseLiteral.Text = "</li>"

                InternalLinkButton.CssClass = "permalink-text"
                InternalLinkButton.OnClientClick = String.Format("OpenRadWindow('', '" & InternalPage & "', 0, 0); return false;")
                InternalLinkButton.Text = ReferenceText
                InternalLinkButton.ToolTip = "Click to open " & ReferenceText

                PlaceHolder.Controls.Add(DivOpenLiteral)
                PlaceHolder.Controls.Add(InternalLinkButton)
                PlaceHolder.Controls.Add(DivCloseLiteral)

                Return True

            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Function Build(ByVal Type As AdvantageFramework.Web.DeepLinkType, ByVal DeepLinkQueryString As AdvantageFramework.Web.QueryStringOld) As String

            Return AdvantageFramework.Web.BuildDeepLink(_SecuritySession, Type, QueryString.ToString(True))

        End Function
        Public Sub BuildJavascriptFromQueryString(ByVal DeepLinkQueryString As AdvantageFramework.Web.QueryStringOld, ByRef WebvantageLink As String, ByRef ClientPortalLink As String)

            WebvantageLink = String.Empty
            ClientPortalLink = String.Empty

            BuildFromQueryString(DeepLinkQueryString, WebvantageLink, ClientPortalLink)

            If String.IsNullOrWhiteSpace(WebvantageLink) = False Then

                WebvantageLink = String.Format("copyToClipboard('{0}');", WebvantageLink)

            End If
            If String.IsNullOrWhiteSpace(ClientPortalLink) = False Then

                ClientPortalLink = String.Format("copyToClipboard('{0}');", ClientPortalLink)

            End If

        End Sub
        Public Sub BuildFromQueryString(ByVal DeepLinkQueryString As AdvantageFramework.Web.QueryStringOld, ByRef WebvantageLink As String, ByRef ClientPortalLink As String)

            WebvantageLink = String.Empty
            ClientPortalLink = String.Empty

            If DeepLinkQueryString IsNot Nothing Then

                Dim Link As String = String.Empty 'DeepLinkQueryString.DeepLink

                Try

                    If String.IsNullOrWhiteSpace(DeepLinkQueryString.Page) = False Then

                        DeepLinkQueryString.Page = Regex.Replace(DeepLinkQueryString.Page, Me._WebvantageURL, "", RegexOptions.IgnoreCase)
                        DeepLinkQueryString.Page = Regex.Replace(DeepLinkQueryString.Page, Me._ClientPortalURL, "", RegexOptions.IgnoreCase)

                        If DeepLinkQueryString.Page.StartsWith("/") = True Then

                            DeepLinkQueryString.Page = DeepLinkQueryString.Page.Substring(1, DeepLinkQueryString.Page.Length - 1)

                        End If

                    End If

                Catch ex As Exception

                End Try
                Try

                    If String.IsNullOrWhiteSpace(DeepLinkQueryString.DeepLink) = True Then

                        Link = AdvantageFramework.Web.EncryptDeepLinkQueryString(DeepLinkQueryString.ToString(True))

                    Else

                        Link = DeepLinkQueryString.DeepLink

                    End If

                Catch ex As Exception
                    Link = String.Empty
                End Try

                If String.IsNullOrWhiteSpace(Link) = False Then

                    If String.IsNullOrWhiteSpace(Me._WebvantageURL) = False Then

                        WebvantageLink = String.Format("{0}/NewApp?dl={1}", Me._WebvantageURL, Link)

                    End If
                    If String.IsNullOrWhiteSpace(Me._ClientPortalURL) = False Then

                        ClientPortalLink = String.Format("{0}/NewApp?dl={1}", Me._ClientPortalURL, Link)

                    End If

                End If

            End If

        End Sub
        Public Function TextHasInternalLinks(ByVal TextString As String) As Boolean

            Return AdvantageFramework.AlertSystem.TextHasInternalLinks(TextString, Me._WebvantageURL, Me._ClientPortalURL)

        End Function
        Private Sub SetApplicationURL()

            Me._WebvantageURL = String.Empty
            Me._ClientPortalURL = String.Empty

            If Me._SecuritySession IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_SecuritySession.ConnectionString, _SecuritySession.UserCode)

                    Dim Agency As AdvantageFramework.Database.Entities.Agency

                    Agency = Nothing
                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If Agency IsNot Nothing Then

                        If Agency.WebvantageURL IsNot Nothing Then Me._WebvantageURL = Agency.WebvantageURL
                        If Agency.ClientPortalURL IsNot Nothing Then Me._ClientPortalURL = Agency.ClientPortalURL

                        Me.CheckURLs()

                    End If

                End Using

            End If

        End Sub
        Private Sub CheckURLs()

            If Me._WebvantageURL.EndsWith("/") = True Then Me._WebvantageURL = Me._WebvantageURL.Substring(0, Me._WebvantageURL.Length - 1)
            If Me._ClientPortalURL.EndsWith("/") = True Then Me._ClientPortalURL = Me._ClientPortalURL.Substring(0, Me._ClientPortalURL.Length - 1)

            If Me._WebvantageURL.ToLower.StartsWith("http://") = False AndAlso Me._WebvantageURL.ToLower.StartsWith("https://") = False Then

                Me._WebvantageURL = "http://" & Me._WebvantageURL

            End If
            If Me._ClientPortalURL.ToLower.StartsWith("http://") = False AndAlso Me._ClientPortalURL.ToLower.StartsWith("https://") = False Then

                Me._ClientPortalURL = "http://" & Me._ClientPortalURL

            End If

            'If Me._WebvantageURL.EndsWith("/") = False Then Me._WebvantageURL &= "/"
            'If Me._ClientPortalURL.EndsWith("/") = False Then Me._ClientPortalURL &= "/"

        End Sub

        Sub New(ByVal SecuritySession As AdvantageFramework.Security.Session)

            Me._SecuritySession = SecuritySession
            Me._QueryString = New AdvantageFramework.Web.QueryStringOld

            Me.SetApplicationURL()

        End Sub
        Sub New(ByVal SecuritySession As AdvantageFramework.Security.Session,
                ByVal QueryString As AdvantageFramework.Web.QueryStringOld)

            Me._SecuritySession = SecuritySession

            If QueryString IsNot Nothing Then

                Me._QueryString = QueryString

            Else

                Me._QueryString = New AdvantageFramework.Web.QueryStringOld

            End If

            Me.SetApplicationURL()

        End Sub

#End Region

    End Class

End Namespace
