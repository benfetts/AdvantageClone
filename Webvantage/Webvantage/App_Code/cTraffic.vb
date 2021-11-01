Imports System.Data
Imports System.Data.SqlClient
Imports MyGeneration.dOOdads

<Serializable()> Public Class TrafficEditRowForUpdate
    Dim mRowID As Int32
    Dim mTaskStatus As String
    Dim mEmpCode As String
    Dim mStartDate As Date
    Dim mRevDateDue As Date
    Dim mRevTimeDue As String
    Dim mCompDate As Date
    Dim mTaskComments As String
    Dim mJobRowID As Int32
    Dim mJobComments As String
    Dim mJobStatus As String
    Dim mJobCompDate As Date
    Dim mTaskTempDate As Date
    Dim mPhaseID As Integer

    Public Enum GantChartData
        StartDate = 1
        Populated = 2
        EndDate = 3
        NonPopulated = 4
        StartEndDate = 5
    End Enum

    Public Property RowID() As Int32
        Get
            Return mRowID
        End Get
        Set(ByVal Value As Int32)
            mRowID = Value
        End Set
    End Property
    Public Property PhaseID() As Integer
        Get
            Return mPhaseID
        End Get
        Set(ByVal value As Integer)
            mPhaseID = value
        End Set
    End Property
    Public Property TaskStatus() As String
        Get
            Return mTaskStatus
        End Get
        Set(ByVal Value As String)
            mTaskStatus = Value
        End Set
    End Property
    Public Property EmpCode() As String
        Get
            Return mEmpCode
        End Get
        Set(ByVal Value As String)
            mEmpCode = Value
        End Set
    End Property
    Public Property StartDate() As Date
        Get
            Return mStartDate
        End Get
        Set(ByVal Value As Date)
            mStartDate = Value
        End Set
    End Property
    Public Property RevDateDue() As Date
        Get
            Return mRevDateDue
        End Get
        Set(ByVal Value As Date)
            mRevDateDue = Value
        End Set
    End Property
    Public Property RevTimeDue() As String
        Get
            Return mRevTimeDue
        End Get
        Set(ByVal Value As String)
            mRevTimeDue = Value
        End Set
    End Property
    Public Property CompDate() As Date
        Get
            Return mCompDate
        End Get
        Set(ByVal Value As Date)
            mCompDate = Value
        End Set
    End Property
    Public Property TaskComments() As String
        Get
            Return mTaskComments
        End Get
        Set(ByVal Value As String)
            mTaskComments = Value
        End Set
    End Property
    Public Property JobRowID() As Int32
        Get
            Return mJobRowID
        End Get
        Set(ByVal Value As Int32)
            mJobRowID = Value
        End Set
    End Property
    Public Property JobComments() As String
        Get
            Return mJobComments
        End Get
        Set(ByVal Value As String)
            mJobComments = Value
        End Set
    End Property
    Public Property JobStatus() As String
        Get
            Return mJobStatus
        End Get
        Set(ByVal Value As String)
            mJobStatus = Value
        End Set
    End Property
    Public Property JobCompDate() As Date
        Get
            Return mJobCompDate
        End Get
        Set(ByVal Value As Date)
            mJobCompDate = Value
        End Set
    End Property
    Public Property TaskTempDate() As Date
        Get
            Return mTaskTempDate
        End Get
        Set(ByVal Value As Date)
            mTaskTempDate = Value
        End Set
    End Property
    Sub New()
        mRowID = 0
        mTaskStatus = ""
        mEmpCode = ""
        mStartDate = Date.MinValue
        mRevDateDue = Date.MinValue
        mRevTimeDue = ""
        mCompDate = Date.MinValue
        mTaskComments = ""
        mJobRowID = 0
        mJobComments = ""
        mJobStatus = ""
        mJobCompDate = Date.MinValue
        mTaskTempDate = Date.MinValue
        mPhaseID = 0
    End Sub
End Class

<Serializable()> Public Class TrafficEditRowsForUpdate
    Inherits CollectionBase
    Default Public Property Item(ByVal index As Integer) As TrafficEditRowForUpdate
        Get
            Return CType(List(index), TrafficEditRowForUpdate)
        End Get
        Set(ByVal Value As TrafficEditRowForUpdate)
            List(index) = Value
        End Set
    End Property
    Public Function Add(ByVal value As TrafficEditRowForUpdate) As Integer
        Return List.Add(value)
    End Function
    Public Function IndexOf(ByVal value As TrafficEditRowForUpdate) As Integer
        Return List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As TrafficEditRowForUpdate)
        List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As TrafficEditRowForUpdate)
        List.Remove(value)
    End Sub
    Public Function Contains(ByVal value As TrafficEditRowForUpdate) As Boolean
        Return List.Contains(value)
    End Function
End Class

<Serializable()> Public Class cTraffic
    Dim mConnString As String
    Dim mUserID As String
    Dim oSQL As SqlHelper
    Public Function GetTrafficEdit(ByVal ClientCode As String, _
                                    ByVal DivCode As String, _
                                    ByVal ProdCode As String, _
                                    ByVal JobCode As String, _
                                    ByVal JobComp As String, _
                                    ByVal EmpCode As String, _
                                    ByVal AE As String, _
                                    ByVal Role As String, _
                                    ByVal TaskCode As String, _
                                    ByVal DueDate As Date, _
                                    ByVal IncludeTaskCompleted As Boolean, _
                                    ByVal OnlyTempCompleted As Boolean, _
                                    ByVal ExcludeProjected As Boolean, _
                                    Optional ByVal SortOrder As Integer = 0) As DataSet
        Dim ds As DataSet = New DataSet

        ' Create Instance of Connection and Command Object
        Dim myConnection As New SqlConnection(mConnString)
        Dim myCommand As New SqlCommand("usp_wv_traffic_edit_getgrid", myConnection)
        Dim myAdapter As New SqlDataAdapter(myCommand)

        ' Mark the Command as a SPROC
        myCommand.CommandType = CommandType.StoredProcedure

        ' Add Parameters to SPROC
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 6)
        parameterUserID.Value = mUserID
        myCommand.Parameters.Add(parameterUserID)

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        myCommand.Parameters.Add(parameterClientCode)

        Dim parameterDivCode As New SqlParameter("@DivCode", SqlDbType.VarChar, 6)
        parameterDivCode.Value = DivCode
        myCommand.Parameters.Add(parameterDivCode)

        Dim parameterProdCode As New SqlParameter("@ProdCode", SqlDbType.VarChar, 6)
        parameterProdCode.Value = ProdCode
        myCommand.Parameters.Add(parameterProdCode)

        Dim parameterJobCode As New SqlParameter("@JobCode", SqlDbType.VarChar, 6)
        If JobCode.Trim = "" Then
            parameterJobCode.Value = "%"
        Else
            parameterJobCode.Value = JobCode
        End If

        myCommand.Parameters.Add(parameterJobCode)

        Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.VarChar, 6)
        If JobComp.Trim = "" Then
            parameterJobComp.Value = "%"
        Else
            parameterJobComp.Value = JobComp
        End If
        myCommand.Parameters.Add(parameterJobComp)

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = EmpCode
        myCommand.Parameters.Add(parameterEmpCode)

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar, 6)
        parameterAE.Value = AE
        myCommand.Parameters.Add(parameterAE)

        Dim parameterRole As New SqlParameter("@Role", SqlDbType.VarChar, 6)
        parameterRole.Value = Role
        myCommand.Parameters.Add(parameterRole)

        Dim parameterTaskCode As New SqlParameter("@TaskCode", SqlDbType.VarChar, 10)
        parameterTaskCode.Value = TaskCode
        myCommand.Parameters.Add(parameterTaskCode)

        Dim parameterTaskCompDate As New SqlParameter("@TaskCompDate", SqlDbType.VarChar, 10)
        If IncludeTaskCompleted = False Then
            parameterTaskCompDate.Value = "11/12/2072"
        Else
            parameterTaskCompDate.Value = ""
        End If
        myCommand.Parameters.Add(parameterTaskCompDate)

        Dim parameterTaskTempDate As New SqlParameter("@TaskTempDate", SqlDbType.VarChar, 10)
        If OnlyTempCompleted = True Then
            parameterTaskTempDate.Value = "11/12/1905"
        Else
            parameterTaskTempDate.Value = ""
        End If
        myCommand.Parameters.Add(parameterTaskTempDate)

        Dim parameterDueDate As New SqlParameter("@DueDate", SqlDbType.VarChar, 10)
        If DueDate = New Date Then
            parameterDueDate.Value = "11/12/2072"
        Else
            parameterDueDate.Value = DueDate.ToShortDateString
        End If
        myCommand.Parameters.Add(parameterDueDate)

        Dim parameterNotTaskStatus As New SqlParameter("@Type", SqlDbType.Char, 1)
        If ExcludeProjected = True Then
            parameterNotTaskStatus.Value = "P"
        Else
            parameterNotTaskStatus.Value = ""
        End If
        myCommand.Parameters.Add(parameterNotTaskStatus)

        'Dim parameterSortOrder As New SqlParameter("@SortOrder", SqlDbType.Int)
        'parameterSortOrder.Value = SortOrder
        'myCommand.Parameters.Add(parameterSortOrder)

        'Dim parameterSortOrder As New SqlParameter("@SortOrder", SqlDbType.VarChar, 200)
        'Select Case SortOrder
        '    Case 0
        '        parameterSortOrder.Value = "ISNULL(TRAFFIC_PHASE.PHASE_ORDER,-1),JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID DESC,JOB_TRAFFIC_DET.FNC_CODE,JOB_TRAFFIC_DET.TASK_START_DATE,JOB_TRAFFIC_DET.JOB_REVISED_DATE"
        '    Case 1
        '        parameterSortOrder.Value = "ISNULL(TRAFFIC_PHASE.PHASE_ORDER,-1),JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID DESC,JOB_TRAFFIC_DET.TASK_START_DATE,JOB_TRAFFIC_DET.JOB_REVISED_DATE"
        '    Case 2
        '        parameterSortOrder.Value = "ISNULL(TRAFFIC_PHASE.PHASE_ORDER,-1),JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID DESC"
        '    Case Else
        '        parameterSortOrder.Value = "ISNULL(TRAFFIC_PHASE.PHASE_ORDER,-1),JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID DESC,JOB_TRAFFIC_DET.FNC_CODE,JOB_TRAFFIC_DET.TASK_START_DATE,JOB_TRAFFIC_DET.JOB_REVISED_DATE"
        'End Select

        ' Open the database connection and get dr
        Try
            myConnection.Open()
            myAdapter.Fill(ds)
        Catch
            Err.Raise(Err.Number, Err.Source, Err.Description)
        End Try

        Dim dcParents() As DataColumn
        Dim dcChilds() As DataColumn

        dcParents = New DataColumn() {ds.Tables("Table").Columns("JOB_NUMBER"), ds.Tables("Table").Columns("JOB_COMPONENT_NBR")}
        dcChilds = New DataColumn() {ds.Tables("Table1").Columns("JOB_NUMBER"), ds.Tables("Table1").Columns("JOB_COMPONENT_NBR")}

        ds.Relations.Add("TrafficJobNo", dcParents, dcChilds)

        myConnection.Close()
        myConnection.Dispose()

        Return ds
    End Function

    Public Function ValidateEmpCode(ByVal EmpCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateEmpCode" & EmpCode
        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim MyReturn As Integer = 0
                Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
                parameterEmpCode.Value = EmpCode
                Try
                    MyReturn = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_empcode_validate", parameterEmpCode)
                Catch
                    MyReturn = 0
                Finally
                End Try
                If MyReturn = 0 Then
                    IsValid = False
                Else
                    IsValid = True
                End If
            Catch ex As Exception
                IsValid = False
            End Try
            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function IsEmpTerminated(ByVal strEmpCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "IsEmpTerminated" & strEmpCode
        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim iReturn As Integer = 0

                Dim Tparameter As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
                Tparameter.Value = strEmpCode

                Try
                    iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_IsEmpTerminated", Tparameter))
                Catch
                    Err.Raise(Err.Number, "Class:cTraffic Routine:IsEmpActive", Err.Description)
                End Try

                If iReturn > 0 Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch ex As Exception
                IsValid = False
            End Try
            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid
    End Function

    Public Function ValidateJobTrafficStatus(ByVal JobTrafficStatus As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateJobTrafficStatus" & JobTrafficStatus
        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim MyReturn As Integer = 0
                Dim parameterEmpCode As New SqlParameter("@TrafficCode", SqlDbType.VarChar, 10)
                parameterEmpCode.Value = JobTrafficStatus

                Try
                    MyReturn = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_JobTrafficCode_validate", parameterEmpCode)
                Catch
                    MyReturn = 0
                End Try

                If MyReturn = 0 Then
                    IsValid = False
                Else
                    IsValid = True
                End If

            Catch ex As Exception
                IsValid = False
            End Try
            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function GetTimeline(ByVal intJobNumber As Integer, ByVal intJobCompNumber As Integer, ByVal strPeriod As String, Optional ByVal usercode As String = "") As DataSet
        Dim ds As DataSet
        Dim dr As SqlDataReader
        Dim chkStartDate As Date
        Dim chkEndDate As Date
        Dim strPreviousCheck As String

        Dim strStartDate As String, strEndDate As String
        Dim dtchartDates() As Date, i As Integer, j As Integer, k As Integer
        Dim aParms(2) As SqlParameter

        Dim parameterJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        parameterJobNumber.Value = intJobNumber
        aParms(0) = parameterJobNumber

        Dim parameterCompJobNumber As New SqlParameter("@JobComponent", SqlDbType.SmallInt)
        parameterCompJobNumber.Value = intJobCompNumber
        aParms(1) = parameterCompJobNumber

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_traffic_GetMinMaxChartDate", aParms)

            If dr.HasRows Then
                Do While dr.Read
                    If IsDBNull(dr("minStartDate")) Then
                        strStartDate = ""
                        strEndDate = ""
                    Else
                        strStartDate = CStr(dr("minStartDate"))
                        strEndDate = CStr(dr("maxEndDate"))
                    End If
                Loop
            End If

        Catch
            Err.Raise(Err.Number, "Class:cTraffic Routine:GetTimeline", Err.Description)
        Finally
            dr.Close()
        End Try

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_traffic_gettimeline", aParms)
            If strStartDate <> "" Then 'No record for selected job number
                dtchartDates = LoadGanttColumns(strStartDate, strEndDate, GetByPeriod(strPeriod))

                'add the columns to the table based on which period the user is choosing.
                Try
                    For i = 0 To dtchartDates.GetUpperBound(0)
                        ds.Tables(0).Columns.Add(dtchartDates(i).ToString("MM/dd/yy"))
                        If strPeriod = "Month" Then
                            ds.Tables(0).Columns.Add(dtchartDates(i).ToString("MM/yy"))
                        Else
                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                ds.Tables(0).Columns.Add(dtchartDates(i).ToString("MM/dd"))
                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                ds.Tables(0).Columns.Add(dtchartDates(i).ToString("dd/MM"))
                            Else
                                ds.Tables(0).Columns.Add(dtchartDates(i).ToString("dd.MM"))
                            End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                For j = 0 To (ds.Tables(0).Rows.Count - 1)

                    '-------------------------------------------------------------------------
                    'CTB:2006/06/23 - Null dates are causing problems.  Unfortunately, there
                    ' is no nullable date data type in 2003 .NET.  So, for now, store 1/1/1900
                    ' in this field ... this results in records with a start date to display
                    ' red on the Gannt Chart.
                    '-------------------------------------------------------------------------
                    If IsDBNull(ds.Tables(0).Rows(j).Item("Start Date&nbsp;&nbsp;&nbsp;&nbsp;")) Then
                        chkStartDate = #1/1/1900#
                    Else
                        chkStartDate = ds.Tables(0).Rows(j).Item("Start Date&nbsp;&nbsp;&nbsp;&nbsp;")
                    End If

                    If IsDBNull(ds.Tables(0).Rows(j).Item("End Date&nbsp;&nbsp;")) Then
                        chkStartDate = #1/1/1900#
                    Else
                        chkEndDate = ds.Tables(0).Rows(j).Item("End Date&nbsp;&nbsp;")
                    End If

                    ds.Tables(0).Rows(j).Item("Start Date&nbsp;&nbsp;&nbsp;&nbsp;") = ds.Tables(0).Rows(j).Item("Start Date&nbsp;&nbsp;&nbsp;&nbsp;") '& "&nbsp;&nbsp;&nbsp;&nbsp;"
                    'There are times when there will be no start date.  The stored procedure is add the current date.  If the enddate is before the startdate, make the startdate the same day as the end date.
                    If chkStartDate > chkEndDate Then
                        chkStartDate = chkEndDate
                    End If

                    'present the full text for status
                    ds.Tables(0).Rows(j).Item("Status") = GetStatus(ds.Tables(0).Rows(j).Item("Status"))
                    'Dim empcode As String
                    'Dim str As String = ds.Tables(0).Rows(j).Item("EMP_CODE").ToString
                    If IsDBNull(ds.Tables(0).Rows(j).Item("Status")) Then
                        ds.Tables(0).Rows(j).Item("Task Code") = " "
                    Else
                        ds.Tables(0).Rows(j).Item("&nbsp;&nbsp;") = "<a onclick=""Javascript:window.open('task.aspx?JobNo=" & intJobNumber & "&JobComp=" & intJobCompNumber & "&SeqNo=" & ds.Tables(0).Rows(j).Item("SeqNo") & "&type=timeline&EmpCode=" & ds.Tables(0).Rows(j).Item("EMP_CODE") & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=650,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;"""" href="""">" & "<img border=0 src=""Images/Icons/Grey/256/find.png"" class=""icon-image"">" & "</a>&nbsp;"
                    End If

                    'add the images to the timeline date columns.
                    If strPeriod = "Month" Then
                        For k = 0 To dtchartDates.GetUpperBound(0)
                            If chkStartDate.ToString("MM/yy") = dtchartDates(k).ToString("MM/yy") Then
                                If ds.Tables(0).Rows(j).Item("Milestone") = "1" Then
                                    ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/mile_start.gif />"
                                Else
                                    If ds.Tables(0).Rows(j).Item("Milestone") = "2" Then
                                        ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/phase_start.gif />"
                                    Else
                                        ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/task_start.gif />"
                                    End If
                                End If
                                strPreviousCheck = "1"
                            End If
                            If k = dtchartDates.GetUpperBound(0) Then
                                If chkEndDate.ToString("MM/yy") = dtchartDates(k).ToString("MM/yy") Then
                                    If ds.Tables(0).Rows(j).Item("Milestone") = "1" Then
                                        ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/mile_end.gif />"
                                    Else
                                        If ds.Tables(0).Rows(j).Item("Milestone") = "2" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/phase_end.gif />"
                                        Else
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/task_end.gif />"
                                        End If
                                    End If
                                    strPreviousCheck = "3"
                                End If
                                If chkStartDate.ToString("MM/yy") = chkEndDate.ToString("MM/yy") And chkStartDate.ToString("MM/yy") = dtchartDates(k).ToString("MM/yy") Then
                                    If ds.Tables(0).Rows(j).Item("Milestone") = "1" Then
                                        ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/mile_one.gif />"
                                    Else
                                        If ds.Tables(0).Rows(j).Item("Milestone") = "2" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/phase_one.gif />"
                                        Else
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/task_one.gif />"
                                        End If
                                    End If
                                    strPreviousCheck = "4"
                                End If
                                If IsDBNull(ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy"))) Then
                                    ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/transparent_60X15.gif />"
                                End If
                            Else
                                If chkStartDate.ToString("MM/yy") < dtchartDates(k).ToString("MM/yy") And chkEndDate.ToString("MM/yy") > dtchartDates(k).ToString("MM/yy") And strPreviousCheck = "1" Then
                                    If ds.Tables(0).Rows(j).Item("Milestone") = "1" Then
                                        ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/mile_middle.gif />"
                                    Else
                                        If ds.Tables(0).Rows(j).Item("Milestone") = "2" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/phase_middle.gif />"
                                        Else
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/task_middle.gif />"
                                        End If
                                    End If
                                    strPreviousCheck = "2"
                                End If
                                If chkStartDate.ToString("MM/yy") < dtchartDates(k).ToString("MM/yy") And chkEndDate.ToString("MM/yy") > dtchartDates(k).ToString("MM/yy") And strPreviousCheck = "2" Then
                                    If ds.Tables(0).Rows(j).Item("Milestone") = "1" Then
                                        ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/mile_middle.gif />"
                                    Else
                                        If ds.Tables(0).Rows(j).Item("Milestone") = "2" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/phase_middle.gif />"
                                        Else
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/task_middle.gif />"
                                        End If
                                    End If
                                    strPreviousCheck = "2"
                                End If
                                If chkStartDate.ToString("MM/yy") > dtchartDates(k).ToString("MM/yy") And chkStartDate.ToString("MM/yy") < dtchartDates(k + 1).ToString("MM/yy") And strPreviousCheck = "" Then
                                    If ds.Tables(0).Rows(j).Item("Milestone") = "1" Then
                                        ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/mile_start.gif />"
                                    Else
                                        If ds.Tables(0).Rows(j).Item("Milestone") = "2" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/phase_start.gif />"
                                        Else
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/task_start.gif />"
                                        End If
                                    End If
                                    strPreviousCheck = "1"
                                End If
                                If chkEndDate.ToString("MM/yy") > dtchartDates(k).ToString("MM/yy") And chkEndDate.ToString("MM/yy") < dtchartDates(k + 1).ToString("MM/yy") And strPreviousCheck = "1" Then
                                    If ds.Tables(0).Rows(j).Item("Milestone") = "1" Then
                                        ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/mile_end.gif />"
                                    Else
                                        If ds.Tables(0).Rows(j).Item("Milestone") = "2" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/phase_end.gif />"
                                        Else
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/task_end.gif />"
                                        End If
                                    End If
                                    strPreviousCheck = "3"
                                End If
                                If chkEndDate.ToString("MM/yy") > dtchartDates(k).ToString("MM/yy") And chkEndDate.ToString("MM/yy") < dtchartDates(k + 1).ToString("MM/yy") And strPreviousCheck = "2" Then
                                    If ds.Tables(0).Rows(j).Item("Milestone") = "1" Then
                                        ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/mile_end.gif />"
                                    Else
                                        If ds.Tables(0).Rows(j).Item("Milestone") = "2" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/phase_end.gif />"
                                        Else
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/task_end.gif />"
                                        End If
                                    End If
                                    strPreviousCheck = "3"
                                End If
                                If chkEndDate.ToString("MM/yy") = dtchartDates(k).ToString("MM/yy") Then
                                    If ds.Tables(0).Rows(j).Item("Milestone") = "1" Then
                                        ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/mile_end.gif />"
                                    Else
                                        If ds.Tables(0).Rows(j).Item("Milestone") = "2" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/phase_end.gif />"
                                        Else
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/task_end.gif />"
                                        End If
                                    End If
                                    strPreviousCheck = "3"
                                End If
                                If chkStartDate.ToString("MM/yy") = chkEndDate.ToString("MM/yy") And chkStartDate.ToString("MM/yy") = dtchartDates(k).ToString("MM/yy") Then
                                    If ds.Tables(0).Rows(j).Item("Milestone") = "1" Then
                                        ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/mile_one.gif />"
                                    Else
                                        If ds.Tables(0).Rows(j).Item("Milestone") = "2" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/phase_one.gif />"
                                        Else
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/task_one.gif />"
                                        End If
                                    End If
                                    strPreviousCheck = "4"
                                End If
                                If IsDBNull(ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy"))) Then
                                    ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/yy")) = "<img src=Images/transparent_60X15.gif />"
                                End If
                            End If
                        Next
                    Else
                        For k = 0 To dtchartDates.GetUpperBound(0)

                            If chkStartDate = dtchartDates(k) Then
                                If ds.Tables(0).Rows(j).Item("Milestone") = "1" Then
                                    If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                        ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/mile_start.gif />"
                                    ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                        ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/mile_start.gif />"
                                    Else
                                        ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/mile_start.gif />"
                                    End If
                                Else
                                    If ds.Tables(0).Rows(j).Item("Milestone") = "2" Then
                                        If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/phase_start.gif />"
                                        ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/phase_start.gif />"
                                        Else
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/phase_start.gif />"
                                        End If
                                    Else
                                        If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/task_start.gif />"
                                        ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/task_start.gif />"
                                        Else
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/task_start.gif />"
                                        End If
                                    End If
                                End If
                                strPreviousCheck = "1"
                            End If
                            If k = dtchartDates.GetUpperBound(0) Then
                                If chkEndDate = dtchartDates(k) Then
                                    If ds.Tables(0).Rows(j).Item("Milestone") = "1" Then
                                        If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/mile_end.gif />"
                                        ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/mile_end.gif />"
                                        Else
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/mile_end.gif />"
                                        End If
                                    Else
                                        If ds.Tables(0).Rows(j).Item("Milestone") = "2" Then
                                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/phase_end.gif />"
                                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/phase_end.gif />"
                                            Else
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/phase_end.gif />"
                                            End If
                                        Else
                                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/task_end.gif />"
                                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/task_end.gif />"
                                            Else
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/task_end.gif />"
                                            End If
                                        End If
                                    End If
                                    strPreviousCheck = "3"
                                End If
                                If chkStartDate.ToString("MM/dd") = chkEndDate.ToString("MM/dd") And chkStartDate.ToString("MM/dd") = dtchartDates(k).ToString("MM/dd") Then
                                    If ds.Tables(0).Rows(j).Item("Milestone") = "1" Then
                                        If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/mile_one.gif />"
                                        ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/mile_one.gif />"
                                        Else
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/mile_one.gif />"
                                        End If
                                    Else
                                        If ds.Tables(0).Rows(j).Item("Milestone") = "2" Then
                                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/phase_one.gif />"
                                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/phase_one.gif />"
                                            Else
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/phase_one.gif />"
                                            End If
                                        Else
                                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/task_one.gif />"
                                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/task_one.gif />"
                                            Else
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/task_one.gif />"
                                            End If
                                        End If
                                    End If
                                    strPreviousCheck = "4"
                                End If
                                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                    If IsDBNull(ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd"))) Then
                                        ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/transparent_60X15.gif />"
                                    End If
                                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                    If IsDBNull(ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM"))) Then
                                        ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/transparent_60X15.gif />"
                                    End If
                                Else
                                    If IsDBNull(ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM"))) Then
                                        ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/transparent_60X15.gif />"
                                    End If
                                End If

                            Else 'jtg - added "Or"  8/15/08
                                If (chkStartDate > dtchartDates(k) Or chkStartDate = dtchartDates(k)) And chkEndDate < dtchartDates(k + 1) And strPreviousCheck = "" Then
                                    If ds.Tables(0).Rows(j).Item("Milestone") = "1" Then
                                        If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/mile_one.gif />"
                                        ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/mile_one.gif />"
                                        Else
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/mile_one.gif />"
                                        End If
                                    Else
                                        If ds.Tables(0).Rows(j).Item("Milestone") = "2" Then
                                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/phase_one.gif />"
                                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/phase_one.gif />"
                                            Else
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/phase_one.gif />"
                                            End If
                                        Else
                                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/task_one.gif />"
                                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/task_one.gif />"
                                            Else
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/task_one.gif />"
                                            End If
                                        End If
                                    End If
                                    strPreviousCheck = "4"
                                End If
                                If chkStartDate = dtchartDates(k) And chkEndDate < dtchartDates(k + 1) And strPreviousCheck = "1" Then
                                    If ds.Tables(0).Rows(j).Item("Milestone") = "1" Then
                                        If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/mile_one.gif />"
                                        ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/mile_one.gif />"
                                        Else
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/mile_one.gif />"
                                        End If
                                    Else
                                        If ds.Tables(0).Rows(j).Item("Milestone") = "2" Then
                                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/phase_one.gif />"
                                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/phase_one.gif />"
                                            Else
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/phase_one.gif />"
                                            End If
                                        Else
                                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/task_one.gif />"
                                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/task_one.gif />"
                                            Else
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/task_one.gif />"
                                            End If
                                        End If
                                    End If
                                    strPreviousCheck = "4"
                                End If
                                If chkStartDate < dtchartDates(k) And chkEndDate > dtchartDates(k) And strPreviousCheck = "1" Then
                                    If ds.Tables(0).Rows(j).Item("Milestone") = "1" Then
                                        If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/mile_middle.gif />"
                                        ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/mile_middle.gif />"
                                        Else
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/mile_middle.gif />"
                                        End If
                                    Else
                                        If ds.Tables(0).Rows(j).Item("Milestone") = "2" Then
                                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/phase_middle.gif />"
                                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/phase_middle.gif />"
                                            Else
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/phase_middle.gif />"
                                            End If
                                        Else
                                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/task_middle.gif />"
                                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/task_middle.gif />"
                                            Else
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/task_middle.gif />"
                                            End If
                                        End If
                                    End If
                                    strPreviousCheck = "2"
                                End If
                                If chkStartDate < dtchartDates(k) And chkEndDate > dtchartDates(k) And strPreviousCheck = "2" Then
                                    If ds.Tables(0).Rows(j).Item("Milestone") = "1" Then
                                        If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/mile_middle.gif />"
                                        ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/mile_middle.gif />"
                                        Else
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/mile_middle.gif />"
                                        End If
                                    Else
                                        If ds.Tables(0).Rows(j).Item("Milestone") = "2" Then
                                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/phase_middle.gif />"
                                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/phase_middle.gif />"
                                            Else
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/phase_middle.gif />"
                                            End If
                                        Else
                                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/task_middle.gif />"
                                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/task_middle.gif />"
                                            Else
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/task_middle.gif />"
                                            End If
                                        End If
                                    End If
                                    strPreviousCheck = "2"
                                End If
                                If chkStartDate > dtchartDates(k) And chkStartDate < dtchartDates(k + 1) And strPreviousCheck = "" Then
                                    If ds.Tables(0).Rows(j).Item("Milestone") = "1" Then
                                        If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/mile_start.gif />"
                                        ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/mile_start.gif />"
                                        Else
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/mile_start.gif />"
                                        End If
                                    Else
                                        If ds.Tables(0).Rows(j).Item("Milestone") = "2" Then
                                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/phase_start.gif />"
                                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/phase_start.gif />"
                                            Else
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/phase_start.gif />"
                                            End If
                                        Else
                                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/task_start.gif />"
                                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/task_start.gif />"
                                            Else
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/task_start.gif />"
                                            End If
                                        End If
                                    End If
                                    strPreviousCheck = "1"
                                End If
                                If chkEndDate > dtchartDates(k) And chkEndDate < dtchartDates(k + 1) And strPreviousCheck = "1" Then
                                    If ds.Tables(0).Rows(j).Item("Milestone") = "1" Then
                                        If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/mile_end.gif />"
                                        ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/mile_end.gif />"
                                        Else
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/mile_end.gif />"
                                        End If
                                    Else
                                        If ds.Tables(0).Rows(j).Item("Milestone") = "2" Then
                                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/phase_end.gif />"
                                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/phase_end.gif />"
                                            Else
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/phase_end.gif />"
                                            End If
                                        Else
                                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/task_end.gif />"
                                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/task_end.gif />"
                                            Else
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/task_end.gif />"
                                            End If
                                        End If
                                    End If
                                    strPreviousCheck = "3"
                                End If
                                If chkEndDate > dtchartDates(k) And chkEndDate < dtchartDates(k + 1) And strPreviousCheck = "2" Then
                                    If ds.Tables(0).Rows(j).Item("Milestone") = "1" Then
                                        If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/mile_end.gif />"
                                        ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/mile_end.gif />"
                                        Else
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/mile_end.gif />"
                                        End If
                                    Else
                                        If ds.Tables(0).Rows(j).Item("Milestone") = "2" Then
                                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/phase_end.gif />"
                                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/phase_end.gif />"
                                            Else
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/phase_end.gif />"
                                            End If
                                        Else
                                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/task_end.gif />"
                                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/task_end.gif />"
                                            Else
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/task_end.gif />"
                                            End If
                                        End If
                                    End If
                                    strPreviousCheck = "3"
                                End If
                                'jtg - added "And Not" 8/15/08
                                If chkEndDate = dtchartDates(k) And Not (chkStartDate > dtchartDates(k) Or chkStartDate = dtchartDates(k)) Then
                                    If ds.Tables(0).Rows(j).Item("Milestone") = "1" Then
                                        If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/mile_end.gif />"
                                        ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/mile_end.gif />"
                                        Else
                                            ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/mile_end.gif />"
                                        End If
                                    Else
                                        If ds.Tables(0).Rows(j).Item("Milestone") = "2" Then
                                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/phase_end.gif />"
                                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/phase_end.gif />"
                                            Else
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/phase_end.gif />"
                                            End If
                                        Else
                                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/task_end.gif />"
                                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/task_end.gif />"
                                            Else
                                                ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/task_end.gif />"
                                            End If
                                        End If
                                    End If
                                    strPreviousCheck = "3"
                                End If


                                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                    If IsDBNull(ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd"))) Then
                                        ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("MM/dd")) = "<img src=Images/transparent_60X15.gif />"
                                    End If
                                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                    If IsDBNull(ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM"))) Then
                                        ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd/MM")) = "<img src=Images/transparent_60X15.gif />"
                                    End If
                                Else
                                    If IsDBNull(ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM"))) Then
                                        ds.Tables(0).Rows(j).Item(dtchartDates(k).ToString("dd.MM")) = "<img src=Images/transparent_60X15.gif />"
                                    End If
                                End If
                            End If
                        Next
                    End If

                    strPreviousCheck = ""
                Next
                For i = 0 To dtchartDates.GetUpperBound(0)
                    ds.Tables(0).Columns.Remove(dtchartDates(i).ToString("MM/dd/yy"))
                Next

                'ds.Tables(0).DefaultView.Sort = "PhaseOrder, SeqNo"
                'Issue #131 - ATC - Post/QA
                'Added a extra sort field to make sure the Sequence order was correct
                'ds.Tables(0).DefaultView.Sort = "[PhaseOrder],[Start Date&nbsp;&nbsp;&nbsp;&nbsp;],[SeqNo],[End Date&nbsp;&nbsp;], [PhaseDesc]"
                'Silk:Migration #271, ST
                ds.Tables(0).DefaultView.Sort = "[PhaseOrder],[PhaseDesc],[SortID],[End Date&nbsp;&nbsp;],[JOB_ORDER],[SeqNo]" ', [PhaseDesc]"
                'Remove the milestone column before it is bound to the datagrid.
                ds.Tables(0).Columns.Remove("Milestone")
                ds.Tables(0).Columns.Remove("PhaseDesc")
                ds.Tables(0).Columns.Remove("Status")
                ds.Tables(0).Columns.Remove("SeqNo")
                ds.Tables(0).Columns.Remove("PhaseOrder")
                ds.Tables(0).Columns.Remove("SortID")
                ds.Tables(0).Columns.Remove("JOB_ORDER")

            End If

        Catch
            Err.Raise(Err.Number, "Class:cTraffic Routine:GetTimeline", Err.Description)
        End Try

        Return ds
    End Function

    Private Function LoadGanttColumns(ByVal dtStartDate As Date, ByVal dtEndDate As Date, ByVal strByPeriod As String) As Date()
        Dim i As Integer
        Dim intPeriodColumns As Integer = 0
        Dim dtChartDate(intPeriodColumns) As Date

        intPeriodColumns = DateDiff(strByPeriod, dtStartDate, dtEndDate)

        If strByPeriod = "ww" Then
            ReDim dtChartDate(intPeriodColumns + 1)
        Else
            ReDim dtChartDate(intPeriodColumns)
        End If

        dtChartDate(0) = dtStartDate

        For i = 1 To intPeriodColumns
            dtChartDate(i) = DateAdd(strByPeriod, 1, dtChartDate(i - 1))
        Next

        If strByPeriod = "ww" And dtChartDate(intPeriodColumns) < dtEndDate Then
            dtChartDate(intPeriodColumns + 1) = dtEndDate
        Else
            If strByPeriod = "ww" And dtChartDate(intPeriodColumns) >= dtEndDate Then
                ReDim dtChartDate(intPeriodColumns)
                dtChartDate(0) = dtStartDate

                For i = 1 To intPeriodColumns
                    dtChartDate(i) = DateAdd(strByPeriod, 1, dtChartDate(i - 1))
                Next
                dtChartDate(intPeriodColumns) = dtEndDate
            End If
        End If
        Return dtChartDate

    End Function

    Public Function GetJobHeader(ByVal intJobNumber As Integer, ByVal intJobCompNumber As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim aParms(2) As SqlParameter

        Dim parameterJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        parameterJobNumber.Value = intJobNumber
        aParms(0) = parameterJobNumber

        Dim parameterCompJobNumber As New SqlParameter("@JobComponent", SqlDbType.SmallInt)
        parameterCompJobNumber.Value = intJobCompNumber
        aParms(1) = parameterCompJobNumber

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_traffic_getjobheader", aParms)

        Catch
            Err.Raise(Err.Number, "Class:cTraffic Routine:GetTimeline", Err.Description)
        End Try

        Return dr
    End Function

    Private Function GetByPeriod(ByVal strPeriod As String) As String
        If strPeriod = "Week" Then
            Return "ww"
        Else
            If strPeriod = "Month" Then
                Return "m"
            Else
                If strPeriod = "Day" Then
                    Return "y"
                End If
            End If
        End If
    End Function

    Private Function GetStatus(ByVal strStatus As String) As String
        If strStatus = "P" Then
            Return "Projected"
        ElseIf strStatus = "A" Then
            Return "Active"
        ElseIf strStatus = "H" Then
            Return "High Priority"
        ElseIf strStatus = "L" Then
            Return "Low Priority"
        End If
    End Function

    Public Sub New(ByVal ConnectionString As String, ByVal UserID As String)
        mConnString = ConnectionString
        mUserID = UserID
    End Sub

End Class