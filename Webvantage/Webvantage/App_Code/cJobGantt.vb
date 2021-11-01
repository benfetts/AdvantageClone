Imports System.Data
Imports System.Data.SqlClient
Imports Webvantage.MiscFN
Imports eWorld.UI.CollapsablePanel
Imports System.Text


<Serializable()> Public Class cJobGantt
#Region "Class Level Private/Protected Variables ......"
    Dim oSQL As SqlHelper
    Dim mConnString As String = String.Empty

    Protected mCMP_CODE As String
    Protected mCampaignDesc As String
    Protected mTrafficDesc As String
    Protected mJOB_NUMBER As Integer
    Protected mJOB_DESC As String
    Protected mPHASE_ORDER As Integer
    Protected mPHASE_DESC As String
    Protected mTASK_START_DATE As Date
    Protected mJOB_REVISED_DATE As Date

    Public aCMP_CODE() As String
    Public aCampaignDesc() As String
    Public aTrafficDesc() As String
    Public aJOB_NUMBER() As Integer
    Public aJOB_DESC() As String
    Public aPHASE_ORDER() As Integer
    Public aPHASE_DESC() As String
    Public aTASK_START_DATE() As Date
    Public aJOB_REVISED_DATE() As Date

    Protected mCL_CODE As String = String.Empty
    Protected mDIV_CODE As String = String.Empty
    Protected mPRD_CODE As String = String.Empty
    Protected mClientDesc As String = String.Empty
    Protected mDivisionDesc As String = String.Empty
    Protected mProductDesc As String = String.Empty
    Protected mSC_CODE As String = String.Empty
    Protected mSalesClassDesc As String = String.Empty
    Protected mUSER_ID As String = String.Empty
    Protected mJobComponent As JobComponent
    Protected mJobComponents As JobsComponentCollection
    Protected mIsNew As Boolean = False

    Public Shared row_arr(0) As cChartRow

#End Region

#Region " Constructors "
    Public Sub New(ByVal ConnectionString As String)
        mConnString = ConnectionString
    End Sub
#End Region

#Region " Business Properties"

    Public Property CMP_CODE() As String
        Get
            Return mCMP_CODE
        End Get
        Set(ByVal Value As String)
            If mCMP_CODE <> Value Then
                mCMP_CODE = Value
            End If
        End Set
    End Property

    Public ReadOnly Property CampaignDesc() As String
        Get
            Return mCampaignDesc
        End Get
    End Property

    Public ReadOnly Property TrafficDesc() As String
        Get
            Return mTrafficDesc
        End Get
    End Property

    Public Overridable Property JOB_NUMBER() As Integer
        Get
            Return mJOB_NUMBER
        End Get
        Set(ByVal Value As Integer)
            If mJOB_NUMBER <> Value Then
                mJOB_NUMBER = Value
            End If
        End Set
    End Property

    Public ReadOnly Property JOB_DESC() As String
        Get
            Return mJOB_DESC
        End Get
    End Property

    Public Overridable Property PHASE_ORDER() As Integer
        Get
            Return mPHASE_ORDER
        End Get
        Set(ByVal Value As Integer)
            If mPHASE_ORDER <> Value Then
                mPHASE_ORDER = Value
            End If
        End Set
    End Property

    Public ReadOnly Property PHASE_DESC() As String
        Get
            Return mPHASE_DESC
        End Get
    End Property

    Public Overridable Property TASK_START_DATE() As Date
        Get
            Return mTASK_START_DATE
        End Get
        Set(ByVal Value As Date)
            If mTASK_START_DATE <> Value Then
                mTASK_START_DATE = Value
            End If
        End Set
    End Property

    Public Overridable Property JOB_REVISED_DATE() As Date
        Get
            Return mJOB_REVISED_DATE
        End Get
        Set(ByVal Value As Date)
            If mJOB_REVISED_DATE <> Value Then
                mJOB_REVISED_DATE = Value
            End If
        End Set
    End Property

#End Region

#Region " Methods "
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''     Private Subroutine for returning Gantt Chart data
    ''' </summary>
    ''' <param name="CMP_CODE"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jtg]	4/26/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------

    Public Function GetSqlData() As Boolean

        Dim dr As SqlDataReader
        Dim RowIDX As Integer = New Integer

        'Dim arParams(3) As SqlParameter
        'Create Stored Procedure Parameters
        'Dim parameteremp_code As New SqlParameter("@emp_code", SqlDbType.VarChar, 6)
        'parameteremp_code.Value = EmpCode
        'arParams(0) = parameteremp_code

        Try
            'dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_ts_GetTimeSheet", arParams)
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "JTST1")
        Catch
            Err.Raise(Err.Number, "Class:cJobGantt Routine:GetSqlData", Err.Description)
        Finally

        End Try

        RowIDX = 0
        'If dr.HasRows = True Then
        'Do While dr.Read
        'dr.Read()
        'With dr
        'mCMP_CODE = .GetString(0)
        'mCampaignDesc = .GetString(1)
        'mTrafficDesc = .GetString(2)
        'mJOB_NUMBER = .GetInt32(3)
        'mJOB_DESC = .GetString(4)
        'mPHASE_ORDER = .GetInt32(5)
        'mPHASE_DESC = .GetString(6)
        'If .IsDBNull(8) = False Then
        'mTASK_START_DATE = .GetDateTime(7)
        'End If
        'If .IsDBNull(8) = False Then
        'mJOB_REVISED_DATE = .GetDateTime(8)
        'End If

        'row_arr(RowIDX)._CMP_CODE = .GetString(0)
        'row_arr(RowIDX)._CampaignDesc = .GetString(1)
        'row_arr(RowIDX)._TrafficDesc = .GetString(2)
        'row_arr(RowIDX)._JOB_NUMBER = .GetInt32(3)
        'row_arr(RowIDX)._JOB_DESC = .GetString(4)
        'row_arr(RowIDX)._PHASE_ORDER = .GetInt32(5)
        'row_arr(RowIDX)._PHASE_DESC = .GetString(6)

        'If .IsDBNull(7) = False Then
        'row_arr(RowIDX)._TASK_START_DATE = .GetDateTime(7)
        'End If

        ' If .IsDBNull(8) = False Then
        'row_arr(RowIDX)._JOB_REVISED_DATE = .GetDateTime(8)
        ' End If

        'RowIDX = RowIDX + 1

        'End With
        'Loop
        'End If

        'dr.Close()

        aCMP_CODE = New String() {}
        aCampaignDesc = New String() {}
        aTrafficDesc = New String() {}
        aJOB_NUMBER = New Integer() {}
        aJOB_DESC = New String() {}
        aPHASE_ORDER = New Integer() {}
        aPHASE_DESC = New String() {}
        aTASK_START_DATE = New Date() {}
        aJOB_REVISED_DATE = New Date() {}

        Dim startdate As New System.DateTime(2007, 5, 10, 12, 15, 0)
        Dim enddate As New System.DateTime(2007, 5, 10, 2, 15, 0)

        aCMP_CODE(0) = "2005"
        aCampaignDesc(0) = "CmpnDesc"
        aTrafficDesc(0) = "Traffic Desc"
        aJOB_NUMBER(0) = 1
        aJOB_DESC(0) = "Job Desc 1"
        aPHASE_ORDER(0) = 1
        aPHASE_DESC(0) = "Phase Desc"
        aTASK_START_DATE(0) = startdate
        aJOB_REVISED_DATE(0) = enddate

        'row_arr(0)._CMP_CODE = "2005"
        'row_arr(0)._CampaignDesc = "CmpnDesc"
        'row_arr(0)._TrafficDesc = "Traffic Desc"
        'row_arr(0)._JOB_NUMBER = 1
        'row_arr(0)._JOB_DESC = "Job Desc 1"
        'row_arr(0)._PHASE_ORDER = 1
        'row_arr(0)._PHASE_DESC = "Phase Desc"
        'row_arr(0)._TASK_START_DATE = startdate
        'row_arr(0)._JOB_REVISED_DATE = enddate


        Return True
    End Function

#End Region

End Class

<Serializable()> Public Class cChartRow
    Public _CMP_CODE As String = String.Empty
    Public _CampaignDesc As String = String.Empty
    Public _TrafficDesc As String = String.Empty
    Public _JOB_NUMBER As Integer = 0
    Public _JOB_DESC As String = String.Empty
    Public _PHASE_ORDER As Integer = 0
    Public _PHASE_DESC As String = String.Empty
    Public _TASK_START_DATE As Date
    Public _JOB_REVISED_DATE As Date
End Class