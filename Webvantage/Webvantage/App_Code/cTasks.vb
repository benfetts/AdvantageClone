Imports System.Data
Imports System.Data.SqlClient

<Serializable()> Public Class cTasks
    Dim mConnString As String
    Dim oSQL As SqlHelper

    Public Function GetAssignments(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, ByVal SeqNum As Integer) As DataTable
        Try
            Dim arParams(3) As SqlParameter

            Dim parameterJob As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            parameterJob.Value = JobNumber
            arParams(0) = parameterJob

            Dim parameterJobComp As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            parameterJobComp.Value = JobComponentNbr
            arParams(1) = parameterJobComp

            Dim parameterSeqNo As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
            parameterSeqNo.Value = SeqNum
            arParams(2) = parameterSeqNo

            Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_GET_TASK_ASSIGNMENTS", "DtTaskAssignments", arParams)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    'Public Function MarkCompleted(ByVal JobNo As Integer, ByVal JobComp As Integer, ByVal SeqNo As Integer, ByVal EmpCode As String, ByVal CompDate As Date) As Boolean

    '    Dim arParams(5) As SqlParameter

    '    Dim parameterJob As New SqlParameter("@JobNo", SqlDbType.Int, 4)
    '    parameterJob.Value = JobNo
    '    arParams(0) = parameterJob

    '    Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.Int, 4)
    '    parameterJobComp.Value = JobComp
    '    arParams(1) = parameterJobComp

    '    Dim parameterSeqNo As New SqlParameter("@SeqNo", SqlDbType.Int, 4)
    '    parameterSeqNo.Value = SeqNo
    '    arParams(2) = parameterSeqNo

    '    Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
    '    parameterEmpCode.Value = EmpCode
    '    arParams(3) = parameterEmpCode

    '    Dim parameterCompDate As New SqlParameter("@CompDate", SqlDbType.SmallDateTime, 4)
    '    parameterCompDate.Value = CompDate
    '    arParams(4) = parameterCompDate

    '    Try
    '        oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Task_Update_Complete", arParams)
    '    Catch
    '        Return False
    '    End Try

    '    Return True

    'End Function
    'Public Function MarkNotCompleted(ByVal JobNo As Integer, ByVal JobComp As Integer, ByVal SeqNo As Integer, ByVal EmpCode As String) As Boolean

    '    Dim arParams(4) As SqlParameter

    '    Dim parameterJob As New SqlParameter("@JobNo", SqlDbType.Int, 4)
    '    parameterJob.Value = JobNo
    '    arParams(0) = parameterJob

    '    Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.Int, 4)
    '    parameterJobComp.Value = JobComp
    '    arParams(1) = parameterJobComp

    '    Dim parameterSeqNo As New SqlParameter("@SeqNo", SqlDbType.Int, 4)
    '    parameterSeqNo.Value = SeqNo
    '    arParams(2) = parameterSeqNo

    '    Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
    '    parameterEmpCode.Value = EmpCode
    '    arParams(3) = parameterEmpCode

    '    Try
    '        oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Task_Update_NotComplete", arParams)
    '    Catch
    '        Return False
    '    End Try

    '    Return True

    'End Function

    Public Function GetTask(ByVal JobNo As Integer, ByVal JobComp As Integer, ByVal SeqNo As Integer, ByVal EmpCode As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter

        Dim parameterJob As New SqlParameter("@JobNo", SqlDbType.Int, 4)
        parameterJob.Value = JobNo
        arParams(0) = parameterJob

        Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.Int, 4)
        parameterJobComp.Value = JobComp
        arParams(1) = parameterJobComp

        Dim parameterSeqNo As New SqlParameter("@SeqNo", SqlDbType.Int, 4)
        parameterSeqNo.Value = SeqNo
        arParams(2) = parameterSeqNo

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = EmpCode
        arParams(3) = parameterEmpCode

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Task_Get", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetTask", Err.Description)
        End Try

        Return dr
    End Function

    Public Function GetTaskComment(ByVal JobNo As Integer, ByVal JobComp As Integer, ByVal SeqNo As Integer, ByVal EmpCode As String) As String
        Dim arParams(4) As SqlParameter

        Dim parameterJob As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        parameterJob.Value = JobNo
        arParams(0) = parameterJob

        Dim parameterJobComp As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
        parameterJobComp.Value = JobComp
        arParams(1) = parameterJobComp

        Dim parameterSeqNo As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
        parameterSeqNo.Value = SeqNo
        arParams(2) = parameterSeqNo

        Dim parameterEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = EmpCode
        arParams(4) = parameterEmpCode

        Try
            Return oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_Task_GetEmpComment", arParams).ToString
        Catch ex As Exception
            Return ""
            'Return "Error:  " & ex.Message.ToString
        End Try

    End Function

    Public Function SaveTaskComment(ByVal JobNo As Integer, ByVal JobComp As Integer, ByVal SeqNo As Integer, ByVal EmpCode As String, ByVal TaskComment As String) As String
        Dim arParams(5) As SqlParameter

        Dim parameterJob As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        parameterJob.Value = JobNo
        arParams(0) = parameterJob

        Dim parameterJobComp As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
        parameterJobComp.Value = JobComp
        arParams(1) = parameterJobComp

        Dim parameterSeqNo As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
        parameterSeqNo.Value = SeqNo
        arParams(2) = parameterSeqNo

        Dim parameterEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = EmpCode
        arParams(4) = parameterEmpCode

        Dim parameterTaskComment As New SqlParameter("@COMPLETED_COMMENTS", SqlDbType.Text)
        parameterTaskComment.Value = TaskComment
        arParams(5) = parameterTaskComment

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Task_SaveEmpComment", arParams)
            Return ""
        Catch ex As Exception
            Return "Error:  " & ex.Message.ToString
        End Try

    End Function

    Public Function GetTaskEmployees(ByVal JobNo As Integer, ByVal JobComp As Integer, ByVal SeqNo As Integer, ByVal EmpCode As String)
        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter

        Dim parameterJob As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        parameterJob.Value = JobNo
        arParams(0) = parameterJob

        Dim parameterJobComp As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
        parameterJobComp.Value = JobComp
        arParams(1) = parameterJobComp

        Dim parameterSeqNo As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
        parameterSeqNo.Value = SeqNo
        arParams(2) = parameterSeqNo

        Dim parameterEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = EmpCode
        arParams(3) = parameterEmpCode

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Task_GetEmpList", arParams)
        Catch ex As Exception
            Return ""
            'Return "Error:  " & ex.Message.ToString
        End Try

        Return dr

    End Function


    Public Function MarkCompletedMedia(ByVal OrderNumber As Integer, ByVal LineNumber As Integer, ByVal Revision As Integer, ByVal MediaType As String, ByVal CompDate As String) As Boolean

        Dim arParams(5) As SqlParameter

        Dim parameterOrderNumber As New SqlParameter("@OrderNumber", SqlDbType.Int, 20)
        parameterOrderNumber.Value = OrderNumber
        arParams(0) = parameterOrderNumber

        Dim parameterLineNumber As New SqlParameter("@LineNumber", SqlDbType.Int, 20)
        parameterLineNumber.Value = LineNumber
        arParams(1) = parameterLineNumber

        Dim parameterRevision As New SqlParameter("@Revision", SqlDbType.Int, 20)
        parameterRevision.Value = Revision
        arParams(2) = parameterRevision

        Dim parameterMediaType As New SqlParameter("@MediaType", SqlDbType.VarChar, 2)
        parameterMediaType.Value = MediaType
        arParams(3) = parameterMediaType

        Dim parameterCompDate As New SqlParameter("@CompDate", SqlDbType.SmallDateTime, 12)
        If cGlobals.wvIsDate(CompDate) = True Then
            parameterCompDate.Value = cGlobals.wvCDate(CompDate)
        Else
            parameterCompDate.Value = System.DBNull.Value
        End If
        arParams(4) = parameterCompDate

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_TaskMedia_Update_Complete", arParams)
        Catch
            Return False
        End Try

        Return True

    End Function
    Public Function GetMediaMagTask(ByVal OrderNumber As Integer, ByVal LineNumber As Integer, ByVal RevNumber As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

        Dim parameterOrderNumber As New SqlParameter("@OrderNumber", SqlDbType.Int, 20)
        parameterOrderNumber.Value = OrderNumber
        arParams(0) = parameterOrderNumber

        Dim parameterLineNumber As New SqlParameter("@LineNumber", SqlDbType.Int, 20)
        parameterLineNumber.Value = LineNumber
        arParams(1) = parameterLineNumber

        Dim parameterRevNumber As New SqlParameter("@RevNumber", SqlDbType.Int, 20)
        parameterRevNumber.Value = RevNumber
        arParams(2) = parameterRevNumber

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_ddMagazine", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetTask", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetMediaNewsTask(ByVal OrderNumber As Integer, ByVal LineNumber As Integer, ByVal RevNumber As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

        Dim parameterOrderNumber As New SqlParameter("@OrderNumber", SqlDbType.Int, 20)
        parameterOrderNumber.Value = OrderNumber
        arParams(0) = parameterOrderNumber

        Dim parameterLineNumber As New SqlParameter("@LineNumber", SqlDbType.Int, 20)
        parameterLineNumber.Value = LineNumber
        arParams(1) = parameterLineNumber

        Dim parameterRevNumber As New SqlParameter("@RevNumber", SqlDbType.Int, 20)
        parameterRevNumber.Value = RevNumber
        arParams(2) = parameterRevNumber

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_ddNewspaper", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetTask", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetMediaInternetTask(ByVal OrderNumber As Integer, ByVal LineNumber As Integer, ByVal RevNumber As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

        Dim parameterOrderNumber As New SqlParameter("@OrderNumber", SqlDbType.Int, 20)
        parameterOrderNumber.Value = OrderNumber
        arParams(0) = parameterOrderNumber

        Dim parameterLineNumber As New SqlParameter("@LineNumber", SqlDbType.Int, 20)
        parameterLineNumber.Value = LineNumber
        arParams(1) = parameterLineNumber

        Dim parameterRevNumber As New SqlParameter("@RevNumber", SqlDbType.Int, 20)
        parameterRevNumber.Value = RevNumber
        arParams(2) = parameterRevNumber

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_ddInternet", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetTask", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetMediaOutTask(ByVal OrderNumber As Integer, ByVal LineNumber As Integer, ByVal RevNumber As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

        Dim parameterOrderNumber As New SqlParameter("@OrderNumber", SqlDbType.Int, 20)
        parameterOrderNumber.Value = OrderNumber
        arParams(0) = parameterOrderNumber

        Dim parameterLineNumber As New SqlParameter("@LineNumber", SqlDbType.Int, 20)
        parameterLineNumber.Value = LineNumber
        arParams(1) = parameterLineNumber

        Dim parameterRevNumber As New SqlParameter("@RevNumber", SqlDbType.Int, 20)
        parameterRevNumber.Value = RevNumber
        arParams(2) = parameterRevNumber

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_ddOutDoor", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetTask", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetMediaRadioTask(ByVal OrderNumber As Integer, ByVal LineNumber As Integer, ByVal RevNumber As Integer, ByVal Year As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter

        Dim parameterOrderNumber As New SqlParameter("@OrderNumber", SqlDbType.Int, 20)
        parameterOrderNumber.Value = OrderNumber
        arParams(0) = parameterOrderNumber

        Dim parameterLineNumber As New SqlParameter("@LineNumber", SqlDbType.Int, 20)
        parameterLineNumber.Value = LineNumber
        arParams(1) = parameterLineNumber

        Dim parameterRevNumber As New SqlParameter("@RevNumber", SqlDbType.Int, 20)
        parameterRevNumber.Value = RevNumber
        arParams(2) = parameterRevNumber

        Dim parameterYear As New SqlParameter("@Year", SqlDbType.Int, 20)
        parameterYear.Value = Year
        arParams(3) = parameterYear

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_ddRadio", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetTask", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetMediaTVTask(ByVal OrderNumber As Integer, ByVal LineNumber As Integer, ByVal RevNumber As Integer, ByVal Year As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter

        Dim parameterOrderNumber As New SqlParameter("@OrderNumber", SqlDbType.Int, 20)
        parameterOrderNumber.Value = OrderNumber
        arParams(0) = parameterOrderNumber

        Dim parameterLineNumber As New SqlParameter("@LineNumber", SqlDbType.Int, 20)
        parameterLineNumber.Value = LineNumber
        arParams(1) = parameterLineNumber

        Dim parameterRevNumber As New SqlParameter("@RevNumber", SqlDbType.Int, 20)
        parameterRevNumber.Value = RevNumber
        arParams(2) = parameterRevNumber

        Dim parameterYear As New SqlParameter("@Year", SqlDbType.Int, 20)
        parameterYear.Value = Year
        arParams(3) = parameterYear

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_ddTV", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetTask", Err.Description)
        End Try

        Return dr
    End Function

    Public Function GetMediaInfo(ByVal VendorCode As String, ByVal MediaType As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter

        Dim parameterVendorCode As New SqlParameter("@VendorCode", SqlDbType.VarChar, 50)
        parameterVendorCode.Value = VendorCode
        arParams(0) = parameterVendorCode

        Dim parameterMediaType As New SqlParameter("@Type", SqlDbType.VarChar, 50)
        parameterMediaType.Value = MediaType
        arParams(1) = parameterMediaType

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_ddMediaInfo", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetTask", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetMediaDelivery(ByVal VendorCode As String, ByVal MediaType As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter

        Dim parameterVendorCode As New SqlParameter("@VendorCode", SqlDbType.VarChar, 50)
        parameterVendorCode.Value = VendorCode
        arParams(0) = parameterVendorCode

        Dim parameterMediaType As New SqlParameter("@Type", SqlDbType.VarChar, 50)
        parameterMediaType.Value = MediaType
        arParams(1) = parameterMediaType

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_ddMediaDelivery", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetTask", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetMediaSpecs(ByVal VendorCode As String, ByVal MediaType As String) As DataTable
        Dim dr As SqlDataReader
        Dim dr2 As SqlDataReader
        Dim arParams(2) As SqlParameter

        Dim parameterVendorCode As New SqlParameter("@VendorCode", SqlDbType.VarChar, 50)
        parameterVendorCode.Value = VendorCode
        arParams(0) = parameterVendorCode

        Dim parameterMediaType As New SqlParameter("@Type", SqlDbType.VarChar, 50)
        parameterMediaType.Value = MediaType
        arParams(1) = parameterMediaType

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_ddMediaColumns", arParams)
            dr2 = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_ddMediaSpecs", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetTask", Err.Description)
        End Try

        Dim dt As DataTable
        Dim row As DataRow
        Dim i As Integer = 0
        Dim x As Integer = 1
        dt = New DataTable("mediainfo")
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
        'If dr2.HasRows Then
        '    Do While dr2.Read
        '        If dr2.GetInt16(3) >= i Then
        '            row.Item("Ad Size") = dr2.GetString(0)
        '            row.Item("Ad Size Description") = dr2.GetString(2)
        '            row.Item(dr2.GetInt16(3) + 1) = dr2.GetString(1)
        '            i = dr2.GetInt16(3)
        '        ElseIf dr2.GetInt16(3) < i Then
        '            dt.Rows.Add(row)
        '            row = dt.NewRow
        '            row.Item("Ad Size") = dr2.GetString(0)
        '            row.Item("Ad Size Description") = dr2.GetString(2)
        '            row.Item(dr2.GetInt16(3) + 1) = dr2.GetString(1)
        '            i = dr2.GetInt16(3)
        '        End If
        '    Loop

        'End If
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
                    row.Item("Ad Size") = dr2.GetString(0)
                    row.Item("Ad Size Description") = dr2.GetString(2)
                End If
            Next
        Loop


        If dr.HasRows = True And dr2.HasRows = True Then
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
    Public Function GetMediaSpecsByAdSizeGrid(ByVal VendorCode As String, ByVal MediaType As String, ByVal AdSizeCode As String) As DataTable
        Dim dr As SqlDataReader
        Dim dr2 As SqlDataReader
        Dim arParams(2) As SqlParameter
        Dim arParams2(2) As SqlParameter

        Dim parameterVendorCode As New SqlParameter("@VendorCode", SqlDbType.VarChar, 50)
        parameterVendorCode.Value = VendorCode
        arParams(0) = parameterVendorCode
        arParams2(0) = parameterVendorCode

        Dim parameterMediaType As New SqlParameter("@Type", SqlDbType.VarChar, 50)
        parameterMediaType.Value = MediaType
        arParams(1) = parameterMediaType
        arParams2(1) = parameterMediaType

        Dim parameterAdSize As New SqlParameter("@AdSize", SqlDbType.VarChar, 6)
        parameterAdSize.Value = AdSizeCode
        arParams2(2) = parameterAdSize

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_ddMediaColumns", arParams)
            dr2 = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_ddMediaSpecsByAdSize", arParams2)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetTask", Err.Description)
        End Try

        Dim dt As DataTable
        Dim row As DataRow
        Dim i As Integer = 0
        Dim x As Integer = 1
        dt = New DataTable("mediainfo")
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
        'If dr2.HasRows Then
        '    Do While dr2.Read
        '        If dr2.GetInt16(3) >= i Then
        '            row.Item("Ad Size") = dr2.GetString(0)
        '            row.Item("Ad Size Description") = dr2.GetString(2)
        '            row.Item(dr2.GetInt16(3) + 1) = dr2.GetString(1)
        '            i = dr2.GetInt16(3)
        '        ElseIf dr2.GetInt16(3) < i Then
        '            dt.Rows.Add(row)
        '            row = dt.NewRow
        '            row.Item("Ad Size") = dr2.GetString(0)
        '            row.Item("Ad Size Description") = dr2.GetString(2)
        '            row.Item(dr2.GetInt16(3) + 1) = dr2.GetString(1)
        '            i = dr2.GetInt16(3)
        '        End If
        '    Loop

        'End If
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
                    row.Item("Ad Size") = dr2.GetString(0)
                    row.Item("Ad Size Description") = dr2.GetString(2)
                End If
            Next
        Loop


        If dr.HasRows = True And dr2.HasRows = True Then
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
    Public Function GetMediaSpecsByAdSize(ByVal VendorCode As String, ByVal MediaType As String, ByVal AdSize As String) As DataTable
        Dim dt As DataTable
        Dim arParams(3) As SqlParameter

        Dim parameterVendorCode As New SqlParameter("@VendorCode", SqlDbType.VarChar, 50)
        parameterVendorCode.Value = VendorCode
        arParams(0) = parameterVendorCode

        Dim parameterMediaType As New SqlParameter("@Type", SqlDbType.VarChar, 50)
        parameterMediaType.Value = MediaType
        arParams(1) = parameterMediaType

        Dim parameterAdSize As New SqlParameter("@AdSize", SqlDbType.VarChar, 6)
        parameterAdSize.Value = AdSize
        arParams(2) = parameterAdSize

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_ddMediaSpecsByAdSize", "MediaSpecs", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetMSAS", Err.Description)
        End Try

        Return dt

    End Function
    Public Function GetMediaType(ByVal VendorCode As String) As String
        'Dim dr As SqlDataReader
        'Dim arParams(2) As SqlParameter
        Dim type As String
        Dim parameterVendorCode As New SqlParameter("@VendorCode", SqlDbType.VarChar, 50)
        parameterVendorCode.Value = VendorCode
        'arParams(0) = parameterVendorCode

        'Dim parameterMediaType As New SqlParameter("@Type", SqlDbType.VarChar, 50)
        'parameterMediaType.Value = MediaType
        'arParams(1) = parameterMediaType

        Try
            type = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_jobspecs_GetVendorType", parameterVendorCode)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetMediaType", Err.Description)
        End Try

        Return type
    End Function

    Public Function GetVendorRepInfo(ByVal VendorCode As String, ByVal VendorRepCode As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter

        Dim parameterVendorCode As New SqlParameter("@VendorCode", SqlDbType.VarChar, 20)
        parameterVendorCode.Value = VendorCode
        arParams(0) = parameterVendorCode

        Dim parameterVendorRepCode As New SqlParameter("@VendorRepCode", SqlDbType.VarChar, 20)
        parameterVendorRepCode.Value = VendorRepCode
        arParams(1) = parameterVendorRepCode

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_ddVendorRep", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetTask", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetCommentsOrderInfo(ByVal OrderNumber As Integer, ByVal Type As String, Optional ByVal RevNumber As Integer = 0) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

        Dim parameterOrderNumber As New SqlParameter("@OrderNumber", SqlDbType.Int, 20)
        parameterOrderNumber.Value = OrderNumber
        arParams(0) = parameterOrderNumber

        Dim parameterType As New SqlParameter("@Type", SqlDbType.VarChar, 2)
        parameterType.Value = Type
        arParams(1) = parameterType

        Dim parameterRevNumber As New SqlParameter("@RevNumber", SqlDbType.Int, 20)
        parameterRevNumber.Value = RevNumber
        arParams(2) = parameterRevNumber

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_ddCommentsOrderInfo", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetTask", Err.Description)
        End Try

        Return dr
    End Function

    Public Function GetCommentsOrderDetail(ByVal OrderNumber As Integer, ByVal LineNumber As Integer, ByVal Type As String, Optional ByVal RevNumber As Integer = 0) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter

        Dim parameterOrderNumber As New SqlParameter("@OrderNumber", SqlDbType.Int, 20)
        parameterOrderNumber.Value = OrderNumber
        arParams(0) = parameterOrderNumber

        Dim parameterLineNumber As New SqlParameter("@LineNumber", SqlDbType.Int, 20)
        parameterLineNumber.Value = LineNumber
        arParams(1) = parameterLineNumber

        Dim parameterRevNumber As New SqlParameter("@RevNumber", SqlDbType.Int, 20)
        parameterRevNumber.Value = RevNumber
        arParams(2) = parameterRevNumber

        Dim parameterType As New SqlParameter("@Type", SqlDbType.VarChar, 2)
        parameterType.Value = Type
        arParams(3) = parameterType

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_ddCommentsOrderDetail", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetTask", Err.Description)
        End Try

        Return dr
    End Function

    Public Function GetWorkload(ByVal userid As String, _
                                ByVal empcode As String, _
                                ByVal StartDate As DateTime, _
                                ByVal EndDate As DateTime, _
                                Optional ByVal Office As String = "", _
                                Optional ByVal Client As String = "", _
                                Optional ByVal Division As String = "", _
                                Optional ByVal Product As String = "", _
                                Optional ByVal Job As String = "", _
                                Optional ByVal JobComp As String = "", _
                                Optional ByVal ROLES As String = "", _
                                Optional ByVal TaskStatus As String = "", _
                                Optional ByVal ExcludeTempComplete As Boolean = False, _
                                Optional ByVal Depts As String = "", _
                                Optional ByVal emps As String = "", _
                                Optional ByVal manager As String = "") As DataTable
        Dim dt As DataTable
        Dim dt2 As DataTable
        Dim dr As SqlDataReader
        Dim dr2 As SqlDataReader
        Dim dr3 As SqlDataReader
        Dim dr4 As SqlDataReader
        Dim arParams(14) As SqlParameter
        Dim arParams2(3) As SqlParameter
        Dim arParams3(3) As SqlParameter

        'If StartDate.Date = EndDate.Date Then
        '    StartDate = StartDate.AddDays(-15.0)
        '    EndDate = EndDate.AddDays(15)
        'End If

        Dim parameteruserid As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameteruserid.Value = userid
        arParams(0) = parameteruserid

        Dim parameterempcode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterempcode.Value = empcode
        arParams(1) = parameterempcode

        Dim parameterStartDate As New SqlParameter("@start_date", SqlDbType.DateTime, 20)
        parameterStartDate.Value = StartDate.Date
        arParams(2) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@end_date", SqlDbType.DateTime, 20)
        parameterEndDate.Value = EndDate.Date
        arParams(3) = parameterEndDate

        Dim parameterOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
        parameterOffice.Value = Office
        arParams(4) = parameterOffice

        Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClient.Value = Client
        arParams(5) = parameterClient

        Dim parameterDivision As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivision.Value = Division
        arParams(6) = parameterDivision

        Dim parameterProduct As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProduct.Value = Product
        arParams(7) = parameterProduct

        Dim parameterJob As New SqlParameter("@JobNum", SqlDbType.VarChar, 6)
        parameterJob.Value = Job
        arParams(8) = parameterJob

        Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.VarChar, 6)
        parameterJobComp.Value = JobComp
        arParams(9) = parameterJobComp

        Dim parameterROLES As New SqlParameter("@ROLES", SqlDbType.VarChar, 8000)
        parameterROLES.Value = ROLES
        arParams(10) = parameterROLES

        Dim parameterTaskStatus As New SqlParameter("@TaskStatus", SqlDbType.VarChar, 1)
        parameterTaskStatus.Value = TaskStatus
        arParams(11) = parameterTaskStatus

        Dim parameterExcludeTempComplete As New SqlParameter("@ExcludeTempComplete", SqlDbType.Char, 1)
        If ExcludeTempComplete = True Then
            parameterExcludeTempComplete.Value = "Y"
        Else
            parameterExcludeTempComplete.Value = "N"
        End If
        arParams(12) = parameterExcludeTempComplete

        Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar, 6)
        parameterManager.Value = manager
        arParams(13) = parameterManager

        'Dim parameterEmps As New SqlParameter("@Emps", SqlDbType.VarChar, 2000)
        'parameterEmps.Value = emps
        'arParams(12) = parameterEmps

        arParams2(0) = parameteruserid
        arParams2(1) = parameterempcode

        Dim parameterdepts As New SqlParameter("@DeptCodes", SqlDbType.VarChar, 4000)
        If Depts = "" Then
            parameterdepts.Value = DBNull.Value
        ElseIf Depts.EndsWith(",") Then
            Depts = Depts.Substring(0, Depts.Length - 1)
            parameterdepts.Value = Depts
        Else
            parameterdepts.Value = Depts
        End If
        arParams(14) = parameterdepts

        arParams2(2) = parameterdepts
        arParams2(3) = parameterROLES

        arParams3(0) = parameteruserid
        arParams3(1) = parameterStartDate
        arParams3(2) = parameterEndDate

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_workload", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetWorkload", Err.Description)
        End Try

        Try
            dr2 = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_workload_hours", arParams2)
            dr4 = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_workload_hours", arParams2)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetWorkload2", Err.Description)
        End Try

        Try
            dr3 = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_workload_holidays", arParams3)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetWorkload3", Err.Description)
        End Try

        Dim totalhours As Decimal
        Dim row As DataRow
        dt = New DataTable("workload")
        Dim totaljobduedc As DataColumn = New DataColumn("TOTAL_JOBS_DUE")
        Dim totaljobopentaskdc As DataColumn = New DataColumn("TOTAL_JOBS_OPEN_TASKS")
        Dim opentasksdc As DataColumn = New DataColumn("OPEN_TASKS")
        Dim totalhoursneededdc As DataColumn = New DataColumn("TOTAL_HOURS_NEEDED")
        Dim totalhoursavailabledc As DataColumn = New DataColumn("TOTAL_HOURS_AVAILABLE")
        Dim hoursallocateddc As DataColumn = New DataColumn("HOURS_ALLOCATED")
        Dim hoursoffdc As DataColumn = New DataColumn("HOURS_OFF")
        Dim holidayhours As DataColumn = New DataColumn("HOLIDAY_HOURS")
        Dim appthoursdc As DataColumn = New DataColumn("APPT_HOURS")

        dt.Columns.Add(totaljobduedc)
        dt.Columns.Add(totaljobopentaskdc)
        dt.Columns.Add(opentasksdc)
        dt.Columns.Add(totalhoursneededdc)
        dt.Columns.Add(totalhoursavailabledc)
        dt.Columns.Add(hoursallocateddc)
        dt.Columns.Add(hoursoffdc)
        dt.Columns.Add(holidayhours)
        dt.Columns.Add(appthoursdc)
        row = dt.NewRow

        Dim i As Integer
        Dim mon As Integer
        Dim tue As Integer
        Dim wed As Integer
        Dim thu As Integer
        Dim fri As Integer
        Dim sat As Integer
        Dim sun As Integer
        Dim time As Integer
        EndDate = EndDate.AddDays(1)
        Dim ts As TimeSpan = EndDate.Subtract(StartDate)
        time = ts.Days

        For i = 1 To time
            If StartDate <= EndDate Then
                If StartDate.DayOfWeek = DayOfWeek.Monday Then
                    mon += 1
                    StartDate = StartDate.AddDays(1)
                ElseIf StartDate.DayOfWeek = DayOfWeek.Tuesday Then
                    tue += 1
                    StartDate = StartDate.AddDays(1)
                ElseIf StartDate.DayOfWeek = DayOfWeek.Wednesday Then
                    wed += 1
                    StartDate = StartDate.AddDays(1)
                ElseIf StartDate.DayOfWeek = DayOfWeek.Thursday Then
                    thu += 1
                    StartDate = StartDate.AddDays(1)
                ElseIf StartDate.DayOfWeek = DayOfWeek.Friday Then
                    fri += 1
                    StartDate = StartDate.AddDays(1)
                ElseIf StartDate.DayOfWeek = DayOfWeek.Saturday Then
                    sat += 1
                    StartDate = StartDate.AddDays(1)
                ElseIf StartDate.DayOfWeek = DayOfWeek.Sunday Then
                    sun += 1
                    StartDate = StartDate.AddDays(1)
                End If
            Else
                Exit For
            End If
        Next

        Dim day As String
        Dim totalEmpCount As Decimal
        dt2 = convertDRworkload(dr4)
        If dr3.HasRows = True Then
            Do While dr3.Read
                day = dr3.GetDateTime(0).DayOfWeek.ToString
                For i = 0 To dt2.Rows.Count - 1
                    Select Case day
                        Case "Monday"
                            If dt2.Rows(i).Item(1) <> 0.0 Then
                                If dt2.Rows(i).Item(1) <= dr3.GetDecimal(1) Then
                                    totalEmpCount += dt2.Rows(i).Item(1)
                                Else
                                    totalEmpCount += dr3.GetDecimal(1)
                                End If
                            End If
                        Case "Tuesday"
                            If dt2.Rows(i).Item(2) <> 0.0 Then
                                If dt2.Rows(i).Item(2) <= dr3.GetDecimal(1) Then
                                    totalEmpCount += dt2.Rows(i).Item(2)
                                Else
                                    totalEmpCount += dr3.GetDecimal(1)
                                End If
                            End If
                        Case "Wednesday"
                            If dt2.Rows(i).Item(3) <> 0.0 Then
                                If dt2.Rows(i).Item(3) <= dr3.GetDecimal(1) Then
                                    totalEmpCount += dt2.Rows(i).Item(3)
                                Else
                                    totalEmpCount += dr3.GetDecimal(1)
                                End If
                            End If
                        Case "Thursday"
                            If dt2.Rows(i).Item(4) <> 0.0 Then
                                If dt2.Rows(i).Item(4) <= dr3.GetDecimal(1) Then
                                    totalEmpCount += dt2.Rows(i).Item(4)
                                Else
                                    totalEmpCount += dr3.GetDecimal(1)
                                End If
                            End If
                        Case "Friday"
                            If dt2.Rows(i).Item(5) <> 0.0 Then
                                If dt2.Rows(i).Item(5) <= dr3.GetDecimal(1) Then
                                    totalEmpCount += dt2.Rows(i).Item(5)
                                Else
                                    totalEmpCount += dr3.GetDecimal(1)
                                End If
                            End If
                        Case "Saturday"
                            If dt2.Rows(i).Item(6) <> 0.0 Then
                                If dt2.Rows(i).Item(6) <= dr3.GetDecimal(1) Then
                                    totalEmpCount += dt2.Rows(i).Item(6)
                                Else
                                    totalEmpCount += dr3.GetDecimal(1)
                                End If
                            End If
                        Case "Sunday"
                            If dt2.Rows(i).Item(7) <> 0.0 Then
                                If dt2.Rows(i).Item(7) <= dr3.GetDecimal(1) Then
                                    totalEmpCount += dt2.Rows(i).Item(7)
                                Else
                                    totalEmpCount += dr3.GetDecimal(1)
                                End If
                            End If
                    End Select
                Next
            Loop
        End If
        Do While dr.Read
            row.Item("TOTAL_JOBS_DUE") = dr.GetInt32(0)
            row.Item("TOTAL_JOBS_OPEN_TASKS") = dr.GetInt32(1)
            row.Item("OPEN_TASKS") = dr.GetInt32(2)
            row.Item("TOTAL_HOURS_NEEDED") = dr.GetDecimal(3)
            Do While dr2.Read
                If dr2.GetDecimal(1) <> 0 Then
                    totalhours += dr2.GetDecimal(1) * mon
                End If
                If dr2.GetDecimal(2) <> 0 Then
                    totalhours += dr2.GetDecimal(2) * tue
                End If
                If dr2.GetDecimal(3) <> 0 Then
                    totalhours += dr2.GetDecimal(3) * wed
                End If
                If dr2.GetDecimal(4) <> 0 Then
                    totalhours += dr2.GetDecimal(4) * thu
                End If
                If dr2.GetDecimal(5) <> 0 Then
                    totalhours += dr2.GetDecimal(5) * fri
                End If
                If dr2.GetDecimal(6) <> 0 Then
                    totalhours += dr2.GetDecimal(6) * sat
                End If
                If dr2.GetDecimal(7) <> 0 Then
                    totalhours += dr2.GetDecimal(7) * sun
                End If
            Loop
            row.Item("TOTAL_HOURS_AVAILABLE") = totalhours
            row.Item("HOURS_ALLOCATED") = dr.GetDecimal(4)
            row.Item("HOURS_OFF") = dr.GetDecimal(5)
            row.Item("HOLIDAY_HOURS") = totalEmpCount
            row.Item("APPT_HOURS") = dr.GetDecimal(7)
            dt.Rows.Add(row)
            row = dt.NewRow
        Loop
        dr.Close()
        dr2.Close()
        dr3.Close()
        dr4.Close()
        Return dt
    End Function

    Public Overloads Function GetWorkloadEmployee(ByVal userid As String, _
                                        ByVal empcode As String, _
                                        ByVal StartDate As DateTime, _
                                        ByVal EndDate As DateTime, _
                                        Optional ByVal Office As String = "", _
                                        Optional ByVal Client As String = "", _
                                        Optional ByVal Division As String = "", _
                                        Optional ByVal Product As String = "", _
                                        Optional ByVal Job As String = "", _
                                        Optional ByVal JobComp As String = "", _
                                        Optional ByVal Roles As String = "", _
                                        Optional ByVal TaskStatus As String = "", _
                                        Optional ByVal ExcludeTempComplete As Boolean = False, _
                                        Optional ByVal Manager As String = "", _
                                        Optional ByVal QueryType As String = "", _
                                        Optional ByVal ProjectSchedule_JobNumber As Integer = 0, _
                                        Optional ByVal ProjectSchedule_JobComponentNbr As Integer = 0, _
                                        Optional ByVal ProjectSchedule_EmpList As String = "", _
                                        Optional ByVal ProjectSchedule_JobCompWhereClause As String = "", _
                                        Optional ByVal OverrideEmployeeSecurity As Boolean = False, _
                                        Optional ByVal Depts As String = "") As DataSet

        Dim arParams(21) As SqlParameter

        Dim parameteruserid As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameteruserid.Value = userid
        arParams(0) = parameteruserid

        Dim parameterempcode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterempcode.Value = empcode
        arParams(1) = parameterempcode

        Dim parameterStartDate As New SqlParameter("@start_date", SqlDbType.DateTime, 20)
        parameterStartDate.Value = StartDate.Date
        arParams(2) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@end_date", SqlDbType.DateTime, 20)
        parameterEndDate.Value = EndDate.Date
        arParams(3) = parameterEndDate

        Dim parameterOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 6)
        parameterOffice.Value = Office
        arParams(4) = parameterOffice

        Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClient.Value = Client
        arParams(5) = parameterClient

        Dim parameterDivision As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivision.Value = Division
        arParams(6) = parameterDivision

        Dim parameterProduct As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProduct.Value = Product
        arParams(7) = parameterProduct

        If Job = "0" Then
            Job = ""
        End If

        Dim parameterJob As New SqlParameter("@JobNum", SqlDbType.VarChar, 6)
        parameterJob.Value = Job
        arParams(8) = parameterJob

        If JobComp = "0" Then
            JobComp = ""
        End If

        Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.VarChar, 6)
        parameterJobComp.Value = JobComp
        arParams(9) = parameterJobComp

        Dim parameterRoles As New SqlParameter("@ROLES", SqlDbType.VarChar, 8000)
        parameterRoles.Value = Roles
        arParams(10) = parameterRoles

        Dim parameterTaskStatus As New SqlParameter("@TaskStatus", SqlDbType.VarChar, 1)
        parameterTaskStatus.Value = TaskStatus
        arParams(11) = parameterTaskStatus

        Dim parameterExcludeTempComplete As New SqlParameter("@ExcludeTempComplete", SqlDbType.Char, 1)
        If ExcludeTempComplete = True Then
            parameterExcludeTempComplete.Value = "Y"
        Else
            parameterExcludeTempComplete.Value = "N"
        End If
        arParams(12) = parameterExcludeTempComplete

        Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar, 6)
        parameterManager.Value = Manager
        arParams(13) = parameterManager

        Dim parameterQueryType As New SqlParameter("@QUERY_TYPE", SqlDbType.VarChar, 10)
        parameterQueryType.Value = QueryType
        arParams(14) = parameterQueryType

        Dim parameterProjectSchedule_JobNumber As New SqlParameter("@PSWL_JOB_NUMBER", SqlDbType.Int)
        If ProjectSchedule_JobNumber = 0 Then
            parameterProjectSchedule_JobNumber.Value = System.DBNull.Value
        Else
            parameterProjectSchedule_JobNumber.Value = ProjectSchedule_JobNumber
        End If
        arParams(15) = parameterProjectSchedule_JobNumber

        Dim parameterProjectSchedule_JobComponentNbr As New SqlParameter("@PSWL_JOB_COMPONENT_NBR", SqlDbType.SmallInt)
        If ProjectSchedule_JobNumber = 0 Then
            parameterProjectSchedule_JobComponentNbr.Value = System.DBNull.Value
        Else
            parameterProjectSchedule_JobComponentNbr.Value = ProjectSchedule_JobComponentNbr
        End If
        arParams(16) = parameterProjectSchedule_JobComponentNbr

        Dim parameterProjectSchedule_EmpList As New SqlParameter("@EMP_LIST", SqlDbType.VarChar, 8000)
        parameterProjectSchedule_EmpList.Value = ProjectSchedule_EmpList
        arParams(17) = parameterProjectSchedule_EmpList

        Dim parameterProjectSchedule_JobCompWhereClause As New SqlParameter("@JC_LIST", SqlDbType.VarChar, 8000)
        parameterProjectSchedule_JobCompWhereClause.Value = ProjectSchedule_JobCompWhereClause
        arParams(18) = parameterProjectSchedule_JobCompWhereClause

        Dim parameterOverrideEmployeeSecurity As New SqlParameter("@OVERRIDE_EMP_SEC", SqlDbType.SmallInt)
        If OverrideEmployeeSecurity = True Then
            parameterOverrideEmployeeSecurity.Value = 1
        Else
            parameterOverrideEmployeeSecurity.Value = 0
        End If
        arParams(19) = parameterOverrideEmployeeSecurity

        Dim parameterDEPTS As New SqlParameter("@DEPTS", SqlDbType.VarChar, 8000)
        parameterDEPTS.Value = Depts
        arParams(20) = parameterDEPTS

        Try
            Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_workload_employee", arParams)
        Catch
            Return Nothing
        End Try

    End Function

    Public Overloads Function GetWorkloadEmployeeSched(ByVal userid As String, _
                                    ByVal empcode As String, _
                                    ByVal StartDate As DateTime, _
                                    ByVal EndDate As DateTime) As DataSet

        Dim arParams(21) As SqlParameter

        Dim parameteruserid As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameteruserid.Value = userid
        arParams(0) = parameteruserid

        Dim parameterempcode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterempcode.Value = empcode
        arParams(1) = parameterempcode

        Dim parameterStartDate As New SqlParameter("@start_date", SqlDbType.DateTime, 20)
        parameterStartDate.Value = StartDate.Date
        arParams(2) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@end_date", SqlDbType.DateTime, 20)
        parameterEndDate.Value = EndDate.Date
        arParams(3) = parameterEndDate

        Dim parameterOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 6)
        parameterOffice.Value = ""
        arParams(4) = parameterOffice

        Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClient.Value = ""
        arParams(5) = parameterClient

        Dim parameterDivision As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivision.Value = ""
        arParams(6) = parameterDivision

        Dim parameterProduct As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProduct.Value = ""
        arParams(7) = parameterProduct

        Dim parameterJob As New SqlParameter("@JobNum", SqlDbType.VarChar, 6)
        parameterJob.Value = ""
        arParams(8) = parameterJob

        Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.VarChar, 6)
        parameterJobComp.Value = ""
        arParams(9) = parameterJobComp

        Dim parameterRoles As New SqlParameter("@ROLES", SqlDbType.VarChar, 8000)
        parameterRoles.Value = ""
        arParams(10) = parameterRoles

        Dim parameterTaskStatus As New SqlParameter("@TaskStatus", SqlDbType.VarChar, 1)
        parameterTaskStatus.Value = ""
        arParams(11) = parameterTaskStatus

        Dim parameterExcludeTempComplete As New SqlParameter("@ExcludeTempComplete", SqlDbType.Char, 1)
        parameterExcludeTempComplete.Value = "N"
        arParams(12) = parameterExcludeTempComplete

        Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar, 6)
        parameterManager.Value = ""
        arParams(13) = parameterManager

        Dim parameterQueryType As New SqlParameter("@QUERY_TYPE", SqlDbType.VarChar, 4)
        parameterQueryType.Value = ""
        arParams(14) = parameterQueryType

        Dim parameterProjectSchedule_JobNumber As New SqlParameter("@PSWL_JOB_NUMBER", SqlDbType.Int)
        parameterProjectSchedule_JobNumber.Value = System.DBNull.Value
        arParams(15) = parameterProjectSchedule_JobNumber

        Dim parameterProjectSchedule_JobComponentNbr As New SqlParameter("@PSWL_JOB_COMPONENT_NBR", SqlDbType.SmallInt)
        parameterProjectSchedule_JobComponentNbr.Value = System.DBNull.Value
        arParams(16) = parameterProjectSchedule_JobComponentNbr

        Dim parameterProjectSchedule_EmpList As New SqlParameter("@EMP_LIST", SqlDbType.VarChar, 8000)
        parameterProjectSchedule_EmpList.Value = ""
        arParams(17) = parameterProjectSchedule_EmpList

        Dim parameterProjectSchedule_JobCompWhereClause As New SqlParameter("@JC_LIST", SqlDbType.VarChar, 8000)
        parameterProjectSchedule_JobCompWhereClause.Value = ""
        arParams(18) = parameterProjectSchedule_JobCompWhereClause

        Dim parameterOverrideEmployeeSecurity As New SqlParameter("@OVERRIDE_EMP_SEC", SqlDbType.SmallInt)
        'If OverrideEmployeeSecurity = True Then
        parameterOverrideEmployeeSecurity.Value = 1
        'Else
        'parameterOverrideEmployeeSecurity.Value = 0
        'End If
        arParams(19) = parameterOverrideEmployeeSecurity

        Dim parameterDEPTS As New SqlParameter("@DEPTS", SqlDbType.VarChar, 8000)
        parameterDEPTS.Value = ""
        arParams(20) = parameterDEPTS


        Try
            Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_workload_employee", arParams)
        Catch
            Return Nothing
        End Try

    End Function

    Public Function GetWorkloadDetails(ByVal userid As String, _
                                        ByVal StartDate As DateTime, _
                                        ByVal EndDate As DateTime, _
                                        Optional ByVal Office As String = "", _
                                        Optional ByVal Client As String = "", _
                                        Optional ByVal Division As String = "", _
                                        Optional ByVal Product As String = "", _
                                        Optional ByVal Job As String = "", _
                                        Optional ByVal JobComp As String = "", _
                                        Optional ByVal Roles As String = "", _
                                        Optional ByVal TaskStatus As String = "", _
                                        Optional ByVal ExcludeTempComplete As Boolean = False, _
                                        Optional ByVal Employee As String = "", _
                                        Optional ByVal Manager As String = "", _
                                        Optional ByVal Depts As String = "") As DataSet

        Dim arParams(15) As SqlParameter

        Dim parameteruserid As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameteruserid.Value = userid
        arParams(0) = parameteruserid

        Dim parameterStartDate As New SqlParameter("@start_date", SqlDbType.DateTime, 20)
        parameterStartDate.Value = StartDate.Date
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@end_date", SqlDbType.DateTime, 20)
        parameterEndDate.Value = EndDate.Date
        arParams(2) = parameterEndDate

        Dim parameterOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
        parameterOffice.Value = Office
        arParams(3) = parameterOffice

        Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClient.Value = Client
        arParams(4) = parameterClient

        Dim parameterDivision As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivision.Value = Division
        arParams(5) = parameterDivision

        Dim parameterProduct As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProduct.Value = Product
        arParams(6) = parameterProduct

        Dim parameterJob As New SqlParameter("@JobNum", SqlDbType.VarChar, 6)
        parameterJob.Value = Job
        arParams(7) = parameterJob

        Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.VarChar, 6)
        parameterJobComp.Value = JobComp
        arParams(8) = parameterJobComp

        Dim parameterRoles As New SqlParameter("@ROLES", SqlDbType.VarChar, 8000)
        parameterRoles.Value = Roles
        arParams(9) = parameterRoles

        Dim parameterTaskStatus As New SqlParameter("@TaskStatus", SqlDbType.VarChar, 1)
        parameterTaskStatus.Value = TaskStatus
        arParams(10) = parameterTaskStatus

        Dim parameterExcludeTempComplete As New SqlParameter("@ExcludeTempComplete", SqlDbType.Char, 1)
        If ExcludeTempComplete = True Then
            parameterExcludeTempComplete.Value = "Y"
        Else
            parameterExcludeTempComplete.Value = "N"
        End If
        arParams(11) = parameterExcludeTempComplete

        Dim parameterEmployee As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterEmployee.Value = Employee
        arParams(12) = parameterEmployee

        Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar, 6)
        parameterManager.Value = Manager
        arParams(13) = parameterManager

        Dim parameterDEPTS As New SqlParameter("@DEPTS", SqlDbType.VarChar, 8000)
        parameterDEPTS.Value = Depts
        arParams(14) = parameterDEPTS

        Try
            Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_workload_details", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetWorkloadDetails", Err.Description)
        End Try

    End Function

    Public Function GetEmpAvailability(ByVal userid As String, _
                                        ByVal emp_code As String, _
                                        ByVal StartDate As String, _
                                        ByVal EndDate As String, _
                                        ByVal sum_level As String, _
                                        ByVal actualize As String, _
                                        Optional ByVal Office As String = "", _
                                        Optional ByVal Client As String = "", _
                                        Optional ByVal Division As String = "", _
                                        Optional ByVal Product As String = "", _
                                        Optional ByVal Job As String = "", _
                                        Optional ByVal JobComp As String = "", _
                                        Optional ByVal Role As String = "", _
                                        Optional ByVal TaskStatus As String = "", _
                                        Optional ByVal ExcludeTempComplete As Boolean = False, _
                                        Optional ByVal Depts As String = "", _
                                        Optional ByVal Manager As String = "") As SqlDataReader


        Dim dr As SqlDataReader
        Dim arParams(16) As SqlParameter

        Dim parameteruserid As New SqlParameter("@user_id", SqlDbType.VarChar, 100)
        parameteruserid.Value = userid
        arParams(0) = parameteruserid

        Dim parameterEmployee As New SqlParameter("@emp_code", SqlDbType.VarChar, 6)
        parameterEmployee.Value = emp_code
        arParams(1) = parameterEmployee

        Dim parameterStartDate As New SqlParameter("@start_date", SqlDbType.VarChar, 12)
        parameterStartDate.Value = StartDate
        arParams(2) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@end_date", SqlDbType.VarChar, 12)
        parameterEndDate.Value = EndDate
        arParams(3) = parameterEndDate

        Dim parameterSumLevel As New SqlParameter("@sum_level", SqlDbType.VarChar, 1)
        parameterSumLevel.Value = sum_level
        arParams(4) = parameterSumLevel

        Dim parameterActualize As New SqlParameter("@actualize", SqlDbType.VarChar, 1)
        parameterActualize.Value = actualize
        arParams(5) = parameterActualize

        Dim parameterOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 6)
        parameterOffice.Value = Office
        arParams(6) = parameterOffice

        Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClient.Value = Client
        arParams(7) = parameterClient

        Dim parameterDivision As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivision.Value = Division
        arParams(8) = parameterDivision

        Dim parameterProduct As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProduct.Value = Product
        arParams(9) = parameterProduct

        Dim parameterJob As New SqlParameter("@JobNum", SqlDbType.VarChar, 6)
        parameterJob.Value = Job
        arParams(10) = parameterJob

        Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.VarChar, 6)
        parameterJobComp.Value = JobComp
        arParams(11) = parameterJobComp

        Dim parameterRole As New SqlParameter("@Role", SqlDbType.VarChar, 6)
        parameterRole.Value = Role
        arParams(12) = parameterRole

        Dim parameterTaskStatus As New SqlParameter("@TaskStatus", SqlDbType.VarChar, 1)
        parameterTaskStatus.Value = TaskStatus
        arParams(13) = parameterTaskStatus

        Dim parameterExcludeTempComplete As New SqlParameter("@ExcludeTempComplete", SqlDbType.Char, 1)
        If ExcludeTempComplete = True Then
            parameterExcludeTempComplete.Value = "Y"
        Else
            parameterExcludeTempComplete.Value = "N"
        End If
        arParams(14) = parameterExcludeTempComplete

        Dim parameterdepts As New SqlParameter("@Depts", SqlDbType.VarChar, 1000)
        parameterdepts.Value = Depts
        arParams(15) = parameterdepts

        Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar, 6)
        parameterManager.Value = Manager
        arParams(16) = parameterManager


        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_get_emp_avail_ass_all", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetEmpAvailability", Err.Description)
        End Try

        Return dr
    End Function

    Public Function GetEmpsPerDept(ByVal depts As String) As String
        Dim dr As SqlDataReader
        Dim dr2 As SqlDataReader
        Dim arParams(1) As SqlParameter
        Dim emps As String = ""
        Dim dept As String

        If depts <> "" Then
            If depts.EndsWith(",") Then
                depts = depts.Substring(0, depts.Length - 1)
            End If
        End If

        If depts = "%" Then
            Try
                dr2 = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_Depts")
            Catch
                Err.Raise(Err.Number, "Class:cTasks Routine:GetWorkload", Err.Description)
            End Try

            Do While dr2.Read
                dept = dept & dr2.GetString(0) & ","
            Loop
        End If

        Dim parameterdepts As New SqlParameter("@DeptCodes", SqlDbType.VarChar, 4000)
        If depts = "%" Then
            parameterdepts.Value = dept
        Else
            parameterdepts.Value = depts
        End If
        arParams(0) = parameterdepts

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_workload_empperdept", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetWorkload", Err.Description)
        End Try

        If dr.HasRows = True Then
            Do While dr.Read
                emps = emps & dr.GetString(0) & ","
            Loop
        End If

        If emps <> "" Then
            If emps.EndsWith(",") Then
                emps = emps.Substring(0, emps.Length - 1)
            End If
        End If

        Return emps
    End Function

    Public Function convertDRworkload(ByVal dr As SqlDataReader) As DataTable
        Dim totalhours As Integer
        Dim dt As DataTable
        Dim row As DataRow
        dt = New DataTable("workload")
        Dim empcode As DataColumn = New DataColumn("EMP_CODE")
        Dim mon As DataColumn = New DataColumn("MON")
        Dim tue As DataColumn = New DataColumn("TUE")
        Dim wed As DataColumn = New DataColumn("WED")
        Dim thu As DataColumn = New DataColumn("THU")
        Dim fri As DataColumn = New DataColumn("FRI")
        Dim sat As DataColumn = New DataColumn("SAT")
        Dim sun As DataColumn = New DataColumn("SUN")

        dt.Columns.Add(empcode)
        dt.Columns.Add(mon)
        dt.Columns.Add(tue)
        dt.Columns.Add(wed)
        dt.Columns.Add(thu)
        dt.Columns.Add(fri)
        dt.Columns.Add(sat)
        dt.Columns.Add(sun)
        row = dt.NewRow

        Do While dr.Read
            row.Item("EMP_CODE") = dr.GetString(0)
            row.Item("MON") = dr.GetDecimal(1)
            row.Item("TUE") = dr.GetDecimal(2)
            row.Item("WED") = dr.GetDecimal(3)
            row.Item("THU") = dr.GetDecimal(4)
            row.Item("FRI") = dr.GetDecimal(5)
            row.Item("SAT") = dr.GetDecimal(6)
            row.Item("SUN") = dr.GetDecimal(7)
            dt.Rows.Add(row)
            row = dt.NewRow
        Loop

        Return dt
    End Function

    'why is this here and not in cAppVars???
    Public Function getAppVars(ByVal UserID As String, ByVal ApplicationName As String, ByVal VariableName As String) As String
        Dim SessionKey As String = "cTasks_getAppVars" & UserID & ApplicationName & VariableName
        Dim ReturnString As String = ""
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim SbSQL As New System.Text.StringBuilder
            Dim StrSQL As String = ""
            Dim dr As SqlDataReader
            Dim oSQL As SqlHelper

            With SbSQL
                .Append("SELECT ISNULL(VARIABLE_VALUE,'') FROM APP_VARS WHERE USERID = '")
                .Append(UserID)
                .Append("' AND APPLICATION = '")
                .Append(ApplicationName)
                .Append("' AND VARIABLE_NAME = '")
                .Append(VariableName)
                .Append("';")
            End With

            StrSQL = SbSQL.ToString()

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.Text, StrSQL)
            Catch
                ReturnString = ""
            End Try

            If dr.HasRows Then
                dr.Read()
                ReturnString = dr.GetString(0)
            Else
                ReturnString = ""
            End If

            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString

    End Function

    Public Function hasAppVars(ByVal UserID As String, ByVal ApplicationName As String) As Boolean
        Try
            Dim RetVal As Boolean = False
            Using MyConn As New SqlConnection(mConnString)
                MyConn.Open()
                Dim StrSQL As String = "SELECT ISNULL(COUNT(1),0) FROM APP_VARS WHERE USERID = '" & UserID & "' AND APPLICATION = '" & ApplicationName & "';"
                Dim MyCmd As New SqlCommand(StrSQL, MyConn)
                Try
                    Dim i As Integer = 0
                    i = CType(MyCmd.ExecuteScalar, Integer)
                    If i = 0 Then
                        RetVal = False
                    ElseIf i > 0 Then
                        RetVal = True
                    End If
                    MyCmd.ExecuteNonQuery()
                Catch ex As Exception
                Finally
                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                End Try
            End Using
            Return RetVal
        Catch ex As Exception
        End Try
    End Function
    Public Function setAppVars(ByVal UserID As String, ByVal ApplicationName As String, ByVal VariableName As String, ByVal varType As String, ByVal varValue As String) As String
        Try
            Dim SessionKey As String = "cTasks_getAppVars" & UserID & ApplicationName & VariableName
            Dim SbSQL As New System.Text.StringBuilder
            Dim StrSQL As String = ""

            ' clear out existing data first:
            With SbSQL
                .Append("DELETE FROM APP_VARS WITH(ROWLOCK) WHERE USERID = '")
                .Append(UserID)
                .Append("' AND APPLICATION = '")
                .Append(ApplicationName)
                .Append("' AND VARIABLE_NAME = '")
                .Append(VariableName)
                .Append("';")
            End With

            With SbSQL
                .Append("INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_GROUP, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_VALUE) VALUES ('")
                .Append(UserID)
                .Append("','")
                .Append(ApplicationName)
                .Append("','0','")
                .Append(VariableName)
                .Append("','")
                .Append(varType)
                .Append("','")
                .Append(varValue)
                .Append("');")
            End With

            StrSQL = SbSQL.ToString()

            'Save:
            If StrSQL.Trim() <> "" Then
                Using MyConn As New SqlConnection(mConnString)
                    MyConn.Open()
                    Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                    Dim MyCmd As New SqlCommand(StrSQL, MyConn, MyTrans)
                    Try
                        MyCmd.ExecuteNonQuery()
                        MyTrans.Commit()
                        HttpContext.Current.Session(SessionKey) = Nothing
                    Catch ex As Exception
                        MyTrans.Rollback()
                        Return "Error running selection SQL:&nbsp;&nbsp;" & ex.Message.ToString()
                    Finally
                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                    End Try
                End Using
            End If

            Return ""

        Catch ex As Exception
            Return "Error saving " & VariableName & ":&nbsp;&nbsp;" & ex.Message.ToString()
        End Try
    End Function

    Public Sub New(Optional ByVal ConnectionString As String = "")
        Try
            If ConnectionString <> "" Then
                mConnString = ConnectionString
            Else
                mConnString = HttpContext.Current.Session("ConnString")
            End If
        Catch ex As Exception
            mConnString = ""
        End Try
    End Sub

End Class
