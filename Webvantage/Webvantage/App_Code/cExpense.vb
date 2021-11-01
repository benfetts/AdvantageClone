Imports System.Data
Imports System.Data.SqlClient
Public Enum ExpenseStatus
    Open = 0
    Pending = 1
    Approved = 2
End Enum

Public Enum ExpenseStatusCalculated
    '**********         Status  Summitted   Approved
    Open = 0            '0      0           0
    Pending = 1         '1      0           0
    Approved = 2        '2      0           0
    PendingSuper = 3    '1      1           0
    DeniedSuper = 4     '1      1           1
    ApprovedSuper = 5   '1      1           2
    ApprovedAcct = 6    '2      1           2
    PendingAcct = 7     '4      1           0
End Enum

<Serializable()> Public Class ExpenseDetail
    '''-----------------------------------------------------------------
    '''-- Date Created: Tuesday, February 19, 2006
    '''-- by Steve Moreno			
    '''-----------------------------------------------------------------
#Region "Private vars"
    Private m_EXPDETAILID As Integer
    Private m_INV_NBR As String
    Private m_LINE_NBR As Integer
    Private m_ITEM_DATE As String
    Private m_ITEM_DESC As String
    Private m_CC_FLAG As Boolean
    Private m_CL_CODE As String
    Private m_CL_NAME As String
    Private m_DIV_CODE As String
    Private m_PRD_CODE As String
    Private m_JOB_NBR As Integer
    Private m_JOB_COMP_NBR As Integer
    Private m_JOB_COMP_DESC As String
    Private m_FNC_CODE As String
    Private m_FNC_DESCRIPTION As String
    Private m_QTY As Integer
    Private m_RATE As Decimal
    Private m_CC_AMT As Decimal
    Private m_AMOUNT As Decimal
    Private m_AP_COMMENT As String
    Private m_CREATE_USER_ID As String
    Private m_MOD_USER_ID As String
    Private m_MOD_DATE As String
#End Region
#Region "Properties"
    Public Property EXPDETAILID() As Integer
        Get
            Return m_EXPDETAILID
        End Get
        Set(ByVal Value As Integer)
            m_EXPDETAILID = Value
        End Set
    End Property
    Public Property INV_NBR() As String
        Get
            Return m_INV_NBR
        End Get
        Set(ByVal Value As String)
            m_INV_NBR = Value
        End Set
    End Property
    Public Property LINE_NBR() As Integer
        Get
            Return m_LINE_NBR
        End Get
        Set(ByVal Value As Integer)
            m_LINE_NBR = Value
        End Set
    End Property
    Public Property ITEM_DATE() As String
        Get
            Return CType(m_ITEM_DATE, Date).ToShortDateString().ToString
        End Get
        Set(ByVal Value As String)
            m_ITEM_DATE = CType(Value, Date).ToShortDateString().ToString
        End Set
    End Property
    Public Property ITEM_DESC() As String
        Get
            Return m_ITEM_DESC
        End Get
        Set(ByVal Value As String)
            m_ITEM_DESC = Value
        End Set
    End Property
    Public Property CC_FLAG() As Boolean
        Get
            Return m_CC_FLAG
        End Get
        Set(ByVal Value As Boolean)
            m_CC_FLAG = Value
        End Set
    End Property
    Public Property CL_CODE() As String
        Get
            Return m_CL_CODE
        End Get
        Set(ByVal Value As String)
            m_CL_CODE = Value
        End Set
    End Property
    Public Property CL_NAME() As String
        Get
            Return m_CL_NAME
        End Get
        Set(ByVal Value As String)
            m_CL_NAME = Value
        End Set
    End Property
    Public Property DIV_CODE() As String
        Get
            Return m_DIV_CODE
        End Get
        Set(ByVal Value As String)
            m_DIV_CODE = Value
        End Set
    End Property
    Public Property PRD_CODE() As String
        Get
            Return m_PRD_CODE
        End Get
        Set(ByVal Value As String)
            m_PRD_CODE = Value
        End Set
    End Property
    Public Property JOB_NBR() As Integer
        Get
            Return m_JOB_NBR
        End Get
        Set(ByVal Value As Integer)
            m_JOB_NBR = Value
        End Set
    End Property
    Public Property JOB_COMP_NBR() As Integer
        Get
            Return m_JOB_COMP_NBR
        End Get
        Set(ByVal Value As Integer)
            m_JOB_COMP_NBR = Value
        End Set
    End Property
    Public Property JOB_COMP_DESC() As String
        Get
            Return m_JOB_COMP_DESC
        End Get
        Set(ByVal Value As String)
            m_JOB_COMP_DESC = Value
        End Set
    End Property
    Public Property FNC_CODE() As String
        Get
            Return m_FNC_CODE
        End Get
        Set(ByVal Value As String)
            m_FNC_CODE = Value
        End Set
    End Property
    Public Property FNC_DESCRIPTION() As String
        Get
            Return m_FNC_DESCRIPTION
        End Get
        Set(ByVal Value As String)
            m_FNC_DESCRIPTION = Value
        End Set
    End Property
    Public Property QTY() As Integer
        Get
            Return m_QTY
        End Get
        Set(ByVal Value As Integer)
            m_QTY = Value
        End Set
    End Property
    Public Property RATE() As Decimal
        Get
            Return m_RATE
        End Get
        Set(ByVal Value As Decimal)
            m_RATE = Value
        End Set
    End Property
    Public Property CC_AMT() As Decimal
        Get
            Return m_CC_AMT
        End Get
        Set(ByVal Value As Decimal)
            m_CC_AMT = Value
        End Set
    End Property
    Public Property AMOUNT() As Decimal
        Get
            Return m_AMOUNT
        End Get
        Set(ByVal Value As Decimal)
            m_AMOUNT = Value
        End Set
    End Property
    Public Property AP_COMMENT() As String
        Get
            Return m_AP_COMMENT
        End Get
        Set(ByVal Value As String)
            m_AP_COMMENT = Value
        End Set
    End Property
    Public Property CREATE_USER_ID() As String
        Get
            Return m_CREATE_USER_ID
        End Get
        Set(ByVal Value As String)
            m_CREATE_USER_ID = Value
        End Set
    End Property
    Public Property MOD_USER_ID() As String
        Get
            Return m_MOD_USER_ID
        End Get
        Set(ByVal Value As String)
            m_MOD_USER_ID = Value
        End Set
    End Property
    Public Property MOD_DATE() As String
        Get
            Return m_MOD_DATE
        End Get
        Set(ByVal Value As String)
            m_MOD_DATE = Value
        End Set
    End Property
#End Region
#Region "Constructors"
    Public Sub New()

    End Sub

    Public Sub New(ByVal _EXPDETAILID As Integer, ByVal _INV_NBR As String, ByVal _LINE_NBR As Integer, ByVal _ITEM_DATE As DateTime, ByVal _ITEM_DESC As String, ByVal _CC_FLAG As Boolean, ByVal _CL_CODE As String, ByVal _CL_NAME As String, ByVal _DIV_CODE As String, ByVal _PRD_CODE As String, ByVal _JOB_NBR As Integer, ByVal _JOB_COMP_NBR As String, ByVal _JOB_COMP_DESC As String, ByVal _FNC_CODE As String, ByVal _FNC_DESCRIPTION As String, ByVal _QTY As Integer, ByVal _RATE As Decimal, ByVal _CC_AMT As Decimal, ByVal _AMOUNT As Decimal, ByVal _AP_COMMENT As String, ByVal _CREATE_USER_ID As String, ByVal _MOD_USER_ID As String, ByVal _MOD_DATE As DateTime)
        m_EXPDETAILID = _EXPDETAILID
        m_INV_NBR = _INV_NBR
        m_LINE_NBR = _LINE_NBR
        m_ITEM_DATE = CType(_ITEM_DATE, Date).ToShortDateString.ToString
        m_ITEM_DESC = _ITEM_DESC
        m_CC_FLAG = _CC_FLAG
        m_CL_CODE = _CL_CODE
        m_CL_NAME = _CL_NAME
        m_DIV_CODE = _DIV_CODE
        m_PRD_CODE = _PRD_CODE
        m_JOB_NBR = _JOB_NBR
        m_JOB_COMP_NBR = _JOB_COMP_NBR
        m_JOB_COMP_DESC = _JOB_COMP_DESC
        m_FNC_CODE = _FNC_CODE
        m_FNC_DESCRIPTION = _FNC_DESCRIPTION
        m_QTY = _QTY
        m_RATE = _RATE
        m_CC_AMT = _CC_AMT
        m_AMOUNT = _AMOUNT
        m_AP_COMMENT = _AP_COMMENT
        m_CREATE_USER_ID = _CREATE_USER_ID
        m_MOD_USER_ID = _MOD_USER_ID
        m_MOD_DATE = _MOD_DATE
    End Sub
#End Region
End Class
<Serializable()> Public Class ExpenseDetails
    Inherits CollectionBase
    Default Public Property Item(ByVal index As Integer) As ExpenseDetail
        Get
            Return CType(List(index), ExpenseDetail)
        End Get
        Set(ByVal Value As ExpenseDetail)
            List(index) = Value
        End Set
    End Property
    Public Function Add(ByVal value As ExpenseDetail) As Integer
        Return List.Add(value)
    End Function
    Public Function IndexOf(ByVal value As ExpenseDetail) As Integer
        Return List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As ExpenseDetail)
        List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As ExpenseDetail)
        List.Remove(value)
    End Sub
    Public Function Contains(ByVal value As ExpenseDetail) As Boolean
        Return List.Contains(value)
    End Function
End Class
<Serializable()> Public Class ExpenseHeader
    '''-----------------------------------------------------------------
    '''-- Date Created: Tuesday, February 19, 2006
    '''-- by Steve Moreno			
    '''-----------------------------------------------------------------
#Region "Private vars"
    Private m_INV_NBR As Integer
    Private m_EMP_CODE As String
    Private m_EmployeeName As String
    Private m_VN_CODE As String
    Private m_INV_DATE As String
    Private m_EXP_DESC As String
    Private m_DTL_DESC As String
    Private m_DATE_FROM As String
    Private m_DATE_TO As String
    Private m_INV_AMOUNT As Decimal
    Private m_APPROVED_BY As String
    Private m_APPROVED_DATE As String
    Private m_STATUS As ExpenseStatus
    Private m_SUBMITTED_FLAG As String
    Private m_APPROVED_FLAG As String
    Private m_STATUS_CALC As ExpenseStatusCalculated
    Private m_STATUS_CALC_DESC As String
    Private m_TOTAL_EXPENSES As Decimal
    Private m_TOTAL_DUE As Decimal
    Private m_ExpenseDetails As ExpenseDetails
#End Region
#Region "Properties"
    Public Property INV_NBR() As Integer
        Get
            Return m_INV_NBR
        End Get
        Set(ByVal Value As Integer)
            m_INV_NBR = Value
        End Set
    End Property
    Public Property EMP_CODE() As String
        Get
            Return m_EMP_CODE
        End Get
        Set(ByVal Value As String)
            m_EMP_CODE = Value
        End Set
    End Property
    Public Property EmployeeName() As String
        Get
            Return m_EmployeeName
        End Get
        Set(ByVal Value As String)
            m_EmployeeName = Value
        End Set
    End Property
    Public Property VN_CODE() As String
        Get
            Return m_VN_CODE
        End Get
        Set(ByVal Value As String)
            m_VN_CODE = Value
        End Set
    End Property
    Public Property INV_DATE() As String
        Get
            Return m_INV_DATE
        End Get
        Set(ByVal Value As String)
            m_INV_DATE = Value
        End Set
    End Property
    Public Property EXP_DESC() As String
        Get
            Return m_EXP_DESC
        End Get
        Set(ByVal Value As String)
            m_EXP_DESC = Value
        End Set
    End Property
    Public Property DTL_DESC() As String
        Get
            Return m_DTL_DESC
        End Get
        Set(ByVal Value As String)
            m_DTL_DESC = Value
        End Set
    End Property
    Public Property DATE_FROM() As String
        Get
            Return m_DATE_FROM
        End Get
        Set(ByVal Value As String)
            m_DATE_FROM = Value
        End Set
    End Property
    Public Property DATE_TO() As String
        Get
            Return m_DATE_TO
        End Get
        Set(ByVal Value As String)
            m_DATE_TO = Value
        End Set
    End Property
    Public Property INV_AMOUNT() As Decimal
        Get
            Return m_INV_AMOUNT
        End Get
        Set(ByVal Value As Decimal)
            m_INV_AMOUNT = Value
        End Set
    End Property
    Public Property APPROVED_BY() As String
        Get
            Return m_APPROVED_BY
        End Get
        Set(ByVal Value As String)
            m_APPROVED_BY = Value
        End Set
    End Property
    Public Property APPROVED_DATE() As String
        Get
            Return m_APPROVED_DATE
        End Get
        Set(ByVal Value As String)
            m_APPROVED_DATE = Value
        End Set
    End Property
    Public Property STATUS() As ExpenseStatus
        Get
            Return m_STATUS
        End Get
        Set(ByVal Value As ExpenseStatus)
            m_STATUS = Value
        End Set
    End Property

    Public Property SUBMITTED_FLAG() As String
        Get
            Return m_SUBMITTED_FLAG
        End Get
        Set(ByVal Value As String)
            m_SUBMITTED_FLAG = Value
        End Set
    End Property
    Public Property APPROVED_FLAG() As String
        Get
            Return m_APPROVED_FLAG
        End Get
        Set(ByVal Value As String)
            m_APPROVED_FLAG = Value
        End Set
    End Property
    Public Property STATUS_CALC() As ExpenseStatusCalculated
        Get
            Return m_STATUS_CALC
        End Get
        Set(ByVal Value As ExpenseStatusCalculated)
            m_STATUS_CALC = Value
        End Set
    End Property

    Public Property STATUS_CALC_DESC() As String
        Get
            Return m_STATUS_CALC_DESC
        End Get
        Set(ByVal Value As String)
            m_STATUS_CALC_DESC = Value
        End Set
    End Property

    Public Property TOTAL_EXPENSES() As Decimal
        Get
            Return m_TOTAL_EXPENSES
        End Get
        Set(ByVal Value As Decimal)
            m_TOTAL_EXPENSES = Value
        End Set
    End Property

    Public Property TOTAL_DUE() As Decimal
        Get
            Return m_TOTAL_DUE
        End Get
        Set(ByVal Value As Decimal)
            m_TOTAL_DUE = Value
        End Set
    End Property


    Public Property ExpenseDetails() As ExpenseDetails
        Get
            Return m_ExpenseDetails
        End Get
        Set(ByVal Value As ExpenseDetails)
            m_ExpenseDetails = Value
        End Set
    End Property
#End Region

#Region "Constructors"
    Public Sub New()

    End Sub

    Public Sub New(ByVal _INV_NBR As Integer, ByVal _EMP_CODE As String, ByVal _VN_CODE As String, ByVal _INV_DATE As DateTime, ByVal _EXP_DESC As String, ByVal _DTL_DESC As String, ByVal _DATE_FROM As DateTime, ByVal _DATE_TO As DateTime, ByVal _INV_AMOUNT As Decimal, ByVal _APPROVED_BY As String, ByVal _APPROVED_DATE As DateTime, ByVal _STATUS As String, ByVal _SUBMITTED_FLAG As String, ByVal _APPROVED_FLAG As String)
        m_INV_NBR = _INV_NBR
        m_EMP_CODE = _EMP_CODE
        m_VN_CODE = _VN_CODE
        m_INV_DATE = _INV_DATE
        m_EXP_DESC = _EXP_DESC
        m_DTL_DESC = _DTL_DESC
        m_DATE_FROM = _DATE_FROM
        m_DATE_TO = _DATE_TO
        m_INV_AMOUNT = _INV_AMOUNT
        m_APPROVED_BY = _APPROVED_BY
        m_APPROVED_DATE = _APPROVED_DATE
        m_STATUS = _STATUS
        m_SUBMITTED_FLAG = _SUBMITTED_FLAG
        m_APPROVED_FLAG = _APPROVED_FLAG
    End Sub
#End Region
End Class
<Serializable()> Public Class ExpenseHeaders
    Inherits CollectionBase
    Default Public Property Item(ByVal index As Integer) As ExpenseHeader
        Get
            Return CType(List(index), ExpenseHeader)
        End Get
        Set(ByVal Value As ExpenseHeader)
            List(index) = Value
        End Set
    End Property
    Public Function Add(ByVal value As ExpenseHeader) As Integer
        Return List.Add(value)
    End Function
    Public Function IndexOf(ByVal value As ExpenseHeader) As Integer
        Return List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As ExpenseHeader)
        List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As ExpenseHeader)
        List.Remove(value)
    End Sub
    Public Function Contains(ByVal value As ExpenseHeader) As Boolean
        Return List.Contains(value)
    End Function
End Class
<Serializable()> Public Class cExpense
    Dim mConnString As String
    Dim oSQL As SqlHelper

    Public Function ExpenseMainParentData(ByVal EmpCode As String, ByVal StartDate As Date, ByVal EndDate As Date) As DataSet
        Try
            Dim ds As DataSet
            Dim arParams(3) As SqlParameter

            ' Create parameter for stored procedure
            Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            parameterEmpCode.Value = EmpCode
            arParams(0) = parameterEmpCode

            Dim parameterStartingDate As New SqlParameter("@StartingDate", SqlDbType.DateTime)
            parameterStartingDate.Value = StartDate
            arParams(1) = parameterStartingDate

            Dim parameterEndingDate As New SqlParameter("@EndingDate", SqlDbType.DateTime)
            parameterEndingDate.Value = EndDate
            arParams(2) = parameterEndingDate

            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_ExpenseMain_ParentData", arParams)

            Return ds

        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cExpense Routine:ExpenseMainParentData", Err.Description)
        End Try
    End Function

    Public Function ExpenseMainChildData(ByVal EmpCode As String, ByVal StartDate As Date, ByVal EndDate As Date) As DataSet
        Try
            Dim ds As DataSet
            Dim arParams(3) As SqlParameter

            ' Create parameter for stored procedure
            Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            parameterEmpCode.Value = EmpCode
            arParams(0) = parameterEmpCode

            Dim parameterStartingDate As New SqlParameter("@StartingDate", SqlDbType.DateTime)
            parameterStartingDate.Value = StartDate
            arParams(1) = parameterStartingDate

            Dim parameterEndingDate As New SqlParameter("@EndingDate", SqlDbType.DateTime)
            parameterEndingDate.Value = EndDate
            arParams(2) = parameterEndingDate

            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_ExpenseMain_ChildData", arParams)

            Return ds

        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cExpense Routine:ExpenseMainChildData", Err.Description)
        End Try
    End Function

    Public Function GetAllExpenses(ByVal EmpCode As String, ByVal StartDate As Date, ByVal EndDate As Date) As ExpenseHeaders
        Dim dr As SqlClient.SqlDataReader
        Dim arParams(3) As SqlParameter

        ' Create parameter for stored procedure
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = EmpCode
        arParams(0) = parameterEmpCode

        Dim parameterStartingDate As New SqlParameter("@StartingDate", SqlDbType.DateTime)
        parameterStartingDate.Value = StartDate
        arParams(1) = parameterStartingDate

        Dim parameterEndingDate As New SqlParameter("@EndingDate", SqlDbType.DateTime)
        parameterEndingDate.Value = EndDate
        arParams(2) = parameterEndingDate

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_exp_get_all", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cExpense Routine:GetExpenseHeaderList", Err.Description)
        End Try

        Dim ThisExpenseHeader As ExpenseHeader = New ExpenseHeader
        Dim TheseExpenseHeaders As New ExpenseHeaders
        Dim ThisExpenseDetail As ExpenseDetail
        Dim TheseExpenseDetails As New ExpenseDetails
        Dim LastID As Integer = 0
        Dim appr_flag, sub_flag As Int16

        Try
            If dr.HasRows = True Then
                Do While dr.Read
                    If LastID <> dr(0) Then
                        If LastID <> 0 Then
                            ThisExpenseHeader.ExpenseDetails = TheseExpenseDetails
                            TheseExpenseHeaders.Add(ThisExpenseHeader)
                            ThisExpenseHeader = New ExpenseHeader
                            TheseExpenseDetails = New ExpenseDetails
                        End If
                        LastID = dr(0)
                    End If
                    ThisExpenseHeader.INV_NBR = dr(0)
                    ThisExpenseHeader.EMP_CODE = DBStr(dr, 1)
                    ThisExpenseHeader.VN_CODE = DBStr(dr, 2)
                    ThisExpenseHeader.INV_DATE = DBDate(dr, 3)
                    ThisExpenseHeader.EXP_DESC = DBStr(dr, 4)
                    ThisExpenseHeader.DTL_DESC = DBStr(dr, 5)
                    ThisExpenseHeader.DATE_FROM = DBDate(dr, 6)
                    ThisExpenseHeader.DATE_TO = DBDate(dr, 7)
                    ThisExpenseHeader.INV_AMOUNT = DBDec(dr, 8)
                    ThisExpenseHeader.APPROVED_BY = DBStr(dr, 9)
                    ThisExpenseHeader.APPROVED_DATE = DBDate(dr, 10)
                    ThisExpenseHeader.STATUS = DBStr(dr, 11)
                    sub_flag = DBInt(dr, 33)
                    appr_flag = DBInt(dr, 34)
                    ThisExpenseHeader.SUBMITTED_FLAG = CStr(sub_flag)
                    ThisExpenseHeader.APPROVED_FLAG = CStr(appr_flag)
                    ThisExpenseHeader.TOTAL_EXPENSES = DBDec(dr, 35)
                    ThisExpenseHeader.TOTAL_DUE = DBDec(dr, 36)

                    setStatusCalc(ThisExpenseHeader)
                    ThisExpenseHeader.STATUS_CALC_DESC = getStatusCalcDesc(ThisExpenseHeader.STATUS_CALC)

                    If IsDBNull(dr(14)) = False Then
                        ThisExpenseDetail = New ExpenseDetail
                        ThisExpenseDetail.EXPDETAILID = dr(12)
                        ThisExpenseDetail.INV_NBR = DBStr(dr, 13)
                        ThisExpenseDetail.LINE_NBR = dr(14)
                        ThisExpenseDetail.ITEM_DATE = DBDate(dr, 15)
                        ThisExpenseDetail.ITEM_DESC = DBStr(dr, 16)
                        ThisExpenseDetail.CC_FLAG = dr(17)
                        ThisExpenseDetail.CL_CODE = DBStr(dr, 18)
                        ThisExpenseDetail.DIV_CODE = DBStr(dr, 19)
                        ThisExpenseDetail.PRD_CODE = DBStr(dr, 20)
                        ThisExpenseDetail.JOB_NBR = DBInt(dr, 21)
                        ThisExpenseDetail.JOB_COMP_NBR = DBInt(dr, 22)
                        ThisExpenseDetail.FNC_CODE = DBStr(dr, 23)
                        ThisExpenseDetail.QTY = DBInt(dr, 24)
                        ThisExpenseDetail.RATE = DBDec(dr, 25)
                        ThisExpenseDetail.CC_AMT = DBDec(dr, 26)
                        ThisExpenseDetail.AMOUNT = DBDec(dr, 27)
                        ThisExpenseDetail.AP_COMMENT = DBStr(dr, 28)
                        ThisExpenseDetail.CREATE_USER_ID = DBStr(dr, 29)
                        ThisExpenseDetail.MOD_USER_ID = DBStr(dr, 30)
                        ThisExpenseDetail.MOD_DATE = DBDate(dr, 31)
                        TheseExpenseDetails.Add(ThisExpenseDetail)
                    End If
                Loop
                ThisExpenseHeader.ExpenseDetails = TheseExpenseDetails
                TheseExpenseHeaders.Add(ThisExpenseHeader)
            End If
        Catch
            Err.Raise(9999, "Class:cExpenseHeader Routine:GetAllExpenses", Err.Description)
        End Try

        dr.Close()

        Return TheseExpenseHeaders
    End Function

    Private Sub setStatusCalc(ByRef ThisExpenseHeader As ExpenseHeader)
        Select Case ThisExpenseHeader.STATUS
            Case 0
                ThisExpenseHeader.STATUS_CALC = 0

            Case 1
                If ThisExpenseHeader.SUBMITTED_FLAG = "0" Then
                    ThisExpenseHeader.STATUS_CALC = 1
                Else '1
                    If ThisExpenseHeader.APPROVED_FLAG = "0" Then
                        ThisExpenseHeader.STATUS_CALC = 3
                    ElseIf ThisExpenseHeader.APPROVED_FLAG = "1" Then
                        ThisExpenseHeader.STATUS_CALC = 4
                    Else '2
                        ThisExpenseHeader.STATUS_CALC = 5
                    End If
                End If

            Case 2
                If ThisExpenseHeader.APPROVED_FLAG = "0" Then
                    ThisExpenseHeader.STATUS_CALC = 2
                Else '2
                    ThisExpenseHeader.STATUS_CALC = 6
                End If
            Case 4
                ThisExpenseHeader.STATUS_CALC = 7
        End Select
    End Sub

    Public Function getStatusCalcDesc(ByVal ThisExpenseHeader As ExpenseHeader) As String
        Dim desc As String = ""

        Select Case ThisExpenseHeader.STATUS
            Case 0
                'ThisExpenseHeader.STATUS_CALC = 0
                desc = "Open"
            Case 1
                If ThisExpenseHeader.SUBMITTED_FLAG = "0" Then
                    'ThisExpenseHeader.STATUS_CALC = 1
                    desc = "Pending"
                Else '1
                    If ThisExpenseHeader.APPROVED_FLAG = "0" Then
                        'ThisExpenseHeader.STATUS_CALC = 3
                        desc = "Pending Approval"
                    ElseIf ThisExpenseHeader.APPROVED_FLAG = "1" Then
                        'ThisExpenseHeader.STATUS_CALC = 4
                        desc = "Denied by Approver"
                    Else '2
                        'ThisExpenseHeader.STATUS_CALC = 5
                        desc = "Approved"
                    End If
                End If

            Case 2
                If ThisExpenseHeader.APPROVED_FLAG = "0" Then
                    'ThisExpenseHeader.STATUS_CALC = 2
                    desc = "Approved"
                Else '2
                    'ThisExpenseHeader.STATUS_CALC = 6
                    desc = "Approved in Accounting"
                End If
            Case 4
                desc = "Pending Approval in Accouting"
        End Select

        Return desc

    End Function

    Public Function getStatusCalcDesc(ByVal StatusCalc As ExpenseStatusCalculated) As String
        Dim desc As String = ""

        Select Case StatusCalc
            Case 0
                desc = "Open"
            Case 1
                desc = "Pending"
            Case 2
                desc = "Approved"
            Case 3
                desc = "Pending Approval"
            Case 4
                desc = "Denied by Aprrover"
            Case 5
                desc = "Approved"
            Case 6
                desc = "Approved in Accounting"
            Case 7
                desc = "Pending Approval in Accounting"
        End Select

        Return desc

    End Function

    Public Function GetExpenseDetail(ByVal p_EXPDETAILID As Integer) As ExpenseDetail
        Dim dr As SqlDataReader
        Dim ThisExpenseDetail As ExpenseDetail

        Dim paramEXPDETAILID As New SqlParameter("@EXPDETAILID", SqlDbType.Int, 0)
        paramEXPDETAILID.Value = p_EXPDETAILID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "dbo.usp_wv_exp_SelectEXPENSE_DETAIL", paramEXPDETAILID)
        Catch
            Err.Raise(9999, "Class:cExpenseDetail Routine:DeleteExpenseDetail", Err.Description)
        End Try

        ThisExpenseDetail = New ExpenseDetail
        If dr.HasRows = True Then
            dr.Read()
            ThisExpenseDetail.EXPDETAILID = dr(0)
            ThisExpenseDetail.INV_NBR = dr(1)
            ThisExpenseDetail.LINE_NBR = dr(2)
            ThisExpenseDetail.ITEM_DATE = DBDate(dr, 3)
            ThisExpenseDetail.ITEM_DESC = DBStr(dr, 4)
            ThisExpenseDetail.CC_FLAG = dr(5)
            ThisExpenseDetail.CL_CODE = DBStr(dr, 6)
            ThisExpenseDetail.DIV_CODE = DBStr(dr, 7)
            ThisExpenseDetail.PRD_CODE = DBStr(dr, 8)
            ThisExpenseDetail.JOB_NBR = DBInt(dr, 9)
            ThisExpenseDetail.JOB_COMP_NBR = DBInt(dr, 10)
            ThisExpenseDetail.FNC_CODE = DBStr(dr, 11)
            ThisExpenseDetail.QTY = DBInt(dr, 12)
            ThisExpenseDetail.RATE = DBDec(dr, 13)
            ThisExpenseDetail.CC_AMT = DBDec(dr, 14)
            ThisExpenseDetail.AMOUNT = DBDec(dr, 15)
            ThisExpenseDetail.AP_COMMENT = DBStr(dr, 16)
            ThisExpenseDetail.CREATE_USER_ID = DBStr(dr, 17)
            ThisExpenseDetail.MOD_USER_ID = DBStr(dr, 18)
            ThisExpenseDetail.MOD_DATE = DBDate(dr, 19)
        End If

        dr.Close()

        Return ThisExpenseDetail

    End Function
    Public Function GetExpenseReportExport(ByVal p_INV_NBR As Integer) As String
        Dim ThisExpenseHeader As ExpenseHeader
        Dim ThisExpenseDetail As ExpenseDetail
        Dim Total As Decimal
        Dim ReturnString As String

        ThisExpenseHeader = GetExpenseHeader(p_INV_NBR, True)

        For Each ThisExpenseDetail In ThisExpenseHeader.ExpenseDetails
            If ThisExpenseDetail.CC_FLAG = False Then
                Total = Total + ThisExpenseDetail.AMOUNT
            End If
        Next

        For Each ThisExpenseDetail In ThisExpenseHeader.ExpenseDetails
            'ST:    Char(34) is a quote, in this case, used to create the csv file
            'ex:    "empcode","inv_nbr",....etc.
            '       commas are getting hard-coded into the string
            ReturnString &= Chr(34) & ThisExpenseHeader.EMP_CODE & Chr(34) & ","        ' VN_CODE (EMP_CODE)
            ReturnString &= ThisExpenseHeader.INV_NBR & ","                             ' AP_INV_VCHR
            ReturnString &= Chr(34) & ThisExpenseHeader.INV_DATE & Chr(34) & ","        ' AP_INV_DATE
            ReturnString &= Chr(34) & ThisExpenseHeader.VN_CODE & Chr(34) & ","         ' VN_CODE
            ReturnString &= Chr(34) & ThisExpenseHeader.EXP_DESC & Chr(34) & ","        ' AP_DESC
            ReturnString &= Total.ToString() & ","                                        ' AP_INV_AMT
            If ThisExpenseDetail.JOB_NBR > 0 Then                                       ' JOB_NUMBER
                ReturnString &= ThisExpenseDetail.JOB_NBR.ToString
            End If
            ReturnString &= ","
            If ThisExpenseDetail.JOB_COMP_NBR > 0 Then                                  ' JOB_COMPONENT_NBR
                ReturnString &= ThisExpenseDetail.JOB_COMP_NBR.ToString
            End If
            ReturnString &= ","
            ReturnString &= Chr(34) & ThisExpenseDetail.FNC_CODE & Chr(34) & ","        ' FNC_CODE
            ReturnString &= ThisExpenseDetail.AMOUNT.ToString() & ","                     ' AP_PROD_EXT_AMT
            'ReturnString &= ThisExpenseDetail.LINE_NBR.ToString()& ","                   '

            'ST: original
            'ReturnString &= Chr(34) & ThisExpenseDetail.ITEM_DESC & Chr(34)             ' AP_Comment

            'Modified by Sam Tran on 2006/06/06
            '	replacement code for bug #29
            If ThisExpenseDetail.AP_COMMENT = "" Or ThisExpenseDetail.AP_COMMENT Is Nothing Or ThisExpenseDetail.AP_COMMENT.Length <= 0 Then
                ReturnString &= Chr(34) & ThisExpenseHeader.EXP_DESC & " - " & ThisExpenseDetail.ITEM_DATE & " - " & ThisExpenseDetail.ITEM_DESC & Chr(34)
            Else
                ReturnString &= Chr(34) & ThisExpenseDetail.AP_COMMENT & Chr(34)
            End If


            ReturnString &= vbCrLf
        Next

        Return ReturnString

    End Function
    Public Function GetAllExpenseDetail() As ExpenseDetails
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "dbo.usp_wv_exp_SelectEXPENSE_DETAILsAll")
        Catch
            Err.Raise(9999, "Class:cExpenseDetail Routine:GetAllExpenseDetail", Err.Description)
        End Try

        Return EDCollectionFromDR(dr)

    End Function
    Public Function GetAllExpenseDetailByExpID(ByVal p_INV_NBR As Integer) As ExpenseDetails
        Dim dr As SqlDataReader
        Dim ThisExpenseHeader As ExpenseHeader

        Dim paramINV_NBR As New SqlParameter("@ExpID", SqlDbType.Int, 0)
        paramINV_NBR.Value = p_INV_NBR

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "dbo.usp_wv_exp_SelectEXPENSE_DETAILbyExpenseID", paramINV_NBR)
        Catch
            Err.Raise(9999, "Class:cExpenseHeader Routine:GetAllExpenseDetailByExpID", Err.Description)
        End Try

        Return EDCollectionFromDR(dr)

    End Function
    Public Function GetAllExpenseDetailByExpIDWithCredit(ByVal p_INV_NBR As Integer) As ExpenseDetails
        Dim dr As SqlDataReader
        Dim ThisExpenseHeader As ExpenseHeader

        Dim paramINV_NBR As New SqlParameter("@ExpID", SqlDbType.Int, 0)
        paramINV_NBR.Value = p_INV_NBR

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "dbo.usp_wv_exp_SelectEXPENSE_DETAILbyExpenseID_withcredit", paramINV_NBR)
        Catch
            Err.Raise(9999, "Class:cExpenseHeader Routine:GetAllExpenseDetailByExpID", Err.Description)
        End Try

        Return EDCollectionFromDR(dr)

    End Function
    Public Function DeleteExpenseDetail(ByVal p_EXPDETAILID As Integer) As Boolean
        Dim oSQL As SqlHelper
        Dim MyReturn As Boolean

        Dim paramEXPDETAILID As New SqlParameter("@EXPDETAILID", SqlDbType.Int, 0)
        paramEXPDETAILID.Value = p_EXPDETAILID

        Try
            If oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "dbo.usp_wv_exp_DeleteEXPENSE_DETAIL", paramEXPDETAILID) > 0 Then
                MyReturn = True
            Else
                MyReturn = False
            End If
        Catch
            Err.Raise(9999, "Class:cExpenseDetail Routine:DeleteExpenseDetail", Err.Description)
        End Try

        Return MyReturn

    End Function
    Public Function UpdateExpenseDetail(ByVal pExpenseDetail As ExpenseDetail) As Boolean
        Dim arParams(9) As SqlParameter
        Dim myReturn As Integer

        Dim paramEXPDETAILID As New SqlParameter("@EXPDETAILID", SqlDbType.Int, 0)
        paramEXPDETAILID.Value = pExpenseDetail.EXPDETAILID
        arParams(0) = paramEXPDETAILID
        Dim paramITEM_DATE As New SqlParameter("@ITEM_DATE", SqlDbType.DateTime, 0)
        paramITEM_DATE.Value = CType(pExpenseDetail.ITEM_DATE, Date).ToShortDateString
        arParams(1) = paramITEM_DATE
        Dim paramITEM_DESC As New SqlParameter("@ITEM_DESC", SqlDbType.VarChar, 200)
        paramITEM_DESC.Value = pExpenseDetail.ITEM_DESC
        arParams(2) = paramITEM_DESC
        Dim paramCC_FLAG As New SqlParameter("@CC_FLAG", SqlDbType.Bit, 0)
        paramCC_FLAG.Value = pExpenseDetail.CC_FLAG
        arParams(3) = paramCC_FLAG
        Dim paramQTY As New SqlParameter("@QTY", SqlDbType.Int, 0)
        paramQTY.Value = pExpenseDetail.QTY
        arParams(4) = paramQTY
        Dim paramRATE As New SqlParameter("@RATE", SqlDbType.Decimal, 0)
        paramRATE.Value = pExpenseDetail.RATE
        arParams(5) = paramRATE
        Dim paramAMOUNT As New SqlParameter("@AMOUNT", SqlDbType.Decimal, 0)
        paramAMOUNT.Value = pExpenseDetail.AMOUNT
        arParams(6) = paramAMOUNT
        Dim paramMOD_USER_ID As New SqlParameter("@MOD_USER_ID", SqlDbType.VarChar, 100)
        paramMOD_USER_ID.Value = pExpenseDetail.MOD_USER_ID
        arParams(7) = paramMOD_USER_ID
        Dim paramMOD_DATE As New SqlParameter("@MOD_DATE", SqlDbType.DateTime, 0)
        paramMOD_DATE.Value = pExpenseDetail.MOD_DATE
        arParams(8) = paramMOD_DATE

        Try
            myReturn = oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "dbo.usp_wv_exp_UpdateEXPENSE_DETAIL", arParams)
        Catch ex As Exception
            Err.Raise(9999, "Class:cExpenseDetail Routine:UpdateExpenseDetail", Err.Description)
        End Try

        If myReturn > 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function InsertExpenseDetail(ByVal pExpenseDetail As ExpenseDetail) As Integer
        Dim arParams(17) As SqlParameter


        Dim paramINV_NBR As New SqlParameter("@INV_NBR", SqlDbType.VarChar, 25)
        paramINV_NBR.Value = pExpenseDetail.INV_NBR
        arParams(0) = paramINV_NBR
        Dim paramITEM_DATE As New SqlParameter("@ITEM_DATE", SqlDbType.DateTime, 0)
        paramITEM_DATE.Value = CType(pExpenseDetail.ITEM_DATE, Date).ToShortDateString
        arParams(1) = paramITEM_DATE
        Dim paramITEM_DESC As New SqlParameter("@ITEM_DESC", SqlDbType.VarChar, 200)
        paramITEM_DESC.Value = pExpenseDetail.ITEM_DESC
        arParams(2) = paramITEM_DESC
        Dim paramCC_FLAG As New SqlParameter("@CC_FLAG", SqlDbType.Bit, 0)
        paramCC_FLAG.Value = pExpenseDetail.CC_FLAG
        arParams(3) = paramCC_FLAG
        Dim paramCL_CODE As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
        paramCL_CODE.Value = pExpenseDetail.CL_CODE
        arParams(4) = paramCL_CODE
        Dim paramDIV_CODE As New SqlParameter("@DIV_CODE", SqlDbType.VarChar, 6)
        paramDIV_CODE.Value = pExpenseDetail.DIV_CODE
        arParams(5) = paramDIV_CODE
        Dim paramPRD_CODE As New SqlParameter("@PRD_CODE", SqlDbType.VarChar, 6)
        paramPRD_CODE.Value = pExpenseDetail.PRD_CODE
        arParams(6) = paramPRD_CODE
        Dim paramJOB_NBR As New SqlParameter("@JOB_NBR", SqlDbType.Int, 0)
        If pExpenseDetail.JOB_NBR = 0 Then
            paramJOB_NBR.Value = DBNull.Value
        Else
            paramJOB_NBR.Value = pExpenseDetail.JOB_NBR
        End If
        arParams(7) = paramJOB_NBR
        Dim paramJOB_COMP_NBR As New SqlParameter("@JOB_COMP_NBR", SqlDbType.SmallInt, 0)
        If pExpenseDetail.JOB_COMP_NBR = 0 Then
            paramJOB_COMP_NBR.Value = DBNull.Value
        Else
            paramJOB_COMP_NBR.Value = pExpenseDetail.JOB_COMP_NBR
        End If
        arParams(8) = paramJOB_COMP_NBR
        Dim paramFNC_CODE As New SqlParameter("@FNC_CODE", SqlDbType.VarChar, 6)
        paramFNC_CODE.Value = pExpenseDetail.FNC_CODE
        arParams(9) = paramFNC_CODE
        Dim paramQTY As New SqlParameter("@QTY", SqlDbType.Int, 0)
        paramQTY.Value = pExpenseDetail.QTY
        arParams(10) = paramQTY
        Dim paramRATE As New SqlParameter("@RATE", SqlDbType.Decimal, 0)
        paramRATE.Value = pExpenseDetail.RATE
        arParams(11) = paramRATE
        Dim paramCC_AMT As New SqlParameter("@CC_AMT", SqlDbType.Decimal, 0)
        paramCC_AMT.Value = pExpenseDetail.CC_AMT
        arParams(12) = paramCC_AMT
        Dim paramAMOUNT As New SqlParameter("@AMOUNT", SqlDbType.Decimal, 0)
        paramAMOUNT.Value = pExpenseDetail.AMOUNT
        arParams(13) = paramAMOUNT
        Dim paramAP_COMMENT As New SqlParameter("@AP_COMMENT", SqlDbType.VarChar, 100)
        paramAP_COMMENT.Value = pExpenseDetail.AP_COMMENT
        arParams(14) = paramAP_COMMENT
        Dim paramCREATE_USER_ID As New SqlParameter("@CREATE_USER_ID", SqlDbType.VarChar, 100)
        paramCREATE_USER_ID.Value = pExpenseDetail.CREATE_USER_ID
        arParams(15) = paramCREATE_USER_ID
        Dim paramMOD_USER_ID As New SqlParameter("@MOD_USER_ID", SqlDbType.VarChar, 100)
        paramMOD_USER_ID.Value = pExpenseDetail.MOD_USER_ID
        arParams(16) = paramMOD_USER_ID
        Dim paramMOD_DATE As New SqlParameter("@MOD_DATE", SqlDbType.DateTime, 0)
        paramMOD_DATE.Value = pExpenseDetail.MOD_DATE
        arParams(17) = paramMOD_DATE

        Try
            Return CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "dbo.usp_wv_exp_InsertEXPENSE_DETAIL", arParams))
        Catch ex As Exception
            Err.Raise(9999, "Class:cExpenseDetail Routine:InsertExpenseDetail", Err.Description)
        End Try

    End Function
    Private Function EDCollectionFromDR(ByVal dr As SqlDataReader) As ExpenseDetails
        Dim ThisExpenseDetail As ExpenseDetail
        Dim TheseExpenseDetails As New ExpenseDetails

        Try
            If dr.HasRows = True Then
                Do While dr.Read
                    ThisExpenseDetail = New ExpenseDetail
                    ThisExpenseDetail.EXPDETAILID = dr(0)
                    ThisExpenseDetail.INV_NBR = dr(1)
                    ThisExpenseDetail.LINE_NBR = dr(2)
                    ThisExpenseDetail.ITEM_DATE = DBDate(dr, 3)
                    ThisExpenseDetail.ITEM_DESC = DBStr(dr, 4)
                    ThisExpenseDetail.CC_FLAG = dr(5)
                    ThisExpenseDetail.CL_CODE = DBStr(dr, 6)
                    ThisExpenseDetail.CL_NAME = DBStr(dr, 7)
                    ThisExpenseDetail.DIV_CODE = DBStr(dr, 8)
                    ThisExpenseDetail.PRD_CODE = DBStr(dr, 9)
                    ThisExpenseDetail.JOB_NBR = DBInt(dr, 10)
                    ThisExpenseDetail.JOB_COMP_NBR = DBInt(dr, 11)
                    ThisExpenseDetail.JOB_COMP_DESC = DBStr(dr, 12)
                    ThisExpenseDetail.FNC_CODE = DBStr(dr, 13)
                    ThisExpenseDetail.FNC_DESCRIPTION = DBStr(dr, 14)
                    ThisExpenseDetail.QTY = DBInt(dr, 15)
                    ThisExpenseDetail.RATE = DBDec(dr, 16)
                    ThisExpenseDetail.CC_AMT = DBDec(dr, 17)
                    ThisExpenseDetail.AMOUNT = DBDec(dr, 18)
                    ThisExpenseDetail.AP_COMMENT = DBStr(dr, 19)
                    ThisExpenseDetail.CREATE_USER_ID = DBStr(dr, 20)
                    ThisExpenseDetail.MOD_USER_ID = DBStr(dr, 21)
                    ThisExpenseDetail.MOD_DATE = DBDate(dr, 22)
                    TheseExpenseDetails.Add(ThisExpenseDetail)
                Loop
            End If
        Catch
            Err.Raise(9999, "Class:cExpenseDetail Routine:CollectionFromDR", Err.Description)
        End Try

        dr.Close()

        Return TheseExpenseDetails

    End Function

    Public Function GetExpenseLineItemCount(ByVal INV_NBR As String) As Integer
        Dim lineItems As Integer
        Dim dr As SqlDataReader
        Dim strSQL As String
        Dim oSQL As SqlHelper

        lineItems = 0
        strSQL = "SELECT COUNT(*) FROM EXPENSE_DETAIL WHERE INV_NBR = " & INV_NBR

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, strSQL)
            dr.Read()

            lineItems = dr.GetInt32(0)
        Catch
            Err.Raise(Err.Number, "Class:cExpense Routine:GetExpenseLineItemCount", Err.Description)
        Finally
        End Try

        Return lineItems

    End Function

    Public Function GetExpenseHeader(ByVal p_INV_NBR As Integer, ByVal WithCreditLine As Boolean) As ExpenseHeader
        Dim dr As SqlDataReader
        Dim ThisExpenseHeader As ExpenseHeader
        Dim appr_flag, sub_flag As Int16
        Dim arP(2) As SqlParameter

        Dim paramINV_NBR As New SqlParameter("@INV_NBR", SqlDbType.Int)
        paramINV_NBR.Value = p_INV_NBR
        arP(0) = paramINV_NBR

        Dim pUserId As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
        pUserId.Value = HttpContext.Current.Session("UserCode").ToString()
        arP(1) = pUserId

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_exp_SelectEXPENSE_HEADER", arP)
        Catch
            Err.Raise(9999, "Class:cExpenseHeader Routine:DeleteExpenseHeader", Err.Description)
        End Try

        ThisExpenseHeader = New ExpenseHeader
        If dr.HasRows = True Then
            dr.Read()
            ThisExpenseHeader.INV_NBR = dr(0)
            ThisExpenseHeader.EMP_CODE = DBStr(dr, 1)
            ThisExpenseHeader.VN_CODE = DBStr(dr, 2)
            ThisExpenseHeader.INV_DATE = DBDate(dr, 3)
            ThisExpenseHeader.EXP_DESC = DBStr(dr, 4)
            ThisExpenseHeader.DTL_DESC = DBStr(dr, 5)
            ThisExpenseHeader.DATE_FROM = DBDate(dr, 6)
            ThisExpenseHeader.DATE_TO = DBDate(dr, 7)
            ThisExpenseHeader.INV_AMOUNT = DBDec(dr, 8)
            ThisExpenseHeader.APPROVED_BY = DBStr(dr, 9)
            ThisExpenseHeader.APPROVED_DATE = DBDate(dr, 10)
            ThisExpenseHeader.STATUS = dr(11)
            ThisExpenseHeader.EmployeeName = DBStr(dr, 12)
            sub_flag = DBInt(dr, 13)
            appr_flag = DBInt(dr, 14)
            ThisExpenseHeader.SUBMITTED_FLAG = CStr(sub_flag)
            ThisExpenseHeader.APPROVED_FLAG = CStr(appr_flag)
            ThisExpenseHeader.TOTAL_EXPENSES = DBDec(dr, 15)
            ThisExpenseHeader.TOTAL_DUE = DBDec(dr, 16)


            setStatusCalc(ThisExpenseHeader)
            ThisExpenseHeader.STATUS_CALC_DESC = getStatusCalcDesc(ThisExpenseHeader.STATUS_CALC)
        End If

        dr.Close()

        If WithCreditLine = True Then
            ThisExpenseHeader.ExpenseDetails = GetAllExpenseDetailByExpIDWithCredit(p_INV_NBR)
        Else
            ThisExpenseHeader.ExpenseDetails = GetAllExpenseDetailByExpID(p_INV_NBR)
        End If

        Return ThisExpenseHeader

    End Function
    Public Function GetAllExpenseHeader() As ExpenseHeaders
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "dbo.usp_wv_exp_SelectEXPENSE_HEADERsAll")
        Catch
            Err.Raise(9999, "Class:cExpenseHeader Routine:GetAllExpenseHeader", Err.Description)
        End Try

        Return EHCollectionFromDR(dr)

    End Function
    Public Function DeleteExpenseHeader(ByVal p_INV_NBR As Integer) As Boolean
        Dim oSQL As SqlHelper
        Dim MyReturn As Boolean

        Dim paramINV_NBR As New SqlParameter("@INV_NBR", SqlDbType.Int, 0)
        paramINV_NBR.Value = p_INV_NBR

        Try
            If oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "dbo.usp_wv_exp_DeleteEXPENSE_HEADER", paramINV_NBR) > 0 Then
                MyReturn = True
            Else
                MyReturn = False
            End If
        Catch
            Err.Raise(9999, "Class:cExpenseHeader Routine:DeleteExpenseHeader", Err.Description)
        End Try

        Return MyReturn

    End Function
    Public Function UpdateExpenseHeader(ByVal pExpenseHeader As ExpenseHeader) As Boolean
        Dim arParams(4) As SqlParameter
        Dim myReturn As Integer

        Dim paramINV_NBR As New SqlParameter("@INV_NBR", SqlDbType.Int, 0)
        paramINV_NBR.Value = pExpenseHeader.INV_NBR
        arParams(0) = paramINV_NBR
        Dim paramINV_DATE As New SqlParameter("@INV_DATE", SqlDbType.DateTime, 0)
        paramINV_DATE.Value = pExpenseHeader.INV_DATE
        arParams(1) = paramINV_DATE
        Dim paramEXP_DESC As New SqlParameter("@EXP_DESC", SqlDbType.VarChar, 30)
        paramEXP_DESC.Value = pExpenseHeader.EXP_DESC
        arParams(2) = paramEXP_DESC
        Dim paramDTL_DESC As New SqlParameter("@DTL_DESC", SqlDbType.Text, 2147483647)
        paramDTL_DESC.Value = pExpenseHeader.DTL_DESC
        arParams(3) = paramDTL_DESC

        Try
            myReturn = oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "dbo.usp_wv_exp_UpdateEXPENSE_HEADER", arParams)
        Catch ex As Exception
            Err.Raise(9999, "Class:cExpenseHeader Routine:UpdateExpenseHeader", Err.Description)
        End Try

        If myReturn > 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function InsertExpenseHeader(ByVal pExpenseHeader As ExpenseHeader) As Integer
        Dim arParams(4) As SqlParameter

        Dim paramEMP_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
        paramEMP_CODE.Value = pExpenseHeader.EMP_CODE
        arParams(0) = paramEMP_CODE
        Dim paramINV_DATE As New SqlParameter("@INV_DATE", SqlDbType.DateTime, 0)
        paramINV_DATE.Value = pExpenseHeader.INV_DATE
        arParams(1) = paramINV_DATE
        Dim paramEXP_DESC As New SqlParameter("@EXP_DESC", SqlDbType.VarChar, 30)
        paramEXP_DESC.Value = pExpenseHeader.EXP_DESC
        arParams(2) = paramEXP_DESC
        Dim paramDTL_DESC As New SqlParameter("@DTL_DESC", SqlDbType.Text, 2147483647)
        paramDTL_DESC.Value = pExpenseHeader.DTL_DESC
        arParams(3) = paramDTL_DESC

        Try
            Return CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "dbo.usp_wv_exp_InsertEXPENSE_HEADER", arParams))
        Catch ex As Exception
            Err.Raise(9999, "Class:cExpenseHeader Routine:InsertExpenseHeader", Err.Description)
        End Try

    End Function
    Private Function EHCollectionFromDR(ByVal dr As SqlDataReader) As ExpenseHeaders
        Dim ThisExpenseHeader As ExpenseHeader
        Dim TheseExpenseHeaders As New ExpenseHeaders
        Dim appr_flag, sub_flag As Int16

        Try
            If dr.HasRows = True Then
                Do While dr.Read
                    ThisExpenseHeader.INV_NBR = dr(0)
                    ThisExpenseHeader.EMP_CODE = DBStr(dr, 1)
                    ThisExpenseHeader.VN_CODE = DBStr(dr, 2)
                    ThisExpenseHeader.INV_DATE = DBDate(dr, 3)
                    ThisExpenseHeader.EXP_DESC = DBStr(dr, 4)
                    ThisExpenseHeader.DTL_DESC = DBStr(dr, 5)
                    ThisExpenseHeader.DATE_FROM = DBDate(dr, 6)
                    ThisExpenseHeader.DATE_TO = DBDate(dr, 7)
                    ThisExpenseHeader.INV_AMOUNT = DBDec(dr, 8)
                    ThisExpenseHeader.APPROVED_BY = DBStr(dr, 9)
                    ThisExpenseHeader.APPROVED_DATE = DBDate(dr, 10)
                    ThisExpenseHeader.STATUS = dr(11)
                    ThisExpenseHeader.EmployeeName = DBStr(dr, 12)
                    sub_flag = DBInt(dr, 33)
                    appr_flag = DBInt(dr, 34)
                    ThisExpenseHeader.SUBMITTED_FLAG = CStr(sub_flag)
                    ThisExpenseHeader.APPROVED_FLAG = CStr(appr_flag)
                    'ThisExpenseHeader.SUBMITTED_FLAG = DBStr(dr, 33)
                    'ThisExpenseHeader.APPROVED_FLAG = DBStr(dr, 34)
                    TheseExpenseHeaders.Add(ThisExpenseHeader)
                Loop
            End If
        Catch
            Err.Raise(9999, "Class:cExpenseHeader Routine:CollectionFromDR", Err.Description)
        End Try

        dr.Close()

        Return TheseExpenseHeaders

    End Function
    Public Function ExpenseNextInvoiceNBR(ByVal strEmpCode As String) As String
        Dim MyReturn As String
        Dim dr As SqlDataReader

        Dim paramEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        paramEmpCode.Value = strEmpCode

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_exp_ExpHdr_Next_InvoiceNBR", paramEmpCode)

            If dr.HasRows Then
                Do While dr.Read
                    MyReturn = dr("InvoiceNBR")
                Loop
            End If

        Catch
            Err.Raise(9999, "Class:cExpense Routine:ExpenseNextInvoiceNBR", Err.Description)
        End Try

        Return MyReturn

    End Function
    Public Function CheckVendor(ByVal strEmpCode As String) As Boolean
        Dim oSQL As SqlHelper
        Dim MyReturn As String
        Dim dr As SqlDataReader

        Dim paramEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        paramEmpCode.Value = strEmpCode

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_exp_VendorCheck", paramEmpCode)

            If dr.HasRows Then
                Return True
            Else
                Return False
            End If

        Catch
            Err.Raise(9999, "Class:cExpense Routine:VendorCodeCheck", Err.Description)
        End Try

    End Function
    Public Function GetExpenseTotals(ByVal strINVNBR As Integer) As SqlDataReader
        Dim dr As SqlClient.SqlDataReader

        ' Create parameter for stored procedure
        Dim parameterINVNBR As New SqlParameter("@InvoiceNBR", SqlDbType.Int, 0)
        parameterINVNBR.Value = strINVNBR

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_exp_Get_ExpenseDetailTotals", parameterINVNBR)
        Catch
            Err.Raise(Err.Number, "Class:cExpense Routine:GetExpenseTotals", Err.Description)
        End Try

        Return dr

    End Function

    Public Function GetInvoiceDetail(ByVal emp_code As String, ByVal inv_nbr As Integer) As DataSet
        Dim ds As DataSet
        Dim arParams(1) As SqlParameter

        Dim paramEMP_CODE As New SqlParameter("@emp_code", SqlDbType.VarChar, 6)
        paramEMP_CODE.Value = emp_code
        arParams(0) = paramEMP_CODE

        Dim paramINV_DATE As New SqlParameter("@inv_nbr", SqlDbType.Int, 0)
        paramINV_DATE.Value = inv_nbr
        arParams(1) = paramINV_DATE

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_get_inv_dtl", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cExpense Routine:GetInvoiceDetail", Err.Description)
        End Try

        Return ds

    End Function

    Public Function InsertCreditLine(ByVal strINVNBR As Integer) As Boolean
        Dim intReturn As Integer

        ' Create parameter for stored procedure
        Dim parameterINVNBR As New SqlParameter("@InvoiceNBR", SqlDbType.Int, 0)
        parameterINVNBR.Value = strINVNBR

        Try
            intReturn = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_exp_insert_credit_line", parameterINVNBR)
        Catch
            Err.Raise(Err.Number, "Class:cExpense Routine:GetExpenseTotals", Err.Description)
        End Try

        If intReturn = 1 Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function DeleteCreditLine(ByVal strInvNbr As Integer) As Boolean
        Dim intReturn As Integer

        ' Create parameter for stored procedure
        Dim parameterINVNBR As New SqlParameter("@InvoiceNBR", SqlDbType.Int, 0)
        parameterINVNBR.Value = strInvNbr

        Try
            intReturn = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_exp_delete_credit_line", parameterINVNBR)
        Catch
            Err.Raise(Err.Number, "Class:cExpense Routine:GetExpenseTotals", Err.Description)
        End Try

        If intReturn > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function GetFunctionRate(ByVal FunctionCode As String) As Decimal
        Dim MyReturn As Decimal

        Dim paramEmpCode As New SqlParameter("@FunctionCode", SqlDbType.VarChar, 6)
        paramEmpCode.Value = FunctionCode

        Try
            MyReturn = Convert.ToDecimal(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_function_getrate", paramEmpCode))
        Catch
            Return 0.0
        End Try

        Return MyReturn
    End Function

    Public Function SuperApprovalNeeded(ByVal empCode As String) As Boolean
        Dim SQL As String
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper

        SQL = "SELECT ISNULL(SUPERVISOR_CODE, '') AS SUPERVISOR_CODE,  ISNULL(EXP_APPR_REQ,0) AS EXP_APPR_REQ "
        SQL += " FROM EMPLOYEE WHERE EMP_CODE = '" & empCode & "'"

        Dim superCode As String = ""
        Dim SuperReq As Int16 = 0
        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL)
            If dr.HasRows Then
                dr.Read()
                superCode = dr.GetString(0)
                SuperReq = dr.GetInt16(1)
            End If
        Catch
            Err.Raise(Err.Number, "Class:cExpense Routine:SuperApprovalNeeded", Err.Description)
        End Try

        If SuperReq = 1 And superCode <> "" Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function UpdateStatus(ByVal ReportID As Integer, ByVal pStatus As ExpenseStatus, ByVal Submitted As Int16, ByVal Approved As Int16) As Boolean
        Dim arParams(3) As SqlParameter
        Dim myReturn As Integer

        Dim paramINV_NBR As New SqlParameter("@INV_NBR", SqlDbType.Int, 0)
        paramINV_NBR.Value = ReportID
        arParams(0) = paramINV_NBR
        Dim paramStatus As New SqlParameter("@Status", SqlDbType.Int, 0)
        paramStatus.Value = pStatus
        arParams(1) = paramStatus
        Dim paramSubmitted As New SqlParameter("@Submitted", SqlDbType.Int, 0)
        paramSubmitted.Value = Submitted
        arParams(2) = paramSubmitted
        Dim paramApproved As New SqlParameter("@Approved", SqlDbType.Int, 0)
        paramApproved.Value = Approved
        arParams(3) = paramApproved

        Try
            myReturn = oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "dbo.usp_wv_exp_UpdateHeaderStatus", arParams)
        Catch ex As Exception
            Err.Raise(9999, "Class:cExpenseHeader Routine:UpdateExpenseHeader", Err.Description)
        End Try

        If myReturn > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function DBStr(ByRef dr As SqlDataReader, ByVal Index As Integer) As String
        If IsDBNull(dr(Index)) = True Then
            Return ""
        Else
            Return CStr(dr(Index))
        End If
    End Function
    Private Function DBDate(ByRef dr As SqlDataReader, ByVal Index As Integer) As String
        If IsDBNull(dr(Index)) = True Then
            Return ""
        Else
            Return CDate(LoGlo.FormatDate(dr(Index))).ToShortDateString
        End If

    End Function
    Private Function DBInt(ByRef dr As SqlDataReader, ByVal Index As Integer) As Integer
        If IsDBNull(dr(Index)) = True Then
            Return 0
        Else
            Return CInt(dr(Index))
        End If
    End Function
    Private Function DBDec(ByRef dr As SqlDataReader, ByVal Index As Integer) As Decimal
        If IsDBNull(dr(Index)) = True Then
            Return 0
        Else
            Return CDec(dr(Index))
        End If
    End Function
    Public Sub New(ByVal ConnectionString As String)
        mConnString = ConnectionString
    End Sub
End Class


