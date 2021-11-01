Imports System.Data
Imports System.Data.SqlClient
Imports Webvantage.MiscFN
Imports eWorld.UI.CollapsablePanel
Imports System.Text
Imports System.Drawing
Imports Telerik.Web.UI

<Serializable()> Public Class Job
#Region "Class Level Private/Protected Variables ......"
    Dim oSQL As SqlHelper
    Dim mConnString As String
    Protected mJOB_NUMBER As Integer = 0    '**PK
    Protected mOFFICE_CODE As String = String.Empty
    Protected mCL_CODE As String = String.Empty
    Protected mDIV_CODE As String = String.Empty
    Protected mPRD_CODE As String = String.Empty
    Protected mCMP_CODE As String = String.Empty
    Protected mSC_CODE As String = String.Empty
    Protected mUSER_ID As String = String.Empty
    Protected mCREATE_DATE As New Date
    Protected mJOB_DESC As String = String.Empty
    Protected mJOB_DATE_OPENED As New Date
    Protected mJOB_RUSH_CHARGES As Short = 0
    Protected mJOB_ESTIMATE_REQ As Short = 0
    Protected mJOB_COMMENTS As String = String.Empty
    Protected mJOB_COMMENTS_HTML As String = String.Empty
    Protected mJOB_CLI_REF As String = String.Empty
    Protected mBILL_COOP_CODE As String = String.Empty
    Protected mFORMAT_SC_CODE As String = String.Empty
    Protected mFORMAT_CODE As String = String.Empty
    Protected mCOMPLEX_CODE As String = String.Empty
    Protected mPROMO_CODE As String = String.Empty
    Protected mCMP_IDENTIFIER As Integer = 0
    Protected mCMP_LINE_NBR As Short = 0
    Protected mROWID As Integer = 0
    Protected mJOB_BILL_COMMENT As String = String.Empty
    Protected mFEE_JOB As Short = 0
    Protected mUDFTab As String = String.Empty
    Protected mUDF1 As wvUserDefinedField
    Protected mUDF2 As wvUserDefinedField
    Protected mUDF3 As wvUserDefinedField
    Protected mUDF4 As wvUserDefinedField
    Protected mUDF5 As wvUserDefinedField
    Protected mClientDesc As String = String.Empty
    Protected mDivisionDesc As String = String.Empty
    Protected mProductDesc As String = String.Empty
    Protected mSalesClassDesc As String = String.Empty
    Protected mCampaignDesc As String = String.Empty
    Protected mCoopBillingDesc As String = String.Empty
    Protected mSalesClassFormatDesc As String = String.Empty
    Protected mComplexityDesc As String = String.Empty
    Protected mPromotionDesc As String = String.Empty
    Protected mJobComponent As JobComponent
    Protected mJobComponents As JobsComponentCollection
    Protected mIsNew As Boolean = False
    Protected mTotalBudget As Decimal = 0.0

#End Region
#Region " Constructors "
    Public Sub New(ByVal ConnectionString As String)
        mConnString = ConnectionString
        mIsNew = True
        mJobComponent = New JobComponent(ConnectionString, Me)
    End Sub
#End Region
#Region " Business Properties and Methods "
    Public Overridable ReadOnly Property JOB_NUMBER() As Integer
        Get
            Return mJOB_NUMBER
        End Get
    End Property
    Public Overridable Property OFFICE_CODE() As String
        Get
            Return mOFFICE_CODE
        End Get
        Set(ByVal Value As String)
            If mOFFICE_CODE <> Value Then
                mOFFICE_CODE = Value
            End If
        End Set
    End Property
    Public Overridable Property CL_CODE() As String
        Get
            Return mCL_CODE
        End Get
        Set(ByVal Value As String)
            If mCL_CODE <> Value Then
                mCL_CODE = Value
            End If
        End Set
    End Property
    Public Overridable Property DIV_CODE() As String
        Get
            Return mDIV_CODE
        End Get
        Set(ByVal Value As String)
            If mDIV_CODE <> Value Then
                mDIV_CODE = Value
            End If
        End Set
    End Property
    Public Overridable Property PRD_CODE() As String
        Get
            Return mPRD_CODE
        End Get
        Set(ByVal Value As String)
            If mPRD_CODE <> Value Then
                mPRD_CODE = Value
            End If
        End Set
    End Property
    Public Overridable Property CMP_CODE() As String
        Get
            Return mCMP_CODE
        End Get
        Set(ByVal Value As String)
            If mCMP_CODE <> Value Then
                Dim oJob As cJobs = New cJobs(mConnString)
                mCMP_CODE = Value
                mCMP_IDENTIFIER = oJob.GetCampaignIdentifier(Value, mCL_CODE, mDIV_CODE, PRD_CODE)
            End If
        End Set
    End Property
    Public Overridable Property SC_CODE() As String
        Get
            Return mSC_CODE
        End Get
        Set(ByVal Value As String)
            If mSC_CODE <> Value Then
                mSC_CODE = Value
            End If
        End Set
    End Property
    Public Overridable Property USER_ID() As String
        Get
            Return mUSER_ID
        End Get
        Set(ByVal Value As String)
            If mUSER_ID <> Value Then
                mUSER_ID = Value
            End If
        End Set
    End Property
    Public Overridable Property CREATE_DATE() As Date
        Get
            Return mCREATE_DATE
        End Get
        Set(ByVal Value As Date)
            If mCREATE_DATE <> Value Then
                mCREATE_DATE = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_DESC() As String
        Get
            Return mJOB_DESC
        End Get
        Set(ByVal Value As String)
            If mJOB_DESC <> Value Then
                mJOB_DESC = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_DATE_OPENED() As Date
        Get
            Return mJOB_DATE_OPENED
        End Get
        Set(ByVal Value As Date)
            If mJOB_DATE_OPENED <> Value Then
                mJOB_DATE_OPENED = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_RUSH_CHARGES() As Short
        Get
            Return mJOB_RUSH_CHARGES
        End Get
        Set(ByVal Value As Short)
            If mJOB_RUSH_CHARGES <> Value Then
                mJOB_RUSH_CHARGES = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_ESTIMATE_REQ() As Short
        Get
            Return mJOB_ESTIMATE_REQ
        End Get
        Set(ByVal Value As Short)
            If mJOB_ESTIMATE_REQ <> Value Then
                mJOB_ESTIMATE_REQ = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_COMMENTS() As String
        Get
            Return mJOB_COMMENTS
        End Get
        Set(ByVal Value As String)
            If mJOB_COMMENTS <> Value Then
                mJOB_COMMENTS = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_COMMENTS_HTML() As String
        Get
            Return mJOB_COMMENTS_HTML
        End Get
        Set(ByVal Value As String)
            If mJOB_COMMENTS_HTML <> Value Then
                mJOB_COMMENTS_HTML = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_CLI_REF() As String
        Get
            Return mJOB_CLI_REF
        End Get
        Set(ByVal Value As String)
            If mJOB_CLI_REF <> Value Then
                mJOB_CLI_REF = Value
            End If
        End Set
    End Property
    Public Overridable Property BILL_COOP_CODE() As String
        Get
            Return mBILL_COOP_CODE
        End Get
        Set(ByVal Value As String)
            If mBILL_COOP_CODE <> Value Then
                mBILL_COOP_CODE = Value
            End If
        End Set
    End Property
    Public Overridable Property FORMAT_SC_CODE() As String
        Get
            Return mFORMAT_SC_CODE
        End Get
        Set(ByVal Value As String)
            If mFORMAT_SC_CODE <> Value Then
                mFORMAT_SC_CODE = Value
            End If
        End Set
    End Property
    Public Overridable Property FORMAT_CODE() As String
        Get
            Return mFORMAT_CODE
        End Get
        Set(ByVal Value As String)
            If mFORMAT_CODE <> Value Then
                mFORMAT_CODE = Value
            End If
        End Set
    End Property
    Public Overridable Property COMPLEX_CODE() As String
        Get
            Return mCOMPLEX_CODE
        End Get
        Set(ByVal Value As String)
            If mCOMPLEX_CODE <> Value Then
                mCOMPLEX_CODE = Value
            End If
        End Set
    End Property
    Public Overridable Property PROMO_CODE() As String
        Get
            Return mPROMO_CODE
        End Get
        Set(ByVal Value As String)
            If mPROMO_CODE <> Value Then
                mPROMO_CODE = Value
            End If
        End Set
    End Property
    Public Overridable Property CMP_IDENTIFIER() As Integer
        Get
            Return mCMP_IDENTIFIER
        End Get
        Set(ByVal Value As Integer)
            If mCMP_IDENTIFIER <> Value Then
                mCMP_IDENTIFIER = Value
            End If
        End Set
    End Property
    Public Overridable Property CMP_LINE_NBR() As Short
        Get
            Return mCMP_LINE_NBR
        End Get
        Set(ByVal Value As Short)
            If mCMP_LINE_NBR <> Value Then
                mCMP_LINE_NBR = Value
            End If
        End Set
    End Property
    Public Overridable Property ROWID() As Integer
        Get
            Return mROWID
        End Get
        Set(ByVal Value As Integer)
            If mROWID <> Value Then
                mROWID = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_BILL_COMMENT() As String
        Get
            Return mJOB_BILL_COMMENT
        End Get
        Set(ByVal Value As String)
            If mJOB_BILL_COMMENT <> Value Then
                mJOB_BILL_COMMENT = Value
            End If
        End Set
    End Property
    Public Overridable Property FEE_JOB() As Short
        Get
            Return mFEE_JOB
        End Get
        Set(ByVal Value As Short)
            If mFEE_JOB <> Value Then
                mFEE_JOB = Value
            End If
        End Set
    End Property
    Public Overridable Property UDFTab() As String
        Get
            Return mUDFTab
        End Get
        Set(ByVal Value As String)
            If mUDFTab <> Value Then
                mUDFTab = Value
            End If
        End Set
    End Property
    Public Overridable Property UDF1() As wvUserDefinedField
        Get
            Return mUDF1
        End Get
        Set(ByVal Value As wvUserDefinedField)
            mUDF1 = Value
        End Set
    End Property
    Public Overridable Property UDF2() As wvUserDefinedField
        Get
            Return mUDF2
        End Get
        Set(ByVal Value As wvUserDefinedField)
            mUDF2 = Value
        End Set
    End Property
    Public Overridable Property UDF3() As wvUserDefinedField
        Get
            Return mUDF3
        End Get
        Set(ByVal Value As wvUserDefinedField)
            mUDF3 = Value
        End Set
    End Property
    Public Overridable Property UDF4() As wvUserDefinedField
        Get
            Return mUDF4
        End Get
        Set(ByVal Value As wvUserDefinedField)
            mUDF4 = Value
        End Set
    End Property
    Public Overridable Property UDF5() As wvUserDefinedField
        Get
            Return mUDF5
        End Get
        Set(ByVal Value As wvUserDefinedField)
            mUDF5 = Value
        End Set
    End Property
    '--- Descriptions ---
    Public ReadOnly Property ClientDesc() As String
        Get
            Return mClientDesc
        End Get
    End Property
    Public ReadOnly Property DivisionDesc() As String
        Get
            Return mDivisionDesc
        End Get
    End Property
    Public ReadOnly Property ProductDesc() As String
        Get
            Return mProductDesc
        End Get
    End Property
    Public ReadOnly Property SalesClassDesc() As String
        Get
            Return mSalesClassDesc
        End Get
    End Property
    Public ReadOnly Property CampaignDesc() As String
        Get
            Return mCampaignDesc
        End Get
    End Property
    Public ReadOnly Property CoopBillingDesc() As String
        Get
            Return mCoopBillingDesc
        End Get
    End Property
    Public ReadOnly Property SalesClassFormatDesc() As String
        Get
            Return mSalesClassFormatDesc
        End Get
    End Property
    Public ReadOnly Property ComplexityDesc() As String
        Get
            Return mComplexityDesc
        End Get
    End Property
    Public ReadOnly Property PromotionDesc() As String
        Get
            Return mPromotionDesc
        End Get
    End Property
    Public ReadOnly Property TotalBudget() As Decimal
        Get
            Return mTotalBudget
        End Get
    End Property
    '--- Objects ---
    Public Property JobComponent() As JobComponent
        Get
            Return mJobComponent
        End Get
        Set(ByVal Value As JobComponent)
            mJobComponent = Value
        End Set
    End Property
    Public Property JobComponents() As JobsComponentCollection
        Get
            Return mJobComponents
        End Get
        Set(ByVal Value As JobsComponentCollection)
            mJobComponents = Value
        End Set
    End Property
#End Region
#Region " System.Object Overrides "
    Public Overrides Function ToString() As String
        'Return the Primary Key As a String
        Return mJOB_NUMBER.ToString
    End Function
#End Region
#Region " Methods "
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''     Private Subroutine for filling the job object 
    ''' </summary>
    ''' <param name="JobNumber"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[smoreno]	1/25/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub GetThisJob(ByVal JobNumber As Integer)

        CreateUserDefinedFields()

        Dim dr As SqlDataReader

        Dim parameterJobNo As New SqlParameter("@JOB_NUMBER", SqlDbType.Int, 0)
        parameterJobNo.Value = JobNumber

        dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_job_get_by_jobno", parameterJobNo)


        Try
            dr.Read()
            If dr.HasRows = True Then
                With dr
                    mJOB_NUMBER = .GetInt32(0)

                    If .IsDBNull(1) = False Then
                        mOFFICE_CODE = .GetString(1)
                    End If

                    mCL_CODE = .GetString(2)
                    mDIV_CODE = .GetString(3)
                    mPRD_CODE = .GetString(4)
                    If .IsDBNull(5) = False Then
                        mCMP_CODE = .GetString(5)
                    End If
                    If .IsDBNull(6) = False Then
                        mSC_CODE = .GetString(6)
                    End If
                    If .IsDBNull(7) = False Then
                        mUSER_ID = .GetString(7)
                    End If
                    If .IsDBNull(8) = False Then
                        mCREATE_DATE = .GetDateTime(8)
                    End If
                    If .IsDBNull(9) = False Then
                        mJOB_DESC = .GetString(9)
                    End If
                    If .IsDBNull(10) = False Then
                        mJOB_DATE_OPENED = .GetDateTime(10)
                    End If
                    If .IsDBNull(11) = False Then
                        mJOB_RUSH_CHARGES = .GetInt16(11)
                    End If
                    If .IsDBNull(12) = False Then
                        mJOB_ESTIMATE_REQ = .GetInt16(12)
                    End If
                    If .IsDBNull(13) = False Then
                        mJOB_COMMENTS = .GetString(13)
                    End If
                    If .IsDBNull(14) = False Then
                        mJOB_CLI_REF = .GetString(14)
                    End If
                    If .IsDBNull(15) = False Then
                        mBILL_COOP_CODE = .GetString(15)
                    End If
                    If .IsDBNull(16) = False Then
                        mFORMAT_SC_CODE = .GetString(16)
                    End If
                    If .IsDBNull(17) = False Then
                        mFORMAT_CODE = .GetString(17)
                    End If
                    If .IsDBNull(18) = False Then
                        mCOMPLEX_CODE = .GetString(18)
                    End If
                    If .IsDBNull(19) = False Then
                        mPROMO_CODE = .GetString(19)
                    End If
                    If .IsDBNull(20) = False Then
                        mCMP_IDENTIFIER = .GetInt32(20)
                    End If
                    If .IsDBNull(21) = False Then
                        mCMP_LINE_NBR = .GetInt16(21)
                    End If
                    If .IsDBNull(22) = False Then
                        mROWID = .GetInt32(22)
                    End If
                    If .IsDBNull(23) = False Then
                        mJOB_BILL_COMMENT = .GetString(23)
                    End If
                    If .IsDBNull(24) = False Then
                        mFEE_JOB = .GetInt16(24)
                    End If
                    If .IsDBNull(25) = False Then
                        mClientDesc = .GetString(25)
                    End If
                    If .IsDBNull(26) = False Then
                        mDivisionDesc = .GetString(26)
                    End If
                    If .IsDBNull(27) = False Then
                        mProductDesc = .GetString(27)
                    End If
                    If .IsDBNull(28) = False Then
                        mSalesClassDesc = .GetString(28)
                    End If
                    If .IsDBNull(29) = False Then
                        mCampaignDesc = .GetString(29)
                    End If
                    If .IsDBNull(30) = False Then
                        mCoopBillingDesc = .GetString(30)
                    End If
                    If .IsDBNull(31) = False Then
                        mSalesClassFormatDesc = .GetString(31)
                    End If
                    If .IsDBNull(32) = False Then
                        mComplexityDesc = .GetString(32)
                    End If
                    If .IsDBNull(33) = False Then
                        mPromotionDesc = .GetString(33)
                    End If
                    If Not Me.mUDF1 Is Nothing Then
                        If .IsDBNull(34) = False Then
                            mUDF1.Code = .GetString(34)
                        End If
                        If .IsDBNull(35) = False Then
                            mUDF1.Description = .GetString(35)
                        End If
                    End If
                    If Not Me.mUDF2 Is Nothing Then
                        If .IsDBNull(36) = False Then
                            mUDF2.Code = .GetString(36)
                        End If
                        If .IsDBNull(37) = False Then
                            mUDF2.Description = .GetString(37)
                        End If
                    End If
                    If Not Me.mUDF3 Is Nothing Then
                        If .IsDBNull(38) = False Then
                            mUDF3.Code = .GetString(38)
                        End If
                        If .IsDBNull(39) = False Then
                            mUDF3.Description = .GetString(39)
                        End If
                    End If
                    If Not Me.mUDF4 Is Nothing Then
                        If .IsDBNull(40) = False Then
                            mUDF4.Code = .GetString(40)
                        End If
                        If .IsDBNull(41) = False Then
                            mUDF4.Description = .GetString(41)
                        End If
                    End If
                    If Not Me.mUDF5 Is Nothing Then
                        If .IsDBNull(42) = False Then
                            mUDF5.Code = .GetString(42)
                        End If
                        If .IsDBNull(43) = False Then
                            mUDF5.Description = .GetString(43)
                        End If
                    End If
                    If .IsDBNull(44) = False Then
                        mTotalBudget = .GetDecimal(44)
                    End If
                    If .IsDBNull(45) = False Then
                        mJOB_COMMENTS_HTML = .GetString(45)
                    End If
                End With
            End If
        Finally
            dr.Close()
            mIsNew = False
        End Try

    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''     Public sub Fills Job and Component Property
    ''' </summary>
    ''' <param name="JobNumber"></param>
    ''' <param name="JobComponent"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[smoreno]	1/25/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overloads Sub GetJob(ByVal JobNumber As Integer, ByVal JobComponent As Integer)
        GetThisJob(JobNumber)
        mJobComponent.GetJobComponent(JobNumber, JobComponent)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''     Public subroutine that fills object and creates new Job component
    ''' </summary>
    ''' <param name="JobNumber"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[smoreno]	1/25/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overloads Sub GetJob(ByVal JobNumber As Integer)
        GetThisJob(JobNumber)
        mJobComponent = New JobComponent(mConnString, Me)
        mJobComponent.GetNextCompNumber()
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Public function that saves the job object
    ''' </summary>

    ''' <param name="Message"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[smoreno]	1/25/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function Save(ByRef Message As String) As Boolean

        If mIsNew = True Then
            'TODO Save New Job
            'usp_wv_job_new
        Else
            'Update Job 
            If Validate(Message) = False Then
                Return False
            End If
            Try
                SaveJob()
            Catch ex As Exception
                Message = Err.Description
                Return False
            End Try
        End If

        Return True

    End Function
    Private Function SaveJob() As Boolean
        Dim myReturn As Integer
        Dim arParamsJ(29) As SqlParameter

        Try
            Dim paramJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int, 0)
            paramJOB_NUMBER.Value = JOB_NUMBER
            arParamsJ(0) = paramJOB_NUMBER
            Dim paramOFFICE_CODE As New SqlParameter("@OFFICE_CODE", SqlDbType.VarChar, 4)
            paramOFFICE_CODE.Value = OFFICE_CODE
            arParamsJ(1) = paramOFFICE_CODE
            Dim paramCL_CODE As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
            paramCL_CODE.Value = CL_CODE
            arParamsJ(2) = paramCL_CODE
            Dim paramDIV_CODE As New SqlParameter("@DIV_CODE", SqlDbType.VarChar, 6)
            paramDIV_CODE.Value = DIV_CODE
            arParamsJ(3) = paramDIV_CODE
            Dim paramPRD_CODE As New SqlParameter("@PRD_CODE", SqlDbType.VarChar, 6)
            paramPRD_CODE.Value = PRD_CODE
            arParamsJ(4) = paramPRD_CODE

            'Modified by Sam Tran on 2006/05/04
            '	add check so that if empty, it inserts a null instead of an empty string
            If CMP_CODE = String.Empty OrElse CMP_CODE = "" OrElse CMP_CODE.Length < 1 Then 'its empty
                Dim paramCMP_CODE As New SqlParameter("@CMP_CODE", System.DBNull.Value)
                arParamsJ(5) = paramCMP_CODE
            Else
                Dim paramCMP_CODE As New SqlParameter("@CMP_CODE", SqlDbType.VarChar, 6)
                paramCMP_CODE.Value = CMP_CODE
                arParamsJ(5) = paramCMP_CODE
            End If


            Dim paramSC_CODE As New SqlParameter("@SC_CODE", SqlDbType.VarChar, 6)
            paramSC_CODE.Value = SC_CODE
            arParamsJ(6) = paramSC_CODE

            Dim paramUSER_ID As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
            paramUSER_ID.Value = USER_ID
            arParamsJ(7) = paramUSER_ID

            Dim paramCREATE_DATE As New SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime, 0)
            If CREATE_DATE.Equals(New Date) = False Then
                paramCREATE_DATE.Value = CREATE_DATE
            End If
            arParamsJ(8) = paramCREATE_DATE
            Dim paramJOB_DESC As New SqlParameter("@JOB_DESC", SqlDbType.VarChar, 60)
            paramJOB_DESC.Value = JOB_DESC
            arParamsJ(9) = paramJOB_DESC
            Dim paramJOB_DATE_OPENED As New SqlParameter("@JOB_DATE_OPENED", SqlDbType.SmallDateTime, 0)
            If JOB_DATE_OPENED.Equals(New Date) = False Then
                paramJOB_DATE_OPENED.Value = JOB_DATE_OPENED
            End If
            arParamsJ(10) = paramJOB_DATE_OPENED
            Dim paramJOB_RUSH_CHARGES As New SqlParameter("@JOB_RUSH_CHARGES", SqlDbType.SmallInt, 0)
            If JOB_RUSH_CHARGES <> 0 Then
                paramJOB_RUSH_CHARGES.Value = JOB_RUSH_CHARGES
            End If
            arParamsJ(11) = paramJOB_RUSH_CHARGES
            Dim paramJOB_ESTIMATE_REQ As New SqlParameter("@JOB_ESTIMATE_REQ", SqlDbType.SmallInt, 0)
            paramJOB_ESTIMATE_REQ.Value = JOB_ESTIMATE_REQ
            arParamsJ(12) = paramJOB_ESTIMATE_REQ
            Dim paramJOB_COMMENTS As New SqlParameter("@JOB_COMMENTS", SqlDbType.Text, 2147483647)
            If JOB_COMMENTS.Trim <> "" Then
                paramJOB_COMMENTS.Value = JOB_COMMENTS
            End If
            arParamsJ(13) = paramJOB_COMMENTS
            Dim paramJOB_CLI_REF As New SqlParameter("@JOB_CLI_REF", SqlDbType.VarChar, 30)
            If JOB_CLI_REF.Trim <> "" Then
                paramJOB_CLI_REF.Value = JOB_CLI_REF
            End If
            arParamsJ(14) = paramJOB_CLI_REF
            Dim paramBILL_COOP_CODE As New SqlParameter("@BILL_COOP_CODE", SqlDbType.VarChar, 6)
            If BILL_COOP_CODE.Trim <> "" Then
                paramBILL_COOP_CODE.Value = BILL_COOP_CODE
            End If
            arParamsJ(15) = paramBILL_COOP_CODE

            Dim paramFORMAT_SC_CODE As New SqlParameter("@FORMAT_SC_CODE", SqlDbType.VarChar, 6)
            If FORMAT_SC_CODE = "" Then
                paramFORMAT_SC_CODE.Value = DBNull.Value
            Else
                paramFORMAT_SC_CODE.Value = FORMAT_SC_CODE
            End If
            arParamsJ(16) = paramFORMAT_SC_CODE

            Dim paramFORMAT_CODE As New SqlParameter("@FORMAT_CODE", SqlDbType.VarChar, 8)
            If FORMAT_CODE.Trim <> "" Then
                paramFORMAT_CODE.Value = FORMAT_CODE
            End If

            'Modified by Sam Tran on 2006/06/19
            '	the next 2 params are how I found this function
            '   doesn't look like they are inserting to correct sproc vars???!!!!!
            arParamsJ(17) = paramFORMAT_CODE
            Dim paramCOMPLEX_CODE As New SqlParameter("@COMPLEX_CODE", SqlDbType.VarChar, 8)
            If COMPLEX_CODE <> "" Then
                paramCOMPLEX_CODE.Value = COMPLEX_CODE
            End If
            arParamsJ(18) = paramCOMPLEX_CODE
            Dim paramPROMO_CODE As New SqlParameter("@PROMO_CODE", SqlDbType.VarChar, 8)
            If PROMO_CODE <> "" Then
                paramPROMO_CODE.Value = PROMO_CODE
            End If
            arParamsJ(19) = paramPROMO_CODE

            'Modified by Sam Tran on 2006/05/04
            '   If stmnt to make sure null gets inserted instead of default zero	
            If CMP_IDENTIFIER = 0 Then
                Dim paramCMP_IDENTIFIER As New SqlParameter("@CMP_IDENTIFIER", System.DBNull.Value)
                arParamsJ(20) = paramCMP_IDENTIFIER
            Else
                Dim paramCMP_IDENTIFIER As New SqlParameter("@CMP_IDENTIFIER", SqlDbType.Int, 4)
                paramCMP_IDENTIFIER.Value = CMP_IDENTIFIER
                arParamsJ(20) = paramCMP_IDENTIFIER
            End If


            Dim paramCMP_LINE_NBR As New SqlParameter("@CMP_LINE_NBR", SqlDbType.SmallInt, 0)
            If CMP_LINE_NBR <> 0 Then
                paramCMP_LINE_NBR.Value = CMP_LINE_NBR
            End If
            arParamsJ(21) = paramCMP_LINE_NBR
            Dim paramJOB_BILL_COMMENT As New SqlParameter("@JOB_BILL_COMMENT", SqlDbType.VarChar, 254)
            If JOB_BILL_COMMENT.Trim <> "" Then
                paramJOB_BILL_COMMENT.Value = JOB_BILL_COMMENT
            End If
            arParamsJ(22) = paramJOB_BILL_COMMENT
            Dim paramFEE_JOB As New SqlParameter("@FEE_JOB", SqlDbType.SmallInt, 0)
            If FEE_JOB <> 0 Then
                paramFEE_JOB.Value = FEE_JOB
            End If
            arParamsJ(23) = paramFEE_JOB

            'User Defined Fields
            Dim paramUDF1 As New SqlParameter("@UDF1", SqlDbType.VarChar, 10)
            If Not Me.UDF1 Is Nothing Then
                If Me.UDF1.Code <> "" Then
                    paramUDF1.Value = Me.UDF1.Code
                End If
            End If
            arParamsJ(24) = paramUDF1
            Dim paramUDF2 As New SqlParameter("@UDF2", SqlDbType.VarChar, 10)
            If Not Me.UDF2 Is Nothing Then
                If Me.UDF2.Code <> "" Then
                    paramUDF2.Value = Me.UDF2.Code
                End If
            End If
            arParamsJ(25) = paramUDF2
            Dim paramUDF3 As New SqlParameter("@UDF3", SqlDbType.VarChar, 10)
            If Not Me.UDF3 Is Nothing Then
                If Me.UDF3.Code <> "" Then
                    paramUDF3.Value = Me.UDF3.Code
                End If
            End If
            arParamsJ(26) = paramUDF3
            Dim paramUDF4 As New SqlParameter("@UDF4", SqlDbType.VarChar, 10)
            If Not Me.UDF4 Is Nothing Then
                If Me.UDF4.Code <> "" Then
                    paramUDF4.Value = Me.UDF4.Code
                End If
            End If
            arParamsJ(27) = paramUDF4
            Dim paramUDF5 As New SqlParameter("@UDF5", SqlDbType.VarChar, 10)
            If Not Me.UDF5 Is Nothing Then
                If Me.UDF5.Code <> "" Then
                    paramUDF5.Value = Me.UDF5.Code
                End If
            End If
            arParamsJ(28) = paramUDF5

            myReturn = oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_job_update", arParamsJ)
        Catch ex As Exception
            Err.Raise(9999, Err.Source, Err.Description)
        End Try

        If myReturn > 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    Private Function Validate(ByRef Message As String) As Boolean
        Dim oValidations As cValidations = New cValidations(mConnString)
        Dim oReq As cRequired = New cRequired(mConnString)

        Try
            'Agency settings:

            'Client Reference
            If mJOB_CLI_REF = "" OrElse mJOB_CLI_REF = String.Empty Then
                If oReq.RequiredClientRef() = True Then
                    Message = "Client Ref is Required"
                    Return False
                End If
            Else    'member isn't empty
                'If oReq.IsUniqueClient(mJOB_CLI_REF, mJOB_NUMBER) = False Then
                '    Message = "A unique Client Ref is Required"
                '    Return False
                'End If
            End If

            'Campaign
            If mCMP_CODE = "" Then
                If oReq.RequiredCampaign(mCL_CODE) = True Then
                    Message = "Campaign is Required"
                    Return False
                End If
            Else
                If oValidations.ValidateCampaign(Me) = False Then
                    Message = "Invalid Campaign"
                    Return False
                End If
            End If

            'Coop Billing
            If mBILL_COOP_CODE = "" Then
                If oReq.RequiredCoopBilling(mCL_CODE) = True Then
                    Message = "Coop Billing is Required"
                    Return False
                End If
            Else
                If oValidations.ValidateCoopBilling(Me) = False Then
                    Message = "Invalid Coop Billing"
                    Return False
                End If
            End If
            '------------------
            'Sales Class Format
            '--------------------------------------------------------------
            'CTB-2006/06/20: As per Christy, all information should be save
            ' to FORMAT_CODE vice FORMAT_SC_CODE.
            '--------------------------------------------------------------
            If mFORMAT_CODE = "" Then
                If oReq.RequiredSalesClassFormat(mCL_CODE) = True Then
                    Message = "Sales Class Format is Required"
                    Return False
                End If
            Else
                If oValidations.ValidateSalesClassFormat(Me) = False Then
                    Message = "Invalid Sales Class Format"
                    Return False
                End If
            End If

            'Complexity
            If mCOMPLEX_CODE = "" Then
                If oReq.RequiredComplexity(mCL_CODE) = True Then
                    Message = "Complexity is Required"
                    Return False
                End If
            Else
                If oValidations.ValidateComplexity(Me) = False Then
                    Message = "Invalid Complexity"
                    Return False
                End If
            End If

            'Promotion
            If mPROMO_CODE = "" Then
                If oReq.RequiredPromotion(mCL_CODE) = True Then
                    Message = "Promotion is Required"
                    Return False
                End If
            Else
                If oValidations.ValidatePromotion(Me) = False Then
                    Message = "Invalid Promotion"
                    Return False
                End If
            End If

            'User Defined Fields
            If Not Me.UDF1 Is Nothing Then
                If Me.UDF1.Code = "" Then
                    If oReq.RequiredJobUDF1(Me.CL_CODE) = True Then
                        Message = Me.UDF1.Label & " is Required"
                        Return False
                    End If
                Else
                    If oValidations.ValidateJobUDF1(Me) = False Then
                        Message = "Invalid " & Me.UDF1.Label
                        Return False
                    End If
                End If
            End If
            If Not Me.UDF2 Is Nothing Then
                If Me.UDF2.Code = "" Then
                    If oReq.RequiredJobUDF2(Me.CL_CODE) = True Then
                        Message = Me.UDF2.Label & " is Required"
                        Return False
                    End If
                Else
                    If oValidations.ValidateJobUDF2(Me) = False Then
                        Message = "Invalid " & Me.UDF2.Label
                        Return False
                    End If
                End If
            End If
            If Not Me.UDF3 Is Nothing Then
                If Me.UDF3.Code = "" Then
                    If oReq.RequiredJobUDF3(Me.CL_CODE) = True Then
                        Message = Me.UDF3.Label & " is Required"
                        Return False
                    End If
                Else
                    If oValidations.ValidateJobUDF3(Me) = False Then
                        Message = "Invalid " & Me.UDF3.Label
                        Return False
                    End If
                End If
            End If
            If Not Me.UDF4 Is Nothing Then
                If Me.UDF4.Code = "" Then
                    If oReq.RequiredJobUDF4(Me.CL_CODE) = True Then
                        Message = Me.UDF4.Label & " is Required"
                        Return False
                    End If
                Else
                    If oValidations.ValidateJobUDF4(Me) = False Then
                        Message = "Invalid " & Me.UDF4.Label
                        Return False
                    End If
                End If
            End If
            If Not Me.UDF5 Is Nothing Then
                If Me.UDF5.Code = "" Then
                    If oReq.RequiredJobUDF5(Me.CL_CODE) = True Then
                        Message = Me.UDF5.Label & " is Required"
                        Return False
                    End If
                Else
                    If oValidations.ValidateJobUDF5(Me) = False Then
                        Message = "Invalid " & Me.UDF5.Label
                        Return False
                    End If
                End If
            End If
        Catch
            Message = Err.Description
            Return False
        End Try

        Return True

    End Function
    Private Sub CreateUserDefinedFields()
        Dim dr As SqlDataReader
        Dim ThisLabel As String
        Dim ThisUDF As wvUserDefinedField


        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_job_get_udf_labels")

            Do While dr.Read()
                ThisLabel = dr.GetString(0)
                Select Case ThisLabel
                    Case "JOB_LOG_TAB"
                        mUDFTab = dr.GetString(1)
                    Case "JOB_LOG_UDV1"
                        If dr.IsDBNull(1) = False Then
                            ThisUDF = New wvUserDefinedField
                            ThisUDF.Label = dr.GetString(1)
                            mUDF1 = ThisUDF
                        Else
                            mUDF1 = Nothing
                        End If
                    Case "JOB_LOG_UDV2"
                        If dr.IsDBNull(1) = False Then
                            ThisUDF = New wvUserDefinedField
                            ThisUDF.Label = dr.GetString(1)
                            mUDF2 = ThisUDF
                        Else
                            mUDF2 = Nothing
                        End If
                    Case "JOB_LOG_UDV3"
                        If dr.IsDBNull(1) = False Then
                            ThisUDF = New wvUserDefinedField
                            ThisUDF.Label = dr.GetString(1)
                            mUDF3 = ThisUDF
                        Else
                            mUDF3 = Nothing
                        End If
                    Case "JOB_LOG_UDV4"
                        If dr.IsDBNull(1) = False Then
                            ThisUDF = New wvUserDefinedField
                            ThisUDF.Label = dr.GetString(1)
                            mUDF4 = ThisUDF
                        Else
                            mUDF4 = Nothing
                        End If
                    Case "JOB_LOG_UDV5"
                        If dr.IsDBNull(1) = False Then
                            ThisUDF = New wvUserDefinedField
                            ThisUDF.Label = dr.GetString(1)
                            mUDF5 = ThisUDF
                        Else
                            mUDF5 = Nothing
                        End If
                End Select
            Loop
        Catch
            Err.Raise(Err.Number, "Class:Job Routine:CreateUserDefinedFields", Err.Description)
        End Try
    End Sub
#End Region
End Class

<Serializable()> Public Class JobVersion

#Region " Vars "

    Private mConnString As String
    Private oSQL As SqlHelper
    Private TitleSpacer As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
    Private RowSpacer As String = "&nbsp;&nbsp;"
    Private IndentSpacer As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
    Private count As Integer = 0
    Private jobnum As Integer
    Private jobcompnum As Integer
    Private dsComments As DataSet
    Private client As String
    Private versionNum As Integer
    Private revisionNum As Integer
    Private rwindow As Telerik.Web.UI.RadWindow
    Private dsText As DataSet

#End Region

#Region " DB Related "

    Public Sub New(ByVal ConnectionString As String)
        mConnString = ConnectionString
    End Sub

    Public Function GetJobVersDtl(ByVal jobverhdr As Integer) As SqlDataReader
        Try
            Dim arParams(1) As SqlParameter
            Dim dr As SqlDataReader


            Dim paramJobVersion As New SqlParameter("@jobverhdr", SqlDbType.Int)
            paramJobVersion.Value = jobverhdr
            arParams(0) = paramJobVersion

            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_getJobVers_dtl", arParams)

            Return dr

        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetJobVersDtl!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())

        End Try
    End Function

    'job version report
    Public Function getArptJobVersion(ByVal jobverhdr As Integer) As DataSet
        Try
            Dim arParams(1) As SqlParameter
            Dim dr As DataSet

            Dim paramJobVersion As New SqlParameter("@JobVersHdrID", SqlDbType.Int)
            paramJobVersion.Value = jobverhdr
            arParams(0) = paramJobVersion

            dr = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_get_arptJobVersion", arParams)

            Return dr

        Catch ex As Exception
            Err.Raise(Err.Number, "Error getArptJobVersion!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())

        End Try
    End Function

    'job versions report
    Public Function getArptJobVersions(ByVal job As Integer, ByVal comp As Integer) As DataSet
        Try
            Dim arParams(1) As SqlParameter
            Dim dr As DataSet

            Dim paramJob As New SqlParameter("@Job", SqlDbType.Int)
            paramJob.Value = job
            arParams(0) = paramJob

            Dim paramJComp As New SqlParameter("@Comp", SqlDbType.Int)
            paramJComp.Value = comp
            arParams(1) = paramJComp

            dr = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_get_arptJobVersions", arParams)

            Return dr

        Catch ex As Exception
            Err.Raise(Err.Number, "Error getArptJobVersions!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())

        End Try
    End Function

    Public Function GetJobVerTmplt_dd() As SqlDataReader
        Try

            Dim dr As SqlDataReader

            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobVerTmplt")

            Return dr

        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetJobVerTmplt_dd!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())

        End Try
    End Function

    Public Function InsJobVers(ByVal job As Integer, ByVal comp As Int16, ByVal tmpltCode As String, ByVal user As String, Optional ByVal cpid As Integer = 0) As SqlDataReader
        Try
            Dim arParams(6) As SqlParameter
            Dim dr As SqlDataReader

            Dim paramJob As New SqlParameter("@JOB", SqlDbType.Int)
            paramJob.Value = job
            arParams(0) = paramJob

            Dim paramComp As New SqlParameter("@COMP", SqlDbType.SmallInt)
            paramComp.Value = comp
            arParams(1) = paramComp

            Dim paramTmpltCode As New SqlParameter("@TMPLT_CODE", SqlDbType.VarChar, 6)
            paramTmpltCode.Value = tmpltCode
            arParams(2) = paramTmpltCode

            Dim paramUser As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
            paramUser.Value = user
            arParams(3) = paramUser

            Dim paramCPID As New SqlParameter("@CPID", SqlDbType.Int)
            paramCPID.Value = cpid
            arParams(4) = paramCPID

            Dim paramCreateDate As New SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
            paramCreateDate.Value = cEmployee.TimeZoneTodayTime
            arParams(6) = paramCreateDate

            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_JobVerIns", arParams)

            Return dr

        Catch ex As Exception
            Err.Raise(Err.Number, "Error InsJobVers!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())

        End Try

    End Function

    Public Function ExistingTemplates(ByVal job As Integer, ByVal comp As Int16) As Boolean

        Dim i As Integer = 0
        Try
            i = CType(oSQL.ExecuteScalar(mConnString, CommandType.Text, String.Format("SELECT COUNT(1) FROM JOB_VER_HDR JVH, JOB_VER_TMPLT_HDR JVTH WHERE JVH.JV_TMPLT_CODE = JVTH.JV_TMPLT_CODE AND JVH.JOB_NUMBER = {0} AND JVH.JOB_COMPONENT_NBR = {1};", job, comp)), Integer)

            Return i > 0

        Catch ex As Exception

            Return False

        End Try

    End Function

    Public Function GetJVDescriptions(ByVal job As Integer, ByVal comp As Int16, ByVal jvh_id As Integer) As SqlDataReader
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper

        SQL_STRING = "SELECT JL.JOB_DESC, JC.JOB_COMP_DESC, JVH.JOB_VER_DESC, JVTH.JV_TMPLT_DESC, JVH.JOB_VER_SEQ_NBR, JVH.JV_TMPLT_CODE"
        SQL_STRING += " FROM JOB_LOG JL, JOB_COMPONENT JC, JOB_VER_HDR JVH, JOB_VER_TMPLT_HDR JVTH"
        SQL_STRING += " WHERE JL.JOB_NUMBER = JC.JOB_NUMBER "
        SQL_STRING += " AND JC.JOB_NUMBER = JVH.JOB_NUMBER"
        SQL_STRING += " AND JC.JOB_COMPONENT_NBR = JVH.JOB_COMPONENT_NBR"
        SQL_STRING += " AND JVH.JV_TMPLT_CODE = JVTH.JV_TMPLT_CODE"
        SQL_STRING += " AND JC.JOB_NUMBER = " & job
        SQL_STRING += " AND JC.JOB_COMPONENT_NBR = " & comp
        SQL_STRING += " AND JVH.JOB_VER_HDR_ID = " & jvh_id

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL_STRING)
            Return dr

        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetJVDescriptions!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try

    End Function

    Public Function GetJVjob(ByVal jvh_id As Integer)
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper
        Dim job As Integer

        SQL_STRING = "SELECT JVH.JOB_NUMBER"
        SQL_STRING += " FROM JOB_VER_HDR JVH"
        SQL_STRING += " WHERE JVH.JOB_VER_HDR_ID = " & jvh_id

        Try
            job = oSQL.ExecuteScalar(mConnString, CommandType.Text, SQL_STRING)
            Return job

        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetJVJob!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try

    End Function

    Public Function GetJVRequestDescriptions(ByVal jvh_id As Integer) As SqlDataReader
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper

        SQL_STRING = "SELECT JVH.CL_CODE, C.CL_NAME, JVH.DIV_CODE, D.DIV_NAME, JVH.PRD_CODE, PRD_DESCRIPTION, JVH.JOB_VER_DESC, JVTH.JV_TMPLT_DESC, JVH.JOB_VER_SEQ_NBR, JVH.JV_TMPLT_CODE"
        SQL_STRING += " FROM JOB_VER_HDR JVH INNER JOIN JOB_VER_TMPLT_HDR JVTH ON JVH.JV_TMPLT_CODE = JVTH.JV_TMPLT_CODE"
        SQL_STRING += " LEFT OUTER JOIN PRODUCT P ON P.CL_CODE = JVH.CL_CODE AND P.DIV_CODE = JVH.DIV_CODE AND P.PRD_CODE = JVH.PRD_CODE"
        SQL_STRING += " LEFT OUTER JOIN DIVISION D ON D.CL_CODE = P.CL_CODE AND D.DIV_CODE = P.DIV_CODE"
        SQL_STRING += " LEFT OUTER JOIN CLIENT C ON D.CL_CODE = C.CL_CODE"
        SQL_STRING += " WHERE JVH.JOB_VER_HDR_ID = " & jvh_id

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL_STRING)
            Return dr

        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetJVRequestDescriptions!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try

    End Function

    Public Function GetJobRequests(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal StartDate As String, ByVal EndDate As String, ByVal search As Boolean, ByVal ExcludeCompletedJobRequests As Boolean, ByVal isClientPortal As Boolean, Optional ByVal cpid As Integer = 0) As DataTable
        Dim SQL_STRING As String
        Dim dt As DataTable
        Dim oSQL As SqlHelper

        Dim Employeeoffice As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing
        Dim UserClientDivisionProductAccess As System.Collections.Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(mConnString, HttpContext.Current.Session("UserCode"))
            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(mConnString, HttpContext.Current.Session("UserCode"))
                Employeeoffice = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, HttpContext.Current.Session("EmpCode")).ToList
                UserClientDivisionProductAccess = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, HttpContext.Current.Session("UserCode")).ToList
            End Using
        End Using

        SQL_STRING = "SELECT JVH.JOB_VER_HDR_ID, JVH.CL_CODE, C.CL_NAME, JVH.DIV_CODE, D.DIV_NAME, JVH.PRD_CODE, PRD_DESCRIPTION, JVH.JOB_VER_DESC, JVTH.JV_TMPLT_DESC, JVH.JOB_VER_SEQ_NBR, JVH.JV_TMPLT_CODE, JVH.CREATE_DATE,"
        SQL_STRING += " JVH.JOB_NUMBER, J.JOB_DESC, JVH.JOB_COMPONENT_NBR, JC.JOB_COMP_DESC, CASE WHEN JVH.JOB_NUMBER = 0 THEN 'Pending' ELSE 'Completed' END AS STATUS"
        SQL_STRING += " FROM JOB_VER_HDR JVH INNER JOIN JOB_VER_TMPLT_HDR JVTH ON JVH.JV_TMPLT_CODE = JVTH.JV_TMPLT_CODE"
        SQL_STRING += " LEFT OUTER JOIN PRODUCT P ON P.CL_CODE = JVH.CL_CODE AND P.DIV_CODE = JVH.DIV_CODE AND P.PRD_CODE = JVH.PRD_CODE"
        SQL_STRING += " LEFT OUTER JOIN DIVISION D ON D.CL_CODE = P.CL_CODE AND D.DIV_CODE = P.DIV_CODE"
        SQL_STRING += " LEFT OUTER JOIN CLIENT C ON D.CL_CODE = C.CL_CODE"
        SQL_STRING += " LEFT OUTER JOIN JOB_LOG J ON J.JOB_NUMBER = JVH.JOB_NUMBER"
        SQL_STRING += " LEFT OUTER JOIN JOB_COMPONENT JC On JC.JOB_NUMBER = JVH.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = JVH.JOB_COMPONENT_NBR"
        If isClientPortal = True Then
            SQL_STRING += " INNER JOIN CP_SEC_CLIENT On JVH.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JVH.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND JVH.PRD_CODE = CP_SEC_CLIENT.PRD_CODE"
        End If
        If Employeeoffice IsNot Nothing AndAlso Employeeoffice.Count > 0 Then
            SQL_STRING += " INNER JOIN EMP_OFFICE On P.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = '" & HttpContext.Current.Session("EmpCode") & "'"
        End If
        If UserClientDivisionProductAccess IsNot Nothing AndAlso UserClientDivisionProductAccess.Count > 0 Then
            SQL_STRING += " INNER JOIN SEC_CLIENT ON P.CL_CODE = SEC_CLIENT.CL_CODE AND P.DIV_CODE = SEC_CLIENT.DIV_CODE AND P.PRD_CODE = SEC_CLIENT.PRD_CODE"
        End If
        SQL_STRING += " WHERE JVH.CL_CODE IS NOT NULL AND (JVH.CREATE_DATE BETWEEN '" & StartDate & "' AND '" & EndDate & "')"
        If ExcludeCompletedJobRequests = True Then
            SQL_STRING += " AND JVH.JOB_NUMBER = 0"
        End If
        'If search = False Then
        '    SQL_STRING += " WHERE JVH.CL_CODE IS NOT NULL"
        'Else
        '    SQL_STRING += " WHERE JVH.JOB_NUMBER = 0"
        'End If
        If ClientCode <> "" Then
            SQL_STRING += " AND JVH.CL_CODE = '" & ClientCode & "'"
        End If
        If DivisionCode <> "" Then
            SQL_STRING += " AND JVH.DIV_CODE = '" & DivisionCode & "'"
        End If
        If ProductCode <> "" Then
            SQL_STRING += " AND JVH.PRD_CODE = '" & ProductCode & "'"
        End If
        If isClientPortal = True Then
            SQL_STRING += " AND CP_SEC_CLIENT.CDP_CONTACT_ID = " & cpid
        End If
        If UserClientDivisionProductAccess IsNot Nothing AndAlso UserClientDivisionProductAccess.Count > 0 Then
            SQL_STRING += " AND (UPPER(SEC_CLIENT.USER_ID) = UPPER('" & HttpContext.Current.Session("UserCode") & "')) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)"
        End If
        SQL_STRING += " ORDER BY JVH.CREATE_DATE DESC"
        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.Text, SQL_STRING, "dt")
            Return dt

        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetJobRequests!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try

    End Function
    Public Function GetJobRequestsDO(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal StartDate As String, ByVal EndDate As String, ByVal search As String, ByVal ExcludeCompletedJobRequests As Boolean, ByVal DesktopObject As String, ByVal isClientPortal As Boolean, Optional ByVal cpid As Integer = 0) As DataTable
        Dim SQL_STRING As String
        Dim dt As DataTable
        Dim oSQL As SqlHelper

        Dim Employeeoffice As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing
        Dim UserClientDivisionProductAccess As System.Collections.Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(mConnString, HttpContext.Current.Session("UserCode"))
            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(mConnString, HttpContext.Current.Session("UserCode"))
                Employeeoffice = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, HttpContext.Current.Session("EmpCode")).ToList
                UserClientDivisionProductAccess = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, HttpContext.Current.Session("UserCode")).ToList
            End Using
        End Using

        SQL_STRING = "SELECT JVH.JOB_VER_HDR_ID, JVH.CL_CODE, C.CL_NAME, JVH.DIV_CODE, D.DIV_NAME, JVH.PRD_CODE, PRD_DESCRIPTION, JVH.JOB_VER_DESC, JVTH.JV_TMPLT_DESC, JVH.JOB_VER_SEQ_NBR, JVH.JV_TMPLT_CODE, JVH.CREATE_DATE,"
        SQL_STRING += " JVH.JOB_NUMBER, J.JOB_DESC, JVH.JOB_COMPONENT_NBR, JC.JOB_COMP_DESC, CASE WHEN JVH.JOB_NUMBER = 0 THEN 'Pending' ELSE 'Completed' END AS STATUS,"
        SQL_STRING += " CASE WHEN CAST(JVH.CREATED_BY_CP As VARCHAR) = '0' THEN COALESCE((RTRIM(E.EMP_FNAME) + ' '),'') + COALESCE((E.EMP_MI + '. '),'') + COALESCE(E.EMP_LNAME,'') ELSE CU.FULL_NAME END AS CREATED_BY"
        SQL_STRING += " FROM JOB_VER_HDR JVH INNER JOIN JOB_VER_TMPLT_HDR JVTH On JVH.JV_TMPLT_CODE = JVTH.JV_TMPLT_CODE"
        SQL_STRING += " LEFT OUTER JOIN PRODUCT P On P.CL_CODE = JVH.CL_CODE AND P.DIV_CODE = JVH.DIV_CODE AND P.PRD_CODE = JVH.PRD_CODE"
        SQL_STRING += " LEFT OUTER JOIN DIVISION D On D.CL_CODE = P.CL_CODE AND D.DIV_CODE = P.DIV_CODE"
        SQL_STRING += " LEFT OUTER JOIN CLIENT C On D.CL_CODE = C.CL_CODE"
        SQL_STRING += " LEFT OUTER JOIN JOB_LOG J On J.JOB_NUMBER = JVH.JOB_NUMBER"
        SQL_STRING += " LEFT OUTER JOIN JOB_COMPONENT JC On JC.JOB_NUMBER = JVH.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = JVH.JOB_COMPONENT_NBR"
        SQL_STRING += " LEFT OUTER JOIN SEC_USER SU On SU.USER_CODE = JVH.CREATED_BY"
        SQL_STRING += " LEFT OUTER JOIN EMPLOYEE E On E.EMP_CODE = SU.EMP_CODE"
        SQL_STRING += " LEFT OUTER JOIN CP_USER CU On CU.CDP_CONTACT_ID = JVH.CREATED_BY_CP"
        If isClientPortal = True Then
            SQL_STRING += " INNER JOIN CP_SEC_CLIENT On JVH.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JVH.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND JVH.PRD_CODE = CP_SEC_CLIENT.PRD_CODE"
        End If
        If Employeeoffice IsNot Nothing AndAlso Employeeoffice.Count > 0 Then
            SQL_STRING += " INNER JOIN EMP_OFFICE On P.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = '" & HttpContext.Current.Session("EmpCode") & "'"
        End If
        If UserClientDivisionProductAccess IsNot Nothing AndAlso UserClientDivisionProductAccess.Count > 0 Then
            SQL_STRING += " INNER JOIN SEC_CLIENT ON P.CL_CODE = SEC_CLIENT.CL_CODE AND P.DIV_CODE = SEC_CLIENT.DIV_CODE AND P.PRD_CODE = SEC_CLIENT.PRD_CODE"
        End If
        SQL_STRING += " WHERE JVH.CL_CODE IS NOT NULL AND (JVH.CREATE_DATE BETWEEN '" & StartDate & "' AND '" & EndDate & "')"
        If ExcludeCompletedJobRequests = True Then
            SQL_STRING += " AND JVH.JOB_NUMBER = 0"
        End If
        If search <> "" Then
            SQL_STRING += " AND (LOWER(Cast(JVH.JOB_NUMBER AS VARCHAR)) Like '%' + LOWER('" & search & "') + '%'"
            SQL_STRING += " OR LOWER(J.JOB_DESC) LIKE '%' + LOWER('" & search & "') + '%'"
            SQL_STRING += " OR LOWER(Cast(JVH.JOB_COMPONENT_NBR As VARCHAR)) Like '%' + LOWER('" & search & "') + '%' "
            SQL_STRING += " OR LOWER(JC.JOB_COMP_DESC) LIKE '%' + LOWER('" & search & "') + '%'"
            SQL_STRING += " OR LOWER(JVH.CL_CODE) Like '%' + LOWER('" & search & "') + '%'"
            SQL_STRING += " OR LOWER(C.CL_NAME) LIKE '%' + LOWER('" & search & "') + '%'"
            SQL_STRING += " OR LOWER(JVH.DIV_CODE) Like '%' + LOWER('" & search & "') + '%'"
            SQL_STRING += " OR LOWER(D.DIV_NAME) LIKE '%' + LOWER('" & search & "') + '%'"
            SQL_STRING += " OR LOWER(JVH.PRD_CODE) Like '%' + LOWER('" & search & "') + '%'"
            SQL_STRING += " OR LOWER(PRD_DESCRIPTION) LIKE '%' + LOWER('" & search & "') + '%'"
            SQL_STRING += " OR LOWER(JVH.JOB_VER_DESC) Like '%' + LOWER('" & search & "') + '%') "
        End If
        If ClientCode <> "" Then
            SQL_STRING += " AND JVH.CL_CODE = '" & ClientCode & "'"
        End If
        If DivisionCode <> "" Then
            SQL_STRING += " AND JVH.DIV_CODE = '" & DivisionCode & "'"
        End If
        If ProductCode <> "" Then
            SQL_STRING += " AND JVH.PRD_CODE = '" & ProductCode & "'"
        End If
        If isClientPortal = True Then
            SQL_STRING += " AND CP_SEC_CLIENT.CDP_CONTACT_ID = " & cpid
            SQL_STRING += " AND JVH.CREATED_BY_CP = " & cpid
        ElseIf DesktopObject = "My" Then
            SQL_STRING += " AND ((UPPER(JVH.CREATED_BY) = UPPER('" & HttpContext.Current.Session("UserCode") & "')) OR CU.AGENCY_CONTACT_CODE = '" & HttpContext.Current.Session("EmpCode") & "') "
        End If
        If UserClientDivisionProductAccess IsNot Nothing AndAlso UserClientDivisionProductAccess.Count > 0 Then
            SQL_STRING += " AND (UPPER(SEC_CLIENT.USER_ID) = UPPER('" & HttpContext.Current.Session("UserCode") & "')) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)"
        End If
        SQL_STRING += " ORDER BY JVH.CREATE_DATE DESC"
        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.Text, SQL_STRING, "dt")
            Return dt

        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetJobRequests!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try

    End Function
    Public Function GetAgencyDesc() As String

        Dim AgencyDesc As String = "Versions"
        Dim SessionKey As String = "GetAgencyJobVersionDesc"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then

            Dim SQL_STRING As String
            Dim dr As SqlDataReader
            Dim oSQL As SqlHelper

            SQL_STRING = "SELECT AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'JOB_VERSION_DESC';"

            Try

                dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL_STRING)

                If dr.HasRows Then

                    dr.Read()

                    If IsDBNull(dr.GetValue(0)) Then        'AGY_SETTINGS_VALUE

                        If IsDBNull(dr.GetValue(1)) Then    'AGY_SETTINGS_DEF

                            AgencyDesc = "Versions"

                        Else

                            AgencyDesc = dr.GetValue(1)

                        End If
                    Else

                        AgencyDesc = dr.GetValue(0)

                    End If

                End If

            Catch ex As Exception

                AgencyDesc = "Versions"

            End Try

            HttpContext.Current.Session(SessionKey) = AgencyDesc

        Else

            AgencyDesc = HttpContext.Current.Session(SessionKey)

        End If

        Return AgencyDesc

    End Function

    Public Function CopyJobVers(ByVal job As Integer, ByVal comp As Int16, ByVal tmpltCode As String, ByVal hdrIdCopy As Integer, ByVal user As String, Optional ByVal cpid As Integer = 0) As SqlDataReader
        Try
            Dim arParams(6) As SqlParameter
            Dim dr As SqlDataReader

            Dim paramJob As New SqlParameter("@JOB", SqlDbType.Int)
            paramJob.Value = job
            arParams(0) = paramJob

            Dim paramComp As New SqlParameter("@COMP", SqlDbType.SmallInt)
            paramComp.Value = comp
            arParams(1) = paramComp

            Dim paramTmpltCode As New SqlParameter("@TMPLT_CODE", SqlDbType.VarChar, 6)
            paramTmpltCode.Value = tmpltCode
            arParams(2) = paramTmpltCode

            Dim paramhdrIdCopy As New SqlParameter("@JOB_VER_HDR_ID_COPY", SqlDbType.Int)
            paramhdrIdCopy.Value = hdrIdCopy
            arParams(3) = paramhdrIdCopy

            Dim paramUser As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
            paramUser.Value = user
            arParams(4) = paramUser

            Dim paramCPID As New SqlParameter("@CPID", SqlDbType.Int)
            paramCPID.Value = cpid
            arParams(5) = paramCPID

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_JobVerCopy", arParams)
            Catch ex As Exception

            End Try


            Return dr

        Catch ex As Exception
            Err.Raise(Err.Number, "Error CopyJobVers!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())

        End Try

    End Function

    Public Function GetJobTemplateItems(ByVal DatabaseTypeID As Integer, ByVal JobversionDatabaseTypeID As Integer) As DataTable
        Dim SQL_STRING As String
        Dim dt As DataTable
        Dim oSQL As SqlHelper

        SQL_STRING = "SELECT ITEM_CODE AS Code, CASE WHEN ADVAN_DTYPE_ID = 1 THEN ITEM_DESC + ' (' + CAST(JT_DTYPE_PREC AS VARCHAR) + ')' ELSE ITEM_DESC END AS Description"
        SQL_STRING += " FROM JOB_TMPLT_ITEMS "
        SQL_STRING += " WHERE JOB_TMPLT_ITEMS.ADVAN_DTYPE_ID = " & DatabaseTypeID.ToString & ""
        SQL_STRING += " ORDER BY JOB_TMPLT_ITEMS.ITEM_DESC "
        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.Text, SQL_STRING, "dt")
            Return dt

        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetJobTemplateItems!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try

    End Function

    Public Function UpdateJobTemplatePerJVMapping(ByVal JobVersionHeaderID As Integer, ByVal FromApp As String) As Boolean
        Try

            Dim arParams(4) As SqlParameter

            Dim paramJobNumber As New SqlParameter("@JobVersionHeaderID", SqlDbType.Int)
            paramJobNumber.Value = JobVersionHeaderID
            arParams(0) = paramJobNumber

            Dim paramFromApp As New SqlParameter("@FromApp", SqlDbType.VarChar)
            paramFromApp.Value = FromApp
            arParams(1) = paramFromApp

            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_UpdateFields_By_Mapping", arParams)
            Return True
        Catch ex As Exception
            Return False
            Err.Raise(Err.Number, "Error GetJobTemplateComments!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

#End Region


End Class

<Serializable()> Public Class JobCollection
    Inherits CollectionBase
    Default Public Property Item(ByVal index As Integer) As Job
        Get
            Return CType(List(index), Job)
        End Get
        Set(ByVal Value As Job)
            List(index) = Value
        End Set
    End Property
    Public Function Add(ByVal value As Job) As Integer
        Return List.Add(value)
    End Function
    Public Function IndexOf(ByVal value As Job) As Integer
        Return List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As Job)
        List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As Job)
        List.Remove(value)
    End Sub
    Public Function Contains(ByVal value As Job) As Boolean
        Return List.Contains(value)
    End Function
End Class

#Region "Job Component Objects"
'***************************************** Job Component ************************************
''' -----------------------------------------------------------------------------

''' -----------------------------------------------------------------------------
<Serializable()> Public Class JobComponent
#Region "Class Level Private/Protected Variables ......"
    Dim oSQL As SqlHelper
    Dim mConnString As String
    Protected mJOB_NUMBER As Integer = 0    '**PK
    Protected mJOB_COMPONENT_NBR As Short = 0    '**PK
    Protected mClient As String = String.Empty
    Protected mDivision As String = String.Empty
    Protected mProduct As String = String.Empty
    Protected mJOB_BILL_HOLD As Short = 0
    Protected mEMP_CODE As String = String.Empty
    Protected mJOB_COMP_DATE As New Date
    Protected mJOB_FIRST_USE_DATE As New Date
    Protected mSTART_DATE As New Date
    Protected mJOB_AD_SIZE As String = String.Empty
    Protected mJOB_SPEC_TYPE As String = "0"
    Protected mDP_TM_CODE As String = String.Empty
    Protected mJOB_MARKUP_PCT As Decimal = 0.0    '***************
    Protected mCREATIVE_INSTR As String = String.Empty
    Protected mCREATIVE_INSTR_HTML As String = String.Empty
    Protected mJOB_LAYOUT_THUMB As Short = 0
    Protected mJOB_LAYOUT_ROUGH As Short = 0
    Protected mJOB_LAYOUT_COMP As Short = 0
    Protected mJOB_LAYOUT_NONE As Short = 0
    Protected mJOB_LAYOUT_SPECIAL As Short = 0
    Protected mJOB_LAYOUT_SPC_EXP As String = String.Empty
    Protected mJOB_PROCESS_CONTRL As Short = 1
    Protected mJOB_COMP_DESC As String = String.Empty
    Protected mJOB_COMP_COMMENTS As String = String.Empty
    Protected mJC_COMMENTS_HTML As String = String.Empty
    Protected mJOB_COMP_BUDGET_AM As Decimal = 0
    'Modified by Sam Tran on 2006/05/11
    '	
    Protected mJOB_COMP_ACCT_NonBillable As Short = 0
    Protected mJOB_COMP_ACCT_Markup As String = String.Empty

    Protected mESTIMATE_NUMBER As Integer = 0
    Protected mEST_COMPONENT_NBR As Short = 0
    Protected mBILLING_USER As String = String.Empty
    Protected mAB_FLAG As Short = 0
    Protected mJOB_DEL_INSTRUCT As String = String.Empty
    Protected mJOB_DEL_INSTR_HTML As String = String.Empty
    Protected mJT_CODE As String = String.Empty
    Protected mTAX_FLAG As Short = 0       '******************
    'Modified by Sam Tran on 2006/06/21
    '	Added the one var below to handle having a null flag in db
    Protected mStrTAX_FLAG As String = String.Empty
    Protected mTAX_CODE As String = String.Empty '***************
    Protected mNOBILL_FLAG As Short = 0       '***************
    Protected mEMAIL_GR_CODE As String = String.Empty
    Protected mAD_NBR As String = String.Empty
    Protected mACCT_NBR As String = String.Empty
    'Modified by Sam Tran on 2006/06/14
    '	added desc to class
    Protected mACCT_NBR_DESC As String = String.Empty
    Protected mPRD_AB_INCOME As Short = 0
    Protected mMARKET_CODE As String = String.Empty
    Protected mSERVICE_FEE_FLAG As Short = 0
    Protected mPRD_CONT_CODE As String = String.Empty
    Protected mARCHIVE_FLAG As Short = 0
    Protected mROWID As Integer = 0
    Protected mADJUST_USER As String = String.Empty
    Protected mTRF_SCHEDULE_BY As Short = 0
    Protected mTRF_SCHEDULE_REQ As Short = 0
    Protected mJOB_CL_PO_NBR As String = String.Empty
    Protected mIsNew As Boolean = False
    Protected mAccountExecutiveDesc As String = String.Empty
    Protected mContactDesc As String = String.Empty
    Protected mJobTypeDesc As String = String.Empty
    Protected mDeptTeamDesc As String = String.Empty
    Protected mAdNumberDesc As String = String.Empty
    Protected mMarketDesc As String = String.Empty
    Protected mParent As Job
    Protected mUDFTab As String = String.Empty
    Protected mUDF1 As wvUserDefinedField
    Protected mUDF2 As wvUserDefinedField
    Protected mUDF3 As wvUserDefinedField
    Protected mUDF4 As wvUserDefinedField
    Protected mUDF5 As wvUserDefinedField
    Protected mBLACKPLT_VER_CODE As String = String.Empty
    Protected mBLACKPLT_VER_DESC As String = String.Empty
    Protected mBLACKPLT_VER2_CODE As String = String.Empty
    Protected mBLACKPLT_VER2_DESC As String = String.Empty
    Protected mJOB_QTY As String = String.Empty
    Protected mFISCAL_PERIOD_CODE As String = String.Empty
    Protected mFISCAL_YEAR As String = String.Empty
    Protected mCDP_CONTACT_ID As Integer
    Protected mALRT_NOTIFY_HDR_ID As Integer
    Protected mALERT_NOTIFY_NAME As String = String.Empty
    Protected mSERVICE_FEE_TYPE_ID As Integer
    Protected mSERVICE_FEE_TYPE_CODE As String = String.Empty
    Protected mSERVICE_FEE_TYPE_DESC As String = String.Empty
    Protected mMEDIA_BILL_DATE As New Date

#End Region
#Region " Constructors "
    Public Sub New(ByVal ConnectionString As String, ByRef ParentJob As Job)
        mConnString = ConnectionString
        mParent = ParentJob
        mIsNew = True
    End Sub
#End Region
#Region " Business Properties and Methods "

    Public Overridable ReadOnly Property JOB_NUMBER() As Integer
        Get
            Return mJOB_NUMBER
        End Get
    End Property
    Public Overridable ReadOnly Property JOB_COMPONENT_NBR() As Short
        Get
            Return mJOB_COMPONENT_NBR
        End Get
    End Property
    Public Overridable Property JOB_BILL_HOLD() As Short
        Get
            Return mJOB_BILL_HOLD
        End Get
        Set(ByVal Value As Short)
            If mJOB_BILL_HOLD <> Value Then
                mJOB_BILL_HOLD = Value
            End If
        End Set
    End Property
    Public Overridable Property EMP_CODE() As String
        Get
            Return mEMP_CODE
        End Get
        Set(ByVal Value As String)
            If mEMP_CODE <> Value Then
                mEMP_CODE = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_COMP_DATE() As Date
        Get
            Return mJOB_COMP_DATE
        End Get
        Set(ByVal Value As Date)
            If mJOB_COMP_DATE <> Value Then
                mJOB_COMP_DATE = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_FIRST_USE_DATE() As Date
        Get
            Return mJOB_FIRST_USE_DATE
        End Get
        Set(ByVal Value As Date)
            If mJOB_FIRST_USE_DATE <> Value Then
                mJOB_FIRST_USE_DATE = Value
            End If
        End Set
    End Property
    Public Overridable Property START_DATE() As Date
        Get
            Return mSTART_DATE
        End Get
        Set(ByVal Value As Date)
            If mSTART_DATE <> Value Then
                mSTART_DATE = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_AD_SIZE() As String
        Get
            Return mJOB_AD_SIZE
        End Get
        Set(ByVal Value As String)
            If mJOB_AD_SIZE <> Value Then
                mJOB_AD_SIZE = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_SPEC_TYPE() As String
        Get
            Return mJOB_SPEC_TYPE
        End Get
        Set(ByVal Value As String)
            If mJOB_SPEC_TYPE <> Value Then
                mJOB_SPEC_TYPE = Value
            End If
        End Set
    End Property
    Public Overridable Property DP_TM_CODE() As String
        Get
            Return mDP_TM_CODE
        End Get
        Set(ByVal Value As String)
            If mDP_TM_CODE <> Value Then
                mDP_TM_CODE = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_MARKUP_PCT() As Decimal
        Get
            Return mJOB_MARKUP_PCT
        End Get
        Set(ByVal Value As Decimal)
            If mJOB_MARKUP_PCT <> Value Then
                mJOB_MARKUP_PCT = Value
            End If
        End Set
    End Property
    Public Overridable Property CREATIVE_INSTR() As String
        Get
            Return mCREATIVE_INSTR
        End Get
        Set(ByVal Value As String)
            If mCREATIVE_INSTR <> Value Then
                mCREATIVE_INSTR = Value
            End If
        End Set
    End Property
    Public Overridable Property CREATIVE_INSTR_HTML() As String
        Get
            Return mCREATIVE_INSTR_HTML
        End Get
        Set(ByVal Value As String)
            If mCREATIVE_INSTR_HTML <> Value Then
                mCREATIVE_INSTR_HTML = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_LAYOUT_THUMB() As Short
        Get
            Return mJOB_LAYOUT_THUMB
        End Get
        Set(ByVal Value As Short)
            If mJOB_LAYOUT_THUMB <> Value Then
                mJOB_LAYOUT_THUMB = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_LAYOUT_ROUGH() As Short
        Get
            Return mJOB_LAYOUT_ROUGH
        End Get
        Set(ByVal Value As Short)
            If mJOB_LAYOUT_ROUGH <> Value Then
                mJOB_LAYOUT_ROUGH = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_LAYOUT_COMP() As Short
        Get
            Return mJOB_LAYOUT_COMP
        End Get
        Set(ByVal Value As Short)
            If mJOB_LAYOUT_COMP <> Value Then
                mJOB_LAYOUT_COMP = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_LAYOUT_NONE() As Short
        Get
            Return mJOB_LAYOUT_NONE
        End Get
        Set(ByVal Value As Short)
            If mJOB_LAYOUT_NONE <> Value Then
                mJOB_LAYOUT_NONE = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_LAYOUT_SPECIAL() As Short
        Get
            Return mJOB_LAYOUT_SPECIAL
        End Get

        Set(ByVal Value As Short)
            If mJOB_LAYOUT_SPECIAL <> Value Then
                mJOB_LAYOUT_SPECIAL = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_LAYOUT_SPC_EXP() As String
        Get
            Return mJOB_LAYOUT_SPC_EXP
        End Get
        Set(ByVal Value As String)
            If mJOB_LAYOUT_SPC_EXP <> Value Then
                mJOB_LAYOUT_SPC_EXP = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_PROCESS_CONTRL() As Short
        Get
            Return mJOB_PROCESS_CONTRL
        End Get
        Set(ByVal Value As Short)
            If mJOB_PROCESS_CONTRL <> Value Then
                mJOB_PROCESS_CONTRL = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_COMP_DESC() As String
        Get
            Return mJOB_COMP_DESC
        End Get
        Set(ByVal Value As String)
            If mJOB_COMP_DESC <> Value Then
                mJOB_COMP_DESC = Value

            End If
        End Set
    End Property
    Public Overridable Property JOB_COMP_COMMENTS() As String
        Get
            Return mJOB_COMP_COMMENTS
        End Get
        Set(ByVal Value As String)
            If mJOB_COMP_COMMENTS <> Value Then
                mJOB_COMP_COMMENTS = Value
            End If
        End Set
    End Property
    Public Overridable Property JC_COMMENTS_HTML() As String
        Get
            Return mJC_COMMENTS_HTML
        End Get
        Set(ByVal Value As String)
            If mJC_COMMENTS_HTML <> Value Then
                mJC_COMMENTS_HTML = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_COMP_BUDGET_AM() As Decimal
        Get
            Return mJOB_COMP_BUDGET_AM
        End Get
        Set(ByVal Value As Decimal)
            If mJOB_COMP_BUDGET_AM <> Value Then
                mJOB_COMP_BUDGET_AM = Value
            End If
        End Set
    End Property
    Public Overridable Property ESTIMATE_NUMBER() As Integer
        Get
            Return mESTIMATE_NUMBER
        End Get
        Set(ByVal Value As Integer)
            If mESTIMATE_NUMBER <> Value Then
                mESTIMATE_NUMBER = Value

            End If
        End Set
    End Property
    Public Overridable Property EST_COMPONENT_NBR() As Short
        Get
            Return mEST_COMPONENT_NBR
        End Get
        Set(ByVal Value As Short)
            If mEST_COMPONENT_NBR <> Value Then
                mEST_COMPONENT_NBR = Value
            End If
        End Set
    End Property
    Public Overridable Property BILLING_USER() As String
        Get
            Return mBILLING_USER
        End Get
        Set(ByVal Value As String)
            If mBILLING_USER <> Value Then
                mBILLING_USER = Value
            End If
        End Set
    End Property
    Public Overridable Property AB_FLAG() As Short
        Get
            Return mAB_FLAG
        End Get
        Set(ByVal Value As Short)
            If mAB_FLAG <> Value Then
                mAB_FLAG = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_DEL_INSTRUCT() As String
        Get
            Return mJOB_DEL_INSTRUCT
        End Get
        Set(ByVal Value As String)
            If mJOB_DEL_INSTRUCT <> Value Then
                mJOB_DEL_INSTRUCT = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_DEL_INSTR_HTML() As String
        Get
            Return mJOB_DEL_INSTR_HTML
        End Get
        Set(ByVal Value As String)
            If mJOB_DEL_INSTR_HTML <> Value Then
                mJOB_DEL_INSTR_HTML = Value
            End If
        End Set
    End Property
    Public Overridable Property JT_CODE() As String
        Get
            Return mJT_CODE
        End Get
        Set(ByVal Value As String)
            If mJT_CODE <> Value Then
                mJT_CODE = Value
            End If
        End Set
    End Property
    Public Overridable Property strTAX_FLAG() As String
        Get
            Return mStrTAX_FLAG
        End Get
        Set(ByVal Value As String)
            If mStrTAX_FLAG <> Value Then
                mStrTAX_FLAG = Value
            End If
        End Set
    End Property
    Public Overridable Property TAX_FLAG() As Short
        Get
            Return mTAX_FLAG
        End Get
        Set(ByVal Value As Short)
            If mTAX_FLAG <> Value Then
                mTAX_FLAG = Value
            End If
        End Set
    End Property
    Public Overridable Property TAX_CODE() As String
        Get
            Return mTAX_CODE
        End Get
        Set(ByVal Value As String)
            If mTAX_CODE <> Value Then
                mTAX_CODE = Value
            End If
        End Set
    End Property
    Public Overridable Property NOBILL_FLAG() As Short
        Get
            Return mNOBILL_FLAG
        End Get
        Set(ByVal Value As Short)
            If mNOBILL_FLAG <> Value Then
                mNOBILL_FLAG = Value
            End If
        End Set
    End Property
    Public Overridable Property EMAIL_GR_CODE() As String
        Get
            Return mEMAIL_GR_CODE
        End Get
        Set(ByVal Value As String)
            If mEMAIL_GR_CODE <> Value Then
                mEMAIL_GR_CODE = Value
            End If
        End Set
    End Property
    Public Overridable Property AD_NBR() As String
        Get
            Return mAD_NBR
        End Get
        Set(ByVal Value As String)
            If mAD_NBR <> Value Then
                mAD_NBR = Value
            End If
        End Set
    End Property
    Public Overridable Property ACCT_NBR() As String
        Get
            Return mACCT_NBR
        End Get
        Set(ByVal Value As String)
            If mACCT_NBR <> Value Then
                mACCT_NBR = Value
            End If
        End Set
    End Property
    'Modified by Sam Tran on 2006/06/14
    '	
    Public Overridable Property ACCT_NBR_DESC() As String
        Get
            Return mACCT_NBR_DESC
        End Get
        Set(ByVal Value As String)
            If mACCT_NBR_DESC <> Value Then
                mACCT_NBR_DESC = Value
            End If
        End Set
    End Property
    Public Overridable Property PRD_AB_INCOME() As Short
        Get
            Return mPRD_AB_INCOME
        End Get
        Set(ByVal Value As Short)
            If mPRD_AB_INCOME <> Value Then
                mPRD_AB_INCOME = Value
            End If
        End Set
    End Property
    Public Overridable Property MARKET_CODE() As String
        Get
            Return mMARKET_CODE
        End Get

        Set(ByVal Value As String)
            If mMARKET_CODE <> Value Then
                mMARKET_CODE = Value
            End If
        End Set
    End Property
    Public Overridable Property SERVICE_FEE_FLAG() As Short
        Get
            Return mSERVICE_FEE_FLAG
        End Get
        Set(ByVal Value As Short)
            If mSERVICE_FEE_FLAG <> Value Then
                mSERVICE_FEE_FLAG = Value
            End If
        End Set
    End Property
    Public Overridable Property PRD_CONT_CODE() As String
        Get
            Return mPRD_CONT_CODE
        End Get
        Set(ByVal Value As String)
            If mPRD_CONT_CODE <> Value Then
                mPRD_CONT_CODE = Value
            End If
        End Set
    End Property
    Public Overridable Property CDP_CONTACT_ID() As Integer
        Get
            Return mCDP_CONTACT_ID
        End Get
        Set(ByVal Value As Integer)
            If mCDP_CONTACT_ID <> Value Then
                mCDP_CONTACT_ID = Value
            End If
        End Set
    End Property
    Public Overridable Property ARCHIVE_FLAG() As Short
        Get
            Return mARCHIVE_FLAG
        End Get
        Set(ByVal Value As Short)
            If mARCHIVE_FLAG <> Value Then
                mARCHIVE_FLAG = Value
            End If
        End Set
    End Property
    Public Overridable Property ROWID() As Integer
        Get
            Return mROWID
        End Get
        Set(ByVal Value As Integer)
            If mROWID <> Value Then
                mROWID = Value
            End If
        End Set
    End Property
    Public Overridable Property ADJUST_USER() As String
        Get
            Return mADJUST_USER
        End Get
        Set(ByVal Value As String)
            If mADJUST_USER <> Value Then
                mADJUST_USER = Value
            End If
        End Set
    End Property
    Public Overridable Property TRF_SCHEDULE_BY() As Short
        Get
            Return mTRF_SCHEDULE_BY
        End Get
        Set(ByVal Value As Short)
            If mTRF_SCHEDULE_BY <> Value Then
                mTRF_SCHEDULE_BY = Value
            End If
        End Set
    End Property
    Public Overridable Property TRF_SCHEDULE_REQ() As Short
        Get
            Return mTRF_SCHEDULE_REQ
        End Get
        Set(ByVal Value As Short)
            If mTRF_SCHEDULE_REQ <> Value Then
                mTRF_SCHEDULE_REQ = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_CL_PO_NBR() As String
        Get
            Return mJOB_CL_PO_NBR
        End Get
        Set(ByVal Value As String)
            If mJOB_CL_PO_NBR <> Value Then
                mJOB_CL_PO_NBR = Value
            End If
        End Set
    End Property
    Public ReadOnly Property IsNew() As Boolean
        Get
            Return mIsNew
        End Get
    End Property
    Public Overridable Property UDFTab() As String
        Get
            Return mUDFTab
        End Get
        Set(ByVal Value As String)
            If mUDFTab <> Value Then
                mUDFTab = Value
            End If
        End Set
    End Property
    Public Overridable Property UDF1() As wvUserDefinedField
        Get
            Return mUDF1
        End Get
        Set(ByVal Value As wvUserDefinedField)
            mUDF1 = Value
        End Set
    End Property
    Public Overridable Property UDF2() As wvUserDefinedField
        Get
            Return mUDF2
        End Get
        Set(ByVal Value As wvUserDefinedField)
            mUDF2 = Value
        End Set
    End Property
    Public Overridable Property UDF3() As wvUserDefinedField
        Get
            Return mUDF3
        End Get
        Set(ByVal Value As wvUserDefinedField)
            mUDF3 = Value
        End Set
    End Property
    Public Overridable Property UDF4() As wvUserDefinedField
        Get
            Return mUDF4
        End Get
        Set(ByVal Value As wvUserDefinedField)
            mUDF4 = Value
        End Set
    End Property
    Public Overridable Property UDF5() As wvUserDefinedField
        Get
            Return mUDF5
        End Get
        Set(ByVal Value As wvUserDefinedField)
            mUDF5 = Value
        End Set
    End Property
    'st:
    'Modified by Sam Tran on 2006/05/11
    '	next 2 shouldn't be needed
    Public Overridable Property IS_NON_BILLABLE() As Single
        Get
            Return mJOB_COMP_ACCT_NonBillable
        End Get
        Set(ByVal Value As Single)
            If mJOB_COMP_ACCT_NonBillable <> Value Then mJOB_COMP_ACCT_NonBillable = Value
        End Set
    End Property
    Public Overridable Property MARKUP_PERC() As String
        Get
            Return mJOB_COMP_ACCT_Markup
        End Get
        Set(ByVal Value As String)
            If mJOB_COMP_ACCT_Markup <> Value Then mJOB_COMP_ACCT_Markup = Value
        End Set
    End Property
    Public Overridable Property BLACKPLT_VER_CODE() As String
        Get
            Return mBLACKPLT_VER_CODE
        End Get
        Set(ByVal Value As String)
            If mBLACKPLT_VER_CODE <> Value Then
                mBLACKPLT_VER_CODE = Value
            End If
        End Set
    End Property
    Public Overridable Property BLACKPLT_VER2_CODE() As String
        Get
            Return mBLACKPLT_VER2_CODE
        End Get
        Set(ByVal Value As String)
            If mBLACKPLT_VER2_CODE <> Value Then
                mBLACKPLT_VER2_CODE = Value
            End If
        End Set
    End Property
    Public Overridable Property BLACKPLT_VER_DESC() As String
        Get
            Return mBLACKPLT_VER_DESC
        End Get
        Set(ByVal Value As String)
            If mBLACKPLT_VER_DESC <> Value Then
                mBLACKPLT_VER_DESC = Value
            End If
        End Set
    End Property
    Public Overridable Property BLACKPLT_VER2_DESC() As String
        Get
            Return mBLACKPLT_VER2_DESC
        End Get
        Set(ByVal Value As String)
            If mBLACKPLT_VER2_DESC <> Value Then
                mBLACKPLT_VER2_DESC = Value
            End If
        End Set
    End Property
    Public Overridable Property JOB_QTY() As String
        Get
            Return mJOB_QTY
        End Get
        Set(ByVal Value As String)
            If mJOB_QTY <> Value Then
                mJOB_QTY = Value
            End If
        End Set
    End Property
    Public Overridable Property FISCAL_PERIOD_CODE() As String
        Get
            Return mFISCAL_PERIOD_CODE
        End Get
        Set(ByVal Value As String)
            If mFISCAL_PERIOD_CODE <> Value Then
                mFISCAL_PERIOD_CODE = Value
            End If
        End Set
    End Property
    Public Overridable Property ALRT_NOTIFY_HDR_ID() As Integer
        Get
            Return mALRT_NOTIFY_HDR_ID
        End Get
        Set(ByVal Value As Integer)
            If mALRT_NOTIFY_HDR_ID <> Value Then
                mALRT_NOTIFY_HDR_ID = Value
            End If
        End Set
    End Property
    Public Overridable Property SERVICE_FEE_TYPE_ID() As Integer
        Get
            Return mSERVICE_FEE_TYPE_ID
        End Get
        Set(ByVal Value As Integer)
            If mSERVICE_FEE_TYPE_ID <> Value Then
                mSERVICE_FEE_TYPE_ID = Value
            End If
        End Set
    End Property
    Public Overridable Property SERVICE_FEE_TYPE_CODE() As String
        Get
            Return mSERVICE_FEE_TYPE_CODE
        End Get
        Set(ByVal Value As String)
            If mSERVICE_FEE_TYPE_CODE <> Value Then
                mSERVICE_FEE_TYPE_CODE = Value
            End If
        End Set
    End Property
    Public Overridable Property SERVICE_FEE_TYPE_DESC() As String
        Get
            Return mSERVICE_FEE_TYPE_DESC
        End Get
        Set(ByVal Value As String)
            If mSERVICE_FEE_TYPE_DESC <> Value Then
                mSERVICE_FEE_TYPE_DESC = Value
            End If
        End Set
    End Property

    '--- Descriptions ---
    Public Overridable Property AccountExecutiveDesc() As String
        Get
            Return mAccountExecutiveDesc
        End Get
        Set(ByVal Value As String)
            If mAccountExecutiveDesc <> Value Then
                mAccountExecutiveDesc = Value
            End If
        End Set
    End Property
    Public Overridable Property ContactDesc() As String
        Get
            Return mContactDesc
        End Get
        Set(ByVal Value As String)
            If mContactDesc <> Value Then
                mContactDesc = Value
            End If
        End Set
    End Property
    Public Overridable Property JobTypeDesc() As String
        Get
            Return mJobTypeDesc
        End Get
        Set(ByVal Value As String)
            If mJobTypeDesc <> Value Then
                mJobTypeDesc = Value
            End If
        End Set
    End Property
    Public Overridable Property DeptTeamDesc() As String
        Get
            Return mDeptTeamDesc
        End Get
        Set(ByVal Value As String)
            If mDeptTeamDesc <> Value Then
                mDeptTeamDesc = Value
            End If
        End Set
    End Property
    Public Overridable Property AdNumberDesc() As String
        Get
            Return mAdNumberDesc
        End Get
        Set(ByVal Value As String)
            If mAdNumberDesc <> Value Then
                mAdNumberDesc = Value
            End If
        End Set
    End Property
    Public Overridable Property MarketDesc() As String
        Get
            Return mMarketDesc
        End Get
        Set(ByVal Value As String)
            If mMarketDesc <> Value Then
                mMarketDesc = Value
            End If
        End Set
    End Property
    Public Overridable Property ALERT_NOTIFY_NAME() As String
        Get
            Return mALERT_NOTIFY_NAME
        End Get
        Set(ByVal Value As String)
            If mALERT_NOTIFY_NAME <> Value Then
                mALERT_NOTIFY_NAME = Value
            End If
        End Set
    End Property
    Public Overridable Property MEDIA_BILL_DATE() As Date
        Get
            Return mMEDIA_BILL_DATE
        End Get
        Set(ByVal Value As Date)
            If mMEDIA_BILL_DATE <> Value Then
                mMEDIA_BILL_DATE = Value
            End If
        End Set
    End Property
    Public Overridable ReadOnly Property ParentJob() As Job
        Get
            Return mParent
        End Get
    End Property
#End Region
#Region " System.Object Overrides "
    Public Overrides Function ToString() As String
        'Return the Primary Key As a String
        Return mJOB_NUMBER.ToString() + "." + mJOB_COMPONENT_NBR.ToString
    End Function
#End Region
#Region " Methods "
    Public Function Save(ByRef Message As String) As Boolean
        If mIsNew = True Then
            If ValidateNew(Message) = False Then
                Return False
            End If
            Try
                If SaveNewJobComponent() = True Then
                    SaveJobComponent()
                Else
                    Message = "Error Saving New Component"
                    Return False
                End If
            Catch ex As Exception
                Message = Err.Description
                Return False
            End Try
        Else
            'Update Job Component
            If ValidateUpdate(Message) = False Then
                Return False
            End If
            Try
                SaveJobComponent()
            Catch ex As Exception
                Message = Err.Description
                Return False
            End Try
        End If
        Return True
    End Function
    Private Function SaveJobComponent() As Boolean
        Dim myReturn As Integer

        Try
            Dim arParams(49) As SqlParameter

            Dim paramcJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int, 0)
            paramcJOB_NUMBER.Value = Me.ParentJob.JOB_NUMBER
            arParams(0) = paramcJOB_NUMBER
            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt, 0)
            paramJOB_COMPONENT_NBR.Value = Me.mJOB_COMPONENT_NBR
            arParams(1) = paramJOB_COMPONENT_NBR
            Dim paramJOB_BILL_HOLD As New SqlParameter("@JOB_BILL_HOLD", SqlDbType.SmallInt, 0)
            If mJOB_BILL_HOLD <> 0 Then
                paramJOB_BILL_HOLD.Value = Me.mJOB_BILL_HOLD
            End If
            arParams(2) = paramJOB_BILL_HOLD
            Dim paramEMP_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            paramEMP_CODE.Value = Me.mEMP_CODE
            arParams(3) = paramEMP_CODE


            '================================================================
            Dim paramJOB_COMP_DATE As New SqlParameter("@JOB_COMP_DATE", SqlDbType.SmallDateTime, 0)
            If Me.mJOB_COMP_DATE.Equals(New Date) = False Then
                paramJOB_COMP_DATE.Value = Me.mJOB_COMP_DATE
            Else
                paramJOB_COMP_DATE.Value = Date.Now
            End If
            arParams(4) = paramJOB_COMP_DATE

            Dim paramJOB_FIRST_USE_DATE As New SqlParameter("@JOB_FIRST_USE_DATE", SqlDbType.SmallDateTime, 0)
            If Me.mJOB_FIRST_USE_DATE.Equals(New Date) = False Then
                If Me.mJOB_FIRST_USE_DATE = "12:00:00 AM" Then
                    paramJOB_FIRST_USE_DATE.Value = DBNull.Value
                Else
                    paramJOB_FIRST_USE_DATE.Value = Me.mJOB_FIRST_USE_DATE
                End If
            End If
            arParams(5) = paramJOB_FIRST_USE_DATE

            Dim paramSTART_DATE As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime, 0)
            If Me.mSTART_DATE.Equals(New Date) = False Then
                If Me.mSTART_DATE = "12:00:00 AM" Then
                    paramSTART_DATE.Value = DBNull.Value
                Else
                    paramSTART_DATE.Value = Me.mSTART_DATE
                End If
            End If
            arParams(6) = paramSTART_DATE
            '================================================================


            Dim paramJOB_AD_SIZE As New SqlParameter("@JOB_AD_SIZE", SqlDbType.VarChar, 60)
            If mJOB_AD_SIZE <> "" Then
                paramJOB_AD_SIZE.Value = Me.mJOB_AD_SIZE
            End If
            arParams(7) = paramJOB_AD_SIZE
            Dim paramJOB_SPEC_TYPE As New SqlParameter("@JOB_SPEC_TYPE", SqlDbType.VarChar, 1)
            paramJOB_SPEC_TYPE.Value = Me.mJOB_SPEC_TYPE
            arParams(8) = paramJOB_SPEC_TYPE
            Dim paramDP_TM_CODE As New SqlParameter("@DP_TM_CODE", SqlDbType.VarChar, 4)
            If mDP_TM_CODE <> "" Then
                paramDP_TM_CODE.Value = Me.mDP_TM_CODE
            End If
            arParams(9) = paramDP_TM_CODE

            'Modified by Sam Tran on 2006/06/19
            '	insert dbnull if zero markup
            Dim paramJOB_MARKUP_PCT As New SqlParameter("@JOB_MARKUP_PCT", SqlDbType.Decimal, 0)
            If Me.mJOB_MARKUP_PCT = -1 Then
                paramJOB_MARKUP_PCT.Value = DBNull.Value
            Else
                paramJOB_MARKUP_PCT.Value = Me.mJOB_MARKUP_PCT
            End If
            arParams(10) = paramJOB_MARKUP_PCT


            Dim paramCREATIVE_INSTR As New SqlParameter("@CREATIVE_INSTR", SqlDbType.Text, 2147483647)
            If mCREATIVE_INSTR <> "" Then
                paramCREATIVE_INSTR.Value = Me.mCREATIVE_INSTR
            End If
            arParams(11) = paramCREATIVE_INSTR
            Dim paramJOB_LAYOUT_THUMB As New SqlParameter("@JOB_LAYOUT_THUMB", SqlDbType.SmallInt, 0)
            If mJOB_LAYOUT_THUMB <> 0 Then
                paramJOB_LAYOUT_THUMB.Value = Me.mJOB_LAYOUT_THUMB
            End If
            arParams(12) = paramJOB_LAYOUT_THUMB
            Dim paramJOB_LAYOUT_ROUGH As New SqlParameter("@JOB_LAYOUT_ROUGH", SqlDbType.SmallInt, 0)
            If mJOB_LAYOUT_ROUGH <> 0 Then
                paramJOB_LAYOUT_ROUGH.Value = Me.mJOB_LAYOUT_ROUGH
            End If
            arParams(13) = paramJOB_LAYOUT_ROUGH
            Dim paramJOB_LAYOUT_COMP As New SqlParameter("@JOB_LAYOUT_COMP", SqlDbType.SmallInt, 0)
            If mJOB_LAYOUT_COMP <> 0 Then
                paramJOB_LAYOUT_COMP.Value = Me.mJOB_LAYOUT_COMP
            End If
            arParams(14) = paramJOB_LAYOUT_COMP
            Dim paramJOB_LAYOUT_NONE As New SqlParameter("@JOB_LAYOUT_NONE", SqlDbType.SmallInt, 0)
            If mJOB_LAYOUT_NONE <> 0 Then
                paramJOB_LAYOUT_NONE.Value = Me.mJOB_LAYOUT_NONE
            End If
            arParams(15) = paramJOB_LAYOUT_NONE
            Dim paramJOB_LAYOUT_SPECIAL As New SqlParameter("@JOB_LAYOUT_SPECIAL", SqlDbType.SmallInt, 0)
            If mJOB_LAYOUT_SPECIAL <> 0 Then
                paramJOB_LAYOUT_SPECIAL.Value = Me.mJOB_LAYOUT_SPECIAL
            End If
            arParams(16) = paramJOB_LAYOUT_SPECIAL
            Dim paramJOB_LAYOUT_SPC_EXP As New SqlParameter("@JOB_LAYOUT_SPC_EXP", SqlDbType.VarChar, 60)
            If mJOB_LAYOUT_SPC_EXP <> "" Then
                paramJOB_LAYOUT_SPC_EXP.Value = Me.mJOB_LAYOUT_SPC_EXP
            End If
            arParams(17) = paramJOB_LAYOUT_SPC_EXP
            Dim paramJOB_PROCESS_CONTRL As New SqlParameter("@JOB_PROCESS_CONTRL", SqlDbType.SmallInt, 0)
            paramJOB_PROCESS_CONTRL.Value = Me.mJOB_PROCESS_CONTRL
            arParams(18) = paramJOB_PROCESS_CONTRL
            Dim paramJOB_COMP_DESC As New SqlParameter("@JOB_COMP_DESC", SqlDbType.VarChar, 60)
            paramJOB_COMP_DESC.Value = Me.mJOB_COMP_DESC
            arParams(19) = paramJOB_COMP_DESC
            Dim paramJOB_COMP_COMMENTS As New SqlParameter("@JOB_COMP_COMMENTS", SqlDbType.Text, 2147483647)
            If mJOB_COMP_COMMENTS <> "" Then
                paramJOB_COMP_COMMENTS.Value = Me.mJOB_COMP_COMMENTS
            End If
            arParams(20) = paramJOB_COMP_COMMENTS
            Dim paramJOB_COMP_BUDGET_AM As New SqlParameter("@JOB_COMP_BUDGET_AM", SqlDbType.Decimal, 0)
            If mJOB_COMP_BUDGET_AM <> 0 Then
                paramJOB_COMP_BUDGET_AM.Value = Me.mJOB_COMP_BUDGET_AM
            End If
            arParams(21) = paramJOB_COMP_BUDGET_AM
            Dim paramESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int, 0)
            If mESTIMATE_NUMBER <> 0 Then
                paramESTIMATE_NUMBER.Value = Me.mESTIMATE_NUMBER
            End If
            arParams(22) = paramESTIMATE_NUMBER
            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt, 0)
            paramEST_COMPONENT_NBR.Value = Me.mEST_COMPONENT_NBR
            arParams(23) = paramEST_COMPONENT_NBR
            Dim paramBILLING_USER As New SqlParameter("@BILLING_USER", SqlDbType.VarChar, 100)
            If mBILLING_USER <> "" Then
                paramBILLING_USER.Value = Me.mBILLING_USER
            End If
            arParams(24) = paramBILLING_USER
            Dim paramAB_FLAG As New SqlParameter("@AB_FLAG", SqlDbType.SmallInt, 0)
            paramAB_FLAG.Value = Me.mAB_FLAG
            arParams(25) = paramAB_FLAG
            Dim paramJOB_DEL_INSTRUCT As New SqlParameter("@JOB_DEL_INSTRUCT", SqlDbType.Text, 2147483647)
            If mJOB_DEL_INSTRUCT <> "" Then
                paramJOB_DEL_INSTRUCT.Value = Me.mJOB_DEL_INSTRUCT
            End If
            arParams(26) = paramJOB_DEL_INSTRUCT
            Dim paramJT_CODE As New SqlParameter("@JT_CODE", SqlDbType.VarChar, 10)
            If mJT_CODE <> "" Then
                paramJT_CODE.Value = Me.mJT_CODE
            End If
            arParams(27) = paramJT_CODE

            Dim paramTAX_FLAG As New SqlParameter("@TAX_FLAG", SqlDbType.SmallInt, 0)
            If mTAX_FLAG = 0 OrElse mTAX_FLAG = 1 Then
                paramTAX_FLAG.Value = Me.mTAX_FLAG
            Else
                paramTAX_FLAG.Value = DBNull.Value
            End If
            arParams(28) = paramTAX_FLAG

            Dim paramTAX_CODE As New SqlParameter("@TAX_CODE", SqlDbType.VarChar, 4)
            If mTAX_CODE = "" OrElse mTAX_CODE = String.Empty OrElse mTAX_CODE.Length < 1 Then
                paramTAX_CODE.Value = DBNull.Value
            Else
                paramTAX_CODE.Value = Me.mTAX_CODE
            End If
            arParams(29) = paramTAX_CODE



            Dim paramNOBILL_FLAG As New SqlParameter("@NOBILL_FLAG", SqlDbType.SmallInt, 0)
            'If mNOBILL_FLAG = 0 Then
            '    paramNOBILL_FLAG.Value = DBNull.Value
            'Else
            paramNOBILL_FLAG.Value = Me.mNOBILL_FLAG
            'End If
            arParams(30) = paramNOBILL_FLAG


            'Modified by Sam Tran on 2006/05/04
            '	insert dbnull if value is none
            Dim paramEMAIL_GR_CODE As New SqlParameter("@EMAIL_GR_CODE", SqlDbType.VarChar, 50)
            If Me.mEMAIL_GR_CODE = "" OrElse Me.mEMAIL_GR_CODE = String.Empty OrElse Me.mEMAIL_GR_CODE = "[None]" Then
                paramEMAIL_GR_CODE.Value = DBNull.Value
            Else
                paramEMAIL_GR_CODE.Value = Me.mEMAIL_GR_CODE
            End If
            arParams(31) = paramEMAIL_GR_CODE



            Dim paramAD_NBR As New SqlParameter("@AD_NBR", SqlDbType.VarChar, 30)
            If Me.mAD_NBR <> "" Then
                paramAD_NBR.Value = Me.mAD_NBR
            End If
            arParams(32) = paramAD_NBR

            Dim paramACCT_NBR As New SqlParameter("@ACCT_NBR", SqlDbType.VarChar, 30)
            If Me.mACCT_NBR = "" OrElse Me.mACCT_NBR = String.Empty Then
                paramACCT_NBR.Value = DBNull.Value
            Else
                paramACCT_NBR.Value = Me.mACCT_NBR
            End If
            arParams(33) = paramACCT_NBR

            Dim paramPRD_AB_INCOME As New SqlParameter("@PRD_AB_INCOME", SqlDbType.SmallInt, 0)
            If Me.mPRD_AB_INCOME <> 0 Then
                paramPRD_AB_INCOME.Value = Me.mPRD_AB_INCOME
            End If
            arParams(34) = paramPRD_AB_INCOME
            Dim paramMARKET_CODE As New SqlParameter("@MARKET_CODE", SqlDbType.VarChar, 10)
            If Me.mMARKET_CODE <> "" Then
                paramMARKET_CODE.Value = Me.mMARKET_CODE
            End If
            arParams(35) = paramMARKET_CODE
            Dim paramSERVICE_FEE_FLAG As New SqlParameter("@SERVICE_FEE_FLAG", SqlDbType.SmallInt, 0)
            If Me.mSERVICE_FEE_FLAG <> 0 Then
                paramSERVICE_FEE_FLAG.Value = Me.mSERVICE_FEE_FLAG
            End If
            arParams(36) = paramSERVICE_FEE_FLAG
            Dim paramPRD_CONT_CODE As New SqlParameter("@PRD_CONT_CODE", SqlDbType.VarChar, 4)
            If Me.mPRD_CONT_CODE <> "" Then
                paramPRD_CONT_CODE.Value = Me.mPRD_CONT_CODE
            End If
            arParams(37) = paramPRD_CONT_CODE
            Dim paramARCHIVE_FLAG As New SqlParameter("@ARCHIVE_FLAG", SqlDbType.SmallInt, 0)
            If Me.mARCHIVE_FLAG <> 0 Then
                paramARCHIVE_FLAG.Value = Me.mARCHIVE_FLAG
            End If
            arParams(38) = paramARCHIVE_FLAG
            Dim paramADJUST_USER As New SqlParameter("@ADJUST_USER", SqlDbType.VarChar, 100)
            If Me.mADJUST_USER <> "" Then
                paramADJUST_USER.Value = Me.mADJUST_USER
            End If
            arParams(39) = paramADJUST_USER
            Dim paramTRF_SCHEDULE_BY As New SqlParameter("@TRF_SCHEDULE_BY", SqlDbType.SmallInt, 0)
            If Me.mTRF_SCHEDULE_BY <> 0 Then
                paramTRF_SCHEDULE_BY.Value = Me.mTRF_SCHEDULE_BY
            End If
            arParams(40) = paramTRF_SCHEDULE_BY
            Dim paramTRF_SCHEDULE_REQ As New SqlParameter("@TRF_SCHEDULE_REQ", SqlDbType.SmallInt, 0)
            If Me.mTRF_SCHEDULE_REQ <> 0 Then
                paramTRF_SCHEDULE_REQ.Value = Me.mTRF_SCHEDULE_REQ
            End If
            arParams(41) = paramTRF_SCHEDULE_REQ
            Dim paramJOB_CL_PO_NBR As New SqlParameter("@JOB_CL_PO_NBR", SqlDbType.VarChar, 40)
            If Me.mJOB_CL_PO_NBR <> "" Then
                paramJOB_CL_PO_NBR.Value = Me.mJOB_CL_PO_NBR
            End If
            arParams(42) = paramJOB_CL_PO_NBR

            'User Defined Fields
            Dim paramUDF1 As New SqlParameter("@UDF1", SqlDbType.VarChar, 10)
            If Not Me.UDF1 Is Nothing Then
                If Me.UDF1.Code <> "" Then
                    paramUDF1.Value = Me.UDF1.Code
                End If
            End If
            arParams(43) = paramUDF1
            Dim paramUDF2 As New SqlParameter("@UDF2", SqlDbType.VarChar, 10)
            If Not Me.UDF2 Is Nothing Then
                If Me.UDF2.Code <> "" Then
                    paramUDF2.Value = Me.UDF2.Code
                End If
            End If
            arParams(44) = paramUDF2
            Dim paramUDF3 As New SqlParameter("@UDF3", SqlDbType.VarChar, 10)
            If Not Me.UDF3 Is Nothing Then
                If Me.UDF3.Code <> "" Then
                    paramUDF3.Value = Me.UDF3.Code
                End If
            End If
            arParams(45) = paramUDF3
            Dim paramUDF4 As New SqlParameter("@UDF4", SqlDbType.VarChar, 10)
            If Not Me.UDF4 Is Nothing Then
                If Me.UDF4.Code <> "" Then
                    paramUDF4.Value = Me.UDF4.Code
                End If
            End If
            arParams(46) = paramUDF4
            Dim paramUDF5 As New SqlParameter("@UDF5", SqlDbType.VarChar, 10)
            If Not Me.UDF5 Is Nothing Then
                If Me.UDF5.Code <> "" Then
                    paramUDF5.Value = Me.UDF5.Code
                End If
            End If
            arParams(47) = paramUDF5

            myReturn = oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "dbo.usp_wv_job_comp_update", arParams)

        Catch ex As Exception
            Err.Raise(9999, Err.Source, Err.Description)
        End Try

        If myReturn > 0 Then
            Return True
        Else
            Return False
        End If


    End Function
    Private Function SaveNewJobComponent() As Boolean
        Dim dr As SqlDataReader

        Try
            Dim arParams(4) As SqlParameter

            Dim paramcJOB_NUMBER As New SqlParameter("@JobNumber", SqlDbType.Int, 0)
            paramcJOB_NUMBER.Value = Me.ParentJob.JOB_NUMBER
            arParams(0) = paramcJOB_NUMBER
            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@JobCompNumber", SqlDbType.SmallInt, 0)
            paramJOB_COMPONENT_NBR.Value = Me.mJOB_COMPONENT_NBR
            arParams(1) = paramJOB_COMPONENT_NBR
            Dim paramEMP_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            paramEMP_CODE.Value = Me.mEMP_CODE
            arParams(2) = paramEMP_CODE
            Dim paramJobCompdDesc As New SqlParameter("@JOB_COMP_DESC", SqlDbType.VarChar, 60)
            paramJobCompdDesc.Value = Me.mJOB_COMP_DESC
            arParams(3) = paramJobCompdDesc

            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_job_component_new", arParams)

        Catch ex As Exception
            Err.Raise(9999, Err.Source, Err.Description)
        End Try

        Try
            If dr.HasRows = True Then
                dr.Read()
                Me.mJOB_COMP_DATE = CDate(dr.GetDateTime(0))
                If IsDBNull(dr(1)) = False Then
                    Me.mJOB_MARKUP_PCT = CDec(dr.GetDecimal(1))
                    'Else
                    '    Me.mJOB_MARKUP_PCT = 0
                End If
            Else
                Return False
            End If
        Catch
            Return False
        End Try
        dr.Close()

        Return True

    End Function

    Public Sub GetJobComponent(ByVal JobNo As Integer, ByVal JobComponent As Integer)
        CreateUserDefinedFields()

        'Retrieve data from db
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter

        Dim parameterJobNo As New SqlParameter("@JOB_NUMBER", SqlDbType.Int, 0)
        parameterJobNo.Value = JobNo
        arParams(0) = parameterJobNo
        Dim parameterJobComp As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt, 0)
        parameterJobComp.Value = JobComponent
        arParams(1) = parameterJobComp

        dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_job_comp_get", arParams)
        Try
            dr.Read()
            With dr
                If .IsDBNull(0) = False Then
                    mJOB_NUMBER = .GetInt32(0)
                End If

                If .IsDBNull(1) = False Then
                    mJOB_COMPONENT_NBR = .GetInt16(1)
                End If

                If .IsDBNull(2) = False Then
                    mJOB_BILL_HOLD = .GetInt16(2)
                End If

                If .IsDBNull(3) = False Then
                    mEMP_CODE = .GetString(3)
                End If

                If .IsDBNull(4) = False Then
                    mJOB_COMP_DATE = .GetDateTime(4)
                End If

                If .IsDBNull(5) = False Then
                    mJOB_FIRST_USE_DATE = .GetDateTime(5)
                End If

                If .IsDBNull(6) = False Then
                    mSTART_DATE = .GetDateTime(6)
                End If

                If .IsDBNull(7) = False Then
                    mJOB_AD_SIZE = .GetString(7)
                End If

                If .IsDBNull(8) = False Then
                    mJOB_SPEC_TYPE = .GetString(8)
                End If

                If .IsDBNull(9) = False Then
                    mDP_TM_CODE = .GetString(9)
                End If

                If .IsDBNull(10) = False Then
                    mJOB_MARKUP_PCT = .GetDecimal(10)
                Else
                    mJOB_MARKUP_PCT = 0
                End If

                If .IsDBNull(11) = False Then
                    mCREATIVE_INSTR = .GetString(11)
                End If

                If .IsDBNull(12) = False Then
                    mJOB_LAYOUT_THUMB = .GetInt16(12)
                End If

                If .IsDBNull(13) = False Then
                    mJOB_LAYOUT_ROUGH = .GetInt16(13)
                End If

                If .IsDBNull(14) = False Then
                    mJOB_LAYOUT_COMP = .GetInt16(14)
                End If

                If .IsDBNull(15) = False Then
                    mJOB_LAYOUT_NONE = .GetInt16(15)
                End If

                If .IsDBNull(16) = False Then
                    mJOB_LAYOUT_SPECIAL = .GetInt16(16)
                End If

                If .IsDBNull(17) = False Then
                    mJOB_LAYOUT_SPC_EXP = .GetString(17)
                End If

                If .IsDBNull(18) = False Then
                    mJOB_PROCESS_CONTRL = .GetInt16(18)
                End If

                If .IsDBNull(19) = False Then
                    mJOB_COMP_DESC = .GetString(19)
                End If

                If .IsDBNull(20) = False Then
                    mJOB_COMP_COMMENTS = .GetString(20)
                End If

                If .IsDBNull(21) = False Then
                    mJOB_COMP_BUDGET_AM = .GetDecimal(21)
                End If

                If .IsDBNull(22) = False Then
                    mESTIMATE_NUMBER = .GetInt32(22)
                End If

                If .IsDBNull(23) = False Then
                    mEST_COMPONENT_NBR = .GetInt16(23)
                End If

                If .IsDBNull(24) = False Then
                    mBILLING_USER = .GetString(24)
                End If

                If .IsDBNull(25) = False Then
                    mAB_FLAG = .GetInt16(25)
                End If

                If .IsDBNull(26) = False Then
                    mJOB_DEL_INSTRUCT = .GetString(26)
                End If

                If .IsDBNull(27) = False Then
                    mJT_CODE = .GetString(27)
                End If

                If .IsDBNull(28) = False Then
                    mTAX_FLAG = .GetInt16(28)
                Else
                    mTAX_FLAG = -1
                End If

                If .IsDBNull(29) = False Then
                    mTAX_CODE = .GetString(29)
                End If

                If .IsDBNull(30) = False Then
                    mNOBILL_FLAG = .GetInt16(30)
                End If

                If .IsDBNull(31) = False Then
                    mEMAIL_GR_CODE = .GetString(31)
                End If

                If .IsDBNull(32) = False Then
                    mAD_NBR = .GetString(32)
                End If

                If .IsDBNull(33) = False Then
                    mACCT_NBR = .GetString(33)
                End If

                If .IsDBNull(34) = False Then
                    mPRD_AB_INCOME = .GetInt16(34)
                End If

                If .IsDBNull(35) = False Then
                    mMARKET_CODE = .GetString(35)
                End If

                If .IsDBNull(36) = False Then
                    mSERVICE_FEE_FLAG = .GetInt16(36)
                End If

                If .IsDBNull(37) = False Then
                    mPRD_CONT_CODE = .GetString(37)
                End If

                If .IsDBNull(38) = False Then
                    mARCHIVE_FLAG = .GetInt16(38)
                End If

                If .IsDBNull(39) = False Then
                    mROWID = .GetInt32(39)
                End If

                If .IsDBNull(40) = False Then
                    mADJUST_USER = .GetString(40)
                End If

                If .IsDBNull(41) = False Then
                    mTRF_SCHEDULE_BY = .GetInt16(41)
                End If

                If .IsDBNull(42) = False Then
                    mTRF_SCHEDULE_REQ = .GetInt16(42)
                End If

                If .IsDBNull(43) = False Then
                    mJOB_CL_PO_NBR = .GetString(43)
                End If
                If .IsDBNull(44) = False Then
                    mClient = .GetString(44)
                End If
                If .IsDBNull(45) = False Then
                    mDivision = .GetString(45)
                End If
                If .IsDBNull(46) = False Then
                    mProduct = .GetString(46)
                End If
                If .IsDBNull(47) = False Then
                    mAccountExecutiveDesc = .GetString(47)
                End If
                If .IsDBNull(48) = False Then
                    mContactDesc = .GetString(48)
                End If
                If .IsDBNull(49) = False Then
                    mJobTypeDesc = .GetString(49)
                End If
                If .IsDBNull(50) = False Then
                    mDeptTeamDesc = .GetString(50)
                End If
                If .IsDBNull(51) = False Then
                    mAdNumberDesc = .GetString(51)
                End If
                If .IsDBNull(52) = False Then
                    mMarketDesc = .GetString(52)
                End If
                If Not Me.mUDF1 Is Nothing Then
                    If .IsDBNull(53) = False Then
                        mUDF1.Code = .GetString(53)
                    End If
                    If .IsDBNull(54) = False Then
                        mUDF1.Description = .GetString(54)
                    End If
                End If
                If Not Me.mUDF2 Is Nothing Then
                    If .IsDBNull(55) = False Then
                        mUDF2.Code = .GetString(55)
                    End If
                    If .IsDBNull(56) = False Then
                        mUDF2.Description = .GetString(56)
                    End If
                End If
                If Not Me.mUDF3 Is Nothing Then
                    If .IsDBNull(57) = False Then
                        mUDF3.Code = .GetString(57)
                    End If
                    If .IsDBNull(58) = False Then
                        mUDF3.Description = .GetString(58)
                    End If
                End If
                If Not Me.mUDF4 Is Nothing Then
                    If .IsDBNull(59) = False Then
                        mUDF4.Code = .GetString(59)
                    End If
                    If .IsDBNull(60) = False Then
                        mUDF4.Description = .GetString(60)
                    End If
                End If
                If Not Me.mUDF5 Is Nothing Then
                    If .IsDBNull(61) = False Then
                        mUDF5.Code = .GetString(61)
                    End If
                    If .IsDBNull(62) = False Then
                        mUDF5.Description = .GetString(62)
                    End If
                End If
                If .IsDBNull(63) = False Then
                    mACCT_NBR_DESC = .GetString(63)
                End If
                If .IsDBNull(64) = False Then
                    mBLACKPLT_VER_CODE = .GetString(64)
                End If
                If .IsDBNull(65) = False Then
                    mBLACKPLT_VER_DESC = .GetString(65)
                End If
                If .IsDBNull(66) = False Then
                    mBLACKPLT_VER2_CODE = .GetString(66)
                End If
                If .IsDBNull(67) = False Then
                    mBLACKPLT_VER2_DESC = .GetString(67)
                End If
                If .IsDBNull(68) = False Then
                    mJOB_QTY = .GetInt32(68)
                End If
                If .IsDBNull(69) = False Then
                    mFISCAL_PERIOD_CODE = .GetString(69)
                End If
                If .IsDBNull(70) = False Then
                    mCDP_CONTACT_ID = .GetInt32(70)
                End If
                If .IsDBNull(.GetOrdinal("ALRT_NOTIFY_HDR_ID")) = False Then
                    mALRT_NOTIFY_HDR_ID = .GetInt32(.GetOrdinal("ALRT_NOTIFY_HDR_ID"))
                End If
                If .IsDBNull(.GetOrdinal("ALERT_NOTIFY_NAME")) = False Then
                    mALERT_NOTIFY_NAME = .GetString(.GetOrdinal("ALERT_NOTIFY_NAME"))
                End If
                If .IsDBNull(73) = False Then
                    mSERVICE_FEE_TYPE_ID = .GetInt32(73)
                End If
                If .IsDBNull(74) = False Then
                    mSERVICE_FEE_TYPE_CODE = .GetString(74)
                End If
                If .IsDBNull(75) = False Then
                    mSERVICE_FEE_TYPE_DESC = .GetString(75)
                End If
                If .IsDBNull(76) = False Then
                    mCREATIVE_INSTR_HTML = .GetString(76)
                End If
                If .IsDBNull(77) = False Then
                    mJC_COMMENTS_HTML = .GetString(77)
                End If
                If .IsDBNull(78) = False Then
                    mJOB_DEL_INSTR_HTML = .GetString(78)
                End If
            End With
        Catch ex As Exception

        Finally
            dr.Close()
            mIsNew = False
        End Try
    End Sub
    Public Function GetMarkupAmt(ByRef cl_code As String, ByRef div_code As String, ByRef prd_code As String) As Decimal
        Dim arParams(4) As SqlParameter

        Dim parameterClt As New SqlParameter("@ClientCode", SqlDbType.Char, 6)
        parameterClt.Value = cl_code
        arParams(0) = parameterClt
        Dim parameterDiv As New SqlParameter("@DivisionCode", SqlDbType.Char, 6)
        parameterDiv.Value = div_code
        arParams(1) = parameterDiv
        Dim parameterPrd As New SqlParameter("@ProductCode", SqlDbType.Char, 6)
        parameterPrd.Value = prd_code
        arParams(2) = parameterPrd
        Dim parameterMarkUp As New SqlParameter("@markup_pct", SqlDbType.Decimal)
        parameterMarkUp.Direction = ParameterDirection.Output
        parameterMarkUp.Scale = 3
        arParams(4) = parameterMarkUp

        oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_job_component_GetDefaultMarkup", arParams)
        Return arParams(4).Value
    End Function

    Private Function ValidateNew(ByRef Message As String) As Boolean

        'JobCompDesc
        If Me.mJOB_COMP_DESC = "" Then
            Message = "Job Component Description is Required"
            Return False
        End If

        If ValidateUpdate(Message) = False Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Function ValidateUpdate(ByRef Message As String) As Boolean
        Dim oValidations As cValidations = New cValidations(mConnString)
        Dim oReq As cRequired = New cRequired(mConnString)

        Try
            'Account Executive
            If Me.mEMP_CODE = "" Then
                Message = "Account Executive is Required"
                Return False
            Else
                If oValidations.ValidateAccountExecutive(Me) = False Then
                    Message = "Invalid Account Executive"
                    Return False
                End If
            End If

            'Product Contact
            If Me.mPRD_CONT_CODE = "" Then
                If oReq.RequiredProdContact(mParent.CL_CODE) = True Then
                    Message = "Product Contact is Required"
                    Return False
                End If
            Else
                If oValidations.ValidateProdContact(Me) = False Then
                    Message = "Invalid Product Contact"
                    Return False
                End If
            End If

            'Job Type
            If Me.mJT_CODE = "" Then
                If oReq.RequiredJobType(mParent.CL_CODE) = True Then
                    Message = "Job Type is Required"
                    Return False
                End If
            Else
                If oValidations.ValidateJobType(Me) = False Then
                    Message = "Invalid Job Type"
                    Return False
                End If
            End If

            'Dept/Team
            If Me.mDP_TM_CODE = "" Then
                If oReq.RequiredDeptTeam(mParent.CL_CODE) = True Then
                    Message = "Dept/Team is Required"
                    Return False
                End If
            Else
                If oValidations.ValidateDeptTeam(Me) = False Then
                    Message = "Invalid Dept/Team"
                    Return False
                End If
            End If

            'Ad Number
            If Me.AD_NBR = "" Then
                If oReq.RequiredAdNumber(mParent.CL_CODE) = True Then
                    Message = "Ad Number is Required"
                    Return False
                End If
            Else
                If oValidations.ValidateAdNumber(Me) = False Then
                    Message = "Invalid Ad Number"
                    Return False
                End If
            End If

            'Market
            If Me.mMARKET_CODE = "" Then
                If oReq.RequiredMarket(mParent.CL_CODE) = True Then
                    Message = "Market is Required"
                    Return False
                End If
            Else
                If oValidations.ValidateMarket(Me) = False Then
                    Message = "Invalid Market"
                    Return False
                End If
            End If

            'User Defined Fields
            If Not Me.UDF1 Is Nothing Then
                If Me.UDF1.Code = "" Then
                    If oReq.RequiredJCUDF1(mParent.CL_CODE) = True Then
                        Message = Me.UDF1.Label & " is Required"
                        Return False
                    End If
                Else
                    If oValidations.ValidateJobCompUDF1(Me) = False Then
                        Message = "Invalid " & Me.UDF1.Label
                        Return False
                    End If
                End If
            End If
            If Not Me.UDF2 Is Nothing Then
                If Me.UDF2.Code = "" Then
                    If oReq.RequiredJCUDF2(mParent.CL_CODE) = True Then
                        Message = Me.UDF2.Label & " is Required"
                        Return False
                    End If
                Else
                    If oValidations.ValidateJobCompUDF2(Me) = False Then
                        Message = "Invalid " & Me.UDF2.Label
                        Return False
                    End If
                End If
            End If
            If Not Me.UDF3 Is Nothing Then
                If Me.UDF3.Code = "" Then
                    If oReq.RequiredJCUDF3(mParent.CL_CODE) = True Then
                        Message = Me.UDF3.Label & " is Required"
                        Return False
                    End If
                Else
                    If oValidations.ValidateJobCompUDF3(Me) = False Then
                        Message = "Invalid " & Me.UDF3.Label
                        Return False
                    End If
                End If
            End If
            If Not Me.UDF4 Is Nothing Then
                If Me.UDF4.Code = "" Then
                    If oReq.RequiredJCUDF4(mParent.CL_CODE) = True Then
                        Message = Me.UDF4.Label & " is Required"
                        Return False
                    End If
                Else
                    If oValidations.ValidateJobCompUDF4(Me) = False Then
                        Message = "Invalid " & Me.UDF4.Label
                        Return False
                    End If
                End If
            End If
            If Not Me.UDF5 Is Nothing Then
                If Me.UDF5.Code = "" Then
                    If oReq.RequiredJCUDF5(mParent.CL_CODE) = True Then
                        Message = Me.UDF5.Label & " is Required"
                        Return False
                    End If
                Else
                    If oValidations.ValidateJobCompUDF5(Me) = False Then
                        Message = "Invalid " & Me.UDF5.Label
                        Return False
                    End If
                End If
            End If

            If oValidations.ValidateJobComponentAccountNumber(Me) = False Then
                Message = "Invalid Account Number"
                Return False
            End If

            'Modified by Sam Tran on 2006/06/19
            '	added to validate tax code
            If oValidations.ValidateTaxCode(Me) = False Then
                Message = "Invalid Tax Code"
                Return False
            End If

            If oValidations.ValidateSalesClassFormat(mParent) = False Then
                Message = "Invalid Sales Class Format"
            End If

            Return True

        Catch
            Message = Err.Description
            Return False
        End Try

    End Function

    Public Sub GetNextCompNumber()
        If mIsNew = True AndAlso Not mParent Is Nothing Then
            Dim Num As Short

            Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int, 0)
            paramJobNumber.Value = Me.mParent.JOB_NUMBER

            Try
                Num = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_component_next_number", paramJobNumber)
            Catch
                Err.Raise(Err.Number, "Object:JobComponent Routine:GetNextCompNumber", Err.Description)
            End Try

            Me.mJOB_COMPONENT_NBR = Num
        Else
            Err.Raise(9999, "Object:JobComponent Routine:GetNextCompNumber", "No parent job or component number is already assigned.")
        End If
    End Sub
    Private Sub CreateUserDefinedFields()
        Dim dr As SqlDataReader
        Dim ThisLabel As String
        Dim ThisUDF As wvUserDefinedField


        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_job_get_udf_labels")

            Do While dr.Read()
                ThisLabel = dr.GetString(0)
                Select Case ThisLabel
                    Case "JOB_CMP_TAB"
                        mUDFTab = dr.GetString(1)
                    Case "JOB_CMP_UDV1"
                        If dr.IsDBNull(1) = False Then
                            ThisUDF = New wvUserDefinedField
                            ThisUDF.Label = dr.GetString(1)
                            mUDF1 = ThisUDF
                        Else
                            mUDF1 = Nothing
                        End If
                    Case "JOB_CMP_UDV2"
                        If dr.IsDBNull(1) = False Then
                            ThisUDF = New wvUserDefinedField
                            ThisUDF.Label = dr.GetString(1)
                            mUDF2 = ThisUDF
                        Else
                            mUDF2 = Nothing
                        End If
                    Case "JOB_CMP_UDV3"
                        If dr.IsDBNull(1) = False Then
                            ThisUDF = New wvUserDefinedField
                            ThisUDF.Label = dr.GetString(1)
                            mUDF3 = ThisUDF
                        Else
                            mUDF3 = Nothing
                        End If
                    Case "JOB_CMP_UDV4"
                        If dr.IsDBNull(1) = False Then
                            ThisUDF = New wvUserDefinedField
                            ThisUDF.Label = dr.GetString(1)
                            mUDF4 = ThisUDF
                        Else
                            mUDF4 = Nothing
                        End If
                    Case "JOB_CMP_UDV5"
                        If dr.IsDBNull(1) = False Then
                            ThisUDF = New wvUserDefinedField
                            ThisUDF.Label = dr.GetString(1)
                            mUDF5 = ThisUDF
                        Else
                            mUDF5 = Nothing
                        End If
                End Select
            Loop
        Catch
            Err.Raise(Err.Number, "Class:JobComponent Routine:CreateUserDefinedFields", Err.Description)
        End Try
    End Sub
#End Region
End Class
<Serializable()> Public Class JobsComponentCollection
    Inherits CollectionBase
    Default Public Property Item(ByVal index As Integer) As JobComponent
        Get
            Return CType(List(index), JobComponent)
        End Get
        Set(ByVal Value As JobComponent)
            List(index) = Value
        End Set
    End Property
    Public Function Add(ByVal value As JobComponent) As Integer
        Return List.Add(value)
    End Function
    Public Function IndexOf(ByVal value As JobComponent) As Integer
        Return List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As JobComponent)
        List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As JobComponent)
        List.Remove(value)
    End Sub
    Public Function Contains(ByVal value As JobComponent) As Boolean
        Return List.Contains(value)
    End Function
End Class
#End Region

#Region "Job User Defiends Fields"
<Serializable()> Public Class wvUserDefinedField
    Dim mLablel As String
    Dim mCode As String
    Dim mDescription As String
    Public Overridable Property Label() As String
        Get
            Return mLablel
        End Get
        Set(ByVal Value As String)
            mLablel = Value
        End Set
    End Property
    Public Overridable Property Code() As String
        Get
            Return mCode
        End Get
        Set(ByVal Value As String)
            mCode = Value
        End Set
    End Property
    Public Overridable Property Description() As String
        Get
            Return mDescription
        End Get
        Set(ByVal Value As String)
            mDescription = Value
        End Set
    End Property
End Class
#End Region

#Region "Job Routines Ojbect"
<Serializable()> Public Class cJobs
    Dim mConnString As String
    Dim oSQL As SqlHelper
    Public Function GetTreeViewDR(ByVal strClient As String, ByVal strDivision As String, ByVal strProduct As String, ByVal strJob As String, ByVal strJobComp As String, ByVal strEmpCode As String, ByVal UserID As String) As SqlDataReader
        'Dim dr As SqlDataReader
        'Dim arParams(4) As SqlParameter

        'Dim parameterJob As New SqlParameter("@Job", SqlDbType.Int, 0)
        'parameterJob.Value = strJob
        'arParams(0) = parameterJob

        'Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.VarChar, 10)
        'parameterJobComp.Value = strJobComp
        'arParams(1) = parameterJobComp

        'Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        'parameterEmpCode.Value = strEmpCode
        'arParams(2) = parameterEmpCode

        'Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        'parameterUserID.Value = UserID
        'arParams(3) = parameterUserID

        'Try
        '    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_BuildTreeView", arParams)
        'Catch
        '    Err.Raise(Err.Number, "Class:cJobs Routine:GetTreeViewDR", Err.Description)
        'End Try
        ''Return dr
        'Return dr

        'dr.Close()
        'dr = Nothing

    End Function
    Public Function GetNewJobNumber() As Integer
        Dim Num As Integer
        Try
            Num = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_getnewnumber")
        Catch
            Err.Raise(Err.Number, "Class:cJobs Routine:GetNewJobNumber", Err.Description)
        End Try

        Return Num
    End Function
    Public Function CreateNewJob(ByVal CliCode As String,
                                ByVal DivCode As String,
                                ByVal PrdCode As String,
                                ByVal SCCode As String,
                                ByVal UserID As String,
                                ByVal JobDesc As String,
                                ByVal AE As String,
                                ByVal JobCompdesc As String,
                                ByVal Validate As Boolean,
                                ByRef ReturnMessage As String,
                                Optional ByVal JobTemplateCode As String = "",
                                Optional ByVal OfficeCode As String = "",
                                Optional ByVal CmpID As Integer = 0,
                                Optional ByVal CmpCode As String = "",
                                Optional ByVal JobTypeCode As String = "") As Integer

        Dim oValidations As cValidations = New cValidations(mConnString)
        Dim arParams(14) As SqlParameter
        Dim JobNo As Integer = 0

        'Validate
        If Validate = True Then
            Try
                If oValidations.ValidateNewJob(CliCode, DivCode, PrdCode, SCCode, AE, OfficeCode, ReturnMessage) = False Then
                    Return 0
                End If
            Catch
                Err.Raise(9999, Err.Source, Err.Description)
            End Try
        End If

        Dim parameterClient As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
        parameterClient.Value = CliCode
        arParams(0) = parameterClient

        Dim parameterDivision As New SqlParameter("@DIV_CODE", SqlDbType.VarChar, 6)
        parameterDivision.Value = DivCode
        arParams(1) = parameterDivision

        Dim parameterProduct As New SqlParameter("@PRD_CODE", SqlDbType.VarChar, 6)
        parameterProduct.Value = PrdCode
        arParams(2) = parameterProduct

        Dim parameterSC As New SqlParameter("@SC_CODE", SqlDbType.VarChar, 6)
        parameterSC.Value = SCCode
        arParams(3) = parameterSC

        Dim parameterUseriD As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
        parameterUseriD.Value = UserID
        arParams(4) = parameterUseriD

        Dim parameterJobDesc As New SqlParameter("@JOB_DESC", SqlDbType.VarChar, 60)
        parameterJobDesc.Value = JobDesc
        arParams(5) = parameterJobDesc

        Dim parameterEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = AE
        arParams(6) = parameterEmpCode

        Dim parameterCompDesc As New SqlParameter("@JOB_COMP_DESC", SqlDbType.VarChar, 60)
        parameterCompDesc.Value = JobCompdesc
        arParams(7) = parameterCompDesc

        Dim parameterTemplateCode As New SqlParameter("@TMPLT_CODE", SqlDbType.VarChar, 6)
        If JobTemplateCode.Trim() <> "" Then
            parameterTemplateCode.Value = JobTemplateCode
        Else
            parameterTemplateCode.Value = System.DBNull.Value
        End If
        arParams(8) = parameterTemplateCode

        Dim parameterOfficeCode As New SqlParameter("@USR_OFFICE_CODE", SqlDbType.VarChar, 6)
        parameterOfficeCode.Value = OfficeCode
        arParams(9) = parameterOfficeCode

        Dim parameterCampaignID As New SqlParameter("@CAMPAIGN_ID", SqlDbType.Int)
        parameterCampaignID.Value = CmpID
        arParams(10) = parameterCampaignID

        Dim parameterCampaignCode As New SqlParameter("@CAMPAIGN_CODE", SqlDbType.VarChar, 6)
        parameterCampaignCode.Value = CmpCode
        arParams(11) = parameterCampaignCode

        Dim parameterJobTypeCode As New SqlParameter("@JT_CODE", SqlDbType.VarChar, 10)
        If String.IsNullOrWhiteSpace(JobTypeCode) = True Then
            parameterJobTypeCode.Value = System.DBNull.Value
        Else
            parameterJobTypeCode.Value = JobTypeCode
        End If
        arParams(12) = parameterJobTypeCode

        Dim pCreateDate As New SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
        pCreateDate.Value = cEmployee.TimeZoneToday
        arParams(13) = pCreateDate

        Try
            JobNo = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_NewJob", arParams))
            Return JobNo
        Catch
            Err.Raise(Err.Number, "Class:cJobs Routine:CreateNewJob", Err.Description)
            Return 0
        End Try

    End Function
    Public Function GetCampaignIdentifier(ByVal CampaignCode As String, Optional ByVal ClientCode As String = "", Optional ByVal DivisionCode As String = "", Optional ByVal ProductCode As String = "") As Integer
        'Dim SessionKey As String = "GetCampaignIdentifier" & CampaignCode & ClientCode & DivisionCode & ProductCode
        Dim ReturnInteger As Integer = 0
        'If HttpContext.Current.Session(SessionKey) Is Nothing Then
        Dim arParams(3) As SqlParameter

        Dim paramCMP_CODE As New SqlParameter("@CampaignCode", SqlDbType.VarChar, 6)
        paramCMP_CODE.Value = CampaignCode
        arParams(0) = paramCMP_CODE

        Dim paramCL_CODE As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        paramCL_CODE.Value = ClientCode
        arParams(1) = paramCL_CODE

        Dim paramDIV_CODE As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        paramDIV_CODE.Value = DivisionCode
        arParams(2) = paramDIV_CODE

        Dim paramPRD_CODE As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        paramPRD_CODE.Value = ProductCode
        arParams(3) = paramPRD_CODE

        Try
            ReturnInteger = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_get_campaign_ident", arParams)
        Catch Ex As Exception
            ReturnInteger = 0
        End Try

        '    HttpContext.Current.Session(SessionKey) = ReturnInteger

        'Else
        '    ReturnInteger = CType(HttpContext.Current.Session(SessionKey).ToString(), Integer)
        'End If

        Return ReturnInteger
    End Function
    Public Function GetCampaignId(ByVal CampaignCode As String, Optional ByVal ClientCode As String = "", Optional ByVal DivisionCode As String = "",
                                  Optional ByVal ProductCode As String = "") As Integer
        Dim SessionKey As String = "GetCampaignId" & CampaignCode & ClientCode & DivisionCode & ProductCode
        Dim ReturnInteger As Integer = 0
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim arParams(3) As SqlParameter

            Dim paramCMP_CODE As New SqlParameter("@CampaignCode", SqlDbType.VarChar, 6)
            paramCMP_CODE.Value = CampaignCode
            arParams(0) = paramCMP_CODE

            Dim paramCL_CODE As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            paramCL_CODE.Value = ClientCode
            arParams(1) = paramCL_CODE

            Dim paramDIV_CODE As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
            paramDIV_CODE.Value = DivisionCode
            arParams(2) = paramDIV_CODE

            Dim paramPRD_CODE As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
            paramPRD_CODE.Value = ProductCode
            arParams(3) = paramPRD_CODE

            Try
                ReturnInteger = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_DocumentManager_GetCampaignID", arParams)
            Catch Ex As Exception
                ReturnInteger = 0
            End Try


            HttpContext.Current.Session(SessionKey) = ReturnInteger
        Else
            ReturnInteger = CType(HttpContext.Current.Session(SessionKey).ToString(), Integer)
        End If

        Return ReturnInteger
    End Function
    Public Function GetStatusDesc(ByVal StCode As String) As String
        Dim SessionKey As String = "GetStatusDesc" & StCode
        Dim ReturnString As String = ""
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim stDesc As String
                Dim arParams(1) As SqlParameter

                Dim paramST_CODE As New SqlParameter("@ST_CODE", SqlDbType.VarChar)
                paramST_CODE.Value = StCode
                arParams(0) = paramST_CODE

                stDesc = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_GetStatusDesc", arParams)
                Return stDesc
            Catch ex As Exception
                ReturnString = ""
            End Try

            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString

    End Function
    Public Function GetJobTypeDesc(ByVal JT_CODE As String) As String
        Dim SessionKey As String = "GetJobTypeDesc" & JT_CODE
        Dim ReturnString As String = ""
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim arParams(1) As SqlParameter

            Dim parameterJT_CODE As New SqlParameter("@JT_CODE", SqlDbType.VarChar, 6)
            parameterJT_CODE.Value = JT_CODE
            arParams(0) = parameterJT_CODE

            Try
                ReturnString = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_type_desc", arParams)
            Catch ex As Exception
                ReturnString = ""
            End Try

            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString
    End Function

    Public Function CreateNewJobCopy(ByVal JobNo As Integer,
                                ByVal JobDesc As String,
                                ByVal CliCode As String,
                                ByVal DivCode As String,
                                ByVal PrdCode As String,
                                ByVal SCCode As String,
                                ByVal AE As String,
                                ByVal Validate As Boolean,
                                ByVal UserID As String,
                                ByRef ReturnMessage As String,
                                Optional ByVal JobTemplateCode As String = "",
                                Optional ByVal OfficeCode As String = "",
                                Optional ByVal CmpID As Integer = 0,
                                Optional ByVal CmpCode As String = "")
        Dim oValidations As cValidations = New cValidations(mConnString)
        Dim arParams(11) As SqlParameter
        Dim JobNum As Integer

        'Validate
        If Validate = True Then
            Try
                If oValidations.ValidateNewJob(CliCode, DivCode, PrdCode, SCCode, AE, OfficeCode, ReturnMessage) = False Then
                    Return 0
                End If
            Catch
                Err.Raise(9999, Err.Source, Err.Description)
            End Try
        End If

        Dim parameterJobNo As New SqlParameter("@JobNo", SqlDbType.Int)
        parameterJobNo.Value = JobNo
        arParams(0) = parameterJobNo

        Dim parameterJobDesc As New SqlParameter("@JOB_DESC", SqlDbType.VarChar, 60)
        parameterJobDesc.Value = JobDesc
        arParams(1) = parameterJobDesc

        Dim parameterClient As New SqlParameter("@CLIENT", SqlDbType.VarChar, 6)
        parameterClient.Value = CliCode
        arParams(2) = parameterClient

        Dim parameterDivision As New SqlParameter("@DIVISION", SqlDbType.VarChar, 6)
        parameterDivision.Value = DivCode
        arParams(3) = parameterDivision

        Dim parameterProduct As New SqlParameter("@PRODUCT", SqlDbType.VarChar, 6)
        parameterProduct.Value = PrdCode
        arParams(4) = parameterProduct

        Dim parameterSC As New SqlParameter("@SALES_CLASS", SqlDbType.VarChar, 6)
        parameterSC.Value = SCCode
        arParams(5) = parameterSC

        Dim parameterUSER_ID As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
        parameterUSER_ID.Value = UserID
        arParams(6) = parameterUSER_ID

        Dim parameterCampaignID As New SqlParameter("@CAMPAIGN_ID", SqlDbType.Int)
        parameterCampaignID.Value = CmpID
        arParams(7) = parameterCampaignID

        Dim parameterCampaignCode As New SqlParameter("@CAMPAIGN_CODE", SqlDbType.VarChar, 6)
        parameterCampaignCode.Value = CmpCode
        arParams(8) = parameterCampaignCode

        Dim JOB As New SqlParameter("@JOB_NUM", SqlDbType.Int, 4)
        JOB.Direction = ParameterDirection.Output
        arParams(9) = JOB

        Dim pCreateDate As New SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
        pCreateDate.Value = cEmployee.TimeZoneToday
        arParams(10) = pCreateDate

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_Copy_AddJob", arParams)

        Catch
            Err.Raise(Err.Number, "Class:cJobs Routine:CreateNewJob", Err.Description)
            Return 0
        End Try

        Return JOB.Value
    End Function
    Public Function CreateNewJobComponentCopy(ByVal JOB As Integer,
                                              ByVal JobNo As Integer,
                                              ByVal JobComp As Integer,
                                              ByVal JobCompDesc As String,
                                              ByVal IncludeDates As Boolean,
                                              ByVal Validate As Boolean,
                                              ByRef ReturnMessage As String,
                                              ByVal JobTemplateCode As String,
                                              ByVal JobTypeCode As String,
                                              ByVal AECode As String,
                                              ByVal SelectedBudget As Decimal,
                                              ByVal UserID As String)

        Dim oValidations As cValidations = New cValidations(mConnString)
        Dim arParams(12) As SqlParameter
        Dim JobCompNum As Integer = 0

        'Validate
        'If Validate = True Then
        '    Try
        '        If oValidations.ValidateNewJob(CliCode, DivCode, PrdCode, SCCode, AE, ReturnMessage) = False Then
        '            Return 0
        '        End If
        '    Catch
        '        Err.Raise(9999, Err.Source, Err.Description)
        '    End Try
        'End If

        Dim parameterJOB_NBR As New SqlParameter("@JOB_NBR", SqlDbType.Int)
        parameterJOB_NBR.Value = JOB
        arParams(0) = parameterJOB_NBR

        Dim parameterJobNo As New SqlParameter("@JobNo", SqlDbType.Int)
        parameterJobNo.Value = JobNo
        arParams(1) = parameterJobNo

        Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.Int)
        parameterJobComp.Value = JobComp
        arParams(2) = parameterJobComp

        Dim parameterJobCompDesc As New SqlParameter("@JobCompDesc", SqlDbType.VarChar, 60)
        parameterJobCompDesc.Value = JobCompDesc
        arParams(3) = parameterJobCompDesc

        Dim parameterTemplateCode As New SqlParameter("@JOB_TMPLT_CODE", SqlDbType.VarChar, 6)
        If JobTemplateCode <> "" Then
            parameterTemplateCode.Value = JobTemplateCode
        Else
            parameterTemplateCode.Value = DBNull.Value
        End If
        arParams(4) = parameterTemplateCode

        Dim parameterIncludeDates As New SqlParameter("@IncludeDates", SqlDbType.SmallInt)
        If IncludeDates = True Then
            parameterIncludeDates.Value = 1
        Else
            parameterIncludeDates.Value = 0
        End If
        arParams(5) = parameterIncludeDates

        Dim parameterJobType As New SqlParameter("@JT_CODE", SqlDbType.VarChar, 10)
        If JobTypeCode <> "" Then
            parameterJobType.Value = JobTypeCode
        Else
            parameterJobType.Value = DBNull.Value
        End If
        arParams(6) = parameterJobType

        Dim parameterAECode As New SqlParameter("@AECode", SqlDbType.VarChar)
        parameterAECode.Value = AECode
        arParams(7) = parameterAECode

        Dim JOB_COMP As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
        JOB_COMP.Direction = ParameterDirection.Output
        arParams(8) = JOB_COMP

        Dim pCreateDate As New SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
        pCreateDate.Value = cEmployee.TimeZoneToday
        arParams(9) = pCreateDate

        Dim pBudget As New SqlParameter("@SELECTED_BUDGET", SqlDbType.Decimal)
        pBudget.Value = SelectedBudget
        arParams(10) = pBudget

        Dim parameterUSER_ID As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
        parameterUSER_ID.Value = UserID
        arParams(11) = parameterUSER_ID

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_Copy_AddJobComponent", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cJobs Routine:CreateNewJobComp", Err.Description)
            Return 0
        End Try

        Return JOB_COMP.Value
    End Function
    Public Function CopyJobSpecs(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer, ByVal newjobnum As Integer, ByVal newjobcomp As Integer)
        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNum", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNum", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramJOB_NUM As New SqlParameter("@JOB_NUM", SqlDbType.Int)
        paramJOB_NUM.Value = newjobnum
        arParams(2) = paramJOB_NUM

        Dim paramJOB_COMP As New SqlParameter("@JOB_COMP", SqlDbType.Int)
        paramJOB_COMP.Value = newjobcomp
        arParams(3) = paramJOB_COMP

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_JobCopy", arParams)
            Return True
        Catch ex As Exception
            Return False
            Err.Raise(Err.Number, "Class:cJobs Routine:CopyJobspecdata", Err.Description)
        End Try

    End Function
    Public Function CopyProjectSchedule(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer,
                                        ByVal newjobnum As Integer, ByVal newjobcomp As Integer,
                                        ByVal trfcode As String, ByVal IncludeStartDate As Boolean,
                                        ByVal IncludeDueDate As Boolean, ByVal IncludeEmployees As Boolean,
                                        ByVal IncludeTaskComment As Boolean, ByVal IncludeDueDateComment As Boolean,
                                        ByVal TrafficManagerEmpCode As String, ByVal ScheduleTemplate As Boolean, ByVal IncludeTaskStatus As Boolean)
        Dim dr As SqlDataReader
        Dim arParams(13) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNum", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNum", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramJOB_NUM As New SqlParameter("@JOB_NUM", SqlDbType.Int)
        paramJOB_NUM.Value = newjobnum
        arParams(2) = paramJOB_NUM

        Dim paramJOB_COMP As New SqlParameter("@JOB_COMP", SqlDbType.Int)
        paramJOB_COMP.Value = newjobcomp
        arParams(3) = paramJOB_COMP

        Dim paramTRF_CODE As New SqlParameter("@TRF_CODE", SqlDbType.VarChar)
        paramTRF_CODE.Value = trfcode
        arParams(4) = paramTRF_CODE

        Dim parameterIncludeStartDate As New SqlParameter("@IncludeStartDate", SqlDbType.SmallInt)
        If IncludeStartDate = True Then
            parameterIncludeStartDate.Value = 1
        Else
            parameterIncludeStartDate.Value = 0
        End If
        arParams(5) = parameterIncludeStartDate

        Dim parameterIncludeDueDate As New SqlParameter("@IncludeDueDate", SqlDbType.SmallInt)
        If IncludeDueDate = True Then
            parameterIncludeDueDate.Value = 1
        Else
            parameterIncludeDueDate.Value = 0
        End If
        arParams(6) = parameterIncludeDueDate

        Dim parameterIncludeEmployees As New SqlParameter("@IncludeEmployees", SqlDbType.SmallInt)
        If IncludeEmployees = True Then
            parameterIncludeEmployees.Value = 1
        Else
            parameterIncludeEmployees.Value = 0
        End If
        arParams(7) = parameterIncludeEmployees

        Dim parameterIncludeTaskComment As New SqlParameter("@IncludeTaskComment", SqlDbType.SmallInt)
        If IncludeTaskComment = True Then
            parameterIncludeTaskComment.Value = 1
        Else
            parameterIncludeTaskComment.Value = 0
        End If
        arParams(8) = parameterIncludeTaskComment

        Dim parameterIncludeDueDateComment As New SqlParameter("@IncludeDueDateComment", SqlDbType.SmallInt)
        If IncludeDueDateComment = True Then
            parameterIncludeDueDateComment.Value = 1
        Else
            parameterIncludeDueDateComment.Value = 0
        End If
        arParams(9) = parameterIncludeDueDateComment

        Dim paramTrafficManagerEmpCode As New SqlParameter("@TRAFFIC_MGR_CODE", SqlDbType.VarChar, 6)
        If TrafficManagerEmpCode = "" Then
            paramTrafficManagerEmpCode.Value = System.DBNull.Value
        Else
            paramTrafficManagerEmpCode.Value = TrafficManagerEmpCode
        End If
        arParams(10) = paramTrafficManagerEmpCode

        Dim parameterScheduleTemplate As New SqlParameter("@ScheduleTemplate", SqlDbType.SmallInt)
        If ScheduleTemplate = True Then
            parameterScheduleTemplate.Value = 1
        Else
            parameterScheduleTemplate.Value = 0
        End If
        arParams(11) = parameterScheduleTemplate

        Dim paramUSERCODE As New SqlParameter("@user_id", SqlDbType.Text)
        paramUSERCODE.Value = HttpContext.Current.Session("UserCode")
        arParams(12) = paramUSERCODE

        Dim parameterIncludeTaskStatus As New SqlParameter("@IncludeTaskStatus", SqlDbType.SmallInt)
        If IncludeTaskStatus = True Then
            parameterIncludeTaskStatus.Value = 1
        Else
            parameterIncludeTaskStatus.Value = 0
        End If
        arParams(13) = parameterIncludeTaskStatus

        Try

            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_JobCopy", arParams)
            Return True

        Catch ex As Exception

            Return False
            Err.Raise(Err.Number, "Class:cJobs Routine:Copyprojectscheduledata", Err.Description)

        End Try

    End Function
    Public Function CopyCreativeBrief(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer, ByVal newjobnum As Integer, ByVal newjobcomp As Integer)
        Dim dr As SqlDataReader
        Dim arParams(5) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNum", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNum", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramJOB_NUM As New SqlParameter("@JOB_NUM", SqlDbType.Int)
        paramJOB_NUM.Value = newjobnum
        arParams(2) = paramJOB_NUM

        Dim paramJOB_COMP As New SqlParameter("@JOB_COMP", SqlDbType.Int)
        paramJOB_COMP.Value = newjobcomp
        arParams(3) = paramJOB_COMP

        Dim pCreateDate As New SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
        pCreateDate.Value = cEmployee.TimeZoneToday
        arParams(4) = pCreateDate

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Creative_Brief_JobCopy", arParams)
            Return True
        Catch ex As Exception
            Return False
            Err.Raise(Err.Number, "Class:cJobs Routine:CopyCreativeBrief", Err.Description)
        End Try

    End Function

    Public Sub New(ByVal ConnectionString As String)
        mConnString = ConnectionString
    End Sub
End Class
#End Region

#Region " Enums "

Public Enum RowTypes
    Panel = 0
    ValDescript = 1
    EvenSplit = 2
    ValOnly = 3
    MultiLine = 4
    RadioButton = 5
    RadioButtonList = 6
    DropDownList = 7
    ImageButton = 8
    TextBoxCalendar = 9
    Label = 10
    YesNoRBL = 11
    ValEditableDesc = 12
    LinkButton = 13
    AdNumber = 14
End Enum

Public Enum RowTypesSpecs
    Panel = 0
    ValOnlyChar1 = 1
    ValOnlyChar10 = 2
    ValOnlyChar50 = 3
    MultiLineChar = 4
    MultiLineText = 5
    ValOnlySmallInt = 6
    ValOnlyInt = 7
    RadGrid = 8
End Enum

Public Enum RowVerticalAlignment
    Top = 0
    Middle = 1
    Bottom = 2
End Enum

#End Region

<Serializable()> Public Class Job_Template

#Region " Vars "

    Private mUserCode As String = ""
    Private mConnString As String = ""
    Private mThisEmpCode As String = ""
    Private mIsNewComp As Boolean = False
    Private mCL_CODE As String = ""
    Private mDIV_CODE As String = ""
    Private mPRD_CODE As String = ""
    Private mSC_CODE As String = ""
    Private oSQL As SqlHelper
    Private TitleSpacer As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
    Private RowSpacer As String = "&nbsp;&nbsp;"
    Private IndentSpacer As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
    Private count As Integer = 0
    Private jobnum As Integer = 0
    Private jobcompnum As Integer = 0
    Private client As String = ""

    Private DsJobTemplate As New DataSet
    Private DtJobComments As New DataTable
    Private agency As AdvantageFramework.Database.Entities.Agency = Nothing

    Private sectionCli As String = ""
    Private sectionDiv As String = ""
    Private sectionPrd As String = ""
    Private sectionSC As String = ""

    Private _JobRush As Boolean = False

#End Region

#Region " DB Related "

    'need to handle new comp in this?
    Public Overloads Function GetJobTemplateDetails(ByVal JobNum As Integer, ByVal JobCompNum As Integer) As DataSet
        Try
            Dim arParams(2) As SqlParameter

            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber

            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber

            Dim ds As New DataSet
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_GetTemplate_ByJobAndComp", arParams)
            Return ds
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetJobTemplateDetails!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Public Function GetJobTemplateComments(ByVal JobNum As Integer, ByVal JobCompNum As Integer) As DataSet
        Try
            Dim arParams(2) As SqlParameter

            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber

            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber

            Dim ds As New DataSet
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_GetComments", arParams)
            Return ds
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetJobTemplateComments!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Public Function UpdateJobTemplateComments(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal type As String, ByVal comment As String, ByVal commentHtml As String) As Boolean
        Try
            Dim arParams(4) As SqlParameter

            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber

            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber

            Dim paramType As New SqlParameter("@Type", SqlDbType.VarChar)
            paramType.Value = type
            arParams(2) = paramType

            Dim paramComment As New SqlParameter("@Comment", SqlDbType.VarChar)
            paramComment.Value = comment
            arParams(3) = paramComment

            Dim paramCommentHtml As New SqlParameter("@CommentHtml", SqlDbType.VarChar)
            paramCommentHtml.Value = commentHtml
            arParams(4) = paramCommentHtml

            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_UpdateComments", arParams)
            Return True
        Catch ex As Exception
            Return False
            Err.Raise(Err.Number, "Error GetJobTemplateComments!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Public Function GetAlertRequirements(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal Client As String, ByVal Division As String, ByVal Product As String) As DataTable
        Try
            Dim arParams(5) As SqlParameter

            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim paramClient As New SqlParameter("@Client", SqlDbType.VarChar)
            paramClient.Value = Client
            arParams(2) = paramClient
            Dim paramDivision As New SqlParameter("@Division", SqlDbType.VarChar)
            paramDivision.Value = Division
            arParams(3) = paramDivision
            Dim paramProduct As New SqlParameter("@Product", SqlDbType.VarChar)
            paramProduct.Value = Product
            arParams(4) = paramProduct

            Dim dt As New DataTable
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_GetAlertRequirements_ByJobAndComp", "dtAlertReqs", arParams)
            Return dt
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetAlertRequirements!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Public Function AddNewComponentBase(ByVal JobNumber As Integer, ByVal EmployeeCode As String, ByVal ComponentDescription As String, ByVal JobTemplateCode As String, ByVal JobTypeCode As String, ByVal UserID As String) As Integer

        Try

            Dim intReturn As Integer = 0
            Dim arParams(7) As SqlParameter

            Dim paramcJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramcJOB_NUMBER.Value = JobNumber
            arParams(0) = paramcJOB_NUMBER

            Dim paramEMP_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            paramEMP_CODE.Value = EmployeeCode
            arParams(1) = paramEMP_CODE

            Dim paramJOB_COMP_DESC As New SqlParameter("@JOB_COMP_DESC", SqlDbType.VarChar, 60)
            paramJOB_COMP_DESC.Value = ComponentDescription
            arParams(2) = paramJOB_COMP_DESC

            Dim paramTEMPLATE As New SqlParameter("@JOB_TMPLT_CODE", SqlDbType.VarChar, 6)
            paramTEMPLATE.Value = JobTemplateCode
            arParams(3) = paramTEMPLATE

            Dim paramJT_CODE As New SqlParameter("@JT_CODE", SqlDbType.VarChar, 10)
            If String.IsNullOrWhiteSpace(JobTypeCode) = True Then

                paramJT_CODE.Value = System.DBNull.Value

            Else

                paramJT_CODE.Value = JobTypeCode

            End If
            arParams(4) = paramJT_CODE

            Dim pCreateDate As New SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
            pCreateDate.Value = cEmployee.TimeZoneToday
            arParams(5) = pCreateDate

            Dim parameterUSER_ID As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
            parameterUSER_ID.Value = UserID
            arParams(6) = parameterUSER_ID

            intReturn = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "dbo.usp_wv_Job_Template_AddNewComponent", arParams)
            Return intReturn

        Catch ex As Exception
            Err.Raise(9999, Err.Source, Err.Description)
        End Try

    End Function

    Public Function ChangeTemplate(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal OldTemplate As String, ByVal NewTemplate As String) As Boolean
        If OldTemplate <> NewTemplate AndAlso JobNum > 0 AndAlso JobCompNum > 0 Then
            Try
                Dim intReturn As Integer = 0
                Dim arParams(3) As SqlParameter

                Dim paramcJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                paramcJOB_NUMBER.Value = JobNum
                arParams(0) = paramcJOB_NUMBER

                Dim paramJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
                paramJOB_COMPONENT_NBR.Value = JobCompNum
                arParams(1) = paramJOB_COMPONENT_NBR

                Dim paramJOB_TMPLT_CODE As New SqlParameter("@JOB_TMPLT_CODE", SqlDbType.VarChar, 6)
                paramJOB_TMPLT_CODE.Value = NewTemplate
                arParams(2) = paramJOB_TMPLT_CODE

                intReturn = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "dbo.usp_wv_Job_Template_ChangeTemplate", arParams)
                Return True

            Catch ex As Exception
                Err.Raise(9999, Err.Source, Err.Description)
                Return False
            End Try
        End If
    End Function

    Public Function GetTemplateCode(ByVal JobNum As Integer, ByVal JobCompNum As Integer) As String
        Try
            Dim arParams(2) As SqlParameter

            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim str As String = String.Empty

            str = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_GetTemplateCode_ByJobAndComp", arParams)
            If str = "" OrElse str = String.Empty Then
                str = "DFLT"
            End If
            Return str
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetTemplate!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try

    End Function

    Private Sub GetJobRush(ByVal JobNum As Integer)
        Try

            Dim rushInt As Integer
            Dim arParams(1) As SqlParameter

            Dim paramJobNumber As New SqlParameter("@JobNum", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber

            rushInt = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_GetJobRush", arParams)

            If rushInt = "1" Then

                _JobRush = True

            End If


        Catch ex As Exception

            Err.Raise(Err.Number, "Error GetTemplate!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())

        Finally

        End Try

    End Sub

    Public Function GetTemplateDesc(ByVal JobTemplateCode As String) As String
        Dim SessionKey As String = "GetTemplateDesc" & JobTemplateCode
        Dim ReturnString As String = ""
        If HttpContext.Current.Session(SessionKey) Is Nothing Then

            Try
                Dim codeDesc As String
                Dim arParams(1) As SqlParameter
                Dim paramJobTemplateCode As New SqlParameter("@JobTemplateCode", SqlDbType.VarChar)
                paramJobTemplateCode.Value = JobTemplateCode
                arParams(0) = paramJobTemplateCode
                ReturnString = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_GetJobTemplateDesc", arParams)
            Catch ex As Exception
            End Try

            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString


    End Function

    'not needed, just here to test
    Public Overloads Function GetJobTemplateDetails(ByVal TemplateCode As String) As DataSet
        Dim paramTemplateCode As New SqlParameter("@JTCODE", SqlDbType.VarChar, 6)
        paramTemplateCode.Value = TemplateCode
        Dim ds As New DataSet
        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_GetTemplate", paramTemplateCode)
            Dim str As String
            Return ds
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetJobTemplateDetails!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    'Update the job/comp/client ref
    Public Function UpdateJob(ByVal TheSQL As String, ByVal ar() As SqlParameter, Optional ByRef SuccessfullySaved As Boolean = False) As String
        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.Text, TheSQL, ar)
            SuccessfullySaved = True
            Return ""
        Catch ex As Exception
            SuccessfullySaved = False
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function EncodeSQL(ByVal str As String) As String
        Try
            Return str.Replace("'", "''").Replace(";", "#semicolon#")
        Catch ex As Exception
            Return str
        End Try
    End Function

    Public Function DecodeSQL(ByVal str As String) As String
        Try
            Return str.Replace("#apostrophe#", "'").Replace("#semicolon#", ";")
        Catch ex As Exception
            Return str
        End Try
    End Function

    Public Sub New(Optional ByVal ConnectionString As String = "")
        mConnString = HttpContext.Current.Session("ConnString")
        mUserCode = HttpContext.Current.Session("UserCode")
    End Sub

    Public Function GetDefaultAE(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As String
        Dim SessionKey As String = "GetDefaultAE" & ClientCode & DivisionCode & ProductCode
        Dim ReturnString As String = ""
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim arParams(3) As SqlParameter

                Dim paramClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar)
                paramClientCode.Value = ClientCode
                arParams(0) = paramClientCode
                Dim paramDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar)
                paramDivisionCode.Value = DivisionCode
                arParams(1) = paramDivisionCode
                Dim paramProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar)
                paramProductCode.Value = ProductCode
                arParams(2) = paramProductCode

                ReturnString = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_GetDefaultAE", arParams)

            Catch ex As Exception
                Err.Raise(Err.Number, "Error GetDefaultAE!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
            Finally
            End Try

            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString


    End Function

    Public Function GetBlackPltDesc(ByVal BpCode As String) As String
        Dim SessionKey As String = "GetBlackPltDesc" & BpCode
        Dim ReturnString As String = ""
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim arParams(1) As SqlParameter

                Dim paramBpCode As New SqlParameter("@BpCode", SqlDbType.VarChar)
                paramBpCode.Value = BpCode
                arParams(0) = paramBpCode

                ReturnString = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_GetBlackpltDesc", arParams)

            Catch ex As Exception
                Err.Raise(Err.Number, "Error GetDefaultAE!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
            Finally
            End Try

            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString


    End Function

    Public Function GetJobsForTemplateGrid(ByVal user As String,
                                           ByVal client As String,
                                           ByVal division As String,
                                           ByVal product As String,
                                           ByVal job As String,
                                           ByVal jobcomp As String,
                                           ByVal office As String,
                                           ByVal salesclass As String,
                                           ByVal ae As String,
                                           ByVal withclosed As Boolean,
                                           ByVal campaign As String,
                                           Optional ByVal CP As Boolean = False,
                                           Optional ByVal CPID As Integer = 0) As DataTable
        Try
            Dim arParams(12) As SqlParameter

            Dim paramUser As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUser.Value = user
            arParams(0) = paramUser
            Dim paramClient As New SqlParameter("@Client", SqlDbType.VarChar)
            paramClient.Value = client
            arParams(1) = paramClient
            Dim paramDivision As New SqlParameter("@Division", SqlDbType.VarChar)
            paramDivision.Value = division
            arParams(2) = paramDivision
            Dim paramProduct As New SqlParameter("@Product", SqlDbType.VarChar)
            paramProduct.Value = product
            arParams(3) = paramProduct
            Dim paramJob As New SqlParameter("@Job", SqlDbType.VarChar)
            paramJob.Value = job
            arParams(4) = paramJob
            Dim paramJobComp As New SqlParameter("@JobComp", SqlDbType.VarChar)
            paramJobComp.Value = jobcomp
            arParams(5) = paramJobComp
            Dim paramOffice As New SqlParameter("@Office", SqlDbType.VarChar)
            paramOffice.Value = office
            arParams(6) = paramOffice
            Dim paramSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar)
            paramSalesClass.Value = salesclass
            arParams(7) = paramSalesClass
            Dim paramAE As New SqlParameter("@AE", SqlDbType.VarChar)
            paramAE.Value = ae
            arParams(8) = paramAE
            Dim paramCampaign As New SqlParameter("@Campaign", SqlDbType.VarChar)
            paramCampaign.Value = campaign
            arParams(9) = paramCampaign
            Dim parameterCP As New SqlParameter("@CP", SqlDbType.Int)
            If CP = True Then
                parameterCP.Value = 1
            Else
                parameterCP.Value = 0
            End If
            arParams(10) = parameterCP

            Dim parameterCPID As New SqlParameter("@CPID", SqlDbType.Int)
            parameterCPID.Value = CPID
            arParams(11) = parameterCPID

            If withclosed = True Then
                Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_GetAllJobswithClosed", "dtdata", arParams)
            Else
                Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_GetAllJobs", "dtdata", arParams)
            End If
        Catch ex As Exception
            Return Nothing
            Err.Raise(Err.Number, "Error GetjobsTemplate!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Public Function GetDefaultTaxCode(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As String
        Dim SessionKey As String = "GetDefaultTaxCode" & ClientCode & DivisionCode & ProductCode
        Dim ReturnString As String = ""
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim arParams(3) As SqlParameter

                Dim paramClientCode As New SqlParameter("@Client", SqlDbType.VarChar)
                paramClientCode.Value = ClientCode
                arParams(0) = paramClientCode
                Dim paramDivisionCode As New SqlParameter("@Division", SqlDbType.VarChar)
                paramDivisionCode.Value = DivisionCode
                arParams(1) = paramDivisionCode
                Dim paramProductCode As New SqlParameter("@Product", SqlDbType.VarChar)
                paramProductCode.Value = ProductCode
                arParams(2) = paramProductCode

                ReturnString = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_GetDefaultTaxCode", arParams)

            Catch ex As Exception
            End Try

            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString

    End Function

    Public Function GetTmpltDefSC(ByVal JobTmpltCode As String) As String
        Dim SessionKey As String = "GetTmpltDefSC" & JobTmpltCode
        Dim ReturnString As String = ""
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim SQL_STRING As String
            Dim dr As SqlDataReader
            Dim oSQL As SqlHelper

            SQL_STRING = "SELECT DEF_SALES_CLASS"
            SQL_STRING += " FROM JOB_TMPLT_HDR WITH(NOLOCK)"
            SQL_STRING += " WHERE JOB_TMPLT_CODE = '" & JobTmpltCode & "';"

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL_STRING)

                If dr.HasRows Then
                    dr.Read()
                    If IsDBNull(dr.GetValue(0)) = False Then
                        ReturnString = dr.GetValue(0)
                    End If
                End If


            Catch ex As Exception
            End Try

            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString


    End Function

    Public Function GetThisJob(ByVal JobNumber As Integer) As SqlDataReader

        Dim dr As SqlDataReader

        Dim parameterJobNo As New SqlParameter("@JOB_NUMBER", SqlDbType.Int, 0)
        parameterJobNo.Value = JobNumber

        dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_job_get_by_jobno", parameterJobNo)


        Return dr

    End Function

    Public Function GetProjectScheduleStatusForDisplay(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer) As String
        Dim ReturnValue As String = "Project Schedule"

        Using MyConn As New SqlConnection(Me.mConnString)
            Dim SQL As New System.Text.StringBuilder
            With SQL
                .Append("SELECT TRAFFIC.TRF_CODE, TRAFFIC.TRF_DESCRIPTION")
                .Append(" FROM JOB_TRAFFIC WITH(NOLOCK) INNER JOIN")
                .Append(" TRAFFIC WITH(NOLOCK) ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE")
                .Append(" WHERE JOB_TRAFFIC.JOB_NUMBER = @JOB_NUMBER")
                .Append(" AND JOB_TRAFFIC.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR;")
            End With

            Dim MyCommand As New SqlCommand()
            With MyCommand
                .CommandType = CommandType.Text
                .CommandText = SQL.ToString()
                .Connection = MyConn
            End With

            Dim pJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            pJobNumber.Value = JobNumber
            Dim pJobComponentNbr As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            pJobComponentNbr.Value = JobComponentNbr

            MyCommand.Parameters.Add(pJobNumber)
            MyCommand.Parameters.Add(pJobComponentNbr)

            MyConn.Open()

            Dim Reader As SqlDataReader
            Reader = MyCommand.ExecuteReader()

            If Reader.HasRows = True Then
                Do While Reader.Read()
                    If Reader.IsDBNull(Reader.GetOrdinal("TRF_DESCRIPTION")) = False Then

                        ReturnValue = "Status:  " & Reader.GetValue(Reader.GetOrdinal("TRF_DESCRIPTION")).ToString()

                    End If
                Loop
            End If

        End Using

        Return ReturnValue

    End Function

    Public Function GetUserRightsForJobs(ByVal user As String) As DataSet
        Try
            Dim arParams(1) As SqlParameter
            Dim dr As DataSet

            Dim paramUser As New SqlParameter("@USER_ID", SqlDbType.VarChar)
            paramUser.Value = user
            arParams(0) = paramUser

            dr = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Job_GetUserRights", arParams)

            Return dr
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetjobsTemplate!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Public Function GetAdNumBlackPlt(ByVal AdNum As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterAdNum As New SqlParameter("@AdNum", SqlDbType.VarChar, 30)
        parameterAdNum.Value = AdNum

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_GetAdNumBlackPlt", parameterAdNum)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:usp_wv_GetAdNumBlackPlt", Err.Description)
        End Try

        Return dr
    End Function

    Public Function GetEstimateApproval(ByVal JobNum As Integer, ByVal JobCompNum As Integer) As DataTable
        Try
            Dim arParams(2) As SqlParameter

            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim dt As DataTable

            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_GetEstimateApproval", "estdt", arParams)

            Return dt
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetTemplate!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try

    End Function

    Public Overloads Function GetInfoForJobCopy(ByVal JobNo As Integer, ByVal closed As Boolean, ByVal user As String) As DataTable
        Dim dt As DataTable
        Dim arParams(3) As SqlParameter

        '*** Create Parameters
        Dim parameterJobNo As New SqlParameter("@JobNo", SqlDbType.Int)
        parameterJobNo.Value = JobNo
        arParams(0) = parameterJobNo

        Dim parameterClosed As New SqlParameter("@Closed", SqlDbType.SmallInt)
        If closed = True Then
            parameterClosed.Value = 1
        Else
            parameterClosed.Value = 0
        End If
        arParams(1) = parameterClosed

        Dim paramUser As New SqlParameter("@UserID", SqlDbType.VarChar)
        paramUser.Value = user
        arParams(2) = paramUser

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_Copy_Info", "dtCopy", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetInfoForJobCopy", Err.Description)
        End Try

        Return dt
    End Function

    Public Function UserDefinedFieldAllowsUserEntry(ByVal UserField As String) As Boolean

        UserField = UserField.Replace("JOB_COMPONENT", "JOB_CMP")

        Dim SessionKey As String = "GetEditableUDV" & UserField
        Dim IsValid As Boolean = False

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim arParams(1) As SqlParameter

                Dim paramUserField As New SqlParameter("@UserField", SqlDbType.VarChar)
                paramUserField.Value = UserField
                arParams(0) = paramUserField

                IsValid = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_Editable", arParams)

            Catch ex As Exception

                IsValid = False

            End Try

            HttpContext.Current.Session(SessionKey) = IsValid

        Else

            IsValid = HttpContext.Current.Session(SessionKey)

        End If

        Return IsValid

    End Function

    Private Function CheckAP(ByVal JobNum As Integer, ByVal Office As String) As Boolean
        Dim IsValid As Boolean = False
        'Dim SessionKey As String = "CheckAP" & JobNum.ToString() & Office.ToString()

        'If HttpContext.Current.Session(SessionKey) Is Nothing Then
        Dim ireturn As Integer = 0
        Dim arparams(2) As SqlParameter

        Dim parameterJobNum As New SqlParameter("@JobNum", SqlDbType.Int)
        parameterJobNum.Value = JobNum
        arparams(0) = parameterJobNum

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = Office
        arparams(1) = parameterOffice

        Try
            ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_CheckAP", arparams))
        Catch
            ireturn = 0
        End Try

        If ireturn > 0 Then
            IsValid = True
        Else
            IsValid = False
        End If

        '    HttpContext.Current.Session(SessionKey) = IsValid
        'Else
        '    IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        'End If

        Return IsValid


    End Function

    Private Function CheckAR(ByVal JobNum As Integer, ByVal JobComp As Integer) As Boolean
        Dim IsValid As Boolean = False
        'Dim SessionKey As String = "CheckAR" & JobNum.ToString() & JobComp.ToString()

        'If HttpContext.Current.Session(SessionKey) Is Nothing Then
        Dim ireturn As Integer = 0
        Dim arparams(2) As SqlParameter

        Dim parameterJobNum As New SqlParameter("@JobNum", SqlDbType.Int)
        parameterJobNum.Value = JobNum
        arparams(0) = parameterJobNum

        Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.Int)
        parameterJobComp.Value = JobComp
        arparams(1) = parameterJobComp

        Try
            ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_CheckAR", arparams))
        Catch
            ireturn = 0
        End Try

        If ireturn > 0 Then
            IsValid = True
        Else
            IsValid = False
        End If

        '    HttpContext.Current.Session(SessionKey) = IsValid
        'Else
        '    IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        'End If

        Return IsValid


    End Function

    Private Function CheckARJob(ByVal JobNum As Integer) As Boolean
        Dim IsValid As Boolean = False
        'Dim SessionKey As String = "CheckAR" & JobNum.ToString() & JobComp.ToString()

        'If HttpContext.Current.Session(SessionKey) Is Nothing Then
        Dim ireturn As Integer = 0
        Dim arparams(2) As SqlParameter

        Dim parameterJobNum As New SqlParameter("@JobNum", SqlDbType.Int)
        parameterJobNum.Value = JobNum
        arparams(0) = parameterJobNum

        Try
            ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_CheckAR_job", arparams))
        Catch
            ireturn = 0
        End Try

        If ireturn > 0 Then
            IsValid = True
        Else
            IsValid = False
        End If

        '    HttpContext.Current.Session(SessionKey) = IsValid
        'Else
        '    IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        'End If

        Return IsValid


    End Function

    Public Function GetBudget(ByVal JobNum As Integer, ByVal JobCompNum As Integer) As DataSet
        Try
            Dim arParams(2) As SqlParameter

            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim ds As DataSet

            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_GetBudget", arParams)

            Return ds
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetTemplate!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try

    End Function

    Public Function GetContactDP(ByVal client As String) As DataSet
        Try
            Dim arParams(2) As SqlParameter

            Dim paramClient As New SqlParameter("@Client", SqlDbType.VarChar)
            paramClient.Value = client
            'arParams(0) = paramJobNumber
            'Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            'paramJobCompNumber.Value = JobCompNum
            'arParams(1) = paramJobCompNumber
            Dim ds As DataSet

            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_ContactDPList", paramClient)

            Return ds
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetContactDP!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try

    End Function

    Public Function AddNewContact(ByVal Client As String,
                                   ByVal Contact As String,
                                   ByVal First As String,
                                   ByVal Last As String,
                                   ByVal MI As String,
                                   ByVal Title As String,
                                   ByVal Address1 As String,
                                   ByVal Address2 As String,
                                   ByVal City As String,
                                   ByVal County As String,
                                   ByVal State As String,
                                   ByVal Country As String,
                                   ByVal Zip As String,
                                   ByVal Telephone As String,
                                   ByVal TelephoneExt As String,
                                   ByVal Fax As String,
                                   ByVal FaxExt As String,
                                   ByVal Email As String,
                                   ByVal Cell As String,
                                   ByVal ScheduleUser As Boolean,
                                   ByVal CPUser As Boolean,
                                   ByVal GetAlerts As Boolean,
                                   ByVal Email_Rcpt As Boolean,
                                   ByVal Inactive As Boolean,
                                   ByVal CopyAdress As Boolean,
                                   ByVal Comment As String,
                                   ByVal ContactTypeID As Integer) As Integer
        ''Dim NewContact As AdvantageFramework.Database.Entities.ClientContact
        ''With NewContact

        ''    .ClientCode = Client
        ''    .ContactCode = Contact
        ''    .FirstName = First
        ''    .LastName = Last
        ''    .MiddleInitial = MI
        ''    .Title = Title
        ''    .Address = Address1
        ''    .Address2 = Address2
        ''    .City = City
        ''    .County = County
        ''    .State = State
        ''    .Country = Country
        ''    .Zip = Zip
        ''    .Telephone = Telephone
        ''    .TelephoneExtension = TelephoneExt
        ''    .Fax = Fax
        ''    .FaxExtension = FaxExt
        ''    .EmailAddress = Email
        ''    .CellPhone = Cell

        ''    .ScheduleUser = ScheduleUser
        ''    .IsClientPortalUser = CPUser
        ''    .GetAlerts = GetAlerts
        ''    .GetEmails = Email_Rcpt '?
        ''    .IsInactive = Inactive
        ''    'copyadress??
        ''    .Comments = Comment

        ''End With

        Try
            Dim arParams(28) As SqlParameter

            Dim parameterVendor As New SqlParameter("@CL_CODE", SqlDbType.VarChar)
            parameterVendor.Value = Client
            arParams(0) = parameterVendor

            Dim parameterContact As New SqlParameter("@CONT_CODE", SqlDbType.VarChar)
            parameterContact.Value = Contact
            arParams(1) = parameterContact

            Dim paramVC_FNAME As New SqlParameter("@CONT_FNAME", SqlDbType.VarChar)
            If First.Trim() = "" Then
                paramVC_FNAME.Value = System.DBNull.Value
            Else
                paramVC_FNAME.Value = First
            End If
            arParams(2) = paramVC_FNAME

            Dim paramVC_LNAME As New SqlParameter("@CONT_LNAME", SqlDbType.VarChar)
            If Last.Trim() = "" Then
                paramVC_LNAME.Value = System.DBNull.Value
            Else
                paramVC_LNAME.Value = Last
            End If
            arParams(3) = paramVC_LNAME

            Dim paramVC_MI As New SqlParameter("@CONT_MI", SqlDbType.VarChar)
            If MI.Trim() = "" Then
                paramVC_MI.Value = System.DBNull.Value
            Else
                paramVC_MI.Value = MI
            End If
            arParams(4) = paramVC_MI

            Dim paramVC_TITLE As New SqlParameter("@CONT_TITLE", SqlDbType.VarChar)
            If Title.Trim() = "" Then
                paramVC_TITLE.Value = System.DBNull.Value
            Else
                paramVC_TITLE.Value = Title
            End If
            arParams(5) = paramVC_TITLE

            Dim paramVC_ADDRESS1 As New SqlParameter("@CONT_ADDRESS1", SqlDbType.VarChar)
            If Address1.Trim() = "" Then
                paramVC_ADDRESS1.Value = System.DBNull.Value
            Else
                paramVC_ADDRESS1.Value = Address1
            End If
            arParams(6) = paramVC_ADDRESS1

            Dim paramVC_ADDRESS2 As New SqlParameter("@CONT_ADDRESS2", SqlDbType.VarChar)
            If Address2.Trim() = "" Then
                paramVC_ADDRESS2.Value = System.DBNull.Value
            Else
                paramVC_ADDRESS2.Value = Address2
            End If
            arParams(7) = paramVC_ADDRESS2

            Dim paramVC_CITY As New SqlParameter("@CONT_CITY", SqlDbType.VarChar)
            If City.Trim() = "" Then
                paramVC_CITY.Value = System.DBNull.Value
            Else
                paramVC_CITY.Value = City
            End If
            arParams(8) = paramVC_CITY

            Dim paramVC_COUNTY As New SqlParameter("@CONT_COUNTY", SqlDbType.VarChar)
            If County.Trim() = "" Then
                paramVC_COUNTY.Value = System.DBNull.Value
            Else
                paramVC_COUNTY.Value = County
            End If
            arParams(9) = paramVC_COUNTY

            Dim paramVC_STATE As New SqlParameter("@CONT_STATE", SqlDbType.VarChar)
            If State.Trim() = "" Then
                paramVC_STATE.Value = System.DBNull.Value
            Else
                paramVC_STATE.Value = State
            End If
            arParams(10) = paramVC_STATE

            Dim paramVC_COUNTRY As New SqlParameter("@CONT_COUNTRY", SqlDbType.VarChar)
            If Country.Trim() = "" Then
                paramVC_COUNTRY.Value = System.DBNull.Value
            Else
                paramVC_COUNTRY.Value = Country
            End If
            arParams(11) = paramVC_COUNTRY

            Dim paramVC_ZIP As New SqlParameter("@CONT_ZIP", SqlDbType.VarChar)
            If Zip.Trim() = "" Then
                paramVC_ZIP.Value = System.DBNull.Value
            Else
                paramVC_ZIP.Value = Zip
            End If
            arParams(12) = paramVC_ZIP

            Dim paramVC_TELEPHONE As New SqlParameter("@CONT_TELEPHONE", SqlDbType.VarChar)
            If Telephone.Trim() = "" Then
                paramVC_TELEPHONE.Value = System.DBNull.Value
            Else
                paramVC_TELEPHONE.Value = Telephone
            End If
            arParams(13) = paramVC_TELEPHONE

            Dim paramVC_EXTENTION As New SqlParameter("@CONT_EXTENTION", SqlDbType.VarChar)
            If TelephoneExt.Trim() = "" Then
                paramVC_EXTENTION.Value = System.DBNull.Value
            Else
                paramVC_EXTENTION.Value = TelephoneExt
            End If
            arParams(14) = paramVC_EXTENTION

            Dim paramVC_FAX As New SqlParameter("@CONT_FAX", SqlDbType.VarChar)
            If Fax.Trim() = "" Then
                paramVC_FAX.Value = System.DBNull.Value
            Else
                paramVC_FAX.Value = Fax
            End If
            arParams(15) = paramVC_FAX

            Dim paramVC_FAX_EXTENTION As New SqlParameter("@CONT_FAX_EXTENTION", SqlDbType.VarChar)
            If FaxExt.Trim() = "" Then
                paramVC_FAX_EXTENTION.Value = System.DBNull.Value
            Else
                paramVC_FAX_EXTENTION.Value = FaxExt
            End If
            arParams(16) = paramVC_FAX_EXTENTION

            Dim paramEMAIL_ADDRESS As New SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar)
            If Email.Trim() = "" Then
                paramEMAIL_ADDRESS.Value = System.DBNull.Value
            Else
                paramEMAIL_ADDRESS.Value = Email
            End If
            arParams(17) = paramEMAIL_ADDRESS

            Dim paramVC_PHONE_CELL As New SqlParameter("@CELL_PHONE", SqlDbType.VarChar)
            If Cell.Trim() = "" Then
                paramVC_PHONE_CELL.Value = System.DBNull.Value
            Else
                paramVC_PHONE_CELL.Value = Cell
            End If
            arParams(18) = paramVC_PHONE_CELL

            Dim paramSCHEDULE_USER As New SqlParameter("@SCHEDULE_USER", SqlDbType.SmallInt)
            If ScheduleUser = True Then
                paramSCHEDULE_USER.Value = 1
            Else
                paramSCHEDULE_USER.Value = 0
            End If
            arParams(19) = paramSCHEDULE_USER

            Dim paramCP_USER As New SqlParameter("@CP_USER", SqlDbType.SmallInt)
            If CPUser = True Then
                paramCP_USER.Value = 1
            Else
                paramCP_USER.Value = 0
            End If
            arParams(20) = paramCP_USER

            Dim paramGETS_ALERTS As New SqlParameter("@GETS_ALERTS", SqlDbType.SmallInt)
            If GetAlerts = True Then
                paramGETS_ALERTS.Value = 1
            Else
                paramGETS_ALERTS.Value = 0
            End If
            arParams(21) = paramGETS_ALERTS

            Dim paramEMAIL_RCPT As New SqlParameter("@EMAIL_RCPT", SqlDbType.SmallInt)
            If Email_Rcpt = True Then
                paramEMAIL_RCPT.Value = 1
            Else
                paramEMAIL_RCPT.Value = 0
            End If
            arParams(22) = paramEMAIL_RCPT

            Dim paramINACTIVE As New SqlParameter("@INACTIVE", SqlDbType.SmallInt)
            If Inactive = True Then
                paramINACTIVE.Value = 1
            Else
                paramINACTIVE.Value = 0
            End If
            arParams(23) = paramINACTIVE

            Dim paramCOPY_ADDRESS As New SqlParameter("@COPY_ADDRESS", SqlDbType.SmallInt)
            If CopyAdress = True Then
                paramCOPY_ADDRESS.Value = 1
            Else
                paramCOPY_ADDRESS.Value = 0
            End If
            arParams(24) = paramCOPY_ADDRESS

            Dim paramCONT_COMMENT As New SqlParameter("@CONT_COMMENT", SqlDbType.Text)
            If Comment.Trim() = "" Then
                paramCONT_COMMENT.Value = System.DBNull.Value
            Else
                paramCONT_COMMENT.Value = Comment
            End If
            arParams(25) = paramCONT_COMMENT

            Dim paramCONTACT_TYPE_ID As New SqlParameter("@CONTACT_TYPE_ID", SqlDbType.Int)
            paramCONTACT_TYPE_ID.Value = ContactTypeID
            arParams(26) = paramCONTACT_TYPE_ID

            Dim ID As New SqlParameter("@CDP_ID", SqlDbType.SmallInt)
            ID.Direction = ParameterDirection.Output
            arParams(27) = ID


            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Client_AddContact", arParams)
                Return ID.Value
            Catch ex As Exception
                Return 0
            End Try
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function UpdateContact(ByVal cpdid As Integer, ByVal Client As String,
                                   ByVal Contact As String,
                                   ByVal First As String,
                                   ByVal Last As String,
                                   ByVal MI As String,
                                   ByVal Title As String,
                                   ByVal Address1 As String,
                                   ByVal Address2 As String,
                                   ByVal City As String,
                                   ByVal County As String,
                                   ByVal State As String,
                                   ByVal Country As String,
                                   ByVal Zip As String,
                                   ByVal Telephone As String,
                                   ByVal TelephoneExt As String,
                                   ByVal Fax As String,
                                   ByVal FaxExt As String,
                                   ByVal Email As String,
                                   ByVal Cell As String,
                                   ByVal ScheduleUser As Boolean,
                                   ByVal CPUser As Boolean,
                                   ByVal GetAlerts As Boolean,
                                   ByVal Email_Rcpt As Boolean,
                                   ByVal Inactive As Boolean,
                                   ByVal CopyAdress As Boolean,
                                   ByVal Comment As String,
                                   ByVal ContactTypeID As Integer) As Boolean
        Try
            Dim arParams(28) As SqlParameter

            Dim parameterVendor As New SqlParameter("@CL_CODE", SqlDbType.VarChar)
            parameterVendor.Value = Client
            arParams(0) = parameterVendor

            Dim parameterContact As New SqlParameter("@CONT_CODE", SqlDbType.VarChar)
            parameterContact.Value = Contact
            arParams(1) = parameterContact

            Dim paramVC_FNAME As New SqlParameter("@CONT_FNAME", SqlDbType.VarChar)
            If First.Trim() = "" Then
                paramVC_FNAME.Value = System.DBNull.Value
            Else
                paramVC_FNAME.Value = First
            End If
            arParams(2) = paramVC_FNAME

            Dim paramVC_LNAME As New SqlParameter("@CONT_LNAME", SqlDbType.VarChar)
            If Last.Trim() = "" Then
                paramVC_LNAME.Value = System.DBNull.Value
            Else
                paramVC_LNAME.Value = Last
            End If
            arParams(3) = paramVC_LNAME

            Dim paramVC_MI As New SqlParameter("@CONT_MI", SqlDbType.VarChar)
            If MI.Trim() = "" Then
                paramVC_MI.Value = System.DBNull.Value
            Else
                paramVC_MI.Value = MI
            End If
            arParams(4) = paramVC_MI

            Dim paramVC_TITLE As New SqlParameter("@CONT_TITLE", SqlDbType.VarChar)
            If Title.Trim() = "" Then
                paramVC_TITLE.Value = System.DBNull.Value
            Else
                paramVC_TITLE.Value = Title
            End If
            arParams(5) = paramVC_TITLE

            Dim paramVC_ADDRESS1 As New SqlParameter("@CONT_ADDRESS1", SqlDbType.VarChar)
            If Address1.Trim() = "" Then
                paramVC_ADDRESS1.Value = System.DBNull.Value
            Else
                paramVC_ADDRESS1.Value = Address1
            End If
            arParams(6) = paramVC_ADDRESS1

            Dim paramVC_ADDRESS2 As New SqlParameter("@CONT_ADDRESS2", SqlDbType.VarChar)
            If Address2.Trim() = "" Then
                paramVC_ADDRESS2.Value = System.DBNull.Value
            Else
                paramVC_ADDRESS2.Value = Address2
            End If
            arParams(7) = paramVC_ADDRESS2

            Dim paramVC_CITY As New SqlParameter("@CONT_CITY", SqlDbType.VarChar)
            If City.Trim() = "" Then
                paramVC_CITY.Value = System.DBNull.Value
            Else
                paramVC_CITY.Value = City
            End If
            arParams(8) = paramVC_CITY

            Dim paramVC_COUNTY As New SqlParameter("@CONT_COUNTY", SqlDbType.VarChar)
            If County.Trim() = "" Then
                paramVC_COUNTY.Value = System.DBNull.Value
            Else
                paramVC_COUNTY.Value = County
            End If
            arParams(9) = paramVC_COUNTY

            Dim paramVC_STATE As New SqlParameter("@CONT_STATE", SqlDbType.VarChar)
            If State.Trim() = "" Then
                paramVC_STATE.Value = System.DBNull.Value
            Else
                paramVC_STATE.Value = State
            End If
            arParams(10) = paramVC_STATE

            Dim paramVC_COUNTRY As New SqlParameter("@CONT_COUNTRY", SqlDbType.VarChar)
            If Country.Trim() = "" Then
                paramVC_COUNTRY.Value = System.DBNull.Value
            Else
                paramVC_COUNTRY.Value = Country
            End If
            arParams(11) = paramVC_COUNTRY

            Dim paramVC_ZIP As New SqlParameter("@CONT_ZIP", SqlDbType.VarChar)
            If Zip.Trim() = "" Then
                paramVC_ZIP.Value = System.DBNull.Value
            Else
                paramVC_ZIP.Value = Zip
            End If
            arParams(12) = paramVC_ZIP

            Dim paramVC_TELEPHONE As New SqlParameter("@CONT_TELEPHONE", SqlDbType.VarChar)
            If Telephone.Trim() = "" Then
                paramVC_TELEPHONE.Value = System.DBNull.Value
            Else
                paramVC_TELEPHONE.Value = Telephone
            End If
            arParams(13) = paramVC_TELEPHONE

            Dim paramVC_EXTENTION As New SqlParameter("@CONT_EXTENTION", SqlDbType.VarChar)
            If TelephoneExt.Trim() = "" Then
                paramVC_EXTENTION.Value = System.DBNull.Value
            Else
                paramVC_EXTENTION.Value = TelephoneExt
            End If
            arParams(14) = paramVC_EXTENTION

            Dim paramVC_FAX As New SqlParameter("@CONT_FAX", SqlDbType.VarChar)
            If Fax.Trim() = "" Then
                paramVC_FAX.Value = System.DBNull.Value
            Else
                paramVC_FAX.Value = Fax
            End If
            arParams(15) = paramVC_FAX

            Dim paramVC_FAX_EXTENTION As New SqlParameter("@CONT_FAX_EXTENTION", SqlDbType.VarChar)
            If FaxExt.Trim() = "" Then
                paramVC_FAX_EXTENTION.Value = System.DBNull.Value
            Else
                paramVC_FAX_EXTENTION.Value = FaxExt
            End If
            arParams(16) = paramVC_FAX_EXTENTION

            Dim paramEMAIL_ADDRESS As New SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar)
            If Email.Trim() = "" Then
                paramEMAIL_ADDRESS.Value = System.DBNull.Value
            Else
                paramEMAIL_ADDRESS.Value = Email
            End If
            arParams(17) = paramEMAIL_ADDRESS

            Dim paramVC_PHONE_CELL As New SqlParameter("@CELL_PHONE", SqlDbType.VarChar)
            If Cell.Trim() = "" Then
                paramVC_PHONE_CELL.Value = System.DBNull.Value
            Else
                paramVC_PHONE_CELL.Value = Cell
            End If
            arParams(18) = paramVC_PHONE_CELL

            Dim paramSCHEDULE_USER As New SqlParameter("@SCHEDULE_USER", SqlDbType.SmallInt)
            If ScheduleUser = True Then
                paramSCHEDULE_USER.Value = 1
            Else
                paramSCHEDULE_USER.Value = 0
            End If
            arParams(19) = paramSCHEDULE_USER

            Dim paramCP_USER As New SqlParameter("@CP_USER", SqlDbType.SmallInt)
            If CPUser = True Then
                paramCP_USER.Value = 1
            Else
                paramCP_USER.Value = 0
            End If
            arParams(20) = paramCP_USER

            Dim paramGETS_ALERTS As New SqlParameter("@GETS_ALERTS", SqlDbType.SmallInt)
            If GetAlerts = True Then
                paramGETS_ALERTS.Value = 1
            Else
                paramGETS_ALERTS.Value = 0
            End If
            arParams(21) = paramGETS_ALERTS

            Dim paramEMAIL_RCPT As New SqlParameter("@EMAIL_RCPT", SqlDbType.SmallInt)
            If Email_Rcpt = True Then
                paramEMAIL_RCPT.Value = 1
            Else
                paramEMAIL_RCPT.Value = 0
            End If
            arParams(22) = paramEMAIL_RCPT

            Dim paramINACTIVE As New SqlParameter("@INACTIVE", SqlDbType.SmallInt)
            If Inactive = True Then
                paramINACTIVE.Value = 1
            Else
                paramINACTIVE.Value = 0
            End If
            arParams(23) = paramINACTIVE

            Dim paramCOPY_ADDRESS As New SqlParameter("@COPY_ADDRESS", SqlDbType.SmallInt)
            If CopyAdress = True Then
                paramCOPY_ADDRESS.Value = 1
            Else
                paramCOPY_ADDRESS.Value = 0
            End If
            arParams(24) = paramCOPY_ADDRESS

            Dim paramCONT_COMMENT As New SqlParameter("@CONT_COMMENT", SqlDbType.Text)
            If Comment.Trim() = "" Then
                paramCONT_COMMENT.Value = System.DBNull.Value
            Else
                paramCONT_COMMENT.Value = Comment
            End If
            arParams(25) = paramCONT_COMMENT

            Dim paramID As New SqlParameter("@CDP_ID", SqlDbType.SmallInt)
            paramID.Value = cpdid
            arParams(26) = paramID

            Dim paramCONTACT_TYPE_ID As New SqlParameter("@CONTACT_TYPE_ID", SqlDbType.Int)
            paramCONTACT_TYPE_ID.Value = ContactTypeID
            arParams(27) = paramCONTACT_TYPE_ID

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Client_UpdateContact", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function AddNewContactDP(ByVal CDP_ID As Integer,
                                   ByVal Division As String,
                                   ByVal Product As String) As Boolean
        Try
            Dim arParams(3) As SqlParameter

            Dim parameterCDP_ID As New SqlParameter("@CDP_ID", SqlDbType.SmallInt)
            parameterCDP_ID.Value = CDP_ID
            arParams(0) = parameterCDP_ID

            Dim parameterDIV_CODE As New SqlParameter("@DIV_CODE", SqlDbType.VarChar)
            parameterDIV_CODE.Value = Division
            arParams(1) = parameterDIV_CODE

            Dim paramPRD_CODE As New SqlParameter("@PRD_CODE", SqlDbType.VarChar)
            paramPRD_CODE.Value = Product
            arParams(2) = paramPRD_CODE

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Client_AddContactDP", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetContact(ByVal cpdid As Integer) As SqlDataReader
        Try
            Dim arParams(2) As SqlParameter

            Dim paramClient As New SqlParameter("@CDP_ID", SqlDbType.SmallInt)
            paramClient.Value = cpdid

            Dim dr As SqlDataReader

            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Client_GetContact", paramClient)

            Return dr
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetContact!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try

    End Function

    Public Function GetContactDivPrd(ByVal cpdid As Integer) As SqlDataReader
        Try
            Dim arParams(2) As SqlParameter

            Dim paramClient As New SqlParameter("@CDP_ID", SqlDbType.SmallInt)
            paramClient.Value = cpdid

            Dim dr As SqlDataReader

            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Client_GetContactDP", paramClient)

            Return dr
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetContact!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try

    End Function

    Public Function DeleteContactDP(ByVal CDP_ID As Integer) As Boolean
        Try
            Dim arParams(3) As SqlParameter

            Dim parameterCDP_ID As New SqlParameter("@CDP_ID", SqlDbType.SmallInt)
            parameterCDP_ID.Value = CDP_ID
            arParams(0) = parameterCDP_ID

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Client_DeleteContactDP", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetContactSecurity(ByVal user As String) As String
        Dim SessionKey As String = "GetContactSecurity" & user
        Dim ReturnString As String = ""
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim arParams(1) As SqlParameter
                Dim paramUser As New SqlParameter("@UserCode", SqlDbType.VarChar)
                paramUser.Value = user
                arParams(0) = paramUser

                ReturnString = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_GetCCSecurity", arParams)

            Catch ex As Exception

            End Try

            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString
    End Function

    Private Function HasAccessToFinanceAccounting_JobProcessCtrl() As Boolean
        Dim SessionKey As String = "CheckModuleAccess" & AdvantageFramework.Security.Modules.FinanceAccounting_JobProcessCtrl.ToString()
        If Not HttpContext.Current.Session(SessionKey) Is Nothing Then
            Return MiscFN.IntToBool(CType(HttpContext.Current.Session(SessionKey), Integer))
        End If
    End Function

    Public Function GetContactOption() As Integer
        Dim SessionKey As String = "GetContactOption"
        Dim ReturnInteger As Integer = 0
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim arParams(1) As SqlParameter

                ReturnInteger = CType(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_GetContactOption"), Integer)

            Catch ex As Exception
                ReturnInteger = 0
            End Try

            HttpContext.Current.Session(SessionKey) = ReturnInteger
        Else
            ReturnInteger = CType(HttpContext.Current.Session(SessionKey).ToString(), Integer)
        End If

        Return ReturnInteger
    End Function

    Public Function CheckContactDuplicates(ByVal client As String, ByVal contcode As String)
        Try
            Dim arParams(2) As SqlParameter

            Dim paramClient As New SqlParameter("@Client", SqlDbType.VarChar)
            paramClient.Value = client
            arParams(0) = paramClient

            Dim paramContCode As New SqlParameter("@ContCode", SqlDbType.VarChar)
            paramContCode.Value = contcode
            arParams(1) = paramContCode

            Dim dup As Integer

            dup = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_CheckDuplicateContacts", arParams)

            If dup = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Err.Raise(Err.Number, "Error ContactDUP!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try

    End Function

    Public Function GetJobProcessLog(ByVal JobNum As Integer, ByVal JobCompNum As Integer) As DataSet
        Try
            Dim arParams(2) As SqlParameter

            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim ds As DataSet

            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_GetJobProcessLog", arParams)

            Return ds
        Catch ex As Exception
            Err.Raise(Err.Number, "Error usp_wv_Job_Template_GetJobProcessLog!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try

    End Function

    Public Function AddNewJobProcessLog(ByVal JobNum As Integer, ByVal CompNum As Integer, ByVal OrigControl As String, ByVal NewControl As String, ByVal user As String, ByVal comment As String) As Boolean
        Try
            Dim arParams(6) As SqlParameter

            Dim paramcJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramcJOB_NUMBER.Value = JobNum
            arParams(0) = paramcJOB_NUMBER

            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJOB_COMPONENT_NBR.Value = CompNum
            arParams(1) = paramJOB_COMPONENT_NBR

            Dim paramORIG_CONTROL As New SqlParameter("@ORIG_CONTROL", SqlDbType.SmallInt)
            If OrigControl = "" Then
                paramORIG_CONTROL.Value = NewControl
            Else
                paramORIG_CONTROL.Value = OrigControl
            End If
            arParams(2) = paramORIG_CONTROL

            Dim paramNEW_CONTROL As New SqlParameter("@NEW_CONTROL", SqlDbType.SmallInt)
            paramNEW_CONTROL.Value = NewControl
            arParams(3) = paramNEW_CONTROL

            Dim paramUSER_CODE As New SqlParameter("@USER_CODE", SqlDbType.VarChar)
            paramUSER_CODE.Value = user
            arParams(4) = paramUSER_CODE

            Dim paramCOMMENT As New SqlParameter("@COMMENT", SqlDbType.Text)
            paramCOMMENT.Value = comment
            arParams(5) = paramCOMMENT


            oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "dbo.usp_wv_Job_Template_AddJobProcessLog", arParams)
            Return True
        Catch ex As Exception
            Err.Raise(9999, Err.Source, Err.Description)
        End Try

    End Function

    Public Function UpdateJobProcessLog(ByVal JobNum As Integer, ByVal CompNum As Integer, ByVal NewControl As String, ByVal comment As String) As Integer
        Try
            Dim arParams(6) As SqlParameter
            Dim retInt As Integer

            Dim paramcJOB_NUMBER As New SqlParameter("@job_number", SqlDbType.Int)
            paramcJOB_NUMBER.Value = JobNum
            arParams(0) = paramcJOB_NUMBER

            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@job_component_nbr", SqlDbType.SmallInt)
            paramJOB_COMPONENT_NBR.Value = CompNum
            arParams(1) = paramJOB_COMPONENT_NBR

            Dim paramNEW_CONTROL As New SqlParameter("@job_process_control_in", SqlDbType.SmallInt)
            paramNEW_CONTROL.Value = CInt(NewControl)
            arParams(2) = paramNEW_CONTROL

            Dim paramCOMMENT As New SqlParameter("@comments", SqlDbType.Text)
            paramCOMMENT.Value = comment
            arParams(3) = paramCOMMENT

            Dim paramReturn As New SqlParameter("@ret_val", SqlDbType.Int)
            paramReturn.Direction = ParameterDirection.Output
            arParams(4) = paramReturn

            Dim paramUSERCODE As New SqlParameter("@user_id", SqlDbType.Text)
            paramUSERCODE.Value = HttpContext.Current.Session("UserCode")
            arParams(5) = paramUSERCODE

            oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "advsp_update_job_process_control", arParams)
            Return paramReturn.Value
        Catch ex As Exception
            Err.Raise(9999, Err.Source, Err.Description)
        End Try

    End Function

    Public Function GetAccountSetupData(ByVal JobNum As Integer, ByVal JobCompNum As Integer) As DataSet
        Try
            Dim arParams(2) As SqlParameter

            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim ds As DataSet

            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "advsp_accountsetup_data", arParams)

            Return ds
        Catch ex As Exception
            Err.Raise(Err.Number, "Error advsp_accountsetup_data!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try

    End Function

#End Region

#Region " Datatables and In-memory data manipulation "
    Private mDtFormData As DataTable = New DataTable("FormData")
    Private mDtUserData As DataTable = New DataTable("UserData")
    Private mDtLookupData As DataTable = New DataTable("LookupData")

    'Main DT from db
    Public Overloads Function CreateDataTable() As DataTable
        Try
            Return mDtFormData
        Catch ex As Exception
            Err.Raise(Err.Number, "Error!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try
    End Function

    Public Overloads Function CreateDataTable(ByVal CtrlPage As System.Web.UI.Control) As DataTable
        Try
            AddDTColumns(mDtFormData)
            RecurseAllControls(CtrlPage, mDtFormData)
            'return it to use dt on forms; might not be needed
            'after refinement, both CreateDataTable routines might become private
            Return mDtFormData
        Catch ex As Exception
            Err.Raise(Err.Number, "Error!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try
    End Function

    Public Overloads Sub CreateDataTable(ByVal ADataTable As DataTable, ByVal CtrlPage As System.Web.UI.Control)
        Try
            AddDTColumns(ADataTable)
            RecurseAllControls(CtrlPage, ADataTable)
        Catch ex As Exception
            Err.Raise(Err.Number, "Error!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try
    End Sub

    Private Sub AddDTColumns(ByVal aDataTable As DataTable)
        Dim colItemCode As DataColumn = New DataColumn("ItemCode")
        colItemCode.DataType = System.Type.GetType("System.String")
        aDataTable.Columns.Add(colItemCode)

        Dim colControlID As DataColumn = New DataColumn("ControlID")
        colControlID.DataType = System.Type.GetType("System.String")
        aDataTable.Columns.Add(colControlID)

        Dim colDBValue As DataColumn = New DataColumn("DBValue")
        colDBValue.DataType = System.Type.GetType("System.String")
        aDataTable.Columns.Add(colDBValue)

        Dim colFormValue As DataColumn = New DataColumn("FormValue")
        colFormValue.DataType = System.Type.GetType("System.String")
        aDataTable.Columns.Add(colFormValue)

    End Sub

    Private Overloads Sub AddDTRow(ByVal ADataTable As DataTable, ByVal strControlID As String, ByVal strValue As String, ByVal strItemCode As String)
        Try
            Dim MyRow As DataRow
            MyRow = ADataTable.NewRow
            With MyRow
                .Item("ItemCode") = strItemCode
                .Item("ControlID") = strControlID
                .Item("DBValue") = strValue
                .Item("FormValue") = strValue
            End With
            ADataTable.Rows.Add(MyRow)
        Catch ex As Exception
            Err.Raise(Err.Number, "Error in fn: AddDTRow!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Sub

    Private Overloads Sub AddDTRow(ByVal ADataTable As DataTable, ByVal strControlID As String, ByVal strValue As String)
        Try
            Dim MyRow As DataRow
            MyRow = ADataTable.NewRow
            With MyRow
                .Item("ControlID") = strControlID
                .Item("DBValue") = strValue
            End With
            ADataTable.Rows.Add(MyRow)
        Catch ex As Exception
            Err.Raise(Err.Number, "Error in fn: AddDTRow!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Sub

    'DT from dynamic form
    Public Sub UpdateDTFormValues(ByVal TheMainDataTable As DataTable, ByVal TheSecondaryDataTable As DataTable)
        Dim TheControlID As String = ""
        Dim TheValue As String = ""
        For i As Integer = 0 To TheMainDataTable.Rows.Count - 1
            TheControlID = ""
            TheValue = ""
            TheControlID = TheMainDataTable.Rows(i)("ControlID")
            If TheControlID <> "ctl00_ContentPlaceHolderMain_" Then
                For j As Integer = 0 To TheSecondaryDataTable.Rows.Count - 1
                    If TheSecondaryDataTable.Rows(j)("ControlID") = TheControlID Then
                        TheValue = TheSecondaryDataTable.Rows(j)("FormValue")
                        Exit For
                    End If
                Next
                TheMainDataTable.Select("ControlID = '" & TheControlID & "'")(0)("FormValue") = TheValue
            End If
        Next
    End Sub

    Public Function CreateUserDataDataTable(ByVal ThePage As System.Web.UI.Control) As DataTable
        Try
            AddUserDataDTColumns(mDtUserData)
            RecursUserDataAllControls(ThePage, mDtUserData)
            Return mDtUserData
        Catch ex As Exception
            Err.Raise(Err.Number, "Error!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try
    End Function

    Private Sub AddUserDataDTColumns(ByVal aDataTable As DataTable)
        Dim colControlID As DataColumn = New DataColumn("ControlID")
        colControlID.DataType = System.Type.GetType("System.String")
        aDataTable.Columns.Add(colControlID)

        Dim colValue As DataColumn = New DataColumn("FormValue")
        colValue.DataType = System.Type.GetType("System.String")
        aDataTable.Columns.Add(colValue)

        'Dim colLabel As DataColumn = New DataColumn("FieldLabel")
        'colLabel.DataType = System.Type.GetType("System.String")
        'aDataTable.Columns.Add(colLabel)

    End Sub

    Private Sub AddUserDataDTRow(ByVal ADataTable As DataTable, ByVal strControlID As String, ByVal strValue As String, Optional ByVal YesNoControl As Boolean = False)
        Try
            Dim MyRow As DataRow
            MyRow = ADataTable.NewRow
            If YesNoControl = True Then
                With MyRow
                    .Item("ControlID") = strControlID
                    Select Case strValue
                        Case "Yes"
                            .Item("FormValue") = "1"
                        Case "No"
                            .Item("FormValue") = "0"
                        Case Else
                            Try
                                If cGlobals.wvIsDate(strValue) = True AndAlso strControlID.IndexOf("_DATE") > -1 Then
                                    strValue = cGlobals.wvCDate(strValue).ToShortDateString()
                                End If
                            Catch ex As Exception
                            End Try
                            .Item("FormValue") = strValue
                    End Select
                End With
            Else
                With MyRow
                    .Item("ControlID") = strControlID
                    Try
                        If cGlobals.wvIsDate(strValue) = True AndAlso strControlID.IndexOf("_DATE") > -1 Then
                            strValue = cGlobals.wvCDate(strValue).ToShortDateString()
                        End If
                    Catch ex As Exception
                    End Try
                    .Item("FormValue") = strValue
                End With
            End If

            ADataTable.Rows.Add(MyRow)
        Catch ex As Exception
            Err.Raise(Err.Number, "Error in fn: AddDTRow!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Sub

    Private Overloads Sub RecursUserDataAllControls(ByVal parent As System.Web.UI.Control, ByVal aDataTable As DataTable)
        Try
            For Each ctrl As System.Web.UI.Control In parent.Controls
                Select Case ctrl.GetType.ToString
                    Case "System.Web.UI.WebControls.TextBox"
                        If InStr(ctrl.ClientID, "Value") > 0 Then
                            AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString(), CType(ctrl, TextBox).Text)
                        ElseIf InStr(ctrl.ClientID, "Descript") > 0 AndAlso InStr(ctrl.ClientID, "BLACKPLT_VER_DESC") > 0 Then
                            AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString(), CType(ctrl, TextBox).Text)
                        ElseIf InStr(ctrl.ClientID, "Descript") > 0 AndAlso InStr(ctrl.ClientID, "BLACKPLT_VER2_DESC") > 0 Then
                            AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString(), CType(ctrl, TextBox).Text)
                        End If
                    Case "System.Web.UI.WebControls.RadioButtonList"
                        If InStr(ctrl.ClientID, "Value") > 0 Then
                            AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString(), CType(ctrl, RadioButtonList).SelectedValue, True)
                        End If
                    Case "Telerik.Web.UI.RadComboBox"
                        If InStr(ctrl.ClientID, "Value") > 0 Then
                            If CType(ctrl, Telerik.Web.UI.RadComboBox).SelectedIndex > -1 Then
                                AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString(), CType(ctrl, Telerik.Web.UI.RadComboBox).SelectedValue)
                            Else
                                AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString(), "")
                            End If
                        End If
                    Case "System.Web.UI.WebControls.ImageButton"
                        Try
                            CType(ctrl, ImageButton).ImageAlign = ImageAlign.AbsMiddle
                        Catch ex As Exception
                        End Try
                    Case "System.Web.UI.WebControls.HyperLink"
                    Case "System.Web.UI.WebControls.RadioButton"
                    Case "Telerik.Web.UI.RadDatePicker"
                        If InStr(ctrl.ClientID, "Value") > 0 Then
                            Try
                                Dim val As String = ""
                                Dim rdp As New Telerik.Web.UI.RadDatePicker
                                rdp = CType(ctrl, Telerik.Web.UI.RadDatePicker)
                                If MiscFN.ValidDate(rdp) = True Then
                                    val = rdp.SelectedDate
                                Else
                                    val = ""
                                End If
                                AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString(), val)
                            Catch ex As Exception
                            End Try
                        End If
                    Case "Telerik.Web.UI.RadEditor"
                        Try

                            Dim val As String = ""
                            Dim rdp As New Telerik.Web.UI.RadEditor

                            rdp = CType(ctrl, Telerik.Web.UI.RadEditor)

                            Try

                                val = rdp.Text

                            Catch ex As Exception
                                val = ""
                            End Try

                            'Add the text value as datarow
                            AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString(), val)

                            'Add the html as a datarow
                            Try

                                val = rdp.Content

                            Catch ex As Exception
                                val = ""
                            End Try

                            If ctrl.ClientID.Contains("JOB_COMPONENTCREATIVE_INSTR") Then

                                AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString().Replace("JOB_COMPONENTCREATIVE_INSTR", "JOB_COMPONENTCREATIVE_INSTR_HTML"), val)

                            ElseIf ctrl.ClientID.Contains("JOB_COMPONENTJOB_COMP_COMMENTS") Then

                                AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString().Replace("JOB_COMPONENTJOB_COMP_COMMENTS", "JOB_COMPONENTJC_COMMENTS_HTML"), val)

                            ElseIf ctrl.ClientID.Contains("JOB_COMPONENTJOB_DEL_INSTRUCT") Then

                                AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString().Replace("JOB_COMPONENTJOB_DEL_INSTRUCT", "JOB_COMPONENTJOB_DEL_INSTR_HTML"), val)

                                'ElseIf ctrl.ClientID.Contains("JOB_COMPONENTJOB_LAYOUT_SPC_EXP") Then

                                '    AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString().Replace("JOB_COMPONENTJOB_LAYOUT_SPC_EXP", "JOB_COMPONENTJOB_LAYOUT_SPC_EXP_HTML"), val)

                                'ElseIf ctrl.ClientID.Contains("JOB_LOGJOB_BILL_COMMENT") Then

                                '    AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString().Replace("JOB_LOGJOB_BILL_COMMENT", "JOB_LOGJOB_BILL_COMMENT_HTML"), val)

                            ElseIf ctrl.ClientID.Contains("JOB_LOGJOB_COMMENTS") Then

                                AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString().Replace("JOB_LOGJOB_COMMENTS", "JOB_LOGJOB_COMMENTS_HTML"), val)

                            End If

                        Catch ex As Exception
                        End Try

                End Select
                If ctrl.Controls.Count > 0 Then

                    RecursUserDataAllControls(ctrl, aDataTable)

                End If

            Next
        Catch ex As Exception
            Err.Raise(Err.Number, "Error looping through controls!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Sub

    'DT for lookups
    Public Function CreateLookupDataTable(ByVal JobNum As Integer, ByVal JobCompNum As Integer) As DataTable
        Dim arParams(1) As SqlParameter
        Try
            Dim parameterJobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            parameterJobNum.Value = JobNum
            arParams(0) = parameterJobNum
            Dim parameterJobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            parameterJobCompNum.Value = JobNum
            arParams(1) = parameterJobCompNum
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_GetAllLookupsByJobNum", "DBLookUpData", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:Job_Template Routine:CreateLookupDataTable", Err.Description)
        End Try
    End Function

    'Get one value back from form or datatable:
    Public Overloads Function GetOneFormValue(ByVal ThePage As System.Web.UI.Page, ByVal TheDataTable As DataTable, ByVal TheItemCode As String) As String
        Try
            Dim dt As DataTable = TheDataTable
            dt = CreateUserDataDataTable(ThePage)
            Dim dv As DataView = New DataView(dt)
            dv.RowFilter = "ItemCode = '" & TheItemCode & "'"
            dt = dv.ToTable
            Dim str As String = dt.Rows(0)("FormValue").ToString()
            Return str
        Catch ex As Exception
            Return "Error: " & ex.Message.ToString
        End Try
    End Function

    Public Overloads Function GetOneFormValue(ByVal TheDataTable As DataTable, ByVal TheItemCode As String) As String
        Try
            Dim dv As DataView = New DataView(TheDataTable)
            dv.RowFilter = "ItemCode = '" & TheItemCode & "'"
            Dim dt As DataTable = dv.ToTable
            Dim str As String = dt.Rows(0)("FormValue").ToString()
            Return str
        Catch ex As Exception
            Return "Error: " & ex.Message.ToString
        End Try
    End Function

#End Region

#Region " Page and Form "

    Dim dtFormData As DataTable = New DataTable("FormData")
    Dim tabIndex As Integer = 0
    Dim sectionindex As Integer = 1
    Dim panelidentity As String
    Private _CDPOverride As Short = 0
    Private _CheckAR As Boolean = False
    Private _CheckAP As Boolean = False
    Private _CheckARJob As Boolean = False
    Private _Deep As AdvantageFramework.Web.DeepLink

    Public Function BuildJobTemplateForm(ByRef SecuritySession As AdvantageFramework.Security.Session,
                                         ByVal IsEditMode As Boolean,
                                         ByRef ThePlaceHolder As PlaceHolder,
                                         ByVal intJobNum As Integer,
                                         ByVal intJobCompNum As Integer,
                                         ByVal ThisEmpCode As String,
                                         ByVal IsNewComp As Boolean,
                                         Optional ByVal clientcode As String = "",
                                         Optional ByVal userid As String = "",
                                         Optional ByRef SpellCheckObjects As String = "",
                                         Optional ByRef OfficeCode As String = "",
                                         Optional ByRef ClCode As String = "",
                                         Optional ByRef DivCode As String = "",
                                         Optional ByRef PrdCode As String = "",
                                         Optional ByRef AeCode As String = "",
                                         Optional ByRef ScCode As String = "",
                                         Optional ByRef JobTmpltCode As String = "",
                                         Optional ByVal IsClientPortal As Boolean = False,
                                         Optional ByVal IsContentPanel As Boolean = False) As DataTable

        Try

            Dim textboxID As String = ""
            mThisEmpCode = ThisEmpCode
            mIsNewComp = IsNewComp
            Dim IsEdit As Boolean = True 'job/object level
            Dim ds As DataSet = New DataSet
            Dim hyperlinktext As String = ""
            Dim SaveTemplate As Boolean = False
            jobnum = intJobNum
            jobcompnum = intJobCompNum

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.mConnString, Me.mUserCode)

                agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If agency IsNot Nothing AndAlso agency.CDPOverride IsNot Nothing Then

                    Me._CDPOverride = agency.CDPOverride

                End If

            End Using

            ds = GetJobTemplateDetails(intJobNum, intJobCompNum)

            Try
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim dv As DataView = New DataView(ds.Tables(0))
                    dv.RowFilter = "ITEM_CODE='JOB_LOG.CL_CODE' OR ITEM_CODE='JOB_LOG.DIV_CODE' OR ITEM_CODE='JOB_LOG.PRD_CODE' OR ITEM_CODE='JOB_LOG.SC_CODE'"

                    Dim dt As DataTable = New DataTable()
                    dt = dv.ToTable()

                    For i As Integer = 0 To dt.Rows.Count - 1
                        If dt.Rows(i)("ITEM_CODE") = "JOB_LOG.CL_CODE" Then
                            sectionCli = dt.Rows(i)("SECTION").ToString
                        End If
                        If dt.Rows(i)("ITEM_CODE") = "JOB_LOG.DIV_CODE" Then
                            sectionDiv = dt.Rows(i)("SECTION").ToString
                        End If
                        If dt.Rows(i)("ITEM_CODE") = "JOB_LOG.PRD_CODE" Then
                            sectionPrd = dt.Rows(i)("SECTION").ToString
                        End If
                        If dt.Rows(i)("ITEM_CODE") = "JOB_LOG.SC_CODE" Then
                            sectionSC = dt.Rows(i)("SECTION").ToString
                        End If
                    Next
                End If
            Catch ex As Exception
            End Try

            If Not ds.Tables(1) Is Nothing Then
                Me.DtJobComments = ds.Tables(1)
            End If

            If Not ds.Tables(2) Is Nothing Then
                If ds.Tables(2).Rows.Count > 0 Then
                    If Not IsDBNull(ds.Tables(2).Rows(0)("OFFICE_CODE")) Then
                        OfficeCode = ds.Tables(2).Rows(0)("OFFICE_CODE").ToString()
                    End If
                    If Not IsDBNull(ds.Tables(2).Rows(0)("CL_CODE")) Then
                        Me.mCL_CODE = ds.Tables(2).Rows(0)("CL_CODE").ToString()
                        ClCode = ds.Tables(2).Rows(0)("CL_CODE").ToString()
                    End If
                    If Not IsDBNull(ds.Tables(2).Rows(0)("DIV_CODE")) Then
                        Me.mDIV_CODE = ds.Tables(2).Rows(0)("DIV_CODE").ToString()
                        DivCode = ds.Tables(2).Rows(0)("DIV_CODE").ToString()
                    End If
                    If Not IsDBNull(ds.Tables(2).Rows(0)("PRD_CODE")) Then
                        Me.mPRD_CODE = ds.Tables(2).Rows(0)("PRD_CODE").ToString()
                        PrdCode = ds.Tables(2).Rows(0)("PRD_CODE").ToString()
                    End If
                    If Not IsDBNull(ds.Tables(2).Rows(0)("AE_CODE")) Then
                        AeCode = ds.Tables(2).Rows(0)("AE_CODE").ToString()
                    End If
                    If Not IsDBNull(ds.Tables(2).Rows(0)("SC_CODE")) Then
                        mSC_CODE = ds.Tables(2).Rows(0)("SC_CODE").ToString()
                        ScCode = ds.Tables(2).Rows(0)("SC_CODE").ToString()
                    End If
                    If Not IsDBNull(ds.Tables(2).Rows(0)("JOB_TMPLT_CODE")) Then
                        JobTmpltCode = ds.Tables(2).Rows(0)("JOB_TMPLT_CODE").ToString()
                    Else
                        Try
                            Dim MyDrop As cDropDowns = New cDropDowns(mConnString)
                            Dim dr As SqlDataReader = MyDrop.GetJobTemplatesList
                            Dim dr2 As SqlDataReader = MyDrop.GetJobTemplatesListAll
                            If dr.HasRows Then
                                Do While dr.Read
                                    If IsDBNull(dr("Code")) = False Then
                                        If dr("Code") = "DFLT" Then
                                            JobTmpltCode = "DFLT"
                                            Exit Do
                                        Else
                                            JobTmpltCode = dr("Code")
                                        End If
                                    Else
                                        JobTmpltCode = "DFLT"
                                    End If
                                Loop
                                dr.Close()
                            Else
                                If dr2.HasRows Then
                                    Do While dr2.Read
                                        If dr2("Code") = "DFLT" Then
                                            JobTmpltCode = "DFLT"
                                            Exit Do
                                        Else
                                            JobTmpltCode = dr2("Code")
                                        End If
                                    Loop
                                Else
                                    JobTmpltCode = "DFLT"
                                End If
                                dr2.Close()
                            End If
                            Try
                                SaveTemplate = Me.ChangeTemplate(intJobNum, intJobCompNum, "", JobTmpltCode)
                            Catch ex As Exception
                            End Try
                        Catch ex As Exception

                        End Try
                    End If
                End If
            End If

            'Add default section if no section are present.
            If SaveTemplate = True Then
                ds = GetJobTemplateDetails(intJobNum, intJobCompNum)
            End If
            ds = CheckForSections(ds)
            Dim dvSections As DataView = New DataView(ds.Tables(0))
            dvSections.RowFilter = "ITEM_CODE='SECTION'"

            Dim dtSections As DataTable = New DataTable()
            dtSections = dvSections.ToTable()

            client = Me.mCL_CODE

            'create private dt columns
            AddDTColumns(mDtFormData)

            SpellCheckObjects = ""
            Me.GetJobRush(jobnum)

            _CheckAR = Me.CheckAR(intJobNum, intJobCompNum)
            _CheckAP = Me.CheckAP(intJobNum, OfficeCode)
            _CheckARJob = Me.CheckARJob(intJobNum)

            For i As Integer = 0 To dtSections.Rows.Count - 1

                Dim MyPanel As New eWorld.UI.CollapsablePanel 'instatiate new panel

                panelidentity = i
                SetSectionPanel(MyPanel, dtSections.Rows(i)("SHORT_DESC"), i, IsEditMode, , IsContentPanel)

                ThePlaceHolder.Controls.Add(MyPanel)
                'MyPanel.Controls.Add(MiscFN.NewLiteral("<br />"))

                'For: loop through one section's items (all useable controls)
                Dim dvSectionItems As DataView = New DataView(ds.Tables(0))
                dvSectionItems.RowFilter = "SECTION_ORDER = " & dtSections.Rows(i)("SECTION_ORDER") & " AND ITEM_TYPE <> 'S'"
                Dim dtSectionItems As DataTable = New DataTable
                dtSectionItems = dvSectionItems.ToTable
                Dim strNameForID As String = String.Empty
                Dim str As String = dtSectionItems.Rows.Count.ToString
                For j As Integer = 0 To dtSectionItems.Rows.Count - 1
                    Dim strIDForDT As String = ""
                    Select Case dtSectionItems.Rows(j)("ITEM_CODE").ToString()
                        Case "JOB_SPECIFICATIONS"
                            Try
                                Dim strURL As String
                                Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder

                                strURL = "jobspecs.aspx?JobNum=" & jobnum & "&JobCompNum=" & jobcompnum
                                strBuilder.Append("window.open('" & strURL & "', '', 'screenX=150,left=150,screenY=150,top=150,width=925,height=600,scrollbars=yes,resizable=yes,menubar=no,maximazable=yes')")
                                hyperlinktext = strBuilder.ToString

                            Catch ex As Exception
                                Err.Raise(Err.Number, "Error! " & ex.Message.ToString())
                            End Try
                        Case "TRAFFIC_SCHEDULE"
                            Try
                                Dim oTrafficSchedule As cSchedule = New cSchedule(Me.mConnString, userid)
                                Dim x As Integer = oTrafficSchedule.CheckExistsClosed(jobnum, jobcompnum)
                                Select Case x
                                    Case 0, -2
                                        hyperlinktext = "window.location='" & Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Index/" & jobnum.ToString & "/" & jobcompnum.ToString & "?JT=1'"
                                    Case -1
                                        hyperlinktext = "window.location='" & Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Create?JobNumber=" & jobnum.ToString & "&JobComponentNumber=" & jobcompnum.ToString & "&JT=1'"
                                End Select
                            Catch ex As Exception

                            End Try
                    End Select
                    'might need to wrap this replace into a "clean function" to make sure any chars that
                    'would interfere with js/html are cleaned out
                    strNameForID = Replace(dtSectionItems.Rows(j)("SHORT_DESC"), " ", "_")
                    'strNameForID = Replace(strNameForID, "/", "_")
                    strNameForID = Replace(strNameForID, "_-_", "_")
                    'Add to internal dt

                    If _Deep Is Nothing Then _Deep = New AdvantageFramework.Web.DeepLink(SecuritySession)

                    If IsNewComp = False Then

                        strIDForDT = AddFormRowControls(IsEditMode,
                                                        MyPanel,
                                                        dtSectionItems.Rows(j)("CONTROL_TYPE"),
                                                        dtSectionItems.Rows(j)("ITEM_CODE"),
                                                        strNameForID,
                                                        strNameForID,
                                                        dtSectionItems.Rows(j)("ADVAN_REQ"),
                                                        dtSectionItems.Rows(j)("AGENCY_REQ"),
                                                        dtSectionItems.Rows(j)("CLIENT_REQ"),
                                                        dtSectionItems.Rows(j)("TMPLT_REQ"),
                                                        IIf(IsDBNull(DecodeSQL(dtSectionItems.Rows(j)("FIELD_VALUE"))),
                                                        "",
                                                        DecodeSQL(dtSectionItems.Rows(j)("FIELD_VALUE"))),
                                                        True,
                                                        "desc_" & MyPanel.ID & "_" & strNameForID,
                                                        IIf(IsDBNull(dtSectionItems.Rows(j)("FIELD_DESCRIPT")),
                                                        "",
                                                        dtSectionItems.Rows(j)("FIELD_DESCRIPT")),
                                                        hyperlinktext,
                                                        dtSectionItems.Rows(j)("EDITABLE"),
                                                        userid,
                                                        IsClientPortal)

                    Else

                        strIDForDT = AddFormRowControls(IsEditMode,
                                                        MyPanel,
                                                        dtSectionItems.Rows(j)("CONTROL_TYPE"),
                                                        dtSectionItems.Rows(j)("ITEM_CODE"),
                                                        strNameForID,
                                                        strNameForID,
                                                        dtSectionItems.Rows(j)("ADVAN_REQ"),
                                                        dtSectionItems.Rows(j)("AGENCY_REQ"),
                                                        dtSectionItems.Rows(j)("CLIENT_REQ"),
                                                        dtSectionItems.Rows(j)("TMPLT_REQ"),
                                                        "",
                                                        True,
                                                        "desc_" & MyPanel.ID & "_" & strNameForID,
                                                        IIf(IsDBNull(DecodeSQL(dtSectionItems.Rows(j)("FIELD_DESCRIPT"))),
                                                        "",
                                                        dtSectionItems.Rows(j)("FIELD_DESCRIPT")),
                                                        hyperlinktext,
                                                        dtSectionItems.Rows(j)("EDITABLE"),
                                                        userid,
                                                        IsClientPortal)

                    End If

                    'add to datatable in memory
                    Dim FieldValue As String = ""
                    Try
                        If IsDBNull(dtSectionItems.Rows(j)("FIELD_VALUE")) = False Then
                            FieldValue = DecodeSQL(dtSectionItems.Rows(j)("FIELD_VALUE"))
                        End If
                    Catch ex As Exception
                        FieldValue = ""
                    End Try

                    ' this value has a date appended to it, the date is made into a string on the database side
                    ' which should never ever be done, so we have to parse the date out here so we can format it
                    ' to the users local date formate
                    If (dtSectionItems.Rows(j)("ITEM_CODE") = "JOB_LOG.USER_ID") Then
                        Dim values As String()
                        Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-US")

                        values = FieldValue.Split("-")

                        If values.Length = 2 Then
                            Dim parsedDate As Date = Date.ParseExact(values(1).Trim, "MM/dd/yyyy", ci)
                            FieldValue = values(0).Trim & " - " & parsedDate.ToString(LoGlo.GetDateFormat())
                        End If
                    End If


                    'clean dates
                    Try
                        If FieldValue <> "" AndAlso cGlobals.wvIsDate(FieldValue) = True AndAlso dtSectionItems.Rows(j)("ITEM_CODE").ToString().IndexOf("_DATE") > -1 Then
                            FieldValue = cGlobals.wvCDate(FieldValue).ToShortDateString()
                        End If
                    Catch ex As Exception
                    End Try
                    'why does sc code come out with code and desc together??? put back to just the code
                    If dtSectionItems.Rows(j)("ITEM_CODE").ToString().IndexOf("JOB_LOG.SC_CODE") > -1 AndAlso FieldValue.IndexOf("&nbsp;-&nbsp;") > -1 Then
                        Dim ar() As String
                        ar = FieldValue.Split("&nbsp;-&nbsp;")
                        FieldValue = ar(0)
                    End If

                    'first 2 paths just for blackplate
                    If strIDForDT.IndexOf("Value") > -1 AndAlso strIDForDT.IndexOf("BLACKPLT") > -1 AndAlso strIDForDT.IndexOf("/") = -1 Then
                        AddDTRow(mDtFormData, strIDForDT, FieldValue, dtSectionItems.Rows(j)("ITEM_CODE"))
                    ElseIf strIDForDT.IndexOf("Value") > -1 AndAlso strIDForDT.IndexOf("BLACKPLT") > -1 AndAlso strIDForDT.IndexOf("/") > -1 Then
                        Dim strValueDescript() As String
                        strValueDescript = strIDForDT.Split("/")
                        Dim valuestr As String = strValueDescript(0)
                        Dim descriptstr As String = "ctl00_ContentPlaceHolderMain_" & strValueDescript(1)
                        AddDTRow(mDtFormData, valuestr, FieldValue, dtSectionItems.Rows(j)("ITEM_CODE"))
                        AddDTRow(mDtFormData, descriptstr, IIf(IsDBNull(DecodeSQL(dtSectionItems.Rows(j)("FIELD_DESCRIPT"))), "", DecodeSQL(dtSectionItems.Rows(j)("FIELD_DESCRIPT"))), dtSectionItems.Rows(j)("ITEM_CODE"))
                    ElseIf strIDForDT.IndexOf("CL_CODE") > -1 OrElse strIDForDT.IndexOf("DIV_CODE") > -1 OrElse strIDForDT.IndexOf("PRD_CODE") > -1 Then
                        Dim strCDP() As String = FieldValue.Split("&nbsp;")
                        Dim cdp As String = strCDP(0)
                        AddDTRow(mDtFormData, strIDForDT, cdp, dtSectionItems.Rows(j)("ITEM_CODE"))
                    Else
                        'everthing besides blackplate:
                        AddDTRow(mDtFormData, strIDForDT, FieldValue, dtSectionItems.Rows(j)("ITEM_CODE"))
                        If strIDForDT.IndexOf("JOB_COMMENTS") > -1 Then
                            AddDTRow(mDtFormData, strIDForDT & "_HTML", Job_Specs.DecodeSQL(Me.DtJobComments.Rows(0)("JOB_COMMENTS_HTML").ToString), dtSectionItems.Rows(j)("ITEM_CODE") & "_HTML")
                        End If
                        If strIDForDT.IndexOf("JOB_COMP_COMMENTS") > -1 Then
                            AddDTRow(mDtFormData, strIDForDT.Replace("JOB_COMP_COMMENTS", "JC_COMMENTS_HTML"), Job_Specs.DecodeSQL(Me.DtJobComments.Rows(0)("JC_COMMENTS_HTML").ToString), "JOB_COMPONENT.JC_COMMENTS_HTML")
                        End If
                        If strIDForDT.IndexOf("CREATIVE_INSTR") > -1 Then
                            AddDTRow(mDtFormData, strIDForDT & "_HTML", Job_Specs.DecodeSQL(Me.DtJobComments.Rows(0)("CREATIVE_INSTR_HTML").ToString), dtSectionItems.Rows(j)("ITEM_CODE") & "_HTML")
                        End If
                        If strIDForDT.IndexOf("JOB_DEL_INSTRUCT") > -1 Then
                            AddDTRow(mDtFormData, strIDForDT.Replace("JOB_DEL_INSTRUCT", "JOB_DEL_INSTR_HTML"), Job_Specs.DecodeSQL(Me.DtJobComments.Rows(0)("JOB_DEL_INSTR_HTML").ToString), "JOB_COMPONENT.JOB_DEL_INSTR_HTML")
                        End If
                    End If

                    'Create valid list of controls for spell checker
                    Dim ThisItemCode As String
                    ThisItemCode = dtSectionItems.Rows(j)("ITEM_CODE")
                    Select Case dtSectionItems.Rows(j)("CONTROL_TYPE")
                        Case RowTypes.MultiLine
                            textboxID = ""
                            If InStr(strIDForDT, "Blackplate") > 0 Then
                                Dim strValueDescript() As String
                                strValueDescript = strIDForDT.Split("/")
                                textboxID = "ctl00_ContentPlaceHolderMain_" & strValueDescript(0)
                            End If

                            textboxID &= strIDForDT 'MyPanel.ID.ToString()& "_" & "TxtValue_" & strNameForID & "_" & ThisItemCode.Replace(".", "")
                            SpellCheckObjects &= "New HtmlElementTextSource(document.getElementById('" & textboxID & "'))" & Environment.NewLine & ","
                    End Select

                Next
            Next

            If SpellCheckObjects.Length > 0 Then
                SpellCheckObjects = SpellCheckObjects.Substring(0, SpellCheckObjects.Length - 1)
            End If

            Return mDtFormData
        Catch ex As Exception
            Err.Raise(Err.Number, "Error! " & ex.Message.ToString())
        Finally
        End Try
    End Function

    Private Sub RecurseAllControls(ByVal parent As System.Web.UI.Control, ByVal aDataTable As DataTable)
        Dim str As String = String.Empty
        Try
            For Each ctrl As System.Web.UI.Control In parent.Controls
                Select Case ctrl.GetType.ToString
                    Case "System.Web.UI.WebControls.TextBox"
                        If InStr(ctrl.ClientID, "Value") > 0 Then
                            str = CType(ctrl, TextBox).Text
                            'If str <> "" OrElse str <> String.Empty Then
                            AddDTRow(aDataTable, ctrl.ClientID.ToString(), str)
                            'End If
                        End If
                    Case "System.Web.UI.WebControls.RadioButtonList"
                        str = CType(ctrl, RadioButtonList).SelectedValue
                        If str = "Yes" Then
                            AddDTRow(aDataTable, ctrl.ClientID.ToString(), "1")
                        ElseIf str = "No" Then
                            AddDTRow(aDataTable, ctrl.ClientID.ToString(), "0")
                        Else 'If str <> "" OrElse str <> String.Empty Then
                            AddDTRow(aDataTable, ctrl.ClientID.ToString(), str)
                        End If
                    Case "Telerik.Web.UI.RadComboBox"
                        AddDTRow(aDataTable, ctrl.ClientID.ToString(), CType(ctrl, Telerik.Web.UI.RadComboBox).SelectedValue)
                    Case "System.Web.UI.WebControls.HyperLink"
                    Case "System.Web.UI.WebControls.RadioButton"
                    Case "System.Web.UI.WebControls.ImageButton"
                        Try
                            CType(ctrl, ImageButton).ImageAlign = ImageAlign.AbsMiddle
                        Catch ex As Exception
                        End Try
                End Select
                If ctrl.Controls.Count > 0 Then
                    RecurseAllControls(ctrl, aDataTable)
                End If
                str = String.Empty
            Next
        Catch ex As Exception
            Err.Raise(Err.Number, "Error looping through controls!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Sub

    Private Function SetSectionPanel(ByRef ThePanel As eWorld.UI.CollapsablePanel, ByVal PanelName As String, ByVal PanelID As Integer,
                                     ByVal PanelExpand As Boolean, Optional ByVal PanelToolTip As String = "", Optional ByVal IsContentPanel As Boolean = False) As eWorld.UI.CollapsablePanel
        Try
            With ThePanel
                If PanelName <> "" Then
                    .ID = "colpnl" & Replace(PanelName, " ", "").Replace("&", "").Replace("/", "").Replace("#", "").Replace("'", "") & PanelID.ToString() 'replace with JOB_TMPLT_DTL.LABEL from Section query
                Else
                    .ID = "colpnl" & Replace(PanelName, " ", "") & PanelID.ToString() 'replace with JOB_TMPLT_DTL.LABEL from Section query
                End If
                .TitleText = PanelName.ToString
            End With
            Return ThePanel
        Catch ex As Exception
            Err.Raise(Err.Number, "Error: SetSectionPanel!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Private Function SetHyperLink(ByRef TheHyperLink As System.Web.UI.WebControls.HyperLink, ByVal PanelName As String, ByVal HyperLinkID As String,
                                    ByVal HyperLinkText As String, ByVal HasPopUp As Boolean, ByVal IsEdit As Boolean,
                                    Optional ByVal ThisValueControlID As String = "", Optional ByVal ThisDescriptControlID As String = "",
                                    Optional ByVal ItemCode As String = "", Optional ByVal editable As Boolean = False, Optional ByVal userid As String = "") As System.Web.UI.WebControls.HyperLink
        Try
            Dim oAgency As New cAgency(Me.mConnString)
            Dim agency As AdvantageFramework.Database.Entities.Agency = Nothing
            HyperLinkText = Replace(HyperLinkText, "_SLASH_", "/")
            HyperLinkText = Replace(HyperLinkText, "_", " ")
            HyperLinkText = Replace(HyperLinkText, "--", "/")
            HyperLinkID = Replace(HyperLinkID, "--", "_")
            HyperLinkID = Replace(HyperLinkID, """", "")
            ThisValueControlID = Replace(ThisValueControlID, "--", "_")
            ThisValueControlID = Replace(ThisValueControlID, "/", "_SLASH_")
            ThisValueControlID = Replace(ThisValueControlID, """", "")
            'ThisValueControlID = Replace(ThisValueControlID, "?", "")
            With TheHyperLink
                .ID = PanelName & "_hl" & Replace(HyperLinkID, "_", "") & "_" & ItemCode
                '.Text = HyperLinkText & ":&nbsp;"
                Try
                    If HyperLinkText.IndexOf("?") = HyperLinkText.Length - 1 Then
                        .Text = HyperLinkText
                    Else
                        .Text = HyperLinkText & ":"
                    End If
                Catch ex As Exception
                    .Text = HyperLinkText & ":&nbsp;"
                End Try
                .NavigateUrl = "Javascript:void(0);"
                .ToolTip = HyperLinkText.Replace("&nbsp;", " ")
                .TabIndex = -1
            End With

            'If (ItemCode = "JOB_LOG.OFFICE_CODE" AndAlso oAgency.JobTemplateEditOfficeCheck = False) OrElse editable = True OrElse (ItemCode = "JOB_COMPONENT.JOB_PROCESS_CONTRL" AndAlso Me.GetJPCSecurity(userid, SecuritySession) = "N") Then
            If (ItemCode = "JOB_LOG.OFFICE_CODE" AndAlso oAgency.JobTemplateEditOfficeCheck = False) OrElse editable = True OrElse (ItemCode = "JOB_COMPONENT.JOB_PROCESS_CONTRL" AndAlso Me.HasAccessToFinanceAccounting_JobProcessCtrl = False) Or
                ((ItemCode = "JOB_LOG.CL_CODE" OrElse ItemCode = "JOB_LOG.DIV_CODE" OrElse ItemCode = "JOB_LOG.PRD_CODE") AndAlso _CDPOverride = 0) OrElse ItemCode = "JOB_LOG.JOB_NUMBER" Then
                HasPopUp = False
            Else
                HasPopUp = True
            End If

            If _CheckARJob = True AndAlso ThisValueControlID.Contains("SC_CODE") = True Then

                HasPopUp = False
                IsEdit = False

            End If

            'If to check whether we need to set a hyperlink popup
            'maybe just add one field to table and do isnull check instead of bool?
            Try
                'HasPopUp = True
                If HasPopUp = True AndAlso IsEdit = True Then
                    TheHyperLink.Attributes.Add("onclick", SetLookupJS(ThisValueControlID, ItemCode))
                    'TheHyperLink.CssClass = "JobTemplateLink"
                Else
                    TheHyperLink.CssClass = "JobTemplateLabel"
                End If
            Catch ex As Exception
                Err.Raise(Err.Number, "Error setting hyperlink/label lookup!<br />" & ex.Message.ToString())
            End Try
            Try
                If String.IsNullOrWhiteSpace(TheHyperLink.Attributes.Item("onclick")) = False Then

                    If TheHyperLink.Attributes.Item("onclick").IndexOf("aspx") = -1 Then
                        TheHyperLink.CssClass = "JobTemplateLabel"
                    Else
                        'TheHyperLink.CssClass = "JobTemplateLink"
                    End If
                    If ItemCode = "JOB_LOG.JOB_NUMBER" OrElse ItemCode = "JOB_COMPONENT.JOB_COMPONENT_NBR" Then
                        'TheHyperLink.CssClass = "JobTemplateLink"
                    End If

                End If

            Catch ex As Exception
            End Try
            Return TheHyperLink
        Catch ex As Exception
            Err.Raise(Err.Number, "Error setting hyperlink/label properties!<br />" & ex.Message.ToString())
        End Try

    End Function

    Private Function SetImageButton(ByRef TheImgBtn As System.Web.UI.WebControls.ImageButton, ByVal PanelName As String, ByVal ImgBtnID As String,
                                    ByVal ImgBtnText As String, ByVal HasPopUp As Boolean, ByVal IsEdit As Boolean,
                                    Optional ByVal ThisValueControlID As String = "", Optional ByVal ThisDescriptControlID As String = "",
                                    Optional ByVal ItemCode As String = "", Optional ByVal imagepath As String = "") As System.Web.UI.WebControls.ImageButton

        Try

            Dim oAgency As New cAgency(Me.mConnString)
            ThisValueControlID = Replace(ThisValueControlID, "--", "_")

            With TheImgBtn

                .ID = PanelName & "_ImgBtn" & Replace(ImgBtnID, "_", "")
                .ID = .ID.Replace("/", "_")

                If ItemCode = "JOB_SPECIFICATIONS" Then

                    .ImageUrl = "~/Images/Icons/White/256/arrow_right.png"
                    .CssClass = "icon-image"
                    .ToolTip = "Go to job specification"
                    .CommandName = "GoToJS"

                ElseIf ItemCode = "TRAFFIC_SCHEDULE" Then

                    .ImageUrl = "~/Images/Icons/White/256/arrow_right.png"
                    .CssClass = "icon-image"
                    .ToolTip = "Go to schedule"
                    .CommandName = "GoToTS"

                ElseIf ItemCode = "JOB_VERSIONS" Then

                    .ImageUrl = "~/Images/Icons/White/256/arrow_right.png"
                    .CssClass = "icon-image"
                    .CommandName = "GoToJV"
                    .ToolTip = "Go to versions"

                ElseIf ItemCode = "ESTIMATING" Then

                    .ImageUrl = "~/Images/Icons/White/256/arrow_right.png"
                    .CssClass = "icon-image"
                    .CommandName = "GoToEST"
                    .ToolTip = "Go to estimate"

                ElseIf ItemCode = "JOB_COMPONENT.PRD_CONT_CODE" Then

                    .SkinID = "ImageButtonClientContact"
                    .CommandName = "GoToContacts"
                    .ToolTip = "Client Contacts"

                ElseIf ItemCode = "JOB_LOG.JOB_COMMENTS" Then

                    .SkinID = "ImageButtonView"
                    .CommandName = "GoToComments"
                    .CommandArgument = "JOBCOMMENTS"
                    .ToolTip = "Show Comment"
                    .ImageAlign = ImageAlign.Top

                ElseIf ItemCode = "JOB_COMPONENT.JOB_COMP_COMMENTS" Then

                    .SkinID = "ImageButtonView"
                    .CommandName = "GoToComments"
                    .CommandArgument = "JOBCOMPCOMMENTS"
                    .ToolTip = "Show Comment"
                    .ImageAlign = ImageAlign.Top

                ElseIf ItemCode = "JOB_COMPONENT.CREATIVE_INSTR" Then

                    .SkinID = "ImageButtonView"
                    .CommandName = "GoToComments"
                    .CommandArgument = "CREATIVEINSTR"
                    .ToolTip = "Show Comment"
                    .ImageAlign = ImageAlign.Top

                ElseIf ItemCode = "JOB_COMPONENT.JOB_DEL_INSTRUCT" Then

                    .SkinID = "ImageButtonView"
                    .CommandName = "GoToComments"
                    .CommandArgument = "JOBDELINSTRUCT"
                    .ToolTip = "Show Comment"
                    .ImageAlign = ImageAlign.Top

                ElseIf ItemCode = "JOB_LOG.CL_CODE" Then

                    .SkinID = "ImageButtonClientAddress"
                    .CommandName = "GoToClients"
                    .ToolTip = "Client Address Information"

                End If

            End With

            If ItemCode = "JOB_LOG.OFFICE_CODE" AndAlso oAgency.JobTemplateEditOfficeCheck = False Then

                HasPopUp = False

            Else

                HasPopUp = True

            End If

            'If to check whether we need to set a hyperlink popup
            'maybe just add one field to table and do isnull check instead of bool?
            Try
                If ItemCode = "JOB_COMPONENT.PRD_CONT_CODE" OrElse ItemCode = "JOB_LOG.CL_CODE" Then

                    TheImgBtn.Attributes.Add("onclick", SetImgBtnContactJS(ThisValueControlID, ItemCode))

                End If
            Catch ex As Exception

                Err.Raise(Err.Number, "Error setting hyperlink/label lookup!<br />" & ex.Message.ToString())

            End Try

            Return TheImgBtn

        Catch ex As Exception

            Err.Raise(Err.Number, "Error setting hyplink/label properties!<br />" & ex.Message.ToString())

        End Try

    End Function

    Private Function SetHiddenField(ByRef TheHf As System.Web.UI.WebControls.HiddenField, ByVal PanelName As String, ByVal hfID As String,
                                    ByVal ImgBtnText As String, ByVal HasPopUp As Boolean, ByVal IsEdit As Boolean,
                                    Optional ByVal ThisValueControlID As String = "", Optional ByVal ThisDescriptControlID As String = "",
                                    Optional ByVal ItemCode As String = "", Optional ByVal imagepath As String = "") As System.Web.UI.WebControls.HiddenField
        Try
            Dim oAgency As New cAgency(Me.mConnString)
            ThisValueControlID = Replace(ThisValueControlID, "--", "_")
            ThisValueControlID = Replace(ThisValueControlID, "/", "_")
            With TheHf
                If ItemCode = "JOB_SPECIFICATIONS" Then
                    .ID = "HfJobSpec"
                    .Value = ThisValueControlID
                ElseIf ItemCode = "TRAFFIC_SCHEDULE" Then
                    .ID = "HfTrafficSchedule"
                    .Value = ThisValueControlID
                ElseIf ItemCode = "JOB_VERSIONS" Then
                    .ID = "HfJobVersions"
                    .Value = ThisValueControlID
                ElseIf ItemCode = "ESTIMATING" Then
                    .ID = "HfEstimating"
                    .Value = ThisValueControlID
                ElseIf ItemCode = "JOB_COMPONENT.PRD_CONT_CODE" Then
                    .ID = "HfContact"
                    .Value = ThisValueControlID
                ElseIf ItemCode = "JOB_LOG.JOB_COMMENTS" Then
                    .ID = "HfJobComments"
                    .Value = ThisValueControlID
                ElseIf ItemCode = "JOB_COMPONENT.JOB_COMP_COMMENTS" Then
                    .ID = "HfJobCompComments"
                    .Value = ThisValueControlID
                ElseIf ItemCode = "JOB_COMPONENT.CREATIVE_INSTR" Then
                    .ID = "HfCreativeInstr"
                    .Value = ThisValueControlID
                ElseIf ItemCode = "JOB_COMPONENT.JOB_DEL_INSTRUCT" Then
                    .ID = "HfJobDelInstruct"
                    .Value = ThisValueControlID
                End If
                '.ToolTip = "I am a hyperlink tooltip!"
            End With
            Return TheHf
        Catch ex As Exception
            Err.Raise(Err.Number, "Error setting hf properties!<br />" & ex.Message.ToString())
        End Try

    End Function

    Private Function SetHiddenFieldLb(ByRef TheHf As System.Web.UI.WebControls.HiddenField, ByVal PanelName As String, ByVal hfID As String,
                                    ByVal ImgBtnText As String, ByVal HasPopUp As Boolean, ByVal IsEdit As Boolean,
                                    Optional ByVal ThisValueControlID As String = "", Optional ByVal ThisDescriptControlID As String = "",
                                    Optional ByVal ItemCode As String = "", Optional ByVal imagepath As String = "") As System.Web.UI.WebControls.HiddenField
        Try
            Dim oAgency As New cAgency(Me.mConnString)
            ThisValueControlID = Replace(ThisValueControlID, "--", "_")
            ThisValueControlID = Replace(ThisValueControlID, "/", "_")
            With TheHf
                If ItemCode = "JOB_SPECIFICATIONS" Then
                    .ID = "HfJobSpecLb"
                    .Value = ThisValueControlID
                ElseIf ItemCode = "TRAFFIC_SCHEDULE" Then
                    .ID = "HfTrafficScheduleLb"
                    .Value = ThisValueControlID
                ElseIf ItemCode = "JOB_VERSIONS" Then
                    .ID = "HfJobVersionsLb"
                    .Value = ThisValueControlID
                ElseIf ItemCode = "ESTIMATING" Then
                    .ID = "HfEstimatingLb"
                    .Value = ThisValueControlID
                End If
                '.ToolTip = "I am a hyperlink tooltip!"
            End With
            Return TheHf
        Catch ex As Exception
            Err.Raise(Err.Number, "Error setting hf properties!<br />" & ex.Message.ToString())
        End Try

    End Function

    Private OpenSpacerTable As String = "<table width=""100%"" border=""0"" cellpadding=""2"" cellspacing=""0"" align=""left""><tr><td width=""210"" align=""right"" valign=""top"">"
    Private MiddleSpacerTable As String = "</td><td width=""1"" align=""center"" valign=""middle"">&nbsp;</td><td align=""left"" valign=""top"">"
    Private CloseSpacerTable As String = "</td></tr></table><br />"
    Private Spacer As String = "&nbsp;"
    'Private OpenSpacerTable As String = "<div class=""code-description-container""><div class=""code-description-label"">"
    'Private MiddleSpacerTable As String = "</div><div class=""code-description-description"">"
    'Private CloseSpacerTable As String = "</div></div>"

    Private Function OpenRowTable(ByVal SetAlignment As RowVerticalAlignment) As String

    End Function
    Private Function FillMiddleRowTable(ByVal SetAlignment As RowVerticalAlignment) As String

    End Function
    Private Function CloseRowTable() As String

    End Function
    Dim blackplt1 As String = ""
    Dim blackplt2 As String = ""
    Dim adnum As Boolean = False
    Dim adnumcontrol As String
    Private Function AddFormRowControls(ByVal FormIsEdit As Boolean, ByRef ThePanel As eWorld.UI.CollapsablePanel,
                                    ByVal ThisInputType As RowTypes, ByVal ThisItemCode As String, ByVal ThisControlID As String, ByVal ThisControlName As String,
                                    ByVal AdvantageRequired As Boolean, ByVal AgencyRequired As Boolean, ByVal ClientRequired As Boolean,
                                    ByVal TemplateRequired As Boolean, ByVal ThisValueControlValue As String,
                                    ByVal IsInternalCall As Boolean,
                                    Optional ByVal ThisDescriptControlID As String = "",
                                    Optional ByVal ThisDescriptControlValue As String = "",
                                    Optional ByVal HyperlinkOnClickJS As String = "", Optional ByVal editable As Boolean = False, Optional ByVal userid As String = "",
                                    Optional ByVal IsClientPortal As Boolean = False) As String

        Dim oAgency As New cAgency(Me.mConnString)

        Dim ReturnControlID As String = String.Empty
        Dim hfITEM_CODE As New System.Web.UI.WebControls.HiddenField
        Dim hfLinkID As New System.Web.UI.WebControls.HiddenField
        Dim hfLinkIDLb As New System.Web.UI.WebControls.HiddenField
        Dim txtbxValue As New System.Web.UI.WebControls.TextBox
        Dim txtbxDescript As New System.Web.UI.WebControls.TextBox
        Dim radioValue As New System.Web.UI.WebControls.RadioButton
        Dim rblValue As New System.Web.UI.WebControls.RadioButtonList
        Dim dropValue As New Telerik.Web.UI.RadComboBox
        Dim imgbtnValue As New System.Web.UI.WebControls.ImageButton
        Dim lblValue As New System.Web.UI.WebControls.Label
        Dim hlValue As New System.Web.UI.WebControls.HyperLink
        Dim lbValue As New System.Web.UI.WebControls.LinkButton
        Dim RadDatePickerJob As New Telerik.Web.UI.RadDatePicker
        Dim RadEditor As New Telerik.Web.UI.RadEditor

        Dim IDPrefix As String = ThePanel.ID.ToString() & "_"
        Dim IsRequiredField As Boolean = False
        Dim officeEditable As Boolean = False
        Dim IsReadOnly As Boolean = False
        Dim IsMissingValue As Boolean = False

        'Set requirement flags:
        If FormIsEdit = True Then

            If ThisItemCode = "JOB_LOG.OFFICE_CODE" AndAlso oAgency.JobTemplateEditOfficeCheck = False Then

                IsReadOnly = True
                ThisInputType = 10

            ElseIf ThisItemCode = "JOB_LOG.OFFICE_CODE" Then

                If _CheckAR = False AndAlso _CheckAP = False Then

                    IsReadOnly = False

                ElseIf _CheckAR = True OrElse _CheckAP = True Then

                    IsReadOnly = True
                    officeEditable = True
                    ThisInputType = 10

                Else

                    IsReadOnly = False

                End If

            Else

                IsReadOnly = False

            End If
            If ThisItemCode = "JOB_LOG.SC_CODE" Then

                If _CheckAR = False Then

                    IsReadOnly = False
                    ThisInputType = 1

                Else

                    officeEditable = True

                End If
                If _CheckARJob = True Then

                    IsReadOnly = True
                    ThisInputType = RowTypes.Label

                End If

            End If
            If ThisItemCode = "JOB_LOG.CL_CODE" OrElse ThisItemCode = "JOB_LOG.DIV_CODE" OrElse ThisItemCode = "JOB_LOG.PRD_CODE" Then

                If _CheckARJob = False AndAlso agency.CDPOverride = 1 Then

                    IsReadOnly = False
                    ThisInputType = 1

                Else

                    officeEditable = True

                End If
            End If
            If AdvantageRequired = True Then
                If ThisItemCode = "JOB_LOG.OFFICE_CODE" AndAlso oAgency.JobTemplateEditOfficeCheck = False Then
                    IsRequiredField = False
                    ThisInputType = 10
                Else
                    IsRequiredField = True
                End If
            Else
                If AgencyRequired = True AndAlso ClientRequired = True Then
                    If ThisItemCode = "JOB_LOG.OFFICE_CODE" AndAlso oAgency.JobTemplateEditOfficeCheck = False Then
                        IsRequiredField = False
                        ThisInputType = 10
                    Else
                        IsRequiredField = True
                    End If
                ElseIf AgencyRequired = True AndAlso ClientRequired = False Then
                    If oAgency.JobTemplateOverrideAgencyCheck(Me.client) = True Then
                        IsRequiredField = False
                    Else
                        IsRequiredField = True
                    End If
                ElseIf AgencyRequired = False AndAlso ClientRequired = True Then
                    If oAgency.JobTemplateOverrideAgencyCheck(Me.client) = True Then
                        IsRequiredField = True
                    Else
                        IsRequiredField = False
                    End If
                ElseIf AgencyRequired = False AndAlso ClientRequired = False Then
                    If TemplateRequired = True Then
                        IsRequiredField = True
                    Else
                        IsRequiredField = False
                    End If
                Else
                    IsRequiredField = False
                End If
            End If
        Else
            IsReadOnly = True
        End If

        ''spacer row:
        'ThePanel.Controls.Add(MiscFN.NewLiteral("<br />"))

        'Start creating the controls and filling the data:
        Dim hl As New System.Web.UI.WebControls.HyperLink
        Dim imgbtn As New System.Web.UI.WebControls.ImageButton
        Dim cl As String
        ThisControlName = Replace(ThisControlName, "--", "_")
        ThisControlName = Replace(ThisControlName, "/", "_SLASH_")
        ThisControlName = Replace(ThisControlName, "'", "")
        Try
            Select Case ThisInputType
                Case RowTypes.ValDescript
                    If ThisItemCode = "JOB_LOG.SC_CODE" OrElse ThisItemCode = "JOB_LOG.CL_CODE" OrElse ThisItemCode = "JOB_LOG.DIV_CODE" OrElse ThisItemCode = "JOB_LOG.PRD_CODE" Then
                        Dim str() As String = ThisValueControlValue.Replace("&nbsp;", "").Split("-")
                        ThisValueControlValue = str(0)
                    End If
                    With txtbxValue
                        .ID = IDPrefix & "TxtValue_" & ThisItemCode.Replace(".", "")
                        .SkinID = "TextBoxCodeSmall"
                        .Text = ThisValueControlValue
                        .TabIndex = tabIndex + 1
                        If ThisItemCode = "JOB_LOG.CL_CODE" OrElse ThisItemCode = "JOB_LOG.DIV_CODE" Then
                            If ThisItemCode = "JOB_LOG.CL_CODE" Then
                                .Attributes.Add("onchange", "document.getElementById(""ctl00_ContentPlaceHolderMain_" & IDPrefix & "TxtDescript_" & ThisItemCode.Replace(".", "") & """).value = '';document.getElementById(""ctl00_ContentPlaceHolderMain_colpnl" & sectionDiv.Replace(" ", "") & "_TxtValue_JOB_LOGDIV_CODE"").value = '';document.getElementById(""ctl00_ContentPlaceHolderMain_colpnl" & sectionDiv.Replace(" ", "") & "_TxtDescript_JOB_LOGDIV_CODE"").value = '';document.getElementById(""ctl00_ContentPlaceHolderMain_colpnl" & sectionPrd.Replace(" ", "") & "_TxtValue_JOB_LOGPRD_CODE"").value = '';document.getElementById(""ctl00_ContentPlaceHolderMain_colpnl" & sectionPrd.Replace(" ", "") & "_TxtDescript_JOB_LOGPRD_CODE"").value = '';")
                            End If
                            If ThisItemCode = "JOB_LOG.DIV_CODE" Then
                                .Attributes.Add("onchange", "document.getElementById(""ctl00_ContentPlaceHolderMain_" & IDPrefix & "TxtDescript_" & ThisItemCode.Replace(".", "") & """).value = '';document.getElementById(""ctl00_ContentPlaceHolderMain_colpnl" & sectionPrd.Replace(" ", "") & "_TxtValue_JOB_LOGPRD_CODE"").value = '';document.getElementById(""ctl00_ContentPlaceHolderMain_colpnl" & sectionPrd.Replace(" ", "") & "_TxtDescript_JOB_LOGPRD_CODE"").value = '';")
                            End If
                        ElseIf ThisItemCode = "JOB_LOG.SC_CODE" Then
                            .Attributes.Add("onchange", "$(""#ctl00_ContentPlaceHolderMain_" & IDPrefix & "TxtDescript_" & ThisItemCode.Replace(".", "") & """).val(''); $(""input[type=text][id$=TxtValue_JOB_COMPONENTJT_CODE]"").val(''); $(""input[type=text][id$=TxtDescript_JOB_COMPONENTJT_CODE]"").val('');")
                        Else
                            .Attributes.Add("onchange", "document.getElementById(""ctl00_ContentPlaceHolderMain_" & IDPrefix & "TxtDescript_" & ThisItemCode.Replace(".", "") & """).value = ''")
                        End If
                    End With
                    With txtbxDescript
                        .ID = IDPrefix & "TxtDescript_" & ThisItemCode.Replace(".", "")
                        .SkinID = "TextBoxCodeSingleLineDescription"
                        .Text = ThisDescriptControlValue
                        .ReadOnly = True
                        .TabIndex = -1
                    End With
                    If ThisItemCode = "JOB_COMPONENT.TAX_CODE" AndAlso oAgency.JobTemplateMarkedTaxable = False Then
                        txtbxValue.Visible = False
                        txtbxDescript.Visible = False
                    End If
                    SetHyperLink(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, FormIsEdit, txtbxValue.ClientID.ToString(), txtbxDescript.ClientID.ToString(), ThisItemCode, False, "")
                    If ThisItemCode = "JOB_COMPONENT.PRD_CONT_CODE" AndAlso IsClientPortal = False Then
                        With imgbtn
                            .ID = IDPrefix & "ImgBtnValue_" & ThisControlName.Replace("""", "").Replace("'", "") & "_" & ThisItemCode.Replace(".", "")
                            .ImageAlign = ImageAlign.AbsMiddle
                        End With
                        SetImageButton(imgbtn, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, FormIsEdit, imgbtn.ClientID.ToString(), "", ThisItemCode, imgbtn.Attributes.Item("onclick"))
                        'SetHiddenField(hfLinkID, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, FormIsEdit, txtbxValue.ClientID.ToString(), "", ThisItemCode, txtbxValue.Attributes.Item("onclick"))
                    End If
                    If ThisItemCode = "JOB_LOG.CL_CODE" AndAlso IsClientPortal = False Then
                        With imgbtn
                            .ID = IDPrefix & "ImgBtnValue_" & ThisControlName.Replace("""", "").Replace("'", "") & "_" & ThisItemCode.Replace(".", "")
                            .ImageAlign = ImageAlign.AbsMiddle
                        End With
                        SetImageButton(imgbtn, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, FormIsEdit, imgbtn.ClientID.ToString(), "", ThisItemCode, imgbtn.Attributes.Item("onclick"))
                        'SetHiddenField(hfLinkID, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, FormIsEdit, txtbxValue.ClientID.ToString(), "", ThisItemCode, txtbxValue.Attributes.Item("onclick"))
                    End If
                Case RowTypes.EvenSplit
                    With txtbxValue
                        .ID = IDPrefix & "TxtValue_" & ThisControlName & "_" & ThisItemCode.Replace(".", "")
                        .Width = Unit.Pixel(200)
                        .Text = ThisValueControlValue
                        .TabIndex = tabIndex + 1
                        .Attributes.Add("onchange", "document.getElementById(""ctl00_ContentPlaceHolderMain_" & IDPrefix & "TxtDescript_" & ThisControlName & "_" & ThisItemCode.Replace(".", "") & """).value = ''")
                        .Attributes.Add("onkeyup", "document.getElementById(""ctl00_ContentPlaceHolderMain_" & IDPrefix & "TxtDescript_" & ThisControlName & "_" & ThisItemCode.Replace(".", "") & """).value = ''")
                    End With
                    With txtbxDescript
                        .ID = IDPrefix & "TxtDescript_" & ThisControlName & "_" & ThisItemCode.Replace(".", "")
                        .Width = Unit.Pixel(200)
                        .Text = ThisDescriptControlValue
                        .TabIndex = -1
                    End With
                    If ThisItemCode = "JOB_COMPONENT.AD_NBR" Then
                        txtbxDescript.Attributes.Add("onchange", "document.getElementById(""ctl00_ContentPlaceHolderMain_" & IDPrefix & "TxtValue_" & ThisControlName & "_" & ThisItemCode.Replace(".", "") & """).value = ''")
                        txtbxDescript.Attributes.Add("onkeyup", "document.getElementById(""ctl00_ContentPlaceHolderMain_" & IDPrefix & "TxtValue_" & ThisControlName & "_" & ThisItemCode.Replace(".", "") & """).value = ''")
                        Dim i As Integer
                        Dim index As Integer
                        Dim index2 As Integer
                        Dim bp1section As Integer
                        Dim bp2section As Integer
                        Dim bp1sectionname As String
                        Dim bp2sectionname As String
                        Dim ds As DataSet
                        ds = GetJobTemplateDetails(jobnum, jobcompnum)
                        If Me.blackplt1 = "" Then
                            For i = 0 To ds.Tables(0).Rows.Count - 1
                                If ds.Tables(0).Rows(i)("ITEM_CODE") = "JOB_COMPONENT.BLACKPLT_VER_DESC" Then
                                    bp1section = CInt(ds.Tables(0).Rows(i)("SECTION_ORDER"))
                                End If
                            Next
                            For i = 0 To ds.Tables(0).Rows.Count - 1
                                If ds.Tables(0).Rows(i)("ITEM_CODE") = "SECTION" AndAlso ds.Tables(0).Rows(i)("SECTION_ORDER") = bp1section Then
                                    bp1sectionname = ds.Tables(0).Rows(i)("SHORT_DESC").ToString
                                    bp1sectionname = Replace(bp1sectionname, " ", "")
                                End If
                            Next
                            If Me.sectionindex = 0 Then
                                index = bp1section
                            Else
                                index = bp1section - 1
                            End If
                            Me.blackplt1 = "ctl00_ContentPlaceHolderMain_colpnl" & bp1sectionname & index & "_TxtValue_Blackplate_1"
                        End If
                        If Me.blackplt2 = "" Then
                            For i = 0 To ds.Tables(0).Rows.Count - 1
                                If ds.Tables(0).Rows(i)("ITEM_CODE") = "JOB_COMPONENT.BLACKPLT_VER2_DESC" Then
                                    bp2section = CInt(ds.Tables(0).Rows(i)("SECTION_ORDER"))
                                End If
                            Next
                            For i = 0 To ds.Tables(0).Rows.Count - 1
                                If ds.Tables(0).Rows(i)("ITEM_CODE") = "SECTION" AndAlso ds.Tables(0).Rows(i)("SECTION_ORDER") = bp2section Then
                                    bp2sectionname = ds.Tables(0).Rows(i)("SHORT_DESC").ToString
                                    bp2sectionname = Replace(bp2sectionname, " ", "")
                                End If
                            Next
                            If Me.sectionindex = 0 Then
                                index2 = bp2section
                            Else
                                index2 = bp2section - 1
                            End If
                            Me.blackplt2 = "ctl00_ContentPlaceHolderMain_colpnl" & bp2sectionname & index2 & "_TxtValue_Blackplate_2"
                        End If
                    End If
                    SetHyperLink(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, FormIsEdit, txtbxValue.ID.ToString(), txtbxDescript.ClientID.ToString(), ThisItemCode, False, "")
                Case RowTypes.ValOnly
                    With txtbxValue
                        .ID = IDPrefix & "TxtValue_" & ThisControlName.Replace("""", "").Replace("'", "").Replace(":", "") & "_" & ThisItemCode.Replace(".", "")
                        .SkinID = "TextBoxCodeValueOnly"
                        If editable = True Then
                            .Text = ThisDescriptControlValue
                        Else
                            .Text = ThisValueControlValue
                        End If
                        .TabIndex = tabIndex + 1
                        If ThisItemCode = "JOB_CLIENT_REF.JOB_CLI_REF" OrElse ThisItemCode = "JOB_COMPONENT.ACCT_NBR" Then
                            .MaxLength = 30
                        ElseIf ThisItemCode = "JOB_COMPONENT.JOB_CL_PO_NBR" OrElse editable = True Then
                            .MaxLength = 40
                        Else
                            .MaxLength = 60
                        End If
                        If ThisItemCode = "JOB_COMPONENT.JOB_COMP_BUDGET_AM" AndAlso txtbxValue.Text <> "" Then
                            Dim ds As DataSet
                            ds = GetJobTemplateDetails(jobnum, jobcompnum)
                            If ds.Tables(2).Rows.Count > 0 Then
                                If IsDBNull(ds.Tables(2).Rows(0)("JOB_COMP_BUDGET_AM")) = False Then
                                    .Text = CDec(ds.Tables(2).Rows(0)("JOB_COMP_BUDGET_AM"))
                                End If
                            Else
                                .Text = CDec(ThisValueControlValue)
                            End If
                        End If
                    End With
                    SetHyperLink(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, FormIsEdit, txtbxValue.ID.ToString(), "", ThisItemCode, editable, "")
                Case RowTypes.MultiLine

                    If ThisItemCode = "JOB_COMPONENT.JOB_LAYOUT_SPC_EXP" OrElse ThisItemCode = "JOB_LOG.JOB_BILL_COMMENT" Then
                        With txtbxValue

                            .ID = IDPrefix & "TxtValue_" & ThisControlName & "_" & ThisItemCode.Replace(".", "")
                            .SkinID = "TextBoxCodeMultiLine"
                            .TextMode = TextBoxMode.MultiLine
                            .TabIndex = tabIndex + 1

                            If ThisItemCode = "JOB_COMPONENT.JOB_LAYOUT_SPC_EXP" Then

                                .Attributes.Add("onkeyup", "checkLength(this,60);")

                            ElseIf ThisItemCode = "JOB_LOG.JOB_BILL_COMMENT" Then

                                .Attributes.Add("onkeyup", "checkLength(this,254);")

                            Else

                                .Attributes.Add("onkeyup", "checkLength(this,32000);")

                            End If

                            .Text = ThisValueControlValue

                        End With

                        SetHyperLink(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, FormIsEdit, txtbxValue.ID.ToString(), "", ThisItemCode, False, "")

                    End If

                    If ThisItemCode = "JOB_LOG.JOB_COMMENTS" OrElse ThisItemCode = "JOB_COMPONENT.JOB_COMP_COMMENTS" OrElse ThisItemCode = "JOB_COMPONENT.CREATIVE_INSTR" OrElse ThisItemCode = "JOB_COMPONENT.JOB_DEL_INSTRUCT" Then
                        With RadEditor
                            .ID = IDPrefix & "RadEditor" & ThisControlName & "_" & ThisItemCode.Replace(".", "")
                            '.SkinID = "TextBoxCodeMultiLine"
                            .TabIndex = tabIndex + 1
                            .Attributes.Add("onkeyup", "checkLength(this,32000);")

                            If ThisItemCode = "JOB_LOG.JOB_COMMENTS" Then

                                If Me.DtJobComments.Rows(0)("JOB_COMMENTS_HTML").ToString <> "" Then

                                    .Content = Job_Specs.DecodeSQL(Me.DtJobComments.Rows(0)("JOB_COMMENTS_HTML").ToString)

                                Else

                                    .Content = Job_Specs.DecodeSQL(Me.DtJobComments.Rows(0)("JOB_COMMENTS").ToString).Replace(Environment.NewLine, "<br/>")

                                End If

                            ElseIf ThisItemCode = "JOB_COMPONENT.JOB_COMP_COMMENTS" Then

                                If Me.DtJobComments.Rows(0)("JC_COMMENTS_HTML").ToString <> "" Then

                                    .Content = Job_Specs.DecodeSQL(Me.DtJobComments.Rows(0)("JC_COMMENTS_HTML").ToString)

                                Else

                                    .Content = Job_Specs.DecodeSQL(Me.DtJobComments.Rows(0)("JOB_COMP_COMMENTS").ToString).Replace(Environment.NewLine, "<br/>")

                                End If

                            ElseIf ThisItemCode = "JOB_COMPONENT.CREATIVE_INSTR" Then

                                If Me.DtJobComments.Rows(0)("CREATIVE_INSTR_HTML").ToString <> "" Then

                                    .Content = Job_Specs.DecodeSQL(Me.DtJobComments.Rows(0)("CREATIVE_INSTR_HTML").ToString)

                                Else

                                    .Content = Job_Specs.DecodeSQL(Me.DtJobComments.Rows(0)("CREATIVE_INSTR").ToString).Replace(Environment.NewLine, "<br/>")

                                End If

                            ElseIf ThisItemCode = "JOB_COMPONENT.JOB_DEL_INSTRUCT" Then

                                If Me.DtJobComments.Rows(0)("JOB_DEL_INSTR_HTML").ToString <> "" Then

                                    .Content = Job_Specs.DecodeSQL(Me.DtJobComments.Rows(0)("JOB_DEL_INSTR_HTML").ToString)

                                Else

                                    .Content = Job_Specs.DecodeSQL(Me.DtJobComments.Rows(0)("JOB_DEL_INSTRUCT").ToString).Replace(Environment.NewLine, "<br/>")

                                End If

                            Else

                                .Content = ThisValueControlValue

                            End If

                        End With

                        If ThisItemCode = "JOB_LOG.JOB_COMMENTS" OrElse ThisItemCode = "JOB_COMPONENT.JOB_COMP_COMMENTS" OrElse ThisItemCode = "JOB_COMPONENT.CREATIVE_INSTR" OrElse ThisItemCode = "JOB_COMPONENT.JOB_DEL_INSTRUCT" Then

                            With imgbtn

                                .ID = IDPrefix & "ImgBtnValue_" & ThisControlName.Replace("""", "").Replace("'", "") & "_" & ThisItemCode.Replace(".", "")
                                .ImageAlign = ImageAlign.AbsMiddle

                            End With

                            SetImageButton(imgbtn, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, FormIsEdit, imgbtn.ClientID.ToString(), "", ThisItemCode, imgbtn.Attributes.Item("onclick"))
                            SetHiddenField(hfLinkID, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, FormIsEdit, imgbtn.ClientID.ToString(), "", ThisItemCode, lbValue.Attributes.Item("onclick"))

                        End If

                        SetHyperLink(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, FormIsEdit, RadEditor.ID.ToString(), "", ThisItemCode, False, "")

                    End If

                Case RowTypes.RadioButton

                Case RowTypes.RadioButtonList
                    With rblValue
                        .ID = IDPrefix & "RblValue_" & ThisControlName & "_" & ThisItemCode.Replace(".", "")
                        .RepeatDirection = RepeatDirection.Horizontal
                        .RepeatLayout = RepeatLayout.Flow
                        .TabIndex = tabIndex + 1
                    End With
                    SetHyperLink(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, False, FormIsEdit, rblValue.ClientID.ToString(), "", ThisItemCode, False, "")
                Case RowTypes.DropDownList
                    With dropValue
                        .ID = IDPrefix & "DropValue_" & ThisControlName & "_" & ThisItemCode.Replace(".", "")
                        .TabIndex = tabIndex + 1
                        .SkinID = "RadComboBoxStandard"
                        If InStr(ThisItemCode, "EMAIL_GR_CODE") > 0 Then
                            Dim oDD As cDropDowns = New cDropDowns(mConnString)
                            .DataSource = oDD.GetEmailGroups(mThisEmpCode)
                            .DataValueField = "Code"
                            .DataTextField = "Description"
                            .DataBind()
                            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", ""))
                            If mIsNewComp = True Then
                                Dim od As Alert = New Alert(mConnString)
                                MiscFN.RadComboBoxSetIndex(dropValue, od.GetDefaultGroup(mCL_CODE, mDIV_CODE, mPRD_CODE), False, False)
                            Else
                                MiscFN.RadComboBoxSetIndex(dropValue, ThisValueControlValue, False, True)
                            End If
                        End If
                        If InStr(ThisItemCode, "ALRT_NOTIFY_HDR_ID") > 0 Then
                            Dim a As New cAlerts()
                            .DataSource = a.GetAlertNotifyTemplates(False)
                            .DataValueField = "ALRT_NOTIFY_HDR_ID"
                            .DataTextField = "ALERT_NOTIFY_NAME"
                            .DataBind()
                            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", ""))
                            Try
                                MiscFN.RadComboBoxSetIndex(dropValue, ThisValueControlValue, False)
                            Catch ex As Exception
                            End Try
                            .SkinID = "RadComboBoxEmployee"
                        End If
                        If InStr(ThisItemCode, "SERVICE_FEE_TYPE_ID") > 0 Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.mConnString, Me.mUserCode)
                                .DataSource = AdvantageFramework.Database.Procedures.ServiceFeeType.LoadAllActive(DbContext).ToList.OrderBy(Function(Servicefeetype) Servicefeetype.Code)
                                .DataValueField = "ID"
                                .DataTextField = "Description"
                                .DataBind()
                                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", ""))
                            End Using
                            Try
                                MiscFN.RadComboBoxSetIndex(dropValue, ThisValueControlValue, False)
                            Catch ex As Exception
                            End Try
                        End If
                    End With
                    SetHyperLink(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, False, FormIsEdit, dropValue.ClientID.ToString(), "", ThisItemCode, False, "")
                Case RowTypes.ImageButton

                Case RowTypes.TextBoxCalendar
                    Dim RadCalDay As Telerik.Web.UI.RadCalendarDay = New Telerik.Web.UI.RadCalendarDay
                    RadCalDay.Date = Date.Now
                    RadCalDay.Repeatable = Telerik.Web.UI.Calendar.RecurringEvents.Today
                    RadCalDay.ItemStyle.BackColor = Color.LightSalmon
                    With RadDatePickerJob
                        .ID = IDPrefix & "RadDatePickerValue_" & ThisControlName & "_" & ThisItemCode.Replace(".", "")
                        .SkinID = "RadDatePickerStandard"
                        If ThisValueControlValue = LoGlo.FormatDate("01/01/1900") Then
                            .SelectedDate = Nothing
                        Else
                            .SelectedDate = LoGlo.FormatDate(ThisValueControlValue)
                        End If
                        .Calendar.SpecialDays.Add(RadCalDay)
                        .TabIndex = tabIndex + 1
                    End With

                    SetHyperLink(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, False, FormIsEdit, RadDatePickerJob.ClientID.ToString(), "", ThisItemCode, False, "")

                Case RowTypes.Label
                    With lblValue
                        .ID = IDPrefix & "LblValue_" & ThisControlName & "_" & ThisItemCode.Replace(".", "")
                        If String.IsNullOrWhiteSpace(ThisValueControlValue) = False Then

                            If ThisItemCode = "JOB_LOG.OFFICE_CODE" AndAlso oAgency.JobTemplateEditOfficeCheck = False Then

                                .Text = ThisValueControlValue & " - " & ThisDescriptControlValue

                            ElseIf ThisItemCode = "JOB_LOG.OFFICE_CODE" Then

                                If _CheckAR = False AndAlso _CheckAP = False Then

                                    .Text = ThisValueControlValue

                                ElseIf _CheckAR = True OrElse _CheckAP = True Then

                                    .Text = ThisValueControlValue & " - " & ThisDescriptControlValue

                                Else

                                    .Text = ThisValueControlValue

                                End If

                            ElseIf ThisItemCode = "JOB_LOG.USER_ID" Then

                                Try

                                    Dim values As String()
                                    Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-US")

                                    values = ThisValueControlValue.Split("-")

                                    If values.Length = 2 Then
                                        Dim parsedDate As Date = Date.ParseExact(values(1).Trim, "MM/dd/yyyy", ci)
                                        ThisValueControlValue = values(0).Trim & " - " & parsedDate.ToString(LoGlo.GetDateFormat())
                                    End If


                                    'Dim ar() As String
                                    'ar = ThisValueControlValue.Split("-")

                                    'If ar IsNot Nothing AndAlso ar.Length = 2 Then

                                    '    If IsDate(ar(1).Trim) = True Then

                                    '        ThisValueControlValue = String.Format("{0} - {1}", ar(0).Trim, CDate(ar(1).Trim).ToString(LoGlo.GetDateFormat())) 'LoGlo.FormatDate(CDate(ar(2))))
                                    '        .Text = ThisValueControlValue

                                    '    End If

                                    'End If
                                    .Text = ThisValueControlValue

                                Catch ex As Exception
                                    .Text = ThisValueControlValue
                                End Try

                            Else

                                .Text = ThisValueControlValue

                            End If

                        Else

                            .Text = "-"

                        End If
                        If ThisControlName = "Job_Number" AndAlso lblValue.Text.Length < 6 Then
                            lblValue.Text = lblValue.Text.PadLeft(6, "0")
                        End If
                        If ThisControlName = "Component_Number" AndAlso lblValue.Text.Length < 2 Then
                            lblValue.Text = lblValue.Text.PadLeft(3, "0")
                        End If
                        If ThisControlName = "Estimate" AndAlso lblValue.Text <> "-" Then
                            lblValue.Text = Me.addleadingZeroesEstimate(lblValue.Text)
                        End If

                        If ThisItemCode = "TOTAL_JOB_BUDGET" Then
                            Dim ds As DataSet
                            ds = GetJobTemplateDetails(jobnum, jobcompnum)
                            If ds.Tables(2).Rows.Count > 0 Then
                                If IsDBNull(ds.Tables(2).Rows(0)("TOTAL_JOB_BUDGET")) = False Then
                                    .Text = CDec(ds.Tables(2).Rows(0)("TOTAL_JOB_BUDGET"))
                                End If
                            Else
                                .Text = LoGlo.FormatDecimal(lblValue.Text)
                            End If
                        End If
                    End With
                    If ThisItemCode = "JOB_LOG.OFFICE_CODE" OrElse ThisItemCode = "JOB_LOG.SC_CODE" OrElse ThisItemCode = "JOB_LOG.CL_CODE" OrElse ThisItemCode = "JOB_LOG.DIV_CODE" OrElse ThisItemCode = "JOB_LOG.PRD_CODE" Then
                        SetHyperLink(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, False, FormIsEdit, lblValue.ClientID.ToString(), "", ThisItemCode, officeEditable, userid)
                    Else
                        SetHyperLink(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, False, FormIsEdit, lblValue.ClientID.ToString(), "", ThisItemCode, False, userid)
                    End If
                    If ThisItemCode = "JOB_LOG.CL_CODE" AndAlso IsClientPortal = False Then
                        With imgbtn
                            .ID = IDPrefix & "ImgBtnValue_" & ThisControlName.Replace("""", "").Replace("'", "") & "_" & ThisItemCode.Replace(".", "")
                            .ImageAlign = ImageAlign.AbsMiddle
                        End With
                        SetImageButton(imgbtn, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, FormIsEdit, imgbtn.ClientID.ToString(), "", ThisItemCode, imgbtn.Attributes.Item("onclick"))
                        'SetHiddenField(hfLinkID, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, FormIsEdit, txtbxValue.ClientID.ToString(), "", ThisItemCode, txtbxValue.Attributes.Item("onclick"))
                    End If
                    IsReadOnly = True
                Case RowTypes.YesNoRBL
                    With rblValue
                        .ID = IDPrefix & "RblValue_" & ThisControlName & "_" & ThisItemCode.Replace(".", "")
                        .RepeatDirection = RepeatDirection.Horizontal
                        .RepeatLayout = RepeatLayout.Flow
                        .Items.Add("Yes")
                        .Items.Add("No")
                        .TabIndex = tabIndex + 1
                        If ThisValueControlValue = "1" Then
                            rblValue.SelectedIndex = 0
                        ElseIf ThisValueControlValue = "0" Then
                            rblValue.SelectedIndex = 1
                        Else
                            rblValue.SelectedIndex = -1
                        End If
                    End With
                    If ThisItemCode = "JOB_COMPONENT.NOBILL_FLAG" AndAlso oAgency.JobTemplateNonBillableJCCheck = True Then
                        rblValue.Visible = False
                    End If
                    If ThisItemCode = "JOB_LOG.JOB_ESTIMATE_REQ" Then
                        Dim oReqCheck As cRequired = New cRequired(Me.mConnString)
                        If oReqCheck.RequiredApprovedEstimate(Me.mCL_CODE, Me.mDIV_CODE, Me.mPRD_CODE) = True AndAlso oReqCheck.OverrideApprovedEstimate = False Then
                            rblValue.SelectedIndex = 0
                            IsReadOnly = True
                        End If
                        If oReqCheck.OverrideApprovedEstimate = True Then
                            IsReadOnly = False
                        End If
                    End If
                    If ThisItemCode = "JOB_COMPONENT.TAX_FLAG" AndAlso oAgency.JobTemplateMarkedTaxable = False Then
                        rblValue.Visible = False
                    End If
                    If IsClientPortal = True AndAlso ThisItemCode = "JOB_LOG.JOB_ESTIMATE_REQ" Then
                        IsReadOnly = True
                    End If
                    SetHyperLink(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, False, FormIsEdit, rblValue.ClientID.ToString(), "", ThisItemCode, False, "")
                Case RowTypes.LinkButton
                    With lbValue
                        .ID = IDPrefix & "lbValue_" & ThisControlName & "_" & ThisItemCode.Replace(".", "")
                        .ID = .ID.Replace("/", "")
                        '.Text = Replace(ThisControlName, "_", "&nbsp;")
                        If Not ThisControlName Is Nothing Then
                            .Text = ThisControlName.Replace("_SLASH_", "/").Replace("_", "&nbsp;")
                        End If
                        .CssClass = "TemplateLabel"
                        .Font.Underline = True
                        'If HyperlinkOnClickJS <> "" Then
                        '    .Attributes.Add("onclick", "" & HyperlinkOnClickJS & ";return false;")
                        'End If
                        If ThisItemCode = "JOB_SPECIFICATIONS" Then
                            .CommandName = "GoToJS"
                        End If
                        If ThisItemCode = "TRAFFIC_SCHEDULE" Then
                            .CommandName = "GoToTS"
                        End If
                        If ThisItemCode = "JOB_VERSIONS" Then
                            .CommandName = "GoToJV"
                        End If
                        If ThisItemCode = "ESTIMATING" Then
                            .CommandName = "GoToEST"
                        End If
                    End With
                    SetImageButton(imgbtn, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, FormIsEdit, lbValue.ClientID.ToString(), "", ThisItemCode, lbValue.Attributes.Item("onclick"))
                    If ThisItemCode = "JOB_SPECIFICATIONS" OrElse ThisItemCode = "TRAFFIC_SCHEDULE" OrElse ThisItemCode = "JOB_VERSIONS" OrElse ThisItemCode = "ESTIMATING" Then
                        SetHiddenField(hfLinkID, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, FormIsEdit, imgbtn.ClientID.ToString(), "", ThisItemCode, lbValue.Attributes.Item("onclick"))
                        SetHiddenFieldLb(hfLinkIDLb, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, FormIsEdit, lbValue.ClientID.ToString(), "", ThisItemCode, lbValue.Attributes.Item("onclick"))
                    End If
                Case RowTypes.ValEditableDesc
                    With txtbxValue
                        .ID = IDPrefix & "TxtValue_" & ThisControlName & "_" & ThisItemCode.Replace(".", "")
                        .SkinID = "TextBoxCodeSmall"
                        .Text = ThisValueControlValue
                        .TabIndex = tabIndex + 1
                        .Attributes.Add("onkeyup", "document.getElementById(""ctl00_ContentPlaceHolderMain_" & IDPrefix & "TxtDescript_" & ThisControlName & "_" & ThisItemCode.Replace(".", "") & """).value = ''")
                    End With
                    With txtbxDescript
                        .ID = IDPrefix & "TxtDescript_" & ThisControlName & "_" & ThisItemCode.Replace(".", "")
                        .SkinID = "TextBoxCodeSingleLineDescription"
                        .Text = ThisDescriptControlValue
                        If ThisItemCode = "JOB_COMPONENT.BLACKPLT_VER_DESC" Then
                            .Attributes.Add("onKeyup", "document.getElementById(""ctl00_ContentPlaceHolderMain_" & IDPrefix & "TxtValue_" & ThisControlName & "_" & ThisItemCode.Replace(".", "") & """).value = ''")
                        End If
                        If ThisItemCode = "JOB_COMPONENT.BLACKPLT_VER2_DESC" Then
                            .Attributes.Add("onKeyup", "document.getElementById(""ctl00_ContentPlaceHolderMain_" & IDPrefix & "TxtValue_" & ThisControlName & "_" & ThisItemCode.Replace(".", "") & """).value = ''")
                        End If
                        .TabIndex = -1
                    End With
                    If ThisItemCode = "JOB_COMPONENT.BLACKPLT_VER_DESC" Then
                        Me.blackplt1 = "ctl00_ContentPlaceHolderMain_" & IDPrefix & "TxtValue_" & ThisControlName
                    End If
                    If ThisItemCode = "JOB_COMPONENT.BLACKPLT_VER2_DESC" Then
                        Me.blackplt2 = "ctl00_ContentPlaceHolderMain_" & IDPrefix & "TxtValue_" & ThisControlName
                    End If
                    SetHyperLink(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, FormIsEdit, txtbxValue.ClientID.ToString(), txtbxDescript.ClientID.ToString(), ThisItemCode, False, "")
                Case RowTypes.AdNumber
                    With txtbxValue
                        .ID = IDPrefix & "TxtValue_" & ThisControlName & "_" & ThisItemCode.Replace(".", "")
                        .SkinID = "TextBoxCodeBootstrap"
                        .Text = ThisValueControlValue
                        .TabIndex = tabIndex + 1
                        .Width = New Unit(275, UnitType.Pixel)
                        .MaxLength = 30
                        .Attributes.Add("onchange", "document.getElementById(""ctl00_ContentPlaceHolderMain_" & IDPrefix & "TxtDescript_" & ThisControlName & "_" & ThisItemCode.Replace(".", "") & """).value = ''")
                        '.Attributes.Add("onkeyup", "document.getElementById(""ctl00_ContentPlaceHolderMain_" & IDPrefix & "TxtDescript_" & ThisControlName & "_" & ThisItemCode.Replace(".", "") & """).value = ''")
                    End With
                    With txtbxDescript
                        .ID = IDPrefix & "TxtDescript_" & ThisControlName & "_" & ThisItemCode.Replace(".", "")
                        .SkinID = "TextBoxCodeBootstrap"
                        .Text = ThisDescriptControlValue
                        .TabIndex = tabIndex + 1
                        .Width = New Unit(405, UnitType.Pixel)
                        .MaxLength = 60
                        .Attributes.Add("onchange", "document.getElementById(""ctl00_ContentPlaceHolderMain_" & IDPrefix & "TxtValue_" & ThisControlName & "_" & ThisItemCode.Replace(".", "") & """).value = ''")
                        .ReadOnly = True
                    End With
                    'MiscFN.LimitTextbox(txtbxDescript, 60)
                    Dim i As Integer
                    Dim index As Integer
                    Dim index2 As Integer
                    Dim bp1section As Integer
                    Dim bp2section As Integer
                    Dim bp1sectionname As String
                    Dim bp2sectionname As String
                    Dim ds As DataSet
                    ds = GetJobTemplateDetails(jobnum, jobcompnum)
                    If Me.blackplt1 = "" Then
                        For i = 0 To ds.Tables(0).Rows.Count - 1
                            If ds.Tables(0).Rows(i)("ITEM_CODE") = "JOB_COMPONENT.BLACKPLT_VER_DESC" Then
                                bp1section = CInt(ds.Tables(0).Rows(i)("SECTION_ORDER"))
                            End If
                        Next
                        For i = 0 To ds.Tables(0).Rows.Count - 1
                            If ds.Tables(0).Rows(i)("ITEM_CODE") = "SECTION" AndAlso ds.Tables(0).Rows(i)("SECTION_ORDER") = bp1section Then
                                bp1sectionname = ds.Tables(0).Rows(i)("SHORT_DESC").ToString
                                bp1sectionname = Replace(bp1sectionname, " ", "")
                            End If
                        Next
                        If Me.sectionindex = 0 Then
                            index = bp1section
                        Else
                            index = bp1section - 1
                        End If
                        Me.blackplt1 = "ctl00_ContentPlaceHolderMain_colpnl" & bp1sectionname & index & "_TxtValue_Blackplate_1"
                    End If
                    If Me.blackplt2 = "" Then
                        For i = 0 To ds.Tables(0).Rows.Count - 1
                            If ds.Tables(0).Rows(i)("ITEM_CODE") = "JOB_COMPONENT.BLACKPLT_VER2_DESC" Then
                                bp2section = CInt(ds.Tables(0).Rows(i)("SECTION_ORDER"))
                            End If
                        Next
                        For i = 0 To ds.Tables(0).Rows.Count - 1
                            If ds.Tables(0).Rows(i)("ITEM_CODE") = "SECTION" AndAlso ds.Tables(0).Rows(i)("SECTION_ORDER") = bp2section Then
                                bp2sectionname = ds.Tables(0).Rows(i)("SHORT_DESC").ToString
                                bp2sectionname = Replace(bp2sectionname, " ", "")
                            End If
                        Next
                        If Me.sectionindex = 0 Then
                            index2 = bp2section
                        Else
                            index2 = bp2section - 1
                        End If
                        Me.blackplt2 = "ctl00_ContentPlaceHolderMain_colpnl" & bp2sectionname & index2 & "_TxtValue_Blackplate_2"
                    End If
                    SetHyperLink(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, FormIsEdit, txtbxValue.ID.ToString(), txtbxDescript.ClientID.ToString(), ThisItemCode, False, "")

            End Select
        Catch ex As Exception
            Err.Raise(Err.Number, "Error !<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try

        'Extra hidden field for item codes:
        Try
            With hfITEM_CODE
                .ID = IDPrefix & "hfItemCode_" & ThisControlName & "_" & ThisItemCode.Replace(".", "")
                .Value = ThisItemCode
            End With
        Catch ex As Exception
            Err.Raise(Err.Number, "Error !<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try

        If ThisItemCode = "JOB_COMPONENT.NOBILL_FLAG" AndAlso oAgency.JobTemplateNonBillableJCCheck = True Then
            hl.Visible = False
        End If
        If ThisItemCode = "JOB_COMPONENT.TAX_FLAG" AndAlso oAgency.JobTemplateMarkedTaxable = False Then
            hl.Visible = False
        End If
        If ThisItemCode = "JOB_COMPONENT.TAX_CODE" AndAlso oAgency.JobTemplateMarkedTaxable = False Then
            hl.Visible = False
        End If
        'Create the table (row) and add the hyperlink (the "label" on the form) into them:

        Dim OnClickValue As String = ""
        Dim lbl As New System.Web.UI.WebControls.Label
        Dim ctrl As New System.Web.UI.Control
        Try
            OnClickValue = hl.Attributes.Item("onclick")
        Catch ex As Exception
            OnClickValue = ""
        End Try

        'If OnClickValue.IndexOf(".aspx") > -1 Then
        '    'ctrl = hl
        '    hl.CssClass = "JobTemplateLabel"
        'Else
        '    'lbl.Text = hl.Text
        '    'ctrl = lbl
        'End If

        With ThePanel.Controls
            .Add(MiscFN.NewLiteral(OpenSpacerTable))
            .Add(hfITEM_CODE)

            If ThisItemCode = "JOB_SPECIFICATIONS" OrElse ThisItemCode = "TRAFFIC_SCHEDULE" OrElse ThisItemCode = "JOB_VERSIONS" OrElse (ThisItemCode = "ESTIMATING" AndAlso IsClientPortal = False) Then
                .Add(imgbtn)
                .Add(hfLinkID)
            ElseIf (ThisItemCode = "JOB_COMPONENT.PRD_CONT_CODE" OrElse ThisItemCode = "JOB_LOG.CL_CODE") AndAlso IsClientPortal = False Then
                .Add(imgbtn)
                .Add(hfLinkID)
                .Add(MiscFN.NewLiteral(Spacer))
                .Add(hl)
            Else
                .Add(hl)
            End If
            .Add(MiscFN.NewLiteral(MiddleSpacerTable))
        End With

        'Add the actual controls into the rows and set properties:

        Dim LblTemp As New System.Web.UI.WebControls.Label 'change format to label instead of disabled control when in read-only

        Try
            With ThePanel.Controls
                Select Case ThisInputType
                    Case RowTypes.ValDescript, RowTypes.EvenSplit
                        'do read only check
                        If IsReadOnly = False Then
                            If IsRequiredField = True Then
                                If String.IsNullOrWhiteSpace(txtbxValue.Text) = True Then

                                    txtbxValue.CssClass = "required-missing"
                                    txtbxDescript.CssClass = "required-missing"

                                Else

                                    txtbxValue.CssClass = "RequiredInput"
                                    txtbxDescript.CssClass = "RequiredInput"

                                End If
                            End If
                            txtbxValue.Enabled = True
                            txtbxDescript.Enabled = True
                            .Add(txtbxValue)
                            .Add(MiscFN.NewLiteral("&nbsp;"))
                            .Add(txtbxDescript)
                        Else
                            LblTemp.Text = txtbxValue.Text & " - " & txtbxDescript.Text
                            .Add(LblTemp)
                        End If
                        ReturnControlID = txtbxValue.ID
                    Case RowTypes.AdNumber
                        If IsReadOnly = False Then
                            If IsRequiredField = True Then
                                If String.IsNullOrWhiteSpace(txtbxValue.Text) = True Then

                                    txtbxValue.CssClass = "required-missing"
                                    txtbxDescript.CssClass = "required-missing"

                                Else

                                    txtbxValue.CssClass = "RequiredInput"
                                    txtbxDescript.CssClass = "RequiredInput"

                                End If
                            End If
                            txtbxValue.Enabled = True
                            txtbxDescript.Enabled = True
                            .Add(txtbxValue)
                            .Add(MiscFN.NewLiteral("<br />"))
                            .Add(txtbxDescript)
                        Else
                            LblTemp.Text = txtbxValue.Text & "<br />" & txtbxDescript.Text
                            .Add(LblTemp)
                        End If
                        ReturnControlID = txtbxValue.ID
                    Case RowTypes.ValOnly ', RowTypes.MultiLine
                        'do read only check
                        If IsReadOnly = False Then
                            If IsRequiredField = True Then
                                If String.IsNullOrWhiteSpace(txtbxValue.Text) = True Then

                                    txtbxValue.CssClass = "required-missing"

                                Else

                                    txtbxValue.CssClass = "RequiredInput"

                                End If
                            End If
                            txtbxValue.Enabled = True
                            .Add(txtbxValue)
                        Else
                            If txtbxValue.Text <> "" Then
                                LblTemp.Text = txtbxValue.Text
                            Else
                                LblTemp.Text = "-"
                            End If
                            .Add(LblTemp)
                        End If
                        ReturnControlID = txtbxValue.ID
                        Try
                            If ThisItemCode = "JOB_COMPONENT.JOB_COMP_BUDGET_AM" Then
                                If IsNumeric(txtbxValue.Text) = True Then
                                    txtbxValue.Text = FormatNumber(txtbxValue.Text, 2, TriState.True, TriState.False, TriState.True)
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    Case RowTypes.MultiLine
                        If ThisItemCode = "JOB_COMPONENT.JOB_LAYOUT_SPC_EXP" OrElse ThisItemCode = "JOB_LOG.JOB_BILL_COMMENT" Then
                            If IsReadOnly = False Then
                                If IsRequiredField = True Then
                                    If String.IsNullOrWhiteSpace(txtbxValue.Text) = True Then

                                        txtbxValue.CssClass = "required-missing"

                                    Else

                                        txtbxValue.CssClass = "RequiredInput"

                                    End If
                                End If
                                txtbxValue.Enabled = True
                                .Add(txtbxValue)
                            Else
                                If txtbxValue.Text <> "" Then
                                    LblTemp.Text = txtbxValue.Text
                                Else
                                    LblTemp.Text = "-"
                                End If
                                .Add(LblTemp)
                            End If
                            ReturnControlID = txtbxValue.ID
                        End If
                        If ThisItemCode = "JOB_LOG.JOB_COMMENTS" OrElse ThisItemCode = "JOB_COMPONENT.JOB_COMP_COMMENTS" OrElse
                            ThisItemCode = "JOB_COMPONENT.CREATIVE_INSTR" OrElse ThisItemCode = "JOB_COMPONENT.JOB_DEL_INSTRUCT" Then

                            If IsReadOnly = False Then

                                If IsRequiredField = True Then

                                    If String.IsNullOrWhiteSpace(RadEditor.Content) = True Then

                                        RadEditor.CssClass = "required-missing-editor"

                                    Else

                                        RadEditor.CssClass = "RequiredInput"

                                    End If

                                End If

                                RadEditor.Enabled = True
                                RadEditor.Height = New Unit(300, UnitType.Pixel)
                                RadEditor.ToolsFile = "~/RadEditorToolbars.xml"
                                'RadEditor.NewLineBr = True
                                RadEditor.NewLineMode = EditorNewLineModes.Br
                                RadEditor.OnClientLoad = "RadEditorOnClientLoad"
                                RadEditor.OnClientCommandExecuted = "RadEditorOnClientCommandExecuted"
                                RadEditor.ContentAreaCssFile = "~/CSS/RadEditorContentArea.css"
                                RadEditor.Width = New Unit(700, UnitType.Pixel)
                                RadEditor.EditModes = EditModes.Design
                                RadEditor.ContentAreaMode = EditorContentAreaMode.Div
                                RadEditor.StripFormattingOptions = EditorStripFormattingOptions.MSWord

                                .Add(RadEditor)
                                .Add(imgbtn)
                                .Add(hfLinkID)

                                ReturnControlID = RadEditor.ID

                            Else

                                LblTemp.Text = "-"

                                If String.IsNullOrWhiteSpace(RadEditor.GetHtml(Nothing)) = False Then

                                    LblTemp.Text = RadEditor.GetHtml(Nothing)

                                Else

                                    If String.IsNullOrWhiteSpace(RadEditor.Text) = False Then

                                        LblTemp.Text = RadEditor.Text

                                    End If

                                End If

                                .Add(LblTemp)

                                ReturnControlID = LblTemp.ID

                            End If

                            ''Deeplinks here!
                            'If _Deep.TextHasInternalLinks(RadEditor.Content) = True Then

                            '    Dim InternalLinksPlaceholder As New WebControls.PlaceHolder

                            '    If _Deep.UrlToInternalLink(RadEditor.Content, InternalLinksPlaceholder, False) = True Then

                            '        .Add(MiscFN.NewLiteral("<div style=""margin: 6px;"">"))
                            '        .Add(InternalLinksPlaceholder)
                            '        .Add(MiscFN.NewLiteral("</div>"))

                            '    End If

                            'End If

                        End If
                    Case RowTypes.DropDownList
                        If IsReadOnly = False Then
                            If IsRequiredField = True Then
                                AdvantageFramework.Web.Presentation.SetRadComboBoxRequired(dropValue)
                            End If
                            dropValue.Enabled = True
                            .Add(dropValue)
                        Else
                            LblTemp.Text = dropValue.SelectedItem.Text
                            .Add(LblTemp)
                        End If
                        ReturnControlID = dropValue.ID
                    Case RowTypes.TextBoxCalendar
                        'do read only check
                        If IsReadOnly = False Then
                            If IsRequiredField = True Then
                                If RadDatePickerJob.SelectedDate Is Nothing Then

                                    'RadDatePickerJob.DateInput.BackColor = ColorTranslator.FromHtml("#F44336")
                                    'RadDatePickerJob.DateInput.ForeColor = Color.White
                                    RadDatePickerJob.DateInput.CssClass = "required-missing"

                                Else

                                    RadDatePickerJob.DateInput.CssClass = "RequiredInput"

                                End If
                            End If
                            RadDatePickerJob.Enabled = True
                            .Add(RadDatePickerJob)
                            'txtbxValue.Enabled = True
                            'imgbtnValue.Enabled = True
                            '.Ad(txtbxValue)
                            '.Add(imgbtnValue)
                        Else
                            If Not RadDatePickerJob.SelectedDate Is Nothing Then
                                LblTemp.Text = RadDatePickerJob.SelectedDate.ToString
                            Else
                                LblTemp.Text = "-"
                            End If
                            'If txtbxValue.Text <> "" Then
                            '    LblTemp.Text = txtbxValue.Text
                            'Else
                            '    LblTemp.Text = "-"
                            'End If
                            .Add(LblTemp)
                        End If
                        'ReturnControlID = txtbxValue.ID
                        ReturnControlID = RadDatePickerJob.ID
                    Case RowTypes.YesNoRBL, RowTypes.RadioButtonList
                        If IsReadOnly = False Then
                            If IsRequiredField = True Then
                                If rblValue.SelectedItem Is Nothing OrElse rblValue.SelectedIndex = -1 Then

                                    rblValue.CssClass = "required-missing"

                                Else

                                    rblValue.CssClass = "RequiredInput"

                                End If
                            End If
                            rblValue.Enabled = True
                            .Add(rblValue)
                        Else
                            If rblValue.SelectedIndex > -1 Then
                                LblTemp.Text = rblValue.SelectedItem.Text
                            Else
                                LblTemp.Text = "-"
                            End If
                            .Add(LblTemp)
                        End If
                        ReturnControlID = rblValue.ID

                    Case RowTypes.Label
                        Try
                            If ThisItemCode = "TOTAL_JOB_BUDGET" Then
                                If IsNumeric(lblValue.Text) = True Then
                                    If LoGlo.UserCultureGet() <> "en-US" Then
                                        lblValue.Text = FormatNumber(lblValue.Text, 2, TriState.True, TriState.False, TriState.True)
                                    Else
                                        lblValue.Text = "$ " & FormatNumber(lblValue.Text, 2, TriState.True, TriState.False, TriState.True)
                                    End If
                                End If
                            End If
                        Catch ex As Exception
                        End Try

                        lblValue.ToolTip = lblValue.Text.Replace("&nbsp;", " ")
                        .Add(lblValue)

                        If ThisItemCode = "ESTIMATE" Then
                            Dim dt As DataTable
                            dt = Me.GetEstimateApproval(Me.jobnum, Me.jobcompnum)

                            If dt.Rows.Count > 0 Then

                                Dim txt As String = "Approved by " & dt.Rows(0)("EST_APPR_BY") & " on " & dt.Rows(0)("EST_APPR_DATE")

                                .Add(MiscFN.NewLiteral("<div><div style=""display:inline-block;width:110px;"">"))

                                lblValue.ToolTip = txt.Replace("&nbsp;", " ")
                                .Add(lblValue)

                                .Add(MiscFN.NewLiteral("</div><div style=""display:inline-block;"">"))

                                .Add(MiscFN.NewLiteral("<div class=""icon-background standard-green"">"))

                                Dim img As New System.Web.UI.WebControls.Image
                                img.ImageUrl = "~/Images/Icons/White/256/check.png"
                                img.ToolTip = txt.Replace("&nbsp;", " ")
                                img.CssClass = "icon-image"
                                .Add(img)

                                .Add(MiscFN.NewLiteral("</div></div>"))

                            Else

                                .Add(lblValue)

                            End If

                        Else

                            .Add(lblValue)

                        End If

                    Case RowTypes.LinkButton
                        lbValue.Text = lbValue.Text.Replace("_SLASH_", "/")
                        If (ThisItemCode = "ESTIMATING" AndAlso IsClientPortal = True) Then

                        Else
                            .Add(lbValue)
                        End If
                        If ThisItemCode = "JOB_SPECIFICATIONS" OrElse ThisItemCode = "TRAFFIC_SCHEDULE" OrElse ThisItemCode = "JOB_VERSIONS" OrElse (ThisItemCode = "ESTIMATING" AndAlso IsClientPortal = False) Then
                            .Add(hfLinkIDLb)
                        End If
                    Case RowTypes.RadioButton
                    Case RowTypes.ImageButton
                    Case RowTypes.ValEditableDesc
                        'do read only check
                        If IsReadOnly = False Then
                            If IsRequiredField = True Then
                                If String.IsNullOrWhiteSpace(txtbxValue.Text) = True Then

                                    txtbxValue.CssClass = "required-missing"
                                    txtbxDescript.CssClass = "required-missing"

                                Else

                                    txtbxValue.CssClass = "RequiredInput"
                                    txtbxDescript.CssClass = "RequiredInput"

                                End If
                            End If
                            txtbxValue.Enabled = True
                            txtbxDescript.Enabled = True
                            .Add(txtbxValue)
                            .Add(MiscFN.NewLiteral("&nbsp;"))
                            .Add(txtbxDescript)
                        Else
                            LblTemp.Text = txtbxValue.Text & " - " & txtbxDescript.Text
                            .Add(LblTemp)
                        End If
                        ReturnControlID = txtbxValue.ID & "/" & txtbxDescript.ID

                End Select

                'Create a red asterisk if it is required (when in edit mode):
                If IsRequiredField = True AndAlso IsReadOnly = False AndAlso (ThisInputType <> RowTypes.Label AndAlso ThisInputType <> RowTypes.LinkButton) AndAlso ReturnControlID.Contains("Blackplate") = False Then
                    .Add(MiscFN.NewLiteral(RowSpacer))
                    ' .Add(MiscFN.NewLiteral("<span class = ""CssRequired""></span><br />"))
                    ''add real validator?
                    Dim rfv As New RequiredFieldValidator
                    With rfv
                        .ControlToValidate = ReturnControlID
                        .ErrorMessage = Replace(ThisControlName, "_", "&nbsp;").Replace("SLASH&nbsp;", "") & " is required."
                        .SetFocusOnError = True
                        If InStr(ThisItemCode, "EMAIL_GR_CODE") > 0 OrElse InStr(ThisItemCode, "ALRT_NOTIFY_HDR_ID") > 0 OrElse InStr(ThisItemCode, "SERVICE_FEE_TYPE_ID") > 0 Then
                            .InitialValue = "[None]"
                        End If
                        .ForeColor = Color.Red
                    End With
                    .Add(MiscFN.NewLiteral(IndentSpacer))
                    .Add(rfv)
                Else
                    .Add(MiscFN.NewLiteral(RowSpacer))
                    .Add(MiscFN.NewLiteral(RowSpacer))
                End If
            End With
            If _JobRush = True AndAlso count = 0 Then

                Dim lab As New System.Web.UI.WebControls.Label
                With lab
                    .ID = "lblRush"
                    .Text = "RUSH"
                    .ForeColor = System.Drawing.Color.Red
                    .Font.Size = .Font.Size.XLarge
                    .Font.Bold = True
                End With

                ThePanel.Controls.Add(MiscFN.NewLiteral("</td><td align=""left"" width=""100"">"))
                ThePanel.Controls.Add(lab)
                count = 1

            End If
            ThePanel.Controls.Add(MiscFN.NewLiteral(CloseSpacerTable))

            tabIndex += 1
            Return "ctl00_ContentPlaceHolderMain_" & ReturnControlID
        Catch ex As Exception
            Err.Raise(Err.Number, "Error creating form row!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Private Sub GetTaxDefault(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Function AddAsLabel(ByVal IDPrefix As String, ByVal ControlName As String, ByVal TheValue As String, Optional ByVal TheDescript As String = "", Optional ByVal WrapIt As Boolean = False) As System.Web.UI.WebControls.Label
        Dim lbl As System.Web.UI.WebControls.Label
        With lbl
            .ID = IDPrefix & "LblValue_" & ControlName
            If TheDescript = "" Then
                .Text = TheValue
            Else
                .Text = TheValue & " - " & TheDescript
            End If
            If WrapIt = True Then
                .Width = System.Web.UI.WebControls.Unit.Pixel(400)
            End If
        End With
    End Function

    Private Function SetLookupJS(ByVal LookupType As String, ByVal ItemCode As String) As String
        Try

            'If InStr(mCL_CODE, "-") > 0 Then
            '    Dim str() As String = mCL_CODE.Split("-")
            '    mCL_CODE = str(0).Trim.Replace("&nbsp;", "")
            'End If
            'If InStr(mDIV_CODE, "-") > 0 Then
            '    Dim str() As String = mDIV_CODE.Split("-")
            '    mDIV_CODE = str(0).Trim.Replace("&nbsp;", "")
            'End If
            'If InStr(mPRD_CODE, "-") > 0 Then
            '    Dim str() As String = mPRD_CODE.Split("-")
            '    mPRD_CODE = str(0).Trim.Replace("&nbsp;", "")
            'End If
            'If InStr(mSC_CODE, "-") > 0 Then
            '    Dim str() As String = mSC_CODE.Split("-")
            '    mSC_CODE = str(0).Trim.Replace("&nbsp;", "")
            'End If           

            Dim strJSPrefix As String = "OpenRadWindowLookup('Lookup_Quick.aspx?calledfrom=custom&control="
            Dim strJSSuffix As String = ");" ', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=580,height=425,scrollbars=no,resizable=no,menubar=no,maximazable=no');"
            Dim strJSSufficSetFocus As String = "return false;"
            Dim sbJS As StringBuilder = New StringBuilder
            With sbJS
                .Append(strJSPrefix)
                If ItemCode = "JOB_LOG.UDV1_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=JobUD1'")
                    .Append(strJSSuffix)
                    .Append(strJSSufficSetFocus)
                    Return sbJS.ToString
                ElseIf ItemCode = "JOB_LOG.UDV2_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=JobUD2'")
                    .Append(strJSSuffix)
                    .Append(strJSSufficSetFocus)
                    Return sbJS.ToString
                ElseIf ItemCode = "JOB_LOG.UDV3_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=JobUD3'")
                    .Append(strJSSuffix)
                    .Append(strJSSufficSetFocus)
                    Return sbJS.ToString
                ElseIf ItemCode = "JOB_LOG.UDV4_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=JobUD4'")
                    .Append(strJSSuffix)
                    .Append(strJSSufficSetFocus)
                    Return sbJS.ToString
                ElseIf ItemCode = "JOB_LOG.UDV5_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=JobUD5'")
                    .Append(strJSSuffix)
                    Return sbJS.ToString
                ElseIf ItemCode = "JOB_COMPONENT.UDV1_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=JCUD1'")
                    .Append(strJSSuffix)
                    .Append(strJSSufficSetFocus)
                    Return sbJS.ToString
                ElseIf ItemCode = "JOB_COMPONENT.UDV2_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=JCUD2'")
                    .Append(strJSSuffix)
                    .Append(strJSSufficSetFocus)
                    Return sbJS.ToString
                ElseIf ItemCode = "JOB_COMPONENT.UDV3_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=JCUD3'")
                    .Append(strJSSuffix)
                    .Append(strJSSufficSetFocus)
                    Return sbJS.ToString
                ElseIf ItemCode = "JOB_COMPONENT.UDV4_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=JCUD4'")
                    .Append(strJSSuffix)
                    .Append(strJSSufficSetFocus)
                    Return sbJS.ToString
                ElseIf ItemCode = "JOB_COMPONENT.UDV5_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=JCUD5'")
                    .Append(strJSSuffix)
                    .Append(strJSSufficSetFocus)
                    Return sbJS.ToString
                End If
                If ItemCode = "JOB_LOG.BILL_COOP_CODE" Then 'ok
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=coopbilling'")
                ElseIf ItemCode = "JOB_LOG.COMPLEX_CODE" Then 'ok
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=complexity'")
                ElseIf ItemCode = "JOB_LOG.PROMO_CODE" Then 'ok
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=promotion'")
                ElseIf ItemCode = "JOB_COMPONENT.DP_TM_CODE" Then 'pops ok but doesn't return value;probably due to slash in id
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=deptteam'")
                ElseIf ItemCode = "JOB_COMPONENT.JT_CODE" Then 'ok
                    If _CheckARJob = True Then
                        .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=jobtype&job=" & jobnum & "&sc=" & mSC_CODE & "'")
                    Else
                        .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=jobtype&job=" & jobnum & "&sc=' + $('#ctl00_ContentPlaceHolderMain_colpnl" & sectionSC.Replace(" ", "").Replace("/", "") & "_TxtValue_JOB_LOGSC_CODE').val()")
                    End If
                    '.Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=jobtype&job=" & jobnum & "&sc=' + $('#ctl00_ContentPlaceHolderMain_colpnlJobInformation0_TxtValue_JOB_LOGSC_CODE').val()")
                ElseIf ItemCode = "JOB_COMPONENT.AD_NBR" Then 'ok
                    Return "OpenRadWindow('Look Up Ad Number', 'LookUp_AdNumber.aspx?form=jt&cli=" & mCL_CODE & "&ctrl=ctl00_ContentPlaceHolderMain_" & LookupType & "');return false;"
                ElseIf ItemCode = "JOB_COMPONENT.MARKET_CODE" Then 'ok
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=market'")
                ElseIf ItemCode = "JOB_LOG.OFFICE_CODE" Then 'ok
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&fromform=jt&type=office'")
                ElseIf ItemCode = "JOB_COMPONENT.TAX_CODE" Then 'ok
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&fromform=jt&job=" & jobnum & "&jobcomp=" & jobcompnum & "&client=" & mCL_CODE & "&division=" & mDIV_CODE & "&product=" & mPRD_CODE & "&type=taxcodes'")
                ElseIf ItemCode = "JOB_COMPONENT.ACCT_NBR" Then 'ok
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=acctnum'")
                ElseIf ItemCode = "JOB_COMPONENT.FISCAL_PERIOD_CODE" Then 'ok
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=fiscalperiod'")
                ElseIf ItemCode = "JOB_COMPONENT.BLACKPLT_VER_DESC" Then 'ok
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=blackplt'")
                ElseIf ItemCode = "JOB_COMPONENT.BLACKPLT_VER2_DESC" Then 'ok
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=blackplt'")
                ElseIf ItemCode = "JOB_COMPONENT.EMP_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&client=" & mCL_CODE & "&division=" & mDIV_CODE & "&product=" & mPRD_CODE & "&type=accountexec'")
                ElseIf ItemCode = "JOB_COMPONENT.PRD_CONT_CODE" Then
                    '.Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=contact&client=" & mCL_CODE & "&division=" & mDIV_CODE & "&product=" & mPRD_CODE & "'")
                    Return "OpenRadWindowLookup('poplookup_contact.aspx?form=jobtemplate&control=ctl00_ContentPlaceHolderMain_" & LookupType & "&type=contacts&client=" & mCL_CODE & "&division=" & mDIV_CODE & "&product=" & mPRD_CODE & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=580,height=425,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;"
                ElseIf ItemCode = "JOB_LOG.CMP_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&client=" & mCL_CODE & "&division=" & mDIV_CODE & "&product=" & mPRD_CODE & "&type=campaign2'")
                ElseIf ItemCode = "JOB_LOG.FORMAT_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=salesclassformat&salesclass=" & mSC_CODE & "'")
                ElseIf ItemCode = "JOB_LOG.SC_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=salesclass'")
                ElseIf ItemCode = "JOB_LOG.CL_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=client&form=jtclient&sectiondiv=" & sectionDiv.Replace("/", "") & "&sectionprd=" & sectionPrd.Replace("/", "") & "'")
                ElseIf ItemCode = "JOB_LOG.DIV_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=division&form=jtdivision&division=&sectionprd=" & sectionPrd.Replace("/", "") & "&client=' + document.getElementById(""ctl00_ContentPlaceHolderMain_colpnl" & sectionCli.Replace(" ", "").Replace("/", "") & "_TxtValue_JOB_LOGCL_CODE"").value")
                ElseIf ItemCode = "JOB_LOG.PRD_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=product&form=jtproduct&product=&division=' + document.getElementById(""ctl00_ContentPlaceHolderMain_colpnl" & sectionDiv.Replace(" ", "").Replace("/", "") & "_TxtValue_JOB_LOGDIV_CODE"").value + '&client=' + document.getElementById(""ctl00_ContentPlaceHolderMain_colpnl" & sectionCli.Replace(" ", "").Replace("/", "") & "_TxtValue_JOB_LOGCL_CODE"").value")
                ElseIf ItemCode = "JOB_COMPONENT.JOB_PROCESS_CONTRL" Then
                    '.Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=jpc'")
                    Return "OpenRadWindow('Job Control','popContacts.aspx?From=jjpc&j=" & jobnum & "&jc=" & jobcompnum & "',1000,450);"
                Else
                    Return ""
                End If
                .Append(strJSSuffix)
                .Append(strJSSufficSetFocus)
            End With
            Return sbJS.ToString
        Catch ex As Exception
            Return "ShowMessage(""" & ex.Message.ToString.Replace("/", "_").Replace("'", "") & """);"
        End Try
    End Function

    Private Function SetImgBtnContactJS(ByVal LookupType As String, ByVal ItemCode As String) As String
        Try

            'If InStr(mCL_CODE, "-") > 0 Then
            '    Dim str() As String = mCL_CODE.Split("-")
            '    mCL_CODE = str(0).Trim.Replace("&nbsp;", "")
            'End If
            'If InStr(mDIV_CODE, "-") > 0 Then
            '    Dim str() As String = mDIV_CODE.Split("-")
            '    mDIV_CODE = str(0).Trim.Replace("&nbsp;", "")
            'End If
            'If InStr(mPRD_CODE, "-") > 0 Then
            '    Dim str() As String = mPRD_CODE.Split("-")
            '    mPRD_CODE = str(0).Trim.Replace("&nbsp;", "")
            'End If
            If ItemCode = "JOB_COMPONENT.PRD_CONT_CODE" Then
                Return "OpenRadWindow('Contacts','popContacts.aspx?From=jj&client=" & mCL_CODE & "&division=" & mDIV_CODE & "&product=" & mPRD_CODE & "','1200', '400');return false;"
            ElseIf ItemCode = "JOB_LOG.CL_CODE" Then
                Return "OpenRadWindow('Client Address Information','popContacts.aspx?From=jjcl&client=" & mCL_CODE & "&division=" & mDIV_CODE & "&product=" & mPRD_CODE & "','700', '400');return false;"
            Else
                Return ""
            End If
        Catch ex As Exception
            Return "ShowMessage(""" & ex.Message.ToString.Replace("/", "_").Replace("'", "") & """);"
        End Try
    End Function

    Public Sub ClearComponentFields(ByVal parent As System.Web.UI.Control)
        Try
            For Each ctrl As System.Web.UI.Control In parent.Controls
                Select Case ctrl.GetType.ToString
                    Case "System.Web.UI.WebControls.TextBox"
                        If InStr(ctrl.ClientID, "Value") > 0 AndAlso InStr(ctrl.ClientID, "JOBCOMPONENT") > 0 Then
                            Dim txt As System.Web.UI.WebControls.TextBox = CType(ctrl, TextBox)
                            txt.Text = ""
                        End If
                        If InStr(ctrl.ClientID, "Value") > 0 AndAlso InStr(ctrl.ClientID, "JOBCOMPONENT") > 0 AndAlso InStr(ctrl.ClientID, "Description") > 0 Then
                            Dim txt As System.Web.UI.WebControls.TextBox = CType(ctrl, TextBox)
                            txt.Text = ""
                            MiscFN.SetFocus(txt)
                        End If
                    Case "System.Web.UI.WebControls.RadioButtonList"
                        If InStr(ctrl.ClientID, "Value") > 0 AndAlso InStr(ctrl.ClientID, "JOBCOMPONENT") > 0 Then
                            Dim rbl As System.Web.UI.WebControls.RadioButtonList = CType(ctrl, RadioButtonList)
                            rbl.SelectedIndex = -1
                        End If
                    Case "Telerik.Web.UI.RadComboBox"
                        If InStr(ctrl.ClientID, "Value") > 0 AndAlso InStr(ctrl.ClientID, "JOBCOMPONENT") > 0 Then
                            Dim ddl As Telerik.Web.UI.RadComboBox = CType(ctrl, Telerik.Web.UI.RadComboBox)
                            ddl.SelectedIndex = -1
                        End If
                    Case "System.Web.UI.WebControls.ImageButton"
                    Case "System.Web.UI.WebControls.HyperLink"
                    Case "System.Web.UI.WebControls.RadioButton"
                End Select
                If ctrl.Controls.Count > 0 Then
                    ClearComponentFields(ctrl)
                End If
            Next
        Catch ex As Exception
            Err.Raise(Err.Number, "Error looping through controls!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Sub

    Public Function addleadingZeroesEstimate(ByVal item As String)
        Dim str() As String
        str = item.Split("-")
        Return str(0).PadLeft(6, "0") & " - " & str(1).PadLeft(2, "0")
    End Function

    Public Function CheckForSections(ByVal ds As DataSet)
        Dim row As DataRow
        If ds.Tables(0).Rows(0)("ITEM_TYPE").ToString() <> "S" Then
            row = ds.Tables(0).NewRow
            row.Item("ITEM_CODE") = "SECTION"
            row.Item("ITEM_TYPE") = "S"
            row.Item("SHORT_DESC") = ""
            row.Item("LONG_DESC") = ""
            row.Item("CONTROL_TYPE") = 0
            row.Item("SECTION_ORDER") = 0
            row.Item("ITEM_ORDER") = 0
            row.Item("TMPLT_REQ") = False
            row.Item("ADVAN_REQ") = False
            row.Item("AGENCY_REQ") = False
            row.Item("CLIENT_REQ") = False
            row.Item("FIELD_VALUE") = ""
            row.Item("FIELD_DESCRIPT") = ""
            ds.Tables(0).Rows.InsertAt(row, 0)
            Me.sectionindex = 0
        End If
        Return ds
    End Function


#End Region

#Region " Pop Alert Stuff "
    Private Sub PageLoadJS(ByVal ThePage As System.Web.UI.Page, ByVal strJS As String)
        Dim strTmpJS As String = String.Empty
        strTmpJS = "<script type=""text/javascript"">function init() { " & strJS & " } window.onload = init;</script>"
        If Not ThePage.IsStartupScriptRegistered("JSPageLoad" & Now.Millisecond) Then
            ThePage.RegisterStartupScript("JSAlert", strTmpJS)
        End If
    End Sub

    Public Function BuildAlertEmail(ByVal CurrEmailGroup As String, ByVal DIV_CODE As String, ByVal JOB_NUMBER As String, ByVal JOB_CMP_NBR As String, ByVal PRD_CODE As String,
        ByVal RECIPIENTS As String, ByVal CL_CODE As String, ByVal IsNew As Boolean) As String

        Dim sbQSVars As System.Text.StringBuilder = New System.Text.StringBuilder
        Try
            With sbQSVars
                .Append("?")
                .Append("EmailGroup=" & CurrEmailGroup)
                .Append("&DivCode=" & DIV_CODE)
                .Append("&JobCompNo=" & JOB_CMP_NBR)
                .Append("&JobNo=" & JOB_NUMBER)
                .Append("&ProdCode=" & PRD_CODE)
                .Append("&Recipients=" & RECIPIENTS)
                .Append("&ClientCode=" & CL_CODE)
                If IsNew = True Then
                    .Append("&New=1")
                Else
                    .Append("&New=0")
                End If
            End With
            Dim strJS_PopEmail As String = "window.open('popup_email_alert.aspx" & sbQSVars.ToString() & "','','screenX=150,left=150,screenY=150,top=150,width=310,height=575,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;"
        Catch ex As Exception
            Throw (ex)
        End Try

    End Function
#End Region

End Class

<Serializable()> Public Class Job_Specs

#Region " Vars "

    Private mConnString As String
    Private oSQL As SqlHelper
    Private TitleSpacer As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
    Private RowSpacer As String = "&nbsp;&nbsp;"
    Private IndentSpacer As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
    Private count As Integer = 0
    Private jobnum As Integer
    Private jobcompnum As Integer
    Private dsComments As DataSet
    Private client As String
    Private versionNum As Integer
    Private revisionNum As Integer
    Private dsText As DataSet

#End Region

#Region " DB Related "

    Public Sub New(ByVal ConnectionString As String)
        mConnString = ConnectionString
    End Sub

    Public Function GetJobSpecCategories(ByVal JobSpecType As String) As DataSet
        Try
            Dim arParams(1) As SqlParameter
            Dim dr As DataSet

            Dim paramJobSpecType As New SqlParameter("@JobSpecType", SqlDbType.VarChar)
            paramJobSpecType.Value = JobSpecType
            arParams(0) = paramJobSpecType

            dr = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_Categories", arParams)

            Return dr
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetjobsspecCategories!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Public Function GetJobSpecType(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer) As String
        Dim SessionKey As String = "GetJobSpecType" & JobNumber.ToString() & JobCompNumber.ToString()
        Dim ReturnString As String = ""
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim arParams(2) As SqlParameter

                Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
                paramJobNumber.Value = JobNumber
                arParams(0) = paramJobNumber

                Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
                paramJobCompNumber.Value = JobCompNumber
                arParams(1) = paramJobCompNumber

                ReturnString = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetSpecCode", arParams)

            Catch ex As Exception
            End Try

            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString
    End Function

    Public Function GetJobSpecQtyVendorTabs(ByVal JobSpecType As String) As SqlDataReader
        Try
            Dim arParams(1) As SqlParameter
            Dim dr As SqlDataReader

            Dim paramJobSpecType As New SqlParameter("@JobSpecType", SqlDbType.VarChar)
            paramJobSpecType.Value = JobSpecType
            arParams(0) = paramJobSpecType

            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetQtyVendorTab", arParams)

            Return dr
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetjobsspecQtyVendor!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
    Public Function GetJobSpecQtyVendorTabsDataSet(ByVal JobSpecType As String) As DataSet
        Try
            Dim arParams(1) As SqlParameter
            Dim dr As DataSet

            Dim paramJobSpecType As New SqlParameter("@JobSpecType", SqlDbType.VarChar)
            paramJobSpecType.Value = JobSpecType
            arParams(0) = paramJobSpecType

            dr = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetQtyVendorTab", arParams)

            Return dr
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetjobsspecQtyVendor!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
    Public Function GetJobSpecVersions(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetVersions", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cJobs Routine:GetVersions", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetJobSpecRevisions(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer, ByVal version As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramVersion As New SqlParameter("@Version", SqlDbType.Int)
        paramVersion.Value = version
        arParams(2) = paramVersion

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetRevisions", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cJobs Routine:GetRevisions", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetJobSpecData(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer, ByVal Version As Integer, ByVal Revision As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramVersion As New SqlParameter("@Version", SqlDbType.Int)
        paramVersion.Value = Version
        arParams(2) = paramVersion

        Dim paramRevision As New SqlParameter("@Revision", SqlDbType.Int)
        paramRevision.Value = Revision
        arParams(3) = paramRevision

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetJobSpecsData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cJobs Routine:GetJobspecdata", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetJobSpecDataSet(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer, ByVal Version As Integer, ByVal Revision As Integer) As DataSet
        Dim ds As DataSet
        Dim arParams(4) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramVersion As New SqlParameter("@Version", SqlDbType.Int)
        paramVersion.Value = Version
        arParams(2) = paramVersion

        Dim paramRevision As New SqlParameter("@Revision", SqlDbType.Int)
        paramRevision.Value = Revision
        arParams(3) = paramRevision


        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetJobSpecsData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cJobs Routine:GetJobspecdata", Err.Description)
        End Try

        Return ds
    End Function
    Public Function GetJobSpecsDataSet(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer, ByVal Version As Integer, ByVal Revision As Integer) As DataSet
        Dim ds As DataSet
        Dim arParams(4) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramVersion As New SqlParameter("@VERSION", SqlDbType.Int)
        paramVersion.Value = Version
        arParams(2) = paramVersion

        Dim paramRevision As New SqlParameter("@REVISION", SqlDbType.Int)
        paramRevision.Value = Revision
        arParams(3) = paramRevision

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetJobSpecs_ByJobandComp", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cJobs Routine:GetJobspecdataset", Err.Description)
        End Try

        Return ds
    End Function

    Public Function GetJobSpecsDSbyJobComp(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer) As DataSet
        Dim ds As DataSet
        Dim arParams(4) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_GetJobSpecs_ByJobandComp", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cJobs Routine:GetJobspecdataset", Err.Description)
        End Try

        Return ds
    End Function

    Public Function GetJobSpecsDataSetTextFields(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer, ByVal Version As Integer, ByVal Revision As Integer) As DataSet
        Dim ds As DataSet
        Dim arParams(4) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramVersion As New SqlParameter("@VERSION", SqlDbType.Int)
        paramVersion.Value = Version
        arParams(2) = paramVersion

        Dim paramRevision As New SqlParameter("@REVISION", SqlDbType.Int)
        paramRevision.Value = Revision
        arParams(3) = paramRevision

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetJobSpecsTextFields_ByJobandComp", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cJobs Routine:GetJobspecdataset", Err.Description)
        End Try

        Return ds
    End Function
    Public Function GetJobSpecsQtyData(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer, ByVal Version As Integer, ByVal Revision As Integer) As DataTable
        Dim dt As DataTable
        Dim arParams(4) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramVersion As New SqlParameter("@Version", SqlDbType.Int)
        paramVersion.Value = Version
        arParams(2) = paramVersion

        Dim paramRevision As New SqlParameter("@Revision", SqlDbType.Int)
        paramRevision.Value = Revision
        arParams(3) = paramRevision

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetJobSpecsQtyData", "table", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cJobs Routine:GetJobspecQtydata", Err.Description)
        End Try

        Return dt
    End Function
    Public Function GetJobSpecsQtyDataRows(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer, ByVal Version As Integer, ByVal Revision As Integer) As DataTable
        Dim dt As DataTable
        Dim arParams(4) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramVersion As New SqlParameter("@Version", SqlDbType.Int)
        paramVersion.Value = Version
        arParams(2) = paramVersion

        Dim paramRevision As New SqlParameter("@Revision", SqlDbType.Int)
        paramRevision.Value = Revision
        arParams(3) = paramRevision

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetJobSpecsQtyDataRows", "table", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cJobs Routine:GetJobspecQtydata", Err.Description)
        End Try

        Return dt
    End Function
    Public Function GetJobSpecsQtyDataWithEst(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer, ByVal Version As Integer, ByVal Revision As Integer) As DataTable
        Dim dt As DataTable
        Dim arParams(4) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramVersion As New SqlParameter("@Version", SqlDbType.Int)
        paramVersion.Value = Version
        arParams(2) = paramVersion

        Dim paramRevision As New SqlParameter("@Revision", SqlDbType.Int)
        paramRevision.Value = Revision
        arParams(3) = paramRevision

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetJobSpecsQtyDataRowsWithEst", "table", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cJobs Routine:GetJobspecQtydataWithEst", Err.Description)
        End Try

        Return dt
    End Function
    Public Function GetJobSpecsVendorData(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer, ByVal vendortab As Integer) As DataTable
        Dim dt As DataTable
        Dim arParams(3) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramVendorTab As New SqlParameter("@VendorTab", SqlDbType.Int)
        paramVendorTab.Value = vendortab
        arParams(2) = paramVendorTab

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetJobSpecsVendorData", "table", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cJobs Routine:GetJobspecQtydata", Err.Description)
        End Try

        Return dt
    End Function
    Public Function GetJobSpecsVendorDataBySpec(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer, ByVal vendortab As Integer, ByVal specid As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramVendorTab As New SqlParameter("@VendorTab", SqlDbType.Int)
        paramVendorTab.Value = vendortab
        arParams(2) = paramVendorTab

        Dim paramSpecID As New SqlParameter("@SpecID", SqlDbType.Int)
        paramSpecID.Value = specid
        arParams(3) = paramSpecID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetJobSpecsVendorDataBySpec", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cJobs Routine:GetJobspecQtydatabyspec", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetAlertRequirements(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal Client As String, ByVal Division As String, ByVal Product As String) As DataTable
        Try
            Dim arParams(5) As SqlParameter

            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim paramClient As New SqlParameter("@Client", SqlDbType.VarChar)
            paramClient.Value = Client
            arParams(2) = paramClient
            Dim paramDivision As New SqlParameter("@Division", SqlDbType.VarChar)
            paramDivision.Value = Division
            arParams(3) = paramDivision
            Dim paramProduct As New SqlParameter("@Product", SqlDbType.VarChar)
            paramProduct.Value = Product
            arParams(4) = paramProduct

            Dim dt As New DataTable
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetAlertRequirements_ByJobAndComp", "dtAlertReqs", arParams)
            Return dt
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetAlertRequirements!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
    Public Function GetJobSpecFieldDesc(ByVal FieldName As String, ByVal JobSpecType As String) As String
        Try
            Dim arParams(2) As SqlParameter
            Dim desc As String

            Dim paramFieldName As New SqlParameter("@FieldName", SqlDbType.VarChar)
            paramFieldName.Value = FieldName
            arParams(0) = paramFieldName

            Dim paramJobSpecType As New SqlParameter("@JobSpecType", SqlDbType.VarChar)
            paramJobSpecType.Value = JobSpecType
            arParams(1) = paramJobSpecType

            desc = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetSpecFieldDesc", arParams)

            Return desc
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetjobspecFieldDesc!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
    Public Function GetJobSpecMaxRevision(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer, ByVal version As Integer) As Integer
        Try
            Dim max As Integer
            Dim arParams(3) As SqlParameter

            Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
            paramJobNumber.Value = JobNumber
            arParams(0) = paramJobNumber

            Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNumber
            arParams(1) = paramJobCompNumber

            Dim paramVersion As New SqlParameter("@Version", SqlDbType.Int)
            paramVersion.Value = version
            arParams(2) = paramVersion

            max = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetRevisionsMax", arParams)

            Return max
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetjobspecRevMax!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
    Public Function GetJobSpecMaxVersion(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer) As Integer
        Try
            Dim max As Integer
            Dim arParams(2) As SqlParameter

            Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
            paramJobNumber.Value = JobNumber
            arParams(0) = paramJobNumber

            Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNumber
            arParams(1) = paramJobCompNumber

            max = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetVersionsMax", arParams)

            Return max
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetjobspecVerMax!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
    Public Function AddJobSpecCopy(ByVal JobNumber As Integer,
                                   ByVal JobCompNumber As Integer,
                                   ByVal Version As Integer,
                                   ByVal Revision As Integer,
                                   ByVal RevCopy As Integer,
                                   ByVal NewRevision As Integer,
                                   ByVal VerCopy As Integer,
                                   ByVal NewVersion As Integer,
                                   ByVal VerNew As Integer,
                                   ByVal Reason As String,
                                   ByVal AuthorizedBy As String,
                                   ByVal UserID As String) As Boolean

        Dim jobspeccopy As Boolean = True
        Dim arParams(12) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramVersion As New SqlParameter("@Version", SqlDbType.Int)
        paramVersion.Value = Version
        arParams(2) = paramVersion

        Dim paramRevision As New SqlParameter("@Revision", SqlDbType.Int)
        paramRevision.Value = Revision
        arParams(3) = paramRevision

        Dim paramRevCopy As New SqlParameter("@RevCopy", SqlDbType.Bit)
        paramRevCopy.Value = RevCopy
        arParams(4) = paramRevCopy

        Dim paramNewRevision As New SqlParameter("@NewRevision", SqlDbType.Int)
        paramNewRevision.Value = NewRevision
        arParams(5) = paramNewRevision

        Dim paramVerCopy As New SqlParameter("@VerCopy", SqlDbType.Bit)
        paramVerCopy.Value = VerCopy
        arParams(6) = paramVerCopy

        Dim paramNewVersion As New SqlParameter("@NewVersion", SqlDbType.Int)
        paramNewVersion.Value = NewVersion
        arParams(7) = paramNewVersion

        Dim paramVerNew As New SqlParameter("@VerNew", SqlDbType.Bit)
        paramVerNew.Value = VerNew
        arParams(8) = paramVerNew

        Dim paramReason As New SqlParameter("@Reason", SqlDbType.VarChar)
        paramReason.Value = Reason
        arParams(9) = paramReason

        Dim paramAuthorizedBy As New SqlParameter("@AuthorizedBy", SqlDbType.VarChar)
        paramAuthorizedBy.Value = AuthorizedBy
        arParams(10) = paramAuthorizedBy

        Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        paramUserID.Value = UserID
        arParams(11) = paramUserID

        Dim paramDate As New SqlParameter("@Date", SqlDbType.SmallDateTime)
        paramDate.Value = Date.Now
        arParams(12) = paramDate

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_Copy", arParams)
        Catch ex As Exception
            'Err.Raise(Err.Number, "Class:cTaskCal Routine:CPUserNew", Err.Description)
            jobspeccopy = False
        End Try

        If jobspeccopy = False Then
            Return False
        End If

        Return True
    End Function
    Public Function AddJobSpecCopyQty(ByVal JobNumberQty As Integer,
                                   ByVal JobCompNumberQty As Integer,
                                   ByVal VersionQty As Integer,
                                   ByVal RevisionQty As Integer,
                                   ByVal SeqNbrQty As Integer,
                                   ByVal JobQty As Integer,
                                   ByVal RevCopy As Integer,
                                   ByVal NewRevision As Integer,
                                   ByVal VerCopy As Integer,
                                   ByVal NewVersion As Integer,
                                   ByVal VerNew As Integer) As Boolean

        Dim jobspeccopy As Boolean = True
        Dim arParams(12) As SqlParameter

        Dim paramJobNumberQty As New SqlParameter("@JOB_NUMBER_QTY", SqlDbType.Int)
        paramJobNumberQty.Value = JobNumberQty
        arParams(0) = paramJobNumberQty

        Dim paramJobCompNumberQty As New SqlParameter("@JOB_COMPONENT_NBR_QTY", SqlDbType.SmallInt)
        paramJobCompNumberQty.Value = JobCompNumberQty
        arParams(1) = paramJobCompNumberQty

        Dim paramVersionQty As New SqlParameter("@SPEC_VER_QTY", SqlDbType.Int)
        paramVersionQty.Value = VersionQty
        arParams(2) = paramVersionQty

        Dim paramRevisionQty As New SqlParameter("@SPEC_REV_QTY", SqlDbType.Int)
        paramRevisionQty.Value = RevisionQty
        arParams(4) = paramRevisionQty

        Dim paramSeqNbrQty As New SqlParameter("@SEQ_NBR_QTY", SqlDbType.Int)
        paramSeqNbrQty.Value = SeqNbrQty
        arParams(5) = paramSeqNbrQty

        Dim paramJobQty As New SqlParameter("@JOB_QTY_QTY", SqlDbType.Int)
        paramJobQty.Value = JobQty
        arParams(6) = paramJobQty

        Dim paramRevCopy As New SqlParameter("@RevCopy", SqlDbType.Bit)
        paramRevCopy.Value = RevCopy
        arParams(7) = paramRevCopy

        Dim paramNewRevision As New SqlParameter("@NewRevision", SqlDbType.Int)
        paramNewRevision.Value = NewRevision
        arParams(8) = paramNewRevision

        Dim paramVerCopy As New SqlParameter("@VerCopy", SqlDbType.Bit)
        paramVerCopy.Value = VerCopy
        arParams(9) = paramVerCopy

        Dim paramNewVersion As New SqlParameter("@NewVersion", SqlDbType.Int)
        paramNewVersion.Value = NewVersion
        arParams(10) = paramNewVersion

        Dim paramVerNew As New SqlParameter("@VerNew", SqlDbType.Bit)
        paramVerNew.Value = VerNew
        arParams(11) = paramVerNew

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_CopyQty", arParams)
        Catch ex As Exception
            'Err.Raise(Err.Number, "Class:cTaskCal Routine:CPUserNew", Err.Description)
            jobspeccopy = False
        End Try

        If jobspeccopy = False Then
            Return False
        End If

        Return True
    End Function
    Public Function DeleteJobSpec(ByVal JobNumber As Integer,
                                   ByVal JobCompNumber As Integer,
                                   ByVal Version As Integer,
                                   ByVal Revision As Integer,
                                   ByVal Quantity As Integer,
                                   ByVal VersionDelete As Integer,
                                   ByVal RevisionDelete As Integer) As Boolean

        Dim jobspecdelete As Boolean = True
        Dim arParams(7) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramVersion As New SqlParameter("@Version", SqlDbType.Int)
        paramVersion.Value = Version
        arParams(2) = paramVersion

        Dim paramRevision As New SqlParameter("@Revision", SqlDbType.Int)
        paramRevision.Value = Revision
        arParams(3) = paramRevision

        Dim paramQuantity As New SqlParameter("@Quantity", SqlDbType.Bit)
        paramQuantity.Value = Quantity
        arParams(4) = paramQuantity

        Dim paramVersionDelete As New SqlParameter("@VersionDelete", SqlDbType.Bit)
        paramVersionDelete.Value = VersionDelete
        arParams(5) = paramVersionDelete

        Dim paramRevisionDelete As New SqlParameter("@RevisionDelete", SqlDbType.Bit)
        paramRevisionDelete.Value = RevisionDelete
        arParams(6) = paramRevisionDelete

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_Delete", arParams)
        Catch ex As Exception
            'Err.Raise(Err.Number, "Class:cTaskCal Routine:CPUserNew", Err.Description)
            jobspecdelete = False
        End Try

        If jobspecdelete = False Then
            Return False
        End If

        Return True
    End Function
    Public Function AddJobSpecNewRowVendorPub(ByVal JobNumber As Integer,
                                   ByVal JobCompNumber As Integer,
                                   ByVal SpecID As Integer,
                                   ByVal Vendor As String,
                                   ByVal BleedSize As String,
                                   ByVal CloseDate As String,
                                   ByVal Color As String,
                                   ByVal ExtDate As String,
                                   ByVal LiveArea As String,
                                   ByVal RunDate As String,
                                   ByVal Screen As String,
                                   ByVal TrimSize As String,
                                   ByVal Density As String,
                                   ByVal Film As String,
                                   ByVal Shipping As String,
                                   ByVal Special As String,
                                   ByVal Status As String,
                                   ByVal Region As String,
                                   ByVal ADSize As String) As Boolean

        Dim jobnewrow As Boolean = True
        Dim arParams(18) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT", SqlDbType.SmallInt)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramSpecID As New SqlParameter("@SPEC_ID", SqlDbType.SmallInt)
        paramSpecID.Value = SpecID
        arParams(2) = paramSpecID

        Dim paramVendor As New SqlParameter("@VN_CODE", SqlDbType.VarChar)
        paramVendor.Value = Vendor
        arParams(3) = paramVendor

        Dim paramBleedSize As New SqlParameter("@JOB_PUB_BLEED_SIZE", SqlDbType.VarChar)
        paramBleedSize.Value = BleedSize
        arParams(4) = paramBleedSize

        Dim paramCloseDate As New SqlParameter("@JOB_PUB_CLOSE_DATE", SqlDbType.SmallDateTime)
        If CloseDate <> "" Then
            paramCloseDate.Value = CDate(CloseDate)
        Else
            paramCloseDate.Value = DBNull.Value
        End If
        arParams(5) = paramCloseDate

        Dim paramColor As New SqlParameter("@JOB_PUB_COLOR", SqlDbType.VarChar)
        paramColor.Value = Color
        arParams(6) = paramColor

        Dim paramExtDate As New SqlParameter("@JOB_PUB_EXT_DATE", SqlDbType.SmallDateTime)
        If ExtDate <> "" Then
            paramExtDate.Value = CDate(ExtDate)
        Else
            paramExtDate.Value = DBNull.Value
        End If
        arParams(7) = paramExtDate

        Dim paramLiveArea As New SqlParameter("@JOB_PUB_LIVE_AREA", SqlDbType.VarChar)
        paramLiveArea.Value = LiveArea
        arParams(8) = paramLiveArea

        Dim paramRunDate As New SqlParameter("@JOB_PUB_RUN_DATE", SqlDbType.SmallDateTime)
        If RunDate <> "" Then
            paramRunDate.Value = CDate(RunDate)
        Else
            paramRunDate.Value = DBNull.Value
        End If
        arParams(9) = paramRunDate

        Dim paramScreen As New SqlParameter("@JOB_PUB_SCREEN", SqlDbType.VarChar)
        paramScreen.Value = Screen
        arParams(10) = paramScreen

        Dim paramTrimSize As New SqlParameter("@JOB_PUB_TRIM_SIZE", SqlDbType.VarChar)
        paramTrimSize.Value = TrimSize
        arParams(11) = paramTrimSize

        Dim paramDensity As New SqlParameter("@JOB_PUB_DENSITY", SqlDbType.VarChar)
        paramDensity.Value = Density
        arParams(12) = paramDensity

        Dim paramFilm As New SqlParameter("@JOB_PUB_FILM", SqlDbType.VarChar)
        paramFilm.Value = Film
        arParams(13) = paramFilm

        Dim paramShipping As New SqlParameter("@JOB_PUB_SHIP_COMM", SqlDbType.Text)
        paramShipping.Value = Shipping
        arParams(14) = paramShipping

        Dim paramSpecial As New SqlParameter("@JOB_PUB_SPCL_INST", SqlDbType.Text)
        paramSpecial.Value = Special
        arParams(15) = paramSpecial

        Dim paramStatus As New SqlParameter("@STATUS_CODE", SqlDbType.VarChar)
        If Status <> "" Then
            paramStatus.Value = Status
        Else
            paramStatus.Value = DBNull.Value
        End If
        arParams(16) = paramStatus

        Dim paramRegion As New SqlParameter("@REGION_CODE", SqlDbType.VarChar)
        If Region <> "" Then
            paramRegion.Value = Region
        Else
            paramRegion.Value = DBNull.Value
        End If
        arParams(17) = paramRegion

        Dim paramADSize As New SqlParameter("@AD_SIZE", SqlDbType.VarChar)
        If ADSize <> "" Then
            paramADSize.Value = ADSize
        Else
            paramADSize.Value = DBNull.Value
        End If
        arParams(18) = paramADSize

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_AddNewRowVendorPub", arParams)
        Catch ex As Exception
            'Err.Raise(Err.Number, "Class:cTaskCal Routine:CPUserNew", Err.Description)
            jobnewrow = False
        End Try

        If jobnewrow = False Then
            Return False
        End If

        Return True
    End Function
    Public Function AddJobSpecNewRowVendorOut(ByVal JobNumber As Integer,
                                   ByVal JobCompNumber As Integer,
                                   ByVal SpecID As Integer,
                                   ByVal Vendor As String,
                                   ByVal Location As String,
                                   ByVal OverallSize As String,
                                   ByVal CopyArea As String,
                                   ByVal ADSize As String) As Boolean

        Dim jobnewrow As Boolean = True
        Dim arParams(8) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT", SqlDbType.SmallInt)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramSpecID As New SqlParameter("@SPEC_ID", SqlDbType.SmallInt)
        paramSpecID.Value = SpecID
        arParams(2) = paramSpecID

        Dim paramVendor As New SqlParameter("@VN_CODE", SqlDbType.VarChar)
        paramVendor.Value = Vendor
        arParams(3) = paramVendor

        Dim paramCopyArea As New SqlParameter("@JOB_OUT_COPY_AREA", SqlDbType.VarChar)
        paramCopyArea.Value = CopyArea
        arParams(4) = paramCopyArea

        Dim paramLocation As New SqlParameter("@JOB_OUT_LOCATION", SqlDbType.VarChar)
        paramLocation.Value = Location
        arParams(5) = paramLocation

        Dim paramOverallSize As New SqlParameter("@JOB_OUT_OVR_SIZE", SqlDbType.VarChar)
        paramOverallSize.Value = OverallSize
        arParams(6) = paramOverallSize

        Dim paramADSize As New SqlParameter("@AD_SIZE", SqlDbType.VarChar)
        paramADSize.Value = ADSize
        arParams(7) = paramADSize

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_AddNewRowVendorOut", arParams)
        Catch ex As Exception
            'Err.Raise(Err.Number, "Class:cTaskCal Routine:CPUserNew", Err.Description)
            jobnewrow = False
        End Try

        If jobnewrow = False Then
            Return False
        End If

        Return True
    End Function
    Public Function UpdateJobSpecNewRowVendorPub(ByVal JobNumber As Integer,
                                   ByVal JobCompNumber As Integer,
                                   ByVal SpecID As Integer,
                                   ByVal Vendor As String,
                                   ByVal BleedSize As String,
                                   ByVal CloseDate As String,
                                   ByVal Color As String,
                                   ByVal ExtDate As String,
                                   ByVal LiveArea As String,
                                   ByVal RunDate As String,
                                   ByVal Screen As String,
                                   ByVal TrimSize As String,
                                   ByVal Density As String,
                                   ByVal Film As String,
                                   ByVal Shipping As String,
                                   ByVal Special As String,
                                   ByVal Status As String,
                                   ByVal Region As String,
                                   ByVal ADSize As String) As Boolean

        Dim jobupdaterow As Boolean = True
        Dim arParams(18) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT", SqlDbType.SmallInt)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramSpecID As New SqlParameter("@SPEC_ID", SqlDbType.SmallInt)
        paramSpecID.Value = SpecID
        arParams(2) = paramSpecID

        Dim paramVendor As New SqlParameter("@VN_CODE", SqlDbType.VarChar)
        paramVendor.Value = Vendor
        arParams(3) = paramVendor

        Dim paramBleedSize As New SqlParameter("@JOB_PUB_BLEED_SIZE", SqlDbType.VarChar)
        paramBleedSize.Value = BleedSize
        arParams(4) = paramBleedSize

        Dim paramCloseDate As New SqlParameter("@JOB_PUB_CLOSE_DATE", SqlDbType.SmallDateTime)
        If CloseDate <> "" Then
            paramCloseDate.Value = CDate(CloseDate)
        Else
            paramCloseDate.Value = DBNull.Value
        End If
        arParams(5) = paramCloseDate

        Dim paramColor As New SqlParameter("@JOB_PUB_COLOR", SqlDbType.VarChar)
        paramColor.Value = Color
        arParams(6) = paramColor

        Dim paramExtDate As New SqlParameter("@JOB_PUB_EXT_DATE", SqlDbType.SmallDateTime)
        If ExtDate <> "" Then
            paramExtDate.Value = CDate(ExtDate)
        Else
            paramExtDate.Value = DBNull.Value
        End If
        arParams(7) = paramExtDate

        Dim paramLiveArea As New SqlParameter("@JOB_PUB_LIVE_AREA", SqlDbType.VarChar)
        paramLiveArea.Value = LiveArea
        arParams(8) = paramLiveArea

        Dim paramRunDate As New SqlParameter("@JOB_PUB_RUN_DATE", SqlDbType.SmallDateTime)
        If RunDate <> "" Then
            paramRunDate.Value = CDate(RunDate)
        Else
            paramRunDate.Value = DBNull.Value
        End If
        arParams(9) = paramRunDate

        Dim paramScreen As New SqlParameter("@JOB_PUB_SCREEN", SqlDbType.VarChar)
        paramScreen.Value = Screen
        arParams(10) = paramScreen

        Dim paramTrimSize As New SqlParameter("@JOB_PUB_TRIM_SIZE", SqlDbType.VarChar)
        paramTrimSize.Value = TrimSize
        arParams(11) = paramTrimSize

        Dim paramDensity As New SqlParameter("@JOB_PUB_DENSITY", SqlDbType.VarChar)
        paramDensity.Value = Density
        arParams(12) = paramDensity

        Dim paramFilm As New SqlParameter("@JOB_PUB_FILM", SqlDbType.VarChar)
        paramFilm.Value = Film
        arParams(13) = paramFilm

        Dim paramShipping As New SqlParameter("@JOB_PUB_SHIP_COMM", SqlDbType.Text)
        paramShipping.Value = Shipping
        arParams(14) = paramShipping

        Dim paramSpecial As New SqlParameter("@JOB_PUB_SPCL_INST", SqlDbType.Text)
        paramSpecial.Value = Special
        arParams(15) = paramSpecial

        Dim paramStatus As New SqlParameter("@STATUS_CODE", SqlDbType.VarChar)
        If Status <> "" Then
            paramStatus.Value = Status
        Else
            paramStatus.Value = DBNull.Value
        End If
        arParams(16) = paramStatus

        Dim paramRegion As New SqlParameter("@REGION_CODE", SqlDbType.VarChar)
        If Region <> "" Then
            paramRegion.Value = Region
        Else
            paramRegion.Value = DBNull.Value
        End If
        arParams(17) = paramRegion

        Dim paramADSize As New SqlParameter("@AD_SIZE", SqlDbType.VarChar)
        If ADSize <> "" Then
            paramADSize.Value = ADSize
        Else
            paramADSize.Value = DBNull.Value
        End If
        arParams(18) = paramADSize

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_UpdateNewRowVendorPub", arParams)
        Catch ex As Exception
            'Err.Raise(Err.Number, "Class:cTaskCal Routine:CPUserNew", Err.Description)
            jobupdaterow = False
        End Try

        If jobupdaterow = False Then
            Return False
        End If

        Return True
    End Function
    Public Function UpdateJobSpecNewRowVendorOut(ByVal JobNumber As Integer,
                                   ByVal JobCompNumber As Integer,
                                   ByVal SpecID As Integer,
                                   ByVal Vendor As String,
                                   ByVal Location As String,
                                   ByVal OverallSize As String,
                                   ByVal CopyArea As String,
                                   ByVal ADSize As String) As Boolean

        Dim jobupdaterow As Boolean = True
        Dim arParams(8) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT", SqlDbType.SmallInt)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramSpecID As New SqlParameter("@SPEC_ID", SqlDbType.SmallInt)
        paramSpecID.Value = SpecID
        arParams(2) = paramSpecID

        Dim paramVendor As New SqlParameter("@VN_CODE", SqlDbType.VarChar)
        paramVendor.Value = Vendor
        arParams(3) = paramVendor

        Dim paramCopyArea As New SqlParameter("@JOB_OUT_COPY_AREA", SqlDbType.VarChar)
        paramCopyArea.Value = CopyArea
        arParams(4) = paramCopyArea

        Dim paramLocation As New SqlParameter("@JOB_OUT_LOCATION", SqlDbType.VarChar)
        paramLocation.Value = Location
        arParams(5) = paramLocation

        Dim paramOverallSize As New SqlParameter("@JOB_OUT_OVR_SIZE", SqlDbType.VarChar)
        paramOverallSize.Value = OverallSize
        arParams(6) = paramOverallSize

        Dim paramADSize As New SqlParameter("@AD_SIZE", SqlDbType.VarChar)
        paramADSize.Value = ADSize
        arParams(7) = paramADSize

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_UpdateNewRowVendorOut", arParams)
        Catch ex As Exception
            'Err.Raise(Err.Number, "Class:cTaskCal Routine:CPUserNew", Err.Description)
            jobupdaterow = False
        End Try

        If jobupdaterow = False Then
            Return False
        End If

        Return True
    End Function
    Public Function GetJobSpecMaxSpecID(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer, ByVal type As Integer) As Integer
        Try
            Dim max As Integer
            Dim arParams(3) As SqlParameter

            Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
            paramJobNumber.Value = JobNumber
            arParams(0) = paramJobNumber

            Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNumber
            arParams(1) = paramJobCompNumber

            Dim paramtype As New SqlParameter("@type", SqlDbType.Int)
            paramtype.Value = type
            arParams(2) = paramtype

            max = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetSpecIDMax", arParams)

            Return max
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetjobspecspecIDMax!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
    Public Function AddJobSpecNewRowQty(ByVal JobNumberQty As Integer,
                                       ByVal JobCompNumberQty As Integer,
                                       ByVal VersionQty As Integer,
                                       ByVal RevisionQty As Integer,
                                       ByVal SeqNbrQty As Integer,
                                       ByVal JobQty As Integer) As Boolean

        Dim jobnewrow As Boolean = True
        Dim arParams(6) As SqlParameter

        Dim paramJobNumberQty As New SqlParameter("@JOB_NUMBER_QTY", SqlDbType.Int)
        paramJobNumberQty.Value = JobNumberQty
        arParams(0) = paramJobNumberQty

        Dim paramJobCompNumberQty As New SqlParameter("@JOB_COMPONENT_NBR_QTY", SqlDbType.SmallInt)
        paramJobCompNumberQty.Value = JobCompNumberQty
        arParams(1) = paramJobCompNumberQty

        Dim paramVersionQty As New SqlParameter("@SPEC_VER_QTY", SqlDbType.Int)
        paramVersionQty.Value = VersionQty
        arParams(2) = paramVersionQty

        Dim paramRevisionQty As New SqlParameter("@SPEC_REV_QTY", SqlDbType.Int)
        paramRevisionQty.Value = RevisionQty
        arParams(4) = paramRevisionQty

        Dim paramSeqNbrQty As New SqlParameter("@SEQ_NBR_QTY", SqlDbType.Int)
        paramSeqNbrQty.Value = SeqNbrQty
        arParams(5) = paramSeqNbrQty

        Dim paramJobQty As New SqlParameter("@JOB_QTY_QTY", SqlDbType.Int)
        paramJobQty.Value = JobQty
        arParams(6) = paramJobQty

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_AddNewRowQty", arParams)
        Catch ex As Exception
            'Err.Raise(Err.Number, "Class:cTaskCal Routine:CPUserNew", Err.Description)
            jobnewrow = False
        End Try

        If jobnewrow = False Then
            Return False
        End If

        Return True
    End Function
    Public Function GetJobSpecMaxSeqNum(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer, ByVal version As Integer, ByVal revision As Integer) As Integer
        Try
            Dim max As Integer
            Dim arParams(4) As SqlParameter

            Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
            paramJobNumber.Value = JobNumber
            arParams(0) = paramJobNumber

            Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNumber
            arParams(1) = paramJobCompNumber

            Dim paramVersion As New SqlParameter("@Version", SqlDbType.Int)
            paramVersion.Value = version
            arParams(2) = paramVersion

            Dim paramRevision As New SqlParameter("@Revision", SqlDbType.Int)
            paramRevision.Value = revision
            arParams(3) = paramRevision


            max = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetSeqNumMax", arParams)

            Return max
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetjobspecseqnumMax!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
    Public Function DeleteJobSpecQtyVenRows(ByVal JobNumber As Integer,
                                           ByVal JobCompNumber As Integer,
                                           ByVal Version As Integer,
                                           ByVal Revision As Integer,
                                           ByVal Quantity As Integer,
                                           ByVal Vendor As Integer,
                                           ByVal SpecID As Integer,
                                           ByVal SeqNum As Integer) As Boolean

        Dim jobspecdelete As Boolean = True
        Dim arParams(8) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramVersion As New SqlParameter("@Version", SqlDbType.Int)
        paramVersion.Value = Version
        arParams(2) = paramVersion

        Dim paramRevision As New SqlParameter("@Revision", SqlDbType.Int)
        paramRevision.Value = Revision
        arParams(3) = paramRevision

        Dim paramQuantity As New SqlParameter("@Quantity", SqlDbType.Bit)
        paramQuantity.Value = Quantity
        arParams(4) = paramQuantity

        Dim paramVendor As New SqlParameter("@Vendor", SqlDbType.SmallInt)
        paramVendor.Value = Vendor
        arParams(5) = paramVendor

        Dim paramSpecID As New SqlParameter("@SpecID", SqlDbType.SmallInt)
        paramSpecID.Value = SpecID
        arParams(6) = paramSpecID

        Dim paramSeqNum As New SqlParameter("@SeqNum", SqlDbType.SmallInt)
        paramSeqNum.Value = SeqNum
        arParams(7) = paramSeqNum


        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_Delete_QtyVenRows", arParams)
        Catch ex As Exception
            'Err.Raise(Err.Number, "Class:cTaskCal Routine:CPUserNew", Err.Description)
            jobspecdelete = False
        End Try

        If jobspecdelete = False Then
            Return False
        End If

        Return True
    End Function
    Public Function DeleteJobSpecVenRows(ByVal JobNumber As Integer,
                                           ByVal JobCompNumber As Integer,
                                           ByVal Vendor As Integer) As Boolean

        Dim jobspecdelete As Boolean = True
        Dim arParams(3) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramVendor As New SqlParameter("@Vendor", SqlDbType.SmallInt)
        paramVendor.Value = Vendor
        arParams(2) = paramVendor

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_Delete_VenRows", arParams)
        Catch ex As Exception
            'Err.Raise(Err.Number, "Class:cTaskCal Routine:CPUserNew", Err.Description)
            jobspecdelete = False
        End Try

        If jobspecdelete = False Then
            Return False
        End If

        Return True
    End Function
    Public Function AddJobSpecNew(ByVal JobNumber As Integer,
                                   ByVal JobCompNumber As Integer,
                                   ByVal Version As Integer,
                                   ByVal Revision As Integer,
                                   ByVal UserID As String,
                                   ByVal SpecType As String) As Boolean

        Dim jobspecnew As Boolean = True
        Dim arParams(7) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramVersion As New SqlParameter("@Version", SqlDbType.Int)
        paramVersion.Value = Version
        arParams(2) = paramVersion

        Dim paramRevision As New SqlParameter("@Revision", SqlDbType.Int)
        paramRevision.Value = Revision
        arParams(3) = paramRevision

        Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        paramUserID.Value = UserID
        arParams(4) = paramUserID

        Dim paramDate As New SqlParameter("@Date", SqlDbType.SmallDateTime)
        paramDate.Value = Date.Now
        arParams(5) = paramDate

        Dim paramSpecType As New SqlParameter("@SpecType", SqlDbType.VarChar)
        paramSpecType.Value = SpecType
        arParams(6) = paramSpecType

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_NewJobSpec", arParams)
        Catch ex As Exception
            'Err.Raise(Err.Number, "Class:cTaskCal Routine:CPUserNew", Err.Description)
            jobspecnew = False
        End Try

        If jobspecnew = False Then
            Return False
        End If

        Return True
    End Function
    Public Function AddJobSpecApproval(ByVal JobNumber As Integer,
                                   ByVal JobCompNumber As Integer,
                                   ByVal Version As Integer,
                                   ByVal ApprovedBy As String,
                                   ByVal Comment As String,
                                   ByVal UserID As String,
                                   ByVal ApprovedDate As DateTime,
                                   Optional ByVal cpid As Integer = 0) As Boolean

        Dim jobapprove As Boolean = True
        Dim arParams(8) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramVersion As New SqlParameter("@APPR_SPEC_VER", SqlDbType.Int)
        paramVersion.Value = Version
        arParams(2) = paramVersion

        Dim paramApprovedBy As New SqlParameter("@SPEC_APPR_BY", SqlDbType.VarChar)
        paramApprovedBy.Value = ApprovedBy
        arParams(3) = paramApprovedBy

        Dim paramComment As New SqlParameter("@SPEC_APPR_COMMENT", SqlDbType.Text)
        paramComment.Value = Comment
        arParams(4) = paramComment

        Dim paramUserID As New SqlParameter("@SPEC_APPR_USER_ID", SqlDbType.VarChar)
        paramUserID.Value = UserID
        arParams(5) = paramUserID

        Dim paramApprovedDate As New SqlParameter("@SPEC_APPR_DATE", SqlDbType.SmallDateTime)
        paramApprovedDate.Value = ApprovedDate
        arParams(6) = paramApprovedDate

        Dim paramCPID As New SqlParameter("@CPID", SqlDbType.Int)
        paramCPID.Value = cpid
        arParams(7) = paramCPID

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_ApproveVersion", arParams)
        Catch ex As Exception
            'Err.Raise(Err.Number, "Class:cTaskCal Routine:CPUserNew", Err.Description)
            jobapprove = False
        End Try

        If jobapprove = False Then
            Return False
        End If

        Return True
    End Function
    Public Function GetJobSpecApprovalData(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer)
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetApprovalData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cJobs Routine:GetJobapprovaldata", Err.Description)
        End Try

        Return dr
    End Function
    Public Function DeleteJobSpecApprovalData(ByVal JobNumber As Integer,
                                           ByVal JobCompNumber As Integer) As Boolean

        Dim jobapprdelete As Boolean = True
        Dim arParams(3) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        'Dim paramVersion As New SqlParameter("@Version", SqlDbType.Int)
        'paramVersion.Value = Version
        'arParams(2) = paramVersion

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_DeleteApprovalData", arParams)
        Catch ex As Exception
            'Err.Raise(Err.Number, "Class:cTaskCal Routine:CPUserNew", Err.Description)
            jobapprdelete = False
        End Try

        If jobapprdelete = False Then
            Return False
        End If

        Return True
    End Function
    Public Function GetJobSpecCDP(ByVal JobNumber As Integer)
        Dim dr As SqlDataReader
        Dim arParams(1) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetCDP", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cJobs Routine:GetJobapprovaldata", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetJobSpecsTextField(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer, ByVal Version As Integer, ByVal Revision As Integer, ByVal text As String)
        Dim dt As DataTable
        Dim arParams(5) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramVersion As New SqlParameter("@Version", SqlDbType.Int)
        paramVersion.Value = Version
        arParams(2) = paramVersion

        Dim paramRevision As New SqlParameter("@Revision", SqlDbType.Int)
        paramRevision.Value = Revision
        arParams(3) = paramRevision

        Dim paramJobItemCode As New SqlParameter("@JobItemCode", SqlDbType.VarChar)
        paramJobItemCode.Value = text
        arParams(4) = paramJobItemCode

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetJobSpecsTextField", "table", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cJobs Routine:GetJobspecTextField", Err.Description)
        End Try

        Return dt
    End Function
    Public Function GetMediaType(ByVal VendorCode As String) As String
        Dim SessionKey As String = "GetMediaType" & VendorCode
        Dim ReturnString As String = ""
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim parameterVendorCode As New SqlParameter("@VendorCode", SqlDbType.VarChar, 50)
                parameterVendorCode.Value = VendorCode

                ReturnString = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetVendorType", parameterVendorCode)

            Catch
            End Try

            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString


    End Function
    Public Function GetJobSpecsMediaSpecsData(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer)
        Dim dt As DataTable
        Dim ds As DataSet
        Dim arParams(2) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetMediaSpecsData", "table", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cJobs Routine:GetJobspecMediaSpecsData", Err.Description)
        End Try

        Return dt
    End Function
    Public Function GetJobSpecsMediaSpecs(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer, ByVal vendorTab As Integer)
        Dim dt As DataTable
        Dim ds As DataSet
        Dim arParams(3) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim paramVendorTab As New SqlParameter("@VendorTab", SqlDbType.Int)
        paramVendorTab.Value = vendorTab
        arParams(2) = paramVendorTab

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetJobSpecsVendorData", "table", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cJobs Routine:GetJobspecQtydata", Err.Description)
        End Try

        Dim i As Integer
        Dim oTasks As New cTasks(Me.mConnString)
        ds = New DataSet
        For i = 0 To dt.Rows.Count - 1
            Try
                Dim str As String = dt.Rows(i)("Vendor").ToString
                Dim newTable As New DataTable("Vendor" & i)
                newTable = Me.GetMediaSpecs(JobNumber, JobCompNumber, dt.Rows(i)("Vendor").ToString(), Me.GetMediaType(dt.Rows(i)("Vendor").ToString()), i.ToString())
                ds.Tables.Add(newTable)
            Catch ex As Exception
                Err.Raise(Err.Number, "Class:cTasks Routine:GetTask", Err.Description)
            End Try

        Next
        Dim count As Integer = ds.Tables.Count
        Return ds
    End Function
    Public Function GetMediaSpecs(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer, ByVal VendorCode As String, ByVal MediaType As String, ByVal number As String) As DataTable
        Dim dr As SqlDataReader
        Dim dr2 As SqlDataReader
        Dim arParams(4) As SqlParameter
        Dim arParams2(2) As SqlParameter

        Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        paramJobNumber.Value = JobNumber
        arParams(0) = paramJobNumber

        Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
        paramJobCompNumber.Value = JobCompNumber
        arParams(1) = paramJobCompNumber

        Dim parameterVendorCode As New SqlParameter("@VendorCode", SqlDbType.VarChar, 50)
        parameterVendorCode.Value = VendorCode
        arParams(2) = parameterVendorCode

        Dim parameterMediaType As New SqlParameter("@Type", SqlDbType.VarChar, 50)
        parameterMediaType.Value = MediaType
        'arParams(3) = parameterMediaType

        arParams2(0) = parameterVendorCode
        arParams2(1) = parameterMediaType

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_ddMediaColumns", arParams2)
            dr2 = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetMediaSpecs", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cTasks Routine:GetTask", Err.Description)
        End Try

        Dim dt As DataTable
        Dim row As DataRow
        Dim i As Integer = 0
        Dim x As Integer = 1
        dt = New DataTable("Vendor" & number)
        dt.Columns.Add("Vendor")
        dt.Columns.Add("Vendor Name")
        dt.Columns.Add("Ad Size")
        dt.Columns.Add("Ad Size Description")
        If dr.HasRows Then
            Do While dr.Read
                Try
                    If dt.Columns.Contains(dr.GetString(1)) = False Then
                        dt.Columns.Add(dr.GetString(1))
                    Else
                        dt.Columns.Add(dr.GetString(1) & x.ToString())
                        x += 1
                    End If
                Catch
                    Err.Raise(Err.Number, "Class:cTasks Routine:GetMediaSpecs", Err.Description)
                End Try
            Loop
            row = dt.NewRow

        End If
        Dim j As Integer
        Dim ad As String = ""
        Do While dr2.Read
            Dim adsize As String = dr2.GetString(0)
            For j = 0 To dt.Columns.Count - 1
                Dim str1 As String = dr2.GetString(4)
                Dim str2 As String = dt.Columns(j).ColumnName
                If ad <> "" Then
                    If adsize = ad Then
                        If dr2.GetString(4) = dt.Columns(j).ColumnName Then
                            row.Item(j) = dr2.GetString(1)
                        End If
                        ad = adsize
                    Else
                        dt.Rows.Add(row)
                        row = dt.NewRow
                        row.Item("Vendor") = dr2.GetString(5)
                        row.Item("Vendor Name") = dr2.GetString(6)
                        row.Item("Ad Size") = dr2.GetString(0)
                        row.Item("Ad Size Description") = dr2.GetString(2)
                        If dr2.GetString(4) = dt.Columns(j).ColumnName Then
                            row.Item(j) = dr2.GetString(1)
                        End If
                        ad = adsize
                    End If
                Else
                    ad = adsize
                    If dr2.GetString(4) = dt.Columns(j).ColumnName Then
                        row.Item(j) = dr2.GetString(1)
                    End If
                    row.Item("Vendor") = dr2.GetString(5)
                    row.Item("Vendor Name") = dr2.GetString(6)
                    row.Item("Ad Size") = dr2.GetString(0)
                    row.Item("Ad Size Description") = dr2.GetString(2)
                End If
            Next
        Loop


        If dr.HasRows = True AndAlso dr2.HasRows = True Then
            dt.Rows.Add(row)
        End If
        dr.Close()
        dr2.Close()
        'dt.Rows.RemoveAt(0)
        'Dim a As Integer = dt.Rows.Count
        'Dim b As String = dt.Rows(1).Item(0)
        'Dim c As String = dt.Rows(2).Item(0)
        'Dim d As String = dt.Rows(2).Item(0)

        Return dt
    End Function

    'Public Function GetAdSizeDesc(ByVal MediaType As String, ByVal AdSize As String) As String
    '    'Dim dr As SqlDataReader
    '    'Dim arParams(2) As SqlParameter
    '    Dim desc As String
    '    'Dim parameterMediaType As New SqlParameter("@MediaType", SqlDbType.VarChar)
    '    'parameterMediaType.Value = MediaType
    '    'arParams(0) = parameterMediaType

    '    Dim parameterAdSize As New SqlParameter("@AdSize", SqlDbType.VarChar)
    '    parameterAdSize.Value = AdSize
    '    'arParams(1) = parameterAdSize

    '    Try
    '        desc = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetVendorType", parameterAdSize)
    '    Catch
    '        Err.Raise(Err.Number, "Class:cTasks Routine:GetMediaType", Err.Description)
    '    End Try

    '    Return desc
    'End Function

    'Update the job/comp/client ref
    Public Function UpdateJob(ByVal TheSQL As String, ByVal ar() As SqlParameter, Optional ByRef SuccessfullySaved As Boolean = False) As String
        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.Text, TheSQL, ar)
            SuccessfullySaved = True
            Return "<span class=""warning"">Successful!</span>"
        Catch
            SuccessfullySaved = False
            Return "Error. " & Err.Description
        End Try
        'Using MyConn As New SqlConnection(mConnString)
        '    MyConn.Open()
        '    Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
        '    Dim MyCmd As New SqlCommand(TheSQL, MyConn, MyTrans)
        '    Try
        '        MyCmd.ExecuteNonQuery()
        '        MyTrans.Commit()
        '        SuccessfullySaved = True
        '        Return "<span class=""warning"">Successful!</span>"
        '    Catch ex As Exception
        '        MyTrans.Rollback()
        '        SuccessfullySaved = False
        '        Return "Error. " & ex.Message.ToString
        '    Finally
        '        If MyConn.State = ConnectionState.Open Then MyConn.Close()
        '    End Try
        'End Using
    End Function

    Public Function EncodeSQL(ByVal str As String) As String
        Try
            Return str.Replace("'", "''").Replace(";", "#semicolon#")
        Catch ex As Exception
            Return str
        End Try
    End Function

    Public Shared Function DecodeSQL(ByVal str As String) As String
        Try
            Return str.Replace("#apostrophe#", "'").Replace("#semicolon#", ";")
        Catch ex As Exception
            Return str
        End Try
    End Function

#End Region

#Region " Datatables and In-memory data manipulation "
    Private mDtFormData As DataTable = New DataTable("FormData")
    Private mDtUserData As DataTable = New DataTable("UserData")
    Private mDtLookupData As DataTable = New DataTable("LookupData")

    'Main DT from db
    Public Overloads Function CreateDataTable() As DataTable
        Try
            Return mDtFormData
        Catch ex As Exception
            Err.Raise(Err.Number, "Error!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try
    End Function

    Public Overloads Function CreateDataTable(ByVal CtrlPage As System.Web.UI.Control) As DataTable
        Try
            AddDTColumns(mDtFormData)
            RecursAllControls(CtrlPage, mDtFormData)
            'return it to use dt on forms; might not be needed
            'after refinement, both CreateDataTable routines might become private
            Return mDtFormData
        Catch ex As Exception
            Err.Raise(Err.Number, "Error!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try
    End Function

    Public Overloads Sub CreateDataTable(ByVal ADataTable As DataTable, ByVal CtrlPage As System.Web.UI.Control)
        Try
            AddDTColumns(ADataTable)
            RecursAllControls(CtrlPage, ADataTable)
        Catch ex As Exception
            Err.Raise(Err.Number, "Error!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try
    End Sub

    Private Sub AddDTColumns(ByVal aDataTable As DataTable)
        Dim colItemCode As DataColumn = New DataColumn("ItemCode")
        colItemCode.DataType = System.Type.GetType("System.String")
        aDataTable.Columns.Add(colItemCode)

        Dim colControlID As DataColumn = New DataColumn("ControlID")
        colControlID.DataType = System.Type.GetType("System.String")
        aDataTable.Columns.Add(colControlID)

        Dim colDBValue As DataColumn = New DataColumn("DBValue")
        colDBValue.DataType = System.Type.GetType("System.String")
        aDataTable.Columns.Add(colDBValue)

        Dim colFormValue As DataColumn = New DataColumn("FormValue")
        colFormValue.DataType = System.Type.GetType("System.String")
        aDataTable.Columns.Add(colFormValue)

        Dim colItemCaption As DataColumn = New DataColumn("ItemCaption")
        colItemCaption.DataType = System.Type.GetType("System.String")
        aDataTable.Columns.Add(colItemCaption)

    End Sub

    Private Overloads Sub AddDTRow(ByVal ADataTable As DataTable, ByVal strControlID As String, ByVal strValue As String, ByVal strItemCode As String, ByVal ItemCaption As String)
        Try
            If strValue = "1/1/1900" Then
                strValue = ""
            End If
            Dim MyRow As DataRow
            MyRow = ADataTable.NewRow
            With MyRow
                .Item("ItemCode") = strItemCode
                .Item("ControlID") = "ctl00_ContentPlaceHolderMain_" & strControlID
                .Item("DBValue") = strValue
                .Item("FormValue") = strValue
                .Item("ItemCaption") = ItemCaption
            End With
            ADataTable.Rows.Add(MyRow)
        Catch ex As Exception
            Err.Raise(Err.Number, "Error in fn: AddDTRow!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Sub

    Private Overloads Sub AddDTRow(ByVal ADataTable As DataTable, ByVal strControlID As String, ByVal strValue As String)
        Try
            Dim MyRow As DataRow
            MyRow = ADataTable.NewRow
            With MyRow
                .Item("ControlID") = strControlID
                .Item("DBValue") = strValue
            End With
            ADataTable.Rows.Add(MyRow)
        Catch ex As Exception
            Err.Raise(Err.Number, "Error in fn: AddDTRow!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Sub

    'DT from dynamic form
    Public Sub UpdateDTFormValues(ByVal TheMainDataTable As DataTable, ByVal TheSecondaryDataTable As DataTable, Optional ByVal description As String = "")
        Dim strVal As String = String.Empty
        Dim currVal As String = String.Empty
        Dim added As Integer = 0
        Dim TheControlID As String = String.Empty
        For i As Integer = 0 To TheMainDataTable.Rows.Count - 1
            TheControlID = TheMainDataTable.Rows(i)("ControlID")
            For j As Integer = 0 To TheSecondaryDataTable.Rows.Count - 1
                Dim str As String = TheSecondaryDataTable.Rows(j)("ControlID")
                Dim x As String = TheSecondaryDataTable.Rows(j)("FormValue")
                Dim y As String = TheSecondaryDataTable.Rows(j)("ControlID")
                If TheSecondaryDataTable.Rows(j)("ControlID") = TheControlID Then
                    strVal = TheSecondaryDataTable.Rows(j)("FormValue")
                ElseIf InStr(TheSecondaryDataTable.Rows(j)("ControlID"), "txtDesc") > 0 AndAlso added = 0 Then
                    If description Is Nothing Then
                        description = ""
                    End If
                    Dim MyRow As DataRow
                    MyRow = TheMainDataTable.NewRow
                    With MyRow
                        .Item("ItemCode") = "SPEC_VER_DESC"
                        .Item("ControlID") = TheSecondaryDataTable.Rows(j)("ControlID")
                        .Item("DBValue") = description
                        .Item("FormValue") = TheSecondaryDataTable.Rows(j)("FormValue")
                    End With
                    TheMainDataTable.Rows.Add(MyRow)
                    added = 1
                End If
            Next
            TheControlID = TheControlID.Replace("'", "''")
            TheMainDataTable.Select("ControlID = '" & TheControlID & "'")(0)("FormValue") = strVal
        Next
    End Sub

    Public Function CreateUserDataDataTable(ByVal ThePage As System.Web.UI.Control) As DataTable
        Try
            AddUserDataDTColumns(mDtUserData)
            RecursUserDataAllControls(ThePage, mDtUserData)
            Return mDtUserData
        Catch ex As Exception
            Err.Raise(Err.Number, "Error!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try
    End Function

    Private Sub AddUserDataDTColumns(ByVal aDataTable As DataTable)
        Dim colControlID As DataColumn = New DataColumn("ControlID")
        colControlID.DataType = System.Type.GetType("System.String")
        aDataTable.Columns.Add(colControlID)

        Dim colValue As DataColumn = New DataColumn("FormValue")
        colValue.DataType = System.Type.GetType("System.String")
        aDataTable.Columns.Add(colValue)

        'Dim colLabel As DataColumn = New DataColumn("FieldLabel")
        'colLabel.DataType = System.Type.GetType("System.String")
        'aDataTable.Columns.Add(colLabel)

    End Sub

    Private Sub AddUserDataDTRow(ByVal ADataTable As DataTable, ByVal strControlID As String, ByVal strValue As String, Optional ByVal sControl As String = "")
        Try
            Dim MyRow As DataRow
            MyRow = ADataTable.NewRow
            With MyRow
                .Item("ControlID") = strControlID
                Select Case strValue
                    Case "Yes"
                        If sControl = "System.Web.UI.WebControls.RadioButtonList" Then
                            .Item("FormValue") = "1"
                        Else
                            .Item("FormValue") = strValue
                        End If

                    Case "No"
                        If sControl = "System.Web.UI.WebControls.RadioButtonList" Then
                            .Item("FormValue") = "0"
                        Else
                            .Item("FormValue") = strValue
                        End If

                    Case Else
                        .Item("FormValue") = strValue
                End Select
            End With
            ADataTable.Rows.Add(MyRow)
        Catch ex As Exception
            Err.Raise(Err.Number, "Error in fn: AddDTRow!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Sub

    Private Overloads Sub RecursUserDataAllControls(ByVal parent As System.Web.UI.Control, ByVal aDataTable As DataTable)
        Try
            For Each ctrl As System.Web.UI.Control In parent.Controls
                Dim test As String = ctrl.GetType.ToString
                Select Case ctrl.GetType.ToString
                    Case "System.Web.UI.WebControls.TextBox"
                        If InStr(ctrl.ClientID, "Value") > 0 Then
                            AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString(), CType(ctrl, TextBox).Text)
                        End If
                        If InStr(ctrl.ClientID, "txtDesc") > 0 Then
                            AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString(), CType(ctrl, TextBox).Text)
                        End If
                    Case "System.Web.UI.WebControls.RadioButtonList"
                        If InStr(ctrl.ClientID, "Value") > 0 Then
                            AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString(), CType(ctrl, RadioButtonList).SelectedValue, ctrl.GetType.ToString())
                        End If
                    Case "Telerik.Web.UI.RadComboBox"
                        If InStr(ctrl.ClientID, "Value") > 0 Then
                            AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString(), CType(ctrl, Telerik.Web.UI.RadComboBox).SelectedValue)
                        End If
                    Case "System.Web.UI.WebControls.ImageButton"
                    Case "System.Web.UI.WebControls.HyperLink"
                    Case "Telerik.Web.UI.RadEditor"
                        If InStr(ctrl.ClientID, "Value") > 0 Then
                            AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString(), CType(ctrl, Telerik.Web.UI.RadEditor).Text)
                        End If
                    Case "Telerik.Web.UI.RadGrid"
                        If InStr(ctrl.ClientID, "Quantity") > 0 Then
                            Dim x As Integer
                            Dim y As Integer
                            Dim rg As Telerik.Web.UI.RadGrid
                            rg = CType(ctrl, Telerik.Web.UI.RadGrid)
                            For x = 0 To rg.Items.Count - 1
                                For y = 0 To rg.Columns.Count - 1
                                    Dim txt As New System.Web.UI.WebControls.TextBox
                                    Dim lbl As New System.Web.UI.WebControls.Label
                                    Dim lblSeq As New System.Web.UI.WebControls.Label
                                    Dim lblEst As New System.Web.UI.WebControls.Label
                                    Dim lblComp As New System.Web.UI.WebControls.Label
                                    Dim lblQuote As New System.Web.UI.WebControls.Label
                                    Dim lblRev As New System.Web.UI.WebControls.Label
                                    lblSeq = rg.Items(x).FindControl("lblSeqNum")
                                    lblEst = rg.Items(x).FindControl("lblEstimateNumber")
                                    lblComp = rg.Items(x).FindControl("lblCompNum")
                                    lblQuote = rg.Items(x).FindControl("lblQuoteNum")
                                    lblRev = rg.Items(x).FindControl("lblRevNum")
                                    If InStr(rg.Columns(y).UniqueName, "txt") > 0 Then
                                        txt = rg.Items(x).FindControl(rg.Columns(y).UniqueName)
                                        If lblEst.Text <> "0" Then
                                            AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString() & "_" & rg.Columns(y).UniqueName.Replace("txt", "") & "Est_" & lblEst.Text & "_" & lblComp.Text & "_" & lblQuote.Text & "_" & lblRev.Text, txt.Text)
                                        Else
                                            AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString() & "_" & rg.Columns(y).UniqueName.Replace("txt", "") & "_" & lblSeq.Text, txt.Text)
                                        End If
                                    End If
                                    If InStr(rg.Columns(y).UniqueName, "lbl") > 0 Then
                                        lbl = rg.Items(x).FindControl(rg.Columns(y).UniqueName)
                                        If lblEst.Text <> "0" Then
                                            AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString() & "_" & rg.Columns(y).UniqueName.Replace("lbl", "") & "Est_" & lblEst.Text & "_" & lblComp.Text & "_" & lblQuote.Text & "_" & lblRev.Text, lbl.Text)
                                        Else
                                            AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString() & "_" & rg.Columns(y).UniqueName.Replace("lbl", "") & "_" & lblSeq.Text, lbl.Text)
                                        End If
                                    End If

                                Next
                            Next
                        End If
                        If InStr(ctrl.ClientID, "Vendor") > 0 Then
                            Dim x As Integer
                            Dim y As Integer
                            Dim rg As Telerik.Web.UI.RadGrid
                            rg = CType(ctrl, Telerik.Web.UI.RadGrid)
                            For x = 0 To rg.Items.Count - 1
                                For y = 0 To rg.Columns.Count - 1
                                    Dim txt As System.Web.UI.WebControls.TextBox
                                    Dim lbl As System.Web.UI.WebControls.Label
                                    Dim txtSpecID As System.Web.UI.WebControls.TextBox
                                    txtSpecID = rg.Items(x).FindControl("txtSPEC_ID")
                                    If InStr(rg.Columns(y).UniqueName, "txt") > 0 Then
                                        txt = rg.Items(x).FindControl(rg.Columns(y).UniqueName)
                                        AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString() & "_" & rg.Columns(y).UniqueName.Replace("txt", "") & "_" & txtSpecID.Text, txt.Text)
                                    End If
                                    If InStr(rg.Columns(y).UniqueName, "lbl") > 0 Then
                                        lbl = rg.Items(x).FindControl(rg.Columns(y).UniqueName)
                                        AddUserDataDTRow(aDataTable, ctrl.ClientID.ToString() & "_" & rg.Columns(y).UniqueName.Replace("lbl", "") & "_" & txtSpecID.Text, lbl.Text)
                                    End If

                                Next
                            Next
                        End If
                End Select
                If ctrl.Controls.Count > 0 Then
                    RecursUserDataAllControls(ctrl, aDataTable)
                End If
            Next
        Catch ex As Exception
            Err.Raise(Err.Number, "Error looping through controls!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Sub

    'DT for lookups
    Public Function CreateLookupDataTable(Optional ByVal MediaType As String = "") As DataTable
        'Dim arParams(1) As SqlParameter

        'Dim parameterMediaType As New SqlParameter("@MediaType", SqlDbType.VarChar)
        'parameterMediaType.Value = MediaType
        'arParams(0) = parameterMediaType

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetAllLookups", "DBLookUpData")
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:Job_Specs Routine:CreateLookupDataTable", Err.Description)
        End Try
    End Function

    'Get one value back from form or datatable:
    Public Overloads Function GetOneFormValue(ByVal ThePage As System.Web.UI.Page, ByVal TheDataTable As DataTable, ByVal TheItemCode As String) As String
        Try
            Dim dt As DataTable = TheDataTable
            dt = CreateUserDataDataTable(ThePage)
            Dim dv As DataView = New DataView(dt)
            dv.RowFilter = "ItemCode = '" & TheItemCode & "'"
            dt = dv.ToTable
            Dim str As String = dt.Rows(0)("FormValue").ToString()
            Return str
        Catch ex As Exception
            Return "Error: " & ex.Message.ToString
        End Try
    End Function

    Public Overloads Function GetOneFormValue(ByVal TheDataTable As DataTable, ByVal TheItemCode As String) As String
        Try
            Dim dv As DataView = New DataView(TheDataTable)
            dv.RowFilter = "ItemCode = '" & TheItemCode & "'"
            Dim dt As DataTable = dv.ToTable
            Dim str As String = dt.Rows(0)("FormValue").ToString()
            Return str
        Catch ex As Exception
            Return "Error: " & ex.Message.ToString
        End Try
    End Function

#End Region

#Region " Page and Form "
    Dim dtFormData As DataTable = New DataTable("FormData")
    Dim tabIndex As Integer = 0
    Dim sectionindex As Integer = 1
    Dim panelidentity As String

    Public Function BuildJobSpecsForm(ByVal version As String, ByVal revision As String, ByRef ThePlaceHolder As PlaceHolder, ByVal intJobNum As Integer, ByVal intJobCompNum As Integer, ByVal category As String, ByVal spectype As String, Optional ByVal clientcode As String = "", Optional ByRef SpellCheckObjects As String = "",
                                      Optional ByVal IsClientPortal As Boolean = False) As DataTable
        Try
            Dim strIDForDT As String
            Dim IsEdit As Boolean = True 'job/object level
            Dim ds As DataSet = New DataSet
            Dim dsPanel As DataSet = New DataSet
            Dim dsPanelQtyVen As DataSet = New DataSet
            Dim data As DataTable = New DataTable
            Dim dr As SqlDataReader
            Dim textboxID As String = ""

            jobnum = intJobNum
            jobcompnum = intJobCompNum
            versionNum = CInt(version)
            revisionNum = CInt(revision)
            dsPanel = Me.GetJobSpecCategories(spectype)
            dsPanelQtyVen = Me.GetJobSpecQtyVendorTabsDataSet(spectype)
            ds = Me.GetJobSpecsDataSet(intJobNum, intJobCompNum, CInt(version), CInt(revision))
            dsText = Me.GetJobSpecsDataSetTextFields(intJobNum, intJobCompNum, CInt(version), CInt(revision))
            Dim dvSections As DataView = New DataView(dsPanel.Tables(0))
            'dvSections.RowFilter = "ITEM_CODE='SECTION'"
            Dim dtSections As DataTable = New DataTable()
            dtSections = dvSections.ToTable
            client = clientcode
            ThePlaceHolder.Controls.Clear()
            'create private dt columns
            AddDTColumns(mDtFormData)

            For i As Integer = 0 To dtSections.Rows.Count - 1
                Dim MyPanel As New eWorld.UI.CollapsablePanel 'instatiate new panel
                panelidentity = i

                'For: loop through one section's items (all useable controls)
                Dim dvSectionItems As DataView = New DataView(ds.Tables(0))
                dvSectionItems.RowFilter = "CATEGORY_ID = " & CInt(dtSections.Rows(i)("CATEGORY_ID").ToString())
                Dim dtSectionItems As DataTable = New DataTable
                dtSectionItems = dvSectionItems.ToTable

                If dtSectionItems.Rows.Count <> 0 Then
                    SetSectionPanel(MyPanel, dtSections.Rows(i)("CATEGORY_DESC"), i)
                    ThePlaceHolder.Controls.Add(MyPanel)
                    'MyPanel.Controls.Add(MiscFN.NewLiteral("<br />"))
                End If


                Dim strNameForID As String = String.Empty
                Dim str As String = dtSectionItems.Rows.Count.ToString
                For j As Integer = 0 To dtSectionItems.Rows.Count - 1
                    'might need to wrap this replace into a "clean function" to make sure any chars that
                    'would interfere with js/html are cleaned out
                    strNameForID = Replace(dtSectionItems.Rows(j)("SHORT_DESC"), " ", "_")
                    'strNameForID = Replace(strNameForID, "/", "--")
                    strNameForID = Replace(strNameForID, "_-_", "_")
                    strNameForID = Replace(strNameForID, ":", "")
                    'Add to internal dt
                    strIDForDT = AddFormRowControls(MyPanel,
                                        dtSectionItems.Rows(j)("CONTROL_TYPE"),
                                        dtSectionItems.Rows(j)("FIELD_NAME"),
                                        strNameForID, strNameForID,
                                        dtSectionItems.Rows(j)("REQUIRED"),
                                        Job_Specs.DecodeSQL(dtSectionItems.Rows(j)("FIELD_VALUE").ToString()),
                                        True,
                                        data,
                                        category,
                                        "desc_" & MyPanel.ID & "_" & strNameForID, "", "", IsClientPortal)

                    AddDTRow(mDtFormData, strIDForDT, Job_Specs.DecodeSQL(dtSectionItems.Rows(j)("FIELD_VALUE")), dtSectionItems.Rows(j)("FIELD_NAME"), dtSectionItems.Rows(j)("SHORT_DESC"))

                    If dtSectionItems.Rows(j)("SEPARATOR_LINE") = 1 Then
                        MyPanel.Controls.Add(MiscFN.NewLiteral("<hr />"))
                    End If

                    'Create valid list of controls for spell checker
                    Select Case dtSectionItems.Rows(j)("CONTROL_TYPE")
                        Case RowTypesSpecs.ValOnlyChar50, RowTypesSpecs.MultiLineChar, RowTypesSpecs.MultiLineText
                            'textboxID = MyPanel.ID.ToString()& "_" & "TxtValue_" & strNameForID & "_" & dtSectionItems.Rows(j)("FIELD_NAME")
                            'SpellCheckObjects &= "new HtmlElementTextSource(document.getElementById('" & textboxID & "'))" & Environment.NewLine & ","
                            SpellCheckObjects &= "new HtmlElementTextSource(document.getElementById('" & strIDForDT & "'))" & Environment.NewLine & ","
                    End Select

                    strIDForDT = String.Empty

                Next
            Next
            If SpellCheckObjects <> "" Then
                SpellCheckObjects = SpellCheckObjects.Substring(0, SpellCheckObjects.Length - 1)
            End If


            dvSections = New DataView(dsPanelQtyVen.Tables(0))
            dtSections = New DataTable()
            dtSections = dvSections.ToTable
            'For k As Integer = 0 To dtSections.Rows.Count - 1
            '    Dim MyPanel As New eWorld.UI.CollapsablePanel 'instatiate new panel
            '    Dim x As Integer
            '    Dim y As Integer
            '    If dtSections.Rows(k)("USE_QTY").ToString() = "1" Then
            '        MyPanel = New eWorld.UI.CollapsablePanel
            '        panelidentity = k
            '        SetSectionPanel(MyPanel, "Quantity", k)
            '        ThePlaceHolder.Controls.Add(MyPanel)
            '        'MyPanel.Controls.Add(MiscFN.NewLiteral("<table><tr><td>&nbsp;</td></tr></table>"))
            '        'MyPanel.Controls.Add(MiscFN.NewLiteral("<br />"))
            '        data = Me.GetJobSpecsQtyDataWithEst(intJobNum, intJobCompNum, CInt(version), CInt(revision))
            '        strIDForDT = AddFormRowControls(MyPanel, RowTypesSpecs.RadGrid, "", "", "Quantity", 1, "", True, data, "Qty")
            '        For x = 0 To data.Rows.Count - 1
            '            For y = 0 To data.Columns.Count - 1
            '                Dim stre As String = data.Rows(x)("EstimateNumber").ToString
            '                If data.Rows(x)("EstimateNumber").ToString() <> "0" Then
            '                    AddDTRow(mDtFormData, strIDForDT & "_" & data.Columns(y).ColumnName & "Est_" & data.Rows(x)("EstimateNumber").ToString() & "_" & data.Rows(x)("CompNum").ToString() & "_" & data.Rows(x)("QuoteNum").ToString() & "_" & data.Rows(x)("RevNum").ToString(), data.Rows(x)(y), data.Columns.Item(y).ColumnName)
            '                Else
            '                    AddDTRow(mDtFormData, strIDForDT & "_" & data.Columns(y).ColumnName & "_" & data.Rows(x)("SeqNum").ToString(), data.Rows(x)(y), data.Columns.Item(y).ColumnName)
            '                End If
            '            Next
            '        Next
            '    End If
            '    If dtSections.Rows(k)("USE_VENDOR_TAB").ToString() = "1" Then
            '        MyPanel = New eWorld.UI.CollapsablePanel
            '        panelidentity = k + 1
            '        SetSectionPanel(MyPanel, "Vendor", k)
            '        ThePlaceHolder.Controls.Add(MyPanel)
            '        'MyPanel.Controls.Add(MiscFN.NewLiteral("<table><tr><td>&nbsp;</td></tr></table>"))
            '        'MyPanel.Controls.Add(MiscFN.NewLiteral("<br />"))
            '        data = Me.GetJobSpecsVendorData(intJobNum, intJobCompNum, 1)
            '        strIDForDT = AddFormRowControls(MyPanel, RowTypesSpecs.RadGrid, "", "", "Vendor", 1, "", True, data, "Ven", "1")
            '        For x = 0 To data.Rows.Count - 1
            '            For y = 0 To data.Columns.Count - 1
            '                AddDTRow(mDtFormData, strIDForDT & "_" & data.Columns(y).ColumnName & "_" & data.Rows(x)("SPEC_ID").ToString(), data.Rows(x)(y), data.Columns.Item(y).ColumnName)
            '            Next
            '        Next
            '    End If
            '    If dtSections.Rows(k)("USE_VENDOR_TAB").ToString() = "2" Then
            '        MyPanel = New eWorld.UI.CollapsablePanel
            '        panelidentity = k + 1
            '        SetSectionPanel(MyPanel, "Vendor", k)
            '        ThePlaceHolder.Controls.Add(MyPanel)
            '        'MyPanel.Controls.Add(MiscFN.NewLiteral("<table><tr><td>&nbsp;</td></tr></table>"))
            '        'MyPanel.Controls.Add(MiscFN.NewLiteral("<br />"))
            '        data = Me.GetJobSpecsVendorData(intJobNum, intJobCompNum, 2)
            '        strIDForDT = AddFormRowControls(MyPanel, RowTypesSpecs.RadGrid, "", "", "Vendor", 1, "", True, data, "Ven", "2")
            '        For x = 0 To data.Rows.Count - 1
            '            For y = 0 To data.Columns.Count - 1
            '                AddDTRow(mDtFormData, strIDForDT & "_" & data.Columns(y).ColumnName & "_" & data.Rows(x)("SPEC_ID").ToString(), data.Rows(x)(y), data.Columns.Item(y).ColumnName)
            '            Next
            '        Next
            '    End If
            'Next
            Return mDtFormData
        Catch ex As Exception
            Err.Raise(Err.Number, "Error! " & ex.Message.ToString())
        Finally
        End Try
    End Function

    Private Sub RecursAllControls(ByVal parent As System.Web.UI.Control, ByVal aDataTable As DataTable)
        Dim str As String = String.Empty
        Try
            For Each ctrl As System.Web.UI.Control In parent.Controls
                Select Case ctrl.GetType.ToString
                    Case "System.Web.UI.WebControls.TextBox"
                        If InStr(ctrl.ClientID, "Value") > 0 Then
                            str = CType(ctrl, TextBox).Text
                            'If str <> "" OrElse str <> String.Empty Then
                            AddDTRow(aDataTable, ctrl.ClientID.ToString(), str)
                            'End If
                        End If
                    Case "System.Web.UI.WebControls.RadioButtonList"
                        str = CType(ctrl, RadioButtonList).SelectedValue
                        If str = "Yes" Then
                            AddDTRow(aDataTable, ctrl.ClientID.ToString(), "1")
                        ElseIf str = "No" Then
                            AddDTRow(aDataTable, ctrl.ClientID.ToString(), "0")
                        Else 'If str <> "" OrElse str <> String.Empty Then
                            AddDTRow(aDataTable, ctrl.ClientID.ToString(), str)
                        End If
                    Case "Telerik.Web.UI.RadComboBox"
                        AddDTRow(aDataTable, ctrl.ClientID.ToString(), CType(ctrl, Telerik.Web.UI.RadComboBox).SelectedValue)
                    Case "System.Web.UI.WebControls.HyperLink"
                    Case "System.Web.UI.WebControls.RadioButton"
                    Case "System.Web.UI.WebControls.ImageButton"
                End Select
                If ctrl.Controls.Count > 0 Then
                    RecursAllControls(ctrl, aDataTable)
                End If
                str = String.Empty
            Next
        Catch ex As Exception
            Err.Raise(Err.Number, "Error looping through controls!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Sub

    Private Function SetSectionPanel(ByRef ThePanel As eWorld.UI.CollapsablePanel, ByVal PanelName As String, ByVal PanelID As Integer, Optional ByVal PanelExpand As Boolean = False, Optional ByVal PanelToolTip As String = "") As eWorld.UI.CollapsablePanel
        Try
            With ThePanel
                .ID = "colpnl" & Replace(PanelName, " ", "") & PanelID.ToString() 'replace with JOB_TMPLT_DTL.LABEL from Section query
                .TitleText = PanelName.ToString
            End With
            Return ThePanel
        Catch ex As Exception
            Err.Raise(Err.Number, "Error: SetSectionPanel!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Private Function SetHyperLink(ByRef TheHyperLink As System.Web.UI.WebControls.HyperLink, ByVal PanelName As String, ByVal HyperLinkID As String,
                                    ByVal HyperLinkText As String, ByVal HasPopUp As Boolean, ByVal IsEdit As Boolean,
                                    Optional ByVal ThisValueControlID As String = "", Optional ByVal ThisDescriptControlID As String = "",
                                    Optional ByVal ItemCode As String = "") As System.Web.UI.WebControls.HyperLink
        Try
            Dim oAgency As New cAgency(Me.mConnString)
            HyperLinkText = Replace(HyperLinkText, "_", " ")
            HyperLinkText = Replace(HyperLinkText, "--", "/")
            HyperLinkText = Replace(HyperLinkText, " SLASH ", "/")
            HyperLinkID = Replace(HyperLinkID, "--", "_")
            ThisValueControlID = Replace(ThisValueControlID, "--", "_")
            With TheHyperLink
                .ID = PanelName & "_hl" & Replace(HyperLinkID, "_", "") & "_" & ItemCode
                .Text = HyperLinkText & ":&nbsp;"
                .NavigateUrl = "Javascript:void(0);"
                .Font.Underline = True
                .ToolTip = HyperLinkText.Replace("&nbsp;", " ")
            End With
            If ItemCode = "JOB_LOG.OFFICE_CODE" AndAlso oAgency.JobTemplateEditOfficeCheck = False Then
                HasPopUp = False
            Else
                HasPopUp = True
            End If

            'If to check whether we need to set a hyperlink popup
            'maybe just add one field to table and do isnull check instead of bool?
            Try
                'HasPopUp = True
                If HasPopUp = True AndAlso IsEdit = True Then
                    ' TheHyperLink.Attributes.Add("onclick", SetLookupJSText(ThisValueControlID, ItemCode, HyperLinkText))
                    'TheHyperLink.CssClass = "JobTemplateLink"
                    TheHyperLink.CssClass = "JobTemplatePopupLink"
                Else
                    TheHyperLink.CssClass = "JobTemplateLabel"
                End If
            Catch ex As Exception
                Err.Raise(Err.Number, "Error setting hyperlink/label lookup!<br />" & ex.Message.ToString())
            End Try
            Return TheHyperLink
        Catch ex As Exception
            Err.Raise(Err.Number, "Error setting hyperlink/label properties!<br />" & ex.Message.ToString())
        End Try

    End Function

    Private Function SetLabel(ByRef TheLabel As System.Web.UI.WebControls.Label, ByVal PanelName As String, ByVal LabelID As String,
                                    ByVal LabelText As String, ByVal HasPopUp As Boolean, ByVal IsEdit As Boolean,
                                    Optional ByVal ThisValueControlID As String = "", Optional ByVal ThisDescriptControlID As String = "",
                                    Optional ByVal ItemCode As String = "") As System.Web.UI.WebControls.Label
        Try
            Dim oAgency As New cAgency(Me.mConnString)
            LabelText = Replace(LabelText, "_", " ")
            LabelText = Replace(LabelText, " SLASH ", "/")
            LabelID = Replace(LabelID, "--", "_")
            ThisValueControlID = Replace(ThisValueControlID, "--", "_")
            With TheLabel
                .ID = PanelName & "_lbl" & Replace(LabelID, "_", "") & "_" & ItemCode
                .Text = LabelText & ":&nbsp;"
                ' .Font.Bold = True
                .ToolTip = LabelText.Replace("&nbsp;", " ")
            End With
            Return TheLabel
        Catch ex As Exception
            Err.Raise(Err.Number, "Error setting label properties!<br />" & ex.Message.ToString())
        End Try

    End Function

    Private OpenSpacerTable As String = "<table width=""100%"" border=""0"" cellpadding=""2"" cellspacing=""0"" align=""left""><tr><td width=""210"" align=""right"" valign=""top"">"
    Private MiddleSpacerTable As String = "</td><td width=""1"" align=""center"" valign=""middle"">&nbsp;</td><td align=""left"" valign=""top"">"
    Private CloseSpacerTable As String = "</td></tr></table><br />"

    Private DivSpacer As String = "<div style=""width: 100%; overflow-x: scroll; text-align: left;""> "
    Private DivEnding As String = "</div>"

    Dim blackplt1 As String = ""
    Dim blackplt2 As String = ""
    Dim adnum As Boolean = False
    Dim adnumcontrol As String
    Private Function AddFormRowControls(ByRef ThePanel As eWorld.UI.CollapsablePanel,
                                    ByVal ThisInputType As RowTypesSpecs, ByVal ThisItemCode As String, ByVal ThisControlID As String, ByVal ThisControlName As String,
                                    ByVal Required As Integer, ByVal ThisValueControlValue As String,
                                    ByVal IsInternalCall As Boolean,
                                    ByVal dt As DataTable,
                                    ByVal category As String,
                                    Optional ByVal ThisDescriptControlID As String = "",
                                    Optional ByVal ThisDescriptControlValue As String = "",
                                    Optional ByVal HyperlinkOnClickJS As String = "",
                                    Optional ByVal IsClientPortal As Boolean = False) As String

        'Instantiate vars:
        Dim ReturnControlID As String = String.Empty
        Dim hfITEM_CODE As New System.Web.UI.WebControls.HiddenField
        Dim txtbxValue As New System.Web.UI.WebControls.TextBox
        Dim txtbxDescript As New System.Web.UI.WebControls.TextBox
        Dim radioValue As New System.Web.UI.WebControls.RadioButton
        Dim rblValue As New System.Web.UI.WebControls.RadioButtonList
        Dim dropValue As New Telerik.Web.UI.RadComboBox
        Dim imgbtnValue As New System.Web.UI.WebControls.ImageButton
        Dim radGrid As New Telerik.Web.UI.RadGrid
        Dim lblValue As New System.Web.UI.WebControls.Label
        Dim hlValue As New System.Web.UI.WebControls.HyperLink
        Dim IsRequiredField As Boolean = Required
        Dim IDPrefix As String = ThePanel.ID.ToString() & "_"
        Dim IsReadOnly As Boolean = False
        Dim oAgency As New cAgency(Me.mConnString)
        Dim oReqCheck As cRequired = New cRequired(Me.mConnString)


        'Set requirement flags:


        'Start creating the controls and filling the data:
        Dim hl As New System.Web.UI.WebControls.Label
        Dim hyper As New System.Web.UI.WebControls.HyperLink
        ThisControlName = Replace(ThisControlName, "--", "_")
        ThisControlName = Replace(ThisControlName, "/", "_SLASH_")
        ThisControlID = Replace(ThisControlID, "/", "--")
        Try
            Select Case ThisInputType
                Case RowTypesSpecs.ValOnlyChar1
                    With txtbxValue
                        .ID = IDPrefix & "TxtValue_" & ThisControlName & "_" & ThisItemCode
                        .SkinID = "TextBoxCodeSmall"
                        .MaxLength = 1
                        .Text = ThisValueControlValue
                        .TabIndex = tabIndex + 1
                        .Width = 20
                        If Me.GetJobSpecMaxRevision(Me.jobnum, Me.jobcompnum, Me.versionNum) > Me.revisionNum OrElse IsClientPortal = True Then
                            .ReadOnly = True
                        Else
                            .ReadOnly = False
                        End If
                    End With
                    SetLabel(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, True, txtbxValue.ClientID.ToString(), "", ThisItemCode)
                    'SetHyperLink(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, FormIsEdit, txtbxValue.ClientID.ToString(), txtbxDescript.ClientID.ToString(), ThisItemCode)
                Case RowTypesSpecs.ValOnlyChar10
                    With txtbxValue
                        .ID = IDPrefix & "TxtValue_" & ThisControlName & "_" & ThisItemCode
                        .Width = Unit.Pixel(200)
                        .MaxLength = 10
                        .Text = ThisValueControlValue
                        .TabIndex = tabIndex + 1
                        .Width = 100
                        If Me.GetJobSpecMaxRevision(Me.jobnum, Me.jobcompnum, Me.versionNum) > Me.revisionNum OrElse IsClientPortal = True Then
                            .ReadOnly = True
                        Else
                            .ReadOnly = False
                        End If
                    End With
                    SetLabel(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, True, txtbxValue.ClientID.ToString(), "", ThisItemCode)
                    'SetHyperLink(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, FormIsEdit, txtbxValue.ID.ToString(), txtbxDescript.ClientID.ToString(), ThisItemCode)
                Case RowTypesSpecs.ValOnlyChar50
                    With txtbxValue
                        .ID = IDPrefix & "TxtValue_" & ThisControlName & "_" & ThisItemCode
                        .Width = Unit.Pixel(410)
                        .MaxLength = 50
                        .Text = ThisValueControlValue
                        .TabIndex = tabIndex + 1
                        If Me.GetJobSpecMaxRevision(Me.jobnum, Me.jobcompnum, Me.versionNum) > Me.revisionNum OrElse IsClientPortal = True Then
                            .ReadOnly = True
                        Else
                            .ReadOnly = False
                        End If
                    End With
                    SetLabel(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, True, txtbxValue.ClientID.ToString(), "", ThisItemCode)
                    'SetHyperLink(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, FormIsEdit, txtbxValue.ID.ToString(), "", ThisItemCode)
                Case RowTypesSpecs.MultiLineChar
                    With txtbxValue
                        .ID = IDPrefix & "TxtValue_" & ThisControlName & "_" & ThisItemCode
                        .Width = Unit.Pixel(410)
                        .Attributes.Add("onkeyup", "checkLength(this,254)")
                        .Attributes.Add("onfocus", "checkLength(this,254)")
                        .Attributes.Add("onblur", "checkLength(this,254)")
                        .MaxLength = 254
                        .TextMode = TextBoxMode.MultiLine
                        .Rows = 6
                        .TabIndex = tabIndex + 1
                        .Text = ThisValueControlValue
                        If Me.GetJobSpecMaxRevision(Me.jobnum, Me.jobcompnum, Me.versionNum) > Me.revisionNum OrElse IsClientPortal = True Then
                            .ReadOnly = True
                        Else
                            .ReadOnly = False
                        End If
                    End With
                    SetLabel(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, True, txtbxValue.ClientID.ToString(), "", ThisItemCode)
                    'SetHyperLink(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, FormIsEdit, txtbxValue.ID.ToString(), "", ThisItemCode)
                Case RowTypesSpecs.MultiLineText
                    'With radEdit
                    '    .ID = IDPrefix & "RadEditorValue_" & ThisControlName
                    '    .Skin = Webvantage.MiscFN.SetRadEditorSkin
                    '    .TabIndex = tabIndex + 1
                    '    .Html = ThisValueControlValue
                    '    .OnClientLoad = "OnClientLoad"
                    '    .Width = 450
                    '    .Height = 300
                    '    .ShowSubmitCancelButtons = False
                    '    .ShowPreviewMode = False
                    '    .ShowHtmlMode = False
                    '    If Me.GetJobSpecMaxRevision(Me.jobnum, Me.jobcompnum, Me.versionNum) > Me.revisionNum Then
                    '        .Editable = False
                    '        .HasPermission = False
                    '    Else
                    '        .Editable = True
                    '        .HasPermission = True
                    '    End If
                    'End With
                    With txtbxValue
                        .ID = IDPrefix & "TxtValue_" & ThisItemCode
                        .Width = Unit.Pixel(410)
                        .TextMode = TextBoxMode.MultiLine
                        .Rows = 10
                        .TabIndex = tabIndex + 1
                        If ThisItemCode = "TEXT_1" Then
                            .Text = Job_Specs.DecodeSQL(dsText.Tables(0).Rows(0)("TEXT_1").ToString())
                        ElseIf ThisItemCode = "TEXT_2" Then
                            .Text = Job_Specs.DecodeSQL(dsText.Tables(0).Rows(0)("TEXT_2").ToString())
                        ElseIf ThisItemCode = "TEXT_3" Then
                            .Text = Job_Specs.DecodeSQL(dsText.Tables(0).Rows(0)("TEXT_3").ToString())
                        ElseIf ThisItemCode = "TEXT_4" Then
                            .Text = Job_Specs.DecodeSQL(dsText.Tables(0).Rows(0)("TEXT_4").ToString())
                        ElseIf ThisItemCode = "TEXT_5" Then
                            .Text = Job_Specs.DecodeSQL(dsText.Tables(0).Rows(0)("TEXT_5").ToString())
                        ElseIf ThisItemCode = "TEXT_6" Then
                            .Text = Job_Specs.DecodeSQL(dsText.Tables(0).Rows(0)("TEXT_6").ToString())
                        ElseIf ThisItemCode = "TEXT_7" Then
                            .Text = Job_Specs.DecodeSQL(dsText.Tables(0).Rows(0)("TEXT_7").ToString())
                        ElseIf ThisItemCode = "TEXT_8" Then
                            .Text = Job_Specs.DecodeSQL(dsText.Tables(0).Rows(0)("TEXT_8").ToString())
                        ElseIf ThisItemCode = "TEXT_9" Then
                            .Text = Job_Specs.DecodeSQL(dsText.Tables(0).Rows(0)("TEXT_9").ToString())
                        ElseIf ThisItemCode = "TEXT_10" Then
                            .Text = Job_Specs.DecodeSQL(dsText.Tables(0).Rows(0)("TEXT_10").ToString())
                        ElseIf ThisItemCode = "TEXT_11" Then
                            .Text = Job_Specs.DecodeSQL(dsText.Tables(0).Rows(0)("TEXT_11").ToString())
                        ElseIf ThisItemCode = "TEXT_12" Then
                            .Text = Job_Specs.DecodeSQL(dsText.Tables(0).Rows(0)("TEXT_12").ToString())
                        ElseIf ThisItemCode = "TEXT_13" Then
                            .Text = Job_Specs.DecodeSQL(dsText.Tables(0).Rows(0)("TEXT_13").ToString())
                        ElseIf ThisItemCode = "TEXT_14" Then
                            .Text = Job_Specs.DecodeSQL(dsText.Tables(0).Rows(0)("TEXT_14").ToString())
                        ElseIf ThisItemCode = "TEXT_15" Then
                            .Text = Job_Specs.DecodeSQL(dsText.Tables(0).Rows(0)("TEXT_15").ToString())
                        ElseIf ThisItemCode = "TEXT_16" Then
                            .Text = Job_Specs.DecodeSQL(dsText.Tables(0).Rows(0)("TEXT_16").ToString())
                        ElseIf ThisItemCode = "TEXT_17" Then
                            .Text = Job_Specs.DecodeSQL(dsText.Tables(0).Rows(0)("TEXT_17").ToString())
                        ElseIf ThisItemCode = "TEXT_18" Then
                            .Text = Job_Specs.DecodeSQL(dsText.Tables(0).Rows(0)("TEXT_18").ToString())
                        ElseIf ThisItemCode = "TEXT_19" Then
                            .Text = Job_Specs.DecodeSQL(dsText.Tables(0).Rows(0)("TEXT_19").ToString())
                        ElseIf ThisItemCode = "TEXT_20" Then
                            .Text = Job_Specs.DecodeSQL(dsText.Tables(0).Rows(0)("TEXT_20").ToString())
                        Else
                            .Text = ThisValueControlValue
                        End If
                        If Me.GetJobSpecMaxRevision(Me.jobnum, Me.jobcompnum, Me.versionNum) > Me.revisionNum OrElse IsClientPortal = True Then
                            .ReadOnly = True
                        Else
                            .ReadOnly = False
                        End If
                    End With
                    SetLabel(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, True, txtbxValue.ClientID.ToString(), "", ThisItemCode)
                    SetHyperLink(hyper, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, True, txtbxValue.ID.ToString(), "", ThisItemCode)
                Case RowTypesSpecs.ValOnlyInt
                    With txtbxValue
                        .ID = IDPrefix & "TxtValue_" & ThisControlName.Replace("$", "") & "_" & ThisItemCode
                        .Width = Unit.Pixel(410)
                        .TabIndex = tabIndex + 1
                        .MaxLength = 10
                        .Text = ThisValueControlValue
                        .Width = 75
                        If Me.GetJobSpecMaxRevision(Me.jobnum, Me.jobcompnum, Me.versionNum) > Me.revisionNum OrElse IsClientPortal = True Then
                            .ReadOnly = True
                        Else
                            .ReadOnly = False
                        End If
                    End With
                    SetLabel(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, True, txtbxValue.ClientID.ToString(), "", ThisItemCode)
                    'SetHyperLink(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, False, FormIsEdit, rblValue.ClientID.ToString(), "", ThisItemCode)
                Case RowTypesSpecs.ValOnlySmallInt
                    With txtbxValue
                        .ID = IDPrefix & "TxtValue_" & ThisControlName.Replace("$", "") & "_" & ThisItemCode
                        .Width = Unit.Pixel(410)
                        .TabIndex = tabIndex + 1
                        .MaxLength = 3
                        .Text = ThisValueControlValue
                        .Width = 60
                        If Me.GetJobSpecMaxRevision(Me.jobnum, Me.jobcompnum, Me.versionNum) > Me.revisionNum OrElse IsClientPortal = True Then
                            .ReadOnly = True
                        Else
                            .ReadOnly = False
                        End If
                    End With
                    SetLabel(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, True, True, txtbxValue.ClientID.ToString(), "", ThisItemCode)
                    'SetHyperLink(hl, ThePanel.ID.ToString(), ThisControlID, ThisControlName, False, FormIsEdit, dropValue.ClientID.ToString(), "", ThisItemCode)               
                    'Case RowTypesSpecs.RadGrid
                    '    With radGrid
                    '        .ID = IDPrefix & "RadGrid_" & ThisControlName
                    '        .TabIndex = tabIndex + 1
                    '        .AllowPaging = False
                    '        '.AllowSorting = True
                    '        .AutoGenerateColumns = False
                    '        .GridLines = GridLines.None
                    '        .Width = New Unit(100, UnitType.Percentage)
                    '        .EnableViewState = False
                    '        .AllowAutomaticInserts = True
                    '        '.MasterTableView.EditMode = Telerik.Web.UI.GridEditMode.InPlace
                    '        '.MasterTableView.CommandItemDisplay = Telerik.Web.UI.GridCommandItemDisplay.Top
                    '    End With
                    '    If category = "Qty" Then
                    '        Dim ronly As Boolean
                    '        If Me.GetJobSpecMaxRevision(Me.jobnum, Me.jobcompnum, Me.versionNum) > Me.revisionNum Then
                    '            ronly = True
                    '        Else
                    '            ronly = False
                    '        End If
                    '        Dim RadCol As New Telerik.Web.UI.GridTemplateColumn

                    '        With RadCol
                    '            .UniqueName = "cbDeleteQty"
                    '            .ItemTemplate = New RadGridTemplate("Delete")
                    '            .HeaderText = "Delete"
                    '        End With
                    '        radGrid.Columns.Add(RadCol)
                    '        RadCol = New Telerik.Web.UI.GridTemplateColumn
                    '        With RadCol
                    '            .UniqueName = "txtQuantity"
                    '            .ItemTemplate = New RadGridTemplate("Quantity", "", ronly)
                    '            .DataField = "Quantity"
                    '            .HeaderText = "Quantity"
                    '        End With
                    '        radGrid.Columns.Add(RadCol)
                    '        RadCol = New Telerik.Web.UI.GridTemplateColumn
                    '        With RadCol
                    '            .UniqueName = "lblEstimateNumber"
                    '            .ItemTemplate = New RadGridTemplate("EstimateNumber")
                    '            .DataField = "EstimateNumber"
                    '            .HeaderText = "Estimate Number"
                    '        End With
                    '        radGrid.Columns.Add(RadCol)
                    '        RadCol = New Telerik.Web.UI.GridTemplateColumn
                    '        With RadCol
                    '            .UniqueName = "lblCompNum"
                    '            .ItemTemplate = New RadGridTemplate("CompNum")
                    '            .DataField = "CompNum"
                    '            .HeaderText = "Comp Num"
                    '        End With
                    '        radGrid.Columns.Add(RadCol)
                    '        RadCol = New Telerik.Web.UI.GridTemplateColumn
                    '        With RadCol
                    '            .UniqueName = "lblQuoteNum"
                    '            .ItemTemplate = New RadGridTemplate("QuoteNum")
                    '            .DataField = "QuoteNum"
                    '            .HeaderText = "Quote Num"
                    '        End With
                    '        radGrid.Columns.Add(RadCol)
                    '        RadCol = New Telerik.Web.UI.GridTemplateColumn
                    '        With RadCol
                    '            .UniqueName = "lblRevNum"
                    '            .ItemTemplate = New RadGridTemplate("RevNum")
                    '            .DataField = "RevNum"
                    '            .HeaderText = "Rev Num"
                    '        End With
                    '        radGrid.Columns.Add(RadCol)
                    '        RadCol = New Telerik.Web.UI.GridTemplateColumn
                    '        With RadCol
                    '            .UniqueName = "lblSeqNum"
                    '            .ItemTemplate = New RadGridTemplate("SeqNum")
                    '            .DataField = "SeqNum"
                    '            .HeaderText = ""
                    '            .Visible = False
                    '        End With
                    '        radGrid.Columns.Add(RadCol)
                    '    End If
                    '    If category = "Ven" Then
                    '        Dim strURL As String = "jobspecs_AddNew.aspx?JobNum=" & jobnum & "&JobCompNum=" & jobcompnum & "&Version=" & Me.versionNum & "&Revision=" & Me.revisionNum & "&AddType=2&Row=Ven"
                    '        Dim RadCol As Telerik.Web.UI.GridTemplateColumn
                    '        RadCol = New Telerik.Web.UI.GridTemplateColumn
                    '        With RadCol
                    '            .UniqueName = "cbDeleteVen"
                    '            .ItemTemplate = New RadGridTemplate("Delete")
                    '            .HeaderText = "Delete"
                    '        End With
                    '        radGrid.Columns.Add(RadCol)
                    '        RadCol = New Telerik.Web.UI.GridTemplateColumn
                    '        With RadCol
                    '            .UniqueName = "imgbtnDetail"
                    '            .ItemTemplate = New RadGridTemplate("Detail", strURL)
                    '            '.HeaderText = "Delete"
                    '        End With
                    '        radGrid.Columns.Add(RadCol)
                    '        Dim t As Integer
                    '        For t = 0 To dt.Columns.Count - 1
                    '            RadCol = New Telerik.Web.UI.GridTemplateColumn
                    '            With RadCol
                    '                .UniqueName = "txt" & dt.Columns(t).ColumnName
                    '                .ItemTemplate = New RadGridTemplate(dt.Columns(t).ColumnName, category, False, ThisDescriptControlID)
                    '                .DataField = dt.Columns(t).ColumnName
                    '                .HeaderText = dt.Columns(t).ColumnName.Replace("_", " ")
                    '                If dt.Columns(t).ColumnName = "SPEC_ID" Then
                    '                    .Visible = False
                    '                End If
                    '                If dt.Columns(t).ColumnName = "Vendor" Then
                    '                    .ItemStyle.Wrap = False
                    '                End If
                    '                If dt.Columns(t).ColumnName = "Close_Date" Then
                    '                    .ItemStyle.Wrap = False
                    '                End If
                    '                If dt.Columns(t).ColumnName = "Run_Date" Then
                    '                    .ItemStyle.Wrap = False
                    '                End If
                    '                If dt.Columns(t).ColumnName = "Ext_Date" Then
                    '                    .ItemStyle.Wrap = False
                    '                End If
                    '                If dt.Columns(t).ColumnName = "AdSize" Then
                    '                    .ItemStyle.Wrap = False
                    '                End If
                    '                If dt.Columns(t).ColumnName = "Status" Then
                    '                    .ItemStyle.Wrap = False
                    '                End If
                    '                If dt.Columns(t).ColumnName = "Region" Then
                    '                    .ItemStyle.Wrap = False
                    '                End If
                    '            End With
                    '            radGrid.Columns.Add(RadCol)
                    '        Next
                    '    End If
                    '    radGrid.DataSource = dt
                    '    radGrid.DataBind()
            End Select
        Catch ex As Exception
            Err.Raise(Err.Number, "Error !<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try

        'Extra hidden field for item codes:
        Try
            With hfITEM_CODE
                .ID = IDPrefix & "hfItemCode_" & ThisControlName & ThisItemCode
                .Value = ThisItemCode
            End With
        Catch ex As Exception
            Err.Raise(Err.Number, "Error !<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try

        'Create the table (row) and add the hyperlink (the "label" on the form) into them:
        With ThePanel.Controls
            If ThisInputType = RowTypesSpecs.RadGrid AndAlso ThisControlName = "Vendor" Then
                .Add(MiscFN.NewLiteral(OpenSpacerTable))
                .Add(MiscFN.NewLiteral(DivSpacer))
                'ElseIf ThisInputType = RowTypesSpecs.MultiLineText Then
                '    .Add(MiscFN.NewLiteral(OpenSpacerTable))
                '    .Add(hfITEM_CODE)
                '    .Add(hyper)
                '    .Add(MiscFN.NewLiteral(MiddleSpacerTable))
            Else
                .Add(MiscFN.NewLiteral(OpenSpacerTable))
                .Add(hfITEM_CODE)
                If ThisInputType = RowTypesSpecs.MultiLineText Then
                    .Add(hyper)
                Else
                    .Add(hl)
                End If
                .Add(MiscFN.NewLiteral(MiddleSpacerTable))
            End If
        End With

        'Add the actual controls into the rows and set properties:

        Dim LblTemp As New System.Web.UI.WebControls.Label 'change format to label instead of disabled control when in read-only

        Try
            With ThePanel.Controls
                Select Case ThisInputType
                    Case RowTypesSpecs.ValOnlyChar1, RowTypesSpecs.ValOnlyChar10, RowTypesSpecs.ValOnlyChar50, RowTypesSpecs.ValOnlyInt, RowTypesSpecs.ValOnlySmallInt
                        'do read only check
                        If IsRequiredField = True Then
                            txtbxValue.CssClass = "RequiredInput"
                        End If
                        txtbxValue.Enabled = True
                        .Add(txtbxValue)
                        ReturnControlID = txtbxValue.ID
                    Case RowTypesSpecs.MultiLineChar
                        'do read only check
                        If IsRequiredField = True Then
                            txtbxValue.CssClass = "RequiredInput"
                        End If
                        txtbxValue.Enabled = True
                        .Add(txtbxValue)
                        ReturnControlID = txtbxValue.ID
                    Case RowTypesSpecs.MultiLineText
                        If IsRequiredField = True Then
                            txtbxValue.CssClass = "RequiredInput"
                        End If
                        txtbxValue.Enabled = True
                        .Add(txtbxValue)
                        ReturnControlID = txtbxValue.ID
                End Select

                'Create a red asterisk if it is required (when in edit mode):
                If IsRequiredField = True AndAlso IsReadOnly = False AndAlso (ThisInputType <> RowTypesSpecs.RadGrid AndAlso ThisInputType <> RowTypesSpecs.Panel) Then
                    .Add(MiscFN.NewLiteral(RowSpacer))
                    .Add(MiscFN.NewLiteral("<span class = ""CssRequired""></span><br />"))
                    ''add real validator?
                    Dim rfv As New RequiredFieldValidator
                    With rfv
                        .ControlToValidate = ReturnControlID
                        .ErrorMessage = Replace(ThisControlName, "_", "&nbsp;") & " is required."
                        .SetFocusOnError = True
                    End With
                    .Add(MiscFN.NewLiteral(IndentSpacer))
                    .Add(rfv)
                Else
                    .Add(MiscFN.NewLiteral(RowSpacer))
                    .Add(MiscFN.NewLiteral(RowSpacer))
                End If
            End With
            If ThisInputType = RowTypesSpecs.RadGrid AndAlso ThisControlName = "Vendor" Then
                ThePanel.Controls.Add(MiscFN.NewLiteral(DivEnding))
            End If
            ThePanel.Controls.Add(MiscFN.NewLiteral(CloseSpacerTable))
            tabIndex += 1
            Return ReturnControlID
        Catch ex As Exception
            Err.Raise(Err.Number, "Error creating form row!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Private Function AddAsLabel(ByVal IDPrefix As String, ByVal ControlName As String, ByVal TheValue As String, Optional ByVal TheDescript As String = "", Optional ByVal WrapIt As Boolean = False) As System.Web.UI.WebControls.Label
        Dim lbl As System.Web.UI.WebControls.Label
        With lbl
            .ID = IDPrefix & "LblValue_" & ControlName
            If TheDescript = "" Then
                .Text = TheValue
            Else
                .Text = TheValue & " - " & TheDescript
            End If
            If WrapIt = True Then
                .Width = System.Web.UI.WebControls.Unit.Pixel(400)
            End If
        End With
    End Function

    Private Sub AddUpdateTemplatePanel(ByVal APlaceHolder As PlaceHolder, ByVal IsEdit As Boolean, ByVal CurrTemplate As String)
        Dim APanel As New eWorld.UI.CollapsablePanel 'instatiate new panel
        SetSectionPanel(APanel, "Change Template", 1, False)
        Dim lbl As System.Web.UI.WebControls.Label
        Dim ddl As Telerik.Web.UI.RadComboBox
        With lbl
            .ID = "lblTemplates"
            .Text = "Current Template"
        End With
        Dim MyDrop As cDropDowns = New cDropDowns(mConnString)
        With ddl
            .DataSource = MyDrop.GetJobTemplatesList()
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", ""))
        End With
        If CurrTemplate <> String.Empty AndAlso CurrTemplate <> "" Then
            If ddl.Items.Contains(New Telerik.Web.UI.RadComboBoxItem(CurrTemplate, CurrTemplate)) Then
                ddl.SelectedValue = CurrTemplate
            End If
        End If
        With APlaceHolder.Controls
            .Add(APanel)
            .Add(MiscFN.NewLiteral("<br />"))
            .Add(MiscFN.NewLiteral(IndentSpacer))
            .Add(lbl)
            .Add(MiscFN.NewLiteral("<br />"))
            .Add(MiscFN.NewLiteral(IndentSpacer))
            .Add(ddl)
        End With


    End Sub

    Private Function SetLookupJS(ByVal LookupType As String, Optional ByVal ItemCode As String = "") As String
        Try
            'If InStr(mCL_CODE, "-") > 0 Then
            '    Dim str() As String = mCL_CODE.Split("-")
            '    mCL_CODE = str(0).Trim.Replace("&nbsp;", "")
            'End If
            'If InStr(mDIV_CODE, "-") > 0 Then
            '    Dim str() As String = mDIV_CODE.Split("-")
            '    mDIV_CODE = str(0).Trim.Replace("&nbsp;", "")
            'End If
            'If InStr(mPRD_CODE, "-") > 0 Then
            '    Dim str() As String = mPRD_CODE.Split("-")
            '    mPRD_CODE = str(0).Trim.Replace("&nbsp;", "")
            'End If
            'If InStr(mSC_CODE, "-") > 0 Then
            '    Dim str() As String = mSC_CODE.Split("-")
            '    mSC_CODE = str(0).Trim.Replace("&nbsp;", "")
            'End If
            Dim strJSPrefix As String = "OpenRadWindow('','LookUp_Quick.aspx?calledfrom=custom&control="
            Dim strJSSuffix As String = ");return false;"
            Dim sbJS As StringBuilder = New StringBuilder
            With sbJS
                .Append(strJSPrefix)
                If ItemCode = "JOB_LOG.UDV1_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=JobUD1'")
                    .Append(strJSSuffix)
                    Return sbJS.ToString
                ElseIf ItemCode = "JOB_LOG.UDV2_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=JobUD2'")
                    .Append(strJSSuffix)
                    Return sbJS.ToString
                ElseIf ItemCode = "JOB_LOG.UDV3_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=JobUD3'")
                    .Append(strJSSuffix)
                    Return sbJS.ToString
                ElseIf ItemCode = "JOB_LOG.UDV4_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=JobUD4'")
                    .Append(strJSSuffix)
                    Return sbJS.ToString
                ElseIf ItemCode = "JOB_LOG.UDV5_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=JobUD5'")
                    .Append(strJSSuffix)
                    Return sbJS.ToString
                ElseIf ItemCode = "JOB_COMPONENT.UDV1_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=JCUD1'")
                    .Append(strJSSuffix)
                    Return sbJS.ToString
                ElseIf ItemCode = "JOB_COMPONENT.UDV2_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=JCUD2'")
                    .Append(strJSSuffix)
                    Return sbJS.ToString
                ElseIf ItemCode = "JOB_COMPONENT.UDV3_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=JCUD3'")
                    .Append(strJSSuffix)
                    Return sbJS.ToString
                ElseIf ItemCode = "JOB_COMPONENT.UDV4_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=JCUD4'")
                    .Append(strJSSuffix)
                    Return sbJS.ToString
                ElseIf ItemCode = "JOB_COMPONENT.UDV5_CODE" Then
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=JCUD5'")
                    .Append(strJSSuffix)
                    Return sbJS.ToString
                End If
                If InStr(LookupType, "Coop_Billing") > 0 Then 'ok
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=coopbilling'")
                ElseIf InStr(LookupType, "Complexity") > 0 Then 'ok
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=complexity'")
                ElseIf InStr(LookupType, "Promotion") > 0 Then 'ok
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=promotion'")
                ElseIf InStr(LookupType, "Dept") > 0 Then 'pops ok but doesn't return value;probably due to slash in id
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=deptteam'")
                ElseIf InStr(LookupType, "Job_Type") > 0 Then 'ok
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=jobtype'")
                ElseIf InStr(LookupType, "Ad_Number") > 0 Then 'ok
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=adnumber&fromform=jt&bp1=" & blackplt1 & "&bp2=" & blackplt2 & "'")
                ElseIf InStr(LookupType, "Market") > 0 Then 'ok
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=market'")
                ElseIf InStr(LookupType, "Office") > 0 Then 'ok
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=office'")
                ElseIf InStr(LookupType, "Tax_Code") > 0 Then 'ok
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=taxcodes'")
                ElseIf InStr(LookupType, "Account_Number") > 0 Then 'ok
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=acctnum'")
                ElseIf InStr(LookupType, "Fiscal_Period") > 0 Then 'ok
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=fiscalperiod'")
                ElseIf InStr(LookupType, "Blackplate_1") > 0 AndAlso ItemCode = "JOB_COMPONENT.BLACKPLT_VER_DESC" Then 'ok
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=blackplt'")
                ElseIf InStr(LookupType, "Blackplate_2") > 0 AndAlso ItemCode = "JOB_COMPONENT.BLACKPLT_VER2_DESC" Then 'ok
                    .Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=blackplt'")
                ElseIf InStr(LookupType, "Account_Executive") > 0 Then
                    '.Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&client=" & mCL_CODE & "&division=" & mDIV_CODE & "&product=" & mPRD_CODE & "&type=accountexec'")
                ElseIf InStr(LookupType, "Contact") > 0 Then
                    '.Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=contact&client=" & mCL_CODE & "&division=" & mDIV_CODE & "&product=" & mPRD_CODE & "'")
                    'Return "javascript:window.open('poplookup_contact.aspx?form=jobtemplate&control=ctl00_ContentPlaceHolderMain_" & LookupType & "&type=contact&client=" & mCL_CODE & "&division=" & mDIV_CODE & "&product=" & mPRD_CODE & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=580,height=425,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;"
                ElseIf InStr(LookupType, "Campaign") > 0 Then
                    '.Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&client=" & mCL_CODE & "&division=" & mDIV_CODE & "&product=" & mPRD_CODE & "&type=campaign2'")
                ElseIf InStr(LookupType, "Sales_Class_Format") > 0 Then
                    '.Append("ctl00_ContentPlaceHolderMain_" & LookupType & "&type=salesclassformat&salesclass=" & mSC_CODE & "'")
                Else
                    Return ""
                End If
                .Append(strJSSuffix)
            End With
            Return sbJS.ToString
        Catch ex As Exception
            Return "ShowMessage(""" & ex.Message.ToString.Replace("/", "_").Replace("'", "") & """);"
        End Try
    End Function

    Private Function SetLookupJSText(ByVal LookupType As String, Optional ByVal ItemCode As String = "", Optional ByVal Htext As String = "") As String
        Try
            Dim strJSPrefix As String = "OpenRadWindow('','jobspecs_AddNew.aspx?JobNum=" & Me.jobnum & "&JobCompNum=" & Me.jobcompnum & "&Version=" & Me.versionNum & "&Revision=" & Me.revisionNum & "&AddType=3&Item=" & ItemCode & "&HText=" & Htext & "&control=" & LookupType & "', '1000','600'"
            Dim strJSSuffix As String = ");return false;"
            Dim sbJS As StringBuilder = New StringBuilder
            With sbJS
                .Append(strJSPrefix)
                .Append(strJSSuffix)
            End With
            Return sbJS.ToString
        Catch ex As Exception
            Return "ShowMessage(""" & ex.Message.ToString.Replace("/", "_").Replace("'", "") & """);"
        End Try
    End Function

    Public Sub ClearComponentFields(ByVal parent As System.Web.UI.Control)
        Try
            For Each ctrl As System.Web.UI.Control In parent.Controls
                Select Case ctrl.GetType.ToString
                    Case "System.Web.UI.WebControls.TextBox"
                        If InStr(ctrl.ClientID, "Value") > 0 AndAlso InStr(ctrl.ClientID, "JOBCOMPONENT") > 0 Then
                            Dim txt As System.Web.UI.WebControls.TextBox = CType(ctrl, TextBox)
                            txt.Text = ""
                        End If
                        If InStr(ctrl.ClientID, "Value") > 0 AndAlso InStr(ctrl.ClientID, "JOBCOMPONENT") > 0 AndAlso InStr(ctrl.ClientID, "Description") > 0 Then
                            Dim txt As System.Web.UI.WebControls.TextBox = CType(ctrl, TextBox)
                            txt.Text = ""
                            MiscFN.SetFocus(txt)
                        End If
                    Case "System.Web.UI.WebControls.RadioButtonList"
                        If InStr(ctrl.ClientID, "Value") > 0 AndAlso InStr(ctrl.ClientID, "JOBCOMPONENT") > 0 Then
                            Dim rbl As System.Web.UI.WebControls.RadioButtonList = CType(ctrl, RadioButtonList)
                            rbl.SelectedIndex = -1
                        End If
                    Case "Telerik.Web.UI.RadComboBox"
                        If InStr(ctrl.ClientID, "Value") > 0 AndAlso InStr(ctrl.ClientID, "JOBCOMPONENT") > 0 Then
                            Dim ddl As Telerik.Web.UI.RadComboBox = CType(ctrl, Telerik.Web.UI.RadComboBox)
                            ddl.SelectedIndex = -1
                        End If
                    Case "System.Web.UI.WebControls.ImageButton"
                    Case "System.Web.UI.WebControls.HyperLink"
                    Case "System.Web.UI.WebControls.RadioButton"
                End Select
                If ctrl.Controls.Count > 0 Then
                    ClearComponentFields(ctrl)
                End If
            Next
        Catch ex As Exception
            Err.Raise(Err.Number, "Error looping through controls!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Sub

    Public Function addleadingZeroesEstimate(ByVal item As String)
        Dim str() As String
        str = item.Split("-")
        Return str(0).PadLeft(6, "0") & " - " & str(1).PadLeft(2, "0")
    End Function

    Public Function CheckForSections(ByVal ds As DataSet)
        Dim row As DataRow
        If ds.Tables(0).Rows(0)("ITEM_TYPE").ToString() <> "S" Then
            row = ds.Tables(0).NewRow
            row.Item("ITEM_CODE") = "SECTION"
            row.Item("ITEM_TYPE") = "S"
            row.Item("SHORT_DESC") = ""
            row.Item("LONG_DESC") = ""
            row.Item("CONTROL_TYPE") = "0"
            row.Item("SECTION_ORDER") = "0"
            row.Item("ITEM_ORDER") = "0"
            row.Item("TMPLT_REQ") = "0"
            row.Item("ADVAN_REQ") = "0"
            row.Item("AGENCY_REQ") = "0"
            row.Item("CLIENT_REQ") = "0"
            row.Item("FIELD_VALUE") = ""
            row.Item("FIELD_DESCRIPT") = ""
            ds.Tables(0).Rows.InsertAt(row, 0)
            Me.sectionindex = 0
        End If
        Return ds
    End Function


#End Region

End Class
