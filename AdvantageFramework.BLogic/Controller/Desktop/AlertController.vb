Imports System.Drawing
Imports System.Drawing.Image
Imports System.IO

Namespace Controller.Desktop
    Public Class AlertController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "

        Private Const _AppVarApplication As String = "ALERT_VIEW"

#End Region

#Region " Enum "

        Public Enum AppVars
            CloseAfterCommentOrReAssign
            WidgetLayout
            ShowHideSystemComments
            DetailsExpanded
            ShowChecklistsOnCards
            UploadDocumentManager
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Proofing/Imaging "

        Public Function GetCurrentAlertStateID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                               ByVal AlertID As Integer) As Integer

            Dim DbAlertStateID As Integer = 0

            Try

                DbAlertStateID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ISNULL(ALERT_STATE_ID, 0) FROM ALERT WITH(NOLOCK) WHERE ALERT_ID = {0};", AlertID)).SingleOrDefault

            Catch ex As Exception
                DbAlertStateID = 0
            End Try

            Return DbAlertStateID

        End Function
        Public Function GetLatestDocumentID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal AlertID As Integer,
                                            ByRef ErrorMessage As String) As Integer

            Dim DocumentID As Integer = 0

            Try

                DocumentID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT MAX(DOCUMENT_ID) FROM ALERT_ATTACHMENT AA WITH(NOLOCK) WHERE AA.ALERT_ID = {0};", AlertID)).SingleOrDefault

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                DocumentID = -1
            End Try

            Return DocumentID

        End Function

        Public Function GetThumbnailBytes(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal FullImageBytes As Byte(),
                                          ByRef ErrorMessage As String) As Byte()

            Dim TargetMax As Integer = 100
            Dim FullImage As Image = Nothing
            Dim ThumbnailImage As Image = Nothing
            Dim ThumbnailBytes As Byte() = Nothing

            Dim FullImageHeight As Integer = 0
            Dim FullImageWidth As Integer = 0
            Dim ThumbnailImageHeight As Integer = 0
            Dim ThumbnailImageWidth As Integer = 0
            Dim ScaleFactor As Decimal = 0

            If FullImageBytes IsNot Nothing Then

                FullImage = ByteArrayToImage(FullImageBytes, ErrorMessage)

                If FullImage IsNot Nothing Then

                    FullImageHeight = FullImage.Height
                    FullImageWidth = FullImage.Width

                    If FullImageHeight > TargetMax OrElse FullImageWidth > TargetMax Then

                        If FullImageHeight > FullImageWidth Then

                            ScaleFactor = FullImageHeight / TargetMax

                        Else

                            ScaleFactor = FullImageWidth / TargetMax

                        End If

                        ThumbnailImageHeight = CType(FullImageHeight * ScaleFactor, Integer)
                        ThumbnailImageWidth = CType(FullImageWidth * ScaleFactor, Integer)

                    End If

                    Try

                        ThumbnailImage = FullImage.GetThumbnailImage(ThumbnailImageWidth, ThumbnailImageHeight, Nothing, New IntPtr())

                    Catch ex As Exception
                        ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                        ThumbnailBytes = Nothing
                    End Try

                    GetThumbnailBytes = ImageToByteArray(ThumbnailImage, ErrorMessage)

                End If

            End If

            Return ThumbnailBytes

        End Function

#Region " Private "

        Public Function ImageToByteArray(ByVal TheImage As Image,
                                         ByRef ErrorMessage As String) As Byte()

            Try

                Using MemoryStream As New MemoryStream()

                    TheImage.Save(MemoryStream, TheImage.RawFormat)
                    Return MemoryStream.ToArray()

                End Using

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                Return Nothing
            End Try

        End Function
        Public Function ByteArrayToImage(ByVal ByteArrayIn As Byte(),
                                         ByRef ErrorMessage As String) As Image


            Try

                Using MemoryStream As New MemoryStream(ByteArrayIn)

                    Return Image.FromStream(MemoryStream)

                End Using

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                Return Nothing
            End Try

        End Function
        Public Shared Function ImgToByteConverter(ByVal TheImage As Image,
                                                  ByRef ErrorMessage As String) As Byte()

            Try

                Dim ImageConverter As New ImageConverter()
                Return DirectCast(ImageConverter.ConvertTo(TheImage, GetType(Byte())), Byte())

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                Return Nothing
            End Try

        End Function

#End Region

#End Region

#Region " Inbox/Dashboard "

        Public Function LoadAlerts(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                   ByVal EmployeeCode As String,
                                   ByVal InboxType As String,
                                   ByVal FilterLevel As String,
                                   ByVal OfficeCode As String,
                                   ByVal ClCode As String,
                                   ByVal DivCode As String,
                                   ByVal PrdCode As String,
                                   ByVal CmpIdentifier As String,
                                   ByVal CmpCode As String,
                                   ByVal JobNumber As Integer,
                                   ByVal JobComponentNbr As Integer,
                                   ByVal AlertTypeId As String,
                                   ByVal AlertCategoryId As String,
                                   ByVal StartDate As String,
                                   ByVal EndDate As String,
                                   ByVal AlertLevel As String,
                                   ByVal VnCode As String,
                                   ByVal EstimateNumber As Integer,
                                   ByVal EstComponentNbr As Integer,
                                   ByVal TaskCode As String,
                                   ByVal TaskDescription As String,
                                   ByVal ATBNumber As Integer,
                                   ByVal ShowAssignmentType As String,
                                   ByVal AlrtNotifyHdrId As Integer,
                                   ByVal AlertNotifyName As String,
                                   ByVal IncludeCompletedAssignments As Boolean,
                                   ByVal IsJobAlertsPage As Boolean,
                                   ByVal AlertAssignmentSeqNbr As Integer,
                                   ByVal GroupBy As String,
                                   ByVal SearchCriteria As String,
                                   ByVal AccountExecutiveCode As String,
                                   ByVal ManagerCode As String,
                                   ByVal StateId As Integer,
                                   ByVal RecordsToReturn As Integer,
                                   ByVal IsCount As Boolean,
                                   ByRef RecordCount As Integer,
                                   ByVal IncludeReviews As Boolean,
                                   ByVal IncludeBoardLevel As Boolean,
                                   ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert)

            Dim Alerts As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert) = Nothing
            Dim DataTable As System.Data.DataTable = Nothing

            Try

                DataTable = AdvantageFramework.AlertSystem.LoadAlertsAsDataTable(DbContext,
                                                                                 EmployeeCode,
                                                                                  EmployeeCode,
                                                                                  InboxType,
                                                                                  FilterLevel,
                                                                                  OfficeCode,
                                                                                  ClCode,
                                                                                  DivCode,
                                                                                  PrdCode,
                                                                                  CmpIdentifier,
                                                                                  CmpCode,
                                                                                  JobNumber,
                                                                                  JobComponentNbr,
                                                                                  AlertTypeId,
                                                                                  AlertCategoryId,
                                                                                  StartDate,
                                                                                  EndDate,
                                                                                  AlertLevel,
                                                                                  VnCode,
                                                                                  EstimateNumber,
                                                                                  EstComponentNbr,
                                                                                  TaskCode,
                                                                                  TaskDescription,
                                                                                  ATBNumber,
                                                                                  ShowAssignmentType,
                                                                                  AlrtNotifyHdrId,
                                                                                  AlertNotifyName,
                                                                                  IncludeCompletedAssignments,
                                                                                  IsJobAlertsPage,
                                                                                  AlertAssignmentSeqNbr,
                                                                                  GroupBy,
                                                                                  SearchCriteria,
                                                                                  AccountExecutiveCode,
                                                                                  ManagerCode,
                                                                                  StateId,
                                                                                  RecordsToReturn,
                                                                                  IsCount,
                                                                                  RecordCount,
                                                                                  IncludeReviews,
                                                                                  IncludeBoardLevel,
                                                                                  ErrorMessage)

                If DataTable IsNot Nothing AndAlso DataTable.Rows.Count > 0 Then

                    Alerts = DataTable.Rows.OfType(Of DataRow).ToList.Select(Function(dr) AdvantageFramework.DTO.Desktop.Alert.FromMainAlertQuery(dr, GroupBy)).ToList

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                Alerts = Nothing
            End Try

            Return Alerts

        End Function
        Public Function LoadAlertsCP(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                   ByVal CPID As Integer,
                                   ByVal InboxType As String,
                                   ByVal FilterLevel As String,
                                   ByVal OfficeCode As String,
                                   ByVal ClCode As String,
                                   ByVal DivCode As String,
                                   ByVal PrdCode As String,
                                   ByVal CmpIdentifier As String,
                                   ByVal CmpCode As String,
                                   ByVal JobNumber As Integer,
                                   ByVal JobComponentNbr As Integer,
                                   ByVal AlertTypeId As String,
                                   ByVal AlertCategoryId As String,
                                   ByVal StartDate As String,
                                   ByVal EndDate As String,
                                   ByVal AlertLevel As String,
                                   ByVal VnCode As String,
                                   ByVal EstimateNumber As Integer,
                                   ByVal EstComponentNbr As Integer,
                                   ByVal TaskCode As String,
                                   ByVal TaskDescription As String,
                                   ByVal ATBNumber As Integer,
                                   ByVal ShowAssignmentType As String,
                                   ByVal AlrtNotifyHdrId As Integer,
                                   ByVal AlertNotifyName As String,
                                   ByVal IncludeCompletedAssignments As Boolean,
                                   ByVal IsJobAlertsPage As Boolean,
                                   ByVal AlertAssignmentSeqNbr As Integer,
                                   ByVal GroupBy As String,
                                   ByVal SearchCriteria As String,
                                   ByVal AccountExecutiveCode As String,
                                   ByVal ManagerCode As String,
                                   ByVal StateId As Integer,
                                   ByVal RecordsToReturn As Integer,
                                   ByVal IsCount As Boolean,
                                   ByRef RecordCount As Integer,
                                   ByVal IncludeReviews As Boolean,
                                   ByVal IncludeBoardLevel As Boolean,
                                   ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert)

            Dim Alerts As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert) = Nothing
            Dim DataTable As System.Data.DataTable = Nothing

            Try

                DataTable = AdvantageFramework.AlertSystem.LoadAlertsCPAsDatable(DbContext,
                                                                                  CPID,
                                                                                  InboxType,
                                                                                  FilterLevel,
                                                                                  OfficeCode,
                                                                                  ClCode,
                                                                                  DivCode,
                                                                                  PrdCode,
                                                                                  CmpIdentifier,
                                                                                  CmpCode,
                                                                                  JobNumber,
                                                                                  JobComponentNbr,
                                                                                  AlertTypeId,
                                                                                  AlertCategoryId,
                                                                                  StartDate,
                                                                                  EndDate,
                                                                                  AlertLevel,
                                                                                  VnCode,
                                                                                  EstimateNumber,
                                                                                  EstComponentNbr,
                                                                                  TaskCode,
                                                                                  TaskDescription,
                                                                                  ShowAssignmentType,
                                                                                  AlrtNotifyHdrId,
                                                                                  AlertNotifyName,
                                                                                  IncludeCompletedAssignments,
                                                                                  IsJobAlertsPage,
                                                                                  AlertAssignmentSeqNbr,
                                                                                  GroupBy,
                                                                                  SearchCriteria,
                                                                                  RecordsToReturn,
                                                                                  IsCount,
                                                                                  RecordCount,
                                                                                  IncludeReviews,
                                                                                  ErrorMessage)

                If DataTable IsNot Nothing AndAlso DataTable.Rows.Count > 0 Then

                    Alerts = DataTable.Rows.OfType(Of DataRow).ToList.Select(Function(dr) AdvantageFramework.DTO.Desktop.Alert.FromMainAlertQuery(dr, GroupBy)).ToList

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                Alerts = Nothing
            End Try

            Return Alerts

        End Function
        Public Function LoadAlerts(DbContext As AdvantageFramework.Database.DbContext, EmployeeCode As String,
                                   TaskStartToday As String, TaskOnlyStartDue As String, TaskStatus As String,
                                   DefaultSort As String) As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert)

            Dim Alerts As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert) = Nothing
            Dim Status As String = ""
            Dim Offset As Decimal = 0.0
            Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim StartDateAsOfTodaySqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim StartAndDueDateNotNullSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim TaskStatusSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim GroupBySqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeBacklogSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim GetNotificationCountOnlySqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim OffsetSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            If TaskStatus = "Projected" Then

                Status = "P"

            ElseIf TaskStatus = "Active" Then

                Status = "A"

            End If

            Offset = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, EmployeeCode)

            EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            StartDateAsOfTodaySqlParameter = New System.Data.SqlClient.SqlParameter("@START_DATE_AS_OF_TODAY", SqlDbType.Bit)
            StartAndDueDateNotNullSqlParameter = New System.Data.SqlClient.SqlParameter("@START_AND_DUE_DATE_NOT_NULL", SqlDbType.Bit)
            TaskStatusSqlParameter = New System.Data.SqlClient.SqlParameter("@TASK_STATUS", SqlDbType.Char)
            GroupBySqlParameter = New System.Data.SqlClient.SqlParameter("@GROUP_BY", SqlDbType.VarChar, 20)
            IncludeBacklogSqlParameter = New System.Data.SqlClient.SqlParameter("@INCLUDE_BACKLOG", SqlDbType.Bit)
            GetNotificationCountOnlySqlParameter = New System.Data.SqlClient.SqlParameter("@GET_NOTIFICATION_COUNT_ONLY", SqlDbType.Bit)
            OffsetSqlParameter = New System.Data.SqlClient.SqlParameter("@OFFSET", SqlDbType.Decimal)

            EmployeeCodeSqlParameter.Value = EmployeeCode
            StartDateAsOfTodaySqlParameter.Value = TaskStartToday = "True"
            StartAndDueDateNotNullSqlParameter.Value = TaskOnlyStartDue = "True"
            TaskStatusSqlParameter.Value = Status
            GroupBySqlParameter.Value = DefaultSort
            IncludeBacklogSqlParameter.Value = False
            GetNotificationCountOnlySqlParameter.Value = False
            OffsetSqlParameter.Value = Offset

            Alerts = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Desktop.Alert)(String.Format("EXEC [dbo].[usp_wv_dto_dashboard_alert] @EMP_CODE, @START_DATE_AS_OF_TODAY, @START_AND_DUE_DATE_NOT_NULL, @TASK_STATUS, @GROUP_BY, @INCLUDE_BACKLOG, @GET_NOTIFICATION_COUNT_ONLY, @OFFSET;"),
                                                                                          EmployeeCodeSqlParameter,
                                                                                          StartDateAsOfTodaySqlParameter,
                                                                                          StartAndDueDateNotNullSqlParameter,
                                                                                          TaskStatusSqlParameter,
                                                                                          GroupBySqlParameter,
                                                                                          IncludeBacklogSqlParameter,
                                                                                          GetNotificationCountOnlySqlParameter,
                                                                                          OffsetSqlParameter).ToList

            If DefaultSort = "PRIORITY" Then

                Alerts = Alerts.OrderBy(Function(A) A.PriorityLevel).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "DUE_DATE_ASC" Then

                Alerts = Alerts.OrderBy(Function(A) A.DueDate).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "DUE_DATE" Then

                Alerts = Alerts.OrderByDescending(Function(A) A.DueDate).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "VER_BLD" Then

                Alerts = Alerts.OrderByDescending(Function(A) A.Version).ThenBy(Function(A) A.Build).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "LAST_UPD" Then

                Alerts = Alerts.OrderByDescending(Function(A) A.LastUpdatedDateTime).ThenBy(Function(A) A.CardSequenceNumber).ToList

            ElseIf DefaultSort = "NEW_UNREAD" Then

                Alerts = Alerts.OrderBy(Function(A) A.GroupKey).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "CAT" Then

                Alerts = Alerts.OrderBy(Function(A) A.AlertCategoryDescription).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "STATE" Then

                Alerts = Alerts.OrderBy(Function(A) A.AlertStateName).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "C" Then

                Alerts = Alerts.OrderBy(Function(A) A.ClientName).ThenBy(Function(A) A.DivisionCode).ThenBy(Function(A) A.ProductCode).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "CD" Then

                Alerts = Alerts.OrderBy(Function(A) A.DivisionName).ThenBy(Function(A) A.ProductCode).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "CDP" Then

                Alerts = Alerts.OrderBy(Function(A) A.ProductName).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "CDPJ" Then

                Alerts = Alerts.OrderBy(Function(A) A.GroupKey).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "CDPJC" Then

                Alerts = Alerts.OrderBy(Function(A) A.GroupKey).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "TS" Then

                Alerts = Alerts.OrderBy(Function(A) A.GroupKey).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            Else

                Alerts = Alerts.OrderBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            End If

            LoadAlerts = Alerts

        End Function
        Public Function LoadAlertsCPNew(DbContext As AdvantageFramework.Database.DbContext, CP_ID As String,
                                   TaskStartToday As String, TaskOnlyStartDue As String, TaskStatus As String,
                                   DefaultSort As String) As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert)

            Dim Alerts As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert) = Nothing
            Dim Status As String = ""
            Dim Offset As Decimal = 0.0
            Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim StartDateAsOfTodaySqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim StartAndDueDateNotNullSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim TaskStatusSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim GroupBySqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeBacklogSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim GetNotificationCountOnlySqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim OffsetSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            If TaskStatus = "Projected" Then

                Status = "P"

            ElseIf TaskStatus = "Active" Then

                Status = "A"

            End If

            Offset = 0 'AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, EmployeeCode)

            EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@CP_ID", SqlDbType.VarChar, 6)
            StartDateAsOfTodaySqlParameter = New System.Data.SqlClient.SqlParameter("@START_DATE_AS_OF_TODAY", SqlDbType.Bit)
            StartAndDueDateNotNullSqlParameter = New System.Data.SqlClient.SqlParameter("@START_AND_DUE_DATE_NOT_NULL", SqlDbType.Bit)
            TaskStatusSqlParameter = New System.Data.SqlClient.SqlParameter("@TASK_STATUS", SqlDbType.Char)
            GroupBySqlParameter = New System.Data.SqlClient.SqlParameter("@GROUP_BY", SqlDbType.VarChar, 20)
            IncludeBacklogSqlParameter = New System.Data.SqlClient.SqlParameter("@INCLUDE_BACKLOG", SqlDbType.Bit)
            GetNotificationCountOnlySqlParameter = New System.Data.SqlClient.SqlParameter("@GET_NOTIFICATION_COUNT_ONLY", SqlDbType.Bit)
            OffsetSqlParameter = New System.Data.SqlClient.SqlParameter("@OFFSET", SqlDbType.Decimal)

            EmployeeCodeSqlParameter.Value = CP_ID
            StartDateAsOfTodaySqlParameter.Value = TaskStartToday = "True"
            StartAndDueDateNotNullSqlParameter.Value = TaskOnlyStartDue = "True"
            TaskStatusSqlParameter.Value = Status
            GroupBySqlParameter.Value = DefaultSort
            IncludeBacklogSqlParameter.Value = False
            GetNotificationCountOnlySqlParameter.Value = False
            OffsetSqlParameter.Value = Offset

            Alerts = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Desktop.Alert)(String.Format("EXEC [dbo].[usp_cp_dto_dashboard_alert] @CP_ID, @START_DATE_AS_OF_TODAY, @START_AND_DUE_DATE_NOT_NULL, @TASK_STATUS, @GROUP_BY, @INCLUDE_BACKLOG, @GET_NOTIFICATION_COUNT_ONLY, @OFFSET;"),
                                                                                          EmployeeCodeSqlParameter,
                                                                                          StartDateAsOfTodaySqlParameter,
                                                                                          StartAndDueDateNotNullSqlParameter,
                                                                                          TaskStatusSqlParameter,
                                                                                          GroupBySqlParameter,
                                                                                          IncludeBacklogSqlParameter,
                                                                                          GetNotificationCountOnlySqlParameter,
                                                                                          OffsetSqlParameter).ToList

            If DefaultSort = "PRIORITY" Then

                Alerts = Alerts.OrderBy(Function(A) A.PriorityLevel).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "DUE_DATE_ASC" Then

                Alerts = Alerts.OrderBy(Function(A) A.DueDate).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "DUE_DATE" Then

                Alerts = Alerts.OrderByDescending(Function(A) A.DueDate).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "VER_BLD" Then

                Alerts = Alerts.OrderByDescending(Function(A) A.Version).ThenBy(Function(A) A.Build).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "LAST_UPD" Then

                Alerts = Alerts.OrderByDescending(Function(A) A.LastUpdatedDateTime).ThenBy(Function(A) A.CardSequenceNumber).ToList

            ElseIf DefaultSort = "NEW_UNREAD" Then

                Alerts = Alerts.OrderBy(Function(A) A.GroupKey).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "CAT" Then

                Alerts = Alerts.OrderBy(Function(A) A.AlertCategoryDescription).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "STATE" Then

                Alerts = Alerts.OrderBy(Function(A) A.AlertStateName).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "C" Then

                Alerts = Alerts.OrderBy(Function(A) A.ClientName).ThenBy(Function(A) A.DivisionCode).ThenBy(Function(A) A.ProductCode).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "CD" Then

                Alerts = Alerts.OrderBy(Function(A) A.DivisionName).ThenBy(Function(A) A.ProductCode).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "CDP" Then

                Alerts = Alerts.OrderBy(Function(A) A.ProductName).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "CDPJ" Then

                Alerts = Alerts.OrderBy(Function(A) A.GroupKey).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "CDPJC" Then

                Alerts = Alerts.OrderBy(Function(A) A.GroupKey).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            ElseIf DefaultSort = "TS" Then

                Alerts = Alerts.OrderBy(Function(A) A.GroupKey).ThenBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            Else

                Alerts = Alerts.OrderBy(Function(A) A.CardSequenceNumber).ThenByDescending(Function(A) A.LastUpdatedDateTime).ToList

            End If

            LoadAlertsCPNew = Alerts

        End Function

#End Region

#Region " ALERT NOTIFICATIONS "

        Public Function LoadNotificationCount() As Integer

            Dim Count As Integer = 0

            Try
                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Count = LoadNotificationCount(DbContext)

                End Using
            Catch ex As Exception
                Count = 0
            End Try

            Return Count

        End Function
        Public Function LoadNotificationCount(ByVal DbContext As AdvantageFramework.Database.DbContext) As Integer

            Dim Count As Integer = 0

            Try

                'Count = (From Entity In DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Desktop.Alert)(String.Format("exec dbo.usp_wv_dto_dashboard_alert '{0}', @GET_NOTIFICATION_COUNT_ONLY = 1", Session.User.EmployeeCode)).ToList
                '         Where Entity.ReadAlert Is Nothing OrElse Entity.ReadAlert = 0).Count

                Count = (From Entity In DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Desktop.Alert)(String.Format("EXEC [dbo].[usp_wv_dto_dashboard_alert] '{0}', @GET_NOTIFICATION_COUNT_ONLY = 1;", Session.User.EmployeeCode)).ToList
                         Where Entity.ReadAlert Is Nothing OrElse
                             Entity.ReadAlert = 0).Count


            Catch ex As Exception
                Count = 0
            End Try

            Return Count

        End Function
        Public Function LoadNotifications() As Generic.List(Of AdvantageFramework.ViewModels.Desktop.AlertNotification)

            Dim Notifications As Generic.List(Of AdvantageFramework.ViewModels.Desktop.AlertNotification) = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Notifications = LoadNotifications(DbContext)

                End Using

            Catch ex As Exception
                Notifications = Nothing
            End Try

            If Notifications Is Nothing Then Notifications = New List(Of ViewModels.Desktop.AlertNotification)

            Return Notifications

        End Function
        Public Function LoadNotifications(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.ViewModels.Desktop.AlertNotification)

            Dim Notifications As Generic.List(Of AdvantageFramework.ViewModels.Desktop.AlertNotification) = Nothing
            Dim Alerts As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert) = Nothing
            Dim Status As String = ""
            Dim Offset As Decimal = 0.0

            Offset = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, Me.Session.User.EmployeeCode)

            Alerts = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Desktop.Alert)(String.Format("EXEC [dbo].[usp_wv_dto_dashboard_alert] '{0}', {1}, {2}, '{3}', '{4}', @INCLUDE_BACKLOG = 1, @OFFSET = {5};",
                                                                                                        Me.Session.User.EmployeeCode, 0, 0, Status, "", Offset)).ToList

            Try

                'Notifications = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.Desktop.AlertNotification)(String.Format("EXEC [dbo].[advsp_alert_notifications] '{0}', NULL;", Me.Session.User.EmployeeCode)).ToList
                If Alerts IsNot Nothing Then

                    Notifications = (From Entity In Alerts
                                     Where Entity.ReadAlert Is Nothing OrElse Entity.ReadAlert = 0
                                     Order By Entity.LastUpdatedDateTime Descending
                                     Select New AdvantageFramework.ViewModels.Desktop.AlertNotification With {.AlertID = Entity.ID,
                                                                                                              .LastUpdated = Entity.LastUpdatedDateTime,
                                                                                                              .Generated = Entity.GeneratedDate,
                                                                                                              .Priority = Entity.PriorityLevel,
                                                                                                              .ShortSubject = Entity.Subject,
                                                                                                              .Subject = Entity.Subject,
                                                                                                              .IsAssignment = Entity.IsAlertAssignment,
                                                                                                              .JobNumber = Entity.JobNumber,
                                                                                                              .JobComponentNumber = Entity.JobComponentNumber,
                                                                                                              .SequenceNumber = Entity.TaskSequenceNumber,
                                                                                                              .IsConceptShareReview = Entity.IsCSReview,
                                                                                                              .ConceptShareProjectID = Entity.CSProjectID,
                                                                                                              .ConceptShareReviewID = Entity.CSReviewID,
                                                                                                              .AssignedEmployeeCode = Entity.AssignedEmployeeCode,
                                                                                                              .CurrentNotify = True,
                                                                                                              .IsWorkItem = Entity.IsWorkItem,
                                                                                                              .SprintID = Entity.SprintID,
                                                                                                              .LastUpdatedFullName = Entity.LastUpdatedFullName,
                                                                                                              .LastUpdatedEmployeeCode = Entity.EmployeeCode,
                                                                                                              .AlertCategoryDescription = Entity.AlertCategoryDescription}).ToList

                End If

            Catch ex As Exception
                Notifications = Nothing
            Finally
                If Notifications Is Nothing Then Notifications = New Generic.List(Of AdvantageFramework.ViewModels.Desktop.AlertNotification)
            End Try

            Return Notifications

        End Function
        Public Function AlertNotificationMarkAllAsRead(ByVal EmployeeCode As String) As Boolean

            Dim Success As Boolean = True

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE ALERT_RCPT SET READ_ALERT = 1 WHERE EMP_CODE = '{0}' AND (READ_ALERT IS NULL OR READ_ALERT = 0);" &
                                                                       "UPDATE JOB_TRAFFIC_DET_EMPS SET READ_ALERT = 1 WHERE EMP_CODE = '{0}' AND (READ_ALERT IS NULL OR READ_ALERT = 0);", EmployeeCode))
                    Success = True
                    'Dim Notifications As Generic.List(Of AdvantageFramework.ViewModels.Desktop.AlertNotification) = Nothing

                    'Notifications = LoadNotifications(DbContext)

                    'If Notifications IsNot Nothing Then

                    '    Dim PromptForFullCompleteTask As Boolean = False
                    '    Dim PromptForTempCompleteTask As Boolean = False
                    '    Dim ErrorMessage As String = String.Empty
                    '    Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
                    '    Dim JobComponentTaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee = Nothing

                    '    For Each Notif As AdvantageFramework.ViewModels.Desktop.AlertNotification In Notifications

                    '        AlertRecipient = Nothing

                    '        Try

                    '            AlertRecipient = AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertIDAndEmployeeCode(DbContext, Notif.AlertID, EmployeeCode)

                    '        Catch ex As Exception
                    '            AlertRecipient = Nothing
                    '        End Try

                    '        If AlertRecipient IsNot Nothing Then

                    '            AlertRecipient.HasBeenRead = 1

                    '            If AdvantageFramework.Database.Procedures.AlertRecipient.Update(DbContext, AlertRecipient) = True Then

                    '                Success = True

                    '            End If

                    '        Else

                    '            JobComponentTaskEmployee = Nothing

                    '            Try

                    '                JobComponentTaskEmployee = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeqEmp(DbContext, Notif.JobNumber, Notif.JobComponentNumber, Notif.SequenceNumber, EmployeeCode)

                    '            Catch ex As Exception
                    '                JobComponentTaskEmployee = Nothing
                    '            End Try

                    '            If JobComponentTaskEmployee IsNot Nothing Then

                    '                JobComponentTaskEmployee.ReadAlert = 1

                    '                If AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Update(DbContext, JobComponentTaskEmployee) = True Then

                    '                    Success = True

                    '                End If

                    '            End If

                    '        End If

                    '    Next

                    'End If

                End Using

            Catch ex As Exception
                Success = False
            End Try

            Return Success

        End Function
        Public Function AlertNotificationDismissAllAlerts(ByVal EmployeeCode As String) As Boolean

            Dim HasAlertDismissed As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Dim Alerts As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert) = Nothing

                    Alerts = LoadAlerts(DbContext, EmployeeCode, "", "", "", "")

                    If Alerts IsNot Nothing AndAlso Alerts.Count > 0 Then

                        Alerts = Alerts.Where(Function(F) F.IsAlertCC = True AndAlso (F.ReadAlert Is Nothing OrElse F.ReadAlert = 0)).ToList

                        If Alerts IsNot Nothing AndAlso Alerts.Count > 0 Then

                            Dim PromptForFullCompleteTask As Boolean = False
                            Dim PromptForTempCompleteTask As Boolean = False
                            Dim ErrorMessage As String = String.Empty

                            For Each Alert As AdvantageFramework.DTO.Desktop.Alert In Alerts

                                Try

                                    AdvantageFramework.AlertSystem.DismissAlert(DbContext,
                                                                                Alert.ID,
                                                                                EmployeeCode,
                                                                                Me.Session.UserCode,
                                                                                0,
                                                                                False,
                                                                                PromptForFullCompleteTask,
                                                                                PromptForTempCompleteTask,
                                                                                ErrorMessage)

                                Catch ex As Exception
                                End Try

                            Next

                        End If

                    End If

                End Using

            Catch ex As Exception
                HasAlertDismissed = False
            End Try

            Return HasAlertDismissed

        End Function

#End Region

#Region " New Assignment "

        Public Function InitNewAssignment() As AdvantageFramework.DTO.Desktop.Alert

            Dim Alert As New AdvantageFramework.DTO.Desktop.Alert

            Return Alert

        End Function
        Public Function GetScheduleTasks(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)

            Dim ScheduleTaskList As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = Nothing

            Try

                ScheduleTaskList = AdvantageFramework.ProjectSchedule.GetScheduleTasks(DbContext, JobNumber, JobComponentNumber, "",
                                                                                       DbContext.UserCode, "", "", "", True,
                                                                                       False, False, "", "no_filter", False, False, False, False)

            Catch ex As Exception
                ScheduleTaskList = Nothing
            Finally
                If ScheduleTaskList Is Nothing Then ScheduleTaskList = New List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)
            End Try

            Return ScheduleTaskList

        End Function

#End Region

#Region " Proofing External Reviewers "

        Public Function EmailExternalReviewers(ByVal AlertID As Integer,
                                               ByVal ProofingExternalReviewerID As Integer?,
                                               ByVal OnlyUnMarked As Boolean,
                                               ByRef ErrorMessages As Generic.List(Of String)) As Boolean

            Dim Success As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        If AdvantageFramework.Proofing.SendExternalReviewerEmail(Me.Session,
                                                                                 DbContext,
                                                                                 SecurityDbContext,
                                                                                 Proofing.Methods.ExternalReviewerEmailAction.SendForReview,
                                                                                 AlertID,
                                                                                 ProofingExternalReviewerID,
                                                                                 OnlyUnMarked,
                                                                                 ErrorMessages) = True Then

                            Success = True

                        End If

                    Catch ex As Exception
                        ErrorMessages.Add(AdvantageFramework.StringUtilities.FullErrorToString(ex))
                        Success = False
                    End Try

                End Using

            End Using

            Return Success


        End Function
        Public Function AddExternalReviewerToAssignment(ByVal AlertID As Integer,
                                                        ByVal ProofingExternalReviewerID As Integer,
                                                        ByRef ErrorMessage As String) As Boolean

            Dim Success As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_proofing_add_external_reviewer_to_assignment] {0}, {1};", AlertID, ProofingExternalReviewerID))

                Catch ex As Exception
                    Success = False
                End Try

            End Using

            Return Success

        End Function
        Public Function CanRemoveExternalReviewerFromAssignment(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                ByVal AlertID As Integer,
                                                                ByVal ProofingExternalReviewerID As Integer,
                                                                ByRef ErrorMessage As String) As Boolean

            Dim CanRemove As Boolean = True
            Dim ExternalReviewerDismissed As AdvantageFramework.Database.Entities.AlertRecipientExternalDismissed = Nothing

            ExternalReviewerDismissed = AdvantageFramework.Database.Procedures.AlertRecipientExternalDismissed.LoadByAlertIDandProofingExternalReviewerID(DbContext,
                                                                                                                                                          AlertID,
                                                                                                                                                          ProofingExternalReviewerID)
            If ExternalReviewerDismissed IsNot Nothing AndAlso
               ExternalReviewerDismissed.ProofingStatusID IsNot Nothing AndAlso
               ExternalReviewerDismissed.ProofingStatusID > 0 Then

                CanRemove = False
                ErrorMessage = "Cannot remove this external reviewer."

            End If

            Return CanRemove

        End Function
        Public Function RemoveExternalReviewerFromAssignment(ByVal AlertID As Integer,
                                                             ByVal ProofingExternalReviewerID As Integer,
                                                             ByRef ErrorMessage As String) As Boolean

            Dim Success As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_proofing_remove_external_reviewer_from_assignment] {0}, {1};", AlertID, ProofingExternalReviewerID))
                    Success = True

                Catch ex As Exception
                    Success = False
                End Try

            End Using

            Return Success

        End Function
        'Public Function RemoveExistingExternalReviewer(ByVal AlertID As Integer,
        '                                               ByVal ProofingExternalReviewerID As Integer,
        '                                               ByRef ErrorMessage As String) As Boolean

        '    Dim Removed As Boolean = True

        '    Try

        '        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '        End Using

        '    Catch ex As Exception
        '        Removed = False
        '        ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
        '    End Try

        '    Return Removed

        'End Function
        Public Function SaveExternalReviewer(ByVal AlertID As Integer,
                                             ByVal Name As String,
                                             ByVal Email As String,
                                             ByRef ErrorMessage As String) As AdvantageFramework.Database.Entities.ProofingExternalReviewer

            Dim Saved As Boolean = False
            Dim ProofingExternalReviewer As AdvantageFramework.Database.Entities.ProofingExternalReviewer = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                    If Alert IsNot Nothing Then

                        ProofingExternalReviewer = New Database.Entities.ProofingExternalReviewer

                        ProofingExternalReviewer.Name = Name
                        ProofingExternalReviewer.Email = Email
                        ProofingExternalReviewer.ClientCode = Alert.ClientCode
                        ProofingExternalReviewer.DivisionCode = Alert.DivisionCode
                        ProofingExternalReviewer.ProductCode = Alert.ProductCode
                        ProofingExternalReviewer.JobNumber = Alert.JobNumber
                        ProofingExternalReviewer.JobComponentNumber = Alert.JobComponentNumber
                        ProofingExternalReviewer.AddedByUserCode = Me.Session.UserCode
                        ProofingExternalReviewer.AddedDate = DateTime.Now
                        ProofingExternalReviewer.IsActive = True

                        Saved = AdvantageFramework.Database.Procedures.ProofingExternalReviewer.Insert(DbContext, ProofingExternalReviewer, ErrorMessage)

                        If Saved = False Then

                            ProofingExternalReviewer = Nothing

                        End If

                    End If

                End Using

            Catch ex As Exception
                Saved = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                ProofingExternalReviewer = Nothing
            End Try

            Return ProofingExternalReviewer

        End Function

#End Region
        Public Function UpdateAssignmentsCDP(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal ClientCode As String,
                                             ByVal DivisionCode As String,
                                             ByVal ProductCode As String,
                                             ByVal JobNumber As Integer,
                                             ByVal JobComponentNumber As Short,
                                             ByRef ErrorMessage As String) As Boolean

            Dim Success As Boolean = True

            Try

                Dim SqlParameterClientCode As New System.Data.SqlClient.SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
                Dim SqlParameterDivisionCode As New System.Data.SqlClient.SqlParameter("@DIV_CODE", SqlDbType.VarChar, 6)
                Dim SqlParameterProductCode As New System.Data.SqlClient.SqlParameter("@PRD_CODE", SqlDbType.VarChar, 6)
                Dim SqlParameterJobNumber As New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                'Dim SqlParameterJobComponentNumber As New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)

                SqlParameterClientCode.Value = ClientCode
                SqlParameterDivisionCode.Value = DivisionCode
                SqlParameterProductCode.Value = ProductCode
                SqlParameterJobNumber.Value = JobNumber
                'SqlParameterJobComponentNumber.Value = JobComponentNumber

                'DbContext.Database.ExecuteSqlCommand("UPDATE ALERT WITH(ROWLOCK) SET CL_CODE = @CL_CODE, DIV_CODE = @DIV_CODE, PRD_CODE = @PRD_CODE WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR;",
                '                                     SqlParameterClientCode,
                '                                     SqlParameterDivisionCode,
                '                                     SqlParameterProductCode,
                '                                     SqlParameterJobNumber,
                '                                     SqlParameterJobComponentNumber)

                DbContext.Database.ExecuteSqlCommand("UPDATE ALERT WITH(ROWLOCK) SET CL_CODE = @CL_CODE, DIV_CODE = @DIV_CODE, PRD_CODE = @PRD_CODE WHERE JOB_NUMBER = @JOB_NUMBER;",
                                                     SqlParameterClientCode,
                                                     SqlParameterDivisionCode,
                                                     SqlParameterProductCode,
                                                     SqlParameterJobNumber)

            Catch ex As Exception
                Success = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return Success

        End Function
        Public Sub New(ByVal Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function UploadURL(ByVal AlertID As String,
                                  ByVal Title As String,
                                  ByVal URL As String,
                                  ByVal UploadDocumentManager As Boolean,
                                  ByRef ErrorMessage As String) As Boolean

            Dim Success As Boolean = True

            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
            Dim SavedToAttachment As Boolean = False
            Dim RightNow As DateTime = DateTime.Now

            Try

                If String.IsNullOrWhiteSpace(URL) = False Then

                    If URL.ToLower().StartsWith("http://") = False AndAlso URL.ToLower().StartsWith("https://") = False Then

                        URL = "http://" & URL

                    End If

                    If AdvantageFramework.StringUtilities.IsValidURL(URL) = True Then

                        If String.IsNullOrWhiteSpace(Title) = True Then

                            Title = URL

                        End If

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                            If Alert IsNot Nothing Then

                                Document = New Database.Entities.Document

                                Document.FileName = Title
                                Document.FileSystemFileName = URL
                                Document.MIMEType = "URL"
                                Document.DocumentTypeID = 6
                                Document.UploadedDate = RightNow

                                If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document) = True Then

                                    AlertAttachment = New Database.Entities.AlertAttachment

                                    AlertAttachment.AlertID = Alert.ID
                                    AlertAttachment.DocumentID = Document.ID
                                    AlertAttachment.HasEmailBeenSent = False
                                    AlertAttachment.GeneratedDate = RightNow
                                    AlertAttachment.UserCode = Me.Session.UserCode

                                    SavedToAttachment = AdvantageFramework.Database.Procedures.AlertAttachment.Insert(DbContext, AlertAttachment)

                                    If SavedToAttachment = True Then

                                        If UploadDocumentManager = True Then

                                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                                AddRepositoryReference(DataContext, Alert, Document.ID, ErrorMessage)

                                            End Using

                                        End If

                                    Else

                                        Success = False
                                        ErrorMessage = "Failed to save to assignment"

                                        AdvantageFramework.Database.Procedures.Document.Delete(DbContext, Document)

                                    End If

                                Else

                                    Success = False
                                    ErrorMessage = "Failed to save URL"

                                End If

                            End If

                        End Using

                    Else

                        Success = False
                        ErrorMessage = "Invalid URL."

                    End If

                Else

                    Success = False
                    ErrorMessage = "No URL."

                End If


            Catch ex As Exception
                Success = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return Success

        End Function
        Private Function AddRepositoryReference(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                                ByVal DocumentID As Integer,
                                                ByRef ErrorMessage As String) As Boolean

            Dim Added As Boolean = False

            Try

                If Alert IsNot Nothing AndAlso DocumentID > 0 Then

                    Select Case Alert.AlertLevel.Trim().ToUpper()
                        Case "OF"

                            If String.IsNullOrWhiteSpace(Alert.OfficeCode) = False Then

                                Using DbContext = New AdvantageFramework.Database.DbContext(DataContext.Connection.ConnectionString, DataContext.UserCode)

                                    Dim OfficeDocument As New AdvantageFramework.Database.Entities.OfficeDocument

                                    OfficeDocument.DocumentID = DocumentID
                                    OfficeDocument.OfficeCode = Alert.OfficeCode

                                    If AdvantageFramework.Database.Procedures.OfficeDocument.Insert(DbContext, OfficeDocument) = False Then

                                        Added = False
                                        ErrorMessage = "Failed to save to office."

                                    End If

                                End Using

                            End If

                        Case "CL"

                            If String.IsNullOrWhiteSpace(Alert.ClientCode) = False Then

                                Dim ClientDocument As New AdvantageFramework.Database.Entities.ClientDocument

                                ClientDocument.DocumentID = DocumentID
                                ClientDocument.ClientCode = Alert.ClientCode

                                If AdvantageFramework.Database.Procedures.ClientDocument.Insert(DataContext, ClientDocument) = False Then

                                    Added = False
                                    ErrorMessage = "Failed to save to client"

                                End If

                            End If

                        Case "DIV"

                            If String.IsNullOrWhiteSpace(Alert.ClientCode) = False AndAlso
                                String.IsNullOrWhiteSpace(Alert.DivisionCode) = False Then

                                Dim DivisionDocument As New AdvantageFramework.Database.Entities.DivisionDocument

                                DivisionDocument.DocumentID = DocumentID
                                DivisionDocument.ClientCode = Alert.ClientCode
                                DivisionDocument.DivisionCode = Alert.DivisionCode

                                If AdvantageFramework.Database.Procedures.DivisionDocument.Insert(DataContext, DivisionDocument) = False Then

                                    Added = False
                                    ErrorMessage = "Failed to save to division"

                                End If

                            End If

                        Case "PRD"

                            If String.IsNullOrWhiteSpace(Alert.ClientCode) = False AndAlso
                                String.IsNullOrWhiteSpace(Alert.DivisionCode) = False AndAlso
                                String.IsNullOrWhiteSpace(Alert.ProductCode) = False Then

                                Dim ProductDocument As New AdvantageFramework.Database.Entities.ProductDocument

                                ProductDocument.DocumentID = DocumentID
                                ProductDocument.ClientCode = Alert.ClientCode
                                ProductDocument.DivisionCode = Alert.DivisionCode
                                ProductDocument.ProductCode = Alert.ProductCode

                                If AdvantageFramework.Database.Procedures.ProductDocument.Insert(DataContext, ProductDocument) = False Then

                                    Added = False
                                    ErrorMessage = "Failed to save to product"

                                End If

                            End If

                        Case "JO"

                            If Alert.JobNumber IsNot Nothing AndAlso Alert.JobNumber > 0 Then

                                Dim JobDocument As AdvantageFramework.Database.Entities.JobDocument = Nothing

                                JobDocument = New Database.Entities.JobDocument

                                JobDocument.DocumentID = DocumentID
                                JobDocument.JobNumber = Alert.JobNumber

                                If AdvantageFramework.Database.Procedures.JobDocument.Insert(DataContext, JobDocument) = False Then

                                    Added = False
                                    ErrorMessage = "Failed to save to component"

                                End If

                            End If

                        Case "JC"

                            If Alert.JobNumber IsNot Nothing AndAlso Alert.JobComponentNumber IsNot Nothing AndAlso
                                Alert.JobNumber > 0 AndAlso Alert.JobComponentNumber > 0 Then

                                Dim JobComponentDocument As AdvantageFramework.Database.Entities.JobComponentDocument = Nothing

                                JobComponentDocument = New Database.Entities.JobComponentDocument

                                JobComponentDocument.DocumentID = DocumentID
                                JobComponentDocument.JobNumber = Alert.JobNumber
                                JobComponentDocument.JobComponentNumber = Alert.JobComponentNumber

                                If AdvantageFramework.Database.Procedures.JobComponentDocument.Insert(DataContext, JobComponentDocument) = False Then

                                    Added = False
                                    ErrorMessage = "Failed to save to component"

                                End If

                            End If

                        Case "BRD", "PST"

                            If Alert.JobNumber IsNot Nothing AndAlso Alert.JobComponentNumber IsNot Nothing AndAlso Alert.TaskSequenceNumber IsNot Nothing AndAlso
                                Alert.JobNumber > 0 AndAlso Alert.JobComponentNumber > 0 AndAlso Alert.TaskSequenceNumber > -1 Then

                                Dim JobComponentTaskDocument As AdvantageFramework.Database.Entities.JobComponentTaskDocument = Nothing

                                JobComponentTaskDocument = New Database.Entities.JobComponentTaskDocument

                                JobComponentTaskDocument.DocumentID = DocumentID
                                JobComponentTaskDocument.JobNumber = Alert.JobNumber
                                JobComponentTaskDocument.JobComponentNumber = Alert.JobComponentNumber
                                JobComponentTaskDocument.SequenceNumber = Alert.TaskSequenceNumber

                                If AdvantageFramework.Database.Procedures.JobComponentTaskDocument.Insert(DataContext, JobComponentTaskDocument) = False Then

                                    Added = False
                                    ErrorMessage = "Failed to save to component"

                                End If

                            End If

                    End Select

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                Added = False
            End Try

            Return Added

        End Function
        Public Function AddAutoComment(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal EmployeeCode As String,
                                       ByVal CommentType As Integer, ByVal AlertTemplateID As Integer, ByVal AlertStateID As Integer) As Boolean

            Dim Added As Boolean

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[usp_wv_ALERT_NOTIFY_AUTO_COMMENT] '{0}', {1}, '{2}', {3}, {4}, {5};",
                                                                   DbContext.UserCode, AlertID, EmployeeCode, CommentType, AlertStateID, AlertTemplateID))

            Catch ex As Exception
                Added = False
            End Try

            Return Added

        End Function
        Public Function GetDefaultSubjectType() As String

            Dim DefaultSubjectType As String = String.Empty
            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DefaultSubjectType = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT CAST(ISNULL(AGY_SETTINGS_VALUE, '') AS VARCHAR) FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'ALRT_ASSGN_DFLT_SUB';")).SingleOrDefault

                End Using

            Catch ex As Exception
                DefaultSubjectType = String.Empty
            End Try

            Return DefaultSubjectType

        End Function
        Public Function LoadAlertView(ByVal AlertID As Integer, Optional ByVal CDPContactID As Integer = 0, Optional ByVal Offset As Decimal = 0, Optional ByVal SprintID As Integer = 0, Optional ByVal IsClientPortal As Boolean = False) As AdvantageFramework.ViewModels.Desktop.AlertView

            'objects
            Dim AlertView As AdvantageFramework.ViewModels.Desktop.AlertView = Nothing
            Dim Alert As AdvantageFramework.DTO.Desktop.Alert = Nothing
            Dim ErrorMessage As String = String.Empty

            AlertView = New AdvantageFramework.ViewModels.Desktop.AlertView

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Alert = LoadAlert(DbContext, AlertID, CDPContactID, Offset, SprintID, IsClientPortal)

            End Using

            AlertView.Alert = Alert

            Return AlertView

        End Function
        Public Function LoadAlert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, Optional ByVal CDPContactID As Integer = 0, Optional ByVal Offset As Decimal = 0, Optional ByVal SprintID As Integer = 0, Optional ByVal IsClientPortal As Boolean = False) As AdvantageFramework.DTO.Desktop.Alert

            'objects
            Dim Alert As AdvantageFramework.DTO.Desktop.Alert = Nothing
            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim CDPContactIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim OffsetSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim SprintIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("AlertID", AlertID)
            If IsClientPortal = True Then
                EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("EmployeeCode", "")
            Else
                EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("EmployeeCode", Me.Session.User.EmployeeCode)
            End If
            CDPContactIDSqlParameter = New System.Data.SqlClient.SqlParameter("CDPContactID", CDPContactID)
            OffsetSqlParameter = New System.Data.SqlClient.SqlParameter("Offset", Offset)
            SprintIDSqlParameter = New System.Data.SqlClient.SqlParameter("SprintID", SprintID)

            Try

                Alert = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Desktop.Alert)("EXEC [dbo].[advsp_alert_get] @AlertID, @EmployeeCode, @CDPContactID, @Offset, @SprintID", AlertIDSqlParameter, EmployeeCodeSqlParameter, CDPContactIDSqlParameter, OffsetSqlParameter, SprintIDSqlParameter).SingleOrDefault

            Catch ex As Exception
                Alert = Nothing
            End Try

            Return Alert

        End Function
        Public Function LoadAlertSettings() As AdvantageFramework.ViewModels.Desktop.AlertSettingsViewModel

            Dim AlertSettings As New AdvantageFramework.ViewModels.Desktop.AlertSettingsViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                LoadAppVars(DbContext, AlertSettings.AutoClose,
                                       AlertSettings.WidgetLayout,
                                       AlertSettings.HideSystemComments,
                                       AlertSettings.DetailsExpanded,
                                       AlertSettings.ShowChecklistsOnCards,
                                       AlertSettings.UploadDocumentManager)

            End Using

            Return AlertSettings

        End Function
        Public Function LoadAlert(ByVal AlertID As Integer, Optional ByVal CDPContactID As Integer = 0, Optional ByVal Offset As Decimal = 0, Optional ByVal SprintID As Integer = 0) As AdvantageFramework.DTO.Desktop.Alert

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                LoadAlert = LoadAlert(DbContext, AlertID, CDPContactID, Offset, SprintID)

            End Using

        End Function
        Public Function SaveAssignment(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As Boolean

            'objects
            Dim AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
            Dim SprintDetail As AdvantageFramework.Database.Entities.SprintDetail = Nothing
            Dim CurrentBoardDetail As AdvantageFramework.Database.Entities.BoardDetail = Nothing
            Dim NewBoardDetail As AdvantageFramework.Database.Entities.BoardDetail = Nothing
            Dim TaskAssignmentCards As Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard) = Nothing
            Dim HasVersion As Boolean = False
            Dim OldVersionID As Integer = Nothing
            Dim SelectedVersionID As Integer = Nothing
            Dim OldBuildID As Integer = Nothing
            Dim SelectedBuildID As Integer = Nothing
            Dim Saved As Boolean = False
            Dim SprintDetailSequenceNumber As Integer? = Nothing
            Dim IsChangingColumns As Boolean = False
            Dim CurrentAlertBoardStateID As Integer = 0
            Dim CurrentBoardColumnID As Integer = 0
            Dim NewBoardColumnID As Integer = 0
            Dim IsCompleting As Boolean = False
            Dim StartDueChanged As Boolean = False
            Dim HoursChanged As Boolean = False
            Dim UpdateSprint As Boolean = False
            Dim UpdateDays As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID)

                    If AlertEntity IsNot Nothing Then

                        If (AlertEntity.AssignmentCompleted Is Nothing OrElse AlertEntity.AssignmentCompleted = False) AndAlso
                            Alert.CompletedDate IsNot Nothing Then

                            IsCompleting = True

                        End If

                        If AlertEntity.BoardStateID <> Alert.BoardStateID AndAlso UpdateSprint = False Then UpdateSprint = True
                        If AlertEntity.BoardStateID IsNot Nothing Then CurrentAlertBoardStateID = AlertEntity.BoardStateID

                        If AlertEntity.Subject <> Alert.Subject AndAlso UpdateSprint = False Then UpdateSprint = True
                        AlertEntity.Subject = Alert.Subject
                        AlertEntity.Body = If(String.IsNullOrWhiteSpace(Alert.EmailBody) = True, "", Alert.EmailBody)
                        AlertEntity.EmailBody = If(String.IsNullOrWhiteSpace(Alert.EmailBody) = True, "", Alert.EmailBody)

                        If AlertEntity.PriorityLevel <> Alert.PriorityLevel AndAlso UpdateSprint = False Then UpdateSprint = True
                        AlertEntity.PriorityLevel = Alert.PriorityLevel

                        Try

                            If AlertEntity.StartDate <> Alert.StartDate OrElse AlertEntity.DueDate <> Alert.DueDate Then

                                StartDueChanged = True

                            End If

                        Catch ex As Exception
                        End Try
                        Try

                            If Alert.IsTask Then

                                If Alert.JobHours IsNot Nothing And Alert.HoursAllowed IsNot Nothing AndAlso AlertEntity.HoursAllowed Is Nothing Then

                                    HoursChanged = True

                                ElseIf Alert.JobHours Is Nothing And Alert.HoursAllowed Is Nothing AndAlso AlertEntity.HoursAllowed IsNot Nothing Then

                                    HoursChanged = True

                                ElseIf Alert.JobHours IsNot Nothing And Alert.HoursAllowed IsNot Nothing AndAlso AlertEntity.HoursAllowed IsNot Nothing Then

                                    If Alert.HoursAllowed <> AlertEntity.HoursAllowed Then

                                        HoursChanged = True

                                    End If

                                End If

                            Else

                                If Alert.HoursAllowed IsNot Nothing AndAlso AlertEntity.HoursAllowed Is Nothing Then

                                    HoursChanged = True

                                ElseIf Alert.HoursAllowed Is Nothing AndAlso AlertEntity.HoursAllowed IsNot Nothing Then

                                    HoursChanged = True

                                ElseIf Alert.HoursAllowed IsNot Nothing AndAlso AlertEntity.HoursAllowed IsNot Nothing Then

                                    If Alert.HoursAllowed <> AlertEntity.HoursAllowed Then

                                        HoursChanged = True

                                    End If

                                End If

                            End If

                        Catch ex As Exception
                        End Try
                        If HoursChanged = True Then

                            AlertEntity.HoursAllowed = Alert.HoursAllowed

                        End If

                        If Alert.IsTask AndAlso (AlertEntity.StartDate <> Alert.StartDate OrElse AlertEntity.DueDate <> Alert.DueDate) Then
                            UpdateDays = True
                        End If

                        If AlertEntity.StartDate <> Alert.StartDate AndAlso UpdateSprint = False Then UpdateSprint = True
                        AlertEntity.StartDate = Alert.StartDate

                        If AlertEntity.DueDate <> Alert.DueDate AndAlso UpdateSprint = False Then UpdateSprint = True
                        AlertEntity.DueDate = Alert.DueDate

                        If AlertEntity.TimeDue <> Alert.TimeDue AndAlso UpdateSprint = False Then UpdateSprint = True
                        AlertEntity.TimeDue = Alert.TimeDue

                        AlertEntity.AlertCategoryID = Alert.AlertCategoryID

                        If Alert.BoardStateID IsNot Nothing AndAlso Alert.BoardStateID <= 0 Then Alert.BoardStateID = Nothing
                        If AlertEntity.BoardStateID <> Alert.BoardStateID AndAlso UpdateSprint = False Then UpdateSprint = True
                        AlertEntity.BoardStateID = Alert.BoardStateID

                        If AlertEntity.BoardStateID Is Nothing OrElse AlertEntity.BoardStateID = -1 Then AlertEntity.BacklogSequenceNumber = Nothing

                        AlertEntity.IsDraft = False

                        If Not AlertEntity.TaskSequenceNumber.HasValue Then AlertEntity.HoursAllowed = Alert.HoursAllowed

                        'If Alert.BoardHeaderID Is Nothing Then Alert.BoardHeaderID = 0
                        'If Alert.BoardStateID Is Nothing Then Alert.BoardStateID = 0
                        'If AlertEntity.BoardStateID Is Nothing Then Alert.BoardStateID = 0

                        If AlertEntity.BoardStateID IsNot Nothing AndAlso AlertEntity.BoardStateID > 0 Then

                            If Alert.SprintID Is Nothing Then Alert.SprintID = 0

                            Try

                                If Alert.SprintID IsNot Nothing AndAlso Alert.SprintID > 0 Then

                                    SprintDetail = (From SprintDtl In AdvantageFramework.Database.Procedures.SprintDetail.LoadBySprintID(DbContext, Alert.SprintID)
                                                    Where SprintDtl.AlertID = Alert.ID
                                                    Select SprintDtl).FirstOrDefault

                                End If

                            Catch ex As Exception
                                SprintDetail = Nothing
                            End Try

                            If SprintDetail Is Nothing Then

                                Try

                                    SprintDetail = AdvantageFramework.Database.Procedures.SprintDetail.LoadBySprintIDAlertID(DbContext, Alert.SprintID, Alert.ID)

                                Catch ex As Exception
                                    SprintDetail = Nothing
                                End Try

                            End If
                            If Alert.BoardHeaderID IsNot Nothing AndAlso Alert.BoardHeaderID > 0 AndAlso Alert.BoardStateID IsNot Nothing AndAlso Alert.BoardStateID > 0 Then

                                NewBoardDetail = AdvantageFramework.Database.Procedures.BoardDetail.LoadByBoardHeaderIDandStateID(DbContext, Alert.BoardHeaderID, Alert.BoardStateID)

                            End If
                            If CurrentAlertBoardStateID > 0 Then

                                CurrentBoardDetail = AdvantageFramework.Database.Procedures.BoardDetail.LoadByBoardHeaderIDandStateID(DbContext, Alert.BoardHeaderID, CurrentAlertBoardStateID)

                            End If
                            If SprintDetail Is Nothing AndAlso Alert.SprintID IsNot Nothing AndAlso Alert.SprintID > 0 Then

                                If AlertEntity.BoardStateID IsNot Nothing AndAlso AlertEntity.BoardStateID > 0 Then

                                    SprintDetail = New Database.Entities.SprintDetail
                                    SprintDetail.SprintHeaderID = Alert.SprintID
                                    SprintDetail.AlertID = Alert.ID

                                    AdvantageFramework.Database.Procedures.SprintDetail.Insert(DbContext, SprintDetail)

                                End If

                            End If
                            If SprintDetail IsNot Nothing AndAlso Alert.BoardStateID Is Nothing Then

                                If AdvantageFramework.Database.Procedures.SprintDetail.Delete(DbContext, SprintDetail) Then

                                    SprintDetail = Nothing

                                End If

                            End If
                            If CurrentBoardDetail IsNot Nothing Then CurrentBoardColumnID = CurrentBoardDetail.BoardColumnID
                            If NewBoardDetail IsNot Nothing Then NewBoardColumnID = NewBoardDetail.BoardColumnID
                            If NewBoardColumnID <> CurrentBoardColumnID Then IsChangingColumns = True
                            If IsChangingColumns Then

                                If NewBoardDetail IsNot Nothing Then

                                    TaskAssignmentCards = AdvantageFramework.ProjectManagement.Agile.LoadBoardTaskAssignmentCards(DbContext, Alert.SprintID, Session.UserCode, AdvantageFramework.ProjectManagement.Agile.Methods.BacklogSort.None).ToList

                                    Try

                                        SprintDetailSequenceNumber = (From Item In TaskAssignmentCards
                                                                      Where Item.BoardColumnID = NewBoardColumnID AndAlso
                                                                            Item.AlertID <> Alert.ID
                                                                      Select Item.SequenceNumber.GetValueOrDefault(0)).Max() + 1

                                    Catch ex As Exception
                                    End Try

                                End If

                                Try

                                    If SprintDetailSequenceNumber = 0 Then SprintDetailSequenceNumber = Nothing

                                Catch ex As Exception
                                    SprintDetailSequenceNumber = Nothing
                                End Try

                            End If

                            If SprintDetail IsNot Nothing Then

                                If IsChangingColumns = True AndAlso SprintDetail.SequenceNumber Is Nothing Then

                                    SprintDetail.SequenceNumber = SprintDetailSequenceNumber

                                End If
                                If SprintDetail.AlertID IsNot Nothing AndAlso SprintDetail.AlertID > 0 Then

                                    If IsChangingColumns Then

                                        AdvantageFramework.ProjectManagement.Agile.MoveBoardItem(Me.Session, Alert.BoardStateID, SprintDetail, CurrentBoardColumnID)

                                    End If

                                End If

                                AdvantageFramework.Database.Procedures.SprintDetail.Update(DbContext, SprintDetail)

                            End If

                        Else

                            Try

                                If Alert.SprintID IsNot Nothing AndAlso Alert.SprintID > 0 Then

                                    SprintDetail = (From SprintDtl In AdvantageFramework.Database.Procedures.SprintDetail.LoadBySprintID(DbContext, Alert.SprintID)
                                                    Where SprintDtl.AlertID = Alert.ID
                                                    Select SprintDtl).FirstOrDefault

                                End If

                            Catch ex As Exception
                                SprintDetail = Nothing
                            End Try
                            If SprintDetail Is Nothing Then

                                Try

                                    SprintDetail = AdvantageFramework.Database.Procedures.SprintDetail.LoadBySprintIDAlertID(DbContext, Alert.SprintID, Alert.ID)

                                Catch ex As Exception
                                    SprintDetail = Nothing
                                End Try

                            End If
                            If AdvantageFramework.Database.Procedures.SprintDetail.Delete(DbContext, SprintDetail) Then

                                SprintDetail = Nothing

                            End If

                        End If

                        If Not String.IsNullOrWhiteSpace(Alert.Version) AndAlso IsNumeric(Alert.Version) Then SelectedVersionID = CInt(Alert.Version)
                        If Not String.IsNullOrWhiteSpace(AlertEntity.Version) AndAlso IsNumeric(AlertEntity.Version) Then OldVersionID = CInt(AlertEntity.Version)

                        If OldVersionID <> SelectedVersionID Then

                            If SelectedVersionID > 0 Then

                                AlertEntity.Version = SelectedVersionID.ToString

                            Else

                                AlertEntity.Version = ""

                            End If

                        End If
                        If OldVersionID > 0 OrElse SelectedVersionID > 0 Then

                            HasVersion = True

                        End If
                        If HasVersion Then

                            If Not String.IsNullOrWhiteSpace(Alert.Build) AndAlso IsNumeric(Alert.Build) Then

                                SelectedBuildID = CInt(Alert.Build)

                            End If

                            If Not String.IsNullOrWhiteSpace(AlertEntity.Build) AndAlso IsNumeric(AlertEntity.Build) Then

                                OldBuildID = CInt(AlertEntity.Build)

                            End If

                            If OldBuildID <> SelectedBuildID Then

                                If SelectedBuildID > 0 Then

                                    AlertEntity.Build = SelectedBuildID.ToString

                                Else

                                    AlertEntity.Build = ""

                                End If

                            End If

                        Else

                            AlertEntity.Build = ""

                        End If

                        If HoursChanged = True Then

                            UpdateRecipientHours(DbContext, AlertEntity.ID, AlertEntity.HoursAllowed, "")

                        End If

                        Saved = AdvantageFramework.Database.Procedures.Alert.Update(DbContext, AlertEntity)

                        If Saved = True Then

                            If Alert.IsWorkItem = True AndAlso Alert.TaskSequenceNumber.HasValue AndAlso Alert.AlertLevel = "BRD" Then

                                JobComponentTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, AlertEntity.JobNumber, AlertEntity.JobComponentNumber, AlertEntity.TaskSequenceNumber)

                                If JobComponentTask IsNot Nothing Then

                                    If JobComponentTask.CompletedDate Is Nothing AndAlso Alert.CompletedDate IsNot Nothing Then

                                        IsCompleting = True

                                    End If
                                    If String.IsNullOrWhiteSpace(Alert.TaskFunctionComment) = False Then

                                        JobComponentTask.Comment = Alert.TaskFunctionComment

                                    Else

                                        JobComponentTask.Comment = Nothing

                                    End If
                                    JobComponentTask.StartDate = Alert.StartDate
                                    JobComponentTask.DueDate = Alert.DueDate
                                    JobComponentTask.DueTime = Alert.TimeDue

                                    If UpdateDays = True Then
                                        Try
                                            Dim daysdiff As Integer = 0
                                            Dim wkenddays As Integer = 0

                                            daysdiff = CDate(Alert.DueDate).Date.Subtract(CDate(Alert.StartDate).Date).Days

                                            For i As Integer = 1 To daysdiff
                                                If CDate(Alert.StartDate).Date.AddDays(i).DayOfWeek = DayOfWeek.Sunday Then
                                                    wkenddays += 1
                                                End If
                                                If CDate(Alert.StartDate).Date.AddDays(i).DayOfWeek = DayOfWeek.Saturday Then
                                                    wkenddays += 1
                                                End If
                                            Next

                                            JobComponentTask.Days = daysdiff + 1 - wkenddays

                                        Catch ex As Exception

                                        End Try
                                    End If

                                    If IsCompleting = False Then

                                        JobComponentTask.CompletedDate = Alert.CompletedDate

                                    End If
                                    JobComponentTask.StatusCode = Alert.TaskStatusCode
                                    If AdvantageFramework.Database.Procedures.JobComponentTask.Update(DbContext, JobComponentTask) = True Then

                                        If IsCompleting = True Then

                                            If Me.CompleteAlert(AlertEntity).Success = True Then

                                                If AdvantageFramework.ProjectSchedule.CompleteTask(DbContext, JobComponentTask, Me.Session.User.EmployeeCode, False) = True Then

                                                    JobComponentTask.CompletedDate = Alert.CompletedDate
                                                    AdvantageFramework.Database.Procedures.JobComponentTask.Update(DbContext, JobComponentTask)

                                                End If

                                            End If

                                            UpdateSprint = True

                                        End If

                                    End If

                                End If

                            End If

                            'If Alert.IsWorkItem = True Then

                            '    Dim StateChanged As Boolean = False
                            '    Dim AssigneesChanged As Boolean = False

                            '    AdvantageFramework.AlertSystem.AssignmentHasAssignmentChanges(DbContext, Alert, AlertEntity, StateChanged, AssigneesChanged)

                            'End If

                        End If

                        If StartDueChanged = True Then

                            Dim BackgroundWork As New AdvantageFramework.ProjectManagement.Agile.Classes.WorkItemAsync(Me.Session)
                            BackgroundWork.AlertID = Alert.ID
                            BackgroundWork.CheckSprintEmployeeRecordsWithCheck()

                        End If

                        AdvantageFramework.Controller.ProjectManagement.AgileController.AddSprintEmployeeRecords(DbContext, Alert.ID)

                    End If

                End Using

            Catch ex As Exception
                Saved = False
            Finally
                SaveAssignment = Saved
            End Try

        End Function
        Public Function CreateAssignment(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert,
                                         ByVal TakeOutOfDraftStatus As Boolean,
                                         ByVal UploadToRepository As Boolean,
                                         ByVal UploadToProofHQ As Boolean,
                                         Optional ByRef Message As String = "") As Boolean

            'objects
            Dim AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Errors As Generic.List(Of String) = New Generic.List(Of String)
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
            Dim Task As AdvantageFramework.Database.Entities.Task = Nothing
            Dim SprintDetail As AdvantageFramework.Database.Entities.SprintDetail = Nothing
            Dim Created As Boolean = False
            Dim IsBoardTask As Boolean = False
            Dim IsNewAssignment As Boolean = False
            Dim IsRouted As Boolean = False
            Dim DocumentErrorMessage As String = String.Empty
            'Dim AlertTemplate As AdvantageFramework.Database.Entities.AlertAssignmentTemplate = Nothing
            Dim MultiRouteTemplate As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If String.IsNullOrWhiteSpace(Alert.Subject) Then

                        Errors.Add("Please enter a subject.")

                    End If
                    If Alert.StartDate.HasValue AndAlso Alert.DueDate.HasValue Then

                        If Alert.StartDate.Value.Date > Alert.DueDate.Value.Date Then

                            Errors.Add("Due date is before start date.")

                        End If

                    End If
                    If Alert.AlertTypeID <= 0 Then

                        Errors.Add("Please select a type.")

                    End If
                    If Alert.JobNumber.GetValueOrDefault(0) > 0 AndAlso Alert.JobComponentNumber.GetValueOrDefault(0) > 0 AndAlso Alert.AlertCategoryID = 71 Then

                        If AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, Alert.JobNumber, Alert.JobComponentNumber) Is Nothing Then

                            Errors.Add("Cannot add task because the schedule has not been created.")

                        End If

                    End If
                    If Errors.Count = 0 Then

                        IsBoardTask = IsBoardTaskAlert(Alert.AlertCategoryID)

                        If Not IsBoardTask Then

                            If Alert.ID > 0 Then

                                AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID)

                            Else

                                AlertEntity = New AdvantageFramework.Database.Entities.Alert
                                IsNewAssignment = True

                            End If
                            If (Alert.AlertAssignmentTemplateID IsNot Nothing AndAlso Alert.AlertAssignmentTemplateID > 0) AndAlso
                                   (Alert.AlertStateID IsNot Nothing AndAlso Alert.AlertStateID > 0) Then

                                IsRouted = True
                                AlertEntity.AlertAssignmentTemplateID = Alert.AlertAssignmentTemplateID
                                AlertEntity.AlertStateID = Alert.AlertStateID

                            End If
                            If AlertEntity IsNot Nothing Then

                                If Not String.IsNullOrWhiteSpace(Alert.OfficeCode) Then AlertEntity.OfficeCode = Alert.OfficeCode
                                If Not String.IsNullOrWhiteSpace(Alert.ClientCode) Then AlertEntity.ClientCode = Alert.ClientCode
                                If Not String.IsNullOrWhiteSpace(Alert.DivisionCode) Then AlertEntity.DivisionCode = Alert.DivisionCode
                                If Not String.IsNullOrWhiteSpace(Alert.ProductCode) Then AlertEntity.ProductCode = Alert.ProductCode

                                If Alert.JobNumber.GetValueOrDefault(0) > 0 Then

                                    AlertEntity.JobNumber = Alert.JobNumber

                                    If Alert.JobComponentNumber.GetValueOrDefault(0) > 0 Then AlertEntity.JobComponentNumber = Alert.JobComponentNumber
                                    If Alert.TaskSequenceNumber.GetValueOrDefault(-1) > -1 Then AlertEntity.TaskSequenceNumber = Alert.TaskSequenceNumber

                                    If String.IsNullOrWhiteSpace(AlertEntity.OfficeCode) OrElse
                                        String.IsNullOrWhiteSpace(AlertEntity.ClientCode) OrElse
                                        String.IsNullOrWhiteSpace(AlertEntity.DivisionCode) OrElse
                                        String.IsNullOrWhiteSpace(AlertEntity.ProductCode) Then

                                        With AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, AlertEntity.JobNumber)

                                            AlertEntity.OfficeCode = .OfficeCode
                                            AlertEntity.ClientCode = .ClientCode
                                            AlertEntity.DivisionCode = .DivisionCode
                                            AlertEntity.ProductCode = .ProductCode

                                        End With

                                    End If

                                End If
                                If Not String.IsNullOrWhiteSpace(Alert.Version) AndAlso IsNumeric(Alert.Version) Then

                                    If LoadSoftwareVersionsByJobComponent(AlertEntity.JobNumber.GetValueOrDefault(0), AlertEntity.JobComponentNumber.GetValueOrDefault(0), CInt(AlertEntity.Version)).Where(Function(jv) jv.ID = CInt(Alert.Version)).Any Then

                                        AlertEntity.Version = Alert.Version

                                        If LoadSoftwareBuildsByVersion(CInt(AlertEntity.Version)).Where(Function(sb) sb.ID = CInt(Alert.Build)).Any Then

                                            AlertEntity.Build = Alert.Build

                                        End If

                                    End If

                                End If
                                AlertEntity.AlertTypeID = Alert.AlertTypeID
                                AlertEntity.AlertCategoryID = Alert.AlertCategoryID
                                AlertEntity.Subject = Alert.Subject
                                AlertEntity.HoursAllowed = Alert.HoursAllowed
                                AlertEntity.Body = Alert.EmailBody
                                AlertEntity.EmailBody = Alert.EmailBody
                                AlertEntity.AssignedEmployeeEmployeeCode = Nothing
                                AlertEntity.AssignedEmployeeFullName = Nothing
                                If Alert.StartDate.HasValue Then AlertEntity.StartDate = Alert.StartDate.Value.Date
                                If Alert.DueDate.HasValue Then AlertEntity.DueDate = Alert.DueDate.Value.Date
                                If Not String.IsNullOrWhiteSpace(Alert.TimeDue) Then AlertEntity.TimeDue = Alert.TimeDue

                                AlertEntity.IsWorkItem = Alert.IsWorkItem

                                If Alert.SprintID IsNot Nothing AndAlso Alert.SprintID > 0 Then TakeOutOfDraftStatus = True

                                AlertEntity.IsDraft = False

                            End If

                        Else

                            JobComponentTask = New AdvantageFramework.Database.Entities.JobComponentTask

                            JobComponentTask.JobNumber = Alert.JobNumber
                            JobComponentTask.JobComponentNumber = Alert.JobComponentNumber
                            JobComponentTask.Hours = Alert.HoursAllowed
                            JobComponentTask.CompletedDate = Alert.CompletedDate

                            If Not String.IsNullOrWhiteSpace(Alert.TimeDue) Then

                                JobComponentTask.DueTime = Alert.TimeDue

                            End If
                            If Alert.StartDate.HasValue Then

                                JobComponentTask.StartDate = Alert.StartDate.Value.Date

                            End If
                            If Alert.DueDate.HasValue Then

                                JobComponentTask.DueDate = Alert.DueDate.Value.Date

                            End If
                            If Not String.IsNullOrWhiteSpace(Alert.TaskCode) Then

                                Task = AdvantageFramework.Database.Procedures.Task.LoadByTaskCode(DbContext, Alert.TaskCode)

                            End If
                            If Task IsNot Nothing Then

                                JobComponentTask.TaskCode = Task.Code
                                JobComponentTask.Description = Task.Description
                                JobComponentTask.FuctionCode = Task.FunctionCode

                            Else

                                JobComponentTask.Description = Alert.Subject

                            End If
                            If AdvantageFramework.Database.Procedures.JobComponentTask.Insert(DbContext, JobComponentTask) Then

                                AlertEntity = (From Item In AdvantageFramework.Database.Procedures.Alert.Load(DbContext)
                                               Where Item.JobNumber = JobComponentTask.JobNumber AndAlso
                                                     Item.JobComponentNumber = JobComponentTask.JobComponentNumber AndAlso
                                                     Item.TaskSequenceNumber = JobComponentTask.SequenceNumber
                                               Select Item).SingleOrDefault

                            End If

                        End If
                        If AlertEntity IsNot Nothing Then

                            AlertEntity.BoardStateID = Alert.BoardStateID
                            AlertEntity.GeneratedDate = Now
                            AlertEntity.LastUpdated = Now
                            AlertEntity.UserCode = Session.UserCode
                            AlertEntity.LastUpdatedUserCode = Session.UserCode
                            AlertEntity.LastUpdatedFullName = Session.EmployeeName
                            AlertEntity.PriorityLevel = Alert.PriorityLevel
                            AlertEntity.AlertLevel = Alert.AlertLevel
                            AlertEntity.EmployeeCode = Me.Session.User.EmployeeCode
                            AlertEntity.HoursAllowed = Alert.HoursAllowed

                            If JobComponentTask IsNot Nothing Then

                                AlertEntity.Body = Alert.EmailBody
                                AlertEntity.EmailBody = Alert.EmailBody

                            End If
                            If AlertEntity.ID > 0 OrElse IsBoardTask = True Then

                                Created = AdvantageFramework.Database.Procedures.Alert.Update(DbContext, AlertEntity)

                            Else

                                If AlertEntity.IsWorkItem.GetValueOrDefault(False) = True AndAlso AlertEntity.JobNumber.GetValueOrDefault(0) > 0 AndAlso AlertEntity.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                                    AlertEntity.AlertSequenceNumber = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT (ISNULL(MAX(ALERT_SEQ_NBR),0) + 1) FROM ALERT WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1};", AlertEntity.JobNumber, AlertEntity.JobComponentNumber)).SingleOrDefault

                                End If

                                Created = AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, AlertEntity)

                            End If

                        End If
                        If Created = True Then

                            Try

                                If AlertEntity.AlertAssignmentTemplateID IsNot Nothing AndAlso AlertEntity.AlertAssignmentTemplateID > 0 AndAlso
                                    AlertEntity.AlertStateID IsNot Nothing AndAlso AlertEntity.AlertStateID > 0 Then

                                    Dim ErrorMessage As String = String.Empty

                                    If AdvantageFramework.AlertSystem.SaveTemplateToAssignment(DbContext,
                                                                                               AlertEntity.ID,
                                                                                               AlertEntity.AlertAssignmentTemplateID,
                                                                                               ErrorMessage) = False Then

                                        Errors.Add(ErrorMessage)

                                    End If

                                End If

                            Catch ex As Exception
                            End Try

                            Alert.ID = AlertEntity.ID

                            If Alert.UploadedFiles IsNot Nothing AndAlso Alert.UploadedFiles.Count > 0 Then

                                SaveAttachments(AlertEntity, Alert.UploadedFiles, UploadToRepository, UploadToProofHQ, DocumentErrorMessage, Nothing)

                                If String.IsNullOrWhiteSpace(DocumentErrorMessage) = False Then

                                    Errors.Add(DocumentErrorMessage)

                                End If

                            End If
                            If Alert.LinkedDocuments IsNot Nothing AndAlso Alert.LinkedDocuments.Count > 0 Then

                                For Each LinkedDocumentID In Alert.LinkedDocuments

                                    AddAlertAttachment(AlertEntity.ID, LinkedDocumentID)

                                Next

                            End If
                            If Alert.BoardStateID IsNot Nothing AndAlso Alert.BoardStateID > 0 Then

                                If Alert.SprintID IsNot Nothing AndAlso Alert.SprintID > 0 Then

                                    Try

                                        SprintDetail = AdvantageFramework.Database.Procedures.SprintDetail.LoadBySprintIDAlertID(DbContext, Alert.SprintID, AlertEntity.ID)

                                    Catch ex As Exception
                                        SprintDetail = Nothing
                                    End Try

                                End If
                                If SprintDetail Is Nothing AndAlso Alert.BoardStateID IsNot Nothing AndAlso Alert.BoardStateID > 0 Then

                                    SprintDetail = New Database.Entities.SprintDetail
                                    SprintDetail.SprintHeaderID = Alert.SprintID
                                    SprintDetail.AlertID = AlertEntity.ID

                                    Try

                                        SprintDetail.SequenceNumber = (From Item In AdvantageFramework.Database.Procedures.SprintDetail.LoadBySprintID(DbContext, SprintDetail.SprintHeaderID)
                                                                       Where Item.SequenceNumber IsNot Nothing
                                                                       Select Item.SequenceNumber).Max + 1

                                    Catch ex As Exception
                                        SprintDetail.SequenceNumber = Nothing
                                    End Try
                                    If AdvantageFramework.Database.Procedures.SprintDetail.Insert(DbContext, SprintDetail) Then

                                        AdvantageFramework.ProjectManagement.Agile.MoveBoardItem(Me.Session, Alert.BoardStateID, SprintDetail, -1)

                                    End If

                                Else

                                    If AdvantageFramework.ProjectManagement.Agile.MoveBoardItem(Me.Session, Alert.BoardStateID, SprintDetail, -1) Then

                                        If Alert.BoardStateID Is Nothing OrElse Alert.BoardStateID <= 0 Then

                                            If AdvantageFramework.Database.Procedures.SprintDetail.Delete(DbContext, SprintDetail) Then

                                                SprintDetail = Nothing

                                            End If

                                        End If

                                    End If

                                End If

                            End If

                            If Alert.Assignees IsNot Nothing AndAlso Alert.Assignees.Count > 0 Then

                                If IsRouted = False Then

                                    For Each AssigneeEmployeeCode In Alert.Assignees

                                        AdvantageFramework.AlertSystem.AddAssignee(DbContext, Me.Session, AlertEntity, AssigneeEmployeeCode, Nothing, Nothing)

                                    Next

                                Else

                                    AdvantageFramework.AlertSystem.ProcessAssignees(DbContext, Alert, Alert.Assignees.ToList, True, True, Message)

                                End If

                                If AlertEntity.HoursAllowed IsNot Nothing Then

                                    UpdateRecipientHours(DbContext, AlertEntity.ID, AlertEntity.HoursAllowed, "")

                                End If

                            Else

                                AddUnAssignedComment(DbContext, AlertEntity, "")

                            End If

                            If Alert.Recipients IsNot Nothing AndAlso Alert.Recipients.Count > 0 Then

                                For Each RecipientEmployeeCode In Alert.Recipients

                                    If RecipientEmployeeCode.StartsWith("CC|") = False Then

                                        AddRecipient(DbContext, AlertEntity, RecipientEmployeeCode, "")

                                    Else

                                        AddClientContactRecipient(DbContext, AlertEntity, CType(RecipientEmployeeCode.Replace("CC|", ""), Integer))

                                    End If

                                Next


                            End If

                            'If IsNewAssignment = True AndAlso IsRouted = True AndAlso MultiRouteTemplate = False Then

                            '    Try

                            '        'AddAutoComment(DbContext, AlertEntity.ID, AlertEntity.AssignedEmployeeEmployeeCode, 0, AlertEntity.AlertAssignmentTemplateID, AlertEntity.AlertStateID)
                            '        Dim Comment As AdvantageFramework.Database.Entities.AlertComment = Nothing
                            '        Dim AlertState As AdvantageFramework.Database.Entities.AlertState = Nothing
                            '        Dim MyDate As DateTime = Now

                            '        Comment = New Database.Entities.AlertComment
                            '        AlertState = AdvantageFramework.Database.Procedures.AlertState.LoadByAlertStateID(DbContext, AlertEntity.AlertStateID)

                            '        If AlertState IsNot Nothing Then

                            '            Comment.AlertID = AlertEntity.ID
                            '            Comment.UserCode = DbContext.UserCode
                            '            Comment.GeneratedDate = MyDate
                            '            Comment.AlertAssignmentTemplateID = AlertEntity.AlertAssignmentTemplateID
                            '            Comment.AlertStateID = AlertEntity.AlertStateID

                            '            If String.IsNullOrWhiteSpace(AlertEntity.AssignedEmployeeEmployeeCode) = False Then

                            '                Comment.AssignedEmployeeCode = AlertEntity.AssignedEmployeeEmployeeCode
                            '                Comment.Comment = String.Format("{0} | {1} |", AlertState.Name.ToUpper, AlertEntity.AssignedEmployeeFullName)

                            '            Else

                            '                Comment.Comment = String.Format("{0} | {1} |", AlertState.Name.ToUpper, "Unassigned")

                            '            End If

                            '            Comment.HasEmailBeenSent = False
                            '            Comment.CustodyStart = MyDate

                            '        End If

                            '        'Hack...assign info won't save??!!?!?!?!?!?!
                            '        If AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, Comment) = True Then

                            '            Try

                            '                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE ALERT_COMMENT SET ALRT_NOTIFY_HDR_ID = {0}, ALERT_STATE_ID = {1} WHERE COMMENT_ID = {2};",
                            '                                                                   AlertEntity.AlertAssignmentTemplateID, AlertEntity.AlertStateID, Comment.ID))

                            '            Catch ex As Exception
                            '            End Try

                            '        End If

                            '    Catch ex As Exception
                            '    End Try

                            'End If

                        End If

                    End If

                End Using

            Catch ex As Exception
                Created = False
                Errors.Add("There was a problem creating the alert. Please contact software support.")
            Finally
                If Errors.Count > 0 Then Message = String.Join(vbNewLine, Errors)
                CreateAssignment = Created
            End Try

        End Function
        Public Function LoadAlertComments(ByVal AlertID As Integer,
                                          ByVal DocumentID As Integer?,
                                          ByVal HideSystemComments As Boolean?,
                                          ByVal IsClientPortal As Boolean?) As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertComment)

            'objects
            Dim AllComments As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertComment) = Nothing
            Dim AlertComments As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertComment) = Nothing
            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim DocumentIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim OffsetSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim HideSystemCommentsSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim Offset As Decimal = 0

            AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_ID", AlertID)
            DocumentIDSqlParameter = New System.Data.SqlClient.SqlParameter("@DOCUMENT_ID", DocumentID)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If IsClientPortal = True Then

                    Try

                        EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@EMP_CODE", "")
                        Offset = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, String.Empty)

                    Catch ex As Exception
                    End Try

                Else

                    Try

                        EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@EMP_CODE", Me.Session.User.EmployeeCode)
                        Offset = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, Me.Session.User.EmployeeCode)

                    Catch ex As Exception
                    End Try

                End If

                Try

                    If HideSystemComments Is Nothing OrElse HideSystemComments = False Then

                        HideSystemComments = GetShowHideSystemComments(DbContext)

                    End If

                Catch ex As Exception
                    HideSystemComments = False
                End Try

                HideSystemCommentsSqlParameter = New System.Data.SqlClient.SqlParameter("@HIDE_SYSTEM_COMMENTS", HideSystemComments)

                Try

                    OffsetSqlParameter = New System.Data.SqlClient.SqlParameter("@OFFSET", Offset)
                    AllComments = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Desktop.AlertComment)("EXEC [dbo].[advsp_alert_load_comments] @ALERT_ID, @DOCUMENT_ID, @EMP_CODE, @OFFSET, @HIDE_SYSTEM_COMMENTS;",
                                                                                                               AlertIDSqlParameter,
                                                                                                               DocumentIDSqlParameter,
                                                                                                               EmployeeCodeSqlParameter,
                                                                                                               OffsetSqlParameter,
                                                                                                               HideSystemCommentsSqlParameter).ToList

                Catch ex As Exception
                    AllComments = Nothing
                End Try

            End Using

            If AllComments IsNot Nothing Then

                AlertComments = (From Entity In AllComments
                                 Where Entity.ParentID = 0).OrderByDescending(Function(x) x.GeneratedDate).OrderByDescending(Function(x) x.CommentID).ToList()

                If AlertComments IsNot Nothing Then

                    For Each Comment As DTO.Desktop.AlertComment In AlertComments

                        FindAndAddChildren(Comment, AllComments)

                    Next

                End If

            End If

            Return AlertComments

        End Function
        Private Function FindAndAddChildren(ByRef Parent As DTO.Desktop.AlertComment,
                                            ByVal AllComments As Generic.List(Of DTO.Desktop.AlertComment)) As Boolean

            Dim HasChildren As Boolean = False
            Dim CommentID As Integer = Parent.CommentID
            Dim Children As Generic.List(Of DTO.Desktop.AlertComment) = Nothing

            Try

                Children = (From Entity In AllComments
                            Where Entity.ParentID = CommentID).OrderBy(Function(x) x.GeneratedDate).ThenBy(Function(x) x.CommentID).ToList()

                If Children IsNot Nothing AndAlso Children.Count > 0 Then

                    HasChildren = True

                    If Parent.Replies Is Nothing Then

                        Parent.Replies = New List(Of DTO.Desktop.AlertComment)

                    End If
                    For Each Child As DTO.Desktop.AlertComment In Children

                        Parent.Replies.Add(Child)

                        FindAndAddChildren(Child, AllComments)

                    Next

                End If

            Catch ex As Exception
                HasChildren = False
            End Try

            Return HasChildren

        End Function
        Public Function AddAlertMentions(ByVal AlertID As Integer,
                                             ByVal Mention As String(), ByVal SubjectMention As Integer) As Boolean

            Dim Added As Boolean = False

            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim EmpCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim DescriptionMentionSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
            EmpCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            DescriptionMentionSqlParameter = New System.Data.SqlClient.SqlParameter("@DESCRIPTION_MENTION", SqlDbType.Int)
            UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 6)

            AlertIDSqlParameter.Value = AlertID
            DescriptionMentionSqlParameter.Value = SubjectMention
            UserCodeSqlParameter.Value = Me.Session.User.UserCode

            Try
                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each Employee As String In Mention

                        EmpCodeSqlParameter.Value = Employee

                        DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_ALERT_ADD_MENTION] @ALERT_ID, @EMP_CODE, @DESCRIPTION_MENTION, @USER_CODE;",
                                                         AlertIDSqlParameter,
                                                         EmpCodeSqlParameter,
                                                         DescriptionMentionSqlParameter,
                                                         UserCodeSqlParameter)

                    Next

                End Using

                Added = True

            Catch ex As Exception
                Added = False
            End Try

            Return Added

        End Function
        Public Function AddAlertComment(ByVal AlertID As Integer, ByVal CommentID As Integer?,
                                        ByVal Comment As String,
                                        ByVal ClientContactID As Integer?,
                                        ByVal DocumentList As String,
                                        ByVal DocumentID As Integer?) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return AdvantageFramework.AlertSystem.AddAlertComment(DbContext, AlertID, CommentID, Comment, ClientContactID, DocumentList, DocumentID)

            End Using


            ''objects
            'Dim AlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing
            'Dim Added As Boolean = False
            'Dim LastAlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing

            'AlertComment = New Database.Entities.AlertComment

            'AlertComment.AlertID = AlertID
            'AlertComment.Comment = Comment
            'AlertComment.UserCode = Me.Session.UserCode
            'AlertComment.GeneratedDate = Now
            'AlertComment.HasEmailBeenSent = False
            'AlertComment.ClientContactID = ClientContactID
            'AlertComment.ParentID = CommentID

            'Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

            '    If AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, AlertComment) Then

            '        Added = True

            '        AdvantageFramework.AlertSystem.UndismissCCsByAlertID(DbContext, AlertID)

            '        If Not String.IsNullOrWhiteSpace(DocumentList) Then

            '            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ALERT_COMMENT] SET DOCUMENT_LIST = '{0}' WHERE COMMENT_ID = {1} AND ALERT_ID = {2}", DocumentList, AlertComment.ID, AlertComment.AlertID))

            '        End If

            '    End If

            'End Using

            'Return Added

        End Function
        Public Function LoadAlertRecipients(ByVal AlertID As Integer) As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient)

            'objects
            Dim AlertRecipients As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AlertRecipients = LoadAlertRecipients(DbContext, AlertID)

            End Using

            Return AlertRecipients

        End Function
        Public Function LoadAlertRecipients(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer) As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient)

            'objects
            Dim AlertRecipients As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient) = Nothing

            Try

                AlertRecipients = AdvantageFramework.AlertSystem.LoadAlertRecipients(DbContext, AlertID)

            Catch ex As Exception
            End Try

            Return AlertRecipients

        End Function
        Public Function LoadAlertHours(ByVal AlertID As Integer) As AlertHours

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return LoadAlertHours(DbContext, AlertID)

            End Using

        End Function
        Public Function LoadAlertHours(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer) As AlertHours

            Dim Hours As AlertHours = Nothing

            Try

                Hours = DbContext.Database.SqlQuery(Of AlertHours)(String.Format("EXEC [dbo].[advsp_alert_get_hours] {0};", AlertID)).SingleOrDefault

            Catch ex As Exception
                Hours = Nothing
            End Try
            If Hours IsNot Nothing Then

                Hours.HasWeeklyHours = AdvantageFramework.AlertSystem.AlertHasWeeklyHours(DbContext, AlertID)

            Else

                Hours = New AlertHours

            End If

            Return Hours

        End Function
        Public Function UpdateRecipientHours(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal AlertID As Integer,
                                             ByVal HoursAllowed As Decimal,
                                             ByVal EmployeeCode As String) As Boolean

            Dim Updated As Boolean = False


            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim HoursSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
            HoursSqlParameter = New System.Data.SqlClient.SqlParameter("@HRS_ALLOWED", SqlDbType.Decimal)
            EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)

            AlertIDSqlParameter.Value = AlertID
            HoursSqlParameter.Value = HoursAllowed

            If String.IsNullOrWhiteSpace(EmployeeCode) = True Then

                EmployeeCodeSqlParameter.Value = System.DBNull.Value

            Else

                EmployeeCodeSqlParameter.Value = EmployeeCode

            End If
            Try

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_alert_update_recipient_hours] @ALERT_ID, @HRS_ALLOWED, @EMP_CODE;",
                                                     AlertIDSqlParameter,
                                                     HoursSqlParameter,
                                                     EmployeeCodeSqlParameter)

                Updated = True

            Catch ex As Exception
                Updated = False
            End Try
            If Updated = True AndAlso String.IsNullOrWhiteSpace(EmployeeCode) = True Then

                DbContext.Database.ExecuteSqlCommand("UPDATE ALERT WITH(ROWLOCK) SET HRS_ALLOWED = @HRS_ALLOWED WHERE ALERT_ID = @ALERT_ID;",
                                                     HoursSqlParameter, AlertIDSqlParameter)

            End If

            Return Updated

        End Function
        Public Function IsMyAssignment(ByVal AlertID As Integer, ByVal EmployeeCode As String) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return IsMyAssignment(DbContext, AlertID, EmployeeCode)

            End Using

        End Function
        Public Function IsMyAssignment(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                       ByVal AlertID As Integer, ByVal EmployeeCode As String) As Boolean

            Dim MyAssignment As Boolean = False

            Try

                MyAssignment = DbContext.Database.SqlQuery(Of Boolean)(String.Format("EXEC [dbo].[advsp_alert_is_my_assignment] {0}, '{1}';", AlertID, EmployeeCode)).SingleOrDefault

            Catch ex As Exception
                MyAssignment = False
            End Try

            Return MyAssignment

        End Function
        Public Function LoadTaskDescription(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal TaskSequenceNumber As Short) As String

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return LoadTaskDescription(DbContext, JobNumber, JobComponentNumber, TaskSequenceNumber)

            End Using

        End Function
        Public Function LoadTaskDescription(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal TaskSequenceNumber As Short) As String

            Dim Description As String = String.Empty

            Try

                Description = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT FNC_COMMENTS FROM JOB_TRAFFIC_DET WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2};",
                                                                                   JobNumber, JobComponentNumber, TaskSequenceNumber)).SingleOrDefault

            Catch ex As Exception
                Description = String.Empty
            End Try

            Return Description

        End Function
        Public Function LoadAlertBody(ByVal AlertID As Integer) As String

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return LoadAlertBody(DbContext, AlertID)

            End Using

        End Function
        Public Function LoadAlertBody(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer) As String

            Dim Description As String = String.Empty
            Dim SimpleAlertBody As SimpleAlertBody = Nothing

            Try

                SimpleAlertBody = DbContext.Database.SqlQuery(Of SimpleAlertBody)(String.Format("SELECT [AlertTypeID] = ALERT_TYPE_ID, [AlertCategoryID] = ALERT_CAT_ID, [Description] = COALESCE(BODY_HTML, BODY, '') FROM ALERT WITH (NOLOCK) WHERE ALERT_ID = {0};", AlertID)).SingleOrDefault

                If SimpleAlertBody IsNot Nothing Then

                    If SimpleAlertBody.AlertTypeID = 3 OrElse SimpleAlertBody.AlertTypeID = 8 Then

                        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        If Agency IsNot Nothing Then

                            AdvantageFramework.AlertSystem.ExternalLinkToInternalLink(SimpleAlertBody.Description, Agency)

                        End If

                    End If

                End If

            Catch ex As Exception
                SimpleAlertBody = Nothing
            End Try

            Return SimpleAlertBody.Description

        End Function
        Public Function LoadAlertAttachments(ByVal SecuritySession As AdvantageFramework.Security.Session,
                                             ByVal AlertID As Integer,
                                             ByVal Offset As Decimal,
                                             ByVal IsClientPortal As Boolean) As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertAttachment)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return LoadAlertAttachments(SecuritySession, DbContext, AlertID, Offset, IsClientPortal)

            End Using

        End Function
        Public Function LoadAlertAttachments(ByVal SecuritySession As AdvantageFramework.Security.Session,
                                             ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal AlertID As Integer,
                                             ByVal Offset As Decimal,
                                             ByVal IsClientPortal As Boolean) As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertAttachment)

            'objects
            Dim AlertAttachments As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertAttachment) = Nothing
            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim OffsetSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

            Try

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

            Catch ex As Exception
                Alert = Nothing
            End Try

            If Alert IsNot Nothing Then

                AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("AlertID", AlertID)

                If IsClientPortal = False Then

                    EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("EmployeeCode", Me.Session.User.EmployeeCode)

                Else

                    EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("EmployeeCode", "")

                End If

                OffsetSqlParameter = New System.Data.SqlClient.SqlParameter("Offset", Offset)

                Try

                    AlertAttachments = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Desktop.AlertAttachment)("EXEC [dbo].[advsp_alert_attachments_get] @AlertID, @EmployeeCode, @Offset", AlertIDSqlParameter, EmployeeCodeSqlParameter, OffsetSqlParameter).ToList

                    For Each Attachment As AdvantageFramework.DTO.Desktop.AlertAttachment In AlertAttachments

                        If Attachment.ThumbnailSource IsNot Nothing Then
                            Attachment.Thumbnail = String.Format("data:{0};base64,{1}", Attachment.MIMEType.ToLower, Convert.ToBase64String(Attachment.ThumbnailSource))
                        Else
                            Attachment.Thumbnail = Nothing
                        End If


                    Next

                Catch ex As Exception
                    AlertAttachments = Nothing
                End Try

                If AlertAttachments IsNot Nothing Then

                    LoadAttachmentDisplayData(SecuritySession, Alert, AlertAttachments)

                End If

            End If

            Return AlertAttachments

        End Function
        Public Sub LoadAttachmentDisplayData(ByVal Documents As Generic.List(Of AdvantageFramework.DTO.Desktop.Document))

            For Each Document In Documents

                LoadFileDisplayData(Document.FileName, Document.FileSize, Document.MIMEType, Document.CssClass, Document.FileTypeLabel, Document.FileType, Document.AllowComments, Document.FileSizeDisplay)

            Next

        End Sub
        Public Sub LoadAttachmentDisplayData(ByVal SecuritySession As AdvantageFramework.Security.Session,
                                             ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                             ByVal AlertAttachments As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertAttachment))

            Dim ErrorMessage As String = String.Empty

            For Each AlertAttachment In AlertAttachments

                If Alert.AlertCategoryID = 79 Then

                    AlertAttachment.ProofingURL = AdvantageFramework.Web.GetProofingURL(SecuritySession, Alert.ID, AlertAttachment.DocumentID, 0, ErrorMessage)

                End If

                LoadFileDisplayData(AlertAttachment.FileName, AlertAttachment.FileSize, AlertAttachment.MIMEType, AlertAttachment.CssClass, AlertAttachment.FileTypeLabel, AlertAttachment.FileType, AlertAttachment.AllowComments, AlertAttachment.FileSizeDisplay)

            Next

        End Sub
        Private Sub LoadFileDisplayData(ByVal FileName As String,
                                        ByVal FileSize As Integer,
                                        ByVal MIMEType As String,
                                        ByRef CssClass As String,
                                        ByRef FileTypeLabel As String,
                                        ByRef FileType As String,
                                        ByRef AllowComments As Boolean, ByRef FileSizeDisplay As String)

            Select Case MIMEType

                Case "application/msword",
                          "application/vnd.openxmlformats-officedocument.word",
                          "application/vnd.openxmlformats-officedocument.wordprocessingml.document"

                    CssClass = "document-ms-word"
                    FileTypeLabel = "W"
                    FileType = "Microsoft Word"
                    AllowComments = False

                Case "application/mspowerpoint", "application/vnd.ms-powerpoint"

                    CssClass = "document-ms-powerpoint"
                    FileTypeLabel = "PP"
                    FileType = "Microsoft Powerpoint"

                Case "application/msproject", "application/vnd.ms-msproject"

                    CssClass = "document-ms-project"
                    FileTypeLabel = "PR"
                    FileType = "Microsoft Project"

                Case "application/pdf"

                    CssClass = "document-adobe-pdf"
                    FileTypeLabel = "PDF"
                    FileType = "Adobe PDF"
                    AllowComments = True

                Case "application/msexcel", "application/vnd.ms-excel", "application/vnd.openxmlformats-officedocument.spre"

                    CssClass = "document-ms-excel"
                    FileTypeLabel = "XL"
                    FileType = "Microsoft Excel"
                    AllowComments = True

                Case "image/bmp"

                    CssClass = "document-image"
                    FileTypeLabel = "BMP"
                    FileType = "Bitmap Image"
                    AllowComments = True

                Case "image/gif"

                    CssClass = "document-image"
                    FileTypeLabel = "GIF"
                    FileType = "Gif Image"
                    AllowComments = True

                Case "image/jpeg", "image/pjpeg"

                    CssClass = "document-image"
                    FileTypeLabel = "JPG"
                    FileType = "Jpeg Image"
                    AllowComments = True

                Case "image/x-png", "image/png"

                    CssClass = "document-image"
                    FileTypeLabel = "PNG"
                    FileType = "Png Image"
                    AllowComments = True

                Case "image/tiff"

                    CssClass = "document-image"
                    FileTypeLabel = "TIF"
                    FileType = "Tiff Image"
                    AllowComments = True

                Case "text/plain"

                    CssClass = "document-text"
                    FileTypeLabel = "TXT"
                    FileType = "Text file"

                Case "image/x-photoshop"

                    CssClass = "document-adobe-photoshop"
                    FileTypeLabel = "PSD"
                    FileType = "Adobe Photoshop"

                Case "application/illustrator"

                    CssClass = "document-adobe-illustrator"
                    FileTypeLabel = "AI"
                    FileType = "Adobe Illustrator"

                Case "URL"

                    CssClass = "document-url"
                    FileTypeLabel = "URL"
                    FileType = "URL hyperlink"

                Case "application/x-zip-compressed", "application/zip"

                    CssClass = "document-zip"
                    FileTypeLabel = "ZIP"
                    FileType = "Zip file"

                Case "application/vnd.ms-outlook"

                    CssClass = "document-ms-outlook"
                    FileTypeLabel = "O"
                    FileType = "Microsoft Outlook"
                    AllowComments = True

                Case Else

                    CssClass = "standard-grey"

                    If Not String.IsNullOrWhiteSpace(FileName) Then

                        If FileName.ToUpper.Contains(".MSG") Then

                            CssClass = "document-ms-outlook"
                            FileTypeLabel = "MSG"
                            FileType = "Microsoft Outlook"
                            AllowComments = True

                        ElseIf FileName.ToUpper.Contains(".DOC") Then

                            CssClass = "document-ms-word"
                            FileTypeLabel = "W"
                            FileType = "Microsoft Word"
                            AllowComments = False

                        ElseIf FileName.ToUpper.Contains(".XL") Then

                            CssClass = "document-ms-excel"
                            FileTypeLabel = "XL"
                            FileType = "Microsoft Excel"
                            AllowComments = True

                        Else

                            If FileName.Contains(".") Then

                                Try

                                    Dim ar As String()

                                    ar = FileName.Split(".")

                                    If ar IsNot Nothing And ar.Length > 0 Then

                                        FileTypeLabel = ar(ar.Length - 1).ToString.ToUpper
                                        FileType = FileTypeLabel & " file"

                                        If FileTypeLabel.Length > 3 Then

                                            FileTypeLabel = FileTypeLabel.Substring(0, 3)

                                        End If

                                    End If

                                Catch ex As Exception
                                    FileTypeLabel = "DOC"
                                    FileType = "Document"
                                End Try

                            Else

                                FileTypeLabel = "DOC"
                                FileType = "Document"

                            End If

                        End If

                    End If

            End Select

            If FileSize > 0 Then

                FileSize = FileSize / 1024

                Select Case FileSize

                    Case Is < 1

                        FileSizeDisplay = "< 1K"

                    Case 0 To 1023

                        FileSizeDisplay = FileSize.ToString("#,###") & " KB"

                    Case Is >= 1024

                        FileSizeDisplay = (FileSize / 1024).ToString("#,###") & " MB"

                End Select

            End If

        End Sub
        Public Function UploadAttachmentToProofHQ(ByVal AttachmentID As Integer) As Boolean

            'objects
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim DocumentIDs() As Integer = Nothing
            Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim ParentDocument As AdvantageFramework.Database.Entities.Document = Nothing
            Dim ParentProofHQFileID As Integer = 0
            Dim ByteFile() As Byte = Nothing
            Dim ProofHQUploaded As Boolean = False
            Dim ProofHQUrl As String = ""
            Dim ProofHQFileID As Integer = 0

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        AlertAttachment = AdvantageFramework.Database.Procedures.AlertAttachment.LoadByAlertAttachmentID(DbContext, AttachmentID)

                        If AlertAttachment IsNot Nothing Then

                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            If Agency IsNot Nothing AndAlso AlertAttachment IsNot Nothing Then

                                Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, AlertAttachment.DocumentID)

                                If Document IsNot Nothing Then

                                    Try

                                        DocumentIDs = AdvantageFramework.Database.Procedures.AlertAttachment.LoadByAlertID(DbContext, AlertAttachment.AlertID).Where(Function(Entity) Entity.DocumentID <> Document.ID).Select(Function(Entity) Entity.DocumentID).ToArray

                                    Catch ex As Exception
                                        DocumentIDs = Nothing
                                    End Try

                                    If DocumentIDs IsNot Nothing Then

                                        Try

                                            Documents = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                                         Where DocumentIDs.Any(Function(DocID) DocID = Entity.ID) AndAlso
                                                               Entity.FileName = Document.FileName
                                                         Select Entity).ToList()

                                        Catch ex As Exception
                                            Documents = Nothing
                                        End Try

                                        If Documents IsNot Nothing Then

                                            Try

                                                ParentDocument = Documents.Where(Function(Entity) Entity.ProofHQFileID.GetValueOrDefault(0) > 0).OrderBy(Function(Entity) Entity.ID).FirstOrDefault

                                            Catch ex As Exception
                                                ParentDocument = Nothing
                                            End Try

                                            If ParentDocument IsNot Nothing Then

                                                ParentProofHQFileID = ParentDocument.ProofHQFileID.GetValueOrDefault(0)

                                            End If

                                        End If

                                    End If

                                    If AdvantageFramework.FileSystem.Download(Agency, Document, ByteFile) Then

                                        If ParentProofHQFileID > 0 Then

                                            ProofHQUploaded = AdvantageFramework.ProofHQ.UploadNewVersion(DbContext, DataContext, Me.Session.User.EmployeeCode, ByteFile, ParentProofHQFileID, Document.FileName, Document.FileName, "", "", 0, ProofHQUrl, ProofHQFileID)

                                        Else

                                            ProofHQUploaded = AdvantageFramework.ProofHQ.UploadFile(DbContext, DataContext, Me.Session.User.EmployeeCode, ByteFile, Document.FileName, Document.FileName, "", "", 0, ProofHQUrl, ProofHQFileID)

                                        End If

                                        If ProofHQUploaded Then

                                            Document.ProofHQUrl = ProofHQUrl
                                            Document.ProofHQFileID = ProofHQFileID

                                            AdvantageFramework.Database.Procedures.Document.Update(DbContext, Document)

                                        End If

                                    End If

                                End If

                            End If

                        End If

                    End Using

                End Using

            Catch ex As Exception
                ProofHQUploaded = False
            Finally
                UploadAttachmentToProofHQ = ProofHQUploaded
            End Try

        End Function
        Public Function LoadSoftwareVersionsByJobComponent(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal VersionID As Integer) As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.SoftwareVersion)

            'objects
            Dim SoftwareVersions As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.SoftwareVersion) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                SoftwareVersions = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Desktop.Alert.SoftwareVersion)(String.Format("EXEC [dbo].[advsp_alert_load_software_version_by_job] {0}, {1}, {2};",
                                                                                                                                      JobNumber, JobComponentNumber, VersionID)).ToList
            End Using

            Return SoftwareVersions

        End Function
        Public Function LoadSoftwareBuildsByVersion(ByVal VersionID As Integer) As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.SoftwareBuild)

            'objects
            Dim SoftwareBuilds As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.SoftwareBuild) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                SoftwareBuilds = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Desktop.Alert.SoftwareBuild)(String.Format("EXEC [dbo].[advsp_alert_load_software_build_by_version] {0};",
                                                                                                                                  VersionID)).ToList
            End Using

            Return SoftwareBuilds

        End Function
        Public Function LoadAlertStates() As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertState)

            'objects
            Dim AlertStates As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertState) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AlertStates = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Desktop.Alert.AlertState)(String.Format("EXEC [dbo].[advsp_alert_load_active_states]")).ToList

            End Using

            Return AlertStates

        End Function
        Public Function LoadAlertTemplateStates(ByVal AlertTemplateID As Integer) As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertTemplateState)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return LoadAlertTemplateStates(DbContext, AlertTemplateID)

            End Using

        End Function
        Public Function LoadAlertTemplateStates(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertTemplateID As Integer) As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertTemplateState)

            'objects
            Dim AlertTemplateStates As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertTemplateState) = Nothing
            Dim AlertTemplateIDParameter As System.Data.SqlClient.SqlParameter = Nothing

            AlertTemplateIDParameter = New System.Data.SqlClient.SqlParameter("AlertTemplateID", AlertTemplateID)

            AlertTemplateStates = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Desktop.Alert.AlertTemplateState)("exec [dbo].[advsp_alert_template_states_get] @AlertTemplateID", AlertTemplateIDParameter).ToList

            Return AlertTemplateStates

        End Function
        Public Function LoadCurrentAlertTemplateStateEmployees(ByVal AlertID As Integer) As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertTemplateStateEmployee)

            Return _LoadAlertTemplateStateEmployees(AlertID, 0, 0, False, "", False)

        End Function
        Public Function GetAssignmentTemplate(ByVal AlertID As Integer,
                                              ByVal DocumentID As Integer,
                                              ByVal AllEmployees As Boolean,
                                              ByRef ErrorMessage As String) As AdvantageFramework.ViewModels.Desktop.AlertAssignmentViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return AdvantageFramework.AlertSystem.GetAssignmentTemplate(DbContext, AlertID, DocumentID, AllEmployees, ErrorMessage)

            End Using

        End Function
        Public Function LoadAlertTemplateStateEmployees(ByVal AlertID As Integer,
                                                        ByVal AlertTemplateID As Integer,
                                                        ByVal AlertStateID As Integer,
                                                        ByVal ShowAll As Boolean,
                                                        ByVal IncludeEmployeeCode As String,
                                                        ByVal ConceptShareOnly As Boolean) As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertTemplateStateEmployee)

            Return _LoadAlertTemplateStateEmployees(AlertID, AlertTemplateID, AlertStateID, ShowAll, IncludeEmployeeCode, ConceptShareOnly)

        End Function
        Public Function _LoadAlertTemplateStateEmployees(ByVal AlertID As Integer,
                                                         ByVal AlertTemplateID As Integer,
                                                         ByVal AlertStateID As Integer,
                                                         ByVal ShowAll As Boolean,
                                                         ByVal IncludeEmployeeCode As String,
                                                         ByVal ConceptShareOnly As Boolean) As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertTemplateStateEmployee)

            Dim AlertTemplateStateEmployees As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertTemplateStateEmployee) = Nothing

            Try

                'objects
                Dim AlertIDParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim AlertTemplateIDParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim AlertStateIDParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim ShowAllParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim IncludeEmployeeParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim ConceptShareOnlyParameter As System.Data.SqlClient.SqlParameter = Nothing

                If String.IsNullOrWhiteSpace(IncludeEmployeeCode) Then

                    IncludeEmployeeCode = ""

                End If
                If Not String.IsNullOrWhiteSpace(IncludeEmployeeCode) Then

                    If IncludeEmployeeCode.ToLower() = "unassigned" Then

                        IncludeEmployeeCode = ""

                    End If

                End If
                If AlertID = 0 Then

                    AlertIDParameter = New System.Data.SqlClient.SqlParameter("ALERT_ID", DBNull.Value)

                Else

                    AlertIDParameter = New System.Data.SqlClient.SqlParameter("ALERT_ID", AlertID)

                End If
                If AlertTemplateID = 0 Then

                    AlertTemplateIDParameter = New System.Data.SqlClient.SqlParameter("ALRT_NOTIFY_HDR_ID", DBNull.Value)

                Else

                    AlertTemplateIDParameter = New System.Data.SqlClient.SqlParameter("ALRT_NOTIFY_HDR_ID", AlertTemplateID)

                End If
                If AlertStateID = 0 Then

                    AlertStateIDParameter = New System.Data.SqlClient.SqlParameter("ALERT_STATE_ID", DBNull.Value)

                Else

                    AlertStateIDParameter = New System.Data.SqlClient.SqlParameter("ALERT_STATE_ID", AlertStateID)

                End If

                ShowAllParameter = New System.Data.SqlClient.SqlParameter("SHOW_ALL", ShowAll)
                IncludeEmployeeParameter = New System.Data.SqlClient.SqlParameter("INCLUDE_EMP", IncludeEmployeeCode)
                ConceptShareOnlyParameter = New System.Data.SqlClient.SqlParameter("CS_ONLY", ConceptShareOnly)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AlertTemplateStateEmployees = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Desktop.Alert.AlertTemplateStateEmployee)("EXEC [dbo].[advsp_alert_template_states_employees_get] @ALERT_ID, @ALRT_NOTIFY_HDR_ID, @ALERT_STATE_ID, @SHOW_ALL, @INCLUDE_EMP, @CS_ONLY;",
                                                                                                                                                  AlertIDParameter, AlertTemplateIDParameter, AlertStateIDParameter, ShowAllParameter, IncludeEmployeeParameter, ConceptShareOnlyParameter).ToList

                End Using

            Catch ex As Exception
                AlertTemplateStateEmployees = Nothing
            End Try

            'Dim Unassigned As New AdvantageFramework.DTO.Desktop.Alert.AlertTemplateStateEmployee

            'Unassigned.Code = "unassigned"
            'Unassigned.Name = "[Unassigned]"

            If AlertTemplateStateEmployees Is Nothing Then AlertTemplateStateEmployees = New List(Of DTO.Desktop.Alert.AlertTemplateStateEmployee)

            'AlertTemplateStateEmployees.Insert(0, Unassigned)

            Return AlertTemplateStateEmployees

        End Function
        Public Function LoadAlertCategories() As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertCategory)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return LoadAlertCategories(DbContext)

            End Using

        End Function
        Public Function LoadAlertCategories(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertCategory)

            'objects
            Dim AlertCategories As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertCategory) = Nothing

            AlertCategories = (From Item In DbContext.AlertCategories
                               Where Item.AlertTypeID = 6 AndAlso {28, 29, 30, 31}.Contains(Item.ID) = False
                               Let SortOrder = If(Item.ID >= 70, 1, 2)
                               Order By SortOrder, Item.Description
                               Select New AdvantageFramework.DTO.Desktop.Alert.AlertCategory With {.ID = Item.ID, .AlertTypeID = Item.AlertTypeID, .Description = Item.Description}).ToList

            Return AlertCategories

        End Function
        Public Function LoadAlertCategories(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertCategory)

            'objects
            Dim AlertCategories As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertCategory) = Nothing

            AlertCategories = LoadAlertCategories(DbContext)

            If Alert.AlertCategoryID <> 71 Then 'Task

                AlertCategories = AlertCategories.Where(Function(ac) ac.ID <> 71).ToList

            End If

            If Alert.SprintID.GetValueOrDefault(0) <= 0 Then

                AlertCategories = AlertCategories.Where(Function(ac) ac.ID <> 70 AndAlso ac.ID <> 71).ToList

            End If

            Return AlertCategories

        End Function
        Public Function LoadAvailableEmployees() As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertState)

            'objects
            Dim AlertStates As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertState) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AlertStates = (From Item In AdvantageFramework.Database.Procedures.AlertState.LoadAllActive(DbContext)
                               Order By Item.SortOrder Ascending
                               Select Item).ToList.Select(Function(item) New AdvantageFramework.DTO.Desktop.Alert.AlertState(item)).ToList

            End Using

            Return AlertStates

        End Function
        Public Function LoadBoardStates(ByVal BoardHeaderID As Integer) As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.BoardState)

            'objects
            Dim BoardStates As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.BoardState) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                LoadBoardStates = LoadBoardStates(DbContext, BoardHeaderID)

            End Using

        End Function
        Public Function LoadBoardStates(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BoardHeaderID As Integer) As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.BoardState)

            'objects
            Dim BoardStates As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.BoardState) = Nothing

            BoardStates = (From BoardDetail In AdvantageFramework.Database.Procedures.BoardDetail.LoadWithState(DbContext, BoardHeaderID)
                           Join BoardColumn In AdvantageFramework.Database.Procedures.BoardColumn.LoadByBoardID(DbContext, BoardHeaderID) On BoardDetail.BoardColumnID Equals BoardColumn.ID
                           Order By BoardColumn.SequenceNumber Ascending, BoardDetail.AlertState.Name Ascending
                           Select New AdvantageFramework.DTO.Desktop.Alert.BoardState With {.ID = BoardDetail.AlertStateID,
                                                                                            .Name = BoardDetail.AlertState.Name,
                                                                                            .SequenceNumber = BoardDetail.SequenceNumber,
                                                                                            .BoardDetailID = BoardDetail.ID,
                                                                                            .BoardColumnID = BoardDetail.BoardColumnID,
                                                                                            .BoardColumnName = BoardColumn.Name,
                                                                                            .BoardColumnSequenceNumber = BoardColumn.SequenceNumber}).OrderBy(Function(bs) bs.BoardColumnSequenceNumber).ThenBy(Function(bs) bs.SequenceNumber).ThenBy(Function(bs) bs.BoardDetailID).ToList

            LoadBoardStates = BoardStates

        End Function
        Public Function AddRecipient(ByVal AlertID As Integer, ByVal EmployeeCode As String) As Boolean

            'objects
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Added As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                    If Alert IsNot Nothing Then

                        Added = AddRecipient(DbContext, Alert, EmployeeCode, "")

                    End If

                End Using

            Catch ex As Exception
                Added = False
            Finally
                AddRecipient = Added
            End Try

        End Function
        Public Function AddRecipient(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                     ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                     ByVal EmployeeCode As String, ByVal Comment As String)

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
            Dim AlertRecipientDismissed As AdvantageFramework.Database.Entities.AlertRecipientDismissed = Nothing
            Dim Added As Boolean = False

            Try

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                If Employee IsNot Nothing Then

                    AlertRecipient = (From Item In AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertID(DbContext, Alert.ID)
                                      Where Item.EmployeeCode = EmployeeCode AndAlso
                                            Item.IsCurrentNotify <> 1
                                      Select Item).SingleOrDefault


                    AlertRecipientDismissed = (From Item In AdvantageFramework.Database.Procedures.AlertRecipientDismissed.LoadByAlertID(DbContext, Alert.ID)
                                               Where Item.EmployeeCode = EmployeeCode AndAlso
                                                     Item.IsCurrentNotify <> 1
                                               Select Item).SingleOrDefault

                    Added = AdvantageFramework.AlertSystem.AddAssigneeOrRecipient(DbContext, Alert, Employee, Alert.AlertAssignmentTemplateID, Alert.AlertStateID, AlertRecipient, AlertRecipientDismissed, False, Comment)

                End If

            Catch ex As Exception
                Added = False
            Finally
                AddRecipient = Added
            End Try

        End Function
        Public Function DeleteRecipient(ByVal AlertID As Integer, ByVal EmployeeCode As String) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return AdvantageFramework.AlertSystem.DeleteRecipient(DbContext, AlertID, EmployeeCode)

            End Using

        End Function
        Public Function DeleteClientContact(ByVal AlertID As Integer, ByVal ClientContactID As Integer) As Boolean

            Dim Deleted = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Dim ClientPortalAlertRecipient As AdvantageFramework.Database.Entities.ClientPortalAlertRecipient = Nothing
                Dim ClientPortalAlertRecipientDismissed As AdvantageFramework.Database.Entities.ClientPortalAlertRecipientDismissed = Nothing

                ClientPortalAlertRecipient = AdvantageFramework.Database.Procedures.ClientPortalAlertRecipient.LoadByAlertIDAndContactID(DbContext, AlertID, ClientContactID)
                ClientPortalAlertRecipientDismissed = AdvantageFramework.Database.Procedures.ClientPortalAlertRecipientDismissed.LoadByAlertIDAndContactID(DbContext, AlertID, ClientContactID)

                If ClientPortalAlertRecipient IsNot Nothing Then

                    Deleted = AdvantageFramework.Database.Procedures.ClientPortalAlertRecipient.Delete(DbContext, ClientPortalAlertRecipient)

                End If
                If ClientPortalAlertRecipientDismissed IsNot Nothing Then

                    Deleted = AdvantageFramework.Database.Procedures.ClientPortalAlertRecipientDismissed.Delete(DbContext, ClientPortalAlertRecipientDismissed)

                End If

            End Using

            Return Deleted

        End Function
        Public Function AddClientContactRecipient(ByVal AlertID As Integer, ByVal ClientContactID As Integer) As Boolean

            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Added As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                    If Alert IsNot Nothing Then

                        Added = AddClientContactRecipient(DbContext, Alert, ClientContactID)

                    End If

                End Using

            Catch ex As Exception
                Added = False
            Finally
                AddClientContactRecipient = Added
            End Try

        End Function
        Public Function AddClientContactRecipient(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal Alert As AdvantageFramework.Database.Entities.Alert, ByVal ClientContactID As Integer)

            'objects
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
            Dim ClientPortalAlertRecipient As AdvantageFramework.Database.Entities.ClientPortalAlertRecipient = Nothing
            Dim ClientPortalAlertRecipientDismissed As AdvantageFramework.Database.Entities.ClientPortalAlertRecipientDismissed = Nothing
            Dim Added As Boolean = False

            Try

                ClientContact = AdvantageFramework.Database.Procedures.ClientContact.LoadByContactID(DbContext, ClientContactID)

                If ClientContact IsNot Nothing Then

                    ClientPortalAlertRecipient = AdvantageFramework.Database.Procedures.ClientPortalAlertRecipient.LoadByAlertIDAndContactID(DbContext, Alert.ID, ClientContactID)
                    ClientPortalAlertRecipientDismissed = AdvantageFramework.Database.Procedures.ClientPortalAlertRecipientDismissed.LoadByAlertIDAndContactID(DbContext, Alert.ID, ClientContactID)

                    Added = AddClientContactAlertRecipient(DbContext, Alert, ClientContact, ClientPortalAlertRecipient, ClientPortalAlertRecipientDismissed, False)

                End If

            Catch ex As Exception
                Added = False
            Finally
                AddClientContactRecipient = Added
            End Try

        End Function
        Private Function AddClientContactAlertRecipient(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                       ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                                       ByVal ClientContact As AdvantageFramework.Database.Entities.ClientContact,
                                                       ByVal ClientPortalAlertRecipient As AdvantageFramework.Database.Entities.ClientPortalAlertRecipient,
                                                       ByVal ClientPortalAlertRecipientDismissed As AdvantageFramework.Database.Entities.ClientPortalAlertRecipientDismissed,
                                                       ByVal IsAssignment As Boolean) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim IsNew As Boolean = False
            Dim UserEmployeeCode As String = String.Empty
            Dim IsRoutedAssignment As Boolean = False
            Dim IsTask As Boolean = False

            Try

                If ClientContact IsNot Nothing Then

                    If Alert IsNot Nothing Then

                        Try

                            If Alert.AlertLevel = "BRD" OrElse Alert.AlertLevel = "PST" Then

                                IsTask = True

                            End If

                        Catch ex As Exception
                            IsTask = False
                        End Try

                    End If

                    If ClientPortalAlertRecipient Is Nothing Then

                        IsNew = True

                        ClientPortalAlertRecipient = New AdvantageFramework.Database.Entities.ClientPortalAlertRecipient

                        ClientPortalAlertRecipient.DbContext = DbContext
                        ClientPortalAlertRecipient.ClientContactID = ClientContact.ContactID
                        ClientPortalAlertRecipient.AlertID = Alert.ID

                        If ClientContact.GetEmails IsNot Nothing AndAlso ClientContact.GetEmails = 1 Then

                            ClientPortalAlertRecipient.EmailAddress = ClientContact.EmailAddress

                        End If

                        If ClientPortalAlertRecipientDismissed IsNot Nothing Then


                        Else

                            ClientPortalAlertRecipient.IsNewAlert = 1

                        End If

                    Else

                        ClientPortalAlertRecipient.IsNewAlert = Nothing

                    End If
                    If IsNew Then

                        Added = AdvantageFramework.Database.Procedures.ClientPortalAlertRecipient.Insert(DbContext, ClientPortalAlertRecipient)

                        If Added AndAlso ClientPortalAlertRecipientDismissed IsNot Nothing Then

                            AdvantageFramework.Database.Procedures.ClientPortalAlertRecipientDismissed.Delete(DbContext, ClientPortalAlertRecipientDismissed)

                        End If

                    Else


                        Added = AdvantageFramework.Database.Procedures.ClientPortalAlertRecipient.Update(DbContext, ClientPortalAlertRecipient)

                    End If

                End If

            Catch ex As Exception
                Added = False
            Finally
                AddClientContactAlertRecipient = Added
            End Try

        End Function
        Public Function SendAssignment(ByRef Alert As AdvantageFramework.DTO.Desktop.Alert,
                                       ByRef StateChanged As Boolean,
                                       ByRef AssigneesChanged As Boolean,
                                       ByVal AddUpdatedComment As Boolean,
                                       ByRef Message As String) As Boolean

            'objects
            Dim Sent As Boolean = False
            Dim Errors As Generic.List(Of String) = Nothing
            Dim AlertRecipients As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient) = Nothing
            Dim ErrorMessage As String = String.Empty

            Try

                Errors = New Generic.List(Of String)

                If Alert IsNot Nothing AndAlso Alert.IsWorkItem = True Then

                    If Alert.AlertAssignmentTemplateID.GetValueOrDefault(0) > 0 AndAlso Alert.AlertStateID.GetValueOrDefault(0) <= 0 Then

                        Errors.Add("Please select a State.")

                    End If
                    If Errors.Count = 0 Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            If Errors.Count = 0 Then

                                AdvantageFramework.AlertSystem.AssignmentHasAssignmentChanges(DbContext, Alert, StateChanged, AssigneesChanged)

                                If Alert.Assignees IsNot Nothing Then

                                    Sent = AdvantageFramework.AlertSystem.ProcessAssignees(DbContext, Alert, Alert.Assignees.ToList, AddUpdatedComment, False, ErrorMessage)

                                Else

                                    Dim EmptyList As New List(Of String)
                                    Sent = AdvantageFramework.AlertSystem.ProcessAssignees(DbContext, Alert, EmptyList, AddUpdatedComment, False, ErrorMessage)

                                End If

                            End If

                            AdvantageFramework.Controller.ProjectManagement.AgileController.AddSprintEmployeeRecords(DbContext, Alert.ID)

                        End Using

                    Else

                        Message = String.Join(" ", Errors)

                    End If

                Else

                    Sent = True
                    Message = String.Empty

                End If

            Catch ex As Exception
                Sent = False
            Finally

                If Not Sent AndAlso String.IsNullOrWhiteSpace(Message) Then

                    Message = "There was a problem sending the assignment. Please contact software support."

                End If

                SendAssignment = Sent

            End Try

        End Function
        Public Function AddUnAssignedComment(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                             ByVal SendAssignmentComment As String) As Boolean

            Dim Added As Boolean = False
            Dim StateName As String = String.Empty
            Dim Comment As New AdvantageFramework.Database.Entities.AlertComment
            Dim RightNow As DateTime = Now

            Try

                Comment.AlertID = Alert.ID
                Comment.UserCode = DbContext.UserCode
                Comment.GeneratedDate = RightNow
                Comment.HasEmailBeenSent = False

                Try

                    If Alert.AlertStateID IsNot Nothing AndAlso Alert.AlertStateID > 0 Then

                        StateName = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ALERT_STATE_NAME FROM ALERT_STATES WITH(NOLOCK) WHERE ALERT_STATE_ID = {0};", Alert.AlertStateID)).SingleOrDefault

                    End If

                Catch ex As Exception
                    StateName = String.Empty
                End Try

                If String.IsNullOrWhiteSpace(StateName) = False AndAlso
                    (Alert.AlertAssignmentTemplateID IsNot Nothing AndAlso Alert.AlertAssignmentTemplateID > 0) AndAlso
                    (Alert.AlertStateID IsNot Nothing AndAlso Alert.AlertStateID > 0) Then

                    If String.IsNullOrWhiteSpace(SendAssignmentComment) = False Then

                        Comment.Comment = String.Format("{0} | {1} | {2}", StateName.ToUpper, "UNASSIGNED", SendAssignmentComment)

                    Else

                        Comment.Comment = String.Format("{0} | {1}", StateName.ToUpper, "UNASSIGNED")

                    End If

                    Comment.AlertAssignmentTemplateID = Alert.AlertAssignmentTemplateID
                    Comment.AlertStateID = Alert.AlertStateID

                Else

                    If String.IsNullOrWhiteSpace(SendAssignmentComment) = False Then

                        Comment.Comment = String.Format("{0} | {1}", "UNASSIGNED", SendAssignmentComment)

                    Else

                        Comment.Comment = String.Format("{0}", "UNASSIGNED")

                    End If

                End If

                If String.IsNullOrWhiteSpace(SendAssignmentComment) = True Then

                    Comment.IsSystem = True

                End If

                Added = AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, Comment)

            Catch ex As Exception
                Added = False
            End Try

            Return Added

        End Function
        Private Function AssigneeIsInCurrentState(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal AlertID As Integer,
                                                  ByVal EmployeeCode As String) As Boolean

            Dim IsInCurrentState As Boolean = False
            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
            EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)

            AlertIDSqlParameter.Value = AlertID
            EmployeeCodeSqlParameter.Value = EmployeeCode

            Try

                IsInCurrentState = DbContext.Database.SqlQuery(Of Boolean)("EXEC [dbo].[advsp_alert_assignee_is_in_current_state] @ALERT_ID, @EMP_CODE;",
                                                                            AlertIDSqlParameter, EmployeeCodeSqlParameter).SingleOrDefault

            Catch ex As Exception
                IsInCurrentState = False
            End Try


            Return IsInCurrentState

        End Function
        Private Function ClearNonCurrentState(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal AlertID As Integer) As Boolean

            Dim StateCleared As Boolean = False
            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)

            AlertIDSqlParameter.Value = AlertID

            Try

                StateCleared = DbContext.Database.SqlQuery(Of Boolean)("EXEC [dbo].[advsp_alert_clear_noncurrent_state] @ALERT_ID;",
                                                                        AlertIDSqlParameter).SingleOrDefault

            Catch ex As Exception
                StateCleared = False
            End Try

            Return StateCleared

        End Function
        ''''Private Function SendAssignmentComment(ByVal DbContext As AdvantageFramework.Database.DbContext,
        ''''                                       ByVal EmployeeCode As String,
        ''''                                       ByVal CommentDate As DateTime,
        ''''                                       ByVal Message As String) As Boolean

        ''''    Dim Sent As Boolean = False
        ''''    Dim AlertComment As New AdvantageFramework.Database.Entities.AlertComment




        ''''    Return Sent

        ''''End Function
        Private Function AssigneeHasCommentAtCurrentState(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                          ByVal AlertID As Integer,
                                                          ByVal EmployeeCode As String) As Boolean

            Dim HasComment As Boolean = False
            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
            EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)

            AlertIDSqlParameter.Value = AlertID
            EmployeeCodeSqlParameter.Value = EmployeeCode

            Try

                HasComment = DbContext.Database.SqlQuery(Of Boolean)("EXEC [dbo].[advsp_alert_assignee_has_current_state_comment] @ALERT_ID, @EMP_CODE;",
                                                                      AlertIDSqlParameter, EmployeeCodeSqlParameter).SingleOrDefault

            Catch ex As Exception
                HasComment = False
            End Try

            Return HasComment

        End Function
        Public Function SaveNotifyAssignmentAlertRecipient(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                           ByVal AlertID As Integer, ByVal EmployeeCode As String, ByVal CommentType As Integer, ByVal AlertStateID As Integer,
                                                           ByVal AlertNotifyHeaderID As Integer, ByVal AlertComment As String, ByVal SaveUnassigned As Boolean,
                                                           ByVal IsNewAssignment As Boolean, Optional ByVal ErrorMessage As String = "") As Boolean

            Return AdvantageFramework.AlertSystem.SaveNotifyAssignmentAlertRecipient(DbContext, AlertID, EmployeeCode, CommentType, AlertStateID,
                                                                                     AlertNotifyHeaderID, AlertComment, SaveUnassigned, IsNewAssignment, ErrorMessage)

        End Function
        Public Function DoesAlertHaveBoard(ByVal AlertID As Integer) As Boolean

            Dim HasBoard As Boolean = False

            If AlertID > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        HasBoard = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT [dbo].[advfn_alert_has_board]({0});", AlertID)).SingleOrDefault

                    Catch ex As Exception
                        HasBoard = False
                    End Try

                End Using

            End If

            Return HasBoard

        End Function
        Public Function DismissAlert(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As Boolean

            'objects
            Dim AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Dismissed As Boolean = False
            Dim ForceAssignmentComplete As Boolean = False
            Dim ErrorMessage As String = ""
            Dim IsConceptShareReview As Boolean = False
            Dim Update As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID)

                Try

                    If AlertEntity.IsConceptShareReview IsNot Nothing AndAlso AlertEntity.IsConceptShareReview = True Then

                        IsConceptShareReview = True

                        If AlertEntity.AlertAssignmentTemplateID Is Nothing AndAlso AlertEntity.AlertStateID Is Nothing Then

                            Dim Recipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing

                            Recipient = AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertIDAndEmployeeCode(DbContext, AlertEntity.ID, Me.Session.User.EmployeeCode)

                            If Recipient IsNot Nothing AndAlso Recipient.IsCurrentNotify IsNot Nothing AndAlso Recipient.IsCurrentNotify = 1 Then

                                Recipient.IsCurrentNotify = Nothing
                                AdvantageFramework.Database.Procedures.AlertRecipient.Update(DbContext, Recipient)
                                ForceAssignmentComplete = False

                            End If

                        End If

                    End If

                Catch ex As Exception
                    ForceAssignmentComplete = False
                End Try

                If AlertEntity IsNot Nothing AndAlso Update = True Then

                    'If AlertEntity.IsWorkItem IsNot Nothing AndAlso AlertEntity.IsWorkItem = True Then

                    '    Dismissed = AdvantageFramework.AlertSystem.CompleteAssignment(DbContext, AlertEntity, Session.User.EmployeeCode, Session.UserCode, ErrorMessage)

                    'Else

                    Dismissed = AdvantageFramework.AlertSystem.DismissAlert(DbContext, Alert.ID, Session.User.EmployeeCode, Session.UserCode, 0, False, False, False, ErrorMessage)

                    'End If

                End If

            End Using

            Return Dismissed

        End Function
        Public Function DismissAlertAAManager(ByVal AlertID As Integer) As Boolean

            'objects
            Dim AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Dismissed As Boolean = False
            Dim ForceAssignmentComplete As Boolean = False
            Dim ErrorMessage As String = ""
            Dim IsConceptShareReview As Boolean = False
            Dim Update As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                Try

                    If AlertEntity.IsConceptShareReview IsNot Nothing AndAlso AlertEntity.IsConceptShareReview = True Then

                        IsConceptShareReview = True

                        If AlertEntity.AlertAssignmentTemplateID Is Nothing AndAlso AlertEntity.AlertStateID Is Nothing Then

                            Dim Recipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing

                            Recipient = AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertIDAndEmployeeCode(DbContext, AlertEntity.ID, Me.Session.User.EmployeeCode)

                            If Recipient IsNot Nothing AndAlso Recipient.IsCurrentNotify IsNot Nothing AndAlso Recipient.IsCurrentNotify = 1 Then

                                Recipient.IsCurrentNotify = Nothing
                                AdvantageFramework.Database.Procedures.AlertRecipient.Update(DbContext, Recipient)
                                ForceAssignmentComplete = False

                            End If

                        End If

                    End If

                Catch ex As Exception
                    ForceAssignmentComplete = False
                End Try

                If AlertEntity IsNot Nothing AndAlso Update = True Then

                    'If AlertEntity.IsWorkItem IsNot Nothing AndAlso AlertEntity.IsWorkItem = True Then

                    '    Dismissed = AdvantageFramework.AlertSystem.CompleteAssignment(DbContext, AlertEntity, Session.User.EmployeeCode, Session.UserCode, ErrorMessage)

                    'Else

                    Dismissed = AdvantageFramework.AlertSystem.DismissAlert(DbContext, AlertID, Session.User.EmployeeCode, Session.UserCode, 0, False, False, False, ErrorMessage)

                    'End If

                End If

            End Using

            Return Dismissed

        End Function
        Public Function DismissAlertCP(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As Boolean

            'objects
            Dim AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Dismissed As Boolean = False
            Dim ForceAssignmentComplete As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID)

                If AlertEntity IsNot Nothing Then

                    Dismissed = AdvantageFramework.AlertSystem.DismissAlert(DbContext, Alert.ID, "", Session.UserCode, Session.ClientPortalUser.ClientContactID, False, False, False, "")

                End If

            End Using

            Return Dismissed

        End Function
        Public Function DismissAlertComplete(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As Boolean

            'objects
            Dim AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Dismissed As Boolean = False
            Dim ErrorMessage As String = ""
            Dim CompleteResult As AdvantageFramework.AlertSystem.CompleteAssignmentResult = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID)

                If AlertEntity IsNot Nothing Then

                    If AlertEntity.IsWorkItem IsNot Nothing AndAlso AlertEntity.IsWorkItem = True Then

                        CompleteResult = AdvantageFramework.AlertSystem.CompleteAssignment(DbContext, AlertEntity, Session.User.EmployeeCode, Session.UserCode, Nothing, Nothing)

                        If CompleteResult IsNot Nothing Then Dismissed = CompleteResult.Success

                    Else

                        Dismissed = AdvantageFramework.AlertSystem.DismissAlert(DbContext, Alert.ID, Session.User.EmployeeCode, Session.UserCode, 0, True, False, False, ErrorMessage)

                    End If

                End If

            End Using

            Return Dismissed

        End Function
        Public Function DismissAlertCompleteAAManager(ByVal AlertID As Integer) As Boolean

            'objects
            Dim AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Dismissed As Boolean = False
            Dim ErrorMessage As String = ""
            Dim CompleteResult As AdvantageFramework.AlertSystem.CompleteAssignmentResult = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                If AlertEntity IsNot Nothing Then

                    If AlertEntity.IsWorkItem IsNot Nothing AndAlso AlertEntity.IsWorkItem = True Then

                        CompleteResult = AdvantageFramework.AlertSystem.CompleteAssignment(DbContext, AlertEntity, Session.User.EmployeeCode, Session.UserCode, Nothing, Nothing)

                        If CompleteResult IsNot Nothing Then Dismissed = CompleteResult.Success

                    Else

                        Dismissed = AdvantageFramework.AlertSystem.DismissAlert(DbContext, AlertID, Session.User.EmployeeCode, Session.UserCode, 0, True, False, False, ErrorMessage)

                    End If

                End If

            End Using

            Return Dismissed

        End Function
        Public Function UnDismissAlert(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As Boolean

            'objects
            Dim AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim UnDismissed As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID)

                If AlertEntity IsNot Nothing Then

                    UnDismissed = AdvantageFramework.AlertSystem.UnDismissAlert(DbContext, AlertEntity, Me.Session.User.EmployeeCode, Me.Session.UserCode)

                End If

            End Using

            Return UnDismissed

        End Function
        Public Function DoesJobHaveSchedule(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Boolean

            Dim HasSchedule As Boolean = False

            If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        Dim Schedule As AdvantageFramework.Database.Entities.JobTraffic = Nothing

                        Schedule = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                        HasSchedule = Schedule IsNot Nothing

                    Catch ex As Exception
                        HasSchedule = False
                    End Try

                End Using

            End If

            Return HasSchedule

        End Function
        Public Function ReopenAlert(ByVal AlertId As Integer) As Boolean

            'objects
            Dim AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Reopened As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertId)

                If AlertEntity IsNot Nothing Then

                    Reopened = ReopenAlert(DbContext, AlertEntity)

                End If

            End Using

            Return Reopened

        End Function
        Public Function ReopenAlert(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As Boolean

            'objects
            Dim AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Reopened As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID)

                If AlertEntity IsNot Nothing Then

                    Reopened = ReopenAlert(DbContext, AlertEntity)

                End If

            End Using

            Return Reopened

        End Function
        Public Function ReopenAlert(ByVal Alert As AdvantageFramework.Database.Entities.Alert) As Boolean

            'objects
            Dim Reopened As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Reopened = ReopenAlert(DbContext, Alert)

            End Using

            Return Reopened

        End Function
        Public Function ReopenAlert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Alert As AdvantageFramework.Database.Entities.Alert) As Boolean

            'objects
            Dim AlertIsRealAssignment As Boolean = False
            Dim Reopened As Boolean = False

            Try

                Alert.AssignmentCompleted = False

                AlertIsRealAssignment = IsAlertRealAssignment(Alert)

                If Alert.AlertLevel = "BRD" Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_alert_auto_comment] {0}, '{1}', NULL, 1, 1;", Alert.ID, Session.UserCode))
                    AdvantageFramework.ProjectSchedule.UnCompleteBoardTask(DbContext, Session.UserCode, Alert.ID, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber)

                Else

                    If Alert.IsWorkItem IsNot Nothing AndAlso Alert.IsWorkItem = True Then

                        AdvantageFramework.AlertSystem.UnCompleteAssignment(DbContext, Alert, Session.User.EmployeeCode, Session.UserCode)

                    End If

                End If

                Reopened = AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert)

            Catch ex As Exception
                Reopened = False
            Finally
                ReopenAlert = Reopened
            End Try

        End Function
        Public Function UnTempComplete(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As Boolean

            Dim TempCompleted As Boolean = False
            Dim ShowFullyCompletePrompt As Boolean = False

            TempCompleted = TempComplete(Alert, ShowFullyCompletePrompt)

            Return Not TempCompleted

        End Function
        Public Function TempComplete(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert, ByRef ShowPrompt As Boolean) As Boolean

            Dim TempCompleted As Boolean = False

            If Alert IsNot Nothing AndAlso Alert.JobNumber IsNot Nothing AndAlso
                Alert.JobComponentNumber IsNot Nothing AndAlso
                Alert.TaskSequenceNumber IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Dim FullyCompleteTask As AdvantageFramework.ProjectSchedule.LookupSettingsOptions = CType(AdvantageFramework.ProjectSchedule.CompleteTaskInsteadOfTempCompleteSetting(DbContext), Integer)
                    Dim Psc As New AdvantageFramework.Controller.ProjectManagement.ProjectScheduleController(Me.Session)

                    Select Case FullyCompleteTask
                        Case AdvantageFramework.ProjectSchedule.Methods.LookupSettingsOptions.Yes

                            If Psc.MarkTaskTempComplete(Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, Me.Session.User.EmployeeCode, TempCompleted) = True Then

                                If AdvantageFramework.ProjectSchedule.CompleteTaskInsteadOfTempComplete(DbContext, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber,
                                                                                                        Me.Session.User.EmployeeCode, False) Then
                                End If

                            End If

                        Case AdvantageFramework.ProjectSchedule.Methods.LookupSettingsOptions.Prompt

                            If Psc.MarkTaskTempComplete(Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, Me.Session.User.EmployeeCode, TempCompleted) = True Then

                                If AdvantageFramework.ProjectSchedule.CompleteTaskInsteadOfTempComplete(DbContext, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber,
                                                                                                        Me.Session.User.EmployeeCode, False) Then
                                End If

                            End If

                            ShowPrompt = True

                        Case AdvantageFramework.ProjectSchedule.Methods.LookupSettingsOptions.No

                            Psc.MarkTaskTempComplete(Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, Me.Session.User.EmployeeCode, TempCompleted)

                    End Select


                End Using

            End If

            Return TempCompleted

        End Function
        Public Function CompleteProof(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal AlertID As Integer,
                                      ByVal EmployeeCode As String) As AdvantageFramework.AlertSystem.CompleteAssignmentResult

            Dim Result As New AdvantageFramework.AlertSystem.CompleteAssignmentResult

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_proofing_complete] '{0}', {1}, '{2}';",
                                                                   Session.UserCode, AlertID, EmployeeCode))

                Result.Success = True
                Result.AssignmentFullyCompleted = True

            Catch ex As Exception
                Result.Message = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                Result.Success = False
            End Try

            Return Result

        End Function
        Public Function CompleteAlert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal Alert As AdvantageFramework.DTO.Desktop.Alert,
                                      ByRef StateChanged As Boolean,
                                      ByRef AssigneesChanged As Boolean) As AdvantageFramework.AlertSystem.CompleteAssignmentResult

            'objects
            Dim AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim CompleteResult As AdvantageFramework.AlertSystem.CompleteAssignmentResult = Nothing

            AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID)

            If AlertEntity IsNot Nothing Then

                CompleteResult = CompleteAlert(DbContext, AlertEntity)

                If CompleteResult.Success = True Then

                    AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID)

                    If AlertEntity IsNot Nothing Then

                        AdvantageFramework.AlertSystem.AssignmentHasAssignmentChanges(DbContext, Alert, AlertEntity, StateChanged, AssigneesChanged)

                    End If

                End If

            End If

            Return CompleteResult

        End Function
        Public Function CompleteAlert(ByVal Alert As AdvantageFramework.Database.Entities.Alert) As AdvantageFramework.AlertSystem.CompleteAssignmentResult

            Dim CompleteResult As AdvantageFramework.AlertSystem.CompleteAssignmentResult = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                CompleteResult = CompleteAlert(DbContext, Alert)

            End Using

            Return CompleteResult

        End Function
        Public Function CompleteAlert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal Alert As AdvantageFramework.Database.Entities.Alert) As AdvantageFramework.AlertSystem.CompleteAssignmentResult

            'objects
            Dim AlertIsRealAssignment As Boolean = False
            Dim Completed As Boolean = False
            Dim IsTask As Boolean = False
            Dim ErrorMessage As String = ""
            Dim CompleteResult As AdvantageFramework.AlertSystem.CompleteAssignmentResult = Nothing

            Try

                AlertIsRealAssignment = IsAlertRealAssignment(Alert)

                Try

                    If AlertIsRealAssignment OrElse Alert.IsWorkItem.GetValueOrDefault(False) = True Then

                        If Alert.AlertLevel = "PST" Then

                            'Old path for temp complete stuff until cleaned up
                            Completed = AdvantageFramework.AlertSystem.DismissAlert(DbContext, Alert.ID, Session.User.EmployeeCode, Session.UserCode, 0, True, False, False, ErrorMessage)

                        Else

                            CompleteResult = AdvantageFramework.AlertSystem.CompleteAssignment(DbContext, Alert, Session.User.EmployeeCode, Session.UserCode, Nothing, Nothing)

                        End If

                        ' Refresh
                        Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID)

                    Else

                        'AdvantageFramework.AlertSystem.CreateCompletedChangedComment(DbContext, Alert, Session.User.EmployeeCode)

                    End If

                Catch ex As Exception
                    Completed = False
                    ErrorMessage = ex.Message.ToString
                End Try

                If AssignmentStillHasAssignees(DbContext, Alert.ID) = False Then

                    'Alert.AssignmentCompleted = True

                    If Alert.AlertLevel = "BRD" Then

                        IsTask = True
                        AdvantageFramework.ProjectSchedule.CompleteTask(DbContext, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, Session.User.EmployeeCode, False)
                        DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_alert_auto_comment] {0}, '{1}', NULL, 1, 0;", Alert.ID, Session.UserCode))

                        'AdvantageFramework.ProjectManagement.Agile.ClearAllocatedHours(DbContext, Alert.JobNumber, Alert.JobComponentNumber,
                        'Alert.TaskSequenceNumber, Session.User.EmployeeCode, False)

                    End If

                    Completed = AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert)

                    If Completed = True AndAlso IsTask = False Then

                        'AdvantageFramework.ProjectManagement.Agile.ClearAllocatedHours(DbContext, Alert.ID, Session.User.EmployeeCode, False)

                    End If

                Else

                    Completed = True

                End If

            Catch ex As Exception
                Completed = False
                ErrorMessage = ex.Message.ToString
            Finally

            End Try

            If CompleteResult Is Nothing Then

                CompleteResult = New AdvantageFramework.AlertSystem.CompleteAssignmentResult

                If Completed = False Then

                    CompleteResult.Success = False

                    If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                        CompleteResult.Message = ErrorMessage

                    End If

                End If

            End If

            Return CompleteResult

        End Function
        Private Function AssignmentStillHasAssignees(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer) As Boolean

            Return AdvantageFramework.AlertSystem.AssignmentStillHasAssignees(DbContext, AlertID)

        End Function
        Private Function IsAlertRealAssignment(ByVal Alert As AdvantageFramework.Database.Entities.Alert) As Boolean

            Return AdvantageFramework.AlertSystem.IsAlertRealAssignment(Alert)

        End Function
        Private Function IsBoardTaskAlert(ByVal Alert As AdvantageFramework.Database.Entities.Alert) As Boolean

            Return AdvantageFramework.AlertSystem.IsBoardTaskAlert(Alert)

        End Function
        Private Function IsBoardTaskAlert(ByVal AlertCategoryID As Integer) As Boolean

            Return AdvantageFramework.AlertSystem.IsBoardTaskAlert(AlertCategoryID)

        End Function
        Public Function RemoveRecipient(ByVal AlertID As Integer, ByVal EmployeeCode As String) As Boolean

            'objects
            Dim Removed As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Removed = RemoveRecipient(DbContext, AlertID, EmployeeCode)

                End Using

            Catch ex As Exception
                Removed = False
            Finally
                RemoveRecipient = Removed
            End Try

        End Function
        Public Function RemoveRecipient(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal AlertID As Integer, ByVal EmployeeCode As String)

            'objects
            Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
            Dim AlertRecipientDismissed As AdvantageFramework.Database.Entities.AlertRecipientDismissed = Nothing
            Dim Removed As Boolean = False

            Try

                AlertRecipient = (From Item In AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertID(DbContext, AlertID)
                                  Where Item.EmployeeCode = EmployeeCode
                                  Select Item).SingleOrDefault

                If AlertRecipient IsNot Nothing Then

                    DbContext.Entry(AlertRecipient).State = Entity.EntityState.Deleted

                End If

                AlertRecipientDismissed = (From Item In AdvantageFramework.Database.Procedures.AlertRecipientDismissed.LoadByAlertID(DbContext, AlertID)
                                           Where Item.EmployeeCode = EmployeeCode
                                           Select Item).SingleOrDefault

                If AlertRecipientDismissed IsNot Nothing Then

                    DbContext.Entry(AlertRecipientDismissed).State = Entity.EntityState.Deleted

                End If

                DbContext.SaveChanges()

                Removed = True

            Catch ex As Exception
                Removed = False
            Finally
                RemoveRecipient = Removed
            End Try

        End Function

#Region " Attachments "
        Public Function DeleteAttachment(ByVal AlertID As Integer, ByVal DocumentID As Integer, ByVal IsTaskDocument As Boolean) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If IsTaskDocument = False Then

                    Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
                    AlertAttachment = AdvantageFramework.Database.Procedures.AlertAttachment.LoadByAlertIDAndDocumentID(DbContext, AlertID, DocumentID)

                    If AlertAttachment IsNot Nothing Then

                        Deleted = DeleteAttachment(DbContext, AlertAttachment)

                    End If

                Else

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Dim TaskDocument As AdvantageFramework.Database.Entities.JobComponentTaskDocument = Nothing
                        TaskDocument = AdvantageFramework.Database.Procedures.JobComponentTaskDocument.LoadByDocumentID(DataContext, DocumentID)

                        If TaskDocument IsNot Nothing Then

                            Deleted = DeleteTaskDocument(DbContext, DataContext, TaskDocument)

                        End If

                    End Using

                End If

            End Using

            Return Deleted

        End Function
        Public Function DeleteAttachment(ByVal Attachment As AdvantageFramework.Database.Entities.AlertAttachment) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DeleteAttachment = DeleteAttachment(DbContext, Attachment)

            End Using

        End Function
        Public Function DeleteAttachment(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim DeleteFromRepository As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            Try

                Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, AlertAttachment.DocumentID)

                If Document IsNot Nothing Then

                    If Document.FileSystemFileName.StartsWith("a_") Then 'Only delete from repository if attachment was not uploaded to doc mgr level

                        DeleteFromRepository = True

                    End If
                    If DeleteFromRepository = True Then

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        AdvantageFramework.FileSystem.Delete(Agency, Document.FileSystemFileName)

                    End If
                    If AdvantageFramework.Database.Procedures.AlertAttachment.Delete(DbContext, AlertAttachment) Then

                        AdvantageFramework.Database.Procedures.Document.Delete(DbContext, Document)
                        Deleted = True

                    End If

                End If

            Catch ex As Exception
                Deleted = True
            Finally
                DeleteAttachment = Deleted
            End Try

        End Function
        Public Function DeleteTaskDocument(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal TaskDocument As AdvantageFramework.Database.Entities.JobComponentTaskDocument) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim DeleteFromRepository As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            Try

                Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, TaskDocument.DocumentID)

                If Document IsNot Nothing Then

                    If Document.FileSystemFileName.StartsWith("a_") Then

                        DeleteFromRepository = True

                    End If

                    If DeleteFromRepository = True Then

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        AdvantageFramework.FileSystem.Delete(Agency, Document.FileSystemFileName)

                    End If

                    'delete task doc regardless if found in repository...
                    If AdvantageFramework.Database.Procedures.JobComponentTaskDocument.Delete(DataContext, TaskDocument) Then

                        Deleted = True

                        'For Each DocumentAlertAttachment In AdvantageFramework.Database.Procedures.JobComponentTaskDocument.LoadByDocumentID(DataContext, TaskDocument.DocumentID)

                        '    AdvantageFramework.Database.Procedures.JobComponentTaskDocument.Delete(DbContext, DocumentAlertAttachment)

                        'Next

                        AdvantageFramework.Database.Procedures.Document.Delete(DbContext, Document)

                    End If

                End If

            Catch ex As Exception
                Deleted = True
            Finally
                DeleteTaskDocument = Deleted
            End Try

        End Function
        Public Function AddAlertAttachment(ByVal AlertID As Integer, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
            Dim Added As Boolean = False

            If DocumentID > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Added = AddAlertAttachment(DbContext, AlertID, DocumentID)

                End Using

            End If

            Return Added

        End Function
        Public Function AddAlertAttachment(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal DocumentID As Integer) As Boolean

            Return AdvantageFramework.DocumentManager.AddAlertAttachment(DbContext, AlertID, DocumentID)

        End Function
        Public Function SaveAttachments(ByVal AlertID As Integer, ByVal Files As IEnumerable(Of String),
                                        ByVal UploadToRepository As Boolean,
                                        ByVal UploadToProofHQ As Boolean,
                                        ByRef ErrorMessage As String,
                                        ByRef Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document)) As Boolean

            'objects
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Saved As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                If Alert IsNot Nothing Then

                    Saved = SaveAttachments(Alert, Files, UploadToRepository, UploadToProofHQ, ErrorMessage, Documents)

                    If Saved = True AndAlso Alert.AlertCategoryID = 79 Then

                        Try

                            'DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_proofing_get_approvals_list] {0};", AlertID))
                            AdvantageFramework.Proofing.ResetStatus(DbContext, AlertID, ErrorMessage)

                        Catch ex As Exception
                        End Try

                    End If

                End If

            End Using

            Return Saved

        End Function
        Public Function GetUploadDelay() As Integer

            Dim DelayMilliseconds As Integer = 0

            Try

                If System.Web.Configuration.WebConfigurationManager.AppSettings.Get("UploadDelay") IsNot Nothing AndAlso
                                        IsNumeric(System.Web.Configuration.WebConfigurationManager.AppSettings.Get("UploadDelay")) = True Then

                    DelayMilliseconds = CType(System.Web.Configuration.WebConfigurationManager.AppSettings.Get("UploadDelay"), Integer)

                End If

            Catch ex As Exception
                DelayMilliseconds = 0
            End Try

            Return DelayMilliseconds

        End Function
        Public Function SaveAttachments(ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                        ByVal Files As IEnumerable(Of String),
                                        ByVal UploadToRepository As Boolean,
                                        ByVal UploadToProofHQ As Boolean,
                                        ByRef ErrorMessage As String,
                                        ByRef Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document)) As Boolean

            'objects
            Dim FileInfo As System.IO.FileInfo = Nothing
            Dim IsValidFile As Boolean = True
            Dim Prefix As String = Nothing
            Dim RepositoryFileName As String = ""
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim DocumentSource As AdvantageFramework.FileSystem.DocumentSource = FileSystem.DocumentSource.Alert
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim ProofHQUrl As String = ""
            Dim ProofHQFileID As Integer = 0
            Dim Saved As Boolean = False
            Dim RepositoryErrorMessage As String = String.Empty
            Dim DelayMilliseconds As Integer = GetUploadDelay()
            Dim LastDocumentID As Integer = 0

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                        Documents = New List(Of Database.Entities.Document)

                        For Each FullFileName In Files

                            RepositoryFileName = ""
                            RepositoryErrorMessage = ""
                            IsValidFile = True

                            If System.IO.File.Exists(FullFileName) Then

                                FileInfo = New System.IO.FileInfo(FullFileName)

                                If FileInfo.Length > 0 Then

                                    AdvantageFramework.FileSystem.CheckRepositoryConstraints(DbContext, FullFileName, IsValidFile, RepositoryErrorMessage)

                                    If IsValidFile Then

                                        If UploadToRepository Then

                                            DocumentSource = FileSystem.DocumentSource.DocumentUpload

                                        Else

                                            DocumentSource = FileSystem.DocumentSource.Alert

                                        End If

                                        If AdvantageFramework.FileSystem.Add(Agency, FullFileName, "", "", Me.Session.UserCode, "New Alert", "Attached Doc", DocumentSource, FileName:=RepositoryFileName) Then

                                            If Not String.IsNullOrWhiteSpace(RepositoryFileName) Then

                                                Document = New Database.Entities.Document

                                                Document.FileSystemFileName = RepositoryFileName
                                                Document.FileName = FileInfo.Name
                                                Document.Description = Nothing
                                                Document.Keywords = Nothing
                                                Document.MIMEType = AdvantageFramework.FileSystem.GetMIMEType(FileInfo)
                                                Document.UploadedDate = Now
                                                Document.UserCode = Me.Session.UserCode
                                                Document.FileSize = FileInfo.Length
                                                Document.IsPrivate = Nothing
                                                Document.DocumentTypeID = 2 'file

                                                Try

                                                    If Alert.AlertCategoryID = 79 Then

                                                        Document.VersionNumber = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ISNULL(MAX(ISNULL(VERSION_NUMBER, 0)) + 1, 1) FROM DOCUMENTS D WITH(NOLOCK) INNER JOIN ALERT_ATTACHMENT AA WITH(NOLOCK) ON D.DOCUMENT_ID = AA.DOCUMENT_ID WHERE AA.ALERT_ID = {0};", Alert.ID)).SingleOrDefault

                                                    End If

                                                Catch ex As Exception
                                                End Try

                                                If String.IsNullOrWhiteSpace(Document.MIMEType) = True OrElse Document.MIMEType.Contains("unknown") = True Then

                                                    Document.MIMEType = AdvantageFramework.FileSystem.GetMIMETypeByExtension(AdvantageFramework.StringUtilities.ParseLastDot(Document.FileName))

                                                End If

                                                Try

                                                    Document.ID = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                                   Select Entity.ID).Max + 1

                                                Catch ex As Exception
                                                    Document.ID = 1
                                                End Try

                                                If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document) Then
                                                    If Document.FileName.ToLower.EndsWith("png") OrElse Document.FileName.ToLower.EndsWith("bmp") OrElse
                                                        Document.FileName.ToLower.EndsWith("tiff") OrElse Document.FileName.ToLower.EndsWith("gif") OrElse
                                                        Document.FileName.ToLower.EndsWith("jpeg") OrElse Document.FileName.ToLower.EndsWith("jpg") Then

                                                        AdvantageFramework.DocumentManager.UpdateDocumentThumbnail(DbContext, Agency, Document.ID, Nothing)

                                                    End If

                                                    Documents.Add(Document)

                                                    Saved = AddAlertAttachment(Alert.ID, Document.ID)

                                                    If Saved Then

                                                        Try

                                                            DbContext.Database.ExecuteSqlCommand(String.Format("[dbo].[advsp_proofing_add_upload_comment] '{0}', {1}, {2};", Me.Session.UserCode, Alert.ID, Document.ID))

                                                        Catch ex As Exception
                                                        End Try

                                                    End If

                                                    If UploadToRepository Then

                                                        Try

                                                            Select Case Alert.AlertLevel

                                                                Case "OF"

                                                                    AdvantageFramework.DocumentManager.AddOfficeDocument(DbContext, Alert.OfficeCode, Document.ID)

                                                                Case "CL"

                                                                    AdvantageFramework.DocumentManager.AddClientDocument(DataContext, Alert.ClientCode, Document.ID)

                                                                Case "DI"

                                                                    AdvantageFramework.DocumentManager.AddDivisionDocument(DataContext, Alert.ClientCode, Alert.DivisionCode, Document.ID)

                                                                Case "PR", "PRD"

                                                                    AdvantageFramework.DocumentManager.AddProductDocument(DataContext, Alert.ClientCode, Alert.DivisionCode, Alert.ProductCode, Document.ID)

                                                                Case "JO"

                                                                    AdvantageFramework.DocumentManager.AddJobDocument(DataContext, Alert.JobNumber, Document.ID)

                                                                Case "JC", "ES", "EST"

                                                                    AdvantageFramework.DocumentManager.AddJobComponentDocument(DataContext, Alert.JobNumber, Alert.JobComponentNumber, Document.ID)

                                                                Case "PST", "BRD"

                                                                    AdvantageFramework.DocumentManager.AddTaskDocument(DataContext, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, Document.ID)

                                                            End Select

                                                            If UploadToProofHQ Then

                                                                Dim ByteFile() As Byte = Nothing
                                                                ProofHQUrl = String.Empty
                                                                ProofHQFileID = 0

                                                                If AdvantageFramework.FileSystem.Download(Agency, Document, ByteFile) Then

                                                                    If AdvantageFramework.ProofHQ.UploadFile(DbContext, DataContext, Me.Session.User.EmployeeCode, ByteFile,
                                                                                                             Document.FileName, Document.FileName, "", "", 0, ProofHQUrl, ProofHQFileID) Then

                                                                        If String.IsNullOrWhiteSpace(ProofHQUrl) = False Then

                                                                            Document.ProofHQUrl = ProofHQUrl
                                                                            AdvantageFramework.Database.Procedures.Document.Update(DbContext, Document)

                                                                        End If

                                                                    End If

                                                                End If

                                                            End If

                                                        Catch ex As Exception
                                                        End Try

                                                    End If

                                                Else

                                                    If String.IsNullOrWhiteSpace(ErrorMessage) Then

                                                        ErrorMessage = FileInfo.Name & " - failed adding file to database."

                                                    Else

                                                        ErrorMessage &= FileInfo.Name & " - failed adding file to database."

                                                    End If

                                                End If

                                            End If

                                        Else

                                            If String.IsNullOrWhiteSpace(ErrorMessage) Then

                                                ErrorMessage = FileInfo.Name & " - failed adding file to document repository (FileSystem)."

                                            Else

                                                ErrorMessage &= FileInfo.Name & " - failed adding file to document repository (FileSystem)."

                                            End If

                                        End If

                                    Else

                                        If String.IsNullOrWhiteSpace(ErrorMessage) Then

                                            ErrorMessage = FileInfo.Name & " - " & RepositoryErrorMessage

                                        Else

                                            ErrorMessage &= FileInfo.Name & " - " & RepositoryErrorMessage

                                        End If

                                    End If

                                Else

                                    If String.IsNullOrWhiteSpace(ErrorMessage) Then

                                        ErrorMessage = FileInfo.Name & " - cannot upload because it is empty."

                                    Else

                                        ErrorMessage &= FileInfo.Name & " - cannot upload because it is empty."

                                    End If

                                End If

                            Else

                                If String.IsNullOrWhiteSpace(ErrorMessage) Then

                                    ErrorMessage = My.Computer.FileSystem.GetName(FullFileName) & " - Does not exist."

                                Else

                                    ErrorMessage &= System.Environment.NewLine & My.Computer.FileSystem.GetName(FullFileName) & " - Does not exist."

                                End If

                            End If

                            Try

                                If DelayMilliseconds > 0 Then

                                    System.Threading.Thread.Sleep(CType(System.Web.Configuration.WebConfigurationManager.AppSettings.Get("UploadDelay"), Integer))

                                End If

                            Catch ex As Exception
                            End Try

                        Next

                    End Using

                End Using

            Catch ex As Exception
                Saved = False
            Finally
                SaveAttachments = Saved
            End Try

        End Function
        Public Function SaveAttachment(ByVal AlertID As Integer,
                                       ByVal FileName As String,
                                       ByVal UploadToRepository As Boolean,
                                       ByVal UploadToProofHQ As Boolean,
                                       ByRef ErrorMessage As String) As Boolean

            SaveAttachment = SaveAttachments(AlertID, {FileName}, UploadToRepository, UploadToProofHQ, ErrorMessage, Nothing)

        End Function
        Public Function SaveAttachment(ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                       ByVal FileName As String,
                                       ByVal UploadToRepository As Boolean,
                                       ByVal UploadToProofHQ As Boolean,
                                       ByRef ErrorMessage As String) As Boolean

            SaveAttachment = SaveAttachments(Alert, {FileName}, UploadToRepository, UploadToProofHQ, ErrorMessage, Nothing)

        End Function

#End Region

        Public Function NotifyAlertRecipientsOfChanges(ByVal AlertID As Integer) As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient)

            'objects
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertRecipients As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                If Alert IsNot Nothing Then

                    AlertRecipients = NotifyAlertRecipientsOfChanges(DbContext, Alert)

                End If

            End Using

            NotifyAlertRecipientsOfChanges = AlertRecipients

        End Function
        Public Function NotifyAlertRecipientsOfChanges(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient)

            'objects
            Dim AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertRecipients As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID)

                If AlertEntity IsNot Nothing Then

                    AlertRecipients = NotifyAlertRecipientsOfChanges(DbContext, AlertEntity)

                End If

            End Using

            NotifyAlertRecipientsOfChanges = AlertRecipients

        End Function
        Public Function NotifyAlertRecipientsOfChanges(ByVal Alert As AdvantageFramework.Database.Entities.Alert) As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient)

            'objects
            Dim AlertRecipients As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                AlertRecipients = NotifyAlertRecipientsOfChanges(DbContext, Alert)

            End Using

            NotifyAlertRecipientsOfChanges = AlertRecipients

        End Function
        Public Function NotifyAlertRecipientsOfChanges(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Alert As AdvantageFramework.Database.Entities.Alert) As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient)

            'objects
            Dim AlertRecipientDismissedList As Generic.List(Of AdvantageFramework.Database.Entities.AlertRecipientDismissed) = Nothing
            Dim AlertRecipientList As Generic.List(Of AdvantageFramework.Database.Entities.AlertRecipient) = Nothing
            Dim AlertRecipients As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient) = Nothing
            Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
            Dim AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Add As Boolean = False

            Try

                AlertRecipientList = AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertID(DbContext, Alert.ID).ToList

                If AlertRecipientList IsNot Nothing AndAlso AlertRecipientList.Count > 0 Then

                    For Each AlertRecipient In AlertRecipientList

                        Add = False

                        If AlertRecipient.IsCurrentRecipient.GetValueOrDefault(0) = 0 OrElse AlertRecipient.IsCurrentNotify.GetValueOrDefault(0) = 1 Then

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, AlertRecipient.EmployeeCode)

                            If AlertRecipient.IsCurrentNotify.GetValueOrDefault(0) = 1 Then

                                If (Alert.AlertAssignmentTemplateID Is Nothing OrElse Alert.AlertAssignmentTemplateID = 0) AndAlso
                                    (Alert.AlertStateID Is Nothing OrElse Alert.AlertStateID = 0) Then

                                    Add = True 'Non routed

                                End If
                                If AlertRecipient.AlertTemplateID = Alert.AlertAssignmentTemplateID AndAlso
                                        AlertRecipient.AlertStateID = Alert.AlertStateID Then

                                    Add = True 'Routed;  make sure it only includes "current" assignees and not former assignees.

                                End If
                                If Add = True Then

                                    AdvantageFramework.AlertSystem.AddAssignee(DbContext, Alert, Employee, Alert.AlertAssignmentTemplateID, Alert.AlertStateID, AlertRecipient, Nothing, "")

                                End If

                            Else

                                AdvantageFramework.AlertSystem.AddRecipient(DbContext, Alert, Employee.Code, "")

                            End If

                        End If

                    Next

                End If

                AlertRecipientDismissedList = AdvantageFramework.Database.Procedures.AlertRecipientDismissed.LoadByAlertID(DbContext, Alert.ID).ToList

                If AlertRecipientDismissedList IsNot Nothing AndAlso AlertRecipientDismissedList.Count > 0 Then

                    For Each AlertRecipientDismissed In AlertRecipientDismissedList

                        If AlertRecipientDismissed.IsCurrentRecipient.GetValueOrDefault(0) = 0 OrElse AlertRecipientDismissed.IsCurrentNotify.GetValueOrDefault(0) = 1 Then

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, AlertRecipientDismissed.EmployeeCode)

                            If AlertRecipientDismissed.IsCurrentNotify.GetValueOrDefault(0) = 1 Then

                                AdvantageFramework.AlertSystem.AddAssignee(DbContext, Alert, Employee, Alert.AlertAssignmentTemplateID, Alert.AlertStateID, Nothing, AlertRecipientDismissed, "")

                            Else

                                AddRecipient(DbContext, Alert, Employee.Code, "")

                            End If

                        End If

                    Next

                End If

                Try

                    If Alert.AlertLevel = "BRD" Then

                        AdvantageFramework.ProjectSchedule.MarkTaskNotReadForAllExcept(DbContext, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, Me.Session.User.EmployeeCode)

                    End If

                Catch ex As Exception
                End Try

                AlertRecipients = LoadAlertRecipients(DbContext, Alert.ID)

            Catch ex As Exception
                AlertRecipients = Nothing
            Finally
                NotifyAlertRecipientsOfChanges = AlertRecipients
            End Try

        End Function
        Public Sub LoadAppVars(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByRef AutoClose As Boolean,
                               ByRef WidgetLayout As String(),
                               ByRef HideSystemComments As Boolean,
                               ByRef DetailsExpanded As Boolean,
                               ByRef ShowChecklistsOnCards As Boolean,
                               ByRef UploadDocumentManager As Boolean)

            'objects
            Dim AppVars As Generic.List(Of AdvantageFramework.Database.Entities.AppVars) = Nothing

            AppVars = GetAppVars(DbContext)

            AutoClose = GetAutoClose(AppVars)
            WidgetLayout = GetWidgetLayout(AppVars)
            HideSystemComments = GetShowHideSystemComments(AppVars)
            DetailsExpanded = GetDetailsExpanded(AppVars)
            ShowChecklistsOnCards = GetShowChecklistsOnCards(AppVars)
            UploadDocumentManager = GetUploadDocumentManager(AppVars)

        End Sub
        Public Sub LoadAppVars(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertView As AdvantageFramework.ViewModels.Desktop.AlertView)

            LoadAppVars(DbContext, AlertView.AutoClose, AlertView.WidgetLayout, AlertView.HideSystemComments, AlertView.DetailsExpanded, AlertView.ShowChecklistsOnCards, AlertView.UploadDocumentManager)

        End Sub
        Public Function SetShowHideSystemComments(ByVal Hide As Boolean) As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Success As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Success = SetShowHideSystemComments(DbContext, Hide)

                End Using

            Catch ex As Exception
                Success = False
            Finally
                SetShowHideSystemComments = Success
            End Try

        End Function
        Public Function SetShowHideSystemComments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Hide As Boolean) As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Success As Boolean = False

            Try

                AppVar = GetShowHideSystemCommentsVariable(DbContext)

                If AppVar IsNot Nothing Then

                    AppVar.Value = Hide.ToString

                    If AppVar.ID > 0 Then

                        Success = AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

                    Else

                        Success = AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

                    End If

                End If

            Catch ex As Exception
                Success = False
            Finally
                SetShowHideSystemComments = Success
            End Try

        End Function
        Public Function GetShowHideSystemComments() As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Hide As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Hide = GetShowHideSystemComments(DbContext)

                End Using

            Catch ex As Exception
                Hide = False
            Finally
                GetShowHideSystemComments = Hide
            End Try

        End Function
        Public Function GetShowHideSystemComments(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            'objects
            Dim Hide As Boolean = False

            Try

                Hide = GetShowHideSystemComments(GetAppVars(DbContext))

            Catch ex As Exception
                Hide = False
            Finally
                GetShowHideSystemComments = Hide
            End Try

        End Function
        Private Function GetShowHideSystemComments(ByVal AllAppVars As Generic.List(Of AdvantageFramework.Database.Entities.AppVars)) As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Hide As Boolean = False

            Try

                AppVar = GetShowHideSystemCommentsVariable(AllAppVars)

                If AppVar IsNot Nothing Then

                    Hide = CBool(AppVar.Value)

                End If

            Catch ex As Exception
                Hide = False
            Finally
                GetShowHideSystemComments = Hide
            End Try

        End Function
        Private Function GetShowHideSystemCommentsVariable(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.AppVars

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            Try

                AppVar = GetShowHideSystemCommentsVariable(GetAppVars(DbContext))

            Catch ex As Exception
                AppVar = Nothing
            Finally
                GetShowHideSystemCommentsVariable = AppVar
            End Try

        End Function
        Private Function GetShowHideSystemCommentsVariable(ByVal AllAppVars As Generic.List(Of AdvantageFramework.Database.Entities.AppVars)) As AdvantageFramework.Database.Entities.AppVars

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Name As AppVars = AppVars.ShowHideSystemComments

            Try

                AppVar = GetAppVar(AllAppVars, Name)

                If AppVar Is Nothing Then

                    AppVar = New Database.Entities.AppVars
                    AppVar.Name = Name.ToString
                    AppVar.Application = _AppVarApplication
                    AppVar.UserCode = Me.Session.UserCode
                    AppVar.Value = False.ToString

                End If

                AppVar.Type = "Boolean"
                AppVar.Group = 0

            Catch ex As Exception
                AppVar = Nothing
            Finally
                GetShowHideSystemCommentsVariable = AppVar
            End Try

        End Function
        Public Function SetAutoClose(ByVal AutoClose As Boolean) As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Success As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Success = SetAutoClose(DbContext, AutoClose)

                End Using

            Catch ex As Exception
                Success = False
            Finally
                SetAutoClose = Success
            End Try

        End Function
        Public Function SetAutoClose(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AutoClose As Boolean) As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Success As Boolean = False

            Try

                AppVar = GetAutoCloseVariable(DbContext)

                If AppVar IsNot Nothing Then

                    AppVar.Value = AutoClose.ToString

                    If AppVar.ID > 0 Then

                        Success = AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

                    Else

                        Success = AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

                    End If

                End If

            Catch ex As Exception
                Success = False
            Finally
                SetAutoClose = Success
            End Try

        End Function
        Public Function GetAutoClose() As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim AutoClose As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AutoClose = GetAutoClose(DbContext)

                End Using

            Catch ex As Exception
                AutoClose = False
            Finally
                GetAutoClose = AutoClose
            End Try

        End Function
        Public Function GetAutoClose(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            'objects
            Dim AutoClose As Boolean = False

            Try

                AutoClose = GetAutoClose(GetAppVars(DbContext))

            Catch ex As Exception
                AutoClose = False
            Finally
                GetAutoClose = AutoClose
            End Try

        End Function
        Private Function GetAutoClose(ByVal AllAppVars As Generic.List(Of AdvantageFramework.Database.Entities.AppVars)) As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim AutoClose As Boolean = False

            Try

                AppVar = GetAutoCloseVariable(AllAppVars)

                If AppVar IsNot Nothing Then

                    AutoClose = CBool(AppVar.Value)

                End If

            Catch ex As Exception
                AutoClose = False
            Finally
                GetAutoClose = AutoClose
            End Try

        End Function
        Private Function GetAutoCloseVariable(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.AppVars

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            Try

                AppVar = GetAutoCloseVariable(GetAppVars(DbContext))

            Catch ex As Exception
                AppVar = Nothing
            Finally
                GetAutoCloseVariable = AppVar
            End Try

        End Function
        Private Function GetAutoCloseVariable(ByVal AllAppVars As Generic.List(Of AdvantageFramework.Database.Entities.AppVars)) As AdvantageFramework.Database.Entities.AppVars

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Name As AppVars = AppVars.CloseAfterCommentOrReAssign

            Try

                AppVar = GetAppVar(AllAppVars, Name)

                If AppVar Is Nothing Then

                    AppVar = New Database.Entities.AppVars
                    AppVar.Name = Name.ToString
                    AppVar.Application = _AppVarApplication
                    AppVar.UserCode = Me.Session.UserCode
                    AppVar.Value = False.ToString

                End If

                AppVar.Type = "Boolean"
                AppVar.Group = 0

            Catch ex As Exception
                AppVar = Nothing
            Finally
                GetAutoCloseVariable = AppVar
            End Try

        End Function
        Public Function SetShowChecklistsOnCards(ByVal ShowChecklistsOnCards As Boolean) As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Success As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Success = SetShowChecklistsOnCards(DbContext, ShowChecklistsOnCards)

                End Using

            Catch ex As Exception
                Success = False
            Finally
                SetShowChecklistsOnCards = Success
            End Try

        End Function
        Public Function SetShowChecklistsOnCards(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ShowChecklistsOnCards As Boolean) As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Success As Boolean = False

            Try

                AppVar = GetGetShowChecklistsOnCardsVariable(DbContext)

                If AppVar IsNot Nothing Then

                    AppVar.Value = ShowChecklistsOnCards.ToString

                    If AppVar.ID > 0 Then

                        Success = AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

                    Else

                        Success = AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

                    End If

                End If

            Catch ex As Exception
                Success = False
            Finally
                SetShowChecklistsOnCards = Success
            End Try

        End Function
        Public Function GetShowChecklistsOnCards() As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim AutoClose As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AutoClose = GetShowChecklistsOnCards(DbContext)

                End Using

            Catch ex As Exception
                AutoClose = False
            Finally
                GetShowChecklistsOnCards = AutoClose
            End Try

        End Function
        Public Function GetShowChecklistsOnCards(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            'objects
            Dim AutoClose As Boolean = False

            Try

                AutoClose = GetShowChecklistsOnCards(GetAppVars(DbContext))

            Catch ex As Exception
                AutoClose = False
            Finally
                GetShowChecklistsOnCards = AutoClose
            End Try

        End Function
        Private Function GetShowChecklistsOnCards(ByVal AllAppVars As Generic.List(Of AdvantageFramework.Database.Entities.AppVars)) As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim ShowChecklistsOnCards As Boolean = False

            Try

                AppVar = GetGetShowChecklistsOnCardsVariable(AllAppVars)

                If AppVar IsNot Nothing Then

                    ShowChecklistsOnCards = CBool(AppVar.Value)

                End If

            Catch ex As Exception
                ShowChecklistsOnCards = False
            Finally
                GetShowChecklistsOnCards = ShowChecklistsOnCards
            End Try

        End Function
        Private Function GetGetShowChecklistsOnCardsVariable(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.AppVars

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            Try

                AppVar = GetGetShowChecklistsOnCardsVariable(GetAppVars(DbContext))

            Catch ex As Exception
                AppVar = Nothing
            Finally
                GetGetShowChecklistsOnCardsVariable = AppVar
            End Try

        End Function
        Private Function GetGetShowChecklistsOnCardsVariable(ByVal AllAppVars As Generic.List(Of AdvantageFramework.Database.Entities.AppVars)) As AdvantageFramework.Database.Entities.AppVars

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Name As AppVars = AppVars.ShowChecklistsOnCards

            Try

                AppVar = GetAppVar(AllAppVars, Name)

                If AppVar Is Nothing Then

                    AppVar = New Database.Entities.AppVars
                    AppVar.Name = Name.ToString
                    AppVar.Application = _AppVarApplication
                    AppVar.UserCode = Me.Session.UserCode
                    AppVar.Value = False.ToString

                End If

                AppVar.Type = "Boolean"
                AppVar.Group = 0

            Catch ex As Exception
                AppVar = Nothing
            Finally
                GetGetShowChecklistsOnCardsVariable = AppVar
            End Try

        End Function
        Public Function SetUploadDocumentManager(ByVal Upload As Boolean) As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Success As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Success = SetUploadDocumentManager(DbContext, Upload)

                End Using

            Catch ex As Exception
                Success = False
            Finally
                SetUploadDocumentManager = Success
            End Try

        End Function
        Public Function SetUploadDocumentManager(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Upload As Boolean) As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Success As Boolean = False

            Try

                AppVar = GetUploadDocumentManagerVariable(DbContext)

                If AppVar IsNot Nothing Then

                    AppVar.Value = Upload.ToString

                    If AppVar.ID > 0 Then

                        Success = AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

                    Else

                        Success = AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

                    End If

                End If

            Catch ex As Exception
                Success = False
            Finally
                SetUploadDocumentManager = Success
            End Try

        End Function
        Public Function GetUploadDocumentManager() As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Upload As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Upload = GetUploadDocumentManager(DbContext)

                End Using

            Catch ex As Exception
                Upload = False
            Finally
                GetUploadDocumentManager = Upload
            End Try

        End Function
        Public Function GetUploadDocumentManager(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            'objects
            Dim Upload As Boolean = False

            Try

                Upload = GetUploadDocumentManager(GetAppVars(DbContext))

            Catch ex As Exception
                Upload = False
            Finally
                GetUploadDocumentManager = Upload
            End Try

        End Function
        Private Function GetUploadDocumentManager(ByVal AllAppVars As Generic.List(Of AdvantageFramework.Database.Entities.AppVars)) As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Upload As Boolean = False

            Try

                AppVar = GetUploadDocumentManagerVariable(AllAppVars)

                If AppVar IsNot Nothing Then

                    Upload = CBool(AppVar.Value)

                End If

            Catch ex As Exception
                Upload = False
            Finally
                GetUploadDocumentManager = Upload
            End Try

        End Function
        Private Function GetUploadDocumentManagerVariable(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.AppVars

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            Try

                AppVar = GetUploadDocumentManagerVariable(GetAppVars(DbContext))

            Catch ex As Exception
                AppVar = Nothing
            Finally
                GetUploadDocumentManagerVariable = AppVar
            End Try

        End Function
        Private Function GetUploadDocumentManagerVariable(ByVal AllAppVars As Generic.List(Of AdvantageFramework.Database.Entities.AppVars)) As AdvantageFramework.Database.Entities.AppVars

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Name As AppVars = AppVars.UploadDocumentManager

            Try

                AppVar = GetAppVar(AllAppVars, Name)

                If AppVar Is Nothing Then

                    AppVar = New Database.Entities.AppVars
                    AppVar.Name = Name.ToString
                    AppVar.Application = _AppVarApplication
                    AppVar.UserCode = Me.Session.UserCode
                    AppVar.Value = False.ToString

                End If

                AppVar.Type = "Boolean"
                AppVar.Group = 0

            Catch ex As Exception
                AppVar = Nothing
            Finally
                GetUploadDocumentManagerVariable = AppVar
            End Try

        End Function
        Public Function SetDetailsExpanded(ByVal Expanded As Boolean) As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Success As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Success = SetDetailsExpanded(DbContext, Expanded)

                End Using

            Catch ex As Exception
                Success = False
            Finally
                SetDetailsExpanded = Success
            End Try

        End Function
        Public Function SetDetailsExpanded(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Expanded As Boolean) As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Success As Boolean = False

            Try

                AppVar = GetDetailsExpandedVariable(DbContext)

                If AppVar IsNot Nothing Then

                    AppVar.Value = Expanded.ToString

                    If AppVar.ID > 0 Then

                        Success = AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

                    Else

                        Success = AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

                    End If

                End If

            Catch ex As Exception
                Success = False
            Finally
                SetDetailsExpanded = Success
            End Try

        End Function
        Public Function GetDetailsExpanded() As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Expanded As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Expanded = GetDetailsExpanded(DbContext)

                End Using

            Catch ex As Exception
                Expanded = False
            Finally
                GetDetailsExpanded = Expanded
            End Try

        End Function
        Public Function GetDetailsExpanded(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            'objects
            Dim Expanded As Boolean = False

            Try

                Expanded = GetDetailsExpanded(GetAppVars(DbContext))

            Catch ex As Exception
                Expanded = False
            Finally
                GetDetailsExpanded = Expanded
            End Try

        End Function
        Private Function GetDetailsExpanded(ByVal AllAppVars As Generic.List(Of AdvantageFramework.Database.Entities.AppVars)) As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Expanded As Boolean = False

            Try

                AppVar = GetDetailsExpandedVariable(AllAppVars)

                If AppVar IsNot Nothing Then

                    Expanded = CBool(AppVar.Value)

                End If

            Catch ex As Exception
                Expanded = False
            Finally
                GetDetailsExpanded = Expanded
            End Try

        End Function
        Private Function GetDetailsExpandedVariable(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.AppVars

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            Try

                AppVar = GetDetailsExpandedVariable(GetAppVars(DbContext))

            Catch ex As Exception
                AppVar = Nothing
            Finally
                GetDetailsExpandedVariable = AppVar
            End Try

        End Function
        Private Function GetDetailsExpandedVariable(ByVal AllAppVars As Generic.List(Of AdvantageFramework.Database.Entities.AppVars)) As AdvantageFramework.Database.Entities.AppVars

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Name As AppVars = AppVars.DetailsExpanded

            Try

                AppVar = GetAppVar(AllAppVars, Name)

                If AppVar Is Nothing Then

                    AppVar = New Database.Entities.AppVars
                    AppVar.Name = Name.ToString
                    AppVar.Application = _AppVarApplication
                    AppVar.UserCode = Me.Session.UserCode
                    AppVar.Value = True.ToString

                End If

                AppVar.Type = "Boolean"
                AppVar.Group = 0

            Catch ex As Exception
                AppVar = Nothing
            Finally
                GetDetailsExpandedVariable = AppVar
            End Try

        End Function
        Public Function SetWidgetLayout(ByVal WidgetLayout As String()) As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Success As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Success = SetWidgetLayout(DbContext, WidgetLayout)

                End Using

            Catch ex As Exception
                Success = False
            Finally
                SetWidgetLayout = Success
            End Try

        End Function
        Public Function SetWidgetLayout(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal WidgetLayout As String()) As Boolean

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Success As Boolean = False

            Try

                AppVar = GetWidgetLayoutVariable(DbContext)

                If AppVar IsNot Nothing Then

                    AppVar.Value = String.Join(",", WidgetLayout)

                    If AppVar.ID > 0 Then

                        Success = AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

                    Else

                        Success = AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

                    End If

                End If

            Catch ex As Exception
                Success = False
            Finally
                SetWidgetLayout = Success
            End Try

        End Function
        Public Function GetWidgetLayout() As String()

            'objects
            Dim WidgetLayout As String() = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    WidgetLayout = GetWidgetLayout(DbContext)

                End Using

            Catch ex As Exception
                WidgetLayout = Nothing
            Finally
                GetWidgetLayout = WidgetLayout
            End Try

        End Function
        Public Function GetWidgetLayout(ByVal DbContext As AdvantageFramework.Database.DbContext) As String()

            'objects
            Dim WidgetLayout As String() = Nothing

            Try

                WidgetLayout = GetWidgetLayout(GetAppVars(DbContext))

            Catch ex As Exception
                WidgetLayout = Nothing
            Finally
                GetWidgetLayout = WidgetLayout
            End Try

        End Function
        Private Function GetWidgetLayout(ByVal AllAppVars As Generic.List(Of AdvantageFramework.Database.Entities.AppVars)) As String()

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim WidgetLayout As String() = Nothing

            Try

                AppVar = GetWidgetLayoutVariable(AllAppVars)

                If AppVar IsNot Nothing Then

                    WidgetLayout = AppVar.Value.Split(",")

                End If

            Catch ex As Exception
                WidgetLayout = Nothing
            Finally
                GetWidgetLayout = WidgetLayout
            End Try

        End Function
        Private Function GetWidgetLayoutVariable(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.AppVars

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            Try

                AppVar = GetWidgetLayoutVariable(GetAppVars(DbContext))

            Catch ex As Exception
                AppVar = Nothing
            Finally
                GetWidgetLayoutVariable = AppVar
            End Try

        End Function
        Private Function GetWidgetLayoutVariable(ByVal AllAppVars As Generic.List(Of AdvantageFramework.Database.Entities.AppVars)) As AdvantageFramework.Database.Entities.AppVars

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            Try

                AppVar = GetAppVar(AllAppVars, AppVars.WidgetLayout)

                If AppVar Is Nothing Then

                    AppVar = New Database.Entities.AppVars
                    AppVar.Name = AppVars.WidgetLayout.ToString
                    AppVar.Application = _AppVarApplication
                    AppVar.UserCode = Me.Session.UserCode

                End If

                If String.IsNullOrWhiteSpace(AppVar.Value) Then

                    AppVar.Value = "hours,comments,assignment"

                End If

                AppVar.Type = "String"
                AppVar.Group = 0

            Catch ex As Exception
                AppVar = Nothing
            Finally
                GetWidgetLayoutVariable = AppVar
            End Try

        End Function
        Public Function LinkExistingDocuments(ByVal AlertID As Integer, ByVal DocumentIDs As Integer()) As Boolean

            'objects
            Dim Linked As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each DocumentID In DocumentIDs.Where(Function(ID) ID > 0).Distinct.ToList

                        If Not AdvantageFramework.Database.Procedures.AlertAttachment.LoadByAlertID(DbContext, AlertID).Where(Function(alert) alert.DocumentID = DocumentID).Any Then

                            If AddAlertAttachment(DbContext, AlertID, DocumentID) Then

                                Linked = True

                            End If

                        End If

                    Next

                End Using

            Catch ex As Exception
                Linked = False
            Finally
                LinkExistingDocuments = Linked
            End Try

        End Function
        Private Function GetAppVars(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Entities.AppVars)

            Return AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, _AppVarApplication).ToList

        End Function
        Private Function GetAppVar(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AppVarKey As AppVars) As AdvantageFramework.Database.Entities.AppVars

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            Try

                AppVar = GetAppVar(GetAppVars(DbContext), AppVarKey)

            Catch ex As Exception
                AppVar = Nothing
            End Try

            GetAppVar = AppVar

        End Function
        Private Function GetAppVar(ByVal AllAppVars As Generic.List(Of AdvantageFramework.Database.Entities.AppVars), ByVal AppVarKey As AppVars) As AdvantageFramework.Database.Entities.AppVars

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim AppVarName As String = ""

            Try

                AppVarName = AppVarKey.ToString

                AppVar = AllAppVars.Where(Function(var) var.Name = AppVarName).SingleOrDefault

            Catch ex As Exception
                AppVar = Nothing
            End Try

            GetAppVar = AppVar

        End Function
        Public Function ChangeBoardState(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert, ByVal NewStateID As Integer) As Boolean

            Dim Changed As Boolean = False

            If Alert IsNot Nothing AndAlso Alert.IsWorkItem = True AndAlso Alert.BoardID IsNot Nothing AndAlso Alert.SprintID IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Dim SprintDetail As AdvantageFramework.Database.Entities.SprintDetail = Nothing
                    Dim CurrentBoardColumnID As Integer = 0
                    Dim SprintDetailCreated As Boolean = False

                    SprintDetail = AdvantageFramework.Database.Procedures.SprintDetail.LoadByAlertID(DbContext, Alert.ID)

                    If Alert.BoardStateID IsNot Nothing Then

                        CurrentBoardColumnID = Alert.BoardStateID

                    End If
                    If SprintDetail Is Nothing Then

                        CurrentBoardColumnID = -1 'Backlog

                    End If
                    If Alert.IsCompleted = True Then

                        CurrentBoardColumnID = -2 'Completed

                    End If
                    If SprintDetail Is Nothing Then

                        SprintDetail = AdvantageFramework.Database.Procedures.SprintDetail.LoadBySprintIDAlertID(DbContext, Alert.SprintID, Alert.ID)

                        If SprintDetail Is Nothing Then

                            SprintDetail = New Database.Entities.SprintDetail

                            SprintDetail.SprintHeaderID = Alert.SprintID
                            SprintDetail.AlertID = Alert.ID

                            If AdvantageFramework.Database.Procedures.SprintDetail.Insert(DbContext, SprintDetail) = True Then

                                SprintDetailCreated = True

                            End If

                        End If

                    End If
                    If SprintDetail IsNot Nothing Then

                        Changed = AdvantageFramework.ProjectManagement.Agile.MoveBoardItem(Me.Session, NewStateID, SprintDetail, CurrentBoardColumnID)

                    End If

                End Using

            End If

            Return Changed

        End Function
        Public Function GetCheckLists(ByVal AlertID As Integer) As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return _GetChecklists(DbContext, AlertID)

            End Using

        End Function
        Private Function _GetChecklists(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer) As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader)

            'objects
            Dim ChecklistHeaders As Generic.List(Of AdvantageFramework.Database.Entities.ChecklistHeader) = Nothing
            Dim ChecklistDetails As Generic.List(Of AdvantageFramework.Database.Entities.ChecklistDetail) = Nothing
            Dim ChecklistHeaderList As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader) = Nothing
            Dim ChecklistHdr As AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader = Nothing

            ChecklistHeaders = AdvantageFramework.Database.Procedures.ChecklistHeader.LoadByAlertID(DbContext, AlertID).ToList

            If ChecklistHeaders IsNot Nothing AndAlso ChecklistHeaders.Count > 0 Then

                ChecklistHeaderList = New List(Of DTO.Desktop.Alert.ChecklistHeader)

                For Each ChecklistHeader In ChecklistHeaders

                    ChecklistHdr = DTO.Desktop.Alert.ChecklistHeader.FromEntity(ChecklistHeader)

                    ChecklistHdr.ChecklistItems = (From Item In AdvantageFramework.Database.Procedures.ChecklistDetail.LoadByChecklistID(DbContext, ChecklistHdr.ID).ToList
                                                   Select AdvantageFramework.DTO.Desktop.Alert.ChecklistDetail.FromEntity(Item)).ToList

                    If ChecklistHeaderList Is Nothing Then

                        ChecklistHeaderList = New List(Of DTO.Desktop.Alert.ChecklistHeader)

                    End If

                    ChecklistHeaderList.Add(ChecklistHdr)

                Next

            End If

            Return ChecklistHeaderList

        End Function
        Public Function CreateChecklist(ByVal AlertID As Integer, ByVal Checklist As AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader, Optional ByVal IsClientPortal As Boolean = False) As Boolean

            'objects
            Dim Created As Boolean = False
            Dim ChecklistHeader As AdvantageFramework.Database.Entities.ChecklistHeader = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If Me.CreateChecklistHeader(DbContext, AlertID, Checklist, IsClientPortal) Then

                        If Checklist.ChecklistItems IsNot Nothing AndAlso Checklist.ChecklistItems.Count > 0 Then

                            For Each ChecklistItem In Checklist.ChecklistItems

                                Me.CreateChecklistDetail(DbContext, Checklist.ID, ChecklistItem)

                            Next

                        End If

                        Created = True

                    End If

                End Using

            Catch ex As Exception
                Created = False
            Finally
                CreateChecklist = Created
            End Try

        End Function
        Public Function UpdateChecklistTitle(ByVal ChecklistID As Integer, ByVal Title As String) As Boolean

            Dim Updated As Boolean = False
            Dim ChecklistHeader As AdvantageFramework.Database.Entities.ChecklistHeader = Nothing
            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ChecklistHeader = AdvantageFramework.Database.Procedures.ChecklistHeader.LoadByID(DbContext, ChecklistID)

                    If ChecklistHeader IsNot Nothing Then

                        ChecklistHeader.Description = Title

                        Updated = AdvantageFramework.Database.Procedures.ChecklistHeader.Update(DbContext, ChecklistHeader)

                    End If

                End Using

            Catch ex As Exception
                Updated = False
            Finally

                UpdateChecklistTitle = Updated
            End Try

        End Function
        Public Function CreateChecklistItem(ByVal Checklist As AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader, ByVal ChecklistDetail As AdvantageFramework.DTO.Desktop.Alert.ChecklistDetail, Optional ByVal IsClientPortal As Boolean = False) As Boolean

            'objects
            Dim Created As Boolean = False
            Dim ChecklistHeader As AdvantageFramework.Database.Entities.ChecklistHeader = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Created = Me.CreateChecklistDetail(DbContext, Checklist.ID, ChecklistDetail, IsClientPortal)

                End Using

            Catch ex As Exception
                Created = False
            Finally
                CreateChecklistItem = Created
            End Try

        End Function
        Public Function UpdateChecklist(ByVal ChecklistHeader As AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader) As Boolean

            'objects
            Dim Updated As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Updated = Me.UpdateChecklist(DbContext, ChecklistHeader)

                End Using

            Catch ex As Exception
                Updated = False
            Finally
                UpdateChecklist = Updated
            End Try

        End Function
        Public Function UpdateChecklistItem(ByVal ChecklistDetail As AdvantageFramework.DTO.Desktop.Alert.ChecklistDetail, Optional ByVal IsClientPortal As Boolean = False) As Boolean

            'objects
            Dim Updated As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Updated = Me.UpdateChecklistDetail(DbContext, ChecklistDetail, IsClientPortal)

                End Using

            Catch ex As Exception
                Updated = False
            Finally
                UpdateChecklistItem = Updated
            End Try

        End Function
        Public Function DeleteChecklist(ByVal ChecklistHeader As AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Deleted = Me.DeleteChecklist(DbContext, ChecklistHeader)

                End Using

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteChecklist = Deleted
            End Try

        End Function
        Public Function DeleteChecklistItem(ByVal ChecklistDetail As AdvantageFramework.DTO.Desktop.Alert.ChecklistDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Deleted = Me.DeleteChecklistDetail(DbContext, ChecklistDetail)

                End Using

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteChecklistItem = Deleted
            End Try

        End Function
        Private Function CreateChecklistHeader(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal Checklist As AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader, Optional ByVal IsClientPortal As Boolean = False) As Boolean

            'objects
            Dim ChecklistHeader As AdvantageFramework.Database.Entities.ChecklistHeader = Nothing
            Dim Added As Boolean = False

            Try

                ChecklistHeader = New AdvantageFramework.Database.Entities.ChecklistHeader

                ChecklistHeader.AlertID = AlertID
                If IsClientPortal = True Then
                    ChecklistHeader.CreatedBy = Me.Session.ClientPortalUser.ClientContactID.ToString
                Else
                    ChecklistHeader.CreatedBy = Me.Session.User.EmployeeCode
                End If
                ChecklistHeader.CreatedDate = System.DateTime.Today
                ChecklistHeader.Description = Checklist.Description

                If AdvantageFramework.Database.Procedures.ChecklistHeader.Insert(DbContext, ChecklistHeader) Then

                    Checklist.ID = ChecklistHeader.ID
                    Added = True

                End If

            Catch ex As Exception
                Added = False
            Finally
                CreateChecklistHeader = Added
            End Try

        End Function
        Private Function CreateChecklistDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChecklistID As Integer, ByVal ChecklistItem As AdvantageFramework.DTO.Desktop.Alert.ChecklistDetail, Optional ByVal IsClientPortal As Boolean = False) As Boolean

            'objects
            Dim ChecklistDetail As AdvantageFramework.Database.Entities.ChecklistDetail = Nothing
            Dim Added As Boolean = False

            Try

                ChecklistDetail = New AdvantageFramework.Database.Entities.ChecklistDetail

                ChecklistDetail.ChecklistID = ChecklistID
                ChecklistDetail.Description = ChecklistItem.Description
                ChecklistDetail.IsChecked = ChecklistItem.IsChecked
                ChecklistDetail.SortOrder = ChecklistItem.SortOrder
                If IsClientPortal = True Then
                    ChecklistDetail.CreatedBy = Me.Session.ClientPortalUser.ClientContactID.ToString
                Else
                    ChecklistDetail.CreatedBy = Me.Session.User.EmployeeCode
                End If
                ChecklistDetail.CreatedDate = System.DateTime.Today

                If AdvantageFramework.Database.Procedures.ChecklistDetail.Insert(DbContext, ChecklistDetail) Then

                    Added = True
                    ChecklistItem.ID = ChecklistDetail.ID

                End If

            Catch ex As Exception
                Added = False
            Finally
                CreateChecklistDetail = Added
            End Try

        End Function
        Private Function UpdateChecklist(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Checklist As AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader) As Boolean

            'objects
            Dim ChecklistHeader As AdvantageFramework.Database.Entities.ChecklistHeader = Nothing
            Dim Updated As Boolean = False

            Try

                ChecklistHeader = AdvantageFramework.Database.Procedures.ChecklistHeader.LoadByID(DbContext, Checklist.ID)

                If ChecklistHeader IsNot Nothing Then

                    ChecklistHeader.Description = Checklist.Description

                    Updated = AdvantageFramework.Database.Procedures.ChecklistHeader.Update(DbContext, ChecklistHeader)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                UpdateChecklist = Updated
            End Try

        End Function
        Private Function UpdateChecklistDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChecklistItem As AdvantageFramework.DTO.Desktop.Alert.ChecklistDetail, Optional ByVal IsClientPortal As Boolean = False) As Boolean

            'objects
            Dim ChecklistDetail As AdvantageFramework.Database.Entities.ChecklistDetail = Nothing
            Dim Updated As Boolean = False

            Try

                ChecklistDetail = AdvantageFramework.Database.Procedures.ChecklistDetail.LoadByID(DbContext, ChecklistItem.ID)

                If ChecklistDetail IsNot Nothing Then

                    ChecklistDetail.Description = ChecklistItem.Description
                    ChecklistDetail.IsChecked = ChecklistItem.IsChecked
                    If IsClientPortal = True Then
                        ChecklistDetail.ModifiedBy = Me.Session.ClientPortalUser.ClientContactID.ToString
                    Else
                        ChecklistDetail.ModifiedBy = Me.Session.User.EmployeeCode
                    End If
                    ChecklistDetail.ModifiedDate = System.DateTime.Today

                    Updated = AdvantageFramework.Database.Procedures.ChecklistDetail.Update(DbContext, ChecklistDetail)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                UpdateChecklistDetail = Updated
            End Try

        End Function
        Private Function DeleteChecklist(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Checklist As AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader) As Boolean

            'objects
            Dim ChecklistHeader As AdvantageFramework.Database.Entities.ChecklistHeader = Nothing
            Dim Deleted As Boolean = False

            Try

                ChecklistHeader = AdvantageFramework.Database.Procedures.ChecklistHeader.LoadByID(DbContext, Checklist.ID)

                If ChecklistHeader IsNot Nothing Then

                    Deleted = AdvantageFramework.Database.Procedures.ChecklistHeader.Delete(DbContext, ChecklistHeader)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteChecklist = Deleted
            End Try

        End Function
        Private Function DeleteChecklistDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChecklistItem As AdvantageFramework.DTO.Desktop.Alert.ChecklistDetail) As Boolean

            'objects
            Dim ChecklistDetail As AdvantageFramework.Database.Entities.ChecklistDetail = Nothing
            Dim Deleted As Boolean = False

            Try

                ChecklistDetail = AdvantageFramework.Database.Procedures.ChecklistDetail.LoadByID(DbContext, ChecklistItem.ID)

                If ChecklistDetail IsNot Nothing Then

                    Deleted = AdvantageFramework.Database.Procedures.ChecklistDetail.Delete(DbContext, ChecklistDetail)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteChecklistDetail = Deleted
            End Try

        End Function
        Public Function LoadCopyAndTransferJobs(ByVal AlertID As Integer, ByVal SprintID As Integer?) As Generic.List(Of AdvantageFramework.DTO.JobComponent)

            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim JobComponents As Generic.List(Of AdvantageFramework.DTO.JobComponent) = Nothing
            Dim AllJobs As Boolean = False

            If SprintID Is Nothing Then SprintID = 0

            JobComponents = AdvantageFramework.ProjectManagement.Agile.LoadSprintJobComponents(Me.Session, 0, AlertID, AdvantageFramework.ProjectManagement.Agile.Methods.JobComponentLookupObjectLevel.Component)

            Return JobComponents

        End Function
        Public Function TransferAlert(ByVal AlertID As Integer, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                      ByVal BoardID As Integer, ByVal BoardSprintID As Integer, ByVal BoardStateID As Integer) As Boolean

            Dim Transferred As Boolean = False
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing


            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                Transferred = AdvantageFramework.AlertSystem.TransferAlert(DbContext, Alert, JobNumber, JobComponentNumber,
                                                                           BoardID, BoardSprintID, BoardStateID)

                If Transferred = True Then

                    If BoardStateID > 0 AndAlso Alert.BoardStateID <> BoardStateID Then

                        Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)
                        Alert.BoardStateID = BoardStateID

                        AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert)

                    End If

                    NotifyAlertRecipientsOfChanges(DbContext, Alert)

                End If

            End Using

            Return Transferred

        End Function
        Public Function CopyAlert(ByVal SecuritySession As AdvantageFramework.Security.Session,
                                  ByVal Alert As AdvantageFramework.DTO.Desktop.Alert, ByVal CopyComments As Boolean, ByVal CopyAttachments As Boolean) As Integer

            Dim NewAlertID As Integer = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If Alert.AlertAssignmentTemplateID Is Nothing Then Alert.AlertAssignmentTemplateID = 0
                If Alert.AlertStateID Is Nothing Then Alert.AlertStateID = 0
                If Alert.BoardID Is Nothing Then Alert.BoardID = 0
                If Alert.SprintID Is Nothing Then Alert.SprintID = 0
                If Alert.BoardStateID Is Nothing Then Alert.BoardStateID = 0

                NewAlertID = AdvantageFramework.AlertSystem.CopyAlert(DbContext, Alert.ID, Alert.JobNumber, Alert.JobComponentNumber,
                                                                      Alert.AlertAssignmentTemplateID, Alert.AlertStateID, Alert.AssignedEmployeeCode,
                                                                      Alert.BoardID, Alert.SprintID, Alert.BoardStateID,
                                                                      CopyComments, CopyAttachments,
                                                                      Alert, SecuritySession)

            End Using

            Return NewAlertID

        End Function
        Public Function IsNoTaskBoard(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal AlertID As Integer) As Boolean

            Dim IsOnNoTaskBoard As Boolean = False

            Try

                Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                If Alert IsNot Nothing Then

                    If Alert.AlertCategoryID = 71 Then

                        IsOnNoTaskBoard = JobIsNoTaskBoard(DbContext, Alert.JobNumber, Alert.JobComponentNumber)

                    End If

                End If

            Catch ex As Exception
                IsOnNoTaskBoard = False
            End Try

            Return IsOnNoTaskBoard

        End Function
        Public Function JobIsNoTaskBoard(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal JobNumber As Integer,
                                         ByVal JobComponentNumber As Short) As Boolean

            Dim IsOnNoTaskBoard As Boolean = False

            Try

                Dim Boards As Generic.List(Of AdvantageFramework.Database.Entities.Board) = Nothing
                Dim BoardHeader As AdvantageFramework.Database.Entities.BoardHeader = Nothing
                Dim BoardHeaderIDs As Generic.List(Of Integer?) = Nothing

                Boards = AdvantageFramework.Database.Procedures.Board.LoadByJobAndComponent(DbContext, JobNumber, JobComponentNumber).ToList()

                If Boards IsNot Nothing AndAlso Boards.Count > 0 Then

                    BoardHeaderIDs = (From Entity In Boards
                                      Select Entity.BoardHeaderID).Distinct.ToList

                    If BoardHeaderIDs IsNot Nothing AndAlso BoardHeaderIDs.Count > 0 Then

                        For Each BoardHeaderID As Integer In BoardHeaderIDs

                            BoardHeader = Nothing
                            BoardHeader = AdvantageFramework.Database.Procedures.BoardHeader.LoadByBoardID(DbContext, BoardHeaderID)

                            If BoardHeader IsNot Nothing Then

                                If BoardHeader.ExcludeTasks IsNot Nothing AndAlso BoardHeader.ExcludeTasks = True Then

                                    IsOnNoTaskBoard = True
                                    Exit For

                                End If

                            End If

                        Next

                    End If

                End If


            Catch ex As Exception
                IsOnNoTaskBoard = False
            End Try

            Return IsOnNoTaskBoard

        End Function
        Public Function CheckForBoard(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As ViewModels.ProjectManagement.Agile.AvailableBoardInfo

            Dim BoardInfo As New ViewModels.ProjectManagement.Agile.AvailableBoardInfo

            Dim HasActiveBoard As Boolean = False
            Dim HasSprint As Boolean = False

            Dim JobSpecificBoards As Generic.List(Of AdvantageFramework.Database.Entities.Board) = Nothing
            Dim AllJobsBoards As Generic.List(Of AdvantageFramework.Database.Entities.Board) = Nothing

            Dim AvailableBoards As New Generic.List(Of AdvantageFramework.Database.Entities.Board)
            Dim DisplayBoards As New Generic.List(Of AdvantageFramework.Database.Entities.Board)

            If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    JobSpecificBoards = (From Entity In AdvantageFramework.Database.Procedures.Board.LoadByJobAndComponent(DbContext, JobNumber, JobComponentNumber)
                                         Where Entity.IsActive Is Nothing OrElse Entity.IsActive = True
                                         Select Entity).ToList

                    If JobSpecificBoards IsNot Nothing AndAlso JobSpecificBoards.Count > 0 Then

                        For Each Board In JobSpecificBoards

                            AvailableBoards.Add(Board)

                        Next

                    End If

                    AllJobsBoards = (From Entity In AdvantageFramework.Database.Procedures.Board.LoadAllJobsBoards(DbContext)
                                     Where Entity.IsActive Is Nothing OrElse Entity.IsActive = True
                                     Select Entity).ToList

                    If AllJobsBoards IsNot Nothing AndAlso AllJobsBoards.Count > 0 Then

                        For Each Board In AllJobsBoards

                            AvailableBoards.Add(Board)

                        Next

                    End If
                    If AvailableBoards IsNot Nothing AndAlso AvailableBoards.Count > 0 Then

                        HasActiveBoard = True

                        Dim Sprints As Generic.List(Of AdvantageFramework.Database.Entities.SprintHeader) = Nothing

                        For Each Board As AdvantageFramework.Database.Entities.Board In AvailableBoards

                            Sprints = AdvantageFramework.Database.Procedures.SprintHeader.LoadByBoardID(DbContext, Board.ID).ToList

                            If Sprints IsNot Nothing AndAlso Sprints.Count > 0 Then

                                For Each Sprint As AdvantageFramework.Database.Entities.SprintHeader In Sprints

                                    If (Sprint.IsComplete Is Nothing OrElse Sprint.IsComplete = False) Then

                                        If HasSprint = False Then HasSprint = True
                                        DisplayBoards.Add(Board)
                                        Exit For

                                    End If

                                Next

                            End If

                            Sprints = Nothing

                        Next

                    End If

                End Using

            Else

                HasActiveBoard = False
                HasSprint = False

            End If

            If DisplayBoards Is Nothing OrElse DisplayBoards.Count = 0 Then

                HasActiveBoard = False
                HasSprint = False

            End If

            If HasActiveBoard = True AndAlso HasSprint = True Then

                BoardInfo.DisplayBoards = DisplayBoards

                If DisplayBoards.Count = 1 Then

                    BoardIDChanged(DisplayBoards.Item(0).ID, 0)

                ElseIf DisplayBoards.Count > 1 Then

                    'Dim PleaseSelect As New AdvantageFramework.Database.Entities.Board

                    'PleaseSelect.BoardHeaderID = 0
                    'PleaseSelect.Name = "[Please select]"

                    'DisplayBoards.Insert(0, PleaseSelect)

                End If

                BoardInfo.HasActiveBoard = True

            Else

                BoardInfo.HasActiveBoard = False

            End If

            Return BoardInfo

        End Function
        Public Function BoardIDChanged(ByVal BoardID As Integer, ByVal SprintID As Integer) As ViewModels.ProjectManagement.Agile.AvailableBoardInfo

            Dim BoardInfo As New ViewModels.ProjectManagement.Agile.AvailableBoardInfo

            Dim DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

            Dim Board As AdvantageFramework.Database.Entities.Board = Nothing
            Dim Sprints As Generic.List(Of AdvantageFramework.Database.Entities.SprintHeader) = Nothing
            Dim States As Generic.List(Of AdvantageFramework.Database.Entities.AlertState) = Nothing

            Board = AdvantageFramework.Database.Procedures.Board.LoadByBoardID(DbContext, BoardID)

            If Board IsNot Nothing Then

                BoardInfo.DisplayBoards.Add(Board)

                Sprints = AdvantageFramework.Database.Procedures.SprintHeader.LoadByBoardID(DbContext, BoardID).ToList

                If Sprints IsNot Nothing AndAlso Sprints.Count > 0 Then

                    For Each Sprint As AdvantageFramework.Database.Entities.SprintHeader In Sprints

                        If (Sprint.IsComplete Is Nothing OrElse Sprint.IsComplete = False) Then

                            If Sprint.IsActive IsNot Nothing AndAlso Sprint.IsActive = True Then

                                BoardInfo.ActiveSprintID = Sprint.ID

                            End If

                            BoardInfo.Sprints.Add(Sprint)

                        End If

                    Next

                End If

                If SprintID > 0 Then

                    States = (From ALS In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.AlertState)
                              Join BD In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.BoardDetail) On ALS.ID Equals BD.AlertStateID
                              Join BH In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.BoardHeader) On BH.ID Equals BD.BoardHeaderID
                              Join B In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Board) On B.BoardHeaderID Equals BH.ID
                              Join SH In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.SprintHeader) On SH.BoardID Equals B.ID
                              Where BD.BoardHeaderID = Board.BoardHeaderID And (ALS.IsActive Is Nothing Or ALS.IsActive = True) And SH.ID = SprintID
                              Order By BD.SequenceNumber
                              Select ALS).ToList

                    If States IsNot Nothing Then

                        BoardInfo.States = States

                    End If

                    If BoardInfo.States Is Nothing Then BoardInfo.States = New List(Of Database.Entities.AlertState)

                    Dim BacklogState As New AdvantageFramework.Database.Entities.AlertState

                    BacklogState.ID = -1
                    BacklogState.Name = "[Backlog]"

                    BoardInfo.States.Insert(0, BacklogState)

                End If

            End If

            Return BoardInfo

        End Function
        Public Function GetBoardSprints(ByVal BoardID As Integer) As Generic.List(Of AdvantageFramework.Database.Entities.SprintHeader)

            Dim DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

            'Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

            GetBoardSprints = (From Entity In AdvantageFramework.Database.Procedures.SprintHeader.LoadByBoardID(DbContext, BoardID)
                               Where Entity.IsComplete Is Nothing Or Entity.IsComplete = False
                               Select Entity).ToList

            'End Using

        End Function
        'Public Function GetBoardSprintStates(ByVal SprintID As Integer) As Generic.List(Of AdvantageFramework.Database.Entities.AlertState)

        '    Dim States As Generic.List(Of AdvantageFramework.Database.Entities.AlertState) = Nothing

        '    Dim DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '    Dim BoardHeaderID As Integer = 0

        '    'Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '    Try

        '        Dim SQL As String = String.Format("SELECT TOP 1 ISNULL(BH.ID, 0) FROM SPRINT_HDR SH INNER JOIN BOARD B ON SH.BOARD_ID = B.ID INNER JOIN BOARD_HDR BH ON B.BOARD_HDR_ID = BH.ID WHERE SH.ID = {0};", SprintID)

        '        BoardHeaderID = DbContext.Database.SqlQuery(Of Integer)(SQL).SingleOrDefault

        '    Catch ex As Exception
        '        BoardHeaderID = 0
        '        End Try

        '    If BoardHeaderID > 0 Then

        '        'States = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.AlertState)
        '        '          'Join BD In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.BoardDetail) On Entity.ID Equals BD.AlertStateID
        '        '          'Where BD.BoardHeaderID = BoardHeaderID And (Entity.IsActive Is Nothing Or Entity.IsActive = True)
        '        '          'Order By BD.SequenceNumber
        '        '          Select Entity).ToList

        '    End If

        '    'End Using

        '    If States Is Nothing Then States = New List(Of Database.Entities.AlertState)

        '    Return States

        'End Function
        Public Function GetBoardSprintStates(ByVal SprintID As Integer) As Generic.List(Of BoardSelectData)

            Dim SQL = "SELECT ALS.ALERT_STATE_ID AS ID, ALS.ALERT_STATE_NAME AS Name " &
                      "FROM SPRINT_HDR SH " &
                      "INNER JOIN BOARD B ON SH.BOARD_ID = B.ID " &
                      "INNER JOIN BOARD_HDR BH ON B.BOARD_HDR_ID = BH.ID " &
                      "INNER JOIN BOARD_DTL BD ON BH.ID = BD.BOARD_HDR_ID " &
                      "INNER JOIN ALERT_STATES ALS ON BD.ALERT_STATE_ID = ALS.ALERT_STATE_ID " &
                      "WHERE SH.ID = {0} " &
                      "ORDER BY BD.SEQ_NBR;"


            Dim DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)
            'Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

            GetBoardSprintStates = DbContext.Database.SqlQuery(Of BoardSelectData)(String.Format(SQL, SprintID)).ToList

            'End Using

        End Function
        Public Function CanAddTimeToJob(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByRef Message As String) As Boolean

            Dim _CanAddTimeToJob As Boolean = False

            If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                If AdvantageFramework.Timesheet.JobCompIsEditable(Me.Session.ConnectionString, JobNumber, JobComponentNumber) = False Then

                    Message = "Job/Component Process Control does not allow access."

                Else

                    _CanAddTimeToJob = True

                End If


            Else

                Message = "Invalid job/component"

            End If

            Return _CanAddTimeToJob

        End Function
        Public Function GetJobVersionDefaults() As Generic.List(Of AdvantageFramework.DTO.Maintenance.General.Settings.Setting)
            Dim Defaults As Generic.List(Of AdvantageFramework.DTO.Maintenance.General.Settings.Setting) = New List(Of DTO.Maintenance.General.Settings.Setting)

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

                Defaults = (From Entity In AdvantageFramework.Database.Procedures.Setting.LoadBySettingModuleID(DataContext, 2)
                            Where Entity.SettingModuleTabID = 0
                            Select DTO.Maintenance.General.Settings.Setting.FromEntity(Entity)).ToList


            End Using

            Return Defaults
        End Function

#End Region

#Region " Classes "

        <Serializable()>
        Public Class BoardSelectData
            Public Property ID As Integer = 0
            Public Property Name As String = String.Empty
            Public Property ActiveOrSelected As Boolean = False
            Sub New()

            End Sub
        End Class
        <Serializable()>
        Public Class AlertHours
            Public Property AlertID As Integer? = 0
            Public Property StartDate As Date? = Nothing
            Public Property DueDate As Date? = Nothing
            Public Property HoursAllowed As Decimal? = 0.00
            Public Property HoursPosted As Decimal? = 0.00
            Public Property HoursAllocated As Decimal? = 0.00
            Public Property HoursBalance As Decimal? = 0.00
            Public Property HoursAllocatedBalance As Decimal? = 0.00
            Public Property HasCalculatedHours As Boolean? = False
            Public Property HasWeeklyHours As Boolean? = False
            Sub New()

            End Sub
        End Class
        <Serializable()>
        Public Class SimpleSelectList
            Public Property Code As String = String.Empty
            Public Property Name As String = String.Empty
            Sub New()

            End Sub
        End Class
        <Serializable()>
        Public Class SimpleAlertBody

            Public Property AlertTypeID As Integer
            Public Property AlertCategoryID As Integer
            Public Property Description As String

            Sub New()

            End Sub

        End Class

#End Region

    End Class

End Namespace
