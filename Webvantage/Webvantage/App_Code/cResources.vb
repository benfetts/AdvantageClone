'Select Case Summary_Level
'    Case SummaryLevel.Day
'    Case SummaryLevel.Week
'    Case SummaryLevel.Month
'    Case SummaryLevel.Year
'End Select
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Text
Imports System.Web
Imports Webvantage.cGlobals
Imports Webvantage.MiscFN
Imports DayPilot

Public Enum TimeIncrement
    HalfHour = 0
    Hour = 1
    FourHours = 4
    EightHours = 8
    TwentyFourHours = 24
End Enum

Public Structure ResourceExcelReportData
    Public GridData As DataTable
    Public ColumnData As DataTable
    'Public TestDatatable As DataTable
    'Public TestDataset As DataSet
End Structure

<Serializable()> Public Class cResources
    Private mConnString As String
    Private mUserID As String
    Private mEmpCode As String
    Private oSQL As SqlHelper

    Public ColIdxDate As Integer = 1
    Public ColIdxTime As Integer = 2
    Public ColIdxStartOfDynamicColumns As Integer = 3
    Public HeaderRows As Integer = 1

    Private ExcelRowLimit As Integer = 60000 'Actual: 65,536

#Region " Excel Report "

    Public Function IsOverRowLimit(ByVal StartDate As Date, ByVal EndDate As Date, ByVal TimeInterval As TimeIncrement) As Boolean
        Dim NumDays As Integer
        NumDays = DateDiff(DateInterval.Day, StartDate, EndDate)
        NumDays += 1
        Dim Multiplier As Integer = 0
        Select Case TimeInterval
            Case TimeIncrement.HalfHour
                Multiplier = 48
            Case TimeIncrement.Hour
                Multiplier = 24
            Case TimeIncrement.FourHours
                Multiplier = 6
            Case TimeIncrement.EightHours
                Multiplier = 3
            Case TimeIncrement.TwentyFourHours
                Multiplier = 1
        End Select

        If (NumDays * Multiplier) > ExcelRowLimit Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function GetReport(ByVal StartDate As Date, ByVal EndDate As Date, _
                                Optional ByVal TimeInterval As TimeIncrement = TimeIncrement.HalfHour, _
                                Optional ByVal ResourceTypesList As String = "", _
                                Optional ByVal ResourceList As String = "", _
                                Optional ByVal OfficeList As String = "", _
                                Optional ByVal CDPList As String = "", _
                                Optional ByVal TrfFncList As String = "", _
                                Optional ByVal EmployeeList As String = "") As ResourceExcelReportData

        Dim rerd As New ResourceExcelReportData

        'column indices to make it easier to add columns later:

        Dim DsData As New DataSet
        Dim DtReturn As New DataTable

        Dim NumberOfDays As Long = 0
        Dim RowsPerDay As Integer = 0
        Dim GrandTotal As Decimal = 0.0

        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim k As Integer = 0


        If StartDate.ToShortDateString() = EndDate.ToShortDateString() Then
            NumberOfDays = 1
        Else
            EndDate = DateAdd(DateInterval.Day, 1, EndDate)
            NumberOfDays = DateDiff(DateInterval.Day, StartDate, EndDate)
        End If

        If NumberOfDays > 0 Then

            'Five header rows.  
            '===========================================
            'Row 0 = Merged resource type descriptions,
            'Row 1 = Resource name, 
            'Row 2 = spacer, 
            'Row 3 = Date/Time header, 
            'Row(4 = spacer)

            'row 5 will be start of data:
            'number of dynamic rows depends on time interval
            Select Case TimeInterval
                Case TimeIncrement.HalfHour
                    RowsPerDay = 48
                Case TimeIncrement.Hour
                    RowsPerDay = 24
                Case TimeIncrement.FourHours
                    RowsPerDay = 6
                Case TimeIncrement.EightHours
                    RowsPerDay = 3
                Case TimeIncrement.TwentyFourHours
                    RowsPerDay = 1
            End Select

            'add an index column just in case need it for something:
            Dim Pk(0) As DataColumn

            Dim COL_INDEX As DataColumn = New DataColumn("INDEX") 'Column 0
            With COL_INDEX
                .DataType = GetType(Int32)
                .AutoIncrement = True
                .AutoIncrementSeed = 1
                .AutoIncrementStep = 1
            End With
            Pk(0) = COL_INDEX

            'Add date and time columns
            Dim COL_DATE As DataColumn = New DataColumn("DATE") 'Column 1
            COL_DATE.DataType = GetType(String)

            Dim COL_TIME As DataColumn = New DataColumn("TIME") 'Column 2
            COL_TIME.DataType = GetType(String)

            With DtReturn.Columns
                .Add(COL_INDEX)
                .Add(COL_DATE)
                .Add(COL_TIME)
            End With
            DtReturn.PrimaryKey = Pk

            'Get database data
            Dim DtHeaderInfo As New DataTable
            Dim DtResourceTypes As New DataTable
            Dim DtResourceTypesAndResources As New DataTable
            Dim DtResourceTimes As New DataTable
            Dim DtTotalTimeByResource As New DataTable

            DsData = Me.GetReportData(StartDate, EndDate, ResourceTypesList, ResourceList, OfficeList, CDPList, TrfFncList, EmployeeList)

            DtHeaderInfo = DsData.Tables(0)
            DtResourceTypes = DsData.Tables(1) 'Does the first row; the grouped header
            DtResourceTypesAndResources = DsData.Tables(2) 'does the columns that are the resources
            DtResourceTimes = DsData.Tables(3) 'does the cells that hold data
            DtTotalTimeByResource = DsData.Tables(4) ' does the resource total hours

            'Create the resource columns
            i = 0
            j = 0
            Dim LastType As String = ""
            Dim CurrType As String = ""
            Dim CurrKey As String = ""
            If DtResourceTypesAndResources.Rows.Count > 0 Then
                For i = 0 To DtResourceTypesAndResources.Rows.Count - 1
                    CurrKey = DtResourceTypesAndResources.Rows(i)("RESOURCE_KEY").ToString()
                    Dim COL_RESOURCE As DataColumn = New DataColumn(CurrKey)
                    COL_RESOURCE.DataType = GetType(String)
                    DtReturn.Columns.Add(COL_RESOURCE)
                Next
            End If

            'the two cells in the header row (resource names) that are blank right before the first data row????
            i = 0
            j = 0
            Dim headerRow As DataRow
            headerRow = DtReturn.NewRow()
            headerRow("DATE") = ""
            headerRow("TIME") = ""
            DtReturn.Rows.Add(headerRow)


            'add a row to hold the totals
            Dim TotalsRow As DataRow
            TotalsRow = DtReturn.NewRow()
            TotalsRow("DATE") = "TOTAL (Hours):"
            TotalsRow("TIME") = "GRAND TOTAL"
            DtReturn.Rows.Add(TotalsRow)


            i = 0
            j = 0

            'Create the data (that shows times) rows
            Dim CurrDate As DateTime = StartDate

            For i = 0 To NumberOfDays '- 1
                For j = 0 To RowsPerDay - 1
                    Dim row As DataRow
                    row = DtReturn.NewRow()
                    If j = 0 Then
                        row("DATE") = CurrDate.ToShortDateString()
                    ElseIf j > 0 Then
                        row("DATE") = ""
                    End If
                    row("TIME") = CurrDate
                    DtReturn.Rows.Add(row)
                    Select Case TimeInterval
                        Case TimeIncrement.HalfHour
                            CurrDate = DateAdd(DateInterval.Minute, 30, CurrDate)
                        Case TimeIncrement.Hour
                            CurrDate = DateAdd(DateInterval.Hour, 1, CurrDate)
                        Case TimeIncrement.FourHours
                            CurrDate = DateAdd(DateInterval.Hour, 4, CurrDate)
                        Case TimeIncrement.EightHours
                            CurrDate = DateAdd(DateInterval.Hour, 8, CurrDate)
                        Case TimeIncrement.TwentyFourHours 'it should never step into this...
                    End Select
                Next
                j = 0
            Next
            i = 0

            'Loop through the dynamic columns and....
            For i = ColIdxStartOfDynamicColumns To DtReturn.Columns.Count - 1
                Dim ThisResourceCode As String = ""
                Try 'Clean the resource name header row (row 2) 
                    Dim ResourceRow As DataRow
                    ResourceRow = DtReturn.Rows.Find(1)
                    If DtReturn.Columns(i).ColumnName.ToString().IndexOf("|") > -1 Then
                        Dim ar() As String
                        ar = DtReturn.Columns(i).ColumnName.ToString().Split("|")
                        ThisResourceCode = ar(1)
                        ResourceRow(DtReturn.Columns(i).ColumnName) = ar(1)
                    End If
                Catch ex As Exception
                End Try
                Try 'Add The totals for each resource
                    Dim ThirdRow As DataRow
                    Dim ResourceTotal As Decimal = 0.0
                    ThirdRow = DtReturn.Rows.Find(2)
                    'get total from dataview
                    Dim dv As DataView = New DataView(DtTotalTimeByResource)
                    dv.RowFilter = "RESOURCE_CODE = '" & ThisResourceCode & "'"
                    Try
                        If IsNumeric(dv(0)("TOTAL_MINUTES")) = True Then
                            ResourceTotal = CType(dv(0)("TOTAL_MINUTES"), Decimal) / 60.0
                            GrandTotal += ResourceTotal
                        End If
                    Catch ex As Exception
                    End Try
                    'write to cell
                    ThirdRow(DtReturn.Columns(i).ColumnName) = FormatNumber(ResourceTotal, 2, TriState.True, TriState.False, TriState.True)
                Catch ex As Exception
                End Try
            Next
            i = 0
            j = 0


            'Add the data (time used "x")
            i = 0
            j = 0
            k = HeaderRows

            'For each row:
            If DtResourceTimes.Rows.Count > 0 Then
                For i = 0 To DtResourceTimes.Rows.Count - 1
                    Dim CurrResourceKeyFullKey As String = DtResourceTimes.Rows(i)("RESOURCE_KEY").ToString()
                    Dim CurrResourceKey As String = "" 'DtResourceTimes.Rows(i)("RESOURCE_KEY").ToString()
                    Dim ar() As String
                    ar = CurrResourceKeyFullKey.Split("|")
                    CurrResourceKey = ar(0) & "|" & ar(1)
                    Dim CurrEventTypeId As Integer = 0
                    CurrEventTypeId = CType(ar(2), Integer)
                    Dim CurrJobLogUdv1 As String = ""
                    CurrJobLogUdv1 = ar(3)
                    Dim CurrStartTime As DateTime = Convert.ToDateTime(DtResourceTimes.Rows(i)("START_TIME"))
                    Dim CurrEndTime As DateTime = Convert.ToDateTime(DtResourceTimes.Rows(i)("END_TIME"))
                    Dim CurrCellTime As DateTime = Nothing
                    If CurrEndTime.ToShortTimeString().IndexOf(":00") > -1 Or CurrEndTime.ToShortTimeString().IndexOf(":30") > -1 Then
                        CurrEndTime = DateAdd(DateInterval.Minute, -1, CurrEndTime)
                    End If
                    'For each dynamic column
                    For j = ColIdxStartOfDynamicColumns To DtReturn.Columns.Count - 1
                        'find the column
                        If DtReturn.Columns(j).ColumnName = CurrResourceKey Then
                            'find the rows
                            k = 0
                            For k = HeaderRows To DtReturn.Rows.Count - 1
                                If IsDate(DtReturn.Rows(k)("TIME")) = True Then
                                    CurrCellTime = Convert.ToDateTime(DtReturn.Rows(k)("TIME"))
                                    If CurrCellTime >= CurrStartTime And CurrCellTime <= CurrEndTime Then
                                        DtReturn.Rows(k)(j) = "##" & CurrEventTypeId.ToString() & "|" & CurrJobLogUdv1.ToString()
                                    End If
                                End If
                            Next
                            Exit For
                        End If
                    Next
                    j = 0
                Next
            End If

            'remove the date from the time column because we don't need it anymore
            i = 0
            j = 0
            For i = 0 To DtReturn.Rows.Count - 1
                Try
                    If IsDate(DtReturn.Rows(i)("TIME")) = True Then
                        DtReturn.Rows(i)("TIME") = Convert.ToDateTime(DtReturn.Rows(i)("TIME")).ToShortTimeString()
                    End If
                Catch ex As Exception
                End Try
            Next
            'add the grand total
            Try
                Dim GrandTotalRow As DataRow
                GrandTotalRow = DtReturn.Rows.Find(2)
                GrandTotalRow(DtReturn.Columns(2).ColumnName) = FormatNumber(GrandTotal, 2, TriState.True, TriState.False, TriState.True)
                'DtReturn(2)(2) = FormatNumber(GrandTotalRow, 2, TriState.True, TriState.False, TriState.True)
            Catch ex As Exception
            End Try

            With rerd
                .GridData = DtReturn
                .ColumnData = DtResourceTypes
            End With
            Return rerd



        End If 'NumberOfDays > 0
    End Function

    Public Function GetReportData(ByVal StartDate As DateTime, ByVal EndDate As DateTime, _
                                    Optional ByVal ResourceTypesList As String = "", _
                                    Optional ByVal ResourceList As String = "", _
                                    Optional ByVal OfficeList As String = "", _
                                    Optional ByVal CDPList As String = "", _
                                    Optional ByVal TrfFncList As String = "", _
                                    Optional ByVal EmployeeList As String = "") As DataSet
        Try
            Dim arP(8) As SqlParameter

            Dim pStartDate As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            pStartDate.Value = StartDate
            arP(0) = pStartDate

            Dim pEndDate As New SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            pEndDate.Value = EndDate
            arP(1) = pEndDate

            Dim pOfficeList As New SqlParameter("@OFFICE_LIST", SqlDbType.VarChar, 4000)
            pOfficeList.Value = OfficeList
            arP(2) = pOfficeList

            Dim pCDPList As New SqlParameter("@CDP_LIST", SqlDbType.VarChar, 4000)
            pCDPList.Value = CDPList
            arP(3) = pCDPList

            Dim pResourceList As New SqlParameter("@RESOURCE_CODE_LIST", SqlDbType.VarChar, 4000)
            pResourceList.Value = ResourceList
            arP(4) = pResourceList

            Dim pTrfFncList As New SqlParameter("@TRAFFIC_FNC_LIST", SqlDbType.VarChar, 4000)
            pTrfFncList.Value = TrfFncList
            arP(5) = pTrfFncList

            Dim pEmployeeList As New SqlParameter("@EMPLOYEE_LIST", SqlDbType.VarChar, 4000)
            pEmployeeList.Value = EmployeeList
            arP(6) = pEmployeeList

            Dim pResourceTypesList As New SqlParameter("@RESOURCE_TYPES_LIST", SqlDbType.VarChar, 4000)
            pResourceTypesList.Value = ResourceTypesList
            arP(7) = pResourceTypesList

            Return SqlHelper.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_RESOURCES_RPT_EXCEL", arP)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function EventTypeColors(ByVal DoUpdate As Boolean,
                                    Optional ByRef RadClrPickerNone As Telerik.Web.UI.RadColorPicker = Nothing,
                                    Optional ByRef RadClrPickerFixed As Telerik.Web.UI.RadColorPicker = Nothing,
                                    Optional ByRef RadClrPickerFlex As Telerik.Web.UI.RadColorPicker = Nothing,
                                    Optional ByRef RadClrPickerPreEmptable As Telerik.Web.UI.RadColorPicker = Nothing,
                                    Optional ByRef RadClrPickerHold As Telerik.Web.UI.RadColorPicker = Nothing
                                    ) As DataTable
        Dim arP(6) As SqlParameter

        Dim pNO_EVENT_TYPE_COLOR As New SqlParameter("@NO_EVENT_TYPE_COLOR", SqlDbType.VarChar, 7)
        Try
            pNO_EVENT_TYPE_COLOR.Value = ColorTranslator.ToHtml(RadClrPickerNone.SelectedColor).ToString()
        Catch ex As Exception
            pNO_EVENT_TYPE_COLOR.Value = System.DBNull.Value
        End Try
        arP(0) = pNO_EVENT_TYPE_COLOR

        Dim pSTATIC_COLOR As New SqlParameter("@FIXED_COLOR", SqlDbType.VarChar, 7)
        Try
            pSTATIC_COLOR.Value = ColorTranslator.ToHtml(RadClrPickerFixed.SelectedColor).ToString()
        Catch ex As Exception
            pSTATIC_COLOR.Value = System.DBNull.Value
        End Try
        arP(1) = pSTATIC_COLOR

        Dim pFLEX_COLOR As New SqlParameter("@FLEX_COLOR", SqlDbType.VarChar, 7)
        Try
            pFLEX_COLOR.Value = ColorTranslator.ToHtml(RadClrPickerFlex.SelectedColor).ToString()
        Catch ex As Exception
            pFLEX_COLOR.Value = System.DBNull.Value
        End Try
        arP(2) = pFLEX_COLOR

        Dim pPRE_EMPTABLE_COLOR As New SqlParameter("@PRE_EMPTABLE_COLOR", SqlDbType.VarChar, 7)
        Try
            pPRE_EMPTABLE_COLOR.Value = ColorTranslator.ToHtml(RadClrPickerPreEmptable.SelectedColor).ToString()
        Catch ex As Exception
            pPRE_EMPTABLE_COLOR.Value = System.DBNull.Value
        End Try
        arP(3) = pPRE_EMPTABLE_COLOR

        Dim pHOLD_COLOR As New SqlParameter("@HOLD_COLOR", SqlDbType.VarChar, 7)
        Try
            pHOLD_COLOR.Value = ColorTranslator.ToHtml(RadClrPickerHold.SelectedColor).ToString()
        Catch ex As Exception
            pHOLD_COLOR.Value = System.DBNull.Value
        End Try
        arP(4) = pHOLD_COLOR

        Dim pDO_UPDATE As New SqlParameter("@DO_UPDATE", SqlDbType.TinyInt)
        pDO_UPDATE.Value = MiscFN.BoolToInt(DoUpdate)
        arP(5) = pDO_UPDATE

        Dim dt As New DataTable
        dt = SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.StoredProcedure, "usp_wv_RESOURCES_RPT_EVENT_TYPE_COLORS", "DtColors", arP)

        If dt.Rows.Count > 0 Then

            Try
                RadClrPickerNone.SelectedColor = ColorTranslator.FromHtml(dt.Rows(0)("NO_EVENT_TYPE_COLOR").ToString())
            Catch ex As Exception
            End Try
            Try
                RadClrPickerFixed.SelectedColor = ColorTranslator.FromHtml(dt.Rows(0)("STATIC_COLOR").ToString())
            Catch ex As Exception
            End Try
            Try
                RadClrPickerFlex.SelectedColor = ColorTranslator.FromHtml(dt.Rows(0)("FLEX_COLOR").ToString())
            Catch ex As Exception
            End Try
            Try
                RadClrPickerPreEmptable.SelectedColor = ColorTranslator.FromHtml(dt.Rows(0)("PRE_EMPTABLE_COLOR").ToString())
            Catch ex As Exception
            End Try
            Try
                RadClrPickerHold.SelectedColor = ColorTranslator.FromHtml(dt.Rows(0)("HOLD_COLOR").ToString())
            Catch ex As Exception
            End Try

        End If

        Return dt

    End Function
#End Region

#Region " Resources "

    Public Overloads Function ResourceIsBooked(ByVal ResourceCode As String, ByVal EventId As Integer, Optional ByRef dt As DataTable = Nothing) As Boolean
        Dim IsBooked As Boolean = False
        Try
            Dim arParams(2) As SqlParameter

            Dim pRESOURCE_CODE As New SqlParameter("@RESOURCE_CODE", SqlDbType.VarChar, 6)
            pRESOURCE_CODE.Value = ResourceCode
            arParams(0) = pRESOURCE_CODE

            Dim pEVENT_ID As New SqlParameter("@EVENT_ID", SqlDbType.Int)
            pEVENT_ID.Value = EventId
            arParams(1) = pEVENT_ID


            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_RESOURCES_RESOURCE_IS_BOOKED_BY_EVENT_ID", "DtData", arParams)
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    IsBooked = True
                End If
            End If

            Return IsBooked
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Overloads Function ResourceIsBooked(ByVal ResourceCode As String, ByVal EventId As Integer, ByVal EventDate As DateTime, ByVal EventStartTime As DateTime, ByVal EventEndTime As DateTime, Optional ByRef dt As DataTable = Nothing) As Boolean
        Dim IsBooked As Boolean = False
        Try
            Dim arParams(6) As SqlParameter

            Dim pRESOURCE_CODE As New SqlParameter("@RESOURCE_CODE", SqlDbType.VarChar, 6)
            pRESOURCE_CODE.Value = ResourceCode
            arParams(0) = pRESOURCE_CODE

            Dim pEVENT_ID As New SqlParameter("@EVENT_ID_NEEDED", SqlDbType.Int)
            pEVENT_ID.Value = EventId
            arParams(1) = pEVENT_ID

            Dim pEVENT_DATE_NEEDED As New SqlParameter("@EVENT_DATE_NEEDED", SqlDbType.SmallDateTime)
            pEVENT_DATE_NEEDED.Value = EventDate
            arParams(2) = pEVENT_DATE_NEEDED

            Dim pSTART_TIME_NEEDED As New SqlParameter("@START_TIME_NEEDED", SqlDbType.SmallDateTime)
            pSTART_TIME_NEEDED.Value = EventStartTime
            arParams(3) = pSTART_TIME_NEEDED

            Dim pEND_TIME_NEEDED As New SqlParameter("@END_TIME_NEEDED", SqlDbType.SmallDateTime)
            pEND_TIME_NEEDED.Value = EventEndTime
            arParams(4) = pEND_TIME_NEEDED

            Dim pRETURN_COUNT_ONLY As New SqlParameter("@RETURN_COUNT_ONLY", SqlDbType.Bit)
            pRETURN_COUNT_ONLY.Value = False
            arParams(5) = pRETURN_COUNT_ONLY


            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_RESOURCES_RESOURCE_IS_BOOKED", "DtData", arParams)
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    IsBooked = True
                End If
            End If

            Return IsBooked
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function FindAvailableResources(ByVal EventIdList As String, ByVal ResourceTypeCode As String, ByVal AdNumber As String, ByVal UpdateResources As Boolean, ByVal OverrideExistingResources As Boolean) As DataSet
        Try
            Dim arParams(5) As SqlParameter

            Dim pEVENT_ID_LIST As New SqlParameter("@EVENT_ID_LIST", SqlDbType.VarChar, 8000)
            pEVENT_ID_LIST.Value = EventIdList
            arParams(0) = pEVENT_ID_LIST

            Dim pRESOURCE_TYPE_CODE As New SqlParameter("@RESOURCE_TYPE_CODE", SqlDbType.VarChar, 6)
            pRESOURCE_TYPE_CODE.Value = ResourceTypeCode
            arParams(1) = pRESOURCE_TYPE_CODE

            Dim pAD_NUMBER As New SqlParameter("@AD_NUMBER", SqlDbType.VarChar, 30)
            pAD_NUMBER.Value = AdNumber
            arParams(2) = pAD_NUMBER

            Dim pSAVE_RESOURCE_SELECTIONS As New SqlParameter("@SAVE_RESOURCE_SELECTIONS", SqlDbType.TinyInt)
            pSAVE_RESOURCE_SELECTIONS.Value = MiscFN.BoolToInt(UpdateResources)
            arParams(3) = pSAVE_RESOURCE_SELECTIONS

            Dim pOVERRIDE_EXISTING As New SqlParameter("@OVERRIDE_EXISTING", SqlDbType.TinyInt)
            pOVERRIDE_EXISTING.Value = MiscFN.BoolToInt(OverrideExistingResources)
            arParams(4) = pOVERRIDE_EXISTING

            Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_RESOURCES_FINDER", arParams)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Overloads Sub SetResourceDropdownlist(ByRef DdlResourceTypes As Telerik.Web.UI.RadComboBox, ByRef DdlResources As Telerik.Web.UI.RadComboBox, Optional ByVal SelValue As String = "", Optional ByVal BindDDLs As Boolean = False)
        If BindDDLs = True Then
            Dim d As New cDropDowns(mConnString)
            With DdlResourceTypes
                .DataSource = d.GetResourceTypesList()
                .DataTextField = "display"
                .DataValueField = "code"
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))
            End With
            With DdlResources
                .DataSource = GetResourcesList()
                .DataValueField = "RESOURCE_CODE"
                .DataTextField = "RES_DISPLAY"
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))
            End With
        End If

        If SelValue <> "" Then
            Try
                MiscFN.RadComboBoxSetIndex(DdlResources, SelValue, False) 'set the resource
            Catch ex As Exception
            End Try
            Try
                Dim ThisType As String = ""
                Using MyConn As New SqlConnection(mConnString)
                    MyConn.Open()
                    Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                    Dim MyCmd As New SqlCommand("", MyConn, MyTrans)
                    Try
                        ThisType = MyCmd.ExecuteScalar()
                        MyTrans.Commit()
                    Catch ex As Exception
                        MyTrans.Rollback()
                    Finally
                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                    End Try
                End Using
                If ThisType <> "" Then

                End If
            Catch ex As Exception
            End Try
        End If

    End Sub

    Public Overloads Sub SetResourceDropdownlist(ByRef DdlResources As Telerik.Web.UI.RadComboBox, Optional ByVal SelValue As String = "")
        With DdlResources
            .DataSource = GetResourcesList()
            .DataValueField = "RESOURCE_CODE"
            .DataTextField = "RES_DISPLAY"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))
        End With
        If SelValue <> "" Then
            Try
                MiscFN.RadComboBoxSetIndex(DdlResources, SelValue, False)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Overloads Function GetResourcesList() As DataTable
        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_RESOURCES_VIEW_LIST", "DtResourceList")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Overloads Function GetResourcesList(ByVal ResourceTypeCode As String) As DataTable
        Try
            Dim arParams(1) As SqlParameter

            Dim pRESOURCE_CODE As New SqlParameter("@RESOURCE_TYPE_CODE", SqlDbType.VarChar, 6)
            pRESOURCE_CODE.Value = ResourceTypeCode
            arParams(0) = pRESOURCE_CODE

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_RESOURCES_VIEW_LIST_BY_TYPE", "DtResourceList", arParams)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetResourceType(ByVal ResourceCode As String) As String
        Try
            Dim ThisType As String = ""
            Using MyConn As New SqlConnection(mConnString)
                MyConn.Open()
                Dim MyCmd As New SqlCommand("SELECT RESOURCE_TYPE_CODE FROM RESOURCE WITH(NOLOCK) WHERE RESOURCE_CODE = '" & ResourceCode & "'", MyConn)
                Try
                    ThisType = MyCmd.ExecuteScalar()
                Catch ex As Exception
                Finally
                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                End Try
                Return ThisType
            End Using
        Catch ex As Exception
            Return "ERR"
        End Try

    End Function

    Public Overloads Function GetResourceTypes() As DataTable
        Try
            Dim StrSQL As String = "SELECT RESOURCE_TYPE_CODE, RESOURCE_TYPE_DESC FROM RESOURCE_TYPE WITH(NOLOCK) WHERE (RESOURCE_TYPE.INACTIVE_FLAG IS NULL OR RESOURCE_TYPE.INACTIVE_FLAG = 0) ORDER BY RESOURCE_TYPE_DESC;"
            Return SqlHelper.ExecuteDataTable(mConnString, CommandType.Text, StrSQL, "DtResourceTypes")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Overloads Function GetResourceTypes(ByVal StartDate As Date, ByVal EndDate As Date) As DataTable
        Try
            Dim arParams(2) As SqlParameter
            Dim pSTART_DATE As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            pSTART_DATE.Value = StartDate
            arParams(0) = pSTART_DATE

            Dim pEND_DATE As New SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            pEND_DATE.Value = EndDate
            arParams(1) = pEND_DATE

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_RESOURCES_GET_TYPES_BY_EVENT_DATES", "DtResourceTypes", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetResourceTypesList!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try

    End Function


    Public Function GetResourcesByType(ByVal TypesList As String) As DataTable
        Try
            Dim sb As New System.Text.StringBuilder
            With sb
                .Append("SELECT RESOURCE.RESOURCE_CODE, RESOURCE.RESOURCE_DESC, RESOURCE.RESOURCE_PRIORITY FROM RESOURCE WITH (NOLOCK) INNER JOIN RESOURCE_TYPE WITH(NOLOCK) ON RESOURCE.RESOURCE_TYPE_CODE = RESOURCE_TYPE.RESOURCE_TYPE_CODE WHERE 1 = 1 ")
                If TypesList.Trim() <> "" Then
                    .Append(" AND RESOURCE_TYPE.RESOURCE_TYPE_CODE IN (")
                    .Append(TypesList)
                    .Append(") ")
                End If
                .Append(" AND (RESOURCE.INACTIVE_FLAG IS NULL OR RESOURCE.INACTIVE_FLAG = 0)")
                .Append(" AND (RESOURCE_TYPE.INACTIVE_FLAG IS NULL OR RESOURCE_TYPE.INACTIVE_FLAG = 0)")
                .Append(" ORDER BY RESOURCE_TYPE.RESOURCE_TYPE_DESC, RESOURCE.RESOURCE_PRIORITY, RESOURCE.RESOURCE_DESC;")
            End With
            Return SqlHelper.ExecuteDataTable(mConnString, CommandType.Text, sb.ToString(), "DtResources")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function GetResourceEventDetail(ByVal ResourceCode As String, _
                                              ByRef StrType As String, ByRef StrPriority As String, _
                                              ByRef StrLastDate As String, ByRef StrLastTime As String, _
                                              ByRef StrLastAdNum As String, ByRef StrLastJobComp As String, Optional ByVal EventId As Integer = 0) As String
        Try
            Dim arParams(2) As SqlParameter

            Dim pRESOURCE_CODE As New SqlParameter("@RESOURCE_CODE", SqlDbType.VarChar, 6)
            pRESOURCE_CODE.Value = ResourceCode
            arParams(0) = pRESOURCE_CODE

            Dim pEVENT_ID As New SqlParameter("@EVENT_ID", SqlDbType.Int)
            If EventId < 1 Then
                pEVENT_ID.Value = System.DBNull.Value
            Else
                pEVENT_ID.Value = EventId
            End If
            arParams(1) = pEVENT_ID

            Dim dt As New DataTable

            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_RESOURCES_GET_DETAILS", "DtRescDtl", arParams)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0)("RESOURCE_TYPE")) = False Then
                    StrType = dt.Rows(0)("RESOURCE_TYPE")
                Else
                    StrType = ""
                End If
                If IsDBNull(dt.Rows(0)("RESOURCE_PRIORITY")) = False Then
                    StrPriority = dt.Rows(0)("RESOURCE_PRIORITY")
                Else
                    StrPriority = ""
                End If
                If IsDBNull(dt.Rows(0)("LAST_DATE")) = False Then
                    StrLastDate = Convert.ToDateTime(dt.Rows(0)("LAST_DATE")).ToLongDateString()
                Else
                    StrLastDate = ""
                End If
                If IsDBNull(dt.Rows(0)("LAST_START_TIME")) = False Then
                    StrLastTime = Convert.ToDateTime(dt.Rows(0)("LAST_START_TIME")).ToShortTimeString()
                Else
                    StrLastTime = ""
                End If
                If IsDBNull(dt.Rows(0)("LAST_END_TIME")) = False Then
                    StrLastTime &= " - "
                    StrLastTime &= Convert.ToDateTime(dt.Rows(0)("LAST_END_TIME")).ToShortTimeString()
                    'Else
                    '    StrLastTime = ""
                End If
                If IsDBNull(dt.Rows(0)("LAST_AD_NUMBER")) = False Then
                    StrLastAdNum = dt.Rows(0)("LAST_AD_NUMBER")
                Else
                    StrLastAdNum = ""
                End If
                If IsDBNull(dt.Rows(0)("LAST_JOB_AND_COMPONENT")) = False Then
                    StrLastJobComp = dt.Rows(0)("LAST_JOB_AND_COMPONENT")
                Else
                    StrLastJobComp = ""
                End If
            End If


        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

#End Region

#Region " Employees as resource "
    Public Enum SummaryLevel
        None = 0
        Day = 1
        Week = 2
        Month = 3
        Year = 4
    End Enum

    Public Overloads Function EmployeeIsBooked(ByVal EmpCode As String, ByVal EventTaskId As Integer, Optional ByRef dt As DataTable = Nothing) As Boolean
        Dim IsBooked As Boolean = False
        Try
            Dim arParams(2) As SqlParameter

            Dim pRESOURCE_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            pRESOURCE_CODE.Value = EmpCode
            arParams(0) = pRESOURCE_CODE

            Dim pEVENT_TASK_ID_NEEDED As New SqlParameter("@EVENT_TASK_ID_NEEDED", SqlDbType.Int)
            pEVENT_TASK_ID_NEEDED.Value = EventTaskId
            arParams(1) = pEVENT_TASK_ID_NEEDED

            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_RESOURCES_EMP_IS_BOOKED_BY_EVENT_TASK_ID", "DtData", arParams)
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    IsBooked = True
                End If
            End If

            Return IsBooked
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Overloads Function EmployeeIsBooked(ByVal EmpCode As String, ByVal EventTaskId As Integer, ByVal EventTaskDate As DateTime, ByVal EventTaskStartTime As DateTime, ByVal EventTaskEndTime As DateTime, Optional ByRef dt As DataTable = Nothing) As Boolean
        Dim IsBooked As Boolean = False
        Try
            Dim arParams(6) As SqlParameter

            Dim pRESOURCE_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            pRESOURCE_CODE.Value = EmpCode
            arParams(0) = pRESOURCE_CODE

            Dim pEVENT_TASK_ID_NEEDED As New SqlParameter("@EVENT_TASK_ID_NEEDED", SqlDbType.Int)
            pEVENT_TASK_ID_NEEDED.Value = EventTaskId
            arParams(1) = pEVENT_TASK_ID_NEEDED

            Dim pEVENT_TASK_DATE_NEEDED As New SqlParameter("@EVENT_TASK_DATE_NEEDED", SqlDbType.SmallDateTime)
            pEVENT_TASK_DATE_NEEDED.Value = EventTaskDate
            arParams(2) = pEVENT_TASK_DATE_NEEDED

            Dim pSTART_TIME_NEEDED As New SqlParameter("@START_TIME_NEEDED", SqlDbType.SmallDateTime)
            pSTART_TIME_NEEDED.Value = EventTaskStartTime
            arParams(3) = pSTART_TIME_NEEDED

            Dim pEND_TIME_NEEDED As New SqlParameter("@END_TIME_NEEDED", SqlDbType.SmallDateTime)
            pEND_TIME_NEEDED.Value = EventTaskEndTime
            arParams(4) = pEND_TIME_NEEDED

            Dim pRETURN_COUNT_ONLY As New SqlParameter("@RETURN_COUNT_ONLY", SqlDbType.Bit)
            pRETURN_COUNT_ONLY.Value = False
            arParams(5) = pRETURN_COUNT_ONLY


            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_RESOURCES_EMP_IS_BOOKED", "DtData", arParams)
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    IsBooked = True
                End If
            End If

            Return IsBooked
        Catch ex As Exception
            Return False
        End Try

    End Function

    'Replace the availability grid in taskassignments
    Public Function GetAvailabilityDatatable(ByVal Emp_Code As String, ByVal Start_Date As DateTime, ByVal End_Date As DateTime, ByVal Summary_Level As SummaryLevel, ByVal Roles As String, ByVal Depts As String, Optional ByVal IncludeWeekends As Boolean = False, Optional ByVal EmpList As String = "", _
                                           Optional ByVal Office As String = "", _
                                        Optional ByVal Client As String = "", _
                                        Optional ByVal Division As String = "", _
                                        Optional ByVal Product As String = "", _
                                        Optional ByVal Job As String = "", _
                                        Optional ByVal JobComp As String = "", _
                                        Optional ByVal TaskStatus As String = "", _
                                        Optional ByVal ExcludeTempComplete As Boolean = False, _
                                        Optional ByVal Manager As String = "", _
                                        Optional ByVal QueryType As String = "", _
                                        Optional ByVal ProjectSchedule_JobNumber As Integer = 0, _
                                        Optional ByVal ProjectSchedule_JobComponentNbr As Integer = 0, _
                                        Optional ByVal ProjectSchedule_JobCompWhereClause As String = "", _
                                        Optional ByVal OverrideEmployeeSecurity As Boolean = False) As DataTable
        Try
            Dim Fixed_End_Date As DateTime = Convert.ToDateTime(End_Date.ToShortDateString() & " 11:59:00 PM")
            Dim This_Summary_Level As Integer = CType(Summary_Level, Integer)

            Dim NumDays As Integer = 0
            Dim NumWeeks As Integer = 0
            Dim NumMonths As Integer = 0
            Dim NumYears As Integer = 0
            Dim NumEmps As Integer = 0
            Dim CalculatedStart As DateTime
            Dim CalculatedEnd As DateTime

            Dim TotalNumDays As Integer = CType(DateDiff(DateInterval.Day, Start_Date, End_Date), Integer)
            Dim Fixed_TotalNumDays As Integer = CType(DateDiff(DateInterval.Day, Start_Date, Fixed_End_Date), Integer)

            Dim NumDynamicColumns As Integer = 0


            Dim DsAvailability As New DataSet
            Dim DtHeaderData As New DataTable
            Dim DtGridData As New DataTable
            Dim DtColumns As New DataTable
            Dim DtEmployees As New DataTable

            Dim DtReturn As New DataTable

            Dim arParams(22) As SqlParameter

            Dim pEMP_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            pEMP_CODE.Value = Emp_Code
            arParams(0) = pEMP_CODE

            Dim pROLES As New SqlParameter("@ROLES", SqlDbType.VarChar, 4000)
            If Roles.Trim() = "" Then
                pROLES.Value = System.DBNull.Value
            Else
                pROLES.Value = Roles
            End If
            arParams(1) = pROLES

            Dim pSTART_DATE As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            pSTART_DATE.Value = Start_Date
            arParams(2) = pSTART_DATE

            Dim pEND_DATE As New SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            pEND_DATE.Value = Fixed_End_Date
            arParams(3) = pEND_DATE

            Dim pSUMMARY_LEVEL As New SqlParameter("@SUMMARY_LEVEL", SqlDbType.SmallInt)
            pSUMMARY_LEVEL.Value = This_Summary_Level
            arParams(4) = pSUMMARY_LEVEL

            Dim pDEPTS As New SqlParameter("@DEPTS", SqlDbType.VarChar, 4000)
            If Depts.Trim() = "" Then
                pDEPTS.Value = System.DBNull.Value
            Else
                pDEPTS.Value = Depts
            End If
            arParams(5) = pDEPTS


            Dim pEmpList As New SqlParameter("@EMP_LIST", SqlDbType.VarChar, 4000)
            If EmpList.Trim() = "" Then
                pEmpList.Value = System.DBNull.Value
            Else
                pEmpList.Value = EmpList
            End If
            arParams(6) = pEmpList

            Dim pUSERID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            pUSERID.Value = HttpContext.Current.Session("UserCode")
            arParams(7) = pUSERID

            Dim parameterOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
            parameterOffice.Value = Office
            arParams(8) = parameterOffice

            Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            parameterClient.Value = Client
            arParams(9) = parameterClient

            Dim parameterDivision As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
            parameterDivision.Value = Division
            arParams(10) = parameterDivision

            Dim parameterProduct As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
            parameterProduct.Value = Product
            arParams(11) = parameterProduct

            Dim parameterJob As New SqlParameter("@JobNum", SqlDbType.VarChar, 6)
            parameterJob.Value = Job
            arParams(12) = parameterJob

            Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.VarChar, 6)
            parameterJobComp.Value = JobComp
            arParams(13) = parameterJobComp

            Dim parameterTaskStatus As New SqlParameter("@TaskStatus", SqlDbType.VarChar, 1)
            parameterTaskStatus.Value = TaskStatus
            arParams(14) = parameterTaskStatus

            Dim parameterExcludeTempComplete As New SqlParameter("@ExcludeTempComplete", SqlDbType.Char, 1)
            If ExcludeTempComplete = True Then
                parameterExcludeTempComplete.Value = "Y"
            Else
                parameterExcludeTempComplete.Value = "N"
            End If
            arParams(15) = parameterExcludeTempComplete

            Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar, 6)
            parameterManager.Value = Manager
            arParams(16) = parameterManager

            Dim parameterQueryType As New SqlParameter("@QUERY_TYPE", SqlDbType.VarChar, 10)
            parameterQueryType.Value = QueryType
            arParams(17) = parameterQueryType

            Dim parameterProjectSchedule_JobNumber As New SqlParameter("@PSWL_JOB_NUMBER", SqlDbType.Int)
            If ProjectSchedule_JobNumber = 0 Then
                parameterProjectSchedule_JobNumber.Value = System.DBNull.Value
            Else
                parameterProjectSchedule_JobNumber.Value = ProjectSchedule_JobNumber
            End If
            arParams(18) = parameterProjectSchedule_JobNumber

            Dim parameterProjectSchedule_JobComponentNbr As New SqlParameter("@PSWL_JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            If ProjectSchedule_JobNumber = 0 Then
                parameterProjectSchedule_JobComponentNbr.Value = System.DBNull.Value
            Else
                parameterProjectSchedule_JobComponentNbr.Value = ProjectSchedule_JobComponentNbr
            End If
            arParams(19) = parameterProjectSchedule_JobComponentNbr

            Dim parameterProjectSchedule_JobCompWhereClause As New SqlParameter("@JC_LIST", SqlDbType.VarChar, 8000)
            parameterProjectSchedule_JobCompWhereClause.Value = ProjectSchedule_JobCompWhereClause
            arParams(20) = parameterProjectSchedule_JobCompWhereClause

            Dim parameterOverrideEmployeeSecurity As New SqlParameter("@OVERRIDE_EMP_SEC", SqlDbType.SmallInt)
            If OverrideEmployeeSecurity = True Then
                parameterOverrideEmployeeSecurity.Value = 1
            Else
                parameterOverrideEmployeeSecurity.Value = 0
            End If
            arParams(21) = parameterOverrideEmployeeSecurity

            DsAvailability = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_RESOURCES_EMP_AVAILABILITY", arParams)

            '''just return a quick for now:
            ''Return DsAvailability.Tables(1)
            If Summary_Level = SummaryLevel.None Then
                Return DsAvailability.Tables(0)
            End If

            DtHeaderData = DsAvailability.Tables(0)
            DtEmployees = DsAvailability.Tables(1)
            DtColumns = DsAvailability.Tables(2)
            DtGridData = DsAvailability.Tables(3)

            'This comes frm table 0 in Emp Availability Query
            If DtHeaderData.Rows.Count > 0 Then
                NumDays = DtHeaderData.Rows(0)("NUM_DAYS")
                NumWeeks = DtHeaderData.Rows(0)("NUM_WEEKS")
                NumMonths = DtHeaderData.Rows(0)("NUM_MONTHS")
                NumYears = DtHeaderData.Rows(0)("NUM_YEARS")
                NumEmps = DtHeaderData.Rows(0)("NUM_EMPS")
                CalculatedStart = Convert.ToDateTime(DtHeaderData.Rows(0)("CALCULATED_START_DATE"))
                CalculatedEnd = Convert.ToDateTime(DtHeaderData.Rows(0)("CALCULATED_END_DATE"))
            End If


            'Create the non-dynamic columns:
            Dim COL_EMP_CODE As DataColumn = New DataColumn("EMP_CODE")
            With COL_EMP_CODE
                .DataType = GetType(String)
                .ColumnName = "EMP_CODE"
            End With

            Dim COL_EMP_FML_NAME As DataColumn = New DataColumn("EMP_FML_NAME")
            With COL_EMP_FML_NAME
                .DataType = GetType(String)
                .ColumnName = "Employee"
            End With

            Dim COL_OFFICE_CODE As DataColumn = New DataColumn("OFFICE_CODE")
            With COL_OFFICE_CODE
                .DataType = GetType(String)
                .ColumnName = "Office"
            End With

            Dim COL_DEPT_TEAM As DataColumn = New DataColumn("DEPT_TEAM")
            With COL_DEPT_TEAM
                .DataType = GetType(String)
                .ColumnName = "Department"
            End With

            Dim COL_DEF_TRF_ROLE As DataColumn = New DataColumn("DEF_TRF_ROLE")
            With COL_DEF_TRF_ROLE
                .DataType = GetType(String)
                .ColumnName = "Role"
            End With

            Dim COL_EMP_DIRECT_HRS_GOAL_PERC As DataColumn = New DataColumn("EMP_DIRECT_HRS_GOAL_PERC")
            With COL_EMP_DIRECT_HRS_GOAL_PERC
                .DataType = GetType(Decimal)
                .ColumnName = "Direct Hours Goal %"
            End With

            'Dim COL_STD_HRS_AVAIL As DataColumn = New DataColumn("STD_HRS_AVAIL")
            'With COL_STD_HRS_AVAIL
            '    .DataType = GetType(Decimal)
            '    .ColumnName = "Std. Hours Available"
            'End With

            Dim COL_EMP_DIRECT_HRS_GOAL_HOURS As DataColumn = New DataColumn("EMP_DIRECT_HRS_GOAL_HOURS")
            With COL_EMP_DIRECT_HRS_GOAL_HOURS
                .DataType = GetType(Decimal)
                .ColumnName = "Direct Hours Goal"
            End With

            'Dim COL_HRS_USED_NON_TASK As DataColumn = New DataColumn("HRS_USED_NON_TASK")
            'With COL_HRS_USED_NON_TASK
            '    .DataType = GetType(Decimal)
            '    .ColumnName = ""
            'End With

            Dim COL_HRS_AVAIL As DataColumn = New DataColumn("HRS_AVAIL")
            With COL_HRS_AVAIL
                .DataType = GetType(Decimal)
                .ColumnName = "Hours Available (Adj)"
            End With

            'Dim COL_HRS_ASSIGNED_TASK As DataColumn = New DataColumn("HRS_ASSIGNED_TASK")
            'With COL_HRS_ASSIGNED_TASK
            '    .DataType = GetType(Decimal)
            '    .ColumnName = ""
            'End With

            'Dim COL_HRS_BALANCE_AVAIL As DataColumn = New DataColumn("HRS_BALANCE_AVAIL")
            'With COL_HRS_BALANCE_AVAIL
            '    .DataType = GetType(Decimal)
            '    .ColumnName = ""
            'End With

            'Dim COL_ As DataColumn = New DataColumn("")
            'COL_.DataType = GetType(String)

            With DtReturn.Columns
                .Add(COL_EMP_CODE)
                .Add(COL_OFFICE_CODE)
                .Add(COL_EMP_FML_NAME)
                .Add(COL_DEPT_TEAM)
                .Add(COL_DEF_TRF_ROLE)
                .Add(COL_HRS_AVAIL)
                .Add(COL_EMP_DIRECT_HRS_GOAL_PERC)
                '.Add(COL_STD_HRS_AVAIL)
                .Add(COL_EMP_DIRECT_HRS_GOAL_HOURS)
                '.Add(COL_HRS_USED_NON_TASK)
                '.Add(COL_HRS_ASSIGNED_TASK)
                '.Add(COL_HRS_BALANCE_AVAIL)
            End With


            Select Case Summary_Level
                Case SummaryLevel.Day
                    'NumDynamicColumns = NumDays
                    NumDynamicColumns = TotalNumDays
                Case SummaryLevel.Week
                    'NumDynamicColumns = NumWeeks
                Case SummaryLevel.Month
                    'NumDynamicColumns = NumMonths
                Case SummaryLevel.Year
                    'NumDynamicColumns = NumYears
            End Select



            'Add one row for each Employee (Table 1 from Emp Availability query)
            If DtEmployees.Rows.Count > 0 Then
                For j As Integer = 0 To DtEmployees.Rows.Count - 1
                    Dim r As DataRow
                    r = DtReturn.NewRow()
                    r("EMP_CODE") = DtEmployees.Rows(j)("EMP_CODE")
                    r("Employee") = DtEmployees.Rows(j)("EMP_FML_NAME")
                    r("Office") = DtEmployees.Rows(j)("OFFICE_CODE")
                    r("Department") = DtEmployees.Rows(j)("DP_TM_CODE")
                    r("Direct Hours Goal %") = DtEmployees.Rows(j)("EMP_DIRECT_HRS_GOAL_PERC")
                    r("Direct Hours Goal") = DtEmployees.Rows(j)("EMP_DIRECT_HRS_GOAL_HOURS")
                    r("Hours Available (Adj)") = DtEmployees.Rows(j)("HRS_AVAIL")
                    r("Role") = DtEmployees.Rows(j)("DEF_TRF_ROLE")
                    DtReturn.Rows.Add(r)
                Next
            End If

            'build the dynamic columns, take 2:
            Dim Roof As Integer = 1
            'If Summary_Level = SummaryLevel.Day Then
            '    'If Depts.Trim() = "" Then
            '    '    Roof = 1
            '    'ElseIf Depts.Trim() <> "" And (Emp_Code = "%" Or Emp_Code = "") Then
            '    '    Roof = 2
            '    'End If
            '    If (Emp_Code = "%" Or Emp_Code = "") And Depts.Trim() = "" Then
            '        Roof = 2
            '    End If
            'End If

            'Create the dynamic columns and add it to the rows:
            'column count from table 2 from Emp Avail query
            Try
                Dim ThisDate As DateTime = Start_Date
                Dim ctr As Integer = 0
                Dim DynaCol4 As New DataColumn 'hold the column total...
                For z As Integer = 0 To DtColumns.Rows.Count - Roof
                    If ctr <= NumDays Then
                        Dim ColumnsAdded As Boolean = False
                        Dim DynaCol As New DataColumn 'hold the task hours used, this will get displayed
                        Dim DynaCol2 As New DataColumn 'hold the available hours for the math...
                        Dim DynaCol3 As New DataColumn 'hold the direct hours goal hours
                        Dim DynaCol5 As New DataColumn 'hold the overbooked
                        DynaCol.DataType = GetType(Decimal)
                        DynaCol2.DataType = GetType(Decimal)
                        DynaCol3.DataType = GetType(Decimal)
                        DynaCol5.DataType = GetType(Integer)
                        Select Case Summary_Level
                            Case SummaryLevel.Day
                                ThisDate = Me.GetTheDate(Start_Date, DtColumns.Rows(z)("CTR"), SummaryLevel.Day)
                                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                    DynaCol.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString()
                                    DynaCol2.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_OVER_BOOKED"
                                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                Else
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                End If
                            Case SummaryLevel.Week
                                ThisDate = DtColumns.Rows(z)("WEEK_OF_YEAR") 'Me.GetTheDate(Start_Date, DtColumns.Rows(z)("CTR"), SummaryLevel.Week)
                                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                    DynaCol.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString()
                                    DynaCol2.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_OVER_BOOKED"
                                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                Else
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                End If
                            Case SummaryLevel.Month
                                ThisDate = Me.GetTheDate(Start_Date, DtColumns.Rows(z)("CTR"), SummaryLevel.Month)
                                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                    DynaCol.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString()
                                    DynaCol2.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_OVER_BOOKED"
                                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                Else
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                End If
                            Case SummaryLevel.Year
                                ThisDate = Me.GetTheDate(Start_Date, DtColumns.Rows(z)("CTR"), SummaryLevel.Year)
                                DynaCol.ColumnName = ThisDate.Year.ToString()
                                DynaCol2.ColumnName = ThisDate.Year.ToString() & "_HRS_AVAIL"
                                DynaCol3.ColumnName = ThisDate.Year.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                DynaCol5.ColumnName = ThisDate.Year.ToString() & "_OVER_BOOKED"
                        End Select
                        If Summary_Level = SummaryLevel.Day Then
                            If IncludeWeekends = True Then
                                DtReturn.Columns.Add(DynaCol)
                                DtReturn.Columns.Add(DynaCol2)
                                DtReturn.Columns.Add(DynaCol3)
                                DtReturn.Columns.Add(DynaCol5)
                                ColumnsAdded = True
                            ElseIf IncludeWeekends = False And (ThisDate.DayOfWeek <> DayOfWeek.Saturday And ThisDate.DayOfWeek <> DayOfWeek.Sunday) Then
                                DtReturn.Columns.Add(DynaCol)
                                DtReturn.Columns.Add(DynaCol2)
                                DtReturn.Columns.Add(DynaCol3)
                                DtReturn.Columns.Add(DynaCol5)
                                ColumnsAdded = True
                            End If
                        Else
                            'If ThisDate <= End_Date Then
                            DtReturn.Columns.Add(DynaCol)
                            DtReturn.Columns.Add(DynaCol2)
                            DtReturn.Columns.Add(DynaCol3)
                            DtReturn.Columns.Add(DynaCol5)
                            ColumnsAdded = True
                            'End If
                        End If
                        If ColumnsAdded = True Then
                            ctr += 1
                        End If
                    End If
                Next
                'after all the dyna columns added, add that total column
                DynaCol4.ColumnName = "Total"
                DynaCol4.DataType = GetType(Decimal)

                DtReturn.Columns.Add(DynaCol4)
            Catch ex As Exception

            End Try


            'update the dynamic columns...
            'for each employee
            'this should be filtering table 3 of emp avail query to populate

            For k As Integer = 0 To DtEmployees.Rows.Count - 1
                Dim CurrEmpCode As String = DtEmployees.Rows(k)("EMP_CODE")
                Dim CurrColumnName As String = "" 'HOURS USED
                Dim CurrColumnName2 As String = "" 'HOURS AVAIL
                Dim CurrColumnName3 As String = "" 'HOURS GOAL
                Dim CurrColumnName4 As String = "" 'OVER BOOKED
                Dim CurrDate As DateTime
                Dim CurrDayOfYear As Integer
                Dim TheEmpRow() As Data.DataRow = DtReturn.Select("EMP_CODE = '" & CurrEmpCode & "'")

                Dim TheDataRow() As Data.DataRow = Nothing 'DtGridData.Select("EMP_CODE = '" & CurrEmpCode & "'")
                Try
                    'go through the dynamic columns
                    Dim RunningColumnTotal As Decimal = 0.0
                    For m As Integer = 0 To DtColumns.Rows.Count - Roof
                        Dim DtTemp As New DataTable
                        DtTemp = DtGridData.Copy()
                        Select Case Summary_Level
                            Case SummaryLevel.Day
                                Try
                                    CurrDate = Me.GetTheDate(Start_Date, DtColumns.Rows(m)("CTR"), SummaryLevel.Day)
                                    TheDataRow = DtTemp.Select("EMP_CODE = '" & CurrEmpCode & "' AND DAY_OF_YEAR = " & DtColumns.Rows(m)("CTR"))
                                    If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                        CurrColumnName = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString()
                                        CurrColumnName2 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_OVER_BOOKED"
                                    ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                        CurrColumnName = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                    Else
                                        CurrColumnName = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                    End If
                                    TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    TheEmpRow(0)(CurrColumnName2) = CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                    TheEmpRow(0)(CurrColumnName3) = CType(TheDataRow(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                                    TheEmpRow(0)(CurrColumnName4) = CType(TheDataRow(0)("OVER_BOOKED"), Integer)
                                    Try
                                        RunningColumnTotal = RunningColumnTotal + CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception
                                End Try
                            Case SummaryLevel.Week
                                Try
                                    CurrDate = DtColumns.Rows(m)("WEEK_OF_YEAR") 'Me.GetTheDate(Start_Date, DtColumns.Rows(m)("CTR"), SummaryLevel.Week)
                                    TheDataRow = DtTemp.Select("EMP_CODE = '" & CurrEmpCode & "' AND WEEK_OF_YEAR = '" & DtColumns.Rows(m)("WEEK_OF_YEAR") & "'")
                                    If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                        CurrColumnName = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString()
                                        CurrColumnName2 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_OVER_BOOKED"
                                    ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                        CurrColumnName = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                    Else
                                        CurrColumnName = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                    End If
                                    TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    TheEmpRow(0)(CurrColumnName2) = CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                    TheEmpRow(0)(CurrColumnName3) = CType(TheDataRow(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                                    TheEmpRow(0)(CurrColumnName4) = CType(TheDataRow(0)("OVER_BOOKED"), Integer)
                                    Try
                                        RunningColumnTotal = RunningColumnTotal + CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception
                                End Try
                            Case SummaryLevel.Month
                                Try
                                    CurrDate = Me.GetTheDate(Start_Date, DtColumns.Rows(m)("CTR"), SummaryLevel.Month)
                                    TheDataRow = DtTemp.Select("EMP_CODE = '" & CurrEmpCode & "' AND MONTH_OF_YEAR = " & DtColumns.Rows(m)("CTR"))
                                    If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                        CurrColumnName = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString()
                                        CurrColumnName2 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_OVER_BOOKED"
                                    ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                        CurrColumnName = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                    Else
                                        CurrColumnName = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                    End If
                                    TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    TheEmpRow(0)(CurrColumnName2) = CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                    TheEmpRow(0)(CurrColumnName3) = CType(TheDataRow(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                                    TheEmpRow(0)(CurrColumnName4) = CType(TheDataRow(0)("OVER_BOOKED"), Integer)
                                    Try
                                        RunningColumnTotal = RunningColumnTotal + CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception
                                End Try
                            Case SummaryLevel.Year
                                Try
                                    CurrDate = Me.GetTheDate(Start_Date, DtColumns.Rows(m)("CTR"), SummaryLevel.Year)
                                    TheDataRow = DtTemp.Select("EMP_CODE = '" & CurrEmpCode & "' AND [YEAR] = " & DtColumns.Rows(m)("CTR"))
                                    CurrColumnName = CurrDate.Year.ToString()
                                    CurrColumnName2 = CurrDate.Year.ToString() & "_HRS_AVAIL"
                                    CurrColumnName3 = CurrDate.Year.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    CurrColumnName4 = CurrDate.Year.ToString() & "_OVER_BOOKED"
                                    TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    TheEmpRow(0)(CurrColumnName2) = CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                    TheEmpRow(0)(CurrColumnName3) = CType(TheDataRow(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                                    TheEmpRow(0)(CurrColumnName4) = CType(TheDataRow(0)("OVER_BOOKED"), Decimal)
                                    Try
                                        RunningColumnTotal = RunningColumnTotal + CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception
                                End Try
                        End Select
                        DtTemp.Dispose()
                    Next
                    'try adding a totals column...
                    TheEmpRow(0)("Total") = RunningColumnTotal
                Catch ex As Exception
                End Try
            Next




            Return DtReturn




        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetAllocationDatatable(ByVal Emp_Code As String, ByVal Start_Date As DateTime, ByVal End_Date As DateTime, ByVal Summary_Level As SummaryLevel, ByVal Roles As String, ByVal Depts As String, Optional ByVal IncludeWeekends As Boolean = False, Optional ByVal EmpList As String = "", _
                                           Optional ByVal Office As String = "", _
                                        Optional ByVal Client As String = "", _
                                        Optional ByVal Division As String = "", _
                                        Optional ByVal Product As String = "", _
                                        Optional ByVal Job As String = "", _
                                        Optional ByVal JobComp As String = "", _
                                        Optional ByVal TaskStatus As String = "", _
                                        Optional ByVal ExcludeTempComplete As Boolean = False, _
                                        Optional ByVal Manager As String = "", _
                                        Optional ByVal QueryType As String = "", _
                                        Optional ByVal ProjectSchedule_JobNumber As Integer = 0, _
                                        Optional ByVal ProjectSchedule_JobComponentNbr As Integer = 0, _
                                        Optional ByVal ProjectSchedule_JobCompWhereClause As String = "", _
                                        Optional ByVal OverrideEmployeeSecurity As Boolean = False) As DataTable
        Try
            Dim Fixed_End_Date As DateTime = Convert.ToDateTime(End_Date.ToShortDateString() & " 11:59:00 PM")
            Dim This_Summary_Level As Integer = CType(Summary_Level, Integer)

            Dim NumDays As Integer = 0
            Dim NumWeeks As Integer = 0
            Dim NumMonths As Integer = 0
            Dim NumYears As Integer = 0
            Dim NumEmps As Integer = 0
            Dim CalculatedStart As DateTime
            Dim CalculatedEnd As DateTime

            Dim TotalNumDays As Integer = CType(DateDiff(DateInterval.Day, Start_Date, End_Date), Integer)
            Dim Fixed_TotalNumDays As Integer = CType(DateDiff(DateInterval.Day, Start_Date, Fixed_End_Date), Integer)

            Dim NumDynamicColumns As Integer = 0


            Dim DsAvailability As New DataSet
            Dim DtHeaderData As New DataTable
            Dim DtGridData As New DataTable
            Dim DtColumns As New DataTable
            Dim DtEmployees As New DataTable

            Dim DtReturn As New DataTable

            Dim arParams(22) As SqlParameter

            Dim pEMP_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            pEMP_CODE.Value = Emp_Code
            arParams(0) = pEMP_CODE

            Dim pROLES As New SqlParameter("@ROLES", SqlDbType.VarChar, 4000)
            If Roles.Trim() = "" Then
                pROLES.Value = System.DBNull.Value
            Else
                pROLES.Value = Roles
            End If
            arParams(1) = pROLES

            Dim pSTART_DATE As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            pSTART_DATE.Value = Start_Date
            arParams(2) = pSTART_DATE

            Dim pEND_DATE As New SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            pEND_DATE.Value = Fixed_End_Date
            arParams(3) = pEND_DATE

            Dim pSUMMARY_LEVEL As New SqlParameter("@SUMMARY_LEVEL", SqlDbType.SmallInt)
            pSUMMARY_LEVEL.Value = This_Summary_Level
            arParams(4) = pSUMMARY_LEVEL

            Dim pDEPTS As New SqlParameter("@DEPTS", SqlDbType.VarChar, 4000)
            If Depts.Trim() = "" Then
                pDEPTS.Value = System.DBNull.Value
            Else
                pDEPTS.Value = Depts
            End If
            arParams(5) = pDEPTS


            Dim pEmpList As New SqlParameter("@EMP_LIST", SqlDbType.VarChar, 4000)
            If EmpList.Trim() = "" Then
                pEmpList.Value = System.DBNull.Value
            Else
                pEmpList.Value = EmpList
            End If
            arParams(6) = pEmpList

            Dim pUSERID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            pUSERID.Value = HttpContext.Current.Session("UserCode")
            arParams(7) = pUSERID

            Dim parameterOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
            parameterOffice.Value = Office
            arParams(8) = parameterOffice

            Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            parameterClient.Value = Client
            arParams(9) = parameterClient

            Dim parameterDivision As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
            parameterDivision.Value = Division
            arParams(10) = parameterDivision

            Dim parameterProduct As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
            parameterProduct.Value = Product
            arParams(11) = parameterProduct

            Dim parameterJob As New SqlParameter("@JobNum", SqlDbType.VarChar, 6)
            parameterJob.Value = Job
            arParams(12) = parameterJob

            Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.VarChar, 6)
            parameterJobComp.Value = JobComp
            arParams(13) = parameterJobComp

            Dim parameterTaskStatus As New SqlParameter("@TaskStatus", SqlDbType.VarChar, 1)
            parameterTaskStatus.Value = TaskStatus
            arParams(14) = parameterTaskStatus

            Dim parameterExcludeTempComplete As New SqlParameter("@ExcludeTempComplete", SqlDbType.Char, 1)
            If ExcludeTempComplete = True Then
                parameterExcludeTempComplete.Value = "Y"
            Else
                parameterExcludeTempComplete.Value = "N"
            End If
            arParams(15) = parameterExcludeTempComplete

            Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar, 6)
            parameterManager.Value = Manager
            arParams(16) = parameterManager

            Dim parameterQueryType As New SqlParameter("@QUERY_TYPE", SqlDbType.VarChar, 10)
            parameterQueryType.Value = QueryType
            arParams(17) = parameterQueryType

            Dim parameterProjectSchedule_JobNumber As New SqlParameter("@PSWL_JOB_NUMBER", SqlDbType.Int)
            If ProjectSchedule_JobNumber = 0 Then
                parameterProjectSchedule_JobNumber.Value = System.DBNull.Value
            Else
                parameterProjectSchedule_JobNumber.Value = ProjectSchedule_JobNumber
            End If
            arParams(18) = parameterProjectSchedule_JobNumber

            Dim parameterProjectSchedule_JobComponentNbr As New SqlParameter("@PSWL_JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            If ProjectSchedule_JobNumber = 0 Then
                parameterProjectSchedule_JobComponentNbr.Value = System.DBNull.Value
            Else
                parameterProjectSchedule_JobComponentNbr.Value = ProjectSchedule_JobComponentNbr
            End If
            arParams(19) = parameterProjectSchedule_JobComponentNbr

            Dim parameterProjectSchedule_JobCompWhereClause As New SqlParameter("@JC_LIST", SqlDbType.VarChar, 8000)
            parameterProjectSchedule_JobCompWhereClause.Value = ProjectSchedule_JobCompWhereClause
            arParams(20) = parameterProjectSchedule_JobCompWhereClause

            Dim parameterOverrideEmployeeSecurity As New SqlParameter("@OVERRIDE_EMP_SEC", SqlDbType.SmallInt)
            If OverrideEmployeeSecurity = True Then
                parameterOverrideEmployeeSecurity.Value = 1
            Else
                parameterOverrideEmployeeSecurity.Value = 0
            End If
            arParams(21) = parameterOverrideEmployeeSecurity

            DsAvailability = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_RESOURCES_EMP_ALLOCATION", arParams)

            '''just return a quick for now:
            ''Return DsAvailability.Tables(1)
            If Summary_Level = SummaryLevel.None Then
                Return DsAvailability.Tables(0)
            End If

            DtHeaderData = DsAvailability.Tables(0)
            DtEmployees = DsAvailability.Tables(1)
            DtColumns = DsAvailability.Tables(2)
            DtGridData = DsAvailability.Tables(3)

            'This comes frm table 0 in Emp Availability Query
            If DtHeaderData.Rows.Count > 0 Then
                NumDays = DtHeaderData.Rows(0)("NUM_DAYS")
                NumWeeks = DtHeaderData.Rows(0)("NUM_WEEKS")
                NumMonths = DtHeaderData.Rows(0)("NUM_MONTHS")
                NumYears = DtHeaderData.Rows(0)("NUM_YEARS")
                NumEmps = DtHeaderData.Rows(0)("NUM_EMPS")
                CalculatedStart = Convert.ToDateTime(DtHeaderData.Rows(0)("CALCULATED_START_DATE"))
                CalculatedEnd = Convert.ToDateTime(DtHeaderData.Rows(0)("CALCULATED_END_DATE"))
            End If


            'Create the non-dynamic columns:
            Dim COL_EMP_CODE As DataColumn = New DataColumn("EMP_CODE")
            With COL_EMP_CODE
                .DataType = GetType(String)
                .ColumnName = "EMP_CODE"
            End With

            Dim COL_EMP_FML_NAME As DataColumn = New DataColumn("EMP_FML_NAME")
            With COL_EMP_FML_NAME
                .DataType = GetType(String)
                .ColumnName = "Employee"
            End With

            Dim COL_OFFICE_CODE As DataColumn = New DataColumn("OFFICE_CODE")
            With COL_OFFICE_CODE
                .DataType = GetType(String)
                .ColumnName = "Office"
            End With

            Dim COL_DEPT_TEAM As DataColumn = New DataColumn("DEPT_TEAM")
            With COL_DEPT_TEAM
                .DataType = GetType(String)
                .ColumnName = "Department"
            End With

            Dim COL_EMP_DIRECT_HRS_GOAL_PERC As DataColumn = New DataColumn("EMP_DIRECT_HRS_GOAL_PERC")
            With COL_EMP_DIRECT_HRS_GOAL_PERC
                .DataType = GetType(Decimal)
                .ColumnName = "Direct Hours Goal %"
            End With

            'Dim COL_STD_HRS_AVAIL As DataColumn = New DataColumn("STD_HRS_AVAIL")
            'With COL_STD_HRS_AVAIL
            '    .DataType = GetType(Decimal)
            '    .ColumnName = "Std. Hours Available"
            'End With

            Dim COL_EMP_DIRECT_HRS_GOAL_HOURS As DataColumn = New DataColumn("EMP_DIRECT_HRS_GOAL_HOURS")
            With COL_EMP_DIRECT_HRS_GOAL_HOURS
                .DataType = GetType(Decimal)
                .ColumnName = "Direct Hours Goal"
            End With

            'Dim COL_HRS_USED_NON_TASK As DataColumn = New DataColumn("HRS_USED_NON_TASK")
            'With COL_HRS_USED_NON_TASK
            '    .DataType = GetType(Decimal)
            '    .ColumnName = ""
            'End With

            Dim COL_HRS_AVAIL As DataColumn = New DataColumn("HRS_AVAIL")
            With COL_HRS_AVAIL
                .DataType = GetType(Decimal)
                .ColumnName = "Hours Available (Adj)"
            End With

            Dim COL_HRS_ASSIGNED_TASK As DataColumn = New DataColumn("HRS_ASSIGNED_TASK")
            With COL_HRS_ASSIGNED_TASK
                .DataType = GetType(Decimal)
                .ColumnName = "Hours Assigned"
            End With

            'Dim COL_HRS_BALANCE_AVAIL As DataColumn = New DataColumn("HRS_BALANCE_AVAIL")
            'With COL_HRS_BALANCE_AVAIL
            '    .DataType = GetType(Decimal)
            '    .ColumnName = ""
            'End With

            'Dim COL_ As DataColumn = New DataColumn("")
            'COL_.DataType = GetType(String)

            With DtReturn.Columns
                .Add(COL_EMP_CODE)
                '.Add(COL_OFFICE_CODE)
                .Add(COL_EMP_FML_NAME)
                .Add(COL_DEPT_TEAM)
                '.Add(COL_HRS_AVAIL)
                '.Add(COL_EMP_DIRECT_HRS_GOAL_PERC)
                '.Add(COL_STD_HRS_AVAIL)
                '.Add(COL_EMP_DIRECT_HRS_GOAL_HOURS)
                '.Add(COL_HRS_USED_NON_TASK)
                '.Add(COL_HRS_ASSIGNED_TASK)
                '.Add(COL_HRS_BALANCE_AVAIL)
            End With


            Select Case Summary_Level
                Case SummaryLevel.Day
                    'NumDynamicColumns = NumDays
                    NumDynamicColumns = TotalNumDays
                Case SummaryLevel.Week
                    'NumDynamicColumns = NumWeeks
                Case SummaryLevel.Month
                    'NumDynamicColumns = NumMonths
                Case SummaryLevel.Year
                    'NumDynamicColumns = NumYears
            End Select



            'Add one row for each Employee (Table 1 from Emp Availability query)
            If DtEmployees.Rows.Count > 0 Then
                For j As Integer = 0 To DtEmployees.Rows.Count - 1
                    Dim r As DataRow
                    r = DtReturn.NewRow()
                    r("EMP_CODE") = DtEmployees.Rows(j)("EMP_CODE")
                    r("Employee") = DtEmployees.Rows(j)("EMP_FML_NAME")
                    'r("Office") = DtEmployees.Rows(j)("OFFICE_CODE")
                    r("Department") = DtEmployees.Rows(j)("DP_TM_DESC")
                    'r("Direct Hours Goal %") = DtEmployees.Rows(j)("EMP_DIRECT_HRS_GOAL_PERC")
                    'r("Direct Hours Goal") = DtEmployees.Rows(j)("EMP_DIRECT_HRS_GOAL_HOURS")
                    'r("Hours Available (Adj)") = DtEmployees.Rows(j)("HRS_AVAIL")
                    'r("Hours Assigned") = DtEmployees.Rows(j)("HRS_ASSIGNED_TASK")
                    DtReturn.Rows.Add(r)
                Next
            End If

            'build the dynamic columns, take 2:
            Dim Roof As Integer = 1
            'If Summary_Level = SummaryLevel.Day Then
            '    'If Depts.Trim() = "" Then
            '    '    Roof = 1
            '    'ElseIf Depts.Trim() <> "" And (Emp_Code = "%" Or Emp_Code = "") Then
            '    '    Roof = 2
            '    'End If
            '    If (Emp_Code = "%" Or Emp_Code = "") And Depts.Trim() = "" Then
            '        Roof = 2
            '    End If
            'End If

            'Create the dynamic columns and add it to the rows:
            'column count from table 2 from Emp Avail query
            Try
                Dim ThisDate As DateTime = Start_Date
                Dim ctr As Integer = 0
                Dim DynaCol4 As New DataColumn 'hold the column total...
                For z As Integer = 0 To DtColumns.Rows.Count - Roof
                    If ctr <= NumDays Then
                        Dim ColumnsAdded As Boolean = False
                        Dim DynaCol As New DataColumn 'hold the task hours used, this will get displayed
                        Dim DynaCol2 As New DataColumn 'hold the available hours for the math...
                        Dim DynaCol3 As New DataColumn 'hold the direct hours goal hours
                        Dim DynaCol5 As New DataColumn 'hold the overbooked
                        Dim DynaCol6 As New DataColumn 'hold the overbooked
                        DynaCol.DataType = GetType(Decimal)
                        DynaCol2.DataType = GetType(Decimal)
                        DynaCol3.DataType = GetType(Decimal)
                        DynaCol5.DataType = GetType(Integer)
                        DynaCol6.DataType = GetType(Decimal)
                        Select Case Summary_Level
                            Case SummaryLevel.Day
                                ThisDate = Me.GetTheDate(Start_Date, DtColumns.Rows(z)("CTR"), SummaryLevel.Day)
                                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                    DynaCol.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString()
                                    DynaCol2.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_PERC_WORKED"
                                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_PERC_WORKED"
                                Else
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_PERC_WORKED"
                                End If
                            Case SummaryLevel.Week
                                ThisDate = DtColumns.Rows(z)("WEEK_OF_YEAR") 'Me.GetTheDate(Start_Date, DtColumns.Rows(z)("CTR"), SummaryLevel.Week)
                                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                    DynaCol.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString()
                                    DynaCol2.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_PERC_WORKED"
                                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_PERC_WORKED"
                                Else
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_PERC_WORKED"
                                End If
                            Case SummaryLevel.Month
                                ThisDate = Me.GetTheDate(Start_Date, DtColumns.Rows(z)("CTR"), SummaryLevel.Month)
                                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                    DynaCol.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString()
                                    DynaCol2.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_PERC_WORKED"
                                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_PERC_WORKED"
                                Else
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_PERC_WORKED"
                                End If
                            Case SummaryLevel.Year
                                ThisDate = Me.GetTheDate(Start_Date, DtColumns.Rows(z)("CTR"), SummaryLevel.Year)
                                DynaCol.ColumnName = ThisDate.Year.ToString()
                                DynaCol2.ColumnName = ThisDate.Year.ToString() & "_HRS_AVAIL"
                                DynaCol3.ColumnName = ThisDate.Year.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                DynaCol5.ColumnName = ThisDate.Year.ToString() & "_OVER_BOOKED"
                                DynaCol6.ColumnName = ThisDate.Year.ToString() & "_PERC_WORKED"
                        End Select
                        If Summary_Level = SummaryLevel.Day Then
                            If IncludeWeekends = True Then
                                DtReturn.Columns.Add(DynaCol)
                                DtReturn.Columns.Add(DynaCol2)
                                'DtReturn.Columns.Add(DynaCol3)
                                DtReturn.Columns.Add(DynaCol5)
                                DtReturn.Columns.Add(DynaCol6)
                                ColumnsAdded = True
                            ElseIf IncludeWeekends = False And (ThisDate.DayOfWeek <> DayOfWeek.Saturday And ThisDate.DayOfWeek <> DayOfWeek.Sunday) Then
                                DtReturn.Columns.Add(DynaCol)
                                DtReturn.Columns.Add(DynaCol2)
                                'DtReturn.Columns.Add(DynaCol3)
                                DtReturn.Columns.Add(DynaCol5)
                                DtReturn.Columns.Add(DynaCol6)
                                ColumnsAdded = True
                            End If
                        Else
                            'If ThisDate <= End_Date Then
                            DtReturn.Columns.Add(DynaCol)
                            DtReturn.Columns.Add(DynaCol2)
                            'DtReturn.Columns.Add(DynaCol3)
                            DtReturn.Columns.Add(DynaCol5)
                            DtReturn.Columns.Add(DynaCol6)
                            ColumnsAdded = True
                            'End If
                        End If
                        If ColumnsAdded = True Then
                            ctr += 1
                        End If
                    End If
                Next
                'after all the dyna columns added, add that total column
                DynaCol4.ColumnName = "Total"
                DynaCol4.DataType = GetType(Decimal)

                'DtReturn.Columns.Add(DynaCol4)
            Catch ex As Exception

            End Try


            'update the dynamic columns...
            'for each employee
            'this should be filtering table 3 of emp avail query to populate

            For k As Integer = 0 To DtEmployees.Rows.Count - 1
                Dim CurrEmpCode As String = DtEmployees.Rows(k)("EMP_CODE")
                Dim CurrColumnName As String = "" 'HOURS USED
                Dim CurrColumnName2 As String = "" 'HOURS AVAIL
                Dim CurrColumnName3 As String = "" 'HOURS GOAL
                Dim CurrColumnName4 As String = "" 'OVER BOOKED
                Dim CurrColumnName5 As String = "" 'OVER BOOKED
                Dim CurrDate As DateTime
                Dim CurrDayOfYear As Integer
                Dim TheEmpRow() As Data.DataRow = DtReturn.Select("EMP_CODE = '" & CurrEmpCode & "'")

                Dim TheDataRow() As Data.DataRow = Nothing 'DtGridData.Select("EMP_CODE = '" & CurrEmpCode & "'")
                Try
                    'go through the dynamic columns
                    Dim RunningColumnTotal As Decimal = 0.0
                    For m As Integer = 0 To DtColumns.Rows.Count - Roof
                        Dim DtTemp As New DataTable
                        DtTemp = DtGridData.Copy()
                        Select Case Summary_Level
                            Case SummaryLevel.Day
                                Try
                                    CurrDate = Me.GetTheDate(Start_Date, DtColumns.Rows(m)("CTR"), SummaryLevel.Day)
                                    TheDataRow = DtTemp.Select("EMP_CODE = '" & CurrEmpCode & "' AND DAY_OF_YEAR = " & DtColumns.Rows(m)("CTR"))
                                    If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                        CurrColumnName = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString()
                                        CurrColumnName2 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_PERC_WORKED"
                                    ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                        CurrColumnName = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_PERC_WORKED"
                                    Else
                                        CurrColumnName = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_PERC_WORKED"
                                    End If
                                    'TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    TheEmpRow(0)(CurrColumnName2) = CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                    'TheEmpRow(0)(CurrColumnName3) = CType(TheDataRow(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                                    TheEmpRow(0)(CurrColumnName4) = CType(TheDataRow(0)("OVER_BOOKED"), Integer)
                                    TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("PERC_WORKED"), Decimal)
                                    Try
                                        RunningColumnTotal = RunningColumnTotal + CType(TheDataRow(0)("PERC_WORKED"), Decimal)
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception
                                End Try
                            Case SummaryLevel.Week
                                Try
                                    CurrDate = DtColumns.Rows(m)("WEEK_OF_YEAR") 'Me.GetTheDate(Start_Date, DtColumns.Rows(m)("CTR"), SummaryLevel.Week)
                                    TheDataRow = DtTemp.Select("EMP_CODE = '" & CurrEmpCode & "' AND WEEK_OF_YEAR = '" & DtColumns.Rows(m)("WEEK_OF_YEAR") & "'")
                                    If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                        CurrColumnName = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString()
                                        CurrColumnName2 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_PERC_WORKED"
                                    ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                        CurrColumnName = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_PERC_WORKED"
                                    Else
                                        CurrColumnName = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_PERC_WORKED"
                                    End If
                                    'TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    TheEmpRow(0)(CurrColumnName2) = CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                    'TheEmpRow(0)(CurrColumnName3) = CType(TheDataRow(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                                    TheEmpRow(0)(CurrColumnName4) = CType(TheDataRow(0)("OVER_BOOKED"), Integer)
                                    TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("PERC_WORKED"), Decimal)
                                    Try
                                        RunningColumnTotal = RunningColumnTotal + CType(TheDataRow(0)("PERC_WORKED"), Decimal)
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception
                                End Try
                            Case SummaryLevel.Month
                                Try
                                    CurrDate = Me.GetTheDate(Start_Date, DtColumns.Rows(m)("CTR"), SummaryLevel.Month)
                                    TheDataRow = DtTemp.Select("EMP_CODE = '" & CurrEmpCode & "' AND MONTH_OF_YEAR = " & DtColumns.Rows(m)("CTR"))
                                    If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                        CurrColumnName = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString()
                                        CurrColumnName2 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_PERC_WORKED"
                                    ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                        CurrColumnName = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_PERC_WORKED"
                                    Else
                                        CurrColumnName = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_PERC_WORKED"
                                    End If
                                    'TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    TheEmpRow(0)(CurrColumnName2) = CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                    'TheEmpRow(0)(CurrColumnName3) = CType(TheDataRow(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                                    TheEmpRow(0)(CurrColumnName4) = CType(TheDataRow(0)("OVER_BOOKED"), Integer)
                                    TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("PERC_WORKED"), Decimal)
                                    Try
                                        RunningColumnTotal = RunningColumnTotal + CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception
                                End Try
                            Case SummaryLevel.Year
                                Try
                                    CurrDate = Me.GetTheDate(Start_Date, DtColumns.Rows(m)("CTR"), SummaryLevel.Year)
                                    TheDataRow = DtTemp.Select("EMP_CODE = '" & CurrEmpCode & "' AND [YEAR] = " & DtColumns.Rows(m)("CTR"))
                                    CurrColumnName = CurrDate.Year.ToString()
                                    CurrColumnName2 = CurrDate.Year.ToString() & "_HRS_AVAIL"
                                    CurrColumnName3 = CurrDate.Year.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    CurrColumnName4 = CurrDate.Year.ToString() & "_OVER_BOOKED"
                                    CurrColumnName4 = CurrDate.Year.ToString() & "_PERC_WORKED"
                                    'TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    TheEmpRow(0)(CurrColumnName2) = CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                    'TheEmpRow(0)(CurrColumnName3) = CType(TheDataRow(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                                    TheEmpRow(0)(CurrColumnName4) = CType(TheDataRow(0)("OVER_BOOKED"), Decimal)
                                    TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("PERC_WORKED"), Decimal)
                                    Try
                                        RunningColumnTotal = RunningColumnTotal + CType(TheDataRow(0)("PERC_WORKED"), Decimal)
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception
                                End Try
                        End Select
                        DtTemp.Dispose()
                    Next
                    'try adding a totals column...
                    'TheEmpRow(0)("Total") = RunningColumnTotal
                Catch ex As Exception
                End Try
            Next




            Return DtReturn




        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetAllocationDatatableJob(ByVal Emp_Code As String, ByVal Start_Date As DateTime, ByVal End_Date As DateTime, ByVal Summary_Level As SummaryLevel, ByVal Roles As String, ByVal Depts As String, Optional ByVal IncludeWeekends As Boolean = False, Optional ByVal EmpList As String = "", _
                                           Optional ByVal Office As String = "", _
                                        Optional ByVal Client As String = "", _
                                        Optional ByVal Division As String = "", _
                                        Optional ByVal Product As String = "", _
                                        Optional ByVal Job As String = "", _
                                        Optional ByVal JobComp As String = "", _
                                        Optional ByVal TaskStatus As String = "", _
                                        Optional ByVal ExcludeTempComplete As Boolean = False, _
                                        Optional ByVal Manager As String = "", _
                                        Optional ByVal QueryType As String = "", _
                                        Optional ByVal ProjectSchedule_JobNumber As Integer = 0, _
                                        Optional ByVal ProjectSchedule_JobComponentNbr As Integer = 0, _
                                        Optional ByVal ProjectSchedule_JobCompWhereClause As String = "", _
                                        Optional ByVal OverrideEmployeeSecurity As Boolean = False) As DataTable
        Try
            Dim Fixed_End_Date As DateTime = Convert.ToDateTime(End_Date.ToShortDateString() & " 11:59:00 PM")
            Dim This_Summary_Level As Integer = CType(Summary_Level, Integer)

            Dim NumDays As Integer = 0
            Dim NumWeeks As Integer = 0
            Dim NumMonths As Integer = 0
            Dim NumYears As Integer = 0
            Dim NumEmps As Integer = 0
            Dim CalculatedStart As DateTime
            Dim CalculatedEnd As DateTime

            Dim TotalNumDays As Integer = CType(DateDiff(DateInterval.Day, Start_Date, End_Date), Integer)
            Dim Fixed_TotalNumDays As Integer = CType(DateDiff(DateInterval.Day, Start_Date, Fixed_End_Date), Integer)

            Dim NumDynamicColumns As Integer = 0


            Dim DsAvailability As New DataSet
            Dim DtHeaderData As New DataTable
            Dim DtGridData As New DataTable
            Dim DtColumns As New DataTable
            Dim DtEmployees As New DataTable

            Dim DtReturn As New DataTable

            Dim arParams(22) As SqlParameter

            Dim pEMP_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            pEMP_CODE.Value = Emp_Code
            arParams(0) = pEMP_CODE

            Dim pROLES As New SqlParameter("@ROLES", SqlDbType.VarChar, 4000)
            If Roles.Trim() = "" Then
                pROLES.Value = System.DBNull.Value
            Else
                pROLES.Value = Roles
            End If
            arParams(1) = pROLES

            Dim pSTART_DATE As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            pSTART_DATE.Value = Start_Date
            arParams(2) = pSTART_DATE

            Dim pEND_DATE As New SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            pEND_DATE.Value = Fixed_End_Date
            arParams(3) = pEND_DATE

            Dim pSUMMARY_LEVEL As New SqlParameter("@SUMMARY_LEVEL", SqlDbType.SmallInt)
            pSUMMARY_LEVEL.Value = This_Summary_Level
            arParams(4) = pSUMMARY_LEVEL

            Dim pDEPTS As New SqlParameter("@DEPTS", SqlDbType.VarChar, 4000)
            If Depts.Trim() = "" Then
                pDEPTS.Value = System.DBNull.Value
            Else
                pDEPTS.Value = Depts
            End If
            arParams(5) = pDEPTS


            Dim pEmpList As New SqlParameter("@EMP_LIST", SqlDbType.VarChar, 4000)
            If EmpList.Trim() = "" Then
                pEmpList.Value = System.DBNull.Value
            Else
                pEmpList.Value = EmpList
            End If
            arParams(6) = pEmpList

            Dim pUSERID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            pUSERID.Value = HttpContext.Current.Session("UserCode")
            arParams(7) = pUSERID

            Dim parameterOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
            parameterOffice.Value = Office
            arParams(8) = parameterOffice

            Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            parameterClient.Value = Client
            arParams(9) = parameterClient

            Dim parameterDivision As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
            parameterDivision.Value = Division
            arParams(10) = parameterDivision

            Dim parameterProduct As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
            parameterProduct.Value = Product
            arParams(11) = parameterProduct

            Dim parameterJob As New SqlParameter("@JobNum", SqlDbType.VarChar, 6)
            parameterJob.Value = Job
            arParams(12) = parameterJob

            Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.VarChar, 6)
            parameterJobComp.Value = JobComp
            arParams(13) = parameterJobComp

            Dim parameterTaskStatus As New SqlParameter("@TaskStatus", SqlDbType.VarChar, 1)
            parameterTaskStatus.Value = TaskStatus
            arParams(14) = parameterTaskStatus

            Dim parameterExcludeTempComplete As New SqlParameter("@ExcludeTempComplete", SqlDbType.Char, 1)
            If ExcludeTempComplete = True Then
                parameterExcludeTempComplete.Value = "Y"
            Else
                parameterExcludeTempComplete.Value = "N"
            End If
            arParams(15) = parameterExcludeTempComplete

            Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar, 6)
            parameterManager.Value = Manager
            arParams(16) = parameterManager

            Dim parameterQueryType As New SqlParameter("@QUERY_TYPE", SqlDbType.VarChar, 10)
            parameterQueryType.Value = QueryType
            arParams(17) = parameterQueryType

            Dim parameterProjectSchedule_JobNumber As New SqlParameter("@PSWL_JOB_NUMBER", SqlDbType.Int)
            If ProjectSchedule_JobNumber = 0 Then
                parameterProjectSchedule_JobNumber.Value = System.DBNull.Value
            Else
                parameterProjectSchedule_JobNumber.Value = ProjectSchedule_JobNumber
            End If
            arParams(18) = parameterProjectSchedule_JobNumber

            Dim parameterProjectSchedule_JobComponentNbr As New SqlParameter("@PSWL_JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            If ProjectSchedule_JobNumber = 0 Then
                parameterProjectSchedule_JobComponentNbr.Value = System.DBNull.Value
            Else
                parameterProjectSchedule_JobComponentNbr.Value = ProjectSchedule_JobComponentNbr
            End If
            arParams(19) = parameterProjectSchedule_JobComponentNbr

            Dim parameterProjectSchedule_JobCompWhereClause As New SqlParameter("@JC_LIST", SqlDbType.VarChar, 8000)
            parameterProjectSchedule_JobCompWhereClause.Value = ProjectSchedule_JobCompWhereClause
            arParams(20) = parameterProjectSchedule_JobCompWhereClause

            Dim parameterOverrideEmployeeSecurity As New SqlParameter("@OVERRIDE_EMP_SEC", SqlDbType.SmallInt)
            If OverrideEmployeeSecurity = True Then
                parameterOverrideEmployeeSecurity.Value = 1
            Else
                parameterOverrideEmployeeSecurity.Value = 0
            End If
            arParams(21) = parameterOverrideEmployeeSecurity

            DsAvailability = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_RESOURCES_EMP_ALLOCATION", arParams)

            '''just return a quick for now:
            ''Return DsAvailability.Tables(1)
            If Summary_Level = SummaryLevel.None Then
                Return DsAvailability.Tables(0)
            End If

            DtHeaderData = DsAvailability.Tables(0)
            DtEmployees = DsAvailability.Tables(4)
            DtColumns = DsAvailability.Tables(2)
            DtGridData = DsAvailability.Tables(5)

            'This comes frm table 0 in Emp Availability Query
            If DtHeaderData.Rows.Count > 0 Then
                NumDays = DtHeaderData.Rows(0)("NUM_DAYS")
                NumWeeks = DtHeaderData.Rows(0)("NUM_WEEKS")
                NumMonths = DtHeaderData.Rows(0)("NUM_MONTHS")
                NumYears = DtHeaderData.Rows(0)("NUM_YEARS")
                NumEmps = DtHeaderData.Rows(0)("NUM_EMPS")
                CalculatedStart = Convert.ToDateTime(DtHeaderData.Rows(0)("CALCULATED_START_DATE"))
                CalculatedEnd = Convert.ToDateTime(DtHeaderData.Rows(0)("CALCULATED_END_DATE"))
            End If


            'Create the non-dynamic columns:
            Dim COL_EMP_CODE As DataColumn = New DataColumn("EMP_CODE")
            With COL_EMP_CODE
                .DataType = GetType(String)
                .ColumnName = "EMP_CODE"
            End With

            Dim COL_EMP_FML_NAME As DataColumn = New DataColumn("EMP_FML_NAME")
            With COL_EMP_FML_NAME
                .DataType = GetType(String)
                .ColumnName = "Employee"
            End With

            Dim COL_OFFICE_CODE As DataColumn = New DataColumn("OFFICE_CODE")
            With COL_OFFICE_CODE
                .DataType = GetType(String)
                .ColumnName = "Office"
            End With

            Dim COL_DEPT_TEAM As DataColumn = New DataColumn("DEPT_TEAM")
            With COL_DEPT_TEAM
                .DataType = GetType(String)
                .ColumnName = "Department"
            End With

            Dim COL_JOB_NUMBER As DataColumn = New DataColumn("JOB_NUMBER")
            With COL_JOB_NUMBER
                .DataType = GetType(Integer)
                .ColumnName = "Job"
            End With

            Dim COL_JOB_COMPONENT_NBR As DataColumn = New DataColumn("JOB_COMPONENT_NBR")
            With COL_JOB_COMPONENT_NBR
                .DataType = GetType(Integer)
                .ColumnName = "Component"
            End With

            Dim COL_EMP_DIRECT_HRS_GOAL_PERC As DataColumn = New DataColumn("EMP_DIRECT_HRS_GOAL_PERC")
            With COL_EMP_DIRECT_HRS_GOAL_PERC
                .DataType = GetType(Decimal)
                .ColumnName = "Direct Hours Goal %"
            End With

            'Dim COL_STD_HRS_AVAIL As DataColumn = New DataColumn("STD_HRS_AVAIL")
            'With COL_STD_HRS_AVAIL
            '    .DataType = GetType(Decimal)
            '    .ColumnName = "Std. Hours Available"
            'End With

            Dim COL_EMP_DIRECT_HRS_GOAL_HOURS As DataColumn = New DataColumn("EMP_DIRECT_HRS_GOAL_HOURS")
            With COL_EMP_DIRECT_HRS_GOAL_HOURS
                .DataType = GetType(Decimal)
                .ColumnName = "Direct Hours Goal"
            End With

            'Dim COL_HRS_USED_NON_TASK As DataColumn = New DataColumn("HRS_USED_NON_TASK")
            'With COL_HRS_USED_NON_TASK
            '    .DataType = GetType(Decimal)
            '    .ColumnName = ""
            'End With

            Dim COL_HRS_AVAIL As DataColumn = New DataColumn("HRS_AVAIL")
            With COL_HRS_AVAIL
                .DataType = GetType(Decimal)
                .ColumnName = "Hours Available (Adj)"
            End With

            Dim COL_HRS_ASSIGNED_TASK As DataColumn = New DataColumn("HRS_ASSIGNED_TASK")
            With COL_HRS_ASSIGNED_TASK
                .DataType = GetType(Decimal)
                .ColumnName = "Hours Assigned"
            End With

            'Dim COL_HRS_BALANCE_AVAIL As DataColumn = New DataColumn("HRS_BALANCE_AVAIL")
            'With COL_HRS_BALANCE_AVAIL
            '    .DataType = GetType(Decimal)
            '    .ColumnName = ""
            'End With

            Dim COL_START_DATE As DataColumn = New DataColumn("JOB_START_DATE")
            With COL_START_DATE
                .DataType = GetType(Date)
                .ColumnName = "Project Start Date"
            End With

            Dim COL_END_DATE As DataColumn = New DataColumn("JOB_DUE_DATE")
            With COL_END_DATE
                .DataType = GetType(Date)
                .ColumnName = "Project End Date"
            End With

            Dim COL_JOB_DESC As DataColumn = New DataColumn("JOB_DESC")
            With COL_JOB_DESC
                .DataType = GetType(String)
                .ColumnName = "Job Description"
            End With

            Dim COL_JOB_COMP_DESC As DataColumn = New DataColumn("JOB_COMP_DESC")
            With COL_JOB_COMP_DESC
                .DataType = GetType(String)
                .ColumnName = "Component Description"
            End With

            Dim COL_STATUS As DataColumn = New DataColumn("TRAFFIC_STATUS")
            With COL_STATUS
                .DataType = GetType(String)
                .ColumnName = "Status"
            End With

            Dim COL_PROJECT As DataColumn = New DataColumn("PROJECT")
            With COL_PROJECT
                .DataType = GetType(String)
                .ColumnName = "Project"
            End With

            Dim COL_NON_TASK_ID As DataColumn = New DataColumn("NON_TASK_ID")
            With COL_NON_TASK_ID
                .DataType = GetType(Integer)
                .ColumnName = "NT_ID"
            End With

            'Dim COL_ As DataColumn = New DataColumn("")
            'COL_.DataType = GetType(String)

            With DtReturn.Columns
                .Add(COL_JOB_NUMBER)
                .Add(COL_JOB_COMPONENT_NBR)
                .Add(COL_NON_TASK_ID)
                .Add(COL_EMP_CODE)
                .Add(COL_OFFICE_CODE)
                .Add(COL_EMP_FML_NAME)
                .Add(COL_DEPT_TEAM)
                .Add(COL_HRS_AVAIL)
                .Add(COL_PROJECT)
                .Add(COL_START_DATE)
                .Add(COL_END_DATE)
                '.Add(COL_JOB_DESC)
                '.Add(COL_JOB_COMP_DESC)
                .Add(COL_STATUS)
                '.Add(COL_EMP_DIRECT_HRS_GOAL_PERC)
                '.Add(COL_STD_HRS_AVAIL)
                '.Add(COL_EMP_DIRECT_HRS_GOAL_HOURS)
                '.Add(COL_HRS_USED_NON_TASK)
                .Add(COL_HRS_ASSIGNED_TASK)
                '.Add(COL_HRS_BALANCE_AVAIL)
            End With


            Select Case Summary_Level
                Case SummaryLevel.Day
                    'NumDynamicColumns = NumDays
                    NumDynamicColumns = TotalNumDays
                Case SummaryLevel.Week
                    'NumDynamicColumns = NumWeeks
                Case SummaryLevel.Month
                    'NumDynamicColumns = NumMonths
                Case SummaryLevel.Year
                    'NumDynamicColumns = NumYears
            End Select



            'Add one row for each Employee (Table 1 from Emp Availability query)
            If DtEmployees.Rows.Count > 0 Then
                For j As Integer = 0 To DtEmployees.Rows.Count - 1
                    Dim r As DataRow
                    r = DtReturn.NewRow()
                    If IsDBNull(DtEmployees.Rows(j)("JOB_NUMBER")) = True Then
                        'r("Job") = DtEmployees.Rows(j)("NON_TASK_ID")
                    Else
                        r("Job") = DtEmployees.Rows(j)("JOB_NUMBER")
                    End If
                    If IsDBNull(DtEmployees.Rows(j)("JOB_NUMBER")) = True Then
                        'r("Component") = DtEmployees.Rows(j)("NON_TASK_ID")
                    Else
                        r("Component") = DtEmployees.Rows(j)("JOB_COMPONENT_NBR")
                    End If
                    If IsDBNull(DtEmployees.Rows(j)("NON_TASK_ID")) = False Then
                        r("NT_ID") = DtEmployees.Rows(j)("NON_TASK_ID")
                    End If
                    r("EMP_CODE") = DtEmployees.Rows(j)("EMP_CODE")
                    r("Employee") = DtEmployees.Rows(j)("EMP_FML_NAME")
                    r("Office") = DtEmployees.Rows(j)("OFFICE_CODE")
                    r("Department") = DtEmployees.Rows(j)("DP_TM_CODE")
                    r("Project Start Date") = DtEmployees.Rows(j)("JOB_START_DATE")
                    r("Project End Date") = DtEmployees.Rows(j)("JOB_DUE_DATE")
                    'r("Job Description") = DtEmployees.Rows(j)("JOB_DESC")
                    'r("Component Description") = DtEmployees.Rows(j)("JOB_COMP_DESC")
                    If IsDBNull(DtEmployees.Rows(j)("JOB_NUMBER")) = True Then

                    Else
                        r("Status") = DtEmployees.Rows(j)("TRAFFIC_STATUS")
                    End If
                    If IsDBNull(DtEmployees.Rows(j)("NON_TASK_ID")) = False Then
                        If IsDBNull(DtEmployees.Rows(j)("JOB_NUMBER")) = False Then
                            r("Project") = DtEmployees.Rows(j)("JOB_NUMBER").ToString.PadLeft(6, "0") & "/" & DtEmployees.Rows(j)("JOB_COMPONENT_NBR").ToString.PadLeft(3, "0") & " - " & DtEmployees.Rows(j)("JOB_DESC")
                        Else
                            r("Project") = DtEmployees.Rows(j)("JOB_DESC").ToString
                        End If
                    Else
                        r("Project") = DtEmployees.Rows(j)("JOB_NUMBER").ToString.PadLeft(6, "0") & "/" & DtEmployees.Rows(j)("JOB_COMPONENT_NBR").ToString.PadLeft(3, "0") & " - " & DtEmployees.Rows(j)("JOB_COMP_DESC")
                    End If
                    'r("Direct Hours Goal %") = DtEmployees.Rows(j)("EMP_DIRECT_HRS_GOAL_PERC")
                    'r("Direct Hours Goal") = DtEmployees.Rows(j)("EMP_DIRECT_HRS_GOAL_HOURS")
                    r("Hours Available (Adj)") = DtEmployees.Rows(j)("HRS_AVAIL")
                    r("Hours Assigned") = DtEmployees.Rows(j)("HRS_ASSIGNED_TASK")
                    DtReturn.Rows.Add(r)
                Next
            End If

            'build the dynamic columns, take 2:
            Dim Roof As Integer = 1
            'If Summary_Level = SummaryLevel.Day Then
            '    'If Depts.Trim() = "" Then
            '    '    Roof = 1
            '    'ElseIf Depts.Trim() <> "" And (Emp_Code = "%" Or Emp_Code = "") Then
            '    '    Roof = 2
            '    'End If
            '    If (Emp_Code = "%" Or Emp_Code = "") And Depts.Trim() = "" Then
            '        Roof = 2
            '    End If
            'End If

            'Create the dynamic columns and add it to the rows:
            'column count from table 2 from Emp Avail query
            Try
                Dim ThisDate As DateTime = Start_Date
                Dim ctr As Integer = 0
                Dim DynaCol4 As New DataColumn 'hold the column total...
                For z As Integer = 0 To DtColumns.Rows.Count - Roof
                    If ctr <= NumDays Then
                        Dim ColumnsAdded As Boolean = False
                        Dim DynaCol As New DataColumn 'hold the task hours used, this will get displayed
                        Dim DynaCol2 As New DataColumn 'hold the available hours for the math...
                        Dim DynaCol3 As New DataColumn 'hold the direct hours goal hours
                        Dim DynaCol5 As New DataColumn 'hold the overbooked
                        Dim DynaCol6 As New DataColumn 'hold the overbooked
                        DynaCol.DataType = GetType(Decimal)
                        DynaCol2.DataType = GetType(Decimal)
                        DynaCol3.DataType = GetType(Decimal)
                        DynaCol5.DataType = GetType(Integer)
                        DynaCol6.DataType = GetType(Decimal)
                        Select Case Summary_Level
                            Case SummaryLevel.Day
                                ThisDate = Me.GetTheDate(Start_Date, DtColumns.Rows(z)("CTR"), SummaryLevel.Day)
                                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                    DynaCol.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString()
                                    DynaCol2.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_PERC_WORKED"
                                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_PERC_WORKED"
                                Else
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_PERC_WORKED"
                                End If
                            Case SummaryLevel.Week
                                ThisDate = DtColumns.Rows(z)("WEEK_OF_YEAR") 'Me.GetTheDate(Start_Date, DtColumns.Rows(z)("CTR"), SummaryLevel.Week)
                                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                    DynaCol.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString()
                                    DynaCol2.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_PERC_WORKED"
                                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_PERC_WORKED"
                                Else
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_PERC_WORKED"
                                End If
                            Case SummaryLevel.Month
                                ThisDate = Me.GetTheDate(Start_Date, DtColumns.Rows(z)("CTR"), SummaryLevel.Month)
                                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                    DynaCol.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString()
                                    DynaCol2.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_PERC_WORKED"
                                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_PERC_WORKED"
                                Else
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_PERC_WORKED"
                                End If
                            Case SummaryLevel.Year
                                ThisDate = Me.GetTheDate(Start_Date, DtColumns.Rows(z)("CTR"), SummaryLevel.Year)
                                DynaCol.ColumnName = ThisDate.Year.ToString()
                                DynaCol2.ColumnName = ThisDate.Year.ToString() & "_HRS_AVAIL"
                                DynaCol3.ColumnName = ThisDate.Year.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                DynaCol5.ColumnName = ThisDate.Year.ToString() & "_OVER_BOOKED"
                                DynaCol6.ColumnName = ThisDate.Year.ToString() & "_PERC_WORKED"
                        End Select
                        If Summary_Level = SummaryLevel.Day Then
                            If IncludeWeekends = True Then
                                DtReturn.Columns.Add(DynaCol)
                                DtReturn.Columns.Add(DynaCol2)
                                'DtReturn.Columns.Add(DynaCol3)
                                DtReturn.Columns.Add(DynaCol5)
                                DtReturn.Columns.Add(DynaCol6)
                                ColumnsAdded = True
                            ElseIf IncludeWeekends = False And (ThisDate.DayOfWeek <> DayOfWeek.Saturday And ThisDate.DayOfWeek <> DayOfWeek.Sunday) Then
                                DtReturn.Columns.Add(DynaCol)
                                DtReturn.Columns.Add(DynaCol2)
                                'DtReturn.Columns.Add(DynaCol3)
                                DtReturn.Columns.Add(DynaCol5)
                                DtReturn.Columns.Add(DynaCol6)
                                ColumnsAdded = True
                            End If
                        Else
                            'If ThisDate <= End_Date Then
                            DtReturn.Columns.Add(DynaCol)
                            DtReturn.Columns.Add(DynaCol2)
                            'DtReturn.Columns.Add(DynaCol3)
                            DtReturn.Columns.Add(DynaCol5)
                            DtReturn.Columns.Add(DynaCol6)
                            ColumnsAdded = True
                            'End If
                        End If
                        If ColumnsAdded = True Then
                            ctr += 1
                        End If
                    End If
                Next
                'after all the dyna columns added, add that total column
                DynaCol4.ColumnName = "Total"
                DynaCol4.DataType = GetType(Decimal)

                'DtReturn.Columns.Add(DynaCol4)
            Catch ex As Exception

            End Try


            'update the dynamic columns...
            'for each employee
            'this should be filtering table 3 of emp avail query to populate

            For k As Integer = 0 To DtEmployees.Rows.Count - 1
                Dim CurrEmpCode As String = DtEmployees.Rows(k)("EMP_CODE")
                Dim CurrJobNum As String
                If IsDBNull(DtEmployees.Rows(k)("JOB_NUMBER")) = True Then
                    'CurrJobNum = DtEmployees.Rows(k)("NON_TASK_ID")
                Else
                    CurrJobNum = DtEmployees.Rows(k)("JOB_NUMBER")
                End If
                Dim CurrCompNum As String
                If IsDBNull(DtEmployees.Rows(k)("JOB_COMPONENT_NBR")) = True Then
                    'CurrCompNum = DtEmployees.Rows(k)("NON_TASK_ID")
                Else
                    CurrCompNum = DtEmployees.Rows(k)("JOB_COMPONENT_NBR")
                End If
                Dim CurrNonTaskID As String
                If IsDBNull(DtEmployees.Rows(k)("NON_TASK_ID")) = False Then
                    CurrNonTaskID = DtEmployees.Rows(k)("NON_TASK_ID")
                End If
                Dim CurrColumnName As String = "" 'HOURS USED
                Dim CurrColumnName2 As String = "" 'HOURS AVAIL
                Dim CurrColumnName3 As String = "" 'HOURS GOAL
                Dim CurrColumnName4 As String = "" 'OVER BOOKED
                Dim CurrColumnName5 As String = "" 'OVER BOOKED
                Dim CurrDate As DateTime
                Dim CurrDayOfYear As Integer
                Dim TheEmpRow() As Data.DataRow = Nothing
                If IsDBNull(DtEmployees.Rows(k)("NON_TASK_ID")) = False Then
                    TheEmpRow = DtReturn.Select("EMP_CODE = '" & CurrEmpCode & "' AND NT_ID = " & CurrNonTaskID)
                Else
                    TheEmpRow = DtReturn.Select("EMP_CODE = '" & CurrEmpCode & "' AND Job = " & CurrJobNum & " AND Component = " & CurrCompNum)
                End If
                Dim TheDataRow() As Data.DataRow = Nothing 'DtGridData.Select("EMP_CODE = '" & CurrEmpCode & "'")
                Try
                    'go through the dynamic columns
                    Dim RunningColumnTotal As Decimal = 0.0
                    For m As Integer = 0 To DtColumns.Rows.Count - Roof
                        Dim DtTemp As New DataTable
                        DtTemp = DtGridData.Copy()
                        Select Case Summary_Level
                            Case SummaryLevel.Day
                                Try
                                    CurrDate = Me.GetTheDate(Start_Date, DtColumns.Rows(m)("CTR"), SummaryLevel.Day)
                                    If IsDBNull(DtEmployees.Rows(k)("NON_TASK_ID")) = False Then
                                        TheDataRow = DtTemp.Select("EMP_CODE = '" & CurrEmpCode & "' AND DAY_OF_YEAR = '" & DtColumns.Rows(m)("CTR") & "' AND NON_TASK_ID = " & CurrNonTaskID)
                                    Else
                                        TheDataRow = DtTemp.Select("EMP_CODE = '" & CurrEmpCode & "' AND DAY_OF_YEAR = " & DtColumns.Rows(m)("CTR") & " AND JOB_NUMBER = " & CurrJobNum & " AND JOB_COMPONENT_NBR = " & CurrCompNum)
                                    End If
                                    If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                        CurrColumnName = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString()
                                        CurrColumnName2 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_PERC_WORKED"
                                    ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                        CurrColumnName = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_PERC_WORKED"
                                    Else
                                        CurrColumnName = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_PERC_WORKED"
                                    End If
                                    If IsDBNull(DtEmployees.Rows(k)("NON_TASK_ID")) = False Then
                                        If IsDBNull(DtEmployees.Rows(k)("HRS_APPTS")) = False Then
                                            TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_APPTS"), Decimal)
                                        ElseIf IsDBNull(DtEmployees.Rows(k)("HRS_USED_NON_TASK")) = False Then
                                            TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_USED_NON_TASK"), Decimal)
                                        Else
                                            TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                        End If
                                    Else
                                        TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    End If
                                    TheEmpRow(0)(CurrColumnName2) = CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                    TheEmpRow(0)(CurrColumnName3) = CType(TheDataRow(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                                    TheEmpRow(0)(CurrColumnName4) = CType(TheDataRow(0)("OVER_BOOKED"), Integer)
                                    TheEmpRow(0)(CurrColumnName5) = CType(TheDataRow(0)("PERC_WORKED"), Decimal)
                                    Try
                                        RunningColumnTotal = RunningColumnTotal + CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception
                                End Try
                            Case SummaryLevel.Week
                                Try
                                    CurrDate = DtColumns.Rows(m)("WEEK_OF_YEAR") 'Me.GetTheDate(Start_Date, DtColumns.Rows(m)("CTR"), SummaryLevel.Week)
                                    If IsDBNull(DtEmployees.Rows(k)("NON_TASK_ID")) = False Then
                                        TheDataRow = DtTemp.Select("EMP_CODE = '" & CurrEmpCode & "' AND WEEK_OF_YEAR = '" & DtColumns.Rows(m)("WEEK_OF_YEAR") & "' AND NON_TASK_ID = " & CurrNonTaskID)
                                    Else
                                        TheDataRow = DtTemp.Select("EMP_CODE = '" & CurrEmpCode & "' AND WEEK_OF_YEAR = '" & DtColumns.Rows(m)("WEEK_OF_YEAR") & "' AND JOB_NUMBER = " & CurrJobNum & " AND JOB_COMPONENT_NBR = " & CurrCompNum)
                                    End If
                                    If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                        CurrColumnName = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString()
                                        CurrColumnName2 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_PERC_WORKED"
                                    ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                        CurrColumnName = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_PERC_WORKED"
                                    Else
                                        CurrColumnName = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_PERC_WORKED"
                                    End If
                                    If IsDBNull(DtEmployees.Rows(k)("NON_TASK_ID")) = False Then
                                        If IsDBNull(DtEmployees.Rows(k)("HRS_APPTS")) = False Then
                                            TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_APPTS"), Decimal)
                                        ElseIf IsDBNull(DtEmployees.Rows(k)("HRS_USED_NON_TASK")) = False Then
                                            TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_USED_NON_TASK"), Decimal)
                                        Else
                                            TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                        End If
                                    Else
                                        TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    End If
                                    TheEmpRow(0)(CurrColumnName2) = CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                    TheEmpRow(0)(CurrColumnName3) = CType(TheDataRow(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                                    TheEmpRow(0)(CurrColumnName4) = CType(TheDataRow(0)("OVER_BOOKED"), Integer)
                                    TheEmpRow(0)(CurrColumnName5) = CType(TheDataRow(0)("PERC_WORKED"), Decimal)
                                    Try
                                        RunningColumnTotal = RunningColumnTotal + CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception
                                End Try
                            Case SummaryLevel.Month
                                Try
                                    CurrDate = Me.GetTheDate(Start_Date, DtColumns.Rows(m)("CTR"), SummaryLevel.Month)
                                    If IsDBNull(DtEmployees.Rows(k)("NON_TASK_ID")) = False Then
                                        TheDataRow = DtTemp.Select("EMP_CODE = '" & CurrEmpCode & "' AND MONTH_OF_YEAR = '" & DtColumns.Rows(m)("CTR") & "' AND NON_TASK_ID = " & CurrNonTaskID)
                                    Else
                                        TheDataRow = DtTemp.Select("EMP_CODE = '" & CurrEmpCode & "' AND MONTH_OF_YEAR = " & DtColumns.Rows(m)("CTR") & " AND JOB_NUMBER = " & CurrJobNum & " AND JOB_COMPONENT_NBR = " & CurrCompNum)
                                    End If
                                    If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                        CurrColumnName = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString()
                                        CurrColumnName2 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_PERC_WORKED"
                                    ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                        CurrColumnName = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_PERC_WORKED"
                                    Else
                                        CurrColumnName = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_PERC_WORKED"
                                    End If
                                    If IsDBNull(DtEmployees.Rows(k)("NON_TASK_ID")) = False Then
                                        If IsDBNull(DtEmployees.Rows(k)("HRS_APPTS")) = False Then
                                            TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_APPTS"), Decimal)
                                        ElseIf IsDBNull(DtEmployees.Rows(k)("HRS_USED_NON_TASK")) = False Then
                                            TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_USED_NON_TASK"), Decimal)
                                        Else
                                            TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                        End If
                                    Else
                                        TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    End If
                                    TheEmpRow(0)(CurrColumnName2) = CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                    TheEmpRow(0)(CurrColumnName3) = CType(TheDataRow(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                                    TheEmpRow(0)(CurrColumnName4) = CType(TheDataRow(0)("OVER_BOOKED"), Integer)
                                    TheEmpRow(0)(CurrColumnName5) = CType(TheDataRow(0)("PERC_WORKED"), Decimal)
                                    Try
                                        RunningColumnTotal = RunningColumnTotal + CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception
                                End Try
                            Case SummaryLevel.Year
                                Try
                                    CurrDate = Me.GetTheDate(Start_Date, DtColumns.Rows(m)("CTR"), SummaryLevel.Year)
                                    If IsDBNull(DtEmployees.Rows(k)("NON_TASK_ID")) = False Then
                                        TheDataRow = DtTemp.Select("EMP_CODE = '" & CurrEmpCode & "' AND [YEAR] = '" & DtColumns.Rows(m)("CTR") & "' AND NON_TASK_ID = " & CurrNonTaskID)
                                    Else
                                        TheDataRow = DtTemp.Select("EMP_CODE = '" & CurrEmpCode & "' AND [YEAR] = " & DtColumns.Rows(m)("CTR") & " AND JOB_NUMBER = " & CurrJobNum & " AND JOB_COMPONENT_NBR = " & CurrCompNum)
                                    End If

                                    CurrColumnName = CurrDate.Year.ToString()
                                    CurrColumnName2 = CurrDate.Year.ToString() & "_HRS_AVAIL"
                                    CurrColumnName3 = CurrDate.Year.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    CurrColumnName4 = CurrDate.Year.ToString() & "_OVER_BOOKED"
                                    CurrColumnName4 = CurrDate.Year.ToString() & "_PERC_WORKED"
                                    If IsDBNull(DtEmployees.Rows(k)("NON_TASK_ID")) = False Then
                                        If IsDBNull(DtEmployees.Rows(k)("HRS_APPTS")) = False Then
                                            TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_APPTS"), Decimal)
                                        ElseIf IsDBNull(DtEmployees.Rows(k)("HRS_USED_NON_TASK")) = False Then
                                            TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_USED_NON_TASK"), Decimal)
                                        Else
                                            TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                        End If
                                    Else
                                        TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    End If
                                    TheEmpRow(0)(CurrColumnName2) = CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                    TheEmpRow(0)(CurrColumnName3) = CType(TheDataRow(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                                    TheEmpRow(0)(CurrColumnName4) = CType(TheDataRow(0)("OVER_BOOKED"), Decimal)
                                    TheEmpRow(0)(CurrColumnName5) = CType(TheDataRow(0)("PERC_WORKED"), Decimal)
                                    Try
                                        RunningColumnTotal = RunningColumnTotal + CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception
                                End Try
                        End Select
                        DtTemp.Dispose()
                    Next
                    'try adding a totals column...
                    'TheEmpRow(0)("Total") = RunningColumnTotal
                Catch ex As Exception
                End Try
            Next




            Return DtReturn




        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetAllocationDatatableDept(ByVal Emp_Code As String, ByVal Start_Date As DateTime, ByVal End_Date As DateTime, ByVal Summary_Level As SummaryLevel, ByVal Roles As String, ByVal Depts As String, Optional ByVal IncludeWeekends As Boolean = False, Optional ByVal EmpList As String = "", _
                                           Optional ByVal Office As String = "", _
                                        Optional ByVal Client As String = "", _
                                        Optional ByVal Division As String = "", _
                                        Optional ByVal Product As String = "", _
                                        Optional ByVal Job As String = "", _
                                        Optional ByVal JobComp As String = "", _
                                        Optional ByVal TaskStatus As String = "", _
                                        Optional ByVal ExcludeTempComplete As Boolean = False, _
                                        Optional ByVal Manager As String = "", _
                                        Optional ByVal QueryType As String = "", _
                                        Optional ByVal ProjectSchedule_JobNumber As Integer = 0, _
                                        Optional ByVal ProjectSchedule_JobComponentNbr As Integer = 0, _
                                        Optional ByVal ProjectSchedule_JobCompWhereClause As String = "", _
                                        Optional ByVal OverrideEmployeeSecurity As Boolean = False) As DataTable
        Try
            Dim Fixed_End_Date As DateTime = Convert.ToDateTime(End_Date.ToShortDateString() & " 11:59:00 PM")
            Dim This_Summary_Level As Integer = CType(Summary_Level, Integer)

            Dim NumDays As Integer = 0
            Dim NumWeeks As Integer = 0
            Dim NumMonths As Integer = 0
            Dim NumYears As Integer = 0
            Dim NumEmps As Integer = 0
            Dim CalculatedStart As DateTime
            Dim CalculatedEnd As DateTime

            Dim TotalNumDays As Integer = CType(DateDiff(DateInterval.Day, Start_Date, End_Date), Integer)
            Dim Fixed_TotalNumDays As Integer = CType(DateDiff(DateInterval.Day, Start_Date, Fixed_End_Date), Integer)

            Dim NumDynamicColumns As Integer = 0


            Dim DsAvailability As New DataSet
            Dim DtHeaderData As New DataTable
            Dim DtGridData As New DataTable
            Dim DtColumns As New DataTable
            Dim DtEmployees As New DataTable

            Dim DtReturn As New DataTable

            Dim arParams(22) As SqlParameter

            Dim pEMP_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            pEMP_CODE.Value = Emp_Code
            arParams(0) = pEMP_CODE

            Dim pROLES As New SqlParameter("@ROLES", SqlDbType.VarChar, 4000)
            If Roles.Trim() = "" Then
                pROLES.Value = System.DBNull.Value
            Else
                pROLES.Value = Roles
            End If
            arParams(1) = pROLES

            Dim pSTART_DATE As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            pSTART_DATE.Value = Start_Date
            arParams(2) = pSTART_DATE

            Dim pEND_DATE As New SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            pEND_DATE.Value = Fixed_End_Date
            arParams(3) = pEND_DATE

            Dim pSUMMARY_LEVEL As New SqlParameter("@SUMMARY_LEVEL", SqlDbType.SmallInt)
            pSUMMARY_LEVEL.Value = This_Summary_Level
            arParams(4) = pSUMMARY_LEVEL

            Dim pDEPTS As New SqlParameter("@DEPTS", SqlDbType.VarChar, 4000)
            If Depts.Trim() = "" Then
                pDEPTS.Value = System.DBNull.Value
            Else
                pDEPTS.Value = Depts
            End If
            arParams(5) = pDEPTS


            Dim pEmpList As New SqlParameter("@EMP_LIST", SqlDbType.VarChar, 4000)
            If EmpList.Trim() = "" Then
                pEmpList.Value = System.DBNull.Value
            Else
                pEmpList.Value = EmpList
            End If
            arParams(6) = pEmpList

            Dim pUSERID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            pUSERID.Value = HttpContext.Current.Session("UserCode")
            arParams(7) = pUSERID

            Dim parameterOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
            parameterOffice.Value = Office
            arParams(8) = parameterOffice

            Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            parameterClient.Value = Client
            arParams(9) = parameterClient

            Dim parameterDivision As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
            parameterDivision.Value = Division
            arParams(10) = parameterDivision

            Dim parameterProduct As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
            parameterProduct.Value = Product
            arParams(11) = parameterProduct

            Dim parameterJob As New SqlParameter("@JobNum", SqlDbType.VarChar, 6)
            parameterJob.Value = Job
            arParams(12) = parameterJob

            Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.VarChar, 6)
            parameterJobComp.Value = JobComp
            arParams(13) = parameterJobComp

            Dim parameterTaskStatus As New SqlParameter("@TaskStatus", SqlDbType.VarChar, 1)
            parameterTaskStatus.Value = TaskStatus
            arParams(14) = parameterTaskStatus

            Dim parameterExcludeTempComplete As New SqlParameter("@ExcludeTempComplete", SqlDbType.Char, 1)
            If ExcludeTempComplete = True Then
                parameterExcludeTempComplete.Value = "Y"
            Else
                parameterExcludeTempComplete.Value = "N"
            End If
            arParams(15) = parameterExcludeTempComplete

            Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar, 6)
            parameterManager.Value = Manager
            arParams(16) = parameterManager

            Dim parameterQueryType As New SqlParameter("@QUERY_TYPE", SqlDbType.VarChar, 10)
            parameterQueryType.Value = QueryType
            arParams(17) = parameterQueryType

            Dim parameterProjectSchedule_JobNumber As New SqlParameter("@PSWL_JOB_NUMBER", SqlDbType.Int)
            If ProjectSchedule_JobNumber = 0 Then
                parameterProjectSchedule_JobNumber.Value = System.DBNull.Value
            Else
                parameterProjectSchedule_JobNumber.Value = ProjectSchedule_JobNumber
            End If
            arParams(18) = parameterProjectSchedule_JobNumber

            Dim parameterProjectSchedule_JobComponentNbr As New SqlParameter("@PSWL_JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            If ProjectSchedule_JobNumber = 0 Then
                parameterProjectSchedule_JobComponentNbr.Value = System.DBNull.Value
            Else
                parameterProjectSchedule_JobComponentNbr.Value = ProjectSchedule_JobComponentNbr
            End If
            arParams(19) = parameterProjectSchedule_JobComponentNbr

            Dim parameterProjectSchedule_JobCompWhereClause As New SqlParameter("@JC_LIST", SqlDbType.VarChar, 8000)
            parameterProjectSchedule_JobCompWhereClause.Value = ProjectSchedule_JobCompWhereClause
            arParams(20) = parameterProjectSchedule_JobCompWhereClause

            Dim parameterOverrideEmployeeSecurity As New SqlParameter("@OVERRIDE_EMP_SEC", SqlDbType.SmallInt)
            If OverrideEmployeeSecurity = True Then
                parameterOverrideEmployeeSecurity.Value = 1
            Else
                parameterOverrideEmployeeSecurity.Value = 0
            End If
            arParams(21) = parameterOverrideEmployeeSecurity

            DsAvailability = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_RESOURCES_EMP_ALLOCATION", arParams)

            '''just return a quick for now:
            ''Return DsAvailability.Tables(1)
            If Summary_Level = SummaryLevel.None Then
                Return DsAvailability.Tables(0)
            End If

            DtHeaderData = DsAvailability.Tables(0)
            DtEmployees = DsAvailability.Tables(6)
            DtColumns = DsAvailability.Tables(2)
            DtGridData = DsAvailability.Tables(7)

            'This comes frm table 0 in Emp Availability Query
            If DtHeaderData.Rows.Count > 0 Then
                NumDays = DtHeaderData.Rows(0)("NUM_DAYS")
                NumWeeks = DtHeaderData.Rows(0)("NUM_WEEKS")
                NumMonths = DtHeaderData.Rows(0)("NUM_MONTHS")
                NumYears = DtHeaderData.Rows(0)("NUM_YEARS")
                NumEmps = DtHeaderData.Rows(0)("NUM_EMPS")
                CalculatedStart = Convert.ToDateTime(DtHeaderData.Rows(0)("CALCULATED_START_DATE"))
                CalculatedEnd = Convert.ToDateTime(DtHeaderData.Rows(0)("CALCULATED_END_DATE"))
            End If


            'Create the non-dynamic columns:           
            Dim COL_DEPT_TEAM As DataColumn = New DataColumn("DEPT_TEAM")
            With COL_DEPT_TEAM
                .DataType = GetType(String)
                .ColumnName = "Code"
            End With

            Dim COL_DEPT_DESC As DataColumn = New DataColumn("DEPT_DESC")
            With COL_DEPT_DESC
                .DataType = GetType(String)
                .ColumnName = "Department"
            End With

            With DtReturn.Columns
                .Add(COL_DEPT_TEAM)
                .Add(COL_DEPT_DESC)
            End With


            Select Case Summary_Level
                Case SummaryLevel.Day
                    'NumDynamicColumns = NumDays
                    NumDynamicColumns = TotalNumDays
                Case SummaryLevel.Week
                    'NumDynamicColumns = NumWeeks
                Case SummaryLevel.Month
                    'NumDynamicColumns = NumMonths
                Case SummaryLevel.Year
                    'NumDynamicColumns = NumYears
            End Select



            'Add one row for each Employee (Table 1 from Emp Availability query)
            If DtEmployees.Rows.Count > 0 Then
                For j As Integer = 0 To DtEmployees.Rows.Count - 1
                    Dim r As DataRow
                    r = DtReturn.NewRow()
                    r("Code") = DtEmployees.Rows(j)("DP_TM_CODE")
                    r("Department") = DtEmployees.Rows(j)("DP_TM_DESC")
                    DtReturn.Rows.Add(r)
                Next
            End If

            'build the dynamic columns, take 2:
            Dim Roof As Integer = 1
            'Create the dynamic columns and add it to the rows:
            'column count from table 2 from Emp Avail query
            Try
                Dim ThisDate As DateTime = Start_Date
                Dim ctr As Integer = 0
                Dim DynaCol4 As New DataColumn 'hold the column total...
                For z As Integer = 0 To DtColumns.Rows.Count - Roof
                    If ctr <= NumDays Then
                        Dim ColumnsAdded As Boolean = False
                        Dim DynaCol As New DataColumn 'hold the task hours used, this will get displayed
                        Dim DynaCol2 As New DataColumn 'hold the available hours for the math...
                        Dim DynaCol3 As New DataColumn 'hold the direct hours goal hours
                        Dim DynaCol5 As New DataColumn 'hold the overbooked
                        Dim DynaCol6 As New DataColumn 'hold the overbooked
                        DynaCol.DataType = GetType(Decimal)
                        DynaCol2.DataType = GetType(Decimal)
                        DynaCol3.DataType = GetType(Decimal)
                        DynaCol5.DataType = GetType(Integer)
                        DynaCol6.DataType = GetType(Decimal)
                        Select Case Summary_Level
                            Case SummaryLevel.Day
                                ThisDate = Me.GetTheDate(Start_Date, DtColumns.Rows(z)("CTR"), SummaryLevel.Day)
                                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                    DynaCol.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString()
                                    DynaCol2.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_HRS_AVAIL"
                                    'DynaCol3.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    'DynaCol5.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_PERC_WORKED"
                                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    'DynaCol3.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    'DynaCol5.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_PERC_WORKED"
                                Else
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    'DynaCol3.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    'DynaCol5.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_PERC_WORKED"
                                End If
                            Case SummaryLevel.Week
                                ThisDate = DtColumns.Rows(z)("WEEK_OF_YEAR") 'Me.GetTheDate(Start_Date, DtColumns.Rows(z)("CTR"), SummaryLevel.Week)
                                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                    DynaCol.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString()
                                    DynaCol2.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_HRS_AVAIL"
                                    'DynaCol3.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    'DynaCol5.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_PERC_WORKED"
                                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    'DynaCol3.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    'DynaCol5.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_PERC_WORKED"
                                Else
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    'DynaCol3.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    'DynaCol5.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_PERC_WORKED"
                                End If
                            Case SummaryLevel.Month
                                ThisDate = Me.GetTheDate(Start_Date, DtColumns.Rows(z)("CTR"), SummaryLevel.Month)
                                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                    DynaCol.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString()
                                    DynaCol2.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_HRS_AVAIL"
                                    'DynaCol3.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    'DynaCol5.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_PERC_WORKED"
                                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    'DynaCol3.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    'DynaCol5.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_PERC_WORKED"
                                Else
                                    DynaCol.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString()
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    'DynaCol3.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    'DynaCol5.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    DynaCol6.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_PERC_WORKED"
                                End If
                            Case SummaryLevel.Year
                                ThisDate = Me.GetTheDate(Start_Date, DtColumns.Rows(z)("CTR"), SummaryLevel.Year)
                                DynaCol.ColumnName = ThisDate.Year.ToString()
                                DynaCol2.ColumnName = ThisDate.Year.ToString() & "_HRS_AVAIL"
                                'DynaCol3.ColumnName = ThisDate.Year.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                'DynaCol5.ColumnName = ThisDate.Year.ToString() & "_OVER_BOOKED"
                                DynaCol6.ColumnName = ThisDate.Year.ToString() & "_PERC_WORKED"
                        End Select
                        If Summary_Level = SummaryLevel.Day Then
                            If IncludeWeekends = True Then
                                DtReturn.Columns.Add(DynaCol)
                                DtReturn.Columns.Add(DynaCol2)
                                'DtReturn.Columns.Add(DynaCol3)
                                'DtReturn.Columns.Add(DynaCol5)
                                DtReturn.Columns.Add(DynaCol6)
                                ColumnsAdded = True
                            ElseIf IncludeWeekends = False And (ThisDate.DayOfWeek <> DayOfWeek.Saturday And ThisDate.DayOfWeek <> DayOfWeek.Sunday) Then
                                DtReturn.Columns.Add(DynaCol)
                                DtReturn.Columns.Add(DynaCol2)
                                'DtReturn.Columns.Add(DynaCol3)
                                'DtReturn.Columns.Add(DynaCol5)
                                DtReturn.Columns.Add(DynaCol6)
                                ColumnsAdded = True
                            End If
                        Else
                            'If ThisDate <= End_Date Then
                            DtReturn.Columns.Add(DynaCol)
                            DtReturn.Columns.Add(DynaCol2)
                            'DtReturn.Columns.Add(DynaCol3)
                            'DtReturn.Columns.Add(DynaCol5)
                            DtReturn.Columns.Add(DynaCol6)
                            ColumnsAdded = True
                            'End If
                        End If
                        If ColumnsAdded = True Then
                            ctr += 1
                        End If
                    End If
                Next
                'after all the dyna columns added, add that total column
                DynaCol4.ColumnName = "Total"
                DynaCol4.DataType = GetType(Decimal)

                'DtReturn.Columns.Add(DynaCol4)
            Catch ex As Exception

            End Try


            'update the dynamic columns...
            'for each employee
            'this should be filtering table 3 of emp avail query to populate

            For k As Integer = 0 To DtEmployees.Rows.Count - 1
                Dim CurrDeptCode As String = DtEmployees.Rows(k)("DP_TM_CODE")
                Dim CurrColumnName As String = "" 'HOURS USED
                Dim CurrColumnName2 As String = "" 'HOURS AVAIL
                Dim CurrColumnName3 As String = "" 'HOURS GOAL
                Dim CurrColumnName4 As String = "" 'OVER BOOKED
                Dim CurrColumnName5 As String = "" 'OVER BOOKED
                Dim CurrDate As DateTime
                Dim CurrDayOfYear As Integer
                Dim TheEmpRow() As Data.DataRow = DtReturn.Select("Code = '" & CurrDeptCode & "'")

                Dim TheDataRow() As Data.DataRow = Nothing 'DtGridData.Select("EMP_CODE = '" & CurrEmpCode & "'")
                Try
                    'go through the dynamic columns
                    Dim RunningColumnTotal As Decimal = 0.0
                    For m As Integer = 0 To DtColumns.Rows.Count - Roof
                        Dim DtTemp As New DataTable
                        DtTemp = DtGridData.Copy()
                        Select Case Summary_Level
                            Case SummaryLevel.Day
                                Try
                                    CurrDate = Me.GetTheDate(Start_Date, DtColumns.Rows(m)("CTR"), SummaryLevel.Day)
                                    TheDataRow = DtTemp.Select("DP_TM_CODE = '" & CurrDeptCode & "' AND DAY_OF_YEAR = " & DtColumns.Rows(m)("CTR"))
                                    If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                        CurrColumnName = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString()
                                        CurrColumnName2 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_HRS_AVAIL"
                                        'CurrColumnName3 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        'CurrColumnName4 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_PERC_WORKED"
                                    ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                        CurrColumnName = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        'CurrColumnName3 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        'CurrColumnName4 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_PERC_WORKED"
                                    Else
                                        CurrColumnName = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        'CurrColumnName3 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        'CurrColumnName4 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_PERC_WORKED"
                                    End If
                                    'TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    TheEmpRow(0)(CurrColumnName2) = CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                    'TheEmpRow(0)(CurrColumnName3) = CType(TheDataRow(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                                    'TheEmpRow(0)(CurrColumnName4) = CType(TheDataRow(0)("OVER_BOOKED"), Integer)
                                    TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("PERC_WORKED"), Decimal)
                                    Try
                                        RunningColumnTotal = RunningColumnTotal + CType(TheDataRow(0)("PERC_WORKED"), Decimal)
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception
                                End Try
                            Case SummaryLevel.Week
                                Try
                                    CurrDate = DtColumns.Rows(m)("WEEK_OF_YEAR") 'Me.GetTheDate(Start_Date, DtColumns.Rows(m)("CTR"), SummaryLevel.Week)
                                    TheDataRow = DtTemp.Select("DP_TM_CODE = '" & CurrDeptCode & "' AND WEEK_OF_YEAR = '" & DtColumns.Rows(m)("WEEK_OF_YEAR") & "'")
                                    If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                        CurrColumnName = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString()
                                        CurrColumnName2 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_HRS_AVAIL"
                                        'CurrColumnName3 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        'CurrColumnName4 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_PERC_WORKED"
                                    ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                        CurrColumnName = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        'CurrColumnName3 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        ' CurrColumnName4 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_PERC_WORKED"
                                    Else
                                        CurrColumnName = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        'CurrColumnName3 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        'CurrColumnName4 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_PERC_WORKED"
                                    End If
                                    'TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    TheEmpRow(0)(CurrColumnName2) = CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                    'TheEmpRow(0)(CurrColumnName3) = CType(TheDataRow(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                                    'TheEmpRow(0)(CurrColumnName4) = CType(TheDataRow(0)("OVER_BOOKED"), Integer)
                                    TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("PERC_WORKED"), Decimal)
                                    Try
                                        RunningColumnTotal = RunningColumnTotal + CType(TheDataRow(0)("PERC_WORKED"), Decimal)
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception
                                End Try
                            Case SummaryLevel.Month
                                Try
                                    CurrDate = Me.GetTheDate(Start_Date, DtColumns.Rows(m)("CTR"), SummaryLevel.Month)
                                    TheDataRow = DtTemp.Select("DP_TM_CODE = '" & CurrDeptCode & "' AND MONTH_OF_YEAR = " & DtColumns.Rows(m)("CTR"))
                                    If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                        CurrColumnName = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString()
                                        CurrColumnName2 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_HRS_AVAIL"
                                        'CurrColumnName3 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        'CurrColumnName4 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_PERC_WORKED"
                                    ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                        CurrColumnName = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        'CurrColumnName3 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        'CurrColumnName4 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_PERC_WORKED"
                                    Else
                                        CurrColumnName = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString()
                                        CurrColumnName2 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        'CurrColumnName3 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        ' CurrColumnName4 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        CurrColumnName5 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_PERC_WORKED"
                                    End If
                                    'TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    TheEmpRow(0)(CurrColumnName2) = CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                    'TheEmpRow(0)(CurrColumnName3) = CType(TheDataRow(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                                    'TheEmpRow(0)(CurrColumnName4) = CType(TheDataRow(0)("OVER_BOOKED"), Integer)
                                    TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("PERC_WORKED"), Decimal)
                                    Try
                                        RunningColumnTotal = RunningColumnTotal + CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception
                                End Try
                            Case SummaryLevel.Year
                                Try
                                    CurrDate = Me.GetTheDate(Start_Date, DtColumns.Rows(m)("CTR"), SummaryLevel.Year)
                                    TheDataRow = DtTemp.Select("DP_TM_CODE = '" & CurrDeptCode & "' AND [YEAR] = " & DtColumns.Rows(m)("CTR"))
                                    CurrColumnName = CurrDate.Year.ToString()
                                    CurrColumnName2 = CurrDate.Year.ToString() & "_HRS_AVAIL"
                                    'CurrColumnName3 = CurrDate.Year.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    'CurrColumnName4 = CurrDate.Year.ToString() & "_OVER_BOOKED"
                                    CurrColumnName5 = CurrDate.Year.ToString() & "_PERC_WORKED"
                                    'TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    TheEmpRow(0)(CurrColumnName2) = CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                    'TheEmpRow(0)(CurrColumnName3) = CType(TheDataRow(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                                    'TheEmpRow(0)(CurrColumnName4) = CType(TheDataRow(0)("OVER_BOOKED"), Decimal)
                                    TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("PERC_WORKED"), Decimal)
                                    Try
                                        RunningColumnTotal = RunningColumnTotal + CType(TheDataRow(0)("PERC_WORKED"), Decimal)
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception
                                End Try
                        End Select
                        DtTemp.Dispose()
                    Next
                    'try adding a totals column...
                    'TheEmpRow(0)("Total") = RunningColumnTotal
                Catch ex As Exception
                End Try
            Next




            Return DtReturn




        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetActualizationDatatable(ByVal Emp_Code As String, ByVal Start_Date As DateTime, ByVal End_Date As DateTime, ByVal Summary_Level As SummaryLevel, ByVal Roles As String, ByVal Depts As String, Optional ByVal IncludeWeekends As Boolean = False, Optional ByVal EmpList As String = "",
                                           Optional ByVal Office As String = "",
                                        Optional ByVal Client As String = "",
                                        Optional ByVal Division As String = "",
                                        Optional ByVal Product As String = "",
                                        Optional ByVal Job As String = "",
                                        Optional ByVal JobComp As String = "",
                                        Optional ByVal TaskStatus As String = "",
                                        Optional ByVal ExcludeTempComplete As Boolean = False,
                                        Optional ByVal Manager As String = "",
                                        Optional ByVal QueryType As String = "",
                                        Optional ByVal ProjectSchedule_JobNumber As Integer = 0,
                                        Optional ByVal ProjectSchedule_JobComponentNbr As Integer = 0,
                                        Optional ByVal ProjectSchedule_JobCompWhereClause As String = "",
                                        Optional ByVal OverrideEmployeeSecurity As Boolean = False,
                                        Optional ByVal OmitBeginningBalance As Boolean = False,
                                        Optional ByVal ShowPercent As Boolean = False) As DataTable
        Try
            Dim Fixed_End_Date As DateTime = Convert.ToDateTime(End_Date.ToShortDateString() & " 11:59:00 PM")
            Dim This_Summary_Level As Integer = CType(Summary_Level, Integer)

            Dim NumDays As Integer = 0
            Dim NumWeeks As Integer = 0
            Dim NumMonths As Integer = 0
            Dim NumYears As Integer = 0
            Dim NumEmps As Integer = 0
            Dim CalculatedStart As DateTime
            Dim CalculatedEnd As DateTime

            Dim TotalNumDays As Integer = CType(DateDiff(DateInterval.Day, Start_Date, End_Date), Integer)
            Dim Fixed_TotalNumDays As Integer = CType(DateDiff(DateInterval.Day, Start_Date, Fixed_End_Date), Integer)

            Dim NumDynamicColumns As Integer = 0


            Dim DsAvailability As New DataSet
            Dim DtHeaderData As New DataTable
            Dim DtGridData As New DataTable
            Dim DtColumns As New DataTable
            Dim DtEmployees As New DataTable

            Dim DtReturn As New DataTable

            Dim arParams(23) As SqlParameter

            Dim pEMP_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            pEMP_CODE.Value = Emp_Code
            arParams(0) = pEMP_CODE

            Dim pROLES As New SqlParameter("@ROLES", SqlDbType.VarChar, 4000)
            If Roles.Trim() = "" Then
                pROLES.Value = System.DBNull.Value
            Else
                pROLES.Value = Roles
            End If
            arParams(1) = pROLES

            Dim pSTART_DATE As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            pSTART_DATE.Value = Start_Date
            arParams(2) = pSTART_DATE

            Dim pEND_DATE As New SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            pEND_DATE.Value = Fixed_End_Date
            arParams(3) = pEND_DATE

            Dim pSUMMARY_LEVEL As New SqlParameter("@SUMMARY_LEVEL", SqlDbType.SmallInt)
            pSUMMARY_LEVEL.Value = This_Summary_Level
            arParams(4) = pSUMMARY_LEVEL

            Dim pDEPTS As New SqlParameter("@DEPTS", SqlDbType.VarChar, 4000)
            If Depts.Trim() = "" Then
                pDEPTS.Value = System.DBNull.Value
            Else
                pDEPTS.Value = Depts
            End If
            arParams(5) = pDEPTS


            Dim pEmpList As New SqlParameter("@EMP_LIST", SqlDbType.VarChar, 4000)
            If EmpList.Trim() = "" Then
                pEmpList.Value = System.DBNull.Value
            Else
                pEmpList.Value = EmpList
            End If
            arParams(6) = pEmpList

            Dim pUSERID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            pUSERID.Value = HttpContext.Current.Session("UserCode")
            arParams(7) = pUSERID

            Dim parameterOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
            parameterOffice.Value = Office
            arParams(8) = parameterOffice

            Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            parameterClient.Value = Client
            arParams(9) = parameterClient

            Dim parameterDivision As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
            parameterDivision.Value = Division
            arParams(10) = parameterDivision

            Dim parameterProduct As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
            parameterProduct.Value = Product
            arParams(11) = parameterProduct

            Dim parameterJob As New SqlParameter("@JobNum", SqlDbType.VarChar, 6)
            parameterJob.Value = Job
            arParams(12) = parameterJob

            Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.VarChar, 6)
            parameterJobComp.Value = JobComp
            arParams(13) = parameterJobComp

            Dim parameterTaskStatus As New SqlParameter("@TaskStatus", SqlDbType.VarChar, 1)
            parameterTaskStatus.Value = TaskStatus
            arParams(14) = parameterTaskStatus

            Dim parameterExcludeTempComplete As New SqlParameter("@ExcludeTempComplete", SqlDbType.Char, 1)
            If ExcludeTempComplete = True Then
                parameterExcludeTempComplete.Value = "Y"
            Else
                parameterExcludeTempComplete.Value = "N"
            End If
            arParams(15) = parameterExcludeTempComplete

            Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar, 6)
            parameterManager.Value = Manager
            arParams(16) = parameterManager

            Dim parameterQueryType As New SqlParameter("@QUERY_TYPE", SqlDbType.VarChar, 10)
            parameterQueryType.Value = QueryType
            arParams(17) = parameterQueryType

            Dim parameterProjectSchedule_JobNumber As New SqlParameter("@PSWL_JOB_NUMBER", SqlDbType.Int)
            If ProjectSchedule_JobNumber = 0 Then
                parameterProjectSchedule_JobNumber.Value = System.DBNull.Value
            Else
                parameterProjectSchedule_JobNumber.Value = ProjectSchedule_JobNumber
            End If
            arParams(18) = parameterProjectSchedule_JobNumber

            Dim parameterProjectSchedule_JobComponentNbr As New SqlParameter("@PSWL_JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            If ProjectSchedule_JobNumber = 0 Then
                parameterProjectSchedule_JobComponentNbr.Value = System.DBNull.Value
            Else
                parameterProjectSchedule_JobComponentNbr.Value = ProjectSchedule_JobComponentNbr
            End If
            arParams(19) = parameterProjectSchedule_JobComponentNbr

            Dim parameterProjectSchedule_JobCompWhereClause As New SqlParameter("@JC_LIST", SqlDbType.VarChar, 8000)
            parameterProjectSchedule_JobCompWhereClause.Value = ProjectSchedule_JobCompWhereClause
            arParams(20) = parameterProjectSchedule_JobCompWhereClause

            Dim parameterOverrideEmployeeSecurity As New SqlParameter("@OVERRIDE_EMP_SEC", SqlDbType.SmallInt)
            If OverrideEmployeeSecurity = True Then
                parameterOverrideEmployeeSecurity.Value = 1
            Else
                parameterOverrideEmployeeSecurity.Value = 0
            End If
            arParams(21) = parameterOverrideEmployeeSecurity

            Dim parameterOmitBeginningBalance As New SqlParameter("@OMIT_BEGINNING_BALANCE", SqlDbType.SmallInt)
            If OmitBeginningBalance = True Then
                parameterOmitBeginningBalance.Value = 1
            Else
                parameterOmitBeginningBalance.Value = 0
            End If
            arParams(22) = parameterOmitBeginningBalance

            DsAvailability = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_RESOURCES_EMP_ACTUALIZATION", arParams)

            '''just return a quick for now:
            ''Return DsAvailability.Tables(1)
            If Summary_Level = SummaryLevel.None Then
                Return DsAvailability.Tables(0)
            End If

            DtHeaderData = DsAvailability.Tables(0)
            DtEmployees = DsAvailability.Tables(1)
            DtColumns = DsAvailability.Tables(2)
            DtGridData = DsAvailability.Tables(3)

            'This comes frm table 0 in Emp Availability Query
            If DtHeaderData.Rows.Count > 0 Then
                NumDays = DtHeaderData.Rows(0)("NUM_DAYS")
                NumWeeks = DtHeaderData.Rows(0)("NUM_WEEKS")
                NumMonths = DtHeaderData.Rows(0)("NUM_MONTHS")
                NumYears = DtHeaderData.Rows(0)("NUM_YEARS")
                NumEmps = DtHeaderData.Rows(0)("NUM_EMPS")
                CalculatedStart = Convert.ToDateTime(DtHeaderData.Rows(0)("CALCULATED_START_DATE"))
                CalculatedEnd = Convert.ToDateTime(DtHeaderData.Rows(0)("CALCULATED_END_DATE"))
            End If


            'Create the non-dynamic columns:
            Dim COL_EMP_CODE As DataColumn = New DataColumn("EMP_CODE")
            With COL_EMP_CODE
                .DataType = GetType(String)
                .ColumnName = "EMP_CODE"
            End With

            Dim COL_EMP_FML_NAME As DataColumn = New DataColumn("EMP_FML_NAME")
            With COL_EMP_FML_NAME
                .DataType = GetType(String)
                .ColumnName = "Employee"
            End With

            Dim COL_OFFICE_CODE As DataColumn = New DataColumn("OFFICE_CODE")
            With COL_OFFICE_CODE
                .DataType = GetType(String)
                .ColumnName = "Office"
            End With

            Dim COL_DEPT_TEAM As DataColumn = New DataColumn("DEPT_TEAM")
            With COL_DEPT_TEAM
                .DataType = GetType(String)
                .ColumnName = "Department"
            End With

            Dim COL_DEF_TRF_ROLE As DataColumn = New DataColumn("DEF_TRF_ROLE")
            With COL_DEF_TRF_ROLE
                .DataType = GetType(String)
                .ColumnName = "Role"
            End With

            Dim COL_EMP_DIRECT_HRS_GOAL_PERC As DataColumn = New DataColumn("EMP_DIRECT_HRS_GOAL_PERC")
            With COL_EMP_DIRECT_HRS_GOAL_PERC
                .DataType = GetType(Decimal)
                .ColumnName = "Direct Hours Goal %"
            End With

            'Dim COL_STD_HRS_AVAIL As DataColumn = New DataColumn("STD_HRS_AVAIL")
            'With COL_STD_HRS_AVAIL
            '    .DataType = GetType(Decimal)
            '    .ColumnName = "Std. Hours Available"
            'End With

            Dim COL_EMP_DIRECT_HRS_GOAL_HOURS As DataColumn = New DataColumn("EMP_DIRECT_HRS_GOAL_HOURS")
            With COL_EMP_DIRECT_HRS_GOAL_HOURS
                .DataType = GetType(Decimal)
                .ColumnName = "Direct Hours Goal"
            End With

            'Dim COL_HRS_USED_NON_TASK As DataColumn = New DataColumn("HRS_USED_NON_TASK")
            'With COL_HRS_USED_NON_TASK
            '    .DataType = GetType(Decimal)
            '    .ColumnName = ""
            'End With

            Dim COL_HRS_AVAIL As DataColumn = New DataColumn("HRS_AVAIL")
            With COL_HRS_AVAIL
                .DataType = GetType(Decimal)
                .ColumnName = "Hours Available (Adj)"
            End With

            Dim COL_HRS_POSTED As DataColumn = New DataColumn("HRS_POSTED")
            With COL_HRS_POSTED
                .DataType = GetType(Decimal)
                .ColumnName = "Hours Posted"
            End With

            Dim COL_HRS_LEFT As DataColumn = New DataColumn("HRS_LEFT")
            With COL_HRS_LEFT
                .DataType = GetType(Decimal)
                .ColumnName = "Hours Left"
            End With

            Dim COL_BEGINNING_BALANCE As DataColumn = New DataColumn("BEGINNING_BALANCE")
            With COL_BEGINNING_BALANCE
                .DataType = GetType(Decimal)
                .ColumnName = "Beginning Balance"
            End With

            'Dim COL_HRS_NO_DATE As DataColumn = New DataColumn("HRS_NO_DATE")
            'With COL_HRS_NO_DATE
            '    .DataType = GetType(Decimal)
            '    .ColumnName = "Hours (No Date)"
            'End With

            'Dim COL_ As DataColumn = New DataColumn("")
            'COL_.DataType = GetType(String)

            With DtReturn.Columns
                .Add(COL_EMP_CODE)
                .Add(COL_OFFICE_CODE)
                .Add(COL_EMP_FML_NAME)
                .Add(COL_DEPT_TEAM)
                .Add(COL_DEF_TRF_ROLE)
                .Add(COL_HRS_AVAIL)
                .Add(COL_EMP_DIRECT_HRS_GOAL_PERC)
                '.Add(COL_STD_HRS_AVAIL)
                .Add(COL_EMP_DIRECT_HRS_GOAL_HOURS)
                .Add(COL_BEGINNING_BALANCE)
                .Add(COL_HRS_POSTED)
                .Add(COL_HRS_LEFT)
                '.Add(COL_HRS_NO_DATE)
            End With


            Select Case Summary_Level
                Case SummaryLevel.Day
                    'NumDynamicColumns = NumDays
                    NumDynamicColumns = TotalNumDays
                Case SummaryLevel.Week
                    'NumDynamicColumns = NumWeeks
                Case SummaryLevel.Month
                    'NumDynamicColumns = NumMonths
                Case SummaryLevel.Year
                    'NumDynamicColumns = NumYears
            End Select



            'Add one row for each Employee (Table 1 from Emp Availability query)
            If DtEmployees.Rows.Count > 0 Then
                For j As Integer = 0 To DtEmployees.Rows.Count - 1
                    Dim r As DataRow
                    r = DtReturn.NewRow()
                    r("EMP_CODE") = DtEmployees.Rows(j)("EMP_CODE")
                    r("Employee") = DtEmployees.Rows(j)("EMP_FML_NAME")
                    r("Office") = DtEmployees.Rows(j)("OFFICE_CODE")
                    r("Department") = DtEmployees.Rows(j)("DP_TM_CODE")
                    r("Direct Hours Goal %") = DtEmployees.Rows(j)("EMP_DIRECT_HRS_GOAL_PERC")
                    r("Direct Hours Goal") = DtEmployees.Rows(j)("EMP_DIRECT_HRS_GOAL_HOURS")
                    r("Hours Available (Adj)") = DtEmployees.Rows(j)("HRS_AVAIL")
                    r("Role") = DtEmployees.Rows(j)("DEF_TRF_ROLE")
                    r("Hours Posted") = DtEmployees.Rows(j)("HRS_POSTED")
                    r("Hours Left") = DtEmployees.Rows(j)("HRS_LEFT")
                    r("Beginning Balance") = DtEmployees.Rows(j)("BEGINNING_BALANCE")
                    'r("Hours (No Date)") = DtEmployees.Rows(j)("HRS_NO_DATE")
                    DtReturn.Rows.Add(r)
                Next
            End If

            'build the dynamic columns, take 2:
            Dim Roof As Integer = 1
            'If Summary_Level = SummaryLevel.Day Then
            '    'If Depts.Trim() = "" Then
            '    '    Roof = 1
            '    'ElseIf Depts.Trim() <> "" And (Emp_Code = "%" Or Emp_Code = "") Then
            '    '    Roof = 2
            '    'End If
            '    If (Emp_Code = "%" Or Emp_Code = "") And Depts.Trim() = "" Then
            '        Roof = 2
            '    End If
            'End If

            'Create the dynamic columns and add it to the rows:
            'column count from table 2 from Emp Avail query
            Try
                Dim ThisDate As DateTime = Start_Date
                Dim ctr As Integer = 0
                Dim DynaCol4 As New DataColumn 'hold the column total...
                For z As Integer = 0 To DtColumns.Rows.Count - Roof
                    If ctr <= NumDays Then
                        Dim ColumnsAdded As Boolean = False
                        Dim DynaCol As New DataColumn 'hold the task hours used, this will get displayed
                        Dim DynaCol2 As New DataColumn 'hold the available hours for the math...
                        Dim DynaCol3 As New DataColumn 'hold the direct hours goal hours
                        Dim DynaCol5 As New DataColumn 'hold the overbooked
                        Dim DynaCol6 As New DataColumn 'hold the percent Util
                        DynaCol.DataType = GetType(Decimal)
                        DynaCol2.DataType = GetType(Decimal)
                        DynaCol3.DataType = GetType(Decimal)
                        DynaCol5.DataType = GetType(Integer)
                        DynaCol6.DataType = GetType(Decimal)
                        Select Case Summary_Level
                            Case SummaryLevel.Day
                                ThisDate = Me.GetTheDate(Start_Date, DtColumns.Rows(z)("CTR"), SummaryLevel.Day)
                                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                    If ShowPercent = True Then
                                        DynaCol.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & " %"
                                    Else
                                        DynaCol.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString()
                                    End If
                                    DynaCol2.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_OVER_BOOKED"
                                    'DynaCol6.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_PERCENT_UTIL"
                                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                    If ShowPercent = True Then
                                        DynaCol.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & " %"
                                    Else
                                        DynaCol.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString()
                                    End If
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    'DynaCol6.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_PERCENT_UTIL"
                                Else
                                    If ShowPercent = True Then
                                        DynaCol.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & " %"
                                    Else
                                        DynaCol.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString()
                                    End If
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    'DynaCol6.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_PERCENT_UTIL"
                                End If
                            Case SummaryLevel.Week
                                ThisDate = DtColumns.Rows(z)("WEEK_OF_YEAR") 'Me.GetTheDate(Start_Date, DtColumns.Rows(z)("CTR"), SummaryLevel.Week)
                                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                    If ShowPercent = True Then
                                        DynaCol.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & " %"
                                    Else
                                        DynaCol.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString()
                                    End If
                                    DynaCol2.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_OVER_BOOKED"
                                    'DynaCol6.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_PERCENT_UTIL"
                                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                    If ShowPercent = True Then
                                        DynaCol.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & " %"
                                    Else
                                        DynaCol.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString()
                                    End If
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    'DynaCol6.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_PERCENT_UTIL"
                                Else
                                    If ShowPercent = True Then
                                        DynaCol.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & " %"
                                    Else
                                        DynaCol.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString()
                                    End If
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    'DynaCol6.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_PERCENT_UTIL"
                                End If
                            Case SummaryLevel.Month
                                ThisDate = Me.GetTheDate(Start_Date, DtColumns.Rows(z)("CTR"), SummaryLevel.Month)
                                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                    If ShowPercent = True Then
                                        DynaCol.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & " %"
                                    Else
                                        DynaCol.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString()
                                    End If
                                    DynaCol2.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_OVER_BOOKED"
                                    'DynaCol6.ColumnName = ThisDate.Month.ToString() & "/" & ThisDate.Day.ToString() & "_PERCENT_UTIL"
                                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                    If ShowPercent = True Then
                                        DynaCol.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & " %"
                                    Else
                                        DynaCol.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString()
                                    End If
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    'DynaCol6.ColumnName = ThisDate.Day.ToString() & "/" & ThisDate.Month.ToString() & "_PERCENT_UTIL"
                                Else
                                    If ShowPercent = True Then
                                        DynaCol.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & " %"
                                    Else
                                        DynaCol.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString()
                                    End If
                                    DynaCol2.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_HRS_AVAIL"
                                    DynaCol3.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    DynaCol5.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_OVER_BOOKED"
                                    'DynaCol6.ColumnName = ThisDate.Day.ToString() & "." & ThisDate.Month.ToString() & "_PERCENT_UTIL"
                                End If
                            Case SummaryLevel.Year
                                ThisDate = Me.GetTheDate(Start_Date, DtColumns.Rows(z)("CTR"), SummaryLevel.Year)
                                If ShowPercent = True Then
                                    DynaCol.ColumnName = ThisDate.Year.ToString() & " %"
                                Else
                                    DynaCol.ColumnName = ThisDate.Year.ToString()
                                End If
                                DynaCol2.ColumnName = ThisDate.Year.ToString() & "_HRS_AVAIL"
                                DynaCol3.ColumnName = ThisDate.Year.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                DynaCol5.ColumnName = ThisDate.Year.ToString() & "_OVER_BOOKED"
                                'DynaCol6.ColumnName = ThisDate.Year.ToString() & "_PERCENT_UTIL"
                        End Select
                        If Summary_Level = SummaryLevel.Day Then
                            If IncludeWeekends = True Then
                                DtReturn.Columns.Add(DynaCol)
                                DtReturn.Columns.Add(DynaCol2)
                                DtReturn.Columns.Add(DynaCol3)
                                DtReturn.Columns.Add(DynaCol5)
                                'DtReturn.Columns.Add(DynaCol6)
                                ColumnsAdded = True
                            ElseIf IncludeWeekends = False And (ThisDate.DayOfWeek <> DayOfWeek.Saturday And ThisDate.DayOfWeek <> DayOfWeek.Sunday) Then
                                DtReturn.Columns.Add(DynaCol)
                                DtReturn.Columns.Add(DynaCol2)
                                DtReturn.Columns.Add(DynaCol3)
                                DtReturn.Columns.Add(DynaCol5)
                                'DtReturn.Columns.Add(DynaCol6)
                                ColumnsAdded = True
                            End If
                        Else
                            'If ThisDate <= End_Date Then
                            DtReturn.Columns.Add(DynaCol)
                            DtReturn.Columns.Add(DynaCol2)
                            DtReturn.Columns.Add(DynaCol3)
                            DtReturn.Columns.Add(DynaCol5)
                            'DtReturn.Columns.Add(DynaCol6)
                            ColumnsAdded = True
                            'End If
                        End If
                        If ColumnsAdded = True Then
                            ctr += 1
                        End If
                    End If
                Next
                'after all the dyna columns added, add that total column
                If ShowPercent = True Then
                    DynaCol4.ColumnName = "Total %"
                Else
                    DynaCol4.ColumnName = "Total"
                End If
                DynaCol4.DataType = GetType(Decimal)

                DtReturn.Columns.Add(DynaCol4)
            Catch ex As Exception

            End Try


            'update the dynamic columns...
            'for each employee
            'this should be filtering table 3 of emp avail query to populate

            For k As Integer = 0 To DtEmployees.Rows.Count - 1
                Dim CurrEmpCode As String = DtEmployees.Rows(k)("EMP_CODE")
                Dim CurrColumnName As String = "" 'HOURS USED
                Dim CurrColumnName2 As String = "" 'HOURS AVAIL
                Dim CurrColumnName3 As String = "" 'HOURS GOAL
                Dim CurrColumnName4 As String = "" 'OVER BOOKED
                Dim CurrColumnName5 As String = "" 'PERCENT UTIL
                Dim CurrDate As DateTime
                Dim CurrDayOfYear As Integer
                Dim TheEmpRow() As Data.DataRow = DtReturn.Select("EMP_CODE = '" & CurrEmpCode & "'")

                Dim TheDataRow() As Data.DataRow = Nothing 'DtGridData.Select("EMP_CODE = '" & CurrEmpCode & "'")
                Try
                    'go through the dynamic columns
                    Dim RunningColumnTotal As Decimal = 0.0
                    Dim RunningColumnTotalPercent As Decimal = 0.0
                    Dim RunningColumnHoursAvailable As Decimal = 0.0
                    For m As Integer = 0 To DtColumns.Rows.Count - Roof
                        Dim DtTemp As New DataTable
                        DtTemp = DtGridData.Copy()
                        Select Case Summary_Level
                            Case SummaryLevel.Day
                                Try
                                    CurrDate = Me.GetTheDate(Start_Date, DtColumns.Rows(m)("CTR"), SummaryLevel.Day)
                                    TheDataRow = DtTemp.Select("EMP_CODE = '" & CurrEmpCode & "' AND DAY_OF_YEAR = " & DtColumns.Rows(m)("CTR"))
                                    If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                        If ShowPercent = True Then
                                            CurrColumnName = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & " %"
                                        Else
                                            CurrColumnName = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString()
                                        End If
                                        CurrColumnName2 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_OVER_BOOKED"
                                        'CurrColumnName5 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_PERCENT_UTIL"
                                    ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                        If ShowPercent = True Then
                                            CurrColumnName = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & " %"
                                        Else
                                            CurrColumnName = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString()
                                        End If
                                        CurrColumnName2 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        'CurrColumnName5 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_PERCENT_UTIL"
                                    Else
                                        If ShowPercent = True Then
                                            CurrColumnName = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & " %"
                                        Else
                                            CurrColumnName = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString()
                                        End If
                                        CurrColumnName2 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        'CurrColumnName5 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_PERCENT_UTIL"
                                    End If
                                    If ShowPercent = True Then
                                        TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("PERCENT_UTIL"), Decimal)
                                    Else
                                        TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    End If
                                    TheEmpRow(0)(CurrColumnName2) = CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                    TheEmpRow(0)(CurrColumnName3) = CType(TheDataRow(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                                    TheEmpRow(0)(CurrColumnName4) = CType(TheDataRow(0)("OVER_BOOKED"), Integer)
                                    'TheEmpRow(0)(CurrColumnName5) = CType(TheDataRow(0)("PERCENT_UTIL"), Decimal)
                                    Try
                                        If ShowPercent = True Then
                                            RunningColumnTotalPercent = RunningColumnTotalPercent + CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                            RunningColumnHoursAvailable = RunningColumnHoursAvailable + CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                        Else
                                            RunningColumnTotal = RunningColumnTotal + CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                        End If
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception
                                End Try
                            Case SummaryLevel.Week
                                Try
                                    CurrDate = DtColumns.Rows(m)("WEEK_OF_YEAR") 'Me.GetTheDate(Start_Date, DtColumns.Rows(m)("CTR"), SummaryLevel.Week)
                                    TheDataRow = DtTemp.Select("EMP_CODE = '" & CurrEmpCode & "' AND WEEK_OF_YEAR = '" & DtColumns.Rows(m)("WEEK_OF_YEAR") & "'")
                                    If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                        If ShowPercent = True Then
                                            CurrColumnName = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & " %"
                                        Else
                                            CurrColumnName = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString()
                                        End If
                                        CurrColumnName2 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_OVER_BOOKED"
                                        'CurrColumnName5 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_PERCENT_UTIL"
                                    ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                        If ShowPercent = True Then
                                            CurrColumnName = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & " %"
                                        Else
                                            CurrColumnName = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString()
                                        End If
                                        CurrColumnName2 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        'CurrColumnName5 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_PERCENT_UTIL"
                                    Else
                                        If ShowPercent = True Then
                                            CurrColumnName = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & " %"
                                        Else
                                            CurrColumnName = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString()
                                        End If
                                        CurrColumnName2 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        'CurrColumnName5 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_PERCENT_UTIL"
                                    End If
                                    If ShowPercent = True Then
                                        TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("PERCENT_UTIL"), Decimal)
                                    Else
                                        TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    End If
                                    'TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    TheEmpRow(0)(CurrColumnName2) = CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                    TheEmpRow(0)(CurrColumnName3) = CType(TheDataRow(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                                    TheEmpRow(0)(CurrColumnName4) = CType(TheDataRow(0)("OVER_BOOKED"), Integer)
                                    'TheEmpRow(0)(CurrColumnName5) = CType(TheDataRow(0)("PERCENT_UTIL"), Decimal)
                                    Try
                                        If ShowPercent = True Then
                                            RunningColumnTotalPercent = RunningColumnTotalPercent + CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                            RunningColumnHoursAvailable = RunningColumnHoursAvailable + CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                        Else
                                            RunningColumnTotal = RunningColumnTotal + CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                        End If
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception
                                End Try
                            Case SummaryLevel.Month
                                Try
                                    CurrDate = Me.GetTheDate(Start_Date, DtColumns.Rows(m)("CTR"), SummaryLevel.Month)
                                    TheDataRow = DtTemp.Select("EMP_CODE = '" & CurrEmpCode & "' AND MONTH_OF_YEAR = " & DtColumns.Rows(m)("CTR"))
                                    If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                        If ShowPercent = True Then
                                            CurrColumnName = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & " %"
                                        Else
                                            CurrColumnName = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString()
                                        End If

                                        CurrColumnName2 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_OVER_BOOKED"
                                        'CurrColumnName5 = CurrDate.Month.ToString() & "/" & CurrDate.Day.ToString() & "_PERCENT_UTIL"
                                    ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                        If ShowPercent = True Then
                                            CurrColumnName = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & " %"
                                        Else
                                            CurrColumnName = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString()
                                        End If

                                        CurrColumnName2 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        'CurrColumnName5 = CurrDate.Day.ToString() & "/" & CurrDate.Month.ToString() & "_PERCENT_UTIL"
                                    Else
                                        If ShowPercent = True Then
                                            CurrColumnName = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & " %"
                                        Else
                                            CurrColumnName = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString()
                                        End If

                                        CurrColumnName2 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_HRS_AVAIL"
                                        CurrColumnName3 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                        CurrColumnName4 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_OVER_BOOKED"
                                        'CurrColumnName5 = CurrDate.Day.ToString() & "." & CurrDate.Month.ToString() & "_PERCENT_UTIL"
                                    End If
                                    If ShowPercent = True Then
                                        TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("PERCENT_UTIL"), Integer)
                                    Else
                                        TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    End If
                                    'TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    TheEmpRow(0)(CurrColumnName2) = CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                    TheEmpRow(0)(CurrColumnName3) = CType(TheDataRow(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                                    TheEmpRow(0)(CurrColumnName4) = CType(TheDataRow(0)("OVER_BOOKED"), Integer)
                                    'TheEmpRow(0)(CurrColumnName5) = CType(TheDataRow(0)("PERCENT_UTIL"), Integer)
                                    Try
                                        If ShowPercent = True Then
                                            RunningColumnTotalPercent = RunningColumnTotalPercent + CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                            RunningColumnHoursAvailable = RunningColumnHoursAvailable + CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                        Else
                                            RunningColumnTotal = RunningColumnTotal + CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                        End If
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception
                                End Try
                            Case SummaryLevel.Year
                                Try
                                    CurrDate = Me.GetTheDate(Start_Date, DtColumns.Rows(m)("CTR"), SummaryLevel.Year)
                                    TheDataRow = DtTemp.Select("EMP_CODE = '" & CurrEmpCode & "' AND [YEAR] = " & DtColumns.Rows(m)("CTR"))
                                    If ShowPercent = True Then
                                        CurrColumnName = CurrDate.Year.ToString() & " %"
                                    Else
                                        CurrColumnName = CurrDate.Year.ToString()
                                    End If

                                    CurrColumnName2 = CurrDate.Year.ToString() & "_HRS_AVAIL"
                                    CurrColumnName3 = CurrDate.Year.ToString() & "_EMP_DIRECT_HRS_GOAL_HRS"
                                    CurrColumnName4 = CurrDate.Year.ToString() & "_OVER_BOOKED"
                                    'CurrColumnName5 = CurrDate.Year.ToString() & "_PERCENT_UTIL"
                                    If ShowPercent = True Then
                                        TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("PERCENT_UTIL"), Decimal)
                                    Else
                                        TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    End If
                                    'TheEmpRow(0)(CurrColumnName) = CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                    TheEmpRow(0)(CurrColumnName2) = CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                    TheEmpRow(0)(CurrColumnName3) = CType(TheDataRow(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                                    TheEmpRow(0)(CurrColumnName4) = CType(TheDataRow(0)("OVER_BOOKED"), Decimal)
                                    'TheEmpRow(0)(CurrColumnName5) = CType(TheDataRow(0)("PERCENT_UTIL"), Decimal)
                                    Try
                                        If ShowPercent = True Then
                                            RunningColumnTotalPercent = RunningColumnTotalPercent + CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                            RunningColumnHoursAvailable = RunningColumnHoursAvailable + CType(TheDataRow(0)("HRS_AVAIL"), Decimal)
                                        Else
                                            RunningColumnTotal = RunningColumnTotal + CType(TheDataRow(0)("HRS_ASSIGNED_TASK"), Decimal)
                                        End If
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception
                                End Try
                        End Select
                        DtTemp.Dispose()
                    Next
                    'try adding a totals column...
                    If ShowPercent = True Then
                        TheEmpRow(0)("Total %") = (RunningColumnTotalPercent / RunningColumnHoursAvailable) * 100
                    Else
                        TheEmpRow(0)("Total") = RunningColumnTotal
                    End If
                Catch ex As Exception
                End Try
            Next




            Return DtReturn




        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function GetRoleList(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, ByVal TaskType As Integer) As DataTable
        Try
            Dim arParams(3) As SqlParameter

            Dim pJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            pJOB_NUMBER.Value = JobNumber
            arParams(0) = pJOB_NUMBER

            Dim pJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            pJOB_COMPONENT_NBR.Value = JobComponentNbr
            arParams(1) = pJOB_COMPONENT_NBR

            Dim pTASK_TYPE As New SqlParameter("@TASK_TYPE", SqlDbType.SmallInt)
            pTASK_TYPE.Value = TaskType
            arParams(2) = pTASK_TYPE

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_RESOURCES_JOB_COMPONENT_GET_ROLES", "DtRoles", arParams)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Overloads Function FindAvailableEmployees(ByVal TaskType As Integer, ByVal TrfRoleCode As String, _
                                                     ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, _
                                                     ByVal StartDate As Date, ByVal EndDate As Date, ByVal SaveFoundEmployees As Boolean) As DataSet
        Try
            Dim arParams(8) As SqlParameter

            Dim pJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            pJOB_NUMBER.Value = JobNumber
            arParams(0) = pJOB_NUMBER

            Dim pJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            pJOB_COMPONENT_NBR.Value = JobComponentNbr
            arParams(1) = pJOB_COMPONENT_NBR

            Dim pTASK_TYPE As New SqlParameter("@TASK_TYPE", SqlDbType.SmallInt)
            pTASK_TYPE.Value = TaskType
            arParams(2) = pTASK_TYPE

            Dim pTRF_ROLE_CODE As New SqlParameter("@TRF_ROLE_CODE", SqlDbType.VarChar, 10)
            pTRF_ROLE_CODE.Value = TrfRoleCode
            arParams(3) = pTRF_ROLE_CODE

            Dim pSTART_DATE As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            If StartDate = Nothing Then
                pSTART_DATE.Value = System.DBNull.Value
            Else
                pSTART_DATE.Value = StartDate
            End If
            arParams(4) = pSTART_DATE

            Dim pEND_DATE As New SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            If EndDate = Nothing Then
                pEND_DATE.Value = System.DBNull.Value
            Else
                pEND_DATE.Value = EndDate
            End If
            arParams(5) = pEND_DATE

            Dim pSAVE_FOUND_EMPLOYEES As New SqlParameter("@SAVE_FOUND_EMPLOYEES", SqlDbType.TinyInt)
            pSAVE_FOUND_EMPLOYEES.Value = MiscFN.BoolToInt(SaveFoundEmployees)
            arParams(6) = pSAVE_FOUND_EMPLOYEES

            Dim paramTask_UserCode As New SqlParameter("@UserCode", SqlDbType.VarChar)
            paramTask_UserCode.Value = HttpContext.Current.Session("UserCode")
            arParams(7) = paramTask_UserCode

            Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_RESOURCES_EMP_FINDER", arParams)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Overloads Function FindAvailableEmployees(ByVal TrfFncCode As String, ByVal StartTime As DateTime, ByVal EndTime As DateTime, ByVal From_Form As Integer) As DataTable
        Try
            Dim arParams(4) As SqlParameter

            Dim pTRF_FNC_CODE As New SqlParameter("@TRF_FNC_CODE", SqlDbType.VarChar, 10)
            pTRF_FNC_CODE.Value = TrfFncCode
            arParams(0) = pTRF_FNC_CODE

            Dim pSTART_TIME As New SqlParameter("@START_TIME", SqlDbType.SmallDateTime)
            pSTART_TIME.Value = StartTime
            arParams(1) = pSTART_TIME

            Dim pEND_TIME As New SqlParameter("@END_TIME", SqlDbType.SmallDateTime)
            pEND_TIME.Value = EndTime
            arParams(2) = pEND_TIME

            Dim paramTask_UserCode As New SqlParameter("@UserCode", SqlDbType.VarChar)
            paramTask_UserCode.Value = HttpContext.Current.Session("UserCode")
            arParams(3) = paramTask_UserCode

            Dim ds As New DataSet
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_RESOURCES_EMP_AVAILABILITY_TASK_ROLE", arParams)

            If From_Form = 0 Then 'event task
                Return ds.Tables(1)
            ElseIf From_Form = 1 Then 'project schedule
                Return ds.Tables(1) '?
            End If

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetAvailabilityDataSet(ByVal Emp_Code As String, ByVal Start_Date As DateTime, ByVal End_Date As DateTime, ByVal Summary_Level As SummaryLevel, ByVal Roles As String, ByVal Depts As String, Optional ByVal IncludeWeekends As Boolean = False, Optional ByVal EmpList As String = "",
                                           Optional ByVal Office As String = "",
                                        Optional ByVal Client As String = "",
                                        Optional ByVal Division As String = "",
                                        Optional ByVal Product As String = "",
                                        Optional ByVal Job As String = "",
                                        Optional ByVal JobComp As String = "",
                                        Optional ByVal TaskStatus As String = "",
                                        Optional ByVal ExcludeTempComplete As Boolean = False,
                                        Optional ByVal Manager As String = "",
                                        Optional ByVal QueryType As String = "",
                                        Optional ByVal ProjectSchedule_JobNumber As Integer = 0,
                                        Optional ByVal ProjectSchedule_JobComponentNbr As Integer = 0,
                                        Optional ByVal ProjectSchedule_JobCompWhereClause As String = "",
                                        Optional ByVal OverrideEmployeeSecurity As Boolean = False) As DataSet
        Try
            Dim Fixed_End_Date As DateTime = Convert.ToDateTime(End_Date.ToShortDateString() & " 11:59:00 PM")
            Dim This_Summary_Level As Integer = CType(Summary_Level, Integer)

            Dim NumDays As Integer = 0
            Dim NumWeeks As Integer = 0
            Dim NumMonths As Integer = 0
            Dim NumYears As Integer = 0
            Dim NumEmps As Integer = 0
            Dim CalculatedStart As DateTime
            Dim CalculatedEnd As DateTime

            Dim TotalNumDays As Integer = CType(DateDiff(DateInterval.Day, Start_Date, End_Date), Integer)
            Dim Fixed_TotalNumDays As Integer = CType(DateDiff(DateInterval.Day, Start_Date, Fixed_End_Date), Integer)

            Dim NumDynamicColumns As Integer = 0


            Dim DsAvailability As New DataSet
            Dim DtHeaderData As New DataTable
            Dim DtGridData As New DataTable
            Dim DtColumns As New DataTable
            Dim DtEmployees As New DataTable

            Dim DtReturn As New DataTable

            Dim arParams(22) As SqlParameter

            Dim pEMP_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            pEMP_CODE.Value = Emp_Code
            arParams(0) = pEMP_CODE

            Dim pROLES As New SqlParameter("@ROLES", SqlDbType.VarChar, 4000)
            If Roles.Trim() = "" Then
                pROLES.Value = System.DBNull.Value
            Else
                pROLES.Value = Roles
            End If
            arParams(1) = pROLES

            Dim pSTART_DATE As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            pSTART_DATE.Value = Start_Date
            arParams(2) = pSTART_DATE

            Dim pEND_DATE As New SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            pEND_DATE.Value = Fixed_End_Date
            arParams(3) = pEND_DATE

            Dim pSUMMARY_LEVEL As New SqlParameter("@SUMMARY_LEVEL", SqlDbType.SmallInt)
            pSUMMARY_LEVEL.Value = This_Summary_Level
            arParams(4) = pSUMMARY_LEVEL

            Dim pDEPTS As New SqlParameter("@DEPTS", SqlDbType.VarChar, 4000)
            If Depts.Trim() = "" Then
                pDEPTS.Value = System.DBNull.Value
            Else
                pDEPTS.Value = Depts
            End If
            arParams(5) = pDEPTS


            Dim pEmpList As New SqlParameter("@EMP_LIST", SqlDbType.VarChar, 4000)
            If EmpList.Trim() = "" Then
                pEmpList.Value = System.DBNull.Value
            Else
                pEmpList.Value = EmpList
            End If
            arParams(6) = pEmpList

            Dim pUSERID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            pUSERID.Value = HttpContext.Current.Session("UserCode")
            arParams(7) = pUSERID

            Dim parameterOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
            parameterOffice.Value = Office
            arParams(8) = parameterOffice

            Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            parameterClient.Value = Client
            arParams(9) = parameterClient

            Dim parameterDivision As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
            parameterDivision.Value = Division
            arParams(10) = parameterDivision

            Dim parameterProduct As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
            parameterProduct.Value = Product
            arParams(11) = parameterProduct

            Dim parameterJob As New SqlParameter("@JobNum", SqlDbType.VarChar, 6)
            parameterJob.Value = Job
            arParams(12) = parameterJob

            Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.VarChar, 6)
            parameterJobComp.Value = JobComp
            arParams(13) = parameterJobComp

            Dim parameterTaskStatus As New SqlParameter("@TaskStatus", SqlDbType.VarChar, 1)
            parameterTaskStatus.Value = TaskStatus
            arParams(14) = parameterTaskStatus

            Dim parameterExcludeTempComplete As New SqlParameter("@ExcludeTempComplete", SqlDbType.Char, 1)
            If ExcludeTempComplete = True Then
                parameterExcludeTempComplete.Value = "Y"
            Else
                parameterExcludeTempComplete.Value = "N"
            End If
            arParams(15) = parameterExcludeTempComplete

            Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar, 6)
            parameterManager.Value = Manager
            arParams(16) = parameterManager

            Dim parameterQueryType As New SqlParameter("@QUERY_TYPE", SqlDbType.VarChar, 10)
            parameterQueryType.Value = QueryType
            arParams(17) = parameterQueryType

            Dim parameterProjectSchedule_JobNumber As New SqlParameter("@PSWL_JOB_NUMBER", SqlDbType.Int)
            If ProjectSchedule_JobNumber = 0 Then
                parameterProjectSchedule_JobNumber.Value = System.DBNull.Value
            Else
                parameterProjectSchedule_JobNumber.Value = ProjectSchedule_JobNumber
            End If
            arParams(18) = parameterProjectSchedule_JobNumber

            Dim parameterProjectSchedule_JobComponentNbr As New SqlParameter("@PSWL_JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            If ProjectSchedule_JobNumber = 0 Then
                parameterProjectSchedule_JobComponentNbr.Value = System.DBNull.Value
            Else
                parameterProjectSchedule_JobComponentNbr.Value = ProjectSchedule_JobComponentNbr
            End If
            arParams(19) = parameterProjectSchedule_JobComponentNbr

            Dim parameterProjectSchedule_JobCompWhereClause As New SqlParameter("@JC_LIST", SqlDbType.VarChar, 8000)
            parameterProjectSchedule_JobCompWhereClause.Value = ProjectSchedule_JobCompWhereClause
            arParams(20) = parameterProjectSchedule_JobCompWhereClause

            Dim parameterOverrideEmployeeSecurity As New SqlParameter("@OVERRIDE_EMP_SEC", SqlDbType.SmallInt)
            If OverrideEmployeeSecurity = True Then
                parameterOverrideEmployeeSecurity.Value = 1
            Else
                parameterOverrideEmployeeSecurity.Value = 0
            End If
            arParams(21) = parameterOverrideEmployeeSecurity

            DsAvailability = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_RESOURCES_EMP_AVAILABILITY", arParams)

            Return DsAvailability


        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function GetActualizationDataSet(ByVal Emp_Code As String, ByVal Start_Date As DateTime, ByVal End_Date As DateTime, ByVal Summary_Level As SummaryLevel, ByVal Roles As String, ByVal Depts As String, Optional ByVal IncludeWeekends As Boolean = False, Optional ByVal EmpList As String = "",
                                           Optional ByVal Office As String = "",
                                        Optional ByVal Client As String = "",
                                        Optional ByVal Division As String = "",
                                        Optional ByVal Product As String = "",
                                        Optional ByVal Job As String = "",
                                        Optional ByVal JobComp As String = "",
                                        Optional ByVal TaskStatus As String = "",
                                        Optional ByVal ExcludeTempComplete As Boolean = False,
                                        Optional ByVal Manager As String = "",
                                        Optional ByVal QueryType As String = "",
                                        Optional ByVal ProjectSchedule_JobNumber As Integer = 0,
                                        Optional ByVal ProjectSchedule_JobComponentNbr As Integer = 0,
                                        Optional ByVal ProjectSchedule_JobCompWhereClause As String = "",
                                        Optional ByVal OverrideEmployeeSecurity As Boolean = False,
                                        Optional ByVal OmitBeginningBalance As Boolean = False) As DataSet
        Try
            Dim Fixed_End_Date As DateTime = Convert.ToDateTime(End_Date.ToShortDateString() & " 11:59:00 PM")
            Dim This_Summary_Level As Integer = CType(Summary_Level, Integer)

            Dim NumDays As Integer = 0
            Dim NumWeeks As Integer = 0
            Dim NumMonths As Integer = 0
            Dim NumYears As Integer = 0
            Dim NumEmps As Integer = 0
            Dim CalculatedStart As DateTime
            Dim CalculatedEnd As DateTime

            Dim TotalNumDays As Integer = CType(DateDiff(DateInterval.Day, Start_Date, End_Date), Integer)
            Dim Fixed_TotalNumDays As Integer = CType(DateDiff(DateInterval.Day, Start_Date, Fixed_End_Date), Integer)

            Dim NumDynamicColumns As Integer = 0


            Dim DsAvailability As New DataSet
            Dim DtHeaderData As New DataTable
            Dim DtGridData As New DataTable
            Dim DtColumns As New DataTable
            Dim DtEmployees As New DataTable

            Dim DtReturn As New DataTable

            Dim arParams(23) As SqlParameter

            Dim pEMP_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            pEMP_CODE.Value = Emp_Code
            arParams(0) = pEMP_CODE

            Dim pROLES As New SqlParameter("@ROLES", SqlDbType.VarChar, 4000)
            If Roles.Trim() = "" Then
                pROLES.Value = System.DBNull.Value
            Else
                pROLES.Value = Roles
            End If
            arParams(1) = pROLES

            Dim pSTART_DATE As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            pSTART_DATE.Value = Start_Date
            arParams(2) = pSTART_DATE

            Dim pEND_DATE As New SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            pEND_DATE.Value = Fixed_End_Date
            arParams(3) = pEND_DATE

            Dim pSUMMARY_LEVEL As New SqlParameter("@SUMMARY_LEVEL", SqlDbType.SmallInt)
            pSUMMARY_LEVEL.Value = This_Summary_Level
            arParams(4) = pSUMMARY_LEVEL

            Dim pDEPTS As New SqlParameter("@DEPTS", SqlDbType.VarChar, 4000)
            If Depts.Trim() = "" Then
                pDEPTS.Value = System.DBNull.Value
            Else
                pDEPTS.Value = Depts
            End If
            arParams(5) = pDEPTS


            Dim pEmpList As New SqlParameter("@EMP_LIST", SqlDbType.VarChar, 4000)
            If EmpList.Trim() = "" Then
                pEmpList.Value = System.DBNull.Value
            Else
                pEmpList.Value = EmpList
            End If
            arParams(6) = pEmpList

            Dim pUSERID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            pUSERID.Value = HttpContext.Current.Session("UserCode")
            arParams(7) = pUSERID

            Dim parameterOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
            parameterOffice.Value = Office
            arParams(8) = parameterOffice

            Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            parameterClient.Value = Client
            arParams(9) = parameterClient

            Dim parameterDivision As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
            parameterDivision.Value = Division
            arParams(10) = parameterDivision

            Dim parameterProduct As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
            parameterProduct.Value = Product
            arParams(11) = parameterProduct

            Dim parameterJob As New SqlParameter("@JobNum", SqlDbType.VarChar, 6)
            parameterJob.Value = Job
            arParams(12) = parameterJob

            Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.VarChar, 6)
            parameterJobComp.Value = JobComp
            arParams(13) = parameterJobComp

            Dim parameterTaskStatus As New SqlParameter("@TaskStatus", SqlDbType.VarChar, 1)
            parameterTaskStatus.Value = TaskStatus
            arParams(14) = parameterTaskStatus

            Dim parameterExcludeTempComplete As New SqlParameter("@ExcludeTempComplete", SqlDbType.Char, 1)
            If ExcludeTempComplete = True Then
                parameterExcludeTempComplete.Value = "Y"
            Else
                parameterExcludeTempComplete.Value = "N"
            End If
            arParams(15) = parameterExcludeTempComplete

            Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar, 6)
            parameterManager.Value = Manager
            arParams(16) = parameterManager

            Dim parameterQueryType As New SqlParameter("@QUERY_TYPE", SqlDbType.VarChar, 10)
            parameterQueryType.Value = QueryType
            arParams(17) = parameterQueryType

            Dim parameterProjectSchedule_JobNumber As New SqlParameter("@PSWL_JOB_NUMBER", SqlDbType.Int)
            If ProjectSchedule_JobNumber = 0 Then
                parameterProjectSchedule_JobNumber.Value = System.DBNull.Value
            Else
                parameterProjectSchedule_JobNumber.Value = ProjectSchedule_JobNumber
            End If
            arParams(18) = parameterProjectSchedule_JobNumber

            Dim parameterProjectSchedule_JobComponentNbr As New SqlParameter("@PSWL_JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            If ProjectSchedule_JobNumber = 0 Then
                parameterProjectSchedule_JobComponentNbr.Value = System.DBNull.Value
            Else
                parameterProjectSchedule_JobComponentNbr.Value = ProjectSchedule_JobComponentNbr
            End If
            arParams(19) = parameterProjectSchedule_JobComponentNbr

            Dim parameterProjectSchedule_JobCompWhereClause As New SqlParameter("@JC_LIST", SqlDbType.VarChar, 8000)
            parameterProjectSchedule_JobCompWhereClause.Value = ProjectSchedule_JobCompWhereClause
            arParams(20) = parameterProjectSchedule_JobCompWhereClause

            Dim parameterOverrideEmployeeSecurity As New SqlParameter("@OVERRIDE_EMP_SEC", SqlDbType.SmallInt)
            If OverrideEmployeeSecurity = True Then
                parameterOverrideEmployeeSecurity.Value = 1
            Else
                parameterOverrideEmployeeSecurity.Value = 0
            End If
            arParams(21) = parameterOverrideEmployeeSecurity

            Dim parameterOmitBeginningBalance As New SqlParameter("@OMIT_BEGINNING_BALANCE", SqlDbType.SmallInt)
            If OmitBeginningBalance = True Then
                parameterOmitBeginningBalance.Value = 1
            Else
                parameterOmitBeginningBalance.Value = 0
            End If
            arParams(22) = parameterOmitBeginningBalance

            DsAvailability = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_RESOURCES_EMP_ACTUALIZATION", arParams)

            Return DsAvailability


        Catch ex As Exception
            Return Nothing
        End Try
    End Function
#End Region

    Private Function GetTheDate(ByVal StartDate As DateTime, ByVal Counter As Integer, ByVal Offset As SummaryLevel) As Date
        'Get first of year based on start date
        Dim FirstOfYear As DateTime = Convert.ToDateTime("01/01/" & StartDate.Year.ToString() & " 12:00:00 AM")
        Dim FirstSundayDate As DateTime = Nothing
        Dim ci As System.Globalization.CultureInfo = System.Globalization.CultureInfo.GetCultureInfo("en-US")
        Select Case Offset
            Case SummaryLevel.None, SummaryLevel.Day 'returns date when pass in day of year
                Return DateAdd(DateInterval.Day, Counter - 1, FirstOfYear)
            Case SummaryLevel.Week 'returns date of the sunday of the passed in week number
                Dim FirstSunday As System.DayOfWeek
                FirstSunday = FirstOfYear.DayOfWeek
                If FirstSunday = DayOfWeek.Sunday Then
                    FirstSundayDate = FirstOfYear
                    If LoGlo.UserCultureGet <> "en-US" Then
                        Return DateAdd(DateInterval.WeekOfYear, Counter - 1, CDate(String.Format(ci, "{0:d}", FirstSundayDate)))
                    Else
                        Return DateAdd(DateInterval.WeekOfYear, Counter - 1, FirstSundayDate)
                    End If
                Else
                    FirstSundayDate = Convert.ToDateTime("1/" & (2 + (7 - Weekday(FirstOfYear))) & "/" & FirstOfYear.Year & " 12:00:00 AM")
                    If LoGlo.UserCultureGet <> "en-US" Then
                        Return DateAdd(DateInterval.WeekOfYear, Counter - 2, CDate(String.Format(ci, "{0:d}", FirstSundayDate)))
                    Else
                        Return DateAdd(DateInterval.WeekOfYear, Counter - 2, FirstSundayDate)
                    End If
                End If
            Case SummaryLevel.Month 'returns the first of the month
                If Counter <= 12 Then
                    'Return Convert.ToDateTime(Counter & "/01/" & StartDate.Year.ToString() & " 12:00:00 AM")
                    Return LoGlo.FirstOfMonth(StartDate.Year, Counter)
                Else
                    Return FirstOfYear
                End If
            Case SummaryLevel.Year 'returns the first of the year
                If Counter.ToString().Length = 4 Then
                    Return Convert.ToDateTime("01/01/" & Counter & " 12:00:00 AM")
                Else
                    Return FirstOfYear
                End If
        End Select
    End Function

    Public Sub New(Optional ByVal UserID As String = "", Optional ByVal EmpCode As String = "")
        mConnString = HttpContext.Current.Session("ConnString")
        Try
            If UserID <> "" Then
                mUserID = UserID
            Else
                mUserID = HttpContext.Current.Session("UserCode")
            End If
        Catch ex As Exception
            mUserID = ""
        End Try
        Try
            If EmpCode <> "" Then
                mEmpCode = EmpCode
            Else
                mEmpCode = HttpContext.Current.Session("EmpCode")
            End If
        Catch ex As Exception
            mEmpCode = ""
        End Try
    End Sub

End Class
